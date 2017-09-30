/*
 * Created by SharpDevelop.

 * Date: 9/13/2017
 * Time: 8:12 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 
#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;

using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Host;
using System.Management.Automation.Runspaces;

using System.Text;
using PowerShell = System.Management.Automation.PowerShell;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using System.ComponentModel;

namespace UI.Body.PSHostUI.Classes
{
	/// <summary>
	/// Description of objPSListener.
	/// </summary>
	public class objPSListener
	{
		// This is to replace everything

		private PSDataCollection<PSObject> psObjectHandler;
		
		
		
		
		internal Runspace runspace;
		#region Can Remove This
		
		private bool shouldexit;
		private int exitcode;
		
		#endregion
		// Holds PSHost
		private objPSHost _objPSHost;
		private object instanceLock = new object();
		private PowerShell powershell;
		

		#region define Buffer
		
		public string buffer {
			get {
				return _objPSHost.buffer;
			}
			set {
				_objPSHost.buffer = value;
			}
		}
		public event EventHandler onBufferChanged;
		
		#endregion define Buffer
		
		
		
		
		#region Can Remove This
		public bool shouldExit {
			get { return this.shouldexit; }
			set { this.shouldexit = value; }
		}
		public int ExitCode {
			get { return this.exitcode; }
			set { this.exitcode = value; }
		}
		#endregion
		public objPSListener()
		{
			this._objPSHost = new objPSHost(this);
			this._objPSHost.onBufferChanged += (sender, e) => {
				if (onBufferChanged != null)
					onBufferChanged(this, EventArgs.Empty);
			};
			this.runspace = RunspaceFactory.CreateRunspace(this._objPSHost);
			this.runspace.Open();

			this.executehelper("Write-Host Windows Powershell `r`nCopyright `(C`) 2016 Microsoft Corporation. All rights reserved.`r`n`r`n", null);
			//C:\Users\v-jurom\Documents\WindowsPowerShell\Microsoft.PowerShell_profile.ps1
		}
		
		private void ReportException(Exception e)
		{
			if (e != null)
			{
				object error;
				IContainsErrorRecord icer = e as IContainsErrorRecord;
				if (icer != null) {
					error = icer.ErrorRecord;
				} else {
					error = (object)new ErrorRecord(e, "Host.ReportException", ErrorCategory.NotSpecified, null);
				}
				
				lock (this.instanceLock)
				{
					this.powershell = PowerShell.Create();
				}
				this.powershell.Runspace = this.runspace;
				
				try {
					this.powershell.AddScript("$input").AddCommand("out-string");
					// Do not merge errors, this function will swallow all errors.
					Collection<PSObject> result;
					PSDataCollection<object> inputcollection = new PSDataCollection<object>();
					
					inputcollection.Add(error);
					inputcollection.Complete();
					
					result = this.powershell.Invoke(inputcollection);
					
					if (result.Count > 0) {
						string str = result[0].BaseObject as string;
						if (!string.IsNullOrEmpty(str))
						{
							// remove \r\n, which is added by the out str commandlet
							this._objPSHost.UI.WriteErrorLine(str.Substring(0, str.Length - 2));
						}
					}
				}
				finally {
					lock (this.instanceLock)
					{
						this.powershell.Dispose();
						this.powershell = null;
					}
				}
			}
		}

		private void executehelper(IAsyncResult result)
		{
			if (result.IsCompleted != true)
				return;
			
			this.powershell.Commands.Clear();
			this.powershell.AddScript("write-host PS $pwd>");
			this.powershell.Invoke();
			this.powershell.Dispose();
			this.powershell = null;
		}
		private void executehelper(string cmd, object input)
		{
			if (string.IsNullOrEmpty(cmd))
				return;

			
			if (this.powershell == null) {
				this.powershell = PowerShell.Create();
				this.powershell.Runspace = this.runspace;
			}
			if (this.powershell.InvocationStateInfo.State == PSInvocationState.Running)
				return;
			
			
			this.powershell.Commands.Clear();
			this.powershell.AddScript(cmd);
			//this.powershell.AddCommand("out-default");
			this.powershell.Commands.Commands[0].MergeMyResults(PipelineResultTypes.Error, PipelineResultTypes.Output);
			psObjectHandler = new PSDataCollection<PSObject>();
			
			psObjectHandler.DataAdded += (sender, e) => {
				PSDataCollection<PSObject> myp = (PSDataCollection<PSObject>)sender;
				Collection<PSObject> results = myp.ReadAll();
				
				

				//string SerializedCollection = PSSerializer.Serialize(results);
				//buffer += string.Format("Serialized Output: {0}\r\n", SerializedCollection );
				//object[] o = PSSerializer.DeserializeAsList(SerializedCollection);
				
				//buffer += string.Format("Deserialized output: {0}\r\n", o);
				//PSTypeConverter convert = new PSTypeConverter();
				//ConvertThroughString convert = new ConvertThroughString();
				//buffer += convert.CanConvertTo(results,typeof(String)).ToString();
					
				foreach (PSObject result in results)
				{
					//TypeData(result);

					

					foreach (string ti in result.TypeNames) {
						buffer += String.Format("     -> {0}\r\n", ti);
					}
					
					//foreach (PSProperty i in result.TypeNames) {

						//buffer += String.Format("{0}:{1}:{2}\r\n", i.Name, i.MemberType, i.Value);
						//buffer += String.Format("{0}:{1} = {2}\r\n", "", i.Name, "");
						/*
						if (i.MemberType.ToString() == "CodeProperty") {
							buffer += String.Format("     -> {0}\r\n", i.TypeNameOfValue);
						}
						*/
					//}
					
					//buffer += String.Format("{0}\r\n", result.TypeNames.ToString() );
					//System.Runtime.Serialization.SerializationInfo serializationInfo = new System.Runtime.Serialization.SerializationInfo();
					//buffer += "\r\n";
					//buffer += (result.BaseObject as Hashtable).ToString();
					buffer += result.ToString();
					
					buffer += "\r\n";

					//buffer += result.TypeNames.Contains()
					/*
					foreach (string i in result.TypeNames){
						
						buffer += i;
						buffer += "\r\n";
					}
					*/
					/*
					foreach (PSPropertyInfo i in result.Properties) {
						//buffer += i.Name + i.MemberType.HasFlag().ToString() + "\r\n";
						if (i.IsInstance) {
							buffer += String.Format("{0}:{1}:{2}\r\n", i.Name, i.MemberType.ToString(), i.Value);
							//buffer += i.Name + ":" + i.MemberType.ToString() + "\r\n";
						}
						
						
						
					}
					*/
					//buffer += result.GetObjectData(null, null);
					//buffer += result.ToString();
					buffer += "-----\r\n";
				}

				
			};
			
			
			this.powershell.BeginInvoke<PSObject, PSObject>(null, psObjectHandler, null, new AsyncCallback(executehelper), null);
			//this.powershell.BeginInvoke<PSObject>(null, null, new AsyncCallback(executehelper), null);
		}

		public void Execute(string cmd)
		{
			try {
				this.executehelper(cmd, null);
			}
			catch (RuntimeException rte)
			{
				this.ReportException(rte);
			}
		}
	}
}

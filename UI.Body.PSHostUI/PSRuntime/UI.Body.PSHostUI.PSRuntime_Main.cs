/*
 * Created by SharpDevelop.
 * Date: 08/15/2017
 * Time: 14:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;
using System.Globalization;
using System.Data;
using System.Collections;
using System.Reflection;
using System.Windows.Forms;
using System.Runtime.Remoting;
namespace UI.Body.PSHostUI
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public partial class PSRuntime
	{
		public PowerShell instance;
		public Runspace runspace;
		private PSDataCollection<PSObject> psObjectHandler;
		
		//internal delegate PSCmdlet OuterCmdletCallback
        private CultureInfo originalCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
        private CultureInfo originalUICultureInfo = System.Threading.Thread.CurrentThread.CurrentUICulture;
        
        // Needs to be Implemented
        // SmartToString(PSObject, MSHExpressionFactory, enumerationlimit, stringformaterror)
        //public static extern Microsoft.PowerShell.Commands.Internal.Format.PSObjectHelper ir_obj;
        
        
        //Microsoft.PowerShell.Commands.FormatDefaultCommand v = new Microsoft.PowerShell.Commands.FormatDefaultCommand();
        
        	
        public class PSObjectHelper {
        	// Microsoft.PowerShell.Commands.Internal.Format.PSObjectHelper o;
        	PSObjectHelper() {
        		
        		
        	}
        }
        
        
        public CultureInfo CurrentCulture
        {
            get { return this.originalCultureInfo; }
        }
        public CultureInfo CurrentUICulture
        {
            get { return this.originalUICultureInfo; }
        }

		public void ps_init()
		{
			
			
			if (instance == null) {
				instance = PowerShell.Create();
				buffer_writeline("Copyright (C) 2016 Microsoft Corporation. All rights reserved.");
				buffer_writeline("");
				instance.InvocationStateChanged += Event_InvocationStateChanged;
					
				instance.Streams.Debug.DataAdded += Event_Debug_DataAdded;
				instance.Streams.Error.DataAdded += Event_Error_DataAdded;
				instance.Streams.Information.DataAdded += Event_Information_DataAdded;
				//instance.Streams.Progress
				instance.Streams.Verbose.DataAdded += Error_Verbose_DataAdded;
				//instance.Runspace.
				//instance.Streams.Warning
				
				psObjectHandler = new PSDataCollection<PSObject>();
				psObjectHandler.DataAdded += Event_Object_DataAdded;
				
				//history_init();
			}
			
		}
		public void ps_start() {
			
			if (instance.InvocationStateInfo.State == PSInvocationState.Running)
				return;
			string str_ = "";
			if (System.IO.Directory.Exists(PATH) == true)
				str_ += "cd " + PATH + "\r\n";
			if (SCRIPT != "")
				str_ += SCRIPT + "\r\n";
			if (COMMAND != "")
				str_ += COMMAND + "\r\n";
			ps_call(str_);
		
			
		}
		public void ps_call(string stdin)
		{
			if (instance.InvocationStateInfo.State == PSInvocationState.Running)
				return;
			
			instance.Commands.Clear();
			string endconsole = "\r\nwrite-host \"PS $pwd>\"\r\n";
			history.Add(stdin);
			
			instance.AddScript(stdin + endconsole);
			//instance.AddCommand("out-string").AddParameter("stream");
			//instance.AddCommand("out-host");
			//instance.Commands.Commands[0].MergeMyResults(PipelineResultTypes.Error, PipelineResultTypes.);
			
			buffer = buffer.Substring(0, buffer.Length-2);
			buffer_writeline(stdin);
			IAsyncResult result = instance.BeginInvoke<PSObject, PSObject>(null, psObjectHandler);
		}
		public void ps_stop()
		{
			if (instance.InvocationStateInfo.State == PSInvocationState.Running)
			{
				instance.BeginStop(null, PSInvocationState.Stopped);
				while (instance.InvocationStateInfo.State != PSInvocationState.Stopped) {
					
				}
				instance.Commands.Clear();
				instance.AddScript("\r\nwrite-host \"PS $pwd>\"\r\n");
				IAsyncResult result = instance.BeginInvoke<PSObject, PSObject>(null, psObjectHandler);
			}
			
		}
		private void Event_Information_DataAdded(object sender, DataAddedEventArgs e)
		{
			
			InformationRecord _obj = (sender as PSDataCollection<InformationRecord>)[e.Index];
			switch (_obj.MessageData.GetType().ToString())
			{
				case "System.Management.Automation.HostInformationMessage":
					{
						System.Management.Automation.HostInformationMessage o = (_obj.MessageData as System.Management.Automation.HostInformationMessage);
						buffer_write(o.Message.ToString());
						if (o.NoNewLine == false)
							buffer_writeline("");
					}
					break;
				default:
					buffer_writeline(_obj.ToString());
					break;
					
			}
		}
		private void Event_InvocationStateChanged(object sender, PSInvocationStateChangedEventArgs e)
		{
			//if (e.InvocationStateInfo.State == PSInvocationState.Completed)
			//	buffer += string.Format("PS >\r\n");
			//stdio.stdio += string.Format("Invocation state changed to {0}\r\n", e.InvocationStateInfo.State.ToString());
		}
		private void Event_Debug_DataAdded(object sender, DataAddedEventArgs e)
		{
			buffer_writeline("Debug: ");
			buffer_writeline((sender as PSDataCollection<DebugRecord>)[e.Index].ToString());
		}
		private void Event_Object_DataAdded(object sender, DataAddedEventArgs e)
		{
			PSObject _obj = (sender as PSDataCollection<PSObject>)[e.Index];
			string str = _obj.BaseObject as string;
			//str = _obj.BaseObject.ToString();
			
			buffer_write( str );
			//string text = Microsoft.PowerShell.ToStringCodeMethods.PropertyValueCollection(new PSObject(_obj));
			//buffer_writeline(text);
			
			//PSObjectTypeDescriptor asdf = new PSObjectTypeDescriptor(_obj);
			//asdf.GetConverter();
			//psObjectHandler
			//buffer_writeline(asdf.ToString());
			//PSSerializer.Serialize(_obj);
			
			//PSObjectHelper v = new PSObjectHelper();
			// Begin Hook
			//Type objType = typeof(Microsoft.PowerShell.Commands.Internal.Format.OuterFormatShapeCommandBase).Assembly.GetType("Microsoft.PowerShell.Commands.Internal.Format.PSObjectHelper");
			
			
			
			//MethodInfo[] objType.GetMethods();
			//MethodInfo objMethod = objType.GetMethod("SmartToString");
			
			//if (objMethod != null)
			//{
				//objMethod.Invoke(objType, null
			//	ParameterInfo[] objParam = objMethod.GetParameters();
				
			//	MessageBox.Show(objParam.ToString());
				
			//} else {
			//	MessageBox.Show("Failed to grab ObjMethod");	
			//}
			
			
			
			
			//var propTypeVal = Convert.ChangeType(to_obj Type.GetType(to_obj
			                                  
			//object instance_ = Activator.CreateInstance(typeobject);
			
			
			//buffer_writeline(String.Format("{0}", _obj.TypeNames));
			/*
			foreach (string i in (_obj.TypeNames as System.Collections.ObjectModel.Collection<string>))
			{
				
				buffer_write(String.Format(CurrentUICulture, "{0}, ", i.GetType().ToString()));
			}
			*/
			
			//buffer_writeline(string.Format("{0} {1} {2}", _obj.Members[""].Value, _obj.Members[7].Value, _obj.Members[8].Value));
			
			
			//foreach (PSMemberInfo i in _obj.Members)
			//{
			//	buffer_writeline(string.Format("{0} {1}", i.Name, i.Value));
			//}
			
			//buffer_writeline(String.Format(CurrentUICulture, "{0}", _obj));
			//buffer_writeline("Object Data Added");
			
			
			//Microsoft.PowerShell.Commands.
			
			//System.Management.Automation.Host.PSHost.CurrentCulture;
			
			//_obj.Properties
			//buffer_writeline(Microsoft.PowerShell.ToStringCodeMethods.Type(_obj));
			
			//List<String> v = ((_obj.Properties["CodeProperty"] as PSPropertyInfo).Value as List<String>);

			//buffer_write(_obj.BaseObject.GetType().ToString());
			//buffer_writeline("");
			return;
			foreach (PSPropertyInfo prop in _obj.Properties)
			{
				
				
				switch(prop.MemberType.ToString())
				{
					case "CodeProperty":
						
						//System.Collections.Generic.IEnumerable<System.String> v = prop.Value as System.Collections.Generic.IEnumerable<System.String>;
						//List<String> v = (List<String>)prop.Value;
						
						
						/*
						System.Collections.Generic.List<System.String> v = prop.Value as System.Collections.Generic.List<System.String>;
						foreach (System.String i in v)
						{
							if (i == null)
								continue;
							buffer_write(i);
							buffer_write(",");
							
						}
						*/
						
						//buffer_write(string.Format(CurrentUICulture, "{0} : {1}\r\n",  prop.Value, prop.Value.GetType().ToString()));
						buffer_write(prop.TypeNameOfValue + " \r\n");
						buffer_write(prop.Value.GetType().ToString() + " \r\n");
						buffer_write(prop.Value.ToString() + " \r\n");
						
						/*
						foreach (var i in (prop.Value as System.Collections.Generic.IEnumerable<System.String> ))
						{
							
							buffer_write("herro");
						}
						*/
						//buffer_write(string.Format(CurrentUICulture, "{0}",  prop.Value));
						
						//buffer_write(prop.Value));
						//prop.Value
						break;

					default:
						break;
				}
			}

			buffer_writeline("");
			
			//string v = Microsoft.PowerShell.ToStringCodeMethods.PropertyValueCollection(_obj);
			//buffer_write("Additional Data: ");
			//buffer_writeline(v.ToString());
			//buffer += v;
			//buffer += _obj.ToString();
			//buffer += "\r\n";
		}
		private	void Error_Verbose_DataAdded(object sender, DataAddedEventArgs e)
		{
			buffer_writeline("Verbose:");
			buffer_writeline((sender as PSDataCollection<VerboseRecord>)[e.Index].ToString());
		}
		private void Event_Error_DataAdded(object sender, DataAddedEventArgs e)
		{
			ErrorRecord error = (sender as PSDataCollection<ErrorRecord>)[e.Index];
			//error.GetObjectData();
			
			buffer += string.Format("{0}: {1} \r\n" , error.InvocationInfo.MyCommand.ToString(), error.ToString());
			buffer += string.Format("At line:{0} char:{1}\r\n", error.InvocationInfo.ScriptLineNumber.ToString(), error.InvocationInfo.OffsetInLine.ToString());
			buffer += string.Format("+ {0}\r\n", error.InvocationInfo.Line.ToString() );
			buffer += string.Format("+{0}{1}\r\n", (new String(' ', error.InvocationInfo.OffsetInLine)), (new string('~', error.InvocationInfo.Line.Length-error.InvocationInfo.OffsetInLine)));
			buffer += string.Format("  + CategoryInfo : {0}\r\n", error.CategoryInfo.ToString());
			buffer += string.Format("  + FullyQualifiedErrorId : {0}\r\n\r\n", error.FullyQualifiedErrorId.ToString());
		}
	}
}

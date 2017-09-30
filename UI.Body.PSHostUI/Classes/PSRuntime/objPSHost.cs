/*
 * Created by SharpDevelop.

 * Date: 9/13/2017
 * Time: 5:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Globalization;
using System.Management.Automation.Host;
using System.Management.Automation.Runspaces;

namespace UI.Body.PSHostUI.Classes
{
	/// <summary>
	/// Description of objPSHost.
	/// </summary>
	/// 
	public class objPSHost : PSHost, IHostSupportsInteractiveSession
	{
		// Call is new objPSHost(this)
		public objPSHost(objPSListener program)
		{
			this.program = program;
			this.HostUserInterface.onBufferChanged += (sender, e) => {
				if (onBufferChanged != null)
					onBufferChanged(this, EventArgs.Empty);
			};
		}
		
		public Runspace pushedRunspace = null;
		private objPSListener program;
		private CultureInfo origionalCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
		private CultureInfo originalUICultureInfo = System.Threading.Thread.CurrentThread.CurrentUICulture;
		private static Guid instanceID = Guid.NewGuid();
		private objPSHostUserInterface HostUserInterface = new objPSHostUserInterface();
		#region define Buffer
		public string buffer {
			get {
				return this.HostUserInterface.buffer;
			}
			set {
				this.HostUserInterface.buffer = value;
			}
		}
		public event EventHandler onBufferChanged;
		
		#endregion define Buffer
		/*
		public string buffer {
			get { return this.HostUserInterface.buffer; }
			set { this.HostUserInterface.buffer = value; }
		}
		*/
		public override CultureInfo CurrentCulture {
			get { return this.origionalCultureInfo; }
		}
        public override CultureInfo CurrentUICulture
        {
            get { return this.originalUICultureInfo; }
        }
		public override Guid InstanceId
		{
			get { return instanceID; }
        }
		public override string Name
        {
			get { return instanceID.ToString(); }
        }
    	public override PSHostUserInterface UI
        {
            get { return this.HostUserInterface; }
        }
        public override Version Version
        {
            get { return new Version(1, 0, 0, 0); }
        }
        #region IHostSupportsInteractiveSession Properties
		public bool IsRunspacePushed
		{
			get { return this.pushedRunspace != null; }
		}
		public Runspace Runspace {
			get { return this.program.runspace; }
			internal set { this.program.runspace = value; }
		}
        
        #endregion IHostSupportsInteractiveSession Properties
        public override void EnterNestedPrompt()
        {
            throw new NotImplementedException("Cannot suspend the shell, EnterNestedPrompt() method is not implemented by MyHost.");
        }
        public override void ExitNestedPrompt()
        {
            throw new NotImplementedException("The ExitNestedPrompt() method is not implemented by MyHost.");
        }
		public override void NotifyBeginApplication()
        {
            return;  // Do nothing.
        }
        public override void NotifyEndApplication()
        {
           return; // Do nothing.
        }
        
		public override void SetShouldExit(int exitCode)
        {
            this.program.shouldExit = true;
            this.program.ExitCode = exitCode;
        }
		
		#region IHostSupportsInteractiveSession Methods
        public void PopRunspace()
        {
            Runspace = this.pushedRunspace;
            this.pushedRunspace = null;
        }
        
        public void PushRunspace(Runspace runspace)
        {
            this.pushedRunspace = Runspace;
            Runspace = runspace;
        }
		#endregion IHostSupportsInteractiveSession Methods
		
	}
}

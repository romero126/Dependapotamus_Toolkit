/*
 * Created by SharpDevelop.

 * Date: 9/13/2017
 * Time: 5:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Management.Automation;
using System.Management.Automation.Host;
using System.Text;
namespace UI.Body.PSHostUI.Classes
{
	/// <summary>
	/// Description of objPSHostUserInterface.
	/// </summary>
	public class objPSHostUserInterface : PSHostUserInterface, IHostUISupportsMultipleChoiceSelection
	{
		private string stdio { get; set; }
		public string buffer {
			get { return stdio; }
			set {
				stdio = value;
				if (onBufferChanged != null) {
					onBufferChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler onBufferChanged;
		
		private objPSRawUserInterface objRawUI = new objPSRawUserInterface();
		public override PSHostRawUserInterface RawUI
		{
			get { return this.objRawUI; }
		}
		public override Dictionary<string, PSObject> Prompt(string caption, string message, Collection<FieldDescription> descriptions)
		{
			throw new NotImplementedException("The method Prompt() is not implemented.");
		}
		public override int PromptForChoice(string caption, string message, Collection<ChoiceDescription> choices, int defaultChoice)
		{
			 throw new NotImplementedException("The method PromptForChoice() is not implemented.");
		}
		public Collection<int> PromptForChoice(string caption, string message, Collection<ChoiceDescription> choices, IEnumerable<int> defaultchoices)
		{
			throw new NotImplementedException("The method PromptForChoice() is not implemented.");
		}
		

		public override PSCredential PromptForCredential(string caption, string message, string userName, string targetName)
		{
			 throw new NotImplementedException("The method PromptForCredential() is not implemented.");
		}
		public override PSCredential PromptForCredential(string caption, string message, string userName, string targetName, PSCredentialTypes allowedCredentialTypes, PSCredentialUIOptions options)
		{
			 throw new NotImplementedException("The method PromptForCredential() is not implemented.");
		}
		public override string ReadLine()
		{
			 throw new NotImplementedException("The method ReadLine() is not implemented.");
		}
		public override System.Security.SecureString ReadLineAsSecureString()
		{
			 throw new NotImplementedException("The method ReadLineAsSecureString() is not implemented.");
		}
		public override void Write(string value)
		{
			buffer += value;
		}
		public override void Write(ConsoleColor foregroundColor, ConsoleColor backgroundColor, string value)
		{
			buffer += value;
		}
		public override void WriteLine(ConsoleColor foregroundColor, ConsoleColor backgroundColor, string value)
		{
			buffer += value;
			buffer += "\r\n";
		}
		public override void WriteLine()
		{
			buffer += "\r\n";
		}
		public override void WriteLine(string value)
		{
			buffer += value;
			buffer += "\r\n";
		}
		public override void WriteDebugLine(string message)
		{
			this.WriteLine(ConsoleColor.DarkYellow, ConsoleColor.Black, string.Format(CultureInfo.CurrentCulture, "DEBUG: {0}", message));
		}
		public override void WriteErrorLine(string value)
		{
			this.WriteLine(ConsoleColor.Red, ConsoleColor.Black, value);
		}
		public override void WriteVerboseLine(string message)
		{
			this.WriteLine(ConsoleColor.Green, ConsoleColor.Black, String.Format(CultureInfo.CurrentCulture, "VERBOSE: {0}", message));
		}
		public override void WriteWarningLine(string message)
		{
			this.WriteLine(ConsoleColor.Yellow, ConsoleColor.Black, String.Format(CultureInfo.CurrentCulture, "WARNING: {0}", message));
		}
		public override void WriteProgress(long sourceId, ProgressRecord record)
		{
			// Do Nothing
		}
		
		/*
		private static string[] GetHotkeyAndLabel(string input)
        {
            string[] result = new string[] { String.Empty, String.Empty };
            string[] fragments = input.Split('&');
            if (fragments.Length == 2)
            {
                if (fragments[1].Length > 0)
                {
                    result[0] = fragments[1][0].ToString().
                    ToUpper(CultureInfo.CurrentCulture);
                }

                result[1] = (fragments[0] + fragments[1]).Trim();
            }
            else
            {
                result[1] = input;
            }

            return result;
        }

        private static string[,] BuildHotkeysAndPlainLabels(
            Collection<ChoiceDescription> choices)
        {
            // we will allocate the result array
            string[,] hotkeysAndPlainLabels = new string[2, choices.Count];

            for (int i = 0; i < choices.Count; ++i)
            {
                string[] hotkeyAndLabel = GetHotkeyAndLabel(choices[i].Label);
                hotkeysAndPlainLabels[0, i] = hotkeyAndLabel[0];
                hotkeysAndPlainLabels[1, i] = hotkeyAndLabel[1];
            }

            return hotkeysAndPlainLabels;
        }
		*/

	}
}

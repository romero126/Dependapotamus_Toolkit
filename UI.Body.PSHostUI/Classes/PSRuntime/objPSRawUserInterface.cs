/*
 * Created by SharpDevelop.

 * Date: 9/13/2017
 * Time: 5:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Management.Automation.Host;

namespace UI.Body.PSHostUI.Classes
{
	/// <summary>
	/// Description of PSRawUserInterface.
	/// </summary>
	public class objPSRawUserInterface : PSHostRawUserInterface
	{
		public int BufferWidth = 120;
		public int BufferHeight = 3000;
		public int LargestWindowWidth = 160;
		public int LargestWindowHeight = 50;
		public int cursorSize = 25;
		public bool KeyAvailableProperty = false;
		public int WindowLeft = 0;
		public int WindowTop = 0;
		public int WindowWidth = 120;
		public int WindowHeight = 50;
		public string Title = "PowerShell";
		public ConsoleColor ForegroundColorProperty = ConsoleColor.DarkYellow;
		public ConsoleColor BackgroundColorProperty = ConsoleColor.DarkMagenta;
		
		
		private Coordinates CursorPositionProperty;
		
		
		
		public override ConsoleColor BackgroundColor
		{
			get { return Console.BackgroundColor; }
			set { Console.BackgroundColor = value; }
		}
		public override Size BufferSize {
			get { return new Size(this.BufferWidth, this.BufferHeight); }
			set { this.BufferWidth = value.Width; this.BufferHeight = value.Height; }
		}
		public override Coordinates CursorPosition {
			get { return CursorPositionProperty; }
			set { CursorPositionProperty = value; }
		}
		public override int CursorSize {
			get { return this.cursorSize; }
			set { this.cursorSize = value; }
		}
		public override ConsoleColor ForegroundColor {
			get { return this.ForegroundColorProperty; }
			set { this.ForegroundColorProperty = value; }
		}
		public override bool KeyAvailable {
			get { return this.KeyAvailableProperty; }
		}
		public override Size MaxPhysicalWindowSize {
			get { return new Size(this.LargestWindowWidth, this.LargestWindowHeight); }
		}
		public override Size MaxWindowSize {
			get { return new Size(this.LargestWindowWidth, this.LargestWindowHeight); }
		}
		public override Coordinates WindowPosition {
				get { return new Coordinates(this.WindowLeft, this.WindowTop); }
				set { this.WindowLeft = value.X; this.WindowTop = value.Y; }
		}
		public override Size WindowSize {
			get { return new Size(this.WindowWidth, this.WindowHeight); }
			set { this.WindowWidth = value.Width; this.WindowHeight = value.Height; }
		}
		public override string WindowTitle {
			get { return this.Title; }
			set { this.Title = value; }
		}
		public override void FlushInputBuffer() {
			// Do Nothing
		}
		public override BufferCell[,] GetBufferContents(Rectangle rectangle) {
			//throw new NotImplementedException("The GetBufferContents method is not implemented");
			return null;
		}
		public override KeyInfo ReadKey(ReadKeyOptions options) {
			throw new NotImplementedException("The ReadKey() method is not implemented");
			//return null;
		}
		public override void ScrollBufferContents(Rectangle source, Coordinates destination, Rectangle clip, BufferCell fill) {
			//throw new NotImplementedException("The ScrollBufferContents() method is not implemented");
			
		}
		public override void SetBufferContents(Coordinates origin, BufferCell[,] contents) {
			//throw new NotImplementedException("The SetBufferContents() method is not implemented");
		}
		public override void SetBufferContents(Rectangle rectangle, BufferCell fill) {
			//throw new NotImplementedException("The SetBufferContents() method is not implemented");
		}
	}
}

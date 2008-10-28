// EventCreationCompletionData.cs
//
// Author:
//   Mike Krüger <mkrueger@novell.com>
//
// Copyright (c) 2008 Novell, Inc (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//

using System;
using System.Text;
using System.Linq;
using MonoDevelop.Projects.Gui.Completion;
using MonoDevelop.Projects.Dom;
using MonoDevelop.Projects.Dom.Output;

using MonoDevelop.Ide.Gui;
using MonoDevelop.Ide.Gui.Content;
using CSharpBinding.FormattingStrategy;

namespace MonoDevelop.CSharpBinding
{
	public class EventCreationCompletionData : CompletionData, IActionCompletionData
	{
		string parameterList;
		IMember callingMember;
		TextEditor editor;
		int initialOffset;
		
		public EventCreationCompletionData (TextEditor editor, IType delegateType, IEvent evt, string parameterList, IMember callingMember, IType declaringType) : base (null)
		{
			if (delegateType is InstantiatedType) {
				this.DisplayText   = "Handle" + evt.Name;
			} else {
				this.DisplayText   = "Handle" + evt.Name;
			}
			if (declaringType.SearchMember (this.DisplayText, true).Count > 0) {
				for (int i = 1; i < 10000; i++) {
					if (declaringType.SearchMember (this.DisplayText + i.ToString (), true).Count == 0) {
						this.DisplayText = this.DisplayText + i.ToString ();
						break;
					}
				}
			}
			this.editor        = editor;
			this.parameterList = parameterList;
			this.callingMember = callingMember;
			this.Icon          = delegateType.Methods.First ().StockIcon;
			this.initialOffset = editor.CursorPosition;
		}

		public void InsertCompletionText (ICompletionWidget widget, ICodeCompletionContext context)
		{
			// insert add/remove event handler code after +=/-=
			editor.DeleteText (initialOffset, editor.CursorPosition - initialOffset);
			editor.InsertText (editor.CursorPosition, this.DisplayText + ";");
			
			// Search opening bracket of member
			int pos = editor.GetPositionFromLineColumn (callingMember.BodyRegion.Start.Line, callingMember.BodyRegion.Start.Column);
			pos = Math.Max (pos, editor.SearchChar (pos, '{'));
			
			// Search closing bracket of member
			pos = editor.SearchBracketForward (pos + 1, '{', '}') + 1;
//			int lastPos = editor.GetPositionFromLineColumn (callingMember.DeclaringType.BodyRegion.End.Line, callingMember.DeclaringType.BodyRegion.End.Column);
			pos = Math.Min (pos /*Math.Min (pos, lastPos)*/, editor.TextLength - 1);
			
			// Insert new event handler after closing bracket
			string indent = NewOverrideCompletionData.GetIndentString (editor, editor.GetPositionFromLineColumn (callingMember.Location.Line + 1, 0));
			string text = Environment.NewLine + Environment.NewLine + indent +"void " + this.DisplayText + " " + this.parameterList + Environment.NewLine + indent +"{" + Environment.NewLine + indent + TextEditorProperties.IndentString;
			editor.InsertText (pos, text + Environment.NewLine + indent + "}");
			editor.CursorPosition = pos + text.Length;
		}
		
	}
}

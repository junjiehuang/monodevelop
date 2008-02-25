//
// CatalogHeadersWidget.cs
//
// Author:
//   David Makovský <yakeen@sannyas-on.net>
//
// Copyright (C) 2007 David Makovský
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// 

using System;
using Gtk;

namespace MonoDevelop.Gettext.Editor
{
	
	partial class CatalogHeadersWidget : Bin
	{
		CatalogHeaders headers;
		bool inUpdate = false;
		public event EventHandler PluralDefinitionChanged;
		
		public CatalogHeadersWidget ()
		{
			this.Build ();
			this.textviewComments.Buffer.Changed += delegate {
				if (inUpdate)
					return;
				headers.CommentForGui = textviewComments.Buffer.Text;
				Update ();
			};
			
			headers = new CatalogHeaders (null);
			UpdateGui ();
		}

		internal CatalogHeaders CatalogHeaders
		{
			get { return headers; }
			set
			{
				if (value == null)
					headers = new CatalogHeaders (null);
				else
					headers = value;
				
				UpdateGui ();
			}
		}
		
		void UpdateGui ()
		{
			inUpdate = true;
			// project tab
			textviewComments.Buffer.Clear ();
			textviewComments.Buffer.InsertAtCursor (headers.CommentForGui);
			
			string project = String.Empty;
			string version = String.Empty;
			
			if (! String.IsNullOrEmpty (headers.Project))
			{
				int pos = headers.Project.LastIndexOf (' ');
				if (pos != -1)
				{
					project = headers.Project.Substring (0, pos).TrimEnd (' ', '\t');
					version = headers.Project.Substring (pos + 1);
				} else
				{
					project = headers.Project;
				}
			}
			
			entryProjectName.Text = project;
			entryProjectVersion.Text = version;
			
			entryBugzilla.Text = headers.GetHeader ("Report-Msgid-Bugs-To");
			labelPotCreation.Text = "<b>" + headers.CreationDate + "</b>";
			labelPoLastModification.Text = "<b>" + headers.RevisionDate + "</b>";
			labelPotCreation.UseMarkup = labelPoLastModification.UseMarkup = true;
			
			// language tab
			
			entryTranslatorName.Text = headers.Translator;
			entryTranslatorEmail.Text = headers.TranslatorEmail;
			
			entryLanguageGroupName.Text = headers.Team;
			entryLanguageGroupEmail.Text = headers.TeamEmail;
			
			if (headers.HasHeader ("Plural-Forms"))
				entryPluralsForms.Text = headers.GetHeader ("Plural-Forms");
				
			//comboboxentryCharset.TextColumn.ActiveText = headers.Charset;
			
			// other headers
			
			this.ShowAll ();
			inUpdate = false;
		}

		protected virtual void OnButtonPluralsHelpClicked (object sender, System.EventArgs e)
		{
			// TODO: show hints + examples
		}

		void OnHeaderChanged (object sender, System.EventArgs e)
		{
			if (sender == entryProjectName || sender == entryProjectVersion)
			{
				headers.Project = (entryProjectName.Text + ' ' + entryProjectVersion.Text).Trim ();
			} else if (sender == entryBugzilla)
			{
				headers.SetHeader ("Report-Msgid-Bugs-To", entryBugzilla.Text);
			} else if (sender == entryTranslatorName)
			{
				headers.Translator = entryTranslatorName.Text;
			} else if (sender == entryTranslatorEmail)
			{
				headers.TranslatorEmail = entryTranslatorEmail.Text;
			} else if (sender == entryLanguageGroupName)
			{
				headers.Team = entryLanguageGroupName.Text;
			} else if (sender == entryLanguageGroupEmail)
			{
				headers.TeamEmail = entryLanguageGroupEmail.Text;
			} else if (sender == entryPluralsForms)
			{	
				if (! String.IsNullOrEmpty (entryPluralsForms.Text))
				{
					PluralFormsCalculator calc = new PluralFormsCalculator ();
					PluralFormsScanner scanner = new PluralFormsScanner (entryPluralsForms.Text);
					PluralFormsParser parser = new PluralFormsParser (scanner);
					bool wellFormed = parser.Parse (calc);
					
					if (wellFormed)
					{
						for (int i = 0; i < headers.Owner.PluralFormsCount; i++)
						{
							int example = 0;
							for (example = 1; example < 1000; example++)
							{
								if (calc.Evaluate (example) == i)
									break;
							}

							if (example == 1000 && calc.Evaluate (0) == i)
								example = 0;
							
							if (i > 0 && (example == 0 || example == 1000))
							{
								wellFormed = false;
								break;
							}
						}
					}

					Gdk.Color background = wellFormed ? new Gdk.Color (138, 226,52) : new Gdk.Color (204, 0, 0);
					entryPluralsForms.ModifyBase (StateType.Normal, background); //from tango palete - 8ae234 green, cc0000 red
					if (wellFormed)
					{
						headers.SetHeaderNotEmpty ("Plural-Forms", entryPluralsForms.Text);
						OnPluralDefinitionChanged ();
					}
				} else
				{
					entryPluralsForms.ModifyBase (StateType.Normal);
					headers.SetHeaderNotEmpty ("Plural-Forms", entryPluralsForms.Text);
					OnPluralDefinitionChanged ();
				}
			}
			Update ();
		}
		void Update ()
		{
			headers.UpdateDict ();
			headers.Owner.MarkDirty (this.headers);
		}
		void OnPluralDefinitionChanged ()
		{
			if (PluralDefinitionChanged != null)
				this.PluralDefinitionChanged (this, EventArgs.Empty);
		}
	}
}

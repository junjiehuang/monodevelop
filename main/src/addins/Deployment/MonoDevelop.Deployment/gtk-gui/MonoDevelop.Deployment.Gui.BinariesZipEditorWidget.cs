// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.42
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace MonoDevelop.Deployment.Gui {
    
    
    internal partial class BinariesZipEditorWidget {
        
        private Gtk.VBox vbox2;
        
        private Gtk.Label label4;
        
        private Gtk.Table table1;
        
        private Gtk.ComboBox comboConfiguration;
        
        private Gtk.ComboBox comboPlatform;
        
        private MonoDevelop.Components.FolderEntry folderEntry;
        
        private Gtk.HBox hbox1;
        
        private Gtk.Entry entryZip;
        
        private Gtk.ComboBox comboZip;
        
        private Gtk.Label label1;
        
        private Gtk.Label label2;
        
        private Gtk.Label label3;
        
        private Gtk.Label label5;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget MonoDevelop.Deployment.Gui.BinariesZipEditorWidget
            Stetic.BinContainer.Attach(this);
            this.Name = "MonoDevelop.Deployment.Gui.BinariesZipEditorWidget";
            // Container child MonoDevelop.Deployment.Gui.BinariesZipEditorWidget.Gtk.Container+ContainerChild
            this.vbox2 = new Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 12;
            this.vbox2.BorderWidth = ((uint)(6));
            // Container child vbox2.Gtk.Box+BoxChild
            this.label4 = new Gtk.Label();
            this.label4.Name = "label4";
            this.label4.Xalign = 0F;
            this.label4.LabelProp = Mono.Unix.Catalog.GetString("Select the archive file name and location:");
            this.vbox2.Add(this.label4);
            Gtk.Box.BoxChild w1 = ((Gtk.Box.BoxChild)(this.vbox2[this.label4]));
            w1.Position = 0;
            w1.Expand = false;
            w1.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.table1 = new Gtk.Table(((uint)(4)), ((uint)(2)), false);
            this.table1.Name = "table1";
            this.table1.RowSpacing = ((uint)(6));
            this.table1.ColumnSpacing = ((uint)(6));
            // Container child table1.Gtk.Table+TableChild
            this.comboConfiguration = Gtk.ComboBox.NewText();
            this.comboConfiguration.Name = "comboConfiguration";
            this.table1.Add(this.comboConfiguration);
            Gtk.Table.TableChild w2 = ((Gtk.Table.TableChild)(this.table1[this.comboConfiguration]));
            w2.LeftAttach = ((uint)(1));
            w2.RightAttach = ((uint)(2));
            w2.XOptions = ((Gtk.AttachOptions)(4));
            w2.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.comboPlatform = Gtk.ComboBox.NewText();
            this.comboPlatform.Name = "comboPlatform";
            this.table1.Add(this.comboPlatform);
            Gtk.Table.TableChild w3 = ((Gtk.Table.TableChild)(this.table1[this.comboPlatform]));
            w3.TopAttach = ((uint)(1));
            w3.BottomAttach = ((uint)(2));
            w3.LeftAttach = ((uint)(1));
            w3.RightAttach = ((uint)(2));
            w3.XOptions = ((Gtk.AttachOptions)(4));
            w3.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.folderEntry = new MonoDevelop.Components.FolderEntry();
            this.folderEntry.Name = "folderEntry";
            this.table1.Add(this.folderEntry);
            Gtk.Table.TableChild w4 = ((Gtk.Table.TableChild)(this.table1[this.folderEntry]));
            w4.TopAttach = ((uint)(2));
            w4.BottomAttach = ((uint)(3));
            w4.LeftAttach = ((uint)(1));
            w4.RightAttach = ((uint)(2));
            w4.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.hbox1 = new Gtk.HBox();
            this.hbox1.Name = "hbox1";
            this.hbox1.Spacing = 6;
            // Container child hbox1.Gtk.Box+BoxChild
            this.entryZip = new Gtk.Entry();
            this.entryZip.CanFocus = true;
            this.entryZip.Name = "entryZip";
            this.entryZip.IsEditable = true;
            this.entryZip.InvisibleChar = '●';
            this.hbox1.Add(this.entryZip);
            Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.hbox1[this.entryZip]));
            w5.Position = 0;
            // Container child hbox1.Gtk.Box+BoxChild
            this.comboZip = Gtk.ComboBox.NewText();
            this.comboZip.Name = "comboZip";
            this.comboZip.Active = 0;
            this.hbox1.Add(this.comboZip);
            Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(this.hbox1[this.comboZip]));
            w6.Position = 1;
            w6.Expand = false;
            w6.Fill = false;
            this.table1.Add(this.hbox1);
            Gtk.Table.TableChild w7 = ((Gtk.Table.TableChild)(this.table1[this.hbox1]));
            w7.TopAttach = ((uint)(3));
            w7.BottomAttach = ((uint)(4));
            w7.LeftAttach = ((uint)(1));
            w7.RightAttach = ((uint)(2));
            w7.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.label1 = new Gtk.Label();
            this.label1.Name = "label1";
            this.label1.Xalign = 0F;
            this.label1.LabelProp = Mono.Unix.Catalog.GetString("Configuration:");
            this.table1.Add(this.label1);
            Gtk.Table.TableChild w8 = ((Gtk.Table.TableChild)(this.table1[this.label1]));
            w8.XOptions = ((Gtk.AttachOptions)(4));
            w8.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.label2 = new Gtk.Label();
            this.label2.Name = "label2";
            this.label2.Xalign = 0F;
            this.label2.LabelProp = Mono.Unix.Catalog.GetString("Target folder:");
            this.table1.Add(this.label2);
            Gtk.Table.TableChild w9 = ((Gtk.Table.TableChild)(this.table1[this.label2]));
            w9.TopAttach = ((uint)(2));
            w9.BottomAttach = ((uint)(3));
            w9.XOptions = ((Gtk.AttachOptions)(4));
            w9.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.label3 = new Gtk.Label();
            this.label3.Name = "label3";
            this.label3.Xalign = 0F;
            this.label3.LabelProp = Mono.Unix.Catalog.GetString("File:");
            this.table1.Add(this.label3);
            Gtk.Table.TableChild w10 = ((Gtk.Table.TableChild)(this.table1[this.label3]));
            w10.TopAttach = ((uint)(3));
            w10.BottomAttach = ((uint)(4));
            w10.XOptions = ((Gtk.AttachOptions)(4));
            w10.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.label5 = new Gtk.Label();
            this.label5.Name = "label5";
            this.label5.Xalign = 0F;
            this.label5.LabelProp = Mono.Unix.Catalog.GetString("Target platform:");
            this.table1.Add(this.label5);
            Gtk.Table.TableChild w11 = ((Gtk.Table.TableChild)(this.table1[this.label5]));
            w11.TopAttach = ((uint)(1));
            w11.BottomAttach = ((uint)(2));
            w11.XOptions = ((Gtk.AttachOptions)(4));
            w11.YOptions = ((Gtk.AttachOptions)(4));
            this.vbox2.Add(this.table1);
            Gtk.Box.BoxChild w12 = ((Gtk.Box.BoxChild)(this.vbox2[this.table1]));
            w12.Position = 1;
            w12.Expand = false;
            w12.Fill = false;
            this.Add(this.vbox2);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Show();
            this.entryZip.Changed += new System.EventHandler(this.OnEntryZipChanged);
            this.comboZip.Changed += new System.EventHandler(this.OnComboZipChanged);
            this.folderEntry.PathChanged += new System.EventHandler(this.OnFolderEntryPathChanged);
            this.comboPlatform.Changed += new System.EventHandler(this.OnComboPlatformChanged);
            this.comboConfiguration.Changed += new System.EventHandler(this.OnComboConfigurationChanged);
        }
    }
}

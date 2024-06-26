﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eSchool.Importss;

namespace eSchool
{
    public partial class ListControl : UserControl
    {
        public ListControl()
        {
            InitializeComponent();
        }
        
     
        public void Add(Control c)
        {

            flpListBox.Controls.Add(c);
            SetupAnchors();
        }

        public void Add(string title, string session, string totalFeeTerm)
        {
            StructureListItem c = new StructureListItem();
            c.Name = title;
            c.Title = title;
            c.Session = session;
            c.TotalFeeTerm = totalFeeTerm;
            flpListBox.Controls.Add(c);
            SetupAnchors();
        }

        public void Add(string overHeadName)
        {
            OverHeadListItem c = new OverHeadListItem();
            //for reference on delete
            c.Name = overHeadName;
            c.OverHeadName = overHeadName;
            flpListBox.Controls.Add(c);
            SetupAnchors();
        }

        public void Add(string title,string sizeofFile,string timestamp, bool status,string fileLocation)
        {
            ImportListItem c = new ImportListItem();
            //for reference on delete
            c.Name = title;
            //add properties.
            c.Title = title;
            c.SizeOfFile = sizeofFile;
            c.Timestamp = timestamp;
            c.Status = status;
            c.FileLocation = fileLocation;
            flpListBox.Controls.Add(c);
            SetupAnchors();
        }
        //TODO overload the remove for various uses

        public void Remove(int index)
        {
            Control c = flpListBox.Controls[index];
            Remove(c.Name);
        }
        public void Remove(string name)
        {
            Control c = flpListBox.Controls[name];
            flpListBox.Controls.Remove(c);
            c.Dispose();
            SetupAnchors();
        }
        public void Remove(string title,bool status)
        {
            Control c = flpListBox.Controls[title];
            flpListBox.Controls.Remove(c);
            c.Dispose();
            SetupAnchors();
        }

        public void Remove(string title, string session)
        {
            Control c = flpListBox.Controls[title];
            flpListBox.Controls.Remove(c);
            c.Dispose();
            SetupAnchors();
        }

        public void Clear()
        {
            do
            {
                if (flpListBox.Controls.Count == 0)
                {
                    break; // TODO: might not be correct. Was : Exit Do
                }
                Control c = flpListBox.Controls[0];
                flpListBox.Controls.Remove(c);
                c.Dispose();
            }
            while (true);
        }

        public int Count
        {
            get { return flpListBox.Controls.Count; }
        }
        private void SetupAnchors()
        {
            if (flpListBox.Controls.Count > 0)
            {
                for (int i = 0; i <= flpListBox.Controls.Count - 1; i++)
                {
                    Control c = flpListBox.Controls[i];
                    if (i == 0)
                    {
                        // Its the first control, all subsequent controls follow
                        // the anchor behavior of this control.
                        c.Anchor = (AnchorStyles.Left | AnchorStyles.Top);
                        c.Width = flpListBox.Width - SystemInformation.VerticalScrollBarWidth;
                    }
                    else
                    {
                        // It is not the first control. Set its anchor to
                        // copy the width of the first control in the list.
                        c.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
                    }
                }
            }
        }

        private void ListControl_Layout(object sender, LayoutEventArgs e)
        {
            if (flpListBox.Controls.Count >= 0)
            {
                flpListBox.Controls[0].Width = flpListBox.Size.Width - SystemInformation.VerticalScrollBarWidth;
            }
        }
    }
}

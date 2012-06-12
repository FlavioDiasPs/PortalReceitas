using System;
using System.Collections.Generic;
using System.Text;

namespace PortalControls
{
    public class clsTabPage:System.Windows.Forms.TabPage
    {
        //destructor
        ~clsTabPage()
        {
            System.GC.Collect();
        }

        public delegate void delAddControl(System.Windows.Forms.Control control);
        public void addControl(System.Windows.Forms.Control control)
        {
            if (this.InvokeRequired)
                this.BeginInvoke(new delAddControl(addControl), control);
            else
            {               
                this.Controls.Add(control);
            }
        }
    }
}

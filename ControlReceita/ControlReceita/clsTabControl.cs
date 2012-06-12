using System;
using System.Collections.Generic;
using System.Text;

namespace PortalControls
{
    public class clsTabControl:System.Windows.Forms.TabControl
    {
        public clsTabControl()
        {            
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SendToBack();
        }

        //destructor
        ~clsTabControl()
        {
            System.GC.Collect();
        }

        //public delegate void delAddTabPages(List<System.Windows.Forms.TabPage> listPage);
        //public void addTabPages(List<System.Windows.Forms.TabPage> listPage)
        //{
        //    if (this.InvokeRequired)
        //        this.BeginInvoke(new delAddTabPages(addTabPages), listPage);
        //    else
        //    {
        //        this.Controls.AddRange(listPage.ToArray());
        //        this.Refresh();
        //    }
        //}

        private delegate void delAddTabPage(PortalControls.clsTabPage page);
        public void addTabPage(PortalControls.clsTabPage page)
        {
            if (this.InvokeRequired)
                this.BeginInvoke(new delAddTabPage(addTabPage), page);
            else
            {
                this.TabPages.Add(page);                   
            }
        }

        private delegate void delClear();
        public void disposeAllTabPages()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new delClear(disposeAllTabPages));
            }
            else
            {
                int aux = this.TabPages.Count;
                if (aux == 0) return;

                //remove da memória todas as paginas                
                for (int i = 0; i < aux; i++)
                { this.TabPages[0].Dispose(); }
            }
        }
    }
}

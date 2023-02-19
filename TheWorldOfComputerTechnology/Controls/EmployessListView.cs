using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheWorldOfComputerTechnology.Controls
{
    public partial class EmployessListView : UserControl
    {
        public EmployessListView()
        {
            InitializeComponent();
            //panel4.HorizontalScroll.Maximum = 0;
            //panel4.AutoScroll = false;
            //panel4.VerticalScroll.Maximum = 0;
            //panel4.AutoScroll = true;
            Show();
        }

        async void Show()
        {
            panel4.Visible = false;
            for (int i = 0; i < 20; i++)
            {
                EmployessListViewElement employessListViewElement = new EmployessListViewElement();
                employessListViewElement.Dock = DockStyle.Top;
                panel4.Controls.Add(employessListViewElement);
            }
            panel4.AutoScroll = true;
            panel4.VerticalScroll.Maximum = panel4.Width;
            await Task.Delay(10);
            panel4.Visible = true;
        }
    }
}

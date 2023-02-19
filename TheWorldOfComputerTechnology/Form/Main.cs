using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheWorldOfComputerTechnology.Data;
using TheWorldOfComputerTechnology.Controls;

namespace TheWorldOfComputerTechnology
{
    public partial class Main : PatternForm
    {
        public Main()
        {
            InitializeComponent();
            
        }

        private void Main_Paint(object sender, PaintEventArgs e)
        {
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;
            panel11.Visible = false;
            panel12.Visible = false;
            if (UserData.user.IDRole == 4)
            {
                panel7.Visible = true;
                panel8.Visible = true;
                panel9.Visible = true;
                panel10.Visible = true;
                panel12.Visible = true;
            }
            if (UserData.user.IDRole == 1)
            {
                panel8.Visible = true;

            }
            if (UserData.user.IDRole ==3)
            {
                panel9.Visible = true;
                panel10.Visible = true;
                panel12.Visible = true;

            }
            if (UserData.user.IDRole == 2)
            {
                panel7.Visible = true;

            }
        }

        private void Main_Load(object sender, EventArgs e)
        {

            label1.Text = UserData.user.Surname + " " + UserData.user.Name[0] + "." + UserData.user.Patronymic[0]+".";


            panel5.AutoScroll = false;
            panel5.VerticalScroll.Maximum = panel5.Width;
            panel5.AutoScroll = true;
            button1.FlatAppearance.BorderSize = 0;
            button1.BackColor = MyColors.ColorYellow;
            button2.FlatAppearance.BorderSize = 0;
            button2.BackColor = MyColors.ColorYellow;
            button3.FlatAppearance.BorderSize = 0;
            button3.BackColor = MyColors.ColorYellow;
            button4.FlatAppearance.BorderSize = 0;
            button4.BackColor = MyColors.ColorYellow;
            button5.FlatAppearance.BorderSize = 0;
            button5.BackColor = MyColors.ColorYellow;
            button6.FlatAppearance.BorderSize = 0;
            button6.BackColor = MyColors.ColorYellow;


            button7.FlatAppearance.BorderSize = 0;
            button7.BackColor = MyColors.ColorYellow;
            button1.PerformClick();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ControlContener.Controls.Clear();
            EmployeesList employeesList = new EmployeesList();
            employeesList.Name = "EmployeesList";

            employeesList.Dock = DockStyle.Fill;
            ControlContener.Controls.Add(employeesList);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Program.MyApplicationContext.Open(new Authorization());
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ControlContener.Controls.Clear();
            ClientList ClientList = new ClientList();
            ClientList.Name = "ClientList";

            ClientList.Dock = DockStyle.Fill;
            ControlContener.Controls.Add(ClientList);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ControlContener.Controls.Clear();
            OrderList OrderList = new OrderList();
            OrderList.Name = "OrderList";

            OrderList.Dock = DockStyle.Fill;
            ControlContener.Controls.Add(OrderList);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ControlContener.Controls.Clear();
            TechnicList TechnicList = new TechnicList();
            TechnicList.Name = "TechnicList";

            TechnicList.Dock = DockStyle.Fill;
            ControlContener.Controls.Add(TechnicList);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ControlContener.Controls.Clear();
            RepairTechnicsList RepairTechnicsList = new RepairTechnicsList();
            RepairTechnicsList.Name = "RepairTechnicsList";

            RepairTechnicsList.Dock = DockStyle.Fill;
            ControlContener.Controls.Add(RepairTechnicsList);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //ControlContener.Controls.Clear();
            //RepairWorkList RepairWorkList = new RepairWorkList();
            //RepairWorkList.Name = "RepairWorkList";

            //RepairWorkList.Dock = DockStyle.Fill;
            //ControlContener.Controls.Add(RepairWorkList);
        }
    }
    
    
}

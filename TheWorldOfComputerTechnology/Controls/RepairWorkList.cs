using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using TheWorldOfComputerTechnology.Data;

namespace TheWorldOfComputerTechnology.Controls
{
    public partial class RepairWorkList : UserControl
    {
        RepairTechnicsList repairTechnicsList;
        RepairTechnicArrayItems RepairTechnicArrayItems;
        public RepairWorkList(RepairTechnicsList repairTechnicsList, RepairTechnicArrayItems items)
        {
            InitializeComponent();
            this.repairTechnicsList = repairTechnicsList;
            this.RepairTechnicArrayItems = items;
            ShowRepairTechnic(null);
            repairTechnicsList.panel2.Enabled = false;
        }
        public DataSet dataSet = new DataSet();
        public async void ShowRepairTechnic(string OrderBy)
        {


            await Task.Run(() => {
                dataSet = SQL.Table($@"
                Select 
                RepairWork.ID, Orders.ID as 'IDOrder',Orders.Name as 'Order', 
                RepairWork.RepairTechnic, RepairWork.Date,
                RepairWork.Employees as 'IDEmployees', 
                (Employees.Surname +' '+ Convert(nvarchar(1),Employees.Name,120) +'.'+  Convert(nvarchar(1),Employees.Patronymic,120)+'.') as Employees,
                RepairWork.Description
                from RepairWork
                Inner Join RepairTechnic RepairTechnic on RepairTechnic.ID = RepairWork.RepairTechnic
                Inner Join Orders Orders on Orders.ID = RepairTechnic.Orders
                Inner Join Employees Employees on RepairWork.Employees = Employees.ID 
                where RepairWork.RepairTechnic = {RepairTechnicArrayItems.ID}
                {OrderBy}");
            });


            if (dataSet.Tables.Count <= 0)
            {

                return;
            }
            dataSet.Tables[0].TableName = "RepairWork";
            string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
            RepairWorks RepairWorks = new RepairWorks();
            RepairWorks = JsonConvert.DeserializeObject<RepairWorks>(json);

            dataGridView1.DataSource = RepairWorks.RepairWork;
            //dataGridView1.DataSource = dataSet.Tables[0];
            int countcolor = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                if (countcolor == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
                    countcolor = 1;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    countcolor = 0;
                }
                if (row.Index == 0)
                {
                    LastRow = row;
                    ERowIndex = row.Index;
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                }
            }

            await Task.Delay(100);

            dataGridView1.Visible = true;

        }
        int ERowIndex = -1;
        DataGridViewRow LastRow = new DataGridViewRow();
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            int countcolor = 0;

            if (ERowIndex >= 0)
            {
                if (ERowIndex % 2 == 0)
                {
                    LastRow.DefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
                }
                else
                {
                    LastRow.DefaultCellStyle.BackColor = Color.White;
                }

            }

            if (e.RowIndex >= 0)
            {
                LastRow = (DataGridViewRow)senderGrid.Rows[e.RowIndex];
                ERowIndex = e.RowIndex;
                try
                {
                    DataGridViewRow row = (DataGridViewRow)senderGrid.Rows[e.RowIndex];


                    row.DefaultCellStyle.BackColor = Color.LightGray;

                }
                catch (Exception)
                {


                }
            }
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{

            //    if (countcolor == 0)
            //    {
            //        row.DefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
            //        countcolor = 1;
            //    }
            //    else
            //    {
            //        row.DefaultCellStyle.BackColor = Color.White;
            //        countcolor = 0;
            //    }

            //}
            if (e.RowIndex < 0)
            {

                try
                {
                    if (dataGridView1.Columns[e.ColumnIndex].Tag == null)
                    {
                        dataGridView1.Columns[e.ColumnIndex].Tag = 0;
                    }
                    if ((int)dataGridView1.Columns[e.ColumnIndex].Tag == 1)
                    {
                        dataGridView1.Columns[e.ColumnIndex].Tag = 0;
                        //
                        ShowRepairTechnic($" Order BY {dataGridView1.Columns[e.ColumnIndex].Name} ");
                    }
                    else
                    {
                        dataGridView1.Columns[e.ColumnIndex].Tag = 1;
                        //
                        ShowRepairTechnic($" Order BY {dataGridView1.Columns[e.ColumnIndex].Name} DESC ");
                    }
                    //MessageBox.Show("" + dataGridView1.Columns[e.ColumnIndex].Name);


                }
                catch (Exception)
                {


                }
            }
        }



        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;


            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = (DataGridViewRow)senderGrid.Rows[e.RowIndex];
                RepairWorkArrayItems items = (RepairWorkArrayItems)row.DataBoundItem;
                try
                {
                    //MessageBox.Show("//" + items.ID);
                    //dataGridView1.Visible = false;
                    //NewOrder NewOrder = new NewOrder(this, items);
                    //NewOrder.Name = "NewEmployees";

                    //NewOrder.Dock = DockStyle.Fill;
                    //panel5.Controls.Add(NewOrder);
                    this.Hide();
                    NewRepairWork NewRepairWork = new NewRepairWork(repairTechnicsList, items, this);
                    NewRepairWork.Name = "NewRepairWork";

                    NewRepairWork.Dock = DockStyle.Fill;
                    repairTechnicsList.panel5.Controls.Add(NewRepairWork);

                }
                catch (Exception)
                {


                }
            }
        }


        public DataGridView dostyp_dataGridView1
        {
            get { return dataGridView1; }
            set { dataGridView1 = value; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //dataGridView1.Visible = false;
            //panel2.Enabled = false;
            //NewOrder NewOrder = new NewOrder(this);
            //NewOrder.Name = "NewOrder";

            //NewOrder.Dock = DockStyle.Fill;
            //panel5.Controls.Add(NewOrder);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var senderGrid = dataGridView1;
            //DataGridViewRow row = (DataGridViewRow)senderGrid.Rows[ERowIndex];
           // RepairWorkArrayItems items = (RepairWorkArrayItems)row.DataBoundItem;
            try
            {
                //MessageBox.Show("//" + items.ID);
                //dataGridView1.Visible = false;
                //NewOrder NewOrder = new NewOrder(this, items);
                //NewOrder.Name = "NewOrder";

                //NewOrder.Dock = DockStyle.Fill;
                //panel5.Controls.Add(NewOrder);
                this.Hide();
                NewRepairWork NewRepairWork = new NewRepairWork(repairTechnicsList, this, RepairTechnicArrayItems);
                NewRepairWork.Name = "NewRepairWork";

                NewRepairWork.Dock = DockStyle.Fill;
                repairTechnicsList.panel5.Controls.Add(NewRepairWork);
            }
            catch (Exception)
            {


            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
            repairTechnicsList.dostyp_dataGridView1.Visible = true;
            repairTechnicsList.panel2.Enabled = true;
        }
    }
}

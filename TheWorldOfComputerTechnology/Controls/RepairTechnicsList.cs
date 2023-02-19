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
using TheWorldOfComputerTechnology.Controls;
using TheWorldOfComputerTechnology.Data;

namespace TheWorldOfComputerTechnology
{
    public partial class RepairTechnicsList : UserControl
    {
        public RepairTechnicsList()
        {
            InitializeComponent();



            ShowRepairTechnics(null);
        }
        public DataSet dataSet = new DataSet();
        public async void ShowRepairTechnics(string OrderBy)
        {

     
            await Task.Run(() => {
                dataSet = SQL.Table($@"Select RepairTechnic.ID, Technic.ID AS 'IDTechnic', Technic.Name as 'Technic', Type.ID as 'IDType', Type.Name as 'Type', RepairTechnic.DeliveryDate, RepairTechnic.Date, RepairTechnic.Orders
                from RepairTechnic
                Inner Join Technic Technic on Technic.ID = RepairTechnic.Technic
                Inner Join Type Type on Technic.Type = Type.ID {OrderBy}");
            });


            if (dataSet.Tables.Count <= 0)
            {

                return;
            }
            dataSet.Tables[0].TableName = "RepairTechnic";
            string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
            RepairTechnics employeesArrayItems = new RepairTechnics();
            employeesArrayItems = JsonConvert.DeserializeObject<RepairTechnics>(json);

            dataGridView1.DataSource = employeesArrayItems.RepairTechnic;
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
                        ShowRepairTechnics($" Order BY {dataGridView1.Columns[e.ColumnIndex].Name} ");
                    }
                    else
                    {
                        dataGridView1.Columns[e.ColumnIndex].Tag = 1;
                        //
                        ShowRepairTechnics($" Order BY {dataGridView1.Columns[e.ColumnIndex].Name} DESC ");
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
                RepairTechnicArrayItems items = (RepairTechnicArrayItems)row.DataBoundItem;
                try
                {
                    //MessageBox.Show("//" + items.ID);
                    //dataGridView1.Visible = false;
                    //NewRepairWork NewRepairWork = new NewRepairWork(this, items);
                    //NewRepairWork.Name = "NewRepairWork";

                    //NewRepairWork.Dock = DockStyle.Fill;
                    //panel5.Controls.Add(NewRepairWork);
                    dataGridView1.Visible = false;
                    RepairWorkList RepairWorkList = new RepairWorkList(this, items);
                    RepairWorkList.Name = "RepairWorkList";

                    RepairWorkList.Dock = DockStyle.Fill;
                    panel5.Controls.Add(RepairWorkList);
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
            //NewClient newEmployees = new NewClient(this);
            //newEmployees.Name = "NewEmployees";
            //
            //newEmployees.Dock = DockStyle.Fill;
            //panel5.Controls.Add(newEmployees);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var senderGrid = dataGridView1;
            DataGridViewRow row = (DataGridViewRow)senderGrid.Rows[ERowIndex];
            ClientArrayItems items = (ClientArrayItems)row.DataBoundItem;
            try
            {
                //MessageBox.Show("//" + items.ID);
                dataGridView1.Visible = false;
                //NewClient NewClient = new NewClient(this, items);
                //NewClient.Name = "NewEmployees";
                //
                //NewClient.Dock = DockStyle.Fill;
                //panel5.Controls.Add(NewClient);
                //panel5.Controls.Clear();
                //RepairWorkList RepairWorkList = new RepairWorkList(this, items);
                //RepairWorkList.Name = "RepairWorkList";

                //RepairWorkList.Dock = DockStyle.Fill;
                //panel5.Controls.Add(RepairWorkList);
            }
            catch (Exception)
            {


            }
        }
    }
}

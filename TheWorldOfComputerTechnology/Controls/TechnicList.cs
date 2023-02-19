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

namespace TheWorldOfComputerTechnology
{
    public partial class TechnicList : UserControl
    {
        public TechnicList()
        {
            InitializeComponent();



            ShowTechnicList(null);
        }
        public DataSet dataSet = new DataSet();
        public async void ShowTechnicList(string OrderBy)
        {

     
            await Task.Run(() => {
                dataSet = SQL.Table($@"Select Technic.ID, Technic.Marking, Technic.Name, 
                Type.ID as 'IDType', Type.Name as 'Type' from Technic
                Inner Join Type Type on Type.ID = Technic.Type {OrderBy}");
            });


            if (dataSet.Tables.Count <= 0)
            {

                return;
            }
            dataSet.Tables[0].TableName = "Technic";
            string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
            Technics employeesArrayItems = new Technics();
            employeesArrayItems = JsonConvert.DeserializeObject<Technics>(json);

            dataGridView1.DataSource = employeesArrayItems.Technic;
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
                        ShowTechnicList($" Order BY {dataGridView1.Columns[e.ColumnIndex].Name} ");
                    }
                    else
                    {
                        dataGridView1.Columns[e.ColumnIndex].Tag = 1;
                        //
                        ShowTechnicList($" Order BY {dataGridView1.Columns[e.ColumnIndex].Name} DESC ");
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
                TechnicArrayItems items = (TechnicArrayItems)row.DataBoundItem;
                try
                {
                    //MessageBox.Show("//" + items.ID);
                    dataGridView1.Visible = false;
                    NewTechnic NewTechnic = new NewTechnic(this, items);
                    NewTechnic.Name = "NewEmployees";
                    //
                    NewTechnic.Dock = DockStyle.Fill;
                    panel5.Controls.Add(NewTechnic);
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
            dataGridView1.Visible = false;
            NewTechnic NewTechnic = new NewTechnic(this);
            NewTechnic.Name = "NewEmployees";
            //
            NewTechnic.Dock = DockStyle.Fill;
            panel5.Controls.Add(NewTechnic);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var senderGrid = dataGridView1;
            DataGridViewRow row = (DataGridViewRow)senderGrid.Rows[ERowIndex];
            TechnicArrayItems items = (TechnicArrayItems)row.DataBoundItem;
            try
            {
                //MessageBox.Show("//" + items.ID);
                dataGridView1.Visible = false;
                NewTechnic NewTechnic = new NewTechnic(this, items);
                NewTechnic.Name = "NewEmployees";
                //
                NewTechnic.Dock = DockStyle.Fill;
                panel5.Controls.Add(NewTechnic);
            }
            catch (Exception)
            {


            }
        }
    }
}

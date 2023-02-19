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
    public partial class ClientList : UserControl
    {
        public ClientList()
        {
            InitializeComponent();



            ShowClient(null);
        }
        public DataSet dataSet = new DataSet();
        public async void ShowClient(string OrderBy)
        {

     
            await Task.Run(() => {
                dataSet = SQL.Table($@"Select Clients.ID, Clients.Surname,Clients.Name, 
                Clients.Patronymic,(Clients.Surname +' '+ Convert(nvarchar(1),Clients.Name,120) +'.'+  Convert(nvarchar(1),Clients.Patronymic,120)+'.') as FIO,
                Clients.DateOfBirth, Clients.PlaceOfBirth, 
                Clients.SeriesPassport, Clients.Number_passport, Clients.DateOfIssue,
                Clients.EndDate,Clients.PlaceOfIssue,Clients.Gender as 'IDGender', 
                Gender.Name as 'Gender', Clients.Status as 'IDStatus', ClientStatus.Name as 'Status'  
                from Clients
                Inner Join Gender Gender on Gender.ID = Clients.Gender
                Inner Join ClientStatus ClientStatus on ClientStatus.ID = Clients.Status  {OrderBy}");
            });


            if (dataSet.Tables.Count <= 0)
            {

                return;
            }
            dataSet.Tables[0].TableName = "Clients";
            string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
            ClientArray employeesArrayItems = new ClientArray();
            employeesArrayItems = JsonConvert.DeserializeObject<ClientArray>(json);

            dataGridView1.DataSource = employeesArrayItems.Clients;
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
                        ShowClient($" Order BY {dataGridView1.Columns[e.ColumnIndex].Name} ");
                    }
                    else
                    {
                        dataGridView1.Columns[e.ColumnIndex].Tag = 1;
                        //
                        ShowClient($" Order BY {dataGridView1.Columns[e.ColumnIndex].Name} DESC ");
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
                ClientArrayItems items = (ClientArrayItems)row.DataBoundItem;
                try
                {
                    //MessageBox.Show("//" + items.ID);
                    dataGridView1.Visible = false;
                    NewClient NewClient = new NewClient(this, items);
                    NewClient.Name = "NewEmployees";

                    NewClient.Dock = DockStyle.Fill;
                    panel5.Controls.Add(NewClient);
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
            NewClient newEmployees = new NewClient(this);
            newEmployees.Name = "NewEmployees";

            newEmployees.Dock = DockStyle.Fill;
            panel5.Controls.Add(newEmployees);
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
                NewClient NewClient = new NewClient(this, items);
                NewClient.Name = "NewEmployees";

                NewClient.Dock = DockStyle.Fill;
                panel5.Controls.Add(NewClient);
            }
            catch (Exception)
            {


            }
        }
    }
}

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
using TheWorldOfComputerTechnology.Controls;
namespace TheWorldOfComputerTechnology
{
    public partial class EmployeesList : UserControl
    {
        public EmployeesList()
        {
            InitializeComponent();



            ShowEmployees(null);
        }
        public DataSet dataSet = new DataSet();
        EmployeesArray employeesArrayItems = new EmployeesArray();
        public async void ShowEmployees(string OrderBy)
        {

     
            await Task.Run(() => {
                dataSet = SQL.Table($@"Select Employees.ID, Employees.Login, Employees.Password, Employees.Surname, Employees.Name,(Employees.Surname +' '+ Convert(nvarchar(1),Employees.Name,120) +'.'+  Convert(nvarchar(1),Employees.Patronymic,120)+'.') as FIO,
                Employees.Patronymic,Employees.DateOfBirth, Employees.Gender as 'IDGender', Gender.Name as 'Gender', Employees.Role as 'IDRole', Roles.Name as 'Role', Employees.Photo from Employees 
                Inner Join Gender Gender on Gender.ID = Employees.Gender
                Inner Join Roles Roles on Roles.ID = Employees.Role {OrderBy}"
                );
            });


            if (dataSet.Tables.Count <= 0)
            {

                return;
            }
            dataSet.Tables[0].TableName = "Employees";
            string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
      
            employeesArrayItems = JsonConvert.DeserializeObject<EmployeesArray>(json);
            //dataGridView1.Visible = false;
 
            dataGridView1.DataSource = employeesArrayItems.Employees;

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
                        ShowEmployees($" Order BY {dataGridView1.Columns[e.ColumnIndex].Name} ");
                    }
                    else
                    {
                        dataGridView1.Columns[e.ColumnIndex].Tag = 1;
                        ShowEmployees($" Order BY {dataGridView1.Columns[e.ColumnIndex].Name} DESC ");
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
                EmployeesArrayItems items = (EmployeesArrayItems)row.DataBoundItem;
                try
                {
                    panel2.Enabled = false;
                    dataGridView1.Visible = false;
                    NewEmployees newEmployees = new NewEmployees(this, items);
                    newEmployees.Name = "NewEmployees";

                    newEmployees.Dock = DockStyle.Fill;
                    panel5.Controls.Add(newEmployees);
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
            panel2.Enabled = false;
            dataGridView1.Visible = false;
            NewEmployees newEmployees = new NewEmployees(this);
            newEmployees.Name = "NewEmployees";

            newEmployees.Dock = DockStyle.Fill;
            panel5.Controls.Add(newEmployees);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Enabled = false;
            var senderGrid = dataGridView1;
            DataGridViewRow row = (DataGridViewRow)senderGrid.Rows[ERowIndex];
            EmployeesArrayItems items = (EmployeesArrayItems)row.DataBoundItem;
            try
            {

                dataGridView1.Visible = false;
                NewEmployees newEmployees = new NewEmployees(this, items);
                newEmployees.Name = "NewEmployees";

                newEmployees.Dock = DockStyle.Fill;
                panel5.Controls.Add(newEmployees);
            }
            catch (Exception)
            {


            }
        }
    }
}

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
    public partial class NewRepairWork : UserControl
    {
        RepairTechnicsList RepairTechnicsList;
        RepairTechnicArrayItems RepairTechnicArrayItems;
        RepairWorkList control;
        public NewRepairWork(RepairTechnicsList RepairTechnicsList, RepairWorkList control, RepairTechnicArrayItems RepairTechnicArrayItems)
        {
            InitializeComponent();
            this.RepairTechnicsList = RepairTechnicsList;   
            this.RepairTechnicArrayItems = RepairTechnicArrayItems;
            this.control = control;
            ShowCommboBox(false);
            ShowListOfErrors();
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm";
            dateTimePicker2.CustomFormat = "yyyy-MM-dd HH:mm";
            Update = false;

        }
        public NewRepairWork(RepairTechnicsList RepairTechnicsList, RepairWorkArrayItems RepairWorkArrayItems, RepairWorkList control)
        {
            InitializeComponent();
            this.RepairTechnicsList = RepairTechnicsList;
            this.RepairWorkArrayItems = RepairWorkArrayItems;
            this.control = control;
            ShowCommboBox(true);
            ShowListOfErrors();
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm";
            dateTimePicker2.CustomFormat = "yyyy-MM-dd HH:mm";
            Update = false;
        }
        RepairWorkArrayItems RepairWorkArrayItems = new RepairWorkArrayItems();
        DataSet dataSet = new DataSet();
      
        public async void ShowCommboBox(bool SelectComboBox)
        {
            await Task.Run(() => {
                dataSet = SQL.Table($@"Select Employees.ID, Employees.Login, Employees.Password, Employees.Surname, Employees.Name,(Employees.Surname +' '+ Convert(nvarchar(1),Employees.Name,120) +'.'+  Convert(nvarchar(1),Employees.Patronymic,120)+'.') as FIO,
                Employees.Patronymic,Employees.DateOfBirth, Employees.Gender as 'IDGender', Gender.Name as 'Gender', Employees.Role as 'IDRole', Roles.Name as 'Role', Employees.Photo from Employees 
                Inner Join Gender Gender on Gender.ID = Employees.Gender
                Inner Join Roles Roles on Roles.ID = Employees.Role;
	            Select * from ListOfErrors WHERE  RepairWork = {RepairWorkArrayItems.ID};
                ");
            });

            if (dataSet.Tables.Count < 1)
            {
                MessageBox.Show("F");
                return;
            }
            dataSet.Tables[0].TableName = "Employees";
     

            string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
            json = "" + json;
            EmployeesArray EmployeesArray = new EmployeesArray();
            EmployeesArray = JsonConvert.DeserializeObject<EmployeesArray>(json);


            
           

 
            comboBox2.DataSource = EmployeesArray.Employees;
            comboBox2.DisplayMember = "FIO";
            comboBox2.ValueMember = "ID";
            
            if (SelectComboBox)
            {

               // comboBox2.SelectedValue = RepairTechnicArrayItems.IDType;
            }


            comboBox2.SelectedIndexChanged += comboBox1_SelectedIndexChanged;


        }
        DataSet RepairTechnicdataSet = new DataSet();
        DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
        ListOfErrors ListOfErrors = new ListOfErrors();
        RepairTechnics RepairTechnics = new RepairTechnics();
        async void ShowListOfErrors()
        {
            textBox1.Text = RepairWorkArrayItems.Description;
            await Task.Run(() => {
                RepairTechnicdataSet = SQL.Table($@"
	            Select * from ListOfErrors WHERE  RepairWork = {RepairWorkArrayItems.ID}");
            });

            if (RepairTechnicdataSet.Tables.Count < 1)
            {
                MessageBox.Show("F");
                return;
            }
            RepairTechnicdataSet.Tables[0].TableName = "ListOfError";

            string json = JsonConvert.SerializeObject(RepairTechnicdataSet, Formatting.Indented);

            ListOfErrors = JsonConvert.DeserializeObject<ListOfErrors>(json);


            dataGridView1.Columns.Clear();
            buttonColumn.Name = "ColumnDelete";
            buttonColumn.UseColumnTextForButtonValue = true;
            buttonColumn.Text = "Удалить";
            buttonColumn.Width = 100;
            buttonColumn.HeaderText = "Действие";
            dataGridView1.Columns.Add(buttonColumn);
            dataGridView1.DataSource = ListOfErrors.ListOfError;
      
       

     
        }

        private void button1_Click(object sender, EventArgs e)
        {

           

        }
        bool Update = false;
        private void button4_Click(object sender, EventArgs e)
        {
            
            if (Update)
            {
                this.Dispose();
                control.Show();
                control.ShowRepairTechnic(null);
               
            }
            else
            {
                this.Dispose();
                control.Show();
            }
       
            RepairTechnicsList.panel2.Enabled = true;

        }
        string PathPhoto = "";
        private async void button3_Click(object sender, EventArgs e)
        {
            if (RepairWorkArrayItems.ID == 0)
            {
                ListOfErrorsAdd(false);
          
            }
            else
            {
                ListOfErrorsUpdate(false);

                
            }
           


        }
        private async void button2_Click(object sender, EventArgs e)
        {
            if (RepairWorkArrayItems.ID == 0)
            {
                ListOfErrorsAdd(true);
            }
            else
            {
                ListOfErrorsUpdate(true);
            }
            RepairTechnicsList.panel2.Enabled = true;
        }
        public async void ListOfErrorsUpdate(bool close)
        {
            Update = true;
            DataSet ResultDataSet = new DataSet();
 
            string res = "";
            if (ListOfErrors.ListOfError.ToArray().Where(y => y.ID == 0).ToArray().Length > 0)
            {
                res = $@"Insert Into ListOfErrors(
				        RepairWork,
				        DateStart,
				        Reason,
				        DateEnd,
				        Description) 
                        VALUES (" + string.Join(")," + Environment.NewLine + "(", ListOfErrors.ListOfError.ToArray().Where(y => y.ID == 0).Select(y => (y.RepairWork + ", '" + y.DateStart.ToString("dd-MM-yyyy HH:mm") + "', N'" +y.Reason+ "', '" + y.DateEnd.ToString("dd-MM-yyyy HH:mm") + "', N'" + y.Description+ "'"))) + ");";
            }

            if (DeleteListOfErrors != "")
            {
                res += $" Delete ListOfErrors where ListOfErrors.ID in (0{DeleteListOfErrors});";
            }




            EmployeesArrayItems EmployeesArrayItems = (EmployeesArrayItems)comboBox2.SelectedItem;
            await Task.Run(() => {
                ResultDataSet = SQL.Table($@"
                     Update RepairWork set 
                     RepairWork.Date = '{dateTimePicker3.Value.ToString("dd-MM-yyyy HH:mm")}',
                     RepairWork.Employees = '{EmployeesArrayItems.ID}',
                     RepairWork.Description= '{textBox1.Text}' 
                     where RepairWork.ID = {RepairWorkArrayItems.ID} ;
                {res}
				Select 
                RepairWork.ID, Orders.ID as 'IDOrder',Orders.Name as 'Order', 
                RepairWork.RepairTechnic, RepairWork.Date,
                RepairWork.Employees as 'IDEmployees', 
                (Employees.Surname +' '+ Convert(nvarchar(1),Employees.Name,120) +'.'+  Convert(nvarchar(1),Employees.Patronymic,120)+'.') as Employees,
                RepairWork.Description
                from RepairWork
                Inner Join RepairTechnic RepairTechnic on RepairTechnic.ID = RepairWork.RepairTechnic
                Inner Join Orders Orders on Orders.ID = RepairTechnic.Orders
                Inner Join Employees Employees on RepairWork.Employees = Employees.ID   where RepairWork.ID = {RepairWorkArrayItems.ID};
                ");
            });

            if (ResultDataSet.Tables.Count < 1)
            {
                MessageBox.Show("Что - то пошло не так");
                return;
            }
            if (ResultDataSet.Tables[0].Rows.Count < 1)
            {
                MessageBox.Show("Что - то пошло не так2");
                return;
            }

            string json = JsonConvert.SerializeObject(ResultDataSet.Tables[0], Formatting.Indented);
            json = json.Trim('[', ']');

            RepairWorkArrayItems = JsonConvert.DeserializeObject<RepairWorkArrayItems>(json);
            if (close)
            {
                this.Dispose();
                control.Show();
                control.ShowRepairTechnic(null);
                RepairTechnicsList.panel2.Enabled = true;
            }
    
        }

        public async void ListOfErrorsAdd(bool close)
        {
            Update = true;
            DataSet ResultDataSet = new DataSet();

            EmployeesArrayItems EmployeesArrayItems = (EmployeesArrayItems)comboBox2.SelectedItem;
            string res = "";
            if (ListOfErrors.ListOfError.ToArray().Where(y => y.ID == 0).ToArray().Length > 0)
            {
                res = $@"Insert Into ListOfErrors(
				        RepairWork,
				        DateStart,
				        Reason,
				        DateEnd,
				        Description) 
                        VALUES (" + string.Join(")," + Environment.NewLine + "(", ListOfErrors.ListOfError.ToArray().Where(y => y.ID == 0).Select(y => ("SCOPE_IDENTITY()" + ", '" + y.DateStart.ToString("dd-MM-yyyy HH:mm") + "', N'" + y.Reason + "', '" + y.DateEnd.ToString("dd-MM-yyyy HH:mm") + "', N'" + y.Description + "'"))) + ");";
            }
            await Task.Run(() => {
                ResultDataSet = SQL.Table($@"
				Insert Into RepairWork(
				RepairWork.RepairTechnic,
				RepairWork.Date,
				RepairWork.Employees,
				RepairWork.Description) 
				values (
				'{RepairTechnicArrayItems.ID}',
				'{dateTimePicker3.Value.ToString("dd-MM-yyyy HH:mm")}',
				'{EmployeesArrayItems.ID}',
				'{textBox1.Text}');
                Select 
                RepairWork.ID, Orders.ID as 'IDOrder',Orders.Name as 'Order', 
                RepairWork.RepairTechnic, RepairWork.Date,
                RepairWork.Employees as 'IDEmployees', 
                (Employees.Surname +' '+ Convert(nvarchar(1),Employees.Name,120) +'.'+  Convert(nvarchar(1),Employees.Patronymic,120)+'.') as Employees,
                RepairWork.Description
                from RepairWork
                Inner Join RepairTechnic RepairTechnic on RepairTechnic.ID = RepairWork.RepairTechnic
                Inner Join Orders Orders on Orders.ID = RepairTechnic.Orders
                Inner Join Employees Employees on RepairWork.Employees = Employees.ID  where RepairWork.ID = SCOPE_IDENTITY();
                {res}
                        ");
            });
            textBox1.Text = $@"
				Insert Into RepairWork(
				RepairWork.RepairTechnic,
				RepairWork.Date,
				RepairWork.Employees,
				RepairWork.Description) 
				values (
				'{RepairTechnicArrayItems.ID}',
				'{dateTimePicker3.Value.ToString("dd-MM-yyyy HH:mm")}',
				'{EmployeesArrayItems.ID}',
				'{textBox1.Text}');
                Select 
                RepairWork.ID, Orders.ID as 'IDOrder',Orders.Name as 'Order', 
                RepairWork.RepairTechnic, RepairWork.Date,
                RepairWork.Employees as 'IDEmployees', 
                (Employees.Surname +' '+ Convert(nvarchar(1),Employees.Name,120) +'.'+  Convert(nvarchar(1),Employees.Patronymic,120)+'.') as Employees,
                RepairWork.Description
                from RepairWork
                Inner Join RepairTechnic RepairTechnic on RepairTechnic.ID = RepairWork.RepairTechnic
                Inner Join Orders Orders on Orders.ID = RepairTechnic.Orders
                Inner Join Employees Employees on RepairWork.Employees = Employees.ID  where RepairWork.ID = SCOPE_IDENTITY();
                {res}
                        ";
            if (ResultDataSet.Tables.Count < 1)
            {
                MessageBox.Show("Что - то пошло не так");
                return;
            }
            if (ResultDataSet.Tables[0].Rows.Count < 1)
            {
                MessageBox.Show("Что - то пошло не так");
                return;
            }
          
            string json = JsonConvert.SerializeObject(ResultDataSet.Tables[0], Formatting.Indented);
            json = json.Trim('[', ']');

            RepairWorkArrayItems = JsonConvert.DeserializeObject<RepairWorkArrayItems>(json);
            if (close)
            {
                this.Dispose();
                control.Show();
                control.ShowRepairTechnic(null);
                RepairTechnicsList.panel2.Enabled = true;
            }

        }
        private async void button7_Click(object sender, EventArgs e)
        {
            EmployeesArrayItems Technics = (EmployeesArrayItems)comboBox2.SelectedItem;
            ListOfErrorArrayItems items = new ListOfErrorArrayItems();
            items.ID = 0;
            items.RepairWork = RepairWorkArrayItems.ID;
            items.Reason = textBox2.Text;
            items.Description = textBox3.Text;
            items.DateStart = dateTimePicker1.Value;
            items.DateEnd = dateTimePicker2.Value;

            ListOfErrors.ListOfError.Add(items);
            dataGridView1.DataSource = null;
  
            dataGridView1.DataSource = ListOfErrors.ListOfError;
      
        
        }

       
        private async void button6_Click(object sender, EventArgs e)
        {
           
            //ShowOrder();
        }
        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        string DeleteListOfErrors = "";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = (DataGridViewRow)senderGrid.Rows[e.RowIndex];
                ListOfErrorArrayItems items = (ListOfErrorArrayItems)row.DataBoundItem;
                try
                {
                    if (dataGridView1.Columns["ColumnDelete"].Index != e.ColumnIndex)
                    {
                        return;
                    }
                    if (items.ID == 0)
                    {

                        ListOfErrors.ListOfError.RemoveAt(e.RowIndex);
                        dataGridView1.DataSource = null;

                        dataGridView1.DataSource = ListOfErrors.ListOfError;
                    }
                    else
                    {
                        
                        ListOfErrors.ListOfError.RemoveAt(e.RowIndex);
                        dataGridView1.DataSource = null;

                        dataGridView1.DataSource = ListOfErrors.ListOfError;
                        DeleteListOfErrors += "," + items.ID;
                    }
                
                }
                catch (Exception)
                {


                }
            }
        }

       
    }
   
   
}

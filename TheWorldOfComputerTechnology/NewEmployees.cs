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
    public partial class NewEmployees : UserControl
    {
        ClientList employeesList;
        public NewEmployees(ClientList employeesList)
        {
            InitializeComponent();
            this.employeesList = employeesList;
            ShowCommboBox();

        }
        public NewEmployees(ClientList employeesList, EmployeesArrayItems Employees)
        {
            InitializeComponent();
            this.employeesList = employeesList;
            ShowCommboBox();
            this.Employees = Employees;
            ShowEmployees();
        }
        EmployeesArrayItems Employees = new EmployeesArrayItems();
        DataSet dataSet = new DataSet();
      
        public async void ShowCommboBox()
        {
            await Task.Run(() => {
                dataSet = SQL.Table($@"Select * from Roles;
                Select * from Gender;");
                });


            if (dataSet.Tables.Count < 2)
            {

                return;
            }
            dataSet.Tables[0].TableName = "Roles";
            dataSet.Tables[1].TableName = "Genders";
            string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
            json = "" + json;
            ComboBoxItemsRoles Roles = new ComboBoxItemsRoles();
            Roles = JsonConvert.DeserializeObject<ComboBoxItemsRoles>(json);
            string json2 = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
            json2 = "" + json2;
            ComboBoxItemsGenders Gender = new ComboBoxItemsGenders();
            Gender = JsonConvert.DeserializeObject<ComboBoxItemsGenders>(json2);
    

            comboBox1.DataSource = Roles.Roles;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
            comboBox2.DataSource = Gender.Genders;
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "ID";
   

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
  
        }
        void ShowEmployees()
        {
            textBox1.Text = Employees.Login;
            textBox2.Text = Employees.Password;
            textBox3.Text = Employees.Surname;
            textBox4.Text = Employees.Name;
            textBox5.Text = Employees.Patronymic;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (Employees.ID == 0)
            {
                this.Dispose();
                employeesList.dostyp_dataGridView1.Visible = true;
            }
            else
            {
                this.Dispose();
                employeesList.ShowEmployees();
            }

          

        }
        string PathPhoto = "";
        private async void button3_Click(object sender, EventArgs e)
        {
            if (Employees.ID == 0)
            {
                EmployeesAdd(false);
          
            }
            else
            {
                EmployeesUpdate(false);
                
            }
            
         

        }
        private async void button2_Click(object sender, EventArgs e)
        {
            if (Employees.ID == 0)
            {
                EmployeesAdd(true);
            }
            else
            {
                EmployeesUpdate(true);
            }
        }
        public async void EmployeesUpdate(bool close)
        {
            MessageBox.Show("//" + Employees.ID);
            DataSet ResultDataSet = new DataSet();
            ComboBoxItemsArray Role = (ComboBoxItemsArray)comboBox1.SelectedItem;
            ComboBoxItemsArray Gender = (ComboBoxItemsArray)comboBox2.SelectedItem;

            await Task.Run(() => {
                ResultDataSet = SQL.Table($@"UPDATE [dbo].[Employees]
                   SET [Login] = N'{textBox1.Text}'      
                      ,[Password] =  N'{textBox2.Text}'      
                      ,[Surname] = N'{textBox3.Text}'
                      ,[Name] = N'{textBox4.Text}'    
                      ,[Patronymic] = N'{textBox5.Text}'  
                      ,[DateOfBirth] ='{dateTimePicker1.Value.ToString("yyyy.MM.dd")}' 
                      ,[Role] ='{Role.ID}'    
                      ,[Gender] ='{Gender.ID}'
                      ,[Photo] = N'{PathPhoto}'     
                 WHERE Employees.ID =  {Employees.ID};
                Select Employees.ID, Employees.Login, Employees.Password, Employees.Surname, Employees.Name,
                Employees.Patronymic,Employees.DateOfBirth, Employees.Gender as 'IDGender', Gender.Name as 'Gender', Employees.Role as 'IDRole', Roles.Name as 'Role', Employees.Photo from Employees 
                Inner Join Gender Gender on Gender.ID = Employees.Gender
                Inner Join Roles Roles on Roles.ID = Employees.Role
				Where Employees.ID =  {Employees.ID};");
            });

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

            Employees = JsonConvert.DeserializeObject<EmployeesArrayItems>(json);
            if (close)
            {
                this.Dispose();
                employeesList.ShowEmployees();
            }
        }
        public async void EmployeesAdd(bool close)
        {
            DataSet ResultDataSet = new DataSet();
            ComboBoxItemsArray Role = (ComboBoxItemsArray)comboBox1.SelectedItem;
            ComboBoxItemsArray Gender = (ComboBoxItemsArray)comboBox2.SelectedItem;
          
            await Task.Run(() => {
                ResultDataSet = SQL.Table($@"INSERT INTO [dbo].[Employees]
               ([Login]
               ,[Password]
               ,[Surname]
               ,[Name]
               ,[Patronymic]
               ,[DateOfBirth]
               ,[Role]
               ,[Gender]
               ,[Photo])
                VALUES
               (N'{textBox1.Text}'
               ,N'{textBox2.Text}'
               ,N'{textBox3.Text}'
               ,N'{textBox4.Text}'
               ,N'{textBox5.Text}'
               ,'{dateTimePicker1.Value.ToString("yyyy.MM.dd")}'
               ,'{Role.ID}'
               ,'{Gender.ID}'
               ,N'{PathPhoto}');
                Select Employees.ID, Employees.Login, Employees.Password, Employees.Surname, Employees.Name,
                Employees.Patronymic,Employees.DateOfBirth, Employees.Gender as 'IDGender', Gender.Name as 'Gender', Employees.Role as 'IDRole', Roles.Name as 'Role', Employees.Photo from Employees 
                Inner Join Gender Gender on Gender.ID = Employees.Gender
                Inner Join Roles Roles on Roles.ID = Employees.Role
				Where Employees.ID =  SCOPE_IDENTITY();");
            });
           
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

            Employees = JsonConvert.DeserializeObject<EmployeesArrayItems>(json);
            if (close)
            {
                this.Dispose();
                employeesList.ShowEmployees();
            }

        }
        
        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItemsArray items = (ComboBoxItemsArray)comboBox.SelectedItem;
            MessageBox.Show(items.ID + ""+ items.Name);
        }

        
    }
   
   
}

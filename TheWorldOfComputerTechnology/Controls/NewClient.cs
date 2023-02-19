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
using TheWorldOfComputerTechnology;

namespace TheWorldOfComputerTechnology
{
    public partial class NewClient : UserControl
    {
        ClientList ClientList;
        public NewClient(ClientList ClientList)
        {
            InitializeComponent();
            this.ClientList = ClientList;
            ShowCommboBox(false);

        }
        public NewClient(ClientList ClientList, ClientArrayItems Client)
        {
            InitializeComponent();
            this.ClientList = ClientList;
            ShowCommboBox(true);
            this.Client = Client;
            ShowEmployees();
        }
        ClientArrayItems Client = new ClientArrayItems();
        DataSet dataSet = new DataSet();
      
        public async void ShowCommboBox(bool SelectComboBox)
        {
            await Task.Run(() => {
                dataSet = SQL.Table($@"Select * from ClientStatus;
                Select * from Gender;");
                });


            if (dataSet.Tables.Count < 2)
            {

                return;
            }
            dataSet.Tables[0].TableName = "ClientStatus";
            dataSet.Tables[1].TableName = "Genders";
            string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
            json = "" + json;
            ComboBoxItemsClientStatus ClientStatus = new ComboBoxItemsClientStatus();
            ClientStatus = JsonConvert.DeserializeObject<ComboBoxItemsClientStatus>(json);
            string json2 = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
            json2 = "" + json2;
            ComboBoxItemsGenders Gender = new ComboBoxItemsGenders();
            Gender = JsonConvert.DeserializeObject<ComboBoxItemsGenders>(json2);

            comboBox1.DataSource = Gender.Genders;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
            comboBox2.DataSource = ClientStatus.ClientStatus;
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "ID";


            if (SelectComboBox)
            {
                comboBox1.SelectedValue = Client.IDGender;
                comboBox2.SelectedValue = Client.IDStatus;

            }


            //comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            //comboBox2.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

        }
        void ShowEmployees()
        {
    
            textBox1.Text = Client.Surname;
            textBox2.Text = Client.Name;
            textBox3.Text = Client.Patronymic;
            dateTimePicker1.Value = Client.DateOfBirth;
            textBox4.Text = Client.PlaceOfBirth;
            maskedTextBox1.Text = Client.SeriesPassport.ToString();
            maskedTextBox2.Text = Client.Number_passport.ToString();
            dateTimePicker2.Value = Client.DateOfIssue;
            dateTimePicker3.Value = Client.EndDate;
            textBox5.Text = Client.PlaceOfIssue;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (Client.ID == 0)
            {
                this.Dispose();
                ClientList.dostyp_dataGridView1.Visible = true;
            }
            else
            {
                this.Dispose();
                ClientList.ShowClient(null);
            }

          

        }
        string PathPhoto = "";
        private async void button3_Click(object sender, EventArgs e)
        {
            if (Client.ID == 0)
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
            if (Client.ID == 0)
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
   
            DataSet ResultDataSet = new DataSet();
            ComboBoxItemsArray Gender = (ComboBoxItemsArray)comboBox1.SelectedItem;
            ComboBoxItemsArray ClientStatus = (ComboBoxItemsArray)comboBox2.SelectedItem;

            await Task.Run(() => {
                ResultDataSet = SQL.Table($@"
                UPDATE [dbo].[Clients]
                   SET [Surname] = N'{textBox1.Text}'
                      ,[Name] = N'{textBox2.Text}'
                      ,[Patronymic] = N'{textBox3.Text}'
                      ,[DateOfBirth] = '{dateTimePicker1.Value.ToString("yyyy.MM.dd")}'
                      ,[PlaceOfBirth] = N'{textBox4.Text}'
                      ,[SeriesPassport] = '{maskedTextBox1.Text}'
                      ,[Number_passport] = '{maskedTextBox2.Text}'
                      ,[DateOfIssue] = '{dateTimePicker2.Value.ToString("yyyy.MM.dd")}'
                      ,[EndDate] = '{dateTimePicker3.Value.ToString("yyyy.MM.dd")}'
                      ,[PlaceOfIssue] = N'{textBox5.Text}'
                      ,[Gender] = '{Gender.ID}'
                      ,[Status] = '{ClientStatus.ID}'
                 WHERE Clients.ID =  '{Client.ID}';
                Select Clients.ID, Clients.Surname,Clients.Name, (Clients.Surname +' '+ Convert(char(1),Clients.Name,120) +'.'+  Convert(char(1),Clients.Patronymic,120)+'.') as FIO,
                Clients.Patronymic,Clients.DateOfBirth, Clients.PlaceOfBirth, 
                Clients.SeriesPassport, Clients.Number_passport, Clients.DateOfIssue,
                Clients.EndDate,Clients.PlaceOfIssue,Clients.Gender as 'IDGender', 
                Gender.Name as 'Gender', Clients.Status as 'IDStatus', ClientStatus.Name as 'Status'  
                from Clients
                Inner Join Gender Gender on Gender.ID = Clients.Gender
                Inner Join ClientStatus ClientStatus on ClientStatus.ID = Clients.Status
			    Where Clients.ID =  '{Client.ID}';");
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

            Client = JsonConvert.DeserializeObject<ClientArrayItems>(json);
            if (close)
            {
                this.Dispose();
                ClientList.ShowClient(null);
            }
        }
        public async void EmployeesAdd(bool close)
        {
            DataSet ResultDataSet = new DataSet();
            ComboBoxItemsArray Gender = (ComboBoxItemsArray)comboBox1.SelectedItem;
            ComboBoxItemsArray ClientStatus = (ComboBoxItemsArray)comboBox2.SelectedItem;
            
          
            await Task.Run(() => {
                ResultDataSet = SQL.Table($@"
                INSERT INTO [dbo].[Clients]
                ([Surname]
                ,[Name]
                ,[Patronymic]
                ,[DateOfBirth]
                ,[PlaceOfBirth]
                ,[SeriesPassport]
                ,[Number_passport]
                ,[DateOfIssue]
                ,[EndDate]
                ,[PlaceOfIssue]
                ,[Gender]
                ,[Status])
                 VALUES
                (N'{textBox1.Text}'
                ,N'{textBox2.Text}'
                ,N'{textBox3.Text}'
                ,'{dateTimePicker1.Value.ToString("yyyy.MM.dd")}'
                ,N'{textBox4.Text}'
                ,'{maskedTextBox1.Text}'
                ,'{maskedTextBox2.Text}'
                ,'{dateTimePicker2.Value.ToString("yyyy.MM.dd")}'
                ,'{dateTimePicker3.Value.ToString("yyyy.MM.dd")}'
                ,N'{textBox5.Text}'
                ,'{Gender.ID}'
                ,'{ClientStatus.ID}');
                Select Clients.ID, Clients.Surname,Clients.Name, (Clients.Surname +' '+ Convert(nvarchar(1),Clients.Name,120) +'.'+  Convert(nvarchar(1),Clients.Patronymic,120)+'.') as FIO,
                Clients.Patronymic,Clients.DateOfBirth, Clients.PlaceOfBirth, 
                Clients.SeriesPassport, Clients.Number_passport, Clients.DateOfIssue,
                Clients.EndDate,Clients.PlaceOfIssue,Clients.Gender as 'IDGender', 
                Gender.Name as 'Gender', Clients.Status as 'IDStatus', ClientStatus.Name as 'Status'  
                from Clients
                Inner Join Gender Gender on Gender.ID = Clients.Gender
                Inner Join ClientStatus ClientStatus on ClientStatus.ID = Clients.Status
			    Where Clients.ID =  SCOPE_IDENTITY();");
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

            Client = JsonConvert.DeserializeObject<ClientArrayItems>(json);
            if (close)
            {
                this.Dispose();
                ClientList.ShowClient(null);
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

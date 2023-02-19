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
    public partial class NewTechnic : UserControl
    {
        TechnicList TechnicList;
        public NewTechnic(TechnicList TechnicList)
        {
            InitializeComponent();
            this.TechnicList = TechnicList;
            ShowCommboBox(false);

        }
        public NewTechnic(TechnicList TechnicList, TechnicArrayItems TechnicArrayItems)
        {
            InitializeComponent();
            this.TechnicList = TechnicList;
            ShowCommboBox(true);
            this.TechnicArrayItems = TechnicArrayItems;
            ShowEmployees();
        }
        TechnicArrayItems TechnicArrayItems = new TechnicArrayItems();
        DataSet dataSet = new DataSet();
        DataGridViewButtonColumn buttonColumn1 = new DataGridViewButtonColumn();
        CharacteristicsOfTheEquipments CharacteristicsOfTheEquipments = new CharacteristicsOfTheEquipments();
        public async void ShowCommboBox(bool SelectComboBox)
        {
            await Task.Run(() => {
                dataSet = SQL.Table($@"Select * from Type;
				Select CharacteristicsOfTheEquipment.ID,CharacteristicsOfTheEquipment.Technic, CharacteristicsOfTheEquipment.Characteristics, CharacteristicsOfTheEquipment.Meaning from Technic
				Inner Join CharacteristicsOfTheEquipment CharacteristicsOfTheEquipment on CharacteristicsOfTheEquipment.Technic = Technic.ID where Technic.ID  = {TechnicArrayItems.ID};");
                });


            if (dataSet.Tables.Count < 2)
            {

                return;
            }
            dataSet.Tables[0].TableName = "Type";
            dataSet.Tables[1].TableName = "CharacteristicsOfTheEquipment";
            string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
            json = "" + json;
            ComboBoxItemsType ComboBoxItemsType = new ComboBoxItemsType();
            ComboBoxItemsType = JsonConvert.DeserializeObject<ComboBoxItemsType>(json);
            string json2 = JsonConvert.SerializeObject(dataSet, Formatting.Indented);

            
            CharacteristicsOfTheEquipments = JsonConvert.DeserializeObject<CharacteristicsOfTheEquipments>(json2);

            comboBox1.DataSource = ComboBoxItemsType.Type;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";

            if (SelectComboBox)
            {
                comboBox1.SelectedValue = TechnicArrayItems.IDType;

            }



            dataGridView2.Columns.Clear();
            buttonColumn1.Name = "ColumnDelete";
            buttonColumn1.UseColumnTextForButtonValue = true;
            buttonColumn1.Text = "Удалить";
            buttonColumn1.Width = 100;
            buttonColumn1.HeaderText = "Действие";
            
            dataGridView2.DataSource = CharacteristicsOfTheEquipments.CharacteristicsOfTheEquipment;
            
            //comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            //comboBox2.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

        }
        void ShowEmployees()
        {

            textBox1.Text = TechnicArrayItems.Marking;
            textBox2.Text = TechnicArrayItems.Name;
      
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (TechnicArrayItems.ID == 0)
            {
                this.Dispose();
               
            }
            else
            {
                this.Dispose();
                TechnicList.dostyp_dataGridView1.Visible = true;
            }



        }
        string PathPhoto = "";
        private async void button3_Click(object sender, EventArgs e)
        {
            if (TechnicArrayItems.ID == 0)
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
            if (TechnicArrayItems.ID == 0)
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
            ComboBoxItemsArray ComboBoxItemsArray = (ComboBoxItemsArray)comboBox1.SelectedItem;

            await Task.Run(() => {
                ResultDataSet = SQL.Table($@"		
                Update Technic set 
				Technic.Name = '{textBox1.Text}',
				Technic.Marking = '{textBox2.Text}',
				Technic.Type = '{ComboBoxItemsArray.ID}' where {TechnicArrayItems.ID};
                Select Technic.ID, Technic.Marking, Technic.Name, 
                Type.ID as 'IDType', Type.Name as 'Type' from Technic
                Inner Join Type Type on Type.ID = Technic.Type where Technic.ID = {TechnicArrayItems.ID};
				");
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

            TechnicArrayItems = JsonConvert.DeserializeObject<TechnicArrayItems>(json);
            if (close)
            {
                this.Dispose();
                TechnicList.ShowTechnicList(null);
            }
        }
        public async void EmployeesAdd(bool close)
        {
            DataSet ResultDataSet = new DataSet();
            ComboBoxItemsArray Gender = (ComboBoxItemsArray)comboBox1.SelectedItem;
            ComboBoxItemsArray ClientStatus = (ComboBoxItemsArray)comboBox1.SelectedItem;
            
          
            await Task.Run(() => {
                ResultDataSet = SQL.Table($@"");
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

            TechnicArrayItems = JsonConvert.DeserializeObject<TechnicArrayItems>(json);
            if (close)
            {
                this.Dispose();
                TechnicList.dostyp_dataGridView1.Visible = true;
                TechnicList.ShowTechnicList(null);
            }

        }
        
        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItemsArray items = (ComboBoxItemsArray)comboBox.SelectedItem;
            MessageBox.Show(items.ID + ""+ items.Name);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            CharacteristicsOfTheEquipmentArrayItems items = new CharacteristicsOfTheEquipmentArrayItems();
            items.ID = 0;
            items.Technic = 0;
            items.Characteristics = textBox3.Text;
            items.Meaning = textBox4.Text;
            CharacteristicsOfTheEquipments.CharacteristicsOfTheEquipment.Add(items);
            dataGridView2.DataSource = null;

            dataGridView2.DataSource = CharacteristicsOfTheEquipments.CharacteristicsOfTheEquipment;

        }
        string DeleteCharacteristicsOfTheEquipments = "";
    }
   
   
}

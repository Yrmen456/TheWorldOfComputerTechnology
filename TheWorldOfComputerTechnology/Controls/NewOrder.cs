using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessagingToolkit.QRCode.Codec;
using Newtonsoft.Json;
using TheWorldOfComputerTechnology.Controls;
using TheWorldOfComputerTechnology.Data;


namespace TheWorldOfComputerTechnology
{
    public partial class NewOrder : UserControl
    {
        OrderList OrderList;
        public NewOrder(OrderList OrderList)
        {
            InitializeComponent();
            this.OrderList = OrderList;
            ShowCommboBox(false);
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm";
            dateTimePicker2.CustomFormat = "yyyy-MM-dd HH:mm";
            ShowOrder();
        }
        public NewOrder(OrderList OrderList, OrderArrayItems Order)
        {
            InitializeComponent();
            this.OrderList = OrderList;
            this.Order = Order;
            ShowCommboBox(true);
            ShowOrder();
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm";
            dateTimePicker2.CustomFormat = "yyyy-MM-dd HH:mm";
        }
        OrderArrayItems Order = new OrderArrayItems();
        DataSet dataSet = new DataSet();
      
        public async void ShowCommboBox(bool SelectComboBox)
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
                Inner Join ClientStatus ClientStatus on ClientStatus.ID = Clients.Status;
                Select * from OrderStatus;
                Select Technic.ID, Technic.Marking, Technic.Name, 
                Type.ID as 'IDType', Type.Name as 'Type' from Technic
                Inner Join Type Type on Type.ID = Technic.Type;
                ");
            });

            if (dataSet.Tables.Count < 2)
            {
                MessageBox.Show("F");
                return;
            }
            dataSet.Tables[0].TableName = "Clients";
            dataSet.Tables[1].TableName = "OrderStatus";
            dataSet.Tables[2].TableName = "Technic";
            string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
            json = "" + json;
            ClientArray Client = new ClientArray();
            Client = JsonConvert.DeserializeObject<ClientArray>(json);
            string json2 = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
            json2 = "" + json2;
            ComboBoxItemsOrderStatus OrderStatus = new ComboBoxItemsOrderStatus();
            OrderStatus = JsonConvert.DeserializeObject<ComboBoxItemsOrderStatus>(json2);

            string json3 = JsonConvert.SerializeObject(dataSet, Formatting.Indented);

            Technic = JsonConvert.DeserializeObject<Technics>(json3);

            comboBox1.DataSource = Client.Clients;
            comboBox1.DisplayMember = "FIO";
            comboBox1.ValueMember = "ID";
            comboBox2.DataSource = OrderStatus.OrderStatus;
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "ID";
            comboBox3.DataSource = Technic.Technic;
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "ID";
            if (SelectComboBox)
            {
                comboBox1.SelectedValue = Order.IDClient;
                comboBox2.SelectedValue = Order.IDStatus;
            }

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += comboBox1_SelectedIndexChanged;


        }
        DataSet RepairTechnicdataSet = new DataSet();
        DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
        Technics Technic = new Technics();
        RepairTechnics RepairTechnics = new RepairTechnics();
        async void ShowOrder()
        {
            textBox1.Text = Order.Name;
            await Task.Run(() => {
                RepairTechnicdataSet = SQL.Table($@"
                Select RepairTechnic.ID, Technic.ID AS 'IDTechnic', Technic.Name as 'Technic', Type.ID as 'IDType', Type.Name as 'Type', RepairTechnic.DeliveryDate, RepairTechnic.Date, RepairTechnic.Orders
                from RepairTechnic
                Inner Join Technic Technic on Technic.ID = RepairTechnic.Technic
                Inner Join Type Type on Technic.Type = Type.ID
                Where RepairTechnic.Orders = {Order.ID}");
            });

            if (RepairTechnicdataSet.Tables.Count < 1)
            {
                MessageBox.Show("F");
                return;
            }
          
            RepairTechnicdataSet.Tables[0].TableName = "RepairTechnic";
         
            string json1 = JsonConvert.SerializeObject(RepairTechnicdataSet, Formatting.Indented);
           
            RepairTechnics = JsonConvert.DeserializeObject<RepairTechnics>(json1);
            
            dataGridView1.Columns.Clear();
            buttonColumn.Name = "ColumnDelete";
            buttonColumn.UseColumnTextForButtonValue = true;
            buttonColumn.Text = "Удалить";
            buttonColumn.Width = 100;
            buttonColumn.HeaderText = "Действие";
            dataGridView1.Columns.Add(buttonColumn);
            dataGridView1.DataSource = RepairTechnics.RepairTechnic;
            
       

     
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
                OrderList.ShowOrder(null);
            }
            else
            {
                this.Dispose();
                OrderList.dostyp_dataGridView1.Visible = true;
            }

            OrderList.panel2.Enabled = true;

        }
        string PathPhoto = "";
        private async void button3_Click(object sender, EventArgs e)
        {
            if (Order.ID == 0)
            {
                OrderAdd(false);
          
            }
            else
            {
                OrderUpdate(false);

                
            }
           


        }
        private async void button2_Click(object sender, EventArgs e)
        {
            if (Order.ID == 0)
            {
                OrderAdd(true);
            }
            else
            {
                OrderUpdate(true);
            }
            OrderList.panel2.Enabled = true;
        }
        public async void OrderUpdate(bool close)
        {
            Update = true;
            DataSet ResultDataSet = new DataSet();
            TechnicArrayItems Technics = (TechnicArrayItems)comboBox3.SelectedItem;
            string res = "";
            if (RepairTechnics.RepairTechnic.ToArray().Where(y => y.ID == 0).ToArray().Length > 0)
            {
                res = $@"INSERT INTO [dbo].[RepairTechnic]
                       ([Technic]
                       ,[DeliveryDate]
                       ,[Date]
                       ,[Orders])
                        VALUES (" + string.Join(")," + Environment.NewLine + "(", RepairTechnics.RepairTechnic.ToArray().Where(y => y.ID == 0).Select(y => (y.IDTechnic + ", '" + y.DeliveryDate.ToString("dd-MM-yyyy HH:mm") + "', '" + y.Date.ToString("dd-MM-yyyy HH:mm") + "', " + y.Orders))) + ");";
            }
           
            if (DeleteRepairTechnic != "")
            {
                res += $" Delete RepairTechnic where RepairTechnic.ID in (0{DeleteRepairTechnic})";
            }
            ClientArrayItems Client = (ClientArrayItems)comboBox1.SelectedItem;
            ComboBoxItemsArray OrderStatus = (ComboBoxItemsArray)comboBox2.SelectedItem;
            await Task.Run(() => {
                ResultDataSet = SQL.Table($@"{res}
                                            UPDATE [dbo].[Orders]
                    SET [Name] = N'{textBox1.Text}'
                        ,[Date] = '{DateTime.Now.ToString("dd-MM-yyyy HH:mm")}'
                        ,[Client] = '{Client.ID}'
                        ,[Status] = '{OrderStatus.ID}'
                    WHERE [Orders].ID	= {Order.ID} ;
                Select Orders.ID, Orders.Name, Orders.Date, Orders.Client as 'IDClient', 
                (Clients.Surname +' '+ Convert(char(1), Clients.Name,120)+'.'
                +Convert(char(1), Clients.Patronymic,120)+'.') as 'FIO', 
                Orders.Status as 'IDStatus', OrderStatus.Name  AS 'Status' from Orders
                Inner Join OrderStatus OrderStatus on OrderStatus.ID = Orders.Status
                Inner Join Clients Clients on Clients.ID = Orders.Client where Orders.ID = {Order.ID};
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

            Order = JsonConvert.DeserializeObject<OrderArrayItems>(json);
            if (close)
            {
                this.Dispose();
                OrderList.ShowOrder(null);
            }
        }

        public async void OrderAdd(bool close)
        {
            Update = true;
            DataSet ResultDataSet = new DataSet();
            ClientArrayItems Client = (ClientArrayItems)comboBox1.SelectedItem;
            ComboBoxItemsArray OrderStatus = (ComboBoxItemsArray)comboBox2.SelectedItem;

            TechnicArrayItems Technics = (TechnicArrayItems)comboBox3.SelectedItem;
            string res = "";
            if (RepairTechnics.RepairTechnic.ToArray().Where(y => y.ID == 0).ToArray().Length > 0)
            {
                res = $@"INSERT INTO [dbo].[RepairTechnic]
                       ([Technic]
                       ,[DeliveryDate]
                       ,[Date]
                       ,[Orders])
                        VALUES (" + string.Join(")," + Environment.NewLine + "(", RepairTechnics.RepairTechnic.ToArray().Where(y => y.ID == 0).Select(y => (y.IDTechnic + ", '" + y.DeliveryDate.ToString("dd-MM-yyyy HH:mm") + "', '" + y.Date.ToString("dd-MM-yyyy HH:mm") + "', " + " SCOPE_IDENTITY() "))) + ");";
            }


            await Task.Run(() => {
                ResultDataSet = SQL.Table($@"INSERT INTO [dbo].[Orders]
                       ([Name]
                       ,[Date]
                       ,[Client]
                       ,[Status])
                 VALUES
                       (N'{textBox1.Text}'
                       ,'{DateTime.Now.ToString("yyyy.MM.dd")}'
                       ,'{Client.ID}'
                       ,'{OrderStatus.ID}');
              
                Select Orders.ID, Orders.Name, Orders.Date, Orders.Client as 'IDClient', 
                (Clients.Surname +' '+ Convert(char(1), Clients.Name,120)+'.'
                +Convert(char(1), Clients.Patronymic,120)+'.') as 'FIO', 
                Orders.Status as 'IDStatus', OrderStatus.Name  AS 'Status' from Orders
                Inner Join OrderStatus OrderStatus on OrderStatus.ID = Orders.Status
                Inner Join Clients Clients on Clients.ID = Orders.Client where Orders.ID = SCOPE_IDENTITY();

                  {res}
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

            Order = JsonConvert.DeserializeObject<OrderArrayItems>(json);
            if (close)
            {
                this.Dispose();
                OrderList.ShowOrder(null);
            }

        }
        private async void button7_Click(object sender, EventArgs e)
        {
            TechnicArrayItems Technics = (TechnicArrayItems)comboBox3.SelectedItem;
            RepairTechnicArrayItems items = new RepairTechnicArrayItems();
            items.ID = 0;
            items.IDTechnic = Technics.ID;
            items.Technic = Technics.Name;
            items.DeliveryDate = dateTimePicker1.Value;
            items.Date = dateTimePicker2.Value;
            items.Orders = Order.ID;
            items.IDType = Technics.IDType;
            items.Type = Technics.Type;
            RepairTechnics.RepairTechnic.Add(items);
            dataGridView1.DataSource = null;
  
            dataGridView1.DataSource = RepairTechnics.RepairTechnic;
      
        
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
        string DeleteRepairTechnic = "";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = (DataGridViewRow)senderGrid.Rows[e.RowIndex];
                RepairTechnicArrayItems items = (RepairTechnicArrayItems)row.DataBoundItem;
                try
                {
                    if (dataGridView1.Columns["ColumnDelete"].Index != e.ColumnIndex)
                    {
                        return;
                    }
                    if (items.ID == 0)
                    {

                        RepairTechnics.RepairTechnic.RemoveAt(e.RowIndex);
                        dataGridView1.DataSource = null;

                        dataGridView1.DataSource = RepairTechnics.RepairTechnic;
                    }
                    else
                    {
                        DataSet RESULT = SQL.Table($@"Select * from RepairTechnic
				        Inner Join RepairWork RepairWork on RepairWork.RepairTechnic = RepairTechnic.ID
				        where RepairTechnic.ID = {items.ID}");
                        if (RESULT.Tables.Count <1)
                        {

                            return;
                        }
                        if (RESULT.Tables[0].Rows.Count >= 1)
                        {
                            MessageBox.Show("Нельзя удалить так как Уже проведенныы работы");
                            return;
                        }
                        RepairTechnics.RepairTechnic.RemoveAt(e.RowIndex);
                        dataGridView1.DataSource = null;

                        dataGridView1.DataSource = RepairTechnics.RepairTechnic;
                        DeleteRepairTechnic += "," + items.ID;
                    }
                
                }
                catch (Exception)
                {


                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (Order.ID == 0)
            {
                MessageBox.Show("Сначало создайте Заказ");
                return;
            }
            QRCodeEncoder qrecnoder = new QRCodeEncoder();
            Bitmap qrcode = qrecnoder.Encode(Order.Name);
            pictureBox1.Image = qrcode as Image;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
   
   
}

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
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }
        bool visible_password_click = true;
        private void visible_password_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void visible_password_Click(object sender, EventArgs e)
        {
            if (visible_password_click)
            {

                visible_password_click = false;
                password_textbox.UseSystemPasswordChar = false;
                visible_password.BackgroundImage = Properties.Resources.open;
            }
            else
            {
                password_textbox.UseSystemPasswordChar = true;
                visible_password_click = true;
                visible_password.BackgroundImage = Properties.Resources.close;
            }
        }

        private void form_authorization_MouseDown(object sender, MouseEventArgs e)
        {
            form_authorization.Capture = false;
            labelTitle.Capture = false;
            pictureBox_logo.Capture = false;
            Message m = Message.Create(Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }

        private void login_out_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void login_up_Click(object sender, EventArgs e)
        {
            DataSet dataSet = new DataSet();
            await Task.Run(() => {
                dataSet = SQL.Table($@"Select Employees.ID, Employees.Login, Employees.Password, Employees.Surname, Employees.Name,
                Employees.Patronymic,Employees.DateOfBirth, Employees.Gender as 'IDGender', Gender.Name as 'Gender', Employees.Role as 'IDRole', Roles.Name as 'Role', Employees.Photo from Employees 
                Inner Join Gender Gender on Gender.ID = Employees.Gender
                Inner Join Roles Roles on Roles.ID = Employees.Role
                where Login = '{login_textbox.Text}' and Password = '{password_textbox.Text}' ");
            });
            if (dataSet.Tables.Count <=0)
            {
                MessageBox.Show("что - то пошло не так");
                return;
            }
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                MessageBox.Show("Логин или проль введен неверно");
                return;
            }
            string json = JsonConvert.SerializeObject(dataSet.Tables[0], Formatting.Indented);
            json = json.Trim('[',']');
            User user = new User();
            user = JsonConvert.DeserializeObject<User>(json);
            UserData.user = user;
            Program.MyApplicationContext.Open(new Main());
            this.Close();
        }
    }

    
}

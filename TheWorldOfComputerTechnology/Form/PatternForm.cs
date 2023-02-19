using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheWorldOfComputerTechnology.Data;

namespace TheWorldOfComputerTechnology
{
    public partial class PatternForm : Form
    {
        public PatternForm()
        {
            InitializeComponent();
            this.BackColor = MyColors.ColorWhite;

        }

        private void PatternForm_Load(object sender, EventArgs e)
        {

        }

        private void PatternForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            Color color = System.Drawing.ColorTranslator.FromHtml("#dedede");
            Pen p = new Pen(color, 1);// цвет линии и ширина
            Point p1 = new Point(-2, 0);// первая точка
            Point p2 = new Point(this.Width + 2, 0);// вторая точка
            gr.DrawLine(p, p1, p2);// рисуем линию
            gr.Dispose();// освобождаем все ресурсы, связанные с отрисовкой
        }
    }
}

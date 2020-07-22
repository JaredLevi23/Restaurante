using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante
{
    public partial class Reservaciones : Form
    {
        public Reservaciones()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void Reservaciones_Resize(object sender, EventArgs e)
        {
            panel4.Width = (panel3.Width) / 4;
            panel9.Width = (panel3.Width) / 4;
            panel5.Width = (panel3.Width) / 4;
            panel2.Width = (panel3.Width) / 4;
            panel11.Width = ((panel3.Width) / 4)*3;
            panel12.Width = (panel3.Width) / 4;
        }

        private void Reservaciones_Load(object sender, EventArgs e)
        {

        }
    }
}

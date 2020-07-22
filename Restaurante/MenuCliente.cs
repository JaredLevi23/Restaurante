using FontAwesome.Sharp;
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
    public partial class MenuCliente : Form
    {
        private Form currentChildForm;
        private Panel leftBorderBtn;
        private IconButton currentBtn;
        public MenuCliente()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 40);
            panel1.Controls.Add(leftBorderBtn);



        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {

        }
        public void OpenChildForm(Form nuevo)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = nuevo;
            nuevo.TopLevel = false;
            nuevo.FormBorderStyle = FormBorderStyle.None;
            nuevo.Dock = DockStyle.Fill;
            panel2.Controls.Add(nuevo);
            panel2.Tag = nuevo;
            nuevo.BringToFront();
            nuevo.Show();
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.Black;
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.White;
                currentBtn.ForeColor = Color.Black;
                currentBtn.IconColor = Color.Black;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

       

        private void iconButton5_Click(object sender, EventArgs e)
        {
            iconButton1.Visible = false;
            iconButton2.Visible = false;
            label1.Visible = true;
            iconButton3.Visible = true;
            iconButton6.Visible = true;
            iconButton5.Visible = false;
            iconButton7.Visible = true;
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            iconButton1.Visible = true;
            iconButton2.Visible = true;
            label1.Visible = false;
            iconButton3.Visible = false;
            iconButton6.Visible = false;
            iconButton5.Visible = true;
            iconButton7.Visible = false;
            iconButton1_Click(sender,e);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.White);
            OpenChildForm(new Ordenes());
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.White);
            OpenChildForm(new Reservaciones());
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.White);
            OpenChildForm(new Menu_Restaurante());
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.White);
            OpenChildForm(new Empleados());
        }
    }
}

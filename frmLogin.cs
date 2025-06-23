using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuegoJIAv2
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "admin" && txtPassword.Text == "admin1234")
            {
                FormBienvenida formBienvenida = new FormBienvenida();
                formBienvenida.Show();
            }
            else
            {
                MsgBoxResult msgBoxResult = Interaction.MsgBox("Usuario o contraseña incorrectos", MsgBoxStyle.Critical, "Error de inicio de sesión");
            }
        }
    }
}

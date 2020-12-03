using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio.Models;
using Dominio.ValueObjects;
using presentacion.Forms;

namespace presentacion.Forms
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        private UsuarioModel Usuario = new UsuarioModel();


        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "" && txtPass.Text != "")
            {
                var exi = Usuario.buscarUsuario();
                DataRow[] user = exi.Select("username = '" + txtUsuario.Text + "'");
                DataRow[] pass = exi.Select("pass = '" + txtPass.Text + "'");

                if (user.Length != 0 && pass.Length !=0) {

                    FormControl formControl = new FormControl();
                    formControl.Show();

                    this.Hide();


                }
                else
                {
                    MessageBox.Show("Credenciales incorrectas\n Verifique que el usuario y/o la contraseña sean correctos\nRespete las mayusculas y minusculas, numeros, letas y/o simbolos", "Credenciales incorrectas!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Los campos no pueden estar vacios", "Datos faltantes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("¿Está seguro que desea salir de la aplicación?", "Está saliendo de la aplicación!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (DialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Gracias por usar mi aplicación\nMatricula: 2018-6663\nNombre: Maxwell Tavares", "Creditos", MessageBoxButtons.OK, MessageBoxIcon.Question);
                Application.Exit();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}

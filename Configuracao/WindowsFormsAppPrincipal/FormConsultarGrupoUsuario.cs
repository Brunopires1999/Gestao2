using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppPrincipal
  
{
  
    public partial class FormConsultarGrupoUsuario : Form
    {
        public int Id;
        public FormConsultarGrupoUsuario()
        {
            InitializeComponent();
        }

        private void nomeGrupoTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void grupoUsuarioDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonbuscar_Click(object sender, EventArgs e)
        {
             try
            {
                GrupoUsuarioBLL grupousuarioBLL = new GrupoUsuarioBLL();
                grupoUsuarioBindingSource.DataSource = grupousuarioBLL.Buscar(textBoxBuscar.Text);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void buttonselecionar_Click(object sender, EventArgs e)
        {
            if (grupoUsuarioBindingSource.Count > 0)
            {
                Id = ((GrupoUsuario)grupoUsuarioBindingSource.Current).Id;
                Close();
            }
            else
                MessageBox.Show("Não existe um grupo de usuário para ser selecionado.");
        }

        private void buttoncancelar_Click(object sender, EventArgs e)
        {

        }
    }
}

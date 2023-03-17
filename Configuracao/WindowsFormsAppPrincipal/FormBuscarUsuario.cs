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
    public partial class FormBuscarUsuario : Form
    {
        public FormBuscarUsuario()
        {
            InitializeComponent();
        }

        private void FormBuscarUsuario_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            UsuarioBLL usuarioBLL = new UsuarioBLL();
            usuarioBindingSource.DataSource = usuarioBLL.BuscarTodos();
        }

        private void buttonAdicionarUsuario_Click(object sender, EventArgs e)
        {
            using(CadastroUsuario frm = new CadastroUsuario())
            {
                frm.ShowDialog();
            }
        }

        private void buttonExcluirUsuario_Click(object sender, EventArgs e)
        {
            if(usuarioBindingSource.Count > 0)
            {
                MessageBox.Show("Não existe registro para ser excluido!");
            }
            if (MessageBox.Show("Deseja realmente excluir este registro?", "Atenção", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            int id = ((Usuario)usuarioBindingSource.Current).Id;
            new UsuarioBLL().Excluir(id);

        }
    }
}

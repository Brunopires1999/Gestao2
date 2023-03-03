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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void buttonTeste_Click(object sender, EventArgs e)
        {
            MessageBox.Show("“Conhece-te a ti mesmo e conhecerá o universo e os deuses” - Essa frase não é de Sócrates. Ela estava entalhada no pórtico do templo dedicado ao deus Apolo, e Sócrates tomou-a como lema " +
                "para a sua vida e sua filosofia. “Só sei que nada sei.” “Não penses mal dos que procedem mal, pense que estão equivocados.”");

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HolaMundo
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TextBox1.Text)){

                labelTexto.Text = "Hola, " + TextBox1.Text;
                TextBox1.Text = "";
                labelError.Text = "";
            }
            else
            {
                labelError.Text = "Nombre no ponido";
            }
        }

        
    }
}
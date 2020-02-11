using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MovieLibrary.Business;

namespace MovieLibrary.Winforms
{
    public partial class MovieForm : Form
    {
        public MovieForm ()
        {
            InitializeComponent();
        }

        private void Label3_Click ( object sender, EventArgs e )
        {

        }

        public Movie movie;

        private void OnCancel ( object sender, EventArgs e )
        {
            //todo validation and error reporting
            DialogResult=DialogResult.Cancel;
            Close();
        }

        private void OnOk ( object sender, EventArgs e )
        {
            //todo validation and error reporting
            DialogResult=DialogResult.OK;
            Close();
        }

    }
}

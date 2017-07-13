using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basic
{
    public partial class Configuration : Form
    {
        Font _font;
        FontDialog _fontDialog;
        public Configuration()
        {
            InitializeComponent();
            _fontDialog = new FontDialog();
        }

        private void FontButton_Click(object sender, EventArgs e)
        {
            DialogResult result = _fontDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                _font = _fontDialog.Font;
                Font = _font;
            }
        }
    }
}

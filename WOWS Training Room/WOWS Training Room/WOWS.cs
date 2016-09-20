using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WOWS_Training_Room
{
    public partial class WOWS : Form
    {

        private string gamePath = "";

        public WOWS()
        {
            // Load our saved data from Documents
            

            InitializeComponent();
        }

        // Get gamePath from saved text or from test box
        private void getGamePath()
        {
            gamePath = this.pathBox.Text;
        }

        private void trainingRoom_Click(object sender, EventArgs e)
        {
            // Get the path of game directory
            

        }

        private void replayMode_Click(object sender, EventArgs e)
        {
            // Get the path of game directory

        }
    }
}

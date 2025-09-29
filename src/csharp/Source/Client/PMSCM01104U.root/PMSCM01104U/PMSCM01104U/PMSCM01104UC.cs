using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    public partial class PMSCM01104UC : Form
    {
        private Rectangle RectScreen;
        public PMSCM01104UC()
        {
            InitializeComponent();
        }

        private void PMSCM01104UC_Load(object sender, EventArgs e)
        {


            RectScreen = Screen.PrimaryScreen.Bounds;

            Point xy = new Point();
            xy.X = (RectScreen.Width / 2) - 173;
            xy.Y = (RectScreen.Height / 2) - 57;
            this.Location = xy;


        }

        private void PMSCM01104UC_Shown(object sender, EventArgs e)
        {
            this.Activate();
        }
    }
}
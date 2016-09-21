using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgGateway.ADAPT.Visualizer.UI
{
    public partial class BusyForm : Form
    {
        public BusyForm()
        {
            InitializeComponent();
        }

        public void UpdateLabel(string text)
        {
            label1.Text = text;
        }

        private void BusyForm_Load(object sender, EventArgs e)
        {
            if (Owner != null)
                Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2,
                    Owner.Location.Y + Owner.Height / 2 - Height / 2);
        }
    }
}

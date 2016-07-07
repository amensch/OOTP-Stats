using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOTP_Stats
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            var import = new GoogleSheetsData();

            var batters = import.LoadBatters();
            var pitchers = import.LoadPitchers();

        }
    }
}

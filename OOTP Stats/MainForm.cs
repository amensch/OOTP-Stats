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
        private Stats _stats;

        public MainForm()
        {
            InitializeComponent();

            GoogleSheetsData data = new GoogleSheetsData();
            _stats = new Stats(data);
        }
    }
}

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

            // set event handlers
            tsbBatters.CheckedChanged += CheckedChangedFormat;
            tsbPitchers.CheckedChanged += CheckedChangedFormat;
            tsbCareer.CheckedChanged += CheckedChangedFormat;
            tsbYearByYear.CheckedChanged += CheckedChangedFormat;
            tsbSingleSeason.CheckedChanged += CheckedChangedFormat;

            dgView.ColumnHeaderMouseClick += DgView_ColumnHeaderMouseClick;

            GoogleSheetsData data = new GoogleSheetsData();
            _stats = new Stats(data);
        }

        private void DgView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if( tsbBatters.Checked )
                dgView.DataSource = _stats.Batters.GetBattingList(dgView.Columns[e.ColumnIndex].Name);
            else
                dgView.DataSource = _stats.Pitchers.GetPitchersList(dgView.Columns[e.ColumnIndex].Name);
        }

        private void CheckedChangedFormat(object sender, EventArgs e)
        {
            ToolStripButton btn = (ToolStripButton)sender;
            if( btn.Checked )
            {
                btn.Font = new Font(btn.Font, FontStyle.Bold);
            }
            else
            {
                btn.Font = new Font(btn.Font, FontStyle.Regular);
            }
        }

        private void tsbBatters_Click(object sender, EventArgs e)
        {
            dgView.DataSource = _stats.Batters.GetBattingList();

            // reorder columns
            dgView.Columns["Year"].DisplayIndex = 0;
            dgView.Columns["FullName"].DisplayIndex = 1;

            // format decimal columns
            dgView.Columns["AVG"].DefaultCellStyle.Format = "F3";
            dgView.Columns["SLG"].DefaultCellStyle.Format = "F3";

            // resize columns to fit
            dgView.AutoResizeColumns();

            // determine buttons
            tsbBatters.Checked = true;
            tsbPitchers.Checked = false;
        }

        private void tsbPitchers_Click(object sender, EventArgs e)
        {
            dgView.DataSource = _stats.Pitchers.GetPitchersList();
            dgView.Columns["Year"].DisplayIndex = 0;
            dgView.Columns["FullName"].DisplayIndex = 1;

            // format decimal columns
            dgView.Columns["ERA"].DefaultCellStyle.Format = "F2";
            dgView.Columns["WHIP"].DefaultCellStyle.Format = "F2";

            // resize columns to fit
            dgView.AutoResizeColumns();

            // button state
            tsbBatters.Checked = false;
            tsbPitchers.Checked = true;
        }
    }
}

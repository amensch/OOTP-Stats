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

            tsbSingleSeason.Checked = true;
        }

        private void DgView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RefreshGrid(dgView.Columns[e.ColumnIndex].Name);
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
            tsbBatters.Checked = true;
            tsbPitchers.Checked = false;

            RefreshGrid();
        }

        private void tsbPitchers_Click(object sender, EventArgs e)
        {
            tsbBatters.Checked = false;
            tsbPitchers.Checked = true;

            RefreshGrid();
        }

        private void tsbSingleSeason_Click(object sender, EventArgs e)
        {
            tsbSingleSeason.Checked = true;
            tsbCareer.Checked = false;
            tsbYearByYear.Checked = false;
            tsbTeam.Checked = false;

            RefreshGrid();
        }

        private void tsbCareer_Click(object sender, EventArgs e)
        {
            tsbSingleSeason.Checked = false;
            tsbCareer.Checked = true;
            tsbYearByYear.Checked = false;
            tsbTeam.Checked = false;

            RefreshGrid();
        }

        private void tsbYearByYear_Click(object sender, EventArgs e)
        {
            tsbSingleSeason.Checked = false;
            tsbCareer.Checked = false;
            tsbYearByYear.Checked = true;
            tsbTeam.Checked = false;

            RefreshGrid();
        }

        private void tsbTeam_Click(object sender, EventArgs e)
        {
            tsbSingleSeason.Checked = false;
            tsbCareer.Checked = false;
            tsbYearByYear.Checked = false;
            tsbTeam.Checked = true;

            RefreshGrid();
        }

        private void RefreshGrid()
        {
            RefreshGrid("Year");
        }

        private void RefreshGrid(string sortColumnName)
        {
            bool newsource = false;
            if (tsbBatters.Checked)
            {
                if (tsbSingleSeason.Checked)
                {
                    dgView.DataSource = _stats.Batters.GetBattingList(sortColumnName);

                    // hide columns
                    dgView.Columns["Years"].Visible = false;

                    newsource = true;
                }
                else if (tsbCareer.Checked)
                {
                    dgView.DataSource = _stats.Batters.GetCareerList(sortColumnName);

                    // show columns
                    dgView.Columns["Years"].Visible = true;

                    newsource = true;
                }
                else if (tsbYearByYear.Checked)
                {
                    _stats.Batters.YearByYear("PA");
                    // TODO
                }
                else if( tsbTeam.Checked)
                {
                    dgView.DataSource = _stats.Batters.GetTeamList(sortColumnName);
                    newsource = true;
                }

                if (newsource)
                {
                    // reorder columns
                    dgView.Columns["Year"].DisplayIndex = 0;
                    dgView.Columns["FullName"].DisplayIndex = 1;
                    dgView.Columns["Years"].DisplayIndex = 2;

                    // format decimal columns
                    dgView.Columns["AVG"].DefaultCellStyle.Format = "F3";
                    dgView.Columns["SLG"].DefaultCellStyle.Format = "F3";
                    dgView.Columns["ABperHR"].DefaultCellStyle.Format = "F1";

                    // hide columns
                    dgView.Columns["FirstName"].Visible = false;
                    dgView.Columns["LastName"].Visible = false;
                    dgView.Columns["FirstYear"].Visible = false;
                    dgView.Columns["LastYear"].Visible = false;

                    // resize columns to fit
                    dgView.AutoResizeColumns();
                }
            }
            else if (tsbPitchers.Checked)
            {
                if (tsbSingleSeason.Checked)
                {
                    dgView.DataSource = _stats.Pitchers.GetPitchersList(sortColumnName);

                    // hide columns
                    dgView.Columns["Years"].Visible = false;

                    newsource = true;
                }
                else if (tsbCareer.Checked)
                {
                    dgView.DataSource = _stats.Pitchers.GetCareerList(sortColumnName);

                    // hide columns
                    dgView.Columns["Years"].Visible = true;

                    newsource = true;
                }
                else if (tsbYearByYear.Checked)
                {
                    // TODO
                }
                else if (tsbTeam.Checked)
                {
                    dgView.DataSource = _stats.Pitchers.GetTeamList(sortColumnName);
                    newsource = true;
                }

                if (newsource)
                {
                    dgView.Columns["Year"].DisplayIndex = 0;
                    dgView.Columns["FullName"].DisplayIndex = 1;
                    dgView.Columns["Years"].DisplayIndex = 2;

                    // format decimal columns
                    dgView.Columns["ERA"].DefaultCellStyle.Format = "F2";
                    dgView.Columns["WHIP"].DefaultCellStyle.Format = "F2";
                    dgView.Columns["Kper9"].DefaultCellStyle.Format = "F1";
                    dgView.Columns["BBper9"].DefaultCellStyle.Format = "F1";

                    // hide columns
                    dgView.Columns["FirstName"].Visible = false;
                    dgView.Columns["LastName"].Visible = false;
                    dgView.Columns["FirstYear"].Visible = false;
                    dgView.Columns["LastYear"].Visible = false;
                    dgView.Columns["Outs"].Visible = false;

                    // resize columns to fit
                    dgView.AutoResizeColumns();
                }
            }
        }

    }
}

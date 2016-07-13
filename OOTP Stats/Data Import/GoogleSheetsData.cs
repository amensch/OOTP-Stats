using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
namespace OOTP_Stats
{
    public class GoogleSheetsData : IDataStore, IDisposable
    {
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/sheets.googleapis.com-dotnet-quickstart.json
        static string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        static string ApplicationName = "MLBM Client";

        private string spreadsheetId = "1Gvhz4RLGTe7TBkC6-zJnqcUo_D6Crd16N8CBUGozuJU";
        private SheetsService service;

        List<string> hallList;

        public GoogleSheetsData()
        {
            Connect();
            LoadHallOfFame();
        }

        private void LoadHallOfFame()
        {
            hallList = new List<string>();
            var data = GetData("Hall of Fame!B1:B300");
            string name;

            foreach( var row in data )
            {
                if( row.Count > 0 && ConvertToString(row, 0) != string.Empty )
                {
                    name = ConvertToString(row, 0);
                    if( name != "Batters" && name != "Pitchers" && name != "Name")
                    {
                        hallList.Add(name);
                    }
                }
            }
        }

        public List<BattingYear> LoadBatters()
        {
            var data = GetData("Raw Hitting Data!A2:Q");
            var list = new List<BattingYear>();
            string name;
            bool hall;
            foreach (var row in data)
            {
                if (row.Count > 0 && ConvertToString(row, BattingYear.BattingYearIndex.Year) != string.Empty)
                {

                    name = ConvertToString(row, BattingYear.BattingYearIndex.FirstName) + " " + ConvertToString(row, BattingYear.BattingYearIndex.LastName);
                    hall = hallList.Contains(name);
                    var batter = new BattingYear(
                        ConvertToString(row, BattingYear.BattingYearIndex.FirstName),
                        ConvertToString(row, BattingYear.BattingYearIndex.LastName),
                        ConvertToInt(row, BattingYear.BattingYearIndex.Year),
                        hall
                        );

                    batter.AB = ConvertToInt(row, BattingYear.BattingYearIndex.AB);
                    batter.Hits = ConvertToInt(row, BattingYear.BattingYearIndex.H);
                    batter.HR = ConvertToInt(row, BattingYear.BattingYearIndex.HR);
                    batter.RBI = ConvertToInt(row, BattingYear.BattingYearIndex.RBI);
                    batter.K = ConvertToInt(row, BattingYear.BattingYearIndex.K);
                    batter.BB = ConvertToInt(row, BattingYear.BattingYearIndex.BB);
                    batter.Games = ConvertToInt(row, BattingYear.BattingYearIndex.G);
                    batter.XBH = ConvertToInt(row, BattingYear.BattingYearIndex.XBH);
                    batter.SB = ConvertToInt(row, BattingYear.BattingYearIndex.SB);
                    batter.PA = ConvertToInt(row, BattingYear.BattingYearIndex.PA);
                    batter.TB = ConvertToInt(row, BattingYear.BattingYearIndex.TB);

                    list.Add(batter);
                }
            }

            return list;
        }

        public List<PitchingYear> LoadPitchers()
        {
            var data = GetData("Raw Pitching Data!A2:P");
            var list = new List<PitchingYear>();
            string name;
            bool hall;
            foreach (var row in data)
            {
                if (row.Count > 0 && ConvertToString(row, PitchingYear.PitchingYearIndex.Year) != string.Empty)
                {

                    name = ConvertToString(row, PitchingYear.PitchingYearIndex.FirstName) + " " + ConvertToString(row, PitchingYear.PitchingYearIndex.LastName);
                    hall = hallList.Contains(name);
                    var pitcher = new PitchingYear(
                        ConvertToString(row, PitchingYear.PitchingYearIndex.FirstName),
                        ConvertToString(row, PitchingYear.PitchingYearIndex.LastName),
                        ConvertToInt(row, PitchingYear.PitchingYearIndex.Year),
                        hall
                        );

                    pitcher.BB = ConvertToInt(row, PitchingYear.PitchingYearIndex.BB);
                    pitcher.ER = ConvertToInt(row, PitchingYear.PitchingYearIndex.ER);
                    pitcher.Games = ConvertToInt(row, PitchingYear.PitchingYearIndex.G);
                    pitcher.GS = ConvertToInt(row, PitchingYear.PitchingYearIndex.GS);
                    pitcher.Hits = ConvertToInt(row, PitchingYear.PitchingYearIndex.H);
                    pitcher.HR = ConvertToInt(row, PitchingYear.PitchingYearIndex.HR);
                    pitcher.K = ConvertToInt(row, PitchingYear.PitchingYearIndex.K);
                    pitcher.Loss = ConvertToInt(row, PitchingYear.PitchingYearIndex.Loss);
                    pitcher.Outs = ConvertIPToOuts(row);
                    pitcher.Saves = ConvertToInt(row, PitchingYear.PitchingYearIndex.Save);
                    pitcher.Wins = ConvertToInt(row, PitchingYear.PitchingYearIndex.Win);

                    list.Add(pitcher);
                }
            }

            return list;
        }

        private void Connect()
        {
            UserCredential credential;

            using (var stream =
                new FileStream("client_id.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/sheets.googleapis.com-ootp-stats.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "adam@menschwi.com",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
        }

        private IList<IList<object>> GetData(string range)
        {
            var request = service.Spreadsheets.Values.Get(spreadsheetId, range);

            var response = request.Execute();
            return response.Values;
        }

        /*
The values collection does not go outside of the desired range.
Columns within a row are accessed via a numeric index.

        foreach (var row in values )
        {
            txtList.Text += Environment.NewLine;
            foreach (var item in row )
            {
                txtList.Text += item.ToString() + ",";
            }
        }
*/

        private int ConvertToInt(IList<object> row, BattingYear.BattingYearIndex index)
        {
            int value = 0;
            int.TryParse(row[(int)index].ToString(), out value);
            return value;
        }

        private int ConvertToInt(IList<object> row, PitchingYear.PitchingYearIndex index)
        {
            int value = 0;
            int.TryParse(row[(int)index].ToString(), out value);
            return value;
        }

        private string ConvertToString(IList<object> row, int index)
        {
            return row[(int)index].ToString();
        }

        private string ConvertToString(IList<object> row, BattingYear.BattingYearIndex index)
        {
            return row[(int)index].ToString();
        }

        private string ConvertToString(IList<object> row, PitchingYear.PitchingYearIndex index)
        {
            return row[(int)index].ToString();
        }

        private int ConvertIPToOuts(IList<object> row)
        {
            int outs = 0;
            string ip = ConvertToString(row, PitchingYear.PitchingYearIndex.IP);

            if (ip.Contains(".0"))
            {
                ip = ip.Replace(".0", "");
            }
            else if ( ip.Contains(".1"))
            {
                outs += 1;
                ip = ip.Replace(".1", "");
            }
            else if (ip.Contains(".2"))
            {
                outs += 2;
                ip = ip.Replace(".2", "");
            }
            else if (ip.Contains(".3"))
            {
                outs += 1;
                ip = ip.Replace(".3", "");
            }
            else if (ip.Contains(".6"))
            {
                outs += 2;
                ip = ip.Replace(".6", "");
            }
            else if (ip.Contains(".7"))
            {
                outs += 2;
                ip = ip.Replace(".7", "");
            }

            int ip_int = 0;
            int.TryParse(ip, out ip_int);

            return (ip_int * 3) + outs;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    service.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~GoogleSheetsData() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}

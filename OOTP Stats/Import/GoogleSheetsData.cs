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
    public class GoogleSheetsData : IBattingData, IPitchingData
    {
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/sheets.googleapis.com-dotnet-quickstart.json
        static string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        static string ApplicationName = "MLBM Client";

        private string spreadsheetId = "1Gvhz4RLGTe7TBkC6-zJnqcUo_D6Crd16N8CBUGozuJU";
        private SheetsService service;

        public GoogleSheetsData()
        {
            Connect();
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

        public IList<IList<object>> GetData(string range)
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

        public List<BattingYear> LoadBatters()
        {
            var data = GetData("Raw Hitting Data!A1:Q");

        }

        public List<PitchingYear> LoadPitchers()
        {
            throw new NotImplementedException();
        }



    }
}

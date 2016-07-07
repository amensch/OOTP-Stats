# OOTP-Stats
Windows client for displaying stats for OOTP 2014 from a Google Sheets doc.

Windows client for displaying stats from a Google Sheets doc.

To use in Visual Studio:

Step 1: Turn on the Google Sheets API

Use this wizard to create or select a project in the Google Developers Console and automatically turn on the API. Click Continue, then Go to credentials. At the top of the page, select the OAuth consent screen tab. Select an Email address, enter a Product name if not already set, and click the Save button. Select the Credentials tab, click the Create credentials button and select OAuth client ID. Select the application type Other, enter the name "Google Sheets API Quickstart", and click the Create button. Click OK to dismiss the resulting dialog. Click the file_download (Download JSON) button to the right of the client ID. Move this file to your working directory and rename it client_secret.json.

Step 2: Prepare the project

Create a new Visual C# Console Application project in Visual Studio. Open the NuGet Package Manager Console, select the package source nuget.org, and run the following command: Install-Package Google.Apis.Sheets.v4

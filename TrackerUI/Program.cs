using TrackerLibrary;

namespace TrackerUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Initialize the database/files connections 
            TrackerLibrary.GlobalConfig.InitializeConnections(DatabaseType.Textfile);

            // Starting point for the application
            //Application.Run(new TournamentDashboardForm());
            Application.Run(new CreateTeamForm());
        }
    }
}
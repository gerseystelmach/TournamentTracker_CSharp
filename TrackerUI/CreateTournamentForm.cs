using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreateTournamentForm : Form, IPrizeRequestor, ITeamRequestor
    {

        List<TeamModel> availableTeams = GlobalConfig.Connection.GetTeam_All();
        List<TeamModel> selectedTeams = new List<TeamModel>();
        List<PrizeModel> selectedPrizes = new List<PrizeModel>();

        public CreateTournamentForm()
        {
            InitializeComponent();

            WireUpLists();
        }

        /// <summary>
        /// Adds the data in the lists of the component.
        /// </summary>
        private void WireUpLists()
        {
            selectTeamDropDown.DataSource = null;
            selectTeamDropDown.DataSource = availableTeams;
            // The value has to be the same of the attribute of the model
            selectTeamDropDown.DisplayMember = "TeamName";

            tournamentTeamPlayersListBox.DataSource = null;
            tournamentTeamPlayersListBox.DataSource = selectedTeams;
            tournamentTeamPlayersListBox.DisplayMember = "TeamName";

            prizesListBox.DataSource = null;
            prizesListBox.DataSource = selectedPrizes;
            prizesListBox.DisplayMember = "PlaceName";

        }

        private void addTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel team = (TeamModel) selectTeamDropDown.SelectedItem;

            if (team != null)
            {
                // Taking out from the available list and adding it to the selected list.
                availableTeams.Remove(team);
                selectedTeams.Add(team);

                WireUpLists();
            }
        }

        /// <summary>
        /// Calls the CreatePrize form to create a prize.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            // Call the CreateThePrizeForm and pass the instance of CreateTournamentForm as a param that implements the interface
            createPrizeForm form = new createPrizeForm(this);
            form.Show();

        }

        public void PrizeComplete(PrizeModel model)
        {

            // Get back from the form a PrizeModel
            selectedPrizes.Add(model);
            // Refreshing the lists
            WireUpLists();
            // Take the PrizeModel and put it in our list
        }

        public void TeamComplete(TeamModel model)
        {
            selectedTeams.Add(model);
            WireUpLists();
        }

        private void createNewTeamLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateTeamForm form = new CreateTeamForm(this);
            // Opening the CreateTeamForm
            form.Show();
        }

        private void removeSelectedPlayersButton_Click(object sender, EventArgs e)
        {
            TeamModel team = (TeamModel)tournamentTeamPlayersListBox.SelectedItem;

            if (team != null)
            {
                selectedTeams.Remove(team);
                availableTeams.Add(team);

                WireUpLists();
            }           
        }

        private void removeSelectedPrizeButton_Click(object sender, EventArgs e)
        {
            PrizeModel prize = (PrizeModel) prizesListBox.SelectedItem;

            if (prize != null)
            {
                selectedPrizes.Remove(prize);

                WireUpLists();
            }
        }

        private void createTournamentButton_Click(object sender, EventArgs e)
        {
            // Validating data

            decimal fee = 0;
            // trying to convert it into decimal type,
            // if it successful, it will send the value,
            // if it's not, it will send a false and send the value of 0
            bool feeAcceptable = decimal.TryParse(entryFeeTextBoxValue.Text, out fee);

            if (!feeAcceptable)
            {
                MessageBox.Show("You need to enter a valid Entry Fee.", "Invalid Fee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // stops the process at this point
                return;
            }

            // Create tournament entry

            TournamentModel tournament = new TournamentModel();

            tournament.TournamentName = tournamentNameValue.Text;
            tournament.EntryFee = fee;
            tournament.Prizes = selectedPrizes;
            tournament.EnteredTeams = selectedTeams;

            // TODO - Create matchups rounds
            // ORder our list randomly of teams
            // Check if it is big enough - if not, add in byes - 2 * 2 * 2 * 2 - 2^4
            // Create our first round of matchups
            // Create every round after that

            // This method will be called in accordance to the Connector class (indicated in the Program.cs).
            // It holds any class that implements it. 
            GlobalConfig.Connection.CreateTournament(tournament);

            
        }
    }
}

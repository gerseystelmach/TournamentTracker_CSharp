﻿using System;
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
    public partial class CreateTournamentForm : Form
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
    }
}

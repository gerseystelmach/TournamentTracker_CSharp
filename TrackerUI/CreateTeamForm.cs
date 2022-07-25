﻿using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreateTeamForm : Form
    {

        private List<PersonModel> availableTeamMembers = GlobalConfig.Connection.GetPerson_All();
        private List<PersonModel> selectedTeamMembers = new List<PersonModel>();
        public CreateTeamForm()
        {
            InitializeComponent();

          //  CreateSampleData();

            WireUpLists();
        }

        /// <summary>
        /// Wires up the selectTeamDropdown and the teamMembersListBox with a list of PersonModel.
        /// </summary>
        private void WireUpLists()
        {
            // TODO - Try to find a better way to refresh the datasources.

            // Forcing a refresh of the datasource by setting it null and then giving it a value
            selectTeamDropDown.DataSource = null;

            selectTeamDropDown.DataSource = availableTeamMembers;
            selectTeamDropDown.DisplayMember = "FullName";

            teamMembersListBox.DataSource = null;

            teamMembersListBox.DataSource = selectedTeamMembers;
            teamMembersListBox.DisplayMember = "FullName";

    
        }

        private void CreateSampleData()
        {
            availableTeamMembers.Add(new PersonModel { FirstName = "Gersey", LastName = "Corey" });
            availableTeamMembers.Add(new PersonModel { FirstName = "Sue", LastName = "Corey" });
            selectedTeamMembers.Add(new PersonModel { FirstName = "Pati", LastName = "Corey" });
            selectedTeamMembers.Add(new PersonModel { FirstName = "Lupi", LastName = "Corey" });
        }

        private void createMemberButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm()) {
                PersonModel person = new PersonModel();

                person.FirstName = firstNameValue.Text;
                person.LastName = lastNameValue.Text;
                person.EmailAddress = emailValue.Text;
                person.CellphoneNumber = cellphoneValue.Text;

                GlobalConfig.Connection.CreatePerson(person);

                // Adding the created person into the select listbox
                selectedTeamMembers.Add(person);
                // Refreshing the select team member list
                WireUpLists();
                // Refreshing the form data
                this.cleanFormValues();

            } else
            {
                MessageBox.Show("You need to fill in all of the fields.");
            }

        }

        /// <summary>
        /// It validates the form for the member creation.
        /// </summary>
        /// <returns>True if the form is valid or false if it's not.</returns>
        private bool ValidateForm()
        {
            if (firstNameValue.Text.Length == 0)
            {
                return false;
            }

            if (lastNameValue.Text.Length == 0)
            {
                return false;
            }

            if (emailValue.Text.Length == 0)
            {
                return false;
            }

            if (cellphoneValue.Text.Length == 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// It will assign default values for the Create Member Form. 
        /// </summary>
        public void cleanFormValues()
        {
            firstNameValue.Text = "";
            lastNameValue.Text = "";
            emailValue.Text = "";
            cellphoneValue.Text = "";
        }

        private void addTeamButton_Click(object sender, EventArgs e)
        {

            // Taking the selected item from select team dropdown
            PersonModel person = (PersonModel) selectTeamDropDown.SelectedItem ;

            if (person != null)
            {
                // Removing from available members
                availableTeamMembers.Remove(person);
                // Adding to selected members
                selectedTeamMembers.Add(person);

                WireUpLists();
            }
        }

        /// <summary>
        /// As from a click event, it will remove a Person from the selected team members dropdown and adds it to the available team members select list. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeSelectedMemberButton_Click(object sender, EventArgs e)
        {
            // Taking the selected item from selected team dropdown
            PersonModel person = (PersonModel)teamMembersListBox.SelectedItem;

            if (person != null)
            {
                selectedTeamMembers.Remove(person);
                availableTeamMembers.Add(person);

                WireUpLists();
            }

        }

        private void createTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel teamModel = new TeamModel();

            teamModel.TeamName = teamNameValue.Text;
            teamModel.TeamMembers = selectedTeamMembers;

            GlobalConfig.Connection.CreateTeam(teamModel);

            // TODO - If we aren't closing this form after creation, reset the form
        }
    }
}

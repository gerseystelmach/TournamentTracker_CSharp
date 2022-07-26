namespace TrackerUI
{
    partial class CreateTournamentForm
    {
        /// <summary>
        ///  Create Tournament form.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateTournamentForm));
            this.tournamentLabel = new System.Windows.Forms.Label();
            this.tournamentNameValue = new System.Windows.Forms.TextBox();
            this.tournamentNameLabel = new System.Windows.Forms.Label();
            this.entryFeeValue = new System.Windows.Forms.Label();
            this.entryFeeTextBoxValue = new System.Windows.Forms.TextBox();
            this.selectTeamDropDown = new System.Windows.Forms.ComboBox();
            this.selectTeamLabel = new System.Windows.Forms.Label();
            this.createNewTeamLink = new System.Windows.Forms.LinkLabel();
            this.addTeamButton = new System.Windows.Forms.Button();
            this.createPrizeButton = new System.Windows.Forms.Button();
            this.tournamentPlayersListBoxValue = new System.Windows.Forms.ListBox();
            this.tournamentPlayersLabel = new System.Windows.Forms.Label();
            this.deleteSelectedPlayersButton = new System.Windows.Forms.Button();
            this.prizesLabel = new System.Windows.Forms.Label();
            this.prizesListBoxValue = new System.Windows.Forms.ListBox();
            this.deleteSelectedPrizeButton = new System.Windows.Forms.Button();
            this.createTournamentButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tournamentLabel
            // 
            this.tournamentLabel.AutoSize = true;
            this.tournamentLabel.BackColor = System.Drawing.SystemColors.Window;
            this.tournamentLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tournamentLabel.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.tournamentLabel.Location = new System.Drawing.Point(53, 38);
            this.tournamentLabel.Margin = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.tournamentLabel.Name = "tournamentLabel";
            this.tournamentLabel.Size = new System.Drawing.Size(400, 59);
            this.tournamentLabel.TabIndex = 1;
            this.tournamentLabel.Text = "Create Tournament";
           
            // 
            // tournamentNameValue
            // 
            this.tournamentNameValue.Location = new System.Drawing.Point(53, 209);
            this.tournamentNameValue.Name = "tournamentNameValue";
            this.tournamentNameValue.Size = new System.Drawing.Size(388, 34);
            this.tournamentNameValue.TabIndex = 11;
            // 
            // tournamentNameLabel
            // 
            this.tournamentNameLabel.AutoSize = true;
            this.tournamentNameLabel.BackColor = System.Drawing.SystemColors.Window;
            this.tournamentNameLabel.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tournamentNameLabel.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.tournamentNameLabel.Location = new System.Drawing.Point(53, 142);
            this.tournamentNameLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.tournamentNameLabel.Name = "tournamentNameLabel";
            this.tournamentNameLabel.Size = new System.Drawing.Size(326, 50);
            this.tournamentNameLabel.TabIndex = 10;
            this.tournamentNameLabel.Text = "Tournament Name";
            // 
            // entryFeeValue
            // 
            this.entryFeeValue.AutoSize = true;
            this.entryFeeValue.BackColor = System.Drawing.SystemColors.Window;
            this.entryFeeValue.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.entryFeeValue.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.entryFeeValue.Location = new System.Drawing.Point(53, 295);
            this.entryFeeValue.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.entryFeeValue.Name = "entryFeeValue";
            this.entryFeeValue.Size = new System.Drawing.Size(172, 50);
            this.entryFeeValue.TabIndex = 12;
            this.entryFeeValue.Text = "Entry Fee";
            // 
            // entryFeeTextBoxValue
            // 
            this.entryFeeTextBoxValue.Location = new System.Drawing.Point(259, 309);
            this.entryFeeTextBoxValue.Name = "entryFeeTextBoxValue";
            this.entryFeeTextBoxValue.Size = new System.Drawing.Size(120, 34);
            this.entryFeeTextBoxValue.TabIndex = 13;
            this.entryFeeTextBoxValue.Text = "0";
            // 
            // selectTeamDropDown
            // 
            this.selectTeamDropDown.FormattingEnabled = true;
            this.selectTeamDropDown.Location = new System.Drawing.Point(53, 463);
            this.selectTeamDropDown.Margin = new System.Windows.Forms.Padding(8);
            this.selectTeamDropDown.Name = "selectTeamDropDown";
            this.selectTeamDropDown.Size = new System.Drawing.Size(388, 36);
            this.selectTeamDropDown.TabIndex = 15;
            // 
            // selectTeamLabel
            // 
            this.selectTeamLabel.AutoSize = true;
            this.selectTeamLabel.BackColor = System.Drawing.SystemColors.Window;
            this.selectTeamLabel.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.selectTeamLabel.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.selectTeamLabel.Location = new System.Drawing.Point(53, 395);
            this.selectTeamLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.selectTeamLabel.Name = "selectTeamLabel";
            this.selectTeamLabel.Size = new System.Drawing.Size(214, 50);
            this.selectTeamLabel.TabIndex = 14;
            this.selectTeamLabel.Text = "Select Team";
            // 
            // createNewTeamLink
            // 
            this.createNewTeamLink.AutoSize = true;
            this.createNewTeamLink.Location = new System.Drawing.Point(291, 412);
            this.createNewTeamLink.Name = "createNewTeamLink";
            this.createNewTeamLink.Size = new System.Drawing.Size(162, 28);
            this.createNewTeamLink.TabIndex = 16;
            this.createNewTeamLink.TabStop = true;
            this.createNewTeamLink.Text = "Create New Team";
            // 
            // addTeamButton
            // 
            this.addTeamButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.addTeamButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.addTeamButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addTeamButton.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addTeamButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.addTeamButton.Location = new System.Drawing.Point(146, 529);
            this.addTeamButton.Name = "addTeamButton";
            this.addTeamButton.Size = new System.Drawing.Size(206, 49);
            this.addTeamButton.TabIndex = 17;
            this.addTeamButton.Text = "Add Team";
            this.addTeamButton.UseVisualStyleBackColor = false;
            // 
            // createPrizeButton
            // 
            this.createPrizeButton.BackColor = System.Drawing.Color.Green;
            this.createPrizeButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.createPrizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createPrizeButton.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.createPrizeButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.createPrizeButton.Location = new System.Drawing.Point(146, 605);
            this.createPrizeButton.Name = "createPrizeButton";
            this.createPrizeButton.Size = new System.Drawing.Size(206, 49);
            this.createPrizeButton.TabIndex = 18;
            this.createPrizeButton.Text = "Create Prize";
            this.createPrizeButton.UseVisualStyleBackColor = false;
            // 
            // tournamentPlayersListBoxValue
            // 
            this.tournamentPlayersListBoxValue.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tournamentPlayersListBoxValue.FormattingEnabled = true;
            this.tournamentPlayersListBoxValue.ItemHeight = 45;
            this.tournamentPlayersListBoxValue.Location = new System.Drawing.Point(519, 216);
            this.tournamentPlayersListBoxValue.Name = "tournamentPlayersListBoxValue";
            this.tournamentPlayersListBoxValue.Size = new System.Drawing.Size(462, 229);
            this.tournamentPlayersListBoxValue.TabIndex = 19;
            // 
            // tournamentPlayersLabel
            // 
            this.tournamentPlayersLabel.AutoSize = true;
            this.tournamentPlayersLabel.BackColor = System.Drawing.SystemColors.Window;
            this.tournamentPlayersLabel.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tournamentPlayersLabel.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.tournamentPlayersLabel.Location = new System.Drawing.Point(519, 144);
            this.tournamentPlayersLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.tournamentPlayersLabel.Name = "tournamentPlayersLabel";
            this.tournamentPlayersLabel.Size = new System.Drawing.Size(232, 50);
            this.tournamentPlayersLabel.TabIndex = 20;
            this.tournamentPlayersLabel.Text = "Team Players";
            // 
            // deleteSelectedPlayersButton
            // 
            this.deleteSelectedPlayersButton.BackColor = System.Drawing.Color.Firebrick;
            this.deleteSelectedPlayersButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.deleteSelectedPlayersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteSelectedPlayersButton.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deleteSelectedPlayersButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.deleteSelectedPlayersButton.Location = new System.Drawing.Point(1011, 278);
            this.deleteSelectedPlayersButton.Name = "deleteSelectedPlayersButton";
            this.deleteSelectedPlayersButton.Size = new System.Drawing.Size(175, 90);
            this.deleteSelectedPlayersButton.TabIndex = 21;
            this.deleteSelectedPlayersButton.Text = "Delete Selected";
            this.deleteSelectedPlayersButton.UseVisualStyleBackColor = false;
            // 
            // prizesLabel
            // 
            this.prizesLabel.AutoSize = true;
            this.prizesLabel.BackColor = System.Drawing.SystemColors.Window;
            this.prizesLabel.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.prizesLabel.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.prizesLabel.Location = new System.Drawing.Point(519, 473);
            this.prizesLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.prizesLabel.Name = "prizesLabel";
            this.prizesLabel.Size = new System.Drawing.Size(117, 50);
            this.prizesLabel.TabIndex = 23;
            this.prizesLabel.Text = "Prizes";
            // 
            // prizesListBoxValue
            // 
            this.prizesListBoxValue.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.prizesListBoxValue.FormattingEnabled = true;
            this.prizesListBoxValue.ItemHeight = 45;
            this.prizesListBoxValue.Location = new System.Drawing.Point(519, 545);
            this.prizesListBoxValue.Name = "prizesListBoxValue";
            this.prizesListBoxValue.Size = new System.Drawing.Size(462, 229);
            this.prizesListBoxValue.TabIndex = 22;
            // 
            // deleteSelectedPrizeButton
            // 
            this.deleteSelectedPrizeButton.BackColor = System.Drawing.Color.Brown;
            this.deleteSelectedPrizeButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.deleteSelectedPrizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteSelectedPrizeButton.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deleteSelectedPrizeButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.deleteSelectedPrizeButton.Location = new System.Drawing.Point(1011, 616);
            this.deleteSelectedPrizeButton.Name = "deleteSelectedPrizeButton";
            this.deleteSelectedPrizeButton.Size = new System.Drawing.Size(175, 88);
            this.deleteSelectedPrizeButton.TabIndex = 24;
            this.deleteSelectedPrizeButton.Text = "Delete Selected";
            this.deleteSelectedPrizeButton.UseVisualStyleBackColor = false;
            // 
            // createTournamentButton
            // 
            this.createTournamentButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.createTournamentButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.createTournamentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createTournamentButton.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.createTournamentButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.createTournamentButton.Location = new System.Drawing.Point(390, 821);
            this.createTournamentButton.Name = "createTournamentButton";
            this.createTournamentButton.Size = new System.Drawing.Size(361, 92);
            this.createTournamentButton.TabIndex = 25;
            this.createTournamentButton.Text = "Create Tournament";
            this.createTournamentButton.UseVisualStyleBackColor = false;
            // 
            // CreateTournamentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1225, 954);
            this.Controls.Add(this.createTournamentButton);
            this.Controls.Add(this.deleteSelectedPrizeButton);
            this.Controls.Add(this.prizesLabel);
            this.Controls.Add(this.prizesListBoxValue);
            this.Controls.Add(this.deleteSelectedPlayersButton);
            this.Controls.Add(this.tournamentPlayersLabel);
            this.Controls.Add(this.tournamentPlayersListBoxValue);
            this.Controls.Add(this.createPrizeButton);
            this.Controls.Add(this.addTeamButton);
            this.Controls.Add(this.createNewTeamLink);
            this.Controls.Add(this.selectTeamDropDown);
            this.Controls.Add(this.selectTeamLabel);
            this.Controls.Add(this.entryFeeTextBoxValue);
            this.Controls.Add(this.entryFeeValue);
            this.Controls.Add(this.tournamentNameValue);
            this.Controls.Add(this.tournamentNameLabel);
            this.Controls.Add(this.tournamentLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CreateTournamentForm";
            this.Text = "Create Tournament";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label tournamentLabel;
        private TextBox tournamentNameValue;
        private Label tournamentNameLabel;
        private Label entryFeeValue;
        private TextBox entryFeeTextBoxValue;
        private ComboBox selectTeamDropDown;
        private Label selectTeamLabel;
        private LinkLabel createNewTeamLink;
        private Button addTeamButton;
        private Button createPrizeButton;
        private ListBox tournamentPlayersListBoxValue;
        private Label tournamentPlayersLabel;
        private Button deleteSelectedPlayersButton;
        private Label prizesLabel;
        private ListBox prizesListBoxValue;
        private Button deleteSelectedPrizeButton;
        private Button createTournamentButton;
    }
}
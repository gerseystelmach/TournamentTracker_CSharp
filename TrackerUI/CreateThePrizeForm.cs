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
using TrackerLibrary.DataAccess;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class createPrizeForm : Form
    {
        public createPrizeForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// After a click event in the button to create prize, it will validate the form and if everything is as expected it will insert the prize into database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PrizeModel model = new PrizeModel(
                    placeNameValue.Text, 
                    placeNumberValue.Text, 
                    prizeAmountValue.Text, 
                    prizePercentageValue.Text);

                foreach (IDataConnection db in GlobalConfig.Connections)
                {
                    db.CreatePrize(model);
                }

                // Returning the form to default values if everything goes fine with the prize saving. 
                this.cleanFormValues();
            } else
            {
                MessageBox.Show("This form has invalid information. Pleach check it and try again.");
            }
        }

        private bool ValidateForm()
        {
            bool output = true;
            int placeNumber = 0;
            // Trying to convert the string into int and
            // storing it to the variable placeNumber;
            bool placeNumberValidNumber = int.TryParse(placeNumberValue.Text, out placeNumber);

            if (!placeNumberValidNumber)
            {
                output = false;
            }

            if (placeNumber < 1)
            {
                output = false;
            }

            if (placeNameValue.Text.Length == 0)
            {
                output = false;
            }

            decimal prizeAmount = 0;
            double prizePercentage = 0;

            bool prizeAmountValid = decimal.TryParse(prizeAmountValue.Text, out prizeAmount);
            bool prizePercentageValid = double.TryParse(prizePercentageValue.Text, out prizePercentage);

            if (!prizeAmountValid || !prizePercentageValid)
            {
                output = false;
            }

            if (prizeAmount <=0 && prizePercentage <= 0)
            {
                output = false;
            }

            if (prizePercentage < 0 || prizePercentage > 100)
            {
                output = false; 
            } 

            return output;
        }

        /// <summary>
        /// It will assign default values for the CreatePrize Form. 
        /// </summary>
        public void cleanFormValues()
        {
            placeNameValue.Text = "";
            placeNumberValue.Text = "";
            prizeAmountValue.Text = "0";
            prizePercentageValue.Text = "0";
        }

        private void prizeNumberValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void prizeNumberLabel_Click(object sender, EventArgs e)
        {

        }

        private void prizePercentageValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void prizeAmountValue_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

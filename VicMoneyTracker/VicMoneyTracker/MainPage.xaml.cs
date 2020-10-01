using System;
using Xamarin.Forms;

namespace VicMoneyTracker
{
    /// <summary>
    /// Controller for Victorian Money Tracker App
    /// </summary>
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// Variable to hold an instance of the data model (Money class)
        /// </summary>
        private Money moneyTracker;

        /// <summary>
        /// Constructor
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            moneyTracker = new Money();
            UpdateUI();
        }

        /// <summary>
        /// Updates the user interface based on the current state of the data model
        /// </summary>
        public void UpdateUI()
        {
            // Update labels

            totalAmountLabel.Text = moneyTracker.ToString();

            poundsAmountLabel.Text = moneyTracker.pounds.ToString();
            crownsAmountLabel.Text = moneyTracker.crowns.ToString();
            shillingsAmountLabel.Text = moneyTracker.shillings.ToString();
            penceAmountLabel.Text = moneyTracker.pence.ToString();
            farthingsAmountLabel.Text = moneyTracker.farthings.ToString();

            poundsTextLabel.Text = moneyTracker.poundsLabel;
            crownsTextLabel.Text = moneyTracker.crownsLabel;
            shillingsTextLabel.Text = moneyTracker.shillingsLabel;
            penceTextLabel.Text = moneyTracker.penceLabel;
            farthingsTextLabel.Text = moneyTracker.farthingsLabel;

            // Update visibility of images

            ConvertPoundsDownImage.IsVisible = moneyTracker.canConvertPoundsToCrowns;
            ConvertPoundsDownDisabledImage.IsVisible = !moneyTracker.canConvertPoundsToCrowns;
            ConvertCrownsDownImage.IsVisible = moneyTracker.canConvertCrownsToShillings;
            ConvertCrownsDownDisabledImage.IsVisible = !moneyTracker.canConvertCrownsToShillings;
            ConvertShillingsDownImage.IsVisible = moneyTracker.canConvertShillingsToPence;
            ConvertShillingsDownDisabledImage.IsVisible = !moneyTracker.canConvertShillingsToPence;
            ConvertPenceDownImage.IsVisible = moneyTracker.canConvertPenceToFarthings;
            ConvertPenceDownDisabledImage.IsVisible = !moneyTracker.canConvertPenceToFarthings;

            ConvertCrownsUpImage.IsVisible = moneyTracker.canConvertCrownsToPounds;
            ConvertCrownsUpDisabledImage.IsVisible = !moneyTracker.canConvertCrownsToPounds;
            ConvertShillingsUpImage.IsVisible = moneyTracker.canConvertShillingsToCrowns;
            ConvertShillingsUpDisabledImage.IsVisible = !moneyTracker.canConvertShillingsToCrowns;
            ConvertPenceUpImage.IsVisible = moneyTracker.canConvertPenceToShillings;
            ConvertPenceUpDisabledImage.IsVisible = !moneyTracker.canConvertPenceToShillings;
            ConvertFarthingsUpImage.IsVisible = moneyTracker.canConvertFarthingsToPence;
            ConvertFarthingsUpDisabledImage.IsVisible = !moneyTracker.canConvertFarthingsToPence;

            // Update enabled/disabled state of decrement buttons
            DecrementPoundsButton.IsEnabled = moneyTracker.pounds > 0;
            DecrementCrownsButton.IsEnabled = moneyTracker.crowns > 0;
            DecrementShillingsButton.IsEnabled = moneyTracker.shillings > 0;
            DecrementPenceButton.IsEnabled = moneyTracker.pence > 0;
            DecrementFarthingsButton.IsEnabled = moneyTracker.farthings > 0;
        }

        /// <summary>
        /// Handles click events on the enabled "convert down" image for pounds 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConvertPoundsDownImage_Clicked(object sender, EventArgs e)
        {
            moneyTracker.ConvertPoundToCrowns();
            UpdateUI();
        }

        /// <summary>
        /// Handles click events on the enabled "convert down" image for crowns 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConvertCrownsDownImage_Clicked(object sender, EventArgs e)
        {
            moneyTracker.ConvertCrownToShillings();
            UpdateUI();
        }

        /// <summary>
        /// Handles click events on the enabled "convert up" image for crowns 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConvertCrownsUpImage_Clicked(object sender, EventArgs e)
        {
            moneyTracker.ConvertCrownsToPound();
            UpdateUI();
        }

        /// <summary>
        /// Handles click events on the enabled "convert down" image for shillings 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConvertShillingsDownImage_Clicked(object sender, EventArgs e)
        {
            moneyTracker.ConvertShillingToPence();
            UpdateUI();
        }

        /// <summary>
        /// Handles click events on the enabled "convert up" image for shillings 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConvertShillingsUpImage_Clicked(object sender, EventArgs e)
        {
            moneyTracker.ConvertShillingsToCrown();
            UpdateUI();
        }

        /// <summary>
        /// Handles click events on the enabled "convert down" image for pence 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConvertPenceDownImage_Clicked(object sender, EventArgs e)
        {
            moneyTracker.ConvertPennyToFarthings();
            UpdateUI();
        }

        /// <summary>
        /// Handles click events on the enabled "convert up" image for pence 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConvertPenceUpImage_Clicked(object sender, EventArgs e)
        {
            moneyTracker.ConvertPenceToShilling();
            UpdateUI();
        }

        /// <summary>
        /// Handles click events on the enabled "convert up" image for farthings 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConvertFarthingsUpImage_Clicked(object sender, EventArgs e)
        {
            moneyTracker.ConvertFarthingsToPenny();
            UpdateUI();

        }

        /// <summary>
        /// Handles click events on the decrement button for pounds 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DecrementPoundsButton_Clicked(object sender, EventArgs e)
        {
            //moneyTracker.DecrementPounds();
            moneyTracker.pounds--;
            UpdateUI();
        }

        /// <summary>
        /// Handles click events on the increment button for pounds 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IncrementPoundsButton_Clicked(object sender, EventArgs e)
        {
            //moneyTracker.IncrementPounds();
            moneyTracker.pounds++;
            UpdateUI();
        }

        /// <summary>
        /// Handles click events on the decrement button for crowns 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DecrementCrownsButton_Clicked(object sender, EventArgs e)
        {
            moneyTracker.crowns--;
            UpdateUI();
        }

        /// <summary>
        /// Handles click events on the increment button for crowns 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IncrementCrownsButton_Clicked(object sender, EventArgs e)
        {
            moneyTracker.crowns++;
            UpdateUI();
        }

        /// <summary>
        /// Handles click events on the decrement button for shillings 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DecrementShillingsButton_Clicked(object sender, EventArgs e)
        {
            moneyTracker.shillings--;
            UpdateUI();
        }

        /// <summary>
        /// Handles click events on the increment button for shillings 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IncrementShillingsButton_Clicked(object sender, EventArgs e)
        {
            moneyTracker.shillings++;
            UpdateUI();
        }

        /// <summary>
        /// Handles click events on the decrement button for pence 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DecrementPenceButton_Clicked(object sender, EventArgs e)
        {
            moneyTracker.pence--;
            UpdateUI();
        }

        /// <summary>
        /// Handles click events on the increment button for pence 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IncrementPenceButton_Clicked(object sender, EventArgs e)
        {
            moneyTracker.pence++;
            UpdateUI();
        }

        /// <summary>
        /// Handles click events on the decrement button for farthings 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DecrementFarthingsButton_Clicked(object sender, EventArgs e)
        {
            moneyTracker.farthings--;
            UpdateUI();
        }

        /// <summary>
        /// Handles click events on the increment button for farthings 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IncrementFarthingsButton_Clicked(object sender, EventArgs e)
        {
            moneyTracker.farthings++;
            UpdateUI();
        }
    }
}

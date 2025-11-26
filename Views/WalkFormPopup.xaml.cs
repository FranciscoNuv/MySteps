using CommunityToolkit.Maui.Views;
using System;
using Microsoft.Maui.Controls;

namespace MySteps.Views;
    public partial class WalkFormPopup : Popup
    {
        public WalkFormPopup()
        {
            InitializeComponent();
        }

        private void OnSubmitButtonClicked(object sender, EventArgs e)
        {
            // Handle form submission logic here
            // You can access the Entry fields defined in XAML

            // Close the popup and optionally pass a result back to the main page
            Close(result: true); 
        }

        private void OnCancelButtonClicked(object sender, EventArgs e)
        {
            // Close the popup without a result (or pass false)
            Close(result: false);
        }
    }
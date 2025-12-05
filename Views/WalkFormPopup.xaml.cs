using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Views;
using System;
using Microsoft.Maui.Controls;
using MySteps.ViewModels;

namespace MySteps.Views;
    public partial class WalkFormPopup : Popup
    {
        public WalkFormPopup(WalkViewModel? viewModel)
        {
            InitializeComponent();
            ActionLabel.Text = viewModel.Id is not null ? "Edit":"Add";
            BindingContext = viewModel;
        }

        private void OnSubmitButtonClicked(object sender, EventArgs e)
        {
            if (BindingContext is WalkViewModel vm)
            {
                var walkAtualizado = vm.GetWalk();
                Close(walkAtualizado);
            }
            else
            {
                Close(false);
            }
        }

        private void OnCancelButtonClicked(object sender, EventArgs e)
        {
            // Close the popup without a result (or pass false)
            Close(result: false);
        }
    }
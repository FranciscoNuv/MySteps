﻿using MySteps.Resources;
using System.Globalization;
using LocalizationResourceManager.Maui;

namespace MySteps
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        ILocalizationResourceManager _resourceManager;

        public MainPage(ILocalizationResourceManager resourceManager)
        {
            InitializeComponent();
            _resourceManager = resourceManager;
            // _resourceManager.CurrentCulture = new(() => resourceManager.CurrentCulture.NativeName);
            BindingContext = this;
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void OnPtClicked(object sender, EventArgs e)
        {
            if (_resourceManager.CurrentCulture.TwoLetterISOLanguageName != "pt")
                _resourceManager.CurrentCulture = new CultureInfo("pt");
        }

        private void OnEnClicked(object sender, EventArgs e)
        {
            if (_resourceManager.CurrentCulture.TwoLetterISOLanguageName != "en")
                _resourceManager.CurrentCulture = new CultureInfo("en");
        }
    }
}

﻿using Xamarin.Forms;

namespace XF2003.Views
{
    public partial class NextPage : ContentPage
    {
        public NextPage()
        {
            InitializeComponent();
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}

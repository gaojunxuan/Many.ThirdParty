﻿using Many.ThirdParty.Config;
using Many.ThirdParty.Core.Factories;
using Many.ThirdParty.Core.Models.ReadingModels;
using Many.ThirdParty.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Many.ThirdParty.SubPages
{
    public sealed partial class CarouselDetailPage : Page
    {
        public CarouselDetailPageViewModel ViewModel { get; set; }

        public CarouselDetailPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel = e.Parameter as CarouselDetailPageViewModel ?? new CarouselDetailPageViewModel();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.GoBack(this.Frame);
        }

        private async void CarouselList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var model = e.ClickedItem as CarouselDetailModel;
             
            NavigationManager.GeneralNavigate(
                NavigationManager.MainScenarios[Convert.ToInt32(model.Type) + 4].PageType,
                await ReadingViewModelFactory.CreateReadingDetailPageViewModel(model));
        }
    }
}

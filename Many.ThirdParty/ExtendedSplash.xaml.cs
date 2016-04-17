﻿using Many.ThirdParty.Core.Data;
using Many.ThirdParty.Core.Models.HomeModels;
using Many.ThirdParty.SubPages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Many.ThirdParty
{
    public sealed partial class ExtendedSplash : Page
    {
        public ExtendedSplash()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            //TODO: Delay 2s in debug mode
#if DEBUG
            //await Task.Delay(1000);
#endif
            HomePage.TodaysListId = await LoadResources.GetMainList(HomePage.CumulateListIndex.ToString());

            //TODO: load resource from internet
            Frame.Navigate(typeof(PreLoadPage), await LoadResources.LoadHomeModelResourcesAsync(HomePage.TodaysListId[0]));
        }
    }

}

using Friends.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Friends.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        HomeSection home_section;
        SearchSection search_section;
        MyGroupsSection my_groups_section;
        MyProfileSection my_profile_section;
        int current_view;
        private string Uuid;
        public MainPage(string uuid)
        {
            InitializeComponent();

            Uuid = uuid;

            ibtn_home.Source = ImageSource.FromResource("Friends.Resources.home_black.png");
            ibtn_search.Source = ImageSource.FromResource("Friends.Resources.search_black.png");
            ibtn_mygroups.Source = ImageSource.FromResource("Friends.Resources.group_black.png");
            ibtn_myprofile.Source = ImageSource.FromResource("Friends.Resources.profile_black.png");

            home_section = new HomeSection();
            search_section = new SearchSection();
            my_groups_section = new MyGroupsSection();
            my_profile_section = new MyProfileSection();

            SetMainContent(home_section);
            current_view = 0;

            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString($"{Constants.BaseURL}/oauth/userInfo?uuid={Uuid}");
                WarwickAccount acc_obj = JsonConvert.DeserializeObject<WarwickAccount>(json);
                my_profile_section.SetProfileInfo(acc_obj.data["name"], acc_obj.data["deptshort"]);
            }
        }
        private void ibtn_home_Clicked(object sender, EventArgs e)
        {
            if (current_view == 0)
            {
                home_section.SetHomeHome();
            }
            else
            {
                ibtn_home.Opacity = 1;
                ibtn_search.Opacity = 0.5;
                ibtn_mygroups.Opacity = 0.5;
                ibtn_myprofile.Opacity = 0.5;

                SetMainContent(home_section);
                current_view = 0;
            }
        }
        private void ibtn_search_Clicked(object sender, EventArgs e)
        {
            if (current_view == 1)
            {
                // search_section.setMyGroupsHome();
            }
            else
            {
                ibtn_home.Opacity = 0.5;
                ibtn_search.Opacity = 1;
                ibtn_mygroups.Opacity = 0.5;
                ibtn_myprofile.Opacity = 0.5;

                SetMainContent(search_section);
                current_view = 1;
            }
        }
        private void ibtn_mygroups_Clicked(object sender, EventArgs e)
        {
            if (current_view == 2)
            {
                // my_groups.setMyGroupsHome();
            }
            else
            {
                ibtn_home.Opacity = 0.5;
                ibtn_search.Opacity = 0.5;
                ibtn_mygroups.Opacity = 1;
                ibtn_myprofile.Opacity = 0.5;

                SetMainContent(my_groups_section);
                current_view = 2;
            }
        }
        private void ibtn_myprofile_Clicked(object sender, EventArgs e)
        {
            if (current_view == 3)
            {
                // my_profile.setMyProfileHome();
            }
            else
            {
                ibtn_home.Opacity = 0.5;
                ibtn_search.Opacity = 0.5;
                ibtn_mygroups.Opacity = 0.5;
                ibtn_myprofile.Opacity = 1;

                SetMainContent(my_profile_section);
                current_view = 3;
            }
        }
        public void SetMainContent(ContentView content)
        {
            MainContent.Content = content;
        }
    }
}

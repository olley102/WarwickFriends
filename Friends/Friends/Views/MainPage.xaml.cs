using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Friends.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        ContentView star_section;
        ContentView my_groups;
        ContentView my_profile;
        public MainPage()
        {
            InitializeComponent();

            ibtn_mygroups.Source = ImageSource.FromResource("Friends.Resources.mygroups.png");
            ibtn_main.Source = ImageSource.FromResource("Friends.Resources.main.png");
            ibtn_myprofile.Source = ImageSource.FromResource("Friends.Resources.myprofile.png");

            star_section = new StarSection();
            my_groups = new MyGroupsSection();
            my_profile = new MyProfileSection();

            setMainContent(star_section);
        }

        private void ibtn_mygroups_Clicked(object sender, EventArgs e)
        {
            ibtn_mygroups.Opacity = 1;
            ibtn_main.Opacity = 0.5;
            ibtn_myprofile.Opacity = 0.5;

            setMainContent(my_groups);
        }

        private void ibtn_main_Clicked(object sender, EventArgs e)
        {
            ibtn_mygroups.Opacity = 0.5;
            ibtn_main.Opacity = 1;
            ibtn_myprofile.Opacity = 0.5;

            setMainContent(star_section);
        }
        private void ibtn_myprofile_Clicked(object sender, EventArgs e)
        {
            ibtn_mygroups.Opacity = 0.5;
            ibtn_main.Opacity = 0.5;
            ibtn_myprofile.Opacity = 1;

            setMainContent(my_profile);
        }

        public void setMainContent(ContentView content)
        {
            MainContent.Content = content;
        }
    }
}

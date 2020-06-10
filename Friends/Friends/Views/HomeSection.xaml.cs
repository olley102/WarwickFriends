using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Friends.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeSection : ContentView
    {
        HomeSectionHome home_home;
        HomeSectionFind home_find;
        public HomeSection()
        {
            InitializeComponent();

            home_home = new HomeSectionHome();
            SetHomeFind(0);

            TapGestureRecognizer studyTapRecognizer = new TapGestureRecognizer();
            studyTapRecognizer.Tapped += (s, e) => SetHomeFind(0);

            TapGestureRecognizer societyTapRecognizer = new TapGestureRecognizer();
            societyTapRecognizer.Tapped += (s, e) => SetHomeFind(1);

            TapGestureRecognizer friendshipTapRecognizer = new TapGestureRecognizer();
            friendshipTapRecognizer.Tapped += (s, e) => SetHomeFind(2);

            Frame frame_tap_study = home_home.FindByName<Frame>("frame_tap_study");
            Frame frame_tap_society = home_home.FindByName<Frame>("frame_tap_society");
            Frame frame_tap_friendship = home_home.FindByName<Frame>("frame_tap_friendship");

            frame_tap_study.GestureRecognizers.Add(studyTapRecognizer);
            frame_tap_society.GestureRecognizers.Add(societyTapRecognizer);
            frame_tap_friendship.GestureRecognizers.Add(friendshipTapRecognizer);
        }
        public void SetHomeContent(ContentView content)
        {
            HomeContent.Content = content;
        }
        public void SetHomeHome()
        {
            SetHomeContent(home_home);
        }
        private void SetHomeFind(int find_view_num)
        {
            home_find = new HomeSectionFind();
            SetHomeContent(home_find);
            ImageButton ibtn_back = home_find.FindByName<ImageButton>("ibtn_back");
            ibtn_back.Clicked += (s, _e) => SetHomeHome();
            home_find.SetFindView(find_view_num);
        }
    }
}
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
        int num_members;
        const int max_members = 7;
        const int min_members = 1;
        public HomeSection()
        {
            InitializeComponent();

            home_home = new HomeSectionHome();
            home_home.max_members = max_members;
            home_home.min_members = min_members;

            num_members = 4;
            SetHomeFind(2);

            TapGestureRecognizer studyTapRecognizer = new TapGestureRecognizer();
            studyTapRecognizer.Tapped += (s, e) => SetHomeFind(0);

            TapGestureRecognizer societyTapRecognizer = new TapGestureRecognizer();
            societyTapRecognizer.Tapped += (s, e) => SetHomeFind(1);

            TapGestureRecognizer friendshipTapRecognizer = new TapGestureRecognizer();
            friendshipTapRecognizer.Tapped += (s, e) => SetHomeFind(2);

            TapGestureRecognizer minusTapRecognizer = new TapGestureRecognizer();
            minusTapRecognizer.Tapped += (s, e) =>
            {
                if (num_members > min_members)
                {
                    num_members--;
                }
                AdjustNumMembers();
            };

            TapGestureRecognizer addTapRecognizer = new TapGestureRecognizer();
            addTapRecognizer.Tapped += (s, e) =>
            {
                if (num_members < max_members)
                {
                    num_members++;
                }
                AdjustNumMembers();
            };

            Frame frame_tap_study = home_home.FindByName<Frame>("frame_tap_study");
            Frame frame_tap_society = home_home.FindByName<Frame>("frame_tap_society");
            Frame frame_tap_friendship = home_home.FindByName<Frame>("frame_tap_friendship");
            Frame frame_tap_minus = home_home.FindByName<Frame>("frame_tap_minus");
            Frame frame_tap_add = home_home.FindByName<Frame>("frame_tap_add");

            frame_tap_study.GestureRecognizers.Add(studyTapRecognizer);
            frame_tap_society.GestureRecognizers.Add(societyTapRecognizer);
            frame_tap_friendship.GestureRecognizers.Add(friendshipTapRecognizer);
            frame_tap_minus.GestureRecognizers.Add(minusTapRecognizer);
            frame_tap_add.GestureRecognizers.Add(addTapRecognizer);
        }
        public void SetHomeContent(ContentView content)
        {
            HomeContent.Content = content;
        }
        public void SetHomeHome()
        {
            SetHomeContent(home_home);
        }
        private void BackBtnHandler()
        {
            if (!home_find.at_home)
            {
                home_find.SetFindHome();
            }
            else
            {
                SetHomeHome();
            }
        }
        private void SetHomeFind(int find_view_num)
        {
            home_find = new HomeSectionFind();
            SetHomeContent(home_find);
            ImageButton ibtn_back = home_find.FindByName<ImageButton>("ibtn_back");
            ibtn_back.Clicked += (s, _e) => BackBtnHandler();
            home_find.SetFindView(find_view_num, num_members);
        }
        private void AdjustNumMembers()
        {
            home_home.AdjustNumMembers(num_members);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Friends.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace Friends.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeSection : ContentView
    {
        HomeSectionFind home_find;
        HomeSectionPrefs prefs_view;
        int num_members;
        public HomeSection()
        {
            InitializeComponent();

            num_members = Preferences.Get("num_members", 4);
            home_find = new HomeSectionFind(num_members, MemberViewAction, PrefsClickAction);
            SetHomeContent(home_find);

            prefs_view = new HomeSectionPrefs(num_members, PrefsBackBtnAction, MinusTapAction, AddTapAction);
        }
        private void SetHomeContent(ContentView content)
        {
            HomeContent.Content = content;
        }
        public void SetHomeHome()
        {
            if (HomeContent.Content.GetType() != typeof(HomeSectionFind))
            {
                if (HomeContent.Content.GetType() == typeof(HomeSectionPrefs))
                    Preferences.Set("num_members", num_members);
                home_find = new HomeSectionFind(num_members, MemberViewAction, PrefsClickAction);
                SetHomeContent(home_find);
            }
        }
        private void MemberBackBtnAction()
        {
            SetHomeContent(home_find);
        }
        private void PrefsBackBtnAction()
        {
            Preferences.Set("num_members", num_members);
            home_find = new HomeSectionFind(num_members, MemberViewAction, PrefsClickAction);
            SetHomeContent(home_find);
        }
        private void MemberViewAction()
        {
            MemberView member_view = new MemberView(MemberBackBtnAction);
            SetHomeContent(member_view);
        }
        private int MinusTapAction()
        {
            if (num_members > Constants.MinMembers)
                num_members--;
            return num_members;
        }
        private int AddTapAction()
        {
            if (num_members < Constants.MaxMembers)
                num_members++;
            return num_members;
        }
        private void PrefsClickAction()
        {
            SetHomeContent(prefs_view);
        }
    }
}
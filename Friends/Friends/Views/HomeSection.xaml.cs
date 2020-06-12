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
        HomeSectionFind home_find;
        HomeSectionPrefs prefs_view;
        int num_members;
        const int max_members = 7;
        const int min_members = 1;
        public HomeSection()
        {
            InitializeComponent();

            num_members = 4;
            home_find = new HomeSectionFind(num_members, MemberViewAction, PrefsClickAction);
            SetHomeContent(home_find);

            prefs_view = new HomeSectionPrefs(num_members, PrefsBackBtnAction, MinusTapAction, AddTapAction, max_members, min_members);
        }
        private void SetHomeContent(ContentView content)
        {
            HomeContent.Content = content;
        }
        public void SetHomeHome()
        {
            SetHomeContent(home_find);
        }
        private void MemberBackBtnAction()
        {
            SetHomeContent(home_find);
        }
        private void PrefsBackBtnAction()
        {
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
            if (num_members > min_members)
                num_members--;
            return num_members;
        }
        private int AddTapAction()
        {
            if (num_members < max_members)
                num_members++;
            return num_members;
        }
        private void PrefsClickAction()
        {
            SetHomeContent(prefs_view);
        }
    }
}
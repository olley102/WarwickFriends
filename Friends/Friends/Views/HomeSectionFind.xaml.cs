using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Friends.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeSectionFind : ContentView
    {
        private List<MemberPeek> member_peek_list;
        private Action ViewBtnAction;
        public HomeSectionFind(int num_members, Action view_btn_action, Action prefs_btn_action)
        {
            InitializeComponent();

            img_check.Source = ImageSource.FromResource("Friends.Resources.check_white.png");
            img_cross.Source = ImageSource.FromResource("Friends.Resources.cross_white.png");
            ibtn_prefs.Source = ImageSource.FromResource("Friends.Resources.prefs_black.png");

            ibtn_prefs.Clicked += (s, e) => prefs_btn_action();

            ViewBtnAction = view_btn_action;

            member_peek_list = new List<MemberPeek>();
            for (int i = 0; i < num_members; i++)
            {
                MemberPeek temp_member_peek = new MemberPeek();
                temp_member_peek.SetViewButtonAction(ViewBtnAction);
                stack_member_list.Children.Add(temp_member_peek);
                member_peek_list.Add(temp_member_peek);
            }
        }
    }
}
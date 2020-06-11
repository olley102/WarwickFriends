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
        //private List<MemberPeek> member_peek_list;
        HomeSectionFindGroup group_view;
        HomeSectionFindMember member_view;
        public bool at_home;
        public HomeSectionFind()
        {
            InitializeComponent();

            ibtn_back.Source = ImageSource.FromResource("Friends.Resources.back_black.png");
            //img_cross.Source = ImageSource.FromResource("Friends.Resources.cross_white.png");
            //img_check.Source = ImageSource.FromResource("Friends.Resources.check_white.png");

            //member_peek_list = new List<MemberPeek>();

            group_view = new HomeSectionFindGroup();
            SetFindHome();
        }
        private void SetFindMemberView()
        {
            member_view = new HomeSectionFindMember();
            SetFindContent(member_view);
            at_home = false;
        }
        public void SetFindHome()
        {
            at_home = true;
            SetFindContent(group_view);
        }
        public void SetFindView(int find_view_num, int num_members)
        {
            group_view.SetFindView(find_view_num, num_members, SetFindMemberView);

            //if (find_view_num == 0)
            //{
            //    label_find_header.Text = "Find a study group";

            //}
            //else if (find_view_num == 1)
            //{
            //    label_find_header.Text = "Find a society group";
            //}
            //else
            //{
            //    label_find_header.Text = "Find a friendship group";
            //}

            //for (int i = 0; i < num_members; i++)
            //{
            //    MemberPeek temp_member_peek = new MemberPeek();
            //    member_peek_list.Add(temp_member_peek);
            //    stack_member_list.Children.Add(temp_member_peek);
            //}
        }
        private void SetFindContent(ContentView content)
        {
            FindContent.Content = content;
        }
    }
}
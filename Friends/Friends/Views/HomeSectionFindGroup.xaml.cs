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
    public partial class HomeSectionFindGroup : ContentView
    {
        private List<MemberPeek> member_peek_list;
        public HomeSectionFindGroup()
        {
            InitializeComponent();

            img_cross.Source = ImageSource.FromResource("Friends.Resources.cross_white.png");
            img_check.Source = ImageSource.FromResource("Friends.Resources.check_white.png");

            member_peek_list = new List<MemberPeek>();
        }
        public void SetFindView(int find_view_num, int num_members, Action view_btn_action)
        {
            switch (find_view_num)
            {
                case 0:
                    label_find_header.Text = "Find a study group";
                    break;
                case 1:
                    label_find_header.Text = "Find a society group";
                    break;
                default:
                    label_find_header.Text = "Find a friendship group";
                    break;
            }

            for (int i = 0; i < num_members; i++)
            {
                MemberPeek temp_member_peek = new MemberPeek();
                temp_member_peek.SetViewButtonAction(view_btn_action);
                member_peek_list.Add(temp_member_peek);
                stack_member_list.Children.Add(temp_member_peek);
            }
        }
    }
}
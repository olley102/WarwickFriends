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
        public HomeSectionFind()
        {
            InitializeComponent();

            ibtn_back.Source = ImageSource.FromResource("Friends.Resources.back_black.png");

            member_peek_list = new List<MemberPeek>();
        }
        public void SetFindView(int find_view_num, int num_members)
        {
            if (find_view_num == 0)
            {
                label_find_header.Text = "Find a study group";

            }
            else if (find_view_num == 1)
            {
                label_find_header.Text = "Find a society group";
            }
            else
            {
                label_find_header.Text = "Find a friendship group";
            }

            for (int i = 0; i < num_members; i++)
            {
                MemberPeek temp_member_peek = new MemberPeek();
                temp_member_peek.SetThemeFromViewNum(find_view_num);
                member_peek_list.Add(temp_member_peek);
                stack_member_list.Children.Add(temp_member_peek);
            }
        }
    }
}
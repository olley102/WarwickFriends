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
    public partial class MemberPeek : ContentView
    {
        public MemberPeek()
        {
            InitializeComponent();

            img_member_avatar.Source = ImageSource.FromResource("Friends.Resources.person_black.png");
        }
        public void SetMemberInfo(String first_name, String course_name)
        {
            label_member_first_name.Text = first_name;
            label_member_course.Text = course_name;
        }
        public void SetThemeFromViewNum(int find_view_num)
        {
            if (find_view_num == 0)
            {
                btn_member_view.BackgroundColor = Color.FromHex("#FF00A6FF");
            }
            else if (find_view_num == 1)
            {
                btn_member_view.BackgroundColor = Color.FromHex("#FF77D353");
            }
            else
            {
                btn_member_view.BackgroundColor = Color.FromHex("#FFF95F62");
            }
        }
    }
}
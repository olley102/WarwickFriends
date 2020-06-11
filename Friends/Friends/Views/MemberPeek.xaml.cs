using System;

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
    }
}
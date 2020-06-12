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
    public partial class GroupPeek : ContentView
    {
        public GroupPeek()
        {
            InitializeComponent();

            img_group_pic.Source = ImageSource.FromResource("Friends.Resources.group_black.png");
        }
        public void SetGroupInfo(String group_name, String group_type)
        {
            label_member_first_name.Text = group_name;
            label_member_course.Text = group_type;
        }
        public void SetViewButtonAction(Action view_btn_action)
        {
            btn_group_view.Clicked += (s, e) => view_btn_action();
        }
    }
}
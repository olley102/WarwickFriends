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
    public partial class MemberView : ContentView
    {
        public MemberView(Action back_btn_action)
        {
            InitializeComponent();

            img_profile_pic.Source = ImageSource.FromResource("Friends.Resources.person_black.png");
            img_study_icon.Source = ImageSource.FromResource("Friends.Resources.grad_black.png");
            img_bio_icon.Source = ImageSource.FromResource("Friends.Resources.note_black.png");

            ViewWithBackButton viewWithBackButton = new ViewWithBackButton(back_btn_action);
            BackBtnContent.Content = viewWithBackButton;
        }
    }
}
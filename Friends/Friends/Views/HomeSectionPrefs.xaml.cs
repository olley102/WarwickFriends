using Friends.Models;
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
    public partial class HomeSectionPrefs : ContentView
    {
        public HomeSectionPrefs(int num_members, Action back_btn_action, Func<int> minus_tap_action, Func<int> add_tap_action)
        {
            InitializeComponent();

            label_num_members.Text = num_members.ToString();

            img_minus.Source = ImageSource.FromResource("Friends.Resources.remove_black.png");
            img_add.Source = ImageSource.FromResource("Friends.Resources.add_black.png");

            ViewWithBackButton viewWithBackButton = new ViewWithBackButton(back_btn_action);
            BackBtnContent.Content = viewWithBackButton;

            TapGestureRecognizer minusTapRecognizer = new TapGestureRecognizer();
            minusTapRecognizer.Tapped += (s, e) => AdjustNumMembers(minus_tap_action());

            TapGestureRecognizer addTapRecognizer = new TapGestureRecognizer();
            addTapRecognizer.Tapped += (s, e) => AdjustNumMembers(add_tap_action());

            frame_tap_minus.GestureRecognizers.Add(minusTapRecognizer);
            frame_tap_add.GestureRecognizers.Add(addTapRecognizer);
        }
        private void AdjustNumMembers(int num_members)
        {
            label_num_members.Text = num_members.ToString();
            if (num_members == Constants.MinMembers)
                img_minus.Opacity = 0.2;
            else
            {
                img_minus.Opacity = 1;
                if (num_members == Constants.MaxMembers)
                    img_add.Opacity = 0.2;
                else
                    img_add.Opacity = 1;
            }
        }
    }
}
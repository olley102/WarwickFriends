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
    public partial class HomeSectionHome : ContentView
    {
        public int max_members;
        public int min_members;
        public HomeSectionHome()
        {
            InitializeComponent();

            img_study.Source = ImageSource.FromResource("Friends.Resources.grad_white_outline.png");
            img_society.Source = ImageSource.FromResource("Friends.Resources.heart_white_outline.png");
            img_friendship.Source = ImageSource.FromResource("Friends.Resources.coffee_white_outline.png");
            img_minus.Source = ImageSource.FromResource("Friends.Resources.remove_black.png");
            img_add.Source = ImageSource.FromResource("Friends.Resources.add_black.png");
        }
        public void AdjustNumMembers(int num_members)
        {
            label_num_members.Text = num_members.ToString();
            if (num_members == max_members)
            {
                img_add.Opacity = 0.2;
            }
            else
            {
                img_add.Opacity = 1;
                if (num_members == min_members)
                {
                    img_minus.Opacity = 0.2;
                }
                else
                {
                    img_minus.Opacity = 1;
                }
            }
        }
    }
}
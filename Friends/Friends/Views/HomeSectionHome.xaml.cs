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
        public HomeSectionHome()
        {
            InitializeComponent();

            img_study.Source = ImageSource.FromResource("Friends.Resources.grad_white_outline.png");
            img_society.Source = ImageSource.FromResource("Friends.Resources.heart_white_outline.png");
            img_friendship.Source = ImageSource.FromResource("Friends.Resources.coffee_white_outline.png");
        }
    }
}
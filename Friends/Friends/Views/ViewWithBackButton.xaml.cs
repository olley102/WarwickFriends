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
    public partial class ViewWithBackButton : ContentView
    {
        public ViewWithBackButton(Action back_btn_action, string title = "")
        {
            InitializeComponent();

            ibtn_back.Source = ImageSource.FromResource("Friends.Resources.back_black.png");
            ibtn_back.Clicked += (s, e) => back_btn_action();

            label_title.Text = title;
        }
    }
}
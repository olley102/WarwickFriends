using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace Friends.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyProfileSection : ContentView
    {
        public MyProfileSection()
        {
            InitializeComponent();
        }
        public void SetProfileInfo(string name, string deptshort)
        {
            label_first_name.Text = name;
            label_course.Text = deptshort;
        }
    }
}
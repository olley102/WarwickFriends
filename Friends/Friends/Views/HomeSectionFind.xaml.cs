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
    public partial class HomeSectionFind : ContentView
    {
        public HomeSectionFind()
        {
            InitializeComponent();

            ibtn_back.Source = ImageSource.FromResource("Friends.Resources.back_black.png");
        }
        public void SetFindView(int find_view_num)
        {
            if (find_view_num == 0)
            {
                label_find_header.Text = "Find a study group";
            } else if (find_view_num == 1)
            {
                label_find_header.Text = "Find a society group";
            } else
            {
                label_find_header.Text = "Find a friendship group";
            }
        }
    }
}
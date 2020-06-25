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
    public partial class MyGroupsSectionList : ContentView
    {
        public MyGroupsSectionList()
        {
            InitializeComponent();

            GroupPeek temp_group_peek = new GroupPeek();
            stack_group_list.Children.Add(temp_group_peek);
        }
    }
}
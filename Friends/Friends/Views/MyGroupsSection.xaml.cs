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
    public partial class MyGroupsSection : ContentView
    {
        MyGroupsSectionList groups_list_view;
        public MyGroupsSection()
        {
            InitializeComponent();

            groups_list_view = new MyGroupsSectionList();
            SetMygroupsContent(groups_list_view);
        }
        private void SetMygroupsContent(ContentView content)
        {
            MyGroupsContent.Content = content;
        }
    }
}
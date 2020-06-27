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
    public partial class SocialLinkListItem : ContentView
    {
        public int ItemID;
        public SocialLinkListItem(int item_id, TapGestureRecognizer popRecognizer, Action crossBtnAction)
        {
            InitializeComponent();

            ItemID = item_id;

            img_caret_social.Source = ImageSource.FromResource("Friends.Resources.caret_down_black.png");
            ibtn_social_delete.Source = ImageSource.FromResource("Friends.Resources.cross_black.png");

            frame_tap_social_select.GestureRecognizers.Add(popRecognizer);

            ibtn_social_delete.Clicked += (s, e) => crossBtnAction();
        }
        public void SwitchPopupSocial(bool visible)
        {
            if (visible)
                img_caret_social.Source = ImageSource.FromResource("Friends.Resources.caret_up_black.png");
            else
                img_caret_social.Source = ImageSource.FromResource("Friends.Resources.caret_down_black.png");
        }
        public void SetSocialType(string social_name, string placeholder)
        {
            entry_social_link.IsReadOnly = false;
            label_social_type.Text = social_name;
            entry_social_link.Placeholder = placeholder;
        }
    }
}
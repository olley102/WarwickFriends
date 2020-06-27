using Friends.Models;
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
        private bool social_popped;
        private List<SocialLinkListItem> social_links;
        private int social_popped_id;
        public MyProfileSection()
        {
            InitializeComponent();

            ibtn_profile_pic.Source = ImageSource.FromResource("Friends.Resources.person_black.png");
            img_study_icon.Source = ImageSource.FromResource("Friends.Resources.grad_black.png");
            img_bio_icon.Source = ImageSource.FromResource("Friends.Resources.note_black.png");
            img_social_icon.Source = ImageSource.FromResource("Friends.Resources.link_black.png");
            ibtn_add_social_item.Source = ImageSource.FromResource("Friends.Resources.add_black.png");
            img_facebook_icon.Source = ImageSource.FromResource("Friends.Resources.f_logo.png");
            img_twitter_icon.Source = ImageSource.FromResource("Friends.Resources.t_logo.png");

            social_popped = false;
            social_links = new List<SocialLinkListItem>();
            social_popped_id = 0;

            TapGestureRecognizer socialTapRecognizer = new TapGestureRecognizer();
            socialTapRecognizer.Tapped += (s, e) => TogglePopupSocial(social_popped_id);

            popup_background.GestureRecognizers.Add(socialTapRecognizer);

            TapGestureRecognizer socialItemTapRecognizer = new TapGestureRecognizer();
            socialItemTapRecognizer.Tapped += (s, e) => SelectSocialType(s, e);

            frame_tap_facebook.GestureRecognizers.Add(socialItemTapRecognizer);
            frame_tap_twitter.GestureRecognizers.Add(socialItemTapRecognizer);

            ibtn_add_social_item.Clicked += (s, e) => AddSocialLink();
        }
        public void SetProfileInfo(string name, string deptshort, string warwickyearofstudy)
        {
            label_profile_name.Text = name;
            label_course.Text = deptshort;
            label_year.Text = $"Year {warwickyearofstudy}";
        }
        private void TogglePopupSocial(int item_id)
        {
            if (social_popped)
            {
                social_popped = false;
                popup_background.IsVisible = false;
                social_links[item_id].SwitchPopupSocial(false);
            }
            else
            {
                social_popped = true;
                social_popped_id = item_id;
                popup_background.IsVisible = true;
                social_links[item_id].SwitchPopupSocial(true);
            }
        }
        private void SelectSocialType(object sender, EventArgs e)
        {
            TogglePopupSocial(social_popped_id);
            if (sender is Frame)
            {
                if (sender.Equals(frame_tap_facebook))
                {
                    social_links[social_popped_id].SetSocialType("Facebook", "Name");
                }
                else
                {
                    social_links[social_popped_id].SetSocialType("Twitter", "Username");
                }
            }
        }
        private void AddSocialLink()
        {
            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            var frozen_links_count = social_links.Count;
            tapGestureRecognizer.Tapped += (s, e) => TogglePopupSocial(frozen_links_count);
            Action crossBtnAction = () =>
            {
                social_links.RemoveAt(frozen_links_count);
                stack_social_list.Children.RemoveAt(frozen_links_count);
            };
            var link = new SocialLinkListItem(social_links.Count, tapGestureRecognizer, crossBtnAction);
            stack_social_list.Children.Add(link);
            social_links.Add(link);
        }
    }
}
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
    public partial class SearchSection : ContentView
    {
        private bool society_filter_popped;
        private bool course_filter_popped;
        public SearchSection()
        {
            InitializeComponent();

            img_caret_society.Source = ImageSource.FromResource("Friends.Resources.caret_down_white.png");
            img_caret_course.Source = ImageSource.FromResource("Friends.Resources.caret_down_white.png");

            img_item_pic.Source = ImageSource.FromResource("Friends.Resources.group_black.png");
            img_item_pic2.Source = ImageSource.FromResource("Friends.Resources.group_black.png");

            society_filter_popped = false;
            course_filter_popped = false;

            TapGestureRecognizer societyFilterRecognizer = new TapGestureRecognizer();
            societyFilterRecognizer.Tapped += (s, e) => TogglePopupSociety();

            TapGestureRecognizer courseFilterRecognizer = new TapGestureRecognizer();
            courseFilterRecognizer.Tapped += (s, e) => TogglePopupCourse();

            frame_tap_filter_society.GestureRecognizers.Add(societyFilterRecognizer);
            frame_tap_filter_course.GestureRecognizers.Add(courseFilterRecognizer);

            btn_filter_cancel.Clicked += (s, e) =>
            {
                if (society_filter_popped)
                    TogglePopupSociety();
                else
                    TogglePopupCourse();
            };

            btn_filter_ok.Clicked += (s, e) =>
            {
                if (society_filter_popped)
                    TogglePopupSociety();
                else
                    TogglePopupCourse();
            };

            TapGestureRecognizer stackTapOffRecognizer = new TapGestureRecognizer();
            stackTapOffRecognizer.Tapped += (s, e) =>
            {
                if (society_filter_popped)
                    TogglePopupSociety();
                else
                    TogglePopupCourse();
            };

            stack_filter.GestureRecognizers.Add(stackTapOffRecognizer);

            TapGestureRecognizer frameTapOffRecognizer = new TapGestureRecognizer();  // do nothing
            frame_tap_off_filter.GestureRecognizers.Add(frameTapOffRecognizer);
        }
        private void TogglePopupSociety()
        {
            if (course_filter_popped)
            {
                TogglePopupCourse();
            }
            if (society_filter_popped)
            {
                img_caret_society.Source = ImageSource.FromResource("Friends.Resources.caret_down_white.png");
                popup_filter.IsVisible = false;
                society_filter_popped = false;
            }
            else
            {
                img_caret_society.Source = ImageSource.FromResource("Friends.Resources.caret_up_white.png");
                popup_filter.IsVisible = true;
                society_filter_popped = true;
                label_filter_header.Text = "Filter by society";
            }
        }
        private void TogglePopupCourse()
        {
            if (society_filter_popped)
            {
                TogglePopupSociety();
            }
            if (course_filter_popped)
            {
                img_caret_course.Source = ImageSource.FromResource("Friends.Resources.caret_down_white.png");
                popup_filter.IsVisible = false;
                course_filter_popped = false;
            }
            else
            {
                img_caret_course.Source = ImageSource.FromResource("Friends.Resources.caret_up_white.png");
                popup_filter.IsVisible = true;
                course_filter_popped = true;
                label_filter_header.Text = "Filter by course";
            }
        }
    }
}
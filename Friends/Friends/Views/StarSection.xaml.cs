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
    public partial class StarSection : ContentView
    {
        StarSectionHome star_home;
        StarSectionStudyGroup star_study;
        public StarSection()
        {
            InitializeComponent();

            star_home = new StarSectionHome();
            setStarHome();

            TapGestureRecognizer frame_find_study_Recognizer = new TapGestureRecognizer();
            frame_find_study_Recognizer.Tapped += (s, e) => frame_find_study_Tapped(s, e);

            Frame frame_find_study = star_home.FindByName<Frame>("frame_find_study");
            frame_find_study.GestureRecognizers.Add(frame_find_study_Recognizer);
        }
        public void setStarContent(ContentView content)
        {
            StarContent.Content = content;
        }
        public void setStarHome()
        {
            setStarContent(star_home);
        }
        private void frame_find_study_Tapped(object sender, EventArgs e)
        {
            star_study = new StarSectionStudyGroup();
            setStarContent(star_study);

            ImageButton ibtn_back = star_study.FindByName<ImageButton>("ibtn_back");
            ibtn_back.Clicked += (s, _e) => setStarHome();
        }
    }
}
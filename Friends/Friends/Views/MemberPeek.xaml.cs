﻿using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Friends.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MemberPeek : ContentView
    {
        public MemberPeek()
        {
            InitializeComponent();

            img_member_avatar.Source = ImageSource.FromResource("Friends.Resources.person_black.png");
        }
        public void SetMemberInfo(string first_name, string course_name)
        {
            label_member_first_name.Text = first_name;
            label_member_course.Text = course_name;
        }
        public void SetViewButtonAction(Action view_btn_action)
        {
            btn_member_view.Clicked += (s, e) => view_btn_action();
        }
    }
}
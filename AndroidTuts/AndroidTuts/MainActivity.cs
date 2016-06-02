using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading;

namespace AndroidTuts
{
    [Activity(Label = "LoginSystem", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button gBtnSignUp;
        private ProgressBar gProgressBar;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            ActionBar.Hide();
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            gBtnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);
            gProgressBar = FindViewById<ProgressBar>(Resource.Id.progressBar1);

            gBtnSignUp.Click += (object sender, EventArgs args) =>
            {
                //pull up dialog
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                dialog_signup signUpDialog = new dialog_signup();
                signUpDialog.Show(transaction, "Dialog Fragment");
                
                signUpDialog.gOnSignUpComplete += signUpDialog_gOnSignUpComplete;
            };

        }

        private void signUpDialog_gOnSignUpComplete(object sender, OnSignUpEventArgs e)
        {
            gProgressBar.Visibility = ViewStates.Visible;
            Thread thread = new Thread(ActLikeRequest);
            thread.Start();

        }
        private void ActLikeRequest()
        {
            Thread.Sleep(3000);
            RunOnUiThread(() => { gProgressBar.Visibility = ViewStates.Invisible; });    
        }
    }
}


using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AndroidTuts
{
    public class OnSignUpEventArgs : EventArgs
    {
        private string gfristName;
        private string gemail;
        private string gpassword;

        public string FirstName
        {
            get { return gfristName; }
            set { gfristName = value; }
        }

        public string Email
        {
            get { return gemail; }
            set { gemail = value; }
        }

        public string Password
        {
            get { return gpassword; }
            set { gpassword = value; }
        }

        public OnSignUpEventArgs(string firstname, string email, string password) : base()
        {
            FirstName = firstname;
            Email = email;
            Password = password;
        }
    }

    class dialog_signup : DialogFragment
    {
        private EditText gFirstNameTxt;
        private EditText gEmailTxt;
        private EditText gPasswordTxt;
        private Button gBtnSignUp;

        public event EventHandler<OnSignUpEventArgs> gOnSignUpComplete;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialog_sign_up, container, false);

            gFirstNameTxt = view.FindViewById<EditText>(Resource.Id.txtFirstName);
            gEmailTxt = view.FindViewById<EditText>(Resource.Id.txtEmail);
            gPasswordTxt = view.FindViewById<EditText>(Resource.Id.txtPassword);
            gBtnSignUp = view.FindViewById<Button>(Resource.Id.btnDialogEmail);

            gBtnSignUp.Click += gBtnSignUp_Click;

            return view;
        }

        void gBtnSignUp_Click(object sender, EventArgs e)
        {
            //User has clicked the sign up button
            gOnSignUpComplete.Invoke(this, new OnSignUpEventArgs(gFirstNameTxt.Text, gEmailTxt.Text, gPasswordTxt.Text));
            this.Dismiss();
        }
            
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle); //set the title bar to invisible
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation; // set the animation 
        }
    }
}
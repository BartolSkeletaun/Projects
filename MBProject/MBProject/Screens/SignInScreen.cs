
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MBProject;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Gms.Common;



namespace MBProject
{
	[Activity (Label = "GPlusSignInScreen", Theme = "@style/mytheme", Icon = "@drawable/Icon")]			
	public class GPlusSignInScreen : Activity
	{

	


		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.G_SignInScreen);


	}
}
}

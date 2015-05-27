using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Support.V4.View;
using Android.Support.V4.App;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;




namespace MBProject
{
	[Activity(Label = "MyBuild", Theme = "@style/mytheme", Icon = "@drawable/Icon")]
	public class Activity2 : FragmentActivity
	{


		private ViewPager mViewPager;
		private SlidingTabScrollView mScrollView;





		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			 
			// Create your application here
			SetContentView(Resource.Layout.Activity2);
		    
			RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;

			mScrollView = FindViewById<SlidingTabScrollView>(Resource.Id.sliding_tabs);
			mViewPager = FindViewById<ViewPager>(Resource.Id.viewPager);

			mViewPager.Adapter = new SamplePagerAdapter(SupportFragmentManager);
			mScrollView.ViewPager = mViewPager;



		

		}



		public class SamplePagerAdapter : FragmentPagerAdapter
		{
			private List<Android.Support.V4.App.Fragment> mFragmentHolder;

			public SamplePagerAdapter (Android.Support.V4.App.FragmentManager fragManager) : base(fragManager)
			{
				mFragmentHolder = new List<Android.Support.V4.App.Fragment>();
				mFragmentHolder.Add(new Fragment1());
				mFragmentHolder.Add(new Fragment2());


			}

			public override int Count
			{
				get { return mFragmentHolder.Count; }
			}

			public override Android.Support.V4.App.Fragment GetItem(int position)
			{
				return mFragmentHolder[position];
			}
		}



		public class Fragment1 : Android.Support.V4.App.DialogFragment
		{
			
//			private TextView mTextView;
			Button mButton;
			Button sButton;
			Button snButton;
			Button pButton;



			public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
			{
				
				
				var view = inflater.Inflate(Resource.Layout.Frag1Layout, container, false);


				mButton = view.FindViewById<Button>(Resource.Id.button2);
				sButton = view.FindViewById<Button>(Resource.Id.button1);
				snButton = view.FindViewById<Button>(Resource.Id.button3);
			    pButton = view.FindViewById<Button>(Resource.Id.button4);


				mButton.Click += mButton_Click;
				sButton.Click += sButton_Click;
				snButton.Click += snButton_Click;
				pButton.Click += pButton_Click;


//				mTextView = view.FindViewById<TextView>(Resource.Id.textView1);
//				mTextView.Text = "MyBuild";


				return view;
			}

			void mButton_Click(object sender, EventArgs e)
			{
				var myintent = new Intent (this.Activity, typeof(NotesScreen));



				StartActivity (myintent);
				this.Activity.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);

			}

			void sButton_Click(object sender, EventArgs e)
			{
				var myintent = new Intent (this.Activity, typeof(ScheduleScreen));



				StartActivity (myintent);
				this.Activity.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);

			}

			void snButton_Click(object sender, EventArgs e)
			{
				var myintent = new Intent (this.Activity, typeof(SnagListscreen));



				StartActivity (myintent);
				this.Activity.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);

			}

			void pButton_Click(object sender, EventArgs e)
			{
				var myintent = new Intent (this.Activity, typeof(PhotoScreen));



				StartActivity (myintent);
				this.Activity.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);

			}

			public override string ToString() //Called on line 156 in SlidingTabScrollView
			{
				return "Project Home";
			}
		}

		public class Fragment2 : Android.Support.V4.App.ListFragment 
		{
			
			private int _currentPlayId;
			private bool _isDualPane;
//				
//			public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
//			{
				

			public override void OnActivityCreated(Bundle savedInstanceState)
			{
				base.OnActivityCreated(savedInstanceState);


//				View view = inflater.Inflate(Resource.Layout.Frag2Layout,container, false);
			

				var detailsFrame = Activity.FindViewById<View>(Resource.Id.details);

				// If running on a tablet, then the layout in Resources/Layout-Large will be loaded. 
				// That layout uses fragments, and defines the detailsFrame. We use the visiblity of 
				// detailsFrame as this distinguisher between tablet and phone.
				_isDualPane = detailsFrame != null && detailsFrame.Visibility == ViewStates.Visible;

				var adapter = new ArrayAdapter<String>(Activity, Resource.Layout.Stages, Stages.Titles);
				ListAdapter = adapter;

				if (savedInstanceState != null)
				{
					_currentPlayId = savedInstanceState.GetInt("current_play_id", 0);
				}

				if (_isDualPane)
				{
					ListView.ChoiceMode = ChoiceMode.Single;
					ShowDetails(_currentPlayId);
				}
			}

			public override void OnSaveInstanceState(Bundle outState)
			{
				base.OnSaveInstanceState(outState);
				outState.PutInt("current_play_id", _currentPlayId);
			}

			public override void OnListItemClick(ListView l, View v, int position, long id)
			{
				ShowDetails(position);
			}

			private void ShowDetails(int playId)
			{
				_currentPlayId = playId;
				if (_isDualPane) {
					// We can display everything in-place with fragments.
					// Have the list highlight this item and show the data.
					ListView.SetItemChecked (playId, true);

					// Check what fragment is shown, replace if needed.
					var details = FragmentManager.FindFragmentById (Resource.Id.details) as DetailsFragment;
					if (details == null || details.ShownPlayId != playId) {
						// Make new fragment to show this selection.
						details = DetailsFragment.NewInstance (playId);

						// Execute a transaction, replacing any existing
						// fragment with this one inside the frame.
						var ft = FragmentManager.BeginTransaction ();
						ft.Replace (Resource.Id.details, details);
						ft.SetTransition (Android.Support.V4.App.FragmentTransaction.TransitFragmentFade);
						ft.Commit ();
					}
				} else {
					// Otherwise we need to launch a new activity to display
					// the dialog fragment with selected text.
					var intent = new Intent ();

					intent.SetClass (Activity, typeof(DetailsActivity));
					intent.PutExtra ("current_play_id", playId);
					StartActivity (intent);

				}
			
				//              var view = inflater.Inflate(Resource.Layout.Frag3Layout, container, false);

//			return view;
			
			}


			public override string ToString() //Called on line 156 in SlidingTabScrollView
			{
				return "Schedule Guide";
			}
		}


			

			

			
		}
	}



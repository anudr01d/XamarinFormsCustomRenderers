using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Android.App;
using Android.Widget;
using Huntsman.Mobile.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using NavigationRenderer = Xamarin.Forms.Platform.Android.AppCompat.NavigationPageRenderer;
using Support = Android.Support.V7.Widget;
using SupActBar = Android.Support.V7.App;
using Android.Graphics;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(NavigationPageRenderer))]
namespace Huntsman.Mobile.Droid
{
		public class NavigationPageRenderer : NavigationRenderer
		{
		private Support.Toolbar toolbar;
			private TextView titleText;
			private String Title;
			private SupActBar.ActionBar SupportActionBar;

			protected override void OnElementChanged(ElementChangedEventArgs<NavigationPage> e)
			{
				base.OnElementChanged(e);
				SetCustomView(e.NewElement.CurrentPage.Title);
			}

			private void SetCustomView(string title)
			{
				titleText.Text = title;
				Console.WriteLine(title);
				this.Title = title;
				//toolbar.Title = "";
			}

			protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
			{
				base.OnElementPropertyChanged(sender, e);
				if (e.PropertyName.Equals("CurrentPage"))
				{
					SetCustomView(((NavigationPage)sender).CurrentPage.Title);
				}
			}

		protected override void OnConfigurationChanged(Android.Content.Res.Configuration newConfig)
		{
			base.OnConfigurationChanged(newConfig);
			if (this.Title != null)
			{
				SetCustomView(this.Title);
			}
		}

			public override void OnViewAdded(Android.Views.View child)
			{
				base.OnViewAdded(child);
				if (child.GetType() == typeof(Support.Toolbar))
					toolbar = (Support.Toolbar)child;
					titleText = (TextView)toolbar.FindViewById(Resource.Id.toolbar_title);
					Typeface tf = Typeface.CreateFromAsset(Context.Assets, "HelveticaNeueMed.ttf");
					titleText.SetTypeface(tf,TypefaceStyle.Normal);
					if (this.Title != null)
					{
						SetCustomView(this.Title);
					}
			}
		}
}

using System;
using System.Linq;
using Huntsman.Mobile.TorontoPU.Infrastructure.Constants;
using Huntsman.Mobile.TorontoPU.Infrastructure.Navigation;
using Huntsman.Mobile.iOS;
using Huntsman.Mobile.TorontoPU.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(CustomNavigationPageRenderer))]
namespace Huntsman.Mobile.TorontoPU.iOS
{
	class CustomNavigationPageRenderer : NavigationRenderer
	{
		private static UIImage _hamImage = new UIImage(Globals.HAMBURGER_ICON).ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
		private static UIImage _menuImage = new UIImage(Globals.CONTEXTUAL_ICON).ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
		private static UIImage _refreshImage = new UIImage(Globals.REFRESH_ICON).ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
		private static UIImage _backImage = new UIImage(Globals.BACK_ICON).ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
		private static UIImage _doneImage = new UIImage(Globals.DONE_ICON).ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);

		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null)
			{
				return;
			}

		}

		private bool set; 

		private void SetBackButton(UINavigationItem[] items)
		{
			for (int i = 1; i < items.Count(); i++)
			{
				if (items[i] != null)
				{
					var leftbtn = items[i].BackBarButtonItem;
					if (leftbtn != null)
					{
						leftbtn.Image = _backImage;
						leftbtn.SetBackButtonBackgroundImage(_backImage, UIControlState.Normal, UIBarMetrics.Default);
					}
					if (items[i].RightBarButtonItems.Length > 0)
					{
						var rightbtn = items[i].RightBarButtonItems[0];

						if (rightbtn != null)
						{
							//if (items[i].Title.Equals("My Favorites"))
							//{
							//	rightbtn.Image = _doneImage;
							//}
							//else
							//{
								rightbtn.Image = _menuImage;
							//}
						}
					}
				}
			}
		}

		private void SetHomePage(UINavigationItem[] items)
		{
			var item = items.FirstOrDefault();

			if (item != null)
			{
				if (item.LeftBarButtonItems != null)
				{
					var leftbtn = item.LeftBarButtonItems[0];
					leftbtn.Image = _hamImage;
				}
				if (item.RightBarButtonItems != null)
				{
					item.RightBarButtonItems[0].Image = _menuImage;
					if (item.RightBarButtonItems.Count() > 1)
					{
						item.RightBarButtonItems[1].Image = _refreshImage;
					}
				}
			}
		}

		public override UINavigationBar NavigationBar
		{
			get
			{

				var nav = base.NavigationBar;

				if (nav.Items.Count() > 1)
				{
					this.SetBackButton(nav.Items);
				}
				else
				{
					this.SetHomePage(nav.Items);
				}

				return nav;
			}
		}
	}
}

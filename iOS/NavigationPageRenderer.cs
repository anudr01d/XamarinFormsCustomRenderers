using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Huntsman.Mobile.iOS;
using Huntsman.Mobile.TorontoPU.Infrastructure.Navigation;
using Huntsman.Mobile.TorontoPU.Infrastructure.Constants;

[assembly: ExportRenderer(typeof(ContentPage), typeof(NavigationPageRendereriOS))]
namespace Huntsman.Mobile.iOS
{
		public class NavigationPageRendereriOS : PageRenderer
		{
			private static UIImage _backImage = new UIImage(Globals.BACK_ICON).ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
			private static UIImage _doneImage = new UIImage(Globals.DONE_ICON).ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
			private static UIImage _menuImage = new UIImage(Globals.CONTEXTUAL_ICON).ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);

			public override void ViewWillAppear(bool animated)
			{
				base.ViewWillAppear(animated);

				// If you want to hide the back button in some pages, 
				// you can pass a value to renderer and do this.
				var page = this.Element as ICanHideBackButton;
				if (page != null)
				{
					if (page.HideBackButton)
					{
						this.NavigationController.TopViewController.NavigationItem.SetHidesBackButton(true, false);
						return;
					}
				}
			if (NavigationController != null)
			{
				NavigationController.NavigationBar.BarStyle = UIBarStyle.BlackOpaque;
				NavigationController.NavigationBar.BarTintColor = UIColor.White;
				this.NavigationController.TopViewController.NavigationItem.LeftBarButtonItem =
					new UIBarButtonItem(
						UIImage.FromFile(Globals.BACK_ICON),
						UIBarButtonItemStyle.Plain,
						(sender, args) =>
						{

					NavigationController.PopViewController(true);
						});
				this.NavigationController.TopViewController.NavigationItem.LeftBarButtonItem.Image = _backImage;
				if (this.NavigationController.TopViewController.NavigationItem.RightBarButtonItem != null)
				{
					//if (this.NavigationController.TopViewController.NavigationItem.Title.Equals(Globals.MY_FAVORITES))
					//{
					//	this.NavigationController.TopViewController.NavigationItem.RightBarButtonItem.Image = _doneImage;
					//}
					//else
					//{
						this.NavigationController.TopViewController.NavigationItem.RightBarButtonItem.Image = _menuImage;
					//}
				//}
			}
				}
			}
		}
}

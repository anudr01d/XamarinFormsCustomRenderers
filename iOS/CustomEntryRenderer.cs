using System;
using CoreGraphics;
using Foundation;
using Huntsman.Mobile.iOS;
using Huntsman.Mobile.TorontoPU.iOS;
using Huntsman.Mobile.TorontoPU.UIControls.Controls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(HuntsmanEntry), typeof(CustomEntryRenderer))]
namespace Huntsman.Mobile.TorontoPU.iOS
{
	public class CustomEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);
			if (e.NewElement != null)
			{
				Control.BorderStyle = UIKit.UITextBorderStyle.None;
				var myBox = new UIView(new CGRect(0, 20, UIScreen.MainScreen.Bounds.Width - 250, 1))
				{
					BackgroundColor = UIColor.Clear.FromHex(0x033462)
				};
				Control.SizeToFit();
				Control.AddSubview(myBox);
				Control.TextColor = UIColor.Clear.FromHex(0x033462);
				Control.Font = UIFont.FromName("HelveticaNeue-Medium", 16);
				Control.SetValueForKeyPath(UIColor.Clear.FromHex(0x818181), new NSString("_placeholderLabel.textColor"));
			}
		}
	}
}

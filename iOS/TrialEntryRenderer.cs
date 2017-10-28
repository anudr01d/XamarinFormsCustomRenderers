using System;
using CoreGraphics;
using Foundation;
using Huntsman.Mobile.iOS;
using Huntsman.Mobile.TorontoPU.iOS;
using Huntsman.Mobile.TorontoPU.UIControls.Controls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TrialEntry), typeof(TrialEntryRenderer))]
namespace Huntsman.Mobile.TorontoPU.iOS
{
	public class TrialEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);
			if (e.NewElement != null)
			{
				Control.BorderStyle = UIKit.UITextBorderStyle.None;
				var myBox = new UIView(new CGRect(0, 20, e.NewElement.WidthRequest, 1))
				{
					BackgroundColor = UIColor.Clear.FromHex(0x033462)
				};
				myBox.ClipsToBounds = true;
				Control.SizeToFit();
				Control.AddSubview(myBox);
				Control.TextColor = UIColor.Clear.FromHex(0x033462);
				Control.Font = UIFont.FromName("HelveticaNeue-Medium", 16);
				Control.SetValueForKeyPath(UIColor.Clear.FromHex(0x818181), new NSString("_placeholderLabel.textColor"));
			}
		}
	}
}

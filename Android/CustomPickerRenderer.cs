using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Huntsman.Mobile.Droid;
using Xamarin.Forms.Platform.Android;
using Huntsman.Mobile.UIControls.Controls;
using Android.Content.Res;

[assembly: ExportRenderer(typeof(HuntsmanPicker), typeof(CustomPickerRenderer))]
namespace Huntsman.Mobile.Droid
{
	public class CustomPickerRenderer : PickerRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
		{
			base.OnElementChanged(e);
			Control?.SetBackgroundColor(Android.Graphics.Color.Transparent);
			Android.Graphics.Typeface tf = global::Android.Graphics.Typeface.CreateFromAsset(Context.Assets, "HelveticaNeueMed.ttf");
			Control?.SetTypeface(tf, Android.Graphics.TypefaceStyle.Normal);
			Control?.SetTextSize(Android.Util.ComplexUnitType.Sp, 16);
			Control.SetHintTextColor(ColorStateList.ValueOf(global::Android.Graphics.Color.Rgb(128, 128, 128)));
			
		}
	}
}
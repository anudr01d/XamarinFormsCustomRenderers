using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using System.ComponentModel;
using Android.Graphics.Drawables;
using Xamarin.Forms;
using Huntsman.Mobile.Droid;
using Huntsman.Mobile.UIControls.Controls;
using Huntsman.Mobile.Infrastructure.Constants;

[assembly: ExportRenderer(typeof(PopupButton), typeof(PopupButtonRenderer))]
namespace Huntsman.Mobile.Droid
{
    public class PopupButtonRenderer : ButtonRenderer
    {
        private GradientDrawable _normal, _pressed;
		private PopupButton btn;

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                var button = e.NewElement;
				btn = e.NewElement as PopupButton;

                // Create a drawable for the button's normal state
                _normal = new Android.Graphics.Drawables.GradientDrawable();

				if (button.BackgroundColor.R == -1.0 && button.BackgroundColor.G == -1.0 && button.BackgroundColor.B == -1.0)
					_normal.SetColor(Android.Graphics.Color.ParseColor(Globals.WHITE));
				else
					if (button.BackgroundColor != Color.Black)
				{
					_normal.SetColor(button.BackgroundColor.ToAndroid());
				}
				else {
						_normal.SetColor(Android.Graphics.Color.ParseColor(Globals.WHITE));	
				}

                _normal.SetStroke((int)button.BorderWidth, button.BorderColor.ToAndroid());
                _normal.SetCornerRadius(10);

                // Create a drawable for the button's pressed state
                _pressed = new Android.Graphics.Drawables.GradientDrawable();
				var highlight = Context.ObtainStyledAttributes(new int[] { Android.Resource.Attribute.ColorActivatedHighlight }).GetColor(0, Android.Graphics.Color.ParseColor(Globals.RED));
                _pressed.SetColor(highlight);
                _pressed.SetStroke((int)button.BorderWidth, button.BorderColor.ToAndroid());
                _pressed.SetCornerRadius(button.BorderRadius);

                // Add the drawables to a state list and assign the state list to the button
                var sld = new StateListDrawable();
                sld.AddState(new int[] { Android.Resource.Attribute.StatePressed }, _pressed);
                sld.AddState(new int[] { }, _normal);
                Control.SetBackgroundDrawable(sld);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var button = (Xamarin.Forms.Button)sender;

            if (_normal != null && _pressed != null)
            {
                if (e.PropertyName == "BorderRadius")
                {
                    _normal.SetCornerRadius(button.BorderRadius);
                    _pressed.SetCornerRadius(button.BorderRadius);
                }
                if (e.PropertyName == "BorderWidth" || e.PropertyName == "BorderColor")
                {
                    _normal.SetStroke((int)button.BorderWidth, button.BorderColor.ToAndroid());
                    _pressed.SetStroke((int)button.BorderWidth, button.BorderColor.ToAndroid());
                }
				if (btn!=null && btn.IsBtnEnabled)
				{
					_normal.SetColor(Android.Graphics.Color.ParseColor(Globals.BLUE));
					_pressed.SetColor(Android.Graphics.Color.ParseColor(Globals.BLUE));
				}
            }
        }
    }
}


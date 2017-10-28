using System;
using Huntsman.Mobile.Droid;
using Huntsman.Mobile.UIControls.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SpacedHuntsmanLabel), typeof(LetterSpacingRenderer))]
namespace Huntsman.Mobile.Droid
{
	public class LetterSpacingRenderer : LabelRenderer
	{
		protected SpacedHuntsmanLabel LetterSpacingLabel { get; private set; }

		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement == null)
			{
				this.LetterSpacingLabel = (SpacedHuntsmanLabel)this.Element;
			}

			//var letterSpacing = this.LetterSpacingLabel.LetterSpacing;
			this.Control.LetterSpacing = 0.1f;

			this.UpdateLayout();
		}
	}
}


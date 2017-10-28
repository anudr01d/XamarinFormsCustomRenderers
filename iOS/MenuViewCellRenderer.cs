using System;
using Huntsman.Mobile.iOS;
using Huntsman.Mobile.TorontoPU.iOS;
using Huntsman.Mobile.TorontoPU.UIControls.Controls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MenuViewCell), typeof(MenuViewCellRenderer))]
namespace Huntsman.Mobile.TorontoPU.iOS
{
	public class MenuViewCellRenderer : ViewCellRenderer
	{
		private UIView bgView;

		public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
		{
			var cell = base.GetCell(item, reusableCell, tv);
			cell.BackgroundColor = UIColor.White;
			cell.TextLabel.TextColor = UIColor.White;

			if (bgView == null)
			{
				bgView = new UIView(cell.SelectedBackgroundView.Bounds)
				{
					BackgroundColor = UIColor.Clear
				};
			}

			cell.SelectedBackgroundView = bgView;

			return cell;
		}
	}
}

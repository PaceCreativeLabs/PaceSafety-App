//using System;
//using Xamarin.Forms;
//using 
//
//[assembly: ExportRenderer(typeof(ContentPage), typeof(ExtendedPageRenderer))]
//
//public class ExtendedPageRenderer : PageRenderer
//{
//	public override void ViewWillAppear(bool animated)
//	{
//		base.ViewWillAppear(animated);
//
//		var contentPage = this.Element as ContentPage;
//		if (contentPage == null || NavigationController == null)
//		{
//			return;
//		}
//
//		var itemsInfo = contentPage.ToolbarItems;
//
//		var navigationItem = this.NavigationController.TopViewController.NavigationItem;
//		var leftNativeButtons = (navigationItem.LeftBarButtonItems ?? new UIBarButtonItem[] { }).ToList();
//		var rightNativeButtons = (navigationItem.RightBarButtonItems ?? new UIBarButtonItem[] { }).ToList();
//
//		rightNativeButtons.ForEach(nativeItem =>
//			{
//				// [Hack] Get Xamarin private field "item"
//				var field = nativeItem.GetType().GetField("item", BindingFlags.NonPublic | BindingFlags.Instance);
//				if (field == null)
//				{
//					return;
//				}
//
//				var info = field.GetValue(nativeItem) as ToolbarItem;
//				if (info != null && info.Priority != 0)
//				{
//					return;
//				}
//
//				rightNativeButtons.Remove(nativeItem);
//				leftNativeButtons.Add(nativeItem);
//			});
//
//		navigationItem.RightBarButtonItems = rightNativeButtons.ToArray();
//		navigationItem.LeftBarButtonItems = leftNativeButtons.ToArray();
//	}
//
//}
using Android.Content;
using Android.Views;


using System.ComponentModel;

using Xamarin.Forms;

[assembly: ExportRenderer(typeof(Xamarin.Forms.RoundedBoxView), typeof(Xamarin.Forms.Platform.Android.RoundedBoxViewRenderer))]
namespace Xamarin.Forms.Platform.Android
{
	public class RoundedBoxViewRenderer : VisualElementRenderer<RoundedBoxView>
	{
		public RoundedBoxViewRenderer(Context context)
			: base(context)
		{
			AutoPackage = false;
			Background = new global::Android.Graphics.Drawables.GradientDrawable();
		}

		private global::Android.Graphics.Drawables.GradientDrawable BackgroundGradient => Background as global::Android.Graphics.Drawables.GradientDrawable;

		public override bool OnTouchEvent(MotionEvent e)
		{
			Parent.RequestDisallowInterceptTouchEvent(true);
			return base.OnTouchEvent(e);
		}

		protected override void OnElementChanged(ElementChangedEventArgs<RoundedBoxView> e)
		{
			base.OnElementChanged(e);
			if (Element == null)
			{
				return;
			}

			UpdateBackgroundColor();
			UpdateRadius();
			UpdateBorder();
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == BoxView.ColorProperty.PropertyName || e.PropertyName == VisualElement.BackgroundColorProperty.PropertyName)
			{
				UpdateBackgroundColor();
			}
			else if (e.PropertyName == RoundedBoxView.BorderRadiusProperty.PropertyName)
			{
				UpdateRadius();
			}
			else if (e.PropertyName == RoundedBoxView.BorderWidthProperty.PropertyName || e.PropertyName == RoundedBoxView.BorderColorProperty.PropertyName)
			{
				UpdateBorder();
			}
		}

		protected override void UpdateBackgroundColor()
		{
			var colorToSet = Element.Color;

			if (colorToSet == Color.Default)
			{
				colorToSet = Element.BackgroundColor;
			}

			Background = new global::Android.Graphics.Drawables.GradientDrawable();
			BackgroundGradient?.SetColor(colorToSet.ToAndroid());
		}

		private void UpdateBorder()
		{
			BackgroundGradient?.SetStroke((int)Element.BorderWidth, Element.BorderColor.ToAndroid());
		}

		private void UpdateRadius()
		{
			BackgroundGradient?.SetCornerRadius((float)Element.BorderRadius * 4);
		}
	}
}
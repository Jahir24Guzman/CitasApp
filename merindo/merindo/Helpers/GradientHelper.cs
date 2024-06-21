using Xamarin.Forms;

namespace merindo.Helpers
{
    public class GradientHelper : VisualElement
    {
        public GradientHelper()
        {
        }

        public static readonly BindableProperty StartColorProperty = BindableProperty.Create(
            nameof(StartColor), typeof(Color), typeof(GradientHelper), Color.Default);

        public Color StartColor
        {
            get { return (Color)GetValue(StartColorProperty); }
            set { SetValue(StartColorProperty, value); }
        }

        public static readonly BindableProperty EndColorProperty = BindableProperty.Create(
            nameof(EndColor), typeof(Color), typeof(GradientHelper), Color.Default);

        public Color EndColor
        {
            get { return (Color)GetValue(EndColorProperty); }
            set { SetValue(EndColorProperty, value); }
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();
            Background = new LinearGradientBrush
            {
                GradientStops = new GradientStopCollection
                {
                    new GradientStop { Color = StartColor, Offset = 0.0f },
                    new GradientStop { Color = EndColor, Offset = 1.0f }
                }
            };
        }
    }
}
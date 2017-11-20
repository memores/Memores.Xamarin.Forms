using Xamarin.Forms;
using System.ComponentModel;
using Memores.Xamarin.Forms.Controls.Abstract;

namespace Memores.Xamarin.Forms.Controls
{
    public class MaskedEntry : Entry, IMaskedEntry {
        public static BindableProperty MaskProperty = BindableProperty.Create<MaskedEntry, string>(x => x.Mask, default(string));

        public static BindableProperty UnmaskedTextProperty = BindableProperty.Create<MaskedEntry, string>(x => x.Mask, default(string));

        /// <summary>
        /// Mask for entry text value
        /// </summary>
        public string Mask
        {
            get { return (string)GetValue(MaskProperty); }
            set { SetValue(MaskProperty, value); }
        }

        /// <summary>
        /// Text without mask
        /// </summary>
        public string UnmaskedText
        {
            get { return (string)GetValue(UnmaskedTextProperty); }
            set { SetValue(UnmaskedTextProperty, value); }
        }

        public MaskedEntry() {
            TextChanged += OnTextChanged;
        }

        void OnTextChanged(object sender, TextChangedEventArgs textChangedEventArgs) {
            if (string.IsNullOrWhiteSpace(Mask))
                UnmaskedText = Text;

            var maskedTextProvider = new MaskedTextProvider(Mask);

            maskedTextProvider.Set(textChangedEventArgs.NewTextValue);
            UnmaskedText = maskedTextProvider.ToString(false, false);

            maskedTextProvider.Set(UnmaskedText);

            if (maskedTextProvider.VerifyString(textChangedEventArgs.NewTextValue) && !string.IsNullOrWhiteSpace(UnmaskedText))
                Text = maskedTextProvider.ToString(0, textChangedEventArgs.NewTextValue.Length + 1);
        }
    }
}

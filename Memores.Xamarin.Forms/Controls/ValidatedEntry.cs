using System;
using System.Text.RegularExpressions;
using Memores.Xamarin.Forms.Controls.Abstract;
using Xamarin.Forms;

namespace Memores.Xamarin.Forms.Controls {
    public class ValidatedEntry : Entry, IValidatedEntry {
        public static BindableProperty RegexPatternProperty = BindableProperty.Create<ValidatedEntry, string>(x => x.RegexPattern, default(string));

        public static BindableProperty MatchColorProperty = BindableProperty.Create<ValidatedEntry, Color>(x => x.MatchColor, Color.Default);

        public static BindableProperty DismatchColorProperty = BindableProperty.Create<ValidatedEntry, Color>(x => x.DismatchColor, Color.Default);

        /// <summary>
        /// Regex pattern for entry text value
        /// </summary>
        public string RegexPattern {
            get { return (string) GetValue(RegexPatternProperty); }
            set { SetValue(RegexPatternProperty, value); }
        }

        /// <summary>
        /// Color for text when entry text matched regex pattern
        /// </summary>
        public Color MatchColor {
            get { return (Color) GetValue(MatchColorProperty); }
            set { SetValue(MatchColorProperty, value); }
        }

        /// <summary>
        /// Color for text when entry text didn`t matched regex pattern
        /// </summary>
        public Color DismatchColor {
            get { return (Color) GetValue(DismatchColorProperty); }
            set { SetValue(DismatchColorProperty, value); }
        }


        public ValidatedEntry() {
            TextChanged += OnTextChanged;
        }

        void OnTextChanged(object sender, TextChangedEventArgs e) {
            var pattern = RegexPattern ?? string.Empty;
            TextColor = Regex.IsMatch(e.NewTextValue, pattern, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(100))
                ? MatchColor
                : DismatchColor;
        }
    }
}


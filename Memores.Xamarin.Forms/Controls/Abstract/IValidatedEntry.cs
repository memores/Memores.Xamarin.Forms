using Xamarin.Forms;

namespace Memores.Xamarin.Forms.Controls.Abstract {
    public interface IValidatedEntry {
        /// <summary>
        /// Regex pattern for entry text value
        /// </summary>
        string RegexPattern { get; set; }

        /// <summary>
        /// Color for text when entry text matched regex pattern
        /// </summary>
        Color MatchColor { get; set; }

        /// <summary>
        /// Color for text when entry text didn`t matched regex pattern
        /// </summary>
        Color DismatchColor { get; set; }
    }
}
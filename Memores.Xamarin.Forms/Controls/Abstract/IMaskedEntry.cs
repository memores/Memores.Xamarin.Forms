namespace Memores.Xamarin.Forms.Controls.Abstract {
    public interface IMaskedEntry {
        /// <summary>
        /// Mask for entry text value
        /// </summary>
        string Mask { get; set; }


        /// <summary>
        /// Text without mask
        /// </summary>
        string UnmaskedText { get; set; }
    }
}
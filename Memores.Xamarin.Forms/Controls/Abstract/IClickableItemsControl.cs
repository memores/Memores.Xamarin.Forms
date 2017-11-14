using System.Windows.Input;

namespace Memores.Xamarin.Forms.Controls.Abstract {
    public interface IClickableItemsControl {
        ICommand ItemClickCommand { get; set; }
    }
}
using System.Windows.Input;
using Xamarin.Forms;
using Memores.Xamarin.Forms.Controls.Abstract;

namespace Memores.Xamarin.Forms.Controls {
    public class ClickableListView : ListView, IClickableItemsControl {
        public static BindableProperty ItemClickCommandProperty = BindableProperty.Create<ClickableListView, ICommand>(x => x.ItemClickCommand, null);

        public ICommand ItemClickCommand {
            get { return (ICommand) GetValue(ItemClickCommandProperty); }
            set { SetValue(ItemClickCommandProperty, value); }
        }


        public ClickableListView() {
            ItemTapped += OnItemTapped;
        }


        void OnItemTapped(object sender, ItemTappedEventArgs args) {
            if (args.Item != null && ItemClickCommand != null && ItemClickCommand.CanExecute(args)) {
                ItemClickCommand.Execute(args.Item);
                SelectedItem = null;
            }
        }
    }
}
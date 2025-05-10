using CommunityToolkit.Mvvm.ComponentModel;
using EnterDeleter.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace EnterDeleter.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string _oldText = "";

        [ObservableProperty]
        private string _newText = "";

        [ObservableProperty]
        private string _deleteText = "";

        [ObservableProperty]
        private string _regextText = "";

        [ObservableProperty]
        private int _selectIndexDeleteSymbol;

        [ObservableProperty]
        private List<StandardSymbols> _standardDeleteSymbols =
        [
            new StandardSymbols() { Title = "None", ItemShow = "\"\"", Item = "" },
            new StandardSymbols() { Title = "Enter", ItemShow = "\"\\n\"", Item = "\n" },
            new StandardSymbols() { Title = "Space", ItemShow = "\" \"", Item = " " },
            new StandardSymbols() { Title = "Tab", ItemShow = "\"\\t\"", Item = "\t" }
        ];

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if (e.PropertyName is nameof(OldText) or nameof(SelectIndexDeleteSymbol) or nameof(DeleteText) or nameof(RegextText))
            {
                DeleteSymbols();
            }
        }

        private void DeleteSymbols()
        {
            string newText = OldText;

            if (SelectIndexDeleteSymbol != 0)
            {
                newText = newText.Replace(StandardDeleteSymbols[SelectIndexDeleteSymbol].Item, string.Empty);
            }

            if (!string.IsNullOrEmpty(DeleteText))
            {
                newText = newText.Replace(DeleteText, string.Empty);
            }

            newText = newText.Replace("\r", string.Empty);

            NewText = newText;
        }
    }
}

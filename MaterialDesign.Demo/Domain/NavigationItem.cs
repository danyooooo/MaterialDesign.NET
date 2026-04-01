using MaterialDesign.NET.Controls;

namespace MaterialDesign.Demo.Domain
{
    public class NavigationItem : ViewModelBase
    {
        private string _name;
        private object _content;
        private PackIconKind _symbol;
        private bool _isSelected;

        public NavigationItem(string name, object content, PackIconKind symbol)
        {
            _name = name;
            _content = content;
            _symbol = symbol;
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public object Content
        {
            get => _content;
            set => SetProperty(ref _content, value);
        }

        public PackIconKind Symbol
        {
            get => _symbol;
            set => SetProperty(ref _symbol, value);
        }

        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }
    }
}

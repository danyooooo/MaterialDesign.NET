using System.Collections.ObjectModel;
using MaterialDesign.Demo.Pages;
using MaterialDesign.NET.Controls;
using System.Windows.Input;

namespace MaterialDesign.Demo.Domain
{
    public class MainViewModel : ViewModelBase
    {
        private object? _currentPage;
        private NavigationItem? _selectedNavigationItem;

        public bool IsDialogClosed => !IsDialogOpen;

        private bool _isDialogOpen;
        public bool IsDialogOpen
        {
            get => _isDialogOpen;
            set => SetProperty(ref _isDialogOpen, value);
        }

        private object? _dialogContent;
        public object? DialogContent
        {
            get => _dialogContent;
            set => SetProperty(ref _dialogContent, value);
        }

        public ICommand OpenDialogCommand { get; }
        public ICommand CloseDialogCommand { get; }

        public MainViewModel()
        {
            NavigationItems = new ObservableCollection<NavigationItem>
            {
                new NavigationItem("Home", new Home(), PackIconKind.Home),
                new NavigationItem("Buttons", new Buttons(), PackIconKind.SmartButton),
                new NavigationItem("Icon Buttons", new IconButtons(), PackIconKind.Add),
                new NavigationItem("Selection Controls", new SelectionControls(), PackIconKind.CheckBox),
                new NavigationItem("Floating Action Buttons", new FloatingActionButtons(), PackIconKind.AddCircle),
                new NavigationItem("Cards", new Cards(), PackIconKind.Dashboard),
                new NavigationItem("TextFields", new TextFields(), PackIconKind.TextFields),
                new NavigationItem("Color Palette", new Palette(), PackIconKind.Palette),
                new NavigationItem("Typography", new Typography(), PackIconKind.FormatSize),
                new NavigationItem("Chips", new Chips(), PackIconKind.Label),
                new NavigationItem("Progress", new Progress(), PackIconKind.Refresh),
                new NavigationItem("Dialogs", new Dialogs(), PackIconKind.ChatBubble),
                new NavigationItem("Navigation Drawer", new NavigationDrawerPage(), PackIconKind.MenuOpen),
                new NavigationItem("Tabs", new Tabs(), PackIconKind.Tab),
                new NavigationItem("Snackbars", new Snackbars(), PackIconKind.ChatBubble),
                new NavigationItem("Sliders", new Sliders(), PackIconKind.Tune),
                new NavigationItem("Tooltips", new Tooltips(), PackIconKind.Info),
                new NavigationItem("Badges", new Badges(), PackIconKind.Notifications),
                new NavigationItem("Lists", new Lists(), PackIconKind.List),
                new NavigationItem("Divider", new Divider(), PackIconKind.List),
                new NavigationItem("Menus", new Menus(), PackIconKind.MenuOpen)
            };

            SelectedNavigationItem = NavigationItems[0];

            OpenDialogCommand = new DelegateCommand(OpenDialog);
            CloseDialogCommand = new DelegateCommand(_ => IsDialogOpen = false);
        }

        private void OpenDialog(object? parameter)
        {
            if (parameter is string s && s == "Alert")
            {
                DialogContent = new ConfirmationDialogViewModel
                {
                    Title = "Permissions Request",
                    Message = "Material Design would like to send you notifications."
                };
            }
            else
            {
                DialogContent = new SimpleDialogContent { Header = "Alert", Message = parameter?.ToString() ?? "Default Dialog Content" };
            }
            IsDialogOpen = true;
        }

        public void ShowDialog(string title, string message)
        {
            DialogContent = new SimpleDialogContent { Header = title, Message = message };
            IsDialogOpen = true;
        }

        public ObservableCollection<NavigationItem> NavigationItems { get; }

        public object? CurrentPage
        {
            get => _currentPage;
            private set => SetProperty(ref _currentPage, value);
        }

        public NavigationItem? SelectedNavigationItem
        {
            get => _selectedNavigationItem;
            set
            {
                if (SetProperty(ref _selectedNavigationItem, value))
                {
                    if (value != null)
                    {
                        CurrentPage = value.Content;
                    }
                }
            }
        }
    }
}

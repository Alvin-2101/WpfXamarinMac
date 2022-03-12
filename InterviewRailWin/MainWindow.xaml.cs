using System.Reactive.Disposables;
using ReactiveUI;
using UI;

namespace InterviewRailWin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ReactiveWindow<MainViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new MainViewModel();
            this.WhenActivated(disposableRegistration =>
            {
                this.OneWayBind(ViewModel,
                        viewModel => viewModel.Stations,
                        view => view.StationDataGrid.ItemsSource)
                    .DisposeWith(disposableRegistration);
            });
        }
    }
}

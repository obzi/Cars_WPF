using Cars_WPF.ViewModel;
using System.Windows;

namespace Cars_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel viewModel;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new MainViewModel();
            DataContext = viewModel;
        }

        /// <summary>
        /// Načte soubor.
        /// </summary>
        public void FileLoad(object sender, RoutedEventArgs e)
        {
            viewModel.FileLoad();
        }

        /// <summary>
        /// Vyfiltruje auta dle datumu prodeje.
        /// </summary>
        /// <param name="cars">Kolekce všech aut. </param>
        /// <param name="from">Od </param>
        /// <param name="to">Do </param>
        /// <returns>Kolekce aut vyhovující podmínce. </returns>
        public void Filter(object sender, RoutedEventArgs e)
        {
            viewModel.FilterByDate(FromDate.SelectedDate, ToDate.SelectedDate);
        }
    }
}
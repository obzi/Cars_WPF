using Cars_WPF.DataManagment;
using Cars_WPF.Interfaces;
using Cars_WPF.Model;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace Cars_WPF.ViewModel
{
    public class MainViewModel : Bindable
    {
        private FilterActions function;

        private ObservableCollection<Car> cars;

        private ObservableCollection<Car> avgResults;

        private ObservableCollection<Car> internCollectionOfAllCars;

        private IDataSerializer dataSerializer;

        /// <summary>
        /// Kolekce aut svázaná s komponentou ListView.
        /// </summary>
        [XmlElement(ElementName = "cars")]
        public ObservableCollection<Car> Cars
        {
            get
            {
                return cars;
            }

            set
            {
                cars = value;
                OnPropertyChanged("Cars");
            }
        }


        public ObservableCollection<Car> AVGResults
        {
            get
            {
                return avgResults;
            }
            set
            {
                avgResults = value;
                OnPropertyChanged("AVGResults");
            }
        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        public MainViewModel()
        {
            function = new FilterActions();
            Cars = new ObservableCollection<Car>();
            AVGResults = new ObservableCollection<Car>();
        }

        /// <summary>
        /// Načte soubor.
        /// </summary>
        public async void FileLoad()
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();

                bool? open = dialog.ShowDialog();

                if (open.HasValue && open.Value)
                {
                    string extension = dialog.SafeFileName.Split('.')[1];
                    dataSerializer = new SerializerFactory().Createinstance(extension);
                    internCollectionOfAllCars = await dataSerializer?.FileLoad(dialog.FileName);
                    Cars = internCollectionOfAllCars;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading file!" + "/n" + ex);
            }
        }

        /// <summary>
        /// Vyfiltruje auta dle datumu prodeje.
        /// </summary>
        /// <param name="cars">Kolekce všech aut. </param>
        /// <param name="from">Od </param>
        /// <param name="to">Do </param>
        /// <returns>Kolekce aut vyhovující podmínce. </returns>
        public async Task FilterByDate(DateTime? from, DateTime? to)
        {
            if (from == null || to == null || internCollectionOfAllCars == null)
                MessageBox.Show("Nevyplněné datum nebo kolekce aut !");

            else
                AVGResults = await function.FilterByDate(internCollectionOfAllCars, from, to);
        }
    }
}
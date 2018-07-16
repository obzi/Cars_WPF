using Cars_WPF.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_WPF.DataManagment
{
    /// <summary>
    /// Třída reprezentující akce pro filtrování kolekce dat.
    /// </summary>
    public class FilterActions
    {    
        /// <summary>
        /// Vyfiltruje auta dle datumu prodeje.
        /// </summary>
        /// <param name="cars">Kolekce všech aut. </param>
        /// <param name="from">Od </param>
        /// <param name="to">Do </param>
        /// <returns>Kolekce aut vyhovující podmínce. </returns>
        public async Task<ObservableCollection<Car>> FilterByDate(ObservableCollection<Car> cars, DateTime? from, DateTime? to)
        {
            return await Task.Run(
                () => new ObservableCollection<Car>(cars.Where(car => 
                    DateTime.Parse(car.Date).Ticks > from?.Date.Ticks && 
                    DateTime.Parse(car.Date).Ticks < to?.Date.Ticks).OrderBy(x => x.Date))                
            );
        }
    }
}

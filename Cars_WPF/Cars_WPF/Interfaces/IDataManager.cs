using Cars_WPF.Model;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Cars_WPF.Interfaces
{
    public interface IDataSerializer
    {
        /// <summary>
        /// Zajišťuje načtení dat ze souboru a jejich deserializaci.
        /// </summary>
        /// <param name="path">Cesta k souboru. </param>
        /// <returns>Kolekci aut. </returns>
        Task<ObservableCollection<Car>> FileLoad(string path);
    }
}

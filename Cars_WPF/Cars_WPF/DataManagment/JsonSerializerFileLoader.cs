using Cars_WPF.Interfaces;
using Cars_WPF.Model;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;

namespace Cars_WPF.DataManagment
{
    /// <summary>
    /// Třída zajišťující načtení dat ze souboru typu json.
    /// </summary>
    public class JsonSerializerFileLoader : IDataSerializer
    {
        /// <summary>
        /// Zajišťuje načtení dat ze souboru a jejich deserializaci.
        /// </summary>
        /// <param name="path">Cesta k souboru. </param>
        /// <returns>Kolekci aut. </returns>
        public async Task<ObservableCollection<Car>> FileLoad(string path)
        {
            return await Task.Run(() =>
            {
                CarCollection cars = JsonConvert.DeserializeObject<CarCollection>(File.ReadAllText(path));

                return new ObservableCollection<Car>(cars.Cars);
            });
        }
    }
}
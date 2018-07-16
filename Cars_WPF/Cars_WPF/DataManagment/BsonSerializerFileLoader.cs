using Cars_WPF.Interfaces;
using Cars_WPF.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;

namespace Cars_WPF.DataManagment
{
    /// <summary>
    /// Třída zajišťující načtení dat ze souboru typu bson.
    /// </summary>
    public class BsonSerializerFileLoader : IDataSerializer
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
                MemoryStream ms = new MemoryStream(File.ReadAllBytes(path));

                CarCollection car;

                using (var br = new BsonDataReader(ms))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    car = serializer.Deserialize<CarCollection>(br);
                }

                return new ObservableCollection<Car>(car.Cars);
            });
        }
    }
}

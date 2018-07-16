using Cars_WPF.Interfaces;
using Cars_WPF.Model;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Cars_WPF.DataManagment
{
    /// <summary>
    /// Třída zajišťující načtení dat ze souboru typu xml.
    /// </summary>
    public class XmlSerializerFileLoader : IDataSerializer
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
                CarCollection cars = null;
                XmlSerializer xmlSer = new XmlSerializer(typeof(CarCollection));
                XDocument xDoc = XDocument.Load(path);
                cars = (CarCollection)xmlSer.Deserialize(xDoc.Root.CreateReader());

                return new ObservableCollection<Car>(cars.Cars);
            });
        }
    }
}

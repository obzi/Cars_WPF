using Cars_WPF.Interfaces;
using Cars_WPF.Model;
using Cars_WPF.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;

namespace UnitTests
{
    /// <summary>
    /// Třída testující funkcionalitu rozraní IDataSerializer.
    /// </summary>
    [TestClass]
    public class IDataManagerTests
    {
        /// <summary>
        /// TestContext
        /// </summary>
        public TestContext TestContext
        {
            get; set;
        }

        /// <summary>
        /// Metoda testující serializaci dat.
        /// </summary>
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"D:\Visual Studio 2017\Cars_WPF\Cars_WPF\UnitTests\Resources\CarFileNames.csv", "CarFileNames#csv", DataAccessMethod.Sequential)]
        public void FileLoadTest()
        {
            // arrange
            string fileName = TestContext.DataRow["fileName"].ToString();
            string extension = fileName.Split('.')[1];

            PrivateObject obj = new PrivateObject(new MainViewModel());            
            IDataSerializer dataManager = (IDataSerializer)obj.Invoke("getDataSerializer", extension);

            // act
            ObservableCollection<Car> cars = dataManager.FileLoad(@"D:\Visual Studio 2017\Cars_WPF\Cars_WPF\UnitTests\Resources\" + fileName).Result;

            // assert
            Assert.IsTrue(cars != null && cars.Count > 1);
        }
    }
}

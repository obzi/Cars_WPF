using Cars_WPF.DataManagment;
using Cars_WPF.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.ObjectModel;

namespace UnitTests
{
    /// <summary>
    /// Třída testující funcionalitu filtrování kolekce dat.
    /// </summary>
    [TestClass]
    public class FilterFunctionTests
    {
        /// <summary>
        /// Testuje metodu filtrující kolekci aut podle data prodeje.
        /// </summary>
        [TestMethod]
        public void FilterByDateTest()
        {
            // arrange
            string fileName = "Cars.json";
            FilterActions function = new FilterActions();
            JsonSerializerFileLoader dataManager = new JsonSerializerFileLoader();

            ObservableCollection<Car> cars = dataManager.FileLoad(@"D:\Visual Studio 2017\Cars_WPF\Cars_WPF\UnitTests\Resources\" + fileName).Result;
            DateTime? from = new DateTime(2004, 5, 6);
            DateTime? to = DateTime.Now;

            // act
            ObservableCollection<Car> collectionOfCars = function.FilterByDate(cars, from, to).Result;

            // assert
            foreach (Car car in collectionOfCars)
                if (DateTime.Parse(car.Date) < from || DateTime.Parse(car.Date) > to)
                    Assert.Fail("Test selhal !");
        }
    }
}

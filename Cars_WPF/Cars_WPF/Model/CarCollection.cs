using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace Cars_WPF.Model
{
    /// <summary>
    /// Třída reprezentující kolekci všech aut.
    /// </summary>
    [Serializable()]
    [XmlRoot("root")]
    public class CarCollection
    {
        /// <summary>
        /// Kolekce aut.
        /// </summary>
        [JsonProperty("cars")]
        [XmlArray("cars")]
        [XmlArrayItem("car", typeof(Car))]
        public Car[] Cars { get; set; }
    }
}
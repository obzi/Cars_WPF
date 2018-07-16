using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace Cars_WPF.Model
{
    /// <summary>
    /// Třída reprezentující objekt auta.
    /// </summary>
    [Serializable]
    public class Car
    {
        /// <summary>
        /// Model auta.
        /// </summary>
        [JsonProperty("model")]
        [XmlElement(ElementName = "model")]        
        public string Model { get; set; }

        /// <summary>
        /// Typ auta.
        /// </summary>
        [JsonProperty("type")]
        [XmlElement(ElementName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Cena auta.
        /// </summary>
        [JsonProperty("price")]
        [XmlElement(ElementName = "price")]
        public int Price { get; set; }

        /// <summary>
        /// Datum prodeje auta.
        /// </summary>
        [JsonProperty("date")]
        [XmlElement(ElementName = "date")]
        public string Date { get; set; }
    }
}

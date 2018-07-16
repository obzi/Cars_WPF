using Cars_WPF.Enums;
using Cars_WPF.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Cars_WPF.DataManagment
{
    public class SerializerFactory
    {
        /// <summary>
        /// Seznam podporovaných serializerů.
        /// </summary>
        private Dictionary<FileExtension, IDataSerializer> dataManagers =
            new Dictionary<FileExtension, IDataSerializer>
            {
                    { FileExtension.XML, new XmlSerializerFileLoader() },
                    { FileExtension.JSON, new JsonSerializerFileLoader() },
                    { FileExtension.BSON, new BsonSerializerFileLoader() }
            };

        /// <summary>
        /// Získá a vrací správný serializer dat.
        /// </summary>
        /// <param name="extension">Přípona souboru.</param>
        /// <returns>Serializer dat.</returns>
        public IDataSerializer Createinstance(string extension)
        {
            if (dataManagers.TryGetValue((FileExtension)Enum.Parse(typeof(FileExtension), extension, true),
                out IDataSerializer result))
                return result;
            else
            {
                MessageBox.Show("Not supported file extension!");
                return null;
            }
        }
    }
}

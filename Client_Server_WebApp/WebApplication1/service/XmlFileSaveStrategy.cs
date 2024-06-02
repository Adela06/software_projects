using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using static WebApplication1.service.plantServiceFull;
using System.Xml.Serialization;
using WebApplication1.model;

namespace WebApplication1.service
{
    public class XmlFileSaveStrategy : IFileSaveStrategy
    {
        public void Save(List<Plant> plants, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Plant>));
            using (TextWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, plants);
            }
        }
    }
}
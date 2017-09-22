using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Sql_to_CS_Class_Generator
{
    public static class ObjectToXmlHelper
    {
        public static T ToObject<T>(string xml) where T : new()
        {
            using (var reader = new StringReader(xml))
            using (var xmlReader = new XmlTextReader(reader))
                return (T)new XmlSerializer(typeof(T))
                    .Deserialize(xmlReader);
        }

        public static string ToXml<T>(T obj)
        {
            using (var writer = new StringWriter())
            {
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, obj);
                return writer.ToString();
            }
        }
    }
}
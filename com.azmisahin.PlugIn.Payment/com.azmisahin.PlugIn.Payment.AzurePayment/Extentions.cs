using System.Configuration;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
namespace com.azmisahin.PlugIn.Payment.AzurePayment
{
    /// <summary>
    /// Extenstions
    /// </summary>
    public static class Extentions
    {
        /// <summary>
        /// Serilize Extentions
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="toSerialize"></param>
        /// <returns></returns>
        public static string SerializeObject<T>(this T model)
        {
            var result = string.Empty;
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = false,
                Encoding = Encoding.UTF8
            };
            MemoryStream memoryStream = new MemoryStream();
            XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(model.GetType());
            var xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add("", "");
            xmlSerializer.Serialize(xmlWriter, model, xmlSerializerNamespaces);
            memoryStream.Position = 0;
            StreamReader streamReader = new StreamReader(memoryStream);
            result = streamReader.ReadToEnd();
            return result;
        }

        /// <summary>
        /// DeSerialize
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="toDeserialize"></param>
        /// <returns></returns>
        public static object DeserializeObject<T>(this string toDeserialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            StringReader textReader = new StringReader(toDeserialize);
            return xmlSerializer.Deserialize(textReader);
        }


        /// <summary>
        /// App Setting Value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string appSettingValue(this string key)
        {
            var value = ConfigurationManager.AppSettings[key].ToString();
            return value;
        }
    }
}
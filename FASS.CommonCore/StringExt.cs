namespace FASS.CommonCore
{
    using Newtonsoft.Json;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    using System.Xml.Serialization;

    public static class StringExt
    {
        public static T JsonStringToObject<T>(this string strJson) where T : class
        {
            if (string.IsNullOrEmpty(strJson))
                return null;
            return JsonConvert.DeserializeObject<T>(strJson);
        }


        public static string ObjectToJsonString(this object obj)
        {
            if (obj == null)
                return string.Empty;
            string ObjectToJsonString = JsonConvert.SerializeObject(obj);
            return ObjectToJsonString;
        }


        public static T XmlStringToObject<T>(this string strXml) where T : class,new()
        {
            T t = new T();
            if (string.IsNullOrEmpty(strXml))
                return t;
            using (StringReader sr = new StringReader(strXml))
            {
                XmlSerializer xz = new XmlSerializer(typeof(T));
                t= xz.Deserialize(sr) as T;
            }

            return t;
        }


        public static string ObjectToXmlString(this object obj)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            string xml = string.Empty;
            using (MemoryStream stream = new MemoryStream())
            {
                serializer.Serialize(stream, obj);
                stream.Position = 0;
                using (StreamReader streamReader = new StreamReader(stream))
                {
                    xml = streamReader.ReadToEnd();
                }
            }
            return xml;
        }



        /// <summary>
        /// MD5加密(16位)
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string MD5Encrypt16(this string str)
        {
            byte[] sor = Encoding.UTF8.GetBytes(str);
            MD5 md5 = MD5.Create();
            byte[] result = md5.ComputeHash(sor);
            StringBuilder strbul = new StringBuilder(40);
            for (int i = 0; i < result.Length; i++)
            {
                strbul.Append(result[i].ToString("x"));
            }
            return strbul.ToString();
        }



        /// <summary>
        /// MD5加密(32位)
        /// </summary>
        /// <param name="str">加密字符</param>
        /// <returns></returns>
        public static string MD5Encrypt32(this string str)
        {
            byte[] sor = Encoding.UTF8.GetBytes(str);
            MD5 md5 = MD5.Create();
            byte[] result = md5.ComputeHash(sor);
            StringBuilder strbul = new StringBuilder(40);
            for (int i = 0; i < result.Length; i++)
            {
                strbul.Append(result[i].ToString("x2"));
            }
            return strbul.ToString();
        }

        /// <summary>
        /// MD5加密(64位)
        /// </summary>
        /// <param name="str">加密字符</param>
        /// <returns></returns>
        public static string MD5Encrypt64(this string str)
        {
            byte[] sor = Encoding.UTF8.GetBytes(str);
            MD5 md5 = MD5.Create();
            byte[] result = md5.ComputeHash(sor);
            StringBuilder strbul = new StringBuilder(40);
            for (int i = 0; i < result.Length; i++)
            {
                strbul.Append(result[i].ToString("x4"));
            }
            return strbul.ToString();
        }

    }
}

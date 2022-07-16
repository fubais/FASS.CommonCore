

namespace FASS.CommonCore
{
    using Newtonsoft.Json;
    using System.Security.Cryptography;
    using System.Text;

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

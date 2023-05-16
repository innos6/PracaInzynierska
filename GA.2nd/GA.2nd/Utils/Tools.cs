using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GA._2nd.Utils
{
    public static class Tools
    {
        public static string ComputeChecksum(object arg)
        {
            using(MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                MD5 md5 = new MD5CryptoServiceProvider();
                StringBuilder builder = new StringBuilder();
                try
                {
                    formatter.Serialize(stream, arg);
                    var result = md5.ComputeHash(stream.ToArray());
                    foreach (var item in result)
                    {
                        builder.Append(item.ToString("X2"));
                    }
                    return builder.ToString();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


    }
}

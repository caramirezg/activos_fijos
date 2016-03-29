using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;
using System.IO;

namespace ActivosFijosEETC.Controllers
{
    /// <summary>
    /// Descripción breve de ControllerHelper
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ControllerHelper : System.Web.Services.WebService
    {
        /// <summary>
        /// Convierte un List a DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
         [WebMethod(EnableSession = true)]
        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

         /// <summary>
         /// Encripta una cadena a MD5
         /// </summary>
         /// <param name="str"></param>
         /// <returns></returns>
         public string getMD5(string str) //hacemos uso del MD5 para seguridad
         {
             MD5 md5 = MD5CryptoServiceProvider.Create();
             ASCIIEncoding encoding = new ASCIIEncoding();
             byte[] stream = null;
             StringBuilder sb = new StringBuilder();
             stream = md5.ComputeHash(encoding.GetBytes(str));
             for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
             return sb.ToString();
         }

         public string DataSetToJSON(DataSet ds)
         {

             Dictionary<string, object> dict = new Dictionary<string, object>();
             foreach (DataTable dt in ds.Tables)
             {
                 object[] arr = new object[dt.Rows.Count + 1];

                 for (int i = 0; i <= dt.Rows.Count - 1; i++)
                 {
                     arr[i] = dt.Rows[i].ItemArray;
                 }

                 dict.Add(dt.TableName, arr);
             }

             JavaScriptSerializer json = new JavaScriptSerializer();
             return json.Serialize(dict);
         }

         public string Encrypt(string clearText)
         {
             string EncryptionKey = "MT2K15515T3M45";
             byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
             using (Aes encryptor = Aes.Create())
             {
                 Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                 encryptor.Key = pdb.GetBytes(32);
                 encryptor.IV = pdb.GetBytes(16);
                 using (MemoryStream ms = new MemoryStream())
                 {
                     using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                     {
                         cs.Write(clearBytes, 0, clearBytes.Length);
                         cs.Close();
                     }
                     clearText = Convert.ToBase64String(ms.ToArray());
                 }
             }
             return clearText;
         }

         public string Decrypt(string cipherText)
         {
             string EncryptionKey = "MT2K15515T3M45";
             cipherText = cipherText.Replace(" ", "+");
             byte[] cipherBytes = Convert.FromBase64String(cipherText);
             using (Aes encryptor = Aes.Create())
             {
                 Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                 encryptor.Key = pdb.GetBytes(32);
                 encryptor.IV = pdb.GetBytes(16);
                 using (MemoryStream ms = new MemoryStream())
                 {
                     using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                     {
                         cs.Write(cipherBytes, 0, cipherBytes.Length);
                         cs.Close();
                     }
                     cipherText = Encoding.Unicode.GetString(ms.ToArray());
                 }
             }
             return cipherText;
         }

    }
}

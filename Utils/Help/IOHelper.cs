using System;
using System.Xml;
using System.Web;
using System.Collections;
using System.Text;
using System.Data;
using System.IO;
using System.Xml.Serialization;

namespace Utils.Help
{
   /**//// <summary>
   /// 必需用XPATH表达式来获取相应节点
    /// 关于xpath可以参见:
    /// </summary>
     public class IOHelper
     {
         /// <summary>
         /// 获得文件物理路径
         /// </summary>
         /// <returns></returns>
         public static string GetMapPath(string path)
         {
             if (HttpContext.Current != null)
             {
                 return HttpContext.Current.Server.MapPath(path);
             }
             else
             {
                 return System.Web.Hosting.HostingEnvironment.MapPath(path);
             }
         }

         #region  序列化

         /// <summary>
         /// XML序列化
         /// </summary>
         /// <param name="obj">序列对象</param>
         /// <param name="filePath">XML文件路径</param>
         /// <returns>是否成功</returns>
         public static bool SerializeToXml(object obj, string filePath)
         {
             bool result = false;

             FileStream fs = null;
             try
             {
                 fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                 XmlSerializer serializer = new XmlSerializer(obj.GetType());
                 serializer.Serialize(fs, obj);
                 result = true;
             }
             catch (Exception ex)
             {
                 throw ex;
             }
             finally
             {
                 if (fs != null)
                     fs.Close();
             }
             return result;

         }

         /// <summary>
         /// XML反序列化
         /// </summary>
         /// <param name="type">目标类型(Type类型)</param>
         /// <param name="filePath">XML文件路径</param>
         /// <returns>序列对象</returns>
         public static object DeserializeFromXML(Type type, string filePath)
         {
             FileStream fs = null;
             try
             {
                 fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                 XmlSerializer serializer = new XmlSerializer(type);
                 return serializer.Deserialize(fs);
             }
             catch (Exception ex)
             {
                 throw ex;
             }
             finally
             {
                 if (fs != null)
                     fs.Close();
             }
         }

         #endregion
 
     }
 
 }


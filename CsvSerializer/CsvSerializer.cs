using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel;

namespace CsvSerializer
{
    static class CsvSerializer
    {
        public static string Serialize<T>(T obj) where T : new()
        {
            var r = new List<string>();
            Type t = typeof(T);
            IEnumerable<PropertyInfo> ps = FilterProperty(t);
            foreach (var p in ps)
            {
                var b = p.PropertyType.GetProperties();
                if (null == null)
                {
                    var v = p.GetValue(obj).ToString();
                    r.Add(v);
                }
                
            }
            return string.Join(",", r);
        }

        public static T Deserialize<T>(string str) where T : new()
        {
            var r = new T();
            var t = typeof(T);
            IEnumerable<PropertyInfo> ps = FilterProperty(t);
            var vs = str.Split(',');
            for (int i = 0; i < vs.Length; i++)
            {
                var pt = ps.ElementAt(i).PropertyType;
                var converter = TypeDescriptor.GetConverter(pt);
                var e = converter.ConvertFrom(vs[i]);
                ps.ElementAt(i).SetValue(r, e);
            }
            return r;
        }


        public static string SerializeEnum<T>(IEnumerable<T> objs) where T : new()
        {
            var r = new List<string>();
            foreach (var obj in objs)
            {
                r.Add(Serialize(obj));
            }
            return string.Join("\n", r);
        }

        public static List<T> DeserializeIEnum<T>(string str) where T : new()
        {
            var res = new List<T>();
            var vsl = str.Split('\n');
            foreach (var v in vsl)
            {
                res.Add(Deserialize<T>(v));
            }
            return res;
        }


        public static IEnumerable<PropertyInfo> FilterProperty(Type t)
        {
            IEnumerable<PropertyInfo> ps = t.GetProperties();
            return ps = ps.Where(p => p.GetCustomAttribute<NoCsvAttribute>() == null)
                .OrderByDescending(p => p.GetCustomAttribute<CsvOrderAttribute>() != null)
                .ThenBy(p => p.GetCustomAttribute<CsvOrderAttribute>()?.Order);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Gmail.DDD.Extensions;
using Gmail.DDD.Entity;
using PM2.Models.Code030.szrl111Model;

namespace PM2.Service.Code030.Szrl105Service
{
    public static class IGlobalExtensions
    {
        public static string GetDifference<TEntity>(this Enttity entity1, Enttity entity2, List<string> exceptNames)
        {
            string result = string.Empty;
            try
            {
                List<string> names = new List<string>();
                var type = entity1.GetType();
                var pis = type.GetProperties();
                foreach (var pi in pis)
                {
                    if (pi.MemberType == MemberTypes.Property)
                    {
                        var value1 = pi.GetValue(entity1);
                        var value2 = pi.GetValue(entity2);
                        
                        if ((value1 == null && value2 != null) || (value1 != null && !value1.Equals(value2)))
                        {
                            bool flag = true;
                            bool stringFlag = value1 != null ? value1.GetType() == typeof(string) : value2 != null ? value2.GetType() == typeof(string) : false;
                            if (stringFlag)
                            {
                                if (string.IsNullOrWhiteSpace(Convert.ToString(value1)) && string.IsNullOrWhiteSpace(Convert.ToString(value2)))
                                {
                                    flag = false;
                                }
                            }
                            if (flag)
                            {
                                names.Add(pi.Name);
                            }
                        }
                    }
                }

                // 移除排除项
                if (exceptNames != null && exceptNames.Count > 0)
                {
                    foreach (var item in exceptNames)
                    {
                        names.Remove(item);
                    }
                }

                result = names.JoinToString(";");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }


        public static TDestination Mapper<TSource, TDestination>(TSource source)
        {
            TDestination destination = Activator.CreateInstance<TDestination>();
            try
            {
                var sType = source.GetType();
                var dType = typeof(TDestination);
                var sPIs = sType.GetProperties();
                var dPIs = dType.GetProperties();
                foreach (PropertyInfo sP in sPIs)
                {
                    foreach (PropertyInfo dP in dPIs)
                    {
                        if (dP.Name == sP.Name)
                        {
                            dP.SetValue(destination, sP.GetValue(source));
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return destination;
        }

        
    }
}

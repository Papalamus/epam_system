﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Test_project
{
    public static class ExctensionClass
    {
        public static string MethodSignature(this MethodInfo mi)
        {
            String[] param = mi.GetParameters()
                          .Select(p => String.Format("{0} {1}", p.ParameterType.Name, p.Name))
                          .ToArray();


            string signature = String.Format("{0} {1}({2})", mi.ReturnType.Name, mi.Name, String.Join(",", param));

            return signature;
        }
        public static object GetValue(this MemberInfo mi,object obj)
        {
            PropertyInfo pi = mi as PropertyInfo;
            if (pi != null)
            {
                 return pi.GetValue(obj);
            }
            else
            {
                FieldInfo fi = mi as FieldInfo;
                if (fi != null)
                {
                    return fi.GetValue(obj);
                }
                else throw new NotSupportedException();
            }
        }
    }
}

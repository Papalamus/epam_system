﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Test_project.Attributes;

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

        public static void SetValue(this MemberInfo mi, object obj, object value)
        {
            PropertyInfo pi = mi as PropertyInfo;
            if (pi != null)
            {
                FieldOrmSaveAttribute attr = pi.GetCustomAttribute<FieldOrmSaveAttribute>();
                Type type = attr.type;
                pi.SetValue(obj, Convert.ChangeType(value,type));
            }
            else
            {
                FieldInfo fi = mi as FieldInfo;
                if (fi != null)
                {
                    FieldOrmSaveAttribute attr = pi.GetCustomAttribute<FieldOrmSaveAttribute>();
                    Type type = attr.type;
                    fi.SetValue(obj, Convert.ChangeType(value, type));
                }
                else throw new NotSupportedException();
            }
        }
    }
}

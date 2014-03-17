using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_project.Attributes;
using System.Reflection;

namespace Test_project
{
    class ClassInspector
    {

        public static void Inspect(Assembly asm)
        {

            var classTypes = from t in asm.GetTypes()
                             where
                                 t.IsClass
                             select t;

            foreach (var t in classTypes)
            {
                var classMethods = from m in t.GetMethods()
                                   where Attribute.GetCustomAttributes(m).FirstOrDefault(atr => atr is OverridedAttribute) != default(Attribute)
                                   select m;

                foreach (var m in classMethods)
                {
                    Console.WriteLine(@" В классе {0}, проверяем метод  {1} ", t, m.Name);
                    Type baseType = t.BaseType;
                    MethodInfo baseMethod = baseType.GetMethod(m.Name);
                    if ((baseMethod == null)|| !CheckOverriding(baseMethod, m))
                    {
                        Console.WriteLine("Неправильно переопределен метод {1} в классе {0},  ", t, m.Name);
                    }

                }

            }

        }

        public static bool CheckOverriding(MethodInfo baseMethod, MethodInfo inhMethod)
        {
            return baseMethod.MethodSignature() == inhMethod.MethodSignature();
        }



    }
}

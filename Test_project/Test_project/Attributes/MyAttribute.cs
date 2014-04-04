using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_project.Attributes
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Field|AttributeTargets.Property)]
    class MyAttribute : System.Attribute
    {

    }
}

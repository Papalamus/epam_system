using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_project.Entities;

namespace ConsoleApplication1.InputHelpers
{
    class ArticleInput:IInputHelper<Article>
    {
        public Article makeObject()
        {
            return new Article()
            {
                Title = UserChoise.Request("Введите название статьи"),
                Value = UserChoise.Request<int>("Введите стоимость", Int32.TryParse),
                ArticleCode = UserChoise.Request<int>("Введите код статьи", Int32.TryParse)
            };
        }

        public object requestID()
        {
            return UserChoise.Request<int>("Введите код статьи", Int32.TryParse);
        }
    }
}

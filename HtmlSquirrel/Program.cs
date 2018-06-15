using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Autofac;
using Autofac.Core;

namespace HtmlSquirrel
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine();
        }
    }

    public class StartUp
    {
        public IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();



            return builder.Build();
        }
    }

    public class LambdaExecutor
    {
        public List<Func<object, object>> Expressions = new List<Func<object, object>>();

        public object GlobalObject;

        public void Add(Func<object,object> exp)
        {
            Expressions.Add(exp);
        }

        public IEnumerable<object> Execute()
        {
            var results = new List<object>();
            foreach (Func<object, object> lambdaExpression in Expressions)
            {
                var func =  lambdaExpression;
                results.Add(func(GlobalObject));

            }
            return results;
        }
        
    }
}

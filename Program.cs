using AutoMapperCustomAttributesExample.Extensions;
using AutoMapperCustomAttributesExample.Models;
using System;

namespace AutoMapperCustomAttributesExample
{
    class Program
    { 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine(" AutoMapper CustomAttributes Example ");

            var source = new Source {

                 CustomerName = "test",
                 Salary = 5000, 
                 WorkAddress = "Some address"  
            };

            var mapper = typeof(Source).GetTypeMapper<Source>();

            var target = mapper.Map<Destination>(source);


            Console.WriteLine($"{target.CustomerName}");
            Console.WriteLine($"{target.Salary}");
            Console.WriteLine($"{target.Address}"); 

            Console.ReadLine();  
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMapperCustomAttributesExample.Models
{


    [MapTarget(typeof(Source))]
    public class Destination
    {
        public string CustomerName { set; get; } = "Default"; 



        public int Salary { set; get; }

        [MapFieldName("Address","WorkAddress")]
        public string Address { set; get; }



    }
}

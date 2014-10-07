using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Defining_Classes___Part_I;  // adding Defining_Classes___Part_I as a namespace to use it

namespace GSMTest
{
    public class GSMTest
    {
        static void Main(string[] args)
        {
            GSM[] gsms = new GSM[] 
            { 
                new GSM("N70", "Nokia"),
                new GSM("Sony Ericson", "Sony", 250, "Pesho", new Battery("model1", 20,5,BatteryType.Li_Ion),new Display(3,256)),
                new GSM("Galaxy S3III", "Samsung", 500, "Goro", new Battery("model4", 22,7,BatteryType.NiCd),new Display(4,1024)),
                new GSM("N70", "Nokia", 270, "Ivan", new Battery("model2", 20,5,BatteryType.Li_Ion),new Display()),
                new GSM("Galaxy S3III", "Samsung", 150, "Stoyan", new Battery(),new Display(7,512)),               

            };
            foreach (var gsm in gsms)
            {
                Console.WriteLine(gsm.ToString());
                Console.WriteLine();
            }


            Console.WriteLine(GSM.IPhone4S);
        }
    }
}

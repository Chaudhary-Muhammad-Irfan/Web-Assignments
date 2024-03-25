using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenLocalDataHandling
{
    internal class Validation
    {
        public string validateMobile(string mobile)
        {
            while (mobile.Length != 12 || mobile[4] != '-')
            {
                Console.WriteLine("The Phone number format is not correct: Enter a new Phone:");
                mobile = Console.ReadLine();
            }
            return mobile;
        }
        public string validateCNIC(string cnic)
        {
            while (cnic.Length != 15 || cnic[5] != '-' || cnic[13] != '-')
            {
                Console.WriteLine("The CNIC format is not correct: Enter a new CNIC:");
                cnic = Console.ReadLine();
            }
            return cnic;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoToken
{
    public class Company
    {
        public int permissionGroupId { get; set; }
        public bool strictEncryptionPolicy { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int id { get; set; }
    }
}

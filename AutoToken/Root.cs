using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoToken
{
    public class Root
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string scope { get; set; }
        public string account { get; set; }
        public int account_id { get; set; }
        public string tenant_id { get; set; }
        public List<Company> companies { get; set; }
        public List<string> authorities { get; set; }
        public string cluster_url { get; set; }
    }
}

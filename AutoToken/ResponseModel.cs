using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoToken
{
    class ResponseModel
    {
        public class Sc
        {
            public string code { get; set; }
        }

        public class P
        {
            public string lastName { get; set; }
            public string emailAddress { get; set; }
            public string mobilePhone { get; set; }
            public string userName { get; set; }
        }

        public class Cte
        {
            public string elementId { get; set; }
            public string checklistTemplate { get; set; }
            public string checklistInstance { get; set; }
            public string updateAuthor { get; set; }
            public string id { get; set; }
            public string title { get; set; }
            public DateTime? updated { get; set; }
            public string value { get; set; }
            public DateTime createDateTime { get; set; }
        }

        public class Bp
        {
            public string name { get; set; }
        }

        public class A
        {
            public string code { get; set; }
            public DateTime startDateTime { get; set; }
        }

        public class Ct
        {
            public string name { get; set; }
        }

        public class Datum
        {
            public Sc sc { get; set; }
            public P p { get; set; }
            public Cte cte { get; set; }
            public Bp bp { get; set; }
            public A a { get; set; }
            public Ct ct { get; set; }
        }

        public class Root
        {
            public List<Datum> data { get; set; }
        }
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoToken
{
    class DeserializedResponse
    {
        //clase necesaria para el llenado de la tabla
        public int _id { get; set; }
        public string code { get; set; }
        public string lastName { get; set; }
        public string emailAddress { get; set; }
        public string mobilePhone { get; set; }
        public string userName { get; set; }
        public string elementId { get; set; }
        public string checklistTemplate { get; set; }
        public string checklistInstance { get; set; }
        public string updateAuthor { get; set; }
        public string id { get; set; }
        public string title { get; set; }
        public DateTime? updated { get; set; }
        public string value { get; set; }
        public DateTime createDateTime { get; set; }
        public string cardName { get; set; }
        public string Acode { get; set; }
        public DateTime AstartDateTime { get; set; }
        public string name { get; set; }
    }
}

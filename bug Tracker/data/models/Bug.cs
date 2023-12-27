using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bug_Tracker.data.models
{
    public class Bug
    {
        public string Reference  { get; set; } 
        
        public string Description { get; set; }
        public string Status { get; set; }
        public string Author { get; set; }


        public Bug( string reference , string desc , string status , string author) {
            
            this.Reference = reference;
            this.Description = desc;
            this.Status = status;   
            this.Author = author;
        }
        public Bug(string desc, string status, string author)
        {

            Guid guid = Guid.NewGuid();

            this.Reference = guid.ToString();
            this.Description = desc;
            this.Status = status;
            this.Author = author;
        }
    }
}

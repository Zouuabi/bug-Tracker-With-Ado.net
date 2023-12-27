using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using bug_Tracker.data.models;
using bug_Tracker.data;
namespace bug_Tracker.business_logic
{
    public class BugUsesCases
    {


        public static List<Bug>? FetchBugs()
        {
            BugRepository repository = new();
           return  repository.ReadAllBugs();


        }
    }
}

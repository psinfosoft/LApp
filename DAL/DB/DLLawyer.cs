using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DLLawyer
    {
        public static List<GetAllLawyersBySubscriberID_Result> GetAllLawyersBySubscriberID(long SubscriberID)
        {
            using (LegalTestEntities Ctx = new LegalTestEntities())
            {                
                return Ctx.GetAllLawyersBySubscriberID(SubscriberID).ToList();
            }
        }
    }
}

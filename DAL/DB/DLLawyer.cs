using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DB
{
    public class DLLawyer
    {
        public static IList<GetAllLawyersBySubscriberID_Result> GetAllLawyersBySubscriberID(long SubscriberID)
        {
            using (LegalTestEntities Ctx = new LegalTestEntities())
            {                
                return Ctx.GetAllLawyersBySubscriberID(SubscriberID).ToList();
            }
        }
    }
}

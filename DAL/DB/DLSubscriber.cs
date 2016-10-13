using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DB
{
    public static class DLSubscriber
    {
        public static GetSubscriberByEmailID_Result GetSubscriberByEmailID(string Email)
        {
            using (LegalTestEntities Ctx = new LegalTestEntities())
            {
                //Mapper.Initialize(cfg => cfg.CreateMap<GetSubscriberByEmailID_Result, EntitySubscriber>());
                //return Mapper.Map<GetSubscriberByEmailID_Result,EntitySubscriber>(Ctx.GetSubscriberByEmailID(Email).FirstOrDefault());
                return Ctx.GetSubscriberByEmailID(Email).FirstOrDefault();
            }
        }
    }
}

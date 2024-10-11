using PennyWise.Data.Interfaces;
using PennyWise.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PennyWise.Data.Repositories
{
    public class MobileRepository : BaseRepository, IMobileRepository
    {
        public MobileRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public void AddMobile(Mobile mobile)
        {
            this.GetDbSet<Mobile>().Add(mobile);
            UnitOfWork.SaveChanges();
        }

        public void DeleteMobile(int mobileId)
        {
            var mobile = this.GetDbSet<Mobile>().FirstOrDefault(m => m.Id == mobileId);
            if (mobile != null)
            {
                this.GetDbSet<Mobile>().Remove(mobile);
                UnitOfWork.SaveChanges();
            }
        }

        public IQueryable<Mobile> GetMobiles()
        {
            return this.GetDbSet<Mobile>();
        }

        public Mobile? GetMobile(int mobileId)
        {
            return this.GetDbSet<Mobile>().FirstOrDefault(m => m.Id == mobileId);
        }

        public void UpdateMobile(Mobile mobile)
        {
            var existingMobile = this.GetDbSet<Mobile>().FirstOrDefault(m => m.Id == mobile.Id);
            if (existingMobile != null)
            {
                existingMobile.Brand = mobile.Brand;
                existingMobile.Model = mobile.Model;
                existingMobile.Price = mobile.Price;
                existingMobile.DateUpdated = DateTime.Now;
                UnitOfWork.SaveChanges();
            }
        }
    }
}

using PennyWise.Data.Interfaces;
using PennyWise.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PennyWise.Data.Repositories
{
    public class WishRepository : BaseRepository, IWishRepository
    {
        public WishRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public void AddWish(Wish wish)
        {
            this.GetDbSet<Wish>().Add(wish);
            UnitOfWork.SaveChanges();
        }

        public void DeleteWish(int wishId)
        {
            var wish = this.GetDbSet<Wish>().FirstOrDefault(c => c.Id == wishId);
            if (wish != null)
            {
                this.GetDbSet<Wish>().Remove(wish);
                UnitOfWork.SaveChanges();
            }
        }

        public IQueryable<Wish> GetWishes()
        {
            return this.GetDbSet<Wish>();
        }

        public Wish? GetWish(int wishId)
        {

            return this.GetDbSet<Wish>().FirstOrDefault(c => c.Id == wishId);
        }
        public void UpdateWish(Wish wish)
        {
            var existwish = this.GetDbSet<Wish>().FirstOrDefault(c => c.Id == wish.Id);
            if (existwish != null)
            {
                existwish.WishName = wish.WishName;
                UnitOfWork.SaveChanges();
            }
        }


    }
}

using PennyWise.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PennyWise.Services.Interfaces
{
    public interface IWishService
    {
        void AddWish(Wish wish);
        void DeleteWish(int wishId);
        IQueryable<Wish> GetWishes();
        Wish? GetWish(int wishId);
        void UpdateWish(Wish Wish);
    }
}

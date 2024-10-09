using PennyWise.Data.Interfaces;
using PennyWise.Data.Models;
using PennyWise.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PennyWise.Services.Services
{
    public class WishService : IWishService
    {
        private readonly IWishRepository _repository;
        public WishService(IWishRepository repository)
        {
            _repository = repository;
        }
        public void AddWish(Wish wish)
        {
            _repository.AddWish(wish);
        }
        public void DeleteWish(int wishId)
        {
            _repository.DeleteWish(wishId);
        }
        public IQueryable<Wish> GetWishes()
        {
            return _repository.GetWishes();
        }
        public Wish? GetWish(int wishId)
        {
            return _repository.GetWish(wishId);
        }
        public void UpdateWish(Wish wish)
        {
            _repository.UpdateWish(wish);
        }
    }
}

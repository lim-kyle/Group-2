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
    public class MobileService : IMobileService
    {
        private readonly IMobileRepository _repository;
        public MobileService(IMobileRepository repository)
        {
            _repository = repository;
        }

        public void AddMobile(Mobile mobile)
        {
            _repository.AddMobile(mobile);
        }

        public void DeleteMobile(int mobileId)
        {
            _repository.DeleteMobile(mobileId);
        }

        public IQueryable<Mobile> GetMobiles()
        {
            return _repository.GetMobiles();
        }

        public Mobile? GetMobile(int mobileId)
        {
            return _repository.GetMobile(mobileId);
        }

        public void UpdateMobile(Mobile mobile)
        {
            _repository.UpdateMobile(mobile);
        }
    }
}

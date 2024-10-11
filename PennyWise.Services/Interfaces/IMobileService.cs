using PennyWise.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PennyWise.Services.Interfaces
{
    public interface IMobileService
    {
        void AddMobile(Mobile mobile);
        void DeleteMobile(int mobileId);
        IQueryable<Mobile> GetMobiles();
        Mobile? GetMobile(int mobileId);
        void UpdateMobile(Mobile mobile);
    }
}

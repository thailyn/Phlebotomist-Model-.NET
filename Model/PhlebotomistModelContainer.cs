using Phlebotomist.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phlebotomist.Model
{
    public partial class PhlebotomistModelContainer : IUnitOfWork
    {
        public void Save()
        {
            // result == 0: bad
            // result == 1: good
            int result = SaveChanges();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}

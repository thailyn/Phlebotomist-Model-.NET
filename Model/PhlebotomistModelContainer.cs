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
            SaveChanges();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}

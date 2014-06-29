using Phlebotomist.Model;
using Phlebotomist.Repositories.Interfaces;
using Phlebotomist.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phlebotomist.Repositories
{
    public class PhlebotomistRepository : IPhlebotomistRepository
    {
        #region Member Variables
        private PhlebotomistModelContainer _context;
        #endregion

        #region Properties
        public PhlebotomistModelContainer Context
        {
            get
            {
                return _context;
            }
            protected set
            {
                if (value != _context)
                {
                    _context = value;
                }
            }
        }
        #endregion

        #region Constructor
        public PhlebotomistRepository(IUnitOfWork context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context", "Must provide a context to initialize a Phlebotomist Repository");
            }

            _context = context as PhlebotomistModelContainer;
        }
        #endregion

        #region XXX Methods
        #endregion

        public void Save()
        {
            _context.Save();
        }
    }
}

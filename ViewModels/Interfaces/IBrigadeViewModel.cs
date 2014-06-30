using Phlebotomist.Model;
using Phlebotomist.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phlebotomist.ViewModels.Interfaces
{
    public interface IBrigadeViewModel
    {
        #region Properties
        #region Model
        Brigade Brigade { get; }
        #endregion

        #region Bindings
        #endregion
        long Id { get; set; }
        long BrigadeFormationId { get; set; }
        Nullable<long> PlayerId { get; set; }
        string Name { get; set; }
        string Notes { get; set; }

        ICollection<FamiliarTypeViewModel> Familiars { get; }
        BrigadeFormation Formation { get; set; }
        Player Player { get; set; }
        #endregion

        #region Utility
        /// <summary>
        /// Gets or sets the repository for saving to the Phlebotomist database.
        /// </summary>
        IPhlebotomistRepository PhlebotomistRepository { get; set; }
        #endregion

        #region Accessors
        #endregion

        #region Mutators
        #endregion

        /// <summary>
        /// Saves changes to the underlying model object to the database.
        /// </summary>
        /// <returns>True iff the save was successful.</returns>
        bool Save();
    }
}

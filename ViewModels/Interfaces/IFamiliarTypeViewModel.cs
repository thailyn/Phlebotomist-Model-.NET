﻿using Phlebotomist.Model;
using Phlebotomist.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phlebotomist.ViewModels.Interfaces
{
    public interface IFamiliarTypeViewModel
    {
        #region Properties
        #region Model
        FamiliarType FamiliarType { get; }
        #endregion

        #region Binding
        long Id { get; set; }
        Nullable<long> BbId { get; set; }
        string Name { get; set; }
        //*********************************//
        FamiliarTypeViewModel PreviousEvolution { get; set; }
        #endregion
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
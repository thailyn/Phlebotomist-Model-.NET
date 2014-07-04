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

        ICollection<FamiliarTypeViewModel> FamiliarTypes { get; }
        BrigadeFormation Formation { get; set; }
        Player Player { get; set; }

        #region Scores
        double BasePvPScore { get; }
        double MaxPvPScore { get; }
        double PEPvPScore { get; }

        double BaseRaidScore { get; }
        double MaxRaidScore { get; }
        double PERaidScore { get; }
        #endregion

        #region FamiliarTypes
        FamiliarTypeViewModel FarLeftFrontFamiliarType {get; set; }
        FamiliarTypeViewModel MidLeftFrontFamiliarType {get; set; }
        FamiliarTypeViewModel MiddleFrontFamiliarType { get; set; }
        FamiliarTypeViewModel MidRightFrontFamiliarType { get; set; }
        FamiliarTypeViewModel FarRightFrontFamiliarType { get; set; }

        FamiliarTypeViewModel FarLeftReserveFamiliarType { get; set; }
        FamiliarTypeViewModel MidLeftReserveFamiliarType { get; set; }
        FamiliarTypeViewModel MiddleReserveFamiliarType { get; set; }
        FamiliarTypeViewModel MidRightReserveFamiliarType { get; set; }
        FamiliarTypeViewModel FarRightReserveFamiliarType { get; set; }

        FamiliarTypeViewModel GetBrigadePositionFamiliarType(BrigadeHorizontalPosition horizontalPosition, bool isReserve);
        void SetBrigadePositionFamiliarType(BrigadeHorizontalPosition horizontalPosition, bool isReserve, FamiliarTypeViewModel familiarType);
        #endregion
        #endregion

        #region Utility
        /// <summary>
        /// Gets or sets the repository for saving to the Phlebotomist database.
        /// </summary>
        IPhlebotomistRepository PhlebotomistRepository { get; set; }
        #endregion

        #region Accessors
        double GetScore(StatType statType, EventType eventType);
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

using Phlebotomist.Model;
using Phlebotomist.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        long RarityId { get; set; }
        short NumStars { get; set; }
        short MaxStars { get; set; }
        long GrowthId { get; set; }
        long Worth { get; set; }
        long RaceId { get; set; }
        short Tradable { get; set; }
        string LastWords { get; set; }
        Nullable<long> PrevEvolutionId { get; set; }
        Nullable<long> NextEvolutionId { get; set; }

        FamiliarTypeViewModel PreviousEvolution { get; set; }
        FamiliarTypeViewModel NextEvolution { get; set; }

        ObservableCollection<FamiliarTypeSkill> Skills { get; set; }
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
        void AddSkill(Skill newSkill);
        void RemoveSkill(Skill skill);
        #endregion

        /// <summary>
        /// Saves changes to the underlying model object to the database.
        /// </summary>
        /// <returns>True iff the save was successful.</returns>
        bool Save();
    }
}

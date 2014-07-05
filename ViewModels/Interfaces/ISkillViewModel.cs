using Phlebotomist.Model;
using Phlebotomist.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phlebotomist.ViewModels.Interfaces
{
    public interface ISkillViewModel
    {
        #region Properties
        #region Model
        Skill Skill { get; }
        #endregion

        #region Binding
        long Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        double MinProbability { get; set; }
        double MaxProbability { get; set; }
        Nullable<double> Modifier { get; set; }
        Nullable<byte> FlatModifier { get; set; }
        Nullable<short> NumTargets { get; set; }
        Nullable<int> RowsRange { get; set; }
        Nullable<int> ColumnsRange { get; set; }
        string SkillBased { get; set; }
        string DamageReduction { get; set; }
        string Ability { get; set; }
        Nullable<byte> IgnoresPosition { get; set; }

        ICollection<FamiliarSkill> Familiars { get; set; }
        ICollection<FamiliarTypeSkill> FamiliarTypes { get; set; }
        ICollection<SkillAffectedStat> AffectedStats { get; set; }
        SkillPattern Pattern { get; set; }
        SkillType Type { get; set; }
        Stat FoeDefensiveModifierStat { get; set; }
        Stat ModifierStat { get; set; }
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

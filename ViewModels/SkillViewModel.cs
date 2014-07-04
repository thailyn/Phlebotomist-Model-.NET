using Phlebotomist.Model;
using Phlebotomist.Repositories.Interfaces;
using Phlebotomist.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phlebotomist.ViewModels
{
    public enum SkillPatternEnum
    {
        Sweeping = 1,
        AoE,
        MultiAttack,
        SingleAttack,
        ForkAttack,
        Varies
    }

    public enum SkillGroupEnum
    {
        Offensive = 1,
        Healing,
        Debuff
    }

    public class SkillViewModel : INotifyPropertyChanged, ISkillViewModel
    {
        #region Utility
        /// <summary>
        /// Gets or sets the repository for saving to the Phlebotomist database.
        /// </summary>
        public IPhlebotomistRepository PhlebotomistRepository { get; set; }
        #endregion

        #region Properties
        #region Model
        private Skill _skill;
        public Skill Skill
        {
            get
            {
                return _skill;
            }
            protected set
            {
                if (value != _skill)
                {
                    _skill = value;
                    OnPropertyChanged("FamiliarType");
                }
            }
        }
        #endregion

        #region Bindings
        public long Id
        {
            get
            {
                return _skill.Id;
            }
            set
            {
                if (value != _skill.Id)
                {
                    _skill.Id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public string Name
        {
            get
            {
                return _skill.Name;
            }
            set
            {
                if (value != _skill.Name)
                {
                    _skill.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Description
        {
            get
            {
                return _skill.Description;
            }
            set
            {
                if (value != _skill.Description)
                {
                    _skill.Description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        public long SkillTypeId
        {
            get
            {
                return _skill.SkillTypeId;
            }
            set
            {
                if (value != _skill.SkillTypeId)
                {
                    _skill.SkillTypeId = value;
                    OnPropertyChanged("SkillTypeId");
                }
            }
        }

        public double MinProbability
        {
            get
            {
                return _skill.MinProbability;
            }
            set
            {
                if (value != _skill.MinProbability)
                {
                    _skill.MinProbability = value;
                    OnPropertyChanged("MinProbability");
                }
            }
        }

        public double MaxProbability
        {
            get
            {
                return _skill.MaxProbability;
            }
            set
            {
                if (value != _skill.MaxProbability)
                {
                    _skill.MaxProbability = value;
                    OnPropertyChanged("MaxProbability");
                }
            }
        }

        public Nullable<double> Modifier
        {
            get
            {
                return _skill.Modifier;
            }
            set
            {
                if (value != _skill.Modifier)
                {
                    _skill.Modifier = value;
                    OnPropertyChanged("Modifier");
                }
            }
        }

        public Nullable<long> ModifierStatId
        {
            get
            {
                return _skill.ModifierStatId;
            }
            set
            {
                if (value != _skill.ModifierStatId)
                {
                    _skill.ModifierStatId = value;
                    OnPropertyChanged("ModifierStatId");
                }
            }
        }

        public Nullable<byte> FlatModifier
        {
            get
            {
                return _skill.FlatModifier;
            }
            set
            {
                if (value != _skill.FlatModifier)
                {
                    _skill.FlatModifier = value;
                    OnPropertyChanged("FlatModifier");
                }
            }
        }

        public Nullable<short> NumTargets
        {
            get
            {
                return _skill.NumTargets;
            }
            set
            {
                if (value != _skill.NumTargets)
                {
                    _skill.NumTargets = value;
                    OnPropertyChanged("NumTargets");
                }
            }
        }

        public Nullable<long> SkillPatternId
        {
            get
            {
                return _skill.SkillPatternId;
            }
            set
            {
                if (value != _skill.SkillPatternId)
                {
                    _skill.SkillPatternId = value;
                    OnPropertyChanged("SkillPatternId");
                }
            }
        }

        public Nullable<int> RowsRange
        {
            get
            {
                return _skill.RowsRange;
            }
            set
            {
                if (value != _skill.RowsRange)
                {
                    _skill.RowsRange = value;
                    OnPropertyChanged("RowsRange");
                }
            }
        }

        public Nullable<int> ColumnsRange
        {
            get
            {
                return _skill.ColumnsRange;
            }
            set
            {
                if (value != _skill.ColumnsRange)
                {
                    _skill.ColumnsRange = value;
                    OnPropertyChanged("ColumnsRange");
                }
            }
        }

        public string SkillBased
        {
            get
            {
                return _skill.SkillBased;
            }
            set
            {
                if (value != _skill.SkillBased)
                {
                    _skill.SkillBased = value;
                    OnPropertyChanged("SkillBased");
                }
            }
        }

        public string DamageReduction
        {
            get
            {
                return _skill.DamageReduction;
            }
            set
            {
                if (value != _skill.DamageReduction)
                {
                    _skill.DamageReduction = value;
                    OnPropertyChanged("DamageReduction");
                }
            }
        }

        public Nullable<long> FoeDefensiveModifierStatId
        {
            get
            {
                return _skill.FoeDefensiveModifierStatId;
            }
            set
            {
                if (value != _skill.FoeDefensiveModifierStatId)
                {
                    _skill.FoeDefensiveModifierStatId = value;
                    OnPropertyChanged("FoeDefensiveModifierStatId");
                }
            }
        }

        public string Ability
        {
            get
            {
                return _skill.Ability;
            }
            set
            {
                if (value != _skill.Ability)
                {
                    _skill.Ability = value;
                    OnPropertyChanged("Ability");
                }
            }
        }

        public Nullable<byte> IgnoresPosition
        {
            get
            {
                return _skill.IgnoresPosition;
            }
            set
            {
                if (value != _skill.IgnoresPosition)
                {
                    _skill.IgnoresPosition = value;
                    OnPropertyChanged("IgnoresPosition");
                }
            }
        }

        public ICollection<FamiliarSkill> Familiars
        {
            get
            {
                return _skill.Familiars;
            }
            set
            {
                if (value != _skill.Familiars)
                {
                    _skill.Familiars = value;
                    OnPropertyChanged("Familiars");
                }
            }
        }

        public ICollection<FamiliarTypeSkill> FamiliarTypes
        {
            get
            {
                return _skill.FamiliarTypes;
            }
            set
            {
                if (value != _skill.FamiliarTypes)
                {
                    _skill.FamiliarTypes = value;
                    OnPropertyChanged("FamiliarTypes");
                }
            }
        }

        public ICollection<SkillAffectedStat> AffectedStats
        {
            get
            {
                return _skill.AffectedStats;
            }
            set
            {
                if (value != _skill.AffectedStats)
                {
                    _skill.AffectedStats = value;
                    OnPropertyChanged("AffectedStats");
                }
            }
        }

        public SkillPattern Pattern
        {
            get
            {
                return _skill.Pattern;
            }
            set
            {
                if (value != _skill.Pattern)
                {
                    _skill.Pattern = value;
                    OnPropertyChanged("Pattern");
                }
            }
        }

        public SkillType Type
        {
            get
            {
                return _skill.Type;
            }
            set
            {
                if (value != _skill.Type)
                {
                    _skill.Type = value;
                    OnPropertyChanged("Type");
                }
            }
        }

        public Stat FoeDefensiveModifierStat
        {
            get
            {
                return _skill.FoeDefensiveModifierStat;
            }
            set
            {
                if (value != _skill.FoeDefensiveModifierStat)
                {
                    _skill.FoeDefensiveModifierStat = value;
                    OnPropertyChanged("FoeDefensiveModifierStat");
                }
            }
        }

        public Stat ModifierStat
        {
            get
            {
                return _skill.ModifierStat;
            }
            set
            {
                if (value != _skill.ModifierStat)
                {
                    _skill.ModifierStat = value;
                    OnPropertyChanged("ModifierStat");
                }
            }
        }
        #endregion
        #endregion

        public SkillViewModel(Skill model, IPhlebotomistRepository phlebotomistRepository)
        {
            _skill = model;
            PhlebotomistRepository = phlebotomistRepository;
        }

        public bool Save()
        {
            try
            {
                if (Skill.Id < 0)
                {
                    var repository = PhlebotomistRepository as IPhlebotomistRepository;
                    repository.Context.Skills.Add(Skill);
                }

                PhlebotomistRepository.Save();
            }
            catch (Exception)
            {
                // log info
                throw;
            }

            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}

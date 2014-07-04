using Phlebotomist.Model;
using Phlebotomist.Repositories.Interfaces;
using Phlebotomist.UnitOfWork;
using Phlebotomist.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phlebotomist.ViewModels
{
    public enum StatTypeEnum
    {
        Base = 1,
        Max,
        PE,
        Current,
        POPE
    }

    public enum StatEnum
    {
        HP = 1,
        ATK,
        DEF,
        WIS,
        AGI,
        XP
    }

    public enum EventTypeEnum
    {
        PvP = 1,
        SpecialDungeon,
        WorldBattleColiseum,
        Raid
    }

    public class FamiliarTypeViewModel : IFamiliarTypeViewModel, INotifyPropertyChanged
    {
        #region Utility
        /// <summary>
        /// Gets or sets the repository for saving to the Phlebotomist database.
        /// </summary>
        public IPhlebotomistRepository PhlebotomistRepository { get; set; }
        #endregion

        #region Properties
        #region Model
        private FamiliarType _familiarType;
        public FamiliarType FamiliarType
        {
            get
            {
                return _familiarType;
            }
            protected set
            {
                if (value != _familiarType)
                {
                    _familiarType = value;
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
                return _familiarType.Id;
            }
            set
            {
                if (value != _familiarType.Id)
                {
                    _familiarType.Id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public Nullable<long> BbId
        {
            get
            {
                return _familiarType.BbId;
            }
            set
            {
                if (value != _familiarType.BbId)
                {
                    _familiarType.BbId = value;
                    OnPropertyChanged("BbId");
                }
            }
        }

        public string Name
        {
            get
            {
                return _familiarType.Name;
            }
            set
            {
                if (value != _familiarType.Name)
                {
                    _familiarType.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public long RarityId
        {
            get
            {
                return _familiarType.RarityId;
            }
            set
            {
                if (value != _familiarType.RarityId)
                {
                    _familiarType.RarityId = value;
                    OnPropertyChanged("RarityId");
                }
            }
        }

        public short NumStars
        {
            get
            {
                return _familiarType.NumStars;
            }
            set
            {
                if (value != _familiarType.NumStars)
                {
                    _familiarType.NumStars = value;
                    OnPropertyChanged("NumStars");
                }
            }
        }

        public short MaxStars
        {
            get
            {
                return _familiarType.MaxStars;
            }
            set
            {
                if (value != _familiarType.MaxStars)
                {
                    _familiarType.MaxStars = value;
                    OnPropertyChanged("MaxStars");
                }
            }
        }

        public long GrowthId
        {
            get
            {
                return _familiarType.GrowthId;
            }
            set
            {
                if (value != _familiarType.GrowthId)
                {
                    _familiarType.GrowthId = value;
                    OnPropertyChanged("GrowthId");
                }
            }
        }

        public long Worth
        {
            get
            {
                return _familiarType.Worth;
            }
            set
            {
                if (value != _familiarType.Worth)
                {
                    _familiarType.Worth = value;
                    OnPropertyChanged("Worth");
                }
            }
        }

        public long RaceId
        {
            get
            {
                return _familiarType.RaceId;
            }
            set
            {
                if (value != _familiarType.RaceId)
                {
                    _familiarType.RaceId = value;
                    OnPropertyChanged("RaceId");
                }
            }
        }

        public short Tradable
        {
            get
            {
                return _familiarType.Tradable;
            }
            set
            {
                if (value != _familiarType.Tradable)
                {
                    _familiarType.Tradable = value;
                    OnPropertyChanged("Tradable");
                }
            }
        }

        public string LastWords
        {
            get
            {
                return _familiarType.LastWords;
            }
            set
            {
                if (value != _familiarType.LastWords)
                {
                    _familiarType.LastWords = value;
                    OnPropertyChanged("LastWords");
                }
            }
        }

        public Nullable<long> PrevEvolutionId
        {
            get
            {
                return _familiarType.PrevEvolutionId;
            }
            set
            {
                if (value != _familiarType.PrevEvolutionId)
                {
                    _familiarType.PrevEvolutionId = value;
                    OnPropertyChanged("PrevEvolutionId");
                }
            }
        }

        public Nullable<long> NextEvolutionId
        {
            get
            {
                return _familiarType.NextEvolutionId;
            }
            set
            {
                if (value != _familiarType.NextEvolutionId)
                {
                    _familiarType.NextEvolutionId = value;
                    OnPropertyChanged("NextEvolutionId");
                }
            }
        }

        public FamiliarTypeViewModel PreviousEvolution
        {
            get
            {
                return new FamiliarTypeViewModel(_familiarType.PreviousEvolution, PhlebotomistRepository);
            }
            set
            {
                if (value == null)
                {
                    _familiarType.PreviousEvolution = null;
                    _familiarType.PrevEvolutionId = null;
                }
                else
                {
                    _familiarType.PreviousEvolution = value._familiarType;
                    _familiarType.PrevEvolutionId = value.Id;
                }
                OnPropertyChanged("PreviousEvolution");
                OnPropertyChanged("PrevEvolutionId");
            }
        }

        public FamiliarTypeViewModel NextEvolution
        {
            get
            {
                return new FamiliarTypeViewModel(_familiarType.NextEvolution, PhlebotomistRepository);
            }
            set
            {
                if (value == null)
                {
                    _familiarType.NextEvolution = null;
                    _familiarType.NextEvolutionId = null;
                }
                else
                {
                    _familiarType.NextEvolution = value._familiarType;
                    _familiarType.NextEvolutionId = value.Id;
                }
                OnPropertyChanged("NextEvolution");
                OnPropertyChanged("NextEvolutionId");
            }
        }

        #region Stats
        protected double GetStat(FamiliarType familiarType, StatTypeEnum statType, StatEnum stat)
        {
            var stats = from s in familiarType.StatValues
                        where s.StatTypeId == (int)statType
                        where s.StatId == (int)stat
                        //where string.Equals(s.StatType.Name, "Base", StringComparison.CurrentCultureIgnoreCase)
                        //where string.Equals(s.Stat.Name, "HP", StringComparison.CurrentCultureIgnoreCase)
                        select s;

            var familiarTypeStatValue = stats.ToList().FirstOrDefault();
            return familiarTypeStatValue == null ? 0 : familiarTypeStatValue.StatValue;
        }

        protected void SetStat(FamiliarType familiarType, StatTypeEnum statType, StatEnum stat, double value)
        {
            var stats = from s in familiarType.StatValues
                        where s.StatTypeId == (int)statType
                        where s.StatId == (int)stat
                        //where string.Equals(s.StatType.Name, "Base", StringComparison.CurrentCultureIgnoreCase)
                        //where string.Equals(s.Stat.Name, "HP", StringComparison.CurrentCultureIgnoreCase)
                        select s;

            var familiarTypeStatValue = stats.ToList().FirstOrDefault();
            if (familiarTypeStatValue == null)
            {
                familiarType.StatValues.Add(new FamiliarTypeStatValue
                {
                    FamiliarTypeId = familiarType.Id,
                    StatTypeId = (int)statType,
                    StatId = (int)stat,
                    StatValue = value
                });
            }
            else
            {
                familiarTypeStatValue.StatValue = value;
            }
        }

        public double BaseHP
        {
            get
            {
                return GetStat(_familiarType, StatTypeEnum.Base, StatEnum.HP);
            }
            set
            {
                SetStat(_familiarType, StatTypeEnum.Base, StatEnum.HP, value);
            }
        }

        public double BaseATK
        {
            get
            {
                return GetStat(_familiarType, StatTypeEnum.Base, StatEnum.ATK);
            }
            set
            {
                SetStat(_familiarType, StatTypeEnum.Base, StatEnum.ATK, value);
            }
        }

        public double BaseDEF
        {
            get
            {
                return GetStat(_familiarType, StatTypeEnum.Base, StatEnum.DEF);
            }
            set
            {
                SetStat(_familiarType, StatTypeEnum.Base, StatEnum.DEF, value);
            }
        }

        public double BaseWIS
        {
            get
            {
                return GetStat(_familiarType, StatTypeEnum.Base, StatEnum.WIS);
            }
            set
            {
                SetStat(_familiarType, StatTypeEnum.Base, StatEnum.WIS, value);
            }
        }

        public double BaseAGI
        {
            get
            {
                return GetStat(_familiarType, StatTypeEnum.Base, StatEnum.AGI);
            }
            set
            {
                SetStat(_familiarType, StatTypeEnum.Base, StatEnum.AGI, value);
            }
        }

        public double MaxHP
        {
            get
            {
                return GetStat(_familiarType, StatTypeEnum.Max, StatEnum.HP);
            }
            set
            {
                SetStat(_familiarType, StatTypeEnum.Max, StatEnum.HP, value);
            }
        }

        public double MaxATK
        {
            get
            {
                return GetStat(_familiarType, StatTypeEnum.Max, StatEnum.ATK);
            }
            set
            {
                SetStat(_familiarType, StatTypeEnum.Max, StatEnum.ATK, value);
            }
        }

        public double MaxDEF
        {
            get
            {
                return GetStat(_familiarType, StatTypeEnum.Max, StatEnum.DEF);
            }
            set
            {
                SetStat(_familiarType, StatTypeEnum.Max, StatEnum.DEF, value);
            }
        }

        public double MaxWIS
        {
            get
            {
                return GetStat(_familiarType, StatTypeEnum.Max, StatEnum.WIS);
            }
            set
            {
                SetStat(_familiarType, StatTypeEnum.Max, StatEnum.WIS, value);
            }
        }

        public double MaxAGI
        {
            get
            {
                return GetStat(_familiarType, StatTypeEnum.Max, StatEnum.AGI);
            }
            set
            {
                SetStat(_familiarType, StatTypeEnum.Max, StatEnum.AGI, value);
            }
        }

        public double PEHP
        {
            get
            {
                return GetStat(_familiarType, StatTypeEnum.PE, StatEnum.HP);
            }
            set
            {
                SetStat(_familiarType, StatTypeEnum.PE, StatEnum.HP, value);
            }
        }

        public double PEATK
        {
            get
            {
                return GetStat(_familiarType, StatTypeEnum.PE, StatEnum.ATK);
            }
            set
            {
                SetStat(_familiarType, StatTypeEnum.PE, StatEnum.ATK, value);
            }
        }

        public double PEDEF
        {
            get
            {
                return GetStat(_familiarType, StatTypeEnum.PE, StatEnum.DEF);
            }
            set
            {
                SetStat(_familiarType, StatTypeEnum.PE, StatEnum.DEF, value);
            }
        }

        public double PEWIS
        {
            get
            {
                return GetStat(_familiarType, StatTypeEnum.PE, StatEnum.WIS);
            }
            set
            {
                SetStat(_familiarType, StatTypeEnum.PE, StatEnum.WIS, value);
            }
        }

        public double PEAGI
        {
            get
            {
                return GetStat(_familiarType, StatTypeEnum.PE, StatEnum.AGI);
            }
            set
            {
                SetStat(_familiarType, StatTypeEnum.PE, StatEnum.AGI, value);
            }
        }
        #endregion

        public ObservableCollection<FamiliarTypeSkill> _skills;
        public ObservableCollection<FamiliarTypeSkill> Skills
        {
            get
            {
                return _skills;
            }
            set
            {
                if (value != _skills)
                {
                    _skills = value;
                    OnPropertyChanged("Skills");
                }
            }
        }
        #endregion
        #endregion

        public FamiliarTypeViewModel(FamiliarType model, IPhlebotomistRepository phlebotomistRepository)
        {
            _familiarType = model;
            PhlebotomistRepository = phlebotomistRepository;

            Skills = new ObservableCollection<FamiliarTypeSkill>();
            foreach (var skill in _familiarType.Skills)
            {
                Skills.Add(skill);
            }
        }

        #region Accessors
        public double GetScore(StatType statType, BrigadeFormationVerticalPositionType verticalPosition, EventType eventType)
        {
            if (string.Equals(statType.Name, "Current", StringComparison.CurrentCultureIgnoreCase)
                || string.Equals(statType.Name, "POPE", StringComparison.CurrentCultureIgnoreCase))
            {
                throw new NotImplementedException(string.Format("Selected stat type {0} is not currently supported.",
                    statType.Name));
            }

            if (string.Equals(eventType.Name, "Special Dungeon", StringComparison.CurrentCultureIgnoreCase)
                || string.Equals(eventType.Name, "World Battle Coliseum", StringComparison.CurrentCultureIgnoreCase))
            {
                throw new NotImplementedException(string.Format("Selected event type {0} is not currently supported.",
                    eventType.Name));
            }

            double standardAttackProbability = 1;
            Skill standardAttack = null;
            List<Skill> nonStandardAttacks = new List<Skill>();
            foreach (var familiarTypeSkill in Skills)
            {
                var skill = familiarTypeSkill.Skill;
                if (skill.Name.Contains("Standard Attack"))
                {
                    standardAttack = skill;
                }
                else
                {
                    if (skill.Type.Name.Equals("Attack"))
                    {
                        nonStandardAttacks.Add(skill);
                        standardAttackProbability -= skill.MaxProbability;
                    }
                }
            }

            int maxTargets = 0;
            if (string.Equals(eventType.Name, "PvP", StringComparison.CurrentCultureIgnoreCase))
            {
                maxTargets = 5;
            }
            else if (string.Equals(eventType.Name, "Raid", StringComparison.CurrentCultureIgnoreCase))
            {
                maxTargets = 1;
            }

            double score = 0;
            if (standardAttack != null)
            {
                double standardAttackScore = CalcSkillScore(statType, verticalPosition,
                    standardAttack, maxTargets, standardAttackProbability);
                score += standardAttackScore;
            }

            foreach (var attack in nonStandardAttacks)
            {
                double nonStandardAttackScore = CalcSkillScore(statType, verticalPosition,
                    attack, maxTargets, attack.MaxProbability);
                score += nonStandardAttackScore;
            }

            return score;
        }

        private double CalcSkillScore(StatType statType, BrigadeFormationVerticalPositionType verticalPosition,
            Skill skill, int maxTargets, double skillProbability)
        {
            // Skills other than offensive skills do no damage.
            if (skill.SkillGroups.Id != (int)SkillGroupEnum.Offensive)
            {
                return 0;
            }

            var standardAttackStat = (from sv in FamiliarType.StatValues
                                      where sv.StatType.Id == statType.Id // Base, Max, etc.
                                      where sv.Stat.Id == skill.ModifierStat.Id // ATK, WIS, etc.
                                      select sv.StatValue).FirstOrDefault();

            double standardAttackScore = standardAttackStat * skill.Modifier.Value * skillProbability;
            if (skill.IgnoresPosition.HasValue && skill.IgnoresPosition.Value == 0)
            {
                standardAttackScore *= verticalPosition.DamageDealtModifier;
            }

            int numTargets = 0;
            switch (skill.Pattern.Id)
            {
                case ((int)SkillPatternEnum.Sweeping):
                    // Hit a single target only once.
                    numTargets = Math.Min(maxTargets, (int)skill.NumTargets);
                    break;
                case ((int)SkillPatternEnum.AoE):
                    // Hit a single target only once.
                    numTargets = Math.Min(maxTargets, (int)skill.NumTargets);
                    break;
                case ((int)SkillPatternEnum.MultiAttack):
                    // Hit a single target multiple times.
                    numTargets = (int)skill.NumTargets;
                    break;
                case ((int)SkillPatternEnum.SingleAttack):
                    // Hit only a single target once.
                    numTargets = 1;
                    break;
                case ((int)SkillPatternEnum.ForkAttack):
                    // Hit a single target only once.
                    numTargets = Math.Min(maxTargets, (int)skill.NumTargets);
                    break;
                case ((int)SkillPatternEnum.Varies):
                    // Unknown!
                    break;
            }

            standardAttackScore *= numTargets;
            return standardAttackScore;
        }

        #endregion

        #region Mutators
        public void AddSkill(Skill newSkill)
        {
            var familiarTypeSkill = new FamiliarTypeSkill
            {
                FamiliarTypeId = Id,
                SkillId = newSkill.Id,
                Skill = newSkill
            };

            Skills.Add(familiarTypeSkill);
            FamiliarType.Skills.Add(familiarTypeSkill);
            OnPropertyChanged("Skills");
        }

        public void RemoveSkill(Skill skill)
        {
            for (int i = 0; i < Skills.Count; i++)
            {
                if (Skills[i].SkillId == skill.Id)
                {
                    Skills.RemoveAt(i);
                    break;
                }
            }

            foreach (var familiarTypeSkill in FamiliarType.Skills)
            {
                if (familiarTypeSkill.SkillId == skill.Id)
                {
                    FamiliarType.Skills.Remove(familiarTypeSkill);

                    var repository = PhlebotomistRepository as IPhlebotomistRepository;
                    repository.Context.FamiliarTypeSkills.Remove(familiarTypeSkill);

                    break;
                }
            }

            OnPropertyChanged("Skills");
        }
        #endregion

        public bool Save()
        {
            try
            {
                if (FamiliarType.Id < 0)
                {
                    var repository = PhlebotomistRepository as IPhlebotomistRepository;
                    repository.Context.FamiliarTypes.Add(FamiliarType);
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

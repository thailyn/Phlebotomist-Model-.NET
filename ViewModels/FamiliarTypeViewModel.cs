﻿using Phlebotomist.Model;
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

        public Rarity Rarity
        {
            get
            {
                return _familiarType.Rarity;
            }
            set
            {
                if (value != _familiarType.Rarity)
                {
                    _familiarType.Rarity = value;
                    OnPropertyChanged("Rarity");
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

        public Growth Growth
        {
            get
            {
                return _familiarType.Growth;
            }
            set
            {
                if (value != _familiarType.Growth)
                {
                    _familiarType.Growth = value;
                    OnPropertyChanged("Growth");
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

        public Race Race
        {
            get
            {
                return _familiarType.Race;
            }
            set
            {
                if (value != _familiarType.Race)
                {
                    _familiarType.Race = value;
                    OnPropertyChanged("Race");
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

        private FamiliarTypeViewModel _previousEvolution;
        public FamiliarTypeViewModel PreviousEvolution
        {
            get
            {
                if (_previousEvolution == null && _familiarType.PreviousEvolution != null)
                {
                    _previousEvolution = new FamiliarTypeViewModel(_familiarType.PreviousEvolution, PhlebotomistRepository);
                }
                return _previousEvolution;
            }
            set
            {
                if (value != _previousEvolution)
                {
                    if (value == null)
                    {
                        _familiarType.PreviousEvolution = null;
                        _familiarType.PrevEvolutionId = null;
                        _previousEvolution = null;
                    }
                    else
                    {
                        _familiarType.PreviousEvolution = value._familiarType;
                        _familiarType.PrevEvolutionId = value.Id;
                        _previousEvolution = value;
                    }
                    OnPropertyChanged("PreviousEvolution");
                }
            }
        }

        private FamiliarTypeViewModel _nextEvolution;
        public FamiliarTypeViewModel NextEvolution
        {
            get
            {
                if (_nextEvolution == null && _familiarType.NextEvolution != null)
                {
                    _nextEvolution = new FamiliarTypeViewModel(_familiarType.NextEvolution, PhlebotomistRepository);
                }
                return _nextEvolution;
            }
            set
            {
                if (value == null)
                {
                    _familiarType.NextEvolution = null;
                    _familiarType.NextEvolutionId = null;
                    _nextEvolution = null;
                }
                else
                {
                    _familiarType.NextEvolution = value._familiarType;
                    _familiarType.NextEvolutionId = value.Id;
                    _nextEvolution = value;
                }
                OnPropertyChanged("NextEvolution");
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
                    FamiliarTypes = familiarType,
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

        #region Scores
        public double BasePvPScore
        {
            get
            {
                var statType = PhlebotomistRepository.Context.StatTypes.Where(st =>
                    string.Equals(st.Name, "Base")).FirstOrDefault();
                var verticalPosition = PhlebotomistRepository.Context.BrigadeFormationVerticalPositionTypes.Where(vp =>
                    string.Equals(vp.Name, "Front")).FirstOrDefault();
                var eventType = PhlebotomistRepository.Context.EventTypes.Where(et =>
                    string.Equals(et.Name, "PvP")).FirstOrDefault();

                return GetScore(statType, verticalPosition, eventType);
            }
        }

        public double MaxPvPScore
        {
            get
            {
                var statType = PhlebotomistRepository.Context.StatTypes.Where(st =>
                    string.Equals(st.Name, "Max")).FirstOrDefault();
                var verticalPosition = PhlebotomistRepository.Context.BrigadeFormationVerticalPositionTypes.Where(vp =>
                    string.Equals(vp.Name, "Front")).FirstOrDefault();
                var eventType = PhlebotomistRepository.Context.EventTypes.Where(et =>
                    string.Equals(et.Name, "PvP")).FirstOrDefault();

                return GetScore(statType, verticalPosition, eventType);
            }
        }

        public double PEPvPScore
        {
            get
            {
                var statType = PhlebotomistRepository.Context.StatTypes.Where(st =>
                    string.Equals(st.Name, "PE")).FirstOrDefault();
                var verticalPosition = PhlebotomistRepository.Context.BrigadeFormationVerticalPositionTypes.Where(vp =>
                    string.Equals(vp.Name, "Front")).FirstOrDefault();
                var eventType = PhlebotomistRepository.Context.EventTypes.Where(et =>
                    string.Equals(et.Name, "PvP")).FirstOrDefault();

                return GetScore(statType, verticalPosition, eventType);
            }
        }

        public double PEOrMaxPvPScore
        {
            get
            {
                var statType = PhlebotomistRepository.Context.StatTypes.Where(st =>
                    string.Equals(st.Name, "PE")).FirstOrDefault();
                var verticalPosition = PhlebotomistRepository.Context.BrigadeFormationVerticalPositionTypes.Where(vp =>
                    string.Equals(vp.Name, "Front")).FirstOrDefault();
                var eventType = PhlebotomistRepository.Context.EventTypes.Where(et =>
                    string.Equals(et.Name, "PvP")).FirstOrDefault();

                var peScore = GetScore(statType, verticalPosition, eventType);
                if (peScore > 0)
                {
                    return peScore;
                }

                var maxStatType = PhlebotomistRepository.Context.StatTypes.Where(st =>
                    string.Equals(st.Name, "Max")).FirstOrDefault();
                return GetScore(maxStatType, verticalPosition, eventType);
            }
        }

        public double BaseRaidScore
        {
            get
            {
                var statType = PhlebotomistRepository.Context.StatTypes.Where(st =>
                    string.Equals(st.Name, "Base")).FirstOrDefault();
                var verticalPosition = PhlebotomistRepository.Context.BrigadeFormationVerticalPositionTypes.Where(vp =>
                    string.Equals(vp.Name, "Front")).FirstOrDefault();
                var eventType = PhlebotomistRepository.Context.EventTypes.Where(et =>
                    string.Equals(et.Name, "Raid")).FirstOrDefault();

                return GetScore(statType, verticalPosition, eventType);
            }
        }

        public double MaxRaidScore
        {
            get
            {
                var statType = PhlebotomistRepository.Context.StatTypes.Where(st =>
                    string.Equals(st.Name, "Max")).FirstOrDefault();
                var verticalPosition = PhlebotomistRepository.Context.BrigadeFormationVerticalPositionTypes.Where(vp =>
                    string.Equals(vp.Name, "Front")).FirstOrDefault();
                var eventType = PhlebotomistRepository.Context.EventTypes.Where(et =>
                    string.Equals(et.Name, "Raid")).FirstOrDefault();

                return GetScore(statType, verticalPosition, eventType);
            }
        }

        public double PERaidScore
        {
            get
            {
                var statType = PhlebotomistRepository.Context.StatTypes.Where(st =>
                    string.Equals(st.Name, "PE")).FirstOrDefault();
                var verticalPosition = PhlebotomistRepository.Context.BrigadeFormationVerticalPositionTypes.Where(vp =>
                    string.Equals(vp.Name, "Front")).FirstOrDefault();
                var eventType = PhlebotomistRepository.Context.EventTypes.Where(et =>
                    string.Equals(et.Name, "Raid")).FirstOrDefault();

                return GetScore(statType, verticalPosition, eventType);
            }
        }

        public double PEOrMaxRaidScore
        {
            get
            {
                var statType = PhlebotomistRepository.Context.StatTypes.Where(st =>
                    string.Equals(st.Name, "PE")).FirstOrDefault();
                var verticalPosition = PhlebotomistRepository.Context.BrigadeFormationVerticalPositionTypes.Where(vp =>
                    string.Equals(vp.Name, "Front")).FirstOrDefault();
                var eventType = PhlebotomistRepository.Context.EventTypes.Where(et =>
                    string.Equals(et.Name, "Raid")).FirstOrDefault();

                var peScore = GetScore(statType, verticalPosition, eventType);
                if (peScore > 0)
                {
                    return peScore;
                }

                var maxStatType = PhlebotomistRepository.Context.StatTypes.Where(st =>
                    string.Equals(st.Name, "Max")).FirstOrDefault();
                return GetScore(maxStatType, verticalPosition, eventType);
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
            List<double> nonStandardAttackProbabilities = new List<double>();
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
                    }
                }
            }

            // Modify each non-standard attack's probability based on the number
            // of non-standard attacks there are.  Note that this really be based
            // on the ratio between the current attack's probability relative to
            // the sum of all the non-standard attacks' probabilities.  But, since
            // all non-standard attacks have the same max probability, this simpler
            // algorithm works, as well.
            foreach (var attack in nonStandardAttacks)
            {
                var modifiedProbability = attack.MaxProbability / nonStandardAttacks.Count;
                nonStandardAttackProbabilities.Add(modifiedProbability);

                standardAttackProbability -= modifiedProbability;
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

            for (int i = 0; i < nonStandardAttacks.Count; i++)
            {
                var attack = nonStandardAttacks[i];
                double nonStandardAttackScore = CalcSkillScore(statType, verticalPosition,
                    attack, maxTargets, nonStandardAttackProbabilities[i]);
                score += nonStandardAttackScore;
            }

            return score;
        }

        private double CalcSkillScore(StatType statType, BrigadeFormationVerticalPositionType verticalPosition,
            Skill skill, int maxTargets, double skillProbability)
        {
            // Skills other than offensive skills do no damage.
            if (skill.Group.Id != (int)SkillGroupEnum.Offensive)
            {
                return 0;
            }

            var standardAttackStat = (from sv in FamiliarType.StatValues
                                      where sv.StatType.Id == statType.Id // Base, Max, etc.
                                      where sv.Stat.Id == skill.ModifierStat.Id // ATK, WIS, etc.
                                      select sv.StatValue).FirstOrDefault();

            double standardAttackScore = standardAttackStat * skill.Modifier.Value * skillProbability;
            if (!skill.IgnoresPosition.HasValue || skill.IgnoresPosition.Value == 0)
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
                FamiliarType = FamiliarType,
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

        public override bool Equals(object obj)
        {
            FamiliarTypeViewModel familiarTypeViewModel = obj as FamiliarTypeViewModel;
            if (familiarTypeViewModel == null)
            {
                return false;
            }

            return familiarTypeViewModel.Id == this.Id || familiarTypeViewModel.Name == this.Name;
        }

        public override int GetHashCode()
        {
            var value = this.Id % (long)int.MaxValue;
            return (int)value;
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

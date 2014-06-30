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
        private int _baseStatTypeId = 1;
        private int _maxStatTypeId = 2;
        private int _peStatTypeId = 3;

        private int _hpStatId = 1;
        private int _atkStatId = 2;
        private int _defStatId = 3;
        private int _wisStatId = 4;
        private int _agiStatId = 5;

        protected double GetStat(FamiliarType familiarType, int statTypeId, int statId)
        {
            var stats = from s in familiarType.StatValues
                        where s.StatTypeId == statTypeId
                        where s.StatId == statId
                        //where string.Equals(s.StatType.Name, "Base", StringComparison.CurrentCultureIgnoreCase)
                        //where string.Equals(s.Stat.Name, "HP", StringComparison.CurrentCultureIgnoreCase)
                        select s;

            var stat = stats.ToList().FirstOrDefault();
            return stat == null ? 0 : stat.StatValue;
        }

        protected void SetStat(FamiliarType familiarType, int statTypeId, int statId, double value)
        {
            var stats = from s in familiarType.StatValues
                        where s.StatTypeId == statTypeId
                        where s.StatId == statId
                        //where string.Equals(s.StatType.Name, "Base", StringComparison.CurrentCultureIgnoreCase)
                        //where string.Equals(s.Stat.Name, "HP", StringComparison.CurrentCultureIgnoreCase)
                        select s;

            var stat = stats.ToList().FirstOrDefault();
            if (stat == null)
            {
                familiarType.StatValues.Add(new FamiliarTypeStatValue
                {
                    FamiliarTypeId = familiarType.Id,
                    StatTypeId = statTypeId,
                    StatId = statId,
                    StatValue = value
                });
            }
            else
            {
                stat.StatValue = value;
            }
        }

        public double BaseHP
        {
            get
            {
                return GetStat(_familiarType, _baseStatTypeId, _hpStatId);
            }
            set
            {
                SetStat(_familiarType, _baseStatTypeId, _hpStatId, value);
            }
        }

        public double BaseATK
        {
            get
            {
                return GetStat(_familiarType, _baseStatTypeId, _atkStatId);
            }
            set
            {
                SetStat(_familiarType, _baseStatTypeId, _atkStatId, value);
            }
        }

        public double BaseDEF
        {
            get
            {
                return GetStat(_familiarType, _baseStatTypeId, _defStatId);
            }
            set
            {
                SetStat(_familiarType, _baseStatTypeId, _defStatId, value);
            }
        }

        public double BaseWIS
        {
            get
            {
                return GetStat(_familiarType, _baseStatTypeId, _wisStatId);
            }
            set
            {
                SetStat(_familiarType, _baseStatTypeId, _wisStatId, value);
            }
        }

        public double BaseAGI
        {
            get
            {
                return GetStat(_familiarType, _baseStatTypeId, _agiStatId);
            }
            set
            {
                SetStat(_familiarType, _baseStatTypeId, _agiStatId, value);
            }
        }

        public double MaxHP
        {
            get
            {
                return GetStat(_familiarType, _maxStatTypeId, _hpStatId);
            }
            set
            {
                SetStat(_familiarType, _maxStatTypeId, _hpStatId, value);
            }
        }

        public double MaxATK
        {
            get
            {
                return GetStat(_familiarType, _maxStatTypeId, _atkStatId);
            }
            set
            {
                SetStat(_familiarType, _maxStatTypeId, _atkStatId, value);
            }
        }

        public double MaxDEF
        {
            get
            {
                return GetStat(_familiarType, _maxStatTypeId, _defStatId);
            }
            set
            {
                SetStat(_familiarType, _maxStatTypeId, _defStatId, value);
            }
        }

        public double MaxWIS
        {
            get
            {
                return GetStat(_familiarType, _maxStatTypeId, _wisStatId);
            }
            set
            {
                SetStat(_familiarType, _maxStatTypeId, _wisStatId, value);
            }
        }

        public double MaxAGI
        {
            get
            {
                return GetStat(_familiarType, _maxStatTypeId, _agiStatId);
            }
            set
            {
                SetStat(_familiarType, _maxStatTypeId, _agiStatId, value);
            }
        }

        public double PEHP
        {
            get
            {
                return GetStat(_familiarType, _peStatTypeId, _hpStatId);
            }
            set
            {
                SetStat(_familiarType, _peStatTypeId, _hpStatId, value);
            }
        }

        public double PEATK
        {
            get
            {
                return GetStat(_familiarType, _peStatTypeId, _atkStatId);
            }
            set
            {
                SetStat(_familiarType, _peStatTypeId, _atkStatId, value);
            }
        }

        public double PEDEF
        {
            get
            {
                return GetStat(_familiarType, _peStatTypeId, _defStatId);
            }
            set
            {
                SetStat(_familiarType, _peStatTypeId, _defStatId, value);
            }
        }

        public double PEWIS
        {
            get
            {
                return GetStat(_familiarType, _peStatTypeId, _wisStatId);
            }
            set
            {
                SetStat(_familiarType, _peStatTypeId, _wisStatId, value);
            }
        }

        public double PEAGI
        {
            get
            {
                return GetStat(_familiarType, _peStatTypeId, _agiStatId);
            }
            set
            {
                SetStat(_familiarType, _peStatTypeId, _agiStatId, value);
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

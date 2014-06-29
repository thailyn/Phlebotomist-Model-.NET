using Phlebotomist.Model;
using Phlebotomist.Repositories.Interfaces;
using Phlebotomist.UnitOfWork;
using Phlebotomist.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
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

        public double BaseHP
        {
            get
            {
                var stats = from s in _familiarType.StatValues
                            where s.StatTypeId == _baseStatTypeId
                            where s.StatId == _hpStatId
                            //where string.Equals(s.StatType.Name, "Base", StringComparison.CurrentCultureIgnoreCase)
                            //where string.Equals(s.Stat.Name, "HP", StringComparison.CurrentCultureIgnoreCase)
                            select s;

                var stat = stats.ToList().FirstOrDefault();
                return stat == null ? 0 : stat.StatValue;
            }
            set
            {
                var stats = from s in _familiarType.StatValues
                            where s.StatTypeId == _baseStatTypeId
                            where s.StatId == _hpStatId
                            //where string.Equals(s.StatType.Name, "Base", StringComparison.CurrentCultureIgnoreCase)
                            //where string.Equals(s.Stat.Name, "HP", StringComparison.CurrentCultureIgnoreCase)
                            select s;

                var stat = stats.ToList().FirstOrDefault();
                if (stat == null)
                {
                    _familiarType.StatValues.Add(new FamiliarTypeStatValue
                    {
                        FamiliarTypeId = Id,
                        StatTypeId = _baseStatTypeId,
                        StatId = _hpStatId,
                        StatValue = value
                    });
                }
                else
                {
                    stat.StatValue = value;
                }
            }
        }
        #endregion

        public FamiliarTypeViewModel(FamiliarType model, IPhlebotomistRepository phlebotomistRepository)
        {
            _familiarType = model;
            PhlebotomistRepository = phlebotomistRepository;
        }

        public bool Save()
        {
            try
            {
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

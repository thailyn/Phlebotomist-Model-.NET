﻿using Phlebotomist.Model;
using Phlebotomist.Repositories.Interfaces;
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
    public enum BrigadeHorizontalPosition
    {
        FarLeft = 1,
        MidLeft,
        Middle,
        MidRight,
        FarRight
    }

    public class BrigadeViewModel : IBrigadeViewModel, INotifyPropertyChanged
    {
        #region Properties
        #region Model
        private Brigade _brigade;
        public Brigade Brigade
        {
            get
            {
                return _brigade;
            }
            protected set
            {
                if (value != _brigade)
                {
                    _brigade = value;
                    OnPropertyChanged("Brigade");
                }
            }
        }
        #endregion

        #region Bindings
        #endregion
        public long Id
        {
            get
            {
                return Brigade.Id;
            }
            set
            {
                if (value != Brigade.Id)
                {
                    Brigade.Id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public long BrigadeFormationId
        {
            get
            {
                return Brigade.BrigadeFormationId;
            }
            set
            {
                if (value != Brigade.BrigadeFormationId)
                {
                    Brigade.BrigadeFormationId = value;
                    OnPropertyChanged("BrigadeFormationId");
                }
            }
        }

        public Nullable<long> PlayerId
        {
            get
            {
                return Brigade.PlayerId;
            }
            set
            {
                if (value != Brigade.PlayerId)
                {
                    Brigade.PlayerId = value;
                    OnPropertyChanged("PlayerId");
                }
            }
        }

        public string Name
        {
            get
            {
                return Brigade.Name;
            }
            set
            {
                if (value != Brigade.Name)
                {
                    Brigade.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Notes
        {
            get
            {
                return Brigade.Notes;
            }
            set
            {
                if (value != Brigade.Notes)
                {
                    Brigade.Notes = value;
                    OnPropertyChanged("Notes");
                }
            }
        }

        public ICollection<FamiliarTypeViewModel> _familiars;
        public ICollection<FamiliarTypeViewModel> Familiars
        {
            get
            {
                return _familiars;
            }
            protected set
            {
                if (value != _familiars)
                {
                    _familiars = value;
                    OnPropertyChanged("Familiars");
                }
            }
        }

        public BrigadeFormation Formation
        {
            get
            {
                return Brigade.Formation;
            }
            set
            {
                if (value != Brigade.Formation)
                {
                    Brigade.Formation = value;
                    OnPropertyChanged("Formation");
                }
            }
        }

        public Player Player
        {
            get
            {
                return Brigade.Player;
            }
            set
            {
                if (value != Brigade.Player)
                {
                    Brigade.Player = value;
                    OnPropertyChanged("Player");
                }
            }
        }

        #region FamiliarTypes
        public FamiliarTypeViewModel FarLeftFrontFamiliarType
        {
            get
            {
                return GetBrigadePositionFamiliarType(BrigadeHorizontalPosition.FarLeft, false);
            }
            set
            {
                SetBrigadePositionFamiliarType(BrigadeHorizontalPosition.FarLeft, false, value);
                OnPropertyChanged("FarLeftFrontFamiliarType");
            }
        }

        public FamiliarTypeViewModel MidLeftFrontFamiliarType
        {
            get
            {
                return GetBrigadePositionFamiliarType(BrigadeHorizontalPosition.MidLeft, false);
            }
            set
            {
                SetBrigadePositionFamiliarType(BrigadeHorizontalPosition.MidLeft, false, value);
                OnPropertyChanged("MidLeftFrontFamiliarType");
            }
        }

        public FamiliarTypeViewModel MiddleFrontFamiliarType
        {
            get
            {
                return GetBrigadePositionFamiliarType(BrigadeHorizontalPosition.Middle, false);
            }
            set
            {
                SetBrigadePositionFamiliarType(BrigadeHorizontalPosition.Middle, false, value);
                OnPropertyChanged("MiddleFrontFamiliarType");
            }
        }

        public FamiliarTypeViewModel MidRightFrontFamiliarType
        {
            get
            {
                return GetBrigadePositionFamiliarType(BrigadeHorizontalPosition.MidRight, false);
            }
            set
            {
                SetBrigadePositionFamiliarType(BrigadeHorizontalPosition.MidRight, false, value);
                OnPropertyChanged("MidRightFrontFamiliarType");
            }
        }

        public FamiliarTypeViewModel FarRightFrontFamiliarType
        {
            get
            {
                return GetBrigadePositionFamiliarType(BrigadeHorizontalPosition.FarRight, false);
            }
            set
            {
                SetBrigadePositionFamiliarType(BrigadeHorizontalPosition.FarRight, false, value);
                OnPropertyChanged("FarRightFrontFamiliarType");
            }
        }

        public FamiliarTypeViewModel FarLeftReserveFamiliarType
        {
            get
            {
                return GetBrigadePositionFamiliarType(BrigadeHorizontalPosition.FarLeft, true);
            }
            set
            {
                SetBrigadePositionFamiliarType(BrigadeHorizontalPosition.FarLeft, true, value);
                OnPropertyChanged("FarLeftReserveFamiliarType");
            }
        }

        public FamiliarTypeViewModel MidLeftReserveFamiliarType
        {
            get
            {
                return GetBrigadePositionFamiliarType(BrigadeHorizontalPosition.MidLeft, true);
            }
            set
            {
                SetBrigadePositionFamiliarType(BrigadeHorizontalPosition.MidLeft, true, value);
                OnPropertyChanged("MidLeftReserveFamiliarType");
            }
        }

        public FamiliarTypeViewModel MiddleReserveFamiliarType
        {
            get
            {
                return GetBrigadePositionFamiliarType(BrigadeHorizontalPosition.Middle, true);
            }
            set
            {
                SetBrigadePositionFamiliarType(BrigadeHorizontalPosition.Middle, true, value);
                OnPropertyChanged("MiddleReserveFamiliarType");
            }
        }

        public FamiliarTypeViewModel MidRightReserveFamiliarType
        {
            get
            {
                return GetBrigadePositionFamiliarType(BrigadeHorizontalPosition.MidRight, true);
            }
            set
            {
                SetBrigadePositionFamiliarType(BrigadeHorizontalPosition.MidRight, true, value);
                OnPropertyChanged("MidRightReserveFamiliarType");
            }
        }

        public FamiliarTypeViewModel FarRightReserveFamiliarType
        {
            get
            {
                return GetBrigadePositionFamiliarType(BrigadeHorizontalPosition.FarRight, true);
            }
            set
            {
                SetBrigadePositionFamiliarType(BrigadeHorizontalPosition.FarRight, true, value);
                OnPropertyChanged("FarRightReserveFamiliarType");
            }
        }

        public FamiliarTypeViewModel GetBrigadePositionFamiliarType(BrigadeHorizontalPosition horizontalPosition, bool isReserve)
        {
            var familiars = from bf in _brigade.FamiliarTypes
                            where bf.BrigadeFormationPosition.HorizontalPositionTypeId == (int)horizontalPosition
                            where bf.IsReserve == (isReserve ? 1 : 0)
                            select bf.FamiliarType;

            var familiar = familiars.ToList().FirstOrDefault();
            if (familiar == null)
            {
                return null;
            }
            else
            {
                return new FamiliarTypeViewModel(familiar, PhlebotomistRepository);
            }
        }

        public void SetBrigadePositionFamiliarType(BrigadeHorizontalPosition horizontalPosition, bool isReserve, FamiliarTypeViewModel familiarType)
        {
            var brigadeFamiliars = from bf in _brigade.FamiliarTypes
                                   where bf.BrigadeFormationPosition.HorizontalPositionTypeId == (int)horizontalPosition
                                   where bf.IsReserve == (isReserve ? 1 : 0)
                                   select bf;

            var brigadeFormationPosition = PhlebotomistRepository.Context.BrigadeFormationPositions
                .Where(p => p.BrigadeFormationId == _brigade.BrigadeFormationId
                && p.HorizontalPositionTypeId == (int)horizontalPosition).FirstOrDefault();

            var brigadeFamiliar = brigadeFamiliars.ToList().FirstOrDefault();
            if (brigadeFamiliar == null)
            {
                _brigade.FamiliarTypes.Add(new BrigadeFamiliarType
                {
                    FamiliarType = familiarType.FamiliarType,
                    FamiliarTypeId = familiarType.Id,
                    BrigadeFormationPosition = brigadeFormationPosition,
                    BrigadeFormationPositionId = brigadeFormationPosition.Id,
                    BrigadeId = _brigade.Id,
                    Brigade = _brigade,
                    IsReserve = (byte)(isReserve ? 1 : 0)
                });
            }
            else
            {
                brigadeFamiliar.FamiliarType = familiarType.FamiliarType;
                brigadeFamiliar.FamiliarTypeId = familiarType.Id;
                brigadeFamiliar.BrigadeFormationPosition = brigadeFormationPosition;
                brigadeFamiliar.BrigadeFormationPositionId = brigadeFormationPosition.Id;
                brigadeFamiliar.IsReserve = (byte)(isReserve ? 1 : 0);
            }
        }
        #endregion
        #endregion

        #region Utility
        /// <summary>
        /// Gets or sets the repository for saving to the Phlebotomist database.
        /// </summary>
        public IPhlebotomistRepository PhlebotomistRepository { get; set; }
        #endregion

        public BrigadeViewModel(Brigade model, IPhlebotomistRepository phlebotomistRepository)
        {
            Brigade = model;
            PhlebotomistRepository = phlebotomistRepository;

            Familiars = new ObservableCollection<FamiliarTypeViewModel>();
            foreach (var brigadeFamiliarType in Brigade.FamiliarTypes)
            {
                Familiars.Add(new FamiliarTypeViewModel(brigadeFamiliarType.FamiliarType, PhlebotomistRepository));
            }
        }

        #region Accessors
        #endregion

        #region Mutators
        #endregion

        /// <summary>
        /// Saves changes to the underlying model object to the database.
        /// </summary>
        /// <returns>True iff the save was successful.</returns>
        public bool Save()
        {
            try
            {
                if (Brigade.Id < 0)
                {
                    var repository = PhlebotomistRepository as IPhlebotomistRepository;
                    repository.Context.Brigades.Add(Brigade);
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

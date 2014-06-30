using Phlebotomist.Model;
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

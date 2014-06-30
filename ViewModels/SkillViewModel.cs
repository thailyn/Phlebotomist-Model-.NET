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
    public class SkillViewModel : INotifyPropertyChanged, ISkillViewModel
    {
        #region Utility
        /// <summary>
        /// Gets or sets the repository for saving to the Phlebotomist database.
        /// </summary>
        public IPhlebotomistRepository PhlebotomistRepository { get; set; }
        #endregion

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

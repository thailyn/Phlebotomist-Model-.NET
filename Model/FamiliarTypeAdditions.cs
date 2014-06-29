using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Phlebotomist.Model
{
    public partial class FamiliarType
    {
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
                var stats = from s in StatValues
                            where string.Equals(s.StatType.Name, "Base", StringComparison.CurrentCultureIgnoreCase)
                            where string.Equals(s.Stat.Name, "HP", StringComparison.CurrentCultureIgnoreCase)
                            select s;
                
                var stat = stats.ToList().FirstOrDefault();
                return stat == null ? 0 : stat.StatValue;
            }
            set
            {
                var stats = from s in StatValues
                            where string.Equals(s.StatType.Name, "Base", StringComparison.CurrentCultureIgnoreCase)
                            where string.Equals(s.Stat.Name, "HP", StringComparison.CurrentCultureIgnoreCase)
                            select s;

                var stat = stats.ToList().FirstOrDefault();
                if (stat == null)
                {
                    StatValues.Add(new FamiliarTypeStatValue
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
    }
}

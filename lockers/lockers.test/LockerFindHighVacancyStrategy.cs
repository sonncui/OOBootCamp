using System.Collections.Generic;
using System.Linq;

namespace lockers.test
{
    public class LockerFindHighVacancyStrategy:IFindStrategy
    {
        public Locker FindStrategy(List<Locker> lockers)
        {
            return lockers.OrderByDescending(l => l.GetVacancyRate()).First();
        }
    }
}
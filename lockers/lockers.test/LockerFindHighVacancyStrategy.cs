using System.Collections.Generic;
using System.Linq;

namespace lockers.test
{
    public class LockerFindHighVacancyStrategyBase
    {
    }

    public class LockerFindHighVacancyStrategy: LockerFindHighVacancyStrategyBase, IFindStrategy
    {
        public Locker FindStrategy(List<Locker> lockers)
        {
            return lockers.OrderByDescending(l=>l.GetVacancyRate()).First();
        }
    }
}
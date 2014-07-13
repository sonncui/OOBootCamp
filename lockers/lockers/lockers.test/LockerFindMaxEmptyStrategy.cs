using System.Collections.Generic;
using System.Linq;

namespace lockers.test
{
    public class LockerFindMaxEmptyStrategy:IFindStrategy
    {
        public Locker FindStrategy(List<Locker> lockers)
        {
            return lockers.OrderByDescending(l=>l.emptyBox).First();
        }
    }
}
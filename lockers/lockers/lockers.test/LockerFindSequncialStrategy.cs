using System.Collections.Generic;

namespace lockers.test
{
    public class LockerFindSequncialStrategy:IFindStrategy
    {
        public Locker FindStrategy(List<Locker> lockers)
        {
            return lockers.Find(l=>(l.emptyBox!=0));
        }
    }
}
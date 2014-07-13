using System.Collections.Generic;
using System.Linq;

namespace lockers.test
{
    public class NormalRobot:Robot
    {

        public NormalRobot(List<Locker> lockers):base(lockers)
        {
            
        }

        protected override Locker FindLocker(List<Locker> lockers)
        {
            Locker lockerFound = LockerFound(lockers);
            return lockerFound;
        }

        public static Locker LockerFound(List<Locker> lockers)
        {
            return lockers.Find(l=>(l.emptyBox!=0));
        }
    }
}
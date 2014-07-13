using System.Collections.Generic;
using System.Linq;

namespace lockers.test
{
    public class SmartRobot : Robot
    {

        public SmartRobot(List<Locker> lockers)
            : base(lockers)
        {

        }

        protected override Locker FindLocker(List<Locker> lockers)
        {
            return lockers.OrderByDescending(l => l.emptyBox).First();
        }



    }
}
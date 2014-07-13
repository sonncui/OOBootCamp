using System.Collections.Generic;
using System.Linq;

namespace lockers.test
{
    public class SuperRobot:Robot
    {
        public SuperRobot(List<Locker> lockers):base(lockers)
        {
        }

        protected override Locker FindLocker(List<Locker> lockers)
        {
            return lockers.OrderByDescending(l => l.GetVacancyRate()).First();
        }

    }
}
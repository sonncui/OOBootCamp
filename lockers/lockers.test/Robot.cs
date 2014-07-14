using System.Collections.Generic;

namespace lockers.test
{
    public class Robot
    {
        protected List<Locker> lockers;
        protected IFindStrategy lockerFindStrategy;

        public Robot(List<Locker> lockers, IFindStrategy findStrategy)
        {
            this.lockers = lockers;
            lockerFindStrategy = findStrategy;
        }

        public Ticket store(Bag bag)
        {
            return FindLocker(lockers).store(bag);
        }

        public Bag pick(Ticket ticket)
        {
            Bag bag = null;
            foreach (var locker in lockers)
            {
                bag = locker.pick(ticket);
                if (bag!=null)
                {
                    break;
                }
            } 
            return bag;
        }

        private Locker FindLocker(List<Locker> lockers)
        {
            return lockerFindStrategy.FindStrategy(lockers);
        }

        public static Robot CreateNormalRobot(List<Locker> lockers, IFindStrategy findStrategy)
        {
            return new Robot(lockers, findStrategy);
        }

        public static Robot CreateSmartRobot(List<Locker> lockers, IFindStrategy findStrategy)
        {
            return new Robot(lockers, findStrategy);
        }

        public static Robot CreateSuperRobot(List<Locker> lockers, IFindStrategy findStrategy)
        {
            return new Robot(lockers, findStrategy);
        }
    }
}
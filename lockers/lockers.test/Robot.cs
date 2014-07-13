using System.Collections.Generic;

namespace lockers.test
{
    public  class Robot
    {
        protected List<Locker> lockers;

        public Robot(List<Locker> lockers)
        {
            this.lockers = lockers;
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

        public  Ticket Store(Bag bag, IFindStrategy lockerFindStrategy)
        {
            return FindLocker(lockers, lockerFindStrategy).store(bag);
        }

        protected  Locker FindLocker(List<Locker> lockers, IFindStrategy lockerFindStrategy)
        {
            Locker lockerFound = lockerFindStrategy.FindStrategy(lockers);
            return lockerFound;
        }
    }
}
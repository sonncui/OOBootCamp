using System.Collections.Generic;

namespace lockers.test
{
    public abstract class Robot
    {
        protected List<Locker> lockers;

        public Robot(List<Locker> lockers)
        {
            this.lockers = lockers;
        }

        public Ticket store(Bag bag)
        {
            return FindLocker(lockers).store(bag);
        }

        protected abstract Locker FindLocker(List<Locker> list);
        

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
    }
}
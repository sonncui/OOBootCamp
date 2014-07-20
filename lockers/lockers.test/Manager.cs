using System.Collections.Generic;

namespace lockers.test
{
    public class Manager
    {
        private readonly List<IEntity> entitys;

        public Manager(List<IEntity> entitys)
        {
            this.entitys = entitys;
        }

        public Ticket Store(Bag bag)
        {
            return entitys.Find(entity => entity.IsFull() != true).Store(bag);
        }

        public Bag Pick(Ticket ticket)
        {
            Bag bag = null;
            foreach (IEntity entiry in entitys)
            {
                bag = entiry.Pick(ticket);
                if (bag != null)
                    return bag;

            }
            return bag;
        }
    }
}
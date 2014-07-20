using System.Collections.Generic;
using Xunit;

namespace lockers.test
{
    public class ManagerFacts
    {
        public void should_manager_store_and_pick_bag_right_when_manager_manage_some_lockers()
        {
            Manager manager = new Manager(new List<IEntity> { new Locker(1), new Locker(1) });
            Bag bag = new Bag();
            var ticket = manager.Store(bag);
            Assert.Same(bag, manager.Pick(ticket));
        }
    }
}

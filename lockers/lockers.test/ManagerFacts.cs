using System.Collections.Generic;
using Xunit;

namespace lockers.test
{
    public class ManagerFacts
    {
        [Fact]
        public void
            should_manager_manages_and_can_pick_the_bag_with_the_ticket_when_he_stored_the_bag_to_the_lockers_he_manages
            ()
        {
            Manager manager = new Manager(new List<IEntity> {new Locker(1), new Locker(1)});
            Bag bag = new Bag();
            var ticket = manager.Store(bag);
            Assert.Same(bag, manager.Pick(ticket));
        }

        [Fact]
        public void
            should_manager_manages_and_can_pick_the_bag_with_the_ticket_when_he_stored_the_bag_to_the_robots_he_manages
            ()
        {
            Manager manager =
                new Manager(new List<IEntity>
                    {
                        Robot.CreateNormalRobot(new List<Locker> {new Locker(1)}, new LockerFindSequncialStrategy())
                    });
            Bag bag = new Bag();
            Ticket ticket = manager.Store(bag);
            Assert.Same(bag, manager.Pick(ticket));
        }
       
        [Fact]
        public void
            should_manager_manages_and_can_pick_the_bag_with_the_ticket_when_he_stored_the_bag_to_the_entities_he_manages
            ()
        {
            Robot normalRobot = Robot.CreateNormalRobot(new List<Locker> {new Locker(1)}, new LockerFindSequncialStrategy());
            Manager manager =
                new Manager(new List<IEntity>
                    {
                        new Locker(1),
                        normalRobot
                    });
            manager.Store(new Bag());
            Bag bag = new Bag();
            Ticket ticket = manager.Store(bag);
            Assert.Same(bag, normalRobot.Pick(ticket));
        }

    }
}

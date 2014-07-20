using System.Collections.Generic;
using Xunit;

namespace lockers.test
{
    public class SmartRobotFacts
    {
        private Bag bag;
        private Locker locker;

        public SmartRobotFacts()
        {
            bag = new Bag();
            locker = new Locker(1);
        }

        [Fact]
        public void should_smart_robot_store_a_bag_into_the_only_locker_it_manages_and_return_a_ticket_can_pick_the_bag_with_the_ticket()
        {
            Robot smartRobot = Robot.CreateSmartRobot(new List<Locker>(){locker}, new LockerFindMaxEmptyStrategy());
            Ticket ticket = smartRobot.Store(bag);
            Assert.Same(bag,smartRobot.Pick(ticket));
        }

        [Fact]
        public void
            should_smart_robot_store_a_bag_into_the_locker_has_maximum_empty_boxes_it_manage_and_return_a_ticket
            ()
        {
            Locker lockerWithOneEmptyBox = new Locker(1);
            Locker lockerWithTwoEmptyBox = new Locker(2);
            Robot smartRobot = Robot.CreateSmartRobot(new List<Locker>() {lockerWithOneEmptyBox, lockerWithTwoEmptyBox}, new LockerFindMaxEmptyStrategy());
            Ticket ticket = smartRobot.Store(bag);
            Assert.Same(bag,lockerWithTwoEmptyBox.Pick(ticket));
        }

        [Fact]
        public void
            should_smart_robot_store_a_bag_into_the_locker_has_maximum_empty_boxes_and_smaller_sequence_it_manage_and_return_a_ticket
            ()
        {
            List<Locker> lockers = new List<Locker>() {new Locker(2), new Locker(2)};
            Robot smartRobot = Robot.CreateSmartRobot(lockers, new LockerFindMaxEmptyStrategy());
            Ticket ticket = smartRobot.Store(bag);
            Assert.Same(bag, lockers[0].Pick(ticket));
        }   
    }
}

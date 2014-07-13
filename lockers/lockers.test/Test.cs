using System.Collections.Generic;
using Xunit;

namespace lockers.test
{
    public class Test
    {
        private readonly Bag bag;
        private readonly Locker locker;
        public Test()
        {
             bag= new Bag();
             locker= new Locker();
        }

        [Fact]
        public void should_store_a_bag_to_lockers_when_it_is_not_full()
        {
            
            locker.store(bag);
        }

        [Fact]
        public void should_not_store_a_bag_to_lokers_when_it_is_full()
        {
            Locker fullLocker = new Locker(0);
            Assert.Equal(null,fullLocker.store(new Bag()));
        }

        [Fact]
        public void should_get_the_right_bag_with_the_ticket_stored_it()
        {

            Ticket ticket = locker.store(bag);
            Bag pickedBag = locker.pick(ticket);
            Assert.Same(bag,pickedBag);
        }

        [Fact]
        public void should_not_get_bag_when_it_has_been_picked()
        {
            Ticket ticket = locker.store(bag);
            locker.pick(ticket);
            
            Assert.Null(locker.pick(ticket));
        }

        [Fact]
        public void should_not_get_bag_with_an_invalid_ticket()
        {
            Ticket ticket = new Ticket();
            Assert.Null(locker.pick(ticket));
        }

        [Fact]
        public void should_can_store_bag_after_the_lockers_is_full_and_one_bag_be_picked()
        {
            Locker locker1 = new Locker(1);
            Ticket ticket = locker1.store(bag);
            locker1.pick(ticket);
            locker1.store(new Bag());
        }

        [Fact]
        public void should_pick_a_bag_from_locker_when_robot_stored_it_into_the_locker_he_managed()
        {
            List<Locker> lockers = new List<Locker>();
            lockers.Add(locker);
            NormalRobot normalRobot = new NormalRobot(lockers);
            Ticket ticket = normalRobot.Store(bag, new LockerFindHighVacancyStrategy());
            Assert.Same(bag,lockers[0].pick(ticket));   
        }

        [Fact]
        public void should_pick_a_bag_from_first_locker_when_robot_stored_it_into_the_multi_lockers_he_managed()
        {
            List<Locker> lockers = new List<Locker>(){locker,new Locker()};
            Robot normalRobot = new NormalRobot(lockers);
            Ticket ticket = normalRobot.Store(bag, new LockerFindHighVacancyStrategy());
            Assert.Same(bag, lockers[0].pick(ticket));
        }

        [Fact]
        public void
            should_pick_a_bag_from_second_locker_when_robot_stored_it_into_the_multi_lockers_and_the_first_locker_is_full
            ()
        {
            Locker firstLocker = new Locker(1);
            Locker secondLocker = new Locker();
            List<Locker> lockers = new List<Locker>() { firstLocker, secondLocker };
            firstLocker.store(bag);
            NormalRobot normalRobot = new NormalRobot(lockers);

            Bag expectBag = new Bag();
            Ticket ticket = normalRobot.Store(expectBag, new LockerFindHighVacancyStrategy());
            Assert.Same(expectBag,secondLocker.pick(ticket));
        }

        [Fact]
        public void should_pick_bag_from_first_locker_when_has_picked_a_bag_from_it_when_is_was_full()
        {
            Locker firstLocker = new Locker();
            List<Locker> lockers = new List<Locker>() { firstLocker };
            NormalRobot normalRobot = new NormalRobot(lockers);
            Ticket ticketForPick = normalRobot.Store(bag, new LockerFindHighVacancyStrategy());
            firstLocker.pick(ticketForPick);

            Bag bagStore = new Bag();
            Ticket storeTicket = normalRobot.Store(bagStore, new LockerFindHighVacancyStrategy());
            Assert.Same(bagStore,normalRobot.pick(storeTicket));
        }

        [Fact]
        public void should_robot_pick_bag_from_locker_when_the_bag_in_locker_robot_manage()
        {
            Locker locker = new Locker();
            List<Locker> lockers = new List<Locker>() { locker };
            NormalRobot normalRobot = new NormalRobot(lockers);

            Bag expectBag = new Bag();
            Ticket ticket = normalRobot.Store(expectBag, new LockerFindHighVacancyStrategy());
            Assert.Same(expectBag,normalRobot.pick(ticket));
        }

        [Fact]
        public void should_robot_pick_bag_from_lockers_when_robot_manage_multi_lockers_and_the_bag_in_lockers()
        {
            List<Locker> lockers = new List<Locker>() { new Locker(1), new Locker()};
            NormalRobot normalRobot = new NormalRobot(lockers);
            normalRobot.Store(new Bag(), new LockerFindHighVacancyStrategy());

            Bag expectBag = new Bag();
            Ticket ticket = normalRobot.Store(expectBag, new LockerFindHighVacancyStrategy());
            Assert.Same(expectBag, normalRobot.pick(ticket));
        }

        [Fact]
        public void should_robot_pick_bag_from_first_locker_when_robot_manage_multi_lockers_and_the_first_bag_from_full_to_unfilled_then_store_a_bag_to_lockers()
        {
            List<Locker> lockers = new List<Locker>() {new Locker(1), new Locker()};
            NormalRobot normalRobot = new NormalRobot(lockers);
            var storedTicket = normalRobot.Store(new Bag(), new LockerFindHighVacancyStrategy());
            normalRobot.pick(storedTicket);

            Bag expectBag = new Bag();
            Ticket ticket = normalRobot.Store(expectBag, new LockerFindHighVacancyStrategy());
            Assert.Same(expectBag, normalRobot.pick(ticket));
        }

        [Fact]
        public void should_robot_not_get_the_bag_when_it_has_been_picked()
        {

            Locker locker = new Locker();
            List<Locker> lockers = new List<Locker>() { locker };
            NormalRobot normalRobot = new NormalRobot(lockers);

            Ticket ticket = normalRobot.Store(new Bag(), new LockerFindHighVacancyStrategy());
            normalRobot.pick(ticket);
            Assert.Null(normalRobot.pick(ticket));
        }

    }
}

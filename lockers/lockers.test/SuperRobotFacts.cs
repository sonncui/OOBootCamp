﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace lockers.test
{
    public class SuperRobotFacts
    {
        [Fact]
        public void
            should_super_robot_store_a_bag_to_the_locker_he_manages_and_can_pick_the_bag_with_the_ticket_when_he_stored_the_bag
            ()
        {
            Robot superRobot = Robot.CreateSuperRobot(new List<Locker>(){new Locker()}, new LockerFindHighVacancyStrategy());
            Bag bag = new Bag();
            Ticket ticket = superRobot.Store(bag);
            Assert.Same(bag,superRobot.Pick(ticket));
        }

        [Fact]
        public void should_super_robot_store_the_bag_to_the_locker_which_has_the_highest_vacancy_rate()
        {
            Locker lockerWithLowerCavancyRate = new Locker(5);
            lockerWithLowerCavancyRate.Store(new Bag());
            Locker lockerWithHigherCavancyRate = new Locker(1);
            Robot superRobot = Robot.CreateSuperRobot(new List<Locker>() {lockerWithLowerCavancyRate, lockerWithHigherCavancyRate}, new LockerFindHighVacancyStrategy());

            Bag bagToStore = new Bag();
            Ticket ticket = superRobot.Store(bagToStore);
            Assert.Same(bagToStore,lockerWithHigherCavancyRate.Pick(ticket));
        }
    }
}

namespace lockers.test
{
}

using System.Collections.Generic;

namespace lockers.test
{
    public class Locker
    {
        public int Capacity { get; set; }
        public int emptyBox { get; private set; }
        private Dictionary<Ticket, Bag> bagTicket = new Dictionary<Ticket, Bag>();

        public bool isFull()
        {
            return emptyBox == 0;
        }

        public Locker(int capacity)
        {
            Capacity = capacity;
            emptyBox = capacity;
            
           
        }

        public Locker()
        {
            Capacity = 100;
            emptyBox = Capacity;
        }

        public Ticket store(Bag bag)
        {
            if (emptyBox == 0)
            {
                return null;
            }
            var ticket = new Ticket();
            bagTicket.Add(ticket,bag);
            emptyBox--;
            return ticket;
        }

        public Bag pick(Ticket ticket)
        {
            Bag bag = null;
            if (ticket.ticketValid == true && bagTicket.ContainsKey(ticket))
            {
                bag = bagTicket[ticket];
                bagTicket.Remove(ticket);
                ticket.ticketValid = false;
                emptyBox++;
            }
            
            return bag;
        }


        public double GetVacancyRate()
        {
            return emptyBox/(double)Capacity;
        }
    }
}
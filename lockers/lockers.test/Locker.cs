using System.Collections.Generic;

namespace lockers.test
{
    public class Locker:IEntity
    {
        public int Capacity { get; set; }
        public int EmptyBox { get; private set; }
        private Dictionary<Ticket, Bag> bagTicket = new Dictionary<Ticket, Bag>();

        public bool IsFull()
        {
            return EmptyBox == 0;
        }

        public Locker(int capacity)
        {
            Capacity = capacity;
            EmptyBox = capacity;
            
           
        }

        public Locker()
        {
            Capacity = 100;
            EmptyBox = Capacity;
        }

        public Ticket Store(Bag bag)
        {
            if (EmptyBox == 0)
            {
                return null;
            }
            var ticket = new Ticket();
            bagTicket.Add(ticket,bag);
            EmptyBox--;
            return ticket;
        }

        public Bag Pick(Ticket ticket)
        {
            Bag bag = null;
            if (ticket.ticketValid == true && bagTicket.ContainsKey(ticket))
            {
                bag = bagTicket[ticket];
                bagTicket.Remove(ticket);
                ticket.ticketValid = false;
                EmptyBox++;
            }
            
            return bag;
        }


        public double GetVacancyRate()
        {
            return EmptyBox/(double)Capacity;
        }
    }
}
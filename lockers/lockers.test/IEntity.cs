namespace lockers.test
{
    public interface IEntity
    {
        Ticket Store(Bag bag);
        Bag Pick(Ticket ticket);
        bool IsFull();
    }
}
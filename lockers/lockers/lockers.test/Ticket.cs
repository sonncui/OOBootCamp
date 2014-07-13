public class Ticket
{
    private static int ticketSquence = 1;
    public bool ticketValid { get; set; }
    
    public Ticket()
    {
        ticketValid = true;
        ticketSquence++;
    }
    
}
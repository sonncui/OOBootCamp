using System.Collections.Generic;

namespace lockers.test
{
    public interface IFindStrategy
    {
        Locker FindStrategy(List<Locker> lockers);
    }
}
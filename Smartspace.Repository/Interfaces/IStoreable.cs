using System;

namespace Smartspace.Repository.Interfaces
{
    public interface IStoreable
    {
        IComparable Id { get; set; }
    }
}

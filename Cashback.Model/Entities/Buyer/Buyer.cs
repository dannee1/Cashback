using Cashback.Commom.AggregateRoots;
using Cashback.Commom.Entities;
using System;


namespace Cashback.Domain.Entities.BuyerAggregate
{
    public class Buyer : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }

        public Buyer(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

    }
}

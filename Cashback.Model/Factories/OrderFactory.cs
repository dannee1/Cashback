using Cashback.Domain.Entities;
using Cashback.Domain.Entities.BuyerAggregate;
using Cashback.Domain.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cashback.Domain.Factories
{
    public class OrderFactory
    {
        public static Order Create(Buyer buyer,List<BasketItem> basketItems)
        {
           List<OrderItem> orderedItens = new List<OrderItem>();

           basketItems.ForEach(basketItem => orderedItens.Add(
                                  new OrderItem(new OrderedDisk(basketItem.Disk.Id,
                                                                basketItem.Disk.Name,
                                                                basketItem.Disk.Genre
                                                                ),
                                                basketItem.Disk.Price, basketItem.Unit)
                                    )
            );

           Order order = new Order(buyer, orderedItens);
           return order;
            
        }
    }
}

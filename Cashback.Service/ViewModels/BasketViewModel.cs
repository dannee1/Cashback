using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cashback.Service.ViewModels
{
    public class BasketViewModel
    {
        public Guid BuyerId { get; set; }
        public List<BasketViewItemModel> BasketItems { get; set; }
}
}

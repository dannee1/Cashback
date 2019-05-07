using System;
using System.Collections.Generic;
using System.Text;

namespace Cashback.Commom.Publisher
{
    public abstract class Query : Message
    {
        public DateTime Timestamp { get; private set; }

        protected Query()
        {
            Timestamp = DateTime.Now;
        }

    }
}

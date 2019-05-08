﻿using Cashback.Commom.AggregateRoots;
using Cashback.Commom.Entities;
using Cashback.Domain.Enumerators;
using Cashback.Domain.Exceptions;
using System;

namespace Cashback.Domain.Entities
{
    public class Disk: BaseEntity, IAggregateRoot
    {
        private const decimal PRICE_MIN = 0.01M;
        private const decimal PRICE_MAX = 9000.9m;

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DiskGenreEnum Genre { get; private set; }

        protected Disk() { }

        public Disk( string name, string description, decimal price, DiskGenreEnum genre)
        {
            Guardian.CheckRange(price, PRICE_MIN, PRICE_MAX);

            Name = name;
            Description = description;
            Price = price;
            Genre = genre;
        }
    }
}

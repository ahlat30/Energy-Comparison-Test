﻿using EnergyComparisonTest.Domain.Interfaces;

namespace EnergyComparisonTest.Domain
{
    public class Packaged : ITariff
    {
        public string TariffName { get; set; }
        public int Base { get; set; }
        public decimal PricePerKwh { get; set; }
        public decimal Amount { get; set; }
        public IProducts ProductProcessor { get; set; } = new PackagedElectricity();
    }
}

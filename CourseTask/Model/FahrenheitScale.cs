﻿using System;

namespace Model
{
    public class FahrenheitScale : IScale
    {
        private const string name = "Fahrenheit, °F";

        public string Name { get => name; }

        public double? ConvertCelsiusToOtherScale(double? value)
        {
            return value * 1.8 + 32;
        }

        public double? ConvertTemperatureToCelsius(double? value)
        {
            if (value != null)
            {
                return (Convert.ToDouble(value) - 32) * 5 / 9;
            }
            return value;
        }
    }
}
﻿using System;

namespace Model
{
    public class Kelvin : ITemperatureModel
    {
        private double? degree;

        public Kelvin(string scale)
        {
            DescriptionScale = scale;
        }

        public string DescriptionScale { get; }

        public double? DegreeToCelsius
        {
            get => degree;
            set
            {
                if (value != null)
                {
                    degree = Convert.ToDouble(value) - 273.15;
                }
                else
                {
                    degree = value;
                }
            }
        }

        public double? CelsiusToDegree { get => degree + 273.15; set => degree = value; }
    }
}

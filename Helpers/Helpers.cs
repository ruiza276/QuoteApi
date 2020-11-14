using System;
using System.Collections.Generic;
using QuoteApi.Models;

namespace QuoteApi.Helpers
{
    
    public class FormulaHelper
    {
        private const int HazardFactor = 4;
        public PremiumItem Calculate (QuoteItem item)
        {
            var BusinessFactor = PopulateBusinessFactor();
            var StateFactor = PopulateStateFactor();
            double businessFactor;
            double stateFactor;

            if (!StateFactor.ContainsKey((item.State).ToUpper()))
            {
                throw new ArgumentException(
                    $"We do not have any data for {item.State}. Please ENTER: 'OH', 'TX' or 'FL'");
            }
            else
            {
                stateFactor = StateFactor[(item.State).ToUpper()];
            }

            if (!BusinessFactor.ContainsKey((item.Business).ToLower()))
            {
                throw new ArgumentException(
                    $"We do not have any data for {item.Business}. Please ENTER: 'Architect', 'Plumber' or 'Programmer'");
            }
            else
            {
                businessFactor = BusinessFactor[(item.Business).ToLower()];
            }

            var basePremium = CalculateBasePremium(item);
            var hazardFactor = HazardFactor;

            var premium = new PremiumItem
            {
                Premium = Math.Round((stateFactor*businessFactor*basePremium*hazardFactor), 2, MidpointRounding.AwayFromZero )
            };

            return premium;
        }

        public double CalculateBasePremium (QuoteItem item)
        {
            double rev  = item.Revenue;
            double basePremium = Math.Ceiling((rev / 1000));
            return basePremium;
        }

        public Dictionary<string, double>  PopulateStateFactor()
        {
          Dictionary<string, double> StateFactor =  new Dictionary<string, double>();
          StateFactor.Add("OH", 1);
          StateFactor.Add("FL", 1.2); 
          StateFactor.Add("TX", 0.943);  
            
          return StateFactor;
        }
        public Dictionary<string, double> PopulateBusinessFactor()
        {
          Dictionary<string, double> BusinessFactor =  new Dictionary<string, double>();
          BusinessFactor.Add("architect", 1); 
          BusinessFactor.Add("plumber", 0.5);
          BusinessFactor.Add("programmer", 1.25);

          return BusinessFactor;
        }

    } 

}
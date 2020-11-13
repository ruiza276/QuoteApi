using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QuoteApi.Models;

namespace QuoteApi.Helpers
{
    
    public class FormulaHelper
    {
        public PremiumItem Calculate (QuoteItem item)
        {
            var BusinessFactor = PopulateBusinessFactor();
            var StateFactor = PopulateStateFactor();

            double stateFactor = StateFactor[item.State];
            double businessFactor = BusinessFactor[item.Business];

            double basePremium = CalculateBasePremium(item);
            double hazardFactor = CalculateHazardFactor(item);

            var premium = new PremiumItem
            {
                Premium = (stateFactor*businessFactor*basePremium*hazardFactor)
            };

            return premium;
        }

        public double CalculateBasePremium (QuoteItem item)
        {
            double rev  = item.Revenue;
            double basePremium = Math.Ceiling((rev / 1000));
            return basePremium;
        }

        public double CalculateHazardFactor (QuoteItem item)
        {

            return 4; //errrrrrrrrrrrrrrrrrr i didnt see any formula to calculate this but im assuming there is one? :grimancing:
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
          BusinessFactor.Add("Architect", 1); 
          BusinessFactor.Add("Plumber", 0.5);
          BusinessFactor.Add("Programmer", 1.25);

          return BusinessFactor;
        }

    } 

}
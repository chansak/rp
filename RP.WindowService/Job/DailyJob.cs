﻿using RP.Interfaces;
using RP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP.WindowService
{
    public interface IJob
    {
        void Start();
    }
    public class DailyJob : IJob
    {
        public void Start()
        {
            var currentDate = DateTime.Now;
            try
            {
                if (currentDate.HasWeightCalculationJob())
                {
                    var documents = GenericFactory.Business.AlreadyGotPODocumentsList();
                    var calculator = new WeightCalculator();
                    var period = 120;
                    foreach (var document in documents)
                    {
                        var documentId = document.Id;
                        var totolPrice = document.DocumentProductItems
                            .Where(i => !i.IsDeleted)
                            .Sum(i => i.Amount * i.PricePerUnit);
                        var points = calculator.WithPeriod(period)
                            .WithCurrentDate(currentDate)
                            .WithPoDateDate(document.PoDate.Value)
                            .WithTotalPrice(totolPrice)
                            .WithCustomerLevel(document.Customer.CustomerLevel.Value)
                            .CalculateWeightPoint();
                        document.WeightPoint = Convert.ToInt32(Math.Round(points));
                        GenericFactory.Business.UpdateDocumentWeightPoint(document);
                    }
                }
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP.WindowService
{
    public class WeightCalculator
    {
        private DateTime _poDate;
        public DateTime PoDate
        {
            get { return _poDate; }
            set { _poDate = value; }
        }
        private DateTime dateTime;
        public DateTime CurrentDate
        {
            get { return dateTime; }
            set { dateTime = value; }
        }
        private int _period;
        public int Period
        {
            get { return _period; }
            set { _period = value; }
        }
        private decimal _totalPrice;
        public decimal TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; }
        }
        private int _level;
        public int CustomerLevel
        {
            get { return _level; }
            set { _level = value; }
        }

        public WeightCalculator()
        {
        }
        public WeightCalculator WithCurrentDate(DateTime date) {
            this.CurrentDate = date;
            return this;
        }
        public WeightCalculator WithPeriod(int number)
        {
            this.Period = number;
            return this;
        }
        public WeightCalculator WithPoDateDate(DateTime issuedDate) {
            this.PoDate = issuedDate;
            return this;
        }
        public WeightCalculator WithTotalPrice(decimal price) {
            this._totalPrice = price;
            return this;
        }
        public WeightCalculator WithCustomerLevel(int level)
        {
            this._level = level;
            return this;
        }
        public double CalculateWeightPoint() {
             var formula = new Weightformula(this.CurrentDate,this.Period,this.PoDate,this.TotalPrice,this.CustomerLevel);
            return formula.SumPoints();
        }
    }
}

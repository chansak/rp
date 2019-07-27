using RP.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP.WindowService
{
    public interface IWeightformula
    {
        double SumPoints();
    }
    public class Weightformula : IWeightformula
    {
        private const double WEIGHT_TIME_POINT = 0.5;
        private const double WEIGHT_VALUE_POINT = 0.3;
        private const double WEIGHT_CUSTOMER_POINT = 0.2;
        private readonly DateTime _currentDate;
        private readonly DateTime _issuedDate;
        private readonly int _period;
        private readonly decimal _totalPrice;
        private readonly int _customerLevel;
        public Weightformula(DateTime currentDate, int period, DateTime issuedDate, decimal totalPrice, int customerLevel)
        {
            this._currentDate = currentDate;
            this._period = period;
            this._issuedDate = issuedDate;
            this._totalPrice = totalPrice;
            this._customerLevel = customerLevel;
        }

        private double SumTimePoint
        {
            get
            {
                var expiryDate = this._issuedDate.AddDays(this._period);
                var dayLeft = expiryDate.Subtract(this._currentDate).Days;
                double point = 100 - (dayLeft * 100) / this._period;
                return point * WEIGHT_TIME_POINT;
            }
        }
        private double SumValuesPoint
        {
            get
            {
                var valuePoint = 0;
                if (this._totalPrice >= 0 && this._totalPrice <= Decimal.Parse("29,999"))
                {
                    valuePoint = 5;
                }
                else if (this._totalPrice >= Decimal.Parse("30,000") && this._totalPrice <= Decimal.Parse("99,999"))
                {
                    valuePoint = 10;
                }
                else if (this._totalPrice >= Decimal.Parse("100,000") && this._totalPrice <= Decimal.Parse("499,999"))
                {
                    valuePoint = 25;
                }
                else if (this._totalPrice >= Decimal.Parse("500,000") && this._totalPrice <= Decimal.Parse("1,999,999"))
                {
                    valuePoint = 50;
                }
                else if (this._totalPrice >= Decimal.Parse("2,000,000") && this._totalPrice <= Decimal.Parse("4,999,999"))
                {
                    valuePoint = 75;
                }
                else if (this._totalPrice >= Decimal.Parse("5,000,000"))
                {
                    valuePoint = 100;
                }
                else
                {
                    valuePoint = 0;
                }
                return valuePoint * WEIGHT_VALUE_POINT;
            }
        }
        private double SumCustomerPoint
        {
            get
            {
                var customerLevel = (CustomerLevel)_customerLevel;
                var pointLevel = 0;
                switch (customerLevel)
                {
                    case CustomerLevel.A:
                        {
                            pointLevel = 100;
                            break;
                        }
                    case CustomerLevel.B:
                        {
                            pointLevel = 75;
                            break;
                        }
                    case CustomerLevel.C:
                        {
                            pointLevel = 50;
                            break;
                        }
                    case CustomerLevel.D:
                        {
                            pointLevel = 0;
                            break;
                        }
                }
                return pointLevel * WEIGHT_CUSTOMER_POINT;
            }
        }
        public double SumPoints()
        {
            return this.SumTimePoint + this.SumValuesPoint + this.SumCustomerPoint;
        }
    }
}

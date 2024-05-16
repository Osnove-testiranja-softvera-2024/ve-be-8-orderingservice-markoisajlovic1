using OTS2023_V9.Models;
using OTS2023_V9.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS2023_V9.Fakes
{
    public class CouponServiceFakeException : ICouponService
    {
        public bool usedCoupon;
        public double MinimalRequiredOrderTotal;
        public DateTime expirationDate;
        public double amount;

        public Coupon GetCouponById(Guid id)
        {
            Coupon coupon = new Coupon();
            coupon.Id = id;
            coupon.Used = usedCoupon;
            coupon.MinimalRequiredOrderTotal = MinimalRequiredOrderTotal;
            coupon.ExpirationDate = expirationDate;
            coupon.Amount = amount;
            return coupon;
        }

        public void UseCoupon(Guid id)
        {
            throw new InvalidCouponException("istekao kupon");
        }
    }
}

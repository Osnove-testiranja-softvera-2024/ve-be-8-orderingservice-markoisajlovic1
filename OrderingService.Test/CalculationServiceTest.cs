using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OTS2023_V9.Fakes;
using OTS2023_V9.Models;
using System.Security.Cryptography;
using OTS2023_V9.Services;
using System.ComponentModel;


namespace OrderingService.Test
{
    [TestFixture]
    internal class CalculationServiceTest
    {
        [TestCase(true)]

        public void checkCuponValiditi_OkInput(bool expoectedValidity)
        {
            OrderServiceFake osf = new OrderServiceFake();
            CouponServiceFake csf = new CouponServiceFake();
            // pise !coupon.used!!
            csf.usedCoupon = false;
            csf.MinimalRequiredOrderTotal = 500;
            csf.expirationDate = DateTime.Now.AddDays(1);
            osf.total = 1000;

            CalculationService service = new CalculationService(osf,csf,null);


            bool valid = service.CheckCouponValidity(new Guid(), new Guid());


            Assert.That(expoectedValidity, Is.EqualTo(valid));

        }



        [Test]
        public void ApplyCoupon_Excpetion()
        {
            CouponServiceFakeException csf = new CouponServiceFakeException();
            OrderServiceFake osf = new OrderServiceFake();
            LoggerServiceFake lsf = new LoggerServiceFake();

            CalculationService service = new CalculationService(osf,csf,lsf);

            Coupon coupon = csf.GetCouponById(new Guid());

            service.ApplyCoupon(new Guid(),coupon);

            Assert.That(lsf.lastError, Is.EqualTo("[CouponInvalidException] istekao kupon"));


        }


        [Test]
        public void ApplyCoupon_Valid()
        {
            CouponServiceFake csf = new CouponServiceFake();
            OrderServiceFake osf = new OrderServiceFake();
            csf.amount = 1000;
            Coupon cupon = csf.GetCouponById(new Guid());
            

            CalculationService service = new CalculationService(osf, csf, null);

            service.ApplyCoupon(new Guid(), cupon);

            Assert.That(cupon.Id, Is.EqualTo(csf.usedCouponId));
        }

    }
}

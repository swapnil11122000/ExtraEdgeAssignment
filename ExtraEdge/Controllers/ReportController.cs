using ExtraEdge.Data;
using ExtraEdge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace ExtraEdge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public ReportController(ApplicationDbContext db)
        {
            this.db = db;
        }


        [HttpGet("GetMonthlySalesReport")]
        public ActionResult GetMonthlySalesReport(DateTime fromDate, DateTime toDate)
        {
            var purchases = (from p in db.purchases
                           where p.PurchaseDate > fromDate && p.PurchaseDate < toDate
                           select p).ToList();

            var totalSales = purchases.Sum(p => p.FinalPrice);

            

            return new ObjectResult(purchases);
        }


        [HttpGet("sales-report-by-brand")]
        public IActionResult GetSalesReportByBrand(DateTime fromDate, DateTime toDate)
        {
            var salesByBrand = from p in db.purchases
                               join mb in db.mobiles on p.MobileId equals mb.MobileId into mobilepurchase
                               where p.PurchaseDate > fromDate && p.PurchaseDate < toDate

                               select new
                               {
                                   
                                   purchasedate = p.PurchaseDate,
                                   purchaseprice = p.PurchasePrice,
                                   discount = p.Discount,
                                   finalprice = p.FinalPrice,
                                  
                               };
                              
                             



            return Ok(salesByBrand);
        }

        [HttpGet("profit-loss-report")]
        public async Task<ActionResult<ProfitLossData>> GetProfitLossReport(DateTime fromDate, DateTime toDate)
        {
            // Getting the purchases between the given dates
            var purchases = await db.purchases
                .Where(p => p.PurchaseDate >= fromDate && p.PurchaseDate <= toDate)
                .ToListAsync();

            // Calculating the total sales value, discount, and purchase price
            decimal totalSales = purchases.Sum(p => p.FinalPrice);
            decimal totalDiscount = purchases.Sum(p => p.Discount);
            decimal totalPurchasePrice = purchases.Sum(p => p.PurchasePrice);

            // Getting the purchases between the previous timeline dates
            var prevPurchases = await db.purchases
                .Where(p => p.PurchaseDate >= fromDate.AddYears(-1) && p.PurchaseDate <= toDate.AddYears(-1))
                .ToListAsync();

            // Calculating the total sales value and discount for the previous timeline
            decimal prevTotalSales = prevPurchases.Sum(p => p.FinalPrice);
            decimal prevTotalDiscount = prevPurchases.Sum(p => p.Discount);

            // Calculating the profit/loss by subtracting the purchase price and discount from the total sales value
            decimal profitLoss = totalSales - totalDiscount - totalPurchasePrice;

            // Calculating the profit/loss compared to the previous timeline, taking into account the discounts
            decimal prevProfitLoss = prevTotalSales - prevTotalDiscount - totalPurchasePrice;
            decimal diff = profitLoss - prevProfitLoss;

            // Creating a ProfitLossData object to hold the results
            var result = new ProfitLossData
            {
                TotalSales = totalSales,
                TotalDiscount = totalDiscount,
                TotalPurchasePrice = totalPurchasePrice,
                ProfitLoss = profitLoss - diff 
            };

            return result;
        }


    }

}

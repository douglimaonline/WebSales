using System.ComponentModel.DataAnnotations;
using WebSales.Models.Enums;

namespace WebSales.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double Amount { get; set; }
        public SalesRecordEnums Status { get; set; }
        public Seller Seller { get; set; }

        public SalesRecord()
        {
        }

        public SalesRecord(int id, DateTime date, double amout, SalesRecordEnums status, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amout;
            Status = status;
            Seller = seller;
        }
    }
}

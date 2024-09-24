using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs
{
    public class IncomeExpenseListViewDTO
    {
        public Guid Id { get; set; }  
        public string CategoryName { get; set; }  
        public decimal Amount { get; set; }  
        public DateTime Date { get; set; }  
        public string Type { get; set; }
    }
}

using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs
{
    public class AddIncomeRequestDTO
    {
        public string username { get; set; }
        public decimal amount {  get; set; } 
        public Category category { get; set; }
        public DateTime date { get; set; }
    }
}

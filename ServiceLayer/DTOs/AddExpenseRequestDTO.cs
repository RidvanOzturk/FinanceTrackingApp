using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs;

public class AddExpenseRequestDTO
{
    public string username { get; set; }
    public decimal amount { get; set; }
    public Guid CategoryId { get; set; }
    public DateTime date { get; set; }
}

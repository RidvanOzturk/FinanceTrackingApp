using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs;

public class ReportAsyncViewModel
{
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }

    public Guid? categoryId { get; set; }
}

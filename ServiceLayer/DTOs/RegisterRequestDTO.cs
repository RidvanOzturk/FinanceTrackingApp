using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs
{
    public class RegisterRequestDTO
    {
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }
}

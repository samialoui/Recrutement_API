using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class AppConfirm
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime DateConfirm { get; set; }
    }
}

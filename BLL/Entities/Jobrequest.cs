using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class Jobrequest
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}")]
        public DateTime RequestDate { get; set; }
        public User? User { get; set; }
        public int ClientId { get; set; }
        public Client? Client { get; set; }
        public int JobId { get; set; }
        public Job? Job { get; set; }

    }
}

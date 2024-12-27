using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Api_App.Application.DTOs.TransactionDto
{
    public class AddTransactionDto
    {
        public int StudentId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string TransactionType { get; set; }
        public DateTime Date { get; set; }
    }

}

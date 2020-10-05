using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paschoalotto.Model
{
    public class DebtInstallments
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public DateTime DueDate { get; set; }
        public float Price { get; set; }
    }
}

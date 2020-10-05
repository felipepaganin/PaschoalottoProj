using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paschoalotto.Model
{
    public class Debt
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public float Interest { get; set; }
        public float FineFee { get; set; }
        public List<DebtInstallments> debtInstallments { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using Paschoalotto.Infrastructure.Data;
using Paschoalotto.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paschoalotto.Application.Services
{
    public interface IDebtService
    {
        Task<Debt> Create(Debt data);
    }
    public class DebtService : IDebtService
    {
        private readonly IWriteRepository<Debt> _writeRepository;
        private readonly IUnitOfWork _ouw;


        public DebtService(IWriteRepository<Debt> writeRepository, IUnitOfWork ouw)
        {
            _writeRepository = writeRepository ?? throw new ArgumentNullException(nameof(writeRepository));
            _ouw = ouw ?? throw new ArgumentNullException(nameof(ouw));

        }

        public async Task<Debt> Create(Debt data)
        {

            List<DebtInstallments> parcel = new List<DebtInstallments>();
            var result = new Debt();

            result.Id = Guid.NewGuid();
            result.Name = data.Name;
            result.Number = data.Number;
            result.CPF = data.CPF;
            result.FineFee = data.FineFee;
            result.Interest = data.Interest;

            foreach (var x in data.debtInstallments)
            {
                parcel.Add(new DebtInstallments() { Id = Guid.NewGuid(), Number = x.Number, DueDate = x.DueDate, Price = x.Price });
            }

            result.debtInstallments = parcel;

            await _writeRepository.AddAsync(result);

            await _ouw.CommitAsync();

            return result;
        }
        //        Exemplo:

        //Titulo: 101010
        //Multa: 2%
        //Juros: 1% ao mês
        //Parcelas:
        //Parcela número 10
        //Data vencimento: 10/07/2020
        //Valor: 100,00
        //Parcela número 11
        //Data vencimento: 10/08/2020
        //Valor: 100,00
        //Parcela número 12
        //Data vencimento: 10/09/2020
        //Valor: 100,00
        //Na listagem, teremos:

        //Número do título: 101010
        //Nome do devedor: Fulano
        //Qtde de parcelas: 3
        //Valor original(soma das parcelas do título): 300,00
        //Dias em atraso: 73 dias em atraso(supondo que hoje é 21/09/2020)
        //Valor atualizado na data de hoje: 310,20
        //Valor original = 300,00 +
        //Multa = 300,00 * 0,02 = 6,00
        //Juros = 4,20
        //Parcela 10 – 73 dias
        //Valor = (1 % / 30) * 73 * 100,00 (valor da parcela) = 2,43
        //Parcela 11 – 42 dias
        //Valor = (1 % / 30) * 42 * 100,00 (valor da parcela) = 1,40
        //Parcela 12 – 11 dias
        //Valor = (1 % / 30) * 11 * 100,00 (valor da parcela) = 0,37
    }
}

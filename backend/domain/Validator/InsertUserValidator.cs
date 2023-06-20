using Api.Domain.Model;
using FluentValidation;

namespace Api.Domain.Validator
{
    public class InsertUserValidator : AbstractValidator<InsertUserModel>
    {
        public InsertUserValidator()
        {

            RuleFor(x => x.CPF)
                .NotEmpty().WithMessage("CPF é obrigatório")
                .Must(cpf => ValidCPF(cpf)).WithMessage("CPF inválido");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Endereço é obrigatório");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-mail é obrigatório")
                .EmailAddress().WithMessage("E-mail inválido");

            RuleFor(x => x.State)
                .NotEmpty().WithMessage("Estado é obrigatório");

            RuleFor(x => x.CEP)
                .NotEmpty().WithMessage("CEP é obrigatório");

            RuleFor(x => x.SafeCode)
                .NotEmpty().WithMessage("Código de segurança é obrigatório");

            RuleFor(x => x.CardName)
                .NotEmpty().WithMessage("Nome cartão é obrigatório");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nome é obrigatório");

            RuleFor(x => x.CardNumber)
                .NotEmpty().WithMessage("Número cartão é obrigatório");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("Cidade é obrigatória");

            RuleFor(x => x.PaymentType)
                .NotNull().WithMessage("Forma de pagamento é obrigatória");

            RuleFor(x => x.MonthExpiration)
                .NotEmpty().WithMessage("Data de expiração é obrigatória");

            RuleFor(x => x.YearExpiration)
                .NotEmpty().WithMessage("Data de expiração é obrigatória");
        }

        private static bool ValidCPF(string cpf)
        {
            int[] multiple1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiple2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string verifier;
            int sum;
            int rest;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf[..9];
            sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiple1[i];

            rest = sum % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            verifier = rest.ToString();

            tempCpf += verifier;

            sum = 0;

            for (int i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiple2[i];

            rest = sum % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            verifier += rest.ToString();

            return cpf.EndsWith(verifier);
        }
    }
}

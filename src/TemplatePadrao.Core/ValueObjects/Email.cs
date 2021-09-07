using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace TemplatePadrao.Core.ValueObjects
{
    public class Email
    {
        public const int EnderecoMaxLength = 254;
        public const int EnderecoMinLength = 5;
        public string Endereco { get; private set; }

        //Construtor do EntityFramework
        protected Email() { }

        public Email(string endereco)
        {
            Endereco = endereco;
        }

        public IEnumerable<string> Validar()
        {
            return new EmailValidation().Validate(this).Errors.Select(p => $"{p.PropertyName}: {p.ErrorMessage}");
        }

        public class EmailValidation : AbstractValidator<Email>
        {

            public EmailValidation()
            {
                RuleFor(p => p.Endereco)
                      .EmailAddress()
                      .WithMessage("Email inválido");
            }
        }
    }
}

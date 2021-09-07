using FluentValidation;
using System.Collections.Generic;

namespace TemplatePadrao.Core.ValueObjects
{
    public class Endereco
    {
        public Endereco()
        {

        }

        public Endereco(string cep, string pais, string uf, string cidade, string bairro, string logradouro, string numero, string complemento)
        {
            Cep = cep;
            Pais = pais;
            Uf = uf;
            Cidade = cidade;
            Bairro = bairro;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
        }

        public string Cep { get; private set; }
        public string Pais { get; private set; }
        public string Uf { get; private set; }
        public string Cidade { get; private set; }
        public string Bairro { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }

        public void Atualizar(Endereco endereco)
        {
            Cep = endereco.Cep;
            Pais = endereco.Pais;
            Uf = endereco.Uf;
            Cidade = endereco.Cidade;
            Bairro = endereco.Bairro;
            Logradouro = endereco.Logradouro;
            Numero = endereco.Numero;
            Complemento = endereco.Complemento;
        }

        public class EnderecoValidation : AbstractValidator<Endereco>
        {

            public EnderecoValidation()
            {
                RuleFor(p => p.Cep)
                        .NotEmpty()
                        .WithMessage("Campo obrigatório")
                        .MaximumLength(8)
                        .WithMessage("Quantidade máxima de caracteres {MaxLength}");

                RuleFor(p => p.Uf)
                        .NotEmpty()
                        .WithMessage("Campo obrigatório")
                        .MaximumLength(2)
                        .WithMessage("Quantidade máxima de caracteres {MaxLength}");

                RuleFor(p => p.Numero)
                        .NotEmpty()
                        .WithMessage("Campo obrigatório");
            }
        }
    }
}

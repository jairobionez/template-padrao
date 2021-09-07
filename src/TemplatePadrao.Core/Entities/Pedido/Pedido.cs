using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using TemplatePadrao.Core.Interfaces;
using TemplatePadrao.Core.ValueObjects;
using static TemplatePadrao.Core.Entities.PedidoItem;
using static TemplatePadrao.Core.ValueObjects.Cpf;
using static TemplatePadrao.Core.ValueObjects.Endereco;

namespace TemplatePadrao.Core.Entities
{
    public class Pedido : EntityBase, IAggregateRoot
    {
        public Pedido(string nroPedido, string cliente, string telefone, Cpf cpf, Endereco endereco)
        {
            NroPedido = nroPedido;
            Cliente = cliente;
            Telefone = telefone;
            Cpf = cpf;
            Endereco = endereco;
        }

        protected Pedido()
        {

        }

        public string NroPedido { get; private set; }
        public string Cliente { get; private set; }
        public string Telefone { get; private set; }
        public Cpf Cpf { get; private set; }
        public Endereco Endereco { get; private set; }
        public virtual ICollection<PedidoItem> Itens { get; private set; }

        public void Atualizar(Pedido pedido)
        {
            NroPedido = pedido.NroPedido;
            Cliente = pedido.Cliente;
            Telefone = pedido.Telefone;
            Cpf = pedido.Cpf;
            Endereco = pedido.Endereco;
        }

        public decimal ValorTotal() => Itens.Sum(p => p.ValorTotal());

        public void AdicionarItem(List<PedidoItem> itens)
        {
            if (Itens == null)
                Itens = new List<PedidoItem>();

            itens.ForEach(item => Itens.Add(item));
        }

        public void AdicionarItem(PedidoItem item)
        {
            if (Itens == null)
                Itens = new List<PedidoItem>();

            Itens.Add(item);
        }

        public void RemoverItem(PedidoItem item)
        {
            Itens.Remove(item);
        }

        public void RemoverItem(List<PedidoItem> itens)
        {
            itens.ForEach(item => Itens.Remove(item));
        }

        public class PedidoValidation : AbstractValidator<Pedido>
        {

            public PedidoValidation()
            {
                RuleFor(p => p.NroPedido)
                    .NotNull()
                    .WithMessage("Campo obrigatório");

                RuleFor(p => p.Endereco).SetInheritanceValidator(e =>
                {
                    e.Add<Endereco>(new EnderecoValidation());
                });

                RuleFor(p => p.Cpf).SetInheritanceValidator(e =>
                {
                    e.Add<Cpf>(new CpfValidation());
                });

                RuleForEach(p => p.Itens)
                    .SetValidator(new PedidoItemValidation());
            }
        }
    }
}

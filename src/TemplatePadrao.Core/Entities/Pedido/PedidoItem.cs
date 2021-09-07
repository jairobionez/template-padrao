using FluentValidation;
using System;
using TemplatePadrao.Core.Interfaces;

namespace TemplatePadrao.Core.Entities
{
    public class PedidoItem : EntityBase, IAggregate
    {
        public PedidoItem(string nome, int quantidade, decimal valor, Guid pedidoId)
        {
            Nome = nome;
            Quantidade = quantidade;
            Valor = valor;
            PedidoId = pedidoId;
        }

        protected PedidoItem()
        {

        }

        public string Nome { get; private set; }
        public int Quantidade { get; private set; }
        public decimal Valor { get; private set; }
        public Guid PedidoId { get; private set; }
        public virtual Pedido Pedido { get; private set; }

        public void Atualizar(PedidoItem item)
        {
            Nome = item.Nome;
            Quantidade = item.Quantidade;
            Valor = item.Valor;
            PedidoId = item.PedidoId;
        }

        public decimal ValorTotal() => Valor * Quantidade;

        public class PedidoItemValidation : AbstractValidator<PedidoItem>
        {
            public PedidoItemValidation()
            {
                RuleFor(p => p.Quantidade)
                    .Must(quantidade => quantidade > 0)
                    .WithMessage("Quantidade deve ser maior que 0");
            }
        }
    }
}

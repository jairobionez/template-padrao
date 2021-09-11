# Core da aplicação

## Entidades
Aqui existem duas entidades, Pedido e PedidoItem,tentei deixar as duas entidades com o máximo de comportamento possível para que as mesmas sirvam de exemplo para outros desenvolvedores. 

**Construtor protected**
O construtor protected criado para que o entity framework consiga acessar as propriedades da entidade, dessa forma deixamos um acesso, porém ainda mantemos a entidade protegida.

**Setters privados**
Os privates nas propriedades, garantem que nenhuma modificação externa será realizada, pois, apenas a entidade deve ser responsável por estas ações.

**Comportamento da entidade e agregado root**
Cada método dentro da entidade, representa algum tipo de comportamento ou controle sobre suas ramificações (Pedido), pois o agregado root, é responsável por gerenciar as entidades dependêntes. Já um agregado comun, também possuem comportamento, porém baseado no agregado principal.

**Entidade base**
A entidade base, é um auxiliar para facilitar a criação de serviõs e repositórios genéricos.

## Interfaces
Como o core da aplicação é o centro de tudo, ou seja, os outros projeto que irão depender do mesmo, as interfaces são geradas dentro deste projeto, para que a injeção de dependência possa ser criada, eliminando completamente o acoplamento entre os demais projetos.

## Objetos de valor
Servem para garantir uma validação centralizada e também valorizar a igualdade entre alguns pontos de algumas entidades, e estes, são imutáveis, o que significa que para a alteração destes objetos, uma nova instância deve ser criada.
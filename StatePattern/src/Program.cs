using AndreGutierrez.Exemplos.StatePattern.Domain;

// cria uma nova entidade e define o atributo nome
var entidade = new Entidade();
entidade.Nome = "Nome Entidade";
Console.WriteLine(entidade.Nome);

// remove logicamente a entidade e tenta alterar o nome
// como resultado, uma mensagem indicando que a alteração
// não é suportada para o status atual.
entidade.Remover();
entidade.Nome = "Nome Entidade (Alteração 1)";
Console.WriteLine(entidade.Nome);

// Restaura logicamente a entiade e altera o nome.
entidade.Restaurar();
entidade.Nome = "Nome Entidade (Alteração 2)";
Console.WriteLine(entidade.Nome);
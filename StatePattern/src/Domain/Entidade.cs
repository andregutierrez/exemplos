using AndreGutierrez.Exemplos.StatePattern.Domain.State;

namespace AndreGutierrez.Exemplos.StatePattern.Domain;

public class Entidade
{
    // variável local para armaenamento do nome
    private string _nome = "";

    // variável local para armazenamento do objeto do status atual
    private EntidadeState? _entidadeState;

    // Propriedade nome onde o SET deverá invocar o método
    // de atualização de informações, esse será responsável 
    // por indicar com base no status atual se o nome poderá
    // ou não ser alterado. 
    public string Nome 
    { 
        get => _nome; 
        set => Status.ValidarAtualizacao(() => { _nome = value; }); 
    }

    // Propriedade de acesso e definição do tipo, 
    // para o exemplo uma variável string simples foi
    // utilizada, mas é recomendado que um classe de 
    // enumeração seja criada.
    public String StatusTipo { get; private set; }

    // Propriedade de acesso ao status que deverá
    // verificar durante o acesso se existe uma instancia
    // para o objeto de status criada, caso não, cria e
    // atribui uma nova instancia de acordo com o status 
    // definido na propriedade status tipo. 
    protected EntidadeState Status 
    { 
        // ponto de ateção no acesso ao status, a construção
        // do objeto atém de indicar o tipo que deverá ser criado
        // também define qual método será responsável pela definição 
        // dos novos status, essa definição é necessária visto que 
        // a alteração do tipo do status só pode ser realizada
        // internamente na classe entidade.
        get => _entidadeState ?? (_entidadeState = EntidadeState.Create(this.SetState, StatusTipo, this));
        private set => _entidadeState = value;
    }
    
    // Construtor padrão da classe, para o exemplo a 
    // propriedade status tipo já é definida como ativa
    public Entidade()
    {
        StatusTipo = "Ativo";
    }

    // Método responsável pela atualização do status da entidade, 
    // o nivel de isolamento desses atributos não permite que 
    // as alterações sejam realizadas externamente.
    private void SetState(EntidadeState status)
    {
        this.StatusTipo = status.Tipo;
        this.Status = status;
    }

    // Chamda da alteração de status da remoção da entidade
    public void Remover() => this.Status.Remover();

    // Chamada de alteração de status para restauração da entidade
    public void Restaurar() => this.Status.Restaurar();
}
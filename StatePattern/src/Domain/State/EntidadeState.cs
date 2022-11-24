namespace AndreGutierrez.Exemplos.StatePattern.Domain.State;

public abstract class EntidadeState
{
    // Definição do delegate que irá auxiliar na 
    // alteração do status da classe
    public delegate void DefineStateDelegate(EntidadeState status);

    // Armazena a referência do método que será 
    // invocado quando houver a necessidade de alteração
    // do status a classe.
    public DefineStateDelegate? SetState { get; set; }

    // Entidade relacionada ao status, no exemplo não
    // foi colocada nenhuma utilidade para essa variavel
    // mas deve-se considerar que ela contem informações
    // que poderão ser validadas durante a execução da 
    // transição dos status
    protected Entidade _entidade;

    // Define a propriedade abstrata que retornada
    // a string do tipo do status.
    public abstract string Tipo { get; }

    // Construtor padrão da classe state recebendo 
    // as informações da entidade que poderá ser
    // utilizada para validações da transição.
    protected EntidadeState(Entidade entidade)
    {
        _entidade = entidade;
    }

    // Método resposável por executar a transição do 
    // status da entidade em duas partes. Invocando o 
    // método OnEnter do novo status e registrando o
    // novo status na entidade pelo método de referencia
    protected void TransictionTo(EntidadeState newState)
    {
        newState.Initialize();
        newState.SetState = this.SetState;
        if(this.SetState != null)
            this.SetState(newState);
    }

    // Definição do método abstrato OnEnter que será
    // implementado pelas classes concretas.
    protected abstract void Initialize();

    // Definição dos métodos de transição de status e de verificação 
    // do status, para evitar a escrita de código desnecessário, todos 
    // os métodos são implementados com um valor de negação para ser 
    // substituido pela classe concreta apenas quando necessário.
    // Sugestão é utilizar uma excessão InvalidOperationException
    public virtual void Remover() => Console.WriteLine("A remoção não é valida para o status atual");
    public virtual void Restaurar() => Console.WriteLine("A restauração não é valida para o status atual");
    public virtual void ValidarAtualizacao(Action action) => Console.WriteLine("A atualização das informações não é valida para o status atual");


    public static EntidadeState Create(DefineStateDelegate setstate, string tipo, Entidade entidade)
    {
        EntidadeState state;
        switch(tipo)
        {
            case "Ativo" : state = new EntidadeAtivaState(entidade); break;
            case "Removido" : state = new EntidadeRemovidaState(entidade); break;
            default:  throw new ArgumentException("tipo não gerenciado");
        }
        state.SetState = setstate;
        return state;
    }
}
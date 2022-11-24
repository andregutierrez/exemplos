namespace AndreGutierrez.Exemplos.StatePattern.Domain.State;

public class EntidadeAtivaState : EntidadeState
{
    public override string Tipo => "Ativo";

    public EntidadeAtivaState(Entidade entidade) : base(entidade) { }

    protected override void Initialize()
    {
        Console.WriteLine("Iniciando o status ativo");
    }

    public override void Remover()
    {
        base.TransictionTo(new EntidadeRemovidaState(_entidade));
    }

    public override void ValidarAtualizacao(Action action)
    {
        action();
    }
}
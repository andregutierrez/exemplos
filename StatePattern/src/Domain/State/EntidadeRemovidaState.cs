namespace AndreGutierrez.Exemplos.StatePattern.Domain.State;

public class EntidadeRemovidaState : EntidadeState
{
    public override string Tipo => "Removido";

    protected override void Initialize()
    {
        Console.WriteLine("Iniciando o status Removido");
    }

    public EntidadeRemovidaState(Entidade entidade) : base(entidade) { }

    public override void Restaurar()
    {
        base.TransictionTo(new EntidadeAtivaState(_entidade));
    }
}

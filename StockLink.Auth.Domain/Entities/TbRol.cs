namespace StockLink.Auth.Domain.Entities;

public partial class TbRol : BaseEntity
{
    public string Rol { get; set; } = null!;

    public string Privilegios { get; set; } = null!;

    public int Drainsa { get; set; }

    public int Motornova { get; set; }

    public virtual ICollection<TbUsuario> TbUsuarios { get; set; } = new List<TbUsuario>();
}
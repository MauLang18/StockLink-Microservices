namespace StockLink.Auth.Domain.Entities;

public partial class TbRol : BaseEntity
{
    public string Rol { get; set; } = null!;

    public string Privilegios { get; set; } = null!;

    public virtual ICollection<TbUsuario> TbUsuarios { get; set; } = new List<TbUsuario>();
}
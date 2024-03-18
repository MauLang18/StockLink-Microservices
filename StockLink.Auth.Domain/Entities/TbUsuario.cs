namespace StockLink.Auth.Domain.Entities;

public partial class TbUsuario : BaseEntity
{
    public string Username { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public int Rol { get; set; }

    public string Despacho { get; set; } = null!;

    public virtual TbRol RolNavigation { get; set; } = null!;
}
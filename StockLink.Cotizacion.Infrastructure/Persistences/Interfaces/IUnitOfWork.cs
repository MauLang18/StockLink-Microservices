namespace StockLink.Cotizacion.Infrastructure.Persistences.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //Declaracion o matricula de nuestra interfaces a nivel de repository

        ICotizacionRepository Cotizacion { get; }
        IDetalleCotizacionRepository DetalleCotizacion { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
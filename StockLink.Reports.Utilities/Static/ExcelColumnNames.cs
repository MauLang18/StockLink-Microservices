namespace StockLink.Reports.Utilities.Static
{
    public class ExcelColumnNames
    {
        public static List<TableColumns> GetColumns(IEnumerable<(string ColumnName, string PropertyName)> columnsProperties)
        {
            var columns = new List<TableColumns>();

            foreach (var (ColumnName, PropertyName) in columnsProperties)
            {
                var column = new TableColumns()
                {
                    Label = ColumnName,
                    PropertyName = PropertyName
                };

                columns.Add(column);
            }

            return columns;
        }

        #region ColumnsCategorias
        public static List<(string ColumnName, string PropertyName)> GetColumnsCategorias()
        {
            var columnsProperties = new List<(string ColumnName, string PropertyName)>
            {
                ("NOMBRE", "Nombre"),
                ("DESCRIPCION", "Descripcion"),
                ("FECHA DE CREACIÓN", "Fechacreacionauditoria"),
                ("ESTADO", "EstadoCategoria")
            };

            return columnsProperties;
        }
        #endregion
    }
}
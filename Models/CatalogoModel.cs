namespace Api.Models
{
    public class CatalogoModel
    {
        public int CatalogoId { get; set; }

        public string CatalogoName { get; set; } = string.Empty;

        public string CatalogoTipo { get; set; } = string.Empty;

        public string CatalogoCor { get; set; } = string.Empty;

        public string CatalogoCategoria { get; set; } = string.Empty;


        public static implicit operator List<object>(CatalogoModel v)
        {
            throw new NotImplementedException();
        }

    }
}


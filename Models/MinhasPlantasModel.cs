namespace Api.Models
{
    public class RelatorioModel
    {
        public int RelatorioId { get; set; }

        public string RelatorioDescricao { get; set; } = string.Empty;

        public static implicit operator List<object>(RelatorioModel v)
        {
            throw new NotImplementedException();
        }

    }
}

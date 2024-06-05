namespace Api.Models
{
    public class ObservacoesModel
    {
        public int ObservacoesId { get; set; }

        public string ObservacoesDescri { get; set; } = string.Empty;

        public string ObservacaoLocal { get; set; } = string.Empty;

        public DateTime ObservacaoData { get; set; }

        public static implicit operator List<object>(ObservacoesModel v)
        {
            throw new NotImplementedException();
        }

    }
}
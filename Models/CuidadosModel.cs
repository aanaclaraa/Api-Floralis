namespace Api.Models
{
    public class CuidadosModel
    {
        public int CuidadosId { get; set; }

        public string CuidadosBriófitas { get; set; } = string.Empty;

        public string CuidadosPteridófitas { get; set; } = string.Empty;

        public string CuidadosGimnospermas { get; set; } = string.Empty;

        public string CuidadosAngiospermas { get; set; } = string.Empty;

        public static implicit operator List<object>(CuidadosModel v)
        {
            throw new NotImplementedException();
        }

    }
}
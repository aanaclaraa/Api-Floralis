namespace Api.Models
{
    public class AnimalModel
    {
        public int AnimalId { get; set; }

        public string NomeAnimal { get; set; } = string.Empty;

        public string AnimalRaca { get; set; } = string.Empty;

        public string AnimalTipo { get; set; } = string.Empty;

        public string AnimalCor { get; set; } = string.Empty;

        public string AnimalSexo { get; set; } = string.Empty;
              
        public DateTime AnimalDtDesaparecimento { get; set; } 

        public DateTime? AnimalDtEncontro { get; set; } 

        public string AnimalStatus { get; set; } = string.Empty;

        public string UsuarioId { get; set; } = string.Empty;

        public static implicit operator List<object>(AnimalModel v)
        {
            throw new NotImplementedException();
        }

    }
}


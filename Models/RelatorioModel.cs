namespace Api.Models
{
    public class MinhasPlantasModel
    {
        public int MinhasPlantasId { get; set; }

        public string MinhasPlantasTipo { get; set; } = string.Empty;

        public string MinhasplantasDescricao { get; set; } = string.Empty;

        public static implicit operator List<object>(MinhasPlantasModel v)
        {
            throw new NotImplementedException();
        }

    }
}

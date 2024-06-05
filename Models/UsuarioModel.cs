namespace Api.Models
{
    public class UsuarioModel
    {
        public int UsuarioId { get; set; }

        public string NomeUsuario { get; set; } = string.Empty;

        public string TelefoneUsuario { get; set; } = string.Empty;

        public string EmailUsuario { get; set; } = string.Empty;

        public string SenhaUsuario { get; set; } = string.Empty;

        public static implicit operator List<object>(UsuarioModel v)
        {
            throw new NotImplementedException();
        }

    }
}

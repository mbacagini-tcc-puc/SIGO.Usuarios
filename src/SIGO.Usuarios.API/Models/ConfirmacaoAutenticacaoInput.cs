namespace SIGO.Usuarios.API.Models
{
    public class ConfirmacaoAutenticacaoInput
    {
        public int UsuarioId { get; set; }
        public string CodigoVerificacao { get; set; }
    }
}

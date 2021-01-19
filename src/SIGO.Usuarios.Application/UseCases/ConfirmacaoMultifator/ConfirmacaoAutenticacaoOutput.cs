namespace SIGO.Usuarios.Application.UseCases.ConfirmacaoMultifator
{
    public class ConfirmacaoAutenticacaoOutput
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string[] Modulos { get; set; }
    }
}

namespace WebApi.ViewModels.Response
{
    public class GenericViewModelResponse
    {
        public int Status { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Cuerpo { get; set; } = string.Empty;
    }
}

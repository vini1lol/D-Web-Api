namespace Api.Dto
{
    public class EnderecoDto 
    {
        public int EnderecoId { get; set; }
        public int CEP { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int UserId { get; set; }
    }

}

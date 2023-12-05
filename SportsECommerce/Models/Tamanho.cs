namespace SportsECommerce.Models
{
    public class Tamanho
    {
        public int TamanhoID { get; set; }
        public string Nome { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}

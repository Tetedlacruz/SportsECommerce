namespace SportsECommerce.Models
{
    public class Produto
    {
        public int ProdutoID { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public List<Tamanho> Tamanhos { get; set; }
        public decimal Preco { get; set; }
    }
}

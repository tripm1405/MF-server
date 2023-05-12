namespace MangaFigure.DTOs
{
    public class TransactionCreateReqDto
    {
        public int? Customer { get; set; }
        public string? Address { get; set; }

        public List<ProductTransactionDto>? Products { get; set; }
    }
}

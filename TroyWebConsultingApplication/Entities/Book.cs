namespace TroyWebConsultingApplication.Entities;

public class Book
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Author { get; set; }
    public required string Description { get; set; }
    public required string Publisher { get; set; }
    public required DateOnly PublicationDate { get; set; }
    public required string Category { get; set; }
    public required int PageCount { get; set; }
    public required bool IsCheckedOut { get; set; }
    public string? CheckedOutBy { get; set; }
    public DateTime? LastCheckedOut { get; set; }
    public byte[]? CoverImage { get; set; }
}
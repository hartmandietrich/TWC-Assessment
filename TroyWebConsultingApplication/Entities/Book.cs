namespace TroyWebConsultingApplication.Entities;

public class Book
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string? Author { get; set; }
    public string? Description { get; set; }
    public string? Publisher { get; set; }
    public DateOnly? PublicationDate { get; set; }
    public string? Category { get; set; }
    public int? PageCount { get; set; }
    public bool? IsCheckedOut { get; set; }
    public Customer? CheckedOutBy { get; set; }
    public DateTime? LastCheckedOut { get; set; }
    public byte[]? CoverImage { get; set; }
}
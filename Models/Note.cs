using Supabase.Postgrest.Models;
using Supabase.Postgrest.Attributes;

[Table("Notes")]
public class Note : BaseModel
{
    [PrimaryKey("Id", false)]
    public int Id { get; set; }

    [Column("Title")]
    public string Title { get; set; } = "";

    [Column("Content")]
    public string Content { get; set; } = "";

    [Column("CreatedAt")]
    public DateTime CreatedAt { get; set; }
}
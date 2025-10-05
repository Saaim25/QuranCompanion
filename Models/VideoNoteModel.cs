using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

[Table("VideoNotes")]
public class VideoNoteModel : BaseModel
{
    [PrimaryKey("VideoId", false)]
    public int VideoId { get; set; }
    [PrimaryKey("Title", false)]
    public string Title { get; set; } = "";
    [PrimaryKey("Notes", false)]
    public string Notes { get; set; } = "";
    [PrimaryKey("IsWatched", false)]
    public bool IsWatched { get; set; }
    [PrimaryKey("VideoUrl", false)]
    public string VideoUrl { get; set; } = "";
}
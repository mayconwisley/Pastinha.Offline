using System.ComponentModel.DataAnnotations;

namespace Pastinha.Base.Model.Folder;

public class FolderPastinhaSenior
{
    public int Id { get; set; }
    [Required]
    public string? PathInput { get; set; }
    [Required]
    public string? PathOutput { get; set; }
    [Required]
    public string? PathError { get; set; }
    [Required]
    public string? PathLog { get; set; }
    public bool IsDelete { get; set; } = false;
    public int DaysDelete { get; set; }
}

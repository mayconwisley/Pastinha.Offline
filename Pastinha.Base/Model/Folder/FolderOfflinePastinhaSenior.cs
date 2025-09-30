using System.ComponentModel.DataAnnotations;

namespace Pastinha.Base.Model.Folder;

public class FolderOfflinePastinhaSenior
{
    public int Id { get; set; }
    [Required]
    public bool IsOffline { get; set; }
    [Required]
    public string? PathOffline { get; set; }
}

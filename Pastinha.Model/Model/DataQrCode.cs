using System.Text.Json.Serialization;

namespace Pastinha.Model.Model;

public class DataQrCode
{
    [JsonPropertyName("tipCol")]
    public int TipCol { get; set; }
    [JsonPropertyName("numCad")]
    public int NumCad { get; set; }
    [JsonPropertyName("numPag")]
    public int NumPag { get; set; }
    [JsonPropertyName("numEmp")]
    public int NumEmp { get; set; }
    [JsonPropertyName("nomDoc")]
    public string NomDoc { get; set; } = null!;
    [JsonPropertyName("nomFun")]
    public string NomFun { get; set; } = null!;
    [JsonPropertyName("sitAfa")]
    public int SitAfa { get; set; }
}

namespace Pastinha.Base.Model.DataFileProcessed;

public class CountDataFile
{
    public int Id { get; private set; }
    public DateTime DateProcess { get; private set; }
    public int CountPDF { get; private set; }
    public int CountImage { get; private set; }
    public int CountOtherFormat { get; private set; }
    public int CountSendPlatform { get; private set; }

    protected CountDataFile() { }

    public CountDataFile(DateTime dateProcess, int countPdf, int countImage, int countOtherFormat, int countSendPlatform)
    {
        DateProcess = dateProcess;
        CountPDF = countPdf;
        CountImage = countImage;
        CountOtherFormat = countOtherFormat;
        CountSendPlatform = countSendPlatform;
    }

    public void SetCount(int countPdf, int countImage, int countOtherFormat, int countSendPlatform)
    {
        CountPDF += countPdf;
        CountImage += countImage;
        CountOtherFormat += countOtherFormat;
        CountSendPlatform += countSendPlatform;
    }
}

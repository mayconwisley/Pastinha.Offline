using PdfSharp.Drawing;
using PdfSharp.Pdf;
using Pastinha.Service.Service.Process.Interface;
using Pastinha.Utility.Utility;

namespace Pastinha.Service.Service.Process;

public class ImageToPdf(CreateLog _createLog) : IImageToPdf
{
    public void Process(string[] imageFiles, string pathOutput)
    {
        try
        {
            _createLog.Log($"[INFO] Convertendo Imagem para PDF");
            using PdfDocument document = new();

            foreach (string imagePath in imageFiles)
            {
                PdfPage page = document.AddPage();
                using XGraphics gfx = XGraphics.FromPdfPage(page);
                using XImage img = XImage.FromFile(imagePath);

                // Ajustar imagem ao tamanho da página A4
                double width = page.Width.Point;
                double height = page.Height.Point;
                gfx.DrawImage(img, 0, 0, width, height);
            }
            document.Save(pathOutput);
            _createLog.Log($"[SUCESSO] Conversão concluída: {pathOutput}");
        }
        catch (Exception ex)
        {
            _createLog.Log($"[ERRO] Conversão Imagem para PDF {ex.Message}");
        }
    }
}
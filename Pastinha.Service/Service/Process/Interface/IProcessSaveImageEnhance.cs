using System.Drawing;

namespace Pastinha.Service.Service.Process.Interface;

public interface IProcessSaveImageEnhance
{
	Task<string> SavePathImageEnhance(string pathImage);
	Task<Bitmap?> ImageEnhance(string pathImage);
	Task<List<Bitmap?>> ImageEnhance_1(Bitmap bitmap);
}

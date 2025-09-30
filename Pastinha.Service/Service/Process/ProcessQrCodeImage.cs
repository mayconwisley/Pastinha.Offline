using Pastinha.Model.Model;
using Pastinha.Service.Service.Database.Interface;
using Pastinha.Service.Service.Process.Interface;
using Pastinha.Utility.Utility;
using System.Drawing;
using System.Text.Json;
using ZXing;
using ZXing.Common;
using ZXing.Multi;
using ZXing.QrCode;
using ZXing.Windows.Compatibility;

namespace Pastinha.Service.Service.Process;

public class ProcessQrCodeImage(IProcessSaveImageEnhance _processSaveImageEnhance, IResizeImage _resizeImage,
    ICreateFolderLoose _createFolderLoose, IMoveFoderError _moveFoderError, IReturnFromTo _returnFromTo, CreateLog _createLog) : IProcessQrCodeImage
{
    public async Task<DataQrCode?> ProcessSingleQrCodeFile(string path, string pathError, List<(int dpi, int width, int height)> resizeAttempts)
    {
        try
        {
            _createLog.Log($"[INFO] Processando QRCode da imagem: {path}");
            FileInfo fileInfo = new(path);
            var pathNew1 = await _processSaveImageEnhance.SavePathImageEnhance(path);
            ZXing.Result? result = null;
            string? pathNew = null;
            BarcodeReader reader = new();
            foreach (var (dpi, width, height) in resizeAttempts)
            {
                pathNew = _resizeImage.Resize(pathNew1, dpi, width, height);
                if (string.IsNullOrEmpty(pathNew))
                {
                    _createLog.Log($"[AVISO] caminho vazio, retornando: {pathNew}");
                    return null;
                }

                using var img = (Bitmap)Image.FromFile(pathNew);
                using var bitmap = new Bitmap(img);

                reader.Options = new DecodingOptions
                {
                    PossibleFormats = [BarcodeFormat.QR_CODE],
                    TryInverted = true,
                    TryHarder = true
                };
                reader.AutoRotate = true;


                result = reader.Decode(bitmap);
                img.Dispose();
                bitmap.Dispose();
                if (result is not null)
                {
                    _createLog.Log($"[INFO] Resolução: DPI {dpi} Width {width} Height {height} - Imagem: {pathNew}");
                    break;
                }

            }
            // Se ainda for nulo, tenta a imagem original
            if (result is null)
            {
                using var img = (Bitmap)Image.FromFile(path);
                using var bitmapOriginal = new Bitmap(img);
                reader.Options = new DecodingOptions
                {
                    PossibleFormats = [BarcodeFormat.QR_CODE],
                    TryInverted = true,
                    TryHarder = true
                };
                reader.AutoRotate = true;

                result = reader.Decode(bitmapOriginal);
                img.Dispose();
                bitmapOriginal.Dispose();
            }

            if (result is null)
            {
                _createLog.Log($"[INFO] Verificando nome do arquivo: {fileInfo.Name}");
                var isCreateFolder = _createFolderLoose.Create(fileInfo.Name, fileInfo.Directory!.FullName);
                if (isCreateFolder)
                    return null;

                _moveFoderError.Mover(pathError, fileInfo.FullName, "Erro Leitura QRCode");
                _createLog.Log($"[AVISO] QRCode não encontrado, movendo imagem para: {pathError}");

                return null;
            }
            var dataQrCode = JsonSerializer.Deserialize<DataQrCode>(result.Text) ?? new();

            var newNumEmp = await _returnFromTo.GetFromToCompany(dataQrCode.NumEmp);
            if (newNumEmp != null)
            {
                _createLog.Log($"[INFO] Processando De-Para: Empresa Informada no QRCode: {dataQrCode.NumEmp} para a Empresa cadastrada: {newNumEmp.ToCompany}");
                dataQrCode.NumEmp = newNumEmp.ToCompany;
            }

            var newTipCol = await _returnFromTo.GetFromToType(dataQrCode.TipCol);
            if (newTipCol != null)
            {
                _createLog.Log($"[INFO] Processando De-Para: Tipo de Colaborador Informado no QRCode: {dataQrCode.TipCol} para o Tipo de Colaborador cadastrado: {newTipCol.ToType}");
                dataQrCode.TipCol = newTipCol.ToType;
            }

            var newNumCad = await _returnFromTo.GetFromToEmployee(dataQrCode.NumCad);
            if (newNumCad != null)
            {
                _createLog.Log($"[INFO] Processando De-Para: Colaborador Informado no QRCode: {dataQrCode.NumCad} para o Colaborador cadastrado: {newNumCad.ToEmployee}");
                dataQrCode.NumCad = newNumCad.ToEmployee;
            }

            string strQrCode = JsonSerializer.Serialize(dataQrCode);
            _createLog.Log($"[SUCESSO] QRCode encontrado: {strQrCode}");

            // Limpa arquivos temporários
            File.Delete(pathNew1);
            if (!string.IsNullOrEmpty(pathNew))
                File.Delete(pathNew);

            return dataQrCode;
        }
        catch (FileNotFoundException ex)
        {
            _createLog.Log($"[ERRO] Arquivo não encontrado: {ex}");
            return null;
        }
        catch (JsonException ex)
        {
            _createLog.Log($"[ERRO] Erro ao desserializar o JSON {ex}");
            return null;
        }
        catch (DirectoryNotFoundException ex)
        {
            _createLog.Log($"[ERRO] Diretório não encontrado {ex}");
            return null;
        }
        catch (Exception ex)
        {
            _createLog.Log($"[ERRO] Erro inesperado {ex}");
            return null;
        }
    }

    public async Task<DataQrCode?> ProcessSingleQrCodeMemory(string path, string pathError, List<(int dpi, int width, int height)> resizeAttempts)
    {
        try
        {
            _createLog.Log($"[INFO] Processando QRCode da imagem: {path}");
            FileInfo fileInfo = new(path);
            using var imageEnhanced = await _processSaveImageEnhance.ImageEnhance(path);

            if (imageEnhanced is null)
            {
                _createLog.Log($"[AVISO] Imagem não melhorada, retornando nulo.");
                return null;
            }
            ZXing.Result? result = null;
            var reader = new BarcodeReader
            {
                Options = new DecodingOptions
                {
                    PossibleFormats = [BarcodeFormat.QR_CODE],
                    TryInverted = true,
                    TryHarder = true
                },
                AutoRotate = true
            };

            foreach (var (dpi, width, height) in resizeAttempts)
            {
                using var imageResize = _resizeImage.Image(imageEnhanced, dpi, width, height);
                result = reader.Decode(imageResize);
                if (result is not null)
                {
                    _createLog.Log($"[INFO] Resolução: DPI {dpi} Width {width} Height {height} - Imagem");
                    break;
                }
            }
            // Se ainda for nulo, tenta a imagem original
            if (result is null)
            {
                using var imgOriginal = (Bitmap)Image.FromFile(path);
                using var bitmapOriginal = new Bitmap(imgOriginal);

                result = reader.Decode(bitmapOriginal);
            }

            if (result is null)
            {
                _createLog.Log($"[INFO] Verificando nome do arquivo: {fileInfo.Name}");
                if (_createFolderLoose.Create(fileInfo.Name, fileInfo.Directory!.FullName))
                    return null;

                _moveFoderError.Mover(pathError, fileInfo.FullName, "Erro Leitura QRCode");
                _createLog.Log($"[AVISO] QRCode não encontrado, movendo imagem para: {pathError}");

                return null;
            }
            var dataQrCode = JsonSerializer.Deserialize<DataQrCode>(result.Text) ?? new();

            var newNumEmp = await _returnFromTo.GetFromToCompany(dataQrCode.NumEmp);
            if (newNumEmp != null)
            {
                _createLog.Log($"[INFO] Processando De-Para: Empresa Informada no QRCode: {dataQrCode.NumEmp} para a Empresa cadastrada: {newNumEmp.ToCompany}");
                dataQrCode.NumEmp = newNumEmp.ToCompany;
            }

            var newTipCol = await _returnFromTo.GetFromToType(dataQrCode.TipCol);
            if (newTipCol != null)
            {
                _createLog.Log($"[INFO] Processando De-Para: Tipo de Colaborador Informado no QRCode: {dataQrCode.TipCol} para o Tipo de Colaborador cadastrado: {newTipCol.ToType}");
                dataQrCode.TipCol = newTipCol.ToType;
            }

            var newNumCad = await _returnFromTo.GetFromToEmployee(dataQrCode.NumCad);
            if (newNumCad != null)
            {
                _createLog.Log($"[INFO] Processando De-Para: Colaborador Informado no QRCode: {dataQrCode.NumCad} para o Colaborador cadastrado: {newNumCad.ToEmployee}");
                dataQrCode.NumCad = newNumCad.ToEmployee;
            }

            string strQrCode = JsonSerializer.Serialize(dataQrCode);
            _createLog.Log($"[SUCESSO] QRCode encontrado: {strQrCode}");

            return dataQrCode;
        }
        catch (FileNotFoundException ex)
        {
            _createLog.Log($"[ERRO] Arquivo não encontrado: {ex}");
            return null;
        }
        catch (JsonException ex)
        {
            _createLog.Log($"[ERRO] Erro ao desserializar o JSON {ex}");
            return null;
        }
        catch (DirectoryNotFoundException ex)
        {
            _createLog.Log($"[ERRO] Diretório não encontrado {ex}");
            return null;
        }
        catch (Exception ex)
        {
            _createLog.Log($"[ERRO] Erro inesperado {ex}");
            return null;
        }
    }

    public async Task<DataQrCode?> ProcessMultQrCodeMemory(string path, string pathError, List<(int dpi, int width, int height)> resizeAttempts)
    {
        try
        {
            _createLog.Log($"[INFO] Processando QRCode da imagem: {path}");
            FileInfo fileInfo = new(path);
            using var imageEnhanced = await _processSaveImageEnhance.ImageEnhance(path);

            if (imageEnhanced is null)
            {
                _createLog.Log($"[AVISO] Imagem não melhorada, retornando nulo.");
                return null;
            }
            DataQrCode? dataQrCode = null;
            ZXing.Result? result = null;

            foreach (var (dpi, width, height) in resizeAttempts)
            {
                using var imageResize = _resizeImage.Image(imageEnhanced, dpi, width, height);
                var source = new BitmapLuminanceSource(imageResize);
                var binarizer = new HybridBinarizer(source);
                var binaryBitmap = new BinaryBitmap(binarizer);

                var reader = new GenericMultipleBarcodeReader(new QRCodeReader());

                var results = reader.decodeMultiple(binaryBitmap);
                if (results is null || results.Length == 0)
                {
                    continue;
                }
                else
                {
                    foreach (var item in results)
                    {
                        if (item is not null)
                        {
                            try
                            {
                                dataQrCode = JsonSerializer.Deserialize<DataQrCode>(item.Text);
                                if (dataQrCode is not null && !string.IsNullOrEmpty(dataQrCode.NomDoc))
                                {
                                    result = item;
                                    _createLog.Log($"[INFO] Resolução: DPI {dpi} Width {width} Height {height} - Imagem");
                                    break;
                                }
                            }
                            catch
                            {
                                continue;
                            }
                        }
                    }
                    if (results is not null)
                    {
                        break;
                    }
                }
            }
            // Se ainda for nulo, tenta a imagem original
            if (result is null)
            {
                using var imgOriginal = (Bitmap)Image.FromFile(path);
                using var bitmapOriginal = new Bitmap(imgOriginal);
                var source = new BitmapLuminanceSource(bitmapOriginal);
                var binarizer = new HybridBinarizer(source);
                var binaryBitmap = new BinaryBitmap(binarizer);

                var reader = new GenericMultipleBarcodeReader(new QRCodeReader());
                var results = reader.decodeMultiple(binaryBitmap);
                if (results is not null || results?.Length >= 0)
                {
                    foreach (var item in results)
                    {
                        if (item is not null)
                        {
                            dataQrCode = JsonSerializer.Deserialize<DataQrCode>(item.Text);
                            if (dataQrCode is not null && !string.IsNullOrEmpty(dataQrCode.NomDoc))
                            {
                                result = item;
                                break;
                            }
                        }
                    }
                }
            }

            if (result is null)
            {
                _createLog.Log($"[INFO] Verificando nome do arquivo: {fileInfo.Name}");
                if (_createFolderLoose.Create(fileInfo.Name, fileInfo.Directory!.FullName))
                    return null;

                _moveFoderError.Mover(pathError, fileInfo.FullName, "Erro Leitura QRCode");
                _createLog.Log($"[AVISO] QRCode não encontrado, movendo imagem para: {pathError}");

                return null;
            }

            var newNumEmp = await _returnFromTo.GetFromToCompany(dataQrCode!.NumEmp);
            if (newNumEmp != null)
            {
                _createLog.Log($"[INFO] Processando De-Para: Empresa Informada no QRCode: {dataQrCode.NumEmp} para a Empresa cadastrada: {newNumEmp.ToCompany}");
                dataQrCode.NumEmp = newNumEmp.ToCompany;
            }

            var newTipCol = await _returnFromTo.GetFromToType(dataQrCode.TipCol);
            if (newTipCol != null)
            {
                _createLog.Log($"[INFO] Processando De-Para: Tipo de Colaborador Informado no QRCode: {dataQrCode.TipCol} para o Tipo de Colaborador cadastrado: {newTipCol.ToType}");
                dataQrCode.TipCol = newTipCol.ToType;
            }

            var newNumCad = await _returnFromTo.GetFromToEmployee(dataQrCode.NumCad);
            if (newNumCad != null)
            {
                _createLog.Log($"[INFO] Processando De-Para: Colaborador Informado no QRCode: {dataQrCode.NumCad} para o Colaborador cadastrado: {newNumCad.ToEmployee}");
                dataQrCode.NumCad = newNumCad.ToEmployee;
            }

            string strQrCode = JsonSerializer.Serialize(dataQrCode);
            _createLog.Log($"[SUCESSO] QRCode encontrado: {strQrCode}");

            return dataQrCode;
        }
        catch (FileNotFoundException ex)
        {
            _createLog.Log($"[ERRO] Arquivo não encontrado: {ex}");
            return null;
        }
        catch (JsonException ex)
        {
            _createLog.Log($"[ERRO] Erro ao desserializar o JSON {ex}");
            return null;
        }
        catch (DirectoryNotFoundException ex)
        {
            _createLog.Log($"[ERRO] Diretório não encontrado {ex}");
            return null;
        }
        catch (Exception ex)
        {
            _createLog.Log($"[ERRO] Erro inesperado {ex}");
            return null;
        }
    }
}

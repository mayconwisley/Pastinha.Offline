# 📄 Processador de Documentos com QR Code

Este sistema automatiza o processamento de arquivos com QR Codes, organiza documentos, converte imagens em PDF, e registra logs detalhados de cada operação. Ele foi desenvolvido para rodar como um serviço no Windows.

---

## 🚀 Funcionalidades

- ✅ Leitura de arquivos com QR Code
- 📁 Organização automática de pastas
- 🖨️ Conversão de imagens, DOCX, XLSX, e TXT para PDF
- 🔐 Criptografia de dados sensíveis
- ☁️ Envio automático para a plataforma SeniorX
- 🧾 Geração de logs e auditoria de processos
- 🔄 Execução como Serviço do Windows

---

## 📂 Tipos de Arquivos Suportados

- 📄 **PDF**
- 🖼️ **Imagens**: JPG, PNG, BMP, TIFF
- 📝 **Texto**: TXT
- 📊 **Planilhas**: XLSX
- 🧾 **Documentos Word**: DOCX

---

## ⚙️ Estrutura de Diretórios

| Diretório       | Descrição                                      |
|----------------|------------------------------------------------|
| `/Entrada`      | Onde os arquivos são colocados para processamento |
| `/Saída`  | Arquivos já enviados com sucesso               |
| `/Erros`        | Arquivos com falha no processamento            |
| `/Logs`         | Logs detalhados das execuções                  |

---

## 🛠️ Como Usar

1. **Configure as variáveis de ambiente**:
   - `PastinhaKey`: chave de criptografia
   - `PastinhaBd`: chave do banco de dados, SQLite
   - Diretórios de entrada, saída, erro e logs

2. **Inicie o serviço**:
   - O sistema roda como um serviço do Windows (ver `WindowsServices.cs`)

3. **Adicione os arquivos na pasta de entrada**:
   - Eles serão processados automaticamente

4. **Verifique os logs e diretórios de saída**:
   - Arquivos processados, com erro ou pendentes são organizados automaticamente

5. **Habilitar menu de configuração**:
   - Para habilitar passar como parâmetro no atalho `config`

---

## 🔐 Segurança

- Os dados sensíveis (como tokens de autenticação) são criptografados
- Utilize `GenerateKey.cs` para gerar sua chave de criptografia
- As chaves devem ser armazenadas em variáveis de ambiente e nunca em código-fonte

---

## 📦 Tecnologias Utilizadas

- C# (.NET Framework)
- Windows Services
- QR Code Reader
- Criptografia AES
- Manipulação de imagens e PDF

---

## 📘 Manual do Usuário

Você pode consultar o [Manual do Usuário](./Manual_Usuario_Pastinha_Exe.pdf) para mais detalhes sobre o uso do sistema.

---

## 📥 Contribuições

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou enviar pull requests.

---

## 📄 Licença

Este projeto está licenciado sob a [MIT License](./LICENSE.txt).

---

## 👨‍💻 Desenvolvedor

Desenvolvido com 💡 para facilitar o processamento inteligente de documentos com QR Code.


using PdfiumViewer;
using System.IO;
using System.Windows.Forms;

namespace Barbersoft.PdfViewer
{
    public partial class PDFViewerForm : Form
    {
        public PDFViewerForm(string nomeArquivo)
        {
            InitializeComponent();

            AbrirRelatorio(nomeArquivo);
        }
        private void AbrirRelatorio(string arquivo)
        {
            if (!string.IsNullOrEmpty(arquivo))
            {
                pdfViewer1.Document = ConfiguraArquivo(arquivo);
            } else
            {
                MessageBox.Show("Nenhum arquivo encontrado", "Atenção");
            }
        }
        private PdfDocument ConfiguraArquivo(string filePath)
        {
            byte[] bytes = File.ReadAllBytes(filePath);
            var stream = new MemoryStream(bytes);
            PdfDocument pdf = PdfDocument.Load(stream);
            return pdf;
        }
        private void BtnFechar(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}

using Barbersoft.Utils;
using PdfiumViewer;
using System;
using System.IO;
using System.Windows.Forms;

namespace Barbersoft.PdfViewer
{
    public partial class PDFViewerForm : Form
    {
        public PDFViewerForm()
        {
            InitializeComponent();
        }
        private void BtnAbrirArquivo(object sender, EventArgs e)
        {
            GerarPDF pdf = new();
            string arquivo = pdf.GerarDocumentoPDF();
            if (!string.IsNullOrEmpty(arquivo))
            {
                pdfViewer1.Document = AbrirArquivo(arquivo);
            } else
            {
                MessageBox.Show("Não foi possível abrir o Relatório", "Atenção");
            }
        }
        private PdfDocument AbrirArquivo(string filePath)
        {
            byte[] bytes = File.ReadAllBytes(filePath);
            var stream = new MemoryStream(bytes);
            PdfDocument pdf = PdfDocument.Load(stream);
            return pdf;
        }
    }
}

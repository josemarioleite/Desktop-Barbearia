using Barbersoft.Utils;
using System;
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
            pdf.GerarDocumentoPDF();
        }
    }
}

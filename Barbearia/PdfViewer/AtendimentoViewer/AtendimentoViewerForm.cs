using Barbersoft.Utils;
using System;
using System.Windows.Forms;

namespace Barbersoft.PdfViewer.AtendimentoViewer
{
    public partial class AtendimentoViewerForm : Form
    {
        public AtendimentoViewerForm()
        {
            InitializeComponent();
        }
        private void BtnSair(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnAbrirRelatorio(object sender, EventArgs e)
        {
            if (dtInicio.Value <= dtFim.Value)
            {
                GerarPDF gerarPDF = new();
                string arquivo = gerarPDF.GerarDocumentoPDF("Relatório de Atendimento", dtInicio.Value, dtFim.Value);
                PDFViewerForm pdfViewer = new(arquivo);
                pdfViewer.ShowDialog();
            } else
            {
                MessageBox.Show("A Data de Início não pode ser maior que a Data do Fim", "Atenção");
            }
        }
        private void Viewer_Load(object sender, EventArgs e)
        {
            dtInicio.MaxDate = DateTime.Today;
            dtInicio.MinDate = new DateTime(2021, 1, 1);
            dtInicio.Value = DateTime.Today;

            dtFim.MaxDate = DateTime.Today;
            dtFim.MinDate = new DateTime(2021, 1, 1);
            dtFim.Value = DateTime.Today;
        }
    }
}

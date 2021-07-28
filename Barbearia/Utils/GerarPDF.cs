using Barbearia.Log;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Barbersoft.Utils
{
    public class GerarPDF
    {
        public string GerarDocumentoPDF()
        {
            string caminhoPDF = "";
            try
            {
                var pdxPorMm = 72 / 25.2F;
                var pdf = new Document(PageSize.A4, 15 * pdxPorMm, 15 * pdxPorMm, 15 * pdxPorMm, 20 * pdxPorMm);
                var nomeArquivo = $"pessoas.{DateTime.Now.ToString("yyyy.MM.dd.HH.mm.ss")}.pdf";
                var arquivo = new FileStream(nomeArquivo, FileMode.Create);
                var writer = PdfWriter.GetInstance(pdf, arquivo);
                pdf.Open();

                var fonteBase = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);

                //titulo
                var fonteParagrafo = new Font(fonteBase, 32, Font.NORMAL, BaseColor.Black);
                var titulo = new Paragraph("Relatório de Atendimento\n\n", fonteParagrafo);
                titulo.Alignment = Element.ALIGN_LEFT;
                pdf.Add(titulo);

                pdf.Close();
                arquivo.Close();

                caminhoPDF = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, nomeArquivo);
            } catch (Exception ex)
            {
                new Logging().Log(ex);
                MessageBox.Show("Não foi possível gerar PDF", "Atenção");;
            }
            return caminhoPDF;
        }
    }
}
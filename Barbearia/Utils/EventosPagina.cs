using iTextSharp.text;
using iTextSharp.text.pdf;
using System;

namespace Barbersoft.Utils
{
    public class EventosPagina : PdfPageEventHelper
    {
        private PdfContentByte wdc;
        private BaseFont fonteBaseRodape { get; set; }
        private Font fonteRodape { get; set; }
        private int totalPagina { get; set; }
        public EventosPagina(int totalPaginas)
        {
            fonteBaseRodape = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            fonteRodape = new Font(fonteBaseRodape, 8f, Font.NORMAL, BaseColor.BLACK);
            totalPagina = totalPaginas;
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);
            AdicionarMomentoGeracaoRelatorio(writer, document);
            AdicionarNumeroPagina(writer, document);
        }
        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            base.OnOpenDocument(writer, document);
            wdc = writer.DirectContent;
        }
        private void AdicionarMomentoGeracaoRelatorio(PdfWriter writer, Document document)
        {
            string data = DateTime.Now.ToString("dd/MM/yyyy");
            string hora = DateTime.Now.ToString("HH:mm");
            var textoMomentoGeracao = $"Retirado em: " + data + " às " + hora;

            wdc.BeginText();
            wdc.SetFontAndSize(fonteRodape.BaseFont, fonteRodape.Size);
            wdc.SetTextMatrix(document.LeftMargin, document.BottomMargin * 0.75f);
            wdc.ShowText(textoMomentoGeracao);
            wdc.EndText();
        }
        private void AdicionarNumeroPagina(PdfWriter writer, Document document)
        {
            int paginaAtual = writer.PageNumber;
            var textoPaginacao = $"Página {paginaAtual} de {totalPagina}";
            float larguraTextoPaginacao = fonteBaseRodape.GetWidthPoint(textoPaginacao, fonteRodape.Size);
            var tamanhoPagina = document.PageSize;

            wdc.BeginText();
            wdc.SetFontAndSize(fonteRodape.BaseFont, fonteRodape.Size);
            wdc.SetTextMatrix(tamanhoPagina.Width - document.RightMargin - larguraTextoPaginacao, document.BottomMargin * 0.75f);
            wdc.ShowText(textoPaginacao);
            wdc.EndText();
        }
    }
}

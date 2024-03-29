﻿using Barbearia.Log;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;

namespace Barbersoft.Utils
{
    public class GerarPDF
    {
        private static BaseFont fonteBase = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
        private readonly ObterDadosGenericos dados;
        public GerarPDF()
        {
            dados = new();
        }
        public string GerarDocumentoPDF(string tituloRelatorio, DateTime dataInicial, DateTime dataFinal)
        {
            string origem = "";
            try
            {
                // calculo de quantidade total de paginas
                int totalPaginas = 1;
                int totalLinhas = dados.RetornaAtendimentoFiltros(dataInicial, dataFinal).Count;
                if (totalLinhas > 24)
                    totalPaginas += (int)Math.Ceiling((totalLinhas - 24) / 29F);

                //configuração do pdf
                var pxPorMm = 72 / 25.2F;
                var pdf = new Document(PageSize.A4, 5 * pxPorMm, 5 * pxPorMm, 5 * pxPorMm, 15 * pxPorMm);
                var nomeArquivo = "RelatorioBarbersoft";
                var arquivo = new FileStream(nomeArquivo, FileMode.Create);
                var writer = PdfWriter.GetInstance(pdf, arquivo);
                writer.PageEvent = new EventosPagina(totalPaginas);
                pdf.Open();

                //adição do título
                var fonteParagrafo = new Font(fonteBase, 22, Font.NORMAL);
                var titulo = new Paragraph($"{tituloRelatorio.ToUpper()}\n\n", fonteParagrafo);
                titulo.Alignment = Element.ALIGN_LEFT;
                titulo.SpacingAfter = 4;
                pdf.Add(titulo);

                //adiciona imagem
                var caminhoImagem = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logoMarrom.png");
                if (File.Exists(caminhoImagem))
                {
                    Image logo = Image.GetInstance(caminhoImagem);
                    float razaoAlturaImagem = logo.Width / logo.Height;
                    float alturaLogo = 40;
                    float larguraLogo = alturaLogo * razaoAlturaImagem;
                    logo.ScaleToFit(larguraLogo, alturaLogo);
                    var margemEsquerda = 5 + pdf.PageSize.Width - pdf.RightMargin - larguraLogo;
                    var margemTopo = pdf.PageSize.Height - pdf.TopMargin - 42;
                    logo.SetAbsolutePosition(margemEsquerda, margemTopo);
                    writer.DirectContent.AddImage(logo, false);
                }

                //adição tabela de dados
                var tabela = new PdfPTable(5);
                float[] larguraColunas = { 0.5f, 0.8f, 2f, 2f, 0.9f };
                tabela.SetWidths(larguraColunas);
                tabela.DefaultCell.BorderWidth = 0;
                tabela.WidthPercentage = 100;

                //adição de células de títulos das colunas                
                CriarCelulaTexto(tabela, "ID", PdfPCell.ALIGN_RIGHT, true);
                CriarCelulaTexto(tabela, "Data", PdfPCell.ALIGN_CENTER, true);
                CriarCelulaTexto(tabela, "Cliente", PdfPCell.ALIGN_LEFT, true);
                CriarCelulaTexto(tabela, "Profissional", PdfPCell.ALIGN_LEFT, true);
                CriarCelulaTexto(tabela, "Situação", PdfPCell.ALIGN_LEFT, true);

                foreach (var atend in dados.RetornaAtendimentoFiltros(dataInicial, dataFinal))
                {
                    CriarCelulaTexto(tabela, atend.Id.ToString("D5"), PdfPCell.ALIGN_RIGHT);
                    CriarCelulaTexto(tabela, atend.Data.ToString("dd/MM/yyyy"), PdfPCell.ALIGN_CENTER);
                    CriarCelulaTexto(tabela, atend.Cliente, PdfPCell.ALIGN_LEFT);
                    CriarCelulaTexto(tabela, atend.Profissional, PdfPCell.ALIGN_LEFT);
                    CriarCelulaTexto(tabela, atend.Situacao, PdfPCell.ALIGN_LEFT);
                }

                pdf.Add(tabela);

                pdf.Close();
                arquivo.Close();

                //abre pdf no visualizador padrão
                var caminhoPDF = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, nomeArquivo);
                if (File.Exists(caminhoPDF))
                {
                    origem = caminhoPDF;
                }
            }
            catch (Exception ex)
            {
                new Logging().Log(ex);
            }            
            return origem;
        }
        private static void CriarCelulaTexto(PdfPTable tabela, string texto, int alinhamentoHorz = PdfPCell.ALIGN_LEFT,
            bool negrito = false, bool italico = false, int tamanhoFonte = 12, int alturaCelula = 25)
        {
            int estilo = Font.NORMAL;
            if (negrito && italico)
            {
                estilo = Font.BOLDITALIC;
            } else if (negrito)
            {
                estilo = Font.BOLD;
            } else if (italico)
            {
                estilo = Font.ITALIC;
            }

            var fonteCelula = new Font(fonteBase, tamanhoFonte, estilo, BaseColor.BLACK);

            var bgColor = BaseColor.WHITE;
            if (tabela.Rows.Count % 2 == 1)
                bgColor = new BaseColor(0.95F, 0.9F, 0.9F);

            var celula = new PdfPCell(new Phrase(texto, fonteCelula));
            celula.HorizontalAlignment = alinhamentoHorz;
            celula.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            celula.Border = 0;
            celula.BorderWidthBottom = 1;
            celula.FixedHeight = alturaCelula;
            celula.PaddingBottom = 5;
            celula.BackgroundColor = bgColor;
            tabela.AddCell(celula);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Dapper;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using PinedaStore.Models;
using System.Data.SqlClient;
//using Org.BouncyCastle.Crypto;
using iText.Kernel.Events;
using PinedaStore.Views.pdf;
using PinedaStore.Servicios;
using static PinedaStore.Servicios.Repositoriopdf;


namespace PinedaStore.Controllers
{
    public class pdfController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IRepositorioPdf repositorioPdf;

        public pdfController(IConfiguration configuration, IRepositorioPdf repositorioPdf)
        {
            _configuration = configuration;
            this.repositorioPdf = repositorioPdf;
        }

        public IActionResult pdf()
        {
            return View();
        }


        public IActionResult ListadoPersonasPdf()
        {

            // Generar el PDF
            MemoryStream stream = new MemoryStream();
            PdfWriter writer = new PdfWriter(stream);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            //  manejador de eventos para el pie de página
            pdf.AddEventHandler(PdfDocumentEvent.END_PAGE, new footer(document));

            // Título del documento
            document.Add(new Paragraph("Listado de Productos")
                .SetFontSize(18)
                .SetBold()
                .SetTextAlignment(TextAlignment.CENTER));

            //   tabla con encabezados
            Table table = new Table(6, true); // 4 columnas
            table.AddHeaderCell("Codigo");
            table.AddHeaderCell("Nombre");
            table.AddHeaderCell("Descripcion");
            table.AddHeaderCell("precio");
            table.AddHeaderCell("Unidades");
            table.AddHeaderCell("Estado");

            // Llenar la tabla con datos
            AdministradorModel administradorModel = new AdministradorModel();
            var personas= repositorioPdf.generarpdf(administradorModel);
            foreach (var persona in personas)
            {
                table.AddCell(persona.Codigo);
                table.AddCell(persona.Nombre);
                table.AddCell(persona.Descripcion);
                table.AddCell(persona.precio);
                table.AddCell(persona.Unidades);
                table.AddCell(persona.Estado);
            }

            // Agregar la tabla al documento
            document.Add(table);
            document.Close();

            // Retornar el archivo como respuesta
            byte[] pdfBytes = stream.ToArray();
            // Aplicar opción abrir pestaña navegador
            Response.Headers.Add("Content-Disposition", "inline; filename=ListadoPersonas.pdf");
            return File(pdfBytes, "application/pdf");
        }
    }
}

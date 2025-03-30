using iText.Kernel.Events;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Mvc;
using PinedaStore.Models;
using PinedaStore.Servicios;
using PinedaStore.Views.pdf;

namespace PinedaStore.Controllers
{
    public class PdfProvedorController : Controller
    {

        private readonly IConfiguration _configuration;
        private readonly IRepositorioPdf repositorioPdf;


        public PdfProvedorController(IConfiguration configuration, IRepositorioPdf repositorioPdf)
        {
            _configuration = configuration;
            this.repositorioPdf = repositorioPdf;
        }

        public IActionResult ListadoprovedorPdf()
        {

            // Generar el PDF
            MemoryStream stream = new MemoryStream();
            PdfWriter writer = new PdfWriter(stream);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            //  manejador de eventos para el pie de página
            pdf.AddEventHandler(PdfDocumentEvent.END_PAGE, new footer(document));

            // Título del documento
            document.Add(new Paragraph("Listado de Provedor")
                .SetFontSize(18)
                .SetBold()
                .SetTextAlignment(TextAlignment.CENTER));

            //   tabla con encabezados
            Table table = new Table(5, true); // 4 columnas
            table.AddHeaderCell("Id");
            table.AddHeaderCell("empresa");
            table.AddHeaderCell("nombre");
            table.AddHeaderCell("telefono");
            table.AddHeaderCell("correo");
            


            // Llenar la tabla con datos
            provedorModel pdfprovedor = new provedorModel();
            var personas = repositorioPdf.provedor(pdfprovedor);
            foreach (var persona in personas)
            {
                table.AddCell(persona.Id);
                table.AddCell(persona.empresa);
                table.AddCell(persona.nombre);
                table.AddCell(persona.telefono);
                table.AddCell(persona.correo);
               

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
        public IActionResult PdfProvedor()
        {
            return View();
        }


    }
}

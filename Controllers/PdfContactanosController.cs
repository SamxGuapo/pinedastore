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
    public class PdfContactanosController : Controller
    {
        public IActionResult PdfContactanos()
        {
            return View();
        }

        private readonly IConfiguration _configuration;
        private readonly IRepositorioPdf repositorioPdf;


        public PdfContactanosController(IConfiguration configuration, IRepositorioPdf repositorioPdf)
        {
            _configuration = configuration;
            this.repositorioPdf = repositorioPdf;
        }

        public IActionResult PdfRegistro()
        {
            return View();
        }

        public IActionResult ListadoContactanosPdf()
        {

            // Generar el PDF
            MemoryStream stream = new MemoryStream();
            PdfWriter writer = new PdfWriter(stream);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            //  manejador de eventos para el pie de página
            pdf.AddEventHandler(PdfDocumentEvent.END_PAGE, new footer(document));

            // Título del documento
            document.Add(new Paragraph("Listado de Contactanos")
                .SetFontSize(18)
                .SetBold()
                .SetTextAlignment(TextAlignment.CENTER));

            //   tabla con encabezados
            Table table = new Table(3, true); // 4 columnas
            table.AddHeaderCell("nombre");
            table.AddHeaderCell("correo");
            table.AddHeaderCell("mensaje");
           


            // Llenar la tabla con datos
            contactanosModel pdfcontactanos = new contactanosModel();
            var personas = repositorioPdf.contactar(pdfcontactanos);
            foreach (var persona in personas)
            {
                table.AddCell(persona.nombre);
                table.AddCell(persona.correo);
                table.AddCell(persona.mensaje);
                

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

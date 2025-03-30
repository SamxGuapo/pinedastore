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
    public class PdfRegistroController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IRepositorioPdf repositorioPdf;
        

        public PdfRegistroController(IConfiguration configuration, IRepositorioPdf repositorioPdf)
        {
            _configuration = configuration;
            this.repositorioPdf = repositorioPdf;
        }

        public IActionResult PdfRegistro()
        {
            return View();
        }

        public IActionResult ListadoregistroPdf()
        {

            // Generar el PDF
            MemoryStream stream = new MemoryStream();
            PdfWriter writer = new PdfWriter(stream);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            //  manejador de eventos para el pie de página
            pdf.AddEventHandler(PdfDocumentEvent.END_PAGE, new footer(document));

            // Título del documento
            document.Add(new Paragraph("Listado de Registro")
                .SetFontSize(18)
                .SetBold()
                .SetTextAlignment(TextAlignment.CENTER));

            //   tabla con encabezados
            Table table = new Table(7, true); // 4 columnas
            table.AddHeaderCell("id");
            table.AddHeaderCell("nombre");
            table.AddHeaderCell("apellido");
            table.AddHeaderCell("fecha");
            table.AddHeaderCell("sexo");
            table.AddHeaderCell("correo");
            table.AddHeaderCell("usuario");
           

            // Llenar la tabla con datos
            registromodel registro = new registromodel();
            var personas = repositorioPdf.generar(registro);
            foreach (var persona in personas)
            {
                table.AddCell(persona.id);
                table.AddCell(persona.nombre);
                table.AddCell(persona.apellido);
                table.AddCell(persona.fecha);
                table.AddCell(persona.sexo);
                table.AddCell(persona.correo);
                table.AddCell(persona.usuario);
               
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


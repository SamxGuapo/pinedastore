using iText.Kernel.Geom;
using iText.Kernel.Events;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace PinedaStore.Views.pdf
{
    public class footer : IEventHandler
    {
        private readonly Document _document;

        public footer(Document document)
        {
            _document = document;

        }

        public void HandleEvent(Event @event)
        {
            PdfDocumentEvent docEvent = (PdfDocumentEvent)@event;
            PdfPage page = docEvent.GetPage();
            PdfCanvas canvas = new PdfCanvas(page.NewContentStreamAfter(), page.GetResources(), docEvent.GetDocument());

            // Obtener dimensiones de la página
            Rectangle pageSize = page.GetPageSize();

            // Crear el pie de página
            Canvas footerCanvas = new Canvas(canvas, pageSize);
            footerCanvas.SetFontSize(10);

            Paragraph footerParagraph = new Paragraph()
            .Add("Desarrollamos Software ADSO\n")
            .Add("Página " + docEvent.GetDocument().GetPageNumber(page));

            // Dibujar el pie de página en la posición deseada
            footerCanvas
                .ShowTextAligned(
                    footerParagraph,
                    pageSize.GetWidth() / 2, // Centrar en el ancho
                    pageSize.GetBottom() + 20, // Margen desde el borde inferior
                    iText.Layout.Properties.TextAlignment.CENTER
                );

            footerCanvas.Close();


        }

    }
}

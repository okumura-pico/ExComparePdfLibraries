namespace PdfIntoTextPieces;

using GemBox.Pdf;
using GemBox.Pdf.Content;

public class AnalyzePdf
{
    public AnalyzeResult analyze(Stream stream) =>
        this.analyze(stream, PdfLoadOptions.Default);

    public AnalyzeResult analyze(Stream stream, PdfLoadOptions options)
    {
        using (var document = PdfDocument.Load(stream, options))
        {
            var pageNumber = 1;
            var readResults = document.Pages
                .Select(page =>
                {
                    var readResult = PdfPage2ReadResult.Convert(page);
                    readResult.page = pageNumber++;
                    return readResult;
                })
                .ToArray();

            return new AnalyzeResult
            {
                readResults = readResults
            };
        }
    }
}

class PdfPage2ReadResult
{
    public static ReadResult Convert(PdfPage src) =>
        new ReadResult
        {
            width = src.Size.Width,
            height = src.Size.Height,
            lines = src.Content.Elements
                .Where(x => x.ElementType == PdfContentElementType.Text)
                .Select(x => PdfTextContent2Line.Convert((PdfTextContent)x))
                .ToArray()
        };
}


class PdfTextContent2Line
{
    public static Line Convert(PdfTextContent src) =>
        new Line
        {
            text = src.ToString(),
            boundingBox = PdfQuad2BoudingBox.Convert(src.Bounds),
        };
}

class PdfQuad2BoudingBox
{
    public static IEnumerable<double> Convert(PdfQuad src) =>
        new double[] {
            src.Left,
            src.Top,
            src.Right,
            src.Top,
            src.Right,
            src.Bottom,
            src.Left,
            src.Bottom,
        };
}

if (args.Length < 1)
{
    Console.Error.WriteLine($"Usage: App <PDF file>");
    return;
}

GemBox.Pdf.ComponentInfo.SetLicense("FREE-LIMITED-KEY");


using (var stream = File.OpenRead(args[0]))
{
    var analyzePdf = new PdfIntoTextPieces.AnalyzePdf();
    var result = analyzePdf.analyze(stream);
    var options = new System.Text.Json.JsonSerializerOptions
    {
        IncludeFields = true,
    };
    var json = System.Text.Json.JsonSerializer.Serialize(result, options);
    Console.WriteLine(json);
}


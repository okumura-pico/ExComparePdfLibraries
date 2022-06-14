# GemBox.PDF Example

## Pre requirements

- dotnet sdk 6

## Getting started

```console
git clone https://github.com/okumura-pico/ExGemboxPdf.git
cd ExGemboxPdf
dotnet build
./App/bin/Debug/net6.0/App "Pdf file path"
```

## What is this?

Extract a pdf into text and bounding box.

## API

At first, create an instance.

```c#
var analyzePdf = new PdfIntoTextPieces.AnalyzePdf();
```

Then get the result.

```c#
var result = analyzePdf.analyze(stream);
```

The result type is [AnalyzeResult](./PdfIntoTextPieces/AnalyzeResult.cs).

namespace PdfIntoTextPieces;

public class Word
{
    /// <summary>
    /// Quadrangle bounding box of a word, specifed as a list of 8 numbers.
    /// The 8 numbers represent the four points,clockwise from the top-left
    /// corner relative to the text orientation.
    /// </summary>
    IEnumerable<float>? boundingBox;
    /// <summary>
    /// The text content of a word
    /// </summary>
    string? text;
}

public class Line
{
    /// <summary>
    /// List of words in the text line
    /// </summary>
    // public IEnumerable<Word> words;
    public IEnumerable<double>? boundingBox;
    public string? text;
}

public class ReadResult
{
    /// <summary>
    /// List of text lines.
    /// </summary>
    public IEnumerable<Line>? lines;
    /// <summary>
    /// The 1-based page number in the input document.
    /// </summary>
    public int page;
    /// <summary>
    /// The width of the image/PDF in pixels/inches, respectively.
    /// </summary>
    public double width;
    /// <summary>
    /// The height of the image/PDF in pixels/inches, respectively.
    /// </summary>
    public double height;
}

public class AnalyzeResult
{
    public IEnumerable<ReadResult>? readResults;
}


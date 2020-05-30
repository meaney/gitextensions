using JetBrains.Annotations;

namespace GitUI.Editor
{
    /// <inherritdoc/>
    public class FileDiffMetaData : IFileDiffMetaData
    {
        public FileDiffMetaData([NotNull] string fileName, int lineNumber, [NotNull] string selectedText, [NotNull] string currentLine,
                                [NotNull] string diffContents)
        {
            FileName = fileName;
            LineNumber = lineNumber;
            SelectedText = selectedText;
            LineText = currentLine;
            DiffContents = diffContents;
        }

        public string FileName { get; }

        public int LineNumber { get; }

        public string SelectedText { get; }

        public string LineText { get; }

        public string DiffContents { get; }
    }
}

using JetBrains.Annotations;

namespace GitUI.Editor
{
    /// <summary>
    /// An immutable snapshot relating to the review of a file diff.
    /// </summary>
    public interface IFileDiffMetaData
    {
        /// <summary>
        /// Name of the file
        /// </summary>
        [NotNull]
        string FileName { get; }

        /// <summary>
        /// Line number of the cursor location.
        /// </summary>
        int LineNumber { get; }

        /// <summary>
        /// Column number of the cursor location.
        /// </summary>
        [NotNull]
        string SelectedText { get; }

        /// <summary>
        /// Line of text at the cursor location.
        /// </summary>
        [NotNull]
        string LineText { get; }

        /// <summary>
        /// Full text shown in the diff view.
        /// </summary>
        [NotNull]
        string DiffContents { get; }
    }
}

using System.ComponentModel;

namespace Sugar.Mime
{
    /// <summary>
    /// Mime sub-types for applications
    /// </summary>
    public enum ApplicationMimeType
    {
        /// <summary>
        /// Unknown application type.
        /// This is the default for files whose mime type cannot be found.
        /// </summary>
        [Description("unknown")]
        Unknown,

        /// <summary>
        /// Undefined binary data
        /// </summary>
        [Description("octet-stream")]
        OctetStream,

        /// <summary>
        /// Microsoft Word document (old)
        /// </summary>
        [Description("msword")]
        MicrosoftWord,

        /// <summary>
        /// Microsoft Word document, open XML newer version.
        /// </summary>
        [Description("vnd.openxmlformats-officedocument.wordprocessingml.document")]
        MicrosoftWordOpenXml,

        /// <summary>
        /// Microsoft Powerpoint document (old)
        /// </summary>
        [Description("vnd.ms-powerpoint")]
        MicrosoftPowerPoint,

        /// <summary>
        /// Microsoft Powerpoint document, open XML newer version.
        /// </summary>
        [Description("vnd.openxmlformats-officedocument.presentationml.presentation")]
        MicrosoftPowerPointOpenXml,

        /// <summary>
        /// Microsoft Excel document (old)
        /// </summary>
        [Description("vnd.ms-excel")]
        MicrosoftExcel,

        /// <summary>
        /// Microsoft Excel document, open XML newer version.
        /// </summary>
        [Description("vnd.openxmlformats-officedocument.spreadsheetml.sheet")]
        MicrosoftExcelOpenXml,

        /// <summary>
        /// GZip archive
        /// </summary>
        [Description("x-gzip")]
        GZip,

        /// <summary>
        /// Zip archive
        /// </summary>
        [Description("x-compressed")]
        Zip,

        /// <summary>
        /// Adobe PDF document
        /// </summary>
        [Description("pdf")]
        Pdf
    }
}
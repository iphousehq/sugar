using System.Collections.Generic;

namespace Sugar.Mime
{
    /// <summary>
    /// Generate common mime types
    /// </summary>
    public static class CommonMimeTypes
    {
        /// <summary>
        /// Generates common mime types
        /// </summary>
        /// <returns></returns>
        public static IList<BaseMime> Generate()
        {
            return new List<BaseMime>
            {
                #region Application

                new ApplicationMime
                {
                    ApplicationMimeType = ApplicationMimeType.Unknown,
                    Extensions = new List<string>{""}
                },

                new ApplicationMime
                {
                    ApplicationMimeType = ApplicationMimeType.OctetStream,
                    Extensions = new List<string>{"bin"}
                },

                new ApplicationMime
                {
                    ApplicationMimeType = ApplicationMimeType.MicrosoftWord,
                    Extensions = new List<string>{"doc"}
                },

                new ApplicationMime
                {
                    ApplicationMimeType = ApplicationMimeType.MicrosoftWordOpenXml,
                    Extensions = new List<string>{"docx"}
                },

                new ApplicationMime
                {
                    ApplicationMimeType = ApplicationMimeType.MicrosoftPowerPoint,
                    Extensions = new List<string>{"ppt"}
                },

                new ApplicationMime
                {
                    ApplicationMimeType = ApplicationMimeType.MicrosoftPowerPointOpenXml,
                    Extensions = new List<string>{"pptx"}
                },

                new ApplicationMime
                {
                    ApplicationMimeType = ApplicationMimeType.MicrosoftExcel,
                    Extensions = new List<string>{"xls"}
                },

                new ApplicationMime
                {
                    ApplicationMimeType = ApplicationMimeType.MicrosoftExcelOpenXml,
                    Extensions = new List<string>{"xlsx"}
                },

                new ApplicationMime
                {
                    ApplicationMimeType = ApplicationMimeType.GZip,
                    Extensions = new List<string>{"gzip"}
                },

                new ApplicationMime
                {
                    ApplicationMimeType = ApplicationMimeType.Zip,
                    Extensions = new List<string>{"zip"}
                },

                new ApplicationMime
                {
                    ApplicationMimeType = ApplicationMimeType.Pdf,
                    Extensions = new List<string>{"pdf"}
                },

                #endregion

                #region Audio

                new AudioMime
                {
                    AudioMimeType = AudioMimeType.Basic,
                    Extensions = new List<string>{"au", "snd"}
                },

                new AudioMime
                {
                    AudioMimeType = AudioMimeType.Midi,
                    Extensions = new List<string>{"mid", "midi"}
                },

                new AudioMime
                {
                    AudioMimeType = AudioMimeType.Mpeg,
                    Extensions = new List<string>{"mp2", "mp3", "mpa", "mpg", "mpga"}
                },

                new AudioMime
                {
                    AudioMimeType = AudioMimeType.Mpeg4,
                    Extensions = new List<string>{"mp4", "mp4a"}
                },

                new AudioMime
                {
                    AudioMimeType = AudioMimeType.OggVorbis,
                    Extensions = new List<string>{"ogg"}
                },

                new AudioMime
                {
                    AudioMimeType = AudioMimeType.RealAudio,
                    Extensions = new List<string>{"ra", "ram"}
                },

                new AudioMime
                {
                    AudioMimeType = AudioMimeType.Wav,
                    Extensions = new List<string>{"wav"}
                },

                new AudioMime
                {
                    AudioMimeType = AudioMimeType.Wav,
                    Extensions = new List<string>{"wma"}
                },

                #endregion

                #region Image

                new ImageMime
                {
                    ImageMimeType = ImageMimeType.Bitmap,
                    Extensions = new List<string>{"bmp"}
                },

                new ImageMime
                {
                    ImageMimeType = ImageMimeType.Icon,
                    Extensions = new List<string>{"ico"}
                },

                new ImageMime
                {
                    ImageMimeType = ImageMimeType.Jpeg,
                    Extensions = new List<string>{"jpg", "jpeg"}
                },

                new ImageMime
                {
                    ImageMimeType = ImageMimeType.Png,
                    Extensions = new List<string>{"png"}
                },

                new ImageMime
                {
                    ImageMimeType = ImageMimeType.Svg,
                    Extensions = new List<string>{"svg"}
                },

                new ImageMime
                {
                    ImageMimeType = ImageMimeType.Tiff,
                    Extensions = new List<string>{"tiff", "tif"}
                },

                #endregion

                #region Text
                
                new TextMime
                {
                    TextMimeType = TextMimeType.CascadingStyleSheet,
                    Extensions = new List<string>{"css"}
                },

                new TextMime
                {
                    TextMimeType = TextMimeType.CommaSeperatedValues,
                    Extensions = new List<string>{"csv"}
                },

                new TextMime
                {
                    TextMimeType = TextMimeType.Html,
                    Extensions = new List<string>{"htm", "html", "htmls"}
                },

                new TextMime
                {
                    TextMimeType = TextMimeType.Plain,
                    Extensions = new List<string>{"txt", "text", "log"}
                },

                new TextMime
                {
                    TextMimeType = TextMimeType.Xml,
                    Extensions = new List<string>{"xml"}
                },

                #endregion

                #region Video
                
                new VideoMime
                {
                    VideoMimeType = VideoMimeType.Avi,
                    Extensions = new List<string>{"avi"}
                },

                new VideoMime
                {
                    VideoMimeType = VideoMimeType.Flash,
                    Extensions = new List<string>{"flv"}
                },

                new VideoMime
                {
                    VideoMimeType = VideoMimeType.Mpeg,
                    Extensions = new List<string>{"mpg", "mpeg"}
                },

                new VideoMime
                {
                    VideoMimeType = VideoMimeType.Mpeg4,
                    Extensions = new List<string>{"mp4", "mp4a"}
                },

                new VideoMime
                {
                    VideoMimeType = VideoMimeType.Quicktime,
                    Extensions = new List<string>{"qt", "mov"}
                },

                new VideoMime
                {
                    VideoMimeType = VideoMimeType.WindowsMedia,
                    Extensions = new List<string>{"wmv"}
                }

                #endregion
            };
        }
    }
}
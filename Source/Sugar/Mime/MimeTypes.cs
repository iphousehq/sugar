using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Sugar.Mime
{
    /// <summary>
    /// Common mime types
    /// </summary>
    public static class MimeTypes
    {
        #region Application

        /// <summary>
        /// Gets the unknown mime type.
        /// </summary>
        public static ApplicationMime Unknown
        {
            get
            {
                return new ApplicationMime
                {
                    ApplicationMimeType = ApplicationMimeType.Unknown,
                    Extensions = new List<string> {""}
                };
            }
        }

        /// <summary>
        /// Gets the octet stream mime type.
        /// </summary>
        public static ApplicationMime OctetStream
        {
            get
            {
                return new ApplicationMime
                {
                    ApplicationMimeType = ApplicationMimeType.OctetStream,
                    Extensions = new List<string> {"bin"}
                };
            }
        }

        /// <summary>
        /// Gets the Microsoft Word mime type.
        /// </summary>
        public static ApplicationMime MicrosoftWord
        {
            get
            {
                return new ApplicationMime
                {
                    ApplicationMimeType = ApplicationMimeType.MicrosoftWord,
                    Extensions = new List<string> {"doc"}
                };
            }
        }

        /// <summary>
        /// Gets the Microsoft Word Open XML mime type.
        /// </summary>
        public static ApplicationMime MicrosoftWordOpenXml
        {
            get
            {
                return new ApplicationMime
                {
                    ApplicationMimeType = ApplicationMimeType.MicrosoftWordOpenXml,
                    Extensions = new List<string> {"docx"}
                };
            }
        }

        /// <summary>
        /// Gets the Microsoft Power Point mime type.
        /// </summary>
        public static ApplicationMime MicrosoftPowerPoint
        {
            get
            {
                return new ApplicationMime
                {
                    ApplicationMimeType = ApplicationMimeType.MicrosoftPowerPoint,
                    Extensions = new List<string> {"ppt"}
                };
            }
        }

        /// <summary>
        /// Gets the Microsoft Power Point Open XML mime type.
        /// </summary>
        public static ApplicationMime MicrosoftPowerPointOpenXml
        {
            get
            {
                return new ApplicationMime
                {
                    ApplicationMimeType = ApplicationMimeType.MicrosoftPowerPointOpenXml,
                    Extensions = new List<string> {"pptx"}
                };
            }
        }

        /// <summary>
        /// Gets the Microsoft Excel mime type.
        /// </summary>
        public static ApplicationMime MicrosoftExcel
        {
            get
            {
                return new ApplicationMime
                {
                    ApplicationMimeType = ApplicationMimeType.MicrosoftExcel,
                    Extensions = new List<string> {"xls"}
                };
            }
        }

        /// <summary>
        /// Gets the Microsoft Excel Open XML mime type.
        /// </summary>
        public static ApplicationMime MicrosoftExcelOpenXml
        {
            get
            {
                return new ApplicationMime
                {
                    ApplicationMimeType = ApplicationMimeType.MicrosoftExcelOpenXml,
                    Extensions = new List<string> {"xlsx"}
                };
            }
        }

        /// <summary>
        /// Gets the gzip mime type.
        /// </summary>
        public static ApplicationMime GZip
        {
            get
            {
                return new ApplicationMime
                {
                    ApplicationMimeType = ApplicationMimeType.GZip,
                    Extensions = new List<string> {"gzip"}
                };
            }
        }

        /// <summary>
        /// Gets the zip mime type.
        /// </summary>
        public static ApplicationMime Zip
        {
            get
            {
                return new ApplicationMime
                {
                    ApplicationMimeType = ApplicationMimeType.Zip,
                    Extensions = new List<string> {"zip"}
                };
            }
        }

        /// <summary>
        /// Gets the PDF mime type.
        /// </summary>
        public static ApplicationMime Pdf
        {
            get
            {
                return new ApplicationMime
                {
                    ApplicationMimeType = ApplicationMimeType.Pdf,
                    Extensions = new List<string> {"pdf"}
                };
            }
        }

        /// <summary>
        /// Gets the JSON mime type.
        /// </summary>
        public static ApplicationMime Json
        {
            get
            {
                return new ApplicationMime
                {
                    ApplicationMimeType = ApplicationMimeType.Json,
                    Extensions = new List<string> {"json"}
                };
            }
        }

        #endregion

        #region Audio

        /// <summary>
        /// Gets the basic audio mime type.
        /// </summary>
        public static AudioMime BasicAudio
        {
            get
            {
                return new AudioMime
                {
                    AudioMimeType = AudioMimeType.Basic,
                    Extensions = new List<string> {"au", "snd"}
                };
            }
        }

        /// <summary>
        /// Gets the midi audio mime type.
        /// </summary>
        public static AudioMime MidiAudio
        {
            get
            {
                return new AudioMime
                {
                    AudioMimeType = AudioMimeType.Midi,
                    Extensions = new List<string> {"mid", "midi"}
                };
            }
        }

        /// <summary>
        /// Gets the MPEG audio mime type.
        /// </summary>
        public static AudioMime MpegAudio
        {
            get
            {
                return new AudioMime
                {
                    AudioMimeType = AudioMimeType.Mpeg,
                    Extensions = new List<string> {"mp2", "mp3", "mpa", "mpg", "mpga"}
                };
            }
        }

        /// <summary>
        /// Gets the MPEG4 audio mime type.
        /// </summary>
        public static AudioMime Mpeg4Audio
        {
            get
            {
                return new AudioMime
                {
                    AudioMimeType = AudioMimeType.Mpeg4,
                    Extensions = new List<string> {"mp4", "mp4a"}
                };
            }
        }

        /// <summary>
        /// Gets the Ogg Vorbis audio mime type.
        /// </summary>
        public static AudioMime OggVorbisAudio
        {
            get
            {
                return new AudioMime
                {
                    AudioMimeType = AudioMimeType.OggVorbis,
                    Extensions = new List<string> {"ogg"}
                };
            }
        }

        /// <summary>
        /// Gets the Real Audio mime type.
        /// </summary>
        public static AudioMime RealAudio
        {
            get
            {
                return new AudioMime
                {
                    AudioMimeType = AudioMimeType.RealAudio,
                    Extensions = new List<string> {"ra", "ram"}
                };
            }
        }

        /// <summary>
        /// Gets the wav audio mime type.
        /// </summary>
        public static AudioMime WavAudio
        {
            get
            {
                return new AudioMime
                {
                    AudioMimeType = AudioMimeType.Wav,
                    Extensions = new List<string> {"wav"}
                };
            }
        }

        /// <summary>
        /// Gets the Windows Media audio mime type.
        /// </summary>
        public static AudioMime WindowsMediaAudio
        {
            get
            {
                return new AudioMime
                {
                    AudioMimeType = AudioMimeType.WindowsMedia,
                    Extensions = new List<string> {"wma"}
                };
            }
        }

        #endregion

        #region Image

        /// <summary>
        /// Gets the bitmap mime type.
        /// </summary>
        public static ImageMime Bitmap
        {
            get
            {
                return new ImageMime
                {
                    ImageMimeType = ImageMimeType.Bitmap,
                    Extensions = new List<string> {"bmp"}
                };
            }
        }

        /// <summary>
        /// Gets the icon mime type.
        /// </summary>
        public static ImageMime Icon
        {
            get
            {
                return new ImageMime
                {
                    ImageMimeType = ImageMimeType.Icon,
                    Extensions = new List<string> {"ico"}
                };
            }
        }

        /// <summary>
        /// Gets the JPEG mime type.
        /// </summary>
        public static ImageMime Jpeg
        {
            get
            {
                return new ImageMime
                {
                    ImageMimeType = ImageMimeType.Jpeg,
                    Extensions = new List<string> {"jpg", "jpeg"}
                };
            }
        }

        /// <summary>
        /// Gets the PNG mime type.
        /// </summary>
        public static ImageMime Png
        {
            get
            {
                return new ImageMime
                {
                    ImageMimeType = ImageMimeType.Png,
                    Extensions = new List<string> {"png"}
                };
            }
        }

        /// <summary>
        /// Gets the SVG mime type.
        /// </summary>
        public static ImageMime Svg
        {
            get
            {
                return new ImageMime
                {
                    ImageMimeType = ImageMimeType.Svg,
                    Extensions = new List<string> {"svg"}
                };
            }
        }

        /// <summary>
        /// Gets the TIFF mime type.
        /// </summary>
        public static ImageMime Tiff
        {
            get
            {
                return new ImageMime
                {
                    ImageMimeType = ImageMimeType.Tiff,
                    Extensions = new List<string> {"tiff", "tif"}
                };
            }
        }

        public static ImageMime Gif
        {
            get
            {
                return new ImageMime
                {
                    ImageMimeType = ImageMimeType.Gif,
                    Extensions = new List<string> { "gif" }
                };
            }
        }

        #endregion

        #region Text

        /// <summary>
        /// Gets the Css mime type.
        /// </summary>
        public static TextMime Css
        {
            get
            {
                return new TextMime
                {
                    TextMimeType = TextMimeType.CascadingStyleSheet,
                    Extensions = new List<string> {"css"}
                };
            }
        }

        /// <summary>
        /// Gets the CSV mime type.
        /// </summary>
        public static TextMime Csv
        {
            get
            {
                return new TextMime
                {
                    TextMimeType = TextMimeType.CommaSeperatedValues,
                    Extensions = new List<string> {"csv"}
                };
            }
        }

        /// <summary>
        /// Gets the HTML mime type.
        /// </summary>
        public static TextMime Html
        {
            get
            {
                return new TextMime
                {
                    TextMimeType = TextMimeType.Html,
                    Extensions = new List<string> {"htm", "html", "htmls"}
                };
            }
        }

        /// <summary>
        /// Gets the plain text mime type.
        /// </summary>
        public static TextMime PlainText
        {
            get
            {
                return new TextMime
                {
                    TextMimeType = TextMimeType.Plain,
                    Extensions = new List<string> {"txt", "text", "log"}
                };
            }
        }

        /// <summary>
        /// Gets the XML mime type.
        /// </summary>
        public static TextMime Xml
        {
            get
            {
                return new TextMime
                {
                    TextMimeType = TextMimeType.Xml,
                    Extensions = new List<string> {"xml"}
                };
            }
        }

        #endregion

        #region Video

        /// <summary>
        /// Gets the AVI video mime type.
        /// </summary>
        public static VideoMime AviVideo
        {
            get
            {
                return new VideoMime
                {
                    VideoMimeType = VideoMimeType.Avi,
                    Extensions = new List<string> {"avi"}
                };
            }
        }

        /// <summary>
        /// Gets the flash video mime type.
        /// </summary>
        public static VideoMime FlashVideo
        {
            get
            {
                return new VideoMime
                {
                    VideoMimeType = VideoMimeType.Flash,
                    Extensions = new List<string> {"flv"}
                };
            }
        }

        /// <summary>
        /// Gets the MPEG video mime type.
        /// </summary>
        public static VideoMime MpegVideo
        {
            get
            {
                return new VideoMime
                {
                    VideoMimeType = VideoMimeType.Mpeg,
                    Extensions = new List<string> {"mpg", "mpeg"}
                };
            }
        }

        /// <summary>
        /// Gets the MPEG4 video mime type.
        /// </summary>
        public static VideoMime Mpeg4Video
        {
            get
            {
                return new VideoMime
                {
                    VideoMimeType = VideoMimeType.Mpeg4,
                    Extensions = new List<string> {"mp4", "mp4a"}
                };
            }
        }

        /// <summary>
        /// Gets the Quicktime video mime type.
        /// </summary>
        public static VideoMime QuicktimeVideo
        {
            get
            {
                return new VideoMime
                {
                    VideoMimeType = VideoMimeType.Quicktime,
                    Extensions = new List<string> {"qt", "mov"}
                };
            }
        }

        /// <summary>
        /// Gets the Windows Media video mime type.
        /// </summary>
        public static VideoMime WindowsMediaVideo
        {
            get
            {
                return new VideoMime
                {
                    VideoMimeType = VideoMimeType.WindowsMedia,
                    Extensions = new List<string> {"wmv"}
                };
            }
        }

        #endregion

        /// <summary>
        /// Generates common mime types
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<BaseMime> Generate()
        {
            var types = typeof (MimeTypes).GetProperties(BindingFlags.Public | BindingFlags.Static);

            return types
                .Select(type => type.GetGetMethod().Invoke(null, null))
                .OfType<BaseMime>();
        }
    }
}
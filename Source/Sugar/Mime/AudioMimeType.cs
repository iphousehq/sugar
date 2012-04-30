using System.ComponentModel;

namespace Sugar.Mime
{
    /// <summary>
    /// Mime sub-types for audio
    /// </summary>
    public enum AudioMimeType
    {
        /// <summary>
        /// Basic audio
        /// </summary>
        [Description("basic")]
        Basic,

        /// <summary>
        /// Midi audio
        /// </summary>
        [Description("midi")]
        Midi,

        /// <summary>
        /// MP4 audio
        /// </summary>
        [Description("mp4")]
        Mpeg4,

        /// <summary>
        /// MP3 / MPEG audio
        /// </summary>
        [Description("mpeg")]
        Mpeg,

        /// <summary>
        /// Ogg Vorbis audio
        /// </summary>
        [Description("ogg")]
        OggVorbis,

        /// <summary>
        /// Windows Media audio
        /// </summary>
        [Description("x-ms-wma")]
        WindowsMedia,

        /// <summary>
        /// Real Audio
        /// </summary>
        [Description("vnd.rn-realaudio")]
        RealAudio,

        /// <summary>
        /// WAV audio
        /// </summary>
        [Description("vnd.wav")]
        Wav
    }
}
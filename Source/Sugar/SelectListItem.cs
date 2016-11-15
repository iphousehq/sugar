using System.Runtime.Serialization;

namespace Sugar
{
    /// <summary>
    /// Implementation of a select list item that can be serialized easily.
    /// </summary>
    [DataContract]
    public class SelectListItem
    {
        /// <summary>
        /// Gets or sets the selected.
        /// </summary>
        /// <value>The selected.</value>
        [DataMember(Name = "selected")]
        public bool Selected { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        [DataMember(Name = "text")]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [DataMember(Name = "value")]
        public string Value { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Sugar
{
    /// <summary>
    /// Builder to generate HTML fragments
    /// </summary>
    public class HtmlBuilder : IDisposable
    {
        private readonly StringBuilder sb = new StringBuilder();
        private readonly string tag;
        private readonly IDictionary<string, string> attrs = new Dictionary<string, string>();
        private bool flushed = false;
        
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlBuilder"/> class.
        /// </summary>
        public HtmlBuilder()
        {
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="HtmlBuilder"/> class from being created.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="sb">The sb.</param>
        /// <param name="attributes">The attributes.</param>
        private HtmlBuilder(string tag, StringBuilder sb, object attributes = null)
        {
            this.tag = tag;
            this.sb = sb;

            sb.Append("<");
            sb.Append(tag);

            if (attributes != null)
            {
                var properties = attributes.GetType().GetProperties();

                foreach (var property in properties)
                {
                    Attribute(property.Name, property.GetValue(attributes, null));
                }
            }
        }

        #endregion

        /// <summary>
        /// Appends the specified attribute to this instance.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="replace">if set to <c>true</c> replace the existing value with the given one.</param>
        /// <returns></returns>
        public HtmlBuilder Attribute(string name, object value, bool replace = false)
        {
            if (attrs.ContainsKey(name) && replace)
            {
                attrs[name] = value.ToString();                                
            }
            else if (attrs.ContainsKey(name))
            {
                attrs[name] += " " + value;                
            }
            else
            {
                attrs.Add(name, value.ToString());                
            }

            return this;
        }

        /// <summary>
        /// Sets the tag's class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="replace">if set to <c>true</c> [replace].</param>
        /// <returns></returns>
        public HtmlBuilder Class(string value, bool replace = false)
        {
            return Attribute("class", value, replace);
        }

        /// <summary>
        /// Sets the tag's Id.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="replace">if set to <c>true</c> [replace].</param>
        /// <returns></returns>
        public HtmlBuilder Id(string value, bool replace = false)
        {
            return Attribute("id", value, replace);
        }

        /// <summary>
        /// Sets the tag's Name.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="replace">if set to <c>true</c> [replace].</param>
        /// <returns></returns>
        public HtmlBuilder Name(string value, bool replace = false)
        {
            return Attribute("name", value, replace);
        }

        /// <summary>
        /// Sets the tag's For attribute.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="replace">if set to <c>true</c> [replace].</param>
        /// <returns></returns>
        public HtmlBuilder For(string value, bool replace = false)
        {
            return Attribute("for", value, replace);
        }

        /// <summary>
        /// Sets the tag's Value attribute.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="replace">if set to <c>true</c> [replace].</param>
        /// <returns></returns>
        public HtmlBuilder Value(string value, bool replace = false)
        {
            return Attribute("value", value, replace);
        }

        /// <summary>
        /// Sets the tag's Style attribute.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="replace">if set to <c>true</c> [replace].</param>
        /// <returns></returns>
        public HtmlBuilder Style(string value, bool replace = false)
        {
            return Attribute("style", value, replace);
        }

        /// <summary>
        /// Flushes the attributes and closes this opening tag.
        /// </summary>
        /// <returns></returns>
        public HtmlBuilder FlushAttributes()
        {
            if (!flushed)
            {
                foreach (var key in attrs.Keys)
                {
                    sb.Append(" ");
                    sb.Append(key);
                    sb.Append(@"=""");
                    sb.Append(attrs[key]);
                    sb.Append(@"""");
                }

                if (sb.Length > 0)
                {
                    sb.Append(">");
                }

                flushed = true;
            }

            return this;
        }

        #region Tags

        /// <summary>
        /// Builds a Paragraph Tag
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        public HtmlBuilder P(object attributes = null)
        {
            FlushAttributes();

            return new HtmlBuilder("p", sb, attributes);
        }

        /// <summary>
        /// Builds a DIV Tag
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        public HtmlBuilder Div(object attributes = null)
        {
            FlushAttributes();

            return new HtmlBuilder("div", sb, attributes);
        }

        /// <summary>
        /// Builds a Span Tag
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        public HtmlBuilder Span(object attributes = null)
        {
            FlushAttributes();

            return new HtmlBuilder("span", sb, attributes);
        }

        /// <summary>
        /// Builds an Input Tag
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        public HtmlBuilder Input(object attributes = null)
        {
            FlushAttributes();

            return new HtmlBuilder("input", sb, attributes);
        }

        /// <summary>
        /// Builds a Textarea Tag
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        public HtmlBuilder Textarea(object attributes = null)
        {
            FlushAttributes();

            return new HtmlBuilder("textarea", sb, attributes);
        }

        /// <summary>
        /// Builds a Label Tag
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        public HtmlBuilder Label(object attributes = null)
        {
            FlushAttributes();

            return new HtmlBuilder("label", sb, attributes);
        }

        /// <summary>
        /// Builds a Form Tag
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        public HtmlBuilder Form(object attributes = null)
        {
            FlushAttributes();

            return new HtmlBuilder("form", sb, attributes);
        }

        /// <summary>
        /// Builds a Fieldset Tag
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        public HtmlBuilder Fieldset(object attributes = null)
        {
            FlushAttributes();

            return new HtmlBuilder("fieldset", sb, attributes);
        }

        /// <summary>
        /// Builds a Button Tag
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        public HtmlBuilder Button(object attributes = null)
        {
            FlushAttributes();

            return new HtmlBuilder("button", sb, attributes);
        }

        /// <summary>
        /// Builds an Anchor Tag
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        public HtmlBuilder A(object attributes = null)
        {
            FlushAttributes();

            return new HtmlBuilder("a", sb, attributes);
        }

        /// <summary>
        /// Builds a Select Tag
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        public HtmlBuilder Select(object attributes = null)
        {
            FlushAttributes();

            return new HtmlBuilder("select", sb, attributes);
        }

        /// <summary>
        /// Builds an Option Tag
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        public HtmlBuilder Option(object attributes = null)
        {
            FlushAttributes();

            return new HtmlBuilder("option", sb, attributes);
        }

        /// <summary>
        /// Builds an Image Tag
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        public HtmlBuilder Img(object attributes = null)
        {
            FlushAttributes();

            return new HtmlBuilder("img", sb, attributes);
        }

        /// <summary>
        /// Builds an Italic Tag
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        public HtmlBuilder I(object attributes = null)
        {
            FlushAttributes();

            return new HtmlBuilder("i", sb, attributes);
        }

        /// <summary>
        /// Builds a custom Tag
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        public HtmlBuilder Custom(string name, object attributes = null)
        {
            FlushAttributes();

            return new HtmlBuilder(name, sb, attributes);
        }

        #endregion

        /// <summary>
        /// Closes this instances tag
        /// </summary>
        public void Dispose()
        {
            if (!flushed)
            {
                FlushAttributes();
            }

            sb.Append("</");
            sb.Append(tag);
            sb.Append(">");
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return sb.ToString();
        }
    }
}

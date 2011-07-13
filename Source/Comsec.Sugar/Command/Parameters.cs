using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comsec.Sugar.Command
{
    /// <summary>
    /// Class to represent the applications command line parameters.
    /// </summary>
    public class Parameters : List<Parameter>, ICloneable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Parameters"/> class.
        /// </summary>
        public Parameters()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Parameters"/> class.
        /// </summary>
        /// <param name="args">The args.</param>
        public Parameters(string args)
        {
            if (string.IsNullOrEmpty(args)) return;

            var array = args.Split(' ');

            AddRange(ParameterParser.Parse(array));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Parameters"/> class.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        public Parameters(IEnumerable<Parameter> parameters)
        {
            foreach (var parameter in parameters)
            {
                Add(parameter);
            }
        }

        /// <summary>
        /// Returns a parameter as a string value
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public string AsString(string name)
        {
            var result = (from a in this
                          where a.Name == name
                          select a.Value).FirstOrDefault();

            return result;
        }

        /// <summary>
        /// Returns a parameter as a string value
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="default">The @default value.</param>
        /// <returns></returns>
        public string AsString(string name, string @default)
        {
            var result = (from a in this
                          where a.Name == name
                          select a.Value).FirstOrDefault();

            if (string.IsNullOrEmpty(result)) result = @default;

            return result;
        }

        /// <summary>
        /// Returns a parameter as an integer value
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public int AsInteger(string name)
        {
            return AsInteger(name, 0);
        }

        /// <summary>
        /// Returns a parameter as an integer value
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="default">The @default value.</param>
        /// <returns></returns>
        public int AsInteger(string name, int @default)
        {
            int result;

            var resultAsString = AsString(name);

            if (!int.TryParse(resultAsString, out result))
            {
                result = @default;
            }

            return result;
        }

        /// <summary>
        /// Returns a parameter as an integer value
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public DateTime AsDateTime(string name)
        {
            return AsDateTime(name, DateTime.Now);
        }

        /// <summary>
        /// Returns a parameter as an integer value
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="default">The @default value.</param>
        /// <returns></returns>
        public DateTime AsDateTime(string name, DateTime @default)
        {
            DateTime result;

            var resultAsString = AsString(name);

            if (!DateTime.TryParse(resultAsString, out result))
            {
                result = @default;
            }

            return result;
        }

        /// <summary>
        /// Determines whether the specified name contains argument.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>
        /// 	<c>true</c> if the specified name contains argument; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(string name)
        {
            var count = (from a in this
                         where a.Name == name
                         select a.Value).Count();

            return count > 0;
        }

        public bool Contains(string key, string value)
        {
            return (from   a 
                    in     this
                    where  a.Name == key && 
                           a.Value == value
                    select a).Any();
        }


        /// <summary>
        /// Ases the bool.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="default">if set to <c>true</c> [@default].</param>
        /// <returns></returns>
        public bool AsBool(string name, bool @default)
        {
            bool result;

            var resultAsString = AsString(name, "false");

            if (!bool.TryParse(resultAsString, out result))
            {
                result = @default;
            }

            return result;
        }

        /// <summary>
        /// Adds the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        public void Add(string name)
        {
            Add(name, null);
        }

        /// <summary>
        /// Adds the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public void Add(string name, string value)
        {
            Add(new Parameter { Name = name, Value = value });
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new Parameters(this);
        }

        public void Remove(string name)
        {
            for (var i = Count - 1; i >= 0; i--)
            {
                if (string.Compare(this[i].Name, name, true) == 0)
                {
                    RemoveAt(i);
                }
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var parameter in this)
            {
                if (sb.Length > 0) sb.Append(" ");

                sb.Append(parameter.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Replaces the value of the parameter with the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Replace(string key, string value)
        {
            Remove(key);
            Add(key, value);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Sugar
{
    public static class ObjectExtensions
    {
        public static string ToDump(this object @object, int depth = 1, bool enumerate = true)
        {
            var sb = new StringBuilder();

            sb.AppendLine("{");

            try
            {
                if (@object.GetType().IsPrimitive || @object is string)
                {
                    sb.Append("  ");
                    sb.Append(@object.GetType().Name);
                    sb.AppendFormat(@": ""{0}""", @object);
                    sb.AppendLine(string.Empty);
                }
                else
                {
                    ToDump(@object, 1, sb, enumerate: enumerate);

                    sb.AppendLine(string.Empty);
                }
            }
            catch (Exception)
            {
                sb.AppendLine(string.Empty);
                sb.AppendLine("(errors occured during dumping)");
                sb.AppendLine(string.Empty);
            }

            sb.AppendLine("}");

            return sb.ToString();
        }

        private static void ToDump(object @object, int depth, StringBuilder sb, string name = null, bool enumerate = true)
        {
            // Prevent too much recursion
            if (depth > 4) return;

            if (string.IsNullOrWhiteSpace(name))
            {
                name = @object.GetType().Name;
            }
            else
            {
                name = string.Format(@"""{0}""", name);
            }

            sb.Append(" ".Repeat(2 * depth));
            sb.Append(name);

            if (@object != null)
            {
                if (@object is IEnumerable)
                {
                    var enumerable = @object as IEnumerable;

                    if (enumerate)
                    {
                        sb.AppendLine(": [");

                        var first = true;

                        foreach (var element in enumerable)
                        {
                            if (!first)
                            {
                                sb.AppendLine(",");

                            }
                            first = false;

                            if (element != null)
                            {
                                ToDump(element, depth + 1, sb);
                            }
                            else
                            {
                                sb.Append(" ".Repeat(2*(depth + 1)));
                                sb.Append("null");
                            }
                        }

                        sb.AppendLine(string.Empty);
                        sb.Append(" ".Repeat(2*depth));
                        sb.Append("]");
                    }
                    else
                    {
                        sb.Append(": [ ");
                        sb.Append(@object.GetType().ToGenericFullName());
                        sb.Append(" ]");
                    }
                }
                else
                {
                    sb.AppendLine(": {");

                    var properties = @object.GetType().GetProperties();

                    for (var i = 0; i < properties.Length; i++)
                    {
                        var property = @object.GetType().GetProperties()[i];

                        object value;

                        var error = false;

                        try
                        {
                            value = property.GetValue(@object, null);
                        }
                        catch (Exception)
                        {
                            value = "?";

                            error = true;
                        }

                        if (error)
                        {
                            sb.Append(" ".Repeat(2 * (depth + 1)));
                            sb.AppendFormat(@"""{0}"": err", property.Name);
                        }
                        else if (property.PropertyType.IsPrimitive)
                        {
                            sb.Append(" ".Repeat(2 * (depth + 1)));
                            sb.AppendFormat(@"""{0}"": ""{1}""", property.Name, value);
                        }
                        else if (property.PropertyType == typeof(DateTime))
                        {
                            sb.Append(" ".Repeat(2 * (depth + 1)));
                            sb.AppendFormat(@"""{0}"": ""{1:yyyy-MM-dd hh:mm:ss}""", property.Name, value);
                        }
                        else if ((!property.PropertyType.IsClass && !property.PropertyType.IsInterface) || property.PropertyType == typeof(string))
                        {
                            if (value == null)
                            {
                                sb.Append(" ".Repeat(2 * (depth + 1)));
                                sb.AppendFormat(@"""{0}"": null", property.Name);
                            }
                            else
                            {
                                sb.Append(" ".Repeat(2 * (depth + 1)));
                                sb.AppendFormat(@"""{0}"": ""{1}""", property.Name, value);
                            }
                        }
                        else
                        {
                            ToDump(value, depth + 1, sb, property.Name, enumerate);
                        }

                        if (i < properties.Length - 1 && properties.Length > 1)
                        {
                            sb.AppendLine(",");
                        }
                        else
                        {
                            sb.AppendLine(string.Empty);
                        }
                    }
                    sb.Append(" ".Repeat(2 * depth));
                    sb.Append("}");
                }
            }
            else
            {
                sb.Append(": null");
            }
        }
    }
}

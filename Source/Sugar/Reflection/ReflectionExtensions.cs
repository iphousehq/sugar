using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Sugar.Reflection
{
    /// <summary>
    /// Extension methods to allow setting and getting of private fields easier.
    /// </summary>
    public static class ReflectionExtensions
    {
        public static Member ToMember<TMapping, TReturn>(this Expression<Func<TMapping, TReturn>> propertyExpression)
        {
            return ReflectionHelper.GetMember(propertyExpression);
        }

        /// <summary>
        /// Gets the value of a private field.
        /// </summary>
        /// <remarks>
        /// The field must be private, not a property.
        /// </remarks>
        /// <typeparam name="TSource">The type of the object that the field belongs to.</typeparam>
        /// <typeparam name="TField">The type of the field.</typeparam>
        /// <param name="source">The source object to get the value from.</param>
        /// <param name="name">The name of the field.</param>
        /// <returns></returns>
        public static TField GetValueOf<TSource, TField>(this TSource source, string name)
        {
            var param = Expression.Parameter(typeof(TSource), "arg");
            var member = Expression.Field(param, name);
            var lambda = Expression.Lambda(typeof(Func<TSource, TField>), member, param);

            var compiled = (Func<TSource, TField>)lambda.Compile();
            return compiled(source);
        }

        /// <summary>
        /// Sets the value of a private field.
        /// </summary>
        /// <typeparam name="TSource">The type of the object that the field belongs to.</typeparam>
        /// <typeparam name="TField">The type of the field.</typeparam>
        /// <param name="source">The source object to get the value from.</param>
        /// <param name="name">The name of the field.</param>
        /// <param name="value">The value to set the field to.</param>
        /// <remarks>
        /// The field must be private, it will not set private property.
        /// </remarks>
        public static void SetValueOf<TSource, TField>(this TSource source, string name, object value)
        {
            var param1 = Expression.Parameter(typeof(TSource), "arg1");
            var param2 = Expression.Parameter(typeof(object), "arg2");
            var left = Expression.Field(param1, name);
            var right = Expression.Constant(value);
            var member = Expression.Assign(left, right);
            var lambda = Expression.Lambda(typeof(Func<TSource, object, TField>), member, param1, param2);

            var compiled = (Func<TSource, object, TField>)lambda.Compile();
            compiled(source, value);
        }

        /// <summary>
        /// Sets the protected property on a instance of an object to a specified value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The obj.</param>
        /// <param name="propName">Name of the prop.</param>
        /// <param name="val">The val.</param>
        public static void SetProtectedPropertyValue<T>(this object obj, string propName, T val)
        {
            const BindingFlags mask = BindingFlags.Public |
                                      BindingFlags.NonPublic |
                                      BindingFlags.SetProperty |
                                      BindingFlags.Instance |
                                      BindingFlags.FlattenHierarchy;

            PropertyInfo propertyInfo = null;

            var t = obj.GetType();

            while (propertyInfo == null && t != null)
            {
                propertyInfo = t.GetProperty(propName, mask);

                t = t.BaseType;
            }

            if (propertyInfo == null) throw new ArgumentOutOfRangeException("propName", string.Format("Field {0} was not found in Type {1}", propName, obj.GetType().FullName));

            propertyInfo.SetValue(obj, val, null);
        }
    }
}
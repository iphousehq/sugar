using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Sugar.Reflection
{
    public class PropertyChain : Accessor
    {
        private readonly Member[] chain;
        private readonly SingleMember innerMember;

        public PropertyChain(Member[] members)
        {
            chain = new Member[members.Length - 1];
            for (int i = 0; i < chain.Length; i++)
            {
                chain[i] = members[i];
            }

            innerMember = new SingleMember(members[members.Length - 1]);
        }

        #region Accessor Members

        public void SetValue(object target, object propertyValue)
        {
            target = FindInnerMostTarget(target);
            if (target == null)
            {
                return;
            }

            innerMember.SetValue(target, propertyValue);
        }

        public object GetValue(object target)
        {
            target = FindInnerMostTarget(target);

            if (target == null)
            {
                return null;
            }

            return innerMember.GetValue(target);
        }

        public string FieldName
        {
            get { return innerMember.FieldName; }
        }

        public Type PropertyType
        {
            get { return innerMember.PropertyType; }
        }

        public Member InnerMember
        {
            get { return innerMember.InnerMember; }
        }

        public Accessor GetChildAccessor<T>(Expression<Func<T, object>> expression)
        {
            var member = expression.ToMember();
            var list = new List<Member>(chain);
            list.Add(innerMember.InnerMember);
            list.Add(member);

            return new PropertyChain(list.ToArray());
        }

        public string Name
        {
            get
            {
                string returnValue = string.Empty;
                foreach (var info in chain)
                {
                    returnValue += info.Name + ".";
                }

                returnValue += innerMember.Name;

                return returnValue;
            }
        }

        #endregion

        private object FindInnerMostTarget(object target)
        {
            foreach (var info in chain)
            {
                target = info.GetValue(target);
                if (target == null)
                {
                    return null;
                }
            }

            return target;
        }
    }
}
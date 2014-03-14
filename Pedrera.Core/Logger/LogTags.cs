using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Pedrera.Core.Logger
{
    public class LogTags : ICollection<KeyValuePair<object, object>>, IEnumerable<KeyValuePair<object, object>>, IEnumerable
    {
        private readonly Dictionary<object, object> items;

        public object this[object key]
        {
            get
            {
                return this.items[key];
            }
            set
            {
                this.items[key] = value;
            }
        }

        public int Count
        {
            get
            {
                return this.items.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public LogTags(IEnumerable<KeyValuePair<object, object>> items)
        {
            this.items = Enumerable.ToDictionary<KeyValuePair<object, object>, object, object>(items, (Func<KeyValuePair<object, object>, object>)(x => x.Key), (Func<KeyValuePair<object, object>, object>)(x => x.Value));
        }

        public LogTags()
        {
            this.items = new Dictionary<object, object>();
        }

        public static implicit operator LogTags(KeyValuePair<object, object>[] items)
        {
            return new LogTags((IEnumerable<KeyValuePair<object, object>>)items);
        }

        public IEnumerator<KeyValuePair<object, object>> GetEnumerator()
        {
            return (IEnumerator<KeyValuePair<object, object>>)this.items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)this.GetEnumerator();
        }

        public void Add(KeyValuePair<object, object> item)
        {
            this.items.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            this.items.Clear();
        }

        public bool Contains(KeyValuePair<object, object> item)
        {
            return Enumerable.Contains<KeyValuePair<object, object>>((IEnumerable<KeyValuePair<object, object>>)this.items, item);
        }

        public void CopyTo(KeyValuePair<object, object>[] array, int arrayIndex)
        {
            Enumerable.ToList<KeyValuePair<object, object>>((IEnumerable<KeyValuePair<object, object>>)this.items).CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<object, object> item)
        {
            return this.items.Remove((object)item);
        }
    }
}

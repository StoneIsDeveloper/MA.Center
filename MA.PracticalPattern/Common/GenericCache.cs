using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MA.PracticalPattern.Common
{
    public class GenericCache<TKey, TValue>
    {
        #region Fileds
        // 内部的 Dictionary 容器
        private Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();

        // 用于并发同步访问的锁对象
        private ReaderWriterLock rwLock = new ReaderWriterLock();

        // 用于指定超时时间
        private readonly TimeSpan lockTimeOut = TimeSpan.FromMilliseconds(100);
        #endregion

        #region Methods
        public void Add(TKey key,TValue value)
        {
            bool isExisting = false;
            rwLock.AcquireWriterLock(lockTimeOut);
            try
            {
                if (!dictionary.ContainsKey(key))
                {
                    dictionary.Add(key, value);
                }
                else
                {
                    isExisting = true;
                }
            }
            finally
            {
                rwLock.ReleaseWriterLock();
            }

            if (isExisting)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            rwLock.AcquireReaderLock(lockTimeOut);
            bool result;
            try
            {
                result = dictionary.TryGetValue(key, out value);
            }
            finally
            {
                rwLock.ReleaseReaderLock();
            }

            return result; 

        }

        public void Clear()
        {
            if(dictionary.Count >0)
            {
                rwLock.AcquireWriterLock(lockTimeOut);
                try
                {
                    dictionary.Clear();
                }
                finally
                {
                    rwLock.ReleaseWriterLock();
                }
            }
        }

        public bool ContainsKey(TKey key)
        {
            if(dictionary.Count <= 0)
            {
                return false;
            }
            bool result;
            rwLock.AcquireReaderLock(lockTimeOut);
            try
            {
                result = dictionary.ContainsKey(key);
            }
            finally
            {
                rwLock.ReleaseReaderLock();
            }
            return result;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Dictinary中键值对的数目
        /// </summary>
        public int Count { get { return dictionary.Count; } }
        #endregion



    }
}

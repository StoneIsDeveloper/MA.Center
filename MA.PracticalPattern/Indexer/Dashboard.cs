using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.PracticalPattern.Indexer
{
    public class Dashboard
    {
        float[] temps = new float[10] { 22.0F, 22.4F, 12.0F, 52.0F, 62.0F, 72.0F, 82.0F, 92.0F, 12.0F, 42.0F };

        /// <summary>
        /// 索引器 ，传入检索规则
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public float this[Predicate<float> predicate]
        {
            get
            {
                float[] matches = Array.FindAll<float>(temps, predicate);
                return matches[0];
            }
        }

    }
}

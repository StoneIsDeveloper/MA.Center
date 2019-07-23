using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.PracticalPattern
{
    public interface IOrganization { }

    /// <summary>
    /// 参数类型约束
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TOrganization"></typeparam>
    public abstract class UserBase<TKey, TOrganization> where TOrganization :class,IOrganization,new()
    {
        public abstract TOrganization Organization { get; }

        public abstract void Prometion(TOrganization organization);

        delegate TOrganization OrganizationHandler();

    }
}

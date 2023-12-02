using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CQIE.LOG.DBManager
{
    public interface IDbManager
    {
        /// <summary>
        /// Dbcontext上下文
        /// </summary>
        public CQIE.LOG.DBManager.LOGDbContext Ctx { get; }
        public bool Save<T>(T entity, Expression<Func<T, bool>> predicate = null) where T : class;
    }
}

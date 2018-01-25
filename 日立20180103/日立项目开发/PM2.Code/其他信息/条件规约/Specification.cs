using Gmail.DDD.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Code.Specification
{
    public abstract class Specification : ISpecification
    {
        #region 窗体参数
        private IRequestGetter _rGetter;
        protected IRequestGetter IRequestGetter { get { return this._rGetter; } }
        #endregion
        #region 查询参数
        private ICollection<DbParameter> _parameters;
        public IEnumerable<DbParameter> DbParameters
        {
            set { this._parameters = (ICollection<DbParameter>)value; }
            get { return this._parameters; }
        }
        #endregion
        public Specification(IRequestGetter rGetter)
        {
            this._rGetter = rGetter;
        }

        private string _sWhere;
        public string Where
        {
            set { this._sWhere = value; }
            get {
                if (this._sWhere == null)
                    this._sWhere = this.Bordy(out this._parameters);
                return this._sWhere; 
            }
        }

        #region &|
        public static Specification operator &(Specification leftSideSpecification, Specification rightSideSpecification)
        {
            string where = string.Format("({0}) and ({1})", leftSideSpecification.Where, rightSideSpecification.Where);
            leftSideSpecification.Where = where;
            leftSideSpecification.DbParameters = leftSideSpecification.DbParameters.Union(rightSideSpecification.DbParameters);
            return leftSideSpecification;
        }
        public static Specification operator |(Specification leftSideSpecification, Specification rightSideSpecification)
        {
            string where = string.Format("({0}) or ({1})", leftSideSpecification.Where, rightSideSpecification.Where);
            leftSideSpecification.Where = where;
            leftSideSpecification.DbParameters = leftSideSpecification.DbParameters.Union(rightSideSpecification.DbParameters);
            return leftSideSpecification;
        }
        #endregion

        /// <summary>
        /// 查询主体
        /// </summary>
        /// <param name="_parameters"></param>
        /// <returns></returns>
        protected abstract string Bordy(out ICollection<DbParameter> _parameters);

    }
}

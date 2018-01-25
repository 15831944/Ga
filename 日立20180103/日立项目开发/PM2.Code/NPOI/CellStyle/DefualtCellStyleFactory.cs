using Gmail.DDD.Utility;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gmail.DDD.Extensions;

namespace PM2.Code.NPOI
{
    
    /// <summary>
    /// 默认ICellStyle-样式工厂
    /// </summary>
    public sealed class DefualtCellStyleFactory : ICellStyleFactory
    {
        private readonly Dictionary<CellStyleEnum, ICellStyle> _pool;
        public DefualtCellStyleFactory(IComponent<WorkbookAdapter> wAdapter, CellStyleContext context)
        {
            this._pool = new Dictionary<CellStyleEnum, ICellStyle>();
            this._pool.AddRange(this.Initialize(wAdapter, context));
        }
        #region 初始化
        private IEnumerable<KeyValuePair<CellStyleEnum, ICellStyle>> Initialize(IComponent<WorkbookAdapter> wAdapter, CellStyleContext context)
        {
            yield return new KeyValuePair<CellStyleEnum, ICellStyle>(CellStyleEnum.String_Left, new String_LeftCellStyle().Create(wAdapter,context));
            yield return new KeyValuePair<CellStyleEnum, ICellStyle>(CellStyleEnum.String_Center, new String_CenterStyle().Create(wAdapter, context));
            yield return new KeyValuePair<CellStyleEnum, ICellStyle>(CellStyleEnum.String_Right, new String_RightStyle().Create(wAdapter, context));

            yield return new KeyValuePair<CellStyleEnum, ICellStyle>(CellStyleEnum.Date_Center, new Date_CenterCellStyle().Create(wAdapter, context));
            yield return new KeyValuePair<CellStyleEnum, ICellStyle>(CellStyleEnum.Date_Left, new Date_LeftCellStyle().Create(wAdapter, context));
            yield return new KeyValuePair<CellStyleEnum, ICellStyle>(CellStyleEnum.Int_Center, new Int_CenterCellStyle().Create(wAdapter, context));
            yield return new KeyValuePair<CellStyleEnum, ICellStyle>(CellStyleEnum.Int_Right, new Int_RightCellStyle().Create(wAdapter, context));

            yield return new KeyValuePair<CellStyleEnum, ICellStyle>(CellStyleEnum.Round2_Right, new Round2_RightCellStyle().Create(wAdapter, context));
            yield return new KeyValuePair<CellStyleEnum, ICellStyle>(CellStyleEnum.Round4_Right, new Round4_RightCellStyle().Create(wAdapter, context));
            yield return new KeyValuePair<CellStyleEnum, ICellStyle>(CellStyleEnum.Percentage_Right, new Percentage_RightCellStyle().Create(wAdapter, context));
            yield return new KeyValuePair<CellStyleEnum, ICellStyle>(CellStyleEnum.Double_None, new Double_NoneCellStyle().Create(wAdapter, context));
        }
        #endregion

        public ICellStyle Create(CellStyleEnum cType)
        {
            ICellStyle style = null;
            if (this._pool.TryGetValue(cType, out style))
            { }
            return style;

        }
    }
    

}

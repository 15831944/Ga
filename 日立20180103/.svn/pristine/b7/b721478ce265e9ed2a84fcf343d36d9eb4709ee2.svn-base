using Gmail.DDD.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Code.NPOI
{
    public class ExeclExporCommand: IExportDataCommand
    {
        private Autofac.Features.Indexed.IIndex<Auto_ExportHeaderCommand, IExportHeaderCommand> _hCommands;
        private Autofac.Features.Indexed.IIndex<Auto_ExportDataCommand, IExportDataCommand> _rCommands;
        public ExeclExporCommand(
            Autofac.Features.Indexed.IIndex<Auto_ExportHeaderCommand, IExportHeaderCommand> hCommands,
            Autofac.Features.Indexed.IIndex<Auto_ExportDataCommand, IExportDataCommand> rCommands
        )
        {
            this._hCommands = hCommands;
            this._rCommands = rCommands; 
        }

        /// <summary>
        /// 导出成功
        /// </summary>
        public event EventHandler<ExportContext> SuccessEvent;

        #region IExcelExport
        public void Execute<TModel>(IExcelUnitWork unit, ExportContext context, IEnumerable<TModel> source) 
            where TModel : IEntity
        {
            //表头
            Tuple<IExportHeaderCommand, IEnumerable<ExcelAttribute>> tuple = this.GetExportHeaderCommand(typeof(TModel));
            IExportHeaderCommand hCommand = tuple.Item1;
            hCommand.SuccessEvent += (sender, e) => { 
                #region 内容体
		        IExportDataCommand rCommand = this._rCommands[Auto_ExportDataCommand.ExportDataCommand];
                rCommand.SuccessEvent += this._SuccessEvent;
                rCommand.Execute<TModel>(unit, e, source);
	            #endregion
            };
            hCommand.Execute(unit, context, tuple.Item2);
        }
        private void _SuccessEvent(object sender, ExportContext e)
        {
            if (this.SuccessEvent != null)
                this.SuccessEvent.Invoke(this, e);
        }
        #endregion
        #region [导出-表头]根据模型获取-IExportHeaderCommand
        private Tuple<IExportHeaderCommand, IEnumerable<ExcelAttribute>> GetExportHeaderCommand(Type modelType)
        {
            //获取模型[表头集合]特性
            IEnumerable<ExcelAttribute> attributes = ExcelHelper.GetAttributes(modelType).Where(x => x.Operation == Operation.All || x.Operation == Operation.Export);
            IExportHeaderCommand command = null;
            //情况A: Excel存在三层表头[HraderGroupEnum.One]
            if (attributes.Any(x => x.HraderGroup == HraderGroupEnum.One))
                command = this._hCommands[Auto_ExportHeaderCommand.OneHeardCommand];
            //情况B: Excel存在二层表头[HraderGroupEnum.Two]
            else if (attributes.Where(x => x.HraderGroup != HraderGroupEnum.One).Any(x => x.HraderGroup == HraderGroupEnum.Two))
                command = this._hCommands[Auto_ExportHeaderCommand.TwoHeardCommand];
            //情况C: Excel只存在一层表头[HraderGroupEnum.Three]
            else
                command = this._hCommands[Auto_ExportHeaderCommand.ThreeHeardCommand];
            return new Tuple<IExportHeaderCommand, IEnumerable<ExcelAttribute>>(command, attributes);
        }
        #endregion

    }
}

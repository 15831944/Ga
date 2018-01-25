using Gmail.DDD.DataContext;
using Gmail.DDD.DBContextScope;
using Gmail.DDD.Entity;
using Gmail.DDD.IOC;
using Gmail.DDD.Repositorys;
using Gmail.DDD.Repositorys.SQLBuilding;
using Gmail.DDD.Utility;
using PM2.Code.NPOI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Code
{
    public class CodeModuleManager : ModuleManager
    {
        public override void Load()
        {
            #region Easy - 控件生成器 - Input系列控件
            this.RegisterType<EasyInputBuilder, IHtmlBuilder>(serviceName: Auto_ControlType.EasyInputBuilder);
            this.RegisterType<Easy_Textbox, IEasyInputState>(serviceName: Auto_EasyInputState.Easy_Textbox);
            this.RegisterType<Easy_Passwordbox, IEasyInputState>(serviceName: Auto_EasyInputState.Easy_Passwordbox);
            this.RegisterType<Easy_Numberbox_Int32, IEasyInputState>(serviceName: Auto_EasyInputState.Easy_Numberbox_Int32);
            this.RegisterType<Easy_Numberbox_Decimal, IEasyInputState>(serviceName: Auto_EasyInputState.Easy_Numberbox_Decimal);
            this.RegisterType<Easy_Datebox, IEasyInputState>(serviceName: Auto_EasyInputState.Easy_Datebox);
            this.RegisterType<Easy_Combobox, IEasyInputState>(serviceName: Auto_EasyInputState.Easy_Combobox);
            this.RegisterType<Easy_Switchbutton, IEasyInputState>(serviceName: Auto_EasyInputState.Easy_Switchbutton);
            #endregion
            //Enum - 控件生成器
            this.RegisterType<EnumHtmlBuilde, IHtmlBuilder>(serviceName: Auto_ControlType.EnumHtmlBuilde);
            
            #region Excel - 操作
            this.RegisterType<ExcelUnitWorkFactory, IExcelUnitWorkFactory>();
            this.RegisterType<ThreeHeardCommand, IExportHeaderCommand>(serviceName: Auto_ExportHeaderCommand.ThreeHeardCommand);
            this.RegisterType<TwoHeardCommand, IExportHeaderCommand>(serviceName: Auto_ExportHeaderCommand.TwoHeardCommand);
            this.RegisterType<OneHeardCommand, IExportHeaderCommand>(serviceName: Auto_ExportHeaderCommand.OneHeardCommand);

            this.RegisterType<ExportDataCommand, IExportDataCommand>(serviceName: Auto_ExportDataCommand.ExportDataCommand);
            this.RegisterType<ExeclExporCommand, IExportDataCommand>(serviceName: Auto_ExportDataCommand.ExeclExporCommand);

            this.RegisterType<EImportDataCommand, ImportDataCommand>();
            #endregion
            
        }
    }
}

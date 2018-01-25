using Gmail.DDD.Entity;
using Gmail.DDD.IOC;
using Gmail.DDD.Service;
using PM2.Models.Code100;

namespace PM2.Service.Code031
{
    public class Code031ModuleManager : ModuleManager
    {
        public override void Load()
        {
            #region szrl125.合同支付情况
            this.RegisterType<szrl125ServeAsync, Iszrl125ServerAsync>();
            this.RegisterType<szrl125ServeHelper, Iszrl125ServeHelper>();
            this.RegisterType<szrl126PlanLoadAsync, Iszrl126LoadAsync>(serviceName: Auto_Iszrl126LoadAsync.szrl126PlanLoadAsync);
            this.RegisterType<szrl126ConfirmLoadAsync, Iszrl126LoadAsync>(serviceName: Auto_Iszrl126LoadAsync.szrl126ConfirmLoadAsync);

            this.RegisterType<AdvancePaymentAsync, IPaymentCommandAsync>(serviceName: Auto_IPaymentCommandAsync.AdvancePaymentAsync);
            this.RegisterType<AdjustPaymentAsync, IPaymentCommandAsync>(serviceName: Auto_IPaymentCommandAsync.AdjustPaymentAsync);
            this.RegisterType<IntoPaymentAsync, IPaymentCommandAsync>(serviceName: Auto_IPaymentCommandAsync.IntoPaymentAsync);
            this.RegisterType<RestorePaymentAsync, IPaymentCommandAsync>(serviceName: Auto_IPaymentCommandAsync.RestorePaymentAsync);

            this.RegisterType<szrl105TreeExtensions, IEasyTreeExtensions>(serviceName: Auto_TreeType.szrl105Tree);
            #endregion
        }
        
    }
}

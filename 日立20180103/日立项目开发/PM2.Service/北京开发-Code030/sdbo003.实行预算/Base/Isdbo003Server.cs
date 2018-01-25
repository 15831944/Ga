using Gmail.DDD.Mvc;
using Gmail.DDD.PagedList;
using Gmail.DDD.Service;
using PM2.Models.Code030;
using PM2.Models.Code030.szrl111Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace PM2.Service.Code030
{
    public interface Isdbo003Server : IService
    {
        #region =================================表纸=================================
        /// <summary>
        /// 查询实行预算信息
        /// </summary>
        /// <param name="vParams"></param>
        /// <returns></returns>
        IOperateResult GetImplementBudgetInfo(IRequestGetter vParams);
        /// <summary>
        /// 保存实行预算方法
        /// </summary>
        /// <param name="context">万能接收器</param>
        /// <param name="_szrl082"></param>
        /// <returns></returns>
        IOperateResult Add(IRequestGetter context, szrl082 _szrl082);
        /// <summary>
        /// 变更时显示最新传票数据
        /// </summary>
        /// <param name="vParams"></param>
        /// <returns></returns>
        Dictionary<string, string> Get_partial(IRequestGetter vParams);
        #endregion
        #region =================================KLBDE模块=================================
        /// <summary>
        /// 显示KLBDE表格信息
        /// </summary>
        /// <param name="vParams"></param>
        /// <returns></returns>
        IOperateResult GetKLBDEInfo(IRequestGetter vParams);

        //IOperateResult GetSzrl11Info(IPageContext context);
        /// <summary>
        /// KLBDE模块点击添加时,显示材料编码网格信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        IOperateResult GetSzrl11Info(IPageContext context);
        //IOperateResult SaveVoucher_083(List<szrl083> vParams);
        //IOperateResult SaveVoucher_084(List<szrl084> vParams);
        /// <summary>
        /// 查询材料库一级目录下拉框
        /// </summary>
        /// <returns></returns>
        IEnumerable<szrl112> LevelMenu();
        /// <summary>
        /// 根据一级目录查询二级目录集合
        /// </summary>
        /// <param name="_levelmenu"></param>
        /// <returns></returns>
        IEnumerable<szrl112> LevelMenu2(string _levelmenu);
        /// <summary>
        /// 删除KLBDE模块明细
        /// </summary>
        /// <param name="szrl083"></param>
        /// <returns></returns>
        IOperateResult DeleteVoucher_083(KLBDE szrl083);
        /// <summary>
        /// klbde导入
        /// </summary>
        /// <param name="excel">klbde导入类</param>
        /// <returns></returns>
        IOperateResult ImportDataByExcel(MaterialExcel_klbde excel);
        #endregion
        #region =================================A~J模块=================================

        /// <summary>
        /// AJ目录菜单,用于实行预算明细勾选
        /// </summary>
        /// <returns></returns>
        IEnumerable<szrl112> AjMenu();



        /// <summary>
        /// 查看A~J表格
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        IOperateResult GetajInfo(IRequestGetter context);

        /// <summary>
        /// 删除A~J模块明细
        /// </summary>
        /// <param name="szrl084"></param>
        /// <returns></returns>
        IOperateResult DeleteVoucher_084(AJ szrl084);

        /// <summary>
        /// A~J导入
        /// </summary>
        /// <param name="excel">A~J导入</param>
        /// <returns></returns>
        IOperateResult ImportDataByExcel2(MaterialExcel_aj excel);
        #endregion
        #region ===============================特记事项===============================
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        IOperateResult SpecialNotes(IRequestGetter context);
        /// <summary>
        /// 添加修改
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        IOperateResult SpecialNotes_Add(IRequestGetter context);
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        IOperateResult SpecialNotes_Del(IRequestGetter context);
        /// <summary>
        /// 删除所有在前端删除的明细
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        IOperateResult ux_del(IRequestGetter context);
        /// <summary>
        /// 实行预算承认
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        IOperateResult Recognize(IRequestGetter context);
        /// <summary>
        /// 实行预算删除
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        IOperateResult Remove(IRequestGetter context);
        /// <summary>
        /// 获取版本号
        /// </summary>
        /// <returns></returns>
        List<szrl082> VersioNnumber(IRequestGetter context);
        /// <summary>
        /// 用于审核时保存计划进度
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        IOperateResult btn_saveSzrl085(HttpCollection context);
        #endregion
        #region 与前一版本对比
        IOperateResult GetpvcnbInfo(IRequestGetter vParams);
        IOperateResult GetSzrl019Info(IPageContext context);
        #endregion
    }
}

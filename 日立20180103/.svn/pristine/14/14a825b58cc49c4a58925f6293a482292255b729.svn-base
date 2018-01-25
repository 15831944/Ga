using Newtonsoft.Json;
using PM2.Service.Code030.Szrl105Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Models.Code030
{
    /// <summary>
    /// 表单状态
    /// </summary>
    public class Szrl100FormStateService
    {
        /// <summary>
        /// 新增中
        /// </summary>
        public const int STATE_NEW = 1;

        /// <summary>
        /// 保存完成
        /// </summary>
        public const int STATE_SAVED = 2;

        /// <summary>
        /// 已承认
        /// </summary>
        public const int STATE_ADMITED = 3;

        /// <summary>
        /// 已承认的旧版本
        /// </summary>
        public const int STATE_ADMITED_OLD = 4;


        public bool IsDiabledForm { get; set; }

        /// <summary>
        /// 是否是审核用户
        /// </summary>
        public static bool IsAdmitUser
        {
            get
            {
                return GlobalService.GetLoginUserId().Equals("1003"); 
            }
        }

        /// <summary>
        /// 当前表单状态
        /// </summary>
        public int CurrentState { get; set; }


        public string GetForbidInfo()
        {
            StateAction action = new StateAction();
            action.State = CurrentState;
            switch (CurrentState)
            {
                case STATE_NEW:
                    action.ForbidBtnIds.AddRange(new string[] { "btnUpdate", "btnAdmit", "btnRemove", "btnUpdateFinance", "rl10041", "rl10004", "rl10034" });
                    break;
                case STATE_SAVED:
                    action.ForbidBtnIds.AddRange(new string[] { "btnUpdate" });
                    break;
                case STATE_ADMITED:
                    action.DisabledForm = true;
                    action.ForbidBtnIds.AddRange(new string[] { "btnAdmit", "btnRemove", "btnSave", "btnUpdateFinance" });
                    break;
                case STATE_ADMITED_OLD:
                    action.DisabledForm = true;
                    action.ForbidBtnIds.AddRange(new string[] { "btnUpdate", "btnAdmit", "btnRemove", "btnSave", "btnUpdateFinance" });
                    break;
            }

            var items = new string[] { "rl10041", "rl10004", "rl10034" };
            foreach (var item in items)
            {
                if (!action.ForbidBtnIds.Contains(item))
                {
                    action.ForbidBtnIds.Add(item);
                }
            }

            // 没有财务权限
            if (!IsFinanceFlag)
            {
                action.ForbidBtnIds.Add("btnUpdateFinance");
            }
            else
            {
                action.ForbidBtnIds.Remove("btnUpdateFinance");
                action.ForbidBtnIds.Remove("btnSave");
            }
            /// 财务权限且未完成审核的
            //if (IsFinanceFlag && !IsAdmited(CurrentState))
            //{
            //    items = new string[] { "btnUpdateFinance" };
            //    foreach (var item in items)
            //    {
            //        if (action.ForbidBtnIds.Contains(item))
            //        {
            //            action.ForbidBtnIds.Remove(item);
            //        }
            //    }
            //}

            if (!IsAdmitUser && !action.ForbidBtnIds.Contains("btnAdmit"))
            {
                action.ForbidBtnIds.Add("btnAdmit");
            }
            
            IsDiabledForm = action.DisabledForm;
            return JsonConvert.SerializeObject(action);
        }

        /// <summary>
        /// 是否已完成审核
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        private bool IsAdmited(int state)
        {
            return state == STATE_ADMITED || state == STATE_ADMITED_OLD;
        }

        private static bool _isFinanceFlag = false;
        /// <summary>
        /// 是否是财务权限
        /// </summary>
        public static bool IsFinanceFlag
        {
            get
            {
                return GlobalService.GetLoginUserId().Equals("1002");
            }
        }




        class StateAction
        {
            public int State { get; set; }

            /// <summary>
            /// 禁用表单
            /// </summary>
            public bool DisabledForm { get; set; }

            public List<string> ForbidBtnIds { get; set; }

            public StateAction()
            {
                ForbidBtnIds = new List<string>();
            }
        }

        class ActionController
        {
            public string Id { get; set; }

            public string Type { get; set; }
        }
    }
}

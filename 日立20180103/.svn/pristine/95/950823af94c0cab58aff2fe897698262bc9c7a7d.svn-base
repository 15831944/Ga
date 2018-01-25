
(function () {

    //#region Index_Tree: 合同Tree
    var Index_Tree = (function () {

        var _tree; 
        var _rl12502 = '-1';
        var me = {
        };

        var Initialize = function (parameters) {
            if (parameters)
                $.extend(me, parameters);

            _tree = $('#index_Tree');
            _tree.tree({
                url: '/AreasCode031/szrl105Tree/TreeLoad',
                animate: true,
                onBeforeLoad: function (node, param) {
                    if (node == null)
                        param.id = '-1';
                },
                onClick: function (node) {
                    $(this).tree('expand', node.target);
                    if(node.attributes.nodeType == 'szrl105')
                    {
                        if(_rl12502 != node.id){
                            _rl12502 = node.id;
                            Mediator.Notify('Index_Tree',{
                                perform: 'onClick',
                                node: node
                            });
                        }

                    } else
                      $.messager.alert('警告', '请选择合同信息!!', 'warning');

                },
                onCollapse: function (node) {
                    $(this).tree('collapseAll', node.target);
                }
            });
        }

        //#region 更新节点信息
        var UpdateRow = function(rl12507) {
            var node = _tree.tree('find', _rl12502);
            _tree.tree('update', {
                target: node.target,
                attributes: { 
                    nodeType: 'szrl105',
                    rl12507: rl12507
                }
            });
        }
        //#endregion
        
        return {
            Initialize: Initialize,
            UpdateRow: UpdateRow
        };

    }());
    //#endregion
    //#region Tabs_A_EditFrom: 合同基本信息窗体
    var Tabs_A_EditFrom = (function () {

        var _editFrom;
        var me = {
        };

        var Initialize = function (parameters) {
            if (parameters)
                $.extend(me, parameters);

            _editFrom = $('#Tabs_A_EditFrom');
        }

        //#region 加载合同信息
        var LoadFrom = function(rl10503){
            _editFrom.form({
                onLoadSuccess: function (_record) {
                    SetValues(_record);
                },
                onLoadError: function () {
            
                }
            });
            var _url = "/AreasCode031/sdrl125/LoadFromAsync/" + rl10503;
            _editFrom.form('load', _url);

        }
        //#endregion
        //#region 控件赋值
        var SetValues = function(_record){
            if(_record) {
                for (key in _record) {
                    var content = _record[key];
                    var selector = _editFrom.find("p[id='Tabs_A_"+ key +"']").eq(0);
                    if(selector)
                    {
                        selector.text(content);
                    }
                }
            }
        }
        //#endregion
        //#region 控制控件状态
        var SetDisabled = function(_isTrue){

            var childs = _editFrom.find("p[x-isReadOnly]");
            $.each(childs, function (key, val) {
               
            });  
        }
        //#endregion

        //获取合同金额
        var GetRl10519 = function() {
            var value = $('#Tabs_A_EditFrom').find("p[id='Tabs_A_rl10519']").eq(0).text();
            if(value)
              return parseFloat(value);
            else
              return 0;
        }

        //True: 未做验收计划
        var IsNoYuDing = function() {
            var value = $('#Tabs_A_EditFrom').find("p[id='Tabs_A_rl12105']").eq(0).text();
            if(value)
                value = parseFloat(value);
            else
                value = 0;
            return value == 0;
        }

        return {
            Initialize: Initialize,
            GetRl10519: GetRl10519,  //获取合同金额
            IsNoYuDing: IsNoYuDing,
            LoadFrom: LoadFrom,      //加载合同信息
            SetDisabled: SetDisabled //控制控件状态
        };

    }());
    //#endregion
    //#region Index_Link_Buttons: 主页面按钮组
    var Index_Link_Buttons = (function () {

        var _index_link_ABt, //发票维护
            _index_link_BBt, //预付款
            _index_link_CBt, //验收款
            _index_link_DBt, //支付计划调整
            _index_link_EBt, //带入验收计划
            _index_link_FBt, //恢复原支付计划
            _index_link_JBt, //变更
            _index_link_HBt, //保存
            _index_link_IBt, //删除
            _index_link_GBt; //输出AP
        var me = {
        };

        var Initialize = function (parameters) {
            if (parameters)
                $.extend(me, parameters);
            _index_link_ABt = $('#index_link_ABt');

            //#region 预付款|验收款
            _index_link_BBt = $('#index_link_BBt');
            _index_link_BBt.linkbutton({
                onClick: function(){
                    onClick({
                        text: '数据初始化中,请稍后...',
                        perform: 'index_link_BBt'
                    });
                }
            });
            _index_link_CBt = $('#index_link_CBt');
            _index_link_CBt.linkbutton({
                onClick:function(){
                    onClick({
                        text: '数据初始化中,请稍后...',
                        perform: 'index_link_CBt'
                    });
                }
            });
            //#endregion
            //#region 支付计划调整
            _index_link_DBt = $('#index_link_DBt');
            _index_link_DBt.linkbutton({
                onClick:function(){
                    onMessagerClick({
                        confirm: '是否确认调整此计划?',
                        text: '计划调整中请稍后...',
                        perform: 'index_link_DBt'

                    });
                }
            });
            //#endregion
            //#region 带入验收计划
            _index_link_EBt = $('#index_link_EBt');
            _index_link_EBt.linkbutton({
                onClick:function(){
                    onMessagerClick({
                        confirm: '是否带入验收计划?',
                        text: '数据初始化中请稍后...',
                        perform: 'index_link_EBt'

                    });
                }
            });
            //#endregion
            //#region 恢复原支付计划
            _index_link_FBt = $('#index_link_FBt');
            _index_link_FBt.linkbutton({
                onClick:function(){
                    onMessagerClick({
                        confirm: '是否进行数据恢复?',
                        text: '数据恢复中请稍后...',
                        perform: 'index_link_FBt'

                    });
                }
            });
            //endregion
            //#region 数据保存
            _index_link_HBt = $('#index_link_HBt');
            _index_link_HBt.linkbutton({
                onClick:function(){
                    onClick({
                        text: '数据保存中请稍后...',
                        perform: 'index_link_HBt'
                    });
                }
            });
            //#endregion

            _index_link_JBt = $('#index_link_JBt');
            _index_link_IBt = $('#index_link_IBt');
            _index_link_GBt = $('#index_link_GBt');

        }

        //#region 数据保存
        var SavePayment = function(parameters){
            $.ajax({
                type: "POST",
                url: parameters.url,
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(parameters.record),
                dataType: "json",
                success: function (data) {
                    if(data.success){
                        Mediator.Notify('Index_Link_Buttons', {
                            perform: parameters.perform,
                            Exec: 'Ajax',
                            Data: data
                        });
                    } else{
                       $.messager.progress('close');
                       $.messager.alert('警告', data.Message, 'warning');
                    }
                }
            });
        }
        //#endregion    
        //#region 按钮点击
        var onClick = function(parameters){
            $.messager.progress({ text: parameters.text });
            Mediator.Notify('Index_Link_Buttons', {
                perform: parameters.perform,
                Exec: 'onClick'
            });
        }
        var onMessagerClick = function(parameters){
            $.messager.confirm('友情提示', parameters.confirm,
                function (r) {
                    if (r) {
                        $.messager.progress({ text: parameters.text });
                        Mediator.Notify('Index_Link_Buttons', {
                            perform: parameters.perform,
                            Exec: 'onClick'
                        });

                    }
                }
            );
        }
        //#endregion
        //#region 按钮状态控制
        var ButtonControl = function(state)
        {
            _index_link_ABt.linkbutton('disable');
            _index_link_BBt.linkbutton('disable');
            _index_link_CBt.linkbutton('disable');
            _index_link_DBt.linkbutton('disable');
            _index_link_EBt.linkbutton('disable');
            _index_link_FBt.linkbutton('disable');
            _index_link_JBt.linkbutton('disable');
            _index_link_HBt.linkbutton('disable');
            _index_link_IBt.linkbutton('disable');
            _index_link_GBt.linkbutton('disable');

            switch(state)
            {
                case -1: //初始化
                case 7:  //[已审核]支付结束-等待下次支付
                    _index_link_BBt.linkbutton('enable'); //预付款
                    _index_link_CBt.linkbutton('enable'); //验收款

                    if(state == 7)
                    {
                        
                    }

                break;     
                case 0: //预付款
                case 1: //验收款
                    _btControl();

                break;  
                case 2: //[调整支付计划]预付款
                case 3: //[调整支付计划]验收款
                    _btControl();
                    _index_link_DBt.linkbutton('disable');
                break;   
                case 4: //[带入验收计划]预付款
                case 5: //[带入验收计划]验收款
                    _btControl();
                    _index_link_EBt.linkbutton('disable');
                    _index_link_FBt.linkbutton('enable');
                break;   
            }
        }
        var _btControl = function(){
            _index_link_ABt.linkbutton('enable'); //发票维护
            _index_link_DBt.linkbutton('enable'); //支付计划调整
            _index_link_EBt.linkbutton('enable'); //带入验收计划
            _index_link_HBt.linkbutton('enable'); //保存
            _index_link_IBt.linkbutton('enable'); //删除
        }
        //#endregion
        return {
            Initialize: Initialize,
            SavePayment: SavePayment,       //数据保存
            ButtonControl: ButtonControl    //按钮状态控制
        };

    }());
    //#endregion
    //#region Tabs_A_Index_center_Grid: 支付信息
    var Tabs_A_Index_center_Grid = (function () {

        var _easy_Grid;
        var _isEdit = false; //是否启用编辑

        var me = {
        };

        var Initialize = function (parameters) {
            if (parameters)
                $.extend(me, parameters);

            _easy_Grid = new Easy_GridPanel({
                id: "Tabs_A_Index_center_Grid",
                isPagination: false,

                configuration:{
                    idField: 'rl12601',
                    url: '/AreasCode031/sdrl125/LoadAsync',
                    columns: [[
                        { 
                            field: 'rl12605', title: '支払済', width: 100, 
                            halign: 'center', align: 'center',
                            formatter: function(value, record, rowIndex){
                                if(record.rl12601 == 'AddButton')
                                    return;

                                switch(value)
                                {
                                    case -1: 
                                        return "支付济"; 
                                    break;  
                                    case -2: 
                                        return "累計検収済"; 
                                    break;   
                                    case -3: 
                                        return "合计"; 
                                    break;  
                                    case -4: 
                                        return "元支払予定"; 
                                    break;  
                                    case 0: 
                                        return "今回支払"; 
                                    break; 
                                    case 1: 
                                    case 2: 
                                        return "今後支払予定"; 
                                    break;   
                                    default:
                                        return value;
                                    break;                               
                                }
                            }
                        },
                        { 
                            field: 'rl12606', title: '支払日期', width: 120 ,
                            halign: 'center', align: 'center'
                        },
                        { 
                            field: 'rl12607', title: '%', width: 120,
                            halign: 'center', align: 'right',
                            formatter: function(value, record, rowIndex){
                                if(record.rl12601 == 'AddButton')
                                    return;

                                if(record.rl12605 == 0 && record.rl12604 == '-1')
                                    return '';
                                return value + '%';
                            } 
                        },
                        { 
                            field: 'rl12608', title: '金額', width: 120,
                            halign: 'center', align: 'right',
                            formatter: function(value, record, rowIndex){
                                if(record.rl12601 == 'AddButton')
                                    return;

                                if(record.rl12605 == 0 && record.rl12604 == '-1')
                                    return '';
                                return value;
                            }  
                        },

                        { 
                            field: 'rl12609', title: '処理日期', width: 120,
                            halign: 'center', align: 'center',
                            formatter: function(value, record, rowIndex){
                                switch(record.rl12605)
                                {
                                    case -4: 
                                        return "今回支払実績/今後支払予定修正"; 
                                    break;     
                                    default:
                                        if(record.rl12605 == -1 || record.rl12605 == 0)
                                            return value;
                                    break;                           
                                }
                            } 
                        },
                        { 
                            field: 'rl12610', title: '支払日期', width: 120,
                            halign: 'center', align: 'center',
                            editor: {
                                type: 'datebox',
                                options: {
                                    value: 'new data()'
                                }
                            }
                        },
                        { 
                            field: 'rl12611', title: '%', width: 120,
                            halign: 'center', align: 'right',
                            formatter: function(value, record, rowIndex){
                                if(record.rl12601 == 'AddButton')
                                    return "<a href=\"javascript: void(0)\" onclick=\"window.window_AddPayment()\">插入行</a>";
                                return value + '%';
                            },
                            editor:{
                                type:'numberbox',
                                options: { 
                                    min: 0,
                                    max: 100,
                                    precision: 2,
                                    value: 0
                                }
                            }  
                        },
                        { 
                            field: 'rl12612', title: '金額', width: 120,
                            halign: 'center', align: 'right',
                            editor:{
                                type:'numberbox',
                                options: { groupSeparator: ',', decimalSeparator:'.', precision: 2, value: 0}
                            },
                            formatter: function(value, record, rowIndex){
                                if(record.rl12601 == 'AddButton')
                                    return;
                                return value;
                            }
                        },
                        { 
                            field: 'xxxx', title: '附件', width: 120,
                            halign: 'center', align: 'center',
                            formatter: function(value, record, rowIndex){
                                if(record.rl12605 == 0 && record.rl12604 != '-1')
                                   return "上传附件";
                                if(record.rl12605 == -1)
                                   return "下载附件";
                            } 
                        },
                        { 
                            field: 'rl12614', title: '付款性质', width: 120,
                            halign: 'center', align: 'center',
                            formatter: function(value, record, rowIndex){
                                if(record.rl12605 == -1 || (record.rl12605 == 0 && record.rl12604 != '-1'))
                                {
                                    switch(value)
                                    {
                                        case 0:
                                            return '预付款';
                                        break;
                                        case 1:
                                            return '质保款';
                                        break;
                                        case 2:
                                            return '验收款';
                                        break;
                                    }
                                }
                            }  
                        },
                        { 
                            field: 'rl12615', title: '预付款扣款金额', width: 120,
                            halign: 'center', align: 'right',
                            formatter: function(value, record, rowIndex){
                                if(record.rl12605 == -1 || record.rl12605 == -2 || record.rl12605 == -3 || (record.rl12605 == 0 && record.rl12604 != '-1'))
                                    return value;
                            },
                            editor:{
                                type:'numberbox',
                                options: { groupSeparator: ',', decimalSeparator:'.', precision: 2, value: 0 }
                            }    
                        },
                        { 
                            field: 'rl12616', title: '预付款扣款<br/>占合同%', width: 120,
                            halign: 'center', align: 'right',
                            formatter: function(value, record, rowIndex){
                                if(record.rl12605 == -1 || record.rl12605 == -2 || record.rl12605 == -3 || (record.rl12605 == 0 && record.rl12604 != '-1'))
                                    return value + '%';
                            },
                            editor:{
                                type:'numberbox',
                                options: { 
                                    min: 0,
                                    max: 100,
                                    precision: 2,
                                    value: 0
                                }
                            }    
                        },
                        { 
                            field: 'rl12617', title: '本次实际支<br/>付金额(含税)', width: 120,
                            halign: 'center', align: 'right',
                            formatter: function(value, record, rowIndex){
                                if(record.rl12605 == -1 || record.rl12605 == -2 || record.rl12605 == -3 || (record.rl12605 == 0 && record.rl12604 != '-1'))
                                    return value;
                            } 
                        },
                        { 
                            field: 'rl12618', title: '本次实际支<br/>付金额(不含税)', width: 120,
                            halign: 'center', align: 'right',
                            formatter: function(value, record, rowIndex){
                                if(record.rl12605 == -1 || record.rl12605 == -2 || record.rl12605 == -3 || (record.rl12605 == 0 && record.rl12604 != '-1'))
                                    return value;
                            },
                            editor:{
                                type:'numberbox',
                                options: { groupSeparator: ',', decimalSeparator:'.', precision: 2, value: 0 }
                            }      
                        },

                        { 
                            field: 'rl12619', title: '备注', width: 120,
                            halign: 'center',
                            formatter: function(value, record, rowIndex){
                                if(record.rl12605 == -1 || (record.rl12605 == 0 && record.rl12604 != '-1'))
                                    return value;
                            },
                            editor:{
                                type:'textbox'
                            }  
                        },
                        { 
                            field: 'rl12719', title: '状态', width: 120,
                            halign: 'center', align: 'center',
                            formatter: function(value, record, rowIndex){
                                if(record.rl12605 == -1 || (record.rl12605 == 0 && record.rl12604 != '-1'))
                                {
                                    switch(value)
                                    {
                                        case 0:
                                            return '承认济';
                                        break;
                                        case 1:
                                            return 'AP已发行';
                                        break;
                                    }
                                    if(record.rl12605 == 0 && record.rl12604 != '-1')
                                        return '未提出';
                                }
                            }   
                        },
                        { 
                            field: 'rl12720', title: 'AP编号', width: 120,
                            halign: 'center' 
                        },
                        { 
                            field: 'rl12620', title: '担当者', width: 120,
                            halign: 'center', align: 'center',
                            formatter: function(value, record, rowIndex){
                                if(record.rl12605 == -1 || (record.rl12605 == 0 && record.rl12604 != '-1'))
                                    return value;
                            }   
                        }
                    ]],
                    rownumbers: false,
                    showFooter: true,
                    onLoadSuccess: function(jsonData) {

                        //新增按钮
                        _easy_Grid.GridPanel.datagrid('appendRow',{
                            rl12601: 'AddButton',
                            rl12602: '-1',
                            rl12603: -100,
                            rl12604: '-1',
                            rl12605: -100,
                            rl12606: '',
                            rl12607: 0,
                            rl12608: 0,
                            rl12609: '',
                            rl12610: '',
                            rl12611: 0,
                            rl12612: 0,
                            rl12613: '',
                            rl12614: 0,
                            rl12615: 0,
                            rl12616: 0,
                            rl12617: 0,
                            rl12618: 0,
                            rl12619: '',
                            rl12620: '',
                            rl12621: 0,
                            rl12622: -1
                        });

                        MergeCells();
                        Mediator.Notify('Tabs_A_Index_center_Grid',{
                            perform: 'LoadSuccess'
                        });

                    },
                    onClickCell: onClickCell,
                    onBeginEdit: onBeginEdit,
                    onEndEdit: onEndEdit
                }
                
            });
            
        }
        
        var onBeginEdit = function(rowIndex, record) {

        }

        //#region 编辑后
        var _editfield = null;
        var onEndEdit = function(rowIndex, record, changes) {

            if((record.rl12605 == 0 || record.rl12605 == 1) && _editfield != 'rl12610' && _editfield != 'rl12614' && _editfield != 'rl12619')
            {
                if(record.rl12605 == 0 && record.rl12604 != '-1')
                {
                    if(_editfield == 'rl12612' || _editfield == 'rl12615' || _editfield == 'rl12616')
                    {
                        Mediator.Notify('Tabs_A_Index_center_Grid', {
                            perform: 'onEndEdit',
                            Exec: 'calculate',
                            editfield: _editfield,
                            rowIndex: rowIndex,
                            record: record
                        });
                    }
                }
                //#region 计算合计
                var _rowIndex = -1;
                var _record = null;
                var rows = _easy_Grid.GridPanel.datagrid('getRows');
                //#region 查找-累計検収済
                var x_rl12611 = 0; //%
                var x_rl12612 = 0; //金额

                var x_rl12615 = 0; //预付款扣款金额
                var x_rl12616 = 0; //预付款扣款占合同%
                var x_rl12617 = 0; //本次实际支付金额(含税)
                var x_rl12618 = 0; //本次实际支付金额(不含税)
                
                _rowIndex = _easy_Grid.GridPanel.datagrid('getRowIndex', '-2');
                if(_rowIndex != -1)
                {
                    _record = rows[_rowIndex];
                    x_rl12611 = parseFloat(_record.rl12611);
                    x_rl12612 = parseFloat(_record.rl12612);

                    x_rl12615 = parseFloat(_record.rl12615);
                    x_rl12616 = parseFloat(_record.rl12616);
                    x_rl12617 = parseFloat(_record.rl12617);
                    x_rl12618 = parseFloat(_record.rl12618);
                }
                //#endregion 
                $.each(rows, function(_index, _row) {
                    x_rl12611 += parseFloat(_row.rl12611);
                    x_rl12612 += parseFloat(_row.rl12612);
                    if(_row.rl12605 == 0 && _row.rl12604 != '-1')
                    {
                        x_rl12615 += parseFloat(_row.rl12615);
                        x_rl12616 += parseFloat(_row.rl12616);
                        x_rl12617 += parseFloat(_row.rl12617);
                        x_rl12618 += parseFloat(_row.rl12618);
                    }
                });
                //更新合计
                var footerRows = _easy_Grid.GridPanel.datagrid('getFooterRows');
                footerRows[0].rl12611 = x_rl12611;
                footerRows[0].rl12612 = x_rl12612;

                footerRows[0].rl12615 = x_rl12615;
                footerRows[0].rl12616 = x_rl12616;
                footerRows[0].rl12617 = x_rl12617;
                footerRows[0].rl12618 = x_rl12618;
                _easy_Grid.GridPanel.datagrid('reloadFooter');
                
                //#endregion  

            }
        }
        //#endregion
        
        //#region 编辑控制
        var SetIsEdit = function(isEdit) {
            _isEdit = isEdit;
        }
        var BeforeEditCell = function(index, field) {
            var rows = _easy_Grid.GridPanel.datagrid('getRows');
            var record = rows[index];

            if(_isEdit)
            {
                if(field == 'rl12611' && record.rl12601 != 'AddButton')
                    return true;

                if(field == 'rl12610' || field == 'rl12612')
                {
                    if(record.rl12605 == 0 || (record.rl12605 == 1 && record.rl12603 == 2))
                        return true;
                }  
                if(field == 'rl12614' || field == 'rl12615' || field == 'rl12616' || field == 'rl12617' || field == 'rl12618' || field == 'rl12619')
                {
                    if(record.rl12605 == 0 && record.rl12604 != '-1')
                        return true;
                }  
            }
            return false;
        }
        
        //#endregion
        //#region 单元格编辑
        var editIndex = undefined;
        var endEditing = function(){
			if (editIndex == undefined){
                return true;
            }
			if (_easy_Grid.GridPanel.datagrid('validateRow', editIndex)){
				_easy_Grid.GridPanel.datagrid('endEdit', editIndex);
                editIndex = undefined;
                MergeCells(_easy_Grid.GridPanel);
				return true;
			} else {
				return false;
			}
		}
		function onClickCell(index, field){
            _editfield = field;
			if (endEditing() && BeforeEditCell(index, field)){
				_easy_Grid.GridPanel.datagrid('selectRow', index)
						  .datagrid('editCell', {index:index, field:field});
				editIndex = index;
			}
		}
        //#endregion
        //#region 数据加载
        var Load = function (_params) {
            _easy_Grid.Load(_params);
        };
        //#endregion
        //#region 合并单元格
        var MergeCells = function(){

            var merges = [];
            var rows = _easy_Grid.GridPanel.datagrid('getRows');
            var rowIndex = -1;
            var record = undefined;
            
            //#region 元支払予定-合并
            rowIndex = _easy_Grid.GridPanel.datagrid('getRowIndex', '-4');
            merges.push({
				index: rowIndex,
				field: 'rl12605',
				rowspan: 0,
				colspan: 4
            });
            merges.push({
				index: rowIndex,
				field: 'rl12609',
				rowspan: 0,
				colspan: 14
			});
            //#endregion
            //#region 支払済-今回支払合并
            rowIndex = -1;
            var count = 0;
            $.each(rows, function (index, value) {
                if(value.rl12605 == 0){
                    if(rowIndex == -1)
                        rowIndex = index;
                    count = count+1;
                }

            });
            if(rowIndex!=-1)
            {
                merges.push({
                    index: rowIndex,
                    field: 'rl12605',
                    rowspan: count,
                    colspan: 0
                });
                merges.push({
                    index: rowIndex,
                    field: 'rl12609',
                    rowspan: count,
                    colspan: 0
                });
            }
            //#endregion
            //#region 支払済-今後支払予定合并
            rowIndex = -1;
            count = 0;
            $.each(rows, function (index, value) {
                if(value.rl12605 == 1 || value.rl12605 == 2){
                    if(rowIndex == -1)
                       rowIndex = index;
                    count = count+1;
                }
            });
            if(rowIndex!=-1)
            {
                merges.push({
                    index: rowIndex,
                    field: 'rl12605',
                    rowspan: count,
                    colspan: 0
                });
            }
            //#endregion
			for (var i = 0; i < merges.length; i++) {
				_easy_Grid.GridPanel.datagrid('mergeCells', {
					index: merges[i].index,     //从N 行开始
					field: merges[i].field,     //合并字段
					rowspan: merges[i].rowspan, //共合并多少列
					colspan: merges[i].colspan  //共合并多少行
				});
            }
            
        }
        //#endregion
        
        //#region 初始化 - 更新对应关系(PK)
        var SetAssociated = function(date) {
            var records = _easy_Grid.GridPanel.datagrid('getRows');

            var szrl126_x = []; //-1 : 默认插入的数据
            $.each(date, function(index, record) {
                if(record.rl12604 == -1)
                   szrl126_x.push(record);
            });

            var _xIndex = 0;    //-1: 默认2条数据所在下标
            $.each(records, function(index, record) {
                 var _tempR = null;
                 if(record.rl12604 == -1)
                 {
                    _tempR = szrl126_x[_xIndex];
                    _xIndex = _xIndex+1;
                 } else{
                     _tempR = GetAssociated(record, date);
                 }
                 if(_tempR) {
                    _easy_Grid.GridPanel.datagrid('updateRow',{
                        index: index, 
                        row: {
                            rl12601: _tempR.rl12601
                        }
                    });
                 }
            });
            MergeCells();
            
        }
        var GetAssociated = function(record, date) {
            for(var i = 0; i< date.length; i++)
            {
                if(date[i].rl12604 == record.rl12604)    
                    return date[i];           
            }
            return null;
        }
        //#endregion
        //#region 获取更新数据
        var GetUpRecords = function() {
            var upRecords = [];
            var records = _easy_Grid.GridPanel.datagrid('getChanges');
            $.each(records, function(x, record) {
                if(record.rl12605 == 0 || record.rl12605 == 1)
                  upRecords.push(record);

            });
            return upRecords;
        }
        //#endregion
        //#region 新增一条计划
        var AddPayment = function() {
            if(!_isEdit) return;

            endEditing();
            var index = _easy_Grid.GridPanel.datagrid('getRows').length -1;
            _easy_Grid.GridPanel.datagrid('insertRow',{
                index: index,
                row: {
                    rl12601: '-1',
                    rl12602: '-1',
                    rl12603: 2,
                    rl12604: index + 2, //来源ID 根据此标识更新 PK
                    rl12605: 1,
                    rl12606: '',
                    rl12607: 0,
                    rl12608: 0,
                    rl12609: '',
                    rl12610: '',
                    rl12611: 0,
                    rl12612: 0,
                    rl12613: '',
                    rl12614: 0,
                    rl12615: 0,
                    rl12616: 0,
                    rl12617: 0,
                    rl12618: 0,
                    rl12619: '',
                    rl12620: '',
                    rl12621: 1,
                    rl12622: index + 2
                }
           });
           MergeCells();

        }
        window.window_AddPayment = function() {
            AddPayment();
        }
        //#endregion 

        var UpdateRow = function(rowIndex, record) {
            _easy_Grid.GridPanel.datagrid('updateRow',{
                index: rowIndex, 
                row: record
            });

        }
        var AcceptChanges = function() {
            _easy_Grid.GridPanel.datagrid('acceptChanges');
        }

        return {
            Initialize: Initialize,
            Load: Load,

            SetIsEdit: SetIsEdit,
            endEditing: endEditing,
            SetAssociated: SetAssociated,
            AddPayment: AddPayment,

            UpdateRow: UpdateRow,
            AcceptChanges: AcceptChanges,
            GetUpRecords: GetUpRecords
        };

    }());
    //#endregion
    
    //#region 中介者
    var Mediator = (function () {

        //合同支付状态: -1: 初始化, 0,预付款, 1:验收款, 2:[调整支付计划]预付款, 3:[调整支付计划]验收款, 4:[带入验收计划]预付款, 5:[带入验收计划]验收款, 6:流转审批中, 7: [已审核]支付结束-等待下次支付
        var _rl12507 = -1;
        //合同ID
        var _rl12502 = undefined; 

        var _Index_Tree = Index_Tree;                             //合同树
        var _Tabs_A_EditFrom = Tabs_A_EditFrom;                   //合同基本信息窗体
        var _Index_Link_Buttons = Index_Link_Buttons;             //主页面按钮组
        var _Tabs_A_Index_center_Grid = Tabs_A_Index_center_Grid; //支付信息
        var Notify = function (component, parameters) {
            //#region Index_Tree: 合同Tree
            if(component == 'Index_Tree')
            {
                //树点击
                if(parameters.perform == 'onClick') {
                    TreeClick(parameters.node)
                }            
            }
            //#endregion
            //#region Tabs_A_Index_center_Grid: 支付信息
            if(component == 'Tabs_A_Index_center_Grid')
            {
                //加载成功
                if(parameters.perform == 'LoadSuccess') {
                    LoadSuccess();
                }          
                //编辑
                if(parameters.perform == 'onEndEdit') {
                    switch(parameters.Exec)
                    {
                        //编辑-预付款扣款金额|预付款扣款占合同%|本次实际支付金额(含税)
                        case 'calculate':
                        onEndEdit_Calculate({
                            editfield: parameters.editfield,
                            rowIndex: parameters.rowIndex,
                            record: parameters.record
                        });
                        break
                    }

                }  
            }
            //#endregion
            //#region Index_Link_Buttons: 主页面按钮组
            if(component == 'Index_Link_Buttons')
            {
                //#region 按钮点击
                if(parameters.Exec == 'onClick')
                {
                    switch(parameters.perform)
                    {
                        //#region 预付款
                        case 'index_link_BBt':
                        onClick({
                            perform: 'index_link_BBt',
                            url: '/AreasCode031/sdrl125/AdvancePaymentAsync',
                            rl12507: 0,
                            szrl126s: []
                        });
                        break;
                        //#endregion
                        //#region 验收款
                        case 'index_link_CBt':
                        if(_Tabs_A_EditFrom.IsNoYuDing())
                        {
                            $.messager.alert('警告', '尚未做验收计划!', 'warning');
                            $.messager.progress('close');
                            return;
                        }

                        onClick({
                            perform: 'index_link_CBt',
                            url: '/AreasCode031/sdrl125/AdvancePaymentAsync',
                            rl12507: 1,
                            szrl126s: []
                        });
                        break;
                        //#endregion
                        //#region 支付计划调整
                        case 'index_link_DBt':
                        onClick({
                            perform: 'index_link_DBt',
                            url: '/AreasCode031/sdrl125/AdjustPaymentAsync',
                            rl12507: _rl12507,
                            szrl126s: _Tabs_A_Index_center_Grid.GetUpRecords() 
                        });
                        break;
                        //#endregion
                        //#region 带入验收计划
                        case 'index_link_EBt':
                        onClick({
                            perform: 'index_link_EBt',
                            url: '/AreasCode031/sdrl125/IntoPaymentAsync',
                            rl12507: _rl12507,
                            szrl126s: []
                        });
                        break;
                        //#endregion
                        //#region 恢复原支付计划
                         case 'index_link_FBt':
                         onClick({
                            perform: 'index_link_FBt',
                            url: '/AreasCode031/sdrl125/RestorePaymentAsync',
                            rl12507: _rl12507,
                            szrl126s: []
                         });
                         break;
                        //#endregion
                        //#region 数据保存
                        case 'index_link_HBt':
                        onClick({
                            perform: 'index_link_HBt',
                            url: '/AreasCode031/sdrl125/SaveAsync',
                            rl12507: _rl12507,
                            szrl126s: _Tabs_A_Index_center_Grid.GetUpRecords() 
                        });
                        break;
                        //#endregion
                    }
                }
                //#endregion
                //#region 按钮控制
                if(parameters.Exec == 'Ajax')
                {
                    switch(parameters.perform)
                    {
                        //#region 预付款|验收款|数据保存
                        case 'index_link_BBt':
                        case 'index_link_CBt':
                        case 'index_link_HBt':
                        SavePayment({
                            Data: parameters.Data,
                            InitState: true
                        });
                        break;
                        //#endregion
                        //#region 支付计划调整|带入验收计划|恢复原支付计划
                        case 'index_link_DBt':
                        case 'index_link_EBt':
                        case 'index_link_FBt':
                        SavePayment({
                            Data: parameters.Data,
                            Load: true
                        });
                        break;
                        //#endregion
                    }
                }
                //#endregion
            }
            //#endregion
        }

        //#region Index_Tree: 合同Tree
        //树点击
        var TreeClick = function(node) {
            SetState(node.id, node.attributes.rl12507);
            InitState(-300);

            //加载合同信息
            _Tabs_A_EditFrom.LoadFrom(node.id);
            //加载合同支付信息
            _Tabs_A_Index_center_Grid.Load({
                rl12502: _rl12502,
                rl12507: _rl12507
            });
        }
        //#endregion
        //#region Tabs_A_Index_center_Grid: 支付信息
        //加载成功
        var LoadSuccess = function(node) {
            InitState(_rl12507);
            $.messager.progress('close');
        }
        //编辑-预付款扣款金额|预付款扣款占合同%|本次实际支付金额(含税)
        var onEndEdit_Calculate = function(parameters) {
            var editfield = parameters.editfield;
            var rowIndex = parameters.rowIndex;
            var record = parameters.record;
            //合同金额
            var _rl10519 = _Tabs_A_EditFrom.GetRl10519();
            var _rl12612 = parseFloat(record.rl12612); //金回金额
            var _rl12615 = parseFloat(record.rl12615); //预付款扣款金额
            var _rl12616 = parseFloat(record.rl12616); //预付款扣款占合同%

            switch(editfield)
            {
                case 'rl12615': //预付款扣款金额
                if(_rl10519 > 0)
                    _rl12616 = (_rl12615/_rl10519*100).toFixed(2);
                else
                    _rl12616 = 0;
                break;
                case 'rl12616': //预付款扣款占合同%
                    _rl12615 = ((_rl12616/100)*_rl10519).toFixed(2);

                break;
            }
            //本次实际支付金额(含税)
            var _rl12617 = _rl12612 - _rl12615;

            _Tabs_A_Index_center_Grid.UpdateRow(rowIndex, {
                rl12615: _rl12615,
                rl12616: _rl12616,
                rl12617: _rl12617
            });
            
        }
        //#endregion
        //#region Index_Link_Buttons: 主页面按钮组
        //按钮点击
        var onClick = function(parameters) {
            if(_Tabs_A_Index_center_Grid.endEditing())
            {
                _Index_Link_Buttons.SavePayment({
                    url: parameters.url,
                    perform: parameters.perform,
                    record: {
                        rl12502: _rl12502,
                        rl12507: parameters.rl12507,
                        rl12503: 0,
                        rl12505: 0,
                        //获取更新编辑行
                        szrl126s: parameters.szrl126s
                    }
                });
            }
        }
        //按钮控制
        var SavePayment = function(parameters){
            var u_rl12507 = parameters.Data.Pamrms.rl12507;
            var u_records = null; if(parameters.Data.Pamrms.records) u_records = parameters.Data.Pamrms.records;
            //关联 -1: 默认数据
            if(u_records && u_records.length > 0)
                _Tabs_A_Index_center_Grid.SetAssociated(u_records);
            _Index_Tree.UpdateRow(u_rl12507);

            //设置状态
            SetState(_rl12502, u_rl12507);
            if(parameters.Load)
            {
                //加载合同支付信息
                _Tabs_A_Index_center_Grid.Load({
                    rl12502: _rl12502,
                    rl12507: u_rl12507
                });
            }
            if(parameters.InitState)
            {
                InitState(u_rl12507);
                $.messager.progress('close');
            }
            
            _Tabs_A_Index_center_Grid.AcceptChanges();
        }
        //#endregion

        //#region InitState
        var InitState = function(state){
            _Index_Link_Buttons.ButtonControl(state);
            var _isEdit = false;
            if(state != -1 && state != 6 && state != 7 && state != -300)
                _isEdit = true;
            _Tabs_A_Index_center_Grid.SetIsEdit(_isEdit);

        }
        var SetState = function(rl12502, rl12507){
            _rl12502 = rl12502;
            _rl12507 = rl12507;
        }
        //#endregion

        return {
            Notify: Notify
        };

    }());
    //#endregion

    //#region 系统初始化
    var Initialize = function () {
        Index_Tree.Initialize();
        Tabs_A_EditFrom.Initialize();
        Index_Link_Buttons.Initialize();
        Tabs_A_Index_center_Grid.Initialize();

    }
    //#endregion 
    $(function () {
        Initialize();
    });

}());


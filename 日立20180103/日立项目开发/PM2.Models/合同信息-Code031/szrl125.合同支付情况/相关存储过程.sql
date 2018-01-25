--合同辅助信息
if exists (select * from sysobjects where id = object_id(N'[dbo].[sdvw_szrl105View]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[sdvw_szrl105View]
GO
CREATE VIEW sdvw_szrl105View
WITH ENCRYPTION
AS
--预付款累计支付金额
with ProcAWith as (
	select 
		rl12502,
		[Proc] = SUM(rl12711) 
	from szrl127 inner join szrl125 
	on rl12702 = rl12501 
	where rl12713 = 0 
	group by rl12502
),
--预付款累计扣款金额
ProcBWith as(
	select 
		rl12502,
		[Proc] = SUM(rl12714) 
	from szrl127 inner join szrl125 
	on rl12702 = rl12501 
	where rl12713 <> 0 
	group by rl12502
),
--验收计划
ProcCWith as(
	select
		[pd00401] = rl12802,--合同ID
		--rl12102,--状态 1: 今回检收,2: 今月再度检收预定
		--rl12101,--计划ID
		--验收计划
		rl12103,--验收日期
		rl12104,--验收比率
		rl12105,--验收金额
		--实际验收
		rl12106,--验收日期
		rl12107,--验收比率
		rl12108,--验收金额

		rl12110 --备注

	from szrl128 inner join szrl121
	on rl12124 = rl12801
	where rl12804 = 1 and rl12809 = 1 and rl12102 = 1

),
--已验收金额
ProcDWith as(
	select
		rl12802,
		[Proc] = SUM(rl12108) 
		
	from szrl128 inner join szrl121
	on rl12124 = rl12801
	where rl12804 = 1 and rl12809 = 1 and rl12102 = 0
	group by rl12802
)
select 
	--基础信息
	rl10503,--合同ID
	rl01807,--项目名称
	rl10505,--合同编号
	rl10515,--开工日期
	rl01806,--作番号
	[rl10606] = (select top 1 rl10606 from szrl106 where rl10602 = rl10501),--合同名称
	rl10512,--完工日期
	
	rl10519,--合同金额(含税)
	[rl10003] = (select rl10003 from szrl100 where rl10001 = rl10510),--供应商
	rl10531,--预付款总金额
	--预付款未支付金额
	[ProcA] = isnull((rl10531 - (select isnull([Proc],0) from ProcAWith where rl12502 = rl10503)), 0),
	--已扣预付款占合同%
	[ProcB] = isnull((case when rl10519 = 0 then 0 else ((select isnull([Proc],0) from ProcBWith where rl12502 = rl10503)/rl10519) end),0),     
	--预付款占合同%
	[ProcC] = isnull((case when rl10519 = 0 then 0 else (rl10531/rl10519) end),0),  
	--预付款累计扣款金额
	[ProcD] = isnull((select isnull([Proc],0) from ProcBWith where rl12502 = rl10503),0),
	--已验收金额
	[ProcE] = isnull((select isnull([Proc],0) from ProcDWith where rl12802 = rl10503),0),
	--预付款累计支付金额
	[ProcF] = isnull((select isnull([Proc],0) from ProcAWith where rl12502 = rl10503),0),
	--预付款未扣款金额
	[ProcG] = isnull((rl10531-(select isnull([Proc],0) from ProcBWith where rl12502 = rl10503)),0),
	--已验收金额占合同%
	[ProcH] = isnull((case when rl10519 = 0 then 0 else ((select isnull([Proc],0) from ProcDWith where rl12802 = rl10503)/rl10519) end),0),
	[ProcI] = isnull(rl12504, 0),--累计含税发票金额
	[ProcJ] = isnull(rl12506, 0),--累计不含税发票金额
	--预付款累计支付占合同%
	[ProcK] = isnull((case when rl10519 = 0 then 0 else ((select isnull([Proc],0) from ProcAWith where rl12502 = rl10503)/rl10519) end),0),
	[ProcL] = isnull(rl10524, 0),--税率
	[pj00402] = (select pj00402 from sdpj004 where pj00401 = rl10567),--合同登录人员
	[ProcM] = isnull(rl12503, 0),--本次含税发票金额
	[ProcN] = isnull(rl12505, 0),--本次不含税发票金额
	
	--验收计划
	--计划
	[rl12103] = isnull(rl12103, ''),--验收日期
	[rl12104] = isnull(rl12104, 0),--验收比率
	[rl12105] = isnull(rl12105, 0),--验收金额
	--实际
	[rl12106] = isnull(rl12106, ''),--验收日期
	[rl12107] = isnull(rl12107, 0),--验收比率
	[rl12108] = isnull(rl12108, 0),--验收金额
	rl12110 --备注

from szrl105 
inner join szrl018
on rl10502 = rl01801

left join ProcCWith
on rl10503 = [pd00401]
left join szrl125
on rl10503 = rl12502
where rl10572 = 1 
GO

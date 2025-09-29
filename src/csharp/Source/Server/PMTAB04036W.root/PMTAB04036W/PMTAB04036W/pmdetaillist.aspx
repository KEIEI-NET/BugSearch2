<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pmdetaillist.aspx.cs" Inherits="Broadleaf.Web.UI.PMTAB04036W" %>
<!DOCTYPE HTML>
<html>
<%--  プログラム名:明細表示画面 --%>              
<%--  プログラムID:PMTAB04036W --%> 
<head runat ="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
	<meta name="format-detection" content="telephone=no">
	<meta name="apple-mobile-web-app-capable" content="yes">
	
	<link rel="stylesheet" type="text/css" href="<% Response.Write("./css/common/WebAppCommon.css.aspx?ver=" + Broadleaf.Application.Common.ExtFileVersion.Ver()); %>" />
	<link rel="stylesheet" type="text/css" href="<% Response.Write("./css/common/pmcommon.css?ver=" + Broadleaf.Application.Common.ExtFileVersion.Ver()); %>" />
	<link rel="stylesheet" type="text/css" href="<% Response.Write("./css/common/SoftwareKeyboardWindow.css?ver=" + Broadleaf.Application.Common.ExtFileVersion.Ver()); %>" />
	<link rel="stylesheet" type="text/css" href="<% Response.Write("./css/common/ListSelectWindow.css?ver=" + Broadleaf.Application.Common.ExtFileVersion.Ver()); %>" />
	<link rel="stylesheet" type="text/css" href="<% Response.Write("./css/common/InputPasswordWindow.css?ver=" + Broadleaf.Application.Common.ExtFileVersion.Ver()); %>" />
	<link rel="stylesheet" type="text/css" href="<% Response.Write("./css/stock/pmdetaillist.css?ver=" + Broadleaf.Application.Common.ExtFileVersion.Ver()); %>" />
	<link rel="stylesheet" type="text/css" href="<% Response.Write("./css/stock/pmemployeeselect.css?ver=" + Broadleaf.Application.Common.ExtFileVersion.Ver()); %>" />
	<%-- 2017.11.02 案件番号11370090-00 chenyk add BEGIN --%>
	<link rel="stylesheet" type="text/css" href="<% Response.Write("./css/stock/pmpartsdetailmodal.css?ver=" + Broadleaf.Application.Common.ExtFileVersion.Ver()); %>" />
	<link rel="stylesheet" type="text/css" href="<% Response.Write("./css/lib/swiper.min.css?ver=" + Broadleaf.Application.Common.ExtFileVersion.Ver()); %>" />
	<%-- 2017.11.02 案件番号11370090-00 chenyk add END --%> 
	
	<link id="theme" rel="stylesheet" type="text/css"/>
	<link rel="apple-touch-icon-precomposed" href="./image/system.png" />
	<title>明細表示画面</title>
	
	<script>
	    var enterpriseCode = '<% Response.Write(enterpriseCode); %>';
		var employeeAuth = '<% Response.Write(employeeAuth); %>';
		var loginUrl = '<% Response.Write(loginUrl); %>';
		var logoutUrl = '<% Response.Write(logoutUrl); %>';
	</script>
	<script src="./js/lib/jquery-2.0.0.js"></script>
	<script src="./js/lib/jquery.cookie.js"></script>
	<script src="./js/lib/jquery.json.js"></script>
	<script src="<% Response.Write("./js/common/WebAppCommon.js.aspx?ver=" + Broadleaf.Application.Common.ExtFileVersion.Ver()); %>"></script>
	<script src="<% Response.Write("./js/common/pmcommon.js?ver=" + Broadleaf.Application.Common.ExtFileVersion.Ver()); %>"></script>
	<script src="<% Response.Write("./js/common/waitloading.js?ver=" + Broadleaf.Application.Common.ExtFileVersion.Ver()); %>"></script>
	<script src="<% Response.Write("./js/common/SoftwareKeyboardWindow.js?ver=" + Broadleaf.Application.Common.ExtFileVersion.Ver()); %>"></script>
	<script src="<% Response.Write("./js/common/ListSelectWindow.js?ver=" + Broadleaf.Application.Common.ExtFileVersion.Ver()); %>"></script>
	<script src="<% Response.Write("./js/common/InputPasswordWindow.js?ver=" + Broadleaf.Application.Common.ExtFileVersion.Ver()); %>"></script>
	<script src="<% Response.Write(websyncAp);%>/SFCMN01502C/client.ashx"></script>
    <script src="<% Response.Write("./js/stock/PMTAB04036W.js?ver=" + Broadleaf.Application.Common.ExtFileVersion.Ver()); %>"></script>
    <script src="<% Response.Write("./js/stock/PMTAB04050W.js?ver=" + Broadleaf.Application.Common.ExtFileVersion.Ver()); %>"></script>
	<%-- 2017.11.02 案件番号11370090-00 chenyk add BEGIN --%> 
	<script src="<% Response.Write("./js/common/modalwindow.js?ver=" + Broadleaf.Application.Common.ExtFileVersion.Ver()); %>"></script>
	<script src="<% Response.Write("./js/stock/PMTAB04060W.js?ver=" + Broadleaf.Application.Common.ExtFileVersion.Ver()); %>"></script>
	<script src="<% Response.Write("./js/stock/PMTAB04061W.js?ver=" + Broadleaf.Application.Common.ExtFileVersion.Ver()); %>"></script>
	<script src="<% Response.Write("./js/lib/swiper.min.js?ver=" + Broadleaf.Application.Common.ExtFileVersion.Ver()); %>"></script>
	<%-- 2017.11.02 案件番号11370090-00 chenyk add END --%>
</head>
<body>
    <nav class="UI_toolbar">
	</nav>
	<section class="main">
        <section class="info_panel customer_info_panel">
			<header class="message_header">得意先情報</header>
			<section class="infos_with_icon">
				<ul id="infos_with_icon_ul">
			        <li id="customercode"></li>
					<li id="customersnm"></li>
					<li id="mngsectioncode"></li>
				</ul>
				<div class="clear_float"></div>
			</section>
		</section>
		<section class="info_panel self_section_info_panel">
			<header class="message_header">
				<ul>
					<li class="section">拠点</li>
					<li class="worker">担当者</li>
					<li class="worker">受注者</li>
					<li class="worker">発行者</li>
					<li >売上日</li>
					<div class="clear_float"></div>
				</ul>
			</header>
			<section class="infos_with_icon">
				<ul id="selfsectioninfopanel">
					<li class="section"><span id="sectionname"></span></li>
					<li class="worker"><button class="worker_btn"><span id="salesEmployeeNm"></span></button></li>
					<li class="worker"><button class="worker_btn"><span id="frontEmployeeNm"></span></button></li>
					<li class="worker"><button class="worker_btn"><span id="salesInputName"></span></button></li>
					<li class="salesday"><span id="salesdate"></span></li>
				</ul>
				<div class="clear_float"></div>
			</section>
		</section>
		<section class="info_panel car_info_panel">
			<header class="message_header">車両情報</header>
			<section class="infos_with_icon">
				<ul id="carinfopanel">
					<li class="car_type"></li>
					<li class="car_no"></li>
					<li class="car_body"></li>
					<li class="car_color"></li>
					<li class="car_engine"></li> 
					<li class="car_date"></li>
				</ul>
				<div class="clear_float"></div>
			</section>
		</section>
		<div class="clear_float"></div>
		<!--明細表示-->
		<section class="detail_table">
			<!--明細表示ヘッダ-->
			<header>
				<section class="detail_table_header">
					<ul>
					    <li class="select_del_header"></li>
						<li class="blcode_header">BLコード</li>
						<li class="goodsname_header">品名</li>
						<%-- 2017.11.02 案件番号11370090-00 chenyk upd BEGIN --%>
						<li class="goodsdetail_header"  >部品詳細</li>
						<%-- 2017.11.02 案件番号11370090-00 chenyk upd END --%>
						<li class="shipmentcnt_header group1">数量</li>
						<li class="costrate_header group1"><div class="costrate_header_cllic" name="1"><span class="dispable">原価率</span></div></li>
						<li class="salesunitcost_header group1"><div class="costrate_header_cllic" name="1"><span class="dispable">原単価</span></div></li>	
						<li class="salescdnm_header group2">販売区分</li>	
						<li class="answerdelivdate_header group2">回答納期</li>	
						<li class="warehousecode_header group2">倉庫</li>
						<li class="warehouseshelfno_header group2">棚番</li>	
						<li class="select_del_header"></li>
						<li class="goodsno_header">品番</li>
						<li class="goodsmakercd_header">メーカー</li>
						<li class="suppliercd_header">仕入先</li>
						<li class="listpricetaxexcfl_header group1">標準価格</li>							
						<li class="salesrate_header group1">売価率</li>
						<li class="salesunprctaxexcfl_header group1">売単価</li>
						<li class="salesmoneytaxexc_header group1">売上金額</li> 
						<li class="openpricedivnm_header group2">オープン</li>
						<li class="dtlnote_header group2">明細備考</li>
						<li class="shipmentposcnt_header group2">現在庫数</li>	
					</ul>
					<div class="clear_float"></div>
				</section>
			</header>
			<section class="detail_table_body">	
			</section>
			<button id="parts_prevpage" class="page_button prevpage"></button>
			<button id="parts_nextpage" class="page_button nextpage"></button>
		</section>
		<div class="clear_float"></div>
		<section class="big_self_section">
			<section class="customer_slipnote">
				<fieldset class="fieldset1">
					<button  class="slipnote slipnotes">備考1</button>
					<section class="input_memo1">
						<input type="text" name="memo1" maxlength="30" class="text_input maru_inputedit slipnote_input" placeholder="備考1を入力して下さい"/>
					</section>
				</fieldset>
				<fieldset class="fieldset2">
					<section class="customer_slipnote2">
						<button  class="slipnote2 slipnotes">備考2</button>
						<section class="input_memo2">
							<input type="text" name="memo2" maxlength="30" class="text_input maru_inputedit slipnote2_input" placeholder="備考2を入力して下さい"/>
						</section>
					</section>
					<section class="wrapper_deliveredgoodsdiv">
						<label class="deliveredgoodsdiv">納品区分</label>
						<!-- UPD 2014/10/23 yoshioka #43465 №10663 11-1の対応 start -->
						<!--<div class="dropdownlist_container">-->
						<section class="dropdownlist_container">
						<!-- UPD 2014/10/23 yoshioka #43465 №10663 11-1の対応 end -->
						    <button id="deliveredgoodsdiv_dropdownbutton">
								<b class="button_label" id="deliveredgoodsdiv_b_id"></b>
								<img id="deliveredgoodsdiv_img" src="./image/common/dropdown_001.png">
							</button>
							<div id="deliveredgoodsdiv_dropdownsection" class="nodisplay dropdownlist_content">
								<ul id="deliveredgoodsdiv_dropdownsection_ul">		
								</ul>
						    </div>
						<!-- UPD 2014/10/23 yoshioka #43465 №10663 11の対応 start -->
						<!--</div>-->
						</section>
						<!-- UPD 2014/10/23 yoshioka #43465 №10663 11の対応 end -->
					</section>	
			    </fieldset>
				<fieldset class="fieldset3">
					<section class="wrapper_slipnote3">
						<button class="customer_slipnote3 slipnotes">備考3</button>
						<section class="input_memo3">
							<input type="text" name="memo3" maxlength="30" class="text_input maru_inputedit slipnote3_input" placeholder="備考3を入力して下さい"/>	
						</section>
					</section>
					<section class="wrapper_partysaleslipnum">
						<label for="partysaleslipnum_nm" class="partysaleslipnum_header">指示書番号</label>
						<section class="partysaleslipnum_section">
							<input type="text" name="partysaleslipnum_nm"  class="maru_inputedit partysaleslipnum" placeholder="指示書番号を入力して下さい"/>
						</section>
					</section>
				</fieldset>
			</section>
			<section class="total_money">
			    <section class="total_money_tol">	
					<dl class="total_money1">
						<dt class="sale_price_label">売上金額</dt>
						<dd id="sale_price"><span class="marle" id="salestotaltaxexc"></span></dd>
						<dt class="sale_tax_label"><span class="salestotaltax_label">消費税</span></dt>
						<dd id="sale_tax"><span class="marle" id="salestotaltax"></span></dd>
						<dt class="gross_profit_amount_label"><span class="dispable">粗利金額</span></dt>
						<dd id="gross_profit_amount"><span class="marle dispable" id="grossprofit"></span></dd>
						<dt class="cost_amount_label"><span class="dispable">原価金額</span></dt>
						<dd id="cost_amount"><span class="marle dispable" id="totalcost"></span></dd>
					</dl>
					<dl class="total_money2">
						<dt class="total_amount_label">合計金額</dt>
						<dd id="total_amount"><span class="marle" id="salestotaltaxinc"></span></dd>
					</dl>
				</section>
			</section>
		</section>
		<!--ボタン-->
		<section class="command">
			<button class="button_add_goods">
			    部品を追加
				<span class="button_pic1"></span>
			</button>
			<button class="addSalesDiscountRow">
			   行値引を追加
				<span class="button_pic3"></span>
			</button>
			<button class="selectdeletess">
			    削除行を選択
				<span class="button_pic3"></span>
			</button>
			<button class="button_trdelete">
			    行を削除
				<span class="button_pic2"></span>
			</button>
			<button class="finish">
			    削除完了
				<span class="button_pic4"></span>
			</button>
			<button class="goto_button2 sale_button"><span>売上</span></button>
			<button class="goto_button2 order_button"><span>受注</span></button>
		</section>	
	</section>
	<div class="nodisplay dropdownlist_content salescd_dropdownsection">
		<ul class="salescd_dropdownsection_ul">
		</ul>
	</div>
	<div class="nodisplay dropdownlist_content warehouse_dropdownsection">
		<table>
			<tbody>
			</tbody>
		</table>
	</div>
</body>
</html>

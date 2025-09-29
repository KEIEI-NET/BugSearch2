<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pmsetpartsselect.aspx.cs" Inherits="Broadleaf.Web.UI.PMTAB04034W" %>
<!DOCTYPE HTML>
<html>
<%--  プログラム名:セット選択 --%>              
<%--  プログラムID:PMTAB04034W --%>
<head id="Head1" runat ="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
	<meta name="format-detection" content="telephone=no">
	<meta name="apple-mobile-web-app-capable" content="yes">
	
	<script>
		var employeeAuth = '<% Response.Write(employeeAuth); %>';
		var loginUrl = '<% Response.Write(loginUrl); %>';
		var logoutUrl = '<% Response.Write(logoutUrl); %>';
	</script>
	
	<link rel="stylesheet" type="text/css" href="<% Response.Write("./css/common/WebAppCommon.css.aspx?ver=" + Broadleaf.Application.Common.ExtFileVersion.Ver()); %>" />
	<link rel="stylesheet" type="text/css" href="<% Response.Write("./css/common/pmcommon.css?ver=" + Broadleaf.Application.Common.ExtFileVersion.Ver()); %>" />
	<link rel="stylesheet" type="text/css" href="<% Response.Write("./css/stock/pmstockcommon.css?ver=" + Broadleaf.Application.Common.ExtFileVersion.Ver()); %>" />
	<link rel="stylesheet" type="text/css" href="<% Response.Write("./css/stock/pmsetpartsselect.css?ver=" + Broadleaf.Application.Common.ExtFileVersion.Ver()); %>" />
	<%-- 2017.11.02 案件番号11370090-00 chenyk add BEGIN --%>
	<link rel="stylesheet" type="text/css" href="<% Response.Write("./css/stock/pmpartsdetailmodal.css?ver=" + Broadleaf.Application.Common.ExtFileVersion.Ver()); %>" />
	<link rel="stylesheet" type="text/css" href="<% Response.Write("./css/lib/swiper.min.css?ver=" + Broadleaf.Application.Common.ExtFileVersion.Ver()); %>" />
	<%-- 2017.11.02 案件番号11370090-00 chenyk add END --%> 

	<script src="./js/lib/jquery-2.0.0.js"></script>
	<script src="./js/lib/jquery.cookie.js"></script>
	<script src="./js/lib/jquery.json.js"></script>
	<script src="<% Response.Write("./js/common/WebAppCommon.js.aspx?ver=" + Broadleaf.Application.Common.ExtFileVersion.Ver()); %>"></script>
	<script src="<% Response.Write("./js/common/pmcommon.js?ver=" + Broadleaf.Application.Common.ExtFileVersion.Ver()); %>"></script>
	<script src="<% Response.Write("./js/stock/pmstockcommon.js?ver=" + Broadleaf.Application.Common.ExtFileVersion.Ver()); %>"></script>
	<script src="<% Response.Write("./js/stock/PMTAB04034W.js?ver=" + Broadleaf.Application.Common.ExtFileVersion.Ver()); %>"></script>
	<%-- 2017.11.02 案件番号11370090-00 chenyk add BEGIN --%> 
	<script src="<% Response.Write("./js/common/modalwindow.js?ver=" + Broadleaf.Application.Common.ExtFileVersion.Ver()); %>"></script>
	<script src="<% Response.Write("./js/stock/PMTAB04060W.js?ver=" + Broadleaf.Application.Common.ExtFileVersion.Ver()); %>"></script>
	<script src="<% Response.Write("./js/stock/PMTAB04061W.js?ver=" + Broadleaf.Application.Common.ExtFileVersion.Ver()); %>"></script>
	<script src="<% Response.Write("./js/lib/swiper.min.js?ver=" + Broadleaf.Application.Common.ExtFileVersion.Ver()); %>"></script>
	<%-- 2017.11.02 案件番号11370090-00 chenyk add END --%>
	
    <link id="theme" rel="stylesheet" type="text/css"/>
	<link rel="apple-touch-icon-precomposed" href="./image/system.png" />
	<title>セット選択</title>
</head>
<body>
	<nav class="UI_toolbar">
	</nav> 
    <section class="main">
		<section class="info_panel parts_info_panel">
			<header class="message_header">セット部品から対象の部品を選択してください</header>
			<section class="cc_main_content">
				<section class="resizable2">
					<section class="resizable1_content">
					    <section class="table cc_main_goods">				
						    <section class="table_header" id="search_result">
							    <table>
								    <tbody>
									    <tr>
							                <th class="goodsnamewidth">品　名</th>
							                <th class="goodsnowidth">品　番</th>
							                <th class="showcol makerwidth">メーカー</th>
							                <th class="showcol standardpricewidth">標準価格</th>
							                <th class="showcol salespricewidth">売単価</th>
							                <th class="showcol stockwidth">在庫</th>
							                <th class="showcol replacecheckwidth">代替選択</th>
							                <th class="displaynone specialnotewidth">特記事項</th>
							                <th class="displaynone quantitywidth">QTY</th>
							                <th class="displaynone oldpricewidth">原単価</th>
							                <th class="displaynone ratewidth">粗利率</th>
							                <th class="displaynone ratemoneywidth">粗利額</th>
									    </tr> 
								    </tbody>
							    </table>
						    </section>
						    <section id="searchdiv" class="table_body cc_grid_scroll ">
						        <div class="subtitle stringcol">セット親</div>
							    <table id="parentgoodsinfo">
								    <tbody>						   
								    </tbody>
							    </table>
							    <div class="subtitle stringcol">セット子</div>
						        <table id="childgoodsinfo">
								    <tbody>
								    </tbody>
							    </table>
						    </section>
						    <div class="clear_float"></div>
					    </section>
					    <button id="parts_prevpage" class="page_button prevpage displaynone"></button>
					    <button id="parts_nextpage" class="page_button nextpage showcol"></button>
					    <section class="cc_zaiko">
						    <section class="info_panel2 cc_zaiko_info_panel" id="zaikolist">
							    <section class="table_header">
								    <table>
									    <tbody>
										    <tr>
											    <th class="sokoutitlewidth">在庫を管理している倉庫</th>
											    <th class="danabanwidth">棚　番</th>
											    <th class="stockquantitywidth">現在庫数</th>
										    </tr>
									    </tbody>
								    </table>
							    </section>
							    <section class="table_body cc_zaiko_result cc_grid_scroll">
								    <table>
									    <tbody>
									    </tbody>
								    </table>
							    </section>
						    </section>
						    <section id="botton_area" class="cc_zaiko_info_panel">
                                <section class="cc_top_command">
                                    <button class="cc_replace_goods_btn showcol">代替部品選択</button>
								</section>
								<%-- 2017.11.02 案件番号11370090-00 chenyk add BEGIN --%> 
								<section class="cc_top_command_partsdetail">
									<button class="parts_detail_btn"><span>部品詳細</span></button>
								</section>
								<%-- 2017.11.02 案件番号11370090-00 chenyk add END --%>
                                <section class="cc_bottom_command">
							        <button class="goto_button"><span>部品を決定する</span></button>
						        </section>
                            </section>
					    </section>
					</section>
				</section>
                <div class="clear_float"></div>                
			</section>
		</section>
    </section>
</body>
</html>
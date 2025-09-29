<%@ Page Language="C#" MasterPageFile="~/SFCMN00770C.master" AutoEventWireup="true" CodeFile="SFCMN00773W.aspx.cs" Inherits="Broadleaf.Web.UI.SFCMN00773W" StylesheetTheme="Normal" %>

<%@ Register TagPrefix="bl" Namespace="Broadleaf.Web.UI.WebControls" Assembly="__code" %>

<%@ PreviousPageType VirtualPath="~/SFCMN00771W.aspx" %>

<asp:Content ID="SFCMN00773W_content" ContentPlaceHolderID="Body_contentPlaceHolder" runat="Server">
	<asp:ScriptManager ID="SFCMN00773W_scriptManager" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true" />
	
	<%-- メニューバー START --%>
	<div id="menubar">
		<div class="menu">
			<h2><asp:Image ID="SearchTitle_Image" SkinID="SearchTitle_Image" AlternateText="お知らせ検索" runat="server" /></h2>
			<div class="menuitem search_box">
				<ul>
					<li><h3>変更内容</h3>
						<div class="search_item">
							<asp:TextBox ID="ChangeContents_textBox" CssClass="input_keyword" MaxLength="30" runat="server" />
						</div>
					</li>
                    <li><h3>検索対象</h3>
						<div class="search_item" id="mcastInfoDiv">
						    <asp:DropDownList ID="MulticastInfoDivCd_dropDownList" runat="server" />
						</div>
					</li>

					<li id="search_list_printname" style="display: none"><h3>帳票名称</h3>
						<div class="search_item">
							<asp:TextBox ID="PrintName_textBox" CssClass="input_keyword" MaxLength="30" runat="server" />
						</div>
					</li>

					<li id="search_list_multicast_regionnm" style="display: none"><h3>地域(都道府県)</h3>
						<div class="search_item">
							<asp:TextBox ID="Area_textBox" CssClass="input_keyword" MaxLength="30" runat="server" />
						</div>
					</li>

					<li id="search_list_multicast_date" style="display: none"><h3>配信日付</h3>
						<div class="search_item">
							<asp:TextBox ID="StMulticastDate_textBox" MaxLength="10" runat="server" /><asp:Image ID="StMulticastDate_DropDown_image" SkinID="DropDown_image" AlternateText="カレンダー" runat="server" /> から
							<ajaxToolkit:CalendarExtender ID="StMulticastDate_calendarExtender" TargetControlID="StMulticastDate_textBox" PopupButtonID="StMulticastDate_DropDown_image" Format="yyyy/MM/dd" Animated="false" runat="server" />
						</div>
						<div class="search_item">
							<asp:TextBox ID="EdMulticastDate_textBox" MaxLength="10" runat="server" /><asp:Image ID="EdMulticastDate_DropDown_image" SkinID="DropDown_image" AlternateText="カレンダー" runat="server" />
							<ajaxToolkit:CalendarExtender ID="EdMulticastDate_calendarExtender" TargetControlID="EdMulticastDate_textBox" PopupButtonID="EdMulticastDate_DropDown_image" Format="yyyy/MM/dd" Animated="false" runat="server" />
						</div>
						<div class="validator_ctrl">
							<asp:CustomValidator ID="MulticastDate_customValidator" runat="server" 
								ClientValidationFunction="McasDateTimeValidator" 
								OnServerValidate="MulticastDate_ServerValidation" 
								Display="Dynamic" 
								ValidationGroup="SearchGroup" 
								ErrorMessage="日付の入力が不正です。" />
						</div>
					</li>

					<li id="search_list_mainte_date" style="display: none"><h3>メンテナンス予定日付</h3>
						<div class="search_item">
							<asp:TextBox ID="StMainteDate_textBox" MaxLength="10" runat="server" /><asp:Image ID="StMainteDate_DropDown_image" SkinID="DropDown_image" AlternateText="カレンダー" runat="server" /> から
							<ajaxToolkit:CalendarExtender ID="StMainteDate_calendarExtender" TargetControlID="StMainteDate_textBox" PopupButtonID="StMainteDate_DropDown_image" Format="yyyy/MM/dd" Animated="false" runat="server" />
						</div>
						<div class="search_item">
							<asp:TextBox ID="EdMainteDate_textBox" MaxLength="10" runat="server" /><asp:Image ID="EdMainteDate_DropDown_image" SkinID="DropDown_image" AlternateText="カレンダー" runat="server" />
							<ajaxToolkit:CalendarExtender ID="EdMainteDate_calendarExtender" TargetControlID="EdMainteDate_textBox" PopupButtonID="EdMainteDate_DropDown_image" Format="yyyy/MM/dd" Animated="false" runat="server" />
						</div>
						<div class="validator_ctrl">
							<asp:CustomValidator ID="MainteDate_customValidator" runat="server" 
								ClientValidationFunction="MainteDateTimeValidator" 
								OnServerValidate="MulticastDate_ServerValidation" 
								Display="Dynamic" 
								ValidationGroup="SearchGroup" 
								ErrorMessage="日付の入力が不正です。" />
						</div>
					</li>

					<li id="search_list_mcast_rereace_date" style="display: none"><h3>リリース日付</h3>
						<div class="search_item">
							<asp:TextBox ID="StMcastRereaceDate_textBox" MaxLength="10" runat="server" /><asp:Image ID="StMcastRereaceDate_DropDown_image" SkinID="DropDown_image" AlternateText="カレンダー" runat="server" /> から
							<ajaxToolkit:CalendarExtender ID="StMcastRereaceDate_calendarExtender" TargetControlID="StMcastRereaceDate_textBox" PopupButtonID="StMcastRereaceDate_DropDown_image" Format="yyyy/MM/dd" Animated="false" runat="server" />
						</div>
						<div class="search_item">
							<asp:TextBox ID="EdMcastRereaceDate_textBox" MaxLength="10" runat="server" /><asp:Image ID="EdMcastRereaceDate_DropDown_image" SkinID="DropDown_image" AlternateText="カレンダー" runat="server" />
							<ajaxToolkit:CalendarExtender ID="EdMcastRereaceDate_calendarExtender" TargetControlID="EdMcastRereaceDate_textBox" PopupButtonID="EdMcastRereaceDate_DropDown_image" Format="yyyy/MM/dd" Animated="false" runat="server" />
						</div>
						<div class="validator_ctrl">
							<asp:CustomValidator ID="McastRereaceDate_customValidator" runat="server" 
								ClientValidationFunction="McasReDateTimeValidator" 
								OnServerValidate="MulticastDate_ServerValidation" 
								Display="Dynamic" 
								ValidationGroup="SearchGroup" 
								ErrorMessage="日付の入力が不正です。" />
						</div>
					</li>
					
					<li id="search_list_multicast_version" style="display: none"><h3>バージョン</h3>
						<div class="search_item">
							<asp:TextBox ID="StMulticastVersion_textBox" CssClass="input_keyword" maxlength="32" runat="server" /> から
						</div>
						<div class="search_item">
							<asp:TextBox ID="EdMulticastVersion_textBox" CssClass="input_keyword" maxlength="32" runat="server" />
						</div>
						<div class="validator_ctrl">
							<asp:CustomValidator ID="MulticastVersion_customValidator1" runat="server" 
								ClientValidationFunction="VersionValidator" 
								OnServerValidate="MulticastVersion_ServerValidation" 
								Display="Dynamic" 
								ValidationGroup="SearchGroup" 
								ErrorMessage="配信バージョンの入力が不正です。" />
						</div>
					</li>
										
					<li id="search_list_multicast_sysdiv" style="display: none"><h3>システム区分</h3>
						<div class="search_item">
							<asp:DropDownList ID="MulticastSystemDivCd_dropDownList" runat="server" />
						</div>
					</li>
					
					<li id="search_list_multicast_pgname" style="display: none"><h3>プログラム名称</h3>
						<div class="search_item">
							<asp:TextBox ID="MulticastProgramName_textBox" CssClass="input_keyword" MaxLength="30" runat="server" />
						</div>
					</li>
					
					<li class="search_submit">
						<div>
							<asp:CustomValidator ID="Empty_CustomValidator" runat="server" 
								ClientValidationFunction="EmptyValidator" 
								OnServerValidate="InputEmpty_ServerValidation" 
								Display="Dynamic" 
								ValidationGroup="SearchGroup" 
								ErrorMessage="検索条件が指定されていません。" />
						</div>
						
						<asp:ImageButton ID="Search_imageButton" SkinID="Search_imageButton" AlternateText="検索" OnClick="Search_imageButton_Click" ValidationGroup="SearchGroup" runat="server" />
						<asp:ImageButton ID="Clear_imageButton" SkinID="Clear_imageButton" AlternateText="クリア" OnClientClick="javascript: ClearSearchBox();return false;" runat="server" />
						
						<asp:UpdateProgress ID="Searching_updateProgress" runat="server" AssociatedUpdatePanelID="SearchResult_updatePanel" DisplayAfter="0">
						<ProgressTemplate>
						<div class="searching_progress">
							<p>検索中．．．</p>
						</div>
						</ProgressTemplate>
						</asp:UpdateProgress>
					</li>
				</ul>
			</div>
		</div>
		
		<div class="menu">
			<ul>
				<li><asp:ImageButton ID="MenuTopPage_imageButton" SkinID="MenuTopPage_imageButton" AlternateText="トップページ" OnClick="MenuTopPage_imageButton_Click" runat="server" /></li>
			</ul>
		</div>
	</div>
	<%-- メニューバー END --%>
	
	<%-- コンテンツエリア START --%>
	<div id="contents">
		<asp:UpdatePanel ID="SearchResult_updatePanel" UpdateMode="Conditional" runat="server">
		<ContentTemplate>
		
		<%-- 検索結果セクション START --%>
		<asp:Panel id="SearchResult_panel" runat="server" CssClass="section" Visible="false">
			<h2>検索結果</h2>
			<div class="section_contents">
				<%-- 検索結果 0 件時メッセージ表示用 --%>
				<asp:Panel ID="SearchResultMessage_panel" runat="server" Visible="false">
					<p><asp:Literal ID="SearchResultMessage_literal" runat="server" /></p>
				</asp:Panel>
				<%-- 検索結果 表示用リピータ --%>
				<asp:Repeater ID="MulticastInfo_repeater" runat="server" />
			</div>
			
			<hr class="invisible" />
			
			<%-- ページ制御部品 --%>
			<bl:PagingManageControl ID="SearchResult_pagingManageControl" runat="server" OnPageChanged="SearchResult_pagingManageControl_PageChanged" CssClass="align_center" />
		</asp:Panel>
		<%-- 検索結果セクション END --%>
		
		</ContentTemplate>
		<Triggers>
			<asp:AsyncPostBackTrigger ControlID="Search_imageButton" EventName="Click" />
			<asp:AsyncPostBackTrigger ControlID="SearchResult_pagingManageControl" EventName="PageChanged" />
		</Triggers>
		</asp:UpdatePanel>
	</div>
	<%-- コンテンツエリア END --%>
</asp:Content>

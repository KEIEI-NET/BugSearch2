<%@ Page Language="C#" MasterPageFile="~/SFCMN00770C.master" AutoEventWireup="true" CodeFile="SFCMN00771W.aspx.cs" Inherits="Broadleaf.Web.UI.SFCMN00771W" StylesheetTheme="Normal" %>

<asp:Content ID="SFCMN00771W_content" ContentPlaceHolderID="Body_contentPlaceHolder" Runat="Server">
	<%-- メニューバー START --%>
	<asp:ScriptManager id="SFCMN00771W_scriptManager" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true" />
	
	<div id="menubar">
		<div class="menu">
			<ul>
				<li><asp:ImageButton ID="MenuSearch_imageButton" SkinID="MenuSearch_imageButton" AlternateText="お知らせ検索" OnClick="MenuSearch_imageButton_Click" runat="server" /></li>
			</ul>
		</div>
		
		<asp:Panel ID="SearchBox_panel" runat="server" CssClass="menu">
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
						<asp:ImageButton ID="Search_imageButton" SkinID="Search_imageButton" AlternateText="検索" PostBackUrl="~/SFCMN00773W.aspx" ValidationGroup="SearchGroup" runat="server" OnCommand="Search_imageButton_Command" />
						<asp:ImageButton ID="Clear_imageButton" SkinID="Clear_imageButton" AlternateText="クリア" OnClientClick="javascript: ClearSearchBox();return false;" runat="server" />
						<div id="detailsearch_disp" class="search_item" style="display: block">
							<%-- <p><a href="javascript: DetailSearchExpand();void(0);">▼詳細検索</a></p>--%>
							<p><a href="javascript: detailExpand();void(0);">▼詳細検索</a></p>
						</div>
						<div id="simplesearch_disp" class="search_item" style="display: none">
							<p><a href="javascript: simpleExpand();void(0);">▲簡易検索</a></p>
						</div>
					</li>
				</ul>
			</div>
		</asp:Panel>
	</div>
	<%-- メニューバー END --%>

	<%-- コンテンツエリア START --%>
	<div id="contents">
		<%-- 重要なお知らせセクション START --%>
		<asp:Panel ID="ImportantInfo_panel" runat="server" CssClass="section" Visible="false">
			<h2 class="important">重要なお知らせ<asp:Image CssClass="imgnew" ID="ImportantInfo_img" 
			    ImageUrl="./App_Themes/Normal/Images/new_h4.png" AlternateText="new" visible="false" runat="server" /></h2>
			<div class="section_contents">
				<asp:Repeater ID="ImportantInfo_repeater" runat="server" />
			</div>
			<hr class="invisible" />
		</asp:Panel>
		<%-- 重要なお知らせセクション END --%>
		
		<%-- 新着 .NS 配信情報セクション START --%>
		<asp:Panel ID="NewMulticastInfo_panel" runat="server" CssClass="section">
			<h2><a href="javascript: multicastExpand();void(0);" tabindex="99">新着 .NS 配信情報<asp:Image CssClass="imgnew" ID="NewMulticastInfo_img" 
			    ImageUrl="./App_Themes/Normal/Images/new_h4.png" AlternateText="new" visible="false" runat="server" /></a></h2>
			<%-- <h2 id="newMulticast">新着 .NS 配信情報</h2> --%>
			<div class="section_contents" id="multicast" style="display:none">
				<%-- 検索結果 0 件時メッセージ表示用 --%>
				<asp:Panel ID="NothingMulticastInfo_panel" runat="server" Visible="false">
					<p><asp:Literal ID="NothingMulticastInfo_literal" runat="server" /></p>
				</asp:Panel>
				
				<asp:Repeater ID="NewMulticastInfo_repeater" runat="server" />
			</div>
			<hr class="invisible" />
		</asp:Panel>
		<%-- 新着 .NS 配信情報セクション END --%>
		
		<%-- 新着 メンテナンス情報セクション START --%>
		<asp:Panel ID="NewServerMainteInfo_panel" runat="server" CssClass="section">
		    <h2><a href="javascript: serverMainteExpand();void(0);" tabindex="99">新着 メンテナンス情報<asp:Image CssClass="imgnew" ID="NewServerMainteInfo_img" 
			    ImageUrl="./App_Themes/Normal/Images/new_h4.png" AlternateText="new" visible="false" runat="server" /></a></h2>
			<%-- <h2 id="newMainte">新着 メンテナンス情報</h2> --%>
			<div class="section_contents" id="serverMainte" style="display:none">
				<%-- 検索結果 0 件時メッセージ表示用 --%>
				<asp:Panel ID="NothingServerMainteInfo_panel" runat="server" Visible="false">
					<p><asp:Literal ID="NothingServerMainteInfo_literal" runat="server" /></p>
				</asp:Panel>
				
				<asp:Repeater ID="NewServerMainteInfo_repeater" runat="server" />
			</div>
			<hr class="invisible" />
		</asp:Panel>
		<%-- 新着 メンテナンス情報セクション END --%>
		
		<%-- エラーメッセージ表示用 --%>
		<asp:Panel ID="ErrorMessage_panel" runat="server" Visible="false" CssClass="section">
			<p><asp:Literal ID="ErrorMessage_literal" runat="server" /></p>
		</asp:Panel>
	</div>
	<%-- コンテンツエリア END --%>
</asp:Content>
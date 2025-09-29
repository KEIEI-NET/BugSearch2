<%@ Page Language="C#" MasterPageFile="~/SFCMN00770C.master" AutoEventWireup="true" CodeFile="SFCMN00772W.aspx.cs" Inherits="Broadleaf.Web.UI.SFCMN00772W" StylesheetTheme="Normal" %>

<%@ Import Namespace="Broadleaf.Web.UI" %>

<asp:Content ID="SFCMN00772W_content" ContentPlaceHolderID="Body_contentPlaceHolder" Runat="Server">
	<%-- メニューバー START --%>
	<div id="menubar">
		<ul>
			<li><asp:ImageButton ID="MenuTopPage_imageButton" SkinID="MenuTopPage_imageButton" AlternateText="トップページ" OnClick="MenuTopPage_imageButton_Click" runat="server" /></li>
			<li><asp:ImageButton ID="MenuSearch_imageButton" SkinID="MenuSearch_imageButton" AlternateText="お知らせ検索" OnClick="MenuSearch_imageButton_Click" runat="server" /></li>
		</ul>
	</div>
	<%-- メニューバー END --%>
	
	<%-- コンテンツエリア START --%>
	<div id="contents">
		<%-- 検索結果セクション START --%>
		<div id="detail_info" class="section">
		    <asp:Panel ID="MulticastTitle_panel" runat="server" CssClass="section">
			    <h2>.NS配信詳細情報</h2>
			</asp:Panel>
			
			<asp:Panel ID="ServerMainteTitle_panel" runat="server" CssClass="section">
			    <h2>サーバーメンテナンス詳細情報</h2>
			</asp:Panel>
			
			<%-- エラー等メッセージ表示用 --%>
			<asp:Panel ID="MessageInfo_panel" runat="server" CssClass="section_contents" Visible="false">
				<p><asp:Literal ID="MessageInfo_literal" runat="server" /></p>
			</asp:Panel>
			<asp:Panel ID="DetailInfo_panel" runat="server" CssClass="section_contents">
				<asp:Panel ID="MulticastVersion_panel" runat="server" CssClass="sub_section">
				    <h3>バージョン</h3>
					<div class="sub_section_contents">
						<p><asp:Literal ID="MulticastVersion_literal" runat="server" /></p>
					</div>
				</asp:Panel>
						
				<asp:Panel ID="MulticastDate_panel" runat="server" CssClass="sub_section">
					<h3>配信日</h3>
					<div class="sub_section_contents">
						<p><asp:Literal ID="MulticastDate_literal" runat="server" /></p>
					</div>
                </asp:Panel>
						
                <asp:Panel ID="MulticastSystemDivNm_panel" runat="server" CssClass="sub_section">
					<h3>システム区分</h3>
					<div class="sub_section_contents">
						<p><asp:Literal ID="MulticastSystemDivNm_literal" runat="server" /></p>
					</div>
                </asp:Panel>
						
                <asp:Panel ID="MulticastProgramName_panel" runat="server" CssClass="sub_section">
					<h3>配信プログラム</h3>
					<div class="sub_section_contents">
						<p><asp:Literal ID="MulticastProgramName_literal" runat="server" /></p>
					</div>
                </asp:Panel>
				
				<%-- サーバーメンテナンス詳細情報用 START --%>
                <%-- メンテナンス案内文 --%>
				<asp:Panel ID="ServerMainteGidnc_panel" runat="server" CssClass="sub_section">
					<div class="sub_section_contents" runat="server">
						<p><asp:Literal ID="ServerMainteGidnc_literal" runat="server" /></p>
					</div>
				</asp:Panel>

				<asp:Panel ID="ServerMainteDivNm_panel" runat="server" CssClass="sub_section">
					<h3>メンテナンス内容</h3>
					<div class="sub_section_contents">
						<p><asp:Literal ID="ServerMainteDivNm_literal" runat="server" /></p>
					</div>
				</asp:Panel>
						
				<asp:Panel ID="ServerMainteScdl_panel" runat="server" CssClass="sub_section">
					<h3>メンテナンス予定日時</h3>
					<div class="sub_section_contents">
						<p><asp:Literal ID="ServerMainteScdl_literal" runat="server" /></p>
					</div>
				</asp:Panel>
						
				<asp:Panel ID="ServerMainteTime_panel" runat="server" CssClass="sub_section">
					<h3>メンテナンス実施日時</h3>
					<div class="sub_section_contents">
						<p><asp:Literal ID="ServerMainteTime_literal" runat="server" /></p>
					</div>
				</asp:Panel>
				
				<asp:Panel ID="ServerMainteCntnts_panel" runat="server" CssClass="sub_section">
					<h3>メンテナンス詳細内容</h3>
					<div class="sub_section_contents">
						<p><asp:Literal ID="ServerMainteCntnts_literal" runat="server" /></p>
					</div>
				</asp:Panel>
				<%-- サーバーメンテナンス詳細情報用 END --%>

                <asp:Panel ID="ChangeContents_panel" runat="server" CssClass="sub_section">
					<h3>変更内容</h3>
					<div class="sub_section_contents">
						<p><asp:Literal ID="ChangeContents_literal" runat="server" /></p>
					</div>
                </asp:Panel>

				<asp:Panel id="AnothersheetFile_panel" runat="server" CssClass="sub_section">
					<h3>別紙ファイル</h3>
					<div class="sub_section_contents">
						<p>
							<asp:Repeater ID="AnothersheetFile_repeater" runat="server">
								<ItemTemplate>
									<a href="javascript: window.open('<%# Container.DataItem %>');void(0);"><img src="Images/another_paper_24.png" alt="別紙ファイル" /></a>
								</ItemTemplate>
							</asp:Repeater>
						</p>
					</div>
				</asp:Panel>
				
				<asp:Panel id="MulticastOthreInfo_panel" runat="server" CssClass="sub_section">
					<h3>当配信のその他の配信内容</h3>
					<div class="sub_section_contents">
						<ul class="dtl_malticast_info">
						<asp:Repeater ID="MulticastOthreInfo_repeater" runat="server">
						<ItemTemplate>
							<li><dl class="dtl_multicast_system_div">
									<dt>システム</dt>
									<dd><%# Eval( SFCMN00771WB.ctColumnName_SystemDivNm ) %>/<%# Eval( SFCMN00771WB.ctColumnName_McastGidncNewCustmNm ) %></dd>
								</dl>
								<dl class="dtl_multicast_pg_name">
									<dt>配信プログラム</dt>
									<dd><a href="<%# Eval( SFCMN00771WB.ctColumnName_DetailPageUrl ) %>"><%# Eval( SFCMN00771WB.ctColumnName_Guidance1 ) %></a></dd>
							</dl></li>
						</ItemTemplate>
						</asp:Repeater>
						</ul>
					</div>
				</asp:Panel>
				
			</asp:Panel>
			<hr />
		</div>
		<%-- 検索結果セクション END --%>
	</div>
	<%-- コンテンツエリア END --%>
</asp:Content>


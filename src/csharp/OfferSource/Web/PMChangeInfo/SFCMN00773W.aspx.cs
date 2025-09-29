using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Web.UI.WebControls;

// Global.aspx アクセス用
using Globals = ASP.global_asax;

namespace Broadleaf.Web.UI
{
	public partial class SFCMN00773W : System.Web.UI.Page
	{
		#region << Private Constant >>
		
		#region ■URL

		/// <summary>トップページURL</summary>
		private const string ctTopPageUrl            = "SFCMN00771W.aspx";
		/// <summary>.NS 配信詳細情報URL</summary>
		private const string ctMulticastDetailUrl    = "SFCMN00772W.aspx";
		/// <summary>.NS 配信情報検索URL</summary>
		private const string ctMulticastSearchUrl    = "SFCMN00773W.aspx";
		/// <summary>メンテナンス詳細情報URL</summary>
		//private const string ctServerMainteDetailUrl = "SFCMN00774W.aspx";
		/// <summary>別紙格納フォルダURL</summary>
		private const string ctAnotherSheetsDirUrl   = "AnotherSheets/";

		/// <summary>クライアントスクリプトURL</summary>
        // 2007.12.18 Maki Add & Change --------------------------------------------->>>>>
		private const string ctClientScriptUrl          = "SFCMN00771W.js"; //Change
        private const string ctClientSearchBoxScriptUrl = "SFCMN00773W.js"; //ADD
        // --------------------------------------------------------------------------<<<<<

		#endregion

		#region ■検索条件 ViewState 保存キー

		/// <summary>検索条件 ViewState 保存キー：変更内容</summary>
		private const string ctSearchKey_SearchKey_ChangeContents       = "SearchKey_ChangeContents";
		/// <summary>検索条件 ViewState 保存キー：開始配信日</summary>
		private const string ctSearchKey_SearchKey_StMulticastDate      = "SearchKey_StMulticastDate";
		/// <summary>検索条件 ViewState 保存キー：終了配信日</summary>
		private const string ctSearchKey_SearchKey_EdMulticastDate      = "SearchKey_EdMulticastDate";
		/// <summary>検索条件 ViewState 保存キー：開始配信バージョン</summary>
		private const string ctSearchKey_SearchKey_StMulticastVersion   = "SearchKey_StMulticastVersion";
		/// <summary>検索条件 ViewState 保存キー：終了配信バージョン</summary>
		private const string ctSearchKey_SearchKey_EdMulticastVersion   = "SearchKey_EdMulticastVersion";
		/// <summary>検索条件 ViewState 保存キー：配信システム区分</summary>
		private const string ctSearchKey_SearchKey_MulticastSystemDivCd = "SearchKey_MulticastSystemDivCd";
		/// <summary>検索条件 ViewState 保存キー：配信プログラム名称</summary>
		private const string ctSearchKey_SearchKey_MulticastProgramName = "SearchKey_MulticastProgramName";
        // 2007.12.20 Maki Add ------------------------------------------------------------------------------->>>>>
        /// <summary>検索条件 ViewState 保存キー：検索範囲</summary>
        private const string ctSearchKey_SearchKey_McastGidncCntntsCd   = "SearchKey_McastGidncCntntsCd";
        /// <summary>検索条件 ViewState 保存キー：地域</summary>
        private const string ctSearchKey_SearchKey_Area                 = "SearchKey_Area";
        /// <summary>検索条件 ViewState 保存キー：帳票名称</summary>
        private const string ctSearchKey_SearchKey_PrintName            = "SearchKey_PrintName";
        /// <summary>検索条件 ViewState 保存キー：開始サーバーメンテ予定日</summary>
        private const string ctSearchKey_SearchKey_StServerMainteScdl   = "SearchKey_StServerMainteScdl";
        /// <summary>検索条件 ViewState 保存キー：終了サーバーメンテ予定日</summary>
        private const string ctSearchKey_SearchKey_EdServerMainteScdl   = "SearchKey_EdServerMainteScdl";
        // ---------------------------------------------------------------------------------------------------<<<<<

		#endregion

		#region ■メッセージ表示用テキスト

		/// <summary>メッセージ表示用テキスト「該当の情報が見つかりませんでした。」</summary>
		private const string ctMessage_NoData = "該当の情報が見つかりませんでした。";
		/// <summary>メッセージ表示用テキスト「ページを作成中にエラーが発生しました。」</summary>
		private const string ctmessage_Error  = "ページを作成中にエラーが発生しました。";

		#endregion

		/// <summary>ページ内最大アイテム数</summary>
		private const int ctMaxItemInPage = 10;

		/// <summary>変更内容最大表示文字数</summary>
		private const int ctMaxChangeContentsLength = 120;

		#endregion

		#region << Private Members >>

		/// <summary>変更PG案内検索部品</summary>
		private ChangeInfoSearchManager _changeInfoSearchManager = null;

		/// <summary>プログラム配信案内検索パラメータ</summary>
		private ChangGidncParaWork _changGidncParaWork = null;

		/// <summary>ログ出力部品</summary>
		private ChangePgGuideLogOutPut  _changePgGuideLogOutPut  = null;

		#endregion

		#region << Private Methods >>

		#region ■画面初期表示処理

		/// <summary>
		/// 画面初期表示処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面の初期表示処理を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.02.20</br>
		/// </remarks>
		private void ScreenInitialize()
		{
			// システム区分初期設定
			this.MulticastSystemDivCd_dropDownList.Items.Clear();
			this.MulticastSystemDivCd_dropDownList.Items.Add( new ListItem( "選択しない", "-1" ) );
            // 2007.12.14 Maki Change -------------------------------------------------------------------------------------------->>>>>
            //foreach( int multicastSystemDivCd in Enum.GetValues( typeof( ConstantManagement_NS_MGD.MulticastSystemDiv_SF ) ) ) {
            foreach (int multicastSystemDivCd in Enum.GetValues(typeof(ConstantManagement_NS_MGD.SystemDiv)))
            // -------------------------------------------------------------------------------------------------------------------<<<<<
            {
                this.MulticastSystemDivCd_dropDownList.Items.Add( 
					new ListItem( ConstantManagement_NS_MGD.GetMulticastSystemDivNm( ConstantManagement_NS_MGD.ProductCode.PM, multicastSystemDivCd ), 
						multicastSystemDivCd.ToString( "0" ) ) );
			}
            // 2007.12.18 Maki Add ---------------------------------------------------------------------------------------------------------------->>>>>
            // 検索範囲初期設定
            this.MulticastInfoDivCd_dropDownList.Items.Clear();
            foreach ( int multicastInfoDivCd in Enum.GetValues( typeof( ConstantManagement_NS_MGD.McastGidncCntntsCd ) ) )
            {
                if ( multicastInfoDivCd != 0 ) {
                    this.MulticastInfoDivCd_dropDownList.Items.Add(
                        new ListItem( ConstantManagement_NS_MGD.GetMcastGidncCntntsCdNm( multicastInfoDivCd ),
                            multicastInfoDivCd.ToString( "0" ) ) );
                }
            }
            this.MulticastInfoDivCd_dropDownList.Items.Add( new ListItem( "全て", "0" ) );
            // ------------------------------------------------------------------------------------------------------------------------------------<<<<<

			// IME制御
			this.ChangeContents_textBox.Style.Add(      "ime-mode", "active" );
            this.StMulticastDate_textBox.Style.Add(     "ime-mode", "disabled" );
			this.EdMulticastDate_textBox.Style.Add(     "ime-mode", "disabled" );
            this.StMcastRereaceDate_textBox.Style.Add(  "ime-mode", "disabled" );
            this.EdMcastRereaceDate_textBox.Style.Add(  "ime-mode", "disabled" );
            this.StMainteDate_textBox.Style.Add(        "ime-mode", "disabled");
            this.EdMainteDate_textBox.Style.Add(        "ime-mode", "disabled");
            this.StMulticastVersion_textBox.Style.Add(  "ime-mode", "disabled");
			this.EdMulticastVersion_textBox.Style.Add(  "ime-mode", "disabled" );
			this.MulticastProgramName_textBox.Style.Add("ime-mode", "active" );
            // 2007.12.18 Maki Add ---------------------------------------------->>>>>
            this.Area_textBox.Style.Add(                "ime-mode", "active" );
            this.PrintName_textBox.Style.Add(           "ime-mode", "active" );
            // ------------------------------------------------------------------<<<<<

			// 画面クリア
			this.ScreenClear();
		}

		#endregion

		#region ■画面クリア処理

		/// <summary>
		/// 画面クリア処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面のクリアを行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.02.27</br>
		/// </remarks>
		private void ScreenClear()
		{
			// 配信日初期設定
			DateTime stDeliveryDate = DateTime.Now.Date.AddDays( -7 );
			DateTime edDeliveryDate = DateTime.Now.Date.AddDays( 7 );

			// 配信バージョン
			this.StMulticastVersion_textBox.Text = "";
			this.EdMulticastVersion_textBox.Text = "";

			// システム区分
			this.MulticastSystemDivCd_dropDownList.SelectedIndex = 0;

			// 入替プログラム名称キーワード
			this.MulticastProgramName_textBox.Text = "";
            
            // 2007.12.18 Maki ADD ------------------------------->>>>>
            // 案内区分
            this.MulticastInfoDivCd_dropDownList.SelectedIndex = 0;
            // 地域
            this.Area_textBox.Text = "";
            // 帳票名称
            this.PrintName_textBox.Text = "";
            // ---------------------------------------------------<<<<<
        }

		#endregion

		#region ■クライアントスクリプト登録処理

		/// <summary>
		/// クライアントスクリプト登録処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : クライアントスクリプトの登録を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.02.21</br>
		/// </remarks>
		private void RegisterClientScripts()
		{
			const string ctClientIDScriptKey                = "ClientIDScript";
            // 2007.12.18 Maki Add & Change ---------------------------------------->>>>>
            const string ctIncludeClientScriptKey           = "SFCMN00771W.js"; //ADD
            const string ctIncludeClientSearchBoxScriptKey  = "SFCMN00773W.js"; //Change
            // ---------------------------------------------------------------------<<<<<

			ClientScriptManager cs = this.ClientScript;
			Type csType = this.GetType();

			// 外部スクリプトの登録
            // 2007.12.18 Maki Change ------------------------------------------------------------------------------->>>>>
            //if( ! cs.IsClientScriptIncludeRegistered( csType, ctIncludeClientScriptKey ) ) {
            //    // スクリプトが未登録
            //    cs.RegisterClientScriptInclude( csType, ctIncludeClientScriptKey, ctClientScriptUrl );
            //}
            // 画面展スクリプト
            if (!this.ClientScript.IsClientScriptIncludeRegistered(csType, ctIncludeClientScriptKey))
            {
                // スクリプトが未登録
                this.ClientScript.RegisterClientScriptInclude(csType, ctIncludeClientScriptKey, ctClientScriptUrl);
            }
            // 検索Box用
            if (!cs.IsClientScriptIncludeRegistered(csType, ctIncludeClientSearchBoxScriptKey))
            {
                // スクリプトが未登録
                cs.RegisterClientScriptInclude(csType, ctIncludeClientSearchBoxScriptKey, ctClientSearchBoxScriptUrl);
            }
            // ------------------------------------------------------------------------------------------------------<<<<<

			// 初期登録 クライアントスクリプト を登録
			if( ! cs.IsStartupScriptRegistered( csType, ctClientIDScriptKey ) ) {
				StringBuilder clientScript = new StringBuilder();
				clientScript.AppendLine( "<script type='text/javascript'>" );
				// ↓クライアント用 ID を登録
				clientScript.AppendFormat( "var ID_ChangeContents_textBox = '{0}';",            this.ChangeContents_textBox.ClientID );
				clientScript.AppendFormat( "var ID_StMulticastDate_textBox = '{0}';",           this.StMulticastDate_textBox.ClientID );
				clientScript.AppendFormat( "var ID_EdMulticastDate_textBox = '{0}';",           this.EdMulticastDate_textBox.ClientID );
                clientScript.AppendFormat( "var ID_StMcastRereaceDate_textBox = '{0}';",        this.StMcastRereaceDate_textBox.ClientID );
                clientScript.AppendFormat( "var ID_EdMcastRereaceDate_textBox = '{0}';",        this.EdMcastRereaceDate_textBox.ClientID );
                clientScript.AppendFormat( "var ID_StMainteDate_textBox = '{0}';",              this.StMainteDate_textBox.ClientID );
                clientScript.AppendFormat( "var ID_EdMainteDate_textBox = '{0}';",              this.EdMainteDate_textBox.ClientID );
                clientScript.AppendFormat( "var ID_StMulticastVersion_textBox = '{0}';",        this.StMulticastVersion_textBox.ClientID );
				clientScript.AppendFormat( "var ID_EdMulticastVersion_textBox = '{0}';",        this.EdMulticastVersion_textBox.ClientID );
				clientScript.AppendFormat( "var ID_MulticastSystemDivCd_dropDownList = '{0}';", this.MulticastSystemDivCd_dropDownList.ClientID );
				clientScript.AppendFormat( "var ID_MulticastProgramName_textBox = '{0}';",      this.MulticastProgramName_textBox.ClientID );
				clientScript.AppendFormat( "var ID_Search_imageButton = '{0}';",                this.Search_imageButton.ClientID );
				clientScript.AppendFormat( "var ID_Searching_updateProgress = '{0}';",          this.Searching_updateProgress.ClientID );
                // 2007.12.18 Maki Add ------------------------------------------------------------------------------------------------------>>>>>
                clientScript.AppendFormat( "var ID_MulticastInfoDivCd_dropDownList = '{0}';",   this.MulticastInfoDivCd_dropDownList.ClientID);
                clientScript.AppendFormat( "var ID_Area_textBox = '{0}';",                      this.Area_textBox.ClientID);
                clientScript.AppendFormat( "var ID_PrintName_textBox = '{0}';",                 this.PrintName_textBox.ClientID);

                clientScript.Append( "DtlSearchMcasExpand( ID_MulticastInfoDivCd_dropDownList );" );
                // --------------------------------------------------------------------------------------------------------------------------<<<<<

				// フォーカス移動制御登録
                // 2007.12.19 Maki ----------------------------------------------------------------------------------------------------------------------------------------------->>>>>
                /* DEL
				clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', '{1}' );", this.ChangeContents_textBox.ClientID, this.StMulticastDate_textBox.ClientID );
				clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', '{1}' );", this.StMulticastDate_textBox.ClientID, this.EdMulticastDate_textBox.ClientID );
				clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', '{1}' );", this.EdMulticastDate_textBox.ClientID, this.StMulticastVersion_textBox.ClientID );
				clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', '{1}' );", this.StMulticastVersion_textBox.ClientID, this.EdMulticastVersion_textBox.ClientID );
				clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', '{1}' );", this.EdMulticastVersion_textBox.ClientID, this.MulticastSystemDivCd_dropDownList.ClientID );
				clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', '{1}' );", this.MulticastSystemDivCd_dropDownList.ClientID, this.MulticastProgramName_textBox.ClientID );
				clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', '{1}' );", this.MulticastProgramName_textBox.ClientID, this.Search_imageButton.ClientID );
				clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', '{1}' );", this.Search_imageButton.ClientID, this.Clear_imageButton.ClientID );
				clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', '{1}' );", this.Clear_imageButton.ClientID, this.ChangeContents_textBox.ClientID );
                */
                // ADD
                clientScript.AppendFormat( "RegistKeyDownEvent( '{0}' );", this.ChangeContents_textBox.ClientID );
                clientScript.AppendFormat( "RegistKeyDownEvent( '{0}' );", this.MulticastInfoDivCd_dropDownList.ClientID );
                clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', 'search_list_printname' );", this.PrintName_textBox.ClientID );
                clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', 'search_list_multicast_regionnm' );", this.Area_textBox.ClientID );
                clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', 'search_list_multicast_date' );", this.StMulticastDate_textBox.ClientID);
                clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', 'search_list_multicast_date' );", this.EdMulticastDate_textBox.ClientID );
                clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', 'search_list_mcast_rereace_date' );", this.StMcastRereaceDate_textBox.ClientID );
                clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', 'search_list_mcast_rereace_date' );", this.EdMcastRereaceDate_textBox.ClientID );
                clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', 'search_list_mainte_date' );", this.StMainteDate_textBox.ClientID );
                clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', 'search_list_mainte_date' );", this.EdMainteDate_textBox.ClientID );
                clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', 'search_list_multicast_version' );", this.StMulticastVersion_textBox.ClientID );
                clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', 'search_list_multicast_version' );", this.EdMulticastVersion_textBox.ClientID );
                clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', 'search_list_multicast_sysdiv' );", this.MulticastSystemDivCd_dropDownList.ClientID );
                clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', 'search_list_multicast_pgname' );", this.MulticastProgramName_textBox.ClientID );
                clientScript.AppendFormat( "RegistKeyDownEvent( '{0}' );", this.Search_imageButton.ClientID );
                clientScript.AppendFormat( "RegistKeyDownEvent( '{0}' );", this.Clear_imageButton.ClientID );
                // ---------------------------------------------------------------------------------------------------------------------------------------------------------------<<<<<

				// 非同期 PostBack の開始・終了イベントの登録(メソッド本体は 外部スクリプトで定義
				clientScript.Append( "var prm = Sys.WebForms.PageRequestManager.getInstance();" );
				clientScript.Append( "prm.add_initializeRequest( InitializeRequest );" );
				clientScript.Append( "prm.add_endRequest( EndRequest );" );
				clientScript.Append( "var postBackElement;" );

				clientScript.AppendLine( "</script>" );

				cs.RegisterStartupScript( csType, ctClientIDScriptKey, clientScript.ToString() );
			}
		}

		#endregion

		#region ■クロスページポスティングデータ設定処理

		/// <summary>
		/// クロスページポスティングデータ設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : クロスページポスティングを行った際に、移動前ページのコントロール値を現在のページに設定します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
		private void SetCrossPagePostingData()
		{
			if( this.PreviousPage == null ) {
				return;
			}

			this.ChangeContents_textBox.Text                        = this.PreviousPage.ChangeContentsTextBox.Text;
			this.StMulticastDate_textBox.Text                       = this.PreviousPage.StMulticastDateTextBox.Text;
			this.EdMulticastDate_textBox.Text                       = this.PreviousPage.EdMulticastDateTextBox.Text;
			this.StMulticastVersion_textBox.Text                    = this.PreviousPage.StMulticastVersionTextBox.Text;
			this.EdMulticastVersion_textBox.Text                    = this.PreviousPage.EdMulticastVersionTextBox.Text;
			this.MulticastSystemDivCd_dropDownList.SelectedIndex    = this.PreviousPage.MulticastSystemDivCdDropDownList.SelectedIndex;
			this.MulticastProgramName_textBox.Text                  = this.PreviousPage.MulticastProgramNameTextBox.Text;
            // 2007.12.20 Maki Add ------------------------------------------------------------------------------------------------>>>>>
            this.MulticastInfoDivCd_dropDownList.SelectedIndex      = this.PreviousPage.MulticastInfoDivCdDropDownList.SelectedIndex;
            this.Area_textBox.Text                                  = this.PreviousPage.AreaTextBox.Text;
            this.PrintName_textBox.Text                             = this.PreviousPage.PrintNameTextBox.Text;
            this.StMcastRereaceDate_textBox.Text                    = this.PreviousPage.StMcastRereaceDateTextBox.Text;
            this.EdMcastRereaceDate_textBox.Text                    = this.PreviousPage.EdMcastRereaceDateTextBox.Text;
            this.StMainteDate_textBox.Text                          = this.PreviousPage.StMainteDateTextBox.Text;
            this.EdMainteDate_textBox.Text                          = this.PreviousPage.EdMainteDateTextBox.Text;
            // --------------------------------------------------------------------------------------------------------------------<<<<<
		}

		#endregion

		#region ■入力情報検索パラメータクラス格納処理

		/// <summary>
		/// 入力情報検索パラメータクラス格納処理
		/// </summary>
        /// <param name="changGidncParaWork">変更案内検索パラメータクラス</param>
		/// <remarks>
		/// <br>Note       : 画面の入力値を変更案内検索パラメータクラスに格納します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.07</br>
        /// <br></br>
        /// <br>UpDateTime : 2007.12.20</br>
        /// <br>UpDateNote : 23013 牧　将人 検索条件の追加</br>
		/// </remarks>
		private void SetInputDataToPgMulcasGdParaWork( ref ChangGidncParaWork changGidncParaWork )
		{
			if( changGidncParaWork == null ) {
				changGidncParaWork = new ChangGidncParaWork();
			}

			// 変更内容
			string[] changeContentsArray = this.ChangeContents_textBox.Text.Split( ' ', '　', '\t' );
			List<string> changeContentsList = new List<string>();
			foreach( string changeContents in changeContentsArray ) {
				if( ! String.IsNullOrEmpty( changeContents ) ) {
					changeContentsList.Add( changeContents );
				}
			}
			changGidncParaWork.ChangeContents       = changeContentsList.ToArray();
            //// 配信日
            //DateTime stMulticastDate;
            //if( DateTime.TryParse( this.StMulticastDate_textBox.Text, out stMulticastDate ) ) {
            //    changGidncParaWork.StMulticastDate  = stMulticastDate;
            //}
            //else {
            //    changGidncParaWork.StMulticastDate  = DateTime.MinValue;
            //}
            //DateTime edMulticastDate;
            //if( DateTime.TryParse( this.EdMulticastDate_textBox.Text, out edMulticastDate ) ) {
            //    changGidncParaWork.EdMulticastDate  = edMulticastDate;
            //}
            //else {
            //    changGidncParaWork.EdMulticastDate  = DateTime.MinValue;
            //}
            // 2007.12.20 Maki Add ------------------------------------------------------------------------------------->>>>>
            // 検索範囲
            int mcastGidncCntntsCd = 0;
            if ( Int32.TryParse( this.MulticastInfoDivCd_dropDownList.SelectedValue, out mcastGidncCntntsCd ) ) {

                if ( mcastGidncCntntsCd == 0 ) {
                    changGidncParaWork.McastGidncCntntsCd = -1;
                    changGidncParaWork.McastGidncMainteCd = 2;
                }
                else if ( mcastGidncCntntsCd == 2 ) {
                    changGidncParaWork.McastGidncCntntsCd = mcastGidncCntntsCd;
                    changGidncParaWork.McastGidncMainteCd = 2;
                }
                else {
                    changGidncParaWork.McastGidncCntntsCd = mcastGidncCntntsCd;
                }
            }
            else {
                changGidncParaWork.McastGidncCntntsCd = -1;
                changGidncParaWork.McastGidncMainteCd = 2;
            }
            //string[] chgAreaContentsArray = this.Area_textBox.Text.Split( ' ', '　', '\t' );
            //List<string> chgAreaContentsList = new List<string>();
            //foreach ( string chgAreaContents in chgAreaContentsArray )
            //{
            //    if ( ! String.IsNullOrEmpty( chgAreaContents ) )
            //    {
            //        chgAreaContentsList.Add( chgAreaContents );
            //    }
            //}
            int multicastSystemDivCd = 0;
            switch ( mcastGidncCntntsCd )
            //switch ( this.MulticastInfoDivCd_dropDownList.SelectedIndex )
            {
                case 1:
                    // 配信日
                    DateTime stMulticastDate;
                    if (DateTime.TryParse(this.StMulticastDate_textBox.Text, out stMulticastDate))
                    {
                        changGidncParaWork.StMulticastDate = stMulticastDate;
                    }
                    else
                    {
                        changGidncParaWork.StMulticastDate = DateTime.MinValue;
                    }
                    DateTime edMulticastDate;
                    if (DateTime.TryParse(this.EdMulticastDate_textBox.Text, out edMulticastDate))
                    {
                        changGidncParaWork.EdMulticastDate = edMulticastDate;
                    }
                    else
                    {
                        changGidncParaWork.EdMulticastDate = DateTime.MinValue;
                    }
                    // 配信バージョン
                    changGidncParaWork.StMulticastVersionZeroSup = this.StMulticastVersion_textBox.Text;
                    changGidncParaWork.EdMulticastVersionZeroSup = this.EdMulticastVersion_textBox.Text;
                    // 配信システム区分
                    if ( Int32.TryParse( this.MulticastSystemDivCd_dropDownList.SelectedValue, out multicastSystemDivCd ) ) {
                        changGidncParaWork.MulticastSystemDivCd = multicastSystemDivCd;
                    }
                    else {
                        changGidncParaWork.MulticastSystemDivCd = -1;
                    }
                    // 配信プログラム名称
                    changGidncParaWork.MulticastProgramName = this.MulticastProgramName_textBox.Text.Trim();
                    // 地域
                    changGidncParaWork.Area                 = "";
                    break;
                case 2:
                    // サーバーメンテ予定日時 :TODO
                    DateTime stMainteDate;
                    if (DateTime.TryParse(this.StMainteDate_textBox.Text, out stMainteDate)) {
                    //if (DateTime.TryParse(this.StMainteDate_textBox.Text, out stMainteDate)) {
                        //long aaa = (long)TDateTime.DateTimeToLongDate(stMainteDate) * 10000L;
                        changGidncParaWork.StServerMainteScdl = (long)TDateTime.DateTimeToLongDate(stMainteDate) * 10000L;
                    }
                    else {
                        changGidncParaWork.StServerMainteScdl = 0;
                    }
                    DateTime edMainteDate;
                    if (DateTime.TryParse(this.EdMainteDate_textBox.Text, out edMainteDate)) {
                        //long aaa = (long)TDateTime.DateTimeToLongDate(edMainteDate) * 10000L + 9999L;
                        changGidncParaWork.EdServerMainteScdl = (long)TDateTime.DateTimeToLongDate(edMainteDate) * 10000L + 9999L;
                    }
                    else {
                        changGidncParaWork.EdServerMainteScdl = Int64.MaxValue;
                    }
                    break;
                case 3:
                    // リリース日
                    DateTime stMcastReDate;
                    if ( DateTime.TryParse( this.StMcastRereaceDate_textBox.Text, out stMcastReDate ) ) {
                        changGidncParaWork.StMulticastDate = stMcastReDate;
                    }
                    else {
                        changGidncParaWork.StMulticastDate = DateTime.MinValue;
                    }
                    DateTime edMcastReDate;
                    if ( DateTime.TryParse( this.EdMcastRereaceDate_textBox.Text, out edMcastReDate ) ) {
                        changGidncParaWork.EdMulticastDate = edMcastReDate;
                    }
                    else {
                        changGidncParaWork.EdMulticastDate = DateTime.MinValue;
                    }
                    // 配信バージョン
                    changGidncParaWork.StMulticastVersionZeroSup = "";
                    changGidncParaWork.EdMulticastVersionZeroSup = "";
                    // 配信システム区分
                    if ( Int32.TryParse( this.MulticastSystemDivCd_dropDownList.SelectedValue, out multicastSystemDivCd ) ) {
                        changGidncParaWork.MulticastSystemDivCd = multicastSystemDivCd;
                    }
                    else {
                        changGidncParaWork.MulticastSystemDivCd = -1;
                    }
                    // 帳票名称
                    changGidncParaWork.MulticastProgramName = this.PrintName_textBox.Text.Trim();
                    // 地域
                    changGidncParaWork.Area                 = this.Area_textBox.Text.Trim();
                    break;
                default:
                    // 配信バージョン
                    changGidncParaWork.StMulticastVersionZeroSup = "";
                    changGidncParaWork.EdMulticastVersionZeroSup = "";
                    // 配信システム区分
                    changGidncParaWork.MulticastSystemDivCd = -1;
                    // プログラム名称
                    changGidncParaWork.MulticastProgramName = "";
                    // 地域
                    changGidncParaWork.Area                 = "";
                    break;
            }

            //string[] chgPrintNmContentsArray = this.PrintName_textBox.Text.Split(' ', '　', '\t');
            //List<string> chgPrintNmContentsList = new List<string>();
            //foreach (string chgPrintNmContents in chgPrintNmContentsArray)
            //{
            //    if (!String.IsNullOrEmpty(chgPrintNmContents))
            //    {
            //        chgPrintNmContentsList.Add(chgPrintNmContents);
            //    }
            //}
            // ---------------------------------------------------------------------------------------------------------<<<<<
		}

		#endregion

		#region ■変更案内検索パラメータ ViewState 保存処理

		/// <summary>
		/// 変更案内検索パラメータ ViewState 保存処理
		/// </summary>
        /// <param name="changGidncParaWork">変更案内検索パラメータクラス</param>
		/// <remarks>
		/// <br>Note       : 変更案内検索パラメータをViweStateに保存します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.14</br>
        /// <br></br>
        /// <br>UpDateTime : 2007.12.20</br>
        /// <br>UpdateNote : 23013 牧　将人 検索条件の追加, メソッド名の変更</br>
		/// </remarks>
        //private void SetPgMulcasGdParaWorkToViewState( ChangGidncParaWork pgMulcasGdParaWork )
        private void SetChangGidncParaWorkToViewState(ChangGidncParaWork changGidncParaWork)
		{
            if ( changGidncParaWork == null ) {
				return;
			}

			// 変更内容
            this.ViewState[ ctSearchKey_SearchKey_ChangeContents        ] = changGidncParaWork.ChangeContents;
			// 配信日
            this.ViewState[ ctSearchKey_SearchKey_StMulticastDate       ] = changGidncParaWork.StMulticastDate;
            this.ViewState[ ctSearchKey_SearchKey_EdMulticastDate       ] = changGidncParaWork.EdMulticastDate;
			// 配信バージョン
            this.ViewState[ ctSearchKey_SearchKey_StMulticastVersion    ] = changGidncParaWork.StMulticastVersion;
            this.ViewState[ ctSearchKey_SearchKey_EdMulticastVersion    ] = changGidncParaWork.EdMulticastVersion;
			// 配信システム区分
            this.ViewState[ ctSearchKey_SearchKey_MulticastSystemDivCd  ] = changGidncParaWork.MulticastSystemDivCd;
			// 配信プログラム名称
            this.ViewState[ ctSearchKey_SearchKey_MulticastProgramName  ] = changGidncParaWork.MulticastProgramName;
            // 2007.12.20 Maki Add -------------------------------------------------------------------------------------->>>>>
            // 検索範囲
            this.ViewState[ ctSearchKey_SearchKey_McastGidncCntntsCd    ] = changGidncParaWork.McastGidncCntntsCd;
            // 地域
            this.ViewState[ ctSearchKey_SearchKey_Area                  ] = changGidncParaWork.Area;
            // 帳票名称
            this.ViewState[ ctSearchKey_SearchKey_PrintName             ] = changGidncParaWork.MulticastProgramName;
            // サーバーメンテ予定日
            this.ViewState[ ctSearchKey_SearchKey_StServerMainteScdl    ] = changGidncParaWork.StServerMainteScdl;
            this.ViewState[ ctSearchKey_SearchKey_EdServerMainteScdl    ] = changGidncParaWork.EdServerMainteScdl;
            // ----------------------------------------------------------------------------------------------------------<<<<<
		}

		#endregion

		#region ■変更案内検索パラメータ ViewState 取得処理

		/// <summary>
		/// 変更案内検索パラメータ ViewState 取得処理
		/// </summary>
        /// <param name="changGidncParaWork">変更案内検索パラメータクラス</param>
		/// <remarks>
		/// <br>Note       : 変更案内検索パラメータをViweStateから取得します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.14</br>
        /// <br></br>
        /// <br>UpDateTime : 2007.12.20</br>
        /// <br>UpdateNote : 23013 牧　将人 検索条件の追加, メソッド名の変更</br>
        /// </remarks>
        //private void GetPgMulcasGdParaWorkFromViewState( ref ChangGidncParaWork pgMulcasGdParaWork ) 
        private void GetChangGidncParaWorkFromViewState( ref ChangGidncParaWork changGidncParaWork )
		{
			if( changGidncParaWork == null ) {
				changGidncParaWork = new ChangGidncParaWork();
			}

			// 変更内容
			changGidncParaWork.ChangeContents       = ( string[] )( this.ViewState[ ctSearchKey_SearchKey_ChangeContents       ] ?? new string[ 0 ] );
			// 配信日
			changGidncParaWork.StMulticastDate      = ( DateTime )( this.ViewState[ ctSearchKey_SearchKey_StMulticastDate      ] ?? DateTime.MinValue );
			changGidncParaWork.EdMulticastDate      = ( DateTime )( this.ViewState[ ctSearchKey_SearchKey_EdMulticastDate      ] ?? DateTime.MinValue );
			// 配信バージョン
			changGidncParaWork.StMulticastVersion   = ( string   )( this.ViewState[ ctSearchKey_SearchKey_StMulticastVersion   ] ?? String.Empty );
			changGidncParaWork.EdMulticastVersion   = ( string   )( this.ViewState[ ctSearchKey_SearchKey_EdMulticastVersion   ] ?? String.Empty );
			// 配信システム区分
			changGidncParaWork.MulticastSystemDivCd = ( int      )( this.ViewState[ ctSearchKey_SearchKey_MulticastSystemDivCd ] ?? -1 );
			// 配信プログラム名称
			changGidncParaWork.MulticastProgramName = ( string   )( this.ViewState[ ctSearchKey_SearchKey_MulticastProgramName ] ?? String.Empty );
            // 2007.12.20 Maki Add ------------------------------------------------------------------------------------------------------------------------->>>>>
            // 検索範囲
            changGidncParaWork.McastGidncCntntsCd   = ( int      )( this.ViewState[ ctSearchKey_SearchKey_McastGidncCntntsCd   ] ?? -1 );
            // 地域
            changGidncParaWork.Area                 = ( string   )( this.ViewState[ ctSearchKey_SearchKey_Area                 ] ?? new string[ 0 ] );
            // 帳票名称
            changGidncParaWork.MulticastProgramName = ( string   )( this.ViewState[ctSearchKey_SearchKey_PrintName             ] ?? new string[ 0 ] );
            // サーバーメンテ予定日
            changGidncParaWork.StServerMainteScdl   = ( long     )( this.ViewState[ ctSearchKey_SearchKey_StServerMainteScdl   ] ?? 0 );
            changGidncParaWork.EdServerMainteScdl   = ( long     )( this.ViewState[ ctSearchKey_SearchKey_EdServerMainteScdl   ] ?? 0 );
            // ---------------------------------------------------------------------------------------------------------------------------------------------<<<<<
		}

		#endregion

		#region ■.NS 配信情報検索処理

		/// <summary>
		/// .NS 配信情報検索処理
		/// </summary>
        /// <param name="changGidncParaWork">プログラム配信案内検索パラメータクラス</param>
		/// <remarks>
		/// <br>Note       : .NS配信情報の検索を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.02.20</br>
		/// </remarks>
        private int SearchMulticastInfo( ChangGidncParaWork changGidncParaWork )
		{
			int status = ( int )ConstantManagement.DB_Status.ctDB_ERROR;

			DataSet ds = new DataSet();
            SFCMN00771WB.CreateChangGidncDataSet(ref ds);

			List<ChangGidncWork> changGidncWorkList = new List<ChangGidncWork>();
			List<ChgGidncDtWork> chgGidncDtWorkList = new List<ChgGidncDtWork>();

			// 検索部品インスタンス生成
			if( this._changeInfoSearchManager == null ) {
				this._changeInfoSearchManager = new ChangeInfoSearchManager();
			}

			string errMsg     = "";           // エラーメッセージ
			int    totalCount = 0;

			int searchIndex = this.SearchResult_pagingManageControl.CurrentPageIndex * ctMaxItemInPage;

			status = this._changeInfoSearchManager.SearchChangGidnc( Globals.QueryStringController.AccessTicket, changGidncParaWork, searchIndex, ctMaxItemInPage, out totalCount, out changGidncWorkList, out chgGidncDtWorkList, out errMsg );
            if ( status == 0 && changGidncParaWork.McastGidncCntntsCd == 2 ) {
                int count = 0;
                foreach ( ChangGidncWork changGidncWork in changGidncWorkList )
                {
                    if (changGidncWork.McastGidncMainteCd == 2) {
                        count++;
                    }
                }
                if(count == 0) {
                    status = ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
			switch( status ) {
				// 該当データ有り
				case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					// 検索結果領域を表示
					this.SearchResult_panel.Visible        = true;
					// メッセージ表示用テキストボックスを非表示
					this.SearchResultMessage_panel.Visible = false;
					// 検索結果表示リピータを表示
					this.MulticastInfo_repeater.Visible    = true;

					// ページ制御コントロールの値をセット
					this.SearchResult_pagingManageControl.TotalPageCount = ( totalCount - 1 ) / ctMaxItemInPage + 1;
					// 複数ページの場合はコントロールを表示し、そうでない場合は表示しない。
					this.SearchResult_pagingManageControl.Visible = ( this.SearchResult_pagingManageControl.TotalPageCount > 1 );

                    foreach ( ChangGidncWork wkChangGidncWork in changGidncWorkList ) {
                        // 2007.12.20 Maki Change ------------------------------------>>>>>
                        //this.AddPgMulcasGdWorkToDataSet( ds, wkChangGidncWork );
                        this.AddChangGidncWorkToDataSet( ds, wkChangGidncWork );
                        // -----------------------------------------------------------<<<<<
					}
                    foreach ( ChgGidncDtWork wkChgGidncDtWorkList in chgGidncDtWorkList ) {
                        // 2007.12.20 Maki Change ------------------------------------>>>>>
                        //this.AddPgMulcsGdDWorkToDataSet( ds, wkChgGidncDtWorkList );
                        this.AddChgGidncDtWorkListToDataSet( ds, wkChgGidncDtWorkList );
                        // -----------------------------------------------------------<<<<<
					}
					
					this.MulticastInfo_repeater.DataSource = ds;
					this.MulticastInfo_repeater.DataMember = SFCMN00771WB.ctTableName_ChangeGidncRoot;
					// データバインド
					this.MulticastInfo_repeater.DataBind();
					break;
				}
				// 該当データなし
				case ( int )ConstantManagement.DB_Status.ctDB_EOF:
				case ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND:
				{
					// 検索結果領域を表示
					this.SearchResult_panel.Visible               = true;
					// メッセージ表示用テキストボックスを表示
					this.SearchResultMessage_panel.Visible        = true;
					// 検索結果表示リピータを非表示
					this.MulticastInfo_repeater.Visible           = false;
					// ページ管理コントロールを非表示
					this.SearchResult_pagingManageControl.Visible = false;

					// 該当データなしメッセージを表示
					this.SearchResultMessage_literal.Text  = ctMessage_NoData;

					status = ( int )ConstantManagement.DB_Status.ctDB_EOF;
					break;
				}
				// エラー
				default:
				{
					throw( new NSChangeInfoErrorException( status, errMsg ) );
				}
			}

			return status;
		}

		#endregion

		#region ■プログラム配信案内ワーククラスDataSet格納処理

		/// <summary>
		/// プログラム配信案内ワーククラスDataSet格納処理
		/// </summary>
		/// <param name="ds">格納対象DataSet</param>
		/// <param name="changGidncWork">プログラム配信案内ワーククラス</param>
		/// <remarks>
		/// <br>Note       : 指定されたプログラム配信案内ワーククラスをDataSet内のテーブルに格納します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.07</br>
        /// </remarks>
        //private void AddPgMulcasGdWorkToDataSet( DataSet ds, ChangGidncWork changGidncWork )
        private void AddChangGidncWorkToDataSet( DataSet ds, ChangGidncWork changGidncWork )
		{
			// プログラム配信案内ルートテーブルを取得
            DataTable dtChangGidncRoot = null;
			if( ds.Tables.Contains( SFCMN00771WB.ctTableName_ChangeGidncRoot ) ) {
                dtChangGidncRoot = ds.Tables[SFCMN00771WB.ctTableName_ChangeGidncRoot];
			}
			// プログラム配信案内テーブルを取得
            DataTable dtChangGidnc = null;
			if( ds.Tables.Contains( SFCMN00771WB.ctTableName_ChangeGidnc ) ) {
                dtChangGidnc = ds.Tables[SFCMN00771WB.ctTableName_ChangeGidnc];
			}

			// テーブルの取得に失敗した場合は処理を行わない
			if( ( dtChangGidncRoot == null ) || ( dtChangGidnc == null ) ) {
				return;
			}
			
			// プログラム配信案内ルートテーブルに登録されていない場合
            object[] changGidncRootKey = new object[] {
                changGidncWork.McastGidncCntntsCd,          // 案内内容区分
				changGidncWork.ProductCode,                 // パッケージ区分
                changGidncWork.McastGidncVersionCdZeroSup,  // 配信バージョン
				changGidncWork.McastOfferDivCd,             // 配信提供区分
				changGidncWork.UpdateGroupCode,             // 更新グループコード
				changGidncWork.EnterpriseCode               // 企業コード
			};
			if( ! dtChangGidncRoot.Rows.Contains( changGidncRootKey ) &&
                ! (changGidncWork.McastGidncCntntsCd == 2 && changGidncWork.McastGidncMainteCd != 2))
            {
				// プログラム配信案内ルートテーブルに新規登録
                DataRow drChangGidncRoot = dtChangGidncRoot.NewRow();

                // 2008.01.07 Maki Add ------------------------------------------------------------------------------->>>>>
                // 案内内容区分
                drChangGidncRoot[ SFCMN00771WB.ctColumnName_McastGidncCntntsCd  ] = changGidncWork.McastGidncCntntsCd;
                // ---------------------------------------------------------------------------------------------------<<<<<
				// パッケージ区分
				drChangGidncRoot[ SFCMN00771WB.ctColumnName_ProductCode         ] = changGidncWork.ProductCode;
				// 配信提供区分
				drChangGidncRoot[ SFCMN00771WB.ctColumnName_McastOfferDivCd     ] = changGidncWork.McastOfferDivCd;
				// 更新グループコード
				drChangGidncRoot[ SFCMN00771WB.ctColumnName_UpdateGroupCode     ] = changGidncWork.UpdateGroupCode;
				// 企業コード
				drChangGidncRoot[ SFCMN00771WB.ctColumnName_EnterpriseCode      ] = changGidncWork.EnterpriseCode;
				// 配信バージョン
				drChangGidncRoot[ SFCMN00771WB.ctColumnName_McastGidncVersionCd ] = changGidncWork.McastGidncVersionCdZeroSup;
				// 配信日
				drChangGidncRoot[ SFCMN00771WB.ctColumnName_MulticastDate       ] = changGidncWork.MulticastDate;
				// サポート公開日時
				drChangGidncRoot[ SFCMN00771WB.ctColumnName_SupportOpenTime     ] = this.LongDateToDateTime( changGidncWork.SupportOpenTime );
				// ユーザー公開日時
				drChangGidncRoot[ SFCMN00771WB.ctColumnName_CustomerOpenTime    ] = this.LongDateToDateTime( changGidncWork.CustomerOpenTime );
                // 2008.01.07 Maki Add -------------------------------------------------------------------------------------------------------------------------------------------------->>>>>
                //
                string serverMainteOutputMessage = "";
                switch ( changGidncWork.McastGidncCntntsCd )
                {
                    case 2:
                        // メンテナンス予定
                        if ( ( changGidncWork.ServerMainteStTime == 0 ) &&
                            ( changGidncWork.ServerMainteEdTime == 0 ) )
                        {
                            // メンテナンス終了予定が入っていない場合
                            if ( changGidncWork.ServerMainteEdScdl == 0 )
                            {
                                serverMainteOutputMessage =
                                    String.Format( "{0} より、{1}を実施いたします。",
                                    this.GetDateTimeString( changGidncWork.ServerMainteStScdl, true ),
                                    ConstantManagement_NS_MGD.GetServerMainteDivNm( changGidncWork.McastGidncMainteCd ) );
                            }
                            else
                            {
                                serverMainteOutputMessage =
                                    String.Format( "{0} から {1} まで、{2}を実施いたします。",
                                    this.GetDateTimeString( changGidncWork.ServerMainteStScdl, true ),
                                    this.GetDateTimeString( changGidncWork.ServerMainteEdScdl, true ),
                                    ConstantManagement_NS_MGD.GetServerMainteDivNm( changGidncWork.McastGidncMainteCd ) );
                            }
                        }
                        // メンテナンス中
                        else if ( ( changGidncWork.ServerMainteStTime != 0 ) &&
                            ( changGidncWork.ServerMainteEdTime == 0 ) )
                        {
                            // メンテナンス終了予定が入っていない場合
                            if ( changGidncWork.ServerMainteEdScdl == 0 )
                            {
                                serverMainteOutputMessage =
                                    String.Format( "ただいま、{0}を実施しております。",
                                    ConstantManagement_NS_MGD.GetServerMainteDivNm( changGidncWork.McastGidncMainteCd ) );
                            }
                            else
                            {
                                serverMainteOutputMessage =
                                    String.Format( "ただいま、{0}を実施しております。終了時刻は、{1} を予定しております。",
                                    ConstantManagement_NS_MGD.GetServerMainteDivNm( changGidncWork.McastGidncMainteCd ),
                                    this.GetDateTimeString( changGidncWork.ServerMainteEdScdl, true ) );
                            }
                        }
                        // メンテナンス終了
                        else
                        {
                            serverMainteOutputMessage = String.Format( "{0}は、{1} に終了致しました。",
                                ConstantManagement_NS_MGD.GetServerMainteDivNm( changGidncWork.McastGidncMainteCd ),
                                this.GetDateTimeString( changGidncWork.ServerMainteEdTime, true ) );
                        }
                        break;
                    default:
                        break;
                }
                // 配信案内 メンテ区分
                drChangGidncRoot[ SFCMN00771WB.ctColumnName_McastGidncMainteCd          ] = changGidncWork.McastGidncMainteCd;
                // 配信案内 メンテ区分名称
                drChangGidncRoot[ SFCMN00771WB.ctColumnName_McastGidncMainteNm          ] = ConstantManagement_NS_MGD.GetServerMainteDivNm(changGidncWork.McastGidncMainteCd);
                // サーバーメンテナンス出力メッセージ
                drChangGidncRoot[ SFCMN00771WB.ctColumnName_ServerMainteOutputMessage   ] = serverMainteOutputMessage;
                // 配信プログラム名称(サーバーメンテナンス内容)
                drChangGidncRoot[ SFCMN00771WB.ctColumnName_Guidance1                   ] = changGidncWork.Guidance1;
                // 詳細ページURL
                drChangGidncRoot[ SFCMN00771WB.ctColumnName_DetailPageUrl               ] = this.CreateMulticastDetailUrl(
                    changGidncWork.McastGidncVersionCd, changGidncWork.MulticastConsNo, changGidncWork.McastGidncCntntsCd, changGidncWork.SystemDivCd);
                // ----------------------------------------------------------------------------------------------------------------------------------------------------------------------<<<<<

				// テーブルに追加
				dtChangGidncRoot.Rows.Add( drChangGidncRoot );
			}

            // プログラム配信案内テーブルに登録されていない場合
            object[] changGidncKey = new object[] {
                changGidncWork.McastGidncCntntsCd,          // 案内内容区分
				changGidncWork.ProductCode,                 // パッケージ区分
                changGidncWork.McastGidncVersionCdZeroSup,  // 配信バージョン
				changGidncWork.McastOfferDivCd,             // 配信提供区分
				changGidncWork.UpdateGroupCode,             // 更新グループコード
				changGidncWork.EnterpriseCode,              // 企業コード
                changGidncWork.MulticastConsNo              // 連番
			};
            if (!dtChangGidnc.Rows.Contains(changGidncKey))
            {
                // プログラム配信案内テーブルに新規登録
                DataRow drChangGidnc = dtChangGidnc.NewRow();

                // 2008.01.07 Maki Add ------------------------------------------------------------------------------->>>>>
                // 案内内容区分
                drChangGidnc[ SFCMN00771WB.ctColumnName_McastGidncCntntsCd   ] = changGidncWork.McastGidncCntntsCd;
                // ---------------------------------------------------------------------------------------------------<<<<<
                // パッケージ区分
                drChangGidnc[ SFCMN00771WB.ctColumnName_ProductCode         ] = changGidncWork.ProductCode;
                // 配信提供区分
                drChangGidnc[ SFCMN00771WB.ctColumnName_McastOfferDivCd     ] = changGidncWork.McastOfferDivCd;
                // 更新グループコード
                drChangGidnc[ SFCMN00771WB.ctColumnName_UpdateGroupCode     ] = changGidncWork.UpdateGroupCode;
                // 企業コード
                drChangGidnc[ SFCMN00771WB.ctColumnName_EnterpriseCode      ] = changGidncWork.EnterpriseCode;
                // 配信バージョン
                drChangGidnc[ SFCMN00771WB.ctColumnName_McastGidncVersionCd ] = changGidncWork.McastGidncVersionCdZeroSup;
                // 配信連番
                drChangGidnc[ SFCMN00771WB.ctColumnName_MulticastConsNo     ] = changGidncWork.MulticastConsNo;
                // プログラム変更区分
                drChangGidnc[ SFCMN00771WB.ctColumnName_McastGidncNewCustmCd] = changGidncWork.McastGidncNewCustmCd;
                // プログラム変更区分名称
                // 2007.12.14 Maki Change ------------------------------------------------------------------------------------------------------------------------>>>>>
                //drChangGidnc[ SFCMN00771WB.ctColumnName_ProgramChgDivNm ] = ConstantManagement_NS_MGD.GetProgramChgDivNm( changGidncWork.McastGidncNewCustmCd );
                drChangGidnc[ SFCMN00771WB.ctColumnName_McastGidncNewCustmNm] = ConstantManagement_NS_MGD.GetMcastGidncNewCustmCdNm(changGidncWork.McastGidncNewCustmCd);
                // -----------------------------------------------------------------------------------------------------------------------------------------------<<<<<
                // 配信システム区分
                drChangGidnc[ SFCMN00771WB.ctColumnName_SystemDivCd         ] = changGidncWork.SystemDivCd;
                // 配信システム区分名称
                drChangGidnc[ SFCMN00771WB.ctColumnName_SystemDivNm         ] = ConstantManagement_NS_MGD.GetMulticastSystemDivNm(changGidncWork.ProductCode, changGidncWork.SystemDivCd);
                // 配信プログラム名称
                drChangGidnc[ SFCMN00771WB.ctColumnName_Guidance1           ] = changGidncWork.Guidance1;
                // 地域
                drChangGidnc[ SFCMN00771WB.ctColumnName_Area                ] = changGidncWork.Area;
                // 詳細ページURL
                // 2007.12.20 Maki Change ----------------------------------------------------------------------------------------------------------------------------------------------->>>>>
                //drChangGidnc[ SFCMN00771WB.ctColumnName_DetailPageUrl ] = this.CreateMulticastDetailUrl( changGidncWork.McastGidncVersionCd, changGidncWork.MulticastConsNo );
                drChangGidnc[ SFCMN00771WB.ctColumnName_DetailPageUrl       ] = this.CreateMulticastDetailUrl(
                    changGidncWork.McastGidncVersionCd, changGidncWork.MulticastConsNo, changGidncWork.McastGidncCntntsCd, changGidncWork.SystemDivCd);
                // ----------------------------------------------------------------------------------------------------------------------------------------------------------------------<<<<<

                dtChangGidnc.Rows.Add(drChangGidnc);
            }
		}

		#endregion

		#region ■プログラム配信案内明細ワーククラスDataSet格納処理

		/// <summary>
		/// プログラム配信案内明細ワーククラスDataSet格納処理
		/// </summary>
		/// <param name="ds">格納対象DataSet</param>
		/// <param name="chgGidncDtWork">プログラム配信案内明細ワーククラス</param>
		/// <remarks>
		/// <br>Note       : 指定されたプログラム配信案内明細ワーククラスをDataSet内のテーブルに格納します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.07</br>
        /// </remarks>
        //private void AddPgMulcsGdDWorkToDataSet( DataSet ds, ChgGidncDtWork chgGidncDtWork )
        private void AddChgGidncDtWorkListToDataSet( DataSet ds, ChgGidncDtWork chgGidncDtWork )
		{
			// プログラム配信案内明細テーブルを取得
            DataTable dtChgGidncDt = null;
			if( ds.Tables.Contains( SFCMN00771WB.ctTableName_ChgGidncDt ) ) {
                dtChgGidncDt = ds.Tables[SFCMN00771WB.ctTableName_ChgGidncDt];
			}

			// テーブルの取得に失敗した場合は処理を行わない
			if( dtChgGidncDt == null ) {
				return;
			}
			
			// プログラム配信案内明細テーブルに新規登録
            DataRow drChgGidncDt = dtChgGidncDt.NewRow();

            // 2008.01.07 Maki Add -------------------------------------------------------------------------------->>>>>
            // 案内内容区分
            drChgGidncDt[ SFCMN00771WB.ctColumnName_McastGidncCntntsCd   ] = chgGidncDtWork.McastGidncCntntsCd;
            // ----------------------------------------------------------------------------------------------------<<<<<
			// パッケージ区分
			drChgGidncDt[ SFCMN00771WB.ctColumnName_ProductCode          ] = chgGidncDtWork.ProductCode;
			// 配信提供区分
			drChgGidncDt[ SFCMN00771WB.ctColumnName_McastOfferDivCd      ] = chgGidncDtWork.McastOfferDivCd;
			// 更新グループコード
			drChgGidncDt[ SFCMN00771WB.ctColumnName_UpdateGroupCode      ] = chgGidncDtWork.UpdateGroupCode;
			// 企業コード
			drChgGidncDt[ SFCMN00771WB.ctColumnName_EnterpriseCode       ] = chgGidncDtWork.EnterpriseCode;
			// 配信バージョン
			drChgGidncDt[ SFCMN00771WB.ctColumnName_McastGidncVersionCd  ] = chgGidncDtWork.McastGidncVersionCdZeroSup;
			// 配信連番
			drChgGidncDt[ SFCMN00771WB.ctColumnName_MulticastConsNo      ] = chgGidncDtWork.MulticastConsNo;
			// 配信サブコード
			drChgGidncDt[ SFCMN00771WB.ctColumnName_MulticastSubCode     ] = chgGidncDtWork.MulticastSubCode;
			// 変更内容
			drChgGidncDt[ SFCMN00771WB.ctColumnName_ChangeContents       ] = chgGidncDtWork.ChangeContents;
			// 別紙ファイル有無区分
			drChgGidncDt[ SFCMN00771WB.ctColumnName_AnothersheetFileExst ] = chgGidncDtWork.AnothersheetFileExst;
			// 別紙ファイル名
			drChgGidncDt[ SFCMN00771WB.ctColumnName_AnothersheetFileName ] = ctAnotherSheetsDirUrl + chgGidncDtWork.AnothersheetFileName;
			
			dtChgGidncDt.Rows.Add( drChgGidncDt );
		}

		#endregion

		#region ■日時文字列取得処理

		/// <summary>
		/// LongDate⇒DateTime変換処理
		/// </summary>
		/// <param name="longDate">LongDate(YYYYMMDDHHmm)</param>
		/// <returns>DateTime</returns>
		/// <remarks>
		/// <br>Note       : LongDate(YYYYMMDDHHmm)をDateTimeに変換します。</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
		private DateTime LongDateToDateTime( long longDate )
		{
			DateTime dateTime = DateTime.MinValue;

			try {
				int yy = ( int )( longDate / 100000000 );
				int MM = ( int )( ( longDate % 100000000 ) / 1000000 );
				int dd = ( int )( ( longDate % 1000000 ) / 10000 );
				int HH = ( int )( ( longDate % 10000 ) / 100 );
				int mm = ( int )( longDate % 100 );

				// データ不正チェック
				dateTime = new DateTime( yy, MM, dd, HH, mm, 0 );
			}
			catch {
				dateTime = DateTime.MinValue;
			}

			return dateTime;
		}

		/// <summary>
		/// 日時文字列取得処理
		/// </summary>
		/// <param name="dateTime">日時値(YYYYMMDDHHmm)</param>
		/// <param name="zeroSuppress">ゼロサプレス(true:ゼロサプレスする, false:ゼロサプレスしない)</param>
		/// <returns>日時文字列</returns>
		/// <remarks>
		/// <br>Note       : 日時文字列の取得を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
		private string GetDateTimeString( DateTime dateTime, bool zeroSuppress )
		{
			StringBuilder dateTimeString = new StringBuilder();

			if( zeroSuppress ) {
				dateTimeString.Append( TDateTime.DateTimeToString( "YYYYmmdd", dateTime, "" ) );
				dateTimeString.Append( " " );
				dateTimeString.Append( TDateTime.DateTimeToString( "hhmm", dateTime, "" ) );
			}
			else {
				dateTimeString.Append( TDateTime.DateTimeToString( "YYYYMMDD", dateTime, "" ) );
				dateTimeString.Append( " " );
				dateTimeString.Append( TDateTime.DateTimeToString( "HHMM", dateTime, "" ) );
			}

			return dateTimeString.ToString();
		}

		/// <summary>
		/// 日時文字列取得処理
		/// </summary>
		/// <param name="longDate">LongDate(YYYYMMDDHHmm)</param>
		/// <param name="zeroSuppress">ゼロサプレス(true:ゼロサプレスする, false:ゼロサプレスしない)</param>
		/// <returns>日時文字列</returns>
		/// <remarks>
		/// <br>Note       : 日時文字列の取得を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
		private string GetDateTimeString( long longDate, bool zeroSuppress )
		{
			return this.GetDateTimeString( this.LongDateToDateTime( longDate ), zeroSuppress );
		}

		#endregion

		#region ■詳細情報URL作成処理

		/// <summary>
		/// 詳細情報URL作成処理
		/// </summary>
		/// <param name="multicastVersion">配信バージョン</param>
		/// <param name="multicastConsNo">配信連番</param>
        /// <param name="mcastGidncCntntsCd">案内区分(検索範囲)</param>
        /// <param name="systemDivCd">システム区分</param>
		/// <returns>詳細情報URL</returns>
		/// <remarks>
		/// <br>Note       : .NS 配信詳細情報のURLを作成します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.02.19</br>
        /// <br></br>
        /// <br>Note       : クエリ項目を追加 メソッド引数を追加</br>
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2007.12.20</br>
        /// </remarks>
        //private string CreateMulticastDetailUrl( string multicastVersion, int multicastConsNo )
        private string CreateMulticastDetailUrl(string multicastVersion, int multicastConsNo, int mcastGidncCntntsCd, int systemDivCd)
		{
            QueryStringController query = new QueryStringController();
            query.AccessTicket          = Globals.QueryStringController.AccessTicket;
            query.MulticastVersion      = multicastVersion;
            query.MulticastConsNo       = multicastConsNo;
            // 2007.12.20 Maki Add -------------------------------------->>>>>
            query.McastGidncCntntsCd    = mcastGidncCntntsCd;
            query.SystemDivCd           = systemDivCd;
            // ----------------------------------------------------------<<<<<
            return ctMulticastDetailUrl + query.ToString();
        }

		#endregion

		#region ■エラーメッセージ作成処理

		/// <summary>
		/// エラーメッセージ作成処理
		/// </summary>
		/// <param name="ex">例外オブジェクト</param>
		/// <param name="status">ステータス</param>
		/// <returns>エラーメッセージ</returns>
		/// <remarks>
		/// <br>Note       : エラーメッセージの作成を行い、HTML Encoding を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.14</br>
		/// </remarks>
		private string CreateErrorMessage( Exception ex, int status )
		{
			if( ex == null ) {
				return this.CreateErrorMessage( "", status );
			}
			else {
				return this.CreateErrorMessage( ex.Message, status );
			}
		}

		/// <summary>
		/// エラーメッセージ作成処理
		/// </summary>
		/// <param name="message">エラーメッセージ</param>
		/// <param name="status">ステータス</param>
		/// <returns>エラーメッセージ</returns>
		/// <remarks>
		/// <br>Note       : エラーメッセージの作成を行い、HTML Encoding を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.14</br>
		/// </remarks>
		private string CreateErrorMessage( string message, int status )
		{
			StringBuilder errorMsg = new StringBuilder( ctmessage_Error );

			// エラーメッセージ有り
			if( ! String.IsNullOrEmpty( message ) ) {
				// エラーメッセージを追加
				errorMsg.Append( "\r\n" + message.TrimEnd() );
			}

			// ステータス有り
			if( status != 0 ) {
				errorMsg.AppendFormat( " ST={0}", status );
			}

			// HTML Encoding を行い、改行を <br /> に変換
			return HttpUtility.HtmlEncode( errorMsg.ToString() ).Replace( "\r\n", "<br />" );
		}

		#endregion

        #endregion

		#region << Control Events >>

		#region ■Load イベント (SFCMN00773W)

		/// <summary>
		/// Load イベント (SFCMN00773W)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ページがロード されるときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.02.20</br>
		/// </remarks>
		protected void Page_Load( object sender, EventArgs e )
		{
			// ログ書き込み部品を初期化
			this._changePgGuideLogOutPut = new ChangePgGuideLogOutPut();

			// クライアントスクリプトを登録
			this.RegisterClientScripts();

            // 2007.12.18 Maki Add ------------------------------------------------------------>>>>>
            // 変更区分 onchangeイベント追加
            this.MulticastInfoDivCd_dropDownList.Attributes.Add("onchange",
                "DtlSearchMcasExpand( ID_MulticastInfoDivCd_dropDownList );");
            // --------------------------------------------------------------------------------<<<<<
            
            // 変更案内検索パラメータ 初期化
			this._changGidncParaWork = null;

			// ポストバック時またはクロスページポスティング時
			if( this.IsPostBack ) {

				// 非同期ポストバック
				if( this.SFCMN00773W_scriptManager.IsInAsyncPostBack ) {
				}
				// 通常ポストバック
				else {
				}
			}
			// クロスページポスティング
			else if( this.PreviousPage != null ) {
				if( ! this.PreviousPage.IsValid ) {
					// 検証NG
					return;
				}

				// クロスページポスティング時はコントロール値をコピー

				// ページを初期化
				this.ScreenInitialize();

				// ページ制御コントロールを初期化
				this.SearchResult_pagingManageControl.CurrentPageIndex = 0;

				// コントロール値をコピー
				this.SetCrossPagePostingData();

				// 入力値を取得
				this.SetInputDataToPgMulcasGdParaWork( ref this._changGidncParaWork );

                // 検索条件を ViewState に保存
                // 2007.12.20 Maki Change ----------------------------------------->>>>>
                //this.SetPgMulcasGdParaWorkToViewState(this._changGidncParaWork);
                this.SetChangGidncParaWorkToViewState(this._changGidncParaWork);
                // ----------------------------------------------------------------<<<<<
			}
			// 初回時(初期値をセット
			else {
				// ページを初期化
				this.ScreenInitialize();
			}

			// 検索条件がセットされた場合
			if( this._changGidncParaWork != null ) {
				// 検索結果 Repeater コントロールのアイテムテンプレート(詳細モード)をセット
				this.MulticastInfo_repeater.ItemTemplate = new SFCMN00771WC( SFCMN00771WC.TemplateMode.Detail, ctMaxChangeContentsLength );
				// .NS 配信情報検索
				this.SearchMulticastInfo( this._changGidncParaWork );
			}
            //変更内容にフォーカスをセット
            this.ChangeContents_textBox.Focus();
		}

		#endregion 

		#region ■Click イベント (Search_imageButton)

		/// <summary>
		/// Click イベント (Search_imageButton)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : コントロールがクリックされたときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.02.27</br>
		/// </remarks>
		protected void Search_imageButton_Click( object sender, ImageClickEventArgs e )
		{
			if( ! Page.IsValid ) {
				// 検証NG
				return;
			}

			// ページ制御コントロールを初期化
			this.SearchResult_pagingManageControl.CurrentPageIndex = 0;

			// 入力値を取得
			this.SetInputDataToPgMulcasGdParaWork( ref this._changGidncParaWork );

            // 検索条件を ViewState に保存
            // 2007.12.20 Maki Change ----------------------------------------->>>>>
            //this.SetPgMulcasGdParaWorkToViewState(this._changGidncParaWork);
            this.SetChangGidncParaWorkToViewState( this._changGidncParaWork );
            // ----------------------------------------------------------------<<<<<

			// 検索条件がセットされた場合
            if ( this._changGidncParaWork != null ) {
				// 検索結果 Repeater コントロールのアイテムテンプレート(詳細モード)をセット
				this.MulticastInfo_repeater.ItemTemplate = new SFCMN00771WC( SFCMN00771WC.TemplateMode.Detail, ctMaxChangeContentsLength );
				// .NS 配信情報検索
				this.SearchMulticastInfo( this._changGidncParaWork );
			}
		}

		#endregion

		#region ■PageChanged イベント (SearchResult_pagingManageControl)

		/// <summary>
		/// PageChanged イベント (SearchResult_pagingManageControl)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ページが変更されたときに発生します。。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.19</br>
		/// </remarks>
		protected void SearchResult_pagingManageControl_PageChanged( object sender, PageChangedEventArgs e )
		{
            // 検索条件を ViewState から取得
            // 2007.12.20 Maki Change ----------------------------------------------->>>>>
            //this.GetPgMulcasGdParaWorkFromViewState(ref this._changGidncParaWork);
            this.GetChangGidncParaWorkFromViewState( ref this._changGidncParaWork );
            // ----------------------------------------------------------------------<<<<<

			// 検索条件がセットされた場合
			if( this._changGidncParaWork != null ) {
				// 検索結果 Repeater コントロールのアイテムテンプレート(詳細モード)をセット
				this.MulticastInfo_repeater.ItemTemplate = new SFCMN00771WC( SFCMN00771WC.TemplateMode.Detail, ctMaxChangeContentsLength );
				// .NS 配信情報検索
				this.SearchMulticastInfo( this._changGidncParaWork );
			}
		}

		#endregion

		#region ■Click イベント (MenuTopPage_imageButton)

		/// <summary>
		/// Click イベント (MenuTopPage_imageButton)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : コントロールがクリックされたときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.02.20</br>
		/// </remarks>
		protected void MenuTopPage_imageButton_Click( object sender, ImageClickEventArgs e )
		{
			// クエリ作成
			QueryStringController query = new QueryStringController();
			query.AccessTicket = Globals.QueryStringController.AccessTicket;

			// トップページへリダイレクト
			Response.Redirect( ctTopPageUrl + query.ToString() );
		}

		#endregion

		#endregion

		#region << Server Validator >>

		#region ■配信日サーバー検証イベント

		/// <summary>
		/// 配信日サーバー検証イベント
		/// </summary>
		/// <param name="source"></param>
		/// <param name="e"></param>
		/// <remarks>
		/// <br>Note       : サーバーで検証が実行されると発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.23</br>
		/// </remarks>
		protected void MulticastDate_ServerValidation( object source, ServerValidateEventArgs e )
		{
			if( ! this.Page.IsValid ) {
				// 既に検証NG
				return;
			}

			DateTime stMulticastDate;
			DateTime edMulticastDate;
            DateTime stMcastRereaceDate;
            DateTime edMcastRereaceDate;
            DateTime stMainteDate;
            DateTime edMainteDate;

            switch (this.MulticastInfoDivCd_dropDownList.SelectedValue)
            {
                case "1":
                    // 開始日付
                    if (!this.CheckDateTime(this.StMulticastDate_textBox, out stMulticastDate))
                    {
                        // 無効な入力
                        this.MulticastDate_customValidator.ErrorMessage = "開始日付が不正です。";
                        e.IsValid = false;
                        return;
                    }
                    // 終了日付
                    if (!this.CheckDateTime(this.EdMulticastDate_textBox, out edMulticastDate))
                    {
                        // 無効な入力
                        this.MulticastDate_customValidator.ErrorMessage = "終了日付が不正です。";
                        e.IsValid = false;
                        return;
                    }

                    // 両方の日付が入力されている場合
                    if ((stMulticastDate != DateTime.MinValue) && (edMulticastDate != DateTime.MinValue))
                    {
                        // 日付の範囲をチェック
                        if (stMulticastDate > edMulticastDate)
                        {
                            // 開始日付が終了日付より大きい場合は不正

                            // 無効な入力
                            this.MulticastDate_customValidator.ErrorMessage = "日付の範囲が不正です。";
                            e.IsValid = false;
                            return;
                        }
                    }
                    break;
                case "2":
                    // サーバーメンテナンス開始予定
                    if (!this.CheckDateTime(this.StMainteDate_textBox, out stMainteDate))
                    {
                        // 無効な入力
                        this.MainteDate_customValidator.ErrorMessage = "開始日付が不正です。";
                        e.IsValid = false;
                        return;
                    }
                    // 終了日付
                    if (!this.CheckDateTime(this.EdMainteDate_textBox, out edMainteDate))
                    {
                        // 無効な入力
                        this.MainteDate_customValidator.ErrorMessage = "終了日付が不正です。";
                        e.IsValid = false;
                        return;
                    }

                    // 両方の日付が入力されている場合
                    if ((stMainteDate != DateTime.MinValue) && (edMainteDate != DateTime.MinValue))
                    {
                        // 日付の範囲をチェック
                        if (stMainteDate > edMainteDate)
                        {
                            // 開始日付が終了日付より大きい場合は不正

                            // 無効な入力
                            this.MainteDate_customValidator.ErrorMessage = "日付の範囲が不正です。";
                            e.IsValid = false;
                            return;
                        }
                    }
                    break;
                case "3":
                    // 開始リリース日
                    if (!this.CheckDateTime(this.StMcastRereaceDate_textBox, out stMcastRereaceDate))
                    {
                        // 無効な入力
                        this.McastRereaceDate_customValidator.ErrorMessage = "開始日付が不正です。";
                        e.IsValid = false;
                        return;
                    }
                    // 終了リリース日
                    if (!this.CheckDateTime(this.EdMcastRereaceDate_textBox, out edMcastRereaceDate))
                    {
                        // 無効な入力
                        this.McastRereaceDate_customValidator.ErrorMessage = "終了日付が不正です。";
                        e.IsValid = false;
                        return;
                    }
                    // 両方の日付が入力されている場合
                    if ((stMcastRereaceDate != DateTime.MinValue) && (edMcastRereaceDate != DateTime.MinValue))
                    {
                        // 日付の範囲をチェック
                        if (stMcastRereaceDate > edMcastRereaceDate)
                        {
                            // 開始日付が終了日付より大きい場合は不正

                            // 無効な入力
                            this.McastRereaceDate_customValidator.ErrorMessage = "日付の範囲が不正です。";
                            e.IsValid = false;
                            return;
                        }
                    }
                    break;
                default:
                    break;
            }
            
            // 有効な入力
			e.IsValid = true;
			return;
		}

		/// <summary>
		/// 日付チェック処理
		/// </summary>
		/// <param name="dateTimeTextBox">チェック対象テキストボックス</param>
		/// <returns>チェック結果</returns>
		/// <remarks>
		/// <br>Note       : 指定されたテキストボックスの日付入力チェックを行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.23</br>
		/// </remarks>
		private bool CheckDateTime( TextBox dateTimeTextBox, out DateTime resultDate )
		{
			bool result = false;

			resultDate = DateTime.MinValue;

			// 未入力の場合は空で返す
			if( dateTimeTextBox.Text.Trim() == "" ) {
				result = true;
				return result;
			}

			if( ! DateTime.TryParse( dateTimeTextBox.Text, out resultDate ) ) {
				resultDate = DateTime.MinValue;
				return result;
			}

			dateTimeTextBox.Text = resultDate.ToString( "yyyy/MM/dd" );

			result = true;
			return result;
		}

		#endregion

		#region ■配信バージョンサーバー検証イベント

		/// <summary>
		/// 配信バージョンサーバー検証イベント
		/// </summary>
		/// <param name="source"></param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : サーバーで検証が実行されると発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.23</br>
		/// </remarks>
		protected void MulticastVersion_ServerValidation( object source, ServerValidateEventArgs e )
		{
			if( ! this.Page.IsValid ) {
				// 既に検証NG
				return;
			}

			Version stMulticastVersion = null;
			Version edMulticastVersion = null;

			// 開始バージョン
			if( ! this.CheckVersionTime( this.StMulticastVersion_textBox, out stMulticastVersion ) ) {
				// 無効な入力
				this.MulticastDate_customValidator.ErrorMessage = "開始バージョンが不正です。";
				e.IsValid = false;
				return;
			}
			// 終了バージョン
			if( ! this.CheckVersionTime( this.EdMulticastVersion_textBox, out edMulticastVersion ) ) {
				// 無効な入力
				this.MulticastDate_customValidator.ErrorMessage = "開始バージョンが不正です。";
				e.IsValid = false;
				return;
			}

			// 両方のバージョンが入力されている場合
			if( ( stMulticastVersion != null ) && ( edMulticastVersion != null ) ) {
				// バージョンの範囲をチェック
				if( stMulticastVersion > edMulticastVersion ) {
					// 開始バージョンが終了バージョンより大きい場合は不正
					
					// 無効な入力
					this.MulticastDate_customValidator.ErrorMessage = "バージョンの範囲が不正です。";
					e.IsValid = false;
					return;
				}
			}

			// 有効な入力
			e.IsValid = true;
			return;
		}

		/// <summary>
		/// バージョンチェック処理
		/// </summary>
		/// <param name="versionTextBox">チェック対象テキストボックス</param>
		/// <param name="resultVersion">入力されているバージョン</param>
		/// <returns>チェック結果</returns>
		/// <remarks>
		/// <br>Note       : 指定されたテキストボックスのバージョン入力チェックを行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.23</br>
		/// </remarks>
		private bool CheckVersionTime( TextBox versionTextBox, out Version resultVersion )
		{
			bool result = false;

			resultVersion = null;

			// 未入力の場合は空で返す
			if( versionTextBox.Text.Trim() == "" ) {
				result = true;
				return result;
			}

			// 正規表現チェック
			Regex regex = new Regex( "^[0-9]{1,5}\\.[0-9]{1,5}\\.[0-9]{1,5}\\.[0-9]{1,5}$" );
			if( ! regex.IsMatch( versionTextBox.Text ) ) {
				return result;
			}

			try {
				resultVersion = new Version( versionTextBox.Text );
			}
			catch {
				resultVersion = null;
				return result;
			}

			versionTextBox.Text = resultVersion.ToString();

			result = true;
			return result;
		}

		#endregion

		#region ■条件未入力サーバー検証イベント

		/// <summary>
		/// 条件未入力サーバー検証イベント
		/// </summary>
		/// <param name="source"></param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : サーバーで検証が実行されると発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.23</br>
		/// </remarks>
		protected void InputEmpty_ServerValidation( object source, ServerValidateEventArgs e )
		{
			if( ! this.Page.IsValid ) {
				// 既に検証NG
				return;
			}

			bool isValid = false;

            // 変更内容
            if (this.ChangeContents_textBox.Text.Trim() != String.Empty)
            {
                isValid = true;
            }

            // 2007.12.05 Maki Add -------------------------------------->>>>>
            // 検索対象
            //if ( this.MulticastInfoDivCd_dropDownList.SelectedIndex > 0 ) {
            //    isValid = true;
            //}

            // 地域
            if ( this.Area_textBox.Text.Trim() != String.Empty ) {
                isValid = true;
            }

            // 帳票名称
            if ( this.PrintName_textBox.Text.Trim() != String.Empty ) {
                isValid = true;
            }
            // ---------------------------------------------------------<<<<<

			// 開始配信日
			if( this.StMulticastDate_textBox.Text.Trim() != String.Empty ) {
				isValid = true;
			}

			// 終了配信日
			if( this.EdMulticastDate_textBox.Text.Trim() != String.Empty ) {
				isValid = true;
			}

            // 開始リリース日
            if ( this.StMcastRereaceDate_textBox.Text.Trim() != String.Empty ) {
                isValid = true;
            }

            // 終了リリース日
            if ( this.EdMcastRereaceDate_textBox.Text.Trim() != String.Empty ) {
                isValid = true;
            }

            // 開始サーバーメンテ予定日
            if ( this.StMainteDate_textBox.Text.Trim() != String.Empty ) {
                isValid = true;
            }

            // 終了サーバーメンテ予定日
            if ( this.EdMainteDate_textBox.Text.Trim() != String.Empty ) {
                isValid = true;
            }

			// 開始配信バージョン
			if( this.StMulticastVersion_textBox.Text.Trim() != String.Empty ) {
				isValid = true;
			}

			// 終了配信バージョン
			if( this.EdMulticastVersion_textBox.Text.Trim() != String.Empty ) {
				isValid = true;
			}

			// 配信システム区分
			if( this.MulticastSystemDivCd_dropDownList.SelectedIndex > 0 ) {
				isValid = true;
			}

			// 配信プログラム名称
			if( this.MulticastProgramName_textBox.Text.Trim() != String.Empty ) {
				isValid = true;
			}

			// 検証結果をセット
			e.IsValid = isValid;
		}

		#endregion

		#endregion
	}
}

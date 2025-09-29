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

// Global.aspx アクセス用
using Globals = ASP.global_asax;

namespace Broadleaf.Web.UI
{
	public partial class SFCMN00771W : System.Web.UI.Page
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
		//private const string ctServerMainteDetailUrl = "SFCMN00774W.aspx"; 2007.12.18 Maki DEL
		/// <summary>別紙格納フォルダURL</summary>
		private const string ctAnotherSheetsDirUrl   = "AnotherSheets/";

		/// <summary>画面展開用クライアントスクリプトURL</summary>
		private const string ctClientScriptUrl          = "SFCMN00771W.js";
		/// <summary>カスタムバリデーター用クライアントスクリプトURL</summary>
		private const string ctClientSearchBoxScriptUrl = "SFCMN00773W.js";

		#endregion

		#region ■メッセージ表示用テキスト

		/// <summary>メッセージ表示用テキスト「該当の情報が見つかりませんでした。」</summary>
		private const string ctMessage_NoData = "該当の情報が見つかりませんでした。";
		/// <summary>メッセージ表示用テキスト「ページを作成中にエラーが発生しました。」</summary>
		private const string ctmessage_Error  = "ページを作成中にエラーが発生しました。";

		#endregion

		/// <summary>配信情報表示件数</summary>
		private const int ctMulticastInfoDispCount    = 3;

		/// <summary>データメンテナンス情報表示件数</summary>
		private const int ctDataMainteInfoDispCount = 5;

        /// <summary>サーバーメンテナンス情報表示件数</summary>
        private const int ctServerMainteInfoDispCount = 3;

        ///// <summary>印字位置リリース情報表示件数</summary>
        //private const int ctPrintPosisionInfoDispCount = 5;

		#endregion

		#region << Private Members >>

		/// <summary>変更PG案内検索部品</summary>
		private ChangeInfoSearchManager _changeInfoSearchManager = null;

		/// <summary>ログ出力部品</summary>
		private ChangePgGuideLogOutPut  _changePgGuideLogOutPut  = null;

		#endregion

		#region << PublicPropertids >>

		/// <summary>
		/// 変更内容テキストボックス
		/// </summary>
		public TextBox ChangeContentsTextBox
		{
			get {
				return this.ChangeContents_textBox;
			}
		}

        // 2007.12.05 Maki ADD ----------------------------------->>>>>
        /// <summary>
        /// 案内区分ドロップダウンリスト
        /// </summary>
        public DropDownList MulticastInfoDivCdDropDownList
        {
            get
            {
                return this.MulticastInfoDivCd_dropDownList;
            }
        }

        /// <summary>
        /// 地域テキストボックス
        /// </summary>
        public TextBox AreaTextBox
        {
            get
            {
                return this.Area_textBox;
            }
        }

        /// <summary>
        /// 帳票名称テキストボックス
        /// </summary>
        public TextBox PrintNameTextBox
        {
            get
            {
                return this.PrintName_textBox;
            }
        }
        // ------------------------------------------------------<<<<<

		/// <summary>
		/// 開始配信日テキストボックス
		/// </summary>
		public TextBox StMulticastDateTextBox
		{
			get {
				return this.StMulticastDate_textBox;
			}
		}

		/// <summary>
		/// 終了配信日テキストボックス
		/// </summary>
		public TextBox EdMulticastDateTextBox
		{
			get {
				return this.EdMulticastDate_textBox;
			}
		}

        /// <summary>
        /// 開始リリース日テキストボックス
        /// </summary>
        public TextBox StMcastRereaceDateTextBox
        {
            get
            {
                return this.StMcastRereaceDate_textBox;
            }
        }

        /// <summary>
        /// 終了配信日テキストボックス
        /// </summary>
        public TextBox EdMcastRereaceDateTextBox
        {
            get
            {
                return this.EdMcastRereaceDate_textBox;
            }
        }

        /// <summary>
        /// 開始サーバーメンテ予定日テキストボックス
        /// </summary>
        public TextBox StMainteDateTextBox
        {
            get
            {
                return this.StMainteDate_textBox;
            }
        }

        /// <summary>
        /// 終了サーバーメンテ予定日テキストボックス
        /// </summary>
        public TextBox EdMainteDateTextBox
        {
            get
            {
                return this.EdMainteDate_textBox;
            }
        }

        /// <summary>
		/// 開始配信バージョンテキストボックス
		/// </summary>
		public TextBox StMulticastVersionTextBox
		{
			get {
				return this.StMulticastVersion_textBox;
			}
		}

		/// <summary>
		/// 終了配信バージョンテキストボックス
		/// </summary>
		public TextBox EdMulticastVersionTextBox
		{
			get {
				return this.EdMulticastVersion_textBox;
			}
		}

		/// <summary>
		/// システム区分ドロップダウンリスト
		/// </summary>
		public DropDownList MulticastSystemDivCdDropDownList
		{
			get {
				return this.MulticastSystemDivCd_dropDownList;
			}
		}

		/// <summary>
		/// 配信プログラム名称テキストボックス
		/// </summary>
		public TextBox MulticastProgramNameTextBox
		{
			get {
				return this.MulticastProgramName_textBox;
			}
		}

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
            // 2007.12.14 Maki Change ---------------------------------------------------------------------------------------------->>>>>
			//foreach( int multicastSystemDivCd in Enum.GetValues( typeof( ConstantManagement_NS_MGD.MulticastSystemDiv_SF ) ) ) {
            foreach( int multicastSystemDivCd in Enum.GetValues( typeof( ConstantManagement_NS_MGD.SystemDiv) ) ) {
            // ---------------------------------------------------------------------------------------------------------------------<<<<<
				this.MulticastSystemDivCd_dropDownList.Items.Add( 
					new ListItem( ConstantManagement_NS_MGD.GetMulticastSystemDivNm( ConstantManagement_NS_MGD.ProductCode.PM, multicastSystemDivCd ), 
						multicastSystemDivCd.ToString( "0" ) ) );
			}
            // 2007.12.05 Maki Add ---------------------------------------------------------------------------------------------------------------->>>>>
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
			this.ChangeContents_textBox.Style.Add(          "ime-mode", "active" );
            this.Area_textBox.Style.Add(                    "ime-mode", "active"); 
            this.StMulticastDate_textBox.Style.Add(         "ime-mode", "disabled" );
			this.EdMulticastDate_textBox.Style.Add(         "ime-mode", "disabled" );
            this.StMcastRereaceDate_textBox.Style.Add(      "ime-mode", "disabled");
            this.EdMcastRereaceDate_textBox.Style.Add(      "ime-mode", "disabled");
            this.StMainteDate_textBox.Style.Add(            "ime-mode", "disabled");
            this.EdMainteDate_textBox.Style.Add(            "ime-mode", "disabled");
            this.StMulticastVersion_textBox.Style.Add(      "ime-mode", "disabled");
			this.EdMulticastVersion_textBox.Style.Add(      "ime-mode", "disabled" );
			this.MulticastProgramName_textBox.Style.Add(    "ime-mode", "active" );
            // 2007.12.11 Maki Add ---------------------------------------------->>>>>
            this.PrintName_textBox.Style.Add(               "ime-mode", "active" );
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

            // 2007.12.05 Maki ADD ------------------------------->>>>>
            // 案内区分
            this.MulticastInfoDivCd_dropDownList.SelectedIndex = 0;
            // ---------------------------------------------------<<<<<
            
            // 入替プログラム名称キーワード
			this.MulticastProgramName_textBox.Text = "";

            // 2007.12.11 Maki ADD ------------------------------->>>>>
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
			const string ctIncludeClientScriptKey          = "SFCMN00771W.js";
			const string ctIncludeClientSearchBoxScriptKey = "SFCMN00773W.js";
			const string ctClientIDScriptKey               = "ClientIDScript";

			ClientScriptManager cs = this.ClientScript;
			Type csType = this.GetType();

			// 外部スクリプトの登録
			// 画面展スクリプト
			if( ! this.ClientScript.IsClientScriptIncludeRegistered( csType, ctIncludeClientScriptKey ) ) {
				// スクリプトが未登録
				this.ClientScript.RegisterClientScriptInclude( csType, ctIncludeClientScriptKey, ctClientScriptUrl );
			}
			// 検索Box用
			if( ! cs.IsClientScriptIncludeRegistered( csType, ctIncludeClientSearchBoxScriptKey ) ) {
				// スクリプトが未登録
				cs.RegisterClientScriptInclude( csType, ctIncludeClientSearchBoxScriptKey, ctClientSearchBoxScriptUrl );
			}

			// 初期登録 クライアントスクリプト を登録
			if( ! cs.IsStartupScriptRegistered( csType, ctClientIDScriptKey ) ) {
				StringBuilder clientScript = new StringBuilder();
				clientScript.AppendLine( "<script type='text/javascript'>" );
				// ↓クライアント用 ID を登録
				clientScript.AppendFormat( "var ID_ChangeContents_textBox = '{0}';", this.ChangeContents_textBox.ClientID );
                // 2007.12.05 Maki Add ------------------------------------------------------------------------------------------------------>>>>>
                clientScript.AppendFormat( "var ID_MulticastInfoDivCd_dropDownList = '{0}';", this.MulticastInfoDivCd_dropDownList.ClientID);
                clientScript.AppendFormat( "var ID_Area_textBox = '{0}';", this.Area_textBox.ClientID);
                clientScript.AppendFormat( "var ID_PrintName_textBox = '{0}';", this.PrintName_textBox.ClientID);
                // --------------------------------------------------------------------------------------------------------------------------<<<<<
                clientScript.AppendFormat( "var ID_StMulticastDate_textBox = '{0}';", this.StMulticastDate_textBox.ClientID);
				clientScript.AppendFormat( "var ID_EdMulticastDate_textBox = '{0}';", this.EdMulticastDate_textBox.ClientID );
                clientScript.AppendFormat( "var ID_StMcastRereaceDate_textBox = '{0}';", this.StMcastRereaceDate_textBox.ClientID);
                clientScript.AppendFormat( "var ID_EdMcastRereaceDate_textBox = '{0}';", this.EdMcastRereaceDate_textBox.ClientID);
                clientScript.AppendFormat( "var ID_StMainteDate_textBox = '{0}';", this.StMainteDate_textBox.ClientID);
                clientScript.AppendFormat( "var ID_EdMainteDate_textBox = '{0}';", this.EdMainteDate_textBox.ClientID);
                clientScript.AppendFormat( "var ID_StMulticastVersion_textBox = '{0}';", this.StMulticastVersion_textBox.ClientID);
				clientScript.AppendFormat( "var ID_EdMulticastVersion_textBox = '{0}';", this.EdMulticastVersion_textBox.ClientID );
				clientScript.AppendFormat( "var ID_MulticastSystemDivCd_dropDownList = '{0}';", this.MulticastSystemDivCd_dropDownList.ClientID );
                clientScript.AppendFormat( "var ID_MulticastProgramName_textBox = '{0}';", this.MulticastProgramName_textBox.ClientID);

				// フォーカス移動制御登録
                // 2007.12.19 Maki -------------------------------------------------------------------------------------------------------------------------------------------------->>>>>
                //DEL
                //clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', '{1}', 'search_list_multicast_date', 'display', 'none', '{2}' );", 
                //    this.ChangeContents_textBox.ClientID, this.StMulticastDate_textBox.ClientID, this.Search_imageButton.ClientID );
                //clientScript.AppendFormat("RegistKeyDownEvent( '{0}', '{1}' );", this.StMulticastDate_textBox.ClientID, this.EdMulticastDate_textBox.ClientID);
                //clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', '{1}' );", this.EdMulticastDate_textBox.ClientID, this.StMulticastVersion_textBox.ClientID );
                //clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', '{1}' );", this.StMulticastVersion_textBox.ClientID, this.EdMulticastVersion_textBox.ClientID );
                //clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', '{1}' );", this.EdMulticastVersion_textBox.ClientID, this.MulticastSystemDivCd_dropDownList.ClientID );
                //clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', '{1}' );", this.MulticastSystemDivCd_dropDownList.ClientID, this.MulticastProgramName_textBox.ClientID );
                //clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', '{1}' );", this.MulticastProgramName_textBox.ClientID, this.Search_imageButton.ClientID );
                //clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', '{1}' );", this.Search_imageButton.ClientID, this.Clear_imageButton.ClientID );
                //clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', '{1}' );", this.Clear_imageButton.ClientID, this.ChangeContents_textBox.ClientID );
                //ADD
                clientScript.AppendFormat( "RegistKeyDownEvent( '{0}' );", this.ChangeContents_textBox.ClientID );
                clientScript.AppendFormat( "RegistKeyDownEvent( '{0}' );", this.MulticastInfoDivCdDropDownList.ClientID );
                clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', 'search_list_printname' );", this.PrintName_textBox.ClientID );
                clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', 'search_list_multicast_regionnm' );", this.Area_textBox.ClientID );
                clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', 'search_list_multicast_date' );", this.StMulticastDate_textBox.ClientID );
                clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', 'search_list_multicast_date' );", this.EdMulticastDate_textBox.ClientID );
                clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', 'search_list_mcast_rereace_date' );", this.StMcastRereaceDate_textBox.ClientID);
                clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', 'search_list_mcast_rereace_date' );", this.EdMcastRereaceDate_textBox.ClientID);
                clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', 'search_list_mainte_date' );", this.StMainteDate_textBox.ClientID);
                clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', 'search_list_mainte_date' );", this.EdMainteDate_textBox.ClientID);
                clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', 'search_list_multicast_version' );", this.StMulticastVersion_textBox.ClientID);
                clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', 'search_list_multicast_version' );", this.EdMulticastVersion_textBox.ClientID );
                clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', 'search_list_multicast_sysdiv' );", this.MulticastSystemDivCd_dropDownList.ClientID );
                clientScript.AppendFormat( "RegistKeyDownEvent( '{0}', 'search_list_multicast_pgname' );", this.MulticastProgramName_textBox.ClientID );
                clientScript.AppendFormat( "RegistKeyDownEvent( '{0}' );", this.Search_imageButton.ClientID );
                clientScript.AppendFormat( "RegistKeyDownEvent( '{0}' );", this.Clear_imageButton.ClientID );
                // ------------------------------------------------------------------------------------------------------------------------------------------------------------------<<<<<

                clientScript.AppendLine("</script>");

				cs.RegisterStartupScript( csType, ctClientIDScriptKey, clientScript.ToString() );
			}
		}

		#endregion
        
        #region Del
        #region ■最新 .NS 配信情報作成処理 2007.12.17 DEL
        /*
		/// <summary>
		/// 最新 .NS 配信情報作成処理
		/// </summary>
		/// <param name="errorMessage">エラーメッセージ</param>
		/// <remarks>
		/// <br>Note       : 最新 .NS 配信情報を作成します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.02.19</br>
		/// </remarks>
		private int CreateNewMulticastInfo( ref string errorMessage )
		{
			int status = ( int )ConstantManagement.DB_Status.ctDB_ERROR;

			DataSet ds = new DataSet();
			SFCMN00771WB.CreateChangGidncDataSet( ref ds );

			List<ChangGidncWork> changGidncWorkList = new List<ChangGidncWork>();
			List<ChgGidncDtWork> chgGidncDtWorkList = new List<ChgGidncDtWork>();

			// 検索部品インスタンス生成
			if( this._changeInfoSearchManager == null ) {
				this._changeInfoSearchManager = new ChangeInfoSearchManager();
			}

			string errMsg = "";
			int totalCount = 0;
			ChangGidncParaWork changGidncParaWork   = new ChangGidncParaWork();
			changGidncParaWork.MulticastSystemDivCd = -1;    // 全システムを検索

			status = this._changeInfoSearchManager.SearchChangGidnc( Globals.QueryStringController.AccessTicket.ToString(), changGidncParaWork, 0, ctMulticastInfoDispCount, out totalCount, out changGidncWorkList, out chgGidncDtWorkList, out errMsg );
			switch( status  ) {
				// 該当データ有り
				case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					// 最新 .NS 配信情報パネルを表示
					this.NewMulticastInfo_panel.Visible     = true;
					// 最新 .NS 配信情報を表示
					this.NewMulticastInfo_repeater.Visible  = true;
					// 該当データなしメッセージを非表示
					this.NothingMulticastInfo_panel.Visible = false;

					foreach( ChangGidncWork changGidncWork in changGidncWorkList ) {
                        this.AddChangGidncWorkToDataSet(ds, changGidncWork);
					}
					foreach( ChgGidncDtWork pgMulcsGdDWork in chgGidncDtWorkList ) {
						this.AddPgMulcsGdDWorkToDataSet( ds, pgMulcsGdDWork );
					}
					
					this.NewMulticastInfo_repeater.DataSource = ds;
					this.NewMulticastInfo_repeater.DataMember = SFCMN00771WB.ctTableName_ChangeGidncRoot;
					this.NewMulticastInfo_repeater.DataBind();

					break;
				}
				// 該当データなし
				case ( int )ConstantManagement.DB_Status.ctDB_EOF:
				case ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND:
				{
					// 最新 .NS 配信情報パネルを表示
					this.NewMulticastInfo_panel.Visible     = true;
					// 最新 .NS 配信情報を非表示
					this.NewMulticastInfo_repeater.Visible  = false;
					// 該当データなしメッセージを表示
					this.NothingMulticastInfo_panel.Visible = true;

					// 該当データなしメッセージを表示
					this.NothingMulticastInfo_literal.Text  = ctMessage_NoData;

					status = ( int )ConstantManagement.DB_Status.ctDB_EOF;
					break;
				}
				// エラー
				default:
				{
					// 例外をスロー
					throw( new NSChangeInfoErrorException( status, errMsg ) );
				}
			}

			return status;
		}
        */
		#endregion

		#region ■プログラム配信案内ワーククラスDataSet格納処理 2007.12.17 DEL
        /*
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
		private void AddPgMulcasGdWorkToDataSet( DataSet ds, ChangGidncWork changGidncWork )
		{
			// プログラム配信案内ルートテーブルを取得
			DataTable dtChangGidncRoot = null;
			if( ds.Tables.Contains( SFCMN00771WB.ctTableName_ChangeGidncRoot ) ) {
				dtChangGidncRoot = ds.Tables[ SFCMN00771WB.ctTableName_ChangeGidncRoot ];
			}
			// プログラム配信案内テーブルを取得
			DataTable dtPgMulcasGd = null;
			if( ds.Tables.Contains( SFCMN00771WB.ctTableName_ChangeGidnc ) ) {
				dtPgMulcasGd = ds.Tables[ SFCMN00771WB.ctTableName_ChangeGidnc ];
			}

			// テーブルの取得に失敗した場合は処理を行わない
			if( ( dtChangGidncRoot == null ) || ( dtPgMulcasGd == null ) ) {
				return;
			}
			
			// プログラム配信案内ルートテーブルに登録されていない場合
			object[] pgMulcasGdRootKey = new object[] {
				changGidncWork.ProductCode,            // パッケージ区分
				changGidncWork.McastOfferDivCd,        // 配信提供区分
				changGidncWork.UpdateGroupCode,        // 更新グループコード
				changGidncWork.EnterpriseCode,         // 企業コード
				changGidncWork.McastGidncVersionCdZeroSup // 配信バージョン
			};
			if( ! dtChangGidncRoot.Rows.Contains( pgMulcasGdRootKey ) ) {
				// プログラム配信案内ルートテーブルに新規登録
				DataRow drChangGidncRoot = dtChangGidncRoot.NewRow();

				// パッケージ区分
				drChangGidncRoot[ SFCMN00771WB.ctColumnName_ProductCode      ] = changGidncWork.ProductCode;
				// 配信提供区分
				drChangGidncRoot[ SFCMN00771WB.ctColumnName_McastOfferDivCd  ] = changGidncWork.McastOfferDivCd;
				// 更新グループコード
				drChangGidncRoot[ SFCMN00771WB.ctColumnName_UpdateGroupCode  ] = changGidncWork.UpdateGroupCode;
				// 企業コード
				drChangGidncRoot[ SFCMN00771WB.ctColumnName_EnterpriseCode   ] = changGidncWork.EnterpriseCode;
				// 配信バージョン
				drChangGidncRoot[ SFCMN00771WB.ctColumnName_MulticastVersion ] = changGidncWork.McastGidncVersionCdZeroSup;
				// 配信日
				drChangGidncRoot[ SFCMN00771WB.ctColumnName_MulticastDate    ] = changGidncWork.MulticastDate;
				// サポート公開日時
				drChangGidncRoot[ SFCMN00771WB.ctColumnName_SupportOpenTime  ] = this.LongDateToDateTime( changGidncWork.SupportOpenTime );
				// ユーザー公開日時
				drChangGidncRoot[ SFCMN00771WB.ctColumnName_CustomerOpenTime ] = this.LongDateToDateTime( changGidncWork.CustomerOpenTime );

				// テーブルに追加
				dtChangGidncRoot.Rows.Add( drChangGidncRoot );
			}

			// プログラム配信案内テーブルに新規登録
			DataRow drChangGidnc = dtPgMulcasGd.NewRow();

			// パッケージ区分
			drChangGidnc[ SFCMN00771WB.ctColumnName_ProductCode          ] = changGidncWork.ProductCode;
			// 配信提供区分
			drChangGidnc[ SFCMN00771WB.ctColumnName_McastOfferDivCd      ] = changGidncWork.McastOfferDivCd;
			// 更新グループコード
			drChangGidnc[ SFCMN00771WB.ctColumnName_UpdateGroupCode      ] = changGidncWork.UpdateGroupCode;
			// 企業コード
			drChangGidnc[ SFCMN00771WB.ctColumnName_EnterpriseCode       ] = changGidncWork.EnterpriseCode;
			// 配信バージョン
			drChangGidnc[ SFCMN00771WB.ctColumnName_MulticastVersion     ] = changGidncWork.McastGidncVersionCdZeroSup;
			// 配信連番
			drChangGidnc[ SFCMN00771WB.ctColumnName_MulticastConsNo      ] = changGidncWork.MulticastConsNo;
			// プログラム変更区分
			drChangGidnc[ SFCMN00771WB.ctColumnName_ProgramChgDivCd      ] = changGidncWork.McastGidncNewCustmCd;
			// プログラム変更区分名称
			//drChangGidnc[ SFCMN00771WB.ctColumnName_ProgramChgDivNm      ] = ConstantManagement_NS_MGD.GetProgramChgDivNm( changGidncWork.Guidance1 );
            drChangGidnc[SFCMN00771WB.ctColumnName_ProgramChgDivNm       ] = ConstantManagement_NS_MGD.GetMcastGidncNewCustmCdNm(changGidncWork.McastGidncNewCustmCd);
			// 配信システム区分
			drChangGidnc[ SFCMN00771WB.ctColumnName_MulticastSystemDivCd ] = changGidncWork.SystemDivCd;
			// 配信システム区分名称
            drChangGidnc[SFCMN00771WB.ctColumnName_MulticastSystemDivNm] = ConstantManagement_NS_MGD.GetMulticastSystemDivNm(changGidncWork.ProductCode, changGidncWork.SystemDivCd);
			// 配信プログラム名称
			drChangGidnc[ SFCMN00771WB.ctColumnName_MulticastProgramName ] = changGidncWork.Guidance1;
			// 詳細ページURL
			drChangGidnc[ SFCMN00771WB.ctColumnName_DetailPageUrl        ] = this.CreateMulticastDetailUrl( changGidncWork.McastGidncVersionCd, changGidncWork.MulticastConsNo );;
			
			dtPgMulcasGd.Rows.Add( drChangGidnc );
		}
        */
		#endregion

		#region ■プログラム配信案内明細ワーククラスDataSet格納処理 2007.12.17 DEL
        /*
		/// <summary>
		/// プログラム配信案内明細ワーククラスDataSet格納処理
		/// </summary>
		/// <param name="ds">格納対象DataSet</param>
		/// <param name="pgMulcsGdDWork">プログラム配信案内明細ワーククラス</param>
		/// <remarks>
		/// <br>Note       : 指定されたプログラム配信案内明細ワーククラスをDataSet内のテーブルに格納します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
        private void AddPgMulcsGdDWorkToDataSet(DataSet ds, ChgGidncDtWork pgMulcsGdDWork)
		{
			// プログラム配信案内明細テーブルを取得
			DataTable dtPgMulcsGdD = null;
			if( ds.Tables.Contains( SFCMN00771WB.ctTableName_PgMulcsGdD ) ) {
				dtPgMulcsGdD = ds.Tables[ SFCMN00771WB.ctTableName_PgMulcsGdD ];
			}

			// テーブルの取得に失敗した場合は処理を行わない
			if( dtPgMulcsGdD == null ) {
				return;
			}
			
			// プログラム配信案内明細テーブルに新規登録
			DataRow drPgMulcsGdD = dtPgMulcsGdD.NewRow();

			// パッケージ区分
			drPgMulcsGdD[ SFCMN00771WB.ctColumnName_ProductCode          ] = pgMulcsGdDWork.ProductCode;
			// 配信提供区分
			drPgMulcsGdD[ SFCMN00771WB.ctColumnName_McastOfferDivCd      ] = pgMulcsGdDWork.McastOfferDivCd;
			// 更新グループコード
			drPgMulcsGdD[ SFCMN00771WB.ctColumnName_UpdateGroupCode      ] = pgMulcsGdDWork.UpdateGroupCode;
			// 企業コード
			drPgMulcsGdD[ SFCMN00771WB.ctColumnName_EnterpriseCode       ] = pgMulcsGdDWork.EnterpriseCode;
			// 配信バージョン
			drPgMulcsGdD[ SFCMN00771WB.ctColumnName_MulticastVersion     ] = pgMulcsGdDWork.McastGidncVersionCdZeroSup;
			// 配信連番
			drPgMulcsGdD[ SFCMN00771WB.ctColumnName_MulticastConsNo      ] = pgMulcsGdDWork.MulticastConsNo;
			// 配信サブコード
			drPgMulcsGdD[ SFCMN00771WB.ctColumnName_MulticastSubCode     ] = pgMulcsGdDWork.MulticastSubCode;
			// 変更内容
			drPgMulcsGdD[ SFCMN00771WB.ctColumnName_ChangeContents       ] = pgMulcsGdDWork.ChangeContents;
			// 別紙ファイル有無区分
			drPgMulcsGdD[ SFCMN00771WB.ctColumnName_AnothersheetFileExst ] = pgMulcsGdDWork.AnothersheetFileExst;
			// 別紙ファイル名
			drPgMulcsGdD[ SFCMN00771WB.ctColumnName_AnothersheetFileName ] = ctAnotherSheetsDirUrl + pgMulcsGdDWork.AnothersheetFileName;
			
			dtPgMulcsGdD.Rows.Add( drPgMulcsGdD );
		}
        */
		#endregion

		#region ■最新 サーバーメンテナンス情報作成処理 2007.12.17 DEL
        /*
		/// <summary>
		/// 最新 サーバーメンテナンス情報作成処理
		/// </summary>
		/// <param name="errorMessage">エラーメッセージ</param>
		/// <remarks>
		/// <br>Note       : 最新 サーバーメンテナンス情報を作成します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.02.19</br>
		/// </remarks>
		private int CreateNewServerMainteInfo( ref string errorMessage )
		{
			int status = ( int )ConstantManagement.DB_Status.ctDB_ERROR;

			// サーバーメンテナンス情報データセット作成
			DataSet ds = new DataSet();
			SFCMN00771WB.CreateSvrMntInfoDataSet( ref ds );

			// サーバーメンテナンス情報リスト
			List<SvrMntInfoWork> svrMntInfoWorkList = new List<SvrMntInfoWork>();

			// 緊急メンテナンス情報リスト
			List<SvrMntInfoWork> emergencySvrMntInfoWorkList = new List<SvrMntInfoWork>();

			// 検索部品インスタンス生成
			if( this._changeInfoSearchManager == null ) {
				this._changeInfoSearchManager = new ChangeInfoSearchManager();
			}

			string errMsg = "";
			int totalCount = 0;

			//status = this._changeInfoSearchManager.SearchSvrMntInfo( Globals.QueryStringController.AccessTicket, -1, 0, ctServerMainteInfoDispCount, out totalCount, out svrMntInfoWorkList, out errMsg );
            status = 9;
			switch( status ) {
				// 該当データ有り
				case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					// 最新 サーバーメンテナンス情報パネルを表示
					this.NewServerMainteInfo_panel.Visible     = true;
					// 最新 サーバーメンテナンス情報表示
					this.NewServerMainteInfo_repeater.Visible  = true;
					// 該当データなし、メッセージ表示
					this.NothingServerMainteInfo_panel.Visible = true;

					foreach( SvrMntInfoWork svrMntInfoWork in svrMntInfoWorkList ) {
						// 緊急メンテナンスの場合
						//if( svrMntInfoWork.ServerMainteDivCd == ( int )ConstantManagement_NS_MGD.ServerMainteDiv.Emergency ) {
                        if( svrMntInfoWork.ServerMainteDivCd == ( int )ConstantManagement_NS_MGD.MainteDiv.Emergency ) {
							// 終了日時の有無をチェック
							if( svrMntInfoWork.ServerMainteEdTime == 0 ) {
								// 終了していないので、緊急情報をリストに追加
								emergencySvrMntInfoWorkList.Add( svrMntInfoWork );
							}
						}
						this.AddSvrMntInfoWorkToDataSet( ds, svrMntInfoWork );
					}
					
					this.NewServerMainteInfo_repeater.DataSource = ds;
					this.NewServerMainteInfo_repeater.DataMember = SFCMN00771WB.ctTableName_SvrMntInfo;
					this.NewServerMainteInfo_repeater.DataBind();

					// 緊急メンテナンス情報が存在する場合
					if( emergencySvrMntInfoWorkList.Count > 0 ) {
						// 緊急メンテナンス情報表示
						this.ImportantInfo_panel.Visible = true;

						// 緊急メンテナンス情報を画面に展開
						this.CreateEmergencyMainteInfo( emergencySvrMntInfoWorkList );
					}
					else {
						// 緊急メンテナンス情報非表示
						this.ImportantInfo_panel.Visible = false;
					}
					break;
				}
				// 該当データなし
				case ( int )ConstantManagement.DB_Status.ctDB_EOF:
				case ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND:
				{
					// 最新 サーバーメンテナンス情報パネルを表示
					this.NewServerMainteInfo_panel.Visible     = true;
					// 最新 サーバーメンテナンス情報非表示
					this.NewServerMainteInfo_repeater.Visible  = false;
					// 該当データなし、メッセージ表示
					this.NothingServerMainteInfo_panel.Visible = true;
					// 緊急メンテナンス情報非表示
					this.ImportantInfo_panel.Visible           = false;

					// 該当データなし、メッセージ表示
					this.NothingServerMainteInfo_literal.Text  = ctMessage_NoData;

					status = ( int )ConstantManagement.DB_Status.ctDB_EOF;
					break;
				}
				// エラー
				default:
				{
					// 例外をスロー
					throw( new NSChangeInfoErrorException( status, errMsg ) );
				}
			}

			return status;
		}
        */
		#endregion

		#region ■緊急メンテナンス情報作成処理 2007.12.17 DEL
        /*
		/// <summary>
		/// 緊急メンテナンス情報作成処理
		/// </summary>
		/// <param name="emergencySvrMntInfoWorkList">緊急メンテナンス情報リスト</param>
		/// <remarks>
		/// <br>Note       : 緊急メンテナンス情報を作成します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.09</br>
		/// </remarks>
		private void CreateEmergencyMainteInfo( List<SvrMntInfoWork> emergencySvrMntInfoWorkList )
		{
			// サーバーメンテナンス情報データセット作成
			DataSet ds = new DataSet();
			SFCMN00771WB.CreateSvrMntInfoDataSet( ref ds );

			foreach( SvrMntInfoWork svrMntInfoWork in emergencySvrMntInfoWorkList ) {
				this.AddSvrMntInfoWorkToDataSet( ds, svrMntInfoWork );
			}
			
			this.ImportantInfo_repeater.DataSource = ds;
			this.ImportantInfo_repeater.DataMember = SFCMN00771WB.ctTableName_SvrMntInfo;
			this.ImportantInfo_repeater.DataBind();
		}
        */
		#endregion

		#region ■サーバーメンテナンス情報ワーククラスDataSet格納処理 2007.12.17 DEL
        /*
		/// <summary>
		/// サーバーメンテナンス情報ワーククラスDataSet格納処理
		/// </summary>
		/// <param name="ds">格納対象DataSet</param>
		/// <param name="svrMntInfoWork">サーバーメンテナンス情報ワーククラス</param>
		/// <remarks>
		/// <br>Note       : 指定されたサーバーメンテナンス情報ワーククラスをDataSet内のテーブルに格納します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
		private void AddSvrMntInfoWorkToDataSet( DataSet ds, SvrMntInfoWork svrMntInfoWork )
		{
			// プログラム配信案内明細テーブルを取得
			DataTable dtSvrMntInfo = null;
			if( ds.Tables.Contains( SFCMN00771WB.ctTableName_SvrMntInfo ) ) {
				dtSvrMntInfo = ds.Tables[ SFCMN00771WB.ctTableName_SvrMntInfo ];
			}

			// テーブルの取得に失敗した場合は処理を行わない
			if( dtSvrMntInfo == null ) {
				return;
			}
			
			// プログラム配信案内明細テーブルに新規登録
			DataRow drSvrMntInfo = dtSvrMntInfo.NewRow();

			// パッケージ区分
			drSvrMntInfo[ SFCMN00771WB.ctColumnName_ProductCode               ] = svrMntInfoWork.ProductCode;
			// サーバーメンテナンス連番
			drSvrMntInfo[ SFCMN00771WB.ctColumnName_ServerMainteConsNo        ] = svrMntInfoWork.ServerMainteConsNo;
			// サーバーメンテナンス区分
			drSvrMntInfo[ SFCMN00771WB.ctColumnName_ServerMainteDivCd         ] = svrMntInfoWork.ServerMainteDivCd;
			// サーバーメンテナンス区分名称
			string serverMainteDivNm = ConstantManagement_NS_MGD.GetServerMainteDivNm( svrMntInfoWork.ServerMainteDivCd );
			drSvrMntInfo[ SFCMN00771WB.ctColumnName_ServerMainteDivNm         ] = serverMainteDivNm;
			// サーバーメンテナンス開始予定日時
			drSvrMntInfo[ SFCMN00771WB.ctColumnName_ServerMainteStScdl        ] = this.LongDateToDateTime( svrMntInfoWork.ServerMainteStScdl );
			// サーバーメンテナンス終了予定日時
			drSvrMntInfo[ SFCMN00771WB.ctColumnName_ServerMainteEdScdl        ] = this.LongDateToDateTime( svrMntInfoWork.ServerMainteEdScdl );
			// サーバーメンテナンス開始日時
			drSvrMntInfo[ SFCMN00771WB.ctColumnName_ServerMainteStTime        ] = this.LongDateToDateTime( svrMntInfoWork.ServerMainteStTime );
			// サーバーメンテナンス終了日時
			drSvrMntInfo[ SFCMN00771WB.ctColumnName_ServerMainteEdTime        ] = this.LongDateToDateTime( svrMntInfoWork.ServerMainteEdTime );
			// サーバーメンテナンス内容
			drSvrMntInfo[ SFCMN00771WB.ctColumnName_ServerMainteCntnts        ] = svrMntInfoWork.ServerMainteCntnts;
			// サーバーメンテナンス案内文
			drSvrMntInfo[ SFCMN00771WB.ctColumnName_ServerMainteGidnc         ] = svrMntInfoWork.ServerMainteGidnc;

			string serverMainteOutputMessage = "";
			// メンテナンス予定
			if( ( svrMntInfoWork.ServerMainteStTime == 0 ) && 
				( svrMntInfoWork.ServerMainteEdTime == 0 ) ) {
				// メンテナンス終了予定が入っていない場合
				if( svrMntInfoWork.ServerMainteEdScdl == 0 ) {
					serverMainteOutputMessage = 
						String.Format( "{0} より、{1}を実施いたします。", 
						this.GetDateTimeString( svrMntInfoWork.ServerMainteStScdl, true ), 
						serverMainteDivNm );
				}
				else {
					serverMainteOutputMessage = 
						String.Format( "{0} から {1} まで、{2}を実施いたします。", 
						this.GetDateTimeString( svrMntInfoWork.ServerMainteStScdl, true ), 
						this.GetDateTimeString( svrMntInfoWork.ServerMainteEdScdl, true ), 
						serverMainteDivNm );
				}
			}
			// メンテナンス中
			else if( ( svrMntInfoWork.ServerMainteStTime != 0 ) && 
				( svrMntInfoWork.ServerMainteEdTime == 0 ) ) {
				// メンテナンス終了予定が入っていない場合
				if( svrMntInfoWork.ServerMainteEdScdl == 0 ) {
					serverMainteOutputMessage = 
						String.Format( "ただいま、{0}を実施しております。", 
						serverMainteDivNm );
				}
				else {
					serverMainteOutputMessage = 
						String.Format( "ただいま、{0}を実施しております。終了時刻は、{1} を予定しております。", 
						serverMainteDivNm, 
						this.GetDateTimeString( svrMntInfoWork.ServerMainteEdScdl, true ) );
				}
			}
			// メンテナンス終了
			else {
				serverMainteOutputMessage = String.Format( "{0}は、{1} に終了致しました。", 
					serverMainteDivNm, 
					this.GetDateTimeString( svrMntInfoWork.ServerMainteEdTime, true ) );
			}

			// サーバーメンテナンス出力メッセージ
			drSvrMntInfo[ SFCMN00771WB.ctColumnName_ServerMainteOutputMessage ] = serverMainteOutputMessage;
			// 詳細ページURL
			drSvrMntInfo[ SFCMN00771WB.ctColumnName_DetailPageUrl             ] = this.CreateServerMainteDetailUrl( svrMntInfoWork.ServerMainteConsNo );

			dtSvrMntInfo.Rows.Add( drSvrMntInfo );
		}
        */
		#endregion

        #region ■緊急メンテナンス情報作成処理 2007.12.17 DEL
        /*
        /// <summary>
        /// 緊急メンテナンス情報作成処理
        /// </summary>
        /// <param name="emergencySvrMntInfoWorkList">緊急メンテナンス情報リスト</param>
        /// <remarks>
        /// <br>Note       : 緊急メンテナンス情報を作成します。</br>
        /// <br>Programmer : 23001 秋山　亮介</br>
        /// <br>Date       : 2007.03.09</br>
        /// </remarks>
        private void CreateEmergencyMainteInfo(List<SvrMntInfoWork> emergencySvrMntInfoWorkList)
        {
            // サーバーメンテナンス情報データセット作成
            DataSet ds = new DataSet();
            SFCMN00771WB.CreateChangGidncDataSet(ref ds);

            foreach (SvrMntInfoWork svrMntInfoWork in emergencySvrMntInfoWorkList)
            {
                this.AddSvrMntInfoWorkToDataSet(ds, svrMntInfoWork);
            }

            this.ImportantInfo_repeater.DataSource = ds;
            this.ImportantInfo_repeater.DataMember = SFCMN00771WB.ctTableName_ChangeGidnc;
            this.ImportantInfo_repeater.DataBind();
        }
        */
        #endregion
        
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
        /// <param name="mcastGidncCntntsCd">案内区分</param>
        /// <param name="systemDivCd">システム区分</param>
        /// <param name="mcastGidncMainteCd">メンテナンス区分</param>
		/// <returns>詳細情報URL</returns>
		/// <remarks>
		/// <br>Note       : 詳細情報のURLを作成します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.02.19</br>
        /// <br></br>
        /// <br>Note       : クエリ項目を追加</br>
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2007.12.13</br>
		/// </remarks>
        private string CreateMulticastDetailUrl(string multicastVersion, int multicastConsNo, int mcastGidncCntntsCd, int systemDivCd, int mcastGidncMainteCd)
		{
			QueryStringController query = new QueryStringController();
			query.AccessTicket          = Globals.QueryStringController.AccessTicket;

			query.MulticastVersion      = multicastVersion;
			query.MulticastConsNo       = multicastConsNo;
            query.McastGidncCntntsCd    = mcastGidncCntntsCd;
            query.SystemDivCd           = systemDivCd;
			return ctMulticastDetailUrl + query.ToString();
		}

		#endregion

        #region ■サーバーメンテナンス詳細情報URL作成処理 2007.12.18 DEL
        /*
		/// <summary>
		/// サーバーメンテナンス詳細情報URL作成処理
		/// </summary>
		/// <param name="serverMainteConsNo">サーバーメンテナンス連番</param>
		/// <returns>サーバーメンテナンス詳細情報URL</returns>
		/// <remarks>
		/// <br>Note       : サーバーメンテナンス詳細情報のURLを作成します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.02.19</br>
		/// </remarks>
		private string CreateServerMainteDetailUrl( int serverMainteConsNo )
		{
			QueryStringController query = new QueryStringController();
			query.AccessTicket       = Globals.QueryStringController.AccessTicket;
			//query.ServerMainteConsNo = serverMainteConsNo;
            query.MulticastConsNo   = serverMainteConsNo;
			return ctServerMainteDetailUrl + query.ToString();
		}
        */
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
        private string CreateErrorMessage(Exception ex, int status)
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

        // 2007.12.06 Maki Add ------------------------------>>>>> Start
        #region ■変更案内ワーククラスDataSet格納処理

        /// <summary>
        /// 変更案内ワーククラスDataSet格納処理
        /// </summary>
        /// <param name="ds">格納対象DataSet</param>
        /// <param name="changGidncWork">変更案内ワーククラス</param>
        /// <remarks>
        /// <br>Note       : 指定された変更案内ワーククラスをDataSet内のテーブルに格納します。</br>
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void AddChangGidncWorkToDataSet( DataSet ds, ChangGidncWork changGidncWork )
        {
            // 変更案内ルートテーブルを取得
            DataTable dtChangGidncRoot = null;
            if ( ds.Tables.Contains( SFCMN00771WB.ctTableName_ChangeGidncRoot ) )
            {
                dtChangGidncRoot = ds.Tables[ SFCMN00771WB.ctTableName_ChangeGidncRoot ];
            }
            // 変更案内テーブルを取得
            DataTable dtChangGidnc = null;
            if ( ds.Tables.Contains( SFCMN00771WB.ctTableName_ChangeGidnc ) )
            {
                dtChangGidnc = ds.Tables[ SFCMN00771WB.ctTableName_ChangeGidnc ];
            }

            // テーブルの取得に失敗した場合は処理を行わない
            if ( ( dtChangGidncRoot == null ) || ( dtChangGidnc == null ) )
            {
                return;
            }

            // 変更案内ルートテーブルに登録されていない場合
            object[] pgChangGidncRootKey = new object[] {
				changGidncWork.McastGidncCntntsCd,          // 案内内容区分
                changGidncWork.ProductCode,                 // パッケージ区分
				changGidncWork.McastGidncVersionCdZeroSup,  // 配信バージョン
                changGidncWork.McastOfferDivCd,             // 配信提供区分
				changGidncWork.UpdateGroupCode,             // 更新グループコード
				changGidncWork.EnterpriseCode               // 企業コード
			};

            if ( ! dtChangGidncRoot.Rows.Contains( pgChangGidncRootKey ) )
            {
                // プログラム配信案内ルートテーブルに新規登録
                DataRow drChangGidncRoot = dtChangGidncRoot.NewRow();

                // 案内内容区分
                drChangGidncRoot[ SFCMN00771WB.ctColumnName_McastGidncCntntsCd ]  = changGidncWork.McastGidncCntntsCd;
                // パッケージ区分
                drChangGidncRoot[ SFCMN00771WB.ctColumnName_ProductCode ]         = changGidncWork.ProductCode;
                // 配信提供区分
                drChangGidncRoot[ SFCMN00771WB.ctColumnName_McastOfferDivCd ]     = changGidncWork.McastOfferDivCd;
                // 更新グループコード
                drChangGidncRoot[ SFCMN00771WB.ctColumnName_UpdateGroupCode ]     = changGidncWork.UpdateGroupCode;
                // 企業コード
                drChangGidncRoot[ SFCMN00771WB.ctColumnName_EnterpriseCode ]      = changGidncWork.EnterpriseCode;
                // 配信バージョン
                drChangGidncRoot[ SFCMN00771WB.ctColumnName_McastGidncVersionCd ] = changGidncWork.McastGidncVersionCdZeroSup;
                // 配信日
                drChangGidncRoot[ SFCMN00771WB.ctColumnName_MulticastDate ]       = changGidncWork.MulticastDate;
                // サポート公開日時
                drChangGidncRoot[ SFCMN00771WB.ctColumnName_SupportOpenTime ]     = this.LongDateToDateTime(changGidncWork.SupportOpenTime);
                // ユーザー公開日時
                drChangGidncRoot[ SFCMN00771WB.ctColumnName_CustomerOpenTime ]    = this.LongDateToDateTime(changGidncWork.CustomerOpenTime);
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
                            serverMainteOutputMessage = String.Format( "{0}は、{1} に終了しました。",
                                ConstantManagement_NS_MGD.GetServerMainteDivNm( changGidncWork.McastGidncMainteCd ),
                                this.GetDateTimeString( changGidncWork.ServerMainteEdTime, true ) );
                        }
                        break;
                    default:
                        break;
                }
                // 配信案内 メンテ区分
                drChangGidncRoot[ SFCMN00771WB.ctColumnName_McastGidncMainteCd ]        = changGidncWork.McastGidncMainteCd;
                // 配信案内 メンテ区分名称
                drChangGidncRoot[ SFCMN00771WB.ctColumnName_McastGidncMainteNm ]        = ConstantManagement_NS_MGD.GetServerMainteDivNm( changGidncWork.McastGidncMainteCd );
                // サーバーメンテナンス出力メッセージ
                drChangGidncRoot[ SFCMN00771WB.ctColumnName_ServerMainteOutputMessage ] = serverMainteOutputMessage;
                // 配信プログラム名称(サーバーメンテナンス内容)
                drChangGidncRoot[ SFCMN00771WB.ctColumnName_Guidance1 ]                 = changGidncWork.Guidance1;
                // 詳細ページURL
                drChangGidncRoot[ SFCMN00771WB.ctColumnName_DetailPageUrl ]             = this.CreateMulticastDetailUrl(
                    changGidncWork.McastGidncVersionCd, changGidncWork.MulticastConsNo, changGidncWork.McastGidncCntntsCd, changGidncWork.SystemDivCd, changGidncWork.McastGidncMainteCd );

                //
                // テーブルに追加
                dtChangGidncRoot.Rows.Add(drChangGidncRoot);
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
            if (!dtChangGidnc.Rows.Contains( changGidncKey ) )
            {
                // プログラム配信案内テーブルに新規登録
                DataRow drChangGidnc = dtChangGidnc.NewRow();

                // 案内内容区分
                drChangGidnc[ SFCMN00771WB.ctColumnName_McastGidncCntntsCd ]    = changGidncWork.McastGidncCntntsCd;
                // パッケージ区分
                drChangGidnc[ SFCMN00771WB.ctColumnName_ProductCode ]           = changGidncWork.ProductCode;
                // 配信案内 バージョン区分
                drChangGidnc[ SFCMN00771WB.ctColumnName_McastGidncVersionCd ]   = changGidncWork.McastGidncVersionCdZeroSup;
                // 配信提供区分
                drChangGidnc[ SFCMN00771WB.ctColumnName_McastOfferDivCd ]       = changGidncWork.McastOfferDivCd;
                // 更新グループコード
                drChangGidnc[ SFCMN00771WB.ctColumnName_UpdateGroupCode ]       = changGidncWork.UpdateGroupCode;
                // 企業コード
                drChangGidnc[ SFCMN00771WB.ctColumnName_EnterpriseCode ]        = changGidncWork.EnterpriseCode;
                // 連番 ※案内区分･パッケージ区分･バージョン区分毎に自動採番
                drChangGidnc[ SFCMN00771WB.ctColumnName_MulticastConsNo ]       = changGidncWork.MulticastConsNo;
                // メンテナンス予定日時 開始
                drChangGidnc[ SFCMN00771WB.ctColumnName_ServerMainteStScdl ]    = this.LongDateToDateTime( changGidncWork.ServerMainteStScdl );
                // メンテナンス予定日時 終了
                drChangGidnc[ SFCMN00771WB.ctColumnName_ServerMainteEdScdl ]    = this.LongDateToDateTime( changGidncWork.ServerMainteEdScdl );
                // メンテナンス日時 開始
                drChangGidnc[ SFCMN00771WB.ctColumnName_ServerMainteStTime ]    = this.LongDateToDateTime( changGidncWork.ServerMainteStTime );
                // メンテナンス日時 終了
                drChangGidnc[ SFCMN00771WB.ctColumnName_ServerMainteEdTime ]    = this.LongDateToDateTime( changGidncWork.ServerMainteEdTime );
                // 配信案兄 新規・改良区分 ※1:新規 2:改良 3:障害
                drChangGidnc[ SFCMN00771WB.ctColumnName_McastGidncNewCustmCd ]  = changGidncWork.McastGidncNewCustmCd;
                // 配信案兄 新規・改良区分名称
                drChangGidnc[ SFCMN00771WB.ctColumnName_McastGidncNewCustmNm ]  = ConstantManagement_NS_MGD.GetMcastGidncNewCustmCdNm( changGidncWork.McastGidncNewCustmCd );
                // 配信案内 メンテ区分 ※1:定期メンテ 2:データメンテ 9:緊急メンテ
                drChangGidnc[ SFCMN00771WB.ctColumnName_McastGidncMainteCd ]    = changGidncWork.McastGidncMainteCd;
                // 配信案内 メンテ区分名称
                drChangGidnc[ SFCMN00771WB.ctColumnName_McastGidncMainteNm ]    = ConstantManagement_NS_MGD.GetServerMainteDivNm( changGidncWork.McastGidncMainteCd );
                // システム区分 ※0:共通 1:SF 2:BK 3:SH
                drChangGidnc[ SFCMN00771WB.ctColumnName_SystemDivCd ]           = changGidncWork.SystemDivCd;
                // システム区分名称
                drChangGidnc[ SFCMN00771WB.ctColumnName_SystemDivNm ]           = ConstantManagement_NS_MGD.GetMulticastSystemDivNm( changGidncWork.ProductCode, changGidncWork.SystemDivCd );
                // 案内文１ ※案内区分=1(プログラム配信):配信プログラム名称, =2(サーバーメンテナンス):サーバーメンテナンス内容, =3(印字位置リリース情報):帳票名称
                drChangGidnc[ SFCMN00771WB.ctColumnName_Guidance1 ]             = changGidncWork.Guidance1;
                // 地域
                drChangGidnc[ SFCMN00771WB.ctColumnName_Area ]                  = changGidncWork.Area;
                // 詳細ページURL
                drChangGidnc[ SFCMN00771WB.ctColumnName_DetailPageUrl ]         = this.CreateMulticastDetailUrl(changGidncWork.McastGidncVersionCd, changGidncWork.MulticastConsNo, changGidncWork.McastGidncCntntsCd, changGidncWork.SystemDivCd, changGidncWork.McastGidncMainteCd );

                dtChangGidnc.Rows.Add( drChangGidnc );
            }
        }

        #endregion

        #region ■変更案内明細ワーククラスDataSet格納処理

        /// <summary>
        /// 変更案内明細ワーククラスDataSet格納処理
        /// </summary>
        /// <param name="ds">格納対象DataSet</param>
        /// <param name="chgGidncDtWork">プログラム配信案内明細ワーククラス</param>
        /// <remarks>
        /// <br>Note       : 指定されたプログラム配信案内明細ワーククラスをDataSet内のテーブルに格納します。</br>
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2007.12.18</br>
        /// </remarks>
        private void AddChgGidncDtWorkToDataSet(DataSet ds, ChgGidncDtWork chgGidncDtWork)
        {
            // プログラム配信案内明細テーブルを取得
            DataTable dtChgGidncDt = null;
            if (ds.Tables.Contains(SFCMN00771WB.ctTableName_ChgGidncDt))
            {
                dtChgGidncDt = ds.Tables[SFCMN00771WB.ctTableName_ChgGidncDt];
            }

            // テーブルの取得に失敗した場合は処理を行わない
            if (dtChgGidncDt == null)
            {
                return;
            }

            // プログラム配信案内明細テーブルに新規登録
            DataRow drChgGidncDt = dtChgGidncDt.NewRow();

            // 配信案内 案内内容区分
            drChgGidncDt[SFCMN00771WB.ctColumnName_McastGidncCntntsCd]      = chgGidncDtWork.McastGidncCntntsCd;
            // パッケージ区分
            drChgGidncDt[SFCMN00771WB.ctColumnName_ProductCode]             = chgGidncDtWork.ProductCode;
            // 配信案内 バージョン区分
            drChgGidncDt[SFCMN00771WB.ctColumnName_McastGidncVersionCd]     = chgGidncDtWork.McastGidncVersionCdZeroSup;
            // 配信提供区分
            drChgGidncDt[SFCMN00771WB.ctColumnName_McastOfferDivCd]         = chgGidncDtWork.McastOfferDivCd;
            // 更新グループコード
            drChgGidncDt[SFCMN00771WB.ctColumnName_UpdateGroupCode]         = chgGidncDtWork.UpdateGroupCode;
            // 企業コード
            drChgGidncDt[SFCMN00771WB.ctColumnName_EnterpriseCode]          = chgGidncDtWork.EnterpriseCode;
            // 連番 ※案内区分･パッケージ区分･バージョン区分毎に自動採番
            drChgGidncDt[SFCMN00771WB.ctColumnName_MulticastConsNo]         = chgGidncDtWork.MulticastConsNo;
            // 連番サブコード ※案内区分･パッケージ区分･バージョン区分･連番毎に自動採番
            drChgGidncDt[SFCMN00771WB.ctColumnName_MulticastSubCode]        = chgGidncDtWork.MulticastSubCode;
            // 変更内容 ※案内区分=1(プログラム配信):変更詳細, =2(サーバーメンテナンス):サーバーメンテナンス案内文, =3(印字位置リリース情報):印字位置案内文
            drChgGidncDt[SFCMN00771WB.ctColumnName_ChangeContents]          = chgGidncDtWork.ChangeContents;
            // 別紙ファイル有無区分
            drChgGidncDt[SFCMN00771WB.ctColumnName_AnothersheetFileExst]    = chgGidncDtWork.AnothersheetFileExst;
            // 別紙ファイル名
            drChgGidncDt[SFCMN00771WB.ctColumnName_AnothersheetFileName]    = ctAnotherSheetsDirUrl + chgGidncDtWork.AnothersheetFileName;

            dtChgGidncDt.Rows.Add(drChgGidncDt);
        }

        #endregion
        
        #region ■緊急メンテナンス情報作成処理

        /// <summary>
        /// 緊急メンテナンス情報作成処理
        /// </summary>
        /// <param name="emergencySvrMntInfoWorkList">緊急メンテナンス情報リスト</param>
        /// <remarks>
        /// <br>Note       : 緊急メンテナンス情報を作成します。</br>
        /// <br>Programmer : 23013 秋山　亮介</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void CreateEmergencyMainteInfo(List<ChangGidncWork> emergencySvrMntInfoWorkList)
        {
            // サーバーメンテナンス情報データセット作成
            DataSet ds = new DataSet();
            SFCMN00771WB.CreateChangGidncDataSet(ref ds);

            foreach (ChangGidncWork changGidncWork in emergencySvrMntInfoWorkList)
            {
                this.AddChangGidncWorkToDataSet(ds, changGidncWork);
            }

            this.ImportantInfo_repeater.DataSource = ds;
            //this.ImportantInfo_repeater.DataMember = SFCMN00771WB.ctTableName_ChangeGidnc;
            this.ImportantInfo_repeater.DataMember = SFCMN00771WB.ctTableName_ChangeGidncRoot;
            this.ImportantInfo_repeater.DataBind();
        }

        #endregion
        
        #region ■サーバーメンテナンス情報ワーククラスDataSet格納処理 MEMO:いずれ削除するメソッド 2007.12.18 DEL
        /*
        /// <summary>
        /// サーバーメンテナンス情報ワーククラスDataSet格納処理
        /// </summary>
        /// <param name="ds">格納対象DataSet</param>
        /// <param name="svrMntInfoWork">サーバーメンテナンス情報ワーククラス</param>
        /// <remarks>
        /// <br>Note       : 指定されたサーバーメンテナンス情報ワーククラスをDataSet内のテーブルに格納します。</br>
        /// <br>Programmer : 23001 秋山　亮介</br>
        /// <br>Date       : 2007.03.07</br>
        /// </remarks>
        private void AddSvrMntInfoWorkToDataSet(DataSet ds, SvrMntInfoWork svrMntInfoWork)
        {
            // プログラム配信案内明細テーブルを取得
            DataTable dtSvrMntInfo = null;
            if (ds.Tables.Contains(SFCMN00771WB.ctTableName_ChangeGidnc))
            {
                dtSvrMntInfo = ds.Tables[SFCMN00771WB.ctTableName_ChangeGidnc];
            }

            // テーブルの取得に失敗した場合は処理を行わない
            if (dtSvrMntInfo == null)
            {
                return;
            }

            // プログラム配信案内明細テーブルに新規登録
            DataRow drSvrMntInfo = dtSvrMntInfo.NewRow();

            // パッケージ区分
            drSvrMntInfo[SFCMN00771WB.ctColumnName_ProductCode] = svrMntInfoWork.ProductCode;
            // サーバーメンテナンス連番
            drSvrMntInfo[SFCMN00771WB.ctColumnName_MulticastConsNo] = svrMntInfoWork.ServerMainteConsNo;
            // サーバーメンテナンス区分
            drSvrMntInfo[SFCMN00771WB.ctColumnName_McastGidncMainteCd] = svrMntInfoWork.ServerMainteDivCd;
            // サーバーメンテナンス区分名称
            string serverMainteDivNm = ConstantManagement_NS_MGD.GetServerMainteDivNm(svrMntInfoWork.ServerMainteDivCd);
            drSvrMntInfo[SFCMN00771WB.ctColumnName_McastGidncMainteNm] = serverMainteDivNm;
            // サーバーメンテナンス開始予定日時
            drSvrMntInfo[SFCMN00771WB.ctColumnName_ServerMainteStScdl] = this.LongDateToDateTime(svrMntInfoWork.ServerMainteStScdl);
            // サーバーメンテナンス終了予定日時
            drSvrMntInfo[SFCMN00771WB.ctColumnName_ServerMainteEdScdl] = this.LongDateToDateTime(svrMntInfoWork.ServerMainteEdScdl);
            // サーバーメンテナンス開始日時
            drSvrMntInfo[SFCMN00771WB.ctColumnName_ServerMainteStTime] = this.LongDateToDateTime(svrMntInfoWork.ServerMainteStTime);
            // サーバーメンテナンス終了日時
            drSvrMntInfo[SFCMN00771WB.ctColumnName_ServerMainteEdTime] = this.LongDateToDateTime(svrMntInfoWork.ServerMainteEdTime);
            // サーバーメンテナンス内容
            drSvrMntInfo[SFCMN00771WB.ctColumnName_Guidance1] = svrMntInfoWork.ServerMainteCntnts;
            // サーバーメンテナンス案内文
            drSvrMntInfo[SFCMN00771WB.ctColumnName_ServerMainteOutputMessage] = svrMntInfoWork.ServerMainteGidnc;

            string serverMainteOutputMessage = "";
            // メンテナンス予定
            if ((svrMntInfoWork.ServerMainteStTime == 0) &&
                (svrMntInfoWork.ServerMainteEdTime == 0))
            {
                // メンテナンス終了予定が入っていない場合
                if (svrMntInfoWork.ServerMainteEdScdl == 0)
                {
                    serverMainteOutputMessage =
                        String.Format("{0} より、{1}を実施いたします。",
                        this.GetDateTimeString(svrMntInfoWork.ServerMainteStScdl, true),
                        serverMainteDivNm);
                }
                else
                {
                    serverMainteOutputMessage =
                        String.Format("{0} から {1} まで、{2}を実施いたします。",
                        this.GetDateTimeString(svrMntInfoWork.ServerMainteStScdl, true),
                        this.GetDateTimeString(svrMntInfoWork.ServerMainteEdScdl, true),
                        serverMainteDivNm);
                }
            }
            // メンテナンス中
            else if ((svrMntInfoWork.ServerMainteStTime != 0) &&
                (svrMntInfoWork.ServerMainteEdTime == 0))
            {
                // メンテナンス終了予定が入っていない場合
                if (svrMntInfoWork.ServerMainteEdScdl == 0)
                {
                    serverMainteOutputMessage =
                        String.Format("ただいま、{0}を実施しております。",
                        serverMainteDivNm);
                }
                else
                {
                    serverMainteOutputMessage =
                        String.Format("ただいま、{0}を実施しております。終了時刻は、{1} を予定しております。",
                        serverMainteDivNm,
                        this.GetDateTimeString(svrMntInfoWork.ServerMainteEdScdl, true));
                }
            }
            // メンテナンス終了
            else
            {
                serverMainteOutputMessage = String.Format("{0}は、{1} に終了致しました。",
                    serverMainteDivNm,
                    this.GetDateTimeString(svrMntInfoWork.ServerMainteEdTime, true));
            }

            // サーバーメンテナンス出力メッセージ
            drSvrMntInfo[SFCMN00771WB.ctColumnName_ServerMainteOutputMessage] = serverMainteOutputMessage;
            // 詳細ページURL
            drSvrMntInfo[SFCMN00771WB.ctColumnName_DetailPageUrl] = this.CreateServerMainteDetailUrl(svrMntInfoWork.ServerMainteConsNo);

            dtSvrMntInfo.Rows.Add(drSvrMntInfo);
        }
        */
        #endregion
        
        #region ■最新 変更案内情報作成処理 (.NS配信、サーバーメンテを統合)

        /// <summary>
        /// 最新 変更案内情報作成処理
        /// </summary>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <param name="mcastGidncCntntsCd">案内区分</param>
        /// <param name="mcastGidncMainteCd">メンテナンス区分</param>
        /// <remarks>
        /// <br>Note       : 最新 .NS 配信情報を作成します。</br>
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2007.12.06</br>
        /// </remarks>
        private int CreateNewChangGidnc(ref string errorMessage, int mcastGidncCntntsCd)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            DataSet ds = new DataSet();
            SFCMN00771WB.CreateChangGidncDataSet(ref ds);

            List<ChangGidncWork> changGidncWorkList = new List<ChangGidncWork>();
            List<ChgGidncDtWork> chgGidncDtWorkList = new List<ChgGidncDtWork>();

            // データメンテ情報リスト
            List<ChangGidncWork> wkChangGidncWorkList = new List<ChangGidncWork>();
            List<ChgGidncDtWork> wkChgGidncDtWorkList = new List<ChgGidncDtWork>();
            // 緊急メンテナンス情報リスト
            List<ChangGidncWork> emergencySvrMntInfoWorkList = new List<ChangGidncWork>();

            // 検索部品インスタンス生成
            if (this._changeInfoSearchManager == null)
            {
                this._changeInfoSearchManager = new ChangeInfoSearchManager();
            }

            string errMsg = "";
            int totalCount = 0;
            ChangGidncParaWork changGidncParaWork = new ChangGidncParaWork();
            changGidncParaWork.MulticastSystemDivCd = -1;    // 全システムを検索
            changGidncParaWork.McastGidncCntntsCd = mcastGidncCntntsCd; // 案内区分をセット

            int searchCount = 0;
            switch (mcastGidncCntntsCd)
            {
                case 1:
                    searchCount = ctMulticastInfoDispCount;
                    break;
                case 2:
                    // データメンテステータス
                    int dbStatus = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    // サーバーメンテステータス
                    int mainteSt = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                    // データメンテ
                    searchCount = ctDataMainteInfoDispCount;
                    changGidncParaWork.McastGidncMainteCd = 2;
                    // データメンテのデータ取得
                    dbStatus = this._changeInfoSearchManager.SearchChangGidnc(Globals.QueryStringController.AccessTicket, changGidncParaWork, 0, searchCount, out totalCount, out changGidncWorkList, out chgGidncDtWorkList, out errMsg);
                    if ((dbStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                        (dbStatus == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
                        (dbStatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                    {
                        // 定期メンテ・緊急メンテ
                        searchCount = ctServerMainteInfoDispCount;
                        changGidncParaWork.McastGidncMainteCd = -1;

                        if(changGidncWorkList == null)
                        {
	                        // 定期メンテ・緊急メンテのデータ取得
	                        mainteSt = this._changeInfoSearchManager.SearchChangGidnc(Globals.QueryStringController.AccessTicket, changGidncParaWork, 0, searchCount, out totalCount, out changGidncWorkList, out chgGidncDtWorkList, out errMsg);
	                        if ((mainteSt == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
	                            (mainteSt == (int)ConstantManagement.DB_Status.ctDB_EOF))
	                        {
	                        }
	                        else if (mainteSt != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
	                        {
	                            status = mainteSt;
	                        }
                        }
                        else
                        {
	                        // 定期メンテ・緊急メンテのデータ取得
	                        mainteSt = this._changeInfoSearchManager.SearchChangGidnc(Globals.QueryStringController.AccessTicket, changGidncParaWork, 0, searchCount, out totalCount, out wkChangGidncWorkList, out wkChgGidncDtWorkList, out errMsg);
	                        if ((mainteSt == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
	                            (mainteSt == (int)ConstantManagement.DB_Status.ctDB_EOF))
	                        {
	                            changGidncWorkList.AddRange(wkChangGidncWorkList);
	                            if(chgGidncDtWorkList != null)  chgGidncDtWorkList.AddRange(wkChgGidncDtWorkList);
                                else                            chgGidncDtWorkList = wkChgGidncDtWorkList;
	                        }
	                        else if (mainteSt != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
	                        {
	                            status = mainteSt;
	                        }
                        }

                    }
                    else {
                        status = dbStatus;
                    }
                    if (status != mainteSt)
                    {
                        // ステータスセット
                        if ((dbStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                            (mainteSt == (int)ConstantManagement.DB_Status.ctDB_NORMAL))
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        else if ((dbStatus == (int)ConstantManagement.DB_Status.ctDB_EOF || dbStatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                            (mainteSt == (int)ConstantManagement.DB_Status.ctDB_EOF || mainteSt == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                        }
                    }
                    break;
                //case 3:
                //    searchCount = ctPrintPosisionInfoDispCount;
                //    break;
                default:
                    break;
            }

            // サーバーメンテ以外のデータを取得
            if (mcastGidncCntntsCd != 2) {
                status = this._changeInfoSearchManager.SearchChangGidnc(Globals.QueryStringController.AccessTicket, changGidncParaWork, 0, searchCount, out totalCount, out changGidncWorkList, out chgGidncDtWorkList, out errMsg);
            }

            switch (status)
            {
                // 該当データ有り
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        switch (mcastGidncCntntsCd)
                        {
                            case 1:
                                // 最新 .NS 配信情報パネルを表示
                                this.NewMulticastInfo_panel.Visible     = true;
                                // 最新 .NS 配信情報を表示
                                this.NewMulticastInfo_repeater.Visible  = true;
                                // 該当データなしメッセージを非表示
                                this.NothingMulticastInfo_panel.Visible = false;

                                foreach (ChangGidncWork changGidncWork in changGidncWorkList)
                                {
                                    this.AddChangGidncWorkToDataSet(ds, changGidncWork);
                                }
                                foreach (ChgGidncDtWork chgGidncDtWork in chgGidncDtWorkList)
                                {
                                    this.AddChgGidncDtWorkToDataSet(ds, chgGidncDtWork);
                                }

                                this.NewMulticastInfo_repeater.DataSource = ds;
                                this.NewMulticastInfo_repeater.DataMember = SFCMN00771WB.ctTableName_ChangeGidncRoot;
                                this.NewMulticastInfo_repeater.DataBind();
                                break;
                            case 2:
                                // 最新 サーバーメンテナンス情報パネルを表示
                                this.NewServerMainteInfo_panel.Visible      = true;
                                // 最新 サーバーメンテナンス情報表示
                                this.NewServerMainteInfo_repeater.Visible   = true;
                                // 該当データなし、メッセージ表示
                                this.NothingServerMainteInfo_panel.Visible  = false;

                                foreach (ChangGidncWork changGidncWork in changGidncWorkList)
                                {
                                    // 緊急メンテナンスの場合
                                    if (changGidncWork.McastGidncMainteCd == (int)ConstantManagement_NS_MGD.MainteDiv.Emergency)
                                    {
                                        // 終了日時の有無をチェック
                                        if (changGidncWork.ServerMainteEdTime == 0)
                                        {
                                            // 終了していないので、緊急情報をリストに追加
                                            emergencySvrMntInfoWorkList.Add(changGidncWork);
                                        }
                                    }
                                    this.AddChangGidncWorkToDataSet(ds, changGidncWork);
                                }
                                foreach (ChgGidncDtWork chgGidncDtWork in chgGidncDtWorkList)
                                {
                                    this.AddChgGidncDtWorkToDataSet(ds, chgGidncDtWork);
                                }

                                this.NewServerMainteInfo_repeater.DataSource = ds;
                                //this.NewServerMainteInfo_repeater.DataMember = SFCMN00771WB.ctTableName_ChangeGidnc;
                                this.NewServerMainteInfo_repeater.DataMember = SFCMN00771WB.ctTableName_ChangeGidncRoot;
                                this.NewServerMainteInfo_repeater.DataBind();

                                // 緊急メンテナンス情報が存在する場合
                                if (emergencySvrMntInfoWorkList.Count > 0)
                                {
                                    // 緊急メンテナンス情報表示
                                    this.ImportantInfo_panel.Visible = true;

                                    // 緊急メンテナンス情報を画面に展開
                                    this.CreateEmergencyMainteInfo(emergencySvrMntInfoWorkList);
                                }
                                else
                                {
                                    // 緊急メンテナンス情報非表示
                                    this.ImportantInfo_panel.Visible = false;
                                }
                                break;
                            //case 3:
                            //    // 最新 印字位置リリース情報パネルを表示
                            //    this.NewPrintPointInfo_panel.Visible        = true;
                            //    // 最新 印字位置リリース情報を表示
                            //    this.NewPrintPointInfo_repeater.Visible     = true;
                            //    // 該当データなしメッセージを非表示
                            //    this.NothingPrintReleaseInfo_panel.Visible  = false;

                            //    foreach (ChangGidncWork changGidncWork in changGidncWorkList)
                            //    {
                            //        this.AddChangGidncWorkToDataSet(ds, changGidncWork);
                            //    }
                            //    foreach (ChgGidncDtWork chgGidncDtWork in chgGidncDtWorkList)
                            //    {
                            //        this.AddChgGidncDtWorkToDataSet(ds, chgGidncDtWork);
                            //    }

                            //    this.NewPrintPointInfo_repeater.DataSource = ds;
                            //    this.NewPrintPointInfo_repeater.DataMember = SFCMN00771WB.ctTableName_ChangeGidncRoot;
                            //    this.NewPrintPointInfo_repeater.DataBind();

                            //    break;
                        }

                        break;
                    }
                // 該当データなし
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        switch (mcastGidncCntntsCd)
                        {
                            case 1:
                                // 最新 .NS 配信情報パネルを表示
                                this.NewMulticastInfo_panel.Visible     = true;
                                // 最新 .NS 配信情報を非表示
                                this.NewMulticastInfo_repeater.Visible  = false;
                                // 該当データなしメッセージを表示
                                this.NothingMulticastInfo_panel.Visible = true;

                                // 該当データなしメッセージを表示
                                this.NothingMulticastInfo_literal.Text = ctMessage_NoData;
                                break;
                            case 2:
                                // 最新 サーバーメンテナンス情報パネルを表示
                                this.NewServerMainteInfo_panel.Visible      = true;
                                // 最新 サーバーメンテナンス情報非表示
                                this.NewServerMainteInfo_repeater.Visible   = false;
                                // 該当データなし、メッセージ表示
                                this.NothingServerMainteInfo_panel.Visible  = true;
                                // 緊急メンテナンス情報非表示
                                this.ImportantInfo_panel.Visible            = false;

                                // 該当データなしメッセージを表示
                                this.NothingServerMainteInfo_literal.Text = ctMessage_NoData;
                                break;
                            //case 3:
                            //    // 最新 印字位置リリース情報パネルを表示
                            //    this.NewPrintPointInfo_panel.Visible        = true;
                            //    // 最新 印字位置リリース情報を非表示
                            //    this.NewPrintPointInfo_repeater.Visible     = false;
                            //    // 該当データなしメッセージを表示
                            //    this.NothingPrintReleaseInfo_panel.Visible  = true;

                            //    // 該当データなしメッセージを表示
                            //    this.NothingPrintReleaseInfo_literal.Text = ctMessage_NoData;
                            //    break;
                        }

                        status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                        break;
                    }
                // エラー
                default:
                    {
                        // 例外をスロー
                        throw (new NSChangeInfoErrorException(status, errMsg));
                    }
            }

            return status;
        }

        #endregion
        // --------------------------------------------------<<<<< End
		#endregion

		#region << Control Events >>

		#region ■Load イベント (SFCMN00771W)

		/// <summary>
		/// Load イベント (SFCMN00771W)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ページがロードされるときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.02.19</br>
		/// </remarks>
		protected void Page_Load( object sender, EventArgs e )
		{
			// ログ書き込み部品を初期化
			this._changePgGuideLogOutPut = new ChangePgGuideLogOutPut();

			// クライアントスクリプトを登録
			this.RegisterClientScripts();

            // Newフラグ用パラメータを保持(cokkie)
            if (this.Session["CHG"] == null) {
                this.Session["CHG"] = Globals.QueryStringController.CtCHG;
            }

			// ポストバック
			if( this.IsPostBack ) {
			}
			else {
				// 画面を初期化
				this.ScreenInitialize();

                // 2007.12.17 Maki Change ----------------------------------------------------------------------------->>>>>
				// 最新 .NS 配信情報 Repeater コントロールのアイテムテンプレート(簡易モード)をセット
				//this.NewMulticastInfo_repeater.ItemTemplate    = new SFCMN00771WC( SFCMN00771WC.TemplateMode.Simple );
				// 最新 メンテナンス情報 Repeater コントロールのアイテムテンプレートをセット
                //this.NewServerMainteInfo_repeater.ItemTemplate = new SFCMN00771WD(SFCMN00771WD.TemplateMode.Simple); 
				// 重要なお知らせ Repeater コントロールのアイテムテンプレートをセット
                //this.ImportantInfo_repeater.ItemTemplate = new SFCMN00771WD(SFCMN00771WD.TemplateMode.Detail);

                // 最新 .NS 配信情報 Repeater コントロールのアイテムテンプレート(簡易モード)をセット
                this.NewMulticastInfo_repeater.ItemTemplate     = new SFCMN00771WC( SFCMN00771WC.TemplateMode.Simple, 200, 1 );
                // 最新 メンテナンス情報 Repeater コントロールのアイテムテンプレートをセット
                this.NewServerMainteInfo_repeater.ItemTemplate  = new SFCMN00771WC( SFCMN00771WC.TemplateMode.Simple, 0, 2 );
                // 重要なお知らせ Repeater コントロールのアイテムテンプレートをセット
                this.ImportantInfo_repeater.ItemTemplate        = new SFCMN00771WC( SFCMN00771WC.TemplateMode.Detail, 0, 2, 9 );
                //// 印字位置リリース情報 Repeater コントロールのアイテムテンプレートをセット
                //this.NewPrintPointInfo_repeater.ItemTemplate    = new SFCMN00771WC( SFCMN00771WC.TemplateMode.Simple, 0, 3 );
                // ----------------------------------------------------------------------------------------------------<<<<<
                
				// 最新 .NS 配信情報生成
				int    status       = 0;
				string errorMessage = "";

                // 2007.12.17 Maki Change ----------------------------------------->>>>>
				// .NS 配信情報検索
                //status = this.CreateNewMulticastInfo( ref errorMessage );
                //if( ( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) || 
                //    ( status == ( int )ConstantManagement.DB_Status.ctDB_EOF ) ) {
                //    // サーバーメンテナンス情報検索
                //    status = this.CreateNewServerMainteInfo( ref errorMessage );
                //}
                // .NS 配信情報検索
                status = this.CreateNewChangGidnc(ref errorMessage, 1 );
                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    // データメンテナンス情報検索
                    status = this.CreateNewChangGidnc(ref errorMessage, 2 );
                    if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                    {
                        //// 印字位置リリース情報検索
                        //status = this.CreateNewChangGidnc(ref errorMessage, 3);
                    }
                    // 2008.01.09 Maki Add ----------------------------------------------->>>>>
                    // 新着情報有無を判断して「NEW」を表示するか判断
                    if (this.Session["CHG"] != null)
                    {
                        string chg = this.Session["CHG"].ToString();

                        for (int ix = 0; ix < chg.Length; ix++)
                        {
                            string newFlg = chg.Substring(ix, 1);
                            if (newFlg == "1")
                            {
                                switch (ix)
                                {
                                    case 0:
                                        // プログラム配信
                                        this.NewMulticastInfo_img.Visible = true;
                                        break;
                                    case 1:
                                        // 定期メンテorデータメンテ
                                        this.NewServerMainteInfo_img.Visible = true;
                                        break;
                                    case 2:
                                        // 緊急メンテ
                                        this.ImportantInfo_img.Visible = true;
                                        break;
                                    //case 3:
                                    //    // 印字位置情報
                                    //    this.NewPrintPointInfo_img.Visible = true;
                                    //    break;
                                }
                                // 緊急メンテが新着の場合は、サーバーメンテも新着表示する
                                if (this.ImportantInfo_img.Visible == true) {
                                    this.NewServerMainteInfo_img.Visible = true;
                                }
                            }
                        }
                    }
                    // -------------------------------------------------------------------<<<<<
                }
                // ----------------------------------------------------------------<<<<<

				// エラーの場合
				if( ( status != ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) && 
					( status != ( int )ConstantManagement.DB_Status.ctDB_EOF ) ) {
					// 最新 .NS 配信情報パネルを非表示
					this.NewMulticastInfo_panel.Visible                  = false;
					// 最新 サーバーメンテナンス情報パネルを非表示
					this.NewServerMainteInfo_panel.Visible               = false;
					// 緊急メンテナンス情報非表示
					this.ImportantInfo_panel.Visible                     = false;
					// エラー情報パネルを表示
					this.ErrorMessage_panel.Visible                      = true;

					// エラーメッセージをセット
					this.ErrorMessage_literal.Text                       = errorMessage;
				}
                // 2007.12.11 Maki Add ------------------------------------------------------------>>>>>
                // 変更区分 onchangeイベント追加
                this.MulticastInfoDivCd_dropDownList.Attributes.Add("onchange",
                    "DtlSearchMcasExpand( ID_MulticastInfoDivCd_dropDownList );");
                //変更内容にフォーカスをセット
                this.ChangeContents_textBox.Focus();
                // --------------------------------------------------------------------------------<<<<<
			}
		}

		#endregion

		#region ■Click イベント (MenuSearch_imageButton)

		/// <summary>
		/// Click イベント (MenuSearch_imageButton)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : コントロールがクリックされたときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.02.19</br>
		/// </remarks>
		protected void MenuSearch_imageButton_Click( object sender, ImageClickEventArgs e )
		{
			// クエリ作成
			QueryStringController query = new QueryStringController();
			query.AccessTicket = Globals.QueryStringController.AccessTicket;

			// .NS 配信情報検索へリダイレクト
			Response.Redirect( ctMulticastSearchUrl + query.ToString() );
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
			if( this.ChangeContents_textBox.Text.Trim() != String.Empty ) {
				isValid = true;
			}

            // 2007.12.05 Maki Add -------------------------------------->>>>>
            // 検索対象
            //if (this.MulticastInfoDivCd_dropDownList.SelectedIndex > 0)
            //{
            //    isValid = true;
            //}

            // 地域
            if (this.Area_textBox.Text.Trim() != String.Empty) {
                isValid = true;
            }

            // 帳票名称
            if (this.PrintName_textBox.Text.Trim() != String.Empty) {
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
            if (this.StMainteDate_textBox.Text.Trim() != String.Empty) {
                isValid = true;
            }

            // 終了サーバーメンテ予定日
            if (this.EdMainteDate_textBox.Text.Trim() != String.Empty) {
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
        protected void Search_imageButton_Command(object sender, CommandEventArgs e)
        {
            string a = e.CommandName;

            string b = a;
        }
}
}
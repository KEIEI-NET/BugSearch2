using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;

// Global.aspx アクセス用
using Globals = ASP.global_asax;

namespace Broadleaf.Web.UI
{
	/// <summary>
	/// .NS 配信詳細情報Webページ
	/// </summary>
	/// <remarks>
	/// <br>Note       : .NS 配信詳細情報を表示します。</br>
	/// <br>Programmer : 23001 秋山　亮介</br>
	/// <br>Date       : 2007.02.19</br>
    /// <br></br>
    /// <br>UpDateNote : 23013 牧　将人 サーバー詳細情報Webページを統合(統一明細画面を作成)</br>
	/// </remarks>
	public partial class SFCMN00772W : System.Web.UI.Page
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
		//private const string ctServerMainteDetailUrl = "SFCMN00774W.aspx"; //2008.01.11 DEL
		/// <summary>別紙格納フォルダURL</summary>
		private const string ctAnotherSheetsDirUrl   = "AnotherSheets/";

		#endregion

		#region ■メッセージ表示用テキスト

		/// <summary>メッセージ表示用テキスト「該当の情報が見つかりませんでした。」</summary>
		private const string ctMessage_NoData = "該当の情報が見つかりませんでした。";
		/// <summary>メッセージ表示用テキスト「ページを作成中にエラーが発生しました。」</summary>
		private const string ctmessage_Error  = "ページを作成中にエラーが発生しました。";

		#endregion

		#endregion

		#region << Private Members >>

		/// <summary>変更PG案内検索部品</summary>
		private ChangeInfoSearchManager _changeInfoSearchManager = null;

		/// <summary>ログ出力部品</summary>
		private ChangePgGuideLogOutPut  _changePgGuideLogOutPut  = null;

		#endregion

		#region << Private Methods >>

		#region ■.NS 配信詳細情報設定処理

		/// <summary>
		/// .NS 配信詳細情報設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : .NS 配信詳細情報の各項目をセットします。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.02.19</br>
		/// </remarks>
		private int SetMulticastDetailInfo()
		{
			int status = 0;

			// 検索部品インスタンス生成
			if( this._changeInfoSearchManager == null ) {
				this._changeInfoSearchManager = new ChangeInfoSearchManager();
			}

			List<ChangGidncWork> changGidncWorkList = new List<ChangGidncWork>();    // プログラム配信案内ワークリスト
			List<ChgGidncDtWork> chgGidncDtWorkList = new List<ChgGidncDtWork>();    // プログラム配信案内明細ワークリスト
			string errMsg   = "";   // エラーメッセージ
            int totalCount  = 0;    // 検索結果最大件数
            ChangGidncParaWork changGidncParaWork = new ChangGidncParaWork();
            changGidncParaWork.MulticastSystemDivCd = ( int )Globals.QueryStringController.SystemDivCd;         // システムコードをセット
            changGidncParaWork.McastGidncCntntsCd   = ( int )Globals.QueryStringController.McastGidncCntntsCd;  // 案内区分をセット
            changGidncParaWork.EdMulticastVersion   = Globals.QueryStringController.MulticastVersion;           // 配信バージョンをセット
            changGidncParaWork.MulticastConsNo      = ( int )Globals.QueryStringController.MulticastConsNo;     // 連番をセット

            // 検索実行
            status = this._changeInfoSearchManager.SearchChangGidnc(
                Globals.QueryStringController.AccessTicket, changGidncParaWork, 0, 1,
                out totalCount, out changGidncWorkList, out chgGidncDtWorkList, out errMsg);
            // 2007.12.25 Maki Add ------------------------------------->>>>>
            switch ( Globals.QueryStringController.McastGidncCntntsCd )
            {
                case 1:
                    // .NS配信詳細情報
                    this.MulticastTitle_panel.Visible       = true;
                    // サーバーメンテナンス詳細情報
                    this.ServerMainteTitle_panel.Visible    = false;
                    //// 印字位置リリース詳細情報
                    //this.PrintPointTitle_panel.Visible      = false;
                    break;
                case 2:
                    // .NS配信詳細情報
                    this.MulticastTitle_panel.Visible       = false;
                    // サーバーメンテナンス詳細情報
                    this.ServerMainteTitle_panel.Visible    = true;
                    //// 印字位置リリース詳細情報
                    //this.PrintPointTitle_panel.Visible      = false;
                    break;
                case 3:
                    // .NS配信詳細情報
                    this.MulticastTitle_panel.Visible       = false;
                    // サーバーメンテナンス詳細情報
                    this.ServerMainteTitle_panel.Visible    = false;
                    //// 印字位置リリース詳細情報
                    //this.PrintPointTitle_panel.Visible      = true;
                    break;
                default:
                    break;
            }
            // ---------------------------------------------------------<<<<<
			switch( status ) {
				// 該当データ有り
				case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					// 詳細情報パネルを表示
					this.DetailInfo_panel.Visible  = true;
					// メッセージ表示パネルを非表示
					this.MessageInfo_panel.Visible = false;

					// 結果を表示
                    // 2007.12.25 Maki Change ------------------------------------------------------------------------------------------------------------------------------------------------->>>>>
                    //this.SetChangGidncListToDisp(Globals.QueryStringController.MulticastConsNo ?? -1, changGidncWorkList, chgGidncDtWorkList);
                    this.SetChangGidncListToDisp(Globals.QueryStringController.McastGidncCntntsCd, Globals.QueryStringController.MulticastConsNo ?? -1, changGidncWorkList, chgGidncDtWorkList);
                    // ------------------------------------------------------------------------------------------------------------------------------------------------------------------------<<<<<
                    break;
				}
				// 該当データなし
				case ( int )ConstantManagement.DB_Status.ctDB_EOF:
				case ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND:
				{
					// 詳細情報パネルを非表示
					this.DetailInfo_panel.Visible  = false;
					// メッセージ表示パネルを表示
					this.MessageInfo_panel.Visible = true;

					// 該当データなしメッセージを表示
					this.MessageInfo_literal.Text = ctMessage_NoData;

					status = ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND;
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

		#region ■プログラム配信案内リスト画面展開処理
	
		/// <summary>
		/// プログラム配信案内画面展開処理
		/// </summary>
        /// <param name="mcastGidncCntntsCd">配信案内 案内内容区分</param>
		/// <param name="multicastConsNo">配信連番</param>
		/// <param name="changGidncWorkList">プログラム配信案内ワークリスト</param>
		/// <param name="chgGidncDtWorkList">プログラム配信案内明細ワークリスト</param>
		/// <remarks>
		/// <br>Note       : プログラム配信案内のデータを画面に展開します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.16</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.12.25 牧　将人
        ///                 ・引数追加</br>
		/// </remarks>
        //private void SetChangGidncListToDisp(int multicastConsNo, List<ChangGidncWork> changGidncWorkList, List<ChgGidncDtWork> chgGidncDtWorkList)
        private void SetChangGidncListToDisp(int? mcastGidncCntntsCd, int multicastConsNo, List<ChangGidncWork> changGidncWorkList, List<ChgGidncDtWork> chgGidncDtWorkList)
		{
			// ----------------------------------------
			// 一旦検索データを整理する
            SortedList<int, ChangGidncWork> changGidncWorkSortedList                    = new SortedList<int, ChangGidncWork>();
			SortedList<int, SortedList<int, ChgGidncDtWork>> chgGidncDtWorkSortedList   = new SortedList<int, SortedList<int, ChgGidncDtWork>>();
			// プログラム配信案内
			foreach( ChangGidncWork wkChangGidncWork in changGidncWorkList ) {
				if( ! changGidncWorkSortedList.ContainsKey( wkChangGidncWork.MulticastConsNo ) ) {
					changGidncWorkSortedList.Add( wkChangGidncWork.MulticastConsNo, wkChangGidncWork );
				}
			}
			// プログラム配信案内明細
			foreach( ChgGidncDtWork wkChgGidncDtWork in chgGidncDtWorkList ) {
				SortedList<int,ChgGidncDtWork> listByMulticastConNo = null;

				// 既に対象の配信連番内リストが存在
				if( chgGidncDtWorkSortedList.ContainsKey( wkChgGidncDtWork.MulticastConsNo ) ) {
					// 既存リスト取得
					listByMulticastConNo = chgGidncDtWorkSortedList[ wkChgGidncDtWork.MulticastConsNo ];
				}
				else {
					// 新規リスト作成
					listByMulticastConNo = new SortedList<int, ChgGidncDtWork>();
					chgGidncDtWorkSortedList.Add( wkChgGidncDtWork.MulticastConsNo, listByMulticastConNo );
				}

				if( ! listByMulticastConNo.ContainsKey( wkChgGidncDtWork.MulticastSubCode ) ) {
					listByMulticastConNo.Add( wkChgGidncDtWork.MulticastSubCode, wkChgGidncDtWork );
				}
			}

			// ----------------------------------------
			// 対象バージョン・枝番のデータを取得(クエリで指定された枝番)
			ChangGidncWork changGidncWork = null;
			if( changGidncWorkSortedList.ContainsKey( multicastConsNo ) ) {
				changGidncWork = changGidncWorkSortedList[ multicastConsNo ];
			}

			// 対照データが見つからない場合
			if( changGidncWork == null ) {
				return;
			}

			// ----------------------------------------
			// 画面を表示
			// ----------------------------------------
			// 配信バージョン
			this.MulticastVersion_literal.Text = changGidncWork.McastGidncVersionCdZeroSup;

			// ----------------------------------------
			// 配信日付
			this.MulticastDate_literal.Text = TDateTime.DateTimeToString( "YYYYMMDD", changGidncWork.MulticastDate );

			// ----------------------------------------
			// システム区分
			this.MulticastSystemDivNm_literal.Text = String.Format( "{0} / {1}", 
				ConstantManagement_NS_MGD.GetMulticastSystemDivNm( changGidncWork.ProductCode, changGidncWork.SystemDivCd ), 
				//ConstantManagement_NS_MGD.GetProgramChgDivNm( changGidncWork.ProgramChgDivCd ) );
                ConstantManagement_NS_MGD.GetMcastGidncNewCustmCdNm( changGidncWork.McastGidncNewCustmCd ) );
			// ----------------------------------------
			// 配信プログラム
			this.MulticastProgramName_literal.Text = HttpUtility.HtmlEncode( changGidncWork.Guidance1 );

			// ----------------------------------------
			// 変更内容・別紙情報取得
			StringBuilder changeContentsBuilder = new StringBuilder();    // 変更内容
			List<string>  anothersheetList = new List<string>();     // 別紙リスト
			SortedList<int,ChgGidncDtWork> pgMulcsGdDWorkListByMulticastConNo = null;
			// 
			if( chgGidncDtWorkSortedList.ContainsKey( changGidncWork.MulticastConsNo ) ) {
				// 既存リスト取得
				pgMulcsGdDWorkListByMulticastConNo = chgGidncDtWorkSortedList[ changGidncWork.MulticastConsNo ];
			}
			if( pgMulcsGdDWorkListByMulticastConNo != null ) {
				foreach( ChgGidncDtWork wkChgGidncDtWork in pgMulcsGdDWorkListByMulticastConNo.Values ) {
					// 変更内容がある場合
					if( ! String.IsNullOrEmpty( wkChgGidncDtWork.ChangeContents ) ) {
						changeContentsBuilder.AppendLine( wkChgGidncDtWork.ChangeContents );
					}

					// 別紙ファイルがある場合
					if( ( wkChgGidncDtWork.AnothersheetFileExst == 1 ) && 
						( ! String.IsNullOrEmpty( wkChgGidncDtWork.AnothersheetFileName ) ) ) {
						// 別紙リストに追加
						anothersheetList.Add( ctAnotherSheetsDirUrl + wkChgGidncDtWork.AnothersheetFileName );
					}
				}
			}

			// ----------------------------------------
			// 変更内容
			this.ChangeContents_literal.Text    = HttpUtility.HtmlEncode( changeContentsBuilder.ToString() ).Replace( "\r\n", "<br />" );
			// ----------------------------------------

            // 2007.12.25 Maki Add ---------------------------------------------------------------------------------------------------->>>>>
            //// 帳票名称
            //this.PrintName_literal.Text         = HttpUtility.HtmlEncode( changGidncWork.Guidance1 );
            //// 地域(都道府県)
            //this.AreaName_literal.Text          = HttpUtility.HtmlEncode( changGidncWork.Area );

            // ----------------------------------------
			// サーバーメンテナンス案内文
            this.ServerMainteGidnc_literal.Text = HttpUtility.HtmlEncode( changeContentsBuilder.ToString() ).Replace( "\r\n", "<br />" );

            // ----------------------------------------
			// サーバーメンテナンス区分
            this.ServerMainteDivNm_literal.Text = ConstantManagement_NS_MGD.GetServerMainteDivNm( changGidncWork.McastGidncMainteCd );

			// ----------------------------------------
			// サーバーメンテナンス予定日時
            if ( ( changGidncWork.ServerMainteStScdl != 0 ) ||
                ( changGidncWork.ServerMainteEdScdl != 0 ) )
            {
				// サーバーメンテナンス予定日時を表示
				this.ServerMainteScdl_panel.Visible = true;

				this.ServerMainteScdl_literal.Text = String.Format( "{0} ～ {1}",
                    this.GetDateTimeString( changGidncWork.ServerMainteStScdl, true ),
                    this.GetDateTimeString( changGidncWork.ServerMainteEdScdl, true ) );
			}
			else {
				// サーバーメンテナンス予定日時を非表示
				this.ServerMainteScdl_panel.Visible = false;
			}

			// ----------------------------------------
			// サーバーメンテナンス実施日時
            if ( ( changGidncWork.ServerMainteStTime != 0 ) ||
                ( changGidncWork.ServerMainteEdTime != 0 ) )
            {
				// サーバーメンテナンス実施日時を表示
				this.ServerMainteTime_panel.Visible = true;


                this.ServerMainteTime_literal.Text = String.Format( "{0} ～ {1}", this.GetDateTimeString( changGidncWork.ServerMainteStTime, true ), this.GetDateTimeString( changGidncWork.ServerMainteEdTime, true ) );
			}
			else {
				// サーバーメンテナンス実施日時を表示
				this.ServerMainteTime_panel.Visible = false;
			}

			// ----------------------------------------
			// サーバーメンテナンス内容
            this.ServerMainteCntnts_literal.Text = HttpUtility.HtmlEncode( changGidncWork.Guidance1.TrimEnd() ).Replace( "\r\n", "<br />" );


            // ------------------------------------------------------------------------------------------------------------------------<<<<<

			// 別紙ファイル
            if ( anothersheetList.Count > 0 && multicastConsNo != 3 ) {
				// 別紙ファイルがある場合

				// 別紙ファイルを出力
				this.AnothersheetFile_panel.Visible       = true;
				this.AnothersheetFile_repeater.DataSource = new ArrayList( anothersheetList.ToArray() );
				this.AnothersheetFile_repeater.DataBind();
			}
			else {
				// 別紙ファイルがない場合
				
				// 別紙ファイルは表示しない
				this.AnothersheetFile_panel.Visible = false;
			}

			// ----------------------------------------
			// 当配信のその他の配信内容
			if( changGidncWorkSortedList.Count > 1 ) {
				// その他の配信内容が存在
				this.MulticastOthreInfo_panel.Visible = true;

				// プログラム配信案内テーブルを作成
				DataSet ds = new DataSet();
				SFCMN00771WB.CreateChangGidncTable( ds );

				foreach( ChangGidncWork wkChangGidncWork in changGidncWorkSortedList.Values ) {
					// 該当枝番は除外
					if( wkChangGidncWork.MulticastConsNo == multicastConsNo ) {
						continue;
					}

					// テーブルにデータを追加
					this.AddChangeGidncWorkToDataSet( ds, wkChangGidncWork );
				}
				// データソースをセット
				this.MulticastOthreInfo_repeater.DataSource = ds;
				this.MulticastOthreInfo_repeater.DataMember = SFCMN00771WB.ctTableName_ChangeGidnc;
				this.MulticastOthreInfo_repeater.DataBind();
			}
			else {
				// その他の配信内容が存在しない
				this.MulticastOthreInfo_panel.Visible = false;
			}

            // 2007.12.26 Maki Add ---------------------------------->>>>>
            // 画面表示を全てfalse
            this.ClearDisp();
            switch ( mcastGidncCntntsCd )
            {
                // プログラム配信
                case 1:
                    this.MulticastVersion_panel.Visible     = true;
                    this.MulticastDate_panel.Visible        = true;
                    this.MulticastSystemDivNm_panel.Visible = true;
                    this.MulticastProgramName_panel.Visible = true;
                    this.ChangeContents_panel.Visible       = true;
                    break;
                // サーバーメンテナンス
                case 2:
                    this.ServerMainteGidnc_panel.Visible    = true;
                    this.ServerMainteDivNm_panel.Visible    = true;
                    this.ServerMainteCntnts_panel.Visible   = true;
                    break;
                //// 印字位置リリース情報
                //case 3:
                //    this.MulticastDate_panel.Visible        = true;
                //    this.MulticastSystemDivNm_panel.Visible = true;
                //    this.PrintName_panel.Visible            = true;
                //    this.AreaName_panel.Visible             = true;
                //    this.ChangeContents_panel.Visible       = true;
                //    break;
                default:
                    break;
            }
            // ------------------------------------------------------<<<<<
		}

		#endregion

        #region ■画面非表示設定(初期化)

        /// <summary>
        /// 画面非表示設定(初期化)
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面情報を非表示にする</br>
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2007.12.26</br>
        /// </remarks>
        private void ClearDisp()
        {
            this.MulticastVersion_panel.Visible     = false;
            this.MulticastDate_panel.Visible        = false;
            this.MulticastSystemDivNm_panel.Visible = false;
            this.MulticastProgramName_panel.Visible = false;
            this.ChangeContents_panel.Visible       = false;
            //this.PrintName_panel.Visible            = false;
            //this.AreaName_panel.Visible             = false;
            this.ServerMainteGidnc_panel.Visible    = false;
            this.ServerMainteDivNm_panel.Visible    = false;
            this.ServerMainteCntnts_panel.Visible   = false;
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
        /// <br>Date       : 2007.12.26</br>
        /// </remarks>
        private DateTime LongDateToDateTime( long longDate )
        {
            DateTime dateTime = DateTime.MinValue;

            try
            {
                int yy = ( int )( longDate / 100000000 );
                int MM = ( int )( ( longDate % 100000000 ) / 1000000 );
                int dd = ( int )( ( longDate % 1000000 ) / 10000 );
                int HH = ( int )( ( longDate % 10000 ) / 100 );
                int mm = ( int )( longDate % 100 );

                // データ不正チェック
                dateTime = new DateTime( yy, MM, dd, HH, mm, 0 );
            }
            catch
            {
                dateTime = DateTime.MinValue;
            }

            return dateTime;
        }

        /// <summary>
        /// 日時文字列取得処理
        /// </summary>
        /// <param name="dateTime">DateTime</param>
        /// <param name="zeroSuppress">ゼロサプレス(true:ゼロサプレスする, false:ゼロサプレスしない)</param>
        /// <returns>日時文字列</returns>
        /// <remarks>
        /// <br>Note       : 日時文字列の取得を行います。</br>
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2007.12.26</br>
        /// </remarks>
        private string GetDateTimeString(DateTime dateTime, bool zeroSuppress)
        {
            StringBuilder dateTimeString = new StringBuilder();

            if (zeroSuppress)
            {
                dateTimeString.Append(TDateTime.DateTimeToString("YYYYmmdd", dateTime, ""));
                dateTimeString.Append(" ");
                dateTimeString.Append(TDateTime.DateTimeToString("hhmm", dateTime, ""));
            }
            else
            {
                dateTimeString.Append(TDateTime.DateTimeToString("YYYYMMDD", dateTime, ""));
                dateTimeString.Append(" ");
                dateTimeString.Append(TDateTime.DateTimeToString("HHMM", dateTime, ""));
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
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2007.12.26</br>
        /// </remarks>
        private string GetDateTimeString(long longDate, bool zeroSuppress)
        {
            return this.GetDateTimeString(this.LongDateToDateTime(longDate), zeroSuppress);
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
        private void AddChangeGidncWorkToDataSet(DataSet ds, ChangGidncWork changGidncWork)
		{
			// プログラム配信案内テーブルを取得
            DataTable dtChangeGidnc = null;
			if( ds.Tables.Contains( SFCMN00771WB.ctTableName_ChangeGidnc ) ) {
                dtChangeGidnc = ds.Tables[SFCMN00771WB.ctTableName_ChangeGidnc ];
			}

			// テーブルの取得に失敗した場合は処理を行わない
			if( dtChangeGidnc == null ) {
				return;
			}
			
			// プログラム配信案内テーブルに新規登録
            DataRow drChangeGidnc = dtChangeGidnc.NewRow();

            // 2007.12.26 Maki Add --------------------------------------------------------------------------------->>>>>
            // 配信案内　案内内容区分
            drChangeGidnc[ SFCMN00771WB.ctColumnName_McastGidncCntntsCd     ] = changGidncWork.McastGidncCntntsCd;
            // 地域
            drChangeGidnc[ SFCMN00771WB.ctColumnName_Area                   ] = changGidncWork.Area;
            // -----------------------------------------------------------------------------------------------------<<<<<
            // パッケージ区分
			drChangeGidnc[ SFCMN00771WB.ctColumnName_ProductCode            ] = changGidncWork.ProductCode;
			// 配信提供区分
			drChangeGidnc[ SFCMN00771WB.ctColumnName_McastOfferDivCd        ] = changGidncWork.McastOfferDivCd;
			// 更新グループコード
			drChangeGidnc[ SFCMN00771WB.ctColumnName_UpdateGroupCode        ] = changGidncWork.UpdateGroupCode;
			// 企業コード
			drChangeGidnc[ SFCMN00771WB.ctColumnName_EnterpriseCode         ] = changGidncWork.EnterpriseCode;
			// 配信バージョン
			drChangeGidnc[ SFCMN00771WB.ctColumnName_McastGidncVersionCd    ] = changGidncWork.McastGidncVersionCdZeroSup;
			// 配信連番
			drChangeGidnc[ SFCMN00771WB.ctColumnName_MulticastConsNo        ] = changGidncWork.MulticastConsNo;
			// プログラム変更区分
			drChangeGidnc[ SFCMN00771WB.ctColumnName_McastGidncMainteCd     ] = changGidncWork.McastGidncNewCustmCd;
			// プログラム変更区分名称
			//drChangeGidnc[ SFCMN00771WB.ctColumnName_ProgramChgDivNm      ] = ConstantManagement_NS_MGD.GetProgramChgDivNm( changGidncWork.ProgramChgDivCd );
            drChangeGidnc[ SFCMN00771WB.ctColumnName_McastGidncMainteNm     ] = ConstantManagement_NS_MGD.GetMcastGidncNewCustmCdNm(changGidncWork.McastGidncNewCustmCd);
            // 配信システム区分
			drChangeGidnc[ SFCMN00771WB.ctColumnName_SystemDivCd            ] = changGidncWork.SystemDivCd;
			// 配信システム区分名称
			drChangeGidnc[ SFCMN00771WB.ctColumnName_SystemDivNm            ] = ConstantManagement_NS_MGD.GetMulticastSystemDivNm( changGidncWork.ProductCode, changGidncWork.SystemDivCd);
			// 配信プログラム名称
			drChangeGidnc[ SFCMN00771WB.ctColumnName_Guidance1              ] = changGidncWork.Guidance1;
			// 詳細ページURL
            //drChangeGidnc[ SFCMN00771WB.ctColumnName_DetailPageUrl        ] = this.CreateMulticastDetailUrl( changGidncWork.McastGidncVersionCd, changGidncWork.MulticastConsNo );
            drChangeGidnc[ SFCMN00771WB.ctColumnName_DetailPageUrl          ] = this.CreateMulticastDetailUrl( changGidncWork.McastGidncVersionCd, changGidncWork.MulticastConsNo,
                                                                                    changGidncWork.McastGidncCntntsCd, changGidncWork.McastGidncMainteCd, changGidncWork.SystemDivCd );

			dtChangeGidnc.Rows.Add( drChangeGidnc );
		}

		#endregion

		#region ■.NS 配信詳細情報URL作成処理

		/// <summary>
		/// .NS 配信詳細情報URL作成処理
		/// </summary>
		/// <param name="multicastVersion">配信バージョン</param>
		/// <param name="multicastConsNo">配信連番</param>
		/// <returns>.NS 配信詳細情報URL</returns>
		/// <remarks>
		/// <br>Note       : .NS 配信詳細情報のURLを作成します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.02.19</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.12.26 牧　将人
        ///                 ・引数を追加</br>
        /// <param name="mcastGidncCntntsCd">案内内容区分</param>
        /// <br></br>
		/// </remarks>
        private string CreateMulticastDetailUrl(string multicastVersion, int multicastConsNo, int mcastGidncCntntsCd, int mcastGidncMainteCd, int systemDivCd)
		{
			QueryStringController query = new QueryStringController();
			query.AccessTicket          = Globals.QueryStringController.AccessTicket;

            // 2007.12.26 Maki Add -------------------------->>>>>
            query.McastGidncCntntsCd    = mcastGidncCntntsCd;
            // ----------------------------------------------<<<<<
			query.MulticastVersion      = multicastVersion;
			query.MulticastConsNo       = multicastConsNo;
			// 2008.03.12 -------------------エラー対応-----
            query.SystemDivCd = systemDivCd;
			// ------------------------------エラー対応-----
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

		#region ■Load イベント (SFCMN00772W)

		/// <summary>
		/// Load イベント (SFCMN00772W)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ページがロードされるときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.02.19</br>
		/// </remarks>
		protected void Page_Load(object sender, EventArgs e)
		{
			// ログ書き込み部品を初期化
			this._changePgGuideLogOutPut = new ChangePgGuideLogOutPut();

			if( this.IsPostBack ) {
			}
			else {
				this.SetMulticastDetailInfo();
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
		/// <br>Date       : 2007.02.19</br>
		/// </remarks>
		protected void MenuTopPage_imageButton_Click( object sender, ImageClickEventArgs e )
		{
			// クエリ作成
			QueryStringController query = new QueryStringController();
			query.AccessTicket  = Globals.QueryStringController.AccessTicket;
			
			// トップページへリダイレクト
			Response.Redirect( ctTopPageUrl + query.ToString() );
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
			query.AccessTicket  = Globals.QueryStringController.AccessTicket;

			// お知らせ検索へリダイレクト
			Response.Redirect( ctMulticastSearchUrl + query.ToString() );
		}

		#endregion

		#endregion
	}
}

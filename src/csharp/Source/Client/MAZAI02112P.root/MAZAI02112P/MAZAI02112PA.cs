//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 棚卸関連一覧表(棚卸調査表、棚卸差異表、棚卸表)
// プログラム概要   : 棚卸関連一覧表(棚卸調査表、棚卸差異表、棚卸表)を印刷します。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 中村　仁
// 作 成 日  2007/04/09  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢 貞義
// 修 正 日  2007/09/14  修正内容 : DC.NS対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢 貞義
// 修 正 日  2008/02/13  修正内容 : 不具合対応（DC.NS対応）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 犬飼
// 修 正 日  2008/10/08  修正内容 : PM.NS対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/05/13  修正内容 : 不具合対応[13259]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 長内 数馬
// 修 正 日  2009/09/18  修正内容 : 帳票未入力分の抽出条件は印字対象外とする
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : liyp
// 修 正 日  2011/01/11  修正内容 : 抽出条件追加に伴い帳票のヘッダへ抽出条件を追加で印字するように変更する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 修 正 日  2011/01/11  修正内容 : 棚卸障害対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : liyp
// 修 正 日  2011/02/10  修正内容 : 障害報告 #18873 と 障害報告 #18874
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 修 正 日  2012/12/27  修正内容 : 2013/01/16配信分　Redmine#33233
//                                  ドットプリンタに印字した場合ストックフォーム(15×11)の横3分の2ぐらいを使って印刷するように対応
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 棚卸関連一覧表印刷クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 棚卸関連一覧表を印刷します。</br>
	/// <br>Programmer : 23010 中村　仁</br>
	/// <br>Date       : 2007.04.09</br>
    /// <br>Update Note: 2007.09.14 980035 金沢 貞義</br>
    /// <br>			 ・DC.NS対応</br>
    /// <br>Update Note: 2008.02.13 980035 金沢 貞義</br>
    /// <br>			 ・不具合対応（DC.NS対応）</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : PM.NS対応</br>
    /// <br>Programmer : 30413 犬飼</br>
    /// <br>Date	   : 2008.10.08</br>
    /// <br>           : 2009/05/13 照田 貴志　不具合対応[13259]</br>
    /// <br>Update Note: 2011/01/11 田建委</br>
    /// <br>			 棚卸障害対応</br>
    /// <br>Update Note: 2012/12/27 田建委</br>
    /// <br>管理番号   : 2013/01/16配信分</br>
    /// <br>             Redmine#33233 ドットプリンタに印字した場合ストックフォーム(15×11)の横3分の2ぐらいを使って印刷するように対応</br>
    /// </remarks>
	class MAZAI02112PA
	{
		// --------------------------------------------------
		#region Constructor

		/// <summary>
		/// 棚卸関連一覧表印刷クラスコンストラクタ
		/// </summary>
		/// <param name="printInfo">印刷情報オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 棚卸関連一覧表印刷クラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.04.09</br>
        /// <br>Update Note: 2012/12/27 田建委</br>
        /// <br>管理番号   : 2013/01/16配信分</br>
        /// <br>             Redmine#33233 ドットプリンタに印字した場合ストックフォーム(15×11)の横3分の2ぐらいを使って印刷するように対応</br>
		/// </remarks>
		public MAZAI02112PA( object printInfo )
		{
			// 印刷情報オブジェクト取得
			this._printInfo             = printInfo as SFCMN06002C;
			// アクセスクラスインスタンス生成
			this._inventoryListCmnAcs = new InventoryListCmnAcs();
            //----- ADD 2012/12/27 田建委 Redmine#33233 ------->>>>>
            // 伝票印刷アクセスクラス
            this._slipPrintAcs = new SlipPrintAcs(LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);
            //----- ADD 2012/12/27 田建委 Redmine#33233 -------<<<<<
		}

		#endregion

		// --------------------------------------------------
		#region ReportPrintException

		/// <summary>
		/// 帳票印刷例外クラス
		/// </summary>
		/// <remarks>
		/// <br>Note       : 帳票印刷の例外クラスです。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2007.04.09</br>
		/// </remarks>
		private class ReportPrintException : ApplicationException
		{
			#region Private Members

			/// <summary>ステータス</summary>
			private int		_status		= -1;
			/// <summary>発生メソッドID</summary>
			private string	_procNm		= "";

			#endregion

			#region Constructor

			/// <summary>
			/// 帳票印刷例外クラスコンストラクタ
			/// </summary>
			/// <param name="message">メッセージ</param>
			/// <param name="status">ステータス</param>
			/// <remarks>
			/// <br>Note       : 帳票印刷例外クラスの新しいインスタンスを初期化します。</br>
			/// <br>Programmer : 23010 中村　仁</br>
			/// <br>Date       : 2007.04.09</br>
			/// </remarks>
			public ReportPrintException( string message, int status ) : base( message )
			{
				this._status = status;
			}

			/// <summary>
			/// 帳票印刷例外クラスコンストラクタ
			/// </summary>
			/// <param name="message">メッセージ</param>
			/// <param name="status">ステータス</param>
			/// <param name="procNm">発生メソッドID</param>
			/// <remarks>
			/// <br>Note       : 帳票印刷例外クラスの新しいインスタンスを初期化します。</br>
			/// <br>Programmer : 23010 中村　仁</br>
			/// <br>Date       : 2007.04.09</br>
			/// </remarks>
			public ReportPrintException( string message, int status, string procNm ) : base( message )
			{
				this._status = status;
				this._procNm = procNm;
			}

			#endregion

			#region Properties

			/// <summary>
			/// ステータスプロパティ
			/// </summary>
			public int Status {
				get {
					return this._status;
				}
			}

			/// <summary>
			/// 発生メソッドIDプロパティ
			/// </summary>
			public string ProcNm {
				get {
					return this._procNm;
				}
			}

			#endregion
		}

		#endregion

		// --------------------------------------------------
		#region Private Members

		// 印刷情報オブジェクト
		private SFCMN06002C _printInfo  = null;

		// 抽出条件クラス
		private InventSearchCndtnUI _extrInfo   = null;

		// 棚卸関連一覧表共通アクセスクラス
		private InventoryListCmnAcs _inventoryListCmnAcs    = null;

        //----- ADD 2012/12/27 田建委 Redmine#33233 ------->>>>>
        // 伝票印刷アクセスクラス
        private SlipPrintAcs _slipPrintAcs;
        //----- ADD 2012/12/27 田建委 Redmine#33233 -------<<<<<

		#endregion

		// --------------------------------------------------
		#region Constant

		// クラスID
		private const string	CT_CLASSID              = "MAZAI02112PA";
		// プログラムID
		private const string	CT_PGID                 = "MAZAI02112P";
		// プログラム名称
		private const string	CT_PGNM                 = "棚卸関連一覧表";

		// 抽出条件文字間隔用定数
		//private const string	CT_SPACE                = "    "; //DEL 2011/02/10
        private const string    CT_SPACE = "  "; // ADD 2011/02/10
		// ReportFormNamspace
		private const string	CT_REPORTFORM_NAMESPACE = "Broadleaf.Drawing.Printing";
        //a

        #endregion

        // 2008.02.13 追加 >>>>>>>>>>>>>>>>>>>>
        /// <summary>表示順位</summary>
        private string CT_SectionCode_Odr       = "SectionCode";            // 拠点コード
        private string CT_WarehouseCode_Odr     = "WarehouseCode";          // 倉庫コード
        private string CT_WarehouseShelfNo_Odr  = "WarehouseShelfNo";       // 倉庫棚番
        private string CT_CustomerCode_Odr      = "CustomerCode";           // 得意先コード(仕入先)
        private string CT_BLGoodsCode_Odr       = "BLGoodsCode";            // ＢＬコード
        private string CT_MakerCode_Odr         = "MakerCode";              // メーカーコード
        private string CT_GoodsCode_Odr         = "GoodsCode";              // 商品コード
        private string CT_GoodsDivL_Odr         = "LargeGoodsGanreCode";    // 商品区分グループ
        private string CT_GoodsDivM_Odr         = "MediumGoodsGanreCode";   // 商品区分
        private string CT_GoodsDivD_Odr         = "DetailGoodsGanreCode";   // 商品区分詳細
        // 2008.02.13 追加 <<<<<<<<<<<<<<<<<<<<

        // --------------------------------------------------
		#region Properties

		/// <summary>印刷情報パラメータプロパティ</summary>
		/// <value>印刷情報パラメータを取得または設定します。</value>
		public SFCMN06002C Printinfo
		{
			get {
				return this._printInfo;
			}
			set {
				this._printInfo = value;
			}
		}

		#endregion

		// --------------------------------------------------
		#region Public Methods

		/// <summary>
		/// 印刷処理開始
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 印刷処理を開始します。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2007.04.09</br>
		/// </remarks>
		public int StartPrint()
		{
			return this.PrintMain();
		}

		#endregion

		// --------------------------------------------------
		#region Private Methods

		/// <summary>
		/// 印刷メイン処理
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 印刷のメイン処理を行います。</br>
		/// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.04.09</br>
        /// <br>Update Note: 2012/12/27 田建委</br>
        /// <br>管理番号   : 2013/01/16配信分</br>
        /// <br>             Redmine#33233 ドットプリンタに印字した場合ストックフォーム(15×11)の横3分の2ぐらいを使って印刷するように対応</br>
		/// </remarks>
		private int PrintMain()
		{
			const string ctPROCNM = "PrintMain";
			int status = ( int )ConstantManagement.MethodResult.ctFNC_ERROR;

			this._extrInfo = this._printInfo.jyoken as InventSearchCndtnUI;

			// 印刷用フォームクラス
			DataDynamics.ActiveReports.ActiveReport3 prtRpt = null;

			try 
            {
				// 印刷用データビューインスタンス生成
                DataView dv = this._printInfo.rdData as DataView;

                // 2008.10.31 30413 犬飼 Eクラスでソート済なので実施しない >>>>>>START
                // 2008.02.13 修正 >>>>>>>>>>>>>>>>>>>>
                // ソート順設定
                //dv.Sort = this.GetPrintOderQuerry();
                // 2008.02.13 修正 <<<<<<<<<<<<<<<<<<<<
                // 2008.10.31 30413 犬飼 Eクラスでソート済なので実施しない <<<<<<END

                //----- ADD 2012/12/27 田建委 Redmine#33233 ------->>>>>
                //棚卸調査表のみ
                if (this._printInfo.PrintPaperSetCd == 0)
                {
                    List<PrtManage> prtManageList = _slipPrintAcs.SearchAllPrtManage(LoginInfoAcquisition.EnterpriseCode);
                    if (prtManageList != null && prtManageList.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(this._printInfo.prinm))
                        {
                            foreach (PrtManage itm in prtManageList)
                            {
                                if (itm.LogicalDeleteCode == 0 && itm.PrinterName == this._printInfo.prinm)
                                {
                                    if (itm.PrinterKind == 0)
                                    {
                                        // レーザープリンタに印字した場合
                                        // レポートインスタンス生成
                                        this.CreateReport(out prtRpt, this._printInfo.prpid);
                                    }
                                    else if (itm.PrinterKind == 1)
                                    {
                                        // ドットプリンタに印字した場合
                                        // レポートインスタンス生成
                                        this.CreateReport(out prtRpt, "MAZAI02112P_07A4C");
                                    }
                                    else
                                    {
                                        // なし
                                    }
                                }
                            }
                        }
                        else
                        {
                            // レポートインスタンス生成
                            this.CreateReport(out prtRpt, this._printInfo.prpid);
                        }
                    }
                    else
                    {
                        // レポートインスタンス生成
                        this.CreateReport(out prtRpt, this._printInfo.prpid);
                    }
                }
                else
                {
                    // レポートインスタンス生成
                    this.CreateReport(out prtRpt, this._printInfo.prpid);
                }
                //----- ADD 2012/12/27 田建委 Redmine#33233 -------<<<<<

				// レポートインスタンス生成
                //this.CreateReport( out prtRpt, this._printInfo.prpid ); // DEL 2012/12/27 田建委 Redmine#33233
				if( prtRpt == null ) {
					return status;
				}

				// 各種プロパティ設定
				status = this.SetFormProperties( ref prtRpt );
				if( status != 0 ) {
					return status;
				}

				// バインドするデータソースのセット
				prtRpt.DataSource	= dv;
				prtRpt.DataMember	= "";

				// 印刷共通情報プロパティ設定
				Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
				status = this.SetPrintCommonInfo( out commonInfo );
				if( status != 0 ) {
					return status;
				}

				// プレビュー有無区分
				int mode = this._printInfo.prevkbn;

				// 出力モードがPDFの場合、無条件でプレビュー無し
				if( this._printInfo.printmode == 2 ) {
					// PDF出力時
					mode = 0;
				}

				switch( mode ) {
					case 0:			// プレビュー無し
					{
						Broadleaf.Windows.Forms.SFCMN00293UB processForm = new Broadleaf.Windows.Forms.SFCMN00293UB();

						// 共通条件設定
						processForm.CommonInfo = commonInfo;

						// プログレスバーアップイベント追加
						if( prtRpt is IPrintActiveReportTypeCommon ) {
							( ( IPrintActiveReportTypeCommon )prtRpt ).ProgressBarUpEvent += 
								new ProgressBarUpEventHandler( processForm.ProgressBarUpEvent );
						}

						// 印刷実行
						status = processForm.Run( prtRpt, true );

						// 戻り値設定
						this._printInfo.status = status;
						break;
					}
					case 1:			// プレビュー有り
					{
						Broadleaf.Windows.Forms.SFCMN00293UA viewForm = new Broadleaf.Windows.Forms.SFCMN00293UA();

						// 共通条件設定
						viewForm.CommonInfo = commonInfo;

						// プレビュー実行
						status = viewForm.Run( prtRpt );

						// 戻り値設定
						this._printInfo.status = status;
						break;
					}
				}

				if( status == ( int )ConstantManagement.MethodResult.ctFNC_NORMAL ) {
					switch( this._printInfo.printmode ) {
						case 1:  // プリンタ
						{
							break;
						}
						case 2:  // ＰＤＦ
						case 3:  // 両方(プリンタ + ＰＤＦ)
						{
							// ＰＤＦ表示フラグON
							this._printInfo.pdfopen = true;

							// 両方印刷時のみ履歴保存
							if( this._printInfo.printmode == 3 ) {
								// 出力履歴管理に追加
								SFANL06101UA selectOldPdf = new SFANL06101UA();
								selectOldPdf.AddPrintInfo( this._printInfo.key, this._printInfo.prpnm, this._printInfo.prpnm, this._printInfo.pdftemppath );
							}
							break;
						}
					}
				}
			}
			catch( ReportPrintException rpEx ) {
				this.MsgDispProc( emErrorLevel.ERR_LEVEL_STOPDISP, rpEx.Message, rpEx.Status, rpEx.ProcNm );
			}
			catch( Exception ex ) {
				this.MsgDispProc( emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, -1, ctPROCNM );
				status = -1;
			}
			finally {
				// レポートオブジェクトを破棄
				if( prtRpt != null ) {
					prtRpt.Dispose();
				}
			}

			return status;
		}

		/// <summary>
		/// 各種ActiveReport帳票インスタンス生成
		/// </summary>
		/// <param name="prtObj">インスタンス化された帳票フォームクラス</param>
		/// <param name="prpid">帳票フォームID</param>
		/// <remarks>
		/// <br>Note       : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2007.04.09</br>
		/// </remarks>
		private void CreateReport( out DataDynamics.ActiveReports.ActiveReport3 prtObj, string prpid )
		{
			prtObj = ( DataDynamics.ActiveReports.ActiveReport3 )this.LoadAssemblyReport( 
				prpid.Trim(), CT_REPORTFORM_NAMESPACE + "." + prpid.Trim(), 
				typeof( DataDynamics.ActiveReports.ActiveReport3 ) );
		}

		/// <summary>
		/// 指定されたアセンブリ及びクラス名によるクラスインスタンス化処理
		/// </summary>
		/// <param name="asmname">アセンブリ名称</param>
		/// <param name="classname">クラス名称</param>
		/// <param name="type">実装するクラス型</param>
		/// <returns>インスタンス化されたクラス</returns>
		/// <remarks>
		/// <br>Note       : 指定されたアセンブリ及びクラス名称より、クラスをインスタンス化します。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2007.04.09</br>
		/// </remarks>
		private object LoadAssemblyReport( string asmname, string classname, Type type )
		{
			const string ctPROCNM = "LoadAccemblyReport";
			object obj = null;

			try {
				System.Reflection.Assembly asm = System.Reflection.Assembly.Load( asmname );
				Type objType = asm.GetType( classname );
				if( objType != null ) {
					if( ( objType == type ) || ( objType.IsSubclassOf( type ) == true ) || ( objType.GetInterface( type.Name ).Name == type.Name ) ) {
						obj = Activator.CreateInstance( objType );
					}
				}
			}
			catch( System.IO.FileNotFoundException ) {
				throw new ReportPrintException( asmname + "が存在しません。", -1, ctPROCNM );
			}
			catch( Exception ex ) {
				throw new ReportPrintException( ex.Message, -1, ctPROCNM );
			}

			return obj;
		}

		/// <summary>
		/// プロパティ設定関数
		/// </summary>
		/// <param name="prtRpt">印刷用アクティブレポートクラス変数</param>
		/// <remarks>
		/// <br>Note       : プロパティ設定関数。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2007.04.09</br>
		/// </remarks>
		private int SetFormProperties( ref DataDynamics.ActiveReports.ActiveReport3 prtRpt )
		{
			int status = ( int )ConstantManagement.MethodResult.ctFNC_ERROR;
			const string ctPROCNM = "SetFormProperties";
			try 
            {
				// ActiveReportインターフェースにキャスト
				IPrintActiveReportTypeList instance     = prtRpt as IPrintActiveReportTypeList;

				// ソート順プロパティ設定
				instance.PageHeaderSortOderTitle        = this.MakeSortCondition();
				
				// 抽出条件編集処理
				StringCollection extraInfomations;
				this.MakeExtractConditionMain( out extraInfomations );
				instance.ExtraConditions                = extraInfomations; 
				
				// 帳票出力設定情報取得
				PrtOutSet prtOutSet = null;
				string message;

                //TODO:アクセスクラス置換え
				status = this._inventoryListCmnAcs.ReadPrtOutSet( out prtOutSet, out message );
				if( status != 0 ) {
					throw new ReportPrintException( message, status, ctPROCNM );
				}

				// 抽出条件ヘッダ出力区分
				instance.ExtraCondHeadOutDiv            = prtOutSet.ExtraCondHeadOutDiv;
				// フッタ出力区分
				instance.PageFooterOutCode              = prtOutSet.FooterPrintOutCode;

				// フッタ出力メッセージ
				StringCollection footers = new StringCollection();
				footers.Add( prtOutSet.PrintFooter1 );
				footers.Add( prtOutSet.PrintFooter2 );
				instance.PageFooters                    = footers;

				// 印刷情報オブジェクト
				instance.PrintInfo                      = this._printInfo;
		
				// その他データ
				ArrayList otherDataList = new ArrayList();
				instance.OtherDataList                  = otherDataList;

				status = ( int )ConstantManagement.MethodResult.ctFNC_NORMAL;
			}
			catch( ReportPrintException rpEx ) {
				this.MsgDispProc( emErrorLevel.ERR_LEVEL_STOPDISP, rpEx.Message, rpEx.Status, rpEx.ProcNm );
				status = rpEx.Status;
			}
			catch ( Exception ex ) {
				status = -1;
				this.MsgDispProc( emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, status, ctPROCNM );
			}

			return status;
		}

		/// <summary>
		/// 印刷画面共通情報設定
		/// </summary>
		/// <param name="commonInfo"></param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 印刷画面共通条件の設定を行います。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2007.04.09</br>
		/// </remarks>
		private int SetPrintCommonInfo( out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo )
		{
			int status = ( int )ConstantManagement.DB_Status.ctDB_NORMAL;

			commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();
		
			// プリンタ名
			commonInfo.PrinterName = this._printInfo.prinm;
			// 帳票名
			commonInfo.PrintName   = this._printInfo.prpnm;				
				
			// 印刷件数
            commonInfo.PrintMax    = ( ( DataView )this.Printinfo.rdData ).Count;
			// 印刷モード
			commonInfo.PrintMode   = this.Printinfo.printmode;
			
			// PDF出力フルパス
			// 帳票チャート共通部品クラス
			SFCMN00331C cmnCommon = new SFCMN00331C(); 
			// PDFパス取得
			string pdfPath = "";
			string pdfName = "";
			status = cmnCommon.GetPdfSavePathName( this._printInfo.prpnm, ref pdfPath, ref pdfName );
			if( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL ) {
				status = -1;
				return status;
			}
			this._printInfo.pdftemppath = System.IO.Path.Combine( pdfPath, pdfName );
			commonInfo.PdfFullPath = this._printInfo.pdftemppath;

			// 印字位置
			commonInfo.MarginsLeft  = this._printInfo.px;
			commonInfo.MarginsTop   = this._printInfo.py;

			return status;
		}

		/// <summary>
		///	抽出条件作成関数
		/// </summary>
		/// <remarks>
		/// <br>Note       : 対象期間、抽出条件１，２をstring型の配列に格納する。</br>
		/// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.04.09</br>
        /// <br>Update Note: 2011/01/11 田建委</br>
        /// <br>			 棚卸障害対応</br> 
        /// <br>Update Note: 2011/01/11 liyp </br>
        /// <br>           抽出条件追加に伴い帳票のヘッダへ抽出条件を追加で印字するように変更する</br>
        /// <br>Update Note: 2011/02/10 liyp </br>
        /// <br>           障害報告 #18873</br>
		/// </remarks>
		private void MakeExtractConditionMain( out StringCollection allExtractCondition )
        {
            #region 抽出条件１作成処理
          
            allExtractCondition = new StringCollection();

            //帳票種類によって処理を分ける
            // 2007.09.14 修正 >>>>>>>>>>>>>>>>>>>>
            //switch (this._extrInfo.SelctedPaperKindDiv)
            switch (this._extrInfo.SelectedPaperKind)
            // 2007.09.14 修正 <<<<<<<<<<<<<<<<<<<<
            {
                case 0:
                {
                    //棚卸記入表
                    //棚卸準備処理日
                    // 2008.02.13 修正 >>>>>>>>>>>>>>>>>>>>
                    ////開始の日付が入っていない場合
                    //if(this._extrInfo.St_InventoryPreprDayDateTime == DateTime.MinValue)
                    //{
                    //    //終了の日付も入っていない
                    //    if(this._extrInfo.Ed_InventoryPreprDayDateTime == DateTime.MinValue)
                    //    {
                    //        //条件を指定していないと見なし何もしない
                    //    }
                    //    //終了の日付は入っている
                    //    else
                    //    {
                    //        this.EditCondition( ref allExtractCondition,
                    //        String.Format("棚卸準備処理日" + "： {0} ～ {1}", "ＴＯＰ", TDateTime.DateTimeToString("YYYY/MM/DD",this._extrInfo.Ed_InventoryPreprDayDateTime)));
                    //    }                 
                    //}
                    //else
                    //{
                    //    //終了日の日付が入っていない
                    //    if(this._extrInfo.Ed_InventoryPreprDayDateTime == DateTime.MinValue)
                    //    {
                    //        this.EditCondition( ref allExtractCondition,
                    //        String.Format("棚卸準備処理日" + "： {0} ～ {1}", TDateTime.DateTimeToString("YYYY/MM/DD",this._extrInfo.St_InventoryPreprDayDateTime),"ＥＮＤ"));
                    //    }
                    //    //どちらも入っている
                    //    else
                    //    {
                    //        this.EditCondition( ref allExtractCondition,
                    //        String.Format("棚卸準備処理日" + "： {0} ～ {1}", TDateTime.DateTimeToString("YYYY/MM/DD",this._extrInfo.St_InventoryPreprDayDateTime),TDateTime.DateTimeToString("YYYY/MM/DD",this._extrInfo.Ed_InventoryPreprDayDateTime)));
                    //    }                        
                    //}
                    // 2008.10.31 30413 犬飼 棚卸日に修正 >>>>>>START
                    //this.EditCondition(ref allExtractCondition,
                    //String.Format("棚卸準備処理日" + "： {0}", TDateTime.DateTimeToString("YYYY/MM/DD", this._extrInfo.St_InventoryPreprDayDateTime)));
                    this.EditCondition(ref allExtractCondition,
                    String.Format("棚卸日" + "： {0}", TDateTime.DateTimeToString("YYYY/MM/DD", this._extrInfo.St_InventoryPreprDayDateTime)));
                    // 2008.10.31 30413 犬飼 棚卸日に修正 <<<<<<END
                    // 2008.02.13 修正 <<<<<<<<<<<<<<<<<<<<
                    break;
                }
                case 1:
                {
                    //棚卸差異表
                    //棚卸日
                    // 2008.02.13 修正 >>>>>>>>>>>>>>>>>>>>
                    ////開始の日付が入っていない場合
                    //if(this._extrInfo.St_InventoryDayDateTime == DateTime.MinValue)
                    //{
                    //    //終了の日付も入っていない
                    //    if(this._extrInfo.Ed_InventoryDayDateTime == DateTime.MinValue)
                    //    {
                    //        //条件を指定していないと見なし何もしない
                    //    }
                    //    //終了の日付は入っている
                    //    else
                    //    {
                    //        this.EditCondition( ref allExtractCondition,
                    //        String.Format("棚卸日" + "： {0} ～ {1}", "ＴＯＰ", TDateTime.DateTimeToString("YYYY/MM/DD",this._extrInfo.Ed_InventoryDayDateTime)));
                    //    }                 
                    //}
                    //else
                    //{
                    //    //終了日の日付が入っていない
                    //    if(this._extrInfo.Ed_InventoryDayDateTime == DateTime.MinValue)
                    //    {
                    //        this.EditCondition( ref allExtractCondition,
                    //        String.Format("棚卸日" + "： {0} ～ {1}", TDateTime.DateTimeToString("YYYY/MM/DD",this._extrInfo.St_InventoryDayDateTime),"ＥＮＤ"));
                    //    }
                    //    //どちらも入っている
                    //    else
                    //    {
                    //        this.EditCondition( ref allExtractCondition,
                    //        String.Format("棚卸日" + "： {0} ～ {1}", TDateTime.DateTimeToString("YYYY/MM/DD",this._extrInfo.St_InventoryDayDateTime),TDateTime.DateTimeToString("YYYY/MM/DD",this._extrInfo.Ed_InventoryDayDateTime)));
                    //    }                        
                    //}
                    this.EditCondition(ref allExtractCondition,
                    String.Format("棚卸日" + "： {0}", TDateTime.DateTimeToString("YYYY/MM/DD", this._extrInfo.St_InventoryDayDateTime)));
                    // 2008.02.13 修正 <<<<<<<<<<<<<<<<<<<<
                    break;
                }
                case 2:
                {
                    //棚卸表
                    //棚卸日
                    // 2008.02.13 修正 >>>>>>>>>>>>>>>>>>>>
                    ////開始の日付が入っていない場合
                    //if (this._extrInfo.St_InventoryDayDateTime == DateTime.MinValue)
                    //{
                    //    //終了の日付も入っていない
                    //    if(this._extrInfo.Ed_InventoryDayDateTime == DateTime.MinValue)
                    //    {
                    //        //条件を指定していないと見なし何もしない
                    //    }
                    //    //終了の日付は入っている
                    //    else
                    //    {
                    //        this.EditCondition( ref allExtractCondition,
                    //        String.Format("棚卸日" + "： {0} ～ {1}", "ＴＯＰ", TDateTime.DateTimeToString("YYYY/MM/DD",this._extrInfo.Ed_InventoryDayDateTime)));
                    //    }                 
                    //}
                    //else
                    //{
                    //    //終了日の日付が入っていない
                    //    if(this._extrInfo.Ed_InventoryDayDateTime == DateTime.MinValue)
                    //    {
                    //        this.EditCondition( ref allExtractCondition,
                    //        String.Format("棚卸日" + "： {0} ～ {1}", TDateTime.DateTimeToString("YYYY/MM/DD",this._extrInfo.St_InventoryDayDateTime),"ＥＮＤ"));
                    //    }
                    //    //どちらも入っている
                    //    else
                    //    {
                    //        this.EditCondition( ref allExtractCondition,
                    //        String.Format("棚卸日" + "： {0} ～ {1}", TDateTime.DateTimeToString("YYYY/MM/DD",this._extrInfo.St_InventoryDayDateTime),TDateTime.DateTimeToString("YYYY/MM/DD",this._extrInfo.Ed_InventoryDayDateTime)));
                    //    }                        
                    //}
                    this.EditCondition(ref allExtractCondition,
                    String.Format("棚卸日" + "： {0}", TDateTime.DateTimeToString("YYYY/MM/DD", this._extrInfo.St_InventoryDayDateTime)));
                    // 2008.02.13 修正 <<<<<<<<<<<<<<<<<<<<
                    break;
                }
            }

            string wkStr = "";

            // 2008.10.31 30413 犬飼 非印字項目を削除 >>>>>>START
            ////印字対象(差異表の場合のみ)
            //// 2007.09.14 修正 >>>>>>>>>>>>>>>>>>>>
            ////if(this._extrInfo.SelctedPaperKindDiv == 1)
            //if (this._extrInfo.SelectedPaperKind == 1)
            //// 2007.09.14 修正 <<<<<<<<<<<<<<<<<<<<
            //{
            //    if(this._extrInfo.DifCntExtraDiv == 0)
            //    {
            //        //全て
            //        wkStr = "印字対象: 全て";
            //        this.EditCondition( ref allExtractCondition, wkStr );
            //    }
            //    // 2007.09.14 追加 >>>>>>>>>>>>>>>>>>>>
            //    else if (this._extrInfo.DifCntExtraDiv == 1)
            //    {
            //        //数未入力分のみ
            //        wkStr = "印字対象: 数未入力分のみ";
            //        this.EditCondition(ref allExtractCondition, wkStr);
            //    }
            //    else if (this._extrInfo.DifCntExtraDiv == 2)
            //    {
            //        //数入力分のみ
            //        wkStr = "印字対象: 数入力分のみ";
            //        this.EditCondition(ref allExtractCondition, wkStr);
            //    }
            //    // 2007.09.14 追加 <<<<<<<<<<<<<<<<<<<<
            //    else
            //    {
            //        //差異分のみ印字
            //        // 2007.09.14 修正 >>>>>>>>>>>>>>>>>>>>
            //        //wkStr = "印字対象: 差異分のみ印字";
            //        wkStr = "印字対象: 差異分のみ";
            //        // 2007.09.14 修正 <<<<<<<<<<<<<<<<<<<<
            //        this.EditCondition(ref allExtractCondition, wkStr);
            //    }
            //}

            //// 2007.09.14 修正 >>>>>>>>>>>>>>>>>>>>
            //////集計単位          
            ////if (this._extrInfo.GrossPrintDiv == 0) 
            ////{
            ////    //集計(グロス)しない
            ////	wkStr = "集計単位: 製造番号";
            ////	this.EditCondition( ref allExtractCondition, wkStr );
            ////}
            ////else
            ////{
            ////    //集計(グロス)する
            ////    wkStr = "集計単位: 商品";
            ////	this.EditCondition( ref allExtractCondition, wkStr );
            ////}
            //// 2007.09.14 修正 <<<<<<<<<<<<<<<<<<<<

            ////０出力
            ////棚卸表
            //// 2007.09.14 修正 >>>>>>>>>>>>>>>>>>>>
            ////if (this._extrInfo.SelctedPaperKindDiv == 2)
            //if (this._extrInfo.SelectedPaperKind == 2)
            //// 2007.09.14 修正 <<<<<<<<<<<<<<<<<<<<
            //{
            //    //棚卸数０出力
            //    if(this._extrInfo.IvtStkCntZeroExtraDiv == 0)
            //    {
            //        //印字する
            //        wkStr = "棚卸数０出力: 出力する";
            //        this.EditCondition( ref allExtractCondition, wkStr );
            //    }
            //    else
            //    {
            //        //印字しない
            //        wkStr = "棚卸数０出力: 出力しない";
            //        this.EditCondition( ref allExtractCondition, wkStr );
            //    }
            //}
            ////棚卸差異表
            //// 2007.09.14 修正 >>>>>>>>>>>>>>>>>>>>
            ////else if(this._extrInfo.SelctedPaperKindDiv == 1)
            //else if(this._extrInfo.SelectedPaperKind == 1)
            //// 2007.09.14 修正 <<<<<<<<<<<<<<<<<<<<
            //{
            //    //2007/04/24
            //    //帳簿数０出力を消す
            //    ////帳簿数０出力
            //    //if(this._extrInfo.IvtStkCntZeroExtraDiv == 0)
            //    //{
            //    //    //印字する
            //    //    wkStr = "帳簿数０出力: 出力する";
            //    //    this.EditCondition( ref allExtractCondition, wkStr );
            //    //}
            //    //else
            //    //{
            //    //    //印字しない
            //    //    wkStr = "帳簿数０出力: 出力しない";
            //    //    this.EditCondition( ref allExtractCondition, wkStr );
            //    //}
            //}

            ////得意先印字区分
            //if(this._extrInfo.CustomerPrintDiv == 0)
            //{              
            //    wkStr = "得意先印字区分: 仕入先を印字";
            //    this.EditCondition( ref allExtractCondition, wkStr );
            //}
            //else
            //{
            //    wkStr = "得意先印字区分: 委託先を印字";
            //    this.EditCondition( ref allExtractCondition, wkStr );
            //}

            ////帳簿数印字
            //// 2007.09.14 修正 >>>>>>>>>>>>>>>>>>>>
            ////if(this._extrInfo.SelctedPaperKindDiv == 0)
            //if(this._extrInfo.SelectedPaperKind == 0)
            //// 2007.09.14 修正 <<<<<<<<<<<<<<<<<<<<
            //{
            //    //記入表の場合
            //    //帳簿数印字
            //    if(this._extrInfo.StockCntPrintDiv == 0)
            //    {
            //        //印字する
            //        wkStr = "帳簿数印字: 印字する";
            //        this.EditCondition( ref allExtractCondition, wkStr );
            //    }
            //    else
            //    {
            //        //印字しない
            //        wkStr = "帳簿数印字: 印字しない";
            //        this.EditCondition( ref allExtractCondition, wkStr );
            //    }
            //}
            // 2008.10.31 30413 犬飼 非印字項目を削除 <<<<<<END
            
            // 2007.09.14 追加 >>>>>>>>>>>>>>>>>>>>
            //出力指定区分
            if (this._extrInfo.SelectedPaperKind == 0)
            {
                if (this._extrInfo.OutputAppointDiv == 0)
                {
                    //全て
                    wkStr = "出力指定: 全て";
                    this.EditCondition(ref allExtractCondition, wkStr);
                }
                else if (this._extrInfo.OutputAppointDiv == 1)
                {
                    //棚卸未入力のみ
                    wkStr = "出力指定: 棚卸未入力のみ";
                    this.EditCondition(ref allExtractCondition, wkStr);
                }
                else if (this._extrInfo.OutputAppointDiv == 2)
                {
                    //差異分のみ
                    wkStr = "出力指定: 差異分のみ";
                    this.EditCondition(ref allExtractCondition, wkStr);
                }
                else
                {
                    //重複棚番ありのみ
                    wkStr = "出力指定: 重複棚番ありのみ";
                    this.EditCondition(ref allExtractCondition, wkStr);
                }
            }

            // 2008.11.04 30413 犬飼 追加 >>>>>>START
            // 在庫区分
            if (this._extrInfo.StockDiv == 0)
            {
                // 全て
                wkStr = "在庫区分: 全て";
                this.EditCondition(ref allExtractCondition, wkStr);
            }
            else if (this._extrInfo.StockDiv == 1)
            {
                // 自社
                wkStr = "在庫区分: 自社";
                this.EditCondition(ref allExtractCondition, wkStr);
            }
            else
            {
                // 受託
                wkStr = "在庫区分: 受託";
                this.EditCondition(ref allExtractCondition, wkStr);
            }

            // -- UPD 2009/09/18 ------------------------>>>
            //// 棚卸未入力区分
            //if (this._extrInfo.SelectedPaperKind == 2)
            //{
            //    if (this._extrInfo.InventoryNonInputDiv == 0)
            //    {
            //        // 帳簿数採用
            //        wkStr = "棚卸未入力区分: 帳簿数採用";
            //        this.EditCondition(ref allExtractCondition, wkStr);
            //    }
            //    else
            //    {
            //        // 未入力扱い
            //        wkStr = "棚卸未入力区分: 未入力扱い";
            //        this.EditCondition(ref allExtractCondition, wkStr);
            //    }
            //}
            // -- UPD 2009/09/18 ------------------------<<<

            // 小計印字
            if ((this._extrInfo.SelectedPaperKind == 1) || (this._extrInfo.SelectedPaperKind == 2))
            {
                if (this._extrInfo.SubtotalPrintDiv == 0)
                {
                    // する
                    wkStr = "小計印字: する";
                    this.EditCondition(ref allExtractCondition, wkStr);
                }
                else
                {
                    // しない
                    wkStr = "小計印字: しない";
                    this.EditCondition(ref allExtractCondition, wkStr);
                }
            }
            // 2008.11.04 30413 犬飼 追加 <<<<<<END
            
            // 2008.10.31 30413 犬飼 非印字項目を削除 >>>>>>START
            ////棚卸未入力区分
            //if (this._extrInfo.SelectedPaperKind == 2)
            //{
            //    if (this._extrInfo.InventoryInputDiv == 0)
            //    {
            //        //未入力扱い
            //        wkStr = "棚卸未入力時: 未入力扱い";
            //        this.EditCondition(ref allExtractCondition, wkStr);
            //    }
            //    else
            //    {
            //        //帳簿数と同じ
            //        wkStr = "棚卸未入力時: 帳簿数と同じ";
            //        this.EditCondition(ref allExtractCondition, wkStr);
            //    }
            //}
            // 2008.10.31 30413 犬飼 非印字項目を削除 <<<<<<END
            
            // 2008.11.26 30413 犬飼 改ページ→改頁に文言変更 >>>>>>START
            //改ページ指定区分
            if (this._extrInfo.TurnOoverThePagesDiv == 0)
            {
                //倉庫
                //wkStr = "改ページ: 倉庫";
                wkStr = "改頁: 倉庫";
                this.EditCondition(ref allExtractCondition, wkStr);
            }
            else if (this._extrInfo.TurnOoverThePagesDiv == 1)
            {
                //印刷順
                // 2008.10.31 30413 犬飼 出力順に修正 >>>>>>START
                //wkStr = "改ページ: 印刷順";
                wkStr = "改頁: 出力順";
                // 2008.10.31 30413 犬飼 出力順に修正 <<<<<<END
                this.EditCondition(ref allExtractCondition, wkStr);

                if ((this._extrInfo.SortDiv == 0) || (this._extrInfo.SortDiv == 4))
                {
                    //棚番ブレイク区分（桁数）
                    int shelfNoBreak = this._extrInfo.ShelfNoBreakDiv + 1;
                    wkStr = "棚番ブレイク: " + shelfNoBreak.ToString() + "桁";
                    this.EditCondition(ref allExtractCondition, wkStr);
                }
            }
            else
            {
                //しない
                //wkStr = "改ページ: しない";
                wkStr = "改頁: しない";
                this.EditCondition(ref allExtractCondition, wkStr);
            }
            // 2008.11.26 30413 犬飼 改ページ→改頁に文言変更 <<<<<<END
            // 2007.09.14 追加 <<<<<<<<<<<<<<<<<<<<
            
            // ---ADD 2009/05/13 不具合対応[13259] ---------------------------->>>>>
            // ----- UPD 2011/01/11 ----------------->>>>>
            ////棚卸差異表時のみ
            //if (this._extrInfo.SelectedPaperKind == 0)
            // 棚卸調査表と棚卸差異表と棚卸表
            if (this._extrInfo.SelectedPaperKind == 0 || this._extrInfo.SelectedPaperKind == 1 || this._extrInfo.SelectedPaperKind == 2)
            // ----- UPD 2011/01/11 -----------------<<<<<
            {
                //貸出分
                if (this._extrInfo.LendExtraDiv == 0)
                {
                    wkStr = "貸出分: 印刷しない";
                    this.EditCondition(ref allExtractCondition, wkStr);
                }
                else
                {
                    wkStr = "貸出分: 印刷する";
                    this.EditCondition(ref allExtractCondition, wkStr);
                }

                //来勘計上分
                if (this._extrInfo.DelayPaymentDiv == 0)
                {
                    wkStr = "来勘計上分: 印刷しない";
                    this.EditCondition(ref allExtractCondition, wkStr);
                }
                else
                {
                    wkStr = "来勘計上分: 印刷する";
                    this.EditCondition(ref allExtractCondition, wkStr);
                }

            }
            // ---ADD 2009/05/13 不具合対応[13259] ----------------------------<<<<<

            //棚卸表時のみ
            // ---------ADD 2011/01/11 --------------------------->>>>>
            if (this._extrInfo.SelectedPaperKind == 2)
            {
                //数量印刷区分
                if (this._extrInfo.InventoryNonInputDiv == 0) //棚卸未入力区分:帳簿数採用
                {
                    if (this._extrInfo.NumOutputDiv == 1) // 棚卸数１以上出力
                    {
                        // wkStr = "数量印刷区分: 棚卸数１以上"; DEL 2011/02/10
                        wkStr = "数量出力区分: 棚卸数１以上"; //ADD 2011/02/10
                        this.EditCondition(ref allExtractCondition, wkStr);
                    }
                    else if (this._extrInfo.NumOutputDiv == 2) //棚卸数０以下出力
                    {
                        // wkStr = "数量印刷区分: 棚卸数０以下";DEL 2011/02/10
                        wkStr = "数量出力区分: 棚卸数０以下"; //ADD 2011/02/10
                        this.EditCondition(ref allExtractCondition, wkStr);
                    }
                    else if (this._extrInfo.NumOutputDiv == 3)                                // 棚卸数０のみ出力
                    {
                        // wkStr = "数量印刷区分: 棚卸数０のみ";DEL 2011/02/10
                        wkStr = "数量出力区分: 棚卸数０のみ"; //ADD 2011/02/10
                        this.EditCondition(ref allExtractCondition, wkStr);
                    }
                    else
                    {
                        // wkStr = "数量印刷区分: 全て"; // DEL 2011/02/10
                        wkStr = "数量出力区分: 全て";// ADD 2011/02/10
                        this.EditCondition(ref allExtractCondition, wkStr);
                    }
                }
                else                                           //棚卸未入力区分:未入力扱い
                {
                    if (this._extrInfo.NumOutputDiv == 4) // 未入力のみ出力
                    {
                        // wkStr = "数量印刷区分: 未入力のみ"; // DEL 2011/02/10
                        wkStr = "数量出力区分: 未入力のみ"; // ADD 2011/02/10
                        this.EditCondition(ref allExtractCondition, wkStr);
                    }
                    else if (this._extrInfo.NumOutputDiv == 5)// 未入力以外出力
                    {
                        // wkStr = "数量印刷区分: 未入力以外"; // DEL 2011/02/10
                        wkStr = "数量出力区分: 未入力以外"; // ADD 2011/02/10
                        this.EditCondition(ref allExtractCondition, wkStr);
                    }
                    else
                    {
                        // wkStr = "数量印刷区分: 全て"; // DEL 2011/02/10
                        wkStr = "数量出力区分: 全て"; // ADD 2011/02/10
                        this.EditCondition(ref allExtractCondition, wkStr);
                    }
                }

                // 棚番印刷区分
                if (this._extrInfo.WarehouseShelfOutputDiv == 1)      // 棚番なしのみ出力
                {
                    // wkStr = "棚番印刷区分: 棚番なしのみ"; // DEL 2011/02/10
                    wkStr = "棚番出力区分: 棚番なしのみ"; // ADD 2011/02/10
                    this.EditCondition(ref allExtractCondition, wkStr);
                }
                else if (this._extrInfo.WarehouseShelfOutputDiv == 2) // 棚番なし以外出力
                {
                    // wkStr = "棚番印刷区分: 棚番なし以外"; // DEL 2011/02/10
                    wkStr = "棚番出力区分: 棚番なし以外"; // ADD 2011/02/10
                    this.EditCondition(ref allExtractCondition, wkStr);
                }
                else                                                  // 全て出力
                {
                    // wkStr = "棚番印刷区分: 全て"; // DEL 2011/02/10
                    wkStr = "棚番出力区分: 全て"; // ADD 2011/02/10
                    this.EditCondition(ref allExtractCondition, wkStr);
                }
            }
            // ---------ADD 2011/01/11 ---------------------------<<<<<
           
            #endregion
    		
			StringCollection wkStrCollection = new StringCollection();
			// 抽出条件2
			this.MakeCondition2( ref wkStrCollection );
			// 条件項目追加
			foreach( string workStr in wkStrCollection ) 
            {
				allExtractCondition.Add( workStr );
			}

           
		}

		/// <summary>
		/// 抽出条件文字列編集
		/// </summary>
		/// <param name="editArea">格納エリア</param>
		/// <param name="target">対象文字列</param>
		/// <remarks>
		/// <br>Note       : 出力する抽出条件文字列を編集します。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2007.04.09</br>
        /// <br>UpdateNote : 2011/02/10 liyp</br>
        /// <br>           : 障害報告 #18874</br>
		/// </remarks>
		private void EditCondition( ref StringCollection editArea, string target )
		{
			bool isEdit = false;

            // 2008.11.26 30413 犬飼 抽出条件を適宜改行するように修正 >>>>>>START
            // 編集対象文字バイト数算出
            int targetByte = TStrConv.SizeCountSJIS( target );
			
            //for( int ix = 0; ix < editArea.Count; ix++ ) {
            //    int areaByte = 0;
				
            //    // 格納エリアのバイト数算出
            //    if( editArea[ ix ] != null ) {
            //        areaByte = TStrConv.SizeCountSJIS( editArea[ ix ] );
            //    }

            //    if( ( areaByte + targetByte + 2 ) <= 190 ) {
            //        isEdit = true;

            //        // 全角スペースを挿入
            //        if( editArea[ ix ] != null ) {
            //            editArea[ ix ] += CT_SPACE;
            //        }
					
            //        editArea[ ix ] += target;
            //        break;
            //    }
            //}

            int index = 0;
            int areaByte = 0;

            // 追加するエリアのインデックスを取得
            if (editArea.Count != 0)
            {
                index = editArea.Count - 1;

                // 格納エリアのバイト数算出
                if (editArea[index] != null)
                {
                    areaByte = TStrConv.SizeCountSJIS(editArea[index]);
                }

                
                if ((this._extrInfo.SelectedPaperKind == 0) && ((areaByte + targetByte + 2) >= 120))
                {
                    // 棚卸調査表
                    // 改行
                    editArea[index] += "\n";
                }
                // else if ((this._extrInfo.SelectedPaperKind != 0) && ((areaByte + targetByte + 2) >= 140)) //DEL 2011/02/10
                else if ((this._extrInfo.SelectedPaperKind != 0) && ((areaByte + targetByte +2) >= 200)) //ADD 2011/02/10
                {
                    // 改行
                    editArea[index] += "\n";
                }
                else
                {
                    isEdit = true;

                    // 全角スペースを挿入
                    if (editArea[index] != null) editArea[index] += CT_SPACE;

                    editArea[index] += target;
                }
            }
            // 2008.11.26 30413 犬飼 抽出条件を適宜改行するように修正 <<<<<<END

			// 新規編集エリア作成
			if( !isEdit ) {
				editArea.Add( target );
			}
		}

		/// <summary>
		/// 抽出条件1作成
		/// </summary>
		/// <param name="extraCondition">抽出条件1</param>
		/// <remarks>
		/// <br>Note       : 抽出条件1作成(出力条件）。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2007.04.09</br>
		/// </remarks>
		private void MakeCondition2( ref StringCollection extraCondition )
        {
            #region 抽出条件２作成処理
            // 2008.10.31 30413 犬飼 定数追加 >>>>>>START
            const string ct_Extr_Top = "最初から";
            const string ct_Extr_End = "最後まで";
            // 2008.10.31 30413 犬飼 定数追加 <<<<<<END
            
            string wkStr = "";
            // 2007.09.14 削除 >>>>>>>>>>>>>>>>>>>>
            //string target = "";
            // 2007.09.14 削除 <<<<<<<<<<<<<<<<<<<<
            string start = "";
            string end   = "";

            // 2008.10.31 30413 犬飼 抽出条件の修正 >>>>>>START
            // 倉庫コード
			if( ( this._extrInfo.St_WarehouseCode != "" ) || ( this._extrInfo.Ed_WarehouseCode != "" ) ) 
            {
                // 開始
                if(this._extrInfo.St_WarehouseCode == "")
                {
                    //start = "ＴＯＰ";
                    start = ct_Extr_Top;
                }
                else
                {
                    start = this._extrInfo.St_WarehouseCode;
                }
                // 終了
                if(this._extrInfo.Ed_WarehouseCode == "")
                {
                    //end   = "ＥＮＤ";
                    end = ct_Extr_End;
                }
                else
                {
                    end = this._extrInfo.Ed_WarehouseCode;
                }
                //wkStr = String.Format( "倉庫コード： {0} ～ {1}", 
                //start, end );
                //this.EditCondition( ref extraCondition, wkStr );
                wkStr = String.Format("倉庫： {0} ～ {1}",
                start, end);
                this.EditCondition(ref extraCondition, wkStr);
			}

            // 2007.09.14 追加 >>>>>>>>>>>>>>>>>>>>
            // 棚番
            if ((this._extrInfo.St_WarehouseShelfNo != "") || (this._extrInfo.Ed_WarehouseShelfNo != ""))
            {
                // 開始
                if (this._extrInfo.St_WarehouseShelfNo == "")
                {
                    //start = "ＴＯＰ";
                    start = ct_Extr_Top;
                }
                else
                {
                    start = this._extrInfo.St_WarehouseShelfNo;
                }
                //終了
                if (this._extrInfo.Ed_WarehouseShelfNo == "")
                {
                    //end = "ＥＮＤ";
                    end = ct_Extr_End;
                }
                else
                {
                    end = this._extrInfo.Ed_WarehouseShelfNo;
                }
                wkStr = String.Format("棚番： {0} ～ {1}",
                start, end);
                this.EditCondition(ref extraCondition, wkStr);
            }
            // 2007.09.14 追加 <<<<<<<<<<<<<<<<<<<<
            // 2008.10.31 30413 犬飼 抽出条件の修正 <<<<<<END
            
            // 2007.09.14 削除 >>>>>>>>>>>>>>>>>>>>
            //// キャリア
            //if( ( this._extrInfo.St_CarrierCode != 0 ) || ( this._extrInfo.Ed_CarrierCode != 999 ) ) 
            //{
			//    wkStr = String.Format( "キャリアコード： {0} ～ {1}", 
			//	this._extrInfo.St_CarrierCode.ToString(), this._extrInfo.Ed_CarrierCode.ToString() );
			//    this.EditCondition( ref extraCondition, wkStr );
		    //}           
            ////事業者コード
            //if( ( this._extrInfo.St_CarrierEpCode != 0 ) || ( this._extrInfo.Ed_CarrierEpCode != 9999 ) ) 
            //{
            //	wkStr = String.Format( "事業者コード： {0} ～ {1}", 
            //	this._extrInfo.St_CarrierEpCode.ToString(), this._extrInfo.Ed_CarrierEpCode.ToString() );
            //	this.EditCondition( ref extraCondition, wkStr );
            //}
            // 2007.09.14 削除 <<<<<<<<<<<<<<<<<<<<

            // 2008.10.31 30413 犬飼 抽出条件の追加 >>>>>>START
            // 仕入先
            if ((this._extrInfo.St_SupplierCd == 0) && (this._extrInfo.Ed_SupplierCd != 0))
            {
                wkStr = "仕入先: " + ct_Extr_Top + " ～ " + this._extrInfo.Ed_SupplierCd.ToString("d06");
                this.EditCondition(ref extraCondition, wkStr);
            }

            if ((this._extrInfo.St_SupplierCd > 0) && (this._extrInfo.Ed_SupplierCd == 0))
            {
                wkStr = "仕入先: " + this._extrInfo.St_SupplierCd.ToString("d06") + " ～ " + ct_Extr_End;
                this.EditCondition(ref extraCondition, wkStr);
            }

            if ((this._extrInfo.St_SupplierCd > 0) && (this._extrInfo.Ed_SupplierCd != 0))
            {
                wkStr = "仕入先: " + this._extrInfo.St_SupplierCd.ToString("d06") + " ～ " + this._extrInfo.Ed_SupplierCd.ToString("d06");
                this.EditCondition(ref extraCondition, wkStr);
            }

            // BLコード
            if ((this._extrInfo.St_BLGoodsCode == 0) && (this._extrInfo.Ed_BLGoodsCode != 0))
            {
                wkStr = "BLｺｰﾄﾞ: " + ct_Extr_Top + " ～ " + this._extrInfo.Ed_BLGoodsCode.ToString("d05");
                this.EditCondition(ref extraCondition, wkStr);
            }

            if ((this._extrInfo.St_BLGoodsCode > 0) && (this._extrInfo.Ed_BLGoodsCode == 0))
            {
                wkStr = "BLｺｰﾄﾞ: " + this._extrInfo.St_BLGoodsCode.ToString("d05") + " ～ " + ct_Extr_End;
                this.EditCondition(ref extraCondition, wkStr);
            }

            if ((this._extrInfo.St_BLGoodsCode > 0) && (this._extrInfo.Ed_BLGoodsCode != 0))
            {
                wkStr = "BLｺｰﾄﾞ: " + this._extrInfo.St_BLGoodsCode.ToString("d05") + " ～ " + this._extrInfo.Ed_BLGoodsCode.ToString("d05");
                this.EditCondition(ref extraCondition, wkStr);
            }

            // グループコード
            if ((this._extrInfo.St_BLGroupCode == 0) && (this._extrInfo.Ed_BLGroupCode != 0))
            {
                wkStr = "ｸﾞﾙｰﾌﾟ: " + ct_Extr_Top + " ～ " + this._extrInfo.Ed_BLGroupCode.ToString("d05");
                this.EditCondition(ref extraCondition, wkStr);
            }

            if ((this._extrInfo.St_BLGroupCode > 0) && (this._extrInfo.Ed_BLGroupCode == 0))
            {
                wkStr = "ｸﾞﾙｰﾌﾟ: " + this._extrInfo.St_BLGroupCode.ToString("d05") + " ～ " + ct_Extr_End;
                this.EditCondition(ref extraCondition, wkStr);
            }

            if ((this._extrInfo.St_BLGroupCode > 0) && (this._extrInfo.Ed_BLGroupCode != 0))
            {
                wkStr = "ｸﾞﾙｰﾌﾟ: " + this._extrInfo.St_BLGroupCode.ToString("d05") + " ～ " + this._extrInfo.Ed_BLGroupCode.ToString("d05");
                this.EditCondition(ref extraCondition, wkStr);
            }

            // メーカーコード
            if ((this._extrInfo.St_MakerCode == 0) && (this._extrInfo.Ed_MakerCode != 0))
            {
                wkStr = "ﾒｰｶｰ: " + ct_Extr_Top + " ～ " + this._extrInfo.Ed_MakerCode.ToString("d04");
                this.EditCondition(ref extraCondition, wkStr);
            }

            if ((this._extrInfo.St_MakerCode > 0) && (this._extrInfo.Ed_MakerCode == 0))
            {
                wkStr = "ﾒｰｶｰ: " + this._extrInfo.St_MakerCode.ToString("d04") + " ～ " + ct_Extr_End;
                this.EditCondition(ref extraCondition, wkStr);
            }

            if ((this._extrInfo.St_MakerCode > 0) && (this._extrInfo.Ed_MakerCode != 0))
            {
                wkStr = "ﾒｰｶｰ: " + this._extrInfo.St_MakerCode.ToString("d04") + " ～ " + this._extrInfo.Ed_MakerCode.ToString("d04");
                this.EditCondition(ref extraCondition, wkStr);
            }
            // 2008.10.31 30413 犬飼 抽出条件の追加 <<<<<<END
            
            // 2008.10.31 30413 犬飼 抽出条件の削除 >>>>>>START
            ////メーカーコード
            //// 2008.02.13 修正 >>>>>>>>>>>>>>>>>>>>
            ////if ((this._extrInfo.St_MakerCode != 0) || (this._extrInfo.Ed_MakerCode != 999))
            //if ((this._extrInfo.St_MakerCode != 0) || (this._extrInfo.Ed_MakerCode != 999999))
            //// 2008.02.13 修正 <<<<<<<<<<<<<<<<<<<<
            //{
            //    wkStr = String.Format( "メーカーコード： {0} ～ {1}", 
            //    this._extrInfo.St_MakerCode.ToString(), this._extrInfo.Ed_MakerCode.ToString() );
            //    this.EditCondition( ref extraCondition, wkStr );
            //}

            ////仕入先コード
            //if( ( this._extrInfo.St_CustomerCode != 0 ) || ( this._extrInfo.Ed_CustomerCode != 999999999 ) ) 
            //{
            //    wkStr = String.Format( "仕入先コード： {0} ～ {1}", 
            //    this._extrInfo.St_CustomerCode.ToString(), this._extrInfo.Ed_CustomerCode.ToString() );
            //    this.EditCondition( ref extraCondition, wkStr );
            //}

            ////委託先コード
            //if( ( this._extrInfo.St_ShipCustomerCode != 0 ) || ( this._extrInfo.Ed_ShipCustomerCode != 999999999 ) ) 
            //{
            //    wkStr = String.Format( "委託先コード： {0} ～ {1}", 
            //    this._extrInfo.St_ShipCustomerCode.ToString(), this._extrInfo.Ed_ShipCustomerCode.ToString() );
            //    this.EditCondition( ref extraCondition, wkStr );
            //}
            ////商品区分グループコード
            //if( ( this._extrInfo.St_LargeGoodsGanreCode != "" ) || ( this._extrInfo.Ed_LargeGoodsGanreCode != "" ) ) 
            //{
            //    start = "";
            //    end   = "";
            //    if(this._extrInfo.St_LargeGoodsGanreCode == "")
            //    {
            //        start = "ＴＯＰ";
            //    }
            //    else
            //    {
            //        start = this._extrInfo.St_LargeGoodsGanreCode;
            //    }
            //    if(this._extrInfo.Ed_LargeGoodsGanreCode == "")
            //    {
            //        end   = "ＥＮＤ";
            //    }
            //    else
            //    {
            //        end = this._extrInfo.Ed_LargeGoodsGanreCode;
            //    }

            //    wkStr = String.Format( "商品区分グループ： {0} ～ {1}", 
            //    start, end );
            //    this.EditCondition( ref extraCondition, wkStr );
            //}

            ////商品区分コード
            //if( ( this._extrInfo.St_MediumGoodsGanreCode != "" ) || ( this._extrInfo.Ed_MediumGoodsGanreCode != "" ) ) 
            //{
            //    start = "";
            //    end   = "";
            //    if(this._extrInfo.St_MediumGoodsGanreCode == "")
            //    {
            //        start = "ＴＯＰ";
            //    }
            //    else
            //    {
            //        start = this._extrInfo.St_MediumGoodsGanreCode;
            //    }
            //    if(this._extrInfo.Ed_MediumGoodsGanreCode == "")
            //    {
            //        end   = "ＥＮＤ";
            //    }
            //    else
            //    {
            //        end = this._extrInfo.Ed_MediumGoodsGanreCode;
            //    }

            //    wkStr = String.Format( "商品区分： {0} ～ {1}", 
            //    start, end );
            //    this.EditCondition( ref extraCondition, wkStr );
            //}
            // 2008.10.31 30413 犬飼 抽出条件の削除 <<<<<<END
            
            // 2007.09.14 修正 >>>>>>>>>>>>>>>>>>>>
            ////機種コード
            //if( ( this._extrInfo.St_CellphoneModelCode != "" ) || ( this._extrInfo.Ed_CellphoneModelCode != "" ) ) 
            //{
            //    start = "";
            //    end   = "";
            //    if(this._extrInfo.St_CellphoneModelCode == "")
            //    {
            //        start = "ＴＯＰ";
            //    }
            //    else
            //    {
            //        start = this._extrInfo.St_CellphoneModelCode;
            //    }
            //    if(this._extrInfo.Ed_CellphoneModelCode == "")
            //    {
            //        end   = "ＥＮＤ";
            //    }
            //    else
            //    {
            //        end = this._extrInfo.Ed_CellphoneModelCode;
            //    }
            //
            //    wkStr = String.Format( "機種コード： {0} ～ {1}", 
            //	start, end );
            //    this.EditCondition( ref extraCondition, wkStr );
            //}

            // 2008.10.31 30413 犬飼 抽出条件の削除 >>>>>>START
            ////商品区分詳細コード
            //if ((this._extrInfo.St_DetailGoodsGanreCode != "") || (this._extrInfo.Ed_DetailGoodsGanreCode != ""))
            //{
            //    start = "";
            //    end = "";
            //    if (this._extrInfo.St_DetailGoodsGanreCode == "")
            //    {
            //        start = "ＴＯＰ";
            //    }
            //    else
            //    {
            //        start = this._extrInfo.St_DetailGoodsGanreCode;
            //    }
            //    if (this._extrInfo.Ed_DetailGoodsGanreCode == "")
            //    {
            //        end = "ＥＮＤ";
            //    }
            //    else
            //    {
            //        end = this._extrInfo.Ed_DetailGoodsGanreCode;
            //    }

            //    wkStr = String.Format("商品区分詳細： {0} ～ {1}",
            //    start, end);
            //    this.EditCondition(ref extraCondition, wkStr);
            //}

            ////自社分類コード
            //// 2008.02.13 修正 >>>>>>>>>>>>>>>>>>>>
            ////if ((this._extrInfo.St_EnterpriseGanreCode != 0) || (this._extrInfo.Ed_EnterpriseGanreCode != 99))
            //if ((this._extrInfo.St_EnterpriseGanreCode != 0) || (this._extrInfo.Ed_EnterpriseGanreCode != 9999))
            //// 2008.02.13 修正 <<<<<<<<<<<<<<<<<<<<
            //{
            //    wkStr = String.Format("自社分類コード： {0} ～ {1}",
            //    this._extrInfo.St_EnterpriseGanreCode.ToString(), this._extrInfo.Ed_EnterpriseGanreCode.ToString());
            //    this.EditCondition(ref extraCondition, wkStr);
            //}

            ////ＢＬコード
            //// 2008.02.13 修正 >>>>>>>>>>>>>>>>>>>>
            ////if ((this._extrInfo.St_BLGoodsCode != 0) || (this._extrInfo.Ed_BLGoodsCode != 99))
            //if ((this._extrInfo.St_BLGoodsCode != 0) || (this._extrInfo.Ed_BLGoodsCode != 99999999))
            //// 2008.02.13 修正 <<<<<<<<<<<<<<<<<<<<
            //{
            //    wkStr = String.Format("ＢＬコード： {0} ～ {1}",
            //    this._extrInfo.St_BLGoodsCode.ToString(), this._extrInfo.Ed_BLGoodsCode.ToString());
            //    this.EditCondition(ref extraCondition, wkStr);
            //}
            //// 2007.09.14 修正 <<<<<<<<<<<<<<<<<<<<
            
            ////商品コード
            //if( ( this._extrInfo.St_GoodsNo != "" ) || ( this._extrInfo.Ed_GoodsNo != "" ) ) 
            //{
            //    start = "";
            //    end   = "";
            //    if (this._extrInfo.St_GoodsNo == "")
            //    {
            //        start = "ＴＯＰ";
            //    }
            //    else
            //    {
            //        start = this._extrInfo.St_GoodsNo;
            //    }
            //    if (this._extrInfo.Ed_GoodsNo == "")
            //    {
            //        end   = "ＥＮＤ";
            //    }
            //    else
            //    {
            //        end = this._extrInfo.Ed_GoodsNo;
            //    }

            //    wkStr = String.Format( "商品コード： {0} ～ {1}", 
            //    start, end );
            //    this.EditCondition( ref extraCondition, wkStr );
            //}
            // 2008.10.31 30413 犬飼 抽出条件の削除 <<<<<<END
            
            // 2007.09.14 削除 >>>>>>>>>>>>>>>>>>>>
            //target = "在庫区分: ";
            //wkStr = "";
            //
            //// 在庫区分(自社)      
			//if( this._extrInfo.CompanyStockExtraDiv == 0 ) 
            //{
            //    //抽出する
			//	wkStr += "自社";
			//}
            //// 在庫区分(受託)      
			//if( this._extrInfo.TrustStockExtraDiv == 0 ) 
            //{
            //    //抽出する
            //    if(wkStr != "")
            //    {
            //        wkStr += ",受託";
            //    }				
            //    else
            //    {
            //        wkStr += "受託";
            //    }
			//}
            //// 在庫区分(委託(自社))      
			//if( this._extrInfo.EntrustCmpStockExtraDiv == 0 ) 
            //{
            //    //抽出する
            //    if(wkStr != "")
            //    {
            //        wkStr += ",委託(自社)";
            //    }
            //    else
            //    {
            //        wkStr += "委託(自社)";
            //    }				
            //}
            //// 在庫区分(委託(受託))      
            //if( this._extrInfo.EntrustTrtStockExtraDiv == 0 ) 
            //{
            //    //抽出する
            //    if(wkStr != "")
            //    {
            //        wkStr += ",委託(受託)";
            //    }
            //    else
            //    {
            //        wkStr += "委託(受託)";
            //    }				
            //}
            //
            //target += wkStr;
            //
            //this.EditCondition( ref extraCondition, target );
            // 2007.09.14 削除 <<<<<<<<<<<<<<<<<<<<

            #endregion
        }
	    

		/// <summary>
		/// ソート順文字列作成処理
		/// </summary>
		/// <returns>ソート順文字列</returns>
		/// <remarks>
		/// <br>Note       : ソート順文字列を作成します。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2007.04.09</br>
		/// </remarks>
		private string MakeSortCondition()
		{
			return String.Format( "[{0}]",InventSearchCndtnUI.GetTargetSortTitle(this._extrInfo.SortDiv) + " 順");
		}

        #region ◆　印刷順クエリ作成関数
        /// <summary>
        /// 印字順クエリ作成処理
        /// </summary>
        /// <returns>作成したクエリ</returns>
        /// <remarks>
        /// <br>Note       : DataViewに設定する印字順位のクエリを作成します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2008.02.13</br>
        /// </remarks>
        private string GetPrintOderQuerry()
        {
            string orderQuerry = CT_SectionCode_Odr + "," + CT_WarehouseCode_Odr + ",";

            // 2008.10.31 30413 犬飼 Eクラスでソート済のため省略 >>>>>>START
            //switch (this._extrInfo.SortDiv)
            //{
            //    // 倉庫→棚番→メーカー→商品区分→商品 順
            //    case (int)InventSearchCndtnUI.SortOrder.Warehouce_ShelfNo_GoodsDiv:
            //        {
            //            orderQuerry = orderQuerry + CT_WarehouseShelfNo_Odr + "," + CT_MakerCode_Odr + "," + CT_GoodsDivL_Odr + "," + CT_GoodsDivM_Odr + "," + CT_GoodsDivD_Odr + "," + CT_GoodsCode_Odr;
            //            break;
            //        }
            //    // 倉庫→棚番→メーカー→商品 順
            //    case (int)InventSearchCndtnUI.SortOrder.Warehouce_ShelfNo:
            //        {
            //            orderQuerry = orderQuerry + CT_WarehouseShelfNo_Odr + "," + CT_MakerCode_Odr + "," + CT_GoodsCode_Odr;
            //            break;
            //        }
            //    // 倉庫→仕入先 順
            //    case (int)InventSearchCndtnUI.SortOrder.Warehouce_Customer:
            //        {
            //            orderQuerry = orderQuerry + CT_CustomerCode_Odr;
            //            break;
            //        }
            //    // 倉庫→ＢＬコード 順
            //    case (int)InventSearchCndtnUI.SortOrder.Warehouce_BLCode:
            //        {
            //            orderQuerry = orderQuerry + CT_BLGoodsCode_Odr;
            //            break;
            //        }
            //    // 倉庫→メーカー 順
            //    case (int)InventSearchCndtnUI.SortOrder.Warehouce_Maker:
            //        {
            //            orderQuerry = orderQuerry + CT_MakerCode_Odr;
            //            break;
            //        }
            //    // 倉庫→仕入先→棚番 順
            //    case (int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_ShelfNo:
            //        {
            //            orderQuerry = orderQuerry + CT_CustomerCode_Odr + "," + CT_WarehouseShelfNo_Odr;
            //            break;
            //        }
            //    // 倉庫→仕入先→メーカー 順
            //    case (int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_Maker:
            //        {
            //            orderQuerry = orderQuerry + CT_CustomerCode_Odr + "," + CT_MakerCode_Odr;
            //            break;
            //        }
            //}
            // 2008.10.31 30413 犬飼 Eクラスでソート済のため省略 <<<<<<END
            
            return orderQuerry;
        }
        #endregion

        /// <summary>
		/// エラーメッセージ表示処理
		/// </summary>
		/// <param name="iLevel">エラーレベル</param>
		/// <param name="message">表示メッセージ</param>
		/// <param name="status">ステータス</param>
		/// <param name="procNm">発生メソッドID</param>
		/// <remarks>
		/// <br>Note       : エラーメッセージの表示を行います。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2007.04.09</br>
		/// </remarks>
		private void MsgDispProc( emErrorLevel iLevel, string message, int status, string procNm )
		{
			TMsgDisp.Show( 
				iLevel, 							// エラーレベル
				CT_CLASSID,							// アセンブリＩＤまたはクラスＩＤ
				CT_PGNM,							// プログラム名称
				procNm, 							// 処理名称
				"",									// オペレーション
				message,							// 表示するメッセージ
				status, 							// ステータス値
				null, 								// エラーが発生したオブジェクト
				MessageBoxButtons.OK, 				// 表示するボタン
				MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
		}

		/// <summary>
		/// エラーメッセージ表示処理
		/// </summary>
		/// <param name="message">表示メッセージ</param>
		/// <param name="status">ステータス</param>
		/// <param name="procnm">発生メソッドID</param>
		/// <param name="ex">例外情報</param>
		/// <remarks>
		/// <br>Note       : エラーメッセージの表示を行います。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2007.04.09</br>
		/// </remarks>
		private void MsgDispProc( string message, int status, string procnm, Exception ex )
		{
			string errMessage = message + "\r\n" + ex.Message;

			TMsgDisp.Show( 
				emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
				CT_CLASSID,							// アセンブリＩＤまたはクラスＩＤ
				CT_PGNM,							// プログラム名称
				procnm, 							// 処理名称
				"",									// オペレーション
				errMessage,							// 表示するメッセージ
				status, 							// ステータス値
				null, 								// エラーが発生したオブジェクト
				MessageBoxButtons.OK, 				// 表示するボタン
				MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
		}

		#endregion
	}
}

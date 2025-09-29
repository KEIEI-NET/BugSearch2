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
	/// 在庫一覧表印刷クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 在庫一覧表を印刷します。</br>
	/// <br>Programmer : 23010 中村　仁</br>
	/// <br>Date       : 2007.03.22</br>
    /// <br>Update Note: 2007.10.05 980035 金沢 貞義</br>
    /// <br>			 ・DC.NS対応</br>
    /// <br>Update Note: 2008.01.24 980035 金沢 貞義</br>
    /// <br>			 ・DC.NS対応（不具合対応）</br>
    /// <br>Update Note: 2008/10/08        照田 貴志</br>
    /// <br>			 ・バグ修正、仕様変更対応</br>
    /// <br>Update Note: 2009/03/17        上野 俊治</br>
    /// <br>			 ・障害対応12703</br>
    /// </remarks>
	class MAZAI02072PA
	{
		// --------------------------------------------------
		#region Constructor

		/// <summary>
		/// 在庫一覧表印刷クラスコンストラクタ
		/// </summary>
		/// <param name="printInfo">印刷情報オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 在庫一覧表印刷クラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2007.03.22</br>
		/// </remarks>
		public MAZAI02072PA( object printInfo )
		{
			// 印刷情報オブジェクト取得
			this._printInfo    = printInfo as SFCMN06002C;
			// アクセスクラスインスタンス生成
			this._stockListAcs = new StockListAcs();
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
		/// <br>Date       : 2007.03.22</br>
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
			/// <br>Date       : 2007.03.16</br>
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
			/// <br>Date       : 2007.03.16</br>
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
		private StockListCndtn _extrInfo   = null;

		// 在庫一覧表アクセスクラス
		private StockListAcs _stockListAcs    = null;

		#endregion

		// --------------------------------------------------
		#region Constant

		// クラスID
		private const string	CT_CLASSID              = "MAZAI02072PA";
		// プログラムID
		private const string	CT_PGID                 = "MAZAI02072P";
		// プログラム名称
		private const string	CT_PGNM                 = "在庫一覧表";

		// 抽出条件文字間隔用定数
		private const string	CT_SPACE                = "    ";
		// ReportFormNamspace
		private const string	CT_REPORTFORM_NAMESPACE = "Broadleaf.Drawing.Printing";
        //a

		#endregion

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
		/// <br>Date       : 2007.03.22</br>
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
		/// <br>Date       : 2007.03.22</br>
		/// </remarks>
		private int PrintMain()
		{
			const string ctPROCNM = "PrintMain";
			int status = ( int )ConstantManagement.MethodResult.ctFNC_ERROR;

			this._extrInfo = this._printInfo.jyoken as StockListCndtn;

			// 印刷用フォームクラス
			DataDynamics.ActiveReports.ActiveReport3 prtRpt = null;

			try 
            {
				// 印刷用データビューインスタンス生成
				DataView dv = this._printInfo.rdData as DataView;

				// レポートインスタンス生成
				this.CreateReport( out prtRpt, this._printInfo.prpid );
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
                //status = this.SetPrintCommonInfo( out commonInfo ); // DEL 2009/03/17
                status = this.SetPrintCommonInfo(ref prtRpt, out commonInfo); // ADD 2009/03/17

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
		/// <br>Date       : 2007.03.16</br>
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
		/// <br>Date       : 2007.03.16</br>
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
		/// <br>Date       : 2007.03.22</br>
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
				
				// 在庫全体設定情報取得
				StockMngTtlSt stockMngTtlSt = null;
				string mess;
				status = this._stockListAcs.ReadStockMngTtlSt( out stockMngTtlSt, out mess );
				if( status != 0 ) {
					throw new ReportPrintException( mess, status, ctPROCNM );
				}
                //条件クラスにセットしておく
                this._extrInfo.StockPointWay = stockMngTtlSt.StockPointWay;  
                
                // 帳票出力設定情報取得
				PrtOutSet prtOutSet = null;
				string message;
				status = this._stockListAcs.ReadPrtOutSet( out prtOutSet, out message );
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

				// ヘッダーサブタイトル
                instance.PageHeaderSubtitle             = "";
                
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
		/// <br>Date       : 2007.03.16</br>
		/// </remarks>
        //private int SetPrintCommonInfo( out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo ) // DEL 2009/03/17
        private int SetPrintCommonInfo(ref DataDynamics.ActiveReports.ActiveReport3 rptObj, out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo) // ADD 2009/03/17
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

            // --- ADD 2009/03/17 -------------------------------->>>>>
            rptObj.Document.CacheToDisk = true;
            rptObj.Document.CacheToDiskLocation = pdfPath;
            // --- ADD 2009/03/17 --------------------------------<<<<< 

			return status;
		}

		/// <summary>
		///	抽出条件作成関数
		/// </summary>
		/// <remarks>
		/// <br>Note       : 対象期間、抽出条件１，２をstring型の配列に格納する。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2007.03.16</br>
		/// </remarks>
		private void MakeExtractConditionMain( out StringCollection allExtractCondition )
		{
			allExtractCondition = new StringCollection();

            string start = "";      //ADD 2008/10/08
            string end = "";        //ADD 2008/10/08
            string wkStr = "";

            //--- ADD 2008/08/01 ---------->>>>>
            // --- ADD 2008/10/08 ----------------------------------------------------------------------------------------->>>>>
            //最終仕入日
            //開始日or終了日が入力されている
            if ((this._extrInfo.St_LastStockDate != DateTime.MinValue) || (this._extrInfo.Ed_LastStockDate != DateTime.MinValue))
            {
                //開始仕入日が入っていない場合
                if (this._extrInfo.St_LastStockDate == DateTime.MinValue)
                {
                    start = "最初から";
                }
                else
                {
                    start = TDateTime.DateTimeToString("YYYY/MM", this._extrInfo.St_LastStockDate);
                }

                if (this._extrInfo.Ed_LastStockDate == DateTime.MinValue)
                {
                    end = "最後まで";
                }
                else
                {
                    end = TDateTime.DateTimeToString("YYYY/MM", this._extrInfo.Ed_LastStockDate);
                }
                wkStr = String.Format("対象年月" + "： {0} ～ {1}", start, end);
                this.EditCondition(ref allExtractCondition, wkStr);
            }
            // --- ADD 2008/10/08 -----------------------------------------------------------------------------------------<<<<<
            // 在庫登録日
            if (this._extrInfo.StockCreateDate != DateTime.MinValue)
            {
                wkStr = String.Format("在庫登録日： {0} {1}",
                //this._extrInfo.StockCreateDate.ToString("yyyy年MM月dd日"),        //DEL 2008/10/08 書式変更
                this._extrInfo.StockCreateDate.ToString("yyyy/MM/dd"),              //ADD 2008/10/08
                this._extrInfo.StockCreateDateDivStateTitle);
                this.EditCondition(ref allExtractCondition, wkStr);
            }
            // 出荷指定
            if ((this._extrInfo.St_ShipmentPosCnt != 0) || (this._extrInfo.Ed_ShipmentPosCnt != 99999999))
            {
                //wkStr = String.Format("出荷指定： {0} ～ {1}",            //DEL 2008/10/08 文言変更
                wkStr = String.Format("出荷数指定： {0}個 ～ {1}個",        //ADD 2008/10/08
                this._extrInfo.St_ShipmentPosCnt.ToString(), this._extrInfo.Ed_ShipmentPosCnt.ToString());
                this.EditCondition(ref allExtractCondition, wkStr);
            }
            // --- ADD 2008/10/08 ----------------------------------------------------------------------------------------->>>>>
            // 管理区分1
            if ((this._extrInfo.PartsManagementDivide1 != null) &&
                (this._extrInfo.PartsManagementDivide1.Length > 0))
            {
                StringBuilder partsMngDiv1 = new StringBuilder("管理区分1：");
                Array.Sort<string>(this._extrInfo.PartsManagementDivide1);
                foreach (string partsMngDiv1Item in this._extrInfo.PartsManagementDivide1)
                {
                    partsMngDiv1.Append(partsMngDiv1Item);
                }

                EditCondition(ref allExtractCondition, partsMngDiv1.ToString());
            }
            // 管理区分2
            if ((this._extrInfo.PartsManagementDivide2 != null) &&
                (this._extrInfo.PartsManagementDivide2.Length > 0))
            {
                StringBuilder partsMngDiv2 = new StringBuilder("管理区分2：");
                Array.Sort<string>(this._extrInfo.PartsManagementDivide2);
                foreach (string partsMngDiv2Item in this._extrInfo.PartsManagementDivide2)
                {
                    partsMngDiv2.Append(partsMngDiv2Item);
                }

                EditCondition(ref allExtractCondition, partsMngDiv2.ToString());
            }
            // --- ADD 2008/10/08 -----------------------------------------------------------------------------------------<<<<<
            // 棚番ブレイク指定
            if (this._extrInfo.ChangePageDiv == 1)
            {
                wkStr = String.Format("棚番ブレイク指定： {0}",
                this._extrInfo.WarehouseShelfNoBreakDivStateTitle);
                this.EditCondition(ref allExtractCondition, wkStr);
            }
            //--- ADD 2008/08/01 ----------<<<<<

            //商品コード
            // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
            //if ((this._extrInfo.St_GoodsCode != "") || (this._extrInfo.Ed_GoodsCode != "")) 
            //{
            //    string start = "";
            //    string end   = "";
            //    if(this._extrInfo.St_GoodsCode == "")
            //    {
            //        start = "ＴＯＰ";
            //    }
            //    else
            //    {
            //        start = this._extrInfo.St_GoodsCode;
            //    }
            //    if(this._extrInfo.Ed_GoodsCode == "")
            //    {
            //        end   = "ＥＮＤ";
            //    }
            //    else
            //    {
            //        end = this._extrInfo.Ed_GoodsCode;
            //    }
            //
			//    wkStr = String.Format( "商品コード： {0} ～ {1}", 
			//	start, end );
			//    this.EditCondition( ref allExtractCondition, wkStr );
		    //}
            // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<

            // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
            ////キャリアコード
            //if( ( this._extrInfo.St_CarrierCode != 0 ) || ( this._extrInfo.Ed_CarrierCode != 999 ) ) 
            //{
			//    wkStr = String.Format( "キャリアコード： {0} ～ {1}", 
			//	this._extrInfo.St_CarrierCode.ToString(), this._extrInfo.Ed_CarrierCode.ToString() );
			//    this.EditCondition( ref allExtractCondition, wkStr );
		    //}


            // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
	
			StringCollection wkStrCollection = new StringCollection();
			// 抽出条件1
			this.MakeCondition1( ref wkStrCollection );
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
		/// <br>Date       : 2007.03.16</br>
		/// </remarks>
		private void EditCondition( ref StringCollection editArea, string target )
		{
			bool isEdit = false;
			
			// 編集対象文字バイト数算出
			int targetByte = TStrConv.SizeCountSJIS( target );
			
			for( int ix = 0; ix < editArea.Count; ix++ ) {
				int areaByte = 0;
				
				// 格納エリアのバイト数算出
				if( editArea[ ix ] != null ) {
					areaByte = TStrConv.SizeCountSJIS( editArea[ ix ] );
				}

				if( ( areaByte + targetByte + 2 ) <= 190 ) {
					isEdit = true;

					// 全角スペースを挿入
					if( editArea[ ix ] != null ) {
						editArea[ ix ] += CT_SPACE;
					}
					
					editArea[ ix ] += target;
					break;
				}
			}
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
		/// <br>Date       : 2007.03.22</br>
		/// </remarks>
		private void MakeCondition1( ref StringCollection extraCondition )
		{
            string start = "";
            string end   = "";
			string wkStr = "";

            #region 条件文字列作成処理

            /* --- DEL 2008/10/08 在庫登録日と対象年月の位置変更の為 ------------------------------------------------------>>>>>
            //最終仕入日
            //開始日or終了日が入力されている
            if((this._extrInfo.St_LastStockDate != DateTime.MinValue) || (this._extrInfo.Ed_LastStockDate != DateTime.MinValue))
            {
                 //開始仕入日が入っていない場合
                if(this._extrInfo.St_LastStockDate == DateTime.MinValue)
                {
                    //start = "ＴＯＰ";     // DEL 2008.08.04
                    start = "最初から";     // ADD 2008.08.04
                }
                else
                {                 
                    start = TDateTime.DateTimeToString("YYYY/MM/DD",this._extrInfo.St_LastStockDate);
                }

                if(this._extrInfo.Ed_LastStockDate == DateTime.MinValue)
                {
                    //end = "ＥＮＤ";       // DEL 2008.08.04
                    end = "最後まで";       // ADD 2008.08.04
                }
                else
                {
                    end = TDateTime.DateTimeToString("YYYY/MM/DD",this._extrInfo.Ed_LastStockDate);        
                }
                //wkStr = String.Format("最終仕入日" + "： {0} ～ {1}", start, end);    // DEL 2008.08.01
                wkStr = String.Format("対象年月" + "： {0} ～ {1}", start, end);      // ADD 2008.08.01
                this.EditCondition(ref extraCondition, wkStr);
            }
               --- DEL 2008/10/08 -----------------------------------------------------------------------------------------<<<<< */
            // 倉庫コード
            if ((this._extrInfo.St_WarehouseCode != "") || (this._extrInfo.Ed_WarehouseCode != ""))
            {
                if (this._extrInfo.St_WarehouseCode == "")
                {
                    //start = "ＴＯＰ";     // DEL 2008.08.04
                    start = "最初から";     // ADD 2008.08.04
                }
                else
                {
                    start = this._extrInfo.St_WarehouseCode;
                }
                if (this._extrInfo.Ed_WarehouseCode == "")
                {
                    //end = "ＥＮＤ";       // DEL 2008.08.04
                    end = "最後まで";       // ADD 2008.08.04
                }
                else
                {
                    end = this._extrInfo.Ed_WarehouseCode;
                }

                //wkStr = String.Format("倉庫コード： {0} ～ {1}",      // DEL 2008.08.01
                wkStr = String.Format("倉庫： {0} ～ {1}",              // ADD 2008.08.01
                start, end);
                this.EditCondition(ref extraCondition, wkStr);
            }

            //--- DEL 2008.08.01 ---------->>>>>
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
            //        end = "ＥＮＤ";
            //    }
            //    else
            //    {
            //        end = this._extrInfo.Ed_LargeGoodsGanreCode;
            //    }

            //    wkStr = String.Format( "商品区分グループ： {0} ～ {1}", 
            //    start, end );
            //    this.EditCondition( ref extraCondition, wkStr );
            //}
            //--- DEL 2008.08.01 ----------<<<<<

            //--- DEL 2008.08.01 ---------->>>>>
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
            //        end = "ＥＮＤ";
            //    }
            //    else
            //    {
            //        end = this._extrInfo.Ed_MediumGoodsGanreCode;
            //    }

            //    wkStr = String.Format( "商品区分： {0} ～ {1}", 
            //    start, end );
            //    this.EditCondition( ref extraCondition, wkStr );
            //}
            //--- DEL 2008.08.01 ----------<<<<<

            //--- DEL 2008.08.01 ---------->>>>>
            //// 2008.01.24 修正 >>>>>>>>>>>>>>>>>>>>
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
            //--- DEL 2008.08.01 ----------<<<<<

            //--- DEL 2008.08.01 ---------->>>>>
            ////自社分類コード
            //if ((this._extrInfo.St_EnterpriseGanreCode != 0) || (this._extrInfo.Ed_EnterpriseGanreCode != 9999))
            //{
            //    wkStr = String.Format("自社分類コード： {0} ～ {1}",
            //    this._extrInfo.St_EnterpriseGanreCode.ToString(), this._extrInfo.Ed_EnterpriseGanreCode.ToString());
            //    this.EditCondition(ref extraCondition, wkStr);
            //}
            //--- DEL 2008.08.01 ----------<<<<<

            // 2008.01.24 修正 <<<<<<<<<<<<<<<<<<<<
            /* --- DEL 2008/10/08 大幅変更の為 ---------------------------------------------------------------------------->>>>>
            //--- ADD 2008/08/01 ---------->>>>>
            // 仕入先
            if ((this._extrInfo.St_StockSupplierCode != 0) || (this._extrInfo.Ed_StockSupplierCode != 99999999))
            {
                wkStr = String.Format("仕入先： {0} ～ {1}",
                this._extrInfo.St_StockSupplierCode.ToString(), this._extrInfo.Ed_StockSupplierCode.ToString());
                this.EditCondition(ref extraCondition, wkStr);
            }

            // 倉庫棚番
            if ((this._extrInfo.St_WarehouseShelfNo != string.Empty) || (this._extrInfo.Ed_WarehouseShelfNo != string.Empty))
            {
                wkStr = String.Format("倉庫棚番： {0} ～ {1}",
                this._extrInfo.St_WarehouseShelfNo.ToString(), this._extrInfo.Ed_WarehouseShelfNo.ToString());
                this.EditCondition(ref extraCondition, wkStr);
            }
            //--- ADD 2008/08/01 ----------<<<<<

            //メーカーコード
            // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
            //if ((this._extrInfo.St_MakerCode != 0) || (this._extrInfo.Ed_MakerCode != 999))
            if ((this._extrInfo.St_GoodsMakerCd != 0) || (this._extrInfo.Ed_GoodsMakerCd != 999999))
            // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
            {
                //wkStr = String.Format("メーカーコード： {0} ～ {1}",  // DEL 2008.08.01
                wkStr = String.Format("メーカー： {0} ～ {1}",          // ADD 2008.08.01
                    // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
                    //this._extrInfo.St_MakerCode.ToString(), this._extrInfo.Ed_MakerCode.ToString());
                this._extrInfo.St_GoodsMakerCd.ToString(), this._extrInfo.Ed_GoodsMakerCd.ToString());
                // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
                this.EditCondition(ref extraCondition, wkStr);
            }

            //ＢＬコード
            if ((this._extrInfo.St_BLGoodsCode != 0) || (this._extrInfo.Ed_BLGoodsCode != 99999999))
            {
                wkStr = String.Format("ＢＬコード： {0} ～ {1}",
                this._extrInfo.St_BLGoodsCode.ToString(), this._extrInfo.Ed_BLGoodsCode.ToString());
                this.EditCondition(ref extraCondition, wkStr);
            }
               --- DEL 2008/10/08 -----------------------------------------------------------------------------------------<<<<< */
            // --- ADD 2008/10/08 ----------------------------------------------------------------------------------------->>>>>
            // 仕入先
            //if ((this._extrInfo.St_StockSupplierCode != 0) || (this._extrInfo.Ed_StockSupplierCode != 999999))        //DEL　""とALL9入力の区別をつける必要がある為
            if ((this._extrInfo.St_StockSupplierCode != 0) ||
                ((this._extrInfo.Ed_StockSupplierCode != 0) &&
                 (string.IsNullOrEmpty(this._extrInfo.Ed_StockSupplierCode.ToString()) == false)))
            {
                if (this._extrInfo.St_StockSupplierCode == 0)
                {
                    start = "最初から";
                }
                else
                {
                    start = this._extrInfo.St_StockSupplierCode.ToString("000000");
                }
                //if (this._extrInfo.Ed_StockSupplierCode == 999999)        //DEL　""とALL9入力の区別をつける必要がある為
                if ((this._extrInfo.Ed_StockSupplierCode == 0) || (string.IsNullOrEmpty(this._extrInfo.Ed_StockSupplierCode.ToString()) == true))
                {
                    end = "最後まで";
                }
                else
                {
                    end = this._extrInfo.Ed_StockSupplierCode.ToString("000000");
                }
                wkStr = String.Format("仕入先： {0} ～ {1}", start, end);
                this.EditCondition(ref extraCondition, wkStr);
            }

            // 倉庫棚番
            if ((this._extrInfo.St_WarehouseShelfNo != string.Empty) || (this._extrInfo.Ed_WarehouseShelfNo != string.Empty))
            {
                if (this._extrInfo.St_WarehouseShelfNo == string.Empty)
                {
                    start = "最初から";
                }
                else
                {
                    start = this._extrInfo.St_WarehouseShelfNo.ToString();
                }
                if (this._extrInfo.Ed_WarehouseShelfNo == string.Empty)
                {
                    end = "最後まで";
                }
                else
                {
                    end = this._extrInfo.Ed_WarehouseShelfNo.ToString();
                }
                wkStr = String.Format("倉庫棚番： {0} ～ {1}", start, end);
                this.EditCondition(ref extraCondition, wkStr);
            }

            //メーカーコード
            //if ((this._extrInfo.St_GoodsMakerCd != 0) || (this._extrInfo.Ed_GoodsMakerCd != 9999))    //DEL　""とALL9入力の区別をつける必要がある為
            if ((this._extrInfo.St_GoodsMakerCd != 0) ||
                ((this._extrInfo.Ed_GoodsMakerCd != 0) &&
                 (string.IsNullOrEmpty(this._extrInfo.Ed_GoodsMakerCd.ToString()) == false)))
            {
                if (this._extrInfo.St_GoodsMakerCd == 0)
                {
                    start = "最初から";
                }
                else
                {
                    start = this._extrInfo.St_GoodsMakerCd.ToString("0000");
                }
                //if (this._extrInfo.Ed_GoodsMakerCd == 9999)           //DEL　""とALL9入力の区別をつける必要がある為
                if ((this._extrInfo.Ed_GoodsMakerCd == 0) || (string.IsNullOrEmpty(this._extrInfo.Ed_GoodsMakerCd.ToString()) == true))
                {
                    end = "最後まで";
                }
                else
                {
                    end = this._extrInfo.Ed_GoodsMakerCd.ToString("0000");
                }
                wkStr = String.Format("メーカー： {0} ～ {1}", start, end);
                this.EditCondition(ref extraCondition, wkStr);
            }

            //ＢＬコード
            //if ((this._extrInfo.St_BLGoodsCode != 0) || (this._extrInfo.Ed_BLGoodsCode != 99999))     //DEL　""とALL9入力の区別をつける必要がある為
            if ((this._extrInfo.St_BLGoodsCode != 0) ||
                ((this._extrInfo.Ed_BLGoodsCode != 0) &&
                 (string.IsNullOrEmpty(this._extrInfo.Ed_BLGoodsCode.ToString()) == false)))
            {
                if (this._extrInfo.St_BLGoodsCode == 0)
                {
                    start = "最初から";
                }
                else
                {
                    start = this._extrInfo.St_BLGoodsCode.ToString("00000");
                }
                //if (this._extrInfo.Ed_BLGoodsCode == 99999)           //DEL　""とALL9入力の区別をつける必要がある為
                if ((this._extrInfo.Ed_BLGoodsCode == 0) || (string.IsNullOrEmpty(this._extrInfo.Ed_BLGoodsCode.ToString()) == true))
                {
                    end = "最後まで";
                }
                else
                {
                    end = this._extrInfo.Ed_BLGoodsCode.ToString("00000");
                }
                wkStr = String.Format("ＢＬコード： {0} ～ {1}", start, end);
                this.EditCondition(ref extraCondition, wkStr);
            }
            // --- ADD 2008/10/08 -----------------------------------------------------------------------------------------<<<<<

            if ((this._extrInfo.St_GoodsNo != "") || (this._extrInfo.Ed_GoodsNo != ""))
            {
                if (this._extrInfo.St_GoodsNo == "")
                {
                    //start = "ＴＯＰ";     // DEL 2008.08.04
                    start = "最初から";     // ADD 2008.08.04
                }
                else
                {
                    start = this._extrInfo.St_GoodsNo;
                }
                if (this._extrInfo.Ed_GoodsNo == "")
                {
                    //end = "ＥＮＤ";       // DEL 2008.08.04
                    end = "最後まで";       // ADD 2008.08.04
                }
                else
                {
                    end = this._extrInfo.Ed_GoodsNo;
                }

                //wkStr = String.Format("商品コード： {0} ～ {1}",      // DEL 2008.08.01
                wkStr = String.Format("品番： {0} ～ {1}",              // ADD 2008.08.01
                start, end);
                this.EditCondition(ref extraCondition, wkStr);
            }

            //--- DEL 2008/08/01 ---------->>>>>
            //wkStr = "在庫区分： ";
            ////在庫区分
            //switch(this._extrInfo.StockDiv)
            //{
                
            //    //全て
            //    case (int)StockListCndtn.StockDivStatus.StockDiv_ALLStock:
            //    {
            //        wkStr += StockListCndtn.GetStockDivName((int)StockListCndtn.StockDivStatus.StockDiv_ALLStock);
            //        break;
            //    }
            //    //仕入在庫分
            //    case (int)StockListCndtn.StockDivStatus.StockDiv_MyStock:
            //    {
            //        wkStr += StockListCndtn.GetStockDivName((int)StockListCndtn.StockDivStatus.StockDiv_MyStock);
            //        break;
            //    }
            //    //受託在庫分
            //    case (int)StockListCndtn.StockDivStatus.StockDiv_TrustStock:
            //    {
            //        wkStr += StockListCndtn.GetStockDivName((int)StockListCndtn.StockDivStatus.StockDiv_TrustStock);
            //        break;
            //    }
                                  
            //}
            //this.EditCondition( ref extraCondition, wkStr );
            //--- DEL 2008/08/01 ----------<<<<<
                     
            #endregion
        }
	    

		/// <summary>
		/// ソート順文字列作成処理
		/// </summary>
		/// <returns>ソート順文字列</returns>
		/// <remarks>
		/// <br>Note       : ソート順文字列を作成します。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2007.03.22</br>
		/// </remarks>
		private string MakeSortCondition()
		{
			return "[" + StockListCndtn.GetSortName(this._extrInfo.ChangePageDiv) + "]";
		}

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
		/// <br>Date       : 2007.03.16</br>
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
		/// <br>Date       : 2007.03.16</br>
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

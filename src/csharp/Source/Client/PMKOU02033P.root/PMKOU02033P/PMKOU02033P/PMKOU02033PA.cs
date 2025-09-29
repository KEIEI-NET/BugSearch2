using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Drawing.Printing;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Text;
using Broadleaf.Application.Resources;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 仕入先元帳印刷クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 仕入先元帳の印刷を行います。</br>
	/// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2007.11.26</br>
	/// </remarks>
	public class PMKOU02033PA
	{
		//================================================================================
		//  コンストラクター
		//================================================================================
		#region コンストラクター
		/// <summary>
		/// 仕入先元帳印刷クラスコンストラクタ
		/// </summary>
		/// <param name="printInfo">印刷情報オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 仕入先元帳印刷クラスの初期化を行い新しいインスタンスを生成します。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.11.26</br>
		/// </remarks>
		public PMKOU02033PA()
		{
		}
		/// <summary>
		/// 仕入先元帳印刷クラスコンストラクタ(オーバーロード +1)
		/// </summary>
		/// <param name="printInfo">印刷情報オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 仕入先元帳印刷クラスの初期化を行い新しいインスタンスを生成します。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.11.26</br>
		/// </remarks>
		public PMKOU02033PA(object printInfo)
		{
			this._printInfo = printInfo as SFCMN06002C;
            this._supplierLedgerAcs = new SupplierLedgerAcs();
			this._ledgerCmnCndtn     = this._printInfo.jyoken as LedgerCmnCndtn;
			this._pdfHistoryControl = new Broadleaf.Windows.Forms.SFANL06101UA();
			this._sfcmn00331c       = new SFCMN00331C();

			if (LoginInfoAcquisition.Employee != null)
			{
				this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd();
			}
		}
		#endregion

		//================================================================================
		//  内部定数
		//================================================================================
		#region private constant
		private const string CT_REPORTFORM_NAMESPASE = "Broadleaf.Drawing.Printing";
		private const string CT_ITEM_INTERVAL        = "　　　　　";
		#endregion
		
		//================================================================================
		//  内部変数
		//================================================================================
		#region private member    
		private SFCMN06002C _printInfo;

        private SupplierLedgerAcs _supplierLedgerAcs = null;
		private LedgerCmnCndtn _ledgerCmnCndtn         = null;
		private Broadleaf.Windows.Forms.SFANL06101UA _pdfHistoryControl = null;
		
		private SFCMN00331C _sfcmn00331c             = null;

		private string _loginSectionCode = "";		// ログイン拠点コード	
		#endregion
	
		//================================================================================
		//  外部提供プロパティ
		//================================================================================
		#region public property
		#region IPrintProcの実装部(プロパティ) 
		/// <summary>印刷データ</summary>
		/// <value>印刷するデータを取得または設定します。</value>
		public SFCMN06002C Printinfo
		{
			get { return _printInfo; }
			set { _printInfo = value; }
		}
		#endregion
		#endregion
	
		// ===============================================================================
		// 例外クラス
		// ===============================================================================
		#region 例外クラス
		private class DemandPrintException: ApplicationException
		{
			private int _status;

			#region constructor
			public DemandPrintException(string message, int status): base(message)
			{
				this._status = status; 
			}
			#endregion
    
			#region public property
			public int Status
			{
				get{return this._status;}
			}
			#endregion
		}
		#endregion
		
		//================================================================================
		//  IPrintProcの実装部　印刷メイン処理
		//================================================================================
		#region IPrintProcの実装部
		/// <summary>
		/// 印刷開始処理
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : 印刷の開始処理を行います。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
		public int StartPrint()
		{
			return this.PrintMain();
		}
		#endregion

		/// <summary>
		/// 印刷メイン処理
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : 印刷のメイン処理を行います。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.11.26</br>
		/// </remarks>
		private int PrintMain()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			string message = "";
			try
			{
				// 印刷フォームクラスインスタンス作成
				DataDynamics.ActiveReports.ActiveReport3 prtRpt;

				// レポートインスタンス作成
				this.CreateReport(out prtRpt, this._printInfo.prpid); 
				if (prtRpt == null) return status;

				// 各種プロパティ設定
				status = this.SettingProperty(ref prtRpt, out message);
				if (status != 0)
				{
					TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
						message, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
					return status;
				}

				// 印刷データ取得
				DataView dv = (DataView)this._printInfo.rdData;
				// ソート順設定
				dv.Sort = this.GetPrintOderQuerry();
				
				// データソース設定
				prtRpt.DataSource = dv;

				// 印刷共通情報プロパティ設定
				Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
				this.SetPrintCommonInfo(out commonInfo);

				// プレビュー有無				
				int prevkbn = this._printInfo.prevkbn;
				
				// 出力モードがＰＤＦの場合、無条件でプレビュー無
				if (this._printInfo.printmode == 2)
				{
					prevkbn = 0;
				}
				
				switch(prevkbn)
				{
					case 0:		// プレビュ無
					{
						Broadleaf.Windows.Forms.SFCMN00293UB processForm = new Broadleaf.Windows.Forms.SFCMN00293UB();
						
						// 共通条件設定
						processForm.CommonInfo = commonInfo;

						// プログレスバーUPイベント追加
						if (prtRpt is IPrintActiveReportTypeCommon)
						{
							((IPrintActiveReportTypeCommon)prtRpt).ProgressBarUpEvent +=
								new ProgressBarUpEventHandler(processForm.ProgressBarUpEvent);
						}

						// 印刷実行
						status = processForm.Run(prtRpt);

						// 戻り値設定
						this._printInfo.status = status;

						break;
					}
					case 1:		// プレビュ有
					{
						Broadleaf.Windows.Forms.SFCMN00293UA viewForm = new Broadleaf.Windows.Forms.SFCMN00293UA();

						// 共通条件設定
						viewForm.CommonInfo   = commonInfo;

						// プレビュー実行
						status = viewForm.Run(prtRpt); 

						// 戻り値設定
						this._printInfo.status = status;
						
						break;
					}
				}

#if true				
				// ＰＤＦ出力の場合
				if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
				{
					switch (this._printInfo.printmode)
					{
						case 1:		// プリンタ
							break;
						case 2:		// ＰＤＦ
						case 3:		// 両方(プリンタ + ＰＤＦ)
						{
							// ＰＤＦ表示フラグON
							this._printInfo.pdfopen = true;
							
							// 両方印刷時のみ履歴保存
							if (this._printInfo.printmode == 3)
							{
								// 出力履歴管理に追加
								Broadleaf.Windows.Forms.SFANL06101UA pdfHistoryControl = new Broadleaf.Windows.Forms.SFANL06101UA();
								pdfHistoryControl.AddPrintInfo(this._printInfo.key, this._printInfo.prpnm, this._printInfo.prpnm,
									this._printInfo.pdftemppath);
							}
							break;
						}
					}
				}
#else
				if (this._printInfo.printmode != 1 && status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
				{
					// 出力履歴管理に追加
					Broadleaf.Windows.Forms.SFANL06101UA pdfHistoryControl = new Broadleaf.Windows.Forms.SFANL06101UA();
					pdfHistoryControl.AddPrintInfo(this._printInfo.key, this._printInfo.prpnm, this._printInfo.prpnm,
						this._printInfo.pdftemppath);

					// PDF表示フラグON
					this._printInfo.pdfopen = true;
				}
#endif

			}
			catch(Exception ex)
			{
				TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
					ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			}

			return status;
		}
	
		/// <summary>
		/// 各種ActiveReport帳票インスタンス作成
		/// </summary>
		/// <param name="rptObj">インスタンス化された帳票フォームクラス</param>
		/// <param name="prpid">帳票フォームID</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
		private void CreateReport(out DataDynamics.ActiveReports.ActiveReport3 rptObj,string prpid)
		{
			// 印刷フォームクラスインスタンス作成
			rptObj = (DataDynamics.ActiveReports.ActiveReport3)this.LoadAssemblyReport(
				prpid.Trim(), CT_REPORTFORM_NAMESPASE + "." + prpid.Trim(), 
				typeof(DataDynamics.ActiveReports.ActiveReport3));
		}

		/// <summary>
		/// 指定されたアセンブリ及びクラス名より、クラスをインスタンス化する
		/// </summary>
		/// <param name="asmname">アセンブリ名称</param>
		/// <param name="classname">クラス名称</param>
		/// <param name="type">実装するクラス型</param>
		/// <returns>インスタンス化されたクラス</returns>
		/// <remarks>
		/// <br>Note       : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
		private	object LoadAssemblyReport(string asmname, string classname, Type type)
		{
			object	obj	= null;
			try
			{
				System.Reflection.Assembly	asm	= System.Reflection.Assembly.Load(asmname);
				Type	objType	= asm.GetType(classname);
				if (objType != null)
				{
					if ((objType == type) || (objType.IsSubclassOf(type) == true) || (objType.GetInterface(type.Name).Name == type.Name))
					{
						obj = Activator.CreateInstance(objType);
					}
				}
			}
			catch(System.IO.FileNotFoundException)
			{
				throw new DemandPrintException(asmname + "が存在しません。",-1);
			}
			catch(System.Exception er)
			{
				throw new DemandPrintException(er.Message, -1);
			}
			return obj;
		}
	
		/// <summary>
		/// 各種プロパティ設定
		/// </summary>
		/// <param name="rpt">インスタンス化された帳票フォームクラス</param>
		/// <param name="message">エラーメッセージ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 各種プロパティを設定します。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.11.26</br>
		/// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt, out string message)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			message = "";

			try
			{
				// ActiveReportインターフェースにキャスト
				IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

				// 印刷条件取得
				LedgerCmnCndtn extraInfo = (LedgerCmnCndtn)this._printInfo.jyoken;

				// ソート順プロパティ設定
				string wrkstr = "";
				switch (extraInfo.PrintOder)
				{
					case 0:
						wrkstr = "[得意先コード順]";
						break;
					case 1:
						wrkstr = "[得意先カナ順]";
						break;
					case 2:
						wrkstr = "[担当者→得意先コード順]";
						break;
					case 3:
						wrkstr = "[担当者→得意先カナ順]";
						break;
					default:
						break;
				}
				instance.PageHeaderSortOderTitle = wrkstr;

				// サブタイトル
				string subTitle = "";
				switch (extraInfo.ListDivCode)
				{
					case 0:
						subTitle = "支払残";
						break;
					case 1:
						subTitle = "買掛残";
						break;
					default:
						break;
				}
				instance.PageHeaderSubtitle = subTitle;


				// 帳票出力設定情報取得 
				PrtOutSet prtOutSet;
				status = this._supplierLedgerAcs.ReadPrtOutSet(out prtOutSet, out message);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
						{
							break;
						}
					default:
						{
							return status;
						}
				}
				// 抽出条件ヘッダ出力区分
				instance.ExtraCondHeadOutDiv = prtOutSet.ExtraCondHeadOutDiv;

				// フッタ出力区分
				instance.PageFooterOutCode = prtOutSet.FooterPrintOutCode;

				// フッタ出力メッセージ
				StringCollection footers = new StringCollection();
				footers.Add(prtOutSet.PrintFooter1);
				footers.Add(prtOutSet.PrintFooter2);

				instance.PageFooters = footers;

				// その他関連データ設定
				ArrayList otherDataList = new ArrayList();

				// 拠点情報印字有無判定
				bool isSectionPrint = true;
				bool isSectionTitlePrint = false;

				// 拠点オプションあり
				if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0)
				{
					isSectionPrint = this.CheackSectionNamePrint(extraInfo);
					isSectionTitlePrint = true;	
				}
				// 拠点オプションなし
				else
				{
					isSectionPrint = false;
					isSectionTitlePrint = false;
				}

				otherDataList.Add(isSectionPrint);
				otherDataList.Add(isSectionTitlePrint);

				// 全体項目表示設定の取得
                AlItmDspNm alItmDspNm = this._supplierLedgerAcs.GetAlItmDspNm(this._printInfo.enterpriseCode);
				otherDataList.Add(alItmDspNm);

				instance.OtherDataList = otherDataList;

				// 印刷情報オブジェクト
				instance.PrintInfo = this._printInfo;

				status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			}
			catch (Exception ex)
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
				message = ex.Message;
			}

			return status;
		}
	
		/// <summary>
		/// 印字順クエリ作成処理
		/// </summary>
		/// <returns>作成したクエリ</returns>
		/// <remarks>
		/// <br>Note       : DataViewに設定する印字順位のクエリを作成します。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.11.26</br>
		/// </remarks>
		private string GetPrintOderQuerry()
		{
			string oderQuerry = "";		
		
			// 印字順設定
			switch (this._ledgerCmnCndtn.PrintOder)
			{
				// 得意先コード順(拠点コード,得意先コード)
				case 0: 
				{//拠点、支払先、締日順、仕入先、日付、伝票番号順																																				

                    oderQuerry = SupplierLedgerAcs.COL_Spl_AddUpSecCode + "," +
                        //SupplierLedgerAcs.COL_Spl_CustomerCode + "," + 
                        SupplierLedgerAcs.COL_Spl_SupplierCd + "," +
                        SupplierLedgerAcs.COL_Spl_PayeeCode;
                        //SupplierLedgerAcs.COL_Spl_TotalDay + ",";
					break;
				}
				// 得意先カナ順(拠点コード,得意先カナ,得意先コード)
				case 1: 
				{
                    oderQuerry = SupplierLedgerAcs.COL_Spl_AddUpSecCode + "," +
                        //SupplierLedgerAcs.COL_Spl_Kana + "," +
                        SupplierLedgerAcs.COL_Spl_PayeeCode;
                        //SupplierLedgerAcs.COL_Spl_CustomerCode;
					break;
				}
			}
		
			return oderQuerry;
		}
		
		/// <summary>
		/// 印刷画面共通情報設定
		/// </summary>
		/// <param name="commonInfo"></param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 印刷画面共通条件の設定を行います。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
		private void SetPrintCommonInfo(out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo)
		{
			commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();
		
			// プリンタ名
			commonInfo.PrinterName = this._printInfo.prinm;
			
			// 帳票名
			commonInfo.PrintName   = this._printInfo.prpnm;				
			
			// 印刷モード
			commonInfo.PrintMode   = this.Printinfo.printmode;
			
			// 印刷件数
			commonInfo.PrintMax    = ((DataView)this._printInfo.rdData).Count;
			
			// PDF出力フルパス
			string pdfPath = "";
			string pdfName = "";
			this._sfcmn00331c.GetPdfSavePathName(this._printInfo.prpnm, ref pdfPath, ref pdfName);
			
			string pdfFileName     = System.IO.Path.Combine(pdfPath,pdfName);
			commonInfo.PdfFullPath = pdfFileName;
			this._printInfo.pdftemppath = pdfFileName;
			
			// 上余白
			commonInfo.MarginsTop  = this._printInfo.py;
			
			// 左余白
			commonInfo.MarginsLeft = this._printInfo.px;
		}
		
		/// <summary>
		/// 拠点名称印字有無チェック処理
		/// </summary>
		/// <param name="extraInfo">抽出条件データクラス</param>
		/// <remarks>
		/// <br>Note       : 拠点タイトル、拠点名称を印字するかどうかを判定します。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.11.26</br>
		/// </remarks>
		private bool CheackSectionNamePrint(LedgerCmnCndtn extraInfo)
		{
			bool result = false;
            /*
			// 本社機能 & 「全社」が選択されている場合
			if (this._supplierLedgerAcs.CheckMainOfficeFunc(this._loginSectionCode) && extraInfo.AddUpSecCode.Equals(CsLedgerDmdAcs.CT_AllSectionCode))
			{
				result = true;
			}
			*/
			return result;
		}
		
		/// <summary>
		/// メッセージ表示
		/// </summary>
		/// <param name="iLevel">エラーレベル</param>
		/// <param name="iMsg">エラーメッセージ</param>
		/// <param name="iSt">ステータス</param>
		/// <param name="iButton">表示ボタン</param>
		/// <param name="iDefButton">デフォルトフォーカスボタン</param>
		/// <returns>DialogResult</returns>
		/// <remarks>
		/// <br>Note       : 出力件数の設定を行います。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
		private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "PMKOU02033P", iMsg, iSt, iButton, iDefButton);
		}
	
	
	
	
	}
}

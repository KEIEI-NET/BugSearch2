#define  CHG20060417
using System;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Specialized;


using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows; 
using Broadleaf.Application.Common;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 棚卸過不足更新エラーリスト印刷クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 棚卸過不足更新エラーリストの印刷を行います。</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2007.07.19</br>
	/// </remarks>
	public class MAZAI05167PA
	{
		//================================================================================
		//  コンストラクター
		//================================================================================
		#region コンストラクター
		public MAZAI05167PA()
		{
		}
		/// <summary>
		/// 棚卸過不足更新エラーリスト印刷クラスコンストラクタ(オーバーロード +1)
		/// </summary>
		/// <param name="printInfo">印刷情報オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 棚卸過不足更新エラーリスト印刷クラスの初期化を行い新しいインスタンスを生成します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.07.19</br>
		/// </remarks>
		public MAZAI05167PA(object printInfo)
		{
			this._printInfo       = printInfo as SFCMN06002C;
		}
		#endregion
	
		//================================================================================
		//  内部定数
		//================================================================================
		#region private constant
		private const string CT_REPORTFORM_NAMESPASE = "Broadleaf.Drawing.Printing";
		private const string CT_ASSEMBLY_ID = "MAZAI05167P";
		#endregion
	
		//================================================================================
		//  内部変数
		//================================================================================
		#region private member    
		private SFCMN06002C _printInfo               = null;
		private PrtOutSetAcs _prtOutSetAcs;
		#endregion
	
		//================================================================================
		//  IPrintProcのメンバ
		//================================================================================
		#region IPrintProc メンバ
		public SFCMN06002C Printinfo
		{
			get
			{
				return this._printInfo;
			}
			set
			{
				this._printInfo = value;
			}
		}
		#endregion
	
		// ===============================================================================
		// 例外クラス
		// ===============================================================================
		#region 例外クラス
		private class InventoryErrorDataPrintException: ApplicationException
		{
			private int _status;

			#region constructor
			public InventoryErrorDataPrintException(string message, int status)
				: base(message)
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
		/// 印刷メイン処理
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : 印刷のメイン処理を行います。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.07.19</br>
		/// </remarks>
		public int StartPrint()
		{
			return this.PrintMain();
		}
		#endregion
		
		//================================================================================
		//  内部処理
		//================================================================================
		#region private method        
		/// <summary>
		/// 印刷メイン処理
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : 印刷のメイン処理を行います。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.07.19</br>
		/// </remarks>
		private int PrintMain()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			DataDynamics.ActiveReports.ActiveReport3 prtRpt = null;
			
			try
			{
				// 印刷用DataSetの取得
				InventoryUpdateDataSet.ErrorDataDataTable dt = (InventoryUpdateDataSet.ErrorDataDataTable)this._printInfo.rdData;
				
				// 印刷用DataViewの作成
				DataView dv = dt.DefaultView;

				// レポートインスタンスの作成
				this.CreateReport(out prtRpt, this._printInfo.prpid);
				if (prtRpt == null) return status;

				// 各種プロパティ設定
				status = this.SettingProperty(ref prtRpt);
				if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL) return status;

				// 背景画像有無設定
				if (prtRpt is IPrintActiveReportTypeCommon)
				{
					((IPrintActiveReportTypeCommon)prtRpt).WatermarkMode  = 0;
				}
					
				// データソース設定
				prtRpt.DataSource  = dv;
					
				// 印刷共通情報プロパティ設定
				Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
				this.SetPrintCommonInfo(out commonInfo);

				// 印刷件数設定
				commonInfo.PrintMax = dv.Count; 
					
				// プレビュー有無				
				int prevkbn = this._printInfo.prevkbn;
				
				// 出力モードがＰＤＦの場合、無条件でプレビュー無
				if (this._printInfo.printmode == 2)
				{
					prevkbn = 0;
				}

				switch (prevkbn)
				{
					case 0:		// プレビューなし
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
						status = processForm.Run(prtRpt,true);

						// 戻り値設定
						this._printInfo.status = status;

						break;
					}
					case 1:		// プレビューあり
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
					default:
						break;
				}
				
				// ＰＤＦ出力の場合
				if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
				{
					switch (this._printInfo.printmode)
					{
						case 1:  // プリンタ
							break;
						case 2:  // ＰＤＦ
						case 3:  // 両方(プリンタ + ＰＤＦ)
						{
#if false		// 今のところＰＤＦ出力は無

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
#endif
							break;
						}
					}
				}

				status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			}
			catch (InventoryErrorDataPrintException ex)
			{
				TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message ,
					-1, MessageBoxButtons.OKCancel,MessageBoxDefaultButton.Button1);
			}
			catch (Exception ex)
			{
				TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message + "\n\r" + ex.StackTrace,
					-1, MessageBoxButtons.OKCancel,MessageBoxDefaultButton.Button1);
			}
			finally
			{
				if ( prtRpt != null ){ prtRpt.Dispose(); }
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
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.07.19</br>
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
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.07.19</br>
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
				else 
				{
					throw new InventoryErrorDataPrintException(classname + "が存在しません。",-1);				
				}
			}
			catch(System.IO.FileNotFoundException)
			{
				throw new InventoryErrorDataPrintException(asmname + "が存在しません。",-1);
			}
			catch(System.Exception er)
			{
				throw new InventoryErrorDataPrintException(er.Message, -1);
			}
			return obj;
		}

		/// <summary>
		/// 各種プロパティ設定
		/// </summary>
		/// <param name="rpt">インスタンス化された帳票フォームクラス</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 各種プロパティを設定します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.07.19</br>
		/// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// ActiveReportインターフェースにキャスト
			IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

			// ソート順プロパティ設定
			instance.PageHeaderSortOderTitle = "";

			// 帳票出力設定情報取得 
			PrtOutSet prtOutSet = null;
			try
			{
				//string message;
				this._prtOutSetAcs = new PrtOutSetAcs();
				string sectionCode = string.Empty;

				if (LoginInfoAcquisition.Employee != null)
					sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

				status = this._prtOutSetAcs.Read(out prtOutSet, LoginInfoAcquisition.EnterpriseCode, sectionCode);
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
							throw new InventoryErrorDataPrintException("帳票出力設定の読込時に例外が発生しました。", status);
						}
				}
			}
			catch (Exception)
			{
			}

			// 抽出条件ヘッダ出力区分
			if (prtOutSet != null)
				instance.ExtraCondHeadOutDiv = prtOutSet.ExtraCondHeadOutDiv;

			// フッタ出力区分
			if (prtOutSet != null)
				instance.PageFooterOutCode = prtOutSet.FooterPrintOutCode;

			// フッタ出力メッセージ
			StringCollection footers = new StringCollection();
			
			if (prtOutSet != null)
			{
				footers.Add(prtOutSet.PrintFooter1);
				footers.Add(prtOutSet.PrintFooter2);
			}

			instance.PageFooters = footers;

			// 印刷情報オブジェクト
			instance.PrintInfo = this._printInfo;

			// その他データ

			// 拠点オプション有無チェック
			bool isSection = false;
			if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0)
			{
				isSection = true;
			}

			ArrayList otherData = new ArrayList();
			otherData.Add(isSection);

			instance.OtherDataList = otherData;

			status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			return status;
		}

		
		/// <summary>
		/// 印刷画面共通情報設定
		/// </summary>
		/// <param name="commonInfo"></param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 印刷画面共通条件の設定を行います。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.07.19</br>
		/// </remarks>
		private void SetPrintCommonInfo(out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo)
		{
			commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();
		
			// プリンタ名
			commonInfo.PrinterName = this._printInfo.prinm;
			
			// 帳票名
			commonInfo.PrintName   = this._printInfo.prpnm;				
				
			// 印刷モード
			commonInfo.PrintMode   = this._printInfo.printmode;
			
			// 余白設定
			// 桁位置
			commonInfo.MarginsLeft = this.Printinfo.px;
			
			// 行位置
			commonInfo.MarginsTop  = this.Printinfo.py;

			// 帳票フォームID
			commonInfo.OutputFormID = this._printInfo.prpid;

			// 印字位置調整
			commonInfo.PrintPositionAdjust = 0;
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
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.07.19</br>
		/// </remarks>
		private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, CT_ASSEMBLY_ID, iMsg, iSt, iButton, iDefButton);
		}
		#endregion
		
	}
}

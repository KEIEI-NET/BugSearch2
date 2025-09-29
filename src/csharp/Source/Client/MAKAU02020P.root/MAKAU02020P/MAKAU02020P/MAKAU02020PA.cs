#define CHG20060329
#define CHG20060410
#define CHG20060418
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

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 請求書一覧印刷クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 請求書一覧の印刷を行います。</br>
    /// <br>Programmer : 980023 飯谷 耕平</br>
    /// <br>Date       : 2007.06.19</br>
    /// <br>Update Note: 20081 疋田 勇人
    /// <br>           : 2007.10.15 DC.NS用に変更</br> 
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : PM.NS対応</br>
    /// <br>Programmer : 犬飼</br>
    /// <br>Date	   : 2008.09.04</br>
    /// <br></br> 
    /// <br>UpdateNote : 2011/04/07  22018 鈴木 正臣</br>
    /// <br>           : フォントサイズを大きくする為に、印字桁制御を追加。</br>
    /// </remarks>
	public class MAKAU02020PA: ICustomTextWriter
	{
		//================================================================================
		//  コンストラクター
		//================================================================================
		#region コンストラクター
		/// <summary>
		/// 請求書一覧印刷クラスコンストラクタ
		/// </summary>
		/// <param name="printInfo">印刷情報オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 請求書一覧印刷クラスの初期化を行い新しいインスタンスを生成します。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.19</br>
        /// </remarks>
		public MAKAU02020PA()
		{
		}
		/// <summary>
		/// 請求書一覧印刷クラスコンストラクタ(オーバーロード +1)
		/// </summary>
		/// <param name="printInfo">印刷情報オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 請求書一覧印刷クラスの初期化を行い新しいインスタンスを生成します。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.19</br>
        /// </remarks>
		public MAKAU02020PA(object printInfo)
		{
			this._printInfo         = printInfo as SFCMN06002C;
            this._demandExtraInfo = this._printInfo.jyoken as ExtrInfo_DemandTotal;
			
			this._demandPrintAcs    = new DemandPrintAcs();
			this._pdfHistoryControl = new PdfHistoryControl();
			this._sfcmn00331C       = new SFCMN00331C();

			// テキスト出力部品のインスタンス化
			this._customTextWriter = new CustomTextWriter();				// 2006.08.31 Y.Sasaki ADD
		}
		#endregion

		//================================================================================
		//  内部定数
		//================================================================================
		#region private constant
		private const string CT_REPORTFORM_NAMESPASE = "Broadleaf.Drawing.Printing";
		// 2008.10.17 30413 犬飼 抽出条件項目間を全角スペースに変更 >>>>>>START
        //private const string CT_ITEM_INTERVAL        = "　　　　　";
        private const string CT_ITEM_INTERVAL = "　";
        // 2008.10.17 30413 犬飼 抽出条件項目間を全角スペースに変更 <<<<<<END
        #endregion
		
		//================================================================================
		//  内部変数
		//================================================================================
		#region private member    
		private SFCMN06002C     _printInfo           = null;
		private ExtrInfo_DemandTotal _demandExtraInfo     = null;
		private DemandPrintAcs _demandPrintAcs       = null;
		private PdfHistoryControl _pdfHistoryControl = null;
		private SFCMN00331C _sfcmn00331C             = null;			// 帳票系共通部品
		private CustomTextWriter _customTextWriter = null;				// テキスト出力部品 2006.08.31 Y.Sasaki ADD
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
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.19</br>
        /// </remarks>
		public int StartPrint()
		{
			return this.PrintMain();
		}
		#endregion

		//================================================================================
		//  ICustomTextWriter実装部　テキスト出力処理
		//================================================================================
		#region ICustomTextWriter メンバ

		/// <summary>
		/// テキスト出力設定情報取得
		/// </summary>
		/// <param name="schemaPath">スキーマファイルパス</param>
		/// <param name="customTextProviderInfo">テキスト出力設定情報</param>
		/// <returns>処理結果 0:処理成功, 4:対象データなし, -9:出力対象外のデータが指定された, -1:その他エラー</returns>
		/// <remarks>
		/// <remarks>
		/// <br>Note       : </br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.19</br>
        /// </remarks>
		public int GetCustomTextDefInfo(string schemaPath, out Broadleaf.Library.Text.CustomTextProviderInfo customTextProviderInfo)
		{
			customTextProviderInfo = _customTextWriter.GetCustomTextProviderInfo(schemaPath);
			return 0;
		}

		/// <summary>
		/// テキスト出力処理
		/// </summary>
		/// <param name="source">出力対象データ</param>
		/// <param name="schemaPath">スキーマパス</param>
		/// <param name="outputFilePath">出力パス</param>
		/// <param name="customTextProviderInfo">テキスト出力設定情報</param>
		/// <returns>処理結果 0:処理成功, 4:対象データなし, -9:出力対象外のデータが指定された, -1:その他エラー</returns>
		/// <remarks>
		/// <br>Note       : </br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.19</br>
        /// </remarks>
		public int MakeCustomText(object source, string schemaPath, string outputFilePath, ref Broadleaf.Library.Text.CustomTextProviderInfo customTextProviderInfo)
		{
			//// スキーマファイル作成を行う場合は、以下のロジックを復活させてください
			//// スキーマファイル作成サンプル
			//DataSet ds = this._demandPrintAcs.DemandDataSet;
			//CustomTextTool.DataSetToXMLSchema(ds, "MAKAU02020P_S.xml");

			// >>>>> 2006.10.04 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
			// 出力順を設定
			// 印刷データ取得
			DataView dv = source as DataView;
			// ソート順設定
			dv.Sort = this.GetPrintOderQuerry();
			// <<<<< 2006.10.04 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
			
			// テキスト出力実行 ⇒ 出力データ、スキーマファイル名(=帳票ID)、出力パス、上書きモード
			return _customTextWriter.WriteText(source, schemaPath, outputFilePath, _printInfo.overWriteFlag);

			// ※参考 こちらのロジックでもテキスト出力は可能です()
			//return _customTextWriter.WriteText(_printInfo.rdData, _printInfo.schemaFilePath, _printInfo.outPutFilePathName, _printInfo.overWriteFlag);
		}

		#endregion		
		//================================================================================
		// 内部関数
		//================================================================================
		#region Private Methods
		#region ◆　印刷メイン処理
		/// <summary>
		/// 印刷メイン処理
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : 印刷のメイン処理を行います。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.19</br>
        /// </remarks>
		private int PrintMain()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			try
			{
				// 印刷フォームクラスインスタンス作成
				DataDynamics.ActiveReports.ActiveReport3 prtRpt;

				// レポートインスタンス作成
				this.CreateReport(out prtRpt, this._printInfo.prpid); 
				if (prtRpt == null) return status;

				// 各種プロパティ設定
				status = this.SettingProperty(ref prtRpt);
				if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL) return status;

                // --- ADD m.suzuki 2011/04/07 ---------->>>>>
                PMCMN02000CA reportCtrl = PMCMN02000CA.GetInstance();
                reportCtrl.SetReportProps( ref prtRpt, PMCMN02000CA.SetReportPropsKind.NormalList );
                // --- ADD m.suzuki 2011/04/07 ----------<<<<<

				// 印刷データ取得
				DataView dv = (DataView)this._printInfo.rdData;

                // 請求内訳によるフィルター設定
                if (this._demandExtraInfo.DmdDtl == 0)
                {
                    // 請求内訳が両方
                    dv.RowFilter = this.SelectTotalRecordOnlyFilter(dv.RowFilter);
                }

				// ソート順設定
				dv.Sort = this.GetPrintOderQuerry();
				
				// データソース設定
				prtRpt.DataSource = dv;

				// 印刷共通情報プロパティ設定
				Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
				this.SetPrintCommonInfo(out commonInfo);

#if CHG20060418
				// プレビュー有無				
				int prevkbn = this._printInfo.prevkbn;
				
				// 出力モードがＰＤＦの場合、無条件でプレビュー無
				if (this._printInfo.printmode == 2)
				{
					prevkbn = 0;
				}
#else
				// プレビュー有無				
				int mode = this._printInfo.prevkbn;
				
				// 出力モードがＰＤＦの場合、無条件でプレビュー無
				if (this._printInfo.printmode != 1)
				{
					mode = 0;
				}
#endif
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

#if CHG20060418
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
								this._pdfHistoryControl.AddPrintHistoryList(this._printInfo.key, "請求一覧表", this._printInfo.prpnm,
									this._printInfo.pdftemppath);
							}
							break;
						}
					}
				}
#else
				// ＰＤＦ出力の場合
				if (this._printInfo.printmode != 1 && status == 0)
				{
					this._printInfo.pdfopen = true;
					this._pdfHistoryControl.AddPrintHistoryList(this.Printinfo.key, "請求一覧表", this._printInfo.prpnm, this.Printinfo.pdftemppath);
				}
#endif

			}
			catch(DemandPrintException ex)
			{
				TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
					ex.Message, ex.Status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			}
			catch(Exception ex)
			{
				TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
					ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			}

			return status;
		}
		#endregion
	
		#region ◆　ActiveReport帳票インスタンス作成関連
		/// <summary>
		/// 各種ActiveReport帳票インスタンス作成
		/// </summary>
		/// <param name="rptObj">インスタンス化された帳票フォームクラス</param>
		/// <param name="prpid">帳票フォームID</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.19</br>
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
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.19</br>
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
		#endregion
	
		#region ◆　AvtiveReportに各種プロパティを設定します
		/// <summary>
		/// 各種プロパティ設定
		/// </summary>
		/// <param name="rpt">インスタンス化された帳票フォームクラス</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 各種プロパティを設定します。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.19</br>
        /// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// ActiveReportインターフェースにキャスト
			IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

			// ソート順プロパティ設定
			string wrkstr = "";
			// 2008.09.09 30413 犬飼 ソート順名称の変更 >>>>>>START
            switch (this._demandExtraInfo.SortOrder)
			{
                //case 0:
                //    wrkstr = "[得意先コード順]";
                //    break;
                //case 1:
                //    wrkstr = "[得意先カナ順]";
                //    break;
                //case 2:
                //    wrkstr = "[担当者→得意先コード順]";
                //    break;
                //case 3:
                //    wrkstr = "[担当者→得意先カナ順]";
                //    break;
                case 0:
                    wrkstr = "[得意先順]";
                    break;
                case 1:
                    wrkstr = "[担当者順]";
                    break;
                case 2:
                    wrkstr = "[地区順]";
                    break;
				default:
					break;
			}
            // 2008.09.09 30413 犬飼 ソート順名称の変更 <<<<<<END
            instance.PageHeaderSortOderTitle = wrkstr;

			// 帳票出力設定情報取得 
			PrtOutSet prtOutSet;
			string message;
			status = this._demandPrintAcs.ReadPrtOutSet(out prtOutSet, out message);
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
						throw new DemandPrintException(message, status);
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

			// 印刷情報オブジェクト
			instance.PrintInfo = this._printInfo;

			// 抽出条件編集処理
			StringCollection extraInfomations;
			this.MakeExtarCondition(out extraInfomations);

			instance.ExtraConditions = extraInfomations;

			// その他データ
			//bool isSection = (this._demandExtraInfo.IsOptSection && this._demandExtraInfo.MainOfficeFuncFlag == 1);
            bool isSection = (this._demandExtraInfo.IsOptSection && this._demandExtraInfo.IsMainOfficeFunc == true);
            ArrayList otherData = new ArrayList();
			otherData.Add(isSection);

			// >>>>> 2006.08.30 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
			// 全体項目表示設定の取得
			AlItmDspNm alItmDspNm = this._demandPrintAcs.GetAlItmDspNm();
			otherData.Add(alItmDspNm);
			// <<<<< 2006.08.30 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

			instance.OtherDataList = otherData;

			status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			return status;
		}
		#endregion
	
		#region ◆　抽出条件ヘッダー作成処理
		/// <summary>
		/// 抽出条件出力情報作成
		/// </summary>
		/// <param name="extraConditions">作成後抽出条件コレクション</param>
		/// <remarks>
		/// <br>Note       : 出力する抽出条件文字列を作成します。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.19</br>
        /// </remarks>
		private void MakeExtarCondition(out StringCollection extraConditions)
		{
            // 抽出条件ヘッダー項目
			extraConditions = new StringCollection();
            StringCollection addConditions = new StringCollection();
			
            const string ct_Extr_Top = "最初から";
            const string ct_Extr_End = "最後まで";

			string target = "";

            string addUpADate = string.Empty;

            // 2008.09.08 30413 犬飼 締日の変更 >>>>>>START
            //if (this._demandExtraInfo.TargetAddUpDate == 0)
            if (this._demandExtraInfo.AddUpDate == DateTime.MinValue)
            // 2008.09.08 30413 犬飼 締日の変更 <<<<<<END
            {
                addUpADate = "";
            }
            else
            {
                // 2008.09.08 30413 犬飼 締日の変更 >>>>>>START
                //addUpADate = TDateTime.LongDateToString("YYYY/MM/DD", this._demandExtraInfo.TargetAddUpDate);
                addUpADate = this._demandExtraInfo.AddUpDate.ToString("yyyy/MM/dd");
                // 2008.09.08 30413 犬飼 締日の変更 <<<<<<END
            }

            // 2009.01.28 30413 犬飼 対象締日→締日に変更 >>>>>>START
            //target = String.Format("対象締日：" + addUpADate);
            target = String.Format("締日：{0}　締分", addUpADate);
            // 2009.01.28 30413 犬飼 対象締日→締日に変更 <<<<<<END
            
            // 2008.09.08 30413 犬飼 削除項目 >>>>>>START
//            // 得意先締日 
//            if (this._demandExtraInfo.TotalDay >= 28 && this._demandExtraInfo.IsLastDay)
//            {
//                // 末日全ての場合、28日～31日と印字
//                if (target != "") target += CT_ITEM_INTERVAL;
//                target += "得意先締日：28日～31日";
//            }
//            else 
//            {
//                if (target != "") target += CT_ITEM_INTERVAL;
//#if CHG20060410
//                if (this._demandExtraInfo.TotalDay == 0)
//                {
//                    target += "得意先締日：全締日";
//                } 
//                else 
//                {
//                    target += String.Format("得意先締日：{0,2}日", this._demandExtraInfo.TotalDay);
//                }
//#else
//                target += String.Format("得意先締日　：{0,2}日", this._demandExtraInfo.TotalDay);
//#endif
//            }
            // 2008.09.08 30413 犬飼 削除項目 <<<<<<END
            this.EditCondition(ref addConditions, target); 

            // 2008.10.17 30413 犬飼 得意先の印字順序を変更 >>>>>>START
            //target = "";
			
            //// 得意先コード
            //if (this._demandExtraInfo.CustomerCodeSt != 0 || this._demandExtraInfo.CustomerCodeEd != 0)
            //{
            //    string startCode  = "";
            //    if (this._demandExtraInfo.CustomerCodeSt == 0)
            //    {
            //        startCode = ct_Extr_Top;
            //    }
            //    else
            //    {
            //        startCode = this._demandExtraInfo.CustomerCodeSt.ToString();
            //    }

            //    string endCode  = "";
            //    if (this._demandExtraInfo.CustomerCodeEd == 0)
            //    {
            //        endCode = ct_Extr_End;
            //    } 
            //    else 
            //    {
            //        endCode = this._demandExtraInfo.CustomerCodeEd.ToString();
            //    }
            //    target = "得意先コード：" + startCode + " ～ " + endCode;
            //    this.EditCondition(ref addConditions, target); 
            //}
            // 2008.10.17 30413 犬飼 得意先の印字順序を変更 <<<<<<END
			
            // 2008.09.08 30413 犬飼 削除項目 >>>>>>START
            //// 得意先カナ
            //if (this._demandExtraInfo.KanaSt.Trim() != "" || this._demandExtraInfo.KanaEd.Trim() != "")
            //{
            //    string startKana  = "";
            //    if (this._demandExtraInfo.KanaSt.Trim() == "")
            //    {
            //        startKana = "最初から";
            //    } 
            //    else 
            //    {
            //        startKana = this._demandExtraInfo.KanaSt;
            //    }
				
            //    string endKana  = "";
            //    if (this._demandExtraInfo.KanaEd.Trim() == "")
            //    {
            //        endKana = "最後まで";
            //    } 
            //    else 
            //    {
            //        endKana = this._demandExtraInfo.KanaEd;
            //    }
            //    target = "得意先カナ：" + startKana + " ～ " + endKana;
            //    this.EditCondition(ref addConditions, target); 
            //}
            // 2008.09.08 30413 犬飼 削除項目 <<<<<<END
            
            // 2007.10.15 hikita del start ------------------------------------------------------>>
			// 法人・個人区分
            //string wrkstr = "";
            //wrkstr = "";
            //if (this._demandExtraInfo.CorporateDivCodeList.Length != 0 && this._demandExtraInfo.CorporateDivCodeList.Length != 5)
            //{
            //    foreach(int i in this._demandExtraInfo.CorporateDivCodeList)
            //    {
            //        switch (i)
            //        {
            //            case 0:
            //                if (wrkstr != "") wrkstr += "・個人";
            //                else wrkstr = "個人";
            //                break;
            //            case 1:
            //                if (wrkstr != "") wrkstr += "・法人";
            //                else wrkstr = "法人";
            //                break;
            //            case 2:
            //                if (wrkstr != "") wrkstr += "・大口法人";
            //                else wrkstr = "大口法人";
            //                break;
            //            case 3:
            //                if (wrkstr != "") wrkstr += "・業者";
            //                else wrkstr = "業者";
            //                break;
            //            case 4:
            //                if (wrkstr != "") wrkstr += "・社員";
            //                else wrkstr = "社員";
            //                break;
            //            default:
            //                break;
            //        }
            //    }
            //    target = "個人・法人区分：" + wrkstr;
            //    this.EditCondition(ref addConditions, target);
            //}
            // 2007.10.15 hikita del end ----------------------------------------------------------<<

			// 担当者コード
            switch (this._demandExtraInfo.CustomerAgentDivCd)
            {
                case 0:     // 得意先担当
                    {
                        if (this._demandExtraInfo.CustomerAgentCdSt.Trim() != "" || this._demandExtraInfo.CustomerAgentCdEd.Trim() != "")
                        {
                            string startEmpCode = "";
                            if (this._demandExtraInfo.CustomerAgentCdSt.Trim() == "")
                            {
                                startEmpCode = ct_Extr_Top;
                            }
                            else
                            {
                                startEmpCode = this._demandExtraInfo.CustomerAgentCdSt;
                            }

                            string endEmpCode = "";
                            if (this._demandExtraInfo.CustomerAgentCdEd.Trim() == "")
                            {
                                endEmpCode = ct_Extr_End;
                            }
                            else
                            {
                                endEmpCode = this._demandExtraInfo.CustomerAgentCdEd;
                            }

                            string title = "";
                            // 2008.09.08 30413 犬飼 得意先担当者コード→得意先担当 >>>>>>START
                            //title = "得意先担当者コード：";
                            title = "得意先担当：";
                            // 2008.09.08 30413 犬飼 得意先担当者コード→得意先担当 <<<<<<END
                            target = title + startEmpCode + " ～ " + endEmpCode;
                            this.EditCondition(ref addConditions, target);
                        }

                        break;
                    }
                case 1:     // 集金担当
                    {
                        if (this._demandExtraInfo.BillCollecterCdSt.Trim() != "" || this._demandExtraInfo.BillCollecterCdEd.Trim() != "")
                        {
                            string startEmpCode = "";
                            if (this._demandExtraInfo.BillCollecterCdSt.Trim() == "")
                            {
                                startEmpCode = ct_Extr_Top;
                            }
                            else
                            {
                                startEmpCode = this._demandExtraInfo.BillCollecterCdSt;
                            }

                            string endEmpCode = "";
                            if (this._demandExtraInfo.BillCollecterCdEd.Trim() == "")
                            {
                                endEmpCode = ct_Extr_End;
                            }
                            else
                            {
                                endEmpCode = this._demandExtraInfo.BillCollecterCdEd;
                            }

                            string title = "";
                            // 2008.09.08 30413 犬飼 集金担当者コード→集金担当 >>>>>>START
                            //title = "集金担当者コード：";
                            title = "集金担当：";
                            // 2008.09.08 30413 犬飼 集金担当者コード→集金担当 <<<<<<END
                            
                            target = title + startEmpCode + " ～ " + endEmpCode;
                            this.EditCondition(ref addConditions, target);
                        }

                        break;
                    }
                default:
                    break;
            }

            // 2008.10.17 30413 犬飼 地区の印字を追加 >>>>>>START
            // 地区
            if ((this._demandExtraInfo.SalesAreaCodeSt == 0) && (this._demandExtraInfo.SalesAreaCodeEd != 0))
            {
                target = "地区: " + ct_Extr_Top + " ～ " + this._demandExtraInfo.SalesAreaCodeEd.ToString("d04");
                this.EditCondition(ref addConditions, target);
            }

            if ((this._demandExtraInfo.SalesAreaCodeSt > 0) && (this._demandExtraInfo.SalesAreaCodeEd == 0))
            {
                target = "地区: " + this._demandExtraInfo.SalesAreaCodeSt.ToString("d04") + " ～ " + ct_Extr_End;
                this.EditCondition(ref addConditions, target);
            }

            if ((this._demandExtraInfo.SalesAreaCodeSt > 0) && (this._demandExtraInfo.SalesAreaCodeEd != 0))
            {
                target = "地区: " + this._demandExtraInfo.SalesAreaCodeSt.ToString("d04") + " ～ " + this._demandExtraInfo.SalesAreaCodeEd.ToString("d04");
                this.EditCondition(ref addConditions, target);
            }
            // 2008.10.17 30413 犬飼 地区の印字を追加 <<<<<<END
            
            // 2008.10.17 30413 犬飼 得意先の印字順序を変更 >>>>>>START
            // 得意先コード
            if (this._demandExtraInfo.CustomerCodeSt != 0 || this._demandExtraInfo.CustomerCodeEd != 0)
            {
                string startCode = "";
                if (this._demandExtraInfo.CustomerCodeSt == 0)
                {
                    startCode = ct_Extr_Top;
                }
                else
                {
                    startCode = this._demandExtraInfo.CustomerCodeSt.ToString("d08");
                }

                string endCode = "";
                if (this._demandExtraInfo.CustomerCodeEd == 0)
                {
                    endCode = ct_Extr_End;
                }
                else
                {
                    endCode = this._demandExtraInfo.CustomerCodeEd.ToString("d08");
                }
                target = "得意先：" + startCode + " ～ " + endCode;
                this.EditCondition(ref addConditions, target);
            }
            // 2008.10.17 30413 犬飼 得意先の印字順序を変更 <<<<<<END
            
            // 2007.10.15 hikita del start ------------------------------------------------------------->>
			// >>>>> 2006.09.07 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
			// 得意先分析コード
            //string strCustmerAnalys = "得意先分析コード";
            //if (!(this._demandExtraInfo.CustAnalysCode1St == 0 && this._demandExtraInfo.CustAnalysCode1Ed == 999))
            //{
            //    target = strCustmerAnalys + "１:" + EditCodeRange(this._demandExtraInfo.CustAnalysCode1St, this._demandExtraInfo.CustAnalysCode1Ed);
            //    this.EditCondition(ref addConditions, target);
            //}
            //if (!(this._demandExtraInfo.CustAnalysCode2St == 0 && this._demandExtraInfo.CustAnalysCode2Ed == 999))
            //{
            //    target = strCustmerAnalys + "２:" + EditCodeRange(this._demandExtraInfo.CustAnalysCode2St, this._demandExtraInfo.CustAnalysCode2Ed);
            //    this.EditCondition(ref addConditions, target);
            //}
            //if (!(this._demandExtraInfo.CustAnalysCode3St == 0 && this._demandExtraInfo.CustAnalysCode3Ed == 999))
            //{
            //    target = strCustmerAnalys + "３:" + EditCodeRange(this._demandExtraInfo.CustAnalysCode3St, this._demandExtraInfo.CustAnalysCode3Ed);
            //    this.EditCondition(ref addConditions, target);
            //}
            //if (!(this._demandExtraInfo.CustAnalysCode4St == 0 && this._demandExtraInfo.CustAnalysCode4Ed == 999))
            //{
            //    target = strCustmerAnalys + "４:" + EditCodeRange(this._demandExtraInfo.CustAnalysCode4St, this._demandExtraInfo.CustAnalysCode4Ed);
            //    this.EditCondition(ref addConditions, target);
            //}
            //if (!(this._demandExtraInfo.CustAnalysCode5St == 0 && this._demandExtraInfo.CustAnalysCode5Ed == 999))
            //{
            //    target = strCustmerAnalys + "５:" + EditCodeRange(this._demandExtraInfo.CustAnalysCode5St, this._demandExtraInfo.CustAnalysCode5Ed);
            //    this.EditCondition(ref addConditions, target);
            //}
            //if (!(this._demandExtraInfo.CustAnalysCode6St == 0 && this._demandExtraInfo.CustAnalysCode6Ed == 999))
            //{
            //    target = strCustmerAnalys + "６:" + EditCodeRange(this._demandExtraInfo.CustAnalysCode6St, this._demandExtraInfo.CustAnalysCode6Ed);
            //    this.EditCondition(ref addConditions, target);
            //}
			// <<<<< 2006.09.07 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
            // 2007.10.15 hikita del end ---------------------------------------------------------------<<
		
			// 条件項目追加
			foreach (string str in addConditions)
			{
				extraConditions.Add(str);
			}
		
		}
		
		/// <summary>
		/// 抽出条件文字列編集(コードの範囲)
		/// </summary>
		/// <remarks>
		/// <br>Note       : 出力する抽出条件文字列(コードの範囲)を編集します。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2006.2006.09.07</br>
		/// </remarks>
		private string EditCodeRange(int startCd, int endCd)
		{
			string result = "";
			result = String.Format("{0} ～ {1}", startCd.ToString(), endCd.ToString());
			return result;
		}
		
		/// <summary>
		/// 抽出条件文字列編集
		/// </summary>
		/// <param name="editArea">格納エリア</param>
		/// <param name="target">対象文字列</param>
		/// <remarks>
		/// <br>Note       : 出力する抽出条件文字列を編集します。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.19</br>
        /// </remarks>
		private void EditCondition(ref StringCollection editArea, string target)
		{
			bool isEdit = false;
			
			// 編集対象文字バイト数算出
			int targetByte = TStrConv.SizeCountSJIS(target);
			
			for (int i = 0; i < editArea.Count; i++)
			{
				int areaByte = 0;
				
				
				// 格納エリアのバイト数算出
				if (editArea[i] != null)
				{
					areaByte = TStrConv.SizeCountSJIS(editArea[i]);
				}

				if ((areaByte + targetByte + 2) <= 190)
				{
					isEdit = true;

					// 全角スペースを挿入
					if (editArea[i] != null) editArea[i] += CT_ITEM_INTERVAL;
					
					editArea[i]  += target;
					break;
				}
			}
			// 新規編集エリア作成
			if (!isEdit)
			{
				editArea.Add(target);
			}
		}
		#endregion
		
		#region ◆　共通プレビュー部品パラメータ設定
		/// <summary>
		/// 印刷画面共通情報設定
		/// </summary>
		/// <param name="commonInfo"></param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 印刷画面共通条件の設定を行います。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.19</br>
        /// </remarks>
		private void SetPrintCommonInfo(out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo)
		{
			commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();
		
			// プリンタ名
			commonInfo.PrinterName = this._printInfo.prinm;
			
			// 帳票名
			commonInfo.PrintName   = this._printInfo.prpnm;				
				
			// 印刷件数
			commonInfo.PrintMax    = ((DataView)this._printInfo.rdData).Count;
			
			// 印刷モード
			commonInfo.PrintMode   = this._printInfo.printmode;
			
			// 余白設定
			// 桁位置
			commonInfo.MarginsLeft = this._printInfo.px;
			
			// 行位置
			commonInfo.MarginsTop  = this._printInfo.py;

			// PDF出力フルパス
			string pdfPath = "";
			string pdfName = "";
			this._sfcmn00331C.GetPdfSavePathName(this._printInfo.prpnm, ref pdfPath, ref pdfName);
			
			string pdfFileName     = System.IO.Path.Combine(pdfPath,pdfName);
			commonInfo.PdfFullPath = pdfFileName;
			
			this._printInfo.pdftemppath = pdfFileName;
		}
		#endregion
		
		#region ◆　印刷順クエリ作成関数
		/// <summary>
		/// 印字順クエリ作成処理
		/// </summary>
		/// <returns>作成したクエリ</returns>
		/// <remarks>
		/// <br>Note       : DataViewに設定する印字順位のクエリを作成します。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.19</br>
        /// </remarks>
		private string GetPrintOderQuerry()
		{
			string oderQuerry = "";		
		
			// 印字順設定
			switch (this._demandExtraInfo.SortOrder)
			{
                // 2008.09.08 30413 犬飼 ソート内容変更 >>>>>>START
                //case 0: 
                //{
                //    // 得意先コード順(拠点コード,得意先コード)
                //    oderQuerry = DemandPrintAcs.CT_CsDmd_AddUpSecCode + "," + 
                //        DemandPrintAcs.CT_CsDmd_ClaimCode + "," + 
                //        DemandPrintAcs.CT_CsDmd_CustomerCode;
                //    break;
                //}
                //case 1: 
                //{
                //    // 得意先カナ順(拠点コード,得意先カナ,得意先コード)
                //    oderQuerry = DemandPrintAcs.CT_CsDmd_AddUpSecCode + "," + 
                //        DemandPrintAcs.CT_CsDmd_Kana + "," +
                //        DemandPrintAcs.CT_CsDmd_ClaimCode + "," + 
                //        DemandPrintAcs.CT_CsDmd_CustomerCode;
                //    break;
                //}
                //case 2:
                //{
                //    // 担当者→得意先コード順(拠点コード,担当者コード,得意先コード)
                //    string employeeKey = "";

                //    switch (this._demandExtraInfo.CustomerAgentDivCd)
                //    {
                //        case 0:     // 顧客担当
                //            employeeKey = DemandPrintAcs.CT_CsDmd_CustomerAgentCd; 
                //            break;
                //        case 1:     // 集金担当
                //            employeeKey = DemandPrintAcs.CT_CsDmd_BillCollecterCd;
                //            break;
                //        default:
                //            break;
                //    }
                                
                //    oderQuerry = DemandPrintAcs.CT_CsDmd_AddUpSecCode + "," + 
                //        employeeKey + "," +
                //        DemandPrintAcs.CT_CsDmd_ClaimCode + "," + 
                //        DemandPrintAcs.CT_CsDmd_CustomerCode;
                //    break;
                //}
                //case 3: 
                //{
                //    // 担当者→得意先カナ順(拠点コード,担当者コード,得意先カナ,得意先コード)
                //    string employeeKey = "";

                //    switch (this._demandExtraInfo.CustomerAgentDivCd)
                //    {
                //        case 0:     // 顧客担当
                //            employeeKey = DemandPrintAcs.CT_CsDmd_CustomerAgentCd; 
                //            break;
                //        case 1:     // 集金担当
                //            employeeKey = DemandPrintAcs.CT_CsDmd_BillCollecterCd;
                //            break;
                //        default:
                //            break;
                //    }
                                
                //    oderQuerry = DemandPrintAcs.CT_CsDmd_AddUpSecCode + "," + 
                //        employeeKey + "," +
                //        DemandPrintAcs.CT_CsDmd_Kana + "," +
                //        DemandPrintAcs.CT_CsDmd_ClaimCode + "," + 
                //        DemandPrintAcs.CT_CsDmd_CustomerCode;
                //    break;
                //}
            case 0:
                {
                    // 2009.01.26 30413 犬飼 ソート順を変更 >>>>>>START
                    //// 得意先順(拠点－得意先順)
                    //oderQuerry = DemandPrintAcs.CT_CsDmd_AddUpSecCode + ","
                    //           + DemandPrintAcs.CT_CsDmd_CustomerCode;
                    // 得意先順(請求拠点－請求得意先－実績拠点－得意先順)
                    oderQuerry = DemandPrintAcs.CT_CsDmd_AddUpSecCode + ","
                               + DemandPrintAcs.CT_CsDmd_ClaimCode + ","
                               + DemandPrintAcs.CT_CsDmd_ResultsSectCd + ","
                               + DemandPrintAcs.CT_CsDmd_CustomerCode;
                    // 2009.01.26 30413 犬飼 ソート順を変更 <<<<<<END
                    break;
                }
            case 1:
                {
                    // 担当者順(拠点－担当者－得意先順)
                    string employeeKey = "";

                    if ((int)this._demandExtraInfo.CustomerAgentDivCd == 0)
                    {
                        // 得意先担当
                        employeeKey = DemandPrintAcs.CT_CsDmd_CustomerAgentCd;
                    }
                    else
                    {
                        // 集金担当
                        employeeKey = DemandPrintAcs.CT_CsDmd_BillCollecterCd;
                    }

                    // 2009.01.26 30413 犬飼 ソート順を変更 >>>>>>START
                    //oderQuerry = DemandPrintAcs.CT_CsDmd_AddUpSecCode + ","
                    //           + employeeKey + ","
                    //           + DemandPrintAcs.CT_CsDmd_CustomerCode;
                    // 担当者順(請求拠点－担当者－請求得意先－実績拠点－得意先順)
                    oderQuerry = DemandPrintAcs.CT_CsDmd_AddUpSecCode + ","
                               + employeeKey + ","
                               + DemandPrintAcs.CT_CsDmd_ClaimCode + ","
                               + DemandPrintAcs.CT_CsDmd_ResultsSectCd + ","
                               + DemandPrintAcs.CT_CsDmd_CustomerCode;
                    // 2009.01.26 30413 犬飼 ソート順を変更 <<<<<<END
                    break;
                }
            case 2:
                {
                    // 2009.01.26 30413 犬飼 ソート順を変更 >>>>>>START
                    //// 地区順(拠点－地区－得意先順)
                    //oderQuerry = DemandPrintAcs.CT_CsDmd_AddUpSecCode + ","
                    //           + DemandPrintAcs.CT_CsDmd_SalesAreaCode + ","
                    //           + DemandPrintAcs.CT_CsDmd_CustomerCode;
                    // 地区順(請求拠点－地区－請求得意先－実績拠点－得意先順)
                    oderQuerry = DemandPrintAcs.CT_CsDmd_AddUpSecCode + ","
                               + DemandPrintAcs.CT_CsDmd_SalesAreaCode + ","
                               + DemandPrintAcs.CT_CsDmd_ClaimCode + ","
                               + DemandPrintAcs.CT_CsDmd_ResultsSectCd + ","
                               + DemandPrintAcs.CT_CsDmd_CustomerCode;
                    // 2009.01.26 30413 犬飼 ソート順を変更 >>>>>>START
                    break;
                }
            // 2008.09.08 30413 犬飼 ソート内容変更 <<<<<<END
			}
			
			return oderQuerry;
		}
		#endregion

        #region ◆　フィルター設定処理
        /// <summary>
        /// フィルター設定処理
        /// </summary>
        /// <returns>作成したクエリ</returns>
        /// <remarks>
        /// <br>Note       : 請求内訳が両方の場合にDataViewに設定するフィルターを追加する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.11.14</br>
        /// </remarks>
        private string SelectTotalRecordOnlyFilter(string rowFilter)
        {
            string filter = "";

            // 既にフィルターが存在するか？
            if (rowFilter.Trim().Length == 0)
            {
                // 他のフィルター無し
                filter = String.Format("{0} = {1}",
                        DemandPrintAcs.CT_CsDmd_CustomerCode,
                        0);
            }
            else
            {
                // 他のフィルター有り
                filter = String.Format("{0} AND {1} = {2}",
                        rowFilter,
                        DemandPrintAcs.CT_CsDmd_CustomerCode,
                        0);
            }

            return filter;
        }
		#endregion

		#region ◆　メッセージ表示処理
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
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.19</br>
        /// </remarks>
		private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "MAKAU02020P", iMsg, iSt, iButton, iDefButton);
		}
		#endregion
		#endregion


	}
}

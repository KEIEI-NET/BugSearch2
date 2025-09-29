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
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 回収予定表印刷クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 回収予定表の印刷を行う。</br>
	/// <br>Programmer : 20081 疋田 勇人</br>
	/// <br>Date       : 2007.10.23</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : PM.NS対応</br>
    /// <br>Programmer : 30413 犬飼</br>
    /// <br>Date	   : 2008.11.11</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : PM.NS対応</br>
    /// <br>Programmer : 30414 忍</br>
    /// <br>Date	   : 2009.02.24</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : #13691の対応</br>
    /// <br>Programmer : 楊明俊</br>
    /// <br>Date	   : 2010/08/26</br>
    /// <br></br>
    /// <br>UpdateNote : 2011/04/11  22018 鈴木 正臣</br>
    /// <br>           : フォントサイズを大きくする為に、印字桁制御を追加。</br>
    /// </remarks>
	class DCKAU02522PA: IPrintProc
	{

		#region ■ Constructor
		/// <summary>
		/// 回収予定表印刷クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 回収予定表印刷クラスのインスタンスの作成を行う。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.23</br>
		/// </remarks>
		public DCKAU02522PA()
		{
		}

		/// <summary>
		/// 回収予定表印刷クラスコンストラクタ
		/// </summary>
		/// <param name="printInfo">印刷情報オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 回収予定表印刷クラスのインスタンスの作成を行う。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.23</br>
		/// </remarks>
		public DCKAU02522PA( object printInfo )
		{
			this._printInfo = printInfo as SFCMN06002C;
            this._rsltInfo_CollectPlan = this._printInfo.jyoken as RsltInfo_CollectPlan;
		}
		#endregion ■ Constructor

		#region ■ Pricate Const
		private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
		private const string ct_Space			= "　";
		private const string ct_Extr_Top		= "最初から";
		private const string ct_Extr_End		= "最後まで";
		#endregion ■ Pricate Const

		#region ■ Private Member
		private SFCMN06002C _printInfo;					    // 印刷情報クラス
        private RsltInfo_CollectPlan _rsltInfo_CollectPlan;	// 抽出条件クラス
		#endregion ■ Private Member

        // 2008.11.21 30413 犬飼 出力順のプロパティ変更 >>>>>>START
        private string CT_Sort1_Odr = "AddUpSecCode, ClaimCode";                                        // 拠点+得意先
        private string CT_Sort2_1_Odr = "AddUpSecCode, CustomerAgentCd, ClaimCode"; 　                  // 拠点+得意先担当者+得意先
        private string CT_Sort2_2_Odr = "AddUpSecCode, BillCollecterCd, ClaimCode"; 　                  // 拠点+集金担当者+得意先
        private string CT_Sort3_Odr = "AddUpSecCode, SalesAreaCode, ClaimCode";                         // 拠点+地区+得意先
        private string CT_Sort4_1_Odr = "AddUpSecCode, CustomerAgentCd, CalcCollectDay, ClaimCode"; 　  // 拠点+得意先担当者+締後回収日+得意先
        private string CT_Sort4_2_Odr = "AddUpSecCode, BillCollecterCd, CalcCollectDay, ClaimCode";     // 拠点+集金担当者+締後回収日+得意先
        private string CT_Sort5_Odr = "AddUpSecCode, SalesAreaCode, CalcCollectDay, ClaimCode"; 　      // 拠点+地区+締後回収日+得意先
        private string CT_Sort6_Odr = "AddUpSecCode, CalcCollectDay, ClaimCode";                        // 拠点+締後回収日+得意先
        private string CT_Sort7_Odr = "AddUpSecCode, CalcCollectDay, CollectCond, ClaimCode";           // 拠点+締後回収日+回収条件+得意先
        // 2008.11.21 30413 犬飼 出力順のプロパティ変更 <<<<<<END

		#region ■ Exception Class
		/// <summary> 例外クラス </summary>
        private class CollectPlanMainException: ApplicationException
		{
			private int _status;
			#region ◆ Constructor
			/// <summary>
			/// 例外クラスコンストラクタ
			/// </summary>
			/// <param name="message">メッセージ</param>
			/// <param name="status">ステータス</param>
			public CollectPlanMainException(string message, int status): base(message)
			{
				this._status = status; 
			}
			#endregion
    
			#region ◆ Public Property
			/// <summary> ステータスプロパティ </summary>
			public int Status
			{
				get{ return this._status; }
			}
			#endregion
		}
		#endregion ■ Exception Class
		


		#region ■ IPrintProc メンバ
		#region ◆ Public Property
		/// <summary>
		/// 印刷情報取得プロパティ
		/// </summary>
		public SFCMN06002C Printinfo
		{
			get { return this._printInfo; }
			set { this._printInfo = value;}
		}
		#endregion ◆ Public Property

		#region ◆ Public Method
		#region ◎ 印刷処理開始
		/// <summary>
		/// 印刷処理開始
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : 印刷を開始する。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.23</br>
		/// </remarks>
		public int StartPrint ()
		{
			return PrintMain();
		}
		#endregion
		#endregion ◆ Public Method
		#endregion ■ IPrintProc メンバ

		#region ■ Private Member
		#region ◆ 印刷処理
		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷処理を行う。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.23</br>
		/// </remarks>
		private int PrintMain ()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			// 印刷フォームクラスインスタンス作成
			DataDynamics.ActiveReports.ActiveReport3 prtRpt = null;
			try
			{
				// レポートインスタンス作成
				this.CreateReport(out prtRpt, this._printInfo.prpid); 
				if (prtRpt == null) return status;

				// 各種プロパティ設定
				status = this.SettingProperty(ref prtRpt);
				if (status != 0) return status;

                // --- ADD m.suzuki 2011/04/11 ---------->>>>>
                PMCMN02000CA reportCtrl = PMCMN02000CA.GetInstance();
                reportCtrl.SetReportProps( ref prtRpt, PMCMN02000CA.SetReportPropsKind.NormalList );
                // --- ADD m.suzuki 2011/04/11 ----------<<<<<

                // 2008.11.21 30413 犬飼 データソース設定時に出力順にソートクエリを設定 >>>>>>START
                // データソース設定
                //prtRpt.DataSource = (DataSet)this._printInfo.rdData;
                prtRpt.DataMember = DCKAU02524EA.Col_Tbl_RsltInfo_CollectPlan;

                // 2008.12.16 30413 犬飼 フィルター追加のため、データビューに変更 >>>>>>START
                // 印刷データ取得
                //DataSet ds = (DataSet)this._printInfo.rdData;
                //dv.Table = ds.Tables[DCKAU02524EA.Col_Tbl_RsltInfo_CollectPlan];
                DataView dv = (DataView)this._printInfo.rdData;
                // 2008.12.16 30413 犬飼 フィルター追加のため、データビューに変更 <<<<<<END
        
                // ソート順設定
                dv.Sort = this.GetPrintOderQuerry();

                // データソース設定
                prtRpt.DataSource = dv;
                // 2008.11.21 30413 犬飼 データソース設定時に出力順にソートクエリを設定 <<<<<<END

				// 印刷共通情報プロパティ設定
				Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
			    this.SetPrintCommonInfo(out commonInfo);

			    // プレビュー有無				
			    int mode = this._printInfo.prevkbn;
				
			    // 出力モードがＰＤＦの場合、無条件でプレビュー無
			    if (this._printInfo.printmode == 2)
			    {
			        mode = 0;
			    }
				
			    switch(mode)
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
			}
			catch(Exception ex)
			{
			    this.MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP,
			        ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			}
			finally
			{
			    if ( prtRpt != null )
			    {
			        prtRpt.Dispose();
			    }
			}
			return status;
		}
		#endregion ◆ 印刷処理

		#region ◆ レポートフォーム設定関連
		#region ◎ 各種ActiveReport帳票インスタンス作成
		/// <summary>
		/// 各種ActiveReport帳票インスタンス作成
		/// </summary>
		/// <param name="rptObj">インスタンス化された帳票フォームクラス</param>
		/// <param name="prpid">帳票フォームID</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.23</br>
		/// </remarks>
		private void CreateReport(out DataDynamics.ActiveReports.ActiveReport3 rptObj,string prpid)
		{
			// 印刷フォームクラスインスタンス作成
			rptObj = (DataDynamics.ActiveReports.ActiveReport3)this.LoadAssemblyReport(
				prpid.Trim(), ct_ReportForm_NameSpace + "." + prpid.Trim(), 
				typeof(DataDynamics.ActiveReports.ActiveReport3));
		}
		#endregion

		#region ◎ レポートアセンブリインスタンス化
		/// <summary>
		/// レポートアセンブリインスタンス化
		/// </summary>
		/// <param name="asmname">アセンブリ名称</param>
		/// <param name="classname">クラス名称</param>
		/// <param name="type">実装するクラス型</param>
		/// <returns>インスタンス化されたクラス</returns>
		/// <remarks>
		/// <br>Note       : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.23</br>
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
				throw new CollectPlanMainException(asmname + "が存在しません。",-1);
			}
			catch(System.Exception er)
			{
				throw new CollectPlanMainException(er.Message, -1);
			}
			return obj;
		}
		#endregion

		#region ◎ 印刷画面共通情報設定

		/// <summary>
		/// 印刷画面共通情報設定
		/// </summary>
		/// <param name="commonInfo"></param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 印刷画面共通条件の設定を行います。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.23</br>
		/// </remarks>
		private void SetPrintCommonInfo(out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();
			
			// 帳票チャート共通部品クラス
			SFCMN00331C cmnCommon = new SFCMN00331C(); 

			// PDFパス取得
			string pdfPath = "";
			string pdfName = "";
		
			// プリンタ名
			commonInfo.PrinterName = this._printInfo.prinm;
			// 帳票名
			commonInfo.PrintName   = this._printInfo.prpnm;				
			// 印刷モード
			commonInfo.PrintMode   = this.Printinfo.printmode;
			// 印刷件数
            //commonInfo.PrintMax    = 0;
            int maxCount = 0;
            if (this._printInfo.rdData is DataView)
            {
                maxCount = (this._printInfo.rdData as DataView).Count;
            }
            commonInfo.PrintMax = maxCount;
			
			status = cmnCommon.GetPdfSavePathName(this._printInfo.prpnm, ref pdfPath, ref pdfName);
			this._printInfo.pdftemppath = pdfPath + pdfName;
			commonInfo.PdfFullPath = this._printInfo.pdftemppath;

			// 上余白
			commonInfo.MarginsTop  = this._printInfo.py;
			// 左余白
			commonInfo.MarginsLeft = this._printInfo.px;
		}

		#endregion
		

		#region ◎ 各種プロパティ設定
		
		/// <summary>
		/// 各種プロパティ設定
		/// </summary>
		/// <param name="rpt">インスタンス化された帳票フォームクラス</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 各種プロパティを設定します。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.23</br>
		/// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// ActiveReportインターフェースにキャスト
			IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

			// 印刷条件取得
            RsltInfo_CollectPlan extraInfo = (RsltInfo_CollectPlan)this._printInfo.jyoken;

			// ソート順プロパティ設定
			instance.PageHeaderSortOderTitle = GetSortOrderName( extraInfo );
			
			// 帳票出力設定情報取得 
			PrtOutSet prtOutSet;
			string message;
            int st = CollectPlanAcs.ReadPrtOutSet(out prtOutSet, out message);
			if (st != 0) 
			{
                throw new CollectPlanMainException(message, status);
            }
			
			// 抽出条件ヘッダ出力区分
			instance.ExtraCondHeadOutDiv = prtOutSet.ExtraCondHeadOutDiv;

			// 抽出条件編集処理
			StringCollection extraInfomations;
			this.MakeExtarCondition( out extraInfomations );

			instance.ExtraConditions = extraInfomations; 
			
			// フッタ出力区分
			instance.PageFooterOutCode   = prtOutSet.FooterPrintOutCode;

			// フッタ出力メッセージ
			StringCollection footers = new StringCollection();
			footers.Add(prtOutSet.PrintFooter1);
			footers.Add(prtOutSet.PrintFooter2);
			
			instance.PageFooters = footers;

			// 印刷情報オブジェクト
			instance.PrintInfo = this._printInfo;

            // ヘッダーサブタイトル
            instance.PageHeaderSubtitle = this._rsltInfo_CollectPlan.PrintDivName;

			// その他データ
			ArrayList otherDataList = new ArrayList();
			otherDataList.Add(this._rsltInfo_CollectPlan.EmployeeKindDivName);		// 担当者タイトル名称

			// 全社が選択されていたら明細に拠点名称を出す。
			if ( this._rsltInfo_CollectPlan.IsSelectAllSection )
			{
				otherDataList.Add("支払計上拠点");		// 明細拠点名称タイトル
			}
			else
			{
				otherDataList.Add( string.Empty );		// 明細拠点名称タイトル
			}
			instance.OtherDataList = otherDataList;

			status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			return status;
		}

		#endregion

		#region ◎ ソート順名称取得
		/// <summary>
		/// ソート順名称取得
		/// </summary>
		/// <param name="rsltInfo_CollectPlan">抽出条件</param>
		/// <returns>ソート順名称</returns>
		/// <remarks>
		/// <br>Note       : ソート順名称を取得する。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.23</br>
		/// </remarks>
        private string GetSortOrderName(RsltInfo_CollectPlan rsltInfo_CollectPlan)
		{
			string sortOrderName = string.Empty;
            sortOrderName = "[" + rsltInfo_CollectPlan.SortOrderDivName + "]";
			return sortOrderName;
		}
		#endregion

		#region ◎ 抽出条件出力情報作成
		/// <summary>
		/// 抽出条件出力情報作成
		/// </summary>
		/// <param name="extraConditions">作成後抽出条件コレクション</param>
		/// <remarks>
		/// <br>Note       : 出力する抽出条件文字列を作成する。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.23</br>
        /// <br>Update Note : 2010/08/26 楊明俊 #13691の対応</br>
        /// </remarks>
		private void MakeExtarCondition( out StringCollection extraConditions )
		{
			extraConditions = new StringCollection();

            // 2008.11.20 30413 犬飼 抽出条件出力の変更 >>>>>>START
            string target = "";
            StringCollection addConditions = new StringCollection();

			// 処理日 ----------------------------------------------------------------------------------------------------
			string addUpADate = string.Empty;
			
			if ( this._rsltInfo_CollectPlan.AddUpDate != DateTime.MinValue )
                addUpADate = TDateTime.DateTimeToString(RsltInfo_CollectPlan.ct_DateFomat, this._rsltInfo_CollectPlan.AddUpDate);
			else
				addUpADate = "";

            //this.EditCondition(ref extraConditions, string.Format( "処理日　" + addUpADate ) );
            this.EditCondition(ref addConditions, string.Format("処理日：" + addUpADate));

            //StringCollection addConditions = new StringCollection();

            //// 得意先先コード ----------------------------------------------------------------------------------------------------
            //if ((this._rsltInfo_CollectPlan.St_ClaimCode != 0) || (this._rsltInfo_CollectPlan.Ed_ClaimCode != 0))
            //{
            //    string st_ClaimCode_Top = string.Empty;
            //    string ed_ClaimCode_End = string.Empty;

            //    if (this._rsltInfo_CollectPlan.St_ClaimCode == 0)
            //    {
            //        st_ClaimCode_Top = ct_Extr_Top;
            //    }
            //    else
            //    {
            //        st_ClaimCode_Top = string.Format("{0:000000000}", this._rsltInfo_CollectPlan.St_ClaimCode);
            //    }

            //    if (this._rsltInfo_CollectPlan.Ed_ClaimCode == 0)
            //    {
            //        ed_ClaimCode_End = ct_Extr_End;
            //    }
            //    else
            //    {
            //        ed_ClaimCode_End = string.Format("{0:000000000}", this._rsltInfo_CollectPlan.Ed_ClaimCode);
            //    }

            //    this.EditCondition(ref addConditions,
            //        string.Format("得意先コード：{0} ～ {1}", st_ClaimCode_Top, ed_ClaimCode_End));
            //}
            //// 担当者コード ----------------------------------------------------------------------------------------------------
            //if ( ( this._rsltInfo_CollectPlan.St_EmployeeCode != string.Empty ) || ( this._rsltInfo_CollectPlan.Ed_EmployeeCode != string.Empty ) )
            //{
            //    this.EditCondition( ref addConditions, 
            //        GetConditionRange( this._rsltInfo_CollectPlan.EmployeeKindDivName + "者コード", this._rsltInfo_CollectPlan.St_EmployeeCode, this._rsltInfo_CollectPlan.Ed_EmployeeCode ) );
            //}

            // 締日
            if (this._rsltInfo_CollectPlan.TotalDay == 0)
            {
                // 締日未入力
                this.EditCondition(ref addConditions, "締日：全締日");
            }
            else
            {
                //-----UPD 2010/08/26 ---------->>>>>
                if (this._rsltInfo_CollectPlan.TotalDay == 31)
                {
                    target = "締日：末日";
                }
                else
                {
                    target = "締日：" + this._rsltInfo_CollectPlan.TotalDay.ToString("d02") + "日";
                }
                //target = "締日：" + this._rsltInfo_CollectPlan.TotalDay.ToString("d02") + "日";
                //-----UPD 2010/08/26 ----------<<<<<
                this.EditCondition(ref addConditions, target);
            }

            // 回収日
            if (this._rsltInfo_CollectPlan.ExpectedDepositDate == 0)
            {
                // 回収日未入力
                this.EditCondition(ref addConditions, "回収日：全回収日");
            }
            else
            {
                //-----UPD 2010/08/26 ---------->>>>>
                if (this._rsltInfo_CollectPlan.ExpectedDepositDate == 31)
                {
                    target = "回収日：末日";
                }
                else
                {
                    target = "回収日：" + this._rsltInfo_CollectPlan.ExpectedDepositDate.ToString("d02") + "日";
                }
                //target = "回収日：" + this._rsltInfo_CollectPlan.ExpectedDepositDate.ToString("d02") + "日";
                //-----UPD 2010/08/26 ----------<<<<<
                this.EditCondition(ref addConditions, target);
            }

			// 回収条件 ----------------------------------------------------------------------------------------------------
            if (!this._rsltInfo_CollectPlan.CollectCond.ContainsKey(RsltInfo_CollectPlan.ct_All_Code))
			{
                this.EditCondition(ref addConditions, "回収条件：" + GetCollectCondDivName());
			}

            // 担当者コード
            if (this._rsltInfo_CollectPlan.St_EmployeeCode.Trim() != "" || this._rsltInfo_CollectPlan.Ed_EmployeeCode.Trim() != "")
            {
                string startEmpCode = "";
                if (this._rsltInfo_CollectPlan.St_EmployeeCode.Trim() == "")
                {
                    startEmpCode = ct_Extr_Top;
                }
                else
                {
                    startEmpCode = this._rsltInfo_CollectPlan.St_EmployeeCode;
                }

                string endEmpCode = "";
                if (this._rsltInfo_CollectPlan.Ed_EmployeeCode.Trim() == "")
                {
                    endEmpCode = ct_Extr_End;
                }
                else
                {
                    endEmpCode = this._rsltInfo_CollectPlan.Ed_EmployeeCode;
                }

                string title = "";
                title = this._rsltInfo_CollectPlan.EmployeeKindDivName + "者：";
                target = title + startEmpCode + " ～ " + endEmpCode;
                this.EditCondition(ref addConditions, target);
            }

            // 地区
            if ((this._rsltInfo_CollectPlan.St_SalesAreaCode == 0) && (this._rsltInfo_CollectPlan.Ed_SalesAreaCode != 0))
            {
                target = "地区: " + ct_Extr_Top + " ～ " + this._rsltInfo_CollectPlan.Ed_SalesAreaCode.ToString("d04");
                this.EditCondition(ref addConditions, target);
            }

            if ((this._rsltInfo_CollectPlan.St_SalesAreaCode > 0) && (this._rsltInfo_CollectPlan.Ed_SalesAreaCode == 0))
            {
                target = "地区: " + this._rsltInfo_CollectPlan.St_SalesAreaCode.ToString("d04") + " ～ " + ct_Extr_End;
                this.EditCondition(ref addConditions, target);
            }

            if ((this._rsltInfo_CollectPlan.St_SalesAreaCode > 0) && (this._rsltInfo_CollectPlan.Ed_SalesAreaCode != 0))
            {
                target = "地区: " + this._rsltInfo_CollectPlan.St_SalesAreaCode.ToString("d04") + " ～ " + this._rsltInfo_CollectPlan.Ed_SalesAreaCode.ToString("d04");
                this.EditCondition(ref addConditions, target);
            }

            // 得意先コード
            if (this._rsltInfo_CollectPlan.St_ClaimCode != 0 || this._rsltInfo_CollectPlan.Ed_ClaimCode != 0)
            {
                string startCode = "";
                if (this._rsltInfo_CollectPlan.St_ClaimCode == 0)
                {
                    startCode = ct_Extr_Top;
                }
                else
                {
                    startCode = this._rsltInfo_CollectPlan.St_ClaimCode.ToString("d08");
                }

                string endCode = "";
                if (this._rsltInfo_CollectPlan.Ed_ClaimCode == 0)
                {
                    endCode = ct_Extr_End;
                }
                else
                {
                    endCode = this._rsltInfo_CollectPlan.Ed_ClaimCode.ToString("d08");
                }
                target = "得意先：" + startCode + " ～ " + endCode;
                this.EditCondition(ref addConditions, target);
            }
            // 2008.11.20 30413 犬飼 抽出条件出力の変更 <<<<<<END

            //// --- ADD 2009/02/24 障害ID:10843対応------------------------------------------------------>>>>>
            //// 印刷区分
            //if (this._rsltInfo_CollectPlan.PrintExpctDiv == 0)
            //{
            //    this.EditCondition(ref addConditions, "印刷区分：予定額＜0でも印字する");
            //}
            //else
            //{
            //    this.EditCondition(ref addConditions, "印刷区分：予定額＜0は印字しない");
            //}
            //// --- ADD 2009/02/24 障害ID:10843対応------------------------------------------------------<<<<<
			
			foreach ( string exCondStr in addConditions )
			{
				extraConditions.Add( exCondStr );
			}

		}
		#endregion

		#region ◎ 回収条件称文字列作成
		/// <summary>
		/// 回収条件名称文字列作成
		/// </summary>
		/// <returns>作成文字列</returns>
		/// <remarks>
		/// <br>Note       : 抽出範囲文字列を作成します</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.23</br>
		/// </remarks>
        private string GetCollectCondDivName()
		{
			StringBuilder result = new StringBuilder();

            foreach (string corpName in this._rsltInfo_CollectPlan.CollectCond.Values)
			{
				if ( result.ToString().CompareTo( string.Empty ) != 0 )
				{
					result.Append("、");
				}
				result.Append( corpName );
			}

			return result.ToString();
		}
		#endregion

		#region ◎ 抽出範囲文字列作成
		/// <summary>
		/// 抽出範囲文字列作成
		/// </summary>
		/// <returns>作成文字列</returns>
		/// <remarks>
		/// <br>Note       : 抽出範囲文字列を作成します</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.23</br>
		/// </remarks>
		private string GetConditionRange( string title, string startString, string endString )
		{
			string result = "";
			if ((startString != "") || (endString != ""))
			{
				string start = ct_Extr_Top;
				string end	 = ct_Extr_End;
				if (startString	!= "")	start	= startString;
				if (endString	!= "")	end		= endString;
				result = String.Format(title + "： {0} ～ {1}", start, end);
			}
			return result;
		}
		#endregion

		#region ◎ 抽出条件文字列編集
		/// <summary>
		/// 抽出条件文字列編集
		/// </summary>
		/// <param name="editArea">格納エリア</param>
		/// <param name="target">対象文字列</param>
		/// <remarks>
		/// <br>Note       : 出力する抽出条件文字列を編集します。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.23</br>
		/// </remarks>
		private void EditCondition(ref StringCollection editArea, string target)
		{
			bool isEdit = false;
			
			// 編集対象文字バイト数算出
			int targetByte = TStrConv.SizeCountSJIS(target);

            // 2008.11.20 30413 犬飼 抽出条件を適宜改行するように修正 >>>>>>START
            //for (int i = 0; i < editArea.Count; i++)
            //{
            //    int areaByte = 0;
				
            //    // 格納エリアのバイト数算出
            //    if (editArea[i] != null)
            //    {
            //        areaByte = TStrConv.SizeCountSJIS(editArea[i]);
            //    }

            //    if ((areaByte + targetByte + 2) <= 190)
            //    {
            //        isEdit = true;

            //        // 全角スペースを挿入
            //        if (editArea[i] != null) editArea[i] += ct_Space;
					
            //        editArea[i]  += target;
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

                if ((areaByte + targetByte + 2) >= 140)
                {
                    // 改行
                    editArea[index] += "\n";
                }
                else
                {
                    isEdit = true;

                    // 全角スペースを挿入
                    if (editArea[index] != null) editArea[index] += ct_Space;

                    editArea[index] += target;
                }
            }
            // 2008.11.20 30413 犬飼 抽出条件を適宜改行するように修正 <<<<<<END

			// 新規編集エリア作成
			if (!isEdit)
			{
				editArea.Add(target);
			}
		}
		#endregion
		#endregion ◆ レポートフォーム設定関連

        #region ◆　印刷順クエリ作成関数
        /// <summary>
        /// 印字順クエリ作成処理
        /// </summary>
        /// <returns>作成したクエリ</returns>
        /// <remarks>
        /// <br>Note       : DataViewに設定する印字順位のクエリを作成します。</br>
        /// <br>Programmer : 犬飼</br>
        /// <br>Date       : 2008.11.21</br>
        /// </remarks>
        private string GetPrintOderQuerry()
        {
            string oderQuerry = "";

            switch (this._rsltInfo_CollectPlan.SortOrderDiv)
            {
                case RsltInfo_CollectPlan.SortOrderDivState.CustomerCode:
                    {
                        oderQuerry = CT_Sort1_Odr;
                        break;
                    }
                case RsltInfo_CollectPlan.SortOrderDivState.EmployeeCode:
                    {
                        if (this._rsltInfo_CollectPlan.EmployeeKindDiv == 0)
                        {
                            // 得意先担当
                            oderQuerry = CT_Sort2_1_Odr;
                        }
                        else
                        {
                            // 集金担当
                            oderQuerry = CT_Sort2_2_Odr;
                        }
                        break;
                    }
                case RsltInfo_CollectPlan.SortOrderDivState.SalesAreaCode:
                    {
                        oderQuerry = CT_Sort3_Odr;
                        break;
                    }
                case RsltInfo_CollectPlan.SortOrderDivState.EmployeeCollect:
                    {
                        if (this._rsltInfo_CollectPlan.EmployeeKindDiv == 0)
                        {
                            // 得意先担当
                            oderQuerry = CT_Sort4_1_Odr;
                        }
                        else
                        {
                            // 集金担当
                            oderQuerry = CT_Sort4_2_Odr;
                        }
                        break;
                    }
                case RsltInfo_CollectPlan.SortOrderDivState.SalesAreaCollect:
                    {
                        oderQuerry = CT_Sort5_Odr;
                        break;
                    }
                case RsltInfo_CollectPlan.SortOrderDivState.CollectMoneyDay:
                    {
                        oderQuerry = CT_Sort6_Odr;
                        break;
                    }
                case RsltInfo_CollectPlan.SortOrderDivState.CollectMoneyDayCond:
                    {
                        oderQuerry = CT_Sort7_Odr;
                        break;
                    }
            }

            return oderQuerry;
        }
        #endregion

		#region ◎ メッセージ表示

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
		/// <br>Date       : 2007.10.23</br>
		/// </remarks>
		private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "DCKAU02522P", iMsg, iSt, iButton, iDefButton);
		}

		#endregion
		#endregion
	}
}

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
	/// 発注一覧表印刷クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 発注一覧表の印刷を行う。</br>
	/// <br>Programmer : 22018 鈴木 正臣</br>
	/// <br>Date       : 2007.09.19</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : PM.NS対応</br>
    /// <br>Programmer : 犬飼</br>
    /// <br>Date	   : 2008.09.03</br>
    /// <br>UpdateNote : 発注残一覧表追加</br>
    /// <br>Programmer : 渋谷　大輔</br>
    /// <br>Date	   : 2008.12.10</br>
    /// <br>UpdateNote : 排他制御処理追加</br>
    /// <br>Programmer : 忍　幸史</br>
    /// <br>Date	   : 2009.02.02</br>
    /// <br>UpdateNote : Redmine#34986 発注一覧表更新失敗の場合、エラーメッセージの修正</br>
    /// <br>Programmer : pengjie</br>
    /// <br>Date	   : 2013.03.14</br>
    /// <br>UpdateNote : ハンディターミナル二次開発の対応</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date	   : 2017/09/14</br>
    /// </remarks>
	class DCHAT02102PA: IPrintProc
	{

		#region ■ Constructor
		/// <summary>
		/// 発注一覧表印刷クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 発注一覧表印刷クラスのインスタンスの作成を行う。</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		public DCHAT02102PA()
		{
		}

		/// <summary>
		/// 発注一覧表印刷クラスコンストラクタ
		/// </summary>
		/// <param name="printInfo">印刷情報オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 発注一覧表印刷クラスのインスタンスの作成を行う。</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		public DCHAT02102PA( object printInfo )
		{
			this._printInfo = printInfo as SFCMN06002C;
			this._orderListCndtn = this._printInfo.jyoken as OrderListCndtn;
		}
		#endregion ■ Constructor

		#region ■ Pricate Const
		private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
		private const string ct_Space			= "　";
		private const string ct_Extr_Top		= "ＴＯＰ";
		private const string ct_Extr_End		= "ＥＮＤ";
		private	const string ct_RangeConst		= "：{0} ～ {1}";
		#endregion ■ Pricate Const

		#region ■ Private Member
		private SFCMN06002C _printInfo;					// 印刷情報クラス
		private OrderListCndtn _orderListCndtn;		// 抽出条件クラス
		#endregion ■ Private Member

        

		#region ■ Exception Class
		/// <summary> 例外クラス </summary>
        private class StockMoveException: ApplicationException
		{
			private int _status;
			#region ◆ Constructor
			/// <summary>
			/// 例外クラスコンストラクタ
			/// </summary>
			/// <param name="message">メッセージ</param>
			/// <param name="status">ステータス</param>
			public StockMoveException(string message, int status): base(message)
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
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		public int StartPrint ()
		{
            // 2008.09.03 30413 犬飼 未使用プロパティ削除 >>>>>>START
            //int number = 0;
            //number = 1;
            // 2008.09.03 30413 犬飼 未使用プロパティ削除 <<<<<<END
            
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
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
        /// <br>UpdateNote : Redmine#34986 発注一覧表更新失敗の場合、エラーメッセージの修正</br>
        /// <br>Programmer : pengjie</br>
        /// <br>Date	   : 2013.03.14</br>
        /// <br>UpdateNote : ハンディターミナル二次開発の対応</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date	   : 2017/09/14</br>
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
							
				// データソース設定
				prtRpt.DataSource = this._printInfo.rdData;
                prtRpt.DataMember = DCHAT02104EA.ct_Tbl_OrderList;
				
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

                // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
                // バーコード表示しない場合
                if (((OrderListCndtn)this._printInfo.jyoken).BarCodeShowDiv != 0)
                {
                // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<
                    // 2008.12.10 UPD 1:発注残一覧表の場合は処理を迂回 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    if (((OrderListCndtn)this._printInfo.jyoken).PrtPaperTypeDiv == 0)
                    {
#if true
                        // 印刷条件取得
                        OrderListCndtn extraInfo = (OrderListCndtn)this._printInfo.jyoken;
                        OrderListAcs orderListAcs = new OrderListAcs();
                        int st = orderListAcs.UpdateOrderDate(extraInfo.BlanketStockInputDataDiv);
                        // --- CHG 2009/02/02 排他制御処理追加------------------------------------------------------>>>>>
                        //if (st != 0)
                        //{
                        //    MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        //                "発注データの更新が失敗しました。",
                        //                st,
                        //                MessageBoxButtons.OK,
                        //                MessageBoxDefaultButton.Button1);
                        //}
                        switch (st)
                        {
                            case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                                {
                                    break;
                                }
                            // 企業ロックタイムアウト
                            case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                                {
                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,
                                        "DCHAT02102P",
                                        "更新に失敗しました。" + "\r\n"
                                        + "\r\n" +
                                        "シェアチェックエラー（企業ロック）です。" + "\r\n" +
                                        "月次処理か、その他の業務を行っているため本処理は行えません。" + "\r\n" +
                                        "再試行するか、しばらく待ってから再度処理を行ってください。",
                                        status,
                                        MessageBoxButtons.OK);
                                    break;
                                }
                            // 拠点ロックタイムアウト
                            case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                                {
                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,
                                        "DCHAT02102P",
                                        "更新に失敗しました。" + "\r\n"
                                        + "\r\n" +
                                        "シェアチェックエラー（拠点ロック）です。" + "\r\n" +
                                        "締処理か、処理が込み合っているためタイムアウトしました。" + "\r\n" +
                                        "再試行するか、しばらく待ってから再度処理を行ってください。",
                                        status,
                                        MessageBoxButtons.OK);
                                    break;
                                }
                            // 倉庫ロックタイムアウト
                            case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                                {
                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,
                                        "DCHAT02102P",
                                        "更新に失敗しました。" + "\r\n"
                                        + "\r\n" +
                                        "シェアチェックエラー（倉庫ロック）です。" + "\r\n" +
                                        "棚卸処理か、その他の在庫業務を行っているためタイムアウトしました。" + "\r\n" +
                                        "再試行するか、しばらく待ってから再度処理を行ってください。",
                                        status,
                                        MessageBoxButtons.OK);
                                    break;
                                }
                            default:
                                {
                                    MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        // "発注データの更新が失敗しました。",  // DEL pengjie 2013/03/14 REDMINE#34986 
                                        "発注データの更新が失敗しました。" + "ST=" + st, // ADD pengjie 2013/03/14 REDMINE#34986 
                                        st,
                                        MessageBoxButtons.OK,
                                        MessageBoxDefaultButton.Button1);
                                    break;
                                }
                        }
                        // --- CHG 2009/02/02 排他制御処理追加------------------------------------------------------<<<<<
#else
                    // 発注データ更新
                    DialogResult ret = MessageBox.Show("発注データを更新しますか？", "発注データ更新確認", MessageBoxButtons.YesNo);
                    if (ret == DialogResult.Yes)
                    {
                        // 印刷条件取得
                        OrderListCndtn extraInfo = (OrderListCndtn)this._printInfo.jyoken;
                        OrderListAcs orderListAcs = new OrderListAcs();
                        int st = orderListAcs.UpdateOrderDate(extraInfo.BlanketStockInputDataDiv);
                        if (st == 0)
                        {
                            MessageBox.Show("発注データの更新が完了しました。", "発注データ更新完了通知");
                        }
                        else
                        {
                            MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        "発注データの更新が失敗しました。",
                                        st,
                                        MessageBoxButtons.OK,
                                        MessageBoxDefaultButton.Button1);
                        }
#endif
                    }
                } // ADD 2017/09/14 譚洪 ハンディターミナル二次開発

                /*
                }
#if true
                // 印刷条件取得
                OrderListCndtn extraInfo = (OrderListCndtn)this._printInfo.jyoken;
                OrderListAcs orderListAcs = new OrderListAcs();
                int st = orderListAcs.UpdateOrderDate(extraInfo.BlanketStockInputDataDiv);
                if (st != 0)
                {
                    MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                "発注データの更新が失敗しました。",
                                st,
                                MessageBoxButtons.OK,
                                MessageBoxDefaultButton.Button1);
                }
#else
                // 発注データ更新
                DialogResult ret = MessageBox.Show("発注データを更新しますか？", "発注データ更新確認", MessageBoxButtons.YesNo);
                if (ret == DialogResult.Yes)
                {
                    // 印刷条件取得
                    OrderListCndtn extraInfo = (OrderListCndtn)this._printInfo.jyoken;
                    OrderListAcs orderListAcs = new OrderListAcs();
                    int st = orderListAcs.UpdateOrderDate(extraInfo.BlanketStockInputDataDiv);
                    if (st == 0)
                    {
                        MessageBox.Show("発注データの更新が完了しました。", "発注データ更新完了通知");
                    }
                    else
                    {
                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    "発注データの更新が失敗しました。",
                                    st,
                                    MessageBoxButtons.OK,
                                    MessageBoxDefaultButton.Button1);
                    }
                }                
#endif
                */
                // 2008.12.10 UPD 1:発注残一覧表の場合は処理を迂回 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

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
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
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
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
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
				throw new StockMoveException(asmname + "が存在しません。",-1);
			}
			catch(System.Exception er)
			{
				throw new StockMoveException(er.Message, -1);
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
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
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
            commonInfo.PrintMax = (this._printInfo.rdData as DataView).Count;
			
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
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// ActiveReportインターフェースにキャスト
			IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

			// 印刷条件取得
            OrderListCndtn extraInfo = (OrderListCndtn)this._printInfo.jyoken;

			// ソート順プロパティ設定
            instance.PageHeaderSortOderTitle = extraInfo.PrintSortDivTitle;
			
			// 帳票出力設定情報取得 
			PrtOutSet prtOutSet;
			string message;
			int st = OrderListAcs.ReadPrtOutSet(out prtOutSet, out message);
			if (st != 0) 
			{
                throw new StockMoveException(message, status);
            }

           
			
			// 抽出条件ヘッダ出力区分
			instance.ExtraCondHeadOutDiv = prtOutSet.ExtraCondHeadOutDiv;

            // 2008.09.03 30413 犬飼 抽出条件は印字しない >>>>>>START
            //// 抽出条件編集処理
            //StringCollection extraInfomations;
            //this.MakeExtarCondition( out extraInfomations );

            //instance.ExtraConditions = extraInfomations;
            // 2008.09.03 30413 犬飼 抽出条件は印字しない <<<<<<END
        
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
            object[] titleObj = new object[] { _printInfo.prpnm };
            instance.PageHeaderSubtitle = string.Format("{0}", titleObj);

			// その他データ
			instance.OtherDataList = null;

			status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			return status;
		}

		#endregion

        // 2008.09.03 30413 犬飼 抽出条件は印字しない >>>>>>START
        #region ◎ 抽出条件出力情報作成
        ///// <summary>
        ///// 抽出条件出力情報作成
        ///// </summary>
        ///// <param name="extraConditions">作成後抽出条件コレクション</param>
        ///// <remarks>
        ///// <br>Note       : 出力する抽出条件文字列を作成する。</br>
        ///// <br>Programmer : 22018 鈴木 正臣</br>
        ///// <br>Date       : 2007.09.19</br>
        ///// </remarks>
        //private void MakeExtarCondition( out StringCollection extraConditions )
        //{
        //    extraConditions = new StringCollection();
        //    StringCollection addConditions = new StringCollection();

        //    //-------------------------------------------------------------------------------------------------------
        //    // 入力日
        //    this.EditCondition(ref addConditions,
        //        GetExtarConditionOfDates("入力日", this._orderListCndtn.St_OrderDataCreateDate, this._orderListCndtn.Ed_OrderDataCreateDate));

        //    //-------------------------------------------------------------------------------------------------------
        //    // 発注日
        //    this.EditCondition(ref addConditions,
        //        GetExtarConditionOfDates("発注日", this._orderListCndtn.St_OrderFormPrintDate, this._orderListCndtn.St_OrderFormPrintDate));

        //    //-------------------------------------------------------------------------------------------------------
        //    // 希望納期
        //    this.EditCondition(ref addConditions,
        //        GetExtarConditionOfDates("希望納期", this._orderListCndtn.St_ExpectDeliveryDate, this._orderListCndtn.Ed_ExpectDeliveryDate));

        //    ////-------------------------------------------------------------------------------------------------------
        //    //// ソート順
        //    //this.EditCondition(ref addConditions, String.Format("ソート順：{0}",this._orderListCndtn.PrintSortDivTitle));

        //    //-------------------------------------------------------------------------------------------------------
        //    // 発注状態
        //    this.EditCondition( ref addConditions, String.Format( "発注状態：{0}", this._orderListCndtn.OrderFormIssuedDivTitle ) );

        //    //-------------------------------------------------------------------------------------------------------
        //    // 発注形態
        //    this.EditCondition( ref addConditions, String.Format( "発注形態：{0}", this._orderListCndtn.StockOrderDivCdTitle ) );


        //    //-------------------------------------------------------------------------------------------------------
        //    // 入荷状況
        //    this.EditCondition(ref addConditions, String.Format("入荷状況：{0}", this._orderListCndtn.ArrivalStateDivTitle));

        //    //-------------------------------------------------------------------------------------------------------
        //    // 担当者コード
        //    if ( ( !string.IsNullOrEmpty(this._orderListCndtn.St_StockAgentCode) ) || ( !string.IsNullOrEmpty(this._orderListCndtn.Ed_StockAgentCode) ) ) {
        //        this.EditCondition(ref addConditions,
        //            string.Format("担当者" + ct_RangeConst, this._orderListCndtn.St_StockAgentCode, this._orderListCndtn.Ed_StockAgentCode)
        //        );
        //    }
        //    //-------------------------------------------------------------------------------------------------------
        //    // 入力者コード
        //    if ( ( !string.IsNullOrEmpty(this._orderListCndtn.St_StockInputCode) ) || ( !string.IsNullOrEmpty(this._orderListCndtn.Ed_StockInputCode) ) ) {
        //        this.EditCondition(ref addConditions,
        //            string.Format("入力者" + ct_RangeConst, this._orderListCndtn.St_StockInputCode, this._orderListCndtn.Ed_StockInputCode)
        //        );
        //    }
        //    //-------------------------------------------------------------------------------------------------------
        //    // 発注先コード
        //    if ( ( this._orderListCndtn.St_SupplierCd != 0 ) || ( this._orderListCndtn.Ed_SupplierCd != 999999999 ) ) {
        //        this.EditCondition(ref addConditions,
        //            string.Format("発注先" + ct_RangeConst, this._orderListCndtn.St_SupplierCd, this._orderListCndtn.Ed_SupplierCd)
        //        );
        //    }
        //    //-------------------------------------------------------------------------------------------------------
        //    // 倉庫コード
        //    if ( ( !string.IsNullOrEmpty(this._orderListCndtn.St_WarehouseCode) ) || ( !string.IsNullOrEmpty(this._orderListCndtn.Ed_WarehouseCode) ) ) {
        //        this.EditCondition(ref addConditions,
        //            string.Format("倉庫" + ct_RangeConst, this._orderListCndtn.St_WarehouseCode, this._orderListCndtn.Ed_WarehouseCode)
        //        );
        //    }
        //    //-------------------------------------------------------------------------------------------------------
        //    // メーカーコード
        //    if ( ( this._orderListCndtn.St_GoodsMakerCd != 0 ) || ( this._orderListCndtn.Ed_GoodsMakerCd != 999999 ) ) {
        //        this.EditCondition(ref addConditions,
        //            string.Format("メーカー" + ct_RangeConst, this._orderListCndtn.St_GoodsMakerCd, this._orderListCndtn.Ed_GoodsMakerCd)
        //        );
        //    }
        //    //-------------------------------------------------------------------------------------------------------
        //    // 商品番号
        //    if ( ( !string.IsNullOrEmpty(this._orderListCndtn.St_GoodsNo) ) || ( !string.IsNullOrEmpty(this._orderListCndtn.Ed_GoodsNo) ) ) {
        //        this.EditCondition(ref addConditions,
        //            string.Format("商品番号" + ct_RangeConst, this._orderListCndtn.St_GoodsNo, this._orderListCndtn.Ed_GoodsNo)
        //        );
        //    }

        //    // 追加
        //    foreach ( string exCondStr in addConditions ) {
        //        extraConditions.Add(exCondStr);
        //    }
        //}
        // 2008.09.03 30413 犬飼 抽出条件は印字しない <<<<<<END
        
        /// <summary>
        /// 日付の範囲条件文字列生成
        /// </summary>
        /// <param name="dateTitle">日付タイトル</param>
        /// <param name="stDate">開始日付</param>
        /// <param name="edDate">終了日付</param>
        /// <returns></returns>
        private string GetExtarConditionOfDates( string dateTitle, DateTime stDate, DateTime edDate )
        {
            string wkStDate = string.Empty;
            string wkEdDate = string.Empty;

            string resultString = string.Empty;

            // 開始･終了のいずれかが入力されていれば印字
            if ( ( stDate != DateTime.MinValue ) || ( edDate != DateTime.MinValue ) ) {
                // 開始
                if ( stDate != DateTime.MinValue ) {
                    wkStDate = stDate.ToString("yyyy/MM/dd");
                }
                else {
                    wkStDate = ct_Extr_Top;
                }

                // 終了
                if ( edDate != DateTime.MinValue ) {
                    wkEdDate = edDate.ToString("yyyy/MM/dd");
                }
                else {
                    wkEdDate = ct_Extr_End;
                }

                resultString = string.Format( dateTitle + ct_RangeConst, wkStDate, wkEdDate);
            }

            return resultString;
        }
		#endregion

		#region ◎ 抽出範囲文字列作成
		/// <summary>
		/// 抽出範囲文字列作成
		/// </summary>
		/// <returns>作成文字列</returns>
		/// <remarks>
		/// <br>Note       : 抽出範囲文字列を作成します</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
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
				result = String.Format(title + ct_RangeConst, start, end);
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
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
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
					if (editArea[i] != null) editArea[i] += ct_Space;
					
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
		#endregion ◆ レポートフォーム設定関連

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
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "DCHAT02102P", iMsg, iSt, iButton, iDefButton);
		}

		#endregion
		#endregion
	}
}

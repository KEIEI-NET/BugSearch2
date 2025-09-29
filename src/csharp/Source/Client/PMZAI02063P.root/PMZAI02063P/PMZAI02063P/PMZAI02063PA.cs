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
using DataDynamics.ActiveReports;
using Broadleaf.Windows.Forms;
using System.Reflection;
using System.IO;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 委託在庫補充処理表印刷クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 委託在庫補充処理表の印刷を行う。</br>
	/// <br>Programmer : 30414 忍 幸史</br>
	/// <br>Date       : 2008/11/12</br>
    /// </remarks>
	class PMZAI02063PA: IPrintProc
    {
        # region ■ Private Const

        /// <summary> 印刷フォームネームスペース </summary>
        private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
        /// <summary> スペース(印刷用) </summary>
        private const string ct_Space = "　";
        /// <summary> 開始 抽出範囲初期値(印刷用) </summary>
        private const string ct_Extr_Top = "最初から";
        /// <summary> 終了 抽出範囲初期値(印刷用) </summary>
        private const string ct_Extr_End = "最後まで";

        # endregion ■ Private Const


        # region ■ Private Member

        /// <summary> 印刷情報クラス </summary>
        private SFCMN06002C _printInfo;
        /// <summary> 抽出条件クラス </summary>
        private TrustStockOrderCndtn _trustStockOrderCndtn;
        /// <summary> 委託在庫補充処理アクセスクラス </summary>
        private TrustStockOrderAcs _trustStockOrderAcs;

        # endregion ■ Private Member


        # region ■ Constructor
        /// <summary>
		/// 委託在庫補充処理表印刷クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 委託在庫補充処理表印刷クラスのインスタンスの作成を行う。</br>
		/// <br>Programmer : 30414 忍 幸史</br>
		/// <br>Date       : 2008/11/12</br>
		/// </remarks>
		public PMZAI02063PA()
		{
		}

		/// <summary>
		/// 委託在庫補充処理表印刷クラスコンストラクタ
		/// </summary>
		/// <param name="printInfo">印刷情報オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 委託在庫補充処理表印刷クラスのインスタンスの作成を行う。</br>
		/// <br>Programmer : 30414 忍 幸史</br>
		/// <br>Date       : 2008/11/12</br>
		/// </remarks>
		public PMZAI02063PA( object printInfo )
		{
			this._printInfo = printInfo as SFCMN06002C;
            this._trustStockOrderCndtn = this._printInfo.jyoken as TrustStockOrderCndtn;
            this._trustStockOrderAcs = new TrustStockOrderAcs();
        }
        # endregion ■ Constructor


        # region ■ IPrintProc インターフェース
        /// <summary>
		/// 印刷情報取得プロパティ
		/// </summary>
		public SFCMN06002C Printinfo
		{
			get { return this._printInfo; }
			set { this._printInfo = value;}
        }

        /// <summary>
		/// 印刷処理開始
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : 印刷を開始する。</br>
		/// <br>Programmer : 30414 忍 幸史</br>
		/// <br>Date       : 2008/11/12</br>
		/// </remarks>
		public int StartPrint()
		{
			// 印刷処理
			return PrintMain();
        }
        # endregion ■ IPrintProc インターフェース


        # region ■ Private Method
        /// <summary>
		/// 印刷処理
		/// </summary>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷処理を行う。</br>
		/// <br>Programmer : 30414 忍 幸史</br>
		/// <br>Date       : 2008/11/12</br>
		/// </remarks>
		private int PrintMain()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			// 印刷フォームクラスインスタンス作成
			ActiveReport3 prtRpt = null;
			
			try
			{
				// 各種ActiveReport帳票インスタンス作成
				CreateReport(out prtRpt, this._printInfo.prpid); 
				if (prtRpt == null) return status;

				// 各種プロパティ設定
				status = SettingProperty(ref prtRpt);
				if (status != 0) return status;
							
				// データソース設定
				prtRpt.DataSource = (DataView)this._printInfo.rdData;
                prtRpt.DataMember = PMZAI02069EA.ct_Tbl_TrustStockOrder;
				
				// 印刷共通情報プロパティ設定
				SFCMN00293UC commonInfo;
			    SetPrintCommonInfo(out commonInfo);

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
			            SFCMN00293UB processForm = new SFCMN00293UB();
						
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
			            SFCMN00293UA viewForm = new SFCMN00293UA();

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
			                    SFANL06101UA pdfHistoryControl = new SFANL06101UA();
			                    pdfHistoryControl.AddPrintInfo(this._printInfo.key, this._printInfo.prpnm, 
                                                               this._printInfo.prpnm, this._printInfo.pdftemppath);
			                }
			                break;
			            }
			        }
			    }
			}
			catch(Exception ex)
			{
			    MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP,
			                ex.Message, 
                            -1, 
                            MessageBoxButtons.OK, 
                            MessageBoxDefaultButton.Button1);
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

		/// <summary>
		/// 各種ActiveReport帳票インスタンス作成
		/// </summary>
		/// <param name="rptObj">インスタンス化された帳票フォームクラス</param>
		/// <param name="prpid">帳票フォームID</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
		/// <br>Programmer : 30414 忍 幸史</br>
		/// <br>Date       : 2008/11/12</br>
		/// </remarks>
		private void CreateReport(out DataDynamics.ActiveReports.ActiveReport3 rptObj,string prpid)
		{
			// 印刷フォームクラスインスタンス作成
			rptObj = (ActiveReport3)LoadAssemblyReport(prpid.Trim(), ct_ReportForm_NameSpace + "." + prpid.Trim(), typeof(ActiveReport3));
		}

		/// <summary>
		/// レポートアセンブリインスタンス化
		/// </summary>
		/// <param name="asmname">アセンブリ名称</param>
		/// <param name="classname">クラス名称</param>
		/// <param name="type">実装するクラス型</param>
		/// <returns>インスタンス化されたクラス</returns>
		/// <remarks>
		/// <br>Note       : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
		/// <br>Programmer : 30414 忍 幸史</br>
		/// <br>Date       : 2008/11/12</br>
		/// </remarks>
		private	object LoadAssemblyReport(string asmname, string classname, Type type)
		{
			object	obj	= null;
			try
			{
				Assembly asm = Assembly.Load(asmname);
				Type	objType	= asm.GetType(classname);
				if (objType != null)
				{
					if ((objType == type) || (objType.IsSubclassOf(type) == true) || (objType.GetInterface(type.Name).Name == type.Name))
					{
						obj = Activator.CreateInstance(objType);
					}
				}
			}
			catch(FileNotFoundException)
			{
				throw new ConfirmTrustStockOrderException(asmname + "が存在しません。", -1);
			}
			catch(Exception er)
			{
				throw new ConfirmTrustStockOrderException(er.Message, -1);
			}
			return obj;
		}

		/// <summary>
		/// 印刷画面共通情報設定
		/// </summary>
		/// <param name="commonInfo"></param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 印刷画面共通条件の設定を行います。</br>
		/// <br>Programmer : 30414 忍 幸史</br>
		/// <br>Date       : 2008/11/12</br>
		/// </remarks>
		private void SetPrintCommonInfo(out SFCMN00293UC commonInfo)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			commonInfo = new SFCMN00293UC();
			
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

		/// <summary>
		/// 各種プロパティ設定
		/// </summary>
		/// <param name="rpt">インスタンス化された帳票フォームクラス</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 各種プロパティを設定します。</br>
		/// <br>Programmer : 30414 忍 幸史</br>
		/// <br>Date       : 2008/11/12</br>
		/// </remarks>
		private int SettingProperty(ref ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// ActiveReportインターフェースにキャスト
			IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

			// 印刷条件取得
            TrustStockOrderCndtn extraInfo = (TrustStockOrderCndtn)this._printInfo.jyoken;

			// 帳票出力設定情報取得 
			PrtOutSet prtOutSet = new PrtOutSet();
			string message;
            int st = this._trustStockOrderAcs.ReadPrtOutSet(out prtOutSet, out message);
            if (st != 0)
            {
                throw new ConfirmTrustStockOrderException(message, status);
            }
			
			// 抽出条件ヘッダ出力区分
			instance.ExtraCondHeadOutDiv = prtOutSet.ExtraCondHeadOutDiv;

			// 抽出条件編集処理
			StringCollection extraInfomations;
			MakeExtarCondition( out extraInfomations );

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

			status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			return status;
		}

		/// <summary>
		/// 抽出条件出力情報作成
		/// </summary>
		/// <param name="extraConditions">作成後抽出条件コレクション</param>
		/// <remarks>
		/// <br>Note       : 出力する抽出条件文字列を作成する。</br>
		/// <br>Programmer : 30414 忍 幸史</br>
		/// <br>Date       : 2008/11/12</br>
		/// </remarks>
		private void MakeExtarCondition( out StringCollection extraConditions )
		{
            //const string ct_RangeConst = "：{0} ～ {1}";
			extraConditions = new StringCollection();

            string strTarget;

            // 補充更新
            strTarget = "";
            if (this._trustStockOrderCndtn.StockUpdate == 0)
            {
                strTarget = "補充更新：する";
            }
            else
            {
                strTarget = "補充更新：しない";
            }
            EditCondition(ref extraConditions, strTarget);

            // 補充元在庫不足時
            strTarget = "";
            switch (this._trustStockOrderCndtn.ReplenishLackStock)
            {
                case 0:
                    {
                        strTarget = "補充元在庫不足時：未更新";
                        break;
                    }
                case 1:
                    {
                        strTarget = "補充元在庫不足時：無視して更新";
                        break;
                    }
                case 2:
                    {
                        strTarget = "補充元在庫不足時：ゼロまで更新";
                        break;
                    }
            }
            EditCondition(ref extraConditions, strTarget);

            // 補充元商品無し時
            strTarget = "";
            if (this._trustStockOrderCndtn.ReplenishNoneGoods == 0)
            {
                strTarget = "補充元商品無し時：未更新";
            }
            else
            {
                strTarget = "補充元商品無し時：無視して更新";
            }
            EditCondition(ref extraConditions, strTarget);
            
            // 委託倉庫
            strTarget = "";
            if ((this._trustStockOrderCndtn.St_WarehouseCode.Trim() == "") && (this._trustStockOrderCndtn.Ed_WarehouseCode.Trim() == ""))
            {
                strTarget = "";
            }
            else if ((this._trustStockOrderCndtn.St_WarehouseCode.Trim() != "") && (this._trustStockOrderCndtn.Ed_WarehouseCode.Trim() != ""))
            {
                strTarget = "委託倉庫：" + 
                            this._trustStockOrderCndtn.St_WarehouseCode.Trim().PadLeft(4, '0') + "～" +
                            this._trustStockOrderCndtn.Ed_WarehouseCode.Trim().PadLeft(4, '0');
            }
            else if (this._trustStockOrderCndtn.St_WarehouseCode.Trim() != "")
            {
                strTarget = "委託倉庫：" +
                            this._trustStockOrderCndtn.St_WarehouseCode.Trim().PadLeft(4, '0') + "～" + ct_Extr_End;
            }
            else if (this._trustStockOrderCndtn.Ed_WarehouseCode.Trim() != "")
            {
                strTarget = "委託倉庫：" + 
                            ct_Extr_Top + "～" + this._trustStockOrderCndtn.Ed_WarehouseCode.Trim().PadLeft(4, '0');
            }
            EditCondition(ref extraConditions, strTarget);

            // メーカー
            strTarget = "";
            if ((this._trustStockOrderCndtn.St_GoodsMakerCd == 0) && (this._trustStockOrderCndtn.Ed_GoodsMakerCd == 0))
            {
                strTarget = "";
            }
            else if ((this._trustStockOrderCndtn.St_GoodsMakerCd != 0) && (this._trustStockOrderCndtn.Ed_GoodsMakerCd != 0))
            {
                strTarget = "メーカー：" +
                            this._trustStockOrderCndtn.St_GoodsMakerCd.ToString("0000") + "～" +
                            this._trustStockOrderCndtn.Ed_GoodsMakerCd.ToString("0000");
            }
            else if (this._trustStockOrderCndtn.St_GoodsMakerCd != 0)
            {
                strTarget = "メーカー：" +
                            this._trustStockOrderCndtn.St_GoodsMakerCd.ToString("0000") + "～" + ct_Extr_End;
            }
            else if (this._trustStockOrderCndtn.Ed_GoodsMakerCd != 0)
            {
                strTarget = "メーカー：" +
                            ct_Extr_Top + "～" + this._trustStockOrderCndtn.Ed_GoodsMakerCd.ToString("0000");
            }
            EditCondition(ref extraConditions, strTarget);

            // 品番
            strTarget = "";
            if ((this._trustStockOrderCndtn.St_GoodsNo.Trim() == "") && (this._trustStockOrderCndtn.Ed_GoodsNo.Trim() == ""))
            {
                strTarget = "";
            }
            else if ((this._trustStockOrderCndtn.St_GoodsNo.Trim() != "") && (this._trustStockOrderCndtn.Ed_GoodsNo.Trim() != ""))
            {
                strTarget = "品番：" +
                            this._trustStockOrderCndtn.St_GoodsNo.Trim().PadLeft(4, '0') + "～" +
                            this._trustStockOrderCndtn.Ed_GoodsNo.Trim().PadLeft(4, '0');
            }
            else if (this._trustStockOrderCndtn.St_GoodsNo.Trim() != "")
            {
                strTarget = "品番：" +
                            this._trustStockOrderCndtn.St_GoodsNo.Trim().PadLeft(4, '0') + "～" + ct_Extr_End;
            }
            else if (this._trustStockOrderCndtn.Ed_GoodsNo.Trim() != "")
            {
                strTarget = "品番：" +
                            ct_Extr_Top + "～" + this._trustStockOrderCndtn.Ed_GoodsNo.Trim().PadLeft(4, '0');
            }
            EditCondition(ref extraConditions, strTarget);
		}

		/// <summary>
		/// 抽出範囲文字列作成
		/// </summary>
		/// <returns>作成文字列</returns>
		/// <remarks>
		/// <br>Note       : 抽出範囲文字列を作成します</br>
		/// <br>Programmer : 30414 忍 幸史</br>
		/// <br>Date       : 2007.03.14</br>
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

		/// <summary>
		/// 抽出条件文字列編集
		/// </summary>
		/// <param name="editArea">格納エリア</param>
		/// <param name="target">対象文字列</param>
		/// <remarks>
		/// <br>Note       : 出力する抽出条件文字列を編集します。</br>
		/// <br>Programmer : 30414 忍 幸史</br>
		/// <br>Date       : 2008/11/12</br>
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
		/// <br>Programmer : 22013 久保 将太</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "PMZAI02063P", iMsg, iSt, iButton, iDefButton);
        }
        #endregion ■ Private Methods


        # region ■ Exception Class
        /// <summary> 例外クラス </summary>
        private class ConfirmTrustStockOrderException : ApplicationException
        {
            private int _status;
            # region Constructor
            /// <summary>
            /// 例外クラスコンストラクタ
            /// </summary>
            /// <param name="message">メッセージ</param>
            /// <param name="status">ステータス</param>
            public ConfirmTrustStockOrderException(string message, int status)
                : base(message)
            {
                this._status = status;
            }
            # endregion

            # region Public Property
            /// <summary> ステータスプロパティ </summary>
            public int Status
            {
                get { return this._status; }
            }
            # endregion
        }
        # endregion ■ Exception Class
    }
}

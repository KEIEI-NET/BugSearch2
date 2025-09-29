//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：出荷商品分析表
// プログラム概要   ：出荷商品分析表を印刷・PDF出力を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30452 上野 俊治
// 修正日    2008/10/20     修正内容：Partsman用に変更
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30452 上野 俊治
// 修正日    2009/03/24     修正内容：障害対応12687
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/10     修正内容：Mantis【13128】残案件No.19 端数処理
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30517 夏野 駿希
// 修正日    2009/09/24     修正内容：Mantis【14238】抽出条件に在庫・取寄を指定しても印刷される
// ---------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 李小路
// 修 正 日  2012/05/22  修正内容 : 2012/06/27配信分、Redmine#29911
//                                  出荷商品分析表 全社集計時の集約不正の対応
//----------------------------------------------------------------------------//
// 管理番号  11070263-00 作成担当 : 尹晶晶
// 修 正 日  2014/12/22  修正内容 : 改良分、Redmine#44209
//                                  明治産業様Seiken品番変更
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// 出荷商品分析表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 出荷商品分析表で使用するデータを取得する。</br>
    /// <br>Programmer   : 20081 疋田 勇人</br>
    /// <br>Date         : 2007.12.03</br>
    /// <br></br>
    /// <br>UpdateNote   : エラーになる対応。</br>
    /// <br>             : 売上金額に原価金額が集計され、原価金額が0になる対応。</br>
    /// <br>             : BLコード・BL商品名がセットされていない対応。</br>
    /// <br>Programmer   : 980081 山田 明友</br>
    /// <br>Date         : 2008.04.02</br>
    /// <br>Update Note  : 2008.10.20 30452 上野 俊治</br>
    /// <br>              ・PM.NS対応</br>
    /// <br>Update Note  : 2009/03/24 30452 上野 俊治</br>
    /// <br>              ・障害対応12687</br>
    /// <br>Update Note: 2012/05/22 李小路</br>
    /// <br>管理番号   ：10801804-00 2012/06/27配信分</br>
    /// <br>             Redmine#29911　出荷商品分析表 全社集計時の集約不正の対応</br>
    /// <br>Update Note  : 2014/12/22 尹晶晶</br>
    /// <br>管理番号     : 11070263-00</br>
    /// <br>             :・明治産業様Seiken品番変更</br>
    /// </remarks>
	public class ShipGoodsAnalyzeListAcs
	{
		#region ■ Constructor
		/// <summary>
		/// 出荷商品分析表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 出荷商品分析表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.12.03</br>
		/// </remarks>
		public ShipGoodsAnalyzeListAcs()
		{
            this._iShipGoodsAnalyzeDB = (IShipGoodsAnalyzeDB)MediationShipGoodsAnalyzeDB.GetShipGoodsAnalyzeDB();
		}

		/// <summary>
		/// 出荷商品分析表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 出荷商品分析表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.12.03</br>
		/// </remarks>
        static ShipGoodsAnalyzeListAcs ()
		{
			stc_Employee		= null;
			stc_PrtOutSet		= null;					// 帳票出力設定データクラス
			stc_PrtOutSetAcs	= new PrtOutSetAcs();	// 帳票出力設定アクセスクラス

            stc_SecInfoAcs      = new SecInfoAcs(1);    // 拠点アクセスクラス
            stc_SectionDic      = new Dictionary<string,SecInfoSet>();

			// ログイン拠点取得
		    Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
		    if (loginEmployee != null)
		    {
				stc_Employee = loginEmployee.Clone();
		    }

            // 拠点Dictionary生成
            SecInfoSet[] secInfoSecList = stc_SecInfoAcs.SecInfoSetList;

            foreach ( SecInfoSet secInfoSet in secInfoSecList ) {
                // 既存でなければ
                if (! stc_SectionDic.ContainsKey(secInfoSet.SectionCode) ) {
                    // 追加
                    stc_SectionDic.Add( secInfoSet.SectionCode, secInfoSet );
                }
            }
		}
		#endregion ■ Constructor

		#region ■ Static Member
		private static Employee stc_Employee;
		private static PrtOutSet stc_PrtOutSet;			// 帳票出力設定データクラス
		private static PrtOutSetAcs stc_PrtOutSetAcs;	// 帳票出力設定アクセスクラス

        private static SecInfoAcs stc_SecInfoAcs;                       // 拠点アクセスクラス
        private static Dictionary<string,SecInfoSet> stc_SectionDic;    // 拠点Dictionary
		#endregion ■ Static Member

		#region ■ Private Member
        IShipGoodsAnalyzeDB _iShipGoodsAnalyzeDB;

		private DataTable _shipGoodsAnalyzeListDt;		  // 印刷DataTable
		private DataView  _shipGoodsAnalyzeListDataView;  // 印刷DataView

		#endregion ■ Private Member

		#region ■ Public Property
		/// <summary>
		/// 印刷データセット(読み取り専用)
		/// </summary>
		public DataView ShipGoodsAnalyzeListDataView
		{
			get{ return this._shipGoodsAnalyzeListDataView; }
		}
		#endregion ■ Public Property

		#region ■ Public Method
		#region ◆ 出力データ取得
		#region ◎ 入金データ取得
		/// <summary>
		/// データ取得
		/// </summary>
		/// <param name="extrInfo_ShipGoodsAnalyze">抽出条件</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷するデータを取得する。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.12.03</br>
		/// </remarks>
        public int SearchMain( ExtrInfo_ShipGoodsAnalyze extrInfo_ShipGoodsAnalyze, out string errMsg)
		{
            return this.SearchProc(extrInfo_ShipGoodsAnalyze, out errMsg);
		}
		#endregion
		#endregion ◆ 出力データ取得
		#endregion ■ Public Method

		#region ■ Private Method
		#region ◆ 帳票データ取得
		#region ◎ 在庫移動データ取得
		/// <summary>
		/// 在庫移動データ取得
		/// </summary>
		/// <param name="extrInfo_ShipGoodsAnalyze"></param>
		/// <param name="errMsg"></param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷する在庫移動データを取得する。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.12.03</br>
		/// </remarks>
        private int SearchProc( ExtrInfo_ShipGoodsAnalyze extrInfo_ShipGoodsAnalyze, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			errMsg = "";

			try
			{
				// DataTable Create ----------------------------------------------------------
				DCTOK02054EA.CreateDataTable( ref this._shipGoodsAnalyzeListDt );

                ExtrInfo_ShipGoodsAnalyzeWork extrInfo_ShipGoodsAnalyzeWork = new ExtrInfo_ShipGoodsAnalyzeWork();
				// 抽出条件展開  --------------------------------------------------------------
				status = this.DevShipMoveCndtn( extrInfo_ShipGoodsAnalyze, out extrInfo_ShipGoodsAnalyzeWork, out errMsg );
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					return status;
				}

				// データ取得  ----------------------------------------------------------------
				object retShipMoveList = null;

                //status = this._iShipGoodsAnalyzeDB.SearchShipGoodsAnalyze(out retShipMoveList, extrInfo_ShipGoodsAnalyzeWork); // DEL 2008/10/20
                status = this._iShipGoodsAnalyzeDB.SearchShipGoodsAnalyze(out retShipMoveList, extrInfo_ShipGoodsAnalyzeWork, ConstantManagement.LogicalMode.GetData0); // ADD 2008/10/20

                // テスト用
                //status = this.testproc(out retShipMoveList);

				switch ( status )
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						// データ展開処理
						DevShipMoveData( extrInfo_ShipGoodsAnalyze, (ArrayList)retShipMoveList );
						status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
						break;
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
						status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
						break;
					default:
						errMsg = "商品別売上集計データの取得に失敗しました。";
						break;
				}
			}
			catch ( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}
		#endregion
		#endregion ◆ 帳票データ取得

		#region ◆ データ展開処理
		#region ◎ 抽出条件展開処理
		/// <summary>
		/// 抽出条件展開処理
		/// </summary>
		/// <param name="extrInfo_ShipGoodsAnalyze">UI抽出条件クラス</param>
		/// <param name="extrInfo_ShipGoodsAnalyzeWork">リモート抽出条件クラス</param>
		/// <param name="errMsg">errMsg</param>
		/// <returns>Status</returns>
        private int DevShipMoveCndtn( ExtrInfo_ShipGoodsAnalyze extrInfo_ShipGoodsAnalyze, out ExtrInfo_ShipGoodsAnalyzeWork extrInfo_ShipGoodsAnalyzeWork, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;
            extrInfo_ShipGoodsAnalyzeWork = new ExtrInfo_ShipGoodsAnalyzeWork();
			try
			{
                extrInfo_ShipGoodsAnalyzeWork.EnterpriseCode = extrInfo_ShipGoodsAnalyze.EnterpriseCode;  // 企業コード
				// 抽出条件パラメータセット
				if ( extrInfo_ShipGoodsAnalyze.SecCodeList.Length != 0 )
				{
                    // ↓ 2008.04.03 980081 c
                    //if (extrInfo_ShipGoodsAnalyze.IsSelectAllSection)
                    if (extrInfo_ShipGoodsAnalyze.SecCodeList[0].ToString() == "0")
                    // ↑ 2008.04.03 980081 c
				    {
				        // 全社の時
                        //extrInfo_ShipGoodsAnalyzeWork.SecCodeList = null; // DEL 2008/10/20
                        extrInfo_ShipGoodsAnalyzeWork.SectionCodes = null; // ADD 2008/10/20
				    }
				    else
				    {
                        //extrInfo_ShipGoodsAnalyzeWork.SecCodeList = extrInfo_ShipGoodsAnalyze.SecCodeList; // DEL 2008/10/20
                        extrInfo_ShipGoodsAnalyzeWork.SectionCodes = extrInfo_ShipGoodsAnalyze.SecCodeList; // ADD 2008/10/20
				    }
				}
				else
				{
                    //extrInfo_ShipGoodsAnalyzeWork.SecCodeList = null; // DEL 2008/10/20
                    extrInfo_ShipGoodsAnalyzeWork.SectionCodes = null; // ADD 2008/10/20
				}

                // --- DEL 2008/10/20 -------------------------------->>>>>
                //extrInfo_ShipGoodsAnalyzeWork.St_AddUpYearMonth = extrInfo_ShipGoodsAnalyze.St_AddUpYearMonth;        // 開始年月度
                //extrInfo_ShipGoodsAnalyzeWork.Ed_AddUpYearMonth = extrInfo_ShipGoodsAnalyze.Ed_AddUpYearMonth;        // 終了年月度
                //extrInfo_ShipGoodsAnalyzeWork.Ex_StockCreateDate = extrInfo_ShipGoodsAnalyze.Ex_StockCreateDate;       // 在庫登録日
                //extrInfo_ShipGoodsAnalyzeWork.St_GoodsMakerCd = extrInfo_ShipGoodsAnalyze.St_GoodsMakerCd;          // 開始商品メーカーコード
                //extrInfo_ShipGoodsAnalyzeWork.Ed_GoodsMakerCd = extrInfo_ShipGoodsAnalyze.Ed_GoodsMakerCd;          // 終了商品メーカーコード
                //extrInfo_ShipGoodsAnalyzeWork.St_LargeGoodsGanreCode = extrInfo_ShipGoodsAnalyze.St_LargeGoodsGanreCode;   // 開始商品区分グループコード
                //extrInfo_ShipGoodsAnalyzeWork.Ed_LargeGoodsGanreCode = extrInfo_ShipGoodsAnalyze.Ed_LargeGoodsGanreCode;   // 終了商品区分グループコード
                //extrInfo_ShipGoodsAnalyzeWork.St_MediumGoodsGanreCode = extrInfo_ShipGoodsAnalyze.St_MediumGoodsGanreCode;  // 開始商品区分コード
                //extrInfo_ShipGoodsAnalyzeWork.Ed_MediumGoodsGanreCode = extrInfo_ShipGoodsAnalyze.Ed_MediumGoodsGanreCode;  // 終了商品区分コード
                //extrInfo_ShipGoodsAnalyzeWork.St_DetailGoodsGanreCode = extrInfo_ShipGoodsAnalyze.St_DetailGoodsGanreCode;  // 開始商品区分詳細コード
                //extrInfo_ShipGoodsAnalyzeWork.Ed_DetailGoodsGanreCode = extrInfo_ShipGoodsAnalyze.Ed_DetailGoodsGanreCode;  // 終了商品区分詳細コード
                //extrInfo_ShipGoodsAnalyzeWork.St_BLGoodsCode = extrInfo_ShipGoodsAnalyze.St_BLGoodsCode;           // 開始ＢＬ商品コード
                //extrInfo_ShipGoodsAnalyzeWork.Ed_BLGoodsCode = extrInfo_ShipGoodsAnalyze.Ed_BLGoodsCode;           // 終了ＢＬ商品コード
                //extrInfo_ShipGoodsAnalyzeWork.St_GoodsNo = extrInfo_ShipGoodsAnalyze.St_GoodsNo;               // 開始商品番号
                //extrInfo_ShipGoodsAnalyzeWork.Ed_GoodsNo = extrInfo_ShipGoodsAnalyze.Ed_GoodsNo;               // 終了商品番号
                //extrInfo_ShipGoodsAnalyzeWork.TotalWay = extrInfo_ShipGoodsAnalyze.TotalWay;                 // 集計方法
                //extrInfo_ShipGoodsAnalyzeWork.BeforeAfter = (int)extrInfo_ShipGoodsAnalyze.BeforeAfterDiv;      // 在庫登録日指定区分
                //extrInfo_ShipGoodsAnalyzeWork.Ex_SalesOrderDiv = (int)extrInfo_ShipGoodsAnalyze.SalesOrderDiv;       // 在取指定                
                //extrInfo_ShipGoodsAnalyzeWork.RankSection = (int)extrInfo_ShipGoodsAnalyze.RankSection;         // 順位設定(拠点集計)
                //extrInfo_ShipGoodsAnalyzeWork.RankHighLow = (int)extrInfo_ShipGoodsAnalyze.RankHighLow;         // 順位設定(上位・下位)
                //extrInfo_ShipGoodsAnalyzeWork.RankCount = extrInfo_ShipGoodsAnalyze.RankOrderMax;             // 順位設定(指定順位)
                //extrInfo_ShipGoodsAnalyzeWork.RankItem = (int)extrInfo_ShipGoodsAnalyze.OrderPrintDiv;       // 印刷順
                // --- DEL 2008/10/20 --------------------------------<<<<<
                // --- ADD 2008/10/20 -------------------------------->>>>>
                extrInfo_ShipGoodsAnalyzeWork.TtlType = (int)extrInfo_ShipGoodsAnalyze.TtlType;
                extrInfo_ShipGoodsAnalyzeWork.St_AddUpYearMonth = extrInfo_ShipGoodsAnalyze.St_AddUpYearMonth;
                extrInfo_ShipGoodsAnalyzeWork.Ed_AddUpYearMonth = extrInfo_ShipGoodsAnalyze.Ed_AddUpYearMonth;
                extrInfo_ShipGoodsAnalyzeWork.Ex_StockCreateDate = extrInfo_ShipGoodsAnalyze.Ex_StockCreateDate;
                extrInfo_ShipGoodsAnalyzeWork.BeforeAfter = (int)extrInfo_ShipGoodsAnalyze.BeforeAfterDiv;
                extrInfo_ShipGoodsAnalyzeWork.RsltTtlDivCd = (int)extrInfo_ShipGoodsAnalyze.RsltTtlDiv;
                //------ ADD START 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                extrInfo_ShipGoodsAnalyzeWork.GoodsNoTtlDiv = (int)extrInfo_ShipGoodsAnalyze.GoodsNoTtlDiv;       // 品番集計区分
                if (extrInfo_ShipGoodsAnalyzeWork.GoodsNoTtlDiv == 1)
                {
                    extrInfo_ShipGoodsAnalyzeWork.GoodsNoShowDiv = (int)extrInfo_ShipGoodsAnalyze.GoodsNoShowDiv;     // 品番表示区分
                }
                //------ ADD END 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------<<<<<
                extrInfo_ShipGoodsAnalyzeWork.SupplierCdSt = extrInfo_ShipGoodsAnalyze.St_SupplierCd;
                if (extrInfo_ShipGoodsAnalyze.Ed_SupplierCd == 0)
                {
                    extrInfo_ShipGoodsAnalyzeWork.SupplierCdEd = 999999;
                }
                else
                {
                    extrInfo_ShipGoodsAnalyzeWork.SupplierCdEd = extrInfo_ShipGoodsAnalyze.Ed_SupplierCd;
                }
                extrInfo_ShipGoodsAnalyzeWork.GoodsMakerCdSt = extrInfo_ShipGoodsAnalyze.St_GoodsMakerCd;
                if (extrInfo_ShipGoodsAnalyze.Ed_GoodsMakerCd == 0)
                {
                    extrInfo_ShipGoodsAnalyzeWork.GoodsMakerCdEd = 9999;
                }
                else
                {
                    extrInfo_ShipGoodsAnalyzeWork.GoodsMakerCdEd = extrInfo_ShipGoodsAnalyze.Ed_GoodsMakerCd;
                }
                extrInfo_ShipGoodsAnalyzeWork.GoodsLGroupSt = extrInfo_ShipGoodsAnalyze.St_GoodsLGroup;
                if (extrInfo_ShipGoodsAnalyze.Ed_GoodsLGroup == 0)
                {
                    extrInfo_ShipGoodsAnalyzeWork.GoodsLGroupEd = 9999;
                }
                else
                {
                    extrInfo_ShipGoodsAnalyzeWork.GoodsLGroupEd = extrInfo_ShipGoodsAnalyze.Ed_GoodsLGroup;
                }
                extrInfo_ShipGoodsAnalyzeWork.GoodsMGroupSt = extrInfo_ShipGoodsAnalyze.St_GoodsMGroup;
                if (extrInfo_ShipGoodsAnalyze.Ed_GoodsMGroup == 0)
                {
                    extrInfo_ShipGoodsAnalyzeWork.GoodsMGroupEd = 9999;
                }
                else
                {
                    extrInfo_ShipGoodsAnalyzeWork.GoodsMGroupEd = extrInfo_ShipGoodsAnalyze.Ed_GoodsMGroup;
                }
                extrInfo_ShipGoodsAnalyzeWork.BLGroupCodeSt = extrInfo_ShipGoodsAnalyze.St_BLGroupCode;
                if (extrInfo_ShipGoodsAnalyze.Ed_BLGroupCode == 0)
                {
                    extrInfo_ShipGoodsAnalyzeWork.BLGroupCodeEd = 99999;
                }
                else
                {
                    extrInfo_ShipGoodsAnalyzeWork.BLGroupCodeEd = extrInfo_ShipGoodsAnalyze.Ed_BLGroupCode;
                }
                extrInfo_ShipGoodsAnalyzeWork.BLGoodsCodeSt = extrInfo_ShipGoodsAnalyze.St_BLGoodsCode;
                if (extrInfo_ShipGoodsAnalyze.Ed_BLGoodsCode == 0)
                {
                    extrInfo_ShipGoodsAnalyzeWork.BLGoodsCodeEd = 99999;
                }
                else
                {
                    extrInfo_ShipGoodsAnalyzeWork.BLGoodsCodeEd = extrInfo_ShipGoodsAnalyze.Ed_BLGoodsCode;
                }
                extrInfo_ShipGoodsAnalyzeWork.GoodsNoSt = extrInfo_ShipGoodsAnalyze.St_GoodsNo;
                extrInfo_ShipGoodsAnalyzeWork.GoodsNoEd = extrInfo_ShipGoodsAnalyze.Ed_GoodsNo;
                // --- ADD 2008/10/20 --------------------------------<<<<<
   			}
			catch ( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}
		#endregion

		#region ◎ 取得データ展開処理
		/// <summary>
		/// 取得データ展開処理
		/// </summary>
		/// <param name="extrInfo_ShipGoodsAnalyze">UI抽出条件クラス</param>
		/// <param name="listWork">取得データ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 取得データを展開する。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.12.03</br>
        /// <br>Update Note: 2012/05/22 李小路</br>
        /// <br>管理番号   ：10801804-00 2012/06/27配信分</br>
        /// <br>             Redmine#29911　出荷商品分析表 全社集計時の集約不正の対応</br>
		/// </remarks>
        private void DevShipMoveData( ExtrInfo_ShipGoodsAnalyze extrInfo_ShipGoodsAnalyze, ArrayList listWork)
		{
            // 金額単位取得
            //double moneyUnit = GetMoneyUnit(extrInfo_ShipGoodsAnalyze); // DEL 2008/10/20

			DataRow dr;

            foreach ( RsltInfo_ShipGoodsAnalyzeWork rsltInfo_ShipGoodsAnalyzeWork in listWork)
			{
				dr = this._shipGoodsAnalyzeListDt.NewRow();
				// 取得データ展開
				#region 取得データ展開

                // --- DEL 2008/10/20 -------------------------------->>>>>
                //dr[DCTOK02054EA.ct_Col_SectionCode] = rsltInfo_ShipGoodsAnalyzeWork.AddUpSecCode;                         // 拠点コード
                //dr[DCTOK02054EA.ct_Col_SectionGuideNm] = rsltInfo_ShipGoodsAnalyzeWork.SectionGuideNm;                       // 拠点ガイド名称
                //dr[DCTOK02054EA.ct_Col_GoodsMakerCd] = rsltInfo_ShipGoodsAnalyzeWork.GoodsMakerCd;                         // 商品メーカーコード
                //dr[DCTOK02054EA.ct_Col_MakerName] = rsltInfo_ShipGoodsAnalyzeWork.MakerName;                            // メーカー名称
                //dr[DCTOK02054EA.ct_Col_LargeGoodsGanreCode] = rsltInfo_ShipGoodsAnalyzeWork.LargeGoodsGanreCode;                  // 商品区分グループコード
                //dr[DCTOK02054EA.ct_Col_LargeGoodsGanreName] = rsltInfo_ShipGoodsAnalyzeWork.LargeGoodsGanreName;                  // 商品区分グループ名称
                //dr[DCTOK02054EA.ct_Col_MediumGoodsGanreCode] = rsltInfo_ShipGoodsAnalyzeWork.MediumGoodsGanreCode;                 // 商品区分コード
                //dr[DCTOK02054EA.ct_Col_MediumGoodsGanreName] = rsltInfo_ShipGoodsAnalyzeWork.MediumGoodsGanreName;                 // 商品区分名称
                //dr[DCTOK02054EA.ct_Col_DetailGoodsGanreCode] = rsltInfo_ShipGoodsAnalyzeWork.DetailGoodsGanreCode;                 // 商品区分詳細コード
                //dr[DCTOK02054EA.ct_Col_DetailGoodsGanreName] = rsltInfo_ShipGoodsAnalyzeWork.DetailGoodsGanreName;                 // 商品区分詳細名称
                //// ↓ 2008.04.02 980081 a
                //dr[DCTOK02054EA.ct_Col_BLGoodsCode] = rsltInfo_ShipGoodsAnalyzeWork.BLGoodsCode;                          // BL商品コード
                //dr[DCTOK02054EA.ct_Col_BLGoodsFullName] = rsltInfo_ShipGoodsAnalyzeWork.BLGoodsFullName;                      // BL商品コード名称（全角）
                //// ↑ 2008.04.02 980081 a
                //dr[DCTOK02054EA.ct_Col_GoodsNo] = rsltInfo_ShipGoodsAnalyzeWork.GoodsNo;                              // 商品番号
                //dr[DCTOK02054EA.ct_Col_GoodsShortName] = rsltInfo_ShipGoodsAnalyzeWork.GoodsShortName;                       // 商品略称
                //dr[DCTOK02054EA.ct_Col_StockCreateDate] = rsltInfo_ShipGoodsAnalyzeWork.StockCreateDate.ToString("yy/MM/dd"); // 在庫登録日
                //dr[DCTOK02054EA.ct_Col_SupplierStock] = rsltInfo_ShipGoodsAnalyzeWork.SupplierStock;                        // 仕入在庫数
                //dr[DCTOK02054EA.ct_Col_MinimumStockCnt] = rsltInfo_ShipGoodsAnalyzeWork.MinimumStockCnt;                      // 最低在庫数
                //dr[DCTOK02054EA.ct_Col_MaximumStockCnt] = rsltInfo_ShipGoodsAnalyzeWork.MaximumStockCnt;                      // 最高在庫数
                //dr[DCTOK02054EA.ct_Col_TotalCount] = rsltInfo_ShipGoodsAnalyzeWork.TotalCount;                           // 売上数計
                //dr[DCTOK02054EA.ct_Col_StockCount] = rsltInfo_ShipGoodsAnalyzeWork.StockCount;                           // 売上数計(在庫)
                //dr[DCTOK02054EA.ct_Col_OrderCount] = rsltInfo_ShipGoodsAnalyzeWork.OrderCount;                           // 売上数計(取寄)
                //dr[DCTOK02054EA.ct_Col_SalesMoney] = Math.Floor((double)rsltInfo_ShipGoodsAnalyzeWork.SalesMoney / moneyUnit); // 売上金額
                //// ↓ 2008.04.02 980081 c
                ////dr[DCTOK02054EA.ct_Col_SalesMoney] = Math.Floor((double)rsltInfo_ShipGoodsAnalyzeWork.GrossMoney / moneyUnit); // 粗利金額
                //dr[DCTOK02054EA.ct_Col_GrossMoney] = Math.Floor((double)rsltInfo_ShipGoodsAnalyzeWork.GrossMoney / moneyUnit); // 粗利金額
                //// ↑ 2008.04.02 980081 c
                //dr[DCTOK02054EA.ct_Col_GrossMarginRate] = rsltInfo_ShipGoodsAnalyzeWork.GrossMarginRate;                      // 粗利率
                //if (extrInfo_ShipGoodsAnalyze.RankHighLow == ExtrInfo_ShipGoodsAnalyze.RankHighLowState.High)
                //{
                //    dr[DCTOK02054EA.ct_Col_RankTotalCount] = rsltInfo_ShipGoodsAnalyzeWork.HighRankTotalCount;                   // 売上数順位(上位)
                //    dr[DCTOK02054EA.ct_Col_RankSalesMoney] = rsltInfo_ShipGoodsAnalyzeWork.HighRankSalesMoney;                   // 売上金額順位(上位)
                //    dr[DCTOK02054EA.ct_Col_RankGrossMoney] = rsltInfo_ShipGoodsAnalyzeWork.HighRankGrossMoney;                   // 粗利金額順位(上位)
                //}
                //else
                //{
                //    dr[DCTOK02054EA.ct_Col_RankTotalCount] = rsltInfo_ShipGoodsAnalyzeWork.LowRankTotalCount;                    // 売上数順位(下位)
                //    dr[DCTOK02054EA.ct_Col_RankSalesMoney] = rsltInfo_ShipGoodsAnalyzeWork.LowRankSalesMoney;                    // 売上金額順位(下位)
                //    dr[DCTOK02054EA.ct_Col_RankGrossMoney] = rsltInfo_ShipGoodsAnalyzeWork.LowRankGrossMoney;                    // 粗利金額順位(下位)
                //}
                //dr[DCTOK02054EA.ct_Col_Sort_SectionCode] = rsltInfo_ShipGoodsAnalyzeWork.AddUpSecCode;              // ソート用拠点コード
                //dr[DCTOK02054EA.ct_Col_Sort_GoodsMaker] = rsltInfo_ShipGoodsAnalyzeWork.GoodsMakerCd;              // ソート用商品メーカーコード
                //dr[DCTOK02054EA.ct_Col_Sort_LargeGoodsGanreCode] = rsltInfo_ShipGoodsAnalyzeWork.LargeGoodsGanreCode;   // ソート用商品区分グループコード
                //dr[DCTOK02054EA.ct_Col_Sort_MediumGoodsGanreCode] = rsltInfo_ShipGoodsAnalyzeWork.MediumGoodsGanreCode; // ソート用商品区分コード
                //dr[DCTOK02054EA.ct_Col_Sort_DetailGoodsGanreCode] = rsltInfo_ShipGoodsAnalyzeWork.DetailGoodsGanreCode; // ソート用商品区分詳細コード
                //dr[DCTOK02054EA.ct_Col_Sort_BLGoodsCode] = rsltInfo_ShipGoodsAnalyzeWork.BLGoodsCode;                   // ソート用BL商品コード
                //dr[DCTOK02054EA.ct_Col_Sort_GoodsNo] = rsltInfo_ShipGoodsAnalyzeWork.GoodsNo;       // ソート用商品番号
                //dr[DCTOK02054EA.ct_Col_Sort_TotalCount] = rsltInfo_ShipGoodsAnalyzeWork.TotalCount; // ソート用売上数計
                //dr[DCTOK02054EA.ct_Col_Sort_SalesMoney] = rsltInfo_ShipGoodsAnalyzeWork.SalesMoney; // ソート用売上金額
                //dr[DCTOK02054EA.ct_Col_Sort_GrossMoney] = rsltInfo_ShipGoodsAnalyzeWork.GrossMoney; // ソート用粗利金額
                // --- DEL 2008/10/20 --------------------------------<<<<<
                // --- ADD 2008/10/20 -------------------------------->>>>>
                dr[DCTOK02054EA.ct_Col_SectionCode] = rsltInfo_ShipGoodsAnalyzeWork.AddUpSecCode; // 拠点コード
                dr[DCTOK02054EA.ct_Col_SectionGuideNm] = rsltInfo_ShipGoodsAnalyzeWork.SectionGuideSnm; // 拠点ガイド名称
                dr[DCTOK02054EA.ct_Col_GoodsMakerCd] = rsltInfo_ShipGoodsAnalyzeWork.GoodsMakerCd; // 商品メーカーコード
                dr[DCTOK02054EA.ct_Col_MakerName] = rsltInfo_ShipGoodsAnalyzeWork.MakerShortName; // 商品メーカー名称
                dr[DCTOK02054EA.ct_Col_SupplierCd] = rsltInfo_ShipGoodsAnalyzeWork.SupplierCd; // 仕入先コード
                dr[DCTOK02054EA.ct_Col_SupplierSnm] = rsltInfo_ShipGoodsAnalyzeWork.SupplierSnm; // 仕入先名称
                dr[DCTOK02054EA.ct_Col_GoodsNo] = rsltInfo_ShipGoodsAnalyzeWork.GoodsNo; // 商品番号
                dr[DCTOK02054EA.ct_Col_GoodsShortName] = rsltInfo_ShipGoodsAnalyzeWork.GoodsNameKana; // 商品略称
                dr[DCTOK02054EA.ct_Col_StockCreateDate] = rsltInfo_ShipGoodsAnalyzeWork.StockCreateDate; // 在庫登録日
                dr[DCTOK02054EA.ct_Col_ShipmentPosCnt] = rsltInfo_ShipGoodsAnalyzeWork.ShipmentPosCnt; // 仕入在庫数
                dr[DCTOK02054EA.ct_Col_MinimumStockCnt] = rsltInfo_ShipGoodsAnalyzeWork.MinimumStockCnt; // 最低在庫数
                dr[DCTOK02054EA.ct_Col_MaximumStockCnt] = rsltInfo_ShipGoodsAnalyzeWork.MaximumStockCnt; // 最高在庫数
                dr[DCTOK02054EA.ct_Col_TotalCount] = rsltInfo_ShipGoodsAnalyzeWork.TotalCount; // 売上数計
                dr[DCTOK02054EA.ct_Col_StockCount] = rsltInfo_ShipGoodsAnalyzeWork.StockCount; // 売上数計(在庫)
                dr[DCTOK02054EA.ct_Col_OrderCount] = rsltInfo_ShipGoodsAnalyzeWork.OrderCount; // 売上数計(取寄)
                dr[DCTOK02054EA.ct_Col_SalesMoney] = rsltInfo_ShipGoodsAnalyzeWork.SalesMoney; // 売上金額
                dr[DCTOK02054EA.ct_Col_GrossMoney] = rsltInfo_ShipGoodsAnalyzeWork.GrossProfit; // 粗利金額
                dr[DCTOK02054EA.ct_Col_SalesRetGoodsPrice] = rsltInfo_ShipGoodsAnalyzeWork.SalesRetGoodsPrice; // 返品額
                dr[DCTOK02054EA.ct_Col_DiscountPrice] = rsltInfo_ShipGoodsAnalyzeWork.DiscountPrice; // 値引額
                dr[DCTOK02054EA.ct_Col_StockSalesMoney] = rsltInfo_ShipGoodsAnalyzeWork.StockSalesMoney; // 売上金額(在庫)
                dr[DCTOK02054EA.ct_Col_StockGrossProfit] = rsltInfo_ShipGoodsAnalyzeWork.StockGrossProfit; // 粗利金額(在庫)
                dr[DCTOK02054EA.ct_Col_StockSalesRetGoodsPrice] = rsltInfo_ShipGoodsAnalyzeWork.StockSalesRetGoodsPrice; // 返品額(在庫)
                dr[DCTOK02054EA.ct_Col_StockDiscountPrice] = rsltInfo_ShipGoodsAnalyzeWork.StockDiscountPrice; // 値引額(在庫)
                // --- ADD 2008/10/20 --------------------------------<<<<<
                #endregion

                #region 売上額、粗利額の取得
                // 印字対象の売上額取得
                Int64 pureSalesMoney = 0;
                // 印字対象の粗利額取得
                Int64 grossMoney = 0;

                if (extrInfo_ShipGoodsAnalyze.RsltTtlDiv == ExtrInfo_ShipGoodsAnalyze.RsltTtlDivState.Total)
                {
                    // 合計の金額で計算
                    pureSalesMoney = (Int64)dr[DCTOK02054EA.ct_Col_SalesMoney] + (Int64)dr[DCTOK02054EA.ct_Col_SalesRetGoodsPrice] + (Int64)dr[DCTOK02054EA.ct_Col_DiscountPrice];
                    grossMoney = (Int64)dr[DCTOK02054EA.ct_Col_GrossMoney];

                    // 2009/09/24 Add >>>
                    // 数量，金額、共に0ならContinue
                    if (pureSalesMoney == 0 & rsltInfo_ShipGoodsAnalyzeWork.TotalCount == 0)
                    {
                        continue;
                    }
                    // 2009/09/24 Add <<<

                }
                else if (extrInfo_ShipGoodsAnalyze.RsltTtlDiv == ExtrInfo_ShipGoodsAnalyze.RsltTtlDivState.Stock)
                {
                    // 在庫の金額で計算
                    pureSalesMoney = (Int64)dr[DCTOK02054EA.ct_Col_StockSalesMoney] + (Int64)dr[DCTOK02054EA.ct_Col_StockSalesRetGoodsPrice] + (Int64)dr[DCTOK02054EA.ct_Col_StockDiscountPrice];
                    grossMoney = (Int64)dr[DCTOK02054EA.ct_Col_StockGrossProfit];

                    // 2009/09/24 Add >>>
                    // 数量，金額、共に0ならContinue
                    if (pureSalesMoney == 0 & rsltInfo_ShipGoodsAnalyzeWork.StockCount == 0)
                    {
                        continue;
                    }
                    // 2009/09/24 Add <<<

                }
                else if (extrInfo_ShipGoodsAnalyze.RsltTtlDiv == ExtrInfo_ShipGoodsAnalyze.RsltTtlDivState.Acquire)
                {
                    // 合計 - 在庫で計算
                    pureSalesMoney = (Int64)dr[DCTOK02054EA.ct_Col_SalesMoney] + (Int64)dr[DCTOK02054EA.ct_Col_SalesRetGoodsPrice] + (Int64)dr[DCTOK02054EA.ct_Col_DiscountPrice]
                                   - (Int64)dr[DCTOK02054EA.ct_Col_StockSalesMoney] - (Int64)dr[DCTOK02054EA.ct_Col_StockSalesRetGoodsPrice] - (Int64)dr[DCTOK02054EA.ct_Col_StockDiscountPrice];
                    grossMoney = (Int64)dr[DCTOK02054EA.ct_Col_GrossMoney] - (Int64)dr[DCTOK02054EA.ct_Col_StockGrossProfit];

                    // 2009/09/24 Add >>>
                    // 数量，金額、共に0ならContinue
                    if (pureSalesMoney == 0 & rsltInfo_ShipGoodsAnalyzeWork.OrderCount == 0)
                    {
                        continue;
                    }
                    // 2009/09/24 Add <<<

                }

                dr[DCTOK02054EA.ct_Col_PureSalesMoney] = pureSalesMoney;
                dr[DCTOK02054EA.ct_Col_PrintGrossMoney] = grossMoney;

                #endregion

                #region 率計算
                decimal grossMoneyRate;
                if (grossMoney != 0 && pureSalesMoney != 0)
                {
                    grossMoneyRate = (decimal)grossMoney / (decimal)pureSalesMoney * 100;
                }
                else
                {
                    grossMoneyRate = 0;
                }

                // --- DEL 2009/03/24 -------------------------------->>>>>
                //if (grossMoneyRate < 0)
                //{
                //    grossMoneyRate = grossMoneyRate * -1;
                //}
                // --- DEL 2009/03/24 --------------------------------<<<<<

                // 粗利率
                dr[DCTOK02054EA.ct_Col_GrossMoneyRate] = (double)grossMoneyRate;

                #endregion

                // 小計計算用に純売上と粗利金額の元値(金額単位変換なし)を保持
                dr[DCTOK02054EA.ct_Col_PureSalesMoneyOrg] = pureSalesMoney;
                dr[DCTOK02054EA.ct_Col_GrossMoneyOrg] = grossMoney;

                #region 金額単位設定
                // DEL 2009/04/10 ------>>>
                //int priceUnit;

                //if (extrInfo_ShipGoodsAnalyze.MoneyUnit == ExtrInfo_ShipGoodsAnalyze.MoneyUnitState.Thousand)
                //{
                //    priceUnit = 1000;

                //    // 純売上
                //    dr[DCTOK02054EA.ct_Col_PureSalesMoney] = (Int64)((decimal)((Int64)dr[DCTOK02054EA.ct_Col_PureSalesMoney]) / (decimal)priceUnit);
                //    // 粗利
                //    dr[DCTOK02054EA.ct_Col_PrintGrossMoney] = (Int64)((decimal)((Int64)dr[DCTOK02054EA.ct_Col_PrintGrossMoney]) / (decimal)priceUnit);
                //}
                // DEL 2009/04/10 ------<<<
                #endregion

                // TableにAdd
				this._shipGoodsAnalyzeListDt.Rows.Add( dr );
            }

            // ADD 李小路 2012/05/22 Redmine#29911 ------------->>>>>
            //全社の場合も同じ品番商品の重複レコードを削除します。
            if (extrInfo_ShipGoodsAnalyze.TtlType == ExtrInfo_ShipGoodsAnalyze.TtlTypeState.All)
            {
                this._shipGoodsAnalyzeListDt = DelDuplicateData();
            }
            // ADD 李小路 2012/05/22 Redmine#29911 -------------<<<<<

            #region 順位付

            // 数量順位
            if (extrInfo_ShipGoodsAnalyze.RsltTtlDiv == ExtrInfo_ShipGoodsAnalyze.RsltTtlDivState.Total)
            {
                this.SetOrder(DCTOK02054EA.ct_Col_TotalCount, DCTOK02054EA.ct_Col_RankTotalCount, extrInfo_ShipGoodsAnalyze);
            }
            else if (extrInfo_ShipGoodsAnalyze.RsltTtlDiv == ExtrInfo_ShipGoodsAnalyze.RsltTtlDivState.Stock)
            {
                this.SetOrder(DCTOK02054EA.ct_Col_StockCount, DCTOK02054EA.ct_Col_RankTotalCount, extrInfo_ShipGoodsAnalyze);
            }
            else if (extrInfo_ShipGoodsAnalyze.RsltTtlDiv == ExtrInfo_ShipGoodsAnalyze.RsltTtlDivState.Acquire)
            {
                this.SetOrder(DCTOK02054EA.ct_Col_OrderCount, DCTOK02054EA.ct_Col_RankTotalCount, extrInfo_ShipGoodsAnalyze);
            }

            // 売上金額順位
            this.SetOrder(DCTOK02054EA.ct_Col_PureSalesMoneyOrg, DCTOK02054EA.ct_Col_RankSalesMoney, extrInfo_ShipGoodsAnalyze);

            // 粗利金額順位
            this.SetOrder(DCTOK02054EA.ct_Col_GrossMoneyOrg, DCTOK02054EA.ct_Col_RankGrossMoney, extrInfo_ShipGoodsAnalyze);

            #endregion

            // DataView作成
            this._shipGoodsAnalyzeListDataView = new DataView(this._shipGoodsAnalyzeListDt,
                                                              GetFilter(extrInfo_ShipGoodsAnalyze),
                                                              GetSortOrder(extrInfo_ShipGoodsAnalyze),
                                                              DataViewRowState.CurrentRows);
		}
        /// <summary>
        /// 拠点ガイド名称取得
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        private string GetSectionGuideNm( string sectionCode )
        {
            if ( stc_SectionDic.ContainsKey( sectionCode ) ) {
                return stc_SectionDic[sectionCode].SectionGuideNm;
            }
            else {
                return string.Empty;
            }
        }
		#endregion


		#region ◎ ソート順作成
		/// <summary>
		/// ソート順作成
		/// </summary>
		/// <returns>ソート文字列</returns>
        private string GetSortOrder( ExtrInfo_ShipGoodsAnalyze extrInfo_ShipGoodsAnalyze)
		{
			StringBuilder strSortOrder = new StringBuilder();

            // --- DEL 2008/10/20 -------------------------------->>>>>
            //if ( !extrInfo_ShipGoodsAnalyze.IsSelectAllSection )
            //{
            //    // 全社選択されてないとき
            //    // 主拠点
            //    strSortOrder.Append( string.Format("{0},", DCTOK02054EA.ct_Col_SectionCode ) );
            //}

            //// 拠点コード
            //strSortOrder.Append(string.Format("{0}"+",", DCTOK02054EA.ct_Col_Sort_SectionCode));
            //// メーカーコード
            //strSortOrder.Append(string.Format("{0}"+",", DCTOK02054EA.ct_Col_Sort_GoodsMaker));

            //// 画面指定内容により印刷順を制御
            //switch (extrInfo_ShipGoodsAnalyze.OrderPrintDiv) {
            //    // 売上金額順
            //    case ExtrInfo_ShipGoodsAnalyze.OrderPrintDivState.SalesMoneyTaxExcOrder:
            //        strSortOrder.Append(string.Format("{0}" + ",", DCTOK02054EA.ct_Col_Sort_SalesMoney));
            //        break;
            //    // 粗利額順
            //    case ExtrInfo_ShipGoodsAnalyze.OrderPrintDivState.GrossProfitOrder:
            //        strSortOrder.Append(string.Format("{0}" + ",", DCTOK02054EA.ct_Col_Sort_GrossMoney));
            //        break;
            //    // 出荷数順
            //    case ExtrInfo_ShipGoodsAnalyze.OrderPrintDivState.ShipmentCntOrder:
            //        strSortOrder.Append(string.Format("{0}" + ",", DCTOK02054EA.ct_Col_Sort_TotalCount));
            //        break;
            //    default : 
            //        break;
            //}
            //// 商品グループコード
            //strSortOrder.Append(string.Format("{0}" + ",", DCTOK02054EA.ct_Col_Sort_LargeGoodsGanreCode));
            //// 商品区分コード
            //strSortOrder.Append(string.Format("{0}" + ",", DCTOK02054EA.ct_Col_Sort_MediumGoodsGanreCode));
            //// 商品区分詳細コード
            //strSortOrder.Append(string.Format("{0}" + ",", DCTOK02054EA.ct_Col_Sort_DetailGoodsGanreCode));
            //// BLコード
            //strSortOrder.Append(string.Format("{0}" + ",", DCTOK02054EA.ct_Col_Sort_BLGoodsCode));
            //// 商品番号
            //// ↓ 2008.04.02 980081 c
            ////strSortOrder.Append(string.Format("{0}" + ",", DCTOK02054EA.ct_Col_Sort_GoodsNo));
            //strSortOrder.Append(string.Format("{0}" , DCTOK02054EA.ct_Col_Sort_GoodsNo));
            //// ↑ 2008.04.02 980081 c
            // --- DEL 2008/10/20 --------------------------------<<<<<
            // --- ADD 2008/10/20 -------------------------------->>>>>
            if (extrInfo_ShipGoodsAnalyze.TtlType == ExtrInfo_ShipGoodsAnalyze.TtlTypeState.BySection)
            {
                // 拠点コード
                strSortOrder.Append( string.Format("{0},", DCTOK02054EA.ct_Col_SectionCode ) );
            }

            // 仕入先コード
            strSortOrder.Append(string.Format("{0},", DCTOK02054EA.ct_Col_SupplierCd));

            // メーカーコード
            strSortOrder.Append(string.Format("{0},", DCTOK02054EA.ct_Col_GoodsMakerCd));
            
            // 印刷順
            if (extrInfo_ShipGoodsAnalyze.OrderPrintDiv == ExtrInfo_ShipGoodsAnalyze.OrderPrintDivState.ShipmentCntOrder)
            {
                //if (extrInfo_ShipGoodsAnalyze.RsltTtlDiv == ExtrInfo_ShipGoodsAnalyze.RsltTtlDivState.Total)
                //{
                //    // 出荷数 合計
                //    strSortOrder.Append(string.Format("{0}", DCTOK02054EA.ct_Col_TotalCount));
                //}
                //else if (extrInfo_ShipGoodsAnalyze.RsltTtlDiv == ExtrInfo_ShipGoodsAnalyze.RsltTtlDivState.Stock)
                //{
                //    // 出荷数 在庫
                //    strSortOrder.Append(string.Format("{0}", DCTOK02054EA.ct_Col_StockCount));
                //}
                //else if (extrInfo_ShipGoodsAnalyze.RsltTtlDiv == ExtrInfo_ShipGoodsAnalyze.RsltTtlDivState.Acquire)
                //{
                //    // 出荷数 取寄
                //    strSortOrder.Append(string.Format("{0}", DCTOK02054EA.ct_Col_OrderCount));
                //}
                // 出荷数
                strSortOrder.Append(string.Format("{0},", DCTOK02054EA.ct_Col_RankTotalCount));
            }
            else if (extrInfo_ShipGoodsAnalyze.OrderPrintDiv == ExtrInfo_ShipGoodsAnalyze.OrderPrintDivState.SalesMoneyTaxExcOrder)
            {
                // 売上金額
                strSortOrder.Append(string.Format("{0},", DCTOK02054EA.ct_Col_RankSalesMoney));
            }
            else if (extrInfo_ShipGoodsAnalyze.OrderPrintDiv == ExtrInfo_ShipGoodsAnalyze.OrderPrintDivState.GrossProfitOrder)
            {
                // 粗利金額
                strSortOrder.Append(string.Format("{0},", DCTOK02054EA.ct_Col_RankGrossMoney));
            }

            // 品番
            strSortOrder.Append(string.Format("{0}", DCTOK02054EA.ct_Col_GoodsNo));
            // --- ADD 2008/10/20 --------------------------------<<<<<

			return strSortOrder.ToString();
		}
		#endregion

        #region ◎ フィルタ作成
        /// <summary>
        /// フィルタ作成
        /// </summary>
        /// <param name="extrInfo_ShipGoodsAnalyze">条件パラメータ</param>
        /// <returns>フィルタ文字列</returns>
        private string GetFilter( ExtrInfo_ShipGoodsAnalyze extrInfo_ShipGoodsAnalyze)
		{
            string filterText = string.Empty;

            // 何順タイプかを取得
            switch (extrInfo_ShipGoodsAnalyze.OrderPrintDiv) {
                case ExtrInfo_ShipGoodsAnalyze.OrderPrintDivState.ShipmentCntOrder:
                    //filterText = DCTOK02054EA.ct_Col_TotalCount; // DEL 2008/10/20
                    filterText = DCTOK02054EA.ct_Col_RankTotalCount;
                    break;
                case ExtrInfo_ShipGoodsAnalyze.OrderPrintDivState.SalesMoneyTaxExcOrder:
                    //filterText = DCTOK02054EA.ct_Col_SalesMoney; // DEL 2008/10/20
                    filterText = DCTOK02054EA.ct_Col_RankSalesMoney;
                    break;
                case ExtrInfo_ShipGoodsAnalyze.OrderPrintDivState.GrossProfitOrder:
                    //filterText = DCTOK02054EA.ct_Col_GrossMoney; // DEL 2008/10/20
                    filterText = DCTOK02054EA.ct_Col_RankGrossMoney;
                    break;
                default :
                    return string.Empty;
            }

            // 第何位まで印字するか設定
            filterText += string.Format(" <= {0}",extrInfo_ShipGoodsAnalyze.RankOrderMax);

            return filterText;
        }

        /// <summary>
        /// 全社の場合も同じ品番商品の重複レコードを削除します。
        /// </summary>
        /// <returns>DataView</returns>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 李小路</br>
        /// <br>Date       : 2012/05/22</br>
        /// <br>管理番号   : 10801804-00 2012/06/27配信分　Redmine#29911　出荷商品分析表 全社集計時の集約不正の対応</br>
        /// </remarks>
        private DataTable DelDuplicateData()
        {
            DataTable dstTbl = this._shipGoodsAnalyzeListDt.Clone();
            //<品番コード_仕入先コード_メーカーコード,<拠点コード, rowIndex>>
            Dictionary<string, string[]> goods_Section_Codes = new Dictionary<string, string[]>();

            foreach (DataRow rv in this._shipGoodsAnalyzeListDt.Rows)
            {
                string goodsNo = "";
                string secCode = "";
                int goodsMakerCd = 0;
                int supplierCd = 0;
                if (rv[DCTOK02054EA.ct_Col_GoodsNo] != null)
                    goodsNo = rv[DCTOK02054EA.ct_Col_GoodsNo].ToString();
                if (rv[DCTOK02054EA.ct_Col_SectionCode] != null)
                    secCode = rv[DCTOK02054EA.ct_Col_SectionCode].ToString().Trim();
                goodsMakerCd = (int)rv[DCTOK02054EA.ct_Col_GoodsMakerCd];
                supplierCd = (int)rv[DCTOK02054EA.ct_Col_SupplierCd];

                string key = string.Format("{0}_{1}_{2}", goodsNo, supplierCd, goodsMakerCd);
                if (!goods_Section_Codes.ContainsKey(key))
                {
                    dstTbl.Rows.Add(rv.ItemArray);
                    int idx = dstTbl.Rows.Count - 1;
                    goods_Section_Codes.Add(key, new string[] { secCode, idx.ToString() });
                }
                else
                {
                    int idx = Convert.ToInt32(goods_Section_Codes[key][1]);
                    DataRow oldRow = dstTbl.Rows[idx];
                    // 売上数計
                    double totalCount = Convert.ToDouble(oldRow[DCTOK02054EA.ct_Col_TotalCount])
                                        + Convert.ToDouble(rv[DCTOK02054EA.ct_Col_TotalCount]);
                    // 売上数計(在庫)
                    double stockCount = Convert.ToDouble(oldRow[DCTOK02054EA.ct_Col_StockCount])
                                        + Convert.ToDouble(rv[DCTOK02054EA.ct_Col_StockCount]);
                    // 売上数計(取寄)
                    double orderCount = Convert.ToDouble(oldRow[DCTOK02054EA.ct_Col_OrderCount])
                                        + Convert.ToDouble(rv[DCTOK02054EA.ct_Col_OrderCount]);
                    // 印字対象の売上額
                    Int64 pureSalesMoney = Convert.ToInt64(oldRow[DCTOK02054EA.ct_Col_PureSalesMoney])
                                        + Convert.ToInt64(rv[DCTOK02054EA.ct_Col_PureSalesMoney]);
                    // 印字対象の粗利額
                    Int64 grossMoney = Convert.ToInt64(oldRow[DCTOK02054EA.ct_Col_PrintGrossMoney])
                                        + Convert.ToInt64(rv[DCTOK02054EA.ct_Col_PrintGrossMoney]);
                    #region 粗利率計算
                    decimal grossMoneyRate;
                    if (pureSalesMoney != 0)
                    {
                        grossMoneyRate = (decimal)grossMoney / (decimal)pureSalesMoney * 100;
                    }
                    else
                    {
                        grossMoneyRate = 0;
                    }
                    #endregion

                    if (Convert.ToInt32(goods_Section_Codes[key][0] == "" ? "0" : goods_Section_Codes[key][0]) > Convert.ToInt32(secCode == "" ? "0" : secCode))
                    {
                        goods_Section_Codes[key] = new string[] { secCode, idx.ToString() };
                        //dstTbl.Rows.RemoveAt(idx);                //DEL 李小路 2012/06/06 Redmine#29911
                        //dstTbl.Rows.InsertAt(rv, idx);            //DEL 李小路 2012/06/06 Redmine#29911
                        dstTbl.Rows[idx].ItemArray = rv.ItemArray;  //ADD 李小路 2012/06/06 Redmine#29911
                    }

                    //データを更新する
                    dstTbl.Rows[idx][DCTOK02054EA.ct_Col_TotalCount] = totalCount;          //売上数計
                    dstTbl.Rows[idx][DCTOK02054EA.ct_Col_StockCount] = stockCount;          //売上数計(在庫)
                    dstTbl.Rows[idx][DCTOK02054EA.ct_Col_OrderCount] = orderCount;          //売上数計(取寄)
                    dstTbl.Rows[idx][DCTOK02054EA.ct_Col_PureSalesMoney] = pureSalesMoney;  //印字対象の売上額
                    dstTbl.Rows[idx][DCTOK02054EA.ct_Col_PrintGrossMoney] = grossMoney;     //印字対象の粗利額
                    dstTbl.Rows[idx][DCTOK02054EA.ct_Col_GrossMoneyRate] = (double)grossMoneyRate;  //粗利率
                    // 小計計算用に純売上と粗利金額の元値(金額単位変換なし)を保持
                    dstTbl.Rows[idx][DCTOK02054EA.ct_Col_PureSalesMoneyOrg] = pureSalesMoney;
                    dstTbl.Rows[idx][DCTOK02054EA.ct_Col_GrossMoneyOrg] = grossMoney;
                }
            }

            //ADD 李小路 2012/06/06 Redmine#29911------->>>>>
            //clear ADDUPSECCODERF & SECTIONGUIDESNMRF
            foreach (DataRow row in dstTbl.Rows)
            {
                row[DCTOK02054EA.ct_Col_SectionCode] = "";
                row[DCTOK02054EA.ct_Col_SectionGuideNm] = "";
            }
            //ADD 李小路 2012/06/06 Redmine#29911------->>>>>

            return dstTbl;
        }
        
        #endregion 

        #region ◎ 金額単位取得処理
        /// <summary>
        /// 金額単位取得処理
        /// </summary>
        /// <param name="extrInfo_ShipGoodsAnalyze"></param>
        /// <returns></returns>
        private double GetMoneyUnit( ExtrInfo_ShipGoodsAnalyze extrInfo_ShipGoodsAnalyze)
        {
            double moneyUnit;

            switch (extrInfo_ShipGoodsAnalyze.MoneyUnit) {
                case ExtrInfo_ShipGoodsAnalyze.MoneyUnitState.One: 
                    moneyUnit = 1; 
                    break;
                case ExtrInfo_ShipGoodsAnalyze.MoneyUnitState.Thousand:
                    moneyUnit = 1000;
                    break;
                default :
                    moneyUnit = 1;
                    break;
            }
            return moneyUnit;
        }
        #endregion

        #region 順位付
        /// <summary>
        /// 順位付設定
        /// </summary>
        /// <param name="targetColName">順位付比較対象列名</param>
        /// <param name="setColName">順位設定対象列名</param>
        /// <param name="extrInfo_ShipGoodsAnalyze"></param>
        /// <returns>順位付けされたDataTable</returns>
        private void SetOrder(string targetColName, string setColName, ExtrInfo_ShipGoodsAnalyze extrInfo_ShipGoodsAnalyze)
        {
            string savAddUpSecCode = "";
            int orderNo = 0;
            int orderNoPls = 0;
            double savTotls = -1;
            double nowTotls = 0;

            // ソート条件
            StringBuilder strSortOrder = new StringBuilder();

            if (extrInfo_ShipGoodsAnalyze.RankSection == ExtrInfo_ShipGoodsAnalyze.RankSectionState.Section)
            {
                // 拠点コード
                strSortOrder.Append(string.Format("{0} ASC ,", DCTOK02054EA.ct_Col_SectionCode));
            }

            // 昇順、降順
            string strAscDesc;

            if (extrInfo_ShipGoodsAnalyze.RankHighLow == ExtrInfo_ShipGoodsAnalyze.RankHighLowState.High) strAscDesc = " DESC";
            else strAscDesc = " ASC";

            strSortOrder.Append(string.Format("{0} {1}", targetColName, strAscDesc));

            // (拠点)と対象列でソートされたDataRow配列を取得
            DataRow[] drList = this._shipGoodsAnalyzeListDt.Select("", strSortOrder.ToString());

            //// 返却用DataTable
            //DataTable newDt = this._shipGoodsAnalyzeListDt.Clone();

            for (int i = 0; i < drList.Length; i++)
            {
                //拠点管理する場合
                if (extrInfo_ShipGoodsAnalyze.RankSection == ExtrInfo_ShipGoodsAnalyze.RankSectionState.Section)
                {
                    string tmpAddUpSecCode = (string)drList[i][DCTOK02054EA.ct_Col_SectionCode];
                    if (savAddUpSecCode.Trim() != tmpAddUpSecCode.Trim())
                    {
                        savAddUpSecCode = tmpAddUpSecCode;
                        orderNo = 0;
                        orderNoPls = 0;
                        savTotls = -1;
                    }
                }

                // 順位付対象列の値取得
                nowTotls = Convert.ToDouble(drList[i][targetColName]);

                if (savTotls == nowTotls)
                {
                    orderNoPls++;
                }
                else
                {
                    // 設定される値が順位の最大値設定を超えていないかチェック
                    if (orderNo + orderNoPls + 1 <= extrInfo_ShipGoodsAnalyze.RankOrderMax)
                    {
                        savTotls = nowTotls;
                        orderNo += orderNoPls;
                        orderNoPls = 0;
                    }
                    else
                    {
                        orderNo = 99999999; // 最大値以上を設定(帳票側でクリアする)
                        orderNoPls = 0;
                    }
                }

                if (orderNoPls == 0)
                {
                    orderNo++;
                }

                drList[i][setColName] = orderNo;

                //newDt.Rows.Add(drList[i]);
            }

            //this._shipGoodsAnalyzeListDt = newDt;
        }
        #endregion

        #endregion ◆ データ展開処理

        #region ◆ 帳票設定データ取得
        #region ◎ 帳票出力設定取得処理
        /// <summary>
		/// 帳票出力設定読込
		/// </summary>
		/// <param name="retPrtOutSet">帳票出力設定データクラス</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>status</returns>
		/// <remarks>
		/// <br>Note       : 自拠点の帳票出力設定の読込を行います。</br>
		/// <br>Programmer : 20081 kubo</br>
		/// <br>Date       : 2007.12.03</br>
		/// </remarks>
		static public int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			retPrtOutSet = new PrtOutSet();
			errMsg = "";	

			try
			{
				// データは読込済みか？
				if (stc_PrtOutSet != null)
				{
					retPrtOutSet = stc_PrtOutSet.Clone(); 
					status    = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
				} 
				else 
				{
					status = stc_PrtOutSetAcs.Read(out stc_PrtOutSet, LoginInfoAcquisition.EnterpriseCode, stc_Employee.BelongSectionCode);

					switch(status)
					{
						case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
							retPrtOutSet = stc_PrtOutSet.Clone();
							status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
							break;
						case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
						case (int)ConstantManagement.DB_Status.ctDB_EOF      :
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
						default:
							errMsg = "帳票出力設定の読込に失敗しました";
							status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
							break;
					}
				}
			}
			catch(Exception ex)
			{
				errMsg = ex.Message;
				retPrtOutSet = new PrtOutSet();
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}
		#endregion
		#endregion ◆ 帳票設定データ取得

        #region ◆　テストデータ
        private int testproc(out object retList)
        {
            ArrayList paramlist = new ArrayList();

            //RsltInfo_ShipGoodsAnalyzeWork param1 = new RsltInfo_ShipGoodsAnalyzeWork();

            //param1.AddUpSecCode = "99";
            //param1.SectionGuideSnm = "拠点名称は最大桁１桁";
            //param1.GoodsMakerCd = 9999;
            //param1.MakerShortName = "メーカーは最大１０桁";
            //param1.SupplierCd = 999999;
            //param1.SupplierSnm = "仕入先は最大全角２０桁あります。７８９０";
            //param1.GoodsNo = "111111111122222222221234";
            //param1.GoodsNameKana = "12345678901234567890";
            //param1.StockCreateDate = DateTime.MaxValue;
            //param1.ShipmentPosCnt = 999999999;
            //param1.MinimumStockCnt = 999999999;
            //param1.MaximumStockCnt = 999999999;
            //param1.TotalCount = 999999999;
            //param1.StockCount = 999999999;
            //param1.OrderCount = 999999999;
            //param1.SalesMoney = 888888888;
            //param1.GrossProfit = 999999999;
            //param1.SalesRetGoodsPrice = -111111111;
            //param1.DiscountPrice = -222222222;

            //paramlist.Add(param1);

            //RsltInfo_ShipGoodsAnalyzeWork param2 = new RsltInfo_ShipGoodsAnalyzeWork();

            //param2.AddUpSecCode = "";
            //param2.SectionGuideSnm = "";
            //param2.GoodsMakerCd = 0;
            //param2.MakerShortName = "";
            //param2.SupplierCd = 0;
            //param2.SupplierSnm = "";
            //param2.GoodsNo = "";
            //param2.GoodsNameKana = "";
            //param2.StockCreateDate = DateTime.MinValue;
            //param2.ShipmentPosCnt = 0;
            //param2.MinimumStockCnt = 0;
            //param2.MaximumStockCnt = 0;
            //param2.TotalCount = 0;
            //param2.StockCount = 0;
            //param2.OrderCount = 0;
            //param2.SalesMoney = 0;
            //param2.GrossProfit = 0;
            //param2.SalesRetGoodsPrice = 0;
            //param2.DiscountPrice = 0;

            //paramlist.Add(param2);

            //retList = (object)paramlist;

            //RsltInfo_ShipGoodsAnalyzeWork param3 = new RsltInfo_ShipGoodsAnalyzeWork();

            //param3.AddUpSecCode = "1";
            //param3.SectionGuideSnm = "拠点1";
            //param3.GoodsMakerCd = 1;
            //param3.MakerShortName = "メーカー1";
            //param3.SupplierCd = 1;
            //param3.SupplierSnm = "仕入先1";
            //param3.GoodsNo = "1";
            //param3.GoodsNameKana = "ｼｮｳﾋﾝ1";
            //param3.StockCreateDate = DateTime.Today;
            //param3.ShipmentPosCnt = 1000;
            //param3.MinimumStockCnt = 2000;
            //param3.MaximumStockCnt = 3000;
            //param3.TotalCount = 100;
            //param3.StockCount = 200;
            //param3.OrderCount = 300;
            //param3.SalesMoney = 1500;
            //param3.GrossProfit = 250;
            //param3.SalesRetGoodsPrice = -500;
            //param3.DiscountPrice = -500;
            //param3.StockSalesMoney = 150;
            //param3.StockGrossProfit = 25;
            //param3.StockSalesRetGoodsPrice = -10;
            //param3.StockDiscountPrice = -15;

            //paramlist.Add(param3);

            //RsltInfo_ShipGoodsAnalyzeWork param4 = new RsltInfo_ShipGoodsAnalyzeWork();

            //param4.AddUpSecCode = "1";
            //param4.SectionGuideSnm = "拠点1";
            //param4.GoodsMakerCd = 1;
            //param4.MakerShortName = "メーカー1";
            //param4.SupplierCd = 1;
            //param4.SupplierSnm = "仕入先1";
            //param4.GoodsNo = "1";
            //param4.GoodsNameKana = "ｼｮｳﾋﾝ1";
            //param4.StockCreateDate = DateTime.Today;
            //param4.ShipmentPosCnt = 3000;
            //param4.MinimumStockCnt = 2000;
            //param4.MaximumStockCnt = 1000;
            //param4.TotalCount = 200;
            //param4.StockCount = 300;
            //param4.OrderCount = 100;
            //param4.SalesMoney = 1500;
            //param4.GrossProfit = 200;
            //param4.SalesRetGoodsPrice = -250;
            //param4.DiscountPrice = -250;

            //paramlist.Add(param4);

            //RsltInfo_ShipGoodsAnalyzeWork param5 = new RsltInfo_ShipGoodsAnalyzeWork();

            //param5.AddUpSecCode = "1";
            //param5.SectionGuideSnm = "拠点1";
            //param5.GoodsMakerCd = 1;
            //param5.MakerShortName = "メーカー1";
            //param5.SupplierCd = 1;
            //param5.SupplierSnm = "仕入先1";
            //param5.GoodsNo = "1";
            //param5.GoodsNameKana = "ｼｮｳﾋﾝ1";
            //param5.StockCreateDate = DateTime.Today;
            //param5.ShipmentPosCnt = 3000;
            //param5.MinimumStockCnt = 2000;
            //param5.MaximumStockCnt = 1000;
            //param5.TotalCount = 300;
            //param5.StockCount = 100;
            //param5.OrderCount = 200;
            //param5.SalesMoney = 2500;
            //param5.GrossProfit = 1000;
            //param5.SalesRetGoodsPrice = -250;
            //param5.DiscountPrice = -250;

            //paramlist.Add(param5);

            retList = (object)paramlist;

            return 0;
        }
        #endregion
		#endregion ■ Private Method
    }
}

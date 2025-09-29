//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーンマスタ印刷
// プログラム概要   : 抽出結果より出力結果イメージ表示・ＰＤＦ出力・印刷を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 作 成 日  2011/04/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.UIData;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using System.Data;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
	/// キャンペーン管理マスタテーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : キャンペーン管理マスタテーブルのアクセス制御を行います。</br>
	/// <br>Programmer : liyp</br>
	/// <br>Date       : 2011/04/25</br>
	/// <br></br>
    /// </remarks>
    public class CampaignMasterAcs
    {
        #region ■ Constructor
        /// <summary>
        /// キャンペーン管理マスタテーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : キャンペーン管理マスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : liyp</br>
	    /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public CampaignMasterAcs()
        {
            this._iCampaignMasterWorkDB = (ICampaignMasterWorkDB)MediationCampaignMasterWorkDB.GetCampaignMasterWorkDB();
        }

        /// <summary>
        /// キャンペーン管理マスタ印刷アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : キャンペーン管理マスタ印刷アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : liyp</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        static CampaignMasterAcs()
        {
            stc_Employee = null;
            stc_PrtOutSetAcs = new PrtOutSetAcs();	// 帳票出力設定アクセスクラス            

            stc_SecInfoAcs = new SecInfoAcs(1);         // 拠点アクセスクラス
            stc_SectionDic = new Dictionary<string, SecInfoSet>();  // 拠点Dictionary

            Employee loginWorker = null;
            string ownSectionCode = "";

            if (LoginInfoAcquisition.Employee != null)
            {
                loginWorker = LoginInfoAcquisition.Employee.Clone();
                ownSectionCode = loginWorker.BelongSectionCode;
            }


            // ログイン拠点取得
            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            if (loginEmployee != null)
            {
                stc_Employee = loginEmployee.Clone();
            }

            // 拠点Dictionary生成
            SecInfoSet[] secInfoSetList = stc_SecInfoAcs.SecInfoSetList;

            foreach (SecInfoSet secInfoSet in secInfoSetList)
            {
                // 既存でなければ
                if (!stc_SectionDic.ContainsKey(secInfoSet.SectionCode))
                {
                    // 追加
                    stc_SectionDic.Add(secInfoSet.SectionCode, secInfoSet);
                }
            }
        }
        #endregion ■ Constructor

        #region ■ Static Member
        private static Employee stc_Employee;
        private static PrtOutSet stc_PrtOutSet;			                // 帳票出力設定データクラス
        private static PrtOutSetAcs stc_PrtOutSetAcs;	                // 帳票出力設定アクセスクラス
        private static SecInfoAcs stc_SecInfoAcs;                       // 拠点アクセスクラス
        private static Dictionary<string, SecInfoSet> stc_SectionDic;   // 拠点Dictionary
        #endregion ■ Static Member

        #region ■ Private Member
        ICampaignMasterWorkDB _iCampaignMasterWorkDB;
        #endregion ■ Private Member

        #region Public Method

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
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/04/25</br>
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
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    status = stc_PrtOutSetAcs.Read(out stc_PrtOutSet, LoginInfoAcquisition.EnterpriseCode, stc_Employee.BelongSectionCode);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            retPrtOutSet = stc_PrtOutSet.Clone();
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        default:
                            errMsg = "帳票出力設定の読込に失敗しました";
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                retPrtOutSet = new PrtOutSet();
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion ◎ 帳票出力設定取得処理
        #endregion ◆ 帳票設定データ取得

        /// <summary>
		/// キャンペーン管理マスタ全検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : キャンペーン管理マスタの全検索処理を行います。論理削除データは抽出対象外となります。</br>
        /// <br>Programmer : liyp</br>
        /// <br>Date       : 2011/04/25</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, CampaignMasterPrintWork campaignMasterPrintWork)
        {
            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, campaignMasterPrintWork);
        }

        /// <summary>
        /// 商品マスタ検索処理（論理削除）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン管理マスタの全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : liyp</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int SearchDelete(out ArrayList retList, string enterpriseCode, CampaignMasterPrintWork campaignMasterPrintWork)
        {
            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData1, 0, campaignMasterPrintWork);
        }

        #endregion

        #region private method

        /// <summary>
		/// キャンペーン管理マスタ検索処理
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
		/// <param name="readCnt">読込件数</param>
        /// <param name="sectionPrintWork">抽出条件</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : キャンペーン管理マスタの検索処理を行います。</br>
		/// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, CampaignMasterPrintWork campaignMasterPrintWork)
		{
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            //次データ有無初期化
            nextData = false;
            //0で初期化
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            try
            {
                CampaignMasterPrtWork campaignMasterPrtWork = new CampaignMasterPrtWork();
                // 抽出条件展開  --------------------------------------------------------------
                status = this.SearchParaSet(campaignMasterPrintWork, out campaignMasterPrtWork);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // データ取得  ----------------------------------------------------------------
                object retReatList = new object();
                if (campaignMasterPrintWork.PrintType == 6)
                {
                    status = this._iCampaignMasterWorkDB.SearchForMasterType(ref retReatList, campaignMasterPrtWork, 0, logicalMode);
                }
                else
                {
                    status = this._iCampaignMasterWorkDB.Search(ref retReatList, campaignMasterPrtWork, 0, logicalMode);
                }
                
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        if (((ArrayList)retReatList).Count == 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                            break;
                        }

                        // データ展開処理
                        DevReatData(campaignMasterPrintWork, (ArrayList)retReatList, out retList);

                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
		}

        #region ◎ 抽出条件展開処理
        /// <summary>
        /// 抽出条件展開処理
        /// </summary>
        /// <param name="inventSearchCndtnUI">UI抽出条件クラス</param>
        /// <param name="inventInputSearchCndtnWork">リモート抽出条件クラス</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <br>Update Note : liyp 2011/01/11</br>
        /// <br>              出力条件に数量と棚番に関する条件指定を追加する（要望）</br>
        private int SearchParaSet(CampaignMasterPrintWork campaignMasterPrintWork, out CampaignMasterPrtWork campaignMasterPrtWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            campaignMasterPrtWork = new CampaignMasterPrtWork();

            try
            {
                // 企業コード
                campaignMasterPrtWork.EnterpriseCode = campaignMasterPrintWork.EnterpriseCode;
                // 発行タイプ
                campaignMasterPrtWork.PrintType = campaignMasterPrintWork.PrintType;
                // 開始キャンペーンコード
                campaignMasterPrtWork.CampaignCodeSt = campaignMasterPrintWork.CampaignCodeSt;
                // 終了キャンペーンコード
                campaignMasterPrtWork.CampaignCodeEd = campaignMasterPrintWork.CampaignCodeEd;
                // 開始拠点
                campaignMasterPrtWork.SectionCodeSt = campaignMasterPrintWork.SectionCodeSt;
                // 終了拠点
                campaignMasterPrtWork.SectionCodeEd = campaignMasterPrintWork.SectionCodeEd;
                // 論理削除区分
                campaignMasterPrtWork.LogicalDeleteCode = campaignMasterPrintWork.LogicalDeleteCode;
                // 削除日開始
                campaignMasterPrtWork.DeleteDateTimeSt = campaignMasterPrintWork.DeleteDateTimeSt;
                // 削除日終了
                campaignMasterPrtWork.DeleteDateTimeEd = campaignMasterPrintWork.DeleteDateTimeEd;
                // メーカーコード開始
                campaignMasterPrtWork.GoodsMakerCodeSt = campaignMasterPrintWork.GoodsMakerCodeSt;
                // メーカーコード終了
                campaignMasterPrtWork.GoodsMakerCodeEd = campaignMasterPrintWork.GoodsMakerCodeEd;
                // グループコード開始
                campaignMasterPrtWork.BLGroupCodeSt = campaignMasterPrintWork.BLGroupCodeSt;
                // グループコード終了
                campaignMasterPrtWork.BLGroupCodeEd = campaignMasterPrintWork.BLGroupCodeEd;
                // ＢＬコード開始
                campaignMasterPrtWork.BLGoodsCodeSt = campaignMasterPrintWork.BLGoodsCodeSt;
                // ＢＬコード終了
                campaignMasterPrtWork.BLGoodsCodeEd = campaignMasterPrintWork.BLGoodsCodeEd;
                // 販売区分コード開始
                campaignMasterPrtWork.SalesCodeSt = campaignMasterPrintWork.SalesCodeSt;
                // 販売区分コード終了
                campaignMasterPrtWork.SalesCodeEd = campaignMasterPrintWork.SalesCodeEd;
                // 品番開始
                campaignMasterPrtWork.GoodsNoSt = campaignMasterPrintWork.GoodsNoSt;
                // 品番終了
                campaignMasterPrtWork.GoodsNoEd = campaignMasterPrintWork.GoodsNoEd;
                // 売価率指定区分
                campaignMasterPrtWork.DiscountRateDiv = campaignMasterPrintWork.DiscountRateDiv;
                // 売価率
                campaignMasterPrtWork.DiscountRate = campaignMasterPrintWork.DiscountRate;
                // 売価率指定区分
                campaignMasterPrtWork.RateValDiv = campaignMasterPrintWork.RateValDiv;
                // 売価率
                campaignMasterPrtWork.RateVal = campaignMasterPrintWork.RateVal;
                // 売価額指定区分
                campaignMasterPrtWork.PriceFlDiv = campaignMasterPrintWork.PriceFlDiv;
                // 売価額
                campaignMasterPrtWork.PriceFl = campaignMasterPrintWork.PriceFl;
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion

        #region ◎ 取得データ展開処理
        /// <summary>
        /// 取得データ展開処理
        /// </summary>
        /// <param name="salesTargetPrintWork">UI抽出条件クラス</param>
        /// <param name="retaWork">取得データ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 取得データを展開する。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void DevReatData(CampaignMasterPrintWork campaignMasterPrintWork, ArrayList retaWork, out ArrayList retList)
        {
            retList = new ArrayList();

            foreach (CampaignMasterWork cmpaignMasterWork in retaWork)
            {
                if (DataCheck(cmpaignMasterWork, campaignMasterPrintWork) == 0)
                {
                    CampaignMaster campaignMaster = new CampaignMaster();
                    campaignMaster.CreateDateTime = cmpaignMasterWork.CreateDateTime;
                    campaignMaster.UpdateDateTime = cmpaignMasterWork.UpdateDateTime;
                    campaignMaster.CampaignCode = cmpaignMasterWork.CampaignCode;       // キャンペーンコード
                    campaignMaster.CampaignName = cmpaignMasterWork.CampaignName;       // キャンペーンコード名称
                    campaignMaster.CampaignObjDiv = cmpaignMasterWork.CampaignObjDiv;   // キャンペーン対象区分
                    campaignMaster.ApplyStaDate = cmpaignMasterWork.ApplyStaDate;       // 適用開始日
                    campaignMaster.ApplyEndDate = cmpaignMasterWork.ApplyEndDate;       // 適用終了日
                    campaignMaster.SectionCode = cmpaignMasterWork.SectionCode;         // キャンペーン実施拠点
                    campaignMaster.SectionGuideSnm = cmpaignMasterWork.SectionGuideSnm; // 拠点略称
                    campaignMaster.CustomerCode = cmpaignMasterWork.CustomerCode;       // 得意先コード
                    campaignMaster.CustomerSnm = cmpaignMasterWork.CustomerSnm;         // 得意先略称
                    campaignMaster.BLGoodsCode = cmpaignMasterWork.BLGoodsCode;         // BL商品コード
                    campaignMaster.GoodsMakerCd = cmpaignMasterWork.GoodsMakerCd;       // 商品メーカーコード
                    campaignMaster.GoodsNo = cmpaignMasterWork.GoodsNo;                 // 商品番号
                    campaignMaster.BLGroupCode = cmpaignMasterWork.BLGroupCode;         // BLグループコード
                    campaignMaster.SalesCode = cmpaignMasterWork.SalesCode;             // 販売区分コード
                    campaignMaster.SalesPriceSetDiv = cmpaignMasterWork.SalesPriceSetDiv; // 売価設定区分
                    campaignMaster.PriceFl = cmpaignMasterWork.PriceFl;                 // 価格（浮動）
                    campaignMaster.RateVal = cmpaignMasterWork.RateVal;                 // 掛率
                    campaignMaster.DiscountRate = cmpaignMasterWork.DiscountRate;       // 売価率
                    campaignMaster.PriceStartDate = cmpaignMasterWork.PriceStartDate;   // 価格開始日
                    campaignMaster.PriceEndDate = cmpaignMasterWork.PriceEndDate;       // 価格終了日
                    campaignMaster.BLGoodsHalfName = cmpaignMasterWork.BLGoodsHalfName; // ＢＬコード名称（半角）
                    campaignMaster.MakerName = cmpaignMasterWork.MakerName;             // メーカー名称
                    campaignMaster.GoodsName = cmpaignMasterWork.GoodsName;             // 商品名称
                    campaignMaster.BLGroupName = cmpaignMasterWork.BLGroupName;         // グループコード名称
                    campaignMaster.GuideName = cmpaignMasterWork.GuideName;             // ガイド名称
                    
                    retList.Add(campaignMaster);
                }
            }

        }

        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="cmpaignMasterWork"></param>
        /// <param name="campaignMasterPrintWork"></param>
        /// <returns></returns>
        private int DataCheck(CampaignMasterWork cmpaignMasterWork, CampaignMasterPrintWork campaignMasterPrintWork)
        {
            int status = 0;

            string upDateTime = cmpaignMasterWork.UpdateDateTime.Year.ToString("0000") +
                                cmpaignMasterWork.UpdateDateTime.Month.ToString("00") +
                                cmpaignMasterWork.UpdateDateTime.Day.ToString("00");

            if (campaignMasterPrintWork.LogicalDeleteCode == 1 &&
                campaignMasterPrintWork.DeleteDateTimeSt != 0 &&
                campaignMasterPrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < campaignMasterPrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > campaignMasterPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (campaignMasterPrintWork.LogicalDeleteCode == 1 &&
                        campaignMasterPrintWork.DeleteDateTimeSt != 0 &&
                        campaignMasterPrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < campaignMasterPrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (campaignMasterPrintWork.LogicalDeleteCode == 1 &&
                  campaignMasterPrintWork.DeleteDateTimeSt == 0 &&
                  campaignMasterPrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > campaignMasterPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            return status;
        }

        #endregion

        #endregion
    }
}
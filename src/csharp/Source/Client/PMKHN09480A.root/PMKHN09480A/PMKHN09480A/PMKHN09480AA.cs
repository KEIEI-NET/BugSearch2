//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 掛率設定マスタメン（掛率優先管理パターン） 
// プログラム概要   : 掛率設定マスタメン（掛率優先管理パターン）関連処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2010/08/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 楊明俊
// 修 正 日  2010/08/26  修正内容 : #13720の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 修 正 日  2010/09/10  修正内容 : 障害・改良対応8月ﾘﾘｰｽ
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 修 正 日  2010/09/26  修正内容 : Redmine#14490対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 修 正 日  2012/12/07  修正内容 : 2013/01/16配信分　Redmine#33663の#7
//                                  「仕入単価」と「仕入率」を表示する、且つ入力できる対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;

using System.Xml;
using System.Xml.Serialization;
using Broadleaf.Application.UIData;
using System.IO;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.Data;
using Broadleaf.Library.Text;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 掛率設定マスタメン（掛率優先管理パターン）関連処理アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 掛率設定マスタメン関連処理を行います。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2010/08/10</br>
    /// <br>Update Note: 2010/08/26 楊明俊 #13720の対応</br>
    /// <br>Update Note: 2010/09/10 高峰 障害・改良対応8月ﾘﾘｰｽ</br>
    /// <br>Update Note: 2010/09/26 呉元嘯 Redmine#14490対応</br>
    /// <br>Update Note: 2012/12/07 田建委</br>
    /// <br>管理番号   : 2013/01/16配信分</br>
    /// <br>             Redmine#33663の#7「仕入単価」と「仕入率」を表示する、且つ入力できる対応
    /// </remarks>
    public partial class RateProtyMngPatternAcs
    {
        # region ■Private Member
        /// <summary>掛率優先管理マスタデータセット</summary>
        /// <remarks></remarks> 
        private RateProtyMngDataSet _rateProtyMngDataSet;

        /// <summary>掛率マスタデータセット</summary>
        /// <remarks></remarks> 
        private RateProtyMngPatternDataSet _rateProtyMngPatternDataSet;
        private DataTable _originalRateProtyMngDataTable;//変更有無チェック用 検索時のデータ

        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

        private string _sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

        private static RateProtyMngPatternAcs _rateProtyMngPatternAcs;
        private IRateProtyMngPatternDB _iRateProtyMngPatternDB = null;

        // --- ADD 2010/09/09 ---------->>>>>
        private GoodsAcs _goodsAcs = null; //商品入力アクセスクラス
        // --- ADD 2010/09/09 ---------->>>>>
        #endregion

        #region  ■ Public Memebers
        /// <summary>
        /// 掛率優先管理マスタデータセット
        /// </summary>
        public RateProtyMngDataSet RateProtyMngDataSet
        {
            get { return this._rateProtyMngDataSet; }
        }

        /// <summary>
        /// 掛率マスタデータセット
        /// </summary>
        public RateProtyMngPatternDataSet RateProtyMngPatternDataSet
        {
            get { return this._rateProtyMngPatternDataSet; }
        }

        /// <summary>
        /// 変更有無チェック用 検索時のデータ
        /// </summary>
        public DataTable OriginalRateProtyMngDataTable
        {
            get { return this._originalRateProtyMngDataTable; }
        }

        #endregion ■ Public Memebers

        # region ■Constructer
        /// <summary>
        /// 掛率設定マスタメン関連処理アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 掛率設定マスタメン関連処理アクセスクラスコンストラクタを初期化します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        private RateProtyMngPatternAcs()
        {
            this._rateProtyMngDataSet = new RateProtyMngDataSet();
            this._rateProtyMngPatternDataSet = new RateProtyMngPatternDataSet();
            this._originalRateProtyMngDataTable = new DataTable();
            // ----------ADD 2010/09/09----------->>>>>
            this._goodsAcs = new GoodsAcs();

            // メニューモード時はサーバー読み込み固定
            this._goodsAcs.IsLocalDBRead = false;
            string msg = string.Empty;

            // 初期値データ取得
            int status = this._goodsAcs.SearchInitial(this._enterpriseCode, this._sectionCode, out msg);
            // ----------ADD 2010/09/09-----------<<<<<
            // リモートオブジェクト取得
            try
            {
                this._iRateProtyMngPatternDB = (IRateProtyMngPatternDB)MediationRateProtyMngPatternDB.GetRateProtyMngPatternDB();
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iRateProtyMngPatternDB = null;
            }
        }

        /// <summary>
        /// 売上伝票入力アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>売上伝票入力アクセスクラス インスタンス</returns>
        public static RateProtyMngPatternAcs GetInstance()
        {
            if (_rateProtyMngPatternAcs == null)
            {
                _rateProtyMngPatternAcs = new RateProtyMngPatternAcs();
            }

            return _rateProtyMngPatternAcs;
        }
        # endregion


        #region ■Public Method
        /// <summary>
        /// 拠点、単価種類で掛率優先管理マスタを読み込み登録されている内容表示処理
        /// </summary>
        /// <param name="rateProtyMngWork"></param>
        /// <param name="errMess"></param>
        /// <returns>抽出状態</returns>
        /// <remarks>
        /// <br>Note       : 拠点、単価種類で掛率優先管理マスタを読み込み登録されている内容表示を行う。 </br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        public int Search(RateProtyMngWork rateProtyMngWork, out string errMess)
        {
            return SearchProc(rateProtyMngWork, out errMess);
        }

        /// <summary>
        /// 拠点、単価種類で掛率優先管理マスタを読み込み登録されている内容表示処理
        /// </summary>
        /// <param name="rateProtyMngWork"></param>
        /// <param name="errMess"></param>
        /// <returns>抽出状態</returns>
        /// <remarks>
        /// <br>Note       : 拠点、単価種類で掛率優先管理マスタを読み込み登録されている内容表示を行う。 </br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        private int SearchProc(RateProtyMngWork rateProtyMngWork, out string errMess)
        {
            ArrayList rateProtyMngList = new ArrayList();
            errMess = string.Empty;
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            object paraobj = rateProtyMngWork;
            object retobj = null;
            try
            {
                // 掛率優先管理設定読み込み
                status = this._iRateProtyMngPatternDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData0);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    rateProtyMngList = retobj as ArrayList;
                    if (rateProtyMngList.Count > 0)
                    {
                        CopyToRateProtyMngTable(rateProtyMngList);
                    }
                }
            }
            catch (Exception ex)
            {
                errMess = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 抽出条件によってで掛率掛率マスタとマスタを読み込み処理
        /// </summary>
        /// <param name="rateProtyMngPatternWork"></param>
        /// <param name="newList">新規リスト</param>
        /// <param name="updateList">掛率マスタ(更新リスト)</param>
        /// <param name="patternMode">モード(0:BLコード;1:品番指定;2:単独指定;3:層別指定;4:商品掛率G指定;5:グループコード指定;6:メーカー指定)</param>
        /// <param name="retMessage">retMessage</param>
        /// <returns>抽出状態</returns>
        /// <remarks>
        /// <br>Note       : 抽出条件によってで掛率掛率マスタとマスタを読み込みます。 </br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        public int SearchRateRelationData(RateProtyMngPatternWork rateProtyMngPatternWork, out ArrayList newList, out ArrayList updateList, int patternMode, out string retMessage)
        {
            return SearchRateRelationDataProc(rateProtyMngPatternWork, out newList, out updateList, patternMode, out retMessage);
        }

        /// <summary>
        /// 抽出条件によってで掛率掛率マスタとマスタを読み込み処理
        /// </summary>
        /// <param name="rateProtyMngPatternWork"></param>
        /// <param name="newList">新規リスト</param>
        /// <param name="updateList">掛率マスタ(更新リスト)</param>
        /// <param name="patternMode">モード(0:BLコード;1:品番指定;2:単独指定;3:層別指定;4:商品掛率G指定;5:グループコード指定;6:メーカー指定)</param>
        /// <param name="retMessage">retMessage</param>
        /// <returns>抽出状態</returns>
        /// <remarks>
        /// <br>Note       : 抽出条件によってで掛率掛率マスタとマスタを読み込みます。 </br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        private int SearchRateRelationDataProc(RateProtyMngPatternWork rateProtyMngPatternWork, out ArrayList newList, out ArrayList updateList, int patternMode, out string retMessage)
        {
            retMessage = string.Empty;
            newList = new ArrayList();
            updateList = new ArrayList();
            object newListObj = null;
            object updateListObj = null;
            object paraObj = rateProtyMngPatternWork;
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            try
            {
                // 掛率マスタ読み込み
                status = this._iRateProtyMngPatternDB.SearchRateRelationData(out newListObj, out updateListObj, paraObj, patternMode, 0, ConstantManagement.LogicalMode.GetData0);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    newList = newListObj as ArrayList;
                    updateList = updateListObj as ArrayList;
                }
            }
            catch (Exception ex)
            {
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 掛率掛率マスタ更新処理
        /// </summary>
        /// <param name="rateProtyMng">rateProtyMng</param>
        /// <param name="mode">0:新規モード；1:更新モード</param>
        /// <param name="patternMode">patternMode(0:通常;1:層別)</param>
        /// <param name="retMessage">retMessage</param>
        /// <returns>抽出状態</returns>
        /// <remarks>
        /// <br>Note       : 掛率掛率マスタ更新を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        public int WriteRateRelationData(RateProtyMng rateProtyMng, int mode, int patternMode, out string retMessage)
        {
            retMessage = string.Empty;
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            ArrayList updateList = new ArrayList();
            ArrayList deleteList = new ArrayList();
            try
            {
                DetailGridDataToList(ref updateList, ref deleteList, rateProtyMng, mode);

                if (updateList.Count == 0 && deleteList.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                else
                {
                    // 掛率マスタ更新
                    status = this._iRateProtyMngPatternDB.WriteRateRelationData(updateList, deleteList, patternMode, out retMessage);
                }
            }
            catch (Exception ex)
            {
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;

        }
        #endregion ■Public Method

        #region ■Private Method

        /// <summary>
        /// データテーブル格納処理
        /// </summary>
        /// <param name="rateProtyMngList">掛率優先管理マスタリスト</param>
        /// <remarks>
        /// <br>Note       : データテーブル格納処理を行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        private void CopyToRateProtyMngTable(ArrayList rateProtyMngList)
        {
            this.RateProtyMngDataSet.RateProtyMng.Rows.Clear();
            foreach (RateProtyMngWork work in rateProtyMngList)
            {
                // 新規行取得
                RateProtyMngDataSet.RateProtyMngRow row = this.RateProtyMngDataSet.RateProtyMng.NewRateProtyMngRow();

                # region [copy]

                //掛率優先順位
                row.RatePriorityOrder = work.RatePriorityOrder;
                //掛率設定名称(商品)
                row.RateMngGoodsNm = work.RateMngGoodsNm;
                //掛率設定名称(得意先)
                row.RateMngCustNm = work.RateMngCustNm;
                //掛率設定区分
                row.RateSettingDivide = work.RateSettingDivide;
                //単価種類
                row.UnitPriceKind = work.UnitPriceKind;
                //拠点コード
                row.SectionCode = work.SectionCode;
                //掛率設定区分（商品）
                row.RateMngCustCd = work.RateMngCustCd;
                //掛率設定区分（得意先）
                row.RateMngGoodsCd = work.RateMngGoodsCd;
                # endregion

                // 追加
                this.RateProtyMngDataSet.RateProtyMng.AddRateProtyMngRow(row);
            }
        }

        /// <summary>
        /// データテーブル格納処理
        /// </summary>
        /// <param name="resultList">結果リスト</param>
        /// <remarks>
        /// <br>Note       : データテーブル格納処理を行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/10</br>
        /// <br>Update Note: 2010/09/09 曹文傑</br>
        /// <br>           : Redmine#14490と14492対応</br>
        /// <br>Update Note: 2010/09/26 呉元嘯</br>
        /// <br>           : Redmine#14490対応</br>
        /// </remarks>
        public void CopyToRateRelationDataSet(ArrayList resultList)
        {
            if (resultList.Count <= 0) return;
            this._originalRateProtyMngDataTable.Rows.Clear();
            this.RateProtyMngPatternDataSet.RateProtyMngPattern.Rows.Clear();
            int rowNo= 0;
            foreach (RateRlationWork work in resultList)
            {
                // 新規行取得
                RateProtyMngPatternDataSet.RateProtyMngPatternRow row = this.RateProtyMngPatternDataSet.RateProtyMngPattern.NewRateProtyMngPatternRow();
                ++rowNo;
                # region [copy]
                row.RowNo += rowNo;
                row.CreateDateTime = work.CreateDateTime;
                row.UpdateDateTime = work.UpdateDateTime;
                row.FileHeaderGuid = work.FileHeaderGuid;
                // ----------UPD 2010/09/26--------->>>>>
                //row.BLGoodsCode = work.BLGoodsCode;
                if (work.BLGoodsCode == -1)
                {
                    row.BLGoodsCode = string.Empty;
                }
                else
                {
                    row.BLGoodsCode = work.BLGoodsCode.ToString("D5");
                }
                row.MasterNm = work.MasterNm;
                //row.GoodsMakerCd = work.GoodsMakerCd;
                if (work.GoodsMakerCd == -1)
                {
                    row.GoodsMakerCd = string.Empty;
                }
                else
                {
                    row.GoodsMakerCd = work.GoodsMakerCd.ToString("D4"); 
                }
                
                // ----------ADD 2010/09/09----------->>>>>
                double listPrice = 0.0;
                double salesUnitCost = 0.0;

                if (!string.IsNullOrEmpty(work.GoodsNo))
                {
                    List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
                    
                    string msg = string.Empty;
                    listPrice = 0.0;
                    salesUnitCost = 0.0;

                    GoodsCndtn cndtn = new GoodsCndtn();
                    cndtn.EnterpriseCode = this._enterpriseCode;
                    if ("00".Equals(work.SectionCode))
                        cndtn.SectionCode = this._goodsAcs.LoginSectionCode;
                    else
                        cndtn.SectionCode = work.SectionCode;
                    cndtn.GoodsMakerCd = work.GoodsMakerCd;
                    cndtn.BLGoodsCode = work.BLGoodsCode;
                    cndtn.GoodsNo = work.GoodsNo;
                    cndtn.GoodsKindCode = 9;
                    cndtn.IsSettingSupplier = 1;
                    this._goodsAcs.Search(cndtn, out goodsUnitDataList, out msg);

                    this.GetPrice(goodsUnitDataList, out listPrice, out salesUnitCost);

                    if (goodsUnitDataList != null && goodsUnitDataList.Count > 0)
                    {
                        GoodsUnitData goodsUnitData = goodsUnitDataList[0];
                        //row.GoodsNo = work.GoodsNo + " " + goodsUnitData.GoodsName; // DEL 2010/09/25
                        row.GoodsNo = work.GoodsNo; // ADD 2010/09/25
                        row.GoodsNo2 = goodsUnitData.GoodsName; // ADD 2010/09/25
                    }
                    
                    //row.GoodsNo2 = work.GoodsNo; // DEL 2010/09/25
                    row.ListPrice = listPrice;
                    row.SalesUnitCost = salesUnitCost;

                }
                else
                {
                    row.GoodsNo = string.Empty;
                    row.GoodsNo2 = string.Empty;
                    row.ListPrice = work.ListPrice;
                    row.SalesUnitCost = work.SalesUnitCost;
                }
                // ----------ADD 2010/09/09-----------<<<<<
                //row.GoodsRateGrpCode = work.GoodsRateGrpCode;
                row.GoodsRateRank = work.GoodsRateRank;
                //row.BLGroupCode = work.BLGroupCode;
                //row.CustomerCode = work.CustomerCode;
                //row.CustRateGrpCode = work.CustRateGrpCode;
                //row.SupplierCd = work.SupplierCd;
                if (work.GoodsRateGrpCode == -1)
                {
                    row.GoodsRateGrpCode = string.Empty;
                }
                else
                {
                    row.GoodsRateGrpCode = work.GoodsRateGrpCode.ToString("D4");
                }
                if (work.BLGroupCode == -1)
                {
                    row.BLGroupCode = string.Empty;
                }
                else
                {
                    row.BLGroupCode = work.BLGroupCode.ToString("D5");
                }
                if (work.CustomerCode == -1)
                {
                    row.CustomerCode = string.Empty;
                }
                else
                {
                    row.CustomerCode = work.CustomerCode.ToString("D8");
                }
                if (work.CustRateGrpCode == -1)
                {
                    row.CustRateGrpCode = string.Empty;
                }
                else
                {
                    row.CustRateGrpCode = work.CustRateGrpCode.ToString("D4");
                }
                if (work.SupplierCd == -1)
                {
                    row.SupplierCd = string.Empty;
                }
                else
                {
                    row.SupplierCd = work.SupplierCd.ToString("D6");
                }
                // ----------UPD 2010/09/26-----------<<<<<
                row.LotCount = work.LotCount;
                row.PriceFl = work.PriceFl;
                row.RateVal = work.RateVal;
                row.UnPrcFracProcUnit = work.UnPrcFracProcUnit;
                row.UnPrcFracProcDiv = work.UnPrcFracProcDiv;
                if (work.UnPrcFracProcDiv == 1)
                {
                    row.UnPrcFracProcDivNm = "1";
                }
                else if (work.UnPrcFracProcDiv == 2)
                {
                    row.UnPrcFracProcDivNm = "2";
                }
                else if (work.UnPrcFracProcDiv == 3)
                {
                    row.UnPrcFracProcDivNm = "3";
                }
                else
                {
                    row.UnPrcFracProcDivNm = string.Empty;
                }
                row.GrsProfitSecureRate = work.GrsProfitSecureRate;
                row.UpRate = work.UpRate;
                //row.ListPrice = work.ListPrice; // DEL 2010/09/09
                //row.SalesUnitCost = work.SalesUnitCost; // DEL 2010/09/09
                row.UpdateLineFlg = work.UpdateLineFlg; // ADD 2010/09/10
                # endregion

                // 追加
                this.RateProtyMngPatternDataSet.RateProtyMngPattern.AddRateProtyMngPatternRow(row);
            }
            this._originalRateProtyMngDataTable = this.RateProtyMngPatternDataSet.RateProtyMngPattern.Copy();
        }

        /// <summary>
        /// データテーブル格納処理
        /// </summary>
        /// <param name="updateList">掛率マスタリスト(更新用)</param>
        /// <param name="deleteList">掛率マスタリスト(削除用)</param>
        /// <param name="rateProtyMng">rateProtyMng</param>
        /// <param name="mode">0:新規モード；1:更新モード</param>
        /// <remarks>
        /// <br>Note       : データテーブル格納処理を行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/10</br>
        /// <br>update Note: 2010/08/26 楊明俊 #13720対応</br>
        /// <br>Update Note: 2010/09/26 呉元嘯 仕様連絡 #14492対応</br>
        /// </remarks>
        private void DetailGridDataToList(ref ArrayList updateList, ref ArrayList deleteList, RateProtyMng rateProtyMng, int mode)
        {
            RateWork rateWork = null;

            #region data
            foreach (RateProtyMngPatternDataSet.RateProtyMngPatternRow row in this.RateProtyMngPatternDataSet.RateProtyMngPattern)
            {
                //更新対象外
                if (row.SaveFlg == 0)
                {
                    continue;
                }

                #region 掛率マスタ
                rateWork = new RateWork();
                // 作成日時
                rateWork.CreateDateTime = row.CreateDateTime;
                // 更新日時
                rateWork.UpdateDateTime = row.UpdateDateTime;
                // 企業コード
                rateWork.EnterpriseCode = this._enterpriseCode;
                // 論理削除区分
                rateWork.LogicalDeleteCode = 0;
                // 拠点コード
                rateWork.SectionCode = rateProtyMng.SectionCode.Trim();
                // 単価掛率設定区分
                rateWork.UnitRateSetDivCd = rateProtyMng.UnitPriceKind.ToString() + rateProtyMng.RateSettingDivide.Trim();
                // 単価種類
                rateWork.UnitPriceKind = rateProtyMng.UnitPriceKind.ToString();
                // 掛率設定区分
                rateWork.RateSettingDivide = rateProtyMng.RateSettingDivide.Trim();
                // 掛率設定区分（商品）
                rateWork.RateMngGoodsCd = rateProtyMng.RateMngGoodsCd.Trim();
                // 掛率設定名称（商品）
                rateWork.RateMngGoodsNm = rateProtyMng.RateMngGoodsNm.Trim();
                // 掛率設定区分（得意先）
                rateWork.RateMngCustCd = rateProtyMng.RateMngCustCd.Trim();
                // 掛率設定名称（得意先）
                rateWork.RateMngCustNm = rateProtyMng.RateMngCustNm.Trim();
                // ----------UPD 2010/09/26--------->>>>>
                // 商品メーカーコード
                //rateWork.GoodsMakerCd = row.GoodsMakerCd;
                rateWork.GoodsMakerCd = TStrConv.StrToIntDef(row.GoodsMakerCd, 0);
                // 商品番号
                //rateWork.GoodsNo = row.GoodsNo.Trim();
                //rateWork.GoodsNo = row.GoodsNo2.Trim(); // DEL 2010/09/25
                rateWork.GoodsNo = row.GoodsNo.Trim(); // ADD 2010/09/25
                // 商品掛率ランク
                rateWork.GoodsRateRank = row.GoodsRateRank.Trim();
                // BL商品コード
                //rateWork.BLGoodsCode = row.BLGoodsCode;
                rateWork.BLGoodsCode = TStrConv.StrToIntDef(row.BLGoodsCode, 0);
                // 得意先コード
                //rateWork.CustomerCode = row.CustomerCode;
                rateWork.CustomerCode = TStrConv.StrToIntDef(row.CustomerCode, 0);
                // 得意先掛率グループコード
                //-----UPD 2010/08/26---------->>>>>
                //rateWork.CustRateGrpCode = row.CustRateGrpCode;
                //if (work.CustRateGrpCode == -1)
                //{
                //    rateWork.CustRateGrpCode = 0;
                //}
                //else
                //{
                //    rateWork.CustRateGrpCode = row.CustRateGrpCode;
                //}
                //-----UPD 2010/08/26----------<<<<<
                // 仕入先コード
                //rateWork.SupplierCd = row.SupplierCd;
                rateWork.CustRateGrpCode = TStrConv.StrToIntDef(row.CustRateGrpCode, 0);
                rateWork.SupplierCd = TStrConv.StrToIntDef(row.SupplierCd, 0);
                // ロット数
                rateWork.LotCount = row.LotCount;
                // 価格
                rateWork.PriceFl = row.PriceFl;
                // 掛率
                rateWork.RateVal = row.RateVal;
                // 単価端数処理単位
                rateWork.UnPrcFracProcUnit = row.UnPrcFracProcUnit;
                // 単価端数処理区分
                if (!string.IsNullOrEmpty(row.UnPrcFracProcDivNm))
                {
                    if (row.UnPrcFracProcDivNm == "1")
                    {
                        rateWork.UnPrcFracProcDiv = 1;
                    }
                    else if (row.UnPrcFracProcDivNm == "2")
                    {
                        rateWork.UnPrcFracProcDiv = 2;
                    }
                    else if (row.UnPrcFracProcDivNm == "3")
                    {
                        rateWork.UnPrcFracProcDiv = 3;
                    }
                }
                // 商品掛率グループコード
                //rateWork.GoodsRateGrpCode = row.GoodsRateGrpCode;
                // BLグループコード
                //rateWork.BLGroupCode = row.BLGroupCode;
                rateWork.GoodsRateGrpCode = TStrConv.StrToIntDef(row.GoodsRateGrpCode, 0);
                rateWork.BLGroupCode = TStrConv.StrToIntDef(row.BLGroupCode, 0);
                // ----------UPD 2010/09/26---------<<<<<

                // UP率
                rateWork.UpRate = row.UpRate;
                // 粗利確保率
                rateWork.GrsProfitSecureRate = row.GrsProfitSecureRate;

                if (mode == 0)
                {
                    // ロット数
                    rateWork.LotCount = 9999999.99;
                }
                else
                {
                    // GUID
                    rateWork.FileHeaderGuid = row.FileHeaderGuid;
                }
                #endregion 掛率マスタ

                //　新規モード(行削除したデータが更新対象外)
                if (mode == 0)
                {
                    if (row.LogicalDeleteCode == 0)
                    {
                        updateList.Add(rateWork);
                    }
                }
                //　更新モード(行削除したデータも更新対象)
                else
                {
                    // 行削除
                    if (row.LogicalDeleteCode != 0)
                    {
                        if (row.UpdateLineFlg) { // ADD 2010/09/10
                            deleteList.Add(rateWork);
                        } // ADD 2010/09/10
                    }
                    else
                    {
                        updateList.Add(rateWork);
                    }
                }

            }

            // 更新用掛率マスタFilter処理
            MergeUpdateData(rateProtyMng, ref updateList);
            #endregion data
        }

        /// <summary>
        /// 更新用掛率マスタFilter処理
        /// </summary>
        /// <param name="updateList">掛率マスタリスト(更新用)</param>
        /// <param name="rateProtyMng">rateProtyMng</param>
        /// <remarks>
        /// <br>Note       : 更新用掛率マスタFilterを行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/10</br>
        /// <br>Update Note: 2012/12/07 田建委</br>
        /// <br>管理番号   : 2013/01/16配信分</br>
        /// <br>             Redmine#33663の#7「仕入単価」と「仕入率」を表示する、且つ入力できる対応
        /// </remarks>
        private void MergeUpdateData(RateProtyMng rateProtyMng, ref ArrayList updateList)
        {
            if (updateList.Count == 0) return;
            ArrayList updateListNew = new ArrayList();
            switch (rateProtyMng.UnitPriceKind)
            {
                // 売価場合
                case 1:
                    foreach (RateWork rateWork in updateList)
                    {
                        //「売価額・売価率・原価UP率・粗利確保率」いずれか≠0
                        if (rateWork.PriceFl != 0 || rateWork.RateVal != 0 ||
                            rateWork.UpRate != 0 || rateWork.GrsProfitSecureRate != 0)
                        {
                            updateListNew.Add(rateWork);
                        }
                    }
                    break;
                // 原価場合
                case 2:
                    foreach (RateWork rateWork in updateList)
                    {
                        //「仕入率」いずれか≠0
                        //if (rateWork.RateVal != 0) // DEL 2012/12/07 田建委 Redmine#33663の#7
                        if (rateWork.RateVal != 0 || rateWork.PriceFl != 0) // ADD 2012/12/07 田建委 Redmine#33663の#7
                        {
                            updateListNew.Add(rateWork);
                        }
                    }
                    break;
                // 価格場合
                case 3:
                    foreach (RateWork rateWork in updateList)
                    {
                        //「ﾕｰｻﾞｰ定価・定価UP率」いずれか≠0
                        if (rateWork.PriceFl != 0 || rateWork.UpRate != 0)
                        {
                            updateListNew.Add(rateWork);
                        }
                    }
                    break;
            }
            updateList = updateListNew;
        }

        // --- ADD 2010/09/09 ---------->>>>>
        /// <summary>
        /// 品番を入力すると、価格と原価を取る
        /// </summary>
        /// <param name="goodsUnitDataList">商品管理情報マスタ</param>
        /// <param name="listPrice">標準価格</param>
        /// <param name="salesUnitCost">原単価</param>
        /// <remarks>
        /// <br>Note       : 品番を入力すると、価格と原価を取る。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2010/09/09</br>
        /// </remarks>
        public void GetPrice(List<GoodsUnitData> goodsUnitDataList, out double listPrice, out double salesUnitCost)
        {
            if (this._goodsAcs == null)
            {
                this._goodsAcs = new GoodsAcs();
            }
            double price = 0;
            double cost = 0;
            if (goodsUnitDataList.Count > 0)
            {
                GoodsUnitData goodsUnitData = new GoodsUnitData();
                GoodsInputDataSet.GoodsPriceDataTable dt = new GoodsInputDataSet.GoodsPriceDataTable();
                GoodsInputDataSet.GoodsPriceRow goodsPriceRow = dt.NewGoodsPriceRow();
                goodsUnitData = goodsUnitDataList[0];
                this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData);

                switch (goodsUnitData.OfferKubun)
                {
                    case 0: // ユーザー登録
                    case 1: // 提供純正編集
                    case 2: // 提供優良編集
                        if (goodsUnitData.LogicalDeleteCode == 0)
                        {
                            if (goodsUnitData != null && goodsUnitData.GoodsPriceList != null)
                            {
                                if (goodsUnitData.GoodsPriceList.Count > 0)
                                {
                                    GoodsPrice goodsPrice = GetGoodsPriceByPriceStartDate(DateTime.Today, goodsUnitData.GoodsPriceList);

                                    // 標準価格
                                    if (goodsPrice != null)
                                    {
                                        price = goodsPrice.ListPrice;
                                    }

                                    // 価格情報を再計算するので初期化
                                    goodsPriceRow.CalcStockRate = 0.0;          // 計算原価率
                                    goodsPriceRow.CalcSalesUnitCost = 0.0;      // 計算原価額
                                    goodsPriceRow.CalcMaster = string.Empty;    // 算出マスタ
                                    goodsPriceRow.PriorityOrder = 0;            // 優先順位
                                    goodsPriceRow.EnterpriseCode = goodsPrice.EnterpriseCode;
                                    goodsPriceRow.GoodsMakerCd = goodsPrice.GoodsMakerCd;
                                    goodsPriceRow.GoodsNo = goodsPrice.GoodsNo;
                                    goodsPriceRow.ListPrice = goodsPrice.ListPrice;

                                    goodsPriceRow.SalesUnitCost = goodsPrice.SalesUnitCost;
                                    goodsPriceRow.StockRate = goodsPrice.StockRate;
                                    goodsPriceRow.StockUnPrcFrcProcCd = goodsUnitData.StockUnPrcFrcProcCd;
                                    goodsPriceRow.PriceStartDate = goodsPrice.PriceStartDate;

                                    if (goodsPrice.ListPrice != 0)
                                    {
                                        this._goodsAcs.CalclateUnitPrice(goodsPriceRow, goodsUnitData);             // 単価算出
                                        this._goodsAcs.SettingCalcMaster(goodsPriceRow);                            // 算出マスタ
                                        this._goodsAcs.SettingCalcStockRate(goodsPriceRow);                         // 算出用原価率
                                        this._goodsAcs.SettingCalcSalesUnitCost(goodsPriceRow);                     // 算出用原価単価
                                        if (!goodsPriceRow.PriceStartDate.Equals(DateTime.MinValue))
                                        {
                                            cost = goodsPriceRow.CalcSalesUnitCost;    // 原単価
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            listPrice = price;
            salesUnitCost = cost;
        }
        
        /// <summary>
        /// 指定された日時に合う価格情報レコードを取得します。
        /// </summary>
        /// <param name="dateTime">日時</param>
        /// <returns>
        /// 価格開始日≦指定日時のレコードのうち、最近のものを返します。
        /// （指定日時より未来のレコードは無視されます）
        /// </returns>
        /// <remarks>
        /// <br>Note       : 指定された日時に合う価格情報レコードを取得します。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2010/09/09</br>
        /// </remarks>
        private GoodsPrice GetGoodsPriceByPriceStartDate(DateTime dateTime, List<GoodsPrice> goodsPriceList)
        {
            // 価格情報グリッドの最大行数　※保存、起動のタイミングで開始日付の昇順にソートされる
            int rowCount = goodsPriceList.Count;

            // 価格開始日で価格情報レコードをソート（降順）
            SortedList<DateTime, GoodsPrice> sortedGoodsPriceRowList = new SortedList<DateTime, GoodsPrice>();
            for (int i = 0; i < rowCount; i++)
            {
                DateTime key = goodsPriceList[i].PriceStartDate;
                if (key.Equals(DateTime.MinValue))
                {
                    key = key.AddMilliseconds((double)(rowCount - i));
                }
                sortedGoodsPriceRowList.Add(key, goodsPriceList[i]);
            }

            int count = 0;
            bool flag = false;
            for (int i = rowCount - 1; i >= 0; i--)
            {
                DateTime key = sortedGoodsPriceRowList.Keys[i];
                if (sortedGoodsPriceRowList[key].PriceStartDate <= dateTime)
                {
                    count = i;
                    flag = true;
                    break;
                }
            }

            // 価格開始日≦システム日付
            if (flag)
            {
                DateTime key = sortedGoodsPriceRowList.Keys[count];
                return sortedGoodsPriceRowList[key];
            }
            else
            {
                // 価格開始日 > システム日付
                if (rowCount != 0)
                {
                    DateTime key = sortedGoodsPriceRowList.Keys[0];
                    sortedGoodsPriceRowList[key].ListPrice = 0;
                    sortedGoodsPriceRowList[key].SalesUnitCost = 0;
                    sortedGoodsPriceRowList[key].StockRate = 0;
                    return sortedGoodsPriceRowList[key];
                }
                // 価格開始日はNULL
                else
                {
                    GoodsPrice gPrice = new GoodsPrice();
                    gPrice.ListPrice = 0;
                    gPrice.SalesUnitCost = 0;
                    gPrice.StockRate = 0;
                    return gPrice;
                }
            }
        }
        // --- ADD 2010/09/09 ----------<<<<<
        #endregion ■Private Method
    }
}

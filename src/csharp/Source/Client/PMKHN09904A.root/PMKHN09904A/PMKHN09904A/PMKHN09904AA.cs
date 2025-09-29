using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;
using System.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 掛率一括修正・登録Ⅱアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 掛率一括修正・登録Ⅱのアクセス制御を行います。</br>
    /// <br>Programmer : caohh</br>
    /// <br>Date       : 2013/02/19</br>
    /// </remarks>
    public class RateUpdateAcs
    {
        #region ■ Private Members
        // 掛率マスタリモート
        private IRate2DB _iRate2DB = null;
        // 純正設定マスタリモート
        private IPureSettingPmDB _iPureSettingPmDB = null;
        // 層別設定マスタリモート
        private IPartsLayerStPmDB _iPartsLayerStPmDB = null;
        // 帳票出力設定データクラス
        private static PrtOutSet stc_PrtOutSet = null;
        // 帳票出力設定アクセスクラス
        private static PrtOutSetAcs stc_PrtOutSetAcs = new PrtOutSetAcs();
        private static Employee stc_Employee = new Employee();

        /// <summary>
        /// BLコード情報 key: BLコード　value: BLコード情報
        /// </summary>
        private Dictionary<int, BLGoodsCdUMnt> _blCodeDic = new Dictionary<int, BLGoodsCdUMnt>();

        /// <summary>
        /// BLグループコード情報
        /// </summary>
        private Dictionary<int, BLGroupU> _blGroupCodeDic = new Dictionary<int, BLGroupU>();
        #endregion ■ Private Members 

        #region ■ Construcstor
        /// <summary>
        /// 掛率一括修正・登録Ⅱアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 掛率一括修正・登録Ⅱアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
        /// </remarks>
        public RateUpdateAcs()
        {
            try
            {
                // リモートオブジェクト取得
                this._iRate2DB = (IRate2DB)MediationRate2DB.GetRate2DB();
                this._iPureSettingPmDB = (IPureSettingPmDB)MediationPureSettingPmDB.GetPureSettingPmDB();
                this._iPartsLayerStPmDB = (IPartsLayerStPmDB)MediationPartsLayerStPmDB.GetPartsLayerStPmDB();
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iRate2DB = null;
            }
        }
        #endregion ■ Construcstor

        #region プロパティー
        /// <summary>
        ///  BLコード情報
        /// </summary>
        public Dictionary<int, BLGoodsCdUMnt> BLCodeDic
        {
            get{return this._blCodeDic;}
            set{this._blCodeDic=value;}
        }

        /// <summary>
        ///  BLグループコード情報
        /// </summary>
        public Dictionary<int, BLGroupU> BLGroupCodeDic
        {
            get { return this._blGroupCodeDic; }
            set { this._blGroupCodeDic = value; }
        }
        #endregion


        #region ■ Public Methods
        /// <summary>
        /// 掛率マスタ更新処理
        /// </summary>
        /// <param name="saveList">保存リスト</param>
        /// <param name="eFlag">新追加行フラグ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 掛率マスタを更新します。</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
        /// </remarks>
        public int Write(ArrayList saveList,bool eFlag)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList paraRateList = new ArrayList();

                for (int i = 0; i < saveList.Count; i++)
                {
                    // クラスメンバコピー処理
                    paraRateList.Add(CopyToRateWorkFromRate((Rate)saveList[i]));
                }

                object paraObj = (object)paraRateList;

                status = this._iRate2DB.Write(ref paraObj, eFlag);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        /// <summary>
        /// 掛率マスタ削除処理
        /// </summary>
        /// <param name="deleteList">削除リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 掛率マスタを削除します。</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
        /// </remarks>
        public int Delete(ArrayList deleteList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                byte[] paraRateWork = null;
                ArrayList rateWorkList = new ArrayList();

                for (int i = 0; i < deleteList.Count; i++)
                {
                    // クラスメンバコピー処理
                    rateWorkList.Add(CopyToRateWorkFromRate((Rate)deleteList[i]));
                }

                // ArrayListから配列を生成
                Rate2Work[] rateWorks = (Rate2Work[])rateWorkList.ToArray(typeof(Rate2Work));

                // シリアライズ
                paraRateWork = XmlByteSerializer.Serialize(rateWorks);

                // 物理削除処理
                status = this._iRate2DB.DeleteRate(paraRateWork);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        /// <summary>
        /// 掛率マスタ検索処理
        /// </summary>
        /// <param name="rateSearchResultList">掛率マスタ検索結果リスト</param>
        /// <param name="rateSearchParam">掛率マスタ検索条件</param>
        /// <remarks>
        /// <br>Note       : 掛率マスタを検索します。</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
        /// </remarks>
        public int Search(out List<Rate2SearchResult> rateSearchResultList, Rate2SearchParam rateSearchParam)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
             BLGoodsCdAcs blGoodsCdAcs = new BLGoodsCdAcs();
            rateSearchResultList = new List<Rate2SearchResult>();
            try
            {
                // クラスメンバコピー処理(E→D)
                // 検索条件設定
                Rate2ParamWork paraWork = CopyToRateSearchParamWorkFromRateSearchParam(rateSearchParam);

                object paraObj = paraWork;
                // 純正検索(メーカーコードは「0-999」の場合、純正情報検索)
                if (rateSearchParam.GoodsMakerCd > 0 && rateSearchParam.GoodsMakerCd < 1000)
                {
                    // 純正設定List作成
                    List<Rate2SearchResult> pureDataSettingList;

                    // 純正データList設定
                    PureDataSettingList(out pureDataSettingList, rateSearchParam);
                    
                    object retGoodsObj;
                    object retRateObj;
                    //商品管理情報マスタと掛率マスタ検索
                    status = this._iRate2DB.SearchPureRate(out retGoodsObj, out retRateObj, paraObj, 0, ConstantManagement.LogicalMode.GetData01);
                    if (status == 0)
                    {
                        //純正設定Listと商品管理情報関連
                        ArrayList retGoodsList = retGoodsObj as ArrayList;
                        ArrayList retRateList = retRateObj as ArrayList;
                        List<Rate2SearchResult> pureGoodsSearchResult;

                        // ｢ALL｣や｢0000｣のデータフィルタ
                        ArrayList filterList = new ArrayList();
                        DataFilter(retRateList, rateSearchParam, ref filterList);

                        // ★★★★純正設定データと商品管理情報の関連（純正設定データ left join 商品管理情報   join後、層別情報と関連（層別の場合））★★★★
                        MergePureAndGoods(out pureGoodsSearchResult, pureDataSettingList, retGoodsList, rateSearchParam, 0);

                        // ★★★★純正商品と掛率関連（純正設定データ left join 商品管理情報 left join 掛率情報）★★★★
                        MergePureGoodsAndRate(out rateSearchResultList, pureGoodsSearchResult, filterList, rateSearchParam);


                        // 処理後、結果がない場合
                        if (rateSearchResultList.Count > 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        else
                        {
                            return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                        // 親データがない場合に親データの追加処理
                        SetParentData(ref rateSearchResultList, rateSearchParam);
                        //子親データがない場合に親データの追加処理
                        if (rateSearchParam.GoodsChangeMode == 0) // 商品掛率の場合、子親データ作成
                        {
                            SetGroupParentData(ref rateSearchResultList);
                        }
                        else                                      // 層別の場合、子親データ作成
                        {
                            SetGroupParaentDataByRank(ref rateSearchResultList);
                        }
                        
                        // ソート処理
                        Rate2SchRstSort rate2SchRstSort = new Rate2SchRstSort(rateSearchParam.GoodsChangeMode);
                        rateSearchResultList.Sort(rate2SchRstSort);
                    }
                }
                else
                {
 　                 object retPrmSettingObj;
                    object retGoodsObj;
                    object retRateObj;
                    //優良設定マスタと商品管理情報マスタと掛率マスタ検索
                    status = this._iRate2DB.SearchPrmRate(out retPrmSettingObj, out retGoodsObj, out retRateObj, paraObj, 0, ConstantManagement.LogicalMode.GetData01);
                    if (status == 0)
                    {
                        //優良設定Listと商品管理情報関連
                        List<Rate2SearchResult> retPrmSettingList = new List<Rate2SearchResult>();
                        ArrayList retGoodsList = retGoodsObj as ArrayList;
                        ArrayList retRateList = retRateObj as ArrayList;
                        List<Rate2SearchResult> prmGoodsSearchResult;

                        // ｢ALL｣や｢0000｣のデータフィルタ
                        ArrayList filterList = new ArrayList();
                        DataFilter(retRateList, rateSearchParam, ref filterList);

                        //クラスメンバコピー処理(D→E)
                        foreach (Rate2SearchResultWork retWork in retPrmSettingObj as ArrayList)
                        {
                            // クラスメンバコピー処理(D→E)
                            retPrmSettingList.Add(CopyToRateSearchResultFromRateSearchResultWork(retWork));
                        }

                        // ★★★★優良設定データと商品管理情報の関連（優良設定データ left join 商品管理情報   join後、層別情報と関連（層別の場合））★★★★
                        MergePureAndGoods(out prmGoodsSearchResult, retPrmSettingList, retGoodsList, rateSearchParam, 1);

                        // ★★★★優良商品と掛率関連（優良設定データ left join 商品管理情報 left join 掛率情報）★★★★
                        MergePureGoodsAndRate(out rateSearchResultList, prmGoodsSearchResult, filterList, rateSearchParam);

                        // 処理後、結果がない場合
                        if (rateSearchResultList.Count > 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        else
                        {
                            return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                        // 親データがない場合に親データの追加処理
                        SetParentData(ref rateSearchResultList, rateSearchParam);
                        //子親データがない場合に親データの追加処理
                        if (rateSearchParam.GoodsChangeMode == 0) // 商品掛率の場合、子親データ作成
                        {
                            SetGroupParentData(ref rateSearchResultList);
                        }
                        else                                      // 層別の場合、子親データ作成
                        {
                            SetGroupParaentDataByRank(ref rateSearchResultList);
                        }

                        // ソート処理
                        Rate2SchRstSort rate2SchRstSort = new Rate2SchRstSort(rateSearchParam.GoodsChangeMode);
                        rateSearchResultList.Sort(rate2SchRstSort);
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                rateSearchResultList = new List<Rate2SearchResult>();
            }

            return (status);
        }

        /// <summary>
        /// 単一商品情報の掛率検索
        /// </summary>
        /// <param name="rate2WorkList">掛率マスタ検索結果リスト</param>
        /// <param name="rateSearchParam">掛率マスタ検索条件</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 掛率マスタを検索します。</br>
        /// <br>Programmer : 董桂鈺</br>
        /// <br>Date       : 2013/04/03</br>
        /// </remarks>
        public int SearchByOneGoodsInfo(out List<Rate2SearchResult> rate2SearchResultList, Rate2SearchParam rateSearchParam)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            rate2SearchResultList = new List<Rate2SearchResult>();
            try
            {
                // クラスメンバコピー処理(E→D)
                // 検索条件設定
                Rate2ParamWork paraWork = CopyToRateSearchParamWorkFromRateSearchParam(rateSearchParam);

                object paraObj = paraWork;

                object retRateObj;
                //掛率マスタ検索
                status = this._iRate2DB.SearchRate(out retRateObj, paraObj, 0, ConstantManagement.LogicalMode.GetData01);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList rate2WorkList = retRateObj as ArrayList;
                    // ｢ALL｣や｢0000｣のデータフィルタ
                    ArrayList filterList = new ArrayList();
                    DataFilter(rate2WorkList, rateSearchParam, ref filterList);
                    // 拠点違いデータを分離する
                    Dictionary<string, ArrayList> rateDic;
                    GetRateBySection(out rateDic, filterList);
                    // 最小ロット数が含む主KeyListを取得する
                    List<string> lotCountKeyList;
                    GetRateByLotCount(out lotCountKeyList, filterList);
                    foreach (string rateDickey in rateDic.Keys)
                    {
                        // 非最小ロット数のデータを取得しない
                        if (!lotCountKeyList.Contains(rateDickey))
                        {
                            continue;
                        }
                        Rate2SearchResult tempSearchResult = new Rate2SearchResult();
                        Rate2Work rateResultWork = new Rate2Work();

                        #region 拠点のよって、商品管理情報分離する
                        ArrayList rateBySectionList = rateDic[rateDickey] as ArrayList;
                        // 拠点が一つある場合
                        if (rateBySectionList.Count == 1)
                        {
                            rateResultWork = rateBySectionList[0] as Rate2Work;
                        }
                        // 複数の拠点がある場合
                        else
                        {
                            foreach (Rate2Work tempRate2Work in rateBySectionList)
                            {
                                // 画面入力拠点と同じデータを選択する
                                if (tempRate2Work.SectionCode.Trim() == rateSearchParam.SectionCode[0].Trim())
                                {
                                    rateResultWork = tempRate2Work;
                                    break;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                        #endregion 拠点のよって、商品管理情報分離する

                        // 検索結果がRate2WorkListからRate2SearchResultListに渡します
                        CopyRateWorkToRate2SearchResult(ref tempSearchResult, rateResultWork);
                        tempSearchResult.GoodsRateRank = rateResultWork.GoodsRateRank;
                        rate2SearchResultList.Add(tempSearchResult);
                    }
                    
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            
            return status;
        }

        #region ◆ 帳票設定データ取得
        /// <summary>
        /// 帳票出力設定読込
        /// </summary>
        /// <param name="retPrtOutSet">帳票出力設定データクラス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 自拠点の帳票出力設定の読込を行います。</br>
        /// <br>Programmer : LDNS wangqx</br>
        /// <br>Date       : 2013/03/05</br>
        /// </remarks>
        static public int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            retPrtOutSet = new PrtOutSet();
            errMsg = "";
            // ログイン拠点取得
            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            if (loginEmployee != null)
            {
                stc_Employee = loginEmployee.Clone();
            }
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
        #endregion 帳票設定データ取得

        #endregion ■ Public Methods

        #region ■ Private Methods
        /// <summary>
        /// クラスメンバコピー処理(E→D)
        /// </summary>
        /// <param name="rateSearchParam">掛率マスタ検索条件</param>
        /// <returns>掛率マスタ検索条件ワーク</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバをコピーします。</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
        /// </remarks>
        private Rate2ParamWork CopyToRateSearchParamWorkFromRateSearchParam(Rate2SearchParam rateSearchParam)
        {
            Rate2ParamWork paraWork = new Rate2ParamWork();

            paraWork.EnterpriseCode = rateSearchParam.EnterpriseCode;       // 企業コード
            paraWork.SectionCode = rateSearchParam.SectionCode;             // 拠点コード
            paraWork.SupplierCd = rateSearchParam.SupplierCd;               // 仕入先コード
            paraWork.GoodsRateGrpCode = rateSearchParam.GoodsRateGrpCode;   // 商品掛率グループコード
            paraWork.GoodsRateRank = rateSearchParam.GoodsRateRank;         // 層別
            paraWork.GoodsMakerCd = rateSearchParam.GoodsMakerCd;           // メーカーコード
            paraWork.CustomerCode = rateSearchParam.CustomerCode;           // 得意先コード
            paraWork.CustRateGrpCode = rateSearchParam.CustRateGrpCode;     // 得意先掛率グループコード
            paraWork.PrmSectionCode = rateSearchParam.PrmSectionCode;       // ログイン拠点コード

            paraWork.GoodsChangeMode = rateSearchParam.GoodsChangeMode;

            paraWork.BlCd = rateSearchParam.BlCd;                          // BLコード
            paraWork.GroupCd = rateSearchParam.GroupCd;                      // BLグループコード
            paraWork.GoodsRateGrpCode = rateSearchParam.GoodsRateGrpCode;  // グループコード


            return paraWork;
        }

        /// <summary>
        /// クラスメンバコピー処理(D→E)
        /// </summary>
        /// <param name="rateSearchResultWork">掛率マスタ検索結果ワーク</param>
        /// <returns>掛率マスタ検索結果</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバをコピーします。</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
        /// </remarks>
        private Rate2SearchResult CopyToRateSearchResultFromRateSearchResultWork(Rate2SearchResultWork rateSearchResultWork)
        {
            Rate2SearchResult result = new Rate2SearchResult();

            // 掛率マスタより取得
            result.CreateDateTime = rateSearchResultWork.CreateDateTime;            // 作成日時
            result.UpdateDateTime = rateSearchResultWork.UpdateDateTime;            // 更新日時
            result.EnterpriseCode = rateSearchResultWork.EnterpriseCode;            // 企業コード
            result.FileHeaderGuid = rateSearchResultWork.FileHeaderGuid;            // GUID
            result.UpdEmployeeCode = rateSearchResultWork.UpdEmployeeCode;          // 更新従業員コード
            result.UpdAssemblyId1 = rateSearchResultWork.UpdAssemblyId1;            // 更新アセンブリID1
            result.UpdAssemblyId2 = rateSearchResultWork.UpdAssemblyId2;            // 更新アセンブリID2
            result.LogicalDeleteCode = rateSearchResultWork.LogicalDeleteCode;      // 論理削除区分
            result.SectionCode = rateSearchResultWork.SectionCode;                  // 拠点コード
            result.UnitRateSetDivCd = rateSearchResultWork.UnitRateSetDivCd;        // 単価掛率設定区分
            result.UnitPriceKind = rateSearchResultWork.UnitPriceKind;              // 単価種類
            result.RateSettingDivide = rateSearchResultWork.RateSettingDivide;      // 掛率設定区分
            result.RateMngGoodsCd = rateSearchResultWork.RateMngGoodsCd;            // 掛率設定区分（商品）
            result.RateMngGoodsNm = rateSearchResultWork.RateMngGoodsNm;            // 掛率設定名称（商品）
            result.RateMngCustCd = rateSearchResultWork.RateMngCustCd;              // 掛率設定区分（得意先）
            result.RateMngCustNm = rateSearchResultWork.RateMngCustNm;              // 掛率設定名称（得意先）
            result.GoodsMakerCd = rateSearchResultWork.GoodsMakerCd;                // 商品メーカーコード
            result.GoodsNo = rateSearchResultWork.GoodsNo;                          // 商品番号
            result.GoodsRateRank = rateSearchResultWork.GoodsRateRank.Trim();              // 商品掛率ランク
            result.GoodsRateGrpCode = rateSearchResultWork.GoodsRateGrpCode;        // 商品掛率グループコード
            result.BLGroupCode = rateSearchResultWork.BLGroupCode;                  // BLグループコード
            result.BLGoodsCode = rateSearchResultWork.BLGoodsCode;                  // BL商品コード
            result.CustomerCode = rateSearchResultWork.CustomerCode;                // 得意先コード
            result.CustRateGrpCode = rateSearchResultWork.CustRateGrpCode;          // 得意先掛率グループコード
            result.SupplierCd = rateSearchResultWork.SupplierCd;                    // 仕入先コード
            result.LotCount = rateSearchResultWork.LotCount;                        // ロット数
            result.PriceFl = rateSearchResultWork.PriceFl;                          // 価格（浮動）
            result.RateVal = rateSearchResultWork.RateVal;                          // 掛率
            result.UpRate = rateSearchResultWork.UpRate;                            // UP率
            result.GrsProfitSecureRate = rateSearchResultWork.GrsProfitSecureRate;  // 粗利確保率
            result.UnPrcFracProcUnit = rateSearchResultWork.UnPrcFracProcUnit;      // 単価端数処理単位
            result.UnPrcFracProcDiv = rateSearchResultWork.UnPrcFracProcDiv;        // 単価端数処理区分
            // BLグループコードマスタ
            result.BGBLGroupCode = rateSearchResultWork.BGBLGroupCode;              // グループコード
            result.BGBLGroupKanaName = rateSearchResultWork.BGBLGroupKanaName;      // グループコードドカナ名称
            // 優良設定マスタ、商品管理情報マスタより取得
            result.PrmGoodsMGroup = rateSearchResultWork.PrmGoodsMGroup;            // 商品中分類コード
            result.PrmTbsPartsCode = rateSearchResultWork.PrmTbsPartsCode;          // BLコード
            result.BLGoodsHalfName = rateSearchResultWork.BLGoodsHalfName;          // BL商品コード名称（半角）
            result.PrmPartsMakerCd = rateSearchResultWork.PrmPartsMakerCd;          // 部品メーカーコード
            result.EnFlag = rateSearchResultWork.EnFlag;                      // メーカー名称
            result.GoodsSupplierCd = rateSearchResultWork.GoodsSupplierCd;          // 仕入先コード

            return result;
        }

        /// <summary>
        /// クラスメンバーコピー処理（掛率設定クラス⇒掛率設定ワーククラス）
        /// </summary>
        /// <param name="rate">掛率設定クラス</param>
        /// <returns>Rate2Work</returns>
        /// <remarks>
        /// <br>Note       : 掛率設定クラスから掛率設定ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
        /// </remarks>
        private Rate2Work CopyToRateWorkFromRate(Rate rate)
        {
            Rate2Work rateWork = new Rate2Work();

            rateWork.CreateDateTime = rate.CreateDateTime;              // 作成日時
            rateWork.UpdateDateTime = rate.UpdateDateTime;              // 更新日時
            rateWork.EnterpriseCode = rate.EnterpriseCode;              // 企業コード
            rateWork.FileHeaderGuid = rate.FileHeaderGuid;              // GUID
            rateWork.UpdEmployeeCode = rate.UpdEmployeeCode;            // 更新従業員コード
            rateWork.UpdAssemblyId1 = rate.UpdAssemblyId1;              // 更新アセンブリID1
            rateWork.UpdAssemblyId2 = rate.UpdAssemblyId2;              // 更新アセンブリID2
            rateWork.LogicalDeleteCode = rate.LogicalDeleteCode;        // 論理削除区分
            rateWork.SectionCode = rate.SectionCode;                    // 拠点コード
            rateWork.UnitRateSetDivCd = rate.UnitRateSetDivCd;          // 単価掛率設定区分
            rateWork.UnitPriceKind = rate.UnitPriceKind;                // 単価種類
            rateWork.RateSettingDivide = rate.RateSettingDivide;        // 掛率設定区分
            rateWork.RateMngGoodsCd = rate.RateMngGoodsCd;              // 掛率設定区分（商品）
            rateWork.RateMngGoodsNm = rate.RateMngGoodsNm;              // 掛率設定名称（商品）
            rateWork.RateMngCustCd = rate.RateMngCustCd;                // 掛率設定区分（得意先）
            rateWork.RateMngCustNm = rate.RateMngCustNm;                // 掛率設定名称（得意先）
            rateWork.GoodsMakerCd = rate.GoodsMakerCd;                  // 商品メーカーコード
            rateWork.GoodsNo = rate.GoodsNo;                            // 商品番号
            rateWork.GoodsRateRank = rate.GoodsRateRank;                // 商品掛率ランク
            rateWork.BLGoodsCode = rate.BLGoodsCode;                    // BL商品コード
            rateWork.CustomerCode = rate.CustomerCode;                  // 得意先コード
            rateWork.CustRateGrpCode = rate.CustRateGrpCode;            // 得意先掛率グループコード
            rateWork.SupplierCd = rate.SupplierCd;                      // 仕入先コード
            rateWork.LotCount = rate.LotCount;                          // ロット数 
            rateWork.PriceFl = rate.PriceFl;                            // 価格
            rateWork.RateVal = rate.RateVal;                            // 掛率
            rateWork.UnPrcFracProcUnit = rate.UnPrcFracProcUnit;        // 単価端数処理単位
            rateWork.UnPrcFracProcDiv = rate.UnPrcFracProcDiv;          // 単価端数処理区分
            rateWork.GoodsRateGrpCode = rate.GoodsRateGrpCode;          // 商品掛率グループコード
            rateWork.BLGroupCode = rate.BLGroupCode;                    // BLグループコード
            rateWork.UpRate = rate.UpRate;                              // UP率
            rateWork.GrsProfitSecureRate = rate.GrsProfitSecureRate;    // 粗利確保率

            return rateWork;
        }

        /// <summary>
        /// ｢ALL｣や｢0000｣のデータフィルタ
        /// </summary>
        /// <param name="rateSearchResultList">検索リスト</param>
        /// <param name="rateSearchParam">検索条件</param>
        /// <param name="filterList">結果リスト</param>
        /// <remarks>
        /// <br>Note        : ｢ALL｣や｢0000｣のデータフィルタを行います。</br>
        /// <br>Programmer  : gezh</br>
        /// <br>Date        : 2013/03/21</br>
        /// </remarks>
        private void DataFilter(ArrayList retRateList, Rate2SearchParam rateSearchParam, ref ArrayList filterList)
        {
            if (rateSearchParam.CustomerSearchMode == 0 && rateSearchParam.CustRateGrpCode.Length == 1)
            {
                foreach (int key in rateSearchParam.CustRateGrpCode)
                {
                    // ｢ALL｣のみ場合
                    if (key == -1)
                    {
                        foreach (Rate2Work rate2Work in retRateList)
                        {
                            // ｢ALL｣のみの場合、掛率設定区分(得意先)は5：仕入先
                            if (rate2Work.RateMngCustCd == "5")
                            {
                                filterList.Add(rate2Work);
                            }
                        }
                    }
                    // ｢0000｣のみ場合
                    else if (key == 0)
                    {
                        foreach (Rate2Work rate2Work in retRateList)
                        {
                            // ｢0000｣のみの場合、売価データ掛率設定区分(得意先)は3：得意先掛率G+仕入先；原価データ掛率設定区分(得意先)は5：仕入先
                            if ((rate2Work.RateMngCustCd == "3" && rate2Work.UnitPriceKind == "1") || (rate2Work.RateMngCustCd == "5" && rate2Work.UnitPriceKind == "2"))
                            {
                                filterList.Add(rate2Work);
                            }
                        }
                    }
                    else
                    {
                        foreach (Rate2Work rate2Work in retRateList)
                        {
                            filterList.Add(rate2Work);
                        }
                    }
                }
            }
            else
            {
                if (rateSearchParam.CustomerSearchMode == 0)
                {
                    List<int> lst = new List<int>();
                    lst.AddRange(rateSearchParam.CustRateGrpCode);
                    // 得意先掛率グループ検索モードで、検索条件ALLが無い場合
                    if (!lst.Contains(-1) && lst.Contains(0))
                    {
                        foreach (Rate2Work rate2Work in retRateList)
                        {
                            // 原価データと得意先掛率G設定有り売価データを保留
                            if ((rate2Work.UnitPriceKind == "2") || (rate2Work.UnitPriceKind == "1" && rate2Work.RateMngCustCd != "5"))
                            {
                                filterList.Add(rate2Work);
                            }
                        }
                    }
                    // 得意先掛率グループ検索モードで、検索条件「0000」が無い場合
                    else if (lst.Contains(-1) && !lst.Contains(0))
                    {
                        foreach (Rate2Work rate2Work in retRateList)
                        {
                            // 原価データと得意先掛率G「0000」以外の売価データを保留
                            if ((rate2Work.UnitPriceKind == "2") || (rate2Work.UnitPriceKind == "1" && (rate2Work.RateMngCustCd != "3" || rate2Work.CustRateGrpCode != 0)))
                            {
                                filterList.Add(rate2Work);
                            }
                        }
                    }
                    // 得意先掛率グループ検索モードで、検索条件ALLと「0000」無い場合
                    else if (!lst.Contains(-1) && !lst.Contains(0))
                    {
                        foreach (Rate2Work rate2Work in retRateList)
                        {
                            // 原価データと得意先掛率G「0000」とALL以外の売価データを保留
                            if ((rate2Work.UnitPriceKind == "2") || (rate2Work.UnitPriceKind == "1" && rate2Work.CustRateGrpCode != 0))
                            {
                                filterList.Add(rate2Work);
                            }
                        }
                    }
                    else
                    {
                        foreach (Rate2Work rate2Work in retRateList)
                        {
                            filterList.Add(rate2Work);
                        }
                    }
                }
                else
                {
                    foreach (Rate2Work rate2Work in retRateList)
                    {
                        filterList.Add(rate2Work);
                    }
                }
            }
        }

        #region 純正データと掛率データ整合
        /// <summary>
        /// 純正データList設定
        /// </summary>
        /// <param name="pureDataSettingList">純正設定データList</param>
        /// <param name="rateSearchParam">画面の入力条件</param>
        private void PureDataSettingList(out List<Rate2SearchResult> pureDataSettingList, Rate2SearchParam rateSearchParam)
        {
            pureDataSettingList = new List<Rate2SearchResult>();
            object pureSettingPmWorkPbj;
            // 純正データDic
            Dictionary<int, PureSettingPmWork> pureSettingPmWorkDic = new Dictionary<int, PureSettingPmWork>();

            #region 純正情報検索
            // 純正検索
            PureSettingPmWork paraPureSettingPmWork = new PureSettingPmWork();

            // 検索条件設定：メーカー
            paraPureSettingPmWork.PartsMakerCode = rateSearchParam.GoodsMakerCd;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // 純正設定を検索する
            status = this._iPureSettingPmDB.Search(out pureSettingPmWorkPbj, paraPureSettingPmWork);
            #endregion


            // 純正情報検索成功の場合
            if (status == 0)
            {
                #region 純正情報設定
                ArrayList pureSettingPmWorkList = pureSettingPmWorkPbj as ArrayList;
                // 純正情報設定
                foreach (PureSettingPmWork pureSettingPmWork in pureSettingPmWorkList)
                {
                    // 検索条件商品掛率Gを入力入力した場合。
                    if (rateSearchParam.GoodsRateGrpCode != 0
                        && rateSearchParam.GoodsRateGrpCode != pureSettingPmWork.GoodsMGroup)
                    {
                        continue;
                    }

                    // 純正Dic作成
                    if(!pureSettingPmWorkDic.ContainsKey(pureSettingPmWork.BLGoodsCode))
                    {
                        pureSettingPmWorkDic.Add(pureSettingPmWork.BLGoodsCode, pureSettingPmWork);
                    }
                }
                #endregion 純正情報設定

                // 純正情報List設定
                Rate2SearchResult pureSearchResult;
                foreach (int blCode in pureSettingPmWorkDic.Keys)
                {
                　　// 商品掛率Gの場合
                    pureSearchResult = new Rate2SearchResult();
                    // BLCode
                    pureSearchResult.PrmTbsPartsCode = blCode;
                    // 商品掛率クループ
                    pureSearchResult.PrmGoodsMGroup= pureSettingPmWorkDic[blCode].GoodsMGroup;
                    // メーカー
                    pureSearchResult.PrmPartsMakerCd = pureSettingPmWorkDic[blCode].PartsMakerCode;
                    pureDataSettingList.Add(pureSearchResult);
                }
                //BLマスタから、BLCodeよって、ＢＬコード名とＢＬグループ取得する
                foreach(Rate2SearchResult tempSearchResult in pureDataSettingList)
                {
                    if (this.BLCodeDic.Count > 0)
                    {

                        if (this.BLCodeDic.ContainsKey(tempSearchResult.PrmTbsPartsCode))
                        {
                            tempSearchResult.BLGoodsHalfName = this.BLCodeDic[tempSearchResult.PrmTbsPartsCode].BLGoodsHalfName;//ＢＬコード名
                            tempSearchResult.BGBLGroupCode = this.BLCodeDic[tempSearchResult.PrmTbsPartsCode].BLGloupCode;// BLグループコード
                        }
                       
                    }
                }
            }
        }

        /// <summary>
        /// 純正設定データと商品管理情報の関連
        /// </summary>
        /// <param name="pureGoodsList">関連取得データ</param>
        /// <param name="pureSettingList">純正設定データ</param>
        /// <param name="goodsList">商品管理情報から取得商品データ</param>
        /// <param name="mode">0:純正 1:優良</param>
        /// <br>Note       : 純正設定データと商品管理情報の関連。</br>
        /// <br>Programmer : 董桂鈺</br>
        /// <br>Date       : 2013/03/02</br>
        private void MergePureAndGoods(out List<Rate2SearchResult> pureGoodsList,
                                       List<Rate2SearchResult> pureSettingList, 
                                       ArrayList goodsList,
                                       Rate2SearchParam rateSearchParam,
                                       int mode)
        {
            // 戻るしたリスト初期化処理
            pureGoodsList = new List<Rate2SearchResult>();
            // 層別データDic（key: BLCode; value: 層別リスト）
            Dictionary<string, ArrayList> partsLayerStPmWorkDic = new Dictionary<string, ArrayList>();

            #region 優先順のよって、検索取得商品管理情報を分離する
            //優先順：
            //　　　　①　メーカーコード　＋　中分類　+　ＢＬコード
            //　　　　②　メーカーコード　＋　中分類　
            //　　　　③　メーカーコード
            //商品管理情報用Dictionary定義
            Dictionary<string, ArrayList>[] goodsDics = new Dictionary<string, ArrayList>[3];
            for (int i = 0; i < goodsDics.Length; i++)
            {
                goodsDics[i] = new Dictionary<string, ArrayList>();
            }
            //List --> Dictionary 作成
            ArrayList tempGoodsList;
            foreach (Rate2SearchResultWork temp in goodsList)
            {
                tempGoodsList = new ArrayList();
                string k =temp.PrmPartsMakerCd.ToString() + "-" + temp.PrmGoodsMGroup.ToString() + "-" + temp.PrmTbsPartsCode.ToString();
                //メーカーコード　＋　中分類　+　ＢＬコード
                if (temp.PrmTbsPartsCode != 0)
                {
                    if (!goodsDics[0].ContainsKey(k))
                    {
                        tempGoodsList.Add(temp);
                        goodsDics[0].Add(k, tempGoodsList);
                    }
                    //別の拠点のデータを追加する
                    else
                    {
                        goodsDics[0][k].Add(temp);
                    }
                }
                //メーカーコード　＋　中分類　
                else if (temp.PrmGoodsMGroup != 0)
                {
                    if (!goodsDics[1].ContainsKey(k))
                    {
                        tempGoodsList.Add(temp);
                        goodsDics[1].Add(k, tempGoodsList);
                    }
                    //別の拠点のデータを追加する
                    else
                    {
                        goodsDics[1][k].Add(temp);
                    }
                }
                //メーカーコード
                else
                {
                    if (!goodsDics[2].ContainsKey(k))
                    {
                        tempGoodsList.Add(temp);
                        goodsDics[2].Add(k, tempGoodsList);
                    }
                    //別の拠点のデータを追加する
                    else
                    {
                        goodsDics[2][k].Add(temp);
                    }
                }
            }
            #endregion 優先順のよって、検索取得商品管理情報を分離する

            #region 純正Dictionaryを作成する
            //純正設定用Dictionary定義
            Dictionary<string, ArrayList>[] pureSettingDics = new Dictionary<string, ArrayList>[3];
            for (int i = 0; i < pureSettingDics.Length; i++)
            {
                pureSettingDics[i] = new Dictionary<string, ArrayList>();
            }
            //List --> Dictionary 作成
            ArrayList tempPureSettingList;
            foreach (Rate2SearchResult tempPureSetting in pureSettingList)
            {
                tempPureSettingList = new ArrayList();
                string k0 = tempPureSetting.PrmPartsMakerCd.ToString() + "-" + tempPureSetting.PrmGoodsMGroup.ToString() + "-" + tempPureSetting.PrmTbsPartsCode.ToString();
                string k1 = tempPureSetting.PrmPartsMakerCd.ToString() + "-" + tempPureSetting.PrmGoodsMGroup.ToString() + "-" + "0";
                string k2 = tempPureSetting.PrmPartsMakerCd.ToString() + "-" + "0-0";
                //関連条件：メーカーコード　＋　中分類　+　ＢＬコード
                if (!pureSettingDics[0].ContainsKey(k0))
                {
                    tempPureSettingList.Add(tempPureSetting);
                    pureSettingDics[0].Add(k0, tempPureSettingList);
                    tempPureSettingList = new ArrayList();
                }
                else
                {
                    pureSettingDics[0][k0].Add(tempPureSetting);
                }
                //関連条件：メーカーコード　＋　中分類
                if (!pureSettingDics[1].ContainsKey(k1))
                {
                    tempPureSettingList.Add(tempPureSetting);
                    pureSettingDics[1].Add(k1, tempPureSettingList);
                    tempPureSettingList = new ArrayList();
                }
                else
                {
                    pureSettingDics[1][k1].Add(tempPureSetting);
                }
                //関連条件：メーカーコード
                if (!pureSettingDics[2].ContainsKey(k2))
                {
                    tempPureSettingList.Add(tempPureSetting);
                    pureSettingDics[2].Add(k2, tempPureSettingList);
                    tempPureSettingList = new ArrayList();
                }
                else
                {
                    pureSettingDics[2][k2].Add(tempPureSetting);
                }
            }
            #endregion 純正Dictionaryを作成する

            #region 層別情報検索
            // 商品切替：層別の場合、層別情報を設定します。
            if (rateSearchParam.GoodsChangeMode == 1)
            {
                object partsLayerStPmWorkObj;
                int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                PartsLayerStPmWork partsLayerStPmWork = new PartsLayerStPmWork();
                // 画面の検索条件：メーカー
                partsLayerStPmWork.PartsMakerCode = rateSearchParam.GoodsMakerCd;

                // 層別情報を検索する
                status = this._iPartsLayerStPmDB.Search(out partsLayerStPmWorkObj, partsLayerStPmWork);

                // 層別検索成功の場合
                if (status == 0)
                {
                    // 層別情報リスト
                    ArrayList partsLayerStPmWorkList = partsLayerStPmWorkObj as ArrayList;

                    // 層別情報設定
                    ArrayList tempList;
                    foreach (PartsLayerStPmWork partsLayerStPmWorkPs in partsLayerStPmWorkList)
                    {
                        // 優良データの場合、メーカコード>=1000
                        if (mode == 1 && partsLayerStPmWorkPs.PartsMakerCode < 1000) 
                        {
                            continue;
                        }

                        // 画面検索条件の層別を入力した場合
                        if (rateSearchParam.GoodsRateRank.Trim() != ""
                            && rateSearchParam.GoodsRateRank.Trim() != partsLayerStPmWorkPs.PartsLayerCd.Trim())
                        {
                            continue;
                        }

                        // BLCode対応した層別リストを取得する
                        bool exit = partsLayerStPmWorkDic.TryGetValue(partsLayerStPmWorkPs.BLGoodsCode + "-" + partsLayerStPmWorkPs.PartsMakerCode, out tempList);
                        if (exit)
                        {
                            tempList.Add(partsLayerStPmWorkPs);
                        }
                        else
                        {
                            tempList = new ArrayList();
                            tempList.Add(partsLayerStPmWorkPs);
                            partsLayerStPmWorkDic.Add(partsLayerStPmWorkPs.BLGoodsCode + "-" + partsLayerStPmWorkPs.PartsMakerCode, tempList);
                        }
                    }
                }
            }
            #endregion 層別情報検索

            #region 純正データと商品管理情報関連
            Dictionary<string, Rate2SearchResult> tempDic = new Dictionary<string, Rate2SearchResult>();
            for (int i = 0; i < goodsDics.Length; i++)
            {
                foreach(string goodsKey in goodsDics[i].Keys)
                {
                    #region 拠点よって、商品管理情報分離する
                    ArrayList goodsBySectionList = goodsDics[i][goodsKey] as ArrayList;
                    Rate2SearchResultWork goodsSearchResultWork = new Rate2SearchResultWork();
                    if (goodsBySectionList.Count == 1)
                    {
                        goodsSearchResultWork = goodsBySectionList[0] as Rate2SearchResultWork;
                    }
                    else
                    {
                        foreach (Rate2SearchResultWork tempGoodsSearchResultWork in goodsBySectionList)
                        {
                            if (tempGoodsSearchResultWork.SectionCode.Trim() == rateSearchParam.SectionCode[0].Trim())
                            {
                                goodsSearchResultWork = tempGoodsSearchResultWork;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    #endregion 拠点よって、商品管理情報分離する

                    #region 純正データと商品管理情報関連
                    if (pureSettingDics[i].ContainsKey(goodsKey))
                    {
                        Rate2SearchResult tempSearchResult;
                        foreach (Rate2SearchResult pureSearchResult in pureSettingDics[i][goodsKey])
                        {
                            // 優良の場合
                            if (mode == 1)
                            {
                                if (!pureSearchResult.SectionCode.Trim().Equals("00")
                                    && pureSearchResult.SectionCode.Trim() != goodsSearchResultWork.SectionCode.Trim())
                                {
                                    break;
                                }
                            }

                            string tempKey = pureSearchResult.PrmPartsMakerCd.ToString() + "-" + pureSearchResult.PrmGoodsMGroup.ToString() + "-" + pureSearchResult.PrmTbsPartsCode.ToString();
                            tempSearchResult = new Rate2SearchResult();
                            //ＢＬコード
                            tempSearchResult.PrmTbsPartsCode = pureSearchResult.PrmTbsPartsCode;
                            //ＢＬコード名
                            tempSearchResult.BLGoodsHalfName = pureSearchResult.BLGoodsHalfName;
                            //メーカー
                            tempSearchResult.PrmPartsMakerCd = pureSearchResult.PrmPartsMakerCd;
                            //商品掛率グループ
                            tempSearchResult.PrmGoodsMGroup = pureSearchResult.PrmGoodsMGroup;
                            //仕入先
                            tempSearchResult.GoodsSupplierCd = goodsSearchResultWork.GoodsSupplierCd;
                            //ＢＬグループコード
                            tempSearchResult.BGBLGroupCode = pureSearchResult.BGBLGroupCode;
                            //拠点
                            tempSearchResult.SectionCode = goodsSearchResultWork.SectionCode;
                            //入力制御フラグ
                            tempSearchResult.EnFlag = "0";

                            if (!tempDic.ContainsKey(tempKey))
                            {
                                tempDic.Add(tempKey, tempSearchResult);
                            }
                        }
                    }
                   
                    #endregion 純正データと商品管理情報関連
                }
            }

            #endregion 純正データと商品管理情報関連

            #region 画面に入力条件と一致のデータ取得
            List<Rate2SearchResult> tempPureGoodsList = new List<Rate2SearchResult>();
            foreach (string tempGoodsKey in tempDic.Keys)
            {
                if (tempDic[tempGoodsKey].GoodsSupplierCd == rateSearchParam.SupplierCd
                    && ((rateSearchParam.GoodsMakerCd != 0    //画面にメーカーが入力した場合には、入力メーカーと一致の時、追加する
                    && tempDic[tempGoodsKey].PrmPartsMakerCd == rateSearchParam.GoodsMakerCd)
                    || rateSearchParam.GoodsMakerCd == 0)     //画面にメーカーが入力しない場合には、直接追加する
                    && ((rateSearchParam.GoodsRateGrpCode != 0　//画面に商掛Ｇが入力した場合には、入力商掛Ｇと一致の時、追加する
                    && tempDic[tempGoodsKey].PrmGoodsMGroup == rateSearchParam.GoodsRateGrpCode)
                    || rateSearchParam.GoodsRateGrpCode == 0))//画面に商掛Ｇが入力しない場合には、直接追加する
                {
                    tempPureGoodsList.Add(tempDic[tempGoodsKey]);
                }
                else
                {
                    continue;
                }
            }
            #endregion 画面に入力条件と一致のデータ取得

            if (rateSearchParam.GoodsChangeMode == 0)
            {
                pureGoodsList = tempPureGoodsList;
            }
            //層別の場合には層別情報を追加する
            else
            {
                #region 純正List設定（純正＋層別）
                Rate2SearchResult tempPureSearchResult;
                //層別の場合
                if (partsLayerStPmWorkDic.Count > 0)
                {
                    foreach (Rate2SearchResult pureSetting in tempPureGoodsList)
                    {
                        if (partsLayerStPmWorkDic.ContainsKey(pureSetting.PrmTbsPartsCode + "-" + pureSetting.PrmPartsMakerCd))
                        {
                            // 純正 left join 層別(純正:層別 = 1 : n)
                            foreach (PartsLayerStPmWork partsLayerStPmWork in partsLayerStPmWorkDic[pureSetting.PrmTbsPartsCode + "-" + pureSetting.PrmPartsMakerCd])
                            {
                                tempPureSearchResult = new Rate2SearchResult();
                                // BLCode
                                tempPureSearchResult.PrmTbsPartsCode = pureSetting.PrmTbsPartsCode;
                                //BLコード名
                                tempPureSearchResult.BLGoodsHalfName = pureSetting.BLGoodsHalfName;
                                // 層別
                                tempPureSearchResult.GoodsRateRank = partsLayerStPmWork.PartsLayerCd.Trim();
                                // メーカー
                                tempPureSearchResult.PrmPartsMakerCd = pureSetting.PrmPartsMakerCd;
                                //拠点
                                tempPureSearchResult.SectionCode = pureSetting.SectionCode;
                                //ＢＬグループコード
                                tempPureSearchResult.BGBLGroupCode = pureSetting.BGBLGroupCode;
                                //仕入先
                                tempPureSearchResult.GoodsSupplierCd = pureSetting.GoodsSupplierCd;
                                //入力制御フラグ
                                tempPureSearchResult.EnFlag = "0";

                                if ((rateSearchParam.GoodsRateRank.Trim() != ""
                                    && rateSearchParam.GoodsRateRank.Trim() == tempPureSearchResult.GoodsRateRank.Trim())
                                    || rateSearchParam.GoodsRateRank.Trim() == "")
                                {
                                    pureGoodsList.Add(tempPureSearchResult);
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                    }
                }
                else
                {
                    pureGoodsList = tempPureGoodsList;
                }
                #endregion 純正List設定（純正＋層別)
            }
            
        }

        /// <summary>
        /// 純正商品と掛率関連
        /// </summary>
        /// <param name="pureGoodsAndRateList">マージした純正商品と掛率のデータリスト</param>
        /// <param name="pureGoodsList">純正商品データリスト</param>
        /// <param name="rateList">掛率リスト</param>
        /// <param name="rateSearchParam">検索条件</param>
        /// <remarks>
        /// <br>Note       : 純正商品と掛率関連。</br>
        /// <br>Programmer : 董桂鈺</br>
        /// <br>Date       : 2013/03/02</br>
        /// </remarks>
        private void MergePureGoodsAndRate(out List<Rate2SearchResult> pureGoodsAndRateList, 
                                           List<Rate2SearchResult> pureGoodsList, 
                                           ArrayList rateList, 
                                           Rate2SearchParam rateSearchParam)
        {
            pureGoodsAndRateList = new List<Rate2SearchResult>();

            // 拠点違いデータを分離する
            Dictionary<string, ArrayList> rateDic;
            GetRateBySection(out rateDic, rateList);
            
            
            // 最小ロット数が含む主KeyListを取得する
            List<string> lotCountKeyList;
            GetRateByLotCount(out lotCountKeyList, rateList);
            
            #region 純正商品Listのデータと掛率マスタのデータ関連　関連の純正商品がない掛率データも戻るListに追加します
            foreach (string rateDickey in rateDic.Keys)
            {
                // 非最小ロット数のデータを取得しない
                if (!lotCountKeyList.Contains(rateDickey))
                {
                    continue;
                }
                Rate2SearchResult tempSearchResult = null;
                Rate2Work rateResultWork = new Rate2Work();

                #region 拠点のよって、商品管理情報分離する
                ArrayList rateBySectionList = rateDic[rateDickey] as ArrayList;
                // 拠点が一つある場合
                if (rateBySectionList.Count == 1)
                {
                    rateResultWork = rateBySectionList[0] as Rate2Work;
                }
                // 複数の拠点がある場合
                else
                {
                    foreach (Rate2Work tempRate2Work in rateBySectionList)
                    {
                        // 画面入力拠点と同じデータを選択する
                        if (tempRate2Work.SectionCode.Trim() == rateSearchParam.SectionCode[0].Trim())
                        {
                            rateResultWork = tempRate2Work;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                #endregion 拠点のよって、商品管理情報分離する
                #region 純正商品Listのデータと掛率マスタのデータ関連
                foreach (Rate2SearchResult pureGoodsSearchResult in pureGoodsList)
                {
                    // 子（子の場合には掛率マスタの商品掛率グループが「0」を設定する）
                    if (rateResultWork.BLGoodsCode != 0)
                    {
                        if ( (rateResultWork.GoodsMakerCd == pureGoodsSearchResult.PrmPartsMakerCd)
                            && (rateResultWork.BLGroupCode == 0)
                            && (rateResultWork.BLGoodsCode == pureGoodsSearchResult.PrmTbsPartsCode))
                        {
                            //商品掛率グループの場合
                            if (rateSearchParam.GoodsChangeMode == 0)
                            {
                                //商品掛率グループと層別の値がない
                                if ((rateResultWork.GoodsRateGrpCode == 0) && (string.IsNullOrEmpty(rateResultWork.GoodsRateRank.Trim())))
                                {
                                    #region Data Set   
                                    tempSearchResult = new Rate2SearchResult();
                                    //商品管理情報マスタにＢＬコード
                                    tempSearchResult.PrmTbsPartsCode = pureGoodsSearchResult.PrmTbsPartsCode;
                                    //商品管理情報マスタにＢＬコード名
                                    tempSearchResult.BLGoodsHalfName = pureGoodsSearchResult.BLGoodsHalfName;
                                    //商品管理情報マスタにメーカー
                                    tempSearchResult.PrmPartsMakerCd = pureGoodsSearchResult.PrmPartsMakerCd;
                                    //商品管理情報マスタに商品掛率グループ
                                    tempSearchResult.PrmGoodsMGroup = pureGoodsSearchResult.PrmGoodsMGroup;
                                    //商品管理情報マスタに仕入先
                                    tempSearchResult.GoodsSupplierCd = pureGoodsSearchResult.GoodsSupplierCd;
                                    //商品管理情報マスタにＢＬグループ
                                    tempSearchResult.BGBLGroupCode = pureGoodsSearchResult.BGBLGroupCode;
                                    //画面入力制御フラグ　0:入力可　1:入力不可
                                    tempSearchResult.EnFlag = "0";
                                    //掛率マスタから取得するデータをコピー
                                    CopyRateWorkToRate2SearchResult(ref tempSearchResult, rateResultWork);

                                    if ((rateSearchParam.GoodsRateGrpCode != 0 
                                        && tempSearchResult.PrmGoodsMGroup == rateSearchParam.GoodsRateGrpCode)
                                        ||(rateSearchParam.GoodsRateGrpCode == 0))
                                    {
                                            pureGoodsAndRateList.Add(tempSearchResult);
                                            break;
                                    }
                                    #endregion Data Set
                                }
                            }
                            //層別の場合
                            else 
                            {
                                if ((rateResultWork.GoodsRateRank.Trim() != ""
                                      && pureGoodsSearchResult.GoodsRateRank.Trim() == rateResultWork.GoodsRateRank.Trim())
                                      && (rateResultWork.GoodsRateGrpCode == 0))
                                {
                                    #region Data Set
                                    tempSearchResult = new Rate2SearchResult();
                                    //商品管理情報マスタにＢＬコード
                                    tempSearchResult.PrmTbsPartsCode = pureGoodsSearchResult.PrmTbsPartsCode;
                                    //商品管理情報マスタにＢＬコード名
                                    tempSearchResult.BLGoodsHalfName = pureGoodsSearchResult.BLGoodsHalfName;
                                    //商品管理情報マスタにメーカー
                                    tempSearchResult.PrmPartsMakerCd = pureGoodsSearchResult.PrmPartsMakerCd;
                                    //商品管理情報マスタに商品掛率グループ
                                    tempSearchResult.PrmGoodsMGroup = 0;
                                    //層別
                                    tempSearchResult.GoodsRateRank = pureGoodsSearchResult.GoodsRateRank.Trim();
                                    //商品管理情報マスタに仕入先
                                    tempSearchResult.GoodsSupplierCd = pureGoodsSearchResult.GoodsSupplierCd;
                                    //商品管理情報マスタにＢＬグループ
                                    tempSearchResult.BGBLGroupCode = pureGoodsSearchResult.BGBLGroupCode; ;
                                    //画面入力制御フラグ　0:入力可　1:入力不可
                                    tempSearchResult.EnFlag = "0";
                                    //掛率マスタから取得するデータをコピー
                                    CopyRateWorkToRate2SearchResult(ref tempSearchResult, rateResultWork);

                                    if ((rateSearchParam.GoodsRateRank.Trim() != ""
                                        && tempSearchResult.GoodsRateRank.Trim() == rateSearchParam.GoodsRateRank.Trim())
                                        || (string.IsNullOrEmpty(rateSearchParam.GoodsRateRank.Trim())))
                                    {
                                        pureGoodsAndRateList.Add(tempSearchResult);
                                        break;
                                    }
                                    #endregion Data Set
                                }
                                
                            }
                        }
                    }
                    // 子親（子親の場合にはＢＬコートが「０」を設定する）
                    else if (rateResultWork.BLGroupCode != 0)
                    {
                        if (((rateResultWork.GoodsMakerCd == pureGoodsSearchResult.PrmPartsMakerCd)
                            && (rateResultWork.BLGoodsCode == 0)
                            && (rateResultWork.BLGroupCode == pureGoodsSearchResult.BGBLGroupCode)))
                        {
                            if (rateSearchParam.GoodsChangeMode == 0)
                            {
                                if ((rateResultWork.GoodsRateGrpCode == 0) && (string.IsNullOrEmpty(rateResultWork.GoodsRateRank.Trim()))) //wujun todo
                                {
                                    #region Data Set
                                    tempSearchResult = new Rate2SearchResult();
                                    //商品管理情報マスタにＢＬコード
                                    tempSearchResult.PrmTbsPartsCode = 0;
                                    //商品管理情報マスタにＢＬコード名
                                    tempSearchResult.BLGoodsHalfName = "";
                                    //商品管理情報マスタにメーカー
                                    tempSearchResult.PrmPartsMakerCd = pureGoodsSearchResult.PrmPartsMakerCd;
                                    //商品管理情報マスタに商品掛率グループ
                                    tempSearchResult.PrmGoodsMGroup = pureGoodsSearchResult.PrmGoodsMGroup;
                                    //商品管理情報マスタに仕入先
                                    tempSearchResult.GoodsSupplierCd = pureGoodsSearchResult.GoodsSupplierCd;
                                    //商品管理情報マスタにＢＬグループ
                                    tempSearchResult.BGBLGroupCode = pureGoodsSearchResult.BGBLGroupCode;
                                    //画面入力制御フラグ　0:入力可　1:入力不可
                                    tempSearchResult.EnFlag = "0";
                                    //掛率マスタから取得するデータをコピー
                                    CopyRateWorkToRate2SearchResult(ref tempSearchResult, rateResultWork);

                                    if ((rateSearchParam.GoodsRateGrpCode != 0 
                                        && tempSearchResult.PrmGoodsMGroup == rateSearchParam.GoodsRateGrpCode)
                                        || (rateSearchParam.GoodsRateGrpCode == 0))
                                    {
                                        pureGoodsAndRateList.Add(tempSearchResult);
                                        break;
                                    }
                                    #endregion Data Set
                                }
                            }
                            else
                            {
                                if ((rateResultWork.GoodsRateRank.Trim() != ""
                                    && pureGoodsSearchResult.GoodsRateRank.Trim() == rateResultWork.GoodsRateRank.Trim()) 
                                    && (rateResultWork.GoodsRateGrpCode == 0)) 
                                {
                                    #region Data Set
                                    tempSearchResult = new Rate2SearchResult();
                                    //商品管理情報マスタにＢＬコード
                                    tempSearchResult.PrmTbsPartsCode = 0;
                                    //商品管理情報マスタにＢＬコード名
                                    tempSearchResult.BLGoodsHalfName = "";
                                    //商品管理情報マスタにメーカー
                                    tempSearchResult.PrmPartsMakerCd = pureGoodsSearchResult.PrmPartsMakerCd;
                                    //層別
                                    tempSearchResult.GoodsRateRank = pureGoodsSearchResult.GoodsRateRank.Trim();
                                    //商品管理情報マスタに仕入先
                                    tempSearchResult.GoodsSupplierCd = pureGoodsSearchResult.GoodsSupplierCd;
                                    //商品管理情報マスタにＢＬグループ
                                    tempSearchResult.BGBLGroupCode = pureGoodsSearchResult.BGBLGroupCode;
                                    //画面入力制御フラグ　0:入力可　1:入力不可
                                    tempSearchResult.EnFlag = "0";
                                    //掛率マスタから取得するデータをコピー
                                    CopyRateWorkToRate2SearchResult(ref tempSearchResult, rateResultWork);

                                    if ((rateSearchParam.GoodsRateRank.Trim() != "" 
                                        && tempSearchResult.GoodsRateRank.Trim() == rateSearchParam.GoodsRateRank.Trim())
                                        || (string.IsNullOrEmpty(rateSearchParam.GoodsRateRank.Trim())))
                                    {
                                        pureGoodsAndRateList.Add(tempSearchResult);
                                        break;
                                    }
                                    #endregion Data Set
                                }
                            }
                        }
                    }
                    // 親（親の場合にはＢＬコートとＢＬグループコードが「０」を設定する）
                    else
                    {
                        if (rateSearchParam.GoodsChangeMode == 0)
                        {
                            if ( (rateResultWork.GoodsMakerCd == pureGoodsSearchResult.PrmPartsMakerCd)
                            && (rateResultWork.GoodsRateGrpCode == pureGoodsSearchResult.PrmGoodsMGroup)
                            && rateResultWork.GoodsRateGrpCode != 0
                            && rateResultWork.GoodsRateRank.Trim() == ""
                            && (rateResultWork.BLGoodsCode == 0) 
                            && (rateResultWork.BLGroupCode == 0) )
                            {
                                #region Data Set
                                tempSearchResult = new Rate2SearchResult();
                                //商品管理情報マスタにＢＬコード
                                tempSearchResult.PrmTbsPartsCode = 0;
                                //商品管理情報マスタにＢＬコード名
                                tempSearchResult.BLGoodsHalfName = "";
                                //商品管理情報マスタにメーカー
                                tempSearchResult.PrmPartsMakerCd = pureGoodsSearchResult.PrmPartsMakerCd;
                                //商品管理情報マスタに商品掛率グループ
                                tempSearchResult.PrmGoodsMGroup = pureGoodsSearchResult.PrmGoodsMGroup;
                                //商品管理情報マスタに仕入先
                                tempSearchResult.GoodsSupplierCd = pureGoodsSearchResult.GoodsSupplierCd;
                                //商品管理情報マスタにＢＬグループ
                                tempSearchResult.BGBLGroupCode = 0;
                                //画面入力制御フラグ　0:入力可　1:入力不可
                                tempSearchResult.EnFlag = "0";
                                //掛率マスタから取得するデータをコピー
                                CopyRateWorkToRate2SearchResult(ref tempSearchResult, rateResultWork);

                                if ((rateSearchParam.GoodsRateGrpCode != 0 
                                    && tempSearchResult.PrmGoodsMGroup == rateSearchParam.GoodsRateGrpCode)
                                    || (rateSearchParam.GoodsRateGrpCode == 0))
                                {
                                    pureGoodsAndRateList.Add(tempSearchResult);
                                    break;
                                }
                                #endregion Data Set
                            }
                        }
                        else
                        {
                            if ((rateResultWork.GoodsMakerCd == pureGoodsSearchResult.PrmPartsMakerCd)
                            && (rateResultWork.GoodsRateRank.Trim() == pureGoodsSearchResult.GoodsRateRank.Trim())
                            && rateResultWork.BLGoodsCode == 0
                            && rateResultWork.BLGroupCode == 0
                            && rateResultWork.GoodsRateRank.Trim() != "")
                            {
                                #region Data Set
                                tempSearchResult = new Rate2SearchResult();
                                //商品管理情報マスタにＢＬコード
                                tempSearchResult.PrmTbsPartsCode = 0;
                                //商品管理情報マスタにＢＬコード名
                                tempSearchResult.BLGoodsHalfName = "";
                                //商品管理情報マスタにメーカー
                                tempSearchResult.PrmPartsMakerCd = pureGoodsSearchResult.PrmPartsMakerCd;
                                //層別
                                tempSearchResult.GoodsRateRank = pureGoodsSearchResult.GoodsRateRank.Trim();
                                //商品管理情報マスタに仕入先
                                tempSearchResult.GoodsSupplierCd = pureGoodsSearchResult.GoodsSupplierCd;
                                //商品管理情報マスタにＢＬグループ
                                tempSearchResult.BGBLGroupCode = 0;
                                //画面入力制御フラグ　0:入力可　1:入力不可
                                tempSearchResult.EnFlag = "0";
                                //掛率マスタから取得するデータをコピー
                                CopyRateWorkToRate2SearchResult(ref tempSearchResult, rateResultWork);

                                if ((rateSearchParam.GoodsRateRank.Trim() != "" 
                                     && tempSearchResult.GoodsRateRank.Trim() == rateSearchParam.GoodsRateRank.Trim())
                                     || (string.IsNullOrEmpty(rateSearchParam.GoodsRateRank.Trim())))
                                {
                                    pureGoodsAndRateList.Add(tempSearchResult);
                                    break;
                                }
                                #endregion Data Set
                            }
                        }
                    }
                }// end of foreach (Rate2SearchResult pureGoodsSearchResult in pureGoodsList)
                #endregion　純正商品Listのデータと掛率マスタのデータ関連　

                #region 純正商品Listにがない、掛率マスタにがあるデータの追加
                if (tempSearchResult == null)
                {
                    tempSearchResult = new Rate2SearchResult();
                    tempSearchResult.PrmTbsPartsCode = rateResultWork.BLGoodsCode;
                    //層別がなければ、このデータが追加しない
                    if (rateSearchParam.GoodsChangeMode == 1 &&　rateResultWork.GoodsRateRank.Trim() == "")
                    {
                        continue;
                    }
                    //子
                    if (rateResultWork.BLGoodsCode != 0)
                    {
                        if (this.BLCodeDic.ContainsKey(rateResultWork.BLGoodsCode))
                        {
                            tempSearchResult.BLGoodsHalfName = this.BLCodeDic[rateResultWork.BLGoodsCode].BLGoodsHalfName;
                            //掛率マスタに子データのＢＬグループがない場合、戻す表示用ＢＬグループコードがＢＬコードマスタに取得する
                            if (rateResultWork.BLGroupCode == 0)
                            {
                                tempSearchResult.BGBLGroupCode = this.BLCodeDic[rateResultWork.BLGoodsCode].BLGloupCode;
                            }
                            else
                            {
                                tempSearchResult.BGBLGroupCode = rateResultWork.BLGroupCode;
                            }
                            //商品掛率グループの場合
                            if (rateSearchParam.GoodsChangeMode == 0)
                            {
                                if (rateResultWork.GoodsRateGrpCode == 0 && rateResultWork.GoodsRateRank.Trim() == "")
                                {
                                    //ＢＬコードマスタから商品掛率グループを取得する
                                    tempSearchResult.PrmGoodsMGroup = this.BLCodeDic[rateResultWork.BLGoodsCode].GoodsRateGrpCode;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            //層別の場合
                            else
                            {
                                if (rateResultWork.GoodsRateRank.Trim() != "")
                                {
                                    tempSearchResult.GoodsRateRank = rateResultWork.GoodsRateRank.Trim();
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                    }
                    //子親
                    else if (rateResultWork.BLGroupCode != 0)
                    {
                        tempSearchResult.BGBLGroupCode = rateResultWork.BLGroupCode;
                        if (rateSearchParam.GoodsChangeMode == 0)
                        {
                            if (rateResultWork.GoodsRateGrpCode == 0 && rateResultWork.GoodsRateRank.Trim() == "")
                            {
                                if (this.BLGroupCodeDic.ContainsKey(rateResultWork.BLGroupCode))
                                {
                                    // ＢＬグループマスタから、商品掛率グループを取得する
                                    tempSearchResult.PrmGoodsMGroup = this.BLGroupCodeDic[rateResultWork.BLGroupCode].GoodsMGroup; 
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            if (rateResultWork.GoodsRateRank.Trim() != "")
                            {
                                tempSearchResult.GoodsRateRank = rateResultWork.GoodsRateRank.Trim(); 
                            }
                        }
                    }
                     //親（親のデータの商品掛率グループが「０」を設定できない）
                    else
                    {
                        tempSearchResult.BGBLGroupCode = 0;
                        if(rateSearchParam.GoodsChangeMode == 0)
                        {
                            if (rateResultWork.GoodsRateGrpCode != 0 && rateResultWork.GoodsRateRank.Trim() == "")
                            {
                                tempSearchResult.PrmGoodsMGroup = rateResultWork.GoodsRateGrpCode;
                            }
                            //商品掛率グループが「０」のデータが使用しない
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            if (rateResultWork.GoodsRateRank.Trim() != "")
                            {
                                tempSearchResult.GoodsRateRank = rateResultWork.GoodsRateRank.Trim();
                            }
                            else
                            {
                                continue;
                            }

                        }
                        
                    }
                    tempSearchResult.PrmPartsMakerCd = rateResultWork.GoodsMakerCd;
                    tempSearchResult.GoodsSupplierCd = rateResultWork.SupplierCd;
                    tempSearchResult.EnFlag = "0";
                    CopyRateWorkToRate2SearchResult(ref tempSearchResult, rateResultWork);
                    //商品掛率グループの場合
                    if (rateSearchParam.GoodsChangeMode == 0)
                    {
                        //画面の入力条件と一致のデータを使用します
                        if ((rateSearchParam.GoodsRateGrpCode != 0 
                              && tempSearchResult.PrmGoodsMGroup == rateSearchParam.GoodsRateGrpCode)
                              || (rateSearchParam.GoodsRateGrpCode == 0))
                        {
                            pureGoodsAndRateList.Add(tempSearchResult);
                        }
                    }
                    //層別の場合
                    else
                    {
                        //画面の入力条件と一致のデータを使用します
                        if ((rateSearchParam.GoodsRateRank.Trim() != "" 
                              && tempSearchResult.GoodsRateRank.Trim() == rateSearchParam.GoodsRateRank.Trim())
                           ||(string.IsNullOrEmpty(rateSearchParam.GoodsRateRank.Trim())))
                        {
                            pureGoodsAndRateList.Add(tempSearchResult);
                        }
                    }

                }
                #endregion 純正商品Listにがない、掛率マスタにがあるデータの追加

            }// end of foreach (Rate2Work rateResultWork in rateList)
            #endregion　純正商品Listのデータと掛率マスタのデータ関連　関連の純正商品がない掛率データも戻るListに追加します

            #region 純正商品Listにがあって、掛率マスタにがないデータの追加
            foreach (Rate2SearchResult pureGoodsSearchResult in pureGoodsList)
            {
                if (pureGoodsAndRateList.Contains(pureGoodsSearchResult))
                {
                    continue;
                }
                else
                {
                    //層別がなければ、このデータが追加しない
                    if (rateSearchParam.GoodsChangeMode == 1 && pureGoodsSearchResult.GoodsRateRank.Trim() == "")
                    {
                        continue;
                    }
                    else
                    {
                        if (!pureGoodsAndRateList.Exists(delegate(Rate2SearchResult target)
                        {
                            return target.PrmGoodsMGroup == pureGoodsSearchResult.PrmGoodsMGroup
                                   && target.PrmPartsMakerCd == pureGoodsSearchResult.PrmPartsMakerCd
                                   && target.BGBLGroupCode == pureGoodsSearchResult.BGBLGroupCode
                                   && target.PrmTbsPartsCode == pureGoodsSearchResult.PrmTbsPartsCode
                                   && target.GoodsRateRank == pureGoodsSearchResult.GoodsRateRank
                                   && (target.RateVal != 0 || target.UpRate != 0 || target.GrsProfitSecureRate != 0);
                        }))
                        {
                            pureGoodsAndRateList.Add(pureGoodsSearchResult);
                        }
                    }
                }
            }
            #endregion　純正商品Listにがあって、掛率マスタにがないデータの追加
        }

        #region 掛率マスタ取得データが掛率マスタテブールの主Keyのよって、Dictionaryを作成する
        /// <summary>
        /// 拠点違いデータを分離する
        /// </summary>
        /// <param name="rateDic"></param>
        /// <param name="rateList">掛率リスト</param>
        /// <remarks>
        /// <br>Note       : 拠点違いデータを分離する。</br>
        /// <br>Programmer : 董桂鈺</br>
        /// <br>Date       : 2013/03/02</br>
        /// </remarks>
        private void GetRateBySection(out Dictionary<string, ArrayList> rateDic, ArrayList rateList)
        {
            rateDic = new Dictionary<string, ArrayList>();
            string key = string.Empty;
            ArrayList tempRateList = new ArrayList();
            foreach (Rate2Work rate2Work in rateList)
            {
                // Ｒクラス使用以外の主Key：単価設定区分、層別、商品掛率グループ、ＢＬグループコード、ＢＬコード、
                // 得意先コード、得意先掛率グループコードとロット数（拠点が含まない）
                key = rate2Work.GoodsMakerCd.ToString() + "-" + rate2Work.UnitRateSetDivCd.Trim()
                      + "-"+ rate2Work.GoodsRateRank.Trim() + "-" + rate2Work.GoodsRateGrpCode.ToString()
                      + "-" + rate2Work.BLGroupCode.ToString() + "-" + rate2Work.BLGoodsCode.ToString() 
                      + rate2Work.CustomerCode.ToString() + "-" + rate2Work.CustRateGrpCode.ToString() 
                      + "-" + rate2Work.LotCount.ToString();
                if (!rateDic.ContainsKey(key))
                {
                    tempRateList.Add(rate2Work);
                    rateDic.Add(key, tempRateList);
                }
                //別の拠点のデータを追加する
                else
                {
                    rateDic[key].Add(rate2Work);
                }
                tempRateList = new ArrayList();
            }
        }
        #endregion 掛率マスタ取得データが掛率マスタテブールの主Keyのよって、Dictionaryを作成する

        #region  掛率マスタ取得データの中に、最小のロット数データが取得
        /// <summary>
        /// 掛率マスタ取得データの中に、最小のロット数データの取得
        /// </summary>
        /// <param name="lotCountKeyList"></param>
        /// <param name="rateList">掛率リスト</param>
        /// <remarks>
        /// <br>Note       : 掛率マスタ取得データの中に、最小のロット数データの取得</br>
        /// <br>Programmer : 董桂鈺</br>
        /// <br>Date       : 2013/03/02</br>
        /// </remarks>
        private void GetRateByLotCount(out List<string> lotCountKeyList, ArrayList rateList)
        {
            lotCountKeyList = new List<string>();
            // 総計ロット数用Dictionary
            Dictionary<string, ArrayList> rateLotCountDic = new Dictionary<string, ArrayList>();

            foreach (Rate2Work rate2Work in rateList)
            {
                // ロット数が含まないkeyを作成する
                string lotCountKey = rate2Work.GoodsMakerCd.ToString() + "-" + rate2Work.UnitRateSetDivCd.Trim() 
                                     + "-" + rate2Work.GoodsRateRank.Trim() + "-" + rate2Work.GoodsRateGrpCode.ToString()
                                     + "-" + rate2Work.BLGroupCode.ToString() + "-" + rate2Work.BLGoodsCode.ToString() 
                                     + rate2Work.CustomerCode.ToString()
                                     + "-" + rate2Work.CustRateGrpCode.ToString();
                ArrayList tempLotCountList = new ArrayList();
                // 総計ロット数用Dictionaryを作成する
                if (!rateLotCountDic.ContainsKey(lotCountKey))
                {
                    tempLotCountList.Add(rate2Work.LotCount);
                    rateLotCountDic.Add(lotCountKey, tempLotCountList);
                }
                else
                {
                    rateLotCountDic[lotCountKey].Add(rate2Work.LotCount);
                }
            }
            // 最小ロット数が含む主KeyListを作成する
            foreach (string rateLotCountDickey in rateLotCountDic.Keys)
            {
                rateLotCountDic[rateLotCountDickey].Sort();
                lotCountKeyList.Add(rateLotCountDickey + "-" + rateLotCountDic[rateLotCountDickey][0].ToString());
            }
        }
        #endregion　掛率マスタ取得データの中に、最小のロット数データが取得

        /// <summary>
        /// 親データがない場合に親データの追加処理
        /// </summary>
        /// <param name="retWorkList">検索したリスト</param>
        /// <param name="rateSearchParam">検索条件</param>
        /// <returns></returns>
        /// <br>Note       : 親データがない場合に親データの追加処理。</br>
        /// <br>Programmer : 董桂鈺</br>
        /// <br>Date       : 2013/02/26</br>
        private void SetParentData(ref List<Rate2SearchResult> retWorkList, Rate2SearchParam rateSearchParam)
        {
            List<Rate2SearchResult> parentList = new List<Rate2SearchResult>();
            Dictionary<string, Rate2SearchResult> pareDic = new Dictionary<string, Rate2SearchResult>();
            Rate2SearchResult tempParentWork = null;
            foreach (Rate2SearchResult tempWork in retWorkList)
            {
                string key = string.Empty;
                //string parentKey = string.Empty;
                string key1 = string.Empty;

                tempParentWork = new Rate2SearchResult();
                //検索取得の親データ
                if (tempWork.BGBLGroupCode == 0 && tempWork.PrmTbsPartsCode == 0)
                {
                    // 商品掛率Ｇ
                    if (rateSearchParam.GoodsChangeMode == 0)
                    {
                        key1 = tempWork.PrmGoodsMGroup.ToString();
                        tempParentWork.PrmGoodsMGroup = tempWork.PrmGoodsMGroup;
                    }
                    // 層別
                    else
                    {
                        key1 = tempWork.GoodsRateRank.Trim();
                        tempParentWork.GoodsRateRank = key1;
                    }
                    key =tempWork.PrmPartsMakerCd.ToString() + ":" + key1 + ":" + tempWork.BGBLGroupCode.ToString() + ":" + tempWork.PrmTbsPartsCode.ToString();
                    if (!pareDic.ContainsKey(key))
                    {
                        pareDic.Add(key, tempWork);
                    }
                }
                //毎データに親データの設定
                else
                {
                    // 商品掛率Ｇ
                    if (rateSearchParam.GoodsChangeMode == 0)
                    {
                        if (tempWork.PrmGoodsMGroup != 0)
                        {
                            tempParentWork.PrmGoodsMGroup = tempWork.PrmGoodsMGroup;
                        }
                        else if (tempWork.PrmTbsPartsCode != 0)
                        {
                            if (this.BLCodeDic.ContainsKey(tempWork.PrmTbsPartsCode))
                            {
                                tempParentWork.PrmGoodsMGroup = this.BLCodeDic[tempWork.PrmTbsPartsCode].GoodsRateGrpCode;
                            }
                        }
                        else if (tempWork.BGBLGroupCode != 0)
                        {
                            if (this.BLGroupCodeDic.ContainsKey(tempWork.BGBLGroupCode))
                            {
                                tempParentWork.PrmGoodsMGroup = this.BLGroupCodeDic[tempWork.BGBLGroupCode].GoodsMGroup;
                            }
                        }
                    }
                    // 層別
                    else
                    {
                        tempParentWork.GoodsRateRank = tempWork.GoodsRateRank.Trim();
                    }
                }
                tempParentWork.BGBLGroupCode = 0;
                tempParentWork.PrmTbsPartsCode = 0;
                tempParentWork.PrmPartsMakerCd = tempWork.PrmPartsMakerCd;
                tempParentWork.GoodsSupplierCd = tempWork.GoodsSupplierCd;
                tempParentWork.EnFlag = "0";
                parentList.Add(tempParentWork);
            }
            foreach (Rate2SearchResult tempWork in parentList)
            {
                string key = string.Empty;
                // 商品掛率Ｇ
                if (rateSearchParam.GoodsChangeMode == 0)
                {
                    key = tempWork.PrmPartsMakerCd.ToString() + ":" + tempWork.PrmGoodsMGroup.ToString();
                }
                // 層別
                else
                {
                    key = tempWork.PrmPartsMakerCd.ToString() + ":" + tempWork.GoodsRateRank.Trim();
                }
                if (!pareDic.ContainsKey(key + ":0:0"))
                {
                    pareDic.Add(key + ":0:0", tempWork);
                    retWorkList.Add(tempWork);
                }
            }
            // 層別検索の場合
            if (!string.IsNullOrEmpty(rateSearchParam.GoodsRateRank.Trim()))
            {
                List<Rate2SearchResult> retTempWorkList = new List<Rate2SearchResult>();
                foreach (Rate2SearchResult tempResultWork in retWorkList)
                {
                    if (!String.IsNullOrEmpty(tempResultWork.GoodsRateRank.Trim()))
                    {
                        retTempWorkList.Add(tempResultWork);
                    }
                }
                retWorkList = retTempWorkList;
            }
        }

        /// <summary>
        /// 子親データがない場合に親データの追加処理
        /// </summary>
        /// <param name="retWorkList">検索したリスト</param>
        /// <param name="rateSearchParam">検索条件</param>
        /// <br>Note       : 子親データがない場合に親データの追加処理。</br>
        /// <br>Programmer : songg</br>
        /// <br>Date       : 2013/03/04</br>
        private void SetGroupParaentDataByRank(ref List<Rate2SearchResult> retWorkList)
        {
            Dictionary<string, Rate2SearchResult> tempDic = new Dictionary<string, Rate2SearchResult>();
            foreach (Rate2SearchResult tempWork in retWorkList)
            {
                String key = tempWork.PrmPartsMakerCd.ToString() + ":" + tempWork.GoodsRateRank.Trim() + ":" + tempWork.BGBLGroupCode + ":" + tempWork.PrmTbsPartsCode;
                if (!tempDic.ContainsKey(key))
                {
                    tempDic.Add(key, tempWork);
                }
            }

            List<Rate2SearchResult> tempGroupParentList = new List<Rate2SearchResult>();
            foreach (string tempKey in tempDic.Keys)
            {
                Rate2SearchResult tempWork = tempDic[tempKey];

                Rate2SearchResult retWork = null;
                retWork = retWorkList.Find(
                        delegate(Rate2SearchResult work)
                        {
                            if ((work.GoodsRateRank.Trim() == tempWork.GoodsRateRank.Trim()) &&
                                (work.PrmTbsPartsCode == 0) &&
                                (work.BGBLGroupCode == tempWork.BGBLGroupCode)
                                && (work.PrmPartsMakerCd == tempWork.PrmPartsMakerCd))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    );

                if (retWork == null)
                {
                    bool hasInsertGroupParent = false;
                    for (int i = 0; i < tempGroupParentList.Count; i++)
                    {
                        if ((tempGroupParentList[i].GoodsRateRank.Trim() == tempWork.GoodsRateRank.Trim())
                            && (tempGroupParentList[i].BGBLGroupCode == tempWork.BGBLGroupCode)
                            && (tempGroupParentList[i].PrmPartsMakerCd == tempWork.PrmPartsMakerCd)
                            && (tempGroupParentList[i].GoodsSupplierCd == tempWork.GoodsSupplierCd))
                        {
                            hasInsertGroupParent = true;
                            break;
                        }
                    }

                    if (hasInsertGroupParent == false)
                    {
                        retWork = new Rate2SearchResult();

                        retWork.BGBLGroupCode = tempWork.BGBLGroupCode;

                        retWork.EnterpriseCode = tempWork.EnterpriseCode;
                        retWork.GoodsSupplierCd = tempWork.GoodsSupplierCd;
                        //retWork.PrmGoodsMGroup = tempWork.PrmGoodsMGroup;
                        retWork.PrmPartsMakerCd = tempWork.PrmPartsMakerCd;
                        retWork.PrmTbsPartsCode = 0;
                        retWork.SectionCode = tempWork.SectionCode;
                        retWork.GoodsRateRank = tempWork.GoodsRateRank.Trim();
                        retWork.EnFlag = "0";

                        tempGroupParentList.Add(retWork);
                    }
                }

            }

            if (null != tempGroupParentList && tempGroupParentList.Count > 0)
            {
                retWorkList.AddRange(tempGroupParentList.ToArray());
            }

        }

        /// <summary>
        /// 子親データがない場合に親データの追加処理
        /// </summary>
        /// <param name="retWorkList">検索したリスト</param>
        /// <param name="rateSearchParam">検索条件</param>
        /// <br>Note       : 子親データがない場合に親データの追加処理。</br>
        /// <br>Programmer : songg</br>
        /// <br>Date       : 2013/03/04</br>
        private void SetGroupParentData(ref List<Rate2SearchResult> retWorkList)
        {
            Dictionary<string, Rate2SearchResult> tempDic = new Dictionary<string, Rate2SearchResult>(); 
            foreach (Rate2SearchResult tempWork in retWorkList)
            {
                String key = tempWork.PrmPartsMakerCd.ToString() + ":" + tempWork.BGBLGroupCode + ":" + tempWork.PrmTbsPartsCode;
                if(!tempDic.ContainsKey(key))
                {
                    tempDic.Add(key, tempWork);
                }
            }

            List<Rate2SearchResult> tempGroupParentList = new List<Rate2SearchResult>();
            foreach (string tempKey in tempDic.Keys)
            {
                Rate2SearchResult tempWork = tempDic[tempKey];

                Rate2SearchResult retWork = null;
                retWork = retWorkList.Find(
                        delegate(Rate2SearchResult work)
                        {
                            if ((work.PrmTbsPartsCode == 0) &&
                                (work.BGBLGroupCode == tempWork.BGBLGroupCode)
                                && (work.PrmGoodsMGroup == tempWork.PrmGoodsMGroup)
                                && (work.PrmPartsMakerCd == tempWork.PrmPartsMakerCd))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    );

                if (retWork == null)
                {
                    bool hasInsertGroupParent = false;
                    for (int i = 0; i < tempGroupParentList.Count; i++)
                    {
                        if((tempGroupParentList[i].BGBLGroupCode == tempWork.BGBLGroupCode)
                            && (tempGroupParentList[i].PrmPartsMakerCd == tempWork.PrmPartsMakerCd)
                            && (tempGroupParentList[i].PrmGoodsMGroup == tempWork.PrmGoodsMGroup)
                            && (tempGroupParentList[i].GoodsSupplierCd == tempWork.GoodsSupplierCd))
                        {
                            hasInsertGroupParent = true;
                            break;
                        }
                    }

                    if(hasInsertGroupParent == false)
                    {
                        retWork = new Rate2SearchResult();

                        retWork.BGBLGroupCode = tempWork.BGBLGroupCode;

                        retWork.EnterpriseCode = tempWork.EnterpriseCode;
                        retWork.GoodsSupplierCd = tempWork.GoodsSupplierCd;
                        retWork.PrmGoodsMGroup = tempWork.PrmGoodsMGroup;
                        retWork.PrmPartsMakerCd = tempWork.PrmPartsMakerCd;
                        retWork.PrmTbsPartsCode = 0;
                        retWork.SectionCode = tempWork.SectionCode;
                        retWork.GoodsRateRank = tempWork.GoodsRateRank.Trim();
                        retWork.EnFlag = "0";
                        
                        tempGroupParentList.Add(retWork);
                    }
                }

            }

            if (null != tempGroupParentList && tempGroupParentList.Count > 0)
            {
                retWorkList.AddRange(tempGroupParentList.ToArray());
            }
        }
        #endregion

        /// <summary>
        /// Rate2Work --> Rate2SearchResult
        /// </summary>
        /// <param name="rate2SearchResult"></param>
        /// <param name="rateWork"></param>
        /// <br>Note       : Rate2Work --> Rate2SearchResult</br>
        /// <br>Programmer : 董桂鈺</br>
        /// <br>Date       : 2013/03/04</br>
        private void CopyRateWorkToRate2SearchResult(ref Rate2SearchResult rate2SearchResult, Rate2Work rateWork )
        {
            rate2SearchResult.BLGoodsCode = rateWork.BLGoodsCode;
            rate2SearchResult.BLGroupCode = rateWork.BLGroupCode;
            rate2SearchResult.CreateDateTime = rateWork.CreateDateTime;
            rate2SearchResult.CustomerCode = rateWork.CustomerCode;
            rate2SearchResult.CustRateGrpCode = rateWork.CustRateGrpCode;
            rate2SearchResult.EnterpriseCode = rateWork.EnterpriseCode;
            rate2SearchResult.FileHeaderGuid = rateWork.FileHeaderGuid;
            rate2SearchResult.GoodsNo = rateWork.GoodsNo;
            rate2SearchResult.GrsProfitSecureRate = rateWork.GrsProfitSecureRate;
            rate2SearchResult.LogicalDeleteCode = rateWork.LogicalDeleteCode;
            rate2SearchResult.LotCount = rateWork.LotCount;
            rate2SearchResult.PriceFl = rateWork.PriceFl;
            rate2SearchResult.GoodsRateGrpCode = rateWork.GoodsRateGrpCode;
            rate2SearchResult.GoodsMakerCd = rateWork.GoodsMakerCd;
            rate2SearchResult.RateMngCustCd = rateWork.RateMngCustCd;
            rate2SearchResult.RateMngCustNm = rateWork.RateMngCustNm;
            rate2SearchResult.RateMngGoodsCd = rateWork.RateMngGoodsCd;
            rate2SearchResult.RateMngGoodsNm = rateWork.RateMngGoodsNm;
            rate2SearchResult.RateSettingDivide = rateWork.RateSettingDivide;
            rate2SearchResult.RateVal = rateWork.RateVal;
            rate2SearchResult.SectionCode = rateWork.SectionCode;
            rate2SearchResult.SupplierCd = rateWork.SupplierCd;
            rate2SearchResult.UnitPriceKind = rateWork.UnitPriceKind;
            rate2SearchResult.UnitRateSetDivCd = rateWork.UnitRateSetDivCd;
            rate2SearchResult.UnPrcFracProcDiv = rateWork.UnPrcFracProcDiv;
            rate2SearchResult.UnPrcFracProcUnit = rateWork.UnPrcFracProcUnit;
            rate2SearchResult.UpdAssemblyId1 = rateWork.UpdAssemblyId1;
            rate2SearchResult.UpdAssemblyId2 = rateWork.UpdAssemblyId2;
            rate2SearchResult.UpdateDateTime = rateWork.UpdateDateTime;
            rate2SearchResult.UpdEmployeeCode = rateWork.UpdEmployeeCode;
            rate2SearchResult.UpRate = rateWork.UpRate;
        }
        #endregion ■ Private Methods

    }

    #region ■ Internal Class
    /// <summary>
    /// 掛率マスタ検索結果データソートクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 掛率マスタ検索結果データソートクラスです。</br>
    /// <br>Programmer : caohh</br>
    /// <br>Date       : 2013/02/19</br>
    /// </remarks>
    public class Rate2SchRstSort : IComparer<Rate2SearchResult>
    {
        // 商品切替モード
        private int _goodsChangeMode = 0;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="goodsChangeMode">商品切替モード</param>
        /// <remarks>
        /// <br>Note       : コンストラクタです。</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
        /// </remarks>
        public Rate2SchRstSort(int goodsChangeMode)
        {
            this._goodsChangeMode = goodsChangeMode;
        }

        /// <summary>
        /// 掛率マスタ検索結果データの比較処理
        /// </summary>
        /// <param name="x">掛率マスタ検索結果データ</param>
        /// <param name="y">掛率マスタ検索結果データ</param>
        /// <returns>比較結果</returns>
        /// <remarks>
        /// <br>Note       : 掛率マスタ検索結果データの比較処理を行う</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
        /// </remarks>
        public int Compare(Rate2SearchResult x, Rate2SearchResult y)
        {
            // 比較結果
            int compareRst = 0;

            // 商掛の場合
            if (this._goodsChangeMode == 0)
                // 商品中分類コードの比較
                compareRst = x.PrmGoodsMGroup.CompareTo(y.PrmGoodsMGroup);
            // 層別の場合
            else
            {
                // 商品掛率ランクの比較
                int index = 0;
                compareRst = this.CompareStr(x.GoodsRateRank.Trim(), y.GoodsRateRank.Trim(), ref index);
            }
            if (compareRst != 0) return compareRst;

            // メーカーの比較
            compareRst = x.PrmPartsMakerCd.CompareTo(y.PrmPartsMakerCd);
            if (compareRst != 0) return compareRst;

            // グループコードの比較
            compareRst = x.BGBLGroupCode.CompareTo(y.BGBLGroupCode);
            if (compareRst != 0) return compareRst;

            // BLコードの比較
            return x.PrmTbsPartsCode.CompareTo(y.PrmTbsPartsCode);
        }

        /// <summary>
        /// 文字列の比較(ソート順は数字→アルファベット小→大)
        /// </summary>
        /// <param name="strA">文字列A</param>
        /// <param name="strB">文字列B</param>
        /// <param name="index">インデックス</param>
        /// <returns>比較結果</returns>
        /// <remarks>
        /// <br>Note       : は数字→アルファベット小→大で文字列の比較処理を行う</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
        /// </remarks>
        private int CompareStr(string strA, string strB, ref int index)
        {
            if (index == strA.Length || index == strB.Length)
            {
                if (strA.Length > strB.Length)
                    return 1;
                else if (strA.Length == strB.Length)
                    return 0;
                else
                    return -1;
            }

            Int16 shortA = (Int16)strA.Substring(index, 1).ToCharArray()[0];
            Int16 shortB = (Int16)strB.Substring(index, 1).ToCharArray()[0];

            // 相等の場合、次の文字を比較する
            if (shortA == shortB)
            {
                index++;
                return CompareStr(strA, strB, ref index);
            }

            // 大文字の場合
            if (shortA >= 65 && shortA <= 90)
                shortA += (Int16)100;
            if (shortB >= 65 && shortB <= 90)
                shortB += (Int16)100;

            if (shortA > shortB)
                return 1;
            else
                return -1;
        }
    }
    #endregion ■ Internal Class
}

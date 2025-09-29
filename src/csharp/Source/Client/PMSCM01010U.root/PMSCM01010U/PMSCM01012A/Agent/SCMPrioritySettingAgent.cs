//****************************************************************************//
// システム         : 自働回答処理
// プログラム名称   : 自働回答処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/05/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              改修担当 : duzg
// 作 成 日  2011/07/14  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              改修担当 : duzg
// 作 成 日  2011/08/02  修正内容 : Redmine#23307の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : gaofeng
// 作 成 日  2011/09/19  修正内容 : Redmine#25216の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : liusy
// 作 成 日  2011/09/26  修正内容 : Redmine#25492の対応
//----------------------------------------------------------------------------//
// 管理番号  11070076-00 作成担当 : 30744 湯上 千加子
// 修 正 日  2014/05/08  修正内容 : PM-SCM速度改良 フェーズ２対応
//                                : 01.商品検索アクセスクラス補正処理プロパティ対応
//                                : 02.得意先掛率グループマスタ取得改良対応（回答判定時）
//                                : 03.変更前単価計算呼出回数改良対応
//                                : 04.キャンペーン売価設定マスタ取得改良対応
//                                : 05.得意先マスタ（伝票管理）取得改良対応
//                                : 06.得意先マスタ取得改良対応（金額計算クラス）
//                                : 07.得意先マスタ取得改良対応（金額計算クラス・キャンペーン対応）
//                                : 08.売上データ生成時のシステム日付取得対応
//                                : 09.得意先掛率グループマスタ取得改良対応（売上データ生成時）
//                                : 10.単価計算呼出回数改良
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Diagnostics;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.Controller.Agent
{
    using RealAccesserType  = SCMPriorStAcs;
    using RecordType        = SCMPriorSt;

    /// <summary>
    /// SCM優先設定アクセスの代理人クラス
    /// </summary>
    public class SCMPrioritySettingAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "SCM優先設定";
        private const string CLASS_NAME = "SCMPrioritySettingAgent";    // ログ用

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SCMPrioritySettingAgent() : base() { }

        #endregion // </Constructor>

        /// <summary>
        /// 検索します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param> 
        /// <param name="priorAppliDiv">優先適用区分</param>  
        /// <returns>該当するSCM相場価格設定 ※指定拠点で件数0の場合、全社設定で再検索します。</returns>
        public RecordType Find(
            string enterpriseCode,
            string sectionCode,
            int customerCode,
            int priorAppliDiv)
        {
            #region <Guard Phrase>

            if (string.IsNullOrEmpty(enterpriseCode.Trim()) || string.IsNullOrEmpty(sectionCode.Trim()))
            {
                return new RecordType();
            }

            #endregion // </Guard Phrase>

            const string ALL_SECTION_CODE = SecInfoSetAgent.ALL_SECTION_CODE;   // 全社設定

            string key = SCMEntityUtil.FormatEnterpriseCode(enterpriseCode) + SCMEntityUtil.FormatSectionCode(sectionCode);
            if (FoundRecordMap.ContainsKey(key))
            {
                return FoundRecordMap[key];
            }

            RecordType foundRecord = null;
            int status = RealAccesser.ReadPCCUOE(out foundRecord, enterpriseCode, sectionCode,customerCode,priorAppliDiv);
            /*if (!status.Equals((int)ResultUtil.ResultCode.Normal) && !status.Equals((int)ResultUtil.ResultCode.NotFound))
            {
                Debug.Assert(false, MY_NAME + "マスタの検索が失敗しました。");
                int sectionCodeNo = SCMEntityUtil.ConvertNumber(sectionCode.Trim());
                if (sectionCodeNo > 0)
                {
                    //modify by liusy 
                    return Find(enterpriseCode, ALL_SECTION_CODE,0,0);
                }
            }

            if (foundRecord != null && foundRecord.LogicalDeleteCode.Equals(0))
            {
                FoundRecordMap.Add(key, foundRecord);
            }
            else
            {
                int sectionCodeNo = SCMEntityUtil.ConvertNumber(sectionCode.Trim());
                if (sectionCodeNo > 0)
                {
                    // 全社設定で再検索
                    //modify by liusy 
                    return Find(enterpriseCode, ALL_SECTION_CODE,0,0);
                }
            }*/

            return foundRecord ?? new RecordType();
        }
        
        /* --- Del 2011/08/02 duzg for Redmine#23307 --->>>
        // --- Add 2011/07/14 duzg for 自動回答できる品目を委託在庫分以外も可能 --->>>
        /// <summary>SCM全体設定対象</summary>
        private static SCMTtlSt _scmTtlSt = null;

        /// <summary>SCM全体設定対象を取得または設定します。</summary>
        /// <remarks>SCM全体設定対象 </remarks>
        public static SCMTtlSt ScmTtlSt
        {
            get { return _scmTtlSt; }
            set { _scmTtlSt = value; }
        }
        // --- Add 2011/07/14 duzg for 自動回答できる品目を委託在庫分以外も可能 ---<<<
         --- Del 2011/08/02 duzg for Redmine#23307 ---<<< */

        //modify by liusy 
        /// <summary>
        /// 検索します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>該当するSCM相場価格設定 ※指定拠点で件数0の場合、全社設定で再検索します。</returns>
        public RecordType Find(
            string enterpriseCode,
            string sectionCode)
        {
            #region <Guard Phrase>

            if (string.IsNullOrEmpty(enterpriseCode.Trim()) || string.IsNullOrEmpty(sectionCode.Trim()))
            {
                return new RecordType();
            }

            #endregion // </Guard Phrase>

            const string ALL_SECTION_CODE = SecInfoSetAgent.ALL_SECTION_CODE;   // 全社設定

            string key = SCMEntityUtil.FormatEnterpriseCode(enterpriseCode) + SCMEntityUtil.FormatSectionCode(sectionCode);
            if (FoundRecordMap.ContainsKey(key))
            {
                return FoundRecordMap[key];
            }

            RecordType foundRecord = null;
            int status = RealAccesser.Read(out foundRecord, enterpriseCode, sectionCode, 0, -1);
            if (!status.Equals((int)ResultUtil.ResultCode.Normal) && !status.Equals((int)ResultUtil.ResultCode.NotFound))
            {
                Debug.Assert(false, MY_NAME + "マスタの検索が失敗しました。");
                int sectionCodeNo = SCMEntityUtil.ConvertNumber(sectionCode.Trim());
                if (sectionCodeNo > 0)
                {
                    return Find(enterpriseCode, ALL_SECTION_CODE);
                }
            }

            if (foundRecord != null && foundRecord.LogicalDeleteCode.Equals(0))
            {
                FoundRecordMap.Add(key, foundRecord);
            }
            else
            {
                int sectionCodeNo = SCMEntityUtil.ConvertNumber(sectionCode.Trim());
                if (sectionCodeNo > 0)
                {
                    // 全社設定で再検索
                    return Find(enterpriseCode, ALL_SECTION_CODE);
                }
            }

            return foundRecord ?? new RecordType();
        }
        //modify by liusy 
        #region <選択処理>

        /// <summary>
        /// 優先設定コード列挙型
        /// </summary>
        public enum PrioritySettingCd : int
        {
            /// <summary>なし</summary>
            None = 0,
            /// <summary>粗利率</summary>
            RoughRate = 1,
            /// <summary>単価(高)</summary>
            HighUnitPrice = 2,
            /// <summary>定価(高)</summary>
            HighListPrice = 3,
            /// <summary>定価(低)</summary>
            LowListPrice = 4,
            /// <summary>キャンペーン</summary>
            Campaign = 5,
            /// <summary>在庫</summary>
            Stock = 6
        }

        #region <優先設定コードで選択>
        /// <summary>
        /// PCCUOE優先設定で選択します。
        /// </summary>
        /// <param name="prioritySetteing">SCM優先設定</param>
        /// <param name="scmGoodsUnitDataList">SCM情報付商品連結データのリスト</param>
        /// <param name="mode">SCM情報付商品連結データのリスト</param>
        /// <returns>選択されたSCM情報付商品連結データのリスト</returns>
        public static IList<SCMGoodsUnitData> PCCUOESelectBySetting(
            RecordType prioritySetteing,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList,
            int mode
        )
        {
            IList<SCMGoodsUnitData> selectedList = new List<SCMGoodsUnitData>();
            //選択時
            if (mode == (int)SelectMode.On)
            {

                //純優区分
                selectedList = PCCUOESelectByPureDiv(prioritySetteing.SelTgtPureDiv, scmGoodsUnitDataList);
                if (selectedList.Count == 0 || selectedList.Count == 1)
                {
                    return selectedList;
                }

                //在庫区分
                selectedList = PCCUOESelectByStckDiv(prioritySetteing.SelTgtStckDiv, selectedList);
                if (selectedList.Count == 0 || selectedList.Count == 1)
                {
                    return selectedList;
                }

                //キャンペーン区分
                selectedList = PCCUOESelectByCampDiv(prioritySetteing.SelTgtCampDiv, selectedList);
                if (selectedList.Count == 0 || selectedList.Count == 1)
                {
                    return selectedList;
                }

                //価格区分１
                selectedList = PCCUOESelectByPricDiv(prioritySetteing.SelTgtPricDiv1, selectedList);
                if (selectedList.Count == 0 || selectedList.Count == 1)
                {
                    return selectedList;
                }

                //価格区分２
                selectedList = PCCUOESelectByPricDiv(prioritySetteing.SelTgtPricDiv2, selectedList);
                if (selectedList.Count == 0 || selectedList.Count == 1)
                {
                    return selectedList;
                }

                //価格区分３
                selectedList = PCCUOESelectByPricDiv(prioritySetteing.SelTgtPricDiv3, selectedList);
                if (selectedList.Count == 0 || selectedList.Count == 1)
                {
                    return selectedList;
                }

            }
            //非選択時
            else
            {
                //純優区分
                selectedList = PCCUOESelectByPureDiv(prioritySetteing.UnSelTgtPureDiv, scmGoodsUnitDataList);
                if (selectedList.Count == 0 || selectedList.Count == 1)
                {
                    return selectedList;
                }

                //在庫区分
                selectedList = PCCUOESelectByStckDiv(prioritySetteing.UnSelTgtStckDiv, selectedList);
                if (selectedList.Count == 0 || selectedList.Count == 1)
                {
                    return selectedList;
                }


                //キャンペーン区分
                selectedList = PCCUOESelectByCampDiv(prioritySetteing.UnSelTgtCampDiv, selectedList);
                if (selectedList.Count == 0 || selectedList.Count == 1)
                {
                    return selectedList;
                }

                //価格区分１
                selectedList = PCCUOESelectByPricDiv(prioritySetteing.UnSelTgtPricDiv1, selectedList);
                if (selectedList.Count == 0 || selectedList.Count == 1)
                {
                    return selectedList;
                }

                //価格区分２
                selectedList = PCCUOESelectByPricDiv(prioritySetteing.UnSelTgtPricDiv2, selectedList);
                if (selectedList.Count == 0 || selectedList.Count == 1)
                {
                    return selectedList;
                }

                //価格区分３
                selectedList = PCCUOESelectByPricDiv(prioritySetteing.UnSelTgtPricDiv3, selectedList);
                if (selectedList.Count == 0 || selectedList.Count == 1)
                {
                    return selectedList;
                }

            }
            return selectedList;
        }

        // ADD 2014/05/08 PM-SCM速度改良 フェーズ２№10.単価計算呼出回数改良 ---------------------------------->>>>>
        /// <summary>
        /// PCCUOE優先設定で選択します。（純優区分・在庫区分のみ）
        /// </summary>
        /// <param name="prioritySetteing">SCM優先設定</param>
        /// <param name="scmGoodsUnitDataList">SCM情報付商品連結データのリスト</param>
        /// <param name="mode">SCM情報付商品連結データのリスト</param>
        /// <returns>選択されたSCM情報付商品連結データのリスト</returns>
        public static IList<SCMGoodsUnitData> PCCUOESelectBySettingForStock(
            RecordType prioritySetteing,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList,
            int mode
        )
        {
            IList<SCMGoodsUnitData> selectedList = new List<SCMGoodsUnitData>();
            //選択時
            if (mode == (int)SelectMode.On)
            {

                //純優区分
                selectedList = PCCUOESelectByPureDiv(prioritySetteing.SelTgtPureDiv, scmGoodsUnitDataList);
                if (selectedList.Count == 0 || selectedList.Count == 1)
                {
                    return selectedList;
                }

                //在庫区分
                selectedList = PCCUOESelectByStckDiv(prioritySetteing.SelTgtStckDiv, selectedList);
                if (selectedList.Count == 0 || selectedList.Count == 1)
                {
                    return selectedList;
                }
            }
            //非選択時
            else
            {
                //純優区分
                selectedList = PCCUOESelectByPureDiv(prioritySetteing.UnSelTgtPureDiv, scmGoodsUnitDataList);
                if (selectedList.Count == 0 || selectedList.Count == 1)
                {
                    return selectedList;
                }

                //在庫区分
                selectedList = PCCUOESelectByStckDiv(prioritySetteing.UnSelTgtStckDiv, selectedList);
                if (selectedList.Count == 0 || selectedList.Count == 1)
                {
                    return selectedList;
                }
            }
            return selectedList;
        }
        // ADD 2014/05/08 PM-SCM速度改良 フェーズ２№10.単価計算呼出回数改良 ----------------------------------<<<<<

        /// <summary>
        /// PCCUOE在庫区分の優先判断
        /// </summary>
        /// <param name="StckDiv">優先設定マスタ在庫区分</param>
        /// <param name="scmGoodsUnitDataList">SCM情報付商品連結データのリスト</param>
        /// <returns>絞込されたSCM情報付商品連結データのリスト</returns>
        private static IList<SCMGoodsUnitData> PCCUOESelectByStckDiv(int StckDiv, IList<SCMGoodsUnitData> scmGoodsUnitDataList)
        {
            if (StckDiv == 0)
            {
                return scmGoodsUnitDataList;
            }
            IList<SCMGoodsUnitData> selectedList = new List<SCMGoodsUnitData>();

            foreach(SCMGoodsUnitData scmGoodsUnitData in scmGoodsUnitDataList)
            {

                if (StckDiv == 2)                     //2:委託・優先倉庫 // DEL 2011/09/19   //ADD 2011/09/26
                //if (StckDiv == 1)                     //1:委託・優先倉庫 // ADD 2011/09/19 //DEL 2011/09/26
                {
                    //委託倉庫或いは優先倉庫の場合、SCM情報付商品連結データのリストに格納されます
                    if (scmGoodsUnitData.GetStockDiv() == (int)StockDiv.PriorityWarehouse || scmGoodsUnitData.GetStockDiv() == (int)StockDiv.Trust)
                    {
                        selectedList.Add(scmGoodsUnitData);
                    }
                }
                // ----- ADD 2011/09/26 ----- >>>>>
                // ----- DEL 2011/09/19 ----- >>>>>
                else if (StckDiv == 1)                //1:在庫
                {
                    //非在庫の場合、SCM情報付商品連結データのリストに格納されます
                    if (scmGoodsUnitData.GetStockDiv() != (int)StockDiv.None)
                    {
                        selectedList.Add(scmGoodsUnitData);
                    }
                }
                // ----- DEL 2011/09/19 ----- <<<<<
                // ----- DEL 2011/09/26 ----- <<<<<
                else if (StckDiv == 3)                  //委託倉庫 // DEL 2011/09/19     //ADD 2011/09/26
                //else if (StckDiv == 2)                  //委託倉庫 // ADD 2011/09/19   //DEL 2011/09/26
                {
                    //委託倉庫の場合、SCM情報付商品連結データのリストに格納されます
                    if (scmGoodsUnitData.GetStockDiv() == (int)StockDiv.Trust)
                    {
                        selectedList.Add(scmGoodsUnitData);
                    }
                }
            }
            return selectedList;
 
        }
        /// <summary>
        /// PCCUOE価格区分の優先判断
        /// </summary>
        /// <param name="SelTgtPricDiv">優先設定マスタ価格区分</param>
        /// <param name="scmGoodsUnitDataList">SCM情報付商品連結データのリスト</param>
        /// <returns>絞込されたSCM情報付商品連結データのリスト</returns>
        private static IList<SCMGoodsUnitData> PCCUOESelectByPricDiv(int SelTgtPricDiv, IList<SCMGoodsUnitData> scmGoodsUnitDataList)
        {
            //価格区分未設定の場合
            if (SelTgtPricDiv == 0)
            {
                return scmGoodsUnitDataList;
            }
            IList<SCMGoodsUnitData> foundList = new List<SCMGoodsUnitData>();
            //1:粗利率(高)を優先
            if (SelTgtPricDiv == 1)
            {
                // 粗利率を優先
                foundList = SCMGoodsUnitData.FindHighestRoughRate(scmGoodsUnitDataList);
            }
            //2:単価(高)を優先
            else if (SelTgtPricDiv == 2)
            {
                // 単価(高)を優先
                foundList = SCMGoodsUnitData.FindHighestUnitPrice(scmGoodsUnitDataList);
            }
            //3:定価(高)を優先
            else if (SelTgtPricDiv == 3)
            {
                // 定価(高)を優先
                foundList = SCMGoodsUnitData.FindHighestListPrice(scmGoodsUnitDataList);
            }
            //4:定価(低)を優先
            else if (SelTgtPricDiv == 4)
            {
                // 定価(低)を優先
                foundList = SCMGoodsUnitData.FindLowestListPrice(scmGoodsUnitDataList);
            }
            return foundList;

        }
        /// <summary>
        /// PCCUOEキャンペーン区分の優先判断
        /// </summary>
        /// <param name="SelTgtCampDiv">優先設定マスタキャンペーン区分</param>
        /// <param name="scmGoodsUnitDataList">SCM情報付商品連結データのリスト</param>
        /// <returns>絞込されたSCM情報付商品連結データのリスト</returns>
        private static IList<SCMGoodsUnitData> PCCUOESelectByCampDiv(int SelTgtCampDiv, IList<SCMGoodsUnitData> scmGoodsUnitDataList)
        {
            //価格区分未設定の場合
            if (SelTgtCampDiv == 0)
            {
                return scmGoodsUnitDataList;
            }
            IList<SCMGoodsUnitData> selectedList = new List<SCMGoodsUnitData>();

            foreach (SCMGoodsUnitData scmGoodsUnitData in scmGoodsUnitDataList)
            {
                //1:キャンペーン有
                if (SelTgtCampDiv == 1)
                {
                    if (scmGoodsUnitData.CampaignInformation.Enabled)
                    {
                        selectedList.Add(scmGoodsUnitData);
                    }
                }

            }
            return selectedList;

        }
        /// <summary>
        /// PCCUOE純優優先判断
        /// </summary>
        /// <param name="SelTgtPureDiv">優先設定マスタ純優区分</param>
        /// <param name="scmGoodsUnitDataList">SCM情報付商品連結データのリスト</param>
        /// <returns>絞込されたSCM情報付商品連結データのリスト</returns>
        private static IList<SCMGoodsUnitData> PCCUOESelectByPureDiv(int SelTgtPureDiv, IList<SCMGoodsUnitData> scmGoodsUnitDataList)
        {

            if (SelTgtPureDiv == 0)
            {
                return scmGoodsUnitDataList;
            }
            IList<SCMGoodsUnitData> selectedList = new List<SCMGoodsUnitData>();

            foreach (SCMGoodsUnitData scmGoodsUnitData in scmGoodsUnitDataList)
            {
                //1:純正
                if (SelTgtPureDiv == 1)
                {
                    if (IsPureAtOfferKubun(scmGoodsUnitData.RealGoodsUnitData))
                    {
                        selectedList.Add(scmGoodsUnitData);
                    }
                }

            }
            return selectedList;

        }
        /// <summary>
        /// 純正であるか判断します。
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>
        /// <c>true</c> :純正です。<br/>
        /// <c>false</c>:純正ではありません。
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">提供区分の値が範囲外です。</exception>
        private static bool IsPureAtOfferKubun(GoodsUnitData goodsUnitData)
        {
            switch (goodsUnitData.OfferKubun)
            {
                // 2011/02/09 >>>
                //case 0: return false;   // 0:ユーザー登録
                case 0: return !string.IsNullOrEmpty(goodsUnitData.FreSrchPrtPropNo.Trim());   // 0:ユーザー登録
                // 2011/02/09 <<<
                case 1: return true;    // 1:提供純正編集
                case 2: return false;   // 2:提供優良編集
                case 3: return true;    // 3:提供純正
                case 4: return false;   // 4:提供優良
                case 5: return false;   // 5:TBO
                case 7: return false;   // 7:オリジナル部品
                default:
                    throw new ArgumentOutOfRangeException(
                        string.Format("提供区分の値が範囲外です。(={0})", goodsUnitData.OfferKubun)
                    );
            }
        }

        /// <summary>
        /// 優先設定1で選択します。
        /// </summary>
        /// <param name="prioritySetteing">SCM優先設定</param>
        /// <param name="scmGoodsUnitDataList">SCM情報付商品連結データのリスト</param>
        /// <returns>選択されたSCM情報付商品連結データのリスト</returns>
        public static IList<SCMGoodsUnitData> SelectBySetting1(
            RecordType prioritySetteing,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList
        )
        {
            return SelectBySetting(prioritySetteing.PrioritySettingCd1, scmGoodsUnitDataList, 1);
        }

        /// <summary>
        /// 優先設定2で選択します。
        /// </summary>
        /// <param name="prioritySetteing">SCM優先設定</param>
        /// <param name="scmGoodsUnitDataList">SCM情報付商品連結データのリスト</param>
        /// <returns>選択されたSCM情報付商品連結データのリスト</returns>
        public static IList<SCMGoodsUnitData> SelectBySetting2(
            RecordType prioritySetteing,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList
        )
        {
            return SelectBySetting(prioritySetteing.PrioritySettingCd2, scmGoodsUnitDataList, 2);
        }

        /// <summary>
        /// 優先設定3で選択します。
        /// </summary>
        /// <param name="prioritySetteing">SCM優先設定</param>
        /// <param name="scmGoodsUnitDataList">SCM情報付商品連結データのリスト</param>
        /// <returns>選択されたSCM情報付商品連結データのリスト</returns>
        public static IList<SCMGoodsUnitData> SelectBySetting3(
            RecordType prioritySetteing,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList
        )
        {
            return SelectBySetting(prioritySetteing.PrioritySettingCd3, scmGoodsUnitDataList, 3);
        }

        /// <summary>
        /// 優先設定4で選択します。
        /// </summary>
        /// <param name="prioritySetteing">SCM優先設定</param>
        /// <param name="scmGoodsUnitDataList">SCM情報付商品連結データのリスト</param>
        /// <returns>選択されたSCM情報付商品連結データのリスト</returns>
        public static IList<SCMGoodsUnitData> SelectBySetting4(
            RecordType prioritySetteing,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList
        )
        {
            return SelectBySetting(prioritySetteing.PrioritySettingCd4, scmGoodsUnitDataList, 4);
        }

        /// <summary>
        /// 優先設定5で選択します。
        /// </summary>
        /// <param name="prioritySetteing">SCM優先設定</param>
        /// <param name="scmGoodsUnitDataList">SCM情報付商品連結データのリスト</param>
        /// <returns>選択されたSCM情報付商品連結データのリスト</returns>
        public static IList<SCMGoodsUnitData> SelectBySetting5(
            RecordType prioritySetteing,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList
        )
        {
            return SelectBySetting(prioritySetteing.PrioritySettingCd5, scmGoodsUnitDataList, 5);
        }

        /// <summary>
        /// 優先設定コードで選択します。
        /// </summary>
        /// <param name="prioritySetteingCd">優先設定コード</param>
        /// <param name="scmGoodsUnitDataList">SCM情報付商品連結データのリスト</param>
        /// <param name="priorityNo"></param>
        /// <returns>選択されたSCM情報付商品連結データのリスト</returns>
        private static IList<SCMGoodsUnitData> SelectBySetting(
            int prioritySetteingCd,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList,
            int priorityNo
        )
        {
            const string METHOD_NAME = "SelectBySetting()"; // ログ用
            
            #region <Log>

            string msg = string.Format("優先設定{0}で選択中...", priorityNo);
            EasyLogger.WriteDebugLog(CLASS_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

            #endregion // </Log>

            IList<SCMGoodsUnitData> selectedList = new List<SCMGoodsUnitData>();
            {
                foreach (SCMGoodsUnitData scmGoodsUnitData in scmGoodsUnitDataList)
                {
                    #region Del For Redmine#23307
                    /* --- Del 2011/08/02 duzg for Redmine#23307 --->>>
                    // --- Add 2011/07/14 duzg for 自動回答できる品目を委託在庫分以外も可能 --->>>
                    bool NOPrcFlg = false;
                    if (scmGoodsUnitData.GetAcptAnOdrStatus() == (int)AcptAnOdrStatus.Estimate)
                    {
                        NOPrcFlg = true;
                    }
                    else
                    {
                        if (IsCampaignSetting(prioritySetteingCd))
                        {
                            // キャンペーンを優先
                            if (scmGoodsUnitData.CampaignInformation.Enabled)
                            {
                                #region <Log>

                                msg += Environment.NewLine + "キャンペーンを優先します。";
                                msg += Environment.NewLine + SCMDataHelper.GetProfile(scmGoodsUnitData);
                                EasyLogger.WriteDebugLog(CLASS_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                                #endregion // </Log>

                                selectedList.Add(scmGoodsUnitData);
                            }
                        }
                        else if (IsStockSetting(prioritySetteingCd))
                        {
                            // 在庫を優先
                            if (scmGoodsUnitData.ExistsStock)
                            {
                                if (ScmTtlSt != null && ScmTtlSt.AutoAnswerDiv == 1)
                                {
                                    if (scmGoodsUnitData.GetStockDiv() == (int)StockDiv.Trust && ScmTtlSt != null && ScmTtlSt.AutoAnswerDiv == 1)
                                    {
                                        #region <Log>

                                        msg += Environment.NewLine + "委託在庫のみを優先します。";
                                        msg += Environment.NewLine + SCMDataHelper.GetProfile(scmGoodsUnitData);
                                        EasyLogger.WriteDebugLog(CLASS_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                                        #endregion // </Log>

                                        selectedList.Add(scmGoodsUnitData);
                                    }
                                }
                                else if (ScmTtlSt != null && ScmTtlSt.AutoAnswerDiv == 2)
                                {
                                    if (scmGoodsUnitData.GetStockDiv() == (int)StockDiv.Trust
                                        || scmGoodsUnitData.GetStockDiv() == (int)StockDiv.Customer
                                        || scmGoodsUnitData.GetStockDiv() == (int)StockDiv.PriorityWarehouse)
                                    {
                                        #region <Log>

                                        msg += Environment.NewLine + "自社在庫のみを優先します。";
                                        msg += Environment.NewLine + SCMDataHelper.GetProfile(scmGoodsUnitData);
                                        EasyLogger.WriteDebugLog(CLASS_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                                        #endregion // </Log>

                                        selectedList.Add(scmGoodsUnitData);
                                    }
                                }
                                else
                                {
                                    #region <Log>

                                    msg += Environment.NewLine + "在庫を優先します。";
                                    msg += Environment.NewLine + SCMDataHelper.GetProfile(scmGoodsUnitData);
                                    EasyLogger.WriteDebugLog(CLASS_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                                    #endregion // </Log>

                                    selectedList.Add(scmGoodsUnitData);
                                }
                            }
                        }
                    }
                    if (NOPrcFlg)
                    {
                    // --- Add 2011/07/14 duzg for 自動回答できる品目を委託在庫分以外も可能 ---<<<
                    if (IsCampaignSetting(prioritySetteingCd))
                    {
                        // キャンペーンを優先
                        if (scmGoodsUnitData.CampaignInformation.Enabled)
                        {
                            #region <Log>

                            msg += Environment.NewLine + "キャンペーンを優先します。";
                            msg += Environment.NewLine + SCMDataHelper.GetProfile(scmGoodsUnitData);
                            EasyLogger.WriteDebugLog(CLASS_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                            #endregion // </Log>

                            selectedList.Add(scmGoodsUnitData);
                        }
                    }
                    else if (IsStockSetting(prioritySetteingCd))
                    {
                        // 在庫を優先
                        if (scmGoodsUnitData.ExistsStock)
                        {
                            #region <Log>

                            msg += Environment.NewLine + "在庫を優先します。";
                            msg += Environment.NewLine + SCMDataHelper.GetProfile(scmGoodsUnitData);
                            EasyLogger.WriteDebugLog(CLASS_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                            #endregion // </Log>

                            selectedList.Add(scmGoodsUnitData);
                        }
                    }
                    }// Add 2011/07/14 duzg for 自動回答できる品目を委託在庫分以外も可能
                     --- Del 2011/08/02 duzg for Redmine#23307 ---<<<*/
                    #endregion
                    // --- Add 2011/08/02 duzg for Redmine#23307 --->>>
                    if (IsCampaignSetting(prioritySetteingCd))
                    {
                        // キャンペーンを優先
                        if (scmGoodsUnitData.CampaignInformation.Enabled)
                        {
                            #region <Log>

                            msg += Environment.NewLine + "キャンペーンを優先します。";
                            msg += Environment.NewLine + SCMDataHelper.GetProfile(scmGoodsUnitData);
                            EasyLogger.WriteDebugLog(CLASS_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                            #endregion // </Log>

                            selectedList.Add(scmGoodsUnitData);
                        }
                    }
                    else if (IsStockSetting(prioritySetteingCd))
                    {
                        // 在庫を優先
                        if (scmGoodsUnitData.ExistsStock)
                        {
                            #region <Log>

                            msg += Environment.NewLine + "在庫を優先します。";
                            msg += Environment.NewLine + SCMDataHelper.GetProfile(scmGoodsUnitData);
                            EasyLogger.WriteDebugLog(CLASS_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                            #endregion // </Log>

                            selectedList.Add(scmGoodsUnitData);
                        }
                    }
                    // --- Add 2011/08/02 duzg for Redmine#23307 ---<<<
                }
            }
            return selectedList.Count.Equals(0) ? scmGoodsUnitDataList : selectedList;
        }

        /// <summary>
        /// 優先設定がキャンペーンであるか判断します。
        /// </summary>
        /// <param name="prioritySetteingCd">優先設定コード</param>
        /// <returns>
        /// <c>true</c> :キャンペーンです。<br/>
        /// <c>false</c>:キャンペーンではありません。
        /// </returns>
        private static bool IsCampaignSetting(int prioritySetteingCd)
        {
            return prioritySetteingCd.Equals((int)PrioritySettingCd.Campaign);
        }

        /// <summary>
        /// 優先設定が在庫であるか判断します。
        /// </summary>
        /// <param name="prioritySetteingCd">優先設定コード</param>
        /// <returns>
        /// <c>true</c> :在庫です。<br/>
        /// <c>false</c>:在庫ではありません。
        /// </returns>
        private static bool IsStockSetting(int prioritySetteingCd)
        {
            return prioritySetteingCd.Equals((int)PrioritySettingCd.Stock);
        }

        #endregion // </優先設定コードで選択>

        #region <優先価格設定コードで選択>

        /// <summary>
        /// 優先価格設定1で選択します。
        /// </summary>
        /// <param name="prioritySetteing">SCM優先設定</param>
        /// <param name="scmGoodsUnitDataList">SCM情報付商品連結データのリスト</param>
        /// <returns>選択されたSCM情報付商品連結データのリスト</returns>
        public static IList<SCMGoodsUnitData> SelectByPriceSetting1(
            RecordType prioritySetteing,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList
        )
        {
            return SelectByPriceSetting(prioritySetteing.PriorPriceSetCd1, scmGoodsUnitDataList, 1);
        }

        /// <summary>
        /// 優先価格設定2で選択します。
        /// </summary>
        /// <param name="prioritySetteing">SCM優先設定</param>
        /// <param name="scmGoodsUnitDataList">SCM情報付商品連結データのリスト</param>
        /// <returns>選択されたSCM情報付商品連結データのリスト</returns>
        public static IList<SCMGoodsUnitData> SelectByPriceSetting2(
            RecordType prioritySetteing,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList
        )
        {
            return SelectByPriceSetting(prioritySetteing.PriorPriceSetCd2, scmGoodsUnitDataList, 2);
        }

        /// <summary>
        /// 優先価格設定3で選択します。
        /// </summary>
        /// <param name="prioritySetteing">SCM優先設定</param>
        /// <param name="scmGoodsUnitDataList">SCM情報付商品連結データのリスト</param>
        /// <returns>選択されたSCM情報付商品連結データのリスト</returns>
        public static IList<SCMGoodsUnitData> SelectByPriceSetting3(
            RecordType prioritySetteing,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList
        )
        {
            return SelectByPriceSetting(prioritySetteing.PriorPriceSetCd3, scmGoodsUnitDataList, 3);
        }

        /// <summary>
        /// 優先価格設定4で選択します。
        /// </summary>
        /// <param name="prioritySetteing">SCM優先設定</param>
        /// <param name="scmGoodsUnitDataList">SCM情報付商品連結データのリスト</param>
        /// <returns>選択されたSCM情報付商品連結データのリスト</returns>
        public static IList<SCMGoodsUnitData> SelectByPriceSetting4(
            RecordType prioritySetteing,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList
        )
        {
            return SelectByPriceSetting(prioritySetteing.PriorPriceSetCd4, scmGoodsUnitDataList, 4);
        }

        /// <summary>
        /// 優先価格設定5で選択します。
        /// </summary>
        /// <param name="prioritySetteing">SCM優先設定</param>
        /// <param name="scmGoodsUnitDataList">SCM情報付商品連結データのリスト</param>
        /// <returns>選択されたSCM情報付商品連結データのリスト</returns>
        public static IList<SCMGoodsUnitData> SelectByPriceSetting5(
            RecordType prioritySetteing,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList
        )
        {
            return SelectByPriceSetting(prioritySetteing.PriorPriceSetCd5, scmGoodsUnitDataList, 5);
        }

        /// <summary>
        /// 優先価格設定コードで選択します。
        /// </summary>
        /// <param name="priorPriceSetCd">優先価格設定コード</param>
        /// <param name="scmGoodsUnitDataList">SCM情報付商品連結データのリスト</param>
        /// <param name="priorityNo"></param>
        /// <returns>選択されたSCM情報付商品連結データのリスト</returns>
        private static IList<SCMGoodsUnitData> SelectByPriceSetting(
            int priorPriceSetCd,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList,
            int priorityNo
        )
        {
            const string METHOD_NAME = "SelectByPriceSetting()";    // ログ用 

            #region <Log>

            string msg = string.Format("優先価格設定{0}で選択中...", priorityNo);
            EasyLogger.WriteDebugLog(CLASS_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

            #endregion // </Log>

            IList<SCMGoodsUnitData> selectedList = new List<SCMGoodsUnitData>();
            {
                if (IsRoughRateSetting(priorPriceSetCd))
                {
                    // 粗利率を優先
                    selectedList = SCMGoodsUnitData.FindHighestRoughRate(scmGoodsUnitDataList);

                    #region <Log>

                    msg += Environment.NewLine + "粗利率を優先します。";
                    msg += Environment.NewLine + SCMDataHelper.GetProfile(selectedList);
                    EasyLogger.WriteDebugLog(CLASS_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // </Log>
                }
                else if (IsHighUnitPriceSetting(priorPriceSetCd))
                {
                    // 単価(高)を優先
                    selectedList = SCMGoodsUnitData.FindHighestUnitPrice(scmGoodsUnitDataList);

                    #region <Log>

                    msg += Environment.NewLine + "単価(高)を優先します。";
                    msg += Environment.NewLine + SCMDataHelper.GetProfile(selectedList);
                    EasyLogger.WriteDebugLog(CLASS_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // </Log>
                }
                else if (IsHighListPriceSetting(priorPriceSetCd))
                {
                    // 定価(高)を優先
                    selectedList = SCMGoodsUnitData.FindHighestListPrice(scmGoodsUnitDataList);

                    #region <Log>

                    msg += Environment.NewLine + "定価(高)を優先します。";
                    msg += Environment.NewLine + SCMDataHelper.GetProfile(selectedList);
                    EasyLogger.WriteDebugLog(CLASS_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // </Log>
                }
                else if (IsLowListPriceSetting(priorPriceSetCd))
                {
                    // 定価(低)を優先
                    selectedList = SCMGoodsUnitData.FindLowestListPrice(scmGoodsUnitDataList);

                    #region <Log>

                    msg += Environment.NewLine + "定価(低)を優先します。";
                    msg += Environment.NewLine + SCMDataHelper.GetProfile(selectedList);
                    EasyLogger.WriteDebugLog(CLASS_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // </Log>
                }
                else
                {
                    // それ以外
                    return scmGoodsUnitDataList;
                }
            }
            return selectedList.Count.Equals(0) ? scmGoodsUnitDataList : selectedList;
        }

        /// <summary>
        /// 優先価格設定が粗利率であるか判断します。
        /// </summary>
        /// <param name="priorPriceSetCd">優先価格設定コード</param>
        /// <returns>
        /// <c>true</c> :粗利率です。<br/>
        /// <c>false</c>:粗利率ではありません。
        /// </returns>
        private static bool IsRoughRateSetting(int priorPriceSetCd)
        {
            return priorPriceSetCd.Equals((int)PrioritySettingCd.RoughRate);
        }

        /// <summary>
        /// 優先価格設定が単価(高)であるか判断します。
        /// </summary>
        /// <param name="priorPriceSetCd">優先価格設定コード</param>
        /// <returns>
        /// <c>true</c> :単価(高)です。<br/>
        /// <c>false</c>:単価(高)ではありません。
        /// </returns>
        private static bool IsHighUnitPriceSetting(int priorPriceSetCd)
        {
            return priorPriceSetCd.Equals((int)PrioritySettingCd.HighUnitPrice);
        }

        /// <summary>
        /// 優先価格設定が定価(高)であるか判断します。
        /// </summary>
        /// <param name="priorPriceSetCd">優先価格設定コード</param>
        /// <returns>
        /// <c>true</c> :定価(高)です。<br/>
        /// <c>false</c>:定価(高)ではありません。
        /// </returns>
        private static bool IsHighListPriceSetting(int priorPriceSetCd)
        {
            return priorPriceSetCd.Equals((int)PrioritySettingCd.HighListPrice);
        }

        /// <summary>
        /// 優先価格設定が定価(低)であるか判断します。
        /// </summary>
        /// <param name="priorPriceSetCd">優先価格設定コード</param>
        /// <returns>
        /// <c>true</c> :定価(低)です。<br/>
        /// <c>false</c>:定価(低)ではありません。
        /// </returns>
        private static bool IsLowListPriceSetting(int priorPriceSetCd)
        {
            return priorPriceSetCd.Equals((int)PrioritySettingCd.LowListPrice);
        }

        #endregion // </優先価格設定コードで選択>

        #endregion // </選択処理>
    }
}

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
// 作 成 日  2009/06/15  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/03/15  修正内容 : ①回答納期で、設定時間範囲外の場合は空白を返す
//                                 ②売上明細データの回答納期がセットされない不具合の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2011/08/10  修正内容 : PCCUOE自動回答対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2011/09/19  修正内容 : Redmine #25216
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : liusy
// 作 成 日  2011/09/26  修正内容 : Redmine#25492の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2011/10/08  修正内容 : Redmine#25764の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2011/10/11  修正内容 : Redmine#25760、Redmine#25765の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : liusy
// 作 成 日  2011/10/11  修正内容 : Redmine#25754、Redmine#25755の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : liusy
// 作 成 日  2011/11/21  修正内容 : Redmine#8019の対応
//----------------------------------------------------------------------------//
// 管理番号  10800003-00 作成担当 : 20056 對馬 大輔
// 作 成 日  2012/01/04  修正内容 : SCM改良対応
//                                  1)純正情報設定対応
//                                  2)表示順位設定対応
//----------------------------------------------------------------------------//
// 管理番号  10707327-00 作成担当 : 20056 對馬 大輔
// 作 成 日  2012/03/28  修正内容 : SCM改良対応
//                                  1)自動回答速度改善
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 湯上　千加子
// 作 成 日  2012/04/23  修正内容 : 障害№150 2012/02/23配信分、Redmine#28038の対応
//　　　　　　　　　　　　　　　　　SCM改良／修正漏れ対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 三戸　伸悟
// 作 成 日  2012/05/28  修正内容 : 障害№274 在庫確認でＰＣＣ品目設定が無くても自動回答する
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30747 三戸　伸悟
// 作 成 日  2012/06/18  修正内容 : 障害№10289 手動回答時、標準価格選択画面で選択した標準価格が有効にならない
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 20056 對馬 大輔
// 作 成 日  2012/06/26  修正内容 : 障害№274 削除(2012/06/28配信から除外)
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30744 湯上 千加子
// 作 成 日  2012/06/29  修正内容 : 障害№274 在庫確認でＰＣＣ品目設定が無くても自動回答する
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30744 湯上 千加子
// 作 成 日  2012/07/18  修正内容 : SCM障害№173 PCC優先設定で優先倉庫設定時の表示順条件を変更する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡 孝憲　30745
// 作 成 日  2012/08/30  修正内容 : 2012/10月配信予定SCM障害№10345対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/11/09  修正内容 : SCM改良№10337,10338,10341,10364,10431対応 PCCforNS、BLPの自動回答判定処理統合
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/11/27  修正内容 : 2012/12/12配信 システムテスト障害№86対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/12/12  修正内容 : SCM改良№10423対応 PCCforNS、BLPの委託在庫・参照在庫の判定処理統合
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/02/13  修正内容 : SCM障害追加②対応　2013/03/06配信
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡 孝憲
// 作 成 日  2013/02/28  修正内容 : 2013/03/06配信予定 リリース前検証サポ推管№92
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/03/07  修正内容 : SCM障害№10489対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/09/13  修正内容 : SCM仕掛一覧№10571対応　PCC自社設定マスタの参照倉庫を追加
//----------------------------------------------------------------------------//
// 管理番号  10900690-00 作成担当 : qijh
// 作 成 日  2013/02/27  修正内容 : 配信日なし分 Redmine#34752 「PMSCMのNo.10385」BLPの対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/10/17  修正内容 : 商品保証課Redmine#552対応 参照倉庫取得時USBオプションチェック対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/11/19  修正内容 : 201312xx配信予定ｼｽﾃﾑﾃｽﾄ障害№22対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2014/01/30  修正内容 : Redmine#41771 障害№13対応
//----------------------------------------------------------------------------//
// 管理番号  11070147-00 作成担当 : 鄧潘ハン
// 修 正 日  2014/07/23  修正内容 : SCM仕掛一覧№10659の3SCM受発注明細データに在庫状況区分のセットの対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 湯上 千加子
// 修 正 日  2014/09/19  修正内容 : SCM社内障害一覧№44対応
//----------------------------------------------------------------------------//
// 管理番号  11070221-00 作成担当 : 脇田 靖之
// 作 成 日  2014/11/05  修正内容 : SCM障害№10535対応
//                                : 2014/11/26配信システムテスト障害№6対応
//                                : PM-SCMセット部品情報表示でキャンペーンが反映されない障害対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡 孝憲　30745
// 作 成 日  2015/02/10  修正内容 : SCM高速化 回答納期区分対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 豊沢 憲弘　31065
// 作 成 日  2015/02/18  修正内容 : SCM高速化 システム障害№242対応
//----------------------------------------------------------------------------//
// 管理番号  11170206-00 作成担当 : 顧棟
// 作 成 日  2016/01/13  修正内容 : Redmine#47847 2016年2月配信分
//                                : フタバ倉庫引当てオプションオン：既存のままで行う対応
//                                : フタバ倉庫引当てオプションオフ：SCM問合手動回答時、売上明細データの倉庫に得意先マスタの優先倉庫と拠点設定の倉庫１～３
//                                :                                 以外の倉庫が表示されている障害の対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;
using Broadleaf.Application.Remoting.ParamData; // ADD 2010/08/10
namespace Broadleaf.Application.Controller
{
    using CustomerServer            = SingletonInstance<CustomerAgent>;                 // 得意先マスタ
    using SecInfoSetServer          = SingletonInstance<SecInfoSetAgent>;               // 拠点設定マスタ
    using DeliveryDateSettingServer = SingletonInstance<SCMDeliveryDateSettingAgent>;   // SCM納期設定マスタ
    using SalesTtlStServer          = SingletonInstance<SalesTtlStAgent>;               // 売上全体設定マスタ

    /// <summary>
    /// SCM用の情報付商品連結データのヘルパクラス
    /// </summary>
    public class SCMGoodsUnitData
    {
        private const string MY_NAME = "SCMGoodsUnitData";  // ログ用

        // ----- ADD 2011/08/10 ----- >>>>>
        // 受発注種別
        private int _acceptOrOrderKind;

        /// <summary>
        /// 受発注種別を取得または設定します。
        /// </summary>
        public int AcceptOrOrderKind
        {
            get { return _acceptOrOrderKind; }
            set { _acceptOrOrderKind = value; }
        }

        #region <セット子商品のSCM用の情報付商品連結データ>
        /// <summary>セット子商品のSCM用の情報付商品連結データ</summary>
        private List<SCMGoodsUnitData> _setSCMGoodsUnitDataList;
        /// <summary>セット子商品のSCM用の情報付商品連結データを取得します。</summary>
        public List<SCMGoodsUnitData> SetSCMGoodsUnitDataList 
         {
            get
            {
                if (_setSCMGoodsUnitDataList == null)
                {
                    _setSCMGoodsUnitDataList = new List<SCMGoodsUnitData>();
                }
                return _setSCMGoodsUnitDataList;
            }
            set { _setSCMGoodsUnitDataList = value; }
        }
        #endregion

        // PCC自社設定マスタ
        private PccCmpnyStWork _pccCmpnySt;
        /// <summary>SCM受注データの関連マップを取得します。</summary>
        public PccCmpnyStWork PccCmpnySt
        {
            get
            {
                if (_pccCmpnySt == null)
                {
                    _pccCmpnySt = new PccCmpnyStWork();
                }
                return _pccCmpnySt;
            }
            set
            {
                _pccCmpnySt = value;
            }
        }
        // ----- ADD 2011/08/10 ----- <<<<<

        #region <商品連結データ>

        /// <summary>本物の商品連結データ</summary>
        private readonly GoodsUnitData _realGoodsUnitData;
        /// <summary>本物の商品連結データを取得します。</summary>
        public GoodsUnitData RealGoodsUnitData { get { return _realGoodsUnitData; } }

        #endregion // </商品連結データ>

        #region <検索種別>

        /// <summary>検索種別</summary>
        private readonly SCMSearchedResult.GoodsSearchDivCd _searchedType;
        /// <summary>検索種別を取得します。</summary>
        public SCMSearchedResult.GoodsSearchDivCd SearchedType { get { return _searchedType; } }

        #endregion // </検索種別>

        #region <元となったSCM受注データ>

        /// <summary>元となったSCM受注明細データ(問合せ・発注)</summary>
        private readonly ISCMOrderDetailRecord _sourceDetailRecord;
        /// <summary>元となったSCM受注明細データ(問合せ・発注)</summary>
        public ISCMOrderDetailRecord SourceDetailRecord { get { return _sourceDetailRecord; } }

        /// <summary>手動回答の判定にて生成されたか判断するフラグ</summary>
        private readonly bool _createdManually;
        /// <summary>手動回答の判定にて生成されたか判断するフラグを取得します。</summary>
        private bool CreatedManually { get { return _createdManually; } }

        #endregion // </元となったSCM受注データ>

        #region <得意先>

        /// <summary>得意先コード</summary>
        private readonly int _customerCode;
        /// <summary>得意先コードを取得します。</summary>
        public int CustomerCode { get { return _customerCode; } }

        /// <summary>得意先マスタを取得します。</summary>
        private static CustomerAgent CustomerDB
        {
            get { return CustomerServer.Singleton.Instance; }
        }

        #endregion // </得意先>

        // --- Add 2011/08/06 duzg for Redmine#23307 --->>>
        #region <SCM全体設定マスタ>
        /// <summary>SCM全体設定マスタのアクセサ</summary>
        private SCMTtlStAgent _ttlStSettingDB;
        /// <summary>SCM全体設定マスタのアクセサを取得します。</summary>
        protected SCMTtlStAgent TtlStSettingDB
        {
            get
            {
                if (_ttlStSettingDB == null)
                {
                    _ttlStSettingDB = new SCMTtlStAgent();
                }
                return _ttlStSettingDB;
            }
        }

        #endregion // </SCM全体設定マスタ>
        // --- Add 2011/08/06 duzg for Redmine#23307 ---<<<

        #region <自動回答可能フラグ>

        /// <summary>自動回答可能フラグ</summary>
        private bool _canReplyAutomatically;
        /// <summary>
        /// 自動回答可能フラグを取得または設定します。
        /// </summary>
        public bool CanReplyAutomatically
        {
            get { return _canReplyAutomatically; }
            set { _canReplyAutomatically = value; }
        }

        #endregion // </自動回答可能フラグ>

        // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>

        #region 削除(SCM改良の為)
        //#region <SCM品目設定>

        ///// <summary>SCM品目設定</summary>
        //private SCMPrtSetting _scmItemConfig;
        ///// <summary>SCM品目設定を取得または設定します。</summary>
        //public SCMPrtSetting SCMItemConfig
        //{
        //    get
        //    {
        //        if (_scmItemConfig == null)
        //        {
        //            _scmItemConfig = new SCMPrtSetting();
        //        }
        //        return _scmItemConfig;
        //    }
        //    set { _scmItemConfig = value; }
        //}

        ///// <summary>
        ///// 価格を回答できるか判断します。
        ///// </summary>
        //private bool CanReplyPrice
        //{
        //    // UPD 2012/06/29 湯上 No.274 ---------------------------------------------------->>>>>
        //    //>>>2012/06/26
        //    //// --- UPD 三戸 2012/05/28 №274 ---------->>>>>
        //    ////get { return SCMItemConfig.AutoAnswerDiv.Equals((int)SCMPrtSettingAgent.AutoAnswerDiv.Price); }
        //    //get { return !SCMItemConfig.AutoAnswerDiv.Equals((int)SCMPrtSettingAgent.AutoAnswerDiv.DeliveryDate); }
        //    //// --- UPD 三戸 2012/05/28 №274 ----------<<<<<

        //    //get { return SCMItemConfig.AutoAnswerDiv.Equals((int)SCMPrtSettingAgent.AutoAnswerDiv.Price); }
        //    //<<<2012/06/26
        //    // 自動回答区分が「納期」以外の時は「価格」で回答する
        //    get { return !SCMItemConfig.AutoAnswerDiv.Equals((int)SCMPrtSettingAgent.AutoAnswerDiv.DeliveryDate); }
        //    // UPD 2012/06/29 湯上 No.274 ----------------------------------------------------<<<<<
        //}

        //#endregion // </SCM品目設定>
        #endregion

        #region <自動回答品目設定>

        /// <summary>自動回答品目設定</summary>
        private AutoAnsItemSt _autoAnsItemStConfig;
        /// <summary>自動回答品目設定を取得または設定します。</summary>
        public AutoAnsItemSt AutoAnsItemStConfig
        {
            get
            {
                if (_autoAnsItemStConfig == null)
                {
                    _autoAnsItemStConfig = new AutoAnsItemSt();
                }
                return _autoAnsItemStConfig;
            }
            set { _autoAnsItemStConfig = value; }
        }
        #endregion // </自動回答品目設定>

        // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<

        #region <単価算出結果>

        /// <summary>単価算出結果のリスト</summary>
        private IList<UnitPriceCalcRet> _unitPriceCalcRetList;
        /// <summary>単価算出結果のリストを取得または設定します。</summary>
        public IList<UnitPriceCalcRet> UnitPriceCalcRetList
        {
            get
            {
                if (_unitPriceCalcRetList == null)
                {
                    _unitPriceCalcRetList = new List<UnitPriceCalcRet>();
                }
                return _unitPriceCalcRetList;
            }
            set { _unitPriceCalcRetList = value; }
        }

        #endregion // </単価算出結果>

        #region <相場情報>

        /// <summary>相場情報のリスト</summary>
        private IList<SCMSobaResponseHelper> _scmSobaResponseList;
        /// <summary>相場情報のリストを取得または設定します。</summary>
        public IList<SCMSobaResponseHelper> SCMSobaResponseList
        {
            get
            {
                if (_scmSobaResponseList == null)
                {
                    _scmSobaResponseList = new List<SCMSobaResponseHelper>();
                }
                return _scmSobaResponseList;
            }
            set { _scmSobaResponseList = value; }
        }

        /// <summary>
        /// 相場情報を追加します。
        /// </summary>
        /// <param name="sobaResponse">相場情報</param>
        public void AddSobaResponse(SCMSobaResponseHelper sobaResponse)
        {
            SCMSobaResponseList.Add(sobaResponse);
        }

        /// <summary>
        /// 相場価格を持っているか判断します。
        /// </summary>
        /// <value>
        /// <c>true</c> :相場価格を持っています。<br/>
        /// <c>false</c>:相場価格を持っていません。
        /// </value>
        public bool HasMarketPrice
        {
            get { return SCMSobaResponseList.Count > 0; }
        }

        #endregion // </相場情報>

        #region <キャンペーン情報>

        /// <summary>キャンペーン情報</summary>
        private CampaignInformation _campaignInformation;
        /// <summary>キャンペーン情報を取得または設定します。</summary>
        public CampaignInformation CampaignInformation
        {
            get
            {
                if (_campaignInformation == null)
                {
                    _campaignInformation = new CampaignInformation();
                }
                return _campaignInformation;
            }
            set { _campaignInformation = value; }
        }

        #endregion // </キャンペーン情報>

        #region <自動連携値引情報>

        #endregion // </自動連携値引情報>

        #region <売上全体設定>

        /// <summary>
        /// 売上全体設定マスタを取得します。
        /// </summary>
        private static SalesTtlStAgent SalesTtlStDB
        {
            get { return SalesTtlStServer.Singleton.Instance; }
        }

        #endregion // </売上全体設定>

        //>>>2012/01/04
        #region 純正情報
        /// <summary>純正メーカーコード</summary>
        private int _pureGoodsMakerCd = 0;
        /// <summary>純正メーカーコード</summary>
        public int PureGoodsMakerCd
        {
            get { return this._pureGoodsMakerCd; }
            set { this._pureGoodsMakerCd = value; }
        }
        /// <summary>回答純正商品番号</summary>
        private string _ansPureGoodsNo = string.Empty;
        /// <summary>回答純正商品番号</summary>
        public string AnsPureGoodsNo
        {
            get { return this._ansPureGoodsNo; }
            set { this._ansPureGoodsNo = value; }
        }
        #endregion

        #region 表示順位
        /// <summary>回答用表示順位</summary>
        private int _retDisplayOrder = 0;
        /// <summary>回答用表示順位</summary>
        public int RetDisplayOrder
        {
            get { return this._retDisplayOrder; }
            set { this._retDisplayOrder = value; }
        }
        #endregion
        //<<<2012/01/04

        #region <Constructor>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="realGoodsUnitData">本物の商品連結データ</param>
        /// <param name="searchedType">検索種別</param>
        /// <param name="sourceDetailRecord">元となったSCM受注明細データ(問合せ・発注)</param>
        /// <param name="customerCode">得意先コード</param>
        public SCMGoodsUnitData(
            GoodsUnitData realGoodsUnitData,
            SCMSearchedResult.GoodsSearchDivCd searchedType,
            ISCMOrderDetailRecord sourceDetailRecord,
            int customerCode
        ) : this(realGoodsUnitData, searchedType, sourceDetailRecord, customerCode, false)
        { }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="realGoodsUnitData">本物の商品連結データ</param>
        /// <param name="searchedType">検索種別</param>
        /// <param name="sourceDetailRecord">元となったSCM受注明細データ(問合せ・発注)</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="createdManually">手動回答の判定にて生成されたか判断するフラグ</param>
        public SCMGoodsUnitData(
            GoodsUnitData realGoodsUnitData,
            SCMSearchedResult.GoodsSearchDivCd searchedType,
            ISCMOrderDetailRecord sourceDetailRecord,
            int customerCode,
            bool createdManually
        )
        {
            _realGoodsUnitData  = realGoodsUnitData;
            _searchedType       = searchedType;
            _sourceDetailRecord = sourceDetailRecord;
            _customerCode       = customerCode;
            _createdManually    = createdManually;
        }

        #endregion // </Constructor>

        // ADD 2012/07/18 SCM障害№173 --------------------------------------------->>>>>
        #region <列挙型>
        /// <summary>
        /// 優先倉庫順位列挙型
        /// </summary>
        public enum PriWareHouseOrder : int
        {
            /// <summary>なし</summary>
            None = 0,
            /// <summary>優先倉庫１</summary>
            PriWareHouse1 = 1,
            /// <summary>優先倉庫２</summary>
            PriWareHouse2 = 2,
            /// <summary>優先倉庫３</summary>
            // UPD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
            //PriWareHouse3 = 3
            PriWareHouse3 = 3,
            /// <summary>優先倉庫４</summary>
            PriWareHouse4 = 4
            // UPD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
        }
        #endregion //</列挙型>
        // ADD 2012/07/18 SCM障害№173 ---------------------------------------------<<<<<

        // ADD 2012/06/29 湯上 No.274 ---------------------------------------------------->>>>>
        /// <summary>
        /// SCM用の情報付商品連結データ複製処理
        /// </summary>
        /// <returns>SCMGoodsUnitDataクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSCMGoodsUnitDataクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SCMGoodsUnitData Clone()
        {
            return new SCMGoodsUnitData(this._realGoodsUnitData, this._searchedType, this._sourceDetailRecord, this._customerCode, this._createdManually);
        }
        // ADD 2012/06/29 湯上 No.274 ----------------------------------------------------<<<<<

        /// <summary>
        /// 売上データを作成できるか判断します。
        /// </summary>
        /// <remarks>
        /// 売伝用に手動回答と判定された明細データも受注データの作成が必要。
        /// ただし、問合せ・発注種別が"発注"で委託在庫以外のものを対象とする
        /// </remarks>
        /// <returns>
        /// <c>true</c> :売上データを作成できます。<br/>
        /// <c>false</c>:売上データを作成できません。
        /// </returns>
        public bool CanMakeSalesData()
        {
            if (CreatedManually)
            {
                return SourceDetailRecord.InqOrdDivCd.Equals((int)InqOrdDivCdValue.Ordering) && !IsTrustStock();
            }
            else
            {
                return true;
            }
        }

        #region <表示順位>

        /// <summary>
        /// 表示順位を取得します。
        /// </summary>
        public int DisplayOrder
        {
            get { return RealGoodsUnitData.PrimePartsDisplayOrder; }
        }

        /// <summary>
        /// 純正であるか判断します。
        /// </summary>
        public bool IsPure()
        {
            return DisplayOrder.Equals(SCMSearchedResult.PURE_DISPLAY_ORDER);
        }

        #endregion // </表示順位>

        #region <商品種別>

        /// <summary>
        /// 商品種別を取得します。
        /// </summary>
        /// <param name="isAnswer">回答フラグ</param>
        /// <returns>
        /// 優先1<br/>
        /// 相場回答した場合、3:平均相場<br/>
        /// リサイクル回答した場合、2:リサイクル部品
        /// 優先2<br/>
        /// <c>GoodsUnitData.OfferKubun</c>→商品種別<br/>
        /// 1:提供純正編集  →0:純正<br/>
        /// 2:提供優良編集  →1:優良<br/>
        /// 3:提供純正      →0:純正<br/>
        /// 4:提供優良      →1:優良<br/>
        /// 5:TBO           →1:優良<br/>
        /// 6:オリジナル部品→1:優良<br/>
        /// </returns>
        public int GetGoodsDivCd(bool isAnswer)
        {
            if (isAnswer && HasMarketPrice)
            {
                return (int)GoodsDivCd.MarketPrice;
            }
            switch (SourceDetailRecord.GoodsDivCd)
            {
                case (int)GoodsDivCd.MarketPrice:   // 平均相場
                case (int)GoodsDivCd.Recycle:       // リサイクル部品
                    return SourceDetailRecord.GoodsDivCd;

                default:
                    switch (RealGoodsUnitData.OfferKubun)
                    {
                        // ----- ADD 2011/10/11 ----- >>>>>
                        case 0: // ユーザー登録
                            {
                                // 0:純正
                                if (RealGoodsUnitData.GoodsKindCode == 0)
                                {
                                    return (int)GoodsDivCd.Pure;
                                }
                                // 1:その他
                                else if (RealGoodsUnitData.GoodsKindCode == 1)
                                {
                                    return (int)GoodsDivCd.Prime;
                                }
                                return (int)GoodsDivCd.Prime;
                            }
                        // ----- ADD 2011/10/11 ----- <<<<<
                        case 1: // 提供純正編集
                        case 3: // 提供純正
                            return (int)GoodsDivCd.Pure;
                        
                        default:
                            return (int)GoodsDivCd.Prime;
                    }
            }
        }

        #endregion // </商品種別>

        #region <リサイクル部品>

        /// <summary>
        /// リサイクル部品種別を取得します。
        /// </summary>
        /// <param name="isAnswer">回答フラグ</param>
        /// <returns>リサイクル部品種別</returns>
        public int GetRecyclePrtKindCode(bool isAnswer)
        {
            if (HasMarketPrice)
            {
                // 相場回答の場合、リサイクル部品種別を直接返す
                return SCMSobaResponseList[0].MarketPriceKindCd;
            }
            if (GetGoodsDivCd(isAnswer).Equals((int)GoodsDivCd.Recycle))
            {
                if (SCMSobaResponseList.Count > 0)
                {
                    switch (SCMSobaResponseList[0].MarketPriceKindCd)
                    {
                        case (int)MarketPriceKindCd.Used:
                            return (int)RecyclePrtKindCode.Used;
                        case (int)MarketPriceKindCd.Rebuild:
                            return (int)RecyclePrtKindCode.Rebuild;
                    }
                }
            }
            return (int)RecyclePrtKindCode.None;
        }

        /// <summary>
        /// リサイクル部品種別名称を取得します。
        /// </summary>
        /// <param name="isAnswer">回答フラグ</param>
        /// <returns>リサイクル部品種別名称</returns>
        public string GetRecyclePrtKindName(bool isAnswer)
        {
            if (HasMarketPrice)
            {
                // 相場回答の場合、リサイクル部品種別名称を直接返す
                return SCMSobaResponseList[0].MarketPriceKindNm;
            }
            return SCMDataHelper.GetRecyclePrtKindName(GetRecyclePrtKindCode(isAnswer));
        }

        #endregion // </リサイクル部品>

        #region <在庫>

        /// <summary>
        /// 在庫が存在するか判断します。
        /// </summary>
        public bool ExistsStock
        {
            get
            {
                // 2011/01/11 >>>
                //return !(RealGoodsUnitData.StockList == null || RealGoodsUnitData.StockList.Count.Equals(0));
                return !( ( RealGoodsUnitData.SelectedWarehouseCode == null ) || ( string.IsNullOrEmpty(RealGoodsUnitData.SelectedWarehouseCode.Trim()) ) );
                // 2011/01/11 <<<
            }
        }

        /// <summary>
        /// 委託在庫であるか判断します。
        /// </summary>
        /// <returns>
        /// <c>true</c> :委託在庫です。<br/>
        /// <c>false</c>:委託在庫ではありません。
        /// </returns>
        public bool IsTrustStock()
        {
            return GetStockDiv().Equals((int)StockDiv.Trust);
        }

        #region <倉庫マスタ>

        /// <summary>倉庫マスタ</summary>
        private static WarehouseAgent _warehouseDB;
        /// <summary>倉庫マスタを取得します。</summary>
        private static WarehouseAgent WarehouseDB
        {
            get
            {
                if (_warehouseDB == null)
                {
                    _warehouseDB = new WarehouseAgent();
                }
                return _warehouseDB;
            }
        }

        //// ----- ADD 2011/08/10 ----- >>>>>
        ///// <summary>PCCUOE自社設定マスタ</summary>
        //private static SCMWebAcsAgent _pccDB;
        ///// <summary>PCCUOE自社設定マスタを取得します。</summary>
        //private static SCMWebAcsAgent PccDB
        //{
        //    get
        //    {
        //        if (_pccDB == null)
        //        {
        //            _pccDB = new SCMWebAcsAgent();
        //        }
        //        return _pccDB;
        //    }
        //}
        //// ----- ADD 2011/08/10 ----- <<<<<

        #endregion // </倉庫マスタ>

        #region <拠点設定マスタ>

        /// <summary>
        /// 拠点設定マスタを取得します。
        /// </summary>
        private static SecInfoSetAgent SecInfoSetDB
        {
            get { return SecInfoSetServer.Singleton.Instance; }
        }

        #endregion // </拠点設定マスタ>

        /// <summary>在庫区分</summary>
        private int _stockDiv = -1;
        /// <summary>
        /// 在庫区分を取得します。
        /// </summary>
        /// <returns>在庫区分</returns>
        public int GetStockDiv()
        {
            const string METHOD_NAME = "GetStockDiv()"; // ログ用

            if (_stockDiv >= 0) return _stockDiv;

            // DEL 2012/12/12 2013/01/16配信 SCM改良№10423対応 ---------------------------------->>>>>
            #region 削除
            //// SCMの場合
            //if (this._acceptOrOrderKind == (int)EnumAcceptOrOrderKind.SCM) // ADD 2011/08/10
            //{ // ADD 2011/08/10
            //    // 在庫情報がない場合、非在庫
            //    if (!ExistsStock)
            //    {
            //        _stockDiv = (int)StockDiv.None;
            //        return _stockDiv;
            //    }

            //    if (string.IsNullOrEmpty(RealGoodsUnitData.SelectedWarehouseCode))
            //    {
            //        // 2011/01/11 Del >>>
            //        //// 選択している倉庫コードが不定の場合、最初の在庫品の倉庫コードを使用する
            //        //RealGoodsUnitData.SelectedWarehouseCode = GetFirstStockedWarehouseProfile().Key;

            //        // 検索結果の倉庫が入っていなければ非在庫
            //        _stockDiv = (int)StockDiv.None;
            //        return _stockDiv;
            //        // 2011/01/11 Del <<<
            //    }

            //    _warehouseCode = RealGoodsUnitData.SelectedWarehouseCode;   // 倉庫コード
            //    _warehouseName = string.Empty;                              // 倉庫名称

            //    // 委託在庫
            //    // 倉庫マスタの得意先コードとSCM受注明細データ(問合せ・発注)の得意先コードが一致
            //    Warehouse foundWarehouse = WarehouseDB.Find(RealGoodsUnitData);
            //    if (foundWarehouse != null)
            //    {
            //        #region <Log>

            //        string msg = string.Format(
            //            "委託在庫を判定中...SelectedWarehouseCode=「{0}」, foundWarehouse.WarehouseCode=「{1}」, CustomerCode=「{2}」, foundWarehouse.CustomerCode=「{3}」",
            //            _warehouseCode,
            //            foundWarehouse.WarehouseCode,
            //            CustomerCode,
            //            foundWarehouse.CustomerCode
            //        );
            //        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

            //        #endregion // </Log>

            //        // 倉庫名称
            //        _warehouseName = foundWarehouse.WarehouseName;

            //        if (foundWarehouse.CustomerCode.Equals(CustomerCode))
            //        {
            //            _stockDiv = (int)StockDiv.Trust;
            //            return _stockDiv;
            //        }
            //    }
            //    else
            //    {
            //        #region <Log>

            //        string msg = string.Format("委託在庫を判定中...倉庫マスタに登録がありません。(倉庫コード={0})", _warehouseCode);
            //        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

            //        #endregion // </Log>

            //        // 倉庫名称
            //        _warehouseName = GetFirstStockedWarehouseProfile().Value;
            //    }

            //    // 得意先在庫
            //    // 得意先マスタの得意先倉庫コードと一致
            //    CustomerDB.TakeCustomerInfo(SourceDetailRecord.InqOtherEpCd, CustomerCode);
            //    if (CustomerDB.CustomerInfoMap.ContainsKey(CustomerCode))
            //    {
            //        CustomerInfo customerInfo = CustomerDB.CustomerInfoMap[CustomerCode];
            //        {
            //            if (customerInfo.CustWarehouseCd.Trim().Equals(_warehouseCode.Trim()))
            //            {
            //                _stockDiv = (int)StockDiv.Customer;
            //                return _stockDiv;
            //            }
            //        }
            //    }

            //    // 優先倉庫
            //    // 拠点設定マスタの倉庫
            //    if (SecInfoSetDB.ExistsWarehouse(
            //        SourceDetailRecord.InqOtherEpCd,
            //        SourceDetailRecord.InqOtherSecCd,
            //        _warehouseCode
            //    ))
            //    {
            //        _stockDiv = (int)StockDiv.PriorityWarehouse;
            //        return _stockDiv;
            //    }

            //    // 自社在庫
            //    // 倉庫コードが設定有りで、上記条件を満たさない場合
            //    if (!string.IsNullOrEmpty(_warehouseCode.Trim()))
            //    {
            //        _stockDiv = (int)StockDiv.OwnCompany;
            //        return _stockDiv;
            //    }

            //    // 非在庫
            //    // 倉庫コードが設定無しで、上記条件を満たさない場合
            //    _stockDiv = (int)StockDiv.None;
            //    return _stockDiv;
            //    // ----- ADD 2011/08/10 ----- >>>>>
            //}
            //// PCCUOEの場合
            //else
            //{
            #endregion
            // DEL 2012/12/12 2013/01/16配信 SCM改良№10423対応 ----------------------------------<<<<<
                // 在庫確認の場合
                if (SourceDetailRecord.InqOrdDivCd.Equals((int)InqOrdDivCdValue.Inquiry))
                {
                    // 在庫情報がない場合、非在庫
                    if (ListUtil.IsNullOrEmpty(RealGoodsUnitData.StockList))
                    {
                        _stockDiv = (int)StockDiv.None;
                        return _stockDiv;
                    }
                    else
                    {
                        // --- ADD 2016/01/13 顧棟 Redmine#47847 手動回答優先倉庫表示不正の障害対応 ----->>>>>
                        // フタバ倉庫引当てオプションオンのみの場合、既存と同じ仕様で行う
                        if (CheckFutabaWarehAllocOption())
                        {
                        // --- ADD 2016/01/13 顧棟 Redmine#47847 手動回答優先倉庫表示不正の障害対応 -----<<<<<
                            // ADD 2012/12/12 2013/01/16配信 SCM改良№10423対応 ---------------------------------->>>>>
                            if (string.IsNullOrEmpty(RealGoodsUnitData.SelectedWarehouseCode))
                            {
                                // ADD 2012/12/12 2013/01/16配信 SCM改良№10423対応 ----------------------------------<<<<<
                                List<string> priorWarehouseList = new List<string>();
                                priorWarehouseList.Add(string.IsNullOrEmpty(PccCmpnySt.PccWarehouseCd) ? "" : PccCmpnySt.PccWarehouseCd);
                                priorWarehouseList.Add(string.IsNullOrEmpty(PccCmpnySt.PccPriWarehouseCd1) ? "" : PccCmpnySt.PccPriWarehouseCd1);
                                priorWarehouseList.Add(string.IsNullOrEmpty(PccCmpnySt.PccPriWarehouseCd2) ? "" : PccCmpnySt.PccPriWarehouseCd2);
                                priorWarehouseList.Add(string.IsNullOrEmpty(PccCmpnySt.PccPriWarehouseCd3) ? "" : PccCmpnySt.PccPriWarehouseCd3);
                                // UPD 2013/10/17 商品保証課Redmine#552対応 ------------------------------------------>>>>>
                                //// ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
                                //priorWarehouseList.Add(string.IsNullOrEmpty(PccCmpnySt.PccPriWarehouseCd4) ? "" : PccCmpnySt.PccPriWarehouseCd4);
                                //// ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
                                if (CheckPriWarehouseOption())
                                {
                                    priorWarehouseList.Add(string.IsNullOrEmpty(PccCmpnySt.PccPriWarehouseCd4) ? "" : PccCmpnySt.PccPriWarehouseCd4);
                                }
                                // UPD 2013/10/17 商品保証課Redmine#552対応 ------------------------------------------<<<<<

                                foreach (string warehouseCode in priorWarehouseList)
                                {
                                    if (string.IsNullOrEmpty(warehouseCode)) continue;
                                    Stock findStock = RealGoodsUnitData.StockList.Find(
                                        delegate(Stock stockInfo)
                                        {
                                            return (stockInfo.WarehouseCode.Trim().Equals(warehouseCode.Trim()));
                                        }
                                        );
                                    if (findStock != null)
                                    {
                                        RealGoodsUnitData.SelectedWarehouseCode = findStock.WarehouseCode;
                                        break;
                                    }
                                }
                                // ADD 2012/12/12 2013/01/16配信 SCM改良№10423対応 ---------------------------------->>>>>
                            }
                            // ADD 2012/12/12 2013/01/16配信 SCM改良№10423対応 ----------------------------------<<<<<
                        } // ADD 2016/01/13 顧棟 Redmine#47847 手動回答優先倉庫表示不正の障害対応

                        if (!string.IsNullOrEmpty(RealGoodsUnitData.SelectedWarehouseCode))
                        {
                            _warehouseCode = RealGoodsUnitData.SelectedWarehouseCode;   // 倉庫コード
                            _warehouseName = string.Empty;                              // 倉庫名称

                            Warehouse foundWarehouse = WarehouseDB.Find(RealGoodsUnitData);
                            if (foundWarehouse != null)
                            {
                                // 倉庫名称
                                _warehouseName = foundWarehouse.WarehouseName;
                            }
                            else
                            {
                                // 倉庫名称
                                _warehouseName = GetFirstStockedWarehouseProfile().Value;
                            }

                            // 委託在庫
                            if (RealGoodsUnitData.SelectedWarehouseCode.Trim() == PccCmpnySt.PccWarehouseCd.Trim())
                            {
                                _stockDiv = (int)StockDiv.Trust;

                            }
                            // 優先在庫
                            else if (RealGoodsUnitData.SelectedWarehouseCode.Trim() == PccCmpnySt.PccPriWarehouseCd1.Trim()
                                || RealGoodsUnitData.SelectedWarehouseCode.Trim() == PccCmpnySt.PccPriWarehouseCd2.Trim()
                                || RealGoodsUnitData.SelectedWarehouseCode.Trim() == PccCmpnySt.PccPriWarehouseCd3.Trim()
                                // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
                                // UPD 2013/10/17 商品保証課Redmine#552対応 ------------------------------------------>>>>>
                                //|| RealGoodsUnitData.SelectedWarehouseCode.Trim() == PccCmpnySt.PccPriWarehouseCd4.Trim()
                                || (CheckPriWarehouseOption() && RealGoodsUnitData.SelectedWarehouseCode.Trim() == PccCmpnySt.PccPriWarehouseCd4.Trim())
                                // UPD 2013/10/17 商品保証課Redmine#552対応 ------------------------------------------<<<<<
                                // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
                                )
                            {
                                _stockDiv = (int)StockDiv.PriorityWarehouse;
                            }
                            return _stockDiv;
                        }
                        else
                        // 在庫
                        {
                            // --- ADD 2016/01/13 顧棟 Redmine#47847 手動回答優先倉庫表示不正の障害対応 ----->>>>>
                            // フタバ倉庫引当てオプションオンのみの場合、既存と同じ仕様で行う
                            if (CheckFutabaWarehAllocOption())
                            {
                            // --- ADD 2016/01/13 顧棟 Redmine#47847 手動回答優先倉庫表示不正の障害対応 -----<<<<<
                                // ----- ADD 2011/09/26 ----- >>>>>
                                // ----- DEL 2011/09/19 ----- >>>>>
                                // 倉庫コード
                                _warehouseCode = GetFirstStockedWarehouseProfile().Key;
                                // 倉庫名称
                                _warehouseName = GetFirstStockedWarehouseProfile().Value;

                                RealGoodsUnitData.SelectedWarehouseCode = _warehouseCode;

                                _stockDiv = (int)StockDiv.OwnCompany;
                                // ----- DEL 2011/09/19 ----- <<<<<
                                // ----- DEL 2011/09/26 ----- <<<<<

                                //_stockDiv = (int)StockDiv.None; // ADD 2011/09/19 // DEL 2011/09/26
                            // --- ADD 2016/01/13 顧棟 Redmine#47847 手動回答優先倉庫表示不正の障害対応 ----->>>>>
                            }
                            else
                            {
                                // 倉庫コードが選択していない場合、非在庫とする。
                                _stockDiv = (int)StockDiv.None;
                            }
                            // --- ADD 2016/01/13 顧棟 Redmine#47847 手動回答優先倉庫表示不正の障害対応 -----<<<<<
                            return _stockDiv;
                        }
                    }

                }
                // 発注の場合
                else
                {
                    //>>>2012/04/09
                    //// 委託在庫
                    //if (!string.IsNullOrEmpty(RealGoodsUnitData.SelectedWarehouseCode) && RealGoodsUnitData.SelectedWarehouseCode.Trim() == PccCmpnySt.PccWarehouseCd.Trim())
                    //{
                    //    _stockDiv = (int)StockDiv.Trust;
                    //}
                    //// 非委託在庫
                    //else
                    //{
                    //    _stockDiv = -1;
                    //}
                    // 在庫情報がない場合、非在庫
                    if (!ExistsStock)
                    {
                        _stockDiv = (int)StockDiv.None;
                        return _stockDiv;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(RealGoodsUnitData.SelectedWarehouseCode))
                        {
                            // 委託在庫
                            if (RealGoodsUnitData.SelectedWarehouseCode.Trim() == PccCmpnySt.PccWarehouseCd.Trim())
                            {
                                _stockDiv = (int)StockDiv.Trust;

                            }
                            // 優先在庫
                            else if (RealGoodsUnitData.SelectedWarehouseCode.Trim() == PccCmpnySt.PccPriWarehouseCd1.Trim()
                                || RealGoodsUnitData.SelectedWarehouseCode.Trim() == PccCmpnySt.PccPriWarehouseCd2.Trim()
                                || RealGoodsUnitData.SelectedWarehouseCode.Trim() == PccCmpnySt.PccPriWarehouseCd3.Trim()
                                // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
                                // UPD 2013/10/17 商品保証課Redmine#552対応 ------------------------------------------>>>>>
                                //|| RealGoodsUnitData.SelectedWarehouseCode.Trim() == PccCmpnySt.PccPriWarehouseCd4.Trim()
                                || (CheckPriWarehouseOption() && RealGoodsUnitData.SelectedWarehouseCode.Trim() == PccCmpnySt.PccPriWarehouseCd4.Trim())
                                // UPD 2013/10/17 商品保証課Redmine#552対応 ------------------------------------------<<<<<
                                // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
                                )
                            {
                                _stockDiv = (int)StockDiv.PriorityWarehouse;
                            }
                        }
                        else
                        // 在庫
                        {
                            _stockDiv = (int)StockDiv.OwnCompany;
                        }
                    }
                    //<<<2012/04/09

                    if (!string.IsNullOrEmpty(RealGoodsUnitData.SelectedWarehouseCode))
                    {
                        _warehouseCode = RealGoodsUnitData.SelectedWarehouseCode;   // 倉庫コード
                        _warehouseName = string.Empty;                              // 倉庫名称

                        Warehouse foundWarehouse = WarehouseDB.Find(RealGoodsUnitData);
                        if (foundWarehouse != null)
                        {
                            // 倉庫名称
                            _warehouseName = foundWarehouse.WarehouseName;
                        }
                    }
                    return _stockDiv;
                }
            // DEL 2012/12/12 2013/01/16配信 SCM改良№10423対応 ---------------------------------->>>>>
            //}
            // DEL 2012/12/12 2013/01/16配信 SCM改良№10423対応 ----------------------------------<<<<<
            // ----- ADD 2011/08/10 ----- <<<<<
        }

        // ADD 2012/07/18 SCM障害№173 ------------------------------------------->>>>>
        /// <summary>
        /// 優先倉庫順位を取得します。
        /// </summary>
        /// <returns>優先倉庫順位</returns>
        public PriWareHouseOrder GetPriWareHouseOrder()
        {
            PriWareHouseOrder ret = PriWareHouseOrder.None;

            if (!string.IsNullOrEmpty(RealGoodsUnitData.SelectedWarehouseCode))
            {
                if (RealGoodsUnitData.SelectedWarehouseCode.Trim() == PccCmpnySt.PccPriWarehouseCd1.Trim())
                {
                    ret = PriWareHouseOrder.PriWareHouse1;
                }
                else if (RealGoodsUnitData.SelectedWarehouseCode.Trim() == PccCmpnySt.PccPriWarehouseCd2.Trim())
                {
                    ret = PriWareHouseOrder.PriWareHouse2;
                }
                else if (RealGoodsUnitData.SelectedWarehouseCode.Trim() == PccCmpnySt.PccPriWarehouseCd3.Trim())
                {
                    ret = PriWareHouseOrder.PriWareHouse3;
                }
                // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
                // UPD 2013/10/17 商品保証課Redmine#552対応 ------------------------------------------>>>>>
                //else if (RealGoodsUnitData.SelectedWarehouseCode.Trim() == PccCmpnySt.PccPriWarehouseCd4.Trim())
                else if (CheckPriWarehouseOption() && (RealGoodsUnitData.SelectedWarehouseCode.Trim() == PccCmpnySt.PccPriWarehouseCd4.Trim()))
                // UPD 2013/10/17 商品保証課Redmine#552対応 ------------------------------------------<<<<<
                {
                    ret = PriWareHouseOrder.PriWareHouse4;
                }
                // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<

            }
            return ret;
        }
        // ADD 2012/07/18 SCM障害№173 -------------------------------------------<<<<<

        // ADD 2013/10/17 商品保証課Redmine#552対応 ------------------------------------------>>>>>
        /// <summary>
        ///  BLP参照倉庫追加オプションチェック
        /// </summary>
        /// <returns></returns>
        private static bool CheckPriWarehouseOption()
        {
            USBOptionAgent usbOptin = new USBOptionAgent();
            return usbOptin.EnabledBLPPriWarehouseOption();
        }

        // --- ADD 2016/01/13 顧棟 Redmine#47847 フタバ倉庫引当てオプション  （個別）：OPT-CPM0100を追加する ----->>>>>
        /// <summary>
        ///  フタバ倉庫引当てオプションチェック
        /// </summary>
        /// <returns></returns>
        private static bool CheckFutabaWarehAllocOption()
        {
            USBOptionAgent usbOptin = new USBOptionAgent();
            return usbOptin.EnabledFutabaWarehAllocOption();
        }
        // --- ADD 2016/01/13 顧棟 Redmine#47847 フタバ倉庫引当てオプション  （個別）：OPT-CPM0100を追加する -----<<<<<
        // ADD 2013/10/17 商品保証課Redmine#552対応 ------------------------------------------<<<<<

        // ----- ADD 2011/08/10 ----- >>>>>
        /// <summary>
        /// 仕入数量を取得します。
        /// </summary>
        /// <returns>仕入数量</returns>
        public double GetStockQty()
        {

            List<Stock> tempStockList = RealGoodsUnitData.StockList;
            if (!ListUtil.IsNullOrEmpty(tempStockList))
            {
                for(int i=0;i<tempStockList.Count;i++)
                {
                    Stock tempStock = tempStockList[i];
                    if (RealGoodsUnitData.SelectedWarehouseCode != null && tempStock.WarehouseCode == RealGoodsUnitData.SelectedWarehouseCode.Trim())
                    {
                        return tempStock.ShipmentPosCnt;
                    }
                }
                return tempStockList[0].ShipmentPosCnt;
            }
            else
            {
                return 0;
            }
        }
        // ----- ADD 2011/08/10 ----- <<<<<
        /// <summary>
        /// 最初の在庫品の倉庫コードと倉庫名称を取得します。
        /// </summary>
        /// <returns>
        /// 最初の在庫品の倉庫コードと倉庫名称 ※在庫がない場合、<c>string.Empty</c>を返します。
        /// </returns>
        private KeyValuePair<string, string> GetFirstStockedWarehouseProfile()
        {
            if (!ListUtil.IsNullOrEmpty<Stock>(RealGoodsUnitData.StockList))
            {
                return new KeyValuePair<string, string>(
                    RealGoodsUnitData.StockList[0].WarehouseCode,
                    RealGoodsUnitData.StockList[0].WarehouseName
                );
            }
            return new KeyValuePair<string, string>(string.Empty, string.Empty);
        }

        /// <summary>倉庫コード</summary>
        private string _warehouseCode;
        /// <summary>倉庫コードを取得します。</summary>
        public string GetWarehouseCode()
        {
            if (_stockDiv < 0) GetStockDiv();
            return string.IsNullOrEmpty(_warehouseCode) ? string.Empty : _warehouseCode;
        }

        /// <summary>倉庫名称</summary>
        private string _warehouseName;
        /// <summary>倉庫名称を取得します。</summary>
        public string GetWarehouseName()
        {
            if (_stockDiv < 0) GetStockDiv();
            return string.IsNullOrEmpty(_warehouseName) ? string.Empty : _warehouseName;
        }

        #endregion // </在庫>

        #region <受注ステータス>

        /// <summary>受注ステータス</summary>
        private int _acptAnOdrStatus = -1;
        /// <summary>
        /// 受注ステータスを取得します。
        /// </summary>
        /// <returns>
        /// SCM受注明細データ(問合せ・発注).問合せ・発注種別が"問合せ"の場合、10:見積 を返します。<br/>
        /// SCM受注明細データ(問合せ・発注).問合せ・発注種別が"発注"の場合、
        /// 在庫情報に応じて、"20:受注"または"30:売上"を返します。
        /// </returns>
        public int GetAcptAnOdrStatus()
        {
            // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ---------->>>>>
            #region 見積計上用処理

            // 見積計上の場合、売上
            if (RealGoodsUnitData is AnsweredGoodsUnitData) return (int)AcptAnOdrStatus.Sales;

            #endregion // 見積計上用処理
            // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ----------<<<<<

            if (_acptAnOdrStatus >= 0) return _acptAnOdrStatus;

            // UPD 2014/09/19 SCM社内障害一覧№44対応 ----------------------------->>>>>
            //int acptAnOdrStatus = SCMDataHelper.GetDefaultAcptAnOdrStatus(SourceDetailRecord.InqOrdDivCd);
            _acptAnOdrStatus = SCMDataHelper.GetDefaultAcptAnOdrStatus(SourceDetailRecord.InqOrdDivCd);
            return _acptAnOdrStatus;
            // UPD 2014/09/19 SCM社内障害一覧№44対応 -----------------------------<<<<<

            // DEL 2014/09/19 SCM社内障害一覧№44対応 ----------------------------->>>>>
            #region 削除
            //////// SCM受注明細データ(問合せ・発注).問合せ・発注種別が"問合せ"の場合、10:見積 を返します。
            //////if (acptAnOdrStatus.Equals((int)AcptAnOdrStatus.Estimate))
            //////{
            //////    _acptAnOdrStatus = acptAnOdrStatus;
            //////    return _acptAnOdrStatus;
            //////}


            //////// DEL 2012/11/27 2012/12/12配信 システムテスト障害№86対応 ------------------------------>>>>>
            ////////// --- ADD 湯上 2012/04/23 №150 Redmine#28038 ---------->>>>>
            ////////// SCMの場合
            ////////if (this._acceptOrOrderKind != (int)EnumAcceptOrOrderKind.PCCUOE)
            ////////{
            ////////    // SCM全体設定を取得
            ////////    SCMTtlSt foundSCMTtlSt = TtlStSettingDB.Find(
            ////////         SourceDetailRecord.InqOtherEpCd,
            ////////         SourceDetailRecord.InqOtherSecCd
            ////////        );

            ////////    if (foundSCMTtlSt.AutoAnswerDiv == 3)
            ////////    {
            ////////        _acptAnOdrStatus = (int)AcptAnOdrStatus.Sales;  // 売上
            ////////        return _acptAnOdrStatus;
            ////////    }
            ////////}
            ////////// --- ADD 湯上 2012/04/23 №150 Redmine#28038 ----------<<<<<
            //////// DEL 2012/11/27 2012/12/12配信 システムテスト障害№86対応 ------------------------------<<<<<

            //////// SCM受注明細データ(問合せ・発注).問合せ・発注種別が"発注"の場合
            //////// 在庫情報がない場合、非在庫
            //////if (RealGoodsUnitData.StockList == null || RealGoodsUnitData.StockList.Count.Equals(0))
            //////{
            //////    _acptAnOdrStatus = (int)AcptAnOdrStatus.Order;  // 受注
            //////    return _acptAnOdrStatus;
            //////}

            //////// --- ADD 湯上 2012/04/23 №150 Redmine#28038 ---------->>>>>
            //////// SCMの場合
            //////if (this._acceptOrOrderKind != (int)EnumAcceptOrOrderKind.PCCUOE)
            //////{
            //////    //if (GetStockDiv().Equals((int)StockDiv.Trust))// Del 2011/08/06 duzg for Redmine#23307
            //////    if (GetStockDiv().Equals((int)StockDiv.Trust) || GetStockDiv().Equals((int)StockDiv.Customer) || GetStockDiv().Equals((int)StockDiv.PriorityWarehouse))// Add 2011/08/06 duzg for Redmine#23307
            //////    {
            //////        _acptAnOdrStatus = (int)AcptAnOdrStatus.Sales;  // 売上
            //////        return _acptAnOdrStatus;
            //////    }
            //////    else
            //////    {
            //////        // 得意先在庫
            //////        // 優先倉庫
            //////        // 自社在庫
            //////        // 非在庫
            //////        _acptAnOdrStatus = (int)AcptAnOdrStatus.Order;  // 受注
            //////        return _acptAnOdrStatus;
            //////    }
            //////}
            //////else
            //////{
            //////// --- ADD 湯上 2012/04/23 №150 Redmine#28038 ----------<<<<<
            //////    // 委託在庫
            //////    if (GetStockDiv().Equals((int)StockDiv.Trust))
            //////    {
            //////        _acptAnOdrStatus = (int)AcptAnOdrStatus.Sales;  // 売上
            //////        return _acptAnOdrStatus;
            //////    }
            //////    else
            //////    {
            //////        // 得意先在庫
            //////        // 優先倉庫
            //////        // 自社在庫
            //////        // 非在庫
            //////        _acptAnOdrStatus = (int)AcptAnOdrStatus.Order;  // 受注
            //////        return _acptAnOdrStatus;
            //////    }
            //////// --- ADD 湯上 2012/04/23 №150 Redmine#28038 ---------->>>>>
            //////}
            //////// --- ADD 湯上 2012/04/23 №150 Redmine#28038 ----------<<<<<
            #endregion
            // DEL 2014/09/19 SCM社内障害一覧№44対応 ----------------------------->>>>>
        }

        #endregion // </受注ステータス>

        #region <回答納期>

        #region <SCM納期設定マスタ>

        /// <summary>
        /// SCM納期設定マスタのアクセサを取得します。
        /// </summary>
        private static SCMDeliveryDateSettingAgent DeliveryDateSettingDB
        {
            get { return DeliveryDateSettingServer.Singleton.Instance; }
        }

        #endregion // </SCM納期設定マスタ>

        private const string DATE_FORMAT = "yyyy/MM/dd";

        /// <summary>回答納期</summary>
        private string _answerDeliveryDate = DateTime.MinValue.ToString(DATE_FORMAT);
        /// <summary>
        /// 回答納期を取得します。
        /// </summary>
        /// <returns>
        /// 非在庫品の場合のみSCM納期設定マスタより取得します。<br/>
        /// 相場回答は<c>string.Empty</c>を返します。
        /// </returns>
        // UPD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        #region 旧ソース
        //// UPD 2013/03/07 SCM障害№10489対応 ------------------------------------->>>>>
        ////public string GetAnswerDeliveryDate()
        //public string GetAnswerDeliveryDate(int fuwioutAutoAnsDiv)
        //// UPD 2013/03/07 SCM障害№10489対応 -------------------------------------<<<<<
        #endregion
        // ※ 当メソッド使用PGは自動回答のみで他PGからの参照は無し
        public string GetAnswerDeliveryDate(int fuwioutAutoAnsDiv, out Int16 ansDeliDateDiv)
        // UPD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        {
            const string METHOD_NAME = "GetAnswerDeliveryDate()";   // ログ用

            ansDeliDateDiv = 0; // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応

            // 相場回答は""
            if (HasMarketPrice)
            {
                return string.Empty;
            }

            // DEL 2015/02/18 豊沢 SCM仕掛一覧No10695対応 ---------->>>>>
            // 回答納期区分再取得のため削除
            //if (!_answerDeliveryDate.Equals(DateTime.MinValue.ToString(DATE_FORMAT)))
            //{
            //    return _answerDeliveryDate;
            //}
            // DEL 2015/02/18 豊沢 SCM仕掛一覧No10695対応 ----------<<<<<

            // ADD 2013/02/13 SCM障害追加②対応 2013/03/06配信-------------------------------------------->>>>>
            // UPD 2013/03/07 SCM障害№10489対応 ------------------------------------->>>>>
            // 該当なし自動回答区分が「する」で品番なし回答の時は回答納期も"該当無し"で回答する
            //if (RealGoodsUnitData.GoodsNo.Length.Equals(0))
            if (RealGoodsUnitData.GoodsNo.Length.Equals(0) && !RealGoodsUnitData.BLGoodsCode.Equals(0) &&
                fuwioutAutoAnsDiv.Equals((int)FuwioutAutoAnsDiv.Auto))
            // UPD 2013/03/07 SCM障害№10489対応 -------------------------------------<<<<<
            {
                return "該当無し";
            }
            // ADD 2013/02/13 SCM障害追加②対応 ----------------------------------------------------------<<<<<

            // 2011/01/11 >>>
            //// 非在庫品以外は在庫区分により設定
            //if (!GetStockDiv().Equals((int)StockDiv.None))
            //{
            //    _answerDeliveryDate = GetAnswerDeliveryDate(GetStockDiv());
            //    if (!string.IsNullOrEmpty(_answerDeliveryDate.Trim()))
            //    {
            //        return _answerDeliveryDate;
            //    }
            //    // 非在庫品とみなし、処理を続行
            //}

            //// 非在庫品はSCM納期設定マスタより取得
            //_answerDeliveryDate = DeliveryDateSettingDB.FindAnswerDelivDate(
            //    SourceDetailRecord.InqOtherEpCd,
            //    SourceDetailRecord.InqOtherSecCd,
            //    CustomerCode
            //);
            //if (!string.IsNullOrEmpty(_answerDeliveryDate.Trim()))
            //{
            //    #region <Log>

            //    string msg = "回答納期→「無し：非在庫」※SCM納期設定マスタより取得";
            //    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

            //    #endregion // </Log>
            //}
            //return !string.IsNullOrEmpty(_answerDeliveryDate.Trim())
            //    ? _answerDeliveryDate
            //    : GetAnswerDeliveryDate((int)StockDiv.None);

            // ADD 2015/02/18 豊沢 SCM仕掛一覧No10695対応 ---------->>>>>
            // 取得前の設定値を保存
            string answerDeliveryDateTemp = _answerDeliveryDate;
            // ADD 2015/02/18 豊沢 SCM仕掛一覧No10695対応 ----------<<<<<

            _answerDeliveryDate = string.Empty;
            // 在庫区分を取得し、各種フラグを制御
            int stockDiv = GetStockDiv();
            bool stock = ( !stockDiv.Equals((int)StockDiv.None) );
            bool trustStock = ( stockDiv.Equals((int)StockDiv.Trust) );
            bool priorityStock = (stockDiv.Equals((int)StockDiv.PriorityWarehouse)); // ADD 2011/10/11
            // 棚番は委託在庫の時のみ取得
            string shelfNo = ( trustStock ) ? GetShelfNo() : string.Empty;

            // ----- UPD 2011/10/08 ----- >>>>>
            //_answerDeliveryDate = DeliveryDateSettingDB.FindAnswerDelivDate(
            //            SourceDetailRecord.InqOtherEpCd,
            //            SourceDetailRecord.InqOtherSecCd,
            //            CustomerCode,
            //            stock,
            //            trustStock,
            //            shelfNo);

            // ----- UPD 2011/11/21 ----- >>>>>
            //在庫品
            if (stockDiv != 0)
            {
                // UPD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                #region 旧ソース
                //// 2012/08/30 UPD T.Yoshioka 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                //_answerDeliveryDate = DeliveryDateSettingDB.FindAnswerDelivDate2(
                //    SourceDetailRecord.InqOtherEpCd,
                //    SourceDetailRecord.InqOtherSecCd,
                //    CustomerCode,
                //    stock,
                //    trustStock,
                //    priorityStock,
                //    SourceDetailRecord.SalesOrderCount,
                //    GetStockQty());

                //#region 旧ソース
                ////// 発注数 <= 現在庫数 の場合
                ////if (SourceDetailRecord.SalesOrderCount <= GetStockQty())
                ////{
                ////    // ----- UPD 2011/10/11 ----- >>>>>
                ////    //_answerDeliveryDate = DeliveryDateSettingDB.FindAnswerDelivDate(
                ////    //    SourceDetailRecord.InqOtherEpCd,
                ////    //    SourceDetailRecord.InqOtherSecCd,
                ////    //    CustomerCode,
                ////    //    stock,
                ////    //    trustStock,
                ////    //    shelfNo);
                ////    _answerDeliveryDate = DeliveryDateSettingDB.FindAnswerDelivDate(
                ////        SourceDetailRecord.InqOtherEpCd,
                ////        SourceDetailRecord.InqOtherSecCd,
                ////        CustomerCode,
                ////        stock,
                ////        trustStock,
                ////        priorityStock,
                ////        shelfNo);
                ////    // ----- UPD 2011/10/11 ----- <<<<<
                ////}
                //#endregion
                //// 2012/08/30 UPD T.Yoshioka 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<<<
                #endregion 

                _answerDeliveryDate = DeliveryDateSettingDB.FindAnswerDelivDate2(
                    SourceDetailRecord.InqOtherEpCd
                    , SourceDetailRecord.InqOtherSecCd
                    , CustomerCode
                    , stock
                    , trustStock
                    , priorityStock
                    , SourceDetailRecord.SalesOrderCount
                    , GetStockQty()
                    , out ansDeliDateDiv);
                // UPD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            }
            //取寄品
            else
            {
                // UPD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                #region 旧ソース
                //_answerDeliveryDate = DeliveryDateSettingDB.FindAnswerDelivDate(
                //    SourceDetailRecord.InqOtherEpCd,
                //    SourceDetailRecord.InqOtherSecCd,
                //    CustomerCode,
                //    stock,
                //    trustStock,
                //    priorityStock,
                //    shelfNo);
                #endregion
                _answerDeliveryDate = DeliveryDateSettingDB.FindAnswerDelivDate(
                    SourceDetailRecord.InqOtherEpCd
                    , SourceDetailRecord.InqOtherSecCd
                    , CustomerCode
                    , stock
                    , trustStock
                    , priorityStock
                    , shelfNo
                    , out ansDeliDateDiv
                    );

                // UPD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            }
            // ----- UPD 2011/10/08 ----- <<<<<
            // ----- UPD 2011/11/21 ----- >>>>>
            if (!string.IsNullOrEmpty(_answerDeliveryDate.Trim()))
            {
                #region <Log>

                string msg = "回答納期無し";
                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                #endregion // </Log>
            }

            // ADD 2015/02/18 豊沢 SCM仕掛一覧No10695対応 ---------->>>>>
            // 取得済みの区分は元の区分を返却
            if (!answerDeliveryDateTemp.Equals(DateTime.MinValue.ToString(DATE_FORMAT)))
            {
                _answerDeliveryDate = answerDeliveryDateTemp;
            }
            // ADD 2015/02/18 豊沢 SCM仕掛一覧No10695対応 ----------<<<<<

            return _answerDeliveryDate.Trim();
            // 2011/01/11 <<<
        }

        // 2011/01/11 Del >>>
#if False
        /// <summary>
        /// 回答納期を取得します。
        /// </summary>
        /// <returns>
        /// ↓2009/09/03 仕様変更　∴コメントに一部間違いあり
        /// 委託在庫：棚番<br/>
        /// 優先倉庫："在庫有り"<br/>
        /// 自社在庫：倉庫名称<br/>
        /// 非在庫："要確認"<br/>
        /// それ以外：<c>string.Empty</c>
        /// </returns>
        private string GetAnswerDeliveryDate(int stockDiv)
        {
            const string METHOD_NAME = "GetAnswerDeliveryDate(int)";    // ログ用

            const string EXISTS_STOCK = "在庫有り"; // LITERAL;

            switch (stockDiv)
            {
                // 在庫区分.委託在庫    …部品商から整備工場への委託在庫
                case (int)StockDiv.Trust:
                    {
                        #region <Log>

                        string msg = string.Format("回答納期→「部品商：得意先の委託在庫」∵在庫区分={0}", stockDiv);
                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                        #endregion // </Log>

                        return GetShelfNo();
                    }
                // 在庫区分.得意先在庫  …部品商：得意先優先倉庫
                case (int)StockDiv.Customer:
                    {
                        #region <Log>

                        string msg = string.Format("回答納期→「部品商：得意先優先倉庫」∵在庫区分={0}", stockDiv);
                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                        #endregion // </Log>

                        return EXISTS_STOCK;
                    }
                // 在庫区分.非在庫      …無し：非在庫
                case (int)StockDiv.None:
                    {
                        #region <Log>

                        string msg = string.Format("回答納期→「無し：非在庫」∵在庫区分={0}", stockDiv);
                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                        #endregion // </Log>

                        // 2010/03/15 >>>
                        //return "要確認";    // LITERAL:
                        return string.Empty;  // LITERAL:
                        // 2010/03/15 <<<
                    }
                // 在庫区分.優先倉庫 および 在庫区分.自社在庫
                default:
                    {
                        #region <Log>

                        string msg = string.Format(
                            "回答納期を設定中... SelectedWarehouseCode={0}, 拠点={1}, 企業={2}",
                            GetWarehouseCode(),
                            SourceDetailRecord.InqOtherSecCd,
                            SourceDetailRecord.InqOtherEpCd
                        );
                        string moreInfo = string.Empty;

                        #endregion // </Log>

                        // 部品商：自拠点在庫→倉庫マスタ.管理拠点
                        if (!string.IsNullOrEmpty(GetWarehouseCode().Trim()))
                        {
                            Warehouse foundWarehouse = WarehouseDB.Find(RealGoodsUnitData);
                            if (
                                foundWarehouse != null
                                    &&
                                foundWarehouse.SectionCode.Trim().Equals(SourceDetailRecord.InqOtherSecCd.Trim())
                            )
                            {
                                #region <Log>

                                msg += Environment.NewLine + string.Format(
                                    "\t回答納期→「部品商：自拠点在庫」∵倉庫マスタ.管理拠点={0}",
                                    foundWarehouse.SectionCode
                                );
                                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                                #endregion // </Log>

                                return EXISTS_STOCK;
                            }
                            else
                            {
                                #region <Log>

                                moreInfo = string.Format(
                                    "倉庫マスタ.管理拠点=「{0}」",
                                    foundWarehouse != null ? foundWarehouse.SectionCode : "倉庫マスタに登録がありませんでした"
                                );

                                #endregion // </Log>
                            }
                        }

                        // 部品商：他拠点在庫（優先倉庫）→拠点設定.優先倉庫1,2,3
                        if (SecInfoSetDB.ExistsWarehouse(
                            SourceDetailRecord.InqOtherEpCd,
                            SourceDetailRecord.InqOtherSecCd,
                            GetWarehouseCode()
                        ))
                        {
                            #region <Log>

                            msg += Environment.NewLine + "\t回答納期→「部品商：部品商：他拠点在庫（優先倉庫）」※拠点設定.優先倉庫1,2,3";
                            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                            #endregion // </Log>

                            return TrimEndOfAnswerDeliveryDate(GetWarehouseName());
                        }

                        #region <Log>

                        msg += Environment.NewLine + string.Format(
                            "\t回答納期→「無し：非在庫」∵在庫品ですが、優先倉庫の設定に無い他拠点です。({0})",
                            moreInfo
                        );
                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                        #endregion // </Log>

                        return string.Empty;
                    }
            }
        }
#endif
        // 2011/01/11 Del <<<

        /// <summary>回答納期の最大文字数</summary>
        private const int ANSWER_DELIVERY_DATE_LENGTH = 10;

        /// <summary>
        /// 回答納期の値を最大文字数で削ります。
        /// </summary>
        /// <param name="answerDeliveryDate">回答納期の値</param>
        /// <returns>回答納期の値.Substring(0, ANSWER_DELIVERY_DATE_LENGTH)</returns>
        private static string TrimEndOfAnswerDeliveryDate(string answerDeliveryDate)
        {
            if (string.IsNullOrEmpty(answerDeliveryDate)) return string.Empty;

            if (answerDeliveryDate.Length > ANSWER_DELIVERY_DATE_LENGTH)
            {
                return answerDeliveryDate.Substring(0, ANSWER_DELIVERY_DATE_LENGTH);
            }
            return answerDeliveryDate;
        }

        #endregion // <回答納期>

        #region <商品番号>

        /// <summary>
        /// 商品番号を取得します。
        /// </summary>
        /// <returns>商品番号</returns>
        public string GetGoodsNo()
        {
            if (HasMarketPrice)
            {
                return RealGoodsUnitData.GoodsNo;   // TODO:相場回答は"*"かも？
            }
            return RealGoodsUnitData.GoodsNo;
        }

        /// <summary>
        /// 回答純正商品番号を取得します。
        /// </summary>
        /// <returns>回答純正商品番号</returns>
        public string GetAnsPureGoodsNo()
        {
            return GetGoodsNo();
        }

        #endregion // </商品番号>

        #region <棚番>

        /// <summary>
        /// 棚番を取得します。（取得条件として得意先コードを含みます）
        /// </summary>
        /// <returns>棚番</returns>
        public string GetShelfNo()
        {
            string foundWarehouseCode = GetWarehouseCode();

            if (string.IsNullOrEmpty(foundWarehouseCode)) return string.Empty;

            //>>>2012/03/28
            //GoodsAcs goodsAccesser = new GoodsAcs(SourceDetailRecord.InqOtherSecCd);
            //{
            //    string msg = string.Empty;
            //    goodsAccesser.SearchInitial(SourceDetailRecord.InqOtherEpCd, SourceDetailRecord.InqOtherSecCd, out msg);
            //}
            //Stock foundStock = goodsAccesser.GetStockFromStockList(
            //    foundWarehouseCode,
            //    RealGoodsUnitData.GoodsMakerCd,
            //    RealGoodsUnitData.GoodsNo,
            //    RealGoodsUnitData.StockList
            //);

            Stock foundStock = this.GetStockFromStockList(
                foundWarehouseCode,
                RealGoodsUnitData.GoodsMakerCd,
                RealGoodsUnitData.GoodsNo,
                RealGoodsUnitData.StockList
            );
            //<<<2012/03/28

            string shelfNo = (foundStock != null ? foundStock.WarehouseShelfNo : string.Empty);
            return !string.IsNullOrEmpty(shelfNo.Trim()) ? shelfNo : "棚番無し";    // LITERAL:
        }

        //>>>2012/03/28
        /// <summary>
        /// 指定条件該当在庫情報データオブジェクト取得処理
        /// </summary>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="stockList">在庫データオブジェクトリスト</param>
        /// <returns>在庫データオブジェクト</returns>
        public Stock GetStockFromStockList(string warehouseCode, int goodsMakerCd, string goodsNo, List<Stock> stockList)
        {
            Stock retStock = null;
            foreach (Stock stock in stockList)
            {
                if ((stock.WarehouseCode.Trim() == warehouseCode.Trim()) &&
                    (stock.GoodsMakerCd == goodsMakerCd) &&
                    (stock.GoodsNo == goodsNo))
                {
                    retStock = stock;
                }
            }
            return retStock;
        }
        //<<<2012/03/28
        #endregion // </棚番>

        #region <価格>

        /// <summary>
        /// 定価を取得します。
        /// </summary>
        /// <returns>定価</returns>
        public long GetListPrice()
        {
            // 相場価格
            if (HasMarketPrice)
            {
                return SCMSobaResponseList[0].GetMarketPrice();
            }

            // ----- ADD 2011/08/10 ----- >>>>>
            // SCMの場合
            if (this._acceptOrOrderKind == (int)EnumAcceptOrOrderKind.SCM)
            {
            // ----- ADD 2011/08/10 ----- <<<<<
                // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
                //// SCM品目設定が「価格」の場合、値を返す
                //if (CanReplyPrice)
                //{
                // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<
                    // --- ADD 三戸 2012/06/18 №10289 ---------->>>>>
                    if (this.RealGoodsUnitData.SelectedListPrice > 0)
                    {
                        return (long)this.RealGoodsUnitData.SelectedListPrice;
                    }
                    // --- ADD 三戸 2012/06/18 №10289 ----------<<<<<

                    UnitPriceCalcRet listPriceResult = CalculatorAgent.GetListPriceResult(UnitPriceCalcRetList);
                    if (listPriceResult != null)
                    {
                        return (long)listPriceResult.UnitPriceTaxExcFl; // 定価は単価(税抜, 浮動)
                    }
                // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
                //}
                // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<
            // ----- ADD 2011/08/10 ----- >>>>>
            }
            // PCCUOEの場合
            else
            {
                //>>>2012/02/12
                //UnitPriceCalcRet listPriceResult = CalculatorAgent.GetListPriceResult(UnitPriceCalcRetList);
                //if (listPriceResult != null)
                //{
                //    return (long)listPriceResult.UnitPriceTaxExcFl; // 定価は単価(税抜, 浮動)
                //}

                // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
                //// SCM品目設定が「価格」の場合、値を返す
                //if (CanReplyPrice)
                //{
                // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<
                    UnitPriceCalcRet listPriceResult = CalculatorAgent.GetListPriceResult(UnitPriceCalcRetList);
                    if (listPriceResult != null)
                    {
                        return (long)listPriceResult.UnitPriceTaxExcFl; // 定価は単価(税抜, 浮動)
                    }
                // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
                //}
                // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<
                //<<<2012/02/12
            }
            // ----- ADD 2011/08/10 ----- <<<<<
            return 0;
        }

        /// <summary>
        /// セット子を含むか判断します。
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>
        /// <c>true</c> :セット子を含みます。<br/>
        /// <c>false</c>:セット子を含みません。
        /// </returns>
        protected static bool ContainsSetChildAtGoodsKind(GoodsUnitData goodsUnitData)
        {
            IList<int> splitedGoodsKind = SplitGoodsKind(goodsUnitData);
            {
                foreach (int goodsKind in splitedGoodsKind)
                {
                    // 4:セット子
                    if (goodsKind.Equals(4)) return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 商品種別(複数あり)を1, 2, 4, 8, 16 の構成に分解します。
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>
        /// 1, 2, 4, 8, 16 のうち、構成される数値のリスト
        /// </returns>
        protected static IList<int> SplitGoodsKind(GoodsUnitData goodsUnitData)
        {
            int number = goodsUnitData.GoodsKind;

            IList<int> splitedNumber = new List<int>();
            {
                int surplus = number;

                surplus %= 16;  // 代替互換
                if (!surplus.Equals(number))
                {
                    splitedNumber.Add(16);
                }

                number = surplus;
                surplus %= 8;   // 代替
                if (!surplus.Equals(number))
                {
                    splitedNumber.Add(8);
                }

                number = surplus;
                surplus %= 4;   // セット子
                if (!surplus.Equals(number))
                {
                    splitedNumber.Add(4);
                }

                number = surplus;
                surplus %= 2;   // 結合子
                if (!surplus.Equals(number))
                {
                    splitedNumber.Add(2);
                }

                // 親
                if (surplus.Equals(1))
                {
                    splitedNumber.Add(1);
                }
            }
            return splitedNumber;
        }
        /// <summary>
        /// 単価を取得します。
        /// </summary>
        /// <returns>単価</returns>
        public long GetUnitPrice()
        {
            // 相場価格
            if (HasMarketPrice)
            {
                return SCMSobaResponseList[0].GetMarketPrice();
            }

            // --- DEL 2014/11/05 Y.Wakita ---------->>>>>
            #region 削除
            //// ----- ADD 2011/08/10 ----- >>>>>
            //// SCMの場合
            //if (this._acceptOrOrderKind == (int)EnumAcceptOrOrderKind.SCM)
            //{
            //    // ----- ADD 2011/08/10 ----- <<<<<
            //    // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
            //    //// SCM品目設定が「価格」の場合、値を返す
            //    //if (CanReplyPrice)
            //    //{
            //    // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<
            //        UnitPriceCalcRet sellingPriceResult = CalculatorAgent.GetSellingPriceResult(UnitPriceCalcRetList);
            //        if (sellingPriceResult != null)
            //        {
            //            return (long)sellingPriceResult.UnitPriceTaxExcFl;  // 単価は単価(税抜, 浮動)
            //        }
            //        else
            //        {
            //            // 売価未設定区分が「1:定価表示」の場合、定価を使用
            //            if (SalesTtlStDB.UsesListPriceIfSalesPriceIsNone(
            //                SourceDetailRecord.InqOtherEpCd,
            //                SourceDetailRecord.InqOtherSecCd
            //            ))
            //            {
            //                return GetListPrice();
            //            }
            //            return 0;
            //        }
            //    // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
            //    //}
            //    // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<
            //// ----- ADD 2011/08/10 ----- >>>>>
            //}
            //// PCCUOEの場合
            //else
            //{
            #endregion
            // --- DEL 2014/11/05 Y.Wakita ----------<<<<<
                //>>>2012/02/12
                #region 削除
                //// ----- ADD 2011/10/11 ----- >>>>>
                //long _unitPrice = 0;
                //long _listPrice = 0;
                //UnitPriceCalcRet sellingPriceResult = CalculatorAgent.GetSellingPriceResult(UnitPriceCalcRetList);
                //if (sellingPriceResult != null)
                //{
                //    _unitPrice = (long)sellingPriceResult.UnitPriceTaxExcFl;  // 単価は単価(税抜, 浮動)
                //}
                //else
                //{
                //    // 売価未設定区分が「1:定価表示」の場合、定価を使用
                //    if (SalesTtlStDB.UsesListPriceIfSalesPriceIsNone(
                //        SourceDetailRecord.InqOtherEpCd,
                //        SourceDetailRecord.InqOtherSecCd
                //    ))
                //    {
                //        _unitPrice = GetListPrice();
                //    }
                //}
                //// 問合せの場合及び商品連結データの商品種別(複数あり)がセット子の場合(売上データ作成しないの場合)
                //// 自動連携値引きとキャンペーンを反映
                //if (_sourceDetailRecord.InqOrdDivCd == (int)InqOrdDivCd.Inquiry && ContainsSetChildAtGoodsKind(_realGoodsUnitData))
                //{
                //    UnitPriceCalcRet listPriceResult = CalculatorAgent.GetListPriceResult(UnitPriceCalcRetList);
                //    if (listPriceResult != null)
                //    {
                //        _listPrice = (long)listPriceResult.UnitPriceTaxExcFl;
                //    }
                //    //売上明細データ
                //    SalesDetail salesDetail = new SalesDetail();
                //    salesDetail.TaxationDivCd = _realGoodsUnitData.TaxationDivCd;     //課税区分
                //    salesDetail.BfSalesUnitPrice = _unitPrice;                        //変更前売価
                //    salesDetail.ListPriceTaxExcFl = _listPrice;                       //定価（税抜，浮動）
                //    if (_campaignInformation != null)   
                //    {
                //        salesDetail.CampaignCode = _campaignInformation.CampaignCode; //キャンペーンコード
                //    }
                //    salesDetail.EnterpriseCode = _realGoodsUnitData.EnterpriseCode;
                //    salesDetail.SectionCode = _realGoodsUnitData.SectionCode;
                //    salesDetail.GoodsMGroup = _realGoodsUnitData.GoodsMGroup;         //商品中分類コード
                //    salesDetail.BLGoodsCode = _realGoodsUnitData.BLGoodsCode;         //BLグループコード
                //    salesDetail.GoodsMakerCd = _realGoodsUnitData.GoodsMakerCd;       //商品メーカーコード
                //    salesDetail.GoodsNo = _realGoodsUnitData.GoodsNo;                 //商品番号
                //    salesDetail.SalesCode = _realGoodsUnitData.SalesCode;             //販売区分コード
                //    //売上データ
                //    SalesSlip salesSlip = new SalesSlip();
                //    if (_sourceDetailRecord != null)
                //    {
                //        salesSlip.SalesDate = _sourceDetailRecord.UpdateDate;         //問合せ日
                //    }
                //    salesSlip.TotalAmountDispWayCd = 0;                               //総額表示方法区分
                //    salesSlip.CustomerCode = _customerCode;
                //    salesSlip.EnterpriseCode = _realGoodsUnitData.EnterpriseCode;
                //    // 自動連携値引きとキャンペーンを反映
                //    SCMPriceCalculator priceCalculator = new SCMPriceCalculator();
                //    {
                //        priceCalculator.SetCurrentSCMOrderData(_customerCode, salesDetail);
                //        PriceValue priceValue = priceCalculator.CalcTaxExcAndTaxInc(salesDetail, salesSlip);
                //        return (long)priceValue.TaxExc;
                //    }
                
                //}
                //else
                //{
                //    return _unitPrice;
                //}

                //// ----- ADD 2011/10/11 ----- <<<<<
                #endregion

                // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
                // SCM品目設定が「価格」の場合、値を返す
                //if (CanReplyPrice)
                //{
                // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<
                    // ----- ADD 2011/10/11 ----- >>>>>
                    long _unitPrice = 0;
                    long _listPrice = 0;
                    UnitPriceCalcRet sellingPriceResult = CalculatorAgent.GetSellingPriceResult(UnitPriceCalcRetList);
                    if (sellingPriceResult != null)
                    {
                        _unitPrice = (long)sellingPriceResult.UnitPriceTaxExcFl;  // 単価は単価(税抜, 浮動)
                    }
                    else
                    {
                        // 売価未設定区分が「1:定価表示」の場合、定価を使用
                        if (SalesTtlStDB.UsesListPriceIfSalesPriceIsNone(
                            SourceDetailRecord.InqOtherEpCd,
                            SourceDetailRecord.InqOtherSecCd
                        ))
                        {
                            _unitPrice = GetListPrice();
                        }
                    }
                    // 問合せの場合及び商品連結データの商品種別(複数あり)がセット子の場合(売上データ作成しないの場合)
                    // 自動連携値引きとキャンペーンを反映
                    if (_sourceDetailRecord.InqOrdDivCd == (int)InqOrdDivCd.Inquiry && ContainsSetChildAtGoodsKind(_realGoodsUnitData))
                    {
                        UnitPriceCalcRet listPriceResult = CalculatorAgent.GetListPriceResult(UnitPriceCalcRetList);
                        if (listPriceResult != null)
                        {
                            _listPrice = (long)listPriceResult.UnitPriceTaxExcFl;
                        }
                        //売上明細データ
                        SalesDetail salesDetail = new SalesDetail();
                        salesDetail.TaxationDivCd = _realGoodsUnitData.TaxationDivCd;     //課税区分
                        salesDetail.BfSalesUnitPrice = _unitPrice;                        //変更前売価
                        salesDetail.ListPriceTaxExcFl = _listPrice;                       //定価（税抜，浮動）
                        // ADD 2013/02/28 T.Yoshioka 2013/03/06配信予定 リリース前検証サポ推管№92 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        salesDetail.SalesUnPrcTaxExcFl = _unitPrice;
                        // ADD 2013/02/28 T.Yoshioka 2013/03/06配信予定 リリース前検証サポ推管№92 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                        if (_campaignInformation != null)
                        {
                            salesDetail.CampaignCode = _campaignInformation.CampaignCode; //キャンペーンコード
                        }
                        salesDetail.EnterpriseCode = _realGoodsUnitData.EnterpriseCode;
                        salesDetail.SectionCode = _realGoodsUnitData.SectionCode;
                        salesDetail.GoodsMGroup = _realGoodsUnitData.GoodsMGroup;         //商品中分類コード
                        salesDetail.BLGoodsCode = _realGoodsUnitData.BLGoodsCode;         //BLグループコード
                        salesDetail.GoodsMakerCd = _realGoodsUnitData.GoodsMakerCd;       //商品メーカーコード
                        salesDetail.GoodsNo = _realGoodsUnitData.GoodsNo;                 //商品番号
                        salesDetail.SalesCode = _realGoodsUnitData.SalesCode;             //販売区分コード
                        //売上データ
                        SalesSlip salesSlip = new SalesSlip();
                        if (_sourceDetailRecord != null)
                        {
                            salesSlip.SalesDate = _sourceDetailRecord.UpdateDate;         //問合せ日
                        }
                        salesSlip.TotalAmountDispWayCd = 0;                               //総額表示方法区分
                        salesSlip.CustomerCode = _customerCode;
                        salesSlip.EnterpriseCode = _realGoodsUnitData.EnterpriseCode;
                        // 自動連携値引きとキャンペーンを反映
                        SCMPriceCalculator priceCalculator = new SCMPriceCalculator();
                        {
                            // UPD 2014/01/30 Redmine#41771-障害№13対応 ------------------------------------------------------>>>>>
                            //priceCalculator.SetCurrentSCMOrderData(_customerCode, salesDetail);
                            priceCalculator.SetCurrentSCMOrderData(_customerCode, salesDetail,
                                (SourceDetailRecord.CancelCndtinDiv != 0) ? (short)1 : (short)0,
                                SourceDetailRecord.UpdateDate);
                            // UPD 2014/01/30 Redmine#41771-障害№13対応 ------------------------------------------------------<<<<<
                            PriceValue priceValue = priceCalculator.CalcTaxExcAndTaxInc(salesDetail, salesSlip);
                            return (long)priceValue.TaxExc;
                        }

                    }
                    else
                    {
                        return _unitPrice;
                    }
                    // ----- ADD 2011/10/11 ----- <<<<<
                // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
                //}
                //else
                //{
                //    return 0;
                //}
                // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<
                //<<<2012/02/12
            // --- DEL 2014/11/05 Y.Wakita ---------->>>>>
            //}
            // --- DEL 2014/11/05 Y.Wakita ----------<<<<<
            // ----- ADD 2011/08/10 ----- <<<<<
            return -1;  // TODO:SCM品目設定で価格設定しない印
        }

        #endregion // </価格>

        #region <粗利>

        /// <summary>
        /// 粗利額を取得します。
        /// </summary>
        /// <returns>売価 - 原価</returns>
        public long GetRoughRrofit()
        {
            // UPD 2013/11/19 201312xx配信予定ｼｽﾃﾑﾃｽﾄ障害№22対応 ----------------------->>>>>
            //return CalculatorAgent.GetRoughProfit(UnitPriceCalcRetList);
            bool salesPriceIsNone = SalesTtlStDB.UsesListPriceIfSalesPriceIsNone(this.RealGoodsUnitData.EnterpriseCode, this.RealGoodsUnitData.SectionCode);
            return CalculatorAgent.GetRoughProfit(UnitPriceCalcRetList, salesPriceIsNone);
            // UPD 2013/11/19 201312xx配信予定ｼｽﾃﾑﾃｽﾄ障害№22対応 -----------------------<<<<<
        }

        /// <summary>
        /// 粗利率を取得します。
        /// </summary>
        /// <remarks>小数点第3位を四捨五入</remarks>
        /// <returns>(売価 - 原価) / 売価 * 100.0</returns>
        public double GetRoughRate()
        {
            // UPD 2013/11/19 201312xx配信予定ｼｽﾃﾑﾃｽﾄ障害№22対応 ----------------------->>>>>
            //double roughRate = CalculatorAgent.GetRoughRate(UnitPriceCalcRetList);
            bool salesPriceIsNone = SalesTtlStDB.UsesListPriceIfSalesPriceIsNone(this.RealGoodsUnitData.EnterpriseCode, this.RealGoodsUnitData.SectionCode);
            double roughRate = CalculatorAgent.GetRoughRate(UnitPriceCalcRetList, salesPriceIsNone);
            // UPD 2013/11/19 201312xx配信予定ｼｽﾃﾑﾃｽﾄ障害№22対応 -----------------------<<<<<
            return CalculatorAgent.RoundOff(roughRate, 3);
        }

        #endregion // </粗利>

        #region <コレクション用ヘルパメソッド>

        /// <summary>
        /// 粗利率の最も高いSCM情報付商品連結データを検索します。
        /// </summary>
        /// <param name="scmGoodsUitDataList">SCM情報付商品連結データのリスト</param>
        /// <returns>粗利率の最も高いSCM情報付商品連結データのリスト</returns>
        public static IList<SCMGoodsUnitData> FindHighestRoughRate(IList<SCMGoodsUnitData> scmGoodsUitDataList)
        {
            #region <Guard Phrase>

            if (scmGoodsUitDataList == null || scmGoodsUitDataList.Count.Equals(0)) return scmGoodsUitDataList;

            #endregion // </Guard Phrase>

            if (scmGoodsUitDataList.Count.Equals(1)) return scmGoodsUitDataList;

            IList<SCMGoodsUnitData> foundList = new List<SCMGoodsUnitData>();
            {
                double currentRoughRate = scmGoodsUitDataList[0].GetRoughRate();
                foreach (SCMGoodsUnitData scmGoodsUnitData in scmGoodsUitDataList)
                {
                    double roughRate = scmGoodsUnitData.GetRoughRate();
                    if (roughRate > currentRoughRate)
                    {
                        foundList.Clear();
                        foundList.Add(scmGoodsUnitData);
                        currentRoughRate = roughRate;
                    }
                    else if (roughRate.Equals(currentRoughRate))
                    {
                        foundList.Add(scmGoodsUnitData);
                    }
                }
            }
            return foundList.Count.Equals(0) ? scmGoodsUitDataList : foundList;
        }

        /// <summary>
        /// 単価の最も高いSCM情報付商品連結データを検索します。
        /// </summary>
        /// <param name="scmGoodsUitDataList">SCM情報付商品連結データのリスト</param>
        /// <returns>単価の最も高いSCM情報付商品連結データのリスト</returns>
        public static IList<SCMGoodsUnitData> FindHighestUnitPrice(IList<SCMGoodsUnitData> scmGoodsUitDataList)
        {
            #region <Guard Phrase>

            if (scmGoodsUitDataList == null || scmGoodsUitDataList.Count.Equals(0)) return scmGoodsUitDataList;

            #endregion // </Guard Phrase>

            if (scmGoodsUitDataList.Count.Equals(1)) return scmGoodsUitDataList;

            IList<SCMGoodsUnitData> foundList = new List<SCMGoodsUnitData>();
            {
                long currentUnitPrice = scmGoodsUitDataList[0].GetUnitPrice();
                foreach (SCMGoodsUnitData scmGoodsUnitData in scmGoodsUitDataList)
                {
                    long unitPrice = scmGoodsUnitData.GetUnitPrice();
                    if (unitPrice > currentUnitPrice)
                    {
                        foundList.Clear();
                        foundList.Add(scmGoodsUnitData);
                        currentUnitPrice = unitPrice;
                    }
                    else if (unitPrice.Equals(currentUnitPrice))
                    {
                        foundList.Add(scmGoodsUnitData);
                    }
                }
            }
            return foundList.Count.Equals(0) ? scmGoodsUitDataList : foundList;
        }

        /// <summary>
        /// 定価の最も高いSCM情報付商品連結データを検索します。
        /// </summary>
        /// <param name="scmGoodsUitDataList">SCM情報付商品連結データのリスト</param>
        /// <returns>定価の最も高いSCM情報付商品連結データのリスト</returns>
        public static IList<SCMGoodsUnitData> FindHighestListPrice(IList<SCMGoodsUnitData> scmGoodsUitDataList)
        {
            #region <Guard Phrase>

            if (scmGoodsUitDataList == null || scmGoodsUitDataList.Count.Equals(0)) return scmGoodsUitDataList;

            #endregion // </Guard Phrase>

            if (scmGoodsUitDataList.Count.Equals(1)) return scmGoodsUitDataList;

            IList<SCMGoodsUnitData> foundList = new List<SCMGoodsUnitData>();
            {
                long currentListPrice = scmGoodsUitDataList[0].GetListPrice();
                foreach (SCMGoodsUnitData scmGoodsUnitData in scmGoodsUitDataList)
                {
                    long listPrice = scmGoodsUnitData.GetListPrice();
                    if (listPrice > currentListPrice)
                    {
                        foundList.Clear();
                        foundList.Add(scmGoodsUnitData);
                        currentListPrice = listPrice;
                    }
                    else if (listPrice.Equals(currentListPrice))
                    {
                        foundList.Add(scmGoodsUnitData);
                    }
                }
            }
            return foundList.Count.Equals(0) ? scmGoodsUitDataList : foundList;
        }

        /// <summary>
        /// 定価の最も低いSCM情報付商品連結データを検索します。
        /// </summary>
        /// <param name="scmGoodsUitDataList">SCM情報付商品連結データのリスト</param>
        /// <returns>定価の最も低いSCM情報付商品連結データのリスト</returns>
        public static IList<SCMGoodsUnitData> FindLowestListPrice(IList<SCMGoodsUnitData> scmGoodsUitDataList)
        {
            #region <Guard Phrase>

            if (scmGoodsUitDataList == null || scmGoodsUitDataList.Count.Equals(0)) return scmGoodsUitDataList;

            #endregion // </Guard Phrase>

            if (scmGoodsUitDataList.Count.Equals(1)) return scmGoodsUitDataList;

            IList<SCMGoodsUnitData> foundList = new List<SCMGoodsUnitData>();
            {
                long currentListPrice = scmGoodsUitDataList[0].GetListPrice();
                foreach (SCMGoodsUnitData scmGoodsUnitData in scmGoodsUitDataList)
                {
                    long listPrice = scmGoodsUnitData.GetListPrice();
                    if (listPrice < currentListPrice)
                    {
                        foundList.Clear();
                        foundList.Add(scmGoodsUnitData);
                        currentListPrice = listPrice;
                    }
                    else if (listPrice.Equals(currentListPrice))
                    {
                        foundList.Add(scmGoodsUnitData);
                    }
                }
            }
            return foundList.Count.Equals(0) ? scmGoodsUitDataList : foundList;
        }

        #endregion // </コレクション用ヘルパメソッド>

        // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
        /// <summary>
        /// 倉庫情報を取得します。
        /// </summary>
        /// <param name="paramGoodsUnitData">商品連結データ</param>
        /// <returns>倉庫情報</returns>
        public Warehouse GetWarehouseInfo(GoodsUnitData paramGoodsUnitData)
        {
            return WarehouseDB.Find(paramGoodsUnitData);
        }
        // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<

        // ADD 2014/07/23 Redmine#43080の3SCM受発注明細データに在庫状況区分のセット----------------------->>>>>
        /// <summary>
        /// 在庫マスタ情報取得
        /// </summary>
        /// <returns>在庫マスタ情報</returns>
        /// <remarks>
        /// <br>Note		: 在庫状況区分取得します。</br>
        /// <br>Programmer	: 鄧潘ハン</br>
        /// <br>Date		: 2014/07/23</br>
        /// </remarks>
        public Stock GetStock()
        {
            List<Stock> tempStockList = RealGoodsUnitData.StockList;
            if (!ListUtil.IsNullOrEmpty(tempStockList))
            {
                for (int i = 0; i < tempStockList.Count; i++)
                {
                    Stock tempStock = tempStockList[i];
                    if (RealGoodsUnitData.SelectedWarehouseCode != null && tempStock.WarehouseCode == RealGoodsUnitData.SelectedWarehouseCode.Trim())
                    {
                        return tempStock;
                    }
                }
                return tempStockList[0];
            }
            else
                return null;

        }
        // ADD 2014/07/23 Redmine#43080の3SCM受発注明細データに在庫状況区分のセット-----------------------<<<<<
    }
}

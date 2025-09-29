//****************************************************************************//
// システム         : 提供データ更新処理
// プログラム名称   : 機能追加に伴う追加クラス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/02/03  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 長内 数馬
// 作 成 日  2012/02/08  修正内容 : 外装オプションの判定方法の不具合を修正
//----------------------------------------------------------------------------//
//#define _VERSION_CHECK_IS_FALSE_

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller.Util
{
    using UserUpdatingPrimeSettingPair = Pair<ArrayList, ArrayList>;

    #region <処理結果/>

    /// <summary>
    /// 処理結果クラス
    /// </summary>
    public static class Result
    {
        // TODO:共通の定数に値を合わせること
        /// <summary>
        /// リモートの処理結果の列挙体
        /// </summary>
        public enum RemoteStatus : int
        {
            /// <summary>正常終了</summary>
            Normal = 0,
            /// <summary>件数0</summary>
            NotFound = 4
        }

        /// <summary>
        /// 処理結果コード列挙体
        /// </summary>
        public enum Code : int
        {
            /// <summary>正常</summary>
            Normal = (int)RemoteStatus.Normal
        }
    }

    #endregion  // <処理結果/>

    #region <マージチェック/>

    /// <summary>
    /// マージのチェック者クラス
    /// </summary>
    public sealed class MergeChecker
    {
        #region <Const/>

        /// <summary>
        /// 対象データの列挙体
        /// </summary>
        public enum TargetData : int
        {
            /// <summary>BLコードマスタ</summary>
            BLCodeMaster,
            /// <summary>BLグループマスタ</summary>
            BLGroupMaster,
            /// <summary>中分類マスタ</summary>
            MiddleGenreMaster,
            /// <summary>車種マスタ</summary>
            CarTypeMaster,
            /// <summary>メーカーマスタ</summary>
            MakerMaster,
            /// <summary>部位マスタ</summary>
            PartsPOSCodeMaster,
            /// <summary>価格改正</summary>
            PriceRevision
        }

        #endregion  // <Const/>

        #region <現在のバージョン/>

        /// <summary>現在のバージョン</summary>
        private string _currentVersion;
        /// <summary>
        /// 現在のバージョンを取得します。
        /// </summary>
        public string CurrentVersion { get { return _currentVersion; } }

        #endregion  // <現在のバージョン/>

        #region <Constructor/>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public MergeChecker() { }

        #endregion  // <Constructor/>

        /// <summary>
        /// マージ済みか判定します。
        /// </summary>
        /// <returns>
        /// <c>true</c> :マージ済み<br/>
        /// <c>false</c>:マージ済みではない
        /// </returns>
        public bool IsMerged()
        {
            string msg = string.Empty;
            return IsMerged(out msg);
        }

        /// <summary>
        /// マージ済みか判定します。
        /// </summary>
        /// <param name="msg">実行結果のメッセージ</param>
        /// <returns>
        /// <c>true</c> :マージ済み<br/>
        /// <c>false</c>:マージ済みではない
        /// </returns>
        public bool IsMerged(out string msg)
        {
            msg = string.Empty;
        #if _VERSION_CHECK_IS_FALSE_
            msg = "マージが必要です";
            return false;
        #else
            // バージョンチェックリモートの呼び出し（マージチェックメソッド）
            VersionCheckAcs realChecker = new VersionCheckAcs();
            {
                int mergeCheckResult = 0;
                int status = realChecker.MergeCheck(out mergeCheckResult, out _currentVersion);

                //mergeCheckResult = 2;
                if (status.Equals((int)Result.RemoteStatus.Normal))
                {
                    switch (mergeCheckResult)
                    {
                        case 0: msg = "マージ済み";     break;
                        case 1: msg = "価格改正処理中"; break;
                        case 2: msg = "価格改正未実行"; break;
                    }
                    if (mergeCheckResult == 0)
                        return mergeCheckResult.Equals(0);   // 0:正常/1:処理中/2:未実行
                    else
                        return mergeCheckResult.Equals(1);
                }
                msg = "リモートエラー(status=" + status.ToString() + ")";
            }

            // -- UPD 2010/06/19 --------------------------->>>
            //リモートエラーの場合は処理させないようにするため、Trueとする
            //return false;
            return true;  
            // -- UPD 2010/06/19 ---------------------------<<<
#endif
        }

        /// <summary>
        /// バージョンを更新します。
        /// </summary>
        /// <returns>リモートの結果コード</returns>
        public int UpdateVersion()
        {
            VersionCheckAcs realChecker = new VersionCheckAcs();
            {
                return realChecker.UpdateVersion(ref _currentVersion);
            }
        }

        /// <summary>
        /// <c>ArrayList</c>が<c>null</c>または空か判定します。
        /// </summary>
        /// <param name="arrayList"><c>ArrayList</c>を継承したリスト</param>
        /// <returns>
        /// <c>true</c> :<c>null</c>または空である。<br/>
        /// <c>false</c>:要素あり
        /// </returns>
        public static bool IsNullOrEmptyArrayList(ArrayList arrayList)
        {
            return arrayList == null || arrayList.Count.Equals(0);
        }
    }

    #endregion  // <マージチェック/>

    #region <コンフィグ/>

    /// <summary>
    /// 処理構成の項目クラス
    /// </summary>
    public sealed class ProcessConfigItem
    {
        #region <選択/>

        /// <summary>選択</summary>
        private bool _selected;
        /// <summary>
        /// 選択のアクセサ
        /// </summary>
        /// <value>選択</value>
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        #endregion  // <選択/>

        #region <処理ID（対象データID）/>

        /// <summary>処理ID（対象データID）</summary>
        private string _processId;
        /// <summary>
        /// 処理ID（対象データID）のアクセサ
        /// </summary>
        /// <value>処理ID（対象データID）</value>
        public string ProcessId
        {
            get { return _processId; }
            set { _processId = value; }
        }

        #endregion  // <処理ID（対象データID）/>

        #region <処理名称（対象データ名）/>）

        /// <summary>処理名称（対象データ名）</summary>
        private string _processName;
        /// <summary>
        /// 処理名称（対象データ名）のアクセサ
        /// </summary>
        /// <value>処理名称（対象データ名）</value>
        public string ProcessName
        {
            get { return _processName; }
            set { _processName = value; }
        }

        #endregion  // <処理ID（対象データID）/>

        #region <名称を更新するフラグ/>

        /// <summary>名称を更新するフラグ</summary>
        private bool _updatingName;
        /// <summary>
        /// 名称を更新するフラグのアクセサ
        /// </summary>
        /// <value>名称を更新するフラグ</value>
        public bool UpdatingName
        {
            get { return _updatingName; }
            set { _updatingName = value; }
        }

        #endregion  // <名称を更新するフラグ/>

        #region <前回処理日/>

        /// <summary>前回処理日</summary>
        private DateTime _previousDate;
        /// <summary>
        /// 前回処理日のアクセサ
        /// </summary>
        /// <value>前回処理日</value>
        public DateTime PreviousDate
        {
            get { return _previousDate; }
            set { _previousDate = value; }
        }

        /// <summary>
        /// 前回処理日を数値表現に変換します。
        /// </summary>
        /// <returns>数値表現に変換された前回処理日</returns>
        public int ToPreviousDateNo()
        {
            return int.Parse(PreviousDate.ToString("yyyyMMdd"));
        }

        #endregion  // <前回処理日/>

        #region <更新件数/>

        /// <summary>更新件数</summary>
        private int _previousCount;
        /// <summary>
        /// 更新件数のアクセサ
        /// </summary>
        /// <value>更新件数</value>
        public int PreviousCount
        {
            get { return _previousCount; }
            set { _previousCount = value; }
        }

        #endregion  // <更新件数/>

        #region <対象件数/>

        /// <summary>対象件数</summary>
        private int _presentCount;
        /// <summary>
        /// 対象件数のアクセサ
        /// </summary>
        /// <value>対象件数</value>
        public int PresentCount
        {
            get { return _presentCount; }
            set { _presentCount = value; }
        }

        #endregion  // <対象件数/>

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="selected">選択</param>
        /// <param name="processId">処理ID（対象データID）</param>
        /// <param name="processName">処理名称（対象データ名称）</param>
        /// <param name="updatingName">名称を更新するフラグ</param>
        /// <param name="previousDate">前回処理日</param>
        /// <param name="previousCount">更新件数</param>
        /// <param name="presentCount">対象件数</param>
        public ProcessConfigItem(
            bool selected,
            string processId,
            string processName,
            bool updatingName,
            DateTime previousDate,
            int previousCount,
            int presentCount
        )
        {
            _selected       = selected;
            _processId      = processId;
            _processName    = processName;
            _updatingName   = updatingName;
            _previousDate   = previousDate;
            _previousCount  = previousCount;
            _presentCount   = presentCount;
        }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="processId">処理ID（対象データID）</param>
        /// <param name="processName">処理名称（対象データ名称）</param>
        public ProcessConfigItem(
            string processId,
            string processName
        )  : this(false, processId, processName, false, DateTime.MinValue, 0, 0)
        { }

        #endregion  // <Constructor/>

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prevUpdDate"></param>
        /// <returns></returns>
        public static DateTime ConvertPreviousDate(string prevUpdDate)
        {
            if (string.IsNullOrEmpty(prevUpdDate.Trim()))
            {
                return DateTime.MinValue;
            }
            return DateTime.Parse(prevUpdDate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowCnt"></param>
        /// <returns></returns>
        public static int ConvertPreviousCount(string rowCnt)
        {
            if (string.IsNullOrEmpty(rowCnt.Trim()))
            {
                return 0;
            }
            return int.Parse(rowCnt);
        }
    }

    /// <summary>
    /// 処理構成クラス
    /// </summary>
    public sealed class ProcessConfig
    {
        #region <構成項目のコレクション/>

        /// <summary>構成項目のマップ</summary>
        /// <remarks>キー：処理ID</remarks>
        private readonly IDictionary<string, ProcessConfigItem> _itemMap = new Dictionary<string, ProcessConfigItem>();
        /// <summary>
        /// 構成項目のマップを取得します。
        /// </summary>
        /// <value>構成項目のマップ</value>
        private IDictionary<string, ProcessConfigItem> ItemMap { get { return _itemMap; } }

        #endregion  // <構成項目のコレクション/>

        #region <BLコードマスタ/>

        /// <summary>BLコードマスタのID</summary>
        public const string BL_CODE_MASTER_ID = "BLGOODSCDURF";
        /// <summary>BLコードマスタの名称</summary>
        public const string BL_CODE_MASTER_NAME = "BLコードマスタ";

        /// <summary>
        /// BLコードマスタの処理構成の項目を取得します。
        /// </summary>
        /// <returns>BLコードマスタの処理構成の項目</returns>
        public ProcessConfigItem BLCodeMaster
        {
            get
            {
                ProcessConfigItem item = this[BL_CODE_MASTER_ID];
                if (item != null) return item;
                return new ProcessConfigItem(BL_CODE_MASTER_ID, BL_CODE_MASTER_NAME);
            }
        }

        #endregion  // <BLコードマスタ/>

        #region <BLグループマスタ/>

        /// <summary>BLグループマスタのID</summary>
        public const string BL_GROUP_MASTER_ID = "BLGROUPURF";
        /// <summary>BLグループマスタの名称</summary>
        public const string BL_GROUP_MASTER_NAME = "BLグループマスタ";

        /// <summary>
        /// BLグループマスタの処理構成の項目を取得します。
        /// </summary>
        /// <returns>BLグループマスタの処理構成の項目</returns>
        public ProcessConfigItem BLGroupMaster
        {
            get
            {
                ProcessConfigItem item = this[BL_GROUP_MASTER_ID];
                if (item != null) return item;
                return new ProcessConfigItem(BL_GROUP_MASTER_ID, BL_GROUP_MASTER_NAME);
            }
        }

        #endregion  // <BLグループマスタ/>

        #region <中分類マスタ/>

        /// <summary>中分類マスタのID</summary>
        public const string MIDDLE_GENRE_MASTER_ID = "GOODSGROUPURF";
        /// <summary>中分類マスタの名称</summary>
        public const string MIDDLE_GENRE_MASTER_NAME = "中分類マスタ";

        /// <summary>
        /// 中分類マスタの処理構成の項目を取得します。
        /// </summary>
        /// <returns>中分類マスタの処理構成の項目</returns>
        public ProcessConfigItem MiddleGenreMaster
        {
            get
            {
                ProcessConfigItem item = this[MIDDLE_GENRE_MASTER_ID];
                if (item != null) return item;
                return new ProcessConfigItem(MIDDLE_GENRE_MASTER_ID, MIDDLE_GENRE_MASTER_NAME);
            }
        }

        #endregion  // <中分類マスタ/>

        #region <車種マスタ/>

        /// <summary>車種マスタのID</summary>
        public const string MODEL_NAME_MASTER_ID = "MODELNAMEURF";
        /// <summary>車種マスタの名称</summary>
        public const string MODEL_NAME_MASTER_NAME = "車種マスタ";

        /// <summary>
        /// 車種マスタの処理構成の項目を取得します。
        /// </summary>
        /// <returns>車種マスタの処理構成の項目</returns>
        public ProcessConfigItem ModelNameMaster
        {
            get
            {
                ProcessConfigItem item = this[MODEL_NAME_MASTER_ID];
                if (item != null) return item;
                return new ProcessConfigItem(MODEL_NAME_MASTER_ID, MODEL_NAME_MASTER_NAME);
            }
        }

        #endregion  // <車種マスタ/>

        #region <メーカーマスタ/>

        /// <summary>メーカーマスタのID</summary>
        public const string MAKER_MASTER_ID = "MAKERURF";
        /// <summary>メーカーマスタの名称</summary>
        public const string MAKER_MASTER_NAME = "メーカーマスタ";

        /// <summary>
        /// メーカーマスタの処理構成の項目を取得します。
        /// </summary>
        /// <returns>メーカーマスタの処理構成の項目</returns>
        public ProcessConfigItem MakerMaster
        {
            get
            {
                ProcessConfigItem item = this[MAKER_MASTER_ID];
                if (item != null) return item;
                return new ProcessConfigItem(MAKER_MASTER_ID, MAKER_MASTER_NAME);
            }
        }

        #endregion  // <メーカーマスタ/>

        #region <部位マスタ/>

        /// <summary>部位マスタのID</summary>
        public const string PARTS_POS_CODE_MASTER_ID = "PARTSPOSCODEURF";
        /// <summary>部位マスタの名称</summary>
        public const string PARTS_POS_CODE_MASTER_NAME = "部位マスタ";

        /// <summary>
        /// 部位マスタの処理構成の項目を取得します。
        /// </summary>
        /// <returns>部位マスタの処理構成の項目</returns>
        public ProcessConfigItem PartsPosCodeMaster
        {
            get
            {
                ProcessConfigItem item = this[PARTS_POS_CODE_MASTER_ID];
                if (item != null) return item;
                return new ProcessConfigItem(PARTS_POS_CODE_MASTER_ID, PARTS_POS_CODE_MASTER_NAME);
            }
        }

        #endregion  // <部位マスタ/>

        #region <優良設定変更マスタ/>

        /// <summary>優良設定変更マスタのID</summary>
        public const string PRIME_SETTING_CHANGE_MASTER_ID = "PRMSETTINGCHGRF";
        /// <summary>優良設定変更マスタの名称</summary>
        public const string PRIME_SETTING_CHANGE_MASTER_NAME = "優良設定変更マスタ";

        /// <summary>
        /// 優良設定マスタの処理構成の項目を取得します。
        /// </summary>
        /// <returns>優良設定マスタの処理構成の項目</returns>
        public ProcessConfigItem PrimeSettingChangeMaster
        {
            get
            {
                ProcessConfigItem item = this[PRIME_SETTING_CHANGE_MASTER_ID];
                if (item != null) return item;
                return new ProcessConfigItem(PRIME_SETTING_CHANGE_MASTER_ID, PRIME_SETTING_CHANGE_MASTER_NAME);
            }
        }

        #endregion  // <優良設定変更マスタ/>

        /// <summary>
        /// 
        /// </summary>
        public DateTime LatestPreviousDateOfPrimeSetting
        {
            get
            {
                return PrimeSettingChangeMaster.PreviousDate >= PrimeSettingMaster.PreviousDate
                            ?
                        PrimeSettingChangeMaster.PreviousDate : PrimeSettingMaster.PreviousDate;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int TotalPreviousCountOfPrimeSetting
        {
            get { return PrimeSettingChangeMaster.PreviousCount + PrimeSettingMaster.PreviousCount; } 
        }

        /// <summary>
        /// 優良設定マスタの対象件数の合計を取得します。
        /// </summary>
        public int TotalPresentCountOfPrimeSetting
        {
            get { return PrimeSettingChangeMaster.PresentCount + PrimeSettingMaster.PresentCount; }
        }

        #region <優良設定マスタ/>

        /// <summary>優良設定マスタのID</summary>
        public const string PRIME_SETTING_MASTER_ID = "PRMSETTINGURF";
        /// <summary>優良設定マスタの名称</summary>
        public const string PRIME_SETTING_MASTER_NAME = "優良設定マスタ";

        /// <summary>
        /// 優良設定マスタの処理構成の項目を取得します。
        /// </summary>
        /// <returns>優良設定マスタの処理構成の項目</returns>
        public ProcessConfigItem PrimeSettingMaster
        {
            get
            {
                ProcessConfigItem item = this[PRIME_SETTING_MASTER_ID];
                if (item != null) return item;
                return new ProcessConfigItem(PRIME_SETTING_MASTER_ID, PRIME_SETTING_MASTER_NAME);
            }
        }

        #endregion  // <優良設定マスタ/>

        #region <商品マスタ/>

        /// <summary>商品マスタのID</summary>
        public const string GOODS_MASTER_ID = "GOODSURF";
        /// <summary>商品マスタの名称</summary>
        public const string GOODS_MASTER_NAME = "商品マスタ";

        /// <summary>
        /// 商品マスタの処理構成の項目を取得します。
        /// </summary>
        /// <returns>商品マスタの処理構成の項目</returns>
        public ProcessConfigItem GoodsMaster
        {
            get
            {
                ProcessConfigItem item = this[GOODS_MASTER_ID];
                if (item != null) return item;
                return new ProcessConfigItem(GOODS_MASTER_ID, GOODS_MASTER_NAME);
            }
        }

        #endregion  // <商品マスタ/>

        #region <価格マスタ/>

        /// <summary>価格マスタのID</summary>
        public const string GOODS_PRICE_MASTER_ID = "GOODSPRICEURF";
        /// <summary>価格マスタの名称</summary>
        public const string GOODS_PRICE_MASTER_NAME = "価格マスタ";

        /// <summary>
        /// 価格マスタの処理構成の項目を取得します。
        /// </summary>
        /// <returns>価格マスタの処理構成の項目</returns>
        public ProcessConfigItem GoodsPriceMaster
        {
            get
            {
                ProcessConfigItem item = this[GOODS_PRICE_MASTER_ID];
                if (item != null) return item;
                return new ProcessConfigItem(GOODS_PRICE_MASTER_ID, GOODS_PRICE_MASTER_NAME);
            }
        }

        #endregion  // <価格マスタ/>

        #region <価格改正/>

        /// <summary>価格改正のID</summary>
        public const string PRICE_REVISION_ID = "PriceRevision";
        /// <summary>価格改正の名称</summary>
        public const string PRICE_REVISION_NAME = "価格改正";

        /// <summary>
        /// 価格改正の処理構成の項目を取得します。
        /// </summary>
        /// <value>価格改正の処理構成の項目</value>
        public ProcessConfigItem PriceRevision
        {
            get
            {
                ProcessConfigItem item = this[PRICE_REVISION_ID];
                if (item != null) return item;
                return new ProcessConfigItem(PRICE_REVISION_ID, PRICE_REVISION_NAME);
            }
        }

        /// <summary>
        /// 価格改正の処理構成を更新します。
        /// </summary>
        /// <remarks>価格改正の前回処理日は商品マスタと価格マスタで最近の方を設定</remarks>
        public void UpdatePriceRevision()
        {
            // 価格改正の前回処理日は商品マスタと価格マスタで最近の方を設定
            ProcessConfigItem previousItem = (
                GoodsMaster.PreviousDate >= GoodsPriceMaster.PreviousDate ? GoodsMaster : GoodsPriceMaster
            );

            //ProcessConfigItem previousItem = GoodsMaster;

            PriceRevision.PreviousDate = previousItem.PreviousDate;
            PriceRevision.PreviousCount = previousItem.PreviousCount; // MOD 2009/02/23 不具合対応[11802] .PreviousCount→.PresentCount
            PriceRevision.PresentCount = GoodsMaster.PresentCount + GoodsPriceMaster.PresentCount;
        }

        #endregion  // <価格改正/>

        #region <Constructor/>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public ProcessConfig() { }

        #endregion  // <Constructor/>

        /// <summary>
        /// 初期化します。
        /// </summary>
        /// <param name="processConfigItemList">処理構成の項目のリスト</param>
        public void Initialize(IList<ProcessConfigItem> processConfigItemList)
        {
            ItemMap.Clear();
            foreach (ProcessConfigItem item in processConfigItemList)
            {
                if (!ItemMap.ContainsKey(item.ProcessId))
                {
                    ItemMap.Add(item.ProcessId, item);
                }
            }

            UpdatePriceRevision();
        }

        #region <Indexer/>

        /// <summary>
        /// インデクサ
        /// </summary>
        /// <param name="processId">処理ID（対象データID）</param>
        /// <returns>該当する処理構成の項目（該当がない場合、<c>null</c>を返します）</returns>
        public ProcessConfigItem this[string processId]
        {
            get
            {
                if (ItemMap.ContainsKey(processId))
                {
                    return ItemMap[processId];
                }
                return null;
            }
        }

        /// <summary>
        /// インデクサ
        /// </summary>
        /// <param name="index">
        /// インデックス<br/>
        /// <c>0</c>:BLコードマスタ
        /// <c>1</c>:BLグループマスタ
        /// <c>2</c>:中分類マスタ
        /// <c>3</c>:車種マスタ
        /// <c>4</c>:メーカーマスタ
        /// <c>5</c>:優良設定変更マスタ
        /// <c>6</c>:優良設定マスタ
        /// <c>7</c>:商品マスタ
        /// <c>8</c>:価格マスタ
        /// </param>
        /// <returns>該当する処理構成の項目（該当がない場合、<c>null</c>を返します）</returns>
        public ProcessConfigItem this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: // BLコードマスタ
                        return this[BL_CODE_MASTER_ID];
                    case 1: // BLグループマスタ
                        return this[BL_GROUP_MASTER_ID];
                    case 2: // 中分類マスタ
                        return this[MIDDLE_GENRE_MASTER_ID];
                    case 3: // 車種マスタ
                        return this[MODEL_NAME_MASTER_ID];
                    case 4: // メーカーマスタ
                        return this[MAKER_MASTER_ID];
                    case 5: // 優良設定変更マスタ
                        return this[PRIME_SETTING_CHANGE_MASTER_ID];
                    case 6: // 優良設定マスタ
                        return this[PRIME_SETTING_MASTER_ID];

                    // ADD 2009/02/24 不具合対応[11802] ---------->>>>>
                    case 7: // 部位マスタ
                        return this[PARTS_POS_CODE_MASTER_ID];
                    case 8: // 商品マスタ
                        return this[GOODS_MASTER_ID];
                    case 9: // 価格マスタ
                        return this[GOODS_PRICE_MASTER_ID];
                    default:// 価格改正
                        return this[PRICE_REVISION_ID];
                    // ADD 2009/02/24 不具合対応[11802] ----------<<<<<
                }
            }
        }

        #endregion  // <Indexer/>
    }

    #endregion  // <コンフィグ/>

    #region <処理順/>

    /// <summary>
    /// 日付による処理順クラス
    /// </summary>
    public sealed class ProcessSequenceByDate
    {
        #region <処理順リスト/>

        /// <summary>処理順のリスト</summary>
        /// <remarks>キー：対象データ区分("00") + 提供日付("yyyyMMddhhmmss")</remarks>
        private readonly SortedList<string, PriceUpdManualDataWork> _processSequenceList = new SortedList<string, PriceUpdManualDataWork>();
        /// <summary>
        /// 処理順のリストを取得します。
        /// </summary>
        public SortedList<string, PriceUpdManualDataWork> ProcessSequenceList
        {
            get { return _processSequenceList; }
        }

        #endregion  // <処理順リスト/>

        #region <Constructor/>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public ProcessSequenceByDate() { }

        #endregion  // <Constructor/>

        /// <summary>
        /// クリアします。
        /// </summary>
        public void Clear()
        {
            ProcessSequenceList.Clear();
        }

        /// <summary>
        /// 処理順情報を追加します。
        /// </summary>
        /// <param name="offerDateInfo">提供日付情報</param>
        public void Add(PriceUpdManualDataWork offerDateInfo)
        {
            string key = GetProcessSequenceKey(offerDateInfo);
            ProcessSequenceList.Add(key, offerDateInfo);
        }

        
        /// <summary>
        /// 件数を取得します。
        /// </summary>
        public int Count
        {
            get { return ProcessSequenceList.Count;  }
        }

        #region DLETE 1次分
        ///// <summary>
        ///// 日付の処理順リストを生成します。
        ///// </summary>
        ///// <returns>日付の処理順リスト</returns>
        //public SortedList<string, int> CreateDateSequenceList()
        //{
        //    SortedList<string, int> dateSeqList = new SortedList<string, int>();
        //    {
        //        foreach (PriceUpdManualDataWork dateInfo in ProcessSequenceList.Values)
        //        {
        //            string key = dateInfo.OfferDate.ToString("yyyyMMdd");
        //            if (!dateSeqList.ContainsKey(key))
        //            {
        //                dateSeqList.Add(key, int.Parse(key));
        //            }
        //        }
        //    }
        //    return dateSeqList;
        //}
        #endregion

        #region 1.5次分
        /// <summary>
        /// 日付の処理順リストを生成します。
        /// </summary>
        /// <returns>日付の処理順リスト</returns>
        public SortedList<int, string> CreateDateSequenceList()
        {
            SortedList<int, string> dateSeqList = new SortedList<int, string>();
            {
                foreach (PriceUpdManualDataWork dateInfo in ProcessSequenceList.Values)
                {
                    //string key = dateInfo.OfferDate.ToString("yyyyMMdd");

                    int key = int.Parse(dateInfo.OfferDate.ToString("yyyyMMdd"));
                    string value = dateInfo.dataDiv.ToString();

                    if (!dateSeqList.ContainsKey(key))
                    {
                        dateSeqList.Add(key, value);
                    }
                    else
                    {
                        dateSeqList[key] += ("," + value);
                    }
                }
            }
            return dateSeqList;
        }
        
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offerDate"></param>
        /// <returns></returns>
        public int FindAllDataCount(int offerDate)
        {
            DateTime offerDateTime = ConvertDateTime(offerDate);
            foreach (PriceUpdManualDataWork item in ProcessSequenceList.Values)
            {
                if (item.OfferDate.Equals(offerDateTime))
                {
                    return item.allDatacnt;
                }
            }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offerDate"></param>
        /// <returns></returns>
        public static DateTime ConvertDateTime(int offerDate)
        {
            string strOfferDate = offerDate.ToString("00000000");
            DateTime offerDateTime = new DateTime(
                int.Parse(strOfferDate.Substring(0, 4)),
                int.Parse(strOfferDate.Substring(4, 2)),
                int.Parse(strOfferDate.Substring(6, 2))
            );
            return offerDateTime;
        }

        /// <summary>
        /// 処理順リストのキーを取得します。
        /// </summary>
        /// <param name="offerDateInfo">価格改正処理日付取得データレコード</param>
        /// <returns>対象データ区分("00") + 提供日付("yyyyMMddhhmmss")</returns>
        private static string GetProcessSequenceKey(PriceUpdManualDataWork offerDateInfo)
        {
            return offerDateInfo.dataDiv.ToString("00") + offerDateInfo.OfferDate.ToString("yyyyMMddhhmmss");
        }
    }

    #endregion  // <処理順/>

    #region <優良設定マスタのマージ処理/>

    #region <Facade/>

    /// <summary>
    /// 優良設定マスタのマージ処理の窓口クラス
    /// </summary>
    public static class PrimeSettingMergeFacade
    {
        /// <summary>
        /// 優良設定マスタをマージします。
        /// </summary>
        /// <param name="offerDate">提供日</param>
        /// <param name="changeRecordList">優良設定変更マスタのレコードリスト</param>
        /// <param name="offerRecordList">優良設定マスタ（提供データ分）のレコードリスト</param>
        /// <param name="userRecordList">優良設定マスタ（ユーザー登録分）のレコードリスト</param>
        /// <param name="updatesNameItem">名称項目を更新するフラグ</param>
        /// <returns>
        /// マージ結果（優良設定マスタ（ユーザー登録分）の更新するレコードリストと削除するレコードリスト）
        /// </returns>
        public static UserUpdatingPrimeSettingPair Merge(
            int offerDate,
            ArrayList changeRecordList,
            ArrayList offerRecordList,
            ArrayList userRecordList,
            bool updatesNameItem
        )
        {
            string strOfferDate = offerDate.ToString("0000/00/00");
            DateTime offerDateTime = DateTime.Parse(strOfferDate);

            PrimeSettingMerger merger = new PrimeSettingMerger(
                offerDateTime,
                updatesNameItem,
                changeRecordList,
                offerRecordList
            );
            merger.Merge(userRecordList);

            return new UserUpdatingPrimeSettingPair(
                merger.UpdatingUserRecordList,
                merger.DeletingUserRecordList
            );
        }

        /// <summary>
        /// 商品管理情報のレコードのリストを取得します。
        /// </summary>
        /// <param name="prmSettingUWorkList">優良設定マスタ（ユーザー登録分）のレコードのリスト</param>
        /// <returns>対応する商品管理情報のレコードのリスト</returns>
        public static ArrayList GetGoodsMngWorkList(ArrayList prmSettingUWorkList)
        {
            #region <拠点別に分別/>

            // 拠点別に分別
            IDictionary<string, IList<PrmSettingUWork>> prmSettingUWorkListMap = new Dictionary<string, IList<PrmSettingUWork>>();
            foreach (PrmSettingUWork prmSettingUWork in prmSettingUWorkList)
            {
                string sectionCode = prmSettingUWork.SectionCode;
                if (!prmSettingUWorkListMap.ContainsKey(sectionCode))
                {
                    prmSettingUWorkListMap.Add(sectionCode, new List<PrmSettingUWork>());
                }
                prmSettingUWorkListMap[sectionCode].Add(prmSettingUWork);
            }

            #endregion  // <拠点別に分別/>

            // 商品管理情報のレコードのリストを構築
            ArrayList goodsMngWorkList = new ArrayList();
            {
                foreach (string sectionCode in prmSettingUWorkListMap.Keys)
                {
                    #region <検索条件/>

                    GoodsMngWork searchingCondition = new GoodsMngWork();
                    {
                        searchingCondition.EnterpriseCode = prmSettingUWorkListMap[sectionCode][0].EnterpriseCode;  // 企業コード
                        searchingCondition.SectionCode    = sectionCode;    // 拠点コード
                    }

                    #endregion  // <検索条件/>

                    #region <商品管理情報を検索/>

                    IGoodsMngDB dbReader = (IGoodsMngDB)MediationGoodsMngDB.GetGoodsMngDB();

                    object objSearchedList = null;
                    object objSearchingCondition = (object)searchingCondition;
                    int status = dbReader.Search(
                        out objSearchedList,
                        objSearchingCondition,
                        0,
                        Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0
                    );
                    if (!status.Equals((int)Result.RemoteStatus.Normal))
                    {
                        continue;
                    }
                    ArrayList searchedList = objSearchedList as ArrayList;
                    if (MergeChecker.IsNullOrEmptyArrayList(searchedList))
                    {
                        continue;
                    }

                    #endregion  // <商品管理情報を検索/>

                    // 検索結果を 中分類+メーカー+BL で分別
                    const string MIDDLE_FORMAT  = "0000";
                    const string MAKER_FORMAT   = "0000";
                    const string BL_FORMAT      = "0000";
                    IDictionary<string, GoodsMngWork> searchedMap = new Dictionary<string, GoodsMngWork>();
                    foreach (GoodsMngWork goodsMngWork in searchedList)
                    {
                        StringBuilder key = new StringBuilder();
                        {
                            key.Append(goodsMngWork.GoodsMGroup.ToString(MIDDLE_FORMAT));
                            key.Append(goodsMngWork.GoodsMakerCd.ToString(MAKER_FORMAT));
                            key.Append(goodsMngWork.BLGoodsCode.ToString(BL_FORMAT));
                        }
                        if (!searchedMap.ContainsKey(key.ToString()))
                        {
                            searchedMap.Add(key.ToString(), goodsMngWork);
                        }
                    }

                    // 検索結果を展開
                    foreach (PrmSettingUWork prmSettingUWork in prmSettingUWorkListMap[sectionCode])
                    {
                        StringBuilder key = new StringBuilder();
                        {
                            key.Append(prmSettingUWork.GoodsMGroup.ToString(MIDDLE_FORMAT));
                            key.Append(prmSettingUWork.PartsMakerCd.ToString(MAKER_FORMAT));
                            key.Append(prmSettingUWork.TbsPartsCode.ToString(BL_FORMAT));
                        }
                        if (searchedMap.ContainsKey(key.ToString()))
                        {
                            goodsMngWorkList.Add(searchedMap[key.ToString()]);
                        }
                    }
                }   // foreach (string sectionCode in prmSettingUWorkListMap.Keys)
            }
            return goodsMngWorkList;
        }
    }

    #endregion  // <Fcade/>

    /// <summary>
    /// 優良設定マスタのマージ者クラス
    /// </summary>
    public sealed class PrimeSettingMerger
    {
        #region <提供日時/>

        /// <summary>提供日時</summary>
        private readonly DateTime _offerDateTime;
        /// <summary>
        /// 提供日時を取得します。
        /// </summary>
        private DateTime OfferDateTime { get { return _offerDateTime; } }

        /// <summary>提供日付</summary>
        private int _offerDate;
        /// <summary>
        /// 提供日付を取得します。
        /// </summary>
        private int OfferDate
        {
            get
            {
                if (!_offerDate.Equals(0))
                {
                    return _offerDate;
                }
                else
                {
                    return int.Parse(OfferDateTime.ToString("yyyyMMdd"));
                }
            }

            set { _offerDate = value; }
        }

        #endregion  // <提供日時/>

        #region <名称項目を更新するフラグ/>

        /// <summary>名称項目を更新するフラグ</summary>
        private readonly bool _updatesNameItem;
        /// <summary>
        /// 名称項目を更新するフラグを取得します。
        /// </summary>
        private bool UpdatesNameItem { get { return _updatesNameItem; } }

        #endregion  // <名称項目を更新するフラグ/>

        #region <優良設定変更マスタ/>

        /// <summary>優良設定変更マスタのレコードリスト</summary>
        private readonly ArrayList _changeRecordList;
        /// <summary>
        /// 優良設定変更マスタのレコード
        /// </summary>
        private ArrayList ChangeRecordList { get { return _changeRecordList; } }

        #endregion  // <優良設定変更マスタ/>

        #region <優良設定マスタ（提供データ分）/>

        /// <summary>優良設定マスタ（提供データ分）のレコードリスト</summary>
        private readonly ArrayList _offerRecordList;
        /// <summary>
        /// 優良設定マスタ（提供データ分）のレコードリストを取得します。
        /// </summary>
        private ArrayList OfferRecordList { get { return _offerRecordList; } }

        #endregion  // <優良設定マスタ（提供データ分/>）

        #region <優良設定マスタ（ユーザー登録分）/>

        /// <summary>優良設定マスタ（ユーザー登録分）のレコードマップ</summary>
        /// <remarks>キー：構築時に採番（マージ用のデータテーブルのIDと同じ値になる）</remarks>
        private readonly IDictionary<long, PrmSettingUWork> _userRecordMap = new Dictionary<long, PrmSettingUWork>();
        /// <summary>
        /// 優良設定マスタ（ユーザー登録分）のレコードマップを取得します。
        /// </summary>
        /// <remarks>
        /// キー：構築時に採番（マージ用のデータテーブルのIDと同じ値になる）
        /// </remarks>
        private IDictionary<long, PrmSettingUWork> UserRecordMap { get { return _userRecordMap; } }

        #endregion  // <優良設定マスタ（ユーザー登録分）/>

        #region <マージ用データ/>

        /// <summary>マージ用データセット</summary>
        private PrimeSetting _mergingUserDataSet;
        /// <summary>
        /// マージ用データセットを取得します。
        /// </summary>
        private PrimeSetting MergingUserDataSet
        {
            get
            {
                if (_mergingUserDataSet == null)
                {
                    _mergingUserDataSet = new PrimeSetting();
                }
                return _mergingUserDataSet;
            }
        }

        /// <summary>
        /// マージ用データテーブルを取得します。
        /// </summary>
        private PrimeSetting.UserDataTable MergingUserDataTable
        {
            get { return MergingUserDataSet.User; }
        }

        #endregion  // <マージ用データ/>

        #region <マージ結果/>

        /// <summary>更新する優良設定マスタ（ユーザー登録分）のレコードリスト</summary>
        private readonly ArrayList _updatingUserRecordList = new ArrayList();
        /// <summary>
        /// 更新する優良設定マスタ（ユーザー登録分）のレコードリストを取得します。
        /// </summary>
        public ArrayList UpdatingUserRecordList { get { return _updatingUserRecordList; } }

        /// <summary>削除する優良設定マスタ（ユーザー登録分）のレコードリスト</summary>
        private readonly ArrayList _deletingUserRecordList = new ArrayList();
        /// <summary>
        /// 削除する優良設定マスタ（ユーザー登録分）のレコードリストを取得します。
        /// </summary>
        public ArrayList DeletingUserRecordList { get { return _deletingUserRecordList; } }

        #endregion  // <マージ結果/>

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="offerDateTime">提供日時</param>
        /// <param name="updatesNameItem">名称項目を更新するフラグ</param>
        /// <param name="changeRecordList">優良設定変更マスタのレコードリスト</param>
        /// <param name="offerRecordList">優良設定マスタ（提供データ分）のレコードリスト</param>
        public PrimeSettingMerger(
            DateTime offerDateTime,
            bool updatesNameItem,
            ArrayList changeRecordList,
            ArrayList offerRecordList
        )
        {
            _offerDateTime  = offerDateTime;    // 提供日時
            _updatesNameItem= updatesNameItem;  // 名称項目を更新するフラグ

            // 優良設定変更マスタ
            if (!MergeChecker.IsNullOrEmptyArrayList(changeRecordList))
            {
                _changeRecordList = changeRecordList;
            }
            else
            {
                _changeRecordList = new ArrayList();
            }

            // 優良設定マスタ（提供データ分）
            if (!MergeChecker.IsNullOrEmptyArrayList(offerRecordList))
            {
                _offerRecordList = offerRecordList;
            }
            else
            {
                _offerRecordList = new ArrayList();
            }
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// マージします。
        /// </summary>
        /// <param name="userRecordList">優良設定マスタ（ユーザー登録分）のレコードリスト</param>
        public void Merge(ArrayList userRecordList)
        {
            // マージの準備
            InitializeMergingUserInfo(userRecordList);

            // 優良設定変更マスタによるマージ
            MergeByPrimeSettingChangeMaster();

            // 優良設定マスタ（提供データ分）によるマージ
            MergeByPrimeSettingOfferMaster();

            // 更新リストと削除リストに展開
            SetUpdatingUserRecordListAndDeletingRecordList();
        }

        #region <マージの準備/>

        /// <summary>
        /// マージするための優良設定マスタ（ユーザー登録分）情報を初期化します。
        /// </summary>
        /// <param name="userRecordList">優良設定マスタ（ユーザー登録分）のレコードリスト</param>
        private void InitializeMergingUserInfo(ArrayList userRecordList)
        {
            MergingUserDataTable.Clear();
            if (MergeChecker.IsNullOrEmptyArrayList(userRecordList)) return;

            long idCount = 0;
            foreach (PrmSettingUWork prmSettingUWork in userRecordList)
            {
                long currentId = idCount++;

                UserRecordMap.Add(currentId, prmSettingUWork);

                MergingUserDataTable.AddUserRow(
                    currentId,
                    prmSettingUWork.GoodsMGroup,
                    prmSettingUWork.PartsMakerCd,
                    prmSettingUWork.TbsPartsCode,
                    prmSettingUWork.PrmSetDtlNo1,
                    prmSettingUWork.PrmSetDtlName1,
                    prmSettingUWork.PrmSetDtlNo2,
                    prmSettingUWork.PrmSetDtlName2,
                    prmSettingUWork.PrimeDisplayCode,
                    (int)PrimeSetting.RowStatus.None,
                    prmSettingUWork.OfferDate
                );
            }
        }

        #endregion  // <マージの準備/>

        #region <優良設定変更マスタによるマージ/>

        /// <summary>処理区分：削除</summary>
        private const int DELETING = 1;

        /// <summary>
        /// 優良設定変更マスタによるマージを行います。
        /// </summary>
        private void MergeByPrimeSettingChangeMaster()
        {
            foreach (PrmSettingChgWork prmSettingChgWork in ChangeRecordList)
            {
                string filter = GetWhere(prmSettingChgWork);
                Debug.WriteLine("優良設定変更マスタのフィルタ：" + filter);

                DataRow[] foundRows = MergingUserDataTable.Select(filter);
                {
                    // 対象チェック：対象レコードがない場合、処理を行わない
                    if (foundRows.Length.Equals(0)) continue;

                    PrintPrmSettingChgWork(prmSettingChgWork);

                    foreach (PrimeSetting.UserRow mergingRow in foundRows)
                    {
                        // 対象チェック：提供日が提供データとユーザーデータで同一の場合は、処理を行わない
                        if (mergingRow.OfferDate.Equals(prmSettingChgWork.OfferDate)) continue;

                        // 削除判定
                        if (prmSettingChgWork.ProcDivCd.Equals(DELETING))
                        {
                            mergingRow.Status = (int)PrimeSetting.RowStatus.Deleting;
                            continue;
                        }

                        // 優良設定詳細コード1を変更
                        SetPrmSetDtlNo1(mergingRow, prmSettingChgWork);

                        // 優良設定詳細コード2を変更
                        SetPrmSetDtlNo2(mergingRow, prmSettingChgWork);

                        // 優良表示区分
                        SetPrimeDisplayCode(mergingRow, prmSettingChgWork);

                        // 提供日付
                        if (mergingRow.Status.Equals((int)PrimeSetting.RowStatus.Updating))
                        {
                            // 優良設定マスタ（提供データ分）によるマージと同じ日付（のはず）
                            //mergingRow.OfferDate = prmSettingChgWork.OfferDate;
                            OfferDate = prmSettingChgWork.OfferDate;
                        }
                    }   // foreach (PrimeSetting.UserRow mergingRow in foundRows)
                }
            }   // foreach (PrmSettingChgWork prmSettingChgWork in ChangeRecordList)
        }

        /// <summary>
        /// 優良設定詳細コード1を設定します。
        /// </summary>
        /// <param name="mergingRow">マージ用データ行</param>
        /// <param name="prmSettingChgWork">優良設定変更マスタのレコード</param>
        private static void SetPrmSetDtlNo1(
            PrimeSetting.UserRow mergingRow,
            PrmSettingChgWork prmSettingChgWork
        )
        {
            // 変更後優良設定詳細コード1が -1 の場合は書き換えない
            if (prmSettingChgWork.AfPrmSetDtlNo1 < 0) return;

            mergingRow.PrmSetDtlNo1 = prmSettingChgWork.AfPrmSetDtlNo1;
            mergingRow.Status = (int)PrimeSetting.RowStatus.Updating;
        }

        /// <summary>
        /// 優良設定詳細コード2を設定します。
        /// </summary>
        /// <param name="mergingRow">マージ用データ行</param>
        /// <param name="prmSettingChgWork">優良設定変更マスタのレコード</param>
        private static void SetPrmSetDtlNo2(
            PrimeSetting.UserRow mergingRow,
            PrmSettingChgWork prmSettingChgWork
        )
        {
            // 変更後優良設定詳細コード2が -1 の場合は書き換えない
            if (prmSettingChgWork.AfPrmSetDtlNo2 < 0) return;

            mergingRow.PrmSetDtlNo2 = prmSettingChgWork.AfPrmSetDtlNo2;
            mergingRow.Status = (int)PrimeSetting.RowStatus.Updating;
        }

        /// <summary>
        /// 優良表示区分を設定します。
        /// </summary>
        /// <param name="mergingRow">マージ用データ行</param>
        /// <param name="prmSettingChgWork">優良設定変更マスタのレコード</param>
        private static void SetPrimeDisplayCode(
            PrimeSetting.UserRow mergingRow,
            PrmSettingChgWork prmSettingChgWork
        )
        {
            // 変更後優良表示区分が 1, 2 の場合、更新する
            if (
                prmSettingChgWork.AfPrimeDisplayCode.Equals(1)  // 商品＆結合
                    ||
                prmSettingChgWork.AfPrimeDisplayCode.Equals(2)  // 商品
            )
            {
                mergingRow.PrimeDisplayCode = prmSettingChgWork.AfPrimeDisplayCode;
                mergingRow.Status = (int)PrimeSetting.RowStatus.Updating;
            }
        }

        #endregion  // <優良設定変更マスタによるマージ/>

        #region <優良設定マスタ（提供データ分）によるマージ/>

        /// <summary>
        /// 優良設定マスタ（提供データ分）によるマージを行います。
        /// </summary>
        private void MergeByPrimeSettingOfferMaster()
        {
            foreach (PrmSettingWork prmSettingWork in OfferRecordList)
            {
                string filter = GetWhere(prmSettingWork);
                Debug.WriteLine("優良設定マスタ（提供）のフィルタ：" + filter);

                DataRow[] foundRows = MergingUserDataTable.Select(filter);
                {
                    // 対象チェック：対象レコードがない場合、処理を行わない
                    if (foundRows.Length.Equals(0)) continue;

                    PrintPrmSettingWork(prmSettingWork);

                    foreach (PrimeSetting.UserRow mergingRow in foundRows)
                    {
                        // 対象チェック：提供日が提供データとユーザーデータで同一の場合は、処理を行わない
                        if (mergingRow.OfferDate.Equals(prmSettingWork.OfferDate)) continue;

                        // 優良設定詳細1
                        SetPrmSetDtl1(mergingRow, prmSettingWork);

                        // 優良設定詳細2
                        SetPrmSetDtl2(mergingRow, prmSettingWork);

                        // 提供日付
                        if (mergingRow.Status.Equals((int)PrimeSetting.RowStatus.Updating))
                        {
                            // 優良設定変更マスタによるマージと同じ日付（のはず）
                            //mergingRow.OfferDate = prmSettingWork.OfferDate;
                            OfferDate = prmSettingWork.OfferDate;
                        }
                    }   // foreach (PrimeSetting.UserRow mergingRow in foundRows)
                }
            }   // foreach (PrmSettingChgWork prmSettingChgWork in ChangeRecordList)
        }

        /// <summary>
        /// 優良設定詳細1を設定します。
        /// </summary>
        /// <param name="mergingRow">マージ用データ行</param>
        /// <param name="prmSettingWork">優良設定マスタ（提供データ分）のレコード</param>
        private void SetPrmSetDtl1(
            PrimeSetting.UserRow mergingRow,
            PrmSettingWork prmSettingWork
        )
        {
            // 優良設定詳細コード1 ※優良設定詳細コード1は対象外
            //mergingRow.PrmSetDtlNo1 = prmSettingWork.PrmSetDtlNo1;

            // 優良設定詳細名称1
            if (UpdatesNameItem)
            {
                mergingRow.PrmSetDtlName1 = prmSettingWork.PrmSetDtlName1;
            }

            mergingRow.Status = (int)PrimeSetting.RowStatus.Updating;
        }

        /// <summary>
        /// 優良設定詳細2を設定します。
        /// </summary>
        /// <param name="mergingRow">マージ用データ行</param>
        /// <param name="prmSettingWork">優良設定マスタ（提供データ分）のレコード</param>
        private void SetPrmSetDtl2(
            PrimeSetting.UserRow mergingRow,
            PrmSettingWork prmSettingWork
        )
        {
            // 優良設定詳細コード2 ※優良設定詳細コード2は対象外
            //mergingRow.PrmSetDtlNo2 = prmSettingWork.PrmSetDtlNo2;

            // 優良設定詳細名称2
            if (UpdatesNameItem)
            {
                mergingRow.PrmSetDtlName2 = prmSettingWork.PrmSetDtlName2;
            }

            mergingRow.Status = (int)PrimeSetting.RowStatus.Updating;
        }

        #endregion  // <優良設定マスタ（提供データ分）によるマージ/>

        #region <フィルタ/>

        /// <summary>
        /// 優良設定マスタ（提供データ分）によるマージでのwhere句を取得します。
        /// </summary>
        /// <param name="prmSettingWork">優良設定マスタ（提供データ分）のレコード</param>
        /// <returns>基本where句</returns>
        private string GetWhere(PrmSettingWork prmSettingWork)
        {
            return GetBaseWhere(
                prmSettingWork.GoodsMGroup,
                prmSettingWork.PartsMakerCd,
                prmSettingWork.TbsPartsCode
            );
        }

        /// <summary>
        /// 優良設定変更マスタによるマージでのwhere句を取得します。
        /// </summary>
        /// <param name="prmSettingChgWork">優良設定変更マスタのレコード</param>
        /// <returns>基本where句 and 優良設定詳細コード1 and 優良設定詳細コード2</returns>
        private string GetWhere(PrmSettingChgWork prmSettingChgWork)
        {
            string baseWhere = GetBaseWhere(prmSettingChgWork);

            int prmSetDtlNo1 = prmSettingChgWork.PrmSetDtlNo1;   // 優良設定詳細コード1
            int prmSetDtlNo2 = prmSettingChgWork.PrmSetDtlNo2;   // 優良設定詳細コード2

            StringBuilder where = new StringBuilder(baseWhere);
            {
                where.Append(ADOUtil.AND);
                where.Append(MergingUserDataTable.PrmSetDtlNo1Column.ColumnName).Append(ADOUtil.EQ).Append(prmSetDtlNo1);
                where.Append(ADOUtil.AND);
                where.Append(MergingUserDataTable.PrmSetDtlNo2Column.ColumnName).Append(ADOUtil.EQ).Append(prmSetDtlNo2);
            }
            return where.ToString();
        }

        /// <summary>
        /// 基本where句を取得します。
        /// </summary>
        /// <param name="prmSettingChgWork">優良設定変更マスタのレコード</param>
        /// <returns>where 中分類コード and 部品メーカーコード and BLコード</returns>
        private string GetBaseWhere(PrmSettingChgWork prmSettingChgWork)
        {
            int goodsMGroup = prmSettingChgWork.GoodsMGroup;    // 中分類コード
            int partsMakerCd = prmSettingChgWork.PartsMakerCd;   // 部品メーカーコード
            int tbsPartsCode = prmSettingChgWork.TbsPartsCode;   // BLコード

            return GetBaseWhere(goodsMGroup, partsMakerCd, tbsPartsCode);
        }

        /// <summary>
        /// 基本where句を取得します。
        /// </summary>
        /// <param name="goodsMGroup">中分類コード</param>
        /// <param name="partsMakerCd">部品メーカーコード</param>
        /// <param name="tbsPartsCode">BLコード</param>
        /// <returns>where 中分類コード and 部品メーカーコード and BLコード</returns>
        private string GetBaseWhere(
            int goodsMGroup,
            int partsMakerCd,
            int tbsPartsCode
        )
        {
            StringBuilder where = new StringBuilder();
            {
                where.Append(MergingUserDataTable.GoodsMGroupColumn.ColumnName).Append(ADOUtil.EQ).Append(goodsMGroup);
                where.Append(ADOUtil.AND);
                where.Append(MergingUserDataTable.PartsMakerCdColumn.ColumnName).Append(ADOUtil.EQ).Append(partsMakerCd);
                where.Append(ADOUtil.AND);
                where.Append(MergingUserDataTable.TbsPartsCodeColumn.ColumnName).Append(ADOUtil.EQ).Append(tbsPartsCode);
            }
            return where.ToString();
        }

        #endregion  // <フィルタ/>

        #region <更新リストと削除リストに展開/>

        /// <summary>
        /// 更新リストと削除リストに展開します。
        /// </summary>
        private void SetUpdatingUserRecordListAndDeletingRecordList()
        {
            // 更新リストを構築
            UpdatingUserRecordList.Clear();
            {
                string updatingFilter = GetWhere(PrimeSetting.RowStatus.Updating);

                DataRow[] foundRows = MergingUserDataTable.Select(updatingFilter);

                foreach (PrimeSetting.UserRow updatingRow in foundRows)
                {
                    long currentId = updatingRow.Id;

                    // 変更前の更新レコードを論理削除するレコードとして登録
                    UpdatingUserRecordList.Add(CreateLogicalDeletingRecord(UserRecordMap[currentId]));

                    // 更新レコードを登録
                    UpdatingUserRecordList.Add(GetMergedRecord(
                        UserRecordMap[currentId],
                        updatingRow
                    ));
                }
            }

            // 削除リストを構築
            DeletingUserRecordList.Clear();
            {
                string deletingFilter = GetWhere(PrimeSetting.RowStatus.Deleting);

                DataRow[] foundRows = MergingUserDataTable.Select(deletingFilter);

                foreach (PrimeSetting.UserRow deletingRow in foundRows)
                {
                    long currentId = deletingRow.Id;
                    DeletingUserRecordList.Add(UserRecordMap[currentId]);
                }
            }
        }

        /// <summary>
        /// 論理削除とするレコードを生成します。
        /// </summary>
        /// <param name="prmSettingUWork">優良設定マスタ（ユーザー登録分）のレコード</param>
        /// <returns>論理削除とするレコード</returns>
        private PrmSettingUWork CreateLogicalDeletingRecord(PrmSettingUWork prmSettingUWork)
        {
            PrmSettingUWork logicalDeletingRecord = new PrmSettingUWork();
            {
                logicalDeletingRecord.CreateDateTime    = prmSettingUWork.CreateDateTime;   // 作成日時
                logicalDeletingRecord.EnterpriseCode    = prmSettingUWork.EnterpriseCode;   // 企業コード
                logicalDeletingRecord.LogicalDeleteCode = 2;    // 論理削除区分(0:有効, 1:論理削除, 2:保留, 3:完全削除)
                logicalDeletingRecord.UpdateDateTime    = prmSettingUWork.UpdateDateTime;   // 更新日時 

                logicalDeletingRecord.SectionCode       = prmSettingUWork.SectionCode;      // 拠点コード
                logicalDeletingRecord.GoodsMGroup       = prmSettingUWork.GoodsMGroup;      // 商品中分類コード
                logicalDeletingRecord.TbsPartsCode      = prmSettingUWork.TbsPartsCode;     // BLコード
                logicalDeletingRecord.TbsPartsCdDerivedNo = prmSettingUWork.TbsPartsCdDerivedNo;    // BLコード枝番
                logicalDeletingRecord.MakerDispOrder    = prmSettingUWork.MakerDispOrder;   // メーカー表示順位
                logicalDeletingRecord.PartsMakerCd      = prmSettingUWork.PartsMakerCd;     // 部品メーカーコード
                logicalDeletingRecord.PrimeDispOrder    = prmSettingUWork.PrimeDispOrder;   // 優良表示順位
                logicalDeletingRecord.PrmSetDtlNo1      = prmSettingUWork.PrmSetDtlNo1;     // 優良設定詳細コード1
                logicalDeletingRecord.PrmSetDtlName1    = prmSettingUWork.PrmSetDtlName1;   // 優良設定詳細名称1
                logicalDeletingRecord.PrmSetDtlNo2      = prmSettingUWork.PrmSetDtlNo2;     // 優良設定詳細コード2
                logicalDeletingRecord.PrmSetDtlName2    = prmSettingUWork.PrmSetDtlName2;   // 優良設定詳細名称2
                logicalDeletingRecord.PrimeDisplayCode  = prmSettingUWork.PrimeDisplayCode; // 優良表示区分
                logicalDeletingRecord.OfferDate         = prmSettingUWork.OfferDate;        // 提供日付
            }
            return logicalDeletingRecord;
        }

        /// <summary>
        /// 値をマージしたレコードを取得します。
        /// </summary>
        /// <param name="prmSettingUWork">優良設定マスタ（ユーザー登録分）のレコード</param>
        /// <param name="mergingRow">マージ用データ行</param>
        private PrmSettingUWork GetMergedRecord(
            PrmSettingUWork prmSettingUWork,
            PrimeSetting.UserRow mergingRow
        )
        {
            // 優良設定詳細1
            prmSettingUWork.PrmSetDtlNo1    = mergingRow.PrmSetDtlNo1;
            prmSettingUWork.PrmSetDtlName1  = mergingRow.PrmSetDtlName1;

            // 優良設定詳細2
            prmSettingUWork.PrmSetDtlNo2    = mergingRow.PrmSetDtlNo2;
            prmSettingUWork.PrmSetDtlName2  = mergingRow.PrmSetDtlName2;

            // 優良表示区分
            prmSettingUWork.PrimeDisplayCode= mergingRow.PrimeDisplayCode;

            // 提供日付
            prmSettingUWork.OfferDate = OfferDate;

            PrintMergingUserRecord(prmSettingUWork);

            return prmSettingUWork;
        }

        /// <summary>
        /// マージ結果展開用のwhere句を取得します。
        /// </summary>
        /// <param name="rowStatus">マージ用データ行のステータス列の値</param>
        /// <returns>マージ用データ行のステータス列の値</returns>
        private string GetWhere(PrimeSetting.RowStatus rowStatus)
        {
            StringBuilder where = new StringBuilder();
            {
                where.Append(MergingUserDataTable.StatusColumn.ColumnName).Append(ADOUtil.EQ).Append((int)rowStatus);
            }
            return where.ToString();
        }

        #endregion  // <更新リストと削除リストに展開/>

        #region <Debug/>

        /// <summary>
        /// 優良設定変更マスタのレコードの内容を表示します。
        /// </summary>
        /// <param name="prmSettingChgWork">優良設定変更マスタのレコード</param>
        [Conditional("DEBUG")]
        private static void PrintPrmSettingChgWork(PrmSettingChgWork prmSettingChgWork)
        {
        }

        /// <summary>
        /// 優良設定マスタ（提供データ分）のレコードの内容を表示します。
        /// </summary>
        /// <param name="prmSettingWork">優良設定マスタ（提供データ分）のレコード</param>
        [Conditional("DEBUG")]
        private static void PrintPrmSettingWork(PrmSettingWork prmSettingWork)
        {
            int goodsMGroup = prmSettingWork.GoodsMGroup;   // 中分類コード
            int partsMakerCd = prmSettingWork.PartsMakerCd; // 部品メーカーコード
            int tbsPartsCode = prmSettingWork.TbsPartsCode; // BLコード

            // 優良設定詳細1
            int prmSetDtlNo1 = prmSettingWork.PrmSetDtlNo1;
            string prmSetDtlName1 = prmSettingWork.PrmSetDtlName1;

            // 優良設定詳細2
            int prmSetDtlNo2 = prmSettingWork.PrmSetDtlNo2;
            string prmSetDtlName2 = prmSettingWork.PrmSetDtlName2;

            // 提供日付
            int offerDate = prmSettingWork.OfferDate;

            StringBuilder line = new StringBuilder();
            {
                line.Append("(提供)中分類：").Append(goodsMGroup).Append(",");
                line.Append("(提供)メーカー：").Append(partsMakerCd).Append(",");
                line.Append("(提供)BL：").Append(tbsPartsCode).Append(",");
                line.Append("(提供)詳細コード1：").Append(prmSetDtlNo1).Append(",");
                line.Append("(提供)詳細名称1：").Append(prmSetDtlName1).Append(",");
                line.Append("(提供)詳細コード2：").Append(prmSetDtlNo2).Append(",");
                line.Append("(提供)詳細名称2：").Append(prmSetDtlName2).Append(",");
                line.Append("(提供)提供日：").Append(offerDate);
            }
            Debug.WriteLine(line.ToString());
        }

        /// <summary>
        /// 優良設定マスタ（ユーザー登録分）のマージするレコードの内容を表示します。
        /// </summary>
        /// <param name="userRecord">優良設定マスタ（ユーザー登録分）のマージするレコード</param>
        [Conditional("DEBUG")]
        private static void PrintMergingUserRecord(PrmSettingUWork userRecord)
        {
            int goodsMGroup = userRecord.GoodsMGroup;   // 中分類コード
            int partsMakerCd = userRecord.PartsMakerCd; // 部品メーカーコード
            int tbsPartsCode = userRecord.TbsPartsCode; // BLコード

            // 優良設定詳細1
            int prmSetDtlNo1 = userRecord.PrmSetDtlNo1;
            string prmSetDtlName1 = userRecord.PrmSetDtlName1;

            // 優良設定詳細2
            int prmSetDtlNo2 = userRecord.PrmSetDtlNo2;
            string prmSetDtlName2 = userRecord.PrmSetDtlName2;

            // 優良表示区分
            int primeDisplayCode = userRecord.PrimeDisplayCode;

            // 提供日付
            int offerDate = userRecord.OfferDate;

            StringBuilder line = new StringBuilder();
            {
                line.Append("中分類：").Append(goodsMGroup).Append(",");
                line.Append("メーカー：").Append(partsMakerCd).Append(",");
                line.Append("BL：").Append(tbsPartsCode).Append(",");
                line.Append("詳細コード1：").Append(prmSetDtlNo1).Append(",");
                line.Append("詳細名称1：").Append(prmSetDtlName1).Append(",");
                line.Append("詳細コード2：").Append(prmSetDtlNo2).Append(",");
                line.Append("詳細名称2：").Append(prmSetDtlName2).Append(",");
                line.Append("表示区分：").Append(primeDisplayCode).Append(",");
                line.Append("提供日：").Append(offerDate);
            }
            Debug.WriteLine(line.ToString());
        }

        #endregion  // <Debug/>
    }

    #endregion  // <優良設定マスタのマージ処理/>

    #region <実行結果/>

    /// <summary>
    /// 実行結果クラス
    /// </summary>
    public sealed class ProcessResult
    {
        #region <BLコードマスタ/>

        /// <summary>BLコードマスタの更新件数</summary>
        private int _blCodeMasterUpdatedCount;
        /// <summary>
        /// BLコードマスタの更新件数のアクセサ
        /// </summary>
        public int BLCodeMasterUpdatedCount
        {
            get { return _blCodeMasterUpdatedCount; }
            set { _blCodeMasterUpdatedCount = value; }
        }

        #endregion  // <BLコードマスタ/>

        #region <BLグループマスタ/>

        /// <summary>BLグループマスタの更新件数</summary>
        private int _blGroupMasterUpdatedCount;
        /// <summary>
        /// BLグループマスタの更新件数のアクセサ
        /// </summary>
        public int BLGroupMasterUpdatedCount
        {
            get { return _blGroupMasterUpdatedCount; }
            set { _blGroupMasterUpdatedCount = value; }
        }

        #endregion  // <BLグループマスタ/>

        #region <中分類マスタ/>

        /// <summary>中分類マスタの更新件数</summary>
        private int _middleGenreMasterUpdatedCount;
        /// <summary>
        /// 中分類マスタの更新件数のアクセサ
        /// </summary>
        public int MiddleGenreMasterUpdatedCount
        {
            get { return _middleGenreMasterUpdatedCount; }
            set { _middleGenreMasterUpdatedCount = value; }
        }

        #endregion  // <中分類マスタ/>

        #region <車種マスタ/>

        /// <summary>車種マスタの更新件数</summary>
        private int _modelNameMasterUpdatedCount;
        /// <summary>
        /// 車種マスタの更新件数のアクセサ
        /// </summary>
        public int ModelNameMasterUpdatedCount
        {
            get { return _modelNameMasterUpdatedCount; }
            set { _modelNameMasterUpdatedCount = value; }
        }

        #endregion  // <車種マスタ/>

        #region <メーカーマスタ/>

        /// <summary>メーカーマスタの更新件数</summary>
        private int _makerMasterUpdatedCount;
        /// <summary>
        /// メーカーマスタの更新件数のアクセサ
        /// </summary>
        public int MakerMasterUpdatedCount
        {
            get { return _makerMasterUpdatedCount; }
            set { _makerMasterUpdatedCount = value; }
        }

        #endregion  // <メーカーマスタ/>

        #region <優良設定マスタ/>

        /// <summary>優良設定マスタの更新件数</summary>
        private int _primeSettingMasterUpdatedCount;
        /// <summary>
        /// 優良設定マスタの更新件数のアクセサ
        /// </summary>
        public int PrimeSettingMasterUpdatedCount
        {
            get { return _primeSettingMasterUpdatedCount; }
            set { _primeSettingMasterUpdatedCount = value; }
        }

        #endregion  // <優良設定マスタ/>

        #region <部位マスタ/>

        /// <summary>部位マスタの更新件数</summary>
        private int _partsPosCodeMasterUpdatedCount;
        /// <summary>
        /// 部位マスタの更新件数のアクセサ
        /// </summary>
        public int PartsPosCodeMasterUpdatedCount
        {
            get { return _partsPosCodeMasterUpdatedCount; }
            set { _partsPosCodeMasterUpdatedCount = value; }
        }

        #endregion  // <部位マスタ/>

        #region <商品マスタ/>

        /// <summary>商品マスタの更新件数</summary>
        private int _goodsMasterUpdatedCount;
        /// <summary>
        /// 商品マスタの更新件数のアクセサ
        /// </summary>
        public int GoodsMasterUpdatedCount
        {
            get { return _goodsMasterUpdatedCount; }
            set { _goodsMasterUpdatedCount = value; }
        }

        #endregion  // <商品マスタ/>

        #region <価格マスタ/>

        /// <summary>価格マスタの更新件数</summary>
        private int _goodsPriceMasterUpdatedCount;
        /// <summary>
        /// 価格マスタの更新件数のアクセサ
        /// </summary>
        public int GoodsPriceMasterUpdatedCount
        {
            get { return _goodsPriceMasterUpdatedCount; }
            set { _goodsPriceMasterUpdatedCount = value; }
        }

        #endregion  // <価格マスタ/>

        #region <Constructor/>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public ProcessResult() { }

        #endregion  // <Constructor/>

        #region <価格改正/>

        /// <summary>
        /// 価格改正の更新件数を取得します。
        /// </summary>
        /// <value>商品マスタの更新件数 + 価格マスタの更新件数</value>
        public int PriceRevisionUpdatedCount
        {
            get { return GoodsMasterUpdatedCount + GoodsPriceMasterUpdatedCount; }
        }

        #endregion  // <価格改正/>

        #region <Indexer/>

        /// <summary>
        /// インデクサ
        /// </summary>
        /// <param name="tableId">テーブルID</param>
        /// <returns>該当する更新件数</returns>
        public int this[string tableId]
        {
            get
            {
                if (tableId.Equals(ProcessConfig.BL_CODE_MASTER_ID))
                {
                    return BLCodeMasterUpdatedCount;
                }
                if (tableId.Equals(ProcessConfig.BL_GROUP_MASTER_ID))
                {
                    return BLGroupMasterUpdatedCount;
                }
                if (tableId.Equals(ProcessConfig.MIDDLE_GENRE_MASTER_ID))
                {
                    return MiddleGenreMasterUpdatedCount;
                }
                if (tableId.Equals(ProcessConfig.MODEL_NAME_MASTER_ID))
                {
                    return ModelNameMasterUpdatedCount;
                }
                if (tableId.Equals(ProcessConfig.MAKER_MASTER_ID))
                {
                    return MakerMasterUpdatedCount;
                }
                if (
                    tableId.Equals(ProcessConfig.PRIME_SETTING_CHANGE_MASTER_ID)
                        ||
                    tableId.Equals(ProcessConfig.PRIME_SETTING_MASTER_ID)
                )
                {
                    return PrimeSettingMasterUpdatedCount;
                }
                if (tableId.Equals(ProcessConfig.PARTS_POS_CODE_MASTER_ID))
                {
                    return PartsPosCodeMasterUpdatedCount;
                }
                if (tableId.Equals(ProcessConfig.GOODS_MASTER_ID))
                {
                    return GoodsMasterUpdatedCount;
                }
                if (tableId.Equals(ProcessConfig.GOODS_PRICE_MASTER_ID))
                {
                    return GoodsPriceMasterUpdatedCount;
                }
                if (tableId.Equals(ProcessConfig.PRICE_REVISION_ID))
                {
                    return PriceRevisionUpdatedCount;
                }
                return 0;
            }
        }

        #endregion  // <Indexer/>
    }

    #endregion  // <実行結果/>

    #region <ログ/>

    /// <summary>
    /// ロガークラス
    /// </summary>
    public sealed class MyLogWriter
    {
        #region <ログの書込み者/>

        /// <summary>ログの書込み者</summary>
        private readonly OperationHistoryLog _logWriter = new OperationHistoryLog();
        /// <summary>
        /// ログの書込み者を取得します。
        /// </summary>
        private OperationHistoryLog LogWriter { get { return _logWriter; } }

        #endregion  // <ログの書込み者/>

        #region <保持者/>

        /// <summary>保持者</summary>
        private readonly object _owner;
        /// <summary>
        /// 保持者を取得します。
        /// </summary>
        private object Owner { get { return _owner; } }

        #endregion  // <保持者/>

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="owner">保持者</param>
        public MyLogWriter(object owner)
        {
            _owner = owner;
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// ログを書き込みます
        /// </summary>
        /// <param name="processName">各処理の名称</param>
        /// <param name="stepName">処理区分</param>
        /// <param name="data">更新内容</param>
        public void Write(
            string processName,
            string stepName,
            string data
        )
        {
            const string PROGRAM_ID = "PMKHN09201A";
            const string PROGRAM_NAME = "提供データ更新処理";
            const int OPERATION_CODE = 0;
            const int STATUS = 0;

            LogWriter.WriteOperationLog(
                Owner,
                DateTime.Now,
                LogDataKind.SystemLog,
                PROGRAM_ID,
                PROGRAM_NAME,
                processName,
                OPERATION_CODE,
                STATUS,
                stepName,
                data
            );
        }

        #region <文言/>

        /// <summary>
        /// 対象日付取得のログ用メッセージを取得します。
        /// </summary>
        /// <param name="offerDate">提供日</param>
        /// <param name="processSequence"></param>
        /// <returns></returns>
        public static string GetTargetCheckMessage(
            int offerDate,
            ProcessSequenceByDate processSequence
        )
        {
            DateTime offerDateTime = ProcessSequenceByDate.ConvertDateTime(offerDate);
            int allDataCount = processSequence.FindAllDataCount(offerDate);

            StringBuilder msg = new StringBuilder();
            {
                msg.Append("対象日付:").Append(offerDateTime.ToString("yyyy/MM/dd"));
                msg.Append(" ");
                msg.Append("件数").Append(allDataCount).Append("件");
            }
            return msg.ToString();
        }

        /// <summary>マージ処理</summary>
        public const string MERGING = "更新処理";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string GetTargetTableName(MergeInfoGetCond condition)
        {
            const string SEPARATOR = ",";

            StringBuilder msg = new StringBuilder();
            {
                // BLコードマスタ
                if (condition.BLFlg.Equals(MergeCond.DOING_FLG_AS_INT))
                {
                    msg.Append(ProcessConfig.BL_CODE_MASTER_NAME);
                }
                // BLグループマスタ
                if (condition.BLGroupFlg.Equals(MergeCond.DOING_FLG_AS_INT))
                {
                    if (!string.IsNullOrEmpty(msg.ToString())) msg.Append(SEPARATOR);
                    msg.Append(ProcessConfig.BL_GROUP_MASTER_NAME);
                }
                // 中分類マスタ
                if (condition.GoodsMGroupFlg.Equals(MergeCond.DOING_FLG_AS_INT))
                {
                    if (!string.IsNullOrEmpty(msg.ToString())) msg.Append(SEPARATOR);
                    msg.Append(ProcessConfig.MIDDLE_GENRE_MASTER_NAME);
                }
                // 車種マスタ
                if (condition.ModelNameFlg.Equals(MergeCond.DOING_FLG_AS_INT))
                {
                    if (!string.IsNullOrEmpty(msg.ToString())) msg.Append(SEPARATOR);
                    msg.Append(ProcessConfig.MODEL_NAME_MASTER_NAME);
                }
                // メーカーマスタ
                if (condition.PMakerFlg.Equals(MergeCond.DOING_FLG_AS_INT))
                {
                    if (!string.IsNullOrEmpty(msg.ToString())) msg.Append(SEPARATOR);
                    msg.Append(ProcessConfig.MAKER_MASTER_NAME);
                }
                // 優良設定マスタ
                if (
                    condition.PrmSetChgFlg.Equals(MergeCond.DOING_FLG_AS_INT)
                        ||
                    condition.PrmSetFlg.Equals(MergeCond.DOING_FLG_AS_INT)
                )
                {
                    if (!string.IsNullOrEmpty(msg.ToString())) msg.Append(SEPARATOR);
                    msg.Append(ProcessConfig.PRIME_SETTING_MASTER_NAME);
                }
                // 部位マスタ
                if (condition.PartsPosFlg.Equals(MergeCond.DOING_FLG_AS_INT))
                {
                    if (!string.IsNullOrEmpty(msg.ToString())) msg.Append(SEPARATOR);
                    msg.Append(ProcessConfig.PARTS_POS_CODE_MASTER_NAME);
                }
            }
            return msg.ToString();
        }

        /// <summary>
        /// マージ処理のログ用メッセージを取得します。
        /// </summary>
        /// <param name="status">リモートの処理結果</param>
        /// <param name="lstUsrUpdateData">IOfferMerge.WriteMergeData()に渡した更新リスト</param>
        /// <returns>"正常終了(○○件)" または リモートのエラーコード</returns>
        public static string GetMergedMessage(
            int status,
            ArrayList lstUsrUpdateData
        )
        {
            StringBuilder msg = new StringBuilder();
            {
                if (status.Equals((int)Result.RemoteStatus.Normal))
                {
                    int sum = 0;
                    if (!MergeChecker.IsNullOrEmptyArrayList(lstUsrUpdateData))
                    {
                        foreach (ArrayList itemList in lstUsrUpdateData)
                        {
                            sum += itemList.Count;
                        }
                    }
                    msg.Append("正常終了(").Append(sum).Append("件)");
                }
                else
                {
                    msg.Append("リモートエラー(status=").Append(status).Append(")");
                }
            }
            return msg.ToString();
        }

        /// <summary>価格改正</summary>
        public const string PRICE_REVISION = "価格改正";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        /// <param name="lstUsrUpdateData"></param>
        public static string GetPriceRevisionMessage(int status, ArrayList lstUsrUpdateData)
        {
            return GetMergedMessage(status, lstUsrUpdateData);
        }

        #endregion  // <文言/>
    }

    #endregion  // <ログ/>

    #region <買掛オプション/>

    /// <summary>
    /// 買掛オプションクラス
    /// </summary>
    public sealed class PurchaseOption
    {
        #region <検索タイプ/>

        /// <summary>検索タイプ</summary>
        private readonly int _searchPartsType = -1;
        /// <summary>
        /// 検索タイプを取得します。
        /// </summary>
        public int SearchPartsType { get { return _searchPartsType; } }

        /// <summary>
        /// 検索タイプを取得します。
        /// </summary>
        /// <returns>
        /// 基本提供データオプションチェックを行い、戻り値が0より大きい場合<c>10</c><br/>
        /// 外装提供データオプションチェックを行い、戻り値が0より大きい場合<c>20</c>
        /// </returns>
        private static int GetSearchPartsType()
        {
            int status = -1;  // ADD 2012/02/08

            // オプションチェック
            int checkedResult = (int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(
                ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_BasicOfferData   // 基本提供データオプション
            );
            if (checkedResult > 0)
            {
                //return 10; // DEL 2012/02/08
                status = 10; // ADD 2012/02/08
            }
            checkedResult = (int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(
                ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_OutsideOfferData // 外装提供データオプション
            );
            if (checkedResult > 0)
            {
                //return 20; // DEL 2012/02/08
                status = 20; // ADD 2012/02/08
            }

            //return -1;  //DEL 2012/02/08
            return status; // ADD 2012/02/08
        }

        #endregion  // <検索タイプ/>

        #region <大型オプション/>

        /// <summary>大型オプション</summary>
        private readonly int _bigCarOfferDiv = 0;
        /// <summary>
        /// 大型オプションを取得します。
        /// </summary>
        public int BigCarOfferDiv { get { return _bigCarOfferDiv; } }

        /// <summary>
        /// 大型オプションを取得します。
        /// </summary>
        /// <returns>
        /// 大型オプションチェックを行い、戻り値が0より大きい場合<c>1</c>、それ以外 <c>0</c>
        /// </returns>
        private static int GetBigCarOfferDiv()
        {
            // オプションチェック
            int checkedResult = (int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(
                ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_BigCarOfferData  // 大型オプション
            );
            return checkedResult > 0 ? 1 : 0;
        }

        #endregion  // <大型オプション/>

        #region <Constructor/>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public PurchaseOption()
        {
            _bigCarOfferDiv = GetBigCarOfferDiv();
            _searchPartsType= GetSearchPartsType();
        }

        #endregion  // <Constructor/>
    }

    #endregion  // <買掛オプション/>

    #region <ADO.NET/>

    /// <summary>
    /// ADO.NETのユーティリティ
    /// </summary>
    public static class ADOUtil
    {
        /// <summary>=キーワード</summary>
        public const string EQ = "=";

        /// <summary>＜＞キーワード</summary>
        public const string NOT_EQ = "<>";

        /// <summary>ANDキーワード</summary>
        public const string AND = " AND ";

        /// <summary>ORキーワード</summary>
        public const string OR = " OR ";

        /// <summary>降順のキーワード</summary>
        public const string DESC = " DESC";

        /// <summary>カンマキーワード</summary>
        public const string COMMA = ",";

        /// <summary>LIKEキーワード</summary>
        public const string LIKE = " LIKE ";

        /// <summary>ワイルドカードキーワード</summary>
        public const string WILD = "%";

        /// <summary>≧キーワード</summary>
        public const string LARGE_EQ = ">=";

        /// <summary>＞キーワード</summary>
        public const string LARGE = ">";

        /// <summary>≦キーワード</summary>
        public const string LESS_EQ = "<=";

        /// <summary>＜キーワード</summary>
        public const string LESS = "<";

        /// <summary>NOTキーワード</summary>
        public const string NOT = "<>";

        /// <summary>(キーワード</summary>
        public const string BEGIN_BLOCK = "(";

        /// <summary>)キーワード</summary>
        public const string END_BLOCK = ")";

        /// <summary>
        /// SQLの文字列値表記を取得します。
        /// </summary>
        /// <param name="val">文字列値</param>
        /// <returns>SQLの文字列値表記</returns>
        public static string GetString(string val)
        {
            return "'" + val + "'";
        }

        /// <summary>
        /// SQLの文字列値表記を取得します。
        /// </summary>
        /// <param name="number">数値</param>
        /// <returns>SQLの文字列値表記</returns>
        public static string GetString(int number)
        {
            return GetString(number.ToString());
        }

        /// <summary>
        /// SQLのワールドカード付き文字列表記を取得します。
        /// </summary>
        /// <param name="val">文字列値</param>
        /// <returns>SQLのワールドカード付き文字列表記</returns>
        public static string GetWild(string val)
        {
            return GetString(WILD + val + WILD);
        }

        /// <summary>
        /// DataRowの配列からDataTableを生成します。
        /// </summary>
        /// <typeparam name="TDataTable">DataTableの型</typeparam>
        /// <param name="dataRows">DataRowの配列</param>
        /// <returns>新しいDataTableのインスタンス</returns>
        public static TDataTable CreateDataTable<TDataTable>(DataRow[] dataRows) where TDataTable : DataTable, new()
        {
            TDataTable dataTable = new TDataTable();
            foreach (DataRow dataRow in dataRows)
            {
                dataTable.Rows.Add(dataRow.ItemArray);
            }
            return dataTable;
        }

        /// <summary>
        /// DataRow配列を型付きDataRow配列に変換します。
        /// </summary>
        /// <typeparam name="TDataRow">型付きDataRowの型</typeparam>
        /// <param name="dataRows">DataRow配列</param>
        /// <returns>型付きDataRow配列</returns>
        public static TDataRow[] ConvertAll<TDataRow>(DataRow[] dataRows) where TDataRow : DataRow
        {
            return Array.ConvertAll<DataRow, TDataRow>(dataRows, delegate(DataRow dataRow) { return (TDataRow)dataRow; });
        }
    }

    #endregion  // <ADO.NET/>

    #region <Pair/>

    /// <summary>
    /// 値のペアクラス
    /// </summary>
    /// <typeparam name="TFirst">1番目の値の型</typeparam>
    /// <typeparam name="TSecond">2番目の値の型</typeparam>
    public class Pair<TFirst, TSecond>
    {
        /// <summary>1番目の値</summary>
        private readonly TFirst _first;
        /// <summary>
        /// 1番目の値を取得します。
        /// </summary>
        /// <value>1番目の値</value>
        public TFirst First { get { return _first; } }

        /// <summary>2番目の値を取得します。</summary>
        private readonly TSecond _second;
        /// <summary>
        /// 2番目の値を取得します。
        /// </summary>
        /// <value>2番目の値</value>
        public TSecond Second { get { return _second; } }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="first">1番目の値</param>
        /// <param name="second">2番目の値</param>
        public Pair(
            TFirst first,
            TSecond second
        )
        {
            _first = first;
            _second = second;
        }

        #region <object override/>

        /// <summary>
        /// 文字列に変換します。
        /// </summary>
        /// <returns>文字列</returns>
        public override string ToString()
        {
            return First.ToString() + "," + Second.ToString();
        }

        #endregion  // <object override/>
    }

    #endregion  // <Pair/>

    #region <Singleton/>

    /// <summary>
    /// シングルトン化するクラス
    /// </summary>
    /// <typeparam name="T">シングルトンとするクラス</typeparam>
    public sealed class SingletonPolicy<T> where T : class, new()
    {
        #region <Singleton Idiom/>

        /// <summary>同期オブジェクト</summary>
        private static readonly object _syncRoot = new object();

        /// <summary>シングルトンインスタンス</summary>
        private static SingletonPolicy<T> _instance;
        /// <summary>
        /// シングルトンインスタンスを取得します。
        /// </summary>
        /// <value>シングルトンインスタンス</value>
        public static SingletonPolicy<T> Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new SingletonPolicy<T>();
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        private SingletonPolicy()
        {
            _policy = new T();
        }

        #endregion  // <Singleton Idiom/>

        /// <summary>シングルトンとするインスタンス</summary>
        private readonly T _policy;
        /// <summary>
        /// シングルトンとするインスタンスを取得します。
        /// </summary>
        /// <value>シングルトンとするインスタンス</value>
        public T Policy
        {
            get { return _policy; }
        }
    }

    #endregion  // <Singleton/>
}


//#define _CONST_OFFER_DATE_

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
//using System.Xml;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
//using Broadleaf.Library.Globarization;
using Broadleaf.Library.Collections;
//using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Controller.Util;    // ADD 2009/01/22 機能追加
using System.IO;

namespace Broadleaf.Application.Controller
{
    using ProcessConfigAcs = SingletonPolicy<ProcessConfig>;   // ADD 2009/01/30 機能追加
    using UserUpdatingPrimeSettingPair = Pair<ArrayList, ArrayList>;       // ADD 2009/02/03 機能追加
    using LatestPair = Pair<DateTime, int>;
    using Microsoft.Win32;              // ADD 2009/02/03 機能追加

    /// <summary>
    /// 提供マージアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 提供マージアクセス制御を行います。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.09.05</br>
    /// <br></br>
    /// <br>Update Note: BLコード更新区分の対応(MANTIS[0014775])</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2009/12/11</br>    
    /// <br></br>
    /// <br>Update Note: MANTIS[0014775]対応</br>
    /// <br>             ・セレクトコードがある部品は、優良設定を参照して価格セットする</br>
    /// <br>             ・同一提供日付、部品で複数価格マスタがあった場合も処理できるように修正</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2010/04/23</br>    
    /// <br></br>
    /// <br>Update Note: DC配置対応（負荷軽減対応）</br>
    /// <br>             ・リモートを10000件ずつ処理するので、アクセスクラスも対応する</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2010/06/14</br>    
    /// <br></br>
    /// <br>Update Note: 提供DB統合対応</br>
    /// <br>Programmer : 22008　長内 数馬</br>
    /// <br>Date       : 2010/06/19</br>    
    /// <br></br>
    /// <br>Update Note: 接続制限対応</br>
    /// <br>Programmer : 22008　長内 数馬</br>
    /// <br>Date       : 2010/07/02</br>    
    /// <br>Update Note: 層別更新不具合対応</br>
    /// <br>Programmer : 高峰</br>
    /// <br>Date       : 2012/06/26</br>  
    /// <br>Update Note: 品名が全角に更新されるの不具合対応</br>
    /// <br>Programmer : 高峰</br>
    /// <br>Date       : 2012/07/02</br> 
    /// <br>Update Note: BLコード更新不具合対応</br>
    /// <br>Programmer : 宮本</br>
    /// <br>Date       : 2013/01/31</br> 
    /// <br>Update Note: 2013/05/13 chenyd </br>
    /// <br>管理番号   : 10901273-00  2013/06/18配信分</br>
    /// <br>           : Redmine#35515 </br>
    /// <br>           : 提供データ更新処理 離島価格が反映されないの対応</br>
    /// <br>Update Note: 2014/08/21 songg </br>
    /// <br>管理番号   : 11070149-00 仕掛№1923 Redmine#35573</br>
    /// <br>           : 提供データ更新で「種類 'System.OutOfMemmoryException' の例外がスローされました。」のエラーが発生し、価格更新ができない。</br>
    /// <br>Update Note: 2017/07/18 脇田 靖之</br>
    /// <br>管理番号   : 11300429-00 Redmine#49037</br>
    /// <br>           : 提供データ更新で「種類 'System.OutOfMemmoryException' の例外がスローされました。」のエラーが発生し、価格更新ができない。</br>
    /// <br>Update Note: 2025/08/11 田村顕成</br>
    /// <br>管理番号   : 12170169-00</br>
    /// <br>           : 提供データの提供日付が未来の日付になっている不具合の救済対応</br>
    /// </remarks>
    public class OfferMergeAcs
    {
        #region Private Member

        /// <summary>自動時更新対象テーブル</summary>
        private IDictionary<string, LatestPair> _autopLatestDayDic;

        ///<summary>自動判別フラグ</summary>
        private int _autoFlg = 0;

        /// <summary>企業コード</summary>
        private string _enterpriseCode;

        /// <summary>提供データ更新設定</summary>
        private PriceChgSet _priceChgSet;

        // >>> ADD 2009/03/12 *** *** *** *** *** *** *** *** ***
        /// <summary>前回商品ワーク</summary>
        private GoodsUWork PriGoodsUWork = new GoodsUWork();

        // 2010/04/23 Del >>>
        ///// <summary>前回提供価格ワーク</summary>
        //private GoodsPriceUWork PriorOfrGoodsPriceUWork = new GoodsPriceUWork();

        ///// <summary>前回ユーザー価格ワーク</summary>
        //private GoodsPriceUWork PriorGoodsPriceUWork = new GoodsPriceUWork();

        ///// <summary>新規用価格ワーク</summary>
        //private GoodsPriceUWork writeGoodsPriseUwork = new GoodsPriceUWork();

        ///// <summary>削除用価格ワーク</summary>
        //private GoodsPriceUWork deleteGoodsPriceUWork = new GoodsPriceUWork();

        //private bool SkipFlg = false; // 同メーカー･品番の時に処理をスキップする
        //private bool FirstFlg = false; // 前回と違うメーカー品番のときに処理を走らせる。
        //private bool PriorDelflg = false; // 前回価格削除フラグ
        // 2010/04/23 Del <<<

        private ArrayList writeGoodsList = null; // 商品リスト(書込用)
        private ArrayList writePricesList = null; // 価格リスト(書込用)
        private ArrayList deletePriceList = null; // 価格リスト(削除用)

        private CustomSerializeArrayList lst = null; // ﾃﾞｰﾀ送信用価格改正ﾘｽﾄ

        private ArrayList userUpdatingPMakerList = null;             // ユーザー部品メーカー名称更新データリスト
        private ArrayList userUpdatingModelNameList = null;          // ユーザー車種マスタ更新データリスト
        private ArrayList userUpdatingGoodsMGroupList = null;        // ユーザー商品中分類マスタ更新データリスト
        private ArrayList userUpdatingBLGroupList = null;            // ユーザーBLコード更新データリスト
        private ArrayList userUpdatingTbsPartsCodeList = null;       // ユーザーBLグループマスタ更新データリスト
        private ArrayList userUpdatingPartsPosList = null;           // ユーザー部位マスタ更新データリスト

        private PriceRevisionParameter priceRevisionParameter = null;// 価格改正パラメータ

        private Dictionary<int, ArrayList> offerLstPrmSetChg = null; // 優良設定変更マスタ <offerDate,変更ﾘｽﾄ> 1.5次分 
        private Dictionary<int, ArrayList> offerLstPrmSet = null;    // 優良設定マスタ     <offerDate,設定ﾘｽﾄ> 1.5次分

        private CustomSerializeArrayList UsrUpdatePrmsetList = null;  // 優良設定マスタ更新リスト

        private PriceMergeSt pricMergeSt = null;                     // 提供データ更新設定

        private StreamWriter writer = null;                          // テキストログ用

        private int prmSetAllUpdCount = 0;

        private int partsPsDate = 0;                                 // 履歴用更新時部位マスタ提供日付

        private string workDir = string.Empty;
        // <<< ADD 2009/03/12 *** *** *** *** *** *** *** *** *** 

        //------------ ADD By chenyd 2013/05/13 For Redmine #35515------------------------->>>>>
        /// <summary>離島価格マスタテーブルアクセスクラス</summary>
        private IsolIslandPrcAcs _isolIslandPrcAcs;

        /// <summary>離島価格データクラス</summary>
        private static List<IsolIslandPrc> _isolIslandList;
        //------------ ADD By chenyd 2013/05/13 For Redmine #35515--------------------------<<<<<

        // ADD 2025/08/11 田村顕成 ----->>>>> 
        // スキップ対象日付リスト（固定値）
        // 提供データをスキップする対象日付をリストとして保持、今後追加が必要な場合は以下のリストを編集
        private readonly List<string> SkipOfferDates = new List<string>(
             new string[] { "20260701", "20260703", "20260704", "20260705", "20260706", "20260707" }
            );
        // スキップ対象期間（開始）
        private const int SkipOfferTermSt = 20250904;//2025年09月04日
        // スキップ対象期間（終了）
        private const int SkipOfferTermEd = 20260630;//2026年06月30日
        // スキップ対象日付リストに該当した前回提供日付
        string orgDate = string.Empty;
        // スキップ対象日付リスト以外の最新前回提供日付
        string candDate = string.Empty;
        // ADD 2025/08/11 田村顕成 -----<<<<< 

        /// <summary>マージデータの取得者</summary>
        private IMergeDataGet _iMergeDataGetter;
        // ADD 2009/02/02 機能追加：対象日付取得 ---------->>>>>
        /// <summary>
        /// マージデータの取得者を取得します。
        /// </summary>
        private IMergeDataGet MergeDataGetter
        {
            get
            {
                if (_iMergeDataGetter == null)
                {
                    _iMergeDataGetter = MediationMergeDataGetDB.GetRemoteObject();
                }
                return _iMergeDataGetter;
            }
        }
        // ADD 2008/02/02 機能追加：対象日付取得 ----------<<<<<

        /// <summary>マージの実行者</summary>
        private IOfferMerge _iOfferMerger;
        // ADD 2009/02/02 機能追加：対象日付取得 ---------->>>>>
        /// <summary>
        /// マージの実行者を取得します。
        /// </summary>
        private IOfferMerge OfferMerger
        {
            get
            {
                if (_iOfferMerger == null)
                {
                    _iOfferMerger = MediationOfferMergeDB.GetRemoteObject();
                }
                return _iOfferMerger;
            }
        }
        // ADD 2008/02/02 機能追加：対象日付取得 ----------<<<<<

        /// <summary>名称上書きフラグ</summary>        
        private bool _nameOverwriteFlg;

        //private List<string> lstPartsPos = null;

        // ADD 2009/01/22 機能追加：バージョンチェック ---------->>>>>
        /// <summary>マージのチェック者</summary>
        private readonly MergeChecker _checker = new MergeChecker();
        /// <summary>
        /// マージのチェック者を取得します。
        /// </summary>
        public MergeChecker Checker { get { return _checker; } }
        // ADD 2008/01/22 機能追加：バージョンチェック ----------<<<<<
        // ADD 2009/02/20 不具合対応[11708] ---------->>>>>
        /// <summary>買掛オプション</summary>
        private PurchaseOption _option;
        /// <summary>
        /// 買掛オプションを取得します。
        /// </summary>
        public PurchaseOption Option
        {
            get
            {
                if (_option == null)
                {
                    _option = new PurchaseOption();
                }
                return _option;
            }
        }
        // ADD 2009/02/20 不具合対応[11708] ----------<<<<<

        #endregion  // Private Member

        #region Constructor

        /// <summary>
        /// 提供マージアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 提供マージアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.09.05</br>
        /// </remarks>
        public OfferMergeAcs()
        {
            try
            {
                _myLogger = new MyLogWriter(this); // ADD 2009/02/10 機能追加：ログ出力
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
            }
        }

        #endregion  //  Constructor

        #region Public Methods

        #region [ 廃止メソッド ]

        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードを取得します。</br>
        /// </remarks>
        [Obsolete("廃止メソッドです。")]
        public int GetOnlineMode()
        {
            //if (this._iPartsPosCodeUDB == null)
            //{
            //    return (int)ConstantManagement.OnlineMode.Offline;
            //}
            //else
            //{
            return (int)ConstantManagement.OnlineMode.Online;
            //}
        }

        #endregion  // [廃止メソッド]

        /// <summary>
        /// 初期化（価格改正設定取得）
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns></returns>
        public int Initialize(string enterpriseCode)
        {
            int status = 0;
            PriceChgSetAcs _PriceChgSetAcs = new PriceChgSetAcs();
            status = _PriceChgSetAcs.Read(out _priceChgSet, enterpriseCode);
            if (_priceChgSet.NameUpdDiv == 1) // 0:する　1:しない
                _nameOverwriteFlg = false;
            else
                _nameOverwriteFlg = true;
            return status;
        }

        /// <summary>
        /// マージ時名称上書きするしないの設定取得
        /// </summary>
        /// <returns>true:上書きする false:上書きしない</returns>
        public bool NameOverwrite
        {
            get
            {
                return _nameOverwriteFlg;
            }
        }

        // ADD 2009/02/02 機能追加：対象件数 ---------->>>>>
        #region [ 処理順 ]

        /// <summary>処理順</summary>
        private readonly ProcessSequenceByDate _processSequence = new ProcessSequenceByDate();
        /// <summary>
        /// 処理順を取得します。
        /// </summary>
        public ProcessSequenceByDate ProcessSequence { get { return _processSequence; } }

        #endregion  // [ 処理順 ]

        #region <UI用/>

        /// <summary>
        /// 対象日付を取得し、処理順を設定します。（UI用）
        /// </summary>
        /// <param name="config">処理構成</param>
        /// <returns>リモートの対象日付取得メソッドにて内容を更新された処理構成</returns>
        [Obsolete("UI用に残してあるメソッド（ProcessConfigを用いたインターフェースを再設計）")]
        public ProcessConfig GetTargetAndSetProcessSequence(ProcessConfig config)
        {
            ProcessSequence.Clear();

            int blDate = ProcessConfigAcs.Instance.Policy.BLCodeMaster.ToPreviousDateNo();
            int groupDate = ProcessConfigAcs.Instance.Policy.BLGroupMaster.ToPreviousDateNo();
            int goodsMDate = ProcessConfigAcs.Instance.Policy.MiddleGenreMaster.ToPreviousDateNo();
            int modelNmDate = ProcessConfigAcs.Instance.Policy.ModelNameMaster.ToPreviousDateNo();
            int makerDate = ProcessConfigAcs.Instance.Policy.MakerMaster.ToPreviousDateNo();
            //int partsPosDate = ProcessConfigAcs.Instance.Policy.PartsPosCodeMaster.ToPreviousDateNo();
            int partsPosDate = 0;
            int ptmkPriceDate = ProcessConfigAcs.Instance.Policy.GoodsMaster.ToPreviousDateNo();
            int primPartsDate = ProcessConfigAcs.Instance.Policy.GoodsMaster.ToPreviousDateNo();
            int prmSetDate = ProcessConfigAcs.Instance.Policy.PrimeSettingMaster.ToPreviousDateNo();
            int prmSetChgDate = ProcessConfigAcs.Instance.Policy.PrimeSettingChangeMaster.ToPreviousDateNo();

            object objOfferDateList = null;
            int status = MergeDataGetter.GetOfferDate(
               blDate,                  // BLコードマスタ
               groupDate,               // BLグループマスタ
               goodsMDate,              // 中分類マスタ
               modelNmDate,             // 車種マスタ
               makerDate,               // メーカーマスタ
               partsPosDate,            // 部位マスタ
               ptmkPriceDate,           // 価格マスタ
               primPartsDate,           // 商品マスタ
               prmSetDate,              // 優良設定マスタ
               prmSetChgDate,           // 優良設定変更マスタ
               Option.SearchPartsType,  // ADD 2009/02/20 不具合対応[11708] 引数：検索タイプの追加
               Option.BigCarOfferDiv,   // ADD 2009/02/20 不具合対応[11708] 引数：大型オプションの追加
               out objOfferDateList
            );
            if (!status.Equals((int)Result.RemoteStatus.Normal) || status.Equals((int)Result.RemoteStatus.NotFound))
            {
                return ProcessConfigAcs.Instance.Policy;
            }

            ArrayList offerDateList = objOfferDateList as ArrayList;
            if (offerDateList == null || offerDateList.Count.Equals(0))
            {
                return ProcessConfigAcs.Instance.Policy;
            }

            foreach (PriceUpdManualDataWork offerDateInfo in (ArrayList)offerDateList)
            {
                #region <Debug/>

                Debug.Write(offerDateInfo.OfferDate);
                Debug.Write(", ");
                Debug.Write(offerDateInfo.ReNewOfferDate);
                Debug.Write(", ");
                Debug.Write(offerDateInfo.dataCnt);
                Debug.Write(", ");
                Debug.Write(offerDateInfo.allDatacnt);
                Debug.Write(", ");
                Debug.WriteLine(offerDateInfo.dataDiv);

                #endregion  // <Debug/>

                ProcessConfigItem configItem = ProcessConfigAcs.Instance.Policy[offerDateInfo.dataDiv];
                if (configItem != null)
                {
                    if (offerDateInfo.dataDiv != 7)
                        configItem.PresentCount = offerDateInfo.allDatacnt;
                    else
                        configItem.PresentCount += offerDateInfo.allDatacnt;
                }

                ProcessSequence.Add(offerDateInfo);
            }

            ProcessConfigAcs.Instance.Policy.UpdatePriceRevision();
            return ProcessConfigAcs.Instance.Policy;
        }

        #endregion  // <UI用/>

        /// <summary>
        /// 対象日付を取得し、処理順を設定します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>リモートの対象日付取得メソッドにて内容を更新された処理構成</returns>
        public ProcessConfig GetTargetAndSetProcessSequence(string enterpriseCode)
        {
            const string DATE_NUMBER_FORMAT = "yyyyMMdd";

            // 前回処理日と更新件数を取得し、前回処理日を各テーブルの対象日付として展開
            IDictionary<string, LatestPair> latestTableMap;

            if (_autoFlg == 0)
            {
                //latestTableMap = GetLatestHistoryMap(enterpriseCode);// DEL 2025/08/11 田村顕成
                // ADD 2025/08/11 田村顕成 ----->>>>>
                // 価格マスタの前回提供日付がSkipOfferDatesリストに該当する場合、該当しない最新の日付を
                // 取得する（実際の前回提供日付もorgDateで戻される）
                orgDate = string.Empty;
                candDate = string.Empty;
                latestTableMap = GetLatestHistoryMapWithSkip(enterpriseCode);
                // ADD 2025/08/11 田村顕成 -----<<<<< 
            }
            else
            {
                // ADD 2025/08/11 田村顕成 ----->>>>>
                // PMKHN09210U.exeでも実施するが、ここでもう一度手動時と同じくリストに該当しない最新日付を取得
                orgDate = string.Empty;
                candDate = string.Empty;
                latestTableMap = GetLatestHistoryMapWithSkip(enterpriseCode);
                // ADD 2025/08/11 田村顕成 -----<<<<< 
                //latestTableMap = _autopLatestDayDic;// DEL 2025/08/11 田村顕成
                //_autoFlg = 0;
            }

            #region <BLコードマスタ/>

            int blDate = ProcessConfigAcs.Instance.Policy.BLCodeMaster.ToPreviousDateNo();
            if (latestTableMap.ContainsKey(ProcessConfig.BL_CODE_MASTER_ID))
            {
                string strBLDate = latestTableMap[ProcessConfig.BL_CODE_MASTER_ID].First.ToString(DATE_NUMBER_FORMAT);
                blDate = int.Parse(strBLDate);
            }

            #endregion  // <BLコードマスタ/>

            #region <BLグループマスタ/>

            int groupDate = ProcessConfigAcs.Instance.Policy.BLGroupMaster.ToPreviousDateNo();
            if (latestTableMap.ContainsKey(ProcessConfig.BL_GROUP_MASTER_ID))
            {
                string strGroupDate = latestTableMap[ProcessConfig.BL_GROUP_MASTER_ID].First.ToString(DATE_NUMBER_FORMAT);
                groupDate = int.Parse(strGroupDate);
            }

            #endregion  // <BLグループマスタ/>

            #region <中分類コードマスタ/>

            int goodsMDate = ProcessConfigAcs.Instance.Policy.MiddleGenreMaster.ToPreviousDateNo();
            if (latestTableMap.ContainsKey(ProcessConfig.MIDDLE_GENRE_MASTER_ID))
            {
                string strGoodsMDate = latestTableMap[ProcessConfig.MIDDLE_GENRE_MASTER_ID].First.ToString(DATE_NUMBER_FORMAT);
                goodsMDate = int.Parse(strGoodsMDate);
            }

            #endregion  // <中分類コードマスタ/>

            #region <車種マスタ/>

            int modelNmDate = ProcessConfigAcs.Instance.Policy.ModelNameMaster.ToPreviousDateNo();
            if (latestTableMap.ContainsKey(ProcessConfig.MODEL_NAME_MASTER_ID))
            {
                string strModelNmDate = latestTableMap[ProcessConfig.MODEL_NAME_MASTER_ID].First.ToString(DATE_NUMBER_FORMAT);
                modelNmDate = int.Parse(strModelNmDate);
            }

            #endregion  // <車種マスタ/>

            #region <メーカーマスタ/>

            int makerDate = ProcessConfigAcs.Instance.Policy.MakerMaster.ToPreviousDateNo();
            if (latestTableMap.ContainsKey(ProcessConfig.MAKER_MASTER_ID))
            {
                string strMakerDate = latestTableMap[ProcessConfig.MAKER_MASTER_ID].First.ToString(DATE_NUMBER_FORMAT);
                makerDate = int.Parse(strMakerDate);
            }

            #endregion  // <メーカーマスタ/>

            #region <部位マスタ/>

            //int partsPosDate = ProcessConfigAcs.Instance.Policy.PartsPosCodeMaster.ToPreviousDateNo();
            int partsPosDate = 0;
            if (latestTableMap.ContainsKey(ProcessConfig.PARTS_POS_CODE_MASTER_ID))
            {
                //string strPartsPosDate = latestTableMap[ProcessConfig.PARTS_POS_CODE_MASTER_ID].First.ToString(DATE_NUMBER_FORMAT);
                //partsPosDate = int.Parse(strPartsPosDate);
            }

            #endregion  // <部位マスタ/>


            #region <価格マスタ/>

            int ptmkPriceDate = ProcessConfigAcs.Instance.Policy.GoodsMaster.ToPreviousDateNo();

            if (latestTableMap.ContainsKey(ProcessConfig.GOODS_PRICE_MASTER_ID))
            {
                string strPtmkPriceDate = latestTableMap[ProcessConfig.GOODS_MASTER_ID].First.ToString(DATE_NUMBER_FORMAT);
                ptmkPriceDate = int.Parse(strPtmkPriceDate);

            }

            #endregion  // <価格マスタ/>

            #region <商品マスタ/>

            int primPartsDate = ProcessConfigAcs.Instance.Policy.GoodsMaster.ToPreviousDateNo();

            if (latestTableMap.ContainsKey(ProcessConfig.GOODS_MASTER_ID))
            {
                string strPrimPartsDate = latestTableMap[ProcessConfig.GOODS_MASTER_ID].First.ToString(DATE_NUMBER_FORMAT);
                primPartsDate = int.Parse(strPrimPartsDate);
            }

            ptmkPriceDate = primPartsDate;

            #endregion  // <商品マスタ/>

            #region <優良設定マスタ/>

            int prmSetDate = ProcessConfigAcs.Instance.Policy.PrimeSettingMaster.ToPreviousDateNo();
            if (latestTableMap.ContainsKey(ProcessConfig.PRIME_SETTING_MASTER_ID))
            {
                string strPrmSetDate = latestTableMap[ProcessConfig.PRIME_SETTING_MASTER_ID].First.ToString(DATE_NUMBER_FORMAT);
                prmSetDate = int.Parse(strPrmSetDate);
            }

            #endregion  // <優良設定マスタ/>

            #region <優良設定変更マスタ/>

            int prmSetChgDate = ProcessConfigAcs.Instance.Policy.PrimeSettingChangeMaster.ToPreviousDateNo();
            if (latestTableMap.ContainsKey(ProcessConfig.PRIME_SETTING_CHANGE_MASTER_ID))
            {
                string strPrmSetChgDate = latestTableMap[ProcessConfig.PRIME_SETTING_CHANGE_MASTER_ID].First.ToString(DATE_NUMBER_FORMAT);
                prmSetChgDate = int.Parse(strPrmSetChgDate);
            }

            #endregion  // <優良設定変更マスタ/>

            // 提供日を取得
            object objOfferDateList = null;
            int status = MergeDataGetter.GetOfferDate(
               blDate,                  // BLコードマスタ
               groupDate,               // BLグループマスタ
               goodsMDate,              // 中分類マスタ
               modelNmDate,             // 車種マスタ
               makerDate,               // メーカーマスタ
               partsPosDate,            // 部位マスタ
               ptmkPriceDate,           // 価格マスタ
               primPartsDate,           // 商品マスタ
               prmSetDate,              // 優良設定マスタ
               prmSetChgDate,           // 優良設定変更マスタ
               Option.SearchPartsType,  // ADD 2009/02/20 不具合対応[11708] 引数：検索タイプの追加
               Option.BigCarOfferDiv,   // ADD 2009/02/20 不具合対応[11708] 引数：大型オプションの追加
               out objOfferDateList
            );
            if (!status.Equals((int)Result.RemoteStatus.Normal) || status.Equals((int)Result.RemoteStatus.NotFound))
            {
                return ProcessConfigAcs.Instance.Policy;
            }


            // ﾃｷｽﾄﾛｸﾞ書込み (対象日付取得)
            writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\PriceRevision.txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
            writer.Write(DateTime.Now + " 対象日付取得 " + "status=" + status + "\r\n");
            writer.Flush();
            if (writer != null) writer.Close();

            ArrayList offerDateList = objOfferDateList as ArrayList;
            if (offerDateList == null || offerDateList.Count.Equals(0))
            {
                return ProcessConfigAcs.Instance.Policy;
            }

            // 提供日による処理順を構築
            ProcessSequence.Clear();
            {
                foreach (PriceUpdManualDataWork offerDateInfo in (ArrayList)offerDateList)
                {
                    #region <Debug/>

                    Debug.Write(offerDateInfo.OfferDate);
                    Debug.Write(", ");
                    Debug.Write(offerDateInfo.ReNewOfferDate);
                    Debug.Write(", ");
                    Debug.Write(offerDateInfo.dataCnt);
                    Debug.Write(", ");
                    Debug.Write(offerDateInfo.allDatacnt);
                    Debug.Write(", ");
                    Debug.WriteLine(offerDateInfo.dataDiv);

                    #endregion  // <Debug/>


                    //部位マスタなら、対象日付リストに加えない
                    //if (offerDateInfo.dataDiv == 7)
                    //{
                    //    continue;
                    //}
                    ProcessConfigItem configItem = ProcessConfigAcs.Instance.Policy[offerDateInfo.dataDiv];
                    if (configItem != null)
                    {
                        configItem.PresentCount = offerDateInfo.allDatacnt;
                    }

                    ProcessSequence.Add(offerDateInfo);
                }
            }

            ProcessConfigAcs.Instance.Policy.UpdatePriceRevision();
            return ProcessConfigAcs.Instance.Policy;
        }
        
        // インストール日付取得
        //-- DEL 2010/06/19 ---------------------------------->>>
        //private DateTime GetInstallDate()
        //{
        //    RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\OFFER_AP\localhost\OFFER_DB");
        //    if (key == null)
        //    {
        //        return DateTime.MinValue;
        //    }
        //    string InstalOfferDate = key.GetValue("InstallOfferDate").ToString();
        //    int InstDateint = Int32.Parse(InstalOfferDate.Trim());

        //    DateTime instalOfferDate = DateTime.Parse(InstDateint.ToString("0000/00/00"));

        //    // インストール日付より1ヶ月前からマージ処理するため
        //    return instalOfferDate.AddMonths(-1);
        //}
        //-- DEL 2010/06/19 ----------------------------------<<<

        /// <summary>
        /// InstallOfferDateを取得します
        /// </summary>
        /// <param name="InstallOfferDate">インストール日付</param>
        /// <returns>InstallOfferDate</returns>
        public int getInstallDate(ref DateTime InstallOfferDate)
        {
            
            // -- UPD 2010/06/19 -------------------------------->>>
            //if (_iMergeDataGetter == null)
            //    _iMergeDataGetter = MediationMergeDataGetDB.GetRemoteObject();
            //_iMergeDataGetter.GetInstalDate(ref InstallOfferDate);

            InstallOfferDate = DateTime.Now.AddMonths(-1);
            // -- UPD 2010/06/19 --------------------------------<<<

            return 0;
        }

        /// <summary>
        /// 前回処理日と更新件数を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>対象テーブル名と前回処理日のマップ</returns>
        public IDictionary<string, LatestPair> GetLatestHistoryMap
            (string enterpriseCode)
        {
            object objLatestList = null;
            int status = OfferMerger.GetLatestHistory(enterpriseCode, out objLatestList);
            if (!status.Equals((int)Result.RemoteStatus.Normal) || objLatestList == null)
            {
                return new Dictionary<string, LatestPair>();
            }

            ArrayList latestList = objLatestList as ArrayList;
            if (latestList == null)
            {
                return new Dictionary<string, LatestPair>();
            }
            DateTime InstallOfferDate = DateTime.MinValue;
            // -- UPD 2010/06/19 ------------------------------->>>
            //if (_iMergeDataGetter == null)
            //    _iMergeDataGetter = MediationMergeDataGetDB.GetRemoteObject();
            //_iMergeDataGetter.GetInstalDate(ref InstallOfferDate);

            this.getInstallDate(ref InstallOfferDate);
            // -- UPD 2010/06/19 -------------------------------<<<
            IDictionary<string, LatestPair> latestMap = new Dictionary<string, LatestPair>();
            foreach (PriUpdTblUpdHisWork history in latestList)
            {
                string tableId = ConvertSyncTableNameToTableId(history.SyncTableName);
                if (!latestMap.ContainsKey(tableId))
                {
                    // 前回処理日
                    int offerDate = history.OfferDate;
                    DateTime dateTime = DateTime.MinValue;

                    if (!offerDate.Equals(0))
                    {
                        dateTime = DateTime.Parse(history.OfferDate.ToString("0000/00/00"));
                    }
                    // 初めて起動したら
                    else
                    {
                        // 優良･部位はﾚｼﾞｽﾄﾘより日付取得
                        if (tableId.Equals(ProcessConfig.PRIME_SETTING_MASTER_ID) || tableId.Equals(ProcessConfig.PARTS_POS_CODE_MASTER_ID) || tableId.Equals(ProcessConfig.GOODS_MASTER_ID))
                        {
                            dateTime = InstallOfferDate.AddMonths(-1);//GetInstallDate();
                        }
                        // その他はMinvalue
                        else
                        {
                            dateTime = DateTime.MinValue;
                        }
                    }

                    // 更新件数
                    int updatedCount = history.AddUpdateRowsNo;

                    latestMap.Add(tableId, new LatestPair(dateTime, updatedCount));
                    // 優良設定変更マスタ用
                    if (tableId.Equals(ProcessConfig.PRIME_SETTING_MASTER_ID))
                    {
                        latestMap.Add(ProcessConfig.PRIME_SETTING_CHANGE_MASTER_ID, new LatestPair(dateTime, updatedCount));
                    }
                }
            }


            // 価格改正用
            if (!latestMap.ContainsKey(ProcessConfig.GOODS_MASTER_ID))
            {
                latestMap.Add(ProcessConfig.GOODS_MASTER_ID, new LatestPair(InstallOfferDate.AddMonths(-1) /*GetInstallDate()*/ , 0));
            }
            //if (!latestMap.ContainsKey(ProcessConfig.GOODS_PRICE_MASTER_ID))
            //{
            //    latestMap.Add(ProcessConfig.GOODS_PRICE_MASTER_ID, new LatestPair(GetInstallDate(), 0));
            //}

            //string key = string.Empty;
            //if (latestMap[ProcessConfig.GOODS_MASTER_ID].First >= latestMap[ProcessConfig.GOODS_PRICE_MASTER_ID].First)
            //{
            //    key = ProcessConfig.GOODS_MASTER_ID;
            //}
            //else
            //{
            //    key = ProcessConfig.GOODS_PRICE_MASTER_ID;
            //}
            //latestMap.Add(ProcessConfig.PRICE_REVISION_ID, new LatestPair(latestMap[key].First, latestMap[key].Second));

            return latestMap;
        }


        // ADD 2025/08/11 田村顕成 ----->>>>> 
        /// <summary>
        /// スキップ対象日付を考慮して価格改正更新履歴をたどり、スキップ対象日付以外の前回処理日を取得します。
        /// </summary>
        public IDictionary<string, LatestPair> GetLatestHistoryMapWithSkip(string enterpriseCode)
        {
            orgDate = string.Empty;
            candDate = string.Empty;
            IDictionary<string, LatestPair> latestMap = GetLatestHistoryMap(enterpriseCode);
            Dictionary<string, LatestPair> newLatestMap = new Dictionary<string, LatestPair>(); 
            
            foreach (string key in latestMap.Keys)
            {
                string offerDateStr = latestMap[key].First.ToString("yyyyMMdd");
                // 価格マスタの前回提供日付がスキップ対象日付なら、スキップ対象外の最新日付を再取得する
                if (key == "GOODSURF")
                {
                    if (SkipOfferDates.Contains(offerDateStr))
                    {
                        // スキップ対象に該当した提供日付を保持
                        orgDate = offerDateStr;
                        // スキップ対象日に該当しない最新の履歴日付を取得する
                        DateTime newDate = GetPreviousValidOfferDate(enterpriseCode, key, offerDateStr);
                        candDate = newDate.ToString("yyyyMMdd");
                        newLatestMap.Add(key, new LatestPair(newDate, latestMap[key].Second));
                    }
                    else
                    {
                        orgDate = offerDateStr;
                        candDate = orgDate;
                        newLatestMap[key] = latestMap[key];
                    }
                }
                else
                {
                    newLatestMap[key] = latestMap[key];
                }
            }
            return newLatestMap;
        }


        /// <summary>
        /// スキップ対象外の日付が出るまで遡って履歴を検索し、スキップ直前の日付を取得します。
        /// </summary>
        private DateTime GetPreviousValidOfferDate(string enterpriseCode, string tableId, string currentDate)
        {
            object objHistory = null;
            bool isValid = true;
            DateTime newDate = DateTime.Today.AddMonths(-2);

            while (isValid)
            {
                // テーブルIDを指定して、スキップ対象外の最新履歴日付を取得する
                int status = OfferMerger.GetOtherHistories(enterpriseCode, currentDate, tableId, out objHistory);

                if (status != (int)Result.RemoteStatus.Normal || objHistory == null)
                {
                    return DateTime.Today.AddMonths(-2);//遡った履歴に有効なデータがない場合は現在の2か月前の日付を設定する
                }
                ArrayList DateList = objHistory as ArrayList;
                if (DateList.Count == 0) return DateTime.Today.AddMonths(-2);//遡った履歴に有効なデータがない場合は現在の2か月前の日付を設定する
                PriUpdTblUpdHisWork history = (PriUpdTblUpdHisWork)DateList[0];
                if (history.OfferDate == 0) return DateTime.Today.AddMonths(-2);//有効なデータが0の場合も現在の2か月前の日付を設定する
                string OfferDate = history.OfferDate.ToString();
                // 履歴の中からスキップ対象リストに含まれない最新データを返す
                if (!SkipOfferDates.Contains(OfferDate))
                {
                    string candOfferDate = history.OfferDate.ToString("0000/00/00");
                    return (DateTime.Parse(candOfferDate));
                }
                currentDate = OfferDate;
            }
            return DateTime.MinValue;
        }
        // ADD 2025/08/11 田村顕成 -----<<<<< 


        /// <summary>
        /// 
        /// </summary>
        /// <param name="syncTableName"></param>
        /// <returns></returns>
        private static string ConvertSyncTableNameToTableId(string syncTableName)
        {
            if (syncTableName.Equals("BLGROUPURF"))
            {
                return ProcessConfig.BL_GROUP_MASTER_ID;        // BLグループマスタ
            }
            if (syncTableName.Equals("GOODSGROUPURF"))
            {
                return ProcessConfig.MIDDLE_GENRE_MASTER_ID;    // 中分類マスタ
            }
            if (syncTableName.Equals("MODELNAMEURF"))
            {
                return ProcessConfig.MODEL_NAME_MASTER_ID;      // 車種マスタ
            }
            if (syncTableName.Equals("PARTSPOSCODEURF"))
            {
                return ProcessConfig.PARTS_POS_CODE_MASTER_ID;  // 部位マスタ
            }
            if (syncTableName.Equals("BLGOODSCDURF"))
            {
                return ProcessConfig.BL_CODE_MASTER_ID;         // BLコードマスタ
            }
            if (syncTableName.Equals("PRMSETTINGURF"))
            {
                return ProcessConfig.PRIME_SETTING_MASTER_ID;   // 優良設定マスタ
            }
            //if (syncTableName.Equals("GOODSMNGURF"))
            if (syncTableName.Equals("GOODSURF"))
            {
                return ProcessConfig.GOODS_MASTER_ID;           // 商品マスタ
            }
            if (syncTableName.Equals("PRICEURF"))
            {
                return ProcessConfig.GOODS_PRICE_MASTER_ID;     // 価格マスタ
            }
            if (syncTableName.Equals("MAKERURF"))
            {
                return ProcessConfig.MAKER_MASTER_ID;           // メーカーマスタ
            }

            return string.Empty;
        }
        // ADD 2008/02/02 機能追加：対象件数 ----------<<<<<

        /// <summary>
        /// 初期マージ処理[仮]
        /// </summary>
        /// <remarks>
        /// UIから呼び出し
        /// </remarks>
        /// <returns></returns>
        public int InitialMerge(MergeCond cond) // TODO:[更新]ボタンから呼び出し
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            int offerDate = 0; // 手動初期マージは提供日付0とする。
            status = DoMerge(offerDate, cond);
            return status;
        }

        #region [ 自動 ]

        /// <summary>
        /// 価格改正・提供マージ処理を行う。
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="offerDate"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        public int MergeOfferToUser(string enterpriseCode, int offerDate, IDictionary<string, LatestPair> dic)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            _autopLatestDayDic = dic;

            MergeCond cond = new MergeCond();
            cond.EnterpriseCode = enterpriseCode;
            cond.BLFlg = 1;
            cond.BLNmOwFlg = _nameOverwriteFlg;          // 名称上書きは価格改正設定に従う。
            cond.BLGroupFlg = 1;
            cond.BLGroupNmOwFlg = _nameOverwriteFlg;     // 名称上書きは価格改正設定に従う。
            cond.GoodsMGroupFlg = 1;
            cond.GoodsMGroupNmOwFlg = _nameOverwriteFlg; // 名称上書きは価格改正設定に従う。
            cond.ModelNameFlg = 1;
            cond.ModelNameNmOwFlg = _nameOverwriteFlg;   // 名称上書きは価格改正設定に従う。
            cond.PMakerFlg = 1;
            cond.PMakerNmOwFlg = _nameOverwriteFlg;      // 名称上書きは価格改正設定に従う。
            cond.PartsPosFlg = 0; // 部位マスタは提供データ配信による自動更新なし(対象外)
            cond.PartsPosNmOwFlg = _nameOverwriteFlg;    // 名称上書きは価格改正設定に従う。            

            // ADD 2009/02/20 不具合対応[11764] ---------->>>>>
            // 優良設定マスタ（提供）
            cond.PrmSetFlg = 1;
            cond.PrmSetNmOwFlg = _nameOverwriteFlg;
            // 優良設定変更マスタ
            cond.PrmSetChgFlg = 1;
            cond.PrmSetChgNmOwFlg = _nameOverwriteFlg;
            // 価格改正
            cond.PriceRevisionFlg = 1;
            cond.PriceRevisionNmOwFlg = _nameOverwriteFlg;
            // ADD 2009/02/20 不具合対応[11764] ----------<<<<<

            // 自動
            _autoFlg = 1;

            status = DoMerge(offerDate, cond);

            //if(status != 0 && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            return status;


            //status = PriceRevision(enterpriseCode, offerDate);

            //return status;
        }

        #endregion  // [ 自動 ]

        /// <summary>
        /// 価格改正履歴取得
        /// </summary>
        /// <param name="enterpriseCd">企業コード</param>
        /// <param name="HistStDate">履歴取得範囲「開始日」</param>
        /// <param name="HistEdDate">履歴取得範囲「終了日」</param>
        /// <param name="retList">価格改正履歴データリスト</param>
        /// <returns></returns>
        public int GetUpdateHistory(string enterpriseCd, int HistStDate, int HistEdDate, out ArrayList retList)
        {
            int status = 0;
            retList = new ArrayList();

            PriUpdHistCondWork cond = new PriUpdHistCondWork();
            object objList;

            if (_iOfferMerger == null)
                _iOfferMerger = MediationOfferMergeDB.GetRemoteObject();
            cond.EnterpriseCode = enterpriseCd;
            cond.StartDate = HistStDate;
            cond.EndDate = HistEdDate;
            status = _iOfferMerger.GetUpdateHistory(cond, out objList, 0, ConstantManagement.LogicalMode.GetData0);
            if (status != 0)
                return status;
            CustomSerializeArrayList List = objList as CustomSerializeArrayList;
            for (int i = 0; i < List.Count; i++)
            {
                PriUpdTblUpdHisWork histWork = List[i] as PriUpdTblUpdHisWork;
                PriUpdTblUpdHist hist = new PriUpdTblUpdHist();

                hist.CreateDateTime = histWork.CreateDateTime; // 作成日時
                hist.UpdateDateTime = histWork.UpdateDateTime; // 更新日時
                hist.EnterpriseCode = histWork.EnterpriseCode; // 企業コード
                hist.FileHeaderGuid = histWork.FileHeaderGuid; // GUID
                hist.UpdEmployeeCode = histWork.UpdEmployeeCode; // 更新従業員コード
                hist.UpdAssemblyId1 = histWork.UpdAssemblyId1; // 更新アセンブリID1
                hist.UpdAssemblyId2 = histWork.UpdAssemblyId2; // 更新アセンブリID2
                hist.LogicalDeleteCode = histWork.LogicalDeleteCode; // 論理削除区分
                hist.UpdateDataDiv = histWork.UpdateDataDiv; // 更新データ区分
                hist.DataUpdateDateTime = histWork.DataUpdateDateTime; // データ更新日時
                hist.SyncTableID = histWork.SyncTableID; // シンク対象テーブルID
                hist.SyncTableName = histWork.SyncTableName; // シンク対象テーブル名
                if (histWork.AddUpdateRowsNo >= 0)
                    hist.AddUpdateRowsNo = histWork.AddUpdateRowsNo.ToString(); // 追加更新行数
                else
                    hist.AddUpdateRowsNo = string.Format("エラー[{0}]", histWork.AddUpdateRowsNo);
                hist.SyncExecuteDate = histWork.SyncExecuteDate; // シンク実行日付
                hist.OfferDate = histWork.OfferDate; // 提供日付

                hist.OfferVersion = histWork.OfferVersion;  // ADD 2009/01/22 機能追加：カラム（提供バージョン）追加

                retList.Add(hist);
            }

            return status;
        }

        // --- ADD 2010/05/24 ---------->>>>>
        /// <summary>
        /// 価格改正履歴削除
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 削除処理を追加する</br>
        /// <br>Programmer : 朱俊成</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        public int DeleteHistory(ArrayList retList)
        {
            int status = 0;
            ArrayList historyList = new ArrayList();
            for (int i = 0; i < retList.Count; i++)
            {
                PriUpdTblUpdHist hist = retList[i] as PriUpdTblUpdHist;
                PriUpdTblUpdHisWork histWork = new PriUpdTblUpdHisWork();

                histWork.CreateDateTime = hist.CreateDateTime; // 作成日時
                histWork.UpdateDateTime = hist.UpdateDateTime; // 更新日時
                histWork.EnterpriseCode = hist.EnterpriseCode; // 企業コード
                histWork.FileHeaderGuid = hist.FileHeaderGuid; // GUID
                histWork.UpdEmployeeCode = hist.UpdEmployeeCode; // 更新従業員コード
                histWork.UpdAssemblyId1 = hist.UpdAssemblyId1; // 更新アセンブリID1
                histWork.UpdAssemblyId2 = hist.UpdAssemblyId2; // 更新アセンブリID2
                histWork.LogicalDeleteCode = hist.LogicalDeleteCode; // 論理削除区分
                histWork.UpdateDataDiv = hist.UpdateDataDiv; // 更新データ区分
                histWork.DataUpdateDateTime = hist.DataUpdateDateTime; // データ更新日時
                histWork.SyncTableID = hist.SyncTableID; // シンク対象テーブルID
                histWork.SyncTableName = hist.SyncTableName; // シンク対象テーブル名
                histWork.OfferVersion = hist.OfferVersion;  // 提供バージョン

                historyList.Add(histWork);
            }
            status = _iOfferMerger.DeleteHistory(historyList);
            return status;
        }
        // --- ADD 2010/05/24 -----------<<<<<



        /// <summary>
        /// 価格改正履歴の最新提供日付取得
        /// </summary>
        /// <param name="offerDate">最新提供日付</param>
        /// <returns></returns>
        public int GetLastOfferDate(out int offerDate)
        {
            if (_iOfferMerger == null)
                _iOfferMerger = MediationOfferMergeDB.GetRemoteObject();
            return _iOfferMerger.GetLastOfferDate(out offerDate);
        }

        #endregion  // Public Methods

        #region Private Methods

        // ADD 2009/02/12 機能追加：価格改正処理を手動で行う ---------->>>>>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="offerDate"></param>
        /// <returns></returns>
        [Obsolete("廃止メソッド")]
        private int PriceRevision(string enterpriseCode, int offerDate)
        {
            PriceRevisionParameter dummy = null;
            return PriceRevision(enterpriseCode, offerDate, out dummy);
        }

        /// <summary>
        /// 価格改正処理用パラメータクラス
        /// </summary>
        private class PriceRevisionParameter
        {
            #region <価格改正のマージリスト/>

            /// <summary>価格改正のマージリスト</summary>
            private CustomSerializeArrayList _mergedPriceRevisionList;
            /// <summary>
            /// 価格改正のマージリストを取得します。
            /// </summary>
            public CustomSerializeArrayList MergedPriceRevisionList
            {
                get
                {
                    if (_mergedPriceRevisionList == null)
                    {
                        _mergedPriceRevisionList = new CustomSerializeArrayList();
                    }
                    return _mergedPriceRevisionList;
                }
                set { _mergedPriceRevisionList = value; }
            }

            #endregion  // <価格改正のマージリスト/>

            /// <summary>価格改正処理の設定</summary>
            public PriceMergeSt PriceMergeSetting;

            /// <summary>戻り値用リスト</summary>
            public object RetList;

            #region <Constructor/>

            /// <summary>
            /// カスタムコンストラクタ
            /// </summary>
            public PriceRevisionParameter(string enterpriseCode)
            {
                PriceMergeSetting = new PriceMergeSt();
                {
                    PriceMergeSetting.EnterpriseCode = enterpriseCode;
                    PriceMergeSetting.NameMergeFlg = 0;
                    PriceMergeSetting.OpenPriceFlg = 0;
                    PriceMergeSetting.PriceManage = 0;
                    PriceMergeSetting.PriceMergeFlg = 0;
                    PriceMergeSetting.GoodsRankMergeFlg = 0;
                    // 2009/12/11 Add >>>
                    PriceMergeSetting.BLGoodeCdMergeFlg = 0;
                    // 2009/12/11 Add <<<
                }
            }

            #endregion  // <Constructor/>
        }
        // ADD 2009/02/12 機能追加：価格改正処理を手動で行う ----------<<<<<

        /// <summary>
        /// 価格改正処理を行う。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="offerDate"></param>
        /// <param name="priceRevisionParameter"></param>
        private int PriceRevision(string enterpriseCode, int offerDate, out PriceRevisionParameter priceRevisionParameter) // ADD 2009/02/12 機能追加：out PriceRevisionParameterを追加
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            priceRevisionParameter = new PriceRevisionParameter(enterpriseCode);    // ADD 2009/02/12 機能追加

            // ADD 2025/08/11 田村顕成 ----->>>>>
            string offerDateStr = offerDate.ToString("00000000");
            int prevOfferDate;
            if(orgDate.Equals(string.Empty))
            {
                // 有効な履歴日付がない場合（初めての更新等）は更新対象から外さないようにするため、0をセットする
                prevOfferDate = 0;
            }
            else
            {
                prevOfferDate = int.Parse(orgDate);
            }
            // 前回提供日付がスキップ対象期間　かつ　スキップ対象に該当したデータは更新対象から外す
            if ((prevOfferDate >= SkipOfferTermSt) && (prevOfferDate <= SkipOfferTermEd) && SkipOfferDates.Contains(offerDateStr))
            {
                return status;
            }
            // ADD 2025/08/11 田村顕成 -----<<<<<

            if (_iMergeDataGetter == null)
                _iMergeDataGetter = MediationMergeDataGetDB.GetRemoteObject();
            object retList = null;

            CustomSerializeArrayList lstOfferData;

            //if(lst == null) lst = new CustomSerializeArrayList();

            // ﾒｰｶｰﾘｽﾄ(ｵﾌﾞｼﾞｪｸﾄ)
            object makerobj = null;

            // ﾒｰｶｰ一覧取得
            status = _iMergeDataGetter.GetMakerInfo(offerDate, out makerobj);

            // ﾃｷｽﾄﾛｸﾞ書込み (ﾒｰｶｰ一覧取得)
            writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\PriceRevision.txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
            writer.Write(DateTime.Now + " ﾒｰｶｰ一覧取得 " + "対象ﾒｰｶｰ件数 " + ( makerobj as Dictionary<int, int> ).Count + "件" + "\r\n");
            writer.Flush();
            if (writer != null) writer.Close();

            // ﾒｰｶｰﾘｽﾄ取得でｴﾗｰ
            if (makerobj == null || ( status != 0 && status != 4 ))
            {
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            // ｷｬｽﾄ
            Dictionary<int, int> makerList = makerobj as Dictionary<int, int>;

            // 価格改正更新設定読み込み
            pricMergeSt = new PriceMergeSt();
            pricMergeSt.EnterpriseCode = enterpriseCode;                  // 企業コード
            pricMergeSt.NameMergeFlg = _priceChgSet.NameUpdDiv;         // 名称更新区分
            pricMergeSt.OpenPriceFlg = _priceChgSet.OpenPriceDiv;       // オープン価格区分
            pricMergeSt.PriceManage = _priceChgSet.PriceMngCnt;        // 価格管理件数
            pricMergeSt.PriceMergeFlg = _priceChgSet.PriceUpdDiv;        // 価格更新区分
            pricMergeSt.GoodsRankMergeFlg = _priceChgSet.PartsLayerUpdDiv;   // 層別更新区分
            // 2009/12/11 Add >>>
            pricMergeSt.BLGoodeCdMergeFlg = _priceChgSet.BLGoodsCdUpdDiv;    // BLコード更新区分
            // 2009/12/11 Add <<<

            // 価格マージ用フラグ
            // 2010/04/23 Del >>>
            //SkipFlg = false; // (private) 同メーカー･品番の時に処理をスキップする
            //FirstFlg = false; // (private) 前回と違うメーカー品番のときに処理を走らせる。
            //PriorDelflg = false; // (private) 前回価格削除フラグ
            // 2010/04/23 Del <<<
            
            // newは最初の1回だけ
            if (writeGoodsList == null) writeGoodsList = new ArrayList(); // 商品リスト(書込み用:private)
            if (writePricesList == null) writePricesList = new ArrayList(); // 価格リスト(書込み用:private)
            if (deletePriceList == null) deletePriceList = new ArrayList(); // 削除リスト(書込み用:private)
            if (_isolIslandList == null) _isolIslandList = new List<IsolIslandPrc>();// 離島価格リスト// ADD By chenyd 2013/05/13 For Redmine #35515
            // 離島価格リスト取得
            ReflectIsolIslandList(enterpriseCode, out _isolIslandList);// ADD By chenyd 2013/05/13 For Redmine #35515

            // ﾒｰｶｰﾙｰﾌﾟ 
            foreach (int _makerCd in makerList.Keys)
            {
                // DEL 2014/08/21 songg 仕掛№1923 ---->>>>>
                //// ﾕｰｻﾞｰ商品価格連結リスト
                //ArrayList UsrGoodsUnitList = null;
                //// 2010/04/23 Add >>>
                //object retObj;
                //List<PrmSettingUWork> prmSettingUWorkList = null;
                //// 2010/04/23 Add <<<

                //// ﾕｰｻﾞｰﾃﾞｰﾀ取得
                //// 2010/04/23 Add >>>
                ////status = _iOfferMerger.UsrJoinPartsSearch(enterpriseCode, _makerCd, out UsrGoodsUnitList);
                //UsrGoodsUnitList = new ArrayList();
                //status = _iOfferMerger.UsrPartsSearch(enterpriseCode, "00", _makerCd, out retObj);

                //if (retObj is CustomSerializeArrayList)
                //{
                //    CustomSerializeArrayList customList = (CustomSerializeArrayList)retObj;

                //    foreach (ArrayList al in customList)
                //    {
                //        if (al.Count > 0)
                //        {
                //            if (al[0] is PrmSettingUWork)
                //            {
                //                prmSettingUWorkList = new List<PrmSettingUWork>((PrmSettingUWork[])al.ToArray(typeof(PrmSettingUWork)));
                //            }
                //            else if (al[0] is GetUsrGoodsUnitDataWork)
                //            {
                //                UsrGoodsUnitList = al;
                //            }
                //        }
                //    }
                //}
                //// 2010/04/23 Add <<<

                //// ﾃｷｽﾄﾛｸﾞ書込み (ﾕｰｻﾞｰ商品価格ﾏｽﾀ取得)
                //writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\PriceRevision.txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                //writer.Write(DateTime.Now + " ﾕｰｻﾞｰ商品価格ﾃﾞｰﾀ取得 " + "対象ﾒｰｶｰ " + _makerCd + " 対象件数 " + UsrGoodsUnitList.Count + "件" + "\r\n");
                //writer.Flush();
                //if (writer != null) writer.Close();

                //// ﾕｰｻﾞｰﾃﾞｰﾀが無かったらマージしない
                //if (UsrGoodsUnitList.Count == 0 || UsrGoodsUnitList == null) continue;
                // DEL 2014/08/21 songg 仕掛№1923 ----<<<<<

                // ADD 2014/08/21 songg 仕掛№1923 ---->>>>>
                ArrayList goodsNoList = new ArrayList();
                ArrayList UsrGoodsUnitList = null;
                List<PrmSettingUWork> prmSettingUWorkList = null;
                // DEL 2017/07/18 y.wakita ---->>>>>
                //// 1:トヨタ　2：日産以外
                //if (!(_makerCd == 1 || _makerCd == 2))
                //{ 
                //    // ﾕｰｻﾞｰ商品価格連結リスト
                //    UsrGoodsUnitList = null;
                //    object retObj;
                //    prmSettingUWorkList = null;

                //    // ﾕｰｻﾞｰﾃﾞｰﾀ取得
                //    UsrGoodsUnitList = new ArrayList();
                //    status = _iOfferMerger.UsrPartsSearch(enterpriseCode, "00", _makerCd, goodsNoList, out retObj);

                //    if (retObj is CustomSerializeArrayList)
                //    {
                //        CustomSerializeArrayList customList = (CustomSerializeArrayList)retObj;

                //        foreach (ArrayList al in customList)
                //        {
                //            if (al.Count > 0)
                //            {
                //                if (al[0] is PrmSettingUWork)
                //                {
                //                    prmSettingUWorkList = new List<PrmSettingUWork>((PrmSettingUWork[])al.ToArray(typeof(PrmSettingUWork)));
                //                }
                //                else if (al[0] is GetUsrGoodsUnitDataWork)
                //                {
                //                    UsrGoodsUnitList = al;
                //                }
                //            }
                //        }
                //    }

                //    // ﾃｷｽﾄﾛｸﾞ書込み (ﾕｰｻﾞｰ商品価格ﾏｽﾀ取得)
                //    writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\PriceRevision.txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                //    writer.Write(DateTime.Now + " ﾕｰｻﾞｰ商品価格ﾃﾞｰﾀ取得 " + "対象ﾒｰｶｰ " + _makerCd + " 対象件数 " + UsrGoodsUnitList.Count + "件" + "\r\n");
                //    writer.Flush();
                //    if (writer != null) writer.Close();

                //    // ﾕｰｻﾞｰﾃﾞｰﾀが無かったらマージしない
                //    if (UsrGoodsUnitList.Count == 0 || UsrGoodsUnitList == null) continue;
                //}
                // DEL 2017/07/18 y.wakita ----<<<<<
                // ADD 2014/08/21 songg 仕掛№1923 ----<<<<<

                // 提供用前回品番
                string GoodsNo = string.Empty;
                string GoodsPriceNo = string.Empty;

                // ﾒｰｶｰ毎の対象件数
                int makerCnt = 0;
                // 提供件数の取得
                makerList.TryGetValue(_makerCd, out makerCnt);

                // 10万件ﾙｰﾌﾟを何回するか
                // 2010/06/14 >>>
                //int roupCount = makerCnt / 100000 + 1;
                int roupCount = makerCnt / 10000 + 1;
                // 2010/06/14 <<<

                // 提供データ上限10万件でﾙｰﾌﾟ
                for (int i = 0; i < roupCount; i++)
                {
                    // 提供データ取得
                    status = _iMergeDataGetter.GetGoodsInfo(offerDate, _makerCd, GoodsNo, GoodsPriceNo, out retList);

                    if (retList != null)
                    {
                        lstOfferData = (CustomSerializeArrayList)retList;

                        // 提供データ取得がエラーだったら、又は無かったら次のメーカー
                        if (status != 0 || lstOfferData.Count == 0)
                        {
                            continue;
                        }

                        // 提供リスト(部品価格･優良部品･優良価格)
                        ArrayList lstPtMkrPrice = null;
                        ArrayList lstPrimeParts = null;
                        ArrayList lstPrimePrice = null;

                        // 前回品番用
                        GoodsNo = string.Empty;
                        GoodsPriceNo = string.Empty;

                        // ADD 2014/08/21 songg 仕掛№1923 ---->>>>>
                        // 提供DBから、検索した品番より、提供品番リスト作成
                        // DEL 2017/07/18 y.wakita ---->>>>>
                        //if (_makerCd == 1 || _makerCd == 2)
                        //{
                        // DEL 2017/07/18 y.wakita ----<<<<<
                            goodsNoList = new ArrayList();
                        // DEL 2017/07/18 y.wakita ---->>>>>
                        //}
                        // DEL 2017/07/18 y.wakita ----<<<<<
                        // ADD 2014/08/21 songg 仕掛№1923 ----<<<<<

                        // リストの中身が純正か優良か判断 & 最後の品番を一時退避
                        for (int j = 0; j < lstOfferData.Count; j++)
                        {
                            switch (( (ArrayList)lstOfferData[j] )[0].GetType().Name)
                            {
                                case "PtMkrPriceWork": // 部品価格マスタ
                                    lstPtMkrPrice = lstOfferData[j] as ArrayList;
                                    GoodsNo = ( lstPtMkrPrice[( lstPtMkrPrice.Count - 1 )] as PtMkrPriceWork ).NewPrtsNoWithHyphen;
                                    // ADD 2014/08/21 songg 仕掛№1923 ---->>>>>
                                    // DEL 2017/07/18 y.wakita ---->>>>>
                                    //if (_makerCd == 1 || _makerCd == 2)
                                    //{
                                    // DEL 2017/07/18 y.wakita ----<<<<<
                                        for (int k = 0; k < lstPtMkrPrice.Count; k++)
                                        {
                                            // ADD 2025/08/11 田村顕成 ----->>>>>
                                            // 提供日付がスキップ対象の場合、スキップ対象に該当しない最新日付を提供データ日付として設定する
                                            if (SkipOfferDates.Contains(offerDateStr)) (lstPtMkrPrice[k] as PtMkrPriceWork).OfferDate = int.Parse(candDate);
                                            // ADD 2025/08/11 田村顕成 -----<<<<< 
                                            goodsNoList.Add((lstPtMkrPrice[k] as PtMkrPriceWork).NewPrtsNoWithHyphen);
                                        }
                                    // DEL 2017/07/18 y.wakita ---->>>>>
                                    //}
                                    // DEL 2017/07/18 y.wakita ----<<<<<
                                    // ADD 2014/08/21 songg 仕掛№1923 ----<<<<<
                                    break;

                                case "PrimePartsWork": // 優良部品マスタ
                                    lstPrimeParts = lstOfferData[j] as ArrayList;
                                    GoodsNo = ( lstPrimeParts[( lstPrimeParts.Count - 1 )] as PrimePartsWork ).PrimePartsNoWithH;
                                    // ADD 2014/08/21 songg 仕掛№1923 ---->>>>>
                                    // DEL 2017/07/18 y.wakita ---->>>>>
                                    //if (_makerCd == 1 || _makerCd == 2)
                                    //{
                                    // DEL 2017/07/18 y.wakita ----<<<<<
                                        for (int k = 0; k < lstPrimeParts.Count; k++)
                                        {
                                            // ADD 2025/08/11 田村顕成 ----->>>>>
                                            // 提供日付がスキップ対象の場合、スキップ対象に該当しない最新日付を提供データ日付として設定する
                                            if (SkipOfferDates.Contains(offerDateStr)) (lstPrimeParts[k] as PrimePartsWork).OfferDate = int.Parse(candDate);
                                            // ADD 2025/08/11 田村顕成 -----<<<<< 
                                            goodsNoList.Add((lstPrimeParts[k] as PrimePartsWork).PrimePartsNoWithH);
                                        }
                                    // DEL 2017/07/18 y.wakita ---->>>>>
                                    //}
                                    // DEL 2017/07/18 y.wakita ----<<<<<
                                    // ADD 2014/08/21 songg 仕掛№1923 ----<<<<<
                                    break;

                                case "PrmPrtPriceWork": // 優良価格マスタ
                                    lstPrimePrice = lstOfferData[j] as ArrayList;
                                    GoodsPriceNo = ( lstPrimePrice[( lstPrimePrice.Count - 1 )] as PrmPrtPriceWork ).PrimePartsNoWithH;
                                    // ADD 2014/08/21 songg 仕掛№1923 ---->>>>>
                                    // DEL 2017/07/18 y.wakita ---->>>>>
                                    //if (_makerCd == 1 || _makerCd == 2)
                                    //{
                                    // DEL 2017/07/18 y.wakita ----<<<<<
                                        for (int k = 0; k < lstPrimePrice.Count; k++)
                                        {
                                            // ADD 2025/08/11 田村顕成 ----->>>>>
                                            // 提供日付がスキップ対象の場合、スキップ対象に該当しない最新日付を提供データ日付として設定する
                                            if (SkipOfferDates.Contains(offerDateStr)) (lstPrimePrice[k] as PrmPrtPriceWork).OfferDate = int.Parse(candDate);
                                            // ADD 2025/08/11 田村顕成 -----<<<<< 
                                            goodsNoList.Add((lstPrimePrice[k] as PrmPrtPriceWork).PrimePartsNoWithH);
                                        }
                                    // DEL 2017/07/18 y.wakita ---->>>>
                                    //}
                                    // DEL 2017/07/18 y.wakita ----<<<<<
                                    // ADD 2014/08/21 songg 仕掛№1923 ----<<<<<
                                    break;
                            }
                        }

                        // ADD 2014/08/21 songg 仕掛№1923 ---->>>>>
                        // DEL 2017/07/18 y.wakita ---->>>>>
                        //// 1:トヨタ　2：日産
                        //if (_makerCd == 1 || _makerCd == 2)
                        //{
                        // DEL 2017/07/18 y.wakita ----<<<<<
                            #region ユーザーDBの情報取得
                            // ﾕｰｻﾞｰ商品価格連結リスト
                            UsrGoodsUnitList = null;

                            object retObj;
                            prmSettingUWorkList = null;

                            // ﾕｰｻﾞｰﾃﾞｰﾀ取得
                            UsrGoodsUnitList = new ArrayList();
                            status = _iOfferMerger.UsrPartsSearch(enterpriseCode, "00", _makerCd, goodsNoList, out retObj);

                            if (retObj is CustomSerializeArrayList)
                            {
                                CustomSerializeArrayList customList = (CustomSerializeArrayList)retObj;

                                foreach (ArrayList al in customList)
                                {
                                    if (al.Count > 0)
                                    {
                                        if (al[0] is PrmSettingUWork)
                                        {
                                            prmSettingUWorkList = new List<PrmSettingUWork>((PrmSettingUWork[])al.ToArray(typeof(PrmSettingUWork)));
                                        }
                                        else if (al[0] is GetUsrGoodsUnitDataWork)
                                        {
                                            UsrGoodsUnitList = al;
                                        }
                                    }
                                }
                            }

                            // ﾃｷｽﾄﾛｸﾞ書込み (ﾕｰｻﾞｰ商品価格ﾏｽﾀ取得)
                            writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\PriceRevision.txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                            writer.Write(DateTime.Now + " ﾕｰｻﾞｰ商品価格ﾃﾞｰﾀ取得 " + "対象ﾒｰｶｰ " + _makerCd + " 対象件数 " + UsrGoodsUnitList.Count + "件" + "\r\n");
                            writer.Flush();
                            if (writer != null) writer.Close();
                            #endregion

                            // ﾕｰｻﾞｰﾃﾞｰﾀが無かったらマージしない
                            if (UsrGoodsUnitList == null || UsrGoodsUnitList.Count == 0) continue;
                        
                        // DEL 2017/07/18 y.wakita ---->>>>>
                        //}
                        // DEL 2017/07/18 y.wakita ----<<<<<
                        // ADD 2014/08/21 songg 仕掛№1923 ----<<<<<

                        // ﾃｷｽﾄﾛｸﾞ書込み (提供商品価格ﾏｽﾀ取得)
                        string PriceSerchLogText = string.Empty;

                        if (lstPtMkrPrice != null) PriceSerchLogText += ( "提供日付" + offerDate + " 対象ﾒｰｶｰ " + _makerCd + " 対象件数(部品価格ﾏｽﾀ) " + lstPtMkrPrice.Count + "件" + "\r\n" );
                        if (lstPrimeParts != null) PriceSerchLogText += ( "提供日付" + offerDate + " 対象ﾒｰｶｰ " + _makerCd + " 対象件数(優良部品ﾏｽﾀ) " + lstPrimeParts.Count + "件" + "\r\n" );
                        if (lstPrimePrice != null) PriceSerchLogText += ( "提供日付" + offerDate + " 対象ﾒｰｶｰ " + _makerCd + " 対象件数(優良価格ﾏｽﾀ) " + lstPrimePrice.Count + "件" + "\r\n" );

                        writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\PriceRevision.txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                        writer.Write(DateTime.Now + " 提供商品価格ﾃﾞｰﾀ取得 \r\n" + PriceSerchLogText + "\r\n");
                        writer.Flush();
                        if (writer != null) writer.Close();

                        // 部品価格マスタ→商品･価格マスタ(純正)
                        if (lstPtMkrPrice != null && UsrGoodsUnitList != null)
                        {
                            // 2010/04/23 >>>
                            //CopytoPtmkPriceList(ref lstPtMkrPrice, ref UsrGoodsUnitList, pricMergeSt, ref writeGoodsList, ref writePricesList, ref deletePriceList);
                            CopytoPtmkPriceList(enterpriseCode, ref lstPtMkrPrice, ref UsrGoodsUnitList, pricMergeSt, ref writeGoodsList, ref writePricesList, ref deletePriceList);
                            // 2010/04/23 <<<
                        }
                        // 優良部品マスタ→商品･価格マスタ(優良)
                        if (( lstPrimeParts != null || lstPrimePrice != null ) && UsrGoodsUnitList != null)
                        {
                            // 2010/04/23 >>>
                            //CopytoPrimePartsList(ref lstPrimeParts, ref lstPrimePrice, ref UsrGoodsUnitList, pricMergeSt, ref writeGoodsList, ref writePricesList, ref deletePriceList);
                            CopytoPrimePartsList(enterpriseCode, prmSettingUWorkList, ref lstPrimeParts, ref lstPrimePrice, ref UsrGoodsUnitList, pricMergeSt, ref writeGoodsList, ref writePricesList, ref deletePriceList);
                            // 2010/04/23 <<<
                        }
                    }
                    else
                    {
                        retList = new CustomSerializeArrayList();
                    }
                }
                // ﾃｷｽﾄﾛｸﾞ書込み (更新価格改正リスト作成)
                writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\PriceRevision.txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                writer.Write(DateTime.Now + " 価格改正更新ﾘｽﾄ作成 " + "対象ﾒｰｶｰ " + _makerCd + " 商品ﾏｽﾀ更新件数 " + writeGoodsList.Count + "件 " + "価格ﾏｽﾀ更新件数 " + writePricesList.Count + "件" + "\r\n");
                writer.Flush();
                if (writer != null) writer.Close();
            }

            // 2010/04/23 Del >>>
            //if (writeGoodsPriseUwork.OfferDate != DateTime.MinValue)
            //{
            //    writePricesList.Add(writeGoodsPriseUwork);
            //    if (deleteGoodsPriceUWork.EnterpriseCode != "")
            //    {
            //        deletePriceList.Add(deleteGoodsPriceUWork);
            //    }
            //    // 書込･削除ワーククリア
            //    writeGoodsPriseUwork = new GoodsPriceUWork();
            //    deleteGoodsPriceUWork = new GoodsPriceUWork();
            //}
            // 2010/04/23 Del <<<

            //lst.Add(writeGoodsList);
            //lst.Add(writePricesList);
            //lst.Add(deletePriceList);

            #region DEL PM.NS1次分ロジック

            //int status = _iMergeDataGetter.GetGoodsInfo(offerDate, out retList);
            //lstOfferData = (CustomSerializeArrayList)retList;
            //if (status != 0)
            //{

            //    MyLogger.Write(MyLogWriter.PRICE_REVISION, "商品情報取得", MyLogWriter.GetPriceRevisionMessage(status, null));  // ADD 2009/02/10 機能追加：ログ出力
            //    return status;
            //}
            //if (lstOfferData.Count == 0) // 商品・価格の更新はなかった場合、なにもせず終了
            //{
            //    MyLogger.Write(MyLogWriter.PRICE_REVISION, "商品情報取得", MyLogWriter.GetPriceRevisionMessage(status, new ArrayList()));   // ADD 2009/02/10 機能追加：ログ出力
            //    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            //}

            //ArrayList lstPtMkrPrice = null;
            //ArrayList lstPrimeParts = null;
            //ArrayList lstPrimePrice = null;

            //for (int i = 0; i < lstOfferData.Count; i++)
            //{
            //    switch (((ArrayList)lstOfferData[i])[0].GetType().Name)
            //    {
            //        case "PtMkrPriceWork":
            //            lstPtMkrPrice = lstOfferData[i] as ArrayList;          // 部品価格マスタ
            //            break;
            //        case "PrimePartsWork":
            //            lstPrimeParts = lstOfferData[i] as ArrayList;          // 優良部品マスタ
            //            break;
            //        case "PrmPrtPriceWork":
            //            lstPrimePrice = lstOfferData[i] as ArrayList;          // 優良価格マスタ
            //            break;
            //    }
            //}

            //// *** ディクショナリ内構図 *** *** *** *** *** *** *** *** *** *** ***
            ////
            //// dicPriceUpdate<GoodsMakerCD,lstMaker>     [大枠]
            //// │
            //// ├lstMaker(※CashList)       [メーカー毎のアレイリスト]
            //// │├lstGoods (商品マスタ)    [純正の場合は部品価格マスタより取得]
            //// │└lstPrices(価格マスタ)    [純正の場合は部品価格マスタより取得]
            //// │
            //// ├lstMaker(※CashList)       [メーカー毎のアレイリスト]
            //// │├lstGoods (商品マスタ)    [優良の場合は優良部品マスタより取得]
            //// │└lstPrices(価格マスタ)    [優良の場合は優良価格マスタより取得]
            ////          : 
            ////          :                   [以下あるだけ]
            ////
            //// *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** ***

            //// 2009/02/27　改訂版ロジック
            //ArrayList lstMaker = new ArrayList();   // メーカー毎のリスト
            //ArrayList lstGoods = new ArrayList();   // とりあえず商品リスト　後で変更
            //ArrayList lstPrices = new ArrayList();　// とりあえず価格リスト　後で変更
            //ArrayList lstDummy = new ArrayList();
            //Dictionary<int, ArrayList> dicPriceUpdate = new Dictionary<int, ArrayList>(); // 大枠
            //int GoodsMakerCd = 0;

            //// 部品価格マスタ
            //#region
            //if (lstPtMkrPrice != null)
            //{
            //    lstGoods = new ArrayList();
            //    lstPrices = new ArrayList();
            //    lstMaker = new ArrayList();

            //    foreach (PtMkrPriceWork PtMkrPriceWork in lstPtMkrPrice)
            //    {
            //        // ﾃﾞｨｸｼｮﾅﾘに既にメーカーのリストがあれば
            //        if (dicPriceUpdate.ContainsKey(PtMkrPriceWork.MakerCode) == true)
            //        {
            //            //メーカー内のリストで回す
            //            foreach (ArrayList CashList in dicPriceUpdate[PtMkrPriceWork.MakerCode])
            //            {
            //                // 商品マスタマージ
            //                if (CashList[0] is GoodsUWork)
            //                {
            //                    GoodsUWork GoodsUWork = new GoodsUWork();

            //                    GoodsUWork.GoodsMakerCd = PtMkrPriceWork.MakerCode;
            //                    GoodsUWork.GoodsNo = PtMkrPriceWork.NewPrtsNoWithHyphen;
            //                    GoodsUWork.GoodsNoNoneHyphen = PtMkrPriceWork.NewPrtsNoNoneHyphen;
            //                    GoodsUWork.GoodsName = PtMkrPriceWork.MakerOfferPartsName;
            //                    GoodsUWork.GoodsNameKana = PtMkrPriceWork.MakerOfferPartsKana;
            //                    GoodsUWork.GoodsRateRank = PtMkrPriceWork.PartsLayerCd;
            //                    GoodsUWork.TaxationDivCd = 0; // 外税 固定値
            //                    GoodsUWork.GoodsKindCode = 0; // 純正 固定値
            //                    GoodsUWork.OfferDataDiv = 1;  // 提供区分１：提供
            //                    GoodsUWork.OfferDate = ConverIntToDateTime(PtMkrPriceWork.OfferDate);
            //                    GoodsUWork.UpdateDate = ConverIntToDateTime(PtMkrPriceWork.OfferDate);

            //                    CashList.Add(GoodsUWork);
            //                }
            //                // 価格マスタマージ
            //                else if (CashList[0] is GoodsPriceUWork)
            //                {
            //                    GoodsPriceUWork GoodsPriceUWork = new GoodsPriceUWork();

            //                    GoodsPriceUWork.GoodsMakerCd = PtMkrPriceWork.MakerCode;
            //                    GoodsPriceUWork.GoodsNo = PtMkrPriceWork.NewPrtsNoWithHyphen;
            //                    GoodsPriceUWork.ListPrice = PtMkrPriceWork.PartsPrice;
            //                    GoodsPriceUWork.PriceStartDate = ConverIntToDateTime(PtMkrPriceWork.PartsPriceStDate);
            //                    GoodsPriceUWork.OpenPriceDiv = PtMkrPriceWork.OpenPriceDiv;
            //                    GoodsPriceUWork.OfferDate = ConverIntToDateTime(PtMkrPriceWork.OfferDate);
            //                    GoodsPriceUWork.UpdateDate = ConverIntToDateTime(PtMkrPriceWork.OfferDate);

            //                    CashList.Add(GoodsPriceUWork);
            //                }
            //                // エラー
            //                else
            //                {
            //                    return 9;
            //                }

            //            }
            //        }
            //        // ﾃﾞｨｸｼｮﾅﾘにﾒｰｶｰのリストがなければ
            //        else
            //        {
            //            lstGoods = new ArrayList();
            //            lstPrices = new ArrayList();
            //            lstMaker = new ArrayList();

            //            GoodsUWork GoodsUWork = new GoodsUWork();

            //            GoodsUWork.GoodsMakerCd = PtMkrPriceWork.MakerCode;
            //            GoodsUWork.GoodsNo = PtMkrPriceWork.NewPrtsNoWithHyphen;
            //            GoodsUWork.GoodsNoNoneHyphen = PtMkrPriceWork.NewPrtsNoNoneHyphen;
            //            GoodsUWork.GoodsName = PtMkrPriceWork.MakerOfferPartsName;
            //            GoodsUWork.GoodsNameKana = PtMkrPriceWork.MakerOfferPartsKana;
            //            GoodsUWork.GoodsRateRank = PtMkrPriceWork.PartsLayerCd;
            //            GoodsUWork.TaxationDivCd = 0; // 外税 固定値
            //            GoodsUWork.GoodsKindCode = 0; // 純正 固定値
            //            GoodsUWork.OfferDataDiv = 1;  // 提供区分１：提供
            //            GoodsUWork.OfferDate = ConverIntToDateTime(PtMkrPriceWork.OfferDate);
            //            GoodsUWork.UpdateDate = ConverIntToDateTime(PtMkrPriceWork.OfferDate);

            //            lstGoods.Add(GoodsUWork);

            //            GoodsPriceUWork GoodsPriceUWork = new GoodsPriceUWork();

            //            GoodsPriceUWork.GoodsMakerCd = PtMkrPriceWork.MakerCode;
            //            GoodsPriceUWork.GoodsNo = PtMkrPriceWork.NewPrtsNoWithHyphen;
            //            GoodsPriceUWork.ListPrice = PtMkrPriceWork.PartsPrice;
            //            GoodsPriceUWork.PriceStartDate = ConverIntToDateTime(PtMkrPriceWork.PartsPriceStDate);
            //            GoodsPriceUWork.OpenPriceDiv = PtMkrPriceWork.OpenPriceDiv;
            //            GoodsPriceUWork.OfferDate = ConverIntToDateTime(PtMkrPriceWork.OfferDate);
            //            GoodsPriceUWork.UpdateDate = ConverIntToDateTime(PtMkrPriceWork.OfferDate);

            //            lstPrices.Add(GoodsPriceUWork);

            //            lstMaker.Add(lstGoods);
            //            lstMaker.Add(lstPrices);

            //            dicPriceUpdate.Add(GoodsUWork.GoodsMakerCd, lstMaker);
            //        }
            //    }
            //}
            //#endregion

            ////優良部品マスタ
            //#region
            //if (lstPrimeParts != null)
            //{
            //    lstGoods = new ArrayList();
            //    lstMaker = new ArrayList();
            //    lstDummy = new ArrayList();

            //    foreach (PrimePartsWork PrimePartsWork in lstPrimeParts)
            //    {
            //        // ﾃﾞｨｸｼｮﾅﾘに既にメーカーのリストがあれば
            //        if (dicPriceUpdate.ContainsKey(PrimePartsWork.PartsMakerCd) == true)
            //        {
            //            GoodsMakerCd = PrimePartsWork.PartsMakerCd;
            //            //メーカー内のリストで回す
            //            foreach (ArrayList CashList in dicPriceUpdate[PrimePartsWork.PartsMakerCd])
            //            {
            //                // 商品マスタマージ
            //                if (CashList[0] is GoodsUWork)
            //                {
            //                    // GoodsUWorkがある場合
            //                    GoodsUWork GoodsUWork = new GoodsUWork();

            //                    GoodsUWork.GoodsMakerCd = PrimePartsWork.PartsMakerCd;
            //                    GoodsUWork.GoodsNo = PrimePartsWork.PrimePartsNoWithH;
            //                    GoodsUWork.GoodsNoNoneHyphen = PrimePartsWork.PrimePartsNoNoneH;
            //                    GoodsUWork.GoodsName = PrimePartsWork.PrimePartsName;
            //                    GoodsUWork.GoodsNameKana = PrimePartsWork.PrimePartsKanaNm;
            //                    GoodsUWork.GoodsRateRank = PrimePartsWork.PartsLayerCd;
            //                    GoodsUWork.TaxationDivCd = 0; // 外税 固定値
            //                    GoodsUWork.GoodsKindCode = 1; // その他 固定値
            //                    GoodsUWork.OfferDataDiv = 1; // 提供区分１：提供
            //                    GoodsUWork.OfferDate = ConverIntToDateTime(PrimePartsWork.OfferDate);
            //                    GoodsUWork.UpdateDate = ConverIntToDateTime(PrimePartsWork.OfferDate);

            //                    lstGoods.Add(GoodsUWork);
            //                }
            //                else
            //                {
            //                    // メーカーはあるけどGoodsUWorkがない場合
            //                    //lstGoods = new ArrayList();
            //                    GoodsUWork GoodsUWork = new GoodsUWork();

            //                    GoodsUWork.GoodsMakerCd = PrimePartsWork.PartsMakerCd;
            //                    GoodsUWork.GoodsNo = PrimePartsWork.PrimePartsNoWithH;
            //                    GoodsUWork.GoodsNoNoneHyphen = PrimePartsWork.PrimePartsNoNoneH;
            //                    GoodsUWork.GoodsName = PrimePartsWork.PrimePartsName;
            //                    GoodsUWork.GoodsNameKana = PrimePartsWork.PrimePartsKanaNm;
            //                    GoodsUWork.GoodsRateRank = PrimePartsWork.PartsLayerCd;
            //                    GoodsUWork.TaxationDivCd = 0; // 外税 固定値
            //                    GoodsUWork.GoodsKindCode = 1; // その他 固定値
            //                    GoodsUWork.OfferDataDiv = 1; // 提供区分１：提供
            //                    GoodsUWork.OfferDate = ConverIntToDateTime(PrimePartsWork.OfferDate);
            //                    GoodsUWork.UpdateDate = ConverIntToDateTime(PrimePartsWork.OfferDate);

            //                    lstGoods.Add(GoodsUWork);
            //                    lstDummy.Add(lstGoods);
            //                }
            //            }
            //        }
            //        else
            //        {
            //            // メーカーないよ
            //            lstGoods = new ArrayList();
            //            lstMaker = new ArrayList();

            //            GoodsUWork GoodsUWork = new GoodsUWork();

            //            GoodsUWork.GoodsMakerCd = PrimePartsWork.PartsMakerCd;
            //            GoodsUWork.GoodsNo = PrimePartsWork.PrimePartsNoWithH;
            //            GoodsUWork.GoodsNoNoneHyphen = PrimePartsWork.PrimePartsNoNoneH;
            //            GoodsUWork.GoodsName = PrimePartsWork.PrimePartsName;
            //            GoodsUWork.GoodsNameKana = PrimePartsWork.PrimePartsKanaNm;
            //            GoodsUWork.GoodsRateRank = PrimePartsWork.PartsLayerCd;
            //            GoodsUWork.TaxationDivCd = 0; // 外税 固定値
            //            GoodsUWork.GoodsKindCode = 1; // その他 固定値
            //            GoodsUWork.OfferDataDiv = 1; // 提供区分１：提供
            //            GoodsUWork.OfferDate = ConverIntToDateTime(PrimePartsWork.OfferDate);
            //            GoodsUWork.UpdateDate = ConverIntToDateTime(PrimePartsWork.OfferDate);

            //            lstGoods.Add(GoodsUWork);
            //            lstMaker.Add(lstGoods);
            //            dicPriceUpdate.Add(GoodsUWork.GoodsMakerCd, lstMaker);
            //        }
            //    }
            //    if (lstMaker.Count == 0)
            //    {
            //        dicPriceUpdate[GoodsMakerCd].Add(lstGoods);
            //    }
            //}
            //#endregion

            //// 優良価格
            //#region
            //if (lstPrimePrice != null)
            //{
            //    lstPrices = new ArrayList();
            //    lstMaker = new ArrayList();

            //    foreach (PrmPrtPriceWork PrmPrtPriceWork in lstPrimePrice)
            //    {
            //        lstPrices = new ArrayList();
            //        // ﾃﾞｨｸｼｮﾅﾘに既にメーカーのリストがあれば
            //        if (dicPriceUpdate.ContainsKey(PrmPrtPriceWork.PartsMakerCd) == true)
            //        {
            //            GoodsMakerCd = PrmPrtPriceWork.PartsMakerCd;

            //            ArrayList dictionaryList = new ArrayList();
            //            // メーカーのリストを取り出す
            //            dictionaryList = dicPriceUpdate[PrmPrtPriceWork.PartsMakerCd] as ArrayList;

            //            // 商品・価格の両方入ってる
            //            if (dictionaryList.Count == 2)
            //            {
            //                ArrayList dic1 = dictionaryList[0] as ArrayList;
            //                ArrayList dic2 = dictionaryList[1] as ArrayList;
            //                GoodsPriceUWork GoodsPriceUWork = new GoodsPriceUWork();

            //                GoodsPriceUWork.GoodsMakerCd = PrmPrtPriceWork.PartsMakerCd;
            //                GoodsPriceUWork.GoodsNo = PrmPrtPriceWork.PrimePartsNoWithH;
            //                GoodsPriceUWork.ListPrice = PrmPrtPriceWork.NewPrice;
            //                GoodsPriceUWork.PriceStartDate = ConverIntToDateTime(PrmPrtPriceWork.PriceStartDate);
            //                GoodsPriceUWork.OpenPriceDiv = PrmPrtPriceWork.OpenPriceDiv;
            //                GoodsPriceUWork.OfferDate = ConverIntToDateTime(PrmPrtPriceWork.OfferDate);
            //                GoodsPriceUWork.UpdateDate = ConverIntToDateTime(PrmPrtPriceWork.OfferDate);
            //                if (dic1[0] is GoodsPriceUWork)
            //                {
            //                    dic1.Add(GoodsPriceUWork);
            //                }
            //                else if (dic2[0] is GoodsPriceUWork)
            //                {
            //                    dic2.Add(GoodsPriceUWork);
            //                }
            //            }
            //            // どっちかしか入っていない
            //            else
            //            {
            //                ArrayList dic3 = dictionaryList[0] as ArrayList;
            //                GoodsPriceUWork GoodsPriceUWork = new GoodsPriceUWork();

            //                GoodsPriceUWork.GoodsMakerCd = PrmPrtPriceWork.PartsMakerCd;
            //                GoodsPriceUWork.GoodsNo = PrmPrtPriceWork.PrimePartsNoWithH;
            //                GoodsPriceUWork.ListPrice = PrmPrtPriceWork.NewPrice;
            //                GoodsPriceUWork.PriceStartDate = ConverIntToDateTime(PrmPrtPriceWork.PriceStartDate);
            //                GoodsPriceUWork.OpenPriceDiv = PrmPrtPriceWork.OpenPriceDiv;
            //                GoodsPriceUWork.OfferDate = ConverIntToDateTime(PrmPrtPriceWork.OfferDate);
            //                GoodsPriceUWork.UpdateDate = ConverIntToDateTime(PrmPrtPriceWork.OfferDate);

            //                lstPrices.Add(GoodsPriceUWork);

            //                // 商品マスタが入っていた場合は新しく価格マスタを作成
            //                if (dic3[0] is GoodsUWork)
            //                {
            //                    dictionaryList.Add(lstPrices);
            //                }
            //            }
            //        }
            //        else
            //        {
            //            // メーカーないよ
            //            lstPrices = new ArrayList();
            //            lstMaker = new ArrayList();
            //            GoodsPriceUWork GoodsPriceUWork = new GoodsPriceUWork();

            //            GoodsPriceUWork.GoodsMakerCd = PrmPrtPriceWork.PartsMakerCd;
            //            GoodsPriceUWork.GoodsNo = PrmPrtPriceWork.PrimePartsNoWithH;
            //            GoodsPriceUWork.ListPrice = PrmPrtPriceWork.NewPrice;
            //            GoodsPriceUWork.PriceStartDate = ConverIntToDateTime(PrmPrtPriceWork.PriceStartDate);
            //            GoodsPriceUWork.OpenPriceDiv = PrmPrtPriceWork.OpenPriceDiv;
            //            GoodsPriceUWork.OfferDate = ConverIntToDateTime(PrmPrtPriceWork.OfferDate);
            //            GoodsPriceUWork.UpdateDate = ConverIntToDateTime(PrmPrtPriceWork.OfferDate);

            //            lstPrices.Add(GoodsPriceUWork);
            //            lstMaker.Add(lstPrices);

            //            dicPriceUpdate.Add(GoodsPriceUWork.GoodsMakerCd, lstMaker);
            //        }
            //    }
            //}
            //#endregion

            //#region

            ////// ↓旧ロジック


            ////ArrayList lstGoods = new ArrayList();
            ////ArrayList lstPrices = new ArrayList();
            ////if (lstPtMkrPrice != null)
            ////{
            ////    foreach (PtMkrPriceWork PtMkrPriceWork in lstPtMkrPrice)
            ////    {
            ////        GoodsUWork GoodsUWork = new GoodsUWork();

            ////        GoodsUWork.GoodsMakerCd = PtMkrPriceWork.MakerCode;
            ////        GoodsUWork.GoodsNo = PtMkrPriceWork.NewPrtsNoWithHyphen;
            ////        GoodsUWork.GoodsNoNoneHyphen = PtMkrPriceWork.NewPrtsNoNoneHyphen;
            ////        GoodsUWork.GoodsName = PtMkrPriceWork.MakerOfferPartsName;
            ////        GoodsUWork.GoodsNameKana = PtMkrPriceWork.MakerOfferPartsKana;
            ////        GoodsUWork.GoodsRateRank = PtMkrPriceWork.PartsLayerCd;
            ////        GoodsUWork.TaxationDivCd = 0; // 外税 固定値
            ////        GoodsUWork.GoodsKindCode = 0; // 純正 固定値
            ////        GoodsUWork.OfferDataDiv = 1; // 提供区分１：提供
            ////        GoodsUWork.OfferDate = ConverIntToDateTime(PtMkrPriceWork.OfferDate);
            ////        GoodsUWork.UpdateDate = ConverIntToDateTime(PtMkrPriceWork.OfferDate);

            ////        lstGoods.Add(GoodsUWork);


            ////        GoodsPriceUWork GoodsPriceUWork = new GoodsPriceUWork();

            ////        GoodsPriceUWork.GoodsMakerCd = PtMkrPriceWork.MakerCode;
            ////        GoodsPriceUWork.GoodsNo = PtMkrPriceWork.NewPrtsNoWithHyphen;
            ////        GoodsPriceUWork.ListPrice = PtMkrPriceWork.PartsPrice;
            ////        GoodsPriceUWork.PriceStartDate = ConverIntToDateTime(PtMkrPriceWork.PartsPriceStDate);
            ////        GoodsPriceUWork.OpenPriceDiv = PtMkrPriceWork.OpenPriceDiv;
            ////        GoodsPriceUWork.OfferDate = ConverIntToDateTime(PtMkrPriceWork.OfferDate);
            ////        GoodsPriceUWork.UpdateDate = ConverIntToDateTime(PtMkrPriceWork.OfferDate);

            ////        lstPrices.Add(GoodsPriceUWork);
            ////    }
            ////}
            ////if (lstPrimeParts != null)
            ////{
            ////    foreach (PrimePartsWork PrimePartsWork in lstPrimeParts)
            ////    {
            ////        GoodsUWork GoodsUWork = new GoodsUWork();

            ////        GoodsUWork.GoodsMakerCd = PrimePartsWork.PartsMakerCd;
            ////        GoodsUWork.GoodsNo = PrimePartsWork.PrimePartsNoWithH;
            ////        GoodsUWork.GoodsNoNoneHyphen = PrimePartsWork.PrimePartsNoNoneH;
            ////        GoodsUWork.GoodsName = PrimePartsWork.PrimePartsName;
            ////        GoodsUWork.GoodsNameKana = PrimePartsWork.PrimePartsKanaNm;
            ////        GoodsUWork.GoodsRateRank = PrimePartsWork.PartsLayerCd;
            ////        GoodsUWork.TaxationDivCd = 0; // 外税 固定値
            ////        GoodsUWork.GoodsKindCode = 1; // その他 固定値
            ////        GoodsUWork.OfferDataDiv = 1; // 提供区分１：提供
            ////        GoodsUWork.OfferDate = ConverIntToDateTime(PrimePartsWork.OfferDate);
            ////        GoodsUWork.UpdateDate = ConverIntToDateTime(PrimePartsWork.OfferDate);

            ////        lstGoods.Add(GoodsUWork);
            ////    }
            ////}
            ////if (lstPrimePrice != null)
            ////{
            ////    foreach (PrmPrtPriceWork PrmPrtPriceWork in lstPrimePrice)
            ////    {
            ////        GoodsPriceUWork GoodsPriceUWork = new GoodsPriceUWork();

            ////        GoodsPriceUWork.GoodsMakerCd = PrmPrtPriceWork.PartsMakerCd;
            ////        GoodsPriceUWork.GoodsNo = PrmPrtPriceWork.PrimePartsNoWithH;
            ////        GoodsPriceUWork.ListPrice = PrmPrtPriceWork.NewPrice;
            ////        GoodsPriceUWork.PriceStartDate = ConverIntToDateTime(PrmPrtPriceWork.PriceStartDate);
            ////        GoodsPriceUWork.OpenPriceDiv = PrmPrtPriceWork.OpenPriceDiv;
            ////        GoodsPriceUWork.OfferDate = ConverIntToDateTime(PrmPrtPriceWork.OfferDate);
            ////        GoodsPriceUWork.UpdateDate = ConverIntToDateTime(PrmPrtPriceWork.OfferDate);

            ////        lstPrices.Add(GoodsPriceUWork);
            ////    }
            ////}


            ////lst.Add(lstGoods);
            ////lst.Add(lstPrices);
            ////lst.Add(lstClgGoods);
            ////lst.Add(lstClgPrices);

            //#endregion

            //CustomSerializeArrayList lst = new CustomSerializeArrayList();
            //lst.Add(dicPriceUpdate);

            //PriceMergeSt st = new PriceMergeSt();
            //st.EnterpriseCode = enterpriseCode;
            //st.NameMergeFlg = _priceChgSet.NameUpdDiv;
            //st.OpenPriceFlg = _priceChgSet.OpenPriceDiv;
            //st.PriceManage = _priceChgSet.PriceMngCnt;
            //st.PriceMergeFlg = _priceChgSet.PriceUpdDiv;
            //st.GoodsRankMergeFlg = _priceChgSet.PartsLayerUpdDiv;
            #endregion

            // ADD 2009/02/12 機能追加：価格改正処理を手動で行う ---------->>>>>
            //priceRevisionParameter.MergedPriceRevisionList = lst;
            //priceRevisionParameter.PriceMergeSetting = pricMergeSt;
            //priceRevisionParameter.RetList = retList;
            //CountPriceRevision(writeGoodsList, writePricesList);
            return status;  // FIXME:価格改正用のパラメータだけを構築して戻る
            // ADD 2009/02/12 機能追加：価格改正処理を手動で行う ----------<<<<<

            #region [ 封印 ]

            //if (_iOfferMerger == null)
            //    _iOfferMerger = MediationOfferMergeDB.GetRemoteObject();

            //status = _iOfferMerger.DoPriceRevision(st, lst, out retList);

            //// ADD 2009/02/10 機能追加：価格改正処理を手動で行う ---------->>>>>
            //// 価格改正処理の更新件数をカウント
            //if (status.Equals((int)Result.RemoteStatus.Normal))
            //{
            //    CountPriceRevision(lstGoods, lstPrices);
            //}
            //// ADD 2009/02/10 機能追加：価格改正処理を手動で行う ----------<<<<<

            //MyLogger.Write(MyLogWriter.PRICE_REVISION, "価格改正実行", MyLogWriter.GetPriceRevisionMessage(status, lst));  // ADD 2009/02/10 機能追加：ログ出力

            //return status;

            #endregion  // [ 封印 ]
        }

        // 優良部品マスタ格納
        #region
        // 2010/04/23 >>>
        //private void CopytoPrimePartsList(ref ArrayList lstPrimeParts, ref ArrayList lstPrimePrice, ref ArrayList UsrGoodsUnitList, PriceMergeSt pricMergeSt, ref ArrayList writeGoodsList, ref ArrayList writePricesList, ref ArrayList deletePriceList)
        private void CopytoPrimePartsList(string enterpriseCode, List<PrmSettingUWork> prmSettingUWorkList, ref ArrayList lstPrimeParts, ref ArrayList lstPrimePrice, ref ArrayList UsrGoodsUnitList, PriceMergeSt pricMergeSt, ref ArrayList writeGoodsList, ref ArrayList writePricesList, ref ArrayList deletePriceList)
        // 2010/04/23 <<<
        {
            // 2010/04/23 Add >>>
            // ユーザー商品に更新対象リスト
            List<GetUsrGoodsUnitDataWork> prcUpdtTrgtList = new List<GetUsrGoodsUnitDataWork>();
            // 2010/04/23 Add <<<

            // (ユーザー)商品結合データで回す
            foreach (GetUsrGoodsUnitDataWork userGoodsUnitWork in UsrGoodsUnitList)
            {
                if (lstPrimeParts != null)
                {
                    // (提供)優良商品データで回す
                    foreach (PrimePartsWork primePartsWork in lstPrimeParts)
                    {
                        // マージ対象となるキーが一致していたら(ﾒｰｶｰ･品番)
                        if (userGoodsUnitWork.GoodsMakerCd == primePartsWork.PartsMakerCd && userGoodsUnitWork.GoodsNo == primePartsWork.PrimePartsNoWithH)
                        {
                            // 前回品番と一緒じゃ無かったら
                            if (!( userGoodsUnitWork.GoodsMakerCd == PriGoodsUWork.GoodsMakerCd && userGoodsUnitWork.GoodsNo == PriGoodsUWork.GoodsNo ))
                            {
                                GoodsUWork writeGoodsUwork = new GoodsUWork();

                                #region キー格納
                                writeGoodsUwork.CreateDateTime = userGoodsUnitWork.CreateDateTime;
                                writeGoodsUwork.BLGoodsCode = userGoodsUnitWork.BLGoodsCode;
                                writeGoodsUwork.DisplayOrder = userGoodsUnitWork.DisplayOrder;
                                writeGoodsUwork.EnterpriseGanreCode = userGoodsUnitWork.EnterpriseGanreCode;
                                writeGoodsUwork.FileHeaderGuid = userGoodsUnitWork.FileHeaderGuid;
                                writeGoodsUwork.GoodsKindCode = userGoodsUnitWork.GoodsKindCode;
                                writeGoodsUwork.GoodsName = userGoodsUnitWork.GoodsName;
                                writeGoodsUwork.GoodsNameKana = userGoodsUnitWork.GoodsNameKana;
                                writeGoodsUwork.GoodsNoNoneHyphen = userGoodsUnitWork.GoodsNoNoneHyphen;
                                writeGoodsUwork.GoodsNote1 = userGoodsUnitWork.GoodsNote1;
                                writeGoodsUwork.GoodsNote2 = userGoodsUnitWork.GoodsNote2;
                                writeGoodsUwork.GoodsRateRank = userGoodsUnitWork.GoodsRateRank;
                                writeGoodsUwork.GoodsSpecialNote = userGoodsUnitWork.GoodsSpecialNote;
                                writeGoodsUwork.Jan = userGoodsUnitWork.Jan;
                                writeGoodsUwork.LogicalDeleteCode = userGoodsUnitWork.LogicalDeleteCode;
                                writeGoodsUwork.OfferDataDiv = userGoodsUnitWork.OfferDataDiv;
                                writeGoodsUwork.OfferDate = userGoodsUnitWork.OfferDate;
                                writeGoodsUwork.TaxationDivCd = 0;
                                writeGoodsUwork.UpdAssemblyId1 = userGoodsUnitWork.UpdAssemblyId1;
                                writeGoodsUwork.UpdAssemblyId2 = userGoodsUnitWork.UpdAssemblyId2;
                                writeGoodsUwork.UpdateDate = userGoodsUnitWork.UpdateDate;
                                writeGoodsUwork.UpdateDateTime = userGoodsUnitWork.UpdateDateTime;
                                writeGoodsUwork.UpdEmployeeCode = userGoodsUnitWork.UpdEmployeeCode;
                                writeGoodsUwork.EnterpriseCode = userGoodsUnitWork.EnterpriseCode;
                                writeGoodsUwork.GoodsMakerCd = primePartsWork.PartsMakerCd;
                                writeGoodsUwork.GoodsNo = primePartsWork.PrimePartsNoWithH;
                                #endregion

                                #region マージ対象項目格納
                                // [名称更新] [する]の場合
                                bool updateFlg = false;
                                // 2009/12/11 >>>
                                //if (pricMergeSt.NameMergeFlg == 0)
                                if (( pricMergeSt.NameMergeFlg == 0 ) &&
                                    (( !writeGoodsUwork.GoodsName.Equals(primePartsWork.PrimePartsName) ) ||
                                     ( !writeGoodsUwork.GoodsNameKana.Equals(primePartsWork.PrimePartsKanaNm) ) 
                                    )
                                   )
                                // 2009/12/11 <<<
                                {
                                    //writeGoodsUwork.GoodsName = primePartsWork.PrimePartsName; // DEL 2012/07/02 高峰 品名が全角に更新されるの不具合対応
                                    writeGoodsUwork.GoodsName = primePartsWork.PrimePartsKanaNm; // ADD 2012/07/02 高峰 品名が全角に更新されるの不具合対応
                                    writeGoodsUwork.GoodsNameKana = primePartsWork.PrimePartsKanaNm;
                                    updateFlg = true;
                                }
                                // [層別更新] [する]の場合
                                // 2009/12/11 >>>
                                //if (pricMergeSt.GoodsRankMergeFlg == 0)

                                // ----- UPD 2012/06/26 高峰 層別更新不具合対応 ----- >>>>>
                                //if (( pricMergeSt.GoodsRankMergeFlg == 0 ) &&
                                //    ( !writeGoodsUwork.GoodsRateRank.Equals(primePartsWork.PartsLayerCd) )
                                //    )
                                if (( pricMergeSt.GoodsRankMergeFlg == 0 
                                        && !writeGoodsUwork.GoodsRateRank.Equals(primePartsWork.PartsLayerCd) 
                                        && !string.Empty.Equals(primePartsWork.PartsLayerCd.Trim()))
                                    || (pricMergeSt.GoodsRankMergeFlg == 2
                                        && !writeGoodsUwork.GoodsRateRank.Equals(primePartsWork.PartsLayerCd))
                                   )
                                // ----- UPD 2012/06/26 高峰 層別更新不具合対応 ----- <<<<<
                                // 2009/12/11 <<<
                                {
                                    writeGoodsUwork.GoodsRateRank = primePartsWork.PartsLayerCd;
                                    updateFlg = true;
                                }

                                // 2009/12/11 Add >>>
                                // [BLコード更新] [する]の場合
                                // UPD 2013/01/31 T.Miyamoto ------------------------------>>>>>
                                //if (( pricMergeSt.BLGoodeCdMergeFlg == 0 ) &&
                                //    ( !writeGoodsUwork.BLGoodsCode.Equals(primePartsWork.TbsPartsCode) )
                                //   )
                                if (((pricMergeSt.BLGoodeCdMergeFlg == 0) &&                              //更新区分＝0:する（提供未設定分は更新無）
                                    (!writeGoodsUwork.BLGoodsCode.Equals(primePartsWork.TbsPartsCode)) && //商品.BLコード≠提供.翼部品コード
                                    (primePartsWork.TbsPartsCode != 0))                                   //提供.翼部品コード≠0
                                 || ((pricMergeSt.BLGoodeCdMergeFlg == 2) &&                              //更新区分＝1:する（無条件更新）
                                    (!writeGoodsUwork.BLGoodsCode.Equals(primePartsWork.TbsPartsCode)))   //商品.BLコード≠提供.翼部品コード
                                   )
                                // UPD 2013/01/31 T.Miyamoto ------------------------------<<<<<
                                {
                                    writeGoodsUwork.BLGoodsCode = primePartsWork.TbsPartsCode;
                                    updateFlg = true;
                                }
                                // 2009/12/11 Add <<<

                                // 名称又は層別の更新がある場合　商品属性・提供日付・更新年月日を更新する。
                                if (updateFlg)
                                {
                                    writeGoodsUwork.GoodsKindCode = primePartsWork.PartsAttribute;
                                    writeGoodsUwork.OfferDate = ConverIntToDateTime(primePartsWork.OfferDate);
                                    writeGoodsUwork.UpdateDate = DateTime.Now;
                                    writeGoodsUwork.OfferDataDiv = 1;

                                    // 更新用リストにAdd
                                    writeGoodsList.Add(writeGoodsUwork);
                                }
                                #endregion

                                PriGoodsUWork = writeGoodsUwork;
                                break;
                            }
                        }
                    }
                }
                // 2010/04/23 >>>
                #region 削除
                //// 価格マスタマージ
                //if (pricMergeSt.PriceMergeFlg == 0)
                //{
                //    if (lstPrimePrice != null)
                //    {
                //        // もし前回と異なる提供価格だったら
                //        if (!( PriorOfrGoodsPriceUWork.GoodsMakerCd == userGoodsUnitWork.GoodsMakerCd && PriorOfrGoodsPriceUWork.GoodsNo == userGoodsUnitWork.GoodsNo ) || FirstFlg == false)
                //        {
                //            // 提供価格リストから取得
                //            foreach (PrmPrtPriceWork prmPrtPriceWork in lstPrimePrice)
                //            {
                //                // マージ対象となるキーが一致していたら(ﾒｰｶｰ･品番) 
                //                if (userGoodsUnitWork.GoodsMakerCd == prmPrtPriceWork.PartsMakerCd
                //                      && userGoodsUnitWork.GoodsNo == prmPrtPriceWork.PrimePartsNoWithH)
                //                {
                //                    // 新しく前回提供ワークに格納
                //                    PriorOfrGoodsPriceUWork.GoodsMakerCd = prmPrtPriceWork.PartsMakerCd;
                //                    PriorOfrGoodsPriceUWork.GoodsNo = prmPrtPriceWork.PrimePartsNoWithH;
                //                    PriorOfrGoodsPriceUWork.OfferDate = ConverIntToDateTime(prmPrtPriceWork.OfferDate);
                //                    PriorOfrGoodsPriceUWork.OpenPriceDiv = prmPrtPriceWork.OpenPriceDiv;
                //                    PriorOfrGoodsPriceUWork.ListPrice = prmPrtPriceWork.NewPrice;
                //                    PriorOfrGoodsPriceUWork.PriceStartDate = ConverIntToDateTime(prmPrtPriceWork.PriceStartDate);
                //                    PriorOfrGoodsPriceUWork.UpdateDate = ConverIntToDateTime(prmPrtPriceWork.OfferDate);

                //                    FirstFlg = true;  // 同一品番一回目フラグはtrueに
                //                    SkipFlg = false; // 同じ商品があればスキップしないに変更
                //                    PriorDelflg = true;  // 前回提供ワークを削除しないように変更
                //                    break;
                //                }
                //            }
                //        }

                //        // 前回価格ワークをnew
                //        if (PriorDelflg == false)
                //        {
                //            PriorOfrGoodsPriceUWork = new GoodsPriceUWork();
                //        }

                //        PriorDelflg = false;

                //        // もし前回とメーカー･品番のどちらかが違えば
                //        if (PriorGoodsPriceUWork.GoodsMakerCd != userGoodsUnitWork.GoodsMakerCd || PriorGoodsPriceUWork.GoodsNo != userGoodsUnitWork.GoodsNo)
                //        {
                //            // データ入っているか確認するために提供日付で判断
                //            if (writeGoodsPriseUwork.OfferDate != DateTime.MinValue)
                //            {
                //                // 前回取っておいたメーカー品番を書込リストにAdd
                //                writePricesList.Add(writeGoodsPriseUwork);
                //                // 前回取っておいたメーカー品番を削除リストにAdd
                //                if (deleteGoodsPriceUWork.EnterpriseCode != "")
                //                {
                //                    deletePriceList.Add(deleteGoodsPriceUWork);
                //                    deleteGoodsPriceUWork = new GoodsPriceUWork();
                //                }
                //                // 書込･削除ワーククリア
                //                writeGoodsPriseUwork = new GoodsPriceUWork();
                //            }
                //            // 書込み可能
                //            SkipFlg = false;
                //        }

                //        // データ入っているか確認するために提供日付で判断
                //        if (PriorOfrGoodsPriceUWork.OfferDate != DateTime.MinValue)
                //        {
                //            if (SkipFlg == false)
                //            {
                //                DateTime priceStartDate = DateTime.MinValue;
                //                // Datetimeに変換　※価格開始日
                //                if (userGoodsUnitWork.PricePriceStartDate != 0)
                //                {
                //                    priceStartDate = DateTime.Parse(userGoodsUnitWork.PricePriceStartDate.ToString("0000/00/00"));
                //                }
                //                // ﾕｰｻﾞｰのﾚｺｰﾄﾞ数がマスタの価格保持件数よりも大きければ
                //                if (userGoodsUnitWork.PriceCount >= pricMergeSt.PriceManage)
                //                {
                //                    // ﾕｰｻﾞｰ価格開始日が提供の価格開始日以上ならば
                //                    if (priceStartDate > PriorOfrGoodsPriceUWork.PriceStartDate)
                //                    {
                //                    }
                //                    // ﾕｰｻﾞｰと提供の価格開始日が一緒なら
                //                    else if (priceStartDate == PriorOfrGoodsPriceUWork.PriceStartDate)
                //                    {
                //                        // 更新処理　後で作成
                //                        WriteNewPrice(userGoodsUnitWork, pricMergeSt, ref writePricesList, ref PriorOfrGoodsPriceUWork);
                //                    }
                //                    // ﾕｰｻﾞｰより提供の価格開始日が大きい場合(ｲｺｰﾙは含まれない)
                //                    else
                //                    {
                //                        // 新規ワーク作成
                //                        WriteNewPrice(userGoodsUnitWork, pricMergeSt, ref writePricesList, ref PriorOfrGoodsPriceUWork);
                //                        //deleteGoodsPriceUWork = PriorOfrGoodsPriceUWork;
                //                        if (deleteGoodsPriceUWork.GoodsMakerCd != userGoodsUnitWork.PriceGoodsMakerCd && deleteGoodsPriceUWork.GoodsNo != userGoodsUnitWork.PriceGoodsNo)
                //                        {
                //                            deleteGoodsPriceUWork.EnterpriseCode = _enterpriseCode;
                //                            deleteGoodsPriceUWork.GoodsMakerCd = userGoodsUnitWork.PriceGoodsMakerCd;
                //                            deleteGoodsPriceUWork.GoodsNo = userGoodsUnitWork.PriceGoodsNo;
                //                            deleteGoodsPriceUWork.PriceStartDate = DateTime.Parse(( userGoodsUnitWork.PricePriceStartDate ).ToString("0000/00/00"));
                //                        }
                //                    }
                //                    SkipFlg = true; continue;
                //                }
                //                // ﾕｰｻﾞｰのﾚｺｰﾄﾞ数がマスタの価格保持件数より小さければ
                //                else
                //                {
                //                    // ﾕｰｻﾞｰと提供の価格開始日が一緒なら
                //                    if (priceStartDate == PriorOfrGoodsPriceUWork.PriceStartDate)
                //                    {
                //                        // 更新処理　後で作成
                //                        WriteNewPrice(userGoodsUnitWork, pricMergeSt, ref writePricesList, ref PriorOfrGoodsPriceUWork);
                //                    }
                //                    else
                //                    {
                //                        // 新規ワーク作成
                //                        WriteNewPrice(userGoodsUnitWork, pricMergeSt, ref writePricesList, ref PriorOfrGoodsPriceUWork);

                //                    }
                //                    SkipFlg = true; continue;
                //                }
                //            }
                //        }
                //    }
                //}
                #endregion

                if (pricMergeSt.PriceMergeFlg == 0)
                {
                    // 優良価格リストが無い場合は無条件追加
                    if (prcUpdtTrgtList.Count == 0)
                    {
                        prcUpdtTrgtList.Add(userGoodsUnitWork);
                    }
                    else
                    {
                        // 部品が変わったタイミングで価格改正リストの生成
                        if (!( userGoodsUnitWork.GoodsNo.Trim().Equals(prcUpdtTrgtList[0].GoodsNo.Trim()) &&
                               userGoodsUnitWork.GoodsMakerCd.Equals(prcUpdtTrgtList[0].GoodsMakerCd) ))
                        {
                            List<GoodsPriceUWork> addList;
                            List<GoodsPriceUWork> deleteList;
                            this.CreatePrimePartsPriceUpdateDataList(enterpriseCode, prcUpdtTrgtList[0].GoodsNo.Trim(), prcUpdtTrgtList[0].GoodsMakerCd, pricMergeSt, prcUpdtTrgtList, lstPrimePrice, prmSettingUWorkList, out addList, out deleteList);
                            if (addList.Count > 0) writePricesList.AddRange(addList.ToArray());
                            if (deleteList.Count > 0) deletePriceList.AddRange(deleteList.ToArray());

                            prcUpdtTrgtList.Clear();
                        }
                        prcUpdtTrgtList.Add(userGoodsUnitWork);
                    }
                }
                // 2010/04/23 <<<
            }
            // 2010/04/23 Add >>>
            if (pricMergeSt.PriceMergeFlg == 0 && prcUpdtTrgtList.Count > 0)
            {
                // ここで価格改正処理
                List<GoodsPriceUWork> addList;
                List<GoodsPriceUWork> deleteList;
                this.CreatePrimePartsPriceUpdateDataList(enterpriseCode, prcUpdtTrgtList[0].GoodsNo.Trim(), prcUpdtTrgtList[0].GoodsMakerCd, pricMergeSt, prcUpdtTrgtList, lstPrimePrice, prmSettingUWorkList, out addList, out deleteList);
                if (addList.Count > 0) writePricesList.AddRange(addList.ToArray());
                if (deleteList.Count > 0) deletePriceList.AddRange(deleteList.ToArray());
            }
            // 2010/04/23 Add <<<
        }
        #endregion

        // 2010/04/23 Add >>>
        #region 価格マスタの更新処理

        /// <summary>
        /// 価格改正リストの生成
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="makerCd">メーカーコード</param>
        /// <param name="priceMergeSt">提供データ更新設定マスタ</param>
        /// <param name="prcUpdtTrgtList">純正価格マスタリスト</param>
        /// <param name="lstPrimePrice">優良部品価格リスト</param>
        /// <param name="addList">追加更新対象リスト</param>
        /// <param name="deleteList">削除対象リスト</param>
        private void CreatePrimePartsPriceUpdateDataList(string enterpriseCode, string goodsNo, int makerCd, PriceMergeSt priceMergeSt, List<GetUsrGoodsUnitDataWork> prcUpdtTrgtList, ArrayList lstPrimePrice, List<PrmSettingUWork> prmSettingUWorkList, out List<GoodsPriceUWork> addList, out List<GoodsPriceUWork> deleteList)
        {
            addList = new List<GoodsPriceUWork>();
            deleteList = new List<GoodsPriceUWork>();

            if (lstPrimePrice == null || lstPrimePrice.Count == 0) return;

            // 提供・ユーザーをマージしたリスト
            SortedDictionary<int, object> prcList = new SortedDictionary<int, object>();
            // ユーザーに同一価格開始日がある分の提供リスト
            Dictionary<int, PrmPrtPriceWork> duplicateList = new Dictionary<int, PrmPrtPriceWork>();

            // ユーザー価格マスタからリスト追加
            foreach (GetUsrGoodsUnitDataWork data in prcUpdtTrgtList)
            {
                if (data.PricePriceStartDate == 0) continue;

                if (!prcList.ContainsKey(data.PricePriceStartDate))
                {
                    prcList.Add(data.PricePriceStartDate, data);
                }
            }

            bool ofrDtExists = false;
            // 提供優良価格マスタからリスト追加
            foreach (PrmPrtPriceWork prmPrtPriceWork in lstPrimePrice)
            {
                // このリストは品番順にソートされているので、品番が対象品番より大きくなったらBreak
                if (prmPrtPriceWork.PrimePartsNoWithH.CompareTo(goodsNo) > 0) break;

                // マージ対象となるキーが一致していたら(ﾒｰｶｰ･品番) 
                if (makerCd == prmPrtPriceWork.PartsMakerCd
                    && goodsNo == prmPrtPriceWork.PrimePartsNoWithH)
                {
                    // セレクトコードがある場合は該当商品かチェックする
                    if (prmPrtPriceWork.PrmSetDtlNo1 != 0)
                    {
                        if (prmSettingUWorkList == null) continue;

                        PrmSettingUWork prmSettingWork = prmSettingUWorkList.Find(
                            delegate(PrmSettingUWork target)
                            {
                                if (target.PartsMakerCd == prmPrtPriceWork.PartsMakerCd &&
                                    target.GoodsMGroup == prmPrtPriceWork.GoodsMGroup &&
                                    target.TbsPartsCode == prmPrtPriceWork.TbsPartsCode &&
                                    target.PrmSetDtlNo1 == prmPrtPriceWork.PrmSetDtlNo1

                                   ) return true;

                                return false;
                            });

                        if (prmSettingWork == null) continue;
                    }
                    // 既にユーザーに同一価格開始日がある場合は重複リストに移行
                    if (prcList.ContainsKey(prmPrtPriceWork.PriceStartDate))
                    {
                        duplicateList.Add(prmPrtPriceWork.PriceStartDate, prmPrtPriceWork);
                    }
                    else
                    {
                        prcList.Add(prmPrtPriceWork.PriceStartDate, prmPrtPriceWork);
                    }
                    ofrDtExists = true;
                }
            }

            if (!ofrDtExists) return;

            // この時点で、prcListに、ユーザー+提供のリスト（提供の重複分を除く）、duplicateListに重複した提供のリストが入っている

            // 古い方から見ていく
            List<GoodsPriceUWork> allList = new List<GoodsPriceUWork>();    　// ユーザーデータの最新情報（価格順で）
            GetUsrGoodsUnitDataWork usrGoods = new GetUsrGoodsUnitDataWork(); // ユーザー商品

            foreach (int prcStDate in prcList.Keys)
            {
                // ユーザー商品
                if (prcList[prcStDate] is GetUsrGoodsUnitDataWork)
                {
                    usrGoods = (GetUsrGoodsUnitDataWork)prcList[prcStDate];
                    GoodsPriceUWork writeWork = new GoodsPriceUWork();
                    writeWork.CreateDateTime = usrGoods.PriceCreateDateTime;
                    writeWork.UpdateDateTime = usrGoods.PriceUpdateDateTime;
                    writeWork.EnterpriseCode = usrGoods.PriceEnterpriseCode;
                    writeWork.FileHeaderGuid = usrGoods.PriceFileHeaderGuid;
                    writeWork.UpdEmployeeCode = usrGoods.PriceUpdEmployeeCode;
                    writeWork.UpdAssemblyId1 = usrGoods.PriceUpdAssemblyId1;
                    writeWork.UpdAssemblyId2 = usrGoods.PriceUpdAssemblyId2;
                    writeWork.LogicalDeleteCode = usrGoods.PriceLogicalDeleteCode;

                    writeWork.GoodsMakerCd = usrGoods.GoodsMakerCd;
                    writeWork.GoodsNo = usrGoods.GoodsNo;
                    writeWork.PriceStartDate = DateTime.Parse(( usrGoods.PricePriceStartDate ).ToString("0000/00/00"));
                    writeWork.SalesUnitCost = usrGoods.PriceSalesUnitCost;
                    writeWork.StockRate = usrGoods.PriceStockRate;
                    writeWork.ListPrice = usrGoods.PriceListPrice;

                    // 提供データがあった場合
                    if (duplicateList.ContainsKey(prcStDate))
                    {
                        PrmPrtPriceWork ofrData = duplicateList[prcStDate];

                        writeWork.UpdateDate = DateTime.Now;                                                // 更新日付
                        writeWork.OfferDate = DateTime.Parse(( ofrData.OfferDate ).ToString("0000/00/00")); // 提供日付
                        writeWork.OpenPriceDiv = ofrData.OpenPriceDiv;                                      // オープン価格区分

                        // 新しい定価がゼロの場合
                        if (ofrData.NewPrice == 0)
                        {
                            // 提供データ更新設定マスタのオープン価格区分を参照してセット
                            if (priceMergeSt.OpenPriceFlg == 0)
                            {
                                writeWork.ListPrice = usrGoods.PriceListPrice;  // 元のユーザー価格を引継ぐ
                            }
                            else
                            {
                                writeWork.ListPrice = 0;         // 定価０
                            }
                        }
                        else
                        {
                            writeWork.ListPrice = ofrData.NewPrice;
                        }
                        //------------ ADD By chenyd 2013/05/13 For Redmine #35515------------------------------->>>>>
                        double listPrice = writeWork.ListPrice;
                        this.ReflectIsolIslandCall(writeWork.GoodsMakerCd, ref listPrice);
                        writeWork.ListPrice = listPrice;
                        //------------ ADD By chenyd 2013/05/13 For Redmine #35515-------------------------------<<<<<

                        // 提供データがあった場合のみ価格改正リストへの追加
                        addList.Add(writeWork);
                    }
                    allList.Add(writeWork);
                }
                else if (prcList[prcStDate] is PrmPrtPriceWork)
                {
                    PrmPrtPriceWork ofrData = (PrmPrtPriceWork)prcList[prcStDate];

                    GoodsPriceUWork writeWork = new GoodsPriceUWork();
                    writeWork.EnterpriseCode = enterpriseCode;              // 企業コード
                    writeWork.PriceStartDate = DateTime.Parse(( ofrData.PriceStartDate ).ToString("0000/00/00"));       // 価格開始日
                    writeWork.GoodsMakerCd = makerCd;                       // メーカー
                    writeWork.GoodsNo = goodsNo;                            // 品番
                    writeWork.UpdateDate = DateTime.Now;                    // 更新年月日

                    // ユーザー価格マスタの内容を引継ぐ(提供が一番古い場合は入らない)
                    writeWork.SalesUnitCost = usrGoods.PriceSalesUnitCost;  // 原価単価
                    writeWork.StockRate = usrGoods.PriceStockRate;          // 仕入率

                    writeWork.OfferDate = DateTime.Parse(( ofrData.OfferDate ).ToString("0000/00/00")); // 提供日付
                    writeWork.OpenPriceDiv = ofrData.OpenPriceDiv;          // オープン価格区分
                    writeWork.ListPrice = ofrData.NewPrice;                // 定価

                    // 提供の標準価格がゼロの場合
                    if (ofrData.NewPrice == 0)
                    {
                        // 提供データ更新設定マスタのオープン価格区分を参照してセット
                        if (priceMergeSt.OpenPriceFlg == 0)
                        {
                            if (allList.Count > 0)
                            {
                                writeWork.ListPrice = allList[allList.Count - 1].ListPrice;   // 1つ前の定価をセット
                            }
                        }
                    }
                    //------------ ADD By chenyd 2013/05/13 For Redmine #35515------------------------------->>>>>
                    double listPrice = writeWork.ListPrice;
                    this.ReflectIsolIslandCall(writeWork.GoodsMakerCd, ref listPrice);
                    writeWork.ListPrice = listPrice;
                    //------------ ADD By chenyd 2013/05/13 For Redmine #35515-------------------------------<<<<<

                    // 価格改正リストに追加
                    allList.Add(writeWork);

                    // 全件リストに追加
                    addList.Add(writeWork);
                }
            }

            // 管理件数を超えている場合、古いデータから消す
            if (allList.Count > pricMergeSt.PriceManage)
            {
                // 削除する件数
                int delCnt = allList.Count - pricMergeSt.PriceManage;

                for (int cnt = 0; cnt < delCnt; cnt++)
                {
                    GoodsPriceUWork data = allList[0];

                    // 作成日時が入っている場合は、ユーザー登録されていた分なので、削除リストに追加
                    if (data.CreateDateTime != DateTime.MinValue)
                    {
                        deleteList.Add(data);
                    }

                    // 追加・更新データに含まれる場合はリストから削除
                    if (addList.Contains(data)) addList.Remove(data);

                    // 先頭データを消す
                    allList.RemoveAt(0);
                }
            }
        }
        #endregion
        // 2010/04/23 Add <<<

        // 部品価格マスタ格納
        #region
        // 2010/04/23 >>>
        //private void CopytoPtmkPriceList(ref ArrayList lstPtMkrPrice, ref ArrayList UsrGoodsUnitList, PriceMergeSt pricMergeSt, ref ArrayList writeGoodsList, ref ArrayList writePricesList, ref ArrayList deletePriceList)
        private void CopytoPtmkPriceList(string enterpriseCode, ref ArrayList lstPtMkrPrice, ref ArrayList UsrGoodsUnitList, PriceMergeSt pricMergeSt, ref ArrayList writeGoodsList, ref ArrayList writePricesList, ref ArrayList deletePriceList)
        // 2010/04/23 <<<
        {
            // 2010/04/23 Add >>>
            // ユーザー商品に更新対象リスト
            List<GetUsrGoodsUnitDataWork> prcUpdtTrgtList = new List<GetUsrGoodsUnitDataWork>();
            List<PtMkrPriceWork> ptMkrPriceWorkList = new List<PtMkrPriceWork>();
            GetUsrGoodsUnitDataWork beforeGetUsrGoodsUnitDataWork = new GetUsrGoodsUnitDataWork();
            bool purePartsInfoChanged = false;
            // 2010/04/23 Add <<<

            // (ユーザー)商品結合データで回す
            foreach (GetUsrGoodsUnitDataWork userGoodsUnitWork in UsrGoodsUnitList)
            {
                // 2010/04/23 Add >>>
                purePartsInfoChanged = ( !( beforeGetUsrGoodsUnitDataWork.GoodsNo.Equals(userGoodsUnitWork.GoodsNo) && beforeGetUsrGoodsUnitDataWork.GoodsMakerCd.Equals(userGoodsUnitWork.GoodsMakerCd) ) );

                // 部品が変わって、価格更新有り
                if (purePartsInfoChanged && pricMergeSt.PriceMergeFlg == 0 && prcUpdtTrgtList.Count > 0)
                {
                    // ここで価格改正処理
                    List<GoodsPriceUWork> addList;
                    List<GoodsPriceUWork> deleteList;
                    this.CreatePurePartsPriceUpdateDataList(enterpriseCode, beforeGetUsrGoodsUnitDataWork.GoodsNo, beforeGetUsrGoodsUnitDataWork.GoodsMakerCd, pricMergeSt, prcUpdtTrgtList, ptMkrPriceWorkList, out addList, out deleteList);
                    if (addList.Count > 0) writePricesList.AddRange(addList.ToArray());
                    if (deleteList.Count > 0) deletePriceList.AddRange(deleteList.ToArray());

                    ptMkrPriceWorkList.Clear();
                    prcUpdtTrgtList.Clear();
                }
                prcUpdtTrgtList.Add(userGoodsUnitWork);

                beforeGetUsrGoodsUnitDataWork = userGoodsUnitWork;
                // 2010/04/23 Add <<<
                // (提供)商品データで回す
                foreach (PtMkrPriceWork ptMkrPriceWork in lstPtMkrPrice)
                {
                    // マージ対象となるキーが一致していたら(ﾒｰｶｰ･品番) 
                    if (userGoodsUnitWork.GoodsMakerCd == ptMkrPriceWork.MakerCode && userGoodsUnitWork.GoodsNo == ptMkrPriceWork.NewPrtsNoWithHyphen)
                    {
                        // 2010/04/23 Add >>>
                        // 品番、メーカーが変わったら部品価格リストを追加する
                        if (purePartsInfoChanged) ptMkrPriceWorkList.Add(ptMkrPriceWork);
                        // 2010/04/23 Add <<<
                            
                        // *** *** *** *** *** *** 商品マスタ マージ *** *** *** *** *** *** *** *** ***

                        // 前回品番と一緒じゃ無かったら
                        if (!( userGoodsUnitWork.GoodsMakerCd == PriGoodsUWork.GoodsMakerCd && userGoodsUnitWork.GoodsNo == PriGoodsUWork.GoodsNo ))
                        {
                            GoodsUWork writeGoodsUwork = new GoodsUWork();

                            #region キー格納
                            writeGoodsUwork.CreateDateTime = userGoodsUnitWork.CreateDateTime;
                            writeGoodsUwork.BLGoodsCode = userGoodsUnitWork.BLGoodsCode;
                            writeGoodsUwork.DisplayOrder = userGoodsUnitWork.DisplayOrder;
                            writeGoodsUwork.EnterpriseGanreCode = userGoodsUnitWork.EnterpriseGanreCode;
                            writeGoodsUwork.FileHeaderGuid = userGoodsUnitWork.FileHeaderGuid;
                            writeGoodsUwork.GoodsKindCode = userGoodsUnitWork.GoodsKindCode;
                            writeGoodsUwork.GoodsName = userGoodsUnitWork.GoodsName;
                            writeGoodsUwork.GoodsNameKana = userGoodsUnitWork.GoodsNameKana;
                            writeGoodsUwork.GoodsNoNoneHyphen = userGoodsUnitWork.GoodsNoNoneHyphen;
                            writeGoodsUwork.GoodsNote1 = userGoodsUnitWork.GoodsNote1;
                            writeGoodsUwork.GoodsNote2 = userGoodsUnitWork.GoodsNote2;
                            writeGoodsUwork.GoodsRateRank = userGoodsUnitWork.GoodsRateRank;
                            writeGoodsUwork.GoodsSpecialNote = userGoodsUnitWork.GoodsSpecialNote;
                            writeGoodsUwork.Jan = userGoodsUnitWork.Jan;
                            writeGoodsUwork.LogicalDeleteCode = userGoodsUnitWork.LogicalDeleteCode;
                            writeGoodsUwork.OfferDataDiv = userGoodsUnitWork.OfferDataDiv;
                            writeGoodsUwork.OfferDate = userGoodsUnitWork.OfferDate;
                            writeGoodsUwork.TaxationDivCd = 0;
                            writeGoodsUwork.UpdAssemblyId1 = userGoodsUnitWork.UpdAssemblyId1;
                            writeGoodsUwork.UpdAssemblyId2 = userGoodsUnitWork.UpdAssemblyId2;
                            writeGoodsUwork.UpdateDate = userGoodsUnitWork.UpdateDate;
                            writeGoodsUwork.UpdateDateTime = userGoodsUnitWork.UpdateDateTime;
                            writeGoodsUwork.UpdEmployeeCode = userGoodsUnitWork.UpdEmployeeCode;
                            writeGoodsUwork.EnterpriseCode = userGoodsUnitWork.EnterpriseCode;
                            writeGoodsUwork.GoodsMakerCd = ptMkrPriceWork.MakerCode;
                            writeGoodsUwork.GoodsNo = ptMkrPriceWork.NewPrtsNoWithHyphen;
                            #endregion

                            #region マージ対象項目格納
                            // [名称更新] [する]の場合
                            bool updateFlg = false;
                            // 2009/12/11 >>>
                            //if (pricMergeSt.NameMergeFlg == 0)
                            if ((pricMergeSt.NameMergeFlg == 0) &&
                                ( ( !writeGoodsUwork.GoodsName.Equals(ptMkrPriceWork.MakerOfferPartsName) ) ||
                                  ( !writeGoodsUwork.GoodsNameKana.Equals(ptMkrPriceWork.MakerOfferPartsKana) )
                                )
                               )
                            // 2009/12/11 <<<
                            {
                                //writeGoodsUwork.GoodsName = ptMkrPriceWork.MakerOfferPartsName; // DEL 2012/07/02 高峰 品名が全角に更新されるの不具合対応
                                writeGoodsUwork.GoodsName = ptMkrPriceWork.MakerOfferPartsKana; // ADD 2012/07/02 高峰 品名が全角に更新されるの不具合対応
                                writeGoodsUwork.GoodsNameKana = ptMkrPriceWork.MakerOfferPartsKana;
                                updateFlg = true;
                            }
                            // [層別更新] [する]の場合
                            // 2009/12/11 >>>
                            //if (pricMergeSt.GoodsRankMergeFlg == 0)

                            // ----- UPD 2012/06/26 高峰 層別更新不具合対応 ----- >>>>>
                            //if ((pricMergeSt.GoodsRankMergeFlg == 0) &&
                            //    (!writeGoodsUwork.GoodsRateRank.Equals(ptMkrPriceWork.PartsLayerCd))
                            //   )
                            if ((pricMergeSt.GoodsRankMergeFlg == 0
                                    && !writeGoodsUwork.GoodsRateRank.Equals(ptMkrPriceWork.PartsLayerCd)
                                    && !string.Empty.Equals(ptMkrPriceWork.PartsLayerCd.Trim()))
                                || (pricMergeSt.GoodsRankMergeFlg == 2
                                    && !writeGoodsUwork.GoodsRateRank.Equals(ptMkrPriceWork.PartsLayerCd))
                               )
                            // ----- UPD 2012/06/26 高峰 層別更新不具合対応 ----- <<<<<

                            // 2009/12/11 <<<
                            {
                                writeGoodsUwork.GoodsRateRank = ptMkrPriceWork.PartsLayerCd;
                                updateFlg = true;
                            }
                            // 2009/12/11 Add >>>
                            // [BLコード更新] [する]の場合
                            // UPD 2013/01/31 T.Miyamoto ------------------------------>>>>>
                            ////if (pricMergeSt.BLGoodeCdMergeFlg == 0)
                            //if (( pricMergeSt.BLGoodeCdMergeFlg == 0 ) &&
                            //    ( !writeGoodsUwork.BLGoodsCode.Equals(ptMkrPriceWork.TbsPartsCode) )
                            //   )
                            if (((pricMergeSt.BLGoodeCdMergeFlg == 0) &&                               //更新区分＝0:する（提供未設定分は更新無）
                                 (!writeGoodsUwork.BLGoodsCode.Equals(ptMkrPriceWork.TbsPartsCode)) && //商品.BLコード≠提供.翼部品コード
                                 (ptMkrPriceWork.TbsPartsCode != 0))                                   //提供.翼部品コード≠0
                             || ((pricMergeSt.BLGoodeCdMergeFlg == 2) &&                               //更新区分＝2:する（無条件更新）
                                 (!writeGoodsUwork.BLGoodsCode.Equals(ptMkrPriceWork.TbsPartsCode)))   //商品.BLコード≠提供.翼部品コード
                               )
                            // UPD 2013/01/31 T.Miyamoto ------------------------------<<<<<
                            {
                                writeGoodsUwork.BLGoodsCode = ptMkrPriceWork.TbsPartsCode;
                                updateFlg = true;
                            }
                            // 2009/12/11 Add <<<
                            // 名称又は層別の更新がある場合　商品属性・提供日付・更新年月日を更新する。
                            if (updateFlg)
                            {
                                writeGoodsUwork.GoodsKindCode = 0;
                                writeGoodsUwork.OfferDate = ConverIntToDateTime(ptMkrPriceWork.OfferDate);
                                writeGoodsUwork.UpdateDate = DateTime.Now;
                                writeGoodsUwork.OfferDataDiv = 1;

                                // 更新用リストにAdd
                                writeGoodsList.Add(writeGoodsUwork);
                            }
                            #endregion

                            PriGoodsUWork = writeGoodsUwork;
                            //break;
                        }

                        // *** *** *** *** *** *** 価格マスタ マージ *** *** *** *** *** *** *** *** ***
                        #region 削除
                        //// 価格更新フラグが0:するだったら 
                        //if (pricMergeSt.PriceMergeFlg == 0)
                        //{
                        //    // もし前回と異なる提供価格だったら
                        //    if (!( PriorOfrGoodsPriceUWork.GoodsMakerCd == userGoodsUnitWork.GoodsMakerCd && PriorOfrGoodsPriceUWork.GoodsNo == userGoodsUnitWork.GoodsNo ) || FirstFlg == false)
                        //    {
                        //        // マージ対象となるキーが一致していたら(ﾒｰｶｰ･品番) 
                        //        if (userGoodsUnitWork.GoodsMakerCd == ptMkrPriceWork.MakerCode
                        //              && userGoodsUnitWork.GoodsNo == ptMkrPriceWork.NewPrtsNoWithHyphen)
                        //        {
                        //            // 新しく前回提供ワークに格納
                        //            PriorOfrGoodsPriceUWork.GoodsMakerCd = ptMkrPriceWork.MakerCode;
                        //            PriorOfrGoodsPriceUWork.GoodsNo = ptMkrPriceWork.NewPrtsNoWithHyphen;
                        //            PriorOfrGoodsPriceUWork.OfferDate = ConverIntToDateTime(ptMkrPriceWork.OfferDate);
                        //            PriorOfrGoodsPriceUWork.OpenPriceDiv = ptMkrPriceWork.OpenPriceDiv;
                        //            PriorOfrGoodsPriceUWork.ListPrice = ptMkrPriceWork.PartsPrice;
                        //            PriorOfrGoodsPriceUWork.PriceStartDate = ConverIntToDateTime(ptMkrPriceWork.PartsPriceStDate);
                        //            PriorOfrGoodsPriceUWork.UpdateDate = ConverIntToDateTime(ptMkrPriceWork.OfferDate);

                        //            FirstFlg = true;  // 同一品番一回目フラグはtrueに
                        //            SkipFlg = false; // 同じ商品があればスキップしないに変更
                        //            PriorDelflg = true;  // 前回提供ワークを削除しないように変更
                        //            break;
                        //        }
                        //    }
                        //}
                        #endregion  // 削除
                    }
                } // 提供foreach

                // 2010/04/23 Del >>>
                #region 削除
                //// 前回価格ワークをnew
                //if (PriorDelflg == false)
                //{
                //    PriorOfrGoodsPriceUWork = new GoodsPriceUWork();
                //}

                //PriorDelflg = false;

                //// もし前回とメーカー･品番のどちらかが違えば
                //if (PriorGoodsPriceUWork.GoodsMakerCd != userGoodsUnitWork.GoodsMakerCd || PriorGoodsPriceUWork.GoodsNo != userGoodsUnitWork.GoodsNo)
                //{
                //    // データ入っているか確認するために提供日付で判断
                //    if (writeGoodsPriseUwork.OfferDate != DateTime.MinValue)
                //    {
                //        // 前回取っておいたメーカー品番を書込リストにAdd
                //        writePricesList.Add(writeGoodsPriseUwork);
                //        // 前回取っておいたメーカー品番を削除リストにAdd
                //        if (deleteGoodsPriceUWork.EnterpriseCode != "")
                //        {
                //            deletePriceList.Add(deleteGoodsPriceUWork);
                //            deleteGoodsPriceUWork = new GoodsPriceUWork();
                //        }
                //        // 書込･削除ワーククリア
                //        writeGoodsPriseUwork = new GoodsPriceUWork();
                //    }
                //    // 書込み可能
                //    SkipFlg = false;
                //}

                //// データ入っているか確認するために提供日付で判断
                //if (PriorOfrGoodsPriceUWork.OfferDate != DateTime.MinValue)
                //{
                //    if (SkipFlg == false)
                //    {
                //        DateTime priceStartDate = DateTime.MinValue;
                //        // Datetimeに変換　※価格開始日
                //        if (userGoodsUnitWork.PricePriceStartDate != 0)
                //        {
                //            priceStartDate = DateTime.Parse(userGoodsUnitWork.PricePriceStartDate.ToString("0000/00/00"));
                //        }
                //        // ﾕｰｻﾞｰのﾚｺｰﾄﾞ数がマスタの価格保持件数よりも大きければ
                //        if (userGoodsUnitWork.PriceCount >= pricMergeSt.PriceManage)
                //        {
                //            // ﾕｰｻﾞｰ価格開始日が提供の価格開始日以上ならば
                //            if (priceStartDate > PriorOfrGoodsPriceUWork.PriceStartDate)
                //            {
                //                SkipFlg = true; continue;
                //            }
                //            // ﾕｰｻﾞｰと提供の価格開始日が一緒なら
                //            else if (priceStartDate == PriorOfrGoodsPriceUWork.PriceStartDate)
                //            {
                //                // 更新処理　後で作成
                //                WriteNewPrice(userGoodsUnitWork, pricMergeSt, ref writePricesList, ref PriorOfrGoodsPriceUWork);
                //                SkipFlg = true; continue;
                //            }
                //            // ﾕｰｻﾞｰより提供の価格開始日が大きい場合(ｲｺｰﾙは含まれない)
                //            else
                //            {
                //                // 新規ワーク作成
                //                WriteNewPrice(userGoodsUnitWork, pricMergeSt, ref writePricesList, ref PriorOfrGoodsPriceUWork);

                //                //deleteGoodsPriceUWork = PriorOfrGoodsPriceUWork;
                //                if (deleteGoodsPriceUWork.GoodsMakerCd != userGoodsUnitWork.PriceGoodsMakerCd && deleteGoodsPriceUWork.GoodsNo != userGoodsUnitWork.PriceGoodsNo)
                //                {
                //                    deleteGoodsPriceUWork.EnterpriseCode = _enterpriseCode;
                //                    deleteGoodsPriceUWork.GoodsMakerCd = userGoodsUnitWork.PriceGoodsMakerCd;
                //                    deleteGoodsPriceUWork.GoodsNo = userGoodsUnitWork.PriceGoodsNo;
                //                    deleteGoodsPriceUWork.PriceStartDate = DateTime.Parse(( userGoodsUnitWork.PricePriceStartDate ).ToString("0000/00/00"));
                //                }
                //                SkipFlg = true; continue;
                //            }
                //        }
                //        // ﾕｰｻﾞｰのﾚｺｰﾄﾞ数がマスタの価格保持件数より小さければ
                //        else
                //        {
                //            // ﾕｰｻﾞｰと提供の価格開始日が一緒なら
                //            if (priceStartDate == PriorOfrGoodsPriceUWork.PriceStartDate)
                //            {
                //                // 更新処理　後で作成
                //                WriteNewPrice(userGoodsUnitWork, pricMergeSt, ref writePricesList, ref PriorOfrGoodsPriceUWork);
                //                SkipFlg = true; continue;
                //            }
                //            else
                //            {
                //                // 新規ワーク作成
                //                WriteNewPrice(userGoodsUnitWork, pricMergeSt, ref writePricesList, ref PriorOfrGoodsPriceUWork);
                //                SkipFlg = true; continue;
                //            }
                //        }
                //    }
                //}
                #endregion
                // 2010/04/23 Del <<<

            } // ﾕｰｻﾞｰforeach
            // 2010/04/23 Add >>>
            if (pricMergeSt.PriceMergeFlg == 0 && prcUpdtTrgtList.Count > 0)
            {
                // ここで価格改正処理
                List<GoodsPriceUWork> addList;
                List<GoodsPriceUWork> deleteList;
                this.CreatePurePartsPriceUpdateDataList(enterpriseCode, prcUpdtTrgtList[0].GoodsNo.Trim(), prcUpdtTrgtList[0].GoodsMakerCd, pricMergeSt, prcUpdtTrgtList, ptMkrPriceWorkList, out addList, out deleteList);
                if (addList.Count > 0) writePricesList.AddRange(addList.ToArray());
                if (deleteList.Count > 0) deletePriceList.AddRange(deleteList.ToArray());
            }
            // 2010/04/23 Add <<<
        }
        #endregion


        // 2010/04/23 Add >>>

        #region 価格マスタの更新処理

        /// <summary>
        /// 価格改正リストの生成
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="makerCd">メーカーコード</param>
        /// <param name="priceMergeSt">提供データ更新設定マスタ</param>
        /// <param name="prcUpdtTrgtList">ユーザー商品マスタリスト</param>
        /// <param name="ptMkrPriceWorkList">純正価格リスト</param>
        /// <param name="addList">追加更新対象リスト</param>
        /// <param name="deleteList">削除対象リスト</param>
        private void CreatePurePartsPriceUpdateDataList(string enterpriseCode, string goodsNo, int makerCd, PriceMergeSt priceMergeSt, List<GetUsrGoodsUnitDataWork> prcUpdtTrgtList, List<PtMkrPriceWork> ptMkrPriceWorkList, out List<GoodsPriceUWork> addList, out List<GoodsPriceUWork> deleteList)
        {
            addList = new List<GoodsPriceUWork>();
            deleteList = new List<GoodsPriceUWork>();

            if (prcUpdtTrgtList == null || prcUpdtTrgtList.Count == 0) return;

            // 提供・ユーザーをマージしたリスト
            SortedDictionary<int, object> prcList = new SortedDictionary<int, object>();
            // ユーザーに同一価格開始日がある分の提供リスト
            Dictionary<int, PtMkrPriceWork> duplicateList = new Dictionary<int, PtMkrPriceWork>();

            // ユーザー価格マスタからリスト追加
            foreach (GetUsrGoodsUnitDataWork data in prcUpdtTrgtList)
            {
                if (data.PricePriceStartDate == 0) continue;

                if (!prcList.ContainsKey(data.PricePriceStartDate))
                {
                    prcList.Add(data.PricePriceStartDate, data);
                }
            }

            bool ofrDtExists = false;
            // 提供優良価格マスタからリスト追加
            foreach (PtMkrPriceWork ptMkrPriceWork in ptMkrPriceWorkList)
            {
                // このリストは品番順にソートされているので、品番が対象品番より大きくなったらBreak
                if (ptMkrPriceWork.NewPrtsNoWithHyphen.CompareTo(goodsNo) > 0) break;

                // マージ対象となるキーが一致していたら(ﾒｰｶｰ･品番) 
                if (makerCd == ptMkrPriceWork.MakerCode
                    && goodsNo == ptMkrPriceWork.NewPrtsNoWithHyphen)
                {
                    // 既にユーザーに同一価格開始日がある場合は重複リストに移行
                    if (prcList.ContainsKey(ptMkrPriceWork.PartsPriceStDate))
                    {
                        duplicateList.Add(ptMkrPriceWork.PartsPriceStDate, ptMkrPriceWork);
                    }
                    else
                    {
                        prcList.Add(ptMkrPriceWork.PartsPriceStDate, ptMkrPriceWork);
                    }

                    ofrDtExists = true;
                }
            }

            if (!ofrDtExists) return;

            // この時点で、prcListに、ユーザー+提供のリスト（提供の重複分を除く）、duplicateListに重複した提供のリストが入っている

            // 古い方から見ていく
            List<GoodsPriceUWork> allList = new List<GoodsPriceUWork>();    　// ユーザーデータの最新情報（価格順で）
            GetUsrGoodsUnitDataWork usrGoods = new GetUsrGoodsUnitDataWork(); // ユーザー商品

            foreach (int prcStDate in prcList.Keys)
            {
                // ユーザー商品
                if (prcList[prcStDate] is GetUsrGoodsUnitDataWork)
                {
                    usrGoods = (GetUsrGoodsUnitDataWork)prcList[prcStDate];
                    GoodsPriceUWork writeWork = new GoodsPriceUWork();
                    writeWork.CreateDateTime = usrGoods.PriceCreateDateTime;
                    writeWork.UpdateDateTime = usrGoods.PriceUpdateDateTime;
                    writeWork.EnterpriseCode = usrGoods.PriceEnterpriseCode;
                    writeWork.FileHeaderGuid = usrGoods.PriceFileHeaderGuid;
                    writeWork.UpdEmployeeCode = usrGoods.PriceUpdEmployeeCode;
                    writeWork.UpdAssemblyId1 = usrGoods.PriceUpdAssemblyId1;
                    writeWork.UpdAssemblyId2 = usrGoods.PriceUpdAssemblyId2;
                    writeWork.LogicalDeleteCode = usrGoods.PriceLogicalDeleteCode;

                    writeWork.GoodsMakerCd = usrGoods.GoodsMakerCd;
                    writeWork.GoodsNo = usrGoods.GoodsNo;
                    writeWork.PriceStartDate = DateTime.Parse(( usrGoods.PricePriceStartDate ).ToString("0000/00/00"));
                    writeWork.SalesUnitCost = usrGoods.PriceSalesUnitCost;
                    writeWork.StockRate = usrGoods.PriceStockRate;
                    writeWork.ListPrice = usrGoods.PriceListPrice;

                    // 提供データがあった場合
                    if (duplicateList.ContainsKey(prcStDate))
                    {
                        PtMkrPriceWork ofrData = duplicateList[prcStDate];

                        writeWork.UpdateDate = DateTime.Now;                                                // 更新日付
                        writeWork.OfferDate = DateTime.Parse(( ofrData.OfferDate ).ToString("0000/00/00")); // 提供日付
                        writeWork.OpenPriceDiv = ofrData.OpenPriceDiv;                                      // オープン価格区分

                        // 新しい定価がゼロの場合
                        if (ofrData.PartsPrice == 0)
                        {
                            // 提供データ更新設定マスタのオープン価格区分を参照してセット
                            if (priceMergeSt.OpenPriceFlg == 0)
                            {
                                writeWork.ListPrice = usrGoods.PriceListPrice;  // 元のユーザー価格を引継ぐ
                            }
                            else
                            {
                                writeWork.ListPrice = 0;         // 定価０
                            }
                        }
                        else
                        {
                            writeWork.ListPrice = ofrData.PartsPrice;
                        }
                        //------------ ADD By chenyd 2013/05/13 For Redmine #35515------------------------------->>>>>
                        double listPrice = writeWork.ListPrice;
                        this.ReflectIsolIslandCall(writeWork.GoodsMakerCd, ref listPrice);
                        writeWork.ListPrice = listPrice;
                        //------------ ADD By chenyd 2013/05/13 For Redmine #35515-------------------------------<<<<<

                        // 提供データがあった場合のみ価格改正リストへの追加
                        addList.Add(writeWork);
                    }
                    allList.Add(writeWork);
                }
                else if (prcList[prcStDate] is PtMkrPriceWork)
                {
                    PtMkrPriceWork ofrData = (PtMkrPriceWork)prcList[prcStDate];

                    GoodsPriceUWork writeWork = new GoodsPriceUWork();
                    writeWork.EnterpriseCode = enterpriseCode;              // 企業コード
                    writeWork.PriceStartDate = DateTime.Parse(( ofrData.PartsPriceStDate ).ToString("0000/00/00"));       // 価格開始日
                    writeWork.GoodsMakerCd = makerCd;                       // メーカー
                    writeWork.GoodsNo = goodsNo;                            // 品番
                    writeWork.UpdateDate = DateTime.Now;                    // 更新年月日

                    // ユーザー価格マスタの内容を引継ぐ(提供が一番古い場合は入らない)
                    writeWork.SalesUnitCost = usrGoods.PriceSalesUnitCost;   // 原価単価
                    writeWork.StockRate = usrGoods.PriceStockRate;           // 仕入率

                    writeWork.OfferDate = DateTime.Parse(( ofrData.OfferDate ).ToString("0000/00/00")); // 提供日付
                    writeWork.OpenPriceDiv = ofrData.OpenPriceDiv;          // オープン価格区分
                    writeWork.ListPrice = ofrData.PartsPrice;                // 定価

                    // 提供の標準価格がゼロの場合
                    if (ofrData.PartsPrice == 0)
                    {
                        // 提供データ更新設定マスタのオープン価格区分を参照してセット
                        if (priceMergeSt.OpenPriceFlg == 0)
                        {
                            if (allList.Count > 0)
                            {
                                writeWork.ListPrice = allList[allList.Count - 1].ListPrice;   // 1つ前の定価をセット
                            }
                        }
                    }
                    //------------ ADD By chenyd 2013/05/13 For Redmine #35515------------------------------->>>>>
                    double listPrice = writeWork.ListPrice;
                    this.ReflectIsolIslandCall(writeWork.GoodsMakerCd, ref listPrice);
                    writeWork.ListPrice = listPrice;
                    //------------ ADD By chenyd 2013/05/13 For Redmine #35515-------------------------------<<<<<

                    // 価格改正リストに追加
                    allList.Add(writeWork);

                    // 全件リストに追加
                    addList.Add(writeWork);
                }
            }

            // 管理件数を超えている場合、古いデータから消す
            if (allList.Count > pricMergeSt.PriceManage)
            {
                // 削除する件数
                int delCnt = allList.Count - pricMergeSt.PriceManage;

                for (int cnt = 0; cnt < delCnt; cnt++)
                {
                    GoodsPriceUWork data = allList[0];

                    // 作成日時が入っている場合は、ユーザー登録されていた分なので、削除リストに追加
                    if (data.CreateDateTime != DateTime.MinValue)
                    {
                        deleteList.Add(data);
                    }

                    // 追加・更新データに含まれる場合はリストから削除
                    if (addList.Contains(data)) addList.Remove(data);

                    // 先頭データを消す
                    allList.RemoveAt(0);
                }
            }
        }
        #endregion
   
        //------------ ADD By chenyd 2013/05/13 For Redmine #35515----------------------------------------->>>>>
        #region 離島価格反映
        /// <summary>
        /// 離島価格取得処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="_isolIslandList">離島価格リスト</param>
        /// <remarks>
        /// <br>Note       : 離島価格情報取得処理を行います。</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2013.05.13</br>
        /// </remarks>
        private void ReflectIsolIslandList(string enterpriseCode, out List<IsolIslandPrc> _isolIslandList)
        {
            // 離島価格取得
            if (this._isolIslandPrcAcs == null) this._isolIslandPrcAcs = new IsolIslandPrcAcs();
            this._isolIslandPrcAcs.Search(out _isolIslandList, enterpriseCode, false);
            _isolIslandList.Sort(new IsolIslandPrcWorkComparer());
        }

        /// <summary>
        /// 離島価格反映イベントコール
        /// </summary>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <param name="listPrice">標準価格</param>
        /// <remarks>
        /// <br>Note       : 離島価格情報取得処理を行います。</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2013.05.13</br>
        /// </remarks>
        private void ReflectIsolIslandCall(int goodsMakerCd, ref double listPrice)
        {
            // 離島価格反映
            IsolIslandPrc isolIslandPrc = this.GetIsolIslandPrc(goodsMakerCd, listPrice);
            if (isolIslandPrc != null) listPrice = this.GetIsolIslandPrice(isolIslandPrc, listPrice);
        }

        /// <summary>
        /// 離島価格情報取得処理
        /// </summary>
        /// <param name="goodsMakerCode">メーカーコード</param>
        /// <param name="unitPrice">標準価格</param>
        /// <returns>離島価格</returns>
        /// <remarks>
        /// <br>Note       : 離島価格情報取得処理を行います。</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2013.05.13</br>
        /// </remarks>
        private IsolIslandPrc GetIsolIslandPrc(int goodsMakerCode, double unitPrice)
        {
            List<IsolIslandPrc> IsolIslandPrcList = _isolIslandList.FindAll(
                delegate(IsolIslandPrc iso)
                {
                    if (iso.MakerCode == goodsMakerCode)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );
            if (IsolIslandPrcList != null && IsolIslandPrcList.Count > 0 && IsolIslandPrcList[0].UpperLimitPrice >= unitPrice) 
                return IsolIslandPrcList[0];
            else 
                return null;      

        }

        /// <summary>
        /// 離島価格取得処理
        /// </summary>
        /// <param name="isolIslandPrc">離島価格</param>
        /// <param name="targetPrice">標準価格</param>
        /// <returns>retPrice</returns>
        /// <remarks>
        /// <br>Note       : 離島価格取得処理を行います。</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2013.05.13</br>
        /// </remarks>
        private double GetIsolIslandPrice(IsolIslandPrc isolIslandPrc, double targetPrice)
        {
            double retPrice = targetPrice;

            int fracProcDiv = isolIslandPrc.FractionProcCd; // 金額端数処理区分
            double fracProcUnit = isolIslandPrc.FractionProcUnit; // 金額端数処理単位

            if ((isolIslandPrc.UpRate == 0) || (targetPrice == 0)) return 0;

            retPrice = (isolIslandPrc.UpRate < 0) ? targetPrice * (100 + isolIslandPrc.UpRate) * 0.01 : targetPrice * isolIslandPrc.UpRate * 0.01;

            FractionCalculate.FracCalcMoney(retPrice, fracProcUnit, fracProcDiv, out retPrice);

            return retPrice;
        }

        /// <summary>
        /// 離島価格情報比較クラス(拠点コード(昇順)・メーカーコード(昇順)・上限金額(昇順))
        /// </summary>
        private class IsolIslandPrcWorkComparer : Comparer<IsolIslandPrc>
        {
            public override int Compare(IsolIslandPrc x, IsolIslandPrc y)
            {
                int result = x.SectionCode.CompareTo(y.SectionCode);
                if (result != 0) return result;

                result = x.MakerCode.CompareTo(y.MakerCode);
                if (result != 0) return result;

                result = x.UpperLimitPrice.CompareTo(y.UpperLimitPrice);
                return result;
            }
        }
        #endregion
        //------------ ADD By chenyd 2013/05/13 For Redmine #35515-----------------------------------------<<<<<

   
        // 2010/04/23 Add <<<

        // 2010/04/23 >>>
        #region 削除
        // 新規作成処理 
        //private void WriteNewPrice(GetUsrGoodsUnitDataWork userGoodsUnitWork, PriceMergeSt priceMergeSt, ref ArrayList writepriceList, ref GoodsPriceUWork list)
        //{

        //    #region  キー部分格納
        //    writeGoodsPriseUwork.EnterpriseCode = userGoodsUnitWork.PriceEnterpriseCode;
        //    //writeGoodsPriseUwork.UpdateDateTime = userGoodsUnitWork.PriceUpdateDateTime;
        //    writeGoodsPriseUwork.CreateDateTime = userGoodsUnitWork.PriceCreateDateTime;
        //    writeGoodsPriseUwork.UpdAssemblyId1 = userGoodsUnitWork.PriceUpdAssemblyId1;
        //    writeGoodsPriseUwork.UpdAssemblyId2 = userGoodsUnitWork.PriceUpdAssemblyId2;
        //    writeGoodsPriseUwork.FileHeaderGuid = userGoodsUnitWork.PriceFileHeaderGuid;
        //    writeGoodsPriseUwork.LogicalDeleteCode = userGoodsUnitWork.PriceLogicalDeleteCode;

        //    writeGoodsPriseUwork.SalesUnitCost = userGoodsUnitWork.PriceSalesUnitCost;
        //    writeGoodsPriseUwork.StockRate = userGoodsUnitWork.PriceStockRate;
        //    writeGoodsPriseUwork.UpdEmployeeCode = userGoodsUnitWork.PriceUpdEmployeeCode;
        //    writeGoodsPriseUwork.GoodsMakerCd = PriorOfrGoodsPriceUWork.GoodsMakerCd;
        //    writeGoodsPriseUwork.GoodsNo = PriorOfrGoodsPriceUWork.GoodsNo;
        //    writeGoodsPriseUwork.OpenPriceDiv = PriorOfrGoodsPriceUWork.OpenPriceDiv;
        //    writeGoodsPriseUwork.PriceStartDate = PriorOfrGoodsPriceUWork.PriceStartDate;
        //    writeGoodsPriseUwork.OfferDate = PriorOfrGoodsPriceUWork.OfferDate;
        //    writeGoodsPriseUwork.UpdateDate = DateTime.Now;
        //    #endregion

        //    #region マージ部分格納
        //    // 通常価格の場合
        //    if (writeGoodsPriseUwork.OpenPriceDiv == 0)
        //    {
        //        writeGoodsPriseUwork.ListPrice = PriorOfrGoodsPriceUWork.ListPrice;
        //    }
        //    // オープン価格の場合
        //    else
        //    {
        //        // オープン価格区分が0:価格を引継ぐの場合
        //        if (priceMergeSt.OpenPriceFlg == 0)
        //        {
        //            //　部品価格引き継ぎ
        //            writeGoodsPriseUwork.ListPrice = PriorOfrGoodsPriceUWork.ListPrice;
        //        }
        //        // オープン価格区分が1:0で更新だったら
        //        else
        //        {
        //            // 0で更新
        //            writeGoodsPriseUwork.ListPrice = 0;
        //        }
        //    }
        //    #endregion

        //    // 前回ワークとして格納しておく
        //    //PriorGoodsPriceUWork = PriorOfrGoodsPriceUWork;
        //    PriorGoodsPriceUWork.CreateDateTime = PriorOfrGoodsPriceUWork.CreateDateTime;
        //    PriorGoodsPriceUWork.EnterpriseCode = PriorOfrGoodsPriceUWork.EnterpriseCode;
        //    PriorGoodsPriceUWork.FileHeaderGuid = PriorOfrGoodsPriceUWork.FileHeaderGuid;
        //    PriorGoodsPriceUWork.GoodsMakerCd = PriorOfrGoodsPriceUWork.GoodsMakerCd;
        //    PriorGoodsPriceUWork.GoodsNo = PriorOfrGoodsPriceUWork.GoodsNo;
        //    PriorGoodsPriceUWork.ListPrice = PriorOfrGoodsPriceUWork.ListPrice;
        //    PriorGoodsPriceUWork.LogicalDeleteCode = PriorOfrGoodsPriceUWork.LogicalDeleteCode;
        //    PriorGoodsPriceUWork.OfferDate = PriorOfrGoodsPriceUWork.OfferDate;
        //    PriorGoodsPriceUWork.OpenPriceDiv = PriorOfrGoodsPriceUWork.OpenPriceDiv;
        //    PriorGoodsPriceUWork.PriceStartDate = PriorOfrGoodsPriceUWork.PriceStartDate;
        //    PriorGoodsPriceUWork.SalesUnitCost = PriorOfrGoodsPriceUWork.SalesUnitCost;
        //    PriorGoodsPriceUWork.StockRate = PriorOfrGoodsPriceUWork.StockRate;
        //    PriorGoodsPriceUWork.UpdAssemblyId1 = PriorOfrGoodsPriceUWork.UpdAssemblyId1;
        //    PriorGoodsPriceUWork.UpdAssemblyId2 = PriorOfrGoodsPriceUWork.UpdAssemblyId2;
        //    PriorGoodsPriceUWork.UpdateDate = PriorOfrGoodsPriceUWork.UpdateDate;
        //    PriorGoodsPriceUWork.UpdateDateTime = PriorOfrGoodsPriceUWork.UpdateDateTime;
        //    PriorGoodsPriceUWork.UpdEmployeeCode = PriorOfrGoodsPriceUWork.UpdEmployeeCode;
        //}
        #endregion
        // 2010/04/23 <<<


        // ADD 2009/01/28 機能追加：優良設定マスタ ---------->>>>>
        /// <summary>
        /// 優良設定マスタをマージできるか判定します。
        /// </summary>
        /// <param name="mergeConditionFromUI">UIからのマージ条件</param>
        /// <returns>
        /// <c>true</c> :できる<br/>
        /// <c>false</c>:できない
        /// </returns>
        private static bool CanMergePrimeSettingMaster(MergeCond mergeConditionFromUI)
        {
            if (mergeConditionFromUI.PrmSetChgFlg.Equals(MergeCond.NOT_DOING_FLG_AS_INT))
            {
                return false;
            }
            if (mergeConditionFromUI.PrmSetFlg.Equals(MergeCond.NOT_DOING_FLG_AS_INT))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 優良設定マスタの名称項目をマージするか判定します。
        /// </summary>
        /// <param name="mergeConditionFromUI">UIからのマージ条件</param>
        /// <returns>
        /// <c>true</c> :できる<br/>
        /// <c>false</c>:できない
        /// </returns>
        private static bool UpdatesNameItemOfPrimeSettingMaster(MergeCond mergeConditionFromUI)
        {
            if (mergeConditionFromUI.PrmSetChgNmOwFlg)
            {
                return true;
            }
            if (mergeConditionFromUI.PrmSetNmOwFlg)
            {
                return true;
            }
            return false;
        }

        #region <実行結果/>

        /// <summary>実行結果</summary>
        private ProcessResult _processResult;
        /// <summary>
        /// 実行結果を取得します。
        /// </summary>
        public ProcessResult ProcessResult
        {
            get
            {
                if (_processResult == null)
                {
                    _processResult = new ProcessResult();
                }
                return _processResult;
            }
        }

        /// <summary>
        /// マージ処理の前処理を行います。
        /// </summary>
        private void BeginMerge()
        {
            _processResult = null;
        }

        /// <summary>
        /// マージ処理の更新件数をカウントします。
        /// </summary>
        /// <param name="blCodeMasterList">BLコードマスタのレコードリスト</param>
        /// <param name="blGroupMasterList">BLグループマスタのレコードリスト</param>
        /// <param name="middleGenreMasterList">中分類マスタのレコードリスト</param>
        /// <param name="modelNameMasterList">車種マスタのレコードリスト</param>
        /// <param name="makerMasterList">メーカーマスタのレコードリスト</param>
        /// <param name="primeSettingMasterList">優良設定マスタのレコードリスト</param>
        /// <param name="partsPosCodeMasterList">部位マスタのレコードリスト</param>
        private void CountMerge(
            ArrayList blCodeMasterList,
            ArrayList blGroupMasterList,
            ArrayList middleGenreMasterList,
            ArrayList modelNameMasterList,
            ArrayList makerMasterList,
            ArrayList primeSettingMasterList,
            ArrayList partsPosCodeMasterList
        )
        {
            // BLコードマスタ
            if (!MergeChecker.IsNullOrEmptyArrayList(blCodeMasterList))
            {
                ProcessResult.BLCodeMasterUpdatedCount += blCodeMasterList.Count;
            }
            // BLグループマスタ
            if (!MergeChecker.IsNullOrEmptyArrayList(blGroupMasterList))
            {
                ProcessResult.BLGroupMasterUpdatedCount += blGroupMasterList.Count;
            }
            // 中分類マスタ
            if (!MergeChecker.IsNullOrEmptyArrayList(middleGenreMasterList))
            {
                ProcessResult.MiddleGenreMasterUpdatedCount += middleGenreMasterList.Count;
            }
            // 車種マスタ
            if (!MergeChecker.IsNullOrEmptyArrayList(modelNameMasterList))
            {
                ProcessResult.ModelNameMasterUpdatedCount += modelNameMasterList.Count;
            }
            // メーカーマスタ
            if (!MergeChecker.IsNullOrEmptyArrayList(makerMasterList))
            {
                ProcessResult.MakerMasterUpdatedCount += makerMasterList.Count;
            }
            // 優良設定マスタ
            if (!MergeChecker.IsNullOrEmptyArrayList(primeSettingMasterList))
            {
                //ProcessResult.PrimeSettingMasterUpdatedCount += primeSettingMasterList.Count / 2;   // 論理削除分もあるので半分にする
                ProcessResult.PrimeSettingMasterUpdatedCount += prmSetAllUpdCount;
            }
            // 部位マスタ
            if (!MergeChecker.IsNullOrEmptyArrayList(partsPosCodeMasterList))
            {
                ProcessResult.PartsPosCodeMasterUpdatedCount += partsPosCodeMasterList.Count;
            }
        }

        /// <summary>
        /// 価格改正処理の更新件数をカウントします。
        /// </summary>
        /// <param name="goodsMasterList">商品マスタのレコードリスト</param>
        /// <param name="goodsPriceMasterList">価格マスタのレコードリスト</param>
        private void CountPriceRevision(
            ArrayList goodsMasterList,
            ArrayList goodsPriceMasterList
        )
        {
            if (!MergeChecker.IsNullOrEmptyArrayList(goodsMasterList))
            {
                ProcessResult.GoodsMasterUpdatedCount += goodsMasterList.Count;
            }
            if (!MergeChecker.IsNullOrEmptyArrayList(goodsPriceMasterList))
            {
                ProcessResult.GoodsPriceMasterUpdatedCount += goodsPriceMasterList.Count;
            }
        }

        #endregion  // <実行結果/>

        #region <ログ/>

        /// <summary>ロガー</summary>
        private readonly MyLogWriter _myLogger;
        /// <summary>
        /// ロガーを取得します。
        /// </summary>
        public MyLogWriter MyLogger { get { return _myLogger; } }

        #endregion  // <ログ/>
        // ADD 2008/01/28 機能追加：優良設定マスタ ----------<<<<<

        /// <summary>
        /// マージ処理を行う。[対象8テーブル]
        /// </summary>
        /// <param name="offerDate"></param>
        /// <param name="uiCondition"></param>
        /// <returns></returns>
        private int DoMerge(int offerDate, MergeCond uiCondition)
        {
            // ﾚｼﾞｽﾄﾘｷｰ取得
            StreamWriter writer = null;                          // テキストログ用
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

            if (key == null) // あってはいけないケース
            {
                workDir = @"C:\Program Files\Partsman\USER_AP"; // レジストリに情報がないため、仮にデフォルトのフォルダを設定
            }
            else
            {
                // ログ書き込みﾌｫﾙﾀﾞ指定
                workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
            }

            Directory.CreateDirectory(@"" + workDir + @"\Log\PMCMN06200S");

            //_autoFlg = uiCondition.PrmSetFlg;
            //_autoFlg = 0;
            if (_iMergeDataGetter == null) _iMergeDataGetter = MediationMergeDataGetDB.GetRemoteObject();

            // ADD 2009/02/02 機能追加：対象日付取得 ---------->>>>>
            #region [ 対象日付取得 ]


            // DEL 2009/02/23 不具合対応[11818]↓
            //ProcessConfig config = GetTargetAndSetProcessSequence(ProcessConfigAcs.Instance.Policy);
            ProcessConfig config = GetTargetAndSetProcessSequence(uiCondition.EnterpriseCode);  // ADD 2009/02/23 不具合対応[11818]
            if (ProcessSequence.Count.Equals(0))
            {
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            #endregion  // [ 対象日付取得 ]

            int status = 0;

            BeginMerge();

            // 更新フラグ保存
            MergeObjectCond UpdateMaster = new MergeObjectCond();
            UpdateMaster.BLFlg = uiCondition.BLFlg;
            UpdateMaster.BLGroupFlg = uiCondition.BLGroupFlg;
            UpdateMaster.GoodsMGroupFlg = uiCondition.GoodsMGroupFlg;
            UpdateMaster.GoodsUFlg = uiCondition.PriceRevisionFlg;
            UpdateMaster.ModelNameFlg = uiCondition.ModelNameFlg;
            UpdateMaster.PartsPosFlg = uiCondition.PartsPosFlg;
            UpdateMaster.PMakerFlg = uiCondition.PMakerFlg;
            UpdateMaster.PrmSetFlg = uiCondition.PrmSetFlg;

            bool margedPartsPosCodeMaster = false;  // 部位マスタのマージは1回のみ

            //SortedList<string, int> dateSequenceList = ProcessSequence.CreateDateSequenceList();
            //foreach (int enmOfferDate in dateSequenceList.Values)
            SortedList<int, string> dateSequenceList = ProcessSequence.CreateDateSequenceList(); // 1.5次分

            // ADD 2025/08/11 田村顕成 ----->>>>> 
            List<KeyValuePair<int, string>> tempSortList = new List<KeyValuePair<int, string>>();
            List<KeyValuePair<int, string>> dateSequenceListSorted = new List<KeyValuePair<int, string>>();
            foreach (KeyValuePair<int, string> dateSequence in dateSequenceList)
            {
                // 提供データ日付がスキップ対象期間であれば、リストの最後尾に移動する
                if (dateSequence.Key >= SkipOfferTermSt && dateSequence.Key <= SkipOfferTermEd)
                {
                    // 一時退避
                    tempSortList.Add(dateSequence);
                }
                else
                {
                    dateSequenceListSorted.Add(dateSequence);
                }
            }
            // 退避したデータをリストの最後尾に付ける
            dateSequenceListSorted.AddRange(tempSortList);
            // ADD 2025/08/11 田村顕成 -----<<<<<

            // DEL 2025/08/11 田村顕成 ----->>>>> 
            //foreach (int enmOfferDate in dateSequenceList.Keys)                                  // 1.5次分
            //{
            //    offerDate = enmOfferDate;
            // DEL 2025/08/11 田村顕成 -----<<<<<
            // ADD 2025/08/11 田村顕成 ----->>>>> 
            foreach (KeyValuePair<int, string> enmOfferDate in dateSequenceListSorted)
            {
                offerDate = enmOfferDate.Key;
            // ADD 2025/08/11 田村顕成 -----<<<<<

                // ﾃｷｽﾄﾛｸﾞ書込み (対象日付ﾙｰﾌﾟ)
                writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\PriceRevision.txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                writer.Write(DateTime.Now + " 対象日付毎に更新開始 " + "提供日付 " + DateTime.Parse(offerDate.ToString("0000/00/00")) + "\r\n");
                writer.Flush();
                if (writer != null) writer.Close();

                #region 1.5次分
                string writeDataFlg = string.Empty;
                dateSequenceList.TryGetValue(offerDate, out writeDataFlg);
                #endregion

                //Debug.WriteLine("対象日付：" + enmOfferDate.ToString());
                #region <Debug/>
#if _CONST_OFFER_DATE_
                offerDate = 20081001;   // HACK:仮対象日付：優良設定変更マスタなし、優良設定マスタ（提供データ分）なし
                offerDate = 20090105;   // HACK:仮対象日付：優良設定変更マスタあり、優良設定マスタ（提供データ分）あり
                //offerDate = 20080929;   // HACK:仮対象日付：優良設定変更マスタなし、優良設定マスタ（提供データ分）あり
#endif
                #endregion  // <Debug/>

                //MyLogger.Write("対象日付取得", "対象チェック", MyLogWriter.GetTargetCheckMessage(offerDate, ProcessSequence));
                // ADD 2009/02/02 機能追加：対象日付取得 ----------<<<<<

                #region [ マージ用提供情報取得 ]

                // 提供データの取得条件
                MergeInfoGetCond gettingOfferCondition = new MergeInfoGetCond();
                {
                    #region DELETE 1次分ロジック
                    //gettingOfferCondition.BLFlg = uiCondition.BLFlg;            // BLコードマスタ
                    //gettingOfferCondition.BLGroupFlg = uiCondition.BLGroupFlg;       // BLグループマスタ
                    //gettingOfferCondition.GoodsMGroupFlg = uiCondition.GoodsMGroupFlg;   // 中分類マスタ
                    //gettingOfferCondition.ModelNameFlg = uiCondition.ModelNameFlg;     // 車種マスタ
                    //gettingOfferCondition.PMakerFlg = uiCondition.PMakerFlg;        // メーカーマスタ
                    //gettingOfferCondition.PartsPosFlg = uiCondition.PartsPosFlg;      // 部位マスタ
                    //if (margedPartsPosCodeMaster == true)
                    //{
                    //    gettingOfferCondition.PartsPosFlg = 0;
                    //}
                    //// ADD 2009/01/28 機能追加：優良設定マスタ ---------->>>>>
                    //if (CanMergePrimeSettingMaster(uiCondition))
                    //{
                    //    gettingOfferCondition.PrmSetChgFlg = MergeCond.DOING_FLG_AS_INT;   // 優良設定変更マスタ
                    //    gettingOfferCondition.PrmSetFlg = MergeCond.DOING_FLG_AS_INT;   // 優良設定マスタ
                    //}
                    //else
                    //{
                    //    gettingOfferCondition.PrmSetChgFlg = MergeCond.NOT_DOING_FLG_AS_INT;
                    //    gettingOfferCondition.PrmSetFlg = MergeCond.NOT_DOING_FLG_AS_INT;
                    //}
                    #endregion

                    #region 1.5次分

                    gettingOfferCondition.BLFlg = uiCondition.BLFlg;            // BLコードマスタ
                    if (!( writeDataFlg.Contains("0") )) gettingOfferCondition.BLFlg = 0;
                    gettingOfferCondition.BLGroupFlg = uiCondition.BLGroupFlg;       // BLグループマスタ
                    if (!( writeDataFlg.Contains("1") )) gettingOfferCondition.BLGroupFlg = 0;
                    gettingOfferCondition.GoodsMGroupFlg = uiCondition.GoodsMGroupFlg;   // 中分類マスタ
                    if (!( writeDataFlg.Contains("2") )) gettingOfferCondition.GoodsMGroupFlg = 0;
                    gettingOfferCondition.ModelNameFlg = uiCondition.ModelNameFlg;     // 車種マスタ
                    if (!( writeDataFlg.Contains("3") )) gettingOfferCondition.ModelNameFlg = 0;
                    gettingOfferCondition.PMakerFlg = uiCondition.PMakerFlg;        // メーカーマスタ
                    if (!( writeDataFlg.Contains("4") )) gettingOfferCondition.PMakerFlg = 0;
                    gettingOfferCondition.PartsPosFlg = uiCondition.PartsPosFlg;      // 部位マスタ
                    if (uiCondition.PartsPosFlg != 0)
                    {
                        if (!( writeDataFlg.Contains("7") )) gettingOfferCondition.PartsPosFlg = 0;
                    }

                    // ADD 2009/01/28 機能追加：優良設定マスタ ---------->>>>>
                    if (CanMergePrimeSettingMaster(uiCondition))
                    {
                        gettingOfferCondition.PrmSetChgFlg = MergeCond.DOING_FLG_AS_INT;   // 優良設定変更マスタ
                        if (!( writeDataFlg.Contains("5") )) gettingOfferCondition.PrmSetChgFlg = 0;
                        gettingOfferCondition.PrmSetFlg = MergeCond.DOING_FLG_AS_INT;   // 優良設定マスタ
                        if (!( writeDataFlg.Contains("6") )) gettingOfferCondition.PrmSetFlg = 0;
                    }
                    else
                    {
                        gettingOfferCondition.PrmSetChgFlg = MergeCond.NOT_DOING_FLG_AS_INT;
                        gettingOfferCondition.PrmSetFlg = MergeCond.NOT_DOING_FLG_AS_INT;
                    }
                    #endregion

                    //MyLogger.Write(MyLogWriter.MERGING, MyLogWriter.GetTargetTableName(gettingOfferCondition), "マージ開始");
                    // ADD 2008/01/28 機能追加：優良設定マスタ ----------<<<<<
                }
                object retList = null;
                //if (margedPartsPosCodeMaster == false)
                //{
                status = _iMergeDataGetter.GetMergeData(
                    offerDate,
                    gettingOfferCondition,
                    out retList,
                    Option.SearchPartsType, // ADD 2009/02/20 不具合対応[11708] 引数：検索タイプの追加
                    Option.BigCarOfferDiv   // ADD 2009/02/20 不具合対応[11708] 引数：大型オプションの追加
                );
                //}
                //if (status != 0) return status;
                // ADD 2009/02/03 機能追加：優良設定マスタ ---------->>>>>
                #region Delete
                //if (!status.Equals((int)Result.RemoteStatus.Normal) && !status.Equals((int)Result.RemoteStatus.NotFound))
                //{
                //    MyLogger.Write(MyLogWriter.MERGING, MyLogWriter.GetTargetTableName(gettingOfferCondition), MyLogWriter.GetMergedMessage(status, null));
                //    //break;
                //}
                #endregion
                // ADD 2008/02/03 機能追加：優良設定マスタ ----------<<<<<


                if (retList == null) continue;

                //CustomSerializeArrayList lastOfferDataList = (CustomSerializeArrayList)retList;
                ArrayList lastOfferDataList = retList as ArrayList;
                // DEL 2009/02/23 不具合対応[11815]↓
                //if (lastOfferDataList.Count == 0) return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                #endregion  // [ マージ用提供情報取得 ]

                _enterpriseCode = uiCondition.EnterpriseCode;
                MergeObjectCond cond = new MergeObjectCond();
                int offerday = 0; // UIからのマージの場合の提供日付を取得しておく。

                #region [ 提供情報纏め ]

                ArrayList offerPMakerNmList = null; // 提供部品メーカー名称
                ArrayList offerModelNameList = null; // 提供車種マスタ
                ArrayList offerGoodsMGroupList = null; // 提供商品中分類マスタ
                ArrayList offerBLGroupList = null; // 提供BLグループマスタ
                ArrayList offerTbsPartsCodeList = null; // 提供BLコード
                ArrayList offerPartsPosList = null; // 提供部位マスタ
                //ArrayList ofrSupplierLst      = null; // 提供仕入先


                // ADD 2009/02/06 機能追加：優良設定マスタ ---------->>>>>
                ArrayList offerPrimeSettingChangeList = null; // 優良設定変更マスタ
                ArrayList offerPrimeSettingList = null;       // 優良設定マスタ
                // ADD 2008/02/06 機能追加：優良設定マスタ ----------<<<<<


                if (offerLstPrmSetChg == null) offerLstPrmSetChg = new Dictionary<int, ArrayList>(); // 優良設定変更マスタ <offerDate,変更ﾘｽﾄ> 1.5次分 
                if (offerLstPrmSet == null) offerLstPrmSet = new Dictionary<int, ArrayList>(); // 優良設定マスタ     <offerDate,設定ﾘｽﾄ> 1.5次分

                //offerLstPrmSetChg.Clear();
                //offerLstPrmSet.Clear();

                ArrayList lstPMakerCond = null;

                for (int i = 0; i < lastOfferDataList.Count; i++)
                {
                    // ADD 2009/02/06 機能追加：優良設定マスタ ---------->>>>>
                    if (MergeChecker.IsNullOrEmptyArrayList(lastOfferDataList[i] as ArrayList))
                    {
                        continue;
                    }
                    // ADD 2008/02/06 機能追加：優良設定マスタ ----------<<<<<

                    switch (( (ArrayList)lastOfferDataList[i] )[0].GetType().Name)
                    {
                        case "PMakerNmWork":          // 提供部品メーカー名称
                            offerPMakerNmList = lastOfferDataList[i] as ArrayList;
                            offerday = ( (PMakerNmWork)offerPMakerNmList[0] ).OfferDate;
                            cond.PMakerFlg = 1;
                            break;
                        case "ModelNameWork":       // 提供車種マスタ
                            offerModelNameList = lastOfferDataList[i] as ArrayList;
                            offerday = ( (ModelNameWork)offerModelNameList[0] ).OfferDate;
                            cond.ModelNameFlg = 1;

                            lstPMakerCond = new ArrayList();
                            foreach (ModelNameWork ModelNameWork in offerModelNameList)
                            {
                                ModelNameUWork ModelNameUWork = new ModelNameUWork();
                                ModelNameUWork.EnterpriseCode = _enterpriseCode;
                                ModelNameUWork.MakerCode = ModelNameWork.MakerCode;
                                ModelNameUWork.ModelCode = ModelNameWork.ModelCode;
                                ModelNameUWork.ModelSubCode = ModelNameWork.ModelSubCode;
                                ModelNameUWork.ModelUniqueCode = ModelNameWork.ModelUniqueCode;
                                lstPMakerCond.Add(ModelNameUWork);
                            }
                            break;

                        case "GoodsMGroupWork":       // 提供商品中分類マスタ
                            offerGoodsMGroupList = lastOfferDataList[i] as ArrayList;
                            offerday = ( (GoodsMGroupWork)offerGoodsMGroupList[0] ).OfferDate;
                            cond.GoodsMGroupFlg = 1;
                            break;

                        case "BLGroupWork":         // 提供BLグループマスタ
                            offerBLGroupList = lastOfferDataList[i] as ArrayList;
                            offerday = ( (BLGroupWork)offerBLGroupList[0] ).OfferDate;
                            cond.BLGroupFlg = 1;
                            break;

                        case "TbsPartsCodeWork":    // 提供BLコード
                            offerTbsPartsCodeList = lastOfferDataList[i] as ArrayList;
                            offerday = ( (TbsPartsCodeWork)offerTbsPartsCodeList[0] ).OfferDate;
                            cond.BLFlg = 1;
                            break;

                        case "PartsPosCodeWork":        // 提供部位マスタ
                            offerPartsPosList = lastOfferDataList[i] as ArrayList;
                            offerday = ( (PartsPosCodeWork)offerPartsPosList[0] ).OfferDate;
                            cond.PartsPosFlg = 1;
                            break;

                        // ADD 2009/02/06 機能追加：優良設定マスタ ---------->>>>>
                        case "PrmSettingChgWork":   // 優良設定変更マスタ
                            offerPrimeSettingChangeList = lastOfferDataList[i] as ArrayList;
                            offerday = ( (PrmSettingChgWork)offerPrimeSettingChangeList[0] ).OfferDate;
                            cond.PrmSetChgFlg = 1;
                            offerLstPrmSetChg.Add(offerday, offerPrimeSettingChangeList);
                            break;

                        case "PrmSettingWork":      // 優良設定マスタ
                            offerPrimeSettingList = lastOfferDataList[i] as ArrayList;
                            offerday = ( (PrmSettingWork)offerPrimeSettingList[0] ).OfferDate;
                            cond.PrmSetFlg = 1;
                            offerLstPrmSet.Add(offerday, offerPrimeSettingList);
                            break;

                        //case "OfrSupplierWork":
                        //    ofrSupplierLst = lstOfferData[i] as ArrayList;        // 提供仕入先（提供）
                        //    cond.SupplierFlg = 1;
                        //    break;
                        // ADD 2008/02/06 機能追加：優良設定マスタ ----------<<<<<
                    }
                }

                // ﾃｷｽﾄﾛｸﾞ書込み (提供データ取得)
                string MasterSerchLogText = string.Empty;

                if (offerPMakerNmList != null) MasterSerchLogText += ( "提供日付" + offerDate + " ﾒｰｶｰﾏｽﾀ取得 " + offerPMakerNmList.Count + "件" + "\r\n" );
                if (offerModelNameList != null) MasterSerchLogText += ( "提供日付" + offerDate + " 車種ﾏｽﾀ取得 " + offerModelNameList.Count + "件" + "\r\n" );
                if (offerGoodsMGroupList != null) MasterSerchLogText += ( "提供日付" + offerDate + " 中分類ﾏｽﾀ取得 " + offerGoodsMGroupList.Count + "件" + "\r\n" );
                if (offerBLGroupList != null) MasterSerchLogText += ( "提供日付" + offerDate + " BLｸﾞﾙｰﾌﾟﾏｽﾀ取得 " + offerBLGroupList.Count + "件" + "\r\n" );
                if (offerTbsPartsCodeList != null) MasterSerchLogText += ( "提供日付" + offerDate + " BLｺｰﾄﾞﾏｽﾀ取得 " + offerTbsPartsCodeList.Count + "件" + "\r\n" );
                if (offerPartsPosList != null) MasterSerchLogText += ( "提供日付" + offerDate + " 部位ﾏｽﾀ取得 " + offerPartsPosList.Count + "件" + "\r\n" );
                if (offerPrimeSettingChangeList != null) MasterSerchLogText += ( "提供日付" + offerDate + " 優良設定変更ﾏｽﾀ取得 " + offerPrimeSettingChangeList.Count + "件" + "\r\n" );
                if (offerPrimeSettingList != null) MasterSerchLogText += ( "提供日付" + offerDate + " 優良設定ﾏｽﾀ取得 " + offerPrimeSettingList.Count + "件" + "\r\n" );

                if (MasterSerchLogText != string.Empty)
                {
                    writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\PriceRevision.txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                    writer.Write(DateTime.Now + " 提供マスタデータ取得 \r\n" + MasterSerchLogText + "\r\n");
                    writer.Flush();
                    if (writer != null) writer.Close();
                }

                #endregion  // [ 提供情報纏め ]

                #region [ マージ用ユーザー情報取得 ]

                if (_iOfferMerger == null) _iOfferMerger = MediationOfferMergeDB.GetRemoteObject();
                cond.EnterpriseCode = _enterpriseCode;
                object retUsrList;
                // 車種は件数が多いため、提供にあるデータのみをユーザーDBから取得する。
                status = _iOfferMerger.GetMergeObject(cond, lstPMakerCond, out retUsrList);
                // ADD 2009/02/03 機能追加：優良設定マスタ ---------->>>>>
                if (!status.Equals((int)Result.RemoteStatus.Normal) && !status.Equals((int)Result.RemoteStatus.NotFound))
                {
                    MyLogger.Write(
                        MyLogWriter.MERGING,
                        MyLogWriter.GetTargetTableName(gettingOfferCondition),
                        MyLogWriter.GetMergedMessage(status, null)
                    );
                    //break;
                }
                // ADD 2008/02/03 機能追加：優良設定マスタ ----------<<<<<
                CustomSerializeArrayList lstUsrData = (CustomSerializeArrayList)retUsrList;

                ArrayList userPMakerNmList = null;        // ユーザー部品メーカー名称
                ArrayList userModelNameList = null;     // ユーザー車種マスタ
                ArrayList userGoodsMGroupList = null;     // ユーザー商品中分類マスタ
                ArrayList userBLGroupList = null;       // ユーザーBLグループマスタ
                ArrayList usrTbsPartsCodeLst = null;  // ユーザーBLコード
                //ArrayList usrSupplierLst = null;      // ユーザー仕入先マスタ
                ArrayList userPartsPosList = null;      // ユーザー部位マスタ

                // ADD 2009/02/06 機能追加：優良設定マスタ ---------->>>>>
                ArrayList userPrimeSettingList = null;  // 優良設定マスタ（ユーザー登録分）
                // ADD 2008/02/06 機能追加：優良設定マスタ ----------<<<<<

                for (int i = 0; i < lstUsrData.Count; i++)
                {
                    // ADD 2009/02/06 機能追加：優良設定マスタ ---------->>>>>
                    if (MergeChecker.IsNullOrEmptyArrayList(lstUsrData[i] as ArrayList)) continue;
                    // ADD 2008/02/06 機能追加：優良設定マスタ ----------<<<<<

                    if (( (ArrayList)lstUsrData[i] ).Count == 0) continue;

                    switch (( (ArrayList)lstUsrData[i] )[0].GetType().Name)
                    {
                        case "MakerUWork":
                            userPMakerNmList = lstUsrData[i] as ArrayList;          // ユーザー部品メーカー名称
                            break;
                        case "ModelNameUWork":
                            userModelNameList = lstUsrData[i] as ArrayList;       // ユーザー車種マスタ
                            break;
                        case "GoodsGroupUWork":
                            userGoodsMGroupList = lstUsrData[i] as ArrayList;       // ユーザー商品中分類マスタ
                            break;
                        case "BLGroupUWork":
                            userBLGroupList = lstUsrData[i] as ArrayList;         // ユーザーBLグループマスタ
                            break;
                        case "BLGoodsCdUWork":
                            usrTbsPartsCodeLst = lstUsrData[i] as ArrayList;    // ユーザーBLコード
                            break;
                        //case "SupplierWork":
                        //    usrSupplierLst = lstUsrData[i] as ArrayList;        // ユーザー仕入先マスタ
                        //    break;
                        case "PartsPosCodeUWork":
                            userPartsPosList = lstUsrData[i] as ArrayList;        // ユーザー部位マスタ
                            break;
                        // ADD 2009/02/06 機能追加：優良設定マスタ ---------->>>>>
                        case "PrmSettingUWork": // 優良設定マスタ（ユーザー登録分）
                            userPrimeSettingList = lstUsrData[i] as ArrayList;
                            break;
                        // ADD 2008/02/06 機能追加：優良設定マスタ ----------<<<<<
                    }
                }

                #endregion  // [ マージ用ユーザー情報取得 ]

                #region [ 提供→ユーザーデータ変換処理 ]

                if (userUpdatingPMakerList == null) userUpdatingPMakerList = new ArrayList();  // ユーザー部品メーカー名称更新データリスト
                if (userUpdatingModelNameList == null) userUpdatingModelNameList = new ArrayList();  // ユーザー車種マスタ更新データリスト
                if (userUpdatingGoodsMGroupList == null) userUpdatingGoodsMGroupList = new ArrayList();  // ユーザー商品中分類マスタ更新データリスト
                if (userUpdatingBLGroupList == null) userUpdatingBLGroupList = new ArrayList();  // ユーザーBLコード更新データリスト
                if (userUpdatingTbsPartsCodeList == null) userUpdatingTbsPartsCodeList = new ArrayList();  // ユーザーBLグループマスタ更新データリスト
                if (userUpdatingPartsPosList == null) userUpdatingPartsPosList = new ArrayList();  // ユーザー部位マスタ更新データリスト
                //ArrayList usrUpdateSupplierLst = new ArrayList();                                      // ユーザー仕入先マスタ更新データリスト

                #region [ 部品メーカーマスタ ]
                if (offerPMakerNmList != null)
                {
                    int cnt = 0;
                    if (userPMakerNmList != null)
                        cnt = userPMakerNmList.Count;
                    foreach (PMakerNmWork pMakerNmWork in offerPMakerNmList)
                    {
                        bool flg = false;
                        MakerUWork usrPMakerNm = null;

                        for (int i = 0; i < cnt; i++)
                        {
                            usrPMakerNm = userPMakerNmList[i] as MakerUWork;
                            if (pMakerNmWork.PartsMakerCode == usrPMakerNm.GoodsMakerCd)
                            {
                                flg = true;
                                break;
                            }
                        }

                        if (flg == false)
                        {
                            usrPMakerNm = null;
                        }
                        if (ConvertPMakerNm(pMakerNmWork, ref usrPMakerNm))
                            userUpdatingPMakerList.Add(usrPMakerNm);
                    }
                }
                #endregion

                #region [ 車種名称マスタ ]
                if (offerModelNameList != null)
                {
                    int cnt = 0;
                    if (userModelNameList != null)
                        cnt = userModelNameList.Count;
                    foreach (ModelNameWork ModelNameWork in offerModelNameList)
                    {
                        bool flg = false;
                        ModelNameUWork usrModelName = null;
                        for (int i = 0; i < cnt; i++)
                        {
                            usrModelName = userModelNameList[i] as ModelNameUWork;
                            if (ModelNameWork.ModelUniqueCode == usrModelName.ModelUniqueCode)
                            {
                                flg = true;
                                break;
                            }
                        }
                        if (flg == false)
                        {
                            usrModelName = null;
                        }
                        if (ConvertModelName(ModelNameWork, ref usrModelName))
                            userUpdatingModelNameList.Add(usrModelName);
                    }
                }
                #endregion

                #region [ 商品中分類マスタ ]
                if (offerGoodsMGroupList != null)
                {
                    int cnt = 0;
                    if (userGoodsMGroupList != null)
                        cnt = userGoodsMGroupList.Count;
                    foreach (GoodsMGroupWork GoodsMGroupWork in offerGoodsMGroupList)
                    {
                        bool flg = false;
                        GoodsGroupUWork usrGoodsGroup = null;
                        for (int i = 0; i < cnt; i++)
                        {
                            usrGoodsGroup = userGoodsMGroupList[i] as GoodsGroupUWork;
                            if (GoodsMGroupWork.GoodsMGroup == usrGoodsGroup.GoodsMGroup)
                            {
                                flg = true;
                                break;
                            }
                        }
                        if (flg == false)
                        {
                            usrGoodsGroup = null;
                        }
                        if (ConvertGoodsMGroup(uiCondition.GoodsMGroupNmOwFlg, GoodsMGroupWork, ref usrGoodsGroup))
                            userUpdatingGoodsMGroupList.Add(usrGoodsGroup);
                    }
                }
                #endregion

                #region [ BLグループコードマスタ ]
                if (offerBLGroupList != null)
                {
                    int cnt = 0;
                    if (userBLGroupList != null)
                        cnt = userBLGroupList.Count;
                    foreach (BLGroupWork BLGroupWork in offerBLGroupList)
                    {
                        bool flg = false;
                        BLGroupUWork usrBLGroup = null;
                        for (int i = 0; i < cnt; i++)
                        {
                            usrBLGroup = userBLGroupList[i] as BLGroupUWork;
                            if (BLGroupWork.BLGroupCode == usrBLGroup.BLGroupCode)
                            {
                                flg = true;
                                break;
                            }
                        }
                        if (flg == false)
                        {
                            usrBLGroup = null;
                        }
                        if (ConvertBLGroup(uiCondition.BLGroupNmOwFlg, BLGroupWork, ref usrBLGroup))
                            userUpdatingBLGroupList.Add(usrBLGroup);
                    }
                }
                #endregion

                #region [ ＢＬコードマスタ ]
                if (offerTbsPartsCodeList != null)
                {
                    int cnt = 0;
                    if (usrTbsPartsCodeLst != null)
                        cnt = usrTbsPartsCodeLst.Count;
                    foreach (TbsPartsCodeWork TbsPartsCodeWork in offerTbsPartsCodeList)
                    {
                        bool flg = false;
                        BLGoodsCdUWork usrBLGoodsCd = null;
                        for (int i = 0; i < cnt; i++)
                        {
                            usrBLGoodsCd = usrTbsPartsCodeLst[i] as BLGoodsCdUWork;
                            if (TbsPartsCodeWork.TbsPartsCode == usrBLGoodsCd.BLGoodsCode)
                            {
                                flg = true;
                                break;
                            }
                        }
                        if (flg == false)
                        {
                            usrBLGoodsCd = null;
                        }
                        if (ConvertBL(uiCondition.BLNmOwFlg, TbsPartsCodeWork, ref usrBLGoodsCd))
                            userUpdatingTbsPartsCodeList.Add(usrBLGoodsCd);
                    }

                }
                #endregion

                #region [ 仕入先マスタ ]
                /*if (ofrSupplierLst != null)
            {
                int cnt = 0;
                if (usrSupplierLst != null)
                    cnt = usrSupplierLst.Count;
                foreach (OfrSupplierWork OfrSupplierWork in ofrSupplierLst)
                {
                    bool flg = false;
                    SupplierWork usrSupplier = null;
                    for (int i = 0; i < cnt; i++)
                    {
                        usrSupplier = usrSupplierLst[i] as SupplierWork;
                        if (OfrSupplierWork.SupplierCd == usrSupplier.SupplierCd)
                        {
                            flg = true;
                            break;
                        }
                    }
                    if (flg == false)
                    {
                        usrSupplier = null;
                    }
                    if (ConvertSupplier(enterpriseCode, OfrSupplierWork, ref usrSupplier))
                        usrUpdateSupplierLst.Add(usrSupplier);
                }
            }*/
                #endregion

                #region [ 部位マスタ ]
                if (offerPartsPosList != null && !margedPartsPosCodeMaster)   // 部位マスタのマージは1回のみ
                //if (offerPartsPosList != null)
                {
                    int cnt = 0;
                    if (userPartsPosList != null)
                        cnt = userPartsPosList.Count;
                    //lstPartsPos = new List<string>();
                    foreach (PartsPosCodeWork PartsPosCodeWork in offerPartsPosList)
                    {
                        bool flg = false;
                        PartsPosCodeUWork usrPartsPos = null;
                        for (int i = 0; i < cnt; i++)
                        {
                            usrPartsPos = userPartsPosList[i] as PartsPosCodeUWork;
                            if (PartsPosCodeWork.SearchPartsPosCode == usrPartsPos.SearchPartsPosCode
                                && PartsPosCodeWork.TbsPartsCode == usrPartsPos.TbsPartsCode)
                            {
                                flg = true;
                                break;
                            }
                        }
                        if (flg == false)
                        {
                            usrPartsPos = null;
                        }
                        if (ConvertPartsPos(uiCondition.PartsPosNmOwFlg, PartsPosCodeWork, ref usrPartsPos, Option.SearchPartsType, Option.BigCarOfferDiv))
                        {
                            userUpdatingPartsPosList.Add(usrPartsPos);
                        }
                    }
                    margedPartsPosCodeMaster = true;
                }
                #endregion

                // ADD 2009/02/06 機能追加：優良設定マスタ ---------->>>>>
                // 優良設定マスタ（ユーザー登録分）
                #region [ 優良設定マスタ ]

                //if (UsrUpdatePrmsetList == null) UsrUpdatePrmsetList = new CustomSerializeArrayList();
                //if (offerLstPrmSet != null && offerLstPrmSet.Count > 0) UsrUpdatePrmsetList.Add(offerLstPrmSet);
                //if (offerLstPrmSetChg != null && offerLstPrmSetChg.Count > 0) UsrUpdatePrmsetList.Add(offerLstPrmSetChg);

                //// 優良設定マスタ（ユーザー登録分）更新データリストと削除リスト
                //UserUpdatingPrimeSettingPair userUpdatingPrimeSettingPair = PrimeSettingMergeFacade.Merge(
                //    offerDate,
                //    offerPrimeSettingChangeList,
                //    offerPrimeSettingList,
                //    userPrimeSettingList,
                //    UpdatesNameItemOfPrimeSettingMaster(uiCondition)
                //);
                //ArrayList updatingPrmSettingUWorkList = userUpdatingPrimeSettingPair.First; // 優良設定マスタ（ユーザー登録分）更新リスト
                //ArrayList deletingPrmSettingUWorkList = userUpdatingPrimeSettingPair.Second;// 優良設定マスタ（ユーザー登録分）削除リスト

                #endregion  // [ 優良設定マスタ ]
                // ADD 2008/02/06 機能追加：優良設定マスタ ----------<<<<<

                #endregion  // [ 提供→ユーザーデータ変換処理 ]

                #region [ ユーザーDBへ書込み ]

                #region 1.5次対応により日付for文の下に移動(一括更新)
                //CustomSerializeArrayList lstUsrUpdateData = new CustomSerializeArrayList();
                //if (userUpdatingPMakerList.Count > 0) // ユーザー部品メーカー名称更新データリスト
                //    lstUsrUpdateData.Add(userUpdatingPMakerList);
                //if (userUpdatingModelNameList.Count > 0) // ユーザー車種マスタ更新データリスト
                //    lstUsrUpdateData.Add(userUpdatingModelNameList);
                //if (userUpdatingGoodsMGroupList.Count > 0) // ユーザー商品中分類マスタ更新データリスト
                //    lstUsrUpdateData.Add(userUpdatingGoodsMGroupList);
                //if (userUpdatingBLGroupList.Count > 0) // ユーザーBLコード更新データリスト
                //    lstUsrUpdateData.Add(userUpdatingBLGroupList);
                //if (userUpdatingTbsPartsCodeList.Count > 0) // ユーザーBLグループマスタ更新データリスト
                //    lstUsrUpdateData.Add(userUpdatingTbsPartsCodeList);
                //if (usrUpdateSupplierLst.Count > 0) // ユーザー仕入先マスタ更新データリスト
                //    lstUsrUpdateData.Add(usrUpdateSupplierLst);
                #region DELETE
                // ADD 2009/02/09 機能追加：優良設定マスタ ---------->>>>>
                // 優良設定マスタ（ユーザー登録分）更新データリスト
                //if (updatingPrmSettingUWorkList.Count > 0)
                //{
                //    lstUsrUpdateData.Add(updatingPrmSettingUWorkList);
                //}
                ////優良設定マスタ（ユーザー登録分）削除データリスト
                //if (deletingPrmSettingUWorkList.Count > 0)
                //{
                //    // 削除する商品管理情報を取得
                //    ArrayList deletingGoodsMngWorkList = PrimeSettingMergeFacade.GetGoodsMngWorkList(
                //        deletingPrmSettingUWorkList
                //    );
                //    // 優良設定マスタ（ユーザー登録分）を削除
                //    IPrmSettingUDB dbDeleter = (IPrmSettingUDB)MediationPrmSettingUDB.GetPrmSettingUDB();
                //    {
                //        object objDeletingPrimeSettingUWorkList = (object)deletingPrmSettingUWorkList;
                //        object objDeletingGoodsMngWorkList = (object)deletingGoodsMngWorkList;
                //        status = dbDeleter.Delete(objDeletingPrimeSettingUWorkList, objDeletingGoodsMngWorkList);
                //        //if (!status.Equals((int)Result.RemoteStatus.Normal))
                //        //{
                //        //    MyLogger.Write(
                //        //        MyLogWriter.MERGING,
                //        //        MyLogWriter.GetTargetTableName(gettingOfferCondition),
                //        //        MyLogWriter.GetMergedMessage(status, lstUsrUpdateData)
                //        //    );
                //        //    break;
                //        //}
                //    }
                //}
                // ADD 2008/02/09 機能追加：優良設定マスタ ----------<<<<<
                #endregion

                //if (userUpdatingPartsPosList.Count > 0) // ユーザー部位マスタ更新データリスト
                //    lstUsrUpdateData.Add(userUpdatingPartsPosList);
                #endregion

                // ADD 2009/02/03 機能追加：価格改正 ---------->>>>>
                #region [ 価格改正処理 ]

                if (uiCondition.PriceRevisionFlg.Equals(MergeCond.DOING_FLG_AS_INT) && ( ( writeDataFlg.Contains("8") ) || ( writeDataFlg.Contains("9") ) ))
                {
                    status = PriceRevision(_enterpriseCode, offerDate, out priceRevisionParameter);
                    if (!( status.Equals((int)Result.RemoteStatus.Normal) || status.Equals((int)Result.RemoteStatus.NotFound) ))
                    {
                        MyLogger.Write(MyLogWriter.PRICE_REVISION, string.Empty, MyLogWriter.GetPriceRevisionMessage(status, null));
                        return status;  // ADD 2010/07/02 異常終了した場合は、処理を行わない
                        //break;
                    }
                }
                if (priceRevisionParameter == null)
                {
                    priceRevisionParameter = new PriceRevisionParameter(_enterpriseCode);
                }

                #endregion  // [ 価格改正処理 ]
                // ADD 2008/02/03 機能追加：価格改正 ----------<<<<<

                #region 1.5次対応により日付For文の下に移動(一括更新)
                /*
                if (lstUsrUpdateData.Count > 0 || priceRevisionParameter.MergedPriceRevisionList.Count > 0 || offerLstPrmSet.Count > 0 || offerLstPrmSetChg.Count > 0)
                {
                    int updateDataDiv;
                    int _offerDate;

                    // DEL 2009/02/11 機能追加：価格改正を手動で行う ---------->>>>>
                    #region 削除コード
                    //if (offerDate == 0)
                    //{
                    //    updateDataDiv = 0;  // HACK:手動
                    //    _offerDate = offerday;
                    //}
                    //else
                    //{
                    //    updateDataDiv = 1;  // HACK:自動
                    //    _offerDate = offerDate;
                    //}
                    #endregion
                    // DEL 2009/02/11 機能追加：価格改正を手動で行う ----------<<<<<
                    // ADD 2009/02/11 機能追加：価格改正を手動で行う ---------->>>>>
                    updateDataDiv = 0;  // 手動
                    _offerDate = offerDate;
                    // ADD 2009/02/11 機能追加：価格改正を手動で行う ----------<<<<<
                    // ADD 2009/02/10 不具合対応[11706] ---------->>>>>
                    // 優良設定マスタをマージする条件が成立した場合、自動とみなす
                    if (CanMergePrimeSettingMaster(uiCondition))
                    {
                        updateDataDiv = 1;  // 自動
                    }
                    // ADD 2009/02/19 不具合対応[11706] ----------<<<<<
                    // DEL 2009/02/11 機能追加↓：価格改正を手動で行う
                    //status = _iOfferMerger.WriteMergeData(updateDataDiv, _offerDate, lstUsrUpdateData);
                    status = _iOfferMerger.WriteManual(
                        updateDataDiv,
                        _offerDate,
                        priceRevisionParameter.PriceMergeSetting,
                        priceRevisionParameter.MergedPriceRevisionList,
                        out priceRevisionParameter.RetList,
                        lstUsrUpdateData,
                        UsrUpdatePrmsetList,
                        _enterpriseCode,
                        Checker.CurrentVersion,
                        uiCondition.PrmSetNmOwFlg
                    );
                    // ADD 2009/02/03 機能追加：優良設定マスタ ---------->>>>>
                    if (!status.Equals((int)Result.RemoteStatus.Normal) && !status.Equals((int)Result.RemoteStatus.NotFound))
                    {
                        MyLogger.Write(
                            MyLogWriter.MERGING,
                            MyLogWriter.GetTargetTableName(gettingOfferCondition),
                            MyLogWriter.GetMergedMessage(status, lstUsrUpdateData)
                        );
                        break;
                    }

                    // 更新件数をカウント
                    CountMerge(
                        userUpdatingTbsPartsCodeList,
                        userUpdatingBLGroupList,
                        userUpdatingGoodsMGroupList,
                        userUpdatingModelNameList,
                        userUpdatingPMakerList,
                        UsrUpdatePrmsetList,
                        userUpdatingPartsPosList
                    );

                    // 手動の場合の場合は部位マスタのマージは1回のみ
                    if (_autoFlg == 0)
                    {
                        margedPartsPosCodeMaster = true;
                    }

                    //MyLogger.Write(
                    //    MyLogWriter.MERGING,
                    //    MyLogWriter.GetTargetTableName(gettingOfferCondition),
                    //    MyLogWriter.GetMergedMessage(status, lstUsrUpdateData)
                    //);
                    // ADD 2008/02/03 機能追加：優良設定マスタ ----------<<<<<
                }   // if (lstUsrUpdateData.Count > 0)

                

                #if _CONST_OFFER_DATE_
                break;  // 1回分のみ
                #endif
            */
                #endregion

                #endregion  // [ ユーザーDBへ書込み ]

            }   // foreach (int enmOfferDate in dateSequenceList.Values)

            #region 1.5次分 ADD ﾕｰｻﾞｰDBへ書込み

            // 更新リストにAdd
            CustomSerializeArrayList lstUsrUpdateData = new CustomSerializeArrayList();
            if (userUpdatingPMakerList.Count > 0)       // ユーザー部品メーカー名称更新データリスト
                lstUsrUpdateData.Add(userUpdatingPMakerList);
            if (userUpdatingModelNameList.Count > 0)    // ユーザー車種マスタ更新データリスト
                lstUsrUpdateData.Add(userUpdatingModelNameList);
            if (userUpdatingGoodsMGroupList.Count > 0)  // ユーザー商品中分類マスタ更新データリスト
                lstUsrUpdateData.Add(userUpdatingGoodsMGroupList);
            if (userUpdatingBLGroupList.Count > 0)      // ユーザーBLコード更新データリスト
                lstUsrUpdateData.Add(userUpdatingBLGroupList);
            if (userUpdatingTbsPartsCodeList.Count > 0) // ユーザーBLグループマスタ更新データリスト
                lstUsrUpdateData.Add(userUpdatingTbsPartsCodeList);
            if (userUpdatingPartsPosList.Count > 0)     // ユーザー部位マスタ更新データリスト
                lstUsrUpdateData.Add(userUpdatingPartsPosList);

            if (lst == null) lst = new CustomSerializeArrayList();

            lst.Add(writeGoodsList);
            lst.Add(writePricesList);
            lst.Add(deletePriceList);

            priceRevisionParameter.MergedPriceRevisionList = lst;
            priceRevisionParameter.PriceMergeSetting = pricMergeSt;
            CountPriceRevision(writeGoodsList, writePricesList);

            if (UsrUpdatePrmsetList == null) UsrUpdatePrmsetList = new CustomSerializeArrayList();
            if (offerLstPrmSet != null && offerLstPrmSet.Count > 0) UsrUpdatePrmsetList.Add(offerLstPrmSet);
            if (offerLstPrmSetChg != null && offerLstPrmSetChg.Count > 0) UsrUpdatePrmsetList.Add(offerLstPrmSetChg);


            // 更新リストが存在する場合
            if (lstUsrUpdateData.Count > 0 || priceRevisionParameter.MergedPriceRevisionList.Count > 0 || offerLstPrmSet.Count > 0 || offerLstPrmSetChg.Count > 0)
            {
                int updateDataDiv;
                int _offerDate;

                updateDataDiv = 0;  // 手動
                _offerDate = offerDate;
                prmSetAllUpdCount = 0;

                // 自動フラグがあれば
                if (_autoFlg == 1) updateDataDiv = 1;  // 自動

                object updateMasterobj = UpdateMaster;

                status = _iOfferMerger.WriteManual(
                    updateDataDiv,
                    _offerDate,
                    priceRevisionParameter.PriceMergeSetting,
                    priceRevisionParameter.MergedPriceRevisionList,
                    out priceRevisionParameter.RetList,
                    lstUsrUpdateData,
                    UsrUpdatePrmsetList,
                    _enterpriseCode,
                    Checker.CurrentVersion,
                    uiCondition.PrmSetNmOwFlg,
                    ref prmSetAllUpdCount,
                    updateMasterobj,
                    partsPsDate
                );
                // ADD 2009/02/03 機能追加：優良設定マスタ ---------->>>>>
                if (!status.Equals((int)Result.RemoteStatus.Normal) && !status.Equals((int)Result.RemoteStatus.NotFound))
                {
                    //MyLogger.Write(MyLogWriter.MERGING, MyLogWriter.GetTargetTableName(gettingOfferCondition), MyLogWriter.GetMergedMessage(status, lstUsrUpdateData));
                    //break;
                }



                // 更新件数をカウント
                CountMerge(
                    userUpdatingTbsPartsCodeList,
                    userUpdatingBLGroupList,
                    userUpdatingGoodsMGroupList,
                    userUpdatingModelNameList,
                    userUpdatingPMakerList,
                    UsrUpdatePrmsetList,
                    userUpdatingPartsPosList
                );

                // ﾃｷｽﾄﾛｸﾞ書込み (提供データ取得)
                string writeUserDBLogText = string.Empty;

                if (userUpdatingPMakerList != null) writeUserDBLogText += ( "ﾒｰｶｰﾏｽﾀ " + userUpdatingPMakerList.Count + "件" + "\r\n" );
                if (userUpdatingModelNameList != null) writeUserDBLogText += ( "車種ﾏｽﾀ " + userUpdatingModelNameList.Count + "件" + "\r\n" );
                if (userUpdatingGoodsMGroupList != null) writeUserDBLogText += ( "中分類ﾏｽﾀ " + userUpdatingGoodsMGroupList.Count + "件" + "\r\n" );
                if (userUpdatingBLGroupList != null) writeUserDBLogText += ( "BLｸﾞﾙｰﾌﾟﾏｽﾀ " + userUpdatingBLGroupList.Count + "件" + "\r\n" );
                if (userUpdatingTbsPartsCodeList != null) writeUserDBLogText += ( "BLｺｰﾄﾞﾏｽﾀ " + userUpdatingTbsPartsCodeList.Count + "件" + "\r\n" );
                if (userUpdatingPartsPosList != null) writeUserDBLogText += ( "部位ﾏｽﾀ " + userUpdatingPartsPosList.Count + "件" + "\r\n" );
                if (UsrUpdatePrmsetList != null) writeUserDBLogText += ( "優良設定ﾏｽﾀ " + prmSetAllUpdCount + "件" + "\r\n" );
                if (writeGoodsList != null) writeUserDBLogText += ( "商品ﾏｽﾀ" + writeGoodsList.Count + "件" + "\r\n" );
                if (writePricesList != null) writeUserDBLogText += ( "価格ﾏｽﾀ" + writePricesList.Count + "件" + "\r\n" );

                if (writeUserDBLogText != string.Empty)
                {
                    writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\PriceRevision.txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                    writer.Write(DateTime.Now + " ﾕｰｻﾞｰDB更新処理 " + "status = " + status + "\r\n" + writeUserDBLogText + "\r\n");
                    writer.Flush();
                    if (writer != null) writer.Close();
                }
            }
            #endregion

            // バージョンを更新 DELETE
            //status = Checker.UpdateVersion();   // ADD 2009/02/20 不具合対応[11707]

            #region ｸﾘｱ処理
            if (writeGoodsList != null) writeGoodsList.Clear();
            if (writePricesList != null) writePricesList.Clear();
            if (deletePriceList != null) deletePriceList.Clear();
            if (lst != null) lst.Clear();
            if (userUpdatingPMakerList != null) userUpdatingPMakerList.Clear();
            if (userUpdatingModelNameList != null) userUpdatingModelNameList.Clear();
            if (userUpdatingGoodsMGroupList != null) userUpdatingGoodsMGroupList.Clear();
            if (userUpdatingBLGroupList != null) userUpdatingBLGroupList.Clear();
            if (userUpdatingTbsPartsCodeList != null) userUpdatingTbsPartsCodeList.Clear();
            if (userUpdatingPartsPosList != null) userUpdatingPartsPosList.Clear();
            if (priceRevisionParameter.MergedPriceRevisionList != null) priceRevisionParameter.MergedPriceRevisionList.Clear();
            if (offerLstPrmSetChg != null) offerLstPrmSetChg.Clear();
            if (offerLstPrmSet != null) offerLstPrmSet.Clear();
            if (UsrUpdatePrmsetList != null) UsrUpdatePrmsetList.Clear();
            if (lstUsrUpdateData != null) lstUsrUpdateData.Clear();
            if (userUpdatingPMakerList != null) userUpdatingPMakerList.Clear();
            if (userUpdatingModelNameList != null) userUpdatingModelNameList.Clear();
            if (userUpdatingGoodsMGroupList != null) userUpdatingGoodsMGroupList.Clear();
            if (userUpdatingBLGroupList != null) userUpdatingBLGroupList.Clear();
            if (userUpdatingTbsPartsCodeList != null) userUpdatingTbsPartsCodeList.Clear();
            if (userUpdatingPartsPosList != null) userUpdatingPartsPosList.Clear();
            if (offerLstPrmSetChg != null) offerLstPrmSetChg.Clear();
            if (offerLstPrmSet != null) offerLstPrmSet.Clear();
            #endregion

            return status;
        }

        #region コンバート処理[提供→ユーザー]
        /// <summary>
        /// 提供車種名称データをユーザー車種名称データに変換する
        /// </summary>
        /// <param name="ofrPMakerNm">提供車種名称データ</param>
        /// <param name="usrPMakerNm">[出力]ユーザー車種名称データ</param>
        private bool ConvertPMakerNm(PMakerNmWork ofrPMakerNm, ref MakerUWork usrPMakerNm)
        {
            if (usrPMakerNm == null)
            {
                usrPMakerNm = new MakerUWork();

                usrPMakerNm.EnterpriseCode = _enterpriseCode;
                usrPMakerNm.GoodsMakerCd = ofrPMakerNm.PartsMakerCode; // 部品メーカーコード
            }
            else
            {
                if (usrPMakerNm.LogicalDeleteCode != 0)
                    return false;
            }
            usrPMakerNm.OfferDate = ConverIntToDateTime(ofrPMakerNm.OfferDate); // 提供日付
            usrPMakerNm.OfferDataDiv = 1; // 提供データ

            usrPMakerNm.MakerName = ofrPMakerNm.PartsMakerFullName; // 部品メーカー名称（全角）
            usrPMakerNm.MakerKanaName = ofrPMakerNm.PartsMakerHalfName; // 部品メーカー名称（半角）
            return true;
        }

        /// <summary>
        /// 提供車種名称データをユーザー車種名称データに変換する
        /// </summary>
        /// <param name="ofrModelName">提供車種名称データ</param>
        /// <param name="usrModelName">[出力]ユーザー車種名称データ</param>
        private bool ConvertModelName(ModelNameWork ofrModelName, ref ModelNameUWork usrModelName)
        {
            if (usrModelName == null)
            {
                usrModelName = new ModelNameUWork();

                usrModelName.EnterpriseCode = _enterpriseCode;
                usrModelName.ModelUniqueCode = ofrModelName.ModelUniqueCode; // 車種コード（ユニーク）
                usrModelName.MakerCode = ofrModelName.MakerCode; // メーカーコード
                usrModelName.ModelCode = ofrModelName.ModelCode; // 車種コード
                usrModelName.ModelSubCode = ofrModelName.ModelSubCode; // 車種サブコード
            }
            else
            {
                if (usrModelName.LogicalDeleteCode != 0)
                    return false;
            }
            usrModelName.OfferDate = ConverIntToDateTime(ofrModelName.OfferDate); // 提供日付
            usrModelName.OfferDataDiv = 1; // 提供データ

            usrModelName.ModelFullName = ofrModelName.ModelFullName; // 車種全角名称
            usrModelName.ModelHalfName = ofrModelName.ModelHalfName; // 車種半角名称
            usrModelName.ModelAliasName = ofrModelName.ModelAliasName; // 車種呼び名名称
            return true;
        }

        /// <summary>
        /// 提供商品中分類コードデータをユーザー商品中分類コードデータに変換する
        /// </summary>
        /// <param name="owFlg">上書きフラグ</param>
        /// <param name="ofrGoodsMGroup">提供商品中分類コードデータ</param>
        /// <param name="usrGoodsMGroup">[出力]ユーザー商品中分類コードデータ</param>
        private bool ConvertGoodsMGroup(bool owFlg, GoodsMGroupWork ofrGoodsMGroup, ref GoodsGroupUWork usrGoodsMGroup)
        {
            if (usrGoodsMGroup == null)
            {
                usrGoodsMGroup = new GoodsGroupUWork();

                usrGoodsMGroup.EnterpriseCode = _enterpriseCode;
                usrGoodsMGroup.OfferDataDiv = 1; // 提供データ
                usrGoodsMGroup.GoodsMGroup = ofrGoodsMGroup.GoodsMGroup; // 商品中分類コード

                usrGoodsMGroup.OfferDate = ConverIntToDateTime(ofrGoodsMGroup.OfferDate); // 提供日付
                usrGoodsMGroup.GoodsMGroupName = ofrGoodsMGroup.GoodsMGroupName; // 商品中分類名称
            }
            else
            {
                if (usrGoodsMGroup.LogicalDeleteCode != 0)
                    return false;
                if (owFlg)
                {
                    usrGoodsMGroup.OfferDate = ConverIntToDateTime(ofrGoodsMGroup.OfferDate); // 提供日付
                    usrGoodsMGroup.OfferDataDiv = 1; // 提供データ

                    usrGoodsMGroup.GoodsMGroupName = ofrGoodsMGroup.GoodsMGroupName; // 商品中分類名称
                }
            }
            return true;
        }

        /// <summary>
        /// 提供BLグループデータをユーザーBLグループデータに変換する
        /// </summary>
        /// <param name="owFlg">上書きフラグ</param>
        /// <param name="ofrBLGroup">提供BLグループデータ</param>
        /// <param name="usrBLGroup">[出力]ユーザーBLグループデータ</param>
        private bool ConvertBLGroup(bool owFlg, BLGroupWork ofrBLGroup, ref BLGroupUWork usrBLGroup)
        {
            if (usrBLGroup == null)
            {
                usrBLGroup = new BLGroupUWork();

                usrBLGroup.EnterpriseCode = _enterpriseCode;
                usrBLGroup.OfferDataDiv = 1; // 提供データ
                usrBLGroup.BLGroupCode = ofrBLGroup.BLGroupCode; // BLグループコード
                usrBLGroup.GoodsMGroup = ofrBLGroup.GoodsMGroup; // 商品中分類コード

                usrBLGroup.OfferDate = ConverIntToDateTime(ofrBLGroup.OfferDate); // 提供日付

                usrBLGroup.BLGroupName = ofrBLGroup.BLGroupName; // BLグループコード名称
                usrBLGroup.BLGroupKanaName = ofrBLGroup.BLGroupKanaName; // BLグループコード名称

            }
            else
            {
                if (usrBLGroup.LogicalDeleteCode != 0)
                    return false;
                if (owFlg)
                {
                    usrBLGroup.OfferDate = ConverIntToDateTime(ofrBLGroup.OfferDate); // 提供日付
                    usrBLGroup.OfferDataDiv = 1; // 提供データ

                    usrBLGroup.BLGroupName = ofrBLGroup.BLGroupName; // BLグループコード名称
                    usrBLGroup.BLGroupKanaName = ofrBLGroup.BLGroupKanaName; // BLグループコード名称
                }
            }

            return true;
        }

        /// <summary>
        /// 提供BLデータをユーザーBLデータに変換する
        /// </summary>
        /// <param name="owFlg">上書きフラグ</param>
        /// <param name="ofrBL">提供BLデータ</param>
        /// <param name="usrBL">[出力]ユーザーBLデータ</param>
        private bool ConvertBL(bool owFlg, TbsPartsCodeWork ofrBL, ref BLGoodsCdUWork usrBL)
        {
            if (usrBL == null)
            {
                usrBL = new BLGoodsCdUWork();

                usrBL.EnterpriseCode = _enterpriseCode;
                usrBL.OfferDataDiv = 1; // 提供データ
                usrBL.BLGoodsCode = ofrBL.TbsPartsCode; // BLコード
                usrBL.BLGoodsGenreCode = ofrBL.EquipGenre; // 装備分類
                usrBL.BLGroupCode = ofrBL.BLGroupCode; // BLグループコード
                usrBL.GoodsRateGrpCode = ofrBL.GoodsMGroup; // 商品中分類コード

                usrBL.OfferDate = ConverIntToDateTime(ofrBL.OfferDate); // 提供日付

                usrBL.BLGoodsFullName = ofrBL.TbsPartsFullName; // BLコード名称（全角）
                usrBL.BLGoodsHalfName = ofrBL.TbsPartsHalfName; // BLコード名称（半角）
            }
            else
            {
                if (usrBL.LogicalDeleteCode != 0)
                    return false;
                if (owFlg)
                {
                    usrBL.OfferDate = ConverIntToDateTime(ofrBL.OfferDate); // 提供日付
                    usrBL.OfferDataDiv = 1; // 提供データ

                    usrBL.BLGoodsFullName = ofrBL.TbsPartsFullName; // BLコード名称（全角）
                    usrBL.BLGoodsHalfName = ofrBL.TbsPartsHalfName; // BLコード名称（半角）
                }
            }

            return true;
        }

        /*/// <summary>
        /// 提供仕入先データをユーザー仕入先データに変換する
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="ofrSupplier">提供仕入先データ</param>
        /// <param name="usrSupplier">[出力]ユーザー仕入先データ</param>
        private bool ConvertSupplier(string enterpriseCode, OfrSupplierWork ofrSupplier, ref SupplierWork usrSupplier)
        {
            if (usrSupplier == null)
            {
                usrSupplier = new SupplierWork();

                usrSupplier.EnterpriseCode = enterpriseCode;
                usrSupplier.SupplierCd = ofrSupplier.SupplierCd; // 仕入先コード
                usrSupplier.SupplierNm1 = ofrSupplier.SupplierNm1; // 仕入先名
                usrSupplier.SupplierKana = ofrSupplier.SupplierKana; // 仕入先カナ
                usrSupplier.SupplierSnm = ofrSupplier.SupplierSnm; // 仕入先略称
            }
            else
            {
                if (usrSupplier.LogicalDeleteCode != 0)
                    return false;
                if (overwriteFlg)
                {
                    usrSupplier.SupplierNm1 = ofrSupplier.SupplierNm1; // 仕入先名
                    usrSupplier.SupplierKana = ofrSupplier.SupplierKana; // 仕入先カナ
                    usrSupplier.SupplierSnm = ofrSupplier.SupplierSnm; // 仕入先略称
                }
            }

            return true;
        }*/

        /// <summary>
        /// 提供 部位データをユーザー 部位データに変換する
        /// </summary>
        /// <param name="owFlg">上書きフラグ</param>
        /// <param name="partsPosCodeWork">提供 部位データ</param>
        /// <param name="usrPartsPos">[出力]ユーザー 部位データ</param>
        /// <param name="BigOfferDiv"></param>
        /// <param name="SearchType"></param>
        private bool ConvertPartsPos(bool owFlg, PartsPosCodeWork partsPosCodeWork, ref PartsPosCodeUWork usrPartsPos, int SearchType, int BigOfferDiv)
        {
            #region DELETE 1次分
            ///////<summary> 大型提供区分 契約状況</summary>
            //PurchaseStatus ps = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_BigCarOfferData);
            ///////<summary> 検索Bタイプ（外装） 契約状況 </summary>
            //PurchaseStatus ps2 = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_OutsideOfferData);
            ///////<summary> 検索タイプ（基本） 契約状況 </summary>
            //PurchaseStatus ps3 = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_BasicOfferData);
            //bool bigFlg = false; // 大型契約フラグ
            //bool exteriorFlg = false; // 外装契約フラグ
            //bool basicFlg = false; // 基本契約フラ
            //if (ps == PurchaseStatus.Contract || ps == PurchaseStatus.Trial_Contract) // 大型契約なしの場合マージしない
            //    bigFlg = true;
            //if (ps2 == PurchaseStatus.Contract || ps2 == PurchaseStatus.Trial_Contract) // 外装契約なしの場合マージしない
            //    exteriorFlg = true;
            //else if (ps3 == PurchaseStatus.Contract || ps3 == PurchaseStatus.Trial_Contract) // 基本契約なしの場合マージしない
            //    basicFlg = true;
            //if (usrPartsPos == null)
            //{
            //    if ((bigFlg && partsPosCodeWork.BigCarOfferDiv == 0)
            //        || (bigFlg == false && partsPosCodeWork.BigCarOfferDiv == 1))
            //        return false;
            //    if ((exteriorFlg && partsPosCodeWork.SearchPartsType != 20)
            //        || (basicFlg && partsPosCodeWork.SearchPartsType != 10))
            //        return false;
            //    //string key = string.Format("{0}{1}", partsPosCodeWork.SearchPartsPosCode, partsPosCodeWork.TbsPartsCode);
            //    //if (lstPartsPos.Contains(key))
            //    //    return false;
            //    //lstPartsPos.Add(key);

            //    usrPartsPos = new PartsPosCodeUWork();

            //    usrPartsPos.EnterpriseCode = _enterpriseCode;
            //    usrPartsPos.CustomerCode = 0; // 共通設定
            //    usrPartsPos.SearchPartsPosCode = partsPosCodeWork.SearchPartsPosCode; // 検索部位コード
            //    usrPartsPos.SearchPartsPosName = partsPosCodeWork.SearchPartsPosName; // 検索部位コード名称
            //    usrPartsPos.PosDispOrder = partsPosCodeWork.PosDispOrder; // 検索部位表示順位
            //    usrPartsPos.TbsPartsCode = partsPosCodeWork.TbsPartsCode; // BLコード
            //    usrPartsPos.TbsPartsCdDerivedNo = partsPosCodeWork.TbsPartsCdDerivedNo; // BLコード枝番
            //}
            //else
            //{
            //    if ((bigFlg && partsPosCodeWork.BigCarOfferDiv == 0)
            //        || (bigFlg == false && partsPosCodeWork.BigCarOfferDiv == 1))
            //        return false;
            //    if ((exteriorFlg && partsPosCodeWork.SearchPartsType != 20)
            //        || (basicFlg && partsPosCodeWork.SearchPartsType != 10))
            //        return false;
            //    if (usrPartsPos.LogicalDeleteCode != 0)
            //        return false;
            //    if (owFlg)
            //    {
            //        usrPartsPos.SearchPartsPosName = partsPosCodeWork.SearchPartsPosName; // 検索部位コード名称
            //    }
            //}
            #endregion

            if (partsPosCodeWork.BigCarOfferDiv == BigOfferDiv && partsPosCodeWork.SearchPartsType == SearchType)
            {
                if (usrPartsPos == null)
                {
                    usrPartsPos = new PartsPosCodeUWork();

                    usrPartsPos.EnterpriseCode = _enterpriseCode;
                    usrPartsPos.CustomerCode = 0; // 共通設定
                    usrPartsPos.SearchPartsPosCode = partsPosCodeWork.SearchPartsPosCode; // 検索部位コード
                    usrPartsPos.SearchPartsPosName = partsPosCodeWork.SearchPartsPosName; // 検索部位コード名称
                    usrPartsPos.PosDispOrder = partsPosCodeWork.PosDispOrder; // 検索部位表示順位
                    usrPartsPos.TbsPartsCode = partsPosCodeWork.TbsPartsCode; // BLコード
                    usrPartsPos.TbsPartsCdDerivedNo = partsPosCodeWork.TbsPartsCdDerivedNo; // BLコード枝番
                    usrPartsPos.OfferDate = ConverIntToDateTime(partsPosCodeWork.OfferDate); // 提供日付
                    usrPartsPos.OfferDataDiv = 1; // 提供
                }
                else
                {
                    usrPartsPos.SearchPartsPosName = partsPosCodeWork.SearchPartsPosName; // 検索部位コード名称
                    usrPartsPos.OfferDate = ConverIntToDateTime(partsPosCodeWork.OfferDate); // 提供日付
                    usrPartsPos.OfferDataDiv = 1; // 提供
                }

                partsPsDate = partsPosCodeWork.OfferDate;

            }
            else
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 日付変換処理(int -> DateTime)
        /// </summary>
        /// <param name="date">変換する日付データ(YYYYMMDD)</param>
        /// <returns></returns>
        private DateTime ConverIntToDateTime(int date)
        {
            if (date < 0)
                return DateTime.MinValue;
            int year = date / 10000;
            int month = ( date % 10000 ) / 100;
            int day = ( date % 10000 ) % 100;
            if (year == 0 || month == 0 || day == 0)
                return DateTime.MinValue;
            return new DateTime(year, month, day);
        }
        #endregion

        #endregion  // Private Methods
    }
}

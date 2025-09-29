//****************************************************************************//
// システム         : 卸商仕入受信処理
// プログラム名称   : 卸商仕入受信処理Model
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/11/17  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024  佐々木 健 
// 作 成 日  2009/10/09  修正内容 : 買掛オプション無しの場合、在庫切れを含むとエラーになる不具合の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024  佐々木 健 
// 作 成 日  2009/10/14  修正内容 : PMから発注して在庫切れの明細があった場合に
//                                  仕入明細が発注時の明細分できる不具合の修正(MANTIS[0014423]) 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024  佐々木 健 
// 作 成 日  2009/10/15  修正内容 : 従業員名称が16桁を超える場合にエラーになる不具合の修正(MANTIS[0014375]) 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024  佐々木 健 
// 作 成 日  2010/10/19  修正内容 : ①発注番号をまたがった同一仕入伝票の対応(MANTIS[0015563])
//                                 ②在庫調整データの作成について、出庫伝票番号＋倉庫単位で作成する(MANTIS[0016442])
//----------------------------------------------------------------------------//
// 管理番号  10802197-00 作成担当 : 30517 夏野 駿希
// 作 成 日  K2012/06/22 修正内容 : 山形部品個別対応
//                                  手入力発注の場合、仕入データを作成しない
//----------------------------------------------------------------------------//
// 管理番号  10802197-01 作成担当 : FSI佐々木 貴英
// 作 成 日  K2012/12/11 修正内容 : 山形部品個別対応
//                                  山形部品完全個別オプション判定追加
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 李占川
// 作 成 日  2013/05/08  修正内容 : 2013/06/18配信分 
//                                 ①Redmine#35459 エラー『処理に失敗しました。重複した仕入データが存在します。』を出力される
//                                 ②Redmine#35611 山形部品完全個別オプション判定追加(電話発注文の対応)
//----------------------------------------------------------------------------//
// 管理番号  11070100-00 作成担当 : 鄧潘ハン
// 作 成 日  2014/05/30  修正内容 : Redmine 42755 エラー「重複した仕入データが存在します」の対応
//----------------------------------------------------------------------------//
// 管理番号  11601223-00  作成担当 : 陳艶丹
// 作 成 日  K2021/09/22  修正内容 : PMKOBETSU-4189 ログ追加
//----------------------------------------------------------------------------//
// 管理番号  11800082-00  作成担当 : 陳艶丹
// 作 成 日  K2022/04/14  修正内容 : PMKOBETSU-4223 山形部品UOE送信処理時にエラーとなった場合仕入データが作成されない現象を修正
//----------------------------------------------------------------------------//
// 管理番号  11900025-00  作成担当 : 田村顕成
// 作 成 日  2023/01/20   修正内容 : PMKOBETSU-4202 卸商仕入受信処理障害対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using Broadleaf.Library.Collections;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting.ParamData;
// ADD K2012/12/11 START >>>>>>
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Controller;// ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応
// ADD K2012/12/11 END <<<<<<

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// UOE仕入データ（UOE発注データ + 発注情報 + 仕入情報）のヘルパクラス
    /// </summary>
    /// <remarks>※UOE仕入データは造語です。</remarks>
    public class UOEStockDataEssence
    {
        // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------>>>>>
        #region <ログ内容/>
        /// <summary>ログ内容</summary>
        private string _logMsg = string.Empty;
        /// <summary>
        /// ログ内容を取得します。
        /// </summary>
        /// <value>ログ内容</value>
        public string LogMsg { get { return _logMsg; } }
        #endregion  // <ログ内容/>
        // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------<<<<<
        // add K2012/06/22 >>>
        #region DB更新フラグ
        private bool _dbWriteFlg = false;

        /// <summary>DB更新フラグ</summary>
        public bool DBWriteFlg
        {
            get { return _dbWriteFlg; }
        }
        #endregion
        // add K2012/06/22 <<<

        // ADD K2012/12/11 START >>>>>>
        #region 山形部品完全個別オプション判定フラグ
        /// <summary>
        /// 山形部品完全個別オプション判定フラグ
        /// </summary>
        private PurchaseStatus _optionYamagataCustomControl = PurchaseStatus.Uncontract;
        #endregion 山形部品完全個別オプション判定
        // ADD K2012/12/11 END <<<<<<

        #region <検索されたUOE仕入データ/>

        /// <summary>検索されたUOE仕入データ</summary>
        private readonly CustomSerializeArrayList _searchedSlipGroupList;
        /// <summary>
        /// 検索されたUOE仕入データを取得します。
        /// </summary>
        private CustomSerializeArrayList SearchedSlipGroupList { get { return _searchedSlipGroupList; } }

        #endregion  // <検索されたUOE仕入データ/>

        #region <UOE発注データ/>

        /// <summary>検索されたUOE発注データのマップ</summary>
        /// <remarks>キー：UOE発注伝票番号("000000") + UOE発注行番号("00")</remarks>
        private readonly IDictionary<string, UOEOrderDtlWork> _searchedUOEOrderDetailRecordMap = new Dictionary<string, UOEOrderDtlWork>();
        /// <summary>
        /// 検索されたUOE発注データのマップを取得します。
        /// </summary>
        private IDictionary<string, UOEOrderDtlWork> SearchedUOEOrderDetailRecordMap
        {
            get { return _searchedUOEOrderDetailRecordMap; }
        }

        #region <キー/>

        /// <summary>
        /// UOE発注データのマップのキーを取得します。
        /// </summary>
        /// <param name="uoeOrderDetailRecord">UOE発注データのレコード</param>
        /// <returns>UOE発注番号("000000") + UOE発注行番号("00")</returns>
        /// <remarks>
        /// <br>Update Note: Redmine#35459の対応</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2013/05/08 </br>
        /// </remarks>
        private static string GetUOEOrderDertailKey(UOEOrderDtlWork uoeOrderDetailRecord)
        {
            // UPD 李占川 for Redmine#35459 2013/05/08  ---->>>>>>
            //return GetUOEOrderDertailKey(uoeOrderDetailRecord.UOESalesOrderNo, uoeOrderDetailRecord.UOESalesOrderRowNo);
            return GetUOEOrderDertailKey(uoeOrderDetailRecord.UOESalesOrderNo, uoeOrderDetailRecord.UOESalesOrderRowNo, uoeOrderDetailRecord.UOESectionSlipNo);
            // UPD 李占川 for Redmine#35459 2013/05/08  ----<<<<<<
        }

        /// <summary>
        /// UOE発注データのマップのキーを取得します。
        /// </summary>
        /// <param name="receivedTelegram">受信電文</param>
        /// <returns>電文問合せ番号("000000") + 回答電文対応行("00") + 出荷伝票番号("000000")</returns>
        /// <remarks>
        /// <br>Update Note: Redmine#35459の対応</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2013/05/08 </br>
        /// </remarks>
        private static string GetUOEOrderDertailKey(ReceivedText receivedTelegram)
        {
            int uoeSalesOrderNo     = int.Parse(receivedTelegram.UOESalesOrderNo);
            int uoeSalesOrderRowNo  = int.Parse(receivedTelegram.UOESalesOrderRowNo);

            // UPD 李占川 for Redmine#35459 2013/05/08  ---->>>>>>
            string uoeSectionSlipNo = receivedTelegram.UOESectionSlipNo;
            //return GetUOEOrderDertailKey(uoeSalesOrderNo, uoeSalesOrderRowNo);
            return GetUOEOrderDertailKey(uoeSalesOrderNo, uoeSalesOrderRowNo, uoeSectionSlipNo);
            // UPD 李占川 for Redmine#35459 2013/05/08  ----<<<<<<
        }

        // UPD 李占川 for Redmine#35459 2013/05/08    ------>>>>>>
        /// <summary>
        /// UOE発注データのマップのキーを取得します。
        /// </summary>
        /// <param name="uoeSalesOrderNo">UOE発注番号</param>
        /// <param name="uoeSalesOrderRowNo">UOE発注行番号</param>
        /// <param name="uoeSectionSlipNo">出荷伝票番号</param>
        /// <returns>UOE発注番号("000000") + UOE発注行番号("00")+ 出荷伝票番号("000000")</returns>
        //private static string GetUOEOrderDertailKey(
        //    int uoeSalesOrderNo,
        //    int uoeSalesOrderRowNo
        //)
        //{
        //    return uoeSalesOrderNo.ToString("000000") + uoeSalesOrderRowNo.ToString("00");
        //}
        private static string GetUOEOrderDertailKey(
            int uoeSalesOrderNo,
            int uoeSalesOrderRowNo,
            string uoeSectionSlipNo
        )
        {
            return uoeSalesOrderNo.ToString("000000") + uoeSalesOrderRowNo.ToString("00")
                + uoeSectionSlipNo.Trim().PadLeft(6, '0');
        }
        // UPD 李占川 for Redmine#35459 2013/05/08    ------<<<<<<

        #endregion  // <キー/>

        #region <電話発注分/>

        /// <summary>新たに登録するUOE発注データレコードのリスト</summary>
        /// <remarks>電話発注分を想定</remarks>
        private readonly IList<UOEOrderDtlWork> _insertingUOEOrderDetailRecordList = new List<UOEOrderDtlWork>();
        /// <summary>
        /// 新たに登録するUOE発注データレコードのリストを取得します。
        /// </summary>
        /// <remarks>電話発注分を想定</remarks>
        private IList<UOEOrderDtlWork> InsertingUOEOrderDetailRecordList
        {
            get { return _insertingUOEOrderDetailRecordList; }
        }

        /// <summary>
        /// UOE発注データのレコードを追加します。
        /// </summary>
        /// <param name="uoeOrderDtlWork">UOE発注データのレコード</param>
        /// <param name="pairReceivedText">対になる受信テキスト（受信電文）</param>
        /// <remarks>
        /// <br>Update Note: Redmine#35611の対応</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2013/05/08 </br>
        /// <br>Update Note: PMKOBETSU-4223 山形部品仕入データが作成されない対応</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : K2022/04/14</br>
        /// </remarks>
        public void AddUOEOrderDtlWork(
            UOEOrderDtlWork uoeOrderDtlWork,
            ReceivedText pairReceivedText
        )
        {
            InsertingUOEOrderDetailRecordList.Add(uoeOrderDtlWork);


            // ADD 李占川 for Redmine#356111 2013/05/08   ---->>>>>>
            // --- UPD K2022/04/14 陳艶丹 PMKOBETSU-4223の対応 --->>>>>
            //if (PurchaseStatus.Contract == _optionYamagataCustomControl)
            // 山形部品オプションあり、且つ電文問合せ番号= 0の時、UOE発注データを作成しない
            if (PurchaseStatus.Contract == _optionYamagataCustomControl && int.Parse(pairReceivedText.UOESalesOrderNo) == 0)
            // --- UPD K2022/04/14 陳艶丹 PMKOBETSU-4223の対応 ---<<<<<
            {
                string key = uoeOrderDtlWork.UOESalesOrderNo.ToString("000000")
                        + uoeOrderDtlWork.UOESalesOrderRowNo.ToString("00")
                        + uoeOrderDtlWork.UOESectionSlipNo.Trim().PadLeft(6, '0');
                if (!_noAddUoeOderList.Contains(key))
                {
                    _noAddUoeOderList.Add(key);
                }
            }
            // ADD 李占川 for Redmine#356111 2013/05/08   ----<<<<<<
        }

        #endregion  // <電話発注分/>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetUOEOrderDataCount()
        {
            return SearchedUOEOrderDetailRecordMap.Values.Count + InsertingUOEOrderDetailRecordList.Count;
        }

        #endregion  // <UOE発注データ/>

        #region <UOE発注データと仕入明細データのつなぎ/>

        /// <summary>UOE発注伝票番号+UOE発注番号 と 仕入明細通番 をつなぐマップ</summary>
        private readonly IDictionary<string, long> _chainKeyMap = new Dictionary<string, long>();
        /// <summary>
        /// UOE発注伝票番号+UOE発注番号 と 仕入明細通番 をつなぐマップを取得します。
        /// </summary>
        private IDictionary<string, long> ChainKeyMap
        {
            get { return _chainKeyMap; }
        }

        #endregion  // <UOE発注データと仕入明細データのつなぎ/>

        #region <UOE発注データと仕入データのつなぎ/>

        /// <summary>UOE発注伝票番号+UOE発注番号 と 仕入伝票番号 をつなぐマップ</summary>
        //private readonly IDictionary<string, int> _bridgeKeyMap = new Dictionary<string, int>();  // DEL 李占川 for Redmine#35459 2013/05/08
        private readonly IDictionary<string, long> _bridgeKeyMap = new Dictionary<string, long>();  // ADD 李占川 for Redmine#35459 2013/05/08
        /// <summary>
        /// UOE発注伝票番号+UOE発注番号 と 仕入伝票番号 をつなぐマップを取得します。
        /// </summary>
        //private IDictionary<string, int> BridgeKeyMap  // DEL 李占川 for Redmine#35459 2013/05/08
        private IDictionary<string, long> BridgeKeyMap   // ADD 李占川 for Redmine#35459 2013/05/08
        {
            get { return _bridgeKeyMap; }
        }

        #endregion  // <UOE発注データと仕入データのつなぎ/>

        // add K2012/06/22 >>>
        // 追加しない各データのリスト
        private List<string> _noAddUoeOderList = new List<string>();
        //private List<int> _noAddStockSlipList = new List<int>(); // DEL 李占川 for Redmine#35459 2013/05/08
        private List<long> _noAddStockSlipList = new List<long>(); // ADD 李占川 for Redmine#35459 2013/05/08
        private List<long> _noAddStockDetailList = new List<long>();
        private const string CtLogDataMassage = "要更新ﾃﾞｰﾀ:UOE発注ﾃﾞｰﾀ={0}件;仕入ﾃﾞｰﾀ={1}件;仕入明細ﾃﾞｰﾀ={2}件;在庫調整ﾃﾞｰﾀ={3}件;在庫調整明細ﾃﾞｰﾀ={4}件";// ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応
        // add K2012/06/22 <<<

        #region <発注情報の仕入明細データ/>

        /// <summary>検索された仕入明細データのマップ</summary>
        /// <remarks>キー：仕入明細通番</remarks>
        private readonly IDictionary<long, StockDetailWork> _searchedStockDetailRecordMap = new Dictionary<long, StockDetailWork>();
        /// <summary>
        /// 検索された仕入明細データのマップを取得します。
        /// </summary>
        private IDictionary<long, StockDetailWork> SearchedStockDetailRecordMap
        {
            get { return _searchedStockDetailRecordMap; }
        }

        #region <電話発注分/>

        /// <summary>新たに登録する発注情報の仕入明細データレコードのリスト</summary>
        /// <remarks>電話発注分を想定</remarks>
        private readonly IList<StockDetailWork> _insertingOrderStockDetailRecordList = new List<StockDetailWork>();
        /// <summary>
        /// 新たに登録する発注情報の仕入明細データレコードのリストを取得します。
        /// </summary>
        /// <remarks>電話発注分を想定</remarks>
        private IList<StockDetailWork> InsertingOrderStockDetailRecordList
        {
            get { return _insertingOrderStockDetailRecordList; }
        }

        /// <summary>電話発注分の仕入伝票番号（仮）のマップ</summary>
        /// <remarks>キー：受信電文の出荷伝票番号</remarks>
        //private readonly IDictionary<string, int> _telOrderSupplierSlipNoMap = new Dictionary<string, int>();  // DEL 李占川 for Redmine#35459 2013/05/08
        private readonly IDictionary<string, long> _telOrderSupplierSlipNoMap = new Dictionary<string, long>();  // ADD 李占川 for Redmine#35459 2013/05/08
        /// <summary>
        /// 電話発注分の仕入伝票番号（仮）のマップ
        /// </summary>
        /// <remarks>キー：受信電文の出荷伝票番号</remarks>
        //private IDictionary<string, int> TelOrderSupplierSlipNoMap  // DEL 李占川 for Redmine#35459 2013/05/08
        private IDictionary<string, long> TelOrderSupplierSlipNoMap   // ADD 李占川 for Redmine#35459 2013/05/08
        {
            get { return _telOrderSupplierSlipNoMap; }
        }

        /// <summary>電話発注分の仕入伝票番号（仮）のカウンタ</summary>
        /// <remarks>デクリメントされていきます。</remarks>
        private int _telOrderSupplierSlipNoCount = 0;
        /// <summary>
        /// 電話発注分の仕入伝票番号（仮）のカウンタ
        /// </summary>
        /// <remarks>デクリメントされていきます。</remarks>
        private int TelOrderSupplierSlipNoCount
        {
            get { return _telOrderSupplierSlipNoCount; }
            set { _telOrderSupplierSlipNoCount = value; }
        }

        #endregion  // <電話発注分/>

        /// <summary>伝票と明細リスト（電話発注分含む）のマップ</summary>
        //private readonly IDictionary<int, IList<StockDetailWork>> _stockSlipDetailRecordMap = new Dictionary<int, IList<StockDetailWork>>();  // DEL 李占川 for Redmine#35459 2013/05/08
        private readonly IDictionary<long, IList<StockDetailWork>> _stockSlipDetailRecordMap = new Dictionary<long, IList<StockDetailWork>>();  // ADD 李占川 for Redmine#35459 2013/05/08
        /// <summary>
        /// 伝票と明細リスト（電話発注分含む）のマップを取得します。
        /// </summary>
        //private IDictionary<int, IList<StockDetailWork>> StockSlipDetailRecordMap  // DEL 李占川 for Redmine#35459 2013/05/08
        private IDictionary<long, IList<StockDetailWork>> StockSlipDetailRecordMap   // ADD 李占川 for Redmine#35459 2013/05/08
        {
            get { return _stockSlipDetailRecordMap; }
        } 

        #endregion  // <発注情報の仕入明細データ/>

        // 2010/10/19 Add >>>
        #region <受信電文/>

        /// <summary>受信電文の集合体</summary>
        private readonly IAgreegate<ReceivedText> _receivedTelegramAgreegate;
        /// <summary>
        /// 受信電文の集合体を取得します。
        /// </summary>
        /// <value>受信電文の集合体</value>
        protected IAgreegate<ReceivedText> ReceivedTelegramAgreegate { get { return _receivedTelegramAgreegate; } }
        #endregion  // <受信電文/>
        // 2010/10/19 Add <<<

        /// <summary>
        /// 発注情報の仕入明細データを追加します。（電話発注分を想定）
        /// </summary>
        /// <param name="stockDetailWork">発注情報の仕入明細データのレコード</param>
        /// <param name="pairReceivedText">対になる受信テキスト（受信電文）</param>
        /// <remarks>
        /// <br>Update Note: Redmine#35459とRedmine#35611の対応</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2013/05/08 </br>
        /// <br>Update Note: PMKOBETSU-4223 山形部品仕入データが作成されない対応</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : K2022/04/14 </br>
        /// </remarks>
        public void AddStockDetailWork(
            StockDetailWork stockDetailWork,
            ReceivedText pairReceivedText
        )
        {
            InsertingOrderStockDetailRecordList.Add(stockDetailWork);

            // 仮の仕入伝票番号を設定
            string key = pairReceivedText.ToSlipNo();
            if (!TelOrderSupplierSlipNoMap.ContainsKey(key))
            {
                TelOrderSupplierSlipNoMap.Add(key, --TelOrderSupplierSlipNoCount);
            }
            //int telOrderSupplierSlipNo = TelOrderSupplierSlipNoMap[key];  // DEL 李占川 for Redmine#35459 2013/05/08
            long telOrderSupplierSlipNo = TelOrderSupplierSlipNoMap[key];   // ADD 李占川 for Redmine#35459 2013/05/08

            // 仕入明細データ
            if (!StockSlipDetailRecordMap.ContainsKey(telOrderSupplierSlipNo))
            {
                StockSlipDetailRecordMap.Add(telOrderSupplierSlipNo, new List<StockDetailWork>());
            }
            StockSlipDetailRecordMap[telOrderSupplierSlipNo].Add(stockDetailWork);

            // 仕入データ
            if (!StockSlipRecordMap.ContainsKey(telOrderSupplierSlipNo))
            {
                StockSlipRecordMap.Add(telOrderSupplierSlipNo, new StockSlipWork());
            }

            // ADD 李占川 for Redmine#35611 2013/05/08   ---->>>>>>
            // --- UPD K2022/04/14 陳艶丹 PMKOBETSU-4223の対応 --->>>>>
            //if (PurchaseStatus.Contract == _optionYamagataCustomControl)
            // 山形部品オプションあり、且つ電文問合せ番号= 0の時、仕入データ(発注)を作成しない
            if (PurchaseStatus.Contract == _optionYamagataCustomControl && int.Parse(pairReceivedText.UOESalesOrderNo) == 0)
            // --- UPD K2022/04/14 陳艶丹 PMKOBETSU-4223の対応 ---<<<<<
            {
                // 電話発注分時、仕入伝票番号と売上明細通番が「0」
                long key2 = 0;

                if (!_noAddStockSlipList.Contains(key2))
                    _noAddStockSlipList.Add(key2);
                if (!_noAddStockDetailList.Contains(key2))
                    _noAddStockDetailList.Add(key2);
            }
            // ADD 李占川 for Redmine#35611 2013/05/08   ----<<<<<<
        }

        #region <発注情報の仕入データ/>

        /// <summary>仕入データ（電話発注分含む）のマップ</summary>
        /// <remarks>キー：仕入伝票番号</remarks>
        //private readonly IDictionary<int, StockSlipWork> _stockSlipRecordMap = new Dictionary<int, StockSlipWork>();  // DEL 李占川 for Redmine#35459 2013/05/08
        private readonly IDictionary<long, StockSlipWork> _stockSlipRecordMap = new Dictionary<long, StockSlipWork>();  // ADD 李占川 for Redmine#35459 2013/05/08
        /// <summary>
        /// 仕入データ（電話発注分含む）のマップを取得します。
        /// </summary>
        //private IDictionary<int, StockSlipWork> StockSlipRecordMap // DEL 李占川 for Redmine#35459 2013/05/08
        private IDictionary<long, StockSlipWork> StockSlipRecordMap  // ADD 李占川 for Redmine#35459 2013/05/08
        {
            get { return _stockSlipRecordMap; }
        }

        #endregion  // <発注情報の仕入データ/>

        #region <計上情報の仕入系データ/>

        /// <summary>計上情報の仕入データのマップ</summary>
        private IDictionary<int, StockSlipWork> _sumUpStockSlipRecordMap;
        /// <summary>
        /// 
        /// </summary>
        public IDictionary<int, StockSlipWork> SumUpStockSlipRecordMap
        {
            get
            {
                if (_sumUpStockSlipRecordMap == null)
                {
                    _sumUpStockSlipRecordMap = new Dictionary<int, StockSlipWork>();
                }
                return _sumUpStockSlipRecordMap;
            }
        }

        /// <summary>計上情報の仕入明細データのマップ</summary>
        private IDictionary<int, IList<StockDetailWork>> _sumUpStockSlipDetailRecordMap;
        /// <summary>
        /// 
        /// </summary>
        public IDictionary<int, IList<StockDetailWork>> SumUpStockSlipDetailRecordMap
        {
            get
            {
                if (_sumUpStockSlipDetailRecordMap == null)
                {
                    _sumUpStockSlipDetailRecordMap = new Dictionary<int, IList<StockDetailWork>>();
                }
                return _sumUpStockSlipDetailRecordMap;
            }
        }

        /// <summary>
        /// 計上情報の仕入データ、仕入明細データを発注情報の仕入データ、仕入明細データで初期化します。
        /// </summary>
        /// <remarks>
        /// <br></br>
        /// <br>Update Note: 山形部品完全個別オプション判定追加</br>
        /// <br>Programmer : FSI佐々木 貴英</br>
        /// <br>Date       : K2012/12/11 </br>
        /// <br>Update Note: PMKOBETSU-4223 山形部品仕入データが作成されない対応</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : K2022/04/14 </br>
        /// </remarks>
        public void InitializeSumUpStockInformation()
        {
            SumUpStockSlipRecordMap.Clear();
            SumUpStockSlipDetailRecordMap.Clear();
            
            // 2010/10/19 >>>
#if False
            foreach (int supplierSlipNo in StockSlipDetailRecordMap.Keys)
            {
                // 計上情報の仕入データ
                StockSlipWork copySlip = StockSlipRecordMap[supplierSlipNo].Clone();
                SumUpStockSlipRecordMap.Add(supplierSlipNo, copySlip);

                // 計上情報の仕入明細データ
                SumUpStockSlipDetailRecordMap.Add(supplierSlipNo, new List<StockDetailWork>());
                foreach (StockDetailWork stockDetailWork in StockSlipDetailRecordMap[supplierSlipNo])
                {
                    StockDetailWork copyRecord = stockDetailWork.Clone();

                    SumUpStockSlipDetailRecordMap[supplierSlipNo].Add(copyRecord);
                }
            }
#endif

            int slipNo = 0;
            foreach (string uoeSlipNo in ReceivedTelegramAgreegate.GroupedListMap.Keys)
            {
                IList<ReceivedText> uoeSlip = ReceivedTelegramAgreegate.GroupedListMap[uoeSlipNo];
                StockSlipWork work = new StockSlipWork();
                // del K2012/06/22 >>>
                //work.PartySaleSlipNum = uoeSlipNo;
                //SumUpStockSlipRecordMap.Add(slipNo, work);
                // del K2012/06/22 <<<
                // ADD K2012/12/11 START >>>>>>
                // 山形部品完全個別オプションが無効の場合
                if (PurchaseStatus.Contract != _optionYamagataCustomControl)
                {
                    work.PartySaleSlipNum = uoeSlipNo;
                    SumUpStockSlipRecordMap.Add(slipNo, work);
                }
                // ADD K2012/12/11 END <<<<<<

                List<StockDetailWork> stockDetailWorkList = new List<StockDetailWork>();
                SumUpStockSlipDetailRecordMap.Add(slipNo, new List<StockDetailWork>());

                bool updFlg = true; // add K2012/06/22

                // ある出荷伝票番号における受信テキスト（明細）のループ
                foreach (ReceivedText receivedTelegram in uoeSlip)
                {
                    //SumUpStockSlipDetailRecordMap[slipNo].Add(FindStockDetailWork(receivedTelegram).Clone());   // del K2012/06/22
                    // ADD K2012/12/11 START >>>>>>
                    // --- UPD K2022/04/14 陳艶丹 PMKOBETSU-4223の対応 --->>>>>
                    //if (PurchaseStatus.Contract != _optionYamagataCustomControl)
                    // 山形部品完全個別オプションなし、あるいは電文問合せ番号≠ 0の時、仕入データを作成する
                    if (PurchaseStatus.Contract != _optionYamagataCustomControl || int.Parse(receivedTelegram.UOESalesOrderNo) != 0)
                    // --- UPD K2022/04/14 陳艶丹 PMKOBETSU-4223の対応 ---<<<<<
                    {
                        // 山形部品完全個別オプションが無効の場合
                        SumUpStockSlipDetailRecordMap[slipNo].Add(FindStockDetailWork(receivedTelegram).Clone());
                        continue;
                    }
                    // ADD K2012/12/11 END <<<<<<
                    // add K2012/06/22 >>>
                    StockDetailWork stockDetailWorkList2 = new StockDetailWork();
                    stockDetailWorkList2 = FindStockDetailWork2(receivedTelegram);
                    if (stockDetailWorkList2 == null)
                    {
                        stockDetailWorkList2 = new StockDetailWork();
                        updFlg = false;
                    }
                    SumUpStockSlipDetailRecordMap[slipNo].Add(stockDetailWorkList2.Clone());
                    // add K2012/06/22 <<<
                }
                // DEL K2012/12/11 START >>>>>>
                //// add K2012/06/22 >>>
                //if (updFlg)
                //    work.PartySaleSlipNum = uoeSlipNo;
                //SumUpStockSlipRecordMap.Add(slipNo, work);
                //// add K2012/06/22 <<<
                // DEL K2012/12/11 END <<<<<<
                // ADD K2012/12/11 START >>>>>>
                if (PurchaseStatus.Contract == _optionYamagataCustomControl)
                {
                    // 山形部品完全個別オプションが有効の場合
                    // DEL  by 李占川 for Redmine#35611 on 2013/05/08 --------->>>>>>>
                    //if (updFlg)
                    //    work.PartySaleSlipNum = uoeSlipNo;
                    // DEL  by 李占川 for Redmine#35611 on 2013/05/08 ---------<<<<<<<<

                    // ADD by 李占川 for Redmine#35611 on 2013/05/08 --------->>>>>>>
                    if (updFlg)
                    {
                        work.PartySaleSlipNum = uoeSlipNo;
                    }
                    else
                    {
                        work.PartySaleSlipNum = "FALSE" + uoeSlipNo;
                    }
                    // ADD by 李占川 for Redmine#35611 on 2013/05/08 ---------<<<<<<<<


                    SumUpStockSlipRecordMap.Add(slipNo, work);
                }
                // ADD K2012/12/11 END <<<<<<
                slipNo++;
            }
            // 2010/10/19 <<<
        }

        #endregion  // <計上情報の仕入系データ/>

        #region <計上情報の在庫系データ/>

        /// <summary>計上情報の在庫調整データのマップ</summary>
        private IDictionary<int, StockAdjustWork> _sumUpAdjustRecordMap;
        /// <summary>
        /// 
        /// </summary>
        public IDictionary<int, StockAdjustWork> SumUpAdjustRecordMap
        {
            get
            {
                if (_sumUpAdjustRecordMap == null)
                {
                    _sumUpAdjustRecordMap = new Dictionary<int, StockAdjustWork>();
                }
                return _sumUpAdjustRecordMap;
            }
        }

        /// <summary>計上情報の在庫調整明細データのマップ</summary>
        private IDictionary<int, IList<StockAdjustDtlWork>> _sumUpStockAdjustDetailRecordMap;
        /// <summary>
        /// 
        /// </summary>
        public IDictionary<int, IList<StockAdjustDtlWork>> SumUpStockAdjustDetailRecordMap
        {
            get
            {
                if (_sumUpStockAdjustDetailRecordMap == null)
                {
                    _sumUpStockAdjustDetailRecordMap = new Dictionary<int, IList<StockAdjustDtlWork>>();
                }
                return _sumUpStockAdjustDetailRecordMap;
            }
        }

        /// <summary>
        /// 計上情報の在庫調整データ、在庫調整明細データを発注情報の仕入データ、仕入明細データで初期化します。
        /// </summary>
        public void InitializeSumUpAdjustInformation()
        {
            SumUpAdjustRecordMap.Clear();
            SumUpStockAdjustDetailRecordMap.Clear();

            // 2010/10/19 ②対応 >>>
#if False
            foreach (int supplierSlipNo in StockSlipDetailRecordMap.Keys)
            {
                // 計上情報の在庫調整データ
                StockAdjustWork stockAdjustWork = CreateStockAdjustWork(StockSlipRecordMap[supplierSlipNo]);
                SumUpAdjustRecordMap.Add(supplierSlipNo, stockAdjustWork);

                // 計上情報の在庫調整明細データ
                IList<StockAdjustDtlWork> stockAdjustDtlWorkList = new List<StockAdjustDtlWork>();
                foreach (StockDetailWork stockDetailWork in StockSlipDetailRecordMap[supplierSlipNo])
                {
                    // 未処理条件
                    const int SLIP_START = 1;       // ①システム区分が 1:伝発
                    const int NONE_WAREHOUSE = 0;   // ②倉庫コードが 0
                    // 2009/10/09 Add >>>
                    // 受信したUOE発注データに含まれないデータは処理しない
                    if (FindUOEOrderDtlWork(stockDetailWork.DtlRelationGuid) == null) continue;
                    // 2009/10/09 Add <<<
                    if (
                        FindUOEOrderDtlWork(stockDetailWork.DtlRelationGuid).SystemDivCd.Equals(SLIP_START)
                            ||
                        string.IsNullOrEmpty(stockDetailWork.WarehouseCode.Trim())
                            ||
                        stockDetailWork.WarehouseCode.Equals(NONE_WAREHOUSE)
                    )
                    {
                        continue;
                    }
                    StockAdjustDtlWork stockAdjustDtlWork = CreateStockAdjustDtlWork(stockDetailWork);
                    stockAdjustDtlWorkList.Add(stockAdjustDtlWork);
                }

                if (stockAdjustDtlWorkList.Count > 0)
                {
                    SumUpStockAdjustDetailRecordMap.Add(supplierSlipNo, stockAdjustDtlWorkList);
                }
            }

#endif
            // 在庫調整明細データを、一旦まとめる為のリスト
            Dictionary<StockSlipWork, List<StockAdjustDtlWork>> tempList = new Dictionary<StockSlipWork, List<StockAdjustDtlWork>>();

            // 最初に、UOE出庫伝票番号単位で在庫調整明細データを生成する
            foreach (string uoeSlipNo in ReceivedTelegramAgreegate.GroupedListMap.Keys)
            {
                StockSlipWork stockSlipWork = null;
                IList<ReceivedText> uoeSlip = ReceivedTelegramAgreegate.GroupedListMap[uoeSlipNo];
                //tempList.Add(uoeSlipNo,new List<StockAdjustDtlWork>());
                // 出荷伝票番号における受信テキスト（明細）のループ
                foreach (ReceivedText receivedTelegram in uoeSlip)
                {
                    StockDetailWork stockDetailWork = FindStockDetailWork(receivedTelegram);

                    // 未処理条件
                    const int SLIP_START = 1;       // ①システム区分が 1:伝発
                    const int NONE_WAREHOUSE = 0;   // ②倉庫コードが 0
                    // 受信したUOE発注データに含まれないデータは処理しない
                    if (FindUOEOrderDtlWork(stockDetailWork.DtlRelationGuid) == null) continue;
                    if (
                        FindUOEOrderDtlWork(stockDetailWork.DtlRelationGuid).SystemDivCd.Equals(SLIP_START)
                            ||
                        string.IsNullOrEmpty(stockDetailWork.WarehouseCode.Trim())
                            ||
                        stockDetailWork.WarehouseCode.Equals(NONE_WAREHOUSE)
                    )
                    {
                        continue;
                    }
                    StockAdjustDtlWork stockAdjustDtlWork = CreateStockAdjustDtlWork(stockDetailWork);

                    if (stockSlipWork == null)
                    {
                        StockSlipWork work = FindStockSlipWork(receivedTelegram);
                        if (work == null)
                            stockSlipWork = new StockSlipWork();
                        else
                            stockSlipWork = work.Clone();

                        tempList.Add(stockSlipWork, new List<StockAdjustDtlWork>());
                    }

                    tempList[stockSlipWork].Add(stockAdjustDtlWork);
                }
            }

            int slipNo = 0;

            // 拠点出庫番号単位でまとめられた明細を、倉庫毎に分けてからデータ追加
            foreach (StockSlipWork stockslipWork in tempList.Keys)
            {
                List<StockAdjustDtlWork> list = tempList[stockslipWork];

                ArrayList workArray = DivisionStockAdjustData(list);
                if (workArray != null && workArray.Count > 0)
                {
                    foreach (List<StockAdjustDtlWork> oneBlock in workArray)
                    {
                        if (oneBlock.Count == 0) continue;

                        StockAdjustWork stockAdjustWork = CreateStockAdjustWork(stockslipWork);
                        SumUpAdjustRecordMap.Add(++slipNo, stockAdjustWork);

                        SumUpStockAdjustDetailRecordMap.Add(slipNo, oneBlock);
                    }
                }
            }
            // 2010/10/19 <<<
        }

        // 2010/10/19 Add >>>
        /// <summary>
        ///  在庫調整明細リストを倉庫順にソートして返します。
        /// </summary>
        /// <param name="stockAdjustDtlWorkList"></param>
        /// <returns></returns>
        private static ArrayList DivisionStockAdjustData(List<StockAdjustDtlWork> stockAdjustDtlWorkList)
        {
            if (stockAdjustDtlWorkList == null || stockAdjustDtlWorkList.Count == 0) return null;

            ArrayList retList = new ArrayList();
            SortedDictionary<string, List<StockAdjustDtlWork>> sortedList = new SortedDictionary<string, List<StockAdjustDtlWork>>();

            string warehouseCode;
            foreach (StockAdjustDtlWork stockAdjustDtlWork in stockAdjustDtlWorkList)
            {
                warehouseCode = stockAdjustDtlWork.WarehouseCode.Trim();
                if (!sortedList.ContainsKey(warehouseCode))
                {
                    sortedList.Add(warehouseCode, new List<StockAdjustDtlWork>());
                }
                sortedList[warehouseCode].Add(stockAdjustDtlWork);
            }

            foreach (List<StockAdjustDtlWork> tempList in sortedList.Values)
            {
                retList.Add(tempList);
            }

            return retList;
        }
        // 2010/10/19 Add <<<

        /// <summary>
        /// 仕入データから在庫調整データを生成します。
        /// </summary>
        /// <param name="stockSlipWork">仕入データ</param>
        /// <returns>在庫調整データ</returns>
        private static StockAdjustWork CreateStockAdjustWork(StockSlipWork stockSlipWork)
        {
            StockAdjustWork stockAdjustWork = new StockAdjustWork();
            {
                // 003.企業コード
                stockAdjustWork.EnterpriseCode = stockSlipWork.EnterpriseCode;
                // 009.拠点コード
                stockAdjustWork.SectionCode = stockSlipWork.SectionCode;

                // 014.受払元伝票区分
                stockAdjustWork.AcPaySlipCd = stockSlipWork.SupplierSlipCd;

                // 015.仕入拠点コード
                stockAdjustWork.StockSectionCd = stockSlipWork.StockSectionCd;
                // 016.仕入入力者コード
                stockAdjustWork.StockInputCode = stockSlipWork.StockInputCode;
                // 017.仕入入力者名称
                stockAdjustWork.StockInputName = stockSlipWork.StockInputName;
                // 018.仕入担当者コード
                stockAdjustWork.StockAgentCode = stockSlipWork.StockAgentCode;
                // 019.仕入担当者名称
                stockAdjustWork.StockAgentName = stockSlipWork.StockAgentName;
                // 020.仕入金額小計
                stockAdjustWork.StockSubttlPrice = stockSlipWork.StockSubttlPrice;
            }
            return stockAdjustWork;
        }

        /// <summary>
        /// 仕入明細データから在庫調整明細データを生成します。
        /// </summary>
        /// <param name="stockDetailWork">仕入明細データ</param>
        /// <returns>在庫調整明細データ</returns>
        private static StockAdjustDtlWork CreateStockAdjustDtlWork(StockDetailWork stockDetailWork)
        {
            StockAdjustDtlWork stockAdjustDtlWork = new StockAdjustDtlWork();
            {
                // 003.企業コード
                stockAdjustDtlWork.EnterpriseCode = stockDetailWork.EnterpriseCode;
                // 009.拠点コード
                stockAdjustDtlWork.SectionCode = stockDetailWork.SectionCode;
                // 012.仕入形式（元）
                stockAdjustDtlWork.SupplierFormalSrc = stockDetailWork.SupplierFormal;
                // 013.仕入明細通番（元）
                stockAdjustDtlWork.StockSlipDtlNumSrc = stockDetailWork.StockSlipDtlNum;
                // 014.受払元伝票区分：計上元の伝票区分
                stockAdjustDtlWork.AcPaySlipCd = stockDetailWork.StockSlipCdDtl;
                // 018.商品メーカーコード
                stockAdjustDtlWork.GoodsMakerCd = stockDetailWork.GoodsMakerCd;
                // 019.メーカー名称
                stockAdjustDtlWork.MakerName = stockDetailWork.MakerName;
                // 020.商品番号
                stockAdjustDtlWork.GoodsNo = stockDetailWork.GoodsNo;
                // 021.商品名称
                stockAdjustDtlWork.GoodsName = stockDetailWork.GoodsName;
                // 022.仕入単価（税抜, 浮動）
                stockAdjustDtlWork.StockUnitPriceFl = stockDetailWork.StockUnitPriceFl;
                // 023.変更前仕入単価（浮動）
                stockAdjustDtlWork.BfStockUnitPriceFl = stockDetailWork.BfStockUnitPriceFl;
                // 024.調整数
                stockAdjustDtlWork.AdjustCount = stockDetailWork.StockCount;
                // 026.倉庫コード
                stockAdjustDtlWork.WarehouseCode = stockDetailWork.WarehouseCode;
                // 027.倉庫名称
                stockAdjustDtlWork.WarehouseName = stockDetailWork.WarehouseName;
                // 028.BL商品コード
                stockAdjustDtlWork.BLGoodsCode = stockDetailWork.BLGoodsCode;
                // 029.BL商品コード名称（全角）
                stockAdjustDtlWork.BLGoodsFullName = stockDetailWork.BLGoodsFullName;
                // 030.倉庫棚番
                stockAdjustDtlWork.WarehouseShelfNo = stockDetailWork.WarehouseShelfNo;
                // 031.定価（浮動）
                stockAdjustDtlWork.ListPriceFl = stockDetailWork.ListPriceTaxExcFl;
            }
            return stockAdjustDtlWork;
        }

        #endregion  // <計上情報の在庫系データ/>

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="seachedSlipGroupList">検索されたUOE仕入データ</param>
        /// <param name="receivedTelegramAgreegate">受信電文</param>
        /// <remarks>
        /// <br></br>
        /// <br>Update Note: 山形部品完全個別オプション判定追加</br>
        /// <br>Programmer : FSI佐々木 貴英</br>
        /// <br>Date       : K2012/12/11 </br>
        /// <br>Update Note: Redmine#35459の対応</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2013/05/08 </br>
        /// </remarks>
        // 2010/10/19 >>>
        //public UOEStockDataEssence(CustomSerializeArrayList seachedSlipGroupList)
        public UOEStockDataEssence(CustomSerializeArrayList seachedSlipGroupList, IAgreegate<ReceivedText> receivedTelegramAgreegate)
        // 2010/10/19 <<<
        {
            _searchedSlipGroupList = seachedSlipGroupList;
            _receivedTelegramAgreegate = receivedTelegramAgreegate;     // 2010/10/19 Add

            //if (IsNullOrEmpty(seachedSlipGroupList)) return;   // DEL  by 李占川 for Redmine#35459 on 2013/05/08 

            // ADD K2012/12/11 START >>>>>>
            #region 山形部品完全個別オプション判定
            // 山形部品完全個別オプション判定
            _optionYamagataCustomControl = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(
                ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_YamagataCustomControl);
            #endregion 山形部品完全個別オプション判定
            // ADD K2012/12/11 END <<<<<<

            if (IsNullOrEmpty(seachedSlipGroupList)) return;   // ADD by 李占川 for Redmine#35459 on 2013/05/08

            // UOE発注データ
            #region <UOE発注データ/>

            ArrayList uoeOrderDtlWorkList = seachedSlipGroupList[0] as ArrayList;
            if (IsNullOrEmpty(uoeOrderDtlWorkList)) return;

            foreach (UOEOrderDtlWork uoeOrderDtlWork in uoeOrderDtlWorkList)
            {
                // modified by 李占川 for Redmine#35459 on 2013/05/08 begin
                //string key = GetUOEOrderDertailKey(uoeOrderDtlWork);
                string key = uoeOrderDtlWork.UOESalesOrderNo.ToString("000000") + uoeOrderDtlWork.UOESalesOrderRowNo.ToString("00");
                // modified by 李占川 for Redmine#35459 on 2013/05/08 end
                if (!SearchedUOEOrderDetailRecordMap.ContainsKey(key))
                {
                    SearchedUOEOrderDetailRecordMap.Add(key, uoeOrderDtlWork);
                }
                else
                {
                    Debug.Assert(false, "同じUOE発注データ？");
                }

                // UOE発注データと発注情報の仕入明細データをつなぐマップ
                if (!ChainKeyMap.ContainsKey(key))
                {
                    ChainKeyMap.Add(key, uoeOrderDtlWork.StockSlipDtlNum);
                }

                // UOE発注データと発注情報の仕入データをつなぐマップ
                if (!BridgeKeyMap.ContainsKey(key))
                {
                    BridgeKeyMap.Add(key, uoeOrderDtlWork.SupplierSlipNo);
                }

                // add K2012/06/22 >>>
                // DEL K2012/12/11 START >>>>>>
                //// 各データの追加しないリストを作成
                //if (uoeOrderDtlWork.SystemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Input)
                // DEL K2012/12/11 END <<<<<<

                // DEL  by 李占川 for Redmine#35611 on 2013/05/08 --------->>>>>>>
                // ADD K2012/12/11 START >>>>>>
                // 山形部品完全個別オプションが有効かつ手入力の場合、各データの追加しないリストを作成
                //if ((PurchaseStatus.Contract == _optionYamagataCustomControl) && (uoeOrderDtlWork.SystemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Input))
                //// ADD K2012/12/11 END <<<<<<
                //{
                //    if (!_noAddStockSlipList.Contains(uoeOrderDtlWork.SupplierSlipNo))
                //        _noAddStockSlipList.Add(uoeOrderDtlWork.SupplierSlipNo);
                //    if (!_noAddStockDetailList.Contains(uoeOrderDtlWork.StockSlipDtlNum))
                //        _noAddStockDetailList.Add(uoeOrderDtlWork.StockSlipDtlNum);
                //    if (!_noAddUoeOderList.Contains(key))
                //        _noAddUoeOderList.Add(key);
                //}
                //// add K2012/06/22 <<<
                // DEL  by 李占川 for Redmine#35611 on 2013/05/08 ---------<<<<<<<<
            }

            #endregion  // <UOE発注データ/>

            // 仕入データと仕入明細データ
            if (seachedSlipGroupList.Count <= 1) return;

            #region <仕入データと仕入明細データ/>

            for (int i = 1; i < seachedSlipGroupList.Count; i++)
            {
                if (i > 1) break;   // HACK:Search()結果の構造って？

                // 仕入データ
                CustomSerializeArrayList stockSlipList = seachedSlipGroupList[i] as CustomSerializeArrayList;
                if (stockSlipList == null)    continue;
                if (stockSlipList.Count <= 1) continue;

                int innerIndex = 0;
                while (innerIndex < stockSlipList.Count)
                {
                    //StockSlipWork stockSlipWork = stockSlipList[0] as StockSlipWork;
                    StockSlipWork stockSlipWork = stockSlipList[innerIndex++] as StockSlipWork;
                    if (stockSlipWork == null) continue;

                    //if (!SearchedStockSlipRecordMap.ContainsKey(stockSlipWork.SupplierSlipNo))
                    //{
                    StockSlipRecordMap.Add(stockSlipWork.SupplierSlipNo, stockSlipWork);
                    //}

                    // 伝票ごとにまとめるマップに伝票を追加
                    //if (!SearchedStockSlipDetailRecordMap.ContainsKey(stockSlipWork.SupplierSlipNo))
                    //{
                    StockSlipDetailRecordMap.Add(stockSlipWork.SupplierSlipNo, new List<StockDetailWork>());
                    //}

                    // 仕入明細データ
                    ArrayList stockDetailList = stockSlipList[innerIndex++] as ArrayList;
                    if (stockDetailList == null) continue;
                    if (stockDetailList.Count.Equals(0)) continue;

                    foreach (StockDetailWork stockDetailWork in stockDetailList)
                    {
                        //if (!SearchedStockDetailRecordMap.ContainsKey(stockDetailWork.StockSlipDtlNum))
                        //{
                        SearchedStockDetailRecordMap.Add(stockDetailWork.StockSlipDtlNum, stockDetailWork);

                        // 伝票ごとにまとめるマップに明細を追加
                        StockSlipDetailRecordMap[stockSlipWork.SupplierSlipNo].Add(stockDetailWork);
                        //}
                    }   // foreach (StockDetailWork stockDetailWork in stockDetailList)
                }   // while (innerIndex < stockSlipList.Count)
            }   // for (int i = 1; i < seachedSlipGroupList.Count; i++)

            #endregion  // <仕入データと仕入明細データ/>


            // ADD by 李占川 for Redmine#35459 on 2013/05/08 --------->>>>>>>
            # region 新キーより、各マップの再作成
            IDictionary<string, UOEOrderDtlWork> newSearchedUOEOrderDetailRecordMap = new Dictionary<string, UOEOrderDtlWork>();

            IDictionary<long, StockSlipWork> newStockSlipRecordMap = new Dictionary<long, StockSlipWork>();
            IDictionary<long, IList<StockDetailWork>> newStockSlipDetailRecordMap = new Dictionary<long, IList<StockDetailWork>>();
            IDictionary<long, StockDetailWork> newSearchedStockDetailRecordMap = new Dictionary<long, StockDetailWork>();

            ChainKeyMap.Clear();
            BridgeKeyMap.Clear();

            // 電文ループ
            IIterator<ReceivedText> receivedTextIterator = receivedTelegramAgreegate.CreateIterator();
            while (receivedTextIterator.HasNext())
            {
                ReceivedText receivedText = receivedTextIterator.GetNext();
                {
                    // 電文の出荷伝票番号
                    string uoeSectionSlipNo = receivedText.UOESectionSlipNo.Trim().PadLeft(6, '0');

                    // 修正前のＫｅｙ：電文問合せ番号　＋　回答電文対応行
                    string uoeOrderKey = receivedText.UOESalesOrderNo.Trim().PadLeft(6, '0') + receivedText.UOESalesOrderRowNo.Trim().PadLeft(2, '0');
                    // 修正前のＫｅｙ：電文問合せ番号　＋　回答電文対応行　＋出荷伝票番号
                    string newUoeOrderKey = uoeOrderKey + uoeSectionSlipNo;

                    // 新Ｋｅｙを使用して、新検索されたUOE発注データのマップを作成する
                    UOEOrderDtlWork uoeOrderDtlWorkTemp;
                    if (SearchedUOEOrderDetailRecordMap.TryGetValue(uoeOrderKey, out uoeOrderDtlWorkTemp))
                    {
                        UOEOrderDtlWork uoeOrderDtlWork = this.UOEOrderDtlWorkCopy(uoeOrderDtlWorkTemp);
                        newSearchedUOEOrderDetailRecordMap.Add(newUoeOrderKey, uoeOrderDtlWork);

                        // UOE発注データの仕入伝票番号
                        int supplierSlipNo = uoeOrderDtlWork.SupplierSlipNo;
                        // UOE発注データの仕入明細通番
                        long stockSlipDtlNum = uoeOrderDtlWork.StockSlipDtlNum;

                        // 新仕入伝票番号：UOE発注データの仕入伝票番号　＋　電文の出荷伝票番号
                        long newStockSlipDtlNum = long.Parse(stockSlipDtlNum.ToString() + uoeSectionSlipNo);
                        // 新仕入明細通番：UOE発注データの仕入明細通番　＋　電文の出荷伝票番号
                        long newSupplierSlipNo = long.Parse(supplierSlipNo.ToString() + uoeSectionSlipNo);

                        // UOE発注データと発注情報の仕入明細データをつなぐマップ
                        if (!ChainKeyMap.ContainsKey(newUoeOrderKey))
                        {
                            ChainKeyMap.Add(newUoeOrderKey, newStockSlipDtlNum);
                        }

                        // UOE発注データと発注情報の仕入データをつなぐマップ
                        if (!BridgeKeyMap.ContainsKey(newUoeOrderKey))
                        {
                            BridgeKeyMap.Add(newUoeOrderKey, newSupplierSlipNo);
                        }

                        // 新Ｋｅｙを使用して、新仕入データ（電話発注分含む）のマップを作成する
                        if (!newStockSlipRecordMap.ContainsKey(newSupplierSlipNo))
                        {
                            StockSlipWork stockSlipWorkTemp;
                            if (StockSlipRecordMap.TryGetValue(supplierSlipNo, out stockSlipWorkTemp))
                            {
                                StockSlipWork stockSlipWork = this.StockSlipWorkCopy(stockSlipWorkTemp);
                                newStockSlipRecordMap.Add(newSupplierSlipNo, stockSlipWork);
                            }
                            }

                        // 新Ｋｅｙを使用して、検索された仕入明細データのマップを作成する
                        if (!newSearchedStockDetailRecordMap.ContainsKey(newStockSlipDtlNum))
                        {
                            StockDetailWork stockDetailWorkTemp;
                            if (SearchedStockDetailRecordMap.TryGetValue(stockSlipDtlNum, out stockDetailWorkTemp))
                            {
                                StockDetailWork stockDetailWork = this.StockDetailWorkCopy(stockDetailWorkTemp);
                                newSearchedStockDetailRecordMap.Add(newStockSlipDtlNum, stockDetailWork);
                            }
                        }

                        // 新Ｋｅｙを使用して、伝票と明細リスト（電話発注分含む）のマップを作成する
                        if (!newStockSlipDetailRecordMap.ContainsKey(newSupplierSlipNo))
                        {
                            if (StockSlipDetailRecordMap.ContainsKey(supplierSlipNo))
                            {
                                List<StockDetailWork> stockDetailWorkList = new List<StockDetailWork>();
                                stockDetailWorkList.AddRange(StockSlipDetailRecordMap[supplierSlipNo]);
                                newStockSlipDetailRecordMap.Add(newSupplierSlipNo, stockDetailWorkList);
                            }
                        }

                        // ADD by 李占川 for Redmine#35611 on 2013/05/08 --------->>>>>>>
                        if ((PurchaseStatus.Contract == _optionYamagataCustomControl) && (uoeOrderDtlWork.SystemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Input))
                        {
                            if (!_noAddStockSlipList.Contains(newSupplierSlipNo))
                                _noAddStockSlipList.Add(newSupplierSlipNo);
                            if (!_noAddStockDetailList.Contains(newStockSlipDtlNum))
                                _noAddStockDetailList.Add(newStockSlipDtlNum);
                            if (!_noAddUoeOderList.Contains(newUoeOrderKey))
                                _noAddUoeOderList.Add(newUoeOrderKey);
                        }
                        // ADD by 李占川 for Redmine#35611 on 2013/05/08 ---------<<<<<<<<

                    }
                }
            }

            // 検索されたUOE発注データのマップを再作成
            SearchedUOEOrderDetailRecordMap.Clear();
            foreach (string uoeOrderKey in newSearchedUOEOrderDetailRecordMap.Keys)
            {
                SearchedUOEOrderDetailRecordMap.Add(uoeOrderKey, newSearchedUOEOrderDetailRecordMap[uoeOrderKey]);
            }

            // 仕入データ（電話発注分含む）のマップを再作成
            StockSlipRecordMap.Clear();
            foreach (long supplierSlipNo in newStockSlipRecordMap.Keys)
            {
                StockSlipRecordMap.Add(supplierSlipNo, newStockSlipRecordMap[supplierSlipNo]);
            }

            // 検索された仕入明細データのマップを再作成
            SearchedStockDetailRecordMap.Clear();
            foreach (long stockSlipDtlNum in newSearchedStockDetailRecordMap.Keys)
            {
                SearchedStockDetailRecordMap.Add(stockSlipDtlNum, newSearchedStockDetailRecordMap[stockSlipDtlNum]);
            }

            // 伝票と明細リスト（電話発注分含む）のマップを再作成
            StockSlipDetailRecordMap.Clear();
            foreach (long supplierSlipNo in newStockSlipDetailRecordMap.Keys)
            {
                StockSlipDetailRecordMap.Add(supplierSlipNo, newStockSlipDetailRecordMap[supplierSlipNo]);
            }
            # endregion
            // ADD by 李占川 for Redmine#35459 on 2013/05/08 ---------<<<<<<<
        }

        // ADD by 李占川 for Redmine#35459 on 2013/05/08 --------->>>>>>>
        /// <summary>
        /// UOE発注データをコピーする
        /// </summary>
        /// <param name="UOEOrderDtlWorkSrc">元UOE発注データ</param>
        /// <returns>新UOE発注データ</returns>
        /// <remarks>
        /// <br>Note       : UOE発注データをコピーする</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2013/05/08</br>
        /// </remarks>
        private UOEOrderDtlWork UOEOrderDtlWorkCopy(UOEOrderDtlWork UOEOrderDtlWorkSrc)
        {
            UOEOrderDtlWork UOEOrderDtlWorkRs = new UOEOrderDtlWork();

            UOEOrderDtlWorkRs.CreateDateTime = UOEOrderDtlWorkSrc.CreateDateTime;
            UOEOrderDtlWorkRs.UpdateDateTime = UOEOrderDtlWorkSrc.UpdateDateTime;
            UOEOrderDtlWorkRs.EnterpriseCode = UOEOrderDtlWorkSrc.EnterpriseCode;
            UOEOrderDtlWorkRs.FileHeaderGuid = UOEOrderDtlWorkSrc.FileHeaderGuid;
            UOEOrderDtlWorkRs.UpdEmployeeCode = UOEOrderDtlWorkSrc.UpdEmployeeCode;
            UOEOrderDtlWorkRs.UpdAssemblyId1 = UOEOrderDtlWorkSrc.UpdAssemblyId1;
            UOEOrderDtlWorkRs.UpdAssemblyId2 = UOEOrderDtlWorkSrc.UpdAssemblyId2;
            UOEOrderDtlWorkRs.LogicalDeleteCode = UOEOrderDtlWorkSrc.LogicalDeleteCode;
            UOEOrderDtlWorkRs.SystemDivCd = UOEOrderDtlWorkSrc.SystemDivCd;
            UOEOrderDtlWorkRs.UOESalesOrderNo = UOEOrderDtlWorkSrc.UOESalesOrderNo;
            UOEOrderDtlWorkRs.UOESalesOrderRowNo = UOEOrderDtlWorkSrc.UOESalesOrderRowNo;
            UOEOrderDtlWorkRs.SendTerminalNo = UOEOrderDtlWorkSrc.SendTerminalNo;
            UOEOrderDtlWorkRs.UOESupplierCd = UOEOrderDtlWorkSrc.UOESupplierCd;
            UOEOrderDtlWorkRs.UOESupplierName = UOEOrderDtlWorkSrc.UOESupplierName;
            UOEOrderDtlWorkRs.CommAssemblyId = UOEOrderDtlWorkSrc.CommAssemblyId;
            UOEOrderDtlWorkRs.OnlineNo = UOEOrderDtlWorkSrc.OnlineNo;
            UOEOrderDtlWorkRs.OnlineRowNo = UOEOrderDtlWorkSrc.OnlineRowNo;
            UOEOrderDtlWorkRs.SalesDate = UOEOrderDtlWorkSrc.SalesDate;
            UOEOrderDtlWorkRs.InputDay = UOEOrderDtlWorkSrc.InputDay;
            UOEOrderDtlWorkRs.DataUpdateDateTime = UOEOrderDtlWorkSrc.DataUpdateDateTime;
            UOEOrderDtlWorkRs.UOEKind = UOEOrderDtlWorkSrc.UOEKind;
            UOEOrderDtlWorkRs.SalesSlipNum = UOEOrderDtlWorkSrc.SalesSlipNum;
            UOEOrderDtlWorkRs.AcptAnOdrStatus = UOEOrderDtlWorkSrc.AcptAnOdrStatus;
            UOEOrderDtlWorkRs.SalesSlipDtlNum = UOEOrderDtlWorkSrc.SalesSlipDtlNum;
            UOEOrderDtlWorkRs.SectionCode = UOEOrderDtlWorkSrc.SectionCode;
            UOEOrderDtlWorkRs.SubSectionCode = UOEOrderDtlWorkSrc.SubSectionCode;
            UOEOrderDtlWorkRs.CustomerCode = UOEOrderDtlWorkSrc.CustomerCode;
            UOEOrderDtlWorkRs.CustomerSnm = UOEOrderDtlWorkSrc.CustomerSnm;
            UOEOrderDtlWorkRs.CashRegisterNo = UOEOrderDtlWorkSrc.CashRegisterNo;
            UOEOrderDtlWorkRs.CommonSeqNo = UOEOrderDtlWorkSrc.CommonSeqNo;
            UOEOrderDtlWorkRs.SupplierFormal = UOEOrderDtlWorkSrc.SupplierFormal;
            UOEOrderDtlWorkRs.SupplierSlipNo = UOEOrderDtlWorkSrc.SupplierSlipNo;
            UOEOrderDtlWorkRs.StockSlipDtlNum = UOEOrderDtlWorkSrc.StockSlipDtlNum;
            UOEOrderDtlWorkRs.BoCode = UOEOrderDtlWorkSrc.BoCode;
            UOEOrderDtlWorkRs.UOEDeliGoodsDiv = UOEOrderDtlWorkSrc.UOEDeliGoodsDiv;
            UOEOrderDtlWorkRs.DeliveredGoodsDivNm = UOEOrderDtlWorkSrc.DeliveredGoodsDivNm;
            UOEOrderDtlWorkRs.FollowDeliGoodsDiv = UOEOrderDtlWorkSrc.FollowDeliGoodsDiv;
            UOEOrderDtlWorkRs.FollowDeliGoodsDivNm = UOEOrderDtlWorkSrc.FollowDeliGoodsDivNm;
            UOEOrderDtlWorkRs.UOEResvdSection = UOEOrderDtlWorkSrc.UOEResvdSection;
            UOEOrderDtlWorkRs.UOEResvdSectionNm = UOEOrderDtlWorkSrc.UOEResvdSectionNm;
            UOEOrderDtlWorkRs.EmployeeCode = UOEOrderDtlWorkSrc.EmployeeCode;
            UOEOrderDtlWorkRs.EmployeeName = UOEOrderDtlWorkSrc.EmployeeName;
            UOEOrderDtlWorkRs.GoodsMakerCd = UOEOrderDtlWorkSrc.GoodsMakerCd;
            UOEOrderDtlWorkRs.MakerName = UOEOrderDtlWorkSrc.MakerName;
            UOEOrderDtlWorkRs.GoodsNo = UOEOrderDtlWorkSrc.GoodsNo;
            UOEOrderDtlWorkRs.GoodsNoNoneHyphen = UOEOrderDtlWorkSrc.GoodsNoNoneHyphen;
            UOEOrderDtlWorkRs.GoodsName = UOEOrderDtlWorkSrc.GoodsName;
            UOEOrderDtlWorkRs.WarehouseCode = UOEOrderDtlWorkSrc.WarehouseCode;
            UOEOrderDtlWorkRs.WarehouseName = UOEOrderDtlWorkSrc.WarehouseName;
            UOEOrderDtlWorkRs.WarehouseShelfNo = UOEOrderDtlWorkSrc.WarehouseShelfNo;
            UOEOrderDtlWorkRs.AcceptAnOrderCnt = UOEOrderDtlWorkSrc.AcceptAnOrderCnt;
            UOEOrderDtlWorkRs.ListPrice = UOEOrderDtlWorkSrc.ListPrice;
            UOEOrderDtlWorkRs.SalesUnitCost = UOEOrderDtlWorkSrc.SalesUnitCost;
            UOEOrderDtlWorkRs.SupplierCd = UOEOrderDtlWorkSrc.SupplierCd;
            UOEOrderDtlWorkRs.SupplierSnm = UOEOrderDtlWorkSrc.SupplierSnm;
            UOEOrderDtlWorkRs.UoeRemark1 = UOEOrderDtlWorkSrc.UoeRemark1;
            UOEOrderDtlWorkRs.UoeRemark2 = UOEOrderDtlWorkSrc.UoeRemark2;
            UOEOrderDtlWorkRs.ReceiveDate = UOEOrderDtlWorkSrc.ReceiveDate;
            UOEOrderDtlWorkRs.ReceiveTime = UOEOrderDtlWorkSrc.ReceiveTime;
            UOEOrderDtlWorkRs.AnswerMakerCd = UOEOrderDtlWorkSrc.AnswerMakerCd;
            UOEOrderDtlWorkRs.AnswerPartsNo = UOEOrderDtlWorkSrc.AnswerPartsNo;
            UOEOrderDtlWorkRs.AnswerPartsName = UOEOrderDtlWorkSrc.AnswerPartsName;
            UOEOrderDtlWorkRs.SubstPartsNo = UOEOrderDtlWorkSrc.SubstPartsNo;
            UOEOrderDtlWorkRs.UOESectOutGoodsCnt = UOEOrderDtlWorkSrc.UOESectOutGoodsCnt;
            UOEOrderDtlWorkRs.BOShipmentCnt1 = UOEOrderDtlWorkSrc.BOShipmentCnt1;
            UOEOrderDtlWorkRs.BOShipmentCnt2 = UOEOrderDtlWorkSrc.BOShipmentCnt2;
            UOEOrderDtlWorkRs.BOShipmentCnt3 = UOEOrderDtlWorkSrc.BOShipmentCnt3;
            UOEOrderDtlWorkRs.MakerFollowCnt = UOEOrderDtlWorkSrc.MakerFollowCnt;
            UOEOrderDtlWorkRs.NonShipmentCnt = UOEOrderDtlWorkSrc.NonShipmentCnt;
            UOEOrderDtlWorkRs.UOESectStockCnt = UOEOrderDtlWorkSrc.UOESectStockCnt;
            UOEOrderDtlWorkRs.BOStockCount1 = UOEOrderDtlWorkSrc.BOStockCount1;
            UOEOrderDtlWorkRs.BOStockCount2 = UOEOrderDtlWorkSrc.BOStockCount2;
            UOEOrderDtlWorkRs.BOStockCount3 = UOEOrderDtlWorkSrc.BOStockCount3;
            UOEOrderDtlWorkRs.UOESectionSlipNo = UOEOrderDtlWorkSrc.UOESectionSlipNo;
            UOEOrderDtlWorkRs.BOSlipNo1 = UOEOrderDtlWorkSrc.BOSlipNo1;
            UOEOrderDtlWorkRs.BOSlipNo2 = UOEOrderDtlWorkSrc.BOSlipNo2;
            UOEOrderDtlWorkRs.BOSlipNo3 = UOEOrderDtlWorkSrc.BOSlipNo3;
            UOEOrderDtlWorkRs.EOAlwcCount = UOEOrderDtlWorkSrc.EOAlwcCount;
            UOEOrderDtlWorkRs.BOManagementNo = UOEOrderDtlWorkSrc.BOManagementNo;
            UOEOrderDtlWorkRs.AnswerListPrice = UOEOrderDtlWorkSrc.AnswerListPrice;
            UOEOrderDtlWorkRs.AnswerSalesUnitCost = UOEOrderDtlWorkSrc.AnswerSalesUnitCost;
            UOEOrderDtlWorkRs.UOESubstMark = UOEOrderDtlWorkSrc.UOESubstMark;
            UOEOrderDtlWorkRs.UOEStockMark = UOEOrderDtlWorkSrc.UOEStockMark;
            UOEOrderDtlWorkRs.PartsLayerCd = UOEOrderDtlWorkSrc.PartsLayerCd;
            UOEOrderDtlWorkRs.MazdaUOEShipSectCd1 = UOEOrderDtlWorkSrc.MazdaUOEShipSectCd1;
            UOEOrderDtlWorkRs.MazdaUOEShipSectCd2 = UOEOrderDtlWorkSrc.MazdaUOEShipSectCd2;
            UOEOrderDtlWorkRs.MazdaUOEShipSectCd3 = UOEOrderDtlWorkSrc.MazdaUOEShipSectCd3;
            UOEOrderDtlWorkRs.MazdaUOESectCd1 = UOEOrderDtlWorkSrc.MazdaUOESectCd1;
            UOEOrderDtlWorkRs.MazdaUOESectCd2 = UOEOrderDtlWorkSrc.MazdaUOESectCd2;
            UOEOrderDtlWorkRs.MazdaUOESectCd3 = UOEOrderDtlWorkSrc.MazdaUOESectCd3;
            UOEOrderDtlWorkRs.MazdaUOESectCd4 = UOEOrderDtlWorkSrc.MazdaUOESectCd4;
            UOEOrderDtlWorkRs.MazdaUOESectCd5 = UOEOrderDtlWorkSrc.MazdaUOESectCd5;
            UOEOrderDtlWorkRs.MazdaUOESectCd6 = UOEOrderDtlWorkSrc.MazdaUOESectCd6;
            UOEOrderDtlWorkRs.MazdaUOESectCd7 = UOEOrderDtlWorkSrc.MazdaUOESectCd7;
            UOEOrderDtlWorkRs.MazdaUOEStockCnt1 = UOEOrderDtlWorkSrc.MazdaUOEStockCnt1;
            UOEOrderDtlWorkRs.MazdaUOEStockCnt2 = UOEOrderDtlWorkSrc.MazdaUOEStockCnt2;
            UOEOrderDtlWorkRs.MazdaUOEStockCnt3 = UOEOrderDtlWorkSrc.MazdaUOEStockCnt3;
            UOEOrderDtlWorkRs.MazdaUOEStockCnt4 = UOEOrderDtlWorkSrc.MazdaUOEStockCnt4;
            UOEOrderDtlWorkRs.MazdaUOEStockCnt5 = UOEOrderDtlWorkSrc.MazdaUOEStockCnt5;
            UOEOrderDtlWorkRs.MazdaUOEStockCnt6 = UOEOrderDtlWorkSrc.MazdaUOEStockCnt6;
            UOEOrderDtlWorkRs.MazdaUOEStockCnt7 = UOEOrderDtlWorkSrc.MazdaUOEStockCnt7;
            UOEOrderDtlWorkRs.UOEDistributionCd = UOEOrderDtlWorkSrc.UOEDistributionCd;
            UOEOrderDtlWorkRs.UOEOtherCd = UOEOrderDtlWorkSrc.UOEOtherCd;
            UOEOrderDtlWorkRs.UOEHMCd = UOEOrderDtlWorkSrc.UOEHMCd;
            UOEOrderDtlWorkRs.BOCount = UOEOrderDtlWorkSrc.BOCount;
            UOEOrderDtlWorkRs.UOEMarkCode = UOEOrderDtlWorkSrc.UOEMarkCode;
            UOEOrderDtlWorkRs.SourceShipment = UOEOrderDtlWorkSrc.SourceShipment;
            UOEOrderDtlWorkRs.ItemCode = UOEOrderDtlWorkSrc.ItemCode;
            UOEOrderDtlWorkRs.UOECheckCode = UOEOrderDtlWorkSrc.UOECheckCode;
            UOEOrderDtlWorkRs.HeadErrorMassage = UOEOrderDtlWorkSrc.HeadErrorMassage;
            UOEOrderDtlWorkRs.LineErrorMassage = UOEOrderDtlWorkSrc.LineErrorMassage;
            UOEOrderDtlWorkRs.DataSendCode = UOEOrderDtlWorkSrc.DataSendCode;
            UOEOrderDtlWorkRs.DataRecoverDiv = UOEOrderDtlWorkSrc.DataRecoverDiv;
            UOEOrderDtlWorkRs.EnterUpdDivSec = UOEOrderDtlWorkSrc.EnterUpdDivSec;
            UOEOrderDtlWorkRs.EnterUpdDivBO1 = UOEOrderDtlWorkSrc.EnterUpdDivBO1;
            UOEOrderDtlWorkRs.EnterUpdDivBO2 = UOEOrderDtlWorkSrc.EnterUpdDivBO2;
            UOEOrderDtlWorkRs.EnterUpdDivBO3 = UOEOrderDtlWorkSrc.EnterUpdDivBO3;
            UOEOrderDtlWorkRs.EnterUpdDivMaker = UOEOrderDtlWorkSrc.EnterUpdDivMaker;
            UOEOrderDtlWorkRs.EnterUpdDivEO = UOEOrderDtlWorkSrc.EnterUpdDivEO;

            UOEOrderDtlWorkRs.DtlRelationGuid = UOEOrderDtlWorkSrc.DtlRelationGuid;

            return UOEOrderDtlWorkRs;
        }

        /// <summary>
        /// 仕入データをコピーする
        /// </summary>
        /// <param name="StockSlipWorkSrc">元仕入データ</param>
        /// <returns>新仕入データ</returns>
        /// <remarks>
        /// <br>Note       : 仕入データをコピーする</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2013/05/08</br>
        /// </remarks>
        private StockSlipWork StockSlipWorkCopy(StockSlipWork StockSlipWorkSrc)
        {
            StockSlipWork StockSlipWorkRs = new StockSlipWork();

            StockSlipWorkRs.CreateDateTime = StockSlipWorkSrc.CreateDateTime;
            StockSlipWorkRs.UpdateDateTime = StockSlipWorkSrc.UpdateDateTime;
            StockSlipWorkRs.EnterpriseCode = StockSlipWorkSrc.EnterpriseCode;
            StockSlipWorkRs.FileHeaderGuid = StockSlipWorkSrc.FileHeaderGuid;
            StockSlipWorkRs.UpdEmployeeCode = StockSlipWorkSrc.UpdEmployeeCode;
            StockSlipWorkRs.UpdAssemblyId1 = StockSlipWorkSrc.UpdAssemblyId1;
            StockSlipWorkRs.UpdAssemblyId2 = StockSlipWorkSrc.UpdAssemblyId2;
            StockSlipWorkRs.LogicalDeleteCode = StockSlipWorkSrc.LogicalDeleteCode;
            StockSlipWorkRs.SupplierFormal = StockSlipWorkSrc.SupplierFormal;
            StockSlipWorkRs.SupplierSlipNo = StockSlipWorkSrc.SupplierSlipNo;
            StockSlipWorkRs.SectionCode = StockSlipWorkSrc.SectionCode;
            StockSlipWorkRs.SubSectionCode = StockSlipWorkSrc.SubSectionCode;
            StockSlipWorkRs.DebitNoteDiv = StockSlipWorkSrc.DebitNoteDiv;
            StockSlipWorkRs.DebitNLnkSuppSlipNo = StockSlipWorkSrc.DebitNLnkSuppSlipNo;
            StockSlipWorkRs.SupplierSlipCd = StockSlipWorkSrc.SupplierSlipCd;
            StockSlipWorkRs.StockGoodsCd = StockSlipWorkSrc.StockGoodsCd;
            StockSlipWorkRs.AccPayDivCd = StockSlipWorkSrc.AccPayDivCd;
            StockSlipWorkRs.StockSectionCd = StockSlipWorkSrc.StockSectionCd;
            StockSlipWorkRs.StockAddUpSectionCd = StockSlipWorkSrc.StockAddUpSectionCd;
            StockSlipWorkRs.StockSlipUpdateCd = StockSlipWorkSrc.StockSlipUpdateCd;
            StockSlipWorkRs.InputDay = StockSlipWorkSrc.InputDay;
            StockSlipWorkRs.ArrivalGoodsDay = StockSlipWorkSrc.ArrivalGoodsDay;
            StockSlipWorkRs.StockDate = StockSlipWorkSrc.StockDate;
            StockSlipWorkRs.StockAddUpADate = StockSlipWorkSrc.StockAddUpADate;
            StockSlipWorkRs.DelayPaymentDiv = StockSlipWorkSrc.DelayPaymentDiv;
            StockSlipWorkRs.PayeeCode = StockSlipWorkSrc.PayeeCode;
            StockSlipWorkRs.PayeeSnm = StockSlipWorkSrc.PayeeSnm;
            StockSlipWorkRs.SupplierCd = StockSlipWorkSrc.SupplierCd;
            StockSlipWorkRs.SupplierNm1 = StockSlipWorkSrc.SupplierNm1;
            StockSlipWorkRs.SupplierNm2 = StockSlipWorkSrc.SupplierNm2;
            StockSlipWorkRs.SupplierSnm = StockSlipWorkSrc.SupplierSnm;
            StockSlipWorkRs.BusinessTypeCode = StockSlipWorkSrc.BusinessTypeCode;
            StockSlipWorkRs.BusinessTypeName = StockSlipWorkSrc.BusinessTypeName;
            StockSlipWorkRs.SalesAreaCode = StockSlipWorkSrc.SalesAreaCode;
            StockSlipWorkRs.SalesAreaName = StockSlipWorkSrc.SalesAreaName;
            StockSlipWorkRs.StockInputCode = StockSlipWorkSrc.StockInputCode;
            StockSlipWorkRs.StockInputName = StockSlipWorkSrc.StockInputName;
            StockSlipWorkRs.StockAgentCode = StockSlipWorkSrc.StockAgentCode;
            StockSlipWorkRs.StockAgentName = StockSlipWorkSrc.StockAgentName;
            StockSlipWorkRs.SuppTtlAmntDspWayCd = StockSlipWorkSrc.SuppTtlAmntDspWayCd;
            StockSlipWorkRs.TtlAmntDispRateApy = StockSlipWorkSrc.TtlAmntDispRateApy;
            StockSlipWorkRs.StockTotalPrice = StockSlipWorkSrc.StockTotalPrice;
            StockSlipWorkRs.StockSubttlPrice = StockSlipWorkSrc.StockSubttlPrice;
            StockSlipWorkRs.StockTtlPricTaxInc = StockSlipWorkSrc.StockTtlPricTaxInc;
            StockSlipWorkRs.StockTtlPricTaxExc = StockSlipWorkSrc.StockTtlPricTaxExc;
            StockSlipWorkRs.StockNetPrice = StockSlipWorkSrc.StockNetPrice;
            StockSlipWorkRs.StockPriceConsTax = StockSlipWorkSrc.StockPriceConsTax;
            StockSlipWorkRs.TtlItdedStcOutTax = StockSlipWorkSrc.TtlItdedStcOutTax;
            StockSlipWorkRs.TtlItdedStcInTax = StockSlipWorkSrc.TtlItdedStcInTax;
            StockSlipWorkRs.TtlItdedStcTaxFree = StockSlipWorkSrc.TtlItdedStcTaxFree;
            StockSlipWorkRs.StockOutTax = StockSlipWorkSrc.StockOutTax;
            StockSlipWorkRs.StckPrcConsTaxInclu = StockSlipWorkSrc.StckPrcConsTaxInclu;
            StockSlipWorkRs.StckDisTtlTaxExc = StockSlipWorkSrc.StckDisTtlTaxExc;
            StockSlipWorkRs.ItdedStockDisOutTax = StockSlipWorkSrc.ItdedStockDisOutTax;
            StockSlipWorkRs.ItdedStockDisInTax = StockSlipWorkSrc.ItdedStockDisInTax;
            StockSlipWorkRs.ItdedStockDisTaxFre = StockSlipWorkSrc.ItdedStockDisTaxFre;
            StockSlipWorkRs.StockDisOutTax = StockSlipWorkSrc.StockDisOutTax;
            StockSlipWorkRs.StckDisTtlTaxInclu = StockSlipWorkSrc.StckDisTtlTaxInclu;
            StockSlipWorkRs.TaxAdjust = StockSlipWorkSrc.TaxAdjust;
            StockSlipWorkRs.BalanceAdjust = StockSlipWorkSrc.BalanceAdjust;
            StockSlipWorkRs.SuppCTaxLayCd = StockSlipWorkSrc.SuppCTaxLayCd;
            StockSlipWorkRs.SupplierConsTaxRate = StockSlipWorkSrc.SupplierConsTaxRate;
            StockSlipWorkRs.AccPayConsTax = StockSlipWorkSrc.AccPayConsTax;
            StockSlipWorkRs.StockFractionProcCd = StockSlipWorkSrc.StockFractionProcCd;
            StockSlipWorkRs.AutoPayment = StockSlipWorkSrc.AutoPayment;
            StockSlipWorkRs.AutoPaySlipNum = StockSlipWorkSrc.AutoPaySlipNum;
            StockSlipWorkRs.RetGoodsReasonDiv = StockSlipWorkSrc.RetGoodsReasonDiv;
            StockSlipWorkRs.RetGoodsReason = StockSlipWorkSrc.RetGoodsReason;
            StockSlipWorkRs.PartySaleSlipNum = StockSlipWorkSrc.PartySaleSlipNum;
            StockSlipWorkRs.SupplierSlipNote1 = StockSlipWorkSrc.SupplierSlipNote1;
            StockSlipWorkRs.SupplierSlipNote2 = StockSlipWorkSrc.SupplierSlipNote2;
            StockSlipWorkRs.DetailRowCount = StockSlipWorkSrc.DetailRowCount;
            StockSlipWorkRs.EdiSendDate = StockSlipWorkSrc.EdiSendDate;
            StockSlipWorkRs.EdiTakeInDate = StockSlipWorkSrc.EdiTakeInDate;
            StockSlipWorkRs.UoeRemark1 = StockSlipWorkSrc.UoeRemark1;
            StockSlipWorkRs.UoeRemark2 = StockSlipWorkSrc.UoeRemark2;
            StockSlipWorkRs.SlipPrintDivCd = StockSlipWorkSrc.SlipPrintDivCd;
            StockSlipWorkRs.SlipPrintFinishCd = StockSlipWorkSrc.SlipPrintFinishCd;
            StockSlipWorkRs.StockSlipPrintDate = StockSlipWorkSrc.StockSlipPrintDate;
            StockSlipWorkRs.SlipPrtSetPaperId = StockSlipWorkSrc.SlipPrtSetPaperId;
            StockSlipWorkRs.SlipAddressDiv = StockSlipWorkSrc.SlipAddressDiv;
            StockSlipWorkRs.AddresseeCode = StockSlipWorkSrc.AddresseeCode;
            StockSlipWorkRs.AddresseeName = StockSlipWorkSrc.AddresseeName;
            StockSlipWorkRs.AddresseeName2 = StockSlipWorkSrc.AddresseeName2;
            StockSlipWorkRs.AddresseePostNo = StockSlipWorkSrc.AddresseePostNo;
            StockSlipWorkRs.AddresseeAddr1 = StockSlipWorkSrc.AddresseeAddr1;
            StockSlipWorkRs.AddresseeAddr3 = StockSlipWorkSrc.AddresseeAddr3;
            StockSlipWorkRs.AddresseeAddr4 = StockSlipWorkSrc.AddresseeAddr4;
            StockSlipWorkRs.AddresseeTelNo = StockSlipWorkSrc.AddresseeTelNo;
            StockSlipWorkRs.AddresseeFaxNo = StockSlipWorkSrc.AddresseeFaxNo;
            StockSlipWorkRs.DirectSendingCd = StockSlipWorkSrc.DirectSendingCd;

            return StockSlipWorkRs;
        }

        /// <summary>
        /// 仕入明細データをコピーする
        /// </summary>
        /// <param name="StockDetailWorkSrc">元仕入明細データ</param>
        /// <returns>新仕入明細データ</returns>
        /// <remarks>
        /// <br>Note       : 仕入明細データをコピーする</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2013/05/08</br>
        /// </remarks>
        private StockDetailWork StockDetailWorkCopy(StockDetailWork StockDetailWorkSrc)
        {
            StockDetailWork StockDetailWorkRs = new StockDetailWork();

            StockDetailWorkRs.CreateDateTime = StockDetailWorkSrc.CreateDateTime;
            StockDetailWorkRs.UpdateDateTime = StockDetailWorkSrc.UpdateDateTime;
            StockDetailWorkRs.EnterpriseCode = StockDetailWorkSrc.EnterpriseCode;
            StockDetailWorkRs.FileHeaderGuid = StockDetailWorkSrc.FileHeaderGuid;
            StockDetailWorkRs.UpdEmployeeCode = StockDetailWorkSrc.UpdEmployeeCode;
            StockDetailWorkRs.UpdAssemblyId1 = StockDetailWorkSrc.UpdAssemblyId1;
            StockDetailWorkRs.UpdAssemblyId2 = StockDetailWorkSrc.UpdAssemblyId2;
            StockDetailWorkRs.LogicalDeleteCode = StockDetailWorkSrc.LogicalDeleteCode;
            StockDetailWorkRs.AcceptAnOrderNo = StockDetailWorkSrc.AcceptAnOrderNo;
            StockDetailWorkRs.SupplierFormal = StockDetailWorkSrc.SupplierFormal;
            StockDetailWorkRs.SupplierSlipNo = StockDetailWorkSrc.SupplierSlipNo;
            StockDetailWorkRs.StockRowNo = StockDetailWorkSrc.StockRowNo;
            StockDetailWorkRs.SectionCode = StockDetailWorkSrc.SectionCode;
            StockDetailWorkRs.SubSectionCode = StockDetailWorkSrc.SubSectionCode;
            StockDetailWorkRs.CommonSeqNo = StockDetailWorkSrc.CommonSeqNo;
            StockDetailWorkRs.StockSlipDtlNum = StockDetailWorkSrc.StockSlipDtlNum;
            StockDetailWorkRs.SupplierFormalSrc = StockDetailWorkSrc.SupplierFormalSrc;
            StockDetailWorkRs.StockSlipDtlNumSrc = StockDetailWorkSrc.StockSlipDtlNumSrc;
            StockDetailWorkRs.AcptAnOdrStatusSync = StockDetailWorkSrc.AcptAnOdrStatusSync;
            StockDetailWorkRs.SalesSlipDtlNumSync = StockDetailWorkSrc.SalesSlipDtlNumSync;
            StockDetailWorkRs.StockSlipCdDtl = StockDetailWorkSrc.StockSlipCdDtl;
            StockDetailWorkRs.StockInputCode = StockDetailWorkSrc.StockInputCode;
            StockDetailWorkRs.StockInputName = StockDetailWorkSrc.StockInputName;
            StockDetailWorkRs.StockAgentCode = StockDetailWorkSrc.StockAgentCode;
            StockDetailWorkRs.StockAgentName = StockDetailWorkSrc.StockAgentName;
            StockDetailWorkRs.GoodsKindCode = StockDetailWorkSrc.GoodsKindCode;
            StockDetailWorkRs.GoodsMakerCd = StockDetailWorkSrc.GoodsMakerCd;
            StockDetailWorkRs.MakerName = StockDetailWorkSrc.MakerName;
            StockDetailWorkRs.MakerKanaName = StockDetailWorkSrc.MakerKanaName;
            StockDetailWorkRs.CmpltMakerKanaName = StockDetailWorkSrc.CmpltMakerKanaName;
            StockDetailWorkRs.GoodsNo = StockDetailWorkSrc.GoodsNo;
            StockDetailWorkRs.GoodsName = StockDetailWorkSrc.GoodsName;
            StockDetailWorkRs.GoodsNameKana = StockDetailWorkSrc.GoodsNameKana;
            StockDetailWorkRs.GoodsLGroup = StockDetailWorkSrc.GoodsLGroup;
            StockDetailWorkRs.GoodsLGroupName = StockDetailWorkSrc.GoodsLGroupName;
            StockDetailWorkRs.GoodsMGroup = StockDetailWorkSrc.GoodsMGroup;
            StockDetailWorkRs.GoodsMGroupName = StockDetailWorkSrc.GoodsMGroupName;
            StockDetailWorkRs.BLGroupCode = StockDetailWorkSrc.BLGroupCode;
            StockDetailWorkRs.BLGroupName = StockDetailWorkSrc.BLGroupName;
            StockDetailWorkRs.BLGoodsCode = StockDetailWorkSrc.BLGoodsCode;
            StockDetailWorkRs.BLGoodsFullName = StockDetailWorkSrc.BLGoodsFullName;
            StockDetailWorkRs.EnterpriseGanreCode = StockDetailWorkSrc.EnterpriseGanreCode;
            StockDetailWorkRs.EnterpriseGanreName = StockDetailWorkSrc.EnterpriseGanreName;
            StockDetailWorkRs.WarehouseCode = StockDetailWorkSrc.WarehouseCode;
            StockDetailWorkRs.WarehouseName = StockDetailWorkSrc.WarehouseName;
            StockDetailWorkRs.WarehouseShelfNo = StockDetailWorkSrc.WarehouseShelfNo;
            StockDetailWorkRs.StockOrderDivCd = StockDetailWorkSrc.StockOrderDivCd;
            StockDetailWorkRs.OpenPriceDiv = StockDetailWorkSrc.OpenPriceDiv;
            StockDetailWorkRs.GoodsRateRank = StockDetailWorkSrc.GoodsRateRank;
            StockDetailWorkRs.CustRateGrpCode = StockDetailWorkSrc.CustRateGrpCode;
            StockDetailWorkRs.SuppRateGrpCode = StockDetailWorkSrc.SuppRateGrpCode;
            StockDetailWorkRs.ListPriceTaxExcFl = StockDetailWorkSrc.ListPriceTaxExcFl;
            StockDetailWorkRs.ListPriceTaxIncFl = StockDetailWorkSrc.ListPriceTaxIncFl;
            StockDetailWorkRs.StockRate = StockDetailWorkSrc.StockRate;
            StockDetailWorkRs.RateSectStckUnPrc = StockDetailWorkSrc.RateSectStckUnPrc;
            StockDetailWorkRs.RateDivStckUnPrc = StockDetailWorkSrc.RateDivStckUnPrc;
            StockDetailWorkRs.UnPrcCalcCdStckUnPrc = StockDetailWorkSrc.UnPrcCalcCdStckUnPrc;
            StockDetailWorkRs.PriceCdStckUnPrc = StockDetailWorkSrc.PriceCdStckUnPrc;
            StockDetailWorkRs.StdUnPrcStckUnPrc = StockDetailWorkSrc.StdUnPrcStckUnPrc;
            StockDetailWorkRs.FracProcUnitStcUnPrc = StockDetailWorkSrc.FracProcUnitStcUnPrc;
            StockDetailWorkRs.FracProcStckUnPrc = StockDetailWorkSrc.FracProcStckUnPrc;
            StockDetailWorkRs.StockUnitPriceFl = StockDetailWorkSrc.StockUnitPriceFl;
            StockDetailWorkRs.StockUnitTaxPriceFl = StockDetailWorkSrc.StockUnitTaxPriceFl;
            StockDetailWorkRs.StockUnitChngDiv = StockDetailWorkSrc.StockUnitChngDiv;
            StockDetailWorkRs.BfStockUnitPriceFl = StockDetailWorkSrc.BfStockUnitPriceFl;
            StockDetailWorkRs.BfListPrice = StockDetailWorkSrc.BfListPrice;
            StockDetailWorkRs.RateBLGoodsCode = StockDetailWorkSrc.RateBLGoodsCode;
            StockDetailWorkRs.RateBLGoodsName = StockDetailWorkSrc.RateBLGoodsName;
            StockDetailWorkRs.RateGoodsRateGrpCd = StockDetailWorkSrc.RateGoodsRateGrpCd;
            StockDetailWorkRs.RateGoodsRateGrpNm = StockDetailWorkSrc.RateGoodsRateGrpNm;
            StockDetailWorkRs.RateBLGroupCode = StockDetailWorkSrc.RateBLGroupCode;
            StockDetailWorkRs.RateBLGroupName = StockDetailWorkSrc.RateBLGroupName;
            StockDetailWorkRs.StockCount = StockDetailWorkSrc.StockCount;
            StockDetailWorkRs.OrderCnt = StockDetailWorkSrc.OrderCnt;
            StockDetailWorkRs.OrderAdjustCnt = StockDetailWorkSrc.OrderAdjustCnt;
            StockDetailWorkRs.OrderRemainCnt = StockDetailWorkSrc.OrderRemainCnt;
            StockDetailWorkRs.RemainCntUpdDate = StockDetailWorkSrc.RemainCntUpdDate;
            StockDetailWorkRs.StockPriceTaxExc = StockDetailWorkSrc.StockPriceTaxExc;
            StockDetailWorkRs.StockPriceTaxInc = StockDetailWorkSrc.StockPriceTaxInc;
            StockDetailWorkRs.StockGoodsCd = StockDetailWorkSrc.StockGoodsCd;
            StockDetailWorkRs.StockPriceConsTax = StockDetailWorkSrc.StockPriceConsTax;
            StockDetailWorkRs.TaxationCode = StockDetailWorkSrc.TaxationCode;
            StockDetailWorkRs.StockDtiSlipNote1 = StockDetailWorkSrc.StockDtiSlipNote1;
            StockDetailWorkRs.SalesCustomerCode = StockDetailWorkSrc.SalesCustomerCode;
            StockDetailWorkRs.SalesCustomerSnm = StockDetailWorkSrc.SalesCustomerSnm;
            StockDetailWorkRs.SlipMemo1 = StockDetailWorkSrc.SlipMemo1;
            StockDetailWorkRs.SlipMemo2 = StockDetailWorkSrc.SlipMemo2;
            StockDetailWorkRs.SlipMemo3 = StockDetailWorkSrc.SlipMemo3;
            StockDetailWorkRs.InsideMemo1 = StockDetailWorkSrc.InsideMemo1;
            StockDetailWorkRs.InsideMemo2 = StockDetailWorkSrc.InsideMemo2;
            StockDetailWorkRs.InsideMemo3 = StockDetailWorkSrc.InsideMemo3;
            StockDetailWorkRs.SupplierCd = StockDetailWorkSrc.SupplierCd;
            StockDetailWorkRs.SupplierSnm = StockDetailWorkSrc.SupplierSnm;
            StockDetailWorkRs.AddresseeCode = StockDetailWorkSrc.AddresseeCode;
            StockDetailWorkRs.AddresseeName = StockDetailWorkSrc.AddresseeName;
            StockDetailWorkRs.DirectSendingCd = StockDetailWorkSrc.DirectSendingCd;
            StockDetailWorkRs.OrderNumber = StockDetailWorkSrc.OrderNumber;
            StockDetailWorkRs.WayToOrder = StockDetailWorkSrc.WayToOrder;
            StockDetailWorkRs.DeliGdsCmpltDueDate = StockDetailWorkSrc.DeliGdsCmpltDueDate;
            StockDetailWorkRs.ExpectDeliveryDate = StockDetailWorkSrc.ExpectDeliveryDate;
            StockDetailWorkRs.OrderDataCreateDiv = StockDetailWorkSrc.OrderDataCreateDiv;
            StockDetailWorkRs.OrderDataCreateDate = StockDetailWorkSrc.OrderDataCreateDate;
            StockDetailWorkRs.OrderFormIssuedDiv = StockDetailWorkSrc.OrderFormIssuedDiv;

            StockDetailWorkRs.DtlRelationGuid = StockDetailWorkSrc.DtlRelationGuid;

            return StockDetailWorkRs;
        }
        // ADD by 李占川 for Redmine#35459 on 2013/05/08 ---------<<<<<<<

        /// <summary>
        /// <c>ArrayList</c>が<c>null</c>か空か判定します。
        /// </summary>
        /// <param name="arrayList">ArrayList</param>
        /// <returns>
        /// <c>true</c> :<c>null</c>または空である。<br/>
        /// <c>false</c>:要素あり
        /// </returns>
        private static bool IsNullOrEmpty(ArrayList arrayList)
        {
            return arrayList == null || arrayList.Count.Equals(0);
        }

        #endregion  // <Constructor/>

        #region <検索/>

        #region <UOE発注データ/>

        /// <summary>
        /// UOE発注データのレコードを検索します。
        /// </summary>
        /// <param name="receivedTelegram">受信電文</param>
        /// <returns>該当するUOE発注データのレコード（該当するレコードがなかった場合、<c>null</c>を返します）</returns>
        public UOEOrderDtlWork FindUOEOrderDtlWork(ReceivedText receivedTelegram)
        {
            string key = GetUOEOrderDertailKey(receivedTelegram);
            if (SearchedUOEOrderDetailRecordMap.ContainsKey(key))
            {
                return SearchedUOEOrderDetailRecordMap[key];
            }

            UOEOrderDtlWork foundRecord = FindUOEOrderDtlWork(receivedTelegram.DtlRelationGuid);
            return foundRecord;
        }

        /// <summary>
        /// UOE発注データのレコードを検索します。
        /// </summary>
        /// <param name="dtlRelationGuid">GUID</param>
        /// <returns>該当するUOE発注データのレコード（該当するレコードがなかった場合、<c>null</c>を返します）</returns>
        /// <remarks>
        /// <br>Update Note: 山形部品卸商仕入受信障害</br>
        /// <br>Programmer : 田村顕成</br>
        /// <br>Date       : 2013/01/20 </br>
        /// </remarks>
        public UOEOrderDtlWork FindUOEOrderDtlWork(Guid dtlRelationGuid)
        {
            // ------ADD 2023/01/20 田村顕成 卸商仕入受信処理障害対応 ------>>>>>
            if(dtlRelationGuid != Guid.Empty)
            {
            // ------ADD 2023/01/20 田村顕成 卸商仕入受信処理障害対応 ------<<<<<        	
	            foreach (UOEOrderDtlWork uoeOrderDtlWork in InsertingUOEOrderDetailRecordList)
	            {
	                if (uoeOrderDtlWork.DtlRelationGuid.Equals(dtlRelationGuid))
	                {
	                    return uoeOrderDtlWork;
	                }
	            }
	
	            foreach (UOEOrderDtlWork uoeOrderDtlWork in SearchedUOEOrderDetailRecordMap.Values)
	            {
	                if (uoeOrderDtlWork.DtlRelationGuid.Equals(dtlRelationGuid))
	                {
	                    return uoeOrderDtlWork;
	                }
	            }
            // ------ADD 2023/01/20 田村顕成 卸商仕入受信処理障害対応 ------>>>>>
            }
            // ------ADD 2023/01/20 田村顕成 卸商仕入受信処理障害対応 ------<<<<<        	

            return null;
        }

        #endregion  // <UOE発注データ/>

        #region <仕入明細データ/>

        /// <summary>
        /// 仕入明細データのレコードを検索します。
        /// </summary>
        /// <param name="receivedTelegram">受信電文</param>
        /// <returns>該当する仕入明細データのレコード（該当するレコードがなかった場合、<c>null</c>を返します）</returns>
        public StockDetailWork FindStockDetailWork(ReceivedText receivedTelegram)
        {
            string chainKey = GetUOEOrderDertailKey(receivedTelegram);
            if (!ChainKeyMap.ContainsKey(chainKey))
            {
                return FindStockDetailWorkByScanning(receivedTelegram);
            }

            long key = ChainKeyMap[chainKey];
            if (!SearchedStockDetailRecordMap.ContainsKey(key))
            {
                return FindStockDetailWorkByScanning(receivedTelegram);
            }

            return SearchedStockDetailRecordMap[key];
        }

        // add K2012/06/22 >>>
        /// <summary>
        /// 仕入明細データのレコードを検索します。
        /// </summary>
        /// <param name="receivedTelegram">受信電文</param>
        /// <returns>該当する仕入明細データのレコード（該当するレコードがなかった場合、<c>null</c>を返します）</returns>
        /// <remarks>
        /// <br>Update Note: Redmine#35459の対応</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2013/05/08 </br>
        /// </remarks>
        public StockDetailWork FindStockDetailWork2(ReceivedText receivedTelegram)
        {
            // ADD by 李占川 for Redmine#35611 on 2013/05/08 --------->>>>>>>
            // 山形部品、且つ、電話発注の場合、仕入明細データが作成しない
            if ((PurchaseStatus.Contract == _optionYamagataCustomControl)
                && receivedTelegram.IsTelephoneOrder())
            {
                    return null;
            }
            // ADD by 李占川 for Redmine#35611 on 2013/05/08 ---------<<<<<<<<

            string chainKey = GetUOEOrderDertailKey(receivedTelegram);
            if (!ChainKeyMap.ContainsKey(chainKey))
            {
                return FindStockDetailWorkByScanning(receivedTelegram);
            }

            long key = ChainKeyMap[chainKey];
            if (!SearchedStockDetailRecordMap.ContainsKey(key))
            {
                return FindStockDetailWorkByScanning(receivedTelegram);
            }
            if (_noAddStockDetailList.Contains(key))
                return null;
            //int key2 = BridgeKeyMap[chainKey]; // DEL 李占川 for Redmine#35459 2013/05/08
            long key2 = BridgeKeyMap[chainKey];  // ADD 李占川 for Redmine#35459 2013/05/08
            if (_noAddStockSlipList.Contains(key2))
                return null;

            return SearchedStockDetailRecordMap[key];
        }
        // add K2012/06/22 <<<

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receivedTelegram"></param>
        /// <returns></returns>
        private StockDetailWork FindStockDetailWorkByScanning(ReceivedText receivedTelegram)
        {
            foreach (IList<StockDetailWork> stockDetailWorkList in StockSlipDetailRecordMap.Values)
            {
                foreach (StockDetailWork stockDetailWork in stockDetailWorkList)
                {
                    if (stockDetailWork.DtlRelationGuid.Equals(receivedTelegram.DtlRelationGuid))
                    {
                        return stockDetailWork;
                    }
                }
            }
            return null;
        }

        #endregion  // <仕入明細データ/>

        #region <仕入データ/>

        /// <summary>
        /// 仕入データのレコードを検索します。
        /// </summary>
        /// <param name="receivedTelegram">受信電文</param>
        /// <returns>該当する仕入データのレコード（該当するレコードがなかった場合、<c>null</c>を返します）</returns>
        /// <remarks>
        /// <br>Update Note: Redmine#35459の対応</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2013/05/08 </br>
        /// </remarks>
        public StockSlipWork FindStockSlipWork(ReceivedText receivedTelegram)
        {
            string bridgeKey = GetUOEOrderDertailKey(receivedTelegram);
            if (!BridgeKeyMap.ContainsKey(bridgeKey))
            {
                return FindStockSlipWorkAtTelOrder(receivedTelegram);
            }

            //int key = BridgeKeyMap[bridgeKey]; // DEL 李占川 for Redmine#35459 2013/05/08
            long key = BridgeKeyMap[bridgeKey];  // ADD 李占川 for Redmine#35459 2013/05/08
            if (!StockSlipRecordMap.ContainsKey(key))
            {
                return FindStockSlipWorkAtTelOrder(receivedTelegram);
            }

            return StockSlipRecordMap[key];
        }

        /// <summary>
        /// 電話発注分の仕入データを検索します。
        /// </summary>
        /// <param name="receivedTelegram">受信電文</param>
        /// <returns>該当する仕入データのレコード（該当するレコードがなかった場合、<c>null</c>を返します）</returns>
        /// <remarks>
        /// <br>Update Note: Redmine#35459の対応</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2013/05/08 </br>
        /// </remarks>
        private StockSlipWork FindStockSlipWorkAtTelOrder(ReceivedText receivedTelegram)
        {
            string key = receivedTelegram.ToSlipNo();
            if (!TelOrderSupplierSlipNoMap.ContainsKey(key))
            {
                return null;
            }

            //int telOrderSupplierSlipNo = TelOrderSupplierSlipNoMap[key];  // DEL 李占川 for Redmine#35459 2013/05/08
            long telOrderSupplierSlipNo = TelOrderSupplierSlipNoMap[key];   // ADD 李占川 for Redmine#35459 2013/05/08
            if (!StockSlipRecordMap.ContainsKey(telOrderSupplierSlipNo))
            {
                return null;
            }

            return StockSlipRecordMap[telOrderSupplierSlipNo];
        }

        /// <summary>
        /// 仕入伝票番号を検索します。
        /// </summary>
        /// <param name="receivedTelegram">受信電文</param>
        /// <returns>該当する仕入伝票番号（該当する仕入伝票番号がなかった場合、<c>string.Empty</c>を返します）</returns>
        /// <remarks>
        /// <br>Update Note: Redmine#35459の対応</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2013/05/08 </br>
        /// </remarks>
        public string FindSupplierSlipNo(ReceivedText receivedTelegram)
        {
            string bridgeKey = GetUOEOrderDertailKey(receivedTelegram);
            if (!BridgeKeyMap.ContainsKey(bridgeKey))
            {
                string slipNo = receivedTelegram.ToSlipNo();
                if (TelOrderSupplierSlipNoMap.ContainsKey(slipNo))
                {
                    return TelOrderSupplierSlipNoMap[slipNo].ToString();
                }
                return string.Empty;
            }

            //int key = BridgeKeyMap[bridgeKey]; // DEL 李占川 for Redmine#35459 2013/05/08
            long key = BridgeKeyMap[bridgeKey];  // ADD 李占川 for Redmine#35459 2013/05/08
            if (!StockSlipRecordMap.ContainsKey(key))
            {
                string slipNo = receivedTelegram.ToSlipNo();
                if (TelOrderSupplierSlipNoMap.ContainsKey(slipNo))
                {
                    return TelOrderSupplierSlipNoMap[slipNo].ToString();
                }
                return string.Empty;
            }

            return key.ToString();
        }

        #endregion  // <仕入データ/>

        #endregion  // <検索/>

        #region <合計/>

        /// <summary>
        /// 仕入金額合計を取得します。
        /// </summary>
        /// <param name="receivedTelegram">受信電文</param>
        /// <returns>仕入明細データの仕入金額（税抜き）合計</returns>
        public long GetStockTotalPrice(ReceivedText receivedTelegram)
        {
            string strSupplierSlipNo = FindSupplierSlipNo(receivedTelegram);
            if (string.IsNullOrEmpty(strSupplierSlipNo)) return 0;

            int supplierSlipNo = int.Parse(strSupplierSlipNo);
            if (!StockSlipDetailRecordMap.ContainsKey(supplierSlipNo)) return 0;

            long sum = 0;
            foreach (StockDetailWork stockDetailWork in StockSlipDetailRecordMap[supplierSlipNo])
            {
                sum += stockDetailWork.StockPriceTaxExc;
            }
            return sum;
        }

        /// <summary>
        /// 仕入金額小計を取得します。
        /// </summary>
        /// <param name="receivedTelegram">受信電文</param>
        /// <returns>仕入明細データの仕入金額（税込み）合計</returns>
        public long GetStockSubttlPrice(ReceivedText receivedTelegram)
        {
            string strSupplierSlipNo = FindSupplierSlipNo(receivedTelegram);
            if (string.IsNullOrEmpty(strSupplierSlipNo)) return 0;

            int supplierSlipNo = int.Parse(strSupplierSlipNo);
            if (!StockSlipDetailRecordMap.ContainsKey(supplierSlipNo)) return 0;

            long sum = 0;
            foreach (StockDetailWork stockDetailWork in StockSlipDetailRecordMap[supplierSlipNo])
            {
                sum += stockDetailWork.StockPriceTaxInc;
            }
            return sum;
        }

        /// <summary>
        /// 明細行数を取得します。
        /// </summary>
        /// <param name="receivedTelegram">受信電文</param>
        /// <returns>関連する仕入明細データの数</returns>
        public int GetDetailRowCount(ReceivedText receivedTelegram)
        {
            string strSupplierSlipNo = FindSupplierSlipNo(receivedTelegram);
            if (string.IsNullOrEmpty(strSupplierSlipNo)) return 0;

            int supplierSlipNo = int.Parse(strSupplierSlipNo);
            if (!StockSlipDetailRecordMap.ContainsKey(supplierSlipNo)) return 0;

            return StockSlipDetailRecordMap[supplierSlipNo].Count;
        }

        #endregion  // <合計/>

        #region <企業コード/>

        /// <summary>
        /// 企業コードを取得します。
        /// </summary>
        private string EnterpriseCode
        {
            get
            {
                if (SearchedUOEOrderDetailRecordMap.Values.Count > 0)
                {
                    foreach (UOEOrderDtlWork uoeOrderDetail in SearchedUOEOrderDetailRecordMap.Values)
                    {
                        return uoeOrderDetail.EnterpriseCode;
                    }
                }
                if (InsertingUOEOrderDetailRecordList.Count > 0)
                {
                    return InsertingUOEOrderDetailRecordList[0].EnterpriseCode;
                }
                return string.Empty;
            }
        }

        #endregion  // <企業コード/>

        #region <売上・仕入制御オプション/>

        /// <summary>
        /// 売上・仕入制御オプションを生成します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>売上・仕入制御オプション</returns>
        private static IOWriteCtrlOptWork CreateIOWriteCtrlOption(string enterpriseCode)
        {
            // 売上・仕入制御オプションを設定
            IOWriteCtrlOptWork ioWriteCtrlOption = new IOWriteCtrlOptWork();
            {
                // 制御起点（0:売上, 1:仕入, 2:仕入売上同時計上, 9:未設定）
                ioWriteCtrlOption.CtrlStartingPoint = 1;

                // 見積データ計上残区分（0:残す, 1:残さない）
                ioWriteCtrlOption.EstimateAddUpRemDiv = 0;

                // 受注データ計上残区分（0:残す, 1:残さない）
                ioWriteCtrlOption.AcpOdrrAddUpRemDiv = 0;

                // 出荷データ計上残区分（0:残す, 1:残さない）
                ioWriteCtrlOption.ShipmAddUpRemDiv = 0;

                // 返品時在庫登録区分（0:する, 1:しない）
                ioWriteCtrlOption.RetGoodsStockEtyDiv = 0;

                // 仕入伝票削除区分（0:しない, 1:確認, 2:する（する：売仕入同時計上の仕入伝票を売伝削除時に同時削除））
                ioWriteCtrlOption.SupplierSlipDelDiv = 0;

                // 残数管理区分（0:する, 1:しない　※伝票削除時に残に戻すかどうか）
                ioWriteCtrlOption.RemainCntMngDiv = 0;

                // 企業コード（排他制御のキーとして用いる企業コード）
                ioWriteCtrlOption.EnterpriseCode = enterpriseCode;

                // 車両管理区分（0:しない, 1:する）
                ioWriteCtrlOption.CarMngDivCd = 0;
            }
            return ioWriteCtrlOption;
        }

        #endregion  // <売上・仕入制御オプション/>

        #region <伝票明細追加情報データ/>

        /// <summary>伝票明細追加情報データのカウンタ</summary>
        private static int _slipDetailAddInfoCount;

        /// <summary>
        /// 伝票明細追加情報データを生成します。
        /// </summary>
        /// <param name="dtlRelationGuid">明細関連付けGUID</param>
        /// <returns>伝票明細追加情報データ</returns>
        private static SlipDetailAddInfoWork CreateSlipDetailAddInfoWork(Guid dtlRelationGuid)
        {
            SlipDetailAddInfoWork slipDetailAddInfoWork = new SlipDetailAddInfoWork();
            {
                slipDetailAddInfoWork.DtlRelationGuid = dtlRelationGuid;
                slipDetailAddInfoWork.GoodsEntryDiv = 0;    // 0:なし／1:あり
                slipDetailAddInfoWork.GoodsOfferDate = DateTime.MinValue;
                slipDetailAddInfoWork.PriceUpdateDiv = 0;    // 0:なし／1:あり
                slipDetailAddInfoWork.PriceStartDate = DateTime.MinValue;
                slipDetailAddInfoWork.GoodsOfferDate = DateTime.MinValue;
                slipDetailAddInfoWork.CarRelationGuid = Guid.Empty;
                slipDetailAddInfoWork.SlipDtlRegOrder = (++_slipDetailAddInfoCount);    // 伝票番号と大小を同じ関係にする
                slipDetailAddInfoWork.AddUpRemDiv = 1;    // 0:売上仕入制御オプションに準拠／1:残す／2:残さない
            }
            return slipDetailAddInfoWork;
        }

        #endregion  // <伝票明細追加情報データ/>

        /// <summary>
        /// 書込むデータを生成します。
        /// </summary>
        /// <param name="writingSumUpInformation">計上情報の書込みフラグ</param>
        /// <returns>書込むデータ</returns>
        /// <remarks>
        /// <br></br>
        /// <br>Update Note: 山形部品完全個別オプション判定追加</br>
        /// <br>Programmer : FSI佐々木 貴英</br>
        /// <br>Date       : K2012/12/11 </br>
        /// <br></br>
        /// <br>Update Note: Redmine#35459の対応</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2013/05/08 </br>
        /// <br>Update Note: 2014/05/30 鄧潘ハン</br>
        /// <br>             Redmine 42755 エラー「重複した仕入データが存在します」の対応</br>
        /// <br>Update Note: PMKOBETSU-4189　ログ追加</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : K2021/09/22</br>
        /// </remarks>
        public CustomSerializeArrayList CreateWritingData(bool writingSumUpInformation)
        {
            // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------>>>>>
            //UOE発注データ件数
            int uoeOrderDataCount = 0;
            //UOE発注データ(電話分)件数
            int uoeOrderDataTelCount = 0;
            //仕入データ(発注分)件数
            int stockSlipOrderCount = 0;
            //仕入明細データ(発注分)件数
            int stockDetailOrderCount = 0;
            //仕入データ件数
            int stockSlipCount = 0;
            //仕入明細データ件数
            int stockDetailCount = 0;
            //在庫調整データ件数
            int stockAdjustCount = 0;
            //在庫調整明細データ件数
            int stockAdjustDetailCount = 0;
            // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------<<<<<
            CustomSerializeArrayList writingData = new CustomSerializeArrayList();
            {
                if (GetUOEOrderDataCount().Equals(0)) return writingData;

                // 売上・仕入制御オプション
                #region <売上・仕入制御オプション/>

                writingData.Add(CreateIOWriteCtrlOption(EnterpriseCode));

                #endregion  // <売上・仕入制御オプション/>

                // UOE発注データ
                #region <UOE発注データ/>

                ArrayList uoeOrderDataList = new ArrayList();
                {
                    foreach (UOEOrderDtlWork uoeOrderDtlWork in SearchedUOEOrderDetailRecordMap.Values)
                    {
                        UOEOrderDtlWork writingRecord = FormatWritingData(uoeOrderDtlWork);
                        // add K2012/06/22 >>>
                        string key = GetUOEOrderDertailKey(uoeOrderDtlWork);
                        // DEL K2012/12/11 END <<<<<<
                        //if (_noAddUoeOderList.Contains(key))
                        // DEL K2012/12/11 END <<<<<<
                        // ADD K2012/12/11 START >>>>>>
                        // 山形部品完全個別オプションが有効かつ追加しないリストに存在するデータの場合、登録対象としない
                        if ((PurchaseStatus.Contract == _optionYamagataCustomControl) && (_noAddUoeOderList.Contains(key)))
                        // ADD K2012/12/11 END <<<<<<
                                continue;
                        // add K2012/06/22 <<<
                        uoeOrderDataList.Add(writingRecord);
                        uoeOrderDataCount++;// ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応
                    }
                    foreach (UOEOrderDtlWork uoeOrderDtlWork in InsertingUOEOrderDetailRecordList)
                    {
                        UOEOrderDtlWork writingRecord = FormatWritingData(uoeOrderDtlWork);
                        // add K2012/06/22 >>>
                        string key = GetUOEOrderDertailKey(uoeOrderDtlWork);
                        // DEL K2012/12/11 END <<<<<<
                        //if (_noAddUoeOderList.Contains(key))
                        // DEL K2012/12/11 END <<<<<<
                        // ADD K2012/12/11 START >>>>>>
                        // 山形部品完全個別オプションが有効かつ追加しないリストに存在するデータの場合、登録対象としない
                        if ((PurchaseStatus.Contract == _optionYamagataCustomControl) && (_noAddUoeOderList.Contains(key)))
                        // ADD K2012/12/11 END <<<<<<
                            continue;
                        // add K2012/06/22 <<<
                        uoeOrderDataList.Add(writingRecord);
                        uoeOrderDataTelCount++;// ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応
                    }
                }
                // add K2012/06/22 >>>
                // DEL K2012/12/11 END <<<<<<
                //// UOE発注データの更新対象が0ならDB更新を行わない
                //if (uoeOrderDataList.Count == 0)
                // DEL K2012/12/11 END <<<<<<
                // ADD K2012/12/11 START >>>>>>
                // 山形部品完全個別オプションが有効かつUOE発注データの更新対象が0ならDB更新を行わない
                if ((PurchaseStatus.Contract == _optionYamagataCustomControl) && (uoeOrderDataList.Count == 0))
                // ADD K2012/12/11 END <<<<<<
                {
                    this._dbWriteFlg = false;
                }
                else
                    this._dbWriteFlg = true;
                // add K2012/06/22 <<<
                CustomSerializeArrayList uoeOrderData = new CustomSerializeArrayList();
                {
                    uoeOrderData.Add(uoeOrderDataList);
                }
                if (uoeOrderData.Count > 0)
                {
                    writingData.Add(uoeOrderData);
                }

                #endregion  // <UOE発注データ/>

                // 発注情報の仕入データと仕入明細データ
                #region <発注情報の仕入データと仕入明細データ/>

                CustomSerializeArrayList orderStockData = new CustomSerializeArrayList();
                {
                    //foreach (int supplierSlipNo in StockSlipDetailRecordMap.Keys)  // DEL 李占川 for Redmine#35459 2013/05/08
                    foreach (long supplierSlipNo in StockSlipDetailRecordMap.Keys)   // ADD 李占川 for Redmine#35459 2013/05/08
                    {
                        // 電話発注分の判定
                        if (supplierSlipNo > 0) continue;

                        CustomSerializeArrayList slipList = new CustomSerializeArrayList();
                        {
                            // 発注情報の仕入データ
                            StockSlipWork writingRecord = FormatWritingData(StockSlipRecordMap[supplierSlipNo], true);

                            // add K2012/06/22 >>>
                            // DEL K2012/12/11 END <<<<<<
                            //if (_noAddStockSlipList.Contains(writingRecord.SupplierSlipNo))
                            //    //if (stockSlipKey.Contains(writingRecord.SupplierSlipNo))
                            // DEL K2012/12/11 END <<<<<<
                            // ADD K2012/12/11 START >>>>>>
                            // 山形部品完全個別オプションが有効かつ追加しないリストに存在するデータの場合、登録対象としない
                            if ((PurchaseStatus.Contract == _optionYamagataCustomControl) && (_noAddStockSlipList.Contains(writingRecord.SupplierSlipNo)))
                            // ADD K2012/12/11 END <<<<<<
                                continue;
                            // add K2012/06/22 <<<
                            slipList.Add(writingRecord);
                            stockSlipOrderCount++;// ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応
                        }
                        // 発注情報の仕入明細データ 
                        ArrayList stockDetailList = new ArrayList();
                        {
                            foreach (StockDetailWork stockDetailWork in StockSlipDetailRecordMap[supplierSlipNo])
                            {
                                StockDetailWork writingRecord = FormatWritingData(stockDetailWork, true);
                                // add K2012/06/22 >>>
                                // DEL K2012/12/11 END <<<<<<
                                //if (_noAddStockDetailList.Contains(writingRecord.StockSlipDtlNum))
                                //    //if (stockDetailKey.Contains(writingRecord.StockSlipDtlNum))
                                // DEL K2012/12/11 END <<<<<<
                                // ADD K2012/12/11 START >>>>>>
                                // 山形部品完全個別オプションが有効かつ追加しないリストに存在するデータの場合、登録対象としない
                                if ((PurchaseStatus.Contract == _optionYamagataCustomControl) && (_noAddStockDetailList.Contains(writingRecord.StockSlipDtlNum)))
                                // ADD K2012/12/11 END <<<<<<
                                    continue;
                                // add K2012/06/22 <<<
                                stockDetailList.Add(writingRecord);
                                stockDetailOrderCount++;// ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応
                            }
                        }
                        slipList.Add(stockDetailList);

                        if (slipList.Count > 0)
                        {
                            writingData.Add(slipList);
                        }

                        //orderStockData.Add(slipList);
                    }
                }
                //writingData.Add(orderStockData);

                #endregion  // <発注情報の仕入データと仕入明細データ/>

                if (!writingSumUpInformation) return writingData;

                // 計上情報の仕入データと仕入明細データ
                #region <計上情報の仕入データと仕入明細データ/>

                if (SumUpStockSlipDetailRecordMap.Count > 0)
                {
                    CustomSerializeArrayList sumUpStockData = new CustomSerializeArrayList();
                    {
                        _slipDetailAddInfoCount = 0;

                        // 2010/10/19 >>>
                        //// 伝票番号をソート
                        //SortedList<int, int> sortedSupplierSlipNoList = new SortedList<int, int>();
                        //{
                        //    foreach (int supplierSlipNo in SumUpStockSlipDetailRecordMap.Keys)
                        //    {
                        //        sortedSupplierSlipNoList.Add(supplierSlipNo, supplierSlipNo);
                        //    }
                        //}

                        // 仕入伝票番号(相手先伝票番号)順にソート
                        SortedList<string, int> sortedSupplierSlipNoList = new SortedList<string, int>();
                        {
                            foreach (int supplierSlipNo in SumUpStockSlipRecordMap.Keys)
                            {
                                sortedSupplierSlipNoList.Add(SumUpStockSlipRecordMap[supplierSlipNo].PartySaleSlipNum, supplierSlipNo);
                            }
                        }
                        // 2010/10/19 <<<
                        foreach (int supplierSlipNo in sortedSupplierSlipNoList.Values)
                        {
                            // add K2012/06/22 >>>
                            // DEL K2012/12/11 END <<<<<<
                            //if (string.IsNullOrEmpty(SumUpStockSlipRecordMap[supplierSlipNo].PartySaleSlipNum))
                            // DEL K2012/12/11 END <<<<<<
                            // ADD K2012/12/11 START >>>>>>
                            // 山形部品完全個別オプションが有効かつ相手先伝票番号が設定されていない場合、
                            // 本ステートメント内の以降の処理をスキップする
                            String PartySaleSlipNum = SumUpStockSlipRecordMap[supplierSlipNo].PartySaleSlipNum;  // ADD by 李占川 for Redmine#35611 on 2013/05/08
                            if (   (PurchaseStatus.Contract == _optionYamagataCustomControl) 
                                // && (string.IsNullOrEmpty(SumUpStockSlipRecordMap[supplierSlipNo].PartySaleSlipNum)))  // DEL  by 李占川 for Redmine#35611 on 2013/05/08
                                // && (!(string.IsNullOrEmpty(PartySaleSlipNum)) && "FALSE".Equals(PartySaleSlipNum.Substring(0, 5))))  // ADD by 李占川 for Redmine#35611 on 2013/05/08// DEL 2014/05/30 鄧潘ハン Redmine 42755 エラー「重複した仕入データが存在します」の対応
                                && (!(string.IsNullOrEmpty(PartySaleSlipNum)) && PartySaleSlipNum.Length >= 5 && "FALSE".Equals(PartySaleSlipNum.Substring(0, 5))))// ADD 2014/05/30 鄧潘ハン Redmine 42755 エラー「重複した仕入データが存在します」の対応
                            // ADD K2012/12/11 END <<<<<<
                                continue;
                            // add K2012/06/22 <<<
                            CustomSerializeArrayList slipList = new CustomSerializeArrayList();
                            {
                                // 計上情報の仕入データ
                                StockSlipWork writingRecord = FormatWritingData(SumUpStockSlipRecordMap[supplierSlipNo], false);
                                slipList.Add(writingRecord);
                                stockSlipCount++;// ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応
                            }
                            // 計上情報の仕入明細データ 
                            ArrayList stockDetailList = new ArrayList();
                            {
                                foreach (StockDetailWork stockDetailWork in SumUpStockSlipDetailRecordMap[supplierSlipNo])
                                {
                                    // 2009/10/14 Add >>>
                                    if (FindUOEOrderDtlWork(stockDetailWork.DtlRelationGuid) == null) continue;
                                    // 2009/10/14 Add <<<
                                    StockDetailWork writingRecord = FormatWritingData(stockDetailWork, false);
                                    stockDetailList.Add(writingRecord);
                                    stockDetailCount++;// ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応
                                }
                            }
                            slipList.Add(stockDetailList);

                            // 伝票明細追加情報データ
                            ArrayList slipDetailAddInfoList = new ArrayList();
                            {
                                foreach (StockDetailWork stockDetailWork in stockDetailList)
                                {
                                    SlipDetailAddInfoWork slipDetailAddInfoWork = CreateSlipDetailAddInfoWork(stockDetailWork.DtlRelationGuid);
                                    slipDetailAddInfoList.Add(slipDetailAddInfoWork);
                                }
                            }
                            slipList.Add(slipDetailAddInfoList);

                            writingData.Add(slipList);

                            //sumUpStockData.Add(slipList);
                        }   // foreach (int supplierSlipNo in sortedSupplierSlipNoList.Values)
                    }   // CustomSerializeArrayList sumUpStockData = new CustomSerializeArrayList();
                    //writingData.Add(sumUpStockData);
                }   // if (SumUpStockSlipDetailRecordMap.Count > 0)

                #endregion  // <計上情報の仕入データと仕入明細データ/>

                // 計上情報の在庫調整データと在庫調整明細データ
                #region <計上情報の仕入データと仕入明細データ/>

                // 在庫調整明細データが 0件 の場合もありえるので、在庫調整明細データの件数も条件に含む
                if (SumUpStockAdjustDetailRecordMap.Count > 0 && SumUpStockAdjustDetailRecordMap.Values.Count > 0)
                {
                    CustomSerializeArrayList sumUpAdjustData = new CustomSerializeArrayList();
                    {
                        foreach (int supplierSlipNo in SumUpStockAdjustDetailRecordMap.Keys)
                        {
                            CustomSerializeArrayList adjustList = new CustomSerializeArrayList();
                            {
                                // 計上情報の在庫調整データ
                                ArrayList stockAdjustWork = new ArrayList();
                                {
                                    // 2009/10/15 >>>
                                    //stockAdjustWork.Add(SumUpAdjustRecordMap[supplierSlipNo]);
                                    stockAdjustWork.Add(FormatWritingData(SumUpAdjustRecordMap[supplierSlipNo], true));
                                    // 2009/10/15 <<<
                                }
                                adjustList.Add(stockAdjustWork);
                                stockAdjustCount++;// ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応
                            }
                            // 計上情報の在庫調整明細データ 
                            ArrayList stockAdjustDetailList = new ArrayList();
                            {
                                foreach (StockAdjustDtlWork stockAdjustDetailWork in SumUpStockAdjustDetailRecordMap[supplierSlipNo])
                                {
                                    // 2009/10/15 >>>
                                    //stockAdjustDetailList.Add(stockAdjustDetailWork);
                                    stockAdjustDetailList.Add(FormatWritingData(stockAdjustDetailWork, true));
                                    stockAdjustDetailCount++;// ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応
                                    // 2009/10/15 <<<
                                }
                            }
                            adjustList.Add(stockAdjustDetailList);

                            // 2009/02/26 在庫調整のパラメータ構造が変更
                            //writingData.Add(adjustList);
                            sumUpAdjustData.Add(adjustList);

                            _stockAdjustDBParamList = adjustList;   // HACK:<単独で在庫調整データを書く実験コード/>
                            //sumUpAdjustData.Add(slipList);
                        }   // foreach (int supplierSlipNo in SumUpStockAdjustDetailRecordMap.Keys)
                    }   // CustomSerializeArrayList sumUpAdjustData = new CustomSerializeArrayList();

                    writingData.Add(sumUpAdjustData);   // 2009/02/26 在庫調整のパラメータ構造が変更
                }   // if (SumUpStockAdjustDetailRecordMap.Count > 0 && SumUpStockAdjustDetailRecordMap.Values.Count > 0)

                #endregion  // <計上情報の仕入データと仕入明細データ/>
            }
            _logMsg = string.Format(CtLogDataMassage, uoeOrderDataCount, stockSlipCount, stockDetailCount, stockAdjustCount, stockAdjustDetailCount);// ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応
            return writingData;
        }

        #region <書込み用フォーマット/>

        /// <summary>
        /// UOE発注データのレコードを書込み用にフォーマットします。
        /// </summary>
        /// <param name="src">元レコード</param>
        private static UOEOrderDtlWork FormatWritingData(UOEOrderDtlWork src)
        {
            UOEOrderDtlWork nullValue = new UOEOrderDtlWork();
            {
                src.CreateDateTime      = nullValue.CreateDateTime;     // 001.作成日時
                src.UpdateDateTime      = nullValue.UpdateDateTime;     // 002.更新日時
                // 003.企業コード
                src.FileHeaderGuid      = nullValue.FileHeaderGuid;     // 004.GUID
                src.UpdEmployeeCode     = nullValue.UpdEmployeeCode;    // 005.更新従業員コード
                src.UpdAssemblyId1      = nullValue.UpdAssemblyId1;     // 006.更新アセンブリID1
                src.UpdAssemblyId2      = nullValue.UpdAssemblyId2;     // 007.更新アセンブリID2
                src.LogicalDeleteCode   = nullValue.LogicalDeleteCode;  // 008.論理削除区分

                src.OnlineNo            = nullValue.OnlineNo;           // 016.オンライン番号
                // 017.オンライン行番号
            }
            return src;
        }

        /// <summary>
        /// 仕入データのレコードを書込み用にフォーマットします。
        /// </summary>
        /// <param name="src">元レコード</param>
        /// <param name="isOrder"></param>
        private static StockSlipWork FormatWritingData(
            StockSlipWork src,
            bool isOrder
        )
        {
            StockSlipWork nullValue = new StockSlipWork();
            {
                if (!isOrder)
                {
                    src.CreateDateTime      = nullValue.CreateDateTime;     // 001.作成日時
                    src.UpdateDateTime      = nullValue.UpdateDateTime;     // 002.更新日時
                    // 003.企業コード
                    src.FileHeaderGuid      = nullValue.FileHeaderGuid;     // 004.GUID
                    src.UpdEmployeeCode     = nullValue.UpdEmployeeCode;    // 005.更新従業員コード
                    src.UpdAssemblyId1      = nullValue.UpdAssemblyId1;     // 006.更新アセンブリID1
                    src.UpdAssemblyId2      = nullValue.UpdAssemblyId2;     // 007.更新アセンブリID2
                    src.LogicalDeleteCode   = nullValue.LogicalDeleteCode;  // 008.論理削除区分
                }
                src.SupplierSlipNo = nullValue.SupplierSlipNo;  // 010.仕入伝票番号

                // 2009/10/15 >>>
                // 桁数補正
                if (src.StockInputName.Length > 16) src.StockInputName = src.StockInputName.Substring(0, 16);   // 仕入入力者名称
                if (src.StockAgentName.Length > 16) src.StockAgentName = src.StockAgentName.Substring(0, 16);   // 仕入担当者名称
                // 2009/10/15 <<<
            }
            return src;
        }

        /// <summary>
        /// 仕入明細データのレコードを書込み用にフォーマットします。
        /// </summary>
        /// <param name="src">元レコード</param>
        /// <param name="isOrder"></param>
        private static StockDetailWork FormatWritingData(
            StockDetailWork src,
            bool isOrder
        )
        {
            StockDetailWork nullValue = new StockDetailWork();
            {
                if (!isOrder)
                {
                    src.CreateDateTime      = nullValue.CreateDateTime;     // 001.作成日時
                    src.UpdateDateTime      = nullValue.UpdateDateTime;     // 002.更新日時
                    // 003.企業コード
                    src.FileHeaderGuid      = nullValue.FileHeaderGuid;     // 004.GUID
                    src.UpdEmployeeCode     = nullValue.UpdEmployeeCode;    // 005.更新従業員コード
                    src.UpdAssemblyId1      = nullValue.UpdAssemblyId1;     // 006.更新アセンブリID1
                    src.UpdAssemblyId2      = nullValue.UpdAssemblyId2;     // 007.更新アセンブリID2
                    src.LogicalDeleteCode   = nullValue.LogicalDeleteCode;  // 008.論理削除区分

                    src.StockSlipDtlNum = nullValue.StockSlipDtlNum;    // 016.仕入明細通番
                }
                src.AcceptAnOrderNo = nullValue.AcceptAnOrderNo;    // 009.受注番号
                src.SupplierSlipNo  = nullValue.SupplierSlipNo;     // 011.仕入伝票番号
                // 012.仕入行番号
                // 015.共通通番

                // 2009/10/15 >>>
                // 桁数補正
                if (src.StockInputName.Length > 16) src.StockInputName = src.StockInputName.Substring(0, 16);   // 仕入入力者名称
                if (src.StockAgentName.Length > 16) src.StockAgentName = src.StockAgentName.Substring(0, 16);   // 仕入担当者名称
                // 2009/10/15 <<<

            }
            return src;
        }

        // 2009/10/15 Add >>>
        /// <summary>
        /// 在庫調整データのレコードを書込み用にフォーマットします。
        /// </summary>
        /// <param name="src">元レコード</param>
        /// <param name="isOrder"></param>
        private static StockAdjustWork FormatWritingData(
            StockAdjustWork src,
            bool isOrder
        )
        {
            StockAdjustWork nullValue = new StockAdjustWork();
            {
                if (!isOrder)
                {
                }

                // 桁数補正
                if (src.StockInputName.Length > 16) src.StockInputName = src.StockInputName.Substring(0, 16);   // 仕入入力者名称
                if (src.StockAgentName.Length > 16) src.StockAgentName = src.StockAgentName.Substring(0, 16);   // 仕入担当者名称
            }
            return src;
        }

        /// <summary>
        /// 在庫調整明細データのレコードを書込み用にフォーマットします。
        /// </summary>
        /// <param name="src">元レコード</param>
        /// <param name="isOrder"></param>
        private static StockAdjustDtlWork FormatWritingData(
            StockAdjustDtlWork src,
            bool isOrder
        )
        {
            StockAdjustDtlWork nullValue = new StockAdjustDtlWork();
            {
                if (!isOrder)
                {
                }
            }
            return src;
        }

        // 2009/10/15 Add <<<

        #endregion  // <書込み用フォーマット/>

        #region <送受信JNL/>

        /// <summary>
        /// 送受信JNLレコードのリストを生成します。
        /// </summary>
        /// <returns>送受信JNLレコードのリスト</returns>
        public List<OrderSndRcvJnl> CreateOrderSndRcvJnlList()
        {
            List<OrderSndRcvJnl> orderSndRcvJnlList = new List<OrderSndRcvJnl>();
            {
                foreach (UOEOrderDtlWork uoeOrderDtlWork in SearchedUOEOrderDetailRecordMap.Values)
                {
                    orderSndRcvJnlList.Add(CreateOrderSndRcvJnl(uoeOrderDtlWork));
                }
                foreach (UOEOrderDtlWork uoeOrderDtlWork in InsertingUOEOrderDetailRecordList)
                {
                    orderSndRcvJnlList.Add(CreateOrderSndRcvJnl(uoeOrderDtlWork));
                }
            }
            return orderSndRcvJnlList;
        }

        /// <summary>
        /// 送受信JNLレコードを生成します。
        /// </summary>
        /// <param name="src">UOE発注データの明細レコード</param>
        /// <returns>送受信JNLレコード</returns>
        private static OrderSndRcvJnl CreateOrderSndRcvJnl(UOEOrderDtlWork src)
        {
            OrderSndRcvJnl record = new OrderSndRcvJnl();
            {
                #region <メンバフィールドをコピー/>

                record.AcceptAnOrderCnt = src.AcceptAnOrderCnt;
                record.AcptAnOdrStatus = src.AcptAnOdrStatus;
                record.AnswerListPrice = src.AnswerListPrice;
                record.AnswerMakerCd = src.AnswerMakerCd;
                record.AnswerPartsName = src.AnswerPartsName;
                record.AnswerPartsNo = src.AnswerPartsNo;
                record.AnswerSalesUnitCost = src.AnswerSalesUnitCost;
                record.BoCode = src.BoCode;
                record.BOCount = src.BOCount;
                record.BOManagementNo = src.BOManagementNo;
                record.BOShipmentCnt1 = src.BOShipmentCnt1;
                record.BOShipmentCnt2 = src.BOShipmentCnt2;
                record.BOShipmentCnt3 = src.BOShipmentCnt3;
                record.BOSlipNo1 = src.BOSlipNo1;
                record.BOSlipNo2 = src.BOSlipNo2;
                record.BOSlipNo3 = src.BOSlipNo3;
                record.BOStockCount1 = src.BOStockCount1;
                record.BOStockCount2 = src.BOStockCount2;
                record.BOStockCount3 = src.BOStockCount3;
                record.CashRegisterNo = src.CashRegisterNo;
                record.CommAssemblyId = src.CommAssemblyId;
                record.CommonSeqNo = src.CommonSeqNo;
                record.CreateDateTime = src.CreateDateTime;
                //record.CreateDateTimeAdFormal = src.CreateDateTimeAdFormal;
                //record.CreateDateTimeAdInFormal = src.CreateDateTimeAdInFormal;
                //record.CreateDateTimeJpFormal = src.CreateDateTimeJpFormal;
                //record.CreateDateTimeJpInFormal = src.CreateDateTimeJpInFormal;
                record.CustomerCode = src.CustomerCode;
                record.CustomerSnm = src.CustomerSnm;
                record.DataRecoverDiv = src.DataRecoverDiv;
                record.DataSendCode = src.DataSendCode;
                record.DataUpdateDateTime = src.DataUpdateDateTime;
                //record.DataUpdateDateTimeAdFormal = src.DataUpdateDateTimeAdFormal;
                //record.DataUpdateDateTimeAdInFormal = src.DataUpdateDateTimeAdInFormal;
                //record.DataUpdateDateTimeJpFormal = src.DataUpdateDateTimeJpFormal;
                //record.DataUpdateDateTimeJpInFormal = src.DataUpdateDateTimeJpInFormal;
                record.DeliveredGoodsDivNm = src.DeliveredGoodsDivNm;
                record.DtlRelationGuid = src.DtlRelationGuid;
                record.EmployeeCode = src.EmployeeCode;
                record.EmployeeName = src.EmployeeName;
                record.EnterpriseCode = src.EnterpriseCode;
                //record.EnterpriseName = src.EnterpriseName;
                record.EnterUpdDivBO1 = src.EnterUpdDivBO1;
                record.EnterUpdDivBO2 = src.EnterUpdDivBO2;
                record.EnterUpdDivBO3 = src.EnterUpdDivBO3;
                record.EnterUpdDivEO = src.EnterUpdDivEO;
                record.EnterUpdDivMaker = src.EnterUpdDivMaker;
                record.EnterUpdDivSec = src.EnterUpdDivSec;
                record.EOAlwcCount = src.EOAlwcCount;
                record.FileHeaderGuid = src.FileHeaderGuid;
                record.FollowDeliGoodsDiv = src.FollowDeliGoodsDiv;
                record.FollowDeliGoodsDivNm = src.FollowDeliGoodsDivNm;
                record.GoodsMakerCd = src.GoodsMakerCd;
                record.GoodsName = src.GoodsName;
                record.GoodsNo = src.GoodsNo;
                record.GoodsNoNoneHyphen = src.GoodsNoNoneHyphen;
                record.HeadErrorMassage = src.HeadErrorMassage;
                record.InputDay = src.InputDay;
                //record.InputDayAdFormal = src.InputDayAdFormal;
                //record.InputDayAdInFormal = src.InputDayAdInFormal;
                //record.InputDayJpFormal = src.InputDayJpFormal;
                //record.InputDayJpInFormal = src.InputDayJpInFormal;
                record.ItemCode = src.ItemCode;
                record.LineErrorMassage = src.LineErrorMassage;
                record.ListPrice = src.ListPrice;
                record.LogicalDeleteCode = src.LogicalDeleteCode;
                record.MakerFollowCnt = src.MakerFollowCnt;
                record.MakerName = src.MakerName;
                record.MazdaUOESectCd1 = src.MazdaUOESectCd1;
                record.MazdaUOESectCd2 = src.MazdaUOESectCd2;
                record.MazdaUOESectCd3 = src.MazdaUOESectCd3;
                record.MazdaUOESectCd4 = src.MazdaUOESectCd4;
                record.MazdaUOESectCd5 = src.MazdaUOESectCd5;
                record.MazdaUOESectCd6 = src.MazdaUOESectCd6;
                record.MazdaUOESectCd7 = src.MazdaUOESectCd7;
                record.MazdaUOEShipSectCd1 = src.MazdaUOEShipSectCd1;
                record.MazdaUOEShipSectCd2 = src.MazdaUOEShipSectCd2;
                record.MazdaUOEShipSectCd3 = src.MazdaUOEShipSectCd3;
                record.MazdaUOEStockCnt1 = src.MazdaUOEStockCnt1;
                record.MazdaUOEStockCnt2 = src.MazdaUOEStockCnt2;
                record.MazdaUOEStockCnt3 = src.MazdaUOEStockCnt3;
                record.MazdaUOEStockCnt4 = src.MazdaUOEStockCnt4;
                record.MazdaUOEStockCnt5 = src.MazdaUOEStockCnt5;
                record.MazdaUOEStockCnt6 = src.MazdaUOEStockCnt6;
                record.MazdaUOEStockCnt7 = src.MazdaUOEStockCnt7;
                record.NonShipmentCnt = src.NonShipmentCnt;
                record.OnlineNo = src.OnlineNo;
                record.OnlineRowNo = src.OnlineRowNo;
                record.PartsLayerCd = src.PartsLayerCd;
                record.ReceiveDate = src.ReceiveDate;
                //record.ReceiveDateAdFormal = src.ReceiveDateAdFormal;
                //record.ReceiveDateAdInFormal = src.ReceiveDateAdInFormal;
                //record.ReceiveDateJpFormal = src.ReceiveDateJpFormal;
                //record.ReceiveDateJpInFormal = src.ReceiveDateJpInFormal;
                record.ReceiveTime = src.ReceiveTime;
                record.SalesDate = src.SalesDate;
                //record.SalesDateAdFormal = src.SalesDateAdFormal;
                //record.SalesDateAdInFormal = src.SalesDateAdInFormal;
                //record.SalesDateJpFormal = src.SalesDateJpFormal;
                //record.SalesDateJpInFormal = src.SalesDateJpInFormal;
                record.SalesSlipDtlNum = src.SalesSlipDtlNum;
                record.SalesSlipNum = src.SalesSlipNum;
                record.SalesUnitCost = src.SalesUnitCost;
                record.SectionCode = src.SectionCode;
                record.SendTerminalNo = src.SendTerminalNo;
                record.SourceShipment = src.SourceShipment;
                record.StockSlipDtlNum = src.StockSlipDtlNum;
                record.SubSectionCode = src.SubSectionCode;
                record.SubstPartsNo = src.SubstPartsNo;
                record.SupplierCd = src.SupplierCd;
                record.SupplierFormal = src.SupplierFormal;
                record.SupplierSlipNo = src.SupplierSlipNo;
                record.SupplierSnm = src.SupplierSnm;
                record.SystemDivCd = src.SystemDivCd;
                record.UOECheckCode = src.UOECheckCode;
                record.UOEDeliGoodsDiv = src.UOEDeliGoodsDiv;
                record.UOEDistributionCd = src.UOEDistributionCd;
                record.UOEHMCd = src.UOEHMCd;
                record.UOEKind = src.UOEKind;
                record.UOEMarkCode = src.UOEMarkCode;
                record.UOEOtherCd = src.UOEOtherCd;
                record.UoeRemark1 = src.UoeRemark1;
                record.UoeRemark2 = src.UoeRemark2;
                record.UOEResvdSection = src.UOEResvdSection;
                record.UOEResvdSectionNm = src.UOEResvdSectionNm;
                record.UOESalesOrderNo = src.UOESalesOrderNo;
                record.UOESalesOrderRowNo = src.UOESalesOrderRowNo;
                record.UOESectionSlipNo = src.UOESectionSlipNo;
                record.UOESectOutGoodsCnt = src.UOESectOutGoodsCnt;
                record.UOESectStockCnt = src.UOESectStockCnt;
                record.UOEStockMark = src.UOEStockMark;
                record.UOESubstMark = src.UOESubstMark;
                record.UOESupplierCd = src.UOESupplierCd;
                record.UOESupplierName = src.UOESupplierName;
                record.UpdAssemblyId1 = src.UpdAssemblyId1;
                record.UpdAssemblyId2 = src.UpdAssemblyId2;
                record.UpdateDateTime = src.UpdateDateTime;
                //record.UpdateDateTimeAdFormal = src.UpdateDateTimeAdFormal;
                //record.UpdateDateTimeAdInFormal = src.UpdateDateTimeAdInFormal;
                //record.UpdateDateTimeJpFormal = src.UpdateDateTimeJpFormal;
                //record.UpdateDateTimeJpInFormal = src.UpdateDateTimeJpInFormal;
                record.UpdEmployeeCode = src.UpdEmployeeCode;
                //record.UpdEmployeeName = src.UpdEmployeeName;
                record.WarehouseCode = src.WarehouseCode;
                record.WarehouseName = src.WarehouseName;
                record.WarehouseShelfNo = src.WarehouseShelfNo;

                #endregion  // <メンバフィールドをコピー/>
            }
            return record;
        }

        #endregion  // <送受信JNL/>

        #region <単独で在庫調整データを書く実験コード/>

        /// <summary>在庫調整データ、在庫調整明細データを書込むパラメータ</summary>
        private CustomSerializeArrayList _stockAdjustDBParamList;
        /// <summary>
        /// 在庫調整データ、在庫調整明細データを書込むパラメータを取得します。
        /// </summary>
        public CustomSerializeArrayList StockAdjustDBParamList
        {
            get { return _stockAdjustDBParamList; }
        }

        #endregion  // <単独で在庫調整データを書く実験コード/>
    }
}

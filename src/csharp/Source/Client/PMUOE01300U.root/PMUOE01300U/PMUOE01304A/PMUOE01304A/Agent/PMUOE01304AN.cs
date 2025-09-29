//****************************************************************************//
// システム         : 卸商仕入受信処理
// プログラム名称   : 卸商仕入受信処理Controller
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
// 作 成 日  2010/10/19  修正内容 : 発注番号をまたがった同一仕入伝票の対応(MANTIS[0015563])
//----------------------------------------------------------------------------//
// 管理番号  10802197-00 作成担当 : 30517 夏野 駿希
// 作 成 日  K2012/06/22 修正内容 : 山形部品個別対応
//                                  手入力発注の場合、仕入データを作成しない
//----------------------------------------------------------------------------//
// 管理番号  10802197-01 作成担当 : FSI佐々木 貴英
// 作 成 日  K2012/12/11 修正内容 : 山形部品個別対応
//                                  山形部品完全個別オプション判定追加
//----------------------------------------------------------------------------//
// 管理番号  10902931-00  作成担当 : 譚洪
// 作 成 日  K2013/10/04  修正内容 : SPKにて複数拠点で発注→受信を実行すると、在庫数が更新されず、発注残も残ってしまう
//----------------------------------------------------------------------------//
// 管理番号  11601223-00  作成担当 : 陳艶丹
// 作 成 日  K2021/09/22  修正内容 : PMKOBETSU-4189 ログ追加
//----------------------------------------------------------------------------//
// 管理番号  11770181-00  作成担当 : 譚洪
// 作 成 日  2021/12/08   修正内容 : PMKOBETSU-4202 卸商仕入受信処理 データ読込改善対応
//----------------------------------------------------------------------------//
// 管理番号  11900025-00  作成担当 : 田村顕成
// 作 成 日  2023/01/20   修正内容 : PMKOBETSU-4202 卸商仕入受信処理障害対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using System.IO;//ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応

namespace Broadleaf.Application.Controller.Agent
{
    using LoginWorkerAcs = SingletonPolicy<LoginWorker>;

    // ADD K2012/12/11 START >>>>>>
    using Broadleaf.Application.Common;
    using Broadleaf.Application.Resources;
    // ADD K2012/12/11 END <<<<<<

    /// <summary>
    /// 仕入データDBの代理人クラス
    /// </summary>
    /// <remarks>
    /// <br>Update Note: PMKOBETSU-4189　ログ追加</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : K2021/09/22</br>
    /// </remarks>
    public sealed class StockDBAgent
    {
        // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------>>>>>
        /// <summary>仕入データ検索ログ</summary>
        private const string CtSearchLogDataMassage = "仕入データ検索失敗:検索条件⇒{0}";
        /// <summary>仕入データ更新ログ</summary>
        private const string CtDbLogDataMassage = "DB一括更新に失敗:電文問合せ番号={0};エラー内容={1}";
        /// <summary>仕入データ検索条件</summary>
        private const string CtSearchCondition = "拠点={0};発注先={1};UOE発注番号={2};UOE発注行番号={3};UOE種別={4}";
        /// <summary>間隔</summary>
        private const string Str_Space = "  ";
        /// <summary>ログ出力PGID</summary>
        private const string CtLogOutputPgid = "PMUOE01304A";
        /// <summary>ログ出力共通部品</summary>
        OutLogCommon LogCommon;
        /// <summary>操作履歴ログアクセス</summary>
        UoeOprtnHisLogAcs _uoeOprtnHisLogAcs = null;
        #region <電文問合せ番号>
        /// <summary>電文問合せ番号</summary>
        private string _uOESalesOrderNo = string.Empty;
        /// <summary>
        /// 電文問合せ番号を取得します。
        /// </summary>
        /// <value>電文問合せ番号</value>
        public string UOESalesOrderNo
        {
            get { return _uOESalesOrderNo; }
            set { _uOESalesOrderNo = value; } 
        }
        #endregion  // <電文問合せ番号/>

        #region <UOE発注先/>
        /// <summary>UOE発注先</summary>
        private int _uOESupplierCd = 0;
        /// <summary>
        /// UOE発注先を取得します。
        /// </summary>
        /// <value>UOE発注先</value>
        public int UOESupplierCd
        {
            get { return _uOESupplierCd; }
            set { _uOESupplierCd = value; }
        }
        #endregion  // <UOE発注先/>
        // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------<<<<<
        // ------ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応 ------>>>>>
        // 制御XMLファイル
        private const string HISLOGOUTSETTINGFILE = "PMUOE01300U_HisLogOutSetting.xml";
        // 出力制御XML
        private HisLogOutSetting HisLogOutSettingInfoWork;
        /// <summary>
        /// 操作履歴の登録、ログ出力設定
        /// </summary>
        public HisLogOutSetting HisLogOutSettingInfo
        {
            get
            {
                return this.HisLogOutSettingInfoWork;
            }
        }
        // ------ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応 ------<<<<<

        #region <Const/>

        /// <summary>
        /// UOE種別列挙体
        /// </summary>
        public enum UOEKind : int
        {
            /// <summary>UOE</summary>
            UOE = 0,
            /// <summary>卸商仕入受信</summary>
            OroshishoStockReception = 1
        }

        #endregion  // <Const/>

        #region <検索条件/>

        /// <summary>
        /// 検索条件クラス
        /// </summary>
        public sealed class SearchingCondition
        {
            #region <発注先コード/>

            /// <summary>発注先コード</summary>
            private readonly int _uoeSupplierCode;
            /// <summary>
            /// 発注先コードを取得します。
            /// </summary>
            /// <value>発注先コード</value>
            public int UOESupplierCode { get { return _uoeSupplierCode; } }

            #endregion  // <発注先コード/>

            #region <UOE発注伝票番号/>

            /// <summary>UOE発注伝票番号</summary>
            private readonly int _uoeSalesOrderNo;
            /// <summary>
            /// UOE発注伝票番号を取得します。
            /// </summary>
            /// <value>UOE発注伝票番号</value>
            public int UOESalesOrderNo { get { return _uoeSalesOrderNo; } } 

            #endregion  // <UOE発注伝票番号/>

            #region <UOE発注行番号/>

            /// <summary>UOE発注行番号</summary>
            private readonly int _uoeSalesOrderRowNo;
            /// <summary>
            /// UOE発注行番号を取得します。
            /// </summary>
            /// <value>UOE発注行番号</value>
            public int UOESalesOrderRowNo { get { return _uoeSalesOrderRowNo; } }

            #endregion  // <UOE発注行番号/>

            #region <UOE種別/>

            /// <summary>UOE種別</summary>
            private readonly int _uoeKind;
            /// <summary>
            /// UOE種別を取得します。
            /// </summary>
            /// <value>UOE種別</value>
            public int UOEKind { get { return _uoeKind; } } 

            #endregion  // <UOE種別/>

            // ---- ADD K2013/10/04 譚洪 ---- >>>>>
            //Thread中
            //拠点コード
            private const string SECTIONSOLT = "SECTIONSOLT";
            private LocalDataStoreSlot sectionSolt = null;

            #region ■列挙体
            /// <summary>
            /// オプション有効有無
            /// </summary>
            public enum Option : int
            {
                /// <summary>無効ユーザ</summary>
                OFF = 0,
                /// <summary>有効ユーザ</summary>
                ON = 1,
            }
            #endregion

            /// <summary>テキスト出力オプション情報</summary>
            private int _opt_FuTaBa;//OPT-CPM0110：フタバUOEオプション（個別）

            //専用USB用
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus fuTaBaPs;
            // ---- ADD K2013/10/04 譚洪 ---- <<<<<

            #region <Constructor/>

            /// <summary>
            /// カスタムコンストラクタ
            /// </summary>
            /// <remarks>
            /// UOE種別は<c>0</c>：UOEが設定されます。
            /// </remarks>
            /// <param name="uoeSupplierCode">発注先コード</param>
            /// <param name="uoeSalesOrderNo">UOE発注伝票番号</param>
            /// <param name="uoeSalesOrderRowNo">UOE発注行番号</param>
            public SearchingCondition(
                int uoeSupplierCode,
                int uoeSalesOrderNo,
                int uoeSalesOrderRowNo
            )
            {
                _uoeSupplierCode    = uoeSupplierCode;
                _uoeSalesOrderNo    = uoeSalesOrderNo;
                _uoeSalesOrderRowNo = uoeSalesOrderRowNo;
                _uoeKind = (int)StockDBAgent.UOEKind.UOE;
            }

            #endregion  // <Constructor/>

            /// <summary>
            /// UOE発注データ（検索条件）を生成します。
            /// </summary>
            /// <returns>UOE発注データ（検索条件）</returns>
            public UOEOrderDtlWork CreateUoeOrderDtlWork()
            {
                UOEOrderDtlWork record = new UOEOrderDtlWork();
                {
                    record.EnterpriseCode       = LoginWorkerAcs.Instance.Policy.EnterpriseProfile.Code;
                    //record.SectionCode          = LoginWorkerAcs.Instance.Policy.SectionProfile.Code;

                    // ---- ADD K2013/10/04 譚洪 ---- >>>>>
                    //OPT-CPM0110：フタバUOEオプション（個別）
                    fuTaBaPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaUOECtl);
                    if (fuTaBaPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
                    {
                        this._opt_FuTaBa = (int)Option.ON;
                    }
                    else
                    {
                        this._opt_FuTaBa = (int)Option.OFF;
                    }
                    //フタバUSB専用
                    if (this._opt_FuTaBa == (int)Option.ON)
                    {
                        sectionSolt = Thread.GetNamedDataSlot(SECTIONSOLT);
                        //Threadで、拠点がある場合、Threadの拠点を使用
                        if (Thread.GetData(sectionSolt) != null)
                        {
                            record.SectionCode = ((string)Thread.GetData(Thread.GetNamedDataSlot(SECTIONSOLT))).Trim();
                        }
                        else
                        {
                            record.SectionCode = LoginWorkerAcs.Instance.Policy.SectionProfile.Code;
                        }
                    }
                    else
                    {
                        record.SectionCode = LoginWorkerAcs.Instance.Policy.SectionProfile.Code;
                    }
                    // ---- ADD K2013/10/04 譚洪 ---- <<<<<<

                    record.UOESupplierCd        = UOESupplierCode;
                    record.UOESalesOrderNo      = UOESalesOrderNo;
                    record.UOESalesOrderRowNo   = UOESalesOrderRowNo;
                    record.UOEKind              = UOEKind;
                    record.SupplierFormal       = 2;  // 2;発注（固定）
                }
                return record;
            }
        }

        /// <summary>検索条件リスト</summary>
        private readonly IList<SearchingCondition> _searchingConditionList = new List<SearchingCondition>();
        /// <summary>
        /// 検索条件リストを取得します。
        /// </summary>
        /// <value>検索条件リスト</value>
        private IList<SearchingCondition> SearchingConditionList { get { return _searchingConditionList; } }

        /// <summary>
        /// 検索条件を追加します。
        /// </summary>
        /// <param name="uoeSupplierCode">発注先コード</param>
        /// <param name="uoeSalesOrderNo">UOE発注伝票番号</param>
        /// <param name="uoeSalesOrderRowNo">UOE発注行番号</param>
        public void AddSearchingCondition(
            int uoeSupplierCode,
            int uoeSalesOrderNo,
            int uoeSalesOrderRowNo
        )
        {
            SearchingConditionList.Add(new SearchingCondition(
                uoeSupplierCode,
                uoeSalesOrderNo,
                uoeSalesOrderRowNo
            ));
        }

        /// <summary>
        /// リモート用の検索条件リストを生成します。
        /// </summary>
        /// <returns>リモート用の検索条件リスト</returns>
        private ArrayList CreateUOEOrderDtlList()
        {
            ArrayList uoeOrderDtlList = new ArrayList();

            foreach (SearchingCondition searchingCondition in SearchingConditionList)
            {
                // 電話発注分が検索条件に混在すると、リモート側で必ず件数0とするので、無視
                if (searchingCondition.UOESalesOrderNo.Equals(ReceivedText.SALES_ORDER_NO_BY_TELEPHONE)) continue;
                
                uoeOrderDtlList.Add(searchingCondition.CreateUoeOrderDtlWork());   
            }

            return uoeOrderDtlList;
        }

        #endregion  // <検索条件/>

        #region <検索結果/>

        /// <summary>UOE仕入データ（造語）</summary>
        private UOEStockDataEssence _uoeStockData;
        /// <summary>
        /// UOE仕入データ（造語）を取得します。
        /// </summary>
        /// <value>UOE仕入データ（造語）</value>
        private UOEStockDataEssence UoeStockData { get { return _uoeStockData; } }

        #endregion  // <検索結果/>

        #region <Constructor/>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        // ------UPD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応 ------>>>>>
        //public StockDBAgent() { }
        public StockDBAgent() 
        {
            GetControlXmlInfo();
        }        
        // ------UPD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応 ------<<<<<

        #endregion  // <Constructor/>

        /// <summary>
        /// 一括取得します。
        /// </summary>
        // 2010/10/19 >>>
        //public int Search()
        /// <remarks>
        /// <br>Update Note: PMKOBETSU-4189　ログ追加</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : K2021/09/22</br>
        /// <br>Update Note: PMKOBETSU-4202 卸商仕入受信処理障害対応</br>
        /// <br>Programmer : 田村顕成</br>
        /// <br>Date       : 2023/01/20</br>
        /// </remarks>
        public int Search(IAgreegate<ReceivedText> receivedTelegramAgreegate)
        // 2010/10/19 <<<
        {
            // 1パラ目：検索条件
            ArrayList uoeOrderDtlList = CreateUOEOrderDtlList();
            object objUOEOrderDtlList = (object)uoeOrderDtlList;
            PrintSearchingCondition(uoeOrderDtlList);

            // 2パラ目：検索結果
            CustomSerializeArrayList slipGroupList = new CustomSerializeArrayList();
            object objSlipGroupList = (object)slipGroupList;

            // 一括取得
            int status = (int)Result.RemoteStatus.NotFound;
            if (uoeOrderDtlList.Count > 0)
            {
                IIOWriteUOEOdrDtlDB dbReader = MediationIOWriteUOEOdrDtlDB.GetIOWriteUOEOdrDtlDB();
                // ------DEL 2023/01/20 田村顕成 卸商仕入受信処理障害対応 ------>>>>>
                //status = dbReader.Search(
                //    ref objUOEOrderDtlList,
                //    ref objSlipGroupList,
                //    0,  // TODO: 0 固定
                //    ConstantManagement.LogicalMode.GetData0
                //);
                // ------DEL 2023/01/20 田村顕成 卸商仕入受信処理障害対応 ------<<<<<
                // ------ADD 2023/01/20 田村顕成 卸商仕入受信処理障害対応 ------>>>>>
                //山形部品個別対応(検索結果の取得方法変更 Search2 を使用)
                status = dbReader.Search2(
                    ref objUOEOrderDtlList,
                    ref objSlipGroupList,
                    0,  // TODO: 0 固定
                    ConstantManagement.LogicalMode.GetData0
                );
                // ------ADD 2023/01/20 田村顕成 卸商仕入受信処理障害対応 ------<<<<<
            }
            else
            {
                // 電話発注分のみの場合、空の検索結果を設定
                objSlipGroupList = new CustomSerializeArrayList();
            }
            if (status.Equals((int)Result.RemoteStatus.Normal) || status.Equals((int)Result.RemoteStatus.NotFound))
            {
                // 2010/10/19 >>>
                //_uoeStockData = new UOEStockDataEssence(objSlipGroupList as CustomSerializeArrayList);
                _uoeStockData = new UOEStockDataEssence(objSlipGroupList as CustomSerializeArrayList, receivedTelegramAgreegate);
                // 2010/10/19 <<<
            }
            else
            {
                Debug.Assert(status.Equals((int)Result.RemoteStatus.NotFound), "status = " + status.ToString(), "リモートでエラー発生？");
                // ------ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応 ------>>>>>
                if (HisLogOutSettingInfoWork.OutFlg)
                {
                    // ------ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応 ------<<<<<
                    // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------>>>>>
                    //操作履歴ログを登録
                    _uoeOprtnHisLogAcs = new UoeOprtnHisLogAcs();
                    string logMsg = string.Format(CtSearchLogDataMassage, GetSearchCondition(uoeOrderDtlList));
                    _uoeOprtnHisLogAcs.logd_update(this, string.Empty, string.Empty, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_END, status, logMsg, _uOESupplierCd);
                    WriteClcLogProc(CtLogOutputPgid, logMsg);
                    // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------<<<<<
                }//ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応

                return (int)Result.Code.Error;
            }

            SearchingConditionList.Clear(); // 検索条件をクリア
            return (int)Result.Code.Normal;
        }

        // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------>>>>>
        /// <summary>
        /// 検索条件を戻ります。
        /// </summary>
        /// <param name="uoeOrderDtlList">検索条件</param>
        /// <returns>stringBuilder</returns>
        /// <remarks>
        /// <br>Note:       PMKOBETSU-4189　ログ追加</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : K2021/09/22</br>
        /// </remarks>
        private string GetSearchCondition(ArrayList uoeOrderDtlList)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < uoeOrderDtlList.Count; i++)
            {
                UOEOrderDtlWork item = (UOEOrderDtlWork)uoeOrderDtlList[i];
                //検索条件を取得
                if (string.IsNullOrEmpty(stringBuilder.ToString()))
                {
                    stringBuilder.Append(string.Format(CtSearchCondition, item.SectionCode, item.UOESupplierCd, item.UOESalesOrderNo, item.UOESalesOrderRowNo, item.UOEKind));
                }
                else
                {
                    stringBuilder.Append(Str_Space);
                    stringBuilder.Append(string.Format(CtSearchCondition, item.SectionCode, item.UOESupplierCd, item.UOESalesOrderNo, item.UOESalesOrderRowNo, item.UOEKind));
                }
            }
            return stringBuilder.ToString();
        }
        // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------<<<<<

        #region <DBの排他制御用/>

        /// <summary>
        /// DBがロック中か判定します。
        /// </summary>
        /// <param name="status">リモートの処理結果</param>
        /// <returns>
        /// <c>true</c> :ロック中<br/>
        /// <c>false</c>:ロック中ではない
        /// </returns>
        private static bool IsLocked(int status)
        {
            return (
                status.Equals((int)Result.RemoteStatus.EnterpriseLock)
                    ||
                status.Equals((int)Result.RemoteStatus.SectionLock)
                    ||
                status.Equals((int)Result.RemoteStatus.WarehouseLock)
            );
        }

        #endregion <DBの排他制御用/>

        /// <summary>
        /// 一括更新します。
        /// </summary>
        /// <param name="retMsg">リモートの第2パラメータ</param>
        /// <param name="retItemInfo">リモートの第3パラメータ</param>
        /// <returns>リモートの処理結果コード</returns>
        /// <remarks>
        /// <br></br>
        /// <br>Update Note: 山形部品完全個別オプション判定追加</br>
        /// <br>Programmer : FSI佐々木 貴英</br>
        /// <br>Date       : K2012/12/11 </br>
        /// <br>Update Note: PMKOBETSU-4189　ログ追加</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : K2021/09/22</br>
        /// </remarks>
        public int Write(
            out string retMsg,
            out string retItemInfo
        )
        {
            // 1パラ目：更新条件
            CustomSerializeArrayList paraList = UoeStockData.CreateWritingData(CanWriteSumUpInformation());
            // ------ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応 ------>>>>>
            if (HisLogOutSettingInfoWork.OutFlg)
            {
                // ------ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応 ------<<<<<
                // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------>>>>>
                //操作履歴ログを登録
                _uoeOprtnHisLogAcs = new UoeOprtnHisLogAcs();
                _uoeOprtnHisLogAcs.logd_update(this, string.Empty, string.Empty, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_END, 0, UoeStockData.LogMsg, _uOESupplierCd);
                // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------<<<<<
            }//ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応

            object objParaList = (object)paraList;
            //PrintWritingCondition(SearchedResult.RealSlipGroupList);

            // 2パラ目：メッセージ
            retMsg = string.Empty;

            // 3パラ目：項目情報
            retItemInfo = string.Empty;

            // 一括更新
            IIOWriteControlDB dbWriter = (IIOWriteControlDB)MediationIOWriteControlDB.GetIOWriteControlDB();
            {
                const int SLEEP_SEC = 1000; // 1[sec]
                const int LIMITTER  = 30;   // 30回
                int retryCount = 0;

                int status = (int)Result.RemoteStatus.Normal;

                // ADD K2012/12/11 START >>>>>>
                // 山形部品完全個別オプション判定
                PurchaseStatus ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(
                    ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_YamagataCustomControl);
                // ADD K2012/12/11 END <<<<<<

                // add K2012/06/22 >>>
                // DEL K2012/12/11 START >>>>>>
                //if (!UoeStockData.DBWriteFlg)
                // DEL K2012/12/11 END <<<<<<
                // ADD K2012/12/11 START >>>>>>
                // 山形部品完全個別オプションが有効の環境で、かつUOE仕入データ.DB更新フラグが
                // false(更新しない）の場合、処理を中断する
                if ((PurchaseStatus.Contract == ps) && (!UoeStockData.DBWriteFlg))
                // ADD K2012/12/11 END <<<<<<
                    return status;
                // add K2012/06/22 <<<

                do
                {
                    if (retryCount >= LIMITTER) break;

                    status = dbWriter.Write(ref objParaList, out retMsg, out retItemInfo);

                    if (IsLocked(status))
                    {
                        Thread.Sleep(SLEEP_SEC);
                        retryCount++;
                    }
                }
                while (IsLocked(status));
                if (!status.Equals((int)Result.RemoteStatus.Normal))
                {
                    Debug.Assert(false, "DBの更新に失敗\n" + status.ToString() + "\n" + retMsg + "\n" + retItemInfo);
                    // ------ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応 ------>>>>>
                    if (HisLogOutSettingInfoWork.OutFlg)
                    {
                    // ------ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応 ------<<<<<
                        // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------>>>>>
                        //操作履歴ログを登録
                        _uoeOprtnHisLogAcs = new UoeOprtnHisLogAcs();
                        string logMsg = string.Format(CtDbLogDataMassage, _uOESalesOrderNo, retMsg);
                        _uoeOprtnHisLogAcs.logd_update(this, string.Empty, string.Empty, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_END, status, logMsg, _uOESupplierCd);
                        WriteClcLogProc(CtLogOutputPgid, logMsg);
                        // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------<<<<<
                    }//ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応
                }

                #region <単独で在庫調整データを書く実験コード/>

                //if (GetSumUpStockAdjustCount() > 0)
                //{
                //    object objParamLiat = UoeStockData.StockAdjustDBParamList;
                //    string msg = string.Empty;
                //    IStockAdjustDB stockAdjustWriter = (IStockAdjustDB)MediationStockAdjustDB.GetStockAdjustDB();
                //    {
                //        status = stockAdjustWriter.Write(ref objParamLiat, out msg);
                //        if (!status.Equals((int)Result.RemoteStatus.Normal))
                //        {
                //            Debug.Assert(false, "在庫調整DBの更新に失敗\n" + status.ToString() + "\n" + msg);
                //        }
                //    }
                //}

                #endregion  // <単独で在庫調整データを書く実験コード/>

                return status;
            }
        }

        // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------>>>>>
        /// <summary>
        /// CLCログ出力準備メソッド
        /// </summary>
        /// <param name="pgid">呼出元メソッド名</param>
        /// <param name="message">出力メッセージ本文</param>
        /// <remarks>
        /// <br>Note       : CLCログ出力共通メソッドを呼出</br>
        /// <br>Programmer : 田村顕成</br>
        /// <br>Date       : K2021/09/22</br>
        /// </remarks>
        public void WriteClcLogProc(string pgid, string message)
        {
            try
            {
                if (LogCommon == null)
                {
                    LogCommon = new OutLogCommon();
                }
                LogCommon.OutputClientLog(pgid, message, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode);
            }
            catch
            {
                // ログ出力処理のため、例外は無視する
            }
        }
        // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------<<<<<

        // ------ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応 ------>>>>>
        /// <summary>
        /// 出力制御XMLファイル取得
        /// </summary>
        /// <remarks>
        /// <br>Note         : 出力制御XMLファイル取得処理を行う</br>
        /// <br>Programmer   : 譚洪</br>
        /// <br>Date         : 2021/12/08</br>
        /// </remarks>
        public void GetControlXmlInfo()
        {
            try
            {
                HisLogOutSettingInfoWork = new HisLogOutSetting();
                if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, HISLOGOUTSETTINGFILE)))
                {
                    // XML情報を取得する
                    HisLogOutSettingInfoWork = UserSettingController.DeserializeUserSetting<HisLogOutSetting>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, HISLOGOUTSETTINGFILE));
                }
                else
                {
                    HisLogOutSettingInfoWork.OutFlg = false;
                }
            }
            catch
            {
                if (HisLogOutSettingInfoWork == null) HisLogOutSettingInfoWork = new HisLogOutSetting();
                HisLogOutSettingInfoWork.OutFlg = false;
            }
        }
        // ------ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応 ------<<<<<

        /// <summary>
        /// 計上情報を書込めるか判定します。
        /// </summary>
        /// <returns>
        /// <c>true</c> :書込める<br/>
        /// <c>false</c>:書込まれない
        /// </returns>
        private static bool CanWriteSumUpInformation()
        {
            return !LoginWorkerAcs.Instance.Policy.UOESetting.DistEnterDiv.Equals(
                (int)LoginWorker.OroshishoDistEnterDiv.Manual
            );
        }

        #region <UOE発注データ/>

        /// <summary>
        /// UOE発注データのレコードを検索します。
        /// </summary>
        /// <param name="receivedTelegram">受信電文</param>
        /// <returns>
        /// UOE発注データのレコード（検索されなかった場合、<c>null</c>を返します）
        /// </returns>
        public UOEOrderDtlWork FindUOEOrderDtlWork(ReceivedText receivedTelegram)
        {
            return UoeStockData.FindUOEOrderDtlWork(receivedTelegram);
        }

        /// <summary>
        /// UOE発注データのレコードを検索します。
        /// </summary>
        /// <param name="dtlRelationGuid">明細関連付けGUID</param>
        /// <returns>
        /// UOE発注データのレコード（検索されなかった場合、<c>null</c>を返します）
        /// </returns>
        public UOEOrderDtlWork FindUOEOrderDtlWork(Guid dtlRelationGuid)
        {
            return UoeStockData.FindUOEOrderDtlWork(dtlRelationGuid);
        }

        /// <summary>
        /// UOE発注データのレコード数を取得します。
        /// </summary>
        /// <returns>UOE発注データの明細レコード数</returns>
        public int GetUOEOrderDataCount()
        {
            return UoeStockData.GetUOEOrderDataCount();
        }

        /// <summary>
        /// UOE発注データの明細レコードを追加します。
        /// </summary>
        /// <param name="uoeOrderDtlWork">UOE発注データの明細レコード</param>
        /// <param name="pairReceivedText">対になる受信テキスト（受信電文）</param>
        public void AddUOEOrderDtlWork(
            UOEOrderDtlWork uoeOrderDtlWork,
            ReceivedText pairReceivedText
        )
        {
            UoeStockData.AddUOEOrderDtlWork(uoeOrderDtlWork, pairReceivedText);
        }

        #endregion  // <UOE発注データ/>

        #region <発注情報の仕入明細データ/>

        /// <summary>
        /// 発注情報の仕入明細データを検索します。
        /// </summary>
        /// <param name="receivedTelegram">受信電文</param>
        /// <returns>
        /// 発注情報の仕入明細データのレコード（検索されなかった場合、<c>null</c>を返します）
        /// </returns>
        public StockDetailWork FindStockDetailWork(ReceivedText receivedTelegram)
        {
            return UoeStockData.FindStockDetailWork(receivedTelegram);
        }

        /// <summary>
        /// 発注情報の仕入明細データを追加します。
        /// </summary>
        /// <param name="stockDetailWork">発注情報の仕入明細データのレコード</param>
        /// <param name="pairReceivedText">対になる受信テキスト（受信電文）</param>
        public void AddStockDetailWork(
            StockDetailWork stockDetailWork,
            ReceivedText pairReceivedText
        )
        {
            UoeStockData.AddStockDetailWork(stockDetailWork, pairReceivedText);
        }

        #endregion  // <発注情報の仕入明細データ/>

        #region <発注情報の仕入データ/>

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receivedTelegram"></param>
        /// <returns></returns>
        public StockSlipWork FindStockSlipWork(ReceivedText receivedTelegram)
        {
            return UoeStockData.FindStockSlipWork(receivedTelegram);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receivedTelegram"></param>
        /// <returns></returns>
        public string FindSupplierSlipNo(ReceivedText receivedTelegram)
        {
            return UoeStockData.FindSupplierSlipNo(receivedTelegram);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receivedTelegram"></param>
        /// <returns></returns>
        public long GetStockTotalPrice(ReceivedText receivedTelegram)
        {
            return UoeStockData.GetStockTotalPrice(receivedTelegram);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receivedTelegram"></param>
        /// <returns></returns>
        public long GetStockSubttlPrice(ReceivedText receivedTelegram)
        {
            return UoeStockData.GetStockSubttlPrice(receivedTelegram);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receivedTelegram"></param>
        /// <returns></returns>
        public int GetDetailRowCount(ReceivedText receivedTelegram)
        {
            return UoeStockData.GetDetailRowCount(receivedTelegram);
        }

        #region 一時、隠し

        ///// <summary>
        ///// 発注情報の仕入データのマップを取得します。
        ///// </summary>
        ///// <remarks>
        ///// キー：受信電文の出荷伝票番号
        ///// </remarks>
        ///// <value>発注情報の仕入データのマップ</value>
        //public IDictionary<string, OrderStockData> OrderStockDataMap
        //{
        //    get { return SearchedResult.OrderInfo.StockDataMap; }
        //}

        #endregion

        #endregion  // <発注情報の仕入データ/>

        #region <計上情報の仕入データ/>

        /// <summary>
        /// 計上情報を発注情報で初期化します。
        /// </summary>
        public void InitializeSumUpStockInformation()
        {
            UoeStockData.InitializeSumUpStockInformation();
        }

        /// <summary>
        /// 計上情報の仕入明細データのマップを取得します。
        /// </summary>
        public IDictionary<int, IList<StockDetailWork>> SumUpStockSlipDetailRecordMap
        {
            get
            {
                return UoeStockData.SumUpStockSlipDetailRecordMap;
            }
        }

        /// <summary>
        /// 計上情報の仕入データのマップを取得します。
        /// </summary>
        public IDictionary<int, StockSlipWork> SumUpStockSlipRecordMap
        {
            get
            {
                return UoeStockData.SumUpStockSlipRecordMap;
            }
        }

        /// <summary>
        /// 計上情報の仕入明細データ数を取得します。
        /// </summary>
        /// <returns>計上情報の仕入明細データ数</returns>
        public int GetSumUpStockDataCount()
        {
            int count = 0;
            {
                foreach (int supplierSlipNo in UoeStockData.SumUpStockSlipDetailRecordMap.Keys)
                {
                    // 2009/10/14 Add >>>
                    //count += UoeStockData.SumUpStockSlipDetailRecordMap[supplierSlipNo].Count;
                    foreach (StockDetailWork stockDetailWork in UoeStockData.SumUpStockSlipDetailRecordMap[supplierSlipNo])
                    {
                        if (FindUOEOrderDtlWork(stockDetailWork.DtlRelationGuid) == null) continue;

                        count++;
                    }
                    // 2009/10/14 Add <<<
                }
            }
            return count;
        }

        #endregion  // <計上情報の仕入データ/>

        #region <計上情報の在庫仕入データ/>

        /// <summary>
        /// 在庫調整情報を発注情報で初期化します。
        /// </summary>
        public void InitializeSumUpAdjustInformation()
        {
            UoeStockData.InitializeSumUpAdjustInformation();
        }

        /// <summary>
        /// 在庫調整明細データのマップを取得します。
        /// </summary>
        public IDictionary<int, IList<StockAdjustDtlWork>> SumUpStockAdjustDetailRecordMap
        {
            get
            {
                return UoeStockData.SumUpStockAdjustDetailRecordMap;
            }
        }

        /// <summary>
        /// 在庫調整データのマップを取得します。
        /// </summary>
        public IDictionary<int, StockAdjustWork> SumUpAdjustRecordMap
        {
            get
            {
                return UoeStockData.SumUpAdjustRecordMap;
            }
        }

        /// <summary>
        /// 計上情報の在庫調整明細データ数を取得します。
        /// </summary>
        /// <returns>計上情報の在庫調整明細データ数</returns>
        public int GetSumUpStockAdjustCount()
        {
            int count = 0;
            {
                foreach (int supplierSlipNo in UoeStockData.SumUpStockAdjustDetailRecordMap.Keys)
                {
                    count += UoeStockData.SumUpStockAdjustDetailRecordMap[supplierSlipNo].Count;
                }
            }
            return count;
        }

        #endregion  // <計上情報の在庫仕入データ/>

        #region <送受信JNL/>

        /// <summary>送受信JNL</summary>
        private List<OrderSndRcvJnl> _orderSndRcvJnlList;
        /// <summary>
        /// 送受信JNLを取得します。
        /// </summary>
        public List<OrderSndRcvJnl> OrderSndRcvJnlList
        {
            get
            {
                if (_orderSndRcvJnlList == null)
                {
                    _orderSndRcvJnlList = new List<OrderSndRcvJnl>();
                }
                return _orderSndRcvJnlList;
            }
        }

        /// <summary>
        /// UOE発注データを送受信JNLへコピーします。
        /// </summary>
        public void CopyUOEOrderDataToUOESendReceiveJournal()
        {
            _orderSndRcvJnlList = UoeStockData.CreateOrderSndRcvJnlList();
        }

        #endregion  // <送受信JNL/>

        #region <Debug/>

        /// <summary>
        /// 検索条件を表示します。
        /// </summary>
        /// <param name="uoeOrderDtlList">検索条件</param>
        [Conditional("DEBUG")]
        private static void PrintSearchingCondition(ArrayList uoeOrderDtlList)
        {
            const string LIST_NAME = "ArrayList<UOEOrderDtlWork>";

            for (int i = 0; i < uoeOrderDtlList.Count; i++)
            {
                UOEOrderDtlWork item = (UOEOrderDtlWork)uoeOrderDtlList[i];

                StringBuilder str = new StringBuilder();
                
                str.Append(LIST_NAME).Append("[").Append(i).Append("].SectionCode = ").Append(item.SectionCode).Append("\n");
                str.Append(LIST_NAME).Append("[").Append(i).Append("].UOESupplierCd = ").Append(item.UOESupplierCd).Append("\n");
                str.Append(LIST_NAME).Append("[").Append(i).Append("].UOESalesOrderNo = ").Append(item.UOESalesOrderNo).Append("\n");
                str.Append(LIST_NAME).Append("[").Append(i).Append("].UOESalesOrderRowNo = ").Append(item.UOESalesOrderRowNo).Append("\n");
                str.Append(LIST_NAME).Append("[").Append(i).Append("].UOEKind = ").Append(item.UOEKind).Append("\n");

                Debug.WriteLine(str.ToString());
            }
        }

        /// <summary>
        /// 更新条件を表示します。
        /// </summary>
        /// <param name="slipGroupList">更新条件</param>
        [Conditional("DEBUG")]
        private static void PrintWritingCondition(CustomSerializeArrayList slipGroupList)
        {
            StringBuilder str = new StringBuilder("[更新条件]\n");
            {
                str.Append("売上・仕入制御オプション：");
                IOWriteCtrlOptWork ioWriteCtrlOptWork = (IOWriteCtrlOptWork)slipGroupList[0];
                {
                    str.Append(ioWriteCtrlOptWork.GetType().ToString()).Append(Environment.NewLine);
                    str.Append("\t" + "CtrlStartingPoint = ").Append(ioWriteCtrlOptWork.CtrlStartingPoint).Append(Environment.NewLine);
                    str.Append("\t" + "EstimateAddUpRemDiv = ").Append(ioWriteCtrlOptWork.EstimateAddUpRemDiv).Append(Environment.NewLine);
                    str.Append("\t" + "AcpOdrrAddUpRemDiv = ").Append(ioWriteCtrlOptWork.AcpOdrrAddUpRemDiv).Append(Environment.NewLine);
                    str.Append("\t" + "ShipmAddUpRemDiv = ").Append(ioWriteCtrlOptWork.ShipmAddUpRemDiv).Append(Environment.NewLine);
                    str.Append("\t" + "RetGoodsStockEtyDiv = ").Append(ioWriteCtrlOptWork.RetGoodsStockEtyDiv).Append(Environment.NewLine);
                    str.Append("\t" + "SupplierSlipDelDiv = ").Append(ioWriteCtrlOptWork.SupplierSlipDelDiv).Append(Environment.NewLine);
                    str.Append("\t" + "RemainCntMngDiv = ").Append(ioWriteCtrlOptWork.RemainCntMngDiv).Append(Environment.NewLine);
                    str.Append("\t" + "EnterpriseCode = ").Append(ioWriteCtrlOptWork.EnterpriseCode).Append(Environment.NewLine);
                    str.Append("\t" + "CarMngDivCd = ").Append(ioWriteCtrlOptWork.CarMngDivCd).Append(Environment.NewLine);
                }

                str.Append("UOE発注データ：");
                CustomSerializeArrayList uoeOrderDataList = (CustomSerializeArrayList)slipGroupList[1];
                str.Append(uoeOrderDataList.GetType().ToString()).Append(Environment.NewLine);
                
                str.Append("UOE発注データのリスト：");
                ArrayList uoeOrderDtlWorkList = (ArrayList)uoeOrderDataList[0];
                str.Append(uoeOrderDtlWorkList.GetType().ToString()).Append(Environment.NewLine);
                for (int i = 0; i < uoeOrderDtlWorkList.Count; i++)
                {
                    UOEOrderDtlWork dtl = (UOEOrderDtlWork)uoeOrderDtlWorkList[i];

                    str.Append("\tuoeOrderDtlWorkList[").Append(i).Append("].AcceptAnOrderCnt = ").Append(dtl.AcceptAnOrderCnt).Append(Environment.NewLine);
                    str.Append("\tuoeOrderDtlWorkList[").Append(i).Append("].AcptAnOdrStatus = ").Append(dtl.AcptAnOdrStatus).Append(Environment.NewLine);

                    str.Append("\tuoeOrderDtlWorkList[").Append(i).Append("].EnterpriseCode = ").Append(dtl.EnterpriseCode).Append(Environment.NewLine);

                    str.Append("\tuoeOrderDtlWorkList[").Append(i).Append("].SectionCode = ").Append(dtl.SectionCode).Append(Environment.NewLine);
                }
            }
            Debug.WriteLine(str.ToString());
        }

        #endregion  // <Debug/>
    }

    // ------ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応 ------>>>>>
    /// <summary>
    /// 操作履歴の登録、ログ出力設定
    /// </summary>
    public class HisLogOutSetting
    {
        // 操作履歴の登録、ログ出力区分
        private bool _outFlg;

        /// <summary>
        /// 操作履歴の登録、ログ出力設定クラス
        /// </summary>
        public HisLogOutSetting()
        {

        }

        /// <summary>操作履歴の登録、ログ出力区分</summary>
        public bool OutFlg
        {
            get { return this._outFlg; }
            set { this._outFlg = value; }
        }
    }
    // ------ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応 ------<<<<<
}

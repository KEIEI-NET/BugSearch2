using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 卸商仕入回答表示　アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 卸商仕入回答表示に関するアクセス制御を行います。</br>
    /// <br>Programmer	: 渋谷 大輔</br>
    /// <br>Date		: 2008/12/16</br>
    /// <br>Programmer	: 渋谷 大輔</br>
    /// <br>Date		: 2009/01/22</br>
    /// <br>Note		: 不具合修正</br>
    /// <br>UpdateNote  : 2011/08/10 caohh 連番736</br>
    /// <br>            : NSユーザー改良要望一覧連番736の対応</br>
    /// <br>UpdateNote  : 2011/08/24 yangmj 連番736</br>
    /// <br>            : redmine #23905の対応</br>
    /// <br>UpdateNote  : 2011/09/27 21112 M.Kubota</br>
    /// <br>            : 仕入受信時間が午前中の場合に発生する障害の解除</br>
    /// </remarks>
    public class PMUOE01353AA
    {
        #region ■定数、変数、構造体

        // データ
        private const int SUPPLYANSINFO_FIRST = 0;           // 卸商仕入回答情報初期データ位置

        // HashTable
        private Hashtable _supplyAnsInfoHTable = null;       // 卸商仕入回答情報(key：INDEX)
        private Hashtable _uoeOrderDtlHTable = null;        // UOE発注先マスタ(key：UOE発注先コード)

        private string _enterpriseCode = string.Empty;      // 企業コード
        private string _sectionCode = string.Empty;         // 拠点コード
        private int _supplyAnsInfoHTableIndex = 0;           // 卸商仕入回答情報INDEX

        private IUOEAnswerLedgerOrderWorkDB _iUOEAnswerLedgerOrderWorkDB = null;      // 発注データ取得用リモートオブジェクト
       
        // ---- ADD caohh 2011/08/10 -------->>>>>
        private static Employee stc_Employee;
        private static PrtOutSet stc_PrtOutSet;			// 帳票出力設定データクラス
        private static PrtOutSetAcs stc_PrtOutSetAcs;	// 帳票出力設定アクセスクラス
        // ---- ADD caohh 2011/08/10 --------<<<<<

        #region UOEOrderDtlInfo構造体
        internal struct UOEOrderDtlInfo
        {
            private string _programId;          // 通信アセンブリID(プログラムID)
            private string _uoeSupplierName;    // UOE発注先名称

            /// <summary>
            /// 発注先マスタデータ追加
            /// </summary>
            /// <param name="programId">通信アセンブリID(プログラムID)</param>
            /// <param name="uoeSupplierName">UOE発注先名称</param>
            public void Add(string programId, string uoeSupplierName)
            {
                _programId = programId;
                _uoeSupplierName = uoeSupplierName;
            }
            /// <summary> 通信アセンブリID(プログラムID) </summary>
            public string ProgramId
            {
                get { return _programId; }
            }
            /// <summary> UOE発注先名称 </summary>
            public string UOESupplierName
            {
                get { return _uoeSupplierName; }
            }

        }
        #endregion
        #endregion ■定数、変数、構造体 - end

        # region ■Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 各種HashTable用データの取得を行います。</br>
        /// <br>Programmer	: 渋谷 大輔</br>
        /// <br>Date		: 2008/12/16</br>
        /// </remarks>
        public PMUOE01353AA(List<OrderSndRcvJnl> orderSndRcvJnlList, string enterpriseCode, string sectionCode)
        {
            // 企業コード
            this._enterpriseCode = enterpriseCode;

            // 拠点コード
            this._sectionCode = sectionCode;

            // ---- ADD caohh 2011/08/10 -------->>>>>
            stc_Employee = null;
            stc_PrtOutSet = null;					// 帳票出力設定データクラス
            stc_PrtOutSetAcs = new PrtOutSetAcs();	// 帳票出力設定アクセスクラス

            // ログイン拠点取得
            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            if (loginEmployee != null)
            {
                stc_Employee = loginEmployee.Clone();
            }
            // ---- ADD caohh 2011/08/10 --------<<<<<

            // UOE発注先マスタ
            this.CreateUOEOrderDtlHTable();

            if (orderSndRcvJnlList == null)
            {
                // リモートオブジェクト取得
                this._iUOEAnswerLedgerOrderWorkDB = (IUOEAnswerLedgerOrderWorkDB)MediationUOEAnswerLedgerOrderWorkDB.GetUOEAnswerLedgerOrderWorkDB();

                this._supplyAnsInfoHTable = null;
            }
            else
            {
                // UOE送受信ジャーナルデータ
                this.CreateOrderAnsInfoHTable(orderSndRcvJnlList);
            }
        }
        # endregion ■Constructor - end

        #region ■Publicメソッド
        #region ▼SearchFirst(初回検索)
        /// <summary>
        /// 初期表示データ取得(単体起動以外時)
        /// </summary>
        /// <param name="supplierDataSet">グリッド明細以外(ヘッダー、グリッドヘッダー)のデータ</param>
        /// <param name="detailDataSet">グリッド明細</param>
        /// <returns>True：成功、False：失敗</returns>
        /// <remarks>
        /// <br>Note       : 初期表示用データを取得します。 ※SearchBefore、SearchNextの前に呼び出す必要があります。</br>
        /// <br>Programmer	: 渋谷 大輔</br>
        /// <br>Date		: 2008/12/16</br>
        /// </remarks>
        public bool SearchFirst(out DataSet supplierDataSet, out DataSet detailDataSet)
        {
            // 初回以外の呼び出しはNG
            if (this._supplyAnsInfoHTableIndex != -1)
            {
                supplierDataSet = null;
                detailDataSet = null;
                return false;
            }

            bool status = this.GetDispInfoAll(SUPPLYANSINFO_FIRST, out supplierDataSet, out detailDataSet);
            return status;
        }

        /// <summary>
        /// 初期表示データ取得(単体起動専用)
        /// </summary>
        /// <param name="uoeAnswerLedgerOrderCndtn">発注データ抽出条件</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>True：成功、False：失敗</returns>
        /// <remarks>
        /// <br>Note       : 初期表示用データを取得します。 ※SearchBefore、SearchNextの前に呼び出す必要があります。</br>
        /// <br>Programmer	: 渋谷 大輔</br>
        /// <br>Date		: 2008/12/16</br>
        /// </remarks>
        public bool SearchFirst(UOEAnswerLedgerOrderCndtn uoeAnswerLedgerOrderCndtn, out string errorMsg)
        {
            List<OrderSndRcvJnl> orderSndRcvJnlList = null;

            // 発注データ抽出
            bool status = this.CreateOrderSndRcvJnl(uoeAnswerLedgerOrderCndtn, out errorMsg, out orderSndRcvJnlList);
            if (status == true)
            {
                // 抽出データを元にHashTableを作成
                this.CreateOrderAnsInfoHTable(orderSndRcvJnlList);
            }

            return status;
        }
        #endregion

        #region ▼SearchBefore(前データ検索)
        /// <summary>
        /// 前データ取得
        /// </summary>
        /// <param name="supplierDataSet">グリッド明細以外(ヘッダー、グリッドヘッダー)のデータ</param>
        /// <param name="detailDataSet">グリッド明細</param>
        /// <returns>True：成功、False：失敗</returns>
        /// <remarks>
        /// <br>Note       : 現在選択されているデータの1つ前のデータを取得します。データが無い場合はfalseが返ります。</br>
        /// <br>Programmer	: 渋谷 大輔</br>
        /// <br>Date		: 2008/12/16</br>
        /// </remarks>
        public bool SearchBefore(out DataSet supplierDataSet, out DataSet detailDataSet)
        {
            // 1つ前のデータを取得
            bool status = this.GetDispInfoAll(this._supplyAnsInfoHTableIndex - 1, out supplierDataSet, out detailDataSet);
            return status;
        }
        #endregion

        #region ▼SearchNext(次データ検索)
        /// <summary>
        /// 次データ取得
        /// </summary>
        /// <param name="supplierDataSet">グリッド明細以外(ヘッダー、グリッドヘッダー)のデータ</param>
        /// <param name="detailDataSet">グリッド明細</param>
        /// <returns>True：成功、False：失敗</returns>
        /// <remarks>
        /// <br>Note       : 現在選択されているデータの1つ後のデータを取得します。データが無い場合はfalseが返ります。</br>
        /// <br>Programmer	: 渋谷 大輔</br>
        /// <br>Date		: 2008/12/16</br>
        /// </remarks>
        public bool SearchNext(out DataSet supplierDataSet, out DataSet detailDataSet)
        {
            // 1つ後のデータを取得
            bool status = this.GetDispInfoAll(this._supplyAnsInfoHTableIndex + 1, out supplierDataSet, out detailDataSet);
            return status;
        }
        #endregion

        #region ▼ExistsUOESupplierCd(UOE発注先マスタ存在チェック　単体起動専用)
        /// <summary>
        /// UOE発注先マスタ存在チェック
        /// </summary>
        /// <param name="uoeSupplierCd">UOE発注先コード</param>
        /// <returns>True：存在、False：未存在</returns>
        /// <remarks>
        /// <br>Note       : UOE発注先コードがUOE発注先マスタに登録されているかチェックを行います。</br>
        /// <br>Programmer	: 渋谷 大輔</br>
        /// <br>Date		: 2008/12/16</br>
        /// </remarks>
        public bool ExistsUOESupplierCd(int uoeSupplierCd)
        {
            if (this._uoeOrderDtlHTable == null)
            {
                return false;
            }

            if (this._uoeOrderDtlHTable.ContainsKey(uoeSupplierCd) == false)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region ▼GetUOESupplierName(UOE発注先名称取得　単体起動専用)
        /// <summary>
        /// UOE発注先名称取得
        /// </summary>
        /// <param name="uoeSupplierCd">UOE発注先コード</param>
        /// <returns>UOE発注先名称</returns>
        /// <remarks>
        /// <br>Note       : UOE発注先コードを元にUOE発注先名称を取得します。</br>
        /// <br>Programmer	: 渋谷 大輔</br>
        /// <br>Date		: 2008/12/16</br>
        /// </remarks>
        public string GetUOESupplierName(int uoeSupplierCd)
        {
            return this.GetUOESupplierNameFromUOEOrderDtlHTable(uoeSupplierCd);
        }
        #endregion

        // ---- ADD caohh 2011/08/10 --------->>>>>
        #region 帳票出力設定取得処理
        /// <summary>
        /// 帳票出力設定読込
        /// </summary>
        /// <param name="retPrtOutSet">帳票出力設定データクラス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 自拠点の帳票出力設定の読込を行います。</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/07/21</br>
        /// </remarks>
        public static int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
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
        #endregion
        // ---- ADD caohh 2011/08/10 ---------<<<<<

        #endregion ■Publicメソッド - end

        #region ■Privateメソッド
        #region ◆グリッドヘッダーHashTable関連


        #endregion ◆グリッドヘッダーHashTable関連 - end

        #region ◆UOE発注先マスタHashTable関連
        #region ▼CreateUOEOrderDtlHTable(HashTable作成)
        /// <summary>
        /// UOE発注先マスタHashTable作成
        /// </summary>
        /// <remarks>
        /// <br>Note       : UOE発注先マスタを元にHashTableを作成します。</br>
        /// <br>Programmer	: 渋谷 大輔</br>
        /// <br>Date		: 2008/12/16</br>
        /// </remarks>
        private void CreateUOEOrderDtlHTable()
        {
            DataSet retDataSet = new DataSet();

            // UOE発注先マスタデータ取得(PMUOE09022A)
            UOESupplierAcs uoeSupplierAcs = new UOESupplierAcs();
            int status = uoeSupplierAcs.Search(ref retDataSet, this._enterpriseCode, this._sectionCode);

            // 異常
            if (status != 0)
            {
                this._uoeOrderDtlHTable = null;
                return;
            }
            // データなし
            if (retDataSet == null)
            {
                this._uoeOrderDtlHTable = null;
                return;
            }

            // HashTable作成
            this._uoeOrderDtlHTable = new Hashtable();
            foreach (DataRow dataRow in retDataSet.Tables[retDataSet.Tables[0].TableName].Rows)
            {
                int key = 0;
                int.TryParse(dataRow["UoeSupplierCd"].ToString(), out key);

                UOEOrderDtlInfo uoeOrderDtlInfo = new UOEOrderDtlInfo();
                uoeOrderDtlInfo.Add(dataRow["CommAssemblyId"].ToString(), dataRow["UOESupplierName"].ToString());

                this._uoeOrderDtlHTable[key] = uoeOrderDtlInfo;
            }
        }
        #endregion


        #region  ▼GetUOESupplierNameFromUOEOrderDtlHTable(UOE発注先名称取得)
        /// <summary>
        /// UOE発注先名称取得
        /// </summary>
        /// <param name="uoeSupplierCd">UOE発注先コード</param>
        /// <returns>UOE発注先名称</returns>
        /// <remarks>
        /// <br>Note       : UOE発注先コードを元にUOE発注先マスタHashTableからUOE発注先名称を取得します。</br>
        /// <br>Programmer	: 渋谷 大輔</br>
        /// <br>Date		: 2008/12/16</br>
        /// </remarks>
        private string GetUOESupplierNameFromUOEOrderDtlHTable(int uoeSupplierCd)
        {
            string uoeSupplierName = string.Empty;

            // データが無い
            if (this._uoeOrderDtlHTable == null)
            {
                return uoeSupplierName;
            }

            // INDEX範囲外
            if (this._uoeOrderDtlHTable.ContainsKey(uoeSupplierCd) == false)
            {
                return uoeSupplierName;
            }

            UOEOrderDtlInfo uoeOrderDtlInfo = (UOEOrderDtlInfo)this._uoeOrderDtlHTable[uoeSupplierCd];

            uoeSupplierName = uoeOrderDtlInfo.UOESupplierName;
            return uoeSupplierName;
        }
        #endregion
        #endregion ◆UOE発注先マスタHashTable関連 - end

        #region ◆卸商仕入回答情報HashTable関連
        #region ▼CreateOrderAnsInfoHTable(HashTable作成)
        /// <summary>
        /// 卸商仕入回答情報HashTable作成
        /// </summary>
        /// <param name="orderSndRcvJnlList">UOE送受信ジャーナル(発注)リスト</param>
        /// <remarks>
        /// <br>Note       : 渡されたUOE送受信ジャーナル(発注)リストをUOE発注先、UOE発注番号単位にまとめてHashTableに格納します。</br>
        /// <br>Programmer	: 渋谷 大輔</br>
        /// <br>Date		: 2008/12/16</br>
        /// </remarks>
        private void CreateOrderAnsInfoHTable(List<OrderSndRcvJnl> orderSndRcvJnlList)
        {
            string bfKey = string.Empty;
            int listCnt = 0;
            int hashTableCnt = 0;
            List<OrderSndRcvJnl> orderAnsInfoListGroup = new List<OrderSndRcvJnl>();

            this._supplyAnsInfoHTable = new Hashtable();
            foreach (OrderSndRcvJnl orderSndRcvJnl in orderSndRcvJnlList)
            {
                // キー：UOE発注先-オンライン番号
                // 2009/01/22 UPD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //string key = orderSndRcvJnl.UOESupplierCd + "-" + orderSndRcvJnl.UOESalesOrderNo;
                string key = orderSndRcvJnl.UOESupplierCd + "-" + orderSndRcvJnl.OnlineNo;
                // 2009/01/22 UPD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                if ((bfKey != key) && (bfKey != string.Empty))
                {
                    // 最初以外でキーが変わった時
                    // UOE発注先,発注番号単位にまとめたデータをHashTableに追加
                    this._supplyAnsInfoHTable[hashTableCnt] = orderAnsInfoListGroup;
                    hashTableCnt++;

                    // 初期化
                    orderAnsInfoListGroup = new List<OrderSndRcvJnl>();
                    listCnt = 0;
                }

                orderAnsInfoListGroup.Add(orderSndRcvJnl);
                listCnt++;

                bfKey = key;
            }

            // 最後のデータをHashTableに追加
            this._supplyAnsInfoHTable[hashTableCnt] = orderAnsInfoListGroup;

            // 初期位置
            this._supplyAnsInfoHTableIndex = -1;
        }
        #endregion

        #region ▼GetDispInfoAll(HashTableデータ取得)
        /// <summary>
        /// 発注回答情報HashTableデータ取得
        /// </summary>
        /// <param name="index">検索位置</param>
        /// <param name="supplierDataSet">グリッド明細以外(ヘッダー、グリッドヘッダー、合計)のデータ</param>
        /// <param name="detailDataSet">グリッド明細データ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 指定されたindexを元に発注回答情報HashTableからデータを取得します。</br>
        /// <br>Programmer	: 渋谷 大輔</br>
        /// <br>Date		: 2008/12/16</br>
        /// <br>UpdateNote  : 2011/08/24 yangmj</br>
        /// <br>            : redmine #23905の対応</br>
        /// </remarks>
        private bool GetDispInfoAll(int index, out DataSet supplierDataSet, out DataSet detailDataSet)
        {
            detailDataSet = null;
            supplierDataSet = null;

            // データが無い
            if (this._supplyAnsInfoHTable == null)
            {
                return false;
            }

            // INDEX範囲外
            if (this._supplyAnsInfoHTable.ContainsKey(index) == false)
            {
                return false;
            }
             
            // 明細用DataTable作成
            DataTable detailDataTable = null;
            PMUOE01352EA.CreateDataTableDetail(ref detailDataTable);

            List<OrderSndRcvJnl> orderSndRcvJnlList = (List<OrderSndRcvJnl>)this._supplyAnsInfoHTable[index];
            // ------ADD 2011/08/24----->>>>>
            string beReceiveDateYMD = string.Empty;
            string beReceiveTime = string.Empty;
            int cnt = 0;
            // ------ADD 2011/08/24-----<<<<<
            foreach (OrderSndRcvJnl orderSndRcvJnl in orderSndRcvJnlList)
            {
                // dataRow作成
                DataRow detailDataRow = detailDataTable.NewRow();

                //this.CopyToDataRowFromOrderSndRcvJnl(orderSndRcvJnl, ref detailDataRow);// DEL 2011/08/24
                this.CopyToDataRowFromOrderSndRcvJnl(orderSndRcvJnl, ref detailDataRow, ref beReceiveDateYMD, ref beReceiveTime, ref cnt);// ADD 2011/08/24

                detailDataTable.Rows.Add(detailDataRow);
            }

            detailDataSet = new DataSet();
            detailDataSet.Tables.Add(detailDataTable);

            this._supplyAnsInfoHTableIndex = index;      // 現在の位置
            return true;
        }
        #endregion

        #region ▼CopyToDataRowFromOrderSndRcvJnl(UOE送受信ジャーナル→DataRowコピー)
        /// <summary>
        /// UOE送受信ジャーナル(発注)→DataRow作成
        /// </summary>
        /// <param name="dataRow"></param>
        /// <param name="orderSndRcvJnl"></param>
        /// <remarks>
        /// <br>Note       : UOE送受信ジャーナル(発注)の内容を元にDataRowを作成します。</br>
        /// <br>Programmer	: 渋谷 大輔</br>
        /// <br>Date		: 2008/12/16</br>
        /// <br>UpdateNote  : 2011/08/24 yangmj</br>
        /// <br>            : redmine #23905の対応</br>
        /// </remarks>
        //private void CopyToDataRowFromOrderSndRcvJnl(OrderSndRcvJnl orderSndRcvJnl, ref DataRow dataRow, ref string beReceiveDateYMD)// DEL 2011/08/24
        private void CopyToDataRowFromOrderSndRcvJnl(OrderSndRcvJnl orderSndRcvJnl, ref DataRow dataRow, ref string beReceiveDateYMD, ref string beReceiveTime, ref int cnt)// ADD 2011/08/24
        {
            dataRow[PMUOE01352EA.ct_Col_UOESalesOrderNo] = orderSndRcvJnl.UOESalesOrderNo;              // UOE発注番号
            dataRow[PMUOE01352EA.ct_Col_UOESalesOrderRowNo] = orderSndRcvJnl.UOESalesOrderRowNo;        // UOE発注行番号
            dataRow[PMUOE01352EA.ct_Col_ReceiveDate] = orderSndRcvJnl.ReceiveDate.ToShortDateString();   // 受信日
            // ---- ADD caohh 2011/08/10 -------->>>>>
            // ------UPD 2011/08/24----->>>>>
            string receiveDateYMD = TDateTime.DateTimeToString("YY/MM/DD", orderSndRcvJnl.ReceiveDate);  // 受信日(YY/MM/DD)
            //string receiveTime = orderSndRcvJnl.ReceiveTime.ToString().Substring(0, 2) + ":" + orderSndRcvJnl.ReceiveTime.ToString().Substring(2, 2) + ":" + orderSndRcvJnl.ReceiveTime.ToString().Substring(4, 2); // 受信時刻  //DEL 2011/09/27 M.Kubota
            
            //--- ADD 2011/09/27 M.Kubota --->>>
            // 前述の処理方法では、時間が１桁の場合に全部で５文字となり Substring で例外が発生する
            int hh = (int)(orderSndRcvJnl.ReceiveTime / 10000); // 時
            int mm = orderSndRcvJnl.ReceiveTime / 100 % 100;    // 分
            int ss = orderSndRcvJnl.ReceiveTime % 100;          // 秒
            string receiveTime = string.Format("{0}:{1}:{2}", hh, mm, ss);  // 受信時刻
            //--- ADD 2011/09/27 M.Kubota ---<<<
            
            if (string.IsNullOrEmpty(beReceiveDateYMD) || string.IsNullOrEmpty(beReceiveTime))
            {
                beReceiveDateYMD = receiveDateYMD;
                beReceiveTime = receiveTime;
                dataRow[PMUOE01352EA.ct_Col_ReceiveDateYMD] = receiveDateYMD;
                dataRow[PMUOE01352EA.ct_Col_ReceiveTime] = receiveTime;
            }
            else if (beReceiveDateYMD.Equals(receiveDateYMD) && beReceiveTime.Equals(receiveTime))
            {
                if (cnt % 10 != 0)
                {
                    dataRow[PMUOE01352EA.ct_Col_ReceiveDateYMD] = string.Empty;
                    dataRow[PMUOE01352EA.ct_Col_ReceiveTime] = string.Empty;
                }
                else
                {
                    dataRow[PMUOE01352EA.ct_Col_ReceiveDateYMD] = receiveDateYMD;
                    dataRow[PMUOE01352EA.ct_Col_ReceiveTime] = receiveTime;
                }
            }
            else
            {
                beReceiveDateYMD = receiveDateYMD;
                beReceiveTime = receiveTime;
                dataRow[PMUOE01352EA.ct_Col_ReceiveDateYMD] = receiveDateYMD;
                dataRow[PMUOE01352EA.ct_Col_ReceiveTime] = receiveTime;
            }
            cnt++;
            //dataRow[PMUOE01352EA.ct_Col_ReceiveDateYMD] = TDateTime.DateTimeToString("YY/MM/DD", orderSndRcvJnl.ReceiveDate);  // 受信日(YY/MM/DD)
            //dataRow[PMUOE01352EA.ct_Col_ReceiveTime] = orderSndRcvJnl.ReceiveTime.ToString().Substring(0, 2) + ":" + orderSndRcvJnl.ReceiveTime.ToString().Substring(2, 2) + ":" + orderSndRcvJnl.ReceiveTime.ToString().Substring(4, 2); // 受信時刻
            // ------UPD 2011/08/24-----<<<<<
            // 納品区分名称
            dataRow[PMUOE01352EA.ct_Col_DeliveredGoodsDivNm] = orderSndRcvJnl.UOEDeliGoodsDiv;
            // メーカーコード
            dataRow[PMUOE01352EA.ct_Col_GoodsMakerCd] = orderSndRcvJnl.GoodsMakerCd == 0 ? string.Empty : orderSndRcvJnl.GoodsMakerCd.ToString();
            // ---- ADD caohh 2011/08/10 --------<<<<<
            dataRow[PMUOE01352EA.ct_Col_GoodsNo] = orderSndRcvJnl.GoodsNo;                              // 品番
            dataRow[PMUOE01352EA.ct_Col_AnswerpartsName] = orderSndRcvJnl.AnswerPartsName;              // 回答品名
            dataRow[PMUOE01352EA.ct_Col_AnswerSalesUnitCost] = orderSndRcvJnl.AnswerSalesUnitCost;      // 回答原価単価
            dataRow[PMUOE01352EA.ct_Col_UOESectionSlipNo] = orderSndRcvJnl.UOESectionSlipNo;            // UOE拠点伝票番号
            dataRow[PMUOE01352EA.ct_Col_UOECheckCode] = orderSndRcvJnl.UOECheckCode;                    // UOEチェックコード
            dataRow[PMUOE01352EA.ct_Col_UoeRemark1] = orderSndRcvJnl.UoeRemark1;                        // UOEリマーク1
            dataRow[PMUOE01352EA.ct_Col_AnswerpartsNo] = orderSndRcvJnl.AnswerPartsNo;                  // 回答品番
            dataRow[PMUOE01352EA.ct_Col_AcceptAnOrderCnt] = orderSndRcvJnl.AcceptAnOrderCnt;            // 受注数量
            dataRow[PMUOE01352EA.ct_Col_AnswerListPrice] = orderSndRcvJnl.AnswerListPrice;              // 回答定価
            dataRow[PMUOE01352EA.ct_Col_UOESectOutGoodsCnt] = orderSndRcvJnl.UOESectOutGoodsCnt;        // UOE拠点出庫数
            // 2009/01/22 UPD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // 残の表示を"未出庫数"→"受注数量-UOE拠点出庫数"に変更
            //dataRow[PMUOE01352EA.ct_Col_NonShipmentCnt] = orderSndRcvJnl.NonShipmentCnt;                // 未出庫数
            dataRow[PMUOE01352EA.ct_Col_NonShipmentCnt] = orderSndRcvJnl.AcceptAnOrderCnt - orderSndRcvJnl.UOESectOutGoodsCnt;
                                                                                                        // 受注数量-UOE拠点出庫数
            // 2009/01/22  UPD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            dataRow[PMUOE01352EA.ct_Col_LineErrorMessage] = orderSndRcvJnl.LineErrorMassage;            // ラインエラーメッセージ

            // UOE納品区分
            dataRow[PMUOE01352EA.ct_Col_DeliGoodsDiv] = orderSndRcvJnl.DeliveredGoodsDivNm;

            // メーカーコード
            if (orderSndRcvJnl.GoodsMakerCd == 0)
            {
                dataRow[PMUOE01352EA.ct_Col_MakerName] = string.Empty;
            }
            else
            {
                dataRow[PMUOE01352EA.ct_Col_MakerName] = orderSndRcvJnl.MakerName;
            }
        }
        #endregion
        #endregion ◆発注回答情報HashTable関連 - end

        #region ◆発注データ→OrderSndRcvJnl作成関連(単体起動専用)
        #region ▼CreateOrderSndRcvJnl(UOE送受信ジャーナル(発注)作成　単体起動専用)
        /// <summary>
        /// UOE送受信ジャーナル作成(単体起動専用)
        /// </summary>
        /// <param name="uoeAnswerLedgerOrderCndtn">発注データ抽出条件</param>
        /// <param name="errorMsg">エラーメッセージ</param>
        /// <param name="orderSndRcvJnlList">UOE送受信ジャーナル</param>
        /// <returns>True：成功、False：失敗</returns>
        /// <remarks>
        /// <br>Note       : 抽出条件を元に発注データを取得後、UOE送受信ジャーナルを作成します。</br>
        /// <br>Programmer	: 渋谷 大輔</br>
        /// <br>Date		: 2008/12/16</br>
        /// </remarks>
        private bool CreateOrderSndRcvJnl(UOEAnswerLedgerOrderCndtn uoeAnswerLedgerOrderCndtn, out string errorMsg, out List<OrderSndRcvJnl> orderSndRcvJnlList)
        {
            errorMsg = string.Empty;
            orderSndRcvJnlList = new List<OrderSndRcvJnl>();

            // 抽出条件
            UOEAnswerLedgerOrderCndtnWork uoeAnswerLedgerOrderCndtnWork = new UOEAnswerLedgerOrderCndtnWork();
            uoeAnswerLedgerOrderCndtnWork.EnterpriseCode = uoeAnswerLedgerOrderCndtn.EnterpriseCode;        // 企業コード
            uoeAnswerLedgerOrderCndtnWork.SectionCode = uoeAnswerLedgerOrderCndtn.SectionCode;              // 拠点コード
            uoeAnswerLedgerOrderCndtnWork.SystemDivCd = uoeAnswerLedgerOrderCndtn.SystemDivCd;              // システム区分(-1：全て 固定)
            uoeAnswerLedgerOrderCndtnWork.St_ReceiveDate = uoeAnswerLedgerOrderCndtn.St_ReceiveDate;        // 開始発注日
            uoeAnswerLedgerOrderCndtnWork.Ed_ReceiveDate = uoeAnswerLedgerOrderCndtn.Ed_ReceiveDate;        // 終了発注日
            uoeAnswerLedgerOrderCndtnWork.UOESupplierCd = uoeAnswerLedgerOrderCndtn.UOESupplierCd;          // 発注先
            uoeAnswerLedgerOrderCndtnWork.UOEKind = uoeAnswerLedgerOrderCndtn.UOEKind;                      // UOE種別(1:卸商仕入受信)
            uoeAnswerLedgerOrderCndtnWork.St_InputDay = uoeAnswerLedgerOrderCndtn.St_InputDay;              // 開始入力日
            uoeAnswerLedgerOrderCndtnWork.Ed_InputDay = uoeAnswerLedgerOrderCndtn.Ed_InputDay;              // 終了入力日

            // データ抽出            
            Object arrayList = null;
            int status = this._iUOEAnswerLedgerOrderWorkDB.Search(out arrayList, (object)uoeAnswerLedgerOrderCndtnWork, 0, ConstantManagement.LogicalMode.GetDataAll);
            //@@int status = this.TestSearch(out arrayList, (object)uoeAnswerLedgerOrderCndtnWork, 0, ConstantManagement.LogicalMode.GetDataAll);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        errorMsg = "該当データがありません";
                        return false;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                default:
                    errorMsg = "発注データの読込に失敗しました。";
                    return false;
            }

            // 発注データをUOE送受信ジャーナル用のListにセット
            foreach (UOEAnswerLedgerResultWork uoeAnswerLedgerResultWork in (ArrayList)arrayList)
            {
                OrderSndRcvJnl orderSndRcvJnl;

                this.CopyToOrderSndRcvJnlFromUOEAnswerLedgerResultWork(uoeAnswerLedgerResultWork, out orderSndRcvJnl);

                orderSndRcvJnlList.Add(orderSndRcvJnl);
            }


            return true;
        }
        #endregion

        #region test
        private int TestSearch(out object uOEAnswerLedgerResultWork, object uOEAnswerLedgerOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            ArrayList al = new ArrayList();

            #region 抽出結果-値セット0

            #region 抽出結果-値セット0-1
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork01 = new UOEAnswerLedgerResultWork();
            //格納項目
            _UOEAnswerLedgerResultWork01.SectionCode = "99";
            _UOEAnswerLedgerResultWork01.SectionGuideSnm = "テスト拠点";
            _UOEAnswerLedgerResultWork01.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork01.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork01.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            //_UOEAnswerLedgerResultWork01.FileHeaderGuid = 
            _UOEAnswerLedgerResultWork01.UpdEmployeeCode = "1234";
            //_UOEAnswerLedgerResultWork01.UpdAssemblyId1 = 
            //_UOEAnswerLedgerResultWork01.UpdAssemblyId2 = 
            _UOEAnswerLedgerResultWork01.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork01.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork01.UOESalesOrderNo = 1001;
            _UOEAnswerLedgerResultWork01.UOESalesOrderRowNo = 0;
            //_UOEAnswerLedgerResultWork01.SendTerminalNo = 
            //_UOEAnswerLedgerResultWork01.UOESupplierCd = 
            //_UOEAnswerLedgerResultWork01.UOESupplierName = 
            //_UOEAnswerLedgerResultWork01.CommAssemblyId = 
            //_UOEAnswerLedgerResultWork01.OnlineNo = 
            //_UOEAnswerLedgerResultWork01.OnlineRowNo = 
            //_UOEAnswerLedgerResultWork01.SalesDate = 
            //_UOEAnswerLedgerResultWork01.InputDay = 
            //_UOEAnswerLedgerResultWork01.DataUpdateDateTime = 
            //_UOEAnswerLedgerResultWork01.UOEKind = 
            //_UOEAnswerLedgerResultWork01.SubSectionCode = 
            //_UOEAnswerLedgerResultWork01.CustomerCode = 
            //_UOEAnswerLedgerResultWork01.CustomerSnm = 
            //_UOEAnswerLedgerResultWork01.CashRegisterNo = 
            //_UOEAnswerLedgerResultWork01.BoCode = 
            _UOEAnswerLedgerResultWork01.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork01.DeliveredGoodsDivNm = "区分名";
            //_UOEAnswerLedgerResultWork01.FollowDeliGoodsDiv = 
            //_UOEAnswerLedgerResultWork01.FollowDeliGoodsDivNm = 
            //_UOEAnswerLedgerResultWork01.UOEResvdSection = 
            //_UOEAnswerLedgerResultWork01.UOEResvdSectionNm = 
            //_UOEAnswerLedgerResultWork01.EmployeeCode = 
            //_UOEAnswerLedgerResultWork01.EmployeeName = 
            _UOEAnswerLedgerResultWork01.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork01.MakerName = "渋谷部品901234567890";
            _UOEAnswerLedgerResultWork01.GoodsNo = "30009-123456test";
            //_UOEAnswerLedgerResultWork01.GoodsNoNoneHyphen = 
            //_UOEAnswerLedgerResultWork01.GoodsName = "ねじ";
            //_UOEAnswerLedgerResultWork01.WarehouseCode = 
            //_UOEAnswerLedgerResultWork01.WarehouseName = 
            //_UOEAnswerLedgerResultWork01.WarehouseShelfNo = 
            _UOEAnswerLedgerResultWork01.AcceptAnOrderCnt = 120;
            //_UOEAnswerLedgerResultWork01.ListPrice = 
            //_UOEAnswerLedgerResultWork01.SalesUnitCost = 
            //_UOEAnswerLedgerResultWork01.SupplierCd = 
            //_UOEAnswerLedgerResultWork01.SupplierSnm = 
            _UOEAnswerLedgerResultWork01.UoeRemark1 = "りまーくん1";
            //_UOEAnswerLedgerResultWork01.UoeRemark2 = 
            _UOEAnswerLedgerResultWork01.ReceiveDate = DateTime.Now;
            //_UOEAnswerLedgerResultWork01.ReceiveTime = 
            //_UOEAnswerLedgerResultWork01.AnswerMakerCd = 
            _UOEAnswerLedgerResultWork01.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork01.AnswerPartsName = "ねぎ";
            //_UOEAnswerLedgerResultWork01.SubstPartsNo = 
            _UOEAnswerLedgerResultWork01.UOESectOutGoodsCnt = 113;
            //_UOEAnswerLedgerResultWork01.BOShipmentCnt1 = 
            //_UOEAnswerLedgerResultWork01.BOShipmentCnt2 = 
            //_UOEAnswerLedgerResultWork01.BOShipmentCnt3 = 
            //_UOEAnswerLedgerResultWork01.MakerFollowCnt = 
            _UOEAnswerLedgerResultWork01.NonShipmentCnt = 12;
            //_UOEAnswerLedgerResultWork01.UOESectStockCnt = 
            //_UOEAnswerLedgerResultWork01.BOStockCount1 = 
            //_UOEAnswerLedgerResultWork01.BOStockCount2 = 
            //_UOEAnswerLedgerResultWork01.BOStockCount3 = 
            _UOEAnswerLedgerResultWork01.UOESectionSlipNo = "10011";
            //_UOEAnswerLedgerResultWork01.BOSlipNo1 = 
            //_UOEAnswerLedgerResultWork01.BOSlipNo2 = 
            //_UOEAnswerLedgerResultWork01.BOSlipNo3 = 
            //_UOEAnswerLedgerResultWork01.EOAlwcCount = 
            //_UOEAnswerLedgerResultWork01.BOManagementNo = 
            _UOEAnswerLedgerResultWork01.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork01.AnswerSalesUnitCost = 1200;
            //_UOEAnswerLedgerResultWork01.UOESubstMark = 
            //_UOEAnswerLedgerResultWork01.UOEStockMark = 
            //_UOEAnswerLedgerResultWork01.PartsLayerCd = 
            //_UOEAnswerLedgerResultWork01.MazdaUOEShipSectCd1 = 
            //_UOEAnswerLedgerResultWork01.MazdaUOEShipSectCd2 = 
            //_UOEAnswerLedgerResultWork01.MazdaUOEShipSectCd3 = 
            //_UOEAnswerLedgerResultWork01.MazdaUOESectCd1 = 
            //_UOEAnswerLedgerResultWork01.MazdaUOESectCd2 = 
            //_UOEAnswerLedgerResultWork01.MazdaUOESectCd3 = 
            //_UOEAnswerLedgerResultWork01.MazdaUOESectCd4 = 
            //_UOEAnswerLedgerResultWork01.MazdaUOESectCd5 = 
            //_UOEAnswerLedgerResultWork01.MazdaUOESectCd6 = 
            //_UOEAnswerLedgerResultWork01.MazdaUOESectCd7 = 
            //_UOEAnswerLedgerResultWork01.MazdaUOEStockCnt1 = 
            //_UOEAnswerLedgerResultWork01.MazdaUOEStockCnt2 = 
            //_UOEAnswerLedgerResultWork01.MazdaUOEStockCnt3 = 
            //_UOEAnswerLedgerResultWork01.MazdaUOEStockCnt4 = 
            //_UOEAnswerLedgerResultWork01.MazdaUOEStockCnt5 = 
            //_UOEAnswerLedgerResultWork01.MazdaUOEStockCnt6 = 
            //_UOEAnswerLedgerResultWork01.MazdaUOEStockCnt7 = 
            //_UOEAnswerLedgerResultWork01.UOEDistributionCd = 
            //_UOEAnswerLedgerResultWork01.UOEOtherCd = 
            //_UOEAnswerLedgerResultWork01.UOEHMCd = 
            //_UOEAnswerLedgerResultWork01.BOCount = 
            //_UOEAnswerLedgerResultWork01.UOEMarkCode = 
            //_UOEAnswerLedgerResultWork01.SourceShipment = 
            //_UOEAnswerLedgerResultWork01.ItemCode = 
            _UOEAnswerLedgerResultWork01.UOECheckCode = "check";
            //_UOEAnswerLedgerResultWork01.HeadErrorMassage = 
            _UOEAnswerLedgerResultWork01.LineErrorMassage = "ラインエラーメッセージ";
            al.Add(_UOEAnswerLedgerResultWork01);
            #endregion

            #region 抽出結果-値セット0-2
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork02 = new UOEAnswerLedgerResultWork();
            //格納項目
            _UOEAnswerLedgerResultWork02.SectionCode = "99";
            _UOEAnswerLedgerResultWork02.SectionGuideSnm = "テスト拠点";
            _UOEAnswerLedgerResultWork02.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork02.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork02.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork02.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork02.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork02.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork02.UOESalesOrderNo = 1001;
            _UOEAnswerLedgerResultWork02.UOESalesOrderRowNo = 1;
            _UOEAnswerLedgerResultWork02.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork02.DeliveredGoodsDivNm = "区分名";
            _UOEAnswerLedgerResultWork02.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork02.MakerName = "渋谷部品901234567890";
            _UOEAnswerLedgerResultWork02.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork02.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork02.UoeRemark1 = "りまーくん1";
            _UOEAnswerLedgerResultWork02.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork02.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork02.AnswerPartsName = "ねぎ";
            _UOEAnswerLedgerResultWork02.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork02.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork02.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork02.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork02.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork02.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork02.LineErrorMassage = "ラインエラーメッセージ";
            al.Add(_UOEAnswerLedgerResultWork02);
            #endregion

            #region 抽出結果-値セット0-3
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork03 = new UOEAnswerLedgerResultWork();
            //格納項目
            _UOEAnswerLedgerResultWork03.SectionCode = "99";
            _UOEAnswerLedgerResultWork03.SectionGuideSnm = "テスト拠点";
            _UOEAnswerLedgerResultWork03.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork03.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork03.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork03.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork03.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork03.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork03.UOESalesOrderNo = 1001;
            _UOEAnswerLedgerResultWork03.UOESalesOrderRowNo = 2;
            _UOEAnswerLedgerResultWork03.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork03.DeliveredGoodsDivNm = "区分名";
            _UOEAnswerLedgerResultWork03.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork03.MakerName = "渋谷部品901234567890";
            _UOEAnswerLedgerResultWork03.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork03.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork03.UoeRemark1 = "りまーくん1";
            _UOEAnswerLedgerResultWork03.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork03.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork03.AnswerPartsName = "たまねぎ";
            _UOEAnswerLedgerResultWork03.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork03.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork03.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork03.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork03.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork03.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork03.LineErrorMassage = "ラインエラーメッセージ";
            al.Add(_UOEAnswerLedgerResultWork03);
            #endregion

            #region 抽出結果-値セット0-4
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork04 = new UOEAnswerLedgerResultWork();
            //格納項目
            _UOEAnswerLedgerResultWork04.SectionCode = "99";
            _UOEAnswerLedgerResultWork04.SectionGuideSnm = "テスト拠点";
            _UOEAnswerLedgerResultWork04.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork04.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork04.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork04.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork04.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork04.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork04.UOESalesOrderNo = 1001;
            _UOEAnswerLedgerResultWork04.UOESalesOrderRowNo = 3;
            _UOEAnswerLedgerResultWork04.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork04.DeliveredGoodsDivNm = "区分名";
            _UOEAnswerLedgerResultWork04.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork04.MakerName = "渋谷部品901234567890";
            _UOEAnswerLedgerResultWork04.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork04.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork04.UoeRemark1 = "りまーくん1";
            _UOEAnswerLedgerResultWork04.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork04.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork04.AnswerPartsName = "ねぎ";
            _UOEAnswerLedgerResultWork04.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork04.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork04.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork04.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork04.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork04.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork04.LineErrorMassage = "ラインエラーメッセージ";
            al.Add(_UOEAnswerLedgerResultWork04);
            #endregion

            #region 抽出結果-値セット0-5
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork05 = new UOEAnswerLedgerResultWork();
            //格納項目
            _UOEAnswerLedgerResultWork05.SectionCode = "99";
            _UOEAnswerLedgerResultWork05.SectionGuideSnm = "テスト拠点";
            _UOEAnswerLedgerResultWork05.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork05.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork05.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork05.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork05.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork05.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork05.UOESalesOrderNo = 1001;
            _UOEAnswerLedgerResultWork05.UOESalesOrderRowNo = 4;
            _UOEAnswerLedgerResultWork05.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork05.DeliveredGoodsDivNm = "区分名";
            _UOEAnswerLedgerResultWork05.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork05.MakerName = "渋谷部品901234567890";
            _UOEAnswerLedgerResultWork05.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork05.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork05.UoeRemark1 = "りまーくん1";
            _UOEAnswerLedgerResultWork05.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork05.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork05.AnswerPartsName = "たまねぎ";
            _UOEAnswerLedgerResultWork05.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork05.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork05.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork05.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork05.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork05.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork05.LineErrorMassage = "ラインエラーメッセージ";
            al.Add(_UOEAnswerLedgerResultWork05);
            #endregion

            #region 抽出結果-値セット0-6
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork06 = new UOEAnswerLedgerResultWork();
            //格納項目
            _UOEAnswerLedgerResultWork06.SectionCode = "99";
            _UOEAnswerLedgerResultWork06.SectionGuideSnm = "テスト拠点";
            _UOEAnswerLedgerResultWork06.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork06.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork06.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork06.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork06.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork06.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork06.UOESalesOrderNo = 1001;
            _UOEAnswerLedgerResultWork06.UOESalesOrderRowNo = 5;
            _UOEAnswerLedgerResultWork06.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork06.DeliveredGoodsDivNm = "区分名";
            _UOEAnswerLedgerResultWork06.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork06.MakerName = "渋谷部品901234567890";
            _UOEAnswerLedgerResultWork06.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork06.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork06.UoeRemark1 = "りまーくん1";
            _UOEAnswerLedgerResultWork06.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork06.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork06.AnswerPartsName = "ねぎ";
            _UOEAnswerLedgerResultWork06.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork06.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork06.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork06.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork06.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork06.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork06.LineErrorMassage = "ラインエラーメッセージ";
            al.Add(_UOEAnswerLedgerResultWork06);
            #endregion

            #region 抽出結果-値セット0-7
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork07 = new UOEAnswerLedgerResultWork();
            //格納項目
            _UOEAnswerLedgerResultWork07.SectionCode = "99";
            _UOEAnswerLedgerResultWork07.SectionGuideSnm = "テスト拠点";
            _UOEAnswerLedgerResultWork07.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork07.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork07.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork07.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork07.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork07.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork07.UOESalesOrderNo = 1001;
            _UOEAnswerLedgerResultWork07.UOESalesOrderRowNo = 6;
            _UOEAnswerLedgerResultWork07.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork07.DeliveredGoodsDivNm = "区分名";
            _UOEAnswerLedgerResultWork07.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork07.MakerName = "渋谷部品901234567890";
            _UOEAnswerLedgerResultWork07.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork07.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork07.UoeRemark1 = "りまーくん1";
            _UOEAnswerLedgerResultWork07.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork07.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork07.AnswerPartsName = "たまねぎ";
            _UOEAnswerLedgerResultWork07.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork07.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork07.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork07.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork07.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork07.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork07.LineErrorMassage = "ラインエラーメッセージ";
            al.Add(_UOEAnswerLedgerResultWork07);
            #endregion

            #region 抽出結果-値セット0-8
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork08 = new UOEAnswerLedgerResultWork();
            //格納項目
            _UOEAnswerLedgerResultWork08.SectionCode = "99";
            _UOEAnswerLedgerResultWork08.SectionGuideSnm = "テスト拠点";
            _UOEAnswerLedgerResultWork08.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork08.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork08.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork08.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork08.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork08.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork08.UOESalesOrderNo = 1001;
            _UOEAnswerLedgerResultWork08.UOESalesOrderRowNo = 7;
            _UOEAnswerLedgerResultWork08.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork08.DeliveredGoodsDivNm = "区分名";
            _UOEAnswerLedgerResultWork08.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork08.MakerName = "渋谷部品901234567890";
            _UOEAnswerLedgerResultWork08.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork08.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork08.UoeRemark1 = "りまーくん1";
            _UOEAnswerLedgerResultWork08.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork08.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork08.AnswerPartsName = "ねぎ";
            _UOEAnswerLedgerResultWork08.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork08.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork08.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork08.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork08.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork08.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork08.LineErrorMassage = "ラインエラーメッセージ";
            al.Add(_UOEAnswerLedgerResultWork08);
            #endregion

            #region 抽出結果-値セット0-9
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork09 = new UOEAnswerLedgerResultWork();
            //格納項目
            _UOEAnswerLedgerResultWork09.SectionCode = "99";
            _UOEAnswerLedgerResultWork09.SectionGuideSnm = "テスト拠点";
            _UOEAnswerLedgerResultWork09.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork09.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork09.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork09.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork09.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork09.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork09.UOESalesOrderNo = 1001;
            _UOEAnswerLedgerResultWork09.UOESalesOrderRowNo = 8;
            _UOEAnswerLedgerResultWork09.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork09.DeliveredGoodsDivNm = "区分名";
            _UOEAnswerLedgerResultWork09.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork09.MakerName = "渋谷部品901234567890";
            _UOEAnswerLedgerResultWork09.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork09.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork09.UoeRemark1 = "りまーくん1";
            _UOEAnswerLedgerResultWork09.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork09.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork09.AnswerPartsName = "たまねぎ";
            _UOEAnswerLedgerResultWork09.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork09.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork09.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork09.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork09.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork09.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork09.LineErrorMassage = "ラインエラーメッセージ";
            al.Add(_UOEAnswerLedgerResultWork09);
            #endregion

            #region 抽出結果-値セット0-10
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork0A = new UOEAnswerLedgerResultWork();
            //格納項目
            _UOEAnswerLedgerResultWork0A.SectionCode = "99";
            _UOEAnswerLedgerResultWork0A.SectionGuideSnm = "テスト拠点";
            _UOEAnswerLedgerResultWork0A.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork0A.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork0A.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork0A.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork0A.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork0A.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork0A.UOESalesOrderNo = 1001;
            _UOEAnswerLedgerResultWork0A.UOESalesOrderRowNo = 9;
            _UOEAnswerLedgerResultWork0A.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork0A.DeliveredGoodsDivNm = "区分名";
            _UOEAnswerLedgerResultWork0A.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork0A.MakerName = "渋谷部品901234567890";
            _UOEAnswerLedgerResultWork0A.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork0A.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork0A.UoeRemark1 = "りまーくん1";
            _UOEAnswerLedgerResultWork0A.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork0A.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork0A.AnswerPartsName = "たまねぎ";
            _UOEAnswerLedgerResultWork0A.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork0A.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork0A.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork0A.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork0A.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork0A.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork0A.LineErrorMassage = "ラインエラーメッセージ";
            al.Add(_UOEAnswerLedgerResultWork0A);
            #endregion

            #region 抽出結果-値セット0-11
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork0B = new UOEAnswerLedgerResultWork();
            //格納項目
            _UOEAnswerLedgerResultWork0B.SectionCode = "99";
            _UOEAnswerLedgerResultWork0B.SectionGuideSnm = "テスト拠点";
            _UOEAnswerLedgerResultWork0B.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork0B.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork0B.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork0B.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork0B.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork0B.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork0B.UOESalesOrderNo = 1001;
            _UOEAnswerLedgerResultWork0B.UOESalesOrderRowNo = 10;
            _UOEAnswerLedgerResultWork0B.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork0B.DeliveredGoodsDivNm = "区分名";
            _UOEAnswerLedgerResultWork0B.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork0B.MakerName = "渋谷部品901234567890";
            _UOEAnswerLedgerResultWork0B.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork0B.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork0B.UoeRemark1 = "りまーくん1";
            _UOEAnswerLedgerResultWork0B.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork0B.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork0B.AnswerPartsName = "ねぎ";
            _UOEAnswerLedgerResultWork0B.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork0B.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork0B.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork0B.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork0B.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork0B.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork0B.LineErrorMassage = "ラインエラーメッセージ";
            al.Add(_UOEAnswerLedgerResultWork0B);
            #endregion

            #region 抽出結果-値セット0-12
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork0C = new UOEAnswerLedgerResultWork();
            //格納項目
            _UOEAnswerLedgerResultWork0C.SectionCode = "99";
            _UOEAnswerLedgerResultWork0C.SectionGuideSnm = "テスト拠点";
            _UOEAnswerLedgerResultWork0C.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork0C.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork0C.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork0C.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork0C.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork0C.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork0C.UOESalesOrderNo = 1001;
            _UOEAnswerLedgerResultWork0C.UOESalesOrderRowNo = 11;
            _UOEAnswerLedgerResultWork0C.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork0C.DeliveredGoodsDivNm = "区分名";
            _UOEAnswerLedgerResultWork0C.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork0C.MakerName = "渋谷部品901234567890";
            _UOEAnswerLedgerResultWork0C.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork0C.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork0C.UoeRemark1 = "りまーくん1";
            _UOEAnswerLedgerResultWork0C.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork0C.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork0C.AnswerPartsName = "たまねぎ";
            _UOEAnswerLedgerResultWork0C.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork0C.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork0C.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork0C.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork0C.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork0C.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork0C.LineErrorMassage = "ラインエラーメッセージ";
            al.Add(_UOEAnswerLedgerResultWork0C);
            #endregion
            #endregion

            #region 抽出結果-値セット1

            #region 抽出結果-値セット1-1
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork11 = new UOEAnswerLedgerResultWork();
            //格納項目
            _UOEAnswerLedgerResultWork11.SectionCode = "99";
            _UOEAnswerLedgerResultWork11.SectionGuideSnm = "テスト拠点";
            _UOEAnswerLedgerResultWork11.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork11.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork11.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork11.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork11.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork11.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork11.UOESalesOrderNo = 1002;
            _UOEAnswerLedgerResultWork11.UOESalesOrderRowNo = 0;
            _UOEAnswerLedgerResultWork11.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork11.DeliveredGoodsDivNm = "区分名";
            _UOEAnswerLedgerResultWork11.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork11.MakerName = "渋谷部品901234567890";
            _UOEAnswerLedgerResultWork11.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork11.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork11.UoeRemark1 = "りまーくん2";
            _UOEAnswerLedgerResultWork11.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork11.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork11.AnswerPartsName = "ぬるぽ";
            _UOEAnswerLedgerResultWork11.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork11.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork11.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork11.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork11.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork11.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork11.LineErrorMassage = "ラインエラーメッセージ";
            al.Add(_UOEAnswerLedgerResultWork11);
            #endregion

            #region 抽出結果-値セット1-2
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork12 = new UOEAnswerLedgerResultWork();
            //格納項目
            _UOEAnswerLedgerResultWork12.SectionCode = "99";
            _UOEAnswerLedgerResultWork12.SectionGuideSnm = "テスト拠点";
            _UOEAnswerLedgerResultWork12.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork12.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork12.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork12.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork12.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork12.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork12.UOESalesOrderNo = 1002;
            _UOEAnswerLedgerResultWork12.UOESalesOrderRowNo = 1;
            _UOEAnswerLedgerResultWork12.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork12.DeliveredGoodsDivNm = "区分名";
            _UOEAnswerLedgerResultWork12.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork12.MakerName = "渋谷部品901234567890";
            _UOEAnswerLedgerResultWork12.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork12.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork12.UoeRemark1 = "りまーくん1";
            _UOEAnswerLedgerResultWork12.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork12.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork12.AnswerPartsName = "ぬるぽ";
            _UOEAnswerLedgerResultWork12.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork12.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork12.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork12.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork12.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork12.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork12.LineErrorMassage = "ラインエラーメッセージ";
            al.Add(_UOEAnswerLedgerResultWork12);
            #endregion

            #region 抽出結果-値セット1-3
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork13 = new UOEAnswerLedgerResultWork();
            //格納項目
            _UOEAnswerLedgerResultWork13.SectionCode = "99";
            _UOEAnswerLedgerResultWork13.SectionGuideSnm = "テスト拠点";
            _UOEAnswerLedgerResultWork13.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork13.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork13.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork13.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork13.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork13.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork13.UOESalesOrderNo = 1002;
            _UOEAnswerLedgerResultWork13.UOESalesOrderRowNo = 2;
            _UOEAnswerLedgerResultWork13.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork13.DeliveredGoodsDivNm = "区分名";
            _UOEAnswerLedgerResultWork13.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork13.MakerName = "渋谷部品901234567890";
            _UOEAnswerLedgerResultWork13.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork13.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork13.UoeRemark1 = "りまーくん1";
            _UOEAnswerLedgerResultWork13.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork13.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork13.AnswerPartsName = "ぬるぽ";
            _UOEAnswerLedgerResultWork13.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork13.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork13.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork13.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork13.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork13.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork13.LineErrorMassage = "ラインエラーメッセージ";
            al.Add(_UOEAnswerLedgerResultWork13);
            #endregion

            #region 抽出結果-値セット1-4
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork14 = new UOEAnswerLedgerResultWork();
            //格納項目
            _UOEAnswerLedgerResultWork14.SectionCode = "99";
            _UOEAnswerLedgerResultWork14.SectionGuideSnm = "テスト拠点";
            _UOEAnswerLedgerResultWork14.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork14.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork14.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork14.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork14.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork14.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork14.UOESalesOrderNo = 1002;
            _UOEAnswerLedgerResultWork14.UOESalesOrderRowNo = 3;
            _UOEAnswerLedgerResultWork14.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork14.DeliveredGoodsDivNm = "区分名";
            _UOEAnswerLedgerResultWork14.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork14.MakerName = "渋谷部品901234567890";
            _UOEAnswerLedgerResultWork14.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork14.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork14.UoeRemark1 = "りまーくん1";
            _UOEAnswerLedgerResultWork14.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork14.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork14.AnswerPartsName = "ぬるぽ";
            _UOEAnswerLedgerResultWork14.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork14.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork14.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork14.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork14.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork14.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork14.LineErrorMassage = "ラインエラーメッセージ";
            al.Add(_UOEAnswerLedgerResultWork14);
            #endregion

            #region 抽出結果-値セット1-5
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork15 = new UOEAnswerLedgerResultWork();
            //格納項目
            _UOEAnswerLedgerResultWork15.SectionCode = "99";
            _UOEAnswerLedgerResultWork15.SectionGuideSnm = "テスト拠点";
            _UOEAnswerLedgerResultWork15.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork15.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork15.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork15.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork15.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork15.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork15.UOESalesOrderNo = 1002;
            _UOEAnswerLedgerResultWork15.UOESalesOrderRowNo = 4;
            _UOEAnswerLedgerResultWork15.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork15.DeliveredGoodsDivNm = "区分名";
            _UOEAnswerLedgerResultWork15.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork15.MakerName = "渋谷部品901234567890";
            _UOEAnswerLedgerResultWork15.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork15.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork15.UoeRemark1 = "りまーくん1";
            _UOEAnswerLedgerResultWork15.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork15.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork15.AnswerPartsName = "ぬるぽ";
            _UOEAnswerLedgerResultWork15.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork15.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork15.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork15.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork15.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork15.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork15.LineErrorMassage = "ラインエラーメッセージ";
            al.Add(_UOEAnswerLedgerResultWork15);
            #endregion

            #region 抽出結果-値セット1-6
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork16 = new UOEAnswerLedgerResultWork();
            //格納項目
            _UOEAnswerLedgerResultWork16.SectionCode = "99";
            _UOEAnswerLedgerResultWork16.SectionGuideSnm = "テスト拠点";
            _UOEAnswerLedgerResultWork16.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork16.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork16.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork16.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork16.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork16.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork16.UOESalesOrderNo = 1002;
            _UOEAnswerLedgerResultWork16.UOESalesOrderRowNo = 5;
            _UOEAnswerLedgerResultWork16.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork16.DeliveredGoodsDivNm = "区分名";
            _UOEAnswerLedgerResultWork16.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork16.MakerName = "渋谷部品901234567890";
            _UOEAnswerLedgerResultWork16.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork16.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork16.UoeRemark1 = "りまーくん1";
            _UOEAnswerLedgerResultWork16.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork16.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork16.AnswerPartsName = "ぬるぽ";
            _UOEAnswerLedgerResultWork16.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork16.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork16.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork16.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork16.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork16.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork16.LineErrorMassage = "ラインエラーメッセージ";
            al.Add(_UOEAnswerLedgerResultWork16);
            #endregion

            #region 抽出結果-値セット1-7
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork17 = new UOEAnswerLedgerResultWork();
            //格納項目
            _UOEAnswerLedgerResultWork17.SectionCode = "99";
            _UOEAnswerLedgerResultWork17.SectionGuideSnm = "テスト拠点";
            _UOEAnswerLedgerResultWork17.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork17.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork17.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork17.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork17.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork17.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork17.UOESalesOrderNo = 1002;
            _UOEAnswerLedgerResultWork17.UOESalesOrderRowNo = 6;
            _UOEAnswerLedgerResultWork17.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork17.DeliveredGoodsDivNm = "区分名";
            _UOEAnswerLedgerResultWork17.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork17.MakerName = "渋谷部品901234567890";
            _UOEAnswerLedgerResultWork17.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork17.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork17.UoeRemark1 = "りまーくん1";
            _UOEAnswerLedgerResultWork17.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork17.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork17.AnswerPartsName = "ぬるぽ";
            _UOEAnswerLedgerResultWork17.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork17.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork17.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork17.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork17.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork17.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork17.LineErrorMassage = "ラインエラーメッセージ";
            al.Add(_UOEAnswerLedgerResultWork17);
            #endregion

            #region 抽出結果-値セット1-8
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork18 = new UOEAnswerLedgerResultWork();
            //格納項目
            _UOEAnswerLedgerResultWork18.SectionCode = "99";
            _UOEAnswerLedgerResultWork18.SectionGuideSnm = "テスト拠点";
            _UOEAnswerLedgerResultWork18.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork18.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork18.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork18.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork18.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork18.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork18.UOESalesOrderNo = 1002;
            _UOEAnswerLedgerResultWork18.UOESalesOrderRowNo = 7;
            _UOEAnswerLedgerResultWork18.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork18.DeliveredGoodsDivNm = "区分名";
            _UOEAnswerLedgerResultWork18.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork18.MakerName = "渋谷部品901234567890";
            _UOEAnswerLedgerResultWork18.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork18.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork18.UoeRemark1 = "りまーくん1";
            _UOEAnswerLedgerResultWork18.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork18.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork18.AnswerPartsName = "ぬるぽ";
            _UOEAnswerLedgerResultWork18.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork18.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork18.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork18.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork18.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork18.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork18.LineErrorMassage = "ラインエラーメッセージ";
            al.Add(_UOEAnswerLedgerResultWork18);
            #endregion

            #region 抽出結果-値セット1-9
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork19 = new UOEAnswerLedgerResultWork();
            //格納項目
            _UOEAnswerLedgerResultWork19.SectionCode = "99";
            _UOEAnswerLedgerResultWork19.SectionGuideSnm = "テスト拠点";
            _UOEAnswerLedgerResultWork19.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork19.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork19.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork19.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork19.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork19.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork19.UOESalesOrderNo = 1002;
            _UOEAnswerLedgerResultWork19.UOESalesOrderRowNo = 8;
            _UOEAnswerLedgerResultWork19.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork19.DeliveredGoodsDivNm = "区分名";
            _UOEAnswerLedgerResultWork19.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork19.MakerName = "渋谷部品901234567890";
            _UOEAnswerLedgerResultWork19.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork19.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork19.UoeRemark1 = "りまーくん1";
            _UOEAnswerLedgerResultWork19.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork19.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork19.AnswerPartsName = "ぬるぽ";
            _UOEAnswerLedgerResultWork19.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork19.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork19.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork19.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork19.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork19.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork19.LineErrorMassage = "ラインエラーメッセージ";
            al.Add(_UOEAnswerLedgerResultWork19);
            #endregion

            #region 抽出結果-値セット1-10
            UOEAnswerLedgerResultWork _UOEAnswerLedgerResultWork1A = new UOEAnswerLedgerResultWork();
            //格納項目
            _UOEAnswerLedgerResultWork1A.SectionCode = "99";
            _UOEAnswerLedgerResultWork1A.SectionGuideSnm = "テスト拠点";
            _UOEAnswerLedgerResultWork1A.CreateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork1A.UpdateDateTime = DateTime.Now;
            _UOEAnswerLedgerResultWork1A.EnterpriseCode = ((UOEAnswerLedgerOrderCndtnWork)uOEAnswerLedgerOrderCndtnWork).EnterpriseCode;
            _UOEAnswerLedgerResultWork1A.UpdEmployeeCode = "1234";
            _UOEAnswerLedgerResultWork1A.LogicalDeleteCode = 0;
            _UOEAnswerLedgerResultWork1A.SystemDivCd = 0;
            _UOEAnswerLedgerResultWork1A.UOESalesOrderNo = 1002;
            _UOEAnswerLedgerResultWork1A.UOESalesOrderRowNo = 9;
            _UOEAnswerLedgerResultWork1A.UOEDeliGoodsDiv = "1";
            _UOEAnswerLedgerResultWork1A.DeliveredGoodsDivNm = "区分名";
            _UOEAnswerLedgerResultWork1A.GoodsMakerCd = 1986;
            _UOEAnswerLedgerResultWork1A.MakerName = "渋谷部品901234567890";
            _UOEAnswerLedgerResultWork1A.GoodsNo = "30009-123456test";
            _UOEAnswerLedgerResultWork1A.AcceptAnOrderCnt = 120;
            _UOEAnswerLedgerResultWork1A.UoeRemark1 = "りまーくん1";
            _UOEAnswerLedgerResultWork1A.ReceiveDate = DateTime.Now;
            _UOEAnswerLedgerResultWork1A.AnswerPartsNo = "30009-123456testANS";
            _UOEAnswerLedgerResultWork1A.AnswerPartsName = "ぬるぽ";
            _UOEAnswerLedgerResultWork1A.UOESectOutGoodsCnt = 113;
            _UOEAnswerLedgerResultWork1A.NonShipmentCnt = 12;
            _UOEAnswerLedgerResultWork1A.UOESectionSlipNo = "10011";
            _UOEAnswerLedgerResultWork1A.AnswerListPrice = 1500;
            _UOEAnswerLedgerResultWork1A.AnswerSalesUnitCost = 1200;
            _UOEAnswerLedgerResultWork1A.UOECheckCode = "check";
            _UOEAnswerLedgerResultWork1A.LineErrorMassage = "ラインエラーメッセージ";
            al.Add(_UOEAnswerLedgerResultWork1A);
            #endregion
            #endregion

            uOEAnswerLedgerResultWork = al;
            return 0;
        }
        #endregion


        #region ▼CopyToOrderSndRcvJnlFromUOEAnswerLedgerResultWork(発注データ→UOE送受信ジャーナルコピー　単体起動専用)
        /// <summary>
        /// 発注データ→UOE送受信ジャーナルコピー(単体起動専用)
        /// </summary>
        /// <param name="uoeAnswerLedgerResultWork">発注データ</param>
        /// <param name="orderSndRcvJnl">UOE送受信ジャーナル</param>
        /// <remarks>
        /// <br>Note       : 発注データの内容を元にUOE送受信ジャーナル(発注)を作成します。</br>
        /// <br>Programmer	: 渋谷 大輔</br>
        /// <br>Date		: 2008/12/16</br>
        /// </remarks>
        private void CopyToOrderSndRcvJnlFromUOEAnswerLedgerResultWork(UOEAnswerLedgerResultWork uoeAnswerLedgerResultWork, out OrderSndRcvJnl orderSndRcvJnl)
        {
            orderSndRcvJnl = new OrderSndRcvJnl();
            orderSndRcvJnl.CreateDateTime = uoeAnswerLedgerResultWork.CreateDateTime;                   // 作成日時
            orderSndRcvJnl.UpdateDateTime = uoeAnswerLedgerResultWork.UpdateDateTime;                   // 更新日時
            orderSndRcvJnl.EnterpriseCode = uoeAnswerLedgerResultWork.EnterpriseCode;                   // 企業コード
            orderSndRcvJnl.FileHeaderGuid = uoeAnswerLedgerResultWork.FileHeaderGuid;                   // GUID
            orderSndRcvJnl.UpdEmployeeCode = uoeAnswerLedgerResultWork.UpdEmployeeCode;                 // 更新従業員コード
            orderSndRcvJnl.UpdAssemblyId1 = uoeAnswerLedgerResultWork.UpdAssemblyId1;                   // 更新アセンブリID1
            orderSndRcvJnl.UpdAssemblyId2 = uoeAnswerLedgerResultWork.UpdAssemblyId2;                   // 更新アセンブリID2
            orderSndRcvJnl.LogicalDeleteCode = uoeAnswerLedgerResultWork.LogicalDeleteCode;             // 論理削除区分
            orderSndRcvJnl.SystemDivCd = uoeAnswerLedgerResultWork.SystemDivCd;                         // システム区分
            orderSndRcvJnl.UOESalesOrderNo = uoeAnswerLedgerResultWork.UOESalesOrderNo;                 // UOE発注番号
            orderSndRcvJnl.UOESalesOrderRowNo = uoeAnswerLedgerResultWork.UOESalesOrderRowNo;           // UOE発注行番号
            orderSndRcvJnl.SendTerminalNo = uoeAnswerLedgerResultWork.SendTerminalNo;                   // 送信端末番号
            orderSndRcvJnl.UOESupplierCd = uoeAnswerLedgerResultWork.UOESupplierCd;                     // UOE発注先コード
            orderSndRcvJnl.UOESupplierName = uoeAnswerLedgerResultWork.UOESupplierName;                 // UOE発注先名称
            orderSndRcvJnl.CommAssemblyId = uoeAnswerLedgerResultWork.CommAssemblyId;                   // 通信アセンブリID
            orderSndRcvJnl.OnlineNo = uoeAnswerLedgerResultWork.OnlineNo;                               // オンライン番号
            orderSndRcvJnl.OnlineRowNo = uoeAnswerLedgerResultWork.OnlineRowNo;                         // オンライン行番号
            orderSndRcvJnl.SalesDate = uoeAnswerLedgerResultWork.SalesDate;                             // 売上日付
            orderSndRcvJnl.InputDay = uoeAnswerLedgerResultWork.InputDay;                               // 入力日
            orderSndRcvJnl.DataUpdateDateTime = uoeAnswerLedgerResultWork.DataUpdateDateTime;           // データ更新日時
            orderSndRcvJnl.UOEKind = uoeAnswerLedgerResultWork.UOEKind;                                 // UOE種別
            orderSndRcvJnl.SectionCode = uoeAnswerLedgerResultWork.SectionCode;                         // 拠点コード
            orderSndRcvJnl.SubSectionCode = uoeAnswerLedgerResultWork.SubSectionCode;                   // 部門コード
            orderSndRcvJnl.CustomerCode = uoeAnswerLedgerResultWork.CustomerCode;                       // 得意先コード
            orderSndRcvJnl.CustomerSnm = uoeAnswerLedgerResultWork.CustomerSnm;                         // 得意先略称
            orderSndRcvJnl.CashRegisterNo = uoeAnswerLedgerResultWork.CashRegisterNo;                   // レジ番号
            orderSndRcvJnl.BoCode = uoeAnswerLedgerResultWork.BoCode;                                   // BO区分
            orderSndRcvJnl.UOEDeliGoodsDiv = uoeAnswerLedgerResultWork.UOEDeliGoodsDiv;                 // UOE納品区分
            orderSndRcvJnl.DeliveredGoodsDivNm = uoeAnswerLedgerResultWork.DeliveredGoodsDivNm;         // 納品区分名称
            orderSndRcvJnl.FollowDeliGoodsDiv = uoeAnswerLedgerResultWork.FollowDeliGoodsDiv;           // フォロー納品区分
            orderSndRcvJnl.FollowDeliGoodsDivNm = uoeAnswerLedgerResultWork.FollowDeliGoodsDivNm;       // フォロー納品区分名称
            orderSndRcvJnl.UOEResvdSection = uoeAnswerLedgerResultWork.UOEResvdSection;                 // UOE指定拠点
            orderSndRcvJnl.UOEResvdSectionNm = uoeAnswerLedgerResultWork.UOEResvdSectionNm;             // UOE指定拠点名称
            orderSndRcvJnl.EmployeeCode = uoeAnswerLedgerResultWork.EmployeeCode;                       // 従業員コード
            orderSndRcvJnl.EmployeeName = uoeAnswerLedgerResultWork.EmployeeName;                       // 従業員名称
            orderSndRcvJnl.GoodsMakerCd = uoeAnswerLedgerResultWork.GoodsMakerCd;                       // 商品メーカーコード
            orderSndRcvJnl.MakerName = uoeAnswerLedgerResultWork.MakerName;                             // メーカー名称
            orderSndRcvJnl.GoodsNo = uoeAnswerLedgerResultWork.GoodsNo;                                 // 商品番号
            orderSndRcvJnl.GoodsNoNoneHyphen = uoeAnswerLedgerResultWork.GoodsNoNoneHyphen;             // ハイフン無商品番号
            orderSndRcvJnl.GoodsName = uoeAnswerLedgerResultWork.GoodsName;                             // 商品名称
            orderSndRcvJnl.WarehouseCode = uoeAnswerLedgerResultWork.WarehouseCode;                     // 倉庫コード
            orderSndRcvJnl.WarehouseName = uoeAnswerLedgerResultWork.WarehouseName;                     // 倉庫名称
            orderSndRcvJnl.WarehouseShelfNo = uoeAnswerLedgerResultWork.WarehouseShelfNo;               // 倉庫棚番
            orderSndRcvJnl.AcceptAnOrderCnt = uoeAnswerLedgerResultWork.AcceptAnOrderCnt;               // 受注数量
            orderSndRcvJnl.ListPrice = uoeAnswerLedgerResultWork.ListPrice;                             // 定価
            orderSndRcvJnl.SalesUnitCost = uoeAnswerLedgerResultWork.SalesUnitCost;                     // 原価単価
            orderSndRcvJnl.SupplierCd = uoeAnswerLedgerResultWork.SupplierCd;                           // 仕入先コード
            orderSndRcvJnl.SupplierSnm = uoeAnswerLedgerResultWork.SupplierSnm;                         // 仕入先略称
            orderSndRcvJnl.UoeRemark1 = uoeAnswerLedgerResultWork.UoeRemark1;                           // UOEリマーク1
            orderSndRcvJnl.UoeRemark2 = uoeAnswerLedgerResultWork.UoeRemark2;                           // UOEリマーク2
            orderSndRcvJnl.ReceiveDate = uoeAnswerLedgerResultWork.ReceiveDate;                         // 受信日付
            orderSndRcvJnl.ReceiveTime = uoeAnswerLedgerResultWork.ReceiveTime;                         // 受信時刻
            orderSndRcvJnl.AnswerMakerCd = uoeAnswerLedgerResultWork.AnswerMakerCd;                     // 回答メーカーコード
            orderSndRcvJnl.AnswerPartsNo = uoeAnswerLedgerResultWork.AnswerPartsNo;                     // 回答品番
            orderSndRcvJnl.AnswerPartsName = uoeAnswerLedgerResultWork.AnswerPartsName;                 // 回答品名
            orderSndRcvJnl.SubstPartsNo = uoeAnswerLedgerResultWork.SubstPartsNo;                       // 代替品番
            orderSndRcvJnl.UOESectOutGoodsCnt = uoeAnswerLedgerResultWork.UOESectOutGoodsCnt;           // UOE拠点出庫数
            orderSndRcvJnl.BOShipmentCnt1 = uoeAnswerLedgerResultWork.BOShipmentCnt1;                   // BO出庫数1
            orderSndRcvJnl.BOShipmentCnt2 = uoeAnswerLedgerResultWork.BOShipmentCnt2;                   // BO出庫数2
            orderSndRcvJnl.BOShipmentCnt3 = uoeAnswerLedgerResultWork.BOShipmentCnt3;                   // BO出庫数3
            orderSndRcvJnl.MakerFollowCnt = uoeAnswerLedgerResultWork.MakerFollowCnt;                   // メーカーフォロー数
            orderSndRcvJnl.NonShipmentCnt = uoeAnswerLedgerResultWork.NonShipmentCnt;                   // 未出庫数
            orderSndRcvJnl.UOESectStockCnt = uoeAnswerLedgerResultWork.UOESectStockCnt;                 // UOE拠点在庫数
            orderSndRcvJnl.BOStockCount1 = uoeAnswerLedgerResultWork.BOStockCount1;                     // BO在庫数1
            orderSndRcvJnl.BOStockCount2 = uoeAnswerLedgerResultWork.BOStockCount2;                     // BO在庫数2
            orderSndRcvJnl.BOStockCount3 = uoeAnswerLedgerResultWork.BOStockCount3;                     // BO在庫数3
            orderSndRcvJnl.UOESectionSlipNo = uoeAnswerLedgerResultWork.UOESectionSlipNo;               // UOE拠点伝票番号
            orderSndRcvJnl.BOSlipNo1 = uoeAnswerLedgerResultWork.BOSlipNo1;                             // BO伝票番号1
            orderSndRcvJnl.BOSlipNo2 = uoeAnswerLedgerResultWork.BOSlipNo2;                             // BO伝票番号2
            orderSndRcvJnl.BOSlipNo3 = uoeAnswerLedgerResultWork.BOSlipNo3;                             // BO伝票番号3
            orderSndRcvJnl.EOAlwcCount = uoeAnswerLedgerResultWork.EOAlwcCount;                         // EO引当数
            orderSndRcvJnl.BOManagementNo = uoeAnswerLedgerResultWork.BOManagementNo;                   // BO管理番号
            //2009/01/22 UPD>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //orderSndRcvJnl.ListPrice = uoeAnswerLedgerResultWork.ListPrice;                             // 回答定価
            //orderSndRcvJnl.SalesUnitCost = uoeAnswerLedgerResultWork.SalesUnitCost;                     // 回答原価単価
            orderSndRcvJnl.AnswerListPrice = uoeAnswerLedgerResultWork.AnswerListPrice;                 // 回答定価
            orderSndRcvJnl.AnswerSalesUnitCost = uoeAnswerLedgerResultWork.AnswerSalesUnitCost;         // 回答原価単価
            //2009/01/22 UPD<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
           
            orderSndRcvJnl.UOESubstMark = uoeAnswerLedgerResultWork.UOESubstMark;                       // UOE代替マーク
            orderSndRcvJnl.UOEStockMark = uoeAnswerLedgerResultWork.UOEStockMark;                       // UOE在庫マーク
            orderSndRcvJnl.PartsLayerCd = uoeAnswerLedgerResultWork.PartsLayerCd;                       // 層別コード
            orderSndRcvJnl.MazdaUOEShipSectCd1 = uoeAnswerLedgerResultWork.MazdaUOEShipSectCd1;         // UOE出荷拠点コード1(マツダ)
            orderSndRcvJnl.MazdaUOEShipSectCd2 = uoeAnswerLedgerResultWork.MazdaUOEShipSectCd2;         // UOE出荷拠点コード2(マツダ)
            orderSndRcvJnl.MazdaUOEShipSectCd3 = uoeAnswerLedgerResultWork.MazdaUOEShipSectCd3;         // UOE出荷拠点コード3(マツダ)
            orderSndRcvJnl.MazdaUOESectCd1 = uoeAnswerLedgerResultWork.MazdaUOESectCd1;                 // UOE拠点コード1(マツダ)
            orderSndRcvJnl.MazdaUOESectCd2 = uoeAnswerLedgerResultWork.MazdaUOESectCd2;                 // UOE拠点コード2(マツダ)
            orderSndRcvJnl.MazdaUOESectCd3 = uoeAnswerLedgerResultWork.MazdaUOESectCd3;                 // UOE拠点コード3(マツダ)
            orderSndRcvJnl.MazdaUOESectCd4 = uoeAnswerLedgerResultWork.MazdaUOESectCd4;                 // UOE拠点コード4(マツダ)
            orderSndRcvJnl.MazdaUOESectCd5 = uoeAnswerLedgerResultWork.MazdaUOESectCd5;                 // UOE拠点コード5(マツダ)
            orderSndRcvJnl.MazdaUOESectCd6 = uoeAnswerLedgerResultWork.MazdaUOESectCd6;                 // UOE拠点コード6(マツダ)
            orderSndRcvJnl.MazdaUOESectCd7 = uoeAnswerLedgerResultWork.MazdaUOESectCd7;                 // UOE拠点コード7(マツダ)
            orderSndRcvJnl.MazdaUOEStockCnt1 = uoeAnswerLedgerResultWork.MazdaUOEStockCnt1;             // UOE在庫数1(マツダ)
            orderSndRcvJnl.MazdaUOEStockCnt2 = uoeAnswerLedgerResultWork.MazdaUOEStockCnt2;             // UOE在庫数2(マツダ)
            orderSndRcvJnl.MazdaUOEStockCnt3 = uoeAnswerLedgerResultWork.MazdaUOEStockCnt3;             // UOE在庫数3(マツダ)
            orderSndRcvJnl.MazdaUOEStockCnt4 = uoeAnswerLedgerResultWork.MazdaUOEStockCnt4;             // UOE在庫数4(マツダ)
            orderSndRcvJnl.MazdaUOEStockCnt5 = uoeAnswerLedgerResultWork.MazdaUOEStockCnt5;             // UOE在庫数5(マツダ)
            orderSndRcvJnl.MazdaUOEStockCnt6 = uoeAnswerLedgerResultWork.MazdaUOEStockCnt6;             // UOE在庫数6(マツダ)
            orderSndRcvJnl.MazdaUOEStockCnt7 = uoeAnswerLedgerResultWork.MazdaUOEStockCnt7;             // UOE在庫数7(マツダ)
            orderSndRcvJnl.UOEDistributionCd = uoeAnswerLedgerResultWork.UOEDistributionCd;             // UOE卸コード
            orderSndRcvJnl.UOEOtherCd = uoeAnswerLedgerResultWork.UOEOtherCd;                           // UOE他コード
            orderSndRcvJnl.UOEHMCd = uoeAnswerLedgerResultWork.UOEHMCd;                                 // UOEＨＭコード
            orderSndRcvJnl.BOCount = uoeAnswerLedgerResultWork.BOCount;                                 // BO数
            orderSndRcvJnl.UOEMarkCode = uoeAnswerLedgerResultWork.UOEMarkCode;                         // UOEマークコード
            orderSndRcvJnl.SourceShipment = uoeAnswerLedgerResultWork.SourceShipment;                   // 出荷元
            orderSndRcvJnl.ItemCode = uoeAnswerLedgerResultWork.ItemCode;                               // アイテムコード
            orderSndRcvJnl.UOECheckCode = uoeAnswerLedgerResultWork.UOECheckCode;                       // UOEチェックコード
            orderSndRcvJnl.HeadErrorMassage = uoeAnswerLedgerResultWork.HeadErrorMassage;              // ヘッドエラーメッセージ
            orderSndRcvJnl.LineErrorMassage = uoeAnswerLedgerResultWork.LineErrorMassage;              // ラインエラーメッセージ
        }
        #endregion
        #endregion ◆発注データ→OrderSndRcvJnl作成関連 - end
        #endregion ■Privateメソッド - end
    }
}


# region ※using
using System;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Xml.Serialization;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
# endregion

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// UOE回答表示(単体) テーブルアクセスクラス
    /// </summary>
    /// <remarks>
	/// <br>Note		: UOE回答データの検索を行います。</br>
	/// <br>Programmer	: 照田 貴志</br>
    /// <br>Date		: 2008/11/10</br>
    /// <br>UpdateNote  : 2008/12/19 照田 貴志　抽出条件クラス項目追加</br>
    /// <br>              2009/01/07 照田 貴志　バグ修正、仕様変更対応</br>
    /// <br>              2009/01/13 照田 貴志　不具合対応[9834][9872]</br>
    /// <br>              2009/01/21 照田 貴志　不具合対応[9876]</br>
    /// </remarks>
    public class PMUOE04203AA
    {
        # region ■定数、変数、構造体
        // 通信アセンブリID(通信プログラムID)
        private const int PROGRAMID_NOTHING = 0;            // なし
        private const int PROGRAMID_TOYOTA = 102;           // トヨタ
        private const int PROGRAMID_NISSAN = 202;           // ニッサン
        private const int PROGRAMID_MITSUBISHI = 301;       // ミツビシ
        private const int PROGRAMID_MATSUDA_OLD = 401;      // 旧マツダ
        private const int PROGRAMID_MATSUDA_NEW = 402;      // 新マツダ
        private const int PROGRAMID_HONDA = 501;            // ホンダ
        // 変数
        private Hashtable _uoeOrderDtlHTable = null;        // UOE発注先マスタ(key：UOE発注先コード)
        private Hashtable _customerHTable = null;           // 得意先マスタ(key：得意先コード)
        private DataSet _uoeReplyDataSet = null;            // UOE回答データ
        private DataView _uoeReplyDataView = null;          // UOE回答データ(印刷用に、チェックされたものを抽出)
        private string _enterpriseCode = string.Empty;      // 企業コード
        private string _sectionCode = string.Empty;         // 拠点コード

        private IUOEAnswerLedgerOrderWorkDB _iUOEAnswerLedgerOrderWorkDB = null;      // 発注データ取得用リモートオブジェクト
        // 発注先情報
        #region UOEOrderDtlInfo構造体
        /// <summary>
        /// UOE発注先情報　構造体
        /// </summary>
        public struct UOEOrderDtlInfo
        {
            /// <summary> アセンブリID </summary>
            public string CommAssemblyId;
            /// <summary> 発注先名称 </summary>
            public string UOESupplierName;
        }
        #endregion ■定数、変数、構造体 - end
        # endregion

		#region ■イベント
        public event SettingStatusBarMessageEventHandler StatusBarMessageSetting;
		public delegate void SettingStatusBarMessageEventHandler( object sender, string message );
		#endregion

		# region ■Constracter
		/// <summary>
		/// コンストラクタ
        /// </summary>
        /// <remarks>
		/// <br>Note       : インスタンスを初期化します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public PMUOE04203AA()
        {
            // 企業コードを取得する
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 拠点コードを取得する
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            // オフラインチェック
            if (!LoginInfoAcquisition.OnlineFlag)
            {
                MessageBox.Show("オフライン状態のため検索が実行できません。");
                return;
            }

            // リモートオブジェクト取得
            this._iUOEAnswerLedgerOrderWorkDB = (IUOEAnswerLedgerOrderWorkDB)MediationUOEAnswerLedgerOrderWorkDB.GetUOEAnswerLedgerOrderWorkDB();

            // UOE回答表示DataSet(データなし、グリッドレイアウト設定のみ)作成
            DataTable dataTable = null;
            PMUOE04202EA.CreateDataTableDetail(ref dataTable);

            this._uoeReplyDataSet = new DataSet();
            this._uoeReplyDataSet.Tables.Add(dataTable);

            // 発注先データHashTable作成
            this.CreateUOEOrderDtlHTable();

            // 得意先データHashTalbe作成
            this.CreateCustomerHTable();
        }
        # endregion

        #region ■Public
        #region ◆プロパティ
        /// <summary> UOE回答データ </summary>
        public DataSet UOEReplyDataSet
        {
            get { return this._uoeReplyDataSet; }
        }
        /// <summary> UOE回答データ(印刷用 明細チェックありで抽出) </summary>
        public DataView UOEReplyDataView
        {
            get { return this._uoeReplyDataView; }
        }
        #endregion

        #region ▼GetUOESupplierName(発注先名称取得)
        /// <summary>
        /// 発注先名称取得
        /// </summary>
        /// <param name="uoeSupplierCd">発注先コード</param>
        /// <param name="uoeSupplierName">発注先名称</param>
        /// <returns>True：成功、False：失敗</returns>
        /// <remarks>
        /// <br>Note       : UOE発注先コードを元に発注先名称を取得します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public bool GetUOESupplierName(int uoeSupplierCd, out string uoeSupplierName)
        {
            return this.GetUOESupplierNameFromUOEOrderDtlHTable(uoeSupplierCd, out uoeSupplierName);
        }
        #endregion

        #region ▼GetCustomerName(得意先名称取得)
        /// <summary>
        /// 得意先名称取得
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="customerName">得意先名称</param>
        /// <returns>True：成功、False：失敗</returns>
        /// <remarks>
        /// <br>Note       : 得意先コードを元に得意先名称を取得します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public bool GetCustomerName(int customerCode, out string customerName)
        {
            return this.GetCustomerNameFromCustomerHTable(customerCode, out customerName);
        }
        #endregion

        #region ▼ClearUOEOrderDtlDataTable(UOE回答データクリア)
        /// <summary>
        /// UOE回答データクリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : UOE回答データセットの内容をクリアします。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public void ClearUOEOrderDtlDataTable()
        {
            this._uoeReplyDataSet.Tables[PMUOE04202EA.ct_Tbl_UOEReply].Rows.Clear();
        }
        #endregion

        #region ▼SetSearchData(UOE回答データ取得)
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="ioWriteMASIRReadWork">UOE回答検索条件パラメータクラス</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 条件に沿って検索を行います。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public int SetSearchData(UOEAnswerLedgerOrderCndtn uoeAnswerLedgerOrderCndtn)
        {
            // 抽出条件
            UOEAnswerLedgerOrderCndtnWork uoeAnswerLedgerOrderCndtnWork = new UOEAnswerLedgerOrderCndtnWork();
            uoeAnswerLedgerOrderCndtnWork.EnterpriseCode = uoeAnswerLedgerOrderCndtn.EnterpriseCode;        // 企業コード
            uoeAnswerLedgerOrderCndtnWork.SectionCode = uoeAnswerLedgerOrderCndtn.SectionCode;              // 拠点コード
            uoeAnswerLedgerOrderCndtnWork.SystemDivCd = uoeAnswerLedgerOrderCndtn.SystemDivCd;              // システム区分
            uoeAnswerLedgerOrderCndtnWork.UOESupplierCd = uoeAnswerLedgerOrderCndtn.UOESupplierCd;          // 発注先コード
            uoeAnswerLedgerOrderCndtnWork.CustomerCode = uoeAnswerLedgerOrderCndtn.CustomerCode;            // 得意先コード
            uoeAnswerLedgerOrderCndtnWork.St_ReceiveDate = uoeAnswerLedgerOrderCndtn.St_ReceiveDate;        // 開始発注日
            uoeAnswerLedgerOrderCndtnWork.Ed_ReceiveDate = uoeAnswerLedgerOrderCndtn.Ed_ReceiveDate;        // 終了発注日
            uoeAnswerLedgerOrderCndtnWork.UOEKind = uoeAnswerLedgerOrderCndtn.UOEKind;                      // UOE種別(0：UOE固定)      //ADD 2008/12/19
            uoeAnswerLedgerOrderCndtnWork.St_InputDay = uoeAnswerLedgerOrderCndtn.St_InputDay;              // 入力日(開始)             //ADD 2008/12/19
            uoeAnswerLedgerOrderCndtnWork.Ed_InputDay = uoeAnswerLedgerOrderCndtn.Ed_InputDay;              // 入力日(終了)             //ADD 2008/12/19

            // データ抽出            
            Object arrayList = null;
            int status = this._iUOEAnswerLedgerOrderWorkDB.Search(out arrayList, (object)uoeAnswerLedgerOrderCndtnWork, 0, ConstantManagement.LogicalMode.GetDataAll);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        this.StatusBarMessageSetting(this, "該当データがありません");
                        return -1;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                default:
                    this.StatusBarMessageSetting(this, "発注データの読込に失敗しました。");
                    return -1;
            }

            // グリッド表示用データ作成
            DataTable dataTable = this._uoeReplyDataSet.Tables[PMUOE04202EA.ct_Tbl_UOEReply];
            foreach (UOEAnswerLedgerResultWork uoeAnswerLedgerResultWork in (ArrayList)arrayList)
            {
                DataRow dr = dataTable.NewRow();

                dr[PMUOE04202EA.ct_Col_No] = dataTable.Rows.Count + 1;          // 行No.
                dr[PMUOE04202EA.ct_Col_SelectFlg] = false;                      // 選択フラグ

                // UOE回答データ→グリッド用DataRowコピー
                this.CopyToUOEReplyFromUOEAnswerLedgerResultWork(uoeAnswerLedgerResultWork, ref dr);

                dataTable.Rows.Add(dr);
            }

            if (this.StatusBarMessageSetting != null)
            {
                this.StatusBarMessageSetting(this, "データを抽出しました。");
            }

            return 0;
        }
        #endregion

        #region ▼SetRowSelectedAll(選択項目の選択/解除－全行)
        /// <summary>
        /// 全ての行の選択チェックをセット
        /// </summary>
        /// <param name="rowSelected">True：選択、False：解除</param>
        /// <remarks>
        /// <br>Note       : 全明細の選択項目に対して選択/解除を行います。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public void SetRowSelectedAll(bool rowSelected)
        {
            // 全ての行の選択チェックを設定
            foreach (DataRow dataRow in this._uoeReplyDataSet.Tables[PMUOE04202EA.ct_Tbl_UOEReply].Rows)
            {
                dataRow[PMUOE04202EA.ct_Col_SelectFlg] = rowSelected;
            }
        }
        #endregion

        #region ▼SetRowSelected(選択項目の選択/解除－1行のみ)
        /// <summary>
        /// 行選択チェック処理
        /// </summary>
        /// <param name="rowNo">対象行</param>
        /// <param name="rowSelected">True：選択、False：解除</param>
        /// <remarks>
        /// <br>Note       : 指定明細の選択項目に対して選択/解除を行います。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public void SetRowSelected(int rowNo, bool rowSelected)
        {
            // 行№で検索
            DataRow dataRow = this._uoeReplyDataSet.Tables[PMUOE04202EA.ct_Tbl_UOEReply].Rows.Find(rowNo);
            if (dataRow == null)
            {
                return;
            }

            // チェック値セット
            dataRow[PMUOE04202EA.ct_Col_SelectFlg] = rowSelected;

        }
        #endregion

        #region ▼GetSelectedRowCount(選択行数を返す)
        /// <summary>
        /// 選択行取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 指定明細の選択項目に対して選択/解除を行います。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public int GetSelectedRowCount()
        {
            // データビューを生成して、選択済みフラグでフィルタをかける
            string rowFilter = string.Format("{0} = '{1}'", PMUOE04202EA.ct_Col_SelectFlg, true);       // 抽出条件
            //string sort = PMUOE04202EA.ct_Col_No;                                                       // ソート条件     //DEL 2009/01/07 不具合対応[9519]
            // --- ADD 2009/01/07 不具合対応[9519] ----------------------------------------------------------------------------------->>>>>
            // ソート条件
            string sort = string.Format("{0},{1},{2},{3},{4}"
                                        , PMUOE04202EA.ct_Col_UOESupplierCd         //発注先
                                        , PMUOE04202EA.ct_Col_ReceiveDate           //受信日
                                        , PMUOE04202EA.ct_Col_ReceiveTime           //受信時刻
                                        , PMUOE04202EA.ct_Col_UOESalesOrderNo       //発注回答番号
                                        , PMUOE04202EA.ct_Col_UOESalesOrderRowNo);  //発注回答行番号
            // --- ADD 2009/01/07 不具合対応[9519] -----------------------------------------------------------------------------------<<<<<

            this._uoeReplyDataView = new DataView(this._uoeReplyDataSet.Tables[PMUOE04202EA.ct_Tbl_UOEReply],rowFilter,sort,DataViewRowState.CurrentRows);

            // 件数を返す
            return this._uoeReplyDataView.Count;
        }
        #endregion
        #endregion ■Public - end

        #region ■Private
        #region ◆発注先マスタ関連
        #region ▼CreateUOEOrderDtlHTable(HashTable作成)
        /// <summary>
        /// UOE発注先マスタHashTable作成
        /// </summary>
        /// <remarks>
        /// <br>Note       : UOE発注先マスタを元にHashTableを作成します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
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

                // UOE発注先情報取得
                UOEOrderDtlInfo uoeOrderDtlInfo;
                uoeOrderDtlInfo.CommAssemblyId = dataRow["CommAssemblyId"].ToString();
                uoeOrderDtlInfo.UOESupplierName = dataRow["UoeSupplierName"].ToString();

                this._uoeOrderDtlHTable[key] = uoeOrderDtlInfo;
            }
        }
        #endregion

        #region ▼GetProgramIdFromUOEOrderDtlHTable(通信アセンブリID(通信プログラムID)取得)
        /// <summary>
        /// 通信アセンブリID(通信プログラムID)取得
        /// </summary>
        /// <param name="uoeSupplierCd">UOE発注先コード</param>
        /// <returns>通信アセンブリID(通信プログラムID)</returns>
        /// <remarks>
        /// <br>Note       : UOE発注先コードを元にUOE発注先マスタHashTableから通信アセンブリID(通信プログラムID)を取得します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private int GetProgramIdFromUOEOrderDtlHTable(int uoeSupplierCd)
        {
            int programId = 0;        // なし

            if (this.HashTableIsNullOrEmpty(this._uoeOrderDtlHTable, uoeSupplierCd) == false)
            {
                // HashTableより取得
                UOEOrderDtlInfo uoeOrderDtlInfo = (UOEOrderDtlInfo)this._uoeOrderDtlHTable[uoeSupplierCd];

                bool ret = int.TryParse(uoeOrderDtlInfo.CommAssemblyId, out programId);
            }
            return programId;
        }
        #endregion

        #region ▼GetUOESupplierNameFromUOEOrderDtlHTable(UOE発注先名称取得)
        /// <summary>
        /// UOE発注先名称取得
        /// </summary>
        /// <param name="uoeSupplierCd">UOE発注先コード</param>
        /// <param name="uoeSupplierName">UOE発注先名称</param>
        /// <returns>True：データあり、False：データなし</returns>
        /// <remarks>
        /// <br>Note       : UOE発注先コードを元にUOE発注先マスタHashTableからUOE発注先名称を取得します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private bool GetUOESupplierNameFromUOEOrderDtlHTable(int uoeSupplierCd, out string uoeSupplierName)
        {
            uoeSupplierName = string.Empty;
            if (this.HashTableIsNullOrEmpty(this._uoeOrderDtlHTable, uoeSupplierCd))
            {
                return false;
            }

            // HashTableより取得
            UOEOrderDtlInfo uoeOrderDtlInfo = (UOEOrderDtlInfo)this._uoeOrderDtlHTable[uoeSupplierCd];
            uoeSupplierName = uoeOrderDtlInfo.UOESupplierName;

            return true;
        }
        #endregion
        #endregion ◆発注先マスタ関連 - end

        #region ◆得意先マスタ関連
        #region ▼CreateCustomerHTable(HashTable作成)
        /// <summary>
        /// 得意先マスタHashTable作成
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先マスタを元にHashTableを作成します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void CreateCustomerHTable()
        {
            CustomerSearchRet[] customerSearchRetArray = null;

            // 条件設定
            CustomerSearchPara customerSearchPara = new CustomerSearchPara();
            customerSearchPara.EnterpriseCode = this._enterpriseCode;

            // 得意先マスタデータ取得(PMKHN09012A)
            CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();
            int status = customerSearchAcs.Serch(out customerSearchRetArray, customerSearchPara);

            // 異常
            if (status != 0)
            {
                this._customerHTable = null;
                return;
            }
            // データなし
            if (customerSearchRetArray == null)
            {
                this._customerHTable = null;
                return;
            }

            // HashTable作成
            this._customerHTable = new Hashtable();
            foreach (CustomerSearchRet customerSearchRet in customerSearchRetArray)
            {
                this._customerHTable[customerSearchRet.CustomerCode] = customerSearchRet.Name + customerSearchRet.Name2;
            }
        }
        #endregion

        #region ▼GetCustomerNameFromCustomerHTable(得意先名称取得)
        /// <summary>
        /// 得意先名称取得
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="customerName">得意先名称</param>
        /// <returns>True：データあり、False：データなし</returns>
        /// <remarks>
        /// <br>Note       : 得意先コードを元に得意先マスタHashTableから得意先名称を取得します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private bool GetCustomerNameFromCustomerHTable(int customerCode, out string customerName)
        {
            customerName = string.Empty;
            if (this.HashTableIsNullOrEmpty(this._customerHTable, customerCode))
            {
                return false;
            }

            // HashTableより取得
            customerName = this._customerHTable[customerCode].ToString();

            return true;
        }
        #endregion
        #endregion ◆得意先マスタ関連 - end

        #region ▼HashTableIsNullOrDataNothing(HashTableデータ存在チェック)
        /// <summary>
        /// HashTableデータ存在チェック
        /// </summary>
        /// <param name="uoeSupplierCd"></param>
        /// <returns>True:データなし、False:データあり</returns>
        /// <remarks>
        /// <br>Note       : Keyで指定されたデータがHashTableに存在するかチェックを行います。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private bool HashTableIsNullOrEmpty(Hashtable hashTable, int key)
        {
            // データが無い
            if (hashTable == null)
            {
                return true;
            }

            // INDEX範囲外
            if (hashTable.ContainsKey(key) == false)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region ▼CopyToUOEReplyFromUOEAnswerLedgerResultWork(UOE回答データ→グリッド用DataRowコピー)
        /// <summary>
        /// UOE回答データ→グリッド用DataRowコピー
        /// </summary>
        /// <param name="uoeAnswerLedgerResultWork">UOE回答データ</param>
        /// <param name="dr">グリッド用DataRow</param>
        /// <remarks>
        /// <br>Note       : グリッド用DataRowにUOE回答データをコピーします。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void CopyToUOEReplyFromUOEAnswerLedgerResultWork(UOEAnswerLedgerResultWork uoeAnswerLedgerResultWork, ref DataRow dr)
        {
            dr[PMUOE04202EA.ct_Col_ReceiveDate] = uoeAnswerLedgerResultWork.ReceiveDate.ToString("yyyy/MM/dd");                             // 受信日付
            dr[PMUOE04202EA.ct_Col_ReceiveTime] = uoeAnswerLedgerResultWork.ReceiveTime.ToString("000000").Insert(2, ":").Insert(5, ":");   // 受信時刻
            dr[PMUOE04202EA.ct_Col_UOESalesOrderNo] = uoeAnswerLedgerResultWork.UOESalesOrderNo.ToString("000000");                         // UOE発注番号
            dr[PMUOE04202EA.ct_Col_UOESalesOrderRowNo] = uoeAnswerLedgerResultWork.UOESalesOrderRowNo;                                      // UOE発注行番号
            dr[PMUOE04202EA.ct_Col_UOESupplierCd] = uoeAnswerLedgerResultWork.UOESupplierCd.ToString("000000");                             // UOE発注先コード
            dr[PMUOE04202EA.ct_Col_UOESupplierName] = uoeAnswerLedgerResultWork.UOESupplierName;                                            // 発注先名称
            dr[PMUOE04202EA.ct_Col_UOEDeliGoodsDiv] = uoeAnswerLedgerResultWork.UOEDeliGoodsDiv;                                            // UOE納品区分
            dr[PMUOE04202EA.ct_Col_FollowDeliGoodsDiv] = uoeAnswerLedgerResultWork.FollowDeliGoodsDiv;                                      // フォロー納品区分
            dr[PMUOE04202EA.ct_Col_BOCode] = uoeAnswerLedgerResultWork.BoCode;                                                              // BO区分

            // 依頼者コード
            try
            {
                dr[PMUOE04202EA.ct_Col_EmployeeCode] = (int.Parse(uoeAnswerLedgerResultWork.EmployeeCode)).ToString("0000");
            }
            catch
            {
                dr[PMUOE04202EA.ct_Col_EmployeeCode] = uoeAnswerLedgerResultWork.EmployeeCode;
            }

            dr[PMUOE04202EA.ct_Col_EmployeeName] = uoeAnswerLedgerResultWork.EmployeeName;                                                  // 依頼者名称
            //dr[PMUOE04202EA.ct_Col_CustomerCode] = uoeAnswerLedgerResultWork.CustomerCode.ToString("00000000");                             // 得意先コード   //DEL 2009/01/06 不具合対応[9516]
            // --- ADD 2009/01/06 不具合対応[9516] ------------------------------------------------------------------->>>>>
            if (uoeAnswerLedgerResultWork.CustomerCode == 0)
            {
                //ALL0は非表示
                dr[PMUOE04202EA.ct_Col_CustomerCode] = uoeAnswerLedgerResultWork.CustomerCode.ToString("########");
            }
            else
            {
                dr[PMUOE04202EA.ct_Col_CustomerCode] = uoeAnswerLedgerResultWork.CustomerCode.ToString("00000000");
            }
            // --- ADD 2009/01/06 不具合対応[9516] -------------------------------------------------------------------<<<<<
            dr[PMUOE04202EA.ct_Col_CustomerSnm] = uoeAnswerLedgerResultWork.CustomerSnm;                                                    // 得意先名称
            dr[PMUOE04202EA.ct_Col_GoodsNo] = uoeAnswerLedgerResultWork.GoodsNo;                                                            // 品番
            dr[PMUOE04202EA.ct_Col_GoodsMakerCd] = uoeAnswerLedgerResultWork.GoodsMakerCd.ToString("0000");                                 // メーカー
            dr[PMUOE04202EA.ct_Col_GoodsName] = uoeAnswerLedgerResultWork.GoodsName;                                                        // 品名
            dr[PMUOE04202EA.ct_Col_UOERemark1] = uoeAnswerLedgerResultWork.UoeRemark1;                                                      // リマーク1
            dr[PMUOE04202EA.ct_Col_UOERemark2] = uoeAnswerLedgerResultWork.UoeRemark2;                                                      // リマーク2
            dr[PMUOE04202EA.ct_Col_AcceptAnOrderCnt] = uoeAnswerLedgerResultWork.AcceptAnOrderCnt;                                          // 発注数量
            dr[PMUOE04202EA.ct_Col_UOESectOutGoodsCnt] = uoeAnswerLedgerResultWork.UOESectOutGoodsCnt;                                      // 拠点出庫数
            dr[PMUOE04202EA.ct_Col_UOESectionSlipNo] = uoeAnswerLedgerResultWork.UOESectionSlipNo;                                          // 拠点伝票番号
            dr[PMUOE04202EA.ct_Col_BOShipmentCnt1] = uoeAnswerLedgerResultWork.BOShipmentCnt1;                                              // フォロー1(BO1)
            dr[PMUOE04202EA.ct_Col_BOSlipNo1] = uoeAnswerLedgerResultWork.BOSlipNo1;                                                        // フォロー伝票番号1
            dr[PMUOE04202EA.ct_Col_BOShipmentCnt2] = uoeAnswerLedgerResultWork.BOShipmentCnt2;                                              // フォロー2(BO2)
            dr[PMUOE04202EA.ct_Col_BOSlipNo2] = uoeAnswerLedgerResultWork.BOSlipNo2;                                                        // フォロー伝票番号2
            dr[PMUOE04202EA.ct_Col_BOShipmentCnt3] = uoeAnswerLedgerResultWork.BOShipmentCnt3;                                              // フォロー3(BO3)
            dr[PMUOE04202EA.ct_Col_BOSlipNo3] = uoeAnswerLedgerResultWork.BOSlipNo3;                                                        // フォロー伝票番号3
            dr[PMUOE04202EA.ct_Col_MakerFollowCnt] = uoeAnswerLedgerResultWork.MakerFollowCnt;                                              // メーカーフォロー数
            //dr[PMUOE04202EA.ct_Col_ListPrice] = uoeAnswerLedgerResultWork.ListPrice;                                                        // 定価d                  //DEL 2009/01/13 不具合対応[9834]
            //dr[PMUOE04202EA.ct_Col_SalesUnitCost] = uoeAnswerLedgerResultWork.SalesUnitCost;                                                // 仕切単価d              //DEL 2009/01/13 不具合対応[9834]
            dr[PMUOE04202EA.ct_Col_ListPrice] = uoeAnswerLedgerResultWork.AnswerListPrice;                                                  // 定価(回答定価)           //ADD 2009/01/13 不具合対応[9834]
            dr[PMUOE04202EA.ct_Col_SalesUnitCost] = uoeAnswerLedgerResultWork.AnswerSalesUnitCost;                                          // 仕切単価(回答原価単価)   //ADD 2009/01/13 不具合対応[9834]
            dr[PMUOE04202EA.ct_Col_UOESubstMark] = uoeAnswerLedgerResultWork.UOESubstMark;                                                  // 代替区分
            dr[PMUOE04202EA.ct_Col_PartsLayerCd] = uoeAnswerLedgerResultWork.PartsLayerCd;                                                  // 層別(日産)
            dr[PMUOE04202EA.ct_Col_BOManagementNo] = uoeAnswerLedgerResultWork.BOManagementNo;                                              // EO管理番号(日産)
            dr[PMUOE04202EA.ct_Col_EOAlwcCount] = uoeAnswerLedgerResultWork.EOAlwcCount;                                                    // EO発注数(日産)i
            dr[PMUOE04202EA.ct_Col_MazdaUOEShipSectCd1] = uoeAnswerLedgerResultWork.MazdaUOEShipSectCd1;                                    // 拠点コード(ﾏﾂﾀﾞ)
            dr[PMUOE04202EA.ct_Col_MazdaUOEShipSectCd2] = uoeAnswerLedgerResultWork.MazdaUOEShipSectCd2;                                    // フォローコード1(ﾏﾂﾀﾞ)
            dr[PMUOE04202EA.ct_Col_MazdaUOEShipSectCd3] = uoeAnswerLedgerResultWork.MazdaUOEShipSectCd3;                                    // フォローコード2(ﾏﾂﾀﾞ)
            //dr[PMUOE04202EA.ct_Col_LineErrorMessage] = uoeAnswerLedgerResultWork.LineErrorMassage;                                          // エラーメッセージ
            dr[PMUOE04202EA.ct_Col_SourceShipment] = uoeAnswerLedgerResultWork.SourceShipment;                                              // 出荷元コード(ﾎﾝﾀﾞ)  
            dr[PMUOE04202EA.ct_Col_SectionCode] = uoeAnswerLedgerResultWork.SectionCode;                                                    // 拠点コード　※使用は帳票のみ
            dr[PMUOE04202EA.ct_Col_SectionName] = uoeAnswerLedgerResultWork.SectionGuideSnm;                                                // 拠点名称　　※使用は帳票のみ
            dr[PMUOE04202EA.ct_Col_ForeColor] = string.Empty;                                                                               // 表示文字色

            // ---ADD 2009/01/21 不具合対応[9876] ----------------------------------------------->>>>>
            // コメント
            if (string.IsNullOrEmpty(uoeAnswerLedgerResultWork.HeadErrorMassage.Trim()) == false)
            {
                dr[PMUOE04202EA.ct_Col_LineErrorMessage] = uoeAnswerLedgerResultWork.HeadErrorMassage;
            }
            else if (string.IsNullOrEmpty(uoeAnswerLedgerResultWork.LineErrorMassage.Trim()) == false)
            {
                dr[PMUOE04202EA.ct_Col_LineErrorMessage] = uoeAnswerLedgerResultWork.LineErrorMassage;
            }
            else if (string.IsNullOrEmpty(uoeAnswerLedgerResultWork.SubstPartsNo.Trim()) == false)
            {
                dr[PMUOE04202EA.ct_Col_LineErrorMessage] = uoeAnswerLedgerResultWork.SubstPartsNo;
            }
            else
            {
                dr[PMUOE04202EA.ct_Col_LineErrorMessage] = string.Empty;
            }
            // ---ADD 2009/01/21 不具合対応[9876] -----------------------------------------------<<<<<

            /* ---DEL 2009/01/20 不具合対応[10165] -------------------------------------------------------------->>>>>
            // --- ADD 2009/01/13 不具合対応[9872] --------------------------------------------------------->>>>>
            if (uoeAnswerLedgerResultWork.MakerFollowCnt != 0)
            {
                // メーカーフォロー数が０以外
                dr[PMUOE04202EA.ct_Col_ForeColor] = "YELLOW";
                return;
            }
            if (string.IsNullOrEmpty(uoeAnswerLedgerResultWork.SubstPartsNo.Trim()) == false)
            {
                // 代替コードがスペース以外
                dr[PMUOE04202EA.ct_Col_ForeColor] = "GREEN";
                return;
            }
            if ((uoeAnswerLedgerResultWork.UOESectOutGoodsCnt == 0) &&       // 拠点出庫数
                (uoeAnswerLedgerResultWork.BOShipmentCnt1 == 0) &&           // BO1数
                (uoeAnswerLedgerResultWork.BOShipmentCnt2 == 0) &&           // BO2数
                (uoeAnswerLedgerResultWork.BOShipmentCnt3 == 0) &&           // BO3数
                (uoeAnswerLedgerResultWork.MakerFollowCnt == 0) &&           // メーカーフォロー数
                (uoeAnswerLedgerResultWork.EOAlwcCount == 0))                // EO発注数
            {
                // 拠点出庫数、BO1～3数、メーカーフォロー数、EO発注数の全てが、０の場合
                dr[PMUOE04202EA.ct_Col_ForeColor] = "RED";
                return;
            }
            // 下記条件のうち１つでも該当する場合		
            // ①回答データの(発注数量 - (拠点出庫数 + BO1～3数 + メーカーフォロー数 + EO数))が０以外の場合	
            // ②BO1が０以外の場合	
            // ③BO2が０以外の場合	
            // ④BO3数が０以外の場合	
            // ⑤仕切単価が０の場合
            double total = uoeAnswerLedgerResultWork.AcceptAnOrderCnt       // 発注数量
                        - (uoeAnswerLedgerResultWork.UOESectOutGoodsCnt     // 拠点出庫数
                           + uoeAnswerLedgerResultWork.BOShipmentCnt1       // BO1数
                           + uoeAnswerLedgerResultWork.BOShipmentCnt2       // BO2数
                           + uoeAnswerLedgerResultWork.BOShipmentCnt3       // BO3数
                           + uoeAnswerLedgerResultWork.MakerFollowCnt       // メーカーフォロー数
                           + uoeAnswerLedgerResultWork.EOAlwcCount);        // EO発注数
            if ((total != 0) ||
                (uoeAnswerLedgerResultWork.BOShipmentCnt1 != 0) ||
                (uoeAnswerLedgerResultWork.BOShipmentCnt2 != 0) ||
                (uoeAnswerLedgerResultWork.BOShipmentCnt3 != 0) ||
                (uoeAnswerLedgerResultWork.AnswerSalesUnitCost == 0))
            {
                dr[PMUOE04202EA.ct_Col_ForeColor] = "BLUE";
                return;
            }
            // --- ADD 2009/01/13 不具合対応[9872] ---------------------------------------------------------<<<<<
               ---DEL 2009/01/20 不具合対応[10165] --------------------------------------------------------------<<<<< */
            // ---ADD 2009/01/20 不具合対応[10165] -------------------------------------------------------------->>>>>
            // 代替品
            //if (string.IsNullOrEmpty(uoeAnswerLedgerResultWork.SubstPartsNo.Trim()) == false)         //DEL 2009/01/21 不具合対応[9876]
            // ---ADD 2009/01/21 不具合対応[9876] ---------------------------------------------------------->>>>>
            if ((string.IsNullOrEmpty(uoeAnswerLedgerResultWork.HeadErrorMassage.Trim())) &&
                (string.IsNullOrEmpty(uoeAnswerLedgerResultWork.LineErrorMassage.Trim())) &&
                (string.IsNullOrEmpty(uoeAnswerLedgerResultWork.SubstPartsNo.Trim()) == false))
            // ---ADD 2009/01/21 不具合対応[9876] ----------------------------------------------------------<<<<<
            {
                // 代替コードがスペース以外
                dr[PMUOE04202EA.ct_Col_ForeColor] = "GREEN";
                return;
            }
            // 全部残
            if ((uoeAnswerLedgerResultWork.UOESectOutGoodsCnt == 0) &&       // 拠点出庫数
                (uoeAnswerLedgerResultWork.BOShipmentCnt1 == 0) &&           // BO1数
                (uoeAnswerLedgerResultWork.BOShipmentCnt2 == 0) &&           // BO2数
                (uoeAnswerLedgerResultWork.BOShipmentCnt3 == 0) &&           // BO3数
                (uoeAnswerLedgerResultWork.MakerFollowCnt == 0) &&           // メーカーフォロー数
                (uoeAnswerLedgerResultWork.EOAlwcCount == 0))                // EO発注数
            {
                // 拠点出庫数、BO1～3数、メーカーフォロー数、EO発注数の全てが、０の場合
                dr[PMUOE04202EA.ct_Col_ForeColor] = "RED";
                return;
            }
            // 仕切無し/一部残/ﾒｰｶｰﾌｫﾛｰ分
            // ①回答データの(発注数量 - (拠点出庫数 + BO1～3数 + メーカーフォロー数 + EO数))が０以外の場合	
            // ②ﾒｰｶｰﾌｫﾛｰ数が０以外の場合
            // ③仕切単価が０の場合
            double total = uoeAnswerLedgerResultWork.AcceptAnOrderCnt       // 発注数量
                        - (uoeAnswerLedgerResultWork.UOESectOutGoodsCnt     // 拠点出庫数
                           + uoeAnswerLedgerResultWork.BOShipmentCnt1       // BO1数
                           + uoeAnswerLedgerResultWork.BOShipmentCnt2       // BO2数
                           + uoeAnswerLedgerResultWork.BOShipmentCnt3       // BO3数
                           + uoeAnswerLedgerResultWork.MakerFollowCnt       // メーカーフォロー数
                           + uoeAnswerLedgerResultWork.EOAlwcCount);        // EO発注数
            if ((total != 0) || (uoeAnswerLedgerResultWork.MakerFollowCnt != 0) || (uoeAnswerLedgerResultWork.AnswerSalesUnitCost == 0))
            {
                dr[PMUOE04202EA.ct_Col_ForeColor] = "BLUE";
                return;
            }
            // ---ADD 2009/01/20 不具合対応[10165] --------------------------------------------------------------<<<<<
        }
        #endregion
        #endregion
    }
}

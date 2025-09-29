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

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 見積回答表示　アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 見積回答表示に関するアクセス制御を行います。</br>
    /// <br>Programmer	: 照田 貴志</br>
    /// <br>Date		: 2008/11/10</br>
    /// <br>            : 2008/12/10 照田 貴志　品名には回答品名を表示</br>
    /// <br>              2008/12/19 照田 貴志　UOEガイド名称マスタに一致するものが無い場合は編集しないでそのまま表示</br>
    /// <br>              2009/01/20 照田 貴志　不具合対応[10208][10256]</br>
    /// </remarks>
    public class PMUOE04113AA
    {
        #region ■定数、変数、構造体
        // 通信アセンブリID(通信プログラムID)
        private const int PROGRAMID_NOTHING = 0;            // なし
        private const int PROGRAMID_TOYOTA = 102;           // トヨタ
        private const int PROGRAMID_NISSAN = 202;           // ニッサン
        private const int PROGRAMID_MITSUBISHI = 301;       // ミツビシ
        private const int PROGRAMID_MATSUDA_OLD = 401;      // 旧マツダ
        private const int PROGRAMID_MATSUDA_NEW = 402;      // 新マツダ
        private const int PROGRAMID_HONDA = 501;            // ホンダ
        // ガイド区分
        private const int GUIDEDIVCD_SECTION = 3;           // 拠点区分
        // データ
        private const int ESTMTANSINFO_FIRST = 0;           // 見積回答情報初期データ位置

        // HashTable
        private Hashtable _estmtAnsInfoHTable = null;       // 見積回答情報(key：INDEX)
        private Hashtable _gridHeaderHTable = null;         // グリッドヘッダー(key：通信アセンブリID(通信プログラムID))
        private Hashtable _uoeOrderDtlHTable = null;        // UOE発注先マスタ(key：UOE発注先コード)
        private Hashtable _uoeGuideNameHTable = null;       // UOEガイド名称マスタ(key：拠点コード-UOE発注先コード)

        private string _enterpriseCode = string.Empty;      // 企業コード
        private string _sectionCode = string.Empty;         // 拠点コード
        private int _estmtAnsInfoHTableIndex = 0;           // 見積回答情報INDEX

        #region GridHeaderInfo構造体
        /// <summary>
        /// グリッドヘッダー情報　構造体
        /// </summary>
        internal struct GridHeaderInfo
        {
            private string _variableName1;      // 在庫１
            private string _variableName2;      // 在庫２
            private string _variableName3;      // 納期
            private string _variableName4;      // 代替

            /// <summary>
            /// グリッドヘッダーデータ追加
            /// </summary>
            /// <param name="variableName1">可変項目名称1(在庫数1)</param>
            /// <param name="variableName2">可変項目名称2(在庫数2)</param>
            /// <param name="variableName3">可変項目名称3(納期)</param>
            /// <param name="variableName4">可変項目名称4(代替)</param>
            public void Add(string variableName1, string variableName2, string variableName3, string variableName4)
            {
                _variableName1 = variableName1;
                _variableName2 = variableName2;
                _variableName3 = variableName3;
                _variableName4 = variableName4;
            }

            /// <summary>可変綱目名称1(在庫数1)</summary>
            public string variableName1
            {
                get { return _variableName1; }
            }
            /// <summary>可変項目名称2(在庫数2)</summary>
            public string variableName2
            {
                get { return _variableName2; }
            }
            /// <summary>可変項目名称3(納期)</summary>
            public string variableName3
            {
                get { return _variableName3; }
            }
            /// <summary>可変項目名称4(代替)</summary>
            public string variableName4
            {
                get { return _variableName4; }
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
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public PMUOE04113AA(List<EstmtSndRcvJnl> estmtSndRcvJnlList, string enterpriseCode, string sectionCode)
        {
            // 企業コード
            this._enterpriseCode = enterpriseCode;

            // 拠点コード
            this._sectionCode = sectionCode;

            // グリッドヘッダー
            this.CreateGridHeaderHTable();

            // UOEガイド名称マスタ
            this.CreateUOEGuideNameHTable();

            // UOE発注先マスタ
            this.CreateUOEOrderDtlHTable();

            // UOE送受信ジャーナルデータ
            this.CreateEstmtAnsInfoHTable(estmtSndRcvJnlList);
        }
        # endregion ■Constructor - end

        #region ■Publicメソッド
        #region ▼SearchFirst(初回検索)
        /// <summary>
        /// 初期表示データ取得
        /// </summary>
        /// <param name="supplierDataSet">グリッド明細以外(ヘッダー、グリッドヘッダー、合計)のデータ</param>
        /// <param name="detailDataSet">グリッド明細</param>
        /// <returns>True：成功、False：失敗</returns>
        /// <remarks>
        /// <br>Note       : 初期表示用データを取得します。 ※SearchBefore、SearchNextの前に呼び出す必要があります。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public bool SearchFirst(out DataSet supplierDataSet, out DataSet detailDataSet)
        {
            // 初回以外の呼び出しはNG
            if (this._estmtAnsInfoHTableIndex != -1)
            {
                supplierDataSet = null;
                detailDataSet = null;
                return false;
            }

            bool status = this.GetDispInfoAll(ESTMTANSINFO_FIRST, out supplierDataSet, out detailDataSet);
            return status;
        }
        #endregion

        #region ▼SearchBefore(前データ検索)
        /// <summary>
        /// 前データ取得
        /// </summary>
        /// <param name="supplierDataSet">グリッド明細以外(ヘッダー、グリッドヘッダー、合計)のデータ</param>
        /// <param name="detailDataSet">グリッド明細</param>
        /// <returns>True：成功、False：失敗</returns>
        /// <remarks>
        /// <br>Note       : 現在選択されているデータの1つ前のデータを取得します。データが無い場合はfalseが返ります。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public bool SearchBefore(out DataSet supplierDataSet, out DataSet detailDataSet)
        {
            // 1つ前のデータを取得
            bool status = this.GetDispInfoAll(this._estmtAnsInfoHTableIndex - 1, out supplierDataSet, out detailDataSet);
            return status;
        }
        #endregion

        #region ▼SearchNext(次データ検索)
        /// <summary>
        /// 次データ取得
        /// </summary>
        /// <param name="supplierDataSet">グリッド明細以外(ヘッダー、グリッドヘッダー、合計)のデータ</param>
        /// <param name="detailDataSet">グリッド明細</param>
        /// <returns>True：成功、False：失敗</returns>
        /// <remarks>
        /// <br>Note       : 現在選択されているデータの1つ後のデータを取得します。データが無い場合はfalseが返ります。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public bool SearchNext(out DataSet supplierDataSet, out DataSet detailDataSet)
        {
            // 1つ後のデータを取得
            bool status = this.GetDispInfoAll(this._estmtAnsInfoHTableIndex + 1, out supplierDataSet, out detailDataSet);
            return status;
        }
        #endregion
        #endregion ■Publicメソッド - end

        #region ■Privateメソッド
        #region ◆グリッドヘッダーHashTable関連
        #region ▼CreateGridHeaderHTable(HashTable作成)
        // グリッドヘッダーHashTable作成
        /// <summary>
        /// グリッドヘッダーHashTable作成
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッドヘッダーHashTableを作成します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void CreateGridHeaderHTable()
        {
            // this.SetGridHeaderInfo(通信アセンブリID(通信プログラムID), 在庫数1, 在庫数2, 納期, 代替);
            this.AddGridHeaderInfoHTable(PROGRAMID_NOTHING, "", "", "", "");                        // 初期
            this.AddGridHeaderInfoHTable(PROGRAMID_TOYOTA, "本部", "拠点", "納期", "代替");         // トヨタ
            this.AddGridHeaderInfoHTable(PROGRAMID_NISSAN, "", "", "層別", "互換");                 // ニッサン
            this.AddGridHeaderInfoHTable(PROGRAMID_MITSUBISHI, "本庫", "拠点", "価格Ｇ", "代替");   // ミツビシ
            this.AddGridHeaderInfoHTable(PROGRAMID_MATSUDA_OLD, "本庫", "拠点", "価格建", "互換");  // 旧マツダ
            this.AddGridHeaderInfoHTable(PROGRAMID_MATSUDA_NEW, "", "", "価格建", "互換");          // 新マツダ
            this.AddGridHeaderInfoHTable(PROGRAMID_HONDA, "本部", "拠点", "納期", "代替");          // ホンダ
        }
        #endregion

        #region ▼AddGridHeaderInfoHTable(HashTableにデータ追加)
        /// <summary>
        /// グリッドヘッダーHashTableデータ追加
        /// </summary>
        /// <param name="key">HashTableキー</param>
        /// <param name="Variable1">可変項目名称1</param>
        /// <param name="Variable2">可変項目名称2</param>
        /// <param name="Variable3">可変項目名称3</param>
        /// <param name="Variable4">可変項目名称4</param>
        /// <remarks>
        /// <br>Note       : 渡された値を元にHashTableにデータを追加します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void AddGridHeaderInfoHTable(int key, string Variable1, string Variable2, string Variable3, string Variable4)
        {
            if (this._gridHeaderHTable == null)
            {
                this._gridHeaderHTable = new Hashtable();
            }

            GridHeaderInfo gridHeaderInfo = new GridHeaderInfo();
            gridHeaderInfo.Add(Variable1, Variable2, Variable3, Variable4);

            // HashTableに追加(キー：通信アセンブリID(通信プログラムID))
            this._gridHeaderHTable[key] = gridHeaderInfo;
        }
        #endregion

        #region ▼GetHeaderVariableaName(HashTable→DataRowコピー)
        /// <summary>
        /// グリッドヘッダーHashTableデータ取得
        /// </summary>
        /// <param name="estmtSndRcvJnl">UOE送受信ジャーナル(見積)</param>
        /// <param name="dataRow">グリッドヘッダー保存用DataRow</param>
        /// <remarks>
        /// <br>Note       : グリッドヘッダーHashTableよりデータを取得し、DataRowに保存します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void GetHeaderVariableName(EstmtSndRcvJnl estmtSndRcvJnl, ref DataRow dataRow)
        {
            // UOE発注先を元に通信アセンブリID(通信プログラムID)を取得
            int programId = this.GetProgramIdFromUOEOrderDtlHTable(estmtSndRcvJnl.UOESupplierCd);

            // ヘッダー情報取得
            if (this._gridHeaderHTable.ContainsKey(programId) == false )
            {
                dataRow[PMUOE04112EA.ct_Col_GridHeadVariableName1] = string.Empty;
                dataRow[PMUOE04112EA.ct_Col_GridHeadVariableName2] = string.Empty;
                dataRow[PMUOE04112EA.ct_Col_GridHeadVariableName3] = string.Empty;
                dataRow[PMUOE04112EA.ct_Col_GridHeadVariableName4] = string.Empty;
                return;
            }

            GridHeaderInfo gridHeaderInfo = (GridHeaderInfo)this._gridHeaderHTable[programId];

            if (programId == PROGRAMID_MATSUDA_NEW)
            {
                // 新マツダのみUOEガイド名称マスタより取得
                dataRow[PMUOE04112EA.ct_Col_GridHeadVariableName1] = this.GetUOEGuideNm(estmtSndRcvJnl.UOESectionCode1, estmtSndRcvJnl.UOESupplierCd);
                dataRow[PMUOE04112EA.ct_Col_GridHeadVariableName2] = this.GetUOEGuideNm(estmtSndRcvJnl.UOESectionCode2, estmtSndRcvJnl.UOESupplierCd);
            }
            else
            {
                dataRow[PMUOE04112EA.ct_Col_GridHeadVariableName1] = gridHeaderInfo.variableName1;
                dataRow[PMUOE04112EA.ct_Col_GridHeadVariableName2] = gridHeaderInfo.variableName2;
            }
            dataRow[PMUOE04112EA.ct_Col_GridHeadVariableName3] = gridHeaderInfo.variableName3;
            dataRow[PMUOE04112EA.ct_Col_GridHeadVariableName4] = gridHeaderInfo.variableName4;
        }
        #endregion
        #endregion ◆グリッドヘッダーHashTable関連 - end

        #region ◆UOE発注先マスタHashTable関連
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
            int status = uoeSupplierAcs.Search(ref retDataSet, this._enterpriseCode,this._sectionCode);
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

                this._uoeOrderDtlHTable[key] = dataRow["CommAssemblyId"].ToString();
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

            // データが無い
            if (this._uoeOrderDtlHTable == null)
            {
                return programId;
            }

            // INDEX範囲外
            if (this._uoeOrderDtlHTable.ContainsKey(uoeSupplierCd) == false)
            {
                return programId;
            }

            bool ret = int.TryParse(this._uoeOrderDtlHTable[uoeSupplierCd].ToString(), out programId);
            return programId;
        }
        #endregion
        #endregion ◆UOE発注先マスタHashTable関連 - end

        #region ◆UOEガイド名称マスタHashTable関連
        #region ▼CreateUOEGuideNameHTable(HashTable作成)
        /// <summary>
        /// UOEガイド名称マスタHashTable作成
        /// </summary>
        /// <remarks>
        /// <br>Note       : UOEガイド名称マスタを元にHashTableを作成します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void CreateUOEGuideNameHTable()
        {
            // 抽出条件
            UOEGuideName uoeGuideName = new UOEGuideName();
            uoeGuideName.EnterpriseCode = this._enterpriseCode;     // 企業コード
            uoeGuideName.SectionCode = this._sectionCode;           // 拠点コード
            uoeGuideName.UOEGuideDivCd = GUIDEDIVCD_SECTION;        // ガイド区分(3:拠点 固定)

            // UOEガイド名称マスタデータ取得(PMUOE09032A)
            UOEGuideNameAcs uoeGuideNameAcs = new UOEGuideNameAcs();
            DataSet retDataSet = new DataSet();
            int status = uoeGuideNameAcs.Search(ref retDataSet, uoeGuideName);
            // 異常
            if (status != 0)
            {
                this._uoeGuideNameHTable = null;
                return;
            }
            // データなし
            if (retDataSet == null)
            {
                this._uoeGuideNameHTable = null;
                return;
            }

            // HashTable作成
            this._uoeGuideNameHTable = new Hashtable();
            foreach (DataRow dataRow in retDataSet.Tables[retDataSet.Tables[0].TableName].Rows)
            {
                string key = dataRow["UOEGuideCode"].ToString() + "-" + dataRow["UOESupplierCd"].ToString();    // キー：ガイドコード(UOE拠点コード)-UOE発注先コード
                this._uoeGuideNameHTable[key] = dataRow["UOEGuideNm"].ToString();
            }
        }
        #endregion

        #region ▼GetUOEGuideNm(UOEガイド名称取得)
        /// <summary>
        /// UOEガイド名称取得
        /// </summary>
        /// <param name="uoeSectionCode">拠点コード</param>
        /// <param name="uoeSupplierCd">UOE発注先コード</param>
        /// <returns>UOEガイド名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点、UOE発注先コードを元にUOEガイド名称マスタHashTableからUOEガイド名称を取得します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private string GetUOEGuideNm(string uoeSectionCode, int uoeSupplierCd)
        {
            if (this._uoeGuideNameHTable == null)
            {
                int code = 0;
                bool ret = int.TryParse(uoeSectionCode, out code);
                //return code.ToString("0000");         //DEL 2008/12/19
                return code.ToString();                 //ADD 2008/12/19
            }

            string key = uoeSectionCode + "-" + uoeSupplierCd.ToString();
            if (this._uoeGuideNameHTable.ContainsKey(key))
            {
                return this._uoeGuideNameHTable[key].ToString();
            }
            else
            {
                int code = 0;
                bool ret = int.TryParse(uoeSectionCode, out code);
                //return code.ToString("0000");         //DEL 2008/12/19
                return code.ToString();                 //ADD 2008/12/19   
            }
        }
        #endregion
        #endregion ◆UOEガイド名称マスタHashTable関連 - end

        #region ◆見積回答情報HashTable関連
        #region ▼CreateEstmtAnsInfoHTable(HashTable作成)
        /// <summary>
        /// 見積回答情報HashTable作成
        /// </summary>
        /// <param name="estmtSndRcvJnlList">UOE送受信ジャーナル(見積)リスト</param>
        /// <remarks>
        /// <br>Note       : 渡されたUOE送受信ジャーナル(見積)リストをUOE発注先、UOE発注番号単位にまとめてHashTableに格納します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void CreateEstmtAnsInfoHTable(List<EstmtSndRcvJnl> estmtSndRcvJnlList)
        {

            string bfKey = string.Empty;
            int listCnt = 0;
            int hashTableCnt = 0;
            List<EstmtSndRcvJnl> estmtAnsInfoListGroup = new List<EstmtSndRcvJnl>();

            this._estmtAnsInfoHTable = new Hashtable();
            foreach (EstmtSndRcvJnl estmtSndRcvJnl in estmtSndRcvJnlList)
            {
                // キー：UOE発注先-UOE発注番号
                string key = estmtSndRcvJnl.UOESupplierCd + "-" + estmtSndRcvJnl.UOESalesOrderNo;

                if ((bfKey != key) && (bfKey != string.Empty))
                {
                    // 最初以外でキーが変わった時
                    // UOE発注先,発注番号単位にまとめたデータをHashTableに追加
                    this._estmtAnsInfoHTable[hashTableCnt] = estmtAnsInfoListGroup;
                    hashTableCnt++;

                    // 初期化
                    estmtAnsInfoListGroup = new List<EstmtSndRcvJnl>();
                    listCnt = 0;
                }

                estmtAnsInfoListGroup.Add(estmtSndRcvJnl);
                listCnt++;

                bfKey = key;
            }

            // 最後のデータをHashTableに追加
            this._estmtAnsInfoHTable[hashTableCnt] = estmtAnsInfoListGroup;

            // 初期位置
            this._estmtAnsInfoHTableIndex = -1;
        }
        #endregion

        #region ▼GetDispInfoAll(HashTableデータ取得)
        /// <summary>
        /// 見積回答情報HashTableデータ取得
        /// </summary>
        /// <param name="index">検索位置</param>
        /// <param name="supplierDataSet">グリッド明細以外(ヘッダー、グリッドヘッダー、合計)のデータ</param>
        /// <param name="detailDataSet">グリッド明細データ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 指定されたindexを元に見積回答情報HashTableからデータを取得します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private bool GetDispInfoAll(int index, out DataSet supplierDataSet, out DataSet detailDataSet)
        {
            detailDataSet = null;
            supplierDataSet = null;

            // データが無い
            if (this._estmtAnsInfoHTable == null)
            {
                return false;
            }

            // INDEX範囲外
            if (this._estmtAnsInfoHTable.ContainsKey(index) == false)
            {
                return false;
            }

            // 明細以外用DataTable作成
            DataTable supplierDataTable = null;
            PMUOE04112EA.CreateDataTableSupplier(ref supplierDataTable);

            // 明細用DataTable作成
            DataTable detailDataTable = null;
            PMUOE04112EA.CreateDataTableDetail(ref detailDataTable);

            double answerListPriceTotal = 0;
            double answerSalesUnitCostTotal = 0;
            DataRow supplierDataRow = supplierDataTable.NewRow();

            List<EstmtSndRcvJnl> estmtSndRcvJnlList = (List<EstmtSndRcvJnl>)this._estmtAnsInfoHTable[index];
            foreach (EstmtSndRcvJnl estmtSndRcvJnl in estmtSndRcvJnlList)
            {
                // 最初のみ
                if (detailDataTable.Rows.Count == 0)
                {
                    // 画面表示用発注先情報取得
                    supplierDataRow[PMUOE04112EA.ct_Col_UOESupplierName] = estmtSndRcvJnl.UOESupplierName;  // 発注先
                    supplierDataRow[PMUOE04112EA.ct_Col_UoeRemark1] = estmtSndRcvJnl.UoeRemark1;            // リマーク１
                    supplierDataRow[PMUOE04112EA.ct_Col_UoeRemark2] = estmtSndRcvJnl.UoeRemark2;            // リマーク２

                    // グリッドヘッダー情報作成
                    this.GetHeaderVariableName(estmtSndRcvJnl, ref supplierDataRow);
                }

                // dataRow作成
                DataRow detailDataRow = detailDataTable.NewRow();
                this.CopyToDataRowFromEstmtSndRcvJnl(estmtSndRcvJnl, ref detailDataRow);

                detailDataTable.Rows.Add(detailDataRow);

                // 合計算出
                /* ---DEL 2009/01/20 不具合対応[10256] ----------------------------------------->>>>>
                //answerListPriceTotal += estmtSndRcvJnl.AnswerListPrice;
                //answerSalesUnitCostTotal += estmtSndRcvJnl.AnswerSalesUnitCost;
                   ---DEL 2009/01/20 不具合対応[10256] -----------------------------------------<<<<< */
                // ---ADD 2009/01/20 不具合対応[10256] ----------------------------------------->>>>>
                answerListPriceTotal += estmtSndRcvJnl.AnswerListPrice * estmtSndRcvJnl.AcceptAnOrderCnt;               // 見積合計
                answerSalesUnitCostTotal += estmtSndRcvJnl.AnswerSalesUnitCost * estmtSndRcvJnl.AcceptAnOrderCnt;       // 仕切合計
                // ---ADD 2009/01/20 不具合対応[10256] -----------------------------------------<<<<<
            }

            // 画面表示用合計値作成
            supplierDataRow[PMUOE04112EA.ct_Col_AnswerListPriceTotal] = answerListPriceTotal.ToString("#,##0");             // 標準価格合計
            supplierDataRow[PMUOE04112EA.ct_Col_AnswerSalesUnitCostTotal] = answerSalesUnitCostTotal.ToString("#,##0");     // 原単価合計

            supplierDataTable.Rows.Add(supplierDataRow);

            // 戻り値用DataSet作成
            supplierDataSet = new DataSet();
            supplierDataSet.Tables.Add(supplierDataTable);

            detailDataSet = new DataSet();
            detailDataSet.Tables.Add(detailDataTable);

            this._estmtAnsInfoHTableIndex = index;      // 現在の位置
            return true;
        }
        #endregion

        #region ▼CopyToDataRowFromEstmtSndRcvJnl(UOE送受信ジャーナル→DataRowコピー)
        /// <summary>
        /// UOE送受信ジャーナル(見積)→DataRow作成
        /// </summary>
        /// <param name="dataRow"></param>
        /// <param name="estmtSndRcvJnl"></param>
        /// <remarks>
        /// <br>Note       : UOE送受信ジャーナル(見積)の内容を元にDataRowを作成します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void CopyToDataRowFromEstmtSndRcvJnl(EstmtSndRcvJnl estmtSndRcvJnl, ref DataRow dataRow)
        {
            dataRow[PMUOE04112EA.ct_Col_UOESalesOrderRowNo] = estmtSndRcvJnl.UOESalesOrderRowNo;    // UOE発注行番号
            dataRow[PMUOE04112EA.ct_Col_GoodsNo] = estmtSndRcvJnl.GoodsNo;                          // 品番
            // メーカー
            if (estmtSndRcvJnl.GoodsMakerCd == 0)
            {
                dataRow[PMUOE04112EA.ct_Col_GoodsMakerCd] = "";
            }
            else
            {
                dataRow[PMUOE04112EA.ct_Col_GoodsMakerCd] = estmtSndRcvJnl.GoodsMakerCd.ToString("0000");
            }
            /* ---DEL 2009/01/20 不具合対応[10208] ----------------------------------------------------------------------------------->>>>>
            //dataRow[PMUOE04112EA.ct_Col_GoodsName] = estmtSndRcvJnl.GoodsName;                      // 品名       //DEL 2008/12/10 回答品名を表示
            dataRow[PMUOE04112EA.ct_Col_GoodsName] = estmtSndRcvJnl.AnswerPartsName;                // 回答品名     //ADD 2008/12/10
               ---DEL 2009/01/20 不具合対応[10208] -----------------------------------------------------------------------------------<<<<< */
            dataRow[PMUOE04112EA.ct_Col_GoodsName] = estmtSndRcvJnl.GoodsName;                      // 回答品名     //ADD 2009/01/20 不具合対応[10208]
            dataRow[PMUOE04112EA.ct_Col_AcceptAnOrderCnt] = estmtSndRcvJnl.AcceptAnOrderCnt;        // 数量
            dataRow[PMUOE04112EA.ct_Col_AnswerListPrice] = estmtSndRcvJnl.AnswerListPrice;          // 標準価格
            dataRow[PMUOE04112EA.ct_Col_AnswerSalesUnitCost] = estmtSndRcvJnl.AnswerSalesUnitCost;  // 原単価

            // コメント
            /* ---DEL 2009/01/22 不具合対応[10344] ------------------------------------------->>>>>
            if (string.IsNullOrEmpty(estmtSndRcvJnl.HeadErrorMassage) == false)
            {
                dataRow[PMUOE04112EA.ct_Col_Comment] = estmtSndRcvJnl.HeadErrorMassage;
            }
            else if (string.IsNullOrEmpty(estmtSndRcvJnl.LineErrorMassage) == false)
            {
                dataRow[PMUOE04112EA.ct_Col_Comment] = estmtSndRcvJnl.LineErrorMassage;
            }
            else if (string.IsNullOrEmpty(estmtSndRcvJnl.SubstPartsNo) == false)
            {
                dataRow[PMUOE04112EA.ct_Col_Comment] = estmtSndRcvJnl.SubstPartsNo;
            }
            else
            {
                dataRow[PMUOE04112EA.ct_Col_Comment] = string.Empty;
            }
               ---DEL 2009/01/22 不具合対応[10344] -------------------------------------------<<<<< */
            // ---DEL 2009/01/22 不具合対応[10344] ------------------------------------------->>>>>
            if (string.IsNullOrEmpty(estmtSndRcvJnl.HeadErrorMassage.Trim()) == false)
            {
                dataRow[PMUOE04112EA.ct_Col_Comment] = estmtSndRcvJnl.HeadErrorMassage;
            }
            else if (string.IsNullOrEmpty(estmtSndRcvJnl.LineErrorMassage.Trim()) == false)
            {
                dataRow[PMUOE04112EA.ct_Col_Comment] = estmtSndRcvJnl.LineErrorMassage;
            }
            else if (string.IsNullOrEmpty(estmtSndRcvJnl.SubstPartsNo.Trim()) == false)
            {
                dataRow[PMUOE04112EA.ct_Col_Comment] = estmtSndRcvJnl.SubstPartsNo;
            }
            else
            {
                dataRow[PMUOE04112EA.ct_Col_Comment] = string.Empty;
            }
            // ---DEL 2009/01/22 不具合対応[10344] -------------------------------------------<<<<<

            #region 可変項目
            // UOE発注先を元に通信アセンブリID(通信プログラムID)取得
            int programId = this.GetProgramIdFromUOEOrderDtlHTable(estmtSndRcvJnl.UOESupplierCd);

            switch (programId)
            {
                case PROGRAMID_TOYOTA:
                    {
                        dataRow[PMUOE04112EA.ct_Col_Variable1] = estmtSndRcvJnl.HeadQtrsStock;      // 本部在庫
                        dataRow[PMUOE04112EA.ct_Col_Variable2] = estmtSndRcvJnl.BranchStock;        // 拠点在庫
                        dataRow[PMUOE04112EA.ct_Col_Variable3] = estmtSndRcvJnl.UOEDelivDateCd;     // UOE納期コード
                        dataRow[PMUOE04112EA.ct_Col_Variable4] = estmtSndRcvJnl.UOESubstCode;       // UOE代替コード
                        break;
                    }
                case PROGRAMID_NISSAN:
                    {
                        dataRow[PMUOE04112EA.ct_Col_Variable1] = string.Empty;                      // なし
                        dataRow[PMUOE04112EA.ct_Col_Variable2] = string.Empty;                      // なし
                        dataRow[PMUOE04112EA.ct_Col_Variable3] = estmtSndRcvJnl.PartsLayerCd;       // 層別
                        dataRow[PMUOE04112EA.ct_Col_Variable4] = estmtSndRcvJnl.UOESubstCode;       // UOE代替コード
                        break;
                    }
                case PROGRAMID_MITSUBISHI:
                    {
                        dataRow[PMUOE04112EA.ct_Col_Variable1] = estmtSndRcvJnl.HeadQtrsStock;      // 本部在庫
                        dataRow[PMUOE04112EA.ct_Col_Variable2] = estmtSndRcvJnl.BranchStock;        // 拠点在庫
                        dataRow[PMUOE04112EA.ct_Col_Variable3] = estmtSndRcvJnl.UOEPriceCode;       // UOE価格コード
                        dataRow[PMUOE04112EA.ct_Col_Variable4] = estmtSndRcvJnl.UOESubstCode;       // UOE代替コード
                        break;
                    }
                case PROGRAMID_MATSUDA_OLD:
                    {
                        dataRow[PMUOE04112EA.ct_Col_Variable1] = estmtSndRcvJnl.HeadQtrsStock;      // 本部在庫
                        dataRow[PMUOE04112EA.ct_Col_Variable2] = estmtSndRcvJnl.BranchStock;        // 拠点在庫
                        dataRow[PMUOE04112EA.ct_Col_Variable3] = estmtSndRcvJnl.UOEPriceCode;       // UOE価格コード
                        dataRow[PMUOE04112EA.ct_Col_Variable4] = estmtSndRcvJnl.UOESubstCode;       // UOE代替コード
                        break;
                    }
                case PROGRAMID_MATSUDA_NEW:
                    {
                        dataRow[PMUOE04112EA.ct_Col_Variable1] = estmtSndRcvJnl.UOESectionStock1;   // UOE拠点在庫1
                        dataRow[PMUOE04112EA.ct_Col_Variable2] = estmtSndRcvJnl.UOESectionStock2;   // UOE拠点在庫2
                        dataRow[PMUOE04112EA.ct_Col_Variable3] = estmtSndRcvJnl.UOEPriceCode;       // UOE価格コード
                        dataRow[PMUOE04112EA.ct_Col_Variable4] = estmtSndRcvJnl.UOESubstCode;       // UOE代替コード
                        break;
                    }
                case PROGRAMID_HONDA:
                    {
                        dataRow[PMUOE04112EA.ct_Col_Variable1] = estmtSndRcvJnl.HeadQtrsStock;      // 本部在庫
                        dataRow[PMUOE04112EA.ct_Col_Variable2] = estmtSndRcvJnl.BranchStock;        // 拠点在庫
                        dataRow[PMUOE04112EA.ct_Col_Variable3] = estmtSndRcvJnl.UOEDelivDateCd;     // UOE納期コード
                        dataRow[PMUOE04112EA.ct_Col_Variable4] = estmtSndRcvJnl.UOESubstCode;       // UOE代替コード
                        break;
                    }
                default:
                    {
                        dataRow[PMUOE04112EA.ct_Col_Variable1] = string.Empty;                      // 本部在庫
                        dataRow[PMUOE04112EA.ct_Col_Variable2] = string.Empty;                      // 拠点在庫
                        dataRow[PMUOE04112EA.ct_Col_Variable3] = string.Empty;                      // UOE納期コード
                        dataRow[PMUOE04112EA.ct_Col_Variable4] = string.Empty;                      // 代替
                        break;
                    }
            }
            #endregion
        }
        #endregion
        #endregion ◆見積回答情報HashTable関連 - end
        #endregion ■Privateメソッド - end
    }
}


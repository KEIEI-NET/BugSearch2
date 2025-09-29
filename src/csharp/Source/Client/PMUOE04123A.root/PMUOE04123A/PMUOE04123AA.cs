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
    /// 在庫回答表示　アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 在庫回答表示に関するアクセス制御を行います。</br>
    /// <br>Programmer	: 照田 貴志</br>
    /// <br>Date		: 2008/11/10</br>
    /// <br>UpdateNote  : 2008/12/10 照田 貴志　品名には回答品名を表示</br>
    /// <br>              2008/12/18 照田 貴志　バグ修正、仕様変更対応</br>
    /// <br>              ①在庫表示MAX数変更</br>
    /// <br>              2009/01/20 照田 貴志　不具合対応[10207]</br>
    /// <br>              2009/02/03 照田 貴志　不具合対応[10841]</br>
    /// <br>              2010/05/27 堀田 剛生　明治UOE対応</br>
    /// </remarks>
    public class PMUOE04123AA
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
        private const int PROGRAMID_PRIME = 1001;           // 優良
        private const int PROGRAMID_PRIME_MEIJI = 1004;     // 優良             //ADD 2010/05/27
        // 拠点データ表示件数
        private const int SECTIONDISP_TOYOTA = 33;         // トヨタ            //ADD 2008/12/18 ①
        private const int SECTIONDISP_NISSAN = 35;         // ニッサン          //ADD 2008/12/18 ①
        private const int SECTIONDISP_MITSUBISHI = 32;     // ミツビシ          //ADD 2008/12/18 ①
        private const int SECTIONDISP_MATSUDA_OLD = 3;    // 旧マツダ           //ADD 2008/12/18 ①
        private const int SECTIONDISP_MATSUDA_NEW = 8;      // 新マツダ
        //private const int SECTIONDISP_HONDA = 8;            // ホンダ         //DEL 2008/12/18 ①
        //private const int SECTIONDISP_HONDA = 5;            // ホンダ           //ADD 2008/12/18 ①　→ DEL 2009/02/03　不具合対応[10841]
        private const int SECTIONDISP_HONDA = 6;            // ホンダ           //ADD 2009/02/03　不具合対応[10841]
        private const int SECTIONDISP_PRIME = 2;            // 優良(1：拠点、2：センター)
        private const int SECTIONDISP_DEFAULT = 35;         // その他

        // ガイド区分
        private const int GUIDEDIVCD_SECTION = 3;           // 拠点区分
        // データ
        private const int STOCKANSINFO_FIRST = 0;           // 在庫回答情報初期データ位置

        // HashTable
        private Hashtable _stockAnsInfoHTable = null;       // 在庫回答情報(key：INDEX)
        private Hashtable _sectionInfoHTable = null;        // 拠点情報(key：UOE発注先コード-UOE発注番号-UOE発注行番号)
        private Hashtable _uoeOrderDtlHTable = null;        // UOE発注先マスタ(key：UOE発注先コード)
        private Hashtable _uoeGuideNameHTable = null;       // UOEガイド名称マスタ(key：拠点コード-UOE発注先コード)

        private string _enterpriseCode = string.Empty;      // 企業コード
        private string _sectionCode = string.Empty;         // 拠点コード
        private int _stockAnsInfoHTableIndex = 0;           // 在庫回答情報INDEX

        # region SectionInfo構造体
        /// <summary>
        /// 拠点情報　構造体
        /// </summary>
        internal struct SectionInfo
        {
            private string _uoeSection;     // 拠点情報
            //private int _uoeSectionStock;   // 在庫数     //DEL 2009/02/03　不具合対応[10841]
            private string _uoeSectionStock;   // 在庫数    //ADD 2009/02/03　不具合対応[10841]

            /// <summary>
            /// 拠点情報追加
            /// </summary>
            /// <param name="uoeSection">拠点情報</param>
            /// <param name="uoeSectionStock">在庫数</param>
            public void Add(string uoeSection, int uoeSectionStock)
            {
                this._uoeSection = uoeSection;
                //this._uoeSectionStock = uoeSectionStock;                  //DEL 2009/02/03　不具合対応[10841]
                this._uoeSectionStock = uoeSectionStock.ToString("#,###");  //ADD 2009/02/03　不具合対応[10841]
            }
            // ---ADD 2009/02/03　不具合対応[10841] ----------->>>>>
            public void Add(string uoeSection, string uoeSectionStock)
            {
                this._uoeSection = uoeSection;
                this._uoeSectionStock = uoeSectionStock;
            }
            // ---ADD 2009/02/03　不具合対応[10841] -----------<<<<<

            /// <summary>拠点情報</summary>
            public string UOESection
            {
                get { return _uoeSection; }
            }
            /* ---DEL 2009/02/03　不具合対応[10841] ------------>>>>>
            /// <summary>在庫数</summary>
            public int UOESectionStock
            {
                get { return _uoeSectionStock; }
            }
               ---DEL 2009/02/03　不具合対応[10841] ------------<<<<< */
            // ---ADD 2009/02/03　不具合対応[10841] ------------>>>>>
            /// <summary>在庫数</summary>
            public string UOESectionStock
            {
                get { return _uoeSectionStock; }
            }
            // ---ADD 2009/02/03　不具合対応[10841] ------------<<<<<
        }
        # endregion
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
        public PMUOE04123AA(List<StockSndRcvJnl> stockSndRcvJnlList, string enterpriseCode, string sectionCode)
        {
            // 企業コード
            this._enterpriseCode = enterpriseCode;

            // 拠点コード
            this._sectionCode = sectionCode;

            // UOEガイド名称マスタ
            this.CreateUOEGuideNameHTable();

            // UOE発注先マスタ
            this.CreateUOEOrderDtlHTable();

            // UOE送受信ジャーナルデータ
            this.CreateStockAnsInfoHTable(stockSndRcvJnlList);
        }
        # endregion ■Constructor - end

        #region ■Publicメソッド
        #region ▼SearchFirst(初回検索)
        /// <summary>
        /// 初期表示データ取得
        /// </summary>
        /// <param name="supplierDataSet">グリッド以外(ヘッダー)のデータ</param>
        /// <param name="detailDataSet">明細データ</param>
        /// <returns>True：成功、False：失敗</returns>
        /// <remarks>
        /// <br>Note       : 初期表示用データを取得します。 ※SearchBefore、SearchNextの前に呼び出す必要があります。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public bool SearchFirst(out DataSet supplierDataSet, out DataSet detailDataSet)
        {
            // 初回以外の呼び出しはNG
            if (this._stockAnsInfoHTableIndex != -1)
            {
                supplierDataSet = null;
                detailDataSet = null;
                return false;
            }

            bool status = this.GetDispInfoAll(STOCKANSINFO_FIRST, out supplierDataSet, out detailDataSet);
            return status;
        }
        #endregion

        #region ▼SearchBefore(前データ検索)
        /// <summary>
        /// 前データ取得
        /// </summary>
        /// <param name="supplierDataSet">グリッド以外(ヘッダー)のデータ</param>
        /// <param name="detailDataSet">明細データ</param>
        /// <returns>True：成功、False：失敗</returns>
        /// <remarks>
        /// <br>Note       : 現在選択されているデータの1つ前のデータを取得します。データが無い場合はfalseが返ります。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public bool SearchBefore(out DataSet supplierDataSet, out DataSet detailDataSet)
        {
            // 1つ前のデータを取得
            bool status = this.GetDispInfoAll(this._stockAnsInfoHTableIndex - 1, out supplierDataSet, out detailDataSet);
            return status;
        }
        #endregion

        #region ▼SearchNext(次データ検索)
        /// <summary>
        /// 次データ取得
        /// </summary>
        /// <param name="supplierDataSet">グリッド以外(ヘッダー)のデータ</param>
        /// <param name="detailDataSet">明細データ</param>
        /// <returns>True：成功、False：失敗</returns>
        /// <remarks>
        /// <br>Note       : 現在選択されているデータの1つ後のデータを取得します。データが無い場合はfalseが返ります。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public bool SearchNext(out DataSet supplierDataSet, out DataSet detailDataSet)
        {
            // 1つ後のデータを取得
            bool status = this.GetDispInfoAll(this._stockAnsInfoHTableIndex + 1, out supplierDataSet, out detailDataSet);
            return status;
        }
        #endregion

        #region ▼GetSectionInfoDataSet(拠点グリッド用データセット取得)
        /// <summary>
        /// 拠点グリッド用データセット取得
        /// </summary>
        /// <param name="uoeSupplierCd"></param>
        /// <param name="uoeSalesOrderNo"></param>
        /// <param name="uoeSalesOrderNoRow"></param>
        /// <returns>拠点グリッド用データセット</returns>
        /// <remarks>
        /// <br>Note       : 発注先コード、発注番号、発注行番号を元に拠点グリッド用のデータセットを取得します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public DataSet GetSectionInfoDataSet(int uoeSupplierCd, int uoeSalesOrderNo, int uoeSalesOrderNoRow)
        {
            string sectionInfoListkKey = uoeSupplierCd + "-" + uoeSalesOrderNo + "-" + uoeSalesOrderNoRow;
            return CopyToDataSetFromSectionInfoList(uoeSupplierCd, sectionInfoListkKey);
        }
        #endregion
        #endregion ■Publicメソッド - end

        #region ■Privateメソッド
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
                string key = dataRow["UOEGuideCode"].ToString() + "-" + dataRow["UOESupplierCd"].ToString();    // キー：拠点コード-UOE発注先コード
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
                return string.Empty;
            }

            string key = uoeSectionCode + "-" + uoeSupplierCd.ToString();
            if (this._uoeGuideNameHTable.ContainsKey(key))
            {
                return this._uoeGuideNameHTable[key].ToString();
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion
        #endregion ◆UOEガイド名称マスタHashTable関連 - end

        #region ◆在庫回答情報HashTable関連
        #region ▼CreateStockAnsInfoHTable(HashTable作成)
        /// <summary>
        /// 在庫回答情報HashTable作成
        /// </summary>
        /// <param name="stockSndRcvJnlList">UOE送受信ジャーナル(在庫)リスト</param>
        /// <remarks>
        /// <br>Note       : 渡されたUOE送受信ジャーナル(在庫)リストをUOE発注先、UOE発注番号単位にまとめてHashTableに格納します。</br>
        /// <br>             同時に拠点用HashTableの作成を行います。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void CreateStockAnsInfoHTable(List<StockSndRcvJnl> stockSndRcvJnlList)
        {
            string bfKey = string.Empty;
            int listCnt = 0;
            int hashTableCnt = 0;
            List<StockSndRcvJnl> stockAnsInfoListGroup = new List<StockSndRcvJnl>();

            this._stockAnsInfoHTable = new Hashtable();
            this._sectionInfoHTable = new Hashtable();
            foreach (StockSndRcvJnl stockSndRcvJnl in stockSndRcvJnlList)
            {
                // キー：UOE発注先-UOE発注番号
                string key = stockSndRcvJnl.UOESupplierCd + "-" + stockSndRcvJnl.UOESalesOrderNo;

                if ((bfKey != key) && (bfKey != string.Empty))
                {
                    // 最初以外でキーが変わった時
                    // UOE発注先,発注番号単位にまとめたデータをHashTableに追加
                    this._stockAnsInfoHTable[hashTableCnt] = stockAnsInfoListGroup;
                    hashTableCnt++;

                    // 初期化
                    stockAnsInfoListGroup = new List<StockSndRcvJnl>();
                    listCnt = 0;
                }

                stockAnsInfoListGroup.Add(stockSndRcvJnl);
                listCnt++;

                // 拠点データをHashTableに追加
                this.CreateSectionInfoHTable(stockSndRcvJnl);

                bfKey = key;
            }

            // 最後のデータをHashTableに追加
            this._stockAnsInfoHTable[hashTableCnt] = stockAnsInfoListGroup;

            // 初期位置
            this._stockAnsInfoHTableIndex = -1;
        }
        #endregion

        #region ▼GetDispInfoAll(HashTableデータ取得)
        /// <summary>
        /// 在庫回答情報HashTableデータ取得
        /// </summary>
        /// <param name="index">検索位置</param>
        /// <param name="supplierDataSet">グリッド以外(ヘッダー)のデータ</param>
        /// <param name="detailDataSet">明細データ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 指定されたindexを元に在庫回答情報HashTableからデータを取得します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private bool GetDispInfoAll(int index, out DataSet supplierDataSet, out DataSet detailDataSet)
        {
            detailDataSet = null;
            supplierDataSet = null;

            // データが無い
            if (this._stockAnsInfoHTable == null)
            {
                return false;
            }

            // INDEX範囲外
            if (this._stockAnsInfoHTable.ContainsKey(index) == false)
            {
                return false;
            }

            // グリッド以外用DataTable作成
            DataTable supplierDataTable = null;
            PMUOE04122EA.CreateDataTableSupplier(ref supplierDataTable);

            // 明細用DataTable作成
            DataTable detailDataTable = null;
            PMUOE04122EA.CreateDataTableDetail(ref detailDataTable);

            // 発注先用dataRow
            DataRow supplierDataRow = supplierDataTable.NewRow();

            List<StockSndRcvJnl> stockSndRcvJnlList = (List<StockSndRcvJnl>)this._stockAnsInfoHTable[index];
            foreach (StockSndRcvJnl stockSndRcvJnl in stockSndRcvJnlList)
            {
                // 最初のみ
                if (detailDataTable.Rows.Count == 0)
                {
                    // 画面表示用発注先情報取得
                    supplierDataRow[PMUOE04122EA.ct_Col_UOESupplierName] = stockSndRcvJnl.UOESupplierName;  // 発注先
                    supplierDataRow[PMUOE04122EA.ct_Col_UoeRemark1] = stockSndRcvJnl.UoeRemark1;            // リマーク１
                    supplierDataRow[PMUOE04122EA.ct_Col_UoeRemark2] = stockSndRcvJnl.UoeRemark2;            // リマーク２
                }

                // 明細用dataRow
                DataRow detailDataRow = detailDataTable.NewRow();
                this.CopyToDataRowFromStockSndRcvJnl(stockSndRcvJnl, ref detailDataRow);

                detailDataTable.Rows.Add(detailDataRow);
            }

            supplierDataTable.Rows.Add(supplierDataRow);

            // グリッド以外項目用DataSet作成
            supplierDataSet = new DataSet();
            supplierDataSet.Tables.Add(supplierDataTable);

            // 明細用DataSet作成
            detailDataSet = new DataSet();
            detailDataSet.Tables.Add(detailDataTable);

            this._stockAnsInfoHTableIndex = index;      // 現在の位置
            return true;
        }
        #endregion

        #region ▼CopyToDataRowFromStockSndRcvJnl(UOE送受信ジャーナル→DataRowコピー)
        /// <summary>
        /// UOE送受信ジャーナル(在庫)→DataRow作成
        /// </summary>
        /// <param name="stockSndRcvJnl">コピー元</param>
        /// <param name="dataRow">コピー先</param>
        /// <remarks>
        /// <br>Note       : UOE送受信ジャーナル(在庫)の内容を元にDataRowを作成します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void CopyToDataRowFromStockSndRcvJnl(StockSndRcvJnl stockSndRcvJnl, ref DataRow dataRow)
        {
            dataRow[PMUOE04122EA.ct_Col_UOESupplierCd] = stockSndRcvJnl.UOESupplierCd;                      // UOE発注先コード
            dataRow[PMUOE04122EA.ct_Col_UOESalesOrder] = stockSndRcvJnl.UOESalesOrderNo;                    // UOE発注番号
            dataRow[PMUOE04122EA.ct_Col_UOESalesOrderRowNo] = stockSndRcvJnl.UOESalesOrderRowNo;            // UOE発注行番号
            dataRow[PMUOE04122EA.ct_Col_GoodsNo] = stockSndRcvJnl.GoodsNo;                                  // 品番
            // メーカー
            if (stockSndRcvJnl.GoodsMakerCd == 0)
            {
                dataRow[PMUOE04122EA.ct_Col_GoodsMakerCd] = string.Empty;
            }
            else
            {
                dataRow[PMUOE04122EA.ct_Col_GoodsMakerCd] = stockSndRcvJnl.GoodsMakerCd.ToString("0000");       
            }
            /* ---DEL 2009/01/20 不具合対応[10207] ----------------------------------------------------------------------------------->>>>>
            //dataRow[PMUOE04122EA.ct_Col_GoodsName] = stockSndRcvJnl.GoodsName;                              // 品名       //DEL 2008/12/10 回答品名を表示
            dataRow[PMUOE04122EA.ct_Col_GoodsName] = stockSndRcvJnl.AnswerPartsName;                        // 回答品名     //ADD 2008/12/10
               ---DEL 2009/01/20 不具合対応[10207] -----------------------------------------------------------------------------------<<<<< */
            dataRow[PMUOE04122EA.ct_Col_GoodsName] = stockSndRcvJnl.GoodsName;                              // 回答品名     //ADD 2009/01/20 不具合対応[10207]
            dataRow[PMUOE04122EA.ct_Col_AnswerListPrice] = stockSndRcvJnl.AnswerListPrice;                  // 標準価格
            dataRow[PMUOE04122EA.ct_Col_AnswerSalesUnitCost] = stockSndRcvJnl.AnswerSalesUnitCost;          // 原単価
            dataRow[PMUOE04122EA.ct_Col_UOEDelivDateCd] = stockSndRcvJnl.UOEDelivDateCd;                    // 納期
            dataRow[PMUOE04122EA.ct_Col_UOESubstCode] = stockSndRcvJnl.UOESubstCode;                        // 代替

            // コメント
            /* ---DEL 2009/01/22 不具合対応[10345] --------------------------------------------------------------->>>>>
            if (string.IsNullOrEmpty(stockSndRcvJnl.HeadErrorMassage) == false)
            {
                dataRow[PMUOE04122EA.ct_Col_Comment] = stockSndRcvJnl.HeadErrorMassage;             // ヘッドエラーメッセージ
            }
            else if (string.IsNullOrEmpty(stockSndRcvJnl.LineErrorMassage) == false)
            {
                dataRow[PMUOE04122EA.ct_Col_Comment] = stockSndRcvJnl.LineErrorMassage;             // ラインエラーメッセージ
            }
            else if (string.IsNullOrEmpty(stockSndRcvJnl.SubstPartsNo) == false)
            {
                dataRow[PMUOE04122EA.ct_Col_Comment] = stockSndRcvJnl.SubstPartsNo;                 // 代替品番
            }
            else
            {
                dataRow[PMUOE04122EA.ct_Col_Comment] = string.Empty;
            }
               ---DEL 2009/01/22 不具合対応[10345] ---------------------------------------------------------------<<<<< */
            // ---ADD 2009/01/22 不具合対応[10345] --------------------------------------------------------------->>>>>
            if (string.IsNullOrEmpty(stockSndRcvJnl.HeadErrorMassage.Trim()) == false)
            {
                dataRow[PMUOE04122EA.ct_Col_Comment] = stockSndRcvJnl.HeadErrorMassage;             // ヘッドエラーメッセージ
            }
            else if (string.IsNullOrEmpty(stockSndRcvJnl.LineErrorMassage.Trim()) == false)
            {
                dataRow[PMUOE04122EA.ct_Col_Comment] = stockSndRcvJnl.LineErrorMassage;             // ラインエラーメッセージ
            }
            else if (string.IsNullOrEmpty(stockSndRcvJnl.SubstPartsNo.Trim()) == false)
            {
                dataRow[PMUOE04122EA.ct_Col_Comment] = stockSndRcvJnl.SubstPartsNo;                 // 代替品番
            }
            else
            {
                dataRow[PMUOE04122EA.ct_Col_Comment] = string.Empty;
            }
            // ---ADD 2009/01/22 不具合対応[10345] ---------------------------------------------------------------<<<<<
        }
        #endregion
        #endregion ◆在庫回答情報HashTable関連 - end

        #region ◆拠点情報HashTable関連
        #region ▼CreateSectionInfoHTable(HashTable作成)
        /// <summary>
        /// 拠点情報HashTable作成
        /// </summary>
        /// <param name="stockSndRcvJnl">発注行番号単位のデータ</param>
        /// <remarks>
        /// <br>Note       : UOE送受信ジャーナル(在庫)の内容を元に拠点表示用HashTableを作成します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void CreateSectionInfoHTable(StockSndRcvJnl stockSndRcvJnl)
        {
            List<SectionInfo> sectionInfo = CopyToSectionInfoListFromStockSndRcvJnl(stockSndRcvJnl);

            // 拠点情報HashTable作成
            string key = stockSndRcvJnl.UOESupplierCd + "-" + stockSndRcvJnl.UOESalesOrderNo + "-" + stockSndRcvJnl.UOESalesOrderRowNo;
            this._sectionInfoHTable[key] = sectionInfo;
        }
        #endregion

        #region ▼CopyToSectionInfoListFromStockSndRcvJnl(HashTableデータ取得)
        /// <summary>
        /// 拠点用HashTableデータ取得
        /// </summary>
        /// <param name="stockSndRcvJnl">UOE送受信ジャーナル(在庫)</param>
        /// <returns>拠点用List</returns>
        /// <remarks>
        /// <br>Note       : UOE送受信ジャーナル(在庫)の内容を元に拠点用Listを作成します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private List<SectionInfo> CopyToSectionInfoListFromStockSndRcvJnl(StockSndRcvJnl stockSndRcvJnl)
        {
            List<SectionInfo> sectionInfoList = new List<SectionInfo>();
            SectionInfo[] sectionInfo = new SectionInfo[35];

            // ---ADD 2009/02/03　不具合対応[10841] ---------------------------------------->>>>>
            int programId = this.GetProgramIdFromUOEOrderDtlHTable(stockSndRcvJnl.UOESupplierCd);
            if (programId == PROGRAMID_HONDA)
            {
                sectionInfo[0].Add(stockSndRcvJnl.UOESectionCode1, stockSndRcvJnl.HeadQtrsStock);
                sectionInfo[1].Add(stockSndRcvJnl.UOESectionCode1, stockSndRcvJnl.UOESectionStock1);
                sectionInfo[2].Add(stockSndRcvJnl.UOESectionCode2, stockSndRcvJnl.UOESectionStock2);
                sectionInfo[3].Add(stockSndRcvJnl.UOESectionCode3, stockSndRcvJnl.UOESectionStock3);
                sectionInfo[4].Add(stockSndRcvJnl.UOESectionCode4, stockSndRcvJnl.UOESectionStock4);
                sectionInfo[5].Add(stockSndRcvJnl.UOESectionCode5, stockSndRcvJnl.UOESectionStock5);
                sectionInfo[6].Add(stockSndRcvJnl.UOESectionCode6, stockSndRcvJnl.UOESectionStock6);
                sectionInfo[7].Add(stockSndRcvJnl.UOESectionCode7, stockSndRcvJnl.UOESectionStock7);
                sectionInfo[8].Add(stockSndRcvJnl.UOESectionCode8, stockSndRcvJnl.UOESectionStock8);
                sectionInfo[9].Add(string.Empty, stockSndRcvJnl.UOESectionStock9);
                sectionInfo[10].Add(string.Empty, stockSndRcvJnl.UOESectionStock10);
                sectionInfo[11].Add(string.Empty, stockSndRcvJnl.UOESectionStock11);
                sectionInfo[12].Add(string.Empty, stockSndRcvJnl.UOESectionStock12);
                sectionInfo[13].Add(string.Empty, stockSndRcvJnl.UOESectionStock13);
                sectionInfo[14].Add(string.Empty, stockSndRcvJnl.UOESectionStock14);
                sectionInfo[15].Add(string.Empty, stockSndRcvJnl.UOESectionStock15);
                sectionInfo[16].Add(string.Empty, stockSndRcvJnl.UOESectionStock16);
                sectionInfo[17].Add(string.Empty, stockSndRcvJnl.UOESectionStock17);
                sectionInfo[18].Add(string.Empty, stockSndRcvJnl.UOESectionStock18);
                sectionInfo[19].Add(string.Empty, stockSndRcvJnl.UOESectionStock19);
                sectionInfo[20].Add(string.Empty, stockSndRcvJnl.UOESectionStock20);
                sectionInfo[21].Add(string.Empty, stockSndRcvJnl.UOESectionStock21);
                sectionInfo[22].Add(string.Empty, stockSndRcvJnl.UOESectionStock22);
                sectionInfo[23].Add(string.Empty, stockSndRcvJnl.UOESectionStock23);
                sectionInfo[24].Add(string.Empty, stockSndRcvJnl.UOESectionStock24);
                sectionInfo[25].Add(string.Empty, stockSndRcvJnl.UOESectionStock25);
                sectionInfo[26].Add(string.Empty, stockSndRcvJnl.UOESectionStock26);
                sectionInfo[27].Add(string.Empty, stockSndRcvJnl.UOESectionStock27);
                sectionInfo[28].Add(string.Empty, stockSndRcvJnl.UOESectionStock28);
                sectionInfo[29].Add(string.Empty, stockSndRcvJnl.UOESectionStock29);
                sectionInfo[30].Add(string.Empty, stockSndRcvJnl.UOESectionStock30);
                sectionInfo[31].Add(string.Empty, stockSndRcvJnl.UOESectionStock31);
                sectionInfo[32].Add(string.Empty, stockSndRcvJnl.UOESectionStock32);
                sectionInfo[33].Add(string.Empty, stockSndRcvJnl.UOESectionStock33);
                sectionInfo[34].Add(string.Empty, stockSndRcvJnl.UOESectionStock34);
            }
            else
            {
            // ---ADD 2009/02/03　不具合対応[10841] ----------------------------------------<<<<<
                sectionInfo[0].Add(stockSndRcvJnl.UOESectionCode1, stockSndRcvJnl.UOESectionStock1);
                sectionInfo[1].Add(stockSndRcvJnl.UOESectionCode2, stockSndRcvJnl.UOESectionStock2);
                sectionInfo[2].Add(stockSndRcvJnl.UOESectionCode3, stockSndRcvJnl.UOESectionStock3);
                sectionInfo[3].Add(stockSndRcvJnl.UOESectionCode4, stockSndRcvJnl.UOESectionStock4);
                sectionInfo[4].Add(stockSndRcvJnl.UOESectionCode5, stockSndRcvJnl.UOESectionStock5);
                sectionInfo[5].Add(stockSndRcvJnl.UOESectionCode6, stockSndRcvJnl.UOESectionStock6);
                sectionInfo[6].Add(stockSndRcvJnl.UOESectionCode7, stockSndRcvJnl.UOESectionStock7);
                sectionInfo[7].Add(stockSndRcvJnl.UOESectionCode8, stockSndRcvJnl.UOESectionStock8);
                sectionInfo[8].Add(string.Empty, stockSndRcvJnl.UOESectionStock9);
                sectionInfo[9].Add(string.Empty, stockSndRcvJnl.UOESectionStock10);
                sectionInfo[10].Add(string.Empty, stockSndRcvJnl.UOESectionStock11);
                sectionInfo[11].Add(string.Empty, stockSndRcvJnl.UOESectionStock12);
                sectionInfo[12].Add(string.Empty, stockSndRcvJnl.UOESectionStock13);
                sectionInfo[13].Add(string.Empty, stockSndRcvJnl.UOESectionStock14);
                sectionInfo[14].Add(string.Empty, stockSndRcvJnl.UOESectionStock15);
                sectionInfo[15].Add(string.Empty, stockSndRcvJnl.UOESectionStock16);
                sectionInfo[16].Add(string.Empty, stockSndRcvJnl.UOESectionStock17);
                sectionInfo[17].Add(string.Empty, stockSndRcvJnl.UOESectionStock18);
                sectionInfo[18].Add(string.Empty, stockSndRcvJnl.UOESectionStock19);
                sectionInfo[19].Add(string.Empty, stockSndRcvJnl.UOESectionStock20);
                sectionInfo[20].Add(string.Empty, stockSndRcvJnl.UOESectionStock21);
                sectionInfo[21].Add(string.Empty, stockSndRcvJnl.UOESectionStock22);
                sectionInfo[22].Add(string.Empty, stockSndRcvJnl.UOESectionStock23);
                sectionInfo[23].Add(string.Empty, stockSndRcvJnl.UOESectionStock24);
                sectionInfo[24].Add(string.Empty, stockSndRcvJnl.UOESectionStock25);
                sectionInfo[25].Add(string.Empty, stockSndRcvJnl.UOESectionStock26);
                sectionInfo[26].Add(string.Empty, stockSndRcvJnl.UOESectionStock27);
                sectionInfo[27].Add(string.Empty, stockSndRcvJnl.UOESectionStock28);
                sectionInfo[28].Add(string.Empty, stockSndRcvJnl.UOESectionStock29);
                sectionInfo[29].Add(string.Empty, stockSndRcvJnl.UOESectionStock30);
                sectionInfo[30].Add(string.Empty, stockSndRcvJnl.UOESectionStock31);
                sectionInfo[31].Add(string.Empty, stockSndRcvJnl.UOESectionStock32);
                sectionInfo[32].Add(string.Empty, stockSndRcvJnl.UOESectionStock33);
                sectionInfo[33].Add(string.Empty, stockSndRcvJnl.UOESectionStock34);
                sectionInfo[34].Add(string.Empty, stockSndRcvJnl.UOESectionStock35);
            }       //ADD 2009/02/03　不具合対応[10841]

            // SectionInfo→List<SectionInfo>
            for (int index = 0; index <= 34; index++)
            {
                sectionInfoList.Add(sectionInfo[index]);
            }

            return sectionInfoList;
        }
        #endregion

        #region ▼CopyToDataSetFromSectionInfoList(拠点用List→DataSetコピー)
        /// <summary>
        /// 拠点用List→画面表示用DataSet作成
        /// </summary>
        /// <param name="uoeSupplierCode">発注先コード</param>
        /// <param name="key">拠点用HashTable読み込みキー</param>
        /// <returns>画面表示用DataSet</returns>
        /// <remarks>
        /// <br>Note       : 拠点用Listの内容を元に画面表示用のDataSetを作成します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// <br>Date       : 2010/05/27  19060 堀田 剛生 明治UOEWEB対応</br>
        /// </remarks>
        private DataSet CopyToDataSetFromSectionInfoList(int uoeSupplierCode, string key)
        {
            // データなし
            if (this._sectionInfoHTable == null)
            {
                return null;
            }
            // Keyに該当するデータなし
            if (this._sectionInfoHTable.ContainsKey(key) == false)
            {
                return null;
            }

            int count = 0;
            int programId = this.GetProgramIdFromUOEOrderDtlHTable(uoeSupplierCode);

            // DataTable作成
            DataTable dataTable = null;
            PMUOE04122EA.CreateDataTableSection(ref dataTable);

            List<SectionInfo> sectionInfoList = (List<SectionInfo>)this._sectionInfoHTable[key];

            foreach (SectionInfo sectionInfo in sectionInfoList)
            {
                // 最大表示行数判定
                if (this.SectionInfoDispMaxCheck(programId, count + 1) == false)
                {
                    break;
                }

                DataRow dataRow = dataTable.NewRow();
                switch (programId)
                {
                    case PROGRAMID_TOYOTA:
                    case PROGRAMID_NISSAN:
                    case PROGRAMID_MITSUBISHI:
                    case PROGRAMID_MATSUDA_OLD:
                        {
                            dataRow[PMUOE04122EA.ct_Col_SectionCode] = this.GetUOEGuideNm("*" + count.ToString("00"), uoeSupplierCode);
                            dataRow[PMUOE04122EA.ct_Col_SectionStock] = sectionInfo.UOESectionStock;
                            break;
                        }
                    case PROGRAMID_MATSUDA_NEW:
                        {
                            int uoeSectionCode = 0;
                            int.TryParse(sectionInfo.UOESection, out uoeSectionCode);
                            dataRow[PMUOE04122EA.ct_Col_SectionCode] = this.GetUOEGuideNm(uoeSectionCode.ToString("000"), uoeSupplierCode);
                            dataRow[PMUOE04122EA.ct_Col_SectionStock] = sectionInfo.UOESectionStock.ToString();
                            break;
                        }
                    case PROGRAMID_PRIME_MEIJI:  //ADD 2010/05/27
                    case PROGRAMID_PRIME:
                        {
                            if (count == 0)
                            {
                                dataRow[PMUOE04122EA.ct_Col_SectionCode] = "拠点";
                                dataRow[PMUOE04122EA.ct_Col_SectionStock] = sectionInfo.UOESectionStock.ToString();
                            }
                            else
                            {
                                dataRow[PMUOE04122EA.ct_Col_SectionCode] = "センター";
                                dataRow[PMUOE04122EA.ct_Col_SectionStock] = sectionInfo.UOESectionStock.ToString();
                            }
                            break;
                        }
                    // ---ADD 2009/02/03　不具合対応[10841] --------------------------------------------------->>>>>
                    case PROGRAMID_HONDA:
                        {
                            if (count == 0)
                            {
                                dataRow[PMUOE04122EA.ct_Col_SectionCode] = "本部在庫";
                                dataRow[PMUOE04122EA.ct_Col_SectionStock] = sectionInfo.UOESectionStock;
                            }
                            else
                            {
                                dataRow[PMUOE04122EA.ct_Col_SectionCode] = sectionInfo.UOESection;
                                dataRow[PMUOE04122EA.ct_Col_SectionStock] = sectionInfo.UOESectionStock;
                            }
                            break;
                        }
                    // ---ADD 2009/02/03　不具合対応[10841] ---------------------------------------------------<<<<<
                    default:
                        dataRow[PMUOE04122EA.ct_Col_SectionCode] = sectionInfo.UOESection;
                        dataRow[PMUOE04122EA.ct_Col_SectionStock] = sectionInfo.UOESectionStock;
                        break;
                }

                dataTable.Rows.Add(dataRow);
                count++;
            }

            // 画面表示用DataSet作成
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(dataTable);

            return dataSet;
        }
        #endregion

        #region ▼SectionInfoDispMaxCheck(拠点表示行数チェック)
        /// <summary>
        /// 表示チェック
        /// </summary>
        /// <param name="programId">アセンブリID(プログラムID)</param>
        /// <param name="count">グリッド表示件数</param>
        /// <returns>True：表示、False：非表示</returns>
        /// <remarks>
        /// <br>Note       : アセンブリID毎の表示行数を判定します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private bool SectionInfoDispMaxCheck(int programId, int count)
        {
            switch (programId)
            {
                case PROGRAMID_TOYOTA:
                    // --- ADD 2008/12/18 ① ---------------------------------------->>>>>
                    {
                        if (count <= SECTIONDISP_TOYOTA)
                        {
                            return true;
                        }
                        break;
                    }
                // --- ADD 2008/12/18 ① ----------------------------------------<<<<<
                case PROGRAMID_NISSAN:
                    // --- ADD 2008/12/18 ① ---------------------------------------->>>>>
                    {
                        if (count <= SECTIONDISP_NISSAN)
                        {
                            return true;
                        }
                        break;
                    }
                // --- ADD 2008/12/18 ① ----------------------------------------<<<<<
                case PROGRAMID_MITSUBISHI:
                // --- ADD 2008/12/18 ① ---------------------------------------->>>>>
                    {
                        if (count <= SECTIONDISP_MITSUBISHI)
                        {
                            return true;
                        }
                        break;
                    }
                // --- ADD 2008/12/18 ① ----------------------------------------<<<<<
                case PROGRAMID_MATSUDA_OLD:
                    {
                        //if (count <= SECTIONDISP_DEFAULT)         //DEL 2008/12/18 ①
                        if (count <= SECTIONDISP_MATSUDA_OLD)       //ADD 2008/12/18 ①
                        {
                            return true;
                        }
                        break;
                    }
                case PROGRAMID_MATSUDA_NEW:
                    {
                        if (count <= SECTIONDISP_MATSUDA_NEW)
                        {
                            return true;
                        }
                        break;
                    }
                // --- ADD 2008/12/18 ① ---------------------------------------->>>>>
                case PROGRAMID_HONDA:
                    {
                        if (count <= SECTIONDISP_HONDA)
                        {
                            return true;
                        }
                        break;
                    }
                // --- ADD 2008/12/18 ① ----------------------------------------<<<<<
                case PROGRAMID_PRIME_MEIJI:  //ADD 2010/05/27
                case PROGRAMID_PRIME:
                    {
                        if (count <= SECTIONDISP_PRIME)
                        {
                            return true;
                        }
                        break;
                    }
                default:
                    //if (count <= SECTIONDISP_HONDA)               //DEL 2008/12/18 ①
                    if (count <= SECTIONDISP_DEFAULT)               //ADD 2008/12/18 ①
                    {
                        return true;
                    }
                    break;
            }
            return false;
        }
        #endregion
        #endregion ◆拠点情報HashTable関連 - end
        #endregion ■Privateメソッド - end
    }
}


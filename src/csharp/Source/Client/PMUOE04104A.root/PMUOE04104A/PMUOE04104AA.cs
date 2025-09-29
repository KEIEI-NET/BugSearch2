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
    /// 発注回答表示　アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 発注回答表示に関するアクセス制御を行います。</br>
    /// <br>Programmer	: 照田 貴志</br>
    /// <br>Date		: 2008/11/06</br>
    /// <br>UpdateNote  : 2008/11/28 照田 貴志　バグ修正、仕様変更対応</br>
    /// <br>              2008/12/18 照田 貴志　バグ修正、仕様変更対応</br>
    /// <br>               ①新マツダはＭＦ分を"ＢＯ"としてタイトル表示</br>
    /// <br>               ②ホンダの表示方法変更</br>
    /// <br>               ③標準単価、原単価が0となるバグ修正</br>
    /// <br>               ④検索条件クラス項目追加</br>
    /// <br>              2009/01/20 照田 貴志　不具合対応[10165]</br>
    /// <br>              2009/01/21 照田 貴志　不具合対応[10134][10173]</br>
    /// <br>              2010/01/20 工藤 恵優　トヨタ UOE Web 対応</br>
    /// <br>Update Note : 2010/03/08 楊明俊 PM1006</br>
    /// <br>              グリッドタイトルの表示制御対応</br>
    /// <br>UpdateNote  : 2010/04/27 zhshh</br>
    /// <br>              PM1007C 三菱UOE-WEB対応に伴う仕様追加</br>
    /// <br>UpdateNote  : 2010/05/14 呉元嘯</br>
    /// <br>              PM1008 グリッドタイトルの表示制御の対応(明治UOEWeb)</br>
    /// <br>UpdateNote  : 2010/12/31 曹文傑</br>
    /// <br>              UOE自動化改良</br>
    /// <br>UpdateNote  : 2011/01/30 朱 猛</br>
    /// <br>              UOE自動化改良</br>
    /// <br>UpdateNote  : 2011/03/01 liyp</br>
    /// <br>              日産UOE自動化B対応</br>
    /// <br>UpdateNote  : 2011/05/10 施炳中</br>
    /// <br>              グリッドヘッダーHashTable関連の変更</br>
    /// <br>UpdateNote  : 2011/10/25 葛中華</br>
    /// <br>              卸NET-WEB対応に伴う仕様追加 グリッドヘッダーHashTable関連の変更</br>
    /// </remarks>
    public class PMUOE04104AA
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
        // --- ADD 2011/10/25 ---------->>>>>
        private const int PROGRAMID_NET_WEB = 1003;       //卸NET-WEB
        // --- ADD 2011/10/25 ----------<<<<<
        // --- ADD 2010/05/14 ---------->>>>>
        private const int PROGRAMID_MEIJI_WEB = 1004;        // 明治UOE(web)
        // --- ADD 2010/05/14 ----------<<<<<
        // ADD 2010/01/20 トヨタ UOE Web 対応 ---------->>>>>
        private const int PROGRAMID_TOYOTA_WEB= 103;        // トヨタ 電子カタログ
        private const int PROGRAMID_HONDA_WEB = 502;        // ホンダ e-Parts
        // ADD 2010/01/20 トヨタ UOE Web 対応 ----------<<<<<
        // --- ADD 2010/03/08 ---------->>>>>
        private const int PROGRAMID_NISSAN_WEB = 203;        // 日産UOE(web)
        // --- ADD 2010/03/08 ----------<<<<<
        // --- ADD 2010/04/27 ---------->>>>>
        private const int PROGRAMID_MITSUBISHI_WEB = 302;        // 三菱UOE(web)
        // --- ADD 2010/04/27 ----------<<<<<
        // --- ADD 2010/12/31 ---------->>>>>
        private const int PROGRAMID_NISSAN_AUTOWEB = 204;        // 日産UOE(web自動)
        private const int PROGRAMID_MITSUBISHI_AUTOWEB = 303;    // 三菱UOE(web自動)
        // --- ADD 2010/12/31 ----------<<<<<
        private const int PROGRAMID_TOYOTA_104 = 104;        // トヨタ自動処理 // ADD 2011/01/30 朱 猛
        // --- ADD 2011/03/01 ------------------------------------------>>>>>
        private const int PROGRAMID_NISSAN_WEB_205 = 205;
        private const int PROGRAMID_NISSAN_WEB_206 = 206;
        // --- ADD 2011/03/01 ------------------------------------------<<<<<
        // --- ADD 2011/05/10 ---------->>>>>
        private const int PROGRAMID_MAZDA_WEB = 403;        // マズダUOE
        // --- ADD 2010/05/10 ----------<<<<<
        // データ
        private const int ORDERANSINFO_FIRST = 0;           // 発注回答情報初期データ位置

        // HashTable
        private Hashtable _orderAnsInfoHTable = null;       // 発注回答情報(key：INDEX)
        private Hashtable _gridHeaderHTable = null;         // グリッドヘッダー(key：通信アセンブリID(通信プログラムID))
        private Hashtable _uoeOrderDtlHTable = null;        // UOE発注先マスタ(key：UOE発注先コード)

        private string _enterpriseCode = string.Empty;      // 企業コード
        private string _sectionCode = string.Empty;         // 拠点コード
        private int _orderAnsInfoHTableIndex = 0;           // 発注回答情報INDEX

        private IUOEAnswerLedgerOrderWorkDB _iUOEAnswerLedgerOrderWorkDB = null;        // 発注データ取得用リモートオブジェクト

        #region GridHeaderInfo構造体
        /// <summary>
        /// グリッドヘッダー情報　構造体
        /// </summary>
        internal struct GridHeaderInfo
        {
            private string _variableName1;      // 拠点伝票
            private string _variableName2;      // BO伝票1
            private string _variableName3;      // BO伝票2
            private string _variableName4;      // BO伝票3
            private string _variableName5;      // BO管理No.
            private string _variableName6;      // MF

            /// <summary>
            /// グリッドヘッダーデータ追加
            /// </summary>
            /// <param name="variableName1">可変項目名称1(拠点伝票)</param>
            /// <param name="variableName2">可変項目名称2(BO伝票1)</param>
            /// <param name="variableName3">可変項目名称3(BO伝票2)</param>
            /// <param name="variableName4">可変項目名称4(BO伝票3)</param>
            /// <param name="variableName5">可変項目名称5(BO管理No.)</param>
            /// <param name="variableName6">可変項目名称6(MF)</param>
            public void Add(string variableName1, string variableName2, string variableName3, string variableName4,string variableName5, string variabelName6)
            {
                _variableName1 = variableName1;
                _variableName2 = variableName2;
                _variableName3 = variableName3;
                _variableName4 = variableName4;
                _variableName5 = variableName5;
                _variableName6 = variabelName6;
            }

            /// <summary>可変項目名称1(拠点伝票)</summary>
            public string variableName1
            {
                get { return _variableName1; }
            }
            /// <summary>可変項目名称2(BO伝票1)</summary>
            public string variableName2
            {
                get { return _variableName2; }
            }
            /// <summary>可変項目名称3(BO伝票2)</summary>
            public string variableName3
            {
                get { return _variableName3; }
            }
            /// <summary>可変項目名称4(BO伝票3)</summary>
            public string variableName4
            {
                get { return _variableName4; }
            }
            /// <summary>可変項目名称5(BO管理No.)</summary>
            public string variableName5
            {
                get { return _variableName5; }
            }
            /// <summary>可変項目名称6(MF)</summary>
            public string variableName6
            {
                get { return _variableName6; }
            }
        }
        #endregion

        #region UOEOrderDtlInfo構造体
        internal struct UOEOrderDtlInfo
        {
            private string _programId;          // 通信アセンブリID(プログラムID)
            private string _uoeSupplierName;    // UOE発注先名称
            private string _hondaSectionCode;   // 担当拠点(ホンダ項目)

            /// <summary>
            /// 発注先マスタデータ追加
            /// </summary>
            /// <param name="programId">通信アセンブリID(プログラムID)</param>
            /// <param name="uoeSupplierName">UOE発注先名称</param>
            /// <param name="hondaSectionCode">担当拠点(ホンダ項目)</param>
            /* --- DEL 2008/12/18 ② -------------------------------------------------->>>>>
            public void Add(string programId, string uoeSupplierName)
            {
                _programId = programId;
                _uoeSupplierName = uoeSupplierName;
            }
               --- DEL 2008/12/18 ② --------------------------------------------------<<<<< */
            // --- ADD 2008/12/18 ② -------------------------------------------------->>>>>
            public void Add(string programId, string uoeSupplierName, string hondaSectionCode)
            {
                _programId = programId;
                _uoeSupplierName = uoeSupplierName;
                _hondaSectionCode = hondaSectionCode;
            }
            // --- ADD 2008/12/18 ② --------------------------------------------------<<<<<
            /// <summary> 通信アセンブリID(プログラムID) </summary>
            public string ProgramId { get { return _programId; } }
            /// <summary> UOE発注先名称 </summary>
            public string UOESupplierName { get { return _uoeSupplierName; } }
            /// <summary> 担当拠点(ホンダ項目) </summary>
            public string HondaSectionCode { get { return _hondaSectionCode; } }        //ADD 2008/12/18 ②
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
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        public PMUOE04104AA(List<OrderSndRcvJnl> orderSndRcvJnlList, string enterpriseCode, string sectionCode)
        {
            // 企業コード
            this._enterpriseCode = enterpriseCode;

            // 拠点コード
            this._sectionCode = sectionCode;

            // グリッドヘッダー
            this.CreateGridHeaderHTable();

            // UOE発注先マスタ
            this.CreateUOEOrderDtlHTable();

            if (orderSndRcvJnlList == null)
            {
                // リモートオブジェクト取得
                this._iUOEAnswerLedgerOrderWorkDB = (IUOEAnswerLedgerOrderWorkDB)MediationUOEAnswerLedgerOrderWorkDB.GetUOEAnswerLedgerOrderWorkDB();

                this._orderAnsInfoHTable = null;
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
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        public bool SearchFirst(out DataSet supplierDataSet, out DataSet detailDataSet)
        {
            // 初回以外の呼び出しはNG
            if (this._orderAnsInfoHTableIndex != -1)
            {
                supplierDataSet = null;
                detailDataSet = null;
                return false;
            }

            bool status = this.GetDispInfoAll(ORDERANSINFO_FIRST, out supplierDataSet, out detailDataSet);
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
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/06</br>
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
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        public bool SearchBefore(out DataSet supplierDataSet, out DataSet detailDataSet)
        {
            // 1つ前のデータを取得
            bool status = this.GetDispInfoAll(this._orderAnsInfoHTableIndex - 1, out supplierDataSet, out detailDataSet);
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
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        public bool SearchNext(out DataSet supplierDataSet, out DataSet detailDataSet)
        {
            // 1つ後のデータを取得
            bool status = this.GetDispInfoAll(this._orderAnsInfoHTableIndex + 1, out supplierDataSet, out detailDataSet);
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
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/06</br>
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
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        public string GetUOESupplierName(int uoeSupplierCd)
        {
            return this.GetUOESupplierNameFromUOEOrderDtlHTable(uoeSupplierCd);
        }
        #endregion

        #region ▼GetGridHeaderDataSet(グリッド可変ヘッダー名称取得　単体起動専用)
        /// <summary>
        /// グリッドヘッダー名称取得
        /// </summary>
        /// <param name="uoeSupplierCd">発注先コード</param>
        /// <param name="dataSet">ヘッダーデータ</param>
        /// <remarks>
        /// <br>Note       : グリッドヘッダー名称を取得します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        public void GetGridHeaderDataSet(int uoeSupplierCd, out DataSet dataSet)
        {
            // DataTable作成
            DataTable supplierDataTable = null;
            PMUOE04103EA.CreateDataTableSupplier(ref supplierDataTable);

            // DataRow作成
            DataRow supplierDataRow = supplierDataTable.NewRow();

            // データ取得
            this.GetHeaderVariableName(uoeSupplierCd, ref supplierDataRow);

            // DataSet作成
            supplierDataTable.Rows.Add(supplierDataRow);

            dataSet = new DataSet();
            dataSet.Tables.Add(supplierDataTable);
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
        /// <br>Date       : 2008/11/06</br>
        /// <br>UpdateNote : 2010/03/08 楊明俊 グリッドタイトルの表示制御の対応</br>
        /// <br>UpdateNote : 2010/05/14 呉元嘯 グリッドタイトルの表示制御の対応(明治UOEWeb)</br>
        /// <br>UpdateNote : 2010/12/31 曹文傑 UOE自動化改良</br>
        /// <br>UpdateNote : 2011/01/30 朱 猛 UOE自動化改良</br>
        /// <br>UpdateNote : 2011/03/01 liyp 日産UOE自動化B対応</br>
        /// <br>UpdateNote : 2011/05/10 施炳中 グリッドヘッダーHashTable関連の変更</br>
        /// <br>UpdateNote : 2011/10/25 葛中華 卸NET-WEB対応に伴う仕様追加 グリッドヘッダーHashTable関連の変更</br>
        /// </remarks>
        private void CreateGridHeaderHTable()
        {
            // this.SetGridHeaderInfo(通信アセンブリID(通信プログラムID), 拠点伝票, BO伝票1, BO伝票2, BO伝票3, BO管理No., MF);
            this.AddGridHeaderInfoHTable(PROGRAMID_NOTHING, "", "", "", "", "", "");                                // 初期
            this.AddGridHeaderInfoHTable(PROGRAMID_TOYOTA, "拠点", "ＳＦ", "ＨＦ", "ＲＦ", "","ＭＦ");              // トヨタ
            this.AddGridHeaderInfoHTable(PROGRAMID_NISSAN, "自拠点", "サブ", "メイン", "他拠点","ＥＯ","ＢＯ");     // ニッサン
            this.AddGridHeaderInfoHTable(PROGRAMID_MITSUBISHI, "拠点", "サブ", "本庫", "", "", "ＭＦ");             // ミツビシ
            this.AddGridHeaderInfoHTable(PROGRAMID_MATSUDA_OLD, "拠点", "支店", "本社", "", "", "ＢＯ");            // 旧マツダ
            //this.AddGridHeaderInfoHTable(PROGRAMID_MATSUDA_NEW, "拠点", "他拠点", "他拠点", "", "", "");            // 新マツダ       //DEL 2008/12/18 ①
            this.AddGridHeaderInfoHTable(PROGRAMID_MATSUDA_NEW, "拠点", "他拠点", "他拠点", "", "", "ＢＯ");        // 新マツダ         //ADD 2008/12/18 ①
            //this.AddGridHeaderInfoHTable(PROGRAMID_HONDA, "拠点", "ＳＦ", "", "出荷元", "", "");                    // ホンダ         //DEL 2008/12/18 ②
            this.AddGridHeaderInfoHTable(PROGRAMID_HONDA, "", "拠点", "", "ＳＦ", "", "");                          // ホンダ           //ADD 2008/12/18 ②
            this.AddGridHeaderInfoHTable(PROGRAMID_PRIME, "拠点", "ＢＯ", "", "", "", "");                          // 優良
            // ADD 2011/10/25 ---------->>>>>
            this.AddGridHeaderInfoHTable(PROGRAMID_NET_WEB, "拠点", "ＢＯ", "", "", "", "");                        // 卸NET-WEB
            // ADD 2011/10/25 ----------<<<<<
            // ADD 2010/01/20 トヨタ UOE Web 対応 ---------->>>>>
            this.AddGridHeaderInfoHTable(PROGRAMID_TOYOTA_WEB, "拠点", "ＳＦ", "ＨＦ", "ＲＦ", "", "ＭＦ"); // トヨタ 電子カタログ
            this.AddGridHeaderInfoHTable(PROGRAMID_HONDA_WEB, "", "拠点", "", "ＳＦ", "", "");              // ホンダ e-Parts
            // ADD 2010/01/20 トヨタ UOE Web 対応 ----------<<<<<
            // --- ADD 2010/03/08 ---------->>>>>
            this.AddGridHeaderInfoHTable(PROGRAMID_NISSAN_WEB, "自拠点", "サブ", "メイン", "他拠点", "ＥＯ", "ＢＯ"); // 日産UOE(web)
            // --- ADD 2010/03/08 ----------<<<<<
            this.AddGridHeaderInfoHTable(PROGRAMID_NISSAN_AUTOWEB, "自拠点", "サブ", "メイン", "他拠点", "ＥＯ", "ＢＯ"); // 日産UOE(web自動) // ADD 2010/12/31
            // --- ADD 2010/04/27 ---------->>>>>
            this.AddGridHeaderInfoHTable(PROGRAMID_MITSUBISHI_WEB, "拠点", "サブ", "本庫", "", "", "ＭＦ"); // 三菱UOE(web)
            // --- ADD 2010/04/27 ----------<<<<<
            this.AddGridHeaderInfoHTable(PROGRAMID_MITSUBISHI_AUTOWEB, "拠点", "サブ", "本庫", "", "", "ＭＦ"); // 三菱UOE(web自動) // ADD 2010/12/31
            // --- ADD 2010/05/14 ---------->>>>>
            this.AddGridHeaderInfoHTable(PROGRAMID_MEIJI_WEB, "拠点", "ＢＯ", "", "", "", ""); // 明治UOE(web)
            // --- ADD 2010/05/14 ----------<<<<<
            this.AddGridHeaderInfoHTable(PROGRAMID_TOYOTA_104, "拠点", "ＳＦ", "ＨＦ", "ＲＦ", "", "ＭＦ"); // トヨタ自動処理 // ADD 2011/01/30 朱 猛
            // --- ADD 2011/03/01 ---------->>>>>
            this.AddGridHeaderInfoHTable(PROGRAMID_NISSAN_WEB_205, "自拠点", "サブ", "メイン", "他拠点", "ＥＯ", "ＢＯ");
            this.AddGridHeaderInfoHTable(PROGRAMID_NISSAN_WEB_206, "自拠点", "サブ", "メイン", "他拠点", "ＥＯ", "ＢＯ");
            // --- ADD 2011/03/01 ----------<<<<<
            // --- ADD 2011/05/10 ---------->>>>>
            this.AddGridHeaderInfoHTable(PROGRAMID_MAZDA_WEB, "拠点", "サブ", "本庫", "", "", "ＭＦ"); // マズダUOE
            // --- ADD 2011/05/10 ----------<<<<<
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
        /// <param name="Variable5">可変項目名称5</param>
        /// <param name="Variable6">可変項目名称6</param>
        /// <remarks>
        /// <br>Note       : 渡された値を元にHashTableにデータを追加します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private void AddGridHeaderInfoHTable(int key, string variable1, string variable2, string variable3, string variable4, string variable5, string variable6)
        {
            if (this._gridHeaderHTable == null)
            {
                this._gridHeaderHTable = new Hashtable();
            }

            GridHeaderInfo gridHeaderInfo = new GridHeaderInfo();
            gridHeaderInfo.Add(variable1, variable2, variable3, variable4, variable5, variable6);

            // HashTableに追加(キー：通信アセンブリID(通信プログラムID))
            this._gridHeaderHTable[key] = gridHeaderInfo;
        }
        #endregion

        #region ▼GetHeaderVariableaName(HashTable→DataRowコピー)
        /// <summary>
        /// グリッドヘッダーHashTableデータ取得
        /// </summary>
        /// <param name="orderSndRcvJnl">UOE送受信ジャーナル(発注)</param>
        /// <param name="dataRow">グリッドヘッダー保存用DataRow</param>
        /// <remarks>
        /// <br>Note       : グリッドヘッダーHashTableよりデータを取得し、DataRowに保存します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private void GetHeaderVariableName(int uoeSupplierCd, ref DataRow dataRow)
        {
            // UOE発注先を元に通信アセンブリID(通信プログラムID)を取得
            int programId = this.GetProgramIdFromUOEOrderDtlHTable(uoeSupplierCd);

            // ヘッダー情報取得
            if (this._gridHeaderHTable.ContainsKey(programId) == false )
            {
                dataRow[PMUOE04103EA.ct_Col_GridHeadVariableName1] = string.Empty;
                dataRow[PMUOE04103EA.ct_Col_GridHeadVariableName2] = string.Empty;
                dataRow[PMUOE04103EA.ct_Col_GridHeadVariableName3] = string.Empty;
                dataRow[PMUOE04103EA.ct_Col_GridHeadVariableName4] = string.Empty;
                dataRow[PMUOE04103EA.ct_Col_GridHeadVariableName5] = string.Empty;
                dataRow[PMUOE04103EA.ct_Col_GridHeadVariableName6] = string.Empty;
                return;
            }

            GridHeaderInfo gridHeaderInfo = (GridHeaderInfo)this._gridHeaderHTable[programId];
            // 可変項目
            dataRow[PMUOE04103EA.ct_Col_GridHeadVariableName1] = gridHeaderInfo.variableName1;
            dataRow[PMUOE04103EA.ct_Col_GridHeadVariableName2] = gridHeaderInfo.variableName2;
            dataRow[PMUOE04103EA.ct_Col_GridHeadVariableName3] = gridHeaderInfo.variableName3;
            dataRow[PMUOE04103EA.ct_Col_GridHeadVariableName4] = gridHeaderInfo.variableName4;
            dataRow[PMUOE04103EA.ct_Col_GridHeadVariableName5] = gridHeaderInfo.variableName5;
            dataRow[PMUOE04103EA.ct_Col_GridHeadVariableName6] = gridHeaderInfo.variableName6;

            // --- ADD 2008/12/18 ② --------------------------------------------------------------------------------------->>>>>
            // ホンダの表示のみ特殊
            if (programId == PROGRAMID_HONDA)
            {
                dataRow[PMUOE04103EA.ct_Col_GridHeadShipmentCntName1] = "出荷元";
                dataRow[PMUOE04103EA.ct_Col_GridHeadShipmentCntName2] = "出荷数";
                dataRow[PMUOE04103EA.ct_Col_GridHeadShipmentCntName3] = "出荷元";
                dataRow[PMUOE04103EA.ct_Col_GridHeadShipmentCntName4] = "出荷数";
                dataRow[PMUOE04103EA.ct_Col_GridHeadShipmentCntName5] = string.Empty;
            }
            else
            {
            // --- ADD 2008/12/18 ② ---------------------------------------------------------------------------------------<<<<<
                // 『出荷数』項目
                dataRow[PMUOE04103EA.ct_Col_GridHeadShipmentCntName1] = this.GetHeaderShipmentName(gridHeaderInfo.variableName1);
                dataRow[PMUOE04103EA.ct_Col_GridHeadShipmentCntName2] = this.GetHeaderShipmentName(gridHeaderInfo.variableName2);
                dataRow[PMUOE04103EA.ct_Col_GridHeadShipmentCntName3] = this.GetHeaderShipmentName(gridHeaderInfo.variableName3);
                dataRow[PMUOE04103EA.ct_Col_GridHeadShipmentCntName4] = this.GetHeaderShipmentName(gridHeaderInfo.variableName4);
                dataRow[PMUOE04103EA.ct_Col_GridHeadShipmentCntName5] = this.GetHeaderShipmentName(gridHeaderInfo.variableName5);
            }   //ADD 2008/12/18 ②
        }
        #endregion

        #region ▼GetHeaderShipmentName(グリッドヘッダー"出荷数"の表示/非表示を判定)
        /// <summary>
        /// グリッドヘッダー"出荷数"表示判定
        /// </summary>
        /// <param name="variableName">可変項目名称</param>
        /// <returns>表示文字</returns>
        /// <remarks>
        /// <br>Note       : グリッドヘッダーの可変項目名称を元に出荷数の表示/非表示を判定します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private string GetHeaderShipmentName(string variableName)
        {
            if (string.IsNullOrEmpty(variableName))
            {
                return string.Empty;
            }
            else
            {
                return "出荷数";
            }
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
        /// <br>Date       : 2008/11/06</br>
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
                //uoeOrderDtlInfo.Add(dataRow["CommAssemblyId"].ToString(), dataRow["UOESupplierName"].ToString());     //DEL 2008/12/18 ②
                // --- ADD 2008/12/18 ② --------------------------------------------------------------------------------------------->>>>>
                uoeOrderDtlInfo.Add(dataRow["CommAssemblyId"].ToString()
                                    , dataRow["UOESupplierName"].ToString()
                                    , dataRow["HondaSectionCode"].ToString());
                // --- ADD 2008/12/18 ② ---------------------------------------------------------------------------------------------<<<<<
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
        /// <br>Date       : 2008/11/06</br>
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

            UOEOrderDtlInfo uoeOrderDtlInfo = (UOEOrderDtlInfo)this._uoeOrderDtlHTable[uoeSupplierCd];

            bool ret = int.TryParse(uoeOrderDtlInfo.ProgramId, out programId);
            return programId;
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
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/06</br>
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

        #region  ▼GetHondaSectionCodeFromUOEOrderDtlHTable(担当拠点(ホンダ項目)取得)      ADD 2008/12/18 ②
        /// <summary>
        /// 担当拠点(ホンダ項目)取得
        /// </summary>
        /// <param name="uoeSupplierCd">UOE発注先コード</param>
        /// <returns>担当拠点(ホンダ項目)</returns>
        /// <remarks>
        /// <br>Note       : UOE発注先コードを元にUOE発注先マスタHashTableから担当拠点(ホンダ項目)を取得します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/12/18</br>
        /// </remarks>
        private string GetHondaSectionCodeFromUOEOrderDtlHTable(int uoeSupplierCd)
        {
            string hondaSectionCode = string.Empty;

            // データが無い
            if (this._uoeOrderDtlHTable == null)
            {
                return hondaSectionCode;
            }

            // INDEX範囲外
            if (this._uoeOrderDtlHTable.ContainsKey(uoeSupplierCd) == false)
            {
                return hondaSectionCode;
            }

            UOEOrderDtlInfo uoeOrderDtlInfo = (UOEOrderDtlInfo)this._uoeOrderDtlHTable[uoeSupplierCd];

            hondaSectionCode = uoeOrderDtlInfo.HondaSectionCode;
            return hondaSectionCode;
        }
        #endregion
        #endregion ◆UOE発注先マスタHashTable関連 - end

        #region ◆発注回答情報HashTable関連
        #region ▼CreateOrderAnsInfoHTable(HashTable作成)
        /// <summary>
        /// 発注回答情報HashTable作成
        /// </summary>
        /// <param name="orderSndRcvJnlList">UOE送受信ジャーナル(発注)リスト</param>
        /// <remarks>
        /// <br>Note       : 渡されたUOE送受信ジャーナル(発注)リストをUOE発注先、UOE発注番号単位にまとめてHashTableに格納します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private void CreateOrderAnsInfoHTable(List<OrderSndRcvJnl> orderSndRcvJnlList)
        {
            string bfKey = string.Empty;
            int listCnt = 0;
            int hashTableCnt = 0;
            List<OrderSndRcvJnl> orderAnsInfoListGroup = new List<OrderSndRcvJnl>();

            this._orderAnsInfoHTable = new Hashtable();
            foreach (OrderSndRcvJnl orderSndRcvJnl in orderSndRcvJnlList)
            {
                // キー：UOE発注先-UOE発注番号
                string key = orderSndRcvJnl.UOESupplierCd + "-" + orderSndRcvJnl.UOESalesOrderNo;

                if ((bfKey != key) && (bfKey != string.Empty))
                {
                    // 最初以外でキーが変わった時
                    // UOE発注先,発注番号単位にまとめたデータをHashTableに追加
                    this._orderAnsInfoHTable[hashTableCnt] = orderAnsInfoListGroup;
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
            this._orderAnsInfoHTable[hashTableCnt] = orderAnsInfoListGroup;

            // 初期位置
            this._orderAnsInfoHTableIndex = -1;
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
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private bool GetDispInfoAll(int index, out DataSet supplierDataSet, out DataSet detailDataSet)
        {
            detailDataSet = null;
            supplierDataSet = null;

            // データが無い
            if (this._orderAnsInfoHTable == null)
            {
                return false;
            }

            // INDEX範囲外
            if (this._orderAnsInfoHTable.ContainsKey(index) == false)
            {
                return false;
            }

            // 明細以外用DataTable作成
            DataTable supplierDataTable = null;
            PMUOE04103EA.CreateDataTableSupplier(ref supplierDataTable);

            // 明細用DataTable作成
            DataTable detailDataTable = null;
            PMUOE04103EA.CreateDataTableDetail(ref detailDataTable);

            DataRow supplierDataRow = supplierDataTable.NewRow();

            List<OrderSndRcvJnl> orderSndRcvJnlList = (List<OrderSndRcvJnl>)this._orderAnsInfoHTable[index];
            foreach (OrderSndRcvJnl orderSndRcvJnl in orderSndRcvJnlList)
            {
                // 最初のみ
                if (detailDataTable.Rows.Count == 0)
                {
                    // 画面表示用発注先情報取得
                    supplierDataRow[PMUOE04103EA.ct_Col_SalesDate] = orderSndRcvJnl.ReceiveDate.ToString("yyyy/MM/dd") + " " +
                                                                     orderSndRcvJnl.ReceiveTime.ToString("000000").Insert(2, ":").Insert(5,":");   // 発注日

                    supplierDataRow[PMUOE04103EA.ct_Col_UOESalesOrderNo] = orderSndRcvJnl.UOESalesOrderNo.ToString("000000");   // 発注番号
                    supplierDataRow[PMUOE04103EA.ct_Col_UOESupplierName] = orderSndRcvJnl.UOESupplierName;                      // 発注先
                    supplierDataRow[PMUOE04103EA.ct_Col_UoeRemark1] = orderSndRcvJnl.UoeRemark1;                                // リマーク１
                    supplierDataRow[PMUOE04103EA.ct_Col_UoeRemark2] = orderSndRcvJnl.UoeRemark2;                                // リマーク２
                    supplierDataRow[PMUOE04103EA.ct_Col_DeliveredGoodsDivNm] = orderSndRcvJnl.DeliveredGoodsDivNm;              // 納品区分
                    supplierDataRow[PMUOE04103EA.ct_Col_FollowDeliGoodsDivNm] = orderSndRcvJnl.FollowDeliGoodsDivNm;            // Ｈ納品区分
                    supplierDataRow[PMUOE04103EA.ct_Col_UOEResvdSectionNm] = orderSndRcvJnl.UOEResvdSectionNm;                  // 拠点
                    supplierDataRow[PMUOE04103EA.ct_Col_EmployeeName] = orderSndRcvJnl.EmployeeName;                            // 依頼者

                    // グリッドヘッダー情報作成
                    this.GetHeaderVariableName(orderSndRcvJnl.UOESupplierCd, ref supplierDataRow);

                    // システム区分
                    #region
                    switch (orderSndRcvJnl.SystemDivCd)
                    {
                        case 0:
                            {
                                supplierDataRow[PMUOE04103EA.ct_Col_SystemDivName] = "手入力";
                                break;
                            }
                        case 1:
                            {
                                supplierDataRow[PMUOE04103EA.ct_Col_SystemDivName] = "伝発";
                                break;
                            }
                        case 2:
                            {
                                supplierDataRow[PMUOE04103EA.ct_Col_SystemDivName] = "検索";
                                break;
                            }
                        case 3:
                            {
                                supplierDataRow[PMUOE04103EA.ct_Col_SystemDivName] = "在庫一括";
                                break;
                            }
                    }
                    #endregion
                }

                // dataRow作成
                DataRow detailDataRow = detailDataTable.NewRow();
                this.CopyToDataRowFromOrderSndRcvJnl(orderSndRcvJnl, ref detailDataRow);

                detailDataTable.Rows.Add(detailDataRow);
            }

            supplierDataTable.Rows.Add(supplierDataRow);

            // 戻り値用DataSet作成
            supplierDataSet = new DataSet();
            supplierDataSet.Tables.Add(supplierDataTable);

            detailDataSet = new DataSet();
            detailDataSet.Tables.Add(detailDataTable);

            this._orderAnsInfoHTableIndex = index;      // 現在の位置
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
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private void CopyToDataRowFromOrderSndRcvJnl(OrderSndRcvJnl orderSndRcvJnl, ref DataRow dataRow)
        {
            dataRow[PMUOE04103EA.ct_Col_UOESalesOrderRowNo] = orderSndRcvJnl.UOESalesOrderRowNo;        // UOE発注行番号
            dataRow[PMUOE04103EA.ct_Col_GoodsNo] = orderSndRcvJnl.GoodsNo;                              // 品番
            dataRow[PMUOE04103EA.ct_Col_ListPrice] = orderSndRcvJnl.AnswerListPrice;                    // 回答定価
            dataRow[PMUOE04103EA.ct_Col_Blank1] = string.Empty;                                         // 空白1
            /* --- DEL 2008/12/18 ② ------------------------------------------------------------------------------------------------>>>>> 
            dataRow[PMUOE04103EA.ct_Col_UOESectionSlipNo] = orderSndRcvJnl.UOESectionSlipNo;            // 拠点伝票
            dataRow[PMUOE04103EA.ct_Col_BOSlipNo1] = orderSndRcvJnl.BOSlipNo1;                          // BO伝票1
            dataRow[PMUOE04103EA.ct_Col_BOSlipNo2] = orderSndRcvJnl.BOSlipNo2;                          // BO伝票2
            dataRow[PMUOE04103EA.ct_Col_BOManagementNo] = orderSndRcvJnl.BOManagementNo;                // BO管理番号
               --- ADD 2008/12/18 ② ------------------------------------------------------------------------------------------------<<<<< */
            dataRow[PMUOE04103EA.ct_Col_Blank2] = string.Empty;                                         // 空白2
            dataRow[PMUOE04103EA.ct_Col_UOESubstMark] = orderSndRcvJnl.UOESubstMark;                    // 代替
            /* ---DEL 2009/01/21 不具合対応[10173] ----------------------------------------------------------------------------------------------->>>>>
            //dataRow[PMUOE04103EA.ct_Col_GoodsName] = orderSndRcvJnl.GoodsName;                          // 品名                       //DEL 2008/11/28
            dataRow[PMUOE04103EA.ct_Col_GoodsName] = orderSndRcvJnl.AnswerPartsName;                    // 品名(回答品名を表示)         //ADD 2008/11/28
               ---DEL 2009/01/21 不具合対応[10173] -----------------------------------------------------------------------------------------------<<<<< */
            dataRow[PMUOE04103EA.ct_Col_GoodsName] = orderSndRcvJnl.GoodsName;                          // 品名(回答品名を表示)         //ADD 2009/01/21 不具合対応[10173]
            dataRow[PMUOE04103EA.ct_Col_AcceptAnOrderCnt] = orderSndRcvJnl.AcceptAnOrderCnt;            // 受注数量
            dataRow[PMUOE04103EA.ct_Col_BOCode] = orderSndRcvJnl.BoCode;                                // BO区分
            dataRow[PMUOE04103EA.ct_Col_SalesUnitCost] = orderSndRcvJnl.AnswerSalesUnitCost;            // 回答原価単価
            /* --- DEL 2008/12/18 ② ------------------------------------------------------------------------------------------------>>>>> 
            // --- DEL 2008/11/28 ゼロは表示させない -------------------------------------------------------------------------------->>>>>
            //dataRow[PMUOE04103EA.ct_Col_UOESectOutGoodsCnt] = orderSndRcvJnl.UOESectOutGoodsCnt;        // UOE拠点出庫数
            //dataRow[PMUOE04103EA.ct_Col_BOShipmentCnt1] = orderSndRcvJnl.BOShipmentCnt1;                // BO出庫数1
            //dataRow[PMUOE04103EA.ct_Col_BOShipmentCnt2] = orderSndRcvJnl.BOShipmentCnt2;                // BO出庫数2
            //dataRow[PMUOE04103EA.ct_Col_BOShipmentCnt3] = orderSndRcvJnl.BOShipmentCnt3;                // BO出庫数3
            //dataRow[PMUOE04103EA.ct_Col_EOAlwcCount] = orderSndRcvJnl.EOAlwcCount;                      // EO引当数
            //dataRow[PMUOE04103EA.ct_Col_MakerFollowCnt] = orderSndRcvJnl.MakerFollowCnt;                // メーカーフォロー数
            // --- DEL 2008/11/28 ---------------------------------------------------------------------------------------------------<<<<<
            // --- ADD 2008/11/28 --------------------------------------------------------------------------------------------------->>>>>
            dataRow[PMUOE04103EA.ct_Col_UOESectOutGoodsCnt] = this.ChangeZero(orderSndRcvJnl.UOESectOutGoodsCnt);   // UOE拠点出庫数
            dataRow[PMUOE04103EA.ct_Col_BOShipmentCnt1] = this.ChangeZero(orderSndRcvJnl.BOShipmentCnt1);           // BO出庫数1
            dataRow[PMUOE04103EA.ct_Col_BOShipmentCnt2] = this.ChangeZero(orderSndRcvJnl.BOShipmentCnt2);           // BO出庫数2
            dataRow[PMUOE04103EA.ct_Col_BOShipmentCnt3] = this.ChangeZero(orderSndRcvJnl.BOShipmentCnt3);           // BO出庫数3
            dataRow[PMUOE04103EA.ct_Col_EOAlwcCount] = this.ChangeZero(orderSndRcvJnl.EOAlwcCount);                 // EO引当数
            dataRow[PMUOE04103EA.ct_Col_MakerFollowCnt] = this.ChangeZero(orderSndRcvJnl.MakerFollowCnt);           // メーカーフォロー数
            // --- ADD 2008/11/28 ---------------------------------------------------------------------------------------------------<<<<<
               --- ADD 2008/12/18 ② ------------------------------------------------------------------------------------------------<<<<< */
            dataRow[PMUOE04103EA.ct_Col_SubstPartsNo] = orderSndRcvJnl.SubstPartsNo;                    // 代替品番

            // --- ADD 2008/12/18 ② ------------------------------------------------------------------------------------------------>>>>>
            int programId = this.GetProgramIdFromUOEOrderDtlHTable(orderSndRcvJnl.UOESupplierCd);
            string format = "#,###;-#,###;";
            // ホンダの場合、特殊表示
            if (programId == PROGRAMID_HONDA)
            {
                string hondaSectionCode = this.GetHondaSectionCodeFromUOEOrderDtlHTable(orderSndRcvJnl.UOESupplierCd);
                dataRow[PMUOE04103EA.ct_Col_UOESectionSlipNo] = string.Empty;                                           // なし
                dataRow[PMUOE04103EA.ct_Col_BOSlipNo1] = orderSndRcvJnl.UOESectionSlipNo;                               // 拠点
                dataRow[PMUOE04103EA.ct_Col_BOSlipNo2] = string.Empty;                                                  // なし
                dataRow[PMUOE04103EA.ct_Col_BOSlipNo3] = orderSndRcvJnl.BOSlipNo1;                                      // ＳＦ
                dataRow[PMUOE04103EA.ct_Col_BOManagementNo] = string.Empty;                                             // なし
                dataRow[PMUOE04103EA.ct_Col_UOESectOutGoodsCnt] = hondaSectionCode;                                     // 出荷元
                dataRow[PMUOE04103EA.ct_Col_BOShipmentCnt1] = orderSndRcvJnl.UOESectOutGoodsCnt.ToString(format);       // 拠点出荷数
                dataRow[PMUOE04103EA.ct_Col_BOShipmentCnt2] = orderSndRcvJnl.SourceShipment;                            // 出荷元
                dataRow[PMUOE04103EA.ct_Col_BOShipmentCnt3] = orderSndRcvJnl.BOShipmentCnt1.ToString(format);           // ＳＦ出荷数
                dataRow[PMUOE04103EA.ct_Col_EOAlwcCount] = string.Empty;                                                // なし
                dataRow[PMUOE04103EA.ct_Col_MakerFollowCnt] = string.Empty;                                             // なし
            }
            else
            {
                dataRow[PMUOE04103EA.ct_Col_UOESectionSlipNo] = orderSndRcvJnl.UOESectionSlipNo;                        // 拠点伝票
                dataRow[PMUOE04103EA.ct_Col_BOSlipNo1] = orderSndRcvJnl.BOSlipNo1;                                      // BO伝票1
                dataRow[PMUOE04103EA.ct_Col_BOSlipNo2] = orderSndRcvJnl.BOSlipNo2;                                      // BO伝票2
                dataRow[PMUOE04103EA.ct_Col_BOSlipNo3] = orderSndRcvJnl.BOSlipNo3;                                      // BO伝票3
                dataRow[PMUOE04103EA.ct_Col_BOManagementNo] = orderSndRcvJnl.BOManagementNo;                            // BO管理番号
                dataRow[PMUOE04103EA.ct_Col_UOESectOutGoodsCnt] = orderSndRcvJnl.UOESectOutGoodsCnt.ToString(format);   // UOE拠点出庫数
                dataRow[PMUOE04103EA.ct_Col_BOShipmentCnt1] = orderSndRcvJnl.BOShipmentCnt1.ToString(format);           // BO出庫数1
                dataRow[PMUOE04103EA.ct_Col_BOShipmentCnt2] = orderSndRcvJnl.BOShipmentCnt2.ToString(format);           // BO出庫数2
                dataRow[PMUOE04103EA.ct_Col_BOShipmentCnt3] = orderSndRcvJnl.BOShipmentCnt3.ToString(format);           // BO出庫数3
                dataRow[PMUOE04103EA.ct_Col_EOAlwcCount] = orderSndRcvJnl.EOAlwcCount.ToString(format);                 // EO引当数
                dataRow[PMUOE04103EA.ct_Col_MakerFollowCnt] = orderSndRcvJnl.MakerFollowCnt.ToString(format);           // メーカーフォロー数
            }
            // --- ADD 2008/12/18 ② ------------------------------------------------------------------------------------------------<<<<<

            // メーカーコード
            if (orderSndRcvJnl.GoodsMakerCd == 0)
            {
                dataRow[PMUOE04103EA.ct_Col_GoodsMakerCd] = string.Empty;
            }
            else
            {
                dataRow[PMUOE04103EA.ct_Col_GoodsMakerCd] = orderSndRcvJnl.GoodsMakerCd.ToString("0000");
            }

            /* --- DEL 2008/12/18 ② ------------------------------------------------------------------------------------------------>>>>> 
            // BO伝票3
            int programId = this.GetProgramIdFromUOEOrderDtlHTable(orderSndRcvJnl.UOESupplierCd);
            if (programId == PROGRAMID_HONDA)
            {
                dataRow[PMUOE04103EA.ct_Col_BOSlipNo3] = orderSndRcvJnl.SourceShipment;             // 出荷元
            }
            else
            {
                dataRow[PMUOE04103EA.ct_Col_BOSlipNo3] = orderSndRcvJnl.BOSlipNo3;                  // BO伝票3
            }
               --- DEL 2008/12/18 ② ------------------------------------------------------------------------------------------------<<<<< */
            // 倉庫・棚番
            Int32 warehouseCode;
            try
            {
                warehouseCode = Int32.Parse(orderSndRcvJnl.WarehouseCode);
                dataRow[PMUOE04103EA.ct_Col_WarehouseShelfNo] = warehouseCode.ToString("0000") + " " + orderSndRcvJnl.WarehouseShelfNo;
            }
            catch
            {
                dataRow[PMUOE04103EA.ct_Col_WarehouseShelfNo] = orderSndRcvJnl.WarehouseCode + " " + orderSndRcvJnl.WarehouseShelfNo;
            }

            // 出荷数計(各出荷数 + ＭＦ)
            double shipmentCntTotal = orderSndRcvJnl.UOESectOutGoodsCnt
                                    + orderSndRcvJnl.BOShipmentCnt1
                                    + orderSndRcvJnl.BOShipmentCnt2
                                    + orderSndRcvJnl.BOShipmentCnt3
                                    + orderSndRcvJnl.EOAlwcCount
                                    + orderSndRcvJnl.MakerFollowCnt;


            // 残(受注数量 - 出荷数計)
            double remainderCount = orderSndRcvJnl.AcceptAnOrderCnt - shipmentCntTotal;
            dataRow[PMUOE04103EA.ct_Col_RemainderCount] = remainderCount;

            // コメント
            #region
            //if (string.IsNullOrEmpty(orderSndRcvJnl.HeadErrorMassage) == false)           //DEL 2009/01/21 不具合対応[10134]
            if (string.IsNullOrEmpty(orderSndRcvJnl.HeadErrorMassage.Trim()) == false)      //ADD 2009/01/21 不具合対応[10134]
            {
                // ヘッドエラーメッセージ
                dataRow[PMUOE04103EA.ct_Col_Comment] = orderSndRcvJnl.HeadErrorMassage;
            }
            //else if (string.IsNullOrEmpty(orderSndRcvJnl.LineErrorMassage) == false)      //DEL 2009/01/21 不具合対応[10134]
            else if (string.IsNullOrEmpty(orderSndRcvJnl.LineErrorMassage.Trim()) == false) //ADD 2009/01/21 不具合対応[10134]
            {
                // ラインエラーメッセージ
                dataRow[PMUOE04103EA.ct_Col_Comment] = orderSndRcvJnl.LineErrorMassage;
            }
            //else if (string.IsNullOrEmpty(orderSndRcvJnl.SubstPartsNo) == false)          //DEL 2009/01/21 不具合対応[10134]
            else if (string.IsNullOrEmpty(orderSndRcvJnl.SubstPartsNo.Trim()) == false)     //ADD 2009/01/21 不具合対応[10134]
            {
                // 代替品番
                dataRow[PMUOE04103EA.ct_Col_Comment] = orderSndRcvJnl.SubstPartsNo;
            }
            else
            {
                dataRow[PMUOE04103EA.ct_Col_Comment] = string.Empty;
            }
            #endregion

            // 前景色
            #region
            /* ---DEL 2009/01/20 不具合対応[10165] ------------------------------------------------------------------->>>>>
            if ((remainderCount != 0) || (orderSndRcvJnl.MakerFollowCnt != 0) || (orderSndRcvJnl.AnswerSalesUnitCost == 0))
            {
                // 「残 != 0」 or 「ﾒｰｶｰﾌｫﾛｰ数 != 0」 or 「回答原価単価 = 0」
                dataRow[PMUOE04103EA.ct_Col_ForeColor] = "BLUE";
            }
            else if ((string.IsNullOrEmpty(orderSndRcvJnl.HeadErrorMassage)) &&
                     (string.IsNullOrEmpty(orderSndRcvJnl.LineErrorMassage)) &&
                     (string.IsNullOrEmpty(orderSndRcvJnl.SubstPartsNo) == false))
            {
                // 代替品番 != ｽﾍﾟｰｽ
                dataRow[PMUOE04103EA.ct_Col_ForeColor] = "GREEN";
            }
            else if (shipmentCntTotal == 0)
            {
                // UOE拠点出庫数 + BO出庫数1～3 + ﾒｰｶｰﾌｫﾛｰ数 + EO引当数 = 0
                dataRow[PMUOE04103EA.ct_Col_ForeColor] = "RED";
            }
            else
            {
                dataRow[PMUOE04103EA.ct_Col_ForeColor] = string.Empty;
            }
               ---DEL 2009/01/20 不具合対応[10165] -------------------------------------------------------------------<<<<< */
            // ---ADD 2009/01/20 不具合対応[10165] ------------------------------------------------------------------->>>>>
            // 代替品
            if ((string.IsNullOrEmpty(orderSndRcvJnl.HeadErrorMassage.Trim())) &&
                (string.IsNullOrEmpty(orderSndRcvJnl.LineErrorMassage.Trim())) &&
                (string.IsNullOrEmpty(orderSndRcvJnl.SubstPartsNo.Trim()) == false))
            {
                dataRow[PMUOE04103EA.ct_Col_ForeColor] = "GREEN";
            }
            // 全部残
            else if (shipmentCntTotal == 0)
            {
                dataRow[PMUOE04103EA.ct_Col_ForeColor] = "RED";
            }
            // 仕切無し/一部残/ﾒｰｶｰﾌｫﾛｰ分
            else if ((remainderCount != 0) || (orderSndRcvJnl.MakerFollowCnt != 0) || (orderSndRcvJnl.AnswerSalesUnitCost == 0))
            {
                dataRow[PMUOE04103EA.ct_Col_ForeColor] = "BLUE";
            }
            else
            {
                dataRow[PMUOE04103EA.ct_Col_ForeColor] = string.Empty;
            }
            // ---ADD 2009/01/20 不具合対応[10165] -------------------------------------------------------------------<<<<<
            #endregion
        }
        #endregion

        /* --- DEL 2008/12/18 ② ------------------------------------------------------------------------------------------------>>>>> 
        #region ▼ChangeZero(ゼロ値変換)        //ADD 2008/11/28
        /// <summary>
        /// ゼロ値変換
        /// </summary>
        /// <param name="value">変換前の値</param>
        /// <returns>変換後の値</returns>
        /// <remarks>
        /// <br>Note       : 変換前の値がゼロであればDBNullとする。ゼロ以外はそのまま返す。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private Object ChangeZero(int value)
        {
            if (value == 0)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }
        #endregion
               --- DEL 2008/12/18 ② ------------------------------------------------------------------------------------------------<<<<< */
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
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/06</br>
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
            uoeAnswerLedgerOrderCndtnWork.UOEKind = uoeAnswerLedgerOrderCndtn.UOEKind;                      // UOE種別          //ADD 2008/12/18 ④
            uoeAnswerLedgerOrderCndtnWork.St_InputDay = uoeAnswerLedgerOrderCndtn.St_InputDay;              // 入力日(開始)     //ADD 2008/12/18 ④
            uoeAnswerLedgerOrderCndtnWork.Ed_InputDay = uoeAnswerLedgerOrderCndtn.Ed_InputDay;              // 入力日(終了)     //ADD 2008/12/18 ④ 

            // データ抽出            
            Object arrayList = null;
            int status = this._iUOEAnswerLedgerOrderWorkDB.Search(out arrayList, (object)uoeAnswerLedgerOrderCndtnWork, 0, ConstantManagement.LogicalMode.GetDataAll);
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

        #region ▼CopyToOrderSndRcvJnlFromUOEAnswerLedgerResultWork(発注データ→UOE送受信ジャーナルコピー　単体起動専用)
        /// <summary>
        /// 発注データ→UOE送受信ジャーナルコピー(単体起動専用)
        /// </summary>
        /// <param name="uoeAnswerLedgerResultWork">発注データ</param>
        /// <param name="orderSndRcvJnl">UOE送受信ジャーナル</param>
        /// <remarks>
        /// <br>Note       : 発注データの内容を元にUOE送受信ジャーナル(発注)を作成します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/06</br>
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
            //orderSndRcvJnl.SalesSlipNum       // 売上伝票番号
            //orderSndRcvJnl.AcptAnOdrStatus    // 受注ステータス
            //orderSndRcvJnl.SalesSlipDtlNum    // 売上明細通番
            orderSndRcvJnl.SectionCode = uoeAnswerLedgerResultWork.SectionCode;                         // 拠点コード
            orderSndRcvJnl.SubSectionCode = uoeAnswerLedgerResultWork.SubSectionCode;                   // 部門コード
            orderSndRcvJnl.CustomerCode = uoeAnswerLedgerResultWork.CustomerCode;                       // 得意先コード
            orderSndRcvJnl.CustomerSnm = uoeAnswerLedgerResultWork.CustomerSnm;                         // 得意先略称
            orderSndRcvJnl.CashRegisterNo = uoeAnswerLedgerResultWork.CashRegisterNo;                   // レジ番号
            //orderSndRcvJnl.CommonSeqNo        // 共通通番
            //orderSndRcvJnl.SupplierFormal     // 仕入形式
            //orderSndRcvJnl.SupplierSlipNo     // 仕入伝票番号
            //orderSndRcvJnl.StockSlipDtlNum    // 仕入明細通番
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
            //orderSndRcvJnl.ListPrice = uoeAnswerLedgerResultWork.ListPrice;                             // 回答定価           //DEL 2008/12/18 ③
            //orderSndRcvJnl.SalesUnitCost = uoeAnswerLedgerResultWork.SalesUnitCost;                     // 回答原価単価       //DEL 2008/12/18 ③
            orderSndRcvJnl.AnswerListPrice = uoeAnswerLedgerResultWork.AnswerListPrice;                 // 回答定価             //ADD 2008/12/18 ③
            orderSndRcvJnl.AnswerSalesUnitCost = uoeAnswerLedgerResultWork.AnswerSalesUnitCost;         // 回答原価単価         //ADD 2008/12/18 ③
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
            //orderSndRcvJnl.DataSendCode       // データ送信区分
            //orderSndRcvJnl.DataRecoverDiv     // データ復旧区分
            //orderSndRcvJnl.EnterUpdDivSec     // 入庫更新区分(拠点)
            //orderSndRcvJnl.EnterUpdDivBO1     // 入庫更新区分(BO1)
            //orderSndRcvJnl.EnterUpdDivBO2     // 入庫更新区分(BO2)
            //orderSndRcvJnl.EnterUpdDivBO3     // 入庫更新区分(BO3)
            //orderSndRcvJnl.EnterUpdDivMaker   // 入庫更新区分(メーカー)
            //orderSndRcvJnl.EnterUpdDivEO      // 入庫更新区分(EO)
        }
        #endregion
        #endregion ◆発注データ→OrderSndRcvJnl作成関連 - end
        #endregion ■Privateメソッド - end
    }
}


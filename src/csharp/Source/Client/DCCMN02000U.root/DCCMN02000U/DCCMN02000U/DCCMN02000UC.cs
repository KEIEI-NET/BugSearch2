using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using Broadleaf.Application.UIData;

namespace Broadleaf.Windows.Forms
{
    //*************************************************************
    // ※ 抽出元テーブル毎に、印刷条件クラスを定義します。
    //    印刷条件クラスは伝票印刷条件インタフェースを実装します。
    //    印刷条件クラスインスタンスは、(インタフェースを実装する為)、
    //    伝票印刷確認ＵＩのShowDialogに引数として渡す事が出来ます。
    //*************************************************************

    # region ■ 伝票印刷条件インタフェース ■
    /// <summary>
    /// 伝票印刷条件インタフェース
    /// </summary>
    public interface ISlipPrintCndtn
    {
        /// <summary>企業コード</summary>
        string EnterpriseCode { get;set;}

        /// <summary>追加情報</summary>
        ArrayList ExtrData { get;set;}
    }
    # endregion ■ 伝票印刷条件インタフェース ■

    # region ■ 売上伝票印刷条件 ■
    /// <summary>
    /// 売上伝票印刷条件クラス
    /// </summary>
    public class SalesSlipPrintCndtn : ISlipPrintCndtn
    {
        # region ■ フィールド ■
        /// <summary>企業コード</summary>
        private string _enterpriseCode;
        /// <summary>伝票ＫＥＹリスト</summary>
        private List<SalesSlipKey> _salesSlipKeyList;
        /// <summary>追加情報</summary>
        private ArrayList _extrData;
        /// <summary>再発行区分</summary>
        private bool _reissueDiv;
        // --- ADD m.suzuki 2010/07/09 ---------->>>>>
        /// <summary>QR作成区分</summary>
        private bool _makeQRDiv;
        // --- ADD m.suzuki 2010/07/09 ----------<<<<<
        //zhouzy add 2011.09.15 add begin
        //普通帳票（リモート伝票以外）印刷用フラグ（0：印刷、1：印刷しない）
        int _nomalSalesSlipPrintFlag;
        //リモート帳票（リモート伝票以外）印刷用フラグ（0：印刷、1：印刷しない）
        int _remoteSalesSlipPrintFlag;
        //ＳＣＭ送信フラグ
        bool _scmFlg;
        //ＳＣＭ全体設定の売上伝票印刷区分
        int _SCMTotalSettingSalesSlipPrtDiv;
        //zhouzy add 2011.09.15 add end
        # endregion ■ フィールド ■

        # region ■ プロパティ ■
        /// <summary>
        /// 企業コード
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }
        /// <summary>
        /// 売上伝票ＫＥＹリスト
        /// </summary>
        public List<SalesSlipKey> SalesSlipKeyList
        {
            get { return _salesSlipKeyList; }
            set { _salesSlipKeyList = value; }
        }

        /// <summary>
        /// 追加情報プロパティ（予備）
        /// </summary>
        public ArrayList ExtrData
        {
            get { return _extrData; }
            set { _extrData = value; }
        }
        /// <summary>
        /// 再発行区分
        /// </summary>
        public bool ReissueDiv
        {
            get { return _reissueDiv; }
            set { _reissueDiv = value; }
        }
        // --- ADD m.suzuki 2010/07/09 ---------->>>>>
        /// <summary>
        /// QR作成区分
        /// </summary>
        public bool MakeQRDiv
        {
            get { return _makeQRDiv; }
            set { _makeQRDiv = value; }
        }
        // --- ADD m.suzuki 2010/07/09 ----------<<<<<
        
        //zhouzy add 2011.09.15 add begin
        /// <summary>
        /// 普通帳票（リモート伝票以外）印刷用フラグ
        /// </summary>
        public int NomalSalesSlipPrintFlag
        {
            get { return this._nomalSalesSlipPrintFlag; }
            set { this._nomalSalesSlipPrintFlag = value; }
        }
        /// <summary>
        /// 普通帳票（リモート伝票以外）印刷用フラグ
        /// </summary>
        public int RemoteSalesSlipPrintFlag
        {
            get { return this._remoteSalesSlipPrintFlag; }
            set { this._remoteSalesSlipPrintFlag = value; }
        }

        /// <summary>
        /// SCM送信フラグ
        /// </summary>
        public bool ScmFlg
        {
            get { return this._scmFlg; }
            set { _scmFlg = value; }
        }

        /// <summary>
        /// ＳＣＭ全体設定の売上伝票印刷区分
        /// </summary>
        public int SCMTotalSettingSalesSlipPrtDiv
        {
            get { return this._SCMTotalSettingSalesSlipPrtDiv; }
            set { _SCMTotalSettingSalesSlipPrtDiv = value; }         
        }
            //zhouzy add 2011.09.15 add end
        # endregion ■ プロパティ ■

        # region ■ コンストラクタ ■
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SalesSlipPrintCndtn()
        {
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="salesSlipKeyList">伝票ＫＥＹリスト</param>
        /// <param name="extrData">追加情報</param>
        public SalesSlipPrintCndtn( string enterpriseCode, List<SalesSlipKey> salesSlipKeyList, ArrayList extrData )
        {
            this._enterpriseCode = enterpriseCode;
            this._salesSlipKeyList = salesSlipKeyList;
            this._extrData = extrData;
        }
        # endregion ■ コンストラクタ ■

        # region ■ 売上伝票ＫＥＹ ■
        /// <summary>
        /// 売上伝票ＫＥＹ項目　構造体
        /// </summary>
        public struct SalesSlipKey
        {
            private int _acptAnOdrStatus;
            private string _salesSlipNum;

            /// <summary>
            /// 受注ステータス
            /// </summary>
            public int AcptAnOdrStatus
            {
                get { return _acptAnOdrStatus; }
                set { _acptAnOdrStatus = value; }
            }
            /// <summary>
            /// 伝票番号
            /// </summary>
            public string SalesSlipNum
            {
                get { return _salesSlipNum; }
                set { _salesSlipNum = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="acptAnOdrStatus">受注ステータス</param>
            /// <param name="salesSlipNum">伝票番号</param>
            public SalesSlipKey( int acptAnOdrStatus, string salesSlipNum )
            {
                this._acptAnOdrStatus = acptAnOdrStatus;
                this._salesSlipNum = salesSlipNum;
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="salesSlip">売上伝票</param>
            public SalesSlipKey( SalesSlip salesSlip )
            {
                this._acptAnOdrStatus = salesSlip.AcptAnOdrStatus;
                this._salesSlipNum = salesSlip.SalesSlipNum;
            }

        }
        # endregion ■ 売上伝票ＫＥＹ ■
    }
    # endregion ■ 売上伝票印刷条件 ■

    # region ■ 見積書印刷条件 ■
    /// <summary>
    /// 見積書印刷条件クラス
    /// </summary>
    public class EstFmPrintCndtn : ISlipPrintCndtn
    {
        # region ■ フィールド ■
        /// <summary>企業コード</summary>
        private string _enterpriseCode;
        /// <summary>見積書単位リスト</summary>
        private List<EstFmUnitData> _estFmUnitDataList;
        /// <summary>見積初期値設定データ</summary>
        private EstimateDefSet _estimateDefSet;
        /// <summary>追加情報</summary>
        private ArrayList _extrData;
        # endregion ■ フィールド ■

        # region ■ プロパティ ■
        /// <summary>
        /// 企業コード
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }
        /// <summary>
        /// 見積書単位データリスト
        /// </summary>
        public List<EstFmUnitData> EstFmUnitDataList
        {
            get { return _estFmUnitDataList; }
            set { _estFmUnitDataList = value; }
        }
        /// <summary>
        /// 見積初期値設定データ
        /// </summary>
        public EstimateDefSet EstimateDefSet
        {
            get { return _estimateDefSet; }
            set { _estimateDefSet = value; }
        }
        /// <summary>
        /// 追加情報プロパティ（予備）
        /// </summary>
        public ArrayList ExtrData
        {
            get { return _extrData; }
            set { _extrData = value; }
        }
        # endregion ■ プロパティ ■

        # region ■ コンストラクタ ■
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public EstFmPrintCndtn()
        {
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="estFmUnitDataList">伝票ＫＥＹリスト</param>
        /// <param name="estimateDefSet">見積初期値設定データ</param>
        /// <param name="extrData">追加情報</param>
        public EstFmPrintCndtn( string enterpriseCode, List<EstFmUnitData> estFmUnitDataList, EstimateDefSet estimateDefSet, ArrayList extrData )
        {
            this._enterpriseCode = enterpriseCode;
            this._estFmUnitDataList = estFmUnitDataList;
            this._estimateDefSet = estimateDefSet;
            this._extrData = extrData;
        }
        # endregion ■ コンストラクタ ■

        # region [見積書単位データ]
        /// <summary>
        /// 見積書単位データ
        /// </summary>
        public class EstFmUnitData
        {
            /// <summary>見積書ヘッダ</summary>
            private FrePEstFmHead _frePEstFmHead;
            /// <summary>見積書明細リスト</summary>
            private List<FrePEstFmDetail> _frePEstFmDetailList;
            /// <summary>印刷部数</summary>
            private int _printCount;

            /// <summary>
            /// 見積書ヘッダ　プロパティ
            /// </summary>
            public FrePEstFmHead FrePEstFmHead
            {
                get { return _frePEstFmHead; }
                set { _frePEstFmHead = value; }
            }
            /// <summary>
            /// 見積書明細リスト　プロパティ
            /// </summary>
            public List<FrePEstFmDetail> FrePEstFmDetailList
            {
                get { return _frePEstFmDetailList; }
                set { _frePEstFmDetailList = value; }
            }
            /// <summary>
            /// 印刷部数　プロパティ
            /// </summary>
            public int PrintCount
            {
                get { return _printCount; }
                set { _printCount = value; }
            }

            /// <summary>
            /// コンストラクタ
            /// </summary>
            public EstFmUnitData()
            {
                _printCount = 1; // 印刷部数の初期値は１
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="frePEstFmHead">見積書ヘッダ</param>
            /// <param name="frePEstFmDetailList">見積書明細リスト</param>
            /// <param name="printCount">印刷部数</param>
            public EstFmUnitData( FrePEstFmHead frePEstFmHead, List<FrePEstFmDetail> frePEstFmDetailList, int printCount )
            {
                _frePEstFmHead = frePEstFmHead;
                _frePEstFmDetailList = frePEstFmDetailList;
                _printCount = printCount;
            }
        }
        # endregion
    }
    # endregion ■ 見積書印刷条件 ■

    # region ■ 仕入伝票印刷条件 ■
    /// <summary>
    /// 仕入伝票印刷条件クラス
    /// </summary>
    public class StockSlipPrintCndtn : ISlipPrintCndtn
    {
        # region ■ フィールド ■
        /// <summary>企業コード</summary>
        private string _enterpriseCode;
        /// <summary>伝票ＫＥＹリスト</summary>
        private List<StockSlipKey> _stockSlipKeyList;
        /// <summary>追加情報</summary>
        private ArrayList _extrData;
        # endregion ■ フィールド ■

        # region ■ プロパティ ■
        /// <summary>
        /// 企業コード
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }
        /// <summary>
        /// 仕入伝票ＫＥＹリスト
        /// </summary>
        public List<StockSlipKey> StockSlipKeyList
        {
            get { return _stockSlipKeyList; }
            set { _stockSlipKeyList = value; }
        }

        /// <summary>
        /// 追加情報プロパティ（予備）
        /// </summary>
        public ArrayList ExtrData
        {
            get { return _extrData; }
            set { _extrData = value; }
        }
        # endregion ■ プロパティ ■

        # region ■ コンストラクタ ■
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public StockSlipPrintCndtn()
        {
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="stockSlipKeyList">伝票ＫＥＹリスト</param>
        /// <param name="extrData">追加情報</param>
        public StockSlipPrintCndtn( string enterpriseCode, List<StockSlipKey> stockSlipKeyList, ArrayList extrData )
        {
            this._enterpriseCode = enterpriseCode;
            this._stockSlipKeyList = stockSlipKeyList;
            this._extrData = extrData;
        }
        # endregion ■ コンストラクタ ■

        # region ■ 仕入伝票ＫＥＹ ■
        /// <summary>
        /// 仕入伝票ＫＥＹ項目　構造体
        /// </summary>
        public struct StockSlipKey
        {
            /// <summary>仕入形式</summary>
            private int _supplierFormal;
            /// <summary>仕入伝票番号</summary>
            private int _supplierSlipNo;

            /// <summary>
            /// 仕入形式
            /// </summary>
            public int SupplierFormal
            {
                get { return _supplierFormal; }
                set { _supplierFormal = value; }
            }
            /// <summary>
            /// 仕入伝票番号
            /// </summary>
            public int SupplierSlipNo
            {
                get { return _supplierSlipNo; }
                set { _supplierSlipNo = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="supplierFormal">受注ステータス</param>
            /// <param name="supplierSlipNo">伝票番号</param>
            public StockSlipKey( int supplierFormal, int supplierSlipNo )
            {
                this._supplierFormal = supplierFormal;
                this._supplierSlipNo = supplierSlipNo;
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="stockSlip">仕入伝票</param>
            public StockSlipKey( StockSlip stockSlip )
            {
                this._supplierFormal = stockSlip.SupplierFormal;
                this._supplierSlipNo = stockSlip.SupplierSlipNo;
            }
        }
        # endregion ■ 仕入伝票ＫＥＹ ■
    }
    # endregion ■ 仕入伝票印刷条件 ■

    # region ■ 在庫移動伝票印刷条件 ■
    /// <summary>
    /// 在庫移動伝票印刷条件クラス
    /// </summary>
    public class StockMoveSlipPrintCndtn : ISlipPrintCndtn
    {
        # region ■ フィールド ■
        /// <summary>企業コード</summary>
        private string _enterpriseCode;
        /// <summary>伝票ＫＥＹリスト</summary>
        private List<StockMoveSlipKey> _stockMoveSlipKeyList;
        /// <summary>追加情報</summary>
        private ArrayList _extrData;
        /// <summary>再発行区分</summary>
        private bool _reissueDiv;
        # endregion ■ フィールド ■

        # region ■ プロパティ ■
        /// <summary>
        /// 企業コード
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }
        /// <summary>
        /// 在庫移動伝票ＫＥＹリスト
        /// </summary>
        public List<StockMoveSlipKey> StockMoveSlipKeyList
        {
            get { return _stockMoveSlipKeyList; }
            set { _stockMoveSlipKeyList = value; }
        }

        /// <summary>
        /// 追加情報プロパティ（予備）
        /// </summary>
        public ArrayList ExtrData
        {
            get { return _extrData; }
            set { _extrData = value; }
        }
        /// <summary>
        /// 再発行区分
        /// </summary>
        public bool ReissueDiv
        {
            get { return _reissueDiv; }
            set { _reissueDiv = value; }
        }
        # endregion ■ プロパティ ■

        # region ■ コンストラクタ ■
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public StockMoveSlipPrintCndtn()
        {
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="stockMoveSlipKeyList">伝票ＫＥＹリスト</param>
        /// <param name="extrData">追加情報</param>
        public StockMoveSlipPrintCndtn( string enterpriseCode, List<StockMoveSlipKey> stockMoveSlipKeyList, ArrayList extrData )
        {
            this._enterpriseCode = enterpriseCode;
            this._stockMoveSlipKeyList = stockMoveSlipKeyList;
            this._extrData = extrData;
        }
        # endregion ■ コンストラクタ ■

        # region ■ 在庫移動伝票ＫＥＹ ■
        /// <summary>
        /// 在庫移動伝票ＫＥＹ項目　構造体
        /// </summary>
        public struct StockMoveSlipKey
        {
            private int _stockMoveFormal;
            private int _stockMoveSlipNo;

            /// <summary>
            /// 在庫移動形式
            /// </summary>
            public int StockMoveFormal
            {
                get { return _stockMoveFormal; }
                set { _stockMoveFormal = value; }
            }
            /// <summary>
            /// 在庫移動伝票番号
            /// </summary>
            public int StockMoveSlipNo
            {
                get { return _stockMoveSlipNo; }
                set { _stockMoveSlipNo = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="stockMoveFormal">在庫移動形式</param>
            /// <param name="stockMoveSlipNo">在庫移動伝票番号</param>
            public StockMoveSlipKey( int stockMoveFormal, int stockMoveSlipNo )
            {
                this._stockMoveFormal = stockMoveFormal;
                this._stockMoveSlipNo = stockMoveSlipNo;
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="stockMove">在庫移動データ</param>
            public StockMoveSlipKey( StockMove stockMove )
            {
                this._stockMoveFormal = stockMove.StockMoveFormal;
                this._stockMoveSlipNo = stockMove.StockMoveSlipNo;
            }
        }
        # endregion ■ 在庫移動伝票ＫＥＹ ■
    }
    # endregion ■ 売上伝票印刷条件 ■

    # region ■ UOE伝票印刷条件 ■
    /// <summary>
    /// UOE伝票印刷条件クラス
    /// </summary>
    public class UOESlipPrintCndtn : ISlipPrintCndtn
    {
        # region ■ フィールド ■
        /// <summary>企業コード</summary>
        private string _enterpriseCode;
        /// <summary>UOE伝票単位リスト</summary>
        private List<UoeSales> _uoeSalesList;
        /// <summary>追加情報</summary>
        private ArrayList _extrData;
        # endregion ■ フィールド ■

        # region ■ プロパティ ■
        /// <summary>
        /// 企業コード
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }
        /// <summary>
        /// UOE伝票単位データリスト
        /// </summary>
        public List<UoeSales> UOESalesList
        {
            get { return _uoeSalesList; }
            set { _uoeSalesList = value; }
        }
        /// <summary>
        /// 追加情報プロパティ（予備）
        /// </summary>
        public ArrayList ExtrData
        {
            get { return _extrData; }
            set { _extrData = value; }
        }
        # endregion ■ プロパティ ■

        # region ■ コンストラクタ ■
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public UOESlipPrintCndtn()
        {
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="uoeSalesList">伝票ＫＥＹリスト</param>
        /// <param name="extrData">追加情報</param>
        public UOESlipPrintCndtn( string enterpriseCode, List<UoeSales> uoeSalesList, ArrayList extrData )
        {
            this._enterpriseCode = enterpriseCode;
            this._uoeSalesList = uoeSalesList;
            this._extrData = extrData;
        }
        # endregion ■ コンストラクタ ■
    }
    # endregion ■ UOE伝票印刷条件 ■

}

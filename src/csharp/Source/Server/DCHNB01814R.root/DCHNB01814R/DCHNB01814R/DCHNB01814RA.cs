using System;
using System.IO;
using System.Data;
using System.Reflection;
using System.Collections;
using System.Data.SqlClient;
using Broadleaf.Library.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlTypes;

namespace Broadleaf.Application.Remoting
{
    /// public class name:   IOWriteMAHNBDB
    /// <summary>
    ///                      売上エントリ更新リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>note             :   エントリ更新</br>
    /// <br>Programmer       :   21112　久保田　誠</br>
    /// <br>Date             :   2007/11/26</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   SCM対応</br>
    /// <br>Programmer       :   22008 長内</br>
    /// <br>Date             :   2009/05/18</br>
    /// <br>Update Note      :   2009/09/16       汪千来</br>
    ///	<br>		         :   車輌備考を追加する</br>
    /// <br>Update Note      :   2009/10/26       張凱</br>
    ///	<br>		         :   赤伝時、車輌情報処理を追加する</br>
    /// <br>Update Note      :   2010/04/27 gaoyh</br>
    /// <br>                 :   受注マスタ（車両）自由検索型式固定番号配列の追加対応</br>
    /// <br>Update Note      :   2010/05/13 22018 鈴木 正臣</br>
    /// <br>                 :   自由検索自動登録対応</br>
    /// <br>Update Note      :   2010/05/13 22018 鈴木 正臣</br>
    /// <br>                 :   成果物統合</br>
    /// <br>                 :   　自由検索 2010/04/27 の組込</br>
    /// <br>                 :   　自由検索 2010/05/13 の組込</br>
    /// <br>Update Note      :   2010/09/28 20056 對馬 大輔</br>
    /// <br>                 :   　入金データ同時削除対応</br>
    /// <br>Update Note      :   2011/07/25 斉建華</br>
    /// <br>                 :   　SCM対応 - 拠点管理(10704767-00)</br>
    /// <br>Update Note      :   PCCUOE自動回答の対応</br>
    /// <br>Programmer       :   高峰</br>
    /// <br>Date             :   2011/08/10</br>
    /// <br>Update Note      :   2011/09/15 qijh</br>
    /// <br>                 :   #25167を対応</br>
    /// <br></br>
    /// <br>Update Note      :   障害対応(計上残区分：残さないで同時入力(受注売上)を行うと2重で在庫が更新される)</br>
    /// <br>Programmer       :   20056 對馬 大輔</br>
    /// <br>Date             :   2011/12/08</br>
    /// <br></br>
    /// <br>Update Note      :   自動入金データの伝票更新時、送信済みだった場合にエラーが発生する現象の修正</br>
    /// <br>Programmer       :   22008 長内 数馬</br>
    /// <br>Date             :   2012/01/20</br>
    /// <br></br>
    /// <br>Update Note      :   車輌マスタの伝票更新時、売上伝票項目のみ更新するように修正</br>
    /// <br>Programmer       :   脇田 靖之</br>
    /// <br>Date             :   2012/08/29</br>
    /// <br></br>
    /// <br>Update Note      :   売上、売上履歴削除時に更新に失敗した場合、リターンするように修正</br>
    /// <br>Programmer       :   脇田 靖之</br>
    /// <br>Date             :   2012/09/24</br>
    /// <br></br>
    /// <br>Update Note      :   障害対応(「受注計上残区分：残さない」で計上した売上伝票が伝票修正で呼出せない障害の修正)</br>
    /// <br>Programmer       :   脇田 靖之</br>
    /// <br>Date             :   2012/09/27</br>
    /// <br></br>
    /// <br>Update Note      :   得意先マスタ(変動情報)の売掛残高更新条件を修正</br>
    /// <br>Programmer       :   脇田 靖之</br>
    /// <br>Date             :   2013/03/12</br>
    /// <br></br>
    /// <br>Update Note      :   得意先マスタ(変動情報)の売掛残高更新条件を修正</br>
    /// <br>                     （自動入金の場合は更新しない）</br>
    /// <br>Programmer       :   脇田 靖之</br>
    /// <br>Date             :   2013/03/18</br>
    /// <br>Update Note      :   SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
    /// <br>Programmer       :   FSI厚川 宏</br>
    /// <br>Date             :   2013/03/21</br>
    /// <br>管理番号         :   10900269-00</br>
    /// <br>Update Note      :   2013/06/18配信　SCM障害№10308,№10528</br>
    /// <br>Programmer       :   30747 三戸 伸悟</br>
    /// <br>Date             :   2013/05/08</br>
    /// <br>管理番号         :   10801804-00</br>
    /// <br>Update Note      :   2013/06/18配信　SCM障害№10410</br>
    /// <br>Programmer       :   30745 吉岡</br>
    /// <br>Date             :   2013/05/15</br>
    /// <br>管理番号         :   10801804-00</br>
    /// <br>Update Note      :   2013/06/18配信　システムテスト障害№18</br>
    /// <br>Programmer       :   30747 三戸 伸悟</br>
    /// <br>Date             :   2013/06/03</br>
    /// <br>管理番号         :   10801804-00</br>
    /// </remarks>
    [Serializable]
    public class IOWriteMAHNBDB : RemoteWithAppLockDB, IIOWriteMAHNBDB
    {
        # region [いろいろ]

        //処理コントロール部品
        private FunctionCallControl _functionCallControl;

        //--- ADD 2008/03/03 M.Kubota --->>>
        private IOWriteCtrlOptWork _CtrlOptWork = null;

        /// <summary>
        /// 売上・仕入制御オプション プロパティ
        /// </summary>
        public IOWriteCtrlOptWork IOWriteCtrlOptWork
        {
            get
            {
                return this._CtrlOptWork;
            }

            set
            {
                if (this._CtrlOptWork != value)
                {
                    this._CtrlOptWork = value;
                }
            }
        }

        private SalesSlipDB _SalesSlipDB = null;

        /// <summary>
        /// 売上リモート プロパティ
        /// </summary>
        private SalesSlipDB SalesSlipDb
        {
            get
            {
                if (this._SalesSlipDB == null)
                {
                    this._SalesSlipDB = new SalesSlipDB();
                }

                this._SalesSlipDB.IOWriteCtrlOptWork = this.IOWriteCtrlOptWork;

                return this._SalesSlipDB;
            }
        }

        private IOWriteMAHNBDepositDB _depositDB = null;

        /// <summary>
        /// 入金リモート プロパティ
        /// </summary>
        private IOWriteMAHNBDepositDB DepositDb
        {
            get
            {
                if (this._depositDB == null)
                {
                    this._depositDB = new IOWriteMAHNBDepositDB();
                }

                return this._depositDB;
            }
        }
        
        private IOWriteMAHNBStockUpdateDB _iOWriteMAHNBStockUpdateDB = null;

        /// <summary>
        /// 在庫更新リモート プロパティ
        /// </summary>
        private IOWriteMAHNBStockUpdateDB StockUpdDb
        {
            get
            {
                if (this._iOWriteMAHNBStockUpdateDB == null)
                {
                    //this._iOWriteMAHNBStockUpdateDB = new IOWriteMAHNBStockUpdateDB();                 //DEL 2009/01/30 M.Kubota
                    this._iOWriteMAHNBStockUpdateDB = new IOWriteMAHNBStockUpdateDB(this._CtrlOptWork);  //ADD 2009/01/30 M.Kubota
                }

                return this._iOWriteMAHNBStockUpdateDB;
            }
        }

        private SalesSlipHistDB _salesSlipHistDB = null;

        /// <summary>
        /// 売上履歴リモート プロパティ
        /// </summary>
        private SalesSlipHistDB SalesSlipHistDb
        {
            get
            {
                if (this._salesSlipHistDB == null)
                {
                    this._salesSlipHistDB = new SalesSlipHistDB();
                }

                return this._salesSlipHistDB;
            }
        }
        //--- ADD 2008/03/03 M.Kubota ---<<<

        //--- ADD 2008/06/06 M.Kubota --->>>

        private AcceptOdrCarDB _acpOdrCarDB = null;

        /// <summary>
        /// 受注マスタ(車両)リモートプロパティ
        /// </summary>
        private AcceptOdrCarDB acpOdrCarDB
        {
            get
            {
                if (this._acpOdrCarDB == null)
                {
                    // 受注マスタ(車両)リモートを生成
                    this._acpOdrCarDB = new AcceptOdrCarDB(true);  // 更新日付を問わない強制上書きモード
                }

                return this._acpOdrCarDB;
            }
        }


        private CarManagementDB _carMgrDB = null;

        /// <summary>
        /// 車両管理マスタリモートプロパティ
        /// </summary>
        private CarManagementDB carMgrDB
        {
            get
            {
                if (this._carMgrDB == null)
                {
                    // 車両管理マスタリモートを生成
                    this._carMgrDB = new CarManagementDB(true);  // 更新日付を問わない強制上書きモード
                }

                return this._carMgrDB;
            }
        }

        private CustomerChangeDB _customerChangeDB = null;

        /// <summary>
        /// 得意先マスタ(変動情報)リモート プロパティ
        /// </summary>
        private CustomerChangeDB CustomerChangeDb
        {
            get
            {
                if (this._customerChangeDB == null)
                {
                    this._customerChangeDB = new CustomerChangeDB();
                }

                return this._customerChangeDB;
            }
        }

        private IOWriteGoodsUser _ioWriteGoodsUser = null;

        /// <summary>
        /// 商品マスタ(ユーザー)リモート プロパティ
        /// </summary>
        private IOWriteGoodsUser GoodsUserDb
        {
            get
            {
                if (this._ioWriteGoodsUser == null)
                {
                    this._ioWriteGoodsUser = new IOWriteGoodsUser();
                }

                return this._ioWriteGoodsUser;
            }
        }

        private IOWriteGoodsPriceUser _ioWriteGoodsPriceUser = null;
        
        /// <summary>
        /// 商品価格マスタ(ユーザー)リモート プロパティ
        /// </summary>
        private IOWriteGoodsPriceUser GoodsPriceUserDb
        {
            get
            {
                if (this._ioWriteGoodsPriceUser == null)
                {
                    this._ioWriteGoodsPriceUser = new IOWriteGoodsPriceUser();
                }

                return this._ioWriteGoodsPriceUser;
            }
        }

        private MonthlyTtlSalesUpdDB _monthTtlSlsUpdDb = null;

        /// <summary>
        /// 売上月次集計データ更新リモート プロパティ
        /// </summary>
        private MonthlyTtlSalesUpdDB MonthlyTtlSalesUpdDb
        {
            get
            {
                if (this._monthTtlSlsUpdDb == null)
                {
                    this._monthTtlSlsUpdDb = new MonthlyTtlSalesUpdDB();
                }

                return this._monthTtlSlsUpdDb;
            }
        }
        //--- ADD 2008/06/06 M.Kubota ---<<<


        // 2009/05/18 >>>>>>>>>>>>>>>>>>>>
        private IOWriteScmDB _scmIOWriteDB = null;           // SCMIOWriter
        
        /// <summary>
        /// SCM I/O Write リモートプロパティ
        /// </summary>
        private IOWriteScmDB scmIOWriteDB
        {
            get
            {
                if (this._scmIOWriteDB == null)
                {
                    this._scmIOWriteDB = new IOWriteScmDB();
                }

                return this._scmIOWriteDB;
            }
        }
        // 2009/05/18 <<<<<<<<<<<<<<<<<<<<

        // --- ADD m.suzuki 2010/05/13 ---------->>>>>
        private IOWriteFreeSearchParts _ioWriteFreeSearchParts;

        /// <summary>
        /// 自由検索部品 I/O Write リモートプロパティ
        /// </summary>
        public IOWriteFreeSearchParts FreeSearchPartsDB
        {
            get
            {
                if ( this._ioWriteFreeSearchParts == null )
                {
                    this._ioWriteFreeSearchParts = new IOWriteFreeSearchParts();
                }
                return _ioWriteFreeSearchParts;
            }
        }
        // --- ADD m.suzuki 2010/05/13 ----------<<<<<

        //>>>2011/12/08
        private ArrayList _sameInputAcptList = null; // 受注売上同時入力時の計上元情報
        /// <summary>
        /// 受注売上同時入力時の計上元情報プロパティ
        /// </summary>
        public ArrayList SameInputAcptList
        {
            get
            {
                return this._sameInputAcptList;
            }

            set
            {
                this._sameInputAcptList = value;
                StockUpdDb.SameInputAcptList = this._sameInputAcptList;
            }
        }
        //<<<2011/12/08

        //プログラムID
        private string _origin = "IOWriteMAHNBDB";
        //関数コールKEY
        //前
        private string _funcCallKey_BFR = "IOWriteMAHNBDBBfr";
        //後
        private string _funcCallKey_AFT = "IOWriteMAHNBDBAft";

        // ADD 2011/07/25 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
        /// <summary>
        /// 送信済チェック失敗のステータス
        /// </summary>
        private const int STATUS_CHK_SEND_ERR = -1001;
        // ADD 2011/07/25 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<

        # endregion

        /// <summary>
        /// 売上エントリ更新リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        public IOWriteMAHNBDB()
        {
            //●更新ファンクションコントロールクラス生成
            _functionCallControl = new FunctionCallControl(IOWriteMAHNBDBServerRsc.GetResource());

            if (this._CtrlOptWork == null)
            {
                this._CtrlOptWork = new IOWriteCtrlOptWork();
                this._CtrlOptWork.CtrlStartingPoint = (int)IOWriteCtrlOptCtrlStartingPoint.Sales;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CtrlOptWork"></param>
        public IOWriteMAHNBDB(IOWriteCtrlOptWork CtrlOptWork) : this()
        {
            this._CtrlOptWork = CtrlOptWork;
        }

        #region [NewEntry] エントリ初期処理 -- DC.NSの頃より使用されていないので凍結
#if false
        /// <summary>
        /// エントリ情報入力初期処理
        /// </summary>
        /// <param name="paraList">初期処理パラメータオブジェクトリスト</param>
        /// <param name="retList">初期処理結果オブジェクトリスト</param>
        /// <returns>STATUS</returns>
        public int NewEntry(ref object paraList, out object retList)
        {
            //●STATUS初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retList = new CustomSerializeArrayList();
            SqlConnection sqlConnection = null;
            try
            {
                //●パラメータチェック
                CustomSerializeArrayList paramArray = paraList as CustomSerializeArrayList;
                if (paramArray == null || paramArray.Count <= 0)
                {
                    base.WriteErrorLog(null, "プログラムエラー。パラメータが未設定です");
                    return status;
                }

                //●NewEntry用主軸パラメータ生成
                status = MakeNewEntryFunctionParam(ref paramArray);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;

                //メソッド開始時にコネクション文字列を取得
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //●SQLコネクションオブジェクト作成
                using (sqlConnection = new SqlConnection(connectionText))
                {
                    SqlEncryptInfo sqlEncryptInfo = null;
                    try
                    {
                        sqlConnection.Open();

                        //●暗号化キーOPEN
                        sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, IOWriteMAHNBDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.NewEntry));
                        sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                        //●入力初期処理ファンクション呼び出し
                        object freeParam = null;//売上伝票更新では自由パラメータは利用しない
                        CustomSerializeArrayList retArray = new CustomSerializeArrayList();

                        //●NewEntry前オプションファンクション呼び出し
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.NewEntry(_origin, _funcCallKey_BFR, ref paramArray, ref retArray, ref freeParam, ref sqlConnection);

                        //●IOWrite NewEntry処理メイン
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = IOWriteSFFunctionProcNewEntry(ref paramArray, ref retArray, ref freeParam, ref sqlConnection);

                        //●NewEntry後オプションファンクション呼び出し
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.NewEntry(_origin, _funcCallKey_AFT, ref paramArray, ref retArray, ref freeParam, ref sqlConnection);

                        //●戻り値を設定
                        paraList = (object)paramArray;
                        retList = (object)retArray;
                    }
                    finally
                    {
                        //●暗号化キーCLOSE
                        if (sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);
                        //●コネクション破棄
                        if (sqlConnection != null) sqlConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "IOWriteMAHNBDB.NewEntry Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            //STATUSを戻す
            return status;

        }

        /// <summary>
        /// IOWrite NewEntry処理メイン
        /// </summary>
        /// <param name="paramArray">パラメータList</param>
        /// <param name="retArray">戻り値List</param>
        /// <param name="freeParam">ﾌﾘｰﾊﾟﾗﾒｰﾀ</param>
        /// <param name="sqlConnection">Sql接続情報</param>
        /// <returns>STATUS</returns>
        private Int32 IOWriteSFFunctionProcNewEntry(ref CustomSerializeArrayList paramArray, ref CustomSerializeArrayList retArray, ref object freeParam, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            //①売上NewEntry関数を呼び出す
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                int salesSlipNewEntryWork_Posi = MakePosition(paramArray, typeof(SalesSlipNewEntryWork), 0);
                status = this.SalesSlipDb.NewEntry(_origin, ref paramArray, ref retArray, salesSlipNewEntryWork_Posi, ""/*構成ﾌｧｲﾙﾊﾟﾗﾒｰﾀ無し*/, ref freeParam, ref sqlConnection);
            }

            return status;
        }

        /// <summary>
        /// NewEntry用主軸パラメータ生成
        /// </summary>
        /// <param name="paramArray">受け取りパラメータList</param>
        /// <returns>STATUS</returns>
        private int MakeNewEntryFunctionParam(ref CustomSerializeArrayList paramArray)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //売上IOWriteNewEntryパラメータから売上伝票パラメータを生成
            foreach (object obj in paramArray)
            {
                if (obj is IOWriteMAHNBNewEntryWork)
                {
                    //伝票NewEntryパラメータを生成
                    SalesSlipNewEntryWork salesSlipNewEntryWork = new SalesSlipNewEntryWork();
                    salesSlipNewEntryWork.EnterpriseCode = ((IOWriteMAHNBNewEntryWork)obj).EnterpriseCode;
                    salesSlipNewEntryWork.AcptAnOdrStatus = ((IOWriteMAHNBNewEntryWork)obj).AcptAnOdrStatus;
                    salesSlipNewEntryWork.SalesSlipNum = ((IOWriteMAHNBNewEntryWork)obj).SalesSlipNum;
                    paramArray.Add(salesSlipNewEntryWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    break;
                }
            }
            return status;
        }
#endif
        #endregion

        #region [Read] エントリ読込
        /// <summary>
        /// エントリ情報読込
        /// </summary>
        /// <param name="paraList">読込対象オブジェクトリスト</param>
        /// <param name="retList">読込結果オブジェクトリスト</param>
        /// <returns>STATUS</returns>
        public int Read(ref object paraList, out object retList)
        {
            //●STATUS初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retList = new CustomSerializeArrayList();
            SqlConnection sqlConnection = null;

            try
            {
                //●パラメータチェック
                CustomSerializeArrayList paramArray = paraList as CustomSerializeArrayList;
                if (paramArray == null || paramArray.Count <= 0)
                {
                    base.WriteErrorLog(null, "プログラムエラー。パラメータが未設定です");
                    return status;
                }

                //●Read用主軸パラメータ生成
                status = MakeReadFunctionParam(ref paramArray);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;

                //メソッド開始時にコネクション文字列を取得
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //●SQLコネクションオブジェクト作成
                using (sqlConnection = new SqlConnection(connectionText))
                {
                    //SqlEncryptInfo sqlEncryptInfo = null;
                    try
                    {
                        sqlConnection.Open();

                        //●暗号化キーOPEN
                        //sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, IOWriteMAHNBDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Read));
                        //sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                        //呼び出しパラメータ設定
                        object freeParam = null;//売上伝票Readでは自由パラメータは利用しない
                        CustomSerializeArrayList retArray = new CustomSerializeArrayList();

                        //●Read前オプションファンクション呼び出し
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.Read(_origin, _funcCallKey_BFR, ref paramArray, ref retArray, ref freeParam, ref sqlConnection);

                        //●IOWrite Read処理メイン
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = IOWriteMASIRFunctionProcRead(ref paramArray, ref retArray, ref freeParam, ref sqlConnection);

                        //●Read後オプションファンクション呼び出し
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.Read(_origin, _funcCallKey_AFT, ref paramArray, ref retArray, ref freeParam, ref sqlConnection);

                        //●戻り値を設定
                        paraList = (object)paramArray;
                        retList = (object)retArray;
                    }
                    finally
                    {
                        //●暗号化キーCLOSE
                        //if (sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);

                        //●コネクション破棄
                        if (sqlConnection != null) sqlConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "IOWriteMAHNBDB.Read Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            //STATUSを戻す
            return status;
        }

        /// <summary>
        /// エントリ情報読込(コネクションパラメータ付）
        /// </summary>
        /// <param name="paramArray">パラメータList</param>
        /// <param name="retArray">戻り値List</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        public int Read(ref CustomSerializeArrayList paramArray, out CustomSerializeArrayList retArray, ref SqlConnection sqlConnection)
        {
            //●STATUS初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retArray = null;

            try
            {
                //●パラメータチェック
                if (paramArray == null || paramArray.Count <= 0)
                {
                    base.WriteErrorLog(null, "プログラムエラー。パラメータが未設定です");
                    return status;
                }

                //●Read用主軸パラメータ生成
                status = MakeReadFunctionParam(ref paramArray);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;

                //呼び出しパラメータ設定
                object freeParam = null;//売上伝票Readでは自由パラメータは利用しない
                retArray = new CustomSerializeArrayList();

                //●Read前オプションファンクション呼び出し
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.Read(_origin, _funcCallKey_BFR, ref paramArray, ref retArray, ref freeParam, ref sqlConnection);

                //●IOWrite Read処理メイン
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = IOWriteMASIRFunctionProcRead(ref paramArray, ref retArray, ref freeParam, ref sqlConnection);

                //●Read後オプションファンクション呼び出し
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.Read(_origin, _funcCallKey_AFT, ref paramArray, ref retArray, ref freeParam, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "IOWriteMAHNBDB.Read(Connection付) Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            //STATUSを戻す
            return status;
        }

        /// <summary>
        /// IOWrite Read処理メイン
        /// </summary>
        /// <param name="paramArray">パラメータList</param>
        /// <param name="retArray">戻り値List</param>
        /// <param name="freeParam">ﾌﾘｰﾊﾟﾗﾒｰﾀ</param>
        /// <param name="sqlConnection">Sql接続情報</param>
        /// <returns>STATUS</returns>
        private Int32 IOWriteMASIRFunctionProcRead(ref CustomSerializeArrayList paramArray, ref CustomSerializeArrayList retArray, ref object freeParam, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // 売上Read関数を呼び出す
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                int salesSlipReadWork_Posi = MakePosition(paramArray, typeof(SalesSlipReadWork), 0);

                if (salesSlipReadWork_Posi > -1)
                {
                    SalesSlipReadWork salesSlipReadWork = paramArray[salesSlipReadWork_Posi] as SalesSlipReadWork;
                    status = this.SalesSlipDb.Read(_origin, ref paramArray, ref retArray, salesSlipReadWork_Posi, "", ref freeParam, ref sqlConnection);
                    paramArray.Remove(salesSlipReadWork);
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
            }

            //--- ADD 2008/06/06 M.Kubota --->>>
            // 受注マスタ(車両)の読込
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 売上明細データを取得する
                ArrayList salesDetailWorks = ListUtils.Find(retArray, typeof(SalesDetailWork), ListUtils.FindType.Array) as ArrayList;
                
                if (ListUtils.IsNotEmpty(salesDetailWorks))
                {
                    AcceptOdrCarReader AcptOdrCarReader = new AcceptOdrCarReader();
                    
                    SqlTransaction sqlTransaction = null;
                    ArrayList acpOdrCarWorks = null;

                    // 売上明細データに紐付く受注マスタ(車両)データを読み込む
                    status = AcptOdrCarReader.ReadWithSalesDetail(out acpOdrCarWorks, salesDetailWorks, sqlConnection, sqlTransaction);
                    
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        retArray.Add(acpOdrCarWorks);
                    }
                }
            }
            //--- ADD 2008/06/06 M.Kubota ---<<<

            // 入金Read関数を呼び出す
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                int salesSlip_Pos = MakePosition(retArray, typeof(SalesSlipWork), 0);
                
                if (salesSlip_Pos > -1)
                {
                    SalesSlipWork salesSlipWork = retArray[salesSlip_Pos] as SalesSlipWork;

                    // 読み込んだ売上データの自動入金区分が 1:自動入金 の場合にのみ、入金データを読み込む
                    if (salesSlipWork != null && salesSlipWork.AutoDepositCd == 1)
                    {
                        status = this.DepositDb.ReadFromSalesSlip(_origin, ref retArray, ref sqlConnection);
                    }
                }
            }

            // 在庫Read関数を呼び出す
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = this.StockUpdDb.Read(_origin, ref paramArray, ref retArray, 0, "", ref freeParam, ref sqlConnection);
            }

            // 2009/05/18 >>>>>>>>>>>>>>>>>>>>>>>>
            //SCM関連データRead関数を呼び出す
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                int salesSlip_Pos = MakePosition(retArray, typeof(SalesSlipWork), 0);
                
                if (salesSlip_Pos > -1)
                {
                    SalesSlipWork salesSlipWork = retArray[salesSlip_Pos] as SalesSlipWork;

                    //SCM関連データ読み込み用パラメータワーク
                    IOWriteSCMReadWork scmReadWork = new IOWriteSCMReadWork();
                    scmReadWork.EnterpriseCode = salesSlipWork.EnterpriseCode;
                    scmReadWork.AcptAnOdrStatus = salesSlipWork.AcptAnOdrStatus;
                    scmReadWork.SalesSlipNum = salesSlipWork.SalesSlipNum;

                    status = this.scmIOWriteDB.ScmRead(ref retArray, scmReadWork, ref sqlConnection);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        //SCM関連データが存在しない場合も正常とする。
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                }
            }
            // 2009/05/18 <<<<<<<<<<<<<<<<<<<<<<<<

            return status;
        }

        /// <summary>
        /// Read用主軸パラメータ生成
        /// </summary>
        /// <param name="paramArray">受け取りパラメータList</param>
        /// <returns>STATUS</returns>
        private int MakeReadFunctionParam(ref CustomSerializeArrayList paramArray)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //とりあえず売上ヘッダワークを売上伝票パラメータとして生成する
            //売上以外の処理が追加されたらRead用パラメータクラスを生成する
            foreach (object obj in paramArray)
            {
                IOWriteMAHNBReadWork readWork = obj as IOWriteMAHNBReadWork;

                if (readWork != null)
                {
                    //Readパラメータを生成
                    //Readパラメータは他処理の検索キー全てとする
                    SalesSlipReadWork salesSlipReadWork = new SalesSlipReadWork();

                    salesSlipReadWork.EnterpriseCode = readWork.EnterpriseCode;
                    salesSlipReadWork.AcptAnOdrStatus = readWork.AcptAnOdrStatus;
                    salesSlipReadWork.SalesSlipNum = readWork.SalesSlipNum;
                    salesSlipReadWork.DebitNoteDiv = readWork.DebitNoteDiv;
                    salesSlipReadWork.SalesSlipCd = readWork.SalesSlipCd;
                    salesSlipReadWork.SalesGoodsCd = readWork.SalesGoodsCd;
                    // --- ADD 2012/09/27 y.wakita ----->>>>>
                    salesSlipReadWork.LogicalDeleteCodeFlg = readWork.LogicalDeleteCodeFlg;
                    // --- ADD 2012/09/27 y.wakita -----<<<<<

                    paramArray.Add(salesSlipReadWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    break;
                }
            }

            return status;
        }

        #endregion

        #region [Write]　エントリ書込

        // 書込み処理専用 SqlConnection、SqlTransaction
        private SqlConnection sqlWriteConnection = null;
        private SqlTransaction sqlWriteTransaction = null;
        private SqlEncryptInfo sqlWriteEncryptInfo = null;
        
        private bool WriteCommitPossible = true;  // True:コミット可能　False:コミット不可能

        /// <summary>
        /// エントリ書込み (受注・売上同時登録用)
        /// </summary>
        /// <param name="orderList">受注用データ</param>
        /// <param name="salesList">売上用データ</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <returns>STATUS</returns>
        public int Write(ref object orderList, ref object salesList, out string retMsg, out string retItemInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = "";
            retItemInfo = "";

            //●コミット許可フラグに false:不許可 を設定
            this.WriteCommitPossible = false;

            //●SQLコネクションオブジェクト作成
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return status;

            sqlWriteConnection = new SqlConnection(connectionText);
            sqlWriteConnection.Open();

            //●暗号化キーOPEN
            sqlWriteEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, IOWriteMAHNBDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Write));
            sqlWriteEncryptInfo.OpenSymKey(ref sqlWriteConnection);

            //●トランザクションオブジェクト作成
            sqlWriteTransaction = sqlWriteConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);
            
            try
            {
                // 受注データを書き込む(この時点ではコミットは行われない)
                status = this.Write(ref orderList, out retMsg, out retItemInfo);

                // 受注データの書込みに成功した場合にのみ、売上データの書込みを行う
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    try
                    {
                        // 受注明細データを取得
                        CustomSerializeArrayList orderArrayList = orderList as CustomSerializeArrayList;
                        CustomSerializeArrayList salesArrayList = salesList as CustomSerializeArrayList;

                        int ordDtlPos = this.MakePosition(orderArrayList, typeof(SalesDetailWork), 1);
                        int sleDtlPos = this.MakePosition(salesArrayList, typeof(SalesDetailWork), 1);

                        ArrayList ordDtlList = (orderArrayList[ordDtlPos] as ArrayList);
                        ArrayList sleDtlList = (salesArrayList[sleDtlPos] as ArrayList);

                        for (int index = 0; index < sleDtlList.Count; index++)
                        {
                            SalesDetailWork ordDtlWrk = (ordDtlList[index] as SalesDetailWork);
                            SalesDetailWork sleDtlWrk = (sleDtlList[index] as SalesDetailWork);

                            if (ordDtlWrk != null && sleDtlWrk != null)
                            {
                                sleDtlWrk.AcptAnOdrStatusSrc = ordDtlWrk.AcptAnOdrStatus;  // 計上元の受注ステータスを設定
                                sleDtlWrk.CommonSeqNo = ordDtlWrk.CommonSeqNo;             // 共通通番を設定
                                sleDtlWrk.SalesSlipDtlNumSrc = ordDtlWrk.SalesSlipDtlNum;  // 計上元の売上明細通番を設定
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        base.WriteErrorLog(ex, "");
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        return status;
                    }

                    // 売上データを書き込む(この時点ではコミットは行われない)
                    status = this.Write(ref salesList, out retMsg, out retItemInfo);
                }
            }
            finally
            {
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    sqlWriteTransaction.Commit();
                }
                else
                {
                    sqlWriteTransaction.Rollback();
                }

                sqlWriteTransaction.Dispose();
                sqlWriteTransaction = null;

                if (sqlWriteEncryptInfo.IsOpen)
                {
                    sqlWriteEncryptInfo.CloseSymKey(ref sqlWriteConnection);
                    sqlWriteEncryptInfo = null;
                }

                sqlWriteConnection.Close();
                sqlWriteConnection.Dispose();
                sqlWriteConnection = null;

                this.WriteCommitPossible = true;  // 誤動作を防ぐ目的で再設定する
            }

            return status;
        }

        /// <summary>
        /// エントリ情報書き込み
        /// </summary>
        /// <param name="paraList">書き込み対象オブジェクトリスト</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <returns>STATUS</returns>
        public int Write(ref object paraList, out string retMsg, out string retItemInfo)
        {
            //●STATUS初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = "";
            retItemInfo = "";
            CustomSerializeArrayList paramArray_BackUp = null;

            //売上伝票パラメータファイル
            SalesSlipWork excSalesSlipWork = null;
            
            ControlExclusiveOrderAccess ctrlExclsvOdAcs = null;

            CustomSerializeArrayList originArray = new CustomSerializeArrayList();

            try
            {
                //●パラメータチェック
                CustomSerializeArrayList paramArray = paraList as CustomSerializeArrayList;
                if (paramArray == null || paramArray.Count <= 0)
                {
                    base.WriteErrorLog(null, "プログラムエラー。パラメータが未設定です");
                    return status;
                }

                //●パラメータバックアップ
                paramArray_BackUp = new CustomSerializeArrayList();
                paramArray_BackUp.AddRange(paramArray);

                //●排他Lock
                ctrlExclsvOdAcs = new ControlExclusiveOrderAccess();
                excSalesSlipWork = MakeParameter(paramArray, typeof(SalesSlipWork), 0) as SalesSlipWork;

                if (excSalesSlipWork != null)
                {
                    status = ControlExclusiveProc(0, ref ctrlExclsvOdAcs, ref excSalesSlipWork, ref retMsg);
                }
                else
                {
                    // 売上データがNULLの場合は排他ロックを行わない。
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //メソッド開始時にコネクション文字列を取得

                    //●SQLコネクションオブジェクト作成
                    if (sqlWriteConnection == null)
                    {
                        SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                        string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                        if (connectionText == null || connectionText == "") return status;
                        sqlWriteConnection = new SqlConnection(connectionText);
                        sqlWriteConnection.Open();
                    }

                    //●暗号化キーOPEN
                    if (sqlWriteEncryptInfo == null)
                    {
                        sqlWriteEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, IOWriteMAHNBDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Write));
                        sqlWriteEncryptInfo.OpenSymKey(ref sqlWriteConnection);
                    }

                    //●トランザクション開始
                    if (sqlWriteTransaction == null)
                    {
                        sqlWriteTransaction = sqlWriteConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);
                    }

                    try
                    {
                        try
                        {
                            //●更新準備ファンクション呼び出し
                            object freeParam = null;//売上伝票更新では自由パラメータは利用しない

                            #region 書き込み準備
                            //●WriteInitial前オプションファンクション呼び出し
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.WriteInitial(_origin, _funcCallKey_BFR, ref originArray, ref paramArray, ref freeParam, out retMsg, out retItemInfo, ref sqlWriteConnection, ref sqlWriteTransaction, ref sqlWriteEncryptInfo);

                            //●IOWrite WriteInitial処理メイン
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = IOWriteMAHNBFunctionProcWriteInitial(ref originArray, ref paramArray, ref freeParam, out retMsg, out retItemInfo, ref sqlWriteConnection, ref sqlWriteTransaction, ref sqlWriteEncryptInfo);

                            //●WriteInitial後オプションファンクション呼び出し
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.WriteInitial(_origin, _funcCallKey_AFT, ref originArray, ref paramArray, ref freeParam, out retMsg, out retItemInfo, ref sqlWriteConnection, ref sqlWriteTransaction, ref sqlWriteEncryptInfo);
                            #endregion

                            #region Initial処理が上手くいったら実Write
                            //●Write前オプションファンクション呼び出し
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.Write(_origin, _funcCallKey_BFR, ref originArray, ref paramArray, ref freeParam, out retMsg, out retItemInfo, ref sqlWriteConnection, ref sqlWriteTransaction, ref sqlWriteEncryptInfo);

                            //●IOWrite Write処理メイン
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = IOWriteMAHNBFunctionProcWrite(ref originArray, ref paramArray, ref freeParam, out retMsg, out retItemInfo, ref sqlWriteConnection, ref sqlWriteTransaction, ref sqlWriteEncryptInfo);

                            //●Write後オプションファンクション呼び出し
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.Write(_origin, _funcCallKey_AFT, ref originArray, ref paramArray, ref freeParam, out retMsg, out retItemInfo, ref sqlWriteConnection, ref sqlWriteTransaction, ref sqlWriteEncryptInfo);
                            #endregion

                            //●戻り値を設定
                            paraList = (object)paramArray;
                        }
                        //●例外処理
                        catch (SqlException ex)
                        {
                            status = base.WriteSQLErrorLog(ex);
                        }
                        catch (Exception ex)
                        {
                            base.WriteErrorLog(ex, "IOWriteMAHNBDB.Write Exception=" + ex.Message);
                            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        }
                        finally
                        {
                            //●コミットorロールバック
                            //正常更新時コミット、異常発生時ロールバック
                            if (WriteCommitPossible)
                            {
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    sqlWriteTransaction.Commit();
                                }
                                else
                                {
                                    sqlWriteTransaction.Rollback();
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (WriteCommitPossible)
                        {
                            //●トランザクション破棄
                            if (sqlWriteTransaction != null)
                            {
                                sqlWriteTransaction.Dispose();
                                sqlWriteTransaction = null;
                            }

                            //●暗号化キーCLOSE
                            if (sqlWriteEncryptInfo.IsOpen)
                            {
                                sqlWriteEncryptInfo.CloseSymKey(ref sqlWriteConnection);
                            }
                            
                            //●コネクション破棄
                            if (sqlWriteConnection != null)
                            {
                                sqlWriteConnection.Close();
                                sqlWriteConnection.Dispose();
                                sqlWriteConnection = null;
                            }
                        }
                    }

                }
            }
            //●例外処理
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "IOWriteMAHNBDB.Write Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (excSalesSlipWork != null)
                {
                    //●排他Lock破棄
                    ControlExclusiveProc(1, ref ctrlExclsvOdAcs, ref excSalesSlipWork, ref retMsg);
                }

                //正常終了時以外はバックアップパラメータを戻す
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && paramArray_BackUp != null)
                    paraList = paramArray_BackUp;
                //データ無しの場合はステータスを警告ステータスに変更する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND ||
                    status == (int)ConstantManagement.DB_Status.ctDB_EOF) status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
            }

            //STATUSを戻す
            return status;
        }

        /// <summary>
        /// エントリ情報書き込み(コネクションパラメータ付）
        /// </summary>
        /// <param name="paramArray">書き込み対象オブジェクトリスト</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        public int Write(ref CustomSerializeArrayList paramArray, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            //●STATUS初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retMsg = "";
            retItemInfo = "";
            CustomSerializeArrayList paramArray_BackUp = null;

            //売上伝票パラメータファイル
            //SalesSlipWork excSalesSlipWork = null;
            // Del 2007.04.06 Saitoh >>>>>>>>>>　※売上更新リモーティングから呼び出されるため
            //ControlExclusiveOrderAccess ctrlExclsvOdAcs = null;
            // Del 2007.04.06 Saitoh <<<<<<<<<<

            CustomSerializeArrayList originArray = new CustomSerializeArrayList();

            try
            {
                //●パラメータチェック
                if (paramArray == null || paramArray.Count <= 0)
                {
                    base.WriteErrorLog(null, "プログラムエラー。パラメータが未設定です");
                    return status;
                }

                //●パラメータバックアップ
                paramArray_BackUp = new CustomSerializeArrayList();
                paramArray_BackUp.AddRange(paramArray);

                // Del 2007.04.06 Saitoh >>>>>>>>>>　※売上更新リモーティングから呼び出されるため
                //●排他Lock
                //ctrlExclsvOdAcs = new ControlExclusiveOrderAccess();
                //excSalesSlipWork = MakeParameter(paramArray, typeof(SalesSlipWork), 0) as SalesSlipWork;
                //status = ControlExclusiveProc(0, ref ctrlExclsvOdAcs, ref excSalesSlipWork, ref retMsg);
                // Del 2007.04.06 Saitoh <<<<<<<<<<

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //●更新準備ファンクション呼び出し
                    object freeParam = null;//売上伝票更新では自由パラメータは利用しない

                    #region 書き込み準備
                    //●WriteInitial前オプションファンクション呼び出し
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.WriteInitial(_origin, _funcCallKey_BFR, ref originArray, ref paramArray, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                    //●IOWrite WriteInitial処理メイン
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = IOWriteMAHNBFunctionProcWriteInitial(ref originArray, ref paramArray, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                    //●WriteInitial後オプションファンクション呼び出し
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.WriteInitial(_origin, _funcCallKey_AFT, ref originArray, ref paramArray, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                    #endregion

                    #region Initial処理が上手くいったら実Write
                    //●Write前オプションファンクション呼び出し
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.Write(_origin, _funcCallKey_BFR, ref originArray, ref paramArray, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                    //●IOWrite Write処理メイン
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = IOWriteMAHNBFunctionProcWrite(ref originArray, ref paramArray, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                    //●Write後オプションファンクション呼び出し
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.Write(_origin, _funcCallKey_AFT, ref originArray, ref paramArray, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                    #endregion
                }
            }

                //●例外処理
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "IOWriteMAHNBDB.Write(Connection付) Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // Del 2007.04.06 Saitoh >>>>>>>>>>　※売上更新リモーティングから呼び出されるため
                //●排他Lock破棄
                //ControlExclusiveProc(1, ref ctrlExclsvOdAcs, ref excSalesSlipWork, ref retMsg);
                // Del 2007.04.06 Saitoh <<<<<<<<<<

                //正常終了時以外はバックアップパラメータを戻す
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && paramArray_BackUp != null) paramArray = paramArray_BackUp;
                //データ無しの場合はステータスを警告ステータスに変更する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND ||
                    status == (int)ConstantManagement.DB_Status.ctDB_EOF) status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
            }

            //STATUSを戻す
            return status;

        }

        # region [IOWriteControlDB から呼び出される登録メソッド]
        /// <summary>
        /// 売上データ登録準備処理
        /// </summary>
        /// <param name="orgslips">登録対象の元売上データ及び売上明細データを格納するArrayList</param>
        /// <param name="newslips">登録対象の売上データ及び売上明細データを格納するArrayList</param>
        /// <param name="retMsg">メッセージ(主にエラーメッセージ)</param>
        /// <param name="retItemInfo">項目情報(未使用)</param>
        /// <param name="connection">データベース接続オブジェクト</param>
        /// <param name="transaction">トランザクションオブジェクト</param>
        /// <param name="encryptinfo">暗号化キーオブジェクト</param>
        /// <returns>ステータス</returns>
        public int WriteInitialize(out ArrayList orgslips, ref ArrayList newslips, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;
            orgslips = new ArrayList();

            #region [パラメータチェック処理]

            //●パラメータチェック
            if (newslips == null || newslips.Count <= 0)
            {
                retMsg = "IOWriteMAHNBDB.WriteInitialize: 登録対象の売上データが設定されていません。";
                base.WriteErrorLog(retMsg);
                return status;
            }

            //●データベース接続状況チェック
            if (connection == null)
            {
                retMsg = "IOWriteMAHNBDB.WriteInitialize: データベース接続情報が設定されていません。";
                base.WriteErrorLog(retMsg);
                return status;
            }

            if ((connection.State & ConnectionState.Open) == 0)
            {
                connection.Open();
            }

            //●暗号化キーのチェック
            //if (encryptinfo == null)
            //{
            //    retMsg = "IOWriteMAHNBDB.WriteInitialize: 暗号化キー情報が設定されていません。";
            //    base.WriteErrorLog(retMsg);
            //    return status;
            //}

            //●トランザクションのチェック
            if (transaction == null)
            {
                retMsg = "IOWriteMAHNBDB.WriteInitialize: トランザクション情報が設定されていません。";
                base.WriteErrorLog(retMsg);
                return status;
            }

            # endregion

            try
            {
                CustomSerializeArrayList cstSlips = new CustomSerializeArrayList();
                cstSlips.AddRange(newslips);
                
                CustomSerializeArrayList orgSlips = new CustomSerializeArrayList();

                object freeparam = null;
                
                //●WriteInitial前オプションファンクション呼び出し
                status = _functionCallControl.WriteInitial(_origin, _funcCallKey_BFR, ref orgSlips, ref cstSlips, ref freeparam, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

                //●IOWrite WriteInitial処理メイン
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = IOWriteMAHNBFunctionProcWriteInitial(ref orgSlips, ref cstSlips, ref freeparam, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

                //●WriteInitial後オプションファンクション呼び出し
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.WriteInitial(_origin, _funcCallKey_AFT, ref orgSlips, ref cstSlips, ref freeparam, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

                // 登録準備処理の結果を呼び出し元に返す
                newslips.Clear();
                newslips.AddRange(cstSlips);

                orgslips.AddRange(orgSlips);
            }
            catch (SqlException sqlEx)
            {
                retMsg = sqlEx.Message;
                status = base.WriteSQLErrorLog(sqlEx);
            }

            return status;
        }

        /// <summary>
        /// 売上データ登録処理
        /// </summary>
        /// <param name="orgslips">登録対象の元売上データ及び売上明細データを格納するArrayList</param>
        /// <param name="newslips">登録対象の売上データ及び売上明細データを格納するArrayList</param>
        /// <param name="retMsg">メッセージ(主にエラーメッセージ)</param>
        /// <param name="retItemInfo">項目情報(未使用)</param>
        /// <param name="connection">データベース接続オブジェクト</param>
        /// <param name="transaction">トランザクションオブジェクト</param>
        /// <param name="encryptinfo">暗号化キーオブジェクト</param>
        /// <returns>ステータス</returns>
        public int WriteA(ArrayList orgslips, ref ArrayList newslips, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            #region [パラメータチェック処理]

            //●パラメータチェック
            if (newslips == null || newslips.Count <= 0)
            {
                retMsg = "IOWriteMAHNBDB.Write: 登録対象の売上データが設定されていません。";
                base.WriteErrorLog(retMsg);
                return status;
            }

            //●データベース接続状況チェック
            if (connection == null)
            {
                retMsg = "IOWriteMAHNBDB.Write: データベース接続情報が設定されていません。";
                base.WriteErrorLog(retMsg);
                return status;
            }

            if ((connection.State & ConnectionState.Open) == 0)
            {
                connection.Open();
            }

            //●暗号化キーのチェック
            //if (encryptinfo == null)
            //{
            //    retMsg = "IOWriteMAHNBDB.Write: 暗号化キー情報が設定されていません。";
            //    base.WriteErrorLog(retMsg);
            //    return status;
            //}

            //●トランザクションのチェック
            if (transaction == null)
            {
                retMsg = "IOWriteMAHNBDB.Write: トランザクション情報が設定されていません。";
                base.WriteErrorLog(retMsg);
                return status;
            }

            # endregion

            try
            {
                CustomSerializeArrayList cstSlips = new CustomSerializeArrayList();
                cstSlips.AddRange(newslips);

                CustomSerializeArrayList orgSlips = new CustomSerializeArrayList();
                orgSlips.AddRange(orgslips);

                object freeparam = null;

                //●Write前オプションファンクション呼び出し
                status = _functionCallControl.Write(_origin, _funcCallKey_BFR, ref orgSlips, ref cstSlips, ref freeparam, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

                //●IOWrite Write処理メイン
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = IOWriteMAHNBFunctionProcWrite(ref orgSlips, ref cstSlips, ref freeparam, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

                //●Write後オプションファンクション呼び出し
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.Write(_origin, _funcCallKey_AFT, ref orgSlips, ref cstSlips, ref freeparam, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

                // -- ADD 2012/01/20 ----------------------------->>>
                IOWriteMAHNBDepositDB.DepositInfo depositInfo = ListUtils.Find(cstSlips, typeof(IOWriteMAHNBDepositDB.DepositInfo), ListUtils.FindType.Class) as IOWriteMAHNBDepositDB.DepositInfo;
                if (depositInfo != null)
                {
                    cstSlips.Remove(depositInfo);
                }
                // -- ADD 2012/01/20 -----------------------------<<<

                // 登録準備処理の結果を呼び出し元に返す
                newslips.Clear();
                newslips.AddRange(cstSlips);
            }
            catch (SqlException sqlEx)
            {
                retMsg = sqlEx.Message;
                status = base.WriteSQLErrorLog(sqlEx);
            }

            return status;
        }
        #endregion

        /// <summary>
        /// IOWrite WriteInitial処理メイン
        /// </summary>
        /// <param name="originArray">旧パラメータList</param>
        /// <param name="paramArray">パラメータList</param>
        /// <param name="freeParam">ﾌﾘｰﾊﾟﾗﾒｰﾀ</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">Sql接続情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <br>Update Note: 2009/09/16       汪千来</br>
        ///	<br>		   : 車輌備考を追加する</br>
        /// <br>Update Note: SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
        /// <br>Programmer : FSI厚川 宏</br>
        /// <br>Date       : 2013/03/21</br>
        /// <returns>STATUS</returns>
        private Int32 IOWriteMAHNBFunctionProcWriteInitial(ref CustomSerializeArrayList originArray, ref CustomSerializeArrayList paramArray, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = "";
            retItemInfo = "";

            int salesSlipWork_Posi = MakePosition(paramArray, typeof(SalesSlipWork), 0);

            // 売上入力のWriteInitial関数を呼び出す
            if (salesSlipWork_Posi > -1)
            {
                SalesSlipWork salesSlipWork = paramArray[salesSlipWork_Posi] as SalesSlipWork;
                status = this.SalesSlipDb.WriteInitial(_origin, ref originArray, ref paramArray, salesSlipWork_Posi, ""/*構成ﾌｧｲﾙﾊﾟﾗﾒｰﾀ無し*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                // 入金マスタWriteInitial関数を呼び出す(入金マスタ/入金引当マスタ)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && salesSlipWork.AutoDepositCd == 1)
                {
                    int depositWork_Posi = MakePosition(paramArray, typeof(DepsitDataWork), 0);

                    if (depositWork_Posi > -1)
                    {
                        status = this.DepositDb.WriteInitial(_origin, ref originArray, ref paramArray, depositWork_Posi, "", ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // 採番された入金伝票番号を自動入金伝票番号に設定する
                            salesSlipWork.AutoDepositSlipNo = (paramArray[depositWork_Posi] as DepsitDataWork).DepositSlipNo;
                        }
                    }
                }

                // 売上履歴のWriteInitial関数を呼び出す (受注ステータスが30:売上の場合のみ)
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                //    (paramArray[salesSlipWork_Posi] as SalesSlipWork).AcptAnOdrStatus == 30)
                //{
                //    ArrayList workArray = (paramArray as ArrayList);
                //    status = this.SalesSlipHistDb.WriteInitialize(ref workArray, ref sqlConnection, ref sqlTransaction);
                //}

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    # region [車両管理マスタデータの書込準備処理]

                    //○車両管理データを含む配列を分離 → 受注マスタ(車両)の元データとなる為、この時点で取得しておく
                    ArrayList carManagementList = ListUtils.Find(paramArray, typeof(CarManagementWork), ListUtils.FindType.Array) as ArrayList;

                    // 車両管理データのソート・検索をする際に使用する IComparer クラス
                    CarManagementComparer carMngComp = new CarManagementComparer();

                    if (ListUtils.IsNotEmpty(carManagementList))
                    {
                        carManagementList.Sort(carMngComp);

                        if (this.IOWriteCtrlOptWork.CarMngDivCd == 1)
                        {
                            //●車両管理リモートの登録準備処理(車両管理番号(SEQ)を取得)を実行する
                            status = this.carMgrDB.WriteInitial(ref carManagementList, sqlConnection, sqlTransaction);

                        }
                    }

                    # endregion

                    # region [受注マスタ(車両)データの作成]
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 売上明細データを取得
                        ArrayList salesDtlList = ListUtils.Find(paramArray, typeof(SalesDetailWork), ListUtils.FindType.Array) as ArrayList;

                        // 伝票明細追加情報データを含む配列を分離
                        ArrayList slipDtlAddInfList = ListUtils.Find(paramArray, typeof(SlipDetailAddInfoWork), ListUtils.FindType.Array) as ArrayList;

                        if (ListUtils.IsNotEmpty(salesDtlList) && ListUtils.IsNotEmpty(slipDtlAddInfList))
                        {
                            // 伝票明細追加情報データを明細関連付けGUIDで並び替える
                            SlipDetailAddInfoWork SlipDtlAddInfComp = new SlipDetailAddInfoWork();

                            SlipDetailAddInfoDtlRelationGuidComparer DtlRelationGuidComp = new SlipDetailAddInfoDtlRelationGuidComparer();
                            slipDtlAddInfList.Sort(DtlRelationGuidComp);

                            // 受注マスタ(車両)データを含む配列をリモートにて追加
                            ArrayList acpOdrCarList = new ArrayList();
                            AcceptOdrCarComparer acptOdrCarComp = new AcceptOdrCarComparer();

                            foreach (SalesDetailWork salesdtl in salesDtlList)
                            {
                                // 受注マスタ(車両)データを作成する
                                // 明細に紐付く伝票明細追加情報を取得
                                int idx = slipDtlAddInfList.BinarySearch(salesdtl.DtlRelationGuid, DtlRelationGuidComp);

                                if (idx > -1)
                                {
                                    SlipDetailAddInfoWork slipDtlAddInf = slipDtlAddInfList[idx] as SlipDetailAddInfoWork;

                                    if (slipDtlAddInf != null)
                                    {
                                        // 伝票明細追加情報に紐付く車両管理データを取得
                                        CarManagementWork carMng = null;

                                        if (ListUtils.IsNotEmpty(carManagementList))
                                        {
                                            idx = carManagementList.BinarySearch(slipDtlAddInf.CarRelationGuid, carMngComp);

                                            if (idx > -1)
                                            {
                                                carMng = carManagementList[idx] as CarManagementWork;
                                            }
                                        }

                                        // 受注マスタ(車両)データを作成
                                        AcceptOdrCarWork acpOdrCar = new AcceptOdrCarWork();

                                        # region [受注マスタ(車両) ← 売上明細＋車両管理]
                                        acpOdrCar.EnterpriseCode = salesdtl.EnterpriseCode;          // 企業コード
                                        acpOdrCar.LogicalDeleteCode = (int)ConstantManagement.LogicalMode.GetData0;  // 論理削除区分
                                        acpOdrCar.AcceptAnOrderNo = salesdtl.AcceptAnOrderNo;        // 受注番号

                                        // 受注ステータス (売上の受注ステータスと受注マスタ(車両)のそれは内容が異なる為)
                                        switch (salesdtl.AcptAnOdrStatus)
                                        {
                                            case 10:  // 見積
                                                {
                                                    acpOdrCar.AcptAnOdrStatus = 1;
                                                    break;
                                                }
                                            case 20:  // 受注
                                                {
                                                    acpOdrCar.AcptAnOdrStatus = 3;
                                                    break;
                                                }
                                            case 30:  // 売上
                                                {
                                                    acpOdrCar.AcptAnOdrStatus = 7;
                                                    break;
                                                }
                                            case 40:  // 出荷
                                                {
                                                    acpOdrCar.AcptAnOdrStatus = 5;
                                                    break;
                                                }
                                        }

                                        acpOdrCar.DataInputSystem = (int)DataInputSystem.PM;             // データ入力システム

                                        if (carMng != null)
                                        {
                                            acpOdrCar.CarMngNo = carMng.CarMngNo;                        // 車両管理番号
                                            acpOdrCar.CarMngCode = carMng.CarMngCode;                    // 車輌管理コード
                                            acpOdrCar.NumberPlate1Code = carMng.NumberPlate1Code;        // 陸運事務所番号
                                            acpOdrCar.NumberPlate1Name = carMng.NumberPlate1Name;        // 陸運事務局名称
                                            acpOdrCar.NumberPlate2 = carMng.NumberPlate2;                // 車両登録番号（種別）
                                            acpOdrCar.NumberPlate3 = carMng.NumberPlate3;                // 車両登録番号（カナ）
                                            acpOdrCar.NumberPlate4 = carMng.NumberPlate4;                // 車両登録番号（プレート番号）
                                            acpOdrCar.FirstEntryDate = carMng.FirstEntryDate;            // 初年度
                                            acpOdrCar.MakerCode = carMng.MakerCode;                      // メーカーコード
                                            acpOdrCar.MakerFullName = carMng.MakerFullName;              // メーカー全角名称
                                            acpOdrCar.MakerHalfName = carMng.MakerHalfName;              // メーカー半角名称
                                            acpOdrCar.ModelCode = carMng.ModelCode;                      // 車種コード
                                            acpOdrCar.ModelSubCode = carMng.ModelSubCode;                // 車種サブコード
                                            acpOdrCar.ModelFullName = carMng.ModelFullName;              // 車種全角名称
                                            acpOdrCar.ModelHalfName = carMng.ModelHalfName;              // 車種半角名称
                                            acpOdrCar.ExhaustGasSign = carMng.ExhaustGasSign;            // 排ガス記号
                                            acpOdrCar.SeriesModel = carMng.SeriesModel;                  // シリーズ型式
                                            acpOdrCar.CategorySignModel = carMng.CategorySignModel;      // 型式（類別記号）
                                            acpOdrCar.FullModel = carMng.FullModel;                      // 型式（フル型）
                                            acpOdrCar.ModelDesignationNo = carMng.ModelDesignationNo;    // 型式指定番号
                                            acpOdrCar.CategoryNo = carMng.CategoryNo;                    // 類別番号
                                            acpOdrCar.FrameModel = carMng.FrameModel;                    // 車台型式
                                            acpOdrCar.FrameNo = carMng.FrameNo;                          // 車台番号
                                            acpOdrCar.SearchFrameNo = carMng.SearchFrameNo;              // 車台番号（検索用）
                                            acpOdrCar.EngineModelNm = carMng.EngineModelNm;              // エンジン型式名称
                                            acpOdrCar.RelevanceModel = carMng.RelevanceModel;            // 関連型式
                                            acpOdrCar.SubCarNmCd = carMng.SubCarNmCd;                    // サブ車名コード
                                            acpOdrCar.ModelGradeSname = carMng.ModelGradeSname;          // 型式グレード略称
                                            acpOdrCar.ColorCode = carMng.ColorCode;                      // カラーコード
                                            acpOdrCar.ColorName1 = carMng.ColorName1;                    // カラー名称1
                                            acpOdrCar.TrimCode = carMng.TrimCode;                        // トリムコード
                                            acpOdrCar.TrimName = carMng.TrimName;                        // トリム名称
                                            acpOdrCar.Mileage = carMng.Mileage;                          // 車両走行距離
                                            acpOdrCar.FullModelFixedNoAry = carMng.FullModelFixedNoAry;  // フル型式固定番号配列
                                            acpOdrCar.CategoryObjAry = carMng.CategoryObjAry;            // 装備オブジェクト配列
                                            // --- ADD 2009/09/16 ---------->>>>>
                                            acpOdrCar.CarNote = carMng.CarNote;            // 車輌備考
                                            // --- ADD 2009/09/16 ----------<<<<<
                                            acpOdrCar.FreeSrchMdlFxdNoAry = carMng.FreeSrchMdlFxdNoAry; // 自由検索型式固定番号配列 // ADD 2010/04/27
                                            // --- ADD 2013/03/21 ---------->>>>>
                                            acpOdrCar.DomesticForeignCode = carMng.DomesticForeignCode; // 国産/外車区分
                                            // --- ADD 2013/03/21 ----------<<<<<

                                        }
                                        # endregion

                                        acpOdrCarList.Sort(acptOdrCarComp);
                                        idx = acpOdrCarList.BinarySearch(acpOdrCar, acptOdrCarComp);

                                        if (idx < 0)
                                        {
                                            acpOdrCarList.Add(acpOdrCar);
                                        }
                                    }
                                }
                            }

                            // 受注マスタ(車両)データが存在している場合にのみパラメータリストに追加する
                            if (ListUtils.IsNotEmpty(acpOdrCarList))
                            {
                                paramArray.Add(acpOdrCarList);
                            }
                        }
                    }
                    # endregion
                }

                //--- ADD 2008/06/06 M.Kubota ---<<<

                // 在庫マスタWriteInitial関数を呼び出す(受注ステータスが 10:見積 以外の場合に在庫マスタ/在庫受払履歴データを更新)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                    (paramArray[salesSlipWork_Posi] as SalesSlipWork).AcptAnOdrStatus != 10)
                {
                    status = this.StockUpdDb.WriteInitial(_origin, ref originArray, ref paramArray, salesSlipWork_Posi, "", ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                }

                // 2009/05/18 >>>>>>>>>>>>>>>>>>>
                // 採番された売上伝票番号をＳＣＭ関連データへ設定
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
#region test

                    //SCMAcOdrDataWork work1 = new SCMAcOdrDataWork();
                    //work1.EnterpriseCode = salesSlipWork.EnterpriseCode;
                    //work1.InqOriginalEpCd = "1234567890123456";
                    //work1.InqOriginalEpNm = "相手企業名称";
                    //work1.InqOriginalSecCd = "000006";
                    //work1.InqOriginalSecNm = "相手拠点名称";
                    //work1.InqOtherEpCd = salesSlipWork.EnterpriseCode;
                    //work1.InqOtherSecCd = "テスト拠点";
                    //work1.InquiryNumber = 12345678;
                    //work1.CustomerCode = 111;
                    //work1.AcptAnOdrStatus = 30;

                    //paramArray.Add(work1);

                    //SCMAcOdrDtCarWork work2 = new SCMAcOdrDtCarWork();
                    //work2.EnterpriseCode = salesSlipWork.EnterpriseCode;
                    //work2.InqOriginalEpCd = "1234567890123456";
                    //work2.InqOriginalSecCd = "000006";
                    //work2.InquiryNumber = 12345678;
                    //work2.NumberPlate1Code = 1234;

                    //paramArray.Add(work2);

                    //ArrayList list1 = new ArrayList();

                    //SCMAcOdrDtlIqWork work3 = new SCMAcOdrDtlIqWork();
                    //work3.EnterpriseCode = salesSlipWork.EnterpriseCode;
                    //work3.InqOriginalEpCd = "1234567890123456";
                    //work3.InqOriginalSecCd = "000006";
                    //work3.InquiryNumber = 12345678;
                    //work3.InqRowNumber = 1;
                    //work3.InqRowNumDerivedNo = 1;
                    //work3.AcptAnOdrStatus = 30;

                    //list1.Add(work3);

                    //work3 = new SCMAcOdrDtlIqWork();
                    //work3.EnterpriseCode = salesSlipWork.EnterpriseCode;
                    //work3.InqOriginalEpCd = "1234567890123456";
                    //work3.InqOriginalSecCd = "000006";
                    //work3.InquiryNumber = 12345678;
                    //work3.InqRowNumber = 2;
                    //work3.InqRowNumDerivedNo = 1;
                    //work3.AcptAnOdrStatus = 30;

                    //list1.Add(work3);

                    //paramArray.Add(list1);

                    //ArrayList list2 = new ArrayList();

                    //SCMAcOdrDtlAsWork work4 = new SCMAcOdrDtlAsWork();
                    //work4.EnterpriseCode = salesSlipWork.EnterpriseCode;
                    //work4.InqOriginalEpCd = "1234567890123456";
                    //work4.InqOriginalSecCd = "000006";
                    //work4.InquiryNumber = 12345678;
                    //work4.InqRowNumber = 1;
                    //work4.InqRowNumDerivedNo = 1;
                    //work4.AcptAnOdrStatus = 30;

                    //list2.Add(work4);

                    //work4 = new SCMAcOdrDtlAsWork();
                    //work4.EnterpriseCode = salesSlipWork.EnterpriseCode;
                    //work4.InqOriginalEpCd = "1234567890123456";
                    //work4.InqOriginalSecCd = "000006";
                    //work4.InquiryNumber = 12345678;
                    //work4.InqRowNumber = 2;
                    //work4.InqRowNumDerivedNo = 1;
                    //work4.AcptAnOdrStatus = 30;

                    //list2.Add(work4);

                    //paramArray.Add(list2);

#endregion

                    //SCM受注データ
                    SCMAcOdrDataWork scmAcOdrDataWork = ListUtils.Find(paramArray, typeof(SCMAcOdrDataWork), ListUtils.FindType.Class) as SCMAcOdrDataWork;

                    if (scmAcOdrDataWork != null)
                    {
                        scmAcOdrDataWork.SalesSlipNum = salesSlipWork.SalesSlipNum;
                    }

                    //SCM受注データ(車両)
                    SCMAcOdrDtCarWork scmAcOdrDtCarWork = ListUtils.Find(paramArray, typeof(SCMAcOdrDtCarWork), ListUtils.FindType.Class) as SCMAcOdrDtCarWork;

                    if (scmAcOdrDtCarWork != null)
                    {
                        scmAcOdrDtCarWork.SalesSlipNum = salesSlipWork.SalesSlipNum;
                    }

                    //SCM受注明細データ(回答)
                    ArrayList scmAcOdrDtlAsList = ListUtils.Find(paramArray, typeof(SCMAcOdrDtlAsWork), ListUtils.FindType.Array) as ArrayList;

                    if (scmAcOdrDtlAsList != null)
                    {
                        foreach (SCMAcOdrDtlAsWork scmAcOdrDtlAsWork in scmAcOdrDtlAsList)
                        {
                            scmAcOdrDtlAsWork.SalesSlipNum = salesSlipWork.SalesSlipNum;
                        }
                    }
                    // ----- ADD 2011/08/10 ----- >>>>>
                    //SCM受注セットデータ
                    ArrayList scmAcSetList = ListUtils.Find(paramArray, typeof(SCMAcOdSetDtWork), ListUtils.FindType.Array) as ArrayList;

                    if (scmAcSetList != null)
                    {
                        foreach (SCMAcOdSetDtWork scmAcSetWork in scmAcSetList)
                        {
                            // 親は回答と同じで設定
                            if (scmAcSetWork.SetPartsMainSubNo == 0)
                            {
                                scmAcSetWork.PMSalesSlipNum = int.Parse(salesSlipWork.SalesSlipNum);
                            }
                            else
                            {
                                scmAcSetWork.PMSalesSlipNum = 0;
                                scmAcSetWork.PMSalesRowNo = 0;
                            }
                        }
                    }
                    // ----- ADD 2011/08/10 ----- <<<<<
                }
                // 2009/05/18 <<<<<<<<<<<<<<<<<<<
            }
            return status;
        }

        /// <summary>
        /// IOWrite Write処理メイン
        /// </summary>
        /// <param name="originArray">旧パラメータList</param>
        /// <param name="paramArray">パラメータList</param>
        /// <param name="freeParam">ﾌﾘｰﾊﾟﾗﾒｰﾀ</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">Sql接続情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        private Int32 IOWriteMAHNBFunctionProcWrite(ref CustomSerializeArrayList originArray, ref CustomSerializeArrayList paramArray, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = "";
            retItemInfo = "";

            // パラメータインデックスの取得
            int salesSlipWork_Posi = MakePosition(paramArray, typeof(SalesSlipWork), 0);

            if (salesSlipWork_Posi > -1)
            {
                SalesSlipWork wrkSalesSlipWork = paramArray[salesSlipWork_Posi] as SalesSlipWork;

                //①売上データWrite関数を呼び出す
                status = this.SalesSlipDb.Write(_origin, ref originArray, ref paramArray, salesSlipWork_Posi, ""/*構成ﾌｧｲﾙﾊﾟﾗﾒｰﾀ無し*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                //--- ADD 2008/06/06 M.Kubota --->>>

                //●車両管理マスタリモートの登録処理を実行する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 車両管理データを含む配列を分離
                    ArrayList carManagementList = ListUtils.Find(paramArray, typeof(CarManagementWork), ListUtils.FindType.Array) as ArrayList;

                    if (ListUtils.IsNotEmpty(carManagementList) && this.IOWriteCtrlOptWork.CarMngDivCd == 1)
                    {
                        // --- UPD 2012/08/29 y.wakita ----->>>>>
                        //status = this.carMgrDB.Write(ref carManagementList, sqlConnection, sqlTransaction);
                        status = this.carMgrDB.Write2(ref carManagementList, sqlConnection, sqlTransaction);
                        // --- UPD 2012/08/29 y.wakita -----<<<<<
                    }
                }

                //●受注マスタ(車両)リモートの登録処理を実行する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 受注マスタ(車両)データを含む配列を分離
                    ArrayList acpOdrCarList = ListUtils.Find(paramArray, typeof(AcceptOdrCarWork), ListUtils.FindType.Array) as ArrayList;

                    if (ListUtils.IsNotEmpty(acpOdrCarList))
                    {
                        status = this.acpOdrCarDB.Write(ref acpOdrCarList, sqlConnection, sqlTransaction);
                    }
                }

                //--- ADD 2008/06/06 M.Kubota ---<<<

                //②入金マスタWrite関数を呼び出す (売上データ更新成功＆自動入金区分=1:自動入金の場合)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && wrkSalesSlipWork.AutoDepositCd == 1)
                {
                    int depositWork_Posi = MakePosition(paramArray, typeof(DepsitDataWork), 0);

                    if (depositWork_Posi > -1)
                    {
                        status = this.DepositDb.Write(_origin, ref originArray, ref paramArray, depositWork_Posi, "", ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                        //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //{
                        //    // 売上履歴データの入金引当合計額や入金引当残高を指定
                        //    int salesHistoryWork_Posi = MakePosition(paramArray, typeof(SalesHistoryWork), 0);

                        //    if (salesHistoryWork_Posi > -1)
                        //    {
                        //        (paramArray[salesHistoryWork_Posi] as SalesHistoryWork).DepositAllowanceTtl = wrkSalesSlipWork.DepositAllowanceTtl;  // 入金引当合計額
                        //        (paramArray[salesHistoryWork_Posi] as SalesHistoryWork).DepositAlwcBlnce = wrkSalesSlipWork.DepositAlwcBlnce;        // 入金引当残高
                        //    }
                        //}
                    }
                }

                //③売上履歴のWrite関数を呼び出す
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && wrkSalesSlipWork.AcptAnOdrStatus == 30)
                {
                    ArrayList workArray = (paramArray as ArrayList);
                    status = this.SalesSlipHistDb.WriteInitialize(ref workArray, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = this.SalesSlipHistDb.Write(ref workArray, ref sqlConnection, ref sqlTransaction);
                    }
                }

                //--- ADD 2008/06/06 M.Kubota --->>>
                //④得意先マスタ(変動情報)の売掛残高を更新する
                // --- UPD 2013/03/18 y.wakita ----->>>>>
                //// --- UPD 2013/03/12 y.wakita ----->>>>>
                ////if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                ////    wrkSalesSlipWork.AcptAnOdrStatus == 30 && wrkSalesSlipWork.AccRecDivCd == 1)
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && wrkSalesSlipWork.AcptAnOdrStatus == 30)
                //// --- UPD 2013/03/12 y.wakita -----<<<<<
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && 
                    wrkSalesSlipWork.AcptAnOdrStatus == 30 &&
                    wrkSalesSlipWork.AutoDepositCd == 0)
                // --- UPD 2013/03/18 y.wakita -----<<<<<
                {
                    CustomerChangeWork cstChgWrk = new CustomerChangeWork();
                    cstChgWrk.EnterpriseCode = wrkSalesSlipWork.EnterpriseCode;
                    // --- UPD 2013/03/12 y.wakita ----->>>>>
                    //cstChgWrk.CustomerCode = wrkSalesSlipWork.CustomerCode;
                    cstChgWrk.CustomerCode = wrkSalesSlipWork.ClaimCode;    //得意先⇒請求先
                    // --- UPD 2013/03/12 y.wakita -----<<<<<

                    // 売上伝票合計(税込)の差分(更新後－更新前)を算出する
                    Int64 differenceValue = wrkSalesSlipWork.SalesTotalTaxInc;

                    int org_SalesSlipWork_Pos = MakePosition(originArray, typeof(SalesSlipWork), 0);

                    if (org_SalesSlipWork_Pos > -1)
                    {
                        SalesSlipWork orgSlsSlpWrk = originArray[org_SalesSlipWork_Pos] as SalesSlipWork;

                        // 売上伝票の主キーが同じ物の場合にのみ、変更前の売上伝票合計額(税込)の値を減算する
                        if (orgSlsSlpWrk != null &&
                            wrkSalesSlipWork.EnterpriseCode == orgSlsSlpWrk.EnterpriseCode &&
                            wrkSalesSlipWork.AcptAnOdrStatus == orgSlsSlpWrk.AcptAnOdrStatus &&
                            wrkSalesSlipWork.SalesSlipNum == orgSlsSlpWrk.SalesSlipNum)
                        {
                            differenceValue -= orgSlsSlpWrk.SalesTotalTaxInc;
                        }
                    }

                    status = this.CustomerChangeDb.PrsntAccRecBalanceUpdateProc(ref cstChgWrk, differenceValue, ref sqlConnection, ref sqlTransaction);
                }

                //⑤商品マスタへの登録 (商品マスタと商品価格マスタへの追加登録が同時に行われる)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    int addListPos = -1;
                    status = this.GoodsUserDb.Write(ref paramArray, out addListPos, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }

                //⑦月次集計更新処理
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 売上月次集計データ更新パラメータ設定
                    MTtlSalesUpdParaWork mTtlSlsUpdPara = new MTtlSalesUpdParaWork();
                    mTtlSlsUpdPara.EnterpriseCode = wrkSalesSlipWork.EnterpriseCode;  // 企業コード
                    mTtlSlsUpdPara.AddUpSecCode = wrkSalesSlipWork.SectionCode;       // 計上拠点コード(拠点コード)
                    mTtlSlsUpdPara.AddUpYearMonthSt = 0;                              // 計上年月(開始) 0:未指定
                    mTtlSlsUpdPara.AddUpYearMonthEd = 0;                              // 計上年月(終了) 0:未指定
                    mTtlSlsUpdPara.SlipRegDiv = 1;                                    // 伝票登録区分 1:登録
                    mTtlSlsUpdPara.MTtlSalesPrcFlg = 1;                               // 売上月次集計データ処理対象フラグ 1:対象
                    mTtlSlsUpdPara.GoodsMTtlSaPrcFlg = 1;                             // 商品別売上月次集計データ処理対象フラグ 1:対象

                    ArrayList newSalesSlips = new ArrayList();
                    newSalesSlips.Add(paramArray);

                    ArrayList oldSalesSlips = new ArrayList();
                    oldSalesSlips.Add(originArray);

                    status = this.MonthlyTtlSalesUpdDb.Write(mTtlSlsUpdPara, newSalesSlips, oldSalesSlips, sqlConnection, sqlTransaction);
                }
                //--- ADD 2008/06/06 M.Kubota ---<<<

                //⑧在庫データWrite関数を呼び出す(在庫更新リモートから在庫受払履歴更新リモートを呼び出す)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && wrkSalesSlipWork.AcptAnOdrStatus != 10)
                {
                    status = this.StockUpdDb.Write(_origin, ref originArray, ref paramArray, salesSlipWork_Posi, "", ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                }

                // 2009/05/18 >>>>>>>>>>>>>>>>>>>>>>>
                //⑨ＳＣＭ関連データ登録処理
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ADD 2013/05/08 三戸 2013/06/18配信 SCM障害№10308,№10528 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    ArrayList salesDetailWorks = ListUtils.Find(paramArray, typeof(SalesDetailWork), ListUtils.FindType.Array) as ArrayList;
                    ArrayList scmAcOdrDtlAsWorks = ListUtils.Find(paramArray, typeof(SCMAcOdrDtlAsWork), ListUtils.FindType.Array) as ArrayList;
                    // ADD 2013/06/03 三戸 2013/06/18配信 システムテスト障害№18 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    if (scmAcOdrDtlAsWorks != null)
                    {
                        // ADD 2013/06/03 三戸 2013/06/18配信 システムテスト障害№18 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        foreach (SCMAcOdrDtlAsWork scmAcOdrDtlAsRow in scmAcOdrDtlAsWorks)
                        {
                            scmAcOdrDtlAsRow.SalesTotalTaxInc = wrkSalesSlipWork.SalesTotalTaxInc; // 売上伝票合計（税込）
                            scmAcOdrDtlAsRow.SalesTotalTaxExc = wrkSalesSlipWork.SalesTotalTaxExc; // 売上伝票合計（税抜）
                            scmAcOdrDtlAsRow.ScmConsTaxLayMethod = wrkSalesSlipWork.ConsTaxLayMethod; // SCM消費税転嫁方式
                            scmAcOdrDtlAsRow.ConsTaxRate = wrkSalesSlipWork.ConsTaxRate; // 消費税税率
                            scmAcOdrDtlAsRow.ScmFractionProcCd = wrkSalesSlipWork.FractionProcCd; // SCM端数処理区分
                            scmAcOdrDtlAsRow.AccRecConsTax = wrkSalesSlipWork.AccRecConsTax; // 売掛消費税
                            scmAcOdrDtlAsRow.PMSalesDate = Int32.Parse(wrkSalesSlipWork.SalesDate.ToString("yyyyMMdd")); // PM売上日
                            // 仕入先伝票発行時刻
                            DateTime workDateTime = new DateTime();
                            workDateTime = wrkSalesSlipWork.UpdateDateTime;
                            Int32 workSuppSlpPrtTime;
                            workSuppSlpPrtTime = workDateTime.Millisecond;
                            workSuppSlpPrtTime += workDateTime.Second * 1000;
                            workSuppSlpPrtTime += workDateTime.Minute * 100000;
                            workSuppSlpPrtTime += workDateTime.Hour * 10000000;
                            scmAcOdrDtlAsRow.SuppSlpPrtTime = workSuppSlpPrtTime; // 仕入先伝票発行時刻
                            foreach (SalesDetailWork salesDetailRow in salesDetailWorks)
                            {
                                if (scmAcOdrDtlAsRow.SalesSlipNum == salesDetailRow.SalesSlipNum
                                    && scmAcOdrDtlAsRow.SalesRowNo == salesDetailRow.SalesRowNo)
                                {
                                    scmAcOdrDtlAsRow.SalesMoneyTaxInc = salesDetailRow.SalesMoneyTaxInc; // 売上金額（税込み）
                                    scmAcOdrDtlAsRow.SalesMoneyTaxExc = salesDetailRow.SalesMoneyTaxExc; // 売上金額（税抜き）
                                    break;
                                }
                            }
                            // ADD 2013/05/15 吉岡 2013/06/18配信 SCM障害№10410 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                            scmAcOdrDtlAsRow.DataInputSystem = 10; // データ入力システム 10:パーツマン
                            // ADD 2013/05/15 吉岡 2013/06/18配信 SCM障害№10410 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        }
                        // ADD 2013/06/03 三戸 2013/06/18配信 システムテスト障害№18 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    }
                    // ADD 2013/06/03 三戸 2013/06/18配信 システムテスト障害№18 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                    // ADD 2013/05/08 三戸 2013/06/18配信 SCM障害№10308,№10528 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                    status = this.scmIOWriteDB.ScmWrite(ref paramArray, 1, ref sqlConnection, ref sqlTransaction);
                }
                // 2009/05/18 <<<<<<<<<<<<<<<<<<<<<<<

                // --- ADD m.suzuki 2010/05/13 ---------->>>>>
                //⑩自由検索部品 自動登録処理
                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    // 売上明細データを分離
                    ArrayList salesDetailList = ListUtils.Find( paramArray, typeof( SalesDetailWork ), ListUtils.FindType.Array ) as ArrayList;

                    // 受注マスタ(車両)データを含む配列を分離
                    ArrayList acpOdrCarList = ListUtils.Find( paramArray, typeof( AcceptOdrCarWork ), ListUtils.FindType.Array ) as ArrayList;

                    // 伝票明細追加情報を分離
                    ArrayList slpDtlAdInfList = ListUtils.Find( paramArray, typeof( SlipDetailAddInfoWork ), ListUtils.FindType.Array ) as ArrayList;

                    status = this.FreeSearchPartsDB.WriteFreeSearchParts( ref salesDetailList, ref acpOdrCarList, ref slpDtlAdInfList, ref sqlConnection, ref sqlTransaction );
                }
                // --- ADD m.suzuki 2010/05/13 ----------<<<<<
            }
                 
            return status;
        }
        #endregion

        #region [etc] パラメータ関連処理
        /// <summary>
        /// 排他コントロール
        /// </summary>
        /// <param name="mode">処理区分 0:Lock 1:UnLock</param>
        /// <param name="ctrlExclsvOdAcs">排他部品オブジェクト</param>
        /// <param name="salesSlipWork">排他設定売上クラス</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        private int ControlExclusiveProc(int mode, ref ControlExclusiveOrderAccess ctrlExclsvOdAcs, ref SalesSlipWork salesSlipWork, ref string msg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //パラメータチェック
            if (salesSlipWork == null)
            {
                msg = "プログラムエラー。売上パラメータが未設定です";
                return status;
            }

            //排他Lockモードの場合
            if (mode == 0)
            {
                ArrayList al = new ArrayList();
                //得意先コードがあれば追加
                if (salesSlipWork.CustomerCode > 0) al.Add(salesSlipWork.CustomerCode);

                //得意先があるもしくは売上伝票番号/赤黒連結受注票番号がある場合は排他Lock
                //if (al.Count > 0 || TStrConv.StrToIntDef(salesSlipWork.SalesSlipNum, 0) > 0 || salesSlipWork.DebitNLnkAcptAnOdr > 0)  //DEL 2008/06/06 M.Kubota
                if (al.Count > 0 || TStrConv.StrToIntDef(salesSlipWork.SalesSlipNum, 0) > 0 )  //ADD 2008/06/06 M.Kubota
                {
                    //売上伝票番号数を計算
                    Int32 cntSupSlipNo = 0;
                    if (TStrConv.StrToIntDef(salesSlipWork.SalesSlipNum, 0) > 0) cntSupSlipNo++;
                    //if (salesSlipWork.DebitNLnkAcptAnOdr > 0) cntSupSlipNo++;  //DEL 2008/06/06 M.Kubota

                    //得意先・売上伝票番号をセット
                    Int32[] customerCodeList = (Int32[])al.ToArray(typeof(Int32));
                    Int32[] supplierSlipNoList = new Int32[cntSupSlipNo];
                    
                    //売上伝票番号をセット
                    if (TStrConv.StrToIntDef(salesSlipWork.SalesSlipNum, 0) > 0) supplierSlipNoList[0] = TStrConv.StrToIntDef(salesSlipWork.SalesSlipNum, 0);
                    
                    //--- DEL 2008/06/06 M.Kubota --->>>
                    //赤黒連結売上伝票番号をセット
                    //if (salesSlipWork.DebitNLnkAcptAnOdr > 0)
                    //{
                    //    if (supplierSlipNoList[0] == 0) supplierSlipNoList[0] = salesSlipWork.DebitNLnkAcptAnOdr;
                    //    else supplierSlipNoList[1] = salesSlipWork.DebitNLnkAcptAnOdr;
                    //}
                    //--- DEL 2008/06/06 M.Kubota ---<<<

                    status = ctrlExclsvOdAcs.LockDB(salesSlipWork.EnterpriseCode, customerCodeList, null);
                    
                    if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE ||
                        status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                    {
                        msg = "排他の為登録出来ませんでした。しばらくお待ちになって再度登録してください";
                    }
                    if (status == (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT)
                    {
                        msg = "データサーバーの接続がタイムアウトになりました。しばらくお待ちになって再度登録してください";
                    }
                }

                //排他情報が何も無い場合は正常戻り値を戻す
                else status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            //排他UnLockモードの場合
            else status = ctrlExclsvOdAcs.UnlockDB();

            return status;
        }

        /// <summary>
        /// パラメータ取得
        /// </summary>
        /// <param name="paramArray">受け取りパラメータList</param>
        /// <param name="type">取得タイプ</param>
        /// <param name="pattern">パラメータパターン：0クラス 1:Array</param>
        /// <returns>パラメータオブジェクト</returns>
        private object MakeParameter(CustomSerializeArrayList paramArray, Type type, Int32 pattern)
        {
            object result = null;
            //パラメータを取得
            if (pattern == 0)
            {
                foreach (object obj in paramArray)
                {
                    if (obj != null && obj.GetType() == type)
                    {
                        result = obj;
                        break;
                    }
                }
            }
            else
            {
                foreach (object obj in paramArray)
                {
                    if (obj is ArrayList)
                    {
                        ArrayList al = obj as ArrayList;
                        if (al != null && al.Count > 0)
                        {
                            if (al[0] != null && al[0].GetType() == type)
                            {
                                result = obj;
                                break;
                            }
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// パラメータ位置取得
        /// </summary>
        /// <param name="paramArray">受け取りパラメータList</param>
        /// <param name="type">取得タイプ</param>
        /// <param name="pattern">パラメータパターン：0クラス 1:Array</param>
        /// <returns>パラメータ位置:無い場合は-1</returns>
        private int MakePosition(CustomSerializeArrayList paramArray, Type type, Int32 pattern)
        {
            int result = -1;

            //パラメータを取得
            if (pattern == 0)
            {
                for (int i = 0; i < paramArray.Count; i++)
                {
                    if (paramArray[i] != null && paramArray[i].GetType() == type)
                    {
                        result = i;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < paramArray.Count; i++)
                {
                    if (paramArray[i] is ArrayList)
                    {
                        ArrayList al = paramArray[i] as ArrayList;
                        if (al != null && al.Count > 0)
                        {
                            if (al[0] != null && al[0].GetType() == type)
                            {
                                result = i;
                                break;
                            }
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 売上パラメータ取得
        /// </summary>
        /// <param name="source">パラメータ</param>
        /// <returns>SalesSlipWorkオブジェクト</returns>
        private SalesSlipWork MakeSalesSlipWork(object source)
        {
            SalesSlipWork salesSlipWork = null;
            
            if (source is IOWriteMAHNBDeleteWork)
            {
                IOWriteMAHNBDeleteWork iOWriteMAHNBDeleteWork = source as IOWriteMAHNBDeleteWork;

                salesSlipWork = new SalesSlipWork();
                salesSlipWork.UpdateDateTime = iOWriteMAHNBDeleteWork.UpdateDateTime;
                salesSlipWork.EnterpriseCode = iOWriteMAHNBDeleteWork.EnterpriseCode;
                salesSlipWork.AcptAnOdrStatus = iOWriteMAHNBDeleteWork.AcptAnOdrStatus;
                salesSlipWork.SalesSlipNum = iOWriteMAHNBDeleteWork.SalesSlipNum;
                salesSlipWork.DebitNoteDiv = iOWriteMAHNBDeleteWork.DebitNoteDiv;
            }

            return salesSlipWork;
        }
        #endregion

        #region [Delete] エントリ削除
        /// <summary>
        /// エントリ情報論理削除
        /// </summary>
        /// <param name="paraList">論理削除対象オブジェクトリスト</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <returns>STATUS</returns>
        public int Delete(ref object paraList, out string retMsg, out string retItemInfo)
        {
            //●STATUS初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            retMsg = "";
            retItemInfo = "";

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlEncryptInfo sqlEncryptInfo = null;
            SqlConnectionInfo sqlConnectionInfo = null;

            CustomSerializeArrayList paramArray = paraList as CustomSerializeArrayList;

            try
            {
                sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //●SQLコネクションオブジェクト作成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //●暗号化キーOPEN
                //sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, IOWriteMAHNBDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Delete));
                //sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //●トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = this.Delete(ref paramArray, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                //●コミットorロールバック
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    sqlTransaction.Commit();
                }
                else
                {
                    sqlTransaction.Rollback();
                }
            }
            //●例外処理
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "IOWriteMAHNBDB.Delete Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                //●暗号化キーCLOSE
                //if (sqlEncryptInfo != null && sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);

                //●コネクション破棄
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }

                //データ無しの場合はステータスを警告ステータスに変更する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND ||
                    status == (int)ConstantManagement.DB_Status.ctDB_EOF) status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
            }

            //STATUSを戻す
            return status;
        }

        /// <summary>
        /// エントリ情報論理削除（コネクションパラメータ付）
        /// </summary>
        /// <param name="paramArray">論理削除対象オブジェクトリスト</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        public int Delete(ref CustomSerializeArrayList paramArray, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            //●STATUS初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = "";
            retItemInfo = "";
            CustomSerializeArrayList paramArray_BackUp = null;

            //SalesSlipWork excSalesSlipWork = null;
            //ControlExclusiveOrderAccess ctrlExclsvOdAcs = null;
            IOWriteMAHNBDeleteWork iOWriteMAHNBDeleteWork = null;

            CustomSerializeArrayList originArray = new CustomSerializeArrayList();

            try
            {
                //●パラメータチェック
                if (paramArray == null || paramArray.Count <= 0)
                {
                    retMsg = "プログラムエラー。パラメータが未設定です。";
                    base.WriteErrorLog(null, retMsg);
                    return status;
                }

                //●パラメータバックアップ
                paramArray_BackUp = new CustomSerializeArrayList();
                paramArray_BackUp.AddRange(paramArray);

                //●Delete用主軸パラメータ生成
                status = MakeDeleteFunctionParam(ref paramArray, out iOWriteMAHNBDeleteWork);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //取得パラメータチェック
                    //if (iOWriteMAHNBDeleteWork.EnterpriseCode == null || iOWriteMAHNBDeleteWork.EnterpriseCode.Trim().Length == 0 || iOWriteMAHNBDeleteWork.SupplierSlipNo == 0)
                    if (string.IsNullOrEmpty(iOWriteMAHNBDeleteWork.EnterpriseCode) || (TStrConv.StrToIntDef(iOWriteMAHNBDeleteWork.SalesSlipNum, 0) == 0))
                    {
                        retMsg = "プログラムエラー。パラメータに企業コードもしくは売上伝票番号が指定されていません。";
                        base.WriteErrorLog(null, retMsg);
                        return status;
                    }
                }
                else
                {
                    SalesDetailWork dtlwork = (paramArray as ArrayList)[0] as SalesDetailWork;

                    if (dtlwork != null)
                    {
                        //ステータス初期化
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        retMsg = "プログラムエラー。パラメータが未設定です。";
                        base.WriteErrorLog(null, retMsg);
                        return status;
                    }

                    /*
                    foreach (object item in paramArray)
                    {
                        if (item is ArrayList && (item as ArrayList).Count > 0 && (item as ArrayList)[0] is StockDetailWork)
                        {
                            StockDetailWork dtlwork = (item as ArrayList)[0] as StockDetailWork;

                            // 発注データ削除の場合でも無い場合はパラメータ未設定とする
                            if (dtlwork != null && dtlwork.SupplierFormal == 2)
                            {
                                //ステータス初期化
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                            else
                            {
                                retMsg = "プログラムエラー。パラメータが未設定です。";
                                base.WriteErrorLog(null, retMsg);
                                return status;
                            }
                        }
                    }
                    */
                }

                //●排他Lock
                //if (iOWriteMAHNBDeleteWork != null)
                //{
                //    //ステータス初期化
                //    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                //    ctrlExclsvOdAcs = new ControlExclusiveOrderAccess();
                //    excSalesSlipWork = MakeSalesSlipWork(iOWriteMAHNBDeleteWork);

                //    status = ControlExclusiveProc(0, ref ctrlExclsvOdAcs, ref excSalesSlipWork, ref retMsg);
                //}

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //●売上伝票削除では自由パラメータは利用しない
                    object freeParam = null;

                    #region 削除準備
                    //●DeleteInitial前オプションファンクション呼び出し
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.DeleteInitial(_origin, _funcCallKey_BFR, ref originArray, ref paramArray, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                    //●IOWrite DeleteInitial処理メイン
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = IOWriteMASIRFunctionProcDeleteInitial(ref originArray, ref paramArray, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                    //●DeleteInitial後オプションファンクション呼び出し
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.DeleteInitial(_origin, _funcCallKey_AFT, ref originArray, ref paramArray, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                    #endregion

                    #region Initial処理が上手くいったら実Delete
                    //●Delete前オプションファンクション呼び出し
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.Delete(_origin, _funcCallKey_BFR, ref originArray, ref paramArray, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                    //●IOWrite Delete処理メイン
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = IOWriteMASIRFunctionProcDelete(ref originArray, ref paramArray, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                    //●Delete後オプションファンクション呼び出し
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.Delete(_origin, _funcCallKey_AFT, ref originArray, ref paramArray, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                    #endregion
                }
            }
            //●例外処理
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "IOWriteMAHNBDB.Delete(Connection付) Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                //●排他Lock破棄
                //if (iOWriteMAHNBDeleteWork != null)
                //{
                //    ControlExclusiveProc(1, ref ctrlExclsvOdAcs, ref excSalesSlipWork, ref retMsg);
                //}

                //正常終了時以外はバックアップパラメータを戻す
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && paramArray_BackUp != null) paramArray = paramArray_BackUp;

                //データ無しの場合はステータスを警告ステータスに変更する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND ||
                    status == (int)ConstantManagement.DB_Status.ctDB_EOF) status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
            }

            //STATUSを戻す
            return status;
        }

        /// <summary>
        /// IOWrite DeleteInitial処理メイン
        /// </summary>
        /// <param name="originArray">旧パラメータList</param>
        /// <param name="paramArray">パラメータList</param>
        /// <param name="freeParam">ﾌﾘｰﾊﾟﾗﾒｰﾀ</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">Sql接続情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        private Int32 IOWriteMASIRFunctionProcDeleteInitial(ref CustomSerializeArrayList originArray, ref CustomSerializeArrayList paramArray, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retMsg = "";
            retItemInfo = "";

            //①売上DeleteInitial関数を呼び出す
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                int salesSlipWork_Posi = MakePosition(paramArray, typeof(SalesSlipDeleteWork), 0);
                status = this.SalesSlipDb.DeleteInitial(_origin, ref originArray, ref paramArray, salesSlipWork_Posi, "", ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                // 売上履歴DeleteInitializeを実行する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                    (paramArray[salesSlipWork_Posi] as SalesSlipDeleteWork).AcptAnOdrStatus == 30)
                {
                    ArrayList workArray = (paramArray as ArrayList);
                    status = this.SalesSlipHistDb.DeleteInitialize(ref workArray, ref sqlConnection, ref sqlTransaction);
                }
            }

            //②入金マスタDeleteInitial関数を呼び出す(入金マスタ/入金引当マスタ)
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //>>>2010/09/28
                //int depositWork_Posi = MakePosition(paramArray, typeof(DepsitMainWork), 0);
                int depositWork_Posi = MakePosition(paramArray, typeof(DepsitDataWork), 0);
                //<<<2010/09/28

                if (depositWork_Posi > -1)
                {
                    status = this.DepositDb.DeleteInitial(_origin, ref originArray, ref paramArray, depositWork_Posi, ""/*構成ﾌｧｲﾙﾊﾟﾗﾒｰﾀ無し*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                }
            }

            //③在庫データDeleteInitial関数を呼び出す(在庫マスタ/製番在庫マスタ/在庫受払履歴データ/在庫受払履歴明細データ)
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                int salesSlipWork_Posi = MakePosition(paramArray, typeof(SalesSlipDeleteWork), 0);
                status = this.StockUpdDb.DeleteInitial(_origin, ref originArray, ref paramArray, salesSlipWork_Posi, "", ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
            }

            return status;
        }

        /// <summary>
        /// IOWrite Delete処理メイン
        /// </summary>
        /// <param name="originArray">旧パラメータList</param>
        /// <param name="paramArray">パラメータList</param>
        /// <param name="freeParam">ﾌﾘｰﾊﾟﾗﾒｰﾀ</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">Sql接続情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        private Int32 IOWriteMASIRFunctionProcDelete(ref CustomSerializeArrayList originArray, ref CustomSerializeArrayList paramArray, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retMsg = "";
            retItemInfo = "";

            //①売上Delete関数を呼び出す
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                int salesSlipWork_Posi = MakePosition(paramArray, typeof(SalesSlipDeleteWork), 0);
                status = this.SalesSlipDb.Delete(_origin, ref originArray, ref paramArray, salesSlipWork_Posi, "", ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                // ADD 2011/07/25 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
                if (STATUS_CHK_SEND_ERR == status)
                    return status;
                // ADD 2011/07/25 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<

                // 売上履歴LogicalDelete関数を呼び出す
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                    (paramArray[salesSlipWork_Posi] as SalesSlipDeleteWork).AcptAnOdrStatus == 30)
                {
                    ArrayList workArray = (paramArray as ArrayList);
                    status = this.SalesSlipHistDb.LogicalDelete(ref workArray, ref sqlConnection, ref sqlTransaction);
                }
            }

            // --- ADD 2012/09/24 y.wakita ----->>>>>
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                return status;
            // --- ADD 2012/09/24 y.wakita -----<<<<<

            //--- ADD 2008/06/06 M.Kubota --->>>
            //②得意先マスタ(変動情報)の売掛残高を更新する
            int delSalSlipPos = MakePosition(originArray, typeof(SalesSlipWork), 0);

            if (delSalSlipPos > -1)
            {
                SalesSlipWork delSalSlpWrk = originArray[delSalSlipPos] as SalesSlipWork;

                // --- UPD 2013/03/18 y.wakita ----->>>>>
                //// --- UPD 2013/03/12 y.wakita ----->>>>>
                ////if (delSalSlpWrk != null && delSalSlpWrk.AcptAnOdrStatus == 30 && delSalSlpWrk.AccRecDivCd == 1)
                //if (delSalSlpWrk != null && delSalSlpWrk.AcptAnOdrStatus == 30)
                //// --- UPD 2013/03/12 y.wakita -----<<<<
                if (delSalSlpWrk != null && 
                    delSalSlpWrk.AcptAnOdrStatus == 30 &&
                    delSalSlpWrk.AutoDepositCd == 0)
                // --- UPD 2013/03/18 y.wakita -----<<<<
                {
                    CustomerChangeWork cstChgWrk = new CustomerChangeWork();
                    cstChgWrk.EnterpriseCode = delSalSlpWrk.EnterpriseCode;
                    // --- UPD 2013/03/12 y.wakita ----->>>>>
                    //cstChgWrk.CustomerCode = delSalSlpWrk.CustomerCode;
                    cstChgWrk.CustomerCode = delSalSlpWrk.ClaimCode;    //得意先⇒請求先
                    // --- UPD 2013/03/12 y.wakita -----<<<<

                    // 売上伝票合計(税込)の符号を反転させる
                    Int64 differenceValue = -delSalSlpWrk.SalesTotalTaxInc;

                    status = this.CustomerChangeDb.PrsntAccRecBalanceUpdateProc(ref cstChgWrk, differenceValue, ref sqlConnection, ref sqlTransaction);
                }
            }

            //③月次集計更新処理
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 売上月次集計データ更新パラメータ設定
                int slsSlpDelWrk_Pos = MakePosition(originArray, typeof(SalesSlipWork), 0);

                SalesSlipWork slsSlpDelWrk = (originArray[slsSlpDelWrk_Pos] as SalesSlipWork);

                if (slsSlpDelWrk != null)
                {
                    MTtlSalesUpdParaWork mTtlSlsUpdPara = new MTtlSalesUpdParaWork();
                    mTtlSlsUpdPara.EnterpriseCode = slsSlpDelWrk.EnterpriseCode;  // 企業コード
                    mTtlSlsUpdPara.AddUpSecCode = slsSlpDelWrk.SectionCode;       // 計上拠点コード(拠点コード)
                    mTtlSlsUpdPara.AddUpYearMonthSt = 0;                          // 計上年月(開始) 0:未指定
                    mTtlSlsUpdPara.AddUpYearMonthEd = 0;                          // 計上年月(終了) 0:未指定
                    mTtlSlsUpdPara.SlipRegDiv = 0;                                // 伝票登録区分 0:削除
                    mTtlSlsUpdPara.MTtlSalesPrcFlg = 1;                           // 売上月次集計データ処理対象フラグ 1:対象
                    mTtlSlsUpdPara.GoodsMTtlSaPrcFlg = 1;                         // 商品別売上月次集計データ処理対象フラグ 1:対象

                    ArrayList newSalesSlips = new ArrayList();
                    newSalesSlips.Add(paramArray);

                    ArrayList oldSalesSlips = new ArrayList();
                    oldSalesSlips.Add(originArray);

                    status = this.MonthlyTtlSalesUpdDb.Write(mTtlSlsUpdPara, newSalesSlips, oldSalesSlips, sqlConnection, sqlTransaction);
                }
            }
            //--- ADD 2008/06/06 M.Kubota ---<<<


            //④金額マスタDelete関数を呼び出す(支払金額マスタ/買掛金額マスタ)
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //>>>2010/09/28
                //int depositWork_Posi = MakePosition(paramArray, typeof(DepsitMainWork), 0);
                int depositWork_Posi = MakePosition(paramArray, typeof(IOWriteMAHNBDepositDB.DepositInfo), 0);
                //<<<2010/09/28

                if (depositWork_Posi > -1)
                {
                    status = this.DepositDb.Delete(_origin, ref originArray, ref paramArray, depositWork_Posi, ""/*構成ﾌｧｲﾙﾊﾟﾗﾒｰﾀ無し*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                }
            }

            //⑤在庫データDelete関数を呼び出す(在庫マスタ/製番在庫マスタ/在庫受払履歴データ/在庫受払履歴明細データ)
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                int salesSlipWork_Posi = MakePosition(paramArray, typeof(SalesSlipDeleteWork), 0);
                status = this.StockUpdDb.Delete(_origin, ref originArray, ref paramArray, salesSlipWork_Posi, "", ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
            }

            return status;
        }

        /// <summary>
        /// Delete用主軸パラメータ生成
        /// </summary>
        /// <param name="paramArray">受け取りパラメータList</param>
        /// <param name="iOWriteMAHNBDeleteWork">Deleteパラメータ</param>
        /// <returns>STATUS</returns>
        private int MakeDeleteFunctionParam(ref CustomSerializeArrayList paramArray, out IOWriteMAHNBDeleteWork iOWriteMAHNBDeleteWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            iOWriteMAHNBDeleteWork = null;
            //売上IOWriteDeleteパラメータから売上パラメータを生成
            foreach (object obj in paramArray)
            {
                if (obj is IOWriteMAHNBDeleteWork)
                {
                    iOWriteMAHNBDeleteWork = obj as IOWriteMAHNBDeleteWork;
                    //Debug↓今後仕様が詰まり次第対応
                    //iOWriteMAHNBDeleteWork.SupplierSlipNo = 0;
                    //iOWriteMAHNBDeleteWork.SupplierFormal = 0;
                    //Debug↑

                    //売上Delete用パラメータを生成
                    SalesSlipDeleteWork salesSlipDeleteWork = new SalesSlipDeleteWork();
                    salesSlipDeleteWork.UpdateDateTime = iOWriteMAHNBDeleteWork.UpdateDateTime;
                    salesSlipDeleteWork.EnterpriseCode = iOWriteMAHNBDeleteWork.EnterpriseCode;
                    salesSlipDeleteWork.AcptAnOdrStatus = iOWriteMAHNBDeleteWork.AcptAnOdrStatus;
                    salesSlipDeleteWork.SalesSlipNum = iOWriteMAHNBDeleteWork.SalesSlipNum;
                    salesSlipDeleteWork.DebitNoteDiv = iOWriteMAHNBDeleteWork.DebitNoteDiv;

                    paramArray.Add(salesSlipDeleteWork);

                    /*
                    //伝票Deleteパラメータを生成(伝票ワーククラス)
                    RpSlipDeleteWork rpSlipDeleteWork = new RpSlipDeleteWork();
                    rpSlipDeleteWork.EnterpriseCode = depositWork.EnterpriseCode;
                    rpSlipDeleteWork.StandardAcceptAnOrderNo = depositWork.StandardAcceptAnOrderNo;
                    if (depositWork.RpSlipNo != null && depositWork.RpSlipNo != "")
                    {
                        rpSlipDeleteWork.RpSlipKindCdList = new Int32[1];
                        rpSlipDeleteWork.RpSlipNoList = new string[1];
                        rpSlipDeleteWork.RpSlipKindCdList[0] = depositWork.RpSlipKindCd;
                        rpSlipDeleteWork.RpSlipNoList[0] = depositWork.RpSlipNo;
                    }
                    //全伝票削除の場合、伝票番号パラメータ無し（整備伝票ROにて追加）
                    else
                    {
                        rpSlipDeleteWork.RpSlipKindCdList = new Int32[0];
                        rpSlipDeleteWork.RpSlipNoList = new string[0];
                    }
                    paramArray.Add(rpSlipDeleteWork);

                    //金額更新用Deleteパラメータを生成
                    IOWriteMoneyDeleteParamWork iOWriteMoneyDeleteParamWork = new IOWriteMoneyDeleteParamWork();
                    iOWriteMoneyDeleteParamWork.DepsitAlwCheckFlag = depositWork.DepsitAlwCheckFlag;
                    paramArray.Add(iOWriteMoneyDeleteParamWork);
                    */

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    break;
                }
            }
            return status;
        }
        #endregion

        #region [RedWrite] 赤伝作成処理
        /// <summary>
        /// 赤伝作成(赤伝作成データを全てパラメータで貰う)
        /// </summary>
        /// <param name="originList">元黒用オブジェクトリスト</param>
        /// <param name="redList">赤伝用オブジェクトリスト</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <returns>STATUS</returns>
        public int RedWrite(ref object originList, ref object redList, out string retMsg, out string retItemInfo)
        {
            //●STATUS初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = "";
            retItemInfo = "";
            CustomSerializeArrayList originArray_BackUp = null;
            CustomSerializeArrayList redArray_BackUp = null;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            //SalesSlipWork excStockSlipWork = null;
            //ControlExclusiveOrderAccess ctrlExclsvOdAcs = null;

            try
            {
                //●パラメータチェック
                CustomSerializeArrayList originArray = originList as CustomSerializeArrayList;
                if (originArray == null || originArray.Count <= 0)
                {
                    retMsg = "プログラムエラー。RedWrite 元黒伝票パラメータが未設定です。";
                    base.WriteErrorLog(null, retMsg);
                    return status;
                }
                CustomSerializeArrayList redArray = redList as CustomSerializeArrayList;
                if (redArray == null || redArray.Count <= 0)
                {
                    retMsg = "プログラムエラー。RedWrite 赤伝票パラメータが未設定です。";
                    base.WriteErrorLog(null, retMsg);
                    return status;
                }

                //●パラメータバックアップ
                originArray_BackUp = new CustomSerializeArrayList();
                originArray_BackUp.AddRange(originArray);
                redArray_BackUp = new CustomSerializeArrayList();
                redArray_BackUp.AddRange(redArray);

                //●排他Lock
                //ctrlExclsvOdAcs = new ControlExclusiveOrderAccess();
                //excStockSlipWork = MakeParameter(originArray, typeof(SalesSlipWork), 0) as SalesSlipWork;
                //status = ControlExclusiveProc(0, ref ctrlExclsvOdAcs, ref excStockSlipWork, ref retMsg);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //●開始時にコネクション文字列を取得
                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    if (connectionText == null || connectionText == "") return status;

                    //●SQLコネクションオブジェクト作成
                    using (sqlConnection = new SqlConnection(connectionText))
                    {
                        SqlEncryptInfo sqlEncryptInfo = null;
                        try
                        {
                            sqlConnection.Open();

                            //●暗号化キーOPEN
                            //sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, IOWriteMAHNBDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.RedWrite));
                            //sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                            //●トランザクション開始
                            using (sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default))
                            {
                                try
                                {
                                    //●売上伝票赤伝作成では自由パラメータは利用しない
                                    object freeParam = null;
                                    CustomSerializeArrayList retRedArray = new CustomSerializeArrayList();

                                    #region 赤伝作成準備
                                    //●WriteRedInitial前オプションファンクション呼び出し
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.RedWriteInitial(_origin, _funcCallKey_BFR, ref originArray, ref redArray, ref retRedArray, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                                    //●IOWrite WriteRedInitial処理メイン
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = IOWriteMASIRFunctionProcRedWriteInitial(ref originArray, ref redArray, ref retRedArray, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                                    //●WriteRedInitial後オプションファンクション呼び出し
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.RedWriteInitial(_origin, _funcCallKey_AFT, ref originArray, ref redArray, ref retRedArray, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                                    #endregion

                                    #region Initial処理が上手くいったら実RedWrite
                                    //●WriteRed前オプションファンクション呼び出し
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.RedWrite(_origin, _funcCallKey_BFR, ref originArray, ref redArray, ref retRedArray, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                                    //●IOWrite WriteRed処理メイン
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = IOWriteMASIRFunctionProcRedWrite(ref originArray, ref redArray, ref retRedArray, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                                    //●WriteRed後オプションファンクション呼び出し
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.RedWrite(_origin, _funcCallKey_AFT, ref originArray, ref redArray, ref retRedArray, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                                    #endregion

                                    //●戻り値を設定
                                    redList = (object)retRedArray;
                                    originList = (object)originArray;
                                }
                                //●例外処理
                                catch (SqlException ex)
                                {
                                    status = base.WriteSQLErrorLog(ex);
                                }
                                catch (Exception ex)
                                {
                                    base.WriteErrorLog(ex, "IOWritMASIRFDB.RedWrite Exception=" + ex.Message);
                                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                }
                                finally
                                {
                                    //●コミットorロールバック
                                    //正常更新時コミット、異常発生時ロールバック
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) sqlTransaction.Commit();
                                    else sqlTransaction.Rollback();
                                }
                            }
                        }
                        finally
                        {
                            //●暗号化キーCLOSE
                            //if (sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);

                            //●コネクション破棄
                            if (sqlConnection != null) sqlConnection.Close();
                        }
                    }
                }
            }
            //●例外処理
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "IOWriteMAHNBDB.RedWrite Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                //●排他Lock破棄
                //ControlExclusiveProc(1, ref ctrlExclsvOdAcs, ref excStockSlipWork, ref retMsg);

                //正常終了時以外はバックアップパラメータを戻す
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (originArray_BackUp != null) originList = originArray_BackUp;
                    if (redArray_BackUp != null) redList = redArray_BackUp;
                }
                //データ無しの場合はステータスを警告ステータスに変更する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND ||
                    status == (int)ConstantManagement.DB_Status.ctDB_EOF) status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
            }

            //STATUSを戻す
            return status;
        }

        /// <summary>
        /// 赤伝作成(コネクションパラメータ付き)
        /// </summary>
        /// <param name="originList">元黒List</param>
        /// <param name="redList">赤伝List</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        public int RedWrite(ref CustomSerializeArrayList originList, ref CustomSerializeArrayList redList, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            //●STATUS初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retMsg = "";
            retItemInfo = "";
            CustomSerializeArrayList originArray_BackUp = null;
            CustomSerializeArrayList redArray_BackUp = null;

            SalesSlipWork excStockSlipWork = null;
            try
            {
                //●パラメータチェック
                if (originList == null || originList.Count <= 0)
                {
                    retMsg = "プログラムエラー。RedWrite 元黒伝票パラメータが未設定です。";
                    base.WriteErrorLog(null, retMsg);
                    return status;
                }

                if (redList == null || redList.Count <= 0)
                {
                    retMsg = "プログラムエラー。RedWrite 赤伝票パラメータが未設定です。";
                    base.WriteErrorLog(null, retMsg);
                    return status;
                }

                //●パラメータバックアップ
                originArray_BackUp = new CustomSerializeArrayList();
                originArray_BackUp.AddRange(originList);
                redArray_BackUp = new CustomSerializeArrayList();
                redArray_BackUp.AddRange(redList);

                excStockSlipWork = MakeParameter(originList, typeof(SalesSlipWork), 0) as SalesSlipWork;
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //●売上伝票赤伝作成では自由パラメータは利用しない
                    object freeParam = null;
                    CustomSerializeArrayList retRedList = new CustomSerializeArrayList();

                    #region 赤伝作成準備
                    //●WriteRedInitial前オプションファンクション呼び出し
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.RedWriteInitial(_origin, _funcCallKey_BFR, ref originList, ref redList, ref retRedList, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                    //●IOWrite WriteRedInitial処理メイン
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = IOWriteMASIRFunctionProcRedWriteInitial(ref originList, ref redList, ref retRedList, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                    //●WriteRedInitial後オプションファンクション呼び出し
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.RedWriteInitial(_origin, _funcCallKey_AFT, ref originList, ref redList, ref retRedList, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                    #endregion

                    #region Initial処理が上手くいったら実RedWrite
                    //●WriteRed前オプションファンクション呼び出し
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.RedWrite(_origin, _funcCallKey_BFR, ref originList, ref redList, ref retRedList, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                    //●IOWrite WriteRed処理メイン
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = IOWriteMASIRFunctionProcRedWrite(ref originList, ref redList, ref retRedList, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                    //●WriteRed後オプションファンクション呼び出し
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.RedWrite(_origin, _funcCallKey_AFT, ref originList, ref redList, ref retRedList, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                    #endregion

                    //●戻り値を設定
                    //redList = retRedArray;
                }
            }
            //●例外処理
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "IOWriteMAHNBDB.RedWrite Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                //正常終了時以外はバックアップパラメータを戻す
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (originArray_BackUp != null) originList = originArray_BackUp;
                    if (redArray_BackUp != null) redList = redArray_BackUp;
                }
                //データ無しの場合はステータスを警告ステータスに変更する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND ||
                    status == (int)ConstantManagement.DB_Status.ctDB_EOF) status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
            }

            //STATUSを戻す
            return status;
        }

        /// <summary>
        /// IOWrite RedWriteInitial処理メイン
        /// </summary>
        /// <param name="originArray">元黒パラメータList</param>
        /// <param name="redArray">赤伝パラメータList</param>
        /// <param name="retRedArray">赤伝戻りList</param>
        /// <param name="freeParam">ﾌﾘｰﾊﾟﾗﾒｰﾀ</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">Sql接続情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <br>Update Note: 2009/10/26       張凱</br>
        ///	<br>		   : 車輌情報処理を追加する</br>
        /// <br>Update Note: SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
        /// <br>Programmer : FSI厚川 宏</br>
        /// <br>Date       : 2013/03/21</br>
        /// <returns>STATUS</returns>
        private Int32 IOWriteMASIRFunctionProcRedWriteInitial(ref CustomSerializeArrayList originArray, ref CustomSerializeArrayList redArray, ref CustomSerializeArrayList retRedArray, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retMsg = "";
            retItemInfo = "";

            //①売上RedWriteInitial関数を呼び出す
            int redSalesSlip_Posi = MakePosition(redArray, typeof(SalesSlipWork), 0);
            SalesSlipWork redSalesSlip = redArray[redSalesSlip_Posi] as SalesSlipWork;
            status = this.SalesSlipDb.RedWriteInitial(_origin, ref originArray, ref redArray, ref retRedArray, redSalesSlip_Posi, ""/*構成ﾌｧｲﾙﾊﾟﾗﾒｰﾀ無し*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

            // --- ADD 2009/10/26 ---------->>>>>
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                # region [車両管理マスタデータの書込準備処理]

                //○車両管理データを含む配列を分離 → 受注マスタ(車両)の元データとなる為、この時点で取得しておく
                ArrayList carManagementList = ListUtils.Find(redArray, typeof(CarManagementWork), ListUtils.FindType.Array) as ArrayList;

                // 車両管理データのソート・検索をする際に使用する IComparer クラス
                CarManagementComparer carMngComp = new CarManagementComparer();

                if (ListUtils.IsNotEmpty(carManagementList))
                {
                    carManagementList.Sort(carMngComp);

                    if (this.IOWriteCtrlOptWork.CarMngDivCd == 1)
                    {
                        //●車両管理リモートの登録準備処理(車両管理番号(SEQ)を取得)を実行する
                        status = this.carMgrDB.WriteInitial(ref carManagementList, sqlConnection, sqlTransaction);

                    }
                }

                # endregion

                # region [受注マスタ(車両)データの作成]
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 売上明細データを取得
                    ArrayList salesDtlList = ListUtils.Find(redArray, typeof(SalesDetailWork), ListUtils.FindType.Array) as ArrayList;

                    // 伝票明細追加情報データを含む配列を分離
                    ArrayList slipDtlAddInfList = ListUtils.Find(redArray, typeof(SlipDetailAddInfoWork), ListUtils.FindType.Array) as ArrayList;

                    if (ListUtils.IsNotEmpty(salesDtlList) && ListUtils.IsNotEmpty(slipDtlAddInfList))
                    {
                        // 伝票明細追加情報データを明細関連付けGUIDで並び替える
                        SlipDetailAddInfoWork SlipDtlAddInfComp = new SlipDetailAddInfoWork();

                        SlipDetailAddInfoDtlRelationGuidComparer DtlRelationGuidComp = new SlipDetailAddInfoDtlRelationGuidComparer();
                        slipDtlAddInfList.Sort(DtlRelationGuidComp);

                        // 受注マスタ(車両)データを含む配列をリモートにて追加
                        ArrayList acpOdrCarList = new ArrayList();
                        AcceptOdrCarComparer acptOdrCarComp = new AcceptOdrCarComparer();

                        foreach (SalesDetailWork salesdtl in salesDtlList)
                        {
                            // 受注マスタ(車両)データを作成する
                            // 明細に紐付く伝票明細追加情報を取得
                            int idx = slipDtlAddInfList.BinarySearch(salesdtl.DtlRelationGuid, DtlRelationGuidComp);

                            if (idx > -1)
                            {
                                SlipDetailAddInfoWork slipDtlAddInf = slipDtlAddInfList[idx] as SlipDetailAddInfoWork;

                                if (slipDtlAddInf != null)
                                {
                                    // 伝票明細追加情報に紐付く車両管理データを取得
                                    CarManagementWork carMng = null;

                                    if (ListUtils.IsNotEmpty(carManagementList))
                                    {
                                        idx = carManagementList.BinarySearch(slipDtlAddInf.CarRelationGuid, carMngComp);

                                        if (idx > -1)
                                        {
                                            carMng = carManagementList[idx] as CarManagementWork;
                                        }
                                    }

                                    // 受注マスタ(車両)データを作成
                                    AcceptOdrCarWork acpOdrCar = new AcceptOdrCarWork();

                                    # region [受注マスタ(車両) ← 売上明細＋車両管理]
                                    acpOdrCar.EnterpriseCode = salesdtl.EnterpriseCode;          // 企業コード
                                    acpOdrCar.LogicalDeleteCode = (int)ConstantManagement.LogicalMode.GetData0;  // 論理削除区分
                                    acpOdrCar.AcceptAnOrderNo = salesdtl.AcceptAnOrderNo;        // 受注番号

                                    // 受注ステータス (売上の受注ステータスと受注マスタ(車両)のそれは内容が異なる為)
                                    switch (salesdtl.AcptAnOdrStatus)
                                    {
                                        case 10:  // 見積
                                            {
                                                acpOdrCar.AcptAnOdrStatus = 1;
                                                break;
                                            }
                                        case 20:  // 受注
                                            {
                                                acpOdrCar.AcptAnOdrStatus = 3;
                                                break;
                                            }
                                        case 30:  // 売上
                                            {
                                                acpOdrCar.AcptAnOdrStatus = 7;
                                                break;
                                            }
                                        case 40:  // 出荷
                                            {
                                                acpOdrCar.AcptAnOdrStatus = 5;
                                                break;
                                            }
                                    }

                                    acpOdrCar.DataInputSystem = (int)DataInputSystem.PM;             // データ入力システム

                                    if (carMng != null)
                                    {
                                        acpOdrCar.CarMngNo = carMng.CarMngNo;                        // 車両管理番号
                                        acpOdrCar.CarMngCode = carMng.CarMngCode;                    // 車輌管理コード
                                        acpOdrCar.NumberPlate1Code = carMng.NumberPlate1Code;        // 陸運事務所番号
                                        acpOdrCar.NumberPlate1Name = carMng.NumberPlate1Name;        // 陸運事務局名称
                                        acpOdrCar.NumberPlate2 = carMng.NumberPlate2;                // 車両登録番号（種別）
                                        acpOdrCar.NumberPlate3 = carMng.NumberPlate3;                // 車両登録番号（カナ）
                                        acpOdrCar.NumberPlate4 = carMng.NumberPlate4;                // 車両登録番号（プレート番号）
                                        acpOdrCar.FirstEntryDate = carMng.FirstEntryDate;            // 初年度
                                        acpOdrCar.MakerCode = carMng.MakerCode;                      // メーカーコード
                                        acpOdrCar.MakerFullName = carMng.MakerFullName;              // メーカー全角名称
                                        acpOdrCar.MakerHalfName = carMng.MakerHalfName;              // メーカー半角名称
                                        acpOdrCar.ModelCode = carMng.ModelCode;                      // 車種コード
                                        acpOdrCar.ModelSubCode = carMng.ModelSubCode;                // 車種サブコード
                                        acpOdrCar.ModelFullName = carMng.ModelFullName;              // 車種全角名称
                                        acpOdrCar.ModelHalfName = carMng.ModelHalfName;              // 車種半角名称
                                        acpOdrCar.ExhaustGasSign = carMng.ExhaustGasSign;            // 排ガス記号
                                        acpOdrCar.SeriesModel = carMng.SeriesModel;                  // シリーズ型式
                                        acpOdrCar.CategorySignModel = carMng.CategorySignModel;      // 型式（類別記号）
                                        acpOdrCar.FullModel = carMng.FullModel;                      // 型式（フル型）
                                        acpOdrCar.ModelDesignationNo = carMng.ModelDesignationNo;    // 型式指定番号
                                        acpOdrCar.CategoryNo = carMng.CategoryNo;                    // 類別番号
                                        acpOdrCar.FrameModel = carMng.FrameModel;                    // 車台型式
                                        acpOdrCar.FrameNo = carMng.FrameNo;                          // 車台番号
                                        acpOdrCar.SearchFrameNo = carMng.SearchFrameNo;              // 車台番号（検索用）
                                        acpOdrCar.EngineModelNm = carMng.EngineModelNm;              // エンジン型式名称
                                        acpOdrCar.RelevanceModel = carMng.RelevanceModel;            // 関連型式
                                        acpOdrCar.SubCarNmCd = carMng.SubCarNmCd;                    // サブ車名コード
                                        acpOdrCar.ModelGradeSname = carMng.ModelGradeSname;          // 型式グレード略称
                                        acpOdrCar.ColorCode = carMng.ColorCode;                      // カラーコード
                                        acpOdrCar.ColorName1 = carMng.ColorName1;                    // カラー名称1
                                        acpOdrCar.TrimCode = carMng.TrimCode;                        // トリムコード
                                        acpOdrCar.TrimName = carMng.TrimName;                        // トリム名称
                                        acpOdrCar.Mileage = carMng.Mileage;                          // 車両走行距離
                                        acpOdrCar.FullModelFixedNoAry = carMng.FullModelFixedNoAry;  // フル型式固定番号配列
                                        acpOdrCar.CategoryObjAry = carMng.CategoryObjAry;            // 装備オブジェクト配列
                                        // --- ADD 2009/09/16 ---------->>>>>
                                        acpOdrCar.CarNote = carMng.CarNote;            // 車輌備考
                                        // --- ADD 2009/09/16 ----------<<<<<
                                        acpOdrCar.FreeSrchMdlFxdNoAry = carMng.FreeSrchMdlFxdNoAry; // 自由検索型式固定番号配列 // ADD 2010/04/27
                                        // --- ADD 2013/03/21 ---------->>>>>
                                        acpOdrCar.DomesticForeignCode = carMng.DomesticForeignCode; // 国産/外車区分
                                        // --- ADD 2013/03/21 ----------<<<<<
                                    }
                                    # endregion

                                    acpOdrCarList.Sort(acptOdrCarComp);
                                    idx = acpOdrCarList.BinarySearch(acpOdrCar, acptOdrCarComp);

                                    if (idx < 0)
                                    {
                                        acpOdrCarList.Add(acpOdrCar);
                                    }
                                }
                            }
                        }

                        // 受注マスタ(車両)データが存在している場合にのみパラメータリストに追加する
                        if (ListUtils.IsNotEmpty(acpOdrCarList))
                        {
                            redArray.Add(acpOdrCarList);
                        }
                    }
                }
                # endregion
            }
            // --- ADD 2009/10/26 ----------<<<<<

            //②入金マスタRedWriteInitial関数を呼び出す(入金マスタ/入金引当マスタ)
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && redSalesSlip.AutoDepositCd == 1)
            {
                int depositWork_Posi = MakePosition(redArray, typeof(DepsitDataWork), 0);

                if (depositWork_Posi > -1)
                {
                    status = this.DepositDb.RedWriteInitial(_origin, ref originArray, ref redArray, ref retRedArray, depositWork_Posi, ""/*構成ﾌｧｲﾙﾊﾟﾗﾒｰﾀ無し*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        redSalesSlip.AutoDepositSlipNo = (redArray[depositWork_Posi] as DepsitDataWork).DepositSlipNo;
                    }
                }
            }

            //③在庫データWriteInitial関数を呼び出す(在庫マスタ/製番在庫マスタ/在庫受払履歴データ)
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                int stockSlipWork_Posi = MakePosition(redArray, typeof(SalesSlipWork), 0);
                status = this.StockUpdDb.WriteInitial(_origin, ref originArray, ref redArray, stockSlipWork_Posi, "", ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
            }

            return status;
        }

        /// <summary>
        /// IOWrite RedWrite処理メイン
        /// </summary>
        /// <param name="originArray">元黒パラメータList</param>
        /// <param name="redArray">赤伝パラメータList</param>
        /// <param name="retRedArray">赤伝戻りList</param>
        /// <param name="freeParam">ﾌﾘｰﾊﾟﾗﾒｰﾀ</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">Sql接続情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <br>Update Note: 2009/10/26       張凱</br>
        ///	<br>		   : 車輌情報処理を追加する</br>
        /// <returns>STATUS</returns>
        private Int32 IOWriteMASIRFunctionProcRedWrite(ref CustomSerializeArrayList originArray, ref CustomSerializeArrayList redArray, ref CustomSerializeArrayList retRedArray, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retMsg = "";
            retItemInfo = "";

            // パラメータインデックスの取得
            int salesSlipWork_Posi = MakePosition(redArray, typeof(SalesSlipWork), 0);

            if (salesSlipWork_Posi > -1)
            {
                SalesSlipWork wrkSalesSlipWork = redArray[salesSlipWork_Posi] as SalesSlipWork;

                //①売上データRedWrite関数を呼び出す
                status = this.SalesSlipDb.RedWrite(_origin, ref originArray, ref redArray, ref retRedArray, salesSlipWork_Posi, ""/*構成ﾌｧｲﾙﾊﾟﾗﾒｰﾀ無し*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                if (status == STATUS_CHK_SEND_ERR) // add 2011.09.15 qijh #25167
                    return status; // add 2011.09.15 qijh #25167

                // --- ADD 2009/10/26 ---------->>>>>
                //●車両管理マスタリモートの登録処理を実行する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 車両管理データを含む配列を分離
                    ArrayList carManagementList = ListUtils.Find(redArray, typeof(CarManagementWork), ListUtils.FindType.Array) as ArrayList;

                    if (ListUtils.IsNotEmpty(carManagementList) && this.IOWriteCtrlOptWork.CarMngDivCd == 1)
                    {
                        // --- UPD 2012/08/29 y.wakita ----->>>>>
                        //status = this.carMgrDB.Write(ref carManagementList, sqlConnection, sqlTransaction);
                        status = this.carMgrDB.Write2(ref carManagementList, sqlConnection, sqlTransaction);
                        // --- UPD 2012/08/29 y.wakita -----<<<<<
                    }
                }

                //●受注マスタ(車両)リモートの登録処理を実行する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 受注マスタ(車両)データを含む配列を分離
                    ArrayList acpOdrCarList = ListUtils.Find(redArray, typeof(AcceptOdrCarWork), ListUtils.FindType.Array) as ArrayList;

                    if (ListUtils.IsNotEmpty(acpOdrCarList))
                    {
                        status = this.acpOdrCarDB.Write(ref acpOdrCarList, sqlConnection, sqlTransaction);
                    }
                }
                // --- ADD 2009/10/26 ----------<<<<<

                //--- ADD 2008/06/06 M.Kubota --->>>
                //②得意先マスタ(変動情報)の売掛残高を更新する
                // --- UPD 2013/03/18 y.wakita ----->>>>>
                //// --- UPD 2013/03/12 y.wakita ----->>>>>
                ////if (wrkSalesSlipWork.AcptAnOdrStatus == 30 && wrkSalesSlipWork.AccRecDivCd == 1)
                //if (wrkSalesSlipWork.AcptAnOdrStatus == 30)
                //// --- UPD 2013/03/12 y.wakita -----<<<<<
                if (wrkSalesSlipWork.AcptAnOdrStatus == 30 &&
                    wrkSalesSlipWork.AutoDepositCd == 0)
                // --- UPD 2013/03/18 y.wakita -----<<<<<
                {
                    CustomerChangeWork cstChgWrk = new CustomerChangeWork();
                    cstChgWrk.EnterpriseCode = wrkSalesSlipWork.EnterpriseCode;
                    // --- UPD 2013/03/12 y.wakita ----->>>>>
                    //cstChgWrk.CustomerCode = wrkSalesSlipWork.CustomerCode;
                    cstChgWrk.CustomerCode = wrkSalesSlipWork.ClaimCode;    //得意先⇒請求先
                    // --- UPD 2013/03/12 y.wakita -----<<<<<

                    Int64 differenceValue = wrkSalesSlipWork.SalesTotalTaxInc;

                    status = this.CustomerChangeDb.PrsntAccRecBalanceUpdateProc(ref cstChgWrk, differenceValue, ref sqlConnection, ref sqlTransaction);
                }

                //③月次集計更新処理
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 売上月次集計データ更新パラメータ設定
                    MTtlSalesUpdParaWork mTtlSlsUpdPara = new MTtlSalesUpdParaWork();
                    mTtlSlsUpdPara.EnterpriseCode = wrkSalesSlipWork.EnterpriseCode;  // 企業コード
                    mTtlSlsUpdPara.AddUpSecCode = wrkSalesSlipWork.SectionCode;       // 計上拠点コード(拠点コード)
                    mTtlSlsUpdPara.AddUpYearMonthSt = 0;                              // 計上年月(開始) 0:未指定
                    mTtlSlsUpdPara.AddUpYearMonthEd = 0;                              // 計上年月(終了) 0:未指定
                    mTtlSlsUpdPara.SlipRegDiv = 1;                                    // 伝票登録区分 1:登録
                    mTtlSlsUpdPara.MTtlSalesPrcFlg = 1;                               // 売上月次集計データ処理対象フラグ 1:対象
                    mTtlSlsUpdPara.GoodsMTtlSaPrcFlg = 1;                             // 商品別売上月次集計データ処理対象フラグ 1:対象

                    ArrayList newSalesSlips = new ArrayList();
                    newSalesSlips.Add(redArray);

                    ArrayList oldSalesSlips = new ArrayList();
                    oldSalesSlips.Add(originArray);

                    status = this.MonthlyTtlSalesUpdDb.Write(mTtlSlsUpdPara, newSalesSlips, oldSalesSlips, sqlConnection, sqlTransaction);
                }
                //--- ADD 2008/06/06 M.Kubota ---<<<

                //④入金マスタRedWrite関数を呼び出す (売上データ更新成功＆自動入金区分=1:自動入金の場合)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && wrkSalesSlipWork.AutoDepositCd == 1)
                {
                    //int depositWork_Posi = MakePosition(redArray, typeof(DepsitMainWork), 0);  //DEL 2009/01/28 M.Kubota
                    int depositWork_Posi = MakePosition(redArray, typeof(DepsitDataWork), 0);    //ADD 2009/01/28 M.Kubota

                    if (depositWork_Posi > -1)
                    {
                        status = this.DepositDb.RedWrite(_origin, ref originArray, ref redArray, ref retRedArray, depositWork_Posi, "", ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                    }
                }

                //⑤売上履歴RedWrite関数を呼び出す
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && wrkSalesSlipWork.AcptAnOdrStatus == 30)
                {
                    ArrayList blkSlipList = (originArray as ArrayList);
                    ArrayList redSlipList = (redArray as ArrayList);
                    status = this.SalesSlipHistDb.RedWrite(ref redSlipList, ref blkSlipList, ref sqlConnection, ref sqlTransaction);
                }

            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            //⑤在庫データWrite関数を呼び出す(在庫マスタ/製番在庫マスタ/在庫受払履歴データ/在庫受払履歴明細データ)
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = this.StockUpdDb.Write(_origin, ref originArray, ref redArray, salesSlipWork_Posi, "", ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
            }

            
            return status;
        }
        #endregion

        # region [GetLastUnitPrice] 前回商品単価取得処理
        /// <summary>
        /// 前回商品単価取得
        /// </summary>
        /// <param name="param"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int GetLastUnitPrice(ref object param, out object value)
        {
            return this.SalesSlipHistDb.GetLastUnitPrice(param, out value);
        }
        # endregion
    }
}
                   
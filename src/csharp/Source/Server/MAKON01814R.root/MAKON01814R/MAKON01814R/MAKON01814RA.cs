using System;
using System.IO;
using System.Data;
using System.Reflection;
using System.Collections;
using System.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// public class name:   IOWriteMASIRDB
    /// <summary>
    ///                      仕入エントリ更新リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>note             :   エントリ更新</br>
    /// <br>Programmer       :   20036　斉藤　雅明</br>
    /// <br>Date             :   2006/12/25</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   売上時自動受託計上処理時のWrite/RedWriteメソッド修正</br>
    /// <br>Programmer       :   20036　斉藤　雅明</br>
    /// <br>Date             :   2007/04/09</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   発注取り消し時に発注残を更新しないように修正</br>
    /// <br>Programmer       :   22008　長内 数馬</br>
    /// <br>Date             :   2009/09/30</br>
    /// <br>Update Note      :   2010/06/08 高峰 障害・改良対応（７月リリース案件）</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   送信済みのチェック方法を追加</br>
    /// <br>Programmer       :   qijh</br>
    /// <br>Date             :   2011/07/27</br>
    /// <br>Note             :   連番966 仕入明細マスタの同時売上情報をクリアする。</br>
    /// <br>Programmer       :   許雁波</br>
    /// <br>Date             :   2011/08/16</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   売上仕入同時入力で売上伝票を別々で入力し仕入伝票番号を同一で作成し、</br>
    /// <br>                     作成した売上伝票の片方を伝票削除した場合、仕入伝票が呼び出せなくなる件の修正</br>
    /// <br>Programmer       :   脇田 靖之</br>
    /// <br>Date             :   2012/11/30</br>
    /// <br>--------------------------------------</br>
    /// </remarks>
    [Serializable]
    public class IOWriteMASIRDB : RemoteWithAppLockDB, IIOWriteMASIRDB
    {
        //処理コントロール部品
        private FunctionCallControl _functionCallControl;

        private IOWriteCtrlOptWork _ctrlOptWork = null;

        /// <summary>
        /// 売上仕入制御コントロールオプション
        /// </summary>
        public IOWriteCtrlOptWork IOWriteCtrlOptWork
        {
            get
            {
                return this._ctrlOptWork;
            }
            set
            {
                if (this._ctrlOptWork != value)
                {
                    this._ctrlOptWork = value;
                }
            }
        }

        # region プライベートプロパティ
        private StockSlipDB _stockSlipDB = null;

        private StockSlipDB StockSlipDb
        {
            get
            {
                if (this._stockSlipDB == null)
                {
                    this._stockSlipDB = new StockSlipDB();
                }

                this._stockSlipDB.IOWriteCtrlOptWork = this.IOWriteCtrlOptWork;

                return this._stockSlipDB;
            }
        }

        private StockSlipHistDB _stockSlipHistDB = null;

        private StockSlipHistDB StockSlipHistDb
        {
            get
            {
                if (this._stockSlipHistDB == null)
                {
                    this._stockSlipHistDB = new StockSlipHistDB();
                }

                return this._stockSlipHistDB;
            }
        }

        private IOWriteSIRMoneyUpdateDB _moneyUpdateDB = null;

        private IOWriteSIRMoneyUpdateDB MoneyUpdateDb
        {
            get
            {
                if (this._moneyUpdateDB == null)
                {
                    this._moneyUpdateDB = new IOWriteSIRMoneyUpdateDB();
                }

                return this._moneyUpdateDB;
            }
        }

        private IOWriteMASIRStockUpdateDB _stockUpdateDB = null;

        private IOWriteMASIRStockUpdateDB StockUpdateDb
        {
            get
            {
                if (this._stockUpdateDB == null)
                {
                    //this._stockUpdateDB = new IOWriteMASIRStockUpdateDB();                  //DEL 2009/01/30
                    this._stockUpdateDB = new IOWriteMASIRStockUpdateDB(this._ctrlOptWork);  //ADD 2009/01/30
                }

                return this._stockUpdateDB;
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

        private MonthlyTtlStockUpdDB _monthlyTtlStockUpdDb = null;

        /// <summary>
        /// 仕入月次更新処理リモート プロパティ
        /// </summary>
        private MonthlyTtlStockUpdDB MonthlyTtlStockUpdDb
        {
            get
            {
                if (this._monthlyTtlStockUpdDb == null)
                {
                    this._monthlyTtlStockUpdDb = new MonthlyTtlStockUpdDB();
                }

                return this._monthlyTtlStockUpdDb;
            }
        }

        # endregion

        //プログラムID
        private string _origin = "IOWriteMASIRDB";
        //関数コールKEY
        //前
        private string _funcCallKey_BFR = "IOWriteMASIRDBBfr";
        //後
        private string _funcCallKey_AFT = "IOWriteMASIRDBAft";

        # region [Constructor]
        /// <summary>
        /// 仕入エントリ更新リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.25</br>
        /// </remarks>
        public IOWriteMASIRDB()
            : base("MAKON01816D", "Broadleaf.Application.Remoting.ParamData.IOWriteMASIRReadWork", "STOCKSLIPRF")
        {
            //●更新ファンクションコントロールクラス生成
            _functionCallControl = new FunctionCallControl(IOWriteMASIRDBServerRsc.GetResource());
        }
        # endregion

        //--- DEL 2008/06/03 M.Kubota --->>>
        #region [NewEntry] エントリ初期処理  DC.NSの段階で使用していないので削除
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

                        //--- DEL 2008/06/03 M.Kubota --->>>
                        //●暗号化キーOPEN
                        //sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, IOWriteMASIRDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.NewEntry));
                        //sqlEncryptInfo.OpenSymKey(ref sqlConnection);
                        //--- DEL 2008/06/03 M.Kubota ---<<<

                        //●入力初期処理ファンクション呼び出し
                        object freeParam = null;//仕入伝票更新では自由パラメータは利用しない
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
                        //if (sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);  //DEL 2008/06/03 M.Kubota
                        //●コネクション破棄
                        if (sqlConnection != null) sqlConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "IOWriteMASIRDB.NewEntry Exception=" + ex.Message);
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

            //①仕入NewEntry関数を呼び出す
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                StockSlipDB stockSlipDB = new StockSlipDB();
                int stockSlipNewEntryWork_Posi = MakePosition(paramArray, typeof(StockSlipNewEntryWork), 0);
                status = stockSlipDB.NewEntry(_origin, ref paramArray, ref retArray, stockSlipNewEntryWork_Posi, ""/*構成ﾌｧｲﾙﾊﾟﾗﾒｰﾀ無し*/, ref freeParam, ref sqlConnection);
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
            //仕入IOWriteNewEntryパラメータから仕入伝票パラメータを生成
            foreach (object obj in paramArray)
            {
                if (obj is IOWriteMASIRNewEntryWork)
                {
                    //伝票NewEntryパラメータを生成
                    StockSlipNewEntryWork stockSlipNewEntryWork = new StockSlipNewEntryWork();
                    stockSlipNewEntryWork.EnterpriseCode = ((IOWriteMASIRNewEntryWork)obj).EnterpriseCode;
                    stockSlipNewEntryWork.SupplierFormal = ((IOWriteMASIRNewEntryWork)obj).SupplierFormal;
                    stockSlipNewEntryWork.SupplierSlipNo = ((IOWriteMASIRNewEntryWork)obj).SupplierSlipNo;
                    paramArray.Add(stockSlipNewEntryWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    break;
                }
            }
            return status;
        }
#endif
        #endregion
        //--- DEL 2008/06/03 M.Kubota ---<<<

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
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(errmsg, status);
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
                        //sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, IOWriteMASIRDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Read));
                        //sqlEncryptInfo.OpenSymKey(ref sqlConnection);
                        
                        //呼び出しパラメータ設定
                        object freeParam = null;//仕入伝票Readでは自由パラメータは利用しない
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
                        //if (sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);  //DEL 2008/06/03 M.Kubota
                        //●コネクション破棄
                        if (sqlConnection != null) sqlConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
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
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●Read用主軸パラメータ生成
                status = MakeReadFunctionParam(ref paramArray);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;

                //呼び出しパラメータ設定
                object freeParam = null;//仕入伝票Readでは自由パラメータは利用しない
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
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
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

            //①仕入Read関数を呼び出す
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                int stockSlipReadWork_Posi = MakePosition(paramArray, typeof(StockSlipReadWork), 0);

                if (stockSlipReadWork_Posi > -1)
                {
                    StockSlipReadWork stockSlipReadWork = paramArray[stockSlipReadWork_Posi] as StockSlipReadWork;
                    status = this.StockSlipDb.Read(_origin, ref paramArray, ref retArray, stockSlipReadWork_Posi, ""/*構成ﾌｧｲﾙﾊﾟﾗﾒｰﾀ無し*/, ref freeParam, ref sqlConnection);
                    paramArray.Remove(stockSlipReadWork);
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
            }

            //②支払Read関数を呼び出す
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                int stockSlip_Posi = MakePosition(retArray, typeof(StockSlipWork), 0);

                if (stockSlip_Posi > -1)
                {
                    StockSlipWork stockSlipWork = retArray[stockSlip_Posi] as StockSlipWork;

                    // 読み込んだ仕入データの自動入金区分が 1:自動支払 の場合にのみ支払データを読み込む
                    if (stockSlipWork != null && stockSlipWork.AutoPayment == 1)
                    {
                        status = this.MoneyUpdateDb.ReadFromStockSlip(_origin, ref retArray, ref sqlConnection);
                    }
                }
            }

            //③在庫Read関数を呼び出す
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                int stockSlipReadWork_Posi = 0;  // ← 在庫マスタリモートでは使われていない
                status = this.StockUpdateDb.Read(_origin, ref paramArray, ref retArray, stockSlipReadWork_Posi, ""/*構成ﾌｧｲﾙﾊﾟﾗﾒｰﾀ無し*/, ref freeParam, ref sqlConnection);
            }
            
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
            //とりあえず仕入ヘッダワークを仕入伝票パラメータとして生成する
            //仕入以外の処理が追加されたらRead用パラメータクラスを生成する
            foreach (object obj in paramArray)
            {
                if (obj is IOWriteMASIRReadWork)
                {
                    //Readパラメータを生成
                    //Readパラメータは他処理の検索キー全てとする
                    StockSlipReadWork stockSlipReadWork = new StockSlipReadWork();
                    stockSlipReadWork.EnterpriseCode = ((IOWriteMASIRReadWork)obj).EnterpriseCode;
                    stockSlipReadWork.SupplierFormal = ((IOWriteMASIRReadWork)obj).SupplierFormal;
                    stockSlipReadWork.SupplierSlipNo = ((IOWriteMASIRReadWork)obj).SupplierSlipNo;
                    stockSlipReadWork.DebitNoteDiv = ((IOWriteMASIRReadWork)obj).DebitNoteDiv;
                    stockSlipReadWork.StockGoodsCd = ((IOWriteMASIRReadWork)obj).StockGoodsCd;
                    stockSlipReadWork.StockAgentCode = ((IOWriteMASIRReadWork)obj).StockAgentCode;
                    stockSlipReadWork.PartySaleSlipNum = ((IOWriteMASIRReadWork)obj).PartySaleSlipNum;
                    stockSlipReadWork.StockSectionCd = ((IOWriteMASIRReadWork)obj).StockSectionCd;
                    stockSlipReadWork.CarrierEpCodeStart = ((IOWriteMASIRReadWork)obj).CarrierEpCodeStart;
                    stockSlipReadWork.CarrierEpCodeEnd = ((IOWriteMASIRReadWork)obj).CarrierEpCodeEnd;
                    stockSlipReadWork.CustomerCodeStart = ((IOWriteMASIRReadWork)obj).CustomerCodeStart;
                    stockSlipReadWork.CustomerCodeEnd = ((IOWriteMASIRReadWork)obj).CustomerCodeEnd;
                    stockSlipReadWork.WarehouseCodeStart = ((IOWriteMASIRReadWork)obj).WarehouseCodeStart;
                    stockSlipReadWork.WarehouseCodeEnd = ((IOWriteMASIRReadWork)obj).WarehouseCodeEnd;
                    stockSlipReadWork.StockDateStart = ((IOWriteMASIRReadWork)obj).StockDateStart;
                    stockSlipReadWork.StockDateEnd = ((IOWriteMASIRReadWork)obj).StockDateEnd;
                    stockSlipReadWork.StockAddUpADateStart = ((IOWriteMASIRReadWork)obj).StockAddUpADateStart;
                    stockSlipReadWork.StockAddUpADateEnd = ((IOWriteMASIRReadWork)obj).StockAddUpADateEnd;
                    stockSlipReadWork.GoodsCode = ((IOWriteMASIRReadWork)obj).GoodsCode;
                    stockSlipReadWork.StockTelNo1Start = ((IOWriteMASIRReadWork)obj).StockTelNo1Start;
                    stockSlipReadWork.StockTelNo1End = ((IOWriteMASIRReadWork)obj).StockTelNo1End;
                    stockSlipReadWork.ProductNumber1Start = ((IOWriteMASIRReadWork)obj).ProductNumber1Start;
                    stockSlipReadWork.ProductNumber1End = ((IOWriteMASIRReadWork)obj).ProductNumber1End;
                    paramArray.Add(stockSlipReadWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    break;
                }
            }

            return status;
        }
        #endregion

        #region [Write]　エントリ書込
        //--- DEL 2008/06/03 M.Kubota --->>>
        #region [仕入データの登録は IOWriteControlDB のメソッドを使用する為、一時的に削除する]
#if false
        /// <summary>
        /// エントリ情報書き込み
        /// </summary>
        /// <param name="paraList">書き込み対象オブジェクトリスト</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <returns>STATUS</returns>
        public int Write(ref object paraList, out string retMsg, out string retItemInfo)  //DEL 2008/06/03 M.Kubota
        {
            //●STATUS初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = "";
            retItemInfo = "";
            CustomSerializeArrayList paramArray_BackUp = null;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            //仕入伝票パラメータファイル
            //StockSlipWork excStockSlipWork = null;               //DEL 2008/06/03 M.Kubota
            //ControlExclusiveOrderAccess ctrlExclsvOdAcs = null;  //DEL 2008/06/03 M.Kubota

            CustomSerializeArrayList originArray = new CustomSerializeArrayList();

            try
            {
                //●パラメータチェック
                CustomSerializeArrayList paramArray = paraList as CustomSerializeArrayList;
                if (paramArray == null || paramArray.Count <= 0)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●パラメータバックアップ
                paramArray_BackUp = new CustomSerializeArrayList();
                paramArray_BackUp.AddRange(paramArray);

                //--- DEL 2008/06/03 M.Kubota --->>>
                //●排他Lock
                //ctrlExclsvOdAcs = new ControlExclusiveOrderAccess();
                //excStockSlipWork = MakeParameter(paramArray, typeof(StockSlipWork), 0) as StockSlipWork;

                //if (excStockSlipWork != null && excStockSlipWork.SupplierFormal != 2)
                //{
                //    status = ControlExclusiveProc(0, ref ctrlExclsvOdAcs, ref excStockSlipWork, ref retMsg);
                //}
                //else
                //{
                //    // 仕入データがNULL、又は仕入形式が 2:発注 の場合は排他ロックを行わない。
                //    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //}
                //--- DEL 2008/06/03 M.Kubota ---<<<

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;  //ADD 2008/06/03 M.Kubota
                
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
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
                            sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, IOWriteMASIRDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Write));
                            sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                            //●トランザクション開始
                            //using (sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default))  //DEL 2008/09/11 M.Kubota
                            using (sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted))
                            {
                                try
                                {
                                    //●更新準備ファンクション呼び出し
                                    object freeParam = null;//仕入伝票更新では自由パラメータは利用しない

                                    #region 書き込み準備
                                    //●WriteInitial前オプションファンクション呼び出し
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.WriteInitial(_origin, _funcCallKey_BFR, ref originArray, ref paramArray, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                                    //●IOWrite WriteInitial処理メイン
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = IOWriteMASIRFunctionProcWriteInitial(ref originArray, ref paramArray, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                                    //●WriteInitial後オプションファンクション呼び出し
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.WriteInitial(_origin, _funcCallKey_AFT, ref originArray, ref paramArray, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                                    #endregion

                                    #region Initial処理が上手くいったら実Write
                                    //●Write前オプションファンクション呼び出し
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.Write(_origin, _funcCallKey_BFR, ref originArray, ref paramArray, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                                    //●IOWrite Write処理メイン
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = IOWriteMASIRFunctionProcWrite(ref originArray, ref paramArray, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                                    //●Write後オプションファンクション呼び出し
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.Write(_origin, _funcCallKey_AFT, ref originArray, ref paramArray, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                                    #endregion

                                    /*--- DEL 2007/09/11 M.Kubota --->>>
                                    //●特別処理　製番在庫重複データもあれば戻す
                                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        for (int i = 0; i < paramArray.Count; i++)
                                        {
                                            if (paramArray[i] is ArrayList && ((ArrayList)paramArray[i]).Count > 0 && ((ArrayList)paramArray[i])[0] is ProductStockCommonPara)
                                            {
                                                paramArray_BackUp.Add((ArrayList)paramArray[i]);
                                            }
                                        }
                                    }
                                      --- DEL 2007/09/11 M.Kubota ---<<<*/

                                    //●戻り値を設定
                                    paraList = (object)paramArray;
                                }
                                //●例外処理
                                catch (SqlException ex)
                                {
                                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                                    status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                                }
                                catch (Exception ex)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                                    base.WriteErrorLog(ex, errmsg, status);
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
                            if (sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);  //DEL 2008/06/03 M.Kubota
                            //●コネクション破棄
                            if (sqlConnection != null) sqlConnection.Close();
                        }
                    }
                }
            }
            //●例外処理
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                //--- DEL 2008/06/03 M.Kubota --->>>
                //if (excStockSlipWork != null && excStockSlipWork.SupplierFormal != 2)
                //{
                //    //●排他Lock破棄
                //    ControlExclusiveProc(1, ref ctrlExclsvOdAcs, ref excStockSlipWork, ref retMsg);
                //}
                //--- DEL 2008/06/03 M.Kubota ---<<<

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

            //仕入伝票パラメータファイル
            //StockSlipWork excStockSlipWork = null;
            // Del 2007.04.06 Saitoh >>>>>>>>>>　※売上更新リモーティングから呼び出されるため
            //ControlExclusiveOrderAccess ctrlExclsvOdAcs = null;
            // Del 2007.04.06 Saitoh <<<<<<<<<<

            CustomSerializeArrayList originArray = new CustomSerializeArrayList();

            try
            {
                //●パラメータチェック
                if (paramArray == null || paramArray.Count <= 0)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●パラメータバックアップ
                paramArray_BackUp = new CustomSerializeArrayList();
                paramArray_BackUp.AddRange(paramArray);

                // Del 2007.04.06 Saitoh >>>>>>>>>>　※売上更新リモーティングから呼び出されるため
                //●排他Lock
                //ctrlExclsvOdAcs = new ControlExclusiveOrderAccess();
                //excStockSlipWork = MakeParameter(paramArray, typeof(StockSlipWork), 0) as StockSlipWork;
                //status = ControlExclusiveProc(0, ref ctrlExclsvOdAcs, ref excStockSlipWork, ref retMsg);
                // Del 2007.04.06 Saitoh <<<<<<<<<<

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //●更新準備ファンクション呼び出し
                    object freeParam = null;//仕入伝票更新では自由パラメータは利用しない

                    #region 書き込み準備
                    //●WriteInitial前オプションファンクション呼び出し
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.WriteInitial(_origin, _funcCallKey_BFR, ref originArray, ref paramArray, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                    //●IOWrite WriteInitial処理メイン
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = IOWriteMASIRFunctionProcWriteInitial(ref originArray, ref paramArray, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                    //●WriteInitial後オプションファンクション呼び出し
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.WriteInitial(_origin, _funcCallKey_AFT, ref originArray, ref paramArray, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                    #endregion

                    #region Initial処理が上手くいったら実Write
                    //●Write前オプションファンクション呼び出し
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.Write(_origin, _funcCallKey_BFR, ref originArray, ref paramArray, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                    //●IOWrite Write処理メイン
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = IOWriteMASIRFunctionProcWrite(ref originArray, ref paramArray, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                    //●Write後オプションファンクション呼び出し
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.Write(_origin, _funcCallKey_AFT, ref originArray, ref paramArray, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                    #endregion
                }
            }

                //●例外処理
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                // Del 2007.04.06 Saitoh >>>>>>>>>>　※売上更新リモーティングから呼び出されるため
                //●排他Lock破棄
                //ControlExclusiveProc(1, ref ctrlExclsvOdAcs, ref excStockSlipWork, ref retMsg);
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
#endif
        #endregion
        //--- DEL 2008/06/03 M.Kubota ---<<<

        # region [IOWriteControlDB から呼び出される登録メソッド]
        /// <summary>
        /// 仕入データ登録準備処理
        /// </summary>
        /// <param name="orgslips">更新対象の元仕入データ及び仕入明細データを格納するArrayList</param>
        /// <param name="newslips">登録対象の仕入データ及び仕入明細データを格納するArrayList</param>
        /// <param name="retMsg">メッセージ(主にエラーメッセージ)</param>
        /// <param name="retItemInfo">項目情報(未使用)</param>
        /// <param name="connection">データベース接続オブジェクト</param>
        /// <param name="transaction">トランザクションオブジェクト</param>
        /// <param name="encryptinfo">暗号化オブジェクト</param>
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
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(errmsg + ": 登録対象の仕入データが設定されていません。", status);
                return status;
            }

            //●データベース接続状況チェック
            if (connection == null)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(errmsg + ": データベース接続情報が設定されていません。", status);
                return status;
            }

            if ((connection.State & ConnectionState.Open) == 0)
            {
                connection.Open();
            }

            //--- DEL 2008/06/03 M.Kubota --->>>
            ////●暗号化キーのチェック
            //if (encryptinfo == null)
            //{
            //    retMsg = "IOWriteMASIRDB.WriteInitialize: 暗号化キー情報が設定されていません。";
            //    base.WriteErrorLog(retMsg);
            //    return status;
            //}
            //--- DEL 2008/06/03 M.Kubota ---<<<

            //●トランザクションのチェック
            if (transaction == null)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(errmsg + ": トランザクション情報が設定されていません。", status);
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
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = IOWriteMASIRFunctionProcWriteInitial(ref orgSlips, ref cstSlips, ref freeparam, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

                //●WriteInitial後オプションファンクション呼び出し
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.WriteInitial(_origin, _funcCallKey_AFT, ref orgSlips, ref cstSlips, ref freeparam, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

                // 登録準備処理の結果を呼び出し元に返す
                newslips.Clear();
                newslips.AddRange(cstSlips);

                orgslips.AddRange(orgSlips);
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }

            return status;
        }

        /// <summary>
        /// 仕入データ登録処理
        /// </summary>
        /// <param name="orgslips">登録対象の元仕入データ及び元仕入明細データを格納するArrayList</param>
        /// <param name="newslips">登録対象の仕入データ及び仕入明細データを格納するArrayList</param>
        /// <param name="retMsg">メッセージ(主にエラーメッセージ)</param>
        /// <param name="retItemInfo">項目情報(未使用)</param>
        /// <param name="connection">データベース接続オブジェクト</param>
        /// <param name="transaction">トランザクションオブジェクト</param>
        /// <param name="encryptinfo">暗号化オブジェクト</param>
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
                retMsg = ": 登録対象の仕入データが設定されていません。";
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(errmsg + retMsg, status);
                return status;
            }

            //●データベース接続状況チェック
            if (connection == null)
            {
                retMsg = ": データベース接続情報が設定されていません。";
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(errmsg + retMsg, status);
                return status;
            }

            if ((connection.State & ConnectionState.Open) == 0)
            {
                connection.Open();
            }

            //●暗号化キーのチェック
            //if (encryptinfo == null)
            //{
            //    retMsg = ": 暗号化キー情報が設定されていません。";
            //    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
            //    base.WriteErrorLog(errmsg + retMsg, status);
            //    return status;
            //}

            //●トランザクションのチェック
            if (transaction == null)
            {
                retMsg = ": トランザクション情報が設定されていません。";
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(errmsg + retMsg, status);
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
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = IOWriteMASIRFunctionProcWrite(ref orgSlips, ref cstSlips, ref freeparam, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

                //●Write後オプションファンクション呼び出し
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = _functionCallControl.Write(_origin, _funcCallKey_AFT, ref orgSlips, ref cstSlips, ref freeparam, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

                // 登録準備処理の結果を呼び出し元に返す
                newslips.Clear();
                newslips.AddRange(cstSlips);
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }

            return status;
        }
        # endregion

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
        /// <returns>STATUS</returns>
        private Int32 IOWriteMASIRFunctionProcWriteInitial(ref CustomSerializeArrayList originArray, ref CustomSerializeArrayList paramArray, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = "";
            retItemInfo = "";

            int stockSlipWork_Posi = MakePosition(paramArray, typeof(StockSlipWork), 0);

            if (stockSlipWork_Posi < 0)
            {
                stockSlipWork_Posi = MakePosition(paramArray, typeof(OrderSlipWork), 0);
            }

            // ①仕入入力のWriteInitial関数を呼び出す
            if (stockSlipWork_Posi > -1)
            {
                StockSlipWork stockSlipWork = paramArray[stockSlipWork_Posi] as StockSlipWork;
                status = this.StockSlipDb.WriteInitial(_origin, ref originArray, ref paramArray, stockSlipWork_Posi, ""/*構成ﾌｧｲﾙﾊﾟﾗﾒｰﾀ無し*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                // ②支払伝票マスタWriteInitial関数を呼び出す (自動支払区分が 1 の場合)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && stockSlipWork.AutoPayment == 1)
                {
                    int paymentWork_Posi = MakePosition(paramArray, typeof(PaymentDataWork), 0);

                    if (paymentWork_Posi > -1)
                    {
                        status = this.MoneyUpdateDb.WriteInitial(_origin, ref originArray, ref paramArray, paymentWork_Posi, "", ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // 仕入伝票データの自動支払伝票番号に採番された支払伝票番号を設定する
                            stockSlipWork.AutoPaySlipNum = (paramArray[paymentWork_Posi] as PaymentDataWork).PaymentSlipNo;
                        }
                    }
                }

                // ③仕入履歴のWriteInitial関数を呼び出す (仕入形式が 0:仕入 の場合のみ)
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && stockSlipWork.SupplierFormal == 0)
                //{
                //    ArrayList workArray = (paraList as ArrayList);
                //    status = this.StockSlipHistDb.WriteInitialize(ref workArray, ref sqlConnection, ref sqlTransaction);
                //}

                // ④在庫マスタWriteInitial関数を呼び出す(在庫マスタ/在庫受払履歴データ)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    # region DELETE
                    //--- DEL 2008/03/13 M.Kubota --->>>
                    //bool stockUpdateFlg = true;

                    //if (stockSlipWork.SupplierFormal == 2 && stockSlipWork.SupplierSlipNo == 0)
                    //{
                    //    // 発注入力からの場合は在庫更新は行わない
                    //    stockUpdateFlg = false;
                    //}

                    //if (stockUpdateFlg)
                    //{
                    //    IOWriteMASIRStockUpdateDB stockUpdateDB = new IOWriteMASIRStockUpdateDB();
                    //    status = stockUpdateDB.WriteInitial(_origin, ref originArray, ref paraList, stockSlipWork_Posi, ""/*構成ﾌｧｲﾙﾊﾟﾗﾒｰﾀ無し*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                    //}
                    //--- DEL 2008/03/13 M.Kubota ---<<<
                    # endregion

                    if (!(stockSlipWork is OrderSlipWork))  //ADD 2009/01/08 M.Kubota (発注データ(明細のみ)を登録際は在庫更新しない)
                    {
                        status = this.StockUpdateDb.WriteInitial(_origin, ref originArray, ref paramArray, stockSlipWork_Posi, ""/*構成ﾌｧｲﾙﾊﾟﾗﾒｰﾀ無し*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                    }
                }
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
        private Int32 IOWriteMASIRFunctionProcWrite(ref CustomSerializeArrayList originArray, ref CustomSerializeArrayList paramArray, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = "";
            retItemInfo = "";

            // パラメータインデックスの取得
            int stockSlipWork_Posi = MakePosition(paramArray, typeof(StockSlipWork), 0);

            if (stockSlipWork_Posi < 0)
            {
                stockSlipWork_Posi = MakePosition(paramArray, typeof(OrderSlipWork), 0);
            }

            StockSlipWork wrkStockSlipWork = paramArray[stockSlipWork_Posi] as StockSlipWork;

            if (stockSlipWork_Posi > -1)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                // 仕入入力Write関数を呼び出す
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = this.StockSlipDb.Write(_origin, ref originArray, ref paramArray, stockSlipWork_Posi, ""/*構成ﾌｧｲﾙﾊﾟﾗﾒｰﾀ無し*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                    // 仕入履歴のWrite関数を呼び出す
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && wrkStockSlipWork.SupplierFormal == 0)
                    {
                        ArrayList workArray = (paramArray as ArrayList);
                        status = this.StockSlipHistDb.WriteInitialize(ref workArray, ref sqlConnection, ref sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            status = this.StockSlipHistDb.Write(ref workArray, ref sqlConnection, ref sqlTransaction);
                        }
                    }
                }

                int paymentWork_Posi = MakePosition(paramArray, typeof(PaymentDataWork), 0);

                // 支払伝票マスタWrite関数を呼び出す
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && wrkStockSlipWork.AutoPayment == 1 && paymentWork_Posi > -1)
                {
                    status = this.MoneyUpdateDb.Write(_origin, ref originArray, ref paramArray, paymentWork_Posi, "", ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                }

                //--- ADD 2008/06/03 M.Kubota --->>>
                // 商品マスタへの登録
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    int addListPos = -1;  // ダミー
                    status = this.GoodsUserDb.Write(ref paramArray, out addListPos, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                }
                
                // 商品価格マスタへの登録
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    int addListPos = -1;  // ダミー
                    status = this.GoodsPriceUserDb.Write(ref paramArray, out addListPos, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                }
                //--- ADD 2008/06/03 M.Kubota ---<<<

                //--- ADD 2008/12/16 M.Kubota --->>>
                // 月次集計更新処理
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 仕入月次集計データ更新パラメータ設定
                    MTtlStockUpdParaWork mTtlStcUpdPara = new MTtlStockUpdParaWork();
                    mTtlStcUpdPara.EnterpriseCode = wrkStockSlipWork.EnterpriseCode;  // 企業コード
                    mTtlStcUpdPara.StockSectionCd = wrkStockSlipWork.StockSectionCd;  // 仕入拠点コード
                    mTtlStcUpdPara.StockDateYmSt = 0;                                 // 仕入日(開始) 0:未指定
                    mTtlStcUpdPara.StockDateYmEd = 0;                                 // 仕入日(終了) 0:未指定
                    mTtlStcUpdPara.SlipRegDiv = 1;                                    // 伝票登録区分 1:登録

                    ArrayList newStockSlips = new ArrayList();
                    newStockSlips.Add(paramArray);

                    ArrayList oldStockSlips = new ArrayList();
                    oldStockSlips.Add(originArray);

                    status = this.MonthlyTtlStockUpdDb.Write(mTtlStcUpdPara, newStockSlips, oldStockSlips, sqlConnection, sqlTransaction);
                }
                //--- ADD 2008/12/16 M.Kubota ---<<<

                // 在庫データWrite関数を呼び出す(在庫更新リモートから在庫受払履歴更新リモートを呼び出す)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    # region --- DEL 2008/03/13 M.Kubota --->>>
                    //--- DEL 2008/03/13 M.Kubota --->>>
                    //bool stockUpdateFlg = true;

                    //if (stockSlipWork_Posi > -1)
                    //{
                    //    StockSlipWork stockSlipWork = paraList[stockSlipWork_Posi] as StockSlipWork;

                    //    if (stockSlipWork.SupplierFormal == 2 && stockSlipWork.SupplierSlipNo == 0)
                    //    {
                    //        // 発注入力からの場合は在庫更新は行わない
                    //        stockUpdateFlg = false;
                    //    }
                    //}

                    //if (stockUpdateFlg)
                    //{
                    //    IOWriteMASIRStockUpdateDB stockUpDB = new IOWriteMASIRStockUpdateDB();
                    //    status = stockUpDB.Write(_origin, ref originArray, ref paraList, stockSlipWork_Posi, ""/*構成ﾌｧｲﾙﾊﾟﾗﾒｰﾀ無し*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                    //}
                    //--- DEL 2008/03/13 M.Kubota ---<<<
                    # endregion --- DEL 2008/03/13 M.Kubota ---<<<

                    if (!(wrkStockSlipWork is OrderSlipWork))  //ADD 2009/01/08 M.Kubota (発注データ(明細のみ)を登録際は在庫更新しない)
                    {
                        status = this.StockUpdateDb.Write(_origin, ref originArray, ref paramArray, stockSlipWork_Posi, ""/*構成ﾌｧｲﾙﾊﾟﾗﾒｰﾀ無し*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                    }
                }
            }

            return status;
        }
        #endregion

        #region [etc] パラメータ関連処理

        //--- DEL 2008/06/03 M.Kubota --->>>
        #region [得意先排他制御マスタの削除に伴い削除]
#if false
        /// <summary>
        /// 排他コントロール
        /// </summary>
        /// <param name="mode">処理区分 0:Lock 1:UnLock</param>
        /// <param name="ctrlExclsvOdAcs">排他部品オブジェクト</param>
        /// <param name="stockSlipWork">排他設定仕入クラス</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        private int ControlExclusiveProc(int mode, ref ControlExclusiveOrderAccess ctrlExclsvOdAcs, ref StockSlipWork stockSlipWork, ref string msg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //パラメータチェック
            if (stockSlipWork == null)
            {
                msg = "プログラムエラー。仕入パラメータが未設定です";
                return status;
            }

            //排他Lockモードの場合
            if (mode == 0)
            {
                ArrayList al = new ArrayList();
                //得意先コードがあれば追加
                //if (stockSlipWork.CustomerCode > 0) al.Add(stockSlipWork.CustomerCode);

                //得意先があるもしくは仕入伝票番号/赤黒連結仕入伝票番号がある場合は排他Lock
                if (al.Count > 0 || stockSlipWork.SupplierSlipNo > 0 || stockSlipWork.DebitNLnkSuppSlipNo > 0)
                {
                    //仕入伝票番号数を計算
                    Int32 cntSupSlipNo = 0;
                    if (stockSlipWork.SupplierSlipNo > 0) cntSupSlipNo++;
                    if (stockSlipWork.DebitNLnkSuppSlipNo > 0) cntSupSlipNo++;
                    
                    //得意先・仕入伝票番号をセット
                    Int32[] customerCodeList = (Int32[])al.ToArray(typeof(Int32));
                    Int32[] supplierSlipNoList = new Int32[cntSupSlipNo];
                    //仕入伝票番号をセット
                    if (stockSlipWork.SupplierSlipNo > 0) supplierSlipNoList[0] = stockSlipWork.SupplierSlipNo;
                    //赤黒連結仕入伝票番号をセット
                    if (stockSlipWork.DebitNLnkSuppSlipNo > 0)
                    {
                        if (supplierSlipNoList[0] == 0) supplierSlipNoList[0] = stockSlipWork.DebitNLnkSuppSlipNo;
                        else supplierSlipNoList[1] = stockSlipWork.DebitNLnkSuppSlipNo;
                    }

                    status = ctrlExclsvOdAcs.LockDB(stockSlipWork.EnterpriseCode, customerCodeList, null);
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
        //--- DEL 2008/06/03 M.Kubota ---<<<
#endif
        #endregion
        //--- DEL 2008/06/03 M.Kubota ---<<<

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
        /// 仕入パラメータ取得
        /// </summary>
        /// <param name="source">パラメータ</param>
        /// <returns>StockSlipWorkオブジェクト</returns>
        private StockSlipWork MakeStockSlipWork(object source)
        {
            StockSlipWork stockSlipWork = null;
            if (source is IOWriteMASIRDeleteWork)
            {
                IOWriteMASIRDeleteWork iOWriteMASIRDeleteWork = source as IOWriteMASIRDeleteWork;

                stockSlipWork = new StockSlipWork();
                stockSlipWork.EnterpriseCode = iOWriteMASIRDeleteWork.EnterpriseCode;
                stockSlipWork.SupplierFormal = iOWriteMASIRDeleteWork.SupplierFormal;
                stockSlipWork.SupplierSlipNo = iOWriteMASIRDeleteWork.SupplierSlipNo;
                stockSlipWork.UpdateDateTime = iOWriteMASIRDeleteWork.UpdateDateTime;

            }

            return stockSlipWork;
        }
        #endregion

        #region [Delete] エントリ削除

        //--- DEL 2008/06/03 M.Kubota --->>>
        # region [仕入データの削除は IOWriteControlDC のメソッドを使用する為、一時的に削除する]
#if false        
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
                sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, IOWriteMASIRDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Delete));
                sqlEncryptInfo.OpenSymKey(ref sqlConnection);

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
                base.WriteErrorLog(ex, "IOWriteMASIRDB.Delete Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                //●暗号化キーCLOSE
                if (sqlEncryptInfo != null && sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);

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
#endif
        #endregion
        //--- DEL 2008/06/03 M.Kubota ---<<<

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

            //StockSlipWork excStockSlipWork = null;               //DEL 2008/06/03 M.Kubota
            //ControlExclusiveOrderAccess ctrlExclsvOdAcs = null;  //DEL 2008/06/03 M.Kubota
            IOWriteMASIRDeleteWork iOWriteMASIRDeleteWork = null;

            CustomSerializeArrayList originArray = new CustomSerializeArrayList();

            try
            {
                //●パラメータチェック
                if (paramArray == null || paramArray.Count <= 0)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●パラメータバックアップ
                paramArray_BackUp = new CustomSerializeArrayList();
                paramArray_BackUp.AddRange(paramArray);

                //●Delete用主軸パラメータ生成
                status = MakeDeleteFunctionParam(ref paramArray, out iOWriteMASIRDeleteWork);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //取得パラメータチェック
                    //if (iOWriteMASIRDeleteWork.EnterpriseCode == null || iOWriteMASIRDeleteWork.EnterpriseCode.Trim().Length == 0 || iOWriteMASIRDeleteWork.SupplierSlipNo == 0)
                    if (string.IsNullOrEmpty(iOWriteMASIRDeleteWork.EnterpriseCode) || (iOWriteMASIRDeleteWork.SupplierFormal != 2 && iOWriteMASIRDeleteWork.SupplierSlipNo == 0))
                    {
                        retMsg = ": パラメータに企業コードもしくは仕入伝票番号が指定されていません。";
                        string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                        base.WriteErrorLog(errmsg + retMsg, status);
                        return status;
                    }
                }
                else
                {
                    StockDetailWork dtlwork = (paramArray as ArrayList)[0] as StockDetailWork;

                    // 発注データ削除の場合でも無い場合はパラメータ未設定とする
                    if (dtlwork != null && dtlwork.SupplierFormal == 2)
                    {
                        //ステータス初期化
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        retMsg = ": パラメータが未設定です。";
                        string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                        base.WriteErrorLog(errmsg + retMsg, status);
                        return status;
                    }
                    
                    /*
                    foreach (object item in paraList)
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
                //--- DEL 2008/06/03 M.Kubota --->>>
                //if (iOWriteMASIRDeleteWork != null)
                //{
                //    //ステータス初期化
                //    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                //    ctrlExclsvOdAcs = new ControlExclusiveOrderAccess();
                //    excStockSlipWork = MakeStockSlipWork(iOWriteMASIRDeleteWork);
                    
                //    status = ControlExclusiveProc(0, ref ctrlExclsvOdAcs, ref excStockSlipWork, ref retMsg);
                //}
                //--- DEL 2008/06/03 M.Kubota ---<<<

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //●仕入伝票削除では自由パラメータは利用しない
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
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                //--- DEL 2008/06/03 M.Kubota --->>>
                //●排他Lock破棄
                //if (iOWriteMASIRDeleteWork != null)
                //{
                //    ControlExclusiveProc(1, ref ctrlExclsvOdAcs, ref excStockSlipWork, ref retMsg);
                //}
                //--- DEL 2008/06/03 M.Kubota ---<<<

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

            //①仕入DeleteInitial関数を呼び出す
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                int stockSlipWork_Posi = MakePosition(paramArray, typeof(StockSlipDeleteWork), 0);
                status = this.StockSlipDb.DeleteInitial(_origin, ref originArray, ref paramArray, stockSlipWork_Posi, ""/*構成ﾌｧｲﾙﾊﾟﾗﾒｰﾀ無し*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                //--- ADD 2007/09/11 M.Kubota --->>>
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList workArray = (paramArray as ArrayList);
                    status = this.StockSlipHistDb.DeleteInitialize(ref workArray, ref sqlConnection, ref sqlTransaction);
                }
                //--- ADD 2007/09/11 M.Kubota ---<<<
            }

            //②支払伝票マスタDeleteInitial関数を呼び出す
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                int paymentWork_Posi = MakePosition(paramArray, typeof(PaymentDataWork), 0);

                if (paymentWork_Posi > -1)
                {
                    status = this.MoneyUpdateDb.DeleteInitial(_origin, ref originArray, ref paramArray, paymentWork_Posi, "", ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                }
            }

            //③在庫データDeleteInitial関数を呼び出す(在庫マスタ/製番在庫マスタ/在庫受払履歴データ/在庫受払履歴明細データ)
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                int stockSlipWork_Posi = MakePosition( paramArray, typeof( StockSlipDeleteWork ), 0 );
                status = this.StockUpdateDb.DeleteInitial(_origin, ref originArray, ref paramArray, stockSlipWork_Posi, ""/*構成ﾌｧｲﾙﾊﾟﾗﾒｰﾀ無し*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
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

            // 仕入Delete関数を呼び出す
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                int stockSlipWork_Posi = MakePosition(paramArray, typeof(StockSlipDeleteWork), 0);
                status = this.StockSlipDb.Delete(_origin, ref originArray, ref paramArray, stockSlipWork_Posi, ""/*構成ﾌｧｲﾙﾊﾟﾗﾒｰﾀ無し*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                //--- ADD 2007/09/11 M.Kubota --->>>
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList workArray = (paramArray as ArrayList);
                    //status = this.StockSlipHistDb.Delete(ref workArray, ref sqlConnection, ref sqlTransaction);
                    status = this.StockSlipHistDb.LogicalDelete(ref workArray, ref sqlConnection, ref sqlTransaction);
                }
                //--- ADD 2007/09/11 M.Kubota ---<<<
            }

            //--- ADD 2008/12/16 M.Kubota --->>>
            // 月次集計更新処理
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                int stcSlipPos = MakePosition(originArray, typeof(StockSlipWork), 0);

                if (stcSlipPos > -1)
                {
                    StockSlipWork wrkStockSlipWork = originArray[stcSlipPos] as StockSlipWork;

                    // 仕入月次集計データ更新パラメータ設定
                    MTtlStockUpdParaWork mTtlStcUpdPara = new MTtlStockUpdParaWork();
                    mTtlStcUpdPara.EnterpriseCode = wrkStockSlipWork.EnterpriseCode;  // 企業コード
                    mTtlStcUpdPara.StockSectionCd = wrkStockSlipWork.StockSectionCd;  // 仕入拠点コード
                    mTtlStcUpdPara.StockDateYmSt = 0;                                 // 仕入日(開始) 0:未指定
                    mTtlStcUpdPara.StockDateYmEd = 0;                                 // 仕入日(終了) 0:未指定
                    mTtlStcUpdPara.SlipRegDiv = 0;                                    // 伝票登録区分 0:削除

                    ArrayList newStockSlips = new ArrayList();
                    newStockSlips.Add(paramArray);

                    ArrayList oldStockSlips = new ArrayList();
                    oldStockSlips.Add(originArray);

                    status = this.MonthlyTtlStockUpdDb.Write(mTtlStcUpdPara, newStockSlips, oldStockSlips, sqlConnection, sqlTransaction);
                }
            }
            //--- ADD 2008/12/16 M.Kubota ---<<<

            // 支払伝票マスタDelete関数を呼び出す
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                int paymentWork_Posi = MakePosition(paramArray, typeof(PaymentDataWork), 0);

                if (paymentWork_Posi > -1)
                {
                    status = this.MoneyUpdateDb.Delete(_origin, ref originArray, ref paramArray, paymentWork_Posi, "", ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                }
            }

            // 在庫データDelete関数を呼び出す(在庫マスタ/製番在庫マスタ/在庫受払履歴データ/在庫受払履歴明細データ)
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                int stockSlipWork_Posi = MakePosition( paramArray, typeof( StockSlipDeleteWork ), 0 );

                // -- UPD 2009/09/30 ---------------------------------------------------------->>>
                //status = this.StockUpdateDb.Delete(_origin, ref originArray, ref paramArray, stockSlipWork_Posi, ""/*構成ﾌｧｲﾙﾊﾟﾗﾒｰﾀ無し*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                int iOWriteMASIRDeleteWork_Posi = MakePosition(paramArray, typeof(IOWriteMASIRDeleteWork), 0);
                int odrUpdDiv = 0;

                if (iOWriteMASIRDeleteWork_Posi > -1)
                {
                    odrUpdDiv = (paramArray[iOWriteMASIRDeleteWork_Posi] as IOWriteMASIRDeleteWork).StockUpdDiv;
                }

                //送信処理からの発注取り消し時には発注残を更新させないように修正
                if (odrUpdDiv != 1)
                {
                    status = this.StockUpdateDb.Delete(_origin, ref originArray, ref paramArray, stockSlipWork_Posi, ""/*構成ﾌｧｲﾙﾊﾟﾗﾒｰﾀ無し*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                }
                // -- UPD 2009/09/30 ----------------------------------------------------------<<<

            }

            return status;
        }

        /// <summary>
        /// Delete用主軸パラメータ生成
        /// </summary>
        /// <param name="paramArray">受け取りパラメータList</param>
        /// <param name="iOWriteMASIRDeleteWork">Deleteパラメータ</param>
        /// <returns>STATUS</returns>
        private int MakeDeleteFunctionParam(ref CustomSerializeArrayList paramArray, out IOWriteMASIRDeleteWork iOWriteMASIRDeleteWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            iOWriteMASIRDeleteWork = null;
            //仕入IOWriteDeleteパラメータから仕入パラメータを生成
            foreach (object obj in paramArray)
            {
                if (obj is IOWriteMASIRDeleteWork)
                {
                    iOWriteMASIRDeleteWork = obj as IOWriteMASIRDeleteWork;
                    //Debug↓今後仕様が詰まり次第対応
                    //iOWriteMASIRDeleteWork.SupplierSlipNo = 0;
                    //iOWriteMASIRDeleteWork.SupplierFormal = 0;
                    //Debug↑

                    //仕入Delete用パラメータを生成
                    StockSlipDeleteWork stockSlipDeleteWork = new StockSlipDeleteWork();
                    stockSlipDeleteWork.EnterpriseCode = iOWriteMASIRDeleteWork.EnterpriseCode;
                    stockSlipDeleteWork.SupplierFormal = iOWriteMASIRDeleteWork.SupplierFormal;
                    stockSlipDeleteWork.SupplierSlipNo = iOWriteMASIRDeleteWork.SupplierSlipNo;
                    stockSlipDeleteWork.UpdateDateTime = iOWriteMASIRDeleteWork.UpdateDateTime;
                    stockSlipDeleteWork.DebitNoteDiv = iOWriteMASIRDeleteWork.DebitNoteDiv;
                    /*
                    stockSlipDeleteWork.PartySaleSlipNum = iOWriteMASIRDeleteWork.PartySaleSlipNum;
                    stockSlipDeleteWork.StockSectionCd = iOWriteMASIRDeleteWork.StockSectionCd;
                    stockSlipDeleteWork.StockAddUpSectionCd = iOWriteMASIRDeleteWork.StockAddUpSectionCd;
                    stockSlipDeleteWork.StockAgentCode = iOWriteMASIRDeleteWork.StockAgentCode;
                    stockSlipDeleteWork.StockAgentName = iOWriteMASIRDeleteWork.StockAgentName;
                    stockSlipDeleteWork.CustomerCode = iOWriteMASIRDeleteWork.CustomerCode;
                    stockSlipDeleteWork.CustomerName = iOWriteMASIRDeleteWork.CustomerName;
                    stockSlipDeleteWork.CustomerName2 = iOWriteMASIRDeleteWork.CustomerName2;
                    stockSlipDeleteWork.PayeeCode = iOWriteMASIRDeleteWork.PayeeCode;
                    stockSlipDeleteWork.PayeeName1 = iOWriteMASIRDeleteWork.PayeeName1;
                    stockSlipDeleteWork.Payeename2 = iOWriteMASIRDeleteWork.Payeename2;
                    stockSlipDeleteWork.InputDay = iOWriteMASIRDeleteWork.InputDay;
                    stockSlipDeleteWork.ArrivalGoodsDay = iOWriteMASIRDeleteWork.ArrivalGoodsDay;
                    stockSlipDeleteWork.StockDate = iOWriteMASIRDeleteWork.StockDate;
                    stockSlipDeleteWork.StockAddUpADate = iOWriteMASIRDeleteWork.StockAddUpADate;
                    stockSlipDeleteWork.SupplierSlipCd = iOWriteMASIRDeleteWork.SupplierSlipCd;
                    stockSlipDeleteWork.AccPayDivCd = iOWriteMASIRDeleteWork.AccPayDivCd;
                    stockSlipDeleteWork.DebitNoteDiv = iOWriteMASIRDeleteWork.DebitNoteDiv;
                    stockSlipDeleteWork.DebitNLnkSuppSlipNo = iOWriteMASIRDeleteWork.DebitNLnkSuppSlipNo;
                    stockSlipDeleteWork.StockTotalPrice = iOWriteMASIRDeleteWork.StockTotalPrice;
                    stockSlipDeleteWork.StockSubttlPrice = iOWriteMASIRDeleteWork.StockSubttlPrice;
                    //stockSlipDeleteWork.StockTtlDiscount = iOWriteMASIRDeleteWork.StockTtlDiscount;// Del 2007.03.26 Saitoh
                    //stockSlipDeleteWork.TtlItdedStockOutTax = iOWriteMASIRDeleteWork.TtlItdedStockOutTax;// Del 2007.03.26 Saitoh
                    //stockSlipDeleteWork.TtlItdedStockInTax = iOWriteMASIRDeleteWork.TtlItdedStockInTax;// Del 2007.03.26 Saitoh
                    stockSlipDeleteWork.TtlItdedStockTaxFree = iOWriteMASIRDeleteWork.TtlItdedStockTaxFree;
                    //stockSlipDeleteWork.TtlStockOuterTax = iOWriteMASIRDeleteWork.TtlStockOuterTax;// Del 2007.03.26 Saitoh
                    //stockSlipDeleteWork.TtlStockInnerTax = iOWriteMASIRDeleteWork.TtlStockInnerTax;// Del 2007.03.26 Saitoh
                    stockSlipDeleteWork.SuppCTaxLayCd = iOWriteMASIRDeleteWork.SuppCTaxLayCd;
                    stockSlipDeleteWork.SupplierConsTaxRate = iOWriteMASIRDeleteWork.SupplierConsTaxRate;
                    stockSlipDeleteWork.StockFractionProcCd = iOWriteMASIRDeleteWork.StockFractionProcCd;
                    stockSlipDeleteWork.CarrierEpCode = iOWriteMASIRDeleteWork.CarrierEpCode;
                    stockSlipDeleteWork.CarrierEpName = iOWriteMASIRDeleteWork.CarrierEpName;
                    stockSlipDeleteWork.WarehouseCode = iOWriteMASIRDeleteWork.WarehouseCode;
                    stockSlipDeleteWork.WarehouseName = iOWriteMASIRDeleteWork.WarehouseName;
                    stockSlipDeleteWork.StockGoodsCd = iOWriteMASIRDeleteWork.StockGoodsCd;
                    stockSlipDeleteWork.TaxAdjust = iOWriteMASIRDeleteWork.TaxAdjust;
                    stockSlipDeleteWork.BalanceAdjust = iOWriteMASIRDeleteWork.BalanceAdjust;
                    stockSlipDeleteWork.TrustAddUpSpCd = iOWriteMASIRDeleteWork.TrustAddUpSpCd;
                    */
                    paramArray.Add(stockSlipDeleteWork);

                    /*
                    //伝票Deleteパラメータを生成(伝票ワーククラス)
                    RpSlipDeleteWork rpSlipDeleteWork = new RpSlipDeleteWork();
                    rpSlipDeleteWork.EnterpriseCode = stockSlipWork.EnterpriseCode;
                    rpSlipDeleteWork.StandardAcceptAnOrderNo = stockSlipWork.StandardAcceptAnOrderNo;
                    if (stockSlipWork.RpSlipNo != null && stockSlipWork.RpSlipNo != "")
                    {
                        rpSlipDeleteWork.RpSlipKindCdList = new Int32[1];
                        rpSlipDeleteWork.RpSlipNoList = new string[1];
                        rpSlipDeleteWork.RpSlipKindCdList[0] = stockSlipWork.RpSlipKindCd;
                        rpSlipDeleteWork.RpSlipNoList[0] = stockSlipWork.RpSlipNo;
                    }
                    //全伝票削除の場合、伝票番号パラメータ無し（整備伝票ROにて追加）
                    else
                    {
                        rpSlipDeleteWork.RpSlipKindCdList = new Int32[0];
                        rpSlipDeleteWork.RpSlipNoList = new string[0];
                    }
                    paraList.Add(rpSlipDeleteWork);

                    //金額更新用Deleteパラメータを生成
                    IOWriteMoneyDeleteParamWork iOWriteMoneyDeleteParamWork = new IOWriteMoneyDeleteParamWork();
                    iOWriteMoneyDeleteParamWork.DepsitAlwCheckFlag = stockSlipWork.DepsitAlwCheckFlag;
                    paraList.Add(iOWriteMoneyDeleteParamWork);
                    */

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    break;
                }
            }
            return status;
        }
        #endregion

        #region [RedWrite] 赤伝作成処理

        //--- DEL 2008/06/03 M.Kubota --->>>
        #region [仕入データの赤伝は IOWriterControlDB のメソッドを使用する為、一時的に削除する]
#if false
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
            StockSlipWork excStockSlipWork = null;
            ControlExclusiveOrderAccess ctrlExclsvOdAcs = null;
            try
            {
                //●パラメータチェック
                CustomSerializeArrayList originArray = originList as CustomSerializeArrayList;
                if (originArray == null || originArray.Count <= 0)
                {
                    retMsg = ": 元黒伝票パラメータが未設定です。";
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(errmsg + retMsg, status);
                    return status;
                }
                CustomSerializeArrayList redArray = redList as CustomSerializeArrayList;
                if (redArray == null || redArray.Count <= 0)
                {
                    retMsg = ": 赤伝票パラメータが未設定です。";
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(errmsg + retMsg, status);
                    return status;
                }

                //●パラメータバックアップ
                originArray_BackUp = new CustomSerializeArrayList();
                originArray_BackUp.AddRange(originArray);
                redArray_BackUp = new CustomSerializeArrayList();
                redArray_BackUp.AddRange(redArray);

                //--- DEL 2008/06/03 M.Kubota --->>>
                //●排他Lock
                //ctrlExclsvOdAcs = new ControlExclusiveOrderAccess();
                //excStockSlipWork = MakeParameter(originArray, typeof(StockSlipWork), 0) as StockSlipWork;
                //status = ControlExclusiveProc(0, ref ctrlExclsvOdAcs, ref excStockSlipWork, ref retMsg);
                //--- DEL 2008/06/03 M.Kubota ---<<<

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

                            //--- DEL 2008/06/03 M.Kubota --->>>
                            //●暗号化キーOPEN
                            //sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, IOWriteMASIRDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.RedWrite));
                            //sqlEncryptInfo.OpenSymKey(ref sqlConnection);
                            //--- DEL 2008/06/03 M.Kubota ---<<<

                            //●トランザクション開始
                            using (sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default))
                            {
                                try
                                {
                                    //●仕入伝票赤伝作成では自由パラメータは利用しない
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
                                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                                    status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                                }
                                catch (Exception ex)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                                    base.WriteErrorLog(ex, errmsg, status);
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
                            //if (sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);  //DEL 2008/06/03 M.Kubota
                            //●コネクション破棄
                            if (sqlConnection != null) sqlConnection.Close();
                        }
                    }
                }
            }
            //●例外処理
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                //●排他Lock破棄
                //ControlExclusiveProc(1, ref ctrlExclsvOdAcs, ref excStockSlipWork, ref retMsg);  //DEL 2008/06/03 M.Kubota

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
#endif
        #endregion
        //--- DEL 2008/06/03 M.Kubota ---<<<

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

            StockSlipWork excStockSlipWork = null;
            try
            {
                //●パラメータチェック
                if (originList == null || originList.Count <= 0)
                {
                    retMsg = ": 元黒伝票パラメータが未設定です。";
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(errmsg + retMsg, status);
                    return status;
                }

                if (redList == null || redList.Count <= 0)
                {
                    retMsg = ": 赤伝票パラメータが未設定です。";
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(errmsg + retMsg, status);
                    return status;
                }

                //●パラメータバックアップ
                originArray_BackUp = new CustomSerializeArrayList();
                originArray_BackUp.AddRange(originList);
                redArray_BackUp = new CustomSerializeArrayList();
                redArray_BackUp.AddRange(redList);

                excStockSlipWork = MakeParameter(originList, typeof(StockSlipWork), 0) as StockSlipWork;
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //●仕入伝票赤伝作成では自由パラメータは利用しない
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
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
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
        /// <returns>STATUS</returns>
        private Int32 IOWriteMASIRFunctionProcRedWriteInitial(ref CustomSerializeArrayList originArray, ref CustomSerializeArrayList redArray, ref CustomSerializeArrayList retRedArray, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retMsg = "";
            retItemInfo = "";

            //①仕入RedWriteInitial関数を呼び出す
            int stockSlipWork_Posi = MakePosition(redArray, typeof(StockSlipWork), 0);
            status = this.StockSlipDb.RedWriteInitial(_origin, ref originArray, ref redArray, ref retRedArray, stockSlipWork_Posi, ""/*構成ﾌｧｲﾙﾊﾟﾗﾒｰﾀ無し*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

            StockSlipWork redStockSlipWork = redArray[stockSlipWork_Posi] as StockSlipWork;

            //②支払伝票マスタRedWriteInitial関数を呼び出す
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && redStockSlipWork.AutoPayment == 1)
            {
                int paymentWork_Posi = MakePosition(redArray, typeof(PaymentDataWork), 0);  // 赤伝用データリストから仕入支払オブジェクトを取得する

                if (paymentWork_Posi > -1)
                {
                    status = this.MoneyUpdateDb.RedWriteInitial(_origin, ref originArray, ref redArray, ref retRedArray, paymentWork_Posi, "", ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        redStockSlipWork.AutoPaySlipNum = (redArray[paymentWork_Posi] as PaymentDataWork).PaymentSlipNo;
                    }
                }
            }

            //③在庫データWriteInitial関数を呼び出す(在庫マスタ/製番在庫マスタ/在庫受払履歴データ)
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = this.StockUpdateDb.WriteInitial(_origin, ref originArray, ref redArray, stockSlipWork_Posi, ""/*構成ﾌｧｲﾙﾊﾟﾗﾒｰﾀ無し*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
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
        /// <returns>STATUS</returns>
        private Int32 IOWriteMASIRFunctionProcRedWrite(ref CustomSerializeArrayList originArray, ref CustomSerializeArrayList redArray, ref CustomSerializeArrayList retRedArray, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retMsg = "";
            retItemInfo = "";

            // パラメータインデックスの取得
            int stockSlipWork_Posi = MakePosition(redArray, typeof(StockSlipWork), 0);

            if (stockSlipWork_Posi > -1)
            {
                StockSlipWork wrkStockSlipWork = redArray[stockSlipWork_Posi] as StockSlipWork;

                // 仕入RedWrite関数を呼び出す
                status = this.StockSlipDb.RedWrite(_origin, ref originArray, ref redArray, ref retRedArray, stockSlipWork_Posi, ""/*構成ﾌｧｲﾙﾊﾟﾗﾒｰﾀ無し*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                    
                // 仕入履歴RedWrite関数を呼び出す
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList blkSlipList = (originArray as ArrayList);
                    ArrayList redSlipList = (redArray as ArrayList);
                    status = this.StockSlipHistDb.RedWrite(ref redSlipList, ref blkSlipList, ref sqlConnection, ref sqlTransaction);
                }

                int paymentWork_Posi = MakePosition(redArray, typeof(PaymentDataWork), 0);

                // 支払伝票マスタRedWrite関数を呼び出す
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && wrkStockSlipWork.AutoPayment == 1 && paymentWork_Posi > -1)
                {
                    status = this.MoneyUpdateDb.RedWrite(_origin, ref originArray, ref redArray, ref retRedArray, paymentWork_Posi, "", ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                }

                //--- ADD 2008/12/16 M.Kubota --->>>
                // 月次集計更新処理
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 仕入月次集計データ更新パラメータ設定
                    MTtlStockUpdParaWork mTtlStcUpdPara = new MTtlStockUpdParaWork();
                    mTtlStcUpdPara.EnterpriseCode = wrkStockSlipWork.EnterpriseCode;  // 企業コード
                    mTtlStcUpdPara.StockSectionCd = wrkStockSlipWork.StockSectionCd;  // 仕入拠点コード
                    mTtlStcUpdPara.StockDateYmSt = 0;                                 // 仕入日(開始) 0:未指定
                    mTtlStcUpdPara.StockDateYmEd = 0;                                 // 仕入日(終了) 0:未指定
                    mTtlStcUpdPara.SlipRegDiv = 1;                                    // 伝票登録区分 1:登録

                    ArrayList newStockSlips = new ArrayList();
                    newStockSlips.Add(redArray);

                    ArrayList oldStockSlips = new ArrayList();
                    oldStockSlips.Add(originArray);

                    status = this.MonthlyTtlStockUpdDb.Write(mTtlStcUpdPara, newStockSlips, oldStockSlips, sqlConnection, sqlTransaction);
                }
                //--- ADD 2008/12/16 M.Kubota ---<<<

                // 在庫データWrite関数を呼び出す(在庫マスタ/製番在庫マスタ/在庫受払履歴データ/在庫受払履歴明細データ)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = this.StockUpdateDb.Write(_origin, ref originArray, ref redArray, stockSlipWork_Posi, ""/*構成ﾌｧｲﾙﾊﾟﾗﾒｰﾀ無し*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                }
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion

        # region [発注入力用メソッド]

        /// <summary>
        /// 発注入力用 追加・更新処理
        /// </summary>
        /// <param name="paraList">更新情報オブジェクトリスト</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <returns>STATUS</returns>
        public int WriteforOrderInput(ref object paraList, out string retMsg, out string retItemInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = "";
            retItemInfo = "";

            SqlConnection sqlConnection = this.CreateSqlConnection(true);
            SqlTransaction sqlTransaction = this.CreateTransaction(ref sqlConnection);
            SqlEncryptInfo sqlEncryptInfo = null;
            //SqlEncryptInfo sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, IOWriteMASIRDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Write));  //保留
            //sqlEncryptInfo.OpenSymKey(ref sqlConnection);

            ArrayList OdrDtlList = paraList as ArrayList;

            try
            {
                status = this.WriteforOrderInput(ref OdrDtlList, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            sqlTransaction.Rollback();
                        }
                    }
                    sqlTransaction.Dispose();
                }

                if (sqlEncryptInfo != null && sqlEncryptInfo.IsOpen)
                {
                    sqlEncryptInfo.CloseSymKey(ref sqlConnection);
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }


            return status;
        }

        /// <summary>
        /// 発注入力用 追加・更新処理
        /// </summary>
        /// <param name="paraList"></param>
        /// <param name="retMsg"></param>
        /// <param name="retItemInfo"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <param name="sqlEncryptInfo"></param>
        /// <returns></returns>
        public int WriteforOrderInput(ref ArrayList paraList, out string retMsg, out string retItemInfo,
                                      ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = "";
            retItemInfo = "";

            StockSlipWork dummySlip = null;

            if (ListUtils.IsNotEmpty(paraList) && paraList[0] is StockDetailWork)
            {
                StockDetailWork baseInfo = (paraList as ArrayList)[0] as StockDetailWork;

                dummySlip = new OrderSlipWork();

                // ダミー仕入データに必要な項目を設定する
                dummySlip.EnterpriseCode = baseInfo.EnterpriseCode;  // 企業コード
                dummySlip.SupplierFormal = 2;                        // 仕入形式 = 2:発注      固定
                dummySlip.SupplierSlipCd = 10;                       // 仕入伝票区分 = 10:仕入 固定
                dummySlip.SectionCode = baseInfo.SectionCode;        // 拠点コード
                dummySlip.SubSectionCode = baseInfo.SubSectionCode;  // 部門コード
            }

            if (dummySlip != null)
            {
                ArrayList paramArray = new CustomSerializeArrayList();

                paramArray.Add(dummySlip);
                paramArray.Add(paraList);

                // 発注データ(仕入データ)書込み処理を行う
                ArrayList orgArray = null;

                status = this.WriteInitialize(out orgArray, ref paramArray, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = this.WriteA(orgArray, ref paramArray, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                }
            }

            return status;
        }


        /// <summary>
        /// 発注入力用 削除処理
        /// </summary>
        /// <param name="paraList">物理削除情報オブジェクトリスト</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <returns>STATUS</returns>
        public int DeleteforOrderInput(ref object paraList, out string retMsg, out string retItemInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = "";
            retItemInfo = "";

            SqlConnection sqlConnection = this.CreateSqlConnection(true);
            SqlTransaction sqlTransaction = this.CreateTransaction(ref sqlConnection);
            SqlEncryptInfo sqlEncryptInfo = null;
            //SqlEncryptInfo sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, IOWriteMASIRDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Delete));
            //sqlEncryptInfo.OpenSymKey(ref sqlConnection);

            ArrayList OdrDtlList = paraList as ArrayList;

            try
            {
                status = this.DeleteforOrderInput(ref OdrDtlList, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            sqlTransaction.Rollback();
                        }
                    }
                    sqlTransaction.Dispose();
                }

                if (sqlEncryptInfo != null && sqlEncryptInfo.IsOpen)
                {
                    sqlEncryptInfo.CloseSymKey(ref sqlConnection);
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 発注入力用 削除処理
        /// </summary>
        /// <param name="paraList"></param>
        /// <param name="retMsg"></param>
        /// <param name="retItemInfo"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <param name="sqlEncryptInfo"></param>
        /// <returns></returns>
        public int DeleteforOrderInput(ref ArrayList paraList, out string retMsg, out string retItemInfo,
                                       ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = "";
            retItemInfo = "";

            IOWriteMASIRDeleteWork dummyIOWriteMASIRDelete = null;

            if (ListUtils.IsNotEmpty(paraList) && paraList[0] is StockDetailWork)
            {
                StockDetailWork baseInfo = (paraList as ArrayList)[0] as StockDetailWork;

                dummyIOWriteMASIRDelete = new IOWriteMASIRDeleteWork();

                // ダミー仕入データに必要な項目を設定する
                dummyIOWriteMASIRDelete.EnterpriseCode = baseInfo.EnterpriseCode;  // 企業コード
                dummyIOWriteMASIRDelete.SupplierFormal = 2;                        // 仕入形式 = 2:発注 固定
                dummyIOWriteMASIRDelete.SupplierSlipNo = 0;                        // 仕入伝票番号 = 0  固定
                dummyIOWriteMASIRDelete.DebitNoteDiv = 0;                          // 赤伝区分 = 0:黒伝 固定
                dummyIOWriteMASIRDelete.UpdateDateTime = DateTime.MinValue;        // 更新日付 = 最小値 固定
                // -- ADD 2009/09/30 -------------------------------->>>
                // 発注取り消し時には発注残を更新しないように修正
                dummyIOWriteMASIRDelete.StockUpdDiv = 1;                           // 在庫マスタ更新区分 = 1:更新しない 固定
                // -- ADD 2009/09/30 --------------------------------<<<
            }

            if (dummyIOWriteMASIRDelete != null)
            {
                CustomSerializeArrayList paramArray = new CustomSerializeArrayList();

                paramArray.Add(dummyIOWriteMASIRDelete);
                paramArray.Add(paraList);

                status = this.Delete(ref paramArray, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
            }

            return status;
        }

        # endregion

        # region [発注書発行用メソッド]

        /// <summary>
        /// 発注書発行用 追加・更新処理
        /// </summary>
        /// <param name="paraList">更新情報オブジェクトリスト</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <returns>STATUS</returns>
        public int WriteforSalesOrderPrint(ref object paraList, out string retMsg, out string retItemInfo)
        {
            //●STATUS初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            retMsg = "";
            retItemInfo = "";

            string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlEncryptInfo sqlEncryptInfo = null;

            try
            {
                //●SQLコネクションオブジェクト作成
                sqlConnection = this.CreateSqlConnection(true);

                if (sqlConnection == null)
                {
                    errmsg += ": データベースへの接続に失敗しました.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                # region [--- DEL 2008/06/03 M.Kubota ---]
                //--- DEL 2008/06/03 M.Kubota --->>>
                //●暗号化キーOPEN
                //sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, IOWriteMASIRDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Write));
                //sqlEncryptInfo.OpenSymKey(ref sqlConnection);
                //--- DEL 2008/06/03 M.Kubota ---<<<
                # endregion

                //●トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                ArrayList paraArray = paraList as ArrayList;

                status = this.WriteforSalesOrderPrint(ref paraArray, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                # region [--- DEL 2009/01/13 M.Kubota ---]
                //status = this.StockSlipDb.WriteforSalesOrderPrint(ref paraList, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                
                //// 在庫更新(発注数量の加算)を行う
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    object freeParam = null;
                //    CustomSerializeArrayList originArray = new CustomSerializeArrayList();

                //    foreach (object item in paraList)
                //    {
                //        CustomSerializeArrayList OneSetSlipData = item as CustomSerializeArrayList;

                //        if (OneSetSlipData != null)
                //        {
                //            int stockSlipWork_Posi = MakePosition(OneSetSlipData, typeof(StockSlipWork), 0);
                //            status = this.StockUpdateDb.WriteInitial(_origin, ref originArray, ref OneSetSlipData, stockSlipWork_Posi, "", ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                //            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //            {
                //                status = this.StockUpdateDb.Write(_origin, ref originArray, ref OneSetSlipData, stockSlipWork_Posi, "", ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                //            }

                //            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //            {
                //                break;
                //            }
                //        }
                //    }
                //}
                # endregion

                //●コミットorロールバック
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 正常終了の場合はコミット
                    sqlTransaction.Commit();
                }
                else
                {
                    // 異常終了の場合はロールバック
                    sqlTransaction.Rollback();
                }
            }
            //●例外処理
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                //●トランザクション破棄
                if (sqlTransaction != null)
                {
                    sqlTransaction.Dispose();
                }

                //●暗号化キーCLOSE
                //if (sqlEncryptInfo != null && sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);  //DEL 2008/06/03 M.Kubota

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
        /// 
        /// </summary>
        /// <param name="paraList"></param>
        /// <param name="retMsg"></param>
        /// <param name="retItemInfo"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <param name="sqlEncryptInfo"></param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// 2009/01/13 追加
        /// </remarks>
        public int WriteforSalesOrderPrint(ref ArrayList paraList, out string retMsg, out string retItemInfo,
                                           ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            //●STATUS初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            retMsg = "";
            retItemInfo = "";

            string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());

            //●パラメータチェック
            if (paraList == null || paraList.Count <= 0)
            {
                errmsg += ": パラメータの指定に誤りが有ります.";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            try
            {
                status = this.StockSlipDb.WriteforSalesOrderPrint(ref paraList, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                // 在庫更新(発注数量の加算)を行う
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    object freeParam = null;
                    CustomSerializeArrayList originArray = new CustomSerializeArrayList();

                    foreach (object item in paraList)
                    {
                        CustomSerializeArrayList OneSetSlipData = item as CustomSerializeArrayList;

                        if (OneSetSlipData != null)
                        {
                            int stockSlipWork_Posi = MakePosition(OneSetSlipData, typeof(StockSlipWork), 0);
                            status = this.StockUpdateDb.WriteInitial(_origin, ref originArray, ref OneSetSlipData, stockSlipWork_Posi, "", ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                status = this.StockUpdateDb.Write(_origin, ref originArray, ref OneSetSlipData, stockSlipWork_Posi, "", ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                            }

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                //データ無しの場合はステータスを警告ステータスに変更する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND ||
                    status == (int)ConstantManagement.DB_Status.ctDB_EOF) status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
            }

            return status;
        }


        /// <summary>
        /// 発注書発行用 削除処理
        /// </summary>
        /// <param name="paraList">物理削除情報オブジェクトリスト</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <returns>STATUS</returns>
        public int DeleteforSalesOrderPrint(ref object paraList, out string retMsg, out string retItemInfo)
        {
            //●STATUS初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            retMsg = "";
            retItemInfo = "";

            string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());

            # region [---DEL 2009/01/13 M.Kubota ---
            ////●パラメータチェック
            //ArrayList paraList = paraList as ArrayList;
            //if (paraList == null || paraList.Count <= 0)
            //{
            //    base.WriteErrorLog(errmsg, status);
            //    return status;
            //}
            # endregion

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlEncryptInfo sqlEncryptInfo = null;

            try
            {
                //●SQLコネクションオブジェクト作成
                sqlConnection = this.CreateSqlConnection(true);
                
                if (sqlConnection == null)
                {
                    errmsg += ": データベースへの接続に失敗しました.";
                    this.WriteErrorLog(errmsg, status);
                    return status;
                }

                # region [--- DEL 2008/06/03 M.Kubota ---]
                //--- DEL 2008/06/03 M.Kubota --->>>
                //●暗号化キーOPEN
                //sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, IOWriteMASIRDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Write));
                //sqlEncryptInfo.OpenSymKey(ref sqlConnection);
                //--- DEL 2008/06/03 M.Kubota ---<<<
                # endregion

                //●トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                ArrayList paraArray = paraList as ArrayList;

                status = this.DeleteforSalesOrderPrint(ref paraArray, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                # region [--- DEL 2009/01/13 M.Kubota ---]

                //status = this.StockSlipDb.DeleteforSalesOrderPrint(ref paraList, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                //// 在庫更新(発注数量の減算)を行う
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    // 発注取消の対象となった仕入・仕入明細データを格納しているArrayListを取得
                //    int modifiedSlips_Pos = MakePosition(paraList as CustomSerializeArrayList, typeof(ArrayList), 0);

                //    ArrayList modifiedSlips = null;

                //    if (modifiedSlips_Pos > -1)
                //    {
                //        modifiedSlips = paraList[modifiedSlips_Pos] as ArrayList;
                //    }

                //    if (modifiedSlips != null)
                //    {

                //        object freeParam = null;
                //        CustomSerializeArrayList dummyArray = new CustomSerializeArrayList();

                //        foreach (object item in modifiedSlips)
                //        {
                //            if (item is ArrayList)
                //            {
                //                CustomSerializeArrayList modifiedSlipsData = new CustomSerializeArrayList();
                //                modifiedSlipsData.AddRange(item as ArrayList);

                //                int stockSlipWork_Posi = MakePosition(modifiedSlipsData, typeof(StockSlipWork), 0);
                //                int stockSlipDtl_Posi = MakePosition(modifiedSlipsData, typeof(StockDetailWork), 1);

                //                status = this.StockUpdateDb.DeleteInitial(_origin, ref modifiedSlipsData, ref dummyArray, stockSlipWork_Posi, "", ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                //                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //                {
                //                    status = this.StockUpdateDb.Delete(_origin, ref modifiedSlipsData, ref dummyArray, stockSlipWork_Posi, "", ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                //                }

                //                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //                {
                //                    break;
                //                }

                //            }
                //            else
                //            {
                //                continue;
                //            }
                //        }

                //        paraList.Remove(modifiedSlips);
                //    }
                //}

                # endregion

                //●コミットorロールバック
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 正常終了の場合はコミット
                    sqlTransaction.Commit();
                }
                else
                {
                    // 異常終了の場合はロールバック
                    sqlTransaction.Rollback();
                }
            }
            //●例外処理
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                //●トランザクション破棄
                if (sqlTransaction != null)
                {
                    sqlTransaction.Dispose();
                }

                //●暗号化キーCLOSE
                //if (sqlEncryptInfo != null && sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);  //DEL 2008/06/03 M.Kubota

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
        /// 
        /// </summary>
        /// <param name="paraList"></param>
        /// <param name="retMsg"></param>
        /// <param name="retItemInfo"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <param name="sqlEncryptInfo"></param>
        /// <returns></returns>
        public int DeleteforSalesOrderPrint(ref ArrayList paraList, out string retMsg, out string retItemInfo,
                                            ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            //●STATUS初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            retMsg = "";
            retItemInfo = "";

            string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());

            //●パラメータチェック
            if (paraList == null || paraList.Count <= 0)
            {
                errmsg += ": パラメータの指定に誤りが有ります.";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            try
            {
                // UPD 2011/07/27 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
                //status = this.StockSlipDb.DeleteforSalesOrderPrint(ref paraList, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                status = this.StockSlipDb.DeleteforSalesOrderPrint(ref paraList, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo, out retMsg);
                // UPD 2011/07/27 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<

                // 在庫更新(発注数量の減算)を行う
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 発注取消の対象となった仕入・仕入明細データを格納しているArrayListを取得
                    int modifiedSlips_Pos = MakePosition(paraList as CustomSerializeArrayList, typeof(ArrayList), 0);

                    ArrayList modifiedSlips = null;

                    if (modifiedSlips_Pos > -1)
                    {
                        modifiedSlips = paraList[modifiedSlips_Pos] as ArrayList;
                    }

                    if (modifiedSlips != null)
                    {

                        object freeParam = null;
                        CustomSerializeArrayList dummyArray = new CustomSerializeArrayList();

                        foreach (object item in modifiedSlips)
                        {
                            if (item is ArrayList)
                            {
                                CustomSerializeArrayList modifiedSlipsData = new CustomSerializeArrayList();
                                modifiedSlipsData.AddRange(item as ArrayList);

                                int stockSlipWork_Posi = MakePosition(modifiedSlipsData, typeof(StockSlipWork), 0);
                                int stockSlipDtl_Posi = MakePosition(modifiedSlipsData, typeof(StockDetailWork), 1);

                                status = this.StockUpdateDb.DeleteInitial(_origin, ref modifiedSlipsData, ref dummyArray, stockSlipWork_Posi, "", ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    status = this.StockUpdateDb.Delete(_origin, ref modifiedSlipsData, ref dummyArray, stockSlipWork_Posi, "", ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                                }

                                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    break;
                                }

                            }
                            else
                            {
                                continue;
                            }
                        }

                        paraList.Remove(modifiedSlips);
                    }
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                //データ無しの場合はステータスを警告ステータスに変更する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND ||
                    status == (int)ConstantManagement.DB_Status.ctDB_EOF) status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
            }

            return status;
        }

        # endregion

        /// <summary>
        /// 発注書発行からコールされている事を表す為だけのクラス
        /// </summary>
        private class SalesOrderPrint
        {

        }

        // --- ADD 2010/06/08 ---------->>>>>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stockDetailWork"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <param name="sqlEncryptInfo"></param>
        /// <returns></returns>
        public int UpdateStockDetail(ref StockDetailWork stockDetailWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.StockSlipDb.UpdateStockDetailWork(ref stockDetailWork, ref sqlConnection, ref sqlTransaction);
        }
        // --- ADD 2010/06/08 ----------<<<<<

        // --- ADD 連番966 2011/08/16 ---------->>>>>
        /// <summary>
        /// 仕入明細マスタの同時売上情報をクリアする
        /// </summary>
        /// <param name="stockDetailWork"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <param name="sqlEncryptInfo"></param>
        /// <br>Note       : 連番966 仕入明細マスタの同時売上情報をクリアする。</br>
        /// <br>Programmer : 許雁波</br>
        /// <br>Date       : 2011/08/16</br>
        /// <returns></returns>
        public int UpdateStockDetailSync(ref CustomSerializeArrayList paramArray, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            IOWriteMASIRDeleteWork iOWriteMASIRDeleteWork = null;
            StockSlipReadWork stockSlipReadWork = new StockSlipReadWork();

            //仕入IOWriteDeleteパラメータから仕入パラメータを生成
            foreach (object obj in paramArray)
            {
                if (obj is IOWriteMASIRDeleteWork)
                {
                    iOWriteMASIRDeleteWork = obj as IOWriteMASIRDeleteWork;
                    stockSlipReadWork.EnterpriseCode = iOWriteMASIRDeleteWork.EnterpriseCode;
                    stockSlipReadWork.SupplierFormal = iOWriteMASIRDeleteWork.SupplierFormal;
                    stockSlipReadWork.SupplierSlipNo = iOWriteMASIRDeleteWork.SupplierSlipNo;
                    stockSlipReadWork.DebitNoteDiv = iOWriteMASIRDeleteWork.DebitNoteDiv;

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    break;
                }
            }
            ArrayList stockDetailWorkList;
            StockDetailWork stockDetailWork;
            //仕入明細通番の取得
            // --- UPD 2012/11/30 Y.Wakita ---------->>>>>
            //status = this.StockSlipDb.ReadStockDetailWork(out stockDetailWorkList, stockSlipReadWork, ref sqlConnection, ref sqlTransaction);
            status = this.StockSlipDb.ReadStockDetailWork2(out stockDetailWorkList, paramArray, ref sqlConnection, ref sqlTransaction);
            // --- UPD 2012/11/30 Y.Wakita ----------<<<<<
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (StockDetailWork tmp in stockDetailWorkList)
                {
                    stockDetailWork = (StockDetailWork)tmp;
                    //仕入明細マスタの同時売上情報をクリアする
                    status = this.StockSlipDb.ClearStockDetailSync(ref stockDetailWork, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //仕入履歴明細データの同時売上情報をクリアする
                        status = this.StockSlipHistDb.ClearStockSlHistDtlSync(ref stockDetailWork, ref sqlConnection, ref sqlTransaction);
                    }
                }
            }
            return status;
        }
        // --- ADD 連番966 2011/08/16 ----------<<<<<
    }
}

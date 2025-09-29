//***************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 仕入返品計上更新部品
// プログラム概要   : 仕入返品計上更新部品 リモートクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : FSI斎藤 和宏
// 作 成 日  2013/01/22  修正内容 : 仕入返品予定機能追加対応
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入返品計上更新部品 リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入返品計上更新部品リモートオブジェクトの実データ操作を行うクラスです。</br>
    /// <br>Programmer : FSI斎藤 和宏</br>
    /// <br>Date       : 2013/01/22</br>
    /// </remarks>
    [Serializable]
    public class StockSlipRetPlnDB : RemoteWithAppLockDB, IStockSlipRetPlnDB
    {

        #region [仕入エントリ更新リモートオブジェクトで必要なもの]
        //プログラムID
        private string _origin = "IOWriteMASIRDB";
        //関数コールKEY
        //前
        private string _funcCallKey_BFR = "IOWriteMASIRDBBfr";
        //後
        private string _funcCallKey_AFT = "IOWriteMASIRDBAft";
        //処理コントロール部品
        private FunctionCallControl _functionCallControl = null;
        #endregion [仕入エントリ更新リモートオブジェクトで必要なもの]

        # region [使用リモート・プロパティ]
        private IOWriteCtrlOptWork _CtrlOptWork = null;                 // 売上・仕入制御オプション
        private StockSlipDB _stockSlipDB = null;                        // 仕入リモート
        private StockSlipHistDB _stockSlipHistDB = null;                // 仕入履歴リモート
        private IOWriteMASIRStockUpdateDB _stockUpdateDB = null;        // 在庫更新リモート
        private MonthlyTtlStockUpdDB _monthlyTtlStockUpdDb = null;      // 仕入月次更新処理リモート
        private AcceptOdrDB _acceptOdrDb = null;                        // 受注マスタリモート
        private SalesSlipDB _salesSlipDb = null;                        // 売上データDBリモート
        private IOWriteGoodsUser _ioWriteGoodsUser = null;              // 商品マスタ(ユーザー)リモート
        private IOWriteGoodsPriceUser _ioWriteGoodsPriceUser = null;    // 商品価格マスタ(ユーザー)リモート

        /// <summary> 売上・仕入制御オプション プロパティ </summary>
        private IOWriteCtrlOptWork CtrlOptWork
        {
            get { return this._CtrlOptWork; }

            set
            {
                this._CtrlOptWork = value;
                this._ResourceName = this.GetResourceName(this._CtrlOptWork.EnterpriseCode);
            }
        }

        /// <summary> 仕入リモートプロパティ </summary>
        private StockSlipDB stockSlipDB
        {
            get
            {
                if (this._stockSlipDB == null)
                {
                    // 仕入リモートを生成
                    this._stockSlipDB = new StockSlipDB();
                }

                this._stockSlipDB.IOWriteCtrlOptWork = this._CtrlOptWork;

                return this._stockSlipDB;
            }
        }

        /// <summary> 仕入履歴リモートプロパティ </summary>
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

        /// <summary> 在庫更新リモート プロパティ </summary>
        private IOWriteMASIRStockUpdateDB StockUpdateDb
        {
            get
            {
                if (this._stockUpdateDB == null)
                {
                    this._stockUpdateDB = new IOWriteMASIRStockUpdateDB(this._CtrlOptWork);
                }

                return this._stockUpdateDB;
            }
        }

        /// <summary> 仕入月次更新処理リモート プロパティ </summary>
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

        /// <summary> 受注マスタDBリモート プロパティ </summary>
        private AcceptOdrDB AcceptOdrDb
        {
            get
            {
                if (this._acceptOdrDb == null)
                {
                    this._acceptOdrDb = new AcceptOdrDB();
                }

                return this._acceptOdrDb;
            }
        }

        /// <summary> 売上データDBリモート プロパティ </summary>
        private SalesSlipDB SalesSlipDb
        {
            get
            {
                if (this._salesSlipDb == null)
                {
                    this._salesSlipDb = new SalesSlipDB();
                }

                return this._salesSlipDb;
            }
        }

        /// <summary> 商品マスタ(ユーザー)リモート プロパティ </summary>
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

        /// <summary> 商品価格マスタ(ユーザー)リモート プロパティ </summary>
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

        # endregion

        #region[シェアチェック関連]
        /// <summary>
        /// アプリケーション ロック リソース名
        /// </summary>
        private string _ResourceName = "";

        /// <summary>
        /// アプリケーション ロック リソース名 プロパティ
        /// </summary>
        private string ResourceName
        {
            get { return this._ResourceName; }
        }
        #endregion[シェアチェック関連]

        /// <summary>
        /// 仕入返品計上更新部品リモートオブジェクトDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2013/01/22</br>
        /// </remarks>
        public StockSlipRetPlnDB()
            :
            base("PMKAK01104D", "Broadleaf.Application.Remoting.ParamData.StockSlipRetPlnDBWork", "StockSlipRetPlnDBRF")
        {
            #if DEBUG
            Console.WriteLine("仕入返品計上更新部品リモートオブジェクト");
            #endif

            //●更新ファンクションコントロールクラス生成
            _functionCallControl = new FunctionCallControl(IOWriteMASIRDBServerRsc.GetResource());

        }

        # region [書込処理]

        /// <summary>
        /// 仕入返品予定データの登録を行います
        /// </summary>
        /// <param name="paraList">登録する仕入返品予定データ</param>
        /// <param name="retMsg">返却するエラーメッセージ</param>
        /// <param name="retItemInfo">未使用</param>
        /// <returns>RETURN</returns>
        /// <remarks>
        /// <br>Note        : 2013/01/22  FSI斎藤 和宏</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              仕掛No.1105 仕入返品予定機能追加対応</br>
        /// <br>              DCHNB01864RA.cs 流用</br>
        /// </remarks>
        public int Write(ref object paraList, out string retMsg, out string retItemInfo)
        {
            // 戻り値の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            SqlConnection connection = null;
            SqlTransaction transaction = null;
            SqlEncryptInfo encryptinfo = null;

            if (SlipListUtils.IsEmpty(paraList as ArrayList))
            {
                retMsg = "更新情報リストが未登録です。"; // → 終了
                base.WriteErrorLog("public int Write()" + retMsg, status);
            }
            else
            {
                try
                {
                    ArrayList list = paraList as ArrayList;

                    status = this.WriteProc(ref list, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

                    if (transaction != null && transaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            transaction.Commit();
                        }
                        else
                        {
                            transaction.Rollback();
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(ex, errmsg, status);

                    retMsg += (string.IsNullOrEmpty(retMsg) ? "" : "\n") + ex.Message;

                    if (transaction != null && transaction.Connection != null)
                    {
                        transaction.Rollback();
                    }
                }
                finally
                {
                    // トランザクションの破棄
                    if (transaction != null)
                    {
                        transaction.Dispose();
                    }

                    // 暗号化キーのクローズ
                    //if (encryptinfo != null && encryptinfo.IsOpen)
                    //{
                    //    encryptinfo.CloseSymKey(ref connection);
                    //}

                    // コネクションの破棄
                    if (connection != null)
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// 仕入返品予定データの登録メイン処理
        /// </summary>
        /// <param name="paramlist">登録する仕入返品予定データ</param>
        /// <param name="retMsg">メッセージ(主にエラーメッセージ)</param>
        /// <param name="retItemInfo">項目情報(未使用)</param>
        /// <param name="connection">データベース接続オブジェクト</param>
        /// <param name="transaction">トランザクションオブジェクト</param>
        /// <param name="encryptinfo">暗号化キーオブジェクト</param>
        /// <returns>RETURN</returns>
        /// <remarks>
        /// <br>Note        : 2013/01/22  FSI斎藤 和宏</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              仕掛No.1105 仕入返品予定機能追加対応</br>
        /// <br>              DCHNB01864RA.cs 流用</br>
        /// </remarks>
        private int WriteProc(ref ArrayList paramlist, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            //●戻り値の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;
            string methodNm = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());

            //●各種パラメータの確認を行う
            # region [パラメータチェック]

            //●更新情報リストチェック
            if (SlipListUtils.IsEmpty(paramlist))
            {
                retMsg = "更新情報リストが未登録です。";
                base.WriteErrorLog(methodNm + retMsg, status);
                return status;
            }

            //●売上・仕入制御オプションチェック
            this.CtrlOptWork = SlipListUtils.Find(paramlist, typeof(IOWriteCtrlOptWork), SlipListUtils.FindType.Class) as IOWriteCtrlOptWork;

            if (this.CtrlOptWork == null)
            {
                retMsg = "売上・仕入制御オプションが見つかりません。";
                base.WriteErrorLog(methodNm + retMsg, status);
                return status;
            }

            //●コネクションチェック
            if (connection == null)
            {
                connection = this.CreateSqlConnection();
                connection.Open();
            }

            if (connection == null)
            {
                retMsg = "データベースへ接続出来ません。";
                base.WriteErrorLog(methodNm + retMsg, status);
                return status;
            }

            //●トランザクションチェック
            if (transaction == null)
            {

                transaction = connection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
            }

            if (transaction == null)
            {
                retMsg = "トランザクションを開始できません。";
                base.WriteErrorLog(methodNm + retMsg, status);
                return status;
            }
            # endregion

            Hashtable new2org = new Hashtable();

            //●排他ロックを開始する(DCHNB01864RA.cs同様)
#if !DEBUG  // Debug時に他の人の迷惑にならない様に…
            ShareCheckInfo info = null;
            // --- UPD m.suzuki 2010/08/17 ---------->>>>>
            //this.ShareCheckInitialize(paramlist, ref info);
            this.ShareCheckInitialize(paramlist, ref info, ref connection, ref transaction);
            // --- UPD m.suzuki 2010/08/17 ----------<<<<<

            status = this.ShareCheck(info, LockControl.Locke, connection, transaction);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            status = this.Lock(this.ResourceName, connection, transaction);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    retMsg = "ロックタイムアウトが発生しました。";
                }
                else
                {
                    retMsg = "排他ロックに失敗しました。";
                }

                return status;
            }
# endif

            try
            {
                // 登録後の仕入データリスト
                ArrayList afterPurchaseList = new ArrayList();

                //●伝票登録準備処理を呼び出す
                # region [登録データ準備処理]
                foreach (object item in paramlist)
                {
                    if (item is IOWriteCtrlOptWork)
                    {
                        continue;
                    }
                    else
                    {
                        if (!isContainStockDetailWorkData(item))
                        {
                            retMsg += "仕入返品予定データの登録準備処理に失敗しました。";
                            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                            base.WriteErrorLog(methodNm + retMsg, status);
                            return status;
                        }

                        ArrayList newSliplist = item as ArrayList;
                        ArrayList orgSliplist = null;

                        // 仕入系データ登録準備処理
                        status = this.PurchaseWriteInitialize(out orgSliplist, ref newSliplist, ref paramlist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            new2org.Add(newSliplist, orgSliplist);
                        }
                        else
                        {
                            retMsg += "StockSlipRetPlnDB.WriteProc仕入返品予定データの登録準備処理に失敗しました。";
                            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                            base.WriteErrorLog(methodNm + retMsg, status);
                            return status;
                        }
                    }
                }
                # endregion

                //●更新情報リスト内に格納されている伝票データの伝票種類を元に売上・仕入の伝票登録処理を呼び出す
                # region [データ登録処理]
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (object item in paramlist)
                    {
                        if (item is IOWriteCtrlOptWork)
                        {
                            continue;
                        }

                        if (item is ArrayList)
                        {
                            ArrayList newSliplist = item as ArrayList;
                            ArrayList orgSliplist = null;

                            if (!isContainStockDetailWorkData(item))
                            {
                                retMsg += "StockSlipRetPlnDB.WriteProc: 仕入返品予定データの登録処理に失敗しました。";
                                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                base.WriteErrorLog(methodNm + retMsg, status);
                                return status;
                            }

                            // 仕入系データ登録処理
                            orgSliplist = new2org[newSliplist] as ArrayList;
                            status = this.PurchaseWrite(orgSliplist, ref newSliplist, ref paramlist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

                            // 登録処理に失敗した場合は処理を中断する
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retMsg += "StockSlipRetPlnDB.WriteProc: 仕入返品予定データの登録処理に失敗しました。";
                                break;
                            }
                            else
                            {
                                // 登録後リストに追加
                                afterPurchaseList.Add(newSliplist);
                            }
                        }
                    }
                }
                # endregion
            }
            finally
            {
#if !DEBUG // Debug時に他の人の迷惑にならない様に…
                //●排他ロックを解除する
                this.Release(this.ResourceName, connection, transaction);
                
                this.ShareCheck(info, LockControl.Release, connection, transaction);
#endif
            }
            return status;
        }

        # region [仕入返品予定データの登録初期化処理]
        /// <summary>
        /// 仕入返品予定データの登録初期化処理
        /// </summary>
        /// <param name="orgsliplist">登録対象の更新前伝票ヘッダと明細を含むリスト</param>
        /// <param name="newsliplist">登録対象の伝票ヘッダと明細を含むリスト</param>
        /// <param name="otherdatalist">その他の関連伝票データを含むリスト(登録対象データも含む)</param>
        /// <param name="retMsg">メッセージ(主にエラーメッセージ)</param>
        /// <param name="retItemInfo">項目情報(未使用)</param>
        /// <param name="connection">データベース接続オブジェクト</param>
        /// <param name="transaction">トランザクションオブジェクト</param>
        /// <param name="encryptinfo">暗号化キーオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : 2013/01/22  FSI斎藤 和宏</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              仕掛No.1105 仕入返品予定機能追加対応</br>
        /// <br>              DCHNB01864RA.csから流用</br>
        /// </remarks>
        private int PurchaseWriteInitialize(out ArrayList orgsliplist, ref ArrayList newsliplist, ref ArrayList otherdatalist, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            //●戻り値の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            StockSlipWork slip = SlipListUtils.Find(newsliplist, typeof(StockSlipWork), SlipListUtils.FindType.Class) as StockSlipWork;
            ArrayList slipdtls = SlipListUtils.Find(newsliplist, typeof(StockDetailWork), SlipListUtils.FindType.Array) as ArrayList;

            if (slip == null)
            {
                // 伝票データが存在しない場合はエラーとして返却
                retMsg += "StockSlipRetPlnDB.PurchaseWriteInitialize: 仕入伝票データが設定されていません。";
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog("private int PurchaseWriteInitialize()" + retMsg, status);
            }

            //●仕入リモートの登録準備処理を実行する
            // ここから先を部品呼び出しにしたい。後で検証してみる。
            status = this.IOWriteDBWriteInitialize(out orgsliplist, ref newsliplist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

            return status;
        }

        # region [仕入エントリ更新(MAKON01814RA.cs)から流用したメソッド]
        /// <summary>
        /// 仕入返品予定データの登録初期化処理(MAKON01814RA.csのWriteInitializeから流用)
        /// </summary>
        /// <param name="orgslips">登録対象の更新前伝票ヘッダと明細を含むリスト</param>
        /// <param name="newslips">登録対象の伝票ヘッダと明細を含むリスト</param>
        /// <param name="retMsg">メッセージ(主にエラーメッセージ)</param>
        /// <param name="retItemInfo">項目情報(未使用)</param>
        /// <param name="connection">データベース接続オブジェクト</param>
        /// <param name="transaction">トランザクションオブジェクト</param>
        /// <param name="encryptinfo">暗号化キーオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : 2013/01/22  FSI斎藤 和宏</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              仕掛No.1105 仕入返品予定機能追加対応</br>
        /// <br>              MAKON01814RA.csから流用</br>
        /// </remarks>
        private int IOWriteDBWriteInitialize(out ArrayList orgslips, ref ArrayList newslips, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
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
        /// <remarks>
        /// <br>Note        : 2013/01/22  FSI斎藤 和宏</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              仕掛No.1105 仕入返品予定機能追加対応</br>
        /// <br>              MAKON01814RA.csから流用</br>
        /// </remarks>
        private Int32 IOWriteMASIRFunctionProcWriteInitial(ref CustomSerializeArrayList originArray, ref CustomSerializeArrayList paramArray, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = "";
            retItemInfo = "";

            int stockSlipWork_Posi = MakePosition(paramArray, typeof(StockSlipWork), 0);

            // 仕入入力のWriteInitial関数を呼び出す
            if (stockSlipWork_Posi > -1)
            {
                // 伝票番号・共通通番・はここで取得
                // この先は共通部品
                StockSlipWork stockSlipWork = paramArray[stockSlipWork_Posi] as StockSlipWork;
                status = this.stockSlipDB.WriteInitial(_origin, ref originArray, ref paramArray, stockSlipWork_Posi, ""/*構成ﾌｧｲﾙﾊﾟﾗﾒｰﾀ無し*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
            }

            return status;
        }

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
        # endregion [仕入エントリ更新(MAKON01814RA.cs)から流用したメソッド]

        /// <summary>
        /// 仕入系伝票データ登録
        /// </summary>
        /// <param name="orgsliplist">登録対象の更新前伝票ヘッダと明細を含むリスト</param>
        /// <param name="newsliplist">登録対象の伝票ヘッダと明細を含むリスト</param>
        /// <param name="otherdatalist">その他の関連伝票データを含むリスト(登録対象データも含む)</param>
        /// <param name="retMsg">メッセージ(主にエラーメッセージ)</param>
        /// <param name="retItemInfo">項目情報(未使用)</param>
        /// <param name="connection">データベース接続オブジェクト</param>
        /// <param name="transaction">トランザクションオブジェクト</param>
        /// <param name="encryptinfo">暗号化キーオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : 2013/01/22  FSI斎藤 和宏</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              仕掛No.1105 仕入返品予定機能追加対応</br>
        /// </remarks>
        private int PurchaseWrite(ArrayList orgsliplist, ref ArrayList newsliplist, ref ArrayList otherdatalist, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            //●戻り値の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            //●仕入リモートの登録処理を実行する
            status = this.IOWriteDBWriteA(orgsliplist, ref newsliplist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

            //●登録準備処理にてダミーの発注データがリストに追加されている場合は削除する
            OrderSlipWork orderSlip = SlipListUtils.Find(newsliplist, typeof(OrderSlipWork), ListUtils.FindType.Class) as OrderSlipWork;

            if (orderSlip != null)
            {
                newsliplist.Remove(orderSlip);
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
        /// //MAKON01814RA.cs
        private int IOWriteDBWriteA(ArrayList orgslips, ref ArrayList newslips, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;
            string methodNm = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
            #region [パラメータチェック処理]

            //●パラメータチェック
            if (newslips == null || newslips.Count <= 0)
            {
                retMsg = ": 登録対象の仕入データが設定されていません。";
                base.WriteErrorLog(methodNm + retMsg, status);
                return status;
            }

            //●データベース接続状況チェック
            if (connection == null)
            {
                retMsg = ": データベース接続情報が設定されていません。";
                base.WriteErrorLog(methodNm + retMsg, status);
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
                base.WriteErrorLog(methodNm + retMsg, status);
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
                status = base.WriteSQLErrorLog(ex, methodNm, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, methodNm, status);
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
        //MAKON01814RA.cs
        private Int32 IOWriteMASIRFunctionProcWrite(ref CustomSerializeArrayList originArray, ref CustomSerializeArrayList paramArray, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = "";
            retItemInfo = "";

            // パラメータインデックスの取得
            int stockSlipWork_Posi = MakePosition(paramArray, typeof(StockSlipWork), 0);

            if (stockSlipWork_Posi > -1)
            {
                StockSlipWork wrkStockSlipWork = paramArray[stockSlipWork_Posi] as StockSlipWork;

                // 共通部品を呼び出す前に仕入形式を「3」にセットする。
                this.SetToRetPlnFromParamList(ref paramArray);

                // 仕入入力Write関数を呼び出す
                // この先は共通部品
                status = this.stockSlipDB.Write(_origin, ref originArray, ref paramArray, stockSlipWork_Posi, ""/*構成ﾌｧｲﾙﾊﾟﾗﾒｰﾀ無し*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

            }

            return status;
        }

        # endregion

        /// <summary>
        /// 仕入形式を仕入返品予定に更新します。
        /// </summary>
        /// <param name="paramArray">登録対象のパラメータリスト</param>
        /// <remarks>
        /// <br>Note        : 2013/01/22  FSI斎藤 和宏</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              仕掛No.1105 仕入返品予定機能追加対応</br>
        /// </remarks>
        private void SetToRetPlnFromParamList(ref CustomSerializeArrayList paramArray)
        {
            StockSlipWork stockSlip = new StockSlipWork();
            List<StockDetailWork> stockDetailList = new List<StockDetailWork>();

            // データ取得(仕入リストから)
            foreach (object data in paramArray)
            {
                if (data is StockSlipWork) // 仕入伝票の場合
                {
                    stockSlip = (StockSlipWork)data;

                    // 仕入形式「3」をセット
                    stockSlip.SupplierFormal = 3;
                }
                else if (data is ArrayList && ((ArrayList)data)[0] != null && ((ArrayList)data)[0] is StockDetailWork)
                {
                    // foreachでStockDetailWork取り出す
                    foreach (StockDetailWork stockDetail in (ArrayList)data)
                    {
                        // 仕入形式「3」をセット
                        stockDetail.SupplierFormal = 3;
                    }
                }
                else
                {
                    continue;
                }
            }
        }

        #region [売上明細読込]
        // 返品予定データの売上明細通番（同時）取得時の処理
        /// <summary>
        /// 売上明細情報読込
        /// </summary>
        /// <param name="salesDetailWork">売上明細データリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="salesSlipNumList">売上伝票番号リスト</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上伝票番号から売上明細情報を取得します</br>
        /// <br>Programmer : FSI厚川 宏</br>
        /// <br>Date       : 2013/01/24</br>        
        public int SearchSalesDetail(out object salesDetailWork, string enterpriseCode, object salesSlipNumList, string sectionCode)
        {
            return this.SearchSalesDetailWork(out salesDetailWork, enterpriseCode, salesSlipNumList, sectionCode);
        }
        /// <summary>
        /// 売上明細情報読込
        /// </summary>
        /// <param name="salesDetailWork">売上明細データリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="salesSlipNumList">売上伝票番号リスト</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上伝票番号から売上明細情報を取得します</br>
        /// <br>Programmer : FSI厚川 宏</br>
        /// <br>Date       : 2013/01/24</br>        
        private int SearchSalesDetailWork(out object salesDetailWork, string enterpriseCode, object salesSlipNumList, string sectionCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            salesDetailWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchSalesDetailWorkSearchProc(out salesDetailWork, enterpriseCode, salesSlipNumList, sectionCode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesDetailSearchDB.Search");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// 売上明細情報読込
        /// </summary>
        /// <param name="salesDetailWork">検索結果</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="salesSlipNumList">売上伝票番号リスト</param>
        /// <param name="sectionCode">拠点コード</param>        
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上伝票番号から売上明細情報を取得します</br>
        /// <br>Programmer : FSI厚川 宏</br>
        /// <br>Date       : 2013/01/24</br>
        private int SearchSalesDetailWorkSearchProc(out object salesDetailWork, string enterpriseCode, object salesSlipNumList, string sectionCode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            StringBuilder sqlString = new StringBuilder(string.Empty);

            // 売上伝票番号リストのパラメータをArrayListにキャスト
            ArrayList salesSlipNumParamList = null;
            if (salesSlipNumList != null && salesSlipNumList is ArrayList && ((ArrayList)salesSlipNumList).Count > 0)
            {
                salesSlipNumParamList = salesSlipNumList as ArrayList;
            }
            else
            {
                salesDetailWork = null;
                return status;
            }

            string methodNm = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                #region[SQL文]
                sqlString.AppendLine("SELECT");
                sqlString.AppendLine(" DTIL.FILEHEADERGUIDRF");
                sqlString.AppendLine(",DTIL.ACPTANODRSTATUSRF");
                sqlString.AppendLine(",DTIL.SALESSLIPNUMRF");
                sqlString.AppendLine(",DTIL.SALESROWNORF");
                sqlString.AppendLine(",DTIL.COMMONSEQNORF");
                sqlString.AppendLine(",DTIL.SALESSLIPDTLNUMRF");
                sqlString.AppendLine(",DTIL.SUPPLIERCDRF");
                sqlString.AppendLine("FROM SALESSLIPRF WITH (READUNCOMMITTED)");
                sqlString.AppendLine("LEFT JOIN SALESDETAILRF AS DTIL WITH (READUNCOMMITTED)");
                sqlString.AppendLine("ON SALESSLIPRF.ENTERPRISECODERF = DTIL.ENTERPRISECODERF");
                sqlString.AppendLine("AND SALESSLIPRF.ACPTANODRSTATUSRF = DTIL.ACPTANODRSTATUSRF");
                sqlString.AppendLine("AND SALESSLIPRF.SALESSLIPNUMRF = DTIL.SALESSLIPNUMRF");
                sqlString.AppendLine("WHERE DTIL.ENTERPRISECODERF = @ENTERPRISECODE");
                sqlString.AppendLine(" AND DTIL.SALESSLIPNUMRF = @SALESSLIPNUM");
                sqlString.AppendLine(" AND SALESSLIPRF.RESULTSADDUPSECCDRF = @RESULTSADDUPSECCD");
                sqlString.AppendLine(" AND DTIL.LOGICALDELETECODERF = 0");
                sqlString.AppendLine(" AND DTIL.ACPTANODRSTATUSRF = 30");
                #endregion[SQL文]

                sqlCommand.CommandText = sqlString.ToString();
                sqlCommand.CommandTimeout = 600;

                //Prameterオブジェクトの作成
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);    // 企業コード
                SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@SALESSLIPNUM", SqlDbType.NChar);        // 売上伝票番号
                SqlParameter paraSectionCodeRF = sqlCommand.Parameters.Add("@RESULTSADDUPSECCD", SqlDbType.NChar);  // 実績計上拠点コード

                foreach (string salesSlipNum in salesSlipNumParamList)
                {
                    if (salesSlipNum != string.Empty)
                    {
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                        paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(salesSlipNum);
                        paraSectionCodeRF.Value = SqlDataMediator.SqlSetString(sectionCode);

                        try
                        {
                            myReader = sqlCommand.ExecuteReader();
                            while (myReader.Read())
                            {
                                retList.Add(this.CopyToSalesDetailWorkFromReader(myReader));
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                        }
                        catch
                        {

                        }
                        finally
                        {
                            if (myReader != null)
                            {
                                if (!myReader.IsClosed)
                                {
                                    myReader.Close();
                                }
                                myReader.Dispose();
                                myReader = null;
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
                base.WriteErrorLog(ex, methodNm, status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                    myReader = null;
                }
            }

            salesDetailWork = retList;

            return status;
        }

        /// <summary>
        /// クラス格納処理 Reader → StockAcPayHisSearchWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SalesDetailWork</returns>
        /// <remarks>
        /// <br>Programmer : FSI厚川 宏</br>
        /// <br>Date       : 2013/01/24</br>
        /// </remarks>
        private StockSlipRetPlnWork CopyToSalesDetailWorkFromReader(SqlDataReader myReader)
        {
            StockSlipRetPlnWork stockSlipRetPlnWork = new StockSlipRetPlnWork();
            
            #region 売上明細ワーククラスへ代入
            // Client側で必要なアイテムのみ取得
            // GUID
            stockSlipRetPlnWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            // 受注ステータス
            stockSlipRetPlnWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
            // 売上伝票番号
            stockSlipRetPlnWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
            // 売上行番号
            stockSlipRetPlnWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));
            // 売上明細通番
            stockSlipRetPlnWork.SalesSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMRF"));
            // 共通通番
            stockSlipRetPlnWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));
            // 仕入先コード
            stockSlipRetPlnWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            #endregion

            return stockSlipRetPlnWork;
        }

        #endregion [売上明細読込]
        
        #endregion

        #region [論理削除]
        /// <summary>
        /// 情報を論理削除します
        /// </summary>
        /// <param name="stockSlipWork">stockSlipWorkオブジェクト</param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 情報を論理削除します</br>
        /// <br>Programmer : FSI福原 一樹</br>
        /// <br>Date       : 2012/01/23</br>
        public int LogicalDelete(ref object stockSlipWork, out string retMsg)
        {
            return this.LogicalDeleteProc(ref stockSlipWork, out retMsg);
        }

        /// <summary>
        /// 論理削除を操作します
        /// </summary>
        /// <param name="stockSlipWork">stockSlipWorkオブジェクト</param>
        /// <param name="retMsg"></param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除を操作します</br>
        /// <br>Programmer : FSI福原 一樹</br>
        /// <br>Date       : 2012/01/23</br>
        private int LogicalDeleteProc(ref object stockSlipWork, out string retMsg)
        {
            //●初期値設定
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            int procMode = 0;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            string methodNm = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());

            try
            {
                ArrayList paraList = new ArrayList();

                // StockSlipWorkのリストの場合
                if (stockSlipWork is ArrayList)
                {
                    paraList = new ArrayList();

                    foreach (StockSlipWork stockSlip in stockSlipWork as ArrayList)
                    {
                        paraList.Add(stockSlip);
                    }
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    retMsg = "仕入伝票データが不正です。";
                    base.WriteErrorLog(methodNm, retMsg, status);
                    return status;
                }
                //●仕入データ有無のチェック
                if (paraList == null || paraList.Count <= 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    retMsg = "削除対象の仕入データがありません。";
                    base.WriteErrorLog(methodNm, retMsg, status);
                    return status;
                }

                //●コネクションチェック
                if (sqlConnection == null)
                {
                    sqlConnection = this.CreateSqlConnection();
                    sqlConnection.Open();
                }
                if (sqlConnection == null)
                {
                    retMsg = "データベースへ接続出来ません。";
                    base.WriteErrorLog(methodNm + retMsg, status);
                    return status;
                }

                //●トランザクションチェック
                if (sqlTransaction == null) sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                if (sqlTransaction == null)
                {
                    retMsg = "トランザクションを開始できません。";
                    base.WriteErrorLog(methodNm + retMsg, status);
                    return status;
                }

                //●論理削除処理へ
                status = LogicalDeleteProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction, out retMsg);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //●コミット
                    sqlTransaction.Commit();
                }
                else
                {
                    //●ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                    base.WriteErrorLog(methodNm + retMsg, status);
                }
            }
            catch (Exception ex)
            {
                retMsg = "仕入伝票データが不正です";
                base.WriteErrorLog(ex, methodNm + retMsg, status);
                //●ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockSlipWork">論理削除対象のStockSlipWorkオブジェクト</param>
        /// <param name="procMode">関数区分</param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2013/01/22</br>
        public int LogicalDelete(ref object stockSlipWork, int procMode, out string retMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            //●初期値設定
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            ArrayList paraList = new ArrayList();
            string methodNm = "public int LogicalDelete()";

            //●コネクション情報パラメータチェック
            if (sqlConnection == null || sqlTransaction == null)
            {
                retMsg = "データベース接続情報パラメータが未指定です。";
                base.WriteErrorLog(methodNm + retMsg, status);
                return status;
            }

            // StockSlipWorkのリストの場合
            if (stockSlipWork is List<StockSlipWork>)
            {
                paraList = new ArrayList();

                foreach (StockSlipWork stockSlip in stockSlipWork as List<StockSlipWork>)
                {
                    paraList.Add(stockSlip);
                }
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                retMsg = "仕入伝票データが不正です。";
                base.WriteErrorLog(methodNm + retMsg, status);
                return status;
            }

            if (paraList == null || paraList.Count <= 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                retMsg = "削除対象の仕入データがありません。";
                base.WriteErrorLog(methodNm + retMsg, status);
                return status;
            }

            return this.LogicalDeleteProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction, out retMsg);
        }

        /// <summary>
        /// 情報の論理削除を操作します
        /// </summary>
        /// <param name="stockSlipWorkList">論理削除対象のStockSlipWorkオブジェクト</param>
        /// <param name="procMode">関数区分</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2013/01/22</br>
        private int LogicalDeleteProc(ref ArrayList stockSlipWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, out string retMsg)
        {
            //●初期値設定
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            int logicalCnt = 0;
            retMsg = "";
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            string methodNm = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());

            //●排他ロックを開始する(DCHNB01864RA.cs同様)
#if !DEBUG  // Debug時に他の人の迷惑にならない様に…
            ShareCheckInfo info = null;
            // --- UPD m.suzuki 2010/08/17 ---------->>>>>
            //this.ShareCheckInitialize(paramlist, ref info);
            this.ShareCheckInitialize(stockSlipWorkList, ref info, ref sqlConnection, ref sqlTransaction);
            // --- UPD m.suzuki 2010/08/17 ----------<<<<<

            status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            status = this.Lock(this.ResourceName, sqlConnection, sqlTransaction);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    retMsg = "ロックタイムアウトが発生しました。";
                }
                else
                {
                    retMsg = "排他ロックに失敗しました。";
                }

                return status;
            }
# endif

            try
            {
                if (stockSlipWorkList != null)
                {
                    for (int i = 0; i < stockSlipWorkList.Count; i++)
                    {
                        StockSlipWork stockSlipWork = stockSlipWorkList[i] as StockSlipWork;

                        # region [伝票・明細データ取得SQL文]
                        //Selectコマンドの生成
                        StringBuilder sqlText = new StringBuilder();
                        sqlText.Capacity = 800;
                        sqlText.AppendLine("SELECT");
                        sqlText.AppendLine(" SLIP.UPDATEDATETIMERF");
                        sqlText.AppendLine(" ,SLIP.UPDASSEMBLYID1RF");
                        sqlText.AppendLine(" ,SLIP.UPDASSEMBLYID2RF");
                        sqlText.AppendLine(" ,SLIP.UPDEMPLOYEECODERF");
                        sqlText.AppendLine(" ,SLIP.ENTERPRISECODERF");
                        sqlText.AppendLine(" ,SLIP.SUPPLIERFORMALRF AS SLIP_FORMAL");
                        sqlText.AppendLine(" ,SDTL.SUPPLIERFORMALRF AS SDTL_FORMAL");
                        sqlText.AppendLine(" ,SLIP.LOGICALDELETECODERF AS SLIP_LOGICAL");
                        sqlText.AppendLine(" ,SDTL.LOGICALDELETECODERF AS SDTL_LOGICAL");
                        sqlText.AppendLine("FROM  STOCKSLIPRF AS SLIP  WITH (READUNCOMMITTED)");
                        sqlText.AppendLine(" LEFT JOIN STOCKDETAILRF AS SDTL WITH (READUNCOMMITTED)");
                        sqlText.AppendLine("  ON SLIP.ENTERPRISECODERF = SDTL.ENTERPRISECODERF");
                        sqlText.AppendLine(" AND SLIP.SECTIONCODERF = SDTL.SECTIONCODERF");
                        sqlText.AppendLine(" AND SLIP.SUPPLIERSLIPNORF = SDTL.SUPPLIERSLIPNORF");
                        sqlText.AppendLine(" WHERE SLIP.ENTERPRISECODERF=@FINDENTERPRISECODE");
                        sqlText.AppendLine(" AND SLIP.STOCKSECTIONCDRF=@FINDSTOCKSECTIONCODE" + Environment.NewLine);
                        sqlText.AppendLine(" AND SLIP.SUPPLIERSLIPNORF=@FINDSUPPLIERSLIPNO" + Environment.NewLine);
                        sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);
                        # endregion

                        # region [各種パラメータの定義と設定]
                        sqlCommand.Parameters.Clear();
                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaStockSectionCode = sqlCommand.Parameters.Add("@FINDSTOCKSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);
                        
                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockSlipWork.EnterpriseCode);
                        findParaStockSectionCode.Value = SqlDataMediator.SqlSetString(stockSlipWork.StockSectionCd);
                        findParaSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SupplierSlipNo);
                        # endregion
                        int detailCnt = 0;
                        myReader = sqlCommand.ExecuteReader();

                        while (myReader.Read())
                        {
                            //伝票データの論理削除区分が「0」で、仕入形式が「3」であること。
                            int _supplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIP_FORMAL"));
                            int _logicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIP_LOGICAL"));
                            if (_supplierFormal != 3 || _logicalDeleteCode != 0)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                retMsg = "削除対象ではない仕入データのため削除できません。";
                                base.WriteErrorLog(methodNm + retMsg, status);
                                sqlCommand.Cancel();
                                return status;
                            }

                            //伝票明細データの論理削除区分が「0」で、仕入形式が「3」であること。
                            _supplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SDTL_FORMAL"));
                            _logicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SDTL_LOGICAL"));
                            if (_supplierFormal != 3)
                            {
                                retMsg = "削除対象の仕入形式ではないため削除できません。";
                                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                base.WriteErrorLog(methodNm + retMsg, status);
                                sqlCommand.Cancel();
                                return status;
                            }
                            else if(_logicalDeleteCode != 0)
                            {
                                // 明細単位で計上されている場合はここがインクリメントされる
                                logicalCnt++;
                            }
                            detailCnt++;
                        }

                        //●明細データ数が0の時は、該当データがないものとする
                        if (detailCnt == 0)
                        {
                            retMsg = "削除対象の仕入データが存在しないため削除できません。";
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                            base.WriteErrorLog(methodNm + retMsg, status);
                            sqlCommand.Cancel();
                            return status;
                        }
                        //●明細数と同じ数だけ論理削除されているデータがある場合はエラー対象
                        if (detailCnt == logicalCnt)
                        {
                            retMsg = "明細データが全て計上処理済みのため削除できません。";
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            base.WriteErrorLog(methodNm + retMsg, status);
                            sqlCommand.Cancel();
                            return status;
                        }

                        # region [論理削除]
                        //●UPDATE文生成
                        sqlText.Remove(0, sqlText.Length);
                        sqlText.Append("UPDATE" + Environment.NewLine);
                        sqlText.Append("  STOCKSLIPRF WITH (REPEATABLEREAD) " + Environment.NewLine);
                        sqlText.Append("SET" + Environment.NewLine);
                        sqlText.Append("  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine);
                        sqlText.Append(" ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine);
                        sqlText.Append(" ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine);
                        sqlText.Append(" ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine);
                        sqlText.Append(" ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine);
                        sqlText.Append("WHERE" + Environment.NewLine);
                        sqlText.Append("  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine);
                        sqlText.Append("  AND SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine);
                        sqlText.Append("  AND SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine);
                        sqlText.Append(" " + Environment.NewLine);
                        sqlText.Append("UPDATE" + Environment.NewLine);
                        sqlText.Append("  STOCKDETAILRF WITH (REPEATABLEREAD) " + Environment.NewLine);
                        sqlText.Append("SET" + Environment.NewLine);
                        sqlText.Append("  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine);
                        sqlText.Append(" ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine);
                        sqlText.Append(" ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine);
                        sqlText.Append(" ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine);
                        sqlText.Append(" ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine);
                        sqlText.Append("WHERE" + Environment.NewLine);
                        sqlText.Append("  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine);
                        sqlText.Append("  AND SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine);
                        sqlText.Append("  AND SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine);
                        sqlCommand.CommandText = sqlText.ToString();
                        # endregion

                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockSlipWork.EnterpriseCode);
                        findParaStockSectionCode.Value = SqlDataMediator.SqlSetString(stockSlipWork.SectionCode);
                        findParaSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SupplierSlipNo);

                        //更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)stockSlipWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);

                        sqlCommand.Cancel();
                        if (myReader.IsClosed == false) myReader.Close();

                        //論理削除モードの場合
                        if (procMode == 0)
                        {
                            if (logicalDelCd == 1)
                            {
                                retMsg = "削除済みデータのため削除できません。";
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                base.WriteErrorLog(methodNm + retMsg, status);
                                sqlCommand.Cancel();
                                return status;
                            }
                            else if (logicalDelCd == 0)
                            {
                                stockSlipWork.SupplierFormal = 3;
                                stockSlipWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            }
                        }
                        else
                        {
                            //論理削除以外で使用する場合定義する

                        }


                        # region [各種パラメータの定義と設定]
                        //Parameterオブジェクトの作成(更新用)
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraFindSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定(更新用)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockSlipWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockSlipWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockSlipWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockSlipWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.LogicalDeleteCode);
                        paraFindSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SupplierFormal);
                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(stockSlipWork);
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                retMsg = "仕入伝票データが不正です";
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex,methodNm + retMsg, status);
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
#if !DEBUG // Debug時に他の人の迷惑にならない様に…
                //●排他ロックを解除する
                this.Release(this.ResourceName, sqlConnection, sqlTransaction);

                this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
#endif
            }

            stockSlipWorkList = al;

            return status;

        }

        #endregion [論理削除]

        #region[計上処理]
        /// <summary>
        /// 仕入返品予定データの返品計上処理を行います
        /// </summary>
        /// <param name="paraList">計上する仕入返品予定データ</param>
        /// <param name="retMsg">返却するエラーメッセージ</param>
        /// <param name="retItemInfo">未使用</param>
        /// <returns>RETURN</returns>
        /// <remarks>
        /// <br>Note        : 2013/01/22  FSI斎藤 和宏</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              仕掛No.1105 仕入返品予定機能追加対応</br>
        /// <br>              DCHNB01864RA.cs 流用</br>
        /// </remarks>
        public int AddUp(ref object paraList, out string retMsg, out string retItemInfo)
        {
            // 戻り値の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            SqlConnection connection = null;
            SqlTransaction transaction = null;
            SqlEncryptInfo encryptinfo = null;

            if (SlipListUtils.IsEmpty(paraList as ArrayList))
            {
                retMsg = "更新情報リストが未登録です。"; // → 終了
            }
            else
            {
                try
                {
                    ArrayList list = paraList as ArrayList;

                    status = this.AddUpProc(ref list, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

                    if (transaction != null && transaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            transaction.Commit();
                        }
                        else
                        {
                            transaction.Rollback();
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(ex, errmsg, status);

                    retMsg += (string.IsNullOrEmpty(retMsg) ? "" : "\n") + ex.Message;

                    if (transaction != null && transaction.Connection != null)
                    {
                        transaction.Rollback();
                    }
                }
                finally
                {
                    // トランザクションの破棄
                    if (transaction != null)
                    {
                        transaction.Dispose();
                    }

                    // 暗号化キーのクローズ
                    //if (encryptinfo != null && encryptinfo.IsOpen)
                    //{
                    //    encryptinfo.CloseSymKey(ref connection);
                    //}

                    // コネクションの破棄
                    if (connection != null)
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                }
            }

            return status;
        }
        
        /// <summary>
        /// 仕入返品予定データの返品計上処理を行います
        /// </summary>
        /// <param name="paramlist">計上する仕入返品予定データ</param>
        /// <param name="retMsg">メッセージ(主にエラーメッセージ)</param>
        /// <param name="retItemInfo">項目情報(未使用)</param>
        /// <param name="connection">データベース接続オブジェクト</param>
        /// <param name="transaction">トランザクションオブジェクト</param>
        /// <param name="encryptinfo">暗号化キーオブジェクト</param>
        /// <returns>RETURN</returns>
        /// <remarks>
        /// <br>Note        : 2013/01/22  FSI斎藤 和宏</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              仕掛No.1105 仕入返品予定機能追加対応</br>
        /// <br>              DCHNB01864RA.cs 流用</br>
        /// </remarks>
        private int AddUpProc(ref ArrayList paramlist, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            //●戻り値の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            //●各種パラメータの確認を行う
            # region [パラメータチェック]

            //●更新情報リストチェック
            if (SlipListUtils.IsEmpty(paramlist))
            {
                retMsg = "更新情報リストが未登録です。";
                return status;
            }

            //●売上・仕入制御オプションチェック
            this.CtrlOptWork = SlipListUtils.Find(paramlist, typeof(IOWriteCtrlOptWork), SlipListUtils.FindType.Class) as IOWriteCtrlOptWork;

            if (this.CtrlOptWork == null)
            {
                retMsg = "売上・仕入制御オプションが見つかりません。";
                return status;
            }

            //●コネクションチェック
            if (connection == null)
            {
                connection = this.CreateSqlConnection();
                connection.Open();
            }

            if (connection == null)
            {
                retMsg = "データベースへ接続出来ません。";
                return status;
            }

            //●トランザクションチェック
            if (transaction == null)
            {
                transaction = connection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
            }

            if (transaction == null)
            {
                retMsg = "トランザクションを開始できません。";
                return status;
            }
            # endregion

            Hashtable new2org = new Hashtable();

            //●排他ロックを開始する(DCHNB01864RA.cs同様)
#if !DEBUG  // Debug時に他の人の迷惑にならない様に…
            ShareCheckInfo info = null;
            // --- UPD m.suzuki 2010/08/17 ---------->>>>>
            //this.ShareCheckInitialize(paramlist, ref info);
            this.ShareCheckInitialize(paramlist, ref info, ref connection, ref transaction);
            // --- UPD m.suzuki 2010/08/17 ----------<<<<<

            status = this.ShareCheck(info, LockControl.Locke, connection, transaction);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            status = this.Lock(this.ResourceName, connection, transaction);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    retMsg = "ロックタイムアウトが発生しました。";
                }
                else
                {
                    retMsg = "排他ロックに失敗しました。";
                }

                return status;
            }
# endif

            try
            {
                // 計上後の仕入データリスト
                ArrayList afterPurchaseList = new ArrayList();

                //●伝票登録準備処理を呼び出す
                # region [登録データ準備処理]
                foreach (object item in paramlist)
                {
                    if (item is IOWriteCtrlOptWork)
                    {
                        continue;
                    }
                    else
                    {
                        if (!isContainStockDetailWorkData(item))
                        {
                            retMsg += "StockSlipRetPlnDB.AddUpProc: 仕入返品予定データの登録準備処理に失敗しました。";
                            return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        }

                        ArrayList newSliplist = item as ArrayList;
                        ArrayList orgSliplist = null;

                        // まず仕入返品予定データの更新処理
                        // 売上明細通番（同時）・仕入明細通番（元）・論理削除フラグ:1を行う
                        // 最初に行わないと元の返品予定データがたどれなくなる
                        status = this.UpdateStockDetailForRetPlnData(newSliplist, out retMsg, ref connection, ref transaction);

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            return status;
                        }

                        // 元の返品予定データをたどる為の値などをクリアする
                        status = this.AdjustPurchaseListBeforeInitial(ref newSliplist, out retMsg, ref connection, ref transaction);

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            return status;
                        }
                #endregion

                        // 仕入系データ登録準備処理
                        status = this.PurchaseAddUpInitialize(out orgSliplist, ref newSliplist, ref paramlist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            new2org.Add(newSliplist, orgSliplist);
                        }
                        else
                        {
                            retMsg += "StockSlipRetPlnDB.AddUpProc: 仕入返品予定データの登録準備処理に失敗しました。";
                            return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        }
                    }
                }

                //●更新情報リスト内に格納されている伝票データの伝票種類を元に売上・仕入の伝票登録処理を呼び出す
                # region [データ登録処理]
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (object item in paramlist)
                    {
                        if (item is IOWriteCtrlOptWork)
                        {
                            continue;
                        }

                        if (item is ArrayList)
                        {
                            ArrayList newSliplist = item as ArrayList;
                            ArrayList orgSliplist = null;

                            if (!isContainStockDetailWorkData(item))
                            {
                                retMsg += "StockSlipRetPlnDB.AddUpProc: 仕入返品予定データの登録処理に失敗しました。";
                                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                            }

                            // 仕入系データ登録処理
                            orgSliplist = new2org[newSliplist] as ArrayList;
                            status = this.PurchaseAddUp(orgSliplist, ref newSliplist, ref paramlist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

                            afterPurchaseList.Add(newSliplist);

                            // 登録処理に失敗した場合は処理を中断する
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retMsg += "StockSlipRetPlnDB.AddUpProc: 仕入返品予定データの登録処理に失敗しました。";
                                break;
                            }
                        }
                    }
                }
                # endregion

                #region[データ登録後処理]
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (ArrayList SlipList in afterPurchaseList)
                    {
                        // 登録後リストから明細データを取り出す
                        foreach (object data in SlipList)
                        {
                            if (data is ArrayList && ((ArrayList)data)[0] != null && ((ArrayList)data)[0] is StockDetailWork)
                            {
                                // 売⇔仕入の同期処理(同じテーブルへの更新処理を1つのループでまとめる)
                                foreach (object stockDetail in data as ArrayList)
                                {
                                    StockDetailWork stockDetailWork = stockDetail as StockDetailWork;

                                    if (stockDetailWork != null)
                                    {
                                        if (!string.IsNullOrEmpty(stockDetailWork.WarehouseCode.Trim()))
                                            continue;  // 倉庫コードが存在する明細は売上データとの同期処理は行わない
                                        else if (stockDetailWork.SalesSlipDtlNumSync == 0)
                                            continue;  // 仕入個数を画面で変更したものは売上データと同期をとらない
                                        else
                                        {
                                            status = UpdateSalesDetailWork(stockDetailWork, ref connection, ref transaction);

                                            // 登録処理に失敗した場合は処理を中断する
                                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                            {
                                                retMsg += "StockSlipRetPlnDB.AddUpProc: 仕入返品予定データの登録後処理に失敗しました。";
                                                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion

            }
            finally
            {
#if !DEBUG // Debug時に他の人の迷惑にならない様に…
                //●排他ロックを解除する
                this.Release(this.ResourceName, connection, transaction);
                
                this.ShareCheck(info, LockControl.Release, connection, transaction);
#endif
            }
            return status;
        }

        # region [計上初期化処理]
        /// <summary>
        /// 仕入返品予定データの計上初期化処理
        /// </summary>
        /// <param name="orgsliplist">計上対象の更新前伝票ヘッダと明細を含むリスト</param>
        /// <param name="newsliplist">計上対象の伝票ヘッダと明細を含むリスト</param>
        /// <param name="otherdatalist">その他の関連伝票データを含むリスト(登録対象データも含む)</param>
        /// <param name="retMsg">メッセージ(主にエラーメッセージ)</param>
        /// <param name="retItemInfo">項目情報(未使用)</param>
        /// <param name="connection">データベース接続オブジェクト</param>
        /// <param name="transaction">トランザクションオブジェクト</param>
        /// <param name="encryptinfo">暗号化キーオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : 2013/01/22  FSI斎藤 和宏</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              仕掛No.1105 仕入返品予定機能追加対応</br>
        /// <br>              DCHNB01864RA.csから流用</br>
        /// </remarks>
        private int PurchaseAddUpInitialize(out ArrayList orgsliplist, ref ArrayList newsliplist, ref ArrayList otherdatalist, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            //●戻り値の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            StockSlipWork slip = SlipListUtils.Find(newsliplist, typeof(StockSlipWork), SlipListUtils.FindType.Class) as StockSlipWork;
            ArrayList slipdtls = SlipListUtils.Find(newsliplist, typeof(StockDetailWork), SlipListUtils.FindType.Array) as ArrayList;

            if (slip == null)
            {
                // 伝票データが存在しない場合はエラーとして返却
                retMsg += "StockSlipRetPlnDB.PurchaseWriteInitialize: 仕入伝票データが設定されていません。";
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            //●仕入リモートの登録準備処理を実行する
            status = this.IOWriteDBAddUpInitialize(out orgsliplist, ref newsliplist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

            return status;
        }

        /// <summary>
        /// 仕入返品予定データの計上初期化処理(MAKON01814RA.csのWriteInitializeから流用)
        /// </summary>
        /// <param name="orgslips">計上対象の更新前伝票ヘッダと明細を含むリスト</param>
        /// <param name="newslips">計上対象の伝票ヘッダと明細を含むリスト</param>
        /// <param name="retMsg">メッセージ(主にエラーメッセージ)</param>
        /// <param name="retItemInfo">項目情報(未使用)</param>
        /// <param name="connection">データベース接続オブジェクト</param>
        /// <param name="transaction">トランザクションオブジェクト</param>
        /// <param name="encryptinfo">暗号化キーオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : 2013/01/22  FSI斎藤 和宏</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              仕掛No.1105 仕入返品予定機能追加対応</br>
        /// <br>              MAKON01814RA.csから流用</br>
        /// </remarks>
        private int IOWriteDBAddUpInitialize(out ArrayList orgslips, ref ArrayList newslips, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
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
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = IOWriteMASIRFunctionProcAddUpInitial(ref orgSlips, ref cstSlips, ref freeparam, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

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
        /// IOWrite AddUpInitial処理メイン
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
        /// <remarks>
        /// <br>Note        : 2013/01/22  FSI斎藤 和宏</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              仕掛No.1105 仕入返品予定機能追加対応</br>
        /// <br>              MAKON01814RA.csから流用</br>
        /// </remarks>
        private Int32 IOWriteMASIRFunctionProcAddUpInitial(ref CustomSerializeArrayList originArray, ref CustomSerializeArrayList paramArray, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = "";
            retItemInfo = "";

            int stockSlipWork_Posi = MakePosition(paramArray, typeof(StockSlipWork), 0);
            int stockDetailWork_Posi = MakePosition(paramArray, typeof(StockDetailWork), 1);

            ArrayList stockDetailWorkList = new ArrayList();   
            StockDetailWork targetStockDetailWork = null;

            if (stockSlipWork_Posi > -1 && stockDetailWork_Posi > -1)
            {
                // 仕入明細データを取得(返品計上対象か在庫登録対象か判断する)
                stockDetailWorkList = paramArray[stockDetailWork_Posi] as ArrayList;
                targetStockDetailWork = stockDetailWorkList[0] as StockDetailWork;

                // ①まず在庫更新返品計上を問わず仕入入力のWriteInitial関数を呼び出す
                //   MAKON01814RA.cs同様
                StockSlipWork stockSlipWork = paramArray[stockSlipWork_Posi] as StockSlipWork;

                if (targetStockDetailWork == null || stockSlipWork == null)
                {
                    retMsg = "仕入データ/仕入明細データを取得出来ませんでした。";
                    return status;
                }

                // 伝票番号・共通通番・受注番号はここで取得
                // この先は共通部品
                status = this.stockSlipDB.WriteInitial(_origin, ref originArray, ref paramArray, stockSlipWork_Posi, ""/*構成ﾌｧｲﾙﾊﾟﾗﾒｰﾀ無し*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
            
                // ②正常終了かつ在庫更新の場合は在庫マスタWriteInitial関数を呼び出す
                //  (在庫マスタ/在庫受払履歴データの更新部品)
                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                     targetStockDetailWork.StockOrderDivCd == 1 &&
                     !string.IsNullOrEmpty(targetStockDetailWork.WarehouseCode.Trim()))
                {
                    status = this.StockUpdateDb.WriteInitial(_origin, ref originArray, ref paramArray, stockSlipWork_Posi, ""/*構成ﾌｧｲﾙﾊﾟﾗﾒｰﾀ無し*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                }
            }

            return status;
        }
        #endregion[計上初期化処理]

        #region[計上Write処理]
        /// <summary>
        /// 返品予定計上伝票データ登録
        /// </summary>
        /// <param name="orgsliplist">登録対象の更新前伝票ヘッダと明細を含むリスト</param>
        /// <param name="newsliplist">登録対象の伝票ヘッダと明細を含むリスト</param>
        /// <param name="otherdatalist">その他の関連伝票データを含むリスト(登録対象データも含む)</param>
        /// <param name="retMsg">メッセージ(主にエラーメッセージ)</param>
        /// <param name="retItemInfo">項目情報(未使用)</param>
        /// <param name="connection">データベース接続オブジェクト</param>
        /// <param name="transaction">トランザクションオブジェクト</param>
        /// <param name="encryptinfo">暗号化キーオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : 2013/01/22  FSI斎藤 和宏</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              仕掛No.1105 仕入返品予定機能追加対応</br>
        /// </remarks>
        private int PurchaseAddUp(ArrayList orgsliplist, ref ArrayList newsliplist, ref ArrayList otherdatalist, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            //●戻り値の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            //●仕入リモートの登録処理を実行する
            status = this.IOWriteDBAddUpA(orgsliplist, ref newsliplist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

            //●登録準備処理にてダミーの発注データがリストに追加されている場合は削除する
            OrderSlipWork orderSlip = SlipListUtils.Find(newsliplist, typeof(OrderSlipWork), ListUtils.FindType.Class) as OrderSlipWork;

            if (orderSlip != null)
            {
                newsliplist.Remove(orderSlip);
            }

            return status;
        }

        /// <summary>
        /// 仕入データ計上登録処理
        /// </summary>
        /// <param name="orgslips">登録対象の元仕入データ及び元仕入明細データを格納するArrayList</param>
        /// <param name="newslips">登録対象の仕入データ及び仕入明細データを格納するArrayList</param>
        /// <param name="retMsg">メッセージ(主にエラーメッセージ)</param>
        /// <param name="retItemInfo">項目情報(未使用)</param>
        /// <param name="connection">データベース接続オブジェクト</param>
        /// <param name="transaction">トランザクションオブジェクト</param>
        /// <param name="encryptinfo">暗号化オブジェクト</param>
        /// <returns>ステータス</returns>
        /// //MAKON01814RA.cs
        private int IOWriteDBAddUpA(ArrayList orgslips, ref ArrayList newslips, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
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
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = IOWriteMASIRFunctionProcAddUp(ref orgSlips, ref cstSlips, ref freeparam, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

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

        /// <summary>
        /// IOWriteを使用した 計上処理メイン
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
        //MAKON01814RA.cs
        private Int32 IOWriteMASIRFunctionProcAddUp(ref CustomSerializeArrayList originArray, ref CustomSerializeArrayList paramArray, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = "";
            retItemInfo = "";

            // パラメータインデックスの取得
            int stockSlipWork_Posi = MakePosition(paramArray, typeof(StockSlipWork), 0);
            int stockDetailWork_Posi = MakePosition(paramArray, typeof(StockDetailWork), 1);

            ArrayList stockDetailWorkList = new ArrayList();   
            StockDetailWork targetStockDetailWork = null;

            if (stockSlipWork_Posi > -1 && stockDetailWork_Posi > -1)
            {
                // 仕入明細データを取得(返品計上対象か在庫登録対象か判断する)
                stockDetailWorkList = paramArray[stockDetailWork_Posi] as ArrayList;
                targetStockDetailWork = stockDetailWorkList[0] as StockDetailWork;

                // 仕入計上の場合は仕入入力のWrite関数を呼び出す
                if (targetStockDetailWork.StockOrderDivCd == 0 && string.IsNullOrEmpty(targetStockDetailWork.WarehouseCode.Trim()))
                {
                    #region 仕入計上時のWrite部品コール
                    StockSlipWork wrkStockSlipWork = paramArray[stockSlipWork_Posi] as StockSlipWork;

                    // 仕入入力Write関数を呼び出す
                    // この先は共通部品
                    status = this.stockSlipDB.Write(_origin, ref originArray, ref paramArray, stockSlipWork_Posi, ""/*構成ﾌｧｲﾙﾊﾟﾗﾒｰﾀ無し*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

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
                    #endregion 仕入計上時のWrite部品コール
                }
                else if (targetStockDetailWork.StockOrderDivCd == 1 && !string.IsNullOrEmpty(targetStockDetailWork.WarehouseCode.Trim()))
                {
                    // このパターンは仕入・仕入履歴・仕入月次集計のテーブルは更新しない。

                    // 商品マスタへの登録
                    int addListPos = -1;  // ダミー
                    status = this.GoodsUserDb.Write(ref paramArray, out addListPos, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                
                    // 商品価格マスタへの登録
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        addListPos = -1;  // ダミー
                        status = this.GoodsPriceUserDb.Write(ref paramArray, out addListPos, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                    }
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 在庫データWrite関数を呼び出す(在庫更新リモートから在庫受払履歴更新リモートを呼び出す)
                        status = this.StockUpdateDb.Write(_origin, ref originArray, ref paramArray, stockSlipWork_Posi, ""/*構成ﾌｧｲﾙﾊﾟﾗﾒｰﾀ無し*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                    }
                }
            }
            return status;
        }

        #endregion[計上Write処理]

        #region[計上に伴うUPDATE処理]

        /// <summary>
        /// 仕入明細データの予定データを更新する。
        /// </summary>
        /// <param name="PurchaseList">仕入リスト</param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        private int UpdateStockDetailForRetPlnData(ArrayList PurchaseList, out string retMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            retMsg = string.Empty;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            if (PurchaseList == null || PurchaseList.Count < 3 )
            {
                retMsg = "UpdateStockDetailForRetPlnData: パラメータが不正です";
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            try
            {
                string sqlText = string.Empty;
                SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                #region[仕入返品予定データ更新のSQL文]
                StringBuilder commandText = new StringBuilder();
                commandText.AppendLine("UPDATE STOCKDETAILRF SET");
                commandText.AppendLine("  UPDATEDATETIMERF=@UPDATEDATETIME,");
                commandText.AppendLine("  UPDEMPLOYEECODERF=@UPDEMPLOYEECODE,");
                commandText.AppendLine("  UPDASSEMBLYID1RF=@UPDASSEMBLYID1,");
                commandText.AppendLine("  UPDASSEMBLYID2RF=@UPDASSEMBLYID2,");
                commandText.AppendLine("  LOGICALDELETECODERF=@LOGICALDELETECODE,");
                commandText.AppendLine("  SALESSLIPDTLNUMSYNCRF=@SALESSLIPDTLNUMSYNC,");
                commandText.AppendLine("  STOCKSLIPDTLNUMSRCRF=@STOCKSLIPDTLNUMSRC");
                commandText.AppendLine("  WHERE");
                commandText.AppendLine("    ENTERPRISECODERF=@FINDENTERPRISECODE AND");
                commandText.AppendLine("    SUPPLIERFORMALRF=@FINDSUPPLIERFORMAL AND");
                // 仕入明細通番・売上明細通番（同時）が登録前リストから取得した値と一致するものをUPDATE
                commandText.AppendLine("    STOCKSLIPDTLNUMRF=@FINDSTOCKSLIPDTLNUMRF AND");
                commandText.AppendLine("    SALESSLIPDTLNUMSYNCRF=@FINDSALESSLIPDTLNUMSYNCRF");
                #endregion[仕入返品予定データ更新のSQL文]

                sqlCommand.CommandText = commandText.ToString();
                sqlCommand.CommandTimeout = 600;

                #region[Prameterオブジェクト]
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraSalesSlipDtlNumSync = sqlCommand.Parameters.Add("@SALESSLIPDTLNUMSYNC", SqlDbType.BigInt);
                SqlParameter paraStockSlipDtlNumSrc = sqlCommand.Parameters.Add("@STOCKSLIPDTLNUMSRC", SqlDbType.BigInt);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                SqlParameter findStockSlipDtlNum = sqlCommand.Parameters.Add("@FINDSTOCKSLIPDTLNUMRF", SqlDbType.BigInt);
                SqlParameter findSalesSlipDtlNumSync = sqlCommand.Parameters.Add("@FINDSALESSLIPDTLNUMSYNCRF", SqlDbType.BigInt);
                #endregion

                // 明細データの中から条件を抽出する
                foreach (object data in PurchaseList)
                {
                    if (data is ArrayList && ((ArrayList)data)[0] != null && ((ArrayList)data)[0] is StockDetailWork)
                    {
                        // 明細情報を取得
                        foreach (object stockDetail in data as ArrayList)
                        {
                            // 更新前の仕入返品予定データ
                            StockDetailWork StockDetailWorkSrc = stockDetail as StockDetailWork;

                            if (StockDetailWorkSrc.StockSlipCdDtl == 2)
                            {
                                // 手数料明細は元の予定データがないからUPDATEしない
                                continue;
                            }
                            else if (StockDetailWorkSrc.SalesSlipDtlNumSync != 0 && StockDetailWorkSrc.StockSlipDtlNum != 0)
                            {
                                //更新ヘッダ情報を設定
                                object obj = (object)this;
                                IFileHeader flhd = (IFileHeader)StockDetailWorkSrc;
                                FileHeader fileHeader = new FileHeader(obj);
                                fileHeader.SetUpdateHeader(ref flhd, obj);

                                //UPDATE用
                                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(StockDetailWorkSrc.UpdateDateTime);
                                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(StockDetailWorkSrc.UpdEmployeeCode);
                                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(StockDetailWorkSrc.UpdAssemblyId1);
                                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(StockDetailWorkSrc.UpdAssemblyId2);
                                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((int)ConstantManagement.LogicalMode.GetData1);
                                // 仕入返品データに格納されている為、
                                // 売上明細通番（同時）と仕入明細通番（元）を0にセット
                                paraSalesSlipDtlNumSync.Value = SqlDataMediator.SqlSetInt64(0);
                                paraStockSlipDtlNumSrc.Value = SqlDataMediator.SqlSetInt64(0);

                                //抽出条件用
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(StockDetailWorkSrc.EnterpriseCode);
                                findParaSupplierFormal.Value = SqlDataMediator.SqlSetInt32(3); // 仕入形式が「3:仕入返品予定」に一致するもの
                                findStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(StockDetailWorkSrc.StockSlipDtlNum); // 仕入明細通番に一致するもの
                                findSalesSlipDtlNumSync.Value = SqlDataMediator.SqlSetInt64(StockDetailWorkSrc.SalesSlipDtlNumSync); // 売上明細通番(同時)に一致するもの

                                if (sqlCommand.ExecuteNonQuery() > 0)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                    continue;
                                }
                                else
                                {
                                    retMsg = "UpdateStockDetailForRetPlnData: 仕入返品予定データの更新に失敗しました";
                                    return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                }
                            }
                            else
                            {
                                retMsg = "UpdateStockDetailForRetPlnData: 売上明細通番（同時）or 仕入明細通番が不正です";
                                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                            }

                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }

            return status;
        }

        /// <summary>
        /// 売上明細データの仕入明細通番(同時)を更新する。
        /// </summary>
        /// <param name="targetStockDetailWork">仕入明細work</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        private int UpdateSalesDetailWork(StockDetailWork targetStockDetailWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            if (targetStockDetailWork == null || targetStockDetailWork.SalesSlipDtlNumSync == 0)
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                StringBuilder commandText = new StringBuilder();

                #region[SQL文]
                commandText.AppendLine("UPDATE SALESDETAILRF SET");
                commandText.AppendLine("  UPDATEDATETIMERF=@UPDATEDATETIME,");
                commandText.AppendLine("  UPDEMPLOYEECODERF=@UPDEMPLOYEECODE,");
                commandText.AppendLine("  UPDASSEMBLYID1RF=@UPDASSEMBLYID1,");
                commandText.AppendLine("  UPDASSEMBLYID2RF=@UPDASSEMBLYID2,");
                commandText.AppendLine("  STOCKSLIPDTLNUMSYNCRF=@STOCKSLIPDTLNUMSYNC");
                commandText.AppendLine("  WHERE");
                commandText.AppendLine("    ENTERPRISECODERF=@FINDENTERPRISECODE AND");
                commandText.AppendLine("    ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS AND");
                commandText.AppendLine("    SALESSLIPDTLNUMRF=@FINDSALESSLIPDTLNUMRF");
                commandText.AppendLine("UPDATE SALESHISTDTLRF SET");
                commandText.AppendLine("  UPDATEDATETIMERF=@UPDATEDATETIME,");
                commandText.AppendLine("  UPDEMPLOYEECODERF=@UPDEMPLOYEECODE,");
                commandText.AppendLine("  UPDASSEMBLYID1RF=@UPDASSEMBLYID1,");
                commandText.AppendLine("  UPDASSEMBLYID2RF=@UPDASSEMBLYID2,");
                commandText.AppendLine("  STOCKSLIPDTLNUMSYNCRF=@STOCKSLIPDTLNUMSYNC");
                commandText.AppendLine("  WHERE");
                commandText.AppendLine("    ENTERPRISECODERF=@FINDENTERPRISECODE AND");
                commandText.AppendLine("    ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS AND");
                commandText.AppendLine("    SALESSLIPDTLNUMRF=@FINDSALESSLIPDTLNUMRF");
                #endregion

                using (SqlCommand sqlCommand = new SqlCommand(commandText.ToString(), sqlConnection, sqlTransaction))
                {
                    //更新ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)targetStockDetailWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);

                    //Prameterオブジェクトの作成(UPDATE句)
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraStockSlipDtlNumSync = sqlCommand.Parameters.Add("@STOCKSLIPDTLNUMSYNC", SqlDbType.BigInt);
                    //Prameterオブジェクトの作成(WHERE句)
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter findSalesSlipDtlNum = sqlCommand.Parameters.Add("@FINDSALESSLIPDTLNUMRF", SqlDbType.BigInt);

                    //KEYコマンドを再設定
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(targetStockDetailWork.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(targetStockDetailWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(targetStockDetailWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(targetStockDetailWork.UpdAssemblyId2);
                    paraStockSlipDtlNumSync.Value = SqlDataMediator.SqlSetInt64(targetStockDetailWork.StockSlipDtlNum);

                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(targetStockDetailWork.EnterpriseCode);
                    findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(targetStockDetailWork.AcptAnOdrStatusSync);
                    findSalesSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(targetStockDetailWork.SalesSlipDtlNumSync); // 売上明細通番(同時)に一致するもの

                    if (sqlCommand.ExecuteNonQuery() > 1)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }

            return status;
        }

        #endregion[計上に伴うUPDATE処理]

        #region[計上に伴う仕入リストデータ調整処理]

        /// <summary>
        /// Initial処理前の仕入リストデータの調整処理を行います
        /// </summary>
        /// <param name="PurchaseList">仕入リスト</param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <param name="connection">データベース接続オブジェクト</param>
        /// <param name="transaction">トランザクションオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : 2013/01/22  FSI斎藤 和宏</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              仕掛No.1105 仕入返品予定機能追加対応</br>
        /// </remarks>
        private int AdjustPurchaseListBeforeInitial(ref ArrayList PurchaseList, out string retMsg, ref SqlConnection connection, ref SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            retMsg = string.Empty;

            if (PurchaseList == null || PurchaseList.Count < 3)
            {
                retMsg = "AdjustPurchaseListBeforeInitial: パラメータが不正です";
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            StockSlipWork stockSlipWork = null;

            // 伝票データと明細データを抽出する
            foreach (object data in PurchaseList)
            {
                if (data is StockSlipWork)
                {
                    // 伝票の場合
                    stockSlipWork = data as StockSlipWork;
                }
                else if (data is ArrayList && ((ArrayList)data)[0] != null && ((ArrayList)data)[0] is StockDetailWork)
                {
                    // 明細リストの場合
                    StockDetailWork targetstockDetailWork = ((ArrayList)data)[0] as StockDetailWork;
                    ArrayList stockDetailWorkList = data as ArrayList;

                    // 返品計上データの場合
                    if (targetstockDetailWork.StockOrderDivCd == 0 &&
                         string.IsNullOrEmpty(targetstockDetailWork.WarehouseCode.Trim()))
                    {
                        // 売上明細データから共通通番検索用のパラメータ
                        ArrayList paraSalesDetailWorkList = new ArrayList();
                        ArrayList RetSalesDetailWorkList = new ArrayList();

                        foreach (object item in stockDetailWorkList)
                        {
                            // 明細データを取得
                            StockDetailWork work = item as StockDetailWork;

                            // 手数料明細はそのまま
                            if (work.StockSlipCdDtl == 2)
                                continue;

                            stockSlipWork.SupplierSlipNo = 0;       // 仕入伝票番号をクリア
                            work.SupplierSlipNo = 0;                // 仕入伝票番号をクリア
                            work.StockSlipDtlNum = 0;               // 仕入明細通番をクリア

                            // 返品個数が変更されているかチェック
                            if (work.StockCount != work.OrderRemainCnt)
                            {
                                work.SalesSlipDtlNumSync = 0;       // 売上明細通番（同時）
                                work.CommonSeqNo = 0;               // 共通通番をクリア
                                work.AcptAnOdrStatusSync = 0;       // 受注ステータス（同時）をクリア

                                // 発注残数も仕入数と同じ値にする
                                work.OrderRemainCnt = work.StockCount;
                            }
                            else
                            {
                                // 個数が変更されていない場合は売上明細データと同期を行う
                                // 共通通番は仕入返品予定データでは新規採番されているので、
                                // 売上明細通番（同時）をキーに元となる売上返品の売上明細データを探して共通通番を取得
                                SalesDetailWork paraSalesDetailWork = new SalesDetailWork();

                                paraSalesDetailWork.EnterpriseCode = work.EnterpriseCode;       // 企業コード
                                paraSalesDetailWork.AcptAnOdrStatus = 30;                       // 受注ステータス
                                paraSalesDetailWork.SalesSlipDtlNum = work.SalesSlipDtlNumSync; // 売上明細通番

                                paraSalesDetailWorkList.Add(paraSalesDetailWork);

                            }
                        }

                        if (paraSalesDetailWorkList.Count > 0)
                        {
                            // 明細データの読み込みが終わってから売上明細を検索
                            status = this.SalesSlipDb.ReadSalesDetailWork(out RetSalesDetailWorkList,
                                                                              paraSalesDetailWorkList,
                                                                          ref connection,
                                                                          ref transaction);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retMsg = "共通通番の取得に失敗しました";
                                return status;
                            }
                            else
                            {
                                // 取得した共通通番を仕入明細データにセット
                                status = this.SetToCommonSeqNoFromSalesDetailWork(ref stockDetailWorkList, RetSalesDetailWorkList);

                                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    retMsg = "共通通番の取得に失敗しました";
                                    return status;
                                }
                            }
                        }
                    }
                    // 在庫登録データの場合
                    else if (targetstockDetailWork.StockOrderDivCd == 1 &&
                         !string.IsNullOrEmpty(targetstockDetailWork.WarehouseCode.Trim()))
                    {
                        // 在庫登録データは最終的に仕入返品データが作成されないので、
                        // 仕入初期化の際に伝票番号が採番されないようにする
                        foreach (object item in data as ArrayList)
                        {
                            StockDetailWork work = item as StockDetailWork;

                            // 手数料明細はそのまま
                            if (work.StockSlipCdDtl == 2)
                                continue;
                            
                            // 在庫に登録される個数を調整
                            work.StockCount *= -1;              // 仕入数を正数にする
                            work.OrderRemainCnt *= -1;          // 発注残数を正数にする

                            work.StockCountDifference = work.StockCount;
                        }
                    }
                    else
                    {
                        retMsg = "UpdateStockDetailForRetPlnData: 倉庫コードが不正です";
                        return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }
                }
                else
                {
                    continue;
                }
            }
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <summary>
        /// 取得した仕入明細データから共通通番をセットします
        /// </summary>
        /// <param name="stockDetailWorkList">仕入明細リスト</param>
        /// <param name="retSalesDetailWorkList">売上明細リスト</param>
        /// <remarks>
        /// <br>Note        : 2013/01/22  FSI斎藤 和宏</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              仕掛No.1105 仕入返品予定機能追加対応</br>
        /// </remarks>
        private int SetToCommonSeqNoFromSalesDetailWork(ref ArrayList stockDetailWorkList, ArrayList retSalesDetailWorkList)
        {
            // パラメータチェック
            if (stockDetailWorkList == null || stockDetailWorkList.Count == 0 ||
                retSalesDetailWorkList == null || retSalesDetailWorkList.Count == 0)
            {
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            // ReadSalesDetailWorkメソッドからのretListは
            // 受注マスタ(車両)データが追加されている場合があるので、
            // SalesSlipDetailWorkのみ取得
            ArrayList SalesDetailWorkList = new ArrayList();

            foreach (object data in retSalesDetailWorkList)
            {
                if (data is ArrayList && ((ArrayList)data)[0] != null && ((ArrayList)data)[0] is SalesDetailWork)
                {
                    SalesDetailWorkList = data as ArrayList;
                    break;
                }
            }

            // 売上明細リストがない場合はエラー
            if (SalesDetailWorkList.Count == 0)
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 共通通番を取得
            foreach (object stockdata in stockDetailWorkList)
            {
                StockDetailWork stockDetailWork = stockdata as StockDetailWork;

                // 仕入明細データが取得できない場合はエラー
                if (stockDetailWork == null)
                    return (int)ConstantManagement.DB_Status.ctDB_ERROR;

                else if (stockDetailWork.StockCount == stockDetailWork.OrderRemainCnt)
                {
                    // 売上明細と同期する場合のみ売上明細リストから共通通番を取得して格納
                    foreach (object salesdataList in SalesDetailWorkList)
                    {
                        SalesDetailWork salesDetailWork = salesdataList as SalesDetailWork;

                        if (salesDetailWork == null)
                            return (int)ConstantManagement.DB_Status.ctDB_ERROR;

                        else if (stockDetailWork.SalesSlipDtlNumSync == salesDetailWork.SalesSlipDtlNum)
                        {
                            stockDetailWork.CommonSeqNo = salesDetailWork.CommonSeqNo;
                            break;
                        }
                    }
                }
                else
                    continue;
            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;

        }
        #endregion[計上に伴う仕入リストデータ調整処理]

        #endregion[計上処理]

        #region[共通処理]

        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }

        /// <summary>
        /// パラメータデータが仕入明細データかチェックします。
        /// </summary>
        /// <param name="item">取得した仕入明細データ</param>
        /// <returns>flag</returns>
        private bool isContainStockDetailWorkData(object item)
        {
            bool ret = false;

            if (item is ArrayList)
            {
                ArrayList slips = item as ArrayList;

                if (SlipListUtils.IsNotEmpty(slips))
                {
                    object findObj = null;

                    // 仕入明細データを検索する(明細で検索するのは発注データが含まれるため)
                    findObj = SlipListUtils.Find(slips, typeof(StockDetailWork), SlipListUtils.FindType.Array);

                    if (findObj != null)
                    {
                        ret = true;
                    }
                }
            }

            return ret;
        }
        #endregion

        # region [シェアチェック処理(DCHNB01864RA.csより流用)]
        /// <br>Update Note: Redmine#23737　仕入伝票入力で、今回締処理中のため登録できませんのを修正する</br>
        /// <br>Programmer : XUJS</br>
        /// <br>Date       : 2011/08/18</br>
        /// <br>Update Note: 売上締次集計処理中に伝票発行不可の修正</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/10</br>
        /// <br>Update Note: 2012/11/09 wangf </br>
        /// <br>           : 10801804-00、12月12日配信分、Redmine#33215 PM.NS障害一覧No.1582の対応</br>
        /// <br>           : 売上伝票入力 締処理中の時売上の排他の対応</br>
        // --- UPD m.suzuki 2010/08/17 ---------->>>>>
        //private void ShareCheckInitialize(ArrayList param, ref ShareCheckInfo info)
        private void ShareCheckInitialize(ArrayList param, ref ShareCheckInfo info, ref SqlConnection connection, ref SqlTransaction transaction)
        // --- UPD m.suzuki 2010/08/17 ----------<<<<<
        {
            if (info == null)
            {
                info = new ShareCheckInfo();
            }

            ShareCheckKey dummyKey = new ShareCheckKey();

            foreach (object item in param)
            {
                if (item is ArrayList)
                {
                    // --- UPD m.suzuki 2010/08/17 ---------->>>>>
                    //this.ShareCheckInitialize((item as ArrayList), ref info);
                    this.ShareCheckInitialize((item as ArrayList), ref info, ref connection, ref transaction);
                    // --- UPD m.suzuki 2010/08/17 ----------<<<<<
                    continue;
                }
                // --- ADD m.suzuki 2010/08/17 ----------<<<<<
                // --- ADD XUJS 2011/08/18 ---------->>>>>
                // 仕入データ
                else if (item is StockSlipWork)
                {
                    // 締次ロック
                    dummyKey.EnterpriseCode = (item as StockSlipWork).EnterpriseCode;
                    dummyKey.SectionCode = (item as StockSlipWork).SectionCode;
                    dummyKey.AddUpUpdDate = ToLongDate((item as StockSlipWork).StockAddUpADate);
                    dummyKey.TotalDay = 0;

                    // 仕入先の締日(DD)を取得する
                    SupplierDB supplierDB = new SupplierDB();
                    SupplierWork supplier = new SupplierWork();
                    supplier.EnterpriseCode = (item as StockSlipWork).EnterpriseCode;
                    supplier.SupplierCd = (item as StockSlipWork).SupplierCd;
                    int ret = supplierDB.Read(ref supplier, 0, ref connection, ref transaction);

                    if (ret == 0)
                    {
                        int supplierTotalDay = 0;
                        supplierTotalDay = supplier.PaymentTotalDay;
                        dummyKey.TotalDay = supplierTotalDay;
                    }

                    // 失敗した場合はロックのキーを追加しない
                    if (dummyKey.TotalDay == 0)
                    {
                        continue;
                    }
                }
                // --- ADD XUJS 2011/08/17 ----------<<<<< 
                // 仕入明細データ
                else if (item is StockDetailWork)
                {
                    dummyKey.EnterpriseCode = (item as StockDetailWork).EnterpriseCode;
                    dummyKey.SectionCode = (item as StockDetailWork).SectionCode;
                    dummyKey.WarehouseCode = (item as StockDetailWork).WarehouseCode;
                }
                else
                {
                    continue;
                }

                if (!info.Keys.Exists(delegate(ShareCheckKey key)
                                      {
                                          return key.EnterpriseCode == dummyKey.EnterpriseCode &&
                                              // --- ADD m.suzuki 2010/08/17 ---------->>>>>
                                                 key.Type == ShareCheckType.Section &&
                                              // --- ADD m.suzuki 2010/08/17 ----------<<<<<
                                                 key.SectionCode == dummyKey.SectionCode;
                                      }))
                {
                    info.Keys.Add(dummyKey.EnterpriseCode, ShareCheckType.Section, dummyKey.SectionCode, "");
                }

                // -- ADD 2011/02/21 --------------------->>>
                if (dummyKey.WarehouseCode != "")
                {
                    // -- ADD 2011/02/21 ---------------------<<<
                    if (!info.Keys.Exists(delegate(ShareCheckKey key)
                                          {
                                              return key.EnterpriseCode == dummyKey.EnterpriseCode &&
                                                     key.WarehouseCode == dummyKey.WarehouseCode;
                                          }))
                    {
                        info.Keys.Add(dummyKey.EnterpriseCode, ShareCheckType.WareHouse, "", dummyKey.WarehouseCode);
                    }
                }  // ADD 2011/02/21

                // --- ADD m.suzuki 2010/08/17 ---------->>>>>
                // 締次ロックキー追加
                if (dummyKey.TotalDay != 0)
                {
                    //--- ADD yangmj 2012/05/10  売上締次集計処理中に伝票発行不可の修正----->>>>>
                    // 仕入データ
                    if (item is StockSlipWork)
                    {
                        if (!info.Keys.Exists(delegate(ShareCheckKey key)
                        {
                            return key.Type == ShareCheckType.SupUpSlip &&
                                   key.EnterpriseCode == dummyKey.EnterpriseCode &&
                                   key.SectionCode == dummyKey.SectionCode &&
                                   key.TotalDay == dummyKey.TotalDay &&
                                   key.AddUpUpdDate == dummyKey.AddUpUpdDate;
                        }))
                        {
                            info.Keys.Add(new ShareCheckKey(dummyKey.EnterpriseCode, ShareCheckType.SupUpSlip, dummyKey.SectionCode, "", dummyKey.TotalDay, dummyKey.AddUpUpdDate));
                        }

                    }
                    else
                    {
                        //--- ADD yangmj 2012/05/10  売上締次集計処理中に伝票発行不可の修正-----<<<<<
                        if (!info.Keys.Exists(delegate(ShareCheckKey key)
                                                  {
                                                      return key.Type == ShareCheckType.AddUpSlip &&
                                                             key.EnterpriseCode == dummyKey.EnterpriseCode &&
                                                             key.SectionCode == dummyKey.SectionCode &&
                                                             key.TotalDay == dummyKey.TotalDay &&
                                                             key.AddUpUpdDate == dummyKey.AddUpUpdDate;
                                                  }))
                        {
                            info.Keys.Add(new ShareCheckKey(dummyKey.EnterpriseCode, ShareCheckType.AddUpSlip, dummyKey.SectionCode, "", dummyKey.TotalDay, dummyKey.AddUpUpdDate));
                        }
                    } //ADD yangmj 2012/05/10 売上締次集計処理中に伝票発行不可の修正

                }
                // --- ADD m.suzuki 2010/08/17 ----------<<<<<
            }

        }
        // --- ADD m.suzuki 2010/08/17 ---------->>>>>
        /// <summary>
        /// 日付変換処理
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private int ToLongDate(DateTime dateTime)
        {
            try
            {
                return (dateTime.Year * 10000 + dateTime.Month * 100 + dateTime.Day);
            }
            catch
            {
                return 0;
            }
        }
        // --- ADD m.suzuki 2010/08/17 ----------<<<<<
        # endregion

        # region [伝票パラメータリスト操作処理]
        /// <summary>
        /// List ユーティリティクラス
        /// </summary>
        private class SlipListUtils : ListUtils
        {
            /*
            /// <summary>検索パターン Find() で使用</summary>
            public enum FindType
            {
                /// <summary>クラス</summary>
                Class,
                /// <summary>Array</summary>
                Array
            }
            */
            /// <summary>検索対象項目 FindSlipDetail() で使用</summary>
            public enum FindItem
            {
                /// <summary>通常</summary>
                Normal,
                /// <summary>計上元</summary>
                Source,
                /// <summary>同時計上</summary>
                Synchronize,
                /// <summary>UOE発注</summary>
                UoeOrder
                # region [2008/06/05 M.Kubota --- PM.NSにおける仕入売上同時計上の仕様が未定なので凍結する]
#if false
            /// <summary>売上一時</summary>
            SalesTemp
#endif
                # endregion
            }
        }

        /// <summary>
        /// 伝票タイプ
        /// </summary>
        internal enum SlipType : int
        {
            /// <summary>未指定</summary>
            None = -1,
            /// <summary>見積</summary>
            Estimation = 10,
            /// <summary>受注</summary>
            AcceptAnOrder = 20,
            /// <summary>出荷</summary>
            Shipment = 40,
            /// <summary>売上</summary>
            Sales = 30,
            /// <summary>発注</summary>
            Order = 2,
            /// <summary>入荷</summary>
            Arrival = 1,
            /// <summary>仕入</summary>
            Purchase = 0,
            /// <summary>UOE発注</summary>
            UoeOrder = 98,
            /// <summary>売上削除</summary>
            SalesDel = 100,
            /// <summary>仕入削除</summary>
            PurchaseDel = 101,
            /// <summary>在庫調整</summary>
            StockAdjust = 102
            #region [2008/06/05 M.Kubota --- PM.NSにおける仕入売上同時計上の仕様が未定なので凍結する]
            ///// <summary>売上一時(仕入売上同時計上)</summary>            
            //SalesTemp = 99
            #endregion
        }
        # endregion

    }
}

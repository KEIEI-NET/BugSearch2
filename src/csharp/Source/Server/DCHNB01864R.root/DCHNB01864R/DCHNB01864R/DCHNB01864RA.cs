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
    /// 売上・仕入制御リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上・仕入制御リモートオブジェクトの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 21112　久保田　誠</br>
    /// <br>Date       : 2008.02.13</br>
    /// <br></br>
    /// <br>Update Note: 2008.05.30 PM.NS用に修正</br>
    /// <br>           : 1.排他制御の組み込み → 済</br>
    /// <br>           : 2.番号採番時のリトライ組み込み → 済</br>
    /// <br>           : 3.商品マスタ自動登録</br>
    /// <br>           : 4.価格マスタ自動更新</br>
    /// <br>           : 5.月次集計データリアル更新</br>
    /// <br>           : 6.売掛残高更新(与信管理) → 済</br>
    /// <br>           : 7.車輛管理登録 → 済</br>
    /// <br>           : 8.受注マスタ(車両)登録 → 済</br>
    /// <br>           : 9.入金・支払明細登録</br>
    /// <br>           : A.検索見積対応</br>
    /// <br>           : B.ＵＯＥ対応</br>
    /// <br>           : C.仕入売上同時計上機能の凍結 → 済</br>
    /// <br></br>
    /// <br>Update Note: READUNCOMMITTED対応</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2010/06/11</br>
    /// <br></br>
    /// <br>Update Note: 締次ロック対応</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2010/08/17</br>
    /// <br></br>
    /// <br>Update Note: 倉庫０ロックがかかる不具合の修正</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2011/02/21</br>
    /// <br></br>
    /// <br>Update Note: 障害改良対応　計上して登録した売上伝票を削除時にエラーログ出力される件の修正</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2011/04/21</br>
    /// <br></br>
    /// <br>Update Note: Redmine#23737 連番847　仕入伝票入力で、今回締処理中のため登録できませんのを修正する</br>
    /// <br>Programmer : XUJS</br>
    /// <br>Date       : 2011/08/18</br>
    /// <br>Note       : 連番966 仕入明細マスタの同時売上情報をクリアする。</br>
    /// <br>Programmer : 許雁波</br>
    /// <br>Date       : 2011/08/16</br>
    /// <br></br>
    /// <br>Update Note: 障害対応(計上残区分：残さないで同時入力(受注売上)を行うと2重で在庫が更新される)</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2011/12/08</br>
    /// <br>UpdateNote : K2011/12/09 鄧潘ハン</br>
    /// <br>管理番号   : 10703874-00</br>
    /// <br>作成内容   : イスコ個別対応</br>
    /// <br>Update Note: 2012/05/10  yangmj</br>
    /// <br>           : 売上締次集計処理中に伝票発行不可の修正</br>
    /// <br></br>
    /// <br>Update Note: 障害対応(「受注計上残区分：残さない」で計上した売上伝票が伝票修正で呼出せない障害の修正)</br>
    /// <br>Programmer : 脇田 靖之</br>
    /// <br>Date       : 2012/09/27</br>
    /// <br>Update Note: 2012/11/09 wangf </br>
    /// <br>           : 10801804-00、12月12日配信分、Redmine#33215 PM.NS障害一覧No.1582の対応</br>
    /// <br>           : 売上伝票入力 締処理中の時売上の排他の対応</br>
    /// <br></br>
    /// <br>Update Note: 2012/11/30 脇田 靖之</br>
    /// <br>管理番号   : 10801804-00</br>
    /// <br>             売上仕入同時入力で売上伝票を別々で入力し仕入伝票番号を同一で作成し、</br>
    /// <br>             作成した売上伝票の片方を伝票削除した場合、仕入伝票が呼び出せなくなる件の修正</br>
    /// <br></br>
    /// <br>Update Note: 2014/05/01 宮本 利明</br>
    /// <br>管理番号   : 11070071-00　仕掛一覧 №2257</br>
    /// <br>             計上を含む貸出データの伝票削除を可能にする</br>
    /// <br>Update Note: 2017/03/30 陳艶丹</br>
    /// <br>管理番号   : 11370016-00 Redmine#49164対応</br>
    /// <br>             Tablet伝票が同一セッションIDの場合に重複登録しないように修正</br>
    /// <br>Update Note: 2020/03/25 陳艶丹</br>
    /// <br>管理番号   : 11600006-00 PMKOBETSU-3622対応</br>
    /// <br>             UOE発注送信不具合の対応（アプリケーションロック不具合対応）</br>
    /// </remarks>
    [Serializable]
    public class IOWriteControlDB : RemoteWithAppLockDB, IIOWriteControlDB
    {
        // プログラムID
        //private string _origin = "IOWriteControlDB";

        /// <summary>
        /// 売上・仕入制御オプション
        /// </summary>
        private IOWriteCtrlOptWork _CtrlOptWork = null;

        /// <summary>
        /// 売上・仕入制御オプション プロパティ
        /// </summary>
        private IOWriteCtrlOptWork CtrlOptWork
        {
            get { return this._CtrlOptWork; }

            set
            {
                this._CtrlOptWork = value;
                this._ResourceName = this.GetResourceName(this._CtrlOptWork.EnterpriseCode);
            }
        }
        
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

        # region [使用リモート]
        private IOWriteMASIRDB _purchaseIOWriteDB = null;    // 仕入IOWriter
        private IOWriteMAHNBDB _salesIOWriteDB = null;       // 売上IOWriter
        private IOWriteUOEOdrDtlDB _uoeIOWriteDB = null;     // UOEIOWriter

        # region [2008/06/05 M.Kubota --- PM.NSにおける仕入売上同時計上の仕様が未定なので凍結する]
        //private SalesTempDB _salesTempDB = null;             // 売上一時データリモート
        # endregion

        private StockSlipDB _stockSlipDB = null;             // 仕入リモート
        private SalesSlipDB _salesSlipDB = null;             // 売上リモート
        private StockAdjustDB _stcAdjustDb = null;           // 在庫調整リモート
        private PmTabSessionMngDB _pmTabSessionMngDB = null;   // PMTABセッション管理情報リモート // ADD 2017/03/30 陳艶丹 Redmine#49164対応
        /// <summary>
        /// 仕入IOWriterプロパティ
        /// </summary>
        private IOWriteMASIRDB purchaseIOWriteDB
        {
            get
            {
                if (this._purchaseIOWriteDB == null)
                {
                    // 仕入リモート を生成
                    this._purchaseIOWriteDB = new IOWriteMASIRDB();
                }

                this._purchaseIOWriteDB.IOWriteCtrlOptWork = this.CtrlOptWork;

                return this._purchaseIOWriteDB;
            }
        }

        /// <summary>
        /// 売上IOWriterプロパティ
        /// </summary>
        private IOWriteMAHNBDB salesIOWriteDB
        {
            get
            {
                if (this._salesIOWriteDB == null)
                {
                    // 売上リモート を生成
                    this._salesIOWriteDB = new IOWriteMAHNBDB();
                }

                this._salesIOWriteDB.IOWriteCtrlOptWork = this.CtrlOptWork;

                return this._salesIOWriteDB;
            }
        }

        /// <summary>
        /// UOE I/O Write リモートプロパティ
        /// </summary>
        private IOWriteUOEOdrDtlDB uoeIOWriteDB
        {
            get
            {
                if (this._uoeIOWriteDB == null)
                {
                    this._uoeIOWriteDB = new IOWriteUOEOdrDtlDB();
                }

                return this._uoeIOWriteDB;
            }
        }

        #region [2008/06/05 M.Kubota --- PM.NSにおける仕入売上同時計上の仕様が未定なので凍結する]
        #if false
        /// <summary>
        /// 売上一時リモートプロパティ
        /// </summary>
        private SalesTempDB salesTempDB
        {
            get
            {
                if (this._salesTempDB == null)
                {
                    // 売上一時データリモート を生成
                    this._salesTempDB = new SalesTempDB();
                }

                return this._salesTempDB;
            }
        }
        #endif
        #endregion

        /// <summary>
        /// 仕入リモートプロパティ
        /// </summary>
        private StockSlipDB stockSlipDB
        {
            get
            {
                if (this._stockSlipDB == null)
                {
                    // 仕入リモートを生成
                    this._stockSlipDB = new StockSlipDB();
                }

                return this._stockSlipDB;
            }
        }

        /// <summary>
        /// 売上リモートプロパティ
        /// </summary>
        private SalesSlipDB salesSlipDB
        {
            get
            {
                if (this._salesSlipDB == null)
                {
                    // 売上リモートを生成
                    this._salesSlipDB = new SalesSlipDB();
                }

                return this._salesSlipDB;
            }
        }

        /// <summary>
        /// 在庫調整リモート プロパティ
        /// </summary>
        private StockAdjustDB stcAdjustDb
        {
            get
            {
                if (this._stcAdjustDb == null)
                {
                    this._stcAdjustDb = new StockAdjustDB();
                }

                return this._stcAdjustDb;
            }
        }

        // ----------- ADD 2017/03/30 陳艶丹 Redmine#49164 ---------------- >>>>
        /// <summary>
        /// PMTABセッション管理情報リモートプロパティ
        /// </summary>
        private PmTabSessionMngDB pmTabSessionMngDB
        {
            get
            {
                if (this._pmTabSessionMngDB == null)
                {
                    // PMTABセッション管理情報リモートを生成
                    this._pmTabSessionMngDB = new PmTabSessionMngDB();
                }

                return this._pmTabSessionMngDB;
            }
        }
        // ----------- ADD 2017/03/30 陳艶丹 Redmine#49164 ---------------- <<<<<

        # endregion

        /// <summary>
        /// 売上・仕入制御リモートオブジェクトDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.02.13</br>
        /// </remarks>
        public IOWriteControlDB()
            :
            base("DCHNB01866D", "Broadleaf.Application.Remoting.ParamData.IOWriteControlDBWork", "IOWRITECONTROLDBRF")
        {
            #if DEBUG
            Console.WriteLine("売上・仕入制御リモートオブジェクト");
            #endif
        }

        //--- ADD 2008/06/06 M.Kubota --->>>
        /// <summary>
        /// 売上・仕入登録時のロックリソース名のみを取得します。
        /// </summary>
        /// <param name="enterprisecode">企業コード</param>
        /// <returns>ロックリソース名</returns>
        public string GetLockResourceName(string enterprisecode)
        {
            return this.GetResourceName(enterprisecode);
        }
        //--- ADD 2008/06/06 M.Kubota ---<<<

        # region [読込処理]

        /// <summary>
        /// エントリ読込
        /// </summary>
        /// <param name="paramlist">読込情報オブジェクトリスト</param>
        /// <param name="retsliplist">読込結果オブジェクト</param>
        /// <param name="retrelationsliplist">関連データオブジェクト</param>
        /// <returns>STATUS</returns>
        public int Read(ref object paramlist, out object retsliplist, out object retrelationsliplist)
        {
            // 戻り値の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            retsliplist = null;
            retrelationsliplist = null;

            SqlConnection connection = null;
            SqlEncryptInfo encryptinfo = null;

            if (SlipListUtils.IsEmpty(paramlist as ArrayList))
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                errmsg += ": 読み込み情報リストが未登録です。";
                base.WriteErrorLog(errmsg, status);
            }
            else
            {
                try
                {
                    ArrayList list = paramlist as ArrayList;

                    ArrayList retslips = null;
                    ArrayList retrelationslips = null;

                    status = this.ReadProc(ref list, out retslips, out retrelationslips, ref connection, ref encryptinfo, true);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        retsliplist = new CustomSerializeArrayList();
                        (retsliplist as CustomSerializeArrayList).AddRange(retslips);

                        retrelationsliplist = new CustomSerializeArrayList();
                        (retrelationsliplist as CustomSerializeArrayList).AddRange(retrelationslips);
                    }
                }
                catch (Exception ex)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(ex, errmsg, status);
                }
                finally
                {
                    # region [暗号化キーのクローズ(保留)]
                    // 暗号化キーのクローズ
                    //if (encryptinfo != null && encryptinfo.IsOpen)
                    //{
                    //    encryptinfo.CloseSymKey(ref connection);
                    //}
                    # endregion

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
        /// 複数伝票読み込み
        /// </summary>
        /// <param name="paramList">読込情報オブジェクトリスト</param>
        /// <param name="retsliplist">読込結果オブジェクト</param>
        /// <returns>STATUS</returns>
        public int ReadMore(ref object paramList, out object retsliplist)
        {
            // 戻り値の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            retsliplist = retList;

            SqlConnection connection = null;
            SqlEncryptInfo encryptinfo = null;

            string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());

            # region [パラメータチェック]

            if (SlipListUtils.IsEmpty(paramList as ArrayList))
            {
                errmsg += ": 読み込み情報リストが未登録です。";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            IOWriteCtrlOptWork optWrk = ListUtils.Find((paramList as ArrayList), typeof(IOWriteCtrlOptWork), ListUtils.FindType.Class) as IOWriteCtrlOptWork;

            if (optWrk == null)
            {
                errmsg += ": 売上・仕入制御オプションが未設定です.";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            int orgStartingPoint =  optWrk.CtrlStartingPoint;

            # endregion

            try
            {
                object readWork = null;
                ArrayList readParam = new ArrayList();

                foreach (object item in paramList as ArrayList)
                {
                    readParam.Clear();
                    readParam.Add(optWrk);
                    readWork = null;

                    if (item is IOWriteMAHNBReadWork)
                    {
                        readWork = item;
                        optWrk.CtrlStartingPoint = (int)IOWriteCtrlOptCtrlStartingPoint.Sales;
                    }
                    else if (item is IOWriteMASIRReadWork)
                    {
                        readWork = item;                        
                        optWrk.CtrlStartingPoint = (int)IOWriteCtrlOptCtrlStartingPoint.Purchase;
                    }

                    if (readWork != null)
                    {
                        readParam.Add(readWork);
                        ArrayList retSlipList = null;
                        ArrayList retRelationList = null;
                        
                        status = this.ReadProc(ref readParam, out retSlipList, out retRelationList, ref connection, ref encryptinfo, false);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            CustomSerializeArrayList retCustomList = new CustomSerializeArrayList();
                            retCustomList.AddRange(retSlipList);
                            retList.Add(retCustomList);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                optWrk.CtrlStartingPoint = orgStartingPoint;

                # region [暗号化キーのクローズ(保留)]
                // 暗号化キーのクローズ
                //if (encryptinfo != null && encryptinfo.IsOpen)
                //{
                //    encryptinfo.CloseSymKey(ref connection);
                //}
                # endregion

                // コネクションの破棄
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramlist"></param>
        /// <param name="retsliplist"></param>
        /// <param name="retrelationsliplist"></param>
        /// <param name="connection"></param>
        /// <param name="encryptinfo"></param>
        /// <param name="readrelation"></param>
        /// <returns></returns>
        private int ReadProc(ref ArrayList paramlist, out ArrayList retsliplist, out ArrayList retrelationsliplist, ref SqlConnection connection, ref SqlEncryptInfo encryptinfo, bool readrelation)
        {
            // 戻り値の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            retsliplist = new ArrayList();
            retrelationsliplist = new ArrayList();

            SqlCommand command = null;

            try
            {
                # region [パラメーターチェック]
                
                //●読込情報リストチェック
                if (SlipListUtils.IsEmpty(paramlist))
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    errmsg += ": 読込情報リストが未登録です。";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●売上・仕入制御オプションチェック
                this.CtrlOptWork = SlipListUtils.Find(paramlist, typeof(IOWriteCtrlOptWork), SlipListUtils.FindType.Class) as IOWriteCtrlOptWork;
               
                if (this.CtrlOptWork == null)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    errmsg += ": 売上・仕入制御オプションが見つかりません。";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●コネクションチェック
                if (connection == null)
                {
                    connection = this.CreateSqlConnection(true);
                }

                if (connection == null)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    errmsg += ": データベースへ接続出来ません。";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                # region 暗号化処理 保留
                //●暗号化キーチェック　(保留)
                //if (encryptinfo == null)
                //{
                //    List<string> ConcatArray = new List<string>();

                //    // 暗号化対象の売上データ系テーブルリストを取得
                //    ConcatArray.AddRange(IOWriteMAHNBDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Write));
                    
                //    // 暗号化対象の仕入データ系テーブルリストを取得
                //    ConcatArray.AddRange(IOWriteMASIRDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Write));
                    
                //    // テーブルリストの結合
                //    string[] tablenames = ConcatArray.ToArray();

                //    encryptinfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, tablenames);
                //}

                //if (encryptinfo == null)
                //{
                //    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                //    errmsg += ": 暗号化キーを作成出来ません。";
                //    base.WriteErrorLog(errmsg, status);
                //    return status;
                //}

                //encryptinfo.OpenSymKey(ref connection);

                //if (!encryptinfo.IsOpen)
                //{
                //    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                //    errmsg += ": 暗号化キーをオープン出来ません。";
                //    base.WriteErrorLog(errmsg, status);
                //    return status;
                //}
                # endregion

                //●制御起点に応じて読込オブジェクトをリストより取得する
                IOWriteMAHNBReadWork salesReadWork = null;
                IOWriteMASIRReadWork stockReadWork = null;

                if (this.CtrlOptWork.CtrlStartingPoint == (int)IOWriteCtrlOptCtrlStartingPoint.Sales)
                {
                    salesReadWork = SlipListUtils.Find(paramlist, typeof(IOWriteMAHNBReadWork), SlipListUtils.FindType.Class) as IOWriteMAHNBReadWork;
                    
                    if (salesReadWork == null)
                    {
                        string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                        errmsg += ": 売上データ読込オブジェクトが登録されていません。";
                        base.WriteErrorLog(errmsg, status);
                        return status;
                    }
                }
                else if (this.CtrlOptWork.CtrlStartingPoint == (int)IOWriteCtrlOptCtrlStartingPoint.Purchase)
                {

                    stockReadWork = SlipListUtils.Find(paramlist, typeof(IOWriteMASIRReadWork), SlipListUtils.FindType.Class) as IOWriteMASIRReadWork;
                    
                    if (stockReadWork == null)
                    {
                        string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                        errmsg += ": 仕入データ読込オブジェクトが登録されていません。";
                        base.WriteErrorLog(errmsg, status);
                        return status;
                    }
                }
                else
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    errmsg += ": 売上・仕入制御オプションの制御起点に誤りがあります。";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }
                # endregion

                # region [指定伝票データの読込]
                CustomSerializeArrayList readparam = new CustomSerializeArrayList();
                readparam.AddRange(paramlist);

                CustomSerializeArrayList readresult = null;

                //●読込対象の伝票データを取得する
                if (this.CtrlOptWork.CtrlStartingPoint == (int)IOWriteCtrlOptCtrlStartingPoint.Sales)
                {
                    // 売上伝票データを読み込む
                    status = this.salesIOWriteDB.Read(ref readparam, out readresult, ref connection);
                }
                else
                {
                    // 仕入伝票データを読み込む
                    status = this.purchaseIOWriteDB.Read(ref readparam, out readresult, ref connection);
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 読込結果を格納
                    retsliplist.AddRange(readresult);
                }
                else
                {
                    return status;
                }
                # endregion

                if (readrelation)
                {
                    # region [受注マスタ検索]
                    // 売上データの受注ステータスや仕入データの仕入形式を受注マスタの受注ステータスに変換する辞書
                    Dictionary<int, int> SlipToAodrDic = new Dictionary<int, int>();
                    SlipToAodrDic.Add(10, 1);  // 見積
                    SlipToAodrDic.Add(20, 3);  // 受注
                    SlipToAodrDic.Add(30, 7);  // 売上
                    SlipToAodrDic.Add(40, 5);  // 出荷
                    SlipToAodrDic.Add(0, 6);   // 仕入
                    SlipToAodrDic.Add(1, 4);   // 入荷
                    SlipToAodrDic.Add(2, 2);   // 発注

                    #region [分かりにくいSQL]
                    string sqlText = string.Empty;
                    command = new SqlCommand(sqlText, connection);

                    // 読込対象の伝票番号に紐付く共通通番を取得し、その共通通番で紐付く他伝票番号を取得する
                    // 但し未発行発注データに関しては伝票番号が存在しないため、後述の処理で別途取得する。
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  CASE AODR.ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += "    WHEN 1 THEN  1 + @ORDERWAIT" + Environment.NewLine;
                    sqlText += "    WHEN 3 THEN  2 + @ORDERWAIT" + Environment.NewLine;
                    sqlText += "    WHEN 5 THEN  3 + @ORDERWAIT" + Environment.NewLine;
                    sqlText += "    WHEN 7 THEN  4 + @ORDERWAIT" + Environment.NewLine;
                    sqlText += "    WHEN 8 THEN  5 + @ORDERWAIT" + Environment.NewLine;
                    sqlText += "    WHEN 2 THEN  6" + Environment.NewLine;
                    sqlText += "    WHEN 4 THEN  7" + Environment.NewLine;
                    sqlText += "    WHEN 6 THEN  8" + Environment.NewLine;
                    sqlText += "    WHEN 9 THEN  9" + Environment.NewLine;
                    sqlText += "  END AS ORDERVALUE" + Environment.NewLine;
                    sqlText += " ,CASE AODR.ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += "    WHEN 1 THEN  0" + Environment.NewLine;
                    sqlText += "    WHEN 3 THEN  0" + Environment.NewLine;
                    sqlText += "    WHEN 5 THEN  0" + Environment.NewLine;
                    sqlText += "    WHEN 7 THEN  0" + Environment.NewLine;
                    sqlText += "    WHEN 8 THEN -1" + Environment.NewLine;
                    sqlText += "    WHEN 2 THEN  1" + Environment.NewLine;
                    sqlText += "    WHEN 4 THEN  1" + Environment.NewLine;
                    sqlText += "    WHEN 6 THEN  1" + Environment.NewLine;
                    sqlText += "    WHEN 9 THEN -1" + Environment.NewLine;
                    sqlText += "  END AS SLIPTYPE" + Environment.NewLine;
                    sqlText += " ,AODR.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " ,AODR.ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += " ,AODR.SALESSLIPNUMRF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    // -- UPD 2010/06/11 -------------------------------->>>
                    //sqlText += "  ACCEPTODRRF AS AODR" + Environment.NewLine;
                    sqlText += "  ACCEPTODRRF AS AODR WITH (READUNCOMMITTED)" + Environment.NewLine;
                    // -- UPD 2010/06/11 --------------------------------<<<
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  AODR.ENTERPRISECODERF        = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND AODR.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                    sqlText += "  AND AODR.SECTIONCODERF       = @FINDSECTIONCODE" + Environment.NewLine;
                    sqlText += "  AND AODR.ACPTANODRSTATUSRF  <> @FINDACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += "  AND AODR.COMMONSEQNORF IN (SELECT" + Environment.NewLine;
                    sqlText += "                               ACC1.COMMONSEQNORF" + Environment.NewLine;
                    sqlText += "                             FROM" + Environment.NewLine;
                    // -- UPD 2010/06/11 -------------------------------->>>
                    //sqlText += "                               ACCEPTODRRF AS ACC1 INNER JOIN (SELECT" + Environment.NewLine;
                    sqlText += "                               ACCEPTODRRF AS ACC1 WITH (READUNCOMMITTED) INNER JOIN (SELECT" + Environment.NewLine;
                    // -- UPD 2010/06/11 --------------------------------<<<
                    sqlText += "                                                                 SUB.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "                                                                ,SUB.SECTIONCODERF" + Environment.NewLine;
                    sqlText += "                                                                ,SUB.ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += "                                                                ,SUB.DATAINPUTSYSTEMRF" + Environment.NewLine;
                    sqlText += "                                                                ,SUB.COMMONSEQNORF" + Environment.NewLine;
                    sqlText += "                                                                ,SUB.SLIPDTLNUMRF" + Environment.NewLine;
                    sqlText += "                                                                ,MAX(SUB.SLIPDTLNUMDERIVNORF) AS SLIPDTLNUMDERIVNORF" + Environment.NewLine;
                    sqlText += "                                                               FROM" + Environment.NewLine;
                    // -- UPD 2010/06/11 ------------------------------------------------------------------------->>>
                    //sqlText += "                                                                 ACCEPTODRRF AS SUB" + Environment.NewLine;
                    sqlText += "                                                                 ACCEPTODRRF AS SUB WITH (READUNCOMMITTED)" + Environment.NewLine;
                    // -- UPD 2010/06/11 -------------------------------------------------------------------------<<<
                    sqlText += "                                                               WHERE" + Environment.NewLine;
                    sqlText += "                                                                 SUB.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                    sqlText += "                                                               GROUP BY" + Environment.NewLine;
                    sqlText += "                                                                 SUB.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "                                                                ,SUB.SECTIONCODERF" + Environment.NewLine;
                    sqlText += "                                                                ,SUB.ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += "                                                                ,SUB.DATAINPUTSYSTEMRF" + Environment.NewLine;
                    sqlText += "                                                                ,SUB.COMMONSEQNORF" + Environment.NewLine;
                    sqlText += "                                                                ,SUB.SLIPDTLNUMRF) AS ACC2" + Environment.NewLine;
                    sqlText += "                               ON  ACC1.ENTERPRISECODERF    = ACC2.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "                               AND ACC1.SECTIONCODERF       = ACC2.SECTIONCODERF" + Environment.NewLine;
                    sqlText += "                               AND ACC1.ACPTANODRSTATUSRF   = ACC2.ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += "                               AND ACC1.DATAINPUTSYSTEMRF   = ACC2.DATAINPUTSYSTEMRF" + Environment.NewLine;
                    sqlText += "                               AND ACC1.COMMONSEQNORF       = ACC2.COMMONSEQNORF" + Environment.NewLine;
                    sqlText += "                               AND ACC1.SLIPDTLNUMRF        = ACC2.SLIPDTLNUMRF" + Environment.NewLine;
                    sqlText += "                               AND ACC1.SLIPDTLNUMDERIVNORF = ACC2.SLIPDTLNUMDERIVNORF" + Environment.NewLine;
                    sqlText += "                            WHERE" + Environment.NewLine;
                    sqlText += "                              ACC1.ENTERPRISECODERF        = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "                              AND ACC1.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                    sqlText += "                              AND ACC1.SECTIONCODERF       = @FINDSECTIONCODE" + Environment.NewLine;
                    sqlText += "                              AND ACC1.ACPTANODRSTATUSRF   = @FINDACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += "                              AND ACC1.SALESSLIPNUMRF      = @FINDSALESSLIPNUM" + Environment.NewLine;
                    sqlText += "                              AND ACC1.DATAINPUTSYSTEMRF   = @FINDDATAINPUTSYSTEM)" + Environment.NewLine;
                    sqlText += "GROUP BY" + Environment.NewLine;
                    sqlText += "  AODR.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " ,AODR.ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += " ,AODR.SALESSLIPNUMRF" + Environment.NewLine;
                    sqlText += "ORDER BY" + Environment.NewLine;
                    sqlText += "  ORDERVALUE" + Environment.NewLine;
                    command.CommandText = sqlText;
                    # endregion

                    SqlParameter findEnterpriseCode = command.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);      // 企業コード
                    SqlParameter findLogicalDeleteCode = command.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);  // 論理削除区分
                    SqlParameter findSectionCode = command.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);            // 拠点コード
                    SqlParameter findAcptAnOdrStatus = command.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);      // 受注ステータス
                    SqlParameter findSalesSlipNum = command.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);          // 伝票番号
                    SqlParameter findDataInputSystem = command.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);      // データ入力システム
                    SqlParameter paraOrderwait = command.Parameters.Add("@ORDERWAIT", SqlDbType.Int);                      // 並び順の可変ウェイト

                    AcceptOdrWork aodrWrk = new AcceptOdrWork();

                    if (this.CtrlOptWork.CtrlStartingPoint == (int)IOWriteCtrlOptCtrlStartingPoint.Sales)
                    {
                        SalesSlipWork slip = SlipListUtils.Find(retsliplist, typeof(SalesSlipWork), SlipListUtils.FindType.Class) as SalesSlipWork;

                        if (slip != null)
                        {
                            aodrWrk.EnterpriseCode = slip.EnterpriseCode;                              // 企業コード
                            aodrWrk.LogicalDeleteCode = (int)ConstantManagement.LogicalMode.GetData0;  // 論理削除区分
                            aodrWrk.SectionCode = slip.SectionCode;                                    // 拠点コード
                            aodrWrk.AcptAnOdrStatus = SlipToAodrDic[slip.AcptAnOdrStatus];             // 受注ステータス
                            aodrWrk.SalesSlipNum = slip.SalesSlipNum;                                  // 伝票番号
                            aodrWrk.DataInputSystem = (int)DataInputSystem.PM;                         // データ入力システム
                        }
                        else
                        {
                            return status;
                        }
                    }
                    else
                    {
                        StockSlipWork slip = SlipListUtils.Find(retsliplist, typeof(StockSlipWork), SlipListUtils.FindType.Class) as StockSlipWork;

                        if (slip != null)
                        {
                            aodrWrk.EnterpriseCode = slip.EnterpriseCode;                              // 企業コード
                            aodrWrk.LogicalDeleteCode = (int)ConstantManagement.LogicalMode.GetData0;  // 論理削除区分
                            aodrWrk.SectionCode = slip.SectionCode;                                    // 拠点コード
                            aodrWrk.AcptAnOdrStatus = SlipToAodrDic[slip.SupplierFormal];              // 仕入形式
                            aodrWrk.SalesSlipNum = slip.SupplierSlipNo.ToString();                     // 伝票番号
                            aodrWrk.DataInputSystem = (int)DataInputSystem.PM;                         // データ入力システム
                        }
                        else
                        {
                            return status;
                        }
                    }

                    // SQLパラメータの設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(aodrWrk.EnterpriseCode);
                    findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(aodrWrk.LogicalDeleteCode);
                    findSectionCode.Value = SqlDataMediator.SqlSetString(aodrWrk.SectionCode);
                    findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(aodrWrk.AcptAnOdrStatus);
                    findSalesSlipNum.Value = SqlDataMediator.SqlSetString(aodrWrk.SalesSlipNum);
                    findDataInputSystem.Value = SqlDataMediator.SqlSetInt32(aodrWrk.DataInputSystem);
                    paraOrderwait.Value = this.CtrlOptWork.CtrlStartingPoint == (int)IOWriteCtrlOptCtrlStartingPoint.Sales ? 0 : 10;

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(command));
#endif

                    DataTable aodrtable = new DataTable();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                    try
                    {
                        dataAdapter.Fill(aodrtable);

                        // 受注マスタの受注ステータスを売上データの受注ステータスや仕入データの仕入形式に変換する辞書
                        Dictionary<int, int> AodrToSlipDic = new Dictionary<int, int>();
                        AodrToSlipDic.Add(1, 10);  // 見積
                        AodrToSlipDic.Add(3, 20);  // 受注
                        AodrToSlipDic.Add(7, 30);  // 売上
                        AodrToSlipDic.Add(5, 40);  // 出荷
                        AodrToSlipDic.Add(6, 0);   // 仕入
                        AodrToSlipDic.Add(4, 1);   // 入荷
                        AodrToSlipDic.Add(2, 2);   // 発注

                        foreach (DataRow row in aodrtable.Rows)
                        {
                            readparam = new CustomSerializeArrayList();
                            readresult = new CustomSerializeArrayList();

                            switch ((int)row["SLIPTYPE"])
                            {
                                case 0:
                                    {
                                        # region [売上系データの読込]
                                        // 売上系のデータとして読み込む
                                        salesReadWork = new IOWriteMAHNBReadWork();
                                        salesReadWork.EnterpriseCode = (string)row["ENTERPRISECODERF"];
                                        salesReadWork.AcptAnOdrStatus = AodrToSlipDic[(int)row["ACPTANODRSTATUSRF"]];
                                        salesReadWork.SalesSlipNum = (string)row["SALESSLIPNUMRF"];
                                        // --- ADD 2012/09/27 y.wakita ----->>>>>
                                        salesReadWork.LogicalDeleteCodeFlg = 1;
                                        // --- ADD 2012/09/27 y.wakita -----<<<<<

                                        readparam.Add(salesReadWork);

                                        // 売上伝票データを読み込む
                                        status = this.salesIOWriteDB.Read(ref readparam, out readresult, ref connection);

                                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            // 読込結果を格納
                                            retrelationsliplist.Add(readresult);
                                        }
                                        else
                                        {
                                            return status;
                                        }

                                        break;
                                        # endregion
                                    }
                                case 1:
                                    {
                                        # region [仕入系データの読込]
                                        // 仕入系のデータとして読み込む
                                        stockReadWork = new IOWriteMASIRReadWork();
                                        stockReadWork.EnterpriseCode = (string)row["ENTERPRISECODERF"];
                                        stockReadWork.SupplierFormal = AodrToSlipDic[(int)row["ACPTANODRSTATUSRF"]];
                                        stockReadWork.SupplierSlipNo = int.Parse((string)row["SALESSLIPNUMRF"]);

                                        # region [if (stockReadWork.SupplierFormal == 2 && stockReadWork.SupplierSlipNo == 0)]
                                        if (stockReadWork.SupplierFormal == 2 && stockReadWork.SupplierSlipNo == 0)
                                        {
                                            // 読込対象の伝票番号に紐付く共通通番を取得し、その共通通番で紐付く発注明細データを取得する。
                                            # region [SELECT文]
                                            sqlText = string.Empty;
                                            sqlText += "SELECT" + Environment.NewLine;
                                            sqlText += "  AODR.SLIPDTLNUMRF" + Environment.NewLine;
                                            sqlText += "FROM" + Environment.NewLine;
                                            // -- UPD 2010/06/11 ---------------------------------->>>
                                            //sqlText += "  ACCEPTODRRF AS AODR" + Environment.NewLine;
                                            sqlText += "  ACCEPTODRRF AS AODR WITH (READUNCOMMITTED)" + Environment.NewLine;
                                            // -- UPD 2010/06/11 ----------------------------------<<<
                                            sqlText += "WHERE" + Environment.NewLine;
                                            sqlText += "  AODR.ENTERPRISECODERF        = @FINDENTERPRISECODE" + Environment.NewLine;
                                            sqlText += "  AND AODR.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                                            sqlText += "  AND AODR.SECTIONCODERF       = @FINDSECTIONCODE" + Environment.NewLine;
                                            sqlText += "  AND AODR.ACPTANODRSTATUSRF   = 2" + Environment.NewLine;
                                            sqlText += "  AND AODR.COMMONSEQNORF IN (SELECT" + Environment.NewLine;
                                            sqlText += "                               ACC1.COMMONSEQNORF" + Environment.NewLine;
                                            sqlText += "                             FROM" + Environment.NewLine;
                                            // -- UPD 2010/06/11 ----------------------------------------------->>>
                                            //sqlText += "                               ACCEPTODRRF AS ACC1 INNER JOIN (SELECT" + Environment.NewLine;
                                            sqlText += "                               ACCEPTODRRF AS ACC1 WITH (READUNCOMMITTED) INNER JOIN (SELECT" + Environment.NewLine;
                                            // -- UPD 2010/06/11 -----------------------------------------------<<<
                                            sqlText += "                                                                 SUB.ENTERPRISECODERF" + Environment.NewLine;
                                            sqlText += "                                                                ,SUB.SECTIONCODERF" + Environment.NewLine;
                                            sqlText += "                                                                ,SUB.ACPTANODRSTATUSRF" + Environment.NewLine;
                                            sqlText += "                                                                ,SUB.DATAINPUTSYSTEMRF" + Environment.NewLine;
                                            sqlText += "                                                                ,SUB.COMMONSEQNORF" + Environment.NewLine;
                                            sqlText += "                                                                ,SUB.SLIPDTLNUMRF" + Environment.NewLine;
                                            sqlText += "                                                                ,MAX(SUB.SLIPDTLNUMDERIVNORF) AS SLIPDTLNUMDERIVNORF" + Environment.NewLine;
                                            sqlText += "                                                               FROM" + Environment.NewLine;
                                            // -- UPD 2010/06/11 ------------------------------------------------------------->>>
                                            //sqlText += "                                                                 ACCEPTODRRF AS SUB" + Environment.NewLine;
                                            sqlText += "                                                                 ACCEPTODRRF AS SUB WITH (READUNCOMMITTED)" + Environment.NewLine;
                                            // -- UPD 2010/06/11 -------------------------------------------------------------<<<
                                            sqlText += "                                                               WHERE" + Environment.NewLine;
                                            sqlText += "                                                                 SUB.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                                            sqlText += "                                                               GROUP BY" + Environment.NewLine;
                                            sqlText += "                                                                 SUB.ENTERPRISECODERF" + Environment.NewLine;
                                            sqlText += "                                                                ,SUB.SECTIONCODERF" + Environment.NewLine;
                                            sqlText += "                                                                ,SUB.ACPTANODRSTATUSRF" + Environment.NewLine;
                                            sqlText += "                                                                ,SUB.DATAINPUTSYSTEMRF" + Environment.NewLine;
                                            sqlText += "                                                                ,SUB.COMMONSEQNORF" + Environment.NewLine;
                                            sqlText += "                                                                ,SUB.SLIPDTLNUMRF) AS ACC2" + Environment.NewLine;
                                            sqlText += "                               ON  ACC1.ENTERPRISECODERF    = ACC2.ENTERPRISECODERF" + Environment.NewLine;
                                            sqlText += "                               AND ACC1.SECTIONCODERF       = ACC2.SECTIONCODERF" + Environment.NewLine;
                                            sqlText += "                               AND ACC1.ACPTANODRSTATUSRF   = ACC2.ACPTANODRSTATUSRF" + Environment.NewLine;
                                            sqlText += "                               AND ACC1.DATAINPUTSYSTEMRF   = ACC2.DATAINPUTSYSTEMRF" + Environment.NewLine;
                                            sqlText += "                               AND ACC1.COMMONSEQNORF       = ACC2.COMMONSEQNORF" + Environment.NewLine;
                                            sqlText += "                               AND ACC1.SLIPDTLNUMRF        = ACC2.SLIPDTLNUMRF" + Environment.NewLine;
                                            sqlText += "                               AND ACC1.SLIPDTLNUMDERIVNORF = ACC2.SLIPDTLNUMDERIVNORF" + Environment.NewLine;
                                            sqlText += "                            WHERE" + Environment.NewLine;
                                            sqlText += "                              ACC1.ENTERPRISECODERF        = @FINDENTERPRISECODE" + Environment.NewLine;
                                            sqlText += "                              AND ACC1.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                                            sqlText += "                              AND ACC1.SECTIONCODERF       = @FINDSECTIONCODE" + Environment.NewLine;
                                            sqlText += "                              AND ACC1.ACPTANODRSTATUSRF   = @FINDACPTANODRSTATUS" + Environment.NewLine;
                                            sqlText += "                              AND ACC1.SALESSLIPNUMRF      = @FINDSALESSLIPNUM" + Environment.NewLine;
                                            sqlText += "                              AND ACC1.DATAINPUTSYSTEMRF   = @FINDDATAINPUTSYSTEM)" + Environment.NewLine;
                                            command.CommandText = sqlText;
                                            # endregion

                                            DataTable orderDtlTable = new DataTable();
                                            SqlDataAdapter orderAdapter = new SqlDataAdapter(command);
                                            try
                                            {
                                                orderAdapter.Fill(orderDtlTable);

                                                ArrayList orderdtllist = new ArrayList();

                                                foreach (DataRow orderdtlrow in orderDtlTable.Rows)
                                                {
                                                    StockDetailWork dtl = new StockDetailWork();
                                                    dtl.EnterpriseCode = aodrWrk.EnterpriseCode;
                                                    dtl.SupplierFormal = 2;
                                                    dtl.StockSlipDtlNum = (long)orderdtlrow["SLIPDTLNUMRF"];
                                                    orderdtllist.Add(dtl);
                                                }

                                                if (orderdtllist.Count > 0)
                                                {
                                                    SqlTransaction dummyTran = null;
                                                    ArrayList retOrderDtlList;

                                                    status = this.stockSlipDB.ReadStockDetailWork(out retOrderDtlList, orderdtllist, ref connection, ref dummyTran);

                                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                                    {
                                                        StockSlipWork dummySlip = new StockSlipWork();

                                                        // ダミー仕入データに必要な項目を設定する
                                                        dummySlip.SupplierFormal = 2;                        // 仕入形式 = 2:発注      固定
                                                        dummySlip.SupplierSlipCd = 10;                       // 仕入伝票区分 = 10:仕入 固定

                                                        if (this.CtrlOptWork.CtrlStartingPoint == (int)IOWriteCtrlOptCtrlStartingPoint.Sales)
                                                        {
                                                            SalesSlipWork slip = SlipListUtils.Find(retsliplist, typeof(SalesSlipWork), SlipListUtils.FindType.Class) as SalesSlipWork;
                                                            dummySlip.EnterpriseCode = slip.EnterpriseCode;  // 企業コード
                                                            dummySlip.SectionCode = slip.SectionCode;        // 拠点コード
                                                            dummySlip.SubSectionCode = slip.SubSectionCode;  // 部門コード
                                                        }
                                                        else
                                                        {
                                                            StockSlipWork slip = SlipListUtils.Find(retsliplist, typeof(StockSlipWork), SlipListUtils.FindType.Class) as StockSlipWork;
                                                            dummySlip.EnterpriseCode = slip.EnterpriseCode;  // 企業コード
                                                            dummySlip.SectionCode = slip.SectionCode;        // 拠点コード
                                                            dummySlip.SubSectionCode = slip.SubSectionCode;  // 部門コード
                                                        }

                                                        readresult = new CustomSerializeArrayList();
                                                        readresult.Add(dummySlip);
                                                        readresult.Add(retOrderDtlList);
                                                        retrelationsliplist.Add(readresult);
                                                    }
                                                    else
                                                    {
                                                        return status;
                                                    }
                                                }
                                            }
                                            finally
                                            {
                                                orderAdapter.Dispose();
                                                orderDtlTable.Dispose();
                                            }
                                        }
                                        # endregion
                                        # region [else]
                                        else
                                        {
                                            readparam.Add(stockReadWork);

                                            // 仕入伝票データを読み込む
                                            status = this.purchaseIOWriteDB.Read(ref readparam, out readresult, ref connection);

                                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                            {
                                                // 読込結果を格納
                                                retrelationsliplist.Add(readresult);
                                            }
                                            else
                                            {
                                                return status;
                                            }
                                        }
                                        # endregion
                                        # endregion

                                        # region [UOE発注データの読込]

                                        ArrayList stcDtlList = ListUtils.Find(readresult, typeof(StockDetailWork), ListUtils.FindType.Array) as ArrayList;

                                        if (ListUtils.IsNotEmpty(stcDtlList))
                                        {
                                            ArrayList prmList = new ArrayList();
                                            
                                            // 仕入形式が 2:発注 の場合にのみUOE発注データを読込む
                                            foreach (StockDetailWork stcDtlItem in stcDtlList)
                                            {
                                                // 2009/02/17 MANTIS 11585対応>>>>>>>>>>
                                                //if (stcDtlItem.SupplierFormal == 2)
                                                //オンライン分の場合のみＵＯＥ発注データの読み込みを行う
                                                if (stcDtlItem.SupplierFormal == 2 && stcDtlItem.WayToOrder == 2)
                                                // 2009/02/17 <<<<<<<<<<<<<<<<<<<<<<<<<<
                                                {
                                                    UOEOrderDtlWork uoeOdrDtl = new UOEOrderDtlWork();
                                                    uoeOdrDtl.EnterpriseCode = stcDtlItem.EnterpriseCode;    // 企業コード
                                                    uoeOdrDtl.SupplierFormal = stcDtlItem.SupplierFormal;    // 仕入形式
                                                    uoeOdrDtl.StockSlipDtlNum = stcDtlItem.StockSlipDtlNum;  // 仕入明細通番
                                                    uoeOdrDtl.UOEKind = -1;  // 2009/02/24 MANTIS 11789
                                                    prmList.Add(uoeOdrDtl);
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                            
                                            if (ListUtils.IsNotEmpty(prmList))
                                            {
                                                ArrayList retList = null;
                                                SqlTransaction dummy = null;
                                                status = this.uoeIOWriteDB.Search(prmList, out retList, ref connection, ref dummy);

                                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                                {
                                                    retrelationsliplist.Add(retList);
                                                }

                                            }
                                        }

                                        # endregion

                                        break;
                                    }
                            }
                        }
                    }
                    finally
                    {
                        aodrtable.Dispose();
                        dataAdapter.Dispose();
                    }

                    #endregion

                    #region [2008/06/05 M.Kubota --- PM.NSにおける仕入売上同時計上の仕様が未定なので凍結する]
#if false
                    # region [売上一時データの読込(制御起点が 1:仕入 の場合のみ)]
                if (this._CtrlOptWork.CtrlStartingPoint == (int)IOWriteCtrlOptCtrlStartingPoint.Purchase)
                {
                    ArrayList stockdtllist = SlipListUtils.Find(retsliplist, typeof(StockDetailWork), SlipListUtils.FindType.Array) as ArrayList;

                    if (stockdtllist != null)
                    {
                        ArrayList salestmplist = new ArrayList();

                        foreach (StockDetailWork item in stockdtllist)
                        {
                            if (item != null && item.SalesSlipDtlNumSync != 0)
                            {
                                int index = salestmplist.Add(new SalesTempWork());

                                // 仕入明細の売上明細通番(同時)に登録されている値をキーとしてセットする
                                (salestmplist[index] as SalesTempWork).SalesSlipDtlNum = item.SalesSlipDtlNumSync;
                            }
                        }

                        if (salestmplist.Count > 0)
                        {
                            SqlTransaction dummytran = null;
                            status = this.salesTempDB.Search(ref salestmplist, 0, ConstantManagement.LogicalMode.GetData0, ref connection, ref dummytran);

                            // 売上一時データが見つからない場合もあるのでエラーとはしない
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                salestmplist.Clear();
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && salestmplist.Count > 0)
                            {
                                int index = retrelationsliplist.Add(new CustomSerializeArrayList());
                                (retrelationsliplist[index] as CustomSerializeArrayList).AddRange(salestmplist);
                            }
                        }
                    }
                }
                # endregion
#endif
                    #endregion
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            finally
            {
                if (command != null)
                {
                    command.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 伝票明細データの読み込みを行います。
        /// </summary>
        /// <param name="paraList">伝票明細データを読み込む為の条件(伝票明細クラス)を含むリスト</param>
        /// <param name="retList">読み込んだ伝票明細クラスを含むリスト</param>
        /// <param name="retSynchroList">同時計上されている相手先明細データを含むリスト</param>
        /// <returns>STATUS</returns>
        public int ReadDetail(ref object paraList, out object retList, out object retSynchroList)
        {
            // 戻り値の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            retList = null;
            retSynchroList = null;

            SqlConnection connection = null;
            SqlEncryptInfo encryptinfo = null;
            SqlTransaction transaction = null;

            if (SlipListUtils.IsEmpty(paraList as ArrayList))
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                errmsg += ": 伝票明細読み込み情報リストが未登録です。";
                base.WriteErrorLog(errmsg, status);
            }
            else
            {
                try
                {
                    ArrayList paraArrayList = paraList as ArrayList;
                    ArrayList retArrayList = null;
                    ArrayList retArraySynchroList = null;

                    status = this.ReadDetailProc(ref paraArrayList, out retArrayList, out retArraySynchroList, ref connection, ref transaction, ref encryptinfo);

                    if (retArrayList != null && retArrayList.Count > 0)
                    {
                        retList = new CustomSerializeArrayList();
                        (retList as CustomSerializeArrayList).AddRange(retArrayList);
                    }

                    if (retArraySynchroList != null && retArraySynchroList.Count > 0)
                    {
                        retSynchroList = new CustomSerializeArrayList();
                        (retSynchroList as CustomSerializeArrayList).AddRange(retArraySynchroList);
                    }
                }
                catch (Exception ex)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(ex, errmsg, status);
                }
                finally
                {
                    // 暗号化キーのクローズ (保留9
                    //if (encryptinfo != null && encryptinfo.IsOpen)
                    //{
                    //    encryptinfo.CloseSymKey(ref connection);
                    //}

                    // トランザクションの破棄
                    if (transaction != null)
                    {
                        transaction.Dispose();
                    }

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
        /// 伝票明細データの読み込みを行います。
        /// </summary>
        /// <param name="paraList">伝票明細データを読み込む為の条件(伝票明細クラス)を含むリスト</param>
        /// <param name="retList">読み込んだ伝票明細クラスを含むリスト</param>
        /// <param name="retSynchroList">同時計上されている相手先明細データを含むリスト</param>
        /// <param name="connection">データベース接続情報オブジェクト</param>
        /// <param name="transaction">トランザクション情報オブジェクト</param>
        /// <param name="encryptinfo">暗号化キー情報オブジェクト</param>
        /// <returns>STATUS</returns>
        private int ReadDetailProc(ref ArrayList paraList, out ArrayList retList, out ArrayList retSynchroList, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            // 戻り値の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());

            retList = new ArrayList();
            retSynchroList = new ArrayList();

            SqlCommand command = null;

            try
            {
                # region [パラメーターチェック]

                //●読込情報リストチェック
                if (SlipListUtils.IsEmpty(paraList))
                {
                    errmsg += ": 伝票明細読込情報リストが未登録です。";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●売上・仕入制御オプションチェック
                this.CtrlOptWork = SlipListUtils.Find(paraList, typeof(IOWriteCtrlOptWork), SlipListUtils.FindType.Class) as IOWriteCtrlOptWork;

                if (this.CtrlOptWork == null)
                {
                    errmsg += ": 売上・仕入制御オプションが見つかりません。";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●コネクションチェック
                if (connection == null)
                {
                    connection = this.CreateSqlConnection(true);
                }

                if (connection == null)
                {
                    errmsg += ": データベースへ接続出来ません。";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                # region [暗号化キーチェック 保留]
                //●暗号化キーチェック
                //if (encryptinfo == null)
                //{
                //    List<string> ConcatArray = new List<string>();

                //    // 暗号化対象の売上データ系テーブルリストを取得
                //    ConcatArray.AddRange(IOWriteMAHNBDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Write));

                //    // 暗号化対象の仕入データ系テーブルリストを取得
                //    ConcatArray.AddRange(IOWriteMASIRDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Write));

                //    // テーブルリストの結合
                //    string[] tablenames = ConcatArray.ToArray();

                //    encryptinfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, tablenames);
                //}

                //if (encryptinfo == null)
                //{
                //    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                //    errmsg += ": 暗号化キーを作成出来ません。";
                //    base.WriteErrorLog(errmsg, status);
                //    return status;
                //}

                //encryptinfo.OpenSymKey(ref connection);

                //if (!encryptinfo.IsOpen)
                //{
                //    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                //    errmsg += ": 暗号化キーをオープン出来ません。";
                //    base.WriteErrorLog(errmsg, status);
                //    return status;
                //}

                //●トランザクションチェック
                /*
                if (transaction == null)
                {
                    transaction = this.CreateTransaction(ref connection);
                }

                if (transaction == null)
                {
                    retMsg = "トランザクションを開始できません。";
                    return status;
                }
                */
                # endregion
                # endregion

                # region [主たる伝票明細データ読込]

                //●制御起点に応じて仕入・売上リモートの伝票明細読み込みメソッドを実行する
                if (this.CtrlOptWork.CtrlStartingPoint == (int)IOWriteCtrlOptCtrlStartingPoint.Sales)
                {
                    status = this.salesSlipDB.ReadSalesDetailWork(out retList, paraList, ref connection, ref transaction);
                }
                else if (this.CtrlOptWork.CtrlStartingPoint == (int)IOWriteCtrlOptCtrlStartingPoint.Purchase)
                {
                    ArrayList stcDtlList = null;
                    status = this.stockSlipDB.ReadStockDetailWork(out stcDtlList, paraList, ref connection, ref transaction);
                    retList.Add(stcDtlList);
                }
                else
                {
                    errmsg += ": 売上・仕入制御オプションの制御起点に誤りがあります。";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                # endregion

                # region [同時計上伝票明細データ読み込み]
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList prmSynchroDtlList = new ArrayList();
                    ArrayList retSynchroDtlList = null;

                    ArrayList slpDtlList = null;

                    SalesDetailWork slsDtlWrk = null;
                    StockDetailWork stcDtlWrk = null;

                    //--- ADD 2009/02/05 M.Kubota --->>>
                    UOEOrderDtlWork uoeDtlWrk = null;
                    ArrayList prmUOEOrderDtlList = new ArrayList();
                    //--- ADD 2009/02/05 M.Kubota ---<<<

                    # region [パラメータ作成]
                    // 制御起点が売上の場合
                    if (this.CtrlOptWork.CtrlStartingPoint == (int)IOWriteCtrlOptCtrlStartingPoint.Sales)
                    {
                        // 売上明細データを格納しているArrayListを分離する
                        slpDtlList = ListUtils.Find(retList, typeof(SalesDetailWork), ListUtils.FindType.Array) as ArrayList;

                        // --- ADD m.suzuki 2011/04/21 ---------->>>>>
                        if ( slpDtlList != null )
                        {
                        // --- ADD m.suzuki 2011/04/21 ----------<<<<<
                            foreach ( object slipdtl in slpDtlList )
                            {
                                slsDtlWrk = slipdtl as SalesDetailWork;
                                if ( slsDtlWrk == null ) continue;

                                // 同時計上元の仕入データが存在している場合にのみ設定
                                if ( slsDtlWrk.SupplierFormalSync != -1 && slsDtlWrk.StockSlipDtlNumSync != 0 )
                                {
                                    // 売上明細データから同時計上された仕入明細データの読み込み情報を作成
                                    stcDtlWrk = new StockDetailWork();
                                    stcDtlWrk.EnterpriseCode = slsDtlWrk.EnterpriseCode;
                                    stcDtlWrk.SupplierFormal = slsDtlWrk.SupplierFormalSync;
                                    stcDtlWrk.StockSlipDtlNum = slsDtlWrk.StockSlipDtlNumSync;
                                }

                                if ( stcDtlWrk != null )
                                {
                                    prmSynchroDtlList.Add( stcDtlWrk );
                                    stcDtlWrk = null;
                                }
                            }
                        // --- ADD m.suzuki 2011/04/21 ---------->>>>>
                        }
                        // --- ADD m.suzuki 2011/04/21 ----------<<<<<
                    }
                    // 制御起点が仕入の場合
                    else if (this.CtrlOptWork.CtrlStartingPoint == (int)IOWriteCtrlOptCtrlStartingPoint.Purchase)
                    {
                        // 仕入明細データを格納しているArrayListを分離する
                        slpDtlList = ListUtils.Find(retList, typeof(StockDetailWork), ListUtils.FindType.Array) as ArrayList;

                        foreach (object slipdtl in slpDtlList)
                        {
                            stcDtlWrk = slipdtl as StockDetailWork;
                            if (stcDtlWrk == null) continue;

                            // 同時計上元の売上データが存在している場合にのみ設定
                            if (stcDtlWrk.AcptAnOdrStatusSync != 0 && stcDtlWrk.SalesSlipDtlNumSync != 0)
                            {
                                // 仕入明細データから同時計上された売上明細データの読み込み情報を作成
                                slsDtlWrk = new SalesDetailWork();
                                slsDtlWrk.EnterpriseCode = stcDtlWrk.EnterpriseCode;
                                slsDtlWrk.AcptAnOdrStatus = stcDtlWrk.AcptAnOdrStatusSync;
                                slsDtlWrk.SalesSlipDtlNum = stcDtlWrk.SalesSlipDtlNumSync;
                            }

                            if (slsDtlWrk != null)
                            {
                                prmSynchroDtlList.Add(slsDtlWrk);
                                slsDtlWrk = null;
                            }
                        }
                    }
                    # endregion

                    # region [明細読み込み]
                    if (prmSynchroDtlList.Count > 0)
                    {
                        if (this.CtrlOptWork.CtrlStartingPoint == (int)IOWriteCtrlOptCtrlStartingPoint.Sales)
                        {
                            status = this.stockSlipDB.ReadStockDetailWork(out retSynchroDtlList, prmSynchroDtlList, ref connection, ref transaction);
                        }
                        else if (this.CtrlOptWork.CtrlStartingPoint == (int)IOWriteCtrlOptCtrlStartingPoint.Purchase)
                        {
                            status = this.salesSlipDB.ReadSalesDetailWork(out retSynchroDtlList, prmSynchroDtlList, ref connection, ref transaction);
                        }
                    }
                    # endregion

                    # region [ヘッダ読み込み]
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retSynchroDtlList != null && retSynchroDtlList.Count > 0)
                    {
                        foreach (object synchroDtl in retSynchroDtlList)
                        {
                            object synchroSlip = null;

                            if (this.CtrlOptWork.CtrlStartingPoint == (int)IOWriteCtrlOptCtrlStartingPoint.Sales)
                            {
                                if (synchroDtl is StockDetailWork)
                                {
                                    StockSlipReadWork stockread = new StockSlipReadWork();
                                    stockread.EnterpriseCode = (synchroDtl as StockDetailWork).EnterpriseCode;
                                    stockread.SupplierFormal = (synchroDtl as StockDetailWork).SupplierFormal;
                                    stockread.SupplierSlipNo = (synchroDtl as StockDetailWork).SupplierSlipNo;

                                    // 未発行 発注データの場合はヘッダ情報が存在しない為 ReadStockSlipWork は実行しない
                                    if (stockread.SupplierFormal != 2 || stockread.SupplierSlipNo != 0)
                                    {
                                        StockSlipWork stockslip;
                                        status = this.stockSlipDB.ReadStockSlipWork(out stockslip, stockread, ref connection);
                                        synchroSlip = stockslip;
                                    }
                                    else
                                    {
                                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                    }

                                    //--- ADD 2009/02/05 M.Kubota --->>>
                                    if ((synchroDtl as StockDetailWork).SupplierFormal == 2)
                                    {
                                        // 発注明細の場合はUOE発注明細データの読込み準備をする
                                        uoeDtlWrk = new UOEOrderDtlWork();
                                        uoeDtlWrk.EnterpriseCode = (synchroDtl as StockDetailWork).EnterpriseCode;    // 企業コード
                                        uoeDtlWrk.SupplierFormal = (synchroDtl as StockDetailWork).SupplierFormal;    // 仕入形式
                                        uoeDtlWrk.StockSlipDtlNum = (synchroDtl as StockDetailWork).StockSlipDtlNum;  // 仕入明細通番
                                        
                                        prmUOEOrderDtlList.Add(uoeDtlWrk);
                                    }
                                    //--- ADD 2009/02/05 M.Kubota ---<<<
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            else if (this.CtrlOptWork.CtrlStartingPoint == (int)IOWriteCtrlOptCtrlStartingPoint.Purchase)
                            {
                                if (synchroDtl is SalesDetailWork)
                                {

                                    SalesSlipReadWork salesread = new SalesSlipReadWork();
                                    salesread.EnterpriseCode = (synchroDtl as SalesDetailWork).EnterpriseCode;
                                    salesread.AcptAnOdrStatus = (synchroDtl as SalesDetailWork).AcptAnOdrStatus;
                                    salesread.SalesSlipNum = (synchroDtl as SalesDetailWork).SalesSlipNum;

                                    SalesSlipWork salesslip;

                                    status = this.salesSlipDB.ReadSalesSlipWork(out salesslip, salesread, ref connection);
                                    synchroSlip = salesslip;
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                CustomSerializeArrayList baseList = new CustomSerializeArrayList();

                                if (synchroSlip != null)
                                {
                                    baseList.Add(synchroSlip);
                                }

                                if (synchroDtl != null)
                                {
                                    (baseList[baseList.Add(new ArrayList())] as ArrayList).Add(synchroDtl);
                                    retSynchroList.Add(baseList);
                                }
                            }
                            else
                            {
                                return status;
                            }
                        }
                    }

                    #endregion

                    # region [UOE発注データ読み込み]
                    //--- ADD 2009/02/05 M.Kubota --->>>
                    if (ListUtils.IsNotEmpty(prmUOEOrderDtlList))
                    {
                        ArrayList retUOEList = null;
                        status = this.uoeIOWriteDB.Search(prmUOEOrderDtlList, out retUOEList, ref connection, ref transaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            retSynchroList.Add(retUOEList);
                        }
                    }
                    //--- ADD 2009/02/05 M.Kubota ---<<<
                    # endregion
                }
                # endregion
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
                if (command != null)
                {
                    command.Dispose();
                }
            }

            return status;
        }

        # endregion

        # region [書込処理]

        /// <summary>
        /// 伝票データ登録処理
        /// </summary>
        /// <param name="paraList">更新情報オブジェクトリスト</param>
        /// <param name="retMsg">メッセージ(主にエラーメッセージ)</param>
        /// <param name="retItemInfo">項目情報(未使用)</param>
        /// <returns>STATUS</returns>
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
        /// 伝票データ登録処理
        /// </summary>
        /// <param name="paramlist"></param>
        /// <param name="retMsg">メッセージ(主にエラーメッセージ)</param>
        /// <param name="retItemInfo">項目情報(未使用)</param>
        /// <param name="connection">データベース接続オブジェクト</param>
        /// <param name="transaction">トランザクションオブジェクト</param>
        /// <param name="encryptinfo">暗号化キーオブジェクト</param>
        /// <returns>STATUS</returns>
        public int WriteProc(ref ArrayList paramlist, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {   
            //●戻り値の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;
            // -------- ADD 2017/03/30 陳艶丹 Redmine#49164 ---------------- >>>>>
            ArrayList pmTabSessionMngList = null;
            PmTabSessionMngWork pmTabSessionMngWork = null;
            object resultPmTabSeesionMngObj = null;
            // ------- ADD 2017/03/30 陳艶丹 Redmine#49164 ---------------- <<<<<

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

            // --- ADD 2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
            string enterpriseCode = this.CtrlOptWork.EnterpriseCode;

            // 企業コードが空欄の場合
            if (string.IsNullOrEmpty(enterpriseCode))
            {
                try
                {
                    ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();
                    enterpriseCode = serverLoginInfoAcquisition.EnterpriseCode;

                    // サーバー側共通部品で空欄の企業コードが取得される場合
                    if (string.IsNullOrEmpty(enterpriseCode))
                    {
                        base.WriteErrorLog("IOWriteControlDB.WriteProc:共通部品で企業コードを取得した際に空欄の企業コードが取得されました。", status);
                    }
                }
                catch
                {
                    base.WriteErrorLog("IOWriteControlDB.WriteProc:共通部品で企業コードを取得した際に例外が発生しました。", status);
                }
            }
            // ロックリソース名
            string resNm = this.GetResourceName(enterpriseCode);
            // --- ADD 2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<

            //●コネクションチェック
            if (connection == null)
            {
                connection = this.CreateSqlConnection(true);
            }

            if (connection == null)
            {
                retMsg = "データベースへ接続出来ません。";
                base.WriteErrorLog(string.Format("IOWriteControlDB.WriteProc_connection:{0}", retMsg), status);  // ADD 2020/03/25 陳艶丹　アプリケーションロック不具合対応
                return status;
            }

            # region [--- 暗号化 保留 ---]
            /* --- 保留 ---
            //●暗号化キーチェック
            if (encryptinfo == null)
            {
                List<string> ConcatArray = new List<string>();
                
                // 暗号化対象の売上データ系テーブルリストを取得
                ConcatArray.AddRange(IOWriteMAHNBDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Write));
                
                // 暗号化対象の仕入データ系テーブルリストを取得
                ConcatArray.AddRange(IOWriteMASIRDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Write));
                
                // テーブルリストの結合
                string[] tablenames = ConcatArray.ToArray();

                encryptinfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, tablenames);
            }

            if (encryptinfo == null)
            {
                retMsg = "暗号化キーを作成出来ません。";
                return status;
            }

            encryptinfo.OpenSymKey(ref connection);

            if (!encryptinfo.IsOpen)
            {
                retMsg = "暗号化キーをオープン出来ません。";
                return status;
            }
            */
            # endregion

            //●トランザクションチェック
            if (transaction == null)
            {
                transaction = this.CreateTransaction(ref connection);
            }

            if (transaction == null)
            {
                retMsg = "トランザクションを開始できません。";
                base.WriteErrorLog(string.Format("IOWriteControlDB.WriteProc_transaction:{0}", retMsg), status);  // ADD 2020/03/25 陳艶丹　アプリケーションロック不具合対応
                return status;
            }

            # endregion

            //●制御起点に応じて更新情報リスト内に格納されている伝票データを並び変える                
            SlipTypeComparer sliptypecomparer = new SlipTypeComparer();

            sliptypecomparer.SortType = (this.CtrlOptWork.CtrlStartingPoint == 0) ? SlipTypeComparer.SlipSortType.Sales : SlipTypeComparer.SlipSortType.Purchase;
            paramlist.Sort(sliptypecomparer);

            Hashtable new2org = new Hashtable();

            //●排他ロックを開始する
            #if !DEBUG // Debug時に他の人の迷惑にならない様に…
            ShareCheckInfo info = null;
            // --- UPD m.suzuki 2010/08/17 ---------->>>>>
            //this.ShareCheckInitialize(paramlist, ref info);
            this.ShareCheckInitialize(paramlist, ref info, ref connection, ref transaction);
            // --- UPD m.suzuki 2010/08/17 ----------<<<<<
            // --- ADD 2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
            try
            {
            // --- ADD 2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                status = this.ShareCheck(info, LockControl.Locke, connection, transaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
            // --- ADD 2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "IOWriteControlDB.WriteProc_ShareCheckLocke:" + ex.ToString());
                throw ex;
            }
            // --- ADD 2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<

            // --- ADD 2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
            //status = this.Lock(this.ResourceName, connection, transaction);
            // グローバル変数の代わりにローカルのリソース名を使用する
            status = this.Lock(resNm, connection, transaction);
            // --- ADD 2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<

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
                base.WriteErrorLog(string.Format("IOWriteControlDB.WriteProc_Lock:{0}", retMsg), status);  // ADD 2020/03/25 陳艶丹　アプリケーションロック不具合対応
                return status;
            }
# endif

            try
            {
                // ----------- ADD 2017/03/30 陳艶丹 Redmine#49164 ---------------- >>>>
                // 受渡した引数paramlist分解処理
                status = GetPmtabSessionMng(ref paramlist, ref pmTabSessionMngList);

                if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                {
                    retMsg += "IOWriteControlDB.WriteProc: 伝票データの登録準備処理に失敗しました。(SessionMng)";
                    return status;
                }
                else if (pmTabSessionMngList != null && pmTabSessionMngList.Count > 0)
                {
                    pmTabSessionMngWork = pmTabSessionMngList[0] as PmTabSessionMngWork;
                    // 同一セッションIDの存在チェック
                    status = this.pmTabSessionMngDB.SearchSessionIdProc(pmTabSessionMngWork, out resultPmTabSeesionMngObj, ref connection, ref transaction, out retMsg);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        pmTabSessionMngList.Clear();
                        foreach(PmTabSessionMngWork pmTabWork in (resultPmTabSeesionMngObj as ArrayList))
                        {
                            pmTabSessionMngList.Add(pmTabWork);
                        }
                        retMsg += (!string.IsNullOrEmpty(retMsg) ? "\n" : "") + "IOWriteControlDB.WriteProc: 同一セッションIDが存在します。";
                        return status;
                    }
                    else
                    {
                        retMsg += "IOWriteControlDB.WriteProc: 伝票データの登録準備処理に失敗しました。(SessionId)";
                        return status;
                    }
                }

                // ----------- ADD 2017/03/30 陳艶丹 Redmine#49164 ---------------- <<<<

                //●更新情報リスト内に格納されている伝票データの伝票種類を元に売上・仕入の伝票登録準備処理を呼び出す
                # region [登録データ準備処理]

                foreach (object item in paramlist)
                {
                    if (item is IOWriteCtrlOptWork)
                    {
                        continue;
                    }
                    else
                    {
                        SlipType slipType = SlipListUtils.GetSlipType(item);
                        

                        ArrayList newSliplist = item as ArrayList;
                        ArrayList orgSliplist = null;

                        switch (slipType)
                        {
                            case SlipType.Estimation:
                            case SlipType.AcceptAnOrder:
                            case SlipType.Shipment:
                            case SlipType.Sales:
                                {
                                    // 売上系データ登録準備処理
                                    status = this.SalesWriteInitialize(out orgSliplist, ref newSliplist, ref paramlist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        new2org.Add(newSliplist, orgSliplist);
                                    }
                                    break;
                                }
                            case SlipType.Order:
                            case SlipType.Arrival:
                            case SlipType.Purchase:
                                {
                                    // 仕入系データ登録準備処理
                                    status = this.PurchaseWriteInitialize(out orgSliplist, ref newSliplist, ref paramlist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        new2org.Add(newSliplist, orgSliplist);
                                    }
                                    break;
                                }
                            case SlipType.UoeOrder:
                                {
                                    // UOE発注明細データ登録準備処理
                                    status = this.UoeOrderWriteInitialize(out orgSliplist, ref newSliplist, ref paramlist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        new2org.Add(newSliplist, orgSliplist);
                                    }
                                    break;
                                }
                            case SlipType.StockAdjust:
                                {
                                    // 在庫調整データ登録準備処理
                                    // ※特に無し
                                    break;
                                }
                            case SlipType.PurchaseDel:
                            case SlipType.SalesDel:                        
                                {
                                    // 仕入・売上削除処理
                                    // ※登録準備処理の中で登録済み伝票データを読込んでいる為、削除処理は最初に行う必要がある

                                    int orgCtrlStartingPoint = this.CtrlOptWork.CtrlStartingPoint;

                                    // 伝票削除用パラメータリストの作成
                                    ArrayList delPrm = new ArrayList();
                                    delPrm.Add(this.CtrlOptWork);
                                    delPrm.Add(item);

                                    if (slipType == SlipType.PurchaseDel)
                                    {
                                        // 仕入削除の場合は強制的に制御起点を仕入にする
                                        this.CtrlOptWork.CtrlStartingPoint = (int)IOWriteCtrlOptCtrlStartingPoint.Purchase;
                                    }
                                    else
                                    {
                                        // 売上削除の場合は強制的に制御起点を売上にする
                                        this.CtrlOptWork.CtrlStartingPoint = (int)IOWriteCtrlOptCtrlStartingPoint.Sales;
                                    }

                                    try
                                    {
                                        status = this.DeleteProc(ref delPrm, 1, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                                    }
                                    finally
                                    {
                                        this.CtrlOptWork.CtrlStartingPoint = orgCtrlStartingPoint;
                                    }

                                    break;
                                }
                            #region [2008/06/05 M.Kubota --- PM.NSにおける仕入売上同時計上の仕様が未定なので凍結する]
                            //case SlipType.SalesTemp:
                            //    {
                            //        // 売上一時データ登録準備処理
                            //        status = this.SalesTempWriteInitialize(ref newSliplist, ref paramlist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                            //        break;
                            //    }
                            #endregion
                        }

                        // 登録準備処理に失敗した場合は処理を中断する
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            retMsg += (!string.IsNullOrEmpty(retMsg) ? "\n" : "") + string.Format("IOWriteControlDB.WriteProc: 伝票データの登録準備処理に失敗しました。(SlipType = {0})", Enum.GetName(typeof(SlipType), slipType));
                            break;
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

                            SlipType slipType = SlipListUtils.GetSlipType(newSliplist);

                            switch (slipType)
                            {
                                case SlipType.Estimation:
                                case SlipType.AcceptAnOrder:
                                case SlipType.Shipment:
                                case SlipType.Sales:
                                    {
                                        // 売上系データ登録処理
                                        orgSliplist = new2org[newSliplist] as ArrayList;
                                        status = this.SalesWrite(orgSliplist, ref newSliplist, ref paramlist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

                                        // --------------------- ADD 2017/03/30 陳艶丹 Redmine#49164 ---------------- >>>>
                                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && pmTabSessionMngWork != null)
                                        {
                                            SalesSlipWork slipTab = SlipListUtils.Find(newSliplist, typeof(SalesSlipWork), SlipListUtils.FindType.Class) as SalesSlipWork;

                                            if (slipTab != null)
                                            {
                                                // PMTABセッション管理データの新規追加処理
                                                pmTabSessionMngWork.SalesSlipNum = slipTab.SalesSlipNum;
                                                status = this.pmTabSessionMngDB.WriteSessionMngProc(ref pmTabSessionMngWork, ref connection, ref transaction, out retMsg);
                                                break;
                                            }
                                        }
                                        // --------------------- ADD 2017/03/30 陳艶丹 Redmine#49164 ---------------- <<<<

                                        #region [2008/06/05 M.Kubota --- PM.NSにおける仕入売上同時計上の仕様が未定なので凍結する]
                                        #if false
                                        // 仕入売上同時登録が指定されている際に売上データの登録が完了した場合
                                        // 売上一時データの削除を行う。
                                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                                            this._CtrlOptWork.CtrlStartingPoint == (int)IOWriteCtrlOptCtrlStartingPoint.PurchaseAndSales)
                                        {
                                            ArrayList salestmplist = SlipListUtils.Find(newSliplist, typeof(SalesTempWork), SlipListUtils.FindType.Array) as ArrayList;

                                            if (SlipListUtils.IsNotEmpty(salestmplist))
                                            {
                                                status = this.salesTempDB.Delete(salestmplist, ref connection, ref transaction);
                                            }
                                        }
                                        #endif
                                        #endregion

                                        break;
                                    }
                                case SlipType.Order:
                                case SlipType.Arrival:
                                case SlipType.Purchase:
                                    {
                                        // 仕入系データ登録処理
                                        orgSliplist = new2org[newSliplist] as ArrayList;
                                        status = this.PurchaseWrite(orgSliplist, ref newSliplist, ref paramlist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                                        break;
                                    }
                                case SlipType.StockAdjust:
                                    {
                                        // 在庫調整データ登録処理
                                        object obj = newSliplist;
                                        // 2009/02/25 MANTIS 11807 >>>>>>>>>>>>>>>>
                                        //status = this.stcAdjustDb.Write(ref obj, out retMsg, ref connection, ref transaction);
                                        //IOWriterでシェアチェックをかけるため、在庫仕入ではシェアチェックなしメソッドの呼び出しを行う
                                        status = this.stcAdjustDb.WriteStockAdjustSlipDtl(ref obj, out retMsg, ref connection, ref transaction);
                                        // 2009/02/25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                                        break;
                                    }
                                case SlipType.UoeOrder:
                                    {
                                        // UOE発注データ登録処理    
                                        orgSliplist = new2org[newSliplist] as ArrayList;
                                        status = this.UoeOrderWrite(orgSliplist, ref newSliplist, ref paramlist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                                        break;
                                    }
                                #region [2008/06/05 M.Kubota --- PM.NSにおける仕入売上同時計上の仕様が未定なので凍結する]
                                #if false
                                case SlipType.SalesTemp:
                                    {
                                        // 売上一時データ登録処理
                                        status = this.SalesTempWrite(ref newSliplist, ref paramlist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                                        break;
                                    }
                                #endif
                                #endregion
                            }

                            // 登録処理に失敗した場合は処理を中断する
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retMsg += (!string.IsNullOrEmpty(retMsg) ? "\n" : "") + string.Format("IOWriteControlDB.WriteProc: 伝票データの登録処理に失敗しました。(SlipType = {0})", Enum.GetName(typeof(SlipType), slipType));
                                break;
                            }
                        }
                    }
                }
                
                # endregion
            }
            finally
            {
                #if !DEBUG // Debug時に他の人の迷惑にならない様に…
                // --- UPD 2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                //●排他ロックを解除する
                //this.Release(this.ResourceName, connection, transaction);
                //this.ShareCheck(info, LockControl.Release, connection, transaction);
                int releaseStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                if (connection == null)
                {
                    base.WriteErrorLog("IOWriteControlDB.WriteProc_Release: アプリケーションロック解除前にデータベースに接続できません。", releaseStatus);
                }
                else if (transaction == null)
                {
                    base.WriteErrorLog("IOWriteControlDB.WriteProc_Release: アプリケーションロック解除前にトランザクションが終了しています。", releaseStatus);
                }
                else if (transaction.Connection == null)
                {
                    base.WriteErrorLog("IOWriteControlDB.WriteProc_Release: アプリケーションロック解除前にトランザクションに例外が発生しました。", releaseStatus);
                }
                else
                {
                    //●排他ロックを解除する
                    releaseStatus = this.Release(resNm, connection, transaction);
                    if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        base.WriteErrorLog("IOWriteControlDB.WriteProc_Release: アプリケーションロック解除処理に失敗しました。", releaseStatus);
                    }
                }
                // シェアチェック
                if (connection == null)
                {
                    base.WriteErrorLog("IOWriteControlDB.WriteProc_ShareCheckRelease: シェアチェック解除前にデータベースに接続できません。", releaseStatus);
                }
                else if (transaction == null)
                {
                    base.WriteErrorLog("IOWriteControlDB.WriteProc_ShareCheckRelease: シェアチェック解除前にトランザクションが終了しています。", releaseStatus);
                }
                else if (transaction.Connection == null)
                {
                    base.WriteErrorLog("IOWriteControlDB.WriteProc_ShareCheckRelease: シェアチェック解除前にトランザクションに例外が発生しました。", releaseStatus);
                }
                else
                {
                    // シェアチェック解除
                    releaseStatus = this.ShareCheck(info, LockControl.Release, connection, transaction);
                    if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        base.WriteErrorLog("IOWriteControlDB.WriteProc_ShareCheckRelease: シェアチェック解除処理に失敗しました。", releaseStatus);
                    }
                }
                // --- UPD 2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
#endif
                //●登録準備処理にてダミーの発注データがリストに追加されている場合は削除する
                foreach (object item in paramlist)
                {
                    ArrayList list = item as ArrayList;
                    if (SlipListUtils.IsNotEmpty(list))
                    {
                        OrderSlipWork orderSlip = SlipListUtils.Find(list, typeof(OrderSlipWork), ListUtils.FindType.Class) as OrderSlipWork;

                        if (orderSlip != null)
                        {
                            list.Remove(orderSlip);
                        }
                    }
                }
                // ------- ADD 2017/03/30 陳艶丹 Redmine#49164 ---------------- >>>>>
                // PMTABセッション管理データをメモリ開放する
                pmTabSessionMngWork = null;
                resultPmTabSeesionMngObj = null;
                // ------- ADD 2017/03/30 陳艶丹 Redmine#49164 ---------------- <<<<<
            }

            return status;
        }

        # region [売上データの登録処理]
        /// <summary>
        /// 売上系伝票データ登録初期化処理
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
        private int SalesWriteInitialize(out ArrayList orgsliplist, ref ArrayList newsliplist, ref ArrayList otherdatalist, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            //>>>2011/12/08
            #region 計上元情報を設定
            SlipType slipType = SlipListUtils.GetSlipType(newsliplist);
            if (slipType == SlipType.AcceptAnOrder)
            {
                if (this.salesIOWriteDB.SameInputAcptList == null)
                {
                    ArrayList al = new ArrayList();
                    this.salesIOWriteDB.SameInputAcptList = al;
                    ((ArrayList)this.salesIOWriteDB.SameInputAcptList).Add((ArrayList)newsliplist.Clone());
                }
                else
                {
                    ((ArrayList)this.salesIOWriteDB.SameInputAcptList).Add((ArrayList)newsliplist.Clone());
                }
            }
            #endregion
            //<<<2011/12/08

            //●戻り値の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            //●売上リモートの登録準備処理を実行する
            status = this.salesIOWriteDB.WriteInitialize(out orgsliplist, ref newsliplist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

            //●共通通番・受注番号・売上明細通番を計上先・同時計上先の明細通番へ設定する
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                SalesSlipWork slip = SlipListUtils.Find(newsliplist, typeof(SalesSlipWork), SlipListUtils.FindType.Class) as SalesSlipWork;
                ArrayList slipdtls = SlipListUtils.Find(newsliplist, typeof(SalesDetailWork), SlipListUtils.FindType.Array) as ArrayList;

                if (slip != null && slipdtls != null)
                {
                    //// 赤伝や返品伝票の場合は関連明細に通番を設定しない
                    //if (slip.DebitNoteDiv != 1 && slip.SalesSlipCd != 1)
                    
                    // 赤伝の場合は関連明細に通番を設定しない
                    if (slip.DebitNoteDiv != 1)
                    {
                        // 明細単位で処理を行う
                        foreach (SalesDetailWork salesdtl in slipdtls)
                        {
                            object dtlrelation = null;

                            // 受注ステータス(計上元)でリンクしている明細データを取得する
                            dtlrelation = SlipListUtils.FindSlipDetail(otherdatalist, SlipListUtils.FindItem.Source, (SlipType)Enum.Parse(typeof(SlipType), salesdtl.AcptAnOdrStatus.ToString()), salesdtl.DtlRelationGuid, salesdtl);

                            if (dtlrelation != null)
                            {
                                (dtlrelation as SalesDetailWork).CommonSeqNo = salesdtl.CommonSeqNo;             // 共通通番
                                (dtlrelation as SalesDetailWork).AcceptAnOrderNo = salesdtl.AcceptAnOrderNo;     // 受注番号
                                (dtlrelation as SalesDetailWork).SalesSlipDtlNumSrc = salesdtl.SalesSlipDtlNum;  // 売上明細通番(計上元)
                            }

                            // 受注ステータスでリンクしているUOE発注明細データを取得する
                            dtlrelation = SlipListUtils.FindSlipDetail(otherdatalist, SlipListUtils.FindItem.UoeOrder, (SlipType)Enum.Parse(typeof(SlipType), salesdtl.AcptAnOdrStatus.ToString()), salesdtl.DtlRelationGuid, salesdtl);

                            if (dtlrelation != null)
                            {
                                (dtlrelation as UOEOrderDtlWork).CommonSeqNo = salesdtl.CommonSeqNo;             // 共通通番
                                (dtlrelation as UOEOrderDtlWork).SalesSlipNum = salesdtl.SalesSlipNum;           // 売上伝票番号(受注伝票番号)
                                (dtlrelation as UOEOrderDtlWork).AcptAnOdrStatus = salesdtl.AcptAnOdrStatus;     // 受注ステータス(20:受注)
                                (dtlrelation as UOEOrderDtlWork).SalesSlipDtlNum = salesdtl.SalesSlipDtlNum;     // 売上明細通番
                            }

                            // 仕入形式(同時計上)でリンクしている明細データを取得する
                            dtlrelation = SlipListUtils.FindSlipDetail(otherdatalist, SlipListUtils.FindItem.Synchronize, (SlipType)Enum.Parse(typeof(SlipType), salesdtl.AcptAnOdrStatus.ToString()), salesdtl.DtlRelationGuid, salesdtl);

                            if (dtlrelation != null)
                            {
                                (dtlrelation as StockDetailWork).CommonSeqNo = salesdtl.CommonSeqNo;             // 共通通番
                                (dtlrelation as StockDetailWork).AcceptAnOrderNo = salesdtl.AcceptAnOrderNo;     // 受注番号
                                (dtlrelation as StockDetailWork).SalesSlipDtlNumSync = salesdtl.SalesSlipDtlNum; // 売上明細通番(同時)
                            }
                        }
                    }
                }
                else
                {
                    retMsg += (string.IsNullOrEmpty(retMsg) ? "" : "\n") + "IOWriteControlDB.SalesWriteInitialize: 売上明細データが設定されていません。";
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
            }

            return status;
        }

        /// <summary>
        /// 売上系伝票データ登録
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
        private int SalesWrite(ArrayList orgsliplist, ref ArrayList newsliplist, ref ArrayList otherdatalist, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            //●戻り値の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            //●売上リモートの登録処理を実行する
            status = this.salesIOWriteDB.WriteA(orgsliplist, ref newsliplist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

            return status;
        }
        # endregion

        # region [仕入データの登録処理]
        /// <summary>
        /// 仕入系伝票データ登録初期化処理
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
                if (SlipListUtils.IsNotEmpty(slipdtls))
                {
                    StockDetailWork orderDetail = (slipdtls[0] as StockDetailWork);

                    // 2009/02/12 >>>>>>>>>>>>>>>>>>>>>> 
                    //卸商仕入受信処理、電話発注の場合の対応
                    //if (orderDetail != null && orderDetail.SupplierFormal == (int)SlipType.Order)
                    if (orderDetail != null && orderDetail.SupplierFormal == (int)SlipType.Order && slip == null)
                    // 2009/02/12 <<<<<<<<<<<<<<<<<<<<<<
                    {
                        // 仕入明細データの仕入形式が 2:発注 で、且つ仕入データが存在しない場合は発注入力とみなす
                        slip = new OrderSlipWork();

                        slip.EnterpriseCode = orderDetail.EnterpriseCode;  // 企業コード
                        slip.SupplierFormal = 2;                           // 仕入形式 = 2:発注      固定
                        slip.SupplierSlipCd = 10;                          // 仕入伝票区分 = 10:仕入 固定
                        slip.SectionCode = orderDetail.SectionCode;        // 拠点コード
                        slip.SubSectionCode = orderDetail.SubSectionCode;  // 部門コード

                        newsliplist.Add(slip);  // ダミーの発注データを登録する
                    }
                }
            }

            //●仕入リモートの登録準備処理を実行する
            status = this.purchaseIOWriteDB.WriteInitialize(out orgsliplist, ref newsliplist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

            //●共通通番・受注番号・仕入明細通番を計上先・同時計上先の明細通番へ設定する
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {

                if (slip != null && slipdtls != null)
                {
                    //// 赤伝や返品伝票の場合は関連明細に通番を設定しない
                    //if (slip.DebitNoteDiv != 1 && slip.SupplierSlipCd != 20)
                    
                    // 赤伝の場合は関連明細に通番を設定しない
                    if (slip.DebitNoteDiv != 1)
                    {
                        // 明細単位で処理を行う
                        foreach (StockDetailWork stockdtl in slipdtls)
                        {
                            object dtlrelation = null;

                            // 仕入形式(計上元)でリンクしている明細データを取得する
                            dtlrelation = SlipListUtils.FindSlipDetail(otherdatalist, SlipListUtils.FindItem.Source, (SlipType)Enum.Parse(typeof(SlipType), stockdtl.SupplierFormal.ToString()), stockdtl.DtlRelationGuid, stockdtl);

                            if (dtlrelation != null)
                            {
                                (dtlrelation as StockDetailWork).CommonSeqNo = stockdtl.CommonSeqNo;             // 共通通番
                                (dtlrelation as StockDetailWork).AcceptAnOrderNo = stockdtl.AcceptAnOrderNo;     // 受注番号
                                (dtlrelation as StockDetailWork).StockSlipDtlNumSrc = stockdtl.StockSlipDtlNum;  // 仕入明細通番(計上元)
                            }

                            // 受注ステータス(同時計上)でリンクしている明細データを取得する
                            dtlrelation = SlipListUtils.FindSlipDetail(otherdatalist, SlipListUtils.FindItem.Synchronize, (SlipType)Enum.Parse(typeof(SlipType), stockdtl.SupplierFormal.ToString()), stockdtl.DtlRelationGuid, stockdtl);

                            if (dtlrelation != null)
                            {
                                (dtlrelation as SalesDetailWork).CommonSeqNo = stockdtl.CommonSeqNo;             // 共通通番
                                (dtlrelation as SalesDetailWork).AcceptAnOrderNo = stockdtl.AcceptAnOrderNo;     // 受注番号
                                (dtlrelation as SalesDetailWork).StockSlipDtlNumSync = stockdtl.StockSlipDtlNum; // 仕入明細通番(同時)
                            }

                            // 仕入形式でリンクしているUOE発注明細データを取得する
                            dtlrelation = SlipListUtils.FindSlipDetail(otherdatalist, SlipListUtils.FindItem.UoeOrder, (SlipType)Enum.Parse(typeof(SlipType), stockdtl.SupplierFormal.ToString()), stockdtl.DtlRelationGuid, stockdtl);

                            // 2008/02/18 入庫更新対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            //if (dtlrelation != null)
                            if (dtlrelation != null && (dtlrelation as UOEOrderDtlWork).StockSlipDtlNum == 0)
                            // 2008/02/18 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            {
                                (dtlrelation as UOEOrderDtlWork).CommonSeqNo = stockdtl.CommonSeqNo;             // 共通通番
                                (dtlrelation as UOEOrderDtlWork).SupplierFormal = stockdtl.SupplierFormal;       // 仕入形式
                                (dtlrelation as UOEOrderDtlWork).SupplierSlipNo = stockdtl.SupplierSlipNo;       // 仕入伝票番号
                                (dtlrelation as UOEOrderDtlWork).StockSlipDtlNum = stockdtl.StockSlipDtlNum;     // 仕入明細通番
                            }

                            #region [2008/06/05 M.Kubota --- PM.NSにおける仕入売上同時計上の仕様が未定なので凍結する]
#if false                            
                            // 明細関連付けGUIDでリンクしている売上一時データを取得する
                            dtlrelation = SlipListUtils.FindSlipDetail(otherdatalist, SlipListUtils.FindItem.SalesTemp, (SlipType)Enum.Parse(typeof(SlipType), stockdtl.SupplierFormal.ToString()), stockdtl.DtlRelationGuid, stockdtl);

                            if (dtlrelation != null)
                            {
                                (dtlrelation as SalesTempWork).CommonSeqNo = stockdtl.CommonSeqNo;             // 共通通番
                                (dtlrelation as SalesTempWork).AcceptAnOrderNo = stockdtl.AcceptAnOrderNo;     // 受注番号
                                (dtlrelation as SalesTempWork).StockSlipDtlNumSync = stockdtl.StockSlipDtlNum; // 仕入明細通番(同時)
                                (dtlrelation as SalesTempWork).StockUpdateSecCd = slip.StockUpdateSecCd;       // 在庫更新拠点コード
                            }
#endif
                            #endregion
                        }
                    }
                }
                else
                {
                    retMsg += (string.IsNullOrEmpty(retMsg) ? "" : "\n") + "IOWriteControlDB.PurchaseWriteInitialize: 仕入明細データが設定されていません。";
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
            }

            return status;
        }

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
        private int PurchaseWrite(ArrayList orgsliplist, ref ArrayList newsliplist, ref ArrayList otherdatalist, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            //●戻り値の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            //●仕入リモートの登録処理を実行する
            status = this.purchaseIOWriteDB.WriteA(orgsliplist, ref newsliplist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

            //●登録準備処理にてダミーの発注データがリストに追加されている場合は削除する
            OrderSlipWork orderSlip = SlipListUtils.Find(newsliplist, typeof(OrderSlipWork), ListUtils.FindType.Class) as OrderSlipWork;
            
            if (orderSlip != null)
            {
                newsliplist.Remove(orderSlip);
            }

            return status;
        }
        # endregion

        # region [UOE発注データの登録処理]

        /// <summary>
        /// UOE発注データ登録初期化処理
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
        private int UoeOrderWriteInitialize(out ArrayList orgsliplist, ref ArrayList newsliplist, ref ArrayList otherdatalist, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            orgsliplist = null;

            ArrayList UOEOrderDtlList = ListUtils.Find(newsliplist, typeof(UOEOrderDtlWork), ListUtils.FindType.Array) as ArrayList;

            if (ListUtils.IsNotEmpty(UOEOrderDtlList))
            {
                // UOE発注データのシステム区分に応じて、オンライン番号やUOE発注番号の採番処理を行う
                status = this.uoeIOWriteDB.WriteInitial(ref UOEOrderDtlList, ref connection, ref transaction);
            }

            return status;
        }

        /// <summary>
        /// UOE発注データ登録処理
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
        private int UoeOrderWrite(ArrayList orgsliplist, ref ArrayList newsliplist, ref ArrayList otherdatalist, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            ArrayList uoeOrderDtlList = SlipListUtils.Find(newsliplist, typeof(UOEOrderDtlWork), ListUtils.FindType.Array) as ArrayList;

            if (SlipListUtils.IsNotEmpty(uoeOrderDtlList))
            {
                status = this.uoeIOWriteDB.WriteProc(ref uoeOrderDtlList, ref connection, ref transaction);
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            return status;
        }

        # endregion

        # region [2008/06/05 M.Kubota --- PM.NSにおける仕入売上同時計上の仕様が未定なので凍結する]
#if false
        # region [売上一時データの登録処理]
        /// <summary>
        /// 売上一時データ登録初期化処理
        /// </summary>
        /// <param name="sliplist">登録対象の伝票ヘッダと明細を含むリスト</param>
        /// <param name="otherdatalist">その他の関連伝票データを含むリスト(登録対象データも含む)</param>
        /// <param name="retMsg">メッセージ(主にエラーメッセージ)</param>
        /// <param name="retItemInfo">項目情報(未使用)</param>
        /// <param name="connection">データベース接続オブジェクト</param>
        /// <param name="transaction">トランザクションオブジェクト</param>
        /// <param name="encryptinfo">暗号化キーオブジェクト</param>
        /// <returns>STATUS</returns>
        private int SalesTempWriteInitialize(ref ArrayList sliplist, ref ArrayList otherdatalist, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            //●戻り値の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            //●売上一時データリモートの登録準備処理を実行する
            status = this.salesTempDB.WriteInitialize(ref sliplist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

            //●売上明細通番を同時計上先の明細通番へ設定する
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 明細単位で処理を行う
                foreach (object item in sliplist)
                {
                    SalesTempWork slstmpdtl = item as SalesTempWork;
                    
                    if (slstmpdtl != null)
                    {
                        // 仕入形式(同時計上)でリンクしている明細データを取得する
                        object dtlrelation = SlipListUtils.FindSlipDetail(otherdatalist, SlipListUtils.FindItem.Synchronize, (SlipType)Enum.Parse(typeof(SlipType), slstmpdtl.AcptAnOdrStatus.ToString()), slstmpdtl.DtlRelationGuid, slstmpdtl);

                        if (dtlrelation != null)
                        {
                            (dtlrelation as StockDetailWork).SalesSlipDtlNumSync = slstmpdtl.SalesSlipDtlNum;  // 売上明細通番(同時)
                        }
                    }
                }
            }

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                retMsg += (string.IsNullOrEmpty(retMsg) ? "" : "\n") + "IOWriteControlDB.SalesTempWriteInitialize: 売上一時データが設定されていません。";
            }

            return status;
        }

        /// <summary>
        /// 売上一時データ登録処理
        /// </summary>
        /// <param name="sliplist">登録対象の伝票ヘッダと明細を含むリスト</param>
        /// <param name="otherdatalist">その他の関連伝票データを含むリスト(登録対象データも含む)</param>
        /// <param name="retMsg">メッセージ(主にエラーメッセージ)</param>
        /// <param name="retItemInfo">項目情報(未使用)</param>
        /// <param name="connection">データベース接続オブジェクト</param>
        /// <param name="transaction">トランザクションオブジェクト</param>
        /// <param name="encryptinfo">暗号化キーオブジェクト</param>
        /// <returns>STATUS</returns>
        private int SalesTempWrite(ref ArrayList sliplist, ref ArrayList otherdatalist, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            //●戻り値の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            //●売上一時リモートの登録準備処理を実行する
            status = this.salesTempDB.Write(ref sliplist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

            return status;
        }
        # endregion
#endif
        # endregion

        // --------------------- ADD 2017/03/30 陳艶丹 Redmine#49164 ---------------- >>>>
        # region [PMタブレット判断]
        /// <summary>
        /// 引数paramlist分解処理
        /// </summary>
        /// <param name="paramlist">更新情報リスト</param>
        /// <param name="pmTabSeesinMngList">PMTABセッション管理データリスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 受渡した引数paramlist分解処理する。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/03/30</br>
        /// </remarks>
        private int GetPmtabSessionMng(ref ArrayList paramlist, ref ArrayList pmTabSeesinMngList)
        {
            //●戻り値の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            PmTabSessionMngWork pmTabSeesinMngWork = null;
            pmTabSeesinMngList = null;

            try
            {
                //paramlist分解処理
                foreach (object item in paramlist)
                {
                    if (item is IOWriteCtrlOptWork)
                    {
                        continue;
                    }
                    else
                    {
                        if (item is ArrayList)
                        {
                            ArrayList slips = item as ArrayList;
                            if (SlipListUtils.IsNotEmpty(slips))
                            {
                                foreach (object subItem in slips)
                                {
                                    if (subItem is ArrayList)
                                    {
                                        ArrayList subSlips = subItem as ArrayList;
                                        if (SlipListUtils.IsNotEmpty(subSlips))
                                        {
                                            // PMTABセッション管理データを検索する
                                            pmTabSeesinMngWork = SlipListUtils.Find(subSlips, typeof(PmTabSessionMngWork), SlipListUtils.FindType.Class) as PmTabSessionMngWork;

                                            if (pmTabSeesinMngWork != null)
                                            {
                                                pmTabSeesinMngList = subSlips;
                                                break;
                                            }
                                        }
                                    }
                                }

                                if (pmTabSeesinMngList != null)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        #endregion
        // --------------------- ADD 2017/03/30 陳艶丹 Redmine#49164 ---------------- <<<<
        # endregion

        # region [削除処理]

        /// <summary>
        /// エントリ物理削除
        /// </summary>
        /// <param name="paraList">物理削除情報オブジェクトリスト</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <returns>STATUS</returns>
        public int Delete(ref object paraList, out string retMsg, out string retItemInfo)
        {
            // 戻り値の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            SqlConnection connection = null;
            SqlTransaction transaction = null;
            SqlEncryptInfo encryptinfo = null;

            try
            {
                ArrayList paraArraylist = paraList as ArrayList;

                status = this.DeleteProc(ref paraArraylist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

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

                // 暗号化キーのクローズ (保留)
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

            return status;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paraList"></param>
        /// <param name="retMsg"></param>
        /// <param name="retItemInfo"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <param name="encryptinfo"></param>
        /// <returns></returns>
        public int DeleteProc(ref ArrayList paraList, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            return this.DeleteProc(ref paraList, 0, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paraList"></param>
        /// <param name="lockMode">0:通常 0以外:ロックしない</param>
        /// <param name="retMsg"></param>
        /// <param name="retItemInfo"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <param name="encryptinfo"></param>
        /// <br>Note             :   連番966 仕入明細マスタの同時売上情報をクリアする。</br>
        /// <br>Programmer       :   許雁波</br>
        /// <br>Date             :   2011/08/16</br>
        /// </remarks>
        /// <returns></returns>
        private int DeleteProc(ref ArrayList paraList, int lockMode, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            //●戻り値の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            # region [パラメータチェック]

            //●売上・仕入制御オプションチェック
            this.CtrlOptWork = SlipListUtils.Find(paraList, typeof(IOWriteCtrlOptWork), SlipListUtils.FindType.Class) as IOWriteCtrlOptWork;

            if (this.CtrlOptWork == null)
            {
                retMsg = "売上・仕入制御オプションが見つかりません。";
                return status;
            }

            //●コネクションチェック
            if (connection == null)
            {
                connection = this.CreateSqlConnection(true);
            }

            if (connection == null)
            {
                retMsg = "データベースへ接続出来ません。";
                return status;
            }

            # region [●暗号化キーチェック  (保留)]
            //●暗号化キーチェック  (保留)
            //if (encryptinfo == null)
            //{
            //    List<string> ConcatArray = new List<string>();

            //    // 暗号化対象の売上データ系テーブルリストを取得
            //    ConcatArray.AddRange(IOWriteMAHNBDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Write));

            //    // 暗号化対象の仕入データ系テーブルリストを取得
            //    ConcatArray.AddRange(IOWriteMASIRDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Write));

            //    // テーブルリストの結合
            //    string[] tablenames = ConcatArray.ToArray();

            //    encryptinfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, tablenames);
            //}

            //if (encryptinfo == null)
            //{
            //    retMsg = "暗号化キーを作成出来ません。";
            //    return status;
            //}

            //encryptinfo.OpenSymKey(ref connection);

            //if (!encryptinfo.IsOpen)
            //{
            //    retMsg = "暗号化キーをオープン出来ません。";
            //    return status;
            //}
            # endregion

            //●トランザクションチェック
            if (transaction == null)
            {
                transaction = this.CreateTransaction(ref connection);
            }

            if (transaction == null)
            {
                retMsg = "トランザクションを開始できません。";
                return status;
            }

            # endregion

            //●排他ロックを開始する
            #if DEBUG // Debug時に他の人の迷惑にならない様に…
            ShareCheckInfo info = null;
            // --- UPD m.suzuki 2010/08/17 ---------->>>>>
            //this.ShareCheckInitialize(paraList, ref info);
            this.ShareCheckInitialize( paraList, ref info, ref connection, ref transaction );
            // --- UPD m.suzuki 2010/08/17 ----------<<<<<

            if (info.Keys.Count != 0)
            {
                status = this.ShareCheck(info, LockControl.Locke, connection, transaction);
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            if (lockMode == 0)
            {
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
            }
            # endif

            try
            {
                # region [データ削除処理]
                //●更新情報リスト内に格納されている伝票データの伝票種類を元に売上・仕入の伝票削除処理を呼び出す
                CustomSerializeArrayList paracuslist = new CustomSerializeArrayList();

                switch (this.CtrlOptWork.CtrlStartingPoint)
                {
                    case (int)IOWriteCtrlOptCtrlStartingPoint.Sales:
                        {
                            foreach (object listItem in paraList)
                            {
                                int findObjPos = -1;
                                paracuslist.Clear();

                                if (listItem is ArrayList)
                                {
                                    // 売上データ削除用オブジェクトの存在チェック
                                    SlipListUtils.Find((listItem as ArrayList), typeof(IOWriteMAHNBDeleteWork), SlipListUtils.FindType.Class, out findObjPos);

                                    if (findObjPos >= 0)
                                    {
                                        // 売上データの削除処理
                                        paracuslist.AddRange(listItem as ArrayList);
                                        status = this.salesIOWriteDB.Delete(ref paracuslist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                                    }
                                    # region [--- DEL 2008/12/02 ---]
                                    //else if (this.CtrlOptWork.SupplierSlipDelDiv != 0)
                                    //{
                                    //    // 仕入伝票削除区分が設定されている場合、売上データの削除と同時に仕入データの削除も行う
                                    //    SlipListUtils.Find((listItem as ArrayList), typeof(IOWriteMASIRDeleteWork), SlipListUtils.FindType.Class, out findObjPos);

                                    //    if (findObjPos >= 0)
                                    //    {
                                    //        // 入荷・仕入データの削除パラメータを設定
                                    //        paracuslist.AddRange(listItem as ArrayList);
                                    //    }
                                    //    else
                                    //    {
                                    //        SlipListUtils.Find((listItem as ArrayList), typeof(StockDetailWork), SlipListUtils.FindType.Class, out findObjPos);

                                    //        if (findObjPos >= 0 && ((listItem as ArrayList)[findObjPos] as StockDetailWork).SupplierFormal == 2)
                                    //        {
                                    //            IOWriteMASIRDeleteWork dummyIOWriteMASIRDelete = new IOWriteMASIRDeleteWork();

                                    //            // ダミー仕入データに必要な項目を設定する
                                    //            dummyIOWriteMASIRDelete.EnterpriseCode = ((listItem as ArrayList)[findObjPos] as StockDetailWork).EnterpriseCode;  // 企業コード
                                    //            dummyIOWriteMASIRDelete.SupplierFormal = 2;                        // 仕入形式 = 2:発注 固定
                                    //            dummyIOWriteMASIRDelete.SupplierSlipNo = 0;                        // 仕入伝票番号 = 0  固定
                                    //            dummyIOWriteMASIRDelete.DebitNoteDiv = 0;                          // 赤伝区分 = 0:黒伝 固定
                                    //            dummyIOWriteMASIRDelete.UpdateDateTime = DateTime.MinValue;        // 更新日付 = 最小値 固定

                                    //            paracuslist.Add(dummyIOWriteMASIRDelete);
                                    //            paracuslist.Add(listItem as ArrayList);
                                    //        }
                                    //    }

                                    //    if (paracuslist.Count > 0)
                                    //    {
                                    //        status = this.purchaseIOWriteDB.Delete(ref paracuslist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                                    //    }
                                    //}
                                    # endregion
                                    //--- ADD 2008/12/02 --->>>
                                    else
                                    {
                                        // 仕入伝票削除区分が設定されている場合、売上データの削除と同時に仕入データの削除も行う
                                        // 但し削除対象が発注データ(UOE)の場合は仕入伝票削除区分の値に関わらず削除する。

                                        bool uoeOrder = false;

                                        SlipListUtils.Find((listItem as ArrayList), typeof(IOWriteMASIRDeleteWork), SlipListUtils.FindType.Class, out findObjPos);

                                        if (findObjPos >= 0)
                                        {
                                            // 入荷・仕入データの削除パラメータを設定
                                            paracuslist.AddRange(listItem as ArrayList);
                                        }
                                        else
                                        {
                                            SlipListUtils.Find((listItem as ArrayList), typeof(StockDetailWork), SlipListUtils.FindType.Class, out findObjPos);

                                            if (findObjPos >= 0 && ((listItem as ArrayList)[findObjPos] as StockDetailWork).SupplierFormal == 2)
                                            {
                                                // 注文方法 = 2:オンライ発注 にて UOE発注データ とみなす
                                                uoeOrder = ((listItem as ArrayList)[findObjPos] as StockDetailWork).WayToOrder == 2;

                                                IOWriteMASIRDeleteWork dummyIOWriteMASIRDelete = new IOWriteMASIRDeleteWork();

                                                // ダミー仕入データに必要な項目を設定する
                                                dummyIOWriteMASIRDelete.EnterpriseCode = ((listItem as ArrayList)[findObjPos] as StockDetailWork).EnterpriseCode;  // 企業コード
                                                dummyIOWriteMASIRDelete.SupplierFormal = 2;                        // 仕入形式 = 2:発注 固定
                                                dummyIOWriteMASIRDelete.SupplierSlipNo = 0;                        // 仕入伝票番号 = 0  固定
                                                dummyIOWriteMASIRDelete.DebitNoteDiv = 0;                          // 赤伝区分 = 0:黒伝 固定
                                                dummyIOWriteMASIRDelete.UpdateDateTime = DateTime.MinValue;        // 更新日付 = 最小値 固定

                                                paracuslist.Add(dummyIOWriteMASIRDelete);
                                                paracuslist.Add(listItem as ArrayList);
                                            }
                                        }

                                        // 削除パラメータが存在していて、且つUOE発注データ又は
                                        if (paracuslist.Count > 0 && (uoeOrder || this.CtrlOptWork.SupplierSlipDelDiv != 0))
                                        {
                                            status = this.purchaseIOWriteDB.Delete(ref paracuslist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                                        }
                                        // -------------- ADD 連番966 2011/08/16 ----------------->>>>>
                                        if (paracuslist.Count > 0 && (!uoeOrder && this.CtrlOptWork.SupplierSlipDelDiv == 0))
                                        {
                                            status = this.purchaseIOWriteDB.UpdateStockDetailSync(ref paracuslist, ref connection, ref transaction);
                                        }
                                        // -------------- ADD 連番966 2011/08/16 -----------------<<<<<
                                    }
                                    //--- ADD 2008/12/02 ---<<<

                                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        break;
                                    }
                                }
                            }

                            break;
                        }
                    case (int)IOWriteCtrlOptCtrlStartingPoint.Purchase:
                        {
                            paracuslist.AddRange(paraList);
                            status = this.purchaseIOWriteDB.Delete(ref paracuslist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                            break;
                        }
                    default:
                        {
                            retMsg = "売上・仕入制御オプションの制御起点に誤りがあります。";
                            break;
                        }
                }

                // 登録準備処理に失敗した場合は処理を中断する
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retMsg += (!string.IsNullOrEmpty(retMsg) ? "\n" : "") + "IOWriteControlDB.DeleteProc: 伝票データの削除処理に失敗しました。";
                }
                # endregion
            }
            finally
            {
                //●排他ロックを解除する
                #if DEBUG // Debug時に他の人の迷惑にならない様に…

                if (lockMode == 0)
                {
                    this.Release(this.ResourceName, connection, transaction);
                }


                if (info.Keys.Count != 0)
                {
                    this.ShareCheck(info, LockControl.Release, connection, transaction);
                }
                #endif
            }

            return status;
        }

        # endregion

        # region [赤伝処理]

        /// <summary>
        /// 赤伝作成(赤伝作成データを全てパラメータで貰う)
        /// </summary>
        /// <param name="orgList">元黒List</param>
        /// <param name="redList">赤伝List</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <returns>STATUS</returns>
        public int RedWrite(ref object orgList, ref object redList, out string retMsg, out string retItemInfo)
        {
            // 戻り値の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            SqlConnection connection = null;
            SqlTransaction transaction = null;
            SqlEncryptInfo encryptinfo = null;

            try
            {
                ArrayList orgArraylist = orgList as ArrayList;
                ArrayList redArraylist = redList as ArrayList;

                status = this.RedWriteProc(ref orgArraylist, ref redArraylist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

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

                // 暗号化キーのクローズ (保留)
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

            return status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orgList"></param>
        /// <param name="redList"></param>
        /// <param name="retMsg"></param>
        /// <param name="retItemInfo"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <param name="encryptinfo"></param>
        /// <returns></returns>
        public int RedWriteProc(ref ArrayList orgList, ref ArrayList redList, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            //●戻り値の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            # region [パラメータチェック]

            //●売上・仕入制御オプションチェック
            this.CtrlOptWork = SlipListUtils.Find(redList, typeof(IOWriteCtrlOptWork), SlipListUtils.FindType.Class) as IOWriteCtrlOptWork;

            if (this.CtrlOptWork == null)
            {
                retMsg = "売上・仕入制御オプションが見つかりません。";
                return status;
            }

            // --- ADD 2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
            string enterpriseCode = this.CtrlOptWork.EnterpriseCode;

            // 企業コードが空欄の場合
            if (string.IsNullOrEmpty(enterpriseCode))
            {
                try
                {
                    ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();
                    enterpriseCode = serverLoginInfoAcquisition.EnterpriseCode;

                    // サーバー側共通部品で空欄の企業コードが取得される場合
                    if (string.IsNullOrEmpty(enterpriseCode))
                    {
                        base.WriteErrorLog("IOWriteControlDB.RedWriteProc:共通部品で企業コードを取得した際に空欄の企業コードが取得されました。", status);
                    }
                }
                catch
                {
                    base.WriteErrorLog("IOWriteControlDB.RedWriteProc:共通部品で企業コードを取得した際に例外が発生しました。", status);
                }
            }
            // ロックリソース名
            string resNm = this.GetResourceName(enterpriseCode);
            // --- ADD 2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<

            CustomSerializeArrayList orgcslist = new CustomSerializeArrayList();
            orgcslist.AddRange(orgList);

            //●元黒伝票情報リストチェック
            if (SlipListUtils.IsEmpty(orgcslist))
            {
                retMsg = "元黒伝票情報リストが未登録です。";
                return status;
            }

            CustomSerializeArrayList redcslist = new CustomSerializeArrayList();

            switch (this.CtrlOptWork.CtrlStartingPoint)
            {
                case (int)IOWriteCtrlOptCtrlStartingPoint.Sales:
                    {
                        redcslist = SlipListUtils.Find(redList, typeof(SalesSlipWork), SlipListUtils.FindType.Array) as CustomSerializeArrayList;
                        break;
                    }
                case (int)IOWriteCtrlOptCtrlStartingPoint.Purchase:
                    {
                        redcslist = SlipListUtils.Find(redList, typeof(StockSlipWork), SlipListUtils.FindType.Array) as CustomSerializeArrayList;
                        break;
                    }
                default:
                    {
                        retMsg = "売上・仕入制御オプションの制御起点に誤りがあります。";
                        return status;
                    }
            }

            //●赤伝票情報リストチェック
            if (SlipListUtils.IsEmpty(redcslist))
            {
                retMsg = "赤伝票情報リストが未登録です。";
                return status;
            }

            //●コネクションチェック
            if (connection == null)
            {
                connection = this.CreateSqlConnection(true);
            }

            if (connection == null)
            {
                retMsg = "データベースへ接続出来ません。";
                base.WriteErrorLog(string.Format("IOWriteControlDB.RedWriteProc_connection:{0}", retMsg), status);  // ADD 2020/03/25 陳艶丹　アプリケーションロック不具合対応
                return status;
            }

            //●暗号化キーチェック  (保留)
            //if (encryptinfo == null)
            //{
            //    List<string> ConcatArray = new List<string>();

            //    // 暗号化対象の売上データ系テーブルリストを取得
            //    ConcatArray.AddRange(IOWriteMAHNBDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Write));

            //    // 暗号化対象の仕入データ系テーブルリストを取得
            //    ConcatArray.AddRange(IOWriteMASIRDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Write));

            //    // テーブルリストの結合
            //    string[] tablenames = ConcatArray.ToArray();

            //    encryptinfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, tablenames);
            //}

            //if (encryptinfo == null)
            //{
            //    retMsg = "暗号化キーを作成出来ません。";
            //    return status;
            //}

            //encryptinfo.OpenSymKey(ref connection);

            //if (!encryptinfo.IsOpen)
            //{
            //    retMsg = "暗号化キーをオープン出来ません。";
            //    return status;
            //}

            //●トランザクションチェック
            if (transaction == null)
            {
                transaction = this.CreateTransaction(ref connection);
            }

            if (transaction == null)
            {
                retMsg = "トランザクションを開始できません。";
                base.WriteErrorLog(string.Format("IOWriteControlDB.RedWriteProc_transaction:{0}", retMsg), status);  // ADD 2020/03/25 陳艶丹　アプリケーションロック不具合対応
                return status;
            }

            # endregion

            //●排他ロックを開始する
            #if !DEBUG // Debug時に他の人の迷惑にならない様に…
            ShareCheckInfo info = null;
            // --- UPD m.suzuki 2010/08/17 ---------->>>>>
            //this.ShareCheckInitialize(redList, ref info);
            this.ShareCheckInitialize(redList, ref info, ref connection, ref transaction);
            // --- UPD m.suzuki 2010/08/17 ----------<<<<<
            // --- ADD 2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
            try
            {
            // --- ADD 2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                status = this.ShareCheck(info, LockControl.Locke, connection, transaction);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
            // --- UPD 2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "IOWriteControlDB.RedWriteProc_ShareCheckLocke:" + ex.ToString());
                throw ex;
            }

            //status = this.Lock(this.ResourceName, connection, transaction);
            // グローバル変数の代わりにローカルのリソース名を使用する
            status = this.Lock(resNm, connection, transaction);
            // --- UPD 2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<

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
                base.WriteErrorLog(string.Format("IOWriteControlDB.RedWriteProc_Lock:{0}", retMsg), status);  // ADD 2020/03/25 陳艶丹　アプリケーションロック不具合対応

                return status;
            }
# endif

            try
            {
                # region [赤伝登録処理]
                //●更新情報リスト内に格納されている伝票データの伝票種類を元に売上・仕入の赤伝票登録処理を呼び出す
                switch (this.CtrlOptWork.CtrlStartingPoint)
                {
                    case (int)IOWriteCtrlOptCtrlStartingPoint.Sales:
                        {
                            status = this.salesIOWriteDB.RedWrite(ref orgcslist, ref redcslist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                            break;
                        }
                    case (int)IOWriteCtrlOptCtrlStartingPoint.Purchase:
                        {
                            status = this.purchaseIOWriteDB.RedWrite(ref orgcslist, ref redcslist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                            break;
                        }
                }

                // 登録準備処理に失敗した場合は処理を中断する
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retMsg += (!string.IsNullOrEmpty(retMsg) ? "\n" : "") + "IOWriteControlDB.RedWriteProc: 赤伝票データの登録処理に失敗しました。";
                }
                # endregion
            }
            finally
            {
                //●排他ロックを解除する
                #if !DEBUG // Debug時に他の人の迷惑にならない様に…
                // --- UPD 2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                //●排他ロックを解除する
                //this.Release(this.ResourceName, connection, transaction);
                //this.ShareCheck(info, LockControl.Release, connection, transaction);
                int releaseStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                if (connection == null)
                {
                    base.WriteErrorLog("IOWriteControlDB.RedWriteProc_Release: アプリケーションロック解除前にデータベースに接続できません。", releaseStatus);
                }
                else if (transaction == null)
                {
                    base.WriteErrorLog("IOWriteControlDB.RedWriteProc_Release: アプリケーションロック解除前にトランザクションが終了しています。", releaseStatus);
                }
                else if (transaction.Connection == null)
                {
                    base.WriteErrorLog("IOWriteControlDB.RedWriteProc_Release: アプリケーションロック解除前にトランザクションに例外が発生しました。", releaseStatus);
                }
                else
                {
                    // アプリケーションロック解除
                    releaseStatus = this.Release(resNm, connection, transaction);
                    if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        base.WriteErrorLog("IOWriteControlDB.RedWriteProc_Release: アプリケーションロック解除処理に失敗しました。", releaseStatus);
                    }
                }
                // シェアチェック
                if (connection == null)
                {
                    base.WriteErrorLog("IOWriteControlDB.RedWriteProc_ShareCheckRelease: シェアチェック解除前にデータベースに接続できません。", releaseStatus);
                }
                else if (transaction == null)
                {
                    base.WriteErrorLog("IOWriteControlDB.RedWriteProc_ShareCheckRelease: シェアチェック解除前にトランザクションが終了しています。", releaseStatus);
                }
                else if (transaction.Connection == null)
                {
                    base.WriteErrorLog("IOWriteControlDB.RedWriteProc_ShareCheckRelease: シェアチェック解除前にトランザクションに例外が発生しました。", releaseStatus);
                }
                else
                {
                    // シェアチェック解除
                    releaseStatus = this.ShareCheck(info, LockControl.Release, connection, transaction);
                    if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        base.WriteErrorLog("IOWriteControlDB.RedWriteProc_ShareCheckRelease: シェアチェック解除処理に失敗しました。", releaseStatus);
                    }
                }
                // --- UPD 2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                # endif
            }

            return status;
        }
        
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

            /// <summary>
            /// パラメータに指定されたクラスに応じた伝票タイプを取得します。
            /// </summary>
            /// <returns>SlipType</returns>
            public static SlipType GetSlipType(object obj)
            {
                SlipType result = SlipType.None;

                if (obj is ArrayList)
                {
                    ArrayList slips = obj as ArrayList;

                    if (SlipListUtils.IsNotEmpty(slips))
                    {
                        object findObj = null;

                        // 売上明細データを検索する
                        findObj = SlipListUtils.Find(slips, typeof(SalesDetailWork), FindType.Array);

                        if (findObj == null)
                        {
                            // 仕入明細データを検索する(明細で検索するのは発注データが含まれるため)
                            findObj = SlipListUtils.Find(slips, typeof(StockDetailWork), FindType.Array);
                        }

                        if (findObj == null)
                        {
                            // UOE発注明細データを検索する
                            findObj = SlipListUtils.Find(slips, typeof(UOEOrderDtlWork), FindType.Array);
                        }

                        if (findObj == null)
                        {
                            // 仕入削除パラメータ
                            findObj = SlipListUtils.Find(slips, typeof(IOWriteMASIRDeleteWork), FindType.Class);
                        }

                        if (findObj == null)
                        {
                            // 売上削除パラメータ
                            findObj = SlipListUtils.Find(slips, typeof(IOWriteMAHNBDeleteWork), FindType.Class);
                        }

                        if (findObj == null)
                        {
                            // 在庫調整データ
                            // 2009/02/26 買掛無しオプション対応>>>>>>>>>>>>>>>
                            //// 2009/02/10 >>>>>>>>
                            ////findObj = SlipListUtils.Find(slips, typeof(StockAdjustWork), FindType.Array); //DEL
                            ////在庫調整明細データクラスのリストを取得するように修正
                            //findObj = SlipListUtils.Find(slips, typeof(StockAdjustDtlWork), FindType.Array); //ADD
                            //// 2009/02/10 <<<<<<<<

                            ArrayList adjustcs = slips[0] as ArrayList;
                            findObj = SlipListUtils.Find(adjustcs, typeof(StockAdjustDtlWork), FindType.Array); //ADD

                            // 2009/02/26 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        }

                        # region [2008/06/05 M.Kubota --- PM.NSにおける仕入売上同時計上の仕様が未定なので凍結する]
#if false
                if (findObj == null)
                {
                    // 売上一時データを検索する
                    findObj = SlipListUtils.Find(slips, typeof(SalesTempWork), SlipListUtils.FindType.Class);
                }
#endif
                        # endregion

                        if (SlipListUtils.IsNotEmpty(findObj as ArrayList))
                        {
                            findObj = (findObj as ArrayList)[0];
                        }

                        if (findObj is SalesDetailWork)
                        {
                            switch ((findObj as SalesDetailWork).AcptAnOdrStatus)
                            {
                                case (int)SlipType.Estimation:     // 見積
                                    result = SlipType.Estimation;
                                    break;
                                case (int)SlipType.AcceptAnOrder:  // 受注
                                    result = SlipType.AcceptAnOrder;
                                    break;
                                case (int)SlipType.Shipment:       // 出荷
                                    result = SlipType.Shipment;
                                    break;
                                case (int)SlipType.Sales:          // 売上
                                    result = SlipType.Sales;
                                    break;
                            }
                        }
                        else if (findObj is StockDetailWork)
                        {
                            switch ((findObj as StockDetailWork).SupplierFormal)
                            {
                                case (int)SlipType.Order:     // 発注
                                    result = SlipType.Order;
                                    break;
                                case (int)SlipType.Arrival:   // 入荷
                                    result = SlipType.Arrival;
                                    break;
                                case (int)SlipType.Purchase:  // 仕入
                                    result = SlipType.Purchase;
                                    break;
                            }
                        }
                        else if (findObj is UOEOrderDtlWork)
                        {
                            result = SlipType.UoeOrder;  // UOE発注
                        }
                        else if (findObj is StockAdjustDtlWork)
                        {
                            result = SlipType.StockAdjust;  // 在庫調整
                        }
                        # region [2008/06/05 M.Kubota --- PM.NSにおける仕入売上同時計上の仕様が未定なので凍結する]
                        //else if (findObj is SalesTempWork)
                        //{
                        //    result = SlipType.SalesTemp;
                        //}
                        # endregion
                    }
                }
                else if (obj is IOWriteMAHNBDeleteWork)
                {
                    result = SlipType.SalesDel;  // 売上削除
                }
                else if (obj is IOWriteMASIRDeleteWork)
                {
                    result = SlipType.PurchaseDel;  // 仕入削除
                }

                return result;
            }


            /// <summary>
            /// 伝票タイプとGUIDが合致する明細データを取得します。
            /// </summary>
            /// <param name="sliplist">検索対象リスト</param>
            /// <param name="finditem">検索対象項目</param>
            /// <param name="sliptype">伝票タイプ</param>
            /// <param name="guid">明細GUID</param>
            /// <param name="source">検索元明細データ</param>
            /// <returns>オブジェクト</returns>
            public static object FindSlipDetail(ArrayList sliplist, FindItem finditem, SlipType sliptype, Guid guid, object source)
            {
                object retdtil = null;

                foreach (object item in sliplist)
                {
                    if (item is ArrayList)
                    {
                        // 再帰検索を行う
                        retdtil = SlipListUtils.FindSlipDetail(item as ArrayList, finditem, sliptype, guid, source);
                    }
                    else
                    {
                        // 検索元の明細データと異なる場合にのみチェックする
                        if (item != source)
                        {
                            switch (finditem)
                            {
                                case FindItem.Normal:
                                    {
                                        # region [受注ステータス or 仕入形式を検索対象とする]
                                        switch (sliptype)
                                        {
                                            case SlipType.Estimation:     // 見積
                                            case SlipType.AcceptAnOrder:  // 受注
                                            case SlipType.Shipment:       // 出荷
                                            case SlipType.Sales:          // 売上
                                                {
                                                    if (item is SalesDetailWork)
                                                    {
                                                        // 受注ステータスとGUIDをチェックする
                                                        if ((item as SalesDetailWork).AcptAnOdrStatus == (int)sliptype &&
                                                            (item as SalesDetailWork).DtlRelationGuid == guid)
                                                        {
                                                            retdtil = item;
                                                        }
                                                    }

                                                    break;
                                                }
                                            case SlipType.Order:          // 発注
                                            case SlipType.Arrival:        // 入荷
                                            case SlipType.Purchase:       // 仕入
                                                {
                                                    if (item is StockDetailWork)
                                                    {
                                                        // 仕入形式とGUIDをチェックする
                                                        if ((item as StockDetailWork).SupplierFormal == (int)sliptype &&
                                                            (item as StockDetailWork).DtlRelationGuid == guid)
                                                        {
                                                            retdtil = item;
                                                        }
                                                    }

                                                    break;
                                                }
                                        }
                                        # endregion
                                        break;
                                    }
                                case FindItem.Source:
                                    {
                                        # region [受注ステータス(計上元) or 仕入形式(計上元)を検索対象とする]
                                        switch (sliptype)
                                        {
                                            case SlipType.Estimation:     // 見積
                                            case SlipType.AcceptAnOrder:  // 受注
                                            case SlipType.Shipment:       // 出荷
                                            case SlipType.Sales:          // 売上
                                                {
                                                    if (item is SalesDetailWork)
                                                    {
                                                        // 受注ステータス(計上元)とGUIDをチェックする
                                                        if ((item as SalesDetailWork).AcptAnOdrStatusSrc == (int)sliptype &&
                                                            (item as SalesDetailWork).DtlRelationGuid == guid)
                                                        {
                                                            retdtil = item;
                                                        }
                                                    }

                                                    break;
                                                }
                                            case SlipType.Order:          // 発注
                                            case SlipType.Arrival:        // 入荷
                                            case SlipType.Purchase:       // 仕入
                                                {
                                                    if (item is StockDetailWork)
                                                    {
                                                        // 仕入形式(計上元)とGUIDをチェックする
                                                        if ((item as StockDetailWork).SupplierFormalSrc == (int)sliptype &&
                                                            (item as StockDetailWork).DtlRelationGuid == guid)
                                                        {
                                                            retdtil = item;
                                                        }
                                                    }

                                                    break;
                                                }
                                        }
                                        # endregion
                                        break;
                                    }
                                case FindItem.Synchronize:
                                    {
                                        # region [受注ステータス(同時) or 仕入形式(同時)を検索対象とする]
                                        switch (sliptype)
                                        {
                                            case SlipType.Estimation:     // 見積
                                            case SlipType.AcceptAnOrder:  // 受注
                                            case SlipType.Shipment:       // 出荷
                                            case SlipType.Sales:          // 売上
                                                {
                                                    if (item is StockDetailWork)
                                                    {
                                                        // 受注ステータス(同時)とGUIDをチェックする
                                                        if ((item as StockDetailWork).AcptAnOdrStatusSync == (int)sliptype &&
                                                            (item as StockDetailWork).DtlRelationGuid == guid)
                                                        {
                                                            retdtil = item;
                                                        }
                                                    }

                                                    break;
                                                }
                                            case SlipType.Order:          // 発注
                                            case SlipType.Arrival:        // 入荷
                                            case SlipType.Purchase:       // 仕入
                                                {
                                                    if (item is SalesDetailWork)
                                                    {
                                                        // 仕入形式(同時)とGUIDをチェックする
                                                        if ((item as SalesDetailWork).SupplierFormalSync == (int)sliptype &&
                                                            (item as SalesDetailWork).DtlRelationGuid == guid)
                                                        {
                                                            retdtil = item;
                                                        }
                                                    }

                                                    break;
                                                }
                                        }
                                        # endregion
                                        break;
                                    }
                                case FindItem.UoeOrder:
                                    {
                                        #region [受注ステータス or 仕入形式を検索対象とする]
                                        switch (sliptype)
                                        {
                                            case SlipType.Estimation:     // 見積
                                            case SlipType.AcceptAnOrder:  // 受注
                                            case SlipType.Shipment:       // 出荷
                                            case SlipType.Sales:          // 売上
                                                {
                                                    if (item is UOEOrderDtlWork)
                                                    {
                                                        // 受注ステータスとGUIDをチェックする
                                                        if ((item as UOEOrderDtlWork).AcptAnOdrStatus == (int)sliptype &&
                                                            (item as UOEOrderDtlWork).DtlRelationGuid == guid)
                                                        {
                                                            retdtil = item;
                                                        }
                                                    }

                                                    break;
                                                }
                                            case SlipType.Order:          // 発注
                                            case SlipType.Arrival:        // 入荷
                                            case SlipType.Purchase:       // 仕入
                                                {
                                                    if (item is UOEOrderDtlWork)
                                                    {
                                                        // 仕入形式とGUIDをチェックする
                                                        if ((item as UOEOrderDtlWork).SupplierFormal == (int)sliptype &&
                                                            (item as UOEOrderDtlWork).DtlRelationGuid == guid)
                                                        {
                                                            retdtil = item;
                                                        }
                                                    }

                                                    break;
                                                }
                                        }
                                        # endregion
                                        break;
                                    }
                                # region [2008/06/05 M.Kubota --- PM.NSにおける仕入売上同時計上の仕様が未定なので凍結する]
                                //case FindItem.SalesTemp:
                                //    {
                                //    # region [売上一時データを検索対象とする]
                                //        switch (sliptype)
                                //        {
                                //            case SlipType.Order:          // 発注
                                //            case SlipType.Arrival:        // 入荷
                                //            case SlipType.Purchase:       // 仕入
                                //                {
                                //                    if (item is SalesTempWork)
                                //                    {
                                //                        // GUIDをチェックする
                                //                        if ((item as SalesTempWork).DtlRelationGuid == guid)
                                //                        {
                                //                            retdtil = item;
                                //                        }
                                //                    }
                                //                    break;
                                //                }
                                //        }
                                //        # endregion
                                //        break;
                                //    }
                                # endregion
                            }
                        }
                    }

                    // 最初に見つけたデータを返す
                    if (retdtil != null)
                    {
                        break;
                    }
                }

                return retdtil;
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

        /// <summary>
        /// 伝票形式でソートを行う
        /// </summary>
        internal class SlipTypeComparer : IComparer
        {
            /// <summary>
            /// 伝票並替タイプ
            /// </summary>
            public enum SlipSortType
            {
                /// <summary>売上</summary>
                Sales,
                /// <summary>仕入</summary>
                Purchase
            }

            public SlipSortType SortType = SlipSortType.Sales;

            /// <summary>
            /// 仕入を基準に伝票形式でソートを行う
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public int Compare(object x, object y)
            {
                # region [DELETE]
                // SortType が SlipSortType.Sales(売上) の場合は
                // 0:制御オプション＜1:見積＜2:受注＜3:出荷＜4:売上＜5:発注(＋6:UOE発注)＜7:入荷＜8:仕入＜9:売上一時 の順に並び変える
                
                // SortType が SlipSortType.Purchase(仕入) の場合は
                // 0:制御オプション＜5:発注(＋6:UOE発注)＜7:入荷＜8:仕入＜9:売上一時＜11:見積＜12:受注＜13:出荷＜14:売上 の順に並び変える
                # endregion

                // SortType が SlipSortType.Sales(売上) の場合は
                // 0:制御オプション＜1:仕入削除＜2:見積＜3:受注＜4:出荷＜5:売上＜6:売上削除＜7:発注(＋8:UOE発注)＜9:入荷＜10:仕入＜11:在庫調整＜12:売上一時 の順に並び変える

                // SortType が SlipSortType.Purchase(仕入) の場合は
                // 0:制御オプション＜6:売上削除＜7:発注(＋8:UOE発注)＜9:入荷＜10:仕入＜11:在庫調整＜12:売上一時＜21:仕入削除＜22:見積＜23:受注＜24:出荷＜25:売上 の順に並び変える

                int xValue = 0;
                int yValue = 0;
                int zValue = int.MaxValue;

                int xSlipDtlRegOrder = 0;
                int ySlipDtlRegOrder = 0;
                int zSlipDtlRegOrder = 0;

                const int orderWeight = 20;  // 売上⇔仕入で変わる並び順の重みを指定

                object Z = null;

                for (int i = 0; i < 2; i++)
                {
                    Z = (i == 0) ? x : y;

                    if (Z is IOWriteCtrlOptWork)
                    {
                        // 制御オプションは常に先頭とする
                        zValue = 0;
                    }
                    else if (Z is IOWriteMASIRDeleteWork)
                    {
                        # region [仕入削除パラメータ]

                        // 仕入削除パラメータ
                        zValue = 1;

                        // 並替タイプに応じて重みを設ける
                        zValue += (this.SortType == SlipSortType.Sales) ? 0 : orderWeight;

                        // 仕入削除パラメータが複数登録されている場合は、仕入形式の逆順(先:仕入→入荷→発注:後)の順に並べる
                        zSlipDtlRegOrder = 2 - (Z as IOWriteMASIRDeleteWork).SupplierFormal;

                        # endregion
                    }
                    else if (Z is IOWriteMAHNBDeleteWork)
                    {
                        # region [売上削除パラメータ]

                        // 売上削除パラメータ
                        zValue = 6;

                        // 売上削除パラメータが複数登録されている場合は、受注ステータスの逆順(先:出荷→売上→受注→見積:後)順に並べる
                        zSlipDtlRegOrder = 40 - (Z as IOWriteMAHNBDeleteWork).AcptAnOdrStatus;

                        # endregion
                    }
                    else if (Z is ArrayList)
                    {
                        object findObj = null;
                        ArrayList zList = Z as ArrayList;

                        # region [処理対象の抽出]
                        // 売上明細データを検索する
                        findObj = SlipListUtils.Find(zList, typeof(SalesDetailWork), SlipListUtils.FindType.Array);

                        if (findObj == null)
                        {
                            // 仕入明細データを検索する(明細で検索するのは発注データが含まれるため)
                            findObj = SlipListUtils.Find(zList, typeof(StockDetailWork), SlipListUtils.FindType.Array);
                        }

                        # region [2008/06/05 M.Kubota --- PM.NSにおける仕入売上同時計上の仕様が未定なので凍結する]
                        //if (findObj == null)
                        //{
                        //    // 売上一時データを検索する
                        //    findObj = SlipListUtils.Find(zList, typeof(SalesTempWork), SlipListUtils.FindType.Class);
                        //}
                        # endregion

                        if (findObj == null)
                        {
                            // UOE発注明細データを検索する
                            findObj = SlipListUtils.Find(zList, typeof(UOEOrderDtlWork), SlipListUtils.FindType.Array);
                        }

                        if (findObj == null)
                        {
                            // 2009/02/26 買掛無しオプション対応 >>>>>>>>>>>>>>>
                            // 在庫調整
                            //findObj = SlipListUtils.Find(zList, typeof(StockAdjustWork), SlipListUtils.FindType.Array);

                            ArrayList adjustList = zList[0] as ArrayList;
                            findObj = SlipListUtils.Find(adjustList, typeof(StockAdjustWork), SlipListUtils.FindType.Array);
                            // 2009/02/26 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        }

                        if (findObj is ArrayList && SlipListUtils.IsNotEmpty(findObj as ArrayList))
                        {
                            Z = (findObj as ArrayList)[0];
                        }

                        # region [2008/06/05 M.Kubota --- PM.NSにおける仕入売上同時計上の仕様が未定なので凍結する]
                        //else if (findObj is SalesTempWork)
                        //{
                        //    Z = findObj;
                        //}
                        # endregion
                        # endregion

                        # region [処理対象に基づいた重みの設定]

                        if (Z is SalesDetailWork)
                        {
                            # region [売上明細データ]

                            switch ((Z as SalesDetailWork).AcptAnOdrStatus)
                            {
                                case (int)SlipType.Estimation:     // 見積
                                    zValue = 2;
                                    break;
                                case (int)SlipType.AcceptAnOrder:  // 受注
                                    zValue = 3;
                                    break;
                                case (int)SlipType.Shipment:       // 出荷
                                    zValue = 4;
                                    break;
                                case (int)SlipType.Sales:          // 売上
                                    zValue = 5;
                                    break;
                            }

                            // 並替タイプに応じて重みを設ける
                            zValue += (this.SortType == SlipSortType.Sales) ? 0 : orderWeight;

                            // 同一受注ステータスの伝票を比較する際に、伝票明細登録順位を比較項目とする
                            ArrayList SlpDtlAddInfList = ListUtils.Find(zList, typeof(SlipDetailAddInfoWork), ListUtils.FindType.Array) as ArrayList;

                            if (ListUtils.IsNotEmpty(SlpDtlAddInfList))
                            {
                                SlpDtlAddInfList.Sort(new SlipDetailAddInfoRegOrderComparer());
                                zSlipDtlRegOrder = (SlpDtlAddInfList[0] as SlipDetailAddInfoWork).SlipDtlRegOrder;
                            }

                            # endregion
                        }
                        else if (Z is StockDetailWork)
                        {
                            # region [仕入明細データ]

                            switch ((Z as StockDetailWork).SupplierFormal)
                            {
                                case (int)SlipType.Order:     // 発注
                                    zValue = 7;
                                    break;
                                case (int)SlipType.Arrival:   // 入荷
                                    zValue = 9;
                                    break;
                                case (int)SlipType.Purchase:  // 仕入
                                    zValue = 10;
                                    break;
                            }

                            // 並替タイプに応じて重みを設ける
                            //zValue += (this.SortType == SlipSortType.Purchase) ? 0 : 10;

                            // 同一仕入形式の伝票を比較する際に、伝票明細登録順位を比較項目とする
                            ArrayList SlpDtlAddInfList = ListUtils.Find(zList, typeof(SlipDetailAddInfoWork), ListUtils.FindType.Array) as ArrayList;

                            if (ListUtils.IsNotEmpty(SlpDtlAddInfList))
                            {
                                SlpDtlAddInfList.Sort(new SlipDetailAddInfoRegOrderComparer());
                                zSlipDtlRegOrder = (SlpDtlAddInfList[0] as SlipDetailAddInfoWork).SlipDtlRegOrder;
                            }

                            # endregion
                        }
                        else if (Z is UOEOrderDtlWork)
                        {
                            # region [UOE発注データ]

                            // UOE発注
                            zValue = 8;

                            // 並替タイプに応じて重みを設ける
                            //zValue += (this.SortType == SlipSortType.Purchase) ? 0 : 10;

                            ArrayList SlpDtlAddInfList = ListUtils.Find(zList, typeof(SlipDetailAddInfoWork), ListUtils.FindType.Array) as ArrayList;

                            if (ListUtils.IsNotEmpty(SlpDtlAddInfList))
                            {
                                SlpDtlAddInfList.Sort(new SlipDetailAddInfoRegOrderComparer());
                                zSlipDtlRegOrder = (SlpDtlAddInfList[0] as SlipDetailAddInfoWork).SlipDtlRegOrder;
                            }
                            else
                            {
                                zSlipDtlRegOrder = 0;
                            }

                            # endregion
                        }
                        else if (Z is StockAdjustWork)
                        {
                            # region [在庫調整データ]
                            zValue = 11;
                            zSlipDtlRegOrder = 0;
                            # endregion
                        }
                        
                        # region [2008/06/05 M.Kubota --- PM.NSにおける仕入売上同時計上の仕様が未定なので凍結する]
                        //else if (Z is SalesTempWork)  // 売上一時データ
                        //{
                        //    zValue = 9;

                        //    // 並替タイプに応じて重みを設ける
                        //    zValue += (this.SortType == SlipSortType.Purchase) ? 0 : 10;
                        //}
                        # endregion
                        # endregion

                    }

                    if (i == 0)
                    {
                        xValue = zValue;
                        xSlipDtlRegOrder = zSlipDtlRegOrder;
                    }
                    else
                    {
                        yValue = zValue;
                        ySlipDtlRegOrder = zSlipDtlRegOrder;
                    }
                }

                // 受注ステータス or 仕入形式 で比較
                int compret = xValue.CompareTo(yValue);

                if (compret == 0)
                {
                    // 伝票明細登録順位で比較
                    compret = xSlipDtlRegOrder.CompareTo(ySlipDtlRegOrder);
                }

                return compret;
            }
        }
        # endregion

        # region [シェアチェック処理]

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
        private void ShareCheckInitialize( ArrayList param, ref ShareCheckInfo info, ref SqlConnection connection, ref SqlTransaction transaction )
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
                    this.ShareCheckInitialize( (item as ArrayList), ref info, ref connection, ref transaction );
                    // --- UPD m.suzuki 2010/08/17 ----------<<<<<
                    continue;
                }

                // 売上明細データ
                if (item is SalesDetailWork)
                {
                    dummyKey.EnterpriseCode = (item as SalesDetailWork).EnterpriseCode;
                    dummyKey.SectionCode = (item as SalesDetailWork).SectionCode;
                    
                    // 2009/03/16 MANTIS 11688 >>>>>>>>>>>>>>>>>>>>
                    //見積の場合は、倉庫ロックをしないように修正
                    //dummyKey.WarehouseCode = (item as SalesDetailWork).WarehouseCode;
                    if ((item as SalesDetailWork).AcptAnOdrStatus != 10)
                    {
                        dummyKey.WarehouseCode = (item as SalesDetailWork).WarehouseCode;
                    }
                    // 2009/03/16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
                // --- ADD m.suzuki 2010/08/17 ---------->>>>>
                // 売上データ
                else if (item is SalesSlipWork)
                {
                    // 締次ロック
                    dummyKey.EnterpriseCode = (item as SalesSlipWork).EnterpriseCode;
                    dummyKey.SectionCode = (item as SalesSlipWork).SectionCode;
                    //dummyKey.AddUpUpdDate = ToLongDate( (item as SalesSlipWork).AddUpADate ); // DEL wangf 2012/11/09 FOR Redmine#33215
                    // ------------ADD wangf 2012/11/09 FOR Redmine#33215--------->>>>
                    // 受注ステータス:10:見積,20:受注,30:売上,40:出荷
                    // 締次ロックチェックの比較用の日付は以下の伝票区分により違い日付を使えようになる
                    // 売上伝票　　　　　　　=>　計上日付
                    // 受注、見積、単価見積　=>　売上日付
                    // 貸出　　　　　　　　　=>　出荷日付
                    if ((item as SalesSlipWork).AcptAnOdrStatus == 30)
                    {
                        dummyKey.AddUpUpdDate = ToLongDate((item as SalesSlipWork).AddUpADate);
                    }
                    else if ((item as SalesSlipWork).AcptAnOdrStatus == 40)
                    {
                        dummyKey.AddUpUpdDate = ToLongDate((item as SalesSlipWork).ShipmentDay);
                    }
                    else
                    {
                        dummyKey.AddUpUpdDate = ToLongDate((item as SalesSlipWork).SalesDate);
                    }
                    // ------------ADD wangf 2012/11/09 FOR Redmine#33215---------<<<<
                    dummyKey.TotalDay = 0;

                    // 得意先の締日(DD)を取得する
                    CustomerDB customerDB = new CustomerDB();
                    if ( customerDB != null )
                    {
                        int customerTotalDay = 0;
                        customerDB.GetCustomerTotalDay( dummyKey.EnterpriseCode, (item as SalesSlipWork).CustomerCode, ref customerTotalDay, ref connection, ref transaction );
                        dummyKey.TotalDay = customerTotalDay;
                    }

                    // 失敗した場合はロックのキーを追加しない
                    if ( dummyKey.TotalDay == 0 )
                    {
                        continue;
                    }
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
                // UOE発注明細データ
                else if (item is UOEOrderDtlWork)
                {
                    dummyKey.EnterpriseCode = (item as UOEOrderDtlWork).EnterpriseCode;
                    dummyKey.SectionCode = (item as UOEOrderDtlWork).SectionCode;

                    // 2009/03/16 MANTIS 11688 >>>>>>>>>>>>>>>>>>>>
                    //検索見積で発注された場合に倉庫ロックをかけないようにするため、
                    //ＵＯＥ発注データでは倉庫ロックはかけない。
                    //在庫更新が発生する場合は、他仕入明細等で倉庫ロックが必ずかかるため。

                    //dummyKey.WarehouseCode = (item as UOEOrderDtlWork).WarehouseCode;
                    // 2009/03/16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
                // 在庫調整明細データ
                else if (item is StockAdjustDtlWork)
                {
                    dummyKey.EnterpriseCode = (item as StockAdjustDtlWork).EnterpriseCode;
                    dummyKey.SectionCode = (item as StockAdjustDtlWork).SectionCode;
                    dummyKey.WarehouseCode = (item as StockAdjustDtlWork).WarehouseCode;
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
                if ( dummyKey.TotalDay != 0 )
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
        private int ToLongDate( DateTime dateTime )
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

        # region [シェアチェック用テストメソッド]
# if DEBUG
        public int ShLock(ref object param, int timeout, int retry, int interval)
        {
            SqlConnection connection = this.CreateConnection(true);
            SqlTransaction transaction = this.CreateTransaction(ref connection);

            ShareCheckInfo info = new ShareCheckInfo();

            info.Keys.Clear();
            info.Keys.AddRange((ShareCheckKey[])(param as ArrayList).ToArray(typeof(ShareCheckKey)));
            info.RetryCount = retry;
            info.TimeOut = timeout;

            int status = this.ShareCheck(info, LockControl.Locke, connection, transaction);

            ShareCheckKey key = null;

            info.Keys.GetIntegratedResult(out key);

            Console.WriteLine(string.Format("Lock ST={0} & {1} {2} {3} {4}", status, key.EnterpriseCode, key.Type, key.SectionCode, key.WarehouseCode));

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                System.Threading.Thread.Sleep(interval);

                status = this.ShareCheck(info, LockControl.Release, connection, transaction);

                info.Keys.GetIntegratedResult(out key);
                Console.WriteLine(string.Format("Release ST={0} & {1} {2} {3} {4}", status, key.EnterpriseCode, key.Type, key.SectionCode, key.WarehouseCode));
            }

            return status;
        }
# endif
        # endregion

        // ----- ADD K2011/08/12 --------------------------->>>>>
        #region IIOWriteControlDB メンバ

        /// <summary>
        /// サーバーシステム日付取得を戻します		
        /// </summary>
        /// <returns>DateTime.now</returns>
        /// <br>Note        : サーバーシステム日付取得を戻します	</br>
        /// <br>Programmer  : 鄧潘ハン</br>
        /// <br>Date        : K2011/12/09</br>
        /// <br>管理番号    : 10703874-00 イスコ個別対応</br>
        public DateTime GetServerNowTime()
        {
            return DateTime.Now;
        }
        
        #endregion
        // ----- ADD K2011/08/12 ---------------------------<<<<<

        // --- ADD 2012/11/30 Y.Wakita ---------->>>>>
        # region [削除処理A]

        /// <summary>
        /// エントリ物理削除
        /// </summary>
        /// <param name="paraList">物理削除情報オブジェクトリスト</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <returns>STATUS</returns>
        public int DeleteA(ref object paraList, out string retMsg, out string retItemInfo)
        {
            // 戻り値の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            SqlConnection connection = null;
            SqlTransaction transaction = null;
            SqlEncryptInfo encryptinfo = null;

            try
            {
                ArrayList paraArraylist = paraList as ArrayList;

                status = this.DeleteProcA(ref paraArraylist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

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

                // 暗号化キーのクローズ (保留)
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

            return status;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paraList"></param>
        /// <param name="retMsg"></param>
        /// <param name="retItemInfo"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <param name="encryptinfo"></param>
        /// <br>Note             :   仕入明細マスタの同時売上情報を削除する。</br>
        /// <br>Programmer       :   脇田　靖之</br>
        /// <br>Date             :   2012/11/30</br>
        /// <br>Update Note      :   UOE発注送信不具合の対応（アプリケーションロック不具合対応）</br>
        /// <br>Programmer       :   陳艶丹</br>
        /// <br>Date             :   2020/03/25</br>
        /// <returns></returns>
        private int DeleteProcA(ref ArrayList paraList, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            //●戻り値の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            //●各種パラメータの確認を行う
            # region [パラメータチェック]

            //●更新情報リストチェック
            if (SlipListUtils.IsEmpty(paraList))
            {
                retMsg = "更新情報リストが未登録です。";
                return status;
            }

            //●売上・仕入制御オプションチェック
            this.CtrlOptWork = SlipListUtils.Find(paraList, typeof(IOWriteCtrlOptWork), SlipListUtils.FindType.Class) as IOWriteCtrlOptWork;

            if (this.CtrlOptWork == null)
            {
                retMsg = "売上・仕入制御オプションが見つかりません。";
                return status;
            }

            // --- ADD 2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
            string enterpriseCode = this.CtrlOptWork.EnterpriseCode;

            // 企業コードが空欄の場合
            if (string.IsNullOrEmpty(enterpriseCode))
            {
                try
                {
                    ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();
                    enterpriseCode = serverLoginInfoAcquisition.EnterpriseCode;

                    // サーバー側共通部品で空欄の企業コードが取得される場合
                    if (string.IsNullOrEmpty(enterpriseCode))
                    {
                        base.WriteErrorLog("IOWriteControlDB.DeleteProcA:共通部品で企業コードを取得した際に空欄の企業コードが取得されました。", status);
                    }
                }
                catch
                {
                    base.WriteErrorLog("IOWriteControlDB.DeleteProcA:共通部品で企業コードを取得した際に例外が発生しました。", status);
                }
            }
            // ロックリソース名
            string resNm = this.GetResourceName(enterpriseCode);
            // --- ADD 2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<

            //●コネクションチェック
            if (connection == null)
            {
                connection = this.CreateSqlConnection(true);
            }

            if (connection == null)
            {
                retMsg = "データベースへ接続出来ません。";
                base.WriteErrorLog(string.Format("IOWriteControlDB.DeleteProcA_connection:{0}", retMsg), status);  // ADD 2020/03/25 陳艶丹　アプリケーションロック不具合対応
                return status;
            }

            # region [--- 暗号化 保留 ---]
            /* --- 保留 ---
            //●暗号化キーチェック
            if (encryptinfo == null)
            {
                List<string> ConcatArray = new List<string>();
                
                // 暗号化対象の売上データ系テーブルリストを取得
                ConcatArray.AddRange(IOWriteMAHNBDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Write));
                
                // 暗号化対象の仕入データ系テーブルリストを取得
                ConcatArray.AddRange(IOWriteMASIRDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Write));
                
                // テーブルリストの結合
                string[] tablenames = ConcatArray.ToArray();

                encryptinfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, tablenames);
            }

            if (encryptinfo == null)
            {
                retMsg = "暗号化キーを作成出来ません。";
                return status;
            }

            encryptinfo.OpenSymKey(ref connection);

            if (!encryptinfo.IsOpen)
            {
                retMsg = "暗号化キーをオープン出来ません。";
                return status;
            }
            */
            # endregion

            //●トランザクションチェック
            if (transaction == null)
            {
                transaction = this.CreateTransaction(ref connection);
            }

            if (transaction == null)
            {
                retMsg = "トランザクションを開始できません。";
                base.WriteErrorLog(string.Format("IOWriteControlDB.DeleteProcA:{0}", retMsg), status);  // ADD 2020/03/25 陳艶丹　アプリケーションロック不具合対応
                return status;
            }

            # endregion

            //●排他ロックを開始する
#if !DEBUG // Debug時に他の人の迷惑にならない様に…
            ShareCheckInfo info = null;
            this.ShareCheckInitialize(paraList, ref info, ref connection, ref transaction);
            // --- ADD 2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
            try
            {
            // --- ADD 2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                status = this.ShareCheck(info, LockControl.Locke, connection, transaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

            // --- UPD 2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "IOWriteControlDB.DeleteProcA_ShareCheckLocke:" + ex.ToString());
                throw ex;
            }

            //status = this.Lock(this.ResourceName, connection, transaction);
            // グローバル変数の代わりにローカルのリソース名を使用する
            status = this.Lock(resNm, connection, transaction);
            // --- UPD 2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<

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
                base.WriteErrorLog(string.Format("IOWriteControlDB.DeleteProcA_Lock:{0}" + retMsg), status);  // ADD 2020/03/25 陳艶丹　アプリケーションロック不具合対応

                return status;
            }
# endif

            try
            {
                # region [登録データ準備処理]
                Hashtable new2org = new Hashtable();

                foreach (object item in paraList)
                {
                    if (item is IOWriteCtrlOptWork)
                    {
                        continue;
                    }
                    else
                    {
                        SlipType slipType = SlipListUtils.GetSlipType(item);


                        ArrayList newSliplist = item as ArrayList;
                        ArrayList orgSliplist = null;

                        switch (slipType)
                        {
                            case SlipType.Purchase:
                                {
                                    // 仕入系データ登録準備処理
                                    status = this.PurchaseWriteInitialize(out orgSliplist, ref newSliplist, ref paraList, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        new2org.Add(newSliplist, orgSliplist);
                                    }
                                    break;
                                }
                            case SlipType.PurchaseDel:
                            case SlipType.SalesDel:
                                {
                                    // 仕入・売上削除処理
                                    // ※登録準備処理の中で登録済み伝票データを読込んでいる為、削除処理は最初に行う必要がある

                                    int orgCtrlStartingPoint = this.CtrlOptWork.CtrlStartingPoint;

                                    // 伝票削除用パラメータリストの作成
                                    ArrayList delPrm = new ArrayList();
                                    delPrm.Add(this.CtrlOptWork);
                                    delPrm.Add(item);

                                    if (slipType == SlipType.PurchaseDel)
                                    {
                                        // 仕入削除の場合は強制的に制御起点を仕入にする
                                        this.CtrlOptWork.CtrlStartingPoint = (int)IOWriteCtrlOptCtrlStartingPoint.Purchase;
                                    }
                                    else
                                    {
                                        // 売上削除の場合は強制的に制御起点を売上にする
                                        this.CtrlOptWork.CtrlStartingPoint = (int)IOWriteCtrlOptCtrlStartingPoint.Sales;
                                    }

                                    try
                                    {
                                        status = this.DeleteProc(ref delPrm, 1, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                                    }
                                    finally
                                    {
                                        this.CtrlOptWork.CtrlStartingPoint = orgCtrlStartingPoint;
                                    }

                                    break;
                                }
                        }

                        // 登録準備処理に失敗した場合は処理を中断する
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            retMsg += (!string.IsNullOrEmpty(retMsg) ? "\n" : "") + string.Format("IOWriteControlDB.WriteProc: 伝票データの登録準備処理に失敗しました。(SlipType = {0})", Enum.GetName(typeof(SlipType), slipType));
                            break;
                        }
                    }
                }
                # endregion

                # region [データ登録処理]
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    CustomSerializeArrayList paracuslist = new CustomSerializeArrayList();
                    foreach (object listItem in paraList)
                    {
                        if (listItem is IOWriteCtrlOptWork)
                        {
                            continue;
                        }

                        int findObjPos = -1;
                        paracuslist.Clear();

                        if (listItem is ArrayList)
                        {
                            ArrayList newSliplist = listItem as ArrayList;
                            ArrayList orgSliplist = null;

                            SlipType slipType = SlipListUtils.GetSlipType(newSliplist);

                            switch (slipType)
                            {
                                case SlipType.Estimation:
                                case SlipType.AcceptAnOrder:
                                case SlipType.Shipment:
                                case SlipType.Sales:
                                    {
                                        // 売上データ削除用オブジェクトの存在チェック
                                        SlipListUtils.Find((listItem as ArrayList), typeof(IOWriteMAHNBDeleteWork), SlipListUtils.FindType.Class, out findObjPos);

                                        if (findObjPos >= 0)
                                        {
                                            // 売上データの削除処理
                                            paracuslist.AddRange(listItem as ArrayList);
                                            status = this.salesIOWriteDB.Delete(ref paracuslist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                                        }
                                        break;
                                    }
                                case SlipType.Order:
                                case SlipType.Arrival:
                                case SlipType.Purchase:
                                    {
                                        // 仕入系データ登録処理
                                        orgSliplist = new2org[newSliplist] as ArrayList;
                                        status = this.PurchaseWrite(orgSliplist, ref newSliplist, ref paraList, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                                        break;
                                    }
                            }

                            // 登録処理に失敗した場合は処理を中断する
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retMsg += (!string.IsNullOrEmpty(retMsg) ? "\n" : "") + string.Format("IOWriteControlDB.WriteProc: 伝票データの登録処理に失敗しました。(SlipType = {0})", Enum.GetName(typeof(SlipType), slipType));
                                break;
                            }
                        }
                    }
                }
                # endregion
            }
            finally
            {
                //●排他ロックを解除する
#if !DEBUG // Debug時に他の人の迷惑にならない様に…
                // --- UPD 2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                //●排他ロックを解除する
                //this.Release(this.ResourceName, connection, transaction);
                //this.ShareCheck(info, LockControl.Release, connection, transaction);
                int releaseStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                if (connection == null)
                {
                    base.WriteErrorLog("IOWriteControlDB.DeleteProcA_Release: アプリケーションロック解除前にデータベースに接続できません。", releaseStatus);
                }
                else if (transaction == null)
                {
                    base.WriteErrorLog("IOWriteControlDB.DeleteProcA_Release: アプリケーションロック解除前にトランザクションが終了しています。", releaseStatus);
                }
                else if (transaction.Connection == null)
                {
                    base.WriteErrorLog("IOWriteControlDB.DeleteProcA_Release: アプリケーションロック解除前にトランザクションに例外が発生しました。", releaseStatus);
                }
                else
                {
                    // アプリケーションロック解除
                    releaseStatus = this.Release(resNm, connection, transaction);
                    if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        base.WriteErrorLog("IOWriteControlDB.DeleteProcA_Release: アプリケーションロック解除処理に失敗しました。", releaseStatus);
                    }
                }

                if (connection == null)
                {
                    base.WriteErrorLog("IOWriteControlDB.DeleteProcA_ShareCheckRelease: シェアチェック解除前にデータベースに接続できません。", releaseStatus);
                }
                else if (transaction == null)
                {
                    base.WriteErrorLog("IOWriteControlDB.DeleteProcA_ShareCheckRelease: シェアチェック解除前にトランザクションが終了しています。", releaseStatus);
                }
                else if (transaction.Connection == null)
                {
                    base.WriteErrorLog("IOWriteControlDB.DeleteProcA_ShareCheckRelease: シェアチェック解除前にトランザクションに例外が発生しました。", releaseStatus);
                }
                else
                {
                    // シェアチェック解除
                    releaseStatus = this.ShareCheck(info, LockControl.Release, connection, transaction);
                    if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        base.WriteErrorLog("IOWriteControlDB.DeleteProcA_ShareCheckRelease: シェアチェック解除処理に失敗しました。", releaseStatus);
                    }
                }
                // --- UPD 2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                
#endif
            }

            return status;

        }
        # endregion
        // --- ADD 2012/11/30 Y.Wakita ----------<<<<<

        // --- ADD 2014/05/01 T.Miyamoto 仕掛一覧№2257 ------------------------------>>>>>
        # region [返品存在チェック]
        /// <summary>
        /// 指定された明細データに対して返品が存在するか確認
        /// </summary>
        /// <param name="paraList"></param>
        /// <returns>STATUS</returns>
        public bool CheckReturnData(object paraList)
        {
            SalesDetailWork paraSalesDetailWork = (SalesDetailWork)(paraList as ArrayList)[0];

            //呼び出しパラメータ設定
            SqlConnection sqlConnection = this.CreateSqlConnection(true);
            SqlTransaction sqlTransaction = null;

            bool status = this.CheckReturnData(paraSalesDetailWork, ref sqlConnection, ref sqlTransaction);

            return status;
        }
        /// <summary>
        /// 指定された明細データに対して返品が存在するか確認
        /// </summary>
        /// <param name="parasalesDetailWorks">読込パラメータ</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        private bool CheckReturnData(SalesDetailWork parasalesDetailWorks, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            bool status = false;

            if (parasalesDetailWorks != null)
            {
                SqlCommand command = null;
                try
                {
                    //Selectコマンドの生成
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        SqlDataReader myReader = null;
                        sqlCommand.Connection = sqlConnection;
                        if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                        string sqlText = string.Empty;

                        sqlText += "SELECT COUNT(SALESSLIPNUMRF) AS RETCNT" + Environment.NewLine;
                        sqlText += "  FROM SALESDETAILRF WITH (READUNCOMMITTED)" + Environment.NewLine;
                        sqlText += "  WHERE LOGICALDELETECODERF = 0" + Environment.NewLine;
                        sqlText += "    AND ACPTANODRSTATUSSRCRF = @FINDACPTANODRSTATUSSRC" + Environment.NewLine;
                        sqlText += "    AND SALESSLIPDTLNUMSRCRF = @FINDSALESSLIPDTLNUMSRC" + Environment.NewLine;
                        sqlText += "    AND SALESSLIPCDDTLRF = 1";
                        sqlCommand.CommandText = sqlText;

                        //Prameterオブジェクトの作成
                        SqlParameter findAcptAnOdrStatusSrc = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUSSRC", SqlDbType.Int);
                        SqlParameter findSalesSlipDtlNumSrc = sqlCommand.Parameters.Add("@FINDSALESSLIPDTLNUMSRC", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findAcptAnOdrStatusSrc.Value = parasalesDetailWorks.AcptAnOdrStatus; //受注ステータス
                        findSalesSlipDtlNumSrc.Value = parasalesDetailWorks.SalesSlipDtlNum; //売上明細通番

                        try
                        {
                            myReader = sqlCommand.ExecuteReader();
                            if (myReader.Read())
                            {
                                int retCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETCNT"));
                                if (retCnt > 0)
                                {
                                    status = true;
                                }
                            }
                        }
                        finally
                        {
                            if (myReader != null)
                            {
                                if (!myReader.IsClosed) myReader.Close();
                                myReader.Dispose();
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    //基底クラスに例外を渡して処理してもらう
                    base.WriteSQLErrorLog(ex, "SalesSlipDB.CheckSalesAddUpDateにてSQL例外発生。MSG=" + ex.Message, 0);
                }
                catch (Exception ex)
                {
                    //基底クラスに例外を渡して処理してもらう
                    base.WriteErrorLog(ex, "SalesSlipDB.CheckSalesAddUpDateにて例外発生。MSG=" + ex.Message, 0);
                }
            }
            return status;
        }
        # endregion
        // --- ADD 2014/05/01 T.Miyamoto 仕掛一覧№2257 ------------------------------<<<<<
    }
}

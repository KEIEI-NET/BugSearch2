using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Diagnostics;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Data.SqlTypes;


namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 売上入金更新リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上IOWriteにて入金データを制御します。</br>
    /// <br>Programmer : 19026　湯山　美樹</br>
    /// <br>Date       : 2007.03.17</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// <br>Update Note: 2013/01/18 田建委</br>
    /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
    /// <br>           : Redmine#33797 入金確認表の摘要欄内容を修正</br>
    /// </remarks>
    [Serializable]
    public class IOWriteMAHNBDepositDB : RemoteWithAppLockDB, IFunctionCallTargetWrite, IFunctionCallTargetRedBlackWrite
    {
        /// <summary>
        /// IOWrite入金更新リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特に無し</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.03.17</br>
        /// </remarks>
        public IOWriteMAHNBDepositDB()
        {
        }

        #region 利用リモート

        private DepsitMainDB _depositMainDB = null;
        
        /// <summary>
        /// 入金リモートプロパティ
        /// </summary>
        private DepsitMainDB depositMainDB
        {
            get
            {
                if (this._depositMainDB == null)
                {
                    this._depositMainDB = new DepsitMainDB();
                }

                return this._depositMainDB;
            }
        }

        private DepositReadDB _depositReadDB = null;

        /// <summary>
        /// 入金Readリモートプロパティ
        /// </summary>
        private DepositReadDB depositReadDB
        {
            get
            {
                if (this._depositReadDB == null)
                {
                    this._depositReadDB = new DepositReadDB();
                }

                return this._depositReadDB;
            }
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 入金データの読み込みを行ないます
        /// </summary>
        /// <param name="origin">呼び出し元プログラムID</param>
        /// <param name="readResultList">売上読込結果リスト</param>
        /// <param name="sqlConnection">SQL接続情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 入金データの読み込みを行ないます</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.04.05</br>
        public int ReadFromSalesSlip(string origin, ref CustomSerializeArrayList readResultList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            try
            {
                //●コネクション情報パラメータチェック
                if (sqlConnection == null)
                {
                    errmsg += ": データベース接続情報パラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●売上データ読込結果チェック
                if (readResultList == null) return status;

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                //●売上データ読込結果より売上データを取得 -> 入金データ検索パラメータとする
                SalesSlipWork salesSlipParam = ListUtils.Find(readResultList, typeof(SalesSlipWork), ListUtils.FindType.Class) as SalesSlipWork;
                
                //売上データがなければ正常終了
                if (salesSlipParam == null) return status;

                //●入金データの読込
                object searchParaDepositRead = CreateReadParameterList(salesSlipParam);
                object depositDataResult;
                object depositAlwWorkList;
                SqlTransaction dummyTran = null;

                status = depositReadDB.Search(out depositDataResult, out depositAlwWorkList, searchParaDepositRead, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection, ref dummyTran);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_WARNING)
                {
                    //レスポンスデータ生成
                    DepositInfo readDepositInfo = null;

                    readDepositInfo = this.CreateReadResult((ArrayList)depositDataResult, (ArrayList)depositAlwWorkList);

                    if (readDepositInfo != null)
                    {
                        readResultList.Add(readDepositInfo.DepsitDataWork);
                        readResultList.Add(readDepositInfo.DepositAlwWorkArray[0]);
                    }
                }

                //データ無は正常
                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND ||
                    status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
            }

            return status;
        }

        /// <summary>
        /// 入金データ検索用のパラメータを生成
        /// </summary>
        /// <param name="salesSlipParam">売上データ</param>
        /// <returns>検索用パラメータ</returns>
        private SearchParaDepositRead CreateReadParameterList(SalesSlipWork salesSlipParam)
        {
            //自動入金分の検索条件を生成
            SearchParaDepositRead searchParaDepositRead = new SearchParaDepositRead();
            searchParaDepositRead.EnterpriseCode = salesSlipParam.EnterpriseCode;    // 企業コード
            searchParaDepositRead.AutoDepositCd = 1;                                 // 自動入金区分
            searchParaDepositRead.AcptAnOdrStatus = salesSlipParam.AcptAnOdrStatus;  // 受注ステータス
            searchParaDepositRead.SalesSlipNum = salesSlipParam.SalesSlipNum;        // 売上伝票番号
　          return searchParaDepositRead;
        }
        #endregion

        #region [Write] implements IFunctionCallTargetWrite
        /// <summary>
        /// 入金更新の準備処理を行います
        /// </summary>
        /// <param name="origin">呼び出し元プログラムID</param>
        /// <param name="originList">更新前オブジェクト</param>
        /// <param name="list">パラメータList</param>
        /// <param name="position">対象パラメータクラス位置</param>
        /// <param name="param">構成ファイルパラメータ</param>
        /// <param name="freeParam">自由パラメータ</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">SQL接続情報</param>
        /// <param name="sqlTransaction">SQLトランザクション情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.03.17</br>
        public int WriteInitial(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList list, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            retMsg = "";
            retItemInfo = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            try
            {
                //●コネクション情報パラメータチェック
                if (sqlConnection == null || sqlTransaction == null)
                {
                    errmsg += ": データベース接続情報パラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●更新対象パラメータリストチェック
                if (ListUtils.IsEmpty(list))
                {
                    errmsg += ": 更新対象パラメータListが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●売上伝票オブジェクトの取得
                SalesSlipWork salesSlipParam = ListUtils.Find(list, typeof(SalesSlipWork), ListUtils.FindType.Class) as SalesSlipWork;

                if (salesSlipParam == null)
                {
                    errmsg += ": 更新対象売上オブジェクトパラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●入金データオブジェクトの取得
                DepsitDataWork depsitDataWork = ListUtils.Find(list, typeof(DepsitDataWork), ListUtils.FindType.Class) as DepsitDataWork;

                if (depsitDataWork == null)
                {
                    errmsg += ": 更新対象入金オブジェクトパラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●入金引当データオブジェクトの取得
                DepositAlwWork depositAlwWork = ListUtils.Find(list, typeof(DepositAlwWork), ListUtils.FindType.Class) as DepositAlwWork;

                if (depositAlwWork == null)
                {
                    errmsg += ": 更新対象入金引当オブジェクトパラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●入金・入金引当情報オブジェクトの作成
                DepositInfo depositInfo = new DepositInfo();
                depositInfo.DepsitDataWork = depsitDataWork;
                DepositAlwWork[] depositAlwArray = new DepositAlwWork[] { depositAlwWork };
                depositInfo.DepositAlwWorkArray = depositAlwArray;
                this.CreateDepositParameter(salesSlipParam, ref depositInfo);

                DepsitMainWork depsitMainWork = null;
                DepsitDtlWork[] depsitDtlArray = null;
                DepsitDataUtil.Division(depsitDataWork, out depsitMainWork, out depsitDtlArray);

                //●入金伝票番号の採番
                this.depositMainDB.WriteInitial(ref depsitMainWork, ref depsitDtlArray, ref depositAlwArray, ref sqlConnection, ref sqlTransaction);

                DepsitDataUtil.UnionRef(ref depsitDataWork, depsitMainWork, depsitDtlArray);

                // リストに追加
                list.Add(depositInfo);

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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
                    status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    retMsg = "更新された入金データはありません。" + retMsg;
                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                }
            }

            return status;
        }

        /// <summary>
        /// 入金更新処理の呼び出しを行います
        /// </summary>
        /// <param name="origin">呼び出し元プログラムID</param>
        /// <param name="originList">更新前オブジェクト</param>
        /// <param name="list">パラメータList</param>
        /// <param name="position">対象パラメータクラス位置</param>
        /// <param name="param">構成ファイルパラメータ</param>
        /// <param name="freeParam">自由パラメータ</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">SQL接続情報</param>
        /// <param name="sqlTransaction">SQLトランザクション情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 入金更新処理を行います</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.03.17</br>
        public int Write(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList list, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            retMsg = "";
            retItemInfo = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            try
            {
                //●コネクション情報パラメータチェック
                if (sqlConnection == null || sqlTransaction == null)
                {
                    errmsg += ": データベース接続情報パラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●更新対象パラメータリストチェック
                if (ListUtils.IsEmpty(list))
                {
                    errmsg += ": 更新対象パラメータListが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●売上伝票オブジェクトの取得
                SalesSlipWork salesSlipParam = ListUtils.Find(list, typeof(SalesSlipWork), ListUtils.FindType.Class) as SalesSlipWork;

                if (salesSlipParam == null)
                {
                    errmsg += ": 更新対象売上オブジェクトパラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●入金・入金引当情報オブジェクトの取得
                DepositInfo depositInfo = ListUtils.Find(list, typeof(DepositInfo), ListUtils.FindType.Class) as DepositInfo;

                if (depositInfo == null)
                {
                    errmsg += ": 更新対象入金・入金引当情報オブジェクトパラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }
               
                DepsitDataWork depsitDataWork = depositInfo.DepsitDataWork;
                DepsitMainWork depsitMainWork = null;
                DepsitDtlWork[] depsitDtlArray = null;
                DepsitDataUtil.Division(depsitDataWork, out depsitMainWork, out depsitDtlArray);
                DepositAlwWork[] depositAlwArray = depositInfo.DepositAlwWorkArray;
                
                status = this.depositMainDB.WriteProc(ref depsitMainWork, ref depsitDtlArray, ref depositAlwArray, ref sqlConnection, ref sqlTransaction);
                    
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                    status != (int)ConstantManagement.DB_Status.ctDB_WARNING)
                {
                    retMsg = "入金データの更新処理でエラーが発生しました。" + retMsg;
                }
                else
                {
                    DepsitDataUtil.UnionRef(ref depsitDataWork, depsitMainWork, depsitDtlArray);

                    // 入金リモート側で更新した入金引当合計額や入金引当残高を、売上伝票データに再設定する
                    status = this.UpdateSalesSlipAutoDepositSlipNo(depsitMainWork, ref salesSlipParam, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                }

                // 追加したパラメータをlistから削除
                list.Remove(depositInfo);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
            }

            return status;
        }
        #endregion

        #region [RedWrite] implements IFunctionCallTargetRedBlackWrite
        /// <summary>
        /// 売上データ赤伝更新準備処理
        /// </summary>
        /// <param name="origin">呼び出し元プログラムID</param>
        /// <param name="originList">元黒パラメータList</param>
        /// <param name="redList">赤伝パラメータList</param>
        /// <param name="retRedList">赤伝更新結果List</param>
        /// <param name="position">対象パラメータクラス位置</param>
        /// <param name="param">構成ファイルパラメータ</param>
        /// <param name="freeParam">フリーパラメータ</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">SQL接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上データ赤伝更新の入金データ更新準備処理を行ないます。</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.07.04</br>
        public int RedWriteInitial(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList redList, ref CustomSerializeArrayList retRedList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            // 入金の赤伝票は存在せず、通常の黒伝として登録するが、金額などをマイナスにして相殺するようなデータとしている
            retMsg = "";
            retItemInfo = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            try
            {
                //●コネクション情報パラメータチェック
                if (sqlConnection == null || sqlTransaction == null)
                {
                    errmsg += ": データベース接続情報パラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●赤伝更新パラメータリストのチェック
                if (ListUtils.IsEmpty(redList))
                {
                    errmsg += ": 赤伝更新対象パラメータListが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●売上赤伝オブジェクトの取得
                SalesSlipWork salesSlipParam = ListUtils.Find(redList, typeof(SalesSlipWork), ListUtils.FindType.Class) as SalesSlipWork;

                if (salesSlipParam == null)
                {
                    errmsg += ": 更新対象売上赤伝オブジェクトパラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●入金オブジェクトの取得
                DepsitDataWork depsitDataWork = ListUtils.Find(redList, typeof(DepsitDataWork), ListUtils.FindType.Class) as DepsitDataWork;

                if (depsitDataWork == null)
                {
                    errmsg += ": 更新対象入金オブジェクトパラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●入金オブジェクトの取得
                DepositAlwWork depositAlwWork = ListUtils.Find(redList, typeof(DepositAlwWork), ListUtils.FindType.Class) as DepositAlwWork;

                if (depositAlwWork == null)
                {
                    errmsg += ": 更新対象入金引当オブジェクトパラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●入金・入金引当情報オブジェクトの作成
                DepositInfo depositInfo = new DepositInfo();
                depositInfo.DepsitDataWork = depsitDataWork;
                depositInfo.DepositAlwWorkArray = new DepositAlwWork[] { depositAlwWork };

                this.CreateDepositParameter(salesSlipParam, ref depositInfo);

                // リストに追加
                redList.Add(depositInfo);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                //TODO: WARNING の扱い
                //データ無しの場合はステータスを警告ステータスに変更する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND ||
                    status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    retMsg = "更新された入金データはありません。" + retMsg;
                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                }
            }
            
            return status;
        }

        /// <summary>
        /// 売上データ赤伝更新準備処理
        /// </summary>
        /// <param name="origin">呼び出し元プログラムID</param>
        /// <param name="originList">元黒パラメータList</param>
        /// <param name="redList">赤伝パラメータList</param>
        /// <param name="retRedList">赤伝更新結果List</param>
        /// <param name="position">対象パラメータクラス位置</param>
        /// <param name="param">構成ファイルパラメータ</param>
        /// <param name="freeParam">フリーパラメータ</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">SQL接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上データ赤伝更新の入金データ更新処理を行ないます。</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.07.04</br>
        public int RedWrite(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList redList, ref CustomSerializeArrayList retRedList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            retMsg = "";
            retItemInfo = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            try
            {
                //●コネクション情報パラメータチェック
                if (sqlConnection == null || sqlTransaction == null)
                {
                    errmsg += ": データベース接続情報パラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●更新対象パラメータリストチェック
                if (ListUtils.IsEmpty(redList))
                {
                    errmsg += ": 更新対象パラメータListが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●売上伝票オブジェクトの取得
                SalesSlipWork salesSlipParam = ListUtils.Find(redList, typeof(SalesSlipWork), ListUtils.FindType.Class) as SalesSlipWork;

                if (salesSlipParam == null)
                {
                    errmsg += ": 更新対象売上オブジェクトパラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●入金・入金引当情報オブジェクトの取得
                DepositInfo depositInfo = ListUtils.Find(redList, typeof(DepositInfo), ListUtils.FindType.Class) as DepositInfo;

                if (depositInfo == null)
                {
                    errmsg += ": 更新対象入金・入金引当情報オブジェクトパラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                DepsitMainWork depsitMainWork = null;
                DepsitDtlWork[] depsitDtlArray = null;
                DepsitDataUtil.Division(depositInfo.DepsitDataWork, out depsitMainWork, out depsitDtlArray);
                DepositAlwWork[] depositAlwArray = depositInfo.DepositAlwWorkArray;
                status = depositMainDB.Write(ref depsitMainWork, ref depsitDtlArray, ref depositAlwArray, ref sqlConnection, ref sqlTransaction);
                    
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                    status != (int)ConstantManagement.DB_Status.ctDB_WARNING)
                {
                    retMsg = "入金データの更新処理でエラーが発生しました。" + retMsg;
                }
                else
                {
                    // 赤伝更新結果リストに追加する
                    //retRedList.Add(depositMainWork);
                    //retRedList.Add(depositAlwWorkArray[0]);

                    // 自動入金伝票番号をパラメータにセットし直す。
                    status = this.UpdateSalesSlipAutoDepositSlipNo(depsitMainWork, ref salesSlipParam, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                }

                // 追加したパラメータをlistから削除
                redList.Remove(depositInfo);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "IOWriteMAHNBDepositDB.RedWrite:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            
            return status;
        }

        #endregion

        #region [Delete] implements IFunctionCallTargetWrite
        /// <summary>
        /// 入金更新削除初期処理
        /// </summary>
        /// <param name="origin">呼び出し元</param>
        /// <param name="originList">物理削除List</param>
        /// <param name="list"></param>
        /// <param name="position">更新対象ｵﾌﾞｼﾞｪｸﾄ位置</param>
        /// <param name="param">パラメータ</param>
        /// <param name="freeParam">自由パラメータ</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 入金マスタ物理削除初期処理</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.03.17</br>
        public int DeleteInitial(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList list, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            
            retMsg = "";
            retItemInfo = "";

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            try
            {
                //●コネクション情報パラメータチェック
                if (sqlConnection == null || sqlTransaction == null)
                {
                    errmsg += ": データベース接続情報パラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●更新対象パラメータリストチェック
                if (ListUtils.IsEmpty(list))
                {
                    errmsg += ": 更新対象パラメータリストが未指定です";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●売上伝票削除オブジェクトの取得
                SalesSlipDeleteWork salesSlipDeleteParam = ListUtils.Find(list, typeof(SalesSlipDeleteWork), ListUtils.FindType.Class) as SalesSlipDeleteWork;
                SalesSlipWork salesSlipParam = null;

                if (salesSlipDeleteParam == null)
                {
                    errmsg += ": 削除対象売上オブジェクトパラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }
                else
                {
                    // 売上伝票削除オブジェクトから売上伝票オブジェクトを生成する(後述の入金・入金引当情報オブジェクトを作成する際に必要なため)
                    salesSlipParam = new SalesSlipWork();
                    salesSlipParam.EnterpriseCode = salesSlipDeleteParam.EnterpriseCode;    // 企業コード
                    salesSlipParam.AcptAnOdrStatus = salesSlipDeleteParam.AcptAnOdrStatus;  // 受注ステータス
                    salesSlipParam.SalesSlipNum = salesSlipDeleteParam.SalesSlipNum;        // 売上伝票番号
                    salesSlipParam.DebitNoteDiv = salesSlipDeleteParam.DebitNoteDiv;        // 赤伝区分
                    salesSlipParam.UpdateDateTime = salesSlipDeleteParam.UpdateDateTime;    // 更新日付
                }

                //●入金オブジェクトの取得
                DepsitDataWork depsitDataWork = ListUtils.Find(list, typeof(DepsitDataWork), ListUtils.FindType.Class) as DepsitDataWork;

                if (depsitDataWork == null)
                {
                    errmsg += ": 更新対象入金オブジェクトパラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●入金引当オブジェクトの取得
                DepositAlwWork depositAlwWork = ListUtils.Find(list, typeof(DepositAlwWork), ListUtils.FindType.Class) as DepositAlwWork;

                if (depositAlwWork == null)
                {
                    errmsg += ": 更新対象入金引当オブジェクトパラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●入金・入金引当情報オブジェクトの作成
                DepositInfo depositInfo = new DepositInfo();
                depositInfo.DepsitDataWork = depsitDataWork;
                depositInfo.DepositAlwWorkArray = new DepositAlwWork[] { depositAlwWork };

                //※削除の場合はUI側から読み込み済みの入金・引当データを得られるため、値の再設定は不要
                //this.CreateDepositParameter(salesSlipParam, ref depositInfo);

                // リストに追加
                list.Add(depositInfo);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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
                    status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    retMsg = "削除する入金データはありません。" + retMsg;
                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                }
            }

            return status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="originList"></param>
        /// <param name="list"></param>
        /// <param name="position"></param>
        /// <param name="param"></param>
        /// <param name="freeParam"></param>
        /// <param name="retMsg"></param>
        /// <param name="retItemInfo"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <param name="sqlEncryptInfo"></param>
        /// <returns></returns>
        public int Delete(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList list, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            
            retMsg = "";
            retItemInfo = "";

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            try
            {
                //●コネクション情報パラメータチェック
                if (sqlConnection == null || sqlTransaction == null)
                {
                    errmsg += ": データベース接続情報パラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●更新対象パラメータリストチェック
                if (ListUtils.IsEmpty(list))
                {
                    errmsg += ": 更新対象パラメータリストが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●入金・入金引当情報オブジェクトの取得
                DepositInfo depositInfo = ListUtils.Find(list, typeof(DepositInfo), ListUtils.FindType.Class) as DepositInfo;

                if (depositInfo == null)
                {
                    errmsg += ": 更新対象入金・入金引当情報オブジェクトパラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                // 企業コード＋入金伝票番号で入金データを削除する
                status = depositMainDB.LogicalDelete(depositInfo.DepsitDataWork.EnterpriseCode, depositInfo.DepsitDataWork.DepositSlipNo, depositInfo.DepsitDataWork.AcptAnOdrStatus, ref sqlConnection, ref sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status != (int)ConstantManagement.DB_Status.ctDB_WARNING)
                {
                    retMsg = "入金の削除処理でエラーが発生しました。" + retMsg;
                }

                // パラメータの削除
                list.Remove(depositInfo);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
            }

            return status;
        }
        #endregion

        /// <summary>
        /// 売上自動入金処理において、入金リモート側で更新された入金引当残高や入金引当合計額を再設定する
        /// </summary>
        /// <param name="depositmain">入金データ</param>
        /// <param name="salesslip">売上データ</param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <param name="sqlEncryptInfo"></param>
        /// <returns>status</returns>
        private int UpdateSalesSlipAutoDepositSlipNo(DepsitMainWork depositmain, ref SalesSlipWork salesslip, ref SqlConnection sqlConnection,
                                                    ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            if (depositmain != null && depositmain.DepositSlipNo > 0 &&
                salesslip != null && salesslip.AutoDepositCd == 1 &&
                sqlConnection != null && sqlTransaction != null)
            {
                try
                {
                    // 入金リモート側で更新している項目を取得し、売上データパラメータにセットする
                    string sqlText = string.Empty;
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  SLIP.DEPOSITALLOWANCETTLRF" + Environment.NewLine;
                    sqlText += " ,SLIP.DEPOSITALWCBLNCERF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  SALESSLIPRF AS SLIP" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  SLIP.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND SLIP.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += "  AND SLIP.SALESSLIPNUMRF = @FINDSALESSLIPNUM" + Environment.NewLine;

                    using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                    {
                        sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar).Value = salesslip.EnterpriseCode;  // 企業コード
                        sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int).Value = salesslip.AcptAnOdrStatus;  // 受注ステータス
                        sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar).Value = salesslip.SalesSlipNum;      // 売上伝票番号

                        SqlDataReader myReader = sqlCommand.ExecuteReader();

                        try
                        {
                            if (myReader.Read())
                            {
                                salesslip.DepositAllowanceTtl = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALLOWANCETTLRF"));  // 入金引当合計額
                                salesslip.DepositAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALWCBLNCERF"));        // 入金引当残高
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                            }
                        }
                        finally
                        {
                            if (myReader != null)
                            {
                                myReader.Close();
                                myReader.Dispose();
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
                    base.WriteErrorLog(ex, errmsg, status);
                }
            }
            else
            {
                errmsg += ": 各種パラメータが正しくありません.";
                base.WriteErrorLog(errmsg, status);
            }

            return status;
        }

        //MEMO: 実装しない
        #region [RedBlackWrite] implements IFunctionCallTargetRedBlackWrite
        /// <summary>
        /// 
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="originList"></param>
        /// <param name="redList"></param>
        /// <param name="blackList"></param>
        /// <param name="retRedList"></param>
        /// <param name="retBlackList"></param>
        /// <param name="position"></param>
        /// <param name="param"></param>
        /// <param name="freeParam"></param>
        /// <param name="retMsg"></param>
        /// <param name="retItemInfo"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <param name="sqlEncryptInfo"></param>
        /// <returns></returns>
        public int RedBlackWriteInitial(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList redList, ref CustomSerializeArrayList blackList, ref CustomSerializeArrayList retRedList, ref CustomSerializeArrayList retBlackList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="originList"></param>
        /// <param name="redList"></param>
        /// <param name="blackList"></param>
        /// <param name="retRedList"></param>
        /// <param name="retBlackList"></param>
        /// <param name="position"></param>
        /// <param name="param"></param>
        /// <param name="freeParam"></param>
        /// <param name="retMsg"></param>
        /// <param name="retItemInfo"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <param name="sqlEncryptInfo"></param>
        /// <returns></returns>
        public int RedBlackWrite(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList redList, ref CustomSerializeArrayList blackList, ref CustomSerializeArrayList retRedList, ref CustomSerializeArrayList retBlackList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        #endregion
        
        #region パラメータ処理
        # region [DELETE]
        /*
        /// <summary>
        /// 入金マスタ・入金引当マスタ更新パラメータ生成
        /// </summary>
        /// <param name="salesSlipParam">売上データ更新パラメータ</param>
        /// <param name="depositParamList">売上入金情報</param>
        /// <param name="depositInfoList">入金更新パラメータ</param>
        private void CreateDepositParameter(SalesSlipWork salesSlipParam, ArrayList depositParamList, out ArrayList depositInfoList)
        {
            depositInfoList = new ArrayList();

            try
            {
                for (int i = 0; i < depositParamList.Count; i++)
                {
                    IOWriteMAHNBDepositWork depositParam = (depositParamList[i] as IOWriteMAHNBDepositWork);

                    if (depositParam != null)
                    {
                        //●更新パラメータ格納処理
                        //預り金区分が入金、預り金以外の場合は処理しない
                        if (depositParam.DepositCd != 0 && depositParam.DepositCd != 1) return;

                        #region 入金マスタ
                        DepsitMainWork depositMainWork = new DepsitMainWork();

                        // 売上データの値をセット
                        depositMainWork.EnterpriseCode = salesSlipParam.EnterpriseCode;  // 企業コード
                        depositMainWork.SubSectionCode = salesSlipParam.SubSectionCode;  // 部コード
                        depositMainWork.MinSectionCode = salesSlipParam.MinSectionCode;  // 課コード

                        depositMainWork.AcptAnOdrStatus = salesSlipParam.AcptAnOdrStatus;  // 受注ステータス
                        depositMainWork.AddUpSecCode = salesSlipParam.DemandAddUpSecCd;    // 請求計上拠点コード                

                        depositMainWork.CustomerCode = salesSlipParam.CustomerCode;    // 得意先コード
                        depositMainWork.CustomerName = salesSlipParam.CustomerName;    // 得意先名称
                        depositMainWork.CustomerName2 = salesSlipParam.CustomerName2;  // 得意先名称２
                        depositMainWork.CustomerSnm = salesSlipParam.CustomerSnm;      // 得意先略称

                        depositMainWork.DepositAgentCode = salesSlipParam.SalesEmployeeCd;    // 入金担当者コード ← 計上担当者コード
                        depositMainWork.DepositAgentNm = salesSlipParam.SalesEmployeeNm;      // 入金担当者名     ← 計上担当者名
                        depositMainWork.DepositDate = salesSlipParam.SalesDate;               // 入金日付 ← 売上日付
                        depositMainWork.DepositInputAgentCd = salesSlipParam.SalesInputCode;  // 入金入力者コード ← 売上入力者コード
                        depositMainWork.DepositInputAgentNm = salesSlipParam.SalesInputName;  // 入金入力者名     ← 売上入力者名
                        depositMainWork.InputDepositSecCd = salesSlipParam.SalesInpSecCd;     // 入金入力拠点コード
                        depositMainWork.SalesSlipNum = salesSlipParam.SalesSlipNum;           // 売上伝票番号
                        depositMainWork.UpdateSecCd = salesSlipParam.UpdateSecCd;             // 更新拠点コード
                        depositMainWork.AutoDepositCd = salesSlipParam.AutoDepositCd;         // 自動入金区分
                        depositMainWork.Outline = salesSlipParam.SalesSlipNum;                // 伝票摘要 ← 売上伝票番号

                        // 入金パラメータの値をセット
                        depositMainWork.ClaimCode = depositParam.ClaimCode;    // 請求先コード
                        depositMainWork.ClaimName = depositParam.ClaimName;    // 請求先名称２
                        depositMainWork.ClaimName2 = depositParam.ClaimName2;  // 請求先名称２
                        depositMainWork.ClaimSnm = depositParam.ClaimSnm;      // 請求先略称
                        depositMainWork.Deposit = depositParam.Deposit;        // 入金金額
                        depositMainWork.DepositCd = depositParam.DepositCd;    // 預り金区分

                        depositMainWork.DepositKindCode = depositParam.DepositKindCode;    // 入金金種コード
                        depositMainWork.DepositKindName = depositParam.DepositKindName;    // 入金金種名称
                        depositMainWork.DepositKindDivCd = depositParam.DepositKindDivCd;  // 入金金種区分
                        depositMainWork.DepositTotal = depositParam.DepositTotal;          // 入金計
                        depositMainWork.DiscountDeposit = depositParam.DiscountDeposit;    // 値引入金額
                        depositMainWork.FeeDeposit = depositParam.FeeDeposit;              // 手数料入金額
                        depositMainWork.DepositSlipNo = depositParam.DepositSlipNo;        // 入金伝票番号(再登録時にセット済み)

                        // UIからはデータセットしなくていい項目
                        depositMainWork.AddUpADate = depositMainWork.DepositDate;      // 計上日付 ←入金日付 
                        depositMainWork.DepositAllowance = depositParam.DepositTotal;  // 入金引当額 ← 入金計
                        depositMainWork.DepositDebitNoteCd = (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black;  // 入金赤黒区分 ← 売上から作成する入金は常に黒とする
                        depositMainWork.LastReconcileAddUpDt = depositMainWork.DepositDate;
                        //depositDataWorkList.DepositAlwcBlnce = depositDataWorkList.DepositAlwcBlnce;  // 入金引当残高は入金側で計算
                        #endregion

                        #region 入金引当マスタ
                        DepositAlwWork depositAlwWork = new DepositAlwWork();
                        depositAlwWork.AcptAnOdrStatus = depositMainWork.AcptAnOdrStatus;
                        depositAlwWork.AddUpSecCode = depositMainWork.AddUpSecCode;
                        depositAlwWork.CustomerCode = depositMainWork.CustomerCode;
                        depositAlwWork.CustomerName = depositMainWork.CustomerName;
                        depositAlwWork.CustomerName2 = depositMainWork.CustomerName2;
                        depositAlwWork.DebitNoteOffSetCd = (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black;  // 入金赤黒区分 ← 売上から作成する入金は常に黒とする
                        depositAlwWork.DepositAgentCode = depositMainWork.DepositInputAgentCd;
                        depositAlwWork.DepositAgentNm = depositMainWork.DepositInputAgentNm;
                        depositAlwWork.DepositAllowance = depositMainWork.DepositAllowance;
                        depositAlwWork.DepositCd = depositMainWork.DepositCd;
                        depositAlwWork.DepositKindCode = depositMainWork.DepositKindCode;
                        depositAlwWork.DepositKindName = depositMainWork.DepositKindName;
                        depositAlwWork.DepositSlipNo = depositMainWork.DepositSlipNo;
                        depositAlwWork.EnterpriseCode = depositMainWork.EnterpriseCode;
                        depositAlwWork.InputDepositSecCd = depositMainWork.InputDepositSecCd;
                        depositAlwWork.ReconcileAddUpDate = depositMainWork.AddUpADate;  //消込み計上日 = 入金計上日
                        depositAlwWork.ReconcileDate = depositMainWork.DepositDate;      //消込み日 = 入金日付
                        depositAlwWork.SalesSlipNum = depositMainWork.SalesSlipNum;
                        #endregion

                        DepositInfo depositInfo = new DepositInfo();
                        depositInfo.DepositMainWork = depositMainWork;
                        depositInfo.DepositAlwWorkArray = new DepositAlwWork[] { depositAlwWork };
                        depositInfoList.Add(depositInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                if (depositInfoList != null)
                {
                    depositInfoList = null;
                }
            }
        }
        */
        # endregion
        # endregion

        /// <summary>
        /// 売上データと売上入金データから入金・入金引当データを作成します。
        /// </summary>
        /// <param name="salesslipparam">売上伝票データ</param>
        /// <param name="depositInfo">入金・入金引当データ</param>
        /// <remarks>
        /// <br>Update Note: 2013/01/18 田建委</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : Redmine#33797 入金確認表の摘要欄内容を修正</br>
        /// </remarks>
        private void CreateDepositParameter(SalesSlipWork salesslipparam, ref DepositInfo depositInfo)
        {
            try
            {
                if (salesslipparam != null && depositInfo != null)
                {
                    #region 入金マスタ
                    DepsitDataWork depsitDataWork = depositInfo.DepsitDataWork;

                    depsitDataWork.EnterpriseCode = salesslipparam.EnterpriseCode;                      // 企業コード
                    depsitDataWork.LogicalDeleteCode = (int)ConstantManagement.LogicalMode.GetData0;    // 論理削除区分
                    depsitDataWork.AcptAnOdrStatus = salesslipparam.AcptAnOdrStatus;                    // 受注ステータス
                    depsitDataWork.DepositDebitNoteCd = (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black;  // 入金赤黒区分 ← 売上から作成する入金は常に黒とする
                    depsitDataWork.SalesSlipNum = salesslipparam.SalesSlipNum;                          // 売上伝票番号
                    depsitDataWork.InputDepositSecCd = salesslipparam.SalesInpSecCd;                    // 入金入力拠点コード  ← 売上入力拠点コード
                    depsitDataWork.AddUpSecCode = salesslipparam.DemandAddUpSecCd;                      // 計上拠点コード      ← 請求計上拠点コード
                    depsitDataWork.UpdateSecCd = salesslipparam.UpdateSecCd;                            // 更新拠点コード
                    depsitDataWork.SubSectionCode = salesslipparam.SubSectionCode;                      // 部門コード
                    depsitDataWork.InputDay = salesslipparam.SearchSlipDate;                            // 入力日付         ← 伝票検索日付  //ADD 2009/03/25
                    depsitDataWork.DepositDate = salesslipparam.SearchSlipDate;                         // 入金日付         ← 伝票検索日付
                    depsitDataWork.AddUpADate = salesslipparam.SalesDate;                               // 計上日付         ← 売上日付
                    depsitDataWork.DepositTotal = salesslipparam.SalesTotalTaxInc;                      // 入金計           ← 売上伝票合計(税込)
                    depsitDataWork.Deposit = salesslipparam.SalesTotalTaxInc;                           // 入金金額         ← 売上伝票合計(税込)
                    depsitDataWork.AutoDepositCd = salesslipparam.AutoDepositCd;                        // 自動入金区分
                    depsitDataWork.DepositAllowance = salesslipparam.SalesTotalTaxInc;                  // 入金引当額       ← 売上伝票合計(税込)
                    depsitDataWork.DepositAgentCode = salesslipparam.SalesEmployeeCd;                   // 入金担当者コード ← 計上担当者コード
                    depsitDataWork.DepositAgentNm = salesslipparam.SalesEmployeeNm;                     // 入金担当者名称   ← 計上担当者名
                    depsitDataWork.DepositInputAgentCd = salesslipparam.SalesInputCode;                 // 入金入力者コード ← 売上入力者コード
                    depsitDataWork.DepositInputAgentNm = salesslipparam.SalesInputName;                 // 入金入力者名称   ← 売上入力者名
                    //depsitDataWork.CustomerCode = salesslipparam.CustomerCode;                        // 得意先コード
                    //depsitDataWork.CustomerName = salesslipparam.CustomerName;                        // 得意先名称
                    //depsitDataWork.CustomerName2 = salesslipparam.CustomerName2;                      // 得意先名称2
                    //depsitDataWork.CustomerSnm = salesslipparam.CustomerSnm;                          // 得意先略称
                    depsitDataWork.CustomerCode = salesslipparam.ClaimCode;                             // 得意先コード ← 請求先コード ※PM7仕様に準拠
                    depsitDataWork.CustomerName = depsitDataWork.ClaimName;                             // 得意先名称   ← 請求先名称(UIより設定)
                    depsitDataWork.CustomerName2 = depsitDataWork.ClaimName2;                           // 得意先名称2  ← 請求先名称２(UIより設定)
                    depsitDataWork.CustomerSnm = salesslipparam.ClaimSnm;                               // 得意先略称   ← 請求先略称
                    depsitDataWork.ClaimCode = salesslipparam.ClaimCode;                                // 請求先コード
                    depsitDataWork.ClaimSnm = salesslipparam.ClaimSnm;                                  // 請求先略称
                    //depsitDataWork.Outline = salesslipparam.SalesSlipNum;                               // 伝票摘要         ← 売上伝票番号 // DEL 2013/01/18 田建委 Redmine#33797
                    //----- ADD 2013/01/18 田建委 Redmine#33797 ------------------------------------->>>>>
                    // 自動入金備考区分(AutoDepositNoteDivRF)(0:売上伝票番号 1:売上伝票備考 2:無し)
                    if (salesslipparam.AutoDepositNoteDiv == 0)
                    {
                        depsitDataWork.Outline = salesslipparam.SalesSlipNum;                           // 伝票摘要 ← 売上伝票番号
                    }
                    else if (salesslipparam.AutoDepositNoteDiv == 1)
                    {
                        depsitDataWork.Outline = salesslipparam.SlipNote;                               // 伝票摘要 ← 売上伝票備考
                    }
                    else if (salesslipparam.AutoDepositNoteDiv == 2)
                    {
                        depsitDataWork.Outline = string.Empty;                                          // 伝票摘要 ← 無し
                    }
                    else
                    {
                        depsitDataWork.Outline = string.Empty;                                          // 伝票摘要 ← 無し
                    }
                    //----- ADD 2013/01/18 田建委 Redmine#33797 -------------------------------------<<<<<
                    depsitDataWork.DepositRowNo1 = 1;                                                   // 入金行番号１
                    depsitDataWork.Deposit1 = salesslipparam.SalesTotalTaxInc;                          // 入金金額１
                    #endregion

                    #region 入金引当マスタ
                    DepositAlwWork depositAlwWork = depositInfo.DepositAlwWorkArray[0];

                    depositAlwWork.AcptAnOdrStatus = depsitDataWork.AcptAnOdrStatus;
                    depositAlwWork.AddUpSecCode = depsitDataWork.AddUpSecCode;
                    //depositAlwWork.CustomerCode = depsitDataWork.CustomerCode;
                    //depositAlwWork.CustomerName = depsitDataWork.CustomerName;
                    //depositAlwWork.CustomerName2 = depsitDataWork.CustomerName2;
                    depositAlwWork.CustomerCode = depsitDataWork.ClaimCode;
                    depositAlwWork.CustomerName = depsitDataWork.ClaimName;
                    depositAlwWork.CustomerName2 = depsitDataWork.ClaimName2;
                    depositAlwWork.DebitNoteOffSetCd = (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black;  // 入金赤黒区分 ← 売上から作成する入金は常に黒とする
                    depositAlwWork.DepositAgentCode = depsitDataWork.DepositInputAgentCd;
                    depositAlwWork.DepositAgentNm = depsitDataWork.DepositInputAgentNm;
                    depositAlwWork.DepositAllowance = depsitDataWork.DepositAllowance;
                    depositAlwWork.DepositSlipNo = depsitDataWork.DepositSlipNo;
                    depositAlwWork.EnterpriseCode = depsitDataWork.EnterpriseCode;
                    depositAlwWork.InputDepositSecCd = depsitDataWork.InputDepositSecCd;
                    depositAlwWork.ReconcileAddUpDate = depsitDataWork.AddUpADate;  //消込み計上日 = 入金計上日
                    depositAlwWork.ReconcileDate = depsitDataWork.DepositDate;      //消込み日 = 入金日付
                    depositAlwWork.SalesSlipNum = depsitDataWork.SalesSlipNum;
                    #endregion
                }
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg);

                if (depositInfo != null)
                {
                    depositInfo = null;
                }
            }
        }

        /// <summary>
        /// 読込入金データパラメータを生成する
        /// </summary>
        /// <param name="depositDataWorkList">入金マスタ</param>
        /// <param name="depositAlwWorkList">入金引当マスタ</param>
        /// <returns>入金データパラメータ</returns>
        private DepositInfo CreateReadResult(ArrayList depositDataWorkList, ArrayList depositAlwWorkList)
        {
            DepositInfo depositInfo = new DepositInfo();
            depositInfo.DepsitDataWork = null;
            depositInfo.DepositAlwWorkArray = null;

            //入金伝票番号でソート
            if (ListUtils.IsNotEmpty(depositDataWorkList)) depositDataWorkList.Sort(new DepositDataComparer());
            if (ListUtils.IsNotEmpty(depositAlwWorkList)) depositAlwWorkList.Sort(new DepositAlwComparer());

            //先頭の入金データと入金引当データを返す(売上同時入金の場合、それぞれデータは１件しかできない為)
            if (depositDataWorkList.Count > 0 && depositAlwWorkList.Count > 0)
            {
                depositInfo.DepsitDataWork = depositDataWorkList[0] as DepsitDataWork;
                depositInfo.DepositAlwWorkArray = new DepositAlwWork[] { depositAlwWorkList[0] as DepositAlwWork };
            }

            return depositInfo;
        }


        # region --- DEL ---
# if false
        /// <summary>
        /// 入金引当削除用のパラメータを生成する
        /// </summary>
        /// <param name="depositWork">売上データ</param>
        /// <param name="depositDataWorkList">入金マスタ</param>
        /// <param name="depositAlwWorkList">入金引当マスタ</param>
        /// <param name="depositInfoList">入金更新パラメータ</param>
        private void CreateDeleteDepositParameter(SalesSlipWork salesSlipWork, ArrayList depositMainWorkList, ArrayList depositAlwWorkList, out ArrayList depositInfoList)
        {
            depositInfoList = new ArrayList();

            for (int i = 0; i < depositMainWorkList.Count; i++)
            {
                DepositInfo depositInfo = new DepositInfo();

                //受注番号指定だから、入金:入金引当=1:1になる
                DepsitMainWork depositMainWork = (DepsitMainWork)depositMainWorkList[i];
                DepositAlwWork depositAlwWork = (DepositAlwWork)depositAlwWorkList[i];

                //引当は削除 -- LogicalDeleteCodeに1をセット
                depositAlwWork.LogicalDeleteCode = (int)ConstantManagement.LogicalMode.GetData1;

                //引当分の入金引当額調整
                depositMainWork.DepositAllowance -= depositAlwWork.DepositAllowance;
                depositMainWork.DepositAlwcBlnce += depositAlwWork.DepositAllowance;

                depositInfo.DepositMainWork = depositMainWork;
                depositInfo.DepositAlwWorkArray = new DepositAlwWork[] { depositAlwWork };

                depositInfoList.Add(depositInfo);
            }
        }

        /// <summary>
        /// 読込入金データパラメータを生成する
        /// </summary>
        /// <param name="depositDataWorkList">入金マスタ</param>
        /// <param name="depositAlwWorkList">入金引当マスタ</param>
        /// <returns>入金データパラメータ</returns>
        private DepositInfo CreateReadResult(ArrayList depositDataWorkList, ArrayList depositAlwWorkList)
        {
            DepositInfo depositInfo = new DepositInfo();
            depositInfo.DepsitDataWork = null;
            depositInfo.DepositAlwWorkArray = null;

            //入金伝票番号でソート
            if (ListUtils.IsNotEmpty(depositDataWorkList)) depositDataWorkList.Sort(new DepositDataComparer());
            if (ListUtils.IsNotEmpty(depositAlwWorkList)) depositAlwWorkList.Sort(new DepositAlwComparer());

            //先頭の入金データと入金引当データを返す(売上同時入金の場合、それぞれデータは１件しかできない為)
            if (depositDataWorkList.Count > 0 && depositAlwWorkList.Count > 0)
            {
                depositInfo.DepsitDataWork = depositDataWorkList[0] as DepsitDataWork;
                depositInfo.DepositAlwWorkArray = new DepositAlwWork[] { depositAlwWorkList[0] as DepositAlwWork };
            }

            return depositInfo;
        }

        /// <summary>
        /// DepsitMainWork と DepositAlwWork から DepositParameterWork を生成
        /// </summary>
        /// <param name="depositDataWorkList">入金マスタ</param>
        /// <param name="depositAlwWorkList">入金引当マスタ</param>
        /// <returns>入金パラメータ</returns>
        /*
        private IOWriteMAHNBDepositWork NewDepositParam(DepsitMainWork depositMainWork, DepositAlwWork depositAlwWork)
        {
            IOWriteMAHNBDepositWork depositParam = new IOWriteMAHNBDepositWork();

            depositParam.CreateDateTime = depositMainWork.CreateDateTime;
            depositParam.UpdateDateTime = depositMainWork.UpdateDateTime;
            depositParam.EnterpriseCode = depositMainWork.EnterpriseCode;
            depositParam.FileHeaderGuid = depositMainWork.FileHeaderGuid;
            depositParam.UpdEmployeeCode = depositMainWork.UpdEmployeeCode;
            depositParam.UpdAssemblyId1 = depositMainWork.UpdAssemblyId1;
            depositParam.UpdAssemblyId2 = depositMainWork.UpdAssemblyId2;
            depositParam.LogicalDeleteCode = depositMainWork.LogicalDeleteCode;
            depositParam.AcptAnOdrStatus = depositMainWork.AcptAnOdrStatus;
            depositParam.DepositDebitNoteCd = depositMainWork.DepositDebitNoteCd;
            depositParam.DepositSlipNo = depositMainWork.DepositSlipNo;
            depositParam.SalesSlipNum = depositMainWork.SalesSlipNum;
            depositParam.InputDepositSecCd = depositMainWork.InputDepositSecCd;
            depositParam.AddUpSecCode = depositMainWork.AddUpSecCode;
            depositParam.UpdateSecCd = depositMainWork.UpdateSecCd;
            depositParam.SubSectionCode = depositMainWork.SubSectionCode;
            depositParam.MinSectionCode = depositMainWork.MinSectionCode;
            depositParam.DepositDate = depositMainWork.DepositDate;
            depositParam.AddUpADate = depositMainWork.AddUpADate;
            depositParam.DepositKindCode = depositMainWork.DepositKindCode;
            depositParam.DepositKindName = depositMainWork.DepositKindName;
            depositParam.DepositKindDivCd = depositMainWork.DepositKindDivCd;
            depositParam.DepositTotal = depositMainWork.DepositTotal;
            depositParam.Deposit = depositMainWork.Deposit;
            depositParam.FeeDeposit = depositMainWork.FeeDeposit;
            depositParam.DiscountDeposit = depositMainWork.DiscountDeposit;
            depositParam.AutoDepositCd = depositMainWork.AutoDepositCd;
            depositParam.DepositCd = depositMainWork.DepositCd;
            depositParam.DraftDrawingDate = depositMainWork.DraftDrawingDate;
            depositParam.DraftPayTimeLimit = depositMainWork.DraftPayTimeLimit;
            depositParam.DraftKind = depositMainWork.DraftKind;
            depositParam.DraftKindName = depositMainWork.DraftKindName;
            depositParam.DraftDivide = depositMainWork.DraftDivide;
            depositParam.DraftDivideName = depositMainWork.DraftDivideName;
            depositParam.DraftNo = depositMainWork.DraftNo;
            depositParam.DepositAllowance = depositMainWork.DepositAllowance;
            depositParam.DepositAlwcBlnce = depositMainWork.DepositAlwcBlnce;
            depositParam.DebitNoteLinkDepoNo = depositMainWork.DebitNoteLinkDepoNo;
            depositParam.LastReconcileAddUpDt = depositMainWork.LastReconcileAddUpDt;
            depositParam.DepositAgentCode = depositMainWork.DepositAgentCode;
            depositParam.DepositAgentNm = depositMainWork.DepositAgentNm;
            depositParam.DepositInputAgentCd = depositMainWork.DepositInputAgentCd;
            depositParam.DepositInputAgentNm = depositMainWork.DepositInputAgentNm;
            depositParam.CustomerCode = depositMainWork.CustomerCode;
            depositParam.CustomerName = depositMainWork.CustomerName;
            depositParam.CustomerName2 = depositMainWork.CustomerName2;
            depositParam.CustomerSnm = depositMainWork.CustomerSnm;
            depositParam.ClaimCode = depositMainWork.ClaimCode;
            depositParam.ClaimName = depositMainWork.ClaimName;
            depositParam.ClaimName2 = depositMainWork.ClaimName2;
            depositParam.ClaimSnm = depositMainWork.ClaimSnm;
            depositParam.Outline = depositMainWork.Outline;
            depositParam.BankCode = depositMainWork.BankCode;
            depositParam.BankName = depositMainWork.BankName;
            depositParam.EdiSendDate = depositMainWork.EdiSendDate;
            depositParam.EdiTakeInDate = depositMainWork.EdiTakeInDate;
                
            //depositParamList.ReconcileDate = depositAlwWorkList.ReconcileDate;
            //depositParamList.ReconcileAddUpDate = depositAlwWorkList.ReconcileAddUpDate;
            //depositParamList.DepositAllowance = depositAlwWorkList.DepositAllowance;
            //depositParamList.DebitNoteOffSetCd = depositAlwWorkList.DebitNoteOffSetCd;
            return depositParam;
        }
        */
# endif
        #endregion

        #region パラメータ処理用 InnerClass
        /// <summary>
        /// 入金-入金引当を関連付ける
        /// </summary>
        //>>>2010/09/28
        //private class DepositInfo
        public class DepositInfo
        //<<<2010/09/28
        {
            private DepsitDataWork depsitDataWork = null;
            private DepositAlwWork[] depositAlwWorkArray = null;

            public DepsitDataWork DepsitDataWork
            {
                get { return depsitDataWork; }
                set { depsitDataWork = value; }
            }

            public DepositAlwWork[] DepositAlwWorkArray
            {
                get { return depositAlwWorkArray; }
                set { depositAlwWorkArray = value; }
            }
        }
        #endregion

        # region --- DEL ---
# if false

        /// <summary>
        /// 拠点制御設定マスタから請求計上拠点コードを取得する
        /// </summary>
        /// <param name="depositWork">入金データ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 拠点制御設定マスタから請求計上拠点コードを取得する</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.11.26</br>
        private int SearchClaimSecCd(ref DepsitMainWork depositWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                    sqlCommand.CommandText = "SELECT CTRLFUNCSECTIONCODERF FROM SECCTRLSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CTRLFUNCCODERF=20";

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(depositWork.InputDepositSecCd);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        depositWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CTRLFUNCSECTIONCODERF"));
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 売上リモート List ユーティリティクラス
        /// </summary>
        private class ListUtils
        {
            /// <summary>検索パターン Find() で利用</summary>
            public enum FIND_TYPE
            {
                /// <summary>クラス</summary>
                Class,
                /// <summary>Array</summary>
                Array
            }

            /// <summary>
            /// CustomArrayList から指定した型のオブジェクトを取得する
            /// </summary>
            /// <param name="paramArray">検査対象パラメータList</param>
            /// <param name="type">検索対象タイプ</param>
            /// <param name="pattern">検索パターン</param>
            /// <param name="position">パラメータ位置</param>
            /// <returns>オブジェクト</returns>
            public static object Find(CustomSerializeArrayList paramArray, Type type, FIND_TYPE pattern, out int position)
            {
                object result = null;
                position = -1;
                if (IsEmpty(paramArray)) return result;
                //パラメータを取得
                if (pattern == FIND_TYPE.Class)
                {
                    for (int i = 0; i < paramArray.Count; i++)
                    {
                        if (paramArray[i] != null && paramArray[i].GetType() == type)
                        {
                            result = paramArray[i];
                            position = i;
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
                                    result = paramArray[i];
                                    position = i;
                                    break;
                                }
                            }
                        }
                    }
                }
                return result;
            }
            /// <summary>
            /// CustomArrayList から指定した型のオブジェクトを取得する
            /// </summary>
            /// <param name="paramArray">検査対象パラメータList</param>
            /// <param name="type">検索対象タイプ</param>
            /// <param name="pattern">検索パターン</param>
            /// <returns>オブジェクト</returns>
            public static object Find(CustomSerializeArrayList paramArray, Type type, FIND_TYPE pattern)
            {
                int position;
                return Find(paramArray, type, pattern, out position);
            }

            /// <summary>
            /// ArrayListが空かどうかを判断する
            /// </summary>
            /// <param name="al">検査対象ArrayList</param>
            /// <returns>true:空 false:空でない</returns>
            public static bool IsEmpty(ArrayList al)
            {
                if (al == null || al.Count <= 0) return true;
                return false;
            }
            /// <summary>
            /// ArrayListが空かどうかを判断する
            /// </summary>
            /// <param name="al">検査対象ArrayList</param>
            /// <returns>true:空でない false:空</returns>
            public static bool IsNotEmpty(ArrayList al)
            {
                return !IsEmpty(al);
            }
        }
# endif
        # endregion

        #region Comparer
        /// <summary>
        /// 入金マスタ比較クラス
        /// </summary>
        /// <remarks>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.05.15</br>
        /// </remarks>
        private class DepositDataComparer : System.Collections.IComparer
        {
            public int Compare(object x, object y)
            {
                int result = 0;

                DepsitDataWork cx = x as DepsitDataWork;
                DepsitDataWork cy = y as DepsitDataWork;

                result = (cx == null ? 0 : 1) - (cy == null ? 0 : 1);

                //入金伝票番号
                if (result == 0 && cx != null)
                {
                    result = cx.DepositSlipNo - cy.DepositSlipNo;
                }

                //結果を返す
                return result;
            }
        }
        /// <summary>
        /// 入金引当マスタ比較クラス
        /// </summary>
        /// <remarks>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.05.15</br>
        /// </remarks>
        private class DepositAlwComparer : System.Collections.IComparer
        {
            public int Compare(object x, object y)
            {
                int result = 0;

                DepositAlwWork cx = (DepositAlwWork)x;
                DepositAlwWork cy = (DepositAlwWork)y;

                //入金伝票番号
                if (result == 0)
                    result = cx.DepositSlipNo - cy.DepositSlipNo;

                //売上伝票番号
                try
                {
                    if (result == 0)
                        result = int.Parse(cx.SalesSlipNum) - int.Parse(cy.SalesSlipNum);
                }
                catch
                {
                    result = 0;
                }

                //結果を返す
                return result;
            }
        }
        #endregion
    }
}

//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   車両管理マスタDBリモートオブジェクト
//                  :   PMSYR09011R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21112　久保田
// Date             :   2008.06.02
//----------------------------------------------------------------------
// Update Note      :   2009/09/11 李占川
//                      車輌管理マスタ LDNS開発対応
// Update Note      :   2009/12/24 對馬 大輔
//                      MANTIS[14822] 車輌管理マスタ　キー追加対応
// Update Note      :   2010/04/27 gaoyh
//                      車輌管理マスタ 自由検索型式固定番号配列を追加
// Update Note      :   2011/03/22 曹文傑
//                      照会プログラムのログ出力対応
// Update Note      :   2011/04/06 曹文傑
//                      Redmine#20389の対応（帳票系ログ出力対応の仕様変更）
// Update Note      :   2012/08/30 脇田　靖之
//                      売伝修正時に車輛管理マスタの内容がクリアされる障害の修正
// Update Note      :   2013/01/11 黄興貴
// 管理番号         :   10801804-00 2013/03/13配信分
//                      Redmine#32256 車輌管理マスタに削除済みのデータが復活と完全削除操作できない障害の修正
// Update Note      :   2013/03/22 FSI高橋 文彰
// 管理番号         :   10900269-00 
//                      SPK車台番号文字列対応に伴う国産/外車区分の追加
// Update Note      :   2015/03/23 宮本 利明
// 管理番号         :   11070149-00
//                      日之出商会の車輌管理登録(売伝入力時)の障害対応
// Update Note      :   2020/08/28 田建委
// 管理番号         :   11600006-00
//                      PMKOBETSU-4076 タイムアウト設定
// Update Note      :   2021/11/02 佐々木亘
// 管理番号         :   11770175-00
//                      OUT OF MEMORY対応(4GB対応) 車輌管理マスタ保守　抽出対象件数を最大件数20001件まで（20000件まで画面表示）
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
// --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>>
using Microsoft.Win32;
using System.Xml;
using System.IO;
// --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 車両管理マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 車両管理マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 21112　久保田</br>
    /// <br>Date       : 2008.06.02</br>
    /// <br></br>
    /// <br>Update Note: 2011/03/22 曹文傑</br>
    /// <br>             照会プログラムのログ出力対応</br>
    /// <br>Update Note: 2011/04/06 曹文傑</br>
    /// <br>             Redmine#20389の対応（帳票系ログ出力対応の仕様変更）</br>
    /// <br>Update Note: 2013/01/11 黄興貴</br>
    /// <br>管理番号   : 10801804-00 2013/03/13配信分</br>
    /// <br>             Redmine#32256 車輌管理マスタに削除済みのデータが復活と完全削除操作できない障害の修正</br>
    /// <br>Update Note: 2013/03/22 FSI高橋 文彰</br>
    /// <br>管理番号   : 10900269-00</br>
    /// <br>             SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
    /// <br>Update Note: PMKOBETSU-4076 タイムアウト設定</br>
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2020/08/28</br>
    /// <br>Update Note: 2021/11/02 佐々木亘</br>
    /// <br>管理番号   : 11770175-00</br>
    /// <br>             OUT OF MEMORY対応(4GB対応) 車輌管理マスタ保守　抽出対象件数を最大件数20001件まで（20000件まで画面表示）</br>
    /// </remarks>
    [Serializable]
    public class CarManagementDB : RemoteWithAppLockDB, ICarManagementDB
    {
        private bool _CompulsoryDataOverride = false;

        // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>> 
        // 伝票更新タイムアウト時間設定ファイル
        private const string XML_FILE_NAME = "DbCommandTimeoutSet.xml";
        // XMLファイルが無い時のデフォルト値
        private const int DB_COMMAND_TIMEOUT = 120;
        // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<

        // --- ADD 佐々木亘 2021/11/02 ------>>>>> 
        // 最大抽出件数
        private const int MAX_MST_RECORD_COUNT = 20001;
        // --- ADD 佐々木亘 2021/11/02 ------<<<<<

        /// <summary>
        /// 車両管理マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.06.02</br>
        /// </remarks>
        public CarManagementDB() : base("PMSYR09013D", "Broadleaf.Application.Remoting.ParamData.CarManagementWork", "CARMANAGEMENTRF")
        {
            this._CompulsoryDataOverride = false;
        }

        /// <summary>
        /// 車両管理マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <param name="compulsoryDataOverride">false(標準):更新日付等を考慮してデータの更新を行う。　true:更新日付などを無視してデータの更新を行う。</param>
        /// <remarks>
        /// <br>Note       : 本コンストラクタを使用する際は、CompulsoryDataOverrideの取扱いに十分注意する事</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.06.02</br>
        /// </remarks>
        public CarManagementDB(bool compulsoryDataOverride)
            : base("PMSYR09013D", "Broadleaf.Application.Remoting.ParamData.CarManagementWork", "CARMANAGEMENTRF")
        {
            this._CompulsoryDataOverride = true;
        }


        # region [Read]
        /// <summary>
        /// 単一の車両管理マスタ情報を取得します。
        /// </summary>
        /// <param name="carManagementObj">CarManagementWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 車両管理マスタのキー値が一致する車両管理マスタ情報を取得します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.06.02</br>
        public int Read(ref object carManagementObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                CarManagementWork carManagementWork = carManagementObj as CarManagementWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref carManagementWork, readMode, sqlConnection, sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
                    }

                    sqlTransaction.Dispose();
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
        /// 単一の車両管理マスタ情報を取得します。
        /// </summary>
        /// <param name="carManagementWork">CarManagementWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 車両管理マスタのキー値が一致する車両管理マスタ情報を取得します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.06.02</br>
        public int Read(ref CarManagementWork carManagementWork, int readMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref carManagementWork, readMode, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// 単一の車両管理マスタ情報を取得します。
        /// </summary>
        /// <param name="carManagementWork">CarManagementWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 車両管理マスタのキー値が一致する車両管理マスタ情報を取得します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.06.02</br>
        /// <br>Update Note: 2013/03/22 FSI高橋 文彰</br>
        /// <br>管理番号   : 10900269-00</br>
        /// <br>             SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
        private int ReadProc(ref CarManagementWork carManagementWork, int readMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                // sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction); // DEL 2009/09/11

                # region [SELECT文]
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  CARM.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CARM.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CARM.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,CARM.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,CARM.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,CARM.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,CARM.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,CARM.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,CARM.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += " ,CARM.CARMNGNORF" + Environment.NewLine;
                sqlText += " ,CARM.CARMNGCODERF" + Environment.NewLine;
                sqlText += " ,CARM.NUMBERPLATE1CODERF" + Environment.NewLine;
                sqlText += " ,CARM.NUMBERPLATE1NAMERF" + Environment.NewLine;
                sqlText += " ,CARM.NUMBERPLATE2RF" + Environment.NewLine;
                sqlText += " ,CARM.NUMBERPLATE3RF" + Environment.NewLine;
                sqlText += " ,CARM.NUMBERPLATE4RF" + Environment.NewLine;
                sqlText += " ,CARM.ENTRYDATERF" + Environment.NewLine;
                sqlText += " ,CARM.FIRSTENTRYDATERF" + Environment.NewLine;
                sqlText += " ,CARM.MAKERCODERF" + Environment.NewLine;
                sqlText += " ,CARM.MAKERFULLNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.MAKERHALFNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.MODELCODERF" + Environment.NewLine;
                sqlText += " ,CARM.MODELSUBCODERF" + Environment.NewLine;
                sqlText += " ,CARM.MODELFULLNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.MODELHALFNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.SYSTEMATICCODERF" + Environment.NewLine;
                sqlText += " ,CARM.SYSTEMATICNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.PRODUCETYPEOFYEARCDRF" + Environment.NewLine;
                sqlText += " ,CARM.PRODUCETYPEOFYEARNMRF" + Environment.NewLine;
                sqlText += " ,CARM.STPRODUCETYPEOFYEARRF" + Environment.NewLine;
                sqlText += " ,CARM.EDPRODUCETYPEOFYEARRF" + Environment.NewLine;
                sqlText += " ,CARM.DOORCOUNTRF" + Environment.NewLine;
                sqlText += " ,CARM.BODYNAMECODERF" + Environment.NewLine;
                sqlText += " ,CARM.BODYNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.EXHAUSTGASSIGNRF" + Environment.NewLine;
                sqlText += " ,CARM.SERIESMODELRF" + Environment.NewLine;
                sqlText += " ,CARM.CATEGORYSIGNMODELRF" + Environment.NewLine;
                sqlText += " ,CARM.FULLMODELRF" + Environment.NewLine;
                sqlText += " ,CARM.MODELDESIGNATIONNORF" + Environment.NewLine;
                sqlText += " ,CARM.CATEGORYNORF" + Environment.NewLine;
                sqlText += " ,CARM.FRAMEMODELRF" + Environment.NewLine;
                sqlText += " ,CARM.FRAMENORF" + Environment.NewLine;
                sqlText += " ,CARM.SEARCHFRAMENORF" + Environment.NewLine;
                sqlText += " ,CARM.STPRODUCEFRAMENORF" + Environment.NewLine;
                sqlText += " ,CARM.EDPRODUCEFRAMENORF" + Environment.NewLine;
                sqlText += " ,CARM.ENGINEMODELRF" + Environment.NewLine;
                sqlText += " ,CARM.MODELGRADENMRF" + Environment.NewLine;
                sqlText += " ,CARM.ENGINEMODELNMRF" + Environment.NewLine;
                sqlText += " ,CARM.ENGINEDISPLACENMRF" + Environment.NewLine;
                sqlText += " ,CARM.EDIVNMRF" + Environment.NewLine;
                sqlText += " ,CARM.TRANSMISSIONNMRF" + Environment.NewLine;
                sqlText += " ,CARM.SHIFTNMRF" + Environment.NewLine;
                sqlText += " ,CARM.WHEELDRIVEMETHODNMRF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPEC1RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPEC2RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPEC3RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPEC4RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPEC5RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPEC6RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPECTITLE1RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPECTITLE2RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPECTITLE3RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPECTITLE4RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPECTITLE5RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPECTITLE6RF" + Environment.NewLine;
                sqlText += " ,CARM.RELEVANCEMODELRF" + Environment.NewLine;
                sqlText += " ,CARM.SUBCARNMCDRF" + Environment.NewLine;
                sqlText += " ,CARM.MODELGRADESNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.BLOCKILLUSTRATIONCDRF" + Environment.NewLine;
                sqlText += " ,CARM.THREEDILLUSTNORF" + Environment.NewLine;
                sqlText += " ,CARM.PARTSDATAOFFERFLAGRF" + Environment.NewLine;
                sqlText += " ,CARM.INSPECTMATURITYDATERF" + Environment.NewLine;
                sqlText += " ,CARM.LTIMECIMATDATERF" + Environment.NewLine;
                sqlText += " ,CARM.CARINSPECTYEARRF" + Environment.NewLine;
                sqlText += " ,CARM.MILEAGERF" + Environment.NewLine;
                sqlText += " ,CARM.CARNORF" + Environment.NewLine;
                sqlText += " ,CARM.COLORCODERF" + Environment.NewLine;
                sqlText += " ,CARM.COLORNAME1RF" + Environment.NewLine;
                sqlText += " ,CARM.TRIMCODERF" + Environment.NewLine;
                sqlText += " ,CARM.TRIMNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.FULLMODELFIXEDNOARYRF" + Environment.NewLine;
                sqlText += " ,CARM.CATEGORYOBJARYRF" + Environment.NewLine;
                // --- ADD 2009/09/11 -------------->>>
                sqlText += " ,CARM.CARADDINFO1RF" + Environment.NewLine;
                sqlText += " ,CARM.CARADDINFO2RF" + Environment.NewLine;
                sqlText += " ,CARM.CARNOTERF" + Environment.NewLine;
                // --- ADD 2009/09/11 --------------<<<
                // --- ADD 2009/04/26 -------------->>>
                sqlText += " ,CARM.FREESRCHMDLFXDNOARYRF" + Environment.NewLine;
                // --- ADD 2010/04/26 -------------->>>
                // ADD 2013/03/22  -------------------->>>>>
                sqlText += " ,CARM.DOMESTICFOREIGNCODERF" + Environment.NewLine;
                sqlText += " ,CARM.HANDLEINFOCDRF" + Environment.NewLine;
                // ADD 2013/03/22  --------------------<<<<<
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  CARMANAGEMENTRF AS CARM" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  CARM.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CARM.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                sqlText += "  AND CARM.CARMNGNORF = @FINDCARMNGNO" + Environment.NewLine;
                sqlText += "  AND CARM.CARMNGCODERF = @FINDCARMNGCODE" + Environment.NewLine; // 2009/12/24
                # endregion                

                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction); // ADD 2009/09/11

                // Prameterオブジェクトの作成
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                SqlParameter findCarMngNo = sqlCommand.Parameters.Add("@FINDCARMNGNO", SqlDbType.Int);
                SqlParameter findCarMngCode = sqlCommand.Parameters.Add("@FINDCARMNGCODE", SqlDbType.NChar); // 2009/12/24

                // Parameterオブジェクトへ値設定
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(carManagementWork.EnterpriseCode);
                findCustomerCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CustomerCode);
                findCarMngNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CarMngNo);
                findCarMngCode.Value = SqlDataMediator.SqlSetString(carManagementWork.CarMngCode); // 2009/12/24

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToCarManagementWorkFromReader(ref myReader, ref carManagementWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        # endregion

        # region [Delete]
        /// <summary>
        /// 車両管理マスタ情報を物理削除します
        /// </summary>
        /// <param name="carManagementList">物理削除する車両管理マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 車両管理マスタのキー値が一致する車両管理マスタ情報を物理削除します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.06.02</br>
        public int Delete(object carManagementList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = carManagementList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.Delete(paraList, sqlConnection, sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ロールバック
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
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
        /// 車両管理マスタ情報を物理削除します
        /// </summary>
        /// <param name="carManagementList">車両管理マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : carManagementList に格納されている車両管理マスタ情報を物理削除します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.06.02</br>
        public int Delete(ArrayList carManagementList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(carManagementList, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// 車両管理マスタ情報を物理削除します
        /// </summary>
        /// <param name="carManagementList">車両管理マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : carManagementList に格納されている車両管理マスタ情報を物理削除します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.06.02</br>
        /// <br>Update Note: 2013/01/11 黄興貴</br>
        /// <br>管理番号   : 10801804-00 2013/03/13配信分</br>
        /// <br>             Redmine#32256 車輌管理マスタに削除済みのデータが復活と完全削除操作できない障害の修正</br>
        private int DeleteProc(ArrayList carManagementList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (carManagementList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < carManagementList.Count; i++)
                    {
                        CarManagementWork carManagementWork = carManagementList[i] as CarManagementWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  CARM.UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  CARMANAGEMENTRF AS CARM" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  CARM.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND CARM.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlText += "  AND CARM.CARMNGNORF = @FINDCARMNGNO" + Environment.NewLine;
                        sqlText += "  AND CARM.CARMNGCODERF = @FINDCARMNGCODE" + Environment.NewLine;// ADD 黄興貴 2013/01/11 for redmine 32256
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findCarMngNo = sqlCommand.Parameters.Add("@FINDCARMNGNO", SqlDbType.Int);
                        SqlParameter findCarMngCode = sqlCommand.Parameters.Add("@FINDCARMNGCODE", SqlDbType.NChar); // ADD 黄興貴 2013/01/11 for redmine 32256

                        // Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(carManagementWork.EnterpriseCode);
                        findCustomerCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CustomerCode);
                        findCarMngNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CarMngNo);
                        findCarMngCode.Value = SqlDataMediator.SqlSetString(carManagementWork.CarMngCode); // ADD 黄興貴 2013/01/11 for redmine 32256

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != carManagementWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE文]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  CARMANAGEMENTRF" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                            sqlText += "  AND CARMNGNORF = @FINDCARMNGNO" + Environment.NewLine;
                            sqlText += "  AND CARMNGCODERF = @FINDCARMNGCODE" + Environment.NewLine; // ADD 黄興貴 2013/01/11 for redmine 32256
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(carManagementWork.EnterpriseCode);
                            findCustomerCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CustomerCode);
                            findCarMngNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CarMngNo);
                            findCarMngCode.Value = SqlDataMediator.SqlSetString(carManagementWork.CarMngCode); // ADD 黄興貴 2013/01/11 for redmine 32256
                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        sqlCommand.ExecuteNonQuery();
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        # endregion

        # region [Search]
        /// <summary>
        /// 車両管理マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="carManagementList">検索結果</param>
        /// <param name="carManagementObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 車両管理マスタのキー値が一致する、全ての車両管理マスタ情報を取得します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.06.02</br>
        /// <br>Update Note: 2011/03/22 曹文傑</br>
        /// <br>             照会プログラムのログ出力対応</br>
        public int Search(ref object carManagementList, object carManagementObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList carManagementArray = carManagementList as ArrayList;
                CarManagementWork carManagementWork = carManagementObj as CarManagementWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // ---ADD 2011/03/22---------->>>>>
                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                bool checkId = oprtnHisLogDB.CheckClientAssemblyId("PMSYA04001U");
                if (checkId) oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, carManagementWork.EnterpriseCode, "車輌出荷部品表示(車輌検索)", "抽出開始");
                // ---ADD 2011/03/22----------<<<<<

                status = this.Search(ref carManagementArray, carManagementWork, readMode, logicalMode, sqlConnection, sqlTransaction);

                // ---ADD 2011/03/22---------->>>>>
                if (checkId) oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, carManagementWork.EnterpriseCode, "車輌出荷部品表示(車輌検索)", "抽出終了");
                // ---ADD 2011/03/22----------<<<<<
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
                    }

                    sqlTransaction.Dispose();
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
        /// 車両管理マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="carManagementList">車両管理マスタ情報を格納する ArrayList</param>
        /// <param name="carManagementWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 車両管理マスタのキー値が一致する、全ての車両管理マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.06.02</br>
        /// <br>Update Note: 2009/09/11 李占川 LDNS開発対応</br>
        public int Search(ref ArrayList carManagementList, CarManagementWork carManagementWork, int readMode, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            // --- UPD 2009/09/11 -------------->>>
            //return this.Search(ref carManagementList, carManagementWork, readMode, logicalMode, sqlConnection, sqlTransaction);
            return this.SearchProc(ref carManagementList, carManagementWork, readMode, logicalMode, sqlConnection, sqlTransaction);
            // --- UPD 2009/09/11 --------------<<<
        }

        /// <summary>
        /// 車両管理マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="carManagementList">車両管理マスタ情報を格納する ArrayList</param>
        /// <param name="carManagementWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 車両管理マスタのキー値が一致する、全ての車両管理マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.06.02</br>
        /// <br>Update Note: 2013/03/22 FSI高橋 文彰</br>
        /// <br>管理番号   : 10900269-00</br>
        /// <br>             SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
        /// <br>Update Note: 2021/11/02 佐々木亘</br>
        /// <br>管理番号   : 11770175-00</br>
        /// <br>             OUT OF MEMORY対応(4GB対応) 車輌管理マスタ保守　抽出対象件数を最大件数20001件まで（20000件まで画面表示）</br>
        private int SearchProc(ref ArrayList carManagementList, CarManagementWork carManagementWork, int readMode, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT文]
                sqlText += "SELECT" + Environment.NewLine;
                // --- ADD 佐々木亘 2021/11/02 ------>>>>> 
                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                bool checkId = oprtnHisLogDB.CheckClientAssemblyId("PMSYA04001U");
                if (checkId == true)
                {
                    // 車輌出荷部品表示(車輌検索)
                }
                else
                {
                    sqlText += string.Format(" TOP {0} ", MAX_MST_RECORD_COUNT) + Environment.NewLine;
                }
                // --- ADD 佐々木亘 2021/11/02 ------<<<<<
                sqlText += "  CARM.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CARM.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CARM.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,CARM.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,CARM.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,CARM.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,CARM.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,CARM.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,CARM.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += " ,CARM.CARMNGNORF" + Environment.NewLine;
                sqlText += " ,CARM.CARMNGCODERF" + Environment.NewLine;
                sqlText += " ,CARM.NUMBERPLATE1CODERF" + Environment.NewLine;
                sqlText += " ,CARM.NUMBERPLATE1NAMERF" + Environment.NewLine;
                sqlText += " ,CARM.NUMBERPLATE2RF" + Environment.NewLine;
                sqlText += " ,CARM.NUMBERPLATE3RF" + Environment.NewLine;
                sqlText += " ,CARM.NUMBERPLATE4RF" + Environment.NewLine;
                sqlText += " ,CARM.ENTRYDATERF" + Environment.NewLine;
                sqlText += " ,CARM.FIRSTENTRYDATERF" + Environment.NewLine;
                sqlText += " ,CARM.MAKERCODERF" + Environment.NewLine;
                sqlText += " ,CARM.MAKERFULLNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.MAKERHALFNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.MODELCODERF" + Environment.NewLine;
                sqlText += " ,CARM.MODELSUBCODERF" + Environment.NewLine;
                sqlText += " ,CARM.MODELFULLNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.MODELHALFNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.SYSTEMATICCODERF" + Environment.NewLine;
                sqlText += " ,CARM.SYSTEMATICNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.PRODUCETYPEOFYEARCDRF" + Environment.NewLine;
                sqlText += " ,CARM.PRODUCETYPEOFYEARNMRF" + Environment.NewLine;
                sqlText += " ,CARM.STPRODUCETYPEOFYEARRF" + Environment.NewLine;
                sqlText += " ,CARM.EDPRODUCETYPEOFYEARRF" + Environment.NewLine;
                sqlText += " ,CARM.DOORCOUNTRF" + Environment.NewLine;
                sqlText += " ,CARM.BODYNAMECODERF" + Environment.NewLine;
                sqlText += " ,CARM.BODYNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.EXHAUSTGASSIGNRF" + Environment.NewLine;
                sqlText += " ,CARM.SERIESMODELRF" + Environment.NewLine;
                sqlText += " ,CARM.CATEGORYSIGNMODELRF" + Environment.NewLine;
                sqlText += " ,CARM.FULLMODELRF" + Environment.NewLine;
                sqlText += " ,CARM.MODELDESIGNATIONNORF" + Environment.NewLine;
                sqlText += " ,CARM.CATEGORYNORF" + Environment.NewLine;
                sqlText += " ,CARM.FRAMEMODELRF" + Environment.NewLine;
                sqlText += " ,CARM.FRAMENORF" + Environment.NewLine;
                sqlText += " ,CARM.SEARCHFRAMENORF" + Environment.NewLine;
                sqlText += " ,CARM.STPRODUCEFRAMENORF" + Environment.NewLine;
                sqlText += " ,CARM.EDPRODUCEFRAMENORF" + Environment.NewLine;
                sqlText += " ,CARM.ENGINEMODELRF" + Environment.NewLine;
                sqlText += " ,CARM.MODELGRADENMRF" + Environment.NewLine;
                sqlText += " ,CARM.ENGINEMODELNMRF" + Environment.NewLine;
                sqlText += " ,CARM.ENGINEDISPLACENMRF" + Environment.NewLine;
                sqlText += " ,CARM.EDIVNMRF" + Environment.NewLine;
                sqlText += " ,CARM.TRANSMISSIONNMRF" + Environment.NewLine;
                sqlText += " ,CARM.SHIFTNMRF" + Environment.NewLine;
                sqlText += " ,CARM.WHEELDRIVEMETHODNMRF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPEC1RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPEC2RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPEC3RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPEC4RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPEC5RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPEC6RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPECTITLE1RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPECTITLE2RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPECTITLE3RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPECTITLE4RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPECTITLE5RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPECTITLE6RF" + Environment.NewLine;
                sqlText += " ,CARM.RELEVANCEMODELRF" + Environment.NewLine;
                sqlText += " ,CARM.SUBCARNMCDRF" + Environment.NewLine;
                sqlText += " ,CARM.MODELGRADESNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.BLOCKILLUSTRATIONCDRF" + Environment.NewLine;
                sqlText += " ,CARM.THREEDILLUSTNORF" + Environment.NewLine;
                sqlText += " ,CARM.PARTSDATAOFFERFLAGRF" + Environment.NewLine;
                sqlText += " ,CARM.INSPECTMATURITYDATERF" + Environment.NewLine;
                sqlText += " ,CARM.LTIMECIMATDATERF" + Environment.NewLine;
                sqlText += " ,CARM.CARINSPECTYEARRF" + Environment.NewLine;
                sqlText += " ,CARM.MILEAGERF" + Environment.NewLine;
                sqlText += " ,CARM.CARNORF" + Environment.NewLine;
                sqlText += " ,CARM.COLORCODERF" + Environment.NewLine;
                sqlText += " ,CARM.COLORNAME1RF" + Environment.NewLine;
                sqlText += " ,CARM.TRIMCODERF" + Environment.NewLine;
                sqlText += " ,CARM.TRIMNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.FULLMODELFIXEDNOARYRF" + Environment.NewLine;
                sqlText += " ,CARM.CATEGORYOBJARYRF" + Environment.NewLine;
                // --- ADD 2009/09/11 ---------->>>>>
                sqlText += " ,CARM.CARADDINFO1RF" + Environment.NewLine;
                sqlText += " ,CARM.CARADDINFO2RF" + Environment.NewLine;
                sqlText += " ,CARM.CARNOTERF" + Environment.NewLine;
                // --- ADD 2009/09/11 ----------<<<<<
                // --- ADD 2009/04/26 -------------->>>
                sqlText += " ,CARM.FREESRCHMDLFXDNOARYRF" + Environment.NewLine;
                // --- ADD 2010/04/26 -------------->>>
                // ADD 2013/03/22  -------------------->>>>>
                sqlText += " ,CARM.DOMESTICFOREIGNCODERF" + Environment.NewLine;
                sqlText += " ,CARM.HANDLEINFOCDRF" + Environment.NewLine;
                // ADD 2013/03/22  --------------------<<<<<
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  CARMANAGEMENTRF AS CARM" + Environment.NewLine; sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, carManagementWork, logicalMode);
                // --- ADD 2009/09/11 ---------->>>>>
                sqlCommand.CommandText += " ORDER BY CARM.CUSTOMERCODERF";
                sqlCommand.CommandText += " ,CARM.CARMNGCODERF";
                sqlCommand.CommandText += " ,CARM.CARMNGNORF";
                // --- ADD 2009/09/11 ----------<<<<<
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    carManagementList.Add(this.CopyToCarManagementWorkFromReader(ref myReader));
                }

                if (carManagementList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        # endregion

        # region [SearchGuide]
        // --- ADD 2009/09/11 -------------->>>
        /// <summary>
        /// 車両管理マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="carMngGuideWorkObj">検索条件</param>
        /// <param name="carMngWorkListObj">車両管理マスタ情報を格納する ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 車両管理マスタのキー値が一致する、全ての車両管理マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/11</br>
        public int SearchGuide(object carMngGuideWorkObj, out object carMngWorkListObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            carMngWorkListObj = new object();

            try
            {
                CarMngGuideParamWork carMngGuideWork = carMngGuideWorkObj as CarMngGuideParamWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                ArrayList carMngWorkList = new ArrayList();
                status = this.SearchGuideProc(carMngGuideWork, out carMngWorkList, sqlConnection, sqlTransaction);
                carMngWorkListObj = carMngWorkList as object;
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
                    }

                    sqlTransaction.Dispose();
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
        /// 車両管理マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="carManagementList">車両管理マスタ情報を格納する ArrayList</param>
        /// <param name="carMngGuideWork">検索条件</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 車両管理マスタのキー値が一致する、全ての車両管理マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/11</br>
        /// <br>Update Note: 2013/03/22 FSI高橋 国産外車区分対応</br>
        private int SearchGuideProc(CarMngGuideParamWork carMngGuideWork, out ArrayList carManagementList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            carManagementList = new ArrayList();
            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT文]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  CARM.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CARM.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CARM.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,CARM.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,CARM.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,CARM.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,CARM.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,CARM.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,CARM.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += " ,CARM.CARMNGNORF" + Environment.NewLine;
                sqlText += " ,CARM.CARMNGCODERF" + Environment.NewLine;
                sqlText += " ,CARM.NUMBERPLATE1CODERF" + Environment.NewLine;
                sqlText += " ,CARM.NUMBERPLATE1NAMERF" + Environment.NewLine;
                sqlText += " ,CARM.NUMBERPLATE2RF" + Environment.NewLine;
                sqlText += " ,CARM.NUMBERPLATE3RF" + Environment.NewLine;
                sqlText += " ,CARM.NUMBERPLATE4RF" + Environment.NewLine;
                sqlText += " ,CARM.ENTRYDATERF" + Environment.NewLine;
                sqlText += " ,CARM.FIRSTENTRYDATERF" + Environment.NewLine;
                sqlText += " ,CARM.MAKERCODERF" + Environment.NewLine;
                sqlText += " ,CARM.MAKERFULLNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.MAKERHALFNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.MODELCODERF" + Environment.NewLine;
                sqlText += " ,CARM.MODELSUBCODERF" + Environment.NewLine;
                sqlText += " ,CARM.MODELFULLNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.MODELHALFNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.SYSTEMATICCODERF" + Environment.NewLine;
                sqlText += " ,CARM.SYSTEMATICNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.PRODUCETYPEOFYEARCDRF" + Environment.NewLine;
                sqlText += " ,CARM.PRODUCETYPEOFYEARNMRF" + Environment.NewLine;
                sqlText += " ,CARM.STPRODUCETYPEOFYEARRF" + Environment.NewLine;
                sqlText += " ,CARM.EDPRODUCETYPEOFYEARRF" + Environment.NewLine;
                sqlText += " ,CARM.DOORCOUNTRF" + Environment.NewLine;
                sqlText += " ,CARM.BODYNAMECODERF" + Environment.NewLine;
                sqlText += " ,CARM.BODYNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.EXHAUSTGASSIGNRF" + Environment.NewLine;
                sqlText += " ,CARM.SERIESMODELRF" + Environment.NewLine;
                sqlText += " ,CARM.CATEGORYSIGNMODELRF" + Environment.NewLine;
                sqlText += " ,CARM.FULLMODELRF" + Environment.NewLine;
                sqlText += " ,CARM.MODELDESIGNATIONNORF" + Environment.NewLine;
                sqlText += " ,CARM.CATEGORYNORF" + Environment.NewLine;
                sqlText += " ,CARM.FRAMEMODELRF" + Environment.NewLine;
                sqlText += " ,CARM.FRAMENORF" + Environment.NewLine;
                sqlText += " ,CARM.SEARCHFRAMENORF" + Environment.NewLine;
                sqlText += " ,CARM.STPRODUCEFRAMENORF" + Environment.NewLine;
                sqlText += " ,CARM.EDPRODUCEFRAMENORF" + Environment.NewLine;
                sqlText += " ,CARM.ENGINEMODELRF" + Environment.NewLine;
                sqlText += " ,CARM.MODELGRADENMRF" + Environment.NewLine;
                sqlText += " ,CARM.ENGINEMODELNMRF" + Environment.NewLine;
                sqlText += " ,CARM.ENGINEDISPLACENMRF" + Environment.NewLine;
                sqlText += " ,CARM.EDIVNMRF" + Environment.NewLine;
                sqlText += " ,CARM.TRANSMISSIONNMRF" + Environment.NewLine;
                sqlText += " ,CARM.SHIFTNMRF" + Environment.NewLine;
                sqlText += " ,CARM.WHEELDRIVEMETHODNMRF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPEC1RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPEC2RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPEC3RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPEC4RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPEC5RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPEC6RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPECTITLE1RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPECTITLE2RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPECTITLE3RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPECTITLE4RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPECTITLE5RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPECTITLE6RF" + Environment.NewLine;
                sqlText += " ,CARM.RELEVANCEMODELRF" + Environment.NewLine;
                sqlText += " ,CARM.SUBCARNMCDRF" + Environment.NewLine;
                sqlText += " ,CARM.MODELGRADESNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.BLOCKILLUSTRATIONCDRF" + Environment.NewLine;
                sqlText += " ,CARM.THREEDILLUSTNORF" + Environment.NewLine;
                sqlText += " ,CARM.PARTSDATAOFFERFLAGRF" + Environment.NewLine;
                sqlText += " ,CARM.INSPECTMATURITYDATERF" + Environment.NewLine;
                sqlText += " ,CARM.LTIMECIMATDATERF" + Environment.NewLine;
                sqlText += " ,CARM.CARINSPECTYEARRF" + Environment.NewLine;
                sqlText += " ,CARM.MILEAGERF" + Environment.NewLine;
                sqlText += " ,CARM.CARNORF" + Environment.NewLine;
                sqlText += " ,CARM.COLORCODERF" + Environment.NewLine;
                sqlText += " ,CARM.COLORNAME1RF" + Environment.NewLine;
                sqlText += " ,CARM.TRIMCODERF" + Environment.NewLine;
                sqlText += " ,CARM.TRIMNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.FULLMODELFIXEDNOARYRF" + Environment.NewLine;
                sqlText += " ,CARM.CATEGORYOBJARYRF" + Environment.NewLine;
                sqlText += " ,CARM.CARADDINFO1RF" + Environment.NewLine;
                sqlText += " ,CARM.CARADDINFO2RF" + Environment.NewLine;
                sqlText += " ,CARM.CARNOTERF" + Environment.NewLine;
                // --- ADD 2010/04/27 -------------->>>>>
                sqlText += " ,CARM.FREESRCHMDLFXDNOARYRF" + Environment.NewLine;
                // --- ADD 2010/04/27 --------------<<<<<
                sqlText += " ,CUST.NAMERF" + Environment.NewLine;
                sqlText += " ,CUST.NAME2RF" + Environment.NewLine;
                // ADD 2013/03/22  -------------------->>>>>
                sqlText += " ,CARM.DOMESTICFOREIGNCODERF" + Environment.NewLine;
                sqlText += " ,CARM.HANDLEINFOCDRF" + Environment.NewLine;
                // ADD 2013/03/22  --------------------<<<<<
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  CARMANAGEMENTRF AS CARM" + Environment.NewLine;
                sqlText += " ,CUSTOMERRF AS CUST" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereStringForGuide(ref sqlCommand, carMngGuideWork);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                string customerName = string.Empty;

                while (myReader.Read())
                {
                    CarManagementWork carManagementWork = this.CopyToCarManagementWorkFromReader(ref myReader);
                    // 得意先名称
                    customerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF")) + " " + 
                                          SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAME2RF"));
                    carManagementWork.CustomerName = customerName;

                    carManagementList.Add(carManagementWork);
                }

                if (carManagementList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        // --- ADD 2009/09/11 --------------<<<
        # endregion

        # region [Write]
        /// <summary>
        /// 車両管理マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="carManagementList">追加・更新する車両管理マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : carManagementList に格納されている車両管理マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.06.02</br>
        public int Write(ref object carManagementList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = carManagementList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // 書込準備処理 (車両管理番号の採番)
                status = this.WriteInitial(ref paraList, sqlConnection, sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 書込処理
                    status = this.Write(ref paraList, sqlConnection, sqlTransaction);
                }
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ロールバック
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
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
        /// 車両管理マスタ情報を追加・更新を行う為の準備処理を行います。
        /// </summary>
        /// <param name="carManagementList">追加・更新する車両管理マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        public int WriteInitial(ref ArrayList carManagementList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                if (carManagementList != null && carManagementList.Count > 0)
                {
                    NumberingManager numberingManager = new NumberingManager();
                    long no = -1;
                    
                    foreach (CarManagementWork carManagementWork in carManagementList)
                    {
                        // --- ADD 2009/09/11 -------------->>>
                        if (carManagementWork.CarMngNo != 0)
                        {
                            // 車輌管理マスタ情報の車輌管理番号≠0の場合、車輌管理番号の採番処理を行わない
                            continue;
                        }
                        // --- ADD 2009/09/11 --------------<<<

                        no = -1;
                        // 車両管理番号を採番する。　※拠点管理を行わないので拠点コードには"000000"を固定で設定する
                        status = numberingManager.GetSerialNumber(carManagementWork.EnterpriseCode, "000000", SerialNumberCode.CarMngNo, out no);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && no != -1)
                        {
                            carManagementWork.CarMngNo = (int)no;
                        }
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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
        /// 車両管理マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="carManagementList">追加・更新する車両管理マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : carManagementList に格納されている車両管理マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.06.02</br>
        public int Write(ref ArrayList carManagementList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref carManagementList, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// 車両管理マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="carManagementList">追加・更新する車両管理マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : carManagementList に格納されている車両管理マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.06.02</br>
        /// <br>Update Note: 2013/03/22 FSI高橋 文彰</br>
        /// <br>管理番号   : 10900269-00</br>
        /// <br>             SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
        private int WriteProc(ref ArrayList carManagementList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (carManagementList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < carManagementList.Count; i++)
                    {
                        CarManagementWork carManagementWork = carManagementList[i] as CarManagementWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  CARM.CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,CARM.UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,CARM.FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  CARMANAGEMENTRF AS CARM" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  CARM.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND CARM.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlText += "  AND CARM.CARMNGNORF = @FINDCARMNGNO" + Environment.NewLine;
                        sqlText += "  AND CARM.CARMNGCODERF = @FINDCARMNGCODE" + Environment.NewLine; // 2009/12/24
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findCarMngNo = sqlCommand.Parameters.Add("@FINDCARMNGNO", SqlDbType.Int);
                        SqlParameter findCarMngCode = sqlCommand.Parameters.Add("@FINDCARMNGCODE", SqlDbType.NChar); // 2009/12/24

                        // Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(carManagementWork.EnterpriseCode);
                        findCustomerCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CustomerCode);
                        findCarMngNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CarMngNo);
                        findCarMngCode.Value = SqlDataMediator.SqlSetString(carManagementWork.CarMngCode.Trim()); // 2009/12/24

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            if (!this._CompulsoryDataOverride)
                            {
                                // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                                if (_updateDateTime != carManagementWork.UpdateDateTime)
                                {
                                    if (carManagementWork.UpdateDateTime == DateTime.MinValue)
                                    {
                                        // 新規登録で該当データ有りの場合には重複
                                        status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                    }
                                    else
                                    {
                                        // 既存データで更新日時違いの場合には排他
                                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                    }

                                    return status;
                                }
                            }
                            else
                            {
                                // 強制的にデータを上書きをする為、作成日時やファイルヘッダーGUIDを上書きしておく
                                // ※fileHeader.SetUpdateHeader ではこれらの項目がセットされない為
                                carManagementWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // 作成日時
                                carManagementWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));                 // GUID
                            }

                            # region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText += "UPDATE CARMANAGEMENTRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERCODERF = @CUSTOMERCODE" + Environment.NewLine;
                            sqlText += " ,CARMNGNORF = @CARMNGNO" + Environment.NewLine;
                            sqlText += " ,CARMNGCODERF = @CARMNGCODE" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE1CODERF = @NUMBERPLATE1CODE" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE1NAMERF = @NUMBERPLATE1NAME" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE2RF = @NUMBERPLATE2" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE3RF = @NUMBERPLATE3" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE4RF = @NUMBERPLATE4" + Environment.NewLine;
                            sqlText += " ,ENTRYDATERF = @ENTRYDATE" + Environment.NewLine;
                            sqlText += " ,FIRSTENTRYDATERF = @FIRSTENTRYDATE" + Environment.NewLine;
                            sqlText += " ,MAKERCODERF = @MAKERCODE" + Environment.NewLine;
                            sqlText += " ,MAKERFULLNAMERF = @MAKERFULLNAME" + Environment.NewLine;
                            sqlText += " ,MAKERHALFNAMERF = @MAKERHALFNAME" + Environment.NewLine;
                            sqlText += " ,MODELCODERF = @MODELCODE" + Environment.NewLine;
                            sqlText += " ,MODELSUBCODERF = @MODELSUBCODE" + Environment.NewLine;
                            sqlText += " ,MODELFULLNAMERF = @MODELFULLNAME" + Environment.NewLine;
                            sqlText += " ,MODELHALFNAMERF = @MODELHALFNAME" + Environment.NewLine;
                            sqlText += " ,SYSTEMATICCODERF = @SYSTEMATICCODE" + Environment.NewLine;
                            sqlText += " ,SYSTEMATICNAMERF = @SYSTEMATICNAME" + Environment.NewLine;
                            sqlText += " ,PRODUCETYPEOFYEARCDRF = @PRODUCETYPEOFYEARCD" + Environment.NewLine;
                            sqlText += " ,PRODUCETYPEOFYEARNMRF = @PRODUCETYPEOFYEARNM" + Environment.NewLine;
                            sqlText += " ,STPRODUCETYPEOFYEARRF = @STPRODUCETYPEOFYEAR" + Environment.NewLine;
                            sqlText += " ,EDPRODUCETYPEOFYEARRF = @EDPRODUCETYPEOFYEAR" + Environment.NewLine;
                            sqlText += " ,DOORCOUNTRF = @DOORCOUNT" + Environment.NewLine;
                            sqlText += " ,BODYNAMECODERF = @BODYNAMECODE" + Environment.NewLine;
                            sqlText += " ,BODYNAMERF = @BODYNAME" + Environment.NewLine;
                            sqlText += " ,EXHAUSTGASSIGNRF = @EXHAUSTGASSIGN" + Environment.NewLine;
                            sqlText += " ,SERIESMODELRF = @SERIESMODEL" + Environment.NewLine;
                            sqlText += " ,CATEGORYSIGNMODELRF = @CATEGORYSIGNMODEL" + Environment.NewLine;
                            sqlText += " ,FULLMODELRF = @FULLMODEL" + Environment.NewLine;
                            sqlText += " ,MODELDESIGNATIONNORF = @MODELDESIGNATIONNO" + Environment.NewLine;
                            sqlText += " ,CATEGORYNORF = @CATEGORYNO" + Environment.NewLine;
                            sqlText += " ,FRAMEMODELRF = @FRAMEMODEL" + Environment.NewLine;
                            sqlText += " ,FRAMENORF = @FRAMENO" + Environment.NewLine;
                            sqlText += " ,SEARCHFRAMENORF = @SEARCHFRAMENO" + Environment.NewLine;
                            sqlText += " ,STPRODUCEFRAMENORF = @STPRODUCEFRAMENO" + Environment.NewLine;
                            sqlText += " ,EDPRODUCEFRAMENORF = @EDPRODUCEFRAMENO" + Environment.NewLine;
                            sqlText += " ,ENGINEMODELRF = @ENGINEMODEL" + Environment.NewLine;
                            sqlText += " ,MODELGRADENMRF = @MODELGRADENM" + Environment.NewLine;
                            sqlText += " ,ENGINEMODELNMRF = @ENGINEMODELNM" + Environment.NewLine;
                            sqlText += " ,ENGINEDISPLACENMRF = @ENGINEDISPLACENM" + Environment.NewLine;
                            sqlText += " ,EDIVNMRF = @EDIVNM" + Environment.NewLine;
                            sqlText += " ,TRANSMISSIONNMRF = @TRANSMISSIONNM" + Environment.NewLine;
                            sqlText += " ,SHIFTNMRF = @SHIFTNM" + Environment.NewLine;
                            sqlText += " ,WHEELDRIVEMETHODNMRF = @WHEELDRIVEMETHODNM" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC1RF = @ADDICARSPEC1" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC2RF = @ADDICARSPEC2" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC3RF = @ADDICARSPEC3" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC4RF = @ADDICARSPEC4" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC5RF = @ADDICARSPEC5" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC6RF = @ADDICARSPEC6" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE1RF = @ADDICARSPECTITLE1" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE2RF = @ADDICARSPECTITLE2" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE3RF = @ADDICARSPECTITLE3" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE4RF = @ADDICARSPECTITLE4" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE5RF = @ADDICARSPECTITLE5" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE6RF = @ADDICARSPECTITLE6" + Environment.NewLine;
                            sqlText += " ,RELEVANCEMODELRF = @RELEVANCEMODEL" + Environment.NewLine;
                            sqlText += " ,SUBCARNMCDRF = @SUBCARNMCD" + Environment.NewLine;
                            sqlText += " ,MODELGRADESNAMERF = @MODELGRADESNAME" + Environment.NewLine;
                            sqlText += " ,BLOCKILLUSTRATIONCDRF = @BLOCKILLUSTRATIONCD" + Environment.NewLine;
                            sqlText += " ,THREEDILLUSTNORF = @THREEDILLUSTNO" + Environment.NewLine;
                            sqlText += " ,PARTSDATAOFFERFLAGRF = @PARTSDATAOFFERFLAG" + Environment.NewLine;
                            sqlText += " ,INSPECTMATURITYDATERF = @INSPECTMATURITYDATE" + Environment.NewLine;
                            sqlText += " ,LTIMECIMATDATERF = @LTIMECIMATDATE" + Environment.NewLine;
                            sqlText += " ,CARINSPECTYEARRF = @CARINSPECTYEAR" + Environment.NewLine;
                            sqlText += " ,MILEAGERF = @MILEAGE" + Environment.NewLine;
                            sqlText += " ,CARNORF = @CARNO" + Environment.NewLine;
                            sqlText += " ,COLORCODERF = @COLORCODE" + Environment.NewLine;
                            sqlText += " ,COLORNAME1RF = @COLORNAME1" + Environment.NewLine;
                            sqlText += " ,TRIMCODERF = @TRIMCODE" + Environment.NewLine;
                            sqlText += " ,TRIMNAMERF = @TRIMNAME" + Environment.NewLine;
                            sqlText += " ,FULLMODELFIXEDNOARYRF = @FULLMODELFIXEDNOARY" + Environment.NewLine;
                            sqlText += " ,CATEGORYOBJARYRF = @CATEGORYOBJARY" + Environment.NewLine;
                            // --- ADD 2009/09/11 -------------->>>
                            sqlText += " ,CARADDINFO1RF = @CARADDINFO1" + Environment.NewLine;
                            sqlText += " ,CARADDINFO2RF = @CARADDINFO2" + Environment.NewLine;
                            sqlText += " ,CARNOTERF = @CARNOTE" + Environment.NewLine;
                            // --- ADD 2009/09/11 --------------<<<
                            // --- ADD 2010/04/27 -------------->>>
                            sqlText += " ,FREESRCHMDLFXDNOARYRF = @FREESRCHMDLFXDNOARY" + Environment.NewLine;
                            // --- ADD 2010/04/27 --------------<<<
                            // ADD 2013/03/22  -------------------->>>>>
                            sqlText += " ,DOMESTICFOREIGNCODERF = @DOMESTICFOREIGNCODERF" + Environment.NewLine;
                            sqlText += " ,HANDLEINFOCDRF = @HANDLEINFOCDRF" + Environment.NewLine;
                            // ADD 2013/03/22  --------------------<<<<<
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                            sqlText += "  AND CARMNGNORF = @FINDCARMNGNO" + Environment.NewLine;
                            sqlText += "  AND CARMNGCODERF = @FINDCARMNGCODE" + Environment.NewLine; // 2009/12/24
                            # endregion

                            // KEYコマンドを再設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(carManagementWork.EnterpriseCode);
                            findCustomerCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CustomerCode);
                            findCarMngNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CarMngNo);
                            findCarMngCode.Value = SqlDataMediator.SqlSetString(carManagementWork.CarMngCode); //2009/12/24

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)carManagementWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (carManagementWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT文]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO CARMANAGEMENTRF (" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERCODERF" + Environment.NewLine;
                            sqlText += " ,CARMNGNORF" + Environment.NewLine;
                            sqlText += " ,CARMNGCODERF" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE1CODERF" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE1NAMERF" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE2RF" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE3RF" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE4RF" + Environment.NewLine;
                            sqlText += " ,ENTRYDATERF" + Environment.NewLine;
                            sqlText += " ,FIRSTENTRYDATERF" + Environment.NewLine;
                            sqlText += " ,MAKERCODERF" + Environment.NewLine;
                            sqlText += " ,MAKERFULLNAMERF" + Environment.NewLine;
                            sqlText += " ,MAKERHALFNAMERF" + Environment.NewLine;
                            sqlText += " ,MODELCODERF" + Environment.NewLine;
                            sqlText += " ,MODELSUBCODERF" + Environment.NewLine;
                            sqlText += " ,MODELFULLNAMERF" + Environment.NewLine;
                            sqlText += " ,MODELHALFNAMERF" + Environment.NewLine;
                            sqlText += " ,SYSTEMATICCODERF" + Environment.NewLine;
                            sqlText += " ,SYSTEMATICNAMERF" + Environment.NewLine;
                            sqlText += " ,PRODUCETYPEOFYEARCDRF" + Environment.NewLine;
                            sqlText += " ,PRODUCETYPEOFYEARNMRF" + Environment.NewLine;
                            sqlText += " ,STPRODUCETYPEOFYEARRF" + Environment.NewLine;
                            sqlText += " ,EDPRODUCETYPEOFYEARRF" + Environment.NewLine;
                            sqlText += " ,DOORCOUNTRF" + Environment.NewLine;
                            sqlText += " ,BODYNAMECODERF" + Environment.NewLine;
                            sqlText += " ,BODYNAMERF" + Environment.NewLine;
                            sqlText += " ,EXHAUSTGASSIGNRF" + Environment.NewLine;
                            sqlText += " ,SERIESMODELRF" + Environment.NewLine;
                            sqlText += " ,CATEGORYSIGNMODELRF" + Environment.NewLine;
                            sqlText += " ,FULLMODELRF" + Environment.NewLine;
                            sqlText += " ,MODELDESIGNATIONNORF" + Environment.NewLine;
                            sqlText += " ,CATEGORYNORF" + Environment.NewLine;
                            sqlText += " ,FRAMEMODELRF" + Environment.NewLine;
                            sqlText += " ,FRAMENORF" + Environment.NewLine;
                            sqlText += " ,SEARCHFRAMENORF" + Environment.NewLine;
                            sqlText += " ,STPRODUCEFRAMENORF" + Environment.NewLine;
                            sqlText += " ,EDPRODUCEFRAMENORF" + Environment.NewLine;
                            sqlText += " ,ENGINEMODELRF" + Environment.NewLine;
                            sqlText += " ,MODELGRADENMRF" + Environment.NewLine;
                            sqlText += " ,ENGINEMODELNMRF" + Environment.NewLine;
                            sqlText += " ,ENGINEDISPLACENMRF" + Environment.NewLine;
                            sqlText += " ,EDIVNMRF" + Environment.NewLine;
                            sqlText += " ,TRANSMISSIONNMRF" + Environment.NewLine;
                            sqlText += " ,SHIFTNMRF" + Environment.NewLine;
                            sqlText += " ,WHEELDRIVEMETHODNMRF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC1RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC2RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC3RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC4RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC5RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC6RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE1RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE2RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE3RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE4RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE5RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE6RF" + Environment.NewLine;
                            sqlText += " ,RELEVANCEMODELRF" + Environment.NewLine;
                            sqlText += " ,SUBCARNMCDRF" + Environment.NewLine;
                            sqlText += " ,MODELGRADESNAMERF" + Environment.NewLine;
                            sqlText += " ,BLOCKILLUSTRATIONCDRF" + Environment.NewLine;
                            sqlText += " ,THREEDILLUSTNORF" + Environment.NewLine;
                            sqlText += " ,PARTSDATAOFFERFLAGRF" + Environment.NewLine;
                            sqlText += " ,INSPECTMATURITYDATERF" + Environment.NewLine;
                            sqlText += " ,LTIMECIMATDATERF" + Environment.NewLine;
                            sqlText += " ,CARINSPECTYEARRF" + Environment.NewLine;
                            sqlText += " ,MILEAGERF" + Environment.NewLine;
                            sqlText += " ,CARNORF" + Environment.NewLine;
                            sqlText += " ,COLORCODERF" + Environment.NewLine;
                            sqlText += " ,COLORNAME1RF" + Environment.NewLine;
                            sqlText += " ,TRIMCODERF" + Environment.NewLine;
                            sqlText += " ,TRIMNAMERF" + Environment.NewLine;
                            sqlText += " ,FULLMODELFIXEDNOARYRF" + Environment.NewLine;
                            // --- ADD 2010/04/27 -------------->>>
                            sqlText += " ,FREESRCHMDLFXDNOARYRF" + Environment.NewLine;
                            // --- ADD 2010/04/27 --------------<<<
                            // --- UPD 2009/09/11 -------------->>>
                            //sqlText += " ,CATEGORYOBJARYRF)" + Environment.NewLine;
                            sqlText += " ,CATEGORYOBJARYRF" + Environment.NewLine;
                            sqlText += " ,CARADDINFO1RF" + Environment.NewLine;
                            sqlText += " ,CARADDINFO2RF" + Environment.NewLine;
                            sqlText += " ,CARNOTERF" + Environment.NewLine;
                            // ADD 2013/03/22  -------------------->>>>>
                            sqlText += " ,DOMESTICFOREIGNCODERF" + Environment.NewLine;
                            sqlText += " ,HANDLEINFOCDRF)" + Environment.NewLine;
                            // ADD 2013/03/22 --------------------<<<<<
                            // --- UPD 2009/09/11 --------------<<<
                            sqlText += "VALUES" + Environment.NewLine;
                            sqlText += "  (@CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERCODE" + Environment.NewLine;
                            sqlText += " ,@CARMNGNO" + Environment.NewLine;
                            sqlText += " ,@CARMNGCODE" + Environment.NewLine;
                            sqlText += " ,@NUMBERPLATE1CODE" + Environment.NewLine;
                            sqlText += " ,@NUMBERPLATE1NAME" + Environment.NewLine;
                            sqlText += " ,@NUMBERPLATE2" + Environment.NewLine;
                            sqlText += " ,@NUMBERPLATE3" + Environment.NewLine;
                            sqlText += " ,@NUMBERPLATE4" + Environment.NewLine;
                            sqlText += " ,@ENTRYDATE" + Environment.NewLine;
                            sqlText += " ,@FIRSTENTRYDATE" + Environment.NewLine;
                            sqlText += " ,@MAKERCODE" + Environment.NewLine;
                            sqlText += " ,@MAKERFULLNAME" + Environment.NewLine;
                            sqlText += " ,@MAKERHALFNAME" + Environment.NewLine;
                            sqlText += " ,@MODELCODE" + Environment.NewLine;
                            sqlText += " ,@MODELSUBCODE" + Environment.NewLine;
                            sqlText += " ,@MODELFULLNAME" + Environment.NewLine;
                            sqlText += " ,@MODELHALFNAME" + Environment.NewLine;
                            sqlText += " ,@SYSTEMATICCODE" + Environment.NewLine;
                            sqlText += " ,@SYSTEMATICNAME" + Environment.NewLine;
                            sqlText += " ,@PRODUCETYPEOFYEARCD" + Environment.NewLine;
                            sqlText += " ,@PRODUCETYPEOFYEARNM" + Environment.NewLine;
                            sqlText += " ,@STPRODUCETYPEOFYEAR" + Environment.NewLine;
                            sqlText += " ,@EDPRODUCETYPEOFYEAR" + Environment.NewLine;
                            sqlText += " ,@DOORCOUNT" + Environment.NewLine;
                            sqlText += " ,@BODYNAMECODE" + Environment.NewLine;
                            sqlText += " ,@BODYNAME" + Environment.NewLine;
                            sqlText += " ,@EXHAUSTGASSIGN" + Environment.NewLine;
                            sqlText += " ,@SERIESMODEL" + Environment.NewLine;
                            sqlText += " ,@CATEGORYSIGNMODEL" + Environment.NewLine;
                            sqlText += " ,@FULLMODEL" + Environment.NewLine;
                            sqlText += " ,@MODELDESIGNATIONNO" + Environment.NewLine;
                            sqlText += " ,@CATEGORYNO" + Environment.NewLine;
                            sqlText += " ,@FRAMEMODEL" + Environment.NewLine;
                            sqlText += " ,@FRAMENO" + Environment.NewLine;
                            sqlText += " ,@SEARCHFRAMENO" + Environment.NewLine;
                            sqlText += " ,@STPRODUCEFRAMENO" + Environment.NewLine;
                            sqlText += " ,@EDPRODUCEFRAMENO" + Environment.NewLine;
                            sqlText += " ,@ENGINEMODEL" + Environment.NewLine;
                            sqlText += " ,@MODELGRADENM" + Environment.NewLine;
                            sqlText += " ,@ENGINEMODELNM" + Environment.NewLine;
                            sqlText += " ,@ENGINEDISPLACENM" + Environment.NewLine;
                            sqlText += " ,@EDIVNM" + Environment.NewLine;
                            sqlText += " ,@TRANSMISSIONNM" + Environment.NewLine;
                            sqlText += " ,@SHIFTNM" + Environment.NewLine;
                            sqlText += " ,@WHEELDRIVEMETHODNM" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPEC1" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPEC2" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPEC3" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPEC4" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPEC5" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPEC6" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPECTITLE1" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPECTITLE2" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPECTITLE3" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPECTITLE4" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPECTITLE5" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPECTITLE6" + Environment.NewLine;
                            sqlText += " ,@RELEVANCEMODEL" + Environment.NewLine;
                            sqlText += " ,@SUBCARNMCD" + Environment.NewLine;
                            sqlText += " ,@MODELGRADESNAME" + Environment.NewLine;
                            sqlText += " ,@BLOCKILLUSTRATIONCD" + Environment.NewLine;
                            sqlText += " ,@THREEDILLUSTNO" + Environment.NewLine;
                            sqlText += " ,@PARTSDATAOFFERFLAG" + Environment.NewLine;
                            sqlText += " ,@INSPECTMATURITYDATE" + Environment.NewLine;
                            sqlText += " ,@LTIMECIMATDATE" + Environment.NewLine;
                            sqlText += " ,@CARINSPECTYEAR" + Environment.NewLine;
                            sqlText += " ,@MILEAGE" + Environment.NewLine;
                            sqlText += " ,@CARNO" + Environment.NewLine;
                            sqlText += " ,@COLORCODE" + Environment.NewLine;
                            sqlText += " ,@COLORNAME1" + Environment.NewLine;
                            sqlText += " ,@TRIMCODE" + Environment.NewLine;
                            sqlText += " ,@TRIMNAME" + Environment.NewLine;
                            sqlText += " ,@FULLMODELFIXEDNOARY" + Environment.NewLine;
                            // --- ADD 2010/04/27 -------------->>>
                            sqlText += " ,@FREESRCHMDLFXDNOARY" + Environment.NewLine;
                            // --- ADD 2010/04/27 --------------<<<
                            // --- UPD 2009/09/11 -------------->>>
                            // sqlText += " ,@CATEGORYOBJARY" + Environment.NewLine;
                            sqlText += " ,@CATEGORYOBJARY" + Environment.NewLine;
                            sqlText += " ,@CARADDINFO1" + Environment.NewLine;
                            sqlText += " ,@CARADDINFO2" + Environment.NewLine;
                            sqlText += " ,@CARNOTE" + Environment.NewLine;
                            // --- UPD 2009/09/11 --------------<<<
                            // ADD 2013/03/22  -------------------->>>>>
                            sqlText += " ,@DOMESTICFOREIGNCODERF" + Environment.NewLine;
                            sqlText += " ,@HANDLEINFOCDRF)" + Environment.NewLine;
                            // ADD 2013/03/22  --------------------<<<<<
                            # endregion

                            // 登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)carManagementWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        sqlCommand.CommandText = sqlText;

                        # region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);               // 作成日時
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);               // 更新日時
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);                // 企業コード
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);     // GUID
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);              // 更新従業員コード
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);             // 更新アセンブリID1
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);             // 更新アセンブリID2
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);            // 論理削除区分
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);                      // 得意先コード
                        SqlParameter paraCarMngNo = sqlCommand.Parameters.Add("@CARMNGNO", SqlDbType.Int);                              // 車両管理番号
                        SqlParameter paraCarMngCode = sqlCommand.Parameters.Add("@CARMNGCODE", SqlDbType.NVarChar);                     // 車輌管理コード
                        SqlParameter paraNumberPlate1Code = sqlCommand.Parameters.Add("@NUMBERPLATE1CODE", SqlDbType.Int);              // 陸運事務所番号
                        SqlParameter paraNumberPlate1Name = sqlCommand.Parameters.Add("@NUMBERPLATE1NAME", SqlDbType.NVarChar);         // 陸運事務局名称
                        SqlParameter paraNumberPlate2 = sqlCommand.Parameters.Add("@NUMBERPLATE2", SqlDbType.NVarChar);                 // 車両登録番号（種別）
                        SqlParameter paraNumberPlate3 = sqlCommand.Parameters.Add("@NUMBERPLATE3", SqlDbType.NVarChar);                 // 車両登録番号（カナ）
                        SqlParameter paraNumberPlate4 = sqlCommand.Parameters.Add("@NUMBERPLATE4", SqlDbType.Int);                      // 車両登録番号（プレート番号）
                        SqlParameter paraEntryDate = sqlCommand.Parameters.Add("@ENTRYDATE", SqlDbType.Int);                            // 登録年月日
                        SqlParameter paraFirstEntryDate = sqlCommand.Parameters.Add("@FIRSTENTRYDATE", SqlDbType.Int);                  // 初年度
                        SqlParameter paraMakerCode = sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int);                            // メーカーコード
                        SqlParameter paraMakerFullName = sqlCommand.Parameters.Add("@MAKERFULLNAME", SqlDbType.NVarChar);               // メーカー全角名称
                        SqlParameter paraMakerHalfName = sqlCommand.Parameters.Add("@MAKERHALFNAME", SqlDbType.NVarChar);               // メーカー半角名称
                        SqlParameter paraModelCode = sqlCommand.Parameters.Add("@MODELCODE", SqlDbType.Int);                            // 車種コード
                        SqlParameter paraModelSubCode = sqlCommand.Parameters.Add("@MODELSUBCODE", SqlDbType.Int);                      // 車種サブコード
                        SqlParameter paraModelFullName = sqlCommand.Parameters.Add("@MODELFULLNAME", SqlDbType.NVarChar);               // 車種全角名称
                        SqlParameter paraModelHalfName = sqlCommand.Parameters.Add("@MODELHALFNAME", SqlDbType.NVarChar);               // 車種半角名称
                        SqlParameter paraSystematicCode = sqlCommand.Parameters.Add("@SYSTEMATICCODE", SqlDbType.Int);                  // 系統コード
                        SqlParameter paraSystematicName = sqlCommand.Parameters.Add("@SYSTEMATICNAME", SqlDbType.NVarChar);             // 系統名称
                        SqlParameter paraProduceTypeOfYearCd = sqlCommand.Parameters.Add("@PRODUCETYPEOFYEARCD", SqlDbType.Int);        // 生産年式コード
                        SqlParameter paraProduceTypeOfYearNm = sqlCommand.Parameters.Add("@PRODUCETYPEOFYEARNM", SqlDbType.NVarChar);   // 生産年式名称
                        SqlParameter paraStProduceTypeOfYear = sqlCommand.Parameters.Add("@STPRODUCETYPEOFYEAR", SqlDbType.Int);        // 開始生産年式
                        SqlParameter paraEdProduceTypeOfYear = sqlCommand.Parameters.Add("@EDPRODUCETYPEOFYEAR", SqlDbType.Int);        // 終了生産年式
                        SqlParameter paraDoorCount = sqlCommand.Parameters.Add("@DOORCOUNT", SqlDbType.Int);                            // ドア数
                        SqlParameter paraBodyNameCode = sqlCommand.Parameters.Add("@BODYNAMECODE", SqlDbType.Int);                      // ボディー名コード
                        SqlParameter paraBodyName = sqlCommand.Parameters.Add("@BODYNAME", SqlDbType.NVarChar);                         // ボディー名称
                        SqlParameter paraExhaustGasSign = sqlCommand.Parameters.Add("@EXHAUSTGASSIGN", SqlDbType.NVarChar);             // 排ガス記号
                        SqlParameter paraSeriesModel = sqlCommand.Parameters.Add("@SERIESMODEL", SqlDbType.NVarChar);                   // シリーズ型式
                        SqlParameter paraCategorySignModel = sqlCommand.Parameters.Add("@CATEGORYSIGNMODEL", SqlDbType.NVarChar);       // 型式（類別記号）
                        SqlParameter paraFullModel = sqlCommand.Parameters.Add("@FULLMODEL", SqlDbType.NVarChar);                       // 型式（フル型）
                        SqlParameter paraModelDesignationNo = sqlCommand.Parameters.Add("@MODELDESIGNATIONNO", SqlDbType.Int);          // 型式指定番号
                        SqlParameter paraCategoryNo = sqlCommand.Parameters.Add("@CATEGORYNO", SqlDbType.Int);                          // 類別番号
                        SqlParameter paraFrameModel = sqlCommand.Parameters.Add("@FRAMEMODEL", SqlDbType.NVarChar);                     // 車台型式
                        SqlParameter paraFrameNo = sqlCommand.Parameters.Add("@FRAMENO", SqlDbType.NVarChar);                           // 車台番号
                        SqlParameter paraSearchFrameNo = sqlCommand.Parameters.Add("@SEARCHFRAMENO", SqlDbType.Int);                    // 車台番号（検索用）
                        SqlParameter paraStProduceFrameNo = sqlCommand.Parameters.Add("@STPRODUCEFRAMENO", SqlDbType.Int);              // 生産車台番号開始
                        SqlParameter paraEdProduceFrameNo = sqlCommand.Parameters.Add("@EDPRODUCEFRAMENO", SqlDbType.Int);              // 生産車台番号終了
                        SqlParameter paraEngineModel = sqlCommand.Parameters.Add("@ENGINEMODEL", SqlDbType.NVarChar);                   // 原動機型式（エンジン）
                        SqlParameter paraModelGradeNm = sqlCommand.Parameters.Add("@MODELGRADENM", SqlDbType.NVarChar);                 // 型式グレード名称
                        SqlParameter paraEngineModelNm = sqlCommand.Parameters.Add("@ENGINEMODELNM", SqlDbType.NVarChar);               // エンジン型式名称
                        SqlParameter paraEngineDisplaceNm = sqlCommand.Parameters.Add("@ENGINEDISPLACENM", SqlDbType.NVarChar);         // 排気量名称
                        SqlParameter paraEDivNm = sqlCommand.Parameters.Add("@EDIVNM", SqlDbType.NVarChar);                             // E区分名称
                        SqlParameter paraTransmissionNm = sqlCommand.Parameters.Add("@TRANSMISSIONNM", SqlDbType.NVarChar);             // ミッション名称
                        SqlParameter paraShiftNm = sqlCommand.Parameters.Add("@SHIFTNM", SqlDbType.NVarChar);                           // シフト名称
                        SqlParameter paraWheelDriveMethodNm = sqlCommand.Parameters.Add("@WHEELDRIVEMETHODNM", SqlDbType.NVarChar);     // 駆動方式名称
                        SqlParameter paraAddiCarSpec1 = sqlCommand.Parameters.Add("@ADDICARSPEC1", SqlDbType.NVarChar);                 // 追加諸元1
                        SqlParameter paraAddiCarSpec2 = sqlCommand.Parameters.Add("@ADDICARSPEC2", SqlDbType.NVarChar);                 // 追加諸元2
                        SqlParameter paraAddiCarSpec3 = sqlCommand.Parameters.Add("@ADDICARSPEC3", SqlDbType.NVarChar);                 // 追加諸元3
                        SqlParameter paraAddiCarSpec4 = sqlCommand.Parameters.Add("@ADDICARSPEC4", SqlDbType.NVarChar);                 // 追加諸元4
                        SqlParameter paraAddiCarSpec5 = sqlCommand.Parameters.Add("@ADDICARSPEC5", SqlDbType.NVarChar);                 // 追加諸元5
                        SqlParameter paraAddiCarSpec6 = sqlCommand.Parameters.Add("@ADDICARSPEC6", SqlDbType.NVarChar);                 // 追加諸元6
                        SqlParameter paraAddiCarSpecTitle1 = sqlCommand.Parameters.Add("@ADDICARSPECTITLE1", SqlDbType.NVarChar);       // 追加諸元タイトル1
                        SqlParameter paraAddiCarSpecTitle2 = sqlCommand.Parameters.Add("@ADDICARSPECTITLE2", SqlDbType.NVarChar);       // 追加諸元タイトル2
                        SqlParameter paraAddiCarSpecTitle3 = sqlCommand.Parameters.Add("@ADDICARSPECTITLE3", SqlDbType.NVarChar);       // 追加諸元タイトル3
                        SqlParameter paraAddiCarSpecTitle4 = sqlCommand.Parameters.Add("@ADDICARSPECTITLE4", SqlDbType.NVarChar);       // 追加諸元タイトル4
                        SqlParameter paraAddiCarSpecTitle5 = sqlCommand.Parameters.Add("@ADDICARSPECTITLE5", SqlDbType.NVarChar);       // 追加諸元タイトル5
                        SqlParameter paraAddiCarSpecTitle6 = sqlCommand.Parameters.Add("@ADDICARSPECTITLE6", SqlDbType.NVarChar);       // 追加諸元タイトル6
                        SqlParameter paraRelevanceModel = sqlCommand.Parameters.Add("@RELEVANCEMODEL", SqlDbType.NVarChar);             // 関連型式
                        SqlParameter paraSubCarNmCd = sqlCommand.Parameters.Add("@SUBCARNMCD", SqlDbType.Int);                          // サブ車名コード
                        SqlParameter paraModelGradeSname = sqlCommand.Parameters.Add("@MODELGRADESNAME", SqlDbType.NVarChar);           // 型式グレード略称
                        SqlParameter paraBlockIllustrationCd = sqlCommand.Parameters.Add("@BLOCKILLUSTRATIONCD", SqlDbType.Int);        // ブロックイラストコード
                        SqlParameter paraThreeDIllustNo = sqlCommand.Parameters.Add("@THREEDILLUSTNO", SqlDbType.Int);                  // 3DイラストNo
                        SqlParameter paraPartsDataOfferFlag = sqlCommand.Parameters.Add("@PARTSDATAOFFERFLAG", SqlDbType.Int);          // 部品データ提供フラグ
                        SqlParameter paraInspectMaturityDate = sqlCommand.Parameters.Add("@INSPECTMATURITYDATE", SqlDbType.Int);        // 車検満期日
                        SqlParameter paraLTimeCiMatDate = sqlCommand.Parameters.Add("@LTIMECIMATDATE", SqlDbType.Int);                  // 前回車検満期日
                        SqlParameter paraCarInspectYear = sqlCommand.Parameters.Add("@CARINSPECTYEAR", SqlDbType.Int);                  // 車検期間
                        SqlParameter paraMileage = sqlCommand.Parameters.Add("@MILEAGE", SqlDbType.Int);                                // 車両走行距離
                        SqlParameter paraCarNo = sqlCommand.Parameters.Add("@CARNO", SqlDbType.NVarChar);                               // 号車
                        SqlParameter paraColorCode = sqlCommand.Parameters.Add("@COLORCODE", SqlDbType.NVarChar);                       // カラーコード
                        SqlParameter paraColorName1 = sqlCommand.Parameters.Add("@COLORNAME1", SqlDbType.NVarChar);                     // カラー名称1
                        SqlParameter paraTrimCode = sqlCommand.Parameters.Add("@TRIMCODE", SqlDbType.NVarChar);                         // トリムコード
                        SqlParameter paraTrimName = sqlCommand.Parameters.Add("@TRIMNAME", SqlDbType.NVarChar);                         // トリム名称
                        SqlParameter paraFullModelFixedNoAry = sqlCommand.Parameters.Add("@FULLMODELFIXEDNOARY", SqlDbType.VarBinary);  // フル型式固定番号配列
                        SqlParameter paraCategoryObjAry = sqlCommand.Parameters.Add("@CATEGORYOBJARY", SqlDbType.VarBinary);            // 装備オブジェクト配列
                        // --- ADD 2010/04/27 -------------->>>
                        SqlParameter paraFreeSrchMdlFxdNoAry = sqlCommand.Parameters.Add("@FREESRCHMDLFXDNOARY", SqlDbType.VarBinary);  // 自由検索型式固定番号配列
                        // --- ADD 2010/04/27 --------------<<<
                        // --- ADD 2009/09/11 -------------->>>
                        SqlParameter paraCarAddInfo1 = sqlCommand.Parameters.Add("@CARADDINFO1", SqlDbType.NVarChar);                   // 車輌追加情報１
                        SqlParameter paraCarAddInfo2 = sqlCommand.Parameters.Add("@CARADDINFO2", SqlDbType.NVarChar);                   // 車輌追加情報２
                        SqlParameter paraCarNote = sqlCommand.Parameters.Add("@CARNOTE", SqlDbType.NVarChar);                           // 車輌備考
                        // --- ADD 2009/09/11 --------------<<<
                        // ADD 2013/03/22  -------------------->>>>>
                        SqlParameter paraDomesticForeignCode = sqlCommand.Parameters.Add("@DOMESTICFOREIGNCODERF", SqlDbType.Int);      // 国産/外車区分
                        SqlParameter paraHandleInfoCode = sqlCommand.Parameters.Add("@HANDLEINFOCDRF", SqlDbType.Int);                  // ハンドル位置情報
                        // ADD 2013/03/22  --------------------<<<<<             
                        # endregion

                        # region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(carManagementWork.CreateDateTime);               // 作成日時
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(carManagementWork.UpdateDateTime);               // 更新日時
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(carManagementWork.EnterpriseCode);                          // 企業コード
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(carManagementWork.FileHeaderGuid);                            // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(carManagementWork.UpdEmployeeCode);                        // 更新従業員コード
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(carManagementWork.UpdAssemblyId1);                          // 更新アセンブリID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(carManagementWork.UpdAssemblyId2);                          // 更新アセンブリID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.LogicalDeleteCode);                     // 論理削除区分
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CustomerCode);                               // 得意先コード
                        paraCarMngNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CarMngNo);                                       // 車両管理番号
                        paraCarMngCode.Value = SqlDataMediator.SqlSetString(carManagementWork.CarMngCode);                                  // 車輌管理コード
                        paraNumberPlate1Code.Value = SqlDataMediator.SqlSetInt32(carManagementWork.NumberPlate1Code);                       // 陸運事務所番号
                        paraNumberPlate1Name.Value = SqlDataMediator.SqlSetString(carManagementWork.NumberPlate1Name);                      // 陸運事務局名称
                        paraNumberPlate2.Value = SqlDataMediator.SqlSetString(carManagementWork.NumberPlate2);                              // 車両登録番号（種別）
                        paraNumberPlate3.Value = SqlDataMediator.SqlSetString(carManagementWork.NumberPlate3);                              // 車両登録番号（カナ）
                        paraNumberPlate4.Value = SqlDataMediator.SqlSetInt32(carManagementWork.NumberPlate4);                               // 車両登録番号（プレート番号）
                        paraEntryDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(carManagementWork.EntryDate);                      // 登録年月日
                        //paraFirstEntryDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(carManagementWork.FirstEntryDate);              // 初年度
                        paraFirstEntryDate.Value = SqlDataMediator.SqlSetInt32(carManagementWork.FirstEntryDate);                           // 初年度
                        paraMakerCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.MakerCode);                                     // メーカーコード
                        paraMakerFullName.Value = SqlDataMediator.SqlSetString(carManagementWork.MakerFullName);                            // メーカー全角名称
                        paraMakerHalfName.Value = SqlDataMediator.SqlSetString(carManagementWork.MakerHalfName);                            // メーカー半角名称                        
                        paraModelCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.ModelCode);                                     // 車種コード
                        paraModelSubCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.ModelSubCode);                               // 車種サブコード
                        paraModelFullName.Value = SqlDataMediator.SqlSetString(carManagementWork.ModelFullName);                            // 車種全角名称
                        paraModelHalfName.Value = SqlDataMediator.SqlSetString(carManagementWork.ModelHalfName);                            // 車種半角名称
                        paraSystematicCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.SystematicCode);                           // 系統コード
                        paraSystematicName.Value = SqlDataMediator.SqlSetString(carManagementWork.SystematicName);                          // 系統名称
                        paraProduceTypeOfYearCd.Value = SqlDataMediator.SqlSetInt32(carManagementWork.ProduceTypeOfYearCd);                 // 生産年式コード
                        paraProduceTypeOfYearNm.Value = SqlDataMediator.SqlSetString(carManagementWork.ProduceTypeOfYearNm);                // 生産年式名称
                        paraStProduceTypeOfYear.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(carManagementWork.StProduceTypeOfYear);    // 開始生産年式
                        paraEdProduceTypeOfYear.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(carManagementWork.EdProduceTypeOfYear);    // 終了生産年式
                        paraDoorCount.Value = SqlDataMediator.SqlSetInt32(carManagementWork.DoorCount);                                     // ドア数
                        paraBodyNameCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.BodyNameCode);                               // ボディー名コード
                        paraBodyName.Value = SqlDataMediator.SqlSetString(carManagementWork.BodyName);                                      // ボディー名称
                        paraExhaustGasSign.Value = SqlDataMediator.SqlSetString(carManagementWork.ExhaustGasSign);                          // 排ガス記号
                        paraSeriesModel.Value = SqlDataMediator.SqlSetString(carManagementWork.SeriesModel);                                // シリーズ型式
                        paraCategorySignModel.Value = SqlDataMediator.SqlSetString(carManagementWork.CategorySignModel);                    // 型式（類別記号）
                        paraFullModel.Value = SqlDataMediator.SqlSetString(carManagementWork.FullModel);                                    // 型式（フル型）
                        paraModelDesignationNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.ModelDesignationNo);                   // 型式指定番号
                        paraCategoryNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CategoryNo);                                   // 類別番号
                        paraFrameModel.Value = SqlDataMediator.SqlSetString(carManagementWork.FrameModel);                                  // 車台型式
                        paraFrameNo.Value = SqlDataMediator.SqlSetString(carManagementWork.FrameNo);                                        // 車台番号
                        paraSearchFrameNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.SearchFrameNo);                             // 車台番号（検索用）
                        paraStProduceFrameNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.StProduceFrameNo);                       // 生産車台番号開始
                        paraEdProduceFrameNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.EdProduceFrameNo);                       // 生産車台番号終了
                        paraEngineModel.Value = SqlDataMediator.SqlSetString(carManagementWork.EngineModel);                                // 原動機型式（エンジン）
                        paraModelGradeNm.Value = SqlDataMediator.SqlSetString(carManagementWork.ModelGradeNm);                              // 型式グレード名称
                        paraEngineModelNm.Value = SqlDataMediator.SqlSetString(carManagementWork.EngineModelNm);                            // エンジン型式名称
                        paraEngineDisplaceNm.Value = SqlDataMediator.SqlSetString(carManagementWork.EngineDisplaceNm);                      // 排気量名称
                        paraEDivNm.Value = SqlDataMediator.SqlSetString(carManagementWork.EDivNm);                                          // E区分名称
                        paraTransmissionNm.Value = SqlDataMediator.SqlSetString(carManagementWork.TransmissionNm);                          // ミッション名称
                        paraShiftNm.Value = SqlDataMediator.SqlSetString(carManagementWork.ShiftNm);                                        // シフト名称
                        paraWheelDriveMethodNm.Value = SqlDataMediator.SqlSetString(carManagementWork.WheelDriveMethodNm);                  // 駆動方式名称
                        paraAddiCarSpec1.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpec1);                              // 追加諸元1
                        paraAddiCarSpec2.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpec2);                              // 追加諸元2
                        paraAddiCarSpec3.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpec3);                              // 追加諸元3
                        paraAddiCarSpec4.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpec4);                              // 追加諸元4
                        paraAddiCarSpec5.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpec5);                              // 追加諸元5
                        paraAddiCarSpec6.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpec6);                              // 追加諸元6
                        paraAddiCarSpecTitle1.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpecTitle1);                    // 追加諸元タイトル1
                        paraAddiCarSpecTitle2.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpecTitle2);                    // 追加諸元タイトル2
                        paraAddiCarSpecTitle3.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpecTitle3);                    // 追加諸元タイトル3
                        paraAddiCarSpecTitle4.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpecTitle4);                    // 追加諸元タイトル4
                        paraAddiCarSpecTitle5.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpecTitle5);                    // 追加諸元タイトル5
                        paraAddiCarSpecTitle6.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpecTitle6);                    // 追加諸元タイトル6
                        paraRelevanceModel.Value = SqlDataMediator.SqlSetString(carManagementWork.RelevanceModel);                          // 関連型式
                        paraSubCarNmCd.Value = SqlDataMediator.SqlSetInt32(carManagementWork.SubCarNmCd);                                   // サブ車名コード
                        paraModelGradeSname.Value = SqlDataMediator.SqlSetString(carManagementWork.ModelGradeSname);                        // 型式グレード略称
                        paraBlockIllustrationCd.Value = SqlDataMediator.SqlSetInt32(carManagementWork.BlockIllustrationCd);                 // ブロックイラストコード
                        paraThreeDIllustNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.ThreeDIllustNo);                           // 3DイラストNo
                        paraPartsDataOfferFlag.Value = SqlDataMediator.SqlSetInt32(carManagementWork.PartsDataOfferFlag);                   // 部品データ提供フラグ
                        paraInspectMaturityDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(carManagementWork.InspectMaturityDate);  // 車検満期日
                        paraLTimeCiMatDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(carManagementWork.LTimeCiMatDate);            // 前回車検満期日
                        paraCarInspectYear.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CarInspectYear);                           // 車検期間
                        paraMileage.Value = SqlDataMediator.SqlSetInt32(carManagementWork.Mileage);                                         // 車両走行距離
                        paraCarNo.Value = SqlDataMediator.SqlSetString(carManagementWork.CarNo);                                            // 号車
                        paraColorCode.Value = SqlDataMediator.SqlSetString(carManagementWork.ColorCode);                                    // カラーコード
                        paraColorName1.Value = SqlDataMediator.SqlSetString(carManagementWork.ColorName1);                                  // カラー名称1
                        paraTrimCode.Value = SqlDataMediator.SqlSetString(carManagementWork.TrimCode);                                      // トリムコード
                        paraTrimName.Value = SqlDataMediator.SqlSetString(carManagementWork.TrimName);                                      // トリム名称
                        // --- ADD 2009/09/11 -------------->>>
                        paraCarAddInfo1.Value = SqlDataMediator.SqlSetString(carManagementWork.CarAddInfo1);                                // 車輌追加情報１
                        paraCarAddInfo2.Value = SqlDataMediator.SqlSetString(carManagementWork.CarAddInfo2);                                // 車輌追加情報２
                        paraCarNote.Value = SqlDataMediator.SqlSetString(carManagementWork.CarNote);                                        // 車輌備考
                        // --- ADD 2009/09/11 --------------<<<
                        // ADD 2013/03/22  -------------------->>>>>
                        paraDomesticForeignCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.DomesticForeignCode);                 // 国産/外車区分コード
                        paraHandleInfoCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.HandleInfoCode);                           // ハンドル位置情報コード
                        // ADD 2013/03/22  --------------------<<<<<

                        // int[] → byte[] に変換
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        foreach (int item in carManagementWork.FullModelFixedNoAry)
                            ms.Write(BitConverter.GetBytes(item), 0, sizeof(int));
                        byte[] verbinary = ms.ToArray();
                        ms.Close();

                        paraFullModelFixedNoAry.Value = SqlDataMediator.SqlSetBinary(verbinary);                                            // フル型式固定番号配列
                        paraCategoryObjAry.Value = SqlDataMediator.SqlSetBinary(carManagementWork.CategoryObjAry);                          // 装備オブジェクト配列
                        // --- ADD 2010/04/27 -------------->>>
                        paraFreeSrchMdlFxdNoAry.Value = SqlDataMediator.SqlSetBinary(carManagementWork.FreeSrchMdlFxdNoAry);                                            // 自由検索型式固定番号配列
                        // --- ADD 2010/04/27 --------------<<<
                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(carManagementWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            carManagementList = al;

            return status;
        }
        # endregion

        // ADD 2012/08/29 Wakita -------------------->>>>>
        /// <summary>
        /// 車両管理マスタ情報を追加・更新します。（売上伝票入力更新専用）
        /// </summary>
        /// <param name="carManagementList">追加・更新する車両管理マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : carManagementList に格納されている車両管理マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.06.02</br>
        public int Write2(ref object carManagementList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = carManagementList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // 書込準備処理 (車両管理番号の採番)
                status = this.WriteInitial(ref paraList, sqlConnection, sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 書込処理
                    status = this.Write2(ref paraList, sqlConnection, sqlTransaction);
                }
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ロールバック
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
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
        /// 車両管理マスタ情報を追加・更新します。（売上伝票入力更新専用）
        /// </summary>
        /// <param name="carManagementList">追加・更新する車両管理マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : carManagementList に格納されている車両管理マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.06.02</br>
        public int Write2(ref ArrayList carManagementList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.WriteProc2(ref carManagementList, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// 車両管理マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="carManagementList">追加・更新する車両管理マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : carManagementList に格納されている車両管理マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.06.02</br>
        /// <br>Update Note: 2013/03/22 FSI高橋 文彰</br>
        /// <br>管理番号   : 10900269-00</br>
        /// <br>             SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
        /// <br>Update Note: 2020/08/28 田建委</br>
        /// <br>管理番号   : 11600006-00</br>
        /// <br>             PMKOBETSU-4076 タイムアウト設定</br>
        private int WriteProc2(ref ArrayList carManagementList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>>
            int dbCommandTimeout = DB_COMMAND_TIMEOUT; // コマンドタイムアウト（秒）
            this.GetXmlInfo(ref dbCommandTimeout);
            // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<
            try
            {
                if (carManagementList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < carManagementList.Count; i++)
                    {
                        CarManagementWork carManagementWork = carManagementList[i] as CarManagementWork;
                        // --- ADD 2015/03/23 T.Miyamoto 日之出商会障害対応 -------------------->>>>>
                        // 車輌管理コードが空またはNULLの場合は登録処理を実行しない
                        if (string.IsNullOrEmpty(carManagementWork.CarMngCode.Trim()))
                        {
                            al.Add(carManagementWork);
                            continue;
                        }
                        // --- ADD 2015/03/23 T.Miyamoto 日之出商会障害対応 --------------------<<<<<

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  CARM.CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,CARM.UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,CARM.FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  CARMANAGEMENTRF AS CARM" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  CARM.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND CARM.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlText += "  AND CARM.CARMNGNORF = @FINDCARMNGNO" + Environment.NewLine;
                        sqlText += "  AND CARM.CARMNGCODERF = @FINDCARMNGCODE" + Environment.NewLine; // 2009/12/24
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findCarMngNo = sqlCommand.Parameters.Add("@FINDCARMNGNO", SqlDbType.Int);
                        SqlParameter findCarMngCode = sqlCommand.Parameters.Add("@FINDCARMNGCODE", SqlDbType.NChar); // 2009/12/24

                        // Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(carManagementWork.EnterpriseCode);
                        findCustomerCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CustomerCode);
                        findCarMngNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CarMngNo);
                        findCarMngCode.Value = SqlDataMediator.SqlSetString(carManagementWork.CarMngCode.Trim()); // 2009/12/24

                        sqlCommand.CommandTimeout = dbCommandTimeout; //ADD 田建委 2020/08/28 PMKOBETSU-4076の対応
                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            if (!this._CompulsoryDataOverride)
                            {
                                // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                                if (_updateDateTime != carManagementWork.UpdateDateTime)
                                {
                                    if (carManagementWork.UpdateDateTime == DateTime.MinValue)
                                    {
                                        // 新規登録で該当データ有りの場合には重複
                                        status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                    }
                                    else
                                    {
                                        // 既存データで更新日時違いの場合には排他
                                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                    }

                                    return status;
                                }
                            }
                            else
                            {
                                // 強制的にデータを上書きをする為、作成日時やファイルヘッダーGUIDを上書きしておく
                                // ※fileHeader.SetUpdateHeader ではこれらの項目がセットされない為
                                carManagementWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // 作成日時
                                carManagementWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));                 // GUID
                            }

                            # region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText += "UPDATE CARMANAGEMENTRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERCODERF = @CUSTOMERCODE" + Environment.NewLine;
                            sqlText += " ,CARMNGNORF = @CARMNGNO" + Environment.NewLine;
                            sqlText += " ,CARMNGCODERF = @CARMNGCODE" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE1CODERF = @NUMBERPLATE1CODE" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE1NAMERF = @NUMBERPLATE1NAME" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE2RF = @NUMBERPLATE2" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE3RF = @NUMBERPLATE3" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE4RF = @NUMBERPLATE4" + Environment.NewLine;
                            //sqlText += " ,ENTRYDATERF = @ENTRYDATE" + Environment.NewLine;
                            sqlText += " ,FIRSTENTRYDATERF = @FIRSTENTRYDATE" + Environment.NewLine;
                            sqlText += " ,MAKERCODERF = @MAKERCODE" + Environment.NewLine;
                            sqlText += " ,MAKERFULLNAMERF = @MAKERFULLNAME" + Environment.NewLine;
                            sqlText += " ,MAKERHALFNAMERF = @MAKERHALFNAME" + Environment.NewLine;
                            sqlText += " ,MODELCODERF = @MODELCODE" + Environment.NewLine;
                            sqlText += " ,MODELSUBCODERF = @MODELSUBCODE" + Environment.NewLine;
                            sqlText += " ,MODELFULLNAMERF = @MODELFULLNAME" + Environment.NewLine;
                            sqlText += " ,MODELHALFNAMERF = @MODELHALFNAME" + Environment.NewLine;
                            sqlText += " ,SYSTEMATICCODERF = @SYSTEMATICCODE" + Environment.NewLine;
                            sqlText += " ,SYSTEMATICNAMERF = @SYSTEMATICNAME" + Environment.NewLine;
                            sqlText += " ,PRODUCETYPEOFYEARCDRF = @PRODUCETYPEOFYEARCD" + Environment.NewLine;
                            sqlText += " ,PRODUCETYPEOFYEARNMRF = @PRODUCETYPEOFYEARNM" + Environment.NewLine;
                            sqlText += " ,STPRODUCETYPEOFYEARRF = @STPRODUCETYPEOFYEAR" + Environment.NewLine;
                            sqlText += " ,EDPRODUCETYPEOFYEARRF = @EDPRODUCETYPEOFYEAR" + Environment.NewLine;
                            sqlText += " ,DOORCOUNTRF = @DOORCOUNT" + Environment.NewLine;
                            sqlText += " ,BODYNAMECODERF = @BODYNAMECODE" + Environment.NewLine;
                            sqlText += " ,BODYNAMERF = @BODYNAME" + Environment.NewLine;
                            sqlText += " ,EXHAUSTGASSIGNRF = @EXHAUSTGASSIGN" + Environment.NewLine;
                            sqlText += " ,SERIESMODELRF = @SERIESMODEL" + Environment.NewLine;
                            sqlText += " ,CATEGORYSIGNMODELRF = @CATEGORYSIGNMODEL" + Environment.NewLine;
                            sqlText += " ,FULLMODELRF = @FULLMODEL" + Environment.NewLine;
                            sqlText += " ,MODELDESIGNATIONNORF = @MODELDESIGNATIONNO" + Environment.NewLine;
                            sqlText += " ,CATEGORYNORF = @CATEGORYNO" + Environment.NewLine;
                            sqlText += " ,FRAMEMODELRF = @FRAMEMODEL" + Environment.NewLine;
                            sqlText += " ,FRAMENORF = @FRAMENO" + Environment.NewLine;
                            sqlText += " ,SEARCHFRAMENORF = @SEARCHFRAMENO" + Environment.NewLine;
                            sqlText += " ,STPRODUCEFRAMENORF = @STPRODUCEFRAMENO" + Environment.NewLine;
                            sqlText += " ,EDPRODUCEFRAMENORF = @EDPRODUCEFRAMENO" + Environment.NewLine;
                            //sqlText += " ,ENGINEMODELRF = @ENGINEMODEL" + Environment.NewLine;
                            sqlText += " ,MODELGRADENMRF = @MODELGRADENM" + Environment.NewLine;
                            sqlText += " ,ENGINEMODELNMRF = @ENGINEMODELNM" + Environment.NewLine;
                            sqlText += " ,ENGINEDISPLACENMRF = @ENGINEDISPLACENM" + Environment.NewLine;
                            sqlText += " ,EDIVNMRF = @EDIVNM" + Environment.NewLine;
                            sqlText += " ,TRANSMISSIONNMRF = @TRANSMISSIONNM" + Environment.NewLine;
                            sqlText += " ,SHIFTNMRF = @SHIFTNM" + Environment.NewLine;
                            sqlText += " ,WHEELDRIVEMETHODNMRF = @WHEELDRIVEMETHODNM" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC1RF = @ADDICARSPEC1" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC2RF = @ADDICARSPEC2" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC3RF = @ADDICARSPEC3" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC4RF = @ADDICARSPEC4" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC5RF = @ADDICARSPEC5" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC6RF = @ADDICARSPEC6" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE1RF = @ADDICARSPECTITLE1" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE2RF = @ADDICARSPECTITLE2" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE3RF = @ADDICARSPECTITLE3" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE4RF = @ADDICARSPECTITLE4" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE5RF = @ADDICARSPECTITLE5" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE6RF = @ADDICARSPECTITLE6" + Environment.NewLine;
                            sqlText += " ,RELEVANCEMODELRF = @RELEVANCEMODEL" + Environment.NewLine;
                            sqlText += " ,SUBCARNMCDRF = @SUBCARNMCD" + Environment.NewLine;
                            sqlText += " ,MODELGRADESNAMERF = @MODELGRADESNAME" + Environment.NewLine;
                            sqlText += " ,BLOCKILLUSTRATIONCDRF = @BLOCKILLUSTRATIONCD" + Environment.NewLine;
                            sqlText += " ,THREEDILLUSTNORF = @THREEDILLUSTNO" + Environment.NewLine;
                            sqlText += " ,PARTSDATAOFFERFLAGRF = @PARTSDATAOFFERFLAG" + Environment.NewLine;
                            //sqlText += " ,INSPECTMATURITYDATERF = @INSPECTMATURITYDATE" + Environment.NewLine;
                            //sqlText += " ,LTIMECIMATDATERF = @LTIMECIMATDATE" + Environment.NewLine;
                            //sqlText += " ,CARINSPECTYEARRF = @CARINSPECTYEAR" + Environment.NewLine;
                            sqlText += " ,MILEAGERF = @MILEAGE" + Environment.NewLine;
                            sqlText += " ,CARNORF = @CARNO" + Environment.NewLine;
                            sqlText += " ,COLORCODERF = @COLORCODE" + Environment.NewLine;
                            sqlText += " ,COLORNAME1RF = @COLORNAME1" + Environment.NewLine;
                            sqlText += " ,TRIMCODERF = @TRIMCODE" + Environment.NewLine;
                            sqlText += " ,TRIMNAMERF = @TRIMNAME" + Environment.NewLine;
                            sqlText += " ,FULLMODELFIXEDNOARYRF = @FULLMODELFIXEDNOARY" + Environment.NewLine;
                            sqlText += " ,CATEGORYOBJARYRF = @CATEGORYOBJARY" + Environment.NewLine;
                            // --- ADD 2009/09/11 -------------->>>
                            //sqlText += " ,CARADDINFO1RF = @CARADDINFO1" + Environment.NewLine;
                            //sqlText += " ,CARADDINFO2RF = @CARADDINFO2" + Environment.NewLine;
                            sqlText += " ,CARNOTERF = @CARNOTE" + Environment.NewLine;
                            // --- ADD 2009/09/11 --------------<<<
                            // --- ADD 2010/04/27 -------------->>>
                            sqlText += " ,FREESRCHMDLFXDNOARYRF = @FREESRCHMDLFXDNOARY" + Environment.NewLine;
                            // --- ADD 2010/04/27 --------------<<<
                            // ADD 2013/03/22  -------------------->>>>>
                            sqlText += " ,DOMESTICFOREIGNCODERF = @DOMESTICFOREIGNCODERF" + Environment.NewLine;
                            sqlText += " ,HANDLEINFOCDRF = @HANDLEINFOCDRF" + Environment.NewLine;
                            // ADD 2013/03/22  --------------------<<<<<
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                            sqlText += "  AND CARMNGNORF = @FINDCARMNGNO" + Environment.NewLine;
                            sqlText += "  AND CARMNGCODERF = @FINDCARMNGCODE" + Environment.NewLine; // 2009/12/24
                            # endregion

                            // KEYコマンドを再設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(carManagementWork.EnterpriseCode);
                            findCustomerCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CustomerCode);
                            findCarMngNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CarMngNo);
                            findCarMngCode.Value = SqlDataMediator.SqlSetString(carManagementWork.CarMngCode); //2009/12/24

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)carManagementWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (carManagementWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT文]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO CARMANAGEMENTRF (" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERCODERF" + Environment.NewLine;
                            sqlText += " ,CARMNGNORF" + Environment.NewLine;
                            sqlText += " ,CARMNGCODERF" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE1CODERF" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE1NAMERF" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE2RF" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE3RF" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE4RF" + Environment.NewLine;
                            //sqlText += " ,ENTRYDATERF" + Environment.NewLine;
                            sqlText += " ,FIRSTENTRYDATERF" + Environment.NewLine;
                            sqlText += " ,MAKERCODERF" + Environment.NewLine;
                            sqlText += " ,MAKERFULLNAMERF" + Environment.NewLine;
                            sqlText += " ,MAKERHALFNAMERF" + Environment.NewLine;
                            sqlText += " ,MODELCODERF" + Environment.NewLine;
                            sqlText += " ,MODELSUBCODERF" + Environment.NewLine;
                            sqlText += " ,MODELFULLNAMERF" + Environment.NewLine;
                            sqlText += " ,MODELHALFNAMERF" + Environment.NewLine;
                            sqlText += " ,SYSTEMATICCODERF" + Environment.NewLine;
                            sqlText += " ,SYSTEMATICNAMERF" + Environment.NewLine;
                            sqlText += " ,PRODUCETYPEOFYEARCDRF" + Environment.NewLine;
                            sqlText += " ,PRODUCETYPEOFYEARNMRF" + Environment.NewLine;
                            sqlText += " ,STPRODUCETYPEOFYEARRF" + Environment.NewLine;
                            sqlText += " ,EDPRODUCETYPEOFYEARRF" + Environment.NewLine;
                            sqlText += " ,DOORCOUNTRF" + Environment.NewLine;
                            sqlText += " ,BODYNAMECODERF" + Environment.NewLine;
                            sqlText += " ,BODYNAMERF" + Environment.NewLine;
                            sqlText += " ,EXHAUSTGASSIGNRF" + Environment.NewLine;
                            sqlText += " ,SERIESMODELRF" + Environment.NewLine;
                            sqlText += " ,CATEGORYSIGNMODELRF" + Environment.NewLine;
                            sqlText += " ,FULLMODELRF" + Environment.NewLine;
                            sqlText += " ,MODELDESIGNATIONNORF" + Environment.NewLine;
                            sqlText += " ,CATEGORYNORF" + Environment.NewLine;
                            sqlText += " ,FRAMEMODELRF" + Environment.NewLine;
                            sqlText += " ,FRAMENORF" + Environment.NewLine;
                            sqlText += " ,SEARCHFRAMENORF" + Environment.NewLine;
                            sqlText += " ,STPRODUCEFRAMENORF" + Environment.NewLine;
                            sqlText += " ,EDPRODUCEFRAMENORF" + Environment.NewLine;
                            //sqlText += " ,ENGINEMODELRF" + Environment.NewLine;
                            sqlText += " ,MODELGRADENMRF" + Environment.NewLine;
                            sqlText += " ,ENGINEMODELNMRF" + Environment.NewLine;
                            sqlText += " ,ENGINEDISPLACENMRF" + Environment.NewLine;
                            sqlText += " ,EDIVNMRF" + Environment.NewLine;
                            sqlText += " ,TRANSMISSIONNMRF" + Environment.NewLine;
                            sqlText += " ,SHIFTNMRF" + Environment.NewLine;
                            sqlText += " ,WHEELDRIVEMETHODNMRF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC1RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC2RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC3RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC4RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC5RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC6RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE1RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE2RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE3RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE4RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE5RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE6RF" + Environment.NewLine;
                            sqlText += " ,RELEVANCEMODELRF" + Environment.NewLine;
                            sqlText += " ,SUBCARNMCDRF" + Environment.NewLine;
                            sqlText += " ,MODELGRADESNAMERF" + Environment.NewLine;
                            sqlText += " ,BLOCKILLUSTRATIONCDRF" + Environment.NewLine;
                            sqlText += " ,THREEDILLUSTNORF" + Environment.NewLine;
                            sqlText += " ,PARTSDATAOFFERFLAGRF" + Environment.NewLine;
                            //sqlText += " ,INSPECTMATURITYDATERF" + Environment.NewLine;
                            //sqlText += " ,LTIMECIMATDATERF" + Environment.NewLine;
                            //sqlText += " ,CARINSPECTYEARRF" + Environment.NewLine;
                            sqlText += " ,MILEAGERF" + Environment.NewLine;
                            sqlText += " ,CARNORF" + Environment.NewLine;
                            sqlText += " ,COLORCODERF" + Environment.NewLine;
                            sqlText += " ,COLORNAME1RF" + Environment.NewLine;
                            sqlText += " ,TRIMCODERF" + Environment.NewLine;
                            sqlText += " ,TRIMNAMERF" + Environment.NewLine;
                            sqlText += " ,FULLMODELFIXEDNOARYRF" + Environment.NewLine;
                            // --- ADD 2010/04/27 -------------->>>
                            sqlText += " ,FREESRCHMDLFXDNOARYRF" + Environment.NewLine;
                            // --- ADD 2010/04/27 --------------<<<
                            // --- UPD 2009/09/11 -------------->>>
                            //sqlText += " ,CATEGORYOBJARYRF)" + Environment.NewLine;
                            sqlText += " ,CATEGORYOBJARYRF" + Environment.NewLine;
                            //sqlText += " ,CARADDINFO1RF" + Environment.NewLine;
                            //sqlText += " ,CARADDINFO2RF" + Environment.NewLine;
                            sqlText += " ,CARNOTERF" + Environment.NewLine;
                            // --- UPD 2009/09/11 --------------<<<
                            // ADD 2013/03/22 -------------------->>>>>
                            sqlText += " ,DOMESTICFOREIGNCODERF" + Environment.NewLine;
                            sqlText += " ,HANDLEINFOCDRF)" + Environment.NewLine;
                            // ADD 2013/03/22 --------------------<<<<<
                            sqlText += "VALUES" + Environment.NewLine;
                            sqlText += "  (@CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERCODE" + Environment.NewLine;
                            sqlText += " ,@CARMNGNO" + Environment.NewLine;
                            sqlText += " ,@CARMNGCODE" + Environment.NewLine;
                            sqlText += " ,@NUMBERPLATE1CODE" + Environment.NewLine;
                            sqlText += " ,@NUMBERPLATE1NAME" + Environment.NewLine;
                            sqlText += " ,@NUMBERPLATE2" + Environment.NewLine;
                            sqlText += " ,@NUMBERPLATE3" + Environment.NewLine;
                            sqlText += " ,@NUMBERPLATE4" + Environment.NewLine;
                            //sqlText += " ,@ENTRYDATE" + Environment.NewLine;
                            sqlText += " ,@FIRSTENTRYDATE" + Environment.NewLine;
                            sqlText += " ,@MAKERCODE" + Environment.NewLine;
                            sqlText += " ,@MAKERFULLNAME" + Environment.NewLine;
                            sqlText += " ,@MAKERHALFNAME" + Environment.NewLine;
                            sqlText += " ,@MODELCODE" + Environment.NewLine;
                            sqlText += " ,@MODELSUBCODE" + Environment.NewLine;
                            sqlText += " ,@MODELFULLNAME" + Environment.NewLine;
                            sqlText += " ,@MODELHALFNAME" + Environment.NewLine;
                            sqlText += " ,@SYSTEMATICCODE" + Environment.NewLine;
                            sqlText += " ,@SYSTEMATICNAME" + Environment.NewLine;
                            sqlText += " ,@PRODUCETYPEOFYEARCD" + Environment.NewLine;
                            sqlText += " ,@PRODUCETYPEOFYEARNM" + Environment.NewLine;
                            sqlText += " ,@STPRODUCETYPEOFYEAR" + Environment.NewLine;
                            sqlText += " ,@EDPRODUCETYPEOFYEAR" + Environment.NewLine;
                            sqlText += " ,@DOORCOUNT" + Environment.NewLine;
                            sqlText += " ,@BODYNAMECODE" + Environment.NewLine;
                            sqlText += " ,@BODYNAME" + Environment.NewLine;
                            sqlText += " ,@EXHAUSTGASSIGN" + Environment.NewLine;
                            sqlText += " ,@SERIESMODEL" + Environment.NewLine;
                            sqlText += " ,@CATEGORYSIGNMODEL" + Environment.NewLine;
                            sqlText += " ,@FULLMODEL" + Environment.NewLine;
                            sqlText += " ,@MODELDESIGNATIONNO" + Environment.NewLine;
                            sqlText += " ,@CATEGORYNO" + Environment.NewLine;
                            sqlText += " ,@FRAMEMODEL" + Environment.NewLine;
                            sqlText += " ,@FRAMENO" + Environment.NewLine;
                            sqlText += " ,@SEARCHFRAMENO" + Environment.NewLine;
                            sqlText += " ,@STPRODUCEFRAMENO" + Environment.NewLine;
                            sqlText += " ,@EDPRODUCEFRAMENO" + Environment.NewLine;
                            //sqlText += " ,@ENGINEMODEL" + Environment.NewLine;
                            sqlText += " ,@MODELGRADENM" + Environment.NewLine;
                            sqlText += " ,@ENGINEMODELNM" + Environment.NewLine;
                            sqlText += " ,@ENGINEDISPLACENM" + Environment.NewLine;
                            sqlText += " ,@EDIVNM" + Environment.NewLine;
                            sqlText += " ,@TRANSMISSIONNM" + Environment.NewLine;
                            sqlText += " ,@SHIFTNM" + Environment.NewLine;
                            sqlText += " ,@WHEELDRIVEMETHODNM" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPEC1" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPEC2" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPEC3" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPEC4" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPEC5" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPEC6" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPECTITLE1" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPECTITLE2" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPECTITLE3" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPECTITLE4" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPECTITLE5" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPECTITLE6" + Environment.NewLine;
                            sqlText += " ,@RELEVANCEMODEL" + Environment.NewLine;
                            sqlText += " ,@SUBCARNMCD" + Environment.NewLine;
                            sqlText += " ,@MODELGRADESNAME" + Environment.NewLine;
                            sqlText += " ,@BLOCKILLUSTRATIONCD" + Environment.NewLine;
                            sqlText += " ,@THREEDILLUSTNO" + Environment.NewLine;
                            sqlText += " ,@PARTSDATAOFFERFLAG" + Environment.NewLine;
                            //sqlText += " ,@INSPECTMATURITYDATE" + Environment.NewLine;
                            //sqlText += " ,@LTIMECIMATDATE" + Environment.NewLine;
                            //sqlText += " ,@CARINSPECTYEAR" + Environment.NewLine;
                            sqlText += " ,@MILEAGE" + Environment.NewLine;
                            sqlText += " ,@CARNO" + Environment.NewLine;
                            sqlText += " ,@COLORCODE" + Environment.NewLine;
                            sqlText += " ,@COLORNAME1" + Environment.NewLine;
                            sqlText += " ,@TRIMCODE" + Environment.NewLine;
                            sqlText += " ,@TRIMNAME" + Environment.NewLine;
                            sqlText += " ,@FULLMODELFIXEDNOARY" + Environment.NewLine;
                            // --- ADD 2010/04/27 -------------->>>
                            sqlText += " ,@FREESRCHMDLFXDNOARY" + Environment.NewLine;
                            // --- ADD 2010/04/27 --------------<<<
                            // --- UPD 2009/09/11 -------------->>>
                            // sqlText += " ,@CATEGORYOBJARY" + Environment.NewLine;
                            sqlText += " ,@CATEGORYOBJARY" + Environment.NewLine;
                            //sqlText += " ,@CARADDINFO1" + Environment.NewLine;
                            //sqlText += " ,@CARADDINFO2" + Environment.NewLine;
                            sqlText += " ,@CARNOTE" + Environment.NewLine;
                            // --- UPD 2009/09/11 --------------<<<
                            // ADD 2013/03/22  -------------------->>>>>
                            sqlText += " ,@DOMESTICFOREIGNCODERF" + Environment.NewLine;
                            sqlText += " ,@HANDLEINFOCDRF)" + Environment.NewLine;
                            // ADD 2013/03/22  --------------------<<<<<
                            # endregion

                            // 登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)carManagementWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        sqlCommand.CommandText = sqlText;

                        # region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);               // 作成日時
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);               // 更新日時
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);                // 企業コード
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);     // GUID
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);              // 更新従業員コード
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);             // 更新アセンブリID1
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);             // 更新アセンブリID2
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);            // 論理削除区分
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);                      // 得意先コード
                        SqlParameter paraCarMngNo = sqlCommand.Parameters.Add("@CARMNGNO", SqlDbType.Int);                              // 車両管理番号
                        SqlParameter paraCarMngCode = sqlCommand.Parameters.Add("@CARMNGCODE", SqlDbType.NVarChar);                     // 車輌管理コード
                        SqlParameter paraNumberPlate1Code = sqlCommand.Parameters.Add("@NUMBERPLATE1CODE", SqlDbType.Int);              // 陸運事務所番号
                        SqlParameter paraNumberPlate1Name = sqlCommand.Parameters.Add("@NUMBERPLATE1NAME", SqlDbType.NVarChar);         // 陸運事務局名称
                        SqlParameter paraNumberPlate2 = sqlCommand.Parameters.Add("@NUMBERPLATE2", SqlDbType.NVarChar);                 // 車両登録番号（種別）
                        SqlParameter paraNumberPlate3 = sqlCommand.Parameters.Add("@NUMBERPLATE3", SqlDbType.NVarChar);                 // 車両登録番号（カナ）
                        SqlParameter paraNumberPlate4 = sqlCommand.Parameters.Add("@NUMBERPLATE4", SqlDbType.Int);                      // 車両登録番号（プレート番号）
                        //SqlParameter paraEntryDate = sqlCommand.Parameters.Add("@ENTRYDATE", SqlDbType.Int);                            // 登録年月日
                        SqlParameter paraFirstEntryDate = sqlCommand.Parameters.Add("@FIRSTENTRYDATE", SqlDbType.Int);                  // 初年度
                        SqlParameter paraMakerCode = sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int);                            // メーカーコード
                        SqlParameter paraMakerFullName = sqlCommand.Parameters.Add("@MAKERFULLNAME", SqlDbType.NVarChar);               // メーカー全角名称
                        SqlParameter paraMakerHalfName = sqlCommand.Parameters.Add("@MAKERHALFNAME", SqlDbType.NVarChar);               // メーカー半角名称
                        SqlParameter paraModelCode = sqlCommand.Parameters.Add("@MODELCODE", SqlDbType.Int);                            // 車種コード
                        SqlParameter paraModelSubCode = sqlCommand.Parameters.Add("@MODELSUBCODE", SqlDbType.Int);                      // 車種サブコード
                        SqlParameter paraModelFullName = sqlCommand.Parameters.Add("@MODELFULLNAME", SqlDbType.NVarChar);               // 車種全角名称
                        SqlParameter paraModelHalfName = sqlCommand.Parameters.Add("@MODELHALFNAME", SqlDbType.NVarChar);               // 車種半角名称
                        SqlParameter paraSystematicCode = sqlCommand.Parameters.Add("@SYSTEMATICCODE", SqlDbType.Int);                  // 系統コード
                        SqlParameter paraSystematicName = sqlCommand.Parameters.Add("@SYSTEMATICNAME", SqlDbType.NVarChar);             // 系統名称
                        SqlParameter paraProduceTypeOfYearCd = sqlCommand.Parameters.Add("@PRODUCETYPEOFYEARCD", SqlDbType.Int);        // 生産年式コード
                        SqlParameter paraProduceTypeOfYearNm = sqlCommand.Parameters.Add("@PRODUCETYPEOFYEARNM", SqlDbType.NVarChar);   // 生産年式名称
                        SqlParameter paraStProduceTypeOfYear = sqlCommand.Parameters.Add("@STPRODUCETYPEOFYEAR", SqlDbType.Int);        // 開始生産年式
                        SqlParameter paraEdProduceTypeOfYear = sqlCommand.Parameters.Add("@EDPRODUCETYPEOFYEAR", SqlDbType.Int);        // 終了生産年式
                        SqlParameter paraDoorCount = sqlCommand.Parameters.Add("@DOORCOUNT", SqlDbType.Int);                            // ドア数
                        SqlParameter paraBodyNameCode = sqlCommand.Parameters.Add("@BODYNAMECODE", SqlDbType.Int);                      // ボディー名コード
                        SqlParameter paraBodyName = sqlCommand.Parameters.Add("@BODYNAME", SqlDbType.NVarChar);                         // ボディー名称
                        SqlParameter paraExhaustGasSign = sqlCommand.Parameters.Add("@EXHAUSTGASSIGN", SqlDbType.NVarChar);             // 排ガス記号
                        SqlParameter paraSeriesModel = sqlCommand.Parameters.Add("@SERIESMODEL", SqlDbType.NVarChar);                   // シリーズ型式
                        SqlParameter paraCategorySignModel = sqlCommand.Parameters.Add("@CATEGORYSIGNMODEL", SqlDbType.NVarChar);       // 型式（類別記号）
                        SqlParameter paraFullModel = sqlCommand.Parameters.Add("@FULLMODEL", SqlDbType.NVarChar);                       // 型式（フル型）
                        SqlParameter paraModelDesignationNo = sqlCommand.Parameters.Add("@MODELDESIGNATIONNO", SqlDbType.Int);          // 型式指定番号
                        SqlParameter paraCategoryNo = sqlCommand.Parameters.Add("@CATEGORYNO", SqlDbType.Int);                          // 類別番号
                        SqlParameter paraFrameModel = sqlCommand.Parameters.Add("@FRAMEMODEL", SqlDbType.NVarChar);                     // 車台型式
                        SqlParameter paraFrameNo = sqlCommand.Parameters.Add("@FRAMENO", SqlDbType.NVarChar);                           // 車台番号
                        SqlParameter paraSearchFrameNo = sqlCommand.Parameters.Add("@SEARCHFRAMENO", SqlDbType.Int);                    // 車台番号（検索用）
                        SqlParameter paraStProduceFrameNo = sqlCommand.Parameters.Add("@STPRODUCEFRAMENO", SqlDbType.Int);              // 生産車台番号開始
                        SqlParameter paraEdProduceFrameNo = sqlCommand.Parameters.Add("@EDPRODUCEFRAMENO", SqlDbType.Int);              // 生産車台番号終了
                        //SqlParameter paraEngineModel = sqlCommand.Parameters.Add("@ENGINEMODEL", SqlDbType.NVarChar);                   // 原動機型式（エンジン）
                        SqlParameter paraModelGradeNm = sqlCommand.Parameters.Add("@MODELGRADENM", SqlDbType.NVarChar);                 // 型式グレード名称
                        SqlParameter paraEngineModelNm = sqlCommand.Parameters.Add("@ENGINEMODELNM", SqlDbType.NVarChar);               // エンジン型式名称
                        SqlParameter paraEngineDisplaceNm = sqlCommand.Parameters.Add("@ENGINEDISPLACENM", SqlDbType.NVarChar);         // 排気量名称
                        SqlParameter paraEDivNm = sqlCommand.Parameters.Add("@EDIVNM", SqlDbType.NVarChar);                             // E区分名称
                        SqlParameter paraTransmissionNm = sqlCommand.Parameters.Add("@TRANSMISSIONNM", SqlDbType.NVarChar);             // ミッション名称
                        SqlParameter paraShiftNm = sqlCommand.Parameters.Add("@SHIFTNM", SqlDbType.NVarChar);                           // シフト名称
                        SqlParameter paraWheelDriveMethodNm = sqlCommand.Parameters.Add("@WHEELDRIVEMETHODNM", SqlDbType.NVarChar);     // 駆動方式名称
                        SqlParameter paraAddiCarSpec1 = sqlCommand.Parameters.Add("@ADDICARSPEC1", SqlDbType.NVarChar);                 // 追加諸元1
                        SqlParameter paraAddiCarSpec2 = sqlCommand.Parameters.Add("@ADDICARSPEC2", SqlDbType.NVarChar);                 // 追加諸元2
                        SqlParameter paraAddiCarSpec3 = sqlCommand.Parameters.Add("@ADDICARSPEC3", SqlDbType.NVarChar);                 // 追加諸元3
                        SqlParameter paraAddiCarSpec4 = sqlCommand.Parameters.Add("@ADDICARSPEC4", SqlDbType.NVarChar);                 // 追加諸元4
                        SqlParameter paraAddiCarSpec5 = sqlCommand.Parameters.Add("@ADDICARSPEC5", SqlDbType.NVarChar);                 // 追加諸元5
                        SqlParameter paraAddiCarSpec6 = sqlCommand.Parameters.Add("@ADDICARSPEC6", SqlDbType.NVarChar);                 // 追加諸元6
                        SqlParameter paraAddiCarSpecTitle1 = sqlCommand.Parameters.Add("@ADDICARSPECTITLE1", SqlDbType.NVarChar);       // 追加諸元タイトル1
                        SqlParameter paraAddiCarSpecTitle2 = sqlCommand.Parameters.Add("@ADDICARSPECTITLE2", SqlDbType.NVarChar);       // 追加諸元タイトル2
                        SqlParameter paraAddiCarSpecTitle3 = sqlCommand.Parameters.Add("@ADDICARSPECTITLE3", SqlDbType.NVarChar);       // 追加諸元タイトル3
                        SqlParameter paraAddiCarSpecTitle4 = sqlCommand.Parameters.Add("@ADDICARSPECTITLE4", SqlDbType.NVarChar);       // 追加諸元タイトル4
                        SqlParameter paraAddiCarSpecTitle5 = sqlCommand.Parameters.Add("@ADDICARSPECTITLE5", SqlDbType.NVarChar);       // 追加諸元タイトル5
                        SqlParameter paraAddiCarSpecTitle6 = sqlCommand.Parameters.Add("@ADDICARSPECTITLE6", SqlDbType.NVarChar);       // 追加諸元タイトル6
                        SqlParameter paraRelevanceModel = sqlCommand.Parameters.Add("@RELEVANCEMODEL", SqlDbType.NVarChar);             // 関連型式
                        SqlParameter paraSubCarNmCd = sqlCommand.Parameters.Add("@SUBCARNMCD", SqlDbType.Int);                          // サブ車名コード
                        SqlParameter paraModelGradeSname = sqlCommand.Parameters.Add("@MODELGRADESNAME", SqlDbType.NVarChar);           // 型式グレード略称
                        SqlParameter paraBlockIllustrationCd = sqlCommand.Parameters.Add("@BLOCKILLUSTRATIONCD", SqlDbType.Int);        // ブロックイラストコード
                        SqlParameter paraThreeDIllustNo = sqlCommand.Parameters.Add("@THREEDILLUSTNO", SqlDbType.Int);                  // 3DイラストNo
                        SqlParameter paraPartsDataOfferFlag = sqlCommand.Parameters.Add("@PARTSDATAOFFERFLAG", SqlDbType.Int);          // 部品データ提供フラグ
                        //SqlParameter paraInspectMaturityDate = sqlCommand.Parameters.Add("@INSPECTMATURITYDATE", SqlDbType.Int);        // 車検満期日
                        //SqlParameter paraLTimeCiMatDate = sqlCommand.Parameters.Add("@LTIMECIMATDATE", SqlDbType.Int);                  // 前回車検満期日
                        //SqlParameter paraCarInspectYear = sqlCommand.Parameters.Add("@CARINSPECTYEAR", SqlDbType.Int);                  // 車検期間
                        SqlParameter paraMileage = sqlCommand.Parameters.Add("@MILEAGE", SqlDbType.Int);                                // 車両走行距離
                        SqlParameter paraCarNo = sqlCommand.Parameters.Add("@CARNO", SqlDbType.NVarChar);                               // 号車
                        SqlParameter paraColorCode = sqlCommand.Parameters.Add("@COLORCODE", SqlDbType.NVarChar);                       // カラーコード
                        SqlParameter paraColorName1 = sqlCommand.Parameters.Add("@COLORNAME1", SqlDbType.NVarChar);                     // カラー名称1
                        SqlParameter paraTrimCode = sqlCommand.Parameters.Add("@TRIMCODE", SqlDbType.NVarChar);                         // トリムコード
                        SqlParameter paraTrimName = sqlCommand.Parameters.Add("@TRIMNAME", SqlDbType.NVarChar);                         // トリム名称
                        SqlParameter paraFullModelFixedNoAry = sqlCommand.Parameters.Add("@FULLMODELFIXEDNOARY", SqlDbType.VarBinary);  // フル型式固定番号配列
                        SqlParameter paraCategoryObjAry = sqlCommand.Parameters.Add("@CATEGORYOBJARY", SqlDbType.VarBinary);            // 装備オブジェクト配列
                        // --- ADD 2010/04/27 -------------->>>
                        SqlParameter paraFreeSrchMdlFxdNoAry = sqlCommand.Parameters.Add("@FREESRCHMDLFXDNOARY", SqlDbType.VarBinary);  // 自由検索型式固定番号配列
                        // --- ADD 2010/04/27 --------------<<<
                        // --- ADD 2009/09/11 -------------->>>
                        //SqlParameter paraCarAddInfo1 = sqlCommand.Parameters.Add("@CARADDINFO1", SqlDbType.NVarChar);                   // 車輌追加情報１
                        //SqlParameter paraCarAddInfo2 = sqlCommand.Parameters.Add("@CARADDINFO2", SqlDbType.NVarChar);                   // 車輌追加情報２
                        SqlParameter paraCarNote = sqlCommand.Parameters.Add("@CARNOTE", SqlDbType.NVarChar);                           // 車輌備考
                        // --- ADD 2009/09/11 --------------<<<
                        // ADD 2013/03/22  -------------------->>>>>
                        SqlParameter paraDomesticForeignCode = sqlCommand.Parameters.Add("@DOMESTICFOREIGNCODERF", SqlDbType.Int);      // 国産/外車区分
                        SqlParameter paraHandleInfoCode = sqlCommand.Parameters.Add("@HANDLEINFOCDRF", SqlDbType.Int);                  // ハンドル位置情報
                        // ADD 2013/03/22  --------------------<<<<<

                        # endregion

                        # region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(carManagementWork.CreateDateTime);               // 作成日時
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(carManagementWork.UpdateDateTime);               // 更新日時
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(carManagementWork.EnterpriseCode);                          // 企業コード
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(carManagementWork.FileHeaderGuid);                            // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(carManagementWork.UpdEmployeeCode);                        // 更新従業員コード
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(carManagementWork.UpdAssemblyId1);                          // 更新アセンブリID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(carManagementWork.UpdAssemblyId2);                          // 更新アセンブリID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.LogicalDeleteCode);                     // 論理削除区分
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CustomerCode);                               // 得意先コード
                        paraCarMngNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CarMngNo);                                       // 車両管理番号
                        paraCarMngCode.Value = SqlDataMediator.SqlSetString(carManagementWork.CarMngCode);                                  // 車輌管理コード
                        paraNumberPlate1Code.Value = SqlDataMediator.SqlSetInt32(carManagementWork.NumberPlate1Code);                       // 陸運事務所番号
                        paraNumberPlate1Name.Value = SqlDataMediator.SqlSetString(carManagementWork.NumberPlate1Name);                      // 陸運事務局名称
                        paraNumberPlate2.Value = SqlDataMediator.SqlSetString(carManagementWork.NumberPlate2);                              // 車両登録番号（種別）
                        paraNumberPlate3.Value = SqlDataMediator.SqlSetString(carManagementWork.NumberPlate3);                              // 車両登録番号（カナ）
                        paraNumberPlate4.Value = SqlDataMediator.SqlSetInt32(carManagementWork.NumberPlate4);                               // 車両登録番号（プレート番号）
                        //paraEntryDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(carManagementWork.EntryDate);                      // 登録年月日
                        //paraFirstEntryDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(carManagementWork.FirstEntryDate);              // 初年度
                        paraFirstEntryDate.Value = SqlDataMediator.SqlSetInt32(carManagementWork.FirstEntryDate);                           // 初年度
                        paraMakerCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.MakerCode);                                     // メーカーコード
                        paraMakerFullName.Value = SqlDataMediator.SqlSetString(carManagementWork.MakerFullName);                            // メーカー全角名称
                        paraMakerHalfName.Value = SqlDataMediator.SqlSetString(carManagementWork.MakerHalfName);                            // メーカー半角名称                        
                        paraModelCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.ModelCode);                                     // 車種コード
                        paraModelSubCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.ModelSubCode);                               // 車種サブコード
                        paraModelFullName.Value = SqlDataMediator.SqlSetString(carManagementWork.ModelFullName);                            // 車種全角名称
                        paraModelHalfName.Value = SqlDataMediator.SqlSetString(carManagementWork.ModelHalfName);                            // 車種半角名称
                        paraSystematicCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.SystematicCode);                           // 系統コード
                        paraSystematicName.Value = SqlDataMediator.SqlSetString(carManagementWork.SystematicName);                          // 系統名称
                        paraProduceTypeOfYearCd.Value = SqlDataMediator.SqlSetInt32(carManagementWork.ProduceTypeOfYearCd);                 // 生産年式コード
                        paraProduceTypeOfYearNm.Value = SqlDataMediator.SqlSetString(carManagementWork.ProduceTypeOfYearNm);                // 生産年式名称
                        paraStProduceTypeOfYear.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(carManagementWork.StProduceTypeOfYear);    // 開始生産年式
                        paraEdProduceTypeOfYear.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(carManagementWork.EdProduceTypeOfYear);    // 終了生産年式
                        paraDoorCount.Value = SqlDataMediator.SqlSetInt32(carManagementWork.DoorCount);                                     // ドア数
                        paraBodyNameCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.BodyNameCode);                               // ボディー名コード
                        paraBodyName.Value = SqlDataMediator.SqlSetString(carManagementWork.BodyName);                                      // ボディー名称
                        paraExhaustGasSign.Value = SqlDataMediator.SqlSetString(carManagementWork.ExhaustGasSign);                          // 排ガス記号
                        paraSeriesModel.Value = SqlDataMediator.SqlSetString(carManagementWork.SeriesModel);                                // シリーズ型式
                        paraCategorySignModel.Value = SqlDataMediator.SqlSetString(carManagementWork.CategorySignModel);                    // 型式（類別記号）
                        paraFullModel.Value = SqlDataMediator.SqlSetString(carManagementWork.FullModel);                                    // 型式（フル型）
                        paraModelDesignationNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.ModelDesignationNo);                   // 型式指定番号
                        paraCategoryNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CategoryNo);                                   // 類別番号
                        paraFrameModel.Value = SqlDataMediator.SqlSetString(carManagementWork.FrameModel);                                  // 車台型式
                        paraFrameNo.Value = SqlDataMediator.SqlSetString(carManagementWork.FrameNo);                                        // 車台番号
                        paraSearchFrameNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.SearchFrameNo);                             // 車台番号（検索用）
                        paraStProduceFrameNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.StProduceFrameNo);                       // 生産車台番号開始
                        paraEdProduceFrameNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.EdProduceFrameNo);                       // 生産車台番号終了
                        //paraEngineModel.Value = SqlDataMediator.SqlSetString(carManagementWork.EngineModel);                                // 原動機型式（エンジン）
                        paraModelGradeNm.Value = SqlDataMediator.SqlSetString(carManagementWork.ModelGradeNm);                              // 型式グレード名称
                        paraEngineModelNm.Value = SqlDataMediator.SqlSetString(carManagementWork.EngineModelNm);                            // エンジン型式名称
                        paraEngineDisplaceNm.Value = SqlDataMediator.SqlSetString(carManagementWork.EngineDisplaceNm);                      // 排気量名称
                        paraEDivNm.Value = SqlDataMediator.SqlSetString(carManagementWork.EDivNm);                                          // E区分名称
                        paraTransmissionNm.Value = SqlDataMediator.SqlSetString(carManagementWork.TransmissionNm);                          // ミッション名称
                        paraShiftNm.Value = SqlDataMediator.SqlSetString(carManagementWork.ShiftNm);                                        // シフト名称
                        paraWheelDriveMethodNm.Value = SqlDataMediator.SqlSetString(carManagementWork.WheelDriveMethodNm);                  // 駆動方式名称
                        paraAddiCarSpec1.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpec1);                              // 追加諸元1
                        paraAddiCarSpec2.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpec2);                              // 追加諸元2
                        paraAddiCarSpec3.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpec3);                              // 追加諸元3
                        paraAddiCarSpec4.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpec4);                              // 追加諸元4
                        paraAddiCarSpec5.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpec5);                              // 追加諸元5
                        paraAddiCarSpec6.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpec6);                              // 追加諸元6
                        paraAddiCarSpecTitle1.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpecTitle1);                    // 追加諸元タイトル1
                        paraAddiCarSpecTitle2.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpecTitle2);                    // 追加諸元タイトル2
                        paraAddiCarSpecTitle3.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpecTitle3);                    // 追加諸元タイトル3
                        paraAddiCarSpecTitle4.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpecTitle4);                    // 追加諸元タイトル4
                        paraAddiCarSpecTitle5.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpecTitle5);                    // 追加諸元タイトル5
                        paraAddiCarSpecTitle6.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpecTitle6);                    // 追加諸元タイトル6
                        paraRelevanceModel.Value = SqlDataMediator.SqlSetString(carManagementWork.RelevanceModel);                          // 関連型式
                        paraSubCarNmCd.Value = SqlDataMediator.SqlSetInt32(carManagementWork.SubCarNmCd);                                   // サブ車名コード
                        paraModelGradeSname.Value = SqlDataMediator.SqlSetString(carManagementWork.ModelGradeSname);                        // 型式グレード略称
                        paraBlockIllustrationCd.Value = SqlDataMediator.SqlSetInt32(carManagementWork.BlockIllustrationCd);                 // ブロックイラストコード
                        paraThreeDIllustNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.ThreeDIllustNo);                           // 3DイラストNo
                        paraPartsDataOfferFlag.Value = SqlDataMediator.SqlSetInt32(carManagementWork.PartsDataOfferFlag);                   // 部品データ提供フラグ
                        //paraInspectMaturityDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(carManagementWork.InspectMaturityDate);  // 車検満期日
                        //paraLTimeCiMatDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(carManagementWork.LTimeCiMatDate);            // 前回車検満期日
                        //paraCarInspectYear.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CarInspectYear);                           // 車検期間
                        paraMileage.Value = SqlDataMediator.SqlSetInt32(carManagementWork.Mileage);                                         // 車両走行距離
                        paraCarNo.Value = SqlDataMediator.SqlSetString(carManagementWork.CarNo);                                            // 号車
                        paraColorCode.Value = SqlDataMediator.SqlSetString(carManagementWork.ColorCode);                                    // カラーコード
                        paraColorName1.Value = SqlDataMediator.SqlSetString(carManagementWork.ColorName1);                                  // カラー名称1
                        paraTrimCode.Value = SqlDataMediator.SqlSetString(carManagementWork.TrimCode);                                      // トリムコード
                        paraTrimName.Value = SqlDataMediator.SqlSetString(carManagementWork.TrimName);                                      // トリム名称
                        // --- ADD 2009/09/11 -------------->>>
                        //paraCarAddInfo1.Value = SqlDataMediator.SqlSetString(carManagementWork.CarAddInfo1);                                // 車輌追加情報１
                        //paraCarAddInfo2.Value = SqlDataMediator.SqlSetString(carManagementWork.CarAddInfo2);                                // 車輌追加情報２
                        paraCarNote.Value = SqlDataMediator.SqlSetString(carManagementWork.CarNote);                                        // 車輌備考
                        // --- ADD 2009/09/11 --------------<<<
                        // ADD 2013/03/22  -------------------->>>>>
                        paraDomesticForeignCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.DomesticForeignCode);                 // 国産/外車区分
                        paraHandleInfoCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.HandleInfoCode);                           // ハンドル位置情報
                        // ADD 2013/03/22  --------------------<<<<<     
                        // int[] → byte[] に変換
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        foreach (int item in carManagementWork.FullModelFixedNoAry)
                            ms.Write(BitConverter.GetBytes(item), 0, sizeof(int));
                        byte[] verbinary = ms.ToArray();
                        ms.Close();

                        paraFullModelFixedNoAry.Value = SqlDataMediator.SqlSetBinary(verbinary);                                            // フル型式固定番号配列
                        paraCategoryObjAry.Value = SqlDataMediator.SqlSetBinary(carManagementWork.CategoryObjAry);                          // 装備オブジェクト配列
                        // --- ADD 2010/04/27 -------------->>>
                        paraFreeSrchMdlFxdNoAry.Value = SqlDataMediator.SqlSetBinary(carManagementWork.FreeSrchMdlFxdNoAry);                                            // 自由検索型式固定番号配列
                        // --- ADD 2010/04/27 --------------<<<
                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(carManagementWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            carManagementList = al;

            return status;
        }
        // ADD 2012/08/29 Wakita --------------------<<<<<

        // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>>
        #region 設定ファイル取得
        /// <summary>
        /// 設定ファイル取得
        /// </summary>
        /// <param name="dbCommandTimeout">タイムアウト時間</param>
        /// <remarks>
        /// <br>Note         : 設定ファイル取得処理を行う</br>
        /// <br>Programmer   : 田建委</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private void GetXmlInfo(ref int dbCommandTimeout)
        {
            // 初期値設定
            string fileName = this.InitializeXmlSettings();

            if (fileName != string.Empty)
            {
                XmlReaderSettings settings = new XmlReaderSettings();

                try
                {
                    using (XmlReader reader = XmlReader.Create(fileName, settings))
                    {
                        while (reader.Read())
                        {
                            //タイムアウト時間を取得
                            if (reader.IsStartElement("DbCommandTimeout")) dbCommandTimeout = reader.ReadElementContentAsInt();
                        }
                    }
                }
                catch
                {
                    base.WriteErrorLog(null, "設定ファイル取得エラー");
                }
            }

        }
        #endregion // 設定ファイル取得

        #region XMLファイル操作
        /// <summary>
        /// XMLファイル名取得
        /// </summary>
        /// <returns>XMLファイル名</returns>
        /// <remarks>
        /// <br>Note         : XML情報取得処理を行う</br>
        /// <br>Programmer   : 田建委</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private string InitializeXmlSettings()
        {
            string homeDir = string.Empty;
            string path = string.Empty;

            try
            {
                // カレントディレクトリ取得
                homeDir = this.GetCurrentDirectory();

                // ディレクトリ情報にXMLファイル名を連結
                path = Path.Combine(homeDir, XML_FILE_NAME);

                // ファイルが存在しない場合は空白にする
                if (!File.Exists(path))
                {
                    path = string.Empty;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesSlipDB.InitializeXmlSettings:" + ex.Message);
            }
            return path;
        }
        #endregion //XMLファイル操作

        #region カレントフォルダ
        /// <summary>
        /// カレントフォルダ取得
        /// </summary>
        /// <returns>XMLファイル名</returns>
        /// <remarks>
        /// <br>Note         : カレントフォルダ処理を行う</br>
        /// <br>Programmer   : 田建委</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private string GetCurrentDirectory()
        {
            string defaultDir = string.Empty;
            string homeDir = string.Empty;

            // XML格納ディレクトリ取得
            try
            {
                // dll格納パスを初期ディレクトリとする
                defaultDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd(); // 末尾の「\」は常になし

                // レジストリ情報よりUSER_APのキー情報を取得
                RegistryKey keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                if (keyForUSERAP == null)
                {
                    keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Broadleaf\Service\Partsman\USER_AP");
                    if (keyForUSERAP == null)
                    {
                        // レジストリ情報を取得できない場合は初期ディレクトリ // 運用上ありえないケース
                        homeDir = defaultDir;
                    }
                    else
                    {
                        homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                    }
                }
                else
                {
                    homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                }

                // 取得ディレクトリが存在しない場合は初期ディレクトリを設定
                // 運用上ありえないケース
                if (!Directory.Exists(homeDir))
                {
                    homeDir = defaultDir;
                }
            }
            catch (Exception ex)
            {
                //USER_APのLOGフォルダにログ出力
                base.WriteErrorLog(ex, "SalesSlipDB.GetCurrentDirectory:" + ex.Message);
                if (!string.IsNullOrEmpty(defaultDir))
                {
                    homeDir = defaultDir;
                }
            }
            return homeDir;
        }
        #endregion // カレントフォルダ
        // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<

        # region [LogicalDelete]
        /// <summary>
        /// 車両管理マスタ情報を論理削除します。
        /// </summary>
        /// <param name="carManagementList">論理削除する車両管理マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : carManagementWork に格納されている車両管理マスタ情報を論理削除します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.06.02</br>
        public int LogicalDelete(ref object carManagementList)
        {
            return this.LogicalDelete(ref carManagementList, 0);
        }

        /// <summary>
        /// 車両管理マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="carManagementList">論理削除を解除する車両管理マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : carManagementWork に格納されている車両管理マスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.06.02</br>
        public int RevivalLogicalDelete(ref object carManagementList)
        {
            return this.LogicalDelete(ref carManagementList, 1);
        }

        /// <summary>
        /// 車両管理マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="carManagementList">論理削除を操作する車両管理マスタ情報</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : carManagementWork に格納されている車両管理マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.06.02</br>
        private int LogicalDelete(ref object carManagementList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = carManagementList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.LogicalDelete(ref paraList, procMode, sqlConnection, sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ロールバック
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
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
        /// 車両管理マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="carManagementList">論理削除を操作する車両管理マスタ情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : carManagementWork に格納されている車両管理マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.06.02</br>
        public int LogicalDelete(ref ArrayList carManagementList, int procMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref carManagementList, procMode, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// 車両管理マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="carManagementList">論理削除を操作する車両管理マスタ情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : carManagementWork に格納されている車両管理マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.06.02</br>
        /// <br>Update Note: 2013/01/11 黄興貴</br>
        /// <br>管理番号   : 10801804-00 2013/03/13配信分</br>
        /// <br>             Redmine#32256 車輌管理マスタに削除済みのデータが復活と完全削除操作できない障害の修正</br>
        private int LogicalDeleteProc(ref ArrayList carManagementList, int procMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (carManagementList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < carManagementList.Count; i++)
                    {
                        CarManagementWork carManagementWork = carManagementList[i] as CarManagementWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  CARM.UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,CARM.LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  CARMANAGEMENTRF AS CARM" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  CARM.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND CARM.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlText += "  AND CARM.CARMNGNORF = @FINDCARMNGNO" + Environment.NewLine;
                        sqlText += "  AND CARM.CARMNGCODERF = @FINDCARMNGCODE" + Environment.NewLine; // ADD 黄興貴 2013/01/11 for redmine 32256
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findCarMngNo = sqlCommand.Parameters.Add("@FINDCARMNGNO", SqlDbType.Int);
                        SqlParameter findCarMngCode = sqlCommand.Parameters.Add("@FINDCARMNGCODE", SqlDbType.NChar); // ADD 黄興貴 2013/01/11 for redmine 32256

                        // Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(carManagementWork.EnterpriseCode);
                        findCustomerCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CustomerCode);
                        findCarMngNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CarMngNo);
                        findCarMngCode.Value = SqlDataMediator.SqlSetString(carManagementWork.CarMngCode); // ADD 黄興貴 2013/01/11 for redmine 32256

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != carManagementWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // 現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  CARMANAGEMENTRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                            sqlText += "  AND CARMNGNORF = @FINDCARMNGNO" + Environment.NewLine;
                            sqlText += "  AND CARMNGCODERF = @FINDCARMNGCODE" + Environment.NewLine; // ADD 黄興貴 2013/01/11 for redmine 32256
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(carManagementWork.EnterpriseCode);
                            findCustomerCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CustomerCode);
                            findCarMngNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CarMngNo);
                            findCarMngCode.Value = SqlDataMediator.SqlSetString(carManagementWork.CarMngCode); // ADD 黄興貴 2013/01/11 for redmine 32256

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)carManagementWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        // 論理削除モードの場合
                        if (procMode == 0)
                        {
                            if (logicalDelCd == 3)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;       // 既に削除済みの場合正常
                                return status;
                            }
                            else if (logicalDelCd == 0) carManagementWork.LogicalDeleteCode = 1;  // 論理削除フラグをセット
                            else carManagementWork.LogicalDeleteCode = 3;                         // 完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                carManagementWork.LogicalDeleteCode = 0;                          // 論理削除フラグを解除
                            }
                            else
                            {
                                if (logicalDelCd == 0)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;   // 既に復活している場合はそのまま正常を戻す
                                }
                                else
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;  // 完全削除はデータなしを戻す
                                }

                                return status;
                            }
                        }

                        // Parameterオブジェクトの作成(更新用)
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定(更新用)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(carManagementWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(carManagementWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(carManagementWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(carManagementWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(carManagementWork);
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            carManagementList = al;

            return status;
        }
        # endregion

        # region [WriteAndLogicDelete]
        /// <summary>
        /// 車両管理マスタ情報の書込と論理削除処理。
        /// </summary>
        /// <param name="carManagementList">論理削除すると書込する車両管理マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : carManagementWork に格納されている車両管理マスタ情報を書込と論理削除します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public int WriteAndLogicDelete(ref object carManagementList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                CustomSerializeArrayList paraList = carManagementList as CustomSerializeArrayList;

                ArrayList updateDataList = paraList[0] as ArrayList;
                ArrayList logicDeleteDataList = paraList[1] as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                if (updateDataList.Count > 0)
                {
                    // 書込準備処理 (車両管理番号の採番)
                    status = this.WriteInitial(ref updateDataList, sqlConnection, sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 書込処理
                        status = this.Write(ref updateDataList, sqlConnection, sqlTransaction);
                    }
                }

                if (logicDeleteDataList.Count > 0)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 論理削除処理
                        status = this.LogicalDelete(ref logicDeleteDataList, 0, sqlConnection, sqlTransaction);
                    }
                }

            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ロールバック
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        # endregion

        # region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="carManagementWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.06.02</br>
        /// <br>Update Note: 2009/09/11 李占川 LDNS開発対応</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, CarManagementWork carManagementWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;;

            // 企業コード
            retstring += "  CARM.ENTERPRISECODERF = @FINDENTERPRISECODE"  + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(carManagementWork.EnterpriseCode);

            // 論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
                (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                (logicalMode == ConstantManagement.LogicalMode.GetData2)||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND CARM.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01)||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND CARM.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if(wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            // --- DEL 2009/09/11 ---------->>>>>
            // 車両管理番号
            //SqlParameter findCarMngNo = sqlCommand.Parameters.Add("@FINDCARMNGNO", SqlDbType.Int);
            //findCarMngNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CarMngNo);
            //--- DEL 2009/09/11 ----------<<<<<

            // --- ADD 2009/09/11 ---------->>>>>
            // 車輌管理コード
            //wkstring = "";
            if (carManagementWork.CarMngCode != string.Empty)
            {
                if (carManagementWork.CarMngCodeSearchDiv == 0)
                {
                    wkstring = "  AND CARM.CARMNGCODERF = @FINDCARMNGCODE" + Environment.NewLine;
                    retstring += wkstring;
                    SqlParameter findCarMngCode = sqlCommand.Parameters.Add("@FINDCARMNGCODE", SqlDbType.NChar);
                    findCarMngCode.Value = SqlDataMediator.SqlSetString(carManagementWork.CarMngCode);
                }
                else if (carManagementWork.CarMngCodeSearchDiv == 1)
                {
                    wkstring = "  AND CARM.CARMNGCODERF LIKE @FINDCARMNGCODE" + Environment.NewLine;
                    retstring += wkstring;
                    SqlParameter findCarMngCode = sqlCommand.Parameters.Add("@FINDCARMNGCODE", SqlDbType.NChar);
                    findCarMngCode.Value = SqlDataMediator.SqlSetString(carManagementWork.CarMngCode + "%");
                }
                else if (carManagementWork.CarMngCodeSearchDiv == 2)
                {
                    wkstring = "  AND CARM.CARMNGCODERF LIKE @FINDCARMNGCODE" + Environment.NewLine;
                    retstring += wkstring;
                    SqlParameter findCarMngCode = sqlCommand.Parameters.Add("@FINDCARMNGCODE", SqlDbType.NChar);
                    findCarMngCode.Value = SqlDataMediator.SqlSetString("%" + carManagementWork.CarMngCode + "%");
                }
                else
                {
                    wkstring = "  AND CARM.CARMNGCODERF LIKE @FINDCARMNGCODE" + Environment.NewLine;
                    retstring += wkstring;
                    SqlParameter findCarMngCode = sqlCommand.Parameters.Add("@FINDCARMNGCODE", SqlDbType.NChar);
                    findCarMngCode.Value = SqlDataMediator.SqlSetString("%" + carManagementWork.CarMngCode);
                }
            }

            // 得意先
            if (carManagementWork.CustomerCode != 0)
            {
                wkstring = "  AND CARM.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                retstring += wkstring;
                SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                findCustomerCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CustomerCode);
            }

            // 得意先開始
            if (carManagementWork.CustomerCodeSt != 0)
            {
                wkstring = "  AND CARM.CUSTOMERCODERF >= @FINDCUSTOMERCODEST" + Environment.NewLine;
                retstring += wkstring;
                SqlParameter findCustomerCodeSt = sqlCommand.Parameters.Add("@FINDCUSTOMERCODEST", SqlDbType.Int);
                findCustomerCodeSt.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CustomerCodeSt);
            }

            // 得意先終了
            if (carManagementWork.CustomerCodeEd != 0)
            {
                wkstring = "  AND CARM.CUSTOMERCODERF <= @FINDCUSTOMERCODEED" + Environment.NewLine;
                retstring += wkstring;
                SqlParameter findCustomerCodeEd = sqlCommand.Parameters.Add("@FINDCUSTOMERCODEED", SqlDbType.Int);
                findCustomerCodeEd.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CustomerCodeEd);
            }

            // 車輌備考
            if (!string.IsNullOrEmpty(carManagementWork.CarNote.Trim()))
            {
                if (carManagementWork.CarNoteSearchDiv == 0)
                {
                    // 完全一致の場合
                    wkstring = "  AND CARM.CARNOTERF = @FINDCARNOTE" + Environment.NewLine;
                    retstring += wkstring;
                    SqlParameter findCarNote = sqlCommand.Parameters.Add("@FINDCARNOTE", SqlDbType.NChar);
                    findCarNote.Value = SqlDataMediator.SqlSetString(carManagementWork.CarNote);
                }
                else if (carManagementWork.CarNoteSearchDiv == 1)
                {
                    // 前方一致の場合
                    wkstring = "  AND CARM.CARNOTERF LIKE @FINDCARNOTE" + Environment.NewLine;
                    retstring += wkstring;
                    SqlParameter findCarNote = sqlCommand.Parameters.Add("@FINDCARNOTE", SqlDbType.NChar);
                    findCarNote.Value = SqlDataMediator.SqlSetString(carManagementWork.CarNote + "%");
                }
                else if (carManagementWork.CarNoteSearchDiv == 2)
                {
                    // 含みの場合
                    wkstring = "  AND CARM.CARNOTERF LIKE @FINDCARNOTE" + Environment.NewLine;
                    retstring += wkstring;
                    SqlParameter findCarNote = sqlCommand.Parameters.Add("@FINDCARNOTE", SqlDbType.NChar);
                    findCarNote.Value = SqlDataMediator.SqlSetString("%" + carManagementWork.CarNote + "%");
                }
                else
                {
                    // 後方一致の場合
                    wkstring = "  AND CARM.CARNOTERF LIKE @FINDCARNOTE" + Environment.NewLine;
                    retstring += wkstring;
                    SqlParameter findCarNote = sqlCommand.Parameters.Add("@FINDCARNOTE", SqlDbType.NChar);
                    findCarNote.Value = SqlDataMediator.SqlSetString("%" + carManagementWork.CarNote);
                }
            }

            // 型式
            if (!string.IsNullOrEmpty(carManagementWork.KindModel.Trim()))
            {
                if (carManagementWork.KindModelSearchDiv == 0)
                {
                    // 完全一致の場合
                    wkstring = "  AND ISNULL(CARM.SERIESMODELRF, '') + '-' + ISNULL(CARM.CATEGORYSIGNMODELRF, '') = @FINDKINDMODEL" + Environment.NewLine;
                    retstring += wkstring;
                    SqlParameter findKindModel = sqlCommand.Parameters.Add("@FINDKINDMODEL", SqlDbType.NChar);
                    findKindModel.Value = SqlDataMediator.SqlSetString(carManagementWork.KindModel);
                }
                else if (carManagementWork.KindModelSearchDiv == 1)
                {
                    // 前方一致の場合
                    wkstring = "  AND ISNULL(CARM.SERIESMODELRF, '') + '-' + ISNULL(CARM.CATEGORYSIGNMODELRF, '') LIKE @FINDKINDMODEL" + Environment.NewLine;
                    retstring += wkstring;
                    SqlParameter findKindModel = sqlCommand.Parameters.Add("@FINDKINDMODEL", SqlDbType.NChar);
                    findKindModel.Value = SqlDataMediator.SqlSetString(carManagementWork.KindModel + "%");
                }
                else if (carManagementWork.KindModelSearchDiv == 2)
                {
                    // 含みの場合
                    wkstring = "  AND ISNULL(CARM.SERIESMODELRF, '') + '-' + ISNULL(CARM.CATEGORYSIGNMODELRF, '') LIKE @FINDKINDMODEL" + Environment.NewLine;
                    retstring += wkstring;
                    SqlParameter findKindModel = sqlCommand.Parameters.Add("@FINDKINDMODEL", SqlDbType.NChar);
                    findKindModel.Value = SqlDataMediator.SqlSetString("%" + carManagementWork.KindModel + "%");
                }
                else
                {

                    // 後方一致の場合
                    wkstring = "  AND ISNULL(CARM.SERIESMODELRF, '') + '-' + ISNULL(CARM.CATEGORYSIGNMODELRF, '') LIKE @FINDKINDMODEL" + Environment.NewLine;
                    retstring += wkstring;
                    SqlParameter findKindModel = sqlCommand.Parameters.Add("@FINDKINDMODEL", SqlDbType.NChar);
                    findKindModel.Value = SqlDataMediator.SqlSetString("%" + carManagementWork.KindModel);
                }
            }

            // --- ADD 2009/09/11 ----------<<<<<

            return retstring;
        }
        # endregion

        # region [Where文作成処理（ガイド用）]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="carMngGuideWork">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/11</br>
        private string MakeWhereStringForGuide(ref SqlCommand sqlCommand, CarMngGuideParamWork carMngGuideWork)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine; ;

            // 企業コード
            retstring += "  CARM.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(carMngGuideWork.EnterpriseCode);

            // 車輌管理マスタ．企業コード＝得意先マスタ．．企業コード
            retstring += "  AND CARM.ENTERPRISECODERF = CUST.ENTERPRISECODERF" + Environment.NewLine;

            // 車輌管理マスタ．論理削除区分＝有効データ
            retstring += "  AND CARM.LOGICALDELETECODERF = 0" + Environment.NewLine;

            // 得意先マスタ．論理削除区分＝有効データ
            retstring += "  AND CUST.LOGICALDELETECODERF = 0" + Environment.NewLine;

            // 車輌管理マスタ．得意先コード＝得意先マスタ．得意先コード
            retstring += "  AND CARM.CUSTOMERCODERF = CUST.CUSTOMERCODERF" + Environment.NewLine;

            // 得意先コード絞り込み有り
            if (carMngGuideWork.IsCheckCustomerCode == true)
            {
                wkstring = "  AND CARM.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                retstring += wkstring;
                SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                findCustomerCode.Value = SqlDataMediator.SqlSetInt32(carMngGuideWork.CustomerCode);
            }
            // 管理番号絞り込み有り
            if (carMngGuideWork.IsCheckCarMngCode == true)
            {
                if (carMngGuideWork.CheckCarMngCodeType == 0)
                {
                    // 完全一致の場合
                    wkstring = "  AND CARM.CARMNGCODERF = @FINDCARMNGCODE" + Environment.NewLine;
                    retstring += wkstring;
                    SqlParameter findCarMngCode = sqlCommand.Parameters.Add("@FINDCARMNGCODE", SqlDbType.NChar);
                    findCarMngCode.Value = SqlDataMediator.SqlSetString(carMngGuideWork.CarMngCode);
                }
                else if (carMngGuideWork.CheckCarMngCodeType == 1)
                {
                    // 前方一致の場合
                    wkstring = "  AND CARM.CARMNGCODERF LIKE @FINDCARMNGCODE" + Environment.NewLine;
                    retstring += wkstring;
                    SqlParameter findCarMngCode = sqlCommand.Parameters.Add("@FINDCARMNGCODE", SqlDbType.NChar);
                    findCarMngCode.Value = SqlDataMediator.SqlSetString(carMngGuideWork.CarMngCode + "%");
                }
                else if (carMngGuideWork.CheckCarMngCodeType == 2)
                {
                    // 含みの場合
                    wkstring = "  AND CARM.CARMNGCODERF LIKE @FINDCARMNGCODE" + Environment.NewLine;
                    retstring += wkstring;
                    SqlParameter findCarMngCode = sqlCommand.Parameters.Add("@FINDCARMNGCODE", SqlDbType.NChar);
                    findCarMngCode.Value = SqlDataMediator.SqlSetString("%" + carMngGuideWork.CarMngCode + "%");
                }
                else
                {
                    // 後方一致の場合
                    wkstring = "  AND CARM.CARMNGCODERF LIKE @FINDCARMNGCODE" + Environment.NewLine;
                    retstring += wkstring;
                    SqlParameter findCarMngCode = sqlCommand.Parameters.Add("@FINDCARMNGCODE", SqlDbType.NChar);
                    findCarMngCode.Value = SqlDataMediator.SqlSetString("%" + carMngGuideWork.CarMngCode);
                }
            }

            // 車輌管理区分チェック有り
            if (carMngGuideWork.IsCheckCarMngDivCd == true)
            {
                // 得意先マスタ.車輌管理区分≠「0:しない」のデータを取得する
                wkstring = "  AND CUST.CARMNGDIVCDRF != 0" + Environment.NewLine;
                retstring += wkstring;
            }

            return retstring;
        }
        # endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → CarManagementWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CarManagementWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.06.02</br>
        /// </remarks>
        private CarManagementWork CopyToCarManagementWorkFromReader(ref SqlDataReader myReader)
        {
            CarManagementWork carManagementWork = new CarManagementWork();

            this.CopyToCarManagementWorkFromReader(ref myReader, ref carManagementWork);

            return carManagementWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → CarManagementWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="carManagementWork">CarManagementWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.06.02</br>
        /// <br>Update Note: 2009/09/11 李占川 LDNS開発対応</br>
        /// <br>Update Note: 2010/04/27 gaoyh 自由検索型式固定番号配列を追加</br>
        /// <br>Update Note: 2011/04/06 曹文傑 車輌管理マスタにBinaly型式=nullのデータが存在する時、エラーが発生しないよう修正する為。</br>
        /// <br>Update Note: 2013/03/22 FSI高橋 文彰</br>
        /// <br>管理番号   : 10900269-00</br>
        /// <br>             SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
        /// </remarks>
        private void CopyToCarManagementWorkFromReader(ref SqlDataReader myReader, ref CarManagementWork carManagementWork)
        {
            if (myReader != null && carManagementWork != null)
            {
                # region クラスへ格納
                carManagementWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));               // 作成日時
                carManagementWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));               // 更新日時
                carManagementWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));                          // 企業コード
                carManagementWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));                            // GUID
                carManagementWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));                        // 更新従業員コード
                carManagementWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));                          // 更新アセンブリID1
                carManagementWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));                          // 更新アセンブリID2
                carManagementWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));                     // 論理削除区分
                carManagementWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));                               // 得意先コード
                carManagementWork.CarMngNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARMNGNORF"));                                       // 車両管理番号
                carManagementWork.CarMngCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARMNGCODERF"));                                  // 車輌管理コード
                carManagementWork.NumberPlate1Code = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE1CODERF"));                       // 陸運事務所番号
                carManagementWork.NumberPlate1Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE1NAMERF"));                      // 陸運事務局名称
                carManagementWork.NumberPlate2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE2RF"));                              // 車両登録番号（種別）
                carManagementWork.NumberPlate3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE3RF"));                              // 車両登録番号（カナ）
                carManagementWork.NumberPlate4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE4RF"));                               // 車両登録番号（プレート番号）
                carManagementWork.EntryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ENTRYDATERF"));                      // 登録年月日
                //carManagementWork.FirstEntryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("FIRSTENTRYDATERF"));              // 初年度
                carManagementWork.FirstEntryDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FIRSTENTRYDATERF"));                           // 初年度
                carManagementWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));                                     // メーカーコード
                carManagementWork.MakerFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERFULLNAMERF"));                            // メーカー全角名称
                carManagementWork.MakerHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERHALFNAMERF"));                            // メーカー半角名称
                carManagementWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));                                     // 車種コード
                carManagementWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));                               // 車種サブコード
                carManagementWork.ModelFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELFULLNAMERF"));                            // 車種全角名称
                carManagementWork.ModelHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELHALFNAMERF"));                            // 車種半角名称
                carManagementWork.SystematicCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SYSTEMATICCODERF"));                           // 系統コード
                carManagementWork.SystematicName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SYSTEMATICNAMERF"));                          // 系統名称
                carManagementWork.ProduceTypeOfYearCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRODUCETYPEOFYEARCDRF"));                 // 生産年式コード
                carManagementWork.ProduceTypeOfYearNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRODUCETYPEOFYEARNMRF"));                // 生産年式名称
                carManagementWork.StProduceTypeOfYear = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("STPRODUCETYPEOFYEARRF"));    // 開始生産年式
                carManagementWork.EdProduceTypeOfYear = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("EDPRODUCETYPEOFYEARRF"));    // 終了生産年式
                carManagementWork.DoorCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DOORCOUNTRF"));                                     // ドア数
                carManagementWork.BodyNameCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BODYNAMECODERF"));                               // ボディー名コード
                carManagementWork.BodyName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BODYNAMERF"));                                      // ボディー名称
                carManagementWork.ExhaustGasSign = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EXHAUSTGASSIGNRF"));                          // 排ガス記号
                carManagementWork.SeriesModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SERIESMODELRF"));                                // シリーズ型式
                carManagementWork.CategorySignModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATEGORYSIGNMODELRF"));                    // 型式（類別記号）
                carManagementWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));                                    // 型式（フル型）
                carManagementWork.ModelDesignationNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));                   // 型式指定番号
                carManagementWork.CategoryNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));                                   // 類別番号
                carManagementWork.FrameModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMEMODELRF"));                                  // 車台型式
                carManagementWork.FrameNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMENORF"));                                        // 車台番号
                carManagementWork.SearchFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEARCHFRAMENORF"));                             // 車台番号（検索用）
                carManagementWork.StProduceFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STPRODUCEFRAMENORF"));                       // 生産車台番号開始
                carManagementWork.EdProduceFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDPRODUCEFRAMENORF"));                       // 生産車台番号終了
                carManagementWork.EngineModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEMODELRF"));                                // 原動機型式（エンジン）
                carManagementWork.ModelGradeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELGRADENMRF"));                              // 型式グレード名称
                carManagementWork.EngineModelNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEMODELNMRF"));                            // エンジン型式名称
                carManagementWork.EngineDisplaceNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEDISPLACENMRF"));                      // 排気量名称
                carManagementWork.EDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EDIVNMRF"));                                          // E区分名称
                carManagementWork.TransmissionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRANSMISSIONNMRF"));                          // ミッション名称
                carManagementWork.ShiftNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHIFTNMRF"));                                        // シフト名称
                carManagementWork.WheelDriveMethodNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WHEELDRIVEMETHODNMRF"));                  // 駆動方式名称
                carManagementWork.AddiCarSpec1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPEC1RF"));                              // 追加諸元1
                carManagementWork.AddiCarSpec2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPEC2RF"));                              // 追加諸元2
                carManagementWork.AddiCarSpec3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPEC3RF"));                              // 追加諸元3
                carManagementWork.AddiCarSpec4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPEC4RF"));                              // 追加諸元4
                carManagementWork.AddiCarSpec5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPEC5RF"));                              // 追加諸元5
                carManagementWork.AddiCarSpec6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPEC6RF"));                              // 追加諸元6
                carManagementWork.AddiCarSpecTitle1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPECTITLE1RF"));                    // 追加諸元タイトル1
                carManagementWork.AddiCarSpecTitle2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPECTITLE2RF"));                    // 追加諸元タイトル2
                carManagementWork.AddiCarSpecTitle3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPECTITLE3RF"));                    // 追加諸元タイトル3
                carManagementWork.AddiCarSpecTitle4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPECTITLE4RF"));                    // 追加諸元タイトル4
                carManagementWork.AddiCarSpecTitle5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPECTITLE5RF"));                    // 追加諸元タイトル5
                carManagementWork.AddiCarSpecTitle6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPECTITLE6RF"));                    // 追加諸元タイトル6
                carManagementWork.RelevanceModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RELEVANCEMODELRF"));                          // 関連型式
                carManagementWork.SubCarNmCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBCARNMCDRF"));                                   // サブ車名コード
                carManagementWork.ModelGradeSname = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELGRADESNAMERF"));                        // 型式グレード略称
                carManagementWork.BlockIllustrationCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLOCKILLUSTRATIONCDRF"));                 // ブロックイラストコード
                carManagementWork.ThreeDIllustNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("THREEDILLUSTNORF"));                           // 3DイラストNo
                carManagementWork.PartsDataOfferFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSDATAOFFERFLAGRF"));                   // 部品データ提供フラグ
                carManagementWork.InspectMaturityDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INSPECTMATURITYDATERF"));  // 車検満期日
                carManagementWork.LTimeCiMatDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LTIMECIMATDATERF"));            // 前回車検満期日
                carManagementWork.CarInspectYear = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARINSPECTYEARRF"));                           // 車検期間
                carManagementWork.Mileage = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MILEAGERF"));                                         // 車両走行距離
                carManagementWork.CarNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARNORF"));                                            // 号車
                carManagementWork.ColorCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORCODERF"));                                    // カラーコード
                carManagementWork.ColorName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORNAME1RF"));                                  // カラー名称1
                carManagementWork.TrimCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMCODERF"));                                      // トリムコード
                carManagementWork.TrimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMNAMERF"));                                      // トリム名称
                // ADD 2013/03/22  -------------------->>>>>
                carManagementWork.DomesticForeignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DOMESTICFOREIGNCODERF"));                // 国産/外車区分
                carManagementWork.HandleInfoCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("HANDLEINFOCDRF"));                            // ハンドル位置情報
                // ADD 2013/03/22  --------------------<<<<< 
                byte[] varbinary = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("FULLMODELFIXEDNOARYRF"));                                     // フル型式固定番号配列
                // --- ADD 2011/04/06---------->>>>>
                if (varbinary == null)
                {
                    varbinary = new byte[0];
                }
                // --- ADD 2011/04/06----------<<<<<
                carManagementWork.FullModelFixedNoAry = new int[(int)varbinary.Length / sizeof(int)];
                
                for (int idx = 0; idx < carManagementWork.FullModelFixedNoAry.Length; idx++)
                {
                    carManagementWork.FullModelFixedNoAry[idx] = BitConverter.ToInt32(varbinary, idx * sizeof(int));
                }

                carManagementWork.CategoryObjAry = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("CATEGORYOBJARYRF"));                          // 装備オブジェクト配列
                // --- ADD 2011/04/06---------->>>>>
                if (carManagementWork.CategoryObjAry == null)
                {
                    carManagementWork.CategoryObjAry = new byte[0];
                }
                // --- ADD 2011/04/06----------<<<<<
                // --- ADD 2009/09/11 ---------->>>>>
                carManagementWork.CarNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARNOTERF"));                                         // 車輌備考
                carManagementWork.CarAddInfo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARADDINFO1RF"));                                 // 車輌追加情報１
                carManagementWork.CarAddInfo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARADDINFO2RF"));                                 // 車輌追加情報２
                // --- ADD 2009/09/11 ----------<<<<<
                // --- ADD 2010/04/27 ---------->>>>>
                carManagementWork.FreeSrchMdlFxdNoAry = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("FREESRCHMDLFXDNOARYRF"));
                // --- ADD 2010/04/27 ----------<<<<<
                // --- ADD 2011/04/06---------->>>>>
                if ( carManagementWork.FreeSrchMdlFxdNoAry == null )
                {
                    carManagementWork.FreeSrchMdlFxdNoAry = new byte[0];
                }
                // --- ADD 2011/04/06----------<<<<<
                # endregion
            }
        }
        # endregion
    }
}

//**************************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　伝票番号変換リモートオブジェクト
// プログラム概要   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2018 Broadleaf Co.,Ltd.
//=====================================================================================//
// 履歴
//-------------------------------------------------------------------------------------//
// 管理番号  11470153-00 作成担当 : 倉内
// 修 正 日  2018/09/07  修正内容 : 新規作成
//-------------------------------------------------------------------------------------//
// 管理番号  11470153-00 作成担当 : 倉内
// 修 正 日  2018/09/28  修正内容 : リモートのタイムアウト時間の設定
//-------------------------------------------------------------------------------------//
// 管理番号  11470153-00 作成担当 : 井上
// 修 正 日  2018/10/01  修正内容 : 支払伝票設定マスタの追加他
//-------------------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Resources;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 伝票番号変換リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       :伝票番号変換の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30175 倉内</br>
    /// <br>Date       : 2018/09/11</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class SlpNoConvertDB : RemoteWithAppLockDB,ISlipNoConvertDB
    {

        #region -- Member --
        /// <summary>タイムアウトの値を表す定数：36000</summary>
        private readonly int DB_TIME_OUT = 36000;
        /// <summary>タイムアウトの値を表す定数：3600</summary>
        private readonly int DB_TIME_OUT2 = 3600;　　　　　　　//2018/09/28　倉内追加
        /// <summary>伝票番号変換対象ファイルに不正データが有ることを示す定数：997</summary>
        private readonly int ILLEGAL_DATA = 997;
        /// <summary>伝票番号変換対象ファイルにデータが無いことを示す定数：998</summary>
        private readonly int NO_DATA = 998;
        /// <summary>伝票番号変換対象ファイルが存在しないことを示す定数：999</summary>
        private readonly int NO_FILE = 999;
        
        #endregion

        #region -- Constructor --

        /// <summary>
        /// 拠点コード変換DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/11</br>
        /// </remarks>
        public SlpNoConvertDB()
        {
        }
        
        #endregion

        #region -- Public Method -- 

        /// <summary>
        /// 伝票番号変換対象テーブルリスト取得処理
        /// </summary>
        /// <param name="secDiv">拠点区分（0：全社、1：拠点）</param>
        /// <param name="targetTableList">コード変換対象テーブルリスト</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : 伝票番号変換対象のテーブルのリストを取得します。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/10</br>
        /// </remarks>
        public int GetTargetTableList(int secDiv, ref object targetTableMap)
        {
            // 処理ステータスを初期化します。
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                // XMLから更新対象のリストを取得します。
                if (secDiv == 0)
                {
                    status = this.GetTargetTableFromWholeCompanyXml(ref targetTableMap);
                }
                else
                {
                    status = this.GetTargetTableFromBaseCompanyXml(ref targetTableMap);
                }
            }
            catch (Exception ex)
            {
                string errMsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errMsg, status);
            }

            return status;
        }

        /// <summary>
        /// 伝票番号変換前チェック処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="slipNoCnvPrm">変更データ</param>
        /// <param name="check">チェック結果（True（データなし）/false(データあり))</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : 伝票番号変換前チェック処理を行い。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/10</br>
        /// </remarks>
        public int CheckConvertSlipNo(string enterpriseCode,object slipNoCnvPrm,ref bool check)
        {
            // 処理ステータスを初期化します。
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //変更データの変数
            SlipNoConvertPrmInfoList prmWk = slipNoCnvPrm as SlipNoConvertPrmInfoList;
            check = false;

            //変換処理の開始
            try
            {
                // DBと接続を行いチェックをします
                using (SqlConnection sqlCon = this.CreateConnection(true))
                {
                    status = this.CheckConvertSlipNoProc(enterpriseCode, prmWk,ref check, sqlCon);
                }

            }
            catch (Exception ex)
            {
                string errMsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errMsg, status);
            }

            return status;
        }

        /// <summary>
        /// 伝票番号変換処理
        /// </summary>
        /// <param name="enterprise">企業コード</param>
        /// <param name="slipNoCnvPrm">変更データ</param>
        /// <param name="numberOfTransactions">処理件数を格納した変数</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : 伝票番号変換処理を行い。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/10</br>
        /// </remarks>
        public int ConvertSlipNo(string enterprise,object slipNoCnvPrm, ref long numberOfTransactions)
        {
            // 処理ステータスを初期化します。
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // SqlConnection変数
            SqlConnection sqlCon = null;
            // SqlTrancation変数
            SqlTransaction tran = null;
            //検索条件
            SlipNoConvertPrmInfoList slipNoCnv = slipNoCnvPrm as SlipNoConvertPrmInfoList;

            //処理件数
            numberOfTransactions = 0;

            //変換処理の開始
            try
            {
                // DBと接続を行います
                sqlCon = this.CreateConnection(true);
                // トランザクションを開始します
                tran = this.CreateTransaction(ref sqlCon);
                //コンバートを実行します
                status = this.ConvertSlipNoPrc(enterprise, slipNoCnv, sqlCon, tran, ref numberOfTransactions);

            }
            catch (Exception ex)
            {
                string errMsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errMsg, status);
            }
            finally
            {
                if (tran != null)
                {
                    tran.Dispose();
                }

                if (sqlCon != null)
                {
                    sqlCon.Close();
                    sqlCon.Dispose();
                }
            }

            return status;
        }

        #endregion

        #region -- Private Method --

        #region -- 伝票番号変換対象テーブルリスト取得関連 --

        /// <summary>
        /// 対象テーブル情報WholeCompanyXml読み取り処理
        /// </summary
        /// <param name="targetTableList">更新対象テーブル情報を格納する変数</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : XMLから変換対象となるテーブル情報を読み取ります。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/10</br>
        /// </remarks>
        private int GetTargetTableFromWholeCompanyXml(ref object targetTableList)
        {
            // 処理ステータスを初期化します
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // XMLからデータを読み取ります。
            IList<SlpNoTargetTableList> trgTblMap = targetTableList as IList<SlpNoTargetTableList>;

            using (MemoryStream fs = XMLWholeCompanyList.ms())
            {
                // XMLをデシリアライズします。
                XmlSerializer serializer = new XmlSerializer(typeof(ArrayOfWholeCompanyList));
                ArrayOfWholeCompanyList arryCnvList = (ArrayOfWholeCompanyList)serializer.Deserialize(fs);
                trgTblMap = new List<SlpNoTargetTableList>();


                //リストを作成する
                foreach (WholeCompanyCvtList wholeList in arryCnvList.WoleCompanyCvtList)
                {
                    //Key(番号コード（処理番号）をセットする
                    int TargetNo = 0;
                    if (wholeList.TARGETNO.ToString() == "")
                    {
                        // 処理番号が0の場合は異常データである為、処理を打ち切り
                        return this.ILLEGAL_DATA;
                    }
                    else
                    {
                        TargetNo = Convert.ToInt32(wholeList.TARGETNO);
                    }

                    SlpNoTargetTableList work = new SlpNoTargetTableList();
                    
                    //番号コード(処理対象番号)
                    work.TargetNo = Convert.ToInt32(wholeList.TARGETNO); ;
                    //テーブルID(物理名)
                    work.TargetTable = wholeList.TABLE.Trim().ToUpper(); ;
                    //テーブル名(論理名)
                    work.TargetTableName = wholeList.TABLENAME.Trim();
                    //カラム名(物理名)
                    work.TargetColum = wholeList.TARGETCOLUM.Trim().ToUpper();
                    //カラム名(論理名)
                    work.TargetColumName = wholeList.TARGETCOLUMNNAME.Trim();
                    //受注ステータスID
                    work.TargetAcptStatusId = wholeList.ACPTSTATUSID.Trim().ToUpper();
                    //受注ステータスコード
                  //if (wholeList.ACPTSTATUS.ToString() != "")    2018/10/01
                    if (work.TargetAcptStatusId != "")     //2018/10/01
                    {
                        work.TargetAcptStatus = Convert.ToInt32(wholeList.ACPTSTATUS);
                    }
                    
                    trgTblMap.Add(work);

                }

                if (trgTblMap.Count == 0)
                {
                    // trgTblMapが0件の場合は、変換対象のテーブルが無い為、ステータスをNO_DATAにします。
                    status = this.NO_DATA;
                }
                else
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    targetTableList = trgTblMap;
                }
            }


            return status;
        }


        /// <summary>
        /// 対象テーブル情報BaseCompanyXml読み取り処理
        /// </summary
        /// <param name="targetTableList">更新対象テーブル情報を格納する変数</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : XMLから変換対象となるテーブル情報を読み取ります。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/10</br>
        /// </remarks>
        private int GetTargetTableFromBaseCompanyXml(ref object targetTableList)
        {
            // 処理ステータスを初期化します
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // XMLからデータを読み取ります。
            IList<SlpNoTargetTableList> trgTblMap = targetTableList as IList<SlpNoTargetTableList>;

            using (MemoryStream fs = XMLBaseCompanyList.ms())
            {
                // XMLをデシリアライズします。
                XmlSerializer serializer = new XmlSerializer(typeof(ArrayOfBaseCompanyList));
                ArrayOfBaseCompanyList arryCnvList = (ArrayOfBaseCompanyList)serializer.Deserialize(fs);
                trgTblMap = new List<SlpNoTargetTableList>();

                //リストを作成する
                foreach (BaseCompanyCvtList baceList in arryCnvList.BaseCompanyCvtList)
                {
                    //Key(番号コード（処理番号）をセットする
                    int TargetNo = 0;
                    if (baceList.TARGETNO.ToString() == "")
                    {
                        // 処理番号が0の場合は異常データである為、処理を打ち切り
                        return this.ILLEGAL_DATA;
                    }
                    else
                    {
                        TargetNo = Convert.ToInt32(baceList.TARGETNO);
                    }

                    SlpNoTargetTableList work = new SlpNoTargetTableList();

                    //番号コード(処理対象番号)
                    work.TargetNo = Convert.ToInt32(baceList.TARGETNO);;
                    //テーブルID(物理名)
                    work.TargetTable = baceList.TABLE.Trim().ToUpper(); ;
                    //テーブル名(論理名)
                    work.TargetTableName = baceList.TABLENAME.Trim();
                    //カラム名(物理名)
                    work.TargetColum = baceList.TARGETCOLUM.Trim().ToUpper();
                    //カラム名(論理名)
                    work.TargetColumName = baceList.TARGETCOLUMNAME.Trim();
                    //受注ステータスID
                    work.TargetAcptStatusId = baceList.ACPTSTATUSID.Trim().ToUpper();
                    //受注ステータスコード
           //       if (baceList.ACPTSTATUS.ToString() != "")        2018/10/01
                    if ( work.TargetAcptStatusId != "" )           //2018/10/01
                    {
                        work.TargetAcptStatus = Convert.ToInt32(baceList.ACPTSTATUS);
                    }

                    trgTblMap.Add(work);

                }

                if (trgTblMap.Count == 0)
                {
                    // trgTblMapが0件の場合は、変換対象のテーブルが無い為、ステータスをNO_DATAにします。
                    status = this.NO_DATA;
                }
                else
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    targetTableList = trgTblMap;
                }
            }


            return status;
        }

#endregion


        #region --伝票番号変換前チェック処理関連--
        /// <summary>
        /// 伝票番号変換前チェック処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="prmWk">検索条件</param>
        /// <param name="check">チェック結果（True（データなし）/false(データあり))</param>
        /// <param name="sqlCon">DB接続情報</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : 伝票番号変換前チェック処理を行い。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/10</br>
        /// </remarks>
        private int CheckConvertSlipNoProc(string enterpriseCode,SlipNoConvertPrmInfoList prmWk, ref bool check,SqlConnection sqlCon)
        {
            // 処理ステータスを初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                // 検索用のSQLを生成し、検索を行います
                using (SqlCommand cmd = new SqlCommand())
                {
                    // 接続情報を設定
                    cmd.Connection = sqlCon;
                    // クエリを設定
                    cmd.CommandText = this.CheckSlipSql(enterpriseCode,prmWk, cmd);
                    //タイムアウトの設定
                    cmd.CommandTimeout = this.DB_TIME_OUT2;　//------2018/09/28 -倉内-Add

                    // クエリを実行
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            //結果をセットする
                            long count = (int)SqlDataMediator.SqlSetInt32(rd.GetInt32(0));

                            if (count != 0)
                            {
                                check = false;
                            }
                            else
                            {
                                check = true;
                            }
                           
                        }
                        
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

            }
            catch (SqlException sqle)
            {
                string errMsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(sqle, errMsg, sqle.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SlpNoConvertDB.CheckConvertSlipNoProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;

        }

        /// <summary>
        /// 伝票番号変換前チェックSQL作成処理
        /// </summary>
        /// <param name="prmWk">検索条件</param>
        /// <param name="cmd">SqlCommandオブジェクト</param>
        /// <returns>SQL文</returns>
        /// <remarks>
        /// <br>Note       : 画面で指定した条件を元に検索用のSQL文を生成します。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/14</br>
        /// </remarks>
        private string CheckSlipSql(string enterpriseCode, SlipNoConvertPrmInfoList prmWk, SqlCommand cmd)
        {
            //SQL文の生成
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT count(*) FROM " + prmWk.Table   //テーブルID  
            + " WHERE "
            + "ENTERPRISECODERF = '" + enterpriseCode         //企業コード
            + "' AND ");

            //if(prmWk.AcptStatus != 0 & prmWk.AcptStatusId !="") 　2018/10/01  仕入データは0:仕入
            if ( prmWk.AcptStatusId != "")                        //2018/10/01 
            {
                sb.Append(prmWk.AcptStatusId + " = " + prmWk.AcptStatus + " AND ");   //受注ステータスID、受注ステータス
            }

            //検索開始（設定開始番号+増減値）
            Int64 stprm = Convert.ToInt64(prmWk.SettingStartNo) + Convert.ToInt64(prmWk.NoIncDecWidth);
            //検索終了（番号現在地+増減値）
            Int64 edprm = Convert.ToInt64(prmWk.NoPresentVal) + Convert.ToInt64(prmWk.NoIncDecWidth);
            sb.Append(prmWk.Colum + " >= " + stprm  //項目ID、設定開始番号+増減値
                 + " AND "
                 + prmWk.Colum + " <= " + edprm);     //項目ID、番号現在値+増減値

            return sb.ToString();
        }

        #endregion
       

        #region -- 伝票番号変換処理関連 --

        /// <summary>
        /// 伝票番号変換処理
        /// </summary>
        /// <param name="enterprise">企業コード</param>
        /// <param name="slipNoCnvPrm">変換条件</param>
        /// <param name="sqlCon">SqlConnectionオブジェクト</param>
        /// <param name="tran">SqlTransactionオブジェクト</param>
        /// <param name="numberOfTransactions">処理件数を格納した変数</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : 伝票番号変換処理を行います。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/10</br>
        /// </remarks>
        private int ConvertSlipNoPrc(string enterprise, SlipNoConvertPrmInfoList slipNoCnvPrm, SqlConnection sqlCon, SqlTransaction tran, ref long numberOfTransactions)
        {
            // ステータスを初期化します
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                //更新処理を行います
                using(SqlCommand cmd = new SqlCommand(String.Empty,sqlCon,tran))
                {
                    //タイムアウトの設定
                    cmd.CommandTimeout = this.DB_TIME_OUT;
                    //SQlを生成して実行します
                    cmd.CommandText = this.ConvertSlipSql(enterprise, slipNoCnvPrm,cmd);
                    long count = cmd.ExecuteNonQuery();
                    numberOfTransactions = count;
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                // 基底クラスに例外を渡して処理をしてもらいます
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SectionConvertDB ConvertProc Exception" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            }
            finally
            {
                // 処理が成功した場合はコミット、失敗した場合はロールバックを実施します。
                if (status == 0)
                {
                    tran.Commit();
                }
                else
                {
                    tran.Rollback();
                }
            }

            return status;
        }

        /// <summary>
        /// 伝票番号変換処理　SQL作成処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="prmWork">変換条件のリスト</param>
        /// <param name="cmd">SqlCommandオブジェクト</param>
        /// <returns>コード変換用SQL</returns>
        /// <remarks>
        /// <br>Note       : 画面で指定した条件を元に検索用のSQL文を生成します。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/10</br>
        /// </remarks>
        private string ConvertSlipSql(string enterpriseCode, SlipNoConvertPrmInfoList prmWork, SqlCommand cmd)
        {
            //SQL文の生成
            StringBuilder sb = new StringBuilder();

            sb.Append("UPDATE " + prmWork.Table  //テーブルID
            + " SET "
            + prmWork.Colum + " = " + prmWork.Colum + " + " + prmWork.NoIncDecWidth  //項目ID、増減値
            + " WHERE "
            + "ENTERPRISECODERF = '" + enterpriseCode  //企業コード
            + "' AND ");

//          if (prmWork.AcptStatusId != "" && prmWork.AcptStatus != 0)  //受注ステータスID、受注ステータス  2018/10/01 仕入データは0:仕入
            if (prmWork.AcptStatusId != "" )                            //受注ステータスID　　　　          2018/10/01  
            {
                sb.Append(prmWork.AcptStatusId + " = " + prmWork.AcptStatus + " AND ");
            }

            sb.Append( prmWork.Colum + " >= " + prmWork.SettingStartNo + " AND "  //設定開始番号
                + prmWork.Colum + " <= " + prmWork.NoPresentVal + " AND "         //番号現在値
                + prmWork.Colum + " != 0"); //項目ID

            return sb.ToString();
        }


        #endregion

      
        #endregion
    }
}

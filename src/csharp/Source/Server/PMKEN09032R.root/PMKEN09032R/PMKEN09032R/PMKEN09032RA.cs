//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   優良設定マスタ（ユーザー登録分）DBリモートオブジェクト
//                  :   PMKEN09032R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   20081 疋田 勇人
// Date             :   2008.06.11
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
// 管理番号  11070266-00 作成担当 : 30757 佐々木　貴英 							
// 修 正 日  2015/02/24  修正内容 : SCM高速化 Ｃ向け種別対応
//                                  ①追加項目の取得と更新
//                                    ・優良設定詳細名称２(工場向け)
//                                    ・優良設定詳細名称２(カーオーナー向け)
//----------------------------------------------------------------------
// 管理番号  11770032-00 作成担当 : 30809 佐々木 亘
// 修 正 日  2021/03/25  修正内容 : 山形部品障害対応（先行配信）
//                                  ①オブジェクト参照エラー対応
//                                    ・負荷軽減のためREADUNCOMMITTED追加
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
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 優良設定マスタ（ユーザー登録分）DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 優良設定マスタ（ユーザー登録分）の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2008.06.11</br>
    /// <br></br>
    /// <br>Update Note: 商品管理情報マスタの削除処理追加</br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2008.10.31</br>
    /// <br></br>
    /// <br>Update Note: 商品管理情報マスタでパタン「拠点+中分類＋メーカー＋BLコード」の追加に伴う削除処理の改修</br>
    /// <br>Programmer : 袁磊 redmine#32367</br>
    /// <br>Date       : 2012/11/23</br>
    /// <br></br>
    /// <br>Update Note: 11070266-00　SCM高速化 Ｃ向け種別対応 </br>
    /// <br>Programmer : 30757 佐々木 貴英</br>
    /// <br>Date       : 2015/02/24</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class PrmSettingUDB : RemoteWithAppLockDB, IPrmSettingUDB, IGetSyncdataList
    {
        /// <summary>
        /// 優良設定マスタ（ユーザー登録分）DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        /// </remarks>
        public PrmSettingUDB() : base("PMKEN09034D", "Broadleaf.Application.Remoting.ParamData.PrmSettingUWork", "PrmSettingURF")
        {

        }

        # region [Read]
        /// <summary>
        /// 単一の優良設定マスタ（ユーザー登録分）情報を取得します。
        /// </summary>
        /// <param name="prmSettingUObj">PrmSettingUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 優良設定マスタ（ユーザー登録分）のキー値が一致する優良設定マスタ（ユーザー登録分）情報を取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        public int Read(ref object prmSettingUObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                PrmSettingUWork prmSettingUWork = prmSettingUObj as PrmSettingUWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref prmSettingUWork, readMode, ref sqlConnection, ref sqlTransaction);
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
        /// 単一の優良設定マスタ（ユーザー登録分）情報を取得します。
        /// </summary>
        /// <param name="prmSettingUWork">PrmSettingUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 優良設定マスタ（ユーザー登録分）のキー値が一致する優良設定マスタ（ユーザー登録分）情報を取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        public int Read(ref PrmSettingUWork prmSettingUWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref prmSettingUWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 単一の優良設定マスタ（ユーザー登録分）情報を取得します。
        /// </summary>
        /// <param name="prmSettingUWork">PrmSettingUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 優良設定マスタ（ユーザー登録分）のキー値が一致する優良設定マスタ（ユーザー登録分）情報を取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        /// <br></br>
        /// <br>Update Note: 11070266-00　SCM高速化 Ｃ向け種別対応 </br>
        /// <br>             取得項目追加（優良設定詳細名称２(工場向け)、優良設定詳細名称２(カーオーナー向け)）</br>
        /// <br>Programmer : 30757 佐々木 貴英</br>
        /// <br>Date       : 2015/02/24</br>
        /// <br></br>
        /// </remarks>
        private int ReadProc(ref PrmSettingUWork prmSettingUWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT文]
                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,GOODSMGROUPRF" + Environment.NewLine;
                sqlText += "    ,TBSPARTSCODERF" + Environment.NewLine;
                sqlText += "    ,TBSPARTSCDDERIVEDNORF" + Environment.NewLine;
                sqlText += "    ,MAKERDISPORDERRF" + Environment.NewLine;
                sqlText += "    ,PARTSMAKERCDRF" + Environment.NewLine;
                sqlText += "    ,PRIMEDISPORDERRF" + Environment.NewLine;
                sqlText += "    ,PRMSETDTLNO1RF" + Environment.NewLine;
                sqlText += "    ,PRMSETDTLNAME1RF" + Environment.NewLine;
                sqlText += "    ,PRMSETDTLNO2RF" + Environment.NewLine;
                sqlText += "    ,PRMSETDTLNAME2RF" + Environment.NewLine;
                sqlText += "    ,PRIMEDISPLAYCODERF" + Environment.NewLine;
                //---ADD　30757 佐々木　貴英　2015/02/24 11070266-00　SCM高速化 Ｃ向け種別対応 ---------------->>>>>
                sqlText += "    ,PRMSETDTLNAME2FORFACRF" + Environment.NewLine;
                sqlText += "    ,PRMSETDTLNAME2FORCOWRF" + Environment.NewLine;
                //---ADD　30757 佐々木　貴英　2015/02/24 11070266-00　SCM高速化 Ｃ向け種別対応 ----------------<<<<<
                sqlText += " FROM PRMSETTINGURF" + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine; 
                sqlText += "    AND GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                sqlText += "    AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                sqlText += "    AND PARTSMAKERCDRF=@FINDPARTSMAKERCD" + Environment.NewLine;
                sqlText += "    AND PRMSETDTLNO1RF=@FINDPRMSETDTLNO1" + Environment.NewLine;
                sqlText += "    AND PRMSETDTLNO2RF=@FINDPRMSETDTLNO2" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                // Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                SqlParameter findParaTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int);
                SqlParameter findParaPartsMakerCd = sqlCommand.Parameters.Add("@FINDPARTSMAKERCD", SqlDbType.Int);
                SqlParameter findParaPrmSetDtlNo1 = sqlCommand.Parameters.Add("@FINDPRMSETDTLNO1", SqlDbType.Int);
                SqlParameter findParaPrmSetDtlNo2 = sqlCommand.Parameters.Add("@FINDPRMSETDTLNO2", SqlDbType.Int);                

                // Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.EnterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.SectionCode);
                findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.GoodsMGroup);
                findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.TbsPartsCode);
                findParaPartsMakerCd.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PartsMakerCd);
                findParaPrmSetDtlNo1.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo1);
                findParaPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo2);

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToPrmSettingUWorkFromReader(ref myReader, ref prmSettingUWork);
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
        /// 優良設定マスタ（ユーザー登録分）情報を物理削除します
        /// </summary>
        /// <param name="prmSettingUList">物理削除する優良設定マスタ（ユーザー登録分）情報を含む CustomSerializeArrayList</param>
        /// <param name="goodsMngList">商品管理情報 ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 優良設定マスタ（ユーザー登録分）のキー値が一致する優良設定マスタ（ユーザー登録分）情報を物理削除します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        //public int Delete(object prmSettingUList) // DEL 2008.10.31
        public int Delete(object prmSettingUList, object goodsMngList) // ADD 2008.10.31
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = prmSettingUList as ArrayList;
                ArrayList paraGoodsMngList = goodsMngList as ArrayList; // ADD 2008.10.31

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.Delete(paraList, ref sqlConnection, ref sqlTransaction);

                // ADD 2008.10.31 >>>
                // 商品管理情報削除
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    GoodsMngDB goodsMngDB = new GoodsMngDB();
                    ArrayList wkGoodsMngList = new ArrayList();
                    // 優良設定マスタのパラメータList内に企業・拠点・BLCD・中分類・メーカーが同一のレコードが、
                    // 渡される可能性があるため、表示区分:0以外を優先的に整理する。(整理しなければ、商品管理情報マスタの登録更新でエラーが発生)
                    ArrayList workparaList = new ArrayList();
                    Boolean WriteFlg = false;
                    for (int k = 0; k < paraList.Count; k++)
                    {
                        if (workparaList.Count == 0)
                        {
                            workparaList.Add(paraList[k]);
                        }
                        else
                        {
                            WriteFlg = true;
                            for (int l = 0; l < workparaList.Count; l++)
                            {
                                if ((((PrmSettingUWork)paraList[k]).EnterpriseCode.Trim() == ((PrmSettingUWork)workparaList[l]).EnterpriseCode.Trim()) &&
                                    (((PrmSettingUWork)paraList[k]).SectionCode.Trim() == ((PrmSettingUWork)workparaList[l]).SectionCode.Trim()) &&
                                    (((PrmSettingUWork)paraList[k]).TbsPartsCode == ((PrmSettingUWork)workparaList[l]).TbsPartsCode) &&
                                    (((PrmSettingUWork)paraList[k]).GoodsMGroup == ((PrmSettingUWork)workparaList[l]).GoodsMGroup) &&
                                    (((PrmSettingUWork)paraList[k]).PartsMakerCd == ((PrmSettingUWork)workparaList[l]).PartsMakerCd))
                                {
                                    WriteFlg = false;
                                }
                            }
                            if (WriteFlg == true)
                            {
                                workparaList.Add(paraList[k]);
                            }
                        }
                    }

                    for (int i = 0; i < workparaList.Count; i++)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            wkGoodsMngList.Clear();
                            for (int j = 0; j < paraGoodsMngList.Count; j++)
                            {
                                if ((((PrmSettingUWork)workparaList[i]).EnterpriseCode.Trim() == ((GoodsMngWork)paraGoodsMngList[j]).EnterpriseCode.Trim()) &&
                                     (((PrmSettingUWork)workparaList[i]).SectionCode.Trim() == ((GoodsMngWork)paraGoodsMngList[j]).SectionCode.Trim()) &&
                                     (((PrmSettingUWork)workparaList[i]).TbsPartsCode == ((GoodsMngWork)paraGoodsMngList[j]).BLGoodsCode) &&
                                     (((PrmSettingUWork)workparaList[i]).GoodsMGroup == ((GoodsMngWork)paraGoodsMngList[j]).GoodsMGroup) &&
                                     (((PrmSettingUWork)workparaList[i]).PartsMakerCd == ((GoodsMngWork)paraGoodsMngList[j]).GoodsMakerCd))
                                {
                                    wkGoodsMngList.Add(paraGoodsMngList[j]);
                                    break;
                                }
                            }
                            if (wkGoodsMngList.Count > 0)
                            {
                                status = goodsMngDB.DeleteGoodsMngProc(wkGoodsMngList, ref sqlConnection, ref sqlTransaction);
                            }
                        }
                    }

                }
                // ADD 2008.10.31 <<<

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
        /// 優良設定マスタ（ユーザー登録分）情報を物理削除します
        /// </summary>
        /// <param name="prmSettingUList">優良設定マスタ（ユーザー登録分）情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PrmSettingUList に格納されている優良設定マスタ（ユーザー登録分）情報を物理削除します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        public int Delete(ArrayList prmSettingUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(prmSettingUList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 優良設定マスタ（ユーザー登録分）情報を物理削除します
        /// </summary>
        /// <param name="prmSettingUList">優良設定マスタ（ユーザー登録分）情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PrmSettingUList に格納されている優良設定マスタ（ユーザー登録分）情報を物理削除します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        private int DeleteProc(ArrayList prmSettingUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (prmSettingUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < prmSettingUList.Count; i++)
                    {
                        PrmSettingUWork prmSettingUWork = prmSettingUList[i] as PrmSettingUWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " FROM PRMSETTINGURF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine; 
                        sqlText += "    AND GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                        sqlText += "    AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                        sqlText += "    AND PARTSMAKERCDRF=@FINDPARTSMAKERCD" + Environment.NewLine;
                        sqlText += "    AND PRMSETDTLNO1RF=@FINDPRMSETDTLNO1" + Environment.NewLine;
                        sqlText += "    AND PRMSETDTLNO2RF=@FINDPRMSETDTLNO2" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                        SqlParameter findParaTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int);
                        SqlParameter findParaPartsMakerCd = sqlCommand.Parameters.Add("@FINDPARTSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaPrmSetDtlNo1 = sqlCommand.Parameters.Add("@FINDPRMSETDTLNO1", SqlDbType.Int);
                        SqlParameter findParaPrmSetDtlNo2 = sqlCommand.Parameters.Add("@FINDPRMSETDTLNO2", SqlDbType.Int); 

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.SectionCode);
                        findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.GoodsMGroup);
                        findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.TbsPartsCode);
                        findParaPartsMakerCd.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PartsMakerCd);
                        findParaPrmSetDtlNo1.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo1);
                        findParaPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo2);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != prmSettingUWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE文]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += " FROM PRMSETTINGURF" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine; 
                            sqlText += "    AND GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                            sqlText += "    AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                            sqlText += "    AND PARTSMAKERCDRF=@FINDPARTSMAKERCD" + Environment.NewLine;
                            sqlText += "    AND PRMSETDTLNO1RF=@FINDPRMSETDTLNO1" + Environment.NewLine;
                            sqlText += "    AND PRMSETDTLNO2RF=@FINDPRMSETDTLNO2" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.SectionCode);
                            findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.GoodsMGroup);
                            findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.TbsPartsCode);
                            findParaPartsMakerCd.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PartsMakerCd);
                            findParaPrmSetDtlNo1.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo1);
                            findParaPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo2);
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
        /// 優良設定マスタ（ユーザー登録分）情報のリストを取得します。
        /// </summary>
        /// <param name="prmSettingUList">検索結果</param>
        /// <param name="prmSettingUObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 優良設定マスタ（ユーザー登録分）のキー値が一致する、全ての優良設定マスタ（ユーザー登録分）情報を取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        public int Search(ref object prmSettingUList, object prmSettingUObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList prmSettingUArray = prmSettingUList as ArrayList;

                if (prmSettingUArray == null)
                {
                    prmSettingUArray = new ArrayList();
                }

                PrmSettingUWork prmSettingUWork = prmSettingUObj as PrmSettingUWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref prmSettingUArray, prmSettingUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
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
        /// 優良設定マスタ（ユーザー登録分）情報のリストを取得します。
        /// </summary>
        /// <param name="prmSettingUList">優良設定マスタ（ユーザー登録分）情報を格納する ArrayList</param>
        /// <param name="prmSettingUWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 優良設定マスタ（ユーザー登録分）のキー値が一致する、全ての優良設定マスタ（ユーザー登録分）情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        public int Search(ref ArrayList prmSettingUList, PrmSettingUWork prmSettingUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref prmSettingUList, prmSettingUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 優良設定マスタ（ユーザー登録分）情報のリストを取得します。
        /// </summary>
        /// <param name="prmSettingUList">優良設定マスタ（ユーザー登録分）情報を格納する ArrayList</param>
        /// <param name="prmSettingUWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 優良設定マスタ（ユーザー登録分）のキー値が一致する、全ての優良設定マスタ（ユーザー登録分）情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        /// <br></br>
        /// <br>Update Note: 11070266-00　SCM高速化 Ｃ向け種別対応 </br>
        /// <br>             取得項目追加（優良設定詳細名称２(工場向け)、優良設定詳細名称２(カーオーナー向け)）</br>
        /// <br>Programmer : 30757 佐々木 貴英</br>
        /// <br>Date       : 2015/02/24</br>
        /// <br>Update Note: 11770032-00 山形部品障害対応（先行対応） オブジェクト参照エラー対応（負荷軽減のためREADUNCOMMITTED追加）</br>
        /// <br>Programmer : 30809 佐々木 亘</br>
        /// <br>Date       : 2021/03/25</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc(ref ArrayList prmSettingUList, PrmSettingUWork prmSettingUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT文]
                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,GOODSMGROUPRF" + Environment.NewLine;
                sqlText += "    ,TBSPARTSCODERF" + Environment.NewLine;
                sqlText += "    ,TBSPARTSCDDERIVEDNORF" + Environment.NewLine;
                sqlText += "    ,MAKERDISPORDERRF" + Environment.NewLine;
                sqlText += "    ,PARTSMAKERCDRF" + Environment.NewLine;
                sqlText += "    ,PRIMEDISPORDERRF" + Environment.NewLine;
                sqlText += "    ,PRMSETDTLNO1RF" + Environment.NewLine;
                sqlText += "    ,PRMSETDTLNAME1RF" + Environment.NewLine;
                sqlText += "    ,PRMSETDTLNO2RF" + Environment.NewLine;
                sqlText += "    ,PRMSETDTLNAME2RF" + Environment.NewLine;
                sqlText += "    ,PRIMEDISPLAYCODERF" + Environment.NewLine;
                //---ADD　30757 佐々木　貴英　2015/02/24 11070266-00　SCM高速化 Ｃ向け種別対応 ---------------->>>>>
                sqlText += "    ,PRMSETDTLNAME2FORFACRF" + Environment.NewLine;
                sqlText += "    ,PRMSETDTLNAME2FORCOWRF" + Environment.NewLine;
                //---ADD　30757 佐々木　貴英　2015/02/24 11070266-00　SCM高速化 Ｃ向け種別対応 ----------------<<<<<
                //---UPD　30809 佐々木　亘　2021/03/25 11770032-00　オブジェクト参照エラー対応 ------>>>>>
                //sqlText += " FROM PRMSETTINGURF" + Environment.NewLine;
                sqlText += " FROM PRMSETTINGURF  WITH(READUNCOMMITTED) " + Environment.NewLine;
                //---UPD　30809 佐々木　亘　2021/03/25 11770032-00　オブジェクト参照エラー対応 ------<<<<<
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, prmSettingUWork, logicalMode);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    prmSettingUList.Add(this.CopyToPrmSettingUWorkFromReader(ref myReader));
                }

                if (prmSettingUList.Count > 0)
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

        # region [Write]
        /// <summary>
        /// 優良設定マスタ（ユーザー登録分）情報を追加・更新します。
        /// </summary>
        /// <param name="prmSettingUList">追加・更新する優良設定マスタ（ユーザー登録分）情報を含む ArrayList</param>
        /// <param name="goodsMngList">更新する商品管理情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PrmSettingUList に格納されている優良設定マスタ（ユーザー登録分）情報を追加・更新します。</br>
        /// <br>Note       : GoodsMngList に格納されている商品管理情報を更新します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        public int Write(ref object prmSettingUList, ref object goodsMngList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = prmSettingUList as ArrayList;
                ArrayList paraGoodsMngList = goodsMngList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write実行
                status = this.Write(ref paraList, ref sqlConnection, ref sqlTransaction);

                // ADD 2008.11.17 削除 >>>
                // 商品管理情報更新
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    GoodsMngDB goodsMngDB = new GoodsMngDB();
                //    status = goodsMngDB.WriteGoodsMngProc(ref paraGoodsMngList, ref sqlConnection, ref sqlTransaction);
                //}
                ArrayList wkGoodsMngList = new ArrayList();
                GoodsMngDB goodsMngDB = new GoodsMngDB();

                // 優良設定マスタのパラメータList内に企業・拠点・BLCD・中分類・メーカーが同一のレコードが、
                // 渡される可能性があるため、表示区分:0以外を優先的に整理する。(整理しなければ、商品管理情報マスタの登録更新でエラーが発生)
                ArrayList workparaList = new ArrayList();
                Boolean WriteFlg = false;
                for (int k = 0; k < paraList.Count; k++)
                {
                    if (workparaList.Count==0)
                    {
                        workparaList.Add(paraList[k]);
                    }
                    else
                    {
                        WriteFlg = true;
                        for(int l=0; l<workparaList.Count; l++)
                        {
                            if ((((PrmSettingUWork)paraList[k]).EnterpriseCode.Trim() == ((PrmSettingUWork)workparaList[l]).EnterpriseCode.Trim()) &&
                                (((PrmSettingUWork)paraList[k]).SectionCode.Trim() == ((PrmSettingUWork)workparaList[l]).SectionCode.Trim()) &&
                                (((PrmSettingUWork)paraList[k]).TbsPartsCode == ((PrmSettingUWork)workparaList[l]).TbsPartsCode) &&
                                (((PrmSettingUWork)paraList[k]).GoodsMGroup == ((PrmSettingUWork)workparaList[l]).GoodsMGroup) &&
                                (((PrmSettingUWork)paraList[k]).PartsMakerCd == ((PrmSettingUWork)workparaList[l]).PartsMakerCd))
                            {
                                ((PrmSettingUWork)workparaList[l]).PrimeDisplayCode += ((PrmSettingUWork)paraList[k]).PrimeDisplayCode;
                                WriteFlg = false;
                            }
                        }
                        if (WriteFlg == true)
                        {
                            workparaList.Add(paraList[k]);
                        }
                    }
                }

                for (int i = 0; i < workparaList.Count; i++)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        wkGoodsMngList.Clear();
                        for (int j = 0; j < paraGoodsMngList.Count; j++)
                        {
                            if ((((PrmSettingUWork)workparaList[i]).EnterpriseCode.Trim() == ((GoodsMngWork)paraGoodsMngList[j]).EnterpriseCode.Trim()) &&
                                 (((PrmSettingUWork)workparaList[i]).SectionCode.Trim() == ((GoodsMngWork)paraGoodsMngList[j]).SectionCode.Trim()) &&
                                 (((PrmSettingUWork)workparaList[i]).TbsPartsCode == ((GoodsMngWork)paraGoodsMngList[j]).BLGoodsCode) &&
                                 (((PrmSettingUWork)workparaList[i]).GoodsMGroup == ((GoodsMngWork)paraGoodsMngList[j]).GoodsMGroup) &&
                                 (((PrmSettingUWork)workparaList[i]).PartsMakerCd == ((GoodsMngWork)paraGoodsMngList[j]).GoodsMakerCd))
                            {
                                wkGoodsMngList.Add(paraGoodsMngList[j]);
                                break;
                            }
                        }


                        if (wkGoodsMngList.Count > 0)
                        {
                            if (((PrmSettingUWork)workparaList[i]).PrimeDisplayCode == 0)　// 0:無し,1:商品と結合,2:商品
                            {
                                // 表示なしの場合
                                status = goodsMngDB.DeleteGoodsMngProc(wkGoodsMngList, ref sqlConnection, ref sqlTransaction);
                            }
                            else
                            {
                                // 表示なし以外の場合
                                status = goodsMngDB.WriteGoodsMngProc(ref wkGoodsMngList, ref sqlConnection, ref sqlTransaction);
                            }
                        }
                    }
                }


                // ADD 2008.11.17 <<<

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
        /// 優良設定マスタ（ユーザー登録分）情報を追加・更新します。
        /// </summary>
        /// <param name="prmSettingUList">追加・更新する優良設定マスタ（ユーザー登録分）情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PrmSettingUList に格納されている優良設定マスタ（ユーザー登録分）情報を追加・更新します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        public int Write(ref ArrayList prmSettingUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref prmSettingUList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 優良設定マスタ（ユーザー登録分）情報を追加・更新します。
        /// </summary>
        /// <param name="prmSettingUList">追加・更新する優良設定マスタ（ユーザー登録分）情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : PrmSettingUList に格納されている優良設定マスタ（ユーザー登録分）情報を追加・更新します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        /// <br></br>
        /// <br>Update Note: 11070266-00　SCM高速化 Ｃ向け種別対応 </br>
        /// <br>             設定項目追加（優良設定詳細名称２(工場向け)、優良設定詳細名称２(カーオーナー向け)）</br>
        /// <br>Programmer : 30757 佐々木 貴英</br>
        /// <br>Date       : 2015/02/24</br>
        /// <br></br>
        /// </remarks>
        private int WriteProc(ref ArrayList prmSettingUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (prmSettingUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < prmSettingUList.Count; i++)
                    {
                        PrmSettingUWork prmSettingUWork = prmSettingUList[i] as PrmSettingUWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " FROM PRMSETTINGURF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlText += "    AND GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                        sqlText += "    AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                        sqlText += "    AND PARTSMAKERCDRF=@FINDPARTSMAKERCD" + Environment.NewLine;
                        sqlText += "    AND PRMSETDTLNO1RF=@FINDPRMSETDTLNO1" + Environment.NewLine;
                        sqlText += "    AND PRMSETDTLNO2RF=@FINDPRMSETDTLNO2" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                        SqlParameter findParaTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int);
                        SqlParameter findParaPartsMakerCd = sqlCommand.Parameters.Add("@FINDPARTSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaPrmSetDtlNo1 = sqlCommand.Parameters.Add("@FINDPRMSETDTLNO1", SqlDbType.Int);
                        SqlParameter findParaPrmSetDtlNo2 = sqlCommand.Parameters.Add("@FINDPRMSETDTLNO2", SqlDbType.Int); 

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.SectionCode);
                        findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.GoodsMGroup);
                        findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.TbsPartsCode);
                        findParaPartsMakerCd.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PartsMakerCd);
                        findParaPrmSetDtlNo1.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo1);
                        findParaPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo2);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != prmSettingUWork.UpdateDateTime)
                            {
                                if (prmSettingUWork.UpdateDateTime == DateTime.MinValue)
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

                            # region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText += "UPDATE PRMSETTINGURF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            sqlText += " , GOODSMGROUPRF=@GOODSMGROUP" + Environment.NewLine;
                            sqlText += " , TBSPARTSCODERF=@TBSPARTSCODE" + Environment.NewLine;
                            sqlText += " , TBSPARTSCDDERIVEDNORF=@TBSPARTSCDDERIVEDNO" + Environment.NewLine;
                            sqlText += " , MAKERDISPORDERRF=@MAKERDISPORDER" + Environment.NewLine;
                            sqlText += " , PARTSMAKERCDRF=@PARTSMAKERCD" + Environment.NewLine;
                            sqlText += " , PRIMEDISPORDERRF=@PRIMEDISPORDER" + Environment.NewLine;
                            sqlText += " , PRMSETDTLNO1RF=@PRMSETDTLNO1" + Environment.NewLine;
                            sqlText += " , PRMSETDTLNAME1RF=@PRMSETDTLNAME1" + Environment.NewLine;
                            sqlText += " , PRMSETDTLNO2RF=@PRMSETDTLNO2" + Environment.NewLine;
                            sqlText += " , PRMSETDTLNAME2RF=@PRMSETDTLNAME2" + Environment.NewLine;
                            sqlText += " , PRIMEDISPLAYCODERF=@PRIMEDISPLAYCODE" + Environment.NewLine;
                            //---ADD　30757 佐々木　貴英　2015/02/24 11070266-00　SCM高速化 Ｃ向け種別対応 ---------------->>>>>
                            sqlText += " ,PRMSETDTLNAME2FORFACRF=@PRMSETDTLNAME2FORFACRF" + Environment.NewLine;
                            sqlText += " ,PRMSETDTLNAME2FORCOWRF=@PRMSETDTLNAME2FORCOWRF" + Environment.NewLine;
                            //---ADD　30757 佐々木　貴英　2015/02/24 11070266-00　SCM高速化 Ｃ向け種別対応 ----------------<<<<<
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlText += "    AND GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                            sqlText += "    AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                            sqlText += "    AND PARTSMAKERCDRF=@FINDPARTSMAKERCD" + Environment.NewLine;
                            sqlText += "    AND PRMSETDTLNO1RF=@FINDPRMSETDTLNO1" + Environment.NewLine;
                            sqlText += "    AND PRMSETDTLNO2RF=@FINDPRMSETDTLNO2" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.SectionCode);
                            findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.GoodsMGroup);
                            findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.TbsPartsCode);
                            findParaPartsMakerCd.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PartsMakerCd);
                            findParaPrmSetDtlNo1.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo1);
                            findParaPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo2);

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)prmSettingUWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (prmSettingUWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT文]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO PRMSETTINGURF" + Environment.NewLine;
                            sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                            sqlText += "    ,GOODSMGROUPRF" + Environment.NewLine;
                            sqlText += "    ,TBSPARTSCODERF" + Environment.NewLine;
                            sqlText += "    ,TBSPARTSCDDERIVEDNORF" + Environment.NewLine;
                            sqlText += "    ,MAKERDISPORDERRF" + Environment.NewLine;
                            sqlText += "    ,PARTSMAKERCDRF" + Environment.NewLine;
                            sqlText += "    ,PRIMEDISPORDERRF" + Environment.NewLine;
                            sqlText += "    ,PRMSETDTLNO1RF" + Environment.NewLine;
                            sqlText += "    ,PRMSETDTLNAME1RF" + Environment.NewLine;
                            sqlText += "    ,PRMSETDTLNO2RF" + Environment.NewLine;
                            sqlText += "    ,PRMSETDTLNAME2RF" + Environment.NewLine;
                            sqlText += "    ,PRIMEDISPLAYCODERF" + Environment.NewLine;
                            //---ADD　30757 佐々木　貴英　2015/02/24 11070266-00　SCM高速化 Ｃ向け種別対応 ---------------->>>>>
                            sqlText += "    ,PRMSETDTLNAME2FORFACRF" + Environment.NewLine;
                            sqlText += "    ,PRMSETDTLNAME2FORCOWRF" + Environment.NewLine;
                            //---ADD　30757 佐々木　貴英　2015/02/24 11070266-00　SCM高速化 Ｃ向け種別対応 ----------------<<<<<
                            sqlText += " )" + Environment.NewLine;
                            sqlText += " VALUES" + Environment.NewLine;
                            sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "    ,@SECTIONCODE" + Environment.NewLine;
                            sqlText += "    ,@GOODSMGROUP" + Environment.NewLine;
                            sqlText += "    ,@TBSPARTSCODE" + Environment.NewLine;
                            sqlText += "    ,@TBSPARTSCDDERIVEDNO" + Environment.NewLine;
                            sqlText += "    ,@MAKERDISPORDER" + Environment.NewLine;
                            sqlText += "    ,@PARTSMAKERCD" + Environment.NewLine;
                            sqlText += "    ,@PRIMEDISPORDER" + Environment.NewLine;
                            sqlText += "    ,@PRMSETDTLNO1" + Environment.NewLine;
                            sqlText += "    ,@PRMSETDTLNAME1" + Environment.NewLine;
                            sqlText += "    ,@PRMSETDTLNO2" + Environment.NewLine;
                            sqlText += "    ,@PRMSETDTLNAME2" + Environment.NewLine;
                            sqlText += "    ,@PRIMEDISPLAYCODE" + Environment.NewLine;
                            //---ADD　30757 佐々木　貴英　2015/02/24 11070266-00　SCM高速化 Ｃ向け種別対応 ---------------->>>>>
                            sqlText += "    ,@PRMSETDTLNAME2FORFACRF" + Environment.NewLine;
                            sqlText += "    ,@PRMSETDTLNAME2FORCOWRF" + Environment.NewLine;
                            //---ADD　30757 佐々木　貴英　2015/02/24 11070266-00　SCM高速化 Ｃ向け種別対応 ----------------<<<<<
                            sqlText += " )" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // 登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)prmSettingUWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        # region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);
                        SqlParameter paraTbsPartsCode = sqlCommand.Parameters.Add("@TBSPARTSCODE", SqlDbType.Int);
                        SqlParameter paraTbsPartsCdDerivedNo = sqlCommand.Parameters.Add("@TBSPARTSCDDERIVEDNO", SqlDbType.Int);
                        SqlParameter paraMakerDispOrder = sqlCommand.Parameters.Add("@MAKERDISPORDER", SqlDbType.Int);
                        SqlParameter paraPartsMakerCd = sqlCommand.Parameters.Add("@PARTSMAKERCD", SqlDbType.Int);
                        SqlParameter paraPrimeDispOrder = sqlCommand.Parameters.Add("@PRIMEDISPORDER", SqlDbType.Int);
                        SqlParameter paraPrmSetDtlNo1 = sqlCommand.Parameters.Add("@PRMSETDTLNO1", SqlDbType.Int);
                        SqlParameter paraPrmSetDtlName1 = sqlCommand.Parameters.Add("@PRMSETDTLNAME1", SqlDbType.NVarChar);
                        SqlParameter paraPrmSetDtlNo2 = sqlCommand.Parameters.Add("@PRMSETDTLNO2", SqlDbType.Int);
                        SqlParameter paraPrmSetDtlName2 = sqlCommand.Parameters.Add("@PRMSETDTLNAME2", SqlDbType.NVarChar);
                        SqlParameter paraPrimeDisplayCode = sqlCommand.Parameters.Add("@PRIMEDISPLAYCODE", SqlDbType.Int);
                        //---ADD　30757 佐々木　貴英　2015/02/24 11070266-00　SCM高速化 Ｃ向け種別対応 ---------------->>>>>
                        SqlParameter paraPrmSetDtlName2ForFac = sqlCommand.Parameters.Add("@PRMSETDTLNAME2FORFACRF", SqlDbType.NVarChar);
                        SqlParameter paraPrmSetDtlName2ForCOw = sqlCommand.Parameters.Add("@PRMSETDTLNAME2FORCOWRF", SqlDbType.NVarChar);
                        //---ADD　30757 佐々木　貴英　2015/02/24 11070266-00　SCM高速化 Ｃ向け種別対応 ----------------<<<<<
                        # endregion

                        # region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(prmSettingUWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(prmSettingUWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(prmSettingUWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(prmSettingUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(prmSettingUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.SectionCode);
                        paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.GoodsMGroup);
                        paraTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.TbsPartsCode);
                        paraTbsPartsCdDerivedNo.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.TbsPartsCdDerivedNo);
                        paraMakerDispOrder.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.MakerDispOrder);
                        paraPartsMakerCd.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PartsMakerCd);
                        paraPrimeDispOrder.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrimeDispOrder);
                        paraPrmSetDtlNo1.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo1);
                        paraPrmSetDtlName1.Value = SqlDataMediator.SqlSetString(prmSettingUWork.PrmSetDtlName1);
                        paraPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo2);
                        paraPrmSetDtlName2.Value = SqlDataMediator.SqlSetString(prmSettingUWork.PrmSetDtlName2);
                        // 修正 2009.01.26 >>>
                        //paraPrimeDisplayCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrimeDisplayCode);
                        if (prmSettingUWork.TbsPartsCode == 0)
                        {
                            paraPrimeDisplayCode.Value = 0;
                        }
                        else
                        {
                            paraPrimeDisplayCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrimeDisplayCode);
                        }
                        // 修正 2009.01.26 <<<
                        //---ADD　30757 佐々木　貴英　2015/02/24 11070266-00　SCM高速化 Ｃ向け種別対応 ---------------->>>>>
                        paraPrmSetDtlName2ForFac.Value = SqlDataMediator.SqlSetString(prmSettingUWork.PrmSetDtlName2ForFac);
                        paraPrmSetDtlName2ForCOw.Value = SqlDataMediator.SqlSetString(prmSettingUWork.PrmSetDtlName2ForCOw);
                        //---ADD　30757 佐々木　貴英　2015/02/24 11070266-00　SCM高速化 Ｃ向け種別対応 ----------------<<<<<

                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(prmSettingUWork);
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

            prmSettingUList = al;

            return status;
        }
        # endregion

        #region [GetSyncdataList]
        /// <summary>
        /// ローカルシンク用のデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arraylistdata">検索結果</param>
        /// <param name="syncServiceWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のUOE自社設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081  疋田　勇人</br>
        /// <br>Date       : 2008.06.11</br>
        public int GetSyncdataList(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            return this.GetSyncdataListProc(out arraylistdata, syncServiceWork, ref sqlConnection);
        }

        /// <summary>
        /// ローカルシンク用のデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arraylistdata">検索結果</param>
        /// <param name="syncServiceWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件のUOE自社設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081  疋田　勇人</br>
        /// <br>Date       : 2008.06.11</br>
        /// <br></br>
        /// <br>Update Note: 11070266-00　SCM高速化 Ｃ向け種別対応 </br>
        /// <br>             取得項目追加（優良設定詳細名称２(工場向け)、優良設定詳細名称２(カーオーナー向け)）</br>
        /// <br>Programmer : 30757 佐々木 貴英</br>
        /// <br>Date       : 2015/02/24</br>
        /// <br></br>
        /// </remarks>
        private int GetSyncdataListProc(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string sqlText = string.Empty;
                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,GOODSMGROUPRF" + Environment.NewLine;
                sqlText += "    ,TBSPARTSCODERF" + Environment.NewLine;
                sqlText += "    ,TBSPARTSCDDERIVEDNORF" + Environment.NewLine;
                sqlText += "    ,MAKERDISPORDERRF" + Environment.NewLine;
                sqlText += "    ,PARTSMAKERCDRF" + Environment.NewLine;
                sqlText += "    ,PRIMEDISPORDERRF" + Environment.NewLine;
                sqlText += "    ,PRMSETDTLNO1RF" + Environment.NewLine;
                sqlText += "    ,PRMSETDTLNAME1RF" + Environment.NewLine;
                sqlText += "    ,PRMSETDTLNO2RF" + Environment.NewLine;
                sqlText += "    ,PRMSETDTLNAME2RF" + Environment.NewLine;
                sqlText += "    ,PRIMEDISPLAYCODERF" + Environment.NewLine;
                //---ADD　30757 佐々木　貴英　2015/02/24 11070266-00　SCM高速化 Ｃ向け種別対応 ---------------->>>>>
                sqlText += "    ,PRMSETDTLNAME2FORFACRF" + Environment.NewLine;
                sqlText += "    ,PRMSETDTLNAME2FORCOWRF" + Environment.NewLine;
                //---ADD　30757 佐々木　貴英　2015/02/24 11070266-00　SCM高速化 Ｃ向け種別対応 ----------------<<<<<
                sqlText += " FROM PRMSETTINGURF" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);
                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToPrmSettingUWorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            arraylistdata = al;

            return status;
        }
        #endregion

        # region [LogicalDelete]
        /// <summary>
        /// 優良設定マスタ（ユーザー登録分）情報を論理削除します。
        /// </summary>
        /// <param name="prmSettingUList">論理削除する優良設定マスタ（ユーザー登録分）情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PrmSettingUWork に格納されている優良設定マスタ（ユーザー登録分）情報を論理削除します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        public int LogicalDelete(ref object prmSettingUList)
        {
            return this.LogicalDelete(ref prmSettingUList, 0);
        }

        /// <summary>
        /// 優良設定マスタ（ユーザー登録分）情報の論理削除を解除します。
        /// </summary>
        /// <param name="prmSettingUList">論理削除を解除する優良設定マスタ（ユーザー登録分）情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PrmSettingUWork に格納されている優良設定マスタ（ユーザー登録分）情報の論理削除を解除します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        public int RevivalLogicalDelete(ref object prmSettingUList)
        {
            return this.LogicalDelete(ref prmSettingUList, 1);
        }

        /// <summary>
        /// 優良設定マスタ（ユーザー登録分）情報の論理削除を操作します。
        /// </summary>
        /// <param name="prmSettingUList">論理削除を操作する優良設定マスタ（ユーザー登録分）情報</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PrmSettingUWork に格納されている優良設定マスタ（ユーザー登録分）情報の論理削除を操作します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        private int LogicalDelete(ref object prmSettingUList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = prmSettingUList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.LogicalDelete(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);
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
        /// 優良設定マスタ（ユーザー登録分）情報の論理削除を操作します。
        /// </summary>
        /// <param name="prmSettingUList">論理削除を操作する優良設定マスタ（ユーザー登録分）情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PrmSettingUWork に格納されている優良設定マスタ（ユーザー登録分）情報の論理削除を操作します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        public int LogicalDelete(ref ArrayList prmSettingUList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref prmSettingUList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 優良設定マスタ（ユーザー登録分）情報の論理削除を操作します。
        /// </summary>
        /// <param name="prmSettingUList">論理削除を操作する優良設定マスタ（ユーザー登録分）情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PrmSettingUWork に格納されている優良設定マスタ（ユーザー登録分）情報の論理削除を操作します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        private int LogicalDeleteProc(ref ArrayList prmSettingUList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (prmSettingUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < prmSettingUList.Count; i++)
                    {
                        PrmSettingUWork prmSettingUWork = prmSettingUList[i] as PrmSettingUWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += " FROM PRMSETTINGURF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlText += "    AND GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                        sqlText += "    AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                        sqlText += "    AND PARTSMAKERCDRF=@FINDPARTSMAKERCD" + Environment.NewLine;
                        sqlText += "    AND PRMSETDTLNO1RF=@FINDPRMSETDTLNO1" + Environment.NewLine;
                        sqlText += "    AND PRMSETDTLNO2RF=@FINDPRMSETDTLNO2" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                        SqlParameter findParaTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int);
                        SqlParameter findParaPartsMakerCd = sqlCommand.Parameters.Add("@FINDPARTSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaPrmSetDtlNo1 = sqlCommand.Parameters.Add("@FINDPRMSETDTLNO1", SqlDbType.Int);
                        SqlParameter findParaPrmSetDtlNo2 = sqlCommand.Parameters.Add("@FINDPRMSETDTLNO2", SqlDbType.Int);                

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.SectionCode);
                        findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.GoodsMGroup);
                        findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.TbsPartsCode);
                        findParaPartsMakerCd.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PartsMakerCd);
                        findParaPrmSetDtlNo1.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo1);
                        findParaPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo2);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != prmSettingUWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // 現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  PRMSETTINGURF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlText += "    AND GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                            sqlText += "    AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                            sqlText += "    AND PARTSMAKERCDRF=@FINDPARTSMAKERCD" + Environment.NewLine;
                            sqlText += "    AND PRMSETDTLNO1RF=@FINDPRMSETDTLNO1" + Environment.NewLine;
                            sqlText += "    AND PRMSETDTLNO2RF=@FINDPRMSETDTLNO2" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.SectionCode);
                            findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.GoodsMGroup);
                            findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.TbsPartsCode);
                            findParaPartsMakerCd.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PartsMakerCd);
                            findParaPrmSetDtlNo1.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo1);
                            findParaPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo2);

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)prmSettingUWork;
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
                            else if (logicalDelCd == 0) prmSettingUWork.LogicalDeleteCode = 1;  // 論理削除フラグをセット
                            else prmSettingUWork.LogicalDeleteCode = 3;                         // 完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                prmSettingUWork.LogicalDeleteCode = 0;                          // 論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(prmSettingUWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(prmSettingUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(prmSettingUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(prmSettingUWork);
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

            prmSettingUList = al;

            return status;
        }
        # endregion

        # region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="prmSettingUWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        /// <br>Note       : 商品管理情報マスタでパタン「拠点+中分類＋メーカー＋BLコード」の追加に伴う削除処理の改修</br>
        /// <br>Programmer : 袁磊 redmine#32367</br>
        /// <br>Date       : 2012/11/23</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, PrmSettingUWork prmSettingUWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;;

            // 企業コード
            retstring += "  ENTERPRISECODERF = @FINDENTERPRISECODE"  + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.EnterpriseCode);

            // 論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
                (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                (logicalMode == ConstantManagement.LogicalMode.GetData2)||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01)||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if(wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            // 拠点コード
            if (prmSettingUWork.SectionCode != "")
            {
                retstring += "  AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                findSectionCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.SectionCode);
            }

            // 商品中分類コード
            if (prmSettingUWork.GoodsMGroup != 0)
            {
                retstring += "  AND GOODSMGROUPRF = @FINDGOODSMGROUP" + Environment.NewLine;
                SqlParameter findGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                findGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.GoodsMGroup);
            }

            // BLコード
            //if (prmSettingUWork.GoodsMGroup != 0) // DEL 2012/11/23 袁磊 for redmine#32367
            if (prmSettingUWork.TbsPartsCode != 0) // ADD 2012/11/23 袁磊 for redmine#32367
            {
                retstring += "  AND TBSPARTSCODERF = @FINDTBSPARTSCODE" + Environment.NewLine;
                SqlParameter findTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int);
                findTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.TbsPartsCode);
            }
            
            // 部品メーカーコード
            if (prmSettingUWork.PartsMakerCd != 0)
            {
                retstring += "  AND PARTSMAKERCDRF = @FINDPARTSMAKERCD" + Environment.NewLine;
                SqlParameter findPartsMakerCd = sqlCommand.Parameters.Add("@FINDPARTSMAKERCD", SqlDbType.Int);
                findPartsMakerCd.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PartsMakerCd);
            }

            // 優良設定詳細コード１
            if (prmSettingUWork.PrmSetDtlNo1 != 0)
            {
                retstring += "  AND PRMSETDTLNO1RF = @FINDPRMSETDTLNO1" + Environment.NewLine;
                SqlParameter findPrmSetDtlNo1 = sqlCommand.Parameters.Add("@FINDPRMSETDTLNO1", SqlDbType.Int);
                findPrmSetDtlNo1.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo1);
            }

            // 優良設定詳細コード２
            if (prmSettingUWork.PrmSetDtlNo2 != 0)
            {
                retstring += "  AND PRMSETDTLNO2RF = @FINDPRMSETDTLNO2" + Environment.NewLine;
                SqlParameter findPrmSetDtlNo2 = sqlCommand.Parameters.Add("@FINDPRMSETDTLNO2", SqlDbType.Int);
                findPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo2);
            }

            // 優良表示区分　0⇒0：無以外 -1⇒全て 
            if (prmSettingUWork.PrimeDisplayCode == 0)
            {
                retstring += "  AND PRIMEDISPLAYCODERF != @FINDPRIMEDISPLAYCODERF" + Environment.NewLine;
                SqlParameter findPrimeDisplayCode = sqlCommand.Parameters.Add("@FINDPRIMEDISPLAYCODERF", SqlDbType.Int);
                findPrimeDisplayCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrimeDisplayCode);
            }

            return retstring;
        }
        # endregion

        #region [シンク用Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="syncServiceWork">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 20081  疋田　勇人</br>
        /// <br>Date       : 2008.06.11</br>
        private string MakeSyncWhereString(ref SqlCommand sqlCommand, SyncServiceWork syncServiceWork)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);

            //差分シンクの場合は更新日付の範囲指定
            if (syncServiceWork.Syncmode == 0)
            {
                wkstring = "AND UPDATEDATETIMERF>=@FINDUPDATEDATETIMEST ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeSt = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEST", SqlDbType.BigInt);
                paraUpdateDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeSt);

                wkstring = "AND UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }
            else
            {
                wkstring = "AND UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }

            return retstring;
        }
        #endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → PrmSettingUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>PrmSettingUWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        /// </remarks>
        private PrmSettingUWork CopyToPrmSettingUWorkFromReader(ref SqlDataReader myReader)
        {
            PrmSettingUWork prmSettingUWork = new PrmSettingUWork();

            this.CopyToPrmSettingUWorkFromReader(ref myReader, ref prmSettingUWork);

            return prmSettingUWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → PrmSettingUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="prmSettingUWork">PrmSettingUWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        /// <br></br>
        /// <br>Update Note: 11070266-00　SCM高速化 Ｃ向け種別対応 </br>
        /// <br>             取得項目追加（優良設定詳細名称２(工場向け)、優良設定詳細名称２(カーオーナー向け)）</br>
        /// <br>Programmer : 30757 佐々木 貴英</br>
        /// <br>Date       : 2015/02/24</br>
        /// <br></br>
        /// </remarks>
        private void CopyToPrmSettingUWorkFromReader(ref SqlDataReader myReader, ref PrmSettingUWork prmSettingUWork)
        {
            if (myReader != null && prmSettingUWork != null)
            {
                # region クラスへ格納
                prmSettingUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                prmSettingUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                prmSettingUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                prmSettingUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                prmSettingUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                prmSettingUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                prmSettingUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                prmSettingUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                prmSettingUWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                prmSettingUWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                prmSettingUWork.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                prmSettingUWork.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                prmSettingUWork.MakerDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERDISPORDERRF"));
                prmSettingUWork.PartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                prmSettingUWork.PrimeDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIMEDISPORDERRF"));
                prmSettingUWork.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO1RF"));
                prmSettingUWork.PrmSetDtlName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME1RF"));
                prmSettingUWork.PrmSetDtlNo2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO2RF"));
                prmSettingUWork.PrmSetDtlName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME2RF"));
                prmSettingUWork.PrimeDisplayCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIMEDISPLAYCODERF"));
                //---ADD　30757 佐々木　貴英　2015/02/24 11070266-00　SCM高速化 Ｃ向け種別対応 ---------------->>>>>
                prmSettingUWork.PrmSetDtlName2ForFac = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME2FORFACRF"));
                prmSettingUWork.PrmSetDtlName2ForCOw = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME2FORCOWRF"));
                //---ADD　30757 佐々木　貴英　2015/02/24 11070266-00　SCM高速化 Ｃ向け種別対応 ----------------<<<<<
                # endregion
            }
        }
        # endregion

        # region [コネクション生成処理]
        ///// <summary>
        ///// SqlConnection生成処理
        ///// </summary>
        ///// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        ///// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        ///// <remarks>
        ///// <br>Programmer : 20081 疋田 勇人</br>
        ///// <br>Date       : 2008.06.11</br>
        ///// </remarks>
        //private SqlConnection CreateSqlConnection(bool open)
        //{
        //    SqlConnection retSqlConnection = null;

        //    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

        //    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

        //    if (!string.IsNullOrEmpty(connectionText))
        //    {
        //        retSqlConnection = new SqlConnection(connectionText);

        //        if (open)
        //        {
        //            retSqlConnection.Open();
        //        }
        //    }

        //    return retSqlConnection;
        //}

        ///// <summary>
        ///// SqlTransaction生成処理
        ///// </summary>
        ///// <param name="sqlconnection"></param>
        ///// <returns>生成されたSqlTransaction、生成に失敗した場合はNullを返す。</returns>
        ///// <remarks>
        ///// <br>Programmer : 20081 疋田 勇人</br>
        ///// <br>Date       : 2008.06.11</br>
        ///// </remarks>
        //private SqlTransaction CreateTransaction(ref SqlConnection sqlconnection)
        //{
        //    SqlTransaction retSqlTransaction = null;

        //    if (sqlconnection != null)
        //    {
        //        // DBに接続されていない場合はここで接続する
        //        if ((sqlconnection.State & ConnectionState.Open) == 0)
        //        {
        //            sqlconnection.Open();
        //        }

        //        // トランザクションの生成(開始)
        //        retSqlTransaction = sqlconnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
        //    }

        //    return retSqlTransaction;
        //}
        # endregion
    }
}

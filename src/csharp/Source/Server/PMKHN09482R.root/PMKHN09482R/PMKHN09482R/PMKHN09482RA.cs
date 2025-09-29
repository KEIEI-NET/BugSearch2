//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 掛率設定マスタメン（掛率優先管理パターン） 
// プログラム概要   : 掛率設定マスタメン（掛率優先管理パターン）関連処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2010/08/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 修 正 日  2010/09/10  修正内容 : 障害・改良対応8月ﾘﾘｰｽ
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 修 正 日  2010/09/26  修正内容 : 仕様連絡 #14492対応
//----------------------------------------------------------------------------//
// 管理番号  11670219-00 作成担当 : 譚洪
// 修 正 日  2020/06/17  修正内容 : PMKOBETSU-4005 ＥＢＥ対策
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using System.Data.SqlClient;
using System.Collections;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlTypes;
using System.Data;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Data;
using Broadleaf.Application.Common; // ADD 2020/06/18 譚洪 PMKOBETSU-4005

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 掛率設定マスタメン（掛率優先管理パターン）DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 掛率設定マスタメン（掛率優先管理パターン）の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2010/08/10</br>
    /// <br></br>
    /// <br>Update Note: 2010/09/10 高峰 障害・改良対応8月ﾘﾘｰｽ</br>
    /// <br>Update Note: 2010/09/26 呉元嘯 仕様連絡 #14492対応</br>
    /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2020/06/18</br>
    /// </remarks>
    [Serializable]
    public class RateProtyMngPatternDB : RemoteDB, IRateProtyMngPatternDB
    {
        const double MIN_DOUBLE = 0.000001;   // ADD 2010/09/19
 
        private RateDB _rateDB = new RateDB();

        private string _tableName = "";
        private string _dataColumnCd = "";
        private string _dataColumnCdMast = "";
        private string _dataColumnNm = "";
        private string _rateSettingDivide = "";

        /// <summary>
        /// 掛率設定マスタメン（掛率優先管理パターン）DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        public RateProtyMngPatternDB()
        {

        }

        # region [Search]
        /// <summary>
        /// 掛率優先管理マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="outRateProtyMngList">検索結果</param>
        /// <param name="paraRateProtyMngWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率優先管理マスタ情報を取得します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/10</br>
        public int Search(out object outRateProtyMngList, object paraRateProtyMngWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;

            ArrayList _rateProtyMngList = null;
            RateProtyMngWork rateProtyMngWork = null;

            outRateProtyMngList = new CustomSerializeArrayList();

            try
            {
                rateProtyMngWork = paraRateProtyMngWork as RateProtyMngWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // 検索
                status = this.SearchProc(out _rateProtyMngList, rateProtyMngWork, readMode, logicalMode, ref sqlConnection);

                if (_rateProtyMngList != null)
                {
                    (outRateProtyMngList as CustomSerializeArrayList).AddRange(_rateProtyMngList);
                }

            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "RateProtyMngPatternDB.Search", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "RateProtyMngPatternDB.Search", status);
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 掛率優先管理マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="rateProtyMngList">検索結果</param>
        /// <param name="rateProtyMngWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率優先管理マスタ情報のリストを取得します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/10</br>
        private int SearchProc(out ArrayList rateProtyMngList, RateProtyMngWork rateProtyMngWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                StringBuilder sqlText = new StringBuilder();
                // コネクション生成
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                # region [SELECT文]
                sqlText.Append(" SELECT DISTINCT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, UNITPRICEKINDRF, RATESETTINGDIVIDERF, RATEPRIORITYORDERRF, RATEMNGGOODSCDRF, RATEMNGGOODSNMRF, RATEMNGCUSTCDRF, RATEMNGCUSTNMRF FROM RATEPROTYMNGRF WITH (READUNCOMMITTED) ");        // 掛率優先管理マスタ
                sqlCommand.CommandText += sqlText.ToString();
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, rateProtyMngWork, logicalMode);
                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToRateProtyMngWorkFromReader(ref myReader));
                }

                // 検索結果がある場合
                if (al.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "RateProtyMngPatternDB.SearchProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "RateProtyMngPatternDB.SearchProc", status);
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

            rateProtyMngList = al;

            return status;

        }

        /// <summary>
        /// 抽出条件によってで掛率掛率マスタとマスタを読み込み処理
        /// </summary>
        /// <param name="paraRateProtyMngPatternWork"></param>
        /// <param name="outNewList">新規リスト</param>
        /// <param name="outUpdateList">掛率マスタ(更新リスト)</param>
        /// <param name="patternMode">モード(0:BLコード;1:品番指定;2:品番指定;3:品番指定;4:商品掛率G指定;5:商品掛率G指定;6:商品掛率G指定;7:メーカー指定)</param>
        /// <param name="readMode">readMode</param>
        /// <param name="logicalMode">logicalMode</param>
        /// <returns>抽出状態</returns>
        /// <remarks>
        /// <br>Note       : 抽出条件によってで掛率掛率マスタとマスタを読み込みます。 </br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        public int SearchRateRelationData(out object outNewList, out object outUpdateList, object paraRateProtyMngPatternWork, int patternMode, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;

            ArrayList _newList = null;
            ArrayList _updateList = null;
            RateProtyMngPatternWork rateProtyMngPatternWork = null;

            outNewList = new CustomSerializeArrayList();
            outUpdateList = new CustomSerializeArrayList();

            try
            {
                rateProtyMngPatternWork = paraRateProtyMngPatternWork as RateProtyMngPatternWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // 検索
                status = this.SearchRateRelationDataProc(out _newList, out _updateList, rateProtyMngPatternWork, patternMode, readMode, logicalMode, ref sqlConnection);

                if (_newList != null)
                {
                    (outNewList as CustomSerializeArrayList).AddRange(_newList);
                }
                if (_updateList != null)
                {
                    (outUpdateList as CustomSerializeArrayList).AddRange(_updateList);
                }

            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "RateProtyMngPatternDB.SearchRateRelationData", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "RateProtyMngPatternDB.SearchRateRelationData", status);
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 抽出条件によってで掛率掛率マスタとマスタを読み込み処理
        /// </summary>
        /// <param name="newList">新規リスト</param>
        /// <param name="updateList">掛率マスタ(更新リスト)</param>
        /// <param name="rateProtyMngPatternWork">rateProtyMngPatternWork</param>
        /// <param name="patternMode">モード(0:BLコード;1:品番指定;2:単独指定;3:層別指定;4:商品掛率G指定;5:グループコード指定;6:メーカー指定)</param>
        /// <param name="readMode">readMode</param>
        /// <param name="logicalMode">logicalMode</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>抽出状態</returns>
        /// <remarks>
        /// <br>Note       : 抽出条件によってで掛率掛率マスタとマスタを読み込みます。 </br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/10</br>
        /// <br>Update Note: 2010/09/26 呉元嘯 Redmine#14490対応</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/06/18</br>
        /// </remarks>
        private int SearchRateRelationDataProc(out ArrayList newList, out ArrayList updateList, RateProtyMngPatternWork rateProtyMngPatternWork, int patternMode, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList _newList = new ArrayList();
            ArrayList _updateList = new ArrayList();
            //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
            // 変換情報呼び出し
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // 変換情報初期化
            convertDoubleRelease.ReleaseInitLib();
            //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
            try
            {
                string sqlText = string.Empty;
                // コネクション生成
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                #region パターンによって各々処理
                switch (patternMode)
                {
                    case 0:
                        #region パターン：BLコード
                        #region [掛率マスタ検索]
                        # region [SELECT文]
                        sqlText += "SELECT " + Environment.NewLine;
                        sqlText += "RATEU.GOODSMAKERCDRF, " + Environment.NewLine;// 商品メーカーコード
                        sqlText += "RATEU.GOODSNORF, " + Environment.NewLine;// 商品番号
                        sqlText += "RATEU.GOODSRATERANKRF, " + Environment.NewLine;// 層別
                        sqlText += "RATEU.GOODSRATEGRPCODERF, " + Environment.NewLine;// 商品掛率グループコード
                        sqlText += "RATEU.BLGROUPCODERF, " + Environment.NewLine;// BLグループコード
                        sqlText += "RATEU.CUSTOMERCODERF, " + Environment.NewLine;// 得意先コード
                        sqlText += "RATEU.CUSTRATEGRPCODERF, " + Environment.NewLine;// 得意先掛率グループコード
                        sqlText += "RATEU.SUPPLIERCDRF, " + Environment.NewLine;// 仕入先コード
                        sqlText += "RATEU.BLGOODSCODERF, " + Environment.NewLine;// BL商品コード
                        sqlText += "RATEU.LOTCOUNTRF, " + Environment.NewLine;// ロット数
                        sqlText += "RATEU.CREATEDATETIMERF, " + Environment.NewLine;// 作成日時
                        sqlText += "RATEU.UPDATEDATETIMERF, " + Environment.NewLine;// 更新日時
                        sqlText += "RATEU.FILEHEADERGUIDRF, " + Environment.NewLine;// GUID
                        sqlText += "RATEU.PRICEFLRF, " + Environment.NewLine;//価格（浮動）
                        sqlText += "RATEU.RATEVALRF, " + Environment.NewLine;//掛率
                        sqlText += "RATEU.UPRATERF, " + Environment.NewLine;// UP率
                        sqlText += "RATEU.UNPRCFRACPROCUNITRF, " + Environment.NewLine;// 単価端数処理単位
                        sqlText += "RATEU.UNPRCFRACPROCDIVRF, " + Environment.NewLine;// 単価端数処理区分
                        sqlText += "RATEU.GRSPROFITSECURERATERF, " + Environment.NewLine;// 粗利確保率
                        sqlText += "BLGOODSCDU.BLGOODSHALFNAMERF " + Environment.NewLine;// BL商品コード名称
                        sqlText += "FROM RATERF RATEU " + Environment.NewLine;
                        sqlText += " LEFT JOIN BLGOODSCDURF BLGOODSCDU " + Environment.NewLine;
                        sqlText += "ON RATEU.ENTERPRISECODERF = BLGOODSCDU.ENTERPRISECODERF " + Environment.NewLine;// BL商品コード
                        sqlText += "AND RATEU.LOGICALDELETECODERF = BLGOODSCDU.LOGICALDELETECODERF " + Environment.NewLine;// BL商品コード名称
                        sqlText += "AND RATEU.BLGOODSCODERF = BLGOODSCDU.BLGOODSCODERF " + Environment.NewLine;

                        sqlCommand.CommandText += sqlText.ToString();
                        sqlCommand.CommandText += MakeWhereString(ref sqlCommand, rateProtyMngPatternWork, logicalMode);
                        sqlCommand.CommandText += " ORDER BY " + Environment.NewLine;
                        sqlCommand.CommandText += " RATEU.BLGOODSCODERF" + Environment.NewLine;
                        # endregion

                        myReader = sqlCommand.ExecuteReader();

                        while (myReader.Read())
                        {
                            //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
                            //_updateList.Add(this.CopyToRateFromReader(ref myReader, patternMode));
                            _updateList.Add(this.CopyToRateFromReader(ref myReader, patternMode, convertDoubleRelease, rateProtyMngPatternWork.EnterpriseCode));
                            //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        #endregion [掛率マスタ検索]
                        // ----------------DEl 2010/09/09------------------->>>>>
                        //#region [BLコードマスタ検索]
                        //# region [SELECT文]
                        //myReader.Close();
                        //sqlCommand.CommandText = string.Empty;
                        //sqlText = "SELECT DISTINCT " + Environment.NewLine;
                        //sqlText += "BLGOODSCODERF, " + Environment.NewLine;// BL商品コード
                        //sqlText += "BLGOODSHALFNAMERF " + Environment.NewLine;// BL商品コード名称
                        //sqlText += "FROM BLGOODSCDURF" + Environment.NewLine;// BLコードマスタ
                        //sqlText += "WHERE ENTERPRISECODERF = @FINDENTERPRISECODE1 " + Environment.NewLine;
                        //sqlText += "AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE1 " + Environment.NewLine;
                        //sqlText += "AND NOT EXISTS " + Environment.NewLine;
                        //sqlText += "( SELECT * FROM RATERF " + Environment.NewLine;

                        //sqlCommand.CommandText += sqlText.ToString();
                        //sqlCommand.CommandText += MakeWhereStringTemp(ref sqlCommand, rateProtyMngPatternWork, logicalMode, patternMode);
                        //sqlCommand.CommandText += " ) ORDER BY BLGOODSCODERF " + Environment.NewLine;


                        //// 論理削除区分
                        //SqlParameter findLogicalDeleteCode1 = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE1", SqlDbType.Int);
                        //findLogicalDeleteCode1.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);

                        //// 企業コード
                        //SqlParameter paraEnterpriseCode1 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE1", SqlDbType.NChar);
                        //paraEnterpriseCode1.Value = SqlDataMediator.SqlSetString(rateProtyMngPatternWork.EnterpriseCode);
                        //# endregion

                        //myReader = sqlCommand.ExecuteReader();

                        //while (myReader.Read())
                        //{
                        //    _newList.Add(this.CopyToGoodsFromReader(ref myReader, rateProtyMngPatternWork, patternMode));
                        //}
                        //#endregion [BLコードマスタ検索]
                        // ----------------DEl 2010/09/09-------------------<<<<<

                        // --- ADD 2010/09/09 ---------->>>>>
                        for (int i = 0; i < 999; i++)
                        {
                            RateRlationWork rateRlationWork = this.CopyToGoodsFromReader(ref myReader, rateProtyMngPatternWork, patternMode);
                            _newList.Add(rateRlationWork);
                        }
                        // --- ADD 2010/09/09 ----------<<<<<

                        // 掛率マスタ或BLコードマスタ結果或場合
                        if (_newList.Count > 0 || _updateList.Count > 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            // --- ADD 2010/09/09 ---------->>>>>
                            if (_updateList.Count > 0)
                            {
                                int updCnt = _updateList.Count;
                                // ---------UPD 2010/09/26-------->>>>>
                                //for (int i = updCnt; i < 999; i++)
                                //{
                                //    _updateList.Add(this.CopyToGoodsFromReader(ref myReader, rateProtyMngPatternWork, patternMode));
                                //}
                                if (updCnt < 999)
                                {
                                    for (int i = updCnt; i < 999; i++)
                                    {
                                        _updateList.Add(this.CopyToGoodsFromReader(ref myReader, rateProtyMngPatternWork, patternMode));
                                    }
                                }
                                // ---------UPD 2010/09/26--------<<<<<
                            }
                            // --- ADD 2010/09/09 ----------<<<<<
                        }
                        else if (_newList.Count == 0 && _updateList.Count == 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                        #endregion
                        break;
                    case 1:
                        #region パターン：品番指定
                        #region [掛率マスタ検索]
                        # region [SELECT文]
                        sqlText += "SELECT " + Environment.NewLine;
                        sqlText += "RATEU.GOODSMAKERCDRF, " + Environment.NewLine;// 商品メーカーコード
                        sqlText += "RATEU.GOODSNORF, " + Environment.NewLine;// 商品番号
                        sqlText += "RATEU.GOODSRATERANKRF, " + Environment.NewLine;// 層別
                        sqlText += "RATEU.GOODSRATEGRPCODERF, " + Environment.NewLine;// 商品掛率グループコード
                        sqlText += "RATEU.BLGROUPCODERF, " + Environment.NewLine;// BLグループコード
                        sqlText += "RATEU.CUSTOMERCODERF, " + Environment.NewLine;// 得意先コード
                        sqlText += "RATEU.CUSTRATEGRPCODERF, " + Environment.NewLine;// 得意先掛率グループコード
                        sqlText += "RATEU.SUPPLIERCDRF, " + Environment.NewLine;// 仕入先コード
                        sqlText += "RATEU.BLGOODSCODERF, " + Environment.NewLine;// BL商品コード
                        sqlText += "RATEU.LOTCOUNTRF, " + Environment.NewLine;// ロット数
                        sqlText += "RATEU.CREATEDATETIMERF, " + Environment.NewLine;// 作成日時
                        sqlText += "RATEU.UPDATEDATETIMERF, " + Environment.NewLine;// 更新日時
                        sqlText += "RATEU.FILEHEADERGUIDRF, " + Environment.NewLine;// GUID
                        sqlText += "RATEU.PRICEFLRF, " + Environment.NewLine;//価格（浮動）
                        sqlText += "RATEU.RATEVALRF, " + Environment.NewLine;//掛率
                        sqlText += "RATEU.UPRATERF, " + Environment.NewLine;// UP率
                        sqlText += "RATEU.UNPRCFRACPROCUNITRF, " + Environment.NewLine;// 単価端数処理単位
                        sqlText += "RATEU.UNPRCFRACPROCDIVRF, " + Environment.NewLine;// 単価端数処理区分
                        sqlText += "RATEU.GRSPROFITSECURERATERF, " + Environment.NewLine;// 粗利確保率
                        sqlText += "GPU.LISTPRICERF AS LISTPRICERF, " + Environment.NewLine; // 標準価格
                        sqlText += "GPU.SALESUNITCOSTRF AS SALESUNITCOSTRF " + Environment.NewLine; // 原単価
                        sqlText += "FROM RATERF RATEU " + Environment.NewLine;
                        sqlText += " LEFT JOIN GOODSURF GOODSU " + Environment.NewLine;
                        sqlText += "ON RATEU.ENTERPRISECODERF = GOODSU.ENTERPRISECODERF " + Environment.NewLine;// 企業コード
                        sqlText += "AND RATEU.LOGICALDELETECODERF = GOODSU.LOGICALDELETECODERF " + Environment.NewLine;// 論理削除区分
                        sqlText += "AND RATEU.GOODSMAKERCDRF = GOODSU.GOODSMAKERCDRF " + Environment.NewLine;// メーカー
                        sqlText += "AND RATEU.GOODSNORF = GOODSU.GOODSNORF " + Environment.NewLine;// 商品番号
                        sqlText += "LEFT JOIN" + Environment.NewLine;
                        sqlText += "(" + Environment.NewLine;
                        sqlText += "SELECT B.PRICESTARTDATERF, B.ENTERPRISECODERF, B.GOODSMAKERCDRF, B.GOODSNORF , B.LOGICALDELETECODERF,A.LISTPRICERF, A.SALESUNITCOSTRF" + Environment.NewLine;
                        sqlText += "FROM GOODSPRICEURF A," + Environment.NewLine;
                        sqlText += "  (SELECT" + Environment.NewLine;
                        sqlText += "   MAX(PRICESTARTDATERF) PRICESTARTDATERF, ENTERPRISECODERF, GOODSMAKERCDRF,  GOODSNORF, LOGICALDELETECODERF " + Environment.NewLine;
                        sqlText += "  FROM" + Environment.NewLine;
                        sqlText += "   GOODSPRICEURF " + Environment.NewLine;
                        sqlText += "   WHERE PRICESTARTDATERF <= convert(varchar(100), getdate(), 112) " + Environment.NewLine;
                        sqlText += "   GROUP BY ENTERPRISECODERF, GOODSMAKERCDRF,  GOODSNORF, LOGICALDELETECODERF ) B" + Environment.NewLine;
                        sqlText += "WHERE A.ENTERPRISECODERF = B.ENTERPRISECODERF AND A.GOODSMAKERCDRF = B.GOODSMAKERCDRF AND A.GOODSNORF = B.GOODSNORF AND A.PRICESTARTDATERF = B.PRICESTARTDATERF" + Environment.NewLine;
                        sqlText += " ) AS GPU -- 価格マスタ（ユーザー登録分）" + Environment.NewLine;
                        sqlText += "ON RATEU.ENTERPRISECODERF = GPU.ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "AND RATEU.GOODSMAKERCDRF = GPU.GOODSMAKERCDRF" + Environment.NewLine;
                        sqlText += "AND RATEU.GOODSNORF = GPU.GOODSNORF" + Environment.NewLine;
                        sqlText += "AND GPU.LOGICALDELETECODERF=0" + Environment.NewLine;

                        sqlCommand.CommandText += sqlText.ToString();
                        sqlCommand.CommandText += MakeWhereString(ref sqlCommand, rateProtyMngPatternWork, logicalMode);
                        sqlCommand.CommandText += " ORDER BY " + Environment.NewLine;
                        sqlCommand.CommandText += " RATEU.GOODSNORF," + Environment.NewLine;
                        sqlCommand.CommandText += " RATEU.RATEVALRF," + Environment.NewLine;
                        sqlCommand.CommandText += " RATEU.PRICEFLRF," + Environment.NewLine;
                        sqlCommand.CommandText += " RATEU.GRSPROFITSECURERATERF" + Environment.NewLine;
                        # endregion

                        myReader = sqlCommand.ExecuteReader();

                        while (myReader.Read())
                        {
                            //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
                            //_updateList.Add(this.CopyToRateFromReader(ref myReader, patternMode));
                            _updateList.Add(this.CopyToRateFromReader(ref myReader, patternMode, convertDoubleRelease, rateProtyMngPatternWork.EnterpriseCode));
                            //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        #endregion [掛率マスタ検索]

                        // --- DEL 2010/09/09 ---------->>>>>
                        //#region [商品マスタ検索]
                        //# region [SELECT文]
                        //myReader.Close();
                        //sqlCommand.CommandText = string.Empty;
                        //sqlText = "SELECT DISTINCT " + Environment.NewLine;
                        //sqlText += "GOODSURF.GOODSNORF , " + Environment.NewLine;// 商品番号
                        //sqlText += "GPU.LISTPRICERF AS LISTPRICERF, " + Environment.NewLine; // 標準価格
                        //sqlText += "GPU.SALESUNITCOSTRF AS SALESUNITCOSTRF " + Environment.NewLine; // 原単価
                        //sqlText += "FROM GOODSURF" + Environment.NewLine;// 商品マスタ
                        //sqlText += "LEFT JOIN" + Environment.NewLine;
                        //sqlText += "(" + Environment.NewLine;
                        //sqlText += "SELECT B.PRICESTARTDATERF, B.ENTERPRISECODERF, B.GOODSMAKERCDRF, B.GOODSNORF , B.LOGICALDELETECODERF,A.LISTPRICERF, A.SALESUNITCOSTRF" + Environment.NewLine;
                        //sqlText += "FROM GOODSPRICEURF A," + Environment.NewLine;
                        //sqlText += "  (SELECT" + Environment.NewLine;
                        //sqlText += "   MAX(PRICESTARTDATERF) PRICESTARTDATERF, ENTERPRISECODERF, GOODSMAKERCDRF,  GOODSNORF, LOGICALDELETECODERF " + Environment.NewLine;
                        //sqlText += "  FROM" + Environment.NewLine;
                        //sqlText += "   GOODSPRICEURF " + Environment.NewLine;
                        //sqlText += "   WHERE PRICESTARTDATERF <= convert(varchar(100), getdate(), 112) " + Environment.NewLine;
                        //sqlText += "   GROUP BY ENTERPRISECODERF, GOODSMAKERCDRF,  GOODSNORF, LOGICALDELETECODERF ) B" + Environment.NewLine;
                        //sqlText += "WHERE A.ENTERPRISECODERF = B.ENTERPRISECODERF AND A.GOODSMAKERCDRF = B.GOODSMAKERCDRF AND A.GOODSNORF = B.GOODSNORF AND A.PRICESTARTDATERF = B.PRICESTARTDATERF" + Environment.NewLine;
                        //sqlText += " ) AS GPU -- 価格マスタ（ユーザー登録分）" + Environment.NewLine;
                        //sqlText += "ON GOODSURF.ENTERPRISECODERF = GPU.ENTERPRISECODERF" + Environment.NewLine;
                        //sqlText += "AND GOODSURF.GOODSMAKERCDRF = GPU.GOODSMAKERCDRF" + Environment.NewLine;
                        //sqlText += "AND GOODSURF.GOODSNORF = GPU.GOODSNORF" + Environment.NewLine;
                        //sqlText += "AND GPU.LOGICALDELETECODERF=0" + Environment.NewLine;
                        //sqlText += "WHERE GOODSURF.ENTERPRISECODERF = @FINDENTERPRISECODE3 " + Environment.NewLine;
                        //sqlText += "AND GOODSURF.LOGICALDELETECODERF = @FINDLOGICALDELETECODE3 " + Environment.NewLine;
                        //sqlText += "AND GOODSURF.GOODSMAKERCDRF = @FINDGOODSMAKERCDRF3 " + Environment.NewLine;
                        //sqlText += "AND NOT EXISTS " + Environment.NewLine;
                        //sqlText += "( SELECT * FROM RATERF " + Environment.NewLine;
                        //sqlCommand.CommandText += sqlText.ToString();
                        //sqlCommand.CommandText += MakeWhereStringTemp(ref sqlCommand, rateProtyMngPatternWork, logicalMode, patternMode);
                        //sqlCommand.CommandText += " ) ORDER BY GOODSNORF, " + Environment.NewLine;
                        //sqlCommand.CommandText += " LISTPRICERF, " + Environment.NewLine;
                        //sqlCommand.CommandText += " SALESUNITCOSTRF " + Environment.NewLine;

                        //// 論理削除区分
                        //SqlParameter findLogicalDeleteCode3 = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE3", SqlDbType.Int);
                        //findLogicalDeleteCode3.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);

                        //// 企業コード
                        //SqlParameter paraEnterpriseCode3 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE3", SqlDbType.NChar);
                        //paraEnterpriseCode3.Value = SqlDataMediator.SqlSetString(rateProtyMngPatternWork.EnterpriseCode);

                        //// 商品メーカーコード
                        //SqlParameter paraGoodsMakerCd3 = sqlCommand.Parameters.Add("@FINDGOODSMAKERCDRF3", SqlDbType.Int);
                        //paraGoodsMakerCd3.Value = SqlDataMediator.SqlSetInt32(rateProtyMngPatternWork.GoodsMakerCd);

                        //# endregion

                        //myReader = sqlCommand.ExecuteReader();

                        //while (myReader.Read())
                        //{
                        //    _newList.Add(this.CopyToGoodsFromReader(ref myReader, rateProtyMngPatternWork, patternMode));
                        //}

                        //#endregion [BLコードマスタ検索]
                        // --- DEL 2010/09/09 ----------<<<<<

                        // --- ADD 2010/09/09 ---------->>>>>
                        for (int i = 0; i < 999; i++)
                        {
                            RateRlationWork rateRlationWork = this.CopyToGoodsFromReader(ref myReader, rateProtyMngPatternWork, patternMode);
                            _newList.Add(rateRlationWork);
                        }
                        // --- ADD 2010/09/09 ----------<<<<<

                        // 掛率マスタ或BLコードマスタ結果或場合
                        if (_newList.Count > 0 || _updateList.Count > 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            // --- ADD 2010/09/10 ---------->>>>>
                            if (_updateList.Count > 0)
                            {
                                int updCnt = _updateList.Count;
                                // ---------UPD 2010/09/26-------->>>>>
                                //for (int i = updCnt; i < 999; i++)
                                //{
                                //    _updateList.Add(this.CopyToGoodsFromReader(ref myReader, rateProtyMngPatternWork, patternMode));
                                //}
                                if (updCnt < 999)
                                {
                                    for (int i = updCnt; i < 999; i++)
                                    {
                                        _updateList.Add(this.CopyToGoodsFromReader(ref myReader, rateProtyMngPatternWork, patternMode));
                                    }
                                }
                            }
                            // --- ADD 2010/09/10 ----------<<<<<
                        }
                        else if (_newList.Count == 0 && _updateList.Count == 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                        #endregion
                        break;
                    case 2:
                        #region パターン：単独指定
                        #region [マスタテープル指定]
                        // 掛率設定区分
                        _rateSettingDivide = rateProtyMngPatternWork.RateSettingDivide;
                        // 得意先の場合、得意先マストから検索する
                        if ("2L".Equals(_rateSettingDivide))
                        {
                            this._tableName = "CUSTOMERRF"; // 得意先マスタ
                            this._dataColumnCd = "CUSTOMERCODERF"; // 得意先コード
                            this._dataColumnCdMast = "CUSTOMERCODERF"; // 得意先コード
                            this._dataColumnNm = "CUSTOMERSNMRF"; // 得意先略称
                        }
                        // 得意先+仕入先,或は得意先掛率G+仕入先 の場合、仕入先マストから検索する
                        else if ("1L".Equals(_rateSettingDivide)
                            || "3L".Equals(_rateSettingDivide)
                            || "5L".Equals(_rateSettingDivide))
                        {
                            this._tableName = "SUPPLIERRF"; // 仕入先マスタ
                            this._dataColumnCd = "SUPPLIERCDRF"; // 仕入先コード
                            this._dataColumnCdMast = "SUPPLIERCDRF"; // 仕入先コード
                            this._dataColumnNm = "SUPPLIERSNMRF"; // 仕入先略称
                        }
                        // 得意先掛率Gの場合、得意先マスタ（掛率グループ）から検索する
                        else if ("4L".Equals(_rateSettingDivide))
                        {
                            this._tableName = "USERGDBDURF"; // 得意先マスタ（掛率グループ）
                            this._dataColumnCd = "CUSTRATEGRPCODERF"; // 得意先掛率グループコード
                            this._dataColumnCdMast = "GUIDECODERF"; // 得意先掛率グループコード
                            this._dataColumnNm = "GUIDENAMERF"; // 得意先掛率グループ名称
                        }
                        // BL商品コードの場合、BL商品コードから検索する
                        else if ("6H".Equals(_rateSettingDivide))
                        {
                            this._tableName = "BLGOODSCDURF"; //  BLコードマスタ
                            this._dataColumnCd = "BLGOODSCODERF"; //  BLコード
                            this._dataColumnCdMast = "BLGOODSCODERF"; //  BLコード
                            this._dataColumnNm = "BLGOODSHALFNAMERF"; // BLコード名称（半角）
                        }
                        // ｸﾞﾙｰﾌﾟｺｰﾄﾞの場合、ｸﾞﾙｰﾌﾟｺｰﾄﾞから検索する
                        else if ("6I".Equals(_rateSettingDivide))
                        {
                            this._tableName = "BLGROUPURF"; // 得意先マスタ（掛率グループ）
                            this._dataColumnCd = "BLGROUPCODERF"; // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                            this._dataColumnCdMast = "BLGROUPCODERF"; // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                            this._dataColumnNm = "BLGROUPKANANAMERF"; // BLグループコードカナ名称
                        }
                        // 中分類の場合、商品中分類マスタ（ユーザー登録）から検索する
                        else if ("6J".Equals(_rateSettingDivide))
                        {
                            this._tableName = "GOODSGROUPURF"; // 商品中分類マスタ（ユーザー登録分）
                            this._dataColumnCd = "GOODSRATEGRPCODERF"; // 商品中分類コード
                            this._dataColumnCdMast = "GOODSMGROUPRF"; // 商品中分類コード
                            this._dataColumnNm = "GOODSMGROUPNAMERF"; // 商品中分類名称
                        }
                        // メーカーの場合、メーカーから検索する
                        else if ("6K".Equals(_rateSettingDivide))
                        {
                            this._tableName = "MAKERURF"; // メーカーマスタ（ユーザー登録分）
                            this._dataColumnCd = "GOODSMAKERCDRF"; // メーカーコード
                            this._dataColumnCdMast = "GOODSMAKERCDRF"; // メーカーコード
                            //this._dataColumnNm = "MAKERKANANAMERF"; // メーカーカナ名称 // DEL 2010/09/10
                            this._dataColumnNm = "MAKERNAMERF"; // メーカー名称 // ADD 2010/09/10
                        }
                        #endregion[マスタテープル指定]

                        #region [掛率マスタ検索]
                        # region [SELECT文]
                        sqlText += "SELECT " + Environment.NewLine;
                        sqlText += "RATEU.GOODSMAKERCDRF, " + Environment.NewLine;// 商品メーカーコード
                        sqlText += "RATEU.GOODSNORF, " + Environment.NewLine;// 商品番号
                        sqlText += "RATEU.GOODSRATERANKRF, " + Environment.NewLine;// 層別
                        sqlText += "RATEU.GOODSRATEGRPCODERF, " + Environment.NewLine;// 商品掛率グループコード
                        sqlText += "RATEU.BLGROUPCODERF, " + Environment.NewLine;// BLグループコード
                        sqlText += "RATEU.CUSTOMERCODERF, " + Environment.NewLine;// 得意先コード
                        sqlText += "RATEU.CUSTRATEGRPCODERF, " + Environment.NewLine;// 得意先掛率グループコード
                        sqlText += "RATEU.SUPPLIERCDRF, " + Environment.NewLine;// 仕入先コード
                        sqlText += "RATEU.BLGOODSCODERF, " + Environment.NewLine;// BL商品コード
                        sqlText += "RATEU.LOTCOUNTRF, " + Environment.NewLine;// ロット数
                        sqlText += "RATEU.CREATEDATETIMERF, " + Environment.NewLine;// 作成日時
                        sqlText += "RATEU.UPDATEDATETIMERF, " + Environment.NewLine;// 更新日時
                        sqlText += "RATEU.FILEHEADERGUIDRF, " + Environment.NewLine;// GUID
                        sqlText += "RATEU.PRICEFLRF, " + Environment.NewLine;//価格（浮動）
                        sqlText += "RATEU.RATEVALRF, " + Environment.NewLine;//掛率
                        sqlText += "RATEU.UPRATERF, " + Environment.NewLine;// UP率
                        sqlText += "RATEU.UNPRCFRACPROCUNITRF, " + Environment.NewLine;// 単価端数処理単位
                        sqlText += "RATEU.UNPRCFRACPROCDIVRF, " + Environment.NewLine;// 単価端数処理区分
                        sqlText += "RATEU.GRSPROFITSECURERATERF, " + Environment.NewLine;// 粗利確保率
                        sqlText += _tableName + "." + _dataColumnNm+ Environment.NewLine;// コード名称
                        sqlText += "FROM RATERF RATEU " + Environment.NewLine;

                        if ("2L".Equals(_rateSettingDivide))
                        {
                            sqlText += " LEFT JOIN CUSTOMERRF" + Environment.NewLine;
                            sqlText += "ON RATEU.ENTERPRISECODERF = CUSTOMERRF.ENTERPRISECODERF " + Environment.NewLine;// BL商品コード
                            sqlText += "AND RATEU.LOGICALDELETECODERF = CUSTOMERRF.LOGICALDELETECODERF " + Environment.NewLine;// BL商品コード名称
                            sqlText += "AND RATEU.CUSTOMERCODERF = CUSTOMERRF.CUSTOMERCODERF " + Environment.NewLine;
                        }
                        // 得意先+仕入先,或は得意先掛率G+仕入先 の場合、仕入先マストから検索する
                        else if ("1L".Equals(_rateSettingDivide) 
                            || "3L".Equals(_rateSettingDivide)
                            || "5L".Equals(_rateSettingDivide))
                        {
                            sqlText += " LEFT JOIN SUPPLIERRF " + Environment.NewLine;
                            sqlText += "ON RATEU.ENTERPRISECODERF = SUPPLIERRF.ENTERPRISECODERF " + Environment.NewLine;// BL商品コード
                            sqlText += "AND RATEU.LOGICALDELETECODERF = SUPPLIERRF.LOGICALDELETECODERF " + Environment.NewLine;// BL商品コード名称
                            sqlText += "AND RATEU.SUPPLIERCDRF = SUPPLIERRF.SUPPLIERCDRF " + Environment.NewLine;
                        }
                        // 得意先掛率Gの場合、ユーザーガイドから検索する
                        else if ("4L".Equals(_rateSettingDivide))
                        {
                            sqlText += " LEFT JOIN USERGDBDURF " + Environment.NewLine;
                            sqlText += "ON RATEU.ENTERPRISECODERF = USERGDBDURF.ENTERPRISECODERF " + Environment.NewLine;// BL商品コード
                            sqlText += "AND RATEU.LOGICALDELETECODERF = USERGDBDURF.LOGICALDELETECODERF " + Environment.NewLine;// BL商品コード名称
                            sqlText += "AND RATEU.CUSTRATEGRPCODERF = USERGDBDURF.GUIDECODERF " + Environment.NewLine;
                            sqlText += "AND USERGDBDURF.USERGUIDEDIVCDRF = @FINDUSERGUIDEDIVCD " + Environment.NewLine;

                            // USERGUIDEDIVCDRF
                            SqlParameter findUserGuidEDiv = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD", SqlDbType.Int);
                            findUserGuidEDiv.Value = SqlDataMediator.SqlSetInt32(43);

                        }
                        // BL商品コードの場合、BL商品コードから検索する
                        else if ("6H".Equals(_rateSettingDivide))
                        {
                            sqlText += " LEFT JOIN BLGOODSCDURF " + Environment.NewLine;
                            sqlText += "ON RATEU.ENTERPRISECODERF = BLGOODSCDURF.ENTERPRISECODERF " + Environment.NewLine;// BL商品コード
                            sqlText += "AND RATEU.LOGICALDELETECODERF = BLGOODSCDURF.LOGICALDELETECODERF " + Environment.NewLine;// BL商品コード名称
                            sqlText += "AND RATEU.BLGOODSCODERF = BLGOODSCDURF.BLGOODSCODERF " + Environment.NewLine;
                        }
                        // ｸﾞﾙｰﾌﾟｺｰﾄﾞの場合、ｸﾞﾙｰﾌﾟｺｰﾄﾞから検索する
                        else if ("6I".Equals(_rateSettingDivide))
                        {
                            sqlText += " LEFT JOIN BLGROUPURF " + Environment.NewLine;
                            sqlText += "ON RATEU.ENTERPRISECODERF = BLGROUPURF.ENTERPRISECODERF " + Environment.NewLine;// BL商品コード
                            sqlText += "AND RATEU.LOGICALDELETECODERF = BLGROUPURF.LOGICALDELETECODERF " + Environment.NewLine;// BL商品コード名称
                            sqlText += "AND RATEU.BLGROUPCODERF = BLGROUPURF.BLGROUPCODERF " + Environment.NewLine;
                        }
                        // 中分類の場合、商品中分類マスタ（ユーザー登録）から検索する
                        else if ("6J".Equals(_rateSettingDivide))
                        {
                            sqlText += " LEFT JOIN GOODSGROUPURF " + Environment.NewLine;
                            sqlText += "ON RATEU.ENTERPRISECODERF = GOODSGROUPURF.ENTERPRISECODERF " + Environment.NewLine;// BL商品コード
                            sqlText += "AND RATEU.LOGICALDELETECODERF = GOODSGROUPURF.LOGICALDELETECODERF " + Environment.NewLine;// BL商品コード名称
                            sqlText += "AND RATEU.GOODSRATEGRPCODERF = GOODSGROUPURF.GOODSMGROUPRF " + Environment.NewLine;
                        }
                        // メーカーの場合、メーカーから検索する
                        else if ("6K".Equals(_rateSettingDivide))
                        {
                            sqlText += " LEFT JOIN MAKERURF " + Environment.NewLine;
                            sqlText += "ON RATEU.ENTERPRISECODERF = MAKERURF.ENTERPRISECODERF " + Environment.NewLine;// BL商品コード
                            sqlText += "AND RATEU.LOGICALDELETECODERF = MAKERURF.LOGICALDELETECODERF " + Environment.NewLine;// BL商品コード名称
                            sqlText += "AND RATEU.GOODSMAKERCDRF = MAKERURF.GOODSMAKERCDRF " + Environment.NewLine;
                        } 

                        sqlCommand.CommandText += sqlText.ToString();
                        sqlCommand.CommandText += MakeWhereString(ref sqlCommand, rateProtyMngPatternWork, logicalMode);
                        sqlCommand.CommandText += " ORDER BY " + Environment.NewLine;
                        sqlCommand.CommandText += " RATEU." + this._dataColumnCd + "," + Environment.NewLine;
                        sqlCommand.CommandText += " RATEU.RATEVALRF," + Environment.NewLine;
                        sqlCommand.CommandText += " RATEU.PRICEFLRF," + Environment.NewLine;
                        sqlCommand.CommandText += " RATEU.GRSPROFITSECURERATERF" + Environment.NewLine;
                        # endregion

                        myReader = sqlCommand.ExecuteReader();

                        while (myReader.Read())
                        {
                            //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
                            //_updateList.Add(this.CopyToRateFromReader(ref myReader, patternMode));
                            _updateList.Add(this.CopyToRateFromReader(ref myReader, patternMode, convertDoubleRelease, rateProtyMngPatternWork.EnterpriseCode));
                            //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        #endregion [掛率マスタ検索]

                        // --- DEL 2010/09/10 ---------->>>>>
                        //#region [マスタ検索]
                        //# region [SELECT文]
                        //myReader.Close();
                        //sqlCommand.CommandText = string.Empty;
                        //sqlText = "SELECT DISTINCT " + Environment.NewLine;
                        //sqlText += _dataColumnCdMast + ", " + Environment.NewLine;// コード
                        //sqlText += _dataColumnNm  + Environment.NewLine;// 名称
                        //sqlText += "FROM " + _tableName  + Environment.NewLine;// マスタ
                        //sqlText += "WHERE ENTERPRISECODERF = @FINDENTERPRISECODE1 " + Environment.NewLine;
                        //sqlText += "AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE1 " + Environment.NewLine;
                        //if ("4L".Equals(_rateSettingDivide))
                        //{
                        //    sqlText += "AND USERGUIDEDIVCDRF = @FINDUSERGUIDEDIVCD " + Environment.NewLine;

                        //    // USERGUIDEDIVCDRF
                        //    SqlParameter findUserGuidEDivMast = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD1", SqlDbType.Int);
                        //    findUserGuidEDivMast.Value = SqlDataMediator.SqlSetInt32(43);
                        //}
                        //sqlText += "AND NOT EXISTS " + Environment.NewLine;
                        //sqlText += "( SELECT * FROM RATERF " + Environment.NewLine;

                        //sqlCommand.CommandText += sqlText.ToString();
                        //sqlCommand.CommandText += MakeWhereStringTemp(ref sqlCommand, rateProtyMngPatternWork, logicalMode, patternMode);
                        //sqlCommand.CommandText += " ) ORDER BY " + _dataColumnCdMast + Environment.NewLine;

                        //// 論理削除区分
                        //SqlParameter findLogicalDeleteCodeMast = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE1", SqlDbType.Int);
                        //findLogicalDeleteCodeMast.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);

                        //// 企業コード
                        //SqlParameter paraEnterpriseCodeMast = sqlCommand.Parameters.Add("@FINDENTERPRISECODE1", SqlDbType.NChar);
                        //paraEnterpriseCodeMast.Value = SqlDataMediator.SqlSetString(rateProtyMngPatternWork.EnterpriseCode);

                        //# endregion

                        //myReader = sqlCommand.ExecuteReader();

                        //while (myReader.Read())
                        //{
                        //    _newList.Add(this.CopyToGoodsFromReader(ref myReader, rateProtyMngPatternWork, patternMode));
                        //}

                        //#endregion [マスタ検索]
                        // --- DEL 2010/09/10 ----------<<<<<

                        // --- ADD 2010/09/10 ---------->>>>>
                        for (int i = 0; i < 999; i++)
                        {
                            RateRlationWork rateRlationWork = this.CopyToGoodsFromReader(ref myReader, rateProtyMngPatternWork, patternMode);
                            _newList.Add(rateRlationWork);
                        }
                        // --- ADD 2010/09/10 ----------<<<<<

                        // 掛率マスタ或其の他マスタ結果或場合
                        if (_newList.Count > 0 || _updateList.Count > 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            // --- ADD 2010/09/10 ---------->>>>>
                            if (_updateList.Count > 0)
                            {
                                int updCnt = _updateList.Count;
                                // ---------UPD 2010/09/26-------->>>>>
                                //for (int i = updCnt; i < 999; i++)
                                //{
                                //    _updateList.Add(this.CopyToGoodsFromReader(ref myReader, rateProtyMngPatternWork, patternMode));
                                //}
                                if (updCnt < 999)
                                {
                                    for (int i = updCnt; i < 999; i++)
                                    {
                                        _updateList.Add(this.CopyToGoodsFromReader(ref myReader, rateProtyMngPatternWork, patternMode));
                                    }
                                }
                            }
                            // --- ADD 2010/09/10 ----------<<<<<
                        }
                        else if (_newList.Count == 0 && _updateList.Count == 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                        #endregion
                        break;
                    case 3:
                        #region パターン：層別指定
                        #region [掛率マスタ検索]
                        # region [SELECT文]
                        sqlText += "SELECT " + Environment.NewLine;
                        sqlText += "RATEU.GOODSMAKERCDRF, " + Environment.NewLine;// 商品メーカーコード
                        sqlText += "RATEU.GOODSNORF, " + Environment.NewLine;// 商品番号
                        sqlText += "RATEU.GOODSRATERANKRF, " + Environment.NewLine;// 層別
                        sqlText += "RATEU.GOODSRATEGRPCODERF, " + Environment.NewLine;// 商品掛率グループコード
                        sqlText += "RATEU.BLGROUPCODERF, " + Environment.NewLine;// BLグループコード
                        sqlText += "RATEU.CUSTOMERCODERF, " + Environment.NewLine;// 得意先コード
                        sqlText += "RATEU.CUSTRATEGRPCODERF, " + Environment.NewLine;// 得意先掛率グループコード
                        sqlText += "RATEU.SUPPLIERCDRF, " + Environment.NewLine;// 仕入先コード
                        sqlText += "RATEU.BLGOODSCODERF, " + Environment.NewLine;// BL商品コード
                        sqlText += "RATEU.LOTCOUNTRF, " + Environment.NewLine;// ロット数
                        sqlText += "RATEU.CREATEDATETIMERF, " + Environment.NewLine;// 作成日時
                        sqlText += "RATEU.UPDATEDATETIMERF, " + Environment.NewLine;// 更新日時
                        sqlText += "RATEU.FILEHEADERGUIDRF, " + Environment.NewLine;// GUID
                        sqlText += "RATEU.PRICEFLRF, " + Environment.NewLine;//価格（浮動）
                        sqlText += "RATEU.RATEVALRF, " + Environment.NewLine;//掛率
                        sqlText += "RATEU.UPRATERF, " + Environment.NewLine;// UP率
                        sqlText += "RATEU.UNPRCFRACPROCUNITRF, " + Environment.NewLine;// 単価端数処理単位
                        sqlText += "RATEU.UNPRCFRACPROCDIVRF, " + Environment.NewLine;// 単価端数処理区分
                        sqlText += "RATEU.GRSPROFITSECURERATERF " + Environment.NewLine;// 粗利確保率
                        sqlText += "FROM RATERF RATEU " + Environment.NewLine;

                        sqlCommand.CommandText += sqlText.ToString();
                        sqlCommand.CommandText += MakeWhereString(ref sqlCommand, rateProtyMngPatternWork, logicalMode);
                        sqlCommand.CommandText += " ORDER BY " + Environment.NewLine;
                        sqlCommand.CommandText += " RATEU.GOODSRATERANKRF" + Environment.NewLine;
                        # endregion
                        myReader = sqlCommand.ExecuteReader();

                        while (myReader.Read())
                        {
                            //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
                            //_updateList.Add(this.CopyToRateFromReader(ref myReader, patternMode));
                            _updateList.Add(this.CopyToRateFromReader(ref myReader, patternMode, convertDoubleRelease, rateProtyMngPatternWork.EnterpriseCode));
                            //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        #endregion [掛率マスタ検索]

                        for (int i = 0; i < 999; i++)
                        {
                            _newList.Add(this.CopyToGoodsFromReader(ref myReader, rateProtyMngPatternWork, patternMode));
                        }

                        if (_newList.Count > 0 || _updateList.Count > 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            // --- ADD 2010/09/10 ---------->>>>>
                            if (_updateList.Count > 0)
                            {
                                int updCnt = _updateList.Count;
                                // ---------UPD 2010/09/26-------->>>>>
                                //for (int i = updCnt; i < 999; i++)
                                //{
                                //    _updateList.Add(this.CopyToGoodsFromReader(ref myReader, rateProtyMngPatternWork, patternMode));
                                //}
                                if (updCnt < 999)
                                {
                                    for (int i = updCnt; i < 999; i++)
                                    {
                                        _updateList.Add(this.CopyToGoodsFromReader(ref myReader, rateProtyMngPatternWork, patternMode));
                                    }
                                }
                            }
                            // --- ADD 2010/09/10 ----------<<<<<
                        }
                        else if (_newList.Count == 0 && _updateList.Count == 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                        #endregion
                            break;
                    case 4:
                        #region パターン：商品掛率G指定
                        #region [掛率マスタ検索]
                        # region [SELECT文]
                        sqlText += "SELECT " + Environment.NewLine;
                        sqlText += "RATEU.GOODSMAKERCDRF, " + Environment.NewLine;// 商品メーカーコード
                        sqlText += "RATEU.GOODSNORF, " + Environment.NewLine;// 商品番号
                        sqlText += "RATEU.GOODSRATERANKRF, " + Environment.NewLine;// 層別
                        sqlText += "RATEU.GOODSRATEGRPCODERF, " + Environment.NewLine;// 商品掛率グループコード
                        sqlText += "RATEU.BLGROUPCODERF, " + Environment.NewLine;// BLグループコード
                        sqlText += "RATEU.CUSTOMERCODERF, " + Environment.NewLine;// 得意先コード
                        sqlText += "RATEU.CUSTRATEGRPCODERF, " + Environment.NewLine;// 得意先掛率グループコード
                        sqlText += "RATEU.SUPPLIERCDRF, " + Environment.NewLine;// 仕入先コード
                        sqlText += "RATEU.BLGOODSCODERF, " + Environment.NewLine;// BL商品コード
                        sqlText += "RATEU.LOTCOUNTRF, " + Environment.NewLine;// ロット数
                        sqlText += "RATEU.CREATEDATETIMERF, " + Environment.NewLine;// 作成日時
                        sqlText += "RATEU.UPDATEDATETIMERF, " + Environment.NewLine;// 更新日時
                        sqlText += "RATEU.FILEHEADERGUIDRF, " + Environment.NewLine;// GUID
                        sqlText += "RATEU.PRICEFLRF, " + Environment.NewLine;//価格（浮動）
                        sqlText += "RATEU.RATEVALRF, " + Environment.NewLine;//掛率
                        sqlText += "RATEU.UPRATERF, " + Environment.NewLine;// UP率
                        sqlText += "RATEU.UNPRCFRACPROCUNITRF, " + Environment.NewLine;// 単価端数処理単位
                        sqlText += "RATEU.UNPRCFRACPROCDIVRF, " + Environment.NewLine;// 単価端数処理区分
                        sqlText += "RATEU.GRSPROFITSECURERATERF, " + Environment.NewLine;// 粗利確保率
                        sqlText += "GOODSGROUP.GOODSMGROUPNAMERF " + Environment.NewLine;// 商品掛率ｸﾞﾙｰﾌﾟ
                        sqlText += "FROM RATERF RATEU " + Environment.NewLine;
                        sqlText += " LEFT JOIN GOODSGROUPURF GOODSGROUP " + Environment.NewLine;
                        sqlText += "ON RATEU.ENTERPRISECODERF = GOODSGROUP.ENTERPRISECODERF " + Environment.NewLine;// 企業コード
                        sqlText += "AND RATEU.LOGICALDELETECODERF = GOODSGROUP.LOGICALDELETECODERF " + Environment.NewLine;// 論理削除フラグ
                        sqlText += "AND RATEU.GOODSRATEGRPCODERF = GOODSGROUP.GOODSMGROUPRF " + Environment.NewLine;// 商品中分類ｺｰﾄﾞ

                        sqlCommand.CommandText += sqlText.ToString();
                        sqlCommand.CommandText += MakeWhereString(ref sqlCommand, rateProtyMngPatternWork, logicalMode);
                        sqlCommand.CommandText += " ORDER BY " + Environment.NewLine;
                        sqlCommand.CommandText += " RATEU.GOODSRATEGRPCODERF," + Environment.NewLine;
                        sqlCommand.CommandText += " RATEU.RATEVALRF," + Environment.NewLine;
                        sqlCommand.CommandText += " RATEU.PRICEFLRF," + Environment.NewLine;
                        sqlCommand.CommandText += " RATEU.GRSPROFITSECURERATERF" + Environment.NewLine;
                        # endregion

                        myReader = sqlCommand.ExecuteReader();

                        while (myReader.Read())
                        {
                            //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
                            //_updateList.Add(this.CopyToRateFromReader(ref myReader, patternMode));
                            _updateList.Add(this.CopyToRateFromReader(ref myReader, patternMode, convertDoubleRelease, rateProtyMngPatternWork.EnterpriseCode));
                            //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        #endregion [掛率マスタ検索]

                        // --- DEL 2010/09/09 ---------->>>>>
                        //#region [商品中分類マスタ検索]
                        //# region [SELECT文]
                        //myReader.Close();
                        //sqlCommand.CommandText = string.Empty;
                        //sqlText = "SELECT DISTINCT " + Environment.NewLine;
                        //sqlText += "GOODSMGROUPRF, " + Environment.NewLine;// 商品中分類コード
                        //sqlText += "GOODSMGROUPNAMERF " + Environment.NewLine;// 商品中分類名称
                        //sqlText += "FROM GOODSGROUPURF" + Environment.NewLine;// BLコードマスタ
                        //sqlText += "WHERE ENTERPRISECODERF = @FINDENTERPRISECODE4 " + Environment.NewLine;
                        //sqlText += "AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE4 " + Environment.NewLine;
                        //sqlText += "AND NOT EXISTS " + Environment.NewLine;
                        //sqlText += "( SELECT * FROM RATERF " + Environment.NewLine;

                        //sqlCommand.CommandText += sqlText.ToString();
                        //sqlCommand.CommandText += MakeWhereStringTemp(ref sqlCommand, rateProtyMngPatternWork, logicalMode, patternMode);
                        //sqlCommand.CommandText += " ) ORDER BY GOODSMGROUPRF " + Environment.NewLine;

                        //// 論理削除区分
                        //SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE4", SqlDbType.Int);
                        //findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);

                        //// 企業コード
                        //SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE4", SqlDbType.NChar);
                        //paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateProtyMngPatternWork.EnterpriseCode);

                        //# endregion

                        //myReader = sqlCommand.ExecuteReader();

                        //while (myReader.Read())
                        //{
                        //    _newList.Add(this.CopyToGoodsFromReader(ref myReader, rateProtyMngPatternWork, patternMode));
                        //}

                        //#endregion [BLコードマスタ検索]
                        // --- DEL 2010/09/09 ----------<<<<<

                        // --- ADD 2010/09/09 ---------->>>>>
                        for (int i = 0; i < 999; i++)
                        {
                            RateRlationWork rateRlationWork = this.CopyToGoodsFromReader(ref myReader, rateProtyMngPatternWork, patternMode);
                            _newList.Add(rateRlationWork);
                        }
                        // --- ADD 2010/09/09 ----------<<<<<

                        // 掛率マスタ或BLコードマスタ結果或場合
                        if (_newList.Count > 0 || _updateList.Count > 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            // --- ADD 2010/09/10 ---------->>>>>
                            if (_updateList.Count > 0)
                            {
                                int updCnt = _updateList.Count;
                                // ---------UPD 2010/09/26-------->>>>>
                                //for (int i = updCnt; i < 999; i++)
                                //{
                                //    _updateList.Add(this.CopyToGoodsFromReader(ref myReader, rateProtyMngPatternWork, patternMode));
                                //}
                                if (updCnt < 999)
                                {
                                    for (int i = updCnt; i < 999; i++)
                                    {
                                        _updateList.Add(this.CopyToGoodsFromReader(ref myReader, rateProtyMngPatternWork, patternMode));
                                    }
                                }
                            }
                            // --- ADD 2010/09/10 ----------<<<<<
                        }
                        else if (_newList.Count == 0 && _updateList.Count == 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                        #endregion
                        break;
                    case 5:
                        #region パターン：グループコード指定
                        #region [掛率マスタ検索]
                        # region [SELECT文]
                        sqlText += "SELECT " + Environment.NewLine;
                        sqlText += "RATEU.GOODSMAKERCDRF, " + Environment.NewLine;// 商品メーカーコード
                        sqlText += "RATEU.GOODSNORF, " + Environment.NewLine;// 商品番号
                        sqlText += "RATEU.GOODSRATERANKRF, " + Environment.NewLine;// 層別
                        sqlText += "RATEU.GOODSRATEGRPCODERF, " + Environment.NewLine;// 商品掛率グループコード
                        sqlText += "RATEU.BLGROUPCODERF, " + Environment.NewLine;// BLグループコード
                        sqlText += "RATEU.CUSTOMERCODERF, " + Environment.NewLine;// 得意先コード
                        sqlText += "RATEU.CUSTRATEGRPCODERF, " + Environment.NewLine;// 得意先掛率グループコード
                        sqlText += "RATEU.SUPPLIERCDRF, " + Environment.NewLine;// 仕入先コード
                        sqlText += "RATEU.BLGOODSCODERF, " + Environment.NewLine;// BL商品コード
                        sqlText += "RATEU.LOTCOUNTRF, " + Environment.NewLine;// ロット数
                        sqlText += "RATEU.CREATEDATETIMERF, " + Environment.NewLine;// 作成日時
                        sqlText += "RATEU.UPDATEDATETIMERF, " + Environment.NewLine;// 更新日時
                        sqlText += "RATEU.FILEHEADERGUIDRF, " + Environment.NewLine;// GUID
                        sqlText += "RATEU.PRICEFLRF, " + Environment.NewLine;//価格（浮動）
                        sqlText += "RATEU.RATEVALRF, " + Environment.NewLine;//掛率
                        sqlText += "RATEU.UPRATERF, " + Environment.NewLine;// UP率
                        sqlText += "RATEU.UNPRCFRACPROCUNITRF, " + Environment.NewLine;// 単価端数処理単位
                        sqlText += "RATEU.UNPRCFRACPROCDIVRF, " + Environment.NewLine;// 単価端数処理区分
                        sqlText += "RATEU.GRSPROFITSECURERATERF, " + Environment.NewLine;// 粗利確保率
                        sqlText += "BLGROUPU.BLGROUPNAMERF " + Environment.NewLine;// BLグループコード名称 // UPP 2010/09/13
                        sqlText += "FROM RATERF RATEU " + Environment.NewLine;
                        sqlText += " LEFT JOIN BLGROUPURF BLGROUPU " + Environment.NewLine;
                        sqlText += "ON RATEU.ENTERPRISECODERF = BLGROUPU.ENTERPRISECODERF " + Environment.NewLine;// BL商品コード
                        sqlText += "AND RATEU.LOGICALDELETECODERF = BLGROUPU.LOGICALDELETECODERF " + Environment.NewLine;// BL商品コード名称
                        sqlText += "AND RATEU.BLGROUPCODERF = BLGROUPU.BLGROUPCODERF " + Environment.NewLine;

                        sqlCommand.CommandText += sqlText.ToString();
                        sqlCommand.CommandText += MakeWhereString(ref sqlCommand, rateProtyMngPatternWork, logicalMode);
                        sqlCommand.CommandText += " ORDER BY " + Environment.NewLine;
                        sqlCommand.CommandText += " RATEU.BLGOODSCODERF," + Environment.NewLine;
                        sqlCommand.CommandText += " RATEU.RATEVALRF," + Environment.NewLine;
                        sqlCommand.CommandText += " RATEU.PRICEFLRF," + Environment.NewLine;
                        sqlCommand.CommandText += " RATEU.GRSPROFITSECURERATERF" + Environment.NewLine;
                        # endregion

                        myReader = sqlCommand.ExecuteReader();

                        while (myReader.Read())
                        {
                            //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
                            //_updateList.Add(this.CopyToRateFromReader(ref myReader, patternMode));
                            _updateList.Add(this.CopyToRateFromReader(ref myReader, patternMode, convertDoubleRelease, rateProtyMngPatternWork.EnterpriseCode));
                            //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        #endregion [掛率マスタ検索]
                        // --- DEL 2010/09/13 ---------->>>>>
                        //#region [BLグループマスタ検索]
                        //# region [SELECT文]
                        //myReader.Close();
                        //sqlCommand.CommandText = string.Empty;
                        //sqlText = "SELECT DISTINCT " + Environment.NewLine;
                        //sqlText += "BLGROUPCODERF, " + Environment.NewLine;// BL商品コード
                        //sqlText += "BLGROUPKANANAMERF " + Environment.NewLine;// BL商品コード名称
                        //sqlText += "FROM BLGROUPURF" + Environment.NewLine;// BLコードマスタ
                        //sqlText += "WHERE ENTERPRISECODERF = @FINDENTERPRISECODE2 " + Environment.NewLine;
                        //sqlText += "AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE2 " + Environment.NewLine;
                        //sqlText += "AND NOT EXISTS " + Environment.NewLine;
                        //sqlText += "( SELECT * FROM RATERF " + Environment.NewLine;

                        //sqlCommand.CommandText += sqlText.ToString();
                        //sqlCommand.CommandText += MakeWhereStringTemp(ref sqlCommand, rateProtyMngPatternWork, logicalMode, patternMode);
                        //sqlCommand.CommandText += " ) ORDER BY BLGROUPCODERF " + Environment.NewLine;

                        //// 論理削除区分
                        //SqlParameter findLogicalDeleteCode2 = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE2", SqlDbType.Int);
                        //findLogicalDeleteCode2.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);

                        //// 企業コード
                        //SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE2", SqlDbType.NChar);
                        //paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(rateProtyMngPatternWork.EnterpriseCode);
                        //# endregion

                        //myReader = sqlCommand.ExecuteReader();

                        //while (myReader.Read())
                        //{
                        //    _newList.Add(this.CopyToGoodsFromReader(ref myReader, rateProtyMngPatternWork, patternMode));
                        //}

                        //#endregion [BLグループマスタ検索]
                        // --- DEL 2010/09/13 ----------<<<<<

                        // --- ADD 2010/09/13 ---------->>>>>
                        for (int i = 0; i < 999; i++)
                        {
                            RateRlationWork rateRlationWork = this.CopyToGoodsFromReader(ref myReader, rateProtyMngPatternWork, patternMode);
                            _newList.Add(rateRlationWork);
                        }
                        // --- ADD 2010/09/13 ----------<<<<<
                        // 掛率マスタ或BLコードマスタ結果或場合
                        if (_newList.Count > 0 || _updateList.Count > 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            // --- ADD 2010/09/10 ---------->>>>>
                            if (_updateList.Count > 0)
                            {
                                int updCnt = _updateList.Count;
                                // ---------UPD 2010/09/26-------->>>>>
                                //for (int i = updCnt; i < 999; i++)
                                //{
                                //    _updateList.Add(this.CopyToGoodsFromReader(ref myReader, rateProtyMngPatternWork, patternMode));
                                //}
                                if (updCnt < 999)
                                {
                                    for (int i = updCnt; i < 999; i++)
                                    {
                                        _updateList.Add(this.CopyToGoodsFromReader(ref myReader, rateProtyMngPatternWork, patternMode));
                                    }
                                }
                            }
                            // --- ADD 2010/09/10 ----------<<<<<
                        }
                        else if (_newList.Count == 0 && _updateList.Count == 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                        #endregion
                        break;
                    case 6:
                        #region パターン：メーカー指定
                        #region [掛率マスタ検索]
                        # region [SELECT文]
                        sqlText += "SELECT " + Environment.NewLine;
                        sqlText += "RATEU.GOODSMAKERCDRF, " + Environment.NewLine;// 商品メーカーコード
                        sqlText += "RATEU.GOODSNORF, " + Environment.NewLine;// 商品番号
                        sqlText += "RATEU.GOODSRATERANKRF, " + Environment.NewLine;// 層別
                        sqlText += "RATEU.GOODSRATEGRPCODERF, " + Environment.NewLine;// 商品掛率グループコード
                        sqlText += "RATEU.BLGROUPCODERF, " + Environment.NewLine;// BLグループコード
                        sqlText += "RATEU.CUSTOMERCODERF, " + Environment.NewLine;// 得意先コード
                        sqlText += "RATEU.CUSTRATEGRPCODERF, " + Environment.NewLine;// 得意先掛率グループコード
                        sqlText += "RATEU.SUPPLIERCDRF, " + Environment.NewLine;// 仕入先コード
                        sqlText += "RATEU.BLGOODSCODERF, " + Environment.NewLine;// BL商品コード
                        sqlText += "RATEU.LOTCOUNTRF, " + Environment.NewLine;// ロット数
                        sqlText += "RATEU.CREATEDATETIMERF, " + Environment.NewLine;// 作成日時
                        sqlText += "RATEU.UPDATEDATETIMERF, " + Environment.NewLine;// 更新日時
                        sqlText += "RATEU.FILEHEADERGUIDRF, " + Environment.NewLine;// GUID
                        sqlText += "RATEU.PRICEFLRF, " + Environment.NewLine;//価格（浮動）
                        sqlText += "RATEU.RATEVALRF, " + Environment.NewLine;//掛率
                        sqlText += "RATEU.UPRATERF, " + Environment.NewLine;// UP率
                        sqlText += "RATEU.UNPRCFRACPROCUNITRF, " + Environment.NewLine;// 単価端数処理単位
                        sqlText += "RATEU.UNPRCFRACPROCDIVRF, " + Environment.NewLine;// 単価端数処理区分
                        sqlText += "RATEU.GRSPROFITSECURERATERF, " + Environment.NewLine;// 粗利確保率
                        sqlText += "MAKERURF.MAKERNAMERF " + Environment.NewLine;// メーカーコード名称
                        sqlText += "FROM RATERF RATEU " + Environment.NewLine;
                        sqlText += " LEFT JOIN MAKERURF " + Environment.NewLine;
                        sqlText += "ON RATEU.ENTERPRISECODERF = MAKERURF.ENTERPRISECODERF " + Environment.NewLine;// 企業コード
                        sqlText += "AND RATEU.LOGICALDELETECODERF = MAKERURF.LOGICALDELETECODERF " + Environment.NewLine;// 論理削除区分
                        sqlText += "AND RATEU.GOODSMAKERCDRF = MAKERURF.GOODSMAKERCDRF " + Environment.NewLine;// 商品メーカーコード

                        sqlCommand.CommandText += sqlText.ToString();
                        sqlCommand.CommandText += MakeWhereString(ref sqlCommand, rateProtyMngPatternWork, logicalMode);
                        sqlCommand.CommandText += " ORDER BY " + Environment.NewLine;
                        sqlCommand.CommandText += " RATEU.GOODSMAKERCDRF," + Environment.NewLine;
                        sqlCommand.CommandText += " RATEU.RATEVALRF," + Environment.NewLine;
                        sqlCommand.CommandText += " RATEU.PRICEFLRF," + Environment.NewLine;
                        sqlCommand.CommandText += " RATEU.GRSPROFITSECURERATERF" + Environment.NewLine;
                        # endregion

                        myReader = sqlCommand.ExecuteReader();

                        while (myReader.Read())
                        {
                            //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
                            //_updateList.Add(this.CopyToRateFromReader(ref myReader, patternMode));
                            _updateList.Add(this.CopyToRateFromReader(ref myReader, patternMode, convertDoubleRelease, rateProtyMngPatternWork.EnterpriseCode));
                            //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        #endregion [掛率マスタ検索]

                        // --- DEL 2010/09/10 ---------->>>>>
                        //#region [メーカーコードマスタ検索]
                        //# region [SELECT文]
                        //myReader.Close();
                        //sqlCommand.CommandText = string.Empty;
                        //sqlText = "SELECT DISTINCT " + Environment.NewLine;
                        //sqlText += "GOODSMAKERCDRF, " + Environment.NewLine;// 商品メーカーコード
                        //sqlText += "MAKERNAMERF " + Environment.NewLine;// メーカー名称
                        //sqlText += "FROM MAKERURF " + Environment.NewLine;// メーカーマスタ
                        //sqlText += "WHERE ENTERPRISECODERF = @FINDENTERPRISECODE1 " + Environment.NewLine;
                        //sqlText += "AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE1 " + Environment.NewLine;
                        //sqlText += "AND NOT EXISTS " + Environment.NewLine;
                        //sqlText += "( SELECT * FROM RATERF " + Environment.NewLine;
                        //sqlCommand.CommandText += sqlText.ToString();
                        //sqlCommand.CommandText += MakeWhereStringTemp(ref sqlCommand, rateProtyMngPatternWork, logicalMode, patternMode);
                        //sqlCommand.CommandText += " ) ORDER BY GOODSMAKERCDRF " + Environment.NewLine;

                        //// 論理削除区分
                        //SqlParameter findLogicalDeleteCode6 = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE1", SqlDbType.Int);
                        //findLogicalDeleteCode6.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);

                        //// 企業コード
                        //SqlParameter paraEnterpriseCode6 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE1", SqlDbType.NChar);
                        //paraEnterpriseCode6.Value = SqlDataMediator.SqlSetString(rateProtyMngPatternWork.EnterpriseCode);

                        //# endregion

                        //myReader = sqlCommand.ExecuteReader();

                        //while (myReader.Read())
                        //{
                        //    _newList.Add(this.CopyToGoodsFromReader(ref myReader, rateProtyMngPatternWork, patternMode));
                        //}

                        //#endregion [メーカーコードマスタ検索]
                        // --- DEL 2010/09/10 ----------<<<<<

                        // --- ADD 2010/09/10 ---------->>>>>
                        for (int i = 0; i < 999; i++)
                        {
                            RateRlationWork rateRlationWork = this.CopyToGoodsFromReader(ref myReader, rateProtyMngPatternWork, patternMode);
                            _newList.Add(rateRlationWork);
                        }
                        // --- ADD 2010/09/10 ----------<<<<<

                        // 掛率マスタ或メーカーコードマスタ結果或場合
                        if (_newList.Count > 0 || _updateList.Count > 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            // --- ADD 2010/09/10 ---------->>>>>
                            if (_updateList.Count > 0)
                            {
                                int updCnt = _updateList.Count;
                                // ---------UPD 2010/09/26-------->>>>>
                                //for (int i = updCnt; i < 999; i++)
                                //{
                                //    _updateList.Add(this.CopyToGoodsFromReader(ref myReader, rateProtyMngPatternWork, patternMode));
                                //}
                                if (updCnt < 999)
                                {
                                    for (int i = updCnt; i < 999; i++)
                                    {
                                        _updateList.Add(this.CopyToGoodsFromReader(ref myReader, rateProtyMngPatternWork, patternMode));
                                    }
                                }
                            }
                            // --- ADD 2010/09/10 ----------<<<<<
                        }
                        else if (_newList.Count == 0 && _updateList.Count == 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                        #endregion
                        break;
                }
                #endregion パターンによって各々処理
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "RateProtyMngPatternDB.SearchRateRelationDataProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "RateProtyMngPatternDB.SearchRateRelationDataProc", status);
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
                //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
                // 解放
                convertDoubleRelease.Dispose();
                //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
            }

            newList = _newList;
            updateList = _updateList;

            return status;

        }

        # endregion

        #region [Write]
        /// <summary>
        /// 掛率マスタ情報を登録、更新します
        /// </summary>
        /// <param name="updateList">掛率マスタリスト(更新用)</param>
        /// <param name="deleteList">掛率マスタリスト(削除用)</param>
        /// <param name="patternMode">patternMode(0:通常;1:層別)</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 掛率マスタ情報を登録、更新します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        public int WriteRateRelationData(ArrayList updateList, ArrayList deleteList, int patternMode, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retMessage = string.Empty;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // ---DEL 2010/09/15---------------------->>>
                #region DEL 2010/09/15
                //// パターンによって各々処理
                //switch (patternMode)
                //{
                //    case 0:
                //        #region 通常
                //        // 掛率マスタ情報を削除する
                //        if (deleteList != null && deleteList.Count != 0)
                //        {
                //            status = _rateDB.LogicalDeleteSubSectionProc(ref deleteList, 0, ref sqlConnection, ref sqlTransaction);
                //        }
                //        // 情報を登録する
                //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //        {
                //            if (updateList != null && updateList.Count != 0)
                //            {
                //                //status = _rateDB.WriteSubSectionProc(ref updateList, ref sqlConnection, ref sqlTransaction); // DEL 2010/09/10
                //                status = this.WriteSubSectionProc(ref updateList, ref sqlConnection, ref sqlTransaction); // ADD 2010/09/10
                //            }
                //        }
                //        #endregion
                //        break;
                //    case 1:
                //        #region 層別
                //        // 掛率マスタ情報を削除する
                //        if (deleteList != null && deleteList.Count != 0)
                //        {
                //            status = _rateDB.LogicalDeleteSubSectionProc(ref deleteList, 0, ref sqlConnection, ref sqlTransaction);
                //        }
                //        // 情報を登録する
                //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //        {
                //            if (updateList != null && updateList.Count != 0)
                //            {
                //                SqlDataReader myReader = null;
                //                SqlCommand sqlCommand = null;
                //                ArrayList al = new ArrayList();

                //                string command = string.Empty;
                //                command = "SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM RATERF" + Environment.NewLine;
                //                command += "WHERE" + Environment.NewLine;
                //                command += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                //                command += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                //                command += "  AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD" + Environment.NewLine;
                //                command += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                //                command += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                //                command += "  AND GOODSRATERANKRF=@FINDGOODSRATERANK" + Environment.NewLine;
                //                command += "  AND GOODSRATEGRPCODERF=@FINDGOODSRATEGRPCODE" + Environment.NewLine;
                //                command += "  AND BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
                //                command += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                //                command += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                //                command += "  AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE" + Environment.NewLine;
                //                command += "  AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                //                command += "  AND LOTCOUNTRF=@FINDLOTCOUNT" + Environment.NewLine;

                //                try
                //                {
                //                    for (int i = 0; i < updateList.Count; i++)
                //                    {
                //                        RateWork rateWork = updateList[i] as RateWork;

                //                        //Selectコマンドの生成
                //                        sqlCommand = new SqlCommand(command, sqlConnection, sqlTransaction);

                //                        //Prameterオブジェクトの作成
                //                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                //                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                //                        SqlParameter findParaUnitRateSetDivCd = sqlCommand.Parameters.Add("@FINDUNITRATESETDIVCD", SqlDbType.NChar);
                //                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                //                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                //                        SqlParameter findParaGoodsRateRank = sqlCommand.Parameters.Add("@FINDGOODSRATERANK", SqlDbType.NChar);
                //                        SqlParameter findParaGoodsRateGrpCode = sqlCommand.Parameters.Add("@FINDGOODSRATEGRPCODE", SqlDbType.Int);
                //                        SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                //                        SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                //                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                //                        SqlParameter findParaCustRateGrpCode = sqlCommand.Parameters.Add("@FINDCUSTRATEGRPCODE", SqlDbType.Int);
                //                        SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                //                        SqlParameter findParaLotCount = sqlCommand.Parameters.Add("@FINDLOTCOUNT", SqlDbType.Float);

                //                        //Parameterオブジェクトへ値設定
                //                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);
                //                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(rateWork.SectionCode);
                //                        findParaUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
                //                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
                //                        findParaGoodsNo.Value = rateWork.GoodsNo;
                //                        findParaGoodsRateRank.Value = rateWork.GoodsRateRank;
                //                        findParaGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsRateGrpCode);
                //                        findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGroupCode);
                //                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGoodsCode);
                //                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustomerCode);
                //                        findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustRateGrpCode);
                //                        findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rateWork.SupplierCd);
                //                        findParaLotCount.Value = SqlDataMediator.SqlSetDouble(rateWork.LotCount);

                //                        myReader = sqlCommand.ExecuteReader();
                //                        if (myReader.Read())
                //                        {
                //                            sqlCommand.CommandText = "UPDATE RATERF" + Environment.NewLine;
                //                            //sqlCommand.CommandText += "SET CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                //                            sqlCommand.CommandText += "SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                //                            sqlCommand.CommandText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                //                            //sqlCommand.CommandText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                //                            //sqlCommand.CommandText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                //                            //sqlCommand.CommandText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                //                            //sqlCommand.CommandText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                //                            sqlCommand.CommandText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                //                            sqlCommand.CommandText += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                //                            sqlCommand.CommandText += " , UNITRATESETDIVCDRF=@UNITRATESETDIVCD" + Environment.NewLine;
                //                            sqlCommand.CommandText += " , UNITPRICEKINDRF=@UNITPRICEKIND" + Environment.NewLine;
                //                            sqlCommand.CommandText += " , RATESETTINGDIVIDERF=@RATESETTINGDIVIDE" + Environment.NewLine;
                //                            sqlCommand.CommandText += " , RATEMNGGOODSCDRF=@RATEMNGGOODSCD" + Environment.NewLine;
                //                            sqlCommand.CommandText += " , RATEMNGGOODSNMRF=@RATEMNGGOODSNM" + Environment.NewLine;
                //                            sqlCommand.CommandText += " , RATEMNGCUSTCDRF=@RATEMNGCUSTCD" + Environment.NewLine;
                //                            sqlCommand.CommandText += " , RATEMNGCUSTNMRF=@RATEMNGCUSTNM" + Environment.NewLine;
                //                            sqlCommand.CommandText += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                //                            sqlCommand.CommandText += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                //                            sqlCommand.CommandText += " , GOODSRATERANKRF=@GOODSRATERANK" + Environment.NewLine;
                //                            sqlCommand.CommandText += " , GOODSRATEGRPCODERF=@GOODSRATEGRPCODE" + Environment.NewLine;
                //                            sqlCommand.CommandText += " , BLGROUPCODERF=@BLGROUPCODE" + Environment.NewLine;
                //                            sqlCommand.CommandText += " , BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                //                            sqlCommand.CommandText += " , CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
                //                            sqlCommand.CommandText += " , CUSTRATEGRPCODERF=@CUSTRATEGRPCODE" + Environment.NewLine;
                //                            sqlCommand.CommandText += " , SUPPLIERCDRF=@SUPPLIERCD" + Environment.NewLine;
                //                            sqlCommand.CommandText += " , LOTCOUNTRF=@LOTCOUNT" + Environment.NewLine;
                //                            sqlCommand.CommandText += " , PRICEFLRF=@PRICEFL" + Environment.NewLine;
                //                            sqlCommand.CommandText += " , RATEVALRF=@RATEVAL" + Environment.NewLine;
                //                            sqlCommand.CommandText += " , UPRATERF=@UPRATE" + Environment.NewLine;
                //                            sqlCommand.CommandText += " , GRSPROFITSECURERATERF=@GRSPROFITSECURERATE" + Environment.NewLine;
                //                            sqlCommand.CommandText += " , UNPRCFRACPROCUNITRF=@UNPRCFRACPROCUNIT" + Environment.NewLine;
                //                            sqlCommand.CommandText += " , UNPRCFRACPROCDIVRF=@UNPRCFRACPROCDIV" + Environment.NewLine;
                //                            sqlCommand.CommandText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  AND GOODSRATERANKRF=@FINDGOODSRATERANK" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  AND GOODSRATEGRPCODERF=@FINDGOODSRATEGRPCODE" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  AND BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  AND LOTCOUNTRF=@FINDLOTCOUNT" + Environment.NewLine;


                //                            //KEYコマンドを再設定
                //                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);
                //                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(rateWork.SectionCode);
                //                            findParaUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
                //                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
                //                            findParaGoodsNo.Value = rateWork.GoodsNo;
                //                            findParaGoodsRateRank.Value = rateWork.GoodsRateRank;
                //                            findParaGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsRateGrpCode);
                //                            findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGroupCode);
                //                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGoodsCode);
                //                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustomerCode);
                //                            findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustRateGrpCode);
                //                            findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rateWork.SupplierCd);
                //                            findParaLotCount.Value = SqlDataMediator.SqlSetDouble(rateWork.LotCount);

                //                            //更新ヘッダ情報を設定
                //                            object obj = (object)this;
                //                            IFileHeader flhd = (IFileHeader)rateWork;
                //                            FileHeader fileHeader = new FileHeader(obj);
                //                            fileHeader.SetUpdateHeader(ref flhd, obj);
                //                        }
                //                        else
                //                        {
                //                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                //                            if (rateWork.UpdateDateTime > DateTime.MinValue)
                //                            {
                //                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                //                                sqlCommand.Cancel();
                //                                if (myReader.IsClosed == false) myReader.Close();
                //                                return status;
                //                            }

                //                            //新規作成時のSQL文を生成
                //                            sqlCommand.CommandText = "INSERT INTO RATERF" + Environment.NewLine;
                //                            sqlCommand.CommandText += " (CREATEDATETIMERF" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,SECTIONCODERF" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,UNITRATESETDIVCDRF" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,UNITPRICEKINDRF" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,RATESETTINGDIVIDERF" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,RATEMNGGOODSCDRF" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,RATEMNGGOODSNMRF" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,RATEMNGCUSTCDRF" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,RATEMNGCUSTNMRF" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,GOODSNORF" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,GOODSRATERANKRF" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,GOODSRATEGRPCODERF" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,BLGROUPCODERF" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,BLGOODSCODERF" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,CUSTOMERCODERF" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,CUSTRATEGRPCODERF" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,SUPPLIERCDRF" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,LOTCOUNTRF" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,PRICEFLRF" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,RATEVALRF" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,UPRATERF" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,GRSPROFITSECURERATERF" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,UNPRCFRACPROCUNITRF" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,UNPRCFRACPROCDIVRF" + Environment.NewLine;
                //                            sqlCommand.CommandText += " )" + Environment.NewLine;
                //                            sqlCommand.CommandText += " VALUES" + Environment.NewLine;
                //                            sqlCommand.CommandText += " (@CREATEDATETIME" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,@UPDATEDATETIME" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,@ENTERPRISECODE" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,@FILEHEADERGUID" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,@SECTIONCODE" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,@UNITRATESETDIVCD" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,@UNITPRICEKIND" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,@RATESETTINGDIVIDE" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,@RATEMNGGOODSCD" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,@RATEMNGGOODSNM" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,@RATEMNGCUSTCD" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,@RATEMNGCUSTNM" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,@GOODSMAKERCD" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,@GOODSNO" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,@GOODSRATERANK" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,@GOODSRATEGRPCODE" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,@BLGROUPCODE" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,@BLGOODSCODE" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,@CUSTOMERCODE" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,@CUSTRATEGRPCODE" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,@SUPPLIERCD" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,@LOTCOUNT" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,@PRICEFL" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,@RATEVAL" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,@UPRATE" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,@GRSPROFITSECURERATE" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,@UNPRCFRACPROCUNIT" + Environment.NewLine;
                //                            sqlCommand.CommandText += "  ,@UNPRCFRACPROCDIV" + Environment.NewLine;
                //                            sqlCommand.CommandText += " )" + Environment.NewLine;

                //                            //登録ヘッダ情報を設定
                //                            object obj = (object)this;
                //                            IFileHeader flhd = (IFileHeader)rateWork;
                //                            FileHeader fileHeader = new FileHeader(obj);
                //                            fileHeader.SetInsertHeader(ref flhd, obj);
                //                        }
                //                        if (myReader.IsClosed == false) myReader.Close();

                //                        #region Parameterオブジェクトの作成(更新用)
                //                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                //                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                //                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                //                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                //                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                //                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                //                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                //                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                //                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                //                        SqlParameter paraUnitRateSetDivCd = sqlCommand.Parameters.Add("@UNITRATESETDIVCD", SqlDbType.NChar);
                //                        SqlParameter paraUnitPriceKind = sqlCommand.Parameters.Add("@UNITPRICEKIND", SqlDbType.NChar);
                //                        SqlParameter paraRateSettingDivide = sqlCommand.Parameters.Add("@RATESETTINGDIVIDE", SqlDbType.NChar);
                //                        SqlParameter paraRateMngGoodsCd = sqlCommand.Parameters.Add("@RATEMNGGOODSCD", SqlDbType.NChar);
                //                        SqlParameter paraRateMngGoodsNm = sqlCommand.Parameters.Add("@RATEMNGGOODSNM", SqlDbType.NVarChar);
                //                        SqlParameter paraRateMngCustCd = sqlCommand.Parameters.Add("@RATEMNGCUSTCD", SqlDbType.NChar);
                //                        SqlParameter paraRateMngCustNm = sqlCommand.Parameters.Add("@RATEMNGCUSTNM", SqlDbType.NVarChar);
                //                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                //                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                //                        SqlParameter paraGoodsRateRank = sqlCommand.Parameters.Add("@GOODSRATERANK", SqlDbType.NChar);
                //                        SqlParameter paraGoodsRateGrpCode = sqlCommand.Parameters.Add("@GOODSRATEGRPCODE", SqlDbType.Int);
                //                        SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                //                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                //                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                //                        SqlParameter paraCustRateGrpCode = sqlCommand.Parameters.Add("@CUSTRATEGRPCODE", SqlDbType.Int);
                //                        SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                //                        SqlParameter paraLotCount = sqlCommand.Parameters.Add("@LOTCOUNT", SqlDbType.Float);
                //                        SqlParameter paraPriceFl = sqlCommand.Parameters.Add("@PRICEFL", SqlDbType.Float);
                //                        SqlParameter paraRateVal = sqlCommand.Parameters.Add("@RATEVAL", SqlDbType.Float);
                //                        SqlParameter paraUpRate = sqlCommand.Parameters.Add("@UPRATE", SqlDbType.Float);
                //                        SqlParameter paraGrsProfitSecureRate = sqlCommand.Parameters.Add("@GRSPROFITSECURERATE", SqlDbType.Float);
                //                        SqlParameter paraUnPrcFracProcUnit = sqlCommand.Parameters.Add("@UNPRCFRACPROCUNIT", SqlDbType.Float);
                //                        SqlParameter paraUnPrcFracProcDiv = sqlCommand.Parameters.Add("@UNPRCFRACPROCDIV", SqlDbType.Int);
                //                        #endregion

                //                        #region Parameterオブジェクトへ値設定(更新用)
                //                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rateWork.CreateDateTime);
                //                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rateWork.UpdateDateTime);
                //                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);
                //                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(rateWork.FileHeaderGuid);
                //                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(rateWork.UpdEmployeeCode);
                //                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(rateWork.UpdAssemblyId1);
                //                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(rateWork.UpdAssemblyId2);
                //                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(rateWork.LogicalDeleteCode);
                //                        paraSectionCode.Value = SqlDataMediator.SqlSetString(rateWork.SectionCode);
                //                        paraUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
                //                        paraUnitPriceKind.Value = SqlDataMediator.SqlSetString(rateWork.UnitPriceKind);
                //                        paraRateSettingDivide.Value = SqlDataMediator.SqlSetString(rateWork.RateSettingDivide);
                //                        paraRateMngGoodsCd.Value = SqlDataMediator.SqlSetString(rateWork.RateMngGoodsCd);
                //                        paraRateMngGoodsNm.Value = SqlDataMediator.SqlSetString(rateWork.RateMngGoodsNm);
                //                        paraRateMngCustCd.Value = SqlDataMediator.SqlSetString(rateWork.RateMngCustCd);
                //                        paraRateMngCustNm.Value = SqlDataMediator.SqlSetString(rateWork.RateMngCustNm);
                //                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
                //                        paraGoodsNo.Value = rateWork.GoodsNo;
                //                        paraGoodsRateRank.Value = rateWork.GoodsRateRank;
                //                        paraGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsRateGrpCode);
                //                        paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGroupCode);
                //                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGoodsCode);
                //                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustomerCode);
                //                        paraCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustRateGrpCode);
                //                        paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(rateWork.SupplierCd);
                //                        paraLotCount.Value = SqlDataMediator.SqlSetDouble(rateWork.LotCount);
                //                        paraPriceFl.Value = SqlDataMediator.SqlSetDouble(rateWork.PriceFl);
                //                        paraRateVal.Value = SqlDataMediator.SqlSetDouble(rateWork.RateVal);
                //                        paraUpRate.Value = SqlDataMediator.SqlSetDouble(rateWork.UpRate);
                //                        paraGrsProfitSecureRate.Value = SqlDataMediator.SqlSetDouble(rateWork.GrsProfitSecureRate);
                //                        paraUnPrcFracProcUnit.Value = SqlDataMediator.SqlSetDouble(rateWork.UnPrcFracProcUnit);
                //                        paraUnPrcFracProcDiv.Value = SqlDataMediator.SqlSetInt32(rateWork.UnPrcFracProcDiv);
                //                        #endregion

                //                        sqlCommand.ExecuteNonQuery();
                //                        al.Add(rateWork);
                //                    }

                //                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //                }
                //                catch (SqlException ex)
                //                {
                //                    //基底クラスに例外を渡して処理してもらう
                //                    status = base.WriteSQLErrorLog(ex);
                //                }
                //                finally
                //                {
                //                    if (myReader != null)
                //                        if (myReader.IsClosed == false) myReader.Close();
                //                    if (sqlCommand != null)
                //                    {
                //                        sqlCommand.Cancel();
                //                        sqlCommand.Dispose();
                //                    }
                //                }
                //            }
                //        }
                //        #endregion 層別
                //        break;
                //}
                #endregion
                // ---DEL 2010/09/15----------------------<<<

                // ---ADD 2010/09/15---------------------->>>
                // 掛率マスタ情報を削除する
                if (deleteList != null && deleteList.Count != 0)
                {
                    status = _rateDB.LogicalDeleteSubSectionProc(ref deleteList, 0, ref sqlConnection, ref sqlTransaction);
                }
                // 情報を登録する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (updateList != null && updateList.Count != 0)
                    {
                        //status = _rateDB.WriteSubSectionProc(ref updateList, ref sqlConnection, ref sqlTransaction); // DEL 2010/09/10
                        status = this.WriteSubSectionProc(ref updateList, ref sqlConnection, ref sqlTransaction); // ADD 2010/09/10
                    }
                }
                // ---ADD 2010/09/15----------------------<<<

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RateProtyMngPatternDB.WriteRateRelationData");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        #endregion

        # region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="rateProtyMngWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/10</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, RateProtyMngWork rateProtyMngWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;

            // 企業コード
            retstring += " ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateProtyMngWork.EnterpriseCode);

            // 論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            // 拠点
            retstring += " AND SECTIONCODERF = @FINDSECTIONCODE " + Environment.NewLine;
            SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
            paraSectionCode.Value = SqlDataMediator.SqlSetString(rateProtyMngWork.SectionCode);

            // 単価種類
            retstring += " AND UNITPRICEKINDRF=@FINDUNITPRICEKIND " + Environment.NewLine;
            SqlParameter paraUnitPriceKinde = sqlCommand.Parameters.Add("@FINDUNITPRICEKIND", SqlDbType.Int);
            paraUnitPriceKinde.Value = SqlDataMediator.SqlSetInt(rateProtyMngWork.UnitPriceKind);

            retstring += " ORDER BY " + Environment.NewLine;
            retstring += " RATEPRIORITYORDERRF," + Environment.NewLine;
            retstring += " RATEMNGGOODSNMRF," + Environment.NewLine;
            retstring += " RATEMNGCUSTNMRF" + Environment.NewLine;
            return retstring;
        }


        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="rateProtyMngPatternWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/10</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, RateProtyMngPatternWork rateProtyMngPatternWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;

            // 企業コード
            retstring += " RATEU.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateProtyMngPatternWork.EnterpriseCode);

            // 論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND RATEU.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND RATEU.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            // 拠点
            retstring += " AND RATEU.SECTIONCODERF = @FINDSECTIONCODE " + Environment.NewLine;
            SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
            paraSectionCode.Value = SqlDataMediator.SqlSetString(rateProtyMngPatternWork.SectionCode);

            // 単価種類
            retstring += " AND RATEU.UNITPRICEKINDRF=@FINDUNITPRICEKIND " + Environment.NewLine;
            SqlParameter paraUnitPriceKinde = sqlCommand.Parameters.Add("@FINDUNITPRICEKIND", SqlDbType.NChar);
            paraUnitPriceKinde.Value = SqlDataMediator.SqlSetString(rateProtyMngPatternWork.UnitPriceKind);

            // 掛率設定区分
            retstring += " AND RATEU.RATESETTINGDIVIDERF = @FINDRATESETTINGDIVIDE " + Environment.NewLine;
            SqlParameter paraRateSettingDivide = sqlCommand.Parameters.Add("@FINDRATESETTINGDIVIDE", SqlDbType.NChar);
            paraRateSettingDivide.Value = SqlDataMediator.SqlSetString(rateProtyMngPatternWork.RateSettingDivide);

            // 得意先
            if (rateProtyMngPatternWork.CustomerCode != 0)
            {
                retstring += " AND RATEU.CUSTOMERCODERF = @FINDCUSTOMERCODE " + Environment.NewLine;
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt(rateProtyMngPatternWork.CustomerCode);
            }

            // 得意先掛率G
            if (rateProtyMngPatternWork.CustRateGrpCode != -1)
            {
                retstring += " AND RATEU.CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE " + Environment.NewLine;
                SqlParameter paraCustRateGrpCode = sqlCommand.Parameters.Add("@FINDCUSTRATEGRPCODE", SqlDbType.Int);
                paraCustRateGrpCode.Value = SqlDataMediator.SqlSetInt(rateProtyMngPatternWork.CustRateGrpCode);

            }
            // 仕入先
            if (rateProtyMngPatternWork.SupplierCd != 0)
            {
                retstring += " AND RATEU.SUPPLIERCDRF = @FINDSUPPLIERCD " + Environment.NewLine;
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt(rateProtyMngPatternWork.SupplierCd);
            }

            // 商品メーカーコード
            if (rateProtyMngPatternWork.GoodsMakerCd != 0)
            {
                retstring += " AND RATEU.GOODSMAKERCDRF = @FINDGOODSMAKERCD " + Environment.NewLine;
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt(rateProtyMngPatternWork.GoodsMakerCd);
            }

            // 層別
            if (!string.IsNullOrEmpty(rateProtyMngPatternWork.GoodsRateRank))
            {
                retstring += " AND RATEU.GOODSRATERANKRF = @FINDGOODSRATERANK " + Environment.NewLine;
                SqlParameter paraGoodsRateRank = sqlCommand.Parameters.Add("@FINDGOODSRATERANK", SqlDbType.NChar);
                paraGoodsRateRank.Value = SqlDataMediator.SqlSetString(rateProtyMngPatternWork.GoodsRateRank);
            }

            // BL商品コード
            if (rateProtyMngPatternWork.BlGoodsCode != 0)
            {
                retstring += " AND RATEU.BLGOODSCODERF = @FINDBLGOODSCODE " + Environment.NewLine;
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt(rateProtyMngPatternWork.BlGoodsCode);
            }

            // 商品掛率グループコード
            if (rateProtyMngPatternWork.GoodsRateGrpCode != 0)
            {
                retstring += " AND RATEU.GOODSRATEGRPCODERF = @FINDGOODSRATEGRPCODE " + Environment.NewLine;
                SqlParameter paraGoodsRateGrpCode = sqlCommand.Parameters.Add("@FINDGOODSRATEGRPCODE", SqlDbType.Int);
                paraGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt(rateProtyMngPatternWork.GoodsRateGrpCode);
            }

            // BLグループコード
            if (rateProtyMngPatternWork.BlGroupCode != 0)
            {
                retstring += " AND RATEU.BLGROUPCODERF = @FINDBLGROUPCODE " + Environment.NewLine;
                SqlParameter paraBlGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                paraBlGroupCode.Value = SqlDataMediator.SqlSetInt(rateProtyMngPatternWork.BlGroupCode);
            }

            // --- ADD 2010/09/10 ---------->>>>> 
            if ("1".Equals(rateProtyMngPatternWork.UnitPriceKind)) {
                retstring += " AND RATEU.LOTCOUNTRF = (SELECT MIN(LOTCOUNTRF)" + Environment.NewLine;
                retstring += " FROM RATERF" + Environment.NewLine;
                retstring += " WHERE ENTERPRISECODERF = RATEU.ENTERPRISECODERF" + Environment.NewLine;
                retstring += " AND SECTIONCODERF = RATEU.SECTIONCODERF" + Environment.NewLine;
                retstring += " AND UNITRATESETDIVCDRF = RATEU.UNITRATESETDIVCDRF" + Environment.NewLine;
                retstring += " AND GOODSMAKERCDRF  = RATEU.GOODSMAKERCDRF" + Environment.NewLine;
                retstring += " AND GOODSNORF = RATEU.GOODSNORF" + Environment.NewLine;
                retstring += " AND GOODSRATERANKRF = RATEU.GOODSRATERANKRF" + Environment.NewLine;
                retstring += " AND GOODSRATEGRPCODERF = RATEU.GOODSRATEGRPCODERF" + Environment.NewLine;
                retstring += " AND BLGROUPCODERF = RATEU.BLGROUPCODERF" + Environment.NewLine;
                retstring += " AND BLGOODSCODERF = RATEU.BLGOODSCODERF" + Environment.NewLine;
                retstring += " AND CUSTOMERCODERF = RATEU.CUSTOMERCODERF" + Environment.NewLine;
                retstring += " AND CUSTRATEGRPCODERF = RATEU.CUSTRATEGRPCODERF" + Environment.NewLine;
                retstring += " AND SUPPLIERCDRF = RATEU.SUPPLIERCDRF)" + Environment.NewLine;
            }
            // --- ADD 2010/09/10 ----------<<<<<
            return retstring;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="rateProtyMngPatternWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="patternMode">モード(0:BLコード;1:品番指定;2:単独指定;3:層別指定;4:商品掛率G指定;5:グループコード指定;6:メーカー指定)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/10</br>
        private string MakeWhereStringTemp(ref SqlCommand sqlCommand, RateProtyMngPatternWork rateProtyMngPatternWork, ConstantManagement.LogicalMode logicalMode, int patternMode)
        {
            string retstring = "WHERE" + Environment.NewLine;

            switch (patternMode)
            {
                case 0:
                    #region パターン：BLコード
                    {
                        retstring += "BLGOODSCDURF.BLGOODSCODERF = RATERF.BLGOODSCODERF" + Environment.NewLine;
                        retstring += "AND BLGOODSCDURF.ENTERPRISECODERF = RATERF.ENTERPRISECODERF" + Environment.NewLine;

                        break;
                    }
                    #endregion
                case 1:
                    #region パターン：品番指定
                    {
                        retstring += "GOODSURF.GOODSNORF = RATERF.GOODSNORF" + Environment.NewLine;
                        retstring += "AND GOODSURF.ENTERPRISECODERF = RATERF.ENTERPRISECODERF" + Environment.NewLine;
                        break;
                    }
                    #endregion
                case 2:
                    #region パターン：単独指定
                    {
                        retstring += _tableName + "." + _dataColumnCdMast + " = RATERF." + _dataColumnCd + " " + Environment.NewLine;
                        retstring += "AND " + _tableName + ".ENTERPRISECODERF = RATERF.ENTERPRISECODERF " + Environment.NewLine;

                        // 企業コード
                        retstring += " AND RATERF.ENTERPRISECODERF = @FINDENTERPRISECODETEMP" + Environment.NewLine;
                        SqlParameter paraEnterpriseCode1 = sqlCommand.Parameters.Add("@FINDENTERPRISECODETEMP", SqlDbType.NChar);
                        paraEnterpriseCode1.Value = SqlDataMediator.SqlSetString(rateProtyMngPatternWork.EnterpriseCode);

                        // 拠点
                        retstring += " AND RATERF.SECTIONCODERF = @FINDSECTIONCODETEMP " + Environment.NewLine;
                        SqlParameter paraSectionCode1 = sqlCommand.Parameters.Add("@FINDSECTIONCODETEMP", SqlDbType.NChar);
                        paraSectionCode1.Value = SqlDataMediator.SqlSetString(rateProtyMngPatternWork.SectionCode);

                        // 単価種類
                        retstring += " AND RATERF.UNITPRICEKINDRF=@FINDUNITPRICEKINDTEMP " + Environment.NewLine;
                        SqlParameter paraUnitPriceKinde1 = sqlCommand.Parameters.Add("@FINDUNITPRICEKINDTEMP", SqlDbType.NChar);
                        paraUnitPriceKinde1.Value = SqlDataMediator.SqlSetString(rateProtyMngPatternWork.UnitPriceKind);

                        // 掛率設定区分
                        retstring += " AND RATERF.RATESETTINGDIVIDERF = @FINDRATESETTINGDIVIDETEMP " + Environment.NewLine;
                        SqlParameter paraRateSettingDivide1 = sqlCommand.Parameters.Add("@FINDRATESETTINGDIVIDETEMP", SqlDbType.NChar);
                        paraRateSettingDivide1.Value = SqlDataMediator.SqlSetString(rateProtyMngPatternWork.RateSettingDivide);

                        // 得意先
                        if (rateProtyMngPatternWork.CustomerCode != 0 && "1L".Equals(_rateSettingDivide))
                        {
                            retstring += " AND RATERF.CUSTOMERCODERF = @FINDCUSTOMERCODETEMP " + Environment.NewLine;
                            SqlParameter paraCustomerCode1 = sqlCommand.Parameters.Add("@FINDCUSTOMERCODETEMP", SqlDbType.Int);
                            paraCustomerCode1.Value = SqlDataMediator.SqlSetInt(rateProtyMngPatternWork.CustomerCode);
                        }

                        // 得意先掛率G
                        if (!(rateProtyMngPatternWork.CustRateGrpCode == -1) && "3L".Equals(_rateSettingDivide))
                        {
                            retstring += " AND RATERF.CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODETEMP " + Environment.NewLine;
                            SqlParameter paraCustRateGrpCode1 = sqlCommand.Parameters.Add("@FINDCUSTRATEGRPCODETEMP", SqlDbType.Int);
                            paraCustRateGrpCode1.Value = SqlDataMediator.SqlSetInt(rateProtyMngPatternWork.CustRateGrpCode);
                        }

                        return retstring;
                    }
                    #endregion
                case 3:
                    #region パターン：層別指定
                    {
                        break;
                    }
                    #endregion
                case 4:
                    #region パターン：商品掛率G指定
                    {
                        retstring += "GOODSGROUPURF.GOODSMGROUPRF = RATERF.GOODSRATEGRPCODERF" + Environment.NewLine;
                        retstring += "AND GOODSGROUPURF.ENTERPRISECODERF = RATERF.ENTERPRISECODERF" + Environment.NewLine;
                        break;
                    }
                    #endregion
                case 5:
                    #region パターン：グループコード指定
                    {
                        retstring += "BLGROUPURF.BLGROUPCODERF = RATERF.BLGROUPCODERF" + Environment.NewLine;
                        retstring += "AND BLGROUPURF.ENTERPRISECODERF = RATERF.ENTERPRISECODERF" + Environment.NewLine;
                        break;
                    }
                    #endregion
                case 6:
                    #region パターン：メーカー指定
                    {
                        retstring += "MAKERURF.GOODSMAKERCDRF = RATERF.GOODSMAKERCDRF" + Environment.NewLine;
                        retstring += "AND MAKERURF.ENTERPRISECODERF = RATERF.ENTERPRISECODERF" + Environment.NewLine;
                        break;
                    }
                    #endregion
            }

            // 企業コード
            retstring += " AND RATERF.ENTERPRISECODERF = @FINDENTERPRISECODETEMP" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODETEMP", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateProtyMngPatternWork.EnterpriseCode);

            // 拠点
            retstring += " AND RATERF.SECTIONCODERF = @FINDSECTIONCODETEMP " + Environment.NewLine;
            SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODETEMP", SqlDbType.NChar);
            paraSectionCode.Value = SqlDataMediator.SqlSetString(rateProtyMngPatternWork.SectionCode);

            // 単価種類
            retstring += " AND RATERF.UNITPRICEKINDRF=@FINDUNITPRICEKINDTEMP " + Environment.NewLine;
            SqlParameter paraUnitPriceKinde = sqlCommand.Parameters.Add("@FINDUNITPRICEKINDTEMP", SqlDbType.NChar);
            paraUnitPriceKinde.Value = SqlDataMediator.SqlSetString(rateProtyMngPatternWork.UnitPriceKind);

            // 掛率設定区分
            retstring += " AND RATERF.RATESETTINGDIVIDERF = @FINDRATESETTINGDIVIDETEMP " + Environment.NewLine;
            SqlParameter paraRateSettingDivide = sqlCommand.Parameters.Add("@FINDRATESETTINGDIVIDETEMP", SqlDbType.NChar);
            paraRateSettingDivide.Value = SqlDataMediator.SqlSetString(rateProtyMngPatternWork.RateSettingDivide);

            // 得意先
            if (rateProtyMngPatternWork.CustomerCode != 0)
            {
                retstring += " AND RATERF.CUSTOMERCODERF = @FINDCUSTOMERCODETEMP " + Environment.NewLine;
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODETEMP", SqlDbType.Int);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt(rateProtyMngPatternWork.CustomerCode);
            }

            // 得意先掛率G
            retstring += " AND RATERF.CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODETEMP " + Environment.NewLine;
            SqlParameter paraCustRateGrpCode = sqlCommand.Parameters.Add("@FINDCUSTRATEGRPCODETEMP", SqlDbType.Int);
            paraCustRateGrpCode.Value = SqlDataMediator.SqlSetInt(rateProtyMngPatternWork.CustRateGrpCode);

            // 仕入先
            if (rateProtyMngPatternWork.SupplierCd != 0)
            {
                retstring += " AND RATERF.SUPPLIERCDRF = @FINDSUPPLIERCDTEMP " + Environment.NewLine;
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCDTEMP", SqlDbType.Int);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt(rateProtyMngPatternWork.SupplierCd);
            }

            // 商品メーカーコード
            if (rateProtyMngPatternWork.GoodsMakerCd != 0)
            {
                retstring += " AND RATERF.GOODSMAKERCDRF = @FINDGOODSMAKERCDTEMP " + Environment.NewLine;
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCDTEMP", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt(rateProtyMngPatternWork.GoodsMakerCd);
            }

            // 層別
            if (!string.IsNullOrEmpty(rateProtyMngPatternWork.GoodsRateRank))
            {
                retstring += " AND RATERF.GOODSRATERANKRF = @FINDGOODSRATERANKTEMP " + Environment.NewLine;
                SqlParameter paraGoodsRateRank = sqlCommand.Parameters.Add("@FINDGOODSRATERANKTEMP", SqlDbType.NChar);
                paraGoodsRateRank.Value = SqlDataMediator.SqlSetString(rateProtyMngPatternWork.GoodsRateRank);
            }

            // BL商品コード
            if (rateProtyMngPatternWork.BlGoodsCode != 0)
            {
                retstring += " AND RATERF.BLGOODSCODERF = @FINDBLGOODSCODETEMP " + Environment.NewLine;
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODETEMP", SqlDbType.Int);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt(rateProtyMngPatternWork.BlGoodsCode);
            }

            // 商品掛率グループコード
            if (rateProtyMngPatternWork.GoodsRateGrpCode != 0)
            {
                retstring += " AND RATERF.GOODSRATEGRPCODE = @FINDGOODSRATEGRPCODETEMP " + Environment.NewLine;
                SqlParameter paraGoodsRateGrpCode = sqlCommand.Parameters.Add("@FINDGOODSRATEGRPCODETEMP", SqlDbType.Int);
                paraGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt(rateProtyMngPatternWork.GoodsRateGrpCode);
            }

            // BLグループコード
            if (rateProtyMngPatternWork.BlGroupCode != 0)
            {
                retstring += " AND RATERF.BLGROUPCODE = @FINDBLGROUPCODETEMP " + Environment.NewLine;
                SqlParameter paraBlGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODETEMP", SqlDbType.Int);
                paraBlGroupCode.Value = SqlDataMediator.SqlSetInt(rateProtyMngPatternWork.BlGroupCode);
            }
            return retstring;
        }
        # endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → rateProtyMngPatternWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="rateProtyMngPatternWork">rateProtyMngPatternWork</param>
        /// <param name="patternMode">モード(0:BLコード;1:品番指定;2:単独指定;3:層別指定;4:商品掛率G指定;5:グループコード指定;6:メーカー指定)</param>
        /// <returns>RateRlationWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/10</br>
        /// <br>Update Note : 2010/09/26 呉元嘯 仕様連絡 #14492対応</br>
        /// </remarks>
        private RateRlationWork CopyToGoodsFromReader(ref SqlDataReader myReader, RateProtyMngPatternWork rateProtyMngPatternWork, int patternMode)
        {
            RateRlationWork rateRlationWork = new RateRlationWork();
            rateRlationWork.UpdateLineFlg = false; // ADD 2010/09/10
            rateRlationWork.LotCount = 9999999.99; // ADD 2010/09/10
            if ("3".Equals(rateProtyMngPatternWork.UnitPriceKind)) {
                rateRlationWork.UnPrcFracProcUnit = 1; // ADD 2010/09/10
                rateRlationWork.UnPrcFracProcDiv = 2; // ADD 2010/09/10
            }

            # region クラスへ格納
            switch (patternMode)
            {
                case 0:
                    #region パターン：BLコード
                    rateRlationWork.GoodsRateRank = rateProtyMngPatternWork.GoodsRateRank.Trim();//　画面.層別
                    rateRlationWork.CustRateGrpCode = rateProtyMngPatternWork.CustRateGrpCode;//　画面.得意先掛率G
                    rateRlationWork.CustomerCode = rateProtyMngPatternWork.CustomerCode;//　画面.得意先
                    rateRlationWork.SupplierCd = rateProtyMngPatternWork.SupplierCd;//　画面.仕入先
                    rateRlationWork.GoodsMakerCd = rateProtyMngPatternWork.GoodsMakerCd;//　画面.メーカー
                    //rateRlationWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF")); // DEL 2010/09/09
                    //rateRlationWork.MasterNm = rateRlationWork.BLGoodsCode.ToString("D5") + " " + SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF")); // DEl 2010/09/09
                    #endregion
                    break;
                case 1:
                    #region パターン：品番指定
                    rateRlationWork.CustRateGrpCode = rateProtyMngPatternWork.CustRateGrpCode;//　画面.得意先掛率G
                    rateRlationWork.CustomerCode = rateProtyMngPatternWork.CustomerCode;//　画面.得意先
                    rateRlationWork.SupplierCd = rateProtyMngPatternWork.SupplierCd;//　画面.仕入先
                    rateRlationWork.GoodsMakerCd = rateProtyMngPatternWork.GoodsMakerCd;//　画面.メーカー
                    // --- DEL 2010/09/10 ---------->>>>>
                    //rateRlationWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    //rateRlationWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));
                    //rateRlationWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
                    // --- DEL 2010/09/10 ----------<<<<<
                    #endregion
                    break;
                case 2:
                    #region パターン：単独指定
                    rateRlationWork.CustRateGrpCode = rateProtyMngPatternWork.CustRateGrpCode;//　画面.得意先掛率G
                    rateRlationWork.CustomerCode = rateProtyMngPatternWork.CustomerCode;//　画面.得意先
                    rateRlationWork.SupplierCd = rateProtyMngPatternWork.SupplierCd;//　画面.仕入先
                    rateRlationWork.GoodsMakerCd = rateProtyMngPatternWork.GoodsMakerCd;//　画面.メーカー
                    rateRlationWork.BLGroupCode = rateProtyMngPatternWork.BlGroupCode;// 画面.BLグループコード
                    rateRlationWork.GoodsRateGrpCode = rateProtyMngPatternWork.GoodsRateGrpCode;//商品掛率グループコード
                    rateRlationWork.BLGoodsCode = rateProtyMngPatternWork.BlGroupCode;//BL商品コード

                    // --- DEL 2010/09/10 ---------->>>>>
                    //// 得意先の場合、得意先マストから検索する
                    //if ("2L".Equals(_rateSettingDivide))
                    //{
                    //    rateRlationWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(this._dataColumnCdMast));
                    //    rateRlationWork.MasterNm = rateRlationWork.CustomerCode.ToString("D8") + " " + SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(this._dataColumnNm));

                    //}
                    //// 得意先+仕入先,或は得意先掛率G+仕入先 の場合、仕入先マストから検索する
                    //else if ("1L".Equals(_rateSettingDivide)
                    //    || "3L".Equals(_rateSettingDivide)
                    //    || "5L".Equals(_rateSettingDivide))
                    //{
                    //    rateRlationWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(this._dataColumnCdMast));
                    //    rateRlationWork.MasterNm = rateRlationWork.SupplierCd.ToString("D6") + " " + SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(this._dataColumnNm));

                    //}
                    //// 得意先掛率Gの場合、得意先マスタ（掛率グループ）から検索する
                    //else if ("4L".Equals(_rateSettingDivide))
                    //{
                    //    rateRlationWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(this._dataColumnCdMast));
                    //    rateRlationWork.MasterNm = rateRlationWork.CustRateGrpCode.ToString("D4");
                    //}
                    //// BL商品コードの場合、BL商品コードから検索する
                    //else if ("6H".Equals(_rateSettingDivide))
                    //{
                    //    rateRlationWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(this._dataColumnCdMast));
                    //    rateRlationWork.MasterNm = rateRlationWork.BLGoodsCode.ToString("D5") + " " + SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(this._dataColumnNm));
                    //}
                    //// ｸﾞﾙｰﾌﾟｺｰﾄﾞの場合、ｸﾞﾙｰﾌﾟｺｰﾄﾞから検索する
                    //else if ("6I".Equals(_rateSettingDivide))
                    //{
                    //    rateRlationWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(this._dataColumnCdMast));
                    //    rateRlationWork.MasterNm = rateRlationWork.BLGroupCode.ToString("D5") + " " + SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(this._dataColumnNm));
                    //}
                    //// 中分類の場合、商品中分類マスタ（ユーザー登録）から検索する
                    //else if ("6J".Equals(_rateSettingDivide))
                    //{
                    //    rateRlationWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(this._dataColumnCdMast));
                    //    rateRlationWork.MasterNm = rateRlationWork.GoodsRateGrpCode.ToString("D4") + " " + SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(this._dataColumnNm));
                    //}
                    //// メーカーの場合、メーカーから検索する
                    //else if ("6K".Equals(_rateSettingDivide))
                    //{
                    //    rateRlationWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(this._dataColumnCdMast));
                    //    rateRlationWork.MasterNm = rateRlationWork.GoodsMakerCd.ToString("D4") + " " + SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(this._dataColumnNm));
                    //}
                    // --- DEL 2010/09/10 ----------<<<<<

                    #endregion
                    break;
                case 3:
                    #region パターン：層別指定
                    rateRlationWork.CustRateGrpCode = rateProtyMngPatternWork.CustRateGrpCode;//　画面.得意先掛率G
                    rateRlationWork.CustomerCode = rateProtyMngPatternWork.CustomerCode;//　画面.得意先
                    rateRlationWork.SupplierCd = rateProtyMngPatternWork.SupplierCd;//　画面.仕入先
                    rateRlationWork.GoodsMakerCd = rateProtyMngPatternWork.GoodsMakerCd;//　画面.メーカー
                    #endregion
                    break;
                case 4:
                    #region パターン：商品掛率G指定
                    rateRlationWork.CustRateGrpCode = rateProtyMngPatternWork.CustRateGrpCode;//　画面.得意先掛率G
                    rateRlationWork.CustomerCode = rateProtyMngPatternWork.CustomerCode;//　画面.得意先
                    rateRlationWork.SupplierCd = rateProtyMngPatternWork.SupplierCd;//　画面.仕入先
                    rateRlationWork.GoodsMakerCd = rateProtyMngPatternWork.GoodsMakerCd;//　画面.メーカー
                    // --- DEL 2010/09/09 ---------->>>>>
                    //rateRlationWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    //rateRlationWork.MasterNm = rateRlationWork.GoodsRateGrpCode.ToString("D4") + " " + SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));
                    // --- DEL 2010/09/09 ----------<<<<<
                    #endregion
                    break;
                case 5:
                    #region パターン：グループコード指定
                    rateRlationWork.GoodsRateRank = rateProtyMngPatternWork.GoodsRateRank.Trim();//　画面.層別
                    rateRlationWork.CustRateGrpCode = rateProtyMngPatternWork.CustRateGrpCode;//　画面.得意先掛率G
                    rateRlationWork.CustomerCode = rateProtyMngPatternWork.CustomerCode;//　画面.得意先
                    rateRlationWork.SupplierCd = rateProtyMngPatternWork.SupplierCd;//　画面.仕入先
                    rateRlationWork.GoodsMakerCd = rateProtyMngPatternWork.GoodsMakerCd;//　画面.メーカー
                    //rateRlationWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));// DEL 2010/09/14
                    //rateRlationWork.MasterNm = rateRlationWork.BLGroupCode.ToString("D5") + " " + SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPKANANAMERF"));// DEL 2010/09/14
                    #endregion
                    break;
                case 6:
                    #region パターン：メーカー指定
                    rateRlationWork.CustRateGrpCode = rateProtyMngPatternWork.CustRateGrpCode;//　画面.得意先掛率G
                    rateRlationWork.CustomerCode = rateProtyMngPatternWork.CustomerCode;//　画面.得意先
                    rateRlationWork.SupplierCd = rateProtyMngPatternWork.SupplierCd;//　画面.仕入先
                    //rateRlationWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF")); // DEL 2010/09/14
                    //rateRlationWork.MasterNm = rateRlationWork.GoodsMakerCd.ToString("D4") + " " + SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF")); // DEL 2010/09/14
                    #endregion
                    break;
            }
            // --------ADD 2010/09/26-------->>>>>
            if (rateRlationWork.GoodsMakerCd == 0)
            {
                rateRlationWork.GoodsMakerCd = -1;
            }
            if (rateRlationWork.BLGoodsCode == 0)
            {
                rateRlationWork.BLGoodsCode = -1;
            }
            if (rateRlationWork.BLGroupCode == 0)
            {
                rateRlationWork.BLGroupCode = -1;
            }
            if (rateRlationWork.CustRateGrpCode == 0)
            {
                rateRlationWork.CustRateGrpCode = -1;
            }
            if (rateRlationWork.GoodsRateGrpCode == 0)
            {
                rateRlationWork.GoodsRateGrpCode = -1;
            }
            if (rateRlationWork.SupplierCd == 0)
            {
                rateRlationWork.SupplierCd = -1;
            }
            if (rateRlationWork.CustomerCode == 0)
            {
                rateRlationWork.CustomerCode = -1;
            }
            // --------ADD 2010/09/26--------<<<<<
            # endregion

            return rateRlationWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → rateProtyMngPatternWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RateRlationWork オブジェクト</returns>
        /// <param name="patternMode">モード(0:BLコード;1:品番指定;2:単独指定;3:層別指定;4:商品掛率G指定;5:グループコード指定;6:メーカー指定)</param>
        /// <param name="convertDoubleRelease">数値変換処理</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <remarks>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/10</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/06/18</br>
        /// </remarks>
        //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
        //private RateRlationWork CopyToRateFromReader(ref SqlDataReader myReader, int patternMode)
        private RateRlationWork CopyToRateFromReader(ref SqlDataReader myReader, int patternMode, ConvertDoubleRelease convertDoubleRelease, string enterpriseCode)
        //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
        {
            RateRlationWork rateRlationWork = new RateRlationWork();

            # region クラスへ格納
            rateRlationWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            rateRlationWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            rateRlationWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            rateRlationWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            rateRlationWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            rateRlationWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            rateRlationWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
            rateRlationWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSRATEGRPCODERF"));
            rateRlationWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            rateRlationWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            rateRlationWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
            rateRlationWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            rateRlationWork.LotCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LOTCOUNTRF"));
            rateRlationWork.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICEFLRF"));
            rateRlationWork.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATEVALRF"));
            rateRlationWork.UnPrcFracProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UNPRCFRACPROCUNITRF"));
            rateRlationWork.UnPrcFracProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCFRACPROCDIVRF"));
            rateRlationWork.GrsProfitSecureRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GRSPROFITSECURERATERF"));
            rateRlationWork.UpRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UPRATERF"));

            rateRlationWork.UpdateLineFlg = true; // ADD 2010/09/10

            switch (patternMode)
            {
                case 0://BLコード
                    rateRlationWork.MasterNm = rateRlationWork.BLGoodsCode.ToString("D5") + " " + SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
                    break;
                case 1://品番指定
                    //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
                    //rateRlationWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));
                    convertDoubleRelease.EnterpriseCode = enterpriseCode;
                    convertDoubleRelease.GoodsMakerCd = rateRlationWork.GoodsMakerCd;
                    convertDoubleRelease.GoodsNo = rateRlationWork.GoodsNo;
                    convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));

                    // 変換処理実行
                    convertDoubleRelease.ReleaseProc();

                    rateRlationWork.ListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
                    //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
                    rateRlationWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
                    break;
                case 2://単独指定
                    rateRlationWork.MasterNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(this._dataColumnNm));
                    // --- DEL 2010/09/10 ---------->>>>>
                    //// 得意先の場合、得意先マストから検索する
                    //if ("2L".Equals(_rateSettingDivide))
                    //{
                    //    rateRlationWork.MasterNm = rateRlationWork.CustomerCode.ToString("D8") + " " + SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(this._dataColumnNm));
                    //}
                    //// 得意先+仕入先,或は得意先掛率G+仕入先 の場合、仕入先マストから検索する
                    //else if ("1L".Equals(_rateSettingDivide)
                    //    || "3L".Equals(_rateSettingDivide)
                    //    || "5L".Equals(_rateSettingDivide))
                    //{
                    //    rateRlationWork.MasterNm = rateRlationWork.SupplierCd.ToString("D6") + " " + SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(this._dataColumnNm));
                    //}
                    //// 得意先掛率Gの場合、得意先マスタ（掛率グループ）から検索する
                    //else if ("4L".Equals(_rateSettingDivide))
                    //{
                    //    rateRlationWork.MasterNm = rateRlationWork.CustRateGrpCode.ToString("D4");
                    //}
                    //// BL商品コードの場合、BL商品コードから検索する
                    //else if ("6H".Equals(_rateSettingDivide))
                    //{
                    //    rateRlationWork.MasterNm = rateRlationWork.BLGoodsCode.ToString("D5") + " " + SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(this._dataColumnNm));
                    //}
                    //// ｸﾞﾙｰﾌﾟｺｰﾄﾞの場合、ｸﾞﾙｰﾌﾟｺｰﾄﾞから検索する
                    //else if ("6I".Equals(_rateSettingDivide))
                    //{
                    //    rateRlationWork.MasterNm = rateRlationWork.BLGroupCode.ToString("D5") + " " + SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(this._dataColumnNm));
                    //}
                    //// 中分類の場合、商品中分類マスタ（ユーザー登録）から検索する
                    //else if ("6J".Equals(_rateSettingDivide))
                    //{
                    //    rateRlationWork.MasterNm = rateRlationWork.GoodsRateGrpCode.ToString("D4") + " " + SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(this._dataColumnNm));
                    //}
                    //// メーカーの場合、メーカーから検索する
                    //else if ("6K".Equals(_rateSettingDivide))
                    //{
                    //    rateRlationWork.MasterNm = rateRlationWork.GoodsMakerCd.ToString("D4") + " " + SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(this._dataColumnNm));
                    //}
                    // --- DEL 2010/09/10 ----------<<<<<
                    break;
                case 3://層別指定
                    break;
                case 4://商品掛率G指定
                    rateRlationWork.MasterNm = rateRlationWork.GoodsRateGrpCode.ToString("D4") + " " + SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));
                    break;
                case 5://グループコード指定
                    rateRlationWork.MasterNm = rateRlationWork.BLGroupCode.ToString("D5") + " " + SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPNAMERF"));  //UPD 2010/09/17
                    break;
                case 6://メーカー指定
                    rateRlationWork.MasterNm = rateRlationWork.GoodsMakerCd.ToString("D4") + " " + SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    break;

            }
            # endregion

            return rateRlationWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → RateProtyMngWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SupplierWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        private RateProtyMngWork CopyToRateProtyMngWorkFromReader(ref SqlDataReader myReader)
        {
            RateProtyMngWork rateProtyMngWork = new RateProtyMngWork();

            # region クラスへ格納
            rateProtyMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            rateProtyMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            rateProtyMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            rateProtyMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            rateProtyMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            rateProtyMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            rateProtyMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            rateProtyMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            rateProtyMngWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            rateProtyMngWork.UnitPriceKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNITPRICEKINDRF"));
            rateProtyMngWork.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESETTINGDIVIDERF"));
            rateProtyMngWork.RatePriorityOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEPRIORITYORDERRF"));
            rateProtyMngWork.RateMngGoodsCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGGOODSCDRF"));
            rateProtyMngWork.RateMngGoodsNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGGOODSNMRF"));
            rateProtyMngWork.RateMngCustCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGCUSTCDRF"));
            rateProtyMngWork.RateMngCustNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGCUSTNMRF"));
            # endregion

            return rateProtyMngWork;
        }
        # endregion

        # region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }

            return retSqlConnection;
        }

        /// <summary>
        /// SqlTransaction生成処理
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <returns>生成されたSqlTransaction、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        private SqlTransaction CreateTransaction(ref SqlConnection sqlConnection)
        {
            SqlTransaction sqlTransaction = null;
            if (sqlConnection != null)
            {
                // DBに接続されていない場合はここで接続する
                if ((sqlConnection.State & ConnectionState.Open) == 0)
                {
                    sqlConnection.Open();
                }

                // トランザクションの生成(開始)
#if DEBUG
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);
#else
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
#endif
            }

            return sqlTransaction;
        }
        // --- ADD 2010/09/10 ---------->>>>>
        /// <summary>
        /// 掛率設定マスタ情報を登録、更新します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="rateWorkList">RateWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率設定マスタ情報を登録、更新します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2010/09/10</br>
        private int WriteSubSectionProc(ref ArrayList updateList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            bool updateBool = false;   // ADD 2010/09/19

            string command = string.Empty;
            //command = "SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM RATERF" + Environment.NewLine;  // DEL 2010/09/19
            command = " SELECT MIN(LOTCOUNTRF) AS LOTCOUNT FROM RATERF";    // ADD 2010/09/19
            command += " WHERE" + Environment.NewLine;
            command += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            command += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
            command += "  AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD" + Environment.NewLine;
            command += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
            command += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
            command += "  AND GOODSRATERANKRF=@FINDGOODSRATERANK" + Environment.NewLine;
            command += "  AND GOODSRATEGRPCODERF=@FINDGOODSRATEGRPCODE" + Environment.NewLine;
            command += "  AND BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
            command += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
            command += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
            command += "  AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE" + Environment.NewLine;
            command += "  AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
            //command += "  AND LOTCOUNTRF=@FINDLOTCOUNT" + Environment.NewLine;  // DEL 2010/09/19

            try
            {
                for (int i = 0; i < updateList.Count; i++)
                {
                    RateWork rateWork = updateList[i] as RateWork;

                    //Selectコマンドの生成
                    sqlCommand = new SqlCommand(command, sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaUnitRateSetDivCd = sqlCommand.Parameters.Add("@FINDUNITRATESETDIVCD", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    SqlParameter findParaGoodsRateRank = sqlCommand.Parameters.Add("@FINDGOODSRATERANK", SqlDbType.NChar);
                    SqlParameter findParaGoodsRateGrpCode = sqlCommand.Parameters.Add("@FINDGOODSRATEGRPCODE", SqlDbType.Int);
                    SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                    SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaCustRateGrpCode = sqlCommand.Parameters.Add("@FINDCUSTRATEGRPCODE", SqlDbType.Int);
                    SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                    //SqlParameter findParaLotCount = sqlCommand.Parameters.Add("@FINDLOTCOUNT", SqlDbType.Float);   // DEL 2010/09/19

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(rateWork.SectionCode);
                    findParaUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
                    findParaGoodsNo.Value = rateWork.GoodsNo;
                    findParaGoodsRateRank.Value = rateWork.GoodsRateRank;
                    findParaGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsRateGrpCode);
                    findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGroupCode);
                    findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGoodsCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustomerCode);
                    findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustRateGrpCode);
                    findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rateWork.SupplierCd);
                    //findParaLotCount.Value = SqlDataMediator.SqlSetDouble(rateWork.LotCount);  // DEL 2010/09/19

                    myReader = sqlCommand.ExecuteReader();

                    // UPD 2010/09/19  --- >>>>
                    if (myReader.Read())
                    {
                        double lotCountDouble = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LOTCOUNT"));

                        // 検索あるの場合、
                        if (lotCountDouble < MIN_DOUBLE && lotCountDouble > -MIN_DOUBLE)
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (rateWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            updateBool = false;      // ADD 2010/09/19  

                            //新規作成時のSQL文を生成
                            sqlCommand.CommandText = "INSERT INTO RATERF" + Environment.NewLine;
                            sqlCommand.CommandText += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,SECTIONCODERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,UNITRATESETDIVCDRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,UNITPRICEKINDRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,RATESETTINGDIVIDERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,RATEMNGGOODSCDRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,RATEMNGGOODSNMRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,RATEMNGCUSTCDRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,RATEMNGCUSTNMRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,GOODSNORF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,GOODSRATERANKRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,GOODSRATEGRPCODERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,BLGROUPCODERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,BLGOODSCODERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,CUSTOMERCODERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,CUSTRATEGRPCODERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,SUPPLIERCDRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,LOTCOUNTRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,PRICEFLRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,RATEVALRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,UPRATERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,GRSPROFITSECURERATERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,UNPRCFRACPROCUNITRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,UNPRCFRACPROCDIVRF" + Environment.NewLine;
                            sqlCommand.CommandText += " )" + Environment.NewLine;
                            sqlCommand.CommandText += " VALUES" + Environment.NewLine;
                            sqlCommand.CommandText += " (@CREATEDATETIME" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@SECTIONCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@UNITRATESETDIVCD" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@UNITPRICEKIND" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@RATESETTINGDIVIDE" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@RATEMNGGOODSCD" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@RATEMNGGOODSNM" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@RATEMNGCUSTCD" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@RATEMNGCUSTNM" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@GOODSMAKERCD" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@GOODSNO" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@GOODSRATERANK" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@GOODSRATEGRPCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@BLGROUPCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@BLGOODSCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@CUSTOMERCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@CUSTRATEGRPCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@SUPPLIERCD" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@LOTCOUNT" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@PRICEFL" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@RATEVAL" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@UPRATE" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@GRSPROFITSECURERATE" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@UNPRCFRACPROCUNIT" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@UNPRCFRACPROCDIV" + Environment.NewLine;
                            sqlCommand.CommandText += " )" + Environment.NewLine;

                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)rateWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        else
                        {
                            SqlParameter findParaLotCount = sqlCommand.Parameters.Add("@FINDLOTCOUNT", SqlDbType.Float);
                            updateBool = true;

                            sqlCommand.CommandText = "UPDATE RATERF" + Environment.NewLine;
                            sqlCommand.CommandText += "SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlCommand.CommandText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlCommand.CommandText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlCommand.CommandText += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            sqlCommand.CommandText += " , UNITRATESETDIVCDRF=@UNITRATESETDIVCD" + Environment.NewLine;
                            sqlCommand.CommandText += " , UNITPRICEKINDRF=@UNITPRICEKIND" + Environment.NewLine;
                            sqlCommand.CommandText += " , RATESETTINGDIVIDERF=@RATESETTINGDIVIDE" + Environment.NewLine;
                            sqlCommand.CommandText += " , RATEMNGGOODSCDRF=@RATEMNGGOODSCD" + Environment.NewLine;
                            sqlCommand.CommandText += " , RATEMNGGOODSNMRF=@RATEMNGGOODSNM" + Environment.NewLine;
                            sqlCommand.CommandText += " , RATEMNGCUSTCDRF=@RATEMNGCUSTCD" + Environment.NewLine;
                            sqlCommand.CommandText += " , RATEMNGCUSTNMRF=@RATEMNGCUSTNM" + Environment.NewLine;
                            sqlCommand.CommandText += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                            sqlCommand.CommandText += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                            sqlCommand.CommandText += " , GOODSRATERANKRF=@GOODSRATERANK" + Environment.NewLine;
                            sqlCommand.CommandText += " , GOODSRATEGRPCODERF=@GOODSRATEGRPCODE" + Environment.NewLine;
                            sqlCommand.CommandText += " , BLGROUPCODERF=@BLGROUPCODE" + Environment.NewLine;
                            sqlCommand.CommandText += " , BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                            sqlCommand.CommandText += " , CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
                            sqlCommand.CommandText += " , CUSTRATEGRPCODERF=@CUSTRATEGRPCODE" + Environment.NewLine;
                            sqlCommand.CommandText += " , SUPPLIERCDRF=@SUPPLIERCD" + Environment.NewLine;
                            //sqlCommand.CommandText += " , LOTCOUNTRF=@LOTCOUNT" + Environment.NewLine;
                            sqlCommand.CommandText += " , PRICEFLRF=@PRICEFL" + Environment.NewLine;
                            sqlCommand.CommandText += " , RATEVALRF=@RATEVAL" + Environment.NewLine;
                            sqlCommand.CommandText += " , UPRATERF=@UPRATE" + Environment.NewLine;
                            sqlCommand.CommandText += " , GRSPROFITSECURERATERF=@GRSPROFITSECURERATE" + Environment.NewLine;
                            sqlCommand.CommandText += " , UNPRCFRACPROCUNITRF=@UNPRCFRACPROCUNIT" + Environment.NewLine;
                            sqlCommand.CommandText += " , UNPRCFRACPROCDIVRF=@UNPRCFRACPROCDIV" + Environment.NewLine;
                            sqlCommand.CommandText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND GOODSRATERANKRF=@FINDGOODSRATERANK" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND GOODSRATEGRPCODERF=@FINDGOODSRATEGRPCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND LOTCOUNTRF=@FINDLOTCOUNT" + Environment.NewLine;

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(rateWork.SectionCode);
                            findParaUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
                            findParaGoodsNo.Value = rateWork.GoodsNo;
                            findParaGoodsRateRank.Value = rateWork.GoodsRateRank;
                            findParaGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsRateGrpCode);
                            findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGroupCode);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGoodsCode);
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustomerCode);
                            findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustRateGrpCode);
                            findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rateWork.SupplierCd);
                            //findParaLotCount.Value = SqlDataMediator.SqlSetDouble(rateWork.LotCount);
                            findParaLotCount.Value = SqlDataMediator.SqlSetDouble(lotCountDouble);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)rateWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                    }
                    else
                    {
                        // なし。
                    }
                    // UPD 2010/09/19  --- <<<<

                    if (myReader.IsClosed == false) myReader.Close();

                    #region Parameterオブジェクトの作成(更新用)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraUnitRateSetDivCd = sqlCommand.Parameters.Add("@UNITRATESETDIVCD", SqlDbType.NChar);
                    SqlParameter paraUnitPriceKind = sqlCommand.Parameters.Add("@UNITPRICEKIND", SqlDbType.NChar);
                    SqlParameter paraRateSettingDivide = sqlCommand.Parameters.Add("@RATESETTINGDIVIDE", SqlDbType.NChar);
                    SqlParameter paraRateMngGoodsCd = sqlCommand.Parameters.Add("@RATEMNGGOODSCD", SqlDbType.NChar);
                    SqlParameter paraRateMngGoodsNm = sqlCommand.Parameters.Add("@RATEMNGGOODSNM", SqlDbType.NVarChar);
                    SqlParameter paraRateMngCustCd = sqlCommand.Parameters.Add("@RATEMNGCUSTCD", SqlDbType.NChar);
                    SqlParameter paraRateMngCustNm = sqlCommand.Parameters.Add("@RATEMNGCUSTNM", SqlDbType.NVarChar);
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                    SqlParameter paraGoodsRateRank = sqlCommand.Parameters.Add("@GOODSRATERANK", SqlDbType.NChar);
                    SqlParameter paraGoodsRateGrpCode = sqlCommand.Parameters.Add("@GOODSRATEGRPCODE", SqlDbType.Int);
                    SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                    SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    SqlParameter paraCustRateGrpCode = sqlCommand.Parameters.Add("@CUSTRATEGRPCODE", SqlDbType.Int);
                    SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                    // UPD 2010/09/19  --- >>>>
                    SqlParameter paraLotCount = null;
                    if (!updateBool)
                    {
                        paraLotCount = sqlCommand.Parameters.Add("@LOTCOUNT", SqlDbType.Float);
                    }
                    // UPD 2010/09/19  --- <<<<
                    SqlParameter paraPriceFl = sqlCommand.Parameters.Add("@PRICEFL", SqlDbType.Float);
                    SqlParameter paraRateVal = sqlCommand.Parameters.Add("@RATEVAL", SqlDbType.Float);
                    SqlParameter paraUpRate = sqlCommand.Parameters.Add("@UPRATE", SqlDbType.Float);
                    SqlParameter paraGrsProfitSecureRate = sqlCommand.Parameters.Add("@GRSPROFITSECURERATE", SqlDbType.Float);
                    SqlParameter paraUnPrcFracProcUnit = sqlCommand.Parameters.Add("@UNPRCFRACPROCUNIT", SqlDbType.Float);
                    SqlParameter paraUnPrcFracProcDiv = sqlCommand.Parameters.Add("@UNPRCFRACPROCDIV", SqlDbType.Int);
                    #endregion

                    #region Parameterオブジェクトへ値設定(更新用)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rateWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rateWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(rateWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(rateWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(rateWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(rateWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(rateWork.LogicalDeleteCode);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(rateWork.SectionCode);
                    paraUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
                    paraUnitPriceKind.Value = SqlDataMediator.SqlSetString(rateWork.UnitPriceKind);
                    paraRateSettingDivide.Value = SqlDataMediator.SqlSetString(rateWork.RateSettingDivide);
                    paraRateMngGoodsCd.Value = SqlDataMediator.SqlSetString(rateWork.RateMngGoodsCd);
                    paraRateMngGoodsNm.Value = SqlDataMediator.SqlSetString(rateWork.RateMngGoodsNm);
                    paraRateMngCustCd.Value = SqlDataMediator.SqlSetString(rateWork.RateMngCustCd);
                    paraRateMngCustNm.Value = SqlDataMediator.SqlSetString(rateWork.RateMngCustNm);
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
                    paraGoodsNo.Value = rateWork.GoodsNo;
                    paraGoodsRateRank.Value = rateWork.GoodsRateRank;
                    paraGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsRateGrpCode);
                    paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGroupCode);
                    paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGoodsCode);
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustomerCode);
                    paraCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustRateGrpCode);
                    paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(rateWork.SupplierCd);
                    // UPD 2010/09/19  --- >>>>
                    if (!updateBool)
                    {
                        paraLotCount.Value = SqlDataMediator.SqlSetDouble(rateWork.LotCount);
                    }
                    // UPD 2010/09/19  --- <<<<
                    paraPriceFl.Value = SqlDataMediator.SqlSetDouble(rateWork.PriceFl);
                    paraRateVal.Value = SqlDataMediator.SqlSetDouble(rateWork.RateVal);
                    paraUpRate.Value = SqlDataMediator.SqlSetDouble(rateWork.UpRate);
                    paraGrsProfitSecureRate.Value = SqlDataMediator.SqlSetDouble(rateWork.GrsProfitSecureRate);

                    // UPD 2010/09/19  --- >>>>
                    if (!updateBool)
                    {
                        if ("1".Equals(rateWork.UnitPriceKind) || "2".Equals(rateWork.UnitPriceKind))
                        {
                            paraUnPrcFracProcUnit.Value = SqlDataMediator.SqlSetDouble(0);
                            paraUnPrcFracProcDiv.Value = SqlDataMediator.SqlSetInt32(0);
                        }
                        else
                        {
                            paraUnPrcFracProcUnit.Value = SqlDataMediator.SqlSetDouble(rateWork.UnPrcFracProcUnit);
                            paraUnPrcFracProcDiv.Value = SqlDataMediator.SqlSetInt32(rateWork.UnPrcFracProcDiv);
                        }
                    }
                    else
                    {
                        paraUnPrcFracProcUnit.Value = SqlDataMediator.SqlSetDouble(rateWork.UnPrcFracProcUnit);
                        paraUnPrcFracProcDiv.Value = SqlDataMediator.SqlSetInt32(rateWork.UnPrcFracProcDiv);
                    }
                    // UPD 2010/09/19  --- <<<<
                    #endregion

                    sqlCommand.ExecuteNonQuery();

                    al.Add(rateWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            return status;
        }
        // --- ADD 2010/09/10 ----------<<<<<
        # endregion
    }
}

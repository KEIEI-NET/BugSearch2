//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仕入先変換ツール
// プログラム概要   : 商品管理情報マスタの最適化の為、不要なレコードを削除する。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/07/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日  2009/07/24  修正内容 : PVCS#366 コネクションの解放に関して
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日  2009/07/27  修正内容 : PVCS#369 論理削除区分(LogicalDeleteCode)の判定を追加する。
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入先変換ツールREADDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入先変換ツールREADの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009.07.13</br>
    /// </remarks>
    [Serializable]
    public class SupplierChangeProcDB : RemoteDB, ISupplierChangeProcDB
    {
        #region ■ Const Memebers ■
        private const string ALL_SECTIONCODE = "00";
        private const string MARK_KEY = "<-->";
        private const string MARK_0 = "0";
        #endregion

        #region ■ 仕入先変換ツールの削除処理 ■
        /// <summary>
        /// 仕入先変換ツールの削除処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="readCount">検索件数</param>
        /// <param name="delCount">削除件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入先変換ツールの削除処理を行うクラスです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.07.13</br>
        /// </remarks>
        public int DeleteGoodsMng(string enterpriseCodes, out int readCount, out int delCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            readCount = 0;
            delCount = 0;
            //--------------------------
            // データベースオープン
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            // MOD 2009/07/24 --->>>
            try
            {
            // MOD 2009/07/24 ---<<<
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (_connectionText == null || _connectionText == "")
                {
                    return status;
                }

                sqlConnection = new SqlConnection(_connectionText);
                sqlConnection.Open();

                Dictionary<string, SupplierChangeWork> group1Dic = new Dictionary<string, SupplierChangeWork>();
                Dictionary<string, SupplierChangeWork> group2Dic = new Dictionary<string, SupplierChangeWork>();
                Dictionary<string, SupplierChangeWork> group3Dic = new Dictionary<string, SupplierChangeWork>();
                Dictionary<string, SupplierChangeWork> group4Dic = new Dictionary<string, SupplierChangeWork>();

                // 仕入先変換ツールの画面検索処理
                status = Search(enterpriseCodes, 
                                ref group1Dic,
                                ref group2Dic,
                                ref group3Dic,
                                ref group4Dic,
                                ref sqlConnection);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    readCount = group1Dic.Count + group2Dic.Count + group3Dic.Count + group4Dic.Count;

                    ArrayList delList = new ArrayList();

                    SupplierChangeWork tempWork = null;
                    SupplierChangeWork temp2Work = null;
                    SupplierChangeWork temp3Work = null;
                    SupplierChangeWork temp4Work = null;

                    bool isFlag = false;

                    SupplierChangeWork work = null;
                    string tempKey = string.Empty;

                    foreach (KeyValuePair<string, SupplierChangeWork> temp1Dic in group1Dic)
                    {
                        tempWork = temp1Dic.Value;

                        // 拠点 != "00"の場合、
                        if (!ALL_SECTIONCODE.Equals(tempWork.SectionCode))
                        {
                            // ①拠点＋メーカー＋品番用Dictionary
                            tempKey = ALL_SECTIONCODE + MARK_KEY + MARK_0 + MARK_KEY + Convert.ToString(tempWork.GoodsMakerCd)
                                + MARK_KEY + MARK_0 + MARK_KEY + tempWork.GoodsNo;
                            // リスト内に同一のメーカー＋品番で全社設定("00")のレコードが存在しないかを検索する。
                            if (group1Dic.ContainsKey(tempKey))
                            {
                                work = group1Dic[tempKey];
                                // 存在した場合、仕入先コードと発注ロットが一致した場合は削除対象とする。
                                // MOD 2009/07/27 --->>>
                                if (work.SupplierCd == tempWork.SupplierCd
                                    && work.SupplierLot == tempWork.SupplierLot
                                    && work.LogicalDeleteCode == 0)
                                // MOD 2009/07/27 ---<<<
                                {
                                    delList.Add(tempWork);
                                    continue;
                                }
                                // 一致しなかった場合は、次のループ処理へ
                                else
                                {
                                    continue;
                                }
                            }

                            // ②拠点＋メーカー＋中分類＋ＢＬコード用Dictionary
                            tempKey = tempWork.SectionCode + MARK_KEY + Convert.ToString(tempWork.JoinGoodsMGroup) + MARK_KEY + Convert.ToString(tempWork.GoodsMakerCd)
                                + MARK_KEY + Convert.ToString(tempWork.JoinBLGoodsCode) + MARK_KEY + string.Empty;
                            // リスト内に同一の拠点＋メーカー＋中分類＋ＢＬコードのレコードが存在しないかを検索する。
                            if (group2Dic.ContainsKey(tempKey))
                            {
                                work = group2Dic[tempKey];
                                // 存在した場合、仕入先コードと発注ロットが一致した場合は削除対象とする。
                                // MOD 2009/07/27 --->>>
                                if (work.SupplierCd == tempWork.SupplierCd
                                    && work.SupplierLot == tempWork.SupplierLot
                                    && work.LogicalDeleteCode == 0)
                                // MOD 2009/07/27 ---<<<
                                {
                                    delList.Add(tempWork);
                                    continue;
                                }
                                // 一致しなかった場合は、次のループ処理へ
                                else
                                {
                                    continue;
                                }
                            }

                            // ③拠点＋メーカー＋中分類＋ＢＬコード用Dictionary
                            tempKey = ALL_SECTIONCODE + MARK_KEY + Convert.ToString(tempWork.JoinGoodsMGroup) + MARK_KEY + Convert.ToString(tempWork.GoodsMakerCd)
                                + MARK_KEY + Convert.ToString(tempWork.JoinBLGoodsCode) + MARK_KEY + string.Empty;
                            // リスト内に同一のメーカー＋品番で全社設定("00")のレコードが存在しないかを検索する。
                            if (group2Dic.ContainsKey(tempKey))
                            {
                                work = group2Dic[tempKey];
                                // 存在した場合、仕入先コードと発注ロットが一致した場合は削除対象とする。
                                // MOD 2009/07/27 --->>>
                                if (work.SupplierCd == tempWork.SupplierCd
                                    && work.SupplierLot == tempWork.SupplierLot
                                    && work.LogicalDeleteCode == 0)
                                // MOD 2009/07/27 ---<<<
                                {
                                    delList.Add(tempWork);
                                    continue;
                                }
                                // 一致しなかった場合は、次のループ処理へ
                                else
                                {
                                    continue;
                                }
                            }

                            // ④拠点＋メーカー＋中分類用Dictionary
                            tempKey = tempWork.SectionCode + MARK_KEY + Convert.ToString(tempWork.JoinGoodsMGroup) + MARK_KEY + Convert.ToString(tempWork.GoodsMakerCd)
                                + MARK_KEY + MARK_0 + MARK_KEY + string.Empty;
                            // リスト内に同一の拠点＋メーカー＋中分類＋ＢＬコードのレコードが存在しないかを検索する。
                            if (group3Dic.ContainsKey(tempKey))
                            {
                                work = group3Dic[tempKey];
                                // 存在した場合、仕入先コードと発注ロットが一致した場合は削除対象とする。
                                // MOD 2009/07/27 --->>>
                                if (work.SupplierCd == tempWork.SupplierCd
                                    && work.SupplierLot == tempWork.SupplierLot
                                    && work.LogicalDeleteCode == 0)
                                // MOD 2009/07/27 ---<<<
                                {
                                    delList.Add(tempWork);
                                    continue;
                                }
                                // 一致しなかった場合は、次のループ処理へ
                                else
                                {
                                    continue;
                                }
                            }

                            // ⑤拠点＋メーカー＋中分類用Dictionary
                            tempKey = ALL_SECTIONCODE + MARK_KEY + Convert.ToString(tempWork.JoinGoodsMGroup) + MARK_KEY + Convert.ToString(tempWork.GoodsMakerCd)
                                + MARK_KEY + MARK_0 + MARK_KEY + string.Empty;
                            // リスト内に同一のメーカー＋品番で全社設定("00")のレコードが存在しないかを検索する。
                            if (group3Dic.ContainsKey(tempKey))
                            {
                                work = group3Dic[tempKey];
                                // 存在した場合、仕入先コードと発注ロットが一致した場合は削除対象とする。
                                // MOD 2009/07/27 --->>>
                                if (work.SupplierCd == tempWork.SupplierCd
                                    && work.SupplierLot == tempWork.SupplierLot
                                    && work.LogicalDeleteCode == 0)
                                // MOD 2009/07/27 ---<<<
                                {
                                    delList.Add(tempWork);
                                    continue;
                                }
                                // 一致しなかった場合は、次のループ処理へ
                                else
                                {
                                    continue;
                                }
                            }

                            // ⑥拠点＋メーカー用Dictionary
                            tempKey = tempWork.SectionCode + MARK_KEY + MARK_0 + MARK_KEY + Convert.ToString(tempWork.GoodsMakerCd)
                                + MARK_KEY + MARK_0 + MARK_KEY + string.Empty;
                            // リスト内に同一の拠点＋メーカー＋中分類＋ＢＬコードのレコードが存在しないかを検索する。
                            if (group4Dic.ContainsKey(tempKey))
                            {
                                work = group4Dic[tempKey];
                                // 存在した場合、仕入先コードと発注ロットが一致した場合は削除対象とする。
                                // MOD 2009/07/27 --->>>
                                if (work.SupplierCd == tempWork.SupplierCd
                                    && work.SupplierLot == tempWork.SupplierLot
                                    && work.LogicalDeleteCode == 0)
                                // MOD 2009/07/27 ---<<<
                                {
                                    delList.Add(tempWork);
                                    continue;
                                }
                                // 一致しなかった場合は、次のループ処理へ
                                else
                                {
                                    continue;
                                }
                            }

                            // ⑦拠点＋メーカー用Dictionary
                            tempKey = ALL_SECTIONCODE + MARK_KEY + MARK_0 + MARK_KEY + Convert.ToString(tempWork.GoodsMakerCd)
                                + MARK_KEY + MARK_0 + MARK_KEY + string.Empty;
                            // リスト内に同一のメーカー＋品番で全社設定("00")のレコードが存在しないかを検索する。
                            if (group4Dic.ContainsKey(tempKey))
                            {
                                work = group4Dic[tempKey];
                                // 存在した場合、仕入先コードと発注ロットが一致した場合は削除対象とする。
                                // MOD 2009/07/27 --->>>
                                if (work.SupplierCd == tempWork.SupplierCd
                                    && work.SupplierLot == tempWork.SupplierLot
                                    && work.LogicalDeleteCode == 0)
                                // MOD 2009/07/27 ---<<<
                                {
                                    delList.Add(tempWork);
                                    continue;
                                }
                                // 一致しなかった場合は、次のループ処理へ
                                else
                                {
                                    continue;
                                }
                            }
                        }
                        // 拠点 == "00"の場合、
                        else
                        {
                            isFlag = false;

                            // ②拠点＋メーカー＋中分類＋ＢＬコード用Dictionary
                            foreach (KeyValuePair<string, SupplierChangeWork> temp2Dic in group2Dic)
                            {
                                temp2Work = temp2Dic.Value;

                                if (!ALL_SECTIONCODE.Equals(temp2Work.SectionCode)
                                    && tempWork.JoinGoodsMGroup == temp2Work.GoodsMGroup
                                    && tempWork.GoodsMakerCd == temp2Work.GoodsMakerCd
                                    && tempWork.JoinBLGoodsCode == temp2Work.BLGoodsCode
                                    && string.IsNullOrEmpty(temp2Work.GoodsNo))
                                {
                                    isFlag = true;
                                    break;
                                }
                            }

                            // １件でも存在した場合、次のループ処理へ
                            if (isFlag)
                            {
                                continue;
                            }

                            // ③拠点＋メーカー＋中分類＋ＢＬコード用Dictionary
                            tempKey = ALL_SECTIONCODE + MARK_KEY + Convert.ToString(tempWork.JoinGoodsMGroup) + MARK_KEY + Convert.ToString(tempWork.GoodsMakerCd)
                                + MARK_KEY + Convert.ToString(tempWork.JoinBLGoodsCode) + MARK_KEY + string.Empty;
                            // リスト内に同一のメーカー＋品番で全社設定("00")のレコードが存在しないかを検索する。
                            if (group2Dic.ContainsKey(tempKey))
                            {
                                work = group2Dic[tempKey];
                                // 存在した場合、仕入先コードと発注ロットが一致した場合は削除対象とする。
                                // MOD 2009/07/27 --->>>
                                if (work.SupplierCd == tempWork.SupplierCd
                                    && work.SupplierLot == tempWork.SupplierLot
                                    && work.LogicalDeleteCode == 0)
                                // MOD 2009/07/27 ---<<<
                                {
                                    delList.Add(tempWork);
                                    continue;
                                }
                                // 一致しなかった場合は、次のループ処理へ
                                else
                                {
                                    continue;
                                }
                            }

                            // ④拠点＋メーカー＋中分類用Dictionary
                            foreach (KeyValuePair<string, SupplierChangeWork> temp3Dic in group3Dic)
                            {
                                temp3Work = temp3Dic.Value;

                                if (!ALL_SECTIONCODE.Equals(temp3Work.SectionCode)
                                    && tempWork.JoinGoodsMGroup == temp3Work.GoodsMGroup
                                    && tempWork.GoodsMakerCd == temp3Work.GoodsMakerCd
                                    && 0 == temp3Work.BLGoodsCode
                                    && string.IsNullOrEmpty(temp3Work.GoodsNo))
                                {
                                    isFlag = true;
                                    break;
                                }
                            }

                            // １件でも存在した場合、次のループ処理へ
                            if (isFlag)
                            {
                                continue;
                            }

                            // ⑤拠点＋メーカー＋中分類用Dictionary
                            tempKey = ALL_SECTIONCODE + MARK_KEY + Convert.ToString(tempWork.JoinGoodsMGroup) + MARK_KEY + Convert.ToString(tempWork.GoodsMakerCd)
                                + MARK_KEY + MARK_0 + MARK_KEY + string.Empty;
                            // リスト内に同一のメーカー＋品番で全社設定("00")のレコードが存在しないかを検索する。
                            if (group3Dic.ContainsKey(tempKey))
                            {
                                work = group3Dic[tempKey];
                                // 存在した場合、仕入先コードと発注ロットが一致した場合は削除対象とする。
                                // MOD 2009/07/27 --->>>
                                if (work.SupplierCd == tempWork.SupplierCd
                                    && work.SupplierLot == tempWork.SupplierLot
                                    && work.LogicalDeleteCode == 0)
                                // MOD 2009/07/27 ---<<<
                                {
                                    delList.Add(tempWork);
                                    continue;
                                }
                                // 一致しなかった場合は、次のループ処理へ
                                else
                                {
                                    continue;
                                }
                            }

                            // ⑥拠点＋メーカー用Dictionary
                            foreach (KeyValuePair<string, SupplierChangeWork> temp4Dic in group4Dic)
                            {
                                temp4Work = temp4Dic.Value;

                                if (!ALL_SECTIONCODE.Equals(temp4Work.SectionCode)
                                    && 0 == temp4Work.GoodsMGroup
                                    && tempWork.GoodsMakerCd == temp4Work.GoodsMakerCd
                                    && 0 == temp4Work.BLGoodsCode
                                    && string.IsNullOrEmpty(temp4Work.GoodsNo))
                                {
                                    isFlag = true;
                                    break;
                                }
                            }

                            // １件でも存在した場合、次のループ処理へ
                            if (isFlag)
                            {
                                continue;
                            }

                            // ⑦拠点＋メーカー用Dictionary
                            tempKey = ALL_SECTIONCODE + MARK_KEY + MARK_0 + MARK_KEY + Convert.ToString(tempWork.GoodsMakerCd)
                                + MARK_KEY + MARK_0 + MARK_KEY + string.Empty;
                            // リスト内に同一のメーカー＋品番で全社設定("00")のレコードが存在しないかを検索する。
                            if (group4Dic.ContainsKey(tempKey))
                            {
                                work = group4Dic[tempKey];
                                // 存在した場合、仕入先コードと発注ロットが一致した場合は削除対象とする。
                                // MOD 2009/07/27 --->>>
                                if (work.SupplierCd == tempWork.SupplierCd
                                    && work.SupplierLot == tempWork.SupplierLot
                                    && work.LogicalDeleteCode == 0)
                                // MOD 2009/07/27 ---<<<
                                {
                                    delList.Add(tempWork);
                                    continue;
                                }
                                // 一致しなかった場合は、次のループ処理へ
                                else
                                {
                                    continue;
                                }
                            }
                        }
                    }
                    // SupplierChangeWorkインスタンスの値をGoodsMngWorkインスタンスの同じIDのプロパティにセットする。
                    ArrayList goodsMngDelArr = new ArrayList();
                    GoodsMngWork goodsMngWork = null;

                    foreach (SupplierChangeWork supplierChangeWork in delList)
                    {
                        goodsMngWork = new GoodsMngWork();
                        goodsMngWork.EnterpriseCode = supplierChangeWork.EnterpriseCode;
                        goodsMngWork.UpdateDateTime = supplierChangeWork.UpdateDateTime;
                        goodsMngWork.SectionCode = supplierChangeWork.SectionCode;
                        goodsMngWork.GoodsMGroup = supplierChangeWork.GoodsMGroup;
                        goodsMngWork.GoodsMakerCd = supplierChangeWork.GoodsMakerCd;
                        goodsMngWork.BLGoodsCode = supplierChangeWork.BLGoodsCode;
                        goodsMngWork.GoodsNo = supplierChangeWork.GoodsNo;
                        goodsMngDelArr.Add(goodsMngWork);
                    }


                    // 商品管理情報マスタリモートの削除メソッドの呼び出しを行う
                    GoodsMngDB _goodsMngDB = new GoodsMngDB();

    #if DEBUG
                    // トランザクション
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);
    #else
                                    // トランザクション
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
    #endif

                    status = _goodsMngDB.DeleteGoodsMngProc(goodsMngDelArr, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 削除件数
                        delCount = goodsMngDelArr.Count;
                    }
                }
            
            }
            // MOD 2009/07/24 --->>>
            catch (Exception ex)
            {
                // 基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "SupplierChangeProcDB.DeleteGoodsMng Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
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
                }

                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            // MOD 2009/07/24 ---<<<
            return status;
        }
        #endregion

        #region ■ 仕入先変換ツールの画面検索処理 ■
        /// <summary>
        /// 仕入先変換ツールの画面検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="group1Dic">拠点＋メーカー＋品番Dictionary</param>
        /// <param name="group2Dic">拠点＋メーカー＋中分類＋ＢＬコードDictionary</param>
        /// <param name="group3Dic">拠点＋メーカー＋中分類Dictionary</param>
        /// <param name="group4Dic">拠点＋メーカーDictionary</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入先変換ツール画面検索を行うクラスです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.07.13</br>
        /// </remarks>
        private int Search(string enterpriseCodes,
                            ref Dictionary<string, SupplierChangeWork> group1Dic,
                            ref Dictionary<string, SupplierChangeWork> group2Dic,
                            ref Dictionary<string, SupplierChangeWork> group3Dic,
                            ref Dictionary<string, SupplierChangeWork> group4Dic,
                            ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            StringBuilder sb = new StringBuilder();
            SupplierChangeWork supplierChangeWork = null;
            string goodsNo = string.Empty;
            int blGoodsCode = 0;
            int goodsMGroup = 0;
            int goodsMakerCd = 0;
            string sectionCode = string.Empty;

            string groupDicKey = string.Empty;


            sqlCommand = new SqlCommand("", sqlConnection);

            try
            {
                // Selectコマンドの生成
                sb.Append(" SELECT A.CREATEDATETIMERF, A.UPDATEDATETIMERF, A.ENTERPRISECODERF, A.FILEHEADERGUIDRF, A.UPDEMPLOYEECODERF, A.UPDASSEMBLYID1RF, A.UPDASSEMBLYID2RF, A.LOGICALDELETECODERF, A.SECTIONCODERF, A.GOODSMGROUPRF, A.GOODSMAKERCDRF, A.BLGOODSCODERF, A.GOODSNORF, A.SUPPLIERCDRF, A.SUPPLIERLOTRF, B.BLGOODSCODERF AS JOINBLGOODSCODERF, D.GOODSMGROUPRF AS JOINGOODSMGROUPRF ");
                sb.Append(" FROM GOODSMNGRF A ");
                sb.Append(" LEFT JOIN GOODSURF B ON ");
                sb.Append(" A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sb.Append(" AND A.GOODSNORF = B.GOODSNORF ");
                sb.Append(" AND A.GOODSMAKERCDRF = B.GOODSMAKERCDRF ");
                sb.Append(" LEFT JOIN BLGOODSCDURF C ON ");
                sb.Append(" B.ENTERPRISECODERF = C.ENTERPRISECODERF ");
                sb.Append(" AND B.BLGOODSCODERF = C.BLGOODSCODERF  ");
                sb.Append(" LEFT JOIN BLGROUPURF D ON ");
                sb.Append(" C.ENTERPRISECODERF = D.ENTERPRISECODERF ");
                sb.Append(" AND C.BLGROUPCODERF = D.BLGROUPCODERF ");
                sb.Append(" WHERE A.ENTERPRISECODERF = @FINDENTERPRISECODE ");

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = enterpriseCodes;

                sqlCommand.CommandText = sb.ToString();
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    supplierChangeWork = new SupplierChangeWork();
                    supplierChangeWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    supplierChangeWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    // MOD 2009/07/27 --->>>
                    supplierChangeWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    // MOD 2009/07/27 ---<<<
                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    sectionCode = sectionCode.Trim();
                    supplierChangeWork.SectionCode = sectionCode;
                    // 商品中分類コード
                    goodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    supplierChangeWork.GoodsMGroup = goodsMGroup;
                    // 商品メーカーコード
                    goodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    supplierChangeWork.GoodsMakerCd = goodsMakerCd;
                    // BL商品コード
                    blGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    supplierChangeWork.BLGoodsCode = blGoodsCode;
                    // 商品番号
                    goodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    supplierChangeWork.GoodsNo = goodsNo;
                    supplierChangeWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    supplierChangeWork.SupplierLot = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERLOTRF"));
                    supplierChangeWork.JoinBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINBLGOODSCODERF"));
                    supplierChangeWork.JoinGoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINGOODSMGROUPRF"));

                    groupDicKey = sectionCode + MARK_KEY + Convert.ToString(goodsMGroup) + MARK_KEY + Convert.ToString(goodsMakerCd) + MARK_KEY + Convert.ToString(blGoodsCode) + MARK_KEY + goodsNo;

                    // 商品管理情報マスタ.品番 != string.Empty
                    if (!string.IsNullOrEmpty(goodsNo))
                    {
                        group1Dic.Add(groupDicKey, supplierChangeWork);
                    }
                    // 商品管理情報マスタ.BLコード != 0
                    else if (blGoodsCode != 0)
                    {
                        group2Dic.Add(groupDicKey, supplierChangeWork);
                    }
                    // 商品管理情報マスタ.中分類コード != 0 AND 商品管理情報マスタ.BLコード == 0
                    else if (blGoodsCode == 0 && goodsMGroup != 0)
                    {
                        group3Dic.Add(groupDicKey, supplierChangeWork);
                    }
                    // 商品管理情報マスタ.メーカーコード != 0 AND 商品管理情報マスタ.中分類コード == 0 AND 商品管理情報マスタ.BLコード == 0 AND 商品管理情報マスタ.品番 == string.Empty
                    else if (string.IsNullOrEmpty(goodsNo) && blGoodsCode == 0 && goodsMGroup == 0 && goodsMakerCd != 0)
                    {
                        group4Dic.Add(groupDicKey, supplierChangeWork);
                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "SupplierChangeProcDB.Search Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }
            return status;
        }
        #endregion
    }
}

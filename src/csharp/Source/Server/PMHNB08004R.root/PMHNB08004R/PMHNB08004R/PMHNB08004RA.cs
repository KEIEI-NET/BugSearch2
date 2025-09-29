//**********************************************************************//
// System           :   ＰＭ．ＮＳ
// Sub System       :
// Program name     :   自由帳票（売上伝票）　リモートオブジェクト
//                  :   PMHNB08004R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programer        :   22018 鈴木 正臣
// Date             :   2008.06.03
//----------------------------------------------------------------------//
// Update Note      :   2009.07.24 劉洋
//                      自由帳票（UOE伝票）
// Update Note      :   2009.07.27 汪千来
//                      自由帳票（売上伝票）A800
// Update Note      :   2010.06.08 張凱
//                      自由帳票（売上伝票）
// Update Note      :   2011.07.19 豆昌紅
//                      自由帳票（売上伝票、UOE伝票）自動回答区分(SCM)追加
// Update Note      :   2011/08/17 caohh
//                      リモート伝発：伝票P001対応
// Update Note      :   2011/08/11 zhouzy
//                      リモート伝発
// Update Note      :   2020/03/18 寺田義啓
// 管理番号         :   11670121-00 S＆E改良対応
//----------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co,. Ltd
//**********************************************************************//
using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections.Generic;

using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
//using Broadleaf.Application.UIData;  // DEL caohh 2011/08/17
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
//using Broadleaf.Library.Globarization; // DEL caohh 2011/08/17
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 自由帳票（売上伝票）　リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 自由帳票印字位置設定マスタ取得を行うクラスです。</br>
    /// <br>Programmer : 22018　鈴木　正臣</br>
    /// <br>Date       : 2008.06.03</br>
    /// <br>Update Note: 劉洋　2009.07.24 オートバックス設定追加</br>
    /// <br>Update Note: 2010/03/01  30531 大矢 睦美</br>
    /// <br>           : Mantis【15082】税率設定マスタ、売上金額処理区分設定マスタ追加</br>
    /// <br></br>
    /// <br>Update Note: 2010/03/24 22018  鈴木 正臣</br>
    /// <br>           : ＱＲコード印刷対応の為、得意先マスタのＱＲコード印字区分を追加</br>
    /// <br></br>
    /// <br>Update Note: 2010/06/08 張凱 障害改良対応（７月リリース分）の対応</br>
    /// <br>           : 売上データの伝票情報が取得できない場合は、売上履歴データを読み込んで伝票情報を取得するようにする。</br>
    /// <br></br>
    /// <br>Update Note: 2010/06/21 30517  夏野 駿希</br>
    /// <br>           : Mantis.15558　UOE伝票発行でユーザーガイドを取得しないように修正</br>
    /// <br></br>
    /// <br>Update Note: 2010/07/06 30517  夏野 駿希</br>
    /// <br>           : QRコード携帯メール対応</br>
    /// <br></br>
    /// <br>Update Note: 2011/08/17 caohh</br>
    /// <br>           : リモート伝発：伝票P001対応</br>
    /// <br></br>
    /// <br>Update Note : 2020/03/18 寺田義啓</br>
    /// <br>管理番号    : 11670121-00 S＆E改良対応</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class FrePSalesSlipDB : RemoteDB, IFrePSalesSlipDB
    {
        /// <summary>
        /// 自由帳票（売上伝票）　リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 22018 鈴木　正臣</br>
        /// <br>Date       : 2008.06.03</br>
        /// </remarks>
        public FrePSalesSlipDB()
        {
        }

        #region [Search伝票]
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="frePrtCmnExtPrmWork">自由帳票共通抽出パラメータ</param>
        /// <param name="frePSalesSlipRetWorkList">抽出結果リスト</param>
        /// <param name="frePMasterList">関連マスタリスト</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note         : 指定された自由帳票検索結果クラスワークLISTを取得します。</br>
        /// <br>Programmer   : 22018 鈴木　正臣</br>
        /// <br>Date         : 2008.06.03</br>
        /// </remarks>
        public int Search(object frePrtCmnExtPrmWork, out object frePSalesSlipRetWorkList, out object frePMasterList, out bool msgDiv, out string errMsg)
        {
            return SearchProc(frePrtCmnExtPrmWork, out frePSalesSlipRetWorkList, out frePMasterList, out msgDiv, out errMsg);
        }
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="frePrtCmnExtPrmWork">自由帳票共通抽出パラメータ</param>
        /// <param name="frePSalesSlipRetWorkList">抽出結果リスト</param>
        /// <param name="frePMasterList">関連マスタリスト</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        private int SearchProc(object frePrtCmnExtPrmWork, out object frePSalesSlipRetWorkList, out object frePMasterList, out bool msgDiv, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlEncryptInfo sqlEncryptInfo = null;
            msgDiv = false;
            errMsg = string.Empty;
            frePSalesSlipRetWorkList = null;
            frePMasterList = null;

            FrePSalesSlipParaWork extPrm;
            if (frePrtCmnExtPrmWork is FrePSalesSlipParaWork)
            {
                extPrm = (frePrtCmnExtPrmWork as FrePSalesSlipParaWork);
            }
            else
            {
                // デシリアライズ
                extPrm = (FrePSalesSlipParaWork)XmlByteSerializer.Deserialize((byte[])frePrtCmnExtPrmWork, typeof(FrePSalesSlipParaWork));
            }

            SqlConnection sqlConnection = null;
            
            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //// 暗号化情報設定
                //if ((extPrm.CipherItemsLs != null) && (extPrm.CipherItemsLs.Count > 0))
                //{
                //    sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, extPrm.CipherItemsLs.ToArray());
                //    sqlEncryptInfo.OpenSymKey(ref sqlConnection);
                //}

                // 関連マスタ抽出   
                status = SearchSetInfos(extPrm, out frePMasterList, ref sqlConnection);
               

                // データ抽出
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = SearchProc(extPrm, out frePSalesSlipRetWorkList, ref sqlConnection);
                }

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    frePSalesSlipRetWorkList = null;
                    frePMasterList = null;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "FrePDailyExtRetDB_Search\n" + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "自由帳票（売上伝票）抽出処理中にタイムアウトが発生しました。";
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FrePDailyExtRetDB_Search\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                //暗号化キークローズ
                if (sqlEncryptInfo != null)
                {
                    if (sqlEncryptInfo.IsOpen)
                    {
                        sqlEncryptInfo.CloseSymKey(ref sqlConnection);
                    }
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }

            return status;
        }

        /// <summary>
        /// データ抽出処理（メイン）
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="frePSalesSlipRetWorkList"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        /// <br>Update Note: 2010/06/08 張凱 障害改良対応（７月リリース分）の対応</br>
        /// <br>           : 売上データの伝票情報が取得できない場合は、売上履歴データを読み込んで伝票情報を取得するようにする。</br>

        private int SearchProc(FrePSalesSlipParaWork extPrm, out object frePSalesSlipRetWorkList, ref SqlConnection sqlConnection)
        {
            frePSalesSlipRetWorkList = null;

            List<FrePSalesSlipWork> slipList = null;
            Dictionary<FrePSalesSlipParaWork.FrePSalesSlipParaKey, List<FrePSalesDetailWork>> detailListDic = null;

            // 伝票ヘッダ抽出処理
            int status = SearchProcOfSlip(extPrm, out slipList, sqlConnection);

            // -------UPD 2010/06/08------->>>>>
            //// 伝票明細抽出処理
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    status = SearchProcOfDetail(extPrm, out detailListDic, sqlConnection);
            //}

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 売上履歴データ.伝票ヘッダ抽出処理
                status = SearchProcOfHistory(extPrm, out slipList, sqlConnection);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 売上履歴明細データ.伝票明細抽出処理
                    status = SearchProcOfDetailForHistory(extPrm, out detailListDic, sqlConnection);
                }
            }
            else
            {
                // 伝票明細抽出処理
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = SearchProcOfDetail(extPrm, out detailListDic, sqlConnection);
                }
            }

            // -------UPD 2010/06/08-------<<<<<

            // 返却データ生成
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                CustomSerializeArrayList retList = new CustomSerializeArrayList();
                foreach (FrePSalesSlipWork slipWork in slipList)
                {
                    CustomSerializeArrayList newSlipList = new CustomSerializeArrayList();
                    newSlipList.Add(slipWork);
                    FrePSalesSlipParaWork.FrePSalesSlipParaKey key = CreateSalesSlipKey(slipWork);
                    if (detailListDic.ContainsKey(key))
                    {
                        newSlipList.Add(detailListDic[key]);
                    }
                    retList.Add(newSlipList);
                }
                frePSalesSlipRetWorkList = retList;
            }

            return status;
        }

        #endregion

        # region [Search見積書]
        /// <summary>
        /// 検索処理(見積書)
        /// </summary>
        /// <param name="frePrtCmnExtPrmWork">自由帳票共通抽出パラメータ</param>
        /// <param name="frePEstFmRetWorkList">抽出結果リスト</param>
        /// <param name="frePMasterList">関連マスタリスト</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note         : 指定された自由帳票検索結果クラスワークLISTを取得します。</br>
        /// <br>Programmer   : 22018 鈴木　正臣</br>
        /// <br>Date         : 2008.06.03</br>
        /// </remarks>
        public int SearchForEstFm(object frePrtCmnExtPrmWork, out object frePEstFmRetWorkList, out object frePMasterList, out bool msgDiv, out string errMsg)
        {
            return SearchForEstFmProc(frePrtCmnExtPrmWork, out frePEstFmRetWorkList, out frePMasterList, out msgDiv, out errMsg);
        }
        /// <summary>
        /// 検索処理(見積書)
        /// </summary>
        /// <param name="frePrtCmnExtPrmWork">自由帳票共通抽出パラメータ</param>
        /// <param name="frePEstFmRetWorkList">抽出結果リスト</param>
        /// <param name="frePMasterList">関連マスタリスト</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        private int SearchForEstFmProc(object frePrtCmnExtPrmWork, out object frePEstFmRetWorkList, out object frePMasterList, out bool msgDiv, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlEncryptInfo sqlEncryptInfo = null;
            msgDiv = false;
            errMsg = string.Empty;
            frePEstFmRetWorkList = null;
            frePMasterList = null;

            FrePEstFmParaWork extPrm;
            if (frePrtCmnExtPrmWork is FrePEstFmParaWork)
            {
                extPrm = (frePrtCmnExtPrmWork as FrePEstFmParaWork);
            }
            else
            {
                // デシリアライズ
                extPrm = (FrePEstFmParaWork)XmlByteSerializer.Deserialize((byte[])frePrtCmnExtPrmWork, typeof(FrePEstFmParaWork));
            }

            

            SqlConnection sqlConnection = null;
            
            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //// 暗号化情報設定
                //if ((extPrm.CipherItemsLs != null) && (extPrm.CipherItemsLs.Count > 0))
                //{
                //    sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, extPrm.CipherItemsLs.ToArray());
                //    sqlEncryptInfo.OpenSymKey(ref sqlConnection);
                //}

                // 関連マスタ抽出（売上伝票用メソッドを流用）
                FrePSalesSlipParaWork salesParaWork = new FrePSalesSlipParaWork();
                salesParaWork.EnterpriseCode = extPrm.EnterpriseCode;
                salesParaWork.FrePSalesSlipParaKeyList = new List<FrePSalesSlipParaWork.FrePSalesSlipParaKey>();
                
                status = SearchSetInfos(salesParaWork, out frePMasterList, ref sqlConnection);
               

                // データ抽出
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = SearchForEstFmProc(extPrm, out frePEstFmRetWorkList, ref sqlConnection);
                }

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    frePEstFmRetWorkList = null;
                    frePMasterList = null;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "FrePDailyExtRetDB_Search\n" + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "自由帳票（見積書）抽出処理中にタイムアウトが発生しました。";
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FrePDailyExtRetDB_Search\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                //暗号化キークローズ
                if (sqlEncryptInfo != null)
                {
                    if (sqlEncryptInfo.IsOpen)
                    {
                        sqlEncryptInfo.CloseSymKey(ref sqlConnection);
                    }
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }

            return status;
        }

        /// <summary>
        /// データ抽出処理（メイン）
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="frePEstFmRetWorkList"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchForEstFmProc(FrePEstFmParaWork extPrm, out object frePEstFmRetWorkList, ref SqlConnection sqlConnection)
        {
            frePEstFmRetWorkList = new CustomSerializeArrayList();
            List<FrePSalesSlipWork> retList = new List<FrePSalesSlipWork>();
            int status = SearchProcOfEstFm(extPrm, ref retList, ref sqlConnection);
            if (status == 0 && (retList is List<FrePSalesSlipWork>) && (retList as List<FrePSalesSlipWork>).Count > 0)
            {
                (frePEstFmRetWorkList as CustomSerializeArrayList).Add((retList as List<FrePSalesSlipWork>)[0]);
            }
            return status;
        }
        # endregion

        # region [SearchＵＯＥ伝票補足]
        /// <summary>
        /// 検索処理（ＵＯＥ伝票）
        /// </summary>
        /// <param name="frePrtCmnExtPrmWork">自由帳票共通抽出パラメータ</param>
        /// <param name="frePSalesSlipRetWorkList">抽出結果リスト</param>
        /// <param name="frePMasterList">関連マスタリスト</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note         : 指定された自由帳票検索結果クラスワークLISTを取得します。</br>
        /// <br>Programmer   : 22018 鈴木　正臣</br>
        /// <br>Date         : 2008.11.19</br>
        /// </remarks>
        public int SearchForUOE(object frePrtCmnExtPrmWork, out object frePSalesSlipRetWorkList, out object frePMasterList, out bool msgDiv, out string errMsg)
        {
            return SearchForUOEProc(frePrtCmnExtPrmWork, out frePSalesSlipRetWorkList, out frePMasterList, out msgDiv, out errMsg);
        }
        /// <summary>
        /// 検索処理（ＵＯＥ伝票）
        /// </summary>
        /// <param name="frePrtCmnExtPrmWork">自由帳票共通抽出パラメータ</param>
        /// <param name="frePSalesSlipRetWorkList">抽出結果リスト</param>
        /// <param name="frePMasterList">関連マスタリスト</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        private int SearchForUOEProc(object frePrtCmnExtPrmWork, out object frePSalesSlipRetWorkList, out object frePMasterList, out bool msgDiv, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlEncryptInfo sqlEncryptInfo = null;
            msgDiv = false;
            errMsg = string.Empty;
            frePSalesSlipRetWorkList = null;
            frePMasterList = null;

            FrePUOESlipParaWork extPrm;
            if (frePrtCmnExtPrmWork is FrePUOESlipParaWork)
            {
                extPrm = (frePrtCmnExtPrmWork as FrePUOESlipParaWork);
            }
            else
            {
                // デシリアライズ
                extPrm = (FrePUOESlipParaWork)XmlByteSerializer.Deserialize((byte[])frePrtCmnExtPrmWork, typeof(FrePUOESlipParaWork));
            }

            SqlConnection sqlConnection = null;
            

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //// 暗号化情報設定
                //if ((extPrm.CipherItemsLs != null) && (extPrm.CipherItemsLs.Count > 0))
                //{
                //    sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, extPrm.CipherItemsLs.ToArray());
                //    sqlEncryptInfo.OpenSymKey(ref sqlConnection);
                //}

                // 関連マスタ抽出
                FrePSalesSlipParaWork salesParaWork = new FrePSalesSlipParaWork();
                salesParaWork.EnterpriseCode = extPrm.EnterpriseCode;
                salesParaWork.FrePSalesSlipParaKeyList = new List<FrePSalesSlipParaWork.FrePSalesSlipParaKey>();
               
                status = SearchSetInfos(salesParaWork, out frePMasterList, ref sqlConnection);
                

                // データ抽出
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = SearchForUOEProc(extPrm, out frePSalesSlipRetWorkList, ref sqlConnection);
                }

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    frePSalesSlipRetWorkList = null;
                    frePMasterList = null;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "FrePDailyExtRetDB_Search\n" + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "自由帳票（売上伝票）抽出処理中にタイムアウトが発生しました。";
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FrePDailyExtRetDB_Search\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                //暗号化キークローズ
                if (sqlEncryptInfo != null)
                {
                    if (sqlEncryptInfo.IsOpen)
                    {
                        sqlEncryptInfo.CloseSymKey(ref sqlConnection);
                    }
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }

            return status;
        }

        /// <summary>
        /// データ抽出処理（メイン、ＵＯＥ伝票）
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="frePSalesSlipRetWorkList"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchForUOEProc(FrePUOESlipParaWork extPrm, out object frePSalesSlipRetWorkList, ref SqlConnection sqlConnection)
        {
            //-----------------------------------------------------------
            // ＜返却データ構造＞
            // 
            // retList
            //   + newSlipList
            //   |   + SlipWork
            //   |   + List
            //   |       + detailWork
            //   :       :
            //   :
            //
            // retListとnewSlipListはCustomSerializeArrayListです。
            // ListはList<FrePSalesDetailWork>です。
            //-----------------------------------------------------------

            CustomSerializeArrayList retList = new CustomSerializeArrayList();

            foreach (FrePUOESlipParaWork.FrePUOESlipParaUnitWork unitWork in extPrm.UOESlipParaUnitList)
            {
                CustomSerializeArrayList newSlipList = new CustomSerializeArrayList();

                # region [伝票単位]
                // ヘッダ
                FrePSalesSlipWork slipWork = unitWork.SlipWork;
                ReflectUOESlip(extPrm, ref slipWork, ref sqlConnection);
                newSlipList.Add(slipWork);

                // 明細
                List<FrePSalesDetailWork> detailList = new List<FrePSalesDetailWork>();
                for (int index = 0; index < unitWork.DetailWorkList.Count; index++)
                {
                    FrePSalesDetailWork detailWork = unitWork.DetailWorkList[index];
                    ReflectUOEDetail(extPrm, ref detailWork, ref sqlConnection);
                    detailList.Add(detailWork);
                }
                newSlipList.Add(detailList);
                # endregion

                retList.Add(newSlipList);
            }

            frePSalesSlipRetWorkList = retList;

            return 0;
            //return status;
        }

        # endregion

        #region [private メソッド]

        # region [マスタ抽出]
        /// <summary>
        /// 自由帳票（売上伝票）関連マスタ検索処理
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="frePMasterList"></param>
        /// <param name="sqlConnection"></param>
        /// <returns>ステータス</returns>
        /// <remarks>伝票発行に必要な各種マスタを格納して返します。</remarks>
        private int SearchSetInfos(FrePSalesSlipParaWork extPrm, out object frePMasterList, ref SqlConnection sqlConnection)
        {
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            CustomSerializeArrayList slipPrtSetList = new CustomSerializeArrayList();
            int status;

            // 伝票印刷設定 （SFURI09024R.SlipPrtSetDB）
            status = SearchSlipPrtSet(extPrm, ref slipPrtSetList, ref sqlConnection);
            if (slipPrtSetList != null && slipPrtSetList.Count > 0)
            {
                retList.Add(slipPrtSetList[0]);
            }
            if (status != (int)ConstantManagement.DB_Status.ctDB_ERROR) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // 自由帳票印字位置設定 (SFANL08124R.FrePrtPSetDB)
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                try
                {
                    status = SearchFrePrtPSet(extPrm, (SlipPrtSetWork[])slipPrtSetList[0], ref retList, ref sqlConnection);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_ERROR) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch
                {
                }
            }
            // 伝票タイプ管理設定 （DCKHN09134R.CustSlipMngDB）
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                try
                {
                    status = SearchCustSlipMng(extPrm, ref retList, ref sqlConnection);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_ERROR) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch
                {
                }
            }
            // 伝票出力先設定 (DCKHN09264R.SlipOutputSetDB)
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                try
                {
                    status = SearchSlipOutputSet(extPrm, ref retList, ref sqlConnection);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_ERROR) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch
                {
                }
            }
            // 売上全体設定 (DCKHN09224R.SalesTtlStDB)
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                try
                {
                    status = SearchSalesTtlSt(extPrm, ref retList, ref sqlConnection);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_ERROR) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch
                {
                }
            }
            // 全体初期値設定 (SFCMN09084R.AllDefSetDB)
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                try
                {
                    status = SearchAllDefSet(extPrm, ref retList, ref sqlConnection);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_ERROR) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch
                {
                }
            }
            // --- ADD  大矢睦美  2010/03/01 ---------->>>>>
            //税率設定 (SFUKK09004R.TaxRateSetDB)
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                try
                {
                    status = SearchTaxRateSet(extPrm, ref retList, ref sqlConnection);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_ERROR) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch
                { 
                }
            }
            //売上金額処理区分設定 (MAHNB09134R.SalesProcMoneyDB)
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                try
                {
                    status = SearchSalesProcMoney(extPrm, ref retList, ref sqlConnection);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_ERROR) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch
                { 
                }
            }
            // --- ADD  大矢睦美  2010/03/01 ----------<<<<<
            
            frePMasterList = retList;
            return status;
        }

        /// <summary>
        /// Search 伝票印刷設定
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="refRetList"></param>
        /// <param name="sqlConnection"></param>
        private int SearchSlipPrtSet(FrePSalesSlipParaWork extPrm, ref CustomSerializeArrayList refRetList, ref SqlConnection sqlConnection)
        {
            SlipPrtSetDB slipPrtSetDB = new SlipPrtSetDB();

            // 抽出条件の設定
            SlipPrtSetWork paraWork = new SlipPrtSetWork();
            paraWork.EnterpriseCode = extPrm.EnterpriseCode;

            // 検索
            ArrayList retList;
            int status = slipPrtSetDB.Search(out retList, paraWork, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection);

            // 取得結果
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retList != null)
            {
                refRetList.Add(retList.ToArray(typeof(SlipPrtSetWork)));
            }
            return status;
        }
        /// <summary>
        /// Search 伝票タイプ管理設定（旧 得意先マスタ(伝票管理)）
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="refRetList"></param>
        /// <param name="sqlConnection"></param>
        private int SearchCustSlipMng(FrePSalesSlipParaWork extPrm, ref CustomSerializeArrayList refRetList, ref SqlConnection sqlConnection)
        {
            CustSlipMngDB custSlipMngDB = new CustSlipMngDB();

            CustSlipMngWork paraWork = new CustSlipMngWork();
            paraWork.EnterpriseCode = extPrm.EnterpriseCode;

            // 検索
            ArrayList retList;
            int status = custSlipMngDB.SearchCustSlipMngProc(out retList, paraWork, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection);

            // 取得結果
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retList != null)
            {
                refRetList.Add(retList.ToArray(typeof(CustSlipMngWork)));
            }

            return status;
        }
        /// <summary>
        /// Search 伝票出力先設定
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="refRetList"></param>
        /// <param name="sqlConnection"></param>
        private int SearchSlipOutputSet(FrePSalesSlipParaWork extPrm, ref CustomSerializeArrayList refRetList, ref SqlConnection sqlConnection)
        {
            SlipOutputSetDB slipOutputSetDB = new SlipOutputSetDB();

            // 検索
            ArrayList retList;
            SearchSlipOutputSetParaWork paraWork = new SearchSlipOutputSetParaWork();
            paraWork.EnterpriseCode = extPrm.EnterpriseCode;
            paraWork.CashRegisterNo = -1;
            paraWork.DataInputSystem = 0;
            paraWork.SlipPrtKind = -1;
            int status = slipOutputSetDB.SearchSlipOutputSetProc(out retList, paraWork, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection);

            // 取得結果
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retList != null)
            {
                refRetList.Add(retList.ToArray(typeof(SlipOutputSetWork)));
            }
            return status;
        }
        /// <summary>
        /// Search 売上全体設定
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="refRetList"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchSalesTtlSt(FrePSalesSlipParaWork extPrm, ref CustomSerializeArrayList refRetList, ref SqlConnection sqlConnection)
        {
            SalesTtlStDB salesTtlStDB = new SalesTtlStDB();

            // 検索
            SalesTtlStWork paraWork = new SalesTtlStWork();
            paraWork.EnterpriseCode = extPrm.EnterpriseCode;
            ArrayList retList;
            int status = salesTtlStDB.SearchSalesTtlStProc(out retList, paraWork, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection);

            // 取得結果
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retList != null)
            {
                refRetList.Add(retList.ToArray(typeof(SalesTtlStWork)));
            }
            return status;
        }
        /// <summary>
        /// Search 全体初期値設定
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="refRetList"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchAllDefSet(FrePSalesSlipParaWork extPrm, ref CustomSerializeArrayList refRetList, ref SqlConnection sqlConnection)
        {
            AllDefSetDB allDefSetDB = new AllDefSetDB();

            // 検索
            AllDefSetWork paraWork = new AllDefSetWork();
            paraWork.EnterpriseCode = extPrm.EnterpriseCode;
            ArrayList retList;
            int status = allDefSetDB.Search(out retList, paraWork, ref sqlConnection, ConstantManagement.LogicalMode.GetData0);

            // 取得結果
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retList != null)
            {
                refRetList.Add(retList.ToArray(typeof(AllDefSetWork)));
            }
            return status;
        }

        /// <summary>
        /// Search 自由帳票印字位置設定
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="slipPrtSetList"></param>
        /// <param name="retList"></param>
        /// <param name="sqlConnection"></param>
        private int SearchFrePrtPSet(FrePSalesSlipParaWork extPrm, SlipPrtSetWork[] slipPrtSetList, ref CustomSerializeArrayList retList, ref SqlConnection sqlConnection)
        {
            // 読み込みキーリスト
            List<FrePrtPSetDB.FrePrtPSetReadKey> keyList = new List<FrePrtPSetDB.FrePrtPSetReadKey>();
            foreach (SlipPrtSetWork slipPrtSetWork in slipPrtSetList)
            {
                keyList.Add(GetFrePrtPSetKey(slipPrtSetWork));
            }

            // ユーザーＤＢ検索
            FrePrtPSetDB frePrtPSetDB = new FrePrtPSetDB();
            List<FrePrtPSetWork> frePrtPSetWorkList;
            int status = frePrtPSetDB.SearchFrePrtPSetProc(extPrm.EnterpriseCode, keyList, out frePrtPSetWorkList, ref sqlConnection);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && frePrtPSetWorkList != null)
            {
                retList.Add(frePrtPSetWorkList.ToArray());
            }
            return status;
        }

        // --- ADD  大矢睦美  2010/03/01 ---------->>>>>
        /// <summary>
        /// Search 税率設定
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="refRetList"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchTaxRateSet(FrePSalesSlipParaWork extPrm, ref CustomSerializeArrayList refRetList, ref SqlConnection sqlConnection)
        {                                   
            TaxRateSetDB taxRateSetDB = new TaxRateSetDB();

            //検索
            TaxRateSetWork paraWork = new TaxRateSetWork();
            paraWork.EnterpriseCode = extPrm.EnterpriseCode;
            ArrayList retList;
            int status = taxRateSetDB.Search(out retList, paraWork, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection);

            //取得結果
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retList != null)
            {
                refRetList.Add(retList.ToArray(typeof(TaxRateSetWork)));
            }
            return status;
        }

        /// <summary>
        /// Search 売上金額処理区分設定
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="refRetList"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchSalesProcMoney(FrePSalesSlipParaWork extPrm, ref CustomSerializeArrayList refRetList, ref SqlConnection sqlConnection)
        {
            SalesProcMoneyDB salesProcMoneyDB = new SalesProcMoneyDB();

            //検索
            SalesProcMoneyWork paraWork = new SalesProcMoneyWork();
            //SalesProcMoneyWork salesProcMoneyWork = new SalesProcMoneyWork();
            paraWork.EnterpriseCode = extPrm.EnterpriseCode;
            paraWork.FracProcMoneyDiv = -1;
            paraWork.FractionProcCode = -1;            
            ArrayList retList;
            int status = salesProcMoneyDB.SearchSalesProcMoneyProc(out retList, paraWork, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection);
            
            //取得結果
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retList != null)
            {
                refRetList.Add(retList.ToArray(typeof(SalesProcMoneyWork)));
            }
            return status;
        }
        // --- ADD  大矢睦美  2010/03/01 ----------<<<<<
       
        /// <summary>
        /// 自由帳票印字位置設定Readキー取得処理
        /// </summary>
        /// <param name="slipPrtSetWork">伝票印字位置設定</param>
        /// <returns>自由帳票印字位置設定Readキー</returns>
        private FrePrtPSetDB.FrePrtPSetReadKey GetFrePrtPSetKey(SlipPrtSetWork slipPrtSetWork)
        {
            FrePrtPSetDB.FrePrtPSetReadKey key = new FrePrtPSetDB.FrePrtPSetReadKey();
            key.OutputFormFileName = slipPrtSetWork.OutputFormFileName;

            if (slipPrtSetWork.SlipPrtSetPaperId.StartsWith(slipPrtSetWork.OutputFormFileName))
            {
                string DerivNoText = slipPrtSetWork.SlipPrtSetPaperId.Substring(slipPrtSetWork.OutputFormFileName.Length, slipPrtSetWork.SlipPrtSetPaperId.Length - slipPrtSetWork.OutputFormFileName.Length);
                try
                {
                    key.UserPrtPprIdDerivNo = Int32.Parse(DerivNoText);
                }
                catch
                {
                    key.UserPrtPprIdDerivNo = 0;
                }
            }

            return key;
        }
        # endregion

        # region [売上データ抽出]
        /// <summary>
        /// 自由帳票日次帳票グループ情報検索処理（メイン部）
        /// </summary>
        /// <param name="extPrm">自由帳票共通抽出条件クラス</param>
        /// <param name="retObj">印字位置設定ワーククラス配列</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 指定された自由帳票印字位置設定検索結果クラスワークLISTを取得します。</br>
        /// <br>Programmer	: 22018 鈴木　正臣</br>
        /// <br>Date		: 2008.06.03</br>
        /// </remarks>
        private int SearchProcOfSlip(FrePSalesSlipParaWork extPrm, out List<FrePSalesSlipWork> retObj, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            List<FrePSalesSlipWork> frePSalesSlipWorkList = new List<FrePSalesSlipWork>();
            retObj = null;

            try
            {
                //-------------------------------------------------------------------
                // 対象テーブル
                //   売上データ           SalesSlipRF 
                //   拠点情報設定マスタ   SecInfoSetRF       
                //   自社名称マスタ       CompanyNmRF
                //   画像情報マスタ       ImageInfoRF
                //   部門マスタ           SubsectionRF
                //   従業員マスタ①       EmployeeRF As EMPINP
                //   従業員マスタ②       EmployeeRF As EMPFRT
                //   従業員マスタ③       EmployeeRF As EMPSAL
                //   得意先マスタ①       CustomerRF As CSTCLM
                //   得意先マスタ②       CustomerRF As CSTCST
                //   得意先マスタ③       CustomerRF As CSTADR
                //   自社情報マスタ       CompanyInfRF
                //-------------------------------------------------------------------
                SqlCommand sqlCommand = new SqlCommand("SELECT " + this.GetSelectItemsForSlip(extPrm)
                    + Environment.NewLine
                    + " FROM SALESSLIPRF " + Environment.NewLine
                    + LeftJoin("SALESSLIPRF", "SECINFOSETRF", string.Empty, new string[] { }, new string[] { "SALESSLIPRF.RESULTSADDUPSECCDRF=SECINFOSETRF.SECTIONCODERF" })  // 企業cd,拠点cd
                    + LeftJoin("SECINFOSETRF", "COMPANYNMRF", string.Empty, new string[] { }, new string[] { "SECINFOSETRF.COMPANYNAMECD1RF=COMPANYNMRF.COMPANYNAMECDRF" })    // 企業cd,自社名称cd
                    + LeftJoin("COMPANYNMRF", "IMAGEINFORF", string.Empty, new string[] { "IMAGEINFOCODERF" }, new string[] { "IMAGEINFORF.IMAGEINFODIVRF='10'" })    // 企業cd,画像情報cd,区分=10
                    + LeftJoin("SALESSLIPRF", "SUBSECTIONRF", string.Empty, new string[] { "SUBSECTIONCODERF" }, new string[] { })   // 企業cd,部門cd
                    + LeftJoin("SALESSLIPRF", "EMPLOYEERF", "EMPINP", new string[] { }, new string[] { "SALESSLIPRF.SALESINPUTCODERF=EMPINP.EMPLOYEECODERF" })   // 企業cd,従業員cd
                    + LeftJoin("SALESSLIPRF", "EMPLOYEERF", "EMPFRT", new string[] { }, new string[] { "SALESSLIPRF.FRONTEMPLOYEECDRF=EMPFRT.EMPLOYEECODERF" })  // 企業cd,従業員cd
                    + LeftJoin("SALESSLIPRF", "EMPLOYEERF", "EMPSAL", new string[] { }, new string[] { "SALESSLIPRF.SALESEMPLOYEECDRF=EMPSAL.EMPLOYEECODERF" })  // 企業cd,従業員cd
                    + LeftJoin("SALESSLIPRF", "CUSTOMERRF", "CSTCLM", new string[] { }, new string[] { "SALESSLIPRF.CLAIMCODERF=CSTCLM.CUSTOMERCODERF" })    // 企業cd,得意先cd
                    + LeftJoin("SALESSLIPRF", "CUSTOMERRF", "CSTCST", new string[] { }, new string[] { "SALESSLIPRF.CUSTOMERCODERF=CSTCST.CUSTOMERCODERF" }) // 企業cd,得意先cd
                    + LeftJoin("SALESSLIPRF", "CUSTOMERRF", "CSTADR", new string[] { }, new string[] { "SALESSLIPRF.ADDRESSEECODERF=CSTADR.CUSTOMERCODERF" })    // 企業cd,得意先cd
                    + LeftJoin("SALESSLIPRF", "COMPANYINFRF", string.Empty, new string[] { }, new string[] { }) // 企業cd
                    // --- ADD  汪千来  2009.07.27 ---------->>>>>
                    + LeftJoin("SALESSLIPRF", "SANDESETTINGRF", string.Empty, new string[] { "CUSTOMERCODERF" }, new string[] { "SALESSLIPRF.RESULTSADDUPSECCDRF=SANDESETTINGRF.SECTIONCODERF", "SANDESETTINGRF.LOGICALDELETECODERF=0" })    // 企業cd,得意先cd
                    // --- ADD  汪千来  2009.07.27 ----------<<<<<
                    , sqlConnection);

                // WHERE文を生成
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, extPrm);
                // OrderBy句を生成
                sqlCommand.CommandText += " ORDER BY ACPTANODRSTATUSRF, SALESSLIPNUMRF " + Environment.NewLine;

                // タイムアウト時間設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    FrePSalesSlipWork frePSalesSlipWork = new FrePSalesSlipWork();

                    # region [データのコピー]
                    frePSalesSlipWork.SALESSLIPRF_ACPTANODRSTATUSRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                    frePSalesSlipWork.SALESSLIPRF_SALESSLIPNUMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                    frePSalesSlipWork.SALESSLIPRF_SECTIONCODERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    frePSalesSlipWork.SALESSLIPRF_SUBSECTIONCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
                    frePSalesSlipWork.SALESSLIPRF_DEBITNOTEDIVRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
                    frePSalesSlipWork.SALESSLIPRF_DEBITNLNKSALESSLNUMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEBITNLNKSALESSLNUMRF"));
                    frePSalesSlipWork.SALESSLIPRF_SALESSLIPCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDRF"));
                    frePSalesSlipWork.SALESSLIPRF_SALESGOODSCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESGOODSCDRF"));
                    frePSalesSlipWork.SALESSLIPRF_ACCRECDIVCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCRECDIVCDRF"));
                    frePSalesSlipWork.SALESSLIPRF_SEARCHSLIPDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEARCHSLIPDATERF"));
                    frePSalesSlipWork.SALESSLIPRF_SHIPMENTDAYRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SHIPMENTDAYRF"));
                    frePSalesSlipWork.SALESSLIPRF_SALESDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESDATERF"));
                    frePSalesSlipWork.SALESSLIPRF_ADDUPADATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                    frePSalesSlipWork.SALESSLIPRF_DELAYPAYMENTDIVRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELAYPAYMENTDIVRF"));
                    frePSalesSlipWork.SALESSLIPRF_ESTIMATEFORMNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATEFORMNORF"));
                    frePSalesSlipWork.SALESSLIPRF_ESTIMATEDIVIDERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATEDIVIDERF"));
                    frePSalesSlipWork.SALESSLIPRF_SALESINPUTCODERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTCODERF"));
                    frePSalesSlipWork.SALESSLIPRF_SALESINPUTNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTNAMERF"));
                    frePSalesSlipWork.SALESSLIPRF_FRONTEMPLOYEECDRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEECDRF"));
                    frePSalesSlipWork.SALESSLIPRF_FRONTEMPLOYEENMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEENMRF"));
                    frePSalesSlipWork.SALESSLIPRF_SALESEMPLOYEECDRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEECDRF"));
                    frePSalesSlipWork.SALESSLIPRF_SALESEMPLOYEENMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEENMRF"));
                    frePSalesSlipWork.SALESSLIPRF_TOTALAMOUNTDISPWAYCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));
                    frePSalesSlipWork.SALESSLIPRF_TTLAMNTDISPRATEAPYRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TTLAMNTDISPRATEAPYRF"));
                    frePSalesSlipWork.SALESSLIPRF_SALESTOTALTAXINCRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXINCRF"));
                    frePSalesSlipWork.SALESSLIPRF_SALESTOTALTAXEXCRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXEXCRF"));
                    frePSalesSlipWork.SALESSLIPRF_SALESSUBTOTALTAXINCRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXINCRF"));
                    frePSalesSlipWork.SALESSLIPRF_SALESSUBTOTALTAXEXCRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXEXCRF"));
                    //frePSalesSlipWork.SALESSLIPRF_SALSENETPRICERF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALSENETPRICERF" ) );
                    frePSalesSlipWork.SALESSLIPRF_SALESSUBTOTALTAXRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXRF"));
                    frePSalesSlipWork.SALESSLIPRF_ITDEDSALESOUTTAXRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESOUTTAXRF"));
                    frePSalesSlipWork.SALESSLIPRF_ITDEDSALESINTAXRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESINTAXRF"));
                    frePSalesSlipWork.SALESSLIPRF_SALSUBTTLSUBTOTAXFRERF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALSUBTTLSUBTOTAXFRERF"));
                    //frePSalesSlipWork.SALESSLIPRF_SALSEOUTTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALSEOUTTAXRF" ) );
                    frePSalesSlipWork.SALESSLIPRF_SALAMNTCONSTAXINCLURF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALAMNTCONSTAXINCLURF"));
                    frePSalesSlipWork.SALESSLIPRF_SALESDISTTLTAXEXCRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISTTLTAXEXCRF"));
                    frePSalesSlipWork.SALESSLIPRF_ITDEDSALESDISOUTTAXRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESDISOUTTAXRF"));
                    frePSalesSlipWork.SALESSLIPRF_ITDEDSALESDISINTAXRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESDISINTAXRF"));
                    //frePSalesSlipWork.SALESSLIPRF_ITDEDSALSEDISTAXFRERF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ITDEDSALSEDISTAXFRERF" ) );
                    frePSalesSlipWork.SALESSLIPRF_SALESDISOUTTAXRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISOUTTAXRF"));
                    frePSalesSlipWork.SALESSLIPRF_SALESDISTTLTAXINCLURF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISTTLTAXINCLURF"));
                    frePSalesSlipWork.SALESSLIPRF_TOTALCOSTRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALCOSTRF"));
                    frePSalesSlipWork.SALESSLIPRF_CONSTAXLAYMETHODRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
                    frePSalesSlipWork.SALESSLIPRF_CONSTAXRATERF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CONSTAXRATERF"));
                    frePSalesSlipWork.SALESSLIPRF_FRACTIONPROCCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));
                    frePSalesSlipWork.SALESSLIPRF_ACCRECCONSTAXRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACCRECCONSTAXRF"));
                    frePSalesSlipWork.SALESSLIPRF_AUTODEPOSITCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITCDRF"));
                    frePSalesSlipWork.SALESSLIPRF_AUTODEPOSITSLIPNORF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITSLIPNORF"));
                    frePSalesSlipWork.SALESSLIPRF_DEPOSITALLOWANCETTLRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALLOWANCETTLRF"));
                    frePSalesSlipWork.SALESSLIPRF_DEPOSITALWCBLNCERF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALWCBLNCERF"));
                    frePSalesSlipWork.SALESSLIPRF_CLAIMCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
                    frePSalesSlipWork.SALESSLIPRF_CLAIMSNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
                    frePSalesSlipWork.SALESSLIPRF_CUSTOMERCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    frePSalesSlipWork.SALESSLIPRF_CUSTOMERNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
                    frePSalesSlipWork.SALESSLIPRF_CUSTOMERNAME2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
                    frePSalesSlipWork.SALESSLIPRF_CUSTOMERSNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                    frePSalesSlipWork.SALESSLIPRF_HONORIFICTITLERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));
                    frePSalesSlipWork.SALESSLIPRF_ADDRESSEECODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSEECODERF"));
                    frePSalesSlipWork.SALESSLIPRF_ADDRESSEENAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAMERF"));
                    frePSalesSlipWork.SALESSLIPRF_ADDRESSEENAME2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAME2RF"));
                    frePSalesSlipWork.SALESSLIPRF_ADDRESSEEPOSTNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEPOSTNORF"));
                    frePSalesSlipWork.SALESSLIPRF_ADDRESSEEADDR1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR1RF"));
                    frePSalesSlipWork.SALESSLIPRF_ADDRESSEEADDR3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR3RF"));
                    frePSalesSlipWork.SALESSLIPRF_ADDRESSEEADDR4RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR4RF"));
                    frePSalesSlipWork.SALESSLIPRF_ADDRESSEETELNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEETELNORF"));
                    frePSalesSlipWork.SALESSLIPRF_ADDRESSEEFAXNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEFAXNORF"));
                    frePSalesSlipWork.SALESSLIPRF_PARTYSALESLIPNUMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
                    frePSalesSlipWork.SALESSLIPRF_SLIPNOTERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTERF"));
                    frePSalesSlipWork.SALESSLIPRF_SLIPNOTE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE2RF"));
                    frePSalesSlipWork.SALESSLIPRF_RETGOODSREASONDIVRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSREASONDIVRF"));
                    frePSalesSlipWork.SALESSLIPRF_RETGOODSREASONRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RETGOODSREASONRF"));
                    frePSalesSlipWork.SALESSLIPRF_REGIPROCDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("REGIPROCDATERF"));
                    frePSalesSlipWork.SALESSLIPRF_CASHREGISTERNORF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CASHREGISTERNORF"));
                    frePSalesSlipWork.SALESSLIPRF_POSRECEIPTNORF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("POSRECEIPTNORF"));
                    frePSalesSlipWork.SALESSLIPRF_DETAILROWCOUNTRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILROWCOUNTRF"));
                    frePSalesSlipWork.SALESSLIPRF_EDISENDDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDISENDDATERF"));
                    frePSalesSlipWork.SALESSLIPRF_EDITAKEINDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
                    frePSalesSlipWork.SALESSLIPRF_UOEREMARK1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
                    frePSalesSlipWork.SALESSLIPRF_UOEREMARK2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
                    frePSalesSlipWork.SALESSLIPRF_SLIPPRINTFINISHCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTFINISHCDRF"));
                    frePSalesSlipWork.SALESSLIPRF_SALESSLIPPRINTDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPPRINTDATERF"));
                    frePSalesSlipWork.SALESSLIPRF_BUSINESSTYPECODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
                    frePSalesSlipWork.SALESSLIPRF_BUSINESSTYPENAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPENAMERF"));
                    frePSalesSlipWork.SALESSLIPRF_ORDERNUMBERRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERNUMBERRF"));
                    frePSalesSlipWork.SALESSLIPRF_DELIVEREDGOODSDIVRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVRF"));
                    frePSalesSlipWork.SALESSLIPRF_DELIVEREDGOODSDIVNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVNMRF"));
                    frePSalesSlipWork.SALESSLIPRF_SALESAREACODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                    frePSalesSlipWork.SALESSLIPRF_SALESAREANAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));
                    //frePSalesSlipWork.SALESSLIPRF_COMPLETECDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "COMPLETECDRF" ) );
                    frePSalesSlipWork.SALESSLIPRF_STOCKGOODSTTLTAXEXCRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKGOODSTTLTAXEXCRF"));
                    frePSalesSlipWork.SALESSLIPRF_PUREGOODSTTLTAXEXCRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PUREGOODSTTLTAXEXCRF"));
                    frePSalesSlipWork.SALESSLIPRF_LISTPRICEPRINTDIVRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LISTPRICEPRINTDIVRF"));
                    frePSalesSlipWork.SALESSLIPRF_ERANAMEDISPCD1RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ERANAMEDISPCD1RF"));
                    frePSalesSlipWork.SALESSLIPRF_ESTIMATAXDIVCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATAXDIVCDRF"));
                    frePSalesSlipWork.SALESSLIPRF_ESTIMATEFORMPRTCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATEFORMPRTCDRF"));
                    frePSalesSlipWork.SALESSLIPRF_ESTIMATESUBJECTRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATESUBJECTRF"));
                    frePSalesSlipWork.SALESSLIPRF_FOOTNOTES1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FOOTNOTES1RF"));
                    frePSalesSlipWork.SALESSLIPRF_FOOTNOTES2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FOOTNOTES2RF"));
                    frePSalesSlipWork.SALESSLIPRF_ESTIMATETITLE1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE1RF"));
                    frePSalesSlipWork.SALESSLIPRF_ESTIMATETITLE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE2RF"));
                    frePSalesSlipWork.SALESSLIPRF_ESTIMATETITLE3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE3RF"));
                    frePSalesSlipWork.SALESSLIPRF_ESTIMATETITLE4RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE4RF"));
                    frePSalesSlipWork.SALESSLIPRF_ESTIMATETITLE5RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE5RF"));
                    frePSalesSlipWork.SALESSLIPRF_ESTIMATENOTE1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE1RF"));
                    frePSalesSlipWork.SALESSLIPRF_ESTIMATENOTE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE2RF"));
                    frePSalesSlipWork.SALESSLIPRF_ESTIMATENOTE3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE3RF"));
                    frePSalesSlipWork.SALESSLIPRF_ESTIMATENOTE4RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE4RF"));
                    frePSalesSlipWork.SALESSLIPRF_ESTIMATENOTE5RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE5RF"));
                    frePSalesSlipWork.SECINFOSETRF_SECTIONGUIDENMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                    frePSalesSlipWork.SECINFOSETRF_SECTIONGUIDESNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    frePSalesSlipWork.SECINFOSETRF_COMPANYNAMECD1RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYNAMECD1RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYPRRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYPRRF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYNAME1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYNAME1RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYNAME2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYNAME2RF"));
                    frePSalesSlipWork.COMPANYNMRF_POSTNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSTNORF"));
                    frePSalesSlipWork.COMPANYNMRF_ADDRESS1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS1RF"));
                    frePSalesSlipWork.COMPANYNMRF_ADDRESS3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS3RF"));
                    frePSalesSlipWork.COMPANYNMRF_ADDRESS4RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS4RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYTELNO1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO1RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYTELNO2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO2RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYTELNO3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO3RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYTELTITLE1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE1RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYTELTITLE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE2RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYTELTITLE3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE3RF"));
                    frePSalesSlipWork.COMPANYNMRF_TRANSFERGUIDANCERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRANSFERGUIDANCERF"));
                    frePSalesSlipWork.COMPANYNMRF_ACCOUNTNOINFO1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO1RF"));
                    frePSalesSlipWork.COMPANYNMRF_ACCOUNTNOINFO2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO2RF"));
                    frePSalesSlipWork.COMPANYNMRF_ACCOUNTNOINFO3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO3RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYSETNOTE1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYSETNOTE1RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYSETNOTE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYSETNOTE2RF"));
                    frePSalesSlipWork.COMPANYNMRF_IMAGEINFODIVRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IMAGEINFODIVRF"));
                    frePSalesSlipWork.COMPANYNMRF_IMAGEINFOCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IMAGEINFOCODERF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYURLRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYURLRF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYPRSENTENCE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYPRSENTENCE2RF"));
                    frePSalesSlipWork.COMPANYNMRF_IMAGECOMMENTFORPRT1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IMAGECOMMENTFORPRT1RF"));
                    frePSalesSlipWork.COMPANYNMRF_IMAGECOMMENTFORPRT2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IMAGECOMMENTFORPRT2RF"));
                    frePSalesSlipWork.IMAGEINFORF_IMAGEINFODATARF = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("IMAGEINFODATARF"));
                    frePSalesSlipWork.SUBSECTIONRF_SUBSECTIONNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUBSECTIONNAMERF"));
                    frePSalesSlipWork.EMPINP_KANARF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPINPKANARF"));
                    frePSalesSlipWork.EMPINP_SHORTNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPINPSHORTNAMERF"));
                    frePSalesSlipWork.EMPFRT_KANARF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPFRTKANARF"));
                    frePSalesSlipWork.EMPFRT_SHORTNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPFRTSHORTNAMERF"));
                    frePSalesSlipWork.EMPSAL_KANARF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPSALKANARF"));
                    frePSalesSlipWork.EMPSAL_SHORTNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPSALSHORTNAMERF"));
                    frePSalesSlipWork.CSTCLM_CUSTOMERSUBCODERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCLMCUSTOMERSUBCODERF"));
                    frePSalesSlipWork.CSTCLM_NAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCLMNAMERF"));
                    frePSalesSlipWork.CSTCLM_NAME2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCLMNAME2RF"));
                    frePSalesSlipWork.CSTCLM_HONORIFICTITLERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCLMHONORIFICTITLERF"));
                    frePSalesSlipWork.CSTCLM_KANARF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCLMKANARF"));
                    frePSalesSlipWork.CSTCLM_CUSTOMERSNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCLMCUSTOMERSNMRF"));
                    frePSalesSlipWork.CSTCLM_OUTPUTNAMECODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTCLMOUTPUTNAMECODERF"));
                    frePSalesSlipWork.CSTCLM_CUSTANALYSCODE1RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTCLMCUSTANALYSCODE1RF"));
                    frePSalesSlipWork.CSTCLM_CUSTANALYSCODE2RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTCLMCUSTANALYSCODE2RF"));
                    frePSalesSlipWork.CSTCLM_CUSTANALYSCODE3RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTCLMCUSTANALYSCODE3RF"));
                    frePSalesSlipWork.CSTCLM_CUSTANALYSCODE4RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTCLMCUSTANALYSCODE4RF"));
                    frePSalesSlipWork.CSTCLM_CUSTANALYSCODE5RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTCLMCUSTANALYSCODE5RF"));
                    frePSalesSlipWork.CSTCLM_CUSTANALYSCODE6RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTCLMCUSTANALYSCODE6RF"));
                    frePSalesSlipWork.CSTCLM_NOTE1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCLMNOTE1RF"));
                    frePSalesSlipWork.CSTCLM_NOTE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCLMNOTE2RF"));
                    frePSalesSlipWork.CSTCLM_NOTE3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCLMNOTE3RF"));
                    frePSalesSlipWork.CSTCLM_NOTE4RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCLMNOTE4RF"));
                    frePSalesSlipWork.CSTCLM_NOTE5RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCLMNOTE5RF"));
                    frePSalesSlipWork.CSTCLM_NOTE6RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCLMNOTE6RF"));
                    frePSalesSlipWork.CSTCLM_NOTE7RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCLMNOTE7RF"));
                    frePSalesSlipWork.CSTCLM_NOTE8RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCLMNOTE8RF"));
                    frePSalesSlipWork.CSTCLM_NOTE9RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCLMNOTE9RF"));
                    frePSalesSlipWork.CSTCLM_NOTE10RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCLMNOTE10RF"));
                    frePSalesSlipWork.CSTCST_CUSTOMERSUBCODERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTCUSTOMERSUBCODERF"));
                    frePSalesSlipWork.CSTCST_NAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTNAMERF"));
                    frePSalesSlipWork.CSTCST_NAME2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTNAME2RF"));
                    frePSalesSlipWork.CSTCST_HONORIFICTITLERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTHONORIFICTITLERF"));
                    frePSalesSlipWork.CSTCST_KANARF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTKANARF"));
                    frePSalesSlipWork.CSTCST_CUSTOMERSNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTCUSTOMERSNMRF"));
                    frePSalesSlipWork.CSTCST_OUTPUTNAMECODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTCSTOUTPUTNAMECODERF"));
                    frePSalesSlipWork.CSTCST_CUSTANALYSCODE1RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTCSTCUSTANALYSCODE1RF"));
                    frePSalesSlipWork.CSTCST_CUSTANALYSCODE2RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTCSTCUSTANALYSCODE2RF"));
                    frePSalesSlipWork.CSTCST_CUSTANALYSCODE3RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTCSTCUSTANALYSCODE3RF"));
                    frePSalesSlipWork.CSTCST_CUSTANALYSCODE4RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTCSTCUSTANALYSCODE4RF"));
                    frePSalesSlipWork.CSTCST_CUSTANALYSCODE5RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTCSTCUSTANALYSCODE5RF"));
                    frePSalesSlipWork.CSTCST_CUSTANALYSCODE6RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTCSTCUSTANALYSCODE6RF"));
                    frePSalesSlipWork.CSTCST_NOTE1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTNOTE1RF"));
                    frePSalesSlipWork.CSTCST_NOTE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTNOTE2RF"));
                    frePSalesSlipWork.CSTCST_NOTE3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTNOTE3RF"));
                    frePSalesSlipWork.CSTCST_NOTE4RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTNOTE4RF"));
                    frePSalesSlipWork.CSTCST_NOTE5RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTNOTE5RF"));
                    frePSalesSlipWork.CSTCST_NOTE6RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTNOTE6RF"));
                    frePSalesSlipWork.CSTCST_NOTE7RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTNOTE7RF"));
                    frePSalesSlipWork.CSTCST_NOTE8RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTNOTE8RF"));
                    frePSalesSlipWork.CSTCST_NOTE9RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTNOTE9RF"));
                    frePSalesSlipWork.CSTCST_NOTE10RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTNOTE10RF"));
                    // ---- ADD caohh 2011/08/17 ------>>>>>
                    frePSalesSlipWork.CSTCST_POSTNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTPOSTNORF"));
                    frePSalesSlipWork.CSTCST_ADDRESS1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTADDRESS1RF"));
                    frePSalesSlipWork.CSTCST_ADDRESS3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTADDRESS3RF"));
                    frePSalesSlipWork.CSTCST_ADDRESS4RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTADDRESS4RF"));
                    frePSalesSlipWork.CSTCST_HOMETELNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTHOMETELNORF"));
                    frePSalesSlipWork.CSTCST_OFFICETELNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTOFFICETELNORF"));
                    frePSalesSlipWork.CSTCST_PORTABLETELNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTPORTABLETELNORF"));
                    frePSalesSlipWork.CSTCST_OTHERSTELNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTOTHERSTELNORF"));
                    frePSalesSlipWork.CSTCST_HOMEFAXNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTHOMEFAXNORF"));
                    frePSalesSlipWork.CSTCST_OFFICEFAXNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTOFFICEFAXNORF"));
                    // ---- ADD caohh 2011/08/17 ------<<<<<
                    frePSalesSlipWork.CSTADR_CUSTOMERSUBCODERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTADRCUSTOMERSUBCODERF"));
                    frePSalesSlipWork.CSTADR_NAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTADRNAMERF"));
                    frePSalesSlipWork.CSTADR_NAME2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTADRNAME2RF"));
                    frePSalesSlipWork.CSTADR_HONORIFICTITLERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTADRHONORIFICTITLERF"));
                    frePSalesSlipWork.CSTADR_KANARF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTADRKANARF"));
                    frePSalesSlipWork.CSTADR_CUSTOMERSNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTADRCUSTOMERSNMRF"));
                    frePSalesSlipWork.CSTADR_OUTPUTNAMECODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTADROUTPUTNAMECODERF"));
                    frePSalesSlipWork.CSTADR_CUSTANALYSCODE1RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTADRCUSTANALYSCODE1RF"));
                    frePSalesSlipWork.CSTADR_CUSTANALYSCODE2RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTADRCUSTANALYSCODE2RF"));
                    frePSalesSlipWork.CSTADR_CUSTANALYSCODE3RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTADRCUSTANALYSCODE3RF"));
                    frePSalesSlipWork.CSTADR_CUSTANALYSCODE4RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTADRCUSTANALYSCODE4RF"));
                    frePSalesSlipWork.CSTADR_CUSTANALYSCODE5RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTADRCUSTANALYSCODE5RF"));
                    frePSalesSlipWork.CSTADR_CUSTANALYSCODE6RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTADRCUSTANALYSCODE6RF"));
                    frePSalesSlipWork.CSTADR_NOTE1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTADRNOTE1RF"));
                    frePSalesSlipWork.CSTADR_NOTE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTADRNOTE2RF"));
                    frePSalesSlipWork.CSTADR_NOTE3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTADRNOTE3RF"));
                    frePSalesSlipWork.CSTADR_NOTE4RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTADRNOTE4RF"));
                    frePSalesSlipWork.CSTADR_NOTE5RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTADRNOTE5RF"));
                    frePSalesSlipWork.CSTADR_NOTE6RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTADRNOTE6RF"));
                    frePSalesSlipWork.CSTADR_NOTE7RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTADRNOTE7RF"));
                    frePSalesSlipWork.CSTADR_NOTE8RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTADRNOTE8RF"));
                    frePSalesSlipWork.CSTADR_NOTE9RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTADRNOTE9RF"));
                    frePSalesSlipWork.CSTADR_NOTE10RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTADRNOTE10RF"));
                    frePSalesSlipWork.COMPANYINFRF_COMPANYNAME1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFCOMPANYNAME1RF"));
                    frePSalesSlipWork.COMPANYINFRF_COMPANYNAME2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFCOMPANYNAME2RF"));
                    frePSalesSlipWork.COMPANYINFRF_POSTNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFPOSTNORF"));
                    frePSalesSlipWork.COMPANYINFRF_ADDRESS1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFADDRESS1RF"));
                    frePSalesSlipWork.COMPANYINFRF_ADDRESS3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFADDRESS3RF"));
                    frePSalesSlipWork.COMPANYINFRF_ADDRESS4RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFADDRESS4RF"));
                    frePSalesSlipWork.COMPANYINFRF_COMPANYTELNO1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFCOMPANYTELNO1RF"));
                    frePSalesSlipWork.COMPANYINFRF_COMPANYTELNO2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFCOMPANYTELNO2RF"));
                    frePSalesSlipWork.COMPANYINFRF_COMPANYTELNO3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFCOMPANYTELNO3RF"));
                    frePSalesSlipWork.COMPANYINFRF_COMPANYTELTITLE1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFCOMPANYTELTITLE1RF"));
                    frePSalesSlipWork.COMPANYINFRF_COMPANYTELTITLE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFCOMPANYTELTITLE2RF"));
                    frePSalesSlipWork.COMPANYINFRF_COMPANYTELTITLE3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFCOMPANYTELTITLE3RF"));
                    frePSalesSlipWork.SALESSLIPRF_SLIPNOTE3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE3RF"));
                    frePSalesSlipWork.SALESSLIPRF_RESULTSADDUPSECCDRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
                    frePSalesSlipWork.SALESSLIPRF_UPDATEDATETIMERF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時
                    // --- ADD  汪千来  2009.07.27 ---------->>>>>
                    frePSalesSlipWork.SANDESETTINGRF_CUSTOMERCODE = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SANCUSTOMERCODERF"));//納品先店舗コード	
                    frePSalesSlipWork.SANDESETTINGRF_ADDRESSEESHOPCD = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEESHOPCDRF"));//納品先店舗コード	
                    frePSalesSlipWork.SANDESETTINGRF_SANDEMNGCODE = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SANDEMNGCODERF"));//住電管理コード	
                    frePSalesSlipWork.SANDESETTINGRF_EXPENSEDIVCD = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EXPENSEDIVCDRF"));//経費区分	
                    frePSalesSlipWork.SANDESETTINGRF_DIRECTSENDINGCD = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DIRECTSENDINGCDRF"));//直送区分	
                    frePSalesSlipWork.SANDESETTINGRF_ACPTANORDERDIV = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANORDERDIVRF"));//受注区分	
                    frePSalesSlipWork.SANDESETTINGRF_DELIVERERCD = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIVERERCDRF"));//納品者コード	
                    frePSalesSlipWork.SANDESETTINGRF_DELIVERERNM = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIVERERNMRF"));//納品者名	
                    frePSalesSlipWork.SANDESETTINGRF_DELIVERERADDRESS = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIVERERADDRESSRF"));//納品者住所	
                    frePSalesSlipWork.SANDESETTINGRF_DELIVERERPHONENUM = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIVERERPHONENUMRF"));//納品者ＴＥＬ	
                    frePSalesSlipWork.SANDESETTINGRF_TRADCOMPNAME = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRADCOMPNAMERF"));//部品商名	
                    frePSalesSlipWork.SANDESETTINGRF_TRADCOMPSECTNAME = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRADCOMPSECTNAMERF"));//部品商拠点名	
                    frePSalesSlipWork.SANDESETTINGRF_PURETRADCOMPCD = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PURETRADCOMPCDRF"));//部品商コード（純正）	
                    frePSalesSlipWork.SANDESETTINGRF_PURETRADCOMPRATE = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PURETRADCOMPRATERF"));//部品商仕切率（純正）	
                    frePSalesSlipWork.SANDESETTINGRF_PRITRADCOMPCD = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRITRADCOMPCDRF"));//部品商コード（優良）	
                    frePSalesSlipWork.SANDESETTINGRF_PRITRADCOMPRATE = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRITRADCOMPRATERF"));//部品商仕切率（優良）	
                    frePSalesSlipWork.SANDESETTINGRF_ABGOODSCODE = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ABGOODSCODERF"));//AB商品コード	
                    frePSalesSlipWork.SANDESETTINGRF_COMMENTRESERVEDDIV = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMMENTRESERVEDDIVRF"));//コメント指定区分	
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD1RF"));//商品メーカーコード１	
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD2RF"));//商品メーカーコード２	
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD3RF"));//商品メーカーコード３	
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD4RF"));//商品メーカーコード４	
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD5RF"));//商品メーカーコード５	
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD6RF"));//商品メーカーコード６	
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD7 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD7RF"));//商品メーカーコード７	
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD8 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD8RF"));//商品メーカーコード８	
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD9 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD9RF"));//商品メーカーコード９	
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD10 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD10RF"));//商品メーカーコード１０	
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD11 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD11RF"));//商品メーカーコード１１	
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD12 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD12RF"));//商品メーカーコード１２	
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD13 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD13RF"));//商品メーカーコード１３	
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD14 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD14RF"));//商品メーカーコード１４	
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD15 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD15RF"));//商品メーカーコード１５	
                    frePSalesSlipWork.SANDESETTINGRF_PARTSOEMDIV = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSOEMDIVRF"));//部品ＯＥＭ区分	
                    // --- ADD  汪千来  2009.07.27 ----------<<<<<
                    // --- ADD  大矢睦美  2010/03/01 ---------->>>>>
                    frePSalesSlipWork.CSTCST_SALESUNPRCFRCPROCCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESUNPRCFRCPROCCDRF"));  // 売上単価端数処理コード
                    frePSalesSlipWork.CSTCST_SALESMONEYFRCPROCCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESMONEYFRCPROCCDRF"));  // 売上金額端数処理コード
                    frePSalesSlipWork.CSTCST_SALESCNSTAXFRCPROCCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCNSTAXFRCPROCCDRF"));  // 売上消費税端数処理コード
                    // --- ADD  大矢睦美  2010/03/01 ----------<<<<<
                    // --- ADD m.suzuki 2010/03/24 ---------->>>>>
                    frePSalesSlipWork.CSTCST_QRCODEPRTCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "QRCODEPRTCDRF" ) );  // QRコード印刷
                    // --- ADD m.suzuki 2010/03/24 ----------<<<<<
                    // 2010/07/06 Add >>>
                    frePSalesSlipWork.SALESSLIPRF_FILEHEADERGUID = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));   // 売上データヘッダガイド
                    // 2010/07/06 Add <<<
                    # endregion

                    frePSalesSlipWorkList.Add(frePSalesSlipWork);
                }

                if (frePSalesSlipWorkList.Count > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                retObj = frePSalesSlipWorkList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SearchProc\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }
            return status;
        }
        # endregion

        # region [売上明細データ抽出]
        /// <summary>
        /// 売上明細データ抽出
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="retObj"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        /// <br>Update Note      :   2020/03/18 寺田義啓</br>
        /// <br>管理番号         :   11670121-00 S＆E改良対応</br>
        private int SearchProcOfDetail(FrePSalesSlipParaWork extPrm, out Dictionary<FrePSalesSlipParaWork.FrePSalesSlipParaKey, List<FrePSalesDetailWork>> retObj, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;

            Dictionary<FrePSalesSlipParaWork.FrePSalesSlipParaKey, List<FrePSalesDetailWork>> detailListDic = new Dictionary<FrePSalesSlipParaWork.FrePSalesSlipParaKey, List<FrePSalesDetailWork>>();
            retObj = null;

            try
            {
                //-------------------------------------------------------------------
                // 対象テーブル
                //   売上明細データ       SalesDetailRF 
                //   受注マスタ(車両)     AcceptOdrCarRF
                //   メーカーマスタ①     MakerURF As MAKGDS
                //   メーカーマスタ②     MakerURF As MAKCMP
                //   メーカーマスタ③     MakerURF As MAKPRT
                //   商品マスタ           GoodsURF
                //   在庫マスタ           StockRF
                //   倉庫マスタ           WarehouseRF
                //   ﾕｰｻﾞｰｶﾞｲﾄﾞﾏｽﾀ①     UserGdBdURF As USRCSG
                //   仕入先マスタ         SupplierRF
                //   ＢＬｺｰﾄﾞﾏｽﾀ         BLGoodsCdURF
                //-------------------------------------------------------------------
                SqlCommand sqlCommand = new SqlCommand("SELECT " + this.GetSelectItemsForDetail(extPrm)
                    + Environment.NewLine
                    + " FROM SALESDETAILRF " + Environment.NewLine
                    + LeftJoin("SALESDETAILRF", "SALESSLIPRF", string.Empty, new string[] { "ACPTANODRSTATUSRF", "SALESSLIPNUMRF" }, new string[] { })    // 企業cd, 受注ｽﾃｰﾀｽ, 伝票番号
                    + LeftJoin("SALESDETAILRF", "ACCEPTODRCARRF", string.Empty, new string[] { "ACCEPTANORDERNORF" }, new string[] { "ACCEPTODRCARRF.DATAINPUTSYSTEMRF='10'", GetAcceptOdrCarJoinCndtn() })    // 企業cd, 受注番号,受注ｽﾃｰﾀｽが対応する(GetAcceptOdrCarJoinCndtn),入力ｼｽﾃﾑ=10:PM
                    + LeftJoin("SALESDETAILRF", "MAKERURF", "MAKGDS", new string[] { "GOODSMAKERCDRF" }, new string[] { })    // 企業cd,ﾒｰｶｰcd
                    + LeftJoin("SALESDETAILRF", "MAKERURF", "MAKCMP", new string[] { }, new string[] { "SALESDETAILRF.CMPLTGOODSMAKERCDRF=MAKCMP.GOODSMAKERCDRF" })    // 企業cd,ﾒｰｶｰcd
                    + LeftJoin("SALESDETAILRF", "MAKERURF", "MAKPRT", new string[] { }, new string[] { "SALESDETAILRF.PRTMAKERCODERF=MAKPRT.GOODSMAKERCDRF" })    // 企業cd,ﾒｰｶｰcd
                    + LeftJoin("SALESDETAILRF", "GOODSURF", string.Empty, new string[] { "GOODSNORF", "GOODSMAKERCDRF" }, new string[] { })    // 企業cd,商品番号,ﾒｰｶｰcd
                    + LeftJoin("SALESDETAILRF", "STOCKRF", string.Empty, new string[] { "GOODSNORF", "GOODSMAKERCDRF", "WAREHOUSECODERF" }, new string[] { })    // 企業cd,商品番号,ﾒｰｶｰcd,倉庫cd
                    + LeftJoin("SALESDETAILRF", "WAREHOUSERF", string.Empty, new string[] { "WAREHOUSECODERF" }, new string[] { })    // 企業cd,倉庫cd
                    + LeftJoin("SALESDETAILRF", "USERGDBDURF", "USRCSG", new string[] { }, new string[] { "USRCSG.USERGUIDEDIVCDRF='43'", "SALESDETAILRF.CUSTRATEGRPCODERF=USRCSG.GUIDECODERF" })    // 企業cd,ｶﾞｲﾄﾞ区分=43,ｶﾞｲﾄﾞcd
                    + LeftJoin("SALESDETAILRF", "SUPPLIERRF", string.Empty, new string[] { "SUPPLIERCDRF" }, new string[] { })    // 企業cd,仕入先cd
                    + LeftJoin("SALESDETAILRF", "BLGOODSCDURF", string.Empty, new string[] { "BLGOODSCODERF" }, new string[] { })    // 企業cd,BLcd

                    // --- UPD 寺田義啓 2020.03.18 ---------->>>>>
                    //// --- ADD 汪千来  2009.07.27 ---------->>>>>
                    //+ LeftJoin("SALESDETAILRF", "SANDEGOODSCDCHGRF", string.Empty, new string[] { "BLGOODSCODERF" }, new string[] { "SANDEGOODSCDCHGRF.LOGICALDELETECODERF=0" })    // 企業cd,BLcd
                    //// --- ADD 汪千来  2009.07.27 ----------<<<<<                    
                    + "LEFT JOIN SANDEGOODSCDCHGRF ON SALESDETAILRF.PRTBLGOODSCODERF = SANDEGOODSCDCHGRF.BLGOODSCODERF AND SALESDETAILRF.ENTERPRISECODERF = SANDEGOODSCDCHGRF.ENTERPRISECODERF AND SANDEGOODSCDCHGRF.LOGICALDELETECODERF=0" + Environment.NewLine // 企業cd,BLcd
                    + "LEFT JOIN SANDEMKRGDSCDCHGRF ON SALESDETAILRF.GOODSMAKERCDRF = SANDEMKRGDSCDCHGRF.GOODSMAKERCDRF AND SALESDETAILRF.PRTGOODSNORF = SANDEMKRGDSCDCHGRF.GOODSNORF AND SALESDETAILRF.ENTERPRISECODERF = SANDEMKRGDSCDCHGRF.ENTERPRISECODERF AND SANDEMKRGDSCDCHGRF.LOGICALDELETECODERF=0" + Environment.NewLine // 企業cd,商品ﾒｰｶｰｺｰﾄﾞ,商品番号
                    // --- UPD 寺田義啓 2020.03.18 ----------<<<<<                    
                    , sqlConnection);

                // WHERE文を生成
                sqlCommand.CommandText += MakeWhereStringForDetail(ref sqlCommand, extPrm);
                // OrderBy句を生成
                sqlCommand.CommandText += " ORDER BY ACPTANODRSTATUSRF, SALESSLIPNUMRF, SALESROWNORF " + Environment.NewLine;

                // タイムアウト時間設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    FrePSalesDetailWork frePSalesDetailWork = new FrePSalesDetailWork();

                    # region [データのコピー]
                    frePSalesDetailWork.SALESDETAILRF_ACPTANODRSTATUSRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                    frePSalesDetailWork.SALESDETAILRF_SALESSLIPNUMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                    frePSalesDetailWork.SALESDETAILRF_ACCEPTANORDERNORF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
                    frePSalesDetailWork.SALESDETAILRF_SALESROWNORF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));
                    frePSalesDetailWork.SALESDETAILRF_SALESDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESDATERF"));
                    frePSalesDetailWork.SALESDETAILRF_COMMONSEQNORF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));
                    frePSalesDetailWork.SALESDETAILRF_SALESSLIPDTLNUMRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMRF"));
                    frePSalesDetailWork.SALESDETAILRF_ACPTANODRSTATUSSRCRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSSRCRF"));
                    frePSalesDetailWork.SALESDETAILRF_SALESSLIPDTLNUMSRCRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMSRCRF"));
                    frePSalesDetailWork.SALESDETAILRF_SUPPLIERFORMALSYNCRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALSYNCRF"));
                    frePSalesDetailWork.SALESDETAILRF_STOCKSLIPDTLNUMSYNCRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMSYNCRF"));
                    frePSalesDetailWork.SALESDETAILRF_SALESSLIPCDDTLRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDDTLRF"));
                    //frePSalesDetailWork.SALESDETAILRF_STOCKMNGEXISTCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "STOCKMNGEXISTCDRF" ) );
                    frePSalesDetailWork.SALESDETAILRF_DELIGDSCMPLTDUEDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIGDSCMPLTDUEDATERF"));
                    frePSalesDetailWork.SALESDETAILRF_GOODSKINDCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
                    frePSalesDetailWork.SALESDETAILRF_GOODSMAKERCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    frePSalesDetailWork.SALESDETAILRF_MAKERNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    frePSalesDetailWork.SALESDETAILRF_GOODSNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    frePSalesDetailWork.SALESDETAILRF_GOODSNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    //frePSalesDetailWork.SALESDETAILRF_GOODSSHORTNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSSHORTNAMERF" ) );
                    //frePSalesDetailWork.SALESDETAILRF_LARGEGOODSGANRECODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "LARGEGOODSGANRECODERF" ) );
                    //frePSalesDetailWork.SALESDETAILRF_LARGEGOODSGANRENAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "LARGEGOODSGANRENAMERF" ) );
                    //frePSalesDetailWork.SALESDETAILRF_MEDIUMGOODSGANRECODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MEDIUMGOODSGANRECODERF" ) );
                    //frePSalesDetailWork.SALESDETAILRF_MEDIUMGOODSGANRENAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MEDIUMGOODSGANRENAMERF" ) );
                    //frePSalesDetailWork.SALESDETAILRF_DETAILGOODSGANRECODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DETAILGOODSGANRECODERF" ) );
                    //frePSalesDetailWork.SALESDETAILRF_DETAILGOODSGANRENAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DETAILGOODSGANRENAMERF" ) );
                    frePSalesDetailWork.SALESDETAILRF_BLGOODSCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    frePSalesDetailWork.SALESDETAILRF_BLGOODSFULLNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
                    frePSalesDetailWork.SALESDETAILRF_ENTERPRISEGANRECODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
                    frePSalesDetailWork.SALESDETAILRF_ENTERPRISEGANRENAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISEGANRENAMERF"));
                    frePSalesDetailWork.SALESDETAILRF_WAREHOUSECODERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    frePSalesDetailWork.SALESDETAILRF_WAREHOUSENAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    frePSalesDetailWork.SALESDETAILRF_WAREHOUSESHELFNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    frePSalesDetailWork.SALESDETAILRF_SALESORDERDIVCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERDIVCDRF"));
                    frePSalesDetailWork.SALESDETAILRF_OPENPRICEDIVRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                    //frePSalesDetailWork.SALESDETAILRF_UNITCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "UNITCODERF" ) );
                    //frePSalesDetailWork.SALESDETAILRF_UNITNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "UNITNAMERF" ) );
                    frePSalesDetailWork.SALESDETAILRF_GOODSRATERANKRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
                    frePSalesDetailWork.SALESDETAILRF_CUSTRATEGRPCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
                    //frePSalesDetailWork.SALESDETAILRF_SUPPRATEGRPCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SUPPRATEGRPCODERF" ) );
                    frePSalesDetailWork.SALESDETAILRF_LISTPRICERATERF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERATERF"));
                    frePSalesDetailWork.SALESDETAILRF_LISTPRICETAXINCFLRF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXINCFLRF"));
                    frePSalesDetailWork.SALESDETAILRF_LISTPRICETAXEXCFLRF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                    frePSalesDetailWork.SALESDETAILRF_LISTPRICECHNGCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LISTPRICECHNGCDRF"));
                    frePSalesDetailWork.SALESDETAILRF_SALESRATERF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESRATERF"));
                    frePSalesDetailWork.SALESDETAILRF_SALESUNPRCTAXINCFLRF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXINCFLRF"));
                    frePSalesDetailWork.SALESDETAILRF_SALESUNPRCTAXEXCFLRF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
                    frePSalesDetailWork.SALESDETAILRF_COSTRATERF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("COSTRATERF"));
                    frePSalesDetailWork.SALESDETAILRF_SALESUNITCOSTRF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
                    frePSalesDetailWork.SALESDETAILRF_SHIPMENTCNTRF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                    frePSalesDetailWork.SALESDETAILRF_ACCEPTANORDERCNTRF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACCEPTANORDERCNTRF"));
                    frePSalesDetailWork.SALESDETAILRF_ACPTANODRADJUSTCNTRF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPTANODRADJUSTCNTRF"));
                    frePSalesDetailWork.SALESDETAILRF_ACPTANODRREMAINCNTRF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPTANODRREMAINCNTRF"));
                    frePSalesDetailWork.SALESDETAILRF_REMAINCNTUPDDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("REMAINCNTUPDDATERF"));
                    frePSalesDetailWork.SALESDETAILRF_SALESMONEYTAXINCRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXINCRF"));
                    frePSalesDetailWork.SALESDETAILRF_SALESMONEYTAXEXCRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
                    frePSalesDetailWork.SALESDETAILRF_COSTRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COSTRF"));
                    frePSalesDetailWork.SALESDETAILRF_GRSPROFITCHKDIVRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GRSPROFITCHKDIVRF"));
                    frePSalesDetailWork.SALESDETAILRF_SALESGOODSCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESGOODSCDRF"));
                    //frePSalesDetailWork.SALESDETAILRF_SALSEPRICECONSTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALSEPRICECONSTAXRF" ) );
                    frePSalesDetailWork.SALESDETAILRF_TAXATIONDIVCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
                    frePSalesDetailWork.SALESDETAILRF_PARTYSLIPNUMDTLRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSLIPNUMDTLRF"));
                    frePSalesDetailWork.SALESDETAILRF_DTLNOTERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DTLNOTERF"));
                    frePSalesDetailWork.SALESDETAILRF_SUPPLIERCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    frePSalesDetailWork.SALESDETAILRF_SUPPLIERSNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    frePSalesDetailWork.SALESDETAILRF_ORDERNUMBERRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERNUMBERRF"));
                    frePSalesDetailWork.SALESDETAILRF_SLIPMEMO1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO1RF"));
                    frePSalesDetailWork.SALESDETAILRF_SLIPMEMO2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO2RF"));
                    frePSalesDetailWork.SALESDETAILRF_SLIPMEMO3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO3RF"));
                    frePSalesDetailWork.SALESDETAILRF_INSIDEMEMO1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO1RF"));
                    frePSalesDetailWork.SALESDETAILRF_INSIDEMEMO2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO2RF"));
                    frePSalesDetailWork.SALESDETAILRF_INSIDEMEMO3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO3RF"));
                    frePSalesDetailWork.SALESDETAILRF_BFLISTPRICERF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFLISTPRICERF"));
                    frePSalesDetailWork.SALESDETAILRF_BFSALESUNITPRICERF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSALESUNITPRICERF"));
                    frePSalesDetailWork.SALESDETAILRF_BFUNITCOSTRF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFUNITCOSTRF"));
                    //frePSalesDetailWork.SALESDETAILRF_PRTGOODSNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PRTGOODSNORF" ) );
                    //frePSalesDetailWork.SALESDETAILRF_PRTGOODSNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PRTGOODSNAMERF" ) );
                    //frePSalesDetailWork.SALESDETAILRF_PRTGOODSMAKERCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "PRTGOODSMAKERCDRF" ) );
                    //frePSalesDetailWork.SALESDETAILRF_PRTGOODSMAKERNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PRTGOODSMAKERNMRF" ) );
                    //frePSalesDetailWork.SALESDETAILRF_CONTRACTDIVCDDTLRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CONTRACTDIVCDDTLRF" ) );
                    frePSalesDetailWork.SALESDETAILRF_CMPLTSALESROWNORF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CMPLTSALESROWNORF"));
                    frePSalesDetailWork.SALESDETAILRF_CMPLTGOODSMAKERCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CMPLTGOODSMAKERCDRF"));
                    frePSalesDetailWork.SALESDETAILRF_CMPLTMAKERNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTMAKERNAMERF"));
                    frePSalesDetailWork.SALESDETAILRF_CMPLTGOODSNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTGOODSNAMERF"));
                    frePSalesDetailWork.SALESDETAILRF_CMPLTSHIPMENTCNTRF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CMPLTSHIPMENTCNTRF"));
                    //frePSalesDetailWork.SALESDETAILRF_CMPLTUNITCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CMPLTUNITCODERF" ) );
                    //frePSalesDetailWork.SALESDETAILRF_CMPLTUNITNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMPLTUNITNAMERF" ) );
                    frePSalesDetailWork.SALESDETAILRF_CMPLTSALESUNPRCFLRF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CMPLTSALESUNPRCFLRF"));
                    frePSalesDetailWork.SALESDETAILRF_CMPLTSALESMONEYRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CMPLTSALESMONEYRF"));
                    frePSalesDetailWork.SALESDETAILRF_CMPLTSALESUNITCOSTRF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CMPLTSALESUNITCOSTRF"));
                    frePSalesDetailWork.SALESDETAILRF_CMPLTCOSTRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CMPLTCOSTRF"));
                    frePSalesDetailWork.SALESDETAILRF_CMPLTPARTYSALSLNUMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTPARTYSALSLNUMRF"));
                    frePSalesDetailWork.SALESDETAILRF_CMPLTNOTERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTNOTERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_CARMNGNORF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARMNGNORF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_CARMNGCODERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARMNGCODERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_NUMBERPLATE1CODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE1CODERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_NUMBERPLATE1NAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE1NAMERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_NUMBERPLATE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE2RF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_NUMBERPLATE3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE3RF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_NUMBERPLATE4RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE4RF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_FIRSTENTRYDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FIRSTENTRYDATERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_MAKERCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_MAKERFULLNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERFULLNAMERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_MODELCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_MODELSUBCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_MODELFULLNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELFULLNAMERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_EXHAUSTGASSIGNRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EXHAUSTGASSIGNRF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_SERIESMODELRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SERIESMODELRF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_CATEGORYSIGNMODELRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATEGORYSIGNMODELRF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_FULLMODELRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_MODELDESIGNATIONNORF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_CATEGORYNORF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_FRAMEMODELRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMEMODELRF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_FRAMENORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMENORF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_SEARCHFRAMENORF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEARCHFRAMENORF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_ENGINEMODELNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEMODELNMRF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_RELEVANCEMODELRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RELEVANCEMODELRF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_SUBCARNMCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBCARNMCDRF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_MODELGRADESNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELGRADESNAMERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_COLORCODERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORCODERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_COLORNAME1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORNAME1RF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_TRIMCODERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMCODERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_TRIMNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMNAMERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_MILEAGERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MILEAGERF"));
                    frePSalesDetailWork.MAKGDS_MAKERSHORTNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKGDSMAKERSHORTNAMERF"));
                    frePSalesDetailWork.MAKGDS_MAKERKANANAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKGDSMAKERKANANAMERF"));
                    frePSalesDetailWork.MAKGDS_GOODSMAKERCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKGDSGOODSMAKERCDRF"));
                    frePSalesDetailWork.MAKCMP_MAKERSHORTNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKCMPMAKERSHORTNAMERF"));
                    frePSalesDetailWork.MAKCMP_MAKERKANANAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKCMPMAKERKANANAMERF"));
                    frePSalesDetailWork.MAKCMP_GOODSMAKERCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKCMPGOODSMAKERCDRF"));
                    frePSalesDetailWork.GOODSURF_GOODSNAMEKANARF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSURFGOODSNAMEKANARF"));
                    frePSalesDetailWork.GOODSURF_JANRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSURFJANRF"));
                    frePSalesDetailWork.GOODSURF_GOODSRATERANKRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSURFGOODSRATERANKRF"));
                    frePSalesDetailWork.GOODSURF_GOODSNONONEHYPHENRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSURFGOODSNONONEHYPHENRF"));
                    frePSalesDetailWork.GOODSURF_GOODSNOTE1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSURFGOODSNOTE1RF"));
                    frePSalesDetailWork.GOODSURF_GOODSNOTE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSURFGOODSNOTE2RF"));
                    frePSalesDetailWork.GOODSURF_GOODSSPECIALNOTERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSURFGOODSSPECIALNOTERF"));
                    frePSalesDetailWork.STOCKRF_SHIPMENTPOSCNTRF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
                    frePSalesDetailWork.STOCKRF_DUPLICATIONSHELFNO1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO1RF"));
                    frePSalesDetailWork.STOCKRF_DUPLICATIONSHELFNO2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO2RF"));
                    frePSalesDetailWork.STOCKRF_PARTSMANAGEMENTDIVIDE1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE1RF"));
                    frePSalesDetailWork.STOCKRF_PARTSMANAGEMENTDIVIDE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE2RF"));
                    frePSalesDetailWork.STOCKRF_STOCKNOTE1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE1RF"));
                    frePSalesDetailWork.STOCKRF_STOCKNOTE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE2RF"));
                    frePSalesDetailWork.WAREHOUSERF_WAREHOUSENOTE1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENOTE1RF"));
                    frePSalesDetailWork.USRCSG_GUIDENAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("USRCSGGUIDENAMERF"));
                    //frePSalesDetailWork.USRSPG_GUIDENAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "USRSPGGUIDENAMERF" ) );
                    frePSalesDetailWork.SUPPLIERRF_SUPPLIERCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    frePSalesDetailWork.SUPPLIERRF_SUPPLIERNM1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
                    frePSalesDetailWork.SUPPLIERRF_SUPPLIERNM2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
                    frePSalesDetailWork.SUPPLIERRF_SUPPHONORIFICTITLERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPHONORIFICTITLERF"));
                    frePSalesDetailWork.SUPPLIERRF_SUPPLIERKANARF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERKANARF"));
                    frePSalesDetailWork.SUPPLIERRF_PURECODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PURECODERF"));
                    frePSalesDetailWork.SUPPLIERRF_SUPPLIERNOTE1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNOTE1RF"));
                    frePSalesDetailWork.SUPPLIERRF_SUPPLIERNOTE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNOTE2RF"));
                    frePSalesDetailWork.SUPPLIERRF_SUPPLIERNOTE3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNOTE3RF"));
                    frePSalesDetailWork.SUPPLIERRF_SUPPLIERNOTE4RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNOTE4RF"));
                    frePSalesDetailWork.BLGOODSCDURF_BLGOODSCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    frePSalesDetailWork.BLGOODSCDURF_BLGOODSHALFNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_MAKERHALFNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERHALFNAMERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_MODELHALFNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELHALFNAMERF"));
                    frePSalesDetailWork.SALESDETAILRF_PRTBLGOODSCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRTBLGOODSCODERF"));
                    frePSalesDetailWork.SALESDETAILRF_PRTBLGOODSNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRTBLGOODSNAMERF"));
                    frePSalesDetailWork.SALESDETAILRF_PRTGOODSNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRTGOODSNORF"));
                    frePSalesDetailWork.SALESDETAILRF_PRTMAKERCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRTMAKERCODERF"));
                    frePSalesDetailWork.SALESDETAILRF_PRTMAKERNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRTMAKERNAMERF"));
                    frePSalesDetailWork.MAKPRT_MAKERKANANAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKPRTMAKERKANANAMERF"));
                    frePSalesDetailWork.SALESDETAILRF_GOODSLGROUPRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
                    frePSalesDetailWork.SALESDETAILRF_GOODSLGROUPNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSLGROUPNAMERF"));
                    frePSalesDetailWork.SALESDETAILRF_GOODSMGROUPRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    frePSalesDetailWork.SALESDETAILRF_GOODSMGROUPNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));
                    frePSalesDetailWork.SALESDETAILRF_BLGROUPCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                    frePSalesDetailWork.SALESDETAILRF_BLGROUPNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPNAMERF"));
                    frePSalesDetailWork.SALESDETAILRF_SALESCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
                    frePSalesDetailWork.SALESDETAILRF_SALESCDNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESCDNMRF"));
                    frePSalesDetailWork.SALESDETAILRF_GOODSNAMEKANARF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
                    frePSalesDetailWork.SALESDETAILRF_AUTOANSWERDIVSCMRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOANSWERDIVSCMRF"));// ADD 2011/07/19
                    // --- ADD  汪千来  2009.07.27 ---------->>>>>
                    frePSalesDetailWork.SANDEGOODSCDCHGRF_ABGOODSCODE = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ABGOODSCODERF"));
                    // --- ADD  汪千来  2009.07.27 ----------<<<<<          
                    // add by zhouzy for PCCUOEリモート伝票発行 20110811 begin
                    frePSalesDetailWork.SALESDETAILRF_ACCEPTORORDERKINDRF = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ACCEPTORORDERKINDRF"));
                    frePSalesDetailWork.SALESDETAILRF_INQUIRYNUMBERRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INQUIRYNUMBERRF"));
                    frePSalesDetailWork.SALESDETAILRF_INQROWNUMBERRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQROWNUMBERRF"));
                    // add by zhouzy for PCCUOEリモート伝票発行 20110811  end

                    # endregion

                    // 同一伝票番号のリストが存在しなければ追加
                    FrePSalesSlipParaWork.FrePSalesSlipParaKey key = CreateSalesSlipKey(frePSalesDetailWork);
                    if (!detailListDic.ContainsKey(key))
                    {
                        detailListDic.Add(key, new List<FrePSalesDetailWork>());
                    }
                    // レコード追加
                    detailListDic[key].Add(frePSalesDetailWork);
                }

                if (detailListDic.Count > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                retObj = detailListDic;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SearchProc\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }
            return status;
        }
        /// <summary>
        /// 受注マスタ（車輌）のjoin条件
        /// </summary>
        /// <returns></returns>
        private string GetAcceptOdrCarJoinCndtn()
        {
            // "SALESDETAILRF"  : 10:見積,20:受注,30:売上,40:出荷,70:指示書,80:クレーム,99:一時保管  
            // "ACCEPTODRCARRF" : 1:見積 2:発注 3:受注 4:入荷 5:出荷 6:仕入 7:売上 8:返品 9:入金 10:支払
            StringBuilder text = new StringBuilder();
            text.Append(" (");
            // 見積
            text.Append(" SALESDETAILRF.ACPTANODRSTATUSRF='10' AND ACCEPTODRCARRF.ACPTANODRSTATUSRF='1' ");
            // 受注
            text.Append("OR");
            text.Append(" SALESDETAILRF.ACPTANODRSTATUSRF='20' AND ACCEPTODRCARRF.ACPTANODRSTATUSRF='3' ");
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2010/03/24 DEL
            //// 売上
            //text.Append( "OR" );
            //text.Append( " SALESDETAILRF.ACPTANODRSTATUSRF='30' AND ACCEPTODRCARRF.ACPTANODRSTATUSRF='7' AND SALESSLIPRF.SALESSLIPCDRF='0'" );
            //// 返品
            //text.Append( "OR" );
            //text.Append( " SALESDETAILRF.ACPTANODRSTATUSRF='30' AND ACCEPTODRCARRF.ACPTANODRSTATUSRF='8' AND SALESSLIPRF.SALESSLIPCDRF='1'" );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2010/03/24 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2010/03/24 ADD
            // 売上
            text.Append("OR");
            text.Append(" SALESDETAILRF.ACPTANODRSTATUSRF='30' AND ACCEPTODRCARRF.ACPTANODRSTATUSRF='7' ");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2010/03/24 ADD
            // 出荷
            text.Append("OR");
            text.Append(" SALESDETAILRF.ACPTANODRSTATUSRF='40' AND ACCEPTODRCARRF.ACPTANODRSTATUSRF='5' ");
            text.Append(")");
            return text.ToString();
        }
        # endregion

        // -------ADD 2010/06/08------->>>>>
        # region [売上履歴データ抽出]
        /// <summary>
        /// 自由帳票日次帳票グループ情報検索処理（メイン部）
        /// </summary>
        /// <param name="extPrm">自由帳票共通抽出条件クラス</param>
        /// <param name="retObj">印字位置設定ワーククラス配列</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 売上データの伝票情報が取得できない場合は、売上履歴データを読み込んで伝票情報を取得するようにする。</br>
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2010.06.08</br>
        /// </remarks>
        private int SearchProcOfHistory(FrePSalesSlipParaWork extPrm, out List<FrePSalesSlipWork> retObj, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            List<FrePSalesSlipWork> frePSalesSlipWorkList = new List<FrePSalesSlipWork>();
            retObj = null;

            try
            {
                //-------------------------------------------------------------------
                // 対象テーブル
                //   売上履歴データ       SalesHistoryRF 
                //   拠点情報設定マスタ   SecInfoSetRF       
                //   自社名称マスタ       CompanyNmRF
                //   画像情報マスタ       ImageInfoRF
                //   部門マスタ           SubsectionRF
                //   従業員マスタ①       EmployeeRF As EMPINP
                //   従業員マスタ②       EmployeeRF As EMPFRT
                //   従業員マスタ③       EmployeeRF As EMPSAL
                //   得意先マスタ①       CustomerRF As CSTCLM
                //   得意先マスタ②       CustomerRF As CSTCST
                //   得意先マスタ③       CustomerRF As CSTADR
                //   自社情報マスタ       CompanyInfRF
                //-------------------------------------------------------------------
                SqlCommand sqlCommand = new SqlCommand("SELECT " + this.GetSelectItemsForHistory(extPrm)
                    + Environment.NewLine
                    + " FROM SALESHISTORYRF " + Environment.NewLine
                    + LeftJoin("SALESHISTORYRF", "SECINFOSETRF", string.Empty, new string[] { }, new string[] { "SALESHISTORYRF.RESULTSADDUPSECCDRF=SECINFOSETRF.SECTIONCODERF" })  // 企業cd,拠点cd
                    + LeftJoin("SECINFOSETRF", "COMPANYNMRF", string.Empty, new string[] { }, new string[] { "SECINFOSETRF.COMPANYNAMECD1RF=COMPANYNMRF.COMPANYNAMECDRF" })    // 企業cd,自社名称cd
                    + LeftJoin("COMPANYNMRF", "IMAGEINFORF", string.Empty, new string[] { "IMAGEINFOCODERF" }, new string[] { "IMAGEINFORF.IMAGEINFODIVRF='10'" })    // 企業cd,画像情報cd,区分=10
                    + LeftJoin("SALESHISTORYRF", "SUBSECTIONRF", string.Empty, new string[] { "SUBSECTIONCODERF" }, new string[] { })   // 企業cd,部門cd
                    + LeftJoin("SALESHISTORYRF", "EMPLOYEERF", "EMPINP", new string[] { }, new string[] { "SALESHISTORYRF.SALESINPUTCODERF=EMPINP.EMPLOYEECODERF" })   // 企業cd,従業員cd
                    + LeftJoin("SALESHISTORYRF", "EMPLOYEERF", "EMPFRT", new string[] { }, new string[] { "SALESHISTORYRF.FRONTEMPLOYEECDRF=EMPFRT.EMPLOYEECODERF" })  // 企業cd,従業員cd
                    + LeftJoin("SALESHISTORYRF", "EMPLOYEERF", "EMPSAL", new string[] { }, new string[] { "SALESHISTORYRF.SALESEMPLOYEECDRF=EMPSAL.EMPLOYEECODERF" })  // 企業cd,従業員cd
                    + LeftJoin("SALESHISTORYRF", "CUSTOMERRF", "CSTCLM", new string[] { }, new string[] { "SALESHISTORYRF.CLAIMCODERF=CSTCLM.CUSTOMERCODERF" })    // 企業cd,得意先cd
                    + LeftJoin("SALESHISTORYRF", "CUSTOMERRF", "CSTCST", new string[] { }, new string[] { "SALESHISTORYRF.CUSTOMERCODERF=CSTCST.CUSTOMERCODERF" }) // 企業cd,得意先cd
                    + LeftJoin("SALESHISTORYRF", "CUSTOMERRF", "CSTADR", new string[] { }, new string[] { "SALESHISTORYRF.ADDRESSEECODERF=CSTADR.CUSTOMERCODERF" })    // 企業cd,得意先cd
                    + LeftJoin("SALESHISTORYRF", "COMPANYINFRF", string.Empty, new string[] { }, new string[] { }) // 企業cd
                    + LeftJoin("SALESHISTORYRF", "SANDESETTINGRF", string.Empty, new string[] { "CUSTOMERCODERF" }, new string[] { "SALESHISTORYRF.RESULTSADDUPSECCDRF=SANDESETTINGRF.SECTIONCODERF", "SANDESETTINGRF.LOGICALDELETECODERF=0" })    // 企業cd,得意先cd
                    , sqlConnection);

                // WHERE文を生成
                sqlCommand.CommandText += MakeWhereStringForHistory(ref sqlCommand, extPrm);
                // OrderBy句を生成
                sqlCommand.CommandText += " ORDER BY ACPTANODRSTATUSRF, SALESSLIPNUMRF " + Environment.NewLine;

                // タイムアウト時間設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    FrePSalesSlipWork frePSalesSlipWork = new FrePSalesSlipWork();

                    # region [データのコピー]
                    frePSalesSlipWork.SALESSLIPRF_ACPTANODRSTATUSRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                    frePSalesSlipWork.SALESSLIPRF_SALESSLIPNUMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                    frePSalesSlipWork.SALESSLIPRF_SECTIONCODERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    frePSalesSlipWork.SALESSLIPRF_SUBSECTIONCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
                    frePSalesSlipWork.SALESSLIPRF_DEBITNOTEDIVRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
                    frePSalesSlipWork.SALESSLIPRF_DEBITNLNKSALESSLNUMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEBITNLNKSALESSLNUMRF"));
                    frePSalesSlipWork.SALESSLIPRF_SALESSLIPCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDRF"));
                    frePSalesSlipWork.SALESSLIPRF_SALESGOODSCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESGOODSCDRF"));
                    frePSalesSlipWork.SALESSLIPRF_ACCRECDIVCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCRECDIVCDRF"));
                    frePSalesSlipWork.SALESSLIPRF_SEARCHSLIPDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEARCHSLIPDATERF"));
                    frePSalesSlipWork.SALESSLIPRF_SHIPMENTDAYRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SHIPMENTDAYRF"));
                    frePSalesSlipWork.SALESSLIPRF_SALESDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESDATERF"));
                    frePSalesSlipWork.SALESSLIPRF_ADDUPADATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                    frePSalesSlipWork.SALESSLIPRF_DELAYPAYMENTDIVRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELAYPAYMENTDIVRF"));
                    frePSalesSlipWork.SALESSLIPRF_SALESINPUTCODERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTCODERF"));
                    frePSalesSlipWork.SALESSLIPRF_SALESINPUTNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTNAMERF"));
                    frePSalesSlipWork.SALESSLIPRF_FRONTEMPLOYEECDRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEECDRF"));
                    frePSalesSlipWork.SALESSLIPRF_FRONTEMPLOYEENMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEENMRF"));
                    frePSalesSlipWork.SALESSLIPRF_SALESEMPLOYEECDRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEECDRF"));
                    frePSalesSlipWork.SALESSLIPRF_SALESEMPLOYEENMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEENMRF"));
                    frePSalesSlipWork.SALESSLIPRF_TOTALAMOUNTDISPWAYCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));
                    frePSalesSlipWork.SALESSLIPRF_TTLAMNTDISPRATEAPYRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TTLAMNTDISPRATEAPYRF"));
                    frePSalesSlipWork.SALESSLIPRF_SALESTOTALTAXINCRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXINCRF"));
                    frePSalesSlipWork.SALESSLIPRF_SALESTOTALTAXEXCRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXEXCRF"));
                    frePSalesSlipWork.SALESSLIPRF_SALESSUBTOTALTAXINCRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXINCRF"));
                    frePSalesSlipWork.SALESSLIPRF_SALESSUBTOTALTAXEXCRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXEXCRF"));
                    frePSalesSlipWork.SALESSLIPRF_SALESSUBTOTALTAXRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXRF"));
                    frePSalesSlipWork.SALESSLIPRF_ITDEDSALESOUTTAXRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESOUTTAXRF"));
                    frePSalesSlipWork.SALESSLIPRF_ITDEDSALESINTAXRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESINTAXRF"));
                    frePSalesSlipWork.SALESSLIPRF_SALSUBTTLSUBTOTAXFRERF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALSUBTTLSUBTOTAXFRERF"));
                    frePSalesSlipWork.SALESSLIPRF_SALAMNTCONSTAXINCLURF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALAMNTCONSTAXINCLURF"));
                    frePSalesSlipWork.SALESSLIPRF_SALESDISTTLTAXEXCRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISTTLTAXEXCRF"));
                    frePSalesSlipWork.SALESSLIPRF_ITDEDSALESDISOUTTAXRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESDISOUTTAXRF"));
                    frePSalesSlipWork.SALESSLIPRF_ITDEDSALESDISINTAXRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESDISINTAXRF"));
                    frePSalesSlipWork.SALESSLIPRF_SALESDISOUTTAXRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISOUTTAXRF"));
                    frePSalesSlipWork.SALESSLIPRF_SALESDISTTLTAXINCLURF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISTTLTAXINCLURF"));
                    frePSalesSlipWork.SALESSLIPRF_TOTALCOSTRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALCOSTRF"));
                    frePSalesSlipWork.SALESSLIPRF_CONSTAXLAYMETHODRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
                    frePSalesSlipWork.SALESSLIPRF_CONSTAXRATERF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CONSTAXRATERF"));
                    frePSalesSlipWork.SALESSLIPRF_FRACTIONPROCCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));
                    frePSalesSlipWork.SALESSLIPRF_ACCRECCONSTAXRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACCRECCONSTAXRF"));
                    frePSalesSlipWork.SALESSLIPRF_AUTODEPOSITCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITCDRF"));
                    frePSalesSlipWork.SALESSLIPRF_AUTODEPOSITSLIPNORF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITSLIPNORF"));
                    frePSalesSlipWork.SALESSLIPRF_DEPOSITALLOWANCETTLRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALLOWANCETTLRF"));
                    frePSalesSlipWork.SALESSLIPRF_DEPOSITALWCBLNCERF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALWCBLNCERF"));
                    frePSalesSlipWork.SALESSLIPRF_CLAIMCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
                    frePSalesSlipWork.SALESSLIPRF_CLAIMSNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
                    frePSalesSlipWork.SALESSLIPRF_CUSTOMERCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    frePSalesSlipWork.SALESSLIPRF_CUSTOMERNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
                    frePSalesSlipWork.SALESSLIPRF_CUSTOMERNAME2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
                    frePSalesSlipWork.SALESSLIPRF_CUSTOMERSNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                    frePSalesSlipWork.SALESSLIPRF_HONORIFICTITLERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));
                    frePSalesSlipWork.SALESSLIPRF_ADDRESSEECODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSEECODERF"));
                    frePSalesSlipWork.SALESSLIPRF_ADDRESSEENAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAMERF"));
                    frePSalesSlipWork.SALESSLIPRF_ADDRESSEENAME2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAME2RF"));
                    frePSalesSlipWork.SALESSLIPRF_ADDRESSEEPOSTNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEPOSTNORF"));
                    frePSalesSlipWork.SALESSLIPRF_ADDRESSEEADDR1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR1RF"));
                    frePSalesSlipWork.SALESSLIPRF_ADDRESSEEADDR3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR3RF"));
                    frePSalesSlipWork.SALESSLIPRF_ADDRESSEEADDR4RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR4RF"));
                    frePSalesSlipWork.SALESSLIPRF_ADDRESSEETELNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEETELNORF"));
                    frePSalesSlipWork.SALESSLIPRF_ADDRESSEEFAXNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEFAXNORF"));
                    frePSalesSlipWork.SALESSLIPRF_PARTYSALESLIPNUMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
                    frePSalesSlipWork.SALESSLIPRF_SLIPNOTERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTERF"));
                    frePSalesSlipWork.SALESSLIPRF_SLIPNOTE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE2RF"));
                    frePSalesSlipWork.SALESSLIPRF_RETGOODSREASONDIVRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSREASONDIVRF"));
                    frePSalesSlipWork.SALESSLIPRF_RETGOODSREASONRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RETGOODSREASONRF"));
                    frePSalesSlipWork.SALESSLIPRF_DETAILROWCOUNTRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILROWCOUNTRF"));
                    frePSalesSlipWork.SALESSLIPRF_EDISENDDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDISENDDATERF"));
                    frePSalesSlipWork.SALESSLIPRF_EDITAKEINDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
                    frePSalesSlipWork.SALESSLIPRF_UOEREMARK1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
                    frePSalesSlipWork.SALESSLIPRF_UOEREMARK2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
                    frePSalesSlipWork.SALESSLIPRF_SLIPPRINTFINISHCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTFINISHCDRF"));
                    frePSalesSlipWork.SALESSLIPRF_SALESSLIPPRINTDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPPRINTDATERF"));
                    frePSalesSlipWork.SALESSLIPRF_BUSINESSTYPECODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
                    frePSalesSlipWork.SALESSLIPRF_BUSINESSTYPENAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPENAMERF"));
                    frePSalesSlipWork.SALESSLIPRF_DELIVEREDGOODSDIVRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVRF"));
                    frePSalesSlipWork.SALESSLIPRF_DELIVEREDGOODSDIVNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVNMRF"));
                    frePSalesSlipWork.SALESSLIPRF_SALESAREACODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                    frePSalesSlipWork.SALESSLIPRF_SALESAREANAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));
                    frePSalesSlipWork.SALESSLIPRF_STOCKGOODSTTLTAXEXCRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKGOODSTTLTAXEXCRF"));
                    frePSalesSlipWork.SALESSLIPRF_PUREGOODSTTLTAXEXCRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PUREGOODSTTLTAXEXCRF"));
                    frePSalesSlipWork.SALESSLIPRF_LISTPRICEPRINTDIVRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LISTPRICEPRINTDIVRF"));
                    frePSalesSlipWork.SALESSLIPRF_ERANAMEDISPCD1RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ERANAMEDISPCD1RF"));
                    frePSalesSlipWork.SECINFOSETRF_SECTIONGUIDENMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                    frePSalesSlipWork.SECINFOSETRF_SECTIONGUIDESNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    frePSalesSlipWork.SECINFOSETRF_COMPANYNAMECD1RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYNAMECD1RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYPRRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYPRRF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYNAME1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYNAME1RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYNAME2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYNAME2RF"));
                    frePSalesSlipWork.COMPANYNMRF_POSTNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSTNORF"));
                    frePSalesSlipWork.COMPANYNMRF_ADDRESS1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS1RF"));
                    frePSalesSlipWork.COMPANYNMRF_ADDRESS3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS3RF"));
                    frePSalesSlipWork.COMPANYNMRF_ADDRESS4RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS4RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYTELNO1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO1RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYTELNO2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO2RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYTELNO3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO3RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYTELTITLE1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE1RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYTELTITLE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE2RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYTELTITLE3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE3RF"));
                    frePSalesSlipWork.COMPANYNMRF_TRANSFERGUIDANCERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRANSFERGUIDANCERF"));
                    frePSalesSlipWork.COMPANYNMRF_ACCOUNTNOINFO1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO1RF"));
                    frePSalesSlipWork.COMPANYNMRF_ACCOUNTNOINFO2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO2RF"));
                    frePSalesSlipWork.COMPANYNMRF_ACCOUNTNOINFO3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO3RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYSETNOTE1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYSETNOTE1RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYSETNOTE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYSETNOTE2RF"));
                    frePSalesSlipWork.COMPANYNMRF_IMAGEINFODIVRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IMAGEINFODIVRF"));
                    frePSalesSlipWork.COMPANYNMRF_IMAGEINFOCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IMAGEINFOCODERF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYURLRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYURLRF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYPRSENTENCE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYPRSENTENCE2RF"));
                    frePSalesSlipWork.COMPANYNMRF_IMAGECOMMENTFORPRT1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IMAGECOMMENTFORPRT1RF"));
                    frePSalesSlipWork.COMPANYNMRF_IMAGECOMMENTFORPRT2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IMAGECOMMENTFORPRT2RF"));
                    frePSalesSlipWork.IMAGEINFORF_IMAGEINFODATARF = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("IMAGEINFODATARF"));
                    frePSalesSlipWork.SUBSECTIONRF_SUBSECTIONNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUBSECTIONNAMERF"));
                    frePSalesSlipWork.EMPINP_KANARF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPINPKANARF"));
                    frePSalesSlipWork.EMPINP_SHORTNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPINPSHORTNAMERF"));
                    frePSalesSlipWork.EMPFRT_KANARF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPFRTKANARF"));
                    frePSalesSlipWork.EMPFRT_SHORTNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPFRTSHORTNAMERF"));
                    frePSalesSlipWork.EMPSAL_KANARF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPSALKANARF"));
                    frePSalesSlipWork.EMPSAL_SHORTNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPSALSHORTNAMERF"));
                    frePSalesSlipWork.CSTCLM_CUSTOMERSUBCODERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCLMCUSTOMERSUBCODERF"));
                    frePSalesSlipWork.CSTCLM_NAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCLMNAMERF"));
                    frePSalesSlipWork.CSTCLM_NAME2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCLMNAME2RF"));
                    frePSalesSlipWork.CSTCLM_HONORIFICTITLERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCLMHONORIFICTITLERF"));
                    frePSalesSlipWork.CSTCLM_KANARF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCLMKANARF"));
                    frePSalesSlipWork.CSTCLM_CUSTOMERSNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCLMCUSTOMERSNMRF"));
                    frePSalesSlipWork.CSTCLM_OUTPUTNAMECODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTCLMOUTPUTNAMECODERF"));
                    frePSalesSlipWork.CSTCLM_CUSTANALYSCODE1RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTCLMCUSTANALYSCODE1RF"));
                    frePSalesSlipWork.CSTCLM_CUSTANALYSCODE2RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTCLMCUSTANALYSCODE2RF"));
                    frePSalesSlipWork.CSTCLM_CUSTANALYSCODE3RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTCLMCUSTANALYSCODE3RF"));
                    frePSalesSlipWork.CSTCLM_CUSTANALYSCODE4RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTCLMCUSTANALYSCODE4RF"));
                    frePSalesSlipWork.CSTCLM_CUSTANALYSCODE5RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTCLMCUSTANALYSCODE5RF"));
                    frePSalesSlipWork.CSTCLM_CUSTANALYSCODE6RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTCLMCUSTANALYSCODE6RF"));
                    frePSalesSlipWork.CSTCLM_NOTE1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCLMNOTE1RF"));
                    frePSalesSlipWork.CSTCLM_NOTE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCLMNOTE2RF"));
                    frePSalesSlipWork.CSTCLM_NOTE3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCLMNOTE3RF"));
                    frePSalesSlipWork.CSTCLM_NOTE4RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCLMNOTE4RF"));
                    frePSalesSlipWork.CSTCLM_NOTE5RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCLMNOTE5RF"));
                    frePSalesSlipWork.CSTCLM_NOTE6RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCLMNOTE6RF"));
                    frePSalesSlipWork.CSTCLM_NOTE7RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCLMNOTE7RF"));
                    frePSalesSlipWork.CSTCLM_NOTE8RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCLMNOTE8RF"));
                    frePSalesSlipWork.CSTCLM_NOTE9RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCLMNOTE9RF"));
                    frePSalesSlipWork.CSTCLM_NOTE10RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCLMNOTE10RF"));
                    frePSalesSlipWork.CSTCST_CUSTOMERSUBCODERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTCUSTOMERSUBCODERF"));
                    frePSalesSlipWork.CSTCST_NAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTNAMERF"));
                    frePSalesSlipWork.CSTCST_NAME2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTNAME2RF"));
                    frePSalesSlipWork.CSTCST_HONORIFICTITLERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTHONORIFICTITLERF"));
                    frePSalesSlipWork.CSTCST_KANARF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTKANARF"));
                    frePSalesSlipWork.CSTCST_CUSTOMERSNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTCUSTOMERSNMRF"));
                    frePSalesSlipWork.CSTCST_OUTPUTNAMECODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTCSTOUTPUTNAMECODERF"));
                    frePSalesSlipWork.CSTCST_CUSTANALYSCODE1RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTCSTCUSTANALYSCODE1RF"));
                    frePSalesSlipWork.CSTCST_CUSTANALYSCODE2RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTCSTCUSTANALYSCODE2RF"));
                    frePSalesSlipWork.CSTCST_CUSTANALYSCODE3RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTCSTCUSTANALYSCODE3RF"));
                    frePSalesSlipWork.CSTCST_CUSTANALYSCODE4RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTCSTCUSTANALYSCODE4RF"));
                    frePSalesSlipWork.CSTCST_CUSTANALYSCODE5RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTCSTCUSTANALYSCODE5RF"));
                    frePSalesSlipWork.CSTCST_CUSTANALYSCODE6RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTCSTCUSTANALYSCODE6RF"));
                    frePSalesSlipWork.CSTCST_NOTE1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTNOTE1RF"));
                    frePSalesSlipWork.CSTCST_NOTE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTNOTE2RF"));
                    frePSalesSlipWork.CSTCST_NOTE3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTNOTE3RF"));
                    frePSalesSlipWork.CSTCST_NOTE4RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTNOTE4RF"));
                    frePSalesSlipWork.CSTCST_NOTE5RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTNOTE5RF"));
                    frePSalesSlipWork.CSTCST_NOTE6RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTNOTE6RF"));
                    frePSalesSlipWork.CSTCST_NOTE7RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTNOTE7RF"));
                    frePSalesSlipWork.CSTCST_NOTE8RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTNOTE8RF"));
                    frePSalesSlipWork.CSTCST_NOTE9RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTNOTE9RF"));
                    frePSalesSlipWork.CSTCST_NOTE10RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTNOTE10RF"));
                    // ---- ADD caohh 2011/08/17 ------>>>>>
                    frePSalesSlipWork.CSTCST_POSTNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTPOSTNORF"));
                    frePSalesSlipWork.CSTCST_ADDRESS1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTADDRESS1RF"));
                    frePSalesSlipWork.CSTCST_ADDRESS3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTADDRESS3RF"));
                    frePSalesSlipWork.CSTCST_ADDRESS4RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTADDRESS4RF"));
                    frePSalesSlipWork.CSTCST_HOMETELNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTHOMETELNORF"));
                    frePSalesSlipWork.CSTCST_OFFICETELNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTOFFICETELNORF"));
                    frePSalesSlipWork.CSTCST_PORTABLETELNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTPORTABLETELNORF"));
                    frePSalesSlipWork.CSTCST_OTHERSTELNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTOTHERSTELNORF"));
                    frePSalesSlipWork.CSTCST_HOMEFAXNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTHOMEFAXNORF"));
                    frePSalesSlipWork.CSTCST_OFFICEFAXNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTCSTOFFICEFAXNORF"));
                    // ---- ADD caohh 2011/08/17 ------<<<<<
                    frePSalesSlipWork.CSTADR_CUSTOMERSUBCODERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTADRCUSTOMERSUBCODERF"));
                    frePSalesSlipWork.CSTADR_NAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTADRNAMERF"));
                    frePSalesSlipWork.CSTADR_NAME2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTADRNAME2RF"));
                    frePSalesSlipWork.CSTADR_HONORIFICTITLERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTADRHONORIFICTITLERF"));
                    frePSalesSlipWork.CSTADR_KANARF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTADRKANARF"));
                    frePSalesSlipWork.CSTADR_CUSTOMERSNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTADRCUSTOMERSNMRF"));
                    frePSalesSlipWork.CSTADR_OUTPUTNAMECODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTADROUTPUTNAMECODERF"));
                    frePSalesSlipWork.CSTADR_CUSTANALYSCODE1RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTADRCUSTANALYSCODE1RF"));
                    frePSalesSlipWork.CSTADR_CUSTANALYSCODE2RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTADRCUSTANALYSCODE2RF"));
                    frePSalesSlipWork.CSTADR_CUSTANALYSCODE3RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTADRCUSTANALYSCODE3RF"));
                    frePSalesSlipWork.CSTADR_CUSTANALYSCODE4RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTADRCUSTANALYSCODE4RF"));
                    frePSalesSlipWork.CSTADR_CUSTANALYSCODE5RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTADRCUSTANALYSCODE5RF"));
                    frePSalesSlipWork.CSTADR_CUSTANALYSCODE6RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTADRCUSTANALYSCODE6RF"));
                    frePSalesSlipWork.CSTADR_NOTE1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTADRNOTE1RF"));
                    frePSalesSlipWork.CSTADR_NOTE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTADRNOTE2RF"));
                    frePSalesSlipWork.CSTADR_NOTE3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTADRNOTE3RF"));
                    frePSalesSlipWork.CSTADR_NOTE4RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTADRNOTE4RF"));
                    frePSalesSlipWork.CSTADR_NOTE5RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTADRNOTE5RF"));
                    frePSalesSlipWork.CSTADR_NOTE6RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTADRNOTE6RF"));
                    frePSalesSlipWork.CSTADR_NOTE7RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTADRNOTE7RF"));
                    frePSalesSlipWork.CSTADR_NOTE8RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTADRNOTE8RF"));
                    frePSalesSlipWork.CSTADR_NOTE9RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTADRNOTE9RF"));
                    frePSalesSlipWork.CSTADR_NOTE10RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSTADRNOTE10RF"));
                    frePSalesSlipWork.COMPANYINFRF_COMPANYNAME1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFCOMPANYNAME1RF"));
                    frePSalesSlipWork.COMPANYINFRF_COMPANYNAME2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFCOMPANYNAME2RF"));
                    frePSalesSlipWork.COMPANYINFRF_POSTNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFPOSTNORF"));
                    frePSalesSlipWork.COMPANYINFRF_ADDRESS1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFADDRESS1RF"));
                    frePSalesSlipWork.COMPANYINFRF_ADDRESS3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFADDRESS3RF"));
                    frePSalesSlipWork.COMPANYINFRF_ADDRESS4RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFADDRESS4RF"));
                    frePSalesSlipWork.COMPANYINFRF_COMPANYTELNO1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFCOMPANYTELNO1RF"));
                    frePSalesSlipWork.COMPANYINFRF_COMPANYTELNO2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFCOMPANYTELNO2RF"));
                    frePSalesSlipWork.COMPANYINFRF_COMPANYTELNO3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFCOMPANYTELNO3RF"));
                    frePSalesSlipWork.COMPANYINFRF_COMPANYTELTITLE1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFCOMPANYTELTITLE1RF"));
                    frePSalesSlipWork.COMPANYINFRF_COMPANYTELTITLE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFCOMPANYTELTITLE2RF"));
                    frePSalesSlipWork.COMPANYINFRF_COMPANYTELTITLE3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFCOMPANYTELTITLE3RF"));
                    frePSalesSlipWork.SALESSLIPRF_SLIPNOTE3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE3RF"));
                    frePSalesSlipWork.SALESSLIPRF_RESULTSADDUPSECCDRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
                    frePSalesSlipWork.SALESSLIPRF_UPDATEDATETIMERF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時
                    // --- ADD  汪千来  2009.07.27 ---------->>>>>
                    frePSalesSlipWork.SANDESETTINGRF_CUSTOMERCODE = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SANCUSTOMERCODERF"));//納品先店舗コード	
                    frePSalesSlipWork.SANDESETTINGRF_ADDRESSEESHOPCD = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEESHOPCDRF"));//納品先店舗コード	
                    frePSalesSlipWork.SANDESETTINGRF_SANDEMNGCODE = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SANDEMNGCODERF"));//住電管理コード	
                    frePSalesSlipWork.SANDESETTINGRF_EXPENSEDIVCD = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EXPENSEDIVCDRF"));//経費区分	
                    frePSalesSlipWork.SANDESETTINGRF_DIRECTSENDINGCD = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DIRECTSENDINGCDRF"));//直送区分	
                    frePSalesSlipWork.SANDESETTINGRF_ACPTANORDERDIV = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANORDERDIVRF"));//受注区分	
                    frePSalesSlipWork.SANDESETTINGRF_DELIVERERCD = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIVERERCDRF"));//納品者コード	
                    frePSalesSlipWork.SANDESETTINGRF_DELIVERERNM = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIVERERNMRF"));//納品者名	
                    frePSalesSlipWork.SANDESETTINGRF_DELIVERERADDRESS = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIVERERADDRESSRF"));//納品者住所	
                    frePSalesSlipWork.SANDESETTINGRF_DELIVERERPHONENUM = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIVERERPHONENUMRF"));//納品者ＴＥＬ	
                    frePSalesSlipWork.SANDESETTINGRF_TRADCOMPNAME = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRADCOMPNAMERF"));//部品商名	
                    frePSalesSlipWork.SANDESETTINGRF_TRADCOMPSECTNAME = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRADCOMPSECTNAMERF"));//部品商拠点名	
                    frePSalesSlipWork.SANDESETTINGRF_PURETRADCOMPCD = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PURETRADCOMPCDRF"));//部品商コード（純正）	
                    frePSalesSlipWork.SANDESETTINGRF_PURETRADCOMPRATE = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PURETRADCOMPRATERF"));//部品商仕切率（純正）	
                    frePSalesSlipWork.SANDESETTINGRF_PRITRADCOMPCD = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRITRADCOMPCDRF"));//部品商コード（優良）	
                    frePSalesSlipWork.SANDESETTINGRF_PRITRADCOMPRATE = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRITRADCOMPRATERF"));//部品商仕切率（優良）	
                    frePSalesSlipWork.SANDESETTINGRF_ABGOODSCODE = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ABGOODSCODERF"));//AB商品コード	
                    frePSalesSlipWork.SANDESETTINGRF_COMMENTRESERVEDDIV = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMMENTRESERVEDDIVRF"));//コメント指定区分	
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD1RF"));//商品メーカーコード１	
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD2RF"));//商品メーカーコード２	
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD3RF"));//商品メーカーコード３	
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD4RF"));//商品メーカーコード４	
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD5RF"));//商品メーカーコード５	
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD6RF"));//商品メーカーコード６	
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD7 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD7RF"));//商品メーカーコード７	
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD8 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD8RF"));//商品メーカーコード８	
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD9 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD9RF"));//商品メーカーコード９	
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD10 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD10RF"));//商品メーカーコード１０	
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD11 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD11RF"));//商品メーカーコード１１	
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD12 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD12RF"));//商品メーカーコード１２	
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD13 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD13RF"));//商品メーカーコード１３	
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD14 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD14RF"));//商品メーカーコード１４	
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD15 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD15RF"));//商品メーカーコード１５	
                    frePSalesSlipWork.SANDESETTINGRF_PARTSOEMDIV = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSOEMDIVRF"));//部品ＯＥＭ区分	
                    frePSalesSlipWork.CSTCST_SALESUNPRCFRCPROCCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESUNPRCFRCPROCCDRF"));  // 売上単価端数処理コード
                    frePSalesSlipWork.CSTCST_SALESMONEYFRCPROCCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESMONEYFRCPROCCDRF"));  // 売上金額端数処理コード
                    frePSalesSlipWork.CSTCST_SALESCNSTAXFRCPROCCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCNSTAXFRCPROCCDRF"));  // 売上消費税端数処理コード
                    frePSalesSlipWork.CSTCST_QRCODEPRTCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("QRCODEPRTCDRF"));  // QRコード印刷
                    // 2010/07/06 Add >>>
                    frePSalesSlipWork.SALESSLIPRF_FILEHEADERGUID = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));  // QRコード印刷
                    // 2010/07/06 Add <<<
                    # endregion

                    frePSalesSlipWorkList.Add(frePSalesSlipWork);
                }

                if (frePSalesSlipWorkList.Count > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                retObj = frePSalesSlipWorkList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SearchProc\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }
            return status;
        }
        # endregion

        # region [売上履歴明細データ抽出]
        /// <summary>
        /// 売上履歴明細データ抽出
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="retObj"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        /// <br>Note		: 売上明細データの伝票情報が取得できない場合は、売上履歴明細データを読み込んで伝票情報を取得するようにする。</br>
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2010/06/08</br>
        /// <br>Update Note :   2020/03/18 寺田義啓</br>
        /// <br>管理番号    :   11670121-00 S＆E改良対応</br>
        private int SearchProcOfDetailForHistory(FrePSalesSlipParaWork extPrm, out Dictionary<FrePSalesSlipParaWork.FrePSalesSlipParaKey, List<FrePSalesDetailWork>> retObj, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;

            Dictionary<FrePSalesSlipParaWork.FrePSalesSlipParaKey, List<FrePSalesDetailWork>> detailListDic = new Dictionary<FrePSalesSlipParaWork.FrePSalesSlipParaKey, List<FrePSalesDetailWork>>();
            retObj = null;

            try
            {
                //-------------------------------------------------------------------
                // 対象テーブル
                //   売上履歴明細データ       SalesHistDtlRF 
                //   受注マスタ(車両)     AcceptOdrCarRF
                //   メーカーマスタ①     MakerURF As MAKGDS
                //   メーカーマスタ②     MakerURF As MAKCMP
                //   メーカーマスタ③     MakerURF As MAKPRT
                //   商品マスタ           GoodsURF
                //   在庫マスタ           StockRF
                //   倉庫マスタ           WarehouseRF
                //   ﾕｰｻﾞｰｶﾞｲﾄﾞﾏｽﾀ①     UserGdBdURF As USRCSG
                //   仕入先マスタ         SupplierRF
                //   ＢＬｺｰﾄﾞﾏｽﾀ         BLGoodsCdURF
                //-------------------------------------------------------------------
                SqlCommand sqlCommand = new SqlCommand("SELECT " + this.GetSelectItemsForDetailHistory(extPrm)
                    + Environment.NewLine
                    + " FROM SALESHISTDTLRF " + Environment.NewLine
                    + LeftJoin("SALESHISTDTLRF", "SALESSLIPRF", string.Empty, new string[] { "ACPTANODRSTATUSRF", "SALESSLIPNUMRF" }, new string[] { })    // 企業cd, 受注ｽﾃｰﾀｽ, 伝票番号
                    + LeftJoin("SALESHISTDTLRF", "ACCEPTODRCARRF", string.Empty, new string[] { "ACCEPTANORDERNORF" }, new string[] { "ACCEPTODRCARRF.DATAINPUTSYSTEMRF='10'", GetAcceptOdrCarJoinCndtnForHistory() })    // 企業cd, 受注番号,受注ｽﾃｰﾀｽが対応する(GetAcceptOdrCarJoinCndtn),入力ｼｽﾃﾑ=10:PM
                    + LeftJoin("SALESHISTDTLRF", "MAKERURF", "MAKGDS", new string[] { "GOODSMAKERCDRF" }, new string[] { })    // 企業cd,ﾒｰｶｰcd
                    + LeftJoin("SALESHISTDTLRF", "MAKERURF", "MAKCMP", new string[] { }, new string[] { "SALESHISTDTLRF.CMPLTGOODSMAKERCDRF=MAKCMP.GOODSMAKERCDRF" })    // 企業cd,ﾒｰｶｰcd
                    + LeftJoin("SALESHISTDTLRF", "MAKERURF", "MAKPRT", new string[] { }, new string[] { "SALESHISTDTLRF.PRTMAKERCODERF=MAKPRT.GOODSMAKERCDRF" })    // 企業cd,ﾒｰｶｰcd
                    + LeftJoin("SALESHISTDTLRF", "GOODSURF", string.Empty, new string[] { "GOODSNORF", "GOODSMAKERCDRF" }, new string[] { })    // 企業cd,商品番号,ﾒｰｶｰcd
                    + LeftJoin("SALESHISTDTLRF", "STOCKRF", string.Empty, new string[] { "GOODSNORF", "GOODSMAKERCDRF", "WAREHOUSECODERF" }, new string[] { })    // 企業cd,商品番号,ﾒｰｶｰcd,倉庫cd
                    + LeftJoin("SALESHISTDTLRF", "WAREHOUSERF", string.Empty, new string[] { "WAREHOUSECODERF" }, new string[] { })    // 企業cd,倉庫cd
                    + LeftJoin("SALESHISTDTLRF", "USERGDBDURF", "USRCSG", new string[] { }, new string[] { "USRCSG.USERGUIDEDIVCDRF='43'", "SALESHISTDTLRF.CUSTRATEGRPCODERF=USRCSG.GUIDECODERF" })    // 企業cd,ｶﾞｲﾄﾞ区分=43,ｶﾞｲﾄﾞcd
                    + LeftJoin("SALESHISTDTLRF", "SUPPLIERRF", string.Empty, new string[] { "SUPPLIERCDRF" }, new string[] { })    // 企業cd,仕入先cd
                    + LeftJoin("SALESHISTDTLRF", "BLGOODSCDURF", string.Empty, new string[] { "BLGOODSCODERF" }, new string[] { })    // 企業cd,BLcd
                    // --- UPD 寺田義啓 2020.03.18 ---------->>>>>
                    //+ LeftJoin("SALESHISTDTLRF", "SANDEGOODSCDCHGRF", string.Empty, new string[] { "BLGOODSCODERF" }, new string[] { "SANDEGOODSCDCHGRF.LOGICALDELETECODERF=0" })    // 企業cd,BLcd
                    + "LEFT JOIN SANDEGOODSCDCHGRF ON SALESHISTDTLRF.PRTBLGOODSCODERF = SANDEGOODSCDCHGRF.BLGOODSCODERF AND SALESHISTDTLRF.ENTERPRISECODERF = SANDEGOODSCDCHGRF.ENTERPRISECODERF AND SANDEGOODSCDCHGRF.LOGICALDELETECODERF=0" + Environment.NewLine // 企業cd,BLcd
                    + "LEFT JOIN SANDEMKRGDSCDCHGRF ON SALESHISTDTLRF.GOODSMAKERCDRF = SANDEMKRGDSCDCHGRF.GOODSMAKERCDRF AND SALESHISTDTLRF.PRTGOODSNORF = SANDEMKRGDSCDCHGRF.GOODSNORF AND SALESHISTDTLRF.ENTERPRISECODERF = SANDEMKRGDSCDCHGRF.ENTERPRISECODERF AND SANDEMKRGDSCDCHGRF.LOGICALDELETECODERF=0" + Environment.NewLine // 企業cd,商品ﾒｰｶｰｺｰﾄﾞ,商品番号
                    // --- UPD 寺田義啓 2020.03.18 ----------<<<<<                    
                    , sqlConnection);

                // WHERE文を生成
                sqlCommand.CommandText += MakeWhereStringForDetailHistory(ref sqlCommand, extPrm);
                // OrderBy句を生成
                sqlCommand.CommandText += " ORDER BY ACPTANODRSTATUSRF, SALESSLIPNUMRF, SALESROWNORF " + Environment.NewLine;

                // タイムアウト時間設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    FrePSalesDetailWork frePSalesDetailWork = new FrePSalesDetailWork();

                    # region [データのコピー]
                    frePSalesDetailWork.SALESDETAILRF_ACPTANODRSTATUSRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                    frePSalesDetailWork.SALESDETAILRF_SALESSLIPNUMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                    frePSalesDetailWork.SALESDETAILRF_ACCEPTANORDERNORF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
                    frePSalesDetailWork.SALESDETAILRF_SALESROWNORF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));
                    frePSalesDetailWork.SALESDETAILRF_SALESDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESDATERF"));
                    frePSalesDetailWork.SALESDETAILRF_COMMONSEQNORF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));
                    frePSalesDetailWork.SALESDETAILRF_SALESSLIPDTLNUMRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMRF"));
                    frePSalesDetailWork.SALESDETAILRF_ACPTANODRSTATUSSRCRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSSRCRF"));
                    frePSalesDetailWork.SALESDETAILRF_SALESSLIPDTLNUMSRCRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMSRCRF"));
                    frePSalesDetailWork.SALESDETAILRF_SUPPLIERFORMALSYNCRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALSYNCRF"));
                    frePSalesDetailWork.SALESDETAILRF_STOCKSLIPDTLNUMSYNCRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMSYNCRF"));
                    frePSalesDetailWork.SALESDETAILRF_SALESSLIPCDDTLRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDDTLRF"));
                    frePSalesDetailWork.SALESDETAILRF_GOODSKINDCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
                    frePSalesDetailWork.SALESDETAILRF_GOODSMAKERCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    frePSalesDetailWork.SALESDETAILRF_MAKERNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    frePSalesDetailWork.SALESDETAILRF_GOODSNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    frePSalesDetailWork.SALESDETAILRF_GOODSNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    frePSalesDetailWork.SALESDETAILRF_BLGOODSCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    frePSalesDetailWork.SALESDETAILRF_BLGOODSFULLNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
                    frePSalesDetailWork.SALESDETAILRF_ENTERPRISEGANRECODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
                    frePSalesDetailWork.SALESDETAILRF_ENTERPRISEGANRENAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISEGANRENAMERF"));
                    frePSalesDetailWork.SALESDETAILRF_WAREHOUSECODERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    frePSalesDetailWork.SALESDETAILRF_WAREHOUSENAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    frePSalesDetailWork.SALESDETAILRF_WAREHOUSESHELFNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    frePSalesDetailWork.SALESDETAILRF_SALESORDERDIVCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERDIVCDRF"));
                    frePSalesDetailWork.SALESDETAILRF_OPENPRICEDIVRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                    frePSalesDetailWork.SALESDETAILRF_GOODSRATERANKRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
                    frePSalesDetailWork.SALESDETAILRF_CUSTRATEGRPCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
                    frePSalesDetailWork.SALESDETAILRF_LISTPRICERATERF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERATERF"));
                    frePSalesDetailWork.SALESDETAILRF_LISTPRICETAXINCFLRF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXINCFLRF"));
                    frePSalesDetailWork.SALESDETAILRF_LISTPRICETAXEXCFLRF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                    frePSalesDetailWork.SALESDETAILRF_LISTPRICECHNGCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LISTPRICECHNGCDRF"));
                    frePSalesDetailWork.SALESDETAILRF_SALESRATERF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESRATERF"));
                    frePSalesDetailWork.SALESDETAILRF_SALESUNPRCTAXINCFLRF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXINCFLRF"));
                    frePSalesDetailWork.SALESDETAILRF_SALESUNPRCTAXEXCFLRF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
                    frePSalesDetailWork.SALESDETAILRF_COSTRATERF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("COSTRATERF"));
                    frePSalesDetailWork.SALESDETAILRF_SALESUNITCOSTRF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
                    frePSalesDetailWork.SALESDETAILRF_SHIPMENTCNTRF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                    frePSalesDetailWork.SALESDETAILRF_SALESMONEYTAXINCRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXINCRF"));
                    frePSalesDetailWork.SALESDETAILRF_SALESMONEYTAXEXCRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
                    frePSalesDetailWork.SALESDETAILRF_COSTRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COSTRF"));
                    frePSalesDetailWork.SALESDETAILRF_GRSPROFITCHKDIVRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GRSPROFITCHKDIVRF"));
                    frePSalesDetailWork.SALESDETAILRF_SALESGOODSCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESGOODSCDRF"));
                    frePSalesDetailWork.SALESDETAILRF_TAXATIONDIVCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
                    frePSalesDetailWork.SALESDETAILRF_PARTYSLIPNUMDTLRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSLIPNUMDTLRF"));
                    frePSalesDetailWork.SALESDETAILRF_DTLNOTERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DTLNOTERF"));
                    frePSalesDetailWork.SALESDETAILRF_SUPPLIERCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    frePSalesDetailWork.SALESDETAILRF_SUPPLIERSNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    frePSalesDetailWork.SALESDETAILRF_ORDERNUMBERRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERNUMBERRF"));
                    frePSalesDetailWork.SALESDETAILRF_SLIPMEMO1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO1RF"));
                    frePSalesDetailWork.SALESDETAILRF_SLIPMEMO2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO2RF"));
                    frePSalesDetailWork.SALESDETAILRF_SLIPMEMO3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO3RF"));
                    frePSalesDetailWork.SALESDETAILRF_INSIDEMEMO1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO1RF"));
                    frePSalesDetailWork.SALESDETAILRF_INSIDEMEMO2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO2RF"));
                    frePSalesDetailWork.SALESDETAILRF_INSIDEMEMO3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO3RF"));
                    frePSalesDetailWork.SALESDETAILRF_BFLISTPRICERF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFLISTPRICERF"));
                    frePSalesDetailWork.SALESDETAILRF_BFSALESUNITPRICERF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSALESUNITPRICERF"));
                    frePSalesDetailWork.SALESDETAILRF_BFUNITCOSTRF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFUNITCOSTRF"));
                    frePSalesDetailWork.SALESDETAILRF_CMPLTSALESROWNORF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CMPLTSALESROWNORF"));
                    frePSalesDetailWork.SALESDETAILRF_CMPLTGOODSMAKERCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CMPLTGOODSMAKERCDRF"));
                    frePSalesDetailWork.SALESDETAILRF_CMPLTMAKERNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTMAKERNAMERF"));
                    frePSalesDetailWork.SALESDETAILRF_CMPLTGOODSNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTGOODSNAMERF"));
                    frePSalesDetailWork.SALESDETAILRF_CMPLTSHIPMENTCNTRF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CMPLTSHIPMENTCNTRF"));
                    frePSalesDetailWork.SALESDETAILRF_CMPLTSALESUNPRCFLRF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CMPLTSALESUNPRCFLRF"));
                    frePSalesDetailWork.SALESDETAILRF_CMPLTSALESMONEYRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CMPLTSALESMONEYRF"));
                    frePSalesDetailWork.SALESDETAILRF_CMPLTSALESUNITCOSTRF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CMPLTSALESUNITCOSTRF"));
                    frePSalesDetailWork.SALESDETAILRF_CMPLTCOSTRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CMPLTCOSTRF"));
                    frePSalesDetailWork.SALESDETAILRF_CMPLTPARTYSALSLNUMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTPARTYSALSLNUMRF"));
                    frePSalesDetailWork.SALESDETAILRF_CMPLTNOTERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTNOTERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_CARMNGNORF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARMNGNORF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_CARMNGCODERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARMNGCODERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_NUMBERPLATE1CODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE1CODERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_NUMBERPLATE1NAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE1NAMERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_NUMBERPLATE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE2RF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_NUMBERPLATE3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE3RF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_NUMBERPLATE4RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE4RF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_FIRSTENTRYDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FIRSTENTRYDATERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_MAKERCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_MAKERFULLNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERFULLNAMERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_MODELCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_MODELSUBCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_MODELFULLNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELFULLNAMERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_EXHAUSTGASSIGNRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EXHAUSTGASSIGNRF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_SERIESMODELRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SERIESMODELRF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_CATEGORYSIGNMODELRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATEGORYSIGNMODELRF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_FULLMODELRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_MODELDESIGNATIONNORF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_CATEGORYNORF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_FRAMEMODELRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMEMODELRF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_FRAMENORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMENORF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_SEARCHFRAMENORF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEARCHFRAMENORF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_ENGINEMODELNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEMODELNMRF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_RELEVANCEMODELRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RELEVANCEMODELRF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_SUBCARNMCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBCARNMCDRF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_MODELGRADESNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELGRADESNAMERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_COLORCODERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORCODERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_COLORNAME1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORNAME1RF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_TRIMCODERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMCODERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_TRIMNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMNAMERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_MILEAGERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MILEAGERF"));
                    frePSalesDetailWork.MAKGDS_MAKERSHORTNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKGDSMAKERSHORTNAMERF"));
                    frePSalesDetailWork.MAKGDS_MAKERKANANAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKGDSMAKERKANANAMERF"));
                    frePSalesDetailWork.MAKGDS_GOODSMAKERCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKGDSGOODSMAKERCDRF"));
                    frePSalesDetailWork.MAKCMP_MAKERSHORTNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKCMPMAKERSHORTNAMERF"));
                    frePSalesDetailWork.MAKCMP_MAKERKANANAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKCMPMAKERKANANAMERF"));
                    frePSalesDetailWork.MAKCMP_GOODSMAKERCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKCMPGOODSMAKERCDRF"));
                    frePSalesDetailWork.GOODSURF_GOODSNAMEKANARF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSURFGOODSNAMEKANARF"));
                    frePSalesDetailWork.GOODSURF_JANRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSURFJANRF"));
                    frePSalesDetailWork.GOODSURF_GOODSRATERANKRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSURFGOODSRATERANKRF"));
                    frePSalesDetailWork.GOODSURF_GOODSNONONEHYPHENRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSURFGOODSNONONEHYPHENRF"));
                    frePSalesDetailWork.GOODSURF_GOODSNOTE1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSURFGOODSNOTE1RF"));
                    frePSalesDetailWork.GOODSURF_GOODSNOTE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSURFGOODSNOTE2RF"));
                    frePSalesDetailWork.GOODSURF_GOODSSPECIALNOTERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSURFGOODSSPECIALNOTERF"));
                    frePSalesDetailWork.STOCKRF_SHIPMENTPOSCNTRF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
                    frePSalesDetailWork.STOCKRF_DUPLICATIONSHELFNO1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO1RF"));
                    frePSalesDetailWork.STOCKRF_DUPLICATIONSHELFNO2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO2RF"));
                    frePSalesDetailWork.STOCKRF_PARTSMANAGEMENTDIVIDE1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE1RF"));
                    frePSalesDetailWork.STOCKRF_PARTSMANAGEMENTDIVIDE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE2RF"));
                    frePSalesDetailWork.STOCKRF_STOCKNOTE1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE1RF"));
                    frePSalesDetailWork.STOCKRF_STOCKNOTE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE2RF"));
                    frePSalesDetailWork.WAREHOUSERF_WAREHOUSENOTE1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENOTE1RF"));
                    frePSalesDetailWork.USRCSG_GUIDENAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("USRCSGGUIDENAMERF"));
                    frePSalesDetailWork.SUPPLIERRF_SUPPLIERCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    frePSalesDetailWork.SUPPLIERRF_SUPPLIERNM1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
                    frePSalesDetailWork.SUPPLIERRF_SUPPLIERNM2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
                    frePSalesDetailWork.SUPPLIERRF_SUPPHONORIFICTITLERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPHONORIFICTITLERF"));
                    frePSalesDetailWork.SUPPLIERRF_SUPPLIERKANARF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERKANARF"));
                    frePSalesDetailWork.SUPPLIERRF_PURECODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PURECODERF"));
                    frePSalesDetailWork.SUPPLIERRF_SUPPLIERNOTE1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNOTE1RF"));
                    frePSalesDetailWork.SUPPLIERRF_SUPPLIERNOTE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNOTE2RF"));
                    frePSalesDetailWork.SUPPLIERRF_SUPPLIERNOTE3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNOTE3RF"));
                    frePSalesDetailWork.SUPPLIERRF_SUPPLIERNOTE4RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNOTE4RF"));
                    frePSalesDetailWork.BLGOODSCDURF_BLGOODSCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    frePSalesDetailWork.BLGOODSCDURF_BLGOODSHALFNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_MAKERHALFNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERHALFNAMERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_MODELHALFNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELHALFNAMERF"));
                    frePSalesDetailWork.SALESDETAILRF_PRTBLGOODSCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRTBLGOODSCODERF"));
                    frePSalesDetailWork.SALESDETAILRF_PRTBLGOODSNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRTBLGOODSNAMERF"));
                    frePSalesDetailWork.SALESDETAILRF_PRTGOODSNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRTGOODSNORF"));
                    frePSalesDetailWork.SALESDETAILRF_PRTMAKERCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRTMAKERCODERF"));
                    frePSalesDetailWork.SALESDETAILRF_PRTMAKERNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRTMAKERNAMERF"));
                    frePSalesDetailWork.MAKPRT_MAKERKANANAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKPRTMAKERKANANAMERF"));
                    frePSalesDetailWork.SALESDETAILRF_GOODSLGROUPRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
                    frePSalesDetailWork.SALESDETAILRF_GOODSLGROUPNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSLGROUPNAMERF"));
                    frePSalesDetailWork.SALESDETAILRF_GOODSMGROUPRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    frePSalesDetailWork.SALESDETAILRF_GOODSMGROUPNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));
                    frePSalesDetailWork.SALESDETAILRF_BLGROUPCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                    frePSalesDetailWork.SALESDETAILRF_BLGROUPNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPNAMERF"));
                    frePSalesDetailWork.SALESDETAILRF_SALESCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
                    frePSalesDetailWork.SALESDETAILRF_SALESCDNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESCDNMRF"));
                    frePSalesDetailWork.SALESDETAILRF_GOODSNAMEKANARF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
                    frePSalesDetailWork.SALESDETAILRF_AUTOANSWERDIVSCMRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOANSWERDIVSCMRF"));// ADD 2011/07/19
                    frePSalesDetailWork.SANDEGOODSCDCHGRF_ABGOODSCODE = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ABGOODSCODERF"));
                    # endregion

                    // 同一伝票番号のリストが存在しなければ追加
                    FrePSalesSlipParaWork.FrePSalesSlipParaKey key = CreateSalesSlipKey(frePSalesDetailWork);
                    if (!detailListDic.ContainsKey(key))
                    {
                        detailListDic.Add(key, new List<FrePSalesDetailWork>());
                    }
                    // レコード追加
                    detailListDic[key].Add(frePSalesDetailWork);
                }

                if (detailListDic.Count > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                retObj = detailListDic;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SearchProc\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }
            return status;
        }

        /// <summary>
        /// 受注マスタ（車輌）のjoin条件
        /// </summary>
        /// <returns></returns>
        /// <br>Note		: 売上明細データの伝票情報が取得できない場合は、売上履歴明細データを読み込んで伝票情報を取得するようにする。</br>
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2010/06/08</br>
        private string GetAcceptOdrCarJoinCndtnForHistory()
        {
            // "SALESDETAILRF"  : 10:見積,20:受注,30:売上,40:出荷,70:指示書,80:クレーム,99:一時保管  
            // "ACCEPTODRCARRF" : 1:見積 2:発注 3:受注 4:入荷 5:出荷 6:仕入 7:売上 8:返品 9:入金 10:支払
            StringBuilder text = new StringBuilder();
            text.Append(" (");
            // 見積
            text.Append(" SALESHISTDTLRF.ACPTANODRSTATUSRF='10' AND ACCEPTODRCARRF.ACPTANODRSTATUSRF='1' ");
            // 受注
            text.Append("OR");
            text.Append(" SALESHISTDTLRF.ACPTANODRSTATUSRF='20' AND ACCEPTODRCARRF.ACPTANODRSTATUSRF='3' ");
            // 売上
            text.Append("OR");
            text.Append(" SALESHISTDTLRF.ACPTANODRSTATUSRF='30' AND ACCEPTODRCARRF.ACPTANODRSTATUSRF='7' ");
            // 出荷
            text.Append("OR");
            text.Append(" SALESHISTDTLRF.ACPTANODRSTATUSRF='40' AND ACCEPTODRCARRF.ACPTANODRSTATUSRF='5' ");
            text.Append(")");
            return text.ToString();
        }
        # endregion

        // -------ADD 2010/06/08-------<<<<<

        # region [見積書補足情報抽出]
        /// <summary>
        /// Search 見積書補足情報
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="retObj"></param>
        /// <param name="sqlConnection"></param>
        /// <remarks>※売上伝票のソースを一部変更して作成</remarks>
        private int SearchProcOfEstFm(FrePEstFmParaWork extPrm, ref List<FrePSalesSlipWork> retObj, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            List<FrePSalesSlipWork> frePSalesSlipWorkList = new List<FrePSalesSlipWork>();
            retObj = null;

            try
            {
                //-------------------------------------------------------------------
                // 対象テーブル
                //   自社情報マスタ       CompanyInfRF
                //   拠点情報設定マスタ   SecInfoSetRF       
                //     自社名称マスタ       CompanyNmRF
                //       画像情報マスタ       ImageInfoRF
                //-------------------------------------------------------------------
                SqlCommand sqlCommand = new SqlCommand("SELECT " + this.GetSelectItemsForEstFm(extPrm)
                    + Environment.NewLine
                    + " FROM COMPANYINFRF " + Environment.NewLine
                    + LeftJoin("COMPANYINFRF", "SECINFOSETRF", string.Empty, new string[] { }, new string[] { })  // 企業cd
                    + LeftJoin("SECINFOSETRF", "COMPANYNMRF", string.Empty, new string[] { }, new string[] { "SECINFOSETRF.COMPANYNAMECD1RF=COMPANYNMRF.COMPANYNAMECDRF" })    // 企業cd,自社名称cd
                    + LeftJoin("COMPANYNMRF", "IMAGEINFORF", string.Empty, new string[] { "IMAGEINFOCODERF" }, new string[] { "IMAGEINFORF.IMAGEINFODIVRF='10'" })    // 企業cd,画像情報cd,区分=10
                    , sqlConnection);

                // WHERE文を生成
                sqlCommand.CommandText += MakeWhereStringForEstFm(ref sqlCommand, extPrm);
                // タイムアウト時間設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    FrePSalesSlipWork frePSalesSlipWork = new FrePSalesSlipWork();

                    # region [データのコピー]
                    frePSalesSlipWork.SECINFOSETRF_SECTIONGUIDENMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                    frePSalesSlipWork.SECINFOSETRF_SECTIONGUIDESNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    frePSalesSlipWork.SECINFOSETRF_COMPANYNAMECD1RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYNAMECD1RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYPRRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYPRRF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYNAME1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYNAME1RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYNAME2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYNAME2RF"));
                    frePSalesSlipWork.COMPANYNMRF_POSTNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSTNORF"));
                    frePSalesSlipWork.COMPANYNMRF_ADDRESS1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS1RF"));
                    frePSalesSlipWork.COMPANYNMRF_ADDRESS3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS3RF"));
                    frePSalesSlipWork.COMPANYNMRF_ADDRESS4RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS4RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYTELNO1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO1RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYTELNO2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO2RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYTELNO3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO3RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYTELTITLE1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE1RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYTELTITLE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE2RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYTELTITLE3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE3RF"));
                    frePSalesSlipWork.COMPANYNMRF_TRANSFERGUIDANCERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRANSFERGUIDANCERF"));
                    frePSalesSlipWork.COMPANYNMRF_ACCOUNTNOINFO1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO1RF"));
                    frePSalesSlipWork.COMPANYNMRF_ACCOUNTNOINFO2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO2RF"));
                    frePSalesSlipWork.COMPANYNMRF_ACCOUNTNOINFO3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO3RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYSETNOTE1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYSETNOTE1RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYSETNOTE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYSETNOTE2RF"));
                    frePSalesSlipWork.COMPANYNMRF_IMAGEINFODIVRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IMAGEINFODIVRF"));
                    frePSalesSlipWork.COMPANYNMRF_IMAGEINFOCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IMAGEINFOCODERF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYURLRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYURLRF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYPRSENTENCE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYPRSENTENCE2RF"));
                    frePSalesSlipWork.COMPANYNMRF_IMAGECOMMENTFORPRT1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IMAGECOMMENTFORPRT1RF"));
                    frePSalesSlipWork.COMPANYNMRF_IMAGECOMMENTFORPRT2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IMAGECOMMENTFORPRT2RF"));
                    frePSalesSlipWork.IMAGEINFORF_IMAGEINFODATARF = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("IMAGEINFODATARF"));
                    frePSalesSlipWork.COMPANYINFRF_COMPANYNAME1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFCOMPANYNAME1RF"));
                    frePSalesSlipWork.COMPANYINFRF_COMPANYNAME2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFCOMPANYNAME2RF"));
                    frePSalesSlipWork.COMPANYINFRF_POSTNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFPOSTNORF"));
                    frePSalesSlipWork.COMPANYINFRF_ADDRESS1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFADDRESS1RF"));
                    frePSalesSlipWork.COMPANYINFRF_ADDRESS3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFADDRESS3RF"));
                    frePSalesSlipWork.COMPANYINFRF_ADDRESS4RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFADDRESS4RF"));
                    frePSalesSlipWork.COMPANYINFRF_COMPANYTELNO1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFCOMPANYTELNO1RF"));
                    frePSalesSlipWork.COMPANYINFRF_COMPANYTELNO2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFCOMPANYTELNO2RF"));
                    frePSalesSlipWork.COMPANYINFRF_COMPANYTELNO3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFCOMPANYTELNO3RF"));
                    frePSalesSlipWork.COMPANYINFRF_COMPANYTELTITLE1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFCOMPANYTELTITLE1RF"));
                    frePSalesSlipWork.COMPANYINFRF_COMPANYTELTITLE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFCOMPANYTELTITLE2RF"));
                    frePSalesSlipWork.COMPANYINFRF_COMPANYTELTITLE3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFCOMPANYTELTITLE3RF"));
                    # endregion

                    frePSalesSlipWorkList.Add(frePSalesSlipWork);
                }

                if (frePSalesSlipWorkList.Count > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                retObj = frePSalesSlipWorkList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SearchProc\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }
            return status;
        }
        /// <summary>
        /// 抽出項目名取得処理（見積書用）
        /// </summary>
        /// <param name="extPrm"></param>
        /// <returns></returns>
        /// <remarks>※売上伝票のソースを一部変更して作成</remarks>
        private string GetSelectItemsForEstFm(FrePEstFmParaWork extPrm)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SECINFOSETRF.SECTIONCODERF," + Environment.NewLine); // ←売上伝票用との違い
            # region [項目名]
            sb.Append("SECINFOSETRF.SECTIONGUIDENMRF," + Environment.NewLine);
            sb.Append("SECINFOSETRF.SECTIONGUIDESNMRF," + Environment.NewLine);
            sb.Append("SECINFOSETRF.COMPANYNAMECD1RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYPRRF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYNAME1RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYNAME2RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.POSTNORF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.ADDRESS1RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.ADDRESS3RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.ADDRESS4RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYTELNO1RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYTELNO2RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYTELNO3RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYTELTITLE1RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYTELTITLE2RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYTELTITLE3RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.TRANSFERGUIDANCERF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.ACCOUNTNOINFO1RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.ACCOUNTNOINFO2RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.ACCOUNTNOINFO3RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYSETNOTE1RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYSETNOTE2RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.IMAGEINFODIVRF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.IMAGEINFOCODERF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYURLRF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYPRSENTENCE2RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.IMAGECOMMENTFORPRT1RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.IMAGECOMMENTFORPRT2RF," + Environment.NewLine);
            sb.Append("IMAGEINFORF.IMAGEINFODATARF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.COMPANYNAME1RF AS COMPANYINFRFCOMPANYNAME1RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.COMPANYNAME2RF AS COMPANYINFRFCOMPANYNAME2RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.POSTNORF AS COMPANYINFRFPOSTNORF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.ADDRESS1RF AS COMPANYINFRFADDRESS1RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.ADDRESS3RF AS COMPANYINFRFADDRESS3RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.ADDRESS4RF AS COMPANYINFRFADDRESS4RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.COMPANYTELNO1RF AS COMPANYINFRFCOMPANYTELNO1RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.COMPANYTELNO2RF AS COMPANYINFRFCOMPANYTELNO2RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.COMPANYTELNO3RF AS COMPANYINFRFCOMPANYTELNO3RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.COMPANYTELTITLE1RF AS COMPANYINFRFCOMPANYTELTITLE1RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.COMPANYTELTITLE2RF AS COMPANYINFRFCOMPANYTELTITLE2RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.COMPANYTELTITLE3RF AS COMPANYINFRFCOMPANYTELTITLE3RF");    //←最後はカンマなし
            # endregion
            return sb.ToString();
        }
        /// <summary>
        /// WHERE文作成処理
        /// </summary>
        /// <param name="sqlCommand">SQLコマンド</param>
        /// <param name="extPrm">自由帳票共通抽出条件クラス</param>
        /// <returns>WHERE文</returns>
        /// <remarks>※売上伝票のソースを一部変更して作成</remarks>
        private string MakeWhereStringForEstFm(ref SqlCommand sqlCommand, FrePEstFmParaWork extPrm)
        {
            StringBuilder whereString = new StringBuilder();

            // 企業コードは必須条件
            whereString.Append(" WHERE COMPANYINFRF.ENTERPRISECODERF=@FINDENTERPRISECODE ");
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findParaEnterpriseCode.Value = extPrm.EnterpriseCode;

            // 指定された拠点コードを条件にする
            whereString.Append(" AND SECINFOSETRF.SECTIONCODERF=@FINDSECTIONCODE ");
            SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
            findParaSectionCode.Value = extPrm.SectionCode;

            return whereString.ToString();
        }
        # endregion

        # region [ＵＯＥ伝票データ抽出]
        /// <summary>
        /// ＵＯＥ伝票ヘッダ抽出
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="slipWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int ReflectUOESlip(FrePUOESlipParaWork extPrm, ref FrePSalesSlipWork slipWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // 従業員
            status = ReflectUOESlipFromEmployee(extPrm, ref slipWork, ref sqlConnection);
            if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR) return status;

            // 得意先
            status = ReflectUOESlipFromCustomer(extPrm, ref slipWork, ref sqlConnection);
            if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR) return status;

            // 部門
            status = ReflectUOESlipFromSubSection(extPrm, ref slipWork, ref sqlConnection);
            if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR) return status;

            // 自社・拠点・自社名称・画像
            status = ReflectUOESlipFromCompany(extPrm, ref slipWork, ref sqlConnection);
            if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR) return status;

            // オートバックス設定
            status = ReflectUOEDetailFromSAndESetting(extPrm, ref slipWork, ref sqlConnection);  // ADD 2009.07.24 劉洋

            return status;
        }
        /// <summary>
        /// ＵＯＥ伝票抽出（従業員情報）
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="frePSalesSlipWork"></param>
        /// <param name="sqlConnection"></param>
        private int ReflectUOESlipFromEmployee(FrePUOESlipParaWork extPrm, ref FrePSalesSlipWork frePSalesSlipWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;

            try
            {
                // 発行者
                string salesInputCode = frePSalesSlipWork.SALESSLIPRF_SALESINPUTCODERF;
                // 受注者
                string frontEmployeeCd = frePSalesSlipWork.SALESSLIPRF_FRONTEMPLOYEECDRF;
                // 担当者
                string salesEmployeeCd = frePSalesSlipWork.SALESSLIPRF_SALESEMPLOYEECDRF;

                if (String.IsNullOrEmpty(salesInputCode) && String.IsNullOrEmpty(frontEmployeeCd) && String.IsNullOrEmpty(salesEmployeeCd))
                {
                    return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }


                //-------------------------------------------------------------------
                // 従業員
                //-------------------------------------------------------------------
                SqlCommand sqlCommand = new SqlCommand(
                    "SELECT * " + Environment.NewLine
                    + "FROM EMPLOYEERF " + Environment.NewLine
                    , sqlConnection);

                // 条件設定
                # region [WHERE]
                sqlCommand.CommandText += "WHERE " + Environment.NewLine;

                // 企業コード
                sqlCommand.CommandText += "ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine;
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = extPrm.EnterpriseCode;

                // 論理削除コード
                sqlCommand.CommandText += "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE " + Environment.NewLine;
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findParaLogicalDeleteCode.Value = 0;

                // 従業員コード
                sqlCommand.CommandText += "AND ( " + Environment.NewLine;
                // (発行者)
                if (!String.IsNullOrEmpty(salesInputCode))
                {
                    sqlCommand.CommandText += "EMPLOYEECODERF=@FINDSALESINPUTCODE " + Environment.NewLine;
                    SqlParameter findParaSalesInputCode = sqlCommand.Parameters.Add("@FINDSALESINPUTCODE", SqlDbType.NChar);
                    findParaSalesInputCode.Value = salesInputCode;
                }
                // (受注者)
                if (!string.IsNullOrEmpty(frontEmployeeCd))
                {
                    if (!String.IsNullOrEmpty(salesInputCode))
                    {
                        sqlCommand.CommandText += " OR ";
                    }
                    sqlCommand.CommandText += "EMPLOYEECODERF=@FINDFRONTEMPLOYEECD " + Environment.NewLine;
                    SqlParameter findParaFrontEmployeeCd = sqlCommand.Parameters.Add("@FINDFRONTEMPLOYEECD", SqlDbType.NChar);
                    findParaFrontEmployeeCd.Value = frontEmployeeCd;
                }
                // (担当者)
                if (!string.IsNullOrEmpty(salesEmployeeCd))
                {
                    if (!String.IsNullOrEmpty(salesInputCode) || !String.IsNullOrEmpty(frontEmployeeCd))
                    {
                        sqlCommand.CommandText += " OR ";
                    }
                    sqlCommand.CommandText += "EMPLOYEECODERF=@FINDSALESEMPLOYEECD " + Environment.NewLine;
                    SqlParameter findParaSalesEmployeeCd = sqlCommand.Parameters.Add("@FINDSALESEMPLOYEECD", SqlDbType.NChar);
                    findParaSalesEmployeeCd.Value = salesEmployeeCd;
                }
                sqlCommand.CommandText += ") " + Environment.NewLine;
                # endregion

                // タイムアウト時間設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    # region [データのコピー]
                    string employeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));

                    // (発行者)
                    if (employeeCode.Trim() == salesInputCode.Trim())
                    {
                        frePSalesSlipWork.EMPINP_KANARF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KANARF"));
                        frePSalesSlipWork.EMPINP_SHORTNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHORTNAMERF"));
                    }
                    // (受注者)
                    if (employeeCode.Trim() == frontEmployeeCd.Trim())
                    {
                        frePSalesSlipWork.EMPFRT_KANARF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KANARF"));
                        frePSalesSlipWork.EMPFRT_SHORTNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHORTNAMERF"));
                    }
                    // (担当者)
                    if (employeeCode.Trim() == salesEmployeeCd.Trim())
                    {
                        frePSalesSlipWork.EMPSAL_KANARF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KANARF"));
                        frePSalesSlipWork.EMPSAL_SHORTNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHORTNAMERF"));
                    }
                    # endregion

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SearchProc\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }
            return status;
        }
        /// <summary>
        /// ＵＯＥ伝票抽出（得意先情報）
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="frePSalesSlipWork"></param>
        /// <param name="sqlConnection"></param>
        private int ReflectUOESlipFromCustomer(FrePUOESlipParaWork extPrm, ref FrePSalesSlipWork frePSalesSlipWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;

            try
            {
                // 請求先
                int claimCode = frePSalesSlipWork.SALESSLIPRF_CLAIMCODERF;
                // 得意先
                int customerCode = frePSalesSlipWork.SALESSLIPRF_CUSTOMERCODERF;
                // 納入先
                int addresseeCode = frePSalesSlipWork.SALESSLIPRF_ADDRESSEECODERF;

                if (claimCode == 0 && customerCode == 0 && addresseeCode == 0)
                {
                    return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                //-------------------------------------------------------------------
                // 得意先
                //-------------------------------------------------------------------
                SqlCommand sqlCommand = new SqlCommand(
                    "SELECT * " + Environment.NewLine
                    + "FROM CUSTOMERRF " + Environment.NewLine
                    , sqlConnection);

                // 条件設定
                # region [WHERE]
                sqlCommand.CommandText += "WHERE " + Environment.NewLine;

                // 企業コード
                sqlCommand.CommandText += "ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine;
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = extPrm.EnterpriseCode;

                // 論理削除コード
                sqlCommand.CommandText += "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE " + Environment.NewLine;
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findParaLogicalDeleteCode.Value = 0;

                // 得意先コード
                sqlCommand.CommandText += "AND ( " + Environment.NewLine;
                // (請求先)
                if (claimCode != 0)
                {
                    sqlCommand.CommandText += "CUSTOMERCODERF=@FINDCLAIMCODE " + Environment.NewLine;
                    SqlParameter findParaClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                    findParaClaimCode.Value = claimCode;
                }
                // (得意先)
                if (customerCode != 0)
                {
                    if (claimCode != 0)
                    {
                        sqlCommand.CommandText += " OR ";
                    }
                    sqlCommand.CommandText += "CUSTOMERCODERF=@FINDCUSTOMERCODE " + Environment.NewLine;
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    findParaCustomerCode.Value = customerCode;
                }
                // (納入先)
                if (addresseeCode != 0)
                {
                    if (claimCode != 0 || customerCode != 0)
                    {
                        sqlCommand.CommandText += " OR ";
                    }
                    sqlCommand.CommandText += "CUSTOMERCODERF=@FINDADDRESSEECODE " + Environment.NewLine;
                    SqlParameter findParaAddresseeCode = sqlCommand.Parameters.Add("@FINDADDRESSEECODE", SqlDbType.Int);
                    findParaAddresseeCode.Value = addresseeCode;
                }
                sqlCommand.CommandText += ") " + Environment.NewLine;
                # endregion

                // タイムアウト時間設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    # region [データのコピー]

                    int code = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));

                    // (請求先)
                    if (code == claimCode)
                    {
                        frePSalesSlipWork.CSTCLM_CUSTOMERSUBCODERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSUBCODERF"));
                        frePSalesSlipWork.CSTCLM_NAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
                        frePSalesSlipWork.CSTCLM_NAME2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAME2RF"));
                        frePSalesSlipWork.CSTCLM_HONORIFICTITLERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));
                        frePSalesSlipWork.CSTCLM_KANARF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KANARF"));
                        frePSalesSlipWork.CSTCLM_CUSTOMERSNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                        frePSalesSlipWork.CSTCLM_OUTPUTNAMECODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OUTPUTNAMECODERF"));
                        frePSalesSlipWork.CSTCLM_CUSTANALYSCODE1RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE1RF"));
                        frePSalesSlipWork.CSTCLM_CUSTANALYSCODE2RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE2RF"));
                        frePSalesSlipWork.CSTCLM_CUSTANALYSCODE3RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE3RF"));
                        frePSalesSlipWork.CSTCLM_CUSTANALYSCODE4RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE4RF"));
                        frePSalesSlipWork.CSTCLM_CUSTANALYSCODE5RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE5RF"));
                        frePSalesSlipWork.CSTCLM_CUSTANALYSCODE6RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE6RF"));
                        frePSalesSlipWork.CSTCLM_NOTE1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE1RF"));
                        frePSalesSlipWork.CSTCLM_NOTE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE2RF"));
                        frePSalesSlipWork.CSTCLM_NOTE3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE3RF"));
                        frePSalesSlipWork.CSTCLM_NOTE4RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE4RF"));
                        frePSalesSlipWork.CSTCLM_NOTE5RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE5RF"));
                        frePSalesSlipWork.CSTCLM_NOTE6RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE6RF"));
                        frePSalesSlipWork.CSTCLM_NOTE7RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE7RF"));
                        frePSalesSlipWork.CSTCLM_NOTE8RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE8RF"));
                        frePSalesSlipWork.CSTCLM_NOTE9RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE9RF"));
                        frePSalesSlipWork.CSTCLM_NOTE10RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE10RF"));
                    }
                    // (得意先)
                    if (code == customerCode)
                    {
                        frePSalesSlipWork.CSTCST_CUSTOMERSUBCODERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSUBCODERF"));
                        frePSalesSlipWork.CSTCST_NAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
                        frePSalesSlipWork.CSTCST_NAME2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAME2RF"));
                        frePSalesSlipWork.CSTCST_HONORIFICTITLERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));
                        frePSalesSlipWork.CSTCST_KANARF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KANARF"));
                        frePSalesSlipWork.CSTCST_CUSTOMERSNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                        frePSalesSlipWork.CSTCST_OUTPUTNAMECODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OUTPUTNAMECODERF"));
                        frePSalesSlipWork.CSTCST_CUSTANALYSCODE1RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE1RF"));
                        frePSalesSlipWork.CSTCST_CUSTANALYSCODE2RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE2RF"));
                        frePSalesSlipWork.CSTCST_CUSTANALYSCODE3RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE3RF"));
                        frePSalesSlipWork.CSTCST_CUSTANALYSCODE4RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE4RF"));
                        frePSalesSlipWork.CSTCST_CUSTANALYSCODE5RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE5RF"));
                        frePSalesSlipWork.CSTCST_CUSTANALYSCODE6RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE6RF"));
                        frePSalesSlipWork.CSTCST_NOTE1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE1RF"));
                        frePSalesSlipWork.CSTCST_NOTE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE2RF"));
                        frePSalesSlipWork.CSTCST_NOTE3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE3RF"));
                        frePSalesSlipWork.CSTCST_NOTE4RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE4RF"));
                        frePSalesSlipWork.CSTCST_NOTE5RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE5RF"));
                        frePSalesSlipWork.CSTCST_NOTE6RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE6RF"));
                        frePSalesSlipWork.CSTCST_NOTE7RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE7RF"));
                        frePSalesSlipWork.CSTCST_NOTE8RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE8RF"));
                        frePSalesSlipWork.CSTCST_NOTE9RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE9RF"));
                        frePSalesSlipWork.CSTCST_NOTE10RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE10RF"));
                        // --- ADD m.suzuki 2010/03/24 ---------->>>>>
                        frePSalesSlipWork.CSTCST_QRCODEPRTCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "QRCODEPRTCDRF" ) );
                        // --- ADD m.suzuki 2010/03/24 ----------<<<<<
                    }
                    // (納入先)
                    if (code == addresseeCode)
                    {
                        frePSalesSlipWork.CSTADR_CUSTOMERSUBCODERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSUBCODERF"));
                        frePSalesSlipWork.CSTADR_NAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
                        frePSalesSlipWork.CSTADR_NAME2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAME2RF"));
                        frePSalesSlipWork.CSTADR_HONORIFICTITLERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));
                        frePSalesSlipWork.CSTADR_KANARF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KANARF"));
                        frePSalesSlipWork.CSTADR_CUSTOMERSNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                        frePSalesSlipWork.CSTADR_OUTPUTNAMECODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OUTPUTNAMECODERF"));
                        frePSalesSlipWork.CSTADR_CUSTANALYSCODE1RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE1RF"));
                        frePSalesSlipWork.CSTADR_CUSTANALYSCODE2RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE2RF"));
                        frePSalesSlipWork.CSTADR_CUSTANALYSCODE3RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE3RF"));
                        frePSalesSlipWork.CSTADR_CUSTANALYSCODE4RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE4RF"));
                        frePSalesSlipWork.CSTADR_CUSTANALYSCODE5RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE5RF"));
                        frePSalesSlipWork.CSTADR_CUSTANALYSCODE6RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE6RF"));
                        frePSalesSlipWork.CSTADR_NOTE1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE1RF"));
                        frePSalesSlipWork.CSTADR_NOTE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE2RF"));
                        frePSalesSlipWork.CSTADR_NOTE3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE3RF"));
                        frePSalesSlipWork.CSTADR_NOTE4RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE4RF"));
                        frePSalesSlipWork.CSTADR_NOTE5RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE5RF"));
                        frePSalesSlipWork.CSTADR_NOTE6RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE6RF"));
                        frePSalesSlipWork.CSTADR_NOTE7RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE7RF"));
                        frePSalesSlipWork.CSTADR_NOTE8RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE8RF"));
                        frePSalesSlipWork.CSTADR_NOTE9RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE9RF"));
                        frePSalesSlipWork.CSTADR_NOTE10RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE10RF"));
                    }

                    # endregion

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SearchProc\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }
            return status;
        }
        /// <summary>
        /// ＵＯＥ伝票抽出（部門情報）
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="frePSalesSlipWork"></param>
        /// <param name="sqlConnection"></param>
        private int ReflectUOESlipFromSubSection(FrePUOESlipParaWork extPrm, ref FrePSalesSlipWork frePSalesSlipWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;

            try
            {
                // 部門
                int subSectionCode = frePSalesSlipWork.SALESSLIPRF_SUBSECTIONCODERF;
                if (subSectionCode == 0)
                {
                    return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                //-------------------------------------------------------------------
                // 部門
                //-------------------------------------------------------------------
                SqlCommand sqlCommand = new SqlCommand(
                    "SELECT * " + Environment.NewLine
                    + "FROM SUBSECTIONRF " + Environment.NewLine
                    , sqlConnection);

                // 条件設定
                # region [WHERE]
                sqlCommand.CommandText += "WHERE " + Environment.NewLine;

                // 企業コード
                sqlCommand.CommandText += "ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine;
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = extPrm.EnterpriseCode;

                // 論理削除コード
                sqlCommand.CommandText += "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE " + Environment.NewLine;
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findParaLogicalDeleteCode.Value = 0;

                // 部門コード
                sqlCommand.CommandText += "AND SUBSECTIONCODERF=@FINDSUBSECTIONCODE " + Environment.NewLine;
                SqlParameter findParaSubSectionCode = sqlCommand.Parameters.Add("@FINDSUBSECTIONCODE", SqlDbType.Int);
                findParaSubSectionCode.Value = subSectionCode;

                # endregion

                // タイムアウト時間設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    # region [データのコピー]
                    int code = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
                    frePSalesSlipWork.SUBSECTIONRF_SUBSECTIONNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUBSECTIONNAMERF"));
                    # endregion

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SearchProc\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }
            return status;
        }
        /// <summary>
        /// ＵＯＥ伝票抽出（自社・拠点・自社名称・画像情報）
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="frePSalesSlipWork"></param>
        /// <param name="sqlConnection"></param>
        private int ReflectUOESlipFromCompany(FrePUOESlipParaWork extPrm, ref FrePSalesSlipWork frePSalesSlipWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;

            try
            {
                // 拠点コード（←実績計上拠点コードをセット）
                string sectionCode = frePSalesSlipWork.SALESSLIPRF_RESULTSADDUPSECCDRF;
                if (String.IsNullOrEmpty(sectionCode))
                {
                    return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                //-------------------------------------------------------------------
                // 対象テーブル
                //   自社情報マスタ       CompanyInfRF
                //   拠点情報設定マスタ   SecInfoSetRF       
                //     自社名称マスタ       CompanyNmRF
                //       画像情報マスタ       ImageInfoRF
                //-------------------------------------------------------------------
                SqlCommand sqlCommand = new SqlCommand(
                    "SELECT " + GetSelectItemsForUOESlip(extPrm) + Environment.NewLine
                    + " FROM COMPANYINFRF " + Environment.NewLine
                    + LeftJoin("COMPANYINFRF", "SECINFOSETRF", string.Empty, new string[] { }, new string[] { })  // 企業cd
                    + LeftJoin("SECINFOSETRF", "COMPANYNMRF", string.Empty, new string[] { }, new string[] { "SECINFOSETRF.COMPANYNAMECD1RF=COMPANYNMRF.COMPANYNAMECDRF" })    // 企業cd,自社名称cd
                    + LeftJoin("COMPANYNMRF", "IMAGEINFORF", string.Empty, new string[] { "IMAGEINFOCODERF" }, new string[] { "IMAGEINFORF.IMAGEINFODIVRF='10'" })    // 企業cd,画像情報cd,区分=10
                    , sqlConnection);

                // 条件設定
                # region [WHERE]
                sqlCommand.CommandText += "WHERE " + Environment.NewLine;

                // 企業コード
                sqlCommand.CommandText += "COMPANYINFRF.ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine;
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = extPrm.EnterpriseCode;

                // 論理削除コード
                sqlCommand.CommandText += "AND COMPANYINFRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE " + Environment.NewLine;
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findParaLogicalDeleteCode.Value = 0;

                // 拠点コード
                sqlCommand.CommandText += "AND SECINFOSETRF.SECTIONCODERF=@FINDSECTIONCODE " + Environment.NewLine;
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                findParaSectionCode.Value = sectionCode;
                # endregion

                // タイムアウト時間設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    # region [データのコピー]
                    frePSalesSlipWork.SECINFOSETRF_SECTIONGUIDENMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                    frePSalesSlipWork.SECINFOSETRF_SECTIONGUIDESNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    frePSalesSlipWork.SECINFOSETRF_COMPANYNAMECD1RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYNAMECD1RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYPRRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYPRRF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYNAME1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYNAME1RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYNAME2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYNAME2RF"));
                    frePSalesSlipWork.COMPANYNMRF_POSTNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSTNORF"));
                    frePSalesSlipWork.COMPANYNMRF_ADDRESS1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS1RF"));
                    frePSalesSlipWork.COMPANYNMRF_ADDRESS3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS3RF"));
                    frePSalesSlipWork.COMPANYNMRF_ADDRESS4RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS4RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYTELNO1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO1RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYTELNO2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO2RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYTELNO3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO3RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYTELTITLE1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE1RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYTELTITLE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE2RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYTELTITLE3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE3RF"));
                    frePSalesSlipWork.COMPANYNMRF_TRANSFERGUIDANCERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRANSFERGUIDANCERF"));
                    frePSalesSlipWork.COMPANYNMRF_ACCOUNTNOINFO1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO1RF"));
                    frePSalesSlipWork.COMPANYNMRF_ACCOUNTNOINFO2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO2RF"));
                    frePSalesSlipWork.COMPANYNMRF_ACCOUNTNOINFO3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO3RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYSETNOTE1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYSETNOTE1RF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYSETNOTE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYSETNOTE2RF"));
                    frePSalesSlipWork.COMPANYNMRF_IMAGEINFODIVRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IMAGEINFODIVRF"));
                    frePSalesSlipWork.COMPANYNMRF_IMAGEINFOCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IMAGEINFOCODERF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYURLRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYURLRF"));
                    frePSalesSlipWork.COMPANYNMRF_COMPANYPRSENTENCE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYPRSENTENCE2RF"));
                    frePSalesSlipWork.COMPANYNMRF_IMAGECOMMENTFORPRT1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IMAGECOMMENTFORPRT1RF"));
                    frePSalesSlipWork.COMPANYNMRF_IMAGECOMMENTFORPRT2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IMAGECOMMENTFORPRT2RF"));
                    frePSalesSlipWork.IMAGEINFORF_IMAGEINFODATARF = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("IMAGEINFODATARF"));
                    frePSalesSlipWork.COMPANYINFRF_COMPANYNAME1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFCOMPANYNAME1RF"));
                    frePSalesSlipWork.COMPANYINFRF_COMPANYNAME2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFCOMPANYNAME2RF"));
                    frePSalesSlipWork.COMPANYINFRF_POSTNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFPOSTNORF"));
                    frePSalesSlipWork.COMPANYINFRF_ADDRESS1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFADDRESS1RF"));
                    frePSalesSlipWork.COMPANYINFRF_ADDRESS3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFADDRESS3RF"));
                    frePSalesSlipWork.COMPANYINFRF_ADDRESS4RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFADDRESS4RF"));
                    frePSalesSlipWork.COMPANYINFRF_COMPANYTELNO1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFCOMPANYTELNO1RF"));
                    frePSalesSlipWork.COMPANYINFRF_COMPANYTELNO2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFCOMPANYTELNO2RF"));
                    frePSalesSlipWork.COMPANYINFRF_COMPANYTELNO3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFCOMPANYTELNO3RF"));
                    frePSalesSlipWork.COMPANYINFRF_COMPANYTELTITLE1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFCOMPANYTELTITLE1RF"));
                    frePSalesSlipWork.COMPANYINFRF_COMPANYTELTITLE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFCOMPANYTELTITLE2RF"));
                    frePSalesSlipWork.COMPANYINFRF_COMPANYTELTITLE3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYINFRFCOMPANYTELTITLE3RF"));
                    # endregion

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SearchProc\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }
            return status;
        }

        // --- ADD 2009.07.24 劉洋 ------ >>>>>>
        /// <summary>
        /// ＵＯＥ伝票抽出（オートバックス設定）
        /// </summary>
        /// <param name="extPrm">データ</param>
        /// <param name="frePSalesSlipWork">売上情報</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <remarks>
        /// <br>Note       : オートバックス情報検索</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.07.24</br>
        /// </remarks>	
        private int ReflectUOEDetailFromSAndESetting(FrePUOESlipParaWork extPrm, ref FrePSalesSlipWork frePSalesSlipWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;

            try
            {
                // 得意先コード
                int customerCode = frePSalesSlipWork.SALESSLIPRF_CUSTOMERCODERF;
                // 拠点コード
                string sectionCode = frePSalesSlipWork.SALESSLIPRF_RESULTSADDUPSECCDRF;

                SqlCommand sqlCommand = new SqlCommand(
                    "SELECT * " + Environment.NewLine
                    + " FROM SANDESETTINGRF " + Environment.NewLine
                    , sqlConnection);

                // 条件設定
                # region [WHERE]
                sqlCommand.CommandText += "WHERE " + Environment.NewLine;

                // 企業コード
                sqlCommand.CommandText += "SANDESETTINGRF.ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine;
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = extPrm.EnterpriseCode;

                // 論理削除コード
                sqlCommand.CommandText += "AND SANDESETTINGRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE " + Environment.NewLine;
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findParaLogicalDeleteCode.Value = 0;

                // 得意先コード
                sqlCommand.CommandText += "AND SANDESETTINGRF.CUSTOMERCODERF=@FINDCUSTOMERCODE " + Environment.NewLine;
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                findParaCustomerCode.Value = customerCode;

                // 拠点コード
                sqlCommand.CommandText += "AND SANDESETTINGRF.SECTIONCODERF=@FINDSECTIONCODE " + Environment.NewLine;
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                findParaSectionCode.Value = sectionCode;
                # endregion

                // タイムアウト時間設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    # region [データのコピー]
                    frePSalesSlipWork.SANDESETTINGRF_CUSTOMERCODE = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    frePSalesSlipWork.SANDESETTINGRF_ADDRESSEESHOPCD = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEESHOPCDRF"));
                    frePSalesSlipWork.SANDESETTINGRF_SANDEMNGCODE = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SANDEMNGCODERF"));
                    frePSalesSlipWork.SANDESETTINGRF_EXPENSEDIVCD = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EXPENSEDIVCDRF"));
                    frePSalesSlipWork.SANDESETTINGRF_DIRECTSENDINGCD = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DIRECTSENDINGCDRF"));
                    frePSalesSlipWork.SANDESETTINGRF_ACPTANORDERDIV = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANORDERDIVRF"));
                    frePSalesSlipWork.SANDESETTINGRF_DELIVERERCD = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIVERERCDRF"));
                    frePSalesSlipWork.SANDESETTINGRF_DELIVERERNM = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIVERERNMRF"));
                    frePSalesSlipWork.SANDESETTINGRF_DELIVERERADDRESS = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIVERERADDRESSRF"));
                    frePSalesSlipWork.SANDESETTINGRF_DELIVERERPHONENUM = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIVERERPHONENUMRF"));
                    frePSalesSlipWork.SANDESETTINGRF_TRADCOMPNAME = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRADCOMPNAMERF"));
                    frePSalesSlipWork.SANDESETTINGRF_TRADCOMPSECTNAME = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRADCOMPSECTNAMERF"));
                    frePSalesSlipWork.SANDESETTINGRF_PURETRADCOMPCD = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PURETRADCOMPCDRF"));
                    frePSalesSlipWork.SANDESETTINGRF_PURETRADCOMPRATE = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PURETRADCOMPRATERF"));
                    frePSalesSlipWork.SANDESETTINGRF_PRITRADCOMPCD = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRITRADCOMPCDRF"));
                    frePSalesSlipWork.SANDESETTINGRF_PRITRADCOMPRATE = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRITRADCOMPRATERF"));
                    frePSalesSlipWork.SANDESETTINGRF_ABGOODSCODE = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ABGOODSCODERF"));
                    frePSalesSlipWork.SANDESETTINGRF_COMMENTRESERVEDDIV = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMMENTRESERVEDDIVRF"));
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD1RF"));
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD2RF"));
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD3RF"));
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD4RF"));
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD5RF"));
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD6RF"));
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD7 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD7RF"));
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD8 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD8RF"));
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD9 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD9RF"));
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD10 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD10RF"));
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD11 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD11RF"));
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD12 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD12RF"));
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD13 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD13RF"));
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD14 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD14RF"));
                    frePSalesSlipWork.SANDESETTINGRF_GOODSMAKERCD15 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD15RF"));
                    frePSalesSlipWork.SANDESETTINGRF_PARTSOEMDIV = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSOEMDIVRF"));

                    # endregion

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ReflectUOEDetailFromSAndESetting\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }
            return status;
        }
        // --- ADD 2009.07.24 劉洋 ------ <<<<<<

        /// <summary>
        /// 抽出項目名取得処理（ＵＯＥ伝票用）
        /// </summary>
        /// <param name="extPrm"></param>
        /// <returns></returns>
        /// <remarks>※売上伝票のソースを一部変更して作成</remarks>
        private string GetSelectItemsForUOESlip(FrePUOESlipParaWork extPrm)
        {
            StringBuilder sb = new StringBuilder();
            # region [項目名]
            sb.Append("SECINFOSETRF.SECTIONGUIDENMRF," + Environment.NewLine);
            sb.Append("SECINFOSETRF.SECTIONGUIDESNMRF," + Environment.NewLine);
            sb.Append("SECINFOSETRF.COMPANYNAMECD1RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYPRRF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYNAME1RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYNAME2RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.POSTNORF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.ADDRESS1RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.ADDRESS3RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.ADDRESS4RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYTELNO1RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYTELNO2RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYTELNO3RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYTELTITLE1RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYTELTITLE2RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYTELTITLE3RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.TRANSFERGUIDANCERF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.ACCOUNTNOINFO1RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.ACCOUNTNOINFO2RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.ACCOUNTNOINFO3RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYSETNOTE1RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYSETNOTE2RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.IMAGEINFODIVRF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.IMAGEINFOCODERF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYURLRF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYPRSENTENCE2RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.IMAGECOMMENTFORPRT1RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.IMAGECOMMENTFORPRT2RF," + Environment.NewLine);
            sb.Append("IMAGEINFORF.IMAGEINFODATARF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.COMPANYNAME1RF AS COMPANYINFRFCOMPANYNAME1RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.COMPANYNAME2RF AS COMPANYINFRFCOMPANYNAME2RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.POSTNORF AS COMPANYINFRFPOSTNORF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.ADDRESS1RF AS COMPANYINFRFADDRESS1RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.ADDRESS3RF AS COMPANYINFRFADDRESS3RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.ADDRESS4RF AS COMPANYINFRFADDRESS4RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.COMPANYTELNO1RF AS COMPANYINFRFCOMPANYTELNO1RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.COMPANYTELNO2RF AS COMPANYINFRFCOMPANYTELNO2RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.COMPANYTELNO3RF AS COMPANYINFRFCOMPANYTELNO3RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.COMPANYTELTITLE1RF AS COMPANYINFRFCOMPANYTELTITLE1RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.COMPANYTELTITLE2RF AS COMPANYINFRFCOMPANYTELTITLE2RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.COMPANYTELTITLE3RF AS COMPANYINFRFCOMPANYTELTITLE3RF " + Environment.NewLine); // ←最後の項目はカンマなし
            # endregion
            return sb.ToString();
        }
        # endregion

        # region [ＵＯＥ伝票明細データ抽出]
        /// <summary>
        /// ＵＯＥ伝票明細抽出
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="detailWork"></param>
        /// <param name="sqlConnection"></param>
        /// <br>Update Note :   2020/03/18 寺田義啓</br>
        /// <br>管理番号    :   11670121-00 S＆E改良対応</br>
        /// <returns></returns>
        private int ReflectUOEDetail(FrePUOESlipParaWork extPrm, ref FrePSalesDetailWork detailWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // メーカー
            status = ReflectUOEDetailFromMakerU(extPrm, ref detailWork, ref sqlConnection);
            if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR) return status;

            // ＢＬ商品コード
            status = ReflectUOEDetailFromBLGoodsCdU(extPrm, ref detailWork, ref sqlConnection);
            if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR) return status;

            // 仕入先
            status = ReflectUOEDetailFromSupplier(extPrm, ref detailWork, ref sqlConnection);
            if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR) return status;

            // ユーザーガイド
            // 2010/06/21 Del >>>
            //status = ReflectUOEDetailFromUserGdBdU(extPrm, ref detailWork, ref sqlConnection);
            //if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR) return status;
            // 2010/06/21 Del <<<

            // 商品・在庫・倉庫
            status = ReflectUOEDetailFromGoods(extPrm, ref detailWork, ref sqlConnection);
            if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR) return status;

            // 受注マスタ(車両)
            status = ReflectUOEDetailFromCar(extPrm, ref detailWork, ref sqlConnection);
            if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR) return status;

            // --- UPD 寺田義啓 2020.03.18 ---------->>>>>
            //// --- ADD 2009.07.24 劉洋 ------ >>>>>>
            //// オートバックス商品コード変換マスタ
            //status = ReflectUOEDetailFromSAndEGoodsCdChg(extPrm, ref detailWork, ref sqlConnection);
            //if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR) return status;
            //// --- ADD 2009.07.24 劉洋 ------ <<<<<<
            // メーカー・品番S＆E商品コード変換マスタ
            status = ReflectUOEDetailFromSAndEMkrGdsCdChg(extPrm, ref detailWork, ref sqlConnection);
            if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR) return status;
            if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                // オートバックス商品コード変換マスタ
                status = ReflectUOEDetailFromSAndEGoodsCdChg(extPrm, ref detailWork, ref sqlConnection);
                if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR) return status;
            }
            // --- UPD 寺田義啓 2020.03.18 ----------<<<<<

            return status;
        }
        /// <summary>
        /// ＵＯＥ伝票明細抽出（メーカー情報）
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="frePSalesDetailWork"></param>
        /// <param name="sqlConnection"></param>
        private int ReflectUOEDetailFromMakerU(FrePUOESlipParaWork extPrm, ref FrePSalesDetailWork frePSalesDetailWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;

            try
            {
                // メーカー
                int goodsMakerCd = frePSalesDetailWork.SALESDETAILRF_GOODSMAKERCDRF;
                // 一式メーカー
                int cmpltGoodsMakerCd = frePSalesDetailWork.SALESDETAILRF_CMPLTGOODSMAKERCDRF;
                // 印刷メーカー
                int prtMakerCode = frePSalesDetailWork.SALESDETAILRF_PRTMAKERCODERF;

                if (goodsMakerCd == 0 && cmpltGoodsMakerCd == 0 && prtMakerCode == 0)
                {
                    return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                //-------------------------------------------------------------------
                // メーカー
                //-------------------------------------------------------------------
                SqlCommand sqlCommand = new SqlCommand(
                    "SELECT * " + Environment.NewLine
                    + "FROM MAKERURF " + Environment.NewLine
                    , sqlConnection);

                // 条件設定
                # region [WHERE]
                sqlCommand.CommandText += "WHERE " + Environment.NewLine;

                // 企業コード
                sqlCommand.CommandText += "ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine;
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = extPrm.EnterpriseCode;

                // 論理削除コード
                sqlCommand.CommandText += "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE " + Environment.NewLine;
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findParaLogicalDeleteCode.Value = 0;

                // メーカーコード
                sqlCommand.CommandText += "AND ( " + Environment.NewLine;
                // (メーカー)
                if (goodsMakerCd != 0)
                {
                    sqlCommand.CommandText += "GOODSMAKERCDRF=@FINDGOODSMAKERCD " + Environment.NewLine;
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    findParaGoodsMakerCd.Value = goodsMakerCd;
                }
                // (一式メーカー)
                if (cmpltGoodsMakerCd != 0)
                {
                    if (goodsMakerCd != 0)
                    {
                        sqlCommand.CommandText += " OR ";
                    }
                    sqlCommand.CommandText += "GOODSMAKERCDRF=@FINDCMPLTGOODSMAKERCD " + Environment.NewLine;
                    SqlParameter findParaCmpltGoodsMakerCd = sqlCommand.Parameters.Add("@FINDCMPLTGOODSMAKERCD", SqlDbType.Int);
                    findParaCmpltGoodsMakerCd.Value = cmpltGoodsMakerCd;
                }
                // (印刷メーカー)
                if (prtMakerCode != 0)
                {
                    if (goodsMakerCd != 0 || cmpltGoodsMakerCd != 0)
                    {
                        sqlCommand.CommandText += " OR ";
                    }
                    sqlCommand.CommandText += "GOODSMAKERCDRF=@FINDPRTMAKERCODE " + Environment.NewLine;
                    SqlParameter findParaPrtMakerCode = sqlCommand.Parameters.Add("@FINDPRTMAKERCODE", SqlDbType.Int);
                    findParaPrtMakerCode.Value = prtMakerCode;
                }
                sqlCommand.CommandText += ") " + Environment.NewLine;
                # endregion

                // タイムアウト時間設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    # region [データのコピー]
                    int code = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));

                    if (code == goodsMakerCd)
                    {
                        frePSalesDetailWork.MAKGDS_MAKERSHORTNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERSHORTNAMERF"));
                        frePSalesDetailWork.MAKGDS_MAKERKANANAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERKANANAMERF"));
                        frePSalesDetailWork.MAKGDS_GOODSMAKERCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    }
                    if (code == cmpltGoodsMakerCd)
                    {
                        frePSalesDetailWork.MAKCMP_MAKERSHORTNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERSHORTNAMERF"));
                        frePSalesDetailWork.MAKCMP_MAKERKANANAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERKANANAMERF"));
                        frePSalesDetailWork.MAKCMP_GOODSMAKERCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    }
                    if (code == prtMakerCode)
                    {
                        frePSalesDetailWork.MAKPRT_MAKERKANANAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERKANANAMERF"));
                    }
                    # endregion

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SearchProc\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }
            return status;
        }
        /// <summary>
        /// ＵＯＥ伝票明細抽出（ＢＬ商品コード情報）
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="frePSalesDetailWork"></param>
        /// <param name="sqlConnection"></param>
        private int ReflectUOEDetailFromBLGoodsCdU(FrePUOESlipParaWork extPrm, ref FrePSalesDetailWork frePSalesDetailWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;

            try
            {
                // ＢＬコード
                int blGoodsCode = frePSalesDetailWork.SALESDETAILRF_BLGOODSCODERF;

                if (blGoodsCode == 0)
                {
                    return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                //-------------------------------------------------------------------
                // ＢＬコード
                //-------------------------------------------------------------------
                SqlCommand sqlCommand = new SqlCommand(
                    "SELECT * " + Environment.NewLine
                    + "FROM BLGOODSCDURF " + Environment.NewLine
                    , sqlConnection);

                // 条件設定
                # region [WHERE]
                sqlCommand.CommandText += "WHERE " + Environment.NewLine;

                // 企業コード
                sqlCommand.CommandText += "ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine;
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = extPrm.EnterpriseCode;

                // 論理削除コード
                sqlCommand.CommandText += "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE " + Environment.NewLine;
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findParaLogicalDeleteCode.Value = 0;

                // ＢＬ商品コード
                sqlCommand.CommandText += "AND BLGOODSCODERF=@FINDBLGOODSCODE " + Environment.NewLine;
                SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                findParaBLGoodsCode.Value = blGoodsCode;
                # endregion

                // タイムアウト時間設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    # region [データのコピー]
                    int code = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));

                    if (code == blGoodsCode)
                    {
                        frePSalesDetailWork.BLGOODSCDURF_BLGOODSCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                        frePSalesDetailWork.BLGOODSCDURF_BLGOODSHALFNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
                    }
                    # endregion

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SearchProc\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }
            return status;
        }
        /// <summary>
        /// ＵＯＥ伝票明細抽出（仕入先情報）
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="frePSalesDetailWork"></param>
        /// <param name="sqlConnection"></param>
        private int ReflectUOEDetailFromSupplier(FrePUOESlipParaWork extPrm, ref FrePSalesDetailWork frePSalesDetailWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;

            try
            {
                // 仕入先
                int supplierCd = frePSalesDetailWork.SALESDETAILRF_BLGOODSCODERF;

                if (supplierCd == 0)
                {
                    return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                //-------------------------------------------------------------------
                // 仕入先
                //-------------------------------------------------------------------
                SqlCommand sqlCommand = new SqlCommand(
                    "SELECT * " + Environment.NewLine
                    + "FROM SUPPLIERRF " + Environment.NewLine
                    , sqlConnection);

                // 条件設定
                # region [WHERE]
                sqlCommand.CommandText += "WHERE " + Environment.NewLine;

                // 企業コード
                sqlCommand.CommandText += "ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine;
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = extPrm.EnterpriseCode;

                // 論理削除コード
                sqlCommand.CommandText += "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE " + Environment.NewLine;
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findParaLogicalDeleteCode.Value = 0;

                // 仕入先コード
                sqlCommand.CommandText += "AND SUPPLIERCDRF=@FINDSUPPLIERCD " + Environment.NewLine;
                SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                findParaSupplierCd.Value = supplierCd;
                # endregion

                // タイムアウト時間設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    # region [データのコピー]
                    int code = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));

                    if (code == supplierCd)
                    {
                        frePSalesDetailWork.SUPPLIERRF_SUPPLIERCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                        frePSalesDetailWork.SUPPLIERRF_SUPPLIERNM1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
                        frePSalesDetailWork.SUPPLIERRF_SUPPLIERNM2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
                        frePSalesDetailWork.SUPPLIERRF_SUPPHONORIFICTITLERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPHONORIFICTITLERF"));
                        frePSalesDetailWork.SUPPLIERRF_SUPPLIERKANARF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERKANARF"));
                        frePSalesDetailWork.SUPPLIERRF_PURECODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PURECODERF"));
                        frePSalesDetailWork.SUPPLIERRF_SUPPLIERNOTE1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNOTE1RF"));
                        frePSalesDetailWork.SUPPLIERRF_SUPPLIERNOTE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNOTE2RF"));
                        frePSalesDetailWork.SUPPLIERRF_SUPPLIERNOTE3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNOTE3RF"));
                        frePSalesDetailWork.SUPPLIERRF_SUPPLIERNOTE4RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNOTE4RF"));
                    }
                    # endregion

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SearchProc\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }
            return status;
        }
        /// <summary>
        /// ＵＯＥ伝票明細抽出（ユーザーガイド情報）
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="frePSalesDetailWork"></param>
        /// <param name="sqlConnection"></param>
        private int ReflectUOEDetailFromUserGdBdU(FrePUOESlipParaWork extPrm, ref FrePSalesDetailWork frePSalesDetailWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;

            try
            {
                // ユーザーガイド
                // (43:得意先掛率グループコード)
                int custRateGrpCodeDiv = 43;
                int custRateGrpCode = frePSalesDetailWork.SALESDETAILRF_CUSTRATEGRPCODERF;

                if (custRateGrpCode == 0)
                {
                    return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                //-------------------------------------------------------------------
                // ユーザーガイド
                //-------------------------------------------------------------------
                SqlCommand sqlCommand = new SqlCommand(
                    "SELECT * " + Environment.NewLine
                    + "FROM SUPPLIERRF " + Environment.NewLine
                    , sqlConnection);

                // 条件設定
                # region [WHERE]
                sqlCommand.CommandText += "WHERE " + Environment.NewLine;

                // 企業コード
                sqlCommand.CommandText += "ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine;
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = extPrm.EnterpriseCode;

                // 論理削除コード
                sqlCommand.CommandText += "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE " + Environment.NewLine;
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findParaLogicalDeleteCode.Value = 0;

                // 得意先掛率グループコード
                sqlCommand.CommandText += "AND (USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD1 AND GUIDECODERF=@FINDGUIDECODE1) " + Environment.NewLine;
                SqlParameter findParaUserGuideDivCd1 = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD1", SqlDbType.Int);
                findParaUserGuideDivCd1.Value = custRateGrpCodeDiv;
                SqlParameter findParaGuideCode1 = sqlCommand.Parameters.Add("@FINDGUIDECODE1", SqlDbType.Int);
                findParaGuideCode1.Value = custRateGrpCode;
                # endregion

                // タイムアウト時間設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    # region [データのコピー]
                    int div = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERGUIDEDIVCDRF"));
                    int code = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GUIDECODERF"));

                    if (div == custRateGrpCodeDiv && code == custRateGrpCode)
                    {
                        frePSalesDetailWork.USRCSG_GUIDENAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("USRCSGGUIDENAMERF"));
                    }
                    # endregion

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SearchProc\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }
            return status;
        }
        /// <summary>
        /// ＵＯＥ伝票明細抽出（商品・在庫・倉庫情報）
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="frePSalesDetailWork"></param>
        /// <param name="sqlConnection"></param>
        private int ReflectUOEDetailFromGoods(FrePUOESlipParaWork extPrm, ref FrePSalesDetailWork frePSalesDetailWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;

            try
            {
                // 品番
                string goodsNo = frePSalesDetailWork.SALESDETAILRF_GOODSNORF;
                // メーカー
                int goodsMakerCd = frePSalesDetailWork.SALESDETAILRF_GOODSMAKERCDRF;
                // 倉庫コード
                string warehouseCode = frePSalesDetailWork.SALESDETAILRF_WAREHOUSECODERF;

                if (String.IsNullOrEmpty(goodsNo) || goodsMakerCd == 0)
                {
                    return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                //-------------------------------------------------------------------
                // 商品・在庫・倉庫
                //-------------------------------------------------------------------
                SqlCommand sqlCommand = new SqlCommand(
                    "SELECT * " + Environment.NewLine
                    + "FROM GOODSURF " + Environment.NewLine
                    + LeftJoin("GOODSURF", "STOCKRF", "", new string[] { "GOODSNORF", "GOODSMAKERCDRF" }, new string[] { "STOCKRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" }) + Environment.NewLine
                    + LeftJoin("STOCKRF", "WAREHOUSERF", "", new string[] { "WAREHOUSECODERF" }, new string[] { "WAREHOUSERF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" }) + Environment.NewLine
                    , sqlConnection);

                // 条件設定
                # region [WHERE]
                sqlCommand.CommandText += "WHERE " + Environment.NewLine;

                // 企業コード
                sqlCommand.CommandText += "GOODSURF.ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine;
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = extPrm.EnterpriseCode;

                // 論理削除コード
                sqlCommand.CommandText += "AND GOODSURF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE " + Environment.NewLine;
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findParaLogicalDeleteCode.Value = 0;

                // メーカーコード
                sqlCommand.CommandText += "AND GOODSURF.GOODSMAKERCDRF=@FINDGOODSMAKERCD " + Environment.NewLine;
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                findParaGoodsMakerCd.Value = goodsMakerCd;

                // 品番
                sqlCommand.CommandText += "AND GOODSURF.GOODSNORF=@FINDGOODSNO " + Environment.NewLine;
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);
                findParaGoodsNo.Value = goodsNo;

                // 倉庫
                sqlCommand.CommandText += "AND STOCKRF.WAREHOUSECODERF=@FINDWAREHOUSECODE " + Environment.NewLine;
                SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                findParaWarehouseCode.Value = warehouseCode;

                # endregion

                // タイムアウト時間設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    # region [データのコピー]

                    string readGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    int readGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    string readWarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));

                    if (goodsNo.Trim() == readGoodsNo.Trim() && goodsMakerCd == readGoodsMakerCd)
                    {
                        frePSalesDetailWork.GOODSURF_GOODSNAMEKANARF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
                        frePSalesDetailWork.GOODSURF_JANRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JANRF"));
                        frePSalesDetailWork.GOODSURF_GOODSRATERANKRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
                        frePSalesDetailWork.GOODSURF_GOODSNONONEHYPHENRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
                        frePSalesDetailWork.GOODSURF_GOODSNOTE1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE1RF"));
                        frePSalesDetailWork.GOODSURF_GOODSNOTE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE2RF"));
                        frePSalesDetailWork.GOODSURF_GOODSSPECIALNOTERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSPECIALNOTERF"));

                        if (warehouseCode.Trim() == readWarehouseCode.Trim())
                        {
                            frePSalesDetailWork.STOCKRF_SHIPMENTPOSCNTRF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
                            frePSalesDetailWork.STOCKRF_DUPLICATIONSHELFNO1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO1RF"));
                            frePSalesDetailWork.STOCKRF_DUPLICATIONSHELFNO2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO2RF"));
                            frePSalesDetailWork.STOCKRF_PARTSMANAGEMENTDIVIDE1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE1RF"));
                            frePSalesDetailWork.STOCKRF_PARTSMANAGEMENTDIVIDE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE2RF"));
                            frePSalesDetailWork.STOCKRF_STOCKNOTE1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE1RF"));
                            frePSalesDetailWork.STOCKRF_STOCKNOTE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE2RF"));
                            frePSalesDetailWork.WAREHOUSERF_WAREHOUSENOTE1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENOTE1RF"));
                        }
                    }
                    # endregion

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SearchProc\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }
            return status;
        }
        /// <summary>
        /// ＵＯＥ伝票明細抽出（車両情報）
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="frePSalesDetailWork"></param>
        /// <param name="sqlConnection"></param>
        private int ReflectUOEDetailFromCar(FrePUOESlipParaWork extPrm, ref FrePSalesDetailWork frePSalesDetailWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;

            try
            {
                // 受注ステータス(元)
                int acptAnOdrStatusSrc = frePSalesDetailWork.SALESDETAILRF_ACPTANODRSTATUSSRCRF;
                // 明細通番(元)
                long salesSlipDtlNumSrc = frePSalesDetailWork.SALESDETAILRF_SALESSLIPDTLNUMSRCRF;

                //-------------------------------------------------------------------
                // 売上明細・受注マスタ(車両)
                //-------------------------------------------------------------------
                SqlCommand sqlCommand = new SqlCommand(
                    "SELECT * " + Environment.NewLine
                    + "FROM SALESDETAILRF " + Environment.NewLine
                    + LeftJoin("SALESDETAILRF", "ACCEPTODRCARRF", "", new string[] { "ACCEPTANORDERNORF" }, new string[] { "SALESDETAILRF.ACPTANODRSTATUSRF='20'", "ACCEPTODRCARRF.ACPTANODRSTATUSRF='3'", "ACCEPTODRCARRF.DATAINPUTSYSTEMRF='10'" }) + Environment.NewLine
                    , sqlConnection);

                // 条件設定
                # region [WHERE]
                sqlCommand.CommandText += "WHERE " + Environment.NewLine;

                // 企業コード
                sqlCommand.CommandText += "SALESDETAILRF.ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine;
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = extPrm.EnterpriseCode;

                // 論理削除コード
                sqlCommand.CommandText += "AND SALESDETAILRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE " + Environment.NewLine;
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findParaLogicalDeleteCode.Value = 0;

                // 受注ステータス
                sqlCommand.CommandText += "AND SALESDETAILRF.ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS " + Environment.NewLine;
                SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                findParaAcptAnOdrStatus.Value = acptAnOdrStatusSrc;

                // 明細通番
                sqlCommand.CommandText += "AND SALESDETAILRF.SALESSLIPDTLNUMRF=@FINDSALESSLIPDTLNUM " + Environment.NewLine;
                SqlParameter findParaSalesSlipDtlNum = sqlCommand.Parameters.Add("@FINDSALESSLIPDTLNUM", SqlDbType.BigInt);
                findParaSalesSlipDtlNum.Value = salesSlipDtlNumSrc;
                # endregion

                // タイムアウト時間設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    # region [データのコピー]
                    frePSalesDetailWork.ACCEPTODRCARRF_CARMNGNORF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARMNGNORF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_CARMNGCODERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARMNGCODERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_NUMBERPLATE1CODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE1CODERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_NUMBERPLATE1NAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE1NAMERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_NUMBERPLATE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE2RF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_NUMBERPLATE3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE3RF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_NUMBERPLATE4RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE4RF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_FIRSTENTRYDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FIRSTENTRYDATERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_MAKERCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_MAKERFULLNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERFULLNAMERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_MODELCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_MODELSUBCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_MODELFULLNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELFULLNAMERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_EXHAUSTGASSIGNRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EXHAUSTGASSIGNRF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_SERIESMODELRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SERIESMODELRF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_CATEGORYSIGNMODELRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATEGORYSIGNMODELRF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_FULLMODELRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_MODELDESIGNATIONNORF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_CATEGORYNORF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_FRAMEMODELRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMEMODELRF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_FRAMENORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMENORF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_SEARCHFRAMENORF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEARCHFRAMENORF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_ENGINEMODELNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEMODELNMRF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_RELEVANCEMODELRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RELEVANCEMODELRF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_SUBCARNMCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBCARNMCDRF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_MODELGRADESNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELGRADESNAMERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_COLORCODERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORCODERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_COLORNAME1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORNAME1RF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_TRIMCODERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMCODERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_TRIMNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMNAMERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_MILEAGERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MILEAGERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_MAKERHALFNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERHALFNAMERF"));
                    frePSalesDetailWork.ACCEPTODRCARRF_MODELHALFNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELHALFNAMERF"));
                    # endregion

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    break;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SearchProc\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }
            return status;
        }

        // --- ADD 2009.07.24 劉洋 ------ >>>>>>
        /// <summary>
        /// ＵＯＥ伝票明細抽出（オートバックス商品設定マスタ）
        /// </summary>
        /// <param name="extPrm">データ</param>
        /// <param name="frePSalesDetailWork">売上データ</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <remarks>
        /// <br>Note       : オートバックス情報検索</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.07.24</br>
        /// <br>Note       : メーカー・品番S＆E商品コード検索</br>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.03.18</br>
        /// </remarks>	
        private int ReflectUOEDetailFromSAndEGoodsCdChg(FrePUOESlipParaWork extPrm, ref FrePSalesDetailWork frePSalesDetailWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;

            try
            {
                // ＢＬ商品コード
                // --- UPD 寺田義啓 2020.03.18 ---------->>>>>
                //int bLGoodsCode = frePSalesDetailWork.SALESDETAILRF_BLGOODSCODERF;
                int bLGoodsCode = frePSalesDetailWork.SALESDETAILRF_PRTBLGOODSCODERF;
                // --- UPD 寺田義啓 2020.03.18 ----------<<<<<

                //-------------------------------------------------------------------
                // 売上明細・受注マスタ(車両)
                //-------------------------------------------------------------------
                SqlCommand sqlCommand = new SqlCommand(
                    "SELECT SANDEGOODSCDCHGRF.ABGOODSCODERF " + Environment.NewLine
                    + "FROM SANDEGOODSCDCHGRF " + Environment.NewLine
                    , sqlConnection);

                // 条件設定
                # region [WHERE]
                sqlCommand.CommandText += "WHERE " + Environment.NewLine;

                // 企業コード
                sqlCommand.CommandText += "SANDEGOODSCDCHGRF.ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine;
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = extPrm.EnterpriseCode;

                // 論理削除コード
                sqlCommand.CommandText += "AND SANDEGOODSCDCHGRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE " + Environment.NewLine;
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findParaLogicalDeleteCode.Value = 0;

                // 商品コード
                sqlCommand.CommandText += "AND SANDEGOODSCDCHGRF.BLGOODSCODERF=@FINDBLGOODSCODE " + Environment.NewLine;
                SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                findParaBLGoodsCode.Value = bLGoodsCode;
                # endregion

                // タイムアウト時間設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    # region [データのコピー]
                    frePSalesDetailWork.SANDEGOODSCDCHGRF_ABGOODSCODE = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ABGOODSCODERF"));
                    # endregion

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    break;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ReflectUOEDetailFromSAndEGoodsCdChg\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }
            return status;
        }
        // ADD 2009.07.24 劉洋 ------ <<<<<<

        // --- ADD 2020.03.18 寺田義啓 ------ >>>>>>
        /// <summary>
        /// ＵＯＥ伝票明細抽出（メーカー・品番S＆E商品コード変換マスタ）
        /// </summary>
        /// <param name="extPrm">データ</param>
        /// <param name="frePSalesDetailWork">売上データ</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <remarks>
        /// <br>Note       : メーカー・品番S＆E商品コード検索</br>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.03.18</br>
        /// </remarks>	
        private int ReflectUOEDetailFromSAndEMkrGdsCdChg(FrePUOESlipParaWork extPrm, ref FrePSalesDetailWork frePSalesDetailWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;

            try
            {
                // 商品メーカーコード
                int goodsMakerCd = frePSalesDetailWork.SALESDETAILRF_GOODSMAKERCDRF;
                // 印刷用商品番号
                string prtGoodsNo = frePSalesDetailWork.SALESDETAILRF_PRTGOODSNORF;

                //-------------------------------------------------------------------
                // メーカー・品番S＆E商品コード変換マスタ
                //-------------------------------------------------------------------
                SqlCommand sqlCommand = new SqlCommand(
                    "SELECT SANDEMKRGDSCDCHGRF.ABGOODSCODERF " + Environment.NewLine
                    + "FROM SANDEMKRGDSCDCHGRF " + Environment.NewLine
                    , sqlConnection);

                // 条件設定
                # region [WHERE]
                sqlCommand.CommandText += "WHERE " + Environment.NewLine;

                // 企業コード
                sqlCommand.CommandText += "SANDEMKRGDSCDCHGRF.ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine;
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = extPrm.EnterpriseCode;

                // 論理削除コード
                sqlCommand.CommandText += "AND SANDEMKRGDSCDCHGRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE " + Environment.NewLine;
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findParaLogicalDeleteCode.Value = 0;

                // 商品メーカーコード
                sqlCommand.CommandText += "AND SANDEMKRGDSCDCHGRF.GOODSMAKERCDRF=@FINDGOODSMAKERCD " + Environment.NewLine;
                SqlParameter findGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                findGoodsMakerCd.Value = goodsMakerCd;

                // 商品番号
                sqlCommand.CommandText += "AND SANDEMKRGDSCDCHGRF.GOODSNORF=@FINDGOODSNO " + Environment.NewLine;
                SqlParameter findGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                findGoodsNo.Value = prtGoodsNo;
                # endregion

                // タイムアウト時間設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    # region [データのコピー]
                    frePSalesDetailWork.SANDEGOODSCDCHGRF_ABGOODSCODE = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ABGOODSCODERF"));
                    # endregion

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    break;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ReflectUOEDetailFromSAndEMkrGdsCdChg\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }
            return status;
        }
        // ADD 2020.03.18 寺田義啓 ------ <<<<<<
        # endregion

        # region [自動生成系処理]
        /// <summary>
        /// LeftJoin生成処理
        /// </summary>
        /// <param name="leftTable">左テーブル</param>
        /// <param name="rightTable">右テーブル</param>
        /// <param name="items">一致条件項目リスト</param>
        /// <param name="andMore">追加条件リスト</param>
        /// <returns>LEFT JOIN 文</returns>
        private string LeftJoin(string leftTable, string rightTable, string rightAs, string[] items, string[] andMore)
        {
            StringBuilder sb = new StringBuilder();

            // LEFT JOIN
            if (rightAs == string.Empty)
            {
                sb.Append(string.Format("  LEFT JOIN {0} ON ", rightTable));
                rightAs = rightTable;
            }
            else
            {
                sb.Append(string.Format("  LEFT JOIN {0} AS {1} ON ", rightTable, rightAs));
            }

            // 企業コードは必須
            sb.Append(string.Format("{0}.{2}={1}.{2} ", leftTable, rightAs, "ENTERPRISECODERF"));

            // その他Joinの条件
            for (int index = 0; index < items.Length; index++)
            {
                sb.Append(string.Format("AND {0}.{2}={1}.{2} ", leftTable, rightAs, items[index]));
            }
            // 追加条件
            for (int index = 0; index < andMore.Length; index++)
            {
                sb.Append(string.Format("AND {0} ", andMore[index]));
            }

            // 改行
            sb.Append(Environment.NewLine);

            return sb.ToString();
        }
        /// <summary>
        /// 抽出項目名取得処理
        /// </summary>
        /// <param name="extPrm"></param>
        /// <returns></returns>
        private string GetSelectItemsForSlip(FrePSalesSlipParaWork extPrm)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 注意：同じテーブルを複数回JOINする場合は、Selectに与える項目名称もAsで別名にする。
            StringBuilder sb = new StringBuilder();
            # region [項目名]
            sb.Append("SALESSLIPRF.ACPTANODRSTATUSRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.SALESSLIPNUMRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.SECTIONCODERF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.SUBSECTIONCODERF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.DEBITNOTEDIVRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.DEBITNLNKSALESSLNUMRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.SALESSLIPCDRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.SALESGOODSCDRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.ACCRECDIVCDRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.SEARCHSLIPDATERF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.SHIPMENTDAYRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.SALESDATERF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.ADDUPADATERF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.DELAYPAYMENTDIVRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.ESTIMATEFORMNORF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.ESTIMATEDIVIDERF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.SALESINPUTCODERF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.SALESINPUTNAMERF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.FRONTEMPLOYEECDRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.FRONTEMPLOYEENMRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.SALESEMPLOYEECDRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.SALESEMPLOYEENMRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.TOTALAMOUNTDISPWAYCDRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.TTLAMNTDISPRATEAPYRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.SALESTOTALTAXINCRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.SALESTOTALTAXEXCRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.SALESSUBTOTALTAXINCRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.SALESSUBTOTALTAXEXCRF," + Environment.NewLine);
            //sb.Append( "SALESSLIPRF.SALSENETPRICERF," + Environment.NewLine );
            sb.Append("SALESSLIPRF.SALESSUBTOTALTAXRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.ITDEDSALESOUTTAXRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.ITDEDSALESINTAXRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.SALSUBTTLSUBTOTAXFRERF," + Environment.NewLine);
            //sb.Append( "SALESSLIPRF.SALSEOUTTAXRF," + Environment.NewLine );
            sb.Append("SALESSLIPRF.SALAMNTCONSTAXINCLURF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.SALESDISTTLTAXEXCRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.ITDEDSALESDISOUTTAXRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.ITDEDSALESDISINTAXRF," + Environment.NewLine);
            //sb.Append( "SALESSLIPRF.ITDEDSALSEDISTAXFRERF," + Environment.NewLine );
            sb.Append("SALESSLIPRF.SALESDISOUTTAXRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.SALESDISTTLTAXINCLURF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.TOTALCOSTRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.CONSTAXLAYMETHODRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.CONSTAXRATERF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.FRACTIONPROCCDRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.ACCRECCONSTAXRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.AUTODEPOSITCDRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.AUTODEPOSITSLIPNORF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.DEPOSITALLOWANCETTLRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.DEPOSITALWCBLNCERF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.CLAIMCODERF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.CLAIMSNMRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.CUSTOMERCODERF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.CUSTOMERNAMERF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.CUSTOMERNAME2RF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.CUSTOMERSNMRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.HONORIFICTITLERF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.ADDRESSEECODERF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.ADDRESSEENAMERF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.ADDRESSEENAME2RF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.ADDRESSEEPOSTNORF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.ADDRESSEEADDR1RF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.ADDRESSEEADDR3RF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.ADDRESSEEADDR4RF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.ADDRESSEETELNORF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.ADDRESSEEFAXNORF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.PARTYSALESLIPNUMRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.SLIPNOTERF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.SLIPNOTE2RF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.RETGOODSREASONDIVRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.RETGOODSREASONRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.REGIPROCDATERF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.CASHREGISTERNORF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.POSRECEIPTNORF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.DETAILROWCOUNTRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.EDISENDDATERF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.EDITAKEINDATERF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.UOEREMARK1RF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.UOEREMARK2RF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.SLIPPRINTFINISHCDRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.SALESSLIPPRINTDATERF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.BUSINESSTYPECODERF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.BUSINESSTYPENAMERF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.ORDERNUMBERRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.DELIVEREDGOODSDIVRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.DELIVEREDGOODSDIVNMRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.SALESAREACODERF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.SALESAREANAMERF," + Environment.NewLine);
            //sb.Append( "SALESSLIPRF.COMPLETECDRF," + Environment.NewLine );
            sb.Append("SALESSLIPRF.STOCKGOODSTTLTAXEXCRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.PUREGOODSTTLTAXEXCRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.LISTPRICEPRINTDIVRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.ERANAMEDISPCD1RF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.ESTIMATAXDIVCDRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.ESTIMATEFORMPRTCDRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.ESTIMATESUBJECTRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.FOOTNOTES1RF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.FOOTNOTES2RF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.ESTIMATETITLE1RF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.ESTIMATETITLE2RF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.ESTIMATETITLE3RF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.ESTIMATETITLE4RF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.ESTIMATETITLE5RF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.ESTIMATENOTE1RF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.ESTIMATENOTE2RF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.ESTIMATENOTE3RF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.ESTIMATENOTE4RF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.ESTIMATENOTE5RF," + Environment.NewLine);
            sb.Append("SECINFOSETRF.SECTIONGUIDENMRF," + Environment.NewLine);
            sb.Append("SECINFOSETRF.SECTIONGUIDESNMRF," + Environment.NewLine);
            sb.Append("SECINFOSETRF.COMPANYNAMECD1RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYPRRF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYNAME1RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYNAME2RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.POSTNORF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.ADDRESS1RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.ADDRESS3RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.ADDRESS4RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYTELNO1RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYTELNO2RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYTELNO3RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYTELTITLE1RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYTELTITLE2RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYTELTITLE3RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.TRANSFERGUIDANCERF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.ACCOUNTNOINFO1RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.ACCOUNTNOINFO2RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.ACCOUNTNOINFO3RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYSETNOTE1RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYSETNOTE2RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.IMAGEINFODIVRF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.IMAGEINFOCODERF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYURLRF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYPRSENTENCE2RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.IMAGECOMMENTFORPRT1RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.IMAGECOMMENTFORPRT2RF," + Environment.NewLine);
            sb.Append("IMAGEINFORF.IMAGEINFODATARF," + Environment.NewLine);
            sb.Append("SUBSECTIONRF.SUBSECTIONNAMERF," + Environment.NewLine);
            sb.Append("EMPINP.KANARF AS EMPINPKANARF," + Environment.NewLine);
            sb.Append("EMPINP.SHORTNAMERF AS EMPINPSHORTNAMERF," + Environment.NewLine);
            sb.Append("EMPFRT.KANARF AS EMPFRTKANARF," + Environment.NewLine);
            sb.Append("EMPFRT.SHORTNAMERF AS EMPFRTSHORTNAMERF," + Environment.NewLine);
            sb.Append("EMPSAL.KANARF AS EMPSALKANARF," + Environment.NewLine);
            sb.Append("EMPSAL.SHORTNAMERF AS EMPSALSHORTNAMERF," + Environment.NewLine);
            sb.Append("CSTCLM.CUSTOMERSUBCODERF AS CSTCLMCUSTOMERSUBCODERF," + Environment.NewLine);
            sb.Append("CSTCLM.NAMERF AS CSTCLMNAMERF," + Environment.NewLine);
            sb.Append("CSTCLM.NAME2RF AS CSTCLMNAME2RF," + Environment.NewLine);
            sb.Append("CSTCLM.HONORIFICTITLERF AS CSTCLMHONORIFICTITLERF," + Environment.NewLine);
            sb.Append("CSTCLM.KANARF AS CSTCLMKANARF," + Environment.NewLine);
            sb.Append("CSTCLM.CUSTOMERSNMRF AS CSTCLMCUSTOMERSNMRF," + Environment.NewLine);
            sb.Append("CSTCLM.OUTPUTNAMECODERF AS CSTCLMOUTPUTNAMECODERF," + Environment.NewLine);
            sb.Append("CSTCLM.CUSTANALYSCODE1RF AS CSTCLMCUSTANALYSCODE1RF," + Environment.NewLine);
            sb.Append("CSTCLM.CUSTANALYSCODE2RF AS CSTCLMCUSTANALYSCODE2RF," + Environment.NewLine);
            sb.Append("CSTCLM.CUSTANALYSCODE3RF AS CSTCLMCUSTANALYSCODE3RF," + Environment.NewLine);
            sb.Append("CSTCLM.CUSTANALYSCODE4RF AS CSTCLMCUSTANALYSCODE4RF," + Environment.NewLine);
            sb.Append("CSTCLM.CUSTANALYSCODE5RF AS CSTCLMCUSTANALYSCODE5RF," + Environment.NewLine);
            sb.Append("CSTCLM.CUSTANALYSCODE6RF AS CSTCLMCUSTANALYSCODE6RF," + Environment.NewLine);
            sb.Append("CSTCLM.NOTE1RF AS CSTCLMNOTE1RF," + Environment.NewLine);
            sb.Append("CSTCLM.NOTE2RF AS CSTCLMNOTE2RF," + Environment.NewLine);
            sb.Append("CSTCLM.NOTE3RF AS CSTCLMNOTE3RF," + Environment.NewLine);
            sb.Append("CSTCLM.NOTE4RF AS CSTCLMNOTE4RF," + Environment.NewLine);
            sb.Append("CSTCLM.NOTE5RF AS CSTCLMNOTE5RF," + Environment.NewLine);
            sb.Append("CSTCLM.NOTE6RF AS CSTCLMNOTE6RF," + Environment.NewLine);
            sb.Append("CSTCLM.NOTE7RF AS CSTCLMNOTE7RF," + Environment.NewLine);
            sb.Append("CSTCLM.NOTE8RF AS CSTCLMNOTE8RF," + Environment.NewLine);
            sb.Append("CSTCLM.NOTE9RF AS CSTCLMNOTE9RF," + Environment.NewLine);
            sb.Append("CSTCLM.NOTE10RF AS CSTCLMNOTE10RF," + Environment.NewLine);
            sb.Append("CSTCST.CUSTOMERSUBCODERF AS CSTCSTCUSTOMERSUBCODERF," + Environment.NewLine);
            sb.Append("CSTCST.NAMERF AS CSTCSTNAMERF," + Environment.NewLine);
            sb.Append("CSTCST.NAME2RF AS CSTCSTNAME2RF," + Environment.NewLine);
            sb.Append("CSTCST.HONORIFICTITLERF AS CSTCSTHONORIFICTITLERF," + Environment.NewLine);
            sb.Append("CSTCST.KANARF AS CSTCSTKANARF," + Environment.NewLine);
            sb.Append("CSTCST.CUSTOMERSNMRF AS CSTCSTCUSTOMERSNMRF," + Environment.NewLine);
            sb.Append("CSTCST.OUTPUTNAMECODERF AS CSTCSTOUTPUTNAMECODERF," + Environment.NewLine);
            sb.Append("CSTCST.CUSTANALYSCODE1RF AS CSTCSTCUSTANALYSCODE1RF," + Environment.NewLine);
            sb.Append("CSTCST.CUSTANALYSCODE2RF AS CSTCSTCUSTANALYSCODE2RF," + Environment.NewLine);
            sb.Append("CSTCST.CUSTANALYSCODE3RF AS CSTCSTCUSTANALYSCODE3RF," + Environment.NewLine);
            sb.Append("CSTCST.CUSTANALYSCODE4RF AS CSTCSTCUSTANALYSCODE4RF," + Environment.NewLine);
            sb.Append("CSTCST.CUSTANALYSCODE5RF AS CSTCSTCUSTANALYSCODE5RF," + Environment.NewLine);
            sb.Append("CSTCST.CUSTANALYSCODE6RF AS CSTCSTCUSTANALYSCODE6RF," + Environment.NewLine);
            sb.Append("CSTCST.NOTE1RF AS CSTCSTNOTE1RF," + Environment.NewLine);
            sb.Append("CSTCST.NOTE2RF AS CSTCSTNOTE2RF," + Environment.NewLine);
            sb.Append("CSTCST.NOTE3RF AS CSTCSTNOTE3RF," + Environment.NewLine);
            sb.Append("CSTCST.NOTE4RF AS CSTCSTNOTE4RF," + Environment.NewLine);
            sb.Append("CSTCST.NOTE5RF AS CSTCSTNOTE5RF," + Environment.NewLine);
            sb.Append("CSTCST.NOTE6RF AS CSTCSTNOTE6RF," + Environment.NewLine);
            sb.Append("CSTCST.NOTE7RF AS CSTCSTNOTE7RF," + Environment.NewLine);
            sb.Append("CSTCST.NOTE8RF AS CSTCSTNOTE8RF," + Environment.NewLine);
            sb.Append("CSTCST.NOTE9RF AS CSTCSTNOTE9RF," + Environment.NewLine);
            sb.Append("CSTCST.NOTE10RF AS CSTCSTNOTE10RF," + Environment.NewLine);
            // ---- ADD caohh 20111/08/17 ------>>>>>
            sb.Append("CSTCST.POSTNORF AS CSTCSTPOSTNORF," + Environment.NewLine);
            sb.Append("CSTCST.ADDRESS1RF AS CSTCSTADDRESS1RF," + Environment.NewLine);
            sb.Append("CSTCST.ADDRESS3RF AS CSTCSTADDRESS3RF," + Environment.NewLine);
            sb.Append("CSTCST.ADDRESS4RF AS CSTCSTADDRESS4RF," + Environment.NewLine);
            sb.Append("CSTCST.HOMETELNORF AS CSTCSTHOMETELNORF," + Environment.NewLine);
            sb.Append("CSTCST.OFFICETELNORF AS CSTCSTOFFICETELNORF," + Environment.NewLine);
            sb.Append("CSTCST.PORTABLETELNORF AS CSTCSTPORTABLETELNORF," + Environment.NewLine);
            sb.Append("CSTCST.OTHERSTELNORF AS CSTCSTOTHERSTELNORF," + Environment.NewLine);
            sb.Append("CSTCST.HOMEFAXNORF AS CSTCSTHOMEFAXNORF," + Environment.NewLine);
            sb.Append("CSTCST.OFFICEFAXNORF AS CSTCSTOFFICEFAXNORF," + Environment.NewLine);
            // ---- ADD caohh 20111/08/17 ------<<<<<
            sb.Append("CSTADR.CUSTOMERSUBCODERF AS CSTADRCUSTOMERSUBCODERF," + Environment.NewLine);
            sb.Append("CSTADR.NAMERF AS CSTADRNAMERF," + Environment.NewLine);
            sb.Append("CSTADR.NAME2RF AS CSTADRNAME2RF," + Environment.NewLine);
            sb.Append("CSTADR.HONORIFICTITLERF AS CSTADRHONORIFICTITLERF," + Environment.NewLine);
            sb.Append("CSTADR.KANARF AS CSTADRKANARF," + Environment.NewLine);
            sb.Append("CSTADR.CUSTOMERSNMRF AS CSTADRCUSTOMERSNMRF," + Environment.NewLine);
            sb.Append("CSTADR.OUTPUTNAMECODERF AS CSTADROUTPUTNAMECODERF," + Environment.NewLine);
            sb.Append("CSTADR.CUSTANALYSCODE1RF AS CSTADRCUSTANALYSCODE1RF," + Environment.NewLine);
            sb.Append("CSTADR.CUSTANALYSCODE2RF AS CSTADRCUSTANALYSCODE2RF," + Environment.NewLine);
            sb.Append("CSTADR.CUSTANALYSCODE3RF AS CSTADRCUSTANALYSCODE3RF," + Environment.NewLine);
            sb.Append("CSTADR.CUSTANALYSCODE4RF AS CSTADRCUSTANALYSCODE4RF," + Environment.NewLine);
            sb.Append("CSTADR.CUSTANALYSCODE5RF AS CSTADRCUSTANALYSCODE5RF," + Environment.NewLine);
            sb.Append("CSTADR.CUSTANALYSCODE6RF AS CSTADRCUSTANALYSCODE6RF," + Environment.NewLine);
            sb.Append("CSTADR.NOTE1RF AS CSTADRNOTE1RF," + Environment.NewLine);
            sb.Append("CSTADR.NOTE2RF AS CSTADRNOTE2RF," + Environment.NewLine);
            sb.Append("CSTADR.NOTE3RF AS CSTADRNOTE3RF," + Environment.NewLine);
            sb.Append("CSTADR.NOTE4RF AS CSTADRNOTE4RF," + Environment.NewLine);
            sb.Append("CSTADR.NOTE5RF AS CSTADRNOTE5RF," + Environment.NewLine);
            sb.Append("CSTADR.NOTE6RF AS CSTADRNOTE6RF," + Environment.NewLine);
            sb.Append("CSTADR.NOTE7RF AS CSTADRNOTE7RF," + Environment.NewLine);
            sb.Append("CSTADR.NOTE8RF AS CSTADRNOTE8RF," + Environment.NewLine);
            sb.Append("CSTADR.NOTE9RF AS CSTADRNOTE9RF," + Environment.NewLine);
            sb.Append("CSTADR.NOTE10RF AS CSTADRNOTE10RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.COMPANYNAME1RF AS COMPANYINFRFCOMPANYNAME1RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.COMPANYNAME2RF AS COMPANYINFRFCOMPANYNAME2RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.POSTNORF AS COMPANYINFRFPOSTNORF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.ADDRESS1RF AS COMPANYINFRFADDRESS1RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.ADDRESS3RF AS COMPANYINFRFADDRESS3RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.ADDRESS4RF AS COMPANYINFRFADDRESS4RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.COMPANYTELNO1RF AS COMPANYINFRFCOMPANYTELNO1RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.COMPANYTELNO2RF AS COMPANYINFRFCOMPANYTELNO2RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.COMPANYTELNO3RF AS COMPANYINFRFCOMPANYTELNO3RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.COMPANYTELTITLE1RF AS COMPANYINFRFCOMPANYTELTITLE1RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.COMPANYTELTITLE2RF AS COMPANYINFRFCOMPANYTELTITLE2RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.COMPANYTELTITLE3RF AS COMPANYINFRFCOMPANYTELTITLE3RF,");
            sb.Append("SALESSLIPRF.RESULTSADDUPSECCDRF," + Environment.NewLine);
            sb.Append("SALESSLIPRF.SLIPNOTE3RF," + Environment.NewLine);
            // --- UPDATE 2009.07.27 ---------->>>>>
            sb.Append(" SALESSLIPRF.UPDATEDATETIMERF, " + Environment.NewLine);
            // --- UPDATE 2009.07.27 ----------<<<<<
            sb.Append(" SANDESETTINGRF.CUSTOMERCODERF AS SANCUSTOMERCODERF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.ADDRESSEESHOPCDRF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.SANDEMNGCODERF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.EXPENSEDIVCDRF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.DIRECTSENDINGCDRF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.ACPTANORDERDIVRF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.DELIVERERCDRF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.DELIVERERNMRF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.DELIVERERADDRESSRF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.DELIVERERPHONENUMRF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.TRADCOMPNAMERF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.TRADCOMPSECTNAMERF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.PURETRADCOMPCDRF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.PURETRADCOMPRATERF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.PRITRADCOMPCDRF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.PRITRADCOMPRATERF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.ABGOODSCODERF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.COMMENTRESERVEDDIVRF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.GOODSMAKERCD1RF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.GOODSMAKERCD2RF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.GOODSMAKERCD3RF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.GOODSMAKERCD4RF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.GOODSMAKERCD5RF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.GOODSMAKERCD6RF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.GOODSMAKERCD7RF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.GOODSMAKERCD8RF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.GOODSMAKERCD9RF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.GOODSMAKERCD10RF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.GOODSMAKERCD11RF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.GOODSMAKERCD12RF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.GOODSMAKERCD13RF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.GOODSMAKERCD14RF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.GOODSMAKERCD15RF," + Environment.NewLine);
            // --- DEL  大矢睦美  2010/03/01 ---------->>>>>
            //sb.Append(" SANDESETTINGRF.PARTSOEMDIVRF" + Environment.NewLine);//←最後はカンマなし
            // --- DEL  大矢睦美  2010/03/01 ----------<<<<<
            // --- ADD  汪千来  2009.07.27 ----------<<<<<
            // --- ADD  大矢睦美  2010/03/01 ---------->>>>>            
            sb.Append(" SANDESETTINGRF.PARTSOEMDIVRF," + Environment.NewLine);
            sb.Append(" CSTCST.SALESUNPRCFRCPROCCDRF," + Environment.NewLine);
            sb.Append(" CSTCST.SALESMONEYFRCPROCCDRF," + Environment.NewLine);
            // --- UPD m.suzuki 2010/03/24 ---------->>>>>
            //sb.Append(" CSTCST.SALESCNSTAXFRCPROCCDRF" + Environment.NewLine);            
            sb.Append( " CSTCST.SALESCNSTAXFRCPROCCDRF," + Environment.NewLine );
            // --- UPD m.suzuki 2010/03/24 ----------<<<<<
            // --- ADD  大矢睦美  2010/03/01 ----------<<<<<
            // --- ADD m.suzuki 2010/03/24 ---------->>>>>
            // 2010/07/06 >>>
            //sb.Append( " CSTCST.QRCODEPRTCDRF" + Environment.NewLine );
            sb.Append(" CSTCST.QRCODEPRTCDRF," + Environment.NewLine);
            // 2010/07/06 <<<
            // --- ADD m.suzuki 2010/03/24 ----------<<<<<
            // 2010/07/06 Add >>>
            sb.Append(" SALESSLIPRF.FILEHEADERGUIDRF" + Environment.NewLine);
            // 2010/07/06 Add <<<
            # endregion
            return sb.ToString();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }
        // -------ADD 2010/06/08------->>>>>
        /// <summary>
        /// 抽出項目名取得処理
        /// </summary>
        /// <param name="extPrm"></param>
        /// <returns></returns>
        /// <br>Note		: 売上データの伝票情報が取得できない場合は、売上履歴データを読み込んで伝票情報を取得するようにする。</br>
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2010/06/08</br>
        private string GetSelectItemsForHistory(FrePSalesSlipParaWork extPrm)
        {
            // 注意：同じテーブルを複数回JOINする場合は、Selectに与える項目名称もAsで別名にする。
            StringBuilder sb = new StringBuilder();
            # region [項目名]
            sb.Append("SALESHISTORYRF.ACPTANODRSTATUSRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.SALESSLIPNUMRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.SECTIONCODERF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.SUBSECTIONCODERF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.DEBITNOTEDIVRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.DEBITNLNKSALESSLNUMRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.SALESSLIPCDRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.SALESGOODSCDRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.ACCRECDIVCDRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.SEARCHSLIPDATERF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.SHIPMENTDAYRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.SALESDATERF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.ADDUPADATERF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.DELAYPAYMENTDIVRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.SALESINPUTCODERF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.SALESINPUTNAMERF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.FRONTEMPLOYEECDRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.FRONTEMPLOYEENMRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.SALESEMPLOYEECDRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.SALESEMPLOYEENMRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.TOTALAMOUNTDISPWAYCDRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.TTLAMNTDISPRATEAPYRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.SALESTOTALTAXINCRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.SALESTOTALTAXEXCRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.SALESSUBTOTALTAXINCRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.SALESSUBTOTALTAXEXCRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.SALESSUBTOTALTAXRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.ITDEDSALESOUTTAXRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.ITDEDSALESINTAXRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.SALSUBTTLSUBTOTAXFRERF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.SALAMNTCONSTAXINCLURF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.SALESDISTTLTAXEXCRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.ITDEDSALESDISOUTTAXRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.ITDEDSALESDISINTAXRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.SALESDISOUTTAXRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.SALESDISTTLTAXINCLURF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.TOTALCOSTRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.CONSTAXLAYMETHODRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.CONSTAXRATERF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.FRACTIONPROCCDRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.ACCRECCONSTAXRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.AUTODEPOSITCDRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.AUTODEPOSITSLIPNORF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.DEPOSITALLOWANCETTLRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.DEPOSITALWCBLNCERF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.CLAIMCODERF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.CLAIMSNMRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.CUSTOMERCODERF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.CUSTOMERNAMERF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.CUSTOMERNAME2RF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.CUSTOMERSNMRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.HONORIFICTITLERF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.ADDRESSEECODERF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.ADDRESSEENAMERF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.ADDRESSEENAME2RF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.ADDRESSEEPOSTNORF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.ADDRESSEEADDR1RF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.ADDRESSEEADDR3RF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.ADDRESSEEADDR4RF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.ADDRESSEETELNORF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.ADDRESSEEFAXNORF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.PARTYSALESLIPNUMRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.SLIPNOTERF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.SLIPNOTE2RF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.RETGOODSREASONDIVRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.RETGOODSREASONRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.DETAILROWCOUNTRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.EDISENDDATERF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.EDITAKEINDATERF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.UOEREMARK1RF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.UOEREMARK2RF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.SLIPPRINTFINISHCDRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.SALESSLIPPRINTDATERF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.BUSINESSTYPECODERF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.BUSINESSTYPENAMERF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.DELIVEREDGOODSDIVRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.DELIVEREDGOODSDIVNMRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.SALESAREACODERF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.SALESAREANAMERF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.STOCKGOODSTTLTAXEXCRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.PUREGOODSTTLTAXEXCRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.LISTPRICEPRINTDIVRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.ERANAMEDISPCD1RF," + Environment.NewLine);
            sb.Append("SECINFOSETRF.SECTIONGUIDENMRF," + Environment.NewLine);
            sb.Append("SECINFOSETRF.SECTIONGUIDESNMRF," + Environment.NewLine);
            sb.Append("SECINFOSETRF.COMPANYNAMECD1RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYPRRF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYNAME1RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYNAME2RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.POSTNORF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.ADDRESS1RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.ADDRESS3RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.ADDRESS4RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYTELNO1RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYTELNO2RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYTELNO3RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYTELTITLE1RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYTELTITLE2RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYTELTITLE3RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.TRANSFERGUIDANCERF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.ACCOUNTNOINFO1RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.ACCOUNTNOINFO2RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.ACCOUNTNOINFO3RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYSETNOTE1RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYSETNOTE2RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.IMAGEINFODIVRF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.IMAGEINFOCODERF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYURLRF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.COMPANYPRSENTENCE2RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.IMAGECOMMENTFORPRT1RF," + Environment.NewLine);
            sb.Append("COMPANYNMRF.IMAGECOMMENTFORPRT2RF," + Environment.NewLine);
            sb.Append("IMAGEINFORF.IMAGEINFODATARF," + Environment.NewLine);
            sb.Append("SUBSECTIONRF.SUBSECTIONNAMERF," + Environment.NewLine);
            sb.Append("EMPINP.KANARF AS EMPINPKANARF," + Environment.NewLine);
            sb.Append("EMPINP.SHORTNAMERF AS EMPINPSHORTNAMERF," + Environment.NewLine);
            sb.Append("EMPFRT.KANARF AS EMPFRTKANARF," + Environment.NewLine);
            sb.Append("EMPFRT.SHORTNAMERF AS EMPFRTSHORTNAMERF," + Environment.NewLine);
            sb.Append("EMPSAL.KANARF AS EMPSALKANARF," + Environment.NewLine);
            sb.Append("EMPSAL.SHORTNAMERF AS EMPSALSHORTNAMERF," + Environment.NewLine);
            sb.Append("CSTCLM.CUSTOMERSUBCODERF AS CSTCLMCUSTOMERSUBCODERF," + Environment.NewLine);
            sb.Append("CSTCLM.NAMERF AS CSTCLMNAMERF," + Environment.NewLine);
            sb.Append("CSTCLM.NAME2RF AS CSTCLMNAME2RF," + Environment.NewLine);
            sb.Append("CSTCLM.HONORIFICTITLERF AS CSTCLMHONORIFICTITLERF," + Environment.NewLine);
            sb.Append("CSTCLM.KANARF AS CSTCLMKANARF," + Environment.NewLine);
            sb.Append("CSTCLM.CUSTOMERSNMRF AS CSTCLMCUSTOMERSNMRF," + Environment.NewLine);
            sb.Append("CSTCLM.OUTPUTNAMECODERF AS CSTCLMOUTPUTNAMECODERF," + Environment.NewLine);
            sb.Append("CSTCLM.CUSTANALYSCODE1RF AS CSTCLMCUSTANALYSCODE1RF," + Environment.NewLine);
            sb.Append("CSTCLM.CUSTANALYSCODE2RF AS CSTCLMCUSTANALYSCODE2RF," + Environment.NewLine);
            sb.Append("CSTCLM.CUSTANALYSCODE3RF AS CSTCLMCUSTANALYSCODE3RF," + Environment.NewLine);
            sb.Append("CSTCLM.CUSTANALYSCODE4RF AS CSTCLMCUSTANALYSCODE4RF," + Environment.NewLine);
            sb.Append("CSTCLM.CUSTANALYSCODE5RF AS CSTCLMCUSTANALYSCODE5RF," + Environment.NewLine);
            sb.Append("CSTCLM.CUSTANALYSCODE6RF AS CSTCLMCUSTANALYSCODE6RF," + Environment.NewLine);
            sb.Append("CSTCLM.NOTE1RF AS CSTCLMNOTE1RF," + Environment.NewLine);
            sb.Append("CSTCLM.NOTE2RF AS CSTCLMNOTE2RF," + Environment.NewLine);
            sb.Append("CSTCLM.NOTE3RF AS CSTCLMNOTE3RF," + Environment.NewLine);
            sb.Append("CSTCLM.NOTE4RF AS CSTCLMNOTE4RF," + Environment.NewLine);
            sb.Append("CSTCLM.NOTE5RF AS CSTCLMNOTE5RF," + Environment.NewLine);
            sb.Append("CSTCLM.NOTE6RF AS CSTCLMNOTE6RF," + Environment.NewLine);
            sb.Append("CSTCLM.NOTE7RF AS CSTCLMNOTE7RF," + Environment.NewLine);
            sb.Append("CSTCLM.NOTE8RF AS CSTCLMNOTE8RF," + Environment.NewLine);
            sb.Append("CSTCLM.NOTE9RF AS CSTCLMNOTE9RF," + Environment.NewLine);
            sb.Append("CSTCLM.NOTE10RF AS CSTCLMNOTE10RF," + Environment.NewLine);
            sb.Append("CSTCST.CUSTOMERSUBCODERF AS CSTCSTCUSTOMERSUBCODERF," + Environment.NewLine);
            sb.Append("CSTCST.NAMERF AS CSTCSTNAMERF," + Environment.NewLine);
            sb.Append("CSTCST.NAME2RF AS CSTCSTNAME2RF," + Environment.NewLine);
            sb.Append("CSTCST.HONORIFICTITLERF AS CSTCSTHONORIFICTITLERF," + Environment.NewLine);
            sb.Append("CSTCST.KANARF AS CSTCSTKANARF," + Environment.NewLine);
            sb.Append("CSTCST.CUSTOMERSNMRF AS CSTCSTCUSTOMERSNMRF," + Environment.NewLine);
            sb.Append("CSTCST.OUTPUTNAMECODERF AS CSTCSTOUTPUTNAMECODERF," + Environment.NewLine);
            sb.Append("CSTCST.CUSTANALYSCODE1RF AS CSTCSTCUSTANALYSCODE1RF," + Environment.NewLine);
            sb.Append("CSTCST.CUSTANALYSCODE2RF AS CSTCSTCUSTANALYSCODE2RF," + Environment.NewLine);
            sb.Append("CSTCST.CUSTANALYSCODE3RF AS CSTCSTCUSTANALYSCODE3RF," + Environment.NewLine);
            sb.Append("CSTCST.CUSTANALYSCODE4RF AS CSTCSTCUSTANALYSCODE4RF," + Environment.NewLine);
            sb.Append("CSTCST.CUSTANALYSCODE5RF AS CSTCSTCUSTANALYSCODE5RF," + Environment.NewLine);
            sb.Append("CSTCST.CUSTANALYSCODE6RF AS CSTCSTCUSTANALYSCODE6RF," + Environment.NewLine);
            sb.Append("CSTCST.NOTE1RF AS CSTCSTNOTE1RF," + Environment.NewLine);
            sb.Append("CSTCST.NOTE2RF AS CSTCSTNOTE2RF," + Environment.NewLine);
            sb.Append("CSTCST.NOTE3RF AS CSTCSTNOTE3RF," + Environment.NewLine);
            sb.Append("CSTCST.NOTE4RF AS CSTCSTNOTE4RF," + Environment.NewLine);
            sb.Append("CSTCST.NOTE5RF AS CSTCSTNOTE5RF," + Environment.NewLine);
            sb.Append("CSTCST.NOTE6RF AS CSTCSTNOTE6RF," + Environment.NewLine);
            sb.Append("CSTCST.NOTE7RF AS CSTCSTNOTE7RF," + Environment.NewLine);
            sb.Append("CSTCST.NOTE8RF AS CSTCSTNOTE8RF," + Environment.NewLine);
            sb.Append("CSTCST.NOTE9RF AS CSTCSTNOTE9RF," + Environment.NewLine);
            sb.Append("CSTCST.NOTE10RF AS CSTCSTNOTE10RF," + Environment.NewLine);
            // ---- ADD caohh 20111/08/17 ------>>>>>
            sb.Append("CSTCST.POSTNORF AS CSTCSTPOSTNORF," + Environment.NewLine);
            sb.Append("CSTCST.ADDRESS1RF AS CSTCSTADDRESS1RF," + Environment.NewLine);
            sb.Append("CSTCST.ADDRESS3RF AS CSTCSTADDRESS3RF," + Environment.NewLine);
            sb.Append("CSTCST.ADDRESS4RF AS CSTCSTADDRESS4RF," + Environment.NewLine);
            sb.Append("CSTCST.HOMETELNORF AS CSTCSTHOMETELNORF," + Environment.NewLine);
            sb.Append("CSTCST.OFFICETELNORF AS CSTCSTOFFICETELNORF," + Environment.NewLine);
            sb.Append("CSTCST.PORTABLETELNORF AS CSTCSTPORTABLETELNORF," + Environment.NewLine);
            sb.Append("CSTCST.OTHERSTELNORF AS CSTCSTOTHERSTELNORF," + Environment.NewLine);
            sb.Append("CSTCST.HOMEFAXNORF AS CSTCSTHOMEFAXNORF," + Environment.NewLine);
            sb.Append("CSTCST.OFFICEFAXNORF AS CSTCSTOFFICEFAXNORF," + Environment.NewLine);
            // ---- ADD caohh 20111/08/17 ------<<<<<
            sb.Append("CSTADR.CUSTOMERSUBCODERF AS CSTADRCUSTOMERSUBCODERF," + Environment.NewLine);
            sb.Append("CSTADR.NAMERF AS CSTADRNAMERF," + Environment.NewLine);
            sb.Append("CSTADR.NAME2RF AS CSTADRNAME2RF," + Environment.NewLine);
            sb.Append("CSTADR.HONORIFICTITLERF AS CSTADRHONORIFICTITLERF," + Environment.NewLine);
            sb.Append("CSTADR.KANARF AS CSTADRKANARF," + Environment.NewLine);
            sb.Append("CSTADR.CUSTOMERSNMRF AS CSTADRCUSTOMERSNMRF," + Environment.NewLine);
            sb.Append("CSTADR.OUTPUTNAMECODERF AS CSTADROUTPUTNAMECODERF," + Environment.NewLine);
            sb.Append("CSTADR.CUSTANALYSCODE1RF AS CSTADRCUSTANALYSCODE1RF," + Environment.NewLine);
            sb.Append("CSTADR.CUSTANALYSCODE2RF AS CSTADRCUSTANALYSCODE2RF," + Environment.NewLine);
            sb.Append("CSTADR.CUSTANALYSCODE3RF AS CSTADRCUSTANALYSCODE3RF," + Environment.NewLine);
            sb.Append("CSTADR.CUSTANALYSCODE4RF AS CSTADRCUSTANALYSCODE4RF," + Environment.NewLine);
            sb.Append("CSTADR.CUSTANALYSCODE5RF AS CSTADRCUSTANALYSCODE5RF," + Environment.NewLine);
            sb.Append("CSTADR.CUSTANALYSCODE6RF AS CSTADRCUSTANALYSCODE6RF," + Environment.NewLine);
            sb.Append("CSTADR.NOTE1RF AS CSTADRNOTE1RF," + Environment.NewLine);
            sb.Append("CSTADR.NOTE2RF AS CSTADRNOTE2RF," + Environment.NewLine);
            sb.Append("CSTADR.NOTE3RF AS CSTADRNOTE3RF," + Environment.NewLine);
            sb.Append("CSTADR.NOTE4RF AS CSTADRNOTE4RF," + Environment.NewLine);
            sb.Append("CSTADR.NOTE5RF AS CSTADRNOTE5RF," + Environment.NewLine);
            sb.Append("CSTADR.NOTE6RF AS CSTADRNOTE6RF," + Environment.NewLine);
            sb.Append("CSTADR.NOTE7RF AS CSTADRNOTE7RF," + Environment.NewLine);
            sb.Append("CSTADR.NOTE8RF AS CSTADRNOTE8RF," + Environment.NewLine);
            sb.Append("CSTADR.NOTE9RF AS CSTADRNOTE9RF," + Environment.NewLine);
            sb.Append("CSTADR.NOTE10RF AS CSTADRNOTE10RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.COMPANYNAME1RF AS COMPANYINFRFCOMPANYNAME1RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.COMPANYNAME2RF AS COMPANYINFRFCOMPANYNAME2RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.POSTNORF AS COMPANYINFRFPOSTNORF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.ADDRESS1RF AS COMPANYINFRFADDRESS1RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.ADDRESS3RF AS COMPANYINFRFADDRESS3RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.ADDRESS4RF AS COMPANYINFRFADDRESS4RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.COMPANYTELNO1RF AS COMPANYINFRFCOMPANYTELNO1RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.COMPANYTELNO2RF AS COMPANYINFRFCOMPANYTELNO2RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.COMPANYTELNO3RF AS COMPANYINFRFCOMPANYTELNO3RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.COMPANYTELTITLE1RF AS COMPANYINFRFCOMPANYTELTITLE1RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.COMPANYTELTITLE2RF AS COMPANYINFRFCOMPANYTELTITLE2RF," + Environment.NewLine);
            sb.Append("COMPANYINFRF.COMPANYTELTITLE3RF AS COMPANYINFRFCOMPANYTELTITLE3RF,");
            sb.Append("SALESHISTORYRF.RESULTSADDUPSECCDRF," + Environment.NewLine);
            sb.Append("SALESHISTORYRF.SLIPNOTE3RF," + Environment.NewLine);
            sb.Append(" SALESHISTORYRF.UPDATEDATETIMERF, " + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.CUSTOMERCODERF AS SANCUSTOMERCODERF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.ADDRESSEESHOPCDRF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.SANDEMNGCODERF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.EXPENSEDIVCDRF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.DIRECTSENDINGCDRF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.ACPTANORDERDIVRF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.DELIVERERCDRF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.DELIVERERNMRF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.DELIVERERADDRESSRF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.DELIVERERPHONENUMRF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.TRADCOMPNAMERF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.TRADCOMPSECTNAMERF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.PURETRADCOMPCDRF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.PURETRADCOMPRATERF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.PRITRADCOMPCDRF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.PRITRADCOMPRATERF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.ABGOODSCODERF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.COMMENTRESERVEDDIVRF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.GOODSMAKERCD1RF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.GOODSMAKERCD2RF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.GOODSMAKERCD3RF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.GOODSMAKERCD4RF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.GOODSMAKERCD5RF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.GOODSMAKERCD6RF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.GOODSMAKERCD7RF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.GOODSMAKERCD8RF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.GOODSMAKERCD9RF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.GOODSMAKERCD10RF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.GOODSMAKERCD11RF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.GOODSMAKERCD12RF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.GOODSMAKERCD13RF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.GOODSMAKERCD14RF," + Environment.NewLine);
            sb.Append(" SANDESETTINGRF.GOODSMAKERCD15RF," + Environment.NewLine);
            // --- DEL  大矢睦美  2010/03/01 ---------->>>>>
            //sb.Append(" SANDESETTINGRF.PARTSOEMDIVRF" + Environment.NewLine);//←最後はカンマなし
            // --- DEL  大矢睦美  2010/03/01 ----------<<<<<
            // --- ADD  汪千来  2009.07.27 ----------<<<<<
            // --- ADD  大矢睦美  2010/03/01 ---------->>>>>            
            sb.Append(" SANDESETTINGRF.PARTSOEMDIVRF," + Environment.NewLine);
            sb.Append(" CSTCST.SALESUNPRCFRCPROCCDRF," + Environment.NewLine);
            sb.Append(" CSTCST.SALESMONEYFRCPROCCDRF," + Environment.NewLine);
            // --- UPD m.suzuki 2010/03/24 ---------->>>>>
            //sb.Append(" CSTCST.SALESCNSTAXFRCPROCCDRF" + Environment.NewLine);            
            sb.Append(" CSTCST.SALESCNSTAXFRCPROCCDRF," + Environment.NewLine);
            // --- UPD m.suzuki 2010/03/24 ----------<<<<<
            // --- ADD  大矢睦美  2010/03/01 ----------<<<<<
            // --- ADD m.suzuki 2010/03/24 ---------->>>>>
            // 2010/07/06 >>>
            //sb.Append(" CSTCST.QRCODEPRTCDRF" + Environment.NewLine);
            sb.Append(" CSTCST.QRCODEPRTCDRF," + Environment.NewLine);
            // 2010/07/06 <<<
            // --- ADD m.suzuki 2010/03/24 ----------<<<<<
            // 2010/07/06 Add >>>
            sb.Append(" SALESHISTORYRF.FILEHEADERGUIDRF" + Environment.NewLine);
            // 2010/07/06 Add <<<
            # endregion
            return sb.ToString();
        }

        /// <summary>
        /// WHERE文作成処理
        /// </summary>
        /// <param name="sqlCommand">SQLコマンド</param>
        /// <param name="extPrm">自由帳票共通抽出条件クラス</param>
        /// <returns>WHERE文</returns>
        /// <br>Note		: 売上データの伝票情報が取得できない場合は、売上履歴データを読み込んで伝票情報を取得するようにする。</br>
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2010/06/08</br>
        private string MakeWhereStringForHistory(ref SqlCommand sqlCommand, FrePSalesSlipParaWork extPrm)
        {
            StringBuilder whereString = new StringBuilder();
            //SFANL08309CA gene = new SFANL08309CA();

            // 企業コードは必須条件
            whereString.Append(" WHERE SALESHISTORYRF.ENTERPRISECODERF=@FINDENTERPRISECODE ");
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findParaEnterpriseCode.Value = extPrm.EnterpriseCode;

            // 受注ステータスと伝票番号
            List<SqlParameter> acptList = new List<SqlParameter>();
            List<SqlParameter> slipNumList = new List<SqlParameter>();

            whereString.Append(" AND ( ");
            for (int index = 0; index < extPrm.FrePSalesSlipParaKeyList.Count; index++)
            {
                if (index > 0)
                {
                    whereString.Append(" OR ");
                }

                // WHERE
                whereString.Append(string.Format("(SALESHISTORYRF.ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS{0} AND SALESHISTORYRF.SALESSLIPNUMRF=@FINDSALESSLIPNUM{0})", index));

                // 受注ステータス
                SqlParameter paraAcpt = sqlCommand.Parameters.Add(string.Format("@FINDACPTANODRSTATUS{0}", index), SqlDbType.Int);
                paraAcpt.Value = extPrm.FrePSalesSlipParaKeyList[index].AcptAnOdrStatus;
                acptList.Add(paraAcpt);

                // 伝票番号
                SqlParameter paraSlipNum = sqlCommand.Parameters.Add(string.Format("@FINDSALESSLIPNUM{0}", index), SqlDbType.NChar);
                paraSlipNum.Value = extPrm.FrePSalesSlipParaKeyList[index].SalesSlipNum;
                slipNumList.Add(paraSlipNum);

                whereString.Append(Environment.NewLine);
            }
            whereString.Append(" ) " + Environment.NewLine);

            return whereString.ToString();
        }

        // -------ADD 2010/06/08-------<<<<<

        /// <summary>
        /// WHERE文作成処理
        /// </summary>
        /// <param name="sqlCommand">SQLコマンド</param>
        /// <param name="extPrm">自由帳票共通抽出条件クラス</param>
        /// <returns>WHERE文</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, FrePSalesSlipParaWork extPrm)
        {
            StringBuilder whereString = new StringBuilder();
            //SFANL08309CA gene = new SFANL08309CA();

            // 企業コードは必須条件
            whereString.Append(" WHERE SALESSLIPRF.ENTERPRISECODERF=@FINDENTERPRISECODE ");
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findParaEnterpriseCode.Value = extPrm.EnterpriseCode;

            // 受注ステータスと伝票番号
            List<SqlParameter> acptList = new List<SqlParameter>();
            List<SqlParameter> slipNumList = new List<SqlParameter>();

            whereString.Append(" AND ( ");
            for (int index = 0; index < extPrm.FrePSalesSlipParaKeyList.Count; index++)
            {
                if (index > 0)
                {
                    whereString.Append(" OR ");
                }

                // WHERE
                whereString.Append(string.Format("(SALESSLIPRF.ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS{0} AND SALESSLIPRF.SALESSLIPNUMRF=@FINDSALESSLIPNUM{0})", index));

                // 受注ステータス
                SqlParameter paraAcpt = sqlCommand.Parameters.Add(string.Format("@FINDACPTANODRSTATUS{0}", index), SqlDbType.Int);
                paraAcpt.Value = extPrm.FrePSalesSlipParaKeyList[index].AcptAnOdrStatus;
                acptList.Add(paraAcpt);

                // 伝票番号
                SqlParameter paraSlipNum = sqlCommand.Parameters.Add(string.Format("@FINDSALESSLIPNUM{0}", index), SqlDbType.NChar);
                paraSlipNum.Value = extPrm.FrePSalesSlipParaKeyList[index].SalesSlipNum;
                slipNumList.Add(paraSlipNum);

                whereString.Append(Environment.NewLine);
            }
            whereString.Append(" ) " + Environment.NewLine);

            return whereString.ToString();
        }
        /// <summary>
        /// 抽出項目取得処理（明細用）
        /// </summary>
        /// <param name="extPrm"></param>
        /// <returns></returns>
        /// <br>Update Note:   2020/03/18 寺田義啓</br>
        /// <br>管理番号   :   11670121-00 S＆E改良対応</br>
        private string GetSelectItemsForDetail(FrePSalesSlipParaWork extPrm)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 注意：同じテーブルを複数回JOINする場合は、Selectに与える項目名称もAsで別名にする。
            StringBuilder sb = new StringBuilder();
            # region [項目名]
            sb.Append("SALESDETAILRF.ACPTANODRSTATUSRF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.SALESSLIPNUMRF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.ACCEPTANORDERNORF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.SALESROWNORF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.SALESDATERF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.COMMONSEQNORF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.SALESSLIPDTLNUMRF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.ACPTANODRSTATUSSRCRF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.SALESSLIPDTLNUMSRCRF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.SUPPLIERFORMALSYNCRF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.STOCKSLIPDTLNUMSYNCRF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.SALESSLIPCDDTLRF," + Environment.NewLine);
            //sb.Append( "SALESDETAILRF.STOCKMNGEXISTCDRF," + Environment.NewLine );
            sb.Append("SALESDETAILRF.DELIGDSCMPLTDUEDATERF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.GOODSKINDCODERF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.GOODSMAKERCDRF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.MAKERNAMERF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.GOODSNORF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.GOODSNAMERF," + Environment.NewLine);
            //sb.Append( "SALESDETAILRF.GOODSSHORTNAMERF," + Environment.NewLine );
            //sb.Append( "SALESDETAILRF.LARGEGOODSGANRECODERF," + Environment.NewLine );
            //sb.Append( "SALESDETAILRF.LARGEGOODSGANRENAMERF," + Environment.NewLine );
            //sb.Append( "SALESDETAILRF.MEDIUMGOODSGANRECODERF," + Environment.NewLine );
            //sb.Append( "SALESDETAILRF.MEDIUMGOODSGANRENAMERF," + Environment.NewLine );
            //sb.Append( "SALESDETAILRF.DETAILGOODSGANRECODERF," + Environment.NewLine );
            //sb.Append( "SALESDETAILRF.DETAILGOODSGANRENAMERF," + Environment.NewLine );
            sb.Append("SALESDETAILRF.BLGOODSCODERF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.BLGOODSFULLNAMERF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.ENTERPRISEGANRECODERF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.ENTERPRISEGANRENAMERF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.WAREHOUSECODERF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.WAREHOUSENAMERF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.WAREHOUSESHELFNORF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.SALESORDERDIVCDRF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.OPENPRICEDIVRF," + Environment.NewLine);
            //sb.Append( "SALESDETAILRF.UNITCODERF," + Environment.NewLine );
            //sb.Append( "SALESDETAILRF.UNITNAMERF," + Environment.NewLine );
            sb.Append("SALESDETAILRF.GOODSRATERANKRF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.CUSTRATEGRPCODERF," + Environment.NewLine);
            //sb.Append( "SALESDETAILRF.SUPPRATEGRPCODERF," + Environment.NewLine );
            sb.Append("SALESDETAILRF.LISTPRICERATERF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.LISTPRICETAXINCFLRF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.LISTPRICETAXEXCFLRF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.LISTPRICECHNGCDRF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.SALESRATERF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.SALESUNPRCTAXINCFLRF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.SALESUNPRCTAXEXCFLRF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.COSTRATERF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.SALESUNITCOSTRF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.SHIPMENTCNTRF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.ACCEPTANORDERCNTRF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.ACPTANODRADJUSTCNTRF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.ACPTANODRREMAINCNTRF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.REMAINCNTUPDDATERF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.SALESMONEYTAXINCRF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.SALESMONEYTAXEXCRF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.COSTRF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.GRSPROFITCHKDIVRF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.SALESGOODSCDRF," + Environment.NewLine);
            //sb.Append( "SALESDETAILRF.SALSEPRICECONSTAXRF," + Environment.NewLine );
            sb.Append("SALESDETAILRF.TAXATIONDIVCDRF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.PARTYSLIPNUMDTLRF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.DTLNOTERF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.SUPPLIERCDRF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.SUPPLIERSNMRF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.ORDERNUMBERRF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.SLIPMEMO1RF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.SLIPMEMO2RF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.SLIPMEMO3RF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.INSIDEMEMO1RF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.INSIDEMEMO2RF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.INSIDEMEMO3RF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.BFLISTPRICERF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.BFSALESUNITPRICERF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.BFUNITCOSTRF," + Environment.NewLine);
            //sb.Append( "SALESDETAILRF.PRTGOODSNORF," + Environment.NewLine );
            //sb.Append( "SALESDETAILRF.PRTGOODSNAMERF," + Environment.NewLine );
            //sb.Append( "SALESDETAILRF.PRTGOODSMAKERCDRF," + Environment.NewLine );
            //sb.Append( "SALESDETAILRF.PRTGOODSMAKERNMRF," + Environment.NewLine );
            //sb.Append( "SALESDETAILRF.CONTRACTDIVCDDTLRF," + Environment.NewLine );
            sb.Append("SALESDETAILRF.CMPLTSALESROWNORF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.CMPLTGOODSMAKERCDRF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.CMPLTMAKERNAMERF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.CMPLTGOODSNAMERF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.CMPLTSHIPMENTCNTRF," + Environment.NewLine);
            //sb.Append( "SALESDETAILRF.CMPLTUNITCODERF," + Environment.NewLine );
            //sb.Append( "SALESDETAILRF.CMPLTUNITNAMERF," + Environment.NewLine );
            sb.Append("SALESDETAILRF.CMPLTSALESUNPRCFLRF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.CMPLTSALESMONEYRF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.CMPLTSALESUNITCOSTRF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.CMPLTCOSTRF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.CMPLTPARTYSALSLNUMRF," + Environment.NewLine);
            sb.Append("SALESDETAILRF.CMPLTNOTERF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.CARMNGNORF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.CARMNGCODERF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.NUMBERPLATE1CODERF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.NUMBERPLATE1NAMERF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.NUMBERPLATE2RF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.NUMBERPLATE3RF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.NUMBERPLATE4RF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.FIRSTENTRYDATERF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.MAKERCODERF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.MAKERFULLNAMERF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.MODELCODERF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.MODELSUBCODERF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.MODELFULLNAMERF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.EXHAUSTGASSIGNRF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.SERIESMODELRF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.CATEGORYSIGNMODELRF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.FULLMODELRF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.MODELDESIGNATIONNORF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.CATEGORYNORF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.FRAMEMODELRF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.FRAMENORF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.SEARCHFRAMENORF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.ENGINEMODELNMRF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.RELEVANCEMODELRF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.SUBCARNMCDRF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.MODELGRADESNAMERF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.COLORCODERF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.COLORNAME1RF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.TRIMCODERF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.TRIMNAMERF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.MILEAGERF," + Environment.NewLine);
            sb.Append("MAKGDS.MAKERSHORTNAMERF AS MAKGDSMAKERSHORTNAMERF," + Environment.NewLine);
            sb.Append("MAKGDS.MAKERKANANAMERF AS MAKGDSMAKERKANANAMERF," + Environment.NewLine);
            sb.Append("MAKGDS.GOODSMAKERCDRF AS MAKGDSGOODSMAKERCDRF," + Environment.NewLine);
            sb.Append("MAKCMP.MAKERSHORTNAMERF AS MAKCMPMAKERSHORTNAMERF," + Environment.NewLine);
            sb.Append("MAKCMP.MAKERKANANAMERF AS MAKCMPMAKERKANANAMERF," + Environment.NewLine);
            sb.Append("MAKCMP.GOODSMAKERCDRF AS MAKCMPGOODSMAKERCDRF," + Environment.NewLine);
            sb.Append("GOODSURF.GOODSNAMEKANARF AS GOODSURFGOODSNAMEKANARF," + Environment.NewLine);
            sb.Append("GOODSURF.JANRF AS GOODSURFJANRF," + Environment.NewLine);
            sb.Append("GOODSURF.GOODSRATERANKRF AS GOODSURFGOODSRATERANKRF," + Environment.NewLine);
            sb.Append("GOODSURF.GOODSNONONEHYPHENRF AS GOODSURFGOODSNONONEHYPHENRF," + Environment.NewLine);
            sb.Append("GOODSURF.GOODSNOTE1RF AS GOODSURFGOODSNOTE1RF," + Environment.NewLine);
            sb.Append("GOODSURF.GOODSNOTE2RF AS GOODSURFGOODSNOTE2RF," + Environment.NewLine);
            sb.Append("GOODSURF.GOODSSPECIALNOTERF AS GOODSURFGOODSSPECIALNOTERF," + Environment.NewLine);
            sb.Append("STOCKRF.SHIPMENTPOSCNTRF," + Environment.NewLine);
            sb.Append("STOCKRF.DUPLICATIONSHELFNO1RF," + Environment.NewLine);
            sb.Append("STOCKRF.DUPLICATIONSHELFNO2RF," + Environment.NewLine);
            sb.Append("STOCKRF.PARTSMANAGEMENTDIVIDE1RF," + Environment.NewLine);
            sb.Append("STOCKRF.PARTSMANAGEMENTDIVIDE2RF," + Environment.NewLine);
            sb.Append("STOCKRF.STOCKNOTE1RF," + Environment.NewLine);
            sb.Append("STOCKRF.STOCKNOTE2RF," + Environment.NewLine);
            sb.Append("WAREHOUSERF.WAREHOUSENOTE1RF," + Environment.NewLine);
            sb.Append("USRCSG.GUIDENAMERF AS USRCSGGUIDENAMERF," + Environment.NewLine);
            //sb.Append( "USRSPG.GUIDENAMERF AS USRSPGGUIDENAMERF," + Environment.NewLine );
            sb.Append("SUPPLIERRF.SUPPLIERCDRF," + Environment.NewLine);
            sb.Append("SUPPLIERRF.SUPPLIERNM1RF," + Environment.NewLine);
            sb.Append("SUPPLIERRF.SUPPLIERNM2RF," + Environment.NewLine);
            sb.Append("SUPPLIERRF.SUPPHONORIFICTITLERF," + Environment.NewLine);
            sb.Append("SUPPLIERRF.SUPPLIERKANARF," + Environment.NewLine);
            sb.Append("SUPPLIERRF.PURECODERF," + Environment.NewLine);
            sb.Append("SUPPLIERRF.SUPPLIERNOTE1RF," + Environment.NewLine);
            sb.Append("SUPPLIERRF.SUPPLIERNOTE2RF," + Environment.NewLine);
            sb.Append("SUPPLIERRF.SUPPLIERNOTE3RF," + Environment.NewLine);
            sb.Append("SUPPLIERRF.SUPPLIERNOTE4RF," + Environment.NewLine);
            sb.Append("BLGOODSCDURF.BLGOODSCODERF," + Environment.NewLine);
            sb.Append("BLGOODSCDURF.BLGOODSHALFNAMERF, " + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.MAKERHALFNAMERF, " + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.MODELHALFNAMERF, " + Environment.NewLine);
            sb.Append("SALESDETAILRF.PRTBLGOODSCODERF, " + Environment.NewLine);
            sb.Append("SALESDETAILRF.PRTBLGOODSNAMERF, " + Environment.NewLine);
            sb.Append("SALESDETAILRF.PRTGOODSNORF, " + Environment.NewLine);
            sb.Append("SALESDETAILRF.PRTMAKERCODERF, " + Environment.NewLine);
            sb.Append("SALESDETAILRF.PRTMAKERNAMERF, " + Environment.NewLine);
            sb.Append("MAKPRT.MAKERKANANAMERF AS MAKPRTMAKERKANANAMERF, " + Environment.NewLine);
            sb.Append("SALESDETAILRF.GOODSLGROUPRF, " + Environment.NewLine);
            sb.Append("SALESDETAILRF.GOODSLGROUPNAMERF, " + Environment.NewLine);
            sb.Append("SALESDETAILRF.GOODSMGROUPRF, " + Environment.NewLine);
            sb.Append("SALESDETAILRF.GOODSMGROUPNAMERF, " + Environment.NewLine);
            sb.Append("SALESDETAILRF.BLGROUPCODERF, " + Environment.NewLine);
            sb.Append("SALESDETAILRF.BLGROUPNAMERF, " + Environment.NewLine);
            sb.Append("SALESDETAILRF.SALESCODERF, " + Environment.NewLine);
            sb.Append("SALESDETAILRF.GOODSNAMEKANARF," + Environment.NewLine);
            // --- UPDATE  汪千来  2009.07.27 ---------->>>>>
            sb.Append("SALESDETAILRF.SALESCDNMRF, " + Environment.NewLine);
            sb.Append("SALESDETAILRF.AUTOANSWERDIVSCMRF, " + Environment.NewLine);// ADD 2011/07/19
            // --- UPD 寺田義啓 2020.03.18 ---------->>>>>
            //// --- ADD  汪千来  2009.07.27 ---------->>>>>
            //sb.Append("SANDEGOODSCDCHGRF.ABGOODSCODERF, " + Environment.NewLine);
            //// --- ADD  汪千来  2009.07.27 ----------<<<<<                
            sb.Append("ISNULL(SANDEMKRGDSCDCHGRF.ABGOODSCODERF, SANDEGOODSCDCHGRF.ABGOODSCODERF) AS ABGOODSCODERF, " + Environment.NewLine);
            // --- UPD 寺田義啓 2020.03.18 ----------<<<<<
            // add by zhouzy for PCCUOEリモート伝票発行 20110811 begin
            sb.Append("SALESDETAILRF.ACCEPTORORDERKINDRF, " + Environment.NewLine);
            sb.Append("SALESDETAILRF.INQUIRYNUMBERRF, " + Environment.NewLine);
            sb.Append("SALESDETAILRF.INQROWNUMBERRF " + Environment.NewLine);// ←最後の項目はカンマ無し
            // add by zhouzy for PCCUOEリモート伝票発行 20110811  end

            
            # endregion
            return sb.ToString();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }
        /// <summary>
        /// WHERE分生成処理（明細用）
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="extPrm"></param>
        /// <returns></returns>
        private string MakeWhereStringForDetail(ref SqlCommand sqlCommand, FrePSalesSlipParaWork extPrm)
        {
            StringBuilder whereString = new StringBuilder();
            //SFANL08309CA gene = new SFANL08309CA();

            // 企業コードは必須条件
            whereString.Append(" WHERE SALESDETAILRF.ENTERPRISECODERF=@FINDENTERPRISECODE ");
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findParaEnterpriseCode.Value = extPrm.EnterpriseCode;

            // 受注ステータスと伝票番号
            List<SqlParameter> acptList = new List<SqlParameter>();
            List<SqlParameter> slipNumList = new List<SqlParameter>();

            whereString.Append(" AND ( ");
            for (int index = 0; index < extPrm.FrePSalesSlipParaKeyList.Count; index++)
            {
                if (index > 0)
                {
                    whereString.Append(" OR ");
                }

                // WHERE
                whereString.Append(string.Format("(SALESDETAILRF.ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS{0} AND SALESDETAILRF.SALESSLIPNUMRF=@FINDSALESSLIPNUM{0})", index));

                // 受注ステータス
                SqlParameter paraAcpt = sqlCommand.Parameters.Add(string.Format("@FINDACPTANODRSTATUS{0}", index), SqlDbType.Int);
                paraAcpt.Value = extPrm.FrePSalesSlipParaKeyList[index].AcptAnOdrStatus;
                acptList.Add(paraAcpt);

                // 伝票番号
                SqlParameter paraSlipNum = sqlCommand.Parameters.Add(string.Format("@FINDSALESSLIPNUM{0}", index), SqlDbType.NChar);
                paraSlipNum.Value = extPrm.FrePSalesSlipParaKeyList[index].SalesSlipNum;
                slipNumList.Add(paraSlipNum);

                whereString.Append(Environment.NewLine);
            }
            whereString.Append(" ) " + Environment.NewLine);

            return whereString.ToString();
        }
        // -------ADD 2010/06/08------->>>>>
        /// <summary>
        /// 抽出項目取得処理（明細用）
        /// </summary>
        /// <param name="extPrm"></param>
        /// <returns></returns>
        /// <br>Note		: 売上明細データの伝票情報が取得できない場合は、売上履歴明細データを読み込んで伝票情報を取得するようにする。</br>
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2010/06/08</br>
        /// <br>Update Note :   2020/03/18 寺田義啓</br>
        /// <br>管理番号    :   11670121-00 S＆E改良対応</br>
        private string GetSelectItemsForDetailHistory(FrePSalesSlipParaWork extPrm)
        {
            // 注意：同じテーブルを複数回JOINする場合は、Selectに与える項目名称もAsで別名にする。
            StringBuilder sb = new StringBuilder();
            # region [項目名]
            sb.Append("SALESHISTDTLRF.ACPTANODRSTATUSRF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.SALESSLIPNUMRF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.ACCEPTANORDERNORF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.SALESROWNORF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.SALESDATERF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.COMMONSEQNORF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.SALESSLIPDTLNUMRF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.ACPTANODRSTATUSSRCRF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.SALESSLIPDTLNUMSRCRF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.SUPPLIERFORMALSYNCRF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.STOCKSLIPDTLNUMSYNCRF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.SALESSLIPCDDTLRF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.GOODSKINDCODERF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.GOODSMAKERCDRF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.MAKERNAMERF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.GOODSNORF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.GOODSNAMERF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.BLGOODSCODERF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.BLGOODSFULLNAMERF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.ENTERPRISEGANRECODERF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.ENTERPRISEGANRENAMERF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.WAREHOUSECODERF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.WAREHOUSENAMERF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.WAREHOUSESHELFNORF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.SALESORDERDIVCDRF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.OPENPRICEDIVRF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.GOODSRATERANKRF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.CUSTRATEGRPCODERF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.LISTPRICERATERF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.LISTPRICETAXINCFLRF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.LISTPRICETAXEXCFLRF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.LISTPRICECHNGCDRF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.SALESRATERF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.SALESUNPRCTAXINCFLRF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.SALESUNPRCTAXEXCFLRF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.COSTRATERF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.SALESUNITCOSTRF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.SHIPMENTCNTRF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.SALESMONEYTAXINCRF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.SALESMONEYTAXEXCRF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.COSTRF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.GRSPROFITCHKDIVRF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.SALESGOODSCDRF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.TAXATIONDIVCDRF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.PARTYSLIPNUMDTLRF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.DTLNOTERF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.SUPPLIERCDRF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.SUPPLIERSNMRF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.ORDERNUMBERRF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.SLIPMEMO1RF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.SLIPMEMO2RF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.SLIPMEMO3RF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.INSIDEMEMO1RF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.INSIDEMEMO2RF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.INSIDEMEMO3RF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.BFLISTPRICERF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.BFSALESUNITPRICERF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.BFUNITCOSTRF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.CMPLTSALESROWNORF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.CMPLTGOODSMAKERCDRF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.CMPLTMAKERNAMERF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.CMPLTGOODSNAMERF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.CMPLTSHIPMENTCNTRF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.CMPLTSALESUNPRCFLRF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.CMPLTSALESMONEYRF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.CMPLTSALESUNITCOSTRF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.CMPLTCOSTRF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.CMPLTPARTYSALSLNUMRF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.CMPLTNOTERF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.CARMNGNORF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.CARMNGCODERF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.NUMBERPLATE1CODERF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.NUMBERPLATE1NAMERF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.NUMBERPLATE2RF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.NUMBERPLATE3RF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.NUMBERPLATE4RF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.FIRSTENTRYDATERF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.MAKERCODERF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.MAKERFULLNAMERF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.MODELCODERF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.MODELSUBCODERF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.MODELFULLNAMERF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.EXHAUSTGASSIGNRF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.SERIESMODELRF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.CATEGORYSIGNMODELRF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.FULLMODELRF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.MODELDESIGNATIONNORF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.CATEGORYNORF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.FRAMEMODELRF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.FRAMENORF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.SEARCHFRAMENORF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.ENGINEMODELNMRF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.RELEVANCEMODELRF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.SUBCARNMCDRF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.MODELGRADESNAMERF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.COLORCODERF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.COLORNAME1RF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.TRIMCODERF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.TRIMNAMERF," + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.MILEAGERF," + Environment.NewLine);
            sb.Append("MAKGDS.MAKERSHORTNAMERF AS MAKGDSMAKERSHORTNAMERF," + Environment.NewLine);
            sb.Append("MAKGDS.MAKERKANANAMERF AS MAKGDSMAKERKANANAMERF," + Environment.NewLine);
            sb.Append("MAKGDS.GOODSMAKERCDRF AS MAKGDSGOODSMAKERCDRF," + Environment.NewLine);
            sb.Append("MAKCMP.MAKERSHORTNAMERF AS MAKCMPMAKERSHORTNAMERF," + Environment.NewLine);
            sb.Append("MAKCMP.MAKERKANANAMERF AS MAKCMPMAKERKANANAMERF," + Environment.NewLine);
            sb.Append("MAKCMP.GOODSMAKERCDRF AS MAKCMPGOODSMAKERCDRF," + Environment.NewLine);
            sb.Append("GOODSURF.GOODSNAMEKANARF AS GOODSURFGOODSNAMEKANARF," + Environment.NewLine);
            sb.Append("GOODSURF.JANRF AS GOODSURFJANRF," + Environment.NewLine);
            sb.Append("GOODSURF.GOODSRATERANKRF AS GOODSURFGOODSRATERANKRF," + Environment.NewLine);
            sb.Append("GOODSURF.GOODSNONONEHYPHENRF AS GOODSURFGOODSNONONEHYPHENRF," + Environment.NewLine);
            sb.Append("GOODSURF.GOODSNOTE1RF AS GOODSURFGOODSNOTE1RF," + Environment.NewLine);
            sb.Append("GOODSURF.GOODSNOTE2RF AS GOODSURFGOODSNOTE2RF," + Environment.NewLine);
            sb.Append("GOODSURF.GOODSSPECIALNOTERF AS GOODSURFGOODSSPECIALNOTERF," + Environment.NewLine);
            sb.Append("STOCKRF.SHIPMENTPOSCNTRF," + Environment.NewLine);
            sb.Append("STOCKRF.DUPLICATIONSHELFNO1RF," + Environment.NewLine);
            sb.Append("STOCKRF.DUPLICATIONSHELFNO2RF," + Environment.NewLine);
            sb.Append("STOCKRF.PARTSMANAGEMENTDIVIDE1RF," + Environment.NewLine);
            sb.Append("STOCKRF.PARTSMANAGEMENTDIVIDE2RF," + Environment.NewLine);
            sb.Append("STOCKRF.STOCKNOTE1RF," + Environment.NewLine);
            sb.Append("STOCKRF.STOCKNOTE2RF," + Environment.NewLine);
            sb.Append("WAREHOUSERF.WAREHOUSENOTE1RF," + Environment.NewLine);
            sb.Append("USRCSG.GUIDENAMERF AS USRCSGGUIDENAMERF," + Environment.NewLine);
            sb.Append("SUPPLIERRF.SUPPLIERCDRF," + Environment.NewLine);
            sb.Append("SUPPLIERRF.SUPPLIERNM1RF," + Environment.NewLine);
            sb.Append("SUPPLIERRF.SUPPLIERNM2RF," + Environment.NewLine);
            sb.Append("SUPPLIERRF.SUPPHONORIFICTITLERF," + Environment.NewLine);
            sb.Append("SUPPLIERRF.SUPPLIERKANARF," + Environment.NewLine);
            sb.Append("SUPPLIERRF.PURECODERF," + Environment.NewLine);
            sb.Append("SUPPLIERRF.SUPPLIERNOTE1RF," + Environment.NewLine);
            sb.Append("SUPPLIERRF.SUPPLIERNOTE2RF," + Environment.NewLine);
            sb.Append("SUPPLIERRF.SUPPLIERNOTE3RF," + Environment.NewLine);
            sb.Append("SUPPLIERRF.SUPPLIERNOTE4RF," + Environment.NewLine);
            sb.Append("BLGOODSCDURF.BLGOODSCODERF," + Environment.NewLine);
            sb.Append("BLGOODSCDURF.BLGOODSHALFNAMERF, " + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.MAKERHALFNAMERF, " + Environment.NewLine);
            sb.Append("ACCEPTODRCARRF.MODELHALFNAMERF, " + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.PRTBLGOODSCODERF, " + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.PRTBLGOODSNAMERF, " + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.PRTGOODSNORF, " + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.PRTMAKERCODERF, " + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.PRTMAKERNAMERF, " + Environment.NewLine);
            sb.Append("MAKPRT.MAKERKANANAMERF AS MAKPRTMAKERKANANAMERF, " + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.GOODSLGROUPRF, " + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.GOODSLGROUPNAMERF, " + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.GOODSMGROUPRF, " + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.GOODSMGROUPNAMERF, " + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.BLGROUPCODERF, " + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.BLGROUPNAMERF, " + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.SALESCODERF, " + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.GOODSNAMEKANARF," + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.SALESCDNMRF, " + Environment.NewLine);
            sb.Append("SALESHISTDTLRF.AUTOANSWERDIVSCMRF, " + Environment.NewLine);// ADD 2011/07/19
            // --- UPD 寺田義啓 2020.03.18 ---------->>>>>
            //sb.Append("SANDEGOODSCDCHGRF.ABGOODSCODERF " + Environment.NewLine);// ←最後の項目はカンマ無し
            sb.Append("ISNULL(SANDEMKRGDSCDCHGRF.ABGOODSCODERF, SANDEGOODSCDCHGRF.ABGOODSCODERF) AS ABGOODSCODERF " + Environment.NewLine);// ←最後の項目はカンマ無し
            // --- UPD 寺田義啓 2020.03.18 ----------<<<<<

            # endregion
            return sb.ToString();
        }

        /// <summary>
        /// WHERE分生成処理（明細用）
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="extPrm"></param>
        /// <returns></returns>
        /// <br>Note		: 売上明細データの伝票情報が取得できない場合は、売上履歴明細データを読み込んで伝票情報を取得するようにする。</br>
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2010/06/08</br>
        private string MakeWhereStringForDetailHistory(ref SqlCommand sqlCommand, FrePSalesSlipParaWork extPrm)
        {
            StringBuilder whereString = new StringBuilder();

            // 企業コードは必須条件
            whereString.Append(" WHERE SALESHISTDTLRF.ENTERPRISECODERF=@FINDENTERPRISECODE ");
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findParaEnterpriseCode.Value = extPrm.EnterpriseCode;

            // 受注ステータスと伝票番号
            List<SqlParameter> acptList = new List<SqlParameter>();
            List<SqlParameter> slipNumList = new List<SqlParameter>();

            whereString.Append(" AND ( ");
            for (int index = 0; index < extPrm.FrePSalesSlipParaKeyList.Count; index++)
            {
                if (index > 0)
                {
                    whereString.Append(" OR ");
                }

                // WHERE
                whereString.Append(string.Format("(SALESHISTDTLRF.ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS{0} AND SALESHISTDTLRF.SALESSLIPNUMRF=@FINDSALESSLIPNUM{0})", index));

                // 受注ステータス
                SqlParameter paraAcpt = sqlCommand.Parameters.Add(string.Format("@FINDACPTANODRSTATUS{0}", index), SqlDbType.Int);
                paraAcpt.Value = extPrm.FrePSalesSlipParaKeyList[index].AcptAnOdrStatus;
                acptList.Add(paraAcpt);

                // 伝票番号
                SqlParameter paraSlipNum = sqlCommand.Parameters.Add(string.Format("@FINDSALESSLIPNUM{0}", index), SqlDbType.NChar);
                paraSlipNum.Value = extPrm.FrePSalesSlipParaKeyList[index].SalesSlipNum;
                slipNumList.Add(paraSlipNum);

                whereString.Append(Environment.NewLine);
            }
            whereString.Append(" ) " + Environment.NewLine);

            return whereString.ToString();
        }

        // -------ADD 2010/06/08-------<<<<<

        # endregion

        # region [売上伝票キー生成]
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="slipWork"></param>
        private FrePSalesSlipParaWork.FrePSalesSlipParaKey CreateSalesSlipKey(FrePSalesSlipWork slipWork)
        {
            FrePSalesSlipParaWork.FrePSalesSlipParaKey key = new FrePSalesSlipParaWork.FrePSalesSlipParaKey();
            key.AcptAnOdrStatus = slipWork.SALESSLIPRF_ACPTANODRSTATUSRF;
            key.SalesSlipNum = slipWork.SALESSLIPRF_SALESSLIPNUMRF;
            return key;
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="detailWork"></param>
        public FrePSalesSlipParaWork.FrePSalesSlipParaKey CreateSalesSlipKey(FrePSalesDetailWork detailWork)
        {
            FrePSalesSlipParaWork.FrePSalesSlipParaKey key = new FrePSalesSlipParaWork.FrePSalesSlipParaKey();
            key.AcptAnOdrStatus = detailWork.SALESDETAILRF_ACPTANODRSTATUSRF;
            key.SalesSlipNum = detailWork.SALESDETAILRF_SALESSLIPNUMRF;
            return key;
        }
        # endregion

        #endregion
    }
}

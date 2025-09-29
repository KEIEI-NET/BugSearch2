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
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// SCM問い合わせ一覧DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : SCM問い合わせ一覧の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30350 櫻井 亮太</br>
    /// <br>Date       : 2009.05.14</br>
    /// <br></br>
    /// <br>Update Note: MANTIS 14019 ＳＣＭ受注データ取得時、最新の判定に売上伝票番号を追加</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2009.08.13</br>
    /// <br></br>
    /// <br>Update Note: IAAE対応</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2010/03/11</br>
    /// <br></br>
    /// <br>Update Note: SCMリリース対応</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2010/04/13</br>
    /// <br></br>
    /// <br>Update Note: 回答検索時、問合せ・発注種別も抽出する</br>
    /// <br>Programmer : 21024 佐々木 健</br>
    /// <br>Date       : 2010/05/27</br>
    /// <br></br>
    /// <br>Update Note: ①テーブルレイアウト変更対応</br>
    /// <br>             ②最新情報取得時の不具合修正</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2010/06/17</br>
    /// <br></br>
    /// <br>Update Note: 問合せ/発注を別データとして扱う対応</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2011/01/24</br>
    /// <br></br>
    /// <br>Update Note: キャンセルデータの返品対応</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2011/02/18</br>
    /// <br></br>
    /// <br>Update Note: 画面出力項目追加(主: 備考,指示書番号 明細:倉庫, 棚番 )</br>
    /// <br>Programmer : 21112　久保田 誠</br>
    /// <br>Date       : 2011/05/26</br>
    /// <br></br>
    /// <br>Update Note: 抽出条件項目追加(更新日(UpdateDate))</br>
    /// <br>Programmer : 22018　鈴木 正臣</br>
    /// <br>Date       : 2011/06/13</br>
    /// <br>Update Note: Redmine 26534 受発注種別を追加し、PCCforNSとBLパーツオーダーシステムの判断を可能とする</br>
    /// <br>Programmer : 葛中華</br>
    /// <br>Date       : 2011/11/12</br>
    /// <br></br>
    /// <br>Update Note: システムテスト障害№101 同一問合せ番号で複数売上伝票番号の場合の検索条件を変更</br>
    /// <br>Programmer : 30744　湯上 千加子</br>
    /// <br>Date       : 2012/07/18</br>
    /// <br>Update Note: 2012/08/07配信システムテスト障害№126対応 (№101対応時の不具合)</br>
    /// <br>Programmer : 30745　吉岡 孝憲</br>
    /// <br>Date       : 2012/07/27</br>
    /// <br></br>
    /// <br>Update Note: 2012/11/14配信予定 SCM障害№176対応</br>
    /// <br>Programmer : 30744　湯上 千加子</br>
    /// <br>Date       : 2012/10/10</br>
    /// <br></br>
    /// <br>Update Note: SCM障害№10384対応</br>
    /// <br>Programmer : 30744　湯上 千加子</br>
    /// <br>Date       : 2013/05/09</br>
    /// <br></br>
    /// <br>Update Note: 管理番号 10900690-00 配信日なし分 Redmine#34752 「PMSCMのNo.10385」BLPの対応</br>
    /// <br>Programmer : qijh</br>
    /// <br>Date       : 2013/02/27</br>
    /// <br></br>
    /// <br>Update Note: 管理番号 11070266-00 SCM高速化 SCM高速化 C向け種別特記対応 </br>
    /// <br>Programmer : 吉岡</br>
    /// <br>Date       : 2015/02/20</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class SCMInquiryDB : RemoteDB, ISCMInquiryDB
    {
        /// <summary>
        /// SCM問い合わせ一覧DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public SCMInquiryDB()
            :
        base("PMSCM04007D", "Broadleaf.Application.Remoting.ParamData.SCMInquiryResultWork", "SCMACODRDATARF") //基底クラスのコンストラクタ
        {
        }

        #region SCM問合せ一覧

        /// <summary>
        /// 指定された企業コードのSCM問い合わせ一覧のLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="supplierUnmResultWork">検索結果</param>
        /// <param name="supplierUnmOrderCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードのSCM問い合わせ一覧LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2009.05.14</br>
        public int Search(out object scmInquiryResultWork, object objscmInquiryOrderWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            scmInquiryResultWork = null;

            SCMInquiryOrderWork scmInquiryOrderWork = objscmInquiryOrderWork as SCMInquiryOrderWork;
            
            try
            {
                status = SearchProc(out scmInquiryResultWork, scmInquiryOrderWork, readMode, logicalMode);
            }

            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMInquiryDB.Search Exception=" + ex.Message);
                scmInquiryResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードのSCM問い合わせ一覧のLISTを全て戻します
        /// </summary>
        /// <param name="supplierSendErResultWork">検索結果</param>
        /// <param name="_supplierSendErOrderCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードのSCM問い合わせ一覧のLISTを全て戻します</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2009.05.14</br>
        private int SearchProc(out object scmInquiryResultWork, SCMInquiryOrderWork scmInquiryOrderWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            scmInquiryResultWork = null;

            CustomSerializeArrayList retList = new CustomSerializeArrayList(); // 伝票リスト情報抽出結果

            try
            {
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                // 伝票情報抽出
                status = SearchProc(ref retList, ref sqlConnection, scmInquiryOrderWork, logicalMode);

            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMInquiryDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            scmInquiryResultWork = retList;

            return status;
        }

        // -- UPD 2010/04/13 ----------------------------------------------------------->>>
        #region [削除]
        ///// <summary>
        ///// 検索条件文字列生成＋条件値設定
        ///// </summary>
        ///// <param name="al">検索結果ArrayList</param>
        ///// <param name="sqlConnection">SqlConnection</param>
        ///// <param name="_supplierSendErOrderCndtnWork">検索条件格納クラス</param>
        ///// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        ///// <returns>STATUS</returns>
        //private int SearchProc(ref CustomSerializeArrayList retList, ref SqlConnection sqlConnection, SCMInquiryOrderWork scmInquiryOrderWork, ConstantManagement.LogicalMode logicalMode)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
        //    SqlDataReader myReader = null;
        //    SqlCommand sqlCommand = null;

        //    // 伝票リスト
        //    CustomSerializeArrayList SlipList = new CustomSerializeArrayList();

        //    try
        //    {
        //        string selectTxt = "";
        //        sqlCommand = new SqlCommand(selectTxt, sqlConnection);

        //        #region Select文作成
        //        selectTxt += "  SELECT   SCM.CUSTOMERCODERF   " + Environment.NewLine;
        //        selectTxt += "          ,CUS.CUSTOMERSNMRF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.ENTERPRISECODERF  " + Environment.NewLine;
        //        selectTxt += "          ,SCM.ACPTANODRSTATUSRF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.SALESSLIPNUMRF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.INQORIGINALEPCDRF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.INQORIGINALSECCDRF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.INQOTHEREPCDRF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.INQOTHERSECCDRF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.INQUIRYNUMBERRF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.UPDATEDATERF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.UPDATETIMERF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.INQORDDIVCDRF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.ANSWERDIVCDRF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.JUDGEMENTDATERF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.INQORDNOTERF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.APPENDINGFILERF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.APPENDINGFILENMRF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.INQEMPLOYEECDRF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.INQEMPLOYEENMRF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.ANSEMPLOYEECDRF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.ANSEMPLOYEENMRF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.INQUIRYDATERF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.ANSWERCREATEDIVRF  " + Environment.NewLine;
        //        selectTxt += "          ,SCM.SALESTOTALTAXINCRF  " + Environment.NewLine;
        //        selectTxt += "          ,CAR.NUMBERPLATE1CODERF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.NUMBERPLATE1NAMERF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.NUMBERPLATE2RF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.NUMBERPLATE3RF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.NUMBERPLATE4RF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.MODELDESIGNATIONNORF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.CATEGORYNORF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.MAKERCODERF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.MODELCODERF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.MODELSUBCODERF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.MODELNAMERF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.CARINSPECTCERTMODELRF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.FULLMODELRF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.FRAMENORF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.FRAMEMODELRF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.CHASSISNORF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.CARPROPERNORF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.PRODUCETYPEOFYEARNUMRF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.COMMENTRF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.RPCOLORCODERF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.COLORNAME1RF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.TRIMCODERF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.TRIMNAMERF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.MILEAGERF   " + Environment.NewLine;
        //        selectTxt += "   FROM SCMACODRDATARF AS SCM   " + Environment.NewLine;
        //        selectTxt += "    INNER JOIN   " + Environment.NewLine;
        //        selectTxt += "    (   " + Environment.NewLine;
        //        selectTxt += "  	  SELECT    " + Environment.NewLine;
        //        // -- UPD 2010/03/11 -------------------------------------------------->>>
        //        //selectTxt += "  	   MAX(UPDATETIMERF) AS UPDATETIMERF   " + Environment.NewLine;
        //        //selectTxt += "  	  ,MAX(UPDATEDATERF) AS UPDATEDATERF   " + Environment.NewLine;
        //        selectTxt += "  	   MAX(cast(UPDATEDATERF as nvarchar) + cast(UPDATETIMERF as nvarchar)) AS UPDATEDATETIMERF   " + Environment.NewLine;
        //        // -- UPD 2010/03/11 --------------------------------------------------<<<
        //        selectTxt += "  	  ,ENTERPRISECODERF   " + Environment.NewLine;
        //        selectTxt += "  	  ,INQORIGINALEPCDRF   " + Environment.NewLine;
        //        selectTxt += "  	  ,INQORIGINALSECCDRF   " + Environment.NewLine;
        //        selectTxt += "  	  ,INQOTHEREPCDRF   " + Environment.NewLine;
        //        selectTxt += "  	  ,INQOTHERSECCDRF   " + Environment.NewLine;
        //        selectTxt += "  	  ,INQUIRYNUMBERRF    " + Environment.NewLine;
        //        // -- UPD 2010/03/11 -------------------------------------------------->>>
        //        //selectTxt += "  	  ,INQORDANSDIVCDRF  " + Environment.NewLine;
        //        //selectTxt += "  	  ,ACPTANODRSTATUSRF	   " + Environment.NewLine;
        //        //selectTxt += "  	  ,SALESSLIPNUMRF  " + Environment.NewLine;
        //        // -- UPD 2010/03/11 --------------------------------------------------<<<
        //        selectTxt += "  	  FROM SCMACODRDATARF    " + Environment.NewLine;
        //        selectTxt += "  	  GROUP BY    " + Environment.NewLine;
        //        selectTxt += "  	   ENTERPRISECODERF   " + Environment.NewLine;
        //        selectTxt += "  	  ,INQORIGINALEPCDRF   " + Environment.NewLine;
        //        selectTxt += "  	  ,INQORIGINALSECCDRF   " + Environment.NewLine;
        //        selectTxt += "  	  ,INQOTHEREPCDRF   " + Environment.NewLine;
        //        selectTxt += "  	  ,INQOTHERSECCDRF   " + Environment.NewLine;
        //        selectTxt += "  	  ,INQUIRYNUMBERRF	   " + Environment.NewLine;
        //        // -- UPD 2010/03/11 -------------------------------------------------->>>
        //        //selectTxt += "  	  ,INQORDANSDIVCDRF  " + Environment.NewLine;
        //        //// -- 2009/08/13 ------------------------------------------------------->>>
        //        //selectTxt += "  	  ,ACPTANODRSTATUSRF	   " + Environment.NewLine;
        //        //selectTxt += "  	  ,SALESSLIPNUMRF  " + Environment.NewLine;
        //        //// -- 2009/08/13 -------------------------------------------------------<<<
        //        // -- UPD 2010/03/11 --------------------------------------------------<<<
        //        selectTxt += "    ) AS SCM2   " + Environment.NewLine;
        //        selectTxt += "    ON   " + Environment.NewLine;
        //        selectTxt += "        SCM2.ENTERPRISECODERF = SCM.ENTERPRISECODERF   " + Environment.NewLine;
        //        selectTxt += "    AND SCM2.INQORIGINALEPCDRF = SCM.INQORIGINALEPCDRF   " + Environment.NewLine;
        //        selectTxt += "    AND SCM2.INQORIGINALSECCDRF = SCM.INQORIGINALSECCDRF   " + Environment.NewLine;
        //        selectTxt += "    AND SCM2.INQOTHEREPCDRF = SCM.INQOTHEREPCDRF   " + Environment.NewLine;
        //        selectTxt += "    AND SCM2.INQOTHERSECCDRF = SCM.INQOTHERSECCDRF   " + Environment.NewLine;
        //        selectTxt += "    AND SCM2.INQUIRYNUMBERRF = SCM.INQUIRYNUMBERRF   " + Environment.NewLine;
        //        // -- UPD 2010/03/11 -------------------------------------------------->>>
        //        //selectTxt += "    AND SCM2.UPDATEDATERF = SCM.UPDATEDATERF   " + Environment.NewLine;
        //        //selectTxt += "    AND SCM2.UPDATETIMERF = SCM.UPDATETIMERF   " + Environment.NewLine;
        //        //// -- 2009/08/13 ------------------------------------------------------->>>
        //        //selectTxt += "    AND SCM2.ACPTANODRSTATUSRF = SCM.ACPTANODRSTATUSRF " + Environment.NewLine;
        //        //selectTxt += "    AND SCM2.SALESSLIPNUMRF = SCM.SALESSLIPNUMRF  " + Environment.NewLine;
        //        //// -- 2009/08/13 -------------------------------------------------------<<<
        //        selectTxt += "    AND SCM2.UPDATEDATETIMERF = (cast(SCM.UPDATEDATERF as nvarchar) + cast(SCM.UPDATETIMERF as nvarchar))   " + Environment.NewLine;
        //        // -- UPD 2010/03/11 --------------------------------------------------<<<
        //        selectTxt += "   LEFT JOIN SCMACODRDTCARRF AS CAR   " + Environment.NewLine;
        //        selectTxt += "    ON  " + Environment.NewLine;
        //        selectTxt += "        CAR.ENTERPRISECODERF = SCM.ENTERPRISECODERF  " + Environment.NewLine;
        //        selectTxt += "    AND CAR.INQORIGINALEPCDRF = SCM.INQORIGINALEPCDRF  " + Environment.NewLine;
        //        selectTxt += "    AND CAR.INQORIGINALSECCDRF = SCM.INQORIGINALSECCDRF  " + Environment.NewLine;
        //        selectTxt += "    AND CAR.INQUIRYNUMBERRF = SCM.INQUIRYNUMBERRF " + Environment.NewLine;
        //        selectTxt += "    AND CAR.ACPTANODRSTATUSRF = SCM.ACPTANODRSTATUSRF " + Environment.NewLine;
        //        selectTxt += "    AND CAR.SALESSLIPNUMRF = SCM.SALESSLIPNUMRF  " + Environment.NewLine;
        //        selectTxt += "   LEFT JOIN CUSTOMERRF AS CUS  " + Environment.NewLine;
        //        selectTxt += "    ON  " + Environment.NewLine;
        //        selectTxt += "        CUS.ENTERPRISECODERF = SCM.ENTERPRISECODERF  " + Environment.NewLine;
        //        selectTxt += "    AND CUS.CUSTOMERCODERF = SCM.CUSTOMERCODERF  " + Environment.NewLine;



        //        //WHERE文の作成
        //        selectTxt += MakeWhereString(ref sqlCommand, scmInquiryOrderWork, logicalMode);

        //        sqlCommand.CommandText = selectTxt;

        //        #endregion

        //        myReader = sqlCommand.ExecuteReader();

        //        while (myReader.Read())
        //        {
        //            #region 抽出結果-値セット

        //            // 伝票
        //            SCMInquiryResultWork wkSCMInquiryResultWork = new SCMInquiryResultWork();

        //            #region 格納項目-伝票
        //            wkSCMInquiryResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF")); // 企業コード
        //            wkSCMInquiryResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));  // 得意先コード
        //            wkSCMInquiryResultWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));  // 得意先名称
        //            wkSCMInquiryResultWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));  // 受注ステータス
        //            wkSCMInquiryResultWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));  // 売上伝票番号
        //            wkSCMInquiryResultWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALEPCDRF"));  // 問合せ元企業コード
        //            wkSCMInquiryResultWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALSECCDRF"));  // 問合せ元拠点コード
        //            wkSCMInquiryResultWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHEREPCDRF"));  // 問合せ先企業コード
        //            wkSCMInquiryResultWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHERSECCDRF"));  // 問合せ先拠点コード
        //            wkSCMInquiryResultWork.InquiryNumber = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INQUIRYNUMBERRF"));  // 問合せ番号
        //            wkSCMInquiryResultWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));  // 更新年月日
        //            wkSCMInquiryResultWork.UpdateTime = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATETIMERF"));  // 更新時間
        //            wkSCMInquiryResultWork.InqOrdDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQORDDIVCDRF"));  // 問合せ・発注種別
        //            wkSCMInquiryResultWork.AnswerDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERDIVCDRF"));  // 回答区分
        //            wkSCMInquiryResultWork.JudgementDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JUDGEMENTDATERF"));  // 確定日
        //            wkSCMInquiryResultWork.InqOrdNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORDNOTERF"));  // 問合せ・発注備考
        //            wkSCMInquiryResultWork.InqEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQEMPLOYEECDRF"));  // 問合せ従業員コード
        //            wkSCMInquiryResultWork.InqEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQEMPLOYEENMRF"));  // 問合せ従業員名称
        //            wkSCMInquiryResultWork.AnsEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSEMPLOYEECDRF"));  // 回答従業員コード
        //            wkSCMInquiryResultWork.AnsEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSEMPLOYEENMRF"));  // 回答従業員名称
        //            wkSCMInquiryResultWork.InquiryDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQUIRYDATERF"));  // 問合せ日
        //            wkSCMInquiryResultWork.NumberPlate1Code = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE1CODERF"));  // 陸運事務所番号
        //            wkSCMInquiryResultWork.NumberPlate1Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE1NAMERF"));  // 陸運事務局名称
        //            wkSCMInquiryResultWork.NumberPlate2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE2RF"));  // 車両登録番号（種別）
        //            wkSCMInquiryResultWork.NumberPlate3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE3RF"));  // 車両登録番号（カナ）
        //            wkSCMInquiryResultWork.NumberPlate4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE4RF"));  // 車両登録番号（プレート番号）
        //            wkSCMInquiryResultWork.ModelDesignationNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));  // 型式指定番号
        //            wkSCMInquiryResultWork.CategoryNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));  // 類別番号
        //            wkSCMInquiryResultWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));  // メーカーコード
        //            wkSCMInquiryResultWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));  // 車種コード
        //            wkSCMInquiryResultWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));  // 車種サブコード
        //            wkSCMInquiryResultWork.ModelName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELNAMERF"));  // 車種名
        //            wkSCMInquiryResultWork.CarInspectCertModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARINSPECTCERTMODELRF"));  // 車検証型式
        //            wkSCMInquiryResultWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));  // 型式（フル型）
        //            wkSCMInquiryResultWork.FrameNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMENORF"));  // 車台番号
        //            wkSCMInquiryResultWork.FrameModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMEMODELRF"));  // 車台型式
        //            wkSCMInquiryResultWork.ChassisNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHASSISNORF"));  // シャシーNo
        //            wkSCMInquiryResultWork.CarProperNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARPROPERNORF"));  // 車両固有番号
        //            wkSCMInquiryResultWork.ProduceTypeOfYearNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRODUCETYPEOFYEARNUMRF"));  // 生産年式（NUMタイプ）
        //            wkSCMInquiryResultWork.Comment = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMMENTRF"));  // コメント
        //            wkSCMInquiryResultWork.RpColorCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RPCOLORCODERF"));  // リペアカラーコード
        //            wkSCMInquiryResultWork.ColorName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORNAME1RF"));  // カラー名称1
        //            wkSCMInquiryResultWork.TrimCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMCODERF"));  // トリムコード
        //            wkSCMInquiryResultWork.TrimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMNAMERF"));  // トリム名称
        //            wkSCMInquiryResultWork.Mileage = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MILEAGERF"));  // 車両走行距離      
        //            wkSCMInquiryResultWork.UpdateTime = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATETIMERF"));  // 更新時間   
        //            wkSCMInquiryResultWork.AwnserMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERCREATEDIVRF"));  // 回答方法
        //            wkSCMInquiryResultWork.SalesTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXINCRF"));  // 売上伝票合計（税込み）
        //            #endregion
        //            #endregion

        //                SlipList.Add(wkSCMInquiryResultWork);

        //            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //        }
        //        // 最後の伝票情報追加
        //        if (SlipList.Count != 0)
        //        {
        //            retList.Add(SlipList);
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        //基底クラスに例外を渡して処理してもらう
        //        status = base.WriteSQLErrorLog(ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        base.WriteErrorLog(ex, "SCMInquiryDB.SearchProc Exception=" + ex.Message);
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    }
        //    finally
        //    {
        //        if (sqlCommand != null) sqlCommand.Dispose();
        //        if (!myReader.IsClosed) myReader.Close();
        //    }

        //    return status;
        //}
        #endregion

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="al">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_supplierSendErOrderCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        private int SearchProc(ref CustomSerializeArrayList retList, ref SqlConnection sqlConnection, SCMInquiryOrderWork scmInquiryOrderWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            // 伝票リスト
            CustomSerializeArrayList SlipList = new CustomSerializeArrayList();

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                #region Select文作成
                selectTxt += "  SELECT" + Environment.NewLine;
                selectTxt += "           SCM.CUSTOMERCODERF   " + Environment.NewLine;
                selectTxt += "          ,CUS.CUSTOMERSNMRF   " + Environment.NewLine;
                selectTxt += "          ,SCM.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "          ,SCM.ACPTANODRSTATUSRF   " + Environment.NewLine;
                selectTxt += "          ,SCM.SALESSLIPNUMRF   " + Environment.NewLine;
                selectTxt += "          ,SCM.INQORIGINALEPCDRF   " + Environment.NewLine;
                selectTxt += "          ,SCM.INQORIGINALSECCDRF   " + Environment.NewLine;
                selectTxt += "          ,SCM.INQOTHEREPCDRF   " + Environment.NewLine;
                selectTxt += "          ,SCM.INQOTHERSECCDRF   " + Environment.NewLine;
                selectTxt += "          ,SCM.INQUIRYNUMBERRF   " + Environment.NewLine;
                selectTxt += "          ,SCM.UPDATEDATERF   " + Environment.NewLine;
                selectTxt += "          ,SCM.UPDATETIMERF   " + Environment.NewLine;
                selectTxt += "          ,SCM.INQORDDIVCDRF   " + Environment.NewLine;
                selectTxt += "          ,SCM.ANSWERDIVCDRF   " + Environment.NewLine;
                selectTxt += "          ,SCM.JUDGEMENTDATERF   " + Environment.NewLine;
                selectTxt += "          ,SCM.INQORDNOTERF   " + Environment.NewLine;
                selectTxt += "          ,SCM.APPENDINGFILERF   " + Environment.NewLine;
                selectTxt += "          ,SCM.APPENDINGFILENMRF   " + Environment.NewLine;
                selectTxt += "          ,SCM.INQEMPLOYEECDRF   " + Environment.NewLine;
                selectTxt += "          ,SCM.INQEMPLOYEENMRF   " + Environment.NewLine;
                selectTxt += "          ,SCM.ANSEMPLOYEECDRF   " + Environment.NewLine;
                selectTxt += "          ,SCM.ANSEMPLOYEENMRF   " + Environment.NewLine;
                selectTxt += "          ,SCM.INQUIRYDATERF   " + Environment.NewLine;
                selectTxt += "          ,SCM.ANSWERCREATEDIVRF  " + Environment.NewLine;
                selectTxt += "          ,SCM.ACCEPTORORDERKINDRF  " + Environment.NewLine; // ADD gezh 2011/11/12
                selectTxt += "          ,SCM.SALESTOTALTAXINCRF  " + Environment.NewLine;
                selectTxt += "          ,CAR.NUMBERPLATE1CODERF   " + Environment.NewLine;
                selectTxt += "          ,CAR.NUMBERPLATE1NAMERF   " + Environment.NewLine;
                selectTxt += "          ,CAR.NUMBERPLATE2RF   " + Environment.NewLine;
                selectTxt += "          ,CAR.NUMBERPLATE3RF   " + Environment.NewLine;
                selectTxt += "          ,CAR.NUMBERPLATE4RF   " + Environment.NewLine;
                selectTxt += "          ,CAR.MODELDESIGNATIONNORF   " + Environment.NewLine;
                selectTxt += "          ,CAR.CATEGORYNORF   " + Environment.NewLine;
                selectTxt += "          ,CAR.MAKERCODERF   " + Environment.NewLine;
                selectTxt += "          ,CAR.MODELCODERF   " + Environment.NewLine;
                selectTxt += "          ,CAR.MODELSUBCODERF   " + Environment.NewLine;
                selectTxt += "          ,CAR.MODELNAMERF   " + Environment.NewLine;
                selectTxt += "          ,CAR.CARINSPECTCERTMODELRF   " + Environment.NewLine;
                selectTxt += "          ,CAR.FULLMODELRF   " + Environment.NewLine;
                selectTxt += "          ,CAR.FRAMENORF   " + Environment.NewLine;
                selectTxt += "          ,CAR.FRAMEMODELRF   " + Environment.NewLine;
                selectTxt += "          ,CAR.CHASSISNORF   " + Environment.NewLine;
                selectTxt += "          ,CAR.CARPROPERNORF   " + Environment.NewLine;
                selectTxt += "          ,CAR.PRODUCETYPEOFYEARNUMRF   " + Environment.NewLine;
                selectTxt += "          ,CAR.COMMENTRF   " + Environment.NewLine;
                selectTxt += "          ,CAR.RPCOLORCODERF   " + Environment.NewLine;
                selectTxt += "          ,CAR.COLORNAME1RF   " + Environment.NewLine;
                selectTxt += "          ,CAR.TRIMCODERF   " + Environment.NewLine;
                selectTxt += "          ,CAR.TRIMNAMERF   " + Environment.NewLine;
                selectTxt += "          ,CAR.MILEAGERF   " + Environment.NewLine;
                // -- ADD 2010/06/17 ----------------------------------->>>
                selectTxt += "          ,SCM.CANCELDIVRF" + Environment.NewLine;
                selectTxt += "          ,SCM.CMTCOOPRTDIVRF" + Environment.NewLine;
                // -- ADD 2010/06/17 -----------------------------------<<<
                // -- ADD 2011/05/26 ----------------------------------->>>
                selectTxt += "          ,SCM.SFPMCPRTINSTSLIPNORF" + Environment.NewLine;
                // -- ADD 2011/05/26 -----------------------------------<<<
                //--- ADD 2012/10/10 2012/11/14配信予定 SCM障害№176対応 ---------->>>>>
                selectTxt += "          ,SCM.AUTOANSWERCOUNT" + Environment.NewLine;
                selectTxt += "          ,SCM.MANUALANSWERCOUNT" + Environment.NewLine;
                //--- ADD 2012/10/10 2012/11/14配信予定 SCM障害№176対応 ----------<<<<<
                // ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
                selectTxt += "          ,CAR.EXPECTEDCEDATERF   " + Environment.NewLine;
                // ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<
                selectTxt += "   FROM " + Environment.NewLine;
                selectTxt += "   (" + Environment.NewLine;
                selectTxt += "      --キャンセル以外のデータ取得用" + Environment.NewLine;
                selectTxt += "      SELECT" + Environment.NewLine;
                selectTxt += "         SCM2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "        ,SCM2.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQORIGINALEPCDRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQORIGINALSECCDRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQOTHEREPCDRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQOTHERSECCDRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQUIRYNUMBERRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "        ,SCM2.UPDATEDATERF" + Environment.NewLine;
                selectTxt += "        ,SCM2.UPDATETIMERF" + Environment.NewLine;
                selectTxt += "        ,SCM2.ANSWERDIVCDRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.JUDGEMENTDATERF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQORDNOTERF" + Environment.NewLine;
                selectTxt += "        ,SCM2.APPENDINGFILERF" + Environment.NewLine;
                selectTxt += "        ,SCM2.APPENDINGFILENMRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQEMPLOYEECDRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQEMPLOYEENMRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.ANSEMPLOYEECDRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.ANSEMPLOYEENMRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQUIRYDATERF" + Environment.NewLine;
                selectTxt += "        ,SCM2.ACPTANODRSTATUSRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.SALESSLIPNUMRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.SALESTOTALTAXINCRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.SALESSUBTOTALTAXRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQORDDIVCDRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQORDANSDIVCDRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.RECEIVEDATETIMERF" + Environment.NewLine;
                selectTxt += "        ,SCM2.ANSWERCREATEDIVRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.ACCEPTORORDERKINDRF  " + Environment.NewLine; // ADD gezh 2011/11/12
                // -- ADD 2010/06/17 ----------------------------------->>>
                selectTxt += "        ,SCM2.CANCELDIVRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.CMTCOOPRTDIVRF" + Environment.NewLine;
                // -- ADD 2010/06/17 -----------------------------------<<<
                // -- ADD 2011/05/26 ----------------------------------->>>
                selectTxt += "        ,SCM2.SFPMCPRTINSTSLIPNORF" + Environment.NewLine;
                // -- ADD 2011/05/26 -----------------------------------<<<
                //--- ADD 2012/10/10 2012/11/14配信予定 SCM障害№176対応 ---------->>>>>
                selectTxt += "        ,SCM3.AUTOANSWERCOUNT" + Environment.NewLine;
                selectTxt += "        ,SCM3.MANUALANSWERCOUNT" + Environment.NewLine;
                //--- ADD 2012/10/10 2012/11/14配信予定 SCM障害№176対応 ----------<<<<<
                selectTxt += "      FROM SCMACODRDATARF AS SCM2 WITH (READUNCOMMITTED)  " + Environment.NewLine;
                selectTxt += "      INNER JOIN   " + Environment.NewLine;
                selectTxt += "      (   " + Environment.NewLine;
                // UPD 2012/07/27 T.Yoshioka 2012/08/07配信システムテスト№126対応 ------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                selectTxt += "          SELECT " + Environment.NewLine;
                selectTxt += "            MAX( CAST (UPDATEDATERF AS NVARCHAR) + RIGHT ('000000000' + CAST (UPDATETIMERF AS NVARCHAR), 9 )) AS UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "            , MAX(SALESSLIPNUMRF) AS SALESSLIPNUMRF " + Environment.NewLine;
                selectTxt += "            , T1.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "            , T1.INQORIGINALEPCDRF " + Environment.NewLine;
                selectTxt += "            , T1.INQORIGINALSECCDRF " + Environment.NewLine;
                selectTxt += "            , T1.INQOTHEREPCDRF " + Environment.NewLine;
                selectTxt += "            , T1.INQOTHERSECCDRF " + Environment.NewLine;
                selectTxt += "            , T1.INQUIRYNUMBERRF " + Environment.NewLine;
                selectTxt += "            , T1.INQORDDIVCDRF  " + Environment.NewLine;
                //--- ADD 2012/10/10 2012/11/14配信予定 SCM障害№176対応 ---------->>>>>
                selectTxt += "            , MAX(ISNULL(AUTOANSWERCOUNT,0)) AS AUTOANSWERCOUNT  " + Environment.NewLine;
                selectTxt += "            , MAX(ISNULL(MANUALANSWERCOUNT,0)) AS MANUALANSWERCOUNT  " + Environment.NewLine;
                //--- ADD 2012/10/10 2012/11/14配信予定 SCM障害№176対応 ----------<<<<<
                selectTxt += "          FROM " + Environment.NewLine;
                selectTxt += "            SCMACODRDATARF T1 WITH (READUNCOMMITTED)  " + Environment.NewLine;
                selectTxt += "            INNER JOIN (  " + Environment.NewLine;
                selectTxt += "              SELECT " + Environment.NewLine;
                selectTxt += "                MAX( CAST (UPDATEDATERF AS NVARCHAR) + RIGHT ('000000000' + CAST (UPDATETIMERF AS NVARCHAR), 9 )) AS UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "                , ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "                , INQORIGINALEPCDRF " + Environment.NewLine;
                selectTxt += "                , INQORIGINALSECCDRF " + Environment.NewLine;
                selectTxt += "                , INQOTHEREPCDRF " + Environment.NewLine;
                selectTxt += "                , INQOTHERSECCDRF " + Environment.NewLine;
                selectTxt += "                , INQUIRYNUMBERRF " + Environment.NewLine;
                selectTxt += "                , INQORDDIVCDRF  " + Environment.NewLine;
                selectTxt += "              FROM " + Environment.NewLine;
                selectTxt += "                SCMACODRDATARF WITH (READUNCOMMITTED)  " + Environment.NewLine;
                selectTxt += "              WHERE " + Environment.NewLine;
                selectTxt += "                ENTERPRISECODERF = @ENTERPRISECODE  " + Environment.NewLine;
                selectTxt += "                AND CANCELDIVRF <> 1  " + Environment.NewLine;
                selectTxt += "              GROUP BY " + Environment.NewLine;
                selectTxt += "                ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "                , INQORIGINALEPCDRF " + Environment.NewLine;
                selectTxt += "                , INQORIGINALSECCDRF " + Environment.NewLine;
                selectTxt += "                , INQOTHEREPCDRF " + Environment.NewLine;
                selectTxt += "                , INQOTHERSECCDRF " + Environment.NewLine;
                selectTxt += "                , INQUIRYNUMBERRF " + Environment.NewLine;
                selectTxt += "                , INQORDDIVCDRF " + Environment.NewLine;
                selectTxt += "            ) T2  " + Environment.NewLine;
                selectTxt += "              ON T1.ENTERPRISECODERF = T2.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQORIGINALEPCDRF = T2.INQORIGINALEPCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQORIGINALSECCDRF = T2.INQORIGINALSECCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQOTHEREPCDRF = T2.INQOTHEREPCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQOTHERSECCDRF = T2.INQOTHERSECCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQUIRYNUMBERRF = T2.INQUIRYNUMBERRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQORDDIVCDRF = T2.INQORDDIVCDRF  " + Environment.NewLine;
                selectTxt += "              AND CAST (T1.UPDATEDATERF AS NVARCHAR) +  RIGHT ( '000000000' + CAST (T1.UPDATETIMERF AS NVARCHAR), 9) = T2.UPDATEDATETIMERF  " + Environment.NewLine;
                //--- ADD 2012/10/10 2012/11/14配信予定 SCM障害№176対応 ---------->>>>>
                selectTxt += "            LEFT JOIN (  " + Environment.NewLine;
                selectTxt += "              SELECT  " + Environment.NewLine;
                selectTxt += "                  COUNT(ANSWERCREATEDIVRF) AS AUTOANSWERCOUNT  " + Environment.NewLine;
                selectTxt += "                , ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "                , INQORIGINALEPCDRF  " + Environment.NewLine;
                selectTxt += "                , INQORIGINALSECCDRF  " + Environment.NewLine;
                selectTxt += "                , INQOTHEREPCDRF  " + Environment.NewLine;
                selectTxt += "                , INQOTHERSECCDRF  " + Environment.NewLine;
                selectTxt += "                , INQUIRYNUMBERRF  " + Environment.NewLine;
                selectTxt += "                , INQORDDIVCDRF  " + Environment.NewLine;
                selectTxt += "              FROM  " + Environment.NewLine;
                selectTxt += "                SCMACODRDATARF WITH (READUNCOMMITTED)  " + Environment.NewLine;
                selectTxt += "              WHERE  " + Environment.NewLine;
                selectTxt += "                ENTERPRISECODERF = @ENTERPRISECODE  " + Environment.NewLine;
                selectTxt += "                AND CANCELDIVRF <> 1  " + Environment.NewLine;
                selectTxt += "                AND ANSWERCREATEDIVRF = 0  " + Environment.NewLine;
                selectTxt += "              GROUP BY " + Environment.NewLine;
                selectTxt += "                  ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "                , INQORIGINALEPCDRF " + Environment.NewLine;
                selectTxt += "                , INQORIGINALSECCDRF " + Environment.NewLine;
                selectTxt += "                , INQOTHEREPCDRF " + Environment.NewLine;
                selectTxt += "                , INQOTHERSECCDRF " + Environment.NewLine;
                selectTxt += "                , INQUIRYNUMBERRF " + Environment.NewLine;
                selectTxt += "                , INQORDDIVCDRF " + Environment.NewLine;
                selectTxt += "            ) T3  " + Environment.NewLine;
                selectTxt += "              ON T1.ENTERPRISECODERF = T3.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQORIGINALEPCDRF = T3.INQORIGINALEPCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQORIGINALSECCDRF = T3.INQORIGINALSECCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQOTHEREPCDRF = T3.INQOTHEREPCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQOTHERSECCDRF = T3.INQOTHERSECCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQUIRYNUMBERRF = T3.INQUIRYNUMBERRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQORDDIVCDRF = T3.INQORDDIVCDRF  " + Environment.NewLine;
                selectTxt += "            LEFT JOIN (  " + Environment.NewLine;
                selectTxt += "              SELECT  " + Environment.NewLine;
                selectTxt += "                  COUNT(ANSWERCREATEDIVRF) AS MANUALANSWERCOUNT  " + Environment.NewLine;
                selectTxt += "                , ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "                , INQORIGINALEPCDRF  " + Environment.NewLine;
                selectTxt += "                , INQORIGINALSECCDRF  " + Environment.NewLine;
                selectTxt += "                , INQOTHEREPCDRF  " + Environment.NewLine;
                selectTxt += "                , INQOTHERSECCDRF  " + Environment.NewLine;
                selectTxt += "                , INQUIRYNUMBERRF  " + Environment.NewLine;
                selectTxt += "                , INQORDDIVCDRF  " + Environment.NewLine;
                selectTxt += "              FROM  " + Environment.NewLine;
                selectTxt += "                SCMACODRDATARF WITH (READUNCOMMITTED)  " + Environment.NewLine;
                selectTxt += "              WHERE  " + Environment.NewLine;
                selectTxt += "                ENTERPRISECODERF = @ENTERPRISECODE  " + Environment.NewLine;
                selectTxt += "                AND CANCELDIVRF <> 1  " + Environment.NewLine;
                selectTxt += "                AND ANSWERCREATEDIVRF = 2  " + Environment.NewLine;
                selectTxt += "              GROUP BY " + Environment.NewLine;
                selectTxt += "                  ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "                , INQORIGINALEPCDRF " + Environment.NewLine;
                selectTxt += "                , INQORIGINALSECCDRF " + Environment.NewLine;
                selectTxt += "                , INQOTHEREPCDRF " + Environment.NewLine;
                selectTxt += "                , INQOTHERSECCDRF " + Environment.NewLine;
                selectTxt += "                , INQUIRYNUMBERRF " + Environment.NewLine;
                selectTxt += "                , INQORDDIVCDRF " + Environment.NewLine;
                selectTxt += "            ) T4  " + Environment.NewLine;
                selectTxt += "              ON T1.ENTERPRISECODERF = T4.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQORIGINALEPCDRF = T4.INQORIGINALEPCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQORIGINALSECCDRF = T4.INQORIGINALSECCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQOTHEREPCDRF = T4.INQOTHEREPCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQOTHERSECCDRF = T4.INQOTHERSECCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQUIRYNUMBERRF = T4.INQUIRYNUMBERRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQORDDIVCDRF = T4.INQORDDIVCDRF  " + Environment.NewLine;
                //--- ADD 2012/10/10 2012/11/14配信予定 SCM障害№176対応 ----------<<<<<
                selectTxt += "          WHERE " + Environment.NewLine;
                selectTxt += "            T1.ENTERPRISECODERF = @ENTERPRISECODE  " + Environment.NewLine;
                selectTxt += "            AND CANCELDIVRF <> 1  " + Environment.NewLine;
                selectTxt += "          GROUP BY " + Environment.NewLine;
                selectTxt += "            T1.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "            , T1.INQORIGINALEPCDRF " + Environment.NewLine;
                selectTxt += "            , T1.INQORIGINALSECCDRF " + Environment.NewLine;
                selectTxt += "            , T1.INQOTHEREPCDRF " + Environment.NewLine;
                selectTxt += "            , T1.INQOTHERSECCDRF " + Environment.NewLine;
                selectTxt += "            , T1.INQUIRYNUMBERRF " + Environment.NewLine;
                selectTxt += "            , T1.INQORDDIVCDRF " + Environment.NewLine;
                # region 旧SQL
                //selectTxt += "  	  SELECT    " + Environment.NewLine;
                //// -- UPD 2010/06/17 --------------------------------------->>>
                ////selectTxt += "  	   MAX(cast(UPDATEDATERF as nvarchar) + cast(UPDATETIMERF as nvarchar)) AS UPDATEDATETIMERF   " + Environment.NewLine;
                //selectTxt += "  	   MAX(cast(UPDATEDATERF as nvarchar) + RIGHT('000000000' + cast(UPDATETIMERF as nvarchar),9)) AS UPDATEDATETIMERF   " + Environment.NewLine;
                //// -- UPD 2010/06/17 ---------------------------------------<<<
                //// ADD 2012/07/18 システムテスト障害No.101  yugami ------------------------------------------->>>>>
                //selectTxt += "  	  ,MAX(SALESSLIPNUMRF) AS SALESSLIPNUMRF   " + Environment.NewLine;
                //// ADD 2012/07/18 システムテスト障害No.101  yugami -------------------------------------------<<<<<
                //selectTxt += "  	  ,ENTERPRISECODERF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQORIGINALEPCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQORIGINALSECCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQOTHEREPCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQOTHERSECCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQUIRYNUMBERRF    " + Environment.NewLine;
                //// 2011/01/24 Add >>>
                //selectTxt += "  	  ,INQORDDIVCDRF	   " + Environment.NewLine;
                //// 2011/01/24 Add <<<
                //selectTxt += "  	  FROM SCMACODRDATARF WITH (READUNCOMMITTED) " + Environment.NewLine;
                //selectTxt += "        WHERE" + Environment.NewLine;
                //selectTxt += "              ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                //// 2011/02/18 >>>
                ////selectTxt += "          AND ANSWERDIVCDRF <> 99    " + Environment.NewLine; //99:キャンセル以外
                //selectTxt += "          AND CANCELDIVRF <> 1    " + Environment.NewLine; //1:キャンセル以外
                //// 2011/02/18 <<<
                //selectTxt += "  	  GROUP BY    " + Environment.NewLine;
                //selectTxt += "  	   ENTERPRISECODERF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQORIGINALEPCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQORIGINALSECCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQOTHEREPCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQOTHERSECCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQUIRYNUMBERRF	   " + Environment.NewLine;
                //// 2011/01/24 Add >>>
                //selectTxt += "  	  ,INQORDDIVCDRF	   " + Environment.NewLine;
                //// 2011/01/24 Add <<<
                # endregion
                // UPD 2012/07/27 T.Yoshioka 2012/08/07配信システムテスト№126対応 -------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                selectTxt += "      ) AS SCM3   " + Environment.NewLine;
                selectTxt += "      ON   " + Environment.NewLine;
                selectTxt += "          SCM3.ENTERPRISECODERF = SCM2.ENTERPRISECODERF   " + Environment.NewLine;
                selectTxt += "      AND SCM3.INQORIGINALEPCDRF = SCM2.INQORIGINALEPCDRF   " + Environment.NewLine;
                selectTxt += "      AND SCM3.INQORIGINALSECCDRF = SCM2.INQORIGINALSECCDRF   " + Environment.NewLine;
                selectTxt += "      AND SCM3.INQOTHEREPCDRF = SCM2.INQOTHEREPCDRF   " + Environment.NewLine;
                selectTxt += "      AND SCM3.INQOTHERSECCDRF = SCM2.INQOTHERSECCDRF   " + Environment.NewLine;
                selectTxt += "      AND SCM3.INQUIRYNUMBERRF = SCM2.INQUIRYNUMBERRF   " + Environment.NewLine;
                // -- UPD 2010/06/17 ------------------------------------------->>>
                //selectTxt += "      AND SCM3.UPDATEDATETIMERF = (cast(SCM2.UPDATEDATERF as nvarchar) + cast(SCM2.UPDATETIMERF as nvarchar))   " + Environment.NewLine;
                selectTxt += "      AND SCM3.UPDATEDATETIMERF = (cast(SCM2.UPDATEDATERF as nvarchar) + RIGHT('000000000' + cast(SCM2.UPDATETIMERF as nvarchar),9))   " + Environment.NewLine;
                // -- UPD 2010/06/17 -------------------------------------------<<<
                // 2011/01/24 Add >>>
                selectTxt += "      AND SCM3.INQORDDIVCDRF = SCM2.INQORDDIVCDRF   " + Environment.NewLine;
                // 2011/01/24 Add <<<
                // ADD 2012/07/18 システムテスト障害No.101  yugami ------------------------------------------->>>>>
                selectTxt += "  	AND SCM3.SALESSLIPNUMRF = SCM2.SALESSLIPNUMRF   " + Environment.NewLine;
                // ADD 2012/07/18 システムテスト障害No.101  yugami -------------------------------------------<<<<<
                selectTxt += "    UNION ALL " + Environment.NewLine;
                selectTxt += "      --キャンセルデータ取得用" + Environment.NewLine;
                selectTxt += "      SELECT" + Environment.NewLine;
                selectTxt += "         SCM2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "        ,SCM2.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQORIGINALEPCDRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQORIGINALSECCDRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQOTHEREPCDRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQOTHERSECCDRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQUIRYNUMBERRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "        ,SCM2.UPDATEDATERF" + Environment.NewLine;
                selectTxt += "        ,SCM2.UPDATETIMERF" + Environment.NewLine;
                // 2011/02/18 >>>
                //selectTxt += "        ,SCM2.ANSWERDIVCDRF" + Environment.NewLine;
                selectTxt += "        ,99 AS ANSWERDIVCDRF" + Environment.NewLine;
                // 2011/02/18 <<<
                selectTxt += "        ,SCM2.JUDGEMENTDATERF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQORDNOTERF" + Environment.NewLine;
                selectTxt += "        ,SCM2.APPENDINGFILERF" + Environment.NewLine;
                selectTxt += "        ,SCM2.APPENDINGFILENMRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQEMPLOYEECDRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQEMPLOYEENMRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.ANSEMPLOYEECDRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.ANSEMPLOYEENMRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQUIRYDATERF" + Environment.NewLine;
                selectTxt += "        ,SCM2.ACPTANODRSTATUSRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.SALESSLIPNUMRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.SALESTOTALTAXINCRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.SALESSUBTOTALTAXRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQORDDIVCDRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQORDANSDIVCDRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.RECEIVEDATETIMERF" + Environment.NewLine;
                selectTxt += "        ,SCM2.ANSWERCREATEDIVRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.ACCEPTORORDERKINDRF  " + Environment.NewLine; // ADD gezh 2011/11/12
                // -- ADD 2010/06/17 ----------------------------------->>>
                selectTxt += "        ,SCM2.CANCELDIVRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.CMTCOOPRTDIVRF" + Environment.NewLine;
                // -- ADD 2010/06/17 -----------------------------------<<<
                // -- ADD 2011/05/26 ----------------------------------->>>
                selectTxt += "        ,SCM2.SFPMCPRTINSTSLIPNORF" + Environment.NewLine;
                // -- ADD 2011/05/26 -----------------------------------<<<
                //--- ADD 2012/10/10 2012/11/14配信予定 SCM障害№176対応 ---------->>>>>
                selectTxt += "        ,SCM3.AUTOANSWERCOUNT" + Environment.NewLine;
                selectTxt += "        ,SCM3.MANUALANSWERCOUNT" + Environment.NewLine;
                //--- ADD 2012/10/10 2012/11/14配信予定 SCM障害№176対応 ----------<<<<<
                selectTxt += "      FROM SCMACODRDATARF AS SCM2 WITH (READUNCOMMITTED)  " + Environment.NewLine;
                selectTxt += "      --最新のキャンセルデータを取得" + Environment.NewLine;
                selectTxt += "      INNER JOIN   " + Environment.NewLine;
                selectTxt += "      (   " + Environment.NewLine;

                // UPD 2012/07/27 T.Yoshioka 2012/08/07配信システムテスト№126対応 ------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                selectTxt += "          SELECT " + Environment.NewLine;
                selectTxt += "            MAX( CAST (UPDATEDATERF AS NVARCHAR) + RIGHT ('000000000' + CAST (UPDATETIMERF AS NVARCHAR), 9 )) AS UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "            , MAX(SALESSLIPNUMRF) AS SALESSLIPNUMRF " + Environment.NewLine;
                selectTxt += "            , T1.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "            , T1.INQORIGINALEPCDRF " + Environment.NewLine;
                selectTxt += "            , T1.INQORIGINALSECCDRF " + Environment.NewLine;
                selectTxt += "            , T1.INQOTHEREPCDRF " + Environment.NewLine;
                selectTxt += "            , T1.INQOTHERSECCDRF " + Environment.NewLine;
                selectTxt += "            , T1.INQUIRYNUMBERRF " + Environment.NewLine;
                selectTxt += "            , T1.INQORDDIVCDRF  " + Environment.NewLine;
                //--- ADD 2012/10/10 2012/11/14配信予定 SCM障害№176対応 ---------->>>>>
                selectTxt += "            , MAX(ISNULL(AUTOANSWERCOUNT,0)) AS AUTOANSWERCOUNT  " + Environment.NewLine;
                selectTxt += "            , MAX(ISNULL(MANUALANSWERCOUNT,0)) AS MANUALANSWERCOUNT  " + Environment.NewLine;
                //--- ADD 2012/10/10 2012/11/14配信予定 SCM障害№176対応 ----------<<<<<
                selectTxt += "          FROM " + Environment.NewLine;
                selectTxt += "            SCMACODRDATARF T1 WITH (READUNCOMMITTED)  " + Environment.NewLine;
                selectTxt += "            INNER JOIN (  " + Environment.NewLine;
                selectTxt += "              SELECT " + Environment.NewLine;
                selectTxt += "                MAX( CAST (UPDATEDATERF AS NVARCHAR) + RIGHT ('000000000' + CAST (UPDATETIMERF AS NVARCHAR), 9 )) AS UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "                , ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "                , INQORIGINALEPCDRF " + Environment.NewLine;
                selectTxt += "                , INQORIGINALSECCDRF " + Environment.NewLine;
                selectTxt += "                , INQOTHEREPCDRF " + Environment.NewLine;
                selectTxt += "                , INQOTHERSECCDRF " + Environment.NewLine;
                selectTxt += "                , INQUIRYNUMBERRF " + Environment.NewLine;
                selectTxt += "                , INQORDDIVCDRF  " + Environment.NewLine;
                selectTxt += "              FROM " + Environment.NewLine;
                selectTxt += "                SCMACODRDATARF WITH (READUNCOMMITTED)  " + Environment.NewLine;
                selectTxt += "              WHERE " + Environment.NewLine;
                selectTxt += "                ENTERPRISECODERF = @ENTERPRISECODE  " + Environment.NewLine;
                selectTxt += "                AND CANCELDIVRF = 1  " + Environment.NewLine;
                selectTxt += "              GROUP BY " + Environment.NewLine;
                selectTxt += "                ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "                , INQORIGINALEPCDRF " + Environment.NewLine;
                selectTxt += "                , INQORIGINALSECCDRF " + Environment.NewLine;
                selectTxt += "                , INQOTHEREPCDRF " + Environment.NewLine;
                selectTxt += "                , INQOTHERSECCDRF " + Environment.NewLine;
                selectTxt += "                , INQUIRYNUMBERRF " + Environment.NewLine;
                selectTxt += "                , INQORDDIVCDRF " + Environment.NewLine;
                selectTxt += "            ) T2  " + Environment.NewLine;
                selectTxt += "              ON T1.ENTERPRISECODERF = T2.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQORIGINALEPCDRF = T2.INQORIGINALEPCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQORIGINALSECCDRF = T2.INQORIGINALSECCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQOTHEREPCDRF = T2.INQOTHEREPCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQOTHERSECCDRF = T2.INQOTHERSECCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQUIRYNUMBERRF = T2.INQUIRYNUMBERRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQORDDIVCDRF = T2.INQORDDIVCDRF  " + Environment.NewLine;
                selectTxt += "              AND CAST (T1.UPDATEDATERF AS NVARCHAR) +  RIGHT ( '000000000' + CAST (T1.UPDATETIMERF AS NVARCHAR), 9) = T2.UPDATEDATETIMERF  " + Environment.NewLine;
                //--- ADD 2012/10/10 2012/11/14配信予定 SCM障害№176対応 ---------->>>>>
                selectTxt += "            LEFT JOIN (  " + Environment.NewLine;
                selectTxt += "              SELECT  " + Environment.NewLine;
                selectTxt += "                  COUNT(ANSWERCREATEDIVRF) AS AUTOANSWERCOUNT  " + Environment.NewLine;
                selectTxt += "                , ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "                , INQORIGINALEPCDRF  " + Environment.NewLine;
                selectTxt += "                , INQORIGINALSECCDRF  " + Environment.NewLine;
                selectTxt += "                , INQOTHEREPCDRF  " + Environment.NewLine;
                selectTxt += "                , INQOTHERSECCDRF  " + Environment.NewLine;
                selectTxt += "                , INQUIRYNUMBERRF  " + Environment.NewLine;
                selectTxt += "                , INQORDDIVCDRF  " + Environment.NewLine;
                selectTxt += "              FROM  " + Environment.NewLine;
                selectTxt += "                SCMACODRDATARF WITH (READUNCOMMITTED)  " + Environment.NewLine;
                selectTxt += "              WHERE  " + Environment.NewLine;
                selectTxt += "                ENTERPRISECODERF = @ENTERPRISECODE  " + Environment.NewLine;
                selectTxt += "                AND CANCELDIVRF = 1  " + Environment.NewLine;
                selectTxt += "                AND ANSWERCREATEDIVRF = 0  " + Environment.NewLine;
                selectTxt += "              GROUP BY " + Environment.NewLine;
                selectTxt += "                  ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "                , INQORIGINALEPCDRF " + Environment.NewLine;
                selectTxt += "                , INQORIGINALSECCDRF " + Environment.NewLine;
                selectTxt += "                , INQOTHEREPCDRF " + Environment.NewLine;
                selectTxt += "                , INQOTHERSECCDRF " + Environment.NewLine;
                selectTxt += "                , INQUIRYNUMBERRF " + Environment.NewLine;
                selectTxt += "                , INQORDDIVCDRF " + Environment.NewLine;
                selectTxt += "            ) T3  " + Environment.NewLine;
                selectTxt += "              ON T1.ENTERPRISECODERF = T3.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQORIGINALEPCDRF = T3.INQORIGINALEPCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQORIGINALSECCDRF = T3.INQORIGINALSECCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQOTHEREPCDRF = T3.INQOTHEREPCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQOTHERSECCDRF = T3.INQOTHERSECCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQUIRYNUMBERRF = T3.INQUIRYNUMBERRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQORDDIVCDRF = T3.INQORDDIVCDRF  " + Environment.NewLine;
                selectTxt += "            LEFT JOIN (  " + Environment.NewLine;
                selectTxt += "              SELECT  " + Environment.NewLine;
                selectTxt += "                  COUNT(ANSWERCREATEDIVRF) AS MANUALANSWERCOUNT  " + Environment.NewLine;
                selectTxt += "                , ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "                , INQORIGINALEPCDRF  " + Environment.NewLine;
                selectTxt += "                , INQORIGINALSECCDRF  " + Environment.NewLine;
                selectTxt += "                , INQOTHEREPCDRF  " + Environment.NewLine;
                selectTxt += "                , INQOTHERSECCDRF  " + Environment.NewLine;
                selectTxt += "                , INQUIRYNUMBERRF  " + Environment.NewLine;
                selectTxt += "                , INQORDDIVCDRF  " + Environment.NewLine;
                selectTxt += "              FROM  " + Environment.NewLine;
                selectTxt += "                SCMACODRDATARF WITH (READUNCOMMITTED)  " + Environment.NewLine;
                selectTxt += "              WHERE  " + Environment.NewLine;
                selectTxt += "                ENTERPRISECODERF = @ENTERPRISECODE  " + Environment.NewLine;
                selectTxt += "                AND CANCELDIVRF = 1  " + Environment.NewLine;
                selectTxt += "                AND ANSWERCREATEDIVRF = 2  " + Environment.NewLine;
                selectTxt += "              GROUP BY " + Environment.NewLine;
                selectTxt += "                  ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "                , INQORIGINALEPCDRF " + Environment.NewLine;
                selectTxt += "                , INQORIGINALSECCDRF " + Environment.NewLine;
                selectTxt += "                , INQOTHEREPCDRF " + Environment.NewLine;
                selectTxt += "                , INQOTHERSECCDRF " + Environment.NewLine;
                selectTxt += "                , INQUIRYNUMBERRF " + Environment.NewLine;
                selectTxt += "                , INQORDDIVCDRF " + Environment.NewLine;
                selectTxt += "            ) T4  " + Environment.NewLine;
                selectTxt += "              ON T1.ENTERPRISECODERF = T4.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQORIGINALEPCDRF = T4.INQORIGINALEPCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQORIGINALSECCDRF = T4.INQORIGINALSECCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQOTHEREPCDRF = T4.INQOTHEREPCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQOTHERSECCDRF = T4.INQOTHERSECCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQUIRYNUMBERRF = T4.INQUIRYNUMBERRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQORDDIVCDRF = T4.INQORDDIVCDRF  " + Environment.NewLine;
                //--- ADD 2012/10/10 2012/11/14配信予定 SCM障害№176対応 ----------<<<<<
                selectTxt += "          WHERE " + Environment.NewLine;
                selectTxt += "            T1.ENTERPRISECODERF = @ENTERPRISECODE  " + Environment.NewLine;
                selectTxt += "            AND CANCELDIVRF = 1  " + Environment.NewLine;
                selectTxt += "          GROUP BY " + Environment.NewLine;
                selectTxt += "            T1.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "            , T1.INQORIGINALEPCDRF " + Environment.NewLine;
                selectTxt += "            , T1.INQORIGINALSECCDRF " + Environment.NewLine;
                selectTxt += "            , T1.INQOTHEREPCDRF " + Environment.NewLine;
                selectTxt += "            , T1.INQOTHERSECCDRF " + Environment.NewLine;
                selectTxt += "            , T1.INQUIRYNUMBERRF " + Environment.NewLine;
                selectTxt += "            , T1.INQORDDIVCDRF " + Environment.NewLine;
                # region 旧SQL
                //selectTxt += "      SELECT    " + Environment.NewLine;
                //// -- UPD 2010/06/17 --------------------------------->>>
                ////selectTxt += "       MAX(cast(UPDATEDATERF as nvarchar) + cast(UPDATETIMERF as nvarchar)) AS UPDATEDATETIMERF   " + Environment.NewLine;
                //selectTxt += "       MAX(cast(UPDATEDATERF as nvarchar) + RIGHT('000000000' + cast(UPDATETIMERF as nvarchar),9)) AS UPDATEDATETIMERF   " + Environment.NewLine;
                //// -- UPD 2010/06/17 ---------------------------------<<<
                //// ADD 2012/07/18 システムテスト障害No.101  yugami ------------------------------------------->>>>>
                //selectTxt += "  	,MAX(SALESSLIPNUMRF) AS SALESSLIPNUMRF   " + Environment.NewLine;
                //// ADD 2012/07/18 システムテスト障害No.101  yugami -------------------------------------------<<<<<
                //selectTxt += "      ,ENTERPRISECODERF   " + Environment.NewLine;
                //selectTxt += "      ,INQORIGINALEPCDRF   " + Environment.NewLine;
                //selectTxt += "      ,INQORIGINALSECCDRF   " + Environment.NewLine;
                //selectTxt += "      ,INQOTHEREPCDRF   " + Environment.NewLine;
                //selectTxt += "      ,INQOTHERSECCDRF   " + Environment.NewLine;
                //selectTxt += "      ,INQUIRYNUMBERRF    " + Environment.NewLine;
                //// 2011/01/24 Add >>>
                //selectTxt += "  	,INQORDDIVCDRF	   " + Environment.NewLine;
                //// 2011/01/24 Add <<<
                //selectTxt += "      FROM SCMACODRDATARF WITH (READUNCOMMITTED) " + Environment.NewLine;
                //selectTxt += "        WHERE" + Environment.NewLine;
                //selectTxt += "              ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                //// 2011/02/18 >>>
                ////selectTxt += "          AND ANSWERDIVCDRF = 99   " + Environment.NewLine;
                ////selectTxt += "          AND INQORDDIVCDRF = 2    " + Environment.NewLine;
                //selectTxt += "          AND CANCELDIVRF = 1   " + Environment.NewLine;
                //// 2011/02/18 <<<
                //selectTxt += "      GROUP BY    " + Environment.NewLine;
                //selectTxt += "       ENTERPRISECODERF   " + Environment.NewLine;
                //selectTxt += "      ,INQORIGINALEPCDRF   " + Environment.NewLine;
                //selectTxt += "      ,INQORIGINALSECCDRF   " + Environment.NewLine;
                //selectTxt += "      ,INQOTHEREPCDRF   " + Environment.NewLine;
                //selectTxt += "      ,INQOTHERSECCDRF   " + Environment.NewLine;
                //selectTxt += "      ,INQUIRYNUMBERRF     " + Environment.NewLine;
                //// 2011/01/24 Add >>>
                //selectTxt += "  	,INQORDDIVCDRF	   " + Environment.NewLine;
                //// 2011/01/24 Add <<<
                #endregion
                // UPD 2012/07/27 T.Yoshioka 2012/08/07配信システムテスト№126対応 -------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                selectTxt += "      ) AS SCM3   " + Environment.NewLine;
                selectTxt += "      ON   " + Environment.NewLine;
                selectTxt += "          SCM3.ENTERPRISECODERF = SCM2.ENTERPRISECODERF   " + Environment.NewLine;
                selectTxt += "      AND SCM3.INQORIGINALEPCDRF = SCM2.INQORIGINALEPCDRF   " + Environment.NewLine;
                selectTxt += "      AND SCM3.INQORIGINALSECCDRF = SCM2.INQORIGINALSECCDRF   " + Environment.NewLine;
                selectTxt += "      AND SCM3.INQOTHEREPCDRF = SCM2.INQOTHEREPCDRF   " + Environment.NewLine;
                selectTxt += "      AND SCM3.INQOTHERSECCDRF = SCM2.INQOTHERSECCDRF   " + Environment.NewLine;
                selectTxt += "      AND SCM3.INQUIRYNUMBERRF = SCM2.INQUIRYNUMBERRF   " + Environment.NewLine;
                // -- UPD 2010/06/17 ----------------------------------------->>>
                //selectTxt += "      AND SCM3.UPDATEDATETIMERF = (cast(SCM2.UPDATEDATERF as nvarchar) + cast(SCM2.UPDATETIMERF as nvarchar))   " + Environment.NewLine;
                selectTxt += "      AND SCM3.UPDATEDATETIMERF = (cast(SCM2.UPDATEDATERF as nvarchar) + RIGHT('000000000' + cast(SCM2.UPDATETIMERF as nvarchar),9))   " + Environment.NewLine;
                // -- UPD 2010/06/17 -----------------------------------------<<<
                // 2011/01/24 Add >>>
                selectTxt += "      AND SCM3.INQORDDIVCDRF = SCM2.INQORDDIVCDRF   " + Environment.NewLine;
                // 2011/01/24 Add <<<
                // ADD 2012/07/18 システムテスト障害No.101  yugami ------------------------------------------->>>>>
                selectTxt += "  	AND SCM3.SALESSLIPNUMRF = SCM2.SALESSLIPNUMRF   " + Environment.NewLine;
                // ADD 2012/07/18 システムテスト障害No.101  yugami -------------------------------------------<<<<<
                selectTxt += "    ) AS SCM   " + Environment.NewLine;
                selectTxt += "   LEFT JOIN SCMACODRDTCARRF AS CAR WITH (READUNCOMMITTED)  " + Environment.NewLine;
                selectTxt += "    ON  " + Environment.NewLine;
                selectTxt += "        CAR.ENTERPRISECODERF = SCM.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "    AND CAR.INQORIGINALEPCDRF = SCM.INQORIGINALEPCDRF  " + Environment.NewLine;
                selectTxt += "    AND CAR.INQORIGINALSECCDRF = SCM.INQORIGINALSECCDRF  " + Environment.NewLine;
                selectTxt += "    AND CAR.INQUIRYNUMBERRF = SCM.INQUIRYNUMBERRF " + Environment.NewLine;
                selectTxt += "    AND CAR.ACPTANODRSTATUSRF = SCM.ACPTANODRSTATUSRF " + Environment.NewLine;
                selectTxt += "    AND CAR.SALESSLIPNUMRF = SCM.SALESSLIPNUMRF  " + Environment.NewLine;
                selectTxt += "   LEFT JOIN CUSTOMERRF AS CUS WITH (READUNCOMMITTED) " + Environment.NewLine;
                selectTxt += "    ON  " + Environment.NewLine;
                selectTxt += "        CUS.ENTERPRISECODERF = SCM.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "    AND CUS.CUSTOMERCODERF = SCM.CUSTOMERCODERF  " + Environment.NewLine;

                //WHERE文の作成
                selectTxt += MakeWhereString(ref sqlCommand, scmInquiryOrderWork, logicalMode);

                sqlCommand.CommandText = selectTxt;

                #endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(Broadleaf.Library.Diagnostics.NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region 抽出結果-値セット

                    // 伝票
                    SCMInquiryResultWork wkSCMInquiryResultWork = new SCMInquiryResultWork();

                    #region 格納項目-伝票
                    wkSCMInquiryResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF")); // 企業コード
                    wkSCMInquiryResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));  // 得意先コード
                    wkSCMInquiryResultWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));  // 得意先名称
                    wkSCMInquiryResultWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));  // 受注ステータス
                    wkSCMInquiryResultWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));  // 売上伝票番号
                    wkSCMInquiryResultWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALEPCDRF")).Trim();  // 問合せ元企業コード//@@@@20230303
                    wkSCMInquiryResultWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALSECCDRF"));  // 問合せ元拠点コード
                    wkSCMInquiryResultWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHEREPCDRF"));  // 問合せ先企業コード
                    wkSCMInquiryResultWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHERSECCDRF"));  // 問合せ先拠点コード
                    wkSCMInquiryResultWork.InquiryNumber = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INQUIRYNUMBERRF"));  // 問合せ番号
                    wkSCMInquiryResultWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));  // 更新年月日
                    wkSCMInquiryResultWork.UpdateTime = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATETIMERF"));  // 更新時間
                    wkSCMInquiryResultWork.InqOrdDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQORDDIVCDRF"));  // 問合せ・発注種別
                    wkSCMInquiryResultWork.AnswerDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERDIVCDRF"));  // 回答区分
                    wkSCMInquiryResultWork.JudgementDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JUDGEMENTDATERF"));  // 確定日
                    wkSCMInquiryResultWork.InqOrdNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORDNOTERF"));  // 問合せ・発注備考
                    wkSCMInquiryResultWork.InqEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQEMPLOYEECDRF"));  // 問合せ従業員コード
                    wkSCMInquiryResultWork.InqEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQEMPLOYEENMRF"));  // 問合せ従業員名称
                    wkSCMInquiryResultWork.AnsEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSEMPLOYEECDRF"));  // 回答従業員コード
                    wkSCMInquiryResultWork.AnsEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSEMPLOYEENMRF"));  // 回答従業員名称
                    wkSCMInquiryResultWork.InquiryDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQUIRYDATERF"));  // 問合せ日
                    wkSCMInquiryResultWork.NumberPlate1Code = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE1CODERF"));  // 陸運事務所番号
                    wkSCMInquiryResultWork.NumberPlate1Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE1NAMERF"));  // 陸運事務局名称
                    wkSCMInquiryResultWork.NumberPlate2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE2RF"));  // 車両登録番号（種別）
                    wkSCMInquiryResultWork.NumberPlate3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE3RF"));  // 車両登録番号（カナ）
                    wkSCMInquiryResultWork.NumberPlate4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE4RF"));  // 車両登録番号（プレート番号）
                    wkSCMInquiryResultWork.ModelDesignationNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));  // 型式指定番号
                    wkSCMInquiryResultWork.CategoryNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));  // 類別番号
                    wkSCMInquiryResultWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));  // メーカーコード
                    wkSCMInquiryResultWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));  // 車種コード
                    wkSCMInquiryResultWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));  // 車種サブコード
                    wkSCMInquiryResultWork.ModelName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELNAMERF"));  // 車種名
                    wkSCMInquiryResultWork.CarInspectCertModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARINSPECTCERTMODELRF"));  // 車検証型式
                    wkSCMInquiryResultWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));  // 型式（フル型）
                    wkSCMInquiryResultWork.FrameNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMENORF"));  // 車台番号
                    wkSCMInquiryResultWork.FrameModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMEMODELRF"));  // 車台型式
                    wkSCMInquiryResultWork.ChassisNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHASSISNORF"));  // シャシーNo
                    wkSCMInquiryResultWork.CarProperNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARPROPERNORF"));  // 車両固有番号
                    wkSCMInquiryResultWork.ProduceTypeOfYearNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRODUCETYPEOFYEARNUMRF"));  // 生産年式（NUMタイプ）
                    wkSCMInquiryResultWork.Comment = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMMENTRF"));  // コメント
                    wkSCMInquiryResultWork.RpColorCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RPCOLORCODERF"));  // リペアカラーコード
                    wkSCMInquiryResultWork.ColorName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORNAME1RF"));  // カラー名称1
                    wkSCMInquiryResultWork.TrimCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMCODERF"));  // トリムコード
                    wkSCMInquiryResultWork.TrimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMNAMERF"));  // トリム名称
                    wkSCMInquiryResultWork.Mileage = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MILEAGERF"));  // 車両走行距離      
                    wkSCMInquiryResultWork.UpdateTime = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATETIMERF"));  // 更新時間   
                    wkSCMInquiryResultWork.AwnserMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERCREATEDIVRF"));  // 回答方法
                    wkSCMInquiryResultWork.SalesTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXINCRF"));  // 売上伝票合計（税込み）
                    // -- UPD 2010/06/17 ------------------------------------------------->>>
                    wkSCMInquiryResultWork.CancelDiv = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("CANCELDIVRF"));  // キャンセル区分
                    wkSCMInquiryResultWork.CMTCooprtDiv = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("CMTCOOPRTDIVRF"));  // CMT連携区分
                    // -- UPD 2010/06/17 -------------------------------------------------<<<
                    wkSCMInquiryResultWork.SfPmCprtInstSlipNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SFPMCPRTINSTSLIPNORF"));  // SF-PM連携指示書番号
                    // -- ADD gezh 2011/11/12 ------------------------------------------------->>>>>
                    wkSCMInquiryResultWork.CooperationOptionDiv = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ACCEPTORORDERKINDRF"));  // 連携対象区分
                    // -- ADD gezh 2011/11/12 -------------------------------------------------<<<<<
                    //--- ADD 2012/10/10 2012/11/14配信予定 SCM障害№176対応 ---------->>>>>
                    wkSCMInquiryResultWork.AutoAnswerCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOANSWERCOUNT"));  // 回答方法件数（自動回答分）
                    wkSCMInquiryResultWork.ManualAnswerCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MANUALANSWERCOUNT"));  // 回答方法件数（手動回答分）
                    //--- ADD 2012/10/10 2012/11/14配信予定 SCM障害№176対応 ----------<<<<<
                    // ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
                    wkSCMInquiryResultWork.ExpectedCeDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EXPECTEDCEDATERF"));  // 入庫予定日
                    // ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<
                    #endregion
                    #endregion

                    SlipList.Add(wkSCMInquiryResultWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                // 最後の伝票情報追加
                if (SlipList.Count != 0)
                {
                    retList.Add(SlipList);
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMInquiryDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// SCM問い合わせ一覧LISTを全て戻します（キャンセル以外分、キャンセル分の両方）
        /// </summary>
        /// <param name="scmInquiryResultWork">キャンセル以外分の検索結果</param>
        /// <param name="scmInquiryResultWorkCancel">キャンセル分の検索結果</param>
        /// <param name="objscmInquiryResultWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードのSCM問い合わせ一覧LISTを全て戻します（キャンセル以外分、キャンセル分の両方）</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2010/04/13</br>
        public int SearchDetailAll(out object scmInquiryResultWork, out object scmInquiryResultWorkCancel, object objscmInquiryResultWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            scmInquiryResultWork = null;
            scmInquiryResultWorkCancel = null;

            SCMInquiryResultWork parascmInquiryResultWork = objscmInquiryResultWork as SCMInquiryResultWork;

            try
            {
                status = SearchDetailAllProc(out scmInquiryResultWork, out scmInquiryResultWorkCancel, parascmInquiryResultWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMInquiryDB.SearchDetailAll Exception=" + ex.Message);
                scmInquiryResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// SCM問い合わせ一覧LISTを全て戻します（キャンセル以外分、キャンセル分の両方）
        /// </summary>
        /// <param name="scmInquiryResultWork">キャンセル以外分の検索結果</param>
        /// <param name="scmInquiryResultWorkCancel">キャンセル分の検索結果</param>
        /// <param name="objscmInquiryResultWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードのSCM問い合わせ一覧のLISTを全て戻します</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2010/04/13</br>
        private int SearchDetailAllProc(out object scmInquiryResultWork, out object scmInquiryResultWorkCancel, SCMInquiryResultWork parascmInquiryResultWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            scmInquiryResultWork = null;
            scmInquiryResultWorkCancel = null;

            CustomSerializeArrayList retList = new CustomSerializeArrayList(); // キャンセル以外の明細抽出結果
            CustomSerializeArrayList retCancelList = new CustomSerializeArrayList(); // キャンセルの明細抽出結果

            try
            {
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //キャンセル分の抽出
                parascmInquiryResultWork.AnswerDivCd = 20;  //パラメータはキャンセル以外ならなんでもいいが、とりあえず20:回答完了をセット

                // 問い合わせ抽出
                status = SearchDetailInqProc(ref retList, ref sqlConnection, parascmInquiryResultWork, logicalMode);

                // 回答抽出
                status = SearchDetailAnsProc(ref retList, ref sqlConnection, parascmInquiryResultWork, logicalMode);

                //キャンセル分の抽出
                parascmInquiryResultWork.AnswerDivCd = 99;  //99:キャンセル

                // 問い合わせ抽出
                status = SearchDetailInqProc(ref retCancelList, ref sqlConnection, parascmInquiryResultWork, logicalMode);

                // 回答抽出
                status = SearchDetailAnsProc(ref retCancelList, ref sqlConnection, parascmInquiryResultWork, logicalMode);

                //回答がなくても正常とする
                if (status == (int)ConstantManagement.DB_Status.ctDB_EOF && (retList.Count > 0 || retCancelList.Count > 0))
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMInquiryDB.SearchDetailAllProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            scmInquiryResultWork = retList;
            scmInquiryResultWorkCancel = retCancelList;

            return status;
        }
        // -- UPD 2010/04/13 -----------------------------------------------------------<<<

        /// <summary>
        /// 指定された企業コードのSCM問い合わせ一覧のLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="supplierUnmResultWork">検索結果</param>
        /// <param name="supplierUnmOrderCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードのSCM問い合わせ一覧LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2009.05.14</br>
        public int SearchDetail(out object scmInquiryResultWork, object objscmInquiryResultWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            scmInquiryResultWork = null;

            SCMInquiryResultWork parascmInquiryResultWork = objscmInquiryResultWork as SCMInquiryResultWork;

            try
            {
                status = SearchDetailProc(out scmInquiryResultWork, parascmInquiryResultWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMInquiryDB.SearchDetail Exception=" + ex.Message);
                scmInquiryResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードのSCM問い合わせ一覧のLISTを全て戻します
        /// </summary>
        /// <param name="supplierSendErResultWork">検索結果</param>
        /// <param name="_supplierSendErOrderCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードのSCM問い合わせ一覧のLISTを全て戻します</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2009.05.14</br>
        private int SearchDetailProc(out object scmInquiryResultWork, SCMInquiryResultWork parascmInquiryResultWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            scmInquiryResultWork = null;

            CustomSerializeArrayList retList = new CustomSerializeArrayList(); // 伝票リスト情報抽出結果

            try
            {
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                // 問い合わせ抽出
                status = SearchDetailInqProc(ref retList, ref sqlConnection, parascmInquiryResultWork, logicalMode);

                // 回答抽出
                status = SearchDetailAnsProc(ref retList, ref sqlConnection, parascmInquiryResultWork, logicalMode);

                //回答がなくても正常とする
                if (status == (int)ConstantManagement.DB_Status.ctDB_EOF && retList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMInquiryDB.SearchDetailProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            scmInquiryResultWork = retList;

            return status;
        }

        /// <summary>
        /// 問い合わせ明細抽出
        /// </summary>
        /// <param name="retList">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="parascmInquiryResultWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        private int SearchDetailInqProc(ref CustomSerializeArrayList retList, ref SqlConnection sqlConnection, SCMInquiryResultWork parascmInquiryResultWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            // 伝票リスト
            CustomSerializeArrayList DetailList = new CustomSerializeArrayList();

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                #region Select文作成
                // -- UPD 2010/04/13-------------------------------->>>
                #region [削除]
                //selectTxt += "  SELECT " + Environment.NewLine;
                //selectTxt += " 	    SCM.ENTERPRISECODERF  " + Environment.NewLine;
                //selectTxt += " 	   ,SCM.INQORIGINALEPCDRF  " + Environment.NewLine;
                //selectTxt += " 	   ,SCM.INQORIGINALSECCDRF  " + Environment.NewLine;
                //selectTxt += " 	   ,SCM.INQUIRYNUMBERRF  " + Environment.NewLine;
                //selectTxt += " 	   ,SCM.UPDATEDATERF  " + Environment.NewLine;
                //selectTxt += " 	   ,SCM.UPDATETIMERF  " + Environment.NewLine;
                //selectTxt += " 	   ,SCM.INQROWNUMBERRF  " + Environment.NewLine;
                //selectTxt += " 	   ,SCM.INQROWNUMDERIVEDNORF  " + Environment.NewLine;
                //selectTxt += "     ,SCM.INQORGDTLDISCGUIDRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.INQOTHDTLDISCGUIDRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.GOODSDIVCDRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.DELIVEREDGOODSDIVRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.HANDLEDIVCODERF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.GOODSSHAPERF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.DELIVRDGDSCONFCDRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.DELIGDSCMPLTDUEDATERF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.BLGOODSCODERF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.BLGOODSDRCODERF   " + Environment.NewLine;
                //selectTxt += "	   ,SCM.INQPUREGOODSNORF " + Environment.NewLine;
                //selectTxt += "	   ,SCM.ANSPUREGOODSNORF " + Environment.NewLine;
                //selectTxt += "     ,SCM.SALESORDERCOUNTRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.DELIVEREDGOODSCOUNTRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.GOODSNORF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.GOODSMAKERCDRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.PUREGOODSMAKERCDRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.INQGOODSNAMERF " + Environment.NewLine;
                //selectTxt += "	   ,SCM.ANSGOODSNAMERF " + Environment.NewLine;
                //selectTxt += "     ,SCM.LISTPRICERF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.UNITPRICERF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.GOODSADDINFORF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.ROUGHRROFITRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.ROUGHRATERF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.ANSWERLIMITDATERF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.COMMENTDTLRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.SHELFNORF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.ADDITIONALDIVCDRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.CORRECTDIVCDRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.INQORDDIVCDRF  " + Environment.NewLine;
                //selectTxt += "     ,SCM.ANSWERDELIVERYDATERF  " + Environment.NewLine;
                //// 2009.08.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //selectTxt += "     ,SCM.RECYCLEPRTKINDCODERF  " + Environment.NewLine;
                //selectTxt += "     ,SCM.RECYCLEPRTKINDNAMERF  " + Environment.NewLine;
                //// 2009.08.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                //selectTxt += "   FROM SCMACODRDTLIQRF AS SCM " + Environment.NewLine;
                //selectTxt += "    INNER JOIN   " + Environment.NewLine;
                //selectTxt += "    (   " + Environment.NewLine;
                //selectTxt += "  	 SELECT    " + Environment.NewLine;
                //// -- UPD 2010/03/11 -------------------------------------------------->>>
                ////selectTxt += "  	   MAX(UPDATETIMERF) AS UPDATETIMERF   " + Environment.NewLine;
                ////selectTxt += "  	  ,MAX(UPDATEDATERF) AS UPDATEDATERF   " + Environment.NewLine;
                //selectTxt += "  	   MAX(cast(UPDATEDATERF as nvarchar) + cast(UPDATETIMERF as nvarchar)) AS UPDATEDATETIMERF   " + Environment.NewLine;
                //// -- UPD 2010/03/11 --------------------------------------------------<<<
                //selectTxt += "  	  ,ENTERPRISECODERF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQORIGINALEPCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQORIGINALSECCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQOTHEREPCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQOTHERSECCDRF    " + Environment.NewLine;
                //selectTxt += "  	  ,INQUIRYNUMBERRF  " + Environment.NewLine;
                //selectTxt += "  	  ,INQROWNUMBERRF	   " + Environment.NewLine;
                //selectTxt += "  	  ,INQROWNUMDERIVEDNORF  " + Environment.NewLine;
                //selectTxt += "  	 FROM SCMACODRDTLIQRF    " + Environment.NewLine;
                //selectTxt += "  	 GROUP BY    " + Environment.NewLine;
                //selectTxt += "  	   ENTERPRISECODERF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQORIGINALEPCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQORIGINALSECCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQOTHEREPCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQOTHERSECCDRF    " + Environment.NewLine;
                //selectTxt += "  	  ,INQUIRYNUMBERRF  " + Environment.NewLine;
                //selectTxt += "  	  ,INQROWNUMBERRF	   " + Environment.NewLine;
                //selectTxt += "  	  ,INQROWNUMDERIVEDNORF  " + Environment.NewLine;
                //selectTxt += "    ) AS SCM2   " + Environment.NewLine;
                //selectTxt += "    ON   " + Environment.NewLine;
                //selectTxt += "        SCM2.ENTERPRISECODERF = SCM.ENTERPRISECODERF   " + Environment.NewLine;
                //selectTxt += "    AND SCM2.INQORIGINALEPCDRF = SCM.INQORIGINALEPCDRF" + Environment.NewLine;
                //selectTxt += "    AND SCM2.INQORIGINALSECCDRF = SCM.INQORIGINALSECCDRF" + Environment.NewLine;
                //selectTxt += "    AND SCM2.INQOTHEREPCDRF = SCM.INQOTHEREPCDRF" + Environment.NewLine;
                //selectTxt += "    AND SCM2.INQOTHERSECCDRF = SCM.INQOTHERSECCDRF" + Environment.NewLine;
                //selectTxt += "    AND SCM2.INQUIRYNUMBERRF = SCM.INQUIRYNUMBERRF" + Environment.NewLine;
                //// -- UPD 2010/03/11 -------------------------------------------------->>>
                ////selectTxt += "    AND SCM2.UPDATEDATERF = SCM.UPDATEDATERF" + Environment.NewLine;
                ////selectTxt += "    AND SCM2.UPDATETIMERF = SCM.UPDATETIMERF" + Environment.NewLine;
                //selectTxt += "    AND SCM2.UPDATEDATETIMERF = (cast(SCM.UPDATEDATERF as nvarchar) + cast(SCM.UPDATETIMERF as nvarchar))   " + Environment.NewLine;
                //// -- UPD 2010/03/11 --------------------------------------------------<<<
                //selectTxt += "    AND SCM2.INQROWNUMBERRF = SCM.INQROWNUMBERRF" + Environment.NewLine;
                //selectTxt += "    AND SCM2.INQROWNUMDERIVEDNORF = SCM.INQROWNUMDERIVEDNORF" + Environment.NewLine;
                //selectTxt += "  WHERE  " + Environment.NewLine;
                //selectTxt += "        SCM.ENTERPRISECODERF = @ENTERPRISECODE  " + Environment.NewLine;
                //selectTxt += "    AND SCM.INQORIGINALEPCDRF = @INQORIGINALEPCD  " + Environment.NewLine;
                //selectTxt += "    AND SCM.INQORIGINALSECCDRF = @INQORIGINALSECCD  " + Environment.NewLine;
                //selectTxt += "    AND SCM.INQUIRYNUMBERRF = @INQUIRYNUMBER  " + Environment.NewLine;
                //selectTxt += "    AND SCM.INQOTHEREPCDRF = @INQOTHEREPCD  " + Environment.NewLine;
                //selectTxt += "    AND SCM.INQOTHERSECCDRF = @INQOTHERSECCD  " + Environment.NewLine;
                //selectTxt += "    AND SCM.INQORDDIVCDRF = @INQORDDIVCD  " + Environment.NewLine;
                #endregion

                if (parascmInquiryResultWork.AnswerDivCd != 99)
                {
                    //キャンセル以外の抽出クエリ
                    selectTxt += "  SELECT " + Environment.NewLine;
                    selectTxt += " 	    SCM.ENTERPRISECODERF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQORIGINALEPCDRF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQORIGINALSECCDRF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQUIRYNUMBERRF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.UPDATEDATERF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.UPDATETIMERF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQROWNUMBERRF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQROWNUMDERIVEDNORF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.INQORGDTLDISCGUIDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.INQOTHDTLDISCGUIDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSDIVCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.DELIVEREDGOODSDIVRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.HANDLEDIVCODERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSSHAPERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.DELIVRDGDSCONFCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.DELIGDSCMPLTDUEDATERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.BLGOODSCODERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.BLGOODSDRCODERF   " + Environment.NewLine;
                    selectTxt += "	   ,SCM.INQPUREGOODSNORF " + Environment.NewLine;
                    selectTxt += "	   ,SCM.ANSPUREGOODSNORF " + Environment.NewLine;
                    selectTxt += "     ,SCM.SALESORDERCOUNTRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.DELIVEREDGOODSCOUNTRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSNORF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSMAKERCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.PUREGOODSMAKERCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.INQGOODSNAMERF " + Environment.NewLine;
                    selectTxt += "	   ,SCM.ANSGOODSNAMERF " + Environment.NewLine;
                    selectTxt += "     ,SCM.LISTPRICERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.UNITPRICERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSADDINFORF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.ROUGHRROFITRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.ROUGHRATERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.ANSWERLIMITDATERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.COMMENTDTLRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.SHELFNORF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.ADDITIONALDIVCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.CORRECTDIVCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.INQORDDIVCDRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.ANSWERDELIVERYDATERF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.RECYCLEPRTKINDCODERF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.RECYCLEPRTKINDNAMERF  " + Environment.NewLine;
                    // -- ADD 2010/06/17 ------------------------------------->>>
                    selectTxt += "     ,SCM.CANCELCNDTINDIVRF" + Environment.NewLine;
                    selectTxt += "     ,SCM.ACPTANODRSTATUSRF" + Environment.NewLine;
                    selectTxt += "     ,SCM.SALESSLIPNUMRF" + Environment.NewLine;
                    selectTxt += "     ,SCM.SALESROWNORF" + Environment.NewLine;
                    // -- ADD 2010/06/17 -------------------------------------<<<
                    //--- ADD 2011/05/26 ------------------------------------->>>
                    selectTxt += "     ,SCM.WAREHOUSECODERF" + Environment.NewLine;
                    selectTxt += "     ,SCM.WAREHOUSENAMERF" + Environment.NewLine;
                    selectTxt += "     ,SCM.WAREHOUSESHELFNORF" + Environment.NewLine;
                    //--- ADD 2011/05/26 -------------------------------------<<<
                    // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                    selectTxt += "     ,SCM.PMMAINMNGWAREHOUSECDRF " + Environment.NewLine;
                    selectTxt += "     ,SCM.PMMAINMNGWAREHOUSENAMERF " + Environment.NewLine;
                    selectTxt += "     ,SCM.PMMAINMNGSHELFNORF" + Environment.NewLine;
                    selectTxt += "     ,SCM.PMMAINMNGPRSNTCOUNTRF" + Environment.NewLine;
                    // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                    // ADD 2015/02/20 吉岡 SCM高速化 C向け種別特記対応   -------------->>>>>>>>>>>>>>>>>>>>
                    selectTxt += "     ,SCM.GOODSSPECIALNTFORFACRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSSPECIALNTFORCOWRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.PRMSETDTLNAME2FORFACRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.PRMSETDTLNAME2FORCOWRF  " + Environment.NewLine;
                    // ADD 2015/02/20 吉岡 SCM高速化 C向け種別特記対応   --------------<<<<<<<<<<<<<<<<<<<<
                    selectTxt += "   FROM SCMACODRDTLIQRF AS SCM WITH (READUNCOMMITTED)" + Environment.NewLine;
                    selectTxt += "    INNER JOIN   " + Environment.NewLine;
                    selectTxt += "    (   " + Environment.NewLine;
                    selectTxt += "  	 SELECT    " + Environment.NewLine;
                    // -- UPD 2010/06/17 ----------------------------->>>
                    //selectTxt += "  	   MAX(cast(SCMIQ.UPDATEDATERF as nvarchar) + cast(SCMIQ.UPDATETIMERF as nvarchar)) AS UPDATEDATETIMERF   " + Environment.NewLine;
                    selectTxt += "  	   MAX(cast(SCMIQ.UPDATEDATERF as nvarchar) + RIGHT('000000000' + cast(SCMIQ.UPDATETIMERF as nvarchar),9)) AS UPDATEDATETIMERF   " + Environment.NewLine;
                    // -- UPD 2010/06/17 -----------------------------<<<
                    selectTxt += "  	  ,SCMIQ.ENTERPRISECODERF   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMIQ.INQORIGINALEPCDRF   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMIQ.INQORIGINALSECCDRF   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMIQ.INQOTHEREPCDRF   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMIQ.INQOTHERSECCDRF    " + Environment.NewLine;
                    selectTxt += "  	  ,SCMIQ.INQUIRYNUMBERRF  " + Environment.NewLine;
                    selectTxt += "  	  ,SCMIQ.INQROWNUMBERRF	   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMIQ.INQROWNUMDERIVEDNORF  " + Environment.NewLine;
                    selectTxt += "  	 FROM SCMACODRDTLIQRF AS SCMIQ WITH (READUNCOMMITTED)  " + Environment.NewLine;
                    selectTxt += "       INNER JOIN   " + Environment.NewLine;
                    selectTxt += "       (   " + Environment.NewLine;
                    selectTxt += "         SELECT    " + Environment.NewLine;
                    selectTxt += "  	     ENTERPRISECODERF   " + Environment.NewLine;
                    selectTxt += "          ,INQORIGINALEPCDRF   " + Environment.NewLine;
                    selectTxt += "          ,INQORIGINALSECCDRF   " + Environment.NewLine;
                    selectTxt += "          ,INQOTHEREPCDRF   " + Environment.NewLine;
                    selectTxt += "          ,INQOTHERSECCDRF    " + Environment.NewLine;
                    selectTxt += "          ,INQUIRYNUMBERRF  " + Environment.NewLine;
                    selectTxt += "          ,UPDATEDATERF  " + Environment.NewLine;
                    selectTxt += "          ,UPDATETIMERF  " + Environment.NewLine;
                    selectTxt += "  	   FROM SCMACODRDATARF WITH (READUNCOMMITTED) " + Environment.NewLine;
                    selectTxt += "         WHERE" + Environment.NewLine;
                    selectTxt += "             ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                    // 2011/01/24 Add >>>
                    selectTxt += "             AND INQORIGINALEPCDRF = @INQORIGINALEPCD  " + Environment.NewLine;
                    selectTxt += "             AND INQORIGINALSECCDRF = @INQORIGINALSECCD  " + Environment.NewLine;
                    selectTxt += "             AND INQUIRYNUMBERRF = @INQUIRYNUMBER  " + Environment.NewLine;
                    selectTxt += "             AND INQOTHEREPCDRF = @INQOTHEREPCD  " + Environment.NewLine;
                    selectTxt += "             AND INQOTHERSECCDRF = @INQOTHERSECCD  " + Environment.NewLine;
                    selectTxt += "             AND INQORDDIVCDRF = @INQORDDIVCD  " + Environment.NewLine;
                    // 2011/01/24 Add <<<
                    // 2011/02/18 >>>
                    //selectTxt += "         AND ANSWERDIVCDRF <> 99   " + Environment.NewLine;
                    selectTxt += "         AND CANCELDIVRF <> 1   " + Environment.NewLine;
                    // 2011/02/18 <<<
                    selectTxt += "       ) AS SCMODR   " + Environment.NewLine;
                    selectTxt += "       ON   " + Environment.NewLine;
                    selectTxt += "           SCMODR.ENTERPRISECODERF = SCMIQ.ENTERPRISECODERF   " + Environment.NewLine;
                    selectTxt += "       AND SCMODR.INQORIGINALEPCDRF = SCMIQ.INQORIGINALEPCDRF" + Environment.NewLine;
                    selectTxt += "       AND SCMODR.INQORIGINALSECCDRF = SCMIQ.INQORIGINALSECCDRF" + Environment.NewLine;
                    selectTxt += "       AND SCMODR.INQOTHEREPCDRF = SCMIQ.INQOTHEREPCDRF" + Environment.NewLine;
                    selectTxt += "       AND SCMODR.INQOTHERSECCDRF = SCMIQ.INQOTHERSECCDRF" + Environment.NewLine;
                    selectTxt += "       AND SCMODR.INQUIRYNUMBERRF = SCMIQ.INQUIRYNUMBERRF" + Environment.NewLine;
                    selectTxt += "       AND SCMODR.UPDATEDATERF = SCMIQ.UPDATEDATERF" + Environment.NewLine;
                    selectTxt += "       AND SCMODR.UPDATETIMERF = SCMIQ.UPDATETIMERF" + Environment.NewLine;
                    selectTxt += "  	 GROUP BY    " + Environment.NewLine;
                    selectTxt += "  	   SCMIQ.ENTERPRISECODERF   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMIQ.INQORIGINALEPCDRF   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMIQ.INQORIGINALSECCDRF   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMIQ.INQOTHEREPCDRF   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMIQ.INQOTHERSECCDRF    " + Environment.NewLine;
                    selectTxt += "  	  ,SCMIQ.INQUIRYNUMBERRF  " + Environment.NewLine;
                    selectTxt += "  	  ,SCMIQ.INQROWNUMBERRF	   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMIQ.INQROWNUMDERIVEDNORF  " + Environment.NewLine;
                    selectTxt += "    ) AS SCM2   " + Environment.NewLine;
                    selectTxt += "    ON   " + Environment.NewLine;
                    selectTxt += "        SCM2.ENTERPRISECODERF = SCM.ENTERPRISECODERF   " + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQORIGINALEPCDRF = SCM.INQORIGINALEPCDRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQORIGINALSECCDRF = SCM.INQORIGINALSECCDRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQOTHEREPCDRF = SCM.INQOTHEREPCDRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQOTHERSECCDRF = SCM.INQOTHERSECCDRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQUIRYNUMBERRF = SCM.INQUIRYNUMBERRF" + Environment.NewLine;
                    // -- UPD 2010/06/17 ----------------------------------->>>
                    //selectTxt += "    AND SCM2.UPDATEDATETIMERF = (cast(SCM.UPDATEDATERF as nvarchar) + cast(SCM.UPDATETIMERF as nvarchar))   " + Environment.NewLine;
                    selectTxt += "    AND SCM2.UPDATEDATETIMERF = (cast(SCM.UPDATEDATERF as nvarchar) + RIGHT('000000000' + cast(SCM.UPDATETIMERF as nvarchar),9))   " + Environment.NewLine;
                    // -- UPD 2010/06/17 -----------------------------------<<<
                    selectTxt += "    AND SCM2.INQROWNUMBERRF = SCM.INQROWNUMBERRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQROWNUMDERIVEDNORF = SCM.INQROWNUMDERIVEDNORF" + Environment.NewLine;
                    selectTxt += "  WHERE  " + Environment.NewLine;
                    selectTxt += "        SCM.ENTERPRISECODERF = @ENTERPRISECODE  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQORIGINALEPCDRF = @INQORIGINALEPCD  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQORIGINALSECCDRF = @INQORIGINALSECCD  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQUIRYNUMBERRF = @INQUIRYNUMBER  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQOTHEREPCDRF = @INQOTHEREPCD  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQOTHERSECCDRF = @INQOTHERSECCD  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQORDDIVCDRF = @INQORDDIVCD  " + Environment.NewLine;
                }
                else
                {
                    //キャンセル分の抽出クエリ
                    selectTxt += "  SELECT " + Environment.NewLine;
                    selectTxt += " 	    SCM.ENTERPRISECODERF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQORIGINALEPCDRF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQORIGINALSECCDRF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQUIRYNUMBERRF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.UPDATEDATERF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.UPDATETIMERF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQROWNUMBERRF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQROWNUMDERIVEDNORF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.INQORGDTLDISCGUIDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.INQOTHDTLDISCGUIDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSDIVCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.DELIVEREDGOODSDIVRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.HANDLEDIVCODERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSSHAPERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.DELIVRDGDSCONFCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.DELIGDSCMPLTDUEDATERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.BLGOODSCODERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.BLGOODSDRCODERF   " + Environment.NewLine;
                    selectTxt += "	   ,SCM.INQPUREGOODSNORF " + Environment.NewLine;
                    selectTxt += "	   ,SCM.ANSPUREGOODSNORF " + Environment.NewLine;
                    selectTxt += "     ,SCM.SALESORDERCOUNTRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.DELIVEREDGOODSCOUNTRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSNORF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSMAKERCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.PUREGOODSMAKERCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.INQGOODSNAMERF " + Environment.NewLine;
                    selectTxt += "	   ,SCM.ANSGOODSNAMERF " + Environment.NewLine;
                    selectTxt += "     ,SCM.LISTPRICERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.UNITPRICERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSADDINFORF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.ROUGHRROFITRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.ROUGHRATERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.ANSWERLIMITDATERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.COMMENTDTLRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.SHELFNORF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.ADDITIONALDIVCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.CORRECTDIVCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.INQORDDIVCDRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.ANSWERDELIVERYDATERF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.RECYCLEPRTKINDCODERF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.RECYCLEPRTKINDNAMERF  " + Environment.NewLine;
                    // -- ADD 2010/06/17 ------------------------------------->>>
                    selectTxt += "     ,SCM.CANCELCNDTINDIVRF" + Environment.NewLine;
                    selectTxt += "     ,SCM.ACPTANODRSTATUSRF" + Environment.NewLine;
                    selectTxt += "     ,SCM.SALESSLIPNUMRF" + Environment.NewLine;
                    selectTxt += "     ,SCM.SALESROWNORF" + Environment.NewLine;
                    // -- ADD 2010/06/17 -------------------------------------<<<
                    //--- ADD 2011/05/26 ------------------------------------->>>
                    selectTxt += "     ,SCM.WAREHOUSECODERF" + Environment.NewLine;
                    selectTxt += "     ,SCM.WAREHOUSENAMERF" + Environment.NewLine;
                    selectTxt += "     ,SCM.WAREHOUSESHELFNORF" + Environment.NewLine;
                    //--- ADD 2011/05/26 -------------------------------------<<<
                    // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                    selectTxt += "     ,SCM.PMMAINMNGWAREHOUSECDRF" + Environment.NewLine;
                    selectTxt += "     ,SCM.PMMAINMNGWAREHOUSENAMERF" + Environment.NewLine;
                    selectTxt += "     ,SCM.PMMAINMNGSHELFNORF" + Environment.NewLine;
                    selectTxt += "     ,SCM.PMMAINMNGPRSNTCOUNTRF" + Environment.NewLine;
                    // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                    // ADD 2015/02/20 吉岡 SCM高速化 C向け種別特記対応   -------------->>>>>>>>>>>>>>>>>>>>
                    selectTxt += "     ,SCM.GOODSSPECIALNTFORFACRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSSPECIALNTFORCOWRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.PRMSETDTLNAME2FORFACRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.PRMSETDTLNAME2FORCOWRF  " + Environment.NewLine;
                    // ADD 2015/02/20 吉岡 SCM高速化 C向け種別特記対応   --------------<<<<<<<<<<<<<<<<<<<<
                    selectTxt += "   FROM SCMACODRDTLIQRF AS SCM WITH (READUNCOMMITTED)" + Environment.NewLine;
                    selectTxt += "   INNER JOIN   " + Environment.NewLine;
                    selectTxt += "    (   " + Environment.NewLine;
                    selectTxt += "  	 SELECT    " + Environment.NewLine;
                    selectTxt += "  	   ENTERPRISECODERF   " + Environment.NewLine;
                    selectTxt += "  	  ,INQORIGINALEPCDRF   " + Environment.NewLine;
                    selectTxt += "  	  ,INQORIGINALSECCDRF   " + Environment.NewLine;
                    selectTxt += "  	  ,INQOTHEREPCDRF   " + Environment.NewLine;
                    selectTxt += "  	  ,INQOTHERSECCDRF    " + Environment.NewLine;
                    selectTxt += "  	  ,INQUIRYNUMBERRF  " + Environment.NewLine;
                    selectTxt += "  	  ,UPDATEDATERF  " + Environment.NewLine;
                    selectTxt += "  	  ,UPDATETIMERF  " + Environment.NewLine;
                    selectTxt += "  	 FROM SCMACODRDATARF WITH (READUNCOMMITTED) " + Environment.NewLine;
                    selectTxt += "       WHERE" + Environment.NewLine;
                    selectTxt += "             ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                    // 2011/02/18 >>>
                    //selectTxt += "         AND ANSWERDIVCDRF = 99   " + Environment.NewLine;
                    selectTxt += "         AND CANCELDIVRF = 1   " + Environment.NewLine;
                    // 2011/02/18 <<<
                    selectTxt += "    ) AS SCM2   " + Environment.NewLine;
                    selectTxt += "    ON   " + Environment.NewLine;
                    selectTxt += "        SCM2.ENTERPRISECODERF = SCM.ENTERPRISECODERF   " + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQORIGINALEPCDRF = SCM.INQORIGINALEPCDRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQORIGINALSECCDRF = SCM.INQORIGINALSECCDRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQOTHEREPCDRF = SCM.INQOTHEREPCDRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQOTHERSECCDRF = SCM.INQOTHERSECCDRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQUIRYNUMBERRF = SCM.INQUIRYNUMBERRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.UPDATEDATERF = SCM.UPDATEDATERF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.UPDATETIMERF = SCM.UPDATETIMERF" + Environment.NewLine;
                    selectTxt += "  WHERE  " + Environment.NewLine;
                    selectTxt += "        SCM.ENTERPRISECODERF = @ENTERPRISECODE  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQORIGINALEPCDRF = @INQORIGINALEPCD  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQORIGINALSECCDRF = @INQORIGINALSECCD  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQUIRYNUMBERRF = @INQUIRYNUMBER  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQOTHEREPCDRF = @INQOTHEREPCD  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQOTHERSECCDRF = @INQOTHERSECCD  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQORDDIVCDRF = @INQORDDIVCD  " + Environment.NewLine;
                }
                // -- UPD 2010/04/13--------------------------------<<<

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(parascmInquiryResultWork.EnterpriseCode);

                SqlParameter paraInqOriginalEpCd = sqlCommand.Parameters.Add("@INQORIGINALEPCD", SqlDbType.NChar);
                paraInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(parascmInquiryResultWork.InqOriginalEpCd);

                SqlParameter paraInqOriginalSecCd = sqlCommand.Parameters.Add("@INQORIGINALSECCD", SqlDbType.NChar);
                paraInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(parascmInquiryResultWork.InqOriginalSecCd);

                SqlParameter paraInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
                paraInqOtherEpCd.Value = SqlDataMediator.SqlSetString(parascmInquiryResultWork.InqOtherEpCd);

                SqlParameter paraInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
                paraInqOtherSecCd.Value = SqlDataMediator.SqlSetString(parascmInquiryResultWork.InqOtherSecCd);

                SqlParameter paraInquiryNumber = sqlCommand.Parameters.Add("@INQUIRYNUMBER", SqlDbType.BigInt);
                paraInquiryNumber.Value = SqlDataMediator.SqlSetInt64(parascmInquiryResultWork.InquiryNumber);

                SqlParameter paraInqOrdDivCd = sqlCommand.Parameters.Add("@INQORDDIVCD", SqlDbType.Int);
                paraInqOrdDivCd.Value = SqlDataMediator.SqlSetInt32(parascmInquiryResultWork.InqOrdDivCd);

                //selectTxt += " 	GROUP BY   " + Environment.NewLine;
                //selectTxt += " 	    ENTERPRISECODERF  " + Environment.NewLine;
                //selectTxt += " 	   ,INQORIGINALEPCDRF  " + Environment.NewLine;
                //selectTxt += " 	   ,INQORIGINALSECCDRF  " + Environment.NewLine;
                //selectTxt += " 	   ,INQUIRYNUMBERRF  " + Environment.NewLine;
                //selectTxt += " 	   ,INQROWNUMBERRF  " + Environment.NewLine;
                //selectTxt += " 	   ,INQROWNUMDERIVEDNORF  " + Environment.NewLine;
                //selectTxt += "     ,INQORGDTLDISCGUIDRF   " + Environment.NewLine;
                //selectTxt += "     ,INQOTHDTLDISCGUIDRF   " + Environment.NewLine;
                //selectTxt += "     ,GOODSDIVCDRF   " + Environment.NewLine;
                //selectTxt += "     ,DELIVEREDGOODSDIVRF   " + Environment.NewLine;
                //selectTxt += "     ,HANDLEDIVCODERF   " + Environment.NewLine;
                //selectTxt += "     ,GOODSSHAPERF   " + Environment.NewLine;
                //selectTxt += "     ,DELIVRDGDSCONFCDRF   " + Environment.NewLine;
                //selectTxt += "     ,DELIGDSCMPLTDUEDATERF   " + Environment.NewLine;
                //selectTxt += "     ,BLGOODSCODERF   " + Environment.NewLine;
                //selectTxt += "     ,BLGOODSDRCODERF   " + Environment.NewLine;
                //selectTxt += "	   ,INQGOODSNAMERF " + Environment.NewLine;
                //selectTxt += "	   ,ANSGOODSNAMERF " + Environment.NewLine;
                //selectTxt += "     ,SALESORDERCOUNTRF   " + Environment.NewLine;
                //selectTxt += "     ,DELIVEREDGOODSCOUNTRF   " + Environment.NewLine;
                //selectTxt += "     ,GOODSNORF   " + Environment.NewLine;
                //selectTxt += "     ,GOODSMAKERCDRF   " + Environment.NewLine;
                //selectTxt += "     ,PUREGOODSMAKERCDRF   " + Environment.NewLine;
                //selectTxt += "	   ,INQPUREGOODSNORF " + Environment.NewLine;
                //selectTxt += "	   ,ANSPUREGOODSNORF " + Environment.NewLine;
                //selectTxt += "     ,LISTPRICERF   " + Environment.NewLine;
                //selectTxt += "     ,UNITPRICERF   " + Environment.NewLine;
                //selectTxt += "     ,GOODSADDINFORF   " + Environment.NewLine;
                //selectTxt += "     ,ROUGHRROFITRF   " + Environment.NewLine;
                //selectTxt += "     ,ROUGHRATERF   " + Environment.NewLine;
                //selectTxt += "     ,ANSWERLIMITDATERF   " + Environment.NewLine;
                //selectTxt += "     ,COMMENTDTLRF   " + Environment.NewLine;
                //selectTxt += "     ,SHELFNORF   " + Environment.NewLine;
                //selectTxt += "     ,ADDITIONALDIVCDRF   " + Environment.NewLine;
                //selectTxt += "     ,CORRECTDIVCDRF   " + Environment.NewLine;
                //selectTxt += "     ,INQORDDIVCDRF  " + Environment.NewLine;
                //selectTxt += "     ,ANSWERDELIVERYDATERF  " + Environment.NewLine;

                sqlCommand.CommandText = selectTxt;

                #endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    // 明細-問合せ
                    SCMInquiryDtlInqResultWork wkSCMInquiryDtlResultInqWork = new SCMInquiryDtlInqResultWork();

                    wkSCMInquiryDtlResultInqWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALEPCDRF")).Trim();  // 問合せ元企業コード//@@@@20230303
                    wkSCMInquiryDtlResultInqWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALSECCDRF"));  // 問合せ元拠点コード
                    wkSCMInquiryDtlResultInqWork.InquiryNumber = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INQUIRYNUMBERRF"));  // 問合せ番号
                    wkSCMInquiryDtlResultInqWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));  // 更新年月日
                    wkSCMInquiryDtlResultInqWork.UpdateTime = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATETIMERF"));  // 更新時間
                    wkSCMInquiryDtlResultInqWork.InqRowNumber = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQROWNUMBERRF"));  // 問合せ行番号
                    wkSCMInquiryDtlResultInqWork.InqRowNumDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQROWNUMDERIVEDNORF"));  // 問合せ行番号枝番
                    wkSCMInquiryDtlResultInqWork.InqOrgDtlDiscGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("INQORGDTLDISCGUIDRF"));  // 問合せ元明細識別GUID
                    wkSCMInquiryDtlResultInqWork.InqOthDtlDiscGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("INQOTHDTLDISCGUIDRF"));  // 問合せ先明細識別GUID
                    wkSCMInquiryDtlResultInqWork.GoodsDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSDIVCDRF"));  // 商品種別
                    wkSCMInquiryDtlResultInqWork.DeliveredGoodsDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVRF"));  // 納品区分
                    wkSCMInquiryDtlResultInqWork.HandleDivCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("HANDLEDIVCODERF"));  // 取扱区分
                    wkSCMInquiryDtlResultInqWork.GoodsShape = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSSHAPERF"));  // 商品形態
                    wkSCMInquiryDtlResultInqWork.DelivrdGdsConfCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIVRDGDSCONFCDRF"));  // 納品確認区分
                    wkSCMInquiryDtlResultInqWork.DeliGdsCmpltDueDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DELIGDSCMPLTDUEDATERF"));  // 納品完了予定日
                    wkSCMInquiryDtlResultInqWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));  // BL商品コード
                    wkSCMInquiryDtlResultInqWork.BLGoodsDrCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSDRCODERF"));  // BL商品コード枝番
                    wkSCMInquiryDtlResultInqWork.InqGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQPUREGOODSNORF"));  // 問発商品名称
                    wkSCMInquiryDtlResultInqWork.AnsGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSPUREGOODSNORF"));  // 回答商品名称
                    wkSCMInquiryDtlResultInqWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF"));  // 発注数
                    wkSCMInquiryDtlResultInqWork.DeliveredGoodsCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("DELIVEREDGOODSCOUNTRF"));  // 納品数
                    wkSCMInquiryDtlResultInqWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));  // 商品番号
                    wkSCMInquiryDtlResultInqWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));  // 商品メーカーコード
                    wkSCMInquiryDtlResultInqWork.PureGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PUREGOODSMAKERCDRF"));  // 純正商品メーカーコード
                    wkSCMInquiryDtlResultInqWork.InqPureGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQPUREGOODSNORF")); // 問発純正商品番号
                    wkSCMInquiryDtlResultInqWork.AnsPureGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSPUREGOODSNORF")); // 回答純正商品番号
                    wkSCMInquiryDtlResultInqWork.ListPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LISTPRICERF"));  // 定価
                    wkSCMInquiryDtlResultInqWork.UnitPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("UNITPRICERF"));  // 単価
                    wkSCMInquiryDtlResultInqWork.GoodsAddInfo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSADDINFORF"));  // 商品補足情報
                    wkSCMInquiryDtlResultInqWork.RoughRrofit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ROUGHRROFITRF"));  // 粗利額
                    wkSCMInquiryDtlResultInqWork.RoughRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ROUGHRATERF"));  // 粗利率
                    wkSCMInquiryDtlResultInqWork.AnswerLimitDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERLIMITDATERF"));  // 回答期限
                    wkSCMInquiryDtlResultInqWork.CommentDtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMMENTDTLRF"));  // 備考(明細)
                    wkSCMInquiryDtlResultInqWork.ShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHELFNORF"));  // 棚番
                    wkSCMInquiryDtlResultInqWork.AdditionalDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDITIONALDIVCDRF"));  // 追加区分
                    wkSCMInquiryDtlResultInqWork.CorrectDivCD = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CORRECTDIVCDRF"));  // 訂正区分   
                    wkSCMInquiryDtlResultInqWork.InqOrdDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQORDDIVCDRF"));  // 問合せ・発注種別  
                    wkSCMInquiryDtlResultInqWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));  // 企業コード
                    wkSCMInquiryDtlResultInqWork.AnswerDelivDate = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERDELIVERYDATERF"));  // 回答納期
                    // 2009.08.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    wkSCMInquiryDtlResultInqWork.RecyclePrtKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECYCLEPRTKINDCODERF"));  // リサイクル部品種別
                    wkSCMInquiryDtlResultInqWork.RecyclePrtKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECYCLEPRTKINDNAMERF"));  // リサイクル部品種別名称
                    // 2009.08.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                    // -- ADD 2010/06/17 ----------------------------------------->>>
                    wkSCMInquiryDtlResultInqWork.CancelCndtinDiv = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("CANCELCNDTINDIVRF"));  // キャンセル状態区分
                    wkSCMInquiryDtlResultInqWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));  // 受注ステータス
                    wkSCMInquiryDtlResultInqWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));  // 売上伝票番号
                    wkSCMInquiryDtlResultInqWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));  // 売上行番号
                    // -- ADD 2010/06/17 -----------------------------------------<<<

                    //--- ADD 2011/05/26 ------------------------------------->>>
                    wkSCMInquiryDtlResultInqWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));  // 倉庫コード
                    wkSCMInquiryDtlResultInqWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));  // 倉庫名称
                    wkSCMInquiryDtlResultInqWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));  // 倉庫棚番
                    //--- ADD 2011/05/26 -------------------------------------<<<

                    // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                    wkSCMInquiryDtlResultInqWork.PmMainMngWarehouseCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PMMAINMNGWAREHOUSECDRF"));  // PM主管倉庫コード
                    wkSCMInquiryDtlResultInqWork.PmMainMngWarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PMMAINMNGWAREHOUSENAMERF"));  // PM主管倉庫名称
                    wkSCMInquiryDtlResultInqWork.PmMainMngShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PMMAINMNGSHELFNORF"));  // PM主管棚番
                    wkSCMInquiryDtlResultInqWork.PmMainMngPrsntCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PMMAINMNGPRSNTCOUNTRF"));  // PM主管現在個数
                    // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                    // ADD 2015/02/20 吉岡 SCM高速化 C向け種別特記対応   -------------->>>>>>>>>>>>>>>>>>>>
                    wkSCMInquiryDtlResultInqWork.GoodsSpecialNtForFac = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSPECIALNTFORFACRF"));  // 商品規格・特記事項(工場向け)
                    wkSCMInquiryDtlResultInqWork.GoodsSpecialNtForCOw = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSPECIALNTFORCOWRF"));  // 商品規格・特記事項(カーオーナー向け)
                    wkSCMInquiryDtlResultInqWork.PrmSetDtlName2ForFac = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME2FORFACRF"));  // 優良設定詳細名称２(工場向け)
                    wkSCMInquiryDtlResultInqWork.PrmSetDtlName2ForCOw = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME2FORCOWRF"));  // 優良設定詳細名称２(カーオーナー向け)
                    // ADD 2015/02/20 吉岡 SCM高速化 C向け種別特記対応   --------------<<<<<<<<<<<<<<<<<<<<

                    DetailList.Add(wkSCMInquiryDtlResultInqWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                // 最後の伝票情報追加
                if (DetailList.Count != 0)
                {
                    retList.Add(DetailList);
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMInquiryDB.SearchDetailInqProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// 回答明細抽出
        /// </summary>
        /// <param name="retList">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="parascmInquiryResultWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        private int SearchDetailAnsProc(ref CustomSerializeArrayList retList, ref SqlConnection sqlConnection, SCMInquiryResultWork parascmInquiryResultWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            // 伝票リスト
            CustomSerializeArrayList DetailList = new CustomSerializeArrayList();

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                #region Select文作成
                // -- UPD 2010/04/13-------------------------------->>>
                #region[削除]
                //selectTxt += "  SELECT " + Environment.NewLine;
                //selectTxt += "      SCM.ENTERPRISECODERF  " + Environment.NewLine;
                //selectTxt += " 	   ,SCM.INQORIGINALEPCDRF  " + Environment.NewLine;
                //selectTxt += " 	   ,SCM.INQORIGINALSECCDRF  " + Environment.NewLine;
                //selectTxt += " 	   ,SCM.INQUIRYNUMBERRF  " + Environment.NewLine;
                //selectTxt += " 	   ,SCM.UPDATEDATERF  " + Environment.NewLine;
                //selectTxt += " 	   ,SCM.UPDATETIMERF  " + Environment.NewLine;
                //selectTxt += " 	   ,SCM.INQROWNUMBERRF  " + Environment.NewLine;
                //selectTxt += " 	   ,SCM.INQROWNUMDERIVEDNORF  " + Environment.NewLine;
                //selectTxt += " 	   ,SCM.ACPTANODRSTATUSRF  " + Environment.NewLine;
                //selectTxt += "     ,SCM.SALESSLIPNUMRF  " + Environment.NewLine;
                //selectTxt += "     ,SCM.INQORGDTLDISCGUIDRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.INQOTHDTLDISCGUIDRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.GOODSDIVCDRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.DELIVEREDGOODSDIVRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.HANDLEDIVCODERF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.GOODSSHAPERF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.DELIVRDGDSCONFCDRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.DELIGDSCMPLTDUEDATERF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.BLGOODSCODERF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.BLGOODSDRCODERF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.INQGOODSNAMERF " + Environment.NewLine;
                //selectTxt += "	   ,SCM.ANSGOODSNAMERF " + Environment.NewLine;
                //selectTxt += "     ,SCM.SALESORDERCOUNTRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.DELIVEREDGOODSCOUNTRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.GOODSNORF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.GOODSMAKERCDRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.PUREGOODSMAKERCDRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.INQPUREGOODSNORF " + Environment.NewLine;
                //selectTxt += "	   ,SCM.ANSPUREGOODSNORF " + Environment.NewLine;
                //selectTxt += "     ,SCM.LISTPRICERF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.UNITPRICERF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.GOODSADDINFORF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.ROUGHRROFITRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.ROUGHRATERF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.ANSWERLIMITDATERF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.COMMENTDTLRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.SHELFNORF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.ADDITIONALDIVCDRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.CORRECTDIVCDRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.SALESROWNORF  " + Environment.NewLine;
                //selectTxt += "     ,SCM.CAMPAIGNCODERF  " + Environment.NewLine;
                //selectTxt += "     ,SCM.STOCKDIVRF  " + Environment.NewLine;
                //// 2009.08.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //selectTxt += "     ,SCM.RECYCLEPRTKINDCODERF  " + Environment.NewLine;
                //selectTxt += "     ,SCM.RECYCLEPRTKINDNAMERF  " + Environment.NewLine;
                //// 2009.08.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                //selectTxt += "   FROM SCMACODRDTLASRF AS SCM" + Environment.NewLine;
                //selectTxt += "    INNER JOIN   " + Environment.NewLine;
                //selectTxt += "    (   " + Environment.NewLine;
                //selectTxt += "  	 SELECT    " + Environment.NewLine;
                //// -- UPD 2010/03/11 -------------------------------------------------->>>
                ////selectTxt += "  	   MAX(UPDATETIMERF) AS UPDATETIMERF   " + Environment.NewLine;
                ////selectTxt += "  	  ,MAX(UPDATEDATERF) AS UPDATEDATERF   " + Environment.NewLine;
                //selectTxt += "  	   MAX(cast(UPDATEDATERF as nvarchar) + cast(UPDATETIMERF as nvarchar)) AS UPDATEDATETIMERF   " + Environment.NewLine;
                //// -- UPD 2010/03/11 --------------------------------------------------<<<
                //selectTxt += "  	  ,ENTERPRISECODERF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQORIGINALEPCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQORIGINALSECCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQOTHEREPCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQOTHERSECCDRF    " + Environment.NewLine;
                //selectTxt += "  	  ,INQUIRYNUMBERRF  " + Environment.NewLine;
                //selectTxt += "  	  ,INQROWNUMBERRF	   " + Environment.NewLine;
                //selectTxt += "  	  ,INQROWNUMDERIVEDNORF  " + Environment.NewLine;
                //selectTxt += "  	  ,ACPTANODRSTATUSRF  " + Environment.NewLine;
                //selectTxt += "  	  ,SALESSLIPNUMRF  " + Environment.NewLine;
                //selectTxt += "  	  ,SALESROWNORF  " + Environment.NewLine;
                //selectTxt += "  	 FROM SCMACODRDTLASRF    " + Environment.NewLine;
                //selectTxt += "  	 GROUP BY    " + Environment.NewLine;
                //selectTxt += "  	   ENTERPRISECODERF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQORIGINALEPCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQORIGINALSECCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQOTHEREPCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQOTHERSECCDRF    " + Environment.NewLine;
                //selectTxt += "  	  ,INQUIRYNUMBERRF  " + Environment.NewLine;
                //selectTxt += "  	  ,INQROWNUMBERRF	   " + Environment.NewLine;
                //selectTxt += "  	  ,INQROWNUMDERIVEDNORF  " + Environment.NewLine;
                //selectTxt += "  	  ,ACPTANODRSTATUSRF  " + Environment.NewLine;
                //selectTxt += "  	  ,SALESSLIPNUMRF  " + Environment.NewLine;
                //selectTxt += "  	  ,SALESROWNORF  " + Environment.NewLine;
                //selectTxt += "    ) AS SCM2   " + Environment.NewLine;
                //selectTxt += "    ON   " + Environment.NewLine;
                //selectTxt += "        SCM2.ENTERPRISECODERF = SCM.ENTERPRISECODERF   " + Environment.NewLine;
                //selectTxt += "    AND SCM2.INQORIGINALEPCDRF = SCM.INQORIGINALEPCDRF" + Environment.NewLine;
                //selectTxt += "    AND SCM2.INQORIGINALSECCDRF = SCM.INQORIGINALSECCDRF" + Environment.NewLine;
                //selectTxt += "    AND SCM2.INQOTHEREPCDRF = SCM.INQOTHEREPCDRF" + Environment.NewLine;
                //selectTxt += "    AND SCM2.INQOTHERSECCDRF = SCM.INQOTHERSECCDRF" + Environment.NewLine;
                //selectTxt += "    AND SCM2.INQUIRYNUMBERRF = SCM.INQUIRYNUMBERRF" + Environment.NewLine;
                //// -- UPD 2010/03/11 -------------------------------------------------->>>
                ////selectTxt += "    AND SCM2.UPDATEDATERF = SCM.UPDATEDATERF" + Environment.NewLine;
                ////selectTxt += "    AND SCM2.UPDATETIMERF = SCM.UPDATETIMERF" + Environment.NewLine;
                //selectTxt += "    AND SCM2.UPDATEDATETIMERF = (cast(SCM.UPDATEDATERF as nvarchar) + cast(SCM.UPDATETIMERF as nvarchar))   " + Environment.NewLine;
                //// -- UPD 2010/03/11 --------------------------------------------------<<<
                //selectTxt += "    AND SCM2.INQROWNUMBERRF = SCM.INQROWNUMBERRF" + Environment.NewLine;
                //selectTxt += "    AND SCM2.INQROWNUMDERIVEDNORF = SCM.INQROWNUMDERIVEDNORF" + Environment.NewLine;
                //selectTxt += "    AND SCM2.ACPTANODRSTATUSRF = SCM.ACPTANODRSTATUSRF" + Environment.NewLine;
                //selectTxt += "    AND SCM2.SALESSLIPNUMRF = SCM.SALESSLIPNUMRF" + Environment.NewLine;
                //selectTxt += "    AND SCM2.SALESROWNORF = SCM.SALESROWNORF" + Environment.NewLine;

                //selectTxt += "  WHERE  " + Environment.NewLine;
                //selectTxt += "        SCM.ENTERPRISECODERF = @ENTERPRISECODE  " + Environment.NewLine;
                //selectTxt += "    AND SCM.INQORIGINALEPCDRF = @INQORIGINALEPCD  " + Environment.NewLine;
                //selectTxt += "    AND SCM.INQORIGINALSECCDRF = @INQORIGINALSECCD  " + Environment.NewLine;
                //selectTxt += "    AND SCM.INQUIRYNUMBERRF = @INQUIRYNUMBER  " + Environment.NewLine;
                //selectTxt += "    AND SCM.INQOTHEREPCDRF = @INQOTHEREPCD  " + Environment.NewLine;
                //selectTxt += "    AND SCM.INQOTHERSECCDRF = @INQOTHERSECCD  " + Environment.NewLine;
                //selectTxt += "    AND SCM.INQORDDIVCDRF = @INQORDDIVCD  " + Environment.NewLine;
                //selectTxt += "    AND SCM.ACPTANODRSTATUSRF = @ACPTANODRSTATUS " + Environment.NewLine;
                //selectTxt += "    AND SCM.SALESSLIPNUMRF = @SALESSLIPNUM " + Environment.NewLine;
                #endregion

                if (parascmInquiryResultWork.AnswerDivCd != 99)
                {
                    //キャンセル以外の抽出クエリ
                    selectTxt += "  SELECT " + Environment.NewLine;
                    selectTxt += "      SCM.ENTERPRISECODERF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQORIGINALEPCDRF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQORIGINALSECCDRF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQUIRYNUMBERRF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.UPDATEDATERF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.UPDATETIMERF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQROWNUMBERRF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQROWNUMDERIVEDNORF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.ACPTANODRSTATUSRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.SALESSLIPNUMRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.INQORGDTLDISCGUIDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.INQOTHDTLDISCGUIDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSDIVCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.DELIVEREDGOODSDIVRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.HANDLEDIVCODERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSSHAPERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.DELIVRDGDSCONFCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.DELIGDSCMPLTDUEDATERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.BLGOODSCODERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.BLGOODSDRCODERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.INQGOODSNAMERF " + Environment.NewLine;
                    selectTxt += "	   ,SCM.ANSGOODSNAMERF " + Environment.NewLine;
                    selectTxt += "     ,SCM.SALESORDERCOUNTRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.DELIVEREDGOODSCOUNTRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSNORF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSMAKERCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.PUREGOODSMAKERCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.INQPUREGOODSNORF " + Environment.NewLine;
                    selectTxt += "	   ,SCM.ANSPUREGOODSNORF " + Environment.NewLine;
                    selectTxt += "     ,SCM.LISTPRICERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.UNITPRICERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSADDINFORF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.ROUGHRROFITRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.ROUGHRATERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.ANSWERLIMITDATERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.COMMENTDTLRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.SHELFNORF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.ADDITIONALDIVCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.CORRECTDIVCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.SALESROWNORF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.CAMPAIGNCODERF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.STOCKDIVRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.RECYCLEPRTKINDCODERF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.RECYCLEPRTKINDNAMERF  " + Environment.NewLine;
                    // 2010/05/27 Add >>>
                    selectTxt += "     ,SCM.INQORDDIVCDRF  " + Environment.NewLine;
                    // 2010/05/27 Add <<<
                    // -- ADD 2010/06/17 -------------------------->>>
                    selectTxt += "     ,SCM.CANCELCNDTINDIVRF" + Environment.NewLine;
                    // -- ADD 2010/06/17 --------------------------<<<
                    //--- ADD 2011/05/26 -------------------------->>>
                    selectTxt += "     ,SCM.WAREHOUSECODERF" + Environment.NewLine;
                    selectTxt += "     ,SCM.WAREHOUSENAMERF" + Environment.NewLine;
                    selectTxt += "     ,SCM.WAREHOUSESHELFNORF" + Environment.NewLine;
                    //--- ADD 2011/05/26 -------------------------->>>
                    // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                    selectTxt += "     ,SCM.PMMAINMNGWAREHOUSECDRF" + Environment.NewLine;
                    selectTxt += "     ,SCM.PMMAINMNGWAREHOUSENAMERF" + Environment.NewLine;
                    selectTxt += "     ,SCM.PMMAINMNGSHELFNORF" + Environment.NewLine;
                    selectTxt += "     ,SCM.PMMAINMNGPRSNTCOUNTRF" + Environment.NewLine;
                    // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                    // ADD 2015/02/20 吉岡 SCM高速化 C向け種別特記対応   -------------->>>>>>>>>>>>>>>>>>>>
                    selectTxt += "     ,SCM.GOODSSPECIALNTFORFACRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSSPECIALNTFORCOWRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.PRMSETDTLNAME2FORFACRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.PRMSETDTLNAME2FORCOWRF  " + Environment.NewLine;
                    // ADD 2015/02/20 吉岡 SCM高速化 C向け種別特記対応   --------------<<<<<<<<<<<<<<<<<<<<
                    selectTxt += "   FROM SCMACODRDTLASRF AS SCM WITH (READUNCOMMITTED)" + Environment.NewLine;
                    selectTxt += "    INNER JOIN   " + Environment.NewLine;
                    selectTxt += "    (   " + Environment.NewLine;
                    selectTxt += "  	 SELECT    " + Environment.NewLine;
                    // -- UPD 2010/06/17 --------------------------------------->>>
                    //selectTxt += "  	   MAX(cast(SCMAS.UPDATEDATERF as nvarchar) + cast(SCMAS.UPDATETIMERF as nvarchar)) AS UPDATEDATETIMERF   " + Environment.NewLine;
                    selectTxt += "  	   MAX(cast(SCMAS.UPDATEDATERF as nvarchar) + RIGHT('000000000' + cast(SCMAS.UPDATETIMERF as nvarchar),9)) AS UPDATEDATETIMERF   " + Environment.NewLine;
                    // -- UPD 2010/06/17 ---------------------------------------<<<
                    selectTxt += "  	  ,SCMAS.ENTERPRISECODERF   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.INQORIGINALEPCDRF   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.INQORIGINALSECCDRF   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.INQOTHEREPCDRF   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.INQOTHERSECCDRF    " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.INQUIRYNUMBERRF  " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.INQROWNUMBERRF	   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.INQROWNUMDERIVEDNORF  " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.ACPTANODRSTATUSRF  " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.SALESSLIPNUMRF  " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.SALESROWNORF  " + Environment.NewLine;
                    selectTxt += "  	 FROM SCMACODRDTLASRF AS SCMAS WITH (READUNCOMMITTED)   " + Environment.NewLine;
                    selectTxt += "       INNER JOIN   " + Environment.NewLine;
                    selectTxt += "       (   " + Environment.NewLine;
                    selectTxt += "         SELECT    " + Environment.NewLine;
                    selectTxt += "  	     ENTERPRISECODERF   " + Environment.NewLine;
                    selectTxt += "          ,INQORIGINALEPCDRF   " + Environment.NewLine;
                    selectTxt += "          ,INQORIGINALSECCDRF   " + Environment.NewLine;
                    selectTxt += "          ,INQOTHEREPCDRF   " + Environment.NewLine;
                    selectTxt += "          ,INQOTHERSECCDRF    " + Environment.NewLine;
                    selectTxt += "          ,INQUIRYNUMBERRF  " + Environment.NewLine;
                    selectTxt += "          ,UPDATEDATERF  " + Environment.NewLine;
                    selectTxt += "          ,UPDATETIMERF  " + Environment.NewLine;
                    selectTxt += "  	   FROM SCMACODRDATARF WITH (READUNCOMMITTED) " + Environment.NewLine;
                    selectTxt += "         WHERE" + Environment.NewLine;
                    selectTxt += "               ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                    // 2011/01/24 Add >>>
                    selectTxt += "           AND INQORIGINALEPCDRF = @INQORIGINALEPCD  " + Environment.NewLine;
                    selectTxt += "           AND INQORIGINALSECCDRF = @INQORIGINALSECCD  " + Environment.NewLine;
                    selectTxt += "           AND INQUIRYNUMBERRF = @INQUIRYNUMBER  " + Environment.NewLine;
                    selectTxt += "           AND INQOTHEREPCDRF = @INQOTHEREPCD  " + Environment.NewLine;
                    selectTxt += "           AND INQOTHERSECCDRF = @INQOTHERSECCD  " + Environment.NewLine;
                    selectTxt += "           AND INQORDDIVCDRF = @INQORDDIVCD  " + Environment.NewLine;
                    // 2011/01/24 Add <<<        
                    // 2011/02/18 >>>
                    //selectTxt += "           AND ANSWERDIVCDRF <> 99   " + Environment.NewLine;
                    selectTxt += "           AND CANCELDIVRF <> 1   " + Environment.NewLine;
                    // 2011/02/18 <<<
                    selectTxt += "       ) AS SCMODR   " + Environment.NewLine;
                    selectTxt += "       ON   " + Environment.NewLine;
                    selectTxt += "           SCMODR.ENTERPRISECODERF = SCMAS.ENTERPRISECODERF   " + Environment.NewLine;
                    selectTxt += "       AND SCMODR.INQORIGINALEPCDRF = SCMAS.INQORIGINALEPCDRF" + Environment.NewLine;
                    selectTxt += "       AND SCMODR.INQORIGINALSECCDRF = SCMAS.INQORIGINALSECCDRF" + Environment.NewLine;
                    selectTxt += "       AND SCMODR.INQOTHEREPCDRF = SCMAS.INQOTHEREPCDRF" + Environment.NewLine;
                    selectTxt += "       AND SCMODR.INQOTHERSECCDRF = SCMAS.INQOTHERSECCDRF" + Environment.NewLine;
                    selectTxt += "       AND SCMODR.INQUIRYNUMBERRF = SCMAS.INQUIRYNUMBERRF" + Environment.NewLine;
                    selectTxt += "       AND SCMODR.UPDATEDATERF = SCMAS.UPDATEDATERF" + Environment.NewLine;
                    selectTxt += "       AND SCMODR.UPDATETIMERF = SCMAS.UPDATETIMERF" + Environment.NewLine;
                    selectTxt += "  	 GROUP BY    " + Environment.NewLine;
                    selectTxt += "  	   SCMAS.ENTERPRISECODERF   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.INQORIGINALEPCDRF   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.INQORIGINALSECCDRF   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.INQOTHEREPCDRF   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.INQOTHERSECCDRF    " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.INQUIRYNUMBERRF  " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.INQROWNUMBERRF	   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.INQROWNUMDERIVEDNORF  " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.ACPTANODRSTATUSRF  " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.SALESSLIPNUMRF  " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.SALESROWNORF  " + Environment.NewLine;
                    selectTxt += "    ) AS SCM2   " + Environment.NewLine;
                    selectTxt += "    ON   " + Environment.NewLine;
                    selectTxt += "        SCM2.ENTERPRISECODERF = SCM.ENTERPRISECODERF   " + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQORIGINALEPCDRF = SCM.INQORIGINALEPCDRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQORIGINALSECCDRF = SCM.INQORIGINALSECCDRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQOTHEREPCDRF = SCM.INQOTHEREPCDRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQOTHERSECCDRF = SCM.INQOTHERSECCDRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQUIRYNUMBERRF = SCM.INQUIRYNUMBERRF" + Environment.NewLine;
                    // -- UPD 2010/06/17 ------------------------------------>>>
                    //selectTxt += "    AND SCM2.UPDATEDATETIMERF = (cast(SCM.UPDATEDATERF as nvarchar) + cast(SCM.UPDATETIMERF as nvarchar))   " + Environment.NewLine;
                    selectTxt += "    AND SCM2.UPDATEDATETIMERF = (cast(SCM.UPDATEDATERF as nvarchar) + RIGHT('000000000' + cast(SCM.UPDATETIMERF as nvarchar),9))   " + Environment.NewLine;
                    // -- UPD 2010/06/17 ------------------------------------<<<
                    selectTxt += "    AND SCM2.INQROWNUMBERRF = SCM.INQROWNUMBERRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQROWNUMDERIVEDNORF = SCM.INQROWNUMDERIVEDNORF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.ACPTANODRSTATUSRF = SCM.ACPTANODRSTATUSRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.SALESSLIPNUMRF = SCM.SALESSLIPNUMRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.SALESROWNORF = SCM.SALESROWNORF" + Environment.NewLine;
                    selectTxt += "  WHERE  " + Environment.NewLine;
                    selectTxt += "        SCM.ENTERPRISECODERF = @ENTERPRISECODE  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQORIGINALEPCDRF = @INQORIGINALEPCD  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQORIGINALSECCDRF = @INQORIGINALSECCD  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQUIRYNUMBERRF = @INQUIRYNUMBER  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQOTHEREPCDRF = @INQOTHEREPCD  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQOTHERSECCDRF = @INQOTHERSECCD  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQORDDIVCDRF = @INQORDDIVCD  " + Environment.NewLine;
                }
                else
                {
                    //キャンセル分の抽出クエリ
                    selectTxt += "  SELECT " + Environment.NewLine;
                    selectTxt += "      SCM.ENTERPRISECODERF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQORIGINALEPCDRF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQORIGINALSECCDRF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQUIRYNUMBERRF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.UPDATEDATERF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.UPDATETIMERF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQROWNUMBERRF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQROWNUMDERIVEDNORF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.ACPTANODRSTATUSRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.SALESSLIPNUMRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.INQORGDTLDISCGUIDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.INQOTHDTLDISCGUIDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSDIVCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.DELIVEREDGOODSDIVRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.HANDLEDIVCODERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSSHAPERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.DELIVRDGDSCONFCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.DELIGDSCMPLTDUEDATERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.BLGOODSCODERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.BLGOODSDRCODERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.INQGOODSNAMERF " + Environment.NewLine;
                    selectTxt += "	   ,SCM.ANSGOODSNAMERF " + Environment.NewLine;
                    selectTxt += "     ,SCM.SALESORDERCOUNTRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.DELIVEREDGOODSCOUNTRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSNORF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSMAKERCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.PUREGOODSMAKERCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.INQPUREGOODSNORF " + Environment.NewLine;
                    selectTxt += "	   ,SCM.ANSPUREGOODSNORF " + Environment.NewLine;
                    selectTxt += "     ,SCM.LISTPRICERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.UNITPRICERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSADDINFORF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.ROUGHRROFITRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.ROUGHRATERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.ANSWERLIMITDATERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.COMMENTDTLRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.SHELFNORF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.ADDITIONALDIVCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.CORRECTDIVCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.SALESROWNORF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.CAMPAIGNCODERF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.STOCKDIVRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.RECYCLEPRTKINDCODERF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.RECYCLEPRTKINDNAMERF  " + Environment.NewLine;
                    // 2010/05/27 Add >>>
                    selectTxt += "     ,SCM.INQORDDIVCDRF  " + Environment.NewLine;
                    // 2010/05/27 Add <<<
                    // -- ADD 2010/06/17 -------------------------->>>
                    selectTxt += "     ,SCM.CANCELCNDTINDIVRF" + Environment.NewLine;
                    // -- ADD 2010/06/17 --------------------------<<<
                    //--- ADD 2011/05/26 -------------------------->>>
                    selectTxt += "     ,SCM.WAREHOUSECODERF" + Environment.NewLine;
                    selectTxt += "     ,SCM.WAREHOUSENAMERF" + Environment.NewLine;
                    selectTxt += "     ,SCM.WAREHOUSESHELFNORF" + Environment.NewLine;
                    //--- ADD 2011/05/26 -------------------------->>>
                    // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                    selectTxt += "     ,SCM.PMMAINMNGWAREHOUSECDRF" + Environment.NewLine;
                    selectTxt += "     ,SCM.PMMAINMNGWAREHOUSENAMERF" + Environment.NewLine;
                    selectTxt += "     ,SCM.PMMAINMNGSHELFNORF" + Environment.NewLine;
                    selectTxt += "     ,SCM.PMMAINMNGPRSNTCOUNTRF" + Environment.NewLine;
                    // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                    // ADD 2015/02/20 吉岡 SCM高速化 C向け種別特記対応   -------------->>>>>>>>>>>>>>>>>>>>
                    selectTxt += "     ,SCM.GOODSSPECIALNTFORFACRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSSPECIALNTFORCOWRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.PRMSETDTLNAME2FORFACRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.PRMSETDTLNAME2FORCOWRF  " + Environment.NewLine;
                    // ADD 2015/02/20 吉岡 SCM高速化 C向け種別特記対応   --------------<<<<<<<<<<<<<<<<<<<<
                    selectTxt += "   FROM SCMACODRDTLASRF AS SCM WITH (READUNCOMMITTED)" + Environment.NewLine;
                    selectTxt += "   INNER JOIN   " + Environment.NewLine;
                    selectTxt += "    (   " + Environment.NewLine;
                    selectTxt += "  	 SELECT    " + Environment.NewLine;
                    selectTxt += "  	   ENTERPRISECODERF   " + Environment.NewLine;
                    selectTxt += "  	  ,INQORIGINALEPCDRF   " + Environment.NewLine;
                    selectTxt += "  	  ,INQORIGINALSECCDRF   " + Environment.NewLine;
                    selectTxt += "  	  ,INQOTHEREPCDRF   " + Environment.NewLine;
                    selectTxt += "  	  ,INQOTHERSECCDRF    " + Environment.NewLine;
                    selectTxt += "  	  ,INQUIRYNUMBERRF  " + Environment.NewLine;
                    selectTxt += "  	  ,UPDATEDATERF  " + Environment.NewLine;
                    selectTxt += "  	  ,UPDATETIMERF  " + Environment.NewLine;
                    selectTxt += "  	 FROM SCMACODRDATARF WITH (READUNCOMMITTED) " + Environment.NewLine;
                    selectTxt += "       WHERE" + Environment.NewLine;
                    selectTxt += "             ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                    // 2011/02/18 >>>
                    //selectTxt += "         AND ANSWERDIVCDRF = 99   " + Environment.NewLine;
                    selectTxt += "         AND CANCELDIVRF = 1   " + Environment.NewLine;
                    // 2011/02/18 <<<
                    selectTxt += "    ) AS SCM2   " + Environment.NewLine;
                    selectTxt += "    ON   " + Environment.NewLine;
                    selectTxt += "        SCM2.ENTERPRISECODERF = SCM.ENTERPRISECODERF   " + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQORIGINALEPCDRF = SCM.INQORIGINALEPCDRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQORIGINALSECCDRF = SCM.INQORIGINALSECCDRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQOTHEREPCDRF = SCM.INQOTHEREPCDRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQOTHERSECCDRF = SCM.INQOTHERSECCDRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQUIRYNUMBERRF = SCM.INQUIRYNUMBERRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.UPDATEDATERF = SCM.UPDATEDATERF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.UPDATETIMERF = SCM.UPDATETIMERF" + Environment.NewLine;
                    selectTxt += "  WHERE  " + Environment.NewLine;
                    selectTxt += "        SCM.ENTERPRISECODERF = @ENTERPRISECODE  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQORIGINALEPCDRF = @INQORIGINALEPCD  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQORIGINALSECCDRF = @INQORIGINALSECCD  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQUIRYNUMBERRF = @INQUIRYNUMBER  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQOTHEREPCDRF = @INQOTHEREPCD  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQOTHERSECCDRF = @INQOTHERSECCD  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQORDDIVCDRF = @INQORDDIVCD  " + Environment.NewLine;

                }
                // -- UPD 2010/04/13--------------------------------<<<

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(parascmInquiryResultWork.EnterpriseCode);

                SqlParameter paraInqOriginalEpCd = sqlCommand.Parameters.Add("@INQORIGINALEPCD", SqlDbType.NChar);
                paraInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(parascmInquiryResultWork.InqOriginalEpCd);

                SqlParameter paraInqOriginalSecCd = sqlCommand.Parameters.Add("@INQORIGINALSECCD", SqlDbType.NChar);
                paraInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(parascmInquiryResultWork.InqOriginalSecCd);

                SqlParameter paraInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
                paraInqOtherEpCd.Value = SqlDataMediator.SqlSetString(parascmInquiryResultWork.InqOtherEpCd);

                SqlParameter paraInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
                paraInqOtherSecCd.Value = SqlDataMediator.SqlSetString(parascmInquiryResultWork.InqOtherSecCd);

                SqlParameter paraInquiryNumber = sqlCommand.Parameters.Add("@INQUIRYNUMBER", SqlDbType.BigInt);
                paraInquiryNumber.Value = SqlDataMediator.SqlSetInt64(parascmInquiryResultWork.InquiryNumber);

                SqlParameter paraInqOrdDivCd = sqlCommand.Parameters.Add("@INQORDDIVCD", SqlDbType.Int);
                paraInqOrdDivCd.Value = SqlDataMediator.SqlSetInt32(parascmInquiryResultWork.InqOrdDivCd);


                // -- UPD 2010/04/13-------------------------------->>>
                //回答は伝票番号で絞り込みを行わない
                //SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                //paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(parascmInquiryResultWork.AcptAnOdrStatus);

                //SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@SALESSLIPNUM", SqlDbType.NChar);
                //paraSalesSlipNum.Value = parascmInquiryResultWork.SalesSlipNum;
                // -- UPD 2010/04/13--------------------------------<<<

                
                //selectTxt += " 	GROUP BY   " + Environment.NewLine;
                //selectTxt += "      ENTERPRISECODERF  " + Environment.NewLine;
                //selectTxt += " 	   ,INQORIGINALEPCDRF  " + Environment.NewLine;
                //selectTxt += " 	   ,INQORIGINALSECCDRF  " + Environment.NewLine;
                //selectTxt += " 	   ,INQOTHEREPCDRF  " + Environment.NewLine;
                //selectTxt += " 	   ,INQOTHERSECCDRF  " + Environment.NewLine;
                //selectTxt += " 	   ,INQUIRYNUMBERRF  " + Environment.NewLine;
                //selectTxt += " 	   ,INQROWNUMBERRF  " + Environment.NewLine;
                //selectTxt += " 	   ,INQROWNUMDERIVEDNORF  " + Environment.NewLine;
                //selectTxt += " 	   ,ACPTANODRSTATUSRF  " + Environment.NewLine;
                //selectTxt += "     ,SALESSLIPNUMRF  " + Environment.NewLine;
                //selectTxt += "     ,INQORGDTLDISCGUIDRF   " + Environment.NewLine;
                //selectTxt += "     ,INQOTHDTLDISCGUIDRF   " + Environment.NewLine;
                //selectTxt += "     ,GOODSDIVCDRF   " + Environment.NewLine;
                //selectTxt += "     ,DELIVEREDGOODSDIVRF   " + Environment.NewLine;
                //selectTxt += "     ,HANDLEDIVCODERF   " + Environment.NewLine;
                //selectTxt += "     ,GOODSSHAPERF   " + Environment.NewLine;
                //selectTxt += "     ,DELIVRDGDSCONFCDRF   " + Environment.NewLine;
                //selectTxt += "     ,DELIGDSCMPLTDUEDATERF   " + Environment.NewLine;
                //selectTxt += "     ,BLGOODSCODERF   " + Environment.NewLine;
                //selectTxt += "     ,BLGOODSDRCODERF   " + Environment.NewLine;
                //selectTxt += "     ,INQGOODSNAMERF " + Environment.NewLine;
                //selectTxt += "	   ,ANSGOODSNAMERF " + Environment.NewLine;
                //selectTxt += "     ,SALESORDERCOUNTRF   " + Environment.NewLine;
                //selectTxt += "     ,DELIVEREDGOODSCOUNTRF   " + Environment.NewLine;
                //selectTxt += "     ,GOODSNORF   " + Environment.NewLine;
                //selectTxt += "     ,GOODSMAKERCDRF   " + Environment.NewLine;
                //selectTxt += "     ,PUREGOODSMAKERCDRF   " + Environment.NewLine;
                //selectTxt += "     ,INQPUREGOODSNORF " + Environment.NewLine;
                //selectTxt += "	   ,ANSPUREGOODSNORF  " + Environment.NewLine;
                //selectTxt += "     ,LISTPRICERF   " + Environment.NewLine;
                //selectTxt += "     ,UNITPRICERF   " + Environment.NewLine;
                //selectTxt += "     ,GOODSADDINFORF   " + Environment.NewLine;
                //selectTxt += "     ,ROUGHRROFITRF   " + Environment.NewLine;
                //selectTxt += "     ,ROUGHRATERF   " + Environment.NewLine;
                //selectTxt += "     ,ANSWERLIMITDATERF   " + Environment.NewLine;
                //selectTxt += "     ,COMMENTDTLRF   " + Environment.NewLine;
                //selectTxt += "     ,SHELFNORF   " + Environment.NewLine;
                //selectTxt += "     ,ADDITIONALDIVCDRF   " + Environment.NewLine;
                //selectTxt += "     ,CORRECTDIVCDRF   " + Environment.NewLine;
                //selectTxt += "     ,SALESROWNORF  " + Environment.NewLine;
                //selectTxt += "     ,CAMPAIGNCODERF  " + Environment.NewLine;
                //selectTxt += "     ,STOCKDIVRF  " + Environment.NewLine;

                sqlCommand.CommandText = selectTxt;

                #endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    // 明細-回答
                    SCMInquiryDtlAnsResultWork wkSCMInquiryDtlResultAnsWork = new SCMInquiryDtlAnsResultWork();

                    wkSCMInquiryDtlResultAnsWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALEPCDRF")).Trim();  // 問合せ元企業コード//@@@@20230303
                    wkSCMInquiryDtlResultAnsWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALSECCDRF"));  // 問合せ元拠点コード
                    wkSCMInquiryDtlResultAnsWork.InquiryNumber = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INQUIRYNUMBERRF"));  // 問合せ番号
                    wkSCMInquiryDtlResultAnsWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));  // 更新年月日
                    wkSCMInquiryDtlResultAnsWork.UpdateTime = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATETIMERF"));  // 更新時間
                    wkSCMInquiryDtlResultAnsWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));  // 受注ステータス
                    wkSCMInquiryDtlResultAnsWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));  // 売上伝票番号
                    wkSCMInquiryDtlResultAnsWork.InqRowNumber = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQROWNUMBERRF"));  // 問合せ行番号
                    wkSCMInquiryDtlResultAnsWork.InqRowNumDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQROWNUMDERIVEDNORF"));  // 問合せ行番号枝番
                    wkSCMInquiryDtlResultAnsWork.InqOrgDtlDiscGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("INQORGDTLDISCGUIDRF"));  // 問合せ元明細識別GUID
                    wkSCMInquiryDtlResultAnsWork.InqOthDtlDiscGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("INQOTHDTLDISCGUIDRF"));  // 問合せ先明細識別GUID
                    wkSCMInquiryDtlResultAnsWork.GoodsDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSDIVCDRF"));  // 商品種別
                    wkSCMInquiryDtlResultAnsWork.DeliveredGoodsDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVRF"));  // 納品区分
                    wkSCMInquiryDtlResultAnsWork.HandleDivCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("HANDLEDIVCODERF"));  // 取扱区分
                    wkSCMInquiryDtlResultAnsWork.GoodsShape = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSSHAPERF"));  // 商品形態
                    wkSCMInquiryDtlResultAnsWork.DelivrdGdsConfCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIVRDGDSCONFCDRF"));  // 納品確認区分
                    wkSCMInquiryDtlResultAnsWork.DeliGdsCmpltDueDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DELIGDSCMPLTDUEDATERF"));  // 納品完了予定日
                    wkSCMInquiryDtlResultAnsWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));  // BL商品コード
                    wkSCMInquiryDtlResultAnsWork.BLGoodsDrCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSDRCODERF"));  // BL商品コード枝番
                    wkSCMInquiryDtlResultAnsWork.InqGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQGOODSNAMERF")); // 問発商品名称
                    wkSCMInquiryDtlResultAnsWork.AnsGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSGOODSNAMERF")); // 回答商品名称
                    wkSCMInquiryDtlResultAnsWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF"));  // 発注数
                    wkSCMInquiryDtlResultAnsWork.DeliveredGoodsCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("DELIVEREDGOODSCOUNTRF"));  // 納品数
                    wkSCMInquiryDtlResultAnsWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));  // 商品番号
                    wkSCMInquiryDtlResultAnsWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));  // 商品メーカーコード
                    wkSCMInquiryDtlResultAnsWork.PureGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PUREGOODSMAKERCDRF"));  // 純正商品メーカーコード
                    wkSCMInquiryDtlResultAnsWork.InqPureGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQPUREGOODSNORF")); // 問発純正商品番号
                    wkSCMInquiryDtlResultAnsWork.AnsPureGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSPUREGOODSNORF")); // 回答純正商品番号
                    wkSCMInquiryDtlResultAnsWork.ListPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LISTPRICERF"));  // 定価
                    wkSCMInquiryDtlResultAnsWork.UnitPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("UNITPRICERF"));  // 単価
                    wkSCMInquiryDtlResultAnsWork.GoodsAddInfo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSADDINFORF"));  // 商品補足情報
                    wkSCMInquiryDtlResultAnsWork.RoughRrofit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ROUGHRROFITRF"));  // 粗利額
                    wkSCMInquiryDtlResultAnsWork.RoughRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ROUGHRATERF"));  // 粗利率
                    wkSCMInquiryDtlResultAnsWork.AnswerLimitDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERLIMITDATERF"));  // 回答期限
                    wkSCMInquiryDtlResultAnsWork.CommentDtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMMENTDTLRF"));  // 備考(明細)
                    wkSCMInquiryDtlResultAnsWork.ShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHELFNORF"));  // 棚番
                    wkSCMInquiryDtlResultAnsWork.AdditionalDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDITIONALDIVCDRF"));  // 追加区分
                    wkSCMInquiryDtlResultAnsWork.CorrectDivCD = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CORRECTDIVCDRF"));  // 訂正区分   
                    wkSCMInquiryDtlResultAnsWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));  // 企業コード
                    wkSCMInquiryDtlResultAnsWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));  // 売上行番号
                    wkSCMInquiryDtlResultAnsWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAMPAIGNCODERF"));  // キャンペーンコード
                    wkSCMInquiryDtlResultAnsWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKDIVRF"));  // 在庫区分
                    // 2009.08.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    wkSCMInquiryDtlResultAnsWork.RecyclePrtKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECYCLEPRTKINDCODERF"));  // リサイクル部品種別
                    wkSCMInquiryDtlResultAnsWork.RecyclePrtKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECYCLEPRTKINDNAMERF"));  // リサイクル部品種別名称
                    // 2009.08.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    // 2010/05/27 Add >>>
                    wkSCMInquiryDtlResultAnsWork.InqOrdDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQORDDIVCDRF"));  // 問合せ・発注種別
                    // 2010/05/27 Add <<<
                    // -- ADD 2010/06/17 -------------------------------------->>>
                    wkSCMInquiryDtlResultAnsWork.CancelCndtinDiv = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("CANCELCNDTINDIVRF"));  // キャンセル状態区分
                    // -- ADD 2010/06/17 --------------------------------------<<<

                    //--- ADD 2011/05/26 -------------------------------------->>>
                    wkSCMInquiryDtlResultAnsWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));  // 倉庫コード
                    wkSCMInquiryDtlResultAnsWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));  // 倉庫名称
                    wkSCMInquiryDtlResultAnsWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));  // 倉庫棚番
                    //--- ADD 2011/05/26 --------------------------------------<<<

                    // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                    wkSCMInquiryDtlResultAnsWork.PmMainMngWarehouseCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PMMAINMNGWAREHOUSECDRF"));  // PM主管倉庫コード
                    wkSCMInquiryDtlResultAnsWork.PmMainMngWarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PMMAINMNGWAREHOUSENAMERF"));  // PM主管倉庫名称
                    wkSCMInquiryDtlResultAnsWork.PmMainMngShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PMMAINMNGSHELFNORF"));  // PM主管棚番
                    wkSCMInquiryDtlResultAnsWork.PmMainMngPrsntCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PMMAINMNGPRSNTCOUNTRF"));  // PM主管現在個数
                    // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                    // ADD 2015/02/20 吉岡 SCM高速化 C向け種別特記対応   -------------->>>>>>>>>>>>>>>>>>>>
                    wkSCMInquiryDtlResultAnsWork.GoodsSpecialNtForFac = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSPECIALNTFORFACRF"));  // 
                    wkSCMInquiryDtlResultAnsWork.GoodsSpecialNtForCOw = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSPECIALNTFORCOWRF"));  // 
                    wkSCMInquiryDtlResultAnsWork.PrmSetDtlName2ForFac = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME2FORFACRF"));  // 
                    wkSCMInquiryDtlResultAnsWork.PrmSetDtlName2ForCOw = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME2FORCOWRF"));  // 
                    // ADD 2015/02/20 吉岡 SCM高速化 C向け種別特記対応   --------------<<<<<<<<<<<<<<<<<<<<

                    DetailList.Add(wkSCMInquiryDtlResultAnsWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                // 最後の伝票情報追加
                if (DetailList.Count != 0)
                {
                    retList.Add(DetailList);
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMInquiryDB.SearchDetailAnsProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        #endregion

        #region 件数取得

        /// <summary>
        /// 指定された企業コードのSCM問い合わせ一覧の件数を戻します（論理削除除く）
        /// </summary>
        /// <param name="readCnt">抽出件数</param>
        /// <param name="supplierUnmOrderCndtnWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードのSCM問い合わせ一覧件数を戻します（論理削除除く）</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2009.05.14</br>
        public int SearchCnt(out int readCnt, object objscmInquiryOrderWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SCMInquiryOrderWork scmInquiryOrderWork = objscmInquiryOrderWork as SCMInquiryOrderWork;

            readCnt = 0;

            try
            {
                status = SearchCntProc(out readCnt, scmInquiryOrderWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMInquiryDB.Search Exception=" + ex.Message);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 指定された企業コードのSCM問い合わせ一覧の件数を戻します（論理削除除く）
        /// </summary>
        /// <param name="supplierSendErResultWork">検索結果</param>
        /// <param name="_supplierSendErOrderCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードのSCM問い合わせ一覧件数を戻します（論理削除除く）</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2009.05.14</br>
        private int SearchCntProc(out int readCnt, SCMInquiryOrderWork scmInquiryOrderWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            readCnt = 0;

            try
            {
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                // 伝票情報抽出
                status = SearchOrderProc(ref readCnt, ref sqlConnection, scmInquiryOrderWork);

            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMInquiryDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="al">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_supplierSendErOrderCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        private int SearchOrderProc(ref int retCnt, ref SqlConnection sqlConnection, SCMInquiryOrderWork scmInquiryOrderWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                #region Select文作成
                selectTxt += "  SELECT COUNT(*) AS READCOUNT " + Environment.NewLine;
                // -- UPD 2010/04/13 --------------------------------->>>
                //selectTxt += "   FROM SCMACODRDATARF AS SCM   " + Environment.NewLine;
                selectTxt += "   FROM SCMACODRDATARF AS SCM WITH (READUNCOMMITTED)  " + Environment.NewLine;
                // -- UPD 2010/04/13 ---------------------------------<<<
                selectTxt += "    INNER JOIN   " + Environment.NewLine;
                selectTxt += "    (   " + Environment.NewLine;
                selectTxt += "  	  SELECT    " + Environment.NewLine;
                selectTxt += "  	   MAX(UPDATETIMERF) AS UPDATETIMERF   " + Environment.NewLine;
                selectTxt += "  	  ,MAX(UPDATEDATERF) AS UPDATEDATERF   " + Environment.NewLine;
                selectTxt += "  	  ,ENTERPRISECODERF   " + Environment.NewLine;
                selectTxt += "  	  ,INQORIGINALEPCDRF   " + Environment.NewLine;
                selectTxt += "  	  ,INQOTHEREPCDRF   " + Environment.NewLine;
                selectTxt += "  	  ,INQOTHERSECCDRF   " + Environment.NewLine;
                selectTxt += "  	  ,INQUIRYNUMBERRF    " + Environment.NewLine;
                selectTxt += "  	  ,INQORDANSDIVCDRF  " + Environment.NewLine;
                // -- UPD 2010/04/13 --------------------------------->>>
                //selectTxt += "  	  FROM SCMACODRDATARF    " + Environment.NewLine;
                selectTxt += "  	  FROM SCMACODRDATARF WITH (READUNCOMMITTED)    " + Environment.NewLine;
                // -- UPD 2010/04/13 ---------------------------------<<<
                selectTxt += "  	  GROUP BY    " + Environment.NewLine;
                selectTxt += "  	   ENTERPRISECODERF   " + Environment.NewLine;
                selectTxt += "  	  ,INQORIGINALEPCDRF   " + Environment.NewLine;
                selectTxt += "  	  ,INQOTHEREPCDRF   " + Environment.NewLine;
                selectTxt += "  	  ,INQOTHERSECCDRF   " + Environment.NewLine;
                selectTxt += "  	  ,INQUIRYNUMBERRF	   " + Environment.NewLine;
                selectTxt += "  	  ,INQORDANSDIVCDRF  " + Environment.NewLine;
                selectTxt += "    ) AS SCM2   " + Environment.NewLine;
                selectTxt += "    ON   " + Environment.NewLine;
                selectTxt += "        SCM2.ENTERPRISECODERF = SCM.ENTERPRISECODERF   " + Environment.NewLine;
                selectTxt += "    AND SCM2.INQORIGINALEPCDRF = SCM.INQORIGINALEPCDRF   " + Environment.NewLine;
                selectTxt += "    AND SCM2.INQOTHEREPCDRF = SCM.INQOTHEREPCDRF   " + Environment.NewLine;
                selectTxt += "    AND SCM2.INQOTHERSECCDRF = SCM.INQOTHERSECCDRF   " + Environment.NewLine;
                selectTxt += "    AND SCM2.INQUIRYNUMBERRF = SCM.INQUIRYNUMBERRF   " + Environment.NewLine;
                selectTxt += "    AND SCM2.UPDATEDATERF = SCM.UPDATEDATERF   " + Environment.NewLine;
                selectTxt += "    AND SCM2.UPDATETIMERF = SCM.UPDATETIMERF   " + Environment.NewLine;

                //WHERE文の作成
                selectTxt += MakeWhereString(ref sqlCommand, scmInquiryOrderWork, 0);

                sqlCommand.CommandText = selectTxt;

                #endregion

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    retCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("READCOUNT")); // 抽出件数

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMInquiryDB.CustomSearchOrderProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_supplierSendErOrderCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, SCMInquiryOrderWork scmInquiryOrderWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成

            string retst = "";

            string retstring = "WHERE" + Environment.NewLine;

            // 企業コード
            retstring += " SCM.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmInquiryOrderWork.EnterpriseCode);

            // 問合わせ元企業コード 
            if (scmInquiryOrderWork.InqOriginalEpCd != "")
            {
                retstring += "AND  SCM.INQORIGINALEPCDRF=@INQORIGINALEPCD" + Environment.NewLine;
                SqlParameter paraInqOriginalEpCd = sqlCommand.Parameters.Add("@INQORIGINALEPCD", SqlDbType.NChar);
                paraInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(scmInquiryOrderWork.InqOriginalEpCd);
            }
            // 問合わせ元拠点コード //画面拠点
            if (scmInquiryOrderWork.InqOriginalSecCd != "")
            {
                retstring += " AND SCM.INQORIGINALSECCDRF=@INQORIGINALSECCD" + Environment.NewLine;
                SqlParameter paraInqOriginalSecCd = sqlCommand.Parameters.Add("@INQORIGINALSECCD", SqlDbType.NChar);
                paraInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(scmInquiryOrderWork.InqOriginalSecCd);
            }

            // 問合わせ先企業コード
            if (scmInquiryOrderWork.InqOtherEpCd != "")
            {
                retstring += " AND SCM.INQOTHEREPCDRF=@INQOTHEREPCD" + Environment.NewLine;
                SqlParameter paraInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
                paraInqOtherEpCd.Value = SqlDataMediator.SqlSetString(scmInquiryOrderWork.InqOtherEpCd);
            }

            // 問合わせ先拠点コード
            if (scmInquiryOrderWork.InqOtherSecCd != "")
            {
                retstring += " AND SCM.INQOTHERSECCDRF=@INQOTHERSECCD" + Environment.NewLine;
                SqlParameter paraInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
                paraInqOtherSecCd.Value = SqlDataMediator.SqlSetString(scmInquiryOrderWork.InqOtherSecCd);
            }

            // 問合せ番号
            if (scmInquiryOrderWork.St_InquiryNumber != 0)
            {
                retstring += " AND SCM.INQUIRYNUMBERRF>=@STINQUIRYNUMBER" + Environment.NewLine;
                SqlParameter paraStInquiryNumber = sqlCommand.Parameters.Add("@STINQUIRYNUMBER", SqlDbType.BigInt);
                paraStInquiryNumber.Value = SqlDataMediator.SqlSetInt64(scmInquiryOrderWork.St_InquiryNumber);
            }
            if (scmInquiryOrderWork.Ed_InquiryNumber != 0)
            {
                retstring += " AND SCM.INQUIRYNUMBERRF<=@EDINQUIRYNUMBER" + Environment.NewLine;
                SqlParameter paraEdInquiryNumber = sqlCommand.Parameters.Add("@EDINQUIRYNUMBER", SqlDbType.BigInt);
                paraEdInquiryNumber.Value = SqlDataMediator.SqlSetInt64(scmInquiryOrderWork.Ed_InquiryNumber);
            }

            // 更新年月日
            if (scmInquiryOrderWork.UpdateDate != DateTime.MinValue)
            {
                retstring += " AND SCM.UPDATEDATERF=@UPDATEDATE" + Environment.NewLine;
                SqlParameter paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);
                paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(scmInquiryOrderWork.UpdateDate);
            }

            // 更新時分秒ミリ秒
            if (scmInquiryOrderWork.UpdateTime != 0)
            {
                retstring += " AND SCM.UPDATETIMERF=@UPDATETIME" + Environment.NewLine;
                SqlParameter paraUpdateTime = sqlCommand.Parameters.Add("@UPDATETIME", SqlDbType.Int);
                paraUpdateTime.Value = SqlDataMediator.SqlSetInt32(scmInquiryOrderWork.UpdateTime);
            }

            // 問合せ・発注種別
            if (scmInquiryOrderWork.InqOrdDivCd != null)
            {
                retst = "";
                foreach (int str in scmInquiryOrderWork.InqOrdDivCd)
                {
                    if (retst != "") retst += ",";
                    retst += "'" + str + "'";
                }
                if (retst != "")
                {
                    retstring += "AND SCM.INQORDDIVCDRF IN (" + retst + ") ";
                }
            }

            // 回答区分
            if (scmInquiryOrderWork.AnswerDivCd != null)
            {
                retst = "";
                foreach (int str in scmInquiryOrderWork.AnswerDivCd)
                {
                    if (retst != "") retst += ",";
                    retst += "'" + str + "'";
                }
                if (retst != "")
                {
                    retstring += "AND SCM.ANSWERDIVCDRF IN (" + retst + ") ";
                }
            }
            
            // 確定日
            if (scmInquiryOrderWork.JudgementDate != 0)
            {
                retstring += " AND SCM.JUDGEMENTDATERF=@JUDGEMENTDATE" + Environment.NewLine;
                SqlParameter paraJudgementDate = sqlCommand.Parameters.Add("@JUDGEMENTDATE", SqlDbType.Int);
                paraJudgementDate.Value = SqlDataMediator.SqlSetInt32(scmInquiryOrderWork.JudgementDate);
            }

            // 問合わせ・発注備考
            if (scmInquiryOrderWork.InqOrdNote != "")
            {
                retstring += " AND SCM.INQORDNOTERF=@INQORDNOTE" + Environment.NewLine;
                SqlParameter paraInqOrdNote = sqlCommand.Parameters.Add("@INQORDNOTE", SqlDbType.NChar);
                paraInqOrdNote.Value = SqlDataMediator.SqlSetString(scmInquiryOrderWork.InqOrdNote);
            }

            // 問合せ従業員コード
            if (scmInquiryOrderWork.InqEmployeeCd != "")
            {
                retstring += " AND SCM.INQEMPLOYEECDRF=@INQEMPLOYEECD" + Environment.NewLine;
                SqlParameter paraInqEmployeeCd = sqlCommand.Parameters.Add("@INQEMPLOYEECD", SqlDbType.NChar);
                paraInqEmployeeCd.Value = SqlDataMediator.SqlSetString(scmInquiryOrderWork.InqEmployeeCd);
            }

            // 回答従業員コード
            if (scmInquiryOrderWork.AnsEmployeeCd != "")
            {
                retstring += " AND SCM.ANSEMPLOYEECDRF=@ANSEMPLOYEECD" + Environment.NewLine;
                SqlParameter paraAnsEmployeeCd = sqlCommand.Parameters.Add("@ANSEMPLOYEECD", SqlDbType.NChar);
                paraAnsEmployeeCd.Value = SqlDataMediator.SqlSetString(scmInquiryOrderWork.AnsEmployeeCd);
            }

            // 問合せ日
            if (scmInquiryOrderWork.St_InquiryDate != 0)
            {
                retstring += " AND SCM.INQUIRYDATERF>=@STINQUIRYDATE" + Environment.NewLine;
                SqlParameter paraStInquiryDate = sqlCommand.Parameters.Add("@STINQUIRYDATE", SqlDbType.Int);
                paraStInquiryDate.Value = SqlDataMediator.SqlSetInt32(scmInquiryOrderWork.St_InquiryDate);
            }
            if (scmInquiryOrderWork.Ed_InquiryDate != 0)
            {
                retstring += " AND SCM.INQUIRYDATERF<=@EDINQUIRYDATE" + Environment.NewLine;
                SqlParameter paraEdInquiryDate = sqlCommand.Parameters.Add("@EDINQUIRYDATE", SqlDbType.Int);
                paraEdInquiryDate.Value = SqlDataMediator.SqlSetInt32(scmInquiryOrderWork.Ed_InquiryDate);
            }
            // --- ADD m.suzuki 2011/06/13 ---------->>>>>
            // 更新年月日
            if ( scmInquiryOrderWork.St_UpdateDate != 0 )
            {
                retstring += " AND SCM.UPDATEDATERF>=@STUPDATEDATE" + Environment.NewLine;
                SqlParameter paraStUpdateDate = sqlCommand.Parameters.Add( "@STUPDATEDATE", SqlDbType.Int );
                paraStUpdateDate.Value = SqlDataMediator.SqlSetInt32( scmInquiryOrderWork.St_UpdateDate );
            }
            if ( scmInquiryOrderWork.Ed_UpdateDate != 0 )
            {
                retstring += " AND SCM.UPDATEDATERF<=@EDUPDATEDATE" + Environment.NewLine;
                SqlParameter paraEdUpdateDate = sqlCommand.Parameters.Add( "@EDUPDATEDATE", SqlDbType.Int );
                paraEdUpdateDate.Value = SqlDataMediator.SqlSetInt32( scmInquiryOrderWork.Ed_UpdateDate );
            }
            // --- ADD m.suzuki 2011/06/13 ----------<<<<<

            // 得意先コード
            if (scmInquiryOrderWork.St_CustomerCode != 0)
            {
                retstring += " AND SCM.CUSTOMERCODERF>=@STCUSTOMERCODE" + Environment.NewLine;
                SqlParameter paraStCustomerCode = sqlCommand.Parameters.Add("@STCUSTOMERCODE", SqlDbType.Int);
                paraStCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmInquiryOrderWork.St_CustomerCode);
            }
            if (scmInquiryOrderWork.Ed_CustomerCode != 0)
            {
                retstring += " AND SCM.CUSTOMERCODERF<=@EDCUSTOMERCODE" + Environment.NewLine;
                SqlParameter paraEdCustomerCode = sqlCommand.Parameters.Add("@EDCUSTOMERCODE", SqlDbType.Int);
                paraEdCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmInquiryOrderWork.Ed_CustomerCode);
            }

            // 回答方法
            if (scmInquiryOrderWork.AwnserMethod != null)
            {
                retst = "";
                foreach (int str in scmInquiryOrderWork.AwnserMethod)
                {
                    if (retst != "") retst += ",";
                    retst += "'" + str + "'";
                }
                if (retst != "")
                {
                    retstring += "AND SCM.ANSWERCREATEDIVRF IN (" + retst + ") ";
                }
            }

            // 伝票番号
            if (scmInquiryOrderWork.St_SalesSlipNum != "")
            {
                retstring += " AND SCM.SALESSLIPNUMRF>=@STSALESSLIPNUM" + Environment.NewLine;
                SqlParameter paraStSalesSlipNum = sqlCommand.Parameters.Add("@STSALESSLIPNUM", SqlDbType.NChar);
                paraStSalesSlipNum.Value = SqlDataMediator.SqlSetString(scmInquiryOrderWork.St_SalesSlipNum);
            }
            if (scmInquiryOrderWork.Ed_SalesSlipNum != "")
            {
                retstring += " AND SCM.SALESSLIPNUMRF<=@EDSALESSLIPNUM" + Environment.NewLine;
                SqlParameter paraEdSalesSlipNum = sqlCommand.Parameters.Add("@EDSALESSLIPNUM", SqlDbType.NChar);
                paraEdSalesSlipNum.Value = SqlDataMediator.SqlSetString(scmInquiryOrderWork.Ed_SalesSlipNum);
            }

            // 受注ステータス
            if (scmInquiryOrderWork.AcptAnOdrStatus != null)
            {
                retst = "";
                foreach (int str in scmInquiryOrderWork.AcptAnOdrStatus)
                {
                    if (retst != "") retst += ",";
                    retst += "'" + str + "'";
                }
                if (retst != "")
                {
                    retstring += "AND SCM.ACPTANODRSTATUSRF IN (" + retst + ") ";
                }
            }

            // 売上伝票計
            if (scmInquiryOrderWork.SalesTotalTaxInc != 0)
            {
                retstring += " AND SCM.SALESTOTALTAXINCRF=@SALESTOTALTAXINC" + Environment.NewLine;
                SqlParameter paraSalesTotalTaxInc = sqlCommand.Parameters.Add("@SALESTOTALTAXINC", SqlDbType.Int);
                paraSalesTotalTaxInc.Value = SqlDataMediator.SqlSetInt64(scmInquiryOrderWork.SalesTotalTaxInc);
            }
            // ---- ADD gezh 2011/11/12 -------->>>>>
            // 連携対象区分
            if (scmInquiryOrderWork.CooperationOptionDiv != null)
            {
                retst = "";
                foreach (int str in scmInquiryOrderWork.CooperationOptionDiv)
                {
                    if (retst != "") retst += ",";
                    retst += "'" + str + "'";
                }
                if (retst != "")
                {
                    retstring += "AND SCM.ACCEPTORORDERKINDRF IN (" + retst + ") ";
                }
            }
            // ---- ADD gezh 2011/11/12 --------<<<<<

            // ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
            // 入庫予定日
            if (scmInquiryOrderWork.St_ExpectedCeDate != 0)
            {
                retstring += " AND CAR.EXPECTEDCEDATERF>=@STEXPECTEDCEDATE" + Environment.NewLine;
                SqlParameter paraStExpectedCeDate = sqlCommand.Parameters.Add("@STEXPECTEDCEDATE", SqlDbType.Int);
                paraStExpectedCeDate.Value = SqlDataMediator.SqlSetInt32(scmInquiryOrderWork.St_ExpectedCeDate);
            }
            if (scmInquiryOrderWork.Ed_ExpectedCeDate != 0)
            {
                retstring += " AND CAR.EXPECTEDCEDATERF<=@EDEXPECTEDCEDATE" + Environment.NewLine;
                SqlParameter paraEdExpectedCeDate = sqlCommand.Parameters.Add("@EDEXPECTEDCEDATE", SqlDbType.Int);
                paraEdExpectedCeDate.Value = SqlDataMediator.SqlSetInt32(scmInquiryOrderWork.Ed_ExpectedCeDate);
            }
            // ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<

            return retstring;
            #endregion
        }
    }
}

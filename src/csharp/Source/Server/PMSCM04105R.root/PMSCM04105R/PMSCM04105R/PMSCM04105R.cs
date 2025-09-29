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
    /// 売上履歴回答照会DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上履歴回答照会の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30350 櫻井 亮太</br>
    /// <br>Date       : 2009.05.19</br>
    /// <br></br>
    /// <br>Update Note: MANTIS 14155 抽出結果に回答作成区分追加。
    /// <br>           :        14157 各種項目を正常取得できるように変更</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2009.08.25</br>
    /// </remarks>
    [Serializable]
    public class SCMAnsHistDB : RemoteDB, ISCMAnsHistDB
    {
        /// <summary>
        /// 売上履歴回答照会DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2009.05.19</br>
        /// </remarks>
        public SCMAnsHistDB()
            :
        base("PMSCM04107D", "Broadleaf.Application.Remoting.ParamData.SCMAnsHistResultWork", "SCMACODRDATARF") //基底クラスのコンストラクタ
        {
        }

        #region 売上履歴回答照会

        /// <summary>
        /// 指定された企業コードの売上履歴回答照会のLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="supplierUnmResultWork">検索結果</param>
        /// <param name="supplierUnmOrderCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードのSCM問い合わせ一覧LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2009.05.19</br>
        public int Search(out object scmAnsHistResultWork, object objscmAnsHistOrderWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            scmAnsHistResultWork = null;

            SCMAnsHistOrderWork scmAnsHistOrderWork = objscmAnsHistOrderWork as SCMAnsHistOrderWork;
            
            try
            {
                status = SearchProc(out scmAnsHistResultWork, scmAnsHistOrderWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMAnsHistDB.Search Exception=" + ex.Message);
                scmAnsHistResultWork = new ArrayList();
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
        private int SearchProc(out object scmAnsHistResultWork, SCMAnsHistOrderWork scmAnsHistOrderWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            scmAnsHistResultWork = null;

            ArrayList al = new ArrayList();   //明細情報抽出結果

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
                status = SearchOrderProc(ref al, ref sqlConnection, scmAnsHistOrderWork, logicalMode);

            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMAnsHistDB.SearchProc Exception=" + ex.Message);
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

            scmAnsHistResultWork = al;

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
        private int SearchOrderProc(ref ArrayList al, ref SqlConnection sqlConnection, SCMAnsHistOrderWork scmAnsHistOrderWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                #region Select文作成

                selectTxt += "  SELECT SCM.INQOTHEREPCDRF  " + Environment.NewLine;
                selectTxt += "          ,SCM.INQOTHERSECCDRF  " + Environment.NewLine;
                selectTxt += "          ,SEC.SECTIONGUIDENMRF  " + Environment.NewLine;
                selectTxt += "          ,SCM.CUSTOMERCODERF  " + Environment.NewLine;
                selectTxt += "          ,CUS.CUSTOMERSNMRF AS CUSTOMERNAMERF  " + Environment.NewLine;
                selectTxt += "          ,SCM.INQUIRYNUMBERRF  " + Environment.NewLine;
                selectTxt += "          ,SCM.UPDATEDATERF  " + Environment.NewLine;
                selectTxt += "          ,SCM.UPDATETIMERF  " + Environment.NewLine;
                selectTxt += "          ,SCM.ANSWERDIVCDRF  " + Environment.NewLine;
                selectTxt += "          ,SCM.JUDGEMENTDATERF  " + Environment.NewLine;
                selectTxt += "          ,SCM.INQORDNOTERF  " + Environment.NewLine;
                selectTxt += "          ,SCM.INQEMPLOYEECDRF  " + Environment.NewLine;
                selectTxt += "          ,SCM.INQEMPLOYEENMRF  " + Environment.NewLine;
                selectTxt += "          ,SCM.ANSEMPLOYEECDRF  " + Environment.NewLine;
                selectTxt += "          ,SCM.ANSEMPLOYEENMRF  " + Environment.NewLine;
                selectTxt += "          ,SCM.INQUIRYDATERF  " + Environment.NewLine;
                selectTxt += "          ,CAR.NUMBERPLATE1CODERF  " + Environment.NewLine;
                selectTxt += "          ,CAR.NUMBERPLATE1NAMERF  " + Environment.NewLine;
                selectTxt += "          ,CAR.NUMBERPLATE2RF  " + Environment.NewLine;
                selectTxt += "          ,CAR.NUMBERPLATE3RF  " + Environment.NewLine;
                selectTxt += "          ,CAR.NUMBERPLATE4RF  " + Environment.NewLine;
                selectTxt += "          ,CAR.MODELDESIGNATIONNORF  " + Environment.NewLine;
                selectTxt += "          ,CAR.CATEGORYNORF  " + Environment.NewLine;
                selectTxt += "          ,CAR.MAKERCODERF  " + Environment.NewLine;
                selectTxt += "          ,MAK2.MAKERNAMERF AS CARMAKERNAMERF  " + Environment.NewLine;
                selectTxt += "          ,CAR.MODELCODERF  " + Environment.NewLine;
                selectTxt += "          ,CAR.MODELSUBCODERF  " + Environment.NewLine;
                selectTxt += "          ,CAR.MODELNAMERF  " + Environment.NewLine;
                selectTxt += "          ,CAR.CARINSPECTCERTMODELRF  " + Environment.NewLine;
                selectTxt += "          ,CAR.FULLMODELRF  " + Environment.NewLine;
                selectTxt += "          ,CAR.FRAMENORF  " + Environment.NewLine;
                selectTxt += "          ,CAR.FRAMEMODELRF  " + Environment.NewLine;
                selectTxt += "          ,CAR.CHASSISNORF  " + Environment.NewLine;
                selectTxt += "          ,CAR.CARPROPERNORF  " + Environment.NewLine;
                selectTxt += "          ,CAR.PRODUCETYPEOFYEARNUMRF  " + Environment.NewLine;
                selectTxt += "          ,CAR.COMMENTRF  " + Environment.NewLine;
                selectTxt += "          ,CAR.RPCOLORCODERF  " + Environment.NewLine;
                selectTxt += "          ,CAR.COLORNAME1RF  " + Environment.NewLine;
                selectTxt += "          ,CAR.TRIMCODERF  " + Environment.NewLine;
                selectTxt += "          ,CAR.TRIMNAMERF  " + Environment.NewLine;
                selectTxt += "          ,CAR.MILEAGERF  " + Environment.NewLine;
                selectTxt += "          ,CAR.EQUIPOBJRF  " + Environment.NewLine;
                selectTxt += "          ,ANS.INQROWNUMBERRF  " + Environment.NewLine;
                selectTxt += "          ,ANS.INQROWNUMDERIVEDNORF  " + Environment.NewLine;
                selectTxt += "          ,ANS.GOODSDIVCDRF  " + Environment.NewLine;
                selectTxt += "          ,ANS.RECYCLEPRTKINDCODERF  " + Environment.NewLine;
                selectTxt += "          ,ANS.RECYCLEPRTKINDNAMERF  " + Environment.NewLine;
                selectTxt += "          ,ANS.DELIVEREDGOODSDIVRF  " + Environment.NewLine;
                selectTxt += "          ,ANS.HANDLEDIVCODERF  " + Environment.NewLine;
                selectTxt += "          ,ANS.GOODSSHAPERF  " + Environment.NewLine;
                selectTxt += "          ,ANS.DELIVRDGDSCONFCDRF  " + Environment.NewLine;
                selectTxt += "          ,ANS.DELIGDSCMPLTDUEDATERF  " + Environment.NewLine;
                selectTxt += "          ,ANS.BLGOODSCODERF  " + Environment.NewLine;
                selectTxt += "          ,ANS.BLGOODSDRCODERF " + Environment.NewLine;
                selectTxt += "          ,ANS.INQGOODSNAMERF " + Environment.NewLine;
                selectTxt += "          ,ANS.ANSGOODSNAMERF  " + Environment.NewLine;
                selectTxt += "          ,ANS.SALESORDERCOUNTRF  " + Environment.NewLine;
                selectTxt += "          ,ANS.DELIVEREDGOODSCOUNTRF  " + Environment.NewLine;
                selectTxt += "          ,ANS.GOODSNORF  " + Environment.NewLine;
                selectTxt += "          ,ANS.GOODSMAKERCDRF  " + Environment.NewLine;
                selectTxt += "          ,MAK.MAKERNAMERF  " + Environment.NewLine;
                selectTxt += "          ,ANS.PUREGOODSMAKERCDRF  " + Environment.NewLine;
                selectTxt += "          ,MAP.MAKERNAMERF AS PUREMAKERNAMERF  " + Environment.NewLine;
                selectTxt += "          ,ANS.INQPUREGOODSNORF " + Environment.NewLine;
                selectTxt += "          ,ANS.ANSPUREGOODSNORF " + Environment.NewLine;
                selectTxt += "          ,GOAP.GOODSNAMEKANARF AS ANSPUREGOODSNAMERF  " + Environment.NewLine;
                selectTxt += "          ,GOIP.GOODSNAMEKANARF AS INQPUREGOODSNAMERF " + Environment.NewLine;
                selectTxt += "          ,ANS.LISTPRICERF  " + Environment.NewLine;
                selectTxt += "          ,ANS.UNITPRICERF  " + Environment.NewLine;
                selectTxt += "          ,ANS.GOODSADDINFORF  " + Environment.NewLine;
                selectTxt += "          ,ANS.ROUGHRROFITRF  " + Environment.NewLine;
                selectTxt += "          ,ANS.ROUGHRATERF  " + Environment.NewLine;
                selectTxt += "          ,ANS.ANSWERLIMITDATERF  " + Environment.NewLine;
                selectTxt += "          ,ANS.COMMENTDTLRF  " + Environment.NewLine;
                selectTxt += "          ,ANS.SHELFNORF  " + Environment.NewLine;
                selectTxt += "          ,ANS.ADDITIONALDIVCDRF  " + Environment.NewLine;
                selectTxt += "          ,ANS.CORRECTDIVCDRF  " + Environment.NewLine;
                selectTxt += "          ,ANS.ACPTANODRSTATUSRF  " + Environment.NewLine;
                selectTxt += "          ,ANS.SALESSLIPNUMRF  " + Environment.NewLine;
                selectTxt += "          ,ANS.SALESROWNORF  " + Environment.NewLine;
                selectTxt += "          ,ANS.STOCKDIVRF  " + Environment.NewLine;
                selectTxt += "          ,ANS.INQORDDIVCDRF  " + Environment.NewLine;
                selectTxt += "          ,ANS.DISPLAYORDERRF  " + Environment.NewLine;
                selectTxt += "          ,SAL.CAMPAIGNCODERF  " + Environment.NewLine;
                selectTxt += "          ,SAL.CAMPAIGNNAMERF  " + Environment.NewLine;
                selectTxt += "          ,SCM.SALESTOTALTAXINCRF  " + Environment.NewLine;
                selectTxt += "          ,SCM.SALESSUBTOTALTAXRF  " + Environment.NewLine;
                selectTxt += "          ,SCM.INQORDANSDIVCDRF  " + Environment.NewLine;
                selectTxt += "          ,SCM.RECEIVEDATETIMERF  " + Environment.NewLine;
                // 2009.08.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                selectTxt += "          ,SCM.ANSWERCREATEDIVRF  " + Environment.NewLine;
                // 2009.08.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                selectTxt += "          ,ANS.ANSWERDELIVERYDATERF  " + Environment.NewLine;
                selectTxt += "           ,INQ.INQROWNUMBERRF AS IINQROWNUMBERRF  " + Environment.NewLine;
                selectTxt += "           ,INQ.INQROWNUMDERIVEDNORF AS IINQROWNUMDERIVEDNORF  " + Environment.NewLine;
                selectTxt += "           ,INQ.GOODSDIVCDRF AS IGOODSDIVCDRF  " + Environment.NewLine;
                selectTxt += "           ,INQ.RECYCLEPRTKINDCODERF AS IRECYCLEPRTKINDCODERF  " + Environment.NewLine;
                selectTxt += "           ,INQ.RECYCLEPRTKINDNAMERF AS IRECYCLEPRTKINDNAMERF  " + Environment.NewLine;
                selectTxt += "           ,INQ.DELIVEREDGOODSDIVRF AS IRECYCLEPRTKINDNAMERF  " + Environment.NewLine;
                selectTxt += "           ,INQ.HANDLEDIVCODERF AS IHANDLEDIVCODERF  " + Environment.NewLine;
                selectTxt += "           ,INQ.GOODSSHAPERF AS IGOODSSHAPERF  " + Environment.NewLine;
                selectTxt += "           ,INQ.DELIVRDGDSCONFCDRF AS IDELIVRDGDSCONFCDRF  " + Environment.NewLine;
                selectTxt += "           ,INQ.DELIGDSCMPLTDUEDATERF AS IDELIGDSCMPLTDUEDATERF  " + Environment.NewLine;
                selectTxt += "           ,INQ.BLGOODSCODERF AS IBLGOODSCODERF  " + Environment.NewLine;
                selectTxt += "           ,INQ.BLGOODSDRCODERF AS IBLGOODSDRCODERF  " + Environment.NewLine;
                selectTxt += "           ,INQ.ANSGOODSNAMERF AS IANSGOODSNAMERF " + Environment.NewLine;
                selectTxt += "           ,INQ.INQGOODSNAMERF AS IINQGOODSNAMERF   " + Environment.NewLine;
                selectTxt += "           ,INQ.SALESORDERCOUNTRF AS ISALESORDERCOUNTRF  " + Environment.NewLine;
                selectTxt += "           ,INQ.DELIVEREDGOODSCOUNTRF AS IDELIVEREDGOODSCOUNTRF  " + Environment.NewLine;
                selectTxt += "           ,INQ.GOODSNORF AS IGOODSNORF  " + Environment.NewLine;
                selectTxt += "           ,INQ.GOODSMAKERCDRF AS IGOODSMAKERCDRF  " + Environment.NewLine;
                selectTxt += "           ,IMAK.MAKERNAMERF AS IMAKERNAMERF   " + Environment.NewLine;
                selectTxt += "           ,INQ.PUREGOODSMAKERCDRF AS IPUREGOODSMAKERCDRF   " + Environment.NewLine;
                selectTxt += "           ,MAP2.MAKERNAMERF AS IPUREMAKERNAMERF   " + Environment.NewLine;
                selectTxt += "           ,INQ.INQPUREGOODSNORF AS IIPUREGOODSNORF   " + Environment.NewLine;
                selectTxt += "           ,INQ.ANSPUREGOODSNORF AS IAPUREGOODSNORF   " + Environment.NewLine;
                selectTxt += "           ,GOIP2.GOODSNAMEKANARF AS IIPUREGOODSNAMERF   " + Environment.NewLine;
                selectTxt += "           ,GOAP2.GOODSNAMEKANARF AS IAPUREGOODSNAMERF " + Environment.NewLine;
                selectTxt += "           ,INQ.LISTPRICERF AS ILISTPRICERF   " + Environment.NewLine;
                selectTxt += "           ,INQ.UNITPRICERF AS IUNITPRICERF  " + Environment.NewLine;
                selectTxt += "           ,INQ.GOODSADDINFORF AS IGOODSADDINFORF  " + Environment.NewLine;
                selectTxt += "           ,INQ.ROUGHRROFITRF AS IROUGHRROFITRF  " + Environment.NewLine;
                selectTxt += "           ,INQ.ROUGHRATERF AS IROUGHRATERF   " + Environment.NewLine;
                selectTxt += "           ,INQ.ANSWERLIMITDATERF AS IANSWERLIMITDATERF   " + Environment.NewLine;
                selectTxt += "           ,INQ.COMMENTDTLRF AS ICOMMENTDTLRF   " + Environment.NewLine;
                selectTxt += "           ,INQ.SHELFNORF AS ISHELFNORF   " + Environment.NewLine;
                selectTxt += "           ,INQ.ADDITIONALDIVCDRF AS IADDITIONALDIVCDRF   " + Environment.NewLine;
                selectTxt += "           ,INQ.CORRECTDIVCDRF AS ICORRECTDIVCDRF   " + Environment.NewLine;
                selectTxt += "           ,INQ.DISPLAYORDERRF AS IDISPLAYORDERRF   " + Environment.NewLine;
                selectTxt += "           ,INQ.ANSWERDELIVERYDATERF AS IANSWERDELIVERYDATERF   " + Environment.NewLine;
                selectTxt += "           ,INQ.INQORDDIVCDRF AS IINQORDDIVCDRF   " + Environment.NewLine;
                selectTxt += "           ,ANS.UPDATEDATERF AS AUPDATEDATERF  " + Environment.NewLine;
                selectTxt += "           ,INQ.UPDATEDATERF AS IUPDATEDATERF  " + Environment.NewLine;
                selectTxt += "   FROM SCMACODRDATARF AS SCM  " + Environment.NewLine;
                selectTxt += "  LEFT JOIN CUSTOMERRF AS CUS  " + Environment.NewLine;
                selectTxt += "  ON  " + Environment.NewLine;
                selectTxt += "  	 CUS.ENTERPRISECODERF = SCM.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "   AND CUS.CUSTOMERCODERF = SCM.CUSTOMERCODERF  " + Environment.NewLine;
                selectTxt += "  LEFT JOIN SCMACODRDTCARRF AS CAR  " + Environment.NewLine;
                selectTxt += "  ON  " + Environment.NewLine;
                selectTxt += "  	 CAR.ENTERPRISECODERF = SCM.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "   AND CAR.INQORIGINALEPCDRF = SCM.INQORIGINALEPCDRF  " + Environment.NewLine;
                selectTxt += "   AND CAR.INQORIGINALSECCDRF = SCM.INQORIGINALSECCDRF  " + Environment.NewLine;
                selectTxt += "   AND CAR.INQUIRYNUMBERRF = SCM.INQUIRYNUMBERRF  " + Environment.NewLine;
                selectTxt += "   AND CAR.SALESSLIPNUMRF = SCM.SALESSLIPNUMRF " + Environment.NewLine;
                selectTxt += "   AND CAR.ACPTANODRSTATUSRF = SCM.ACPTANODRSTATUSRF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN SCMACODRDTLASRF AS ANS  " + Environment.NewLine;
                selectTxt += "  ON  " + Environment.NewLine;
                selectTxt += "  	 ANS.ENTERPRISECODERF = SCM.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "   AND ANS.INQORIGINALEPCDRF = SCM.INQORIGINALEPCDRF  " + Environment.NewLine;
                selectTxt += "   AND ANS.INQORIGINALSECCDRF = SCM.INQORIGINALSECCDRF  " + Environment.NewLine;
                selectTxt += "   AND ANS.INQUIRYNUMBERRF = SCM.INQUIRYNUMBERRF  " + Environment.NewLine;
                selectTxt += "   AND ANS.UPDATEDATERF = SCM.UPDATEDATERF  " + Environment.NewLine;
                selectTxt += "   AND ANS.UPDATETIMERF = SCM.UPDATETIMERF  " + Environment.NewLine;
                selectTxt += "   AND ANS.SALESSLIPNUMRF = SCM.SALESSLIPNUMRF " + Environment.NewLine;
                selectTxt += "   AND ANS.ACPTANODRSTATUSRF = SCM.ACPTANODRSTATUSRF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN MAKERURF AS MAK  " + Environment.NewLine;
                selectTxt += "  ON  " + Environment.NewLine;
                selectTxt += "  	 MAK.ENTERPRISECODERF = SCM.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "   AND MAK.GOODSMAKERCDRF = ANS.GOODSMAKERCDRF  " + Environment.NewLine;
                selectTxt += "  LEFT JOIN MAKERURF AS MAP  " + Environment.NewLine;
                selectTxt += "  ON  " + Environment.NewLine;
                selectTxt += "  	 MAP.ENTERPRISECODERF = SCM.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "   AND MAP.GOODSMAKERCDRF = ANS.PUREGOODSMAKERCDRF  " + Environment.NewLine;
                selectTxt += "  LEFT JOIN GOODSURF AS GOAP  " + Environment.NewLine;
                selectTxt += "  ON  " + Environment.NewLine;
                selectTxt += "  	 GOAP.ENTERPRISECODERF = SCM.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "   AND GOAP.GOODSMAKERCDRF = ANS.GOODSMAKERCDRF  " + Environment.NewLine;
                selectTxt += "   AND GOAP.GOODSNORF = ANS.ANSPUREGOODSNORF  " + Environment.NewLine;
                selectTxt += "  LEFT JOIN GOODSURF AS GOIP " + Environment.NewLine;
                selectTxt += "  ON " + Environment.NewLine;
                selectTxt += " 	 GOIP.ENTERPRISECODERF = SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND GOIP.GOODSMAKERCDRF = ANS.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += "   AND GOIP.GOODSNORF = ANS.INQPUREGOODSNORF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN GOODSURF AS GOO  " + Environment.NewLine;
                selectTxt += "  ON  " + Environment.NewLine;
                selectTxt += "  	 GOO.ENTERPRISECODERF = SCM.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "  	 AND GOO.GOODSMAKERCDRF = ANS.GOODSMAKERCDRF  " + Environment.NewLine;
                selectTxt += "  	 AND GOO.GOODSNORF = ANS.ANSPUREGOODSNORF  " + Environment.NewLine;
                selectTxt += "  LEFT JOIN SECINFOSETRF AS SEC  " + Environment.NewLine;
                selectTxt += "  ON   " + Environment.NewLine;
                selectTxt += "  	 SEC.ENTERPRISECODERF = SCM.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "   AND SEC.SECTIONCODERF = SCM.INQOTHERSECCDRF  " + Environment.NewLine;
                selectTxt += "  LEFT JOIN MAKERURF AS MAK2  " + Environment.NewLine;
                selectTxt += "  ON  " + Environment.NewLine;
                selectTxt += "       MAK2.ENTERPRISECODERF = SCM.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "   AND MAK2.GOODSMAKERCDRF = CAR.MAKERCODERF  " + Environment.NewLine;
                selectTxt += "  LEFT JOIN SALESDETAILRF AS SAL  " + Environment.NewLine;
                selectTxt += "  ON  " + Environment.NewLine;
                selectTxt += "  	 SAL.ENTERPRISECODERF = SCM.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "   AND SAL.ACPTANODRSTATUSRF = SCM.ACPTANODRSTATUSRF  " + Environment.NewLine;
                selectTxt += "   AND SAL.SALESSLIPNUMRF = SCM.SALESSLIPNUMRF  " + Environment.NewLine;
                selectTxt += "   AND SAL.SALESROWNORF = ANS.SALESROWNORF  " + Environment.NewLine;
                selectTxt += "  LEFT JOIN SCMACODRDTLIQRF AS INQ   " + Environment.NewLine;
                selectTxt += "   ON   " + Environment.NewLine;
                selectTxt += "   	 INQ.ENTERPRISECODERF = SCM.ENTERPRISECODERF   " + Environment.NewLine;
                selectTxt += "    AND INQ.INQORIGINALEPCDRF = SCM.INQORIGINALEPCDRF   " + Environment.NewLine;
                selectTxt += "    AND INQ.INQORIGINALSECCDRF = SCM.INQORIGINALSECCDRF   " + Environment.NewLine;
                selectTxt += "    AND INQ.INQUIRYNUMBERRF = SCM.INQUIRYNUMBERRF   " + Environment.NewLine;
                selectTxt += "    AND INQ.UPDATEDATERF = SCM.UPDATEDATERF   " + Environment.NewLine;
                selectTxt += "    AND INQ.UPDATETIMERF = SCM.UPDATETIMERF   " + Environment.NewLine;
                selectTxt += "  LEFT JOIN MAKERURF AS IMAK  " + Environment.NewLine;
                selectTxt += "  ON  " + Environment.NewLine;
                selectTxt += "  	    IMAK.ENTERPRISECODERF = SCM.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "   AND IMAK.GOODSMAKERCDRF = INQ.GOODSMAKERCDRF  " + Environment.NewLine;
                selectTxt += "  LEFT JOIN MAKERURF AS MAP2  " + Environment.NewLine;
                selectTxt += "  ON  " + Environment.NewLine;
                selectTxt += "  	    MAP2.ENTERPRISECODERF = SCM.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "   AND MAP2.GOODSMAKERCDRF = INQ.PUREGOODSMAKERCDRF  " + Environment.NewLine;
                selectTxt += "  LEFT JOIN GOODSURF AS GOAP2  " + Environment.NewLine;
                selectTxt += "  ON  " + Environment.NewLine;
                selectTxt += "       GOAP2.ENTERPRISECODERF = SCM.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "   AND GOAP2.GOODSMAKERCDRF = INQ.GOODSMAKERCDRF  " + Environment.NewLine;
                selectTxt += "   AND GOAP2.GOODSNORF = INQ.ANSPUREGOODSNORF  " + Environment.NewLine;
                selectTxt += "  LEFT JOIN GOODSURF AS GOIP2 " + Environment.NewLine;
                selectTxt += "  ON " + Environment.NewLine;
                selectTxt += " 	  GOIP2.ENTERPRISECODERF = SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND GOIP2.GOODSMAKERCDRF = INQ.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += "   AND GOIP2.GOODSNORF = INQ.INQPUREGOODSNORF   " + Environment.NewLine;


  
                //WHERE文の作成
                selectTxt += MakeWhereString(ref sqlCommand, scmAnsHistOrderWork, logicalMode);

                sqlCommand.CommandText = selectTxt;

                #endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region 抽出結果-値セット
                    //キー情報があるか
                    if (SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUPDATEDATERF")) != 0)
                    {
                        SCMAnsHistResultWork wkSCMAnsHistResultWork = new SCMAnsHistResultWork();

                        wkSCMAnsHistResultWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHEREPCDRF"));  // 問合せ先企業コード
                        wkSCMAnsHistResultWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHERSECCDRF"));  // 問合せ先拠点コード
                        wkSCMAnsHistResultWork.SectionGuidNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));  // 拠点名称
                        wkSCMAnsHistResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));  // 得意先コード
                        wkSCMAnsHistResultWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));  // 得意先名称
                        wkSCMAnsHistResultWork.InquiryNumber = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INQUIRYNUMBERRF"));  // 問合せ番号
                        wkSCMAnsHistResultWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));  // 更新年月日
                        wkSCMAnsHistResultWork.UpdateTime = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATETIMERF"));  // 更新時間
                        wkSCMAnsHistResultWork.AnswerDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERDIVCDRF"));  // 回答区分
                        wkSCMAnsHistResultWork.JudgementDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JUDGEMENTDATERF"));  // 確定日
                        wkSCMAnsHistResultWork.InqOrdNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORDNOTERF"));  // 問合せ・発注備考
                        wkSCMAnsHistResultWork.InqEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQEMPLOYEECDRF"));  // 問合せ従業員コード
                        wkSCMAnsHistResultWork.InqEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQEMPLOYEENMRF"));  // 問合せ従業員名称
                        wkSCMAnsHistResultWork.AnsEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSEMPLOYEECDRF"));  // 回答従業員コード
                        wkSCMAnsHistResultWork.AnsEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSEMPLOYEENMRF"));  // 回答従業員名称
                        wkSCMAnsHistResultWork.InquiryDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQUIRYDATERF"));  // 問合せ日
                        wkSCMAnsHistResultWork.NumberPlate1Code = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE1CODERF"));  // 陸運事務所番号
                        wkSCMAnsHistResultWork.NumberPlate1Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE1NAMERF"));  // 陸運事務局名称
                        wkSCMAnsHistResultWork.NumberPlate2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE2RF"));  // 車両登録番号（種別）
                        wkSCMAnsHistResultWork.NumberPlate3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE3RF"));  // 車両登録番号（カナ）
                        wkSCMAnsHistResultWork.NumberPlate4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE4RF"));  // 車両登録番号（プレート番号）
                        wkSCMAnsHistResultWork.ModelDesignationNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));  // 型式指定番号
                        wkSCMAnsHistResultWork.CategoryNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));  // 類別番号
                        wkSCMAnsHistResultWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));  // メーカーコード
                        wkSCMAnsHistResultWork.CarMakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARMAKERNAMERF"));  // メーカー名称
                        wkSCMAnsHistResultWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));  // 車種コード
                        wkSCMAnsHistResultWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));  // 車種サブコード
                        wkSCMAnsHistResultWork.ModelName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELNAMERF"));  // 車種名
                        wkSCMAnsHistResultWork.CarInspectCertModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARINSPECTCERTMODELRF"));  // 車検証型式
                        wkSCMAnsHistResultWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));  // 型式（フル型）
                        wkSCMAnsHistResultWork.FrameNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMENORF"));  // 車台番号
                        wkSCMAnsHistResultWork.FrameModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMEMODELRF"));  // 車台型式
                        wkSCMAnsHistResultWork.ChassisNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHASSISNORF"));  // シャシーNo
                        wkSCMAnsHistResultWork.CarProperNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARPROPERNORF"));  // 車両固有番号
                        wkSCMAnsHistResultWork.ProduceTypeOfYearNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRODUCETYPEOFYEARNUMRF"));  // 生産年式（NUMタイプ）
                        wkSCMAnsHistResultWork.Comment = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMMENTRF"));  // コメント
                        wkSCMAnsHistResultWork.RpColorCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RPCOLORCODERF"));  // リペアカラーコード
                        wkSCMAnsHistResultWork.ColorName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORNAME1RF"));  // カラー名称1
                        wkSCMAnsHistResultWork.TrimCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMCODERF"));  // トリムコード
                        wkSCMAnsHistResultWork.TrimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMNAMERF"));  // トリム名称
                        wkSCMAnsHistResultWork.Mileage = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MILEAGERF"));  // 車両走行距離
                        wkSCMAnsHistResultWork.EquipObj = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("EQUIPOBJRF"));  // 装備オブジェクト
                        if (wkSCMAnsHistResultWork.EquipObj == null)
                        {
                            wkSCMAnsHistResultWork.EquipObj = new Byte[0];
                        }
                        wkSCMAnsHistResultWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAMPAIGNCODERF"));  // キャンペーンコード
                        wkSCMAnsHistResultWork.CampaignName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CAMPAIGNNAMERF"));  // キャンペーン名称
                        wkSCMAnsHistResultWork.SalesTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXINCRF"));  // 売上伝票合計（税込み）
                        wkSCMAnsHistResultWork.SalesSubtotalTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXRF"));  // 売上小計（税）
                        wkSCMAnsHistResultWork.InqOrdAnsDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQORDANSDIVCDRF"));  // 問発・回答種別
                        wkSCMAnsHistResultWork.ReceiveDateTime = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RECEIVEDATETIMERF"));  // 受信日時
                        // 2009.08.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        wkSCMAnsHistResultWork.AnswerCreateDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERCREATEDIVRF"));  // 回答作成区分
                        // 2009.08.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        wkSCMAnsHistResultWork.InqRowNumber = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQROWNUMBERRF"));  // 問合せ行番号
                        wkSCMAnsHistResultWork.InqRowNumDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQROWNUMDERIVEDNORF"));  // 問合せ行番号枝番
                        wkSCMAnsHistResultWork.GoodsDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSDIVCDRF"));  // 商品種別
                        wkSCMAnsHistResultWork.RecyclePrtKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECYCLEPRTKINDCODERF"));  // リサイクル部品種別
                        wkSCMAnsHistResultWork.RecyclePrtKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECYCLEPRTKINDNAMERF"));  // リサイクル部品種別名称
                        wkSCMAnsHistResultWork.DeliveredGoodsDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVRF"));  // 納品区分
                        wkSCMAnsHistResultWork.HandleDivCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("HANDLEDIVCODERF"));  // 取扱区分
                        wkSCMAnsHistResultWork.GoodsShape = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSSHAPERF"));  // 商品形態
                        wkSCMAnsHistResultWork.DelivrdGdsConfCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIVRDGDSCONFCDRF"));  // 納品確認区分
                        wkSCMAnsHistResultWork.DeliGdsCmpltDueDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DELIGDSCMPLTDUEDATERF"));  // 納品完了予定日
                        wkSCMAnsHistResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));  // BL商品コード
                        wkSCMAnsHistResultWork.BLGoodsDrCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSDRCODERF"));  // BL商品コード枝番
                        wkSCMAnsHistResultWork.AnsGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSGOODSNAMERF")); // 回答商品名
                        wkSCMAnsHistResultWork.InqGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQGOODSNAMERF")); // 純正商品名
                        //wkSCMAnsHistResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));  // 商品名称

                        wkSCMAnsHistResultWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF"));  // 発注数
                        wkSCMAnsHistResultWork.DeliveredGoodsCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("DELIVEREDGOODSCOUNTRF"));  // 納品数
                        wkSCMAnsHistResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));  // 商品番号
                        wkSCMAnsHistResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));  // 商品メーカーコード
                        wkSCMAnsHistResultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));  // メーカー名称
                        wkSCMAnsHistResultWork.PureGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PUREGOODSMAKERCDRF"));  // 純正商品メーカーコード
                        wkSCMAnsHistResultWork.PureMakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PUREMAKERNAMERF"));  // 純正商品メーカー名称
                        //wkSCMAnsHistResultWork.PureGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PUREGOODSNORF"));  // 純正商品番号

                        wkSCMAnsHistResultWork.InqPureGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQPUREGOODSNORF"));  // 純正商品番号
                        wkSCMAnsHistResultWork.AnsPureGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSPUREGOODSNORF"));  // 純正商品番号
                        
                        //wkSCMAnsHistResultWork.PureGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PUREGOODSNAMERF"));  // 純正商品名称
                        wkSCMAnsHistResultWork.AnsPureGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSPUREGOODSNAMERF"));  // 回答純正商品名称
                        wkSCMAnsHistResultWork.InqPureGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQPUREGOODSNAMERF"));  // 問発純正商品名称

                        wkSCMAnsHistResultWork.ListPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LISTPRICERF"));  // 定価
                        wkSCMAnsHistResultWork.UnitPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("UNITPRICERF"));  // 単価
                        wkSCMAnsHistResultWork.GoodsAddInfo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSADDINFORF"));  // 商品補足情報
                        wkSCMAnsHistResultWork.RoughRrofit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ROUGHRROFITRF"));  // 粗利額
                        wkSCMAnsHistResultWork.RoughRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ROUGHRATERF"));  // 粗利率
                        wkSCMAnsHistResultWork.AnswerLimitDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERLIMITDATERF"));  // 回答期限
                        wkSCMAnsHistResultWork.CommentDtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMMENTDTLRF"));  // 備考(明細)
                        wkSCMAnsHistResultWork.ShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHELFNORF"));  // 棚番
                        wkSCMAnsHistResultWork.AdditionalDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDITIONALDIVCDRF"));  // 追加区分
                        wkSCMAnsHistResultWork.CorrectDivCD = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CORRECTDIVCDRF"));  // 訂正区分
                        wkSCMAnsHistResultWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));  // 受注ステータス
                        wkSCMAnsHistResultWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));  // 売上伝票番号
                        wkSCMAnsHistResultWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));  // 売上行番号
                        wkSCMAnsHistResultWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKDIVRF"));  // 在庫区分
                        wkSCMAnsHistResultWork.InqOrdDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQORDDIVCDRF"));  // 問合せ・発注種別
                        wkSCMAnsHistResultWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));  // 表示順位
                        wkSCMAnsHistResultWork.AnswerDeliveryDate = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERDELIVERYDATERF"));  // 回答納期
                        
                        al.Add(wkSCMAnsHistResultWork);
                    }
                    // キー情報があるか
                    if (SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IUPDATEDATERF")) != 0)
                    {
                        SCMAnsHistResultWork wkSCMAnsHistResultWork = new SCMAnsHistResultWork();

                        wkSCMAnsHistResultWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHEREPCDRF"));  // 問合せ先企業コード
                        wkSCMAnsHistResultWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHERSECCDRF"));  // 問合せ先拠点コード
                        wkSCMAnsHistResultWork.SectionGuidNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));  // 拠点名称
                        wkSCMAnsHistResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));  // 得意先コード
                        wkSCMAnsHistResultWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));  // 得意先名称
                        wkSCMAnsHistResultWork.InquiryNumber = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INQUIRYNUMBERRF"));  // 問合せ番号
                        wkSCMAnsHistResultWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));  // 更新年月日
                        wkSCMAnsHistResultWork.UpdateTime = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATETIMERF"));  // 更新時間
                        wkSCMAnsHistResultWork.AnswerDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERDIVCDRF"));  // 回答区分
                        wkSCMAnsHistResultWork.JudgementDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JUDGEMENTDATERF"));  // 確定日
                        wkSCMAnsHistResultWork.InqOrdNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORDNOTERF"));  // 問合せ・発注備考
                        wkSCMAnsHistResultWork.InqEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQEMPLOYEECDRF"));  // 問合せ従業員コード
                        wkSCMAnsHistResultWork.InqEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQEMPLOYEENMRF"));  // 問合せ従業員名称
                        wkSCMAnsHistResultWork.AnsEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSEMPLOYEECDRF"));  // 回答従業員コード
                        wkSCMAnsHistResultWork.AnsEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSEMPLOYEENMRF"));  // 回答従業員名称
                        wkSCMAnsHistResultWork.InquiryDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQUIRYDATERF"));  // 問合せ日
                        wkSCMAnsHistResultWork.NumberPlate1Code = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE1CODERF"));  // 陸運事務所番号
                        wkSCMAnsHistResultWork.NumberPlate1Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE1NAMERF"));  // 陸運事務局名称
                        wkSCMAnsHistResultWork.NumberPlate2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE2RF"));  // 車両登録番号（種別）
                        wkSCMAnsHistResultWork.NumberPlate3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE3RF"));  // 車両登録番号（カナ）
                        wkSCMAnsHistResultWork.NumberPlate4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE4RF"));  // 車両登録番号（プレート番号）
                        wkSCMAnsHistResultWork.ModelDesignationNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));  // 型式指定番号
                        wkSCMAnsHistResultWork.CategoryNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));  // 類別番号
                        wkSCMAnsHistResultWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));  // メーカーコード
                        wkSCMAnsHistResultWork.CarMakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARMAKERNAMERF"));  // メーカー名称
                        wkSCMAnsHistResultWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));  // 車種コード
                        wkSCMAnsHistResultWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));  // 車種サブコード
                        wkSCMAnsHistResultWork.ModelName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELNAMERF"));  // 車種名
                        wkSCMAnsHistResultWork.CarInspectCertModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARINSPECTCERTMODELRF"));  // 車検証型式
                        wkSCMAnsHistResultWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));  // 型式（フル型）
                        wkSCMAnsHistResultWork.FrameNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMENORF"));  // 車台番号
                        wkSCMAnsHistResultWork.FrameModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMEMODELRF"));  // 車台型式
                        wkSCMAnsHistResultWork.ChassisNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHASSISNORF"));  // シャシーNo
                        wkSCMAnsHistResultWork.CarProperNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARPROPERNORF"));  // 車両固有番号
                        wkSCMAnsHistResultWork.ProduceTypeOfYearNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRODUCETYPEOFYEARNUMRF"));  // 生産年式（NUMタイプ）
                        wkSCMAnsHistResultWork.Comment = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMMENTRF"));  // コメント
                        wkSCMAnsHistResultWork.RpColorCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RPCOLORCODERF"));  // リペアカラーコード
                        wkSCMAnsHistResultWork.ColorName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORNAME1RF"));  // カラー名称1
                        wkSCMAnsHistResultWork.TrimCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMCODERF"));  // トリムコード
                        wkSCMAnsHistResultWork.TrimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMNAMERF"));  // トリム名称
                        wkSCMAnsHistResultWork.Mileage = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MILEAGERF"));  // 車両走行距離
                        wkSCMAnsHistResultWork.EquipObj = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("EQUIPOBJRF"));  // 装備オブジェクト
                        if (wkSCMAnsHistResultWork.EquipObj == null)
                        {
                            wkSCMAnsHistResultWork.EquipObj = new Byte[0];
                        }
                        wkSCMAnsHistResultWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAMPAIGNCODERF"));  // キャンペーンコード
                        wkSCMAnsHistResultWork.CampaignName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CAMPAIGNNAMERF"));  // キャンペーン名称
                        wkSCMAnsHistResultWork.SalesTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXINCRF"));  // 売上伝票合計（税込み）
                        wkSCMAnsHistResultWork.SalesSubtotalTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXRF"));  // 売上小計（税）
                        wkSCMAnsHistResultWork.InqOrdAnsDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQORDANSDIVCDRF"));  // 問発・回答種別
                        wkSCMAnsHistResultWork.ReceiveDateTime = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RECEIVEDATETIMERF"));  // 受信日時
                        // 2009.08.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        wkSCMAnsHistResultWork.AnswerCreateDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERCREATEDIVRF"));  // 回答作成区分
                        // 2009.08.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                        wkSCMAnsHistResultWork.InqRowNumber = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IINQROWNUMBERRF"));  // 問合せ行番号
                        wkSCMAnsHistResultWork.InqRowNumDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IINQROWNUMDERIVEDNORF"));  // 問合せ行番号枝番
                        wkSCMAnsHistResultWork.GoodsDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IGOODSDIVCDRF"));  // 商品種別
                        wkSCMAnsHistResultWork.RecyclePrtKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IRECYCLEPRTKINDCODERF"));  // リサイクル部品種別
                        wkSCMAnsHistResultWork.RecyclePrtKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IRECYCLEPRTKINDNAMERF"));  // リサイクル部品種別名称
                        wkSCMAnsHistResultWork.DeliveredGoodsDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IDELIVRDGDSCONFCDRF"));  // 納品区分
                        wkSCMAnsHistResultWork.HandleDivCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IHANDLEDIVCODERF"));  // 取扱区分
                        wkSCMAnsHistResultWork.GoodsShape = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IGOODSSHAPERF"));  // 商品形態
                        wkSCMAnsHistResultWork.DelivrdGdsConfCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IDELIVRDGDSCONFCDRF"));  // 納品確認区分
                        wkSCMAnsHistResultWork.DeliGdsCmpltDueDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IDELIGDSCMPLTDUEDATERF"));  // 納品完了予定日
                        wkSCMAnsHistResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IBLGOODSCODERF"));  // BL商品コード
                        wkSCMAnsHistResultWork.BLGoodsDrCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IBLGOODSDRCODERF"));  // BL商品コード枝番
                        //wkSCMAnsHistResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IGOODSNAMERF"));  // 商品名称
                        wkSCMAnsHistResultWork.InqGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IINQGOODSNAMERF"));
                        wkSCMAnsHistResultWork.AnsGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IANSGOODSNAMERF"));
                        wkSCMAnsHistResultWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ISALESORDERCOUNTRF"));  // 発注数
                        wkSCMAnsHistResultWork.DeliveredGoodsCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IDELIVEREDGOODSCOUNTRF"));  // 納品数
                        wkSCMAnsHistResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IGOODSNORF"));  // 商品番号
                        wkSCMAnsHistResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IGOODSMAKERCDRF"));  // 商品メーカーコード
                        wkSCMAnsHistResultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IMAKERNAMERF"));  // メーカー名称
                        wkSCMAnsHistResultWork.PureGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IPUREGOODSMAKERCDRF"));  // 純正商品メーカーコード
                        wkSCMAnsHistResultWork.PureMakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IPUREMAKERNAMERF"));  // 純正商品メーカー名称
                        //wkSCMAnsHistResultWork.PureGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IPUREGOODSNORF"));  // 純正商品番号
                        wkSCMAnsHistResultWork.InqPureGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IIPUREGOODSNORF")); // 純正問発商品番号
                        wkSCMAnsHistResultWork.AnsPureGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IAPUREGOODSNORF")); // 純正回答商品番号
                        
                        //wkSCMAnsHistResultWork.PureGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IPUREGOODSNAMERF"));  // 純正商品名称
                        wkSCMAnsHistResultWork.InqPureGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IIPUREGOODSNAMERF")); // 問発純正商品名称
                        wkSCMAnsHistResultWork.AnsPureGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IAPUREGOODSNAMERF")); // 回答純正商品名称
                        
                        wkSCMAnsHistResultWork.ListPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ILISTPRICERF"));  // 定価
                        wkSCMAnsHistResultWork.UnitPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("IUNITPRICERF"));  // 単価
                        wkSCMAnsHistResultWork.GoodsAddInfo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IGOODSADDINFORF"));  // 商品補足情報
                        wkSCMAnsHistResultWork.RoughRrofit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("IROUGHRROFITRF"));  // 粗利額
                        wkSCMAnsHistResultWork.RoughRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IROUGHRATERF"));  // 粗利率
                        wkSCMAnsHistResultWork.AnswerLimitDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IANSWERLIMITDATERF"));  // 回答期限
                        wkSCMAnsHistResultWork.CommentDtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ICOMMENTDTLRF"));  // 備考(明細)
                        wkSCMAnsHistResultWork.ShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ISHELFNORF"));  // 棚番
                        wkSCMAnsHistResultWork.AdditionalDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IADDITIONALDIVCDRF"));  // 追加区分
                        wkSCMAnsHistResultWork.CorrectDivCD = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ICORRECTDIVCDRF"));  // 訂正区分
                        //wkSCMAnsHistResultWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IACPTANODRSTATUSRF"));  // 受注ステータス
                        //wkSCMAnsHistResultWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ISALESSLIPNUMRF"));  // 売上伝票番号
                        wkSCMAnsHistResultWork.InqOrdDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IINQORDDIVCDRF"));  // 問合せ・発注種別
                        wkSCMAnsHistResultWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IDISPLAYORDERRF"));  // 表示順位
                        wkSCMAnsHistResultWork.AnswerDeliveryDate = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IANSWERDELIVERYDATERF"));  // 回答納期
                       
                        al.Add(wkSCMAnsHistResultWork);
                    }
                    #endregion



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
        private string MakeWhereString(ref SqlCommand sqlCommand, SCMAnsHistOrderWork scmAnsHistOrderWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = "WHERE" + Environment.NewLine;
            string retst = "";

            // 問合せ先企業コード 
            retstring += " SCM.INQOTHEREPCDRF=@INQOTHEREPCD" + Environment.NewLine;
            SqlParameter paraInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
            paraInqOtherEpCd.Value = SqlDataMediator.SqlSetString(scmAnsHistOrderWork.InqOtherEpCd);

            // 回答区分
            if (scmAnsHistOrderWork.AnswerDivCd != null)
            {
                retst = "";
                foreach (int str in scmAnsHistOrderWork.AnswerDivCd)
                {
                    if (retst != "") retst += ",";
                    retst += "'" + str + "'";
                }
                if (retst != "")
                {
                    retstring += "AND SCM.ANSWERDIVCDRF IN (" + retst + ") ";
                }
            }

            // 問合せ日
            if (scmAnsHistOrderWork.St_InquiryDate != 0)
            {
                retstring += " AND SCM.INQUIRYDATERF>=@STINQUIRYDATE" + Environment.NewLine;
                SqlParameter paraStInquiryDate = sqlCommand.Parameters.Add("@STINQUIRYDATE", SqlDbType.Int);
                paraStInquiryDate.Value = SqlDataMediator.SqlSetInt32(scmAnsHistOrderWork.St_InquiryDate);
            }
            if (scmAnsHistOrderWork.Ed_InquiryDate != 0)
            {
                retstring += " AND SCM.INQUIRYDATERF<=@EDINQUIRYDATE" + Environment.NewLine;
                SqlParameter paraEdInquiryDate = sqlCommand.Parameters.Add("@EDINQUIRYDATE", SqlDbType.Int);
                paraEdInquiryDate.Value = SqlDataMediator.SqlSetInt32(scmAnsHistOrderWork.Ed_InquiryDate);
            }

            // 問合わせ先拠点コード
            if (scmAnsHistOrderWork.InqOtherSecCd != "")
            {
                retstring += " AND SCM.INQOTHERSECCDRF=@INQOTHERSECCD" + Environment.NewLine;
                SqlParameter paraInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
                paraInqOtherSecCd.Value = SqlDataMediator.SqlSetString(scmAnsHistOrderWork.InqOtherSecCd);
            }

            // 得意先コード
            if (scmAnsHistOrderWork.St_CustomerCode != 0)
            {
                retstring += " AND SCM.CUSTOMERCODERF>=@STCUSTOMERCODE" + Environment.NewLine;
                SqlParameter paraStCustomerCode = sqlCommand.Parameters.Add("@STCUSTOMERCODE", SqlDbType.Int);
                paraStCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmAnsHistOrderWork.St_CustomerCode);
            }
            if (scmAnsHistOrderWork.Ed_CustomerCode != 0)
            {
                retstring += " AND SCM.CUSTOMERCODERF<=@EDCUSTOMERCODE" + Environment.NewLine;
                SqlParameter paraEdCustomerCode = sqlCommand.Parameters.Add("@EDCUSTOMERCODE", SqlDbType.Int);
                paraEdCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmAnsHistOrderWork.Ed_CustomerCode);
            }

            // 回答方法
            if (scmAnsHistOrderWork.AwnserMethod != null)
            {
                retst = "";
                foreach (int str in scmAnsHistOrderWork.AwnserMethod)
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
            if (scmAnsHistOrderWork.St_SalesSlipNum != "")
            {
                retstring += " AND SCM.SALESSLIPNUMRF>=@STSALESSLIPNUM" + Environment.NewLine;
                SqlParameter paraStSalesSlipNum = sqlCommand.Parameters.Add("@STSALESSLIPNUM", SqlDbType.NChar);
                paraStSalesSlipNum.Value = SqlDataMediator.SqlSetString(scmAnsHistOrderWork.St_SalesSlipNum);
            }
            if (scmAnsHistOrderWork.Ed_SalesSlipNum != "")
            {
                retstring += " AND SCM.SALESSLIPNUMRF<=@EDSALESSLIPNUM" + Environment.NewLine;
                SqlParameter paraEdSalesSlipNum = sqlCommand.Parameters.Add("@EDSALESSLIPNUM", SqlDbType.NChar);
                paraEdSalesSlipNum.Value = SqlDataMediator.SqlSetString(scmAnsHistOrderWork.Ed_SalesSlipNum);
            }

            // 受注ステータス
            if (scmAnsHistOrderWork.AcptAnOdrStatus != null)
            {
                retst = "";
                foreach (int str in scmAnsHistOrderWork.AcptAnOdrStatus)
                {
                    if (retst != "") retst += ",";
                    retst += "'" + str + "'";
                }
                if (retst != "")
                {
                    retstring += "AND SCM.ACPTANODRSTATUSRF IN (" + retst + ") ";
                }
            }

            // 問合せ番号
            if (scmAnsHistOrderWork.St_InquiryNumber != 0)
            {
                retstring += " AND SCM.INQUIRYNUMBERRF>=@STINQUIRYNUMBER" + Environment.NewLine;
                SqlParameter paraStInquiryNumber = sqlCommand.Parameters.Add("@STINQUIRYNUMBER", SqlDbType.BigInt);
                paraStInquiryNumber.Value = SqlDataMediator.SqlSetInt64(scmAnsHistOrderWork.St_InquiryNumber);
            }
            if (scmAnsHistOrderWork.Ed_InquiryNumber != 0)
            {
                retstring += " AND SCM.INQUIRYNUMBERRF<=@EDINQUIRYNUMBER" + Environment.NewLine;
                SqlParameter paraEdInquiryNumber = sqlCommand.Parameters.Add("@EDINQUIRYNUMBER", SqlDbType.BigInt);
                paraEdInquiryNumber.Value = SqlDataMediator.SqlSetInt64(scmAnsHistOrderWork.Ed_InquiryNumber);
            }

            // 車両登録番号(プレート番号)
            if (scmAnsHistOrderWork.NumberPlate4 != 0)
            {
                retstring += " AND CAR.NUMBERPLATE4RF=@NUMBERPLATE4" + Environment.NewLine;
                SqlParameter paraNumberPlate4 = sqlCommand.Parameters.Add("@NUMBERPLATE4", SqlDbType.Int);
                paraNumberPlate4.Value = SqlDataMediator.SqlSetInt32(scmAnsHistOrderWork.NumberPlate4);
            }

            // 型式
            if (scmAnsHistOrderWork.FullModel != "")
            {
                retstring += " AND CAR.FULLMODELRF LIKE @FULLMODEL" + Environment.NewLine;

                SqlParameter paraFullModel = sqlCommand.Parameters.Add("@FULLMODEL", SqlDbType.NChar);
                //前方一致検索の場合
                if (scmAnsHistOrderWork.SerchTypeModelCd == 1) scmAnsHistOrderWork.FullModel = scmAnsHistOrderWork.FullModel + "%";
                //後方一致検索の場合
                if (scmAnsHistOrderWork.SerchTypeModelCd == 2) scmAnsHistOrderWork.FullModel = "%" + scmAnsHistOrderWork.FullModel;
                //曖昧検索の場合
                if (scmAnsHistOrderWork.SerchTypeModelCd == 3) scmAnsHistOrderWork.FullModel = "%" + scmAnsHistOrderWork.FullModel + "%";

                paraFullModel.Value = SqlDataMediator.SqlSetString(scmAnsHistOrderWork.FullModel);
            }

            // メーカーコード(車両情報)
            if (scmAnsHistOrderWork.CarMakerCode != 0)
            {
                retstring += " AND CAR.MAKERCODERF=@MAKERCODE" + Environment.NewLine;
                SqlParameter paraCarMakerCode = sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int);
                paraCarMakerCode.Value = SqlDataMediator.SqlSetInt32(scmAnsHistOrderWork.CarMakerCode);
            }

            // 車種
            if (scmAnsHistOrderWork.ModelCode != 0)
            {
                retstring += " AND CAR.MODELCODERF=@MODELCODE" + Environment.NewLine;
                SqlParameter paraModelCode = sqlCommand.Parameters.Add("@MODELCODE", SqlDbType.Int);
                paraModelCode.Value = SqlDataMediator.SqlSetInt32(scmAnsHistOrderWork.ModelCode);
            }

            // 2009.08.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // 車種サブコード
            if (scmAnsHistOrderWork.ModelSubCode != 0)
            {
                retstring += " AND CAR.MODELSUBCODERF=@MODELSUBCODE" + Environment.NewLine;
                SqlParameter paraModelSubCode = sqlCommand.Parameters.Add("@MODELSUBCODE", SqlDbType.Int);
                paraModelSubCode.Value = SqlDataMediator.SqlSetInt32(scmAnsHistOrderWork.ModelSubCode);
            }
            // 2009.08.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // メーカーコード
            if (scmAnsHistOrderWork.GoodsMakerCd != 0)
            {
                retstring += " AND ANS.GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(scmAnsHistOrderWork.GoodsMakerCd);
            }

            // BLコード
            if (scmAnsHistOrderWork.BLGoodsCode != 0)
            {
                retstring += " AND ANS.BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(scmAnsHistOrderWork.BLGoodsCode);
            }

            // 品番
            if (scmAnsHistOrderWork.GoodsNo != "")
            {
                retstring += " AND ANS.GOODSNORF LIKE @GOODSNO" + Environment.NewLine;

                SqlParameter paraFullModel = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                //前方一致検索の場合
                if (scmAnsHistOrderWork.SerchTypeGoodsNo == 1) scmAnsHistOrderWork.GoodsNo = scmAnsHistOrderWork.GoodsNo + "%";
                //後方一致検索の場合
                if (scmAnsHistOrderWork.SerchTypeGoodsNo == 2) scmAnsHistOrderWork.GoodsNo = "%" + scmAnsHistOrderWork.GoodsNo;
                //曖昧検索の場合
                if (scmAnsHistOrderWork.SerchTypeGoodsNo == 3) scmAnsHistOrderWork.GoodsNo = "%" + scmAnsHistOrderWork.GoodsNo + "%";

                // 2009.08.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //paraFullModel.Value = SqlDataMediator.SqlSetString(scmAnsHistOrderWork.FullModel);
                paraFullModel.Value = SqlDataMediator.SqlSetString(scmAnsHistOrderWork.GoodsNo);
                // 2009.08.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            }

            // 純正品番
            if (scmAnsHistOrderWork.PureGoodsNo != "")
            {
                retstring += " AND ANS.ANSPUREGOODSNORF LIKE @PUREGOODSNO" + Environment.NewLine;

                SqlParameter paraFullModel = sqlCommand.Parameters.Add("@PUREGOODSNO", SqlDbType.NChar);
                //前方一致検索の場合
                if (scmAnsHistOrderWork.SerchTypePureGoodsNo == 1) scmAnsHistOrderWork.PureGoodsNo = scmAnsHistOrderWork.PureGoodsNo + "%";
                //後方一致検索の場合
                if (scmAnsHistOrderWork.SerchTypePureGoodsNo == 2) scmAnsHistOrderWork.PureGoodsNo = "%" + scmAnsHistOrderWork.PureGoodsNo;
                //曖昧検索の場合
                if (scmAnsHistOrderWork.SerchTypePureGoodsNo == 3) scmAnsHistOrderWork.PureGoodsNo = "%" + scmAnsHistOrderWork.PureGoodsNo + "%";

                // 2009.08.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //paraFullModel.Value = SqlDataMediator.SqlSetString(scmAnsHistOrderWork.FullModel);
                paraFullModel.Value = SqlDataMediator.SqlSetString(scmAnsHistOrderWork.PureGoodsNo);
                // 2009.08.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            }
            // 問合せ・発注種別
            if (scmAnsHistOrderWork.InqOrdDivCd != null)
            {
                retst = "";
                foreach (int str in scmAnsHistOrderWork.InqOrdDivCd)
                {
                    if (retst != "") retst += ",";
                    retst += "'" + str + "'";
                }
                if (retst != "")
                {
                    retstring += "AND SCM.INQORDDIVCDRF IN (" + retst + ") ";
                }
            }
            return retstring;
            #endregion
        }
    }
}

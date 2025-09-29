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
    /// ���㗚���񓚏Ɖ�DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���㗚���񓚏Ɖ�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30350 �N�� ����</br>
    /// <br>Date       : 2009.05.19</br>
    /// <br></br>
    /// <br>Update Note: MANTIS 14155 ���o���ʂɉ񓚍쐬�敪�ǉ��B
    /// <br>           :        14157 �e�퍀�ڂ𐳏�擾�ł���悤�ɕύX</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2009.08.25</br>
    /// </remarks>
    [Serializable]
    public class SCMAnsHistDB : RemoteDB, ISCMAnsHistDB
    {
        /// <summary>
        /// ���㗚���񓚏Ɖ�DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2009.05.19</br>
        /// </remarks>
        public SCMAnsHistDB()
            :
        base("PMSCM04107D", "Broadleaf.Application.Remoting.ParamData.SCMAnsHistResultWork", "SCMACODRDATARF") //���N���X�̃R���X�g���N�^
        {
        }

        #region ���㗚���񓚏Ɖ�

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̔��㗚���񓚏Ɖ��LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="supplierUnmResultWork">��������</param>
        /// <param name="supplierUnmOrderCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h��SCM�₢���킹�ꗗLIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 30350 �N�� ����</br>
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
        /// �w�肳�ꂽ��ƃR�[�h��SCM�₢���킹�ꗗ��LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="supplierSendErResultWork">��������</param>
        /// <param name="_supplierSendErOrderCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h��SCM�₢���킹�ꗗ��LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2009.05.14</br>
        private int SearchProc(out object scmAnsHistResultWork, SCMAnsHistOrderWork scmAnsHistOrderWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            scmAnsHistResultWork = null;

            ArrayList al = new ArrayList();   //���׏�񒊏o����

            try
            {
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                // �`�[��񒊏o
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
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="al">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_supplierSendErOrderCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
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

                #region Select���쐬

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


  
                //WHERE���̍쐬
                selectTxt += MakeWhereString(ref sqlCommand, scmAnsHistOrderWork, logicalMode);

                sqlCommand.CommandText = selectTxt;

                #endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    //�L�[��񂪂��邩
                    if (SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUPDATEDATERF")) != 0)
                    {
                        SCMAnsHistResultWork wkSCMAnsHistResultWork = new SCMAnsHistResultWork();

                        wkSCMAnsHistResultWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHEREPCDRF"));  // �⍇�����ƃR�[�h
                        wkSCMAnsHistResultWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHERSECCDRF"));  // �⍇���拒�_�R�[�h
                        wkSCMAnsHistResultWork.SectionGuidNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));  // ���_����
                        wkSCMAnsHistResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));  // ���Ӑ�R�[�h
                        wkSCMAnsHistResultWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));  // ���Ӑ於��
                        wkSCMAnsHistResultWork.InquiryNumber = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INQUIRYNUMBERRF"));  // �⍇���ԍ�
                        wkSCMAnsHistResultWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));  // �X�V�N����
                        wkSCMAnsHistResultWork.UpdateTime = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATETIMERF"));  // �X�V����
                        wkSCMAnsHistResultWork.AnswerDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERDIVCDRF"));  // �񓚋敪
                        wkSCMAnsHistResultWork.JudgementDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JUDGEMENTDATERF"));  // �m���
                        wkSCMAnsHistResultWork.InqOrdNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORDNOTERF"));  // �⍇���E�������l
                        wkSCMAnsHistResultWork.InqEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQEMPLOYEECDRF"));  // �⍇���]�ƈ��R�[�h
                        wkSCMAnsHistResultWork.InqEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQEMPLOYEENMRF"));  // �⍇���]�ƈ�����
                        wkSCMAnsHistResultWork.AnsEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSEMPLOYEECDRF"));  // �񓚏]�ƈ��R�[�h
                        wkSCMAnsHistResultWork.AnsEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSEMPLOYEENMRF"));  // �񓚏]�ƈ�����
                        wkSCMAnsHistResultWork.InquiryDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQUIRYDATERF"));  // �⍇����
                        wkSCMAnsHistResultWork.NumberPlate1Code = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE1CODERF"));  // ���^�������ԍ�
                        wkSCMAnsHistResultWork.NumberPlate1Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE1NAMERF"));  // ���^�����ǖ���
                        wkSCMAnsHistResultWork.NumberPlate2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE2RF"));  // �ԗ��o�^�ԍ��i��ʁj
                        wkSCMAnsHistResultWork.NumberPlate3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE3RF"));  // �ԗ��o�^�ԍ��i�J�i�j
                        wkSCMAnsHistResultWork.NumberPlate4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE4RF"));  // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                        wkSCMAnsHistResultWork.ModelDesignationNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));  // �^���w��ԍ�
                        wkSCMAnsHistResultWork.CategoryNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));  // �ޕʔԍ�
                        wkSCMAnsHistResultWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));  // ���[�J�[�R�[�h
                        wkSCMAnsHistResultWork.CarMakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARMAKERNAMERF"));  // ���[�J�[����
                        wkSCMAnsHistResultWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));  // �Ԏ�R�[�h
                        wkSCMAnsHistResultWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));  // �Ԏ�T�u�R�[�h
                        wkSCMAnsHistResultWork.ModelName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELNAMERF"));  // �Ԏ햼
                        wkSCMAnsHistResultWork.CarInspectCertModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARINSPECTCERTMODELRF"));  // �Ԍ��،^��
                        wkSCMAnsHistResultWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));  // �^���i�t���^�j
                        wkSCMAnsHistResultWork.FrameNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMENORF"));  // �ԑ�ԍ�
                        wkSCMAnsHistResultWork.FrameModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMEMODELRF"));  // �ԑ�^��
                        wkSCMAnsHistResultWork.ChassisNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHASSISNORF"));  // �V���V�[No
                        wkSCMAnsHistResultWork.CarProperNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARPROPERNORF"));  // �ԗ��ŗL�ԍ�
                        wkSCMAnsHistResultWork.ProduceTypeOfYearNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRODUCETYPEOFYEARNUMRF"));  // ���Y�N���iNUM�^�C�v�j
                        wkSCMAnsHistResultWork.Comment = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMMENTRF"));  // �R�����g
                        wkSCMAnsHistResultWork.RpColorCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RPCOLORCODERF"));  // ���y�A�J���[�R�[�h
                        wkSCMAnsHistResultWork.ColorName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORNAME1RF"));  // �J���[����1
                        wkSCMAnsHistResultWork.TrimCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMCODERF"));  // �g�����R�[�h
                        wkSCMAnsHistResultWork.TrimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMNAMERF"));  // �g��������
                        wkSCMAnsHistResultWork.Mileage = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MILEAGERF"));  // �ԗ����s����
                        wkSCMAnsHistResultWork.EquipObj = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("EQUIPOBJRF"));  // �����I�u�W�F�N�g
                        if (wkSCMAnsHistResultWork.EquipObj == null)
                        {
                            wkSCMAnsHistResultWork.EquipObj = new Byte[0];
                        }
                        wkSCMAnsHistResultWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAMPAIGNCODERF"));  // �L�����y�[���R�[�h
                        wkSCMAnsHistResultWork.CampaignName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CAMPAIGNNAMERF"));  // �L�����y�[������
                        wkSCMAnsHistResultWork.SalesTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXINCRF"));  // ����`�[���v�i�ō��݁j
                        wkSCMAnsHistResultWork.SalesSubtotalTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXRF"));  // ���㏬�v�i�Łj
                        wkSCMAnsHistResultWork.InqOrdAnsDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQORDANSDIVCDRF"));  // �┭�E�񓚎��
                        wkSCMAnsHistResultWork.ReceiveDateTime = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RECEIVEDATETIMERF"));  // ��M����
                        // 2009.08.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        wkSCMAnsHistResultWork.AnswerCreateDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERCREATEDIVRF"));  // �񓚍쐬�敪
                        // 2009.08.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        wkSCMAnsHistResultWork.InqRowNumber = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQROWNUMBERRF"));  // �⍇���s�ԍ�
                        wkSCMAnsHistResultWork.InqRowNumDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQROWNUMDERIVEDNORF"));  // �⍇���s�ԍ��}��
                        wkSCMAnsHistResultWork.GoodsDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSDIVCDRF"));  // ���i���
                        wkSCMAnsHistResultWork.RecyclePrtKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECYCLEPRTKINDCODERF"));  // ���T�C�N�����i���
                        wkSCMAnsHistResultWork.RecyclePrtKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECYCLEPRTKINDNAMERF"));  // ���T�C�N�����i��ʖ���
                        wkSCMAnsHistResultWork.DeliveredGoodsDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVRF"));  // �[�i�敪
                        wkSCMAnsHistResultWork.HandleDivCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("HANDLEDIVCODERF"));  // �戵�敪
                        wkSCMAnsHistResultWork.GoodsShape = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSSHAPERF"));  // ���i�`��
                        wkSCMAnsHistResultWork.DelivrdGdsConfCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIVRDGDSCONFCDRF"));  // �[�i�m�F�敪
                        wkSCMAnsHistResultWork.DeliGdsCmpltDueDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DELIGDSCMPLTDUEDATERF"));  // �[�i�����\���
                        wkSCMAnsHistResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));  // BL���i�R�[�h
                        wkSCMAnsHistResultWork.BLGoodsDrCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSDRCODERF"));  // BL���i�R�[�h�}��
                        wkSCMAnsHistResultWork.AnsGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSGOODSNAMERF")); // �񓚏��i��
                        wkSCMAnsHistResultWork.InqGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQGOODSNAMERF")); // �������i��
                        //wkSCMAnsHistResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));  // ���i����

                        wkSCMAnsHistResultWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF"));  // ������
                        wkSCMAnsHistResultWork.DeliveredGoodsCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("DELIVEREDGOODSCOUNTRF"));  // �[�i��
                        wkSCMAnsHistResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));  // ���i�ԍ�
                        wkSCMAnsHistResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));  // ���i���[�J�[�R�[�h
                        wkSCMAnsHistResultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));  // ���[�J�[����
                        wkSCMAnsHistResultWork.PureGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PUREGOODSMAKERCDRF"));  // �������i���[�J�[�R�[�h
                        wkSCMAnsHistResultWork.PureMakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PUREMAKERNAMERF"));  // �������i���[�J�[����
                        //wkSCMAnsHistResultWork.PureGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PUREGOODSNORF"));  // �������i�ԍ�

                        wkSCMAnsHistResultWork.InqPureGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQPUREGOODSNORF"));  // �������i�ԍ�
                        wkSCMAnsHistResultWork.AnsPureGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSPUREGOODSNORF"));  // �������i�ԍ�
                        
                        //wkSCMAnsHistResultWork.PureGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PUREGOODSNAMERF"));  // �������i����
                        wkSCMAnsHistResultWork.AnsPureGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSPUREGOODSNAMERF"));  // �񓚏������i����
                        wkSCMAnsHistResultWork.InqPureGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQPUREGOODSNAMERF"));  // �┭�������i����

                        wkSCMAnsHistResultWork.ListPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LISTPRICERF"));  // �艿
                        wkSCMAnsHistResultWork.UnitPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("UNITPRICERF"));  // �P��
                        wkSCMAnsHistResultWork.GoodsAddInfo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSADDINFORF"));  // ���i�⑫���
                        wkSCMAnsHistResultWork.RoughRrofit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ROUGHRROFITRF"));  // �e���z
                        wkSCMAnsHistResultWork.RoughRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ROUGHRATERF"));  // �e����
                        wkSCMAnsHistResultWork.AnswerLimitDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERLIMITDATERF"));  // �񓚊���
                        wkSCMAnsHistResultWork.CommentDtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMMENTDTLRF"));  // ���l(����)
                        wkSCMAnsHistResultWork.ShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHELFNORF"));  // �I��
                        wkSCMAnsHistResultWork.AdditionalDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDITIONALDIVCDRF"));  // �ǉ��敪
                        wkSCMAnsHistResultWork.CorrectDivCD = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CORRECTDIVCDRF"));  // �����敪
                        wkSCMAnsHistResultWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));  // �󒍃X�e�[�^�X
                        wkSCMAnsHistResultWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));  // ����`�[�ԍ�
                        wkSCMAnsHistResultWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));  // ����s�ԍ�
                        wkSCMAnsHistResultWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKDIVRF"));  // �݌ɋ敪
                        wkSCMAnsHistResultWork.InqOrdDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQORDDIVCDRF"));  // �⍇���E�������
                        wkSCMAnsHistResultWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));  // �\������
                        wkSCMAnsHistResultWork.AnswerDeliveryDate = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERDELIVERYDATERF"));  // �񓚔[��
                        
                        al.Add(wkSCMAnsHistResultWork);
                    }
                    // �L�[��񂪂��邩
                    if (SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IUPDATEDATERF")) != 0)
                    {
                        SCMAnsHistResultWork wkSCMAnsHistResultWork = new SCMAnsHistResultWork();

                        wkSCMAnsHistResultWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHEREPCDRF"));  // �⍇�����ƃR�[�h
                        wkSCMAnsHistResultWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHERSECCDRF"));  // �⍇���拒�_�R�[�h
                        wkSCMAnsHistResultWork.SectionGuidNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));  // ���_����
                        wkSCMAnsHistResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));  // ���Ӑ�R�[�h
                        wkSCMAnsHistResultWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));  // ���Ӑ於��
                        wkSCMAnsHistResultWork.InquiryNumber = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INQUIRYNUMBERRF"));  // �⍇���ԍ�
                        wkSCMAnsHistResultWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));  // �X�V�N����
                        wkSCMAnsHistResultWork.UpdateTime = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATETIMERF"));  // �X�V����
                        wkSCMAnsHistResultWork.AnswerDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERDIVCDRF"));  // �񓚋敪
                        wkSCMAnsHistResultWork.JudgementDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JUDGEMENTDATERF"));  // �m���
                        wkSCMAnsHistResultWork.InqOrdNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORDNOTERF"));  // �⍇���E�������l
                        wkSCMAnsHistResultWork.InqEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQEMPLOYEECDRF"));  // �⍇���]�ƈ��R�[�h
                        wkSCMAnsHistResultWork.InqEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQEMPLOYEENMRF"));  // �⍇���]�ƈ�����
                        wkSCMAnsHistResultWork.AnsEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSEMPLOYEECDRF"));  // �񓚏]�ƈ��R�[�h
                        wkSCMAnsHistResultWork.AnsEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSEMPLOYEENMRF"));  // �񓚏]�ƈ�����
                        wkSCMAnsHistResultWork.InquiryDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQUIRYDATERF"));  // �⍇����
                        wkSCMAnsHistResultWork.NumberPlate1Code = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE1CODERF"));  // ���^�������ԍ�
                        wkSCMAnsHistResultWork.NumberPlate1Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE1NAMERF"));  // ���^�����ǖ���
                        wkSCMAnsHistResultWork.NumberPlate2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE2RF"));  // �ԗ��o�^�ԍ��i��ʁj
                        wkSCMAnsHistResultWork.NumberPlate3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE3RF"));  // �ԗ��o�^�ԍ��i�J�i�j
                        wkSCMAnsHistResultWork.NumberPlate4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE4RF"));  // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                        wkSCMAnsHistResultWork.ModelDesignationNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));  // �^���w��ԍ�
                        wkSCMAnsHistResultWork.CategoryNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));  // �ޕʔԍ�
                        wkSCMAnsHistResultWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));  // ���[�J�[�R�[�h
                        wkSCMAnsHistResultWork.CarMakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARMAKERNAMERF"));  // ���[�J�[����
                        wkSCMAnsHistResultWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));  // �Ԏ�R�[�h
                        wkSCMAnsHistResultWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));  // �Ԏ�T�u�R�[�h
                        wkSCMAnsHistResultWork.ModelName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELNAMERF"));  // �Ԏ햼
                        wkSCMAnsHistResultWork.CarInspectCertModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARINSPECTCERTMODELRF"));  // �Ԍ��،^��
                        wkSCMAnsHistResultWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));  // �^���i�t���^�j
                        wkSCMAnsHistResultWork.FrameNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMENORF"));  // �ԑ�ԍ�
                        wkSCMAnsHistResultWork.FrameModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMEMODELRF"));  // �ԑ�^��
                        wkSCMAnsHistResultWork.ChassisNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHASSISNORF"));  // �V���V�[No
                        wkSCMAnsHistResultWork.CarProperNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARPROPERNORF"));  // �ԗ��ŗL�ԍ�
                        wkSCMAnsHistResultWork.ProduceTypeOfYearNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRODUCETYPEOFYEARNUMRF"));  // ���Y�N���iNUM�^�C�v�j
                        wkSCMAnsHistResultWork.Comment = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMMENTRF"));  // �R�����g
                        wkSCMAnsHistResultWork.RpColorCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RPCOLORCODERF"));  // ���y�A�J���[�R�[�h
                        wkSCMAnsHistResultWork.ColorName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORNAME1RF"));  // �J���[����1
                        wkSCMAnsHistResultWork.TrimCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMCODERF"));  // �g�����R�[�h
                        wkSCMAnsHistResultWork.TrimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMNAMERF"));  // �g��������
                        wkSCMAnsHistResultWork.Mileage = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MILEAGERF"));  // �ԗ����s����
                        wkSCMAnsHistResultWork.EquipObj = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("EQUIPOBJRF"));  // �����I�u�W�F�N�g
                        if (wkSCMAnsHistResultWork.EquipObj == null)
                        {
                            wkSCMAnsHistResultWork.EquipObj = new Byte[0];
                        }
                        wkSCMAnsHistResultWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAMPAIGNCODERF"));  // �L�����y�[���R�[�h
                        wkSCMAnsHistResultWork.CampaignName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CAMPAIGNNAMERF"));  // �L�����y�[������
                        wkSCMAnsHistResultWork.SalesTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXINCRF"));  // ����`�[���v�i�ō��݁j
                        wkSCMAnsHistResultWork.SalesSubtotalTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXRF"));  // ���㏬�v�i�Łj
                        wkSCMAnsHistResultWork.InqOrdAnsDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQORDANSDIVCDRF"));  // �┭�E�񓚎��
                        wkSCMAnsHistResultWork.ReceiveDateTime = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RECEIVEDATETIMERF"));  // ��M����
                        // 2009.08.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        wkSCMAnsHistResultWork.AnswerCreateDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERCREATEDIVRF"));  // �񓚍쐬�敪
                        // 2009.08.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                        wkSCMAnsHistResultWork.InqRowNumber = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IINQROWNUMBERRF"));  // �⍇���s�ԍ�
                        wkSCMAnsHistResultWork.InqRowNumDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IINQROWNUMDERIVEDNORF"));  // �⍇���s�ԍ��}��
                        wkSCMAnsHistResultWork.GoodsDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IGOODSDIVCDRF"));  // ���i���
                        wkSCMAnsHistResultWork.RecyclePrtKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IRECYCLEPRTKINDCODERF"));  // ���T�C�N�����i���
                        wkSCMAnsHistResultWork.RecyclePrtKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IRECYCLEPRTKINDNAMERF"));  // ���T�C�N�����i��ʖ���
                        wkSCMAnsHistResultWork.DeliveredGoodsDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IDELIVRDGDSCONFCDRF"));  // �[�i�敪
                        wkSCMAnsHistResultWork.HandleDivCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IHANDLEDIVCODERF"));  // �戵�敪
                        wkSCMAnsHistResultWork.GoodsShape = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IGOODSSHAPERF"));  // ���i�`��
                        wkSCMAnsHistResultWork.DelivrdGdsConfCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IDELIVRDGDSCONFCDRF"));  // �[�i�m�F�敪
                        wkSCMAnsHistResultWork.DeliGdsCmpltDueDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IDELIGDSCMPLTDUEDATERF"));  // �[�i�����\���
                        wkSCMAnsHistResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IBLGOODSCODERF"));  // BL���i�R�[�h
                        wkSCMAnsHistResultWork.BLGoodsDrCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IBLGOODSDRCODERF"));  // BL���i�R�[�h�}��
                        //wkSCMAnsHistResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IGOODSNAMERF"));  // ���i����
                        wkSCMAnsHistResultWork.InqGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IINQGOODSNAMERF"));
                        wkSCMAnsHistResultWork.AnsGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IANSGOODSNAMERF"));
                        wkSCMAnsHistResultWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ISALESORDERCOUNTRF"));  // ������
                        wkSCMAnsHistResultWork.DeliveredGoodsCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IDELIVEREDGOODSCOUNTRF"));  // �[�i��
                        wkSCMAnsHistResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IGOODSNORF"));  // ���i�ԍ�
                        wkSCMAnsHistResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IGOODSMAKERCDRF"));  // ���i���[�J�[�R�[�h
                        wkSCMAnsHistResultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IMAKERNAMERF"));  // ���[�J�[����
                        wkSCMAnsHistResultWork.PureGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IPUREGOODSMAKERCDRF"));  // �������i���[�J�[�R�[�h
                        wkSCMAnsHistResultWork.PureMakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IPUREMAKERNAMERF"));  // �������i���[�J�[����
                        //wkSCMAnsHistResultWork.PureGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IPUREGOODSNORF"));  // �������i�ԍ�
                        wkSCMAnsHistResultWork.InqPureGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IIPUREGOODSNORF")); // �����┭���i�ԍ�
                        wkSCMAnsHistResultWork.AnsPureGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IAPUREGOODSNORF")); // �����񓚏��i�ԍ�
                        
                        //wkSCMAnsHistResultWork.PureGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IPUREGOODSNAMERF"));  // �������i����
                        wkSCMAnsHistResultWork.InqPureGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IIPUREGOODSNAMERF")); // �┭�������i����
                        wkSCMAnsHistResultWork.AnsPureGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IAPUREGOODSNAMERF")); // �񓚏������i����
                        
                        wkSCMAnsHistResultWork.ListPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ILISTPRICERF"));  // �艿
                        wkSCMAnsHistResultWork.UnitPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("IUNITPRICERF"));  // �P��
                        wkSCMAnsHistResultWork.GoodsAddInfo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IGOODSADDINFORF"));  // ���i�⑫���
                        wkSCMAnsHistResultWork.RoughRrofit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("IROUGHRROFITRF"));  // �e���z
                        wkSCMAnsHistResultWork.RoughRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IROUGHRATERF"));  // �e����
                        wkSCMAnsHistResultWork.AnswerLimitDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IANSWERLIMITDATERF"));  // �񓚊���
                        wkSCMAnsHistResultWork.CommentDtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ICOMMENTDTLRF"));  // ���l(����)
                        wkSCMAnsHistResultWork.ShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ISHELFNORF"));  // �I��
                        wkSCMAnsHistResultWork.AdditionalDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IADDITIONALDIVCDRF"));  // �ǉ��敪
                        wkSCMAnsHistResultWork.CorrectDivCD = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ICORRECTDIVCDRF"));  // �����敪
                        //wkSCMAnsHistResultWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IACPTANODRSTATUSRF"));  // �󒍃X�e�[�^�X
                        //wkSCMAnsHistResultWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ISALESSLIPNUMRF"));  // ����`�[�ԍ�
                        wkSCMAnsHistResultWork.InqOrdDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IINQORDDIVCDRF"));  // �⍇���E�������
                        wkSCMAnsHistResultWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IDISPLAYORDERRF"));  // �\������
                        wkSCMAnsHistResultWork.AnswerDeliveryDate = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IANSWERDELIVERYDATERF"));  // �񓚔[��
                       
                        al.Add(wkSCMAnsHistResultWork);
                    }
                    #endregion



                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
          
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
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
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="_supplierSendErOrderCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, SCMAnsHistOrderWork scmAnsHistOrderWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = "WHERE" + Environment.NewLine;
            string retst = "";

            // �⍇�����ƃR�[�h 
            retstring += " SCM.INQOTHEREPCDRF=@INQOTHEREPCD" + Environment.NewLine;
            SqlParameter paraInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
            paraInqOtherEpCd.Value = SqlDataMediator.SqlSetString(scmAnsHistOrderWork.InqOtherEpCd);

            // �񓚋敪
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

            // �⍇����
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

            // �⍇�킹�拒�_�R�[�h
            if (scmAnsHistOrderWork.InqOtherSecCd != "")
            {
                retstring += " AND SCM.INQOTHERSECCDRF=@INQOTHERSECCD" + Environment.NewLine;
                SqlParameter paraInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
                paraInqOtherSecCd.Value = SqlDataMediator.SqlSetString(scmAnsHistOrderWork.InqOtherSecCd);
            }

            // ���Ӑ�R�[�h
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

            // �񓚕��@
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

            // �`�[�ԍ�
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

            // �󒍃X�e�[�^�X
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

            // �⍇���ԍ�
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

            // �ԗ��o�^�ԍ�(�v���[�g�ԍ�)
            if (scmAnsHistOrderWork.NumberPlate4 != 0)
            {
                retstring += " AND CAR.NUMBERPLATE4RF=@NUMBERPLATE4" + Environment.NewLine;
                SqlParameter paraNumberPlate4 = sqlCommand.Parameters.Add("@NUMBERPLATE4", SqlDbType.Int);
                paraNumberPlate4.Value = SqlDataMediator.SqlSetInt32(scmAnsHistOrderWork.NumberPlate4);
            }

            // �^��
            if (scmAnsHistOrderWork.FullModel != "")
            {
                retstring += " AND CAR.FULLMODELRF LIKE @FULLMODEL" + Environment.NewLine;

                SqlParameter paraFullModel = sqlCommand.Parameters.Add("@FULLMODEL", SqlDbType.NChar);
                //�O����v�����̏ꍇ
                if (scmAnsHistOrderWork.SerchTypeModelCd == 1) scmAnsHistOrderWork.FullModel = scmAnsHistOrderWork.FullModel + "%";
                //�����v�����̏ꍇ
                if (scmAnsHistOrderWork.SerchTypeModelCd == 2) scmAnsHistOrderWork.FullModel = "%" + scmAnsHistOrderWork.FullModel;
                //�B�������̏ꍇ
                if (scmAnsHistOrderWork.SerchTypeModelCd == 3) scmAnsHistOrderWork.FullModel = "%" + scmAnsHistOrderWork.FullModel + "%";

                paraFullModel.Value = SqlDataMediator.SqlSetString(scmAnsHistOrderWork.FullModel);
            }

            // ���[�J�[�R�[�h(�ԗ����)
            if (scmAnsHistOrderWork.CarMakerCode != 0)
            {
                retstring += " AND CAR.MAKERCODERF=@MAKERCODE" + Environment.NewLine;
                SqlParameter paraCarMakerCode = sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int);
                paraCarMakerCode.Value = SqlDataMediator.SqlSetInt32(scmAnsHistOrderWork.CarMakerCode);
            }

            // �Ԏ�
            if (scmAnsHistOrderWork.ModelCode != 0)
            {
                retstring += " AND CAR.MODELCODERF=@MODELCODE" + Environment.NewLine;
                SqlParameter paraModelCode = sqlCommand.Parameters.Add("@MODELCODE", SqlDbType.Int);
                paraModelCode.Value = SqlDataMediator.SqlSetInt32(scmAnsHistOrderWork.ModelCode);
            }

            // 2009.08.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // �Ԏ�T�u�R�[�h
            if (scmAnsHistOrderWork.ModelSubCode != 0)
            {
                retstring += " AND CAR.MODELSUBCODERF=@MODELSUBCODE" + Environment.NewLine;
                SqlParameter paraModelSubCode = sqlCommand.Parameters.Add("@MODELSUBCODE", SqlDbType.Int);
                paraModelSubCode.Value = SqlDataMediator.SqlSetInt32(scmAnsHistOrderWork.ModelSubCode);
            }
            // 2009.08.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // ���[�J�[�R�[�h
            if (scmAnsHistOrderWork.GoodsMakerCd != 0)
            {
                retstring += " AND ANS.GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(scmAnsHistOrderWork.GoodsMakerCd);
            }

            // BL�R�[�h
            if (scmAnsHistOrderWork.BLGoodsCode != 0)
            {
                retstring += " AND ANS.BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(scmAnsHistOrderWork.BLGoodsCode);
            }

            // �i��
            if (scmAnsHistOrderWork.GoodsNo != "")
            {
                retstring += " AND ANS.GOODSNORF LIKE @GOODSNO" + Environment.NewLine;

                SqlParameter paraFullModel = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                //�O����v�����̏ꍇ
                if (scmAnsHistOrderWork.SerchTypeGoodsNo == 1) scmAnsHistOrderWork.GoodsNo = scmAnsHistOrderWork.GoodsNo + "%";
                //�����v�����̏ꍇ
                if (scmAnsHistOrderWork.SerchTypeGoodsNo == 2) scmAnsHistOrderWork.GoodsNo = "%" + scmAnsHistOrderWork.GoodsNo;
                //�B�������̏ꍇ
                if (scmAnsHistOrderWork.SerchTypeGoodsNo == 3) scmAnsHistOrderWork.GoodsNo = "%" + scmAnsHistOrderWork.GoodsNo + "%";

                // 2009.08.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //paraFullModel.Value = SqlDataMediator.SqlSetString(scmAnsHistOrderWork.FullModel);
                paraFullModel.Value = SqlDataMediator.SqlSetString(scmAnsHistOrderWork.GoodsNo);
                // 2009.08.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            }

            // �����i��
            if (scmAnsHistOrderWork.PureGoodsNo != "")
            {
                retstring += " AND ANS.ANSPUREGOODSNORF LIKE @PUREGOODSNO" + Environment.NewLine;

                SqlParameter paraFullModel = sqlCommand.Parameters.Add("@PUREGOODSNO", SqlDbType.NChar);
                //�O����v�����̏ꍇ
                if (scmAnsHistOrderWork.SerchTypePureGoodsNo == 1) scmAnsHistOrderWork.PureGoodsNo = scmAnsHistOrderWork.PureGoodsNo + "%";
                //�����v�����̏ꍇ
                if (scmAnsHistOrderWork.SerchTypePureGoodsNo == 2) scmAnsHistOrderWork.PureGoodsNo = "%" + scmAnsHistOrderWork.PureGoodsNo;
                //�B�������̏ꍇ
                if (scmAnsHistOrderWork.SerchTypePureGoodsNo == 3) scmAnsHistOrderWork.PureGoodsNo = "%" + scmAnsHistOrderWork.PureGoodsNo + "%";

                // 2009.08.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //paraFullModel.Value = SqlDataMediator.SqlSetString(scmAnsHistOrderWork.FullModel);
                paraFullModel.Value = SqlDataMediator.SqlSetString(scmAnsHistOrderWork.PureGoodsNo);
                // 2009.08.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            }
            // �⍇���E�������
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

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Diagnostics;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���㗚���Ɖ���[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���㗚���Ɖ�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 980081 �R�c ���F</br>
    /// <br>Date       : 2007.10.03</br>
    /// <br></br>
    /// <br>Update Note: 980081 �R�c ���F</br>
    /// <br>Date       : 2007.12.13</br>
    /// <br>             �_���폜�敪�̃`�F�b�N��ǉ�</br>
    /// <br></br>
    /// <br>Update Note: 980081 �R�c ���F</br>
    /// <br>Date       : 2008.01.21</br>
    /// <br>             ���o�����E���o���ʂ̃��C�A�E�g���ꕔ�ύX</br>
    /// <br></br>
    /// <br>Update Note: 980081 �R�c ���F</br>
    /// <br>Date       : 2008.01.24</br>
    /// <br>             ���i�ԍ��̐擪��v�����Ή�</br>
    /// <br>             ���i���̂̂����܂������Ή�</br>
    /// <br></br>
    /// <br>Update Note: 20081 �D�c �E�l</br>
    /// <br>Date       : 2008.06.23</br>
    /// <br>             �o�l.�m�r�p�ɕύX</br>
    /// <br></br>
    /// <br>Update Note: 23015 �X�{ ��P</br>
    /// <br>Date       : 2008.09.16</br>
    /// <br>             �G���[�Ή�</br>
    /// <br></br>
    /// <br>Update Note: 23012 ���� �[���N</br>
    /// <br>Date       : 2008.11.13</br>
    /// <br>             �s��Ή�</br>
    /// <br></br>
    /// <br>Update Note: 22008 ���� ���n</br>
    /// <br>Date       : 2010/05/10</br>
    /// <br>             ���x�`���[�j���O</br>
    /// <br>Update Note: ���N�n��</br>
    /// <br>Date       : 2011/03/22</br>
    /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
    /// <br></br>
    /// <br>Update Note: 2011/11/11 ���N�n�� Redmine 26539�Ή�</br>
    /// <br>Update Note: 2014/04/17 �e�c ���V</br>
    /// <br>�Ǘ��ԍ�   : 10904597-00</br>
    /// <br>           : �����艿�󎚑Ή��̏�Q�Ή�</br>
    /// <br>Update Note: �Ǘ��ԍ� : 11900025-00 �쐬�S�� : 3H ����</br>
    /// <br>           : �C�����e : READUNCOMMITTED�Ή�</br>
    /// <br>Date       : 2023/11/07</br>
    /// </remarks>
    [Serializable]
    public class SalHisRefDB : RemoteDB, ISalHisRefDB
    {

        /// <summary>
        /// ���㗚���Ɖ���[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.10.09</br>
        /// </remarks>
        public SalHisRefDB()
            : base("DCHNB04116D", "Broadleaf.Application.Remoting.ParamData.SalHisRefResultParamWork", "SALESHISTDTLRF")
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�p�����[�^�̏����𖞂����S�Ă̔��㗚��LIST��߂��܂�
        /// </summary>
        /// <param name="salHisRefResultParam">��������</param>
        /// <param name="salHisRefExtraParamWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�ۗ��f�[�^�̂� 3:���S�폜�f�[�^�̂� 4:�S�� 5:���K�f�[�^+�폜�f�[�^ 6:���K�f�[�^+�폜�f�[�^+�ۗ��f�[�^)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�p�����[�^�̏����𖞂����S�Ă̔��㗚��LIST��߂��܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.10.09</br>
        /// <br></br>
        /// <br>Update Note: 980081 �R�c ���F</br>
        /// <br>Date       : 2007.12.13</br>
        /// <br>             �_���폜�敪�̃`�F�b�N��ǉ�</br>
        /// <br>Update Note: ���N�n��</br>
        /// <br>Date       : 2011/03/22</br>
        /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
        public int Search(out object salHisRefResultParam, object salHisRefExtraParamWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            salHisRefResultParam = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //�������s
            ArrayList salHisRefResultParamWorkList = new ArrayList();
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = GetSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // --- ADD 2011/03/22----------------------------------->>>>>
                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, ((SalHisRefExtraParamWork)salHisRefExtraParamWork).EnterpriseCode, "���㗚���Ɖ�", "���o�J�n");
                // --- ADD 2011/03/22-----------------------------------<<<<<
                
                status = Search(out salHisRefResultParamWorkList, (SalHisRefExtraParamWork)salHisRefExtraParamWork, ref sqlConnection, logicalMode);

                // --- ADD 2011/03/22----------------------------------->>>>>
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, ((SalHisRefExtraParamWork)salHisRefExtraParamWork).EnterpriseCode, "���㗚���Ɖ�", "���o�I��");
                // --- ADD 2011/03/22-----------------------------------<<<<<
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalHisRefDB.Search");
                return status;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            //out�p�����[�^��ݒ�
            salHisRefResultParam = salHisRefResultParamWorkList;

            return status;
        }
        /// <summary>
        /// �w�肳�ꂽ�p�����[�^�̏����𖞂����S�Ă̔��㗚��LIST��߂��܂�
        /// </summary>
        /// <param name="salHisRefResultParamWorkList">��������</param>
        /// <param name="salHisRefExtraParamWork">�����p�����[�^</param>
        /// <param name="sqlConnection">SQL�ڑ����</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�ۗ��f�[�^�̂� 3:���S�폜�f�[�^�̂� 4:�S�� 5:���K�f�[�^+�폜�f�[�^ 6:���K�f�[�^+�폜�f�[�^+�ۗ��f�[�^)</param>
        /// <returns>STATUS</returns>
        /// <br>Update Note: 2011/11/11 ���N�n�� BL�߰µ��ް�݌Ɋm�F���̌��ϓ`�[�Ή�</br>
        /// <br>Update Note: �Ǘ��ԍ� : 11900025-00 �쐬�S�� : 3H ����</br>
        /// <br>           : �C�����e : READUNCOMMITTED�Ή�</br>
        /// <br>Date       : 2023/11/07</br>
        private int Search(out ArrayList salHisRefResultParamWorkList, SalHisRefExtraParamWork salHisRefExtraParamWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            salHisRefResultParamWorkList = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //SqlEncryptInfo sqlEncriptInfo = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            int loopcnt = 1;
            try
            {
                //�Í����L�[OPEN
                //sqlEncriptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "SALESHISTDTLRF", "SALESHISTORYRF" });
                //sqlEncriptInfo.OpenSymKey(ref sqlConnection);

                if (IsValidParameter(salHisRefExtraParamWork.AcptAnOdrStatus, false))
                {
                    //�`�[��ʎw��̏ꍇ
                    loopcnt = 1;
                }
                else
                {
                    //�`�[��ʁu�S�āv�̏ꍇ
                    //����f�[�^�ǂݍ��݂ƁA���㗚���f�[�^�ǂݍ��݂���������ׁA�Q�񃋁[�v
                    loopcnt = 2;
                }

                for (int i = 1; i <= loopcnt; i++)
                {
                    if (i == 2)
                    {
                        //�`�[��ʁu�S�āv�Œ��o�����ꍇ�́A�Q��ڂ̃��[�v��
                        //���㗚�𖾍ׂ��甄��f�[�^�𒊏o����
                        salHisRefExtraParamWork.AcptAnOdrStatus = 30;
                        if (!myReader.IsClosed) myReader.Close();
                    }

                    string queryString = string.Empty;
                    queryString += "SELECT DISTINCT" + Environment.NewLine;
                    queryString += "     SHD.ENTERPRISECODERF" + Environment.NewLine;
                    queryString += "    ,SHD.LOGICALDELETECODERF" + Environment.NewLine;
                    queryString += "    ,SHD.ACCEPTANORDERNORF" + Environment.NewLine;
                    queryString += "    ,SHD.ACPTANODRSTATUSRF" + Environment.NewLine;
                    queryString += "    ,SHD.SALESSLIPNUMRF" + Environment.NewLine;
                    queryString += "    ,SHD.SALESROWNORF" + Environment.NewLine;
                    queryString += "    ,SHD.SALESROWDERIVNORF" + Environment.NewLine;
                    // �C�� 2009/05/18 >>>
                    //queryString += "    ,SHD.SECTIONCODERF" + Environment.NewLine;
                    queryString += "    ,SHS.RESULTSADDUPSECCDRF AS SECTIONCODERF" + Environment.NewLine;
                    // �C�� 2009/05/18 <<<
                    queryString += "    ,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                    queryString += "    ,SHD.SUBSECTIONCODERF" + Environment.NewLine;
                    queryString += "    ,SUB.SUBSECTIONNAMERF" + Environment.NewLine;
                    queryString += "    ,SHD.COMMONSEQNORF" + Environment.NewLine;
                    queryString += "    ,SHD.SUPPLIERFORMALSYNCRF" + Environment.NewLine;
                    queryString += "    ,SHD.STOCKSLIPDTLNUMSYNCRF" + Environment.NewLine;
                    queryString += "    ,SHD.GOODSKINDCODERF" + Environment.NewLine;
                    queryString += "    ,SHD.GOODSMAKERCDRF" + Environment.NewLine;
                    queryString += "    ,SHD.MAKERNAMERF" + Environment.NewLine;
                    queryString += "    ,SHD.MAKERKANANAMERF" + Environment.NewLine;
                    queryString += "    ,SHD.CMPLTMAKERKANANAMERF" + Environment.NewLine;
                    queryString += "    ,SHD.GOODSNORF" + Environment.NewLine;
                    queryString += "    ,SHD.GOODSNAMERF" + Environment.NewLine;
                    queryString += "    ,SHD.GOODSNAMEKANARF" + Environment.NewLine;
                    queryString += "    ,SHD.GOODSLGROUPRF" + Environment.NewLine;
                    queryString += "    ,SHD.GOODSLGROUPNAMERF" + Environment.NewLine;
                    queryString += "    ,SHD.GOODSMGROUPRF" + Environment.NewLine;
                    queryString += "    ,SHD.GOODSMGROUPNAMERF" + Environment.NewLine;
                    queryString += "    ,SHD.BLGROUPCODERF" + Environment.NewLine;
                    queryString += "    ,SHD.BLGROUPNAMERF" + Environment.NewLine;
                    queryString += "    ,SHD.BLGOODSCODERF" + Environment.NewLine;
                    queryString += "    ,SHD.BLGOODSFULLNAMERF" + Environment.NewLine;
                    queryString += "    ,SHD.ENTERPRISEGANRECODERF" + Environment.NewLine;
                    queryString += "    ,SHD.ENTERPRISEGANRENAMERF" + Environment.NewLine;
                    queryString += "    ,SHD.WAREHOUSECODERF" + Environment.NewLine;
                    queryString += "    ,SHD.WAREHOUSENAMERF" + Environment.NewLine;
                    queryString += "    ,SHD.WAREHOUSESHELFNORF" + Environment.NewLine;
                    queryString += "    ,SHD.SALESORDERDIVCDRF" + Environment.NewLine;
                    queryString += "    ,SHD.OPENPRICEDIVRF" + Environment.NewLine;
                    queryString += "    ,SHD.GOODSRATERANKRF" + Environment.NewLine;
                    queryString += "    ,SHD.CUSTRATEGRPCODERF" + Environment.NewLine;
                    queryString += "    ,SHD.LISTPRICERATERF" + Environment.NewLine;
                    queryString += "    ,SHD.RATESECTPRICEUNPRCRF" + Environment.NewLine;
                    queryString += "    ,SHD.RATEDIVLPRICERF" + Environment.NewLine;
                    queryString += "    ,SHD.UNPRCCALCCDLPRICERF" + Environment.NewLine;
                    queryString += "    ,SHD.PRICECDLPRICERF" + Environment.NewLine;
                    queryString += "    ,SHD.STDUNPRCLPRICERF" + Environment.NewLine;
                    queryString += "    ,SHD.FRACPROCUNITLPRICERF" + Environment.NewLine;
                    queryString += "    ,SHD.FRACPROCLPRICERF" + Environment.NewLine;
                    queryString += "    ,SHD.LISTPRICETAXINCFLRF" + Environment.NewLine;
                    queryString += "    ,SHD.LISTPRICETAXEXCFLRF" + Environment.NewLine;
                    queryString += "    ,SHD.LISTPRICECHNGCDRF" + Environment.NewLine;
                    queryString += "    ,SHD.SALESRATERF" + Environment.NewLine;
                    queryString += "    ,SHD.RATESECTSALUNPRCRF" + Environment.NewLine;
                    queryString += "    ,SHD.RATEDIVSALUNPRCRF" + Environment.NewLine;
                    queryString += "    ,SHD.UNPRCCALCCDSALUNPRCRF" + Environment.NewLine;
                    queryString += "    ,SHD.PRICECDSALUNPRCRF" + Environment.NewLine;
                    queryString += "    ,SHD.STDUNPRCSALUNPRCRF" + Environment.NewLine;
                    queryString += "    ,SHD.FRACPROCUNITSALUNPRCRF" + Environment.NewLine;
                    queryString += "    ,SHD.FRACPROCSALUNPRCRF" + Environment.NewLine;
                    queryString += "    ,SHD.SALESUNPRCTAXINCFLRF" + Environment.NewLine;
                    queryString += "    ,SHD.SALESUNPRCTAXEXCFLRF" + Environment.NewLine;
                    queryString += "    ,SHD.SALESUNPRCCHNGCDRF" + Environment.NewLine;
                    queryString += "    ,SHD.COSTRATERF" + Environment.NewLine;
                    queryString += "    ,SHD.RATESECTCSTUNPRCRF" + Environment.NewLine;
                    queryString += "    ,SHD.RATEDIVUNCSTRF" + Environment.NewLine;
                    queryString += "    ,SHD.UNPRCCALCCDUNCSTRF" + Environment.NewLine;
                    queryString += "    ,SHD.PRICECDUNCSTRF" + Environment.NewLine;
                    queryString += "    ,SHD.STDUNPRCUNCSTRF" + Environment.NewLine;
                    queryString += "    ,SHD.FRACPROCUNITUNCSTRF" + Environment.NewLine;
                    queryString += "    ,SHD.FRACPROCUNCSTRF" + Environment.NewLine;
                    queryString += "    ,SHD.SALESUNITCOSTRF" + Environment.NewLine;
                    queryString += "    ,SHD.SALESUNITCOSTCHNGDIVRF" + Environment.NewLine;
                    queryString += "    ,SHD.RATEBLGOODSCODERF" + Environment.NewLine;
                    queryString += "    ,SHD.RATEBLGOODSNAMERF" + Environment.NewLine;
                    queryString += "    ,SHD.PRTBLGOODSCODERF" + Environment.NewLine;
                    queryString += "    ,SHD.PRTBLGOODSNAMERF" + Environment.NewLine;
                    queryString += "    ,SHD.SALESCODERF" + Environment.NewLine;
                    queryString += "    ,SHD.SALESCDNMRF" + Environment.NewLine;
                    queryString += "    ,SHD.WORKMANHOURRF" + Environment.NewLine;
                    queryString += "    ,SHD.SHIPMENTCNTRF" + Environment.NewLine;
                    queryString += "    ,SHD.SALESMONEYTAXINCRF" + Environment.NewLine;
                    queryString += "    ,SHD.SALESMONEYTAXEXCRF" + Environment.NewLine;
                    queryString += "    ,SHD.COSTRF" + Environment.NewLine;
                    queryString += "    ,SHD.GRSPROFITCHKDIVRF" + Environment.NewLine;
                    queryString += "    ,SHD.SALESGOODSCDRF" + Environment.NewLine;
                    queryString += "    ,SHD.SALESPRICECONSTAXRF" + Environment.NewLine;
                    queryString += "    ,SHD.TAXATIONDIVCDRF" + Environment.NewLine;
                    queryString += "    ,SHD.PARTYSLIPNUMDTLRF" + Environment.NewLine;
                    queryString += "    ,SHD.DTLNOTERF" + Environment.NewLine;
                    queryString += "    ,SHD.SUPPLIERCDRF" + Environment.NewLine;
                    queryString += "    ,SHD.SUPPLIERSNMRF" + Environment.NewLine;
                    queryString += "    ,SHD.ORDERNUMBERRF" + Environment.NewLine;
                    queryString += "    ,SHD.WAYTOORDERRF" + Environment.NewLine;
                    queryString += "    ,SHD.SLIPMEMO1RF" + Environment.NewLine;
                    queryString += "    ,SHD.SLIPMEMO2RF" + Environment.NewLine;
                    queryString += "    ,SHD.SLIPMEMO3RF" + Environment.NewLine;
                    queryString += "    ,SHD.INSIDEMEMO1RF" + Environment.NewLine;
                    queryString += "    ,SHD.INSIDEMEMO2RF" + Environment.NewLine;
                    queryString += "    ,SHD.INSIDEMEMO3RF" + Environment.NewLine;
                    queryString += "    ,SHD.BFLISTPRICERF" + Environment.NewLine;
                    queryString += "    ,SHD.BFSALESUNITPRICERF" + Environment.NewLine;
                    queryString += "    ,SHD.BFUNITCOSTRF" + Environment.NewLine;
                    queryString += "    ,SHD.CMPLTSALESROWNORF" + Environment.NewLine;
                    queryString += "    ,SHD.CMPLTGOODSMAKERCDRF" + Environment.NewLine;
                    queryString += "    ,SHD.CMPLTMAKERNAMERF" + Environment.NewLine;
                    queryString += "    ,SHD.CMPLTGOODSNAMERF" + Environment.NewLine;
                    queryString += "    ,SHD.CMPLTSHIPMENTCNTRF" + Environment.NewLine;
                    queryString += "    ,SHD.CMPLTSALESUNPRCFLRF" + Environment.NewLine;
                    queryString += "    ,SHD.CMPLTSALESMONEYRF" + Environment.NewLine;
                    queryString += "    ,SHD.CMPLTSALESUNITCOSTRF" + Environment.NewLine;
                    queryString += "    ,SHD.CMPLTCOSTRF" + Environment.NewLine;
                    queryString += "    ,SHD.CMPLTPARTYSALSLNUMRF" + Environment.NewLine;
                    queryString += "    ,SHD.CMPLTNOTERF" + Environment.NewLine;
                    queryString += "    ,AOC.CARMNGCODERF" + Environment.NewLine;
                    queryString += "    ,AOC.MODELDESIGNATIONNORF" + Environment.NewLine;
                    queryString += "    ,AOC.CATEGORYNORF" + Environment.NewLine;
                    queryString += "    ,AOC.MAKERFULLNAMERF" + Environment.NewLine;
                    queryString += "    ,AOC.FULLMODELRF" + Environment.NewLine;
                    queryString += "    ,AOC.MODELFULLNAMERF" + Environment.NewLine;
                    queryString += "    ,SHS.ACCRECDIVCDRF" + Environment.NewLine;
                    queryString += "    ,SHS.SEARCHSLIPDATERF" + Environment.NewLine;
                    queryString += "    ,SHS.SHIPMENTDAYRF" + Environment.NewLine;
                    queryString += "    ,SHS.ADDUPADATERF" + Environment.NewLine;
                    queryString += "    ,SHS.INPUTAGENCDRF" + Environment.NewLine;
                    queryString += "    ,SHS.INPUTAGENNMRF" + Environment.NewLine;
                    queryString += "    ,SHS.SALESINPUTCODERF" + Environment.NewLine;
                    queryString += "    ,SHS.SALESINPUTNAMERF" + Environment.NewLine;
                    queryString += "    ,SHS.FRONTEMPLOYEECDRF" + Environment.NewLine;
                    queryString += "    ,SHS.FRONTEMPLOYEENMRF" + Environment.NewLine;
                    queryString += "    ,SHS.SALESEMPLOYEECDRF" + Environment.NewLine;
                    queryString += "    ,SHS.SALESEMPLOYEENMRF" + Environment.NewLine;
                    queryString += "    ,SHS.CLAIMCODERF" + Environment.NewLine;
                    queryString += "    ,SHS.CLAIMSNMRF" + Environment.NewLine;
                    queryString += "    ,SHS.CUSTOMERCODERF" + Environment.NewLine;
                    queryString += "    ,SHS.CUSTOMERSNMRF" + Environment.NewLine;
                    queryString += "    ,SHS.DEBITNOTEDIVRF" + Environment.NewLine;
                    queryString += "    ,SHD.SALESDATERF" + Environment.NewLine;
                    queryString += "    ,SHD.SALESSLIPDTLNUMRF" + Environment.NewLine;
                    queryString += "    ,SHD.ACPTANODRSTATUSSRCRF" + Environment.NewLine;
                    queryString += "    ,SHD.SALESSLIPDTLNUMSRCRF" + Environment.NewLine;
                    queryString += "    ,SHD.SALESSLIPCDDTLRF" + Environment.NewLine;
                    queryString += "    ,SHS.ADDRESSEECODERF" + Environment.NewLine;
                    queryString += "    ,SHS.ADDRESSEENAMERF" + Environment.NewLine;
                    queryString += "    ,SHS.ADDRESSEENAME2RF" + Environment.NewLine;
                    queryString += "    ,SHS.CONSTAXLAYMETHODRF" + Environment.NewLine;
                    queryString += "    ,SHS.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                    //---ADD 2011/11/11 ---------------------------------->>>>>
                    queryString += "    ,SHD.ACCEPTORORDERKINDRF" + Environment.NewLine;
                    queryString += "    ,SHD.AUTOANSWERDIVSCMRF" + Environment.NewLine;
                    //---ADD 2011/11/11 ----------------------------------<<<<<

                    if (salHisRefExtraParamWork.AcptAnOdrStatus == 30)
                    {
                        // 30:����̏ꍇ�͔��㗚�𖾍׃f�[�^���璊�o����
                        //queryString += "FROM SALESHISTDTLRF AS SHD" + Environment.NewLine;//  DEL 3H ���� 2023/11/07
                        queryString += "FROM SALESHISTDTLRF AS SHD WITH (READUNCOMMITTED)" + Environment.NewLine;//  ADD 3H ���� 2023/11/07
                    }
                    else
                    {
                        queryString += "    ,SHS.ESTIMATEDIVIDERF" + Environment.NewLine;
                        // ����ȊO�͔��㖾�׃f�[�^���璊�o����
                        queryString += "    ,SHD.ACPTANODRREMAINCNTRF" + Environment.NewLine;
                        // ����ȊO�͔��㖾�׃f�[�^���璊�o����
                        //queryString += "FROM SALESDETAILRF AS SHD" + Environment.NewLine;//  DEL 3H ���� 2023/11/07
                        queryString += "FROM SALESDETAILRF AS SHD WITH (READUNCOMMITTED)" + Environment.NewLine;//  ADD 3H ���� 2023/11/07
                    }

                    sqlCommand = new SqlCommand(queryString, sqlConnection);

                    //�p�����[�^���FROM��AWHERE�吶��
                    string fromClause;
                    string whereClause;
                    SetFromWhereClause(ref sqlCommand, salHisRefExtraParamWork, out fromClause, out whereClause, logicalMode);

                    if (!String.IsNullOrEmpty(fromClause)) sqlCommand.CommandText += fromClause;
                    if (!String.IsNullOrEmpty(whereClause)) sqlCommand.CommandText += whereClause;

                    //ORDER BY
                    sqlCommand.CommandText += SetOrderByClause();

                    //���s
                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.HasRows)
                    {
                        while (myReader.Read())
                        {
                            salHisRefResultParamWorkList.Add(ReaderToSalHisRefResultParamWork(ref myReader, salHisRefExtraParamWork));
                        }
                    }
                }
                if (salHisRefResultParamWorkList.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                else
                {
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
                base.WriteErrorLog(ex, "ISalHisRefDB.Search");
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();

                //�Í����L�[�N���[�Y
                //if (sqlEncriptInfo != null)
                //    if (sqlEncriptInfo.IsOpen) sqlEncriptInfo.CloseSymKey(ref sqlConnection);
            }

            if (sqlConnection == null) return status;
            return status;
        }
        #endregion

        #region ���g�p�ׁ̈A�폜
        /*
        #region [TopSearch]
        /// <summary>
        /// �w�肳�ꂽ�p�����[�^�̏����𖞂����w�茏�����̔��㗚��LIST��߂��܂�
        /// </summary>
        /// <param name="salHisRefResultParam">��������</param>
        /// <param name="salHisRefExtraParamWork">���㌟���p�����[�^�iNextRead���͑O��ŏI���R�[�h�L�[�j</param>
        /// <param name="retTotalCnt">�����Ώۑ�����</param>
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="readCnt">�����w�茏��</param>        
        /// <param name="readMode">�����敪(���g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�ۗ��f�[�^�̂� 3:���S�폜�f�[�^�̂� 4:�S�� 5:���K�f�[�^+�폜�f�[�^ 6:���K�f�[�^+�폜�f�[�^+�ۗ��f�[�^)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�p�����[�^�̏����𖞂����w�茏�����̔��㗚��LIST��߂��܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.10.09</br>
        /// <br></br>
        /// <br>Update Note: 980081 �R�c ���F</br>
        /// <br>Date       : 2007.12.13</br>
        /// <br>             �_���폜�敪�̃`�F�b�N��ǉ�</br>
        public int TopSearch(out object salHisRefResultParam, object salHisRefExtraParamWork, out int retTotalCnt, out bool nextData, int readCnt, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            salHisRefResultParam = null;
            retTotalCnt = 0;
            nextData = false;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //�������s
            ArrayList salHisRefResultParamWorkList = new ArrayList();
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = GetSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //�������擾
                status = SearchCount((SalHisRefExtraParamWork)salHisRefExtraParamWork, out retTotalCnt, 0, ConstantManagement.LogicalMode.GetData0);
                if (retTotalCnt == 0) return status;
                //�f�[�^���擾
                status = TopSearch(out salHisRefResultParamWorkList, (SalHisRefExtraParamWork)salHisRefExtraParamWork, readCnt, ref sqlConnection, logicalMode);

                //�S�������擾��������������Ύ��f�[�^����
                if (retTotalCnt > salHisRefResultParamWorkList.Count) nextData = true;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalHisRefDB.TopSearch");
                return status;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            //out�p�����[�^��ݒ�
            salHisRefResultParam = salHisRefResultParamWorkList;

            return status;
        }
        /// <summary>
        /// �w�肳�ꂽ�p�����[�^�̏����𖞂����w�茏�����̔��㗚��LIST��߂��܂�
        /// </summary>
        /// <param name="salHisRefResultParamWorkList">��������</param>
        /// <param name="salHisRefExtraParamWork">�����p�����[�^</param>
        /// <param name="readCnt">������</param>
        /// <param name="sqlConnection">SQL�ڑ����</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�ۗ��f�[�^�̂� 3:���S�폜�f�[�^�̂� 4:�S�� 5:���K�f�[�^+�폜�f�[�^ 6:���K�f�[�^+�폜�f�[�^+�ۗ��f�[�^)</param>
        /// <returns>STATUS</returns>
        private int TopSearch(out ArrayList salHisRefResultParamWorkList, SalHisRefExtraParamWork salHisRefExtraParamWork, int readCnt, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            salHisRefResultParamWorkList = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //SqlEncryptInfo sqlEncriptInfo = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                //�Í����L�[OPEN
                //sqlEncriptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "SALESHISTDTLRF", "SALESHISTORYRF" });
                //sqlEncriptInfo.OpenSymKey(ref sqlConnection);

                //�N�G�������񐶐�
                string queryString =string.Empty;
                if (readCnt > 0)
                {
                    queryString += "SELECT DISTINCT TOP" + Environment.NewLine;
                    queryString += readCnt.ToString() + Environment.NewLine;
                }
                else
                {
                    queryString += "SELECT DISTINCT" + Environment.NewLine;
                }

                queryString += "     SHD.ENTERPRISECODERF" + Environment.NewLine;
                queryString += "    ,SHD.LOGICALDELETECODERF" + Environment.NewLine;
                queryString += "    ,SHD.ACCEPTANORDERNORF" + Environment.NewLine;
                queryString += "    ,SHD.ACPTANODRSTATUSRF" + Environment.NewLine;
                queryString += "    ,SHD.SALESSLIPNUMRF" + Environment.NewLine;
                queryString += "    ,SHD.SALESROWNORF" + Environment.NewLine;
                queryString += "    ,SHD.SALESROWDERIVNORF" + Environment.NewLine;
                queryString += "    ,SHD.SECTIONCODERF" + Environment.NewLine;
                queryString += "    ,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                queryString += "    ,SHD.SUBSECTIONCODERF" + Environment.NewLine;
                queryString += "    ,SUB.SUBSECTIONNAMERF" + Environment.NewLine;
                queryString += "    ,SHD.SALESDATERF" + Environment.NewLine;
                queryString += "    ,SHD.COMMONSEQNORF" + Environment.NewLine;
                queryString += "    ,SHD.SUPPLIERFORMALSYNCRF" + Environment.NewLine;
                queryString += "    ,SHD.STOCKSLIPDTLNUMSYNCRF" + Environment.NewLine;
                queryString += "    ,SHD.GOODSKINDCODERF" + Environment.NewLine;
                queryString += "    ,SHD.GOODSMAKERCDRF" + Environment.NewLine;
                queryString += "    ,SHD.MAKERNAMERF" + Environment.NewLine;
                queryString += "    ,SHD.MAKERKANANAMERF" + Environment.NewLine;
                queryString += "    ,SHD.CMPLTMAKERKANANAMERF" + Environment.NewLine;
                queryString += "    ,SHD.GOODSNORF" + Environment.NewLine;
                queryString += "    ,SHD.GOODSNAMERF" + Environment.NewLine;
                queryString += "    ,SHD.GOODSNAMEKANARF" + Environment.NewLine;
                queryString += "    ,SHD.GOODSLGROUPRF" + Environment.NewLine;
                queryString += "    ,SHD.GOODSLGROUPNAMERF" + Environment.NewLine;
                queryString += "    ,SHD.GOODSMGROUPRF" + Environment.NewLine;
                queryString += "    ,SHD.GOODSMGROUPNAMERF" + Environment.NewLine;
                queryString += "    ,SHD.BLGROUPCODERF" + Environment.NewLine;
                queryString += "    ,SHD.BLGROUPNAMERF" + Environment.NewLine;
                queryString += "    ,SHD.BLGOODSCODERF" + Environment.NewLine;
                queryString += "    ,SHD.BLGOODSFULLNAMERF" + Environment.NewLine;
                queryString += "    ,SHD.ENTERPRISEGANRECODERF" + Environment.NewLine;
                queryString += "    ,SHD.ENTERPRISEGANRENAMERF" + Environment.NewLine;
                queryString += "    ,SHD.WAREHOUSECODERF" + Environment.NewLine;
                queryString += "    ,SHD.WAREHOUSENAMERF" + Environment.NewLine;
                queryString += "    ,SHD.WAREHOUSESHELFNORF" + Environment.NewLine;
                queryString += "    ,SHD.SALESORDERDIVCDRF" + Environment.NewLine;
                queryString += "    ,SHD.OPENPRICEDIVRF" + Environment.NewLine;
                queryString += "    ,SHD.GOODSRATERANKRF" + Environment.NewLine;
                queryString += "    ,SHD.CUSTRATEGRPCODERF" + Environment.NewLine;
                queryString += "    ,SHD.LISTPRICERATERF" + Environment.NewLine;
                queryString += "    ,SHD.RATESECTPRICEUNPRCRF" + Environment.NewLine;
                queryString += "    ,SHD.RATEDIVLPRICERF" + Environment.NewLine;
                queryString += "    ,SHD.UNPRCCALCCDLPRICERF" + Environment.NewLine;
                queryString += "    ,SHD.PRICECDLPRICERF" + Environment.NewLine;
                queryString += "    ,SHD.STDUNPRCLPRICERF" + Environment.NewLine;
                queryString += "    ,SHD.FRACPROCUNITLPRICERF" + Environment.NewLine;
                queryString += "    ,SHD.FRACPROCLPRICERF" + Environment.NewLine;
                queryString += "    ,SHD.LISTPRICETAXINCFLRF" + Environment.NewLine;
                queryString += "    ,SHD.LISTPRICETAXEXCFLRF" + Environment.NewLine;
                queryString += "    ,SHD.LISTPRICECHNGCDRF" + Environment.NewLine;
                queryString += "    ,SHD.SALESRATERF" + Environment.NewLine;
                queryString += "    ,SHD.RATESECTSALUNPRCRF" + Environment.NewLine;
                queryString += "    ,SHD.RATEDIVSALUNPRCRF" + Environment.NewLine;
                queryString += "    ,SHD.UNPRCCALCCDSALUNPRCRF" + Environment.NewLine;
                queryString += "    ,SHD.PRICECDSALUNPRCRF" + Environment.NewLine;
                queryString += "    ,SHD.STDUNPRCSALUNPRCRF" + Environment.NewLine;
                queryString += "    ,SHD.FRACPROCUNITSALUNPRCRF" + Environment.NewLine;
                queryString += "    ,SHD.FRACPROCSALUNPRCRF" + Environment.NewLine;
                queryString += "    ,SHD.SALESUNPRCTAXINCFLRF" + Environment.NewLine;
                queryString += "    ,SHD.SALESUNPRCTAXEXCFLRF" + Environment.NewLine;
                queryString += "    ,SHD.SALESUNPRCCHNGCDRF" + Environment.NewLine;
                queryString += "    ,SHD.COSTRATERF" + Environment.NewLine;
                queryString += "    ,SHD.RATESECTCSTUNPRCRF" + Environment.NewLine;
                queryString += "    ,SHD.RATEDIVUNCSTRF" + Environment.NewLine;
                queryString += "    ,SHD.UNPRCCALCCDUNCSTRF" + Environment.NewLine;
                queryString += "    ,SHD.PRICECDUNCSTRF" + Environment.NewLine;
                queryString += "    ,SHD.STDUNPRCUNCSTRF" + Environment.NewLine;
                queryString += "    ,SHD.FRACPROCUNITUNCSTRF" + Environment.NewLine;
                queryString += "    ,SHD.FRACPROCUNCSTRF" + Environment.NewLine;
                queryString += "    ,SHD.SALESUNITCOSTRF" + Environment.NewLine;
                queryString += "    ,SHD.SALESUNITCOSTCHNGDIVRF" + Environment.NewLine;
                queryString += "    ,SHD.RATEBLGOODSCODERF" + Environment.NewLine;
                queryString += "    ,SHD.RATEBLGOODSNAMERF" + Environment.NewLine;
                queryString += "    ,SHD.PRTBLGOODSCODERF" + Environment.NewLine;
                queryString += "    ,SHD.PRTBLGOODSNAMERF" + Environment.NewLine;
                queryString += "    ,SHD.SALESCODERF" + Environment.NewLine;
                queryString += "    ,SHD.SALESCDNMRF" + Environment.NewLine;
                queryString += "    ,SHD.WORKMANHOURRF" + Environment.NewLine;
                queryString += "    ,SHD.SHIPMENTCNTRF" + Environment.NewLine;
                queryString += "    ,SHD.SALESMONEYTAXINCRF" + Environment.NewLine;
                queryString += "    ,SHD.SALESMONEYTAXEXCRF" + Environment.NewLine;
                queryString += "    ,SHD.COSTRF" + Environment.NewLine;
                queryString += "    ,SHD.GRSPROFITCHKDIVRF" + Environment.NewLine;
                queryString += "    ,SHD.SALESGOODSCDRF" + Environment.NewLine;
                queryString += "    ,SHD.SALESPRICECONSTAXRF" + Environment.NewLine;
                queryString += "    ,SHD.TAXATIONDIVCDRF" + Environment.NewLine;
                queryString += "    ,SHD.PARTYSLIPNUMDTLRF" + Environment.NewLine;
                queryString += "    ,SHD.DTLNOTERF" + Environment.NewLine;
                queryString += "    ,SHD.SUPPLIERCDRF" + Environment.NewLine;
                queryString += "    ,SHD.SUPPLIERSNMRF" + Environment.NewLine;
                queryString += "    ,SHD.ORDERNUMBERRF" + Environment.NewLine;
                queryString += "    ,SHD.WAYTOORDERRF" + Environment.NewLine;
                queryString += "    ,SHD.SLIPMEMO1RF" + Environment.NewLine;
                queryString += "    ,SHD.SLIPMEMO2RF" + Environment.NewLine;
                queryString += "    ,SHD.SLIPMEMO3RF" + Environment.NewLine;
                queryString += "    ,SHD.INSIDEMEMO1RF" + Environment.NewLine;
                queryString += "    ,SHD.INSIDEMEMO2RF" + Environment.NewLine;
                queryString += "    ,SHD.INSIDEMEMO3RF" + Environment.NewLine;
                queryString += "    ,SHD.BFLISTPRICERF" + Environment.NewLine;
                queryString += "    ,SHD.BFSALESUNITPRICERF" + Environment.NewLine;
                queryString += "    ,SHD.BFUNITCOSTRF" + Environment.NewLine;
                queryString += "    ,SHD.CMPLTSALESROWNORF" + Environment.NewLine;
                queryString += "    ,SHD.CMPLTGOODSMAKERCDRF" + Environment.NewLine;
                queryString += "    ,SHD.CMPLTMAKERNAMERF" + Environment.NewLine;
                queryString += "    ,SHD.CMPLTGOODSNAMERF" + Environment.NewLine;
                queryString += "    ,SHD.CMPLTSHIPMENTCNTRF" + Environment.NewLine;
                queryString += "    ,SHD.CMPLTSALESUNPRCFLRF" + Environment.NewLine;
                queryString += "    ,SHD.CMPLTSALESMONEYRF" + Environment.NewLine;
                queryString += "    ,SHD.CMPLTSALESUNITCOSTRF" + Environment.NewLine;
                queryString += "    ,SHD.CMPLTCOSTRF" + Environment.NewLine;
                queryString += "    ,SHD.CMPLTPARTYSALSLNUMRF" + Environment.NewLine;
                queryString += "    ,SHD.CMPLTNOTERF" + Environment.NewLine;
                queryString += "    ,AOC.CARMNGCODERF" + Environment.NewLine;
                queryString += "    ,AOC.MODELDESIGNATIONNORF" + Environment.NewLine;
                queryString += "    ,AOC.CATEGORYNORF" + Environment.NewLine;
                queryString += "    ,AOC.MAKERFULLNAMERF" + Environment.NewLine;
                queryString += "    ,AOC.FULLMODELRF" + Environment.NewLine;
                queryString += "    ,AOC.MODELFULLNAMERF" + Environment.NewLine;
                queryString += "    ,SHS.ACCRECDIVCDRF" + Environment.NewLine;
                queryString += "    ,SHS.SEARCHSLIPDATERF" + Environment.NewLine;
                queryString += "    ,SHS.SHIPMENTDAYRF" + Environment.NewLine;
                queryString += "    ,SHS.ADDUPADATERF" + Environment.NewLine;
                queryString += "    ,SHS.INPUTAGENCDRF" + Environment.NewLine;
                queryString += "    ,SHS.INPUTAGENNMRF" + Environment.NewLine;
                queryString += "    ,SHS.SALESINPUTCODERF" + Environment.NewLine;
                queryString += "    ,SHS.SALESINPUTNAMERF" + Environment.NewLine;
                queryString += "    ,SHS.FRONTEMPLOYEECDRF" + Environment.NewLine;
                queryString += "    ,SHS.FRONTEMPLOYEENMRF" + Environment.NewLine;
                queryString += "    ,SHS.SALESEMPLOYEECDRF" + Environment.NewLine;
                queryString += "    ,SHS.SALESEMPLOYEENMRF" + Environment.NewLine;
                queryString += "    ,SHS.CLAIMCODERF" + Environment.NewLine;
                queryString += "    ,SHS.CLAIMSNMRF" + Environment.NewLine;
                queryString += "    ,SHS.CUSTOMERCODERF" + Environment.NewLine;
                queryString += "    ,SHS.CUSTOMERSNMRF" + Environment.NewLine;
                queryString += "    ,SHS.DEBITNOTEDIVRF" + Environment.NewLine;
                queryString += "    ,SHD.SALESSLIPDTLNUMRF" + Environment.NewLine;
                queryString += "    ,SHD.ACPTANODRSTATUSSRCRF" + Environment.NewLine;
                queryString += "    ,SHD.SALESSLIPDTLNUMSRCRF" + Environment.NewLine;
                queryString += "    ,SHD.SALESSLIPCDDTLRF" + Environment.NewLine;
                queryString += "    ,SHS.ADDRESSEECODERF" + Environment.NewLine;
                queryString += "    ,SHS.ADDRESSEENAMERF" + Environment.NewLine;
                queryString += "    ,SHS.ADDRESSEENAME2RF" + Environment.NewLine;
                
                if (salHisRefExtraParamWork.AcptAnOdrStatus == 30)
                {
                }
                else
                {
                    // ����ȊO�͔��㖾�׃f�[�^���璊�o����
                    queryString += "    ,SHD.ACPTANODRREMAINCNTRF" + Environment.NewLine;
                }
                
                queryString += " FROM" + Environment.NewLine;
                if (salHisRefExtraParamWork.AcptAnOdrStatus == 30)
                {
                    // 30:����̏ꍇ�͔��㗚�𖾍׃f�[�^���璊�o����
                    queryString += " SALESHISTDTLRF AS SHD" + Environment.NewLine;
                }
                else
                {
                    // ����ȊO�͔��㖾�׃f�[�^���璊�o����
                    queryString += " SALESDETAILRF AS SHD" + Environment.NewLine;
                }

                sqlCommand = new SqlCommand(queryString, sqlConnection);

                //�p�����[�^���FROM��AWHERE�吶��
                string fromClause;
                string whereClause;
                SetFromWhereClause(ref sqlCommand, salHisRefExtraParamWork, out fromClause, out whereClause, logicalMode);
                if (!String.IsNullOrEmpty(fromClause)) sqlCommand.CommandText += fromClause;
                if (!String.IsNullOrEmpty(whereClause)) sqlCommand.CommandText += whereClause;

                //ORDER BY
                sqlCommand.CommandText += SetOrderByClause();

                //���s
                myReader = sqlCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        salHisRefResultParamWorkList.Add(ReaderToSalHisRefResultParamWork(ref myReader,salHisRefExtraParamWork));
                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();

                //�Í����L�[�N���[�Y
                //if (sqlEncriptInfo != null)
                //    if (sqlEncriptInfo.IsOpen) sqlEncriptInfo.CloseSymKey(ref sqlConnection);
            }

            if (sqlConnection == null) return status;
            return status;
        }
        #endregion

        #region [SearchCount]
        /// <summary>
        /// �w�肳�ꂽ�p�����[�^�̏����𖞂������㗚��������߂��܂�
        /// </summary>
        /// <param name="salHisRefExtraParamWork">�����p�����[�^</param>
        /// <param name="retTotalCnt">�����Ώۑ�����</param>
        /// <param name="readMode">�����敪(���g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�ۗ��f�[�^�̂� 3:���S�폜�f�[�^�̂� 4:�S�� 5:���K�f�[�^+�폜�f�[�^ 6:���K�f�[�^+�폜�f�[�^+�ۗ��f�[�^)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�p�����[�^�̏����𖞂������㗚��������߂��܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.10.09</br>
        /// <br></br>
        /// <br>Update Note: 980081 �R�c ���F</br>
        /// <br>Date       : 2007.12.13</br>
        /// <br>             �_���폜�敪�̃`�F�b�N��ǉ�</br>
        public int SearchCount(object salHisRefExtraParamWork, out int retTotalCnt, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            retTotalCnt = 0;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //�������s
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = GetSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchCount((SalHisRefExtraParamWork)salHisRefExtraParamWork, out retTotalCnt, ref sqlConnection, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalHisRefDB.SearchCount");
                return status;
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
        /// �w�肳�ꂽ�p�����[�^�̏����𖞂������㗚��������߂��܂�
        /// </summary>
        /// <param name="salHisRefExtraParamWork">�����p�����[�^</param>
        /// <param name="retTotalCnt">�����Ώۑ�����</param>
        /// <param name="sqlConnection">SQL�ڑ����</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�ۗ��f�[�^�̂� 3:���S�폜�f�[�^�̂� 4:�S�� 5:���K�f�[�^+�폜�f�[�^ 6:���K�f�[�^+�폜�f�[�^+�ۗ��f�[�^)</param>
        /// <returns>STATUS</returns>
        private int SearchCount(SalHisRefExtraParamWork salHisRefExtraParamWork, out int retTotalCnt, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            retTotalCnt = 0;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            //SqlEncryptInfo sqlEncriptInfo = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                //�Í����L�[OPEN
                //sqlEncriptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "SALESHISTDTLRF", "SALESHISTORYRF" });
                //sqlEncriptInfo.OpenSymKey(ref sqlConnection);

                //�N�G�������񐶐�
                string queryString = "SELECT COUNT(DISTINCT SHD.SALESSLIPNUMRF) FROM SALESHISTDTLRF SHD";

                sqlCommand = new SqlCommand(queryString, sqlConnection);

                //�p�����[�^���FROM��AWHERE�吶��
                string fromClause;
                string whereClause;
                // �� 2007.12.13 c
                //SetFromWhereClause(ref sqlCommand, salHisRefExtraParamWork, out fromClause, out whereClause);
                SetFromWhereClause(ref sqlCommand, salHisRefExtraParamWork, out fromClause, out whereClause, logicalMode);
                // �� 2007.12.13 c
                if (!String.IsNullOrEmpty(fromClause)) sqlCommand.CommandText += fromClause;
                if (!String.IsNullOrEmpty(whereClause)) sqlCommand.CommandText += whereClause;

                //���s
                retTotalCnt = (int)sqlCommand.ExecuteScalar();
                if (retTotalCnt > 0)
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();

                //�Í����L�[�N���[�Y
                //if (sqlEncriptInfo != null)
                //    if (sqlEncriptInfo.IsOpen) sqlEncriptInfo.CloseSymKey(ref sqlConnection);
            }

            if (sqlConnection == null) return status;
            return status;
        }
        #endregion
        */
        #endregion

        #region �N�G�������񐶐�
        /// <summary>
        /// �p�����[�^���A���I��FROM��AWHERE��𐶐�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand �I�u�W�F�N�g</param>
        /// <param name="salHisRefExtraParamWork">�����p�����[�^</param>
        /// <param name="fromClause">FROM��N�G��������</param>
        /// <param name="whereClause">WHERE��N�G��������</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�ۗ��f�[�^�̂� 3:���S�폜�f�[�^�̂� 4:�S�� 5:���K�f�[�^+�폜�f�[�^ 6:���K�f�[�^+�폜�f�[�^+�ۗ��f�[�^)</param>
        /// <br>Update Note: 2011/11/11 ���N�n�� BL�߰µ��ް�݌Ɋm�F���̌��ϓ`�[�Ή�</br>
        /// <br>Update Note: �Ǘ��ԍ� : 11900025-00 �쐬�S�� : 3H ����</br>
        /// <br>           : �C�����e : READUNCOMMITTED�Ή�</br>
        /// <br>Date       : 2023/11/07</br>
        private void SetFromWhereClause(ref SqlCommand sqlCommand, SalHisRefExtraParamWork salHisRefExtraParamWork, out string fromClause, out string whereClause, ConstantManagement.LogicalMode logicalMode)
        {
            fromClause = String.Empty;
            whereClause = String.Empty;

            string from_detail = string.Empty;
            if (salHisRefExtraParamWork.AcptAnOdrStatus == 30)
            {
                // 30:����̏ꍇ�͔��㗚���f�[�^���璊�o����                                                                                                                            
                //from_detail += " LEFT JOIN SALESHISTORYRF SHS ON (SHD.ENTERPRISECODERF=SHS.ENTERPRISECODERF AND SHD.ACPTANODRSTATUSRF=SHS.ACPTANODRSTATUSRF AND SHD.SALESSLIPNUMRF=SHS.SALESSLIPNUMRF)" + Environment.NewLine;//  DEL 3H ���� 2023/11/07
                from_detail += " LEFT JOIN SALESHISTORYRF SHS WITH (READUNCOMMITTED) ON (SHD.ENTERPRISECODERF=SHS.ENTERPRISECODERF AND SHD.ACPTANODRSTATUSRF=SHS.ACPTANODRSTATUSRF AND SHD.SALESSLIPNUMRF=SHS.SALESSLIPNUMRF)" + Environment.NewLine;//  ADD 3H ���� 2023/11/07
            }
            else
            {
                // ����ȊO�͔���f�[�^���璊�o����
                //from_detail += " LEFT JOIN SALESSLIPRF SHS ON (SHD.ENTERPRISECODERF=SHS.ENTERPRISECODERF AND SHD.ACPTANODRSTATUSRF=SHS.ACPTANODRSTATUSRF AND SHD.SALESSLIPNUMRF=SHS.SALESSLIPNUMRF)" + Environment.NewLine;//  DEL 3H ���� 2023/11/07
                from_detail += " LEFT JOIN SALESSLIPRF SHS WITH (READUNCOMMITTED) ON (SHD.ENTERPRISECODERF=SHS.ENTERPRISECODERF AND SHD.ACPTANODRSTATUSRF=SHS.ACPTANODRSTATUSRF AND SHD.SALESSLIPNUMRF=SHS.SALESSLIPNUMRF)" + Environment.NewLine;//  ADD 3H ���� 2023/11/07
            }
            //from_detail += " LEFT JOIN ACCEPTODRCARRF AOC ON (SHD.ENTERPRISECODERF=AOC.ENTERPRISECODERF AND SHD.ACPTANODRSTATUSRF=AOC.ACPTANODRSTATUSRF AND SHD.ACCEPTANORDERNORF=AOC.ACCEPTANORDERNORF)";�@// 2008.11.13
            // ADD 2008.11.13 >>>
            //from_detail += " LEFT JOIN ACCEPTODRCARRF AOC ON (" + Environment.NewLine;//  DEL 3H ���� 2023/11/07
            from_detail += " LEFT JOIN ACCEPTODRCARRF AOC WITH (READUNCOMMITTED) ON (" + Environment.NewLine;//  ADD 3H ���� 2023/11/07
            from_detail += "SHD.ENTERPRISECODERF=AOC.ENTERPRISECODERF  " + Environment.NewLine;
            from_detail += "AND SHD.ACCEPTANORDERNORF=AOC.ACCEPTANORDERNORF" + Environment.NewLine;
            from_detail += "AND (" + Environment.NewLine;
            from_detail += "      (SHD.ACPTANODRSTATUSRF = 10 AND AOC.ACPTANODRSTATUSRF = 1) " + Environment.NewLine; //�@����
            from_detail += "      OR (SHD.ACPTANODRSTATUSRF = 20 AND AOC.ACPTANODRSTATUSRF = 3)" + Environment.NewLine; // ��
            from_detail += "      OR (SHD.ACPTANODRSTATUSRF = 30 AND AOC.ACPTANODRSTATUSRF = 7)" + Environment.NewLine; // ����
            from_detail += "      OR (SHD.ACPTANODRSTATUSRF = 40 AND AOC.ACPTANODRSTATUSRF = 5)" + Environment.NewLine; // �o�ׁ@
            from_detail += "    )" + Environment.NewLine;            
            from_detail += ")" + Environment.NewLine;
            // ADD 2008.11.13 <<<
            // �C�� 2009/05/18 >>>
            //from_detail += "LEFT JOIN SECINFOSETRF AS SEC ON (SHD.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND SHD.SECTIONCODERF=SEC.SECTIONCODERF)" + Environment.NewLine;
            //from_detail += "LEFT JOIN SECINFOSETRF AS SEC ON (SHS.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND SHS.RESULTSADDUPSECCDRF=SEC.SECTIONCODERF)" + Environment.NewLine;//  DEL 3H ���� 2023/11/07
            from_detail += "LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) ON (SHS.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND SHS.RESULTSADDUPSECCDRF=SEC.SECTIONCODERF)" + Environment.NewLine;//  ADD 3H ���� 2023/11/07
            // �C�� 2009/05/18 <<<
            // -- UPD 2010/05/10 --------------------------------------------->>>
            //from_detail += "LEFT JOIN SUBSECTIONRF AS SUB ON (SHD.ENTERPRISECODERF=SUB.ENTERPRISECODERF AND SHD.SECTIONCODERF=SUB.SECTIONCODERF AND SHD.SUBSECTIONCODERF=SUB.SUBSECTIONCODERF)" + Environment.NewLine;
            //from_detail += "LEFT JOIN SUBSECTIONRF AS SUB ON (SHS.ENTERPRISECODERF=SUB.ENTERPRISECODERF AND SHS.SUBSECTIONCODERF=SUB.SUBSECTIONCODERF)" + Environment.NewLine;//  DEL 3H ���� 2023/11/07
            from_detail += "LEFT JOIN SUBSECTIONRF AS SUB WITH (READUNCOMMITTED) ON (SHS.ENTERPRISECODERF=SUB.ENTERPRISECODERF AND SHS.SUBSECTIONCODERF=SUB.SUBSECTIONCODERF)" + Environment.NewLine;//  ADD 3H ���� 2023/11/07
            // -- UPD 2010/05/10 ---------------------------------------------<<<
            fromClause += from_detail;

            #region �p�����[�^���
            //��ƃR�[�h
            if (IsValidParameter(salHisRefExtraParamWork.EnterpriseCode))
            {
                // -- UPD 2010/05/10 ------------------------------------------------------>>>
                //ConnectWhereClause(ref whereClause, "SHD.ENTERPRISECODERF=@FINDENTERPRISECODE");
                ConnectWhereClause(ref whereClause, "SHS.ENTERPRISECODERF=@FINDENTERPRISECODE");
                // -- UPD 2010/05/10 ------------------------------------------------------<<<
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(salHisRefExtraParamWork.EnterpriseCode);
            }
            //�_���폜�敪
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                // -- UPD 2010/05/10 ------------------------------------------------------>>>
                //ConnectWhereClause(ref whereClause, "SHD.LOGICALDELETECODERF=@FINDLOGICALDELETECODE");
                ConnectWhereClause(ref whereClause, "SHS.LOGICALDELETECODERF=@FINDLOGICALDELETECODE");
                // -- UPD 2010/05/10 ------------------------------------------------------<<<
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                // -- UPD 2010/05/10 ------------------------------------------------------>>>
                //ConnectWhereClause(ref whereClause, "SHD.LOGICALDELETECODERF<@FINDLOGICALDELETECODE");
                ConnectWhereClause(ref whereClause, "SHS.LOGICALDELETECODERF<@FINDLOGICALDELETECODE");
                // -- UPD 2010/05/10 ------------------------------------------------------<<<
            }
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);

            //���_�R�[�h
            if (IsValidParameter(salHisRefExtraParamWork.SectionCode))
            {
                // �C�� 2009/05/18 >>>
                //ConnectWhereClause(ref whereClause, "SHD.SECTIONCODERF=@FINDSECTIONCODE");
                ConnectWhereClause(ref whereClause, "SHS.RESULTSADDUPSECCDRF=@FINDSECTIONCODE");
                // �C�� 2009/05/18 <<<
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(salHisRefExtraParamWork.SectionCode);
            }
            //����R�[�h
            if (IsValidParameter(salHisRefExtraParamWork.SubSectionCode, false))
            {
                ConnectWhereClause(ref whereClause, "SHD.SUBSECTIONCODERF=@FINDSUBSECTIONCODE");
                SqlParameter findParaSubSectionCode = sqlCommand.Parameters.Add("@FINDSUBSECTIONCODE", SqlDbType.Int);
                findParaSubSectionCode.Value = SqlDataMediator.SqlSetInt32(salHisRefExtraParamWork.SubSectionCode);
            }
            //���Ӑ�R�[�h
            if (IsValidParameter(salHisRefExtraParamWork.CustomerCode, false))
            {
                ConnectWhereClause(ref whereClause, "SHS.CUSTOMERCODERF=@FINDCUSTOMERCODE");
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(salHisRefExtraParamWork.CustomerCode);
            }
            //�����(�J�n)
            if (IsValidParameter(salHisRefExtraParamWork.SalesDateSt, false))
            {
                // -- UPD 2010/05/10 --------------------------------------->>>
                //ConnectWhereClause(ref whereClause, "((SHD.ACPTANODRSTATUSRF <> 40 AND SHD.SALESDATERF>=@FINDSALESHDATEST) OR (SHD.ACPTANODRSTATUSRF = 40 AND SHS.SHIPMENTDAYRF>=@FINDSALESHDATEST))");
                //SqlParameter findParaSalesDateSt = sqlCommand.Parameters.Add("@FINDSALESHDATEST", SqlDbType.Int);
                //findParaSalesDateSt.Value = SqlDataMediator.SqlSetInt32(salHisRefExtraParamWork.SalesDateSt);

                if (salHisRefExtraParamWork.AcptAnOdrStatus == 30)
                {
                    ConnectWhereClause(ref whereClause, "SHS.SALESDATERF>=" + SqlDataMediator.SqlSetInt32(salHisRefExtraParamWork.SalesDateSt).ToString());
                }
                else
                {
                    ConnectWhereClause(ref whereClause, "((SHS.ACPTANODRSTATUSRF <> 40 AND SHS.SALESDATERF>=@FINDSALESHDATEST) OR (SHS.ACPTANODRSTATUSRF = 40 AND SHS.SHIPMENTDAYRF>=@FINDSALESHDATEST))");
                    SqlParameter findParaSalesDateSt = sqlCommand.Parameters.Add("@FINDSALESHDATEST", SqlDbType.Int);
                    findParaSalesDateSt.Value = SqlDataMediator.SqlSetInt32(salHisRefExtraParamWork.SalesDateSt);
                }
                // -- UPD 2010/05/10 ---------------------------------------<<<

            }
            //�����(�I��)
            if (IsValidParameter(salHisRefExtraParamWork.SalesDateEd, false))
            {
                // -- UPD 2010/05/10 --------------------------------------->>>
                //ConnectWhereClause(ref whereClause, "((SHD.ACPTANODRSTATUSRF <> 40 AND SHD.SALESDATERF<=@FINDSALESHDATEED) OR (SHD.ACPTANODRSTATUSRF = 40 AND SHS.SHIPMENTDAYRF<=@FINDSALESHDATEED))");
                //SqlParameter findParaSalesDateEd = sqlCommand.Parameters.Add("@FINDSALESHDATEED", SqlDbType.Int);
                //findParaSalesDateEd.Value = SqlDataMediator.SqlSetInt32(salHisRefExtraParamWork.SalesDateEd);

                if (salHisRefExtraParamWork.AcptAnOdrStatus == 30)
                {
                    ConnectWhereClause(ref whereClause, "SHS.SALESDATERF<=" + SqlDataMediator.SqlSetInt32(salHisRefExtraParamWork.SalesDateEd).ToString());
                }
                else
                {
                    ConnectWhereClause(ref whereClause, "((SHS.ACPTANODRSTATUSRF <> 40 AND SHS.SALESDATERF<=@FINDSALESHDATEED) OR (SHS.ACPTANODRSTATUSRF = 40 AND SHS.SHIPMENTDAYRF<=@FINDSALESHDATEED))");
                    SqlParameter findParaSalesDateEd = sqlCommand.Parameters.Add("@FINDSALESHDATEED", SqlDbType.Int);
                    findParaSalesDateEd.Value = SqlDataMediator.SqlSetInt32(salHisRefExtraParamWork.SalesDateEd);
                }
                // -- UPD 2010/05/10 ---------------------------------------<<<
            }
            //���i���[�J�[�R�[�h
            if (IsValidParameter(salHisRefExtraParamWork.GoodsMakerCd, false))
            {
                ConnectWhereClause(ref whereClause, "SHD.GOODSMAKERCDRF=@FINDGOODSMAKERCD");
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(salHisRefExtraParamWork.GoodsMakerCd);
            }
            //����`�[�ԍ�(�J�n)
            if (IsValidParameter(salHisRefExtraParamWork.SalesSlipNumSt))
            {
                ConnectWhereClause(ref whereClause, "SHD.SALESSLIPNUMRF>=@FINDSALESHSLIPNUMST");
                SqlParameter findParaSalesSlipNumSt = sqlCommand.Parameters.Add("@FINDSALESHSLIPNUMST", SqlDbType.NChar);
                findParaSalesSlipNumSt.Value = SqlDataMediator.SqlSetString(salHisRefExtraParamWork.SalesSlipNumSt);
            }
            //����`�[�ԍ�(�I��)
            if (IsValidParameter(salHisRefExtraParamWork.SalesSlipNumEd))
            {
                ConnectWhereClause(ref whereClause, "SHD.SALESSLIPNUMRF<=@FINDSALESHSLIPNUMED");
                SqlParameter findParaSalesSlipNumEd = sqlCommand.Parameters.Add("@FINDSALESHSLIPNUMED", SqlDbType.NChar);
                findParaSalesSlipNumEd.Value = SqlDataMediator.SqlSetString(salHisRefExtraParamWork.SalesSlipNumEd);
            }
            //������R�[�h
            if (IsValidParameter(salHisRefExtraParamWork.ClaimCode, false))
            {
                ConnectWhereClause(ref whereClause, "SHS.CLAIMCODERF=@FINDCLAIMCODE");
                SqlParameter findParaClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(salHisRefExtraParamWork.ClaimCode);
            }
            //�����`�[�ԍ�
            if (IsValidParameter(salHisRefExtraParamWork.PartySaleSlipNum))
            {
                ConnectWhereClause(ref whereClause, "SHD.PARTYSALESLIPNUMRF=@FINDPARTYSALESLIPNUM");
                SqlParameter findParaPartySaleSlipNum = sqlCommand.Parameters.Add("@FINDPARTYSALESLIPNUM", SqlDbType.NChar);
                findParaPartySaleSlipNum.Value = SqlDataMediator.SqlSetString(salHisRefExtraParamWork.PartySaleSlipNum);
            }

            //�i��
            if (string.IsNullOrEmpty(salHisRefExtraParamWork.GoodsNo) == false)
            {
                ConnectWhereClause(ref whereClause, " SHD.GOODSNORF LIKE @FINDGOODSNO");
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                //�O����v�����̏ꍇ
                if (salHisRefExtraParamWork.GoodsNoSrchTyp == 1) salHisRefExtraParamWork.GoodsNo = salHisRefExtraParamWork.GoodsNo + "%";
                //�����v�����̏ꍇ
                if (salHisRefExtraParamWork.GoodsNoSrchTyp == 2) salHisRefExtraParamWork.GoodsNo = "%" + salHisRefExtraParamWork.GoodsNo;
                //�B�������̏ꍇ
                if (salHisRefExtraParamWork.GoodsNoSrchTyp == 3) salHisRefExtraParamWork.GoodsNo = "%" + salHisRefExtraParamWork.GoodsNo + "%";

                paraGoodsNo.Value = SqlDataMediator.SqlSetString(salHisRefExtraParamWork.GoodsNo);
            }

            //�i��
            if (string.IsNullOrEmpty(salHisRefExtraParamWork.GoodsName) == false)
            {
                ConnectWhereClause(ref whereClause, " SHD.GOODSNAMERF LIKE @FINDGOODSNAME");
                SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@FINDGOODSNAME", SqlDbType.NVarChar);
                //�O����v�����̏ꍇ
                if (salHisRefExtraParamWork.GoodsNameSrchTyp == 1) salHisRefExtraParamWork.GoodsName = salHisRefExtraParamWork.GoodsName + "%";
                //�����v�����̏ꍇ
                if (salHisRefExtraParamWork.GoodsNameSrchTyp == 2) salHisRefExtraParamWork.GoodsName = "%" + salHisRefExtraParamWork.GoodsName;
                //�B�������̏ꍇ
                if (salHisRefExtraParamWork.GoodsNameSrchTyp == 3) salHisRefExtraParamWork.GoodsName = "%" + salHisRefExtraParamWork.GoodsName + "%";

                paraGoodsName.Value = SqlDataMediator.SqlSetString(salHisRefExtraParamWork.GoodsName);
            }

            //��t�]�ƈ��R�[�h
            if (IsValidParameter(salHisRefExtraParamWork.FrontEmployeeCd))
            {
                ConnectWhereClause(ref whereClause, "SHS.FRONTEMPLOYEECDRF=@FINDFRONTEMPLOYEECD");
                SqlParameter findParaFrontEmployeeCd = sqlCommand.Parameters.Add("@FINDFRONTEMPLOYEECD", SqlDbType.NChar);
                findParaFrontEmployeeCd.Value = SqlDataMediator.SqlSetString(salHisRefExtraParamWork.FrontEmployeeCd);
            }
            //�̔��]�ƈ��R�[�h
            if (IsValidParameter(salHisRefExtraParamWork.SalesEmployeeCd))
            {
                ConnectWhereClause(ref whereClause, "SHS.SALESEMPLOYEECDRF=@FINDSALESEMPLOYEECD");
                SqlParameter findParaSalesEmployeeCd = sqlCommand.Parameters.Add("@FINDSALESEMPLOYEECD", SqlDbType.NChar);
                findParaSalesEmployeeCd.Value = SqlDataMediator.SqlSetString(salHisRefExtraParamWork.SalesEmployeeCd);
            }
            //������͎҃R�[�h
            if (IsValidParameter(salHisRefExtraParamWork.SalesInputCode))
            {
                ConnectWhereClause(ref whereClause, "SHS.SALESINPUTCODERF=@FINDSALESINPUTCODE");
                SqlParameter findParaSalesInputCode = sqlCommand.Parameters.Add("@FINDSALESINPUTCODE", SqlDbType.NChar);
                findParaSalesInputCode.Value = SqlDataMediator.SqlSetString(salHisRefExtraParamWork.SalesInputCode);
            }
            //���͓�(�J�n)
            if (IsValidParameter(salHisRefExtraParamWork.SearchSlipDateSt, false))
            {
                ConnectWhereClause(ref whereClause, "SHS.SEARCHSLIPDATERF>=@FINDSEARCHSLIPDATEST");
                SqlParameter findParaSearchSlipDateSt = sqlCommand.Parameters.Add("@FINDSEARCHSLIPDATEST", SqlDbType.Int);
                findParaSearchSlipDateSt.Value = SqlDataMediator.SqlSetInt32(salHisRefExtraParamWork.SearchSlipDateSt);
            }
            //���͓�(�I��)
            if (IsValidParameter(salHisRefExtraParamWork.SearchSlipDateEd, false))
            {
                ConnectWhereClause(ref whereClause, "SHS.SEARCHSLIPDATERF<=@FINDSEARCHSLIPDATEED");
                SqlParameter findParaSearchSlipDateEd = sqlCommand.Parameters.Add("@FINDSEARCHSLIPDATEED", SqlDbType.Int);
                findParaSearchSlipDateEd.Value = SqlDataMediator.SqlSetInt32(salHisRefExtraParamWork.SearchSlipDateEd);
            }
            //����`�[�敪
            if (IsValidParameter(salHisRefExtraParamWork.SalesSlipCd, true))
            {
                ConnectWhereClause(ref whereClause, "SHS.SALESSLIPCDRF=@FINDSALESSLIPCD");
                SqlParameter findParaSalesSlipCd = sqlCommand.Parameters.Add("@FINDSALESSLIPCD", SqlDbType.Int);
                findParaSalesSlipCd.Value = SqlDataMediator.SqlSetInt32(salHisRefExtraParamWork.SalesSlipCd);
            }
            //���|�敪
            if (IsValidParameter(salHisRefExtraParamWork.AccRecDivCd, true))
            {
                ConnectWhereClause(ref whereClause, "SHS.ACCRECDIVCDRF=@FINDACCRECDIVCD");
                SqlParameter findParaAccRecDivCd = sqlCommand.Parameters.Add("@FINDACCRECDIVCD", SqlDbType.Int);
                findParaAccRecDivCd.Value = SqlDataMediator.SqlSetInt32(salHisRefExtraParamWork.AccRecDivCd);
            }

            //---ADD 2011/11/11 ------------------------------------->>>>>
            if (salHisRefExtraParamWork.AutoAnswerDivSCM == 0)
            {
                whereClause += (" AND SHD.AUTOANSWERDIVSCMRF=0");
            }
            if (salHisRefExtraParamWork.AutoAnswerDivSCM == 1)
            {
                if (salHisRefExtraParamWork.AcceptOrOrderKind == -1)
                {
                    whereClause += (" AND SHD.AUTOANSWERDIVSCMRF=0");
                }
                else if (salHisRefExtraParamWork.AcceptOrOrderKind == 0)
                {
                    whereClause += (" AND (SHD.AUTOANSWERDIVSCMRF= 0 OR (SHD.AUTOANSWERDIVSCMRF<> 0 AND SHD.ACCEPTORORDERKINDRF=0))");
                }
                else if (salHisRefExtraParamWork.AcceptOrOrderKind == 1)
                {
                    whereClause += (" AND (SHD.AUTOANSWERDIVSCMRF= 0 OR (SHD.AUTOANSWERDIVSCMRF<> 0 AND SHD.ACCEPTORORDERKINDRF=1))");
                    
                }
                else if (salHisRefExtraParamWork.AcceptOrOrderKind == 2)
                {
                    whereClause += (" AND (SHD.AUTOANSWERDIVSCMRF=0 OR SHD.AUTOANSWERDIVSCMRF=1 OR SHD.AUTOANSWERDIVSCMRF=2)");

                }
            }
            if (salHisRefExtraParamWork.AutoAnswerDivSCM == 2)
            {
                if (salHisRefExtraParamWork.AcceptOrOrderKind == -1)
                {
                    whereClause += (" AND SHD.AcceptOrOrderKind = -1");
                }
                else if (salHisRefExtraParamWork.AcceptOrOrderKind == 0)
                {
                    whereClause += (" AND ((SHD.ACCEPTORORDERKINDRF=0 ) AND  SHD.AUTOANSWERDIVSCMRF <>0)");
                }
                else if (salHisRefExtraParamWork.AcceptOrOrderKind == 1)
                {
                    whereClause += (" AND ((SHD.ACCEPTORORDERKINDRF=1 ) AND  SHD.AUTOANSWERDIVSCMRF <>0)");
                }
                else if (salHisRefExtraParamWork.AcceptOrOrderKind == 2)
                {
                    whereClause += (" AND ((SHD.ACCEPTORORDERKINDRF=0 OR SHD.ACCEPTORORDERKINDRF=1) AND  SHD.AUTOANSWERDIVSCMRF <>0)");
                }
            }
            //---ADD 2011/11/11 -------------------------------------<<<<<

            //�󒍃X�e�[�^�X
            if (IsValidParameter(salHisRefExtraParamWork.AcptAnOdrStatus, false))
            {
                //�󒍃X�e�[�^�X10:���ς̏ꍇ�́A�P�����ψȊO�𒊏o
                if (salHisRefExtraParamWork.AcptAnOdrStatus == 10)
                {
                    ConnectWhereClause(ref whereClause, "SHS.ESTIMATEDIVIDERF<>2");
                }

                //�󒍃X�e�[�^�X15:�P�����ς̏ꍇ�́A�󒍃X�e�[�^�X��10:���ςɂ���
                if (salHisRefExtraParamWork.AcptAnOdrStatus == 15)
                {
                    salHisRefExtraParamWork.AcptAnOdrStatus = 10;
                    ConnectWhereClause(ref whereClause, "SHS.ESTIMATEDIVIDERF=2");
                }

                // -- UPD 2010/05/10 ----------------------------------------------->>>
                //ConnectWhereClause(ref whereClause, "SHD.ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS");
                ConnectWhereClause(ref whereClause, "SHS.ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS");
                // -- UPD 2010/05/10 -----------------------------------------------<<<
                SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                findParaAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(salHisRefExtraParamWork.AcptAnOdrStatus);
            }
            else
            {
                //�S�Ă̏ꍇ�́A����A�󒍂͒��o���Ȃ�
                //�S�Ă̏ꍇ�̔���̓p�����[�^�̎󒍃X�e�[�^�X��30:����ɕύX���āA�Q��ڂ̃��[�v�Œ��o
                //ConnectWhereClause(ref whereClause, "(SHD.ACPTANODRSTATUSRF<>30 AND SHD.ACPTANODRSTATUSRF<>20)");
                // -- UPD 2010/05/10 ----------------------------------------------->>>
                //ConnectWhereClause(ref whereClause, "(SHD.ACPTANODRSTATUSRF<>30)");
                ConnectWhereClause(ref whereClause, "(SHS.ACPTANODRSTATUSRF<>30)");
                // -- UPD 2010/05/10 -----------------------------------------------<<<
            }

            //�^��
            if (string.IsNullOrEmpty(salHisRefExtraParamWork.FullModel) == false)
            {
                ConnectWhereClause(ref whereClause, "AOC.FULLMODELRF LIKE @FINDFULLMODEL");
                SqlParameter paraFullModel = sqlCommand.Parameters.Add("@FINDFULLMODEL", SqlDbType.NVarChar);
                //�O����v�����̏ꍇ
                if (salHisRefExtraParamWork.FullModelSrchTyp == 1) salHisRefExtraParamWork.FullModel = salHisRefExtraParamWork.FullModel + "%";
                //�����v�����̏ꍇ
                if (salHisRefExtraParamWork.FullModelSrchTyp == 2) salHisRefExtraParamWork.FullModel = "%" + salHisRefExtraParamWork.FullModel;
                //�B�������̏ꍇ
                if (salHisRefExtraParamWork.FullModelSrchTyp == 3) salHisRefExtraParamWork.FullModel = "%" + salHisRefExtraParamWork.FullModel + "%";

                paraFullModel.Value = SqlDataMediator.SqlSetString(salHisRefExtraParamWork.FullModel);
            }

            // --- DEL 2014/04/17 Y.Wakita ---------->>>>>
            ////�ꎮ�f�[�^(�ꎮ���הԍ�=0)
            //ConnectWhereClause(ref whereClause, "SHD.CMPLTSALESROWNORF=0");
            // --- DEL 2014/04/17 Y.Wakita ----------<<<<<

            //�v��c�敪
            if (salHisRefExtraParamWork.AddUpRemDiv != 0)
            {
                //�c����
                if (salHisRefExtraParamWork.AddUpRemDiv == 1)
                {
                    ConnectWhereClause(ref whereClause, "SHD.ACPTANODRREMAINCNTRF>0");
                }
                else
                //�v��ς�
                if (salHisRefExtraParamWork.AddUpRemDiv == 2)
                {
                    ConnectWhereClause(ref whereClause, "SHD.ACPTANODRREMAINCNTRF<=0");
                }
            }

            #endregion

        }

        /// <summary>
        /// WHERE���ڑ�����
        /// </summary>
        private void ConnectWhereClause(ref string whereClause, string addition)
        {
            if (String.IsNullOrEmpty(whereClause))
                whereClause += " WHERE " + addition;
            else
                whereClause += " AND " + addition;
        }
        /// <summary>
        /// ORDER BY ��𐶐�����
        /// </summary>
        /// <returns>ORDER BY ��</returns>
        private string SetOrderByClause()
        {
            return " ORDER BY SHD.ENTERPRISECODERF, SHD.SALESSLIPNUMRF, SHD.SALESROWNORF";
        }

        /// <summary>
        /// string���L���ȃp�����[�^���ǂ����𔻒f����
        /// </summary>
        private bool IsValidParameter(string value)
        {
            return !String.IsNullOrEmpty(value);
        }
        /// <summary>
        /// int���L���ȃp�����[�^���ǂ����𔻒f����
        /// </summary>
        /// <param name="value">�p�����[�^</param>
        /// <param name="includeZero">0���܂ނ��ǂ���(true:0�L�� false:0����)</param>
        private bool IsValidParameter(int value, bool includeZero)
        {
            if (includeZero)
                return value >= 0;
            else
                return value > 0;
        }
        /// <summary>
        /// DateTime���L���ȃp�����[�^���ǂ����𔻒f����
        /// </summary>
        private bool IsValidParameter(DateTime value)
        {
            return value > DateTime.MinValue;
        }
        #endregion

        #region �f�[�^�Z�b�g
        /// <summary>
        /// SqlDataReader �� SalHisRefResultParamWork �ɕϊ�
        /// </summary>
        /// <param name="myReader">���o���� SqlDataReader</param>
        /// <param name="salHisRefExtraParamWork">�����N���X</param>
        /// <returns>�f�[�^�Z�b�g�ς� SalHisRefResultParamWork �I�u�W�F�N�g</returns>
        /// <br>Update Note: 2011/11/11 ���N�n�� BL�߰µ��ް�݌Ɋm�F���̌��ϓ`�[�Ή�</br>
        private SalHisRefResultParamWork ReaderToSalHisRefResultParamWork(ref SqlDataReader myReader, SalHisRefExtraParamWork salHisRefExtraParamWork)
        {
            SalHisRefResultParamWork salHisRefResultParamWork = new SalHisRefResultParamWork();

            #region SalHisRefResultParamWork�ɑ��
            salHisRefResultParamWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            salHisRefResultParamWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            salHisRefResultParamWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
            salHisRefResultParamWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
            salHisRefResultParamWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
            salHisRefResultParamWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));
            salHisRefResultParamWork.SalesRowDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWDERIVNORF"));
            salHisRefResultParamWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            salHisRefResultParamWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            salHisRefResultParamWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
            salHisRefResultParamWork.SubSectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUBSECTIONNAMERF"));
            salHisRefResultParamWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
            salHisRefResultParamWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));
            salHisRefResultParamWork.SalesSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMRF"));
            salHisRefResultParamWork.AcptAnOdrStatusSrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSSRCRF"));
            salHisRefResultParamWork.SalesSlipDtlNumSrc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMSRCRF"));
            salHisRefResultParamWork.SupplierFormalSync = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALSYNCRF"));
            salHisRefResultParamWork.StockSlipDtlNumSync = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMSYNCRF"));
            salHisRefResultParamWork.SalesSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDDTLRF"));
            salHisRefResultParamWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
            salHisRefResultParamWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            salHisRefResultParamWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            salHisRefResultParamWork.MakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERKANANAMERF"));
            salHisRefResultParamWork.CmpltMakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTMAKERKANANAMERF"));
            salHisRefResultParamWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            salHisRefResultParamWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            salHisRefResultParamWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
            salHisRefResultParamWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
            salHisRefResultParamWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSLGROUPNAMERF"));
            salHisRefResultParamWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
            salHisRefResultParamWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));
            salHisRefResultParamWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            salHisRefResultParamWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPNAMERF"));
            salHisRefResultParamWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            salHisRefResultParamWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
            salHisRefResultParamWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
            salHisRefResultParamWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISEGANRENAMERF"));
            salHisRefResultParamWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            salHisRefResultParamWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            salHisRefResultParamWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
            salHisRefResultParamWork.SalesOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERDIVCDRF"));
            salHisRefResultParamWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
            salHisRefResultParamWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
            salHisRefResultParamWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
            salHisRefResultParamWork.ListPriceRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERATERF"));
            salHisRefResultParamWork.RateSectPriceUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESECTPRICEUNPRCRF"));
            salHisRefResultParamWork.RateDivLPrice = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEDIVLPRICERF"));
            salHisRefResultParamWork.UnPrcCalcCdLPrice = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCCALCCDLPRICERF"));
            salHisRefResultParamWork.PriceCdLPrice = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECDLPRICERF"));
            salHisRefResultParamWork.StdUnPrcLPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCLPRICERF"));
            salHisRefResultParamWork.FracProcUnitLPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACPROCUNITLPRICERF"));
            salHisRefResultParamWork.FracProcLPrice = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCLPRICERF"));
            salHisRefResultParamWork.ListPriceTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXINCFLRF"));
            salHisRefResultParamWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
            salHisRefResultParamWork.ListPriceChngCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LISTPRICECHNGCDRF"));
            salHisRefResultParamWork.SalesRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESRATERF"));
            salHisRefResultParamWork.RateSectSalUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESECTSALUNPRCRF"));
            salHisRefResultParamWork.RateDivSalUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEDIVSALUNPRCRF"));
            salHisRefResultParamWork.UnPrcCalcCdSalUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCCALCCDSALUNPRCRF"));
            salHisRefResultParamWork.PriceCdSalUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECDSALUNPRCRF"));
            salHisRefResultParamWork.StdUnPrcSalUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCSALUNPRCRF"));
            salHisRefResultParamWork.FracProcUnitSalUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACPROCUNITSALUNPRCRF"));
            salHisRefResultParamWork.FracProcSalUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCSALUNPRCRF"));
            salHisRefResultParamWork.SalesUnPrcTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXINCFLRF"));
            salHisRefResultParamWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
            salHisRefResultParamWork.SalesUnPrcChngCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESUNPRCCHNGCDRF"));
            salHisRefResultParamWork.CostRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("COSTRATERF"));
            salHisRefResultParamWork.RateSectCstUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESECTCSTUNPRCRF"));
            salHisRefResultParamWork.RateDivUnCst = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEDIVUNCSTRF"));
            salHisRefResultParamWork.UnPrcCalcCdUnCst = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCCALCCDUNCSTRF"));
            salHisRefResultParamWork.PriceCdUnCst = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECDUNCSTRF"));
            salHisRefResultParamWork.StdUnPrcUnCst = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCUNCSTRF"));
            salHisRefResultParamWork.FracProcUnitUnCst = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACPROCUNITUNCSTRF"));
            salHisRefResultParamWork.FracProcUnCst = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCUNCSTRF"));
            salHisRefResultParamWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
            salHisRefResultParamWork.SalesUnitCostChngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESUNITCOSTCHNGDIVRF"));
            salHisRefResultParamWork.RateBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEBLGOODSCODERF"));
            salHisRefResultParamWork.RateBLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEBLGOODSNAMERF"));
            salHisRefResultParamWork.PrtBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRTBLGOODSCODERF"));
            salHisRefResultParamWork.PrtBLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRTBLGOODSNAMERF"));
            salHisRefResultParamWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
            salHisRefResultParamWork.SalesCdNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESCDNMRF"));
            salHisRefResultParamWork.WorkManHour = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("WORKMANHOURRF"));
            salHisRefResultParamWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
            salHisRefResultParamWork.SalesMoneyTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXINCRF"));
            salHisRefResultParamWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
            salHisRefResultParamWork.Cost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COSTRF"));
            salHisRefResultParamWork.GrsProfitChkDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GRSPROFITCHKDIVRF"));
            salHisRefResultParamWork.SalesGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESGOODSCDRF"));
            salHisRefResultParamWork.SalesPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRICECONSTAXRF"));
            salHisRefResultParamWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
            salHisRefResultParamWork.PartySlipNumDtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSLIPNUMDTLRF"));
            salHisRefResultParamWork.DtlNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DTLNOTERF"));
            salHisRefResultParamWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            salHisRefResultParamWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            salHisRefResultParamWork.OrderNumber = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERNUMBERRF"));
            salHisRefResultParamWork.WayToOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("WAYTOORDERRF"));
            salHisRefResultParamWork.SlipMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO1RF"));
            salHisRefResultParamWork.SlipMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO2RF"));
            salHisRefResultParamWork.SlipMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO3RF"));
            salHisRefResultParamWork.InsideMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO1RF"));
            salHisRefResultParamWork.InsideMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO2RF"));
            salHisRefResultParamWork.InsideMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO3RF"));
            salHisRefResultParamWork.BfListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFLISTPRICERF"));
            salHisRefResultParamWork.BfSalesUnitPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSALESUNITPRICERF"));
            salHisRefResultParamWork.BfUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFUNITCOSTRF"));
            salHisRefResultParamWork.CmpltSalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CMPLTSALESROWNORF"));
            salHisRefResultParamWork.CmpltGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CMPLTGOODSMAKERCDRF"));
            salHisRefResultParamWork.CmpltMakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTMAKERNAMERF"));
            salHisRefResultParamWork.CmpltGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTGOODSNAMERF"));
            salHisRefResultParamWork.CmpltShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CMPLTSHIPMENTCNTRF"));
            salHisRefResultParamWork.CmpltSalesUnPrcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CMPLTSALESUNPRCFLRF"));
            salHisRefResultParamWork.CmpltSalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CMPLTSALESMONEYRF"));
            salHisRefResultParamWork.CmpltSalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CMPLTSALESUNITCOSTRF"));
            salHisRefResultParamWork.CmpltCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CMPLTCOSTRF"));
            salHisRefResultParamWork.CmpltPartySalSlNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTPARTYSALSLNUMRF"));
            salHisRefResultParamWork.CmpltNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTNOTERF"));
            salHisRefResultParamWork.CarMngCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARMNGCODERF"));
            salHisRefResultParamWork.ModelDesignationNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));
            salHisRefResultParamWork.CategoryNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));
            salHisRefResultParamWork.MakerFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERFULLNAMERF"));
            salHisRefResultParamWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));
            salHisRefResultParamWork.ModelFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELFULLNAMERF"));
            salHisRefResultParamWork.SearchSlipDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SEARCHSLIPDATERF"));
            salHisRefResultParamWork.ShipmentDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTDAYRF"));
            salHisRefResultParamWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
            salHisRefResultParamWork.InputAgenCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENCDRF"));
            salHisRefResultParamWork.InputAgenNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENNMRF"));
            salHisRefResultParamWork.SalesInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTCODERF"));
            salHisRefResultParamWork.SalesInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTNAMERF"));
            salHisRefResultParamWork.FrontEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEECDRF"));
            salHisRefResultParamWork.FrontEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEENMRF"));
            salHisRefResultParamWork.SalesEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEECDRF"));
            salHisRefResultParamWork.SalesEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEENMRF"));
            salHisRefResultParamWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            salHisRefResultParamWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
            salHisRefResultParamWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            salHisRefResultParamWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            salHisRefResultParamWork.AddresseeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSEECODERF"));
            salHisRefResultParamWork.AddresseeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAMERF"));
            salHisRefResultParamWork.AddresseeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAME2RF"));
            salHisRefResultParamWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
            salHisRefResultParamWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
            salHisRefResultParamWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));
            //---ADD 2011/11/11 -------------------------------------->>>>>
            salHisRefResultParamWork.AcceptOrOrderKind = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ACCEPTORORDERKINDRF"));
            salHisRefResultParamWork.AutoAnswerDivSCM = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOANSWERDIVSCMRF"));
            //---ADD 2011/11/11 --------------------------------------<<<<<
            if (salHisRefExtraParamWork.AcptAnOdrStatus != 30)
            {
                salHisRefResultParamWork.AcptAnOdrRemainCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPTANODRREMAINCNTRF"));
                salHisRefResultParamWork.EstimateDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATEDIVIDERF"));
            }
                                                                                                                      
            #endregion

            return salHisRefResultParamWork;
        }
        #endregion

        #region SQL�R�l�N�V�����擾
        /// <summary>
        /// SQL�R�l�N�V�����擾
        /// </summary>
        /// <returns>SQL�R�l�N�V����</returns>
        private SqlConnection GetSqlConnection()
        {
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return null;

            return new SqlConnection(connectionText);
        }
        #endregion

        #region ���[�e�B���e�B
        /// <summary>
        /// ArrayList���󂩂ǂ����𔻒f����
        /// </summary>
        /// <param name="al">��������Ώۂ�ArrayList</param>
        /// <returns>true:�� false:��łȂ�</returns>
        private bool IsEmpty(ArrayList al)
        {
            if (al == null || al.Count <= 0) return true;
            return false;
        }
        private bool IsNotEmpty(ArrayList al)
        {
            return !IsEmpty(al);
        }

        /// <summary>
        /// �X�e�[�^�X�̃G���[�`�F�b�N
        /// </summary>
        /// <param name="status">�X�e�[�^�X</param>
        private bool HasError(int status)
        {
            return (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL);
        }
        private bool HasNoError(int status)
        {
            return (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL);
        }
        #endregion
    }
}

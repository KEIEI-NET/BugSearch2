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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// UOE�񓚕\��(�����^�C�v)DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : UOE�񓚕\��(�����^�C�v)�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30350 �N�� ����</br>
    /// <br>Date       : 2008.9.24</br>
    /// <br></br>
    /// <br>Update Note: 2011/03/22 ������</br>
    /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
    /// <br>Update Note: 2011/12/19 ���N�n��</br>
    /// <br>�Ǘ��ԍ�   : 10707327-00 2012/01/25�z�M��</br>
    /// <br>             Redmine#27325 UOE�񓚕\��(����)/�������������̑Ή��̏C��</br>
    /// </remarks>
    [Serializable]
    public class UOEAnswerLedgerOrderWorkDB : RemoteDB, IUOEAnswerLedgerOrderWorkDB
    {
        /// <summary>
        /// UOE�񓚕\��(�����^�C�v)DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.9.24</br>
        /// </remarks>
        public UOEAnswerLedgerOrderWorkDB()
            :
        base("PMUOE02098D", "Broadleaf.Application.Remoting.ParamData.UOEAnswerLedgerResultWork", "UOEORDERDTLRF") //���N���X�̃R���X�g���N�^
        {
        }

        #region UOE�񓚕\��(�����^�C�v)
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h��UOE�񓚕\��(�����^�C�v)��LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="supplierUnmResultWork">��������</param>
        /// <param name="supplierUnmOrderCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h��UOE�񓚕\��(�����^�C�v)��LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.9.24</br>
        public int Search(out object uOEAnswerLedgerResultWork, object uOEAnswerLedgerOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            uOEAnswerLedgerResultWork = null;

            UOEAnswerLedgerOrderCndtnWork _uOEAnswerLedgerOrderCndtnWork = uOEAnswerLedgerOrderCndtnWork as UOEAnswerLedgerOrderCndtnWork;

            try
            {
                status = SearchProc(out uOEAnswerLedgerResultWork, _uOEAnswerLedgerOrderCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UOEAnswerLedgerOrderWork.Search Exception=" + ex.Message);
                uOEAnswerLedgerResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h��UOE�񓚕\��(�����^�C�v)��LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="supplierUnmResultWork">��������</param>
        /// <param name="_supplierUnmOrderCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h��UOE�񓚕\��(�����^�C�v)LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.9.24</br>
        /// <br></br>
        /// <br>Update Note: 2007.10.15 ���� DC.NS�p�ɏC��</br>
        /// <br>Update Note: 2011/03/22 ������</br>
        /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
        private int SearchProc(out object uOEAnswerLedgerResultWork, UOEAnswerLedgerOrderCndtnWork _uOEAnswerLedgerOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            uOEAnswerLedgerResultWork = null;

            ArrayList al = new ArrayList();   //���o����

            try
            {
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                // ---ADD 2011/03/22---------->>>>>
                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _uOEAnswerLedgerOrderCndtnWork.EnterpriseCode, "UOE�񓚕\��", "���o�J�n");
                // ---ADD 2011/03/22----------<<<<<

                status = SearchOrderProc(ref al, ref sqlConnection, _uOEAnswerLedgerOrderCndtnWork, logicalMode);

                // ---ADD 2011/03/22---------->>>>>
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _uOEAnswerLedgerOrderCndtnWork.EnterpriseCode, "UOE�񓚕\��", "���o�I��");
                // ---ADD 2011/03/22----------<<<<<
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UOEAnswerLedgerOrderWorkDB.SearchProc Exception=" + ex.Message);
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

            uOEAnswerLedgerResultWork = al;

            return status;
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="al">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_orderListCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        private int SearchOrderProc(ref ArrayList al, ref SqlConnection sqlConnection, UOEAnswerLedgerOrderCndtnWork _uOEAnswerLedgerOrderCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                #region Select���쐬

                selectTxt += "SELECT " + Environment.NewLine;
                selectTxt += "	       UOD.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "        ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
                selectTxt += "        ,UOD.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "        ,UOD.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "        ,UOD.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "        ,UOD.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "        ,UOD.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "        ,UOD.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "        ,UOD.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "        ,UOD.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "        ,UOD.SYSTEMDIVCDRF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOESALESORDERNORF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOESALESORDERROWNORF" + Environment.NewLine;
                selectTxt += "        ,UOD.SENDTERMINALNORF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOESUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOESUPPLIERNAMERF" + Environment.NewLine;
                selectTxt += "        ,UOD.COMMASSEMBLYIDRF" + Environment.NewLine;
                selectTxt += "        ,UOD.ONLINENORF" + Environment.NewLine;
                selectTxt += "        ,UOD.ONLINEROWNORF" + Environment.NewLine;
                selectTxt += "        ,UOD.SALESDATERF" + Environment.NewLine;
                selectTxt += "        ,UOD.INPUTDAYRF" + Environment.NewLine;
                selectTxt += "        ,UOD.DATAUPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOEKINDRF" + Environment.NewLine;
                selectTxt += "        ,UOD.SUBSECTIONCODERF" + Environment.NewLine;
                selectTxt += "        ,UOD.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "        ,UOD.CUSTOMERSNMRF" + Environment.NewLine;
                selectTxt += "        ,UOD.CASHREGISTERNORF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOCODERF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOEDELIGOODSDIVRF" + Environment.NewLine;
                selectTxt += "        ,UOD.DELIVEREDGOODSDIVNMRF" + Environment.NewLine;
                selectTxt += "        ,UOD.FOLLOWDELIGOODSDIVRF" + Environment.NewLine;
                selectTxt += "        ,UOD.FOLLOWDELIGOODSDIVNMRF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOERESVDSECTIONRF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOERESVDSECTIONNMRF" + Environment.NewLine;
                selectTxt += "        ,UOD.EMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "        ,UOD.EMPLOYEENAMERF" + Environment.NewLine;
                selectTxt += "        ,UOD.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAKERNAMERF" + Environment.NewLine;
                selectTxt += "        ,UOD.GOODSNORF" + Environment.NewLine;
                selectTxt += "        ,UOD.GOODSNONONEHYPHENRF" + Environment.NewLine;
                selectTxt += "        ,UOD.GOODSNAMERF" + Environment.NewLine;
                selectTxt += "        ,UOD.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "        ,UOD.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "        ,UOD.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "        ,UOD.ACCEPTANORDERCNTRF" + Environment.NewLine;
                selectTxt += "        ,UOD.LISTPRICERF" + Environment.NewLine;
                selectTxt += "        ,UOD.SALESUNITCOSTRF" + Environment.NewLine;
                selectTxt += "        ,UOD.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "        ,UOD.SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOEREMARK1RF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOEREMARK2RF" + Environment.NewLine;
                selectTxt += "        ,UOD.RECEIVEDATERF" + Environment.NewLine;
                selectTxt += "        ,UOD.RECEIVETIMERF" + Environment.NewLine;
                selectTxt += "        ,UOD.ANSWERMAKERCDRF" + Environment.NewLine;
                selectTxt += "        ,UOD.ANSWERPARTSNORF" + Environment.NewLine;
                selectTxt += "        ,UOD.ANSWERPARTSNAMERF" + Environment.NewLine;
                selectTxt += "        ,UOD.SUBSTPARTSNORF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOESECTOUTGOODSCNTRF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOSHIPMENTCNT1RF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOSHIPMENTCNT2RF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOSHIPMENTCNT3RF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAKERFOLLOWCNTRF" + Environment.NewLine;
                selectTxt += "        ,UOD.NONSHIPMENTCNTRF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOESECTSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOSTOCKCOUNT1RF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOSTOCKCOUNT2RF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOSTOCKCOUNT3RF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOESECTIONSLIPNORF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOSLIPNO1RF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOSLIPNO2RF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOSLIPNO3RF" + Environment.NewLine;
                selectTxt += "        ,UOD.EOALWCCOUNTRF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOMANAGEMENTNORF" + Environment.NewLine;
                selectTxt += "        ,UOD.ANSWERLISTPRICERF" + Environment.NewLine;
                selectTxt += "        ,UOD.ANSWERSALESUNITCOSTRF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOESUBSTMARKRF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOESTOCKMARKRF" + Environment.NewLine;
                selectTxt += "        ,UOD.PARTSLAYERCDRF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAZDAUOESHIPSECTCD1RF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAZDAUOESHIPSECTCD2RF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAZDAUOESHIPSECTCD3RF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAZDAUOESECTCD1RF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAZDAUOESECTCD2RF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAZDAUOESECTCD3RF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAZDAUOESECTCD4RF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAZDAUOESECTCD5RF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAZDAUOESECTCD6RF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAZDAUOESECTCD7RF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAZDAUOESTOCKCNT1RF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAZDAUOESTOCKCNT2RF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAZDAUOESTOCKCNT3RF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAZDAUOESTOCKCNT4RF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAZDAUOESTOCKCNT5RF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAZDAUOESTOCKCNT6RF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAZDAUOESTOCKCNT7RF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOEDISTRIBUTIONCDRF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOEOTHERCDRF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOEHMCDRF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOCOUNTRF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOEMARKCODERF" + Environment.NewLine;
                selectTxt += "        ,UOD.SOURCESHIPMENTRF" + Environment.NewLine;
                selectTxt += "        ,UOD.ITEMCODERF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOECHECKCODERF" + Environment.NewLine;
                selectTxt += "        ,UOD.HEADERRORMASSAGERF" + Environment.NewLine;
                selectTxt += "        ,UOD.LINEERRORMASSAGERF" + Environment.NewLine;
                selectTxt += "FROM UOEORDERDTLRF AS UOD" + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "     SEC.ENTERPRISECODERF=UOD.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "AND  SEC.SECTIONCODERF=UOD.SECTIONCODERF" + Environment.NewLine;
                
                //WHERE���̍쐬
                selectTxt += MakeWhereString(ref sqlCommand, _uOEAnswerLedgerOrderCndtnWork, logicalMode);

                sqlCommand.CommandText = selectTxt;

                #endregion

                myReader = sqlCommand.ExecuteReader();  
                
                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    UOEAnswerLedgerResultWork wkUOEAnswerLedgerResultWork = new UOEAnswerLedgerResultWork();
                    
                    //�i�[����
                    wkUOEAnswerLedgerResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    wkUOEAnswerLedgerResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    wkUOEAnswerLedgerResultWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkUOEAnswerLedgerResultWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkUOEAnswerLedgerResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkUOEAnswerLedgerResultWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    wkUOEAnswerLedgerResultWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    wkUOEAnswerLedgerResultWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    wkUOEAnswerLedgerResultWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    wkUOEAnswerLedgerResultWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkUOEAnswerLedgerResultWork.SystemDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SYSTEMDIVCDRF"));
                    wkUOEAnswerLedgerResultWork.UOESalesOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESALESORDERNORF"));
                    wkUOEAnswerLedgerResultWork.UOESalesOrderRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESALESORDERROWNORF"));
                    wkUOEAnswerLedgerResultWork.SendTerminalNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SENDTERMINALNORF"));
                    wkUOEAnswerLedgerResultWork.UOESupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESUPPLIERCDRF"));
                    wkUOEAnswerLedgerResultWork.UOESupplierName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESUPPLIERNAMERF"));
                    wkUOEAnswerLedgerResultWork.CommAssemblyId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMMASSEMBLYIDRF"));
                    wkUOEAnswerLedgerResultWork.OnlineNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ONLINENORF"));
                    wkUOEAnswerLedgerResultWork.OnlineRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ONLINEROWNORF"));
                    wkUOEAnswerLedgerResultWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
                    wkUOEAnswerLedgerResultWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
                    wkUOEAnswerLedgerResultWork.DataUpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("DATAUPDATEDATETIMERF"));
                    wkUOEAnswerLedgerResultWork.UOEKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOEKINDRF"));
                    wkUOEAnswerLedgerResultWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
                    wkUOEAnswerLedgerResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    wkUOEAnswerLedgerResultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                    wkUOEAnswerLedgerResultWork.CashRegisterNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CASHREGISTERNORF"));
                    wkUOEAnswerLedgerResultWork.BoCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BOCODERF"));
                    wkUOEAnswerLedgerResultWork.UOEDeliGoodsDiv = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEDELIGOODSDIVRF"));
                    wkUOEAnswerLedgerResultWork.DeliveredGoodsDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVNMRF"));
                    wkUOEAnswerLedgerResultWork.FollowDeliGoodsDiv = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FOLLOWDELIGOODSDIVRF"));
                    wkUOEAnswerLedgerResultWork.FollowDeliGoodsDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FOLLOWDELIGOODSDIVNMRF"));
                    wkUOEAnswerLedgerResultWork.UOEResvdSection = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOERESVDSECTIONRF"));
                    wkUOEAnswerLedgerResultWork.UOEResvdSectionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOERESVDSECTIONNMRF"));
                    wkUOEAnswerLedgerResultWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                    wkUOEAnswerLedgerResultWork.EmployeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEENAMERF"));
                    wkUOEAnswerLedgerResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    wkUOEAnswerLedgerResultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    wkUOEAnswerLedgerResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkUOEAnswerLedgerResultWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
                    wkUOEAnswerLedgerResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    wkUOEAnswerLedgerResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    wkUOEAnswerLedgerResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    wkUOEAnswerLedgerResultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    wkUOEAnswerLedgerResultWork.AcceptAnOrderCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACCEPTANORDERCNTRF"));
                    wkUOEAnswerLedgerResultWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));
                    wkUOEAnswerLedgerResultWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
                    wkUOEAnswerLedgerResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    wkUOEAnswerLedgerResultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    wkUOEAnswerLedgerResultWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
                    wkUOEAnswerLedgerResultWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
                    wkUOEAnswerLedgerResultWork.ReceiveDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RECEIVEDATERF"));
                    wkUOEAnswerLedgerResultWork.ReceiveTime = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECEIVETIMERF"));
                    wkUOEAnswerLedgerResultWork.AnswerMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERMAKERCDRF"));
                    wkUOEAnswerLedgerResultWork.AnswerPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERPARTSNORF"));
                    wkUOEAnswerLedgerResultWork.AnswerPartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERPARTSNAMERF"));
                    wkUOEAnswerLedgerResultWork.SubstPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUBSTPARTSNORF"));
                    wkUOEAnswerLedgerResultWork.UOESectOutGoodsCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESECTOUTGOODSCNTRF"));
                    wkUOEAnswerLedgerResultWork.BOShipmentCnt1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOSHIPMENTCNT1RF"));
                    wkUOEAnswerLedgerResultWork.BOShipmentCnt2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOSHIPMENTCNT2RF"));
                    wkUOEAnswerLedgerResultWork.BOShipmentCnt3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOSHIPMENTCNT3RF"));
                    wkUOEAnswerLedgerResultWork.MakerFollowCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERFOLLOWCNTRF"));
                    wkUOEAnswerLedgerResultWork.NonShipmentCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NONSHIPMENTCNTRF"));
                    wkUOEAnswerLedgerResultWork.UOESectStockCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESECTSTOCKCNTRF"));
                    wkUOEAnswerLedgerResultWork.BOStockCount1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOSTOCKCOUNT1RF"));
                    wkUOEAnswerLedgerResultWork.BOStockCount2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOSTOCKCOUNT2RF"));
                    wkUOEAnswerLedgerResultWork.BOStockCount3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOSTOCKCOUNT3RF"));
                    wkUOEAnswerLedgerResultWork.UOESectionSlipNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESECTIONSLIPNORF"));
                    wkUOEAnswerLedgerResultWork.BOSlipNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BOSLIPNO1RF"));
                    wkUOEAnswerLedgerResultWork.BOSlipNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BOSLIPNO2RF"));
                    wkUOEAnswerLedgerResultWork.BOSlipNo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BOSLIPNO3RF"));
                    wkUOEAnswerLedgerResultWork.EOAlwcCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EOALWCCOUNTRF"));
                    wkUOEAnswerLedgerResultWork.BOManagementNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BOMANAGEMENTNORF"));
                    wkUOEAnswerLedgerResultWork.AnswerListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ANSWERLISTPRICERF"));
                    wkUOEAnswerLedgerResultWork.AnswerSalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ANSWERSALESUNITCOSTRF"));
                    wkUOEAnswerLedgerResultWork.UOESubstMark = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESUBSTMARKRF"));
                    wkUOEAnswerLedgerResultWork.UOEStockMark = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESTOCKMARKRF"));
                    wkUOEAnswerLedgerResultWork.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                    wkUOEAnswerLedgerResultWork.MazdaUOEShipSectCd1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESHIPSECTCD1RF"));
                    wkUOEAnswerLedgerResultWork.MazdaUOEShipSectCd2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESHIPSECTCD2RF"));
                    wkUOEAnswerLedgerResultWork.MazdaUOEShipSectCd3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESHIPSECTCD3RF"));
                    wkUOEAnswerLedgerResultWork.MazdaUOESectCd1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESECTCD1RF"));
                    wkUOEAnswerLedgerResultWork.MazdaUOESectCd2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESECTCD2RF"));
                    wkUOEAnswerLedgerResultWork.MazdaUOESectCd3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESECTCD3RF"));
                    wkUOEAnswerLedgerResultWork.MazdaUOESectCd4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESECTCD4RF"));
                    wkUOEAnswerLedgerResultWork.MazdaUOESectCd5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESECTCD5RF"));
                    wkUOEAnswerLedgerResultWork.MazdaUOESectCd6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESECTCD6RF"));
                    wkUOEAnswerLedgerResultWork.MazdaUOESectCd7 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESECTCD7RF"));
                    wkUOEAnswerLedgerResultWork.MazdaUOEStockCnt1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAZDAUOESTOCKCNT1RF"));
                    wkUOEAnswerLedgerResultWork.MazdaUOEStockCnt2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAZDAUOESTOCKCNT2RF"));
                    wkUOEAnswerLedgerResultWork.MazdaUOEStockCnt3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAZDAUOESTOCKCNT3RF"));
                    wkUOEAnswerLedgerResultWork.MazdaUOEStockCnt4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAZDAUOESTOCKCNT4RF"));
                    wkUOEAnswerLedgerResultWork.MazdaUOEStockCnt5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAZDAUOESTOCKCNT5RF"));
                    wkUOEAnswerLedgerResultWork.MazdaUOEStockCnt6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAZDAUOESTOCKCNT6RF"));
                    wkUOEAnswerLedgerResultWork.MazdaUOEStockCnt7 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAZDAUOESTOCKCNT7RF"));
                    wkUOEAnswerLedgerResultWork.UOEDistributionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEDISTRIBUTIONCDRF"));
                    wkUOEAnswerLedgerResultWork.UOEOtherCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEOTHERCDRF"));
                    wkUOEAnswerLedgerResultWork.UOEHMCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEHMCDRF"));
                    wkUOEAnswerLedgerResultWork.BOCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOCOUNTRF"));
                    wkUOEAnswerLedgerResultWork.UOEMarkCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEMARKCODERF"));
                    wkUOEAnswerLedgerResultWork.SourceShipment = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SOURCESHIPMENTRF"));
                    wkUOEAnswerLedgerResultWork.ItemCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ITEMCODERF"));
                    wkUOEAnswerLedgerResultWork.UOECheckCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOECHECKCODERF"));
                    wkUOEAnswerLedgerResultWork.HeadErrorMassage = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HEADERRORMASSAGERF"));
                    wkUOEAnswerLedgerResultWork.LineErrorMassage = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LINEERRORMASSAGERF"));
                    #endregion

                    al.Add(wkUOEAnswerLedgerResultWork);

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
                base.WriteErrorLog(ex, "UOEAnswerLedgerOrderWorkDB.SearchOrderProc Exception=" + ex.Message);
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
        /// <param name="_orderListCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Update Note: 2011/12/19 ���N�n��</br>
        /// <br>�Ǘ��ԍ�   : 10707327-00 2012/01/25�z�M��</br>
        /// <br>             Redmine#27325 UOE�񓚕\��(����)/�������������̑Ή��̏C��</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, UOEAnswerLedgerOrderCndtnWork _uOEAnswerLedgerOrderCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = "WHERE" + Environment.NewLine;


            //��ƃR�[�h
            retstring += " UOD.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_uOEAnswerLedgerOrderCndtnWork.EnterpriseCode);


            //�V�X�e���敪
            if (_uOEAnswerLedgerOrderCndtnWork.SystemDivCd != -1)
            {
                retstring += " AND UOD.SYSTEMDIVCDRF=@SYSTEMDIVCD" + Environment.NewLine;
                SqlParameter paraSystemDivCd = sqlCommand.Parameters.Add("@SYSTEMDIVCD", SqlDbType.Int);
                paraSystemDivCd.Value = SqlDataMediator.SqlSetInt32(_uOEAnswerLedgerOrderCndtnWork.SystemDivCd);
            }

            //UOE���(0:UOE)
            if (_uOEAnswerLedgerOrderCndtnWork.UOEKind != -1)
            {
                retstring += " AND UOD.UOEKINDRF=@UOEKINDRF" + Environment.NewLine;
                SqlParameter paraUOEKind = sqlCommand.Parameters.Add("@UOEKINDRF", SqlDbType.Int);
                paraUOEKind.Value = SqlDataMediator.SqlSetInt32(_uOEAnswerLedgerOrderCndtnWork.UOEKind);
            }
            //���͓�
            if (_uOEAnswerLedgerOrderCndtnWork.St_InputDay != DateTime.MinValue)
            {
                retstring += " AND UOD.INPUTDAYRF>=@STINPUTDAY" + Environment.NewLine;
                SqlParameter paraStInputDay = sqlCommand.Parameters.Add("@STINPUTDAY", SqlDbType.Int);
                paraStInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_uOEAnswerLedgerOrderCndtnWork.St_InputDay);
            }
            if (_uOEAnswerLedgerOrderCndtnWork.Ed_InputDay != DateTime.MinValue)
            {
                retstring += " AND UOD.INPUTDAYRF<=@EDINPUTDAY" + Environment.NewLine;
                SqlParameter paraEdInputDay = sqlCommand.Parameters.Add("@EDINPUTDAY", SqlDbType.Int);
                paraEdInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_uOEAnswerLedgerOrderCndtnWork.Ed_InputDay);
            }
            //���_�R�[�h
            if (_uOEAnswerLedgerOrderCndtnWork.SectionCode != "")
            {
                retstring += " AND UOD.SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(_uOEAnswerLedgerOrderCndtnWork.SectionCode);
            }


            //������R�[�h
            if (_uOEAnswerLedgerOrderCndtnWork.UOESupplierCd != 0)
            {
                retstring += " AND UOD.UOESUPPLIERCDRF=@UOESUPPLIERCD" + Environment.NewLine;
                SqlParameter paraUOESupplierCd = sqlCommand.Parameters.Add("@UOESUPPLIERCD", SqlDbType.Int);
                paraUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(_uOEAnswerLedgerOrderCndtnWork.UOESupplierCd);
            }

            //���Ӑ�R�[�h
            //if (_uOEAnswerLedgerOrderCndtnWork.CustomerCode != 0 && _uOEAnswerLedgerOrderCndtnWork.SystemDivCd == 2)// DEL ���N�n�� 2011/12/19 Redmine#27325
            if (_uOEAnswerLedgerOrderCndtnWork.CustomerCode != 0 && (_uOEAnswerLedgerOrderCndtnWork.SystemDivCd == 2 || _uOEAnswerLedgerOrderCndtnWork.SystemDivCd == 1))// ADD ���N�n�� 2011/12/19 Redmine#27325
            {
                retstring += " AND UOD.CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(_uOEAnswerLedgerOrderCndtnWork.CustomerCode);
            }

            //��M���t
            if (_uOEAnswerLedgerOrderCndtnWork.St_ReceiveDate != DateTime.MinValue)
            {
                retstring += " AND UOD.RECEIVEDATERF>=@STRECEIVEDATE" + Environment.NewLine;
                SqlParameter paraStReceiveDate = sqlCommand.Parameters.Add("@STRECEIVEDATE", SqlDbType.Int);
                paraStReceiveDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_uOEAnswerLedgerOrderCndtnWork.St_ReceiveDate);
            }
            if (_uOEAnswerLedgerOrderCndtnWork.Ed_ReceiveDate != DateTime.MinValue)
            {
                retstring += " AND UOD.RECEIVEDATERF<=@EDRECEIVEDATE" + Environment.NewLine;
                SqlParameter paraEdReceiveDate = sqlCommand.Parameters.Add("@EDRECEIVEDATE", SqlDbType.Int);
                paraEdReceiveDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_uOEAnswerLedgerOrderCndtnWork.Ed_ReceiveDate);
            }

            //�˗��҃R�[�h
            if (_uOEAnswerLedgerOrderCndtnWork.EmployeeCode != "")
            {
                retstring += " AND UOD.EMPLOYEECODERF=@EMPLOYEECODE" + Environment.NewLine;
                SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.Int);
                paraEmployeeCode.Value = SqlDataMediator.SqlSetString(_uOEAnswerLedgerOrderCndtnWork.EmployeeCode);
            }

            //�[�i�敪
            if (_uOEAnswerLedgerOrderCndtnWork.UOEDeliGoodsDiv != "")
            {
                retstring += " AND UOD.UOEDELIGOODSDIVRF=@UOEDELIGOODSDIV" + Environment.NewLine;
                SqlParameter paraUOEDeliGoodsDiv = sqlCommand.Parameters.Add("@UOEDELIGOODSDIV", SqlDbType.NVarChar);
                paraUOEDeliGoodsDiv.Value = SqlDataMediator.SqlSetString(_uOEAnswerLedgerOrderCndtnWork.UOEDeliGoodsDiv);
            }

            //�t�H���[�[�i�敪
            if (_uOEAnswerLedgerOrderCndtnWork.FollowDeliGoodsDiv != "")
            {
                retstring += " AND UOD.FOLLOWDELIGOODSDIVRF=@FOLLOWDELIGOODSDIV" + Environment.NewLine;
                SqlParameter paraFollowDeliGoodsDiv = sqlCommand.Parameters.Add("@FOLLOWDELIGOODSDIV", SqlDbType.Int);
                paraFollowDeliGoodsDiv.Value = SqlDataMediator.SqlSetString(_uOEAnswerLedgerOrderCndtnWork.FollowDeliGoodsDiv);
            }

            //�d���`�[�ԍ�
            if (_uOEAnswerLedgerOrderCndtnWork.SupplierSlipNo != 0)
            {
                retstring += " AND UOD.SUPPLIERSLIPNORF=@SUPPLIERSLIPNO" + Environment.NewLine;
                SqlParameter paraSupplierSlipNo = sqlCommand.Parameters.Add("@SUPPLIERSLIPNO", SqlDbType.Int);
                paraSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(_uOEAnswerLedgerOrderCndtnWork.SupplierSlipNo);
            }

            //UOE�����ԍ�
            if (_uOEAnswerLedgerOrderCndtnWork.UOESalesOrderNo != 0)
            {
                retstring += " AND UOD.UOESALESORDERNORF=@UOESALESORDERNO" + Environment.NewLine;
                SqlParameter paraUOESalesOrderNo = sqlCommand.Parameters.Add("@UOESALESORDERNO", SqlDbType.Int);
                paraUOESalesOrderNo.Value = SqlDataMediator.SqlSetInt32(_uOEAnswerLedgerOrderCndtnWork.UOESalesOrderNo);
            }

            //UOE���}�[�N1
            if (_uOEAnswerLedgerOrderCndtnWork.UoeRemark1 != "")
            {
                retstring += " AND UOD.UOEREMARK1RF=@UOEREMARK1" + Environment.NewLine;
                SqlParameter paraUoeRemark1 = sqlCommand.Parameters.Add("@UOEREMARK1", SqlDbType.Int);
                paraUoeRemark1.Value = SqlDataMediator.SqlSetString(_uOEAnswerLedgerOrderCndtnWork.UoeRemark1);
            }

            //UOE���}�[�N2
            if (_uOEAnswerLedgerOrderCndtnWork.UoeRemark2 != "")
            {
                retstring += " AND UOD.UOEREMARK2RF=@UOEREMARK2" + Environment.NewLine;
                SqlParameter paraUoeRemark2 = sqlCommand.Parameters.Add("@UOEREMARK2", SqlDbType.Int);
                paraUoeRemark2.Value = SqlDataMediator.SqlSetString(_uOEAnswerLedgerOrderCndtnWork.UoeRemark2);
            }

            //���M�t���O
            retstring += " AND UOD.DATASENDCODERF=9" + Environment.NewLine;

            //�����t���O
            retstring += " AND UOD.DATARECOVERDIVRF=9" + Environment.NewLine;

            #endregion
            return retstring;
        }
    }
}

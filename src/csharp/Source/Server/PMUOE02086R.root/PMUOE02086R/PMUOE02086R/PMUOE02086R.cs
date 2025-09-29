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
    /// �������M�G���[���X�gDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �������M�G���[���X�g�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30350 �N�� ����</br>
    /// <br>Date       : 2008.9.22</br>
    /// <br></br>
    /// <br>Update Note:</br>
    /// </remarks>
    [Serializable]
    public class SupplierSendErOrderWorkDB : RemoteDB, ISupplierSendErOrderWorkDB
    {
        /// <summary>
        /// �������M�G���[���X�gDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.9.22</br>
        /// </remarks>
        public SupplierSendErOrderWorkDB()
            :
        base("PMUOE02088D", "Broadleaf.Application.Remoting.ParamData.SupplierSendErResultWork", "UOEORDERDTLRF") //���N���X�̃R���X�g���N�^
        {
        }

        #region �������M�G���[���X�g
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̔������M�G���[���X�g��LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="supplierUnmResultWork">��������</param>
        /// <param name="supplierUnmOrderCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̕����f�[�^�ꗗ�\LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.9.22</br>
        public int Search(out object supplierSendErResultWork, object supplierSendErOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            supplierSendErResultWork = null;

            SupplierSendErOrderCndtnWork _supplierSendErOrderCndtnWork = supplierSendErOrderCndtnWork as SupplierSendErOrderCndtnWork;

            try
            {
                status = SearchProc(out supplierSendErResultWork, _supplierSendErOrderCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SupplierSendErOrderWork.Search Exception=" + ex.Message);
                supplierSendErResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̔������M�G���[���X�g��LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="supplierSendErResultWork">��������</param>
        /// <param name="_supplierSendErOrderCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̔������M�G���[���X�g��LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.9.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.10.15 ���� DC.NS�p�ɏC��</br>
        private int SearchProc(out object supplierSendErResultWork, SupplierSendErOrderCndtnWork _supplierSendErOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            supplierSendErResultWork = null;

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


                status = SearchOrderProc(ref al, ref sqlConnection, _supplierSendErOrderCndtnWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SupplierSendErOrderWorkDB.SearchProc Exception=" + ex.Message);
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

            supplierSendErResultWork = al;

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
        private int SearchOrderProc(ref ArrayList al, ref SqlConnection sqlConnection, SupplierSendErOrderCndtnWork _supplierSendErOrderCndtnWork, ConstantManagement.LogicalMode logicalMode)
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
                selectTxt += "	       UOD.CREATEDATETIMERF" + Environment.NewLine;
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
                selectTxt += "        ,UOD.SALESSLIPNUMRF" + Environment.NewLine;
                selectTxt += "        ,UOD.ACPTANODRSTATUSRF" + Environment.NewLine;
                selectTxt += "        ,UOD.SALESSLIPDTLNUMRF" + Environment.NewLine;
                selectTxt += "        ,UOD.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "        ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
                selectTxt += "        ,UOD.SUBSECTIONCODERF" + Environment.NewLine;
                selectTxt += "        ,UOD.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "        ,UOD.CUSTOMERSNMRF" + Environment.NewLine;
                selectTxt += "        ,UOD.CASHREGISTERNORF" + Environment.NewLine;
                selectTxt += "        ,UOD.COMMONSEQNORF" + Environment.NewLine;
                selectTxt += "        ,UOD.SUPPLIERFORMALRF" + Environment.NewLine;
                selectTxt += "        ,UOD.SUPPLIERSLIPNORF" + Environment.NewLine;
                selectTxt += "        ,UOD.STOCKSLIPDTLNUMRF" + Environment.NewLine;
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
                selectTxt += "        ,UOD.DATASENDCODERF" + Environment.NewLine;
                selectTxt += "        ,UOD.DATARECOVERDIVRF" + Environment.NewLine;
                selectTxt += "        ,UOD.ENTERUPDDIVSECRF" + Environment.NewLine;
                selectTxt += "        ,UOD.ENTERUPDDIVBO1RF" + Environment.NewLine;
                selectTxt += "        ,UOD.ENTERUPDDIVBO2RF" + Environment.NewLine;
                selectTxt += "        ,UOD.ENTERUPDDIVBO3RF" + Environment.NewLine;
                selectTxt += "        ,UOD.ENTERUPDDIVMAKERRF" + Environment.NewLine;
                selectTxt += "        ,UOD.ENTERUPDDIVEORF" + Environment.NewLine;
                selectTxt += "FROM UOEORDERDTLRF AS UOD" + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "     SEC.ENTERPRISECODERF=UOD.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "AND  SEC.SECTIONCODERF=UOD.SECTIONCODERF" + Environment.NewLine;

                
                //WHERE���̍쐬
                selectTxt += MakeWhereString(ref sqlCommand, _supplierSendErOrderCndtnWork, logicalMode);

                sqlCommand.CommandText = selectTxt;

                #endregion

                myReader = sqlCommand.ExecuteReader();  
                
                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    SupplierSendErResultWork wkSupplierSendErResultWork = new SupplierSendErResultWork();
                    
                    //�i�[����
                    wkSupplierSendErResultWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkSupplierSendErResultWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkSupplierSendErResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkSupplierSendErResultWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    wkSupplierSendErResultWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    wkSupplierSendErResultWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    wkSupplierSendErResultWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    wkSupplierSendErResultWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkSupplierSendErResultWork.SystemDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SYSTEMDIVCDRF"));
                    wkSupplierSendErResultWork.UOESalesOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESALESORDERNORF"));
                    wkSupplierSendErResultWork.UOESalesOrderRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESALESORDERROWNORF"));
                    wkSupplierSendErResultWork.SendTerminalNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SENDTERMINALNORF"));
                    wkSupplierSendErResultWork.UOESupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESUPPLIERCDRF"));
                    wkSupplierSendErResultWork.UOESupplierName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESUPPLIERNAMERF"));
                    wkSupplierSendErResultWork.CommAssemblyId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMMASSEMBLYIDRF"));
                    wkSupplierSendErResultWork.OnlineNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ONLINENORF"));
                    wkSupplierSendErResultWork.OnlineRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ONLINEROWNORF"));
                    wkSupplierSendErResultWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
                    wkSupplierSendErResultWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
                    wkSupplierSendErResultWork.DataUpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("DATAUPDATEDATETIMERF"));
                    wkSupplierSendErResultWork.UOEKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOEKINDRF"));
                    wkSupplierSendErResultWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                    wkSupplierSendErResultWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                    wkSupplierSendErResultWork.SalesSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMRF"));
                    wkSupplierSendErResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    wkSupplierSendErResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    wkSupplierSendErResultWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
                    wkSupplierSendErResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    wkSupplierSendErResultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                    wkSupplierSendErResultWork.CashRegisterNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CASHREGISTERNORF"));
                    wkSupplierSendErResultWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));
                    wkSupplierSendErResultWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
                    wkSupplierSendErResultWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
                    wkSupplierSendErResultWork.StockSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMRF"));
                    wkSupplierSendErResultWork.BoCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BOCODERF"));
                    wkSupplierSendErResultWork.UOEDeliGoodsDiv = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEDELIGOODSDIVRF"));
                    wkSupplierSendErResultWork.DeliveredGoodsDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVNMRF"));
                    wkSupplierSendErResultWork.FollowDeliGoodsDiv = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FOLLOWDELIGOODSDIVRF"));
                    wkSupplierSendErResultWork.FollowDeliGoodsDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FOLLOWDELIGOODSDIVNMRF"));
                    wkSupplierSendErResultWork.UOEResvdSection = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOERESVDSECTIONRF"));
                    wkSupplierSendErResultWork.UOEResvdSectionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOERESVDSECTIONNMRF"));
                    wkSupplierSendErResultWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                    wkSupplierSendErResultWork.EmployeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEENAMERF"));
                    wkSupplierSendErResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    wkSupplierSendErResultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    wkSupplierSendErResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkSupplierSendErResultWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
                    wkSupplierSendErResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    wkSupplierSendErResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    wkSupplierSendErResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    wkSupplierSendErResultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    wkSupplierSendErResultWork.AcceptAnOrderCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACCEPTANORDERCNTRF"));
                    wkSupplierSendErResultWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));
                    wkSupplierSendErResultWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
                    wkSupplierSendErResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    wkSupplierSendErResultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    wkSupplierSendErResultWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
                    wkSupplierSendErResultWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
                    wkSupplierSendErResultWork.ReceiveDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RECEIVEDATERF"));
                    wkSupplierSendErResultWork.ReceiveTime = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECEIVETIMERF"));
                    wkSupplierSendErResultWork.AnswerMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERMAKERCDRF"));
                    wkSupplierSendErResultWork.AnswerPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERPARTSNORF"));
                    wkSupplierSendErResultWork.AnswerPartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERPARTSNAMERF"));
                    wkSupplierSendErResultWork.SubstPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUBSTPARTSNORF"));
                    wkSupplierSendErResultWork.UOESectOutGoodsCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESECTOUTGOODSCNTRF"));
                    wkSupplierSendErResultWork.BOShipmentCnt1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOSHIPMENTCNT1RF"));
                    wkSupplierSendErResultWork.BOShipmentCnt2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOSHIPMENTCNT2RF"));
                    wkSupplierSendErResultWork.BOShipmentCnt3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOSHIPMENTCNT3RF"));
                    wkSupplierSendErResultWork.MakerFollowCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERFOLLOWCNTRF"));
                    wkSupplierSendErResultWork.NonShipmentCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NONSHIPMENTCNTRF"));
                    wkSupplierSendErResultWork.UOESectStockCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESECTSTOCKCNTRF"));
                    wkSupplierSendErResultWork.BOStockCount1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOSTOCKCOUNT1RF"));
                    wkSupplierSendErResultWork.BOStockCount2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOSTOCKCOUNT2RF"));
                    wkSupplierSendErResultWork.BOStockCount3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOSTOCKCOUNT3RF"));
                    wkSupplierSendErResultWork.UOESectionSlipNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESECTIONSLIPNORF"));
                    wkSupplierSendErResultWork.BOSlipNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BOSLIPNO1RF"));
                    wkSupplierSendErResultWork.BOSlipNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BOSLIPNO2RF"));
                    wkSupplierSendErResultWork.BOSlipNo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BOSLIPNO3RF"));
                    wkSupplierSendErResultWork.EOAlwcCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EOALWCCOUNTRF"));
                    wkSupplierSendErResultWork.BOManagementNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BOMANAGEMENTNORF"));
                    wkSupplierSendErResultWork.AnswerListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ANSWERLISTPRICERF"));
                    wkSupplierSendErResultWork.AnswerSalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ANSWERSALESUNITCOSTRF"));
                    wkSupplierSendErResultWork.UOESubstMark = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESUBSTMARKRF"));
                    wkSupplierSendErResultWork.UOEStockMark = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESTOCKMARKRF"));
                    wkSupplierSendErResultWork.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                    wkSupplierSendErResultWork.MazdaUOEShipSectCd1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESHIPSECTCD1RF"));
                    wkSupplierSendErResultWork.MazdaUOEShipSectCd2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESHIPSECTCD2RF"));
                    wkSupplierSendErResultWork.MazdaUOEShipSectCd3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESHIPSECTCD3RF"));
                    wkSupplierSendErResultWork.MazdaUOESectCd1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESECTCD1RF"));
                    wkSupplierSendErResultWork.MazdaUOESectCd2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESECTCD2RF"));
                    wkSupplierSendErResultWork.MazdaUOESectCd3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESECTCD3RF"));
                    wkSupplierSendErResultWork.MazdaUOESectCd4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESECTCD4RF"));
                    wkSupplierSendErResultWork.MazdaUOESectCd5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESECTCD5RF"));
                    wkSupplierSendErResultWork.MazdaUOESectCd6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESECTCD6RF"));
                    wkSupplierSendErResultWork.MazdaUOESectCd7 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESECTCD7RF"));
                    wkSupplierSendErResultWork.MazdaUOEStockCnt1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAZDAUOESTOCKCNT1RF"));
                    wkSupplierSendErResultWork.MazdaUOEStockCnt2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAZDAUOESTOCKCNT2RF"));
                    wkSupplierSendErResultWork.MazdaUOEStockCnt3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAZDAUOESTOCKCNT3RF"));
                    wkSupplierSendErResultWork.MazdaUOEStockCnt4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAZDAUOESTOCKCNT4RF"));
                    wkSupplierSendErResultWork.MazdaUOEStockCnt5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAZDAUOESTOCKCNT5RF"));
                    wkSupplierSendErResultWork.MazdaUOEStockCnt6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAZDAUOESTOCKCNT6RF"));
                    wkSupplierSendErResultWork.MazdaUOEStockCnt7 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAZDAUOESTOCKCNT7RF"));
                    wkSupplierSendErResultWork.UOEDistributionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEDISTRIBUTIONCDRF"));
                    wkSupplierSendErResultWork.UOEOtherCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEOTHERCDRF"));
                    wkSupplierSendErResultWork.UOEHMCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEHMCDRF"));
                    wkSupplierSendErResultWork.BOCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOCOUNTRF"));
                    wkSupplierSendErResultWork.UOEMarkCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEMARKCODERF"));
                    wkSupplierSendErResultWork.SourceShipment = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SOURCESHIPMENTRF"));
                    wkSupplierSendErResultWork.ItemCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ITEMCODERF"));
                    wkSupplierSendErResultWork.UOECheckCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOECHECKCODERF"));
                    wkSupplierSendErResultWork.HeadErrorMassage = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HEADERRORMASSAGERF"));
                    wkSupplierSendErResultWork.LineErrorMassage = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LINEERRORMASSAGERF"));
                    wkSupplierSendErResultWork.DataSendCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATASENDCODERF"));
                    wkSupplierSendErResultWork.DataRecoverDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATARECOVERDIVRF"));
                    wkSupplierSendErResultWork.EnterUpdDivSec = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERUPDDIVSECRF"));
                    wkSupplierSendErResultWork.EnterUpdDivBO1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERUPDDIVBO1RF"));
                    wkSupplierSendErResultWork.EnterUpdDivBO2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERUPDDIVBO2RF"));
                    wkSupplierSendErResultWork.EnterUpdDivBO3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERUPDDIVBO3RF"));
                    wkSupplierSendErResultWork.EnterUpdDivMaker = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERUPDDIVMAKERRF"));
                    wkSupplierSendErResultWork.EnterUpdDivEO = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERUPDDIVEORF"));
                    #endregion

                    al.Add(wkSupplierSendErResultWork);

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
                base.WriteErrorLog(ex, "SupplierSendErOrderWorkDB.SearchOrderProc Exception=" + ex.Message);
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
        private string MakeWhereString(ref SqlCommand sqlCommand, SupplierSendErOrderCndtnWork _supplierSendErOrderCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = "WHERE" + Environment.NewLine;


            //��ƃR�[�h
            retstring += " UOD.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_supplierSendErOrderCndtnWork.EnterpriseCode);

            //UOE���(0:UOE)
            retstring += " AND UOD.UOEKINDRF=0" + Environment.NewLine;

            //���_�R�[�h
            if (_supplierSendErOrderCndtnWork.SectionCodes != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in _supplierSendErOrderCndtnWork.SectionCodes)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }
                if (sectionCodestr != "")
                {
                    retstring += " AND UOD.SECTIONCODERF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            // ���M�[���ԍ�
            retstring += "AND UOD.SENDTERMINALNORF !=0" + Environment.NewLine;

            //������R�[�h
            if (_supplierSendErOrderCndtnWork.St_UOESupplierCd != 0)
            {
                retstring += " AND UOD.UOESUPPLIERCDRF>=@STUOESUPPLIERCD" + Environment.NewLine;
                SqlParameter paraStUOESupplierCd = sqlCommand.Parameters.Add("@STUOESUPPLIERCD", SqlDbType.Int);
                paraStUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(_supplierSendErOrderCndtnWork.St_UOESupplierCd);
            }
            if (_supplierSendErOrderCndtnWork.Ed_UOESupplierCd != 0)
            {
                retstring += " AND UOD.UOESUPPLIERCDRF<=@EDUOESUPPLIERCD" + Environment.NewLine;
                SqlParameter paraEdUOESupplierCd = sqlCommand.Parameters.Add("@EDUOESUPPLIERCD", SqlDbType.Int);
                paraEdUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(_supplierSendErOrderCndtnWork.Ed_UOESupplierCd);
            }

            //��M���t
            if (_supplierSendErOrderCndtnWork.St_ReceiveDate != DateTime.MinValue)
            {
                retstring += " AND UOD.RECEIVEDATERF>=@STRECEIVEDATE" + Environment.NewLine;
                SqlParameter paraStReceiveDate = sqlCommand.Parameters.Add("@STRECEIVEDATE", SqlDbType.Int);
                paraStReceiveDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_supplierSendErOrderCndtnWork.St_ReceiveDate);
            }
            if (_supplierSendErOrderCndtnWork.Ed_ReceiveDate != DateTime.MinValue)
            {
                retstring += " AND UOD.RECEIVEDATERF<=@EDRECEIVEDATE" + Environment.NewLine;
                SqlParameter paraEdReceiveDate = sqlCommand.Parameters.Add("@EDRECEIVEDATE", SqlDbType.Int);
                paraEdReceiveDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_supplierSendErOrderCndtnWork.Ed_ReceiveDate);
            }

            //���M�t���O
            retstring += " AND (UOD.DATASENDCODERF=1)" + Environment.NewLine;

            //�����t���O
            retstring += " AND (UOD.DATARECOVERDIVRF=0)" + Environment.NewLine;

            #endregion
            return retstring;
        }
    }
}

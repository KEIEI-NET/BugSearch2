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
    /// �d���A���}�b�`���X�gDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d���A���}�b�`���X�g�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30350 �N�� ����</br>
    /// <br>Date       : 2008.9.18</br>
    /// <br></br>
    /// <br>Update Note:</br>
    /// </remarks>
    [Serializable]
    public class SupplierUnmOrderWorkDB : RemoteDB, ISupplierUnmOrderWorkDB
    {
        /// <summary>
        /// �d���A���}�b�`���X�gDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.9.18</br>
        /// </remarks>
        public SupplierUnmOrderWorkDB()
            :
        base("PMUOE02078D", "Broadleaf.Application.Remoting.ParamData.SupplierUnmResultWork", "UOEORDERDTLRF") //���N���X�̃R���X�g���N�^
        {
        }

        #region �d���A���}�b�`���X�g
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̎d���A���}�b�`���X�g��LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="supplierUnmResultWork">��������</param>
        /// <param name="supplierUnmOrderCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̕����f�[�^�ꗗ�\LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.9.18</br>
        public int Search(out object supplierUnmResultWork, object supplierUnmOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            supplierUnmResultWork = null;

            SupplierUnmOrderCndtnWork _supplierUnmOrderCndtnWork = supplierUnmOrderCndtnWork as SupplierUnmOrderCndtnWork;

            try
            {
                status = SearchProc(out supplierUnmResultWork, _supplierUnmOrderCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SupplierUnmOrderWork.Search Exception=" + ex.Message);
                supplierUnmResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̎d���A���}�b�`���X�g��LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="supplierUnmResultWork">��������</param>
        /// <param name="_supplierUnmOrderCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̕����ꗗ�\LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.9.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.10.15 ���� DC.NS�p�ɏC��</br>
        private int SearchProc(out object supplierUnmResultWork, SupplierUnmOrderCndtnWork _supplierUnmOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            supplierUnmResultWork = null;

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


                status = SearchOrderProc(ref al, ref sqlConnection, _supplierUnmOrderCndtnWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SupplierUnmOrderWorkDB.SearchProc Exception=" + ex.Message);
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

            supplierUnmResultWork = al;

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
        private int SearchOrderProc(ref ArrayList al, ref SqlConnection sqlConnection, SupplierUnmOrderCndtnWork _supplierUnmOrderCndtnWork, ConstantManagement.LogicalMode logicalMode)
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
                selectTxt += "        ,UOD.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "        ,UOD.SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += "        ,UOD.SALESDATERF" + Environment.NewLine;
                selectTxt += "        ,UOD.GOODSNORF" + Environment.NewLine;
                selectTxt += "        ,UOD.GOODSNAMERF" + Environment.NewLine;
                selectTxt += "        ,UOD.ACCEPTANORDERCNTRF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOCODERF" + Environment.NewLine;
                selectTxt += "        ,UOD.ANSWERLISTPRICERF" + Environment.NewLine;
                selectTxt += "        ,UOD.ANSWERSALESUNITCOSTRF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOESALESORDERNORF" + Environment.NewLine;
                selectTxt += "        ,UOD.SYSTEMDIVCDRF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOESECTOUTGOODSCNTRF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOSHIPMENTCNT1RF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOSHIPMENTCNT2RF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOSHIPMENTCNT3RF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAKERFOLLOWCNTRF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOESECTIONSLIPNORF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOSLIPNO1RF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOSLIPNO2RF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOSLIPNO3RF" + Environment.NewLine;
                selectTxt += "        ,UOD.EOALWCCOUNTRF" + Environment.NewLine;
                selectTxt += " FROM UOEORDERDTLRF AS UOD" + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "     SEC.ENTERPRISECODERF=UOD.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "AND  SEC.SECTIONCODERF=UOD.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN UOESETTINGRF AS UOS" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "     UOS.ENTERPRISECODERF=UOD.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "AND  UOS.SECTIONCODERF=UOD.SECTIONCODERF" + Environment.NewLine;
                
                //WHERE���̍쐬
                selectTxt += MakeWhereString(ref sqlCommand, _supplierUnmOrderCndtnWork, logicalMode);

                sqlCommand.CommandText = selectTxt;

                #endregion

                myReader = sqlCommand.ExecuteReader();  
                
                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    SupplierUnmResultWork wkSupplierUnmResultWork = new SupplierUnmResultWork();
                    
                    //�i�[����
                    wkSupplierUnmResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    wkSupplierUnmResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    wkSupplierUnmResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    wkSupplierUnmResultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    wkSupplierUnmResultWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
                    wkSupplierUnmResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkSupplierUnmResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    wkSupplierUnmResultWork.AcceptAnOrderCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACCEPTANORDERCNTRF"));
                    wkSupplierUnmResultWork.BoCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BOCODERF"));
                    wkSupplierUnmResultWork.AnswerListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ANSWERLISTPRICERF"));
                    wkSupplierUnmResultWork.AnswerSalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ANSWERSALESUNITCOSTRF"));
                    wkSupplierUnmResultWork.UOESalesOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESALESORDERNORF"));
                    wkSupplierUnmResultWork.SystemDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SYSTEMDIVCDRF"));
                    wkSupplierUnmResultWork.UOESectOutGoodsCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESECTOUTGOODSCNTRF"));
                    wkSupplierUnmResultWork.BOShipmentCnt1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOSHIPMENTCNT1RF"));
                    wkSupplierUnmResultWork.BOShipmentCnt2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOSHIPMENTCNT2RF"));
                    wkSupplierUnmResultWork.BOShipmentCnt3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOSHIPMENTCNT3RF"));
                    wkSupplierUnmResultWork.MakerFollowCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERFOLLOWCNTRF"));
                    wkSupplierUnmResultWork.UOESectionSlipNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESECTIONSLIPNORF"));
                    wkSupplierUnmResultWork.BOSlipNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BOSLIPNO1RF"));
                    wkSupplierUnmResultWork.BOSlipNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BOSLIPNO2RF"));
                    wkSupplierUnmResultWork.BOSlipNo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BOSLIPNO3RF"));
                    wkSupplierUnmResultWork.EOAlwcCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EOALWCCOUNTRF"));
                    #endregion

                    al.Add(wkSupplierUnmResultWork);

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
                base.WriteErrorLog(ex, "SupplierUnmOrderWorkDB.SearchOrderProc Exception=" + ex.Message);
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
        private string MakeWhereString(ref SqlCommand sqlCommand, SupplierUnmOrderCndtnWork _supplierUnmOrderCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = "WHERE" + Environment.NewLine;


            //��ƃR�[�h
            retstring += " UOD.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_supplierUnmOrderCndtnWork.EnterpriseCode);

            //�V�X�e���敪 + �q�ɃR�[�h
            //if (_supplierUnmOrderCndtnWork.SystemDivCd == 0)
            //{
            //    retstring += " AND UOD.SYSTEMDIVCDRF=@SYSTEMDIVCD" + Environment.NewLine;
            //    SqlParameter paraSystemDivCd = sqlCommand.Parameters.Add("@SYSTEMDIVCD", SqlDbType.Int);
            //    paraSystemDivCd.Value = SqlDataMediator.SqlSetInt32(_supplierUnmOrderCndtnWork.SystemDivCd);
            //    retstring += " AND UOD.WAREHOUSECODERF =0" + Environment.NewLine;
            //}
            //else if (_supplierUnmOrderCndtnWork.SystemDivCd == 1)
            //{
            //    retstring += " AND UOD.SYSTEMDIVCDRF=@SYSTEMDIVCD" + Environment.NewLine;
            //    SqlParameter paraSystemDivCd = sqlCommand.Parameters.Add("@SYSTEMDIVCD", SqlDbType.Int);
            //    paraSystemDivCd.Value = SqlDataMediator.SqlSetInt32(_supplierUnmOrderCndtnWork.SystemDivCd);
            //}
            //else if (_supplierUnmOrderCndtnWork.SystemDivCd == 2)
            //{
            //    retstring += " AND UOD.SYSTEMDIVCDRF=@SYSTEMDIVCD" + Environment.NewLine;
            //    SqlParameter paraSystemDivCd = sqlCommand.Parameters.Add("@SYSTEMDIVCD", SqlDbType.Int);
            //    paraSystemDivCd.Value = SqlDataMediator.SqlSetInt32(_supplierUnmOrderCndtnWork.SystemDivCd);
            //    retstring += " AND UOD.WAREHOUSECODERF =0" + Environment.NewLine;
            //}

            retstring += " AND ((UOD.SYSTEMDIVCDRF=0 AND (UOD.WAREHOUSECODERF IS NULL OR UOD.WAREHOUSECODERF=0))" + Environment.NewLine;
            //retstring += " AND (((UOS.MAKERFOLLOWADDUPDIVRF = 0) AND((UOD.UOESECTOUTGOODSCNTRF !=0 AND UOD.UOESECTIONSLIPNORF = ' ') OR (UOD.BOSHIPMENTCNT1RF != 0 AND UOD.BOSLIPNO1RF= ' ') OR (UOD.BOSHIPMENTCNT2RF !=0 AND UOD.BOSLIPNO2RF= ' ') OR (UOD.BOSHIPMENTCNT3RF != 0 AND UOD.BOSLIPNO3RF= ' ') OR (UOD.MAKERFOLLOWCNTRF !=0) OR (UOD.EOALWCCOUNTRF !=0)))" + Environment.NewLine;
            //retstring += " OR ((UOS.MAKERFOLLOWADDUPDIVRF = 1) AND ((UOD.UOESECTOUTGOODSCNTRF !=0 AND UOD.UOESECTIONSLIPNORF = ' ') OR (UOD.BOSHIPMENTCNT1RF != 0 AND UOD.BOSLIPNO1RF= ' ') OR (UOD.BOSHIPMENTCNT2RF !=0 AND UOD.BOSLIPNO2RF= ' ') OR (UOD.BOSHIPMENTCNT3RF != 0 AND UOD.BOSLIPNO3RF= ' ')))))" + Environment.NewLine;

            retstring += " OR (UOD.SYSTEMDIVCDRF=1 AND (UOD.WAREHOUSECODERF IS NULL OR UOD.WAREHOUSECODERF=0))" + Environment.NewLine;
            //retstring += " AND (((UOS.MAKERFOLLOWADDUPDIVRF = 0) AND((UOD.UOESECTOUTGOODSCNTRF !=0 AND UOD.UOESECTIONSLIPNORF = ' ') OR (UOD.BOSHIPMENTCNT1RF != 0 AND UOD.BOSLIPNO1RF= ' ') OR (UOD.BOSHIPMENTCNT2RF !=0 AND UOD.BOSLIPNO2RF= ' ') OR (UOD.BOSHIPMENTCNT3RF != 0 AND UOD.BOSLIPNO3RF= ' ') OR (UOD.MAKERFOLLOWCNTRF !=0) OR (UOD.EOALWCCOUNTRF !=0)))" + Environment.NewLine;
            //retstring += " OR ((UOS.MAKERFOLLOWADDUPDIVRF = 1) AND ((UOD.UOESECTOUTGOODSCNTRF !=0 AND UOD.UOESECTIONSLIPNORF = ' ') OR (UOD.BOSHIPMENTCNT1RF != 0 AND UOD.BOSLIPNO1RF= ' ') OR (UOD.BOSHIPMENTCNT2RF !=0 AND UOD.BOSLIPNO2RF= ' ') OR (UOD.BOSHIPMENTCNT3RF != 0 AND UOD.BOSLIPNO3RF= ' ')))))" + Environment.NewLine;

            retstring += " OR (UOD.SYSTEMDIVCDRF=2))" + Environment.NewLine;

            //UOE���(0:UOE)
            retstring += " AND UOD.UOEKINDRF=0" + Environment.NewLine;


            //���_�R�[�h
            if (_supplierUnmOrderCndtnWork.SectionCodes != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in _supplierUnmOrderCndtnWork.SectionCodes)
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

            //�d����R�[�h
            if (_supplierUnmOrderCndtnWork.St_SupplierCd != 0)
            {
                retstring += " AND UOD.SUPPLIERCDRF>=@STSUPPLIERCD" + Environment.NewLine;
                SqlParameter paraStSupplierCd = sqlCommand.Parameters.Add("@STSUPPLIERCD", SqlDbType.Int);
                paraStSupplierCd.Value = SqlDataMediator.SqlSetInt32(_supplierUnmOrderCndtnWork.St_SupplierCd);
            }
            if (_supplierUnmOrderCndtnWork.Ed_SupplierCd != 0)
            {
                retstring += " AND UOD.SUPPLIERCDRF<=@EDSUPPLIERCD" + Environment.NewLine;
                SqlParameter paraEdSupplierCd = sqlCommand.Parameters.Add("@EDSUPPLIERCD", SqlDbType.Int);
                paraEdSupplierCd.Value = SqlDataMediator.SqlSetInt32(_supplierUnmOrderCndtnWork.Ed_SupplierCd);
            }

            //��M���t
            if (_supplierUnmOrderCndtnWork.St_ReceiveDate != DateTime.MinValue)
            {
                retstring += " AND UOD.RECEIVEDATERF>=@STRECEIVEDATE" + Environment.NewLine;
                SqlParameter paraStReceiveDate = sqlCommand.Parameters.Add("@STRECEIVEDATE", SqlDbType.Int);
                paraStReceiveDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_supplierUnmOrderCndtnWork.St_ReceiveDate);
            }
            if (_supplierUnmOrderCndtnWork.Ed_ReceiveDate != DateTime.MinValue)
            {
                retstring += " AND UOD.RECEIVEDATERF<=@EDRECEIVEDATE" + Environment.NewLine;
                SqlParameter paraEdReceiveDate = sqlCommand.Parameters.Add("@EDRECEIVEDATE", SqlDbType.Int);
                paraEdReceiveDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_supplierUnmOrderCndtnWork.Ed_ReceiveDate);
            }

            //UOE���Аݒ�}�X�^�̃��[�J�[�t�H���[�o��敪��"0:����","1:��"�̏ꍇ
            //retstring += "  AND (((UOS.MAKERFOLLOWADDUPDIVRF = 0) AND((UOD.UOESECTOUTGOODSCNTRF !=0 AND (UOD.UOESECTIONSLIPNORF = '' OR UOD.UOESECTIONSLIPNORF IS NULL)) OR (UOD.BOSHIPMENTCNT1RF != 0 AND (UOD.BOSLIPNO1RF= '' OR UOD.BOSLIPNO1RF IS NULL)) OR (UOD.BOSHIPMENTCNT2RF !=0 AND (UOD.BOSLIPNO2RF= '' OR UOD.BOSLIPNO2RF IS NULL)) OR (UOD.BOSHIPMENTCNT3RF != 0 AND (UOD.BOSLIPNO3RF= '' OR UOD.BOSLIPNO3RF IS NULL)) OR (UOD.MAKERFOLLOWCNTRF !=0) OR (UOD.EOALWCCOUNTRF !=0)))" + Environment.NewLine;
            //retstring += "   OR ((UOS.MAKERFOLLOWADDUPDIVRF = 1) AND ((UOD.UOESECTOUTGOODSCNTRF !=0 AND (UOD.UOESECTIONSLIPNORF = '' OR UOD.UOESECTIONSLIPNORF IS NULL)) OR (UOD.BOSHIPMENTCNT1RF != 0 AND (UOD.BOSLIPNO1RF= '' OR UOD.BOSLIPNO1RF IS NULL)) OR (UOD.BOSHIPMENTCNT2RF !=0 AND (UOD.BOSLIPNO2RF= '' OR UOD.BOSLIPNO2RF IS NULL)) OR (UOD.BOSHIPMENTCNT3RF != 0 AND (UOD.BOSLIPNO3RF= '' OR UOD.BOSLIPNO3RF IS NULL)))))" + Environment.NewLine;

            retstring += "    AND (((UOS.MAKERFOLLOWADDUPDIVRF = 0) AND((UOD.UOESECTOUTGOODSCNTRF !=0 AND (UOD.UOESECTIONSLIPNORF = '' OR UOD.UOESECTIONSLIPNORF IS NULL)) OR (UOD.BOSHIPMENTCNT1RF != 0 AND (UOD.BOSLIPNO1RF= '' OR UOD.BOSLIPNO1RF IS NULL)) OR (UOD.BOSHIPMENTCNT2RF !=0 AND (UOD.BOSLIPNO2RF= '' OR UOD.BOSLIPNO2RF IS NULL)) OR (UOD.BOSHIPMENTCNT3RF != 0 AND (UOD.BOSLIPNO3RF= '' OR UOD.BOSLIPNO3RF IS NULL)) OR (UOD.MAKERFOLLOWCNTRF !=0) OR (UOD.EOALWCCOUNTRF !=0)))" + Environment.NewLine;
            retstring += "     OR ((UOS.MAKERFOLLOWADDUPDIVRF = 1 AND SYSTEMDIVCDRF =1) AND ((UOD.UOESECTOUTGOODSCNTRF !=0 AND (UOD.UOESECTIONSLIPNORF = '' OR UOD.UOESECTIONSLIPNORF IS NULL)) OR (UOD.BOSHIPMENTCNT1RF != 0 AND (UOD.BOSLIPNO1RF= '' OR UOD.BOSLIPNO1RF IS NULL)) OR (UOD.BOSHIPMENTCNT2RF !=0 AND (UOD.BOSLIPNO2RF= '' OR UOD.BOSLIPNO2RF IS NULL)) OR (UOD.BOSHIPMENTCNT3RF != 0 AND (UOD.BOSLIPNO3RF= '' OR UOD.BOSLIPNO3RF IS NULL) )))" + Environment.NewLine;
            retstring += "     OR ((UOS.MAKERFOLLOWADDUPDIVRF = 1 AND (SYSTEMDIVCDRF =0 OR SYSTEMDIVCDRF = 2)) AND ((UOD.UOESECTOUTGOODSCNTRF !=0 AND (UOD.UOESECTIONSLIPNORF = '' OR UOD.UOESECTIONSLIPNORF IS NULL)) OR (UOD.BOSHIPMENTCNT1RF != 0 AND (UOD.BOSLIPNO1RF= '' OR UOD.BOSLIPNO1RF IS NULL)) OR (UOD.BOSHIPMENTCNT2RF !=0 AND (UOD.BOSLIPNO2RF= '' OR UOD.BOSLIPNO2RF IS NULL)) OR (UOD.BOSHIPMENTCNT3RF != 0 AND (UOD.BOSLIPNO3RF= '' OR UOD.BOSLIPNO3RF IS NULL) ) OR (UOD.MAKERFOLLOWCNTRF !=0) OR (UOD.EOALWCCOUNTRF !=0))))" + Environment.NewLine;


            //���M�t���O
            retstring += " AND UOD.DATASENDCODERF=9" + Environment.NewLine;

            //�����t���O
            retstring += " AND UOD.DATARECOVERDIVRF=9" + Environment.NewLine;

            #endregion
            return retstring;
        }
    }
}

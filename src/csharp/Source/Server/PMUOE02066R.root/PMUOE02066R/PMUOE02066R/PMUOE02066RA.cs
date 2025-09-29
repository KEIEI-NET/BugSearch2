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
    /// ���ɗ\��\DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���ɗ\��\���f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30350 �N�� ����</br>
    /// <br>Date       : 2008.9.18</br>
    /// <br>Note       : �n���f�B�^�[�~�i���񎟊J���̑Ή�</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2017/09/14</br>
    /// </remarks>
    [Serializable]
    public class EnterSchOrderWorkDB : RemoteDB, IEnterSchOrderWorkDB
    {
        /// <summary>
        /// ���ɗ\��\DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.9.18</br>
        /// </remarks>
        public EnterSchOrderWorkDB()
            :
        base("PMUOE02068D", "Broadleaf.Application.Remoting.ParamData.EnterSchResultWork", "UOEORDERDTLRF") //���N���X�̃R���X�g���N�^
        {
        }

        #region ���ɗ\��\
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̓��ɗ\��\LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="enterSchResultWork">��������</param>
        /// <param name="enterSchOrderCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̔��s�m�F�ꗗ�\LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.9.18</br>
        public int Search(out object enterSchResultWork, object enterSchOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            enterSchResultWork = null;

            EnterSchOrderCndtnWork _enterSchOrderCndtnWork = enterSchOrderCndtnWork as EnterSchOrderCndtnWork;

            try
            {
                status = SearchProc(out enterSchResultWork, _enterSchOrderCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EnterSchOrderWork.Search Exception=" + ex.Message);
                enterSchResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̓��ɗ\��\LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="enterSchResultWork">��������</param>
        /// <param name="_enterSchOrderCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̔��s�m�F�ꗗ�\LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.9.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.10.15 ���� DC.NS�p�ɏC��</br>
        private int SearchProc(out object enterSchResultWork, EnterSchOrderCndtnWork _enterSchOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            enterSchResultWork = null;

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


                status = SearchOrderProc(ref al, ref sqlConnection, _enterSchOrderCndtnWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "enterSchResultWorkDB.SearchProc Exception=" + ex.Message);
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

            enterSchResultWork = al;

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
        /// <remarks>
        /// <br>Note       : �n���f�B�^�[�~�i���񎟊J���̑Ή�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/09/14</br>
        /// </remarks>
        private int SearchOrderProc(ref ArrayList al, ref SqlConnection sqlConnection, EnterSchOrderCndtnWork _enterSchOrderCndtnWork, ConstantManagement.LogicalMode logicalMode)
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
                selectTxt += "        ,UOD.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "        ,UOD.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "        ,UOD.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "        ,UOD.GOODSNORF" + Environment.NewLine;
                selectTxt += "        ,UOD.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "        ,UOD.GOODSNAMERF" + Environment.NewLine;
                selectTxt += "        ,UOD.ACCEPTANORDERCNTRF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOESECTOUTGOODSCNTRF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOSHIPMENTCNT1RF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOSHIPMENTCNT2RF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOSHIPMENTCNT3RF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAKERFOLLOWCNTRF" + Environment.NewLine;
                selectTxt += "        ,UOD.EOALWCCOUNTRF" + Environment.NewLine;
                selectTxt += "        ,UOD.ANSWERLISTPRICERF" + Environment.NewLine;
                selectTxt += "        ,UOD.ANSWERSALESUNITCOSTRF" + Environment.NewLine;
                selectTxt += "        ,UOD.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOSLIPNO1RF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOSLIPNO2RF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOSLIPNO3RF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOESECTIONSLIPNORF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOEREMARK1RF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOEREMARK2RF" + Environment.NewLine;
                selectTxt += "        ,UOD.RECEIVEDATERF" + Environment.NewLine;
                // ------ ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- >>>>
                selectTxt += "        ,UOD.COMMASSEMBLYIDRF" + Environment.NewLine;
                // ------ ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- <<<<
                selectTxt += " FROM UOEORDERDTLRF AS UOD" + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "     SEC.ENTERPRISECODERF=UOD.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "AND  SEC.SECTIONCODERF=UOD.SECTIONCODERF" + Environment.NewLine;


                //WHERE���̍쐬
                selectTxt += MakeWhereString(ref sqlCommand, _enterSchOrderCndtnWork, logicalMode);

                sqlCommand.CommandText = selectTxt;


                #endregion

               myReader = sqlCommand.ExecuteReader(); 
                
                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    EnterSchResultWork wkEnterSchResultWork = new EnterSchResultWork();

                    //�i�[����
                    wkEnterSchResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    wkEnterSchResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    wkEnterSchResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    wkEnterSchResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    wkEnterSchResultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    wkEnterSchResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkEnterSchResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    wkEnterSchResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    wkEnterSchResultWork.AcceptAnOrderCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACCEPTANORDERCNTRF"));
                    wkEnterSchResultWork.UOESectOutGoodsCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESECTOUTGOODSCNTRF"));
                    wkEnterSchResultWork.BOShipmentCnt1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOSHIPMENTCNT1RF"));
                    wkEnterSchResultWork.BOShipmentCnt2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOSHIPMENTCNT2RF"));
                    wkEnterSchResultWork.BOShipmentCnt3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOSHIPMENTCNT3RF"));
                    wkEnterSchResultWork.MakerFollowCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERFOLLOWCNTRF"));
                    wkEnterSchResultWork.EOAlwcCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EOALWCCOUNTRF"));
                    wkEnterSchResultWork.AnswerListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ANSWERLISTPRICERF"));
                    wkEnterSchResultWork.AnswerSalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ANSWERSALESUNITCOSTRF"));
                    wkEnterSchResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    wkEnterSchResultWork.BOSlipNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BOSLIPNO1RF"));
                    wkEnterSchResultWork.BOSlipNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BOSLIPNO2RF"));
                    wkEnterSchResultWork.BOSlipNo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BOSLIPNO3RF"));
                    wkEnterSchResultWork.UOESectionSlipNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESECTIONSLIPNORF"));
                    wkEnterSchResultWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
                    wkEnterSchResultWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
                    wkEnterSchResultWork.ReceiveDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RECEIVEDATERF"));

                    // ------ ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- >>>>
                    wkEnterSchResultWork.CommAssemblyId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMMASSEMBLYIDRF"));
                    // ------ ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- <<<<

                    #endregion
                    if (_enterSchOrderCndtnWork.PrintTypeCndtn == 0)
                    {
                        if ((wkEnterSchResultWork.UOESectOutGoodsCnt + wkEnterSchResultWork.BOShipmentCnt1 + wkEnterSchResultWork.BOShipmentCnt2 + wkEnterSchResultWork.BOShipmentCnt3 + wkEnterSchResultWork.MakerFollowCnt + wkEnterSchResultWork.EOAlwcCount) != 0)
                        {
                            al.Add(wkEnterSchResultWork);
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }
                    else if (_enterSchOrderCndtnWork.PrintTypeCndtn == 2)
                    {
                        if ((wkEnterSchResultWork.UOESectOutGoodsCnt + wkEnterSchResultWork.BOShipmentCnt1 + wkEnterSchResultWork.BOShipmentCnt2 + wkEnterSchResultWork.BOShipmentCnt3 + wkEnterSchResultWork.MakerFollowCnt + wkEnterSchResultWork.EOAlwcCount) == 0)
                        {
                            al.Add(wkEnterSchResultWork);
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }
                    else
                    {
                        al.Add(wkEnterSchResultWork);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "enterSchResultWorkDB.SearchOrderProc Exception=" + ex.Message);
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
        private string MakeWhereString(ref SqlCommand sqlCommand, EnterSchOrderCndtnWork _enterSchOrderCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = "WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " UOD.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_enterSchOrderCndtnWork.EnterpriseCode);

            //�V�X�e���敪
            retstring += " AND UOD.SYSTEMDIVCDRF!=1" + Environment.NewLine;

            //���_�R�[�h
            if (_enterSchOrderCndtnWork.SectionCodes != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in _enterSchOrderCndtnWork.SectionCodes)
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

            //�͈͔�����R�[�h
            if (_enterSchOrderCndtnWork.UOESupplierCds != null)
            {
                string uoeSupplierCdstr = "";
                foreach (int usupcdstr in _enterSchOrderCndtnWork.UOESupplierCds)
                {
                    if (uoeSupplierCdstr != "")
                    {
                        uoeSupplierCdstr += ",";
                    }
                    uoeSupplierCdstr += "'" + usupcdstr + "'";
                }

                if (uoeSupplierCdstr != "")
                {
                    retstring += " AND (UOD.UOESUPPLIERCDRF IN (" + uoeSupplierCdstr + ") OR UOD.UOESUPPLIERCDRF=0)" + Environment.NewLine;
                }
            }
            else
            {

                if (_enterSchOrderCndtnWork.St_UOESupplierCd != 0)
                {
                    retstring += " AND UOD.UOESUPPLIERCDRF>=@STUOESUPPLIERCD" + Environment.NewLine;
                    SqlParameter paraStUOESupplierCd = sqlCommand.Parameters.Add("@STUOESUPPLIERCD", SqlDbType.Int);
                    paraStUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(_enterSchOrderCndtnWork.St_UOESupplierCd);
                }
                if (_enterSchOrderCndtnWork.Ed_UOESupplierCd != 0)
                {
                    retstring += " AND UOD.UOESUPPLIERCDRF<=@EDUOESUPPLIERCD" + Environment.NewLine;
                    SqlParameter paraEdUOESupplierCd = sqlCommand.Parameters.Add("@EDUOESUPPLIERCD", SqlDbType.Int);
                    paraEdUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(_enterSchOrderCndtnWork.Ed_UOESupplierCd);
                }
            }
            //��M���t
            if (_enterSchOrderCndtnWork.St_ReceiveDate != DateTime.MinValue)
            {

                retstring += " AND UOD.RECEIVEDATERF>=@STRECEIVEDATE" + Environment.NewLine;
                SqlParameter paraStReceiveDate = sqlCommand.Parameters.Add("@STRECEIVEDATE", SqlDbType.Int);
                paraStReceiveDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_enterSchOrderCndtnWork.St_ReceiveDate);
            }
            if (_enterSchOrderCndtnWork.Ed_ReceiveDate != DateTime.MinValue)
            {
                retstring += " AND UOD.RECEIVEDATERF<=@EDRECEIVEDATE" + Environment.NewLine;
                SqlParameter paraEdReceiveDate = sqlCommand.Parameters.Add("@EDRECEIVEDATE", SqlDbType.Int);
                paraEdReceiveDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_enterSchOrderCndtnWork.Ed_ReceiveDate);
            }

            //���ɍX�V�敪
            if (_enterSchOrderCndtnWork.PrintTypeCndtn != 2)
            {
                retstring += " AND ((UOD.ENTERUPDDIVSECRF=0) OR (UOD.ENTERUPDDIVBO1RF=0) OR (UOD.ENTERUPDDIVBO2RF=0) OR (UOD.ENTERUPDDIVBO3RF=0) OR (UOD.ENTERUPDDIVMAKERRF=0) OR (UOD.ENTERUPDDIVEORF=0))" + Environment.NewLine;
            }

            //�q�ɃR�[�h
            retstring += " AND UOD.WAREHOUSECODERF !=0" + Environment.NewLine;

            ////����^�C�v�@���ɕ��̂�
            //if (_enterSchOrderCndtnWork.PrintTypeCndtn == 0)
            //{
            //    retstring += " AND (UOD.UOESECTOUTGOODSCNTRF + UOD.BOSHIPMENTCNT1RF + UOD.BOSHIPMENTCNT2RF + UOD.BOSHIPMENTCNT3RF + UOD.MAKERFOLLOWCNTRF + UOD.EOALWCCOUNTRF) != 0" + Environment.NewLine;
            //}
            //����^�C�v�@���[�J�[�t�H���[���̂�
            if (_enterSchOrderCndtnWork.PrintTypeCndtn == 1)
            {
                retstring += " AND UOD.MAKERFOLLOWCNTRF != 0" + Environment.NewLine;
            }
            ////����^�C�v�@���i���̂݁@
            //else if (_enterSchOrderCndtnWork.PrintTypeCndtn == 2)
            //{
            //    retstring += " AND (UOD.UOESECTOUTGOODSCNTRF + UOD.BOSHIPMENTCNT1RF + UOD.BOSHIPMENTCNT2RF + UOD.BOSHIPMENTCNT3RF + UOD.MAKERFOLLOWCNTRF + UOD.EOALWCCOUNTRF) = 0" + Environment.NewLine;
            //}

            //���M�t���O
            retstring += " AND UOD.DATASENDCODERF=9" + Environment.NewLine;

            //�����t���O
            retstring += " AND UOD.DATARECOVERDIVRF=9" + Environment.NewLine;

            #endregion
            return retstring;
        }
    }
}
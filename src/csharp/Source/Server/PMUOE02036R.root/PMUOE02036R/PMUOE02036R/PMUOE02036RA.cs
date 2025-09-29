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
    /// �����ꗗ�\DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����ꗗ�\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2007.10.15</br>
    /// <br></br>
    /// <br>Update Note:</br>
    /// </remarks>
    [Serializable]
    public class SendBeforOrderWorkDB : RemoteDB, ISendBeforOrdeWorkDB
    {
        /// <summary>
        /// �����ꗗ�\DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
        public SendBeforOrderWorkDB()
            :
        base("PMUOE02038D", "Broadleaf.Application.Remoting.ParamData.SendBeforResultWork", "UOEOrderDtlRF") //���N���X�̃R���X�g���N�^
        {
        }

        #region �����ꗗ�\
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̔����ꗗ�\LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="orderListResultWork">��������</param>
        /// <param name="orderListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̔����ꗗ�\LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.10.15</br>
        public int Search(out object sendBeforResultWork, object sendBeforOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            sendBeforResultWork = null;

            SendBeforOrderCndtnWork _sendBeforOrderCndtnWork = sendBeforOrderCndtnWork as SendBeforOrderCndtnWork;

            try
            {
                status = SearchProc(out sendBeforResultWork, _sendBeforOrderCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "sendBeforWork.Search Exception=" + ex.Message);
                sendBeforResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̔����ꗗ�\LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="orderListResultWork">��������</param>
        /// <param name="_orderListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̔����ꗗ�\LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.10.15</br>
        /// <br></br>
        /// <br>Update Note: 2007.10.15 ���� DC.NS�p�ɏC��</br>
        private int SearchProc(out object sendBeforResultWork, SendBeforOrderCndtnWork _sendBeforOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            sendBeforResultWork = null;

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


                status = SearchOrderProc(ref al, ref sqlConnection, _sendBeforOrderCndtnWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SendBeforResultWorkDB.SearchProc Exception=" + ex.Message);
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

            sendBeforResultWork = al;

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
        private int SearchOrderProc(ref ArrayList al, ref SqlConnection sqlConnection, SendBeforOrderCndtnWork _sendBeforOrderCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                #region Select���쐬

                selectTxt += " SELECT " + Environment.NewLine;
                selectTxt += "	       UOD.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "        ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOESUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOESUPPLIERNAMERF" + Environment.NewLine;
                selectTxt += "        ,UOD.ONLINENORF" + Environment.NewLine;
                selectTxt += "        ,UOD.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "        ,UOD.EMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "        ,UOD.GOODSNORF" + Environment.NewLine;
                selectTxt += "        ,UOD.GOODSNAMERF" + Environment.NewLine;
                selectTxt += "        ,UOD.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "        ,UOD.ACCEPTANORDERCNTRF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOCODERF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOEREMARK1RF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOEREMARK2RF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOEDELIGOODSDIVRF" + Environment.NewLine;
                selectTxt += "        ,UOD.FOLLOWDELIGOODSDIVRF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOERESVDSECTIONRF" + Environment.NewLine;
                selectTxt += " FROM UOEORDERDTLRF AS UOD" + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "     SEC.ENTERPRISECODERF=UOD.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "AND  SEC.SECTIONCODERF=UOD.SECTIONCODERF" + Environment.NewLine;

                //WHERE���̍쐬
                selectTxt += MakeWhereString(ref sqlCommand, _sendBeforOrderCndtnWork, logicalMode);

                sqlCommand.CommandText = selectTxt;


                #endregion

                myReader = sqlCommand.ExecuteReader();  
                
                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    SendBeforResultWork wkSendBeforResultWork = new SendBeforResultWork();
                    
                    //�i�[����
                    wkSendBeforResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    wkSendBeforResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    wkSendBeforResultWork.UOESupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESUPPLIERCDRF"));
                    wkSendBeforResultWork.UOESupplierName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESUPPLIERNAMERF"));
                    wkSendBeforResultWork.OnlineNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ONLINENORF"));
                    wkSendBeforResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    wkSendBeforResultWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                    wkSendBeforResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkSendBeforResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    wkSendBeforResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    wkSendBeforResultWork.AcceptAnOrderCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACCEPTANORDERCNTRF"));
                    wkSendBeforResultWork.BoCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BOCODERF"));
                    wkSendBeforResultWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
                    wkSendBeforResultWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
                    wkSendBeforResultWork.UOEDeliGoodsDiv = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEDELIGOODSDIVRF"));
                    wkSendBeforResultWork.FollowDeliGoodsDiv = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FOLLOWDELIGOODSDIVRF"));
                    wkSendBeforResultWork.UOEResvdSection = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOERESVDSECTIONRF"));
                    #endregion

                    al.Add(wkSendBeforResultWork);

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
                base.WriteErrorLog(ex, "SendBeforResultWorkDB.SearchOrderProc Exception=" + ex.Message);
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
        private string MakeWhereString(ref SqlCommand sqlCommand, SendBeforOrderCndtnWork _sendBeforOrderCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = "WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " UOD.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_sendBeforOrderCndtnWork.EnterpriseCode);

            //�V�X�e���敪
            if (_sendBeforOrderCndtnWork.SystemDivCd != -1)
            {
                retstring += " AND UOD.SYSTEMDIVCDRF=@SYSTEMDIVCD" + Environment.NewLine;
                SqlParameter paraStExpectDeliveryDate = sqlCommand.Parameters.Add("@SYSTEMDIVCD", SqlDbType.Int);
                paraStExpectDeliveryDate.Value = SqlDataMediator.SqlSetInt32(_sendBeforOrderCndtnWork.SystemDivCd);
            }

            //UOE���(0:UOE)
            retstring += " AND UOD.UOEKINDRF=0" + Environment.NewLine;

            //�����ԍ�
            if (_sendBeforOrderCndtnWork.St_OnlineNo != 0)
            {
                retstring += " AND UOD.ONLINENORF>=@STONLINENO" + Environment.NewLine;
                SqlParameter paraStOnlineNo = sqlCommand.Parameters.Add("@STONLINENO", SqlDbType.Int);
                paraStOnlineNo.Value = SqlDataMediator.SqlSetInt32(_sendBeforOrderCndtnWork.St_OnlineNo);
            }
            if (_sendBeforOrderCndtnWork.Ed_OnlineNo != 0)
            {
                retstring += " AND UOD.ONLINENORF<=@EDONLINENO" + Environment.NewLine;
                SqlParameter paraEdOnlineNo = sqlCommand.Parameters.Add("@EDONLINENO", SqlDbType.Int);
                paraEdOnlineNo.Value = SqlDataMediator.SqlSetInt32(_sendBeforOrderCndtnWork.Ed_OnlineNo);
            }

            //���_�R�[�h
            //if( _sendBeforOrderCndtnWork.SectionCodes != null)
            if ( _sendBeforOrderCndtnWork.SectionCodes[0] != "0")
            {
                string sectionCodestr = "";
                foreach (string seccdstr in _sendBeforOrderCndtnWork.SectionCodes)
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

            //������R�[�h
            if (_sendBeforOrderCndtnWork.St_UOESupplierCd != 0)
            {
                retstring += " AND UOD.UOESUPPLIERCDRF>=@STUOESUPPLIERCD" + Environment.NewLine;
                SqlParameter paraStUOESupplierCd = sqlCommand.Parameters.Add("@STUOESUPPLIERCD", SqlDbType.Int);
                paraStUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(_sendBeforOrderCndtnWork.St_UOESupplierCd);
            }
            if (_sendBeforOrderCndtnWork.Ed_UOESupplierCd != 0)
            {
                retstring += " AND UOD.UOESUPPLIERCDRF<=@EDUOESUPPLIERCD" + Environment.NewLine;
                SqlParameter paraEdUOESupplierCd = sqlCommand.Parameters.Add("@EDUOESUPPLIERCD", SqlDbType.Int);
                paraEdUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(_sendBeforOrderCndtnWork.Ed_UOESupplierCd);
            }

            //���M�t���O
            retstring += " AND UOD.DATASENDCODERF=0" + Environment.NewLine;

            //�����t���O
            retstring += " AND UOD.DATARECOVERDIVRF=0" + Environment.NewLine;

            #endregion
            return retstring;
        }
    }
}


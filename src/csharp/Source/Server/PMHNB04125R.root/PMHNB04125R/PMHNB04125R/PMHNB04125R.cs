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
    /// ���Ӑ�ߔN�x���яƉ�DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�ߔN�x���яƉ�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30350 �N�� ����</br>
    /// <br>Date       : 2008.9.10</br>
    /// <br>Update Note: 2010/08/02 chenyd</br>
    /// <br>             Excel�A�e�L�X�g�o�͑Ή�</br>
    /// <br>Update Note: 2011/03/22 ������</br>
    /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
    /// </remarks>
    [Serializable]
    public class CustomInqOrderWorkDB : RemoteDB, ICustomInqOrderWorkDB
    {
        /// <summary>
        /// ���Ӑ�ߔN�x���яƉ�DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.10.8</br>
        /// </remarks>
        public CustomInqOrderWorkDB()
            :
        base("PMHNB04125D", "Broadleaf.Application.Remoting.ParamData.CustomInqResultWork", "MTtlSalesSlipRF") //���N���X�̃R���X�g���N�^
        {
        }

        #region ���Ӑ�ߔN�x���яƉ�
        // ---------------------- ADD 2010/08/02 --------------------------------->>>>>
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̓��Ӑ�ߔN�x���яƉ�LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="retListObj">��������</param>
        /// <param name="paraList">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓��Ӑ�ߔN�x���яƉ�LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2010/08/02</br>
        /// <br>Update Note: 2011/03/22 ������</br>
        /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
        public int SearchAll(out object retListObj, object paraList, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retListObj = null;
            object retObj = null;

            ArrayList resultWorkList = new ArrayList();
            ArrayList paraCndtnWorkList = paraList as ArrayList;
            ArrayList customInqResultWorkList = new ArrayList();

            SqlConnection sqlConnection = null; // 2011/03/22
            try
            {
                // ---ADD 2011/03/22---------->>>>>
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, ((CustomInqOrderCndtnWork)paraCndtnWorkList[0]).EnterpriseCode, "���Ӑ�ߔN�x���яƉ�", "���o�J�n");
                // ---ADD 2011/03/22----------<<<<<

                foreach (CustomInqOrderCndtnWork paraCndtnWork in paraCndtnWorkList)
                {

                    status = SearchProc(out retObj, paraCndtnWork, readMode, logicalMode);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        customInqResultWorkList = (ArrayList)retObj;
                        resultWorkList.Add(customInqResultWorkList);
                    }
                }

                // ---ADD 2011/03/22---------->>>>>
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, ((CustomInqOrderCndtnWork)paraCndtnWorkList[0]).EnterpriseCode, "���Ӑ�ߔN�x���яƉ�", "���o�I��");
                // ---ADD 2011/03/22----------<<<<<
                if (resultWorkList.Count >= 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                retListObj = (object)resultWorkList;
                
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "customInqOrderWork.Search Exception=" + ex.Message);
                resultWorkList = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            // ---ADD 2011/03/22---------->>>>>
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            // ---ADD 2011/03/22----------<<<<<
            return status;
        }
        // ---------------------- ADD 2010/08/02 ---------------------------------<<<<<
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̓��Ӑ�ߔN�x���яƉ�LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="customInqResultWorkList">��������</param>
        /// <param name="customInqOrderCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓��Ӑ�ߔN�x���яƉ�LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.10.8</br>
        /// <br>Update Note: 2011/03/22 ������</br>
        /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
        public int Search(out object customInqResultWorkList, object customInqOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            customInqResultWorkList = null;

            CustomInqOrderCndtnWork _customInqOrderCndtnWork = customInqOrderCndtnWork as CustomInqOrderCndtnWork;

            SqlConnection sqlConnection = null; // 2011/03/22
            try
            {
                // ---ADD 2011/03/22---------->>>>>
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _customInqOrderCndtnWork.EnterpriseCode, "���Ӑ�ߔN�x���яƉ�", "���o�J�n");
                // ---ADD 2011/03/22----------<<<<<

                status = SearchProc(out customInqResultWorkList, _customInqOrderCndtnWork, readMode, logicalMode);

                // ---ADD 2011/03/22---------->>>>>
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _customInqOrderCndtnWork.EnterpriseCode, "���Ӑ�ߔN�x���яƉ�", "���o�I��");
                // ---ADD 2011/03/22----------<<<<<
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "customInqOrderWork.Search Exception=" + ex.Message);
                customInqResultWorkList = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            // ---ADD 2011/03/22---------->>>>>
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            // ---ADD 2011/03/22----------<<<<<
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̓��Ӑ�ߔN�x���яƉ�LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="customInqResultWorkList">��������</param>
        /// <param name="_customInqOrderCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓��Ӑ�ߔN�x���яƉ�LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.9.10</br>
        /// <br></br>
        /// <br>Update Note: 2007.10.15 ���� DC.NS�p�ɏC��</br>
        private int SearchProc(out object customInqResultWorkList, CustomInqOrderCndtnWork _customInqOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            customInqResultWorkList = null;

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


                status = SearchOrderProc(ref al, ref sqlConnection, _customInqOrderCndtnWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustomInqResultWorkDB.SearchProc Exception=" + ex.Message);
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

            customInqResultWorkList = al;

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
        private int SearchOrderProc(ref ArrayList al, ref SqlConnection sqlConnection, CustomInqOrderCndtnWork _customInqOrderCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try{
                string selectTxt="";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);
                for (int i = 0; i < 8; i++)
                {
                    selectTxt = "";
                    sqlCommand.Parameters.Clear();
                    #region Select���쐬
                    selectTxt += "SELECT " + Environment.NewLine;
                    selectTxt += "	       MTL.ENTERPRISECODERF" + Environment.NewLine;
                    if (_customInqOrderCndtnWork.AddUpSecCode != "")
                    {
                        selectTxt += "        ,MTL.ADDUPSECCODERF" + Environment.NewLine;
                    }
                    selectTxt += "        ,MTL.CUSTOMERCODERF" + Environment.NewLine;
                    selectTxt += "        ,(SUM(MTL.SALESMONEYRF) + SUM(MTL.SALESRETGOODSPRICERF) + SUM(MTL.DISCOUNTPRICERF)) AS  SUMSALESMONEYRF" + Environment.NewLine;
                    //selectTxt += "        ,SUM(MTL.SALESRETGOODSPRICERF) AS SUMSALESRETGOODSPRICERF" + Environment.NewLine;
                    //selectTxt += "        ,SUM(MTL.DISCOUNTPRICERF) AS SUMDISCOUNTPRICERF" + Environment.NewLine;
                    selectTxt += "        ,SUM(MTL.GROSSPROFITRF) AS SUMGROSSPROFITRF" + Environment.NewLine;
                    selectTxt += " FROM MTTLSALESSLIPRF AS MTL " + Environment.NewLine;
                    #endregion

                    //WHERE���̍쐬
                    selectTxt += MakeWhereString(ref sqlCommand, _customInqOrderCndtnWork, logicalMode);

                    selectTxt += " GROUP BY MTL.ENTERPRISECODERF" + Environment.NewLine;
                    if (_customInqOrderCndtnWork.AddUpSecCode != "")
                    {
                        selectTxt += " ,MTL.ADDUPSECCODERF" + Environment.NewLine;
                    }
                    selectTxt += " ,MTL.CUSTOMERCODERF" + Environment.NewLine;

                    sqlCommand.CommandText = selectTxt;

                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        #region ���o����-�l�Z�b�g
                        CustomInqResultWork wkCustomInqResultWork = new CustomInqResultWork();

                        //�i�[����
                        wkCustomInqResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        if (_customInqOrderCndtnWork.AddUpSecCode != "")
                        {
                            wkCustomInqResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                        }
                        else
                        {
                            wkCustomInqResultWork.AddUpSecCode = "";
                        }
                        wkCustomInqResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                        wkCustomInqResultWork.SalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMSALESMONEYRF"));
                        wkCustomInqResultWork.SalesRetGoodsPrice = 0;//SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMSALESRETGOODSPRICERF"));
                        wkCustomInqResultWork.DiscountPrice = 0;//SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMDISCOUNTPRICERF"));
                        wkCustomInqResultWork.GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMGROSSPROFITRF"));
                        #endregion

                        al.Add(wkCustomInqResultWork);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                    if (al.Count != i+1)
                    {
                        CustomInqResultWork wkCustomInqResultWork = new CustomInqResultWork();
                        wkCustomInqResultWork.EnterpriseCode = "";
                        wkCustomInqResultWork.AddUpSecCode = "";
                        wkCustomInqResultWork.CustomerCode = 0;
                        wkCustomInqResultWork.SalesMoney = 0;
                        wkCustomInqResultWork.SalesRetGoodsPrice = 0;
                        wkCustomInqResultWork.DiscountPrice = 0;
                        wkCustomInqResultWork.GrossProfit = 0;
                        al.Add(wkCustomInqResultWork);
                    }
                    _customInqOrderCndtnWork.St_AddUpYearMonth = _customInqOrderCndtnWork.St_AddUpYearMonth.AddYears(-1);
                    _customInqOrderCndtnWork.Ed_AddUpYearMonth = _customInqOrderCndtnWork.Ed_AddUpYearMonth.AddYears(-1);
                    if (!myReader.IsClosed) myReader.Close();
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "customInqResultWork.SearchOrderProc Exception=" + ex.Message);
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
        private string MakeWhereString(ref SqlCommand sqlCommand, CustomInqOrderCndtnWork _customInqOrderCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = "WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " MTL.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_customInqOrderCndtnWork.EnterpriseCode);

            if (_customInqOrderCndtnWork.AddUpSecCode != "")
            {
                //�v�㋒�_�R�[�h
                retstring += " AND MTL.ADDUPSECCODERF=@ADDUPSECCODE" + Environment.NewLine;
                SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(_customInqOrderCndtnWork.AddUpSecCode);
            }
            else
            {
                retstring += " AND MTL.ADDUPSECCODERF IN (SELECT SECTIONCODERF FROM SECINFOSETRF WHERE ENTERPRISECODERF=@ENTERPRISECODE AND LOGICALDELETECODERF = 0)" + Environment.NewLine; // ADD 2010/09/20
            }

            //���Ӑ�R�[�h
            retstring += " AND MTL.CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
            SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
            paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(_customInqOrderCndtnWork.CustomerCode);

            //�N���x
            if (_customInqOrderCndtnWork.St_AddUpYearMonth != DateTime.MinValue)
            {
                retstring += " AND MTL.ADDUPYEARMONTHRF>=@STADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraStAddUpYearMonth = sqlCommand.Parameters.Add("@STADDUPYEARMONTH", SqlDbType.Int);
                paraStAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_customInqOrderCndtnWork.St_AddUpYearMonth);
            }
            if (_customInqOrderCndtnWork.Ed_AddUpYearMonth != DateTime.MinValue)
            {
                retstring += " AND MTL.ADDUPYEARMONTHRF<=@EDADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraEdAddUpYearMonth = sqlCommand.Parameters.Add("@EDADDUPYEARMONTH", SqlDbType.Int);
                paraEdAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_customInqOrderCndtnWork.Ed_AddUpYearMonth);
            }

            // ���яW�v�敪
            retstring += "  AND MTL.RSLTTTLDIVCDRF = 0" + Environment.NewLine;

            // �]�ƈ��敪
            retstring += " AND EMPLOYEEDIVCDRF = 10" + Environment.NewLine;
            #endregion
            return retstring;
        }
    }
}


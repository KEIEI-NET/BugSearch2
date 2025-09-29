using System;
using System.Collections;
using System.Collections.Generic;
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
    /// �������DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ������т̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���쏹��</br>
    /// <br>Date       : 2007.11.26</br>
    /// <br></br>
    /// <br>Update Note: PM.NS�Ή�</br>
    /// <br>Programmer : 23015 �X�{ ��P</br>
    /// <br>Date       : 2008.09.02</br>
    /// <br>Update Note: 2009.04.11 ����</br>
    /// <br>           �E������ѕ\�i�d����ʁj�̒ǉ�</br>
    /// <br>Update Note: 2010/01/07 �Ė� �x��</br>
    /// <br>           �EMantis�F14722,14830�@�q�ɕʂɂ͑q�ɃR�[�h0000�i���j�͈󎚂��Ȃ��l�ɏC��</br>
    /// <br>Update Note: 2010/01/13 �Ė� �x��</br>
    /// <br>           �EMantis�F14878�@���w�莞�A�o�͌��ʂɈُ킪���錏�̏C��</br>
    ///                  BLGROUPCODERF�CGOODSMGROUPRF�CGOODSLGROUPRF��NULL�̏ꍇ��0�Ƃ��Ĉ����l�ɏC��
    /// <br>Update Note: 2010/05/13 �������n</br>
    /// <br>            �E�i���̎擾���@��ύX
    /// <br>Update Note: 2011/04/21 �������n</br>
    /// <br>            ������ѕ\�i�q�ɕʁj�̏C��
    /// <br>            �E�g�p���鋒�_�����_�R�[�h����v�㋒�_�R�[�h�ɕύX
    /// <br>            �EWHERE��̏I�������̒ǉ�����ɕs������邽�ߏC��
    /// <br>            �E���x�`���[�j���O
    /// <br>Update Note: 2011/07/29 30517 �Ė� �x��</br>
    /// <br>            �C�X�R�Ή��EREADUNCOMMITTED�Ή�
    /// </remarks>
    [Serializable]
    public class SalesRsltListResultDB : RemoteDB, ISalesRsltListResultDB
    {
        /// <summary>
        /// �������DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        public SalesRsltListResultDB()
            :
            base("DCTOK02126D", "Broadleaf.Application.Remoting.ParamData.SalesRsltListResultWork", "SALESRSLTLISTRESULTRF")
        {
        }

        IMTtlSaSlip mTtlSaSlip;

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̔�����уf�[�^��߂��܂�
        /// </summary>
        /// <param name="salesRsltListResultWorkk">��������</param>
        /// <param name="CndtnWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔�����уf�[�^��߂��܂�</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.26</br>
        public int Search(out object salesRsltListResultWork, object salesRsltListCndtnWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            salesRsltListResultWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchsalesDayMonthReportData(out salesRsltListResultWork, salesRsltListCndtnWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesRsltListResultDB.Search");
                salesRsltListResultWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// �w�肳�ꂽ�����̔�����уf�[�^��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objSalesAnnualDataSelectResultWork">��������</param>
        /// <param name="objSalesAnnualDataSelectParamWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔�����уf�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br></br>
        /// <br>Update Note: PM.NS�Ή�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.09.02</br>
        private int SearchsalesDayMonthReportData(out object objSalesRsltListResultWork, object objSalesRsltListCndtnWork, ref SqlConnection sqlConnection)
        {
            SalesRsltListCndtnWork CndtnWork = null;

            ArrayList CndtnWorkList = objSalesRsltListCndtnWork as ArrayList;

            if (CndtnWorkList == null)
            {
                CndtnWork = objSalesRsltListCndtnWork as SalesRsltListCndtnWork;
            }
            else
            {
                if (CndtnWorkList.Count > 0)
                    CndtnWork = CndtnWorkList[0] as SalesRsltListCndtnWork;
            }

            ArrayList salesReportWorkList = null;

            switch (CndtnWork.TotalType)
            {
                case (int)TotalType.Goods:     //���i��
                    mTtlSaSlip = new MTtlSaSlipGoods();
                    break;
                case (int)TotalType.Customer:  //���Ӑ��
                    mTtlSaSlip = new MTtlSaSlipCust();
                    break;
                case (int)TotalType.Agent:     //�S���ҕ�
                    mTtlSaSlip = new MTtlSaSlipEmp();
                    break;
                case (int)TotalType.Whouse:    //�q�ɕ�
                    mTtlSaSlip = new MTtlSaSlipWhouse();
                    break;
                case (int)TotalType.Supplier:   //�d�����   // ADD 2009/04/11
                    mTtlSaSlip = new MTtlSaSlipSupp();
                    break;
                default:
                    break;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            // ������уf�[�^���捞��
            status = SearchSalesHistoryDataProc(out salesReportWorkList, CndtnWork, ref sqlConnection);

            objSalesRsltListResultWork = salesReportWorkList;
            return status;

        }
        #endregion  //Search

        #region [SearchSalesHistoryDataProc]
        /// <summary>
        /// �w�肳�ꂽ�����̔�����уf�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="salesAnnualDataSelectResultWorkList">��������</param>
        /// <param name="salesAnnualDataSelectParamWork">�����p�����[�^</param>
        /// <param name="termDiv">�W�v���ԋ敪  0:�w�茎�͈�  1:�����͈�</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔�����уf�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br></br>
        /// <br>Update Note: PM.NS�Ή�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.09.02</br>
        private int SearchSalesHistoryDataProc(out ArrayList salesHistoryWorkList, SalesRsltListCndtnWork CndtnWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                sqlCommand.CommandText = mTtlSaSlip.MakeSelectString(ref sqlCommand, CndtnWork);

                //�^�C���A�E�g���Ԃ̐ݒ�i�b�j
                sqlCommand.CommandTimeout = 3600;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(mTtlSaSlip.CopyToSalesRsltListResultWorkFromReader(ref myReader, CndtnWork));

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
                base.WriteErrorLog(ex, "SalesRsltListResultDB.SearchSalesHistoryDataProc");
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }

            salesHistoryWorkList = al;

            return status;
        }
        #endregion  //SearchSalesHistoryDataProc

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion  //�R�l�N�V������������
    }

}

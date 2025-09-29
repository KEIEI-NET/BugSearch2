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
    /// �d���挳���x���`�[���oDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d���挳���x���`�[���o�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 22035 �O�� �O��</br>
    /// <br>Date       : 2007.05.08</br>
    /// <br></br>
    /// <br>Update Note: 980081  �R�c ���F</br>
    /// <br>           : 2007.12.04 ���ʊ�Ή�</br>
    /// <br>Update Note: FSI�֓� �a�G</br>
    /// <br>           : 2012/11/01 �x���f�[�^�ɒl���z�E�萔���z�����f����Ă��Ȃ����Ή�</br>
    /// </remarks>
    [Serializable]
    public class LedgerPaymentSlpWorkDB : RemoteDB
    {
        /// <summary>
        /// �d���挳���x���`�[���oDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.05.08</br>
        /// </remarks>
        public LedgerPaymentSlpWorkDB()
            :
        base("MAKON02413D", "Broadleaf.Application.Remoting.ParamData.LedgerPaymentSlpWork", "PAYMENTSLPRF") //���N���X�̃R���X�g���N�^
        {
        }

        #region �x���擾����
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̎d���挳���x���`�[���oLIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="ledgerPaymentSlpWork">�������ʁi�x���j</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="addUpSecCodeList">���_�R�[�h���X�g</param>
        /// <param name="startSupplierCd">�d����R�[�h(�J�n)</param>
        /// <param name="endSupplierCd">�d����R�[�h(�I��)</param>
        /// <param name="startAddUpDate">�v����t(�J�n)</param>
        /// <param name="endAddUpDate">�v����t(�I��)</param>
        /// <param name="sqlConnection">SQLConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎d���挳���x���`�[���oLIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.05.08</br>
        public int Search(out object ledgerPaymentSlpWork, string enterpriseCode, ArrayList addUpSecCodeList,
            int startSupplierCd, int endSupplierCd, int startAddUpDate, int endAddUpDate, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            ledgerPaymentSlpWork = null;

            try
            {
                status = SearchProc(out ledgerPaymentSlpWork, enterpriseCode, addUpSecCodeList, startSupplierCd, endSupplierCd, startAddUpDate, endAddUpDate, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "LedgerPaymentSlpWorkDB.Search Exception=" + ex.Message);
                ledgerPaymentSlpWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̎d���挳���x���`�[���oLIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="ledgerPaymentSlpWork">�������ʁi�x���j</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="addUpSecCodeList">���_�R�[�h���X�g</param>
        /// <param name="startSupplierCd">�d����R�[�h(�J�n)</param>
        /// <param name="endSupplierCd">�d����R�[�h(�I��)</param>
        /// <param name="startAddUpDate">�v����t(�J�n)</param>
        /// <param name="endAddUpDate">�v����t(�I��)</param>
        /// <param name="sqlConnection">SQLConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎d���挳���x���`�[���oLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.05.08</br>
        /// <br></br>
        /// <br>Update Note: �x���f�[�^�ɒl���z�E�萔���z�����f����Ă��Ȃ����Ή�</br>
        /// <br>             ����Ŋz�\���s���Ή�</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/11/01 </br>
        private int SearchProc(out object ledgerPaymentSlpWork, string enterpriseCode, ArrayList addUpSecCodeList,
            int startSupplierCd, int endSupplierCd, int startAddUpDate, int endAddUpDate, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            ledgerPaymentSlpWork = null;
            ArrayList al = new ArrayList();   //���o����

            string sqlText = string.Empty;

            try
            {
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   MAIN.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,MAIN.DEBITNOTEDIVRF" + Environment.NewLine;
                sqlText += "  ,MAIN.PAYMENTSLIPNORF" + Environment.NewLine;
                sqlText += "  ,MAIN.SUPPLIERFORMALRF" + Environment.NewLine;
                sqlText += "  ,MAIN.SUPPLIERSLIPNORF" + Environment.NewLine;
                sqlText += "  ,MAIN.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += "  ,MAIN.SUPPLIERNM1RF" + Environment.NewLine;
                sqlText += "  ,MAIN.SUPPLIERNM2RF" + Environment.NewLine;
                sqlText += "  ,MAIN.SUPPLIERSNMRF" + Environment.NewLine;
                sqlText += "  ,MAIN.PAYEECODERF" + Environment.NewLine;
                sqlText += "  ,MAIN.PAYEENAMERF" + Environment.NewLine;
                sqlText += "  ,MAIN.PAYEENAME2RF" + Environment.NewLine;
                sqlText += "  ,MAIN.PAYEESNMRF" + Environment.NewLine;
                sqlText += "  ,MAIN.PAYMENTINPSECTIONCDRF" + Environment.NewLine;
                sqlText += "  ,MAIN.ADDUPSECCODERF" + Environment.NewLine;
                sqlText += "  ,MAIN.UPDATESECCDRF" + Environment.NewLine;
                sqlText += "  ,MAIN.PAYMENTDATERF" + Environment.NewLine;
                sqlText += "  ,MAIN.ADDUPADATERF" + Environment.NewLine;
                sqlText += "  ,MAIN.PAYMENTAGENTCODERF" + Environment.NewLine;
                sqlText += "  ,MAIN.PAYMENTAGENTNAMERF" + Environment.NewLine;
                sqlText += "  ,MAIN.PAYMENTINPUTAGENTCDRF" + Environment.NewLine;
                sqlText += "  ,MAIN.PAYMENTINPUTAGENTNMRF" + Environment.NewLine;
                sqlText += "  ,MAIN.OUTLINERF" + Environment.NewLine;
                // --- ADD 2012/11/01 ---------->>>>>
                // �萔���ƒl���z���擾
                sqlText += "  ,MAIN.FEEPAYMENTRF" + Environment.NewLine;
                sqlText += "  ,MAIN.DISCOUNTPAYMENTRF" + Environment.NewLine;
                // --- ADD 2012/11/01 ----------<<<<<
                sqlText += "  ,DTL.PAYMENTROWNORF" + Environment.NewLine;
                sqlText += "  ,DTL.MONEYKINDCODERF" + Environment.NewLine;
                sqlText += "  ,DTL.MONEYKINDNAMERF" + Environment.NewLine;
                sqlText += "  ,DTL.MONEYKINDDIVRF" + Environment.NewLine;
                sqlText += "  ,DTL.PAYMENTRF" + Environment.NewLine;
                sqlText += "  ,DTL.VALIDITYTERMRF" + Environment.NewLine;
                sqlText += "FROM PAYMENTSLPRF AS MAIN" + Environment.NewLine;
                sqlText += "LEFT JOIN PAYMENTDTLRF AS DTL ON (MAIN.ENTERPRISECODERF=DTL.ENTERPRISECODERF AND MAIN.SUPPLIERFORMALRF=DTL.SUPPLIERFORMALRF AND MAIN.PAYMENTSLIPNORF=DTL.PAYMENTSLIPNORF ) " + Environment.NewLine;

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))
                {
                    // Where���̍쐬
                    bool result = this.MakeWhereString(sqlCommand, enterpriseCode, addUpSecCodeList, startSupplierCd, endSupplierCd, startAddUpDate, endAddUpDate);
                    if (!result) return status;

                    using (SqlDataReader myReader = sqlCommand.ExecuteReader())
                    {
                        try
                        {
                            this.SetListFromSQLReader(ref status, ref al, myReader);
                        }
                        finally
                        {
                            if (myReader != null) myReader.Close();
                        }
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
                base.WriteErrorLog(ex, "LedgerPaymentSlpWorkDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            ledgerPaymentSlpWork = al;

            return status;
        }
        #endregion

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SQLConnection</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="addUpSecCodeList">���_�R�[�h���X�g</param>
        /// <param name="startSupplierCd">�d����R�[�h(�J�n)</param>
        /// <param name="endSupplierCd">�d����R�[�h(�I��)</param>
        /// <param name="startAddUpDate">�v����t(�J�n)</param>
        /// <param name="endAddUpDate">�v����t(�I��)</param>
        /// <returns>Where����������</returns>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.05.08</br>		
        /// <br></br>
        /// <br>Update Note: 980081  �R�c ���F</br>
        /// <br>           : 2007.12.04 ���ʊ�Ή�</br>
        private bool MakeWhereString(SqlCommand sqlCommand, string enterpriseCode, ArrayList addUpSecCodeList, int startSupplierCd, int endSupplierCd, 
            int startAddUpDate, int endAddUpDate)
        {
            #region WHERE���쐬
            sqlCommand.CommandText += " WHERE";

            // ��ƃR�[�h
            sqlCommand.CommandText += " MAIN.ENTERPRISECODERF=@FINDENTERPRISECODE";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

            // �_���폜�敪
            sqlCommand.CommandText += " AND MAIN.LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            //�x����R�[�h
            if (startSupplierCd != 0)
            {
                sqlCommand.CommandText += " AND MAIN.PAYEECODERF>=@STPAYEECODE";
                SqlParameter paraStSupplierCode = sqlCommand.Parameters.Add("@STPAYEECODE", SqlDbType.Int);
                paraStSupplierCode.Value = SqlDataMediator.SqlSetInt32(startSupplierCd);
            }
            if (endSupplierCd != 0)
            {
                sqlCommand.CommandText += " AND MAIN.PAYEECODERF<=@EDPAYEECODE";
                SqlParameter paraEdSupplierCode = sqlCommand.Parameters.Add("@EDPAYEECODE", SqlDbType.Int);
                paraEdSupplierCode.Value = SqlDataMediator.SqlSetInt32(endSupplierCd);
            }

            // �v����t
            if (startAddUpDate <= endAddUpDate)
            {
                if (startAddUpDate == endAddUpDate)
                {
                    sqlCommand.CommandText += " AND MAIN.ADDUPADATERF=@FINDADDUPADATE";
                    SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPADATE", SqlDbType.Int);
                    paraAddUpDate.Value = SqlDataMediator.SqlSetInt32(startAddUpDate);
                }
                else
                {
                    sqlCommand.CommandText += " AND MAIN.ADDUPADATERF>=@FINDSTARTADDUPADATE AND MAIN.ADDUPADATERF<=@FINDENDADDUPADATE";
                    SqlParameter paraStartAddUpDate = sqlCommand.Parameters.Add("@FINDSTARTADDUPADATE", SqlDbType.Int);
                    paraStartAddUpDate.Value = SqlDataMediator.SqlSetInt32(startAddUpDate);
                    SqlParameter paraEndAddUpDate = sqlCommand.Parameters.Add("@FINDENDADDUPADATE", SqlDbType.Int);
                    paraEndAddUpDate.Value = SqlDataMediator.SqlSetInt32(endAddUpDate);
                }
            }
            else
            {
                return false;
            }

            // �v�㋒�_
            StringBuilder whereSectionCode = new StringBuilder();
            if (addUpSecCodeList.Count > 0)
            {
                if (addUpSecCodeList.Count == 1)
                {
                    sqlCommand.CommandText += " AND MAIN.ADDUPSECCODERF='" + addUpSecCodeList[0] + "'";
                }
                else
                {
                    sqlCommand.CommandText += " AND MAIN.ADDUPSECCODERF IN (";
                    string str = "";
                    for (int ix = 0; ix < addUpSecCodeList.Count; ix++)
                    {
                        if (ix != 0)
                        {
                            str += ",";
                        }
                        str += "'" + addUpSecCodeList[ix] + "'";
                    }
                    sqlCommand.CommandText += str + ")";
                }
            }

            #endregion
            return true;
        }

        /// <summary>
        /// �d���挳���x���`�[���X�g�i�[����
        /// </summary>
        /// <param name="status">�X�e�[�^�X</param>
        /// <param name="al">�d���挳���x���`�[���X�g</param>
        /// <param name="myReader">SQLDataReader</param>
        /// <br>Note       : SQLDataReader�̏����d���挳���x���`�[���X�g�ɃZ�b�g���܂��B</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.05.08</br>		
        private void SetListFromSQLReader(ref int status, ref ArrayList al, SqlDataReader myReader)
        {
            if (al == null)
            {
                al = new ArrayList();
            }

            LedgerPaymentSlpWork _ledgerPaymentSlpWork;

            while (myReader.Read())
            {
                _ledgerPaymentSlpWork = new LedgerPaymentSlpWork();
                this.CopyToDataClassFromSelectData(ref _ledgerPaymentSlpWork, myReader);
                al.Add(_ledgerPaymentSlpWork);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
        }

        /// <summary>
        /// SQL�f�[�^���[�_�[���d���挳���x���`�[���[�N
        /// </summary>
        /// <param name="_ledgerPaymentSlpWork">�d���挳���x���`�[���[�N</param>
        /// <param name="myReader">SQL�f�[�^���[�_�[</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SQL�f�[�^���[�_�[�ɕێ����Ă�����e���d���挳���x���`�[���[�N�ɃR�s�[���܂��B</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.05.08</br>		
        /// <br></br>
        /// <br>Update Note: 980081  �R�c ���F</br>
        /// <br>           : 2007.12.04 ���ʊ�Ή�</br>
        /// <br></br>
        /// <br>Update Note: FSI�֓� �a�G</br>
        /// <br>Date       : 2012/11/01 �x���f�[�^�ɒl���z�E�萔���z�����f����Ă��Ȃ����Ή�
        /// <br>             </br>
        private void CopyToDataClassFromSelectData(ref LedgerPaymentSlpWork _ledgerPaymentSlpWork, SqlDataReader myReader)
        {
            #region �d���挳���x���`�[���[�N�֊i�[
            _ledgerPaymentSlpWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            _ledgerPaymentSlpWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
            _ledgerPaymentSlpWork.PaymentSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTSLIPNORF"));
            _ledgerPaymentSlpWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
            _ledgerPaymentSlpWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
            _ledgerPaymentSlpWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            _ledgerPaymentSlpWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
            _ledgerPaymentSlpWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
            _ledgerPaymentSlpWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            _ledgerPaymentSlpWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            _ledgerPaymentSlpWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAMERF"));
            _ledgerPaymentSlpWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAME2RF"));
            _ledgerPaymentSlpWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
            _ledgerPaymentSlpWork.PaymentInpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPSECTIONCDRF"));
            _ledgerPaymentSlpWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            _ledgerPaymentSlpWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
            _ledgerPaymentSlpWork.PaymentDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PAYMENTDATERF"));
            _ledgerPaymentSlpWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
            _ledgerPaymentSlpWork.PaymentAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTCODERF"));
            _ledgerPaymentSlpWork.PaymentAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTNAMERF"));
            _ledgerPaymentSlpWork.PaymentInputAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTCDRF"));
            _ledgerPaymentSlpWork.PaymentInputAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTNMRF"));
            _ledgerPaymentSlpWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
            _ledgerPaymentSlpWork.PaymentRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTROWNORF"));
            _ledgerPaymentSlpWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDCODERF"));
            _ledgerPaymentSlpWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));
            _ledgerPaymentSlpWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDDIVRF"));
            _ledgerPaymentSlpWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTRF"));
            // --- ADD 2012/11/01 ---------->>>>>
            // �l���z�Ǝ萔���z
            _ledgerPaymentSlpWork.FeePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEPAYMENTRF"));
            _ledgerPaymentSlpWork.DiscountPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPAYMENTRF"));
            // --- ADD 2012/11/01 ----------<<<<<

            _ledgerPaymentSlpWork.ValidityTerm = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("VALIDITYTERMRF"));

            #endregion
        }
    }
}

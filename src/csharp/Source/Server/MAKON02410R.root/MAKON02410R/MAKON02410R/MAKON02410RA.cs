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
    /// �d���挳���d���f�[�^���oDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d���挳���d���f�[�^���o�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 22035 �O�� �O��</br>
    /// <br>Date       : 2007.05.08</br>
    /// <br></br>
    /// <br>Update Note: 980081  �R�c ���F</br>
    /// <br>           : 2007.12.04 ���ʊ�Ή�</br>
    /// <br></br>
    /// <br>Update Note: 980081  �R�c ���F</br>
    /// <br>           : 2008.03.13 ���|���[�h�̍ۂɏ���Œ����E�c���������߂��悤�C��</br>
    /// <br>Update Note: 30290</br>
    /// <br>           : 2008.04.24 ���Ӑ�E�d����؂蕪��</br>
    /// <br>Update Note: 22008 ���� ���n</br>
    /// <br>           : 2008.10.07 PM.NS�p�ɏC��</br>
    /// <br>Update Note: FSI�֓� �a�G</br>
    /// <br>           : 2012/10/02 �d���摍���Ή�</br>
    /// <br>UpdateNote : 2015/10/21 �c�v�t</br>
    /// <br>�Ǘ��ԍ�   : 11170187-00</br>
    /// <br>           : Redmine#47545 �d���挳���̖��ו��Ɏd����q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή�</br>
    /// <br>UpdateNote : 2015/12/10 �c�v�t</br>
    /// <br>�Ǘ��ԍ�   : 11170204-00</br>
    /// <br>           : Redmine#47545 ��Q�P �d�������I�v�V�����L�����A�d���挳���̖��ו�(�d����e)�ɐe�q�����̖��ׂ��󎚂����̏�Q�Ή�</br>
    /// <br>UpdateNote : 2015/12/17 �c�v�t</br>
    /// <br>�Ǘ��ԍ�   : 11170204-00</br>
    /// <br>           : Redmine#47545 �V�X�e���e�X�g��Q�ꗗ_#47545�̎w�ENO.2 ���o�������x���悩��d����ɕύX������A�����̕ϐ������ύX���Ȃ��Ή�</br>
    /// </remarks>
    [Serializable]
    public class LedgerStockSlipWorkDB : RemoteDB
    {
        /// <summary>
        /// �d���挳���d���f�[�^���oDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.05.08</br>
        /// </remarks>
        public LedgerStockSlipWorkDB()
            :
        base("MAKON02411D", "Broadleaf.Application.Remoting.ParamData.LedgerStockSlipWork", "STOCKSLIPHISTRF") //���N���X�̃R���X�g���N�^
        {
        }

        private enum PrintMode
        {
            Slip = 0,
            Dtl = 1
        }

        #region �d���擾����

        #region ���C��

        // --- ADD 2012/10/02 ---------->>>>>
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̎d���挳���d���f�[�^���oLIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="ledgerStockSlipWork">�������ʁi����j</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="addUpSecCodeList">���_�R�[�h���X�g</param>
        /// <param name="startSupplierCd">�d����R�[�h(�J�n)</param>
        /// <param name="endSupplierCd">�d����R�[�h(�I��)</param>
        /// <param name="startAddUpDate">�v����t(�J�n)</param>
        /// <param name="endAddUpDate">�v����t(�I��)</param>
        /// <param name="goodsCdMode">���i�敪 1:�x��</param>
        /// <param name="sqlConnection">SQLConnection</param>
        /// <param name="sumSuppEnable">�d���摍�����p�� 0:���p�s�� 1:���p��</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎d���挳���d���f�[�^���oLIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.05.08</br>
        /// <br>UpdateNote : �d���摍���Ή�</br>
        /// <br>Programer  : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/10/02</br>
        public int SearchSlip(out object ledgerStockSlipWork, string enterpriseCode, ArrayList addUpSecCodeList,
            int startSupplierCd, int endSupplierCd, int startAddUpDate, int endAddUpDate, int goodsCdMode ,ref SqlConnection sqlConnection, int sumSuppEnable)
        {
            return Search(out ledgerStockSlipWork, enterpriseCode, addUpSecCodeList, startSupplierCd, endSupplierCd, startAddUpDate, endAddUpDate, goodsCdMode, ref sqlConnection, (int)PrintMode.Slip, sumSuppEnable);
        }
        // --- ADD 2012/10/02 ----------<<<<<

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̎d���挳���d���f�[�^���oLIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="ledgerStockSlipWork">�������ʁi����j</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="addUpSecCodeList">���_�R�[�h���X�g</param>
        /// <param name="startSupplierCd">�d����R�[�h(�J�n)</param>
        /// <param name="endSupplierCd">�d����R�[�h(�I��)</param>
        /// <param name="startAddUpDate">�v����t(�J�n)</param>
        /// <param name="endAddUpDate">�v����t(�I��)</param>
        /// <param name="goodsCdMode">���i�敪 1:�x��</param>
        /// <param name="sqlConnection">SQLConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎d���挳���d���f�[�^���oLIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.05.08</br>
        public int SearchSlip(out object ledgerStockSlipWork, string enterpriseCode, ArrayList addUpSecCodeList,
            int startSupplierCd, int endSupplierCd, int startAddUpDate, int endAddUpDate, int goodsCdMode ,ref SqlConnection sqlConnection)
        {
            // --- ADD 2012/10/02 ---------->>>>>
            //return Search(out ledgerStockSlipWork, enterpriseCode, addUpSecCodeList, startSupplierCd, endSupplierCd, startAddUpDate, endAddUpDate, goodsCdMode, ref sqlConnection, (int)PrintMode.Slip);
            return Search(out ledgerStockSlipWork, enterpriseCode, addUpSecCodeList, startSupplierCd, endSupplierCd, startAddUpDate, endAddUpDate, goodsCdMode, ref sqlConnection, (int)PrintMode.Slip, 0);
            // --- ADD 2012/10/02 ----------<<<<<
        }

        // --- ADD 2012/10/02 ---------->>>>>
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̎d���挳���d���f�[�^���oLIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="ledgerStockSlipWork">�������ʁi����j</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="addUpSecCodeList">���_�R�[�h���X�g</param>
        /// <param name="startSupplierCd">�d����R�[�h(�J�n)</param>
        /// <param name="endSupplierCd">�d����R�[�h(�I��)</param>
        /// <param name="startAddUpDate">�v����t(�J�n)</param>
        /// <param name="endAddUpDate">�v����t(�I��)</param>
        /// <param name="goodsCdMode">���i�敪 1:�x��</param>
        /// <param name="sqlConnection">SQLConnection</param>
        /// <param name="sumSuppEnable">�d���摍�����p�� 0:���p�s�� 1:���p��</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎d���挳���̎d���f�[�^���oLIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.05.08</br>
        /// <br>UpdateNote : �d���摍���Ή�</br>
        /// <br>Programer  : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/10/02</br>
        public int SearchDtl(out object ledgerStockSlipWork, string enterpriseCode, ArrayList addUpSecCodeList,
            int startSupplierCd, int endSupplierCd, int startAddUpDate, int endAddUpDate, int goodsCdMode ,ref SqlConnection sqlConnection, int sumSuppEnable)
        {
            return Search(out ledgerStockSlipWork, enterpriseCode, addUpSecCodeList, startSupplierCd, endSupplierCd, startAddUpDate, endAddUpDate, goodsCdMode, ref sqlConnection, (int)PrintMode.Dtl, sumSuppEnable);
        }
        // --- ADD 2012/10/02 ----------<<<<<

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̎d���挳���d���f�[�^���oLIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="ledgerStockSlipWork">�������ʁi����j</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="addUpSecCodeList">���_�R�[�h���X�g</param>
        /// <param name="startSupplierCd">�d����R�[�h(�J�n)</param>
        /// <param name="endSupplierCd">�d����R�[�h(�I��)</param>
        /// <param name="startAddUpDate">�v����t(�J�n)</param>
        /// <param name="endAddUpDate">�v����t(�I��)</param>
        /// <param name="goodsCdMode">���i�敪 1:�x��</param>
        /// <param name="sqlConnection">SQLConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎d���挳���̎d���f�[�^���oLIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.05.08</br>
        public int SearchDtl(out object ledgerStockSlipWork, string enterpriseCode, ArrayList addUpSecCodeList,
            int startSupplierCd, int endSupplierCd, int startAddUpDate, int endAddUpDate, int goodsCdMode ,ref SqlConnection sqlConnection)
        {
            // --- ADD 2012/10/02 ----------<<<<<
            //return Search(out ledgerStockSlipWork, enterpriseCode, addUpSecCodeList, startSupplierCd, endSupplierCd, startAddUpDate, endAddUpDate, goodsCdMode, ref sqlConnection, (int)PrintMode.Dtl;
            return Search(out ledgerStockSlipWork, enterpriseCode, addUpSecCodeList, startSupplierCd, endSupplierCd, startAddUpDate, endAddUpDate, goodsCdMode, ref sqlConnection, (int)PrintMode.Dtl, 0);
            // --- ADD 2012/10/02 ----------<<<<<
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̎d���挳���d���f�[�^���oLIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="ledgerStockSlipWork">�������ʁi����j</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="addUpSecCodeList">���_�R�[�h���X�g</param>
        /// <param name="startSupplierCd">�d����R�[�h(�J�n)</param>
        /// <param name="endSupplierCd">�d����R�[�h(�I��)</param>
        /// <param name="startAddUpDate">�v����t(�J�n)</param>
        /// <param name="endAddUpDate">�v����t(�I��)</param>
        /// <param name="goodsCdMode">���i�敪 1:�x��</param>
        /// <param name="sqlConnection">SQLConnection</param>
        /// <param name="printMode">����^�C�v</param>
        /// <param name="sumSuppEnable">�d���摍�����p�� 0:���p�s�� 1:���p��</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎d���挳���d���f�[�^���oLIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.05.08</br>
        private int Search(out object ledgerStockSlipWork, string enterpriseCode, ArrayList addUpSecCodeList,
            int startSupplierCd, int endSupplierCd, int startAddUpDate, int endAddUpDate, int goodsCdMode, ref SqlConnection sqlConnection, int printMode, int sumSuppEnable)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            ledgerStockSlipWork = null;

            try
            {
                if (printMode == (int)PrintMode.Slip)
                {
                    status = SearchSlipProc(out ledgerStockSlipWork, enterpriseCode, addUpSecCodeList, startSupplierCd, endSupplierCd, startAddUpDate, endAddUpDate, goodsCdMode, ref sqlConnection, printMode, sumSuppEnable);
                }
                else
                {
                    status = SearchDtlProc(out ledgerStockSlipWork, enterpriseCode, addUpSecCodeList, startSupplierCd, endSupplierCd, startAddUpDate, endAddUpDate, goodsCdMode, ref sqlConnection, printMode, sumSuppEnable);
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "LedgerStockSlipWorkDB.Search Exception=" + ex.Message);
                ledgerStockSlipWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }
        #endregion

        #region �`�[�^�C�v
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̎d���挳���d���f�[�^���oLIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="ledgerStockSlipWork">�������ʁi����j</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="addUpSecCodeList">���_�R�[�h���X�g</param>
        /// <param name="startSupplierCd">�d����R�[�h(�J�n)</param>
        /// <param name="endSupplierCd">�d����R�[�h(�I��)</param>
        /// <param name="startAddUpDate">�v����t(�J�n)</param>
        /// <param name="endAddUpDate">�v����t(�I��)</param>
        /// <param name="goodsCdMode">���i�敪���[�h 0:�ʏ� 1:�x��(4,5,10�����O) 2:���|</param>
        /// <param name="sqlConnection">SQLConnection</param>
        /// <param name="printMode">����^�C�v</param>
        /// <param name="sumSuppEnable">�d���摍�����p�� 0:���p�s�� 1:���p��</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎d���挳���d���f�[�^���oLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.05.08</br>
        /// <br></br>
        /// <br>Update Note: ����œ]�ŕ��������f���ꂸ�ɕ\���������Ή�</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/11/01 </br>
        private int SearchSlipProc(out object ledgerStockSlipWork, string enterpriseCode, ArrayList addUpSecCodeList,
            int startSupplierCd, int endSupplierCd, int startAddUpDate, int endAddUpDate, int goodsCdMode, ref SqlConnection sqlConnection, int printMode, int sumSuppEnable)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            ledgerStockSlipWork = null;
            ArrayList al = new ArrayList();   //���o����

            string sqlText = string.Empty;

            try
            {
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   SLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,SLIP.SUPPLIERFORMALRF" + Environment.NewLine;
                sqlText += "  ,SLIP.SUPPLIERSLIPNORF" + Environment.NewLine;
                sqlText += "  ,SLIP.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  ,SLIP.DEBITNOTEDIVRF" + Environment.NewLine;
                sqlText += "  ,SLIP.DEBITNLNKSUPPSLIPNORF" + Environment.NewLine;
                sqlText += "  ,SLIP.SUPPLIERSLIPCDRF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKGOODSCDRF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKSECTIONCDRF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKADDUPSECTIONCDRF" + Environment.NewLine;
                sqlText += "  ,SLIP.INPUTDAYRF" + Environment.NewLine;
                sqlText += "  ,SLIP.ARRIVALGOODSDAYRF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKDATERF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKADDUPADATERF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKINPUTCODERF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKINPUTNAMERF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKAGENTCODERF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKAGENTNAMERF" + Environment.NewLine;
                sqlText += "  ,SLIP.PAYEECODERF" + Environment.NewLine;
                sqlText += "  ,SLIP.PAYEESNMRF" + Environment.NewLine;
                sqlText += "  ,SLIP.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += "  ,SLIP.SUPPLIERNM1RF" + Environment.NewLine;
                sqlText += "  ,SLIP.SUPPLIERNM2RF" + Environment.NewLine;
                sqlText += "  ,SLIP.SUPPLIERSNMRF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKTOTALPRICERF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKSUBTTLPRICERF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKPRICECONSTAXRF" + Environment.NewLine;
                sqlText += "  ,SLIP.PARTYSALESLIPNUMRF" + Environment.NewLine;
                sqlText += "  ,SLIP.SUPPLIERSLIPNOTE1RF" + Environment.NewLine;
                sqlText += "  ,SLIP.SUPPLIERSLIPNOTE2RF" + Environment.NewLine;
                sqlText += "  ,SLIP.UOEREMARK1RF" + Environment.NewLine;
                sqlText += "  ,SLIP.UOEREMARK2RF" + Environment.NewLine;
                sqlText += "FROM STOCKSLIPHISTRF AS SLIP" + Environment.NewLine;

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))
                {
                    // --- ADD 2012/10/02 ---------->>>>>
                    if (sumSuppEnable == 1)
                    {
                        // Where���̍쐬
                        bool result = this.MakeWhereStringSumSupp(sqlCommand, enterpriseCode, addUpSecCodeList, startSupplierCd, endSupplierCd, startAddUpDate, endAddUpDate, goodsCdMode);
                        if (!result) return status;
                    }
                    else
                    {
                        // Where���̍쐬
                        bool result = this.MakeWhereString(sqlCommand, enterpriseCode, addUpSecCodeList, startSupplierCd, endSupplierCd, startAddUpDate, endAddUpDate, goodsCdMode);
                        if (!result) return status;
                    }
                    // --- ADD 2012/10/02 ----------<<<<<

                    using (SqlDataReader myReader = sqlCommand.ExecuteReader())
                    {
                        try
                        {
                            this.SetListFromSQLReader(ref status, ref al, myReader, printMode, sumSuppEnable);
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
                base.WriteErrorLog(ex, "LedgerStockSlipWorkDB.SearchSlipProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            ledgerStockSlipWork = al;

            return status;
        }

        /// <summary>
        /// SQL�f�[�^���[�_�[���d���挳���d���f�[�^���[�N
        /// </summary>
        /// <param name="_ledgerStockSlipWork">�d���挳���d���f�[�^���[�N</param>
        /// <param name="myReader">SQL�f�[�^���[�_�[</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SQL�f�[�^���[�_�[�ɕێ����Ă�����e���d���挳���d���f�[�^���[�N�ɃR�s�[���܂��B</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.05.08</br>		
        /// <br></br>
        /// <br>Update Note: ����œ]�ŕ��������f���ꂸ�ɕ\���������Ή�</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/11/01 </br>
        private void CopyToDataClassFromSelectData(ref LedgerStockSlipWork _ledgerStockSlipWork, SqlDataReader myReader)
        {
            #region �d���挳���d���f�[�^���[�N�֊i�[
            _ledgerStockSlipWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            _ledgerStockSlipWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
            _ledgerStockSlipWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
            _ledgerStockSlipWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            _ledgerStockSlipWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
            _ledgerStockSlipWork.DebitNLnkSuppSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNLNKSUPPSLIPNORF"));
            _ledgerStockSlipWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));
            _ledgerStockSlipWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
            _ledgerStockSlipWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));          
            _ledgerStockSlipWork.StockAddUpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKADDUPSECTIONCDRF"));
            _ledgerStockSlipWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
            _ledgerStockSlipWork.ArrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
            _ledgerStockSlipWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
            _ledgerStockSlipWork.StockAddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKADDUPADATERF"));
            _ledgerStockSlipWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
            _ledgerStockSlipWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));
            _ledgerStockSlipWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
            _ledgerStockSlipWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
            _ledgerStockSlipWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            _ledgerStockSlipWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
            _ledgerStockSlipWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            _ledgerStockSlipWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
            _ledgerStockSlipWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
            _ledgerStockSlipWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            _ledgerStockSlipWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
            _ledgerStockSlipWork.StockSubttlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSUBTTLPRICERF"));
            _ledgerStockSlipWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
            _ledgerStockSlipWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
            _ledgerStockSlipWork.SupplierSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE1RF"));
            _ledgerStockSlipWork.SupplierSlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE2RF"));
            _ledgerStockSlipWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
            _ledgerStockSlipWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
            #endregion

        }
        #endregion

        #region ���׃^�C�v

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̎d���挳���d���f�[�^���oLIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="ledgerStockDetailWork">�������ʁi�d�����ׁj</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="addUpSecCodeList">���_�R�[�h���X�g</param>
        /// <param name="startSupplierCd">�d����R�[�h(�J�n)</param>
        /// <param name="endSupplierCd">�d����R�[�h(�I��)</param>
        /// <param name="startAddUpDate">�v����t(�J�n)</param>
        /// <param name="endAddUpDate">�v����t(�I��)</param>
        /// <param name="goodsCdMode">���i�敪���[�h 0:�ʏ� 1:�x��(4,5,10�����O) 2:���|</param>
        /// <param name="sqlConnection">SQLConnection</param>
        /// <param name="printMode">����^�C�v</param>
        /// <param name="sumSuppEnable">�d���摍�����p�� 0:���p�s�� 1:���p��</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎d���挳���d���f�[�^���oLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.12.04</br>
        /// <br></br>
        /// <br>Update Note: ����œ]�ŕ��������f���ꂸ�ɕ\���������Ή�</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/11/01 </br>
        private int SearchDtlProc(out object ledgerStockDetailWork, string enterpriseCode, ArrayList addUpSecCodeList,
            int startSupplierCd, int endSupplierCd, int startAddUpDate, int endAddUpDate, int goodsCdMode, ref SqlConnection sqlConnection, int printMode, int sumSuppEnable)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            ledgerStockDetailWork = null;
            ArrayList al = new ArrayList();     //���o����

            string sqlText = string.Empty;

            try
            {

                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   SLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,SLIP.SUPPLIERFORMALRF" + Environment.NewLine;
                sqlText += "  ,SLIP.SUPPLIERSLIPNORF" + Environment.NewLine;
                sqlText += "  ,SLIP.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  ,SLIP.DEBITNOTEDIVRF" + Environment.NewLine;
                sqlText += "  ,SLIP.DEBITNLNKSUPPSLIPNORF" + Environment.NewLine;
                sqlText += "  ,SLIP.SUPPLIERSLIPCDRF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKGOODSCDRF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKSECTIONCDRF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKADDUPSECTIONCDRF" + Environment.NewLine;
                sqlText += "  ,SLIP.INPUTDAYRF" + Environment.NewLine;
                sqlText += "  ,SLIP.ARRIVALGOODSDAYRF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKDATERF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKADDUPADATERF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKINPUTCODERF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKINPUTNAMERF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKAGENTCODERF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKAGENTNAMERF" + Environment.NewLine;
                sqlText += "  ,SLIP.PAYEECODERF" + Environment.NewLine;
                sqlText += "  ,SLIP.PAYEESNMRF" + Environment.NewLine;
                sqlText += "  ,SLIP.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += "  ,SLIP.SUPPLIERNM1RF" + Environment.NewLine;
                sqlText += "  ,SLIP.SUPPLIERNM2RF" + Environment.NewLine;
                sqlText += "  ,SLIP.SUPPLIERSNMRF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKTOTALPRICERF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKSUBTTLPRICERF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKPRICECONSTAXRF" + Environment.NewLine;
                sqlText += "  ,SLIP.PARTYSALESLIPNUMRF" + Environment.NewLine;
                sqlText += "  ,SLIP.SUPPLIERSLIPNOTE1RF" + Environment.NewLine;
                sqlText += "  ,SLIP.SUPPLIERSLIPNOTE2RF" + Environment.NewLine;
                sqlText += "  ,SLIP.UOEREMARK1RF" + Environment.NewLine;
                sqlText += "  ,SLIP.UOEREMARK2RF" + Environment.NewLine;
                sqlText += "  ,DETAIL.STOCKROWNORF" + Environment.NewLine;
                sqlText += "  ,DETAIL.COMMONSEQNORF" + Environment.NewLine;
                sqlText += "  ,DETAIL.STOCKSLIPDTLNUMRF" + Environment.NewLine;
                sqlText += "  ,DETAIL.GOODSNORF" + Environment.NewLine;
                sqlText += "  ,DETAIL.GOODSNAMERF" + Environment.NewLine;
                sqlText += "  ,DETAIL.GOODSNAMEKANARF" + Environment.NewLine;
                sqlText += "  ,DETAIL.SALESCUSTOMERCODERF" + Environment.NewLine;
                sqlText += "  ,DETAIL.SALESCUSTOMERSNMRF" + Environment.NewLine;
                sqlText += "  ,DETAIL.STOCKCOUNTRF" + Environment.NewLine;
                sqlText += "  ,DETAIL.STOCKUNITPRICEFLRF" + Environment.NewLine;
                sqlText += "  ,DETAIL.STOCKPRICETAXEXCRF" + Environment.NewLine;
                sqlText += "  ,DETAIL.STOCKPRICECONSTAXRF AS DTL_STOCKPRICECONSTAXRF" + Environment.NewLine;
                sqlText += "FROM STOCKSLIPHISTRF SLIP" + Environment.NewLine;
                sqlText += "LEFT JOIN STOCKSLHISTDTLRF AS DETAIL ON (SLIP.ENTERPRISECODERF=DETAIL.ENTERPRISECODERF AND SLIP.SUPPLIERFORMALRF=DETAIL.SUPPLIERFORMALRF AND SLIP.SUPPLIERSLIPNORF=DETAIL.SUPPLIERSLIPNORF ) " + Environment.NewLine;

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))
                {
                    if (sumSuppEnable == 1)
                    {
                        // Where���̍쐬
                        bool result = this.MakeWhereStringSumSupp(sqlCommand, enterpriseCode, addUpSecCodeList, startSupplierCd, endSupplierCd, startAddUpDate, endAddUpDate, goodsCdMode);
                        if (!result) return status;
                    }
                    else
                    {
                        // Where���̍쐬
                        bool result = this.MakeWhereString(sqlCommand, enterpriseCode, addUpSecCodeList, startSupplierCd, endSupplierCd, startAddUpDate, endAddUpDate, goodsCdMode);
                        if (!result) return status;
                    }
                    using (SqlDataReader myReader = sqlCommand.ExecuteReader())
                    {
                        try
                        {
                            this.SetListFromSQLReader(ref status, ref al, myReader, (int)PrintMode.Dtl, sumSuppEnable);
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
                base.WriteErrorLog(ex, "LedgerStockSlipWorkDB.SearchDtlProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            ledgerStockDetailWork = al;

            return status;
        }

        /// <summary>
        /// SQL�f�[�^���[�_�[���d���挳���d���f�[�^���[�N
        /// </summary>
        /// <param name="_ledgerStockDetailWork">�d���挳���d���f�[�^���[�N</param>
        /// <param name="myReader">SQL�f�[�^���[�_�[</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SQL�f�[�^���[�_�[�ɕێ����Ă�����e���d���挳���d���f�[�^���[�N�ɃR�s�[���܂��B</br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.12.04</br>
        private void CopyToDataClassFromSelectDataDetail(ref LedgerStockDetailWork _ledgerStockDetailWork, SqlDataReader myReader)
        {
            #region �d���挳���d���f�[�^���[�N�֊i�[
            _ledgerStockDetailWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            _ledgerStockDetailWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
            _ledgerStockDetailWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
            _ledgerStockDetailWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            _ledgerStockDetailWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
            _ledgerStockDetailWork.DebitNLnkSuppSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNLNKSUPPSLIPNORF"));
            _ledgerStockDetailWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));
            _ledgerStockDetailWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
            _ledgerStockDetailWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
            _ledgerStockDetailWork.StockAddUpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKADDUPSECTIONCDRF"));
            _ledgerStockDetailWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
            _ledgerStockDetailWork.ArrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
            _ledgerStockDetailWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
            _ledgerStockDetailWork.StockAddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKADDUPADATERF"));
            _ledgerStockDetailWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
            _ledgerStockDetailWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));
            _ledgerStockDetailWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
            _ledgerStockDetailWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
            _ledgerStockDetailWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            _ledgerStockDetailWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
            _ledgerStockDetailWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            _ledgerStockDetailWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
            _ledgerStockDetailWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
            _ledgerStockDetailWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            _ledgerStockDetailWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
            _ledgerStockDetailWork.StockSubttlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSUBTTLPRICERF"));
            _ledgerStockDetailWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
            _ledgerStockDetailWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
            _ledgerStockDetailWork.SupplierSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE1RF"));
            _ledgerStockDetailWork.SupplierSlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE2RF"));
            _ledgerStockDetailWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
            _ledgerStockDetailWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
            _ledgerStockDetailWork.StockRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKROWNORF"));
            _ledgerStockDetailWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));
            _ledgerStockDetailWork.StockSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMRF"));
            _ledgerStockDetailWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            _ledgerStockDetailWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            _ledgerStockDetailWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
            _ledgerStockDetailWork.SalesCustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCUSTOMERCODERF"));
            _ledgerStockDetailWork.SalesCustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESCUSTOMERSNMRF"));
            _ledgerStockDetailWork.StockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNTRF"));
            _ledgerStockDetailWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            _ledgerStockDetailWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
            _ledgerStockDetailWork.Dtl_StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DTL_STOCKPRICECONSTAXRF"));
            #endregion

            // --- ADD 2012/11/01 ---------->>>>>
            //_ledgerStockDetailWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));
            // --- ADD 2012/11/01 ----------<<<<<
        }
        #endregion

        /// <summary>
        /// �d���挳���d���f�[�^���X�g�i�[����
        /// </summary>
        /// <param name="status">�X�e�[�^�X</param>
        /// <param name="al">�d���挳���d���f�[�^���X�g</param>
        /// <param name="myReader">SQLDataReader</param>
        /// <param name="printMode">����^�C�v</param>
        /// <param name="sumSuppEnable">�d���摍�����p�� 0:���p�s�� 1:���p��</param>
        /// <br>Note       : SQLDataReader�̏����d���挳���d���f�[�^���X�g�ɃZ�b�g���܂��B</br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.12.04</br>
        private void SetListFromSQLReader(ref int status, ref ArrayList al, SqlDataReader myReader, int printMode, int sumSuppEnable)
        {
            if (al == null)
            {
                al = new ArrayList();
            }

            LedgerStockSlipWork _ledgerStockSlipWork;
            LedgerStockDetailWork _ledgerStockDetailWork;

            while (myReader.Read())
            {
                _ledgerStockSlipWork = new LedgerStockSlipWork();
                _ledgerStockDetailWork = new LedgerStockDetailWork();

                //SQL�f�[�^���[�_�[���d���挳���d���f�[�^���[�N
                if (printMode == (int)PrintMode.Slip)
                {
                    // --- ADD 2012/10/02 ---------->>>>>
                    if (sumSuppEnable == 1)
                    {
                        this.CopyToDataClassFromSelectDataSumSupp(ref _ledgerStockSlipWork, myReader);
                    }
                    else
                    {
                        this.CopyToDataClassFromSelectData(ref _ledgerStockSlipWork, myReader);
                    }
                    // --- ADD 2012/10/02 ----------<<<<<
                    al.Add(_ledgerStockSlipWork);
                }
                else
                if (printMode == (int)PrintMode.Dtl)
                {
                    // --- ADD 2012/10/02 ---------->>>>>
                    if (sumSuppEnable == 1)
                    {
                        this.CopyToDataClassFromSelectDataDetailSumSupp(ref _ledgerStockDetailWork, myReader);
                    }
                    else
                    {
                    this.CopyToDataClassFromSelectDataDetail(ref _ledgerStockDetailWork, myReader);
                    }
                    // --- ADD 2012/10/02 ----------<<<<<
                    al.Add(_ledgerStockDetailWork);
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
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
        /// <param name="goodsCdMode">���i�敪���[�h 0:�ʏ� 1:�x��(4,5,10�����O) 2:���|</param>
        /// <returns>Where����������</returns>
        /// <br>UpdateNote : 2015/10/21 �c�v�t</br>
        /// <br>�Ǘ��ԍ�   : 11170187-00</br>
        /// <br>           : Redmine#47545 �d���挳���̖��ו��Ɏd����q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή�</br> 
        private bool MakeWhereString(SqlCommand sqlCommand, string enterpriseCode, ArrayList addUpSecCodeList, int startSupplierCd, int endSupplierCd, 
            int startAddUpDate, int endAddUpDate, int goodsCdMode)
        {
            #region WHERE���쐬
            sqlCommand.CommandText += " WHERE";

            // ��ƃR�[�h
            sqlCommand.CommandText += " SLIP.ENTERPRISECODERF=@FINDENTERPRISECODE";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

            // �_���폜�敪
            sqlCommand.CommandText += " AND SLIP.LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            //�x����R�[�h
            if (startSupplierCd != 0)
            {
                sqlCommand.CommandText += " AND SLIP.PAYEECODERF>=@STPAYEECODE";
                SqlParameter paraStPayeeCode = sqlCommand.Parameters.Add("@STPAYEECODE", SqlDbType.Int);
                paraStPayeeCode.Value = SqlDataMediator.SqlSetInt32(startSupplierCd);
            }
            if (endSupplierCd != 0)
            {
                sqlCommand.CommandText += " AND SLIP.PAYEECODERF<=@EDPAYEECODE";
                SqlParameter paraEdPayeeCode = sqlCommand.Parameters.Add("@EDPAYEECODE", SqlDbType.Int);
                paraEdPayeeCode.Value = SqlDataMediator.SqlSetInt32(endSupplierCd);
            }

            // �d���v����t
            if (startAddUpDate <= endAddUpDate)
            {
                if (startAddUpDate == endAddUpDate)
                {
                    sqlCommand.CommandText += " AND SLIP.STOCKADDUPADATERF=@FINDSTOCKADDUPADATE";
                    SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@FINDSTOCKADDUPADATE", SqlDbType.Int);
                    paraAddUpDate.Value = SqlDataMediator.SqlSetInt32(startAddUpDate);
                }
                else
                {
                    sqlCommand.CommandText += " AND SLIP.STOCKADDUPADATERF>=@FINDSTARTSTOCKADDUPADATE AND SLIP.STOCKADDUPADATERF<=@FINDENDSTOCKADDUPADATE";
                    SqlParameter paraStartAddUpDate = sqlCommand.Parameters.Add("@FINDSTARTSTOCKADDUPADATE", SqlDbType.Int);
                    paraStartAddUpDate.Value = SqlDataMediator.SqlSetInt32(startAddUpDate);
                    SqlParameter paraEndAddUpDate = sqlCommand.Parameters.Add("@FINDENDSTOCKADDUPADATE", SqlDbType.Int);
                    paraEndAddUpDate.Value = SqlDataMediator.SqlSetInt32(endAddUpDate);
                }
            }
            else
            {
                return false;
            }

            // ---------- DEL 2015/10/21 �c�v�t For Redmine#47545 �d���挳���̖��ו��Ɏd����q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή� ---------->>>>>
            //// �d���v�㋒�_
            //StringBuilder whereSectionCode = new StringBuilder();
            //if (addUpSecCodeList.Count > 0)
            //{
            //    if (addUpSecCodeList.Count == 1)
            //    {
            //        sqlCommand.CommandText += " AND SLIP.STOCKADDUPSECTIONCDRF='" + addUpSecCodeList[0] + "'";
            //    }
            //    else
            //    {
            //        sqlCommand.CommandText += " AND SLIP.STOCKADDUPSECTIONCDRF IN (";

            //        string str = "";
            //        for (int ix = 0; ix < addUpSecCodeList.Count; ix++)
            //        {
            //            if (ix != 0)
            //            {
            //                str += ",";
            //            }
            //            str += "'" + addUpSecCodeList[ix] + "'";
            //        }
            //        sqlCommand.CommandText += str + ")";
            //    }
            //}
            // ---------- DEL 2015/10/21 �c�v�t For Redmine#47545 �d���挳���̖��ו��Ɏd����q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή� ----------<<<<<

            //�d�����i�敪�̃`�F�b�N
            if (goodsCdMode == 1)
            {
                sqlCommand.CommandText += " AND SLIP.STOCKGOODSCDRF!=4 AND SLIP.STOCKGOODSCDRF!=5 AND SLIP.STOCKGOODSCDRF!=10";
            }
            else if (goodsCdMode == 2)
            {
            }

            #endregion
            return true;
        }

        // --- ADD 2012/10/02 ---------->>>>>
        #region �d���摍���L����
        /// <summary>
        /// SQL�f�[�^���[�_�[���d���挳���d���f�[�^���[�N
        /// </summary>
        /// <param name="_ledgerStockSlipWork">�d���挳���d���f�[�^���[�N</param>
        /// <param name="myReader">SQL�f�[�^���[�_�[</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SQL�f�[�^���[�_�[�ɕێ����Ă�����e���d���挳���d���f�[�^���[�N�ɃR�s�[���܂��B</br>
        /// <br>           : �d���摍���I�v�V�����L�����ɃR�[������܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/10/02</br>	
        /// <br>UpdateNote : 2015/12/10 �c�v�t</br>
        /// <br>�Ǘ��ԍ�   : 11170204-00</br>
        /// <br>           : Redmine#47545 ��Q�P �d�������I�v�V�����L�����A�d���挳���̖��ו�(�d����e)�ɐe�q�����̖��ׂ��󎚂����̏�Q�Ή�</br>
        private void CopyToDataClassFromSelectDataSumSupp(ref LedgerStockSlipWork _ledgerStockSlipWork, SqlDataReader myReader)
        {
            #region �d���挳���d���f�[�^���[�N�֊i�[
            _ledgerStockSlipWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            _ledgerStockSlipWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
            _ledgerStockSlipWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
            _ledgerStockSlipWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            _ledgerStockSlipWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
            _ledgerStockSlipWork.DebitNLnkSuppSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNLNKSUPPSLIPNORF"));
            _ledgerStockSlipWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));
            _ledgerStockSlipWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
            _ledgerStockSlipWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));

            // �d�������L�����͌v�㋒�_�ɑ΂��Ďd�����_�R�[�h������
            _ledgerStockSlipWork.StockAddUpSectionCd = _ledgerStockSlipWork.StockSectionCd;

            _ledgerStockSlipWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
            _ledgerStockSlipWork.ArrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
            _ledgerStockSlipWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
            _ledgerStockSlipWork.StockAddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKADDUPADATERF"));
            _ledgerStockSlipWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
            _ledgerStockSlipWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));
            _ledgerStockSlipWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
            _ledgerStockSlipWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
            // ------- DEL 2015/12/10 �c�v�t For Redmine#47545 ��Q�P �d�������I�v�V�����L�����A�d���挳���̖��ו�(�d����e)�ɐe�q�����̖��ׂ��󎚂����̏�Q�Ή� ------->>>>>
            //_ledgerStockSlipWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            //_ledgerStockSlipWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
            // ------- DEL 2015/12/10 �c�v�t For Redmine#47545 ��Q�P �d�������I�v�V�����L�����A�d���挳���̖��ו�(�d����e)�ɐe�q�����̖��ׂ��󎚂����̏�Q�Ή� -------<<<<<
            _ledgerStockSlipWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            _ledgerStockSlipWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
            _ledgerStockSlipWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
            _ledgerStockSlipWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            _ledgerStockSlipWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
            _ledgerStockSlipWork.StockSubttlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSUBTTLPRICERF"));
            _ledgerStockSlipWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
            _ledgerStockSlipWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
            _ledgerStockSlipWork.SupplierSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE1RF"));
            _ledgerStockSlipWork.SupplierSlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE2RF"));
            _ledgerStockSlipWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
            _ledgerStockSlipWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
            // ------- ADD 2015/12/10 �c�v�t For Redmine#47545 ��Q�P �d�������I�v�V�����L�����A�d���挳���̖��ו�(�d����e)�ɐe�q�����̖��ׂ��󎚂����̏�Q�Ή� ------->>>>>
            _ledgerStockSlipWork.PayeeCode = _ledgerStockSlipWork.SupplierCd;
            _ledgerStockSlipWork.PayeeSnm = _ledgerStockSlipWork.SupplierSnm;
            // ------- ADD 2015/12/10 �c�v�t For Redmine#47545 ��Q�P �d�������I�v�V�����L�����A�d���挳���̖��ו�(�d����e)�ɐe�q�����̖��ׂ��󎚂����̏�Q�Ή� -------<<<<<
			#endregion
        }

        /// <summary>
        /// SQL�f�[�^���[�_�[���d���挳���d���f�[�^���[�N
        /// </summary>
        /// <param name="_ledgerStockDetailWork">�d���挳���d���f�[�^���[�N</param>
        /// <param name="myReader">SQL�f�[�^���[�_�[</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SQL�f�[�^���[�_�[�ɕێ����Ă�����e���d���挳���d���f�[�^���[�N�ɃR�s�[���܂��B</br>
        /// <br>           : �d���摍���I�v�V�����L�����ɃR�[������܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/10/02</br>
        /// <br>UpdateNote : 2015/12/10 �c�v�t</br>
        /// <br>�Ǘ��ԍ�   : 11170204-00</br>
        /// <br>           : Redmine#47545 ��Q�P �d�������I�v�V�����L�����A�d���挳���̖��ו�(�d����e)�ɐe�q�����̖��ׂ��󎚂����̏�Q�Ή�</br>
        private void CopyToDataClassFromSelectDataDetailSumSupp(ref LedgerStockDetailWork _ledgerStockDetailWork, SqlDataReader myReader)
        {
            #region �d���挳���d���f�[�^���[�N�֊i�[
            _ledgerStockDetailWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            _ledgerStockDetailWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
            _ledgerStockDetailWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
            _ledgerStockDetailWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            _ledgerStockDetailWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
            _ledgerStockDetailWork.DebitNLnkSuppSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNLNKSUPPSLIPNORF"));
            _ledgerStockDetailWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));
            _ledgerStockDetailWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
            _ledgerStockDetailWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));

            // �d�������L�����͌v�㋒�_�ɑ΂��Ďd�����_�R�[�h������
            _ledgerStockDetailWork.StockAddUpSectionCd = _ledgerStockDetailWork.StockSectionCd;

            _ledgerStockDetailWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
            _ledgerStockDetailWork.ArrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
            _ledgerStockDetailWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
            _ledgerStockDetailWork.StockAddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKADDUPADATERF"));
            _ledgerStockDetailWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
            _ledgerStockDetailWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));
            _ledgerStockDetailWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
            _ledgerStockDetailWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
            // ------- DEL 2015/12/10 �c�v�t For Redmine#47545 ��Q�P �d�������I�v�V�����L�����A�d���挳���̖��ו�(�d����e)�ɐe�q�����̖��ׂ��󎚂����̏�Q�Ή� ------->>>>>
            //_ledgerStockDetailWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            //_ledgerStockDetailWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
            // ------- DEL 2015/12/10 �c�v�t For Redmine#47545 ��Q�P �d�������I�v�V�����L�����A�d���挳���̖��ו�(�d����e)�ɐe�q�����̖��ׂ��󎚂����̏�Q�Ή� -------<<<<<
            _ledgerStockDetailWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            _ledgerStockDetailWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
            _ledgerStockDetailWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
            _ledgerStockDetailWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            _ledgerStockDetailWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
            _ledgerStockDetailWork.StockSubttlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSUBTTLPRICERF"));
            _ledgerStockDetailWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
            _ledgerStockDetailWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
            _ledgerStockDetailWork.SupplierSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE1RF"));
            _ledgerStockDetailWork.SupplierSlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE2RF"));
            _ledgerStockDetailWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
            _ledgerStockDetailWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
            _ledgerStockDetailWork.StockRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKROWNORF"));
            _ledgerStockDetailWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));
            _ledgerStockDetailWork.StockSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMRF"));
            _ledgerStockDetailWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            _ledgerStockDetailWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            _ledgerStockDetailWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
            _ledgerStockDetailWork.SalesCustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCUSTOMERCODERF"));
            _ledgerStockDetailWork.SalesCustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESCUSTOMERSNMRF"));
            _ledgerStockDetailWork.StockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNTRF"));
            _ledgerStockDetailWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            _ledgerStockDetailWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
            _ledgerStockDetailWork.Dtl_StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DTL_STOCKPRICECONSTAXRF"));
            // ------- ADD 2015/12/10 �c�v�t For Redmine#47545 ��Q�P �d�������I�v�V�����L�����A�d���挳���̖��ו�(�d����e)�ɐe�q�����̖��ׂ��󎚂����̏�Q�Ή� ------->>>>>
            _ledgerStockDetailWork.PayeeCode = _ledgerStockDetailWork.SupplierCd;
            _ledgerStockDetailWork.PayeeSnm = _ledgerStockDetailWork.SupplierSnm;
            // ------- ADD 2015/12/10 �c�v�t For Redmine#47545 ��Q�P �d�������I�v�V�����L�����A�d���挳���̖��ו�(�d����e)�ɐe�q�����̖��ׂ��󎚂����̏�Q�Ή� -------<<<<<
			#endregion
        }

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
        /// <param name="goodsCdMode">���i�敪���[�h 0:�ʏ� 1:�x��(4,5,10�����O) 2:���|</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : �������������񐶐��{�����l�ݒ菈���B</br>
        /// <br>           : �d���摍���I�v�V�����L�����ɃR�[������܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/10/02</br>
        /// <br>UpdateNote : 2015/12/17 �c�v�t</br>
        /// <br>�Ǘ��ԍ�   : 11170204-00</br>
        /// <br>           : Redmine#47545 �V�X�e���e�X�g��Q�ꗗ_#47545�̎w�ENO.2 ���o�������x���悩��d����ɕύX������A�����̕ϐ������ύX���Ȃ��Ή�</br>
        private bool MakeWhereStringSumSupp(SqlCommand sqlCommand, string enterpriseCode, ArrayList addUpSecCodeList, int startSupplierCd, int endSupplierCd,
            int startAddUpDate, int endAddUpDate, int goodsCdMode)
        {
            #region WHERE���쐬
            sqlCommand.CommandText += " WHERE";

            // ��ƃR�[�h
            sqlCommand.CommandText += " SLIP.ENTERPRISECODERF=@FINDENTERPRISECODE";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

            // �_���폜�敪
            sqlCommand.CommandText += " AND SLIP.LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            // ------- DEL 2015/12/17 �c�v�t For Redmine#47545 �V�X�e���e�X�g��Q�ꗗ_#47545�̎w�ENO.2 ���o�������x���悩��d����ɕύX������A�����̕ϐ������ύX���Ȃ��Ή� ------->>>>>
            ////�x����R�[�h
            //if (startSupplierCd != 0)
            //{
            //    sqlCommand.CommandText += " AND SLIP.PAYEECODERF>=@STPAYEECODE";
            //    SqlParameter paraStPayeeCode = sqlCommand.Parameters.Add("@STPAYEECODE", SqlDbType.Int);
            //    paraStPayeeCode.Value = SqlDataMediator.SqlSetInt32(startSupplierCd);
            //}
            //if (endSupplierCd != 0)
            //{
            //    sqlCommand.CommandText += " AND SLIP.PAYEECODERF<=@EDPAYEECODE";
            //    SqlParameter paraEdPayeeCode = sqlCommand.Parameters.Add("@EDPAYEECODE", SqlDbType.Int);
            //    paraEdPayeeCode.Value = SqlDataMediator.SqlSetInt32(endSupplierCd);
            //}
            // ------- DEL 2015/12/17 �c�v�t For Redmine#47545 �V�X�e���e�X�g��Q�ꗗ_#47545�̎w�ENO.2 ���o�������x���悩��d����ɕύX������A�����̕ϐ������ύX���Ȃ��Ή� -------<<<<<

            // ------- ADD 2015/12/17 �c�v�t For Redmine#47545 �V�X�e���e�X�g��Q�ꗗ_#47545�̎w�ENO.2 ���o�������x���悩��d����ɕύX������A�����̕ϐ������ύX���Ȃ��Ή� ------->>>>>
            //�d����R�[�h
            if (startSupplierCd != 0)
            {
                sqlCommand.CommandText += " AND SLIP.SUPPLIERCDRF>=@STSUPPLIERCODE";
                SqlParameter paraStSupplierCode = sqlCommand.Parameters.Add("@STSUPPLIERCODE", SqlDbType.Int);
                paraStSupplierCode.Value = SqlDataMediator.SqlSetInt32(startSupplierCd);
            }
            if (endSupplierCd != 0)
            {
                sqlCommand.CommandText += " AND SLIP.SUPPLIERCDRF<=@EDSUPPLIERCODE";
                SqlParameter paraEdSupplierCode = sqlCommand.Parameters.Add("@EDSUPPLIERCODE", SqlDbType.Int);
                paraEdSupplierCode.Value = SqlDataMediator.SqlSetInt32(endSupplierCd);
            }
            // ------- ADD 2015/12/17 �c�v�t For Redmine#47545 �V�X�e���e�X�g��Q�ꗗ_#47545�̎w�ENO.2 ���o�������x���悩��d����ɕύX������A�����̕ϐ������ύX���Ȃ��Ή� -------<<<<<

            // �d���v����t
            if (startAddUpDate <= endAddUpDate)
            {
                if (startAddUpDate == endAddUpDate)
                {
                    sqlCommand.CommandText += " AND SLIP.STOCKADDUPADATERF=@FINDSTOCKADDUPADATE";
                    SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@FINDSTOCKADDUPADATE", SqlDbType.Int);
                    paraAddUpDate.Value = SqlDataMediator.SqlSetInt32(startAddUpDate);
                }
                else
                {
                    sqlCommand.CommandText += " AND SLIP.STOCKADDUPADATERF>=@FINDSTARTSTOCKADDUPADATE AND SLIP.STOCKADDUPADATERF<=@FINDENDSTOCKADDUPADATE";
                    SqlParameter paraStartAddUpDate = sqlCommand.Parameters.Add("@FINDSTARTSTOCKADDUPADATE", SqlDbType.Int);
                    paraStartAddUpDate.Value = SqlDataMediator.SqlSetInt32(startAddUpDate);
                    SqlParameter paraEndAddUpDate = sqlCommand.Parameters.Add("@FINDENDSTOCKADDUPADATE", SqlDbType.Int);
                    paraEndAddUpDate.Value = SqlDataMediator.SqlSetInt32(endAddUpDate);
                }
            }
            else
            {
                return false;
            }

            // �d�����_
            StringBuilder whereSectionCode = new StringBuilder();
            if (addUpSecCodeList.Count > 0)
            {
                if (addUpSecCodeList.Count == 1)
                {
                    sqlCommand.CommandText += " AND SLIP.STOCKSECTIONCDRF='" + addUpSecCodeList[0] + "'";
                }
                else
                {
                    sqlCommand.CommandText += " AND SLIP.STOCKSECTIONCDRF IN (";
                    
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

            //�d�����i�敪�̃`�F�b�N
            if (goodsCdMode == 1)
            {
                sqlCommand.CommandText += " AND SLIP.STOCKGOODSCDRF!=4 AND SLIP.STOCKGOODSCDRF!=5 AND SLIP.STOCKGOODSCDRF!=10";
            }
            else if (goodsCdMode == 2)
            {
            }

            #endregion
            return true;
        }
        
        #endregion �d���摍���L����
        // --- ADD 2012/10/02 ----------<<<<<

    }
}

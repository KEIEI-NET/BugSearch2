//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �t���E�����E�c�l�e�L�X�g�o��
// �v���O�����T�v   : �t���E�����E�c�l�e�L�X�g�o�͂��s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �t���E�����E�c�l�e�L�X�g�o�͏����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �t���E�����E�c�l�e�L�X�g�o�͏����N���X�̃C���X�^���X�̍쐬���s���B</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2009.04.01</br>
    /// </remarks>
    public class PostEnvelDMInstsMainAcs
    {
        #region �� Private Member
        // �}�X�^�����C���^�t�F�[�X
        private IUseMastListDB _iUseMastListDB;

        private static PostEnvelDMInstsMainAcs _postEnvelDMInstsMainAcs;
        // CSV��DataSet
        private DataSet _dataSet;

        #endregion

        # region ��Constracter

        /// <summary>
        /// �t���E�����E�c�l�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �t���E�����E�c�l�A�N�Z�X�N���X�B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public PostEnvelDMInstsMainAcs()
        {
            this._iUseMastListDB = (IUseMastListDB)MediationUseMastDB.GetMastDB();
        }

        /// <summary>
        /// �t���E�����E�c�l�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �t���E�����E�c�l�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B�B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public static PostEnvelDMInstsMainAcs GetInstance()
        {
            if (_postEnvelDMInstsMainAcs == null)
            {
                _postEnvelDMInstsMainAcs = new PostEnvelDMInstsMainAcs();
            }
            return _postEnvelDMInstsMainAcs;
        }

        /// public propaty name  :  DataSet
        /// <summary>DataSet�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   DataSet�v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ���R</br>
        /// </remarks>
        public DataSet UseMastDs
        {
            get { return this._dataSet; }
        }
        # endregion

        #region �� �g�p�}�X�^��񌟍�
        /// <summary>
        /// �g�p�}�X�^�f�[�^�擾����
        /// </summary>
        /// <param name="condition">��������</param>
        /// <param name="retList">�����f�[�^</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �g�p�}�X�^�f�[�^�擾�������s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        public int Search(PostcardEnvelopeDMTextCndtn condition, out ArrayList retList)
        {
            _dataSet = new DataSet();
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            retList = new ArrayList();
            object retObj = null;
            // ���o�����W�J<��ʌ������->remoteDean>  --------------------------------------------------------------
            PostcardEnvelopeDMWork postcardEnvelopeDMWork = new PostcardEnvelopeDMWork();
            // ���o����
            SetCondInfo(ref condition, ref postcardEnvelopeDMWork);

            // �f�[�^�擾  ----------------------------------------------------------------
            // ���Ӑ�}�X�^�f�[�^�擾
            if (postcardEnvelopeDMWork.UseMast == (int)PostcardEnvelopeDMTextCndtn.UseMastDivState.Customer)
            {
                status = _iUseMastListDB.SearchCustomer(out retObj, postcardEnvelopeDMWork);
                if (status == 0)
                {
                    ConverToDataSetCustomerInf((ArrayList)retObj);
                }
                retList = (ArrayList)retObj;
            }
            // �d����}�X�^�f�[�^�擾
            else if (postcardEnvelopeDMWork.UseMast == (int)PostcardEnvelopeDMTextCndtn.UseMastDivState.Supplier)
            {
                SupplierAcs supplierAcs = new SupplierAcs();
                status = supplierAcs.Search(out retList, postcardEnvelopeDMWork.EnterpriseCode);
                if (status == 0)
                {
                    ConverToDataSetSupplierInf(retList, condition);
                    if (_dataSet.Tables["SupplierExp"].DefaultView.Count == 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }

            }
            // ���Ѓ}�X�^�f�[�^�擾
            else if (postcardEnvelopeDMWork.UseMast == (int)PostcardEnvelopeDMTextCndtn.UseMastDivState.Company)
            {
                CompanyInfAcs companyInfAcs = new CompanyInfAcs();
                CompanyInf companyInf = null;
                status = companyInfAcs.Read(out companyInf, postcardEnvelopeDMWork.EnterpriseCode);
                if (status == 0)
                {
                    ConverToDataSetCompanyInf(companyInf);
                    if (_dataSet.Tables["CompanyExp"].DefaultView.Count == 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }

            }
            // ���_�}�X�^�f�[�^�擾
            else if (postcardEnvelopeDMWork.UseMast == (int)PostcardEnvelopeDMTextCndtn.UseMastDivState.SecInfo)
            {
                status = _iUseMastListDB.SearchSecInfoSet(out retObj, postcardEnvelopeDMWork);
                if (status == 0)
                {
                    ConverToDataSetSectionInf((ArrayList)retObj);
                }

                retList = (ArrayList)retObj;
            }
            if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }
            return status;
        }
        #endregion

        #region �� Private Methods
        /// <summary>
        /// �������ʃN���X��ݒ�
        /// </summary>
        /// <param name="condition">��������</param>
        /// <param name="postcardEnvelopeDMWork">�������ʃN���X</param>
        /// <remarks>
        /// <br>Note       : �������ʃN���X��ݒ肷��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void SetCondInfo(ref PostcardEnvelopeDMTextCndtn condition, ref PostcardEnvelopeDMWork postcardEnvelopeDMWork)
        {
            //��ƃR�[�h
            postcardEnvelopeDMWork.EnterpriseCode = condition.EnterpriseCode;
            // �g�p�}�X�^
            postcardEnvelopeDMWork.UseMast = condition.UseMast;
            // �o�͋敪
            postcardEnvelopeDMWork.OutShipDiv = condition.OutShipDiv;
            // ����
            postcardEnvelopeDMWork.TotalDay = condition.TotalDay;
            // �Ώۓ��t�J�n��
            postcardEnvelopeDMWork.St_AddUpDay = condition.St_AddUpDay;
            // �Ώۓ��t�I����
            postcardEnvelopeDMWork.Ed_AddUpDay = condition.Ed_AddUpDay;
            // ���_�R�[�h�J�n
            postcardEnvelopeDMWork.St_SectionCode = condition.St_SectionCode;
            // ���_�R�[�h�I��
            postcardEnvelopeDMWork.Ed_SectionCode = condition.Ed_SectionCode;
            // ���Ӑ�R�[�h�J�n
            postcardEnvelopeDMWork.St_CustomerCode = condition.St_CustomerCode;
            // ���Ӑ�R�[�h�I��
            postcardEnvelopeDMWork.Ed_CustomerCode = condition.Ed_CustomerCode;
            // �d����R�[�h�J�n
            postcardEnvelopeDMWork.St_SupplierCode = condition.St_SupplierCode;
            // �d����R�[�h�I��
            postcardEnvelopeDMWork.Ed_SupplierCode = condition.Ed_SupplierCode;
        }
        /// <summary>
        /// �������ʂ�ConvertToDataSet
        /// </summary>
        /// <param name="retList">��������</param>
        /// <remarks>
        /// <br>Note       : �������ʂ�ConvertToDataSet�ɍs���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void ConverToDataSetCustomerInf(ArrayList retList)
        {
            // �f�[�^�Z�b�g�i�[�p�f�[�^�e�[�u��
            DataTable dataTable = new DataTable("CustomerExp");

            // �J�����ǉ�
            # region �J�����ǉ�(CSV�f�[�^�p)
            dataTable.Columns.Add("MngSectionCodeRF", typeof(string));      //  �Ǘ����_�R�[�h
            dataTable.Columns.Add("CustomerCodeRF", typeof(string));	    //  ���Ӑ�R�[�h
            dataTable.Columns.Add("NameRF", typeof(string));	            //  ����
            dataTable.Columns.Add("Name2RF", typeof(string));	            //  ����2
            dataTable.Columns.Add("PostNoRF", typeof(string));	            //  �X�֔ԍ�
            dataTable.Columns.Add("Address1RF", typeof(string));	        //  �Z��1�i�s���{���s��S�E�����E���j
            dataTable.Columns.Add("Address3RF", typeof(string));	        //  �Z��3�i�Ԓn�j
            dataTable.Columns.Add("Address4RF", typeof(string));	        //  �Z��4�i�A�p�[�g���́j
            dataTable.Columns.Add("OfficeTelNoRF", typeof(string));	        //  �d�b�ԍ��i�Ζ���j
            dataTable.Columns.Add("HomeTelNoRF", typeof(string));	        //  �d�b�ԍ��i����j
            dataTable.Columns.Add("OfficeFaxNoRF", typeof(string));	        //  FAX�ԍ��i�Ζ���j
            dataTable.Columns.Add("CustomerAgentRF", typeof(string));	    //  ���Ӑ�S����
            foreach (PostCustomerWork customerWork in retList)
            {
                DataRow dataRow = dataTable.NewRow();
                // �Ǘ����_�R�[�h
                StringBuilder tempSection = new StringBuilder();
                for (int i = customerWork.MngSectionCode.Trim().Length; i < 2; i++)
                {
                    tempSection.Append("0");
                }
                tempSection.Append(customerWork.MngSectionCode);
                dataRow["MngSectionCodeRF"] = tempSection.ToString().Trim();
                // ���Ӑ�R�[�h
                StringBuilder tempCustCd = new StringBuilder();
                for (int i = customerWork.CustomerCode.ToString().Length; i < 8; i++)
                {
                    tempCustCd.Append("0");
                }
                tempCustCd.Append(customerWork.CustomerCode);
                dataRow["CustomerCodeRF"] = tempCustCd.ToString().Trim();
                // ����
                dataRow["NameRF"] = customerWork.Name.Trim();
                // ����2
                dataRow["Name2RF"] = customerWork.Name2.Trim();
                // �X�֔ԍ�
                dataRow["PostNoRF"] = customerWork.PostNo.Trim();
                // �Z��1�i�s���{���s��S�E�����E���j
                dataRow["Address1RF"] = customerWork.Address1.Trim();
                // �Z��3�i�Ԓn�j
                dataRow["Address3RF"] = customerWork.Address3.Trim();
                // �Z��4�i�A�p�[�g���́j
                dataRow["Address4RF"] = customerWork.Address4.Trim();
                // �d�b�ԍ��i�Ζ���j
                dataRow["OfficeTelNoRF"] = customerWork.OfficeTelNo.Trim();
                // �d�b�ԍ��i����j
                dataRow["HomeTelNoRF"] = customerWork.HomeTelNo.Trim();
                // FAX�ԍ��i�Ζ���j
                dataRow["OfficeFaxNoRF"] = customerWork.OfficeFaxNo.Trim();
                // ���Ӑ�S����
                dataRow["CustomerAgentRF"] = customerWork.CustomerAgent.Trim();
                dataTable.Rows.Add(dataRow);

            }
            #endregion
            _dataSet.Tables.Add(dataTable);
        }
        /// <summary>
        /// �������ʂ�ConvertToDataSet
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="condition">��������</param>
        /// <remarks>
        /// <br>Note       : �������ʂ�ConvertToDataSet�ɍs���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void ConverToDataSetSupplierInf(ArrayList retList, PostcardEnvelopeDMTextCndtn condition)
        {
            // �f�[�^�Z�b�g�i�[�p�f�[�^�e�[�u��
            DataTable dataTable = new DataTable("SupplierExp");

            // �J�����ǉ�
            # region �J�����ǉ�(CSV�f�[�^�p)
            dataTable.Columns.Add("MngSectionCodeRF", typeof(string));      //  �Ǘ����_�R�[�h
            dataTable.Columns.Add("SupplierCdRF", typeof(string));           //  �d����R�[�h
            dataTable.Columns.Add("SupplierNm1RF", typeof(string));	        //  �d���於1
            dataTable.Columns.Add("SupplierNm2RF", typeof(string));	        //  �d���於2
            dataTable.Columns.Add("SupplierPostNoRF", typeof(string));	    //  �d����X�֔ԍ�
            dataTable.Columns.Add("SupplierAddr1RF", typeof(string));	    //  �d����Z��1�i�s���{���s��S�E�����E���j
            dataTable.Columns.Add("SupplierAddr3RF", typeof(string));	    //  �d����Z��3�i�Ԓn�j
            dataTable.Columns.Add("SupplierAddr4RF", typeof(string));	    //  �d����Z��4�i�A�p�[�g���́j
            dataTable.Columns.Add("SupplierTelNoRF", typeof(string));	    //  �d����d�b�ԍ�
            dataTable.Columns.Add("SupplierTelNo1RF", typeof(string));	    //  �d����d�b�ԍ�1
            dataTable.Columns.Add("SupplierTelNo2RF", typeof(string));	    //  �d����d�b�ԍ�2

            foreach (Supplier supplier in retList)
            {
                int checkstatus = DataCheck(supplier, condition);
                if (checkstatus == 0)
                {
                    DataRow dataRow = dataTable.NewRow();
                    // �Ǘ����_�R�[�h
                    StringBuilder tempSection = new StringBuilder();
                    for (int i = supplier.MngSectionCode.Trim().Length; i < 2; i++)
                    {
                        tempSection.Append("0");
                    }
                    tempSection.Append(supplier.MngSectionCode);
                    dataRow["MngSectionCodeRF"] = tempSection.ToString().Trim();
                    // �d����R�[�h
                    StringBuilder tempSuppCd = new StringBuilder();
                    for (int i = supplier.SupplierCd.ToString().Length; i < 6; i++)
                    {
                        tempSuppCd.Append("0");
                    }
                    tempSuppCd.Append(supplier.SupplierCd);
                    dataRow["SupplierCdRF"] = tempSuppCd.ToString().Trim();
                    // �d���於1
                    dataRow["SupplierNm1RF"] = supplier.SupplierNm1.Trim();
                    // �d���於2
                    dataRow["SupplierNm2RF"] = supplier.SupplierNm2.Trim();
                    // �d����X�֔ԍ�
                    dataRow["SupplierPostNoRF"] = supplier.SupplierPostNo.Trim();
                    // �d����Z��1�i�s���{���s��S�E�����E���j
                    dataRow["SupplierAddr1RF"] = supplier.SupplierAddr1.Trim();
                    // �d����Z��3�i�Ԓn�j
                    dataRow["SupplierAddr3RF"] = supplier.SupplierAddr3.Trim();
                    // �d����Z��4�i�A�p�[�g���́j
                    dataRow["SupplierAddr4RF"] = supplier.SupplierAddr4.Trim();
                    // �d����d�b�ԍ�
                    dataRow["SupplierTelNoRF"] = supplier.SupplierTelNo.Trim();
                    // �d����d�b�ԍ�1
                    dataRow["SupplierTelNo1RF"] = supplier.SupplierTelNo1.Trim();
                    // �d����d�b�ԍ�2
                    dataRow["SupplierTelNo2RF"] = supplier.SupplierTelNo2.Trim();
                    dataTable.Rows.Add(dataRow);
                }
            }
            #endregion
            _dataSet.Tables.Add(dataTable);
        }
        /// <summary>
        /// �������ʂ�ConvertToDataSet
        /// </summary>
        /// <param name="retList">��������</param>
        /// <remarks>
        /// <br>Note       : �������ʂ�ConvertToDataSet�ɍs���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void ConverToDataSetSectionInf(ArrayList retList)
        {
            // �f�[�^�Z�b�g�i�[�p�f�[�^�e�[�u��
            DataTable dataTable = new DataTable("SectionExp");

            // �J�����ǉ�
            # region �J�����ǉ�(CSV�f�[�^�p)
            dataTable.Columns.Add("SECTIONCODERF", typeof(string));	            //  ���_�R�[�h
            dataTable.Columns.Add("COMPANYNAME1RF", typeof(string));	        //  ���Ж���1
            dataTable.Columns.Add("COMPANYNAME2RF", typeof(string));	        //  ���Ж���2
            dataTable.Columns.Add("POSTNORF", typeof(string));	                //  �X�֔ԍ�
            dataTable.Columns.Add("ADDRESS1RF", typeof(string));	            //  �Z��1�i�s���{���s��S�E�����E���j
            dataTable.Columns.Add("ADDRESS3RF", typeof(string));	            //  �Z��3�i�Ԓn�j
            dataTable.Columns.Add("ADDRESS4RF", typeof(string));	            //  �Z��4�i�A�p�[�g���́j
            dataTable.Columns.Add("COMPANYTELNO1RF", typeof(string));	        //  ���Гd�b�ԍ�1
            dataTable.Columns.Add("COMPANYTELNO2RF", typeof(string));	        //  ���Гd�b�ԍ�2
            dataTable.Columns.Add("COMPANYTELNO3RF", typeof(string));	        //  ���Гd�b�ԍ�3

            foreach (PostSecInfoSetWork SectionInfCsvData in retList)
            {
                DataRow dataRow = dataTable.NewRow();
                // ���_�R�[�h
                StringBuilder tempSection = new StringBuilder();
                for (int i = SectionInfCsvData.SectionCode.Trim().Length; i < 2; i++)
                {
                    tempSection.Append("0");
                }
                tempSection.Append(SectionInfCsvData.SectionCode);
                dataRow["SECTIONCODERF"] = tempSection.ToString().Trim();
                // ���Ж���1
                dataRow["COMPANYNAME1RF"] = SectionInfCsvData.CompanyName1.Trim();
                // ���Ж���2
                dataRow["COMPANYNAME2RF"] = SectionInfCsvData.CompanyName2.Trim();
                // �X�֔ԍ�
                dataRow["POSTNORF"] = SectionInfCsvData.PostNo.Trim();
                // �Z��1�i�s���{���s��S�E�����E���j
                dataRow["ADDRESS1RF"] = SectionInfCsvData.Address1.Trim();
                // �Z��3�i�Ԓn�j
                dataRow["ADDRESS3RF"] = SectionInfCsvData.Address3.Trim();
                // �Z��4�i�A�p�[�g���́j
                dataRow["ADDRESS4RF"] = SectionInfCsvData.Address4.Trim();
                // ���Гd�b�ԍ�1
                dataRow["COMPANYTELNO1RF"] = SectionInfCsvData.CompanyTelNo1.Trim();
                // ���Гd�b�ԍ�2
                dataRow["COMPANYTELNO2RF"] = SectionInfCsvData.CompanyTelNo2.Trim();
                // ���Гd�b�ԍ�3
                dataRow["COMPANYTELNO3RF"] = SectionInfCsvData.CompanyTelNo3.Trim();
                dataTable.Rows.Add(dataRow);
            }
            #endregion
            _dataSet.Tables.Add(dataTable);
        }
        /// <summary>
        /// �������ʂ�ConvertToDataSet
        /// </summary>
        /// <param name="companyInf">��������</param>
        /// <remarks>
        /// <br>Note       : �������ʂ�ConvertToDataSet�ɍs���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void ConverToDataSetCompanyInf(CompanyInf companyInf)
        {
            // �f�[�^�Z�b�g�i�[�p�f�[�^�e�[�u��
            DataTable dataTable = new DataTable("CompanyExp");

            // �J�����ǉ�
            # region �J�����ǉ�(CSV�f�[�^�p)
            dataTable.Columns.Add("COMPANYNAME1RF", typeof(string));	    //  ���Ж���1
            dataTable.Columns.Add("COMPANYNAME2RF", typeof(string));	    //  ���Ж���2
            dataTable.Columns.Add("POSTNORF", typeof(string));	            //  �X�֔ԍ�
            dataTable.Columns.Add("ADDRESS1RF", typeof(string));	        //  �Z��1�i�s���{���s��S�E�����E���j
            dataTable.Columns.Add("ADDRESS3RF", typeof(string));	        //  �Z��3�i�Ԓn�j
            dataTable.Columns.Add("ADDRESS4RF", typeof(string));	        //  �Z��4�i�A�p�[�g���́j
            dataTable.Columns.Add("COMPANYTELNO1RF", typeof(string));	    //  ���Гd�b�ԍ�1
            dataTable.Columns.Add("COMPANYTELNO2RF", typeof(string));	    //  ���Гd�b�ԍ�2
            dataTable.Columns.Add("COMPANYTELNO3RF", typeof(string));	    //  ���Гd�b�ԍ�3
            if (companyInf.LogicalDeleteCode == 0)
            {
                DataRow dataRow = dataTable.NewRow();
                // ���Ж���1
                dataRow["COMPANYNAME1RF"] = companyInf.CompanyName1.Trim();
                // ���Ж���2
                dataRow["COMPANYNAME2RF"] = companyInf.CompanyName2.Trim();
                // �X�֔ԍ�
                dataRow["POSTNORF"] = companyInf.PostNo.Trim();
                // �Z��1�i�s���{���s��S�E�����E���j
                dataRow["ADDRESS1RF"] = companyInf.Address1.Trim();
                // �Z��3�i�Ԓn�j
                dataRow["ADDRESS3RF"] = companyInf.Address3.Trim();
                // �Z��4�i�A�p�[�g���́j
                dataRow["ADDRESS4RF"] = companyInf.Address4.Trim();
                // ���Гd�b�ԍ�1
                dataRow["COMPANYTELNO1RF"] = companyInf.CompanyTelNo1.Trim();
                // ���Гd�b�ԍ�2
                dataRow["COMPANYTELNO2RF"] = companyInf.CompanyTelNo2.Trim();
                // ���Гd�b�ԍ�3
                dataRow["COMPANYTELNO3RF"] = companyInf.CompanyTelNo3.Trim();

                dataTable.Rows.Add(dataRow);
            }

            #endregion
            _dataSet.Tables.Add(dataTable);
        }

        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="supplier">�d����f�[�^</param>
        /// <param name="condition">��������</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���o�������s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private int DataCheck(Supplier supplier, PostcardEnvelopeDMTextCndtn condition)
        {
            int status = 0;
            // �d����R�[�h
            int stSupplierCd = condition.St_SupplierCode;
            int edSupplierCd = condition.Ed_SupplierCode;

            if (stSupplierCd != 0 && supplier.SupplierCd < stSupplierCd)
            {

                status = -1;
                return status;

            }
            if (edSupplierCd != 0 && supplier.SupplierCd > edSupplierCd)
            {
                status = -1;
                return status;

            }


            // ���_�R�[�h
            if (!String.IsNullOrEmpty(supplier.MngSectionCode.Trim()))
            {
                int supplierSectionCd = System.Convert.ToInt32(supplier.MngSectionCode);
                if (!string.IsNullOrEmpty(condition.St_SectionCode) && supplierSectionCd < Int32.Parse(condition.St_SectionCode))
                {
                    status = -1;
                    return status;
                }
                if (!string.IsNullOrEmpty(condition.Ed_SectionCode) && supplierSectionCd > Int32.Parse(condition.Ed_SectionCode))
                {
                    status = -1;
                    return status;
                }
            }
            return status;
        }
        #endregion

    }
}
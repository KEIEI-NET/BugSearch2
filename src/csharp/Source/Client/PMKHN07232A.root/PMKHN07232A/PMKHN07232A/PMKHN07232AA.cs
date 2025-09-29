//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���_���}�X�^�i�G�N�X�|�[�g�j
// �v���O�����T�v   : ���_���}�X�^�i�G�N�X�|�[�g�j���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �� �� ��  2009/05/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���_���}�X�^�i�G�N�X�|�[�g�j�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���_���}�X�^�i�G�N�X�|�[�g�j�C���X�^���X�̍쐬���s���B</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2009.05.12</br>
    /// </remarks>
    public class SecExportSetAcs
    {
        #region �� Private Member
        private ISecInfoSetDB _iSecInfoSetDB = null;
        private const string PRINTSET_TABLE = "SectionExp";
        #endregion

        # region ��Constracter
        /// <summary>
        /// ���_���}�X�^�i�G�N�X�|�[�g�j�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���_���}�X�^�i�G�N�X�|�[�g�j�A�N�Z�X�N���X�B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public SecExportSetAcs()
        {
            this._iSecInfoSetDB = (ISecInfoSetDB)MediationSecInfoSetDB.GetSecInfoSetDB();
        }
        #endregion

        #region �� ���_���}�X�^��񌟍�
        /// <summary>
        /// ���_���}�X�^�f�[�^�擾����
        /// </summary>
        /// <param name="condition">��������</param>
        /// <param name="dataTable">�����f�[�^</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ���_���}�X�^�f�[�^�擾�������s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        public int Search(SecExportSetWork condition, out DataTable dataTable)
        {
            int status = 0;
            string message = "";
            dataTable = new DataTable(PRINTSET_TABLE);
            // DataTable��Columns��ǉ�����
            CreateDataTable(ref dataTable);

            SecInfoSetWork secInfoSetWork = new SecInfoSetWork();

            secInfoSetWork.EnterpriseCode = condition.EnterpriseCode;
            // XML�֕ϊ����A������̃o�C�i����
            byte[] parabyte = XmlByteSerializer.Serialize(secInfoSetWork);

            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;
            SecInfoSetWork[] al;
            byte[] retbyte;
            status = this._iSecInfoSetDB.Search(out retbyte, parabyte, 0, logicalMode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // XML�̓ǂݍ���
                al = (SecInfoSetWork[])XmlByteSerializer.Deserialize(retbyte, typeof(SecInfoSetWork[]));

                CompanyNmAcs companyNmAcs = new CompanyNmAcs();
                ArrayList companyList = null;
                int companystatus = 0;
                try
                {
                    companystatus = companyNmAcs.Search(out companyList, condition.EnterpriseCode);
                }
                catch (Exception e)
                {
                    message = e.Message;
                    status = 1000;
                }
                bool noCompanyFlag;
                if (companystatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL || companystatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND 
                    || companystatus == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    for (int i = 0; i < al.Length; i++)
                    {
                        noCompanyFlag = true;
                        SecInfoSetWork wkSecInfoSetWork = (SecInfoSetWork)al[i];
                        int checkstatus = DataCheck(wkSecInfoSetWork, condition);
                        if (checkstatus == 0)
                        {
                            foreach (CompanyNm companyNm in companyList)
                            {
                                if (wkSecInfoSetWork.CompanyNameCd1 == companyNm.CompanyNameCd)
                                {
                                    noCompanyFlag = false;
                                    ConverToDataSetWarehouseInf(wkSecInfoSetWork, companyNm, ref dataTable);
                                }
                            }
                            if (noCompanyFlag)
                            {
                                CompanyNm companyNm = new CompanyNm();
                                ConverToDataSetWarehouseInf(wkSecInfoSetWork, companyNm, ref dataTable);
                            }
                        }
                    }
                }
                else
                {
                    return companystatus;
                }

            }
            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            return status;
        }
        # endregion

        #region �� Private Methods
        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="secInfoSetWork">���_���f�[�^</param>
        /// <param name="condition">��������</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���o�������s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private int DataCheck(SecInfoSetWork secInfoSetWork, SecExportSetWork condition)
        {
            int status = 0;
            int sectionCd = Int32.Parse(secInfoSetWork.SectionCode.Trim());
            if (!String.IsNullOrEmpty(condition.SectionCodeSt.Trim()) && sectionCd < Int32.Parse(condition.SectionCodeSt.Trim()))
            {
                status = -1;
                return status;
            }
            if (!String.IsNullOrEmpty(condition.SectionCodeEd.Trim()) && sectionCd > Int32.Parse(condition.SectionCodeEd.Trim()))
            {
                status = -1;
                return status;
            }
            return status;
        }

        /// <summary>
        /// DataTable��Columns��ǉ�����
        /// </summary>
        /// <param name="dataTable">����DataTable</param>
        /// <remarks>
        /// <br>Note       : DataTable��Columns��ǉ�����B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private void CreateDataTable(ref DataTable dataTable)
        {
            dataTable.Columns.Add("SectionCodeRF", typeof(string));             //  ���_�R�[�h
            dataTable.Columns.Add("SectionGuideNmRF", typeof(string));	        //  ���_�K�C�h����
            dataTable.Columns.Add("SectionGuideSnmRF", typeof(string));	        //  ���_�K�C�h����
            dataTable.Columns.Add("IntroductionDate", typeof(string));	        //  �����N����
            dataTable.Columns.Add("SectWarehouseCd1RF", typeof(string));	    //  ���_�q�ɃR�[�h�P
            dataTable.Columns.Add("SectWarehouseCd2RF", typeof(string));	    //  ���_�q�ɃR�[�h�Q
            dataTable.Columns.Add("SectWarehouseCd3RF", typeof(string));	    //  ���_�q�ɃR�[�h�R

            dataTable.Columns.Add("CompanyNameCdRF", typeof(string));	        //  ���Ж��̃R�[�h
            dataTable.Columns.Add("CompanyName1RF", typeof(string));	        //  ���Ж��̂P
            dataTable.Columns.Add("CompanyName2RF", typeof(string));	        //  ���Ж��̂Q
            dataTable.Columns.Add("CompanyPrRF", typeof(string));	            //  ���Ђo�q��
            dataTable.Columns.Add("CompanyPrSentence2RF", typeof(string));	    //  ���Ђo�q���Q
            dataTable.Columns.Add("PostNoRF", typeof(string));	                //  �X�֔ԍ�
            dataTable.Columns.Add("Address1RF", typeof(string));	            //  �Z��1�i�s���{���s��S�E�����E���j
            dataTable.Columns.Add("Address3RF", typeof(string));	            //  �Z��3�i�Ԓn�j
            dataTable.Columns.Add("Address4RF", typeof(string));	            //  �Z��4�i�A�p�[�g���́j
            dataTable.Columns.Add("CompanyTelNo1RF", typeof(string));	        //  ���Гd�b�ԍ��P
            dataTable.Columns.Add("CompanyTelNo2RF", typeof(string));	        //  ���Гd�b�ԍ��Q
            dataTable.Columns.Add("CompanyTelNo3RF", typeof(string));	        //  ���Гd�b�ԍ��R
            dataTable.Columns.Add("CompanySetNote1RF", typeof(string));	        //  ���Аݒ�E�v�P
            dataTable.Columns.Add("CompanySetNote2RF", typeof(string));	        //  ���Аݒ�E�v�Q

            dataTable.Columns.Add("TransferGuidanceRF", typeof(string));	    //  ��s�U���ē���

            dataTable.Columns.Add("AccountNoInfo1RF", typeof(string));	        //  ��s����1
            dataTable.Columns.Add("AccountNoInfo2RF", typeof(string));	        //  ��s�����Q
            dataTable.Columns.Add("AccountNoInfo3RF", typeof(string));	        //  ��s�����R
            dataTable.Columns.Add("CompanyUrlRF", typeof(string));	            //  ����URL
        }

        /// <summary>
        /// �������ʂ�ConvertToDataTable
        /// </summary>
        /// <param name="wkSecInfoSetWork">��������</param>
        /// <param name="companyNm">��������</param>
        /// <param name="dataTable">����</param>
        /// <remarks>
        /// <br>Note       : �������ʂ�ConvertToDataTable�ɍs���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private void ConverToDataSetWarehouseInf(SecInfoSetWork wkSecInfoSetWork, CompanyNm companyNm, ref DataTable dataTable)
        {

            DataRow dataRow = dataTable.NewRow();

            dataRow["SectionCodeRF"] = AppendZero(wkSecInfoSetWork.SectionCode.Trim(), 2);
            dataRow["SectionGuideNmRF"] = GetSubString(wkSecInfoSetWork.SectionGuideNm, 6);
            dataRow["SectionGuideSnmRF"] = GetSubString(wkSecInfoSetWork.SectionGuideSnm, 10);
            if (wkSecInfoSetWork.IntroductionDate == DateTime.MinValue)
            {
                dataRow["IntroductionDate"] = DBNull.Value;
            }
            else
            {
                dataRow["IntroductionDate"] = TDateTime.DateTimeToLongDate("YYYYMMDD", wkSecInfoSetWork.IntroductionDate).ToString();
            }
            dataRow["SectWarehouseCd1RF"] = AppendStrZero(wkSecInfoSetWork.SectWarehouseCd1.Trim(), 4);
            dataRow["SectWarehouseCd2RF"] = AppendStrZero(wkSecInfoSetWork.SectWarehouseCd2.Trim(), 4);
            dataRow["SectWarehouseCd3RF"] = AppendStrZero(wkSecInfoSetWork.SectWarehouseCd3.Trim(), 4);

            if (companyNm.CompanyNameCd != 0)
            {
                dataRow["CompanyNameCdRF"] = AppendZero(companyNm.CompanyNameCd.ToString(), 4);
                dataRow["CompanyName1RF"] = GetSubString(companyNm.CompanyName1, 20);
                dataRow["CompanyName2RF"] = GetSubString(companyNm.CompanyName2, 20);
                dataRow["CompanyPrRF"] = GetSubString(companyNm.CompanyPr, 20);
                dataRow["CompanyPrSentence2RF"] = GetSubString(companyNm.CompanyPrSentence2, 20);
                dataRow["PostNoRF"] = GetSubString(companyNm.PostNo, 10);
                dataRow["Address1RF"] = GetSubString(companyNm.Address1, 30);
                dataRow["Address3RF"] = GetSubString(companyNm.Address3, 22);
                dataRow["Address4RF"] = GetSubString(companyNm.Address4, 30);
                dataRow["CompanyTelNo1RF"] = GetSubString(companyNm.CompanyTelNo1, 16);
                dataRow["CompanyTelNo2RF"] = GetSubString(companyNm.CompanyTelNo2, 16);
                dataRow["CompanyTelNo3RF"] = GetSubString(companyNm.CompanyTelNo3, 16);
                dataRow["CompanySetNote1RF"] = GetSubString(companyNm.CompanySetNote1, 20);
                dataRow["CompanySetNote2RF"] = GetSubString(companyNm.CompanySetNote2, 20);
                dataRow["TransferGuidanceRF"] = GetSubString(companyNm.TransferGuidance, 20);
                dataRow["AccountNoInfo1RF"] = GetSubString(companyNm.AccountNoInfo1, 30);
                dataRow["AccountNoInfo2RF"] = GetSubString(companyNm.AccountNoInfo2, 30);
                dataRow["AccountNoInfo3RF"] = GetSubString(companyNm.AccountNoInfo3, 30);
                dataRow["CompanyUrlRF"] = GetSubString(companyNm.CompanyUrl, 60);
            }

            dataTable.Rows.Add(dataRow);
        }

        /// <summary>
        /// AppendZero
        /// </summary>
        /// <param name="bfString">bfString</param>
        /// <param name="maxSize">��</param>
        /// <remarks>
        /// <br>Note       : AppendZero�s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string AppendZero(string bfString, int maxSize)
        {
            StringBuilder tempBuild = new StringBuilder();
            if (!String.IsNullOrEmpty(bfString.Trim()) && !bfString.Trim().Equals("0"))
            {
                for (int i = bfString.Length; i < maxSize; i++)
                {
                    tempBuild.Append("0");
                }
                tempBuild.Append(bfString);
            }
            return tempBuild.ToString().Trim();
        }

        /// <summary>
        /// GetSubString
        /// </summary>
        /// <param name="bfString">bfString</param>
        /// <param name="length">��</param>
        /// <remarks>
        /// <br>Note       : �������ʂ�ConvertToDataSet�ɍs���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string GetSubString(string bfString, int length)
        {
            string afString = "";
            if (bfString.Trim().Length > length)
            {
                afString = bfString.Substring(0, length);
            }
            else
            {
                afString = bfString;
            }
            return afString.Trim();
        }

        /// <summary>
        /// AppendZero
        /// </summary>
        /// <param name="bfString">bfString</param>
        /// <param name="maxSize">��</param>
        /// <remarks>
        /// <br>Note       : AppendZero�s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string AppendStrZero(string bfString, int maxSize)
        {
            StringBuilder tempBuild = new StringBuilder();
            if (String.IsNullOrEmpty(bfString.Trim()) || bfString.Trim().Length == 0)
            {
                for (int i = 0; i < maxSize; i++)
                {
                    tempBuild.Append("0");
                }
            }
            else
            {
                for (int i = bfString.Length; i < maxSize; i++)
                {
                    tempBuild.Append("0");
                }
                tempBuild.Append(bfString);
            }
            return tempBuild.ToString();
        }
        # endregion
    }
}

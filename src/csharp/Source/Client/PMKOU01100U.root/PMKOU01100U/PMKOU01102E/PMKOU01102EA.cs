using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SupplierCheckOrderCndtn
    /// <summary>
    ///                      �d���`�F�b�N�������o�����N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d���`�F�b�N�������o�����N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class SupplierCheckOrderCndtn
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�����敪</summary>
        /// <remarks>0:���� 1:����</remarks>
        private Int32 _procDiv;

        /// <summary>�`�[�敪</summary>
        /// <remarks>0:�S�� 1:�d�� 2:�ԕi 3:���� 4:�폜</remarks>
        private Int32 _slipDiv;

        /// <summary>�`�F�b�N�敪</summary>
        /// <remarks>0:�S�� 1:���`�F�b�N 2:�`�F�b�N�ς� </remarks>
        private Int32 _checkDiv;

        /// <summary>�J�n�d����</summary>
        /// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
        private Int32 _st_StockDate;

        /// <summary>�I���d����</summary>
        /// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
        private Int32 _ed_StockDate;

        /// <summary>�J�n���͓�</summary>
        /// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
        private Int32 _st_InputDay;

        /// <summary>�I�����͓�</summary>
        /// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
        private Int32 _ed_InputDay;

        /// <summary>�J�n�d���`�[�ԍ�</summary>
        /// <remarks>�����`�[�ԍ��A�d���`�[�ԍ��A���ד`�[�ԍ������˂�</remarks>
        private Int32 _st_SupplierSlipNo;

        /// <summary>�I���d���`�[�ԍ�</summary>
        /// <remarks>�����`�[�ԍ��A�d���`�[�ԍ��A���ד`�[�ԍ������˂�</remarks>
        private Int32 _ed_SupplierSlipNo;

        /// <summary>�J�n�����`�[�ԍ�</summary>
        /// <remarks>�d����`�[�ԍ��Ɏg�p����</remarks>
        private string _st_PartySaleSlipNum = "";

        /// <summary>�I�������`�[�ԍ�</summary>
        /// <remarks>�d����`�[�ԍ��Ɏg�p����</remarks>
        private string _ed_PartySaleSlipNum = "";

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";


        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  ProcDiv
        /// <summary>�����敪�v���p�e�B</summary>
        /// <value>0:���� 1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ProcDiv
        {
            get { return _procDiv; }
            set { _procDiv = value; }
        }

        /// public propaty name  :  SlipDiv
        /// <summary>�`�[�敪�v���p�e�B</summary>
        /// <value>0:�S�� 1:�d�� 2:�ԕi 3:���� 4:�폜</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipDiv
        {
            get { return _slipDiv; }
            set { _slipDiv = value; }
        }

        /// public propaty name  :  CheckDiv
        /// <summary>�`�F�b�N�敪�v���p�e�B</summary>
        /// <value>0:�S�� 1:���`�F�b�N 2:�`�F�b�N�ς� </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�F�b�N�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CheckDiv
        {
            get { return _checkDiv; }
            set { _checkDiv = value; }
        }

        /// public propaty name  :  St_StockDate
        /// <summary>�J�n�d�����v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�d�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_StockDate
        {
            get { return _st_StockDate; }
            set { _st_StockDate = value; }
        }

        /// public propaty name  :  Ed_StockDate
        /// <summary>�I���d�����v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���d�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_StockDate
        {
            get { return _ed_StockDate; }
            set { _ed_StockDate = value; }
        }

        /// public propaty name  :  St_InputDay
        /// <summary>�J�n���͓��v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���͓��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_InputDay
        {
            get { return _st_InputDay; }
            set { _st_InputDay = value; }
        }

        /// public propaty name  :  Ed_InputDay
        /// <summary>�I�����͓��v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����͓��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_InputDay
        {
            get { return _ed_InputDay; }
            set { _ed_InputDay = value; }
        }

        /// public propaty name  :  St_SupplierSlipNo
        /// <summary>�J�n�d���`�[�ԍ��v���p�e�B</summary>
        /// <value>�����`�[�ԍ��A�d���`�[�ԍ��A���ד`�[�ԍ������˂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�d���`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_SupplierSlipNo
        {
            get { return _st_SupplierSlipNo; }
            set { _st_SupplierSlipNo = value; }
        }

        /// public propaty name  :  Ed_SupplierSlipNo
        /// <summary>�I���d���`�[�ԍ��v���p�e�B</summary>
        /// <value>�����`�[�ԍ��A�d���`�[�ԍ��A���ד`�[�ԍ������˂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���d���`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_SupplierSlipNo
        {
            get { return _ed_SupplierSlipNo; }
            set { _ed_SupplierSlipNo = value; }
        }

        /// public propaty name  :  St_PartySaleSlipNum
        /// <summary>�J�n�����`�[�ԍ��v���p�e�B</summary>
        /// <value>�d����`�[�ԍ��Ɏg�p����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string St_PartySaleSlipNum
        {
            get { return _st_PartySaleSlipNum; }
            set { _st_PartySaleSlipNum = value; }
        }

        /// public propaty name  :  Ed_PartySaleSlipNum
        /// <summary>�I�������`�[�ԍ��v���p�e�B</summary>
        /// <value>�d����`�[�ԍ��Ɏg�p����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�������`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Ed_PartySaleSlipNum
        {
            get { return _ed_PartySaleSlipNum; }
            set { _ed_PartySaleSlipNum = value; }
        }

        /// public propaty name  :  EnterpriseName
        /// <summary>��Ɩ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��Ɩ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }


        /// <summary>
        /// �d���`�F�b�N�������o�����N���X�R���X�g���N�^
        /// </summary>
        /// <returns>SupplierCheckOrderCndtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SupplierCheckOrderCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SupplierCheckOrderCndtn()
        {
        }

        /// <summary>
        /// �d���`�F�b�N�������o�����N���X�R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="procDiv">�����敪(0:���� 1:����)</param>
        /// <param name="slipDiv">�`�[�敪(0:�S�� 1:�d�� 2:�ԕi 3:���� 4:�폜)</param>
        /// <param name="checkDiv">�`�F�b�N�敪(0:�S�� 1:���`�F�b�N 2:�`�F�b�N�ς� )</param>
        /// <param name="st_StockDate">�J�n�d����(YYYYMMDD�@�i�X�V�N�����j)</param>
        /// <param name="ed_StockDate">�I���d����(YYYYMMDD�@�i�X�V�N�����j)</param>
        /// <param name="st_InputDay">�J�n���͓�(YYYYMMDD�@�i�X�V�N�����j)</param>
        /// <param name="ed_InputDay">�I�����͓�(YYYYMMDD�@�i�X�V�N�����j)</param>
        /// <param name="st_SupplierSlipNo">�J�n�d���`�[�ԍ�(�����`�[�ԍ��A�d���`�[�ԍ��A���ד`�[�ԍ������˂�)</param>
        /// <param name="ed_SupplierSlipNo">�I���d���`�[�ԍ�(�����`�[�ԍ��A�d���`�[�ԍ��A���ד`�[�ԍ������˂�)</param>
        /// <param name="st_PartySaleSlipNum">�J�n�����`�[�ԍ�(�d����`�[�ԍ��Ɏg�p����)</param>
        /// <param name="ed_PartySaleSlipNum">�I�������`�[�ԍ�(�d����`�[�ԍ��Ɏg�p����)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <returns>SupplierCheckOrderCndtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SupplierCheckOrderCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SupplierCheckOrderCndtn(string enterpriseCode, string sectionCode, Int32 supplierCd, Int32 procDiv, Int32 slipDiv, Int32 checkDiv, Int32 st_StockDate, Int32 ed_StockDate, Int32 st_InputDay, Int32 ed_InputDay, Int32 st_SupplierSlipNo, Int32 ed_SupplierSlipNo, string st_PartySaleSlipNum, string ed_PartySaleSlipNum, string enterpriseName)
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
            this._supplierCd = supplierCd;
            this._procDiv = procDiv;
            this._slipDiv = slipDiv;
            this._checkDiv = checkDiv;
            this._st_StockDate = st_StockDate;
            this._ed_StockDate = ed_StockDate;
            this._st_InputDay = st_InputDay;
            this._ed_InputDay = ed_InputDay;
            this._st_SupplierSlipNo = st_SupplierSlipNo;
            this._ed_SupplierSlipNo = ed_SupplierSlipNo;
            this._st_PartySaleSlipNum = st_PartySaleSlipNum;
            this._ed_PartySaleSlipNum = ed_PartySaleSlipNum;
            this._enterpriseName = enterpriseName;

        }

        /// <summary>
        /// �d���`�F�b�N�������o�����N���X��������
        /// </summary>
        /// <returns>SupplierCheckOrderCndtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SupplierCheckOrderCndtn�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SupplierCheckOrderCndtn Clone()
        {
            return new SupplierCheckOrderCndtn(this._enterpriseCode, this._sectionCode, this._supplierCd, this._procDiv, this._slipDiv, this._checkDiv, this._st_StockDate, this._ed_StockDate, this._st_InputDay, this._ed_InputDay, this._st_SupplierSlipNo, this._ed_SupplierSlipNo, this._st_PartySaleSlipNum, this._ed_PartySaleSlipNum, this._enterpriseName);
        }

        /// <summary>
        /// �d���`�F�b�N�������o�����N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SupplierCheckOrderCndtn�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SupplierCheckOrderCndtn�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(SupplierCheckOrderCndtn target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.ProcDiv == target.ProcDiv)
                 && (this.SlipDiv == target.SlipDiv)
                 && (this.CheckDiv == target.CheckDiv)
                 && (this.St_StockDate == target.St_StockDate)
                 && (this.Ed_StockDate == target.Ed_StockDate)
                 && (this.St_InputDay == target.St_InputDay)
                 && (this.Ed_InputDay == target.Ed_InputDay)
                 && (this.St_SupplierSlipNo == target.St_SupplierSlipNo)
                 && (this.Ed_SupplierSlipNo == target.Ed_SupplierSlipNo)
                 && (this.St_PartySaleSlipNum == target.St_PartySaleSlipNum)
                 && (this.Ed_PartySaleSlipNum == target.Ed_PartySaleSlipNum)
                 && (this.EnterpriseName == target.EnterpriseName));
        }

        /// <summary>
        /// �d���`�F�b�N�������o�����N���X��r����
        /// </summary>
        /// <param name="supplierCheckOrderCndtn1">
        ///                    ��r����SupplierCheckOrderCndtn�N���X�̃C���X�^���X
        /// </param>
        /// <param name="supplierCheckOrderCndtn2">��r����SupplierCheckOrderCndtn�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SupplierCheckOrderCndtn�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(SupplierCheckOrderCndtn supplierCheckOrderCndtn1, SupplierCheckOrderCndtn supplierCheckOrderCndtn2)
        {
            return ((supplierCheckOrderCndtn1.EnterpriseCode == supplierCheckOrderCndtn2.EnterpriseCode)
                 && (supplierCheckOrderCndtn1.SectionCode == supplierCheckOrderCndtn2.SectionCode)
                 && (supplierCheckOrderCndtn1.SupplierCd == supplierCheckOrderCndtn2.SupplierCd)
                 && (supplierCheckOrderCndtn1.ProcDiv == supplierCheckOrderCndtn2.ProcDiv)
                 && (supplierCheckOrderCndtn1.SlipDiv == supplierCheckOrderCndtn2.SlipDiv)
                 && (supplierCheckOrderCndtn1.CheckDiv == supplierCheckOrderCndtn2.CheckDiv)
                 && (supplierCheckOrderCndtn1.St_StockDate == supplierCheckOrderCndtn2.St_StockDate)
                 && (supplierCheckOrderCndtn1.Ed_StockDate == supplierCheckOrderCndtn2.Ed_StockDate)
                 && (supplierCheckOrderCndtn1.St_InputDay == supplierCheckOrderCndtn2.St_InputDay)
                 && (supplierCheckOrderCndtn1.Ed_InputDay == supplierCheckOrderCndtn2.Ed_InputDay)
                 && (supplierCheckOrderCndtn1.St_SupplierSlipNo == supplierCheckOrderCndtn2.St_SupplierSlipNo)
                 && (supplierCheckOrderCndtn1.Ed_SupplierSlipNo == supplierCheckOrderCndtn2.Ed_SupplierSlipNo)
                 && (supplierCheckOrderCndtn1.St_PartySaleSlipNum == supplierCheckOrderCndtn2.St_PartySaleSlipNum)
                 && (supplierCheckOrderCndtn1.Ed_PartySaleSlipNum == supplierCheckOrderCndtn2.Ed_PartySaleSlipNum)
                 && (supplierCheckOrderCndtn1.EnterpriseName == supplierCheckOrderCndtn2.EnterpriseName));
        }
        /// <summary>
        /// �d���`�F�b�N�������o�����N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SupplierCheckOrderCndtn�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SupplierCheckOrderCndtn�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(SupplierCheckOrderCndtn target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.ProcDiv != target.ProcDiv) resList.Add("ProcDiv");
            if (this.SlipDiv != target.SlipDiv) resList.Add("SlipDiv");
            if (this.CheckDiv != target.CheckDiv) resList.Add("CheckDiv");
            if (this.St_StockDate != target.St_StockDate) resList.Add("St_StockDate");
            if (this.Ed_StockDate != target.Ed_StockDate) resList.Add("Ed_StockDate");
            if (this.St_InputDay != target.St_InputDay) resList.Add("St_InputDay");
            if (this.Ed_InputDay != target.Ed_InputDay) resList.Add("Ed_InputDay");
            if (this.St_SupplierSlipNo != target.St_SupplierSlipNo) resList.Add("St_SupplierSlipNo");
            if (this.Ed_SupplierSlipNo != target.Ed_SupplierSlipNo) resList.Add("Ed_SupplierSlipNo");
            if (this.St_PartySaleSlipNum != target.St_PartySaleSlipNum) resList.Add("St_PartySaleSlipNum");
            if (this.Ed_PartySaleSlipNum != target.Ed_PartySaleSlipNum) resList.Add("Ed_PartySaleSlipNum");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }

        /// <summary>
        /// �d���`�F�b�N�������o�����N���X��r����
        /// </summary>
        /// <param name="supplierCheckOrderCndtn1">��r����SupplierCheckOrderCndtn�N���X�̃C���X�^���X</param>
        /// <param name="supplierCheckOrderCndtn2">��r����SupplierCheckOrderCndtn�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SupplierCheckOrderCndtn�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(SupplierCheckOrderCndtn supplierCheckOrderCndtn1, SupplierCheckOrderCndtn supplierCheckOrderCndtn2)
        {
            ArrayList resList = new ArrayList();
            if (supplierCheckOrderCndtn1.EnterpriseCode != supplierCheckOrderCndtn2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (supplierCheckOrderCndtn1.SectionCode != supplierCheckOrderCndtn2.SectionCode) resList.Add("SectionCode");
            if (supplierCheckOrderCndtn1.SupplierCd != supplierCheckOrderCndtn2.SupplierCd) resList.Add("SupplierCd");
            if (supplierCheckOrderCndtn1.ProcDiv != supplierCheckOrderCndtn2.ProcDiv) resList.Add("ProcDiv");
            if (supplierCheckOrderCndtn1.SlipDiv != supplierCheckOrderCndtn2.SlipDiv) resList.Add("SlipDiv");
            if (supplierCheckOrderCndtn1.CheckDiv != supplierCheckOrderCndtn2.CheckDiv) resList.Add("CheckDiv");
            if (supplierCheckOrderCndtn1.St_StockDate != supplierCheckOrderCndtn2.St_StockDate) resList.Add("St_StockDate");
            if (supplierCheckOrderCndtn1.Ed_StockDate != supplierCheckOrderCndtn2.Ed_StockDate) resList.Add("Ed_StockDate");
            if (supplierCheckOrderCndtn1.St_InputDay != supplierCheckOrderCndtn2.St_InputDay) resList.Add("St_InputDay");
            if (supplierCheckOrderCndtn1.Ed_InputDay != supplierCheckOrderCndtn2.Ed_InputDay) resList.Add("Ed_InputDay");
            if (supplierCheckOrderCndtn1.St_SupplierSlipNo != supplierCheckOrderCndtn2.St_SupplierSlipNo) resList.Add("St_SupplierSlipNo");
            if (supplierCheckOrderCndtn1.Ed_SupplierSlipNo != supplierCheckOrderCndtn2.Ed_SupplierSlipNo) resList.Add("Ed_SupplierSlipNo");
            if (supplierCheckOrderCndtn1.St_PartySaleSlipNum != supplierCheckOrderCndtn2.St_PartySaleSlipNum) resList.Add("St_PartySaleSlipNum");
            if (supplierCheckOrderCndtn1.Ed_PartySaleSlipNum != supplierCheckOrderCndtn2.Ed_PartySaleSlipNum) resList.Add("Ed_PartySaleSlipNum");
            if (supplierCheckOrderCndtn1.EnterpriseName != supplierCheckOrderCndtn2.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }
    }
}

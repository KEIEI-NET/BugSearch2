//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d�����f�[�^���o�����N���X
// �v���O�����T�v   : �t�n�d�����f�[�^���o�����̒�`
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-00 �쐬�S�� : ���� �T��
// �� �� ��  2008/05/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : yangmj
// �� �� ��  2012/09/20  �C�����e : redmine#32404�̑Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   UOESendProcCndtnPara
    /// <summary>
    ///                      UOE���M�������o�����N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   UOE���M�������o�����N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/12/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class UOESendProcCndtnPara
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        //-----ADD YANGMJ 2012/09/20 REDMINE#32404 ----->>>>>
        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";
        //-----ADD YANGMJ 2012/09/20 REDMINE#32404 -----<<<<<

        /// <summary>���W�ԍ�</summary>
        private Int32 _cashRegisterNo;

        /// <summary>�V�X�e���敪</summary>
        /// <remarks>0:����� 1:�`�� 2:���� 3�F�ꊇ 4�F��[</remarks>
        private Int32 _systemDivCd;

        /// <summary>�J�nUOE�����ԍ�</summary>
        private Int32 _st_UOESalesOrderNo;

        /// <summary>�I��UOE�����ԍ�</summary>
        private Int32 _ed_UOESalesOrderNo;

        /// <summary>�J�n���͓�</summary>
        /// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
        private DateTime _st_InputDay;

        /// <summary>�I�����͓�</summary>
        /// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
        private DateTime _ed_InputDay;

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>UOE������R�[�h</summary>
        private Int32 _uOESupplierCd;

        /// <summary>�J�n�I�����C���ԍ�</summary>
        private Int32 _st_OnlineNo;

        /// <summary>�I���I�����C���ԍ�</summary>
        private Int32 _ed_OnlineNo;

        /// <summary>�f�[�^���M�敪</summary>
        private Int32[] _dataSendCodes;

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

        //-----ADD YANGMJ 2012/09/20 REDMINE#32404 ----->>>>>
        /// public propaty name  :  EnterpriseCode
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
        //-----ADD YANGMJ 2012/09/20 REDMINE#32404 -----<<<<<

        /// public propaty name  :  CashRegisterNo
        /// <summary>���W�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���W�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CashRegisterNo
        {
            get { return _cashRegisterNo; }
            set { _cashRegisterNo = value; }
        }

        /// public propaty name  :  SystemDivCd
        /// <summary>�V�X�e���敪�v���p�e�B</summary>
        /// <value>0:����� 1:�`�� 2:���� 3�F�ꊇ 4�F��[</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V�X�e���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SystemDivCd
        {
            get { return _systemDivCd; }
            set { _systemDivCd = value; }
        }

        /// public propaty name  :  St_UOESalesOrderNo
        /// <summary>�J�nUOE�����ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�nUOE�����ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_UOESalesOrderNo
        {
            get { return _st_UOESalesOrderNo; }
            set { _st_UOESalesOrderNo = value; }
        }

        /// public propaty name  :  Ed_UOESalesOrderNo
        /// <summary>�I��UOE�����ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I��UOE�����ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_UOESalesOrderNo
        {
            get { return _ed_UOESalesOrderNo; }
            set { _ed_UOESalesOrderNo = value; }
        }

        /// public propaty name  :  St_InputDay
        /// <summary>�J�n���͓��v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���͓��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime St_InputDay
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
        public DateTime Ed_InputDay
        {
            get { return _ed_InputDay; }
            set { _ed_InputDay = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  UOESupplierCd
        /// <summary>UOE������R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESupplierCd
        {
            get { return _uOESupplierCd; }
            set { _uOESupplierCd = value; }
        }

        /// public propaty name  :  St_OnlineNo
        /// <summary>�J�n�I�����C���ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�I�����C���ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_OnlineNo
        {
            get { return _st_OnlineNo; }
            set { _st_OnlineNo = value; }
        }

        /// public propaty name  :  Ed_OnlineNo
        /// <summary>�I���I�����C���ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���I�����C���ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_OnlineNo
        {
            get { return _ed_OnlineNo; }
            set { _ed_OnlineNo = value; }
        }

        /// public propaty name  :  DataSendCodes
        /// <summary>�f�[�^���M�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^���M�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32[] DataSendCodes
        {
            get { return _dataSendCodes; }
            set { _dataSendCodes = value; }
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
        /// UOE���M�������o�����N���X�R���X�g���N�^
        /// </summary>
        /// <returns>UOESendProcCndtnPara�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOESendProcCndtnPara�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UOESendProcCndtnPara()
        {
        }

        /// <summary>
        /// UOE���M�������o�����N���X�R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="enterpriseCode">���_�R�[�h</param>
        /// <param name="cashRegisterNo">���W�ԍ�</param>
        /// <param name="systemDivCd">�V�X�e���敪(0:����� 1:�`�� 2:���� 3�F�ꊇ 4�F��[)</param>
        /// <param name="st_UOESalesOrderNo">�J�nUOE�����ԍ�</param>
        /// <param name="ed_UOESalesOrderNo">�I��UOE�����ԍ�</param>
        /// <param name="st_InputDay">�J�n���͓�(YYYYMMDD�@�i�X�V�N�����j)</param>
        /// <param name="ed_InputDay">�I�����͓�(YYYYMMDD�@�i�X�V�N�����j)</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="uOESupplierCd">UOE������R�[�h</param>
        /// <param name="st_OnlineNo">�J�n�I�����C���ԍ�</param>
        /// <param name="ed_OnlineNo">�I���I�����C���ԍ�</param>
        /// <param name="dataSendCodes">�f�[�^���M�敪</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <returns>UOESendProcCndtnPara�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOESendProcCndtnPara�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        //public UOESendProcCndtnPara(string enterpriseCode, Int32 cashRegisterNo, Int32 systemDivCd, Int32 st_UOESalesOrderNo, Int32 ed_UOESalesOrderNo, DateTime st_InputDay, DateTime ed_InputDay, Int32 customerCode, Int32 uOESupplierCd, Int32 st_OnlineNo, Int32 ed_OnlineNo, Int32[] dataSendCodes, string enterpriseName)// DEL YANGMJ 2012/09/20 REDMINE#32404
        public UOESendProcCndtnPara(string enterpriseCode, string sectionCode, Int32 cashRegisterNo, Int32 systemDivCd, Int32 st_UOESalesOrderNo, Int32 ed_UOESalesOrderNo, DateTime st_InputDay, DateTime ed_InputDay, Int32 customerCode, Int32 uOESupplierCd, Int32 st_OnlineNo, Int32 ed_OnlineNo, Int32[] dataSendCodes, string enterpriseName)// ADD YANGMJ 2012/09/20 REDMINE#32404
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;// ADD YANGMJ 2012/09/20 REDMINE#32404
            this._cashRegisterNo = cashRegisterNo;
            this._systemDivCd = systemDivCd;
            this._st_UOESalesOrderNo = st_UOESalesOrderNo;
            this._ed_UOESalesOrderNo = ed_UOESalesOrderNo;
            this._st_InputDay = st_InputDay;
            this._ed_InputDay = ed_InputDay;
            this._customerCode = customerCode;
            this._uOESupplierCd = uOESupplierCd;
            this._st_OnlineNo = st_OnlineNo;
            this._ed_OnlineNo = ed_OnlineNo;
            this._dataSendCodes = dataSendCodes;
            this._enterpriseName = enterpriseName;

        }

        /// <summary>
        /// UOE���M�������o�����N���X��������
        /// </summary>
        /// <returns>UOESendProcCndtnPara�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����UOESendProcCndtnPara�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UOESendProcCndtnPara Clone()
        {
            //return new UOESendProcCndtnPara(this._enterpriseCode, this._cashRegisterNo, this._systemDivCd, this._st_UOESalesOrderNo, this._ed_UOESalesOrderNo, this._st_InputDay, this._ed_InputDay, this._customerCode, this._uOESupplierCd, this._st_OnlineNo, this._ed_OnlineNo, this._dataSendCodes, this._enterpriseName);// DEL YANGMJ 2012/09/20 REDMINE#32404
            return new UOESendProcCndtnPara(this._enterpriseCode, this._sectionCode, this._cashRegisterNo, this._systemDivCd, this._st_UOESalesOrderNo, this._ed_UOESalesOrderNo, this._st_InputDay, this._ed_InputDay, this._customerCode, this._uOESupplierCd, this._st_OnlineNo, this._ed_OnlineNo, this._dataSendCodes, this._enterpriseName);// ADD YANGMJ 2012/09/20 REDMINE#32404
        }

        /// <summary>
        /// UOE���M�������o�����N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�UOESendProcCndtnPara�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOESendProcCndtnPara�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(UOESendProcCndtnPara target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                && (this.SectionCode == target.SectionCode)// ADD YANGMJ 2012/09/20 REDMINE#32404
                 && (this.CashRegisterNo == target.CashRegisterNo)
                 && (this.SystemDivCd == target.SystemDivCd)
                 && (this.St_UOESalesOrderNo == target.St_UOESalesOrderNo)
                 && (this.Ed_UOESalesOrderNo == target.Ed_UOESalesOrderNo)
                 && (this.St_InputDay == target.St_InputDay)
                 && (this.Ed_InputDay == target.Ed_InputDay)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.UOESupplierCd == target.UOESupplierCd)
                 && (this.St_OnlineNo == target.St_OnlineNo)
                 && (this.Ed_OnlineNo == target.Ed_OnlineNo)
                 && (this.DataSendCodes == target.DataSendCodes)
                 && (this.EnterpriseName == target.EnterpriseName));
        }

        /// <summary>
        /// UOE���M�������o�����N���X��r����
        /// </summary>
        /// <param name="uOESendProcCndtnPara1">
        ///                    ��r����UOESendProcCndtnPara�N���X�̃C���X�^���X
        /// </param>
        /// <param name="uOESendProcCndtnPara2">��r����UOESendProcCndtnPara�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOESendProcCndtnPara�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(UOESendProcCndtnPara uOESendProcCndtnPara1, UOESendProcCndtnPara uOESendProcCndtnPara2)
        {
            return ((uOESendProcCndtnPara1.EnterpriseCode == uOESendProcCndtnPara2.EnterpriseCode)
                && (uOESendProcCndtnPara1.SectionCode == uOESendProcCndtnPara2.SectionCode)// ADD YANGMJ 2012/09/20 REDMINE#32404
                 && (uOESendProcCndtnPara1.CashRegisterNo == uOESendProcCndtnPara2.CashRegisterNo)
                 && (uOESendProcCndtnPara1.SystemDivCd == uOESendProcCndtnPara2.SystemDivCd)
                 && (uOESendProcCndtnPara1.St_UOESalesOrderNo == uOESendProcCndtnPara2.St_UOESalesOrderNo)
                 && (uOESendProcCndtnPara1.Ed_UOESalesOrderNo == uOESendProcCndtnPara2.Ed_UOESalesOrderNo)
                 && (uOESendProcCndtnPara1.St_InputDay == uOESendProcCndtnPara2.St_InputDay)
                 && (uOESendProcCndtnPara1.Ed_InputDay == uOESendProcCndtnPara2.Ed_InputDay)
                 && (uOESendProcCndtnPara1.CustomerCode == uOESendProcCndtnPara2.CustomerCode)
                 && (uOESendProcCndtnPara1.UOESupplierCd == uOESendProcCndtnPara2.UOESupplierCd)
                 && (uOESendProcCndtnPara1.St_OnlineNo == uOESendProcCndtnPara2.St_OnlineNo)
                 && (uOESendProcCndtnPara1.Ed_OnlineNo == uOESendProcCndtnPara2.Ed_OnlineNo)
                 && (uOESendProcCndtnPara1.DataSendCodes == uOESendProcCndtnPara2.DataSendCodes)
                 && (uOESendProcCndtnPara1.EnterpriseName == uOESendProcCndtnPara2.EnterpriseName));
        }
        /// <summary>
        /// UOE���M�������o�����N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�UOESendProcCndtnPara�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOESendProcCndtnPara�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(UOESendProcCndtnPara target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");// ADD YANGMJ 2012/09/20 REDMINE#32404
            if (this.CashRegisterNo != target.CashRegisterNo) resList.Add("CashRegisterNo");
            if (this.SystemDivCd != target.SystemDivCd) resList.Add("SystemDivCd");
            if (this.St_UOESalesOrderNo != target.St_UOESalesOrderNo) resList.Add("St_UOESalesOrderNo");
            if (this.Ed_UOESalesOrderNo != target.Ed_UOESalesOrderNo) resList.Add("Ed_UOESalesOrderNo");
            if (this.St_InputDay != target.St_InputDay) resList.Add("St_InputDay");
            if (this.Ed_InputDay != target.Ed_InputDay) resList.Add("Ed_InputDay");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.UOESupplierCd != target.UOESupplierCd) resList.Add("UOESupplierCd");
            if (this.St_OnlineNo != target.St_OnlineNo) resList.Add("St_OnlineNo");
            if (this.Ed_OnlineNo != target.Ed_OnlineNo) resList.Add("Ed_OnlineNo");
            if (this.DataSendCodes != target.DataSendCodes) resList.Add("DataSendCodes");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }

        /// <summary>
        /// UOE���M�������o�����N���X��r����
        /// </summary>
        /// <param name="uOESendProcCndtnPara1">��r����UOESendProcCndtnPara�N���X�̃C���X�^���X</param>
        /// <param name="uOESendProcCndtnPara2">��r����UOESendProcCndtnPara�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOESendProcCndtnPara�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(UOESendProcCndtnPara uOESendProcCndtnPara1, UOESendProcCndtnPara uOESendProcCndtnPara2)
        {
            ArrayList resList = new ArrayList();
            if (uOESendProcCndtnPara1.EnterpriseCode != uOESendProcCndtnPara2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (uOESendProcCndtnPara1.SectionCode != uOESendProcCndtnPara2.SectionCode) resList.Add("SectionCode");// ADD YANGMJ 2012/09/20 REDMINE#32404
            if (uOESendProcCndtnPara1.CashRegisterNo != uOESendProcCndtnPara2.CashRegisterNo) resList.Add("CashRegisterNo");
            if (uOESendProcCndtnPara1.SystemDivCd != uOESendProcCndtnPara2.SystemDivCd) resList.Add("SystemDivCd");
            if (uOESendProcCndtnPara1.St_UOESalesOrderNo != uOESendProcCndtnPara2.St_UOESalesOrderNo) resList.Add("St_UOESalesOrderNo");
            if (uOESendProcCndtnPara1.Ed_UOESalesOrderNo != uOESendProcCndtnPara2.Ed_UOESalesOrderNo) resList.Add("Ed_UOESalesOrderNo");
            if (uOESendProcCndtnPara1.St_InputDay != uOESendProcCndtnPara2.St_InputDay) resList.Add("St_InputDay");
            if (uOESendProcCndtnPara1.Ed_InputDay != uOESendProcCndtnPara2.Ed_InputDay) resList.Add("Ed_InputDay");
            if (uOESendProcCndtnPara1.CustomerCode != uOESendProcCndtnPara2.CustomerCode) resList.Add("CustomerCode");
            if (uOESendProcCndtnPara1.UOESupplierCd != uOESendProcCndtnPara2.UOESupplierCd) resList.Add("UOESupplierCd");
            if (uOESendProcCndtnPara1.St_OnlineNo != uOESendProcCndtnPara2.St_OnlineNo) resList.Add("St_OnlineNo");
            if (uOESendProcCndtnPara1.Ed_OnlineNo != uOESendProcCndtnPara2.Ed_OnlineNo) resList.Add("Ed_OnlineNo");
            if (uOESendProcCndtnPara1.DataSendCodes != uOESendProcCndtnPara2.DataSendCodes) resList.Add("DataSendCodes");
            if (uOESendProcCndtnPara1.EnterpriseName != uOESendProcCndtnPara2.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }
    }
}

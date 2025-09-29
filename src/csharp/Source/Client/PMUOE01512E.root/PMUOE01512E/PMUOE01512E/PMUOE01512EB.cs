//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �g���^��������
// �v���O�����T�v   : �g���^�����������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10507391-00 �쐬�S�� : 杍^
// �� �� ��  2009/12/31  �C�����e : �V�K�쐬
//                                  �g���^�d�q�J�^���O�Ƃ̘A�g�p�f�[�^�Ƃ��āAUOE�����f�[�^���甭�����M�f�[�^�̍쐬���s��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   InpHedDisplay
    /// <summary>
    ///                      Hed��ʓ��̓N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   Hed��ʓ��̓N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/12/31  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class InpHedDisplay
    {
        /// <summary>�I�����C���ԍ�</summary>
        private Int32 _onlineNo;

        /// <summary>UOE������R�[�h</summary>
        private Int32 _uOESupplierCd;

        /// <summary>UOE�����於��</summary>
        private string _uOESupplierName = "";

        /// <summary>UOE�[�i�敪</summary>
        private string _uOEDeliGoodsDiv = "";

        /// <summary>�[�i�敪����</summary>
        private string _deliveredGoodsDivNm = "";

        /// <summary>�t�H���[�[�i�敪</summary>
        private string _followDeliGoodsDiv = "";

        /// <summary>�t�H���[�[�i�敪����</summary>
        private string _followDeliGoodsDivNm = "";

        /// <summary>UOE�w�苒�_</summary>
        private string _uOEResvdSection = "";

        /// <summary>UOE�w�苒�_����</summary>
        private string _uOEResvdSectionNm = "";

        /// <summary>�]�ƈ��R�[�h</summary>
        /// <remarks>�˗��҃R�[�h</remarks>
        private string _employeeCode = "";

        /// <summary>�]�ƈ�����</summary>
        /// <remarks>�˗��Җ���</remarks>
        private string _employeeName = "";

        /// <summary>�t�n�d���}�[�N�P</summary>
        private string _uoeRemark1 = "";

        /// <summary>�t�n�d���}�[�N�Q</summary>
        private string _uoeRemark2 = "";

        /// <summary>�Ɩ��敪</summary>
        private Int32 _businessCode;

        /// <summary>�I�����C���s�ԍ�</summary>
        private Int32 _onlineRowNo;

        /// <summary>�Ɩ��敪����</summary>
        private string _businessName = "";


        /// public propaty name  :  OnlineNo
        /// <summary>�I�����C���ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����C���ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OnlineNo
        {
            get { return _onlineNo; }
            set { _onlineNo = value; }
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

        /// public propaty name  :  UOESupplierName
        /// <summary>UOE�����於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�����於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOESupplierName
        {
            get { return _uOESupplierName; }
            set { _uOESupplierName = value; }
        }

        /// public propaty name  :  UOEDeliGoodsDiv
        /// <summary>UOE�[�i�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�[�i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEDeliGoodsDiv
        {
            get { return _uOEDeliGoodsDiv; }
            set { _uOEDeliGoodsDiv = value; }
        }

        /// public propaty name  :  DeliveredGoodsDivNm
        /// <summary>�[�i�敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DeliveredGoodsDivNm
        {
            get { return _deliveredGoodsDivNm; }
            set { _deliveredGoodsDivNm = value; }
        }

        /// public propaty name  :  FollowDeliGoodsDiv
        /// <summary>�t�H���[�[�i�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�H���[�[�i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FollowDeliGoodsDiv
        {
            get { return _followDeliGoodsDiv; }
            set { _followDeliGoodsDiv = value; }
        }

        /// public propaty name  :  FollowDeliGoodsDivNm
        /// <summary>�t�H���[�[�i�敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�H���[�[�i�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FollowDeliGoodsDivNm
        {
            get { return _followDeliGoodsDivNm; }
            set { _followDeliGoodsDivNm = value; }
        }

        /// public propaty name  :  UOEResvdSection
        /// <summary>UOE�w�苒�_�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�w�苒�_�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEResvdSection
        {
            get { return _uOEResvdSection; }
            set { _uOEResvdSection = value; }
        }

        /// public propaty name  :  UOEResvdSectionNm
        /// <summary>UOE�w�苒�_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�w�苒�_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEResvdSectionNm
        {
            get { return _uOEResvdSectionNm; }
            set { _uOEResvdSectionNm = value; }
        }

        /// public propaty name  :  EmployeeCode
        /// <summary>�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�˗��҃R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        /// public propaty name  :  EmployeeName
        /// <summary>�]�ƈ����̃v���p�e�B</summary>
        /// <value>�˗��Җ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; }
        }

        /// public propaty name  :  UoeRemark1
        /// <summary>�t�n�d���}�[�N�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�n�d���}�[�N�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UoeRemark1
        {
            get { return _uoeRemark1; }
            set { _uoeRemark1 = value; }
        }

        /// public propaty name  :  UoeRemark2
        /// <summary>�t�n�d���}�[�N�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�n�d���}�[�N�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UoeRemark2
        {
            get { return _uoeRemark2; }
            set { _uoeRemark2 = value; }
        }

        /// public propaty name  :  BusinessCode
        /// <summary>�Ɩ��敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ɩ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BusinessCode
        {
            get { return _businessCode; }
            set { _businessCode = value; }
        }

        /// public propaty name  :  OnlineRowNo
        /// <summary>�I�����C���s�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����C���s�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OnlineRowNo
        {
            get { return _onlineRowNo; }
            set { _onlineRowNo = value; }
        }

        /// public propaty name  :  BusinessName
        /// <summary>�Ɩ��敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ɩ��敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BusinessName
        {
            get { return _businessName; }
            set { _businessName = value; }
        }


        /// <summary>
        /// Hed��ʓ��̓N���X�R���X�g���N�^
        /// </summary>
        /// <returns>InpHedDisplay�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InpHedDisplay�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public InpHedDisplay()
        {
        }

        /// <summary>
        /// Hed��ʓ��̓N���X�R���X�g���N�^
        /// </summary>
        /// <param name="onlineNo">�I�����C���ԍ�</param>
        /// <param name="uOESupplierCd">UOE������R�[�h</param>
        /// <param name="uOESupplierName">UOE�����於��</param>
        /// <param name="uOEDeliGoodsDiv">UOE�[�i�敪</param>
        /// <param name="deliveredGoodsDivNm">�[�i�敪����</param>
        /// <param name="followDeliGoodsDiv">�t�H���[�[�i�敪</param>
        /// <param name="followDeliGoodsDivNm">�t�H���[�[�i�敪����</param>
        /// <param name="uOEResvdSection">UOE�w�苒�_</param>
        /// <param name="uOEResvdSectionNm">UOE�w�苒�_����</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h(�˗��҃R�[�h)</param>
        /// <param name="employeeName">�]�ƈ�����(�˗��Җ���)</param>
        /// <param name="uoeRemark1">�t�n�d���}�[�N�P</param>
        /// <param name="uoeRemark2">�t�n�d���}�[�N�Q</param>
        /// <param name="businessCode">�Ɩ��敪</param>
        /// <param name="onlineRowNo">�I�����C���s�ԍ�</param>
        /// <param name="businessName">�Ɩ��敪����</param>
        /// <returns>InpHedDisplay�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InpHedDisplay�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public InpHedDisplay(Int32 onlineNo, Int32 uOESupplierCd, string uOESupplierName, string uOEDeliGoodsDiv, string deliveredGoodsDivNm, string followDeliGoodsDiv, string followDeliGoodsDivNm, string uOEResvdSection, string uOEResvdSectionNm, string employeeCode, string employeeName, string uoeRemark1, string uoeRemark2, Int32 businessCode, Int32 onlineRowNo, string businessName)
        {
            this._onlineNo = onlineNo;
            this._uOESupplierCd = uOESupplierCd;
            this._uOESupplierName = uOESupplierName;
            this._uOEDeliGoodsDiv = uOEDeliGoodsDiv;
            this._deliveredGoodsDivNm = deliveredGoodsDivNm;
            this._followDeliGoodsDiv = followDeliGoodsDiv;
            this._followDeliGoodsDivNm = followDeliGoodsDivNm;
            this._uOEResvdSection = uOEResvdSection;
            this._uOEResvdSectionNm = uOEResvdSectionNm;
            this._employeeCode = employeeCode;
            this._employeeName = employeeName;
            this._uoeRemark1 = uoeRemark1;
            this._uoeRemark2 = uoeRemark2;
            this._businessCode = businessCode;
            this._onlineRowNo = onlineRowNo;
            this._businessName = businessName;

        }

        /// <summary>
        /// Hed��ʓ��̓N���X��������
        /// </summary>
        /// <returns>InpHedDisplay�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����InpHedDisplay�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public InpHedDisplay Clone()
        {
            return new InpHedDisplay(this._onlineNo, this._uOESupplierCd, this._uOESupplierName, this._uOEDeliGoodsDiv, this._deliveredGoodsDivNm, this._followDeliGoodsDiv, this._followDeliGoodsDivNm, this._uOEResvdSection, this._uOEResvdSectionNm, this._employeeCode, this._employeeName, this._uoeRemark1, this._uoeRemark2, this._businessCode, this._onlineRowNo, this._businessName);
        }

        /// <summary>
        /// Hed��ʓ��̓N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�InpHedDisplay�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InpHedDisplay�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(InpHedDisplay target)
        {
            return ((this.OnlineNo == target.OnlineNo)
                 && (this.UOESupplierCd == target.UOESupplierCd)
                 && (this.UOESupplierName == target.UOESupplierName)
                 && (this.UOEDeliGoodsDiv == target.UOEDeliGoodsDiv)
                 && (this.DeliveredGoodsDivNm == target.DeliveredGoodsDivNm)
                 && (this.FollowDeliGoodsDiv == target.FollowDeliGoodsDiv)
                 && (this.FollowDeliGoodsDivNm == target.FollowDeliGoodsDivNm)
                 && (this.UOEResvdSection == target.UOEResvdSection)
                 && (this.UOEResvdSectionNm == target.UOEResvdSectionNm)
                 && (this.EmployeeCode == target.EmployeeCode)
                 && (this.EmployeeName == target.EmployeeName)
                 && (this.UoeRemark1 == target.UoeRemark1)
                 && (this.UoeRemark2 == target.UoeRemark2)
                 && (this.BusinessCode == target.BusinessCode)
                 && (this.OnlineRowNo == target.OnlineRowNo)
                 && (this.BusinessName == target.BusinessName));
        }

        /// <summary>
        /// Hed��ʓ��̓N���X��r����
        /// </summary>
        /// <param name="inpHedDisplay1">
        ///                    ��r����InpHedDisplay�N���X�̃C���X�^���X
        /// </param>
        /// <param name="inpHedDisplay2">��r����InpHedDisplay�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InpHedDisplay�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(InpHedDisplay inpHedDisplay1, InpHedDisplay inpHedDisplay2)
        {
            return ((inpHedDisplay1.OnlineNo == inpHedDisplay2.OnlineNo)
                 && (inpHedDisplay1.UOESupplierCd == inpHedDisplay2.UOESupplierCd)
                 && (inpHedDisplay1.UOESupplierName == inpHedDisplay2.UOESupplierName)
                 && (inpHedDisplay1.UOEDeliGoodsDiv == inpHedDisplay2.UOEDeliGoodsDiv)
                 && (inpHedDisplay1.DeliveredGoodsDivNm == inpHedDisplay2.DeliveredGoodsDivNm)
                 && (inpHedDisplay1.FollowDeliGoodsDiv == inpHedDisplay2.FollowDeliGoodsDiv)
                 && (inpHedDisplay1.FollowDeliGoodsDivNm == inpHedDisplay2.FollowDeliGoodsDivNm)
                 && (inpHedDisplay1.UOEResvdSection == inpHedDisplay2.UOEResvdSection)
                 && (inpHedDisplay1.UOEResvdSectionNm == inpHedDisplay2.UOEResvdSectionNm)
                 && (inpHedDisplay1.EmployeeCode == inpHedDisplay2.EmployeeCode)
                 && (inpHedDisplay1.EmployeeName == inpHedDisplay2.EmployeeName)
                 && (inpHedDisplay1.UoeRemark1 == inpHedDisplay2.UoeRemark1)
                 && (inpHedDisplay1.UoeRemark2 == inpHedDisplay2.UoeRemark2)
                 && (inpHedDisplay1.BusinessCode == inpHedDisplay2.BusinessCode)
                 && (inpHedDisplay1.OnlineRowNo == inpHedDisplay2.OnlineRowNo)
                 && (inpHedDisplay1.BusinessName == inpHedDisplay2.BusinessName));
        }
        /// <summary>
        /// Hed��ʓ��̓N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�InpHedDisplay�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InpHedDisplay�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(InpHedDisplay target)
        {
            ArrayList resList = new ArrayList();
            if (this.OnlineNo != target.OnlineNo) resList.Add("OnlineNo");
            if (this.UOESupplierCd != target.UOESupplierCd) resList.Add("UOESupplierCd");
            if (this.UOESupplierName != target.UOESupplierName) resList.Add("UOESupplierName");
            if (this.UOEDeliGoodsDiv != target.UOEDeliGoodsDiv) resList.Add("UOEDeliGoodsDiv");
            if (this.DeliveredGoodsDivNm != target.DeliveredGoodsDivNm) resList.Add("DeliveredGoodsDivNm");
            if (this.FollowDeliGoodsDiv != target.FollowDeliGoodsDiv) resList.Add("FollowDeliGoodsDiv");
            if (this.FollowDeliGoodsDivNm != target.FollowDeliGoodsDivNm) resList.Add("FollowDeliGoodsDivNm");
            if (this.UOEResvdSection != target.UOEResvdSection) resList.Add("UOEResvdSection");
            if (this.UOEResvdSectionNm != target.UOEResvdSectionNm) resList.Add("UOEResvdSectionNm");
            if (this.EmployeeCode != target.EmployeeCode) resList.Add("EmployeeCode");
            if (this.EmployeeName != target.EmployeeName) resList.Add("EmployeeName");
            if (this.UoeRemark1 != target.UoeRemark1) resList.Add("UoeRemark1");
            if (this.UoeRemark2 != target.UoeRemark2) resList.Add("UoeRemark2");
            if (this.BusinessCode != target.BusinessCode) resList.Add("BusinessCode");
            if (this.OnlineRowNo != target.OnlineRowNo) resList.Add("OnlineRowNo");
            if (this.BusinessName != target.BusinessName) resList.Add("BusinessName");

            return resList;
        }

        /// <summary>
        /// Hed��ʓ��̓N���X��r����
        /// </summary>
        /// <param name="inpHedDisplay1">��r����InpHedDisplay�N���X�̃C���X�^���X</param>
        /// <param name="inpHedDisplay2">��r����InpHedDisplay�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InpHedDisplay�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(InpHedDisplay inpHedDisplay1, InpHedDisplay inpHedDisplay2)
        {
            ArrayList resList = new ArrayList();
            if (inpHedDisplay1.OnlineNo != inpHedDisplay2.OnlineNo) resList.Add("OnlineNo");
            if (inpHedDisplay1.UOESupplierCd != inpHedDisplay2.UOESupplierCd) resList.Add("UOESupplierCd");
            if (inpHedDisplay1.UOESupplierName != inpHedDisplay2.UOESupplierName) resList.Add("UOESupplierName");
            if (inpHedDisplay1.UOEDeliGoodsDiv != inpHedDisplay2.UOEDeliGoodsDiv) resList.Add("UOEDeliGoodsDiv");
            if (inpHedDisplay1.DeliveredGoodsDivNm != inpHedDisplay2.DeliveredGoodsDivNm) resList.Add("DeliveredGoodsDivNm");
            if (inpHedDisplay1.FollowDeliGoodsDiv != inpHedDisplay2.FollowDeliGoodsDiv) resList.Add("FollowDeliGoodsDiv");
            if (inpHedDisplay1.FollowDeliGoodsDivNm != inpHedDisplay2.FollowDeliGoodsDivNm) resList.Add("FollowDeliGoodsDivNm");
            if (inpHedDisplay1.UOEResvdSection != inpHedDisplay2.UOEResvdSection) resList.Add("UOEResvdSection");
            if (inpHedDisplay1.UOEResvdSectionNm != inpHedDisplay2.UOEResvdSectionNm) resList.Add("UOEResvdSectionNm");
            if (inpHedDisplay1.EmployeeCode != inpHedDisplay2.EmployeeCode) resList.Add("EmployeeCode");
            if (inpHedDisplay1.EmployeeName != inpHedDisplay2.EmployeeName) resList.Add("EmployeeName");
            if (inpHedDisplay1.UoeRemark1 != inpHedDisplay2.UoeRemark1) resList.Add("UoeRemark1");
            if (inpHedDisplay1.UoeRemark2 != inpHedDisplay2.UoeRemark2) resList.Add("UoeRemark2");
            if (inpHedDisplay1.BusinessCode != inpHedDisplay2.BusinessCode) resList.Add("BusinessCode");
            if (inpHedDisplay1.OnlineRowNo != inpHedDisplay2.OnlineRowNo) resList.Add("OnlineRowNo");
            if (inpHedDisplay1.BusinessName != inpHedDisplay2.BusinessName) resList.Add("BusinessName");

            return resList;
        }
    }
}

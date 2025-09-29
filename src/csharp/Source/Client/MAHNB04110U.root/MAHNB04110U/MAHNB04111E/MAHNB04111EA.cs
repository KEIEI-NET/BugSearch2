using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SalesSlipSearch
    /// <summary>
    ///                      ����`�[��������
    /// </summary>
    /// <remarks>
    /// <br>note             :   ����`�[���������w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/03/06  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// <br>Update Note      :   ���N�n�� Redmine 26538�Ή�</br>
    /// <br>Date             :   2011/11/11</br>
    /// </remarks>
    public class SalesSlipSearch
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>����`�[�敪</summary>
        /// <remarks>0:����,1:�ԕi,2:�l�� 100:�������� 101:�����ԕi 102:�����l��</remarks>
        private Int32 _salesSlipCd;

        /// <summary>�󒍃X�e�[�^�X</summary>
        /// <remarks>10:����,15:�P������,20:��,30:����,40:�o��</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>���|�敪</summary>
        /// <remarks>0:���|�Ȃ�,1:���|</remarks>
        private Int32 _accRecDivCd;

        /// <summary>����`�[�ԍ�(�J�n)</summary>
        private string _salesSlipNumSt = "";

        /// <summary>����`�[�ԍ�(�I��)</summary>
        private string _salesSlipNumEd = "";

        /// <summary>�����(�J�n)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _salesDateSt;

        /// <summary>�����(�I��)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _salesDateEd;

        /// <summary>�`�[�������t(�J�n)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _searchSlipDateSt;

        /// <summary>�`�[�������t(�I��)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _searchSlipDateEd;

        /// <summary>��t�]�ƈ��R�[�h</summary>
        private string _frontEmployeeCd = "";

        /// <summary>�̔��]�ƈ��R�[�h</summary>
        private string _salesEmployeeCd = "";

        /// <summary>������͎҃R�[�h</summary>
        private string _salesInputCode = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>������R�[�h</summary>
        private Int32 _claimCode;

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���_��</summary>
        private string _sectionName = "";

        /// <summary>���Ӑ於</summary>
        private string _customerName = "";

        /// <summary>�����於</summary>
        private string _claimName = "";

        /// <summary>���i��</summary>
        private string _goodsName = "";

        /// <summary>��t�]�ƈ���</summary>
        private string _frontEmployeeName = "";

        /// <summary>�̔��]�ƈ���</summary>
        private string _salesEmployeeName = "";

        /// <summary>������͎Җ�</summary>
        private string _salesInputName = "";

        /// <summary>���[�J�[��</summary>
        private string _makerName = "";

        /// <summary>�����`�[�ԍ�</summary>
        /// <remarks>���Ӑ撍���ԍ�</remarks>
        private string _partySaleSlipNum = "";

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�^��</summary>
        private string _fullModel = "";

        /// <summary>�����R�[�h</summary>
        private int _subSectionCode;

        /// <summary>������</summary>
        private string _subSectionName;

        //---ADD 2011/11/11 ------------------------->>>>>
        /// <summary>�󔭒����</summary>
        /// <remarks>0:PCCforNS�@,1:BL�߰µ��ް</remarks>
        private Int16 _acceptOrOrderKind;

        /// <summary>�����񓚎��</summary>
        /// <remarks>0:�ʏ�@,1:�蓮�񓚁@,2:������</remarks>
        private Int32 _autoAnswerDivSCM;

        //---ADD 2011/11/11 -------------------------<<<<<

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

        /// public propaty name  :  SalesSlipCd
        /// <summary>����`�[�敪�v���p�e�B</summary>
        /// <value>0:����,1:�ԕi,2:�l�� 100:�������� 101:�����ԕi 102:�����l��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesSlipCd
        {
            get { return _salesSlipCd; }
            set { _salesSlipCd = value; }
        }

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
        /// <value>10:����,15:�P������,20:��,30:����,40:�o��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// public propaty name  :  AccRecDivCd
        /// <summary>���|�敪�v���p�e�B</summary>
        /// <value>0:���|�Ȃ�,1:���|</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���|�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AccRecDivCd
        {
            get { return _accRecDivCd; }
            set { _accRecDivCd = value; }
        }

        /// public propaty name  :  SalesSlipNumSt
        /// <summary>����`�[�ԍ�(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�ԍ�(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesSlipNumSt
        {
            get { return _salesSlipNumSt; }
            set { _salesSlipNumSt = value; }
        }

        /// public propaty name  :  SalesSlipNumEd
        /// <summary>����`�[�ԍ�(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�ԍ�(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesSlipNumEd
        {
            get { return _salesSlipNumEd; }
            set { _salesSlipNumEd = value; }
        }

        /// public propaty name  :  SalesDateSt
        /// <summary>�����(�J�n)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime SalesDateSt
        {
            get { return _salesDateSt; }
            set { _salesDateSt = value; }
        }

        /// public propaty name  :  SalesDateEd
        /// <summary>�����(�I��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime SalesDateEd
        {
            get { return _salesDateEd; }
            set { _salesDateEd = value; }
        }

        /// public propaty name  :  SearchSlipDateSt
        /// <summary>�`�[�������t(�J�n)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�������t(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime SearchSlipDateSt
        {
            get { return _searchSlipDateSt; }
            set { _searchSlipDateSt = value; }
        }

        /// public propaty name  :  SearchSlipDateEd
        /// <summary>�`�[�������t(�I��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�������t(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime SearchSlipDateEd
        {
            get { return _searchSlipDateEd; }
            set { _searchSlipDateEd = value; }
        }

        /// public propaty name  :  FrontEmployeeCd
        /// <summary>��t�]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��t�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FrontEmployeeCd
        {
            get { return _frontEmployeeCd; }
            set { _frontEmployeeCd = value; }
        }

        /// public propaty name  :  SalesEmployeeCd
        /// <summary>�̔��]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesEmployeeCd
        {
            get { return _salesEmployeeCd; }
            set { _salesEmployeeCd = value; }
        }

        /// public propaty name  :  SalesInputCode
        /// <summary>������͎҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������͎҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesInputCode
        {
            get { return _salesInputCode; }
            set { _salesInputCode = value; }
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

        /// public propaty name  :  ClaimCode
        /// <summary>������R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ClaimCode
        {
            get { return _claimCode; }
            set { _claimCode = value; }
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

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>���i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  SectionName
        /// <summary>���_���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionName
        {
            get { return _sectionName; }
            set { _sectionName = value; }
        }

        /// public propaty name  :  CustomerName
        /// <summary>���Ӑ於�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        /// public propaty name  :  ClaimName
        /// <summary>�����於�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����於�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ClaimName
        {
            get { return _claimName; }
            set { _claimName = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>���i���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  FrontEmployeeName
        /// <summary>��t�]�ƈ����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��t�]�ƈ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FrontEmployeeName
        {
            get { return _frontEmployeeName; }
            set { _frontEmployeeName = value; }
        }

        /// public propaty name  :  SalesEmployeeName
        /// <summary>�̔��]�ƈ����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��]�ƈ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesEmployeeName
        {
            get { return _salesEmployeeName; }
            set { _salesEmployeeName = value; }
        }

        /// public propaty name  :  SalesInputName
        /// <summary>������͎Җ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������͎Җ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesInputName
        {
            get { return _salesInputName; }
            set { _salesInputName = value; }
        }

        /// public propaty name  :  MakerName
        /// <summary>���[�J�[���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MakerName
        {
            get { return _makerName; }
            set { _makerName = value; }
        }

        /// public propaty name  :  PartySaleSlipNum
        /// <summary>�����`�[�ԍ��v���p�e�B</summary>
        /// <value>���Ӑ撍���ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartySaleSlipNum
        {
            get { return _partySaleSlipNum; }
            set { _partySaleSlipNum = value; }
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

        /// public propaty name  :  FullModel
        /// <summary>�^�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FullModel
        {
            get { return _fullModel; }
            set { _fullModel = value; }
        }

        /// public propaty name  :  SubSectionCode
        /// <summary>�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int SubSectionCode
        {
            get { return _subSectionCode; }
            set { this._subSectionCode = value; }
        }

        /// public propaty name  :  SubSectionName
        /// <summary>�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SubSectionName
        {
            get { return _subSectionName; }
            set { this._subSectionName = value; }
        }

        //---ADD 2011/11/11 ----------------------->>>>>

        /// public propaty name  :  AcceptOrOrderKindRF
        /// <summary>�󔭒���ʃv���p�e�B</summary>
        /// <value>0:PCCforNS�@,1:BL�߰µ��ް</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󔭒���ʃv���p�e�B</br>
        /// <br>Programer        :   ���N�n��</br>
        /// </remarks>
        public Int16 AcceptOrOrderKind
        {
            get { return _acceptOrOrderKind; }
            set { _acceptOrOrderKind = value; }
        }


        /// public propaty name  :  AutoAnswerDivSCM
        /// <summary>�����񓚎�ʃv���p�e�B</summary>
        /// <value>0:�ʏ�@,1:�蓮�񓚁@,2:������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����񓚎�ʃv���p�e�B</br>
        /// <br>Programer        :   ���N�n��</br>
        /// </remarks>
        public Int32 AutoAnswerDivSCM
        {
            get { return _autoAnswerDivSCM; }
            set { _autoAnswerDivSCM = value; }
        }

        //---ADD 2011/11/11 -----------------------<<<<<



        /// <summary>
        /// ����`�[���������R���X�g���N�^
        /// </summary>
        /// <returns>SalesSlipSearch�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesSlipSearch�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalesSlipSearch()
        {
        }

        /// <summary>
        /// ����`�[���������R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="salesSlipCd">����`�[�敪(0:����,1:�ԕi,2:�l�� 100:�������� 101:�����ԕi 102:�����l��)</param>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X(10:����,15:�P������,20:��,30:����,40:�o��)</param>
        /// <param name="accRecDivCd">���|�敪(0:���|�Ȃ�,1:���|)</param>
        /// <param name="salesSlipNumSt">����`�[�ԍ�(�J�n)</param>
        /// <param name="salesSlipNumEd">����`�[�ԍ�(�I��)</param>
        /// <param name="salesDateSt">�����(�J�n)(YYYYMMDD)</param>
        /// <param name="salesDateEd">�����(�I��)(YYYYMMDD)</param>
        /// <param name="searchSlipDateSt">�`�[�������t(�J�n)(YYYYMMDD)</param>
        /// <param name="searchSlipDateEd">�`�[�������t(�I��)(YYYYMMDD)</param>
        /// <param name="frontEmployeeCd">��t�]�ƈ��R�[�h</param>
        /// <param name="salesEmployeeCd">�̔��]�ƈ��R�[�h</param>
        /// <param name="salesInputCode">������͎҃R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="claimCode">������R�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="goodsNo">���i�ԍ�</param>
        /// <param name="sectionName">���_��</param>
        /// <param name="customerName">���Ӑ於</param>
        /// <param name="claimName">�����於</param>
        /// <param name="goodsName">���i��</param>
        /// <param name="frontEmployeeName">��t�]�ƈ���</param>
        /// <param name="salesEmployeeName">�̔��]�ƈ���</param>
        /// <param name="salesInputName">������͎Җ�</param>
        /// <param name="makerName">���[�J�[��</param>
        /// <param name="partySaleSlipNum">�����`�[�ԍ�(���Ӑ撍���ԍ�)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="acceptOrOrderKind">�A�g���</param>
        /// <param name="autoAnswerDivSCM">������</param>
        /// <returns>SalesSlipSearch�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesSlipSearch�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   ���N�n�� BL�߰µ��ް�݌Ɋm�F���̌��ϓ`�[�Ή�</br>
        /// <br>Date             :   2011/11/11</br>
        /// </remarks>
        //public SalesSlipSearch(string enterpriseCode, Int32 salesSlipCd, Int32 acptAnOdrStatus, Int32 accRecDivCd, string salesSlipNumSt, string salesSlipNumEd, DateTime salesDateSt, DateTime salesDateEd, DateTime searchSlipDateSt, DateTime searchSlipDateEd, string frontEmployeeCd, string salesEmployeeCd, string salesInputCode, Int32 customerCode, Int32 claimCode, string sectionCode, Int32 goodsMakerCd, string goodsNo, string sectionName, string customerName, string claimName, string goodsName, string frontEmployeeName, string salesEmployeeName, string salesInputName, string makerName, string partySaleSlipNum, string enterpriseName, string fullModel, Int32 subSectionCode, string subSectionName)// DEL 2011/11/11
        public SalesSlipSearch(string enterpriseCode, Int32 salesSlipCd, Int32 acptAnOdrStatus, Int32 accRecDivCd, string salesSlipNumSt, string salesSlipNumEd, DateTime salesDateSt, DateTime salesDateEd, DateTime searchSlipDateSt, DateTime searchSlipDateEd, string frontEmployeeCd, string salesEmployeeCd, string salesInputCode, Int32 customerCode, Int32 claimCode, string sectionCode, Int32 goodsMakerCd, string goodsNo, string sectionName, string customerName, string claimName, string goodsName, string frontEmployeeName, string salesEmployeeName, string salesInputName, string makerName, string partySaleSlipNum, string enterpriseName, string fullModel, Int32 subSectionCode, string subSectionName, Int16 acceptOrOrderKind, Int32 autoAnswerDivSCM)  //ADD 2011/11/11  
        {
            this._enterpriseCode = enterpriseCode;
            this._salesSlipCd = salesSlipCd;
            this._acptAnOdrStatus = acptAnOdrStatus;
            this._accRecDivCd = accRecDivCd;
            this._salesSlipNumSt = salesSlipNumSt;
            this._salesSlipNumEd = salesSlipNumEd;
            this._salesDateSt = salesDateSt;
            this._salesDateEd = salesDateEd;
            this._searchSlipDateSt = searchSlipDateSt;
            this._searchSlipDateEd = searchSlipDateEd;
            this._frontEmployeeCd = frontEmployeeCd;
            this._salesEmployeeCd = salesEmployeeCd;
            this._salesInputCode = salesInputCode;
            this._customerCode = customerCode;
            this._claimCode = claimCode;
            this._sectionCode = sectionCode;
            this._goodsMakerCd = goodsMakerCd;
            this._goodsNo = goodsNo;
            this._sectionName = sectionName;
            this._customerName = customerName;
            this._claimName = claimName;
            this._goodsName = goodsName;
            this._frontEmployeeName = frontEmployeeName;
            this._salesEmployeeName = salesEmployeeName;
            this._salesInputName = salesInputName;
            this._makerName = makerName;
            this._partySaleSlipNum = partySaleSlipNum;
            this._enterpriseName = enterpriseName;
            this._fullModel = fullModel;
            this._subSectionCode = subSectionCode;
            this._subSectionName = subSectionName;
            //---ADD 2011/11/11 ------>>>>>
            this._acceptOrOrderKind = acceptOrOrderKind;
            this._autoAnswerDivSCM = autoAnswerDivSCM;
            //---ADD 2011/11/11 ------<<<<<
        }

        /// <summary>
        /// ����`�[����������������
        /// </summary>
        /// <returns>SalesSlipSearch�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SalesSlipSearch�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   ���N�n�� BL�߰µ��ް�݌Ɋm�F���̌��ϓ`�[�Ή�</br>
        /// </remarks>
        public SalesSlipSearch Clone()
        {
            //return new SalesSlipSearch( this._enterpriseCode, this._salesSlipCd, this._acptAnOdrStatus, this._accRecDivCd, this._salesSlipNumSt, this._salesSlipNumEd, this._salesDateSt, this._salesDateEd, this._searchSlipDateSt, this._searchSlipDateEd, this._frontEmployeeCd, this._salesEmployeeCd, this._salesInputCode, this._customerCode, this._claimCode, this._sectionCode, this._goodsMakerCd, this._goodsNo, this._sectionName, this._customerName, this._claimName, this._goodsName, this._frontEmployeeName, this._salesEmployeeName, this._salesInputName, this._makerName, this._partySaleSlipNum, this._enterpriseName, this._fullModel, this._subSectionCode, this._subSectionName );// DEL 2011/11/11
            return new SalesSlipSearch(this._enterpriseCode, this._salesSlipCd, this._acptAnOdrStatus, this._accRecDivCd, this._salesSlipNumSt, this._salesSlipNumEd, this._salesDateSt, this._salesDateEd, this._searchSlipDateSt, this._searchSlipDateEd, this._frontEmployeeCd, this._salesEmployeeCd, this._salesInputCode, this._customerCode, this._claimCode, this._sectionCode, this._goodsMakerCd, this._goodsNo, this._sectionName, this._customerName, this._claimName, this._goodsName, this._frontEmployeeName, this._salesEmployeeName, this._salesInputName, this._makerName, this._partySaleSlipNum, this._enterpriseName, this._fullModel, this._subSectionCode, this._subSectionName, this._acceptOrOrderKind, this._autoAnswerDivSCM);//ADD 2011/11/11
        }

        /// <summary>
        /// ����`�[����������r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SalesSlipSearch�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesSlipSearch�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   ���N�n�� BL�߰µ��ް�݌Ɋm�F���̌��ϓ`�[�Ή�</br>
        /// </remarks>
        public bool Equals(SalesSlipSearch target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SalesSlipCd == target.SalesSlipCd)
                 && (this.AcptAnOdrStatus == target.AcptAnOdrStatus)
                 && (this.AccRecDivCd == target.AccRecDivCd)
                 && (this.SalesSlipNumSt == target.SalesSlipNumSt)
                 && (this.SalesSlipNumEd == target.SalesSlipNumEd)
                 && (this.SalesDateSt == target.SalesDateSt)
                 && (this.SalesDateEd == target.SalesDateEd)
                 && (this.SearchSlipDateSt == target.SearchSlipDateSt)
                 && (this.SearchSlipDateEd == target.SearchSlipDateEd)
                 && (this.FrontEmployeeCd == target.FrontEmployeeCd)
                 && (this.SalesEmployeeCd == target.SalesEmployeeCd)
                 && (this.SalesInputCode == target.SalesInputCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.ClaimCode == target.ClaimCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.SectionName == target.SectionName)
                 && (this.CustomerName == target.CustomerName)
                 && (this.ClaimName == target.ClaimName)
                 && (this.GoodsName == target.GoodsName)
                 && (this.FrontEmployeeName == target.FrontEmployeeName)
                 && (this.SalesEmployeeName == target.SalesEmployeeName)
                 && (this.SalesInputName == target.SalesInputName)
                 && (this.MakerName == target.MakerName)
                 && (this.PartySaleSlipNum == target.PartySaleSlipNum)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.FullModel == target.FullModel)
                 && (this.SubSectionCode == target.SubSectionCode)
                 && (this.SubSectionName == target.SubSectionName)
                 //---ADD 2011/11/11 ---------------->>>>>
                 && (this.AcceptOrOrderKind == target.AcceptOrOrderKind)
                 && (this.AutoAnswerDivSCM == target.AutoAnswerDivSCM)
                 //---ADD 2011/11/11 -----------------<<<<<
                 );
        }

        /// <summary>
        /// ����`�[����������r����
        /// </summary>
        /// <param name="salesSlipSearch1">
        ///                    ��r����SalesSlipSearch�N���X�̃C���X�^���X
        /// </param>
        /// <param name="salesSlipSearch2">��r����SalesSlipSearch�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesSlipSearch�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   ���N�n�� BL�߰µ��ް�݌Ɋm�F���̌��ϓ`�[�Ή�</br>
        /// </remarks>
        public static bool Equals(SalesSlipSearch salesSlipSearch1, SalesSlipSearch salesSlipSearch2)
        {
            return ((salesSlipSearch1.EnterpriseCode == salesSlipSearch2.EnterpriseCode)
                 && (salesSlipSearch1.SalesSlipCd == salesSlipSearch2.SalesSlipCd)
                 && (salesSlipSearch1.AcptAnOdrStatus == salesSlipSearch2.AcptAnOdrStatus)
                 && (salesSlipSearch1.AccRecDivCd == salesSlipSearch2.AccRecDivCd)
                 && (salesSlipSearch1.SalesSlipNumSt == salesSlipSearch2.SalesSlipNumSt)
                 && (salesSlipSearch1.SalesSlipNumEd == salesSlipSearch2.SalesSlipNumEd)
                 && (salesSlipSearch1.SalesDateSt == salesSlipSearch2.SalesDateSt)
                 && (salesSlipSearch1.SalesDateEd == salesSlipSearch2.SalesDateEd)
                 && (salesSlipSearch1.SearchSlipDateSt == salesSlipSearch2.SearchSlipDateSt)
                 && (salesSlipSearch1.SearchSlipDateEd == salesSlipSearch2.SearchSlipDateEd)
                 && (salesSlipSearch1.FrontEmployeeCd == salesSlipSearch2.FrontEmployeeCd)
                 && (salesSlipSearch1.SalesEmployeeCd == salesSlipSearch2.SalesEmployeeCd)
                 && (salesSlipSearch1.SalesInputCode == salesSlipSearch2.SalesInputCode)
                 && (salesSlipSearch1.CustomerCode == salesSlipSearch2.CustomerCode)
                 && (salesSlipSearch1.ClaimCode == salesSlipSearch2.ClaimCode)
                 && (salesSlipSearch1.SectionCode == salesSlipSearch2.SectionCode)
                 && (salesSlipSearch1.GoodsMakerCd == salesSlipSearch2.GoodsMakerCd)
                 && (salesSlipSearch1.GoodsNo == salesSlipSearch2.GoodsNo)
                 && (salesSlipSearch1.SectionName == salesSlipSearch2.SectionName)
                 && (salesSlipSearch1.CustomerName == salesSlipSearch2.CustomerName)
                 && (salesSlipSearch1.ClaimName == salesSlipSearch2.ClaimName)
                 && (salesSlipSearch1.GoodsName == salesSlipSearch2.GoodsName)
                 && (salesSlipSearch1.FrontEmployeeName == salesSlipSearch2.FrontEmployeeName)
                 && (salesSlipSearch1.SalesEmployeeName == salesSlipSearch2.SalesEmployeeName)
                 && (salesSlipSearch1.SalesInputName == salesSlipSearch2.SalesInputName)
                 && (salesSlipSearch1.MakerName == salesSlipSearch2.MakerName)
                 && (salesSlipSearch1.PartySaleSlipNum == salesSlipSearch2.PartySaleSlipNum)
                 && (salesSlipSearch1.EnterpriseName == salesSlipSearch2.EnterpriseName)
                 && (salesSlipSearch1.FullModel == salesSlipSearch2.FullModel)
                 && (salesSlipSearch1.SubSectionCode == salesSlipSearch2.SubSectionCode)
                 && (salesSlipSearch1.SubSectionName == salesSlipSearch2.SubSectionName)
                 //---ADD 2011/11/11 -------------->>>>>
                 && (salesSlipSearch1.AcceptOrOrderKind == salesSlipSearch2.AcceptOrOrderKind)
                 && (salesSlipSearch1.AutoAnswerDivSCM == salesSlipSearch2.AutoAnswerDivSCM)
                 //---ADD 2011/11/11 --------------<<<<<
                 );
        }
        /// <summary>
        /// ����`�[����������r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SalesSlipSearch�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesSlipSearch�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   ���N�n�� BL�߰µ��ް�݌Ɋm�F���̌��ϓ`�[�Ή�</br>
        /// </remarks>
        public ArrayList Compare(SalesSlipSearch target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SalesSlipCd != target.SalesSlipCd) resList.Add("SalesSlipCd");
            if (this.AcptAnOdrStatus != target.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (this.AccRecDivCd != target.AccRecDivCd) resList.Add("AccRecDivCd");
            if (this.SalesSlipNumSt != target.SalesSlipNumSt) resList.Add("SalesSlipNumSt");
            if (this.SalesSlipNumEd != target.SalesSlipNumEd) resList.Add("SalesSlipNumEd");
            if (this.SalesDateSt != target.SalesDateSt) resList.Add("SalesDateSt");
            if (this.SalesDateEd != target.SalesDateEd) resList.Add("SalesDateEd");
            if (this.SearchSlipDateSt != target.SearchSlipDateSt) resList.Add("SearchSlipDateSt");
            if (this.SearchSlipDateEd != target.SearchSlipDateEd) resList.Add("SearchSlipDateEd");
            if (this.FrontEmployeeCd != target.FrontEmployeeCd) resList.Add("FrontEmployeeCd");
            if (this.SalesEmployeeCd != target.SalesEmployeeCd) resList.Add("SalesEmployeeCd");
            if (this.SalesInputCode != target.SalesInputCode) resList.Add("SalesInputCode");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.ClaimCode != target.ClaimCode) resList.Add("ClaimCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.SectionName != target.SectionName) resList.Add("SectionName");
            if (this.CustomerName != target.CustomerName) resList.Add("CustomerName");
            if (this.ClaimName != target.ClaimName) resList.Add("ClaimName");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.FrontEmployeeName != target.FrontEmployeeName) resList.Add("FrontEmployeeName");
            if (this.SalesEmployeeName != target.SalesEmployeeName) resList.Add("SalesEmployeeName");
            if (this.SalesInputName != target.SalesInputName) resList.Add("SalesInputName");
            if (this.MakerName != target.MakerName) resList.Add("MakerName");
            if (this.PartySaleSlipNum != target.PartySaleSlipNum) resList.Add("PartySaleSlipNum");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.FullModel != target.FullModel) resList.Add("FullModel");
            if (this.SubSectionCode != target.SubSectionCode) resList.Add("SubSectionCode");
            if ( this.SubSectionName != target.SubSectionName ) resList.Add( "SubSectionName" );
            //---ADD 2011/11/11 ------------------------------------->>>>>
            if (this.AcceptOrOrderKind != target.AcceptOrOrderKind) resList.Add("AcceptOrOrderKind");
            if (this.AutoAnswerDivSCM != target.AutoAnswerDivSCM) resList.Add("AutoAnswerDivSCM");
            //---ADD 2011/11/11 -------------------------------------<<<<<
            return resList;
        }

        /// <summary>
        /// ����`�[����������r����
        /// </summary>
        /// <param name="salesSlipSearch1">��r����SalesSlipSearch�N���X�̃C���X�^���X</param>
        /// <param name="salesSlipSearch2">��r����SalesSlipSearch�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesSlipSearch�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   ���N�n�� BL�߰µ��ް�݌Ɋm�F���̌��ϓ`�[�Ή�</br>
        /// </remarks>
        public static ArrayList Compare(SalesSlipSearch salesSlipSearch1, SalesSlipSearch salesSlipSearch2)
        {
            ArrayList resList = new ArrayList();
            if (salesSlipSearch1.EnterpriseCode != salesSlipSearch2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (salesSlipSearch1.SalesSlipCd != salesSlipSearch2.SalesSlipCd) resList.Add("SalesSlipCd");
            if (salesSlipSearch1.AcptAnOdrStatus != salesSlipSearch2.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (salesSlipSearch1.AccRecDivCd != salesSlipSearch2.AccRecDivCd) resList.Add("AccRecDivCd");
            if (salesSlipSearch1.SalesSlipNumSt != salesSlipSearch2.SalesSlipNumSt) resList.Add("SalesSlipNumSt");
            if (salesSlipSearch1.SalesSlipNumEd != salesSlipSearch2.SalesSlipNumEd) resList.Add("SalesSlipNumEd");
            if (salesSlipSearch1.SalesDateSt != salesSlipSearch2.SalesDateSt) resList.Add("SalesDateSt");
            if (salesSlipSearch1.SalesDateEd != salesSlipSearch2.SalesDateEd) resList.Add("SalesDateEd");
            if (salesSlipSearch1.SearchSlipDateSt != salesSlipSearch2.SearchSlipDateSt) resList.Add("SearchSlipDateSt");
            if (salesSlipSearch1.SearchSlipDateEd != salesSlipSearch2.SearchSlipDateEd) resList.Add("SearchSlipDateEd");
            if (salesSlipSearch1.FrontEmployeeCd != salesSlipSearch2.FrontEmployeeCd) resList.Add("FrontEmployeeCd");
            if (salesSlipSearch1.SalesEmployeeCd != salesSlipSearch2.SalesEmployeeCd) resList.Add("SalesEmployeeCd");
            if (salesSlipSearch1.SalesInputCode != salesSlipSearch2.SalesInputCode) resList.Add("SalesInputCode");
            if (salesSlipSearch1.CustomerCode != salesSlipSearch2.CustomerCode) resList.Add("CustomerCode");
            if (salesSlipSearch1.ClaimCode != salesSlipSearch2.ClaimCode) resList.Add("ClaimCode");
            if (salesSlipSearch1.SectionCode != salesSlipSearch2.SectionCode) resList.Add("SectionCode");
            if (salesSlipSearch1.GoodsMakerCd != salesSlipSearch2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (salesSlipSearch1.GoodsNo != salesSlipSearch2.GoodsNo) resList.Add("GoodsNo");
            if (salesSlipSearch1.SectionName != salesSlipSearch2.SectionName) resList.Add("SectionName");
            if (salesSlipSearch1.CustomerName != salesSlipSearch2.CustomerName) resList.Add("CustomerName");
            if (salesSlipSearch1.ClaimName != salesSlipSearch2.ClaimName) resList.Add("ClaimName");
            if (salesSlipSearch1.GoodsName != salesSlipSearch2.GoodsName) resList.Add("GoodsName");
            if (salesSlipSearch1.FrontEmployeeName != salesSlipSearch2.FrontEmployeeName) resList.Add("FrontEmployeeName");
            if (salesSlipSearch1.SalesEmployeeName != salesSlipSearch2.SalesEmployeeName) resList.Add("SalesEmployeeName");
            if (salesSlipSearch1.SalesInputName != salesSlipSearch2.SalesInputName) resList.Add("SalesInputName");
            if (salesSlipSearch1.MakerName != salesSlipSearch2.MakerName) resList.Add("MakerName");
            if (salesSlipSearch1.PartySaleSlipNum != salesSlipSearch2.PartySaleSlipNum) resList.Add("PartySaleSlipNum");
            if (salesSlipSearch1.EnterpriseName != salesSlipSearch2.EnterpriseName) resList.Add("EnterpriseName");
            if (salesSlipSearch1.FullModel != salesSlipSearch2.FullModel) resList.Add("FullModel");
            if (salesSlipSearch1.SubSectionCode != salesSlipSearch2.SubSectionCode) resList.Add("SubSectionCode");
            if ( salesSlipSearch1.SubSectionName != salesSlipSearch2.SubSectionName ) resList.Add( "SubSectionName" );
            //---ADD 2011/11/11 --------------------------------------------->>>>>
            if (salesSlipSearch1.AcceptOrOrderKind != salesSlipSearch2.AcceptOrOrderKind) resList.Add("AcceptOrOrderKind");
            if (salesSlipSearch1.AutoAnswerDivSCM != salesSlipSearch2.AutoAnswerDivSCM) resList.Add("AutoAnswerDivSCM");
            //---ADD 2011/11/11 ---------------------------------------------<<<<<
            return resList;
        }
    }
}

using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   AcptAnOdrRemainRefCndtn
    /// <summary>
    ///                      �󒍎c�Ɖ�o�����N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   �󒍎c�Ɖ�o�����N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/08/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class AcptAnOdrRemainRefCndtn
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>������R�[�h</summary>
        private Int32 _claimCode;

        /// <summary>�󒍏󋵋敪</summary>
        /// <remarks>0:�S�ā^1:�v��ςݕ��^2:���v�㕪</remarks>
        private Int32 _acpOdrStateDiv;

        /// <summary>�^��</summary>
        /// <remarks>(�����܂�����)</remarks>
        private string _fullModel = "";

        /// <summary>�`�[�������t�i�J�n�j</summary>
        /// <remarks>���͓�</remarks>
        private Int32 _st_SearchSlipDate;

        /// <summary>�`�[�������t�i�I���j</summary>
        /// <remarks>���͓�</remarks>
        private Int32 _ed_SearchSlipDate;

        /// <summary>������t(�J�n)</summary>
        /// <remarks>�󒍓�</remarks>
        private Int32 _st_SalesDate;

        /// <summary>������t(�I��)</summary>
        /// <remarks>�󒍓�</remarks>
        private Int32 _ed_SalesDate;

        /// <summary>����`�[�ԍ��i�J�n�j</summary>
        private string _st_SalesSlipNum = "";

        /// <summary>����`�[�ԍ��i�I���j</summary>
        private string _ed_SalesSlipNum = "";

        /// <summary>������͎҃R�[�h</summary>
        /// <remarks>���͒S����</remarks>
        private string _salesInputCode = "";

        /// <summary>��t�]�ƈ��R�[�h</summary>
        /// <remarks>�󒍒S����</remarks>
        private string _frontEmployeeCd = "";

        /// <summary>�̔��]�ƈ��R�[�h</summary>
        /// <remarks>����S����</remarks>
        private string _salesEmployeeCd = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>�i��</summary>
        private string _goodsNo = "";

        /// <summary>�i�ԞB������</summary>
        private Int32 _goodsNoSrchTyp;

        /// <summary>�i��</summary>
        /// <remarks>(�����܂�����)</remarks>
        private string _goodsName = "";

        /// <summary>���i���̞B�������t���O</summary>
        private Int32 _goodsNmVagueSrch;

        /// <summary>�^���B������</summary>
        private Int32 _fullModelSrchTyp;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�̔��]�ƈ�����</summary>
        private string _salesEmployeeNm = "";


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

        /// public propaty name  :  AcpOdrStateDiv
        /// <summary>�󒍏󋵋敪�v���p�e�B</summary>
        /// <value>0:�S�ā^1:�v��ςݕ��^2:���v�㕪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍏󋵋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcpOdrStateDiv
        {
            get { return _acpOdrStateDiv; }
            set { _acpOdrStateDiv = value; }
        }

        /// public propaty name  :  FullModel
        /// <summary>�^���v���p�e�B</summary>
        /// <value>(�����܂�����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FullModel
        {
            get { return _fullModel; }
            set { _fullModel = value; }
        }

        /// public propaty name  :  FullModelSrchTyp
        /// <summary>�^���B�������v���p�e�B</summary>
        /// <value>(�����܂�����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���B�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FullModelSrchTyp
        {
            get { return _fullModelSrchTyp; }
            set { _fullModelSrchTyp = value; }
        }

        /// public propaty name  :  St_SearchSlipDate
        /// <summary>�`�[�������t�i�J�n�j�v���p�e�B</summary>
        /// <value>���͓�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�������t�i�J�n�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_SearchSlipDate
        {
            get { return _st_SearchSlipDate; }
            set { _st_SearchSlipDate = value; }
        }

        /// public propaty name  :  Ed_SearchSlipDate
        /// <summary>�`�[�������t�i�I���j�v���p�e�B</summary>
        /// <value>���͓�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�������t�i�I���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_SearchSlipDate
        {
            get { return _ed_SearchSlipDate; }
            set { _ed_SearchSlipDate = value; }
        }

        /// public propaty name  :  St_SalesDate
        /// <summary>������t(�J�n)�v���p�e�B</summary>
        /// <value>�󒍓�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_SalesDate
        {
            get { return _st_SalesDate; }
            set { _st_SalesDate = value; }
        }

        /// public propaty name  :  Ed_SalesDate
        /// <summary>������t(�I��)�v���p�e�B</summary>
        /// <value>�󒍓�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_SalesDate
        {
            get { return _ed_SalesDate; }
            set { _ed_SalesDate = value; }
        }

        /// public propaty name  :  St_SalesSlipNum
        /// <summary>����`�[�ԍ��i�J�n�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�ԍ��i�J�n�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string St_SalesSlipNum
        {
            get { return _st_SalesSlipNum; }
            set { _st_SalesSlipNum = value; }
        }

        /// public propaty name  :  Ed_SalesSlipNum
        /// <summary>����`�[�ԍ��i�I���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�ԍ��i�I���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Ed_SalesSlipNum
        {
            get { return _ed_SalesSlipNum; }
            set { _ed_SalesSlipNum = value; }
        }

        /// public propaty name  :  SalesInputCode
        /// <summary>������͎҃R�[�h�v���p�e�B</summary>
        /// <value>���͒S����</value>
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

        /// public propaty name  :  FrontEmployeeCd
        /// <summary>��t�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�󒍒S����</value>
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
        /// <value>����S����</value>
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
        /// <summary>�i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsNoSrchTyp
        /// <summary>�i�ԞB������</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ԞB������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsNoSrchTyp
        {
            get { return _goodsNoSrchTyp; }
            set { _goodsNoSrchTyp = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>�i���v���p�e�B</summary>
        /// <value>(�����܂�����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  GoodsNmVagueSrch
        /// <summary>���i���̞B�������t���O�v���p�e�B</summary>
        /// <value>True:�B�������@False:�ʏ팟��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̞B�������t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsNmVagueSrch
        {
            get { return _goodsNmVagueSrch; }
            set { _goodsNmVagueSrch = value; }
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

        /// public propaty name  :  SalesEmployeeNm
        /// <summary>�̔��]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesEmployeeNm
        {
            get { return _salesEmployeeNm; }
            set { _salesEmployeeNm = value; }
        }


        /// <summary>
        /// �󒍎c�Ɖ�o�����N���X�R���X�g���N�^
        /// </summary>
        /// <returns>AcptAnOdrRemainRefCndtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AcptAnOdrRemainRefCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public AcptAnOdrRemainRefCndtn()
        {
        }

        /// <summary>
        /// �󒍎c�Ɖ�o�����N���X�R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="claimCode">������R�[�h</param>
        /// <param name="acpOdrStateDiv">�󒍏󋵋敪(0:�S�ā^1:�v��ςݕ��^2:���v�㕪)</param>
        /// <param name="fullModel">�^��((�����܂�����))</param>
        /// <param name="st_SearchSlipDate">�`�[�������t�i�J�n�j(���͓�)</param>
        /// <param name="ed_SearchSlipDate">�`�[�������t�i�I���j(���͓�)</param>
        /// <param name="st_SalesDate">������t(�J�n)(�󒍓�)</param>
        /// <param name="ed_SalesDate">������t(�I��)(�󒍓�)</param>
        /// <param name="st_SalesSlipNum">����`�[�ԍ��i�J�n�j</param>
        /// <param name="ed_SalesSlipNum">����`�[�ԍ��i�I���j</param>
        /// <param name="salesInputCode">������͎҃R�[�h(���͒S����)</param>
        /// <param name="frontEmployeeCd">��t�]�ƈ��R�[�h(�󒍒S����)</param>
        /// <param name="salesEmployeeCd">�̔��]�ƈ��R�[�h(����S����)</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <param name="goodsNoSrchTyp">�i�ԞB������</param>
        /// <param name="goodsName">�i��((�����܂�����))</param>
        /// <param name="goodsNmVagueSrch">���i���̞B�������t���O</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="salesEmployeeNm">�̔��]�ƈ�����</param>
        /// <param name="fullModelSrchTyp">�^���B�������t���O</param>
        /// <returns>AcptAnOdrRemainRefCndtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AcptAnOdrRemainRefCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public AcptAnOdrRemainRefCndtn(string enterpriseCode, string sectionCode, Int32 customerCode, Int32 claimCode, Int32 acpOdrStateDiv, string fullModel, Int32 st_SearchSlipDate, Int32 ed_SearchSlipDate, Int32 st_SalesDate, Int32 ed_SalesDate, string st_SalesSlipNum, string ed_SalesSlipNum, string salesInputCode, string frontEmployeeCd, string salesEmployeeCd, Int32 goodsMakerCd, string goodsNo, Int32 goodsNoSrchTyp, string goodsName, Int32 goodsNmVagueSrch, string enterpriseName, string salesEmployeeNm, Int32 fullModelSrchTyp)
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
            this._customerCode = customerCode;
            this._claimCode = claimCode;
            this._acpOdrStateDiv = acpOdrStateDiv;
            this._fullModel = fullModel;
            this._st_SearchSlipDate = st_SearchSlipDate;
            this._ed_SearchSlipDate = ed_SearchSlipDate;
            this._st_SalesDate = st_SalesDate;
            this._ed_SalesDate = ed_SalesDate;
            this._st_SalesSlipNum = st_SalesSlipNum;
            this._ed_SalesSlipNum = ed_SalesSlipNum;
            this._salesInputCode = salesInputCode;
            this._frontEmployeeCd = frontEmployeeCd;
            this._salesEmployeeCd = salesEmployeeCd;
            this._goodsMakerCd = goodsMakerCd;
            this._goodsNo = goodsNo;
            this._goodsNoSrchTyp = goodsNoSrchTyp;
            this._goodsName = goodsName;
            this._goodsNmVagueSrch = goodsNmVagueSrch;
            this._enterpriseName = enterpriseName;
            this._salesEmployeeNm = salesEmployeeNm;
            this._fullModelSrchTyp = fullModelSrchTyp;

        }

        /// <summary>
        /// �󒍎c�Ɖ�o�����N���X��������
        /// </summary>
        /// <returns>AcptAnOdrRemainRefCndtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����AcptAnOdrRemainRefCndtn�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public AcptAnOdrRemainRefCndtn Clone()
        {
            return new AcptAnOdrRemainRefCndtn(this._enterpriseCode, this._sectionCode, this._customerCode, this._claimCode, this._acpOdrStateDiv, this._fullModel, this._st_SearchSlipDate, this._ed_SearchSlipDate, this._st_SalesDate, this._ed_SalesDate, this._st_SalesSlipNum, this._ed_SalesSlipNum, this._salesInputCode, this._frontEmployeeCd, this._salesEmployeeCd, this._goodsMakerCd, this._goodsNo, this._goodsNoSrchTyp, this._goodsName, this._goodsNmVagueSrch, this._enterpriseName, this._salesEmployeeNm, this._fullModelSrchTyp);
        }

        /// <summary>
        /// �󒍎c�Ɖ�o�����N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�AcptAnOdrRemainRefCndtn�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AcptAnOdrRemainRefCndtn�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(AcptAnOdrRemainRefCndtn target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.ClaimCode == target.ClaimCode)
                 && (this.AcpOdrStateDiv == target.AcpOdrStateDiv)
                 && (this.FullModel == target.FullModel)
                 && (this.St_SearchSlipDate == target.St_SearchSlipDate)
                 && (this.Ed_SearchSlipDate == target.Ed_SearchSlipDate)
                 && (this.St_SalesDate == target.St_SalesDate)
                 && (this.Ed_SalesDate == target.Ed_SalesDate)
                 && (this.St_SalesSlipNum == target.St_SalesSlipNum)
                 && (this.Ed_SalesSlipNum == target.Ed_SalesSlipNum)
                 && (this.SalesInputCode == target.SalesInputCode)
                 && (this.FrontEmployeeCd == target.FrontEmployeeCd)
                 && (this.SalesEmployeeCd == target.SalesEmployeeCd)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.GoodsNoSrchTyp == target.GoodsNoSrchTyp)
                 && (this.GoodsName == target.GoodsName)
                 && (this.GoodsNmVagueSrch == target.GoodsNmVagueSrch)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.SalesEmployeeNm == target.SalesEmployeeNm)
                 && (this.FullModelSrchTyp == target.FullModelSrchTyp));
        }

        /// <summary>
        /// �󒍎c�Ɖ�o�����N���X��r����
        /// </summary>
        /// <param name="acptAnOdrRemainRefCndtn1">
        ///                    ��r����AcptAnOdrRemainRefCndtn�N���X�̃C���X�^���X
        /// </param>
        /// <param name="acptAnOdrRemainRefCndtn2">��r����AcptAnOdrRemainRefCndtn�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AcptAnOdrRemainRefCndtn�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(AcptAnOdrRemainRefCndtn acptAnOdrRemainRefCndtn1, AcptAnOdrRemainRefCndtn acptAnOdrRemainRefCndtn2)
        {
            return ((acptAnOdrRemainRefCndtn1.EnterpriseCode == acptAnOdrRemainRefCndtn2.EnterpriseCode)
                 && (acptAnOdrRemainRefCndtn1.SectionCode == acptAnOdrRemainRefCndtn2.SectionCode)
                 && (acptAnOdrRemainRefCndtn1.CustomerCode == acptAnOdrRemainRefCndtn2.CustomerCode)
                 && (acptAnOdrRemainRefCndtn1.ClaimCode == acptAnOdrRemainRefCndtn2.ClaimCode)
                 && (acptAnOdrRemainRefCndtn1.AcpOdrStateDiv == acptAnOdrRemainRefCndtn2.AcpOdrStateDiv)
                 && (acptAnOdrRemainRefCndtn1.FullModel == acptAnOdrRemainRefCndtn2.FullModel)
                 && (acptAnOdrRemainRefCndtn1.St_SearchSlipDate == acptAnOdrRemainRefCndtn2.St_SearchSlipDate)
                 && (acptAnOdrRemainRefCndtn1.Ed_SearchSlipDate == acptAnOdrRemainRefCndtn2.Ed_SearchSlipDate)
                 && (acptAnOdrRemainRefCndtn1.St_SalesDate == acptAnOdrRemainRefCndtn2.St_SalesDate)
                 && (acptAnOdrRemainRefCndtn1.Ed_SalesDate == acptAnOdrRemainRefCndtn2.Ed_SalesDate)
                 && (acptAnOdrRemainRefCndtn1.St_SalesSlipNum == acptAnOdrRemainRefCndtn2.St_SalesSlipNum)
                 && (acptAnOdrRemainRefCndtn1.Ed_SalesSlipNum == acptAnOdrRemainRefCndtn2.Ed_SalesSlipNum)
                 && (acptAnOdrRemainRefCndtn1.SalesInputCode == acptAnOdrRemainRefCndtn2.SalesInputCode)
                 && (acptAnOdrRemainRefCndtn1.FrontEmployeeCd == acptAnOdrRemainRefCndtn2.FrontEmployeeCd)
                 && (acptAnOdrRemainRefCndtn1.SalesEmployeeCd == acptAnOdrRemainRefCndtn2.SalesEmployeeCd)
                 && (acptAnOdrRemainRefCndtn1.GoodsMakerCd == acptAnOdrRemainRefCndtn2.GoodsMakerCd)
                 && (acptAnOdrRemainRefCndtn1.GoodsNo == acptAnOdrRemainRefCndtn2.GoodsNo)
                 && (acptAnOdrRemainRefCndtn1.GoodsNoSrchTyp == acptAnOdrRemainRefCndtn2.GoodsNoSrchTyp)
                 && (acptAnOdrRemainRefCndtn1.GoodsName == acptAnOdrRemainRefCndtn2.GoodsName)
                 && (acptAnOdrRemainRefCndtn1.GoodsNmVagueSrch == acptAnOdrRemainRefCndtn2.GoodsNmVagueSrch)
                 && (acptAnOdrRemainRefCndtn1.EnterpriseName == acptAnOdrRemainRefCndtn2.EnterpriseName)
                 && (acptAnOdrRemainRefCndtn1.SalesEmployeeNm == acptAnOdrRemainRefCndtn2.SalesEmployeeNm)
                 && (acptAnOdrRemainRefCndtn1.FullModelSrchTyp == acptAnOdrRemainRefCndtn2.FullModelSrchTyp));
        }
        /// <summary>
        /// �󒍎c�Ɖ�o�����N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�AcptAnOdrRemainRefCndtn�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AcptAnOdrRemainRefCndtn�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(AcptAnOdrRemainRefCndtn target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.ClaimCode != target.ClaimCode) resList.Add("ClaimCode");
            if (this.AcpOdrStateDiv != target.AcpOdrStateDiv) resList.Add("AcpOdrStateDiv");
            if (this.FullModel != target.FullModel) resList.Add("FullModel");
            if (this.St_SearchSlipDate != target.St_SearchSlipDate) resList.Add("St_SearchSlipDate");
            if (this.Ed_SearchSlipDate != target.Ed_SearchSlipDate) resList.Add("Ed_SearchSlipDate");
            if (this.St_SalesDate != target.St_SalesDate) resList.Add("St_SalesDate");
            if (this.Ed_SalesDate != target.Ed_SalesDate) resList.Add("Ed_SalesDate");
            if (this.St_SalesSlipNum != target.St_SalesSlipNum) resList.Add("St_SalesSlipNum");
            if (this.Ed_SalesSlipNum != target.Ed_SalesSlipNum) resList.Add("Ed_SalesSlipNum");
            if (this.SalesInputCode != target.SalesInputCode) resList.Add("SalesInputCode");
            if (this.FrontEmployeeCd != target.FrontEmployeeCd) resList.Add("FrontEmployeeCd");
            if (this.SalesEmployeeCd != target.SalesEmployeeCd) resList.Add("SalesEmployeeCd");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsNoSrchTyp != target.GoodsNoSrchTyp) resList.Add("GoodsNoSrchTyp");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.GoodsNmVagueSrch != target.GoodsNmVagueSrch) resList.Add("GoodsNmVagueSrch");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.SalesEmployeeNm != target.SalesEmployeeNm) resList.Add("SalesEmployeeNm");
            if (this.FullModelSrchTyp != target.FullModelSrchTyp) resList.Add("FullModelSrchTyp");

            return resList;
        }

        /// <summary>
        /// �󒍎c�Ɖ�o�����N���X��r����
        /// </summary>
        /// <param name="acptAnOdrRemainRefCndtn1">��r����AcptAnOdrRemainRefCndtn�N���X�̃C���X�^���X</param>
        /// <param name="acptAnOdrRemainRefCndtn2">��r����AcptAnOdrRemainRefCndtn�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AcptAnOdrRemainRefCndtn�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(AcptAnOdrRemainRefCndtn acptAnOdrRemainRefCndtn1, AcptAnOdrRemainRefCndtn acptAnOdrRemainRefCndtn2)
        {
            ArrayList resList = new ArrayList();
            if (acptAnOdrRemainRefCndtn1.EnterpriseCode != acptAnOdrRemainRefCndtn2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (acptAnOdrRemainRefCndtn1.SectionCode != acptAnOdrRemainRefCndtn2.SectionCode) resList.Add("SectionCode");
            if (acptAnOdrRemainRefCndtn1.CustomerCode != acptAnOdrRemainRefCndtn2.CustomerCode) resList.Add("CustomerCode");
            if (acptAnOdrRemainRefCndtn1.ClaimCode != acptAnOdrRemainRefCndtn2.ClaimCode) resList.Add("ClaimCode");
            if (acptAnOdrRemainRefCndtn1.AcpOdrStateDiv != acptAnOdrRemainRefCndtn2.AcpOdrStateDiv) resList.Add("AcpOdrStateDiv");
            if (acptAnOdrRemainRefCndtn1.FullModel != acptAnOdrRemainRefCndtn2.FullModel) resList.Add("FullModel");
            if (acptAnOdrRemainRefCndtn1.St_SearchSlipDate != acptAnOdrRemainRefCndtn2.St_SearchSlipDate) resList.Add("St_SearchSlipDate");
            if (acptAnOdrRemainRefCndtn1.Ed_SearchSlipDate != acptAnOdrRemainRefCndtn2.Ed_SearchSlipDate) resList.Add("Ed_SearchSlipDate");
            if (acptAnOdrRemainRefCndtn1.St_SalesDate != acptAnOdrRemainRefCndtn2.St_SalesDate) resList.Add("St_SalesDate");
            if (acptAnOdrRemainRefCndtn1.Ed_SalesDate != acptAnOdrRemainRefCndtn2.Ed_SalesDate) resList.Add("Ed_SalesDate");
            if (acptAnOdrRemainRefCndtn1.St_SalesSlipNum != acptAnOdrRemainRefCndtn2.St_SalesSlipNum) resList.Add("St_SalesSlipNum");
            if (acptAnOdrRemainRefCndtn1.Ed_SalesSlipNum != acptAnOdrRemainRefCndtn2.Ed_SalesSlipNum) resList.Add("Ed_SalesSlipNum");
            if (acptAnOdrRemainRefCndtn1.SalesInputCode != acptAnOdrRemainRefCndtn2.SalesInputCode) resList.Add("SalesInputCode");
            if (acptAnOdrRemainRefCndtn1.FrontEmployeeCd != acptAnOdrRemainRefCndtn2.FrontEmployeeCd) resList.Add("FrontEmployeeCd");
            if (acptAnOdrRemainRefCndtn1.SalesEmployeeCd != acptAnOdrRemainRefCndtn2.SalesEmployeeCd) resList.Add("SalesEmployeeCd");
            if (acptAnOdrRemainRefCndtn1.GoodsMakerCd != acptAnOdrRemainRefCndtn2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (acptAnOdrRemainRefCndtn1.GoodsNo != acptAnOdrRemainRefCndtn2.GoodsNo) resList.Add("GoodsNo");
            if (acptAnOdrRemainRefCndtn1.GoodsNoSrchTyp != acptAnOdrRemainRefCndtn2.GoodsNoSrchTyp) resList.Add("GoodsNoSrchTyp");
            if (acptAnOdrRemainRefCndtn1.GoodsName != acptAnOdrRemainRefCndtn2.GoodsName) resList.Add("GoodsName");
            if (acptAnOdrRemainRefCndtn1.GoodsNmVagueSrch != acptAnOdrRemainRefCndtn2.GoodsNmVagueSrch) resList.Add("GoodsNmVagueSrch");
            if (acptAnOdrRemainRefCndtn1.EnterpriseName != acptAnOdrRemainRefCndtn2.EnterpriseName) resList.Add("EnterpriseName");
            if (acptAnOdrRemainRefCndtn1.SalesEmployeeNm != acptAnOdrRemainRefCndtn2.SalesEmployeeNm) resList.Add("SalesEmployeeNm");
            if (acptAnOdrRemainRefCndtn1.FullModelSrchTyp != acptAnOdrRemainRefCndtn2.FullModelSrchTyp) resList.Add("FullModelSrchTyp");

            return resList;
        }
    }
}

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   AcptAnOdrRemainRefCndtnWork
    /// <summary>
    ///                      �󒍎c�Ɖ�o�����N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �󒍎c�Ɖ�o�����N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/07/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class AcptAnOdrRemainRefCndtnWork
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
        private DateTime _st_SearchSlipDate;

        /// <summary>�`�[�������t�i�I���j</summary>
        /// <remarks>���͓�</remarks>
        private DateTime _ed_SearchSlipDate;

        /// <summary>������t(�J�n)</summary>
        /// <remarks>�󒍓�</remarks>
        private DateTime _st_SalesDate;

        /// <summary>������t(�I��)</summary>
        /// <remarks>�󒍓�</remarks>
        private DateTime _ed_SalesDate;

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

        /// <summary>�i��</summary>
        private string _goodsName = "";

        /// <summary>�i�������^�C�v</summary>
        /// <remarks>0:���S��v,1:�O����v����,2:�����v����,3:�B������</remarks>
        private Int32 _goodsNameSrchTyp;

        /// <summary>�i�Ԍ����^�C�v</summary>
        /// <remarks>0:���S��v,1:�O����v����,2:�����v����,3:�B������</remarks>
        private Int32 _goodsNoSrchTyp;

        /// <summary>�^�������^�C�v</summary>
        /// <remarks>0:���S��v,1:�O����v����,2:�����v����,3:�B������</remarks>
        private Int32 _fullModelSrchTyp;

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

        /// public propaty name  :  St_SearchSlipDate
        /// <summary>�`�[�������t�i�J�n�j�v���p�e�B</summary>
        /// <value>���͓�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�������t�i�J�n�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime St_SearchSlipDate
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
        public DateTime Ed_SearchSlipDate
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
        public DateTime St_SalesDate
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
        public DateTime Ed_SalesDate
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

        /// public propaty name  :  GoodsName
        /// <summary>�i���v���p�e�B</summary>
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

        /// public propaty name  :  GoodsNameSrchTyp
        /// <summary>�i�������^�C�v�v���p�e�B</summary>
        /// <value>0:���S��v,1:�O����v����,2:�����v����,3:�B������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�������^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsNameSrchTyp
        {
            get { return _goodsNameSrchTyp; }
            set { _goodsNameSrchTyp = value; }
        }

        /// public propaty name  :  GoodsNoSrchTyp
        /// <summary>�i�Ԍ����^�C�v�v���p�e�B</summary>
        /// <value>0:���S��v,1:�O����v����,2:�����v����,3:�B������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�Ԍ����^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsNoSrchTyp
        {
            get { return _goodsNoSrchTyp; }
            set { _goodsNoSrchTyp = value; }
        }

        /// public propaty name  :  FullModelSrchTyp
        /// <summary>�^�������^�C�v�v���p�e�B</summary>
        /// <value>0:���S��v,1:�O����v����,2:�����v����,3:�B������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�������^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FullModelSrchTyp
        {
            get { return _fullModelSrchTyp; }
            set { _fullModelSrchTyp = value; }
        }

        /// <summary>
        /// �󒍎c�Ɖ�o�����N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>AcptAnOdrRemainRefCndtnWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AcptAnOdrRemainRefCndtnWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public AcptAnOdrRemainRefCndtnWork()
        {
        }

    }

}

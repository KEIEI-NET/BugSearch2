using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/16 DEL
    # region // DEL
    ///// public class name:   CustPrtPprWork
    ///// <summary>
    /////                      ���Ӑ�d�q������������(�c���E�`�[�E����)���[�N
    ///// </summary>
    ///// <remarks>
    ///// <br>note             :   ���Ӑ�d�q������������(�c���E�`�[�E����)���[�N�w�b�_�t�@�C��</br>
    ///// <br>Programmer       :   ��������</br>
    ///// <br>Date             :   </br>
    ///// <br>Genarated Date   :   2009/01/06  (CSharp File Generated Date)</br>
    ///// <br>Update Note      :   </br>
    ///// </remarks>
    //[Serializable]
    //[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    //public class CustPrtPprWork
    //{
    //    /// <summary>�������</summary>
    //    /// <remarks>���������+1���Z�b�g</remarks>
    //    private Int64 _searchCnt;

    //    /// <summary>��ƃR�[�h</summary>
    //    /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
    //    private string _enterpriseCode = "";

    //    /// <summary>���_�R�[�h</summary>
    //    /// <remarks>(�z��)�@�S�Ўw���{""}</remarks>
    //    private string[] _sectionCode;

    //    /// <summary>���Ӑ�R�[�h</summary>
    //    private Int32 _customerCode;

    //    /// <summary>������R�[�h</summary>
    //    private Int32 _claimCode;

    //    /// <summary>�J�n������t</summary>
    //    /// <remarks>YYYYMMDD</remarks>
    //    private DateTime _st_SalesDate;

    //    /// <summary>�I��������t</summary>
    //    /// <remarks>YYYYMMDD</remarks>
    //    private DateTime _ed_SalesDate;

    //    /// <summary>�J�n���͓��t</summary>
    //    /// <remarks>YYYYMMDD</remarks>
    //    private DateTime _st_AddUpADate;

    //    /// <summary>�I�����͓��t</summary>
    //    /// <remarks>YYYYMMDD</remarks>
    //    private DateTime _ed_AddUpADate;

    //    /// <summary>�v��N��</summary>
    //    /// <remarks>���Ӑ搿�����z�}�X�^ �v��N�� YYYYMM</remarks>
    //    private DateTime _addUpYearMonth;

    //    /// <summary>�󒍃X�e�[�^�X</summary>
    //    /// <remarks>(�z��)�@�S�w��̏ꍇ��{""}</remarks>
    //    private Int32[] _acptAnOdrStatus;

    //    /// <summary>����`�[�敪</summary>
    //    /// <remarks>(�z��)�@�S�w��̏ꍇ��{""}</remarks>
    //    private Int32[] _salesSlipCd;

    //    /// <summary>�`�[�ԍ�</summary>
    //    /// <remarks>����`�[�ԍ�</remarks>
    //    private string _salesSlipNum = "";

    //    /// <summary>�S����</summary>
    //    /// <remarks>�̔��]�ƈ��R�[�h</remarks>
    //    private string _salesEmployeeCd = "";

    //    /// <summary>�󒍎�</summary>
    //    /// <remarks>��t�]�ƈ��R�[�h</remarks>
    //    private string _frontEmployeeCd = "";

    //    /// <summary>���s��</summary>
    //    /// <remarks>������͎҃R�[�h</remarks>
    //    private string _salesInputCode = "";

    //    /// <summary>�Ǘ��ԍ�</summary>
    //    /// <remarks>���q�Ǘ��R�[�h</remarks>
    //    private string _carMngCode = "";

    //    /// <summary>�Ԏ햼��</summary>
    //    /// <remarks>�Ԏ�S�p����</remarks>
    //    private string _modelFullName = "";

    //    /// <summary>�^��</summary>
    //    /// <remarks>�^���i�t���^�j</remarks>
    //    private string _fullModel = "";

    //    /// <summary>�ԑ䇂</summary>
    //    /// <remarks>�ԑ�ԍ��i�����p�j</remarks>
    //    private Int32 _searchFrameNo;

    //    /// <summary>���Ӑ撍��</summary>
    //    /// <remarks>�����`�[�ԍ�</remarks>
    //    private string _partySaleSlipNum = "";

    //    /// <summary>�J���[����</summary>
    //    /// <remarks>�J���[����1</remarks>
    //    private string _colorName1 = "";

    //    /// <summary>�g��������</summary>
    //    /// <remarks>�g��������</remarks>
    //    private string _trimName = "";

    //    /// <summary>�t�n�d���M</summary>
    //    /// <remarks>UOE�����f�[�^�̃f�[�^���M�敪</remarks>
    //    private Int32 _dataSendCode;

    //    /// <summary>���l�P</summary>
    //    /// <remarks>�`�[���l</remarks>
    //    private string _slipNote = "";

    //    /// <summary>���l�Q</summary>
    //    /// <remarks>�`�[���l�Q</remarks>
    //    private string _slipNote2 = "";

    //    /// <summary>���l�R</summary>
    //    /// <remarks>�`�[���l�R</remarks>
    //    private string _slipNote3 = "";

    //    /// <summary>�t�n�d���}�[�N�P</summary>
    //    /// <remarks>�t�n�d���}�[�N�P</remarks>
    //    private string _uoeRemark1 = "";

    //    /// <summary>�t�n�d���}�[�N�Q</summary>
    //    /// <remarks>�t�n�d���}�[�N�Q</remarks>
    //    private string _uoeRemark2 = "";

    //    /// <summary>�a�k�O���[�v</summary>
    //    /// <remarks>BL�O���[�v�R�[�h</remarks>
    //    private Int32 _bLGroupCode;

    //    /// <summary>�a�k�R�[�h</summary>
    //    /// <remarks>BL���i�R�[�h</remarks>
    //    private Int32 _bLGoodsCode;

    //    /// <summary>�i��</summary>
    //    /// <remarks>���i����</remarks>
    //    private string _goodsName = "";

    //    /// <summary>�i��</summary>
    //    /// <remarks>���i�ԍ�</remarks>
    //    private string _goodsNo = "";

    //    /// <summary>���[�J�[�R�[�h</summary>
    //    /// <remarks>���i���[�J�[�R�[�h</remarks>
    //    private Int32 _goodsMakerCd;

    //    /// <summary>�̔��敪�R�[�h</summary>
    //    /// <remarks>�̔��敪�R�[�h</remarks>
    //    private Int32 _salesCode;

    //    /// <summary>���Е��ރR�[�h</summary>
    //    /// <remarks>���Е��ރR�[�h</remarks>
    //    private Int32 _enterpriseGanreCode;

    //    /// <summary>�݌Ɏ��敪</summary>
    //    /// <remarks>����݌Ɏ�񂹋敪(-1:�S�� 0:��� 1:�݌�)</remarks>
    //    private Int32 _salesOrderDivCd;

    //    /// <summary>�q�ɃR�[�h</summary>
    //    /// <remarks>�q�ɃR�[�h</remarks>
    //    private string _warehouseCode = "";

    //    /// <summary>�d���`�[�ԍ�</summary>
    //    /// <remarks>�d���f�[�^�̑����`�[�ԍ�</remarks>
    //    private string _supplierSlipNo = "";

    //    /// <summary>�d����</summary>
    //    /// <remarks>�d����R�[�h</remarks>
    //    private Int32 _supplierCd;

    //    /// <summary>������</summary>
    //    /// <remarks>UOE�����f�[�^�̎d����R�[�h</remarks>
    //    private Int32 _uOESupplierCd;

    //    /// <summary>���ה��l</summary>
    //    /// <remarks>���ה��l</remarks>
    //    private string _dtlNote = "";

    //    /// <summary>�`�[�����敪</summary>
    //    /// <remarks>0:�S�� 1:����̂� 2:�����̂�</remarks>
    //    private Int32 _searchType;

    //    /// <summary>�[�i��R�[�h</summary>
    //    private Int32 _addresseeCode;


    //    /// public propaty name  :  SearchCnt
    //    /// <summary>��������v���p�e�B</summary>
    //    /// <value>���������+1���Z�b�g</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ��������v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 SearchCnt
    //    {
    //        get{return _searchCnt;}
    //        set{_searchCnt = value;}
    //    }

    //    /// public propaty name  :  EnterpriseCode
    //    /// <summary>��ƃR�[�h�v���p�e�B</summary>
    //    /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string EnterpriseCode
    //    {
    //        get{return _enterpriseCode;}
    //        set{_enterpriseCode = value;}
    //    }

    //    /// public propaty name  :  SectionCode
    //    /// <summary>���_�R�[�h�v���p�e�B</summary>
    //    /// <value>(�z��)�@�S�Ўw���{""}</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string[] SectionCode
    //    {
    //        get{return _sectionCode;}
    //        set{_sectionCode = value;}
    //    }

    //    /// public propaty name  :  CustomerCode
    //    /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 CustomerCode
    //    {
    //        get{return _customerCode;}
    //        set{_customerCode = value;}
    //    }

    //    /// public propaty name  :  ClaimCode
    //    /// <summary>������R�[�h�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ������R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 ClaimCode
    //    {
    //        get{return _claimCode;}
    //        set{_claimCode = value;}
    //    }

    //    /// public propaty name  :  St_SalesDate
    //    /// <summary>�J�n������t�v���p�e�B</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �J�n������t�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public DateTime St_SalesDate
    //    {
    //        get{return _st_SalesDate;}
    //        set{_st_SalesDate = value;}
    //    }

    //    /// public propaty name  :  Ed_SalesDate
    //    /// <summary>�I��������t�v���p�e�B</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �I��������t�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public DateTime Ed_SalesDate
    //    {
    //        get{return _ed_SalesDate;}
    //        set{_ed_SalesDate = value;}
    //    }

    //    /// public propaty name  :  St_AddUpADate
    //    /// <summary>�J�n���͓��t�v���p�e�B</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �J�n���͓��t�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public DateTime St_AddUpADate
    //    {
    //        get{return _st_AddUpADate;}
    //        set{_st_AddUpADate = value;}
    //    }

    //    /// public propaty name  :  Ed_AddUpADate
    //    /// <summary>�I�����͓��t�v���p�e�B</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �I�����͓��t�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public DateTime Ed_AddUpADate
    //    {
    //        get{return _ed_AddUpADate;}
    //        set{_ed_AddUpADate = value;}
    //    }

    //    /// public propaty name  :  AddUpYearMonth
    //    /// <summary>�v��N���v���p�e�B</summary>
    //    /// <value>���Ӑ搿�����z�}�X�^ �v��N�� YYYYMM</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �v��N���v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public DateTime AddUpYearMonth
    //    {
    //        get{return _addUpYearMonth;}
    //        set{_addUpYearMonth = value;}
    //    }

    //    /// public propaty name  :  AcptAnOdrStatus
    //    /// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
    //    /// <value>(�z��)�@�S�w��̏ꍇ��{""}</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32[] AcptAnOdrStatus
    //    {
    //        get{return _acptAnOdrStatus;}
    //        set{_acptAnOdrStatus = value;}
    //    }

    //    /// public propaty name  :  SalesSlipCd
    //    /// <summary>����`�[�敪�v���p�e�B</summary>
    //    /// <value>(�z��)�@�S�w��̏ꍇ��{""}</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����`�[�敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32[] SalesSlipCd
    //    {
    //        get{return _salesSlipCd;}
    //        set{_salesSlipCd = value;}
    //    }

    //    /// public propaty name  :  SalesSlipNum
    //    /// <summary>�`�[�ԍ��v���p�e�B</summary>
    //    /// <value>����`�[�ԍ�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �`�[�ԍ��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SalesSlipNum
    //    {
    //        get{return _salesSlipNum;}
    //        set{_salesSlipNum = value;}
    //    }

    //    /// public propaty name  :  SalesEmployeeCd
    //    /// <summary>�S���҃v���p�e�B</summary>
    //    /// <value>�̔��]�ƈ��R�[�h</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �S���҃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SalesEmployeeCd
    //    {
    //        get{return _salesEmployeeCd;}
    //        set{_salesEmployeeCd = value;}
    //    }

    //    /// public propaty name  :  FrontEmployeeCd
    //    /// <summary>�󒍎҃v���p�e�B</summary>
    //    /// <value>��t�]�ƈ��R�[�h</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �󒍎҃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string FrontEmployeeCd
    //    {
    //        get{return _frontEmployeeCd;}
    //        set{_frontEmployeeCd = value;}
    //    }

    //    /// public propaty name  :  SalesInputCode
    //    /// <summary>���s�҃v���p�e�B</summary>
    //    /// <value>������͎҃R�[�h</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���s�҃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SalesInputCode
    //    {
    //        get{return _salesInputCode;}
    //        set{_salesInputCode = value;}
    //    }

    //    /// public propaty name  :  CarMngCode
    //    /// <summary>�Ǘ��ԍ��v���p�e�B</summary>
    //    /// <value>���q�Ǘ��R�[�h</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �Ǘ��ԍ��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string CarMngCode
    //    {
    //        get{return _carMngCode;}
    //        set{_carMngCode = value;}
    //    }

    //    /// public propaty name  :  ModelFullName
    //    /// <summary>�Ԏ햼�̃v���p�e�B</summary>
    //    /// <value>�Ԏ�S�p����</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �Ԏ햼�̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string ModelFullName
    //    {
    //        get{return _modelFullName;}
    //        set{_modelFullName = value;}
    //    }

    //    /// public propaty name  :  FullModel
    //    /// <summary>�^���v���p�e�B</summary>
    //    /// <value>�^���i�t���^�j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �^���v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string FullModel
    //    {
    //        get{return _fullModel;}
    //        set{_fullModel = value;}
    //    }

    //    /// public propaty name  :  SearchFrameNo
    //    /// <summary>�ԑ䇂�v���p�e�B</summary>
    //    /// <value>�ԑ�ԍ��i�����p�j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �ԑ䇂�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 SearchFrameNo
    //    {
    //        get{return _searchFrameNo;}
    //        set{_searchFrameNo = value;}
    //    }

    //    /// public propaty name  :  PartySaleSlipNum
    //    /// <summary>���Ӑ撍�ԃv���p�e�B</summary>
    //    /// <value>�����`�[�ԍ�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���Ӑ撍�ԃv���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string PartySaleSlipNum
    //    {
    //        get{return _partySaleSlipNum;}
    //        set{_partySaleSlipNum = value;}
    //    }

    //    /// public propaty name  :  ColorName1
    //    /// <summary>�J���[���̃v���p�e�B</summary>
    //    /// <value>�J���[����1</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �J���[���̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string ColorName1
    //    {
    //        get{return _colorName1;}
    //        set{_colorName1 = value;}
    //    }

    //    /// public propaty name  :  TrimName
    //    /// <summary>�g�������̃v���p�e�B</summary>
    //    /// <value>�g��������</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �g�������̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string TrimName
    //    {
    //        get{return _trimName;}
    //        set{_trimName = value;}
    //    }

    //    /// public propaty name  :  DataSendCode
    //    /// <summary>�t�n�d���M�v���p�e�B</summary>
    //    /// <value>UOE�����f�[�^�̃f�[�^���M�敪</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �t�n�d���M�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 DataSendCode
    //    {
    //        get{return _dataSendCode;}
    //        set{_dataSendCode = value;}
    //    }

    //    /// public propaty name  :  SlipNote
    //    /// <summary>���l�P�v���p�e�B</summary>
    //    /// <value>�`�[���l</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���l�P�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SlipNote
    //    {
    //        get{return _slipNote;}
    //        set{_slipNote = value;}
    //    }

    //    /// public propaty name  :  SlipNote2
    //    /// <summary>���l�Q�v���p�e�B</summary>
    //    /// <value>�`�[���l�Q</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���l�Q�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SlipNote2
    //    {
    //        get{return _slipNote2;}
    //        set{_slipNote2 = value;}
    //    }

    //    /// public propaty name  :  SlipNote3
    //    /// <summary>���l�R�v���p�e�B</summary>
    //    /// <value>�`�[���l�R</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���l�R�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SlipNote3
    //    {
    //        get{return _slipNote3;}
    //        set{_slipNote3 = value;}
    //    }

    //    /// public propaty name  :  UoeRemark1
    //    /// <summary>�t�n�d���}�[�N�P�v���p�e�B</summary>
    //    /// <value>�t�n�d���}�[�N�P</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �t�n�d���}�[�N�P�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string UoeRemark1
    //    {
    //        get{return _uoeRemark1;}
    //        set{_uoeRemark1 = value;}
    //    }

    //    /// public propaty name  :  UoeRemark2
    //    /// <summary>�t�n�d���}�[�N�Q�v���p�e�B</summary>
    //    /// <value>�t�n�d���}�[�N�Q</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �t�n�d���}�[�N�Q�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string UoeRemark2
    //    {
    //        get{return _uoeRemark2;}
    //        set{_uoeRemark2 = value;}
    //    }

    //    /// public propaty name  :  BLGroupCode
    //    /// <summary>�a�k�O���[�v�v���p�e�B</summary>
    //    /// <value>BL�O���[�v�R�[�h</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �a�k�O���[�v�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 BLGroupCode
    //    {
    //        get{return _bLGroupCode;}
    //        set{_bLGroupCode = value;}
    //    }

    //    /// public propaty name  :  BLGoodsCode
    //    /// <summary>�a�k�R�[�h�v���p�e�B</summary>
    //    /// <value>BL���i�R�[�h</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �a�k�R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 BLGoodsCode
    //    {
    //        get{return _bLGoodsCode;}
    //        set{_bLGoodsCode = value;}
    //    }

    //    /// public propaty name  :  GoodsName
    //    /// <summary>�i���v���p�e�B</summary>
    //    /// <value>���i����</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �i���v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string GoodsName
    //    {
    //        get{return _goodsName;}
    //        set{_goodsName = value;}
    //    }

    //    /// public propaty name  :  GoodsNo
    //    /// <summary>�i�ԃv���p�e�B</summary>
    //    /// <value>���i�ԍ�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �i�ԃv���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string GoodsNo
    //    {
    //        get{return _goodsNo;}
    //        set{_goodsNo = value;}
    //    }

    //    /// public propaty name  :  GoodsMakerCd
    //    /// <summary>���[�J�[�R�[�h�v���p�e�B</summary>
    //    /// <value>���i���[�J�[�R�[�h</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���[�J�[�R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 GoodsMakerCd
    //    {
    //        get{return _goodsMakerCd;}
    //        set{_goodsMakerCd = value;}
    //    }

    //    /// public propaty name  :  SalesCode
    //    /// <summary>�̔��敪�R�[�h�v���p�e�B</summary>
    //    /// <value>�̔��敪�R�[�h</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �̔��敪�R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 SalesCode
    //    {
    //        get{return _salesCode;}
    //        set{_salesCode = value;}
    //    }

    //    /// public propaty name  :  EnterpriseGanreCode
    //    /// <summary>���Е��ރR�[�h�v���p�e�B</summary>
    //    /// <value>���Е��ރR�[�h</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���Е��ރR�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 EnterpriseGanreCode
    //    {
    //        get{return _enterpriseGanreCode;}
    //        set{_enterpriseGanreCode = value;}
    //    }

    //    /// public propaty name  :  SalesOrderDivCd
    //    /// <summary>�݌Ɏ��敪�v���p�e�B</summary>
    //    /// <value>����݌Ɏ�񂹋敪(-1:�S�� 0:��� 1:�݌�)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �݌Ɏ��敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 SalesOrderDivCd
    //    {
    //        get{return _salesOrderDivCd;}
    //        set{_salesOrderDivCd = value;}
    //    }

    //    /// public propaty name  :  WarehouseCode
    //    /// <summary>�q�ɃR�[�h�v���p�e�B</summary>
    //    /// <value>�q�ɃR�[�h</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �q�ɃR�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string WarehouseCode
    //    {
    //        get{return _warehouseCode;}
    //        set{_warehouseCode = value;}
    //    }

    //    /// public propaty name  :  SupplierSlipNo
    //    /// <summary>�d���`�[�ԍ��v���p�e�B</summary>
    //    /// <value>�d���f�[�^�̑����`�[�ԍ�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �d���`�[�ԍ��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SupplierSlipNo
    //    {
    //        get{return _supplierSlipNo;}
    //        set{_supplierSlipNo = value;}
    //    }

    //    /// public propaty name  :  SupplierCd
    //    /// <summary>�d����v���p�e�B</summary>
    //    /// <value>�d����R�[�h</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �d����v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 SupplierCd
    //    {
    //        get{return _supplierCd;}
    //        set{_supplierCd = value;}
    //    }

    //    /// public propaty name  :  UOESupplierCd
    //    /// <summary>������v���p�e�B</summary>
    //    /// <value>UOE�����f�[�^�̎d����R�[�h</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ������v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 UOESupplierCd
    //    {
    //        get{return _uOESupplierCd;}
    //        set{_uOESupplierCd = value;}
    //    }

    //    /// public propaty name  :  DtlNote
    //    /// <summary>���ה��l�v���p�e�B</summary>
    //    /// <value>���ה��l</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���ה��l�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string DtlNote
    //    {
    //        get{return _dtlNote;}
    //        set{_dtlNote = value;}
    //    }

    //    /// public propaty name  :  SearchType
    //    /// <summary>�`�[�����敪�v���p�e�B</summary>
    //    /// <value>0:�S�� 1:����̂� 2:�����̂�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �`�[�����敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 SearchType
    //    {
    //        get{return _searchType;}
    //        set{_searchType = value;}
    //    }

    //    /// public propaty name  :  AddresseeCode
    //    /// <summary>�[�i��R�[�h�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �[�i��R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 AddresseeCode
    //    {
    //        get{return _addresseeCode;}
    //        set{_addresseeCode = value;}
    //    }


    //    /// <summary>
    //    /// ���Ӑ�d�q������������(�c���E�`�[�E����)���[�N�R���X�g���N�^
    //    /// </summary>
    //    /// <returns>CustPrtPprWork�N���X�̃C���X�^���X</returns>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   CustPrtPprWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public CustPrtPprWork()
    //    {
    //    }

    //}
    # endregion
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/16 DEL

    /// public class name:   CustPrtPprWork
    /// <summary>
    ///                      ���Ӑ�d�q������������(�c���E�`�[�E����)���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���Ӑ�d�q������������(�c���E�`�[�E����)���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/04/16  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2010/08/05 ������ �ԑ�ԍ��̒ǉ�</br>
    /// <br>Update Note      :   2011/07/18 zhubj �񓚋敪�̒ǉ�</br>
    /// <br>Update Note      :   2011/11/28 �k�m redmine#8172�̒ǉ�</br>
    /// <br>Update Note      :   K2015/06/16 鸏�</br>
    /// <br>�Ǘ��ԍ�         :   11101427-00</br>
    /// <br>                 :   ���C�S�����Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����B</br>
    /// <br>Update Note      :   2015/02/05 ������ �e�L�X�g�o�͌��������Ȃ����[�h�̒ǉ�</br>
    /// <br>Update Note      :   2016/01/21 �e�c ���V</br>
    /// <br>�Ǘ��ԍ�         :   11270007-00 �d�|�ꗗ��2808 �ݏo�󒍑Ή�</br>
    /// <br>                 :   �@���������Ɂu�o�׏󋵁v���ڂ�ǉ�</br>
    /// <br>                 :   �A���ו\���Ɍv�㐔�A���v�㐔���ڂ�ǉ�</br>
    /// <br>Update Note      :   K2016/02/23 ���V��</br>
    /// <br>�Ǘ��ԍ�         :   11200090-00 �C�P�� ���Ӑ�d�q����</br>
    /// <br>                     ���C�P���g ���o�����ɂĎ󒍍쐬�敪��ǉ�����Ή�</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CustPrtPprWork
    {
        /// <summary>�������</summary>
        /// <remarks>���������+1���Z�b�g</remarks>
        private Int64 _searchCnt;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        /// <remarks>(�z��)�@�S�Ўw���{""}</remarks>
        private string[] _sectionCode;

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>������R�[�h</summary>
        private Int32 _claimCode;

        /// <summary>�J�n������t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _st_SalesDate;

        /// <summary>�I��������t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _ed_SalesDate;

        /// <summary>�J�n���͓��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _st_AddUpADate;

        /// <summary>�I�����͓��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _ed_AddUpADate;

        /// <summary>�v��N��</summary>
        /// <remarks>���Ӑ搿�����z�}�X�^ �v��N�� YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>�󒍃X�e�[�^�X</summary>
        /// <remarks>(�z��)�@�S�w��̏ꍇ��{""}</remarks>
        private Int32[] _acptAnOdrStatus;

        /// <summary>����`�[�敪</summary>
        /// <remarks>(�z��)�@�S�w��̏ꍇ��{""}</remarks>
        private Int32[] _salesSlipCd;

        /// <summary>����`�[�ԍ�</summary>
        /// <remarks>����`�[�ԍ�</remarks>
        private string _salesSlipNum = "";

        /// <summary>�̔��]�ƈ��R�[�h</summary>
        /// <remarks>�̔��]�ƈ��R�[�h</remarks>
        private string _salesEmployeeCd = "";

        /// <summary>��t�]�ƈ��R�[�h</summary>
        /// <remarks>��t�]�ƈ��R�[�h</remarks>
        private string _frontEmployeeCd = "";

        /// <summary>������͎҃R�[�h</summary>
        /// <remarks>������͎҃R�[�h</remarks>
        private string _salesInputCode = "";

        /// <summary>�ԗ��Ǘ��R�[�h</summary>
        /// <remarks>���q�Ǘ��R�[�h</remarks>
        private string _carMngCode = "";

        /// <summary>�Ԏ�S�p����</summary>
        /// <remarks>�Ԏ�S�p����</remarks>
        private string _modelFullName = "";

        /// <summary>�^���i�t���^�j</summary>
        /// <remarks>�^���i�t���^�j</remarks>
        private string _fullModel = "";

        /// <summary>�ԑ䇂</summary>
        /// <remarks>�ԑ�ԍ��i�����p�j</remarks>
        private Int32 _searchFrameNo;

        // -----------ADD 2010/08/05----------->>>>>
        /// <summary>�ԑ䇂</summary>
        /// <remarks>�ԑ�ԍ�</remarks>
        private string _frameNo;
        // -----------ADD 2010/08/05-----------<<<<<

        /// <summary>�����`�[�ԍ�</summary>
        /// <remarks>�����`�[�ԍ�</remarks>
        private string _partySaleSlipNum = "";

        /// <summary>�J���[����1</summary>
        /// <remarks>�J���[����1</remarks>
        private string _colorName1 = "";

        /// <summary>�g��������</summary>
        /// <remarks>�g��������</remarks>
        private string _trimName = "";

        /// <summary>�f�[�^���M�敪</summary>
        /// <remarks>UOE�����f�[�^�̃f�[�^���M�敪</remarks>
        private Int32 _dataSendCode;

        /// <summary>�`�[���l</summary>
        /// <remarks>�`�[���l</remarks>
        private string _slipNote = "";

        /// <summary>�`�[���l�Q</summary>
        /// <remarks>�`�[���l�Q</remarks>
        private string _slipNote2 = "";

        /// <summary>�`�[���l�R</summary>
        /// <remarks>�`�[���l�R</remarks>
        private string _slipNote3 = "";

        /// <summary>�t�n�d���}�[�N�P</summary>
        /// <remarks>�t�n�d���}�[�N�P</remarks>
        private string _uoeRemark1 = "";

        /// <summary>�t�n�d���}�[�N�Q</summary>
        /// <remarks>�t�n�d���}�[�N�Q</remarks>
        private string _uoeRemark2 = "";

        /// <summary>BL�O���[�v�R�[�h</summary>
        /// <remarks>BL�O���[�v�R�[�h</remarks>
        private Int32 _bLGroupCode;

        /// <summary>BL���i�R�[�h</summary>
        /// <remarks>BL���i�R�[�h</remarks>
        private Int32 _bLGoodsCode;

        /// <summary>���i����</summary>
        /// <remarks>���i����</remarks>
        private string _goodsName = "";

        /// <summary>���i�ԍ�</summary>
        /// <remarks>���i�ԍ�</remarks>
        private string _goodsNo = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        /// <remarks>���i���[�J�[�R�[�h</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>�̔��敪�R�[�h</summary>
        /// <remarks>�̔��敪�R�[�h</remarks>
        private Int32 _salesCode;

        /// <summary>���Е��ރR�[�h</summary>
        /// <remarks>���Е��ރR�[�h</remarks>
        private Int32 _enterpriseGanreCode;

        /// <summary>����݌Ɏ�񂹋敪</summary>
        /// <remarks>����݌Ɏ�񂹋敪(-1:�S�� 0:��� 1:�݌�)</remarks>
        private Int32 _salesOrderDivCd;

        /// <summary>�q�ɃR�[�h</summary>
        /// <remarks>�q�ɃR�[�h</remarks>
        private string _warehouseCode = "";

        /// <summary>�d���`�[�ԍ�</summary>
        /// <remarks>�d���f�[�^�̑����`�[�ԍ�</remarks>
        private string _supplierSlipNo;

        /// <summary>�d����R�[�h</summary>
        /// <remarks>�d����R�[�h</remarks>
        private Int32 _supplierCd;

        /// <summary>UOE������R�[�h</summary>
        /// <remarks>UOE�����f�[�^�̎d����R�[�h</remarks>
        private Int32 _uOESupplierCd;

        /// <summary>���ה��l</summary>
        /// <remarks>���ה��l</remarks>
        private string _dtlNote = "";

        /// <summary>�`�[�����敪</summary>
        /// <remarks>0:�S�� 1:����̂� 2:�����̂�</remarks>
        private Int32 _searchType;

        /// <summary>�[�i��R�[�h</summary>
        private Int32 _addresseeCode;

        /// <summary>���i����</summary>
        /// <remarks>0:���� 1:�D��</remarks>
        private Int32 _goodsKindCode;

        /// <summary>���i�啪�ރR�[�h</summary>
        /// <remarks>���啪�ށi���[�U�[�K�C�h�j</remarks>
        private Int32 _goodsLGroup;

        /// <summary>���i�����ރR�[�h</summary>
        /// <remarks>�������ރR�[�h</remarks>
        private Int32 _goodsMGroup;

        /// <summary>�q�ɒI��</summary>
        private string _warehouseShelfNo = "";

        /// <summary>����`�[�敪�i���ׁj</summary>
        /// <remarks>0:����,1:�ԕi,2:�l��,3:����,4:���v,5:���</remarks>
        private Int32 _salesSlipCdDtl;

        // ---------------------- ADD START 2011/07/18 zhubj ----------------->>>>>
        /// <summary>�����񓚋敪(SCM)</summary>
        /// <remarks>0:�ʏ�(PCC�A�g�Ȃ�)�A1:�蓮�񓚁A2:������</remarks>
        private Int32 _autoAnswerDivSCM;

        //---ADD START 2011/11/28 �k�m ----------------------------------->>>>>
        /// <summary>�⍇���ԍ�</summary>
        private Int64 _inquiryNumber;
       
        //----- ADD 2015/02/05 ������ -------------------->>>>>
        /// <summary>���o��������</summary>
        /// <remarks>0:���o������������A1:���o���������Ȃ�</remarks>
        private Int32 _searchCountCtrl;

        /// <summary>�J�n���t/�I�����t</summary>
        /// <remarks>0:�J�n���t�A1:�I�����t</remarks>
        private Int32 _searchSalDateStEd;
        //----- ADD 2015/02/05 ������ --------------------<<<<<

        //----- ADD 2015/03/03 ������ Redmine#44701 ---------->>>>>
        /// <summary>���t�����^�C�v</summary>
        /// <remarks>0:����f�[�^����A1:�����f�[�^����</remarks>
        private Int32 _searchSalDateType;
        //----- ADD 2015/03/03 ������ Redmine#44701 ----------<<<<<

        //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����----->>>>>
        /// <summary>�̔��G���A�R�[�h</summary>
        private Int32 _salesAreaCode;

        /// <summary>���Ӑ敪�̓R�[�h1</summary>
        private Int32 _custAnalysCode1;

        /// <summary>���Ӑ敪�̓R�[�h2</summary>
        private Int32 _custAnalysCode2;

        /// <summary>���Ӑ敪�̓R�[�h3</summary>
        private Int32 _custAnalysCode3;

        /// <summary>���Ӑ敪�̓R�[�h4</summary>
        private Int32 _custAnalysCode4;

        /// <summary>���Ӑ敪�̓R�[�h5</summary>
        private Int32 _custAnalysCode5;

        /// <summary>���Ӑ敪�̓R�[�h6</summary>
        private Int32 _custAnalysCode6;

    
        /// public propaty name  :  SalesAreaCode
        /// <summary>�n��ԍ�</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��G���A�R�[�h</br>
        /// <br>Programer        :   鸏�</br>
        /// </remarks>
        public Int32 SalesAreaCode
        {
            get { return _salesAreaCode; }
            set { _salesAreaCode = value; }
        }

        /// public propaty name  :  CustAnalysCode1
        /// <summary>���Ӑ敪�̓R�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ敪�̓R�[�h1</br>
        /// <br>Programer        :   鸏�</br>
        /// </remarks>
        public Int32 CustAnalysCode1
        {
            get { return _custAnalysCode1; }
            set { _custAnalysCode1 = value; }
        }

        /// public propaty name  :  CustAnalysCode2
        /// <summary>���Ӑ敪�̓R�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ敪�̓R�[�h2</br>
        /// <br>Programer        :   鸏�</br>
        /// </remarks>
        public Int32 CustAnalysCode2
        {
            get { return _custAnalysCode2; }
            set { _custAnalysCode2 = value; }
        }

        /// public propaty name  :  CustAnalysCode3
        /// <summary>���Ӑ敪�̓R�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ敪�̓R�[�h3</br>
        /// <br>Programer        :   鸏�</br>
        /// </remarks>
        public Int32 CustAnalysCode3
        {
            get { return _custAnalysCode3; }
            set { _custAnalysCode3 = value; }
        }

        /// public propaty name  :  CustAnalysCode4
        /// <summary>���Ӑ敪�̓R�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ敪�̓R�[�h4</br>
        /// <br>Programer        :   鸏�</br>
        /// </remarks>
        public Int32 CustAnalysCode4
        {
            get { return _custAnalysCode4; }
            set { _custAnalysCode4 = value; }
        }

        /// public propaty name  :  CustAnalysCode5
        /// <summary>���Ӑ敪�̓R�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ敪�̓R�[�h5</br>
        /// <br>Programer        :   鸏�</br>
        /// </remarks>
        public Int32 CustAnalysCode5
        {
            get { return _custAnalysCode5; }
            set { _custAnalysCode5 = value; }
        }

        /// public propaty name  :  CustAnalysCode6
        /// <summary>���Ӑ敪�̓R�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ敪�̓R�[�h6</br>
        /// <br>Programer        :   鸏�</br>
        /// </remarks>
        public Int32 CustAnalysCode6
        {
            get { return _custAnalysCode6; }
            set { _custAnalysCode6 = value; }
        }
        //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����-----<<<<<

        // ---------- ADD 2016/01/21 Y.Wakita ---------->>>>>
        /// <summary>�o�׏�</summary>
        /// <remarks>0:�S�āA1:���v�㕪�A2:�v��ςݕ�</remarks>
        private Int32 _addUpRemDiv;
        // ---------- ADD 2016/01/21 Y.Wakita ----------<<<<<
        
        /// public propaty name  :  InquiryNumber
        /// <summary>�⍇���ԍ��v���p�e�B�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���ԍ��v���p�e�B</br>
        /// <br>Programer        :   �k�m</br>
        /// </remarks>
        public Int64 InquiryNumber
        {
            get { return _inquiryNumber; }
            set { _inquiryNumber = value; }
        }
        //---ADD END 2011/11/28 �k�m -----------------------------------<<<<<

        //----- ADD K2016/02/23 ���V�� ���C�P���g ���o�����ɂĎ󒍍쐬�敪��ǉ�����Ή� ----->>>>>
        /// <summary>�󒍍쐬�敪</summary>
        /// <remarks>0:�S�āA1:�ʏ�󒍓`�[�A2:�`��UOE�󒍓`�[</remarks>
        private Int32 _acptAnOdrMakeDiv;

        /// public propaty name  :  AcptAnOdrMakeDiv
        /// <summary>�󒍍쐬�敪�v���p�e�B</summary>
        /// <value>0:�S�āA1:�ʏ�󒍓`�[�A2:�`��UOE�󒍓`�[</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍍쐬�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcptAnOdrMakeDiv
        {
            get { return _acptAnOdrMakeDiv; }
            set { _acptAnOdrMakeDiv = value; }
        }
        //----- ADD K2016/02/23 ���V�� ���C�P���g ���o�����ɂĎ󒍍쐬�敪��ǉ�����Ή� -----<<<<<


        /// public propaty name  :  AutoAnswerDivSCM
        /// <summary>�����񓚋敪(SCM)�v���p�e�B</summary>
        /// <value>1:�ʏ�(PCC�A�g�Ȃ�)�A2:�蓮�񓚁A3:������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����񓚋敪(SCM)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AutoAnswerDivSCM
        {
            get { return _autoAnswerDivSCM; }
            set { _autoAnswerDivSCM = value; }
        }
        // ---------------------- ADD END   2011/07/18 zhubj -----------------<<<<<

        /// public propaty name  :  SearchCnt
        /// <summary>��������v���p�e�B</summary>
        /// <value>���������+1���Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SearchCnt
        {
            get { return _searchCnt; }
            set { _searchCnt = value; }
        }

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
        /// <value>(�z��)�@�S�Ўw���{""}</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] SectionCode
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

        /// public propaty name  :  St_SalesDate
        /// <summary>�J�n������t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime St_SalesDate
        {
            get { return _st_SalesDate; }
            set { _st_SalesDate = value; }
        }

        /// public propaty name  :  Ed_SalesDate
        /// <summary>�I��������t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I��������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime Ed_SalesDate
        {
            get { return _ed_SalesDate; }
            set { _ed_SalesDate = value; }
        }

        /// public propaty name  :  St_AddUpADate
        /// <summary>�J�n���͓��t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���͓��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime St_AddUpADate
        {
            get { return _st_AddUpADate; }
            set { _st_AddUpADate = value; }
        }

        /// public propaty name  :  Ed_AddUpADate
        /// <summary>�I�����͓��t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����͓��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime Ed_AddUpADate
        {
            get { return _ed_AddUpADate; }
            set { _ed_AddUpADate = value; }
        }

        /// public propaty name  :  AddUpYearMonth
        /// <summary>�v��N���v���p�e�B</summary>
        /// <value>���Ӑ搿�����z�}�X�^ �v��N�� YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AddUpYearMonth
        {
            get { return _addUpYearMonth; }
            set { _addUpYearMonth = value; }
        }

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
        /// <value>(�z��)�@�S�w��̏ꍇ��{""}</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32[] AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// public propaty name  :  SalesSlipCd
        /// <summary>����`�[�敪�v���p�e�B</summary>
        /// <value>(�z��)�@�S�w��̏ꍇ��{""}</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32[] SalesSlipCd
        {
            get { return _salesSlipCd; }
            set { _salesSlipCd = value; }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>����`�[�ԍ��v���p�e�B</summary>
        /// <value>����`�[�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }

        /// public propaty name  :  SalesEmployeeCd
        /// <summary>�̔��]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�̔��]�ƈ��R�[�h</value>
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

        /// public propaty name  :  FrontEmployeeCd
        /// <summary>��t�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>��t�]�ƈ��R�[�h</value>
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

        /// public propaty name  :  SalesInputCode
        /// <summary>������͎҃R�[�h�v���p�e�B</summary>
        /// <value>������͎҃R�[�h</value>
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

        /// public propaty name  :  CarMngCode
        /// <summary>�ԗ��Ǘ��R�[�h�v���p�e�B</summary>
        /// <value>���q�Ǘ��R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԗ��Ǘ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CarMngCode
        {
            get { return _carMngCode; }
            set { _carMngCode = value; }
        }

        /// public propaty name  :  ModelFullName
        /// <summary>�Ԏ�S�p���̃v���p�e�B</summary>
        /// <value>�Ԏ�S�p����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ�S�p���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ModelFullName
        {
            get { return _modelFullName; }
            set { _modelFullName = value; }
        }

        /// public propaty name  :  FullModel
        /// <summary>�^���i�t���^�j�v���p�e�B</summary>
        /// <value>�^���i�t���^�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���i�t���^�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FullModel
        {
            get { return _fullModel; }
            set { _fullModel = value; }
        }

        /// public propaty name  :  SearchFrameNo
        /// <summary>�ԑ䇂�v���p�e�B</summary>
        /// <value>�ԑ�ԍ��i�����p�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԑ䇂�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearchFrameNo
        {
            get { return _searchFrameNo; }
            set { _searchFrameNo = value; }
        }

        // ----------ADD 2010/08/05----------->>>>>
        /// public propaty name  :  FrameNo
        /// <summary>�ԑ䇂�v���p�e�B</summary>
        /// <value>�ԑ�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԑ䇂�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FrameNo
        {
            get { return _frameNo; }
            set { _frameNo = value; }
        }
        // ----------ADD 2010/08/05-----------<<<<<
        /// public propaty name  :  PartySaleSlipNum
        /// <summary>�����`�[�ԍ��v���p�e�B</summary>
        /// <value>�����`�[�ԍ�</value>
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

        /// public propaty name  :  ColorName1
        /// <summary>�J���[����1�v���p�e�B</summary>
        /// <value>�J���[����1</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J���[����1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ColorName1
        {
            get { return _colorName1; }
            set { _colorName1 = value; }
        }

        /// public propaty name  :  TrimName
        /// <summary>�g�������̃v���p�e�B</summary>
        /// <value>�g��������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �g�������̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TrimName
        {
            get { return _trimName; }
            set { _trimName = value; }
        }

        /// public propaty name  :  DataSendCode
        /// <summary>�f�[�^���M�敪�v���p�e�B</summary>
        /// <value>UOE�����f�[�^�̃f�[�^���M�敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^���M�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DataSendCode
        {
            get { return _dataSendCode; }
            set { _dataSendCode = value; }
        }

        /// public propaty name  :  SlipNote
        /// <summary>�`�[���l�v���p�e�B</summary>
        /// <value>�`�[���l</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipNote
        {
            get { return _slipNote; }
            set { _slipNote = value; }
        }

        /// public propaty name  :  SlipNote2
        /// <summary>�`�[���l�Q�v���p�e�B</summary>
        /// <value>�`�[���l�Q</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���l�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipNote2
        {
            get { return _slipNote2; }
            set { _slipNote2 = value; }
        }

        /// public propaty name  :  SlipNote3
        /// <summary>�`�[���l�R�v���p�e�B</summary>
        /// <value>�`�[���l�R</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���l�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipNote3
        {
            get { return _slipNote3; }
            set { _slipNote3 = value; }
        }

        /// public propaty name  :  UoeRemark1
        /// <summary>�t�n�d���}�[�N�P�v���p�e�B</summary>
        /// <value>�t�n�d���}�[�N�P</value>
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
        /// <value>�t�n�d���}�[�N�Q</value>
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

        /// public propaty name  :  BLGroupCode
        /// <summary>BL�O���[�v�R�[�h�v���p�e�B</summary>
        /// <value>BL�O���[�v�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL���i�R�[�h�v���p�e�B</summary>
        /// <value>BL���i�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>���i���̃v���p�e�B</summary>
        /// <value>���i����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>���i�ԍ��v���p�e�B</summary>
        /// <value>���i�ԍ�</value>
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

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>���i���[�J�[�R�[�h</value>
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

        /// public propaty name  :  SalesCode
        /// <summary>�̔��敪�R�[�h�v���p�e�B</summary>
        /// <value>�̔��敪�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesCode
        {
            get { return _salesCode; }
            set { _salesCode = value; }
        }

        /// public propaty name  :  EnterpriseGanreCode
        /// <summary>���Е��ރR�[�h�v���p�e�B</summary>
        /// <value>���Е��ރR�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Е��ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EnterpriseGanreCode
        {
            get { return _enterpriseGanreCode; }
            set { _enterpriseGanreCode = value; }
        }

        /// public propaty name  :  SalesOrderDivCd
        /// <summary>����݌Ɏ�񂹋敪�v���p�e�B</summary>
        /// <value>����݌Ɏ�񂹋敪(-1:�S�� 0:��� 1:�݌�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����݌Ɏ�񂹋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesOrderDivCd
        {
            get { return _salesOrderDivCd; }
            set { _salesOrderDivCd = value; }
        }

        /// public propaty name  :  WarehouseCode
        /// <summary>�q�ɃR�[�h�v���p�e�B</summary>
        /// <value>�q�ɃR�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }

        /// public propaty name  :  SupplierSlipNo
        /// <summary>�d���`�[�ԍ��v���p�e�B</summary>
        /// <value>�d���f�[�^�̑����`�[�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierSlipNo
        {
            get { return _supplierSlipNo; }
            set { _supplierSlipNo = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// <value>�d����R�[�h</value>
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

        /// public propaty name  :  UOESupplierCd
        /// <summary>UOE������R�[�h�v���p�e�B</summary>
        /// <value>UOE�����f�[�^�̎d����R�[�h</value>
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

        /// public propaty name  :  DtlNote
        /// <summary>���ה��l�v���p�e�B</summary>
        /// <value>���ה��l</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ה��l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DtlNote
        {
            get { return _dtlNote; }
            set { _dtlNote = value; }
        }

        /// public propaty name  :  SearchType
        /// <summary>�`�[�����敪�v���p�e�B</summary>
        /// <value>0:�S�� 1:����̂� 2:�����̂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearchType
        {
            get { return _searchType; }
            set { _searchType = value; }
        }

        /// public propaty name  :  AddresseeCode
        /// <summary>�[�i��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddresseeCode
        {
            get { return _addresseeCode; }
            set { _addresseeCode = value; }
        }

        /// public propaty name  :  GoodsKindCode
        /// <summary>���i�����v���p�e�B</summary>
        /// <value>0:���� 1:�D��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsKindCode
        {
            get { return _goodsKindCode; }
            set { _goodsKindCode = value; }
        }

        /// public propaty name  :  GoodsLGroup
        /// <summary>���i�啪�ރR�[�h�v���p�e�B</summary>
        /// <value>���啪�ށi���[�U�[�K�C�h�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�啪�ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsLGroup
        {
            get { return _goodsLGroup; }
            set { _goodsLGroup = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>���i�����ރR�[�h�v���p�e�B</summary>
        /// <value>�������ރR�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public propaty name  :  WarehouseShelfNo
        /// <summary>�q�ɒI�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɒI�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseShelfNo
        {
            get { return _warehouseShelfNo; }
            set { _warehouseShelfNo = value; }
        }

        /// public propaty name  :  SalesSlipCdDtl
        /// <summary>����`�[�敪�i���ׁj�v���p�e�B</summary>
        /// <value>0:����,1:�ԕi,2:�l��,3:����,4:���v,5:���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�敪�i���ׁj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesSlipCdDtl
        {
            get { return _salesSlipCdDtl; }
            set { _salesSlipCdDtl = value; }
        }

        //----- ADD 2015/02/05 ������ -------------------->>>>>
        /// public propaty name  :  SearchCountCtrl
        /// <summary>���o���������v���p�e�B�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���o���������v���p�e�B</br>
        /// <br>Programer        :   ������</br>
        /// </remarks>
        public Int32 SearchCountCtrl
        {
            get { return _searchCountCtrl; }
            set { _searchCountCtrl = value; }
        }

        /// public propaty name  :  SearchSalDateStEd
        /// <summary>�J�n���t/�I�����t�v���p�e�B�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���t/�I�����t�v���p�e�B</br>
        /// <br>Programer        :   ������</br>
        /// </remarks>
        public Int32 SearchSalDateStEd
        {
            get { return _searchSalDateStEd; }
            set { _searchSalDateStEd = value; }
        }
        //----- ADD 2015/02/05 ������ --------------------<<<<<

        //----- ADD 2015/03/03 ������ Redmine#44701 ---------->>>>>
        /// public propaty name  :  SearchSalDateType
        /// <summary>���t�����^�C�v�v���p�e�B�v���p�e�B</summary>
        /// <value>0:����f�[�^����A1:�����f�[�^����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���t�����^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ������</br>
        /// </remarks>
        public Int32 SearchSalDateType
        {
            get { return _searchSalDateType; }
            set { _searchSalDateType = value; }
        }
        //----- ADD 2015/03/03 ������ Redmine#44701 ----------<<<<<

        // ---------- ADD 2016/01/21 Y.Wakita ---------->>>>>
        /// public propaty name  :  AddUpRemDiv
        /// <summary>�o�׏󋵃v���p�e�B</summary>
        /// <value>0:�S�āA1:���v�㕪�A2:�v��ςݕ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�׏󋵃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddUpRemDiv
        {
            get { return _addUpRemDiv; }
            set { _addUpRemDiv = value; }
        }
        // ---------- ADD 2016/01/21 Y.Wakita ----------<<<<<

        /// <summary>
        /// ���Ӑ�d�q������������(�c���E�`�[�E����)���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>CustPrtPprWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustPrtPprWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustPrtPprWork()
        {
        }

    }

}
using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    //------------------------------------------------------------------
    //�@���t���^���Œ�ԍ��z��Ƒ������z���
    //�@�@�c�[���Ő����������e����ŏC������K�v������܂��B
    //
    //�@�@�iPMSYAR09013D���Q�l�ɂ��ĉ������B�j
    //------------------------------------------------------------------
    //  ��UpdateDateTime��Int64�̂܂܎擾���܂��B
    //    �i���������������Ƃ��A�T�[�o�[�ɕ��ׂ����������Ȃ��ׁj
    //------------------------------------------------------------------
    /// <br>Update Note: 2011/08/18 �A��729 ����g 10704766-00 </br>
    /// <br>             ���ד\�t�t�@���N�V�����{�^����ǉ�</br>
    /// <br>Update Note: 2012/04/01 Redmine#29250 </br>
    /// <br>             ���Ӑ�d�q�����@�f�[�^�X�V�����̒ǉ��ɂ���(���׍X�V�����̒ǉ�)</br>

    # region // DEL
    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.10 ADD
    ///// public class name:   CustPrtPprSalTblRsltWork
    ///// <summary>
    /////                      ���Ӑ�d�q�������o����(�`�[�E����)�N���X���[�N
    ///// </summary>
    ///// <remarks>
    ///// <br>note             :   ���Ӑ�d�q�������o����(�`�[�E����)�N���X���[�N�w�b�_�t�@�C��</br>
    ///// <br>Programmer       :   ��������</br>
    ///// <br>Date             :   </br>
    ///// <br>Genarated Date   :   2009/08/25  (CSharp File Generated Date)</br>
    ///// <br>Update Note      :   </br>
    ///// </remarks>
    //[Serializable]
    //[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    //public class CustPrtPprSalTblRsltWork
    //{
    //    /// <summary>�f�[�^�敪</summary>
    //    /// <remarks>0:����f�[�^ 1:�����f�[�^</remarks>
    //    private Int32 _dataDiv;

    //    /// <summary>������t</summary>
    //    /// <remarks>������t(YYYYMMDD)/�������t</remarks>
    //    private DateTime _salesDate;

    //    /// <summary>����`�[�ԍ�</summary>
    //    /// <remarks>����`�[�ԍ�/�����`�[�ԍ�</remarks>
    //    private string _salesSlipNum = "";

    //    /// <summary>����s�ԍ�</summary>
    //    /// <remarks>����s�ԍ�/�����s�ԍ�</remarks>
    //    private Int32 _salesRowNo;

    //    /// <summary>�󒍃X�e�[�^�X</summary>
    //    /// <remarks>10:����,20:��,30:����,40:�o��</remarks>
    //    private Int32 _acptAnOdrStatus;

    //    /// <summary>����`�[�敪</summary>
    //    /// <remarks>0:����,1:�ԕi</remarks>
    //    private Int32 _salesSlipCd;

    //    /// <summary>�̔��]�ƈ�����</summary>
    //    /// <remarks>�̔��]�ƈ�����/�����S���Җ���</remarks>
    //    private string _salesEmployeeNm = "";

    //    /// <summary>����`�[���v�i�Ŕ����j</summary>
    //    /// <remarks>����`�[���v�i�Ŕ����j/�����̏ꍇ(�������z+�l��+�萔��)</remarks>
    //    private Int64 _salesTotalTaxExc;

    //    /// <summary>���i����</summary>
    //    /// <remarks>���i����/���햼��</remarks>
    //    private string _goodsName = "";

    //    /// <summary>���i�ԍ�</summary>
    //    /// <remarks>���i�ԍ�</remarks>
    //    private string _goodsNo = "";

    //    /// <summary>BL���i�R�[�h</summary>
    //    /// <remarks>BL���i�R�[�h</remarks>
    //    private Int32 _bLGoodsCode;

    //    /// <summary>BL�O���[�v�R�[�h</summary>
    //    /// <remarks>BL�O���[�v�R�[�h</remarks>
    //    private Int32 _bLGroupCode;

    //    /// <summary>�o�א�</summary>
    //    /// <remarks>�o�א�</remarks>
    //    private Double _shipmentCnt;

    //    /// <summary>�艿�i�Ŕ��C�����j</summary>
    //    /// <remarks>�艿�i�Ŕ����A�����j�܂���"�I�[�v�����i"</remarks>
    //    private Double _listPriceTaxExcFl;

    //    /// <summary>�I�[�v�����i�敪</summary>
    //    /// <remarks>0:�ʏ�^1:�I�[�v�����i</remarks>
    //    private Int32 _openPriceDiv;

    //    /// <summary>����P���i�Ŕ��C�����j</summary>
    //    /// <remarks>����P���i�Ŕ��C�����j</remarks>
    //    private Double _salesUnPrcTaxExcFl;

    //    /// <summary>�����P��</summary>
    //    /// <remarks>�����P��</remarks>
    //    private Double _salesUnitCost;

    //    /// <summary>������z�i�Ŕ����j</summary>
    //    /// <remarks>������z�i�Ŕ����j/�������z</remarks>
    //    private Int64 _salesMoneyTaxExc;

    //    /// <summary>����œ]�ŕ���</summary>
    //    /// <remarks>0:�`�[�P��1:���גP��2:�����e 3:�����q 9:��ې�</remarks>
    //    private Int32 _consTaxLayMethod;

    //    /// <summary>����`�[���v�i�ō��݁j</summary>
    //    /// <remarks>����f�[�^</remarks>
    //    private Int64 _salesTotalTaxInc;

    //    /// <summary>������z����Ŋz</summary>
    //    /// <remarks>���㖾�׃f�[�^</remarks>
    //    private Int64 _salesPriceConsTax;

    //    /// <summary>�������z�v</summary>
    //    /// <remarks>����f�[�^</remarks>
    //    private Int64 _totalCost;

    //    /// <summary>�^���w��ԍ�</summary>
    //    private Int32 _modelDesignationNo;

    //    /// <summary>�ޕʔԍ�</summary>
    //    /// <remarks>�ޕʔԍ�</remarks>
    //    private Int32 _categoryNo;

    //    /// <summary>�Ԏ�S�p����</summary>
    //    /// <remarks>�Ԏ�S�p����</remarks>
    //    private string _modelFullName = "";

    //    /// <summary>���N�x</summary>
    //    /// <remarks>���N�x(YYYYMM)</remarks>
    //    private DateTime _firstEntryDate;

    //    /// <summary>�ԑ䇂</summary>
    //    /// <remarks>�ԑ�ԍ��i�����p�j</remarks>
    //    private Int32 _searchFrameNo;

    //    /// <summary>�^���i�t���^�j</summary>
    //    /// <remarks>�^���i�t���^�j</remarks>
    //    private string _fullModel = "";

    //    /// <summary>�`�[���l</summary>
    //    /// <remarks>�`�[���l/�`�[�E�v</remarks>
    //    private string _slipNote = "";

    //    /// <summary>�`�[���l�Q</summary>
    //    /// <remarks>�`�[���l�Q</remarks>
    //    private string _slipNote2 = "";

    //    /// <summary>�`�[���l�R</summary>
    //    /// <remarks>�`�[���l�R</remarks>
    //    private string _slipNote3 = "";

    //    /// <summary>��t�]�ƈ�����</summary>
    //    /// <remarks>��t�]�ƈ�����</remarks>
    //    private string _frontEmployeeNm = "";

    //    /// <summary>������͎Җ���</summary>
    //    /// <remarks>������͎Җ���/�������͎Җ���</remarks>
    //    private string _salesInputName = "";

    //    /// <summary>���Ӑ�R�[�h</summary>
    //    /// <remarks>���Ӑ�R�[�h/���Ӑ�R�[�h</remarks>
    //    private Int32 _customerCode;

    //    /// <summary>���Ӑ旪��</summary>
    //    /// <remarks>���Ӑ旪��</remarks>
    //    private string _customerSnm = "";

    //    /// <summary>�d����R�[�h</summary>
    //    /// <remarks>�d����R�[�h</remarks>
    //    private Int32 _supplierCd;

    //    /// <summary>�d���旪��</summary>
    //    /// <remarks>�d���旪��</remarks>
    //    private string _supplierSnm = "";

    //    /// <summary>�����`�[�ԍ�</summary>
    //    /// <remarks>�����`�[�ԍ�</remarks>
    //    private string _partySaleSlipNum = "";

    //    /// <summary>�ԗ��Ǘ��R�[�h</summary>
    //    /// <remarks>���q�Ǘ��R�[�h</remarks>
    //    private string _carMngCode = "";

    //    /// <summary>�󒍔ԍ�</summary>
    //    /// <remarks>�v�㌳�󒍔ԍ�</remarks>
    //    private Int32 _acceptAnOrderNo;

    //    /// <summary>�v�㌳�o�ׇ�</summary>
    //    /// <remarks>�v�㌳�o�הԍ�</remarks>
    //    private string _shipmSalesSlipNum = "";

    //    /// <summary>������(���ו\��)</summary>
    //    /// <remarks>�����`�ԍ�</remarks>
    //    private string _srcSalesSlipNum = "";

    //    /// <summary>����݌Ɏ�񂹋敪</summary>
    //    /// <remarks>����݌Ɏ�񂹋敪(0:��񂹁C1:�݌�)</remarks>
    //    private Int32 _salesOrderDivCd;

    //    /// <summary>�q�ɖ���</summary>
    //    /// <remarks>�q�ɖ���</remarks>
    //    private string _warehouseName = "";

    //    /// <summary>�d���`�[�ԍ�</summary>
    //    /// <remarks>�����d���`�[�ԍ�</remarks>
    //    private Int32 _supplierSlipNo;

    //    /// <summary>UOE������R�[�h</summary>
    //    /// <remarks>�t�n�d�����f�[�^</remarks>
    //    private Int32 _uOESupplierCd;

    //    /// <summary>�����於(���ו\��)</summary>
    //    /// <remarks>�t�n�d�����f�[�^</remarks>
    //    private string _uOESupplierSnm = "";

    //    /// <summary>�t�n�d���}�[�N�P</summary>
    //    /// <remarks>�t�n�d���}�[�N�P</remarks>
    //    private string _uoeRemark1 = "";

    //    /// <summary>�t�n�d���}�[�N�Q</summary>
    //    /// <remarks>�t�n�d���}�[�N�Q</remarks>
    //    private string _uoeRemark2 = "";

    //    /// <summary>�K�C�h����</summary>
    //    /// <remarks>�K�C�h����</remarks>
    //    private string _guideName = "";

    //    /// <summary>���_�K�C�h����</summary>
    //    /// <remarks>���_�K�C�h����/�v�㋒�_�R�[�h</remarks>
    //    private string _sectionGuideNm = "";

    //    /// <summary>���ה��l</summary>
    //    /// <remarks>���ה��l/</remarks>
    //    private string _dtlNote = "";

    //    /// <summary>�J���[����1</summary>
    //    /// <remarks>�J���[����1</remarks>
    //    private string _colorName1 = "";

    //    /// <summary>�g��������</summary>
    //    /// <remarks>�g��������</remarks>
    //    private string _trimName = "";

    //    /// <summary>��P���i�艿�j</summary>
    //    /// <remarks>��P���i�艿�j</remarks>
    //    private Double _stdUnPrcLPrice;

    //    /// <summary>��P���i����P���j</summary>
    //    /// <remarks>��P���i����P���j</remarks>
    //    private Double _stdUnPrcSalUnPrc;

    //    /// <summary>��P���i�����P���j</summary>
    //    /// <remarks>��P���i�����P���j</remarks>
    //    private Double _stdUnPrcUnCst;

    //    /// <summary>���i���[�J�[�R�[�h</summary>
    //    /// <remarks>���i���[�J�[�R�[�h</remarks>
    //    private Int32 _goodsMakerCd;

    //    /// <summary>���[�J�[����</summary>
    //    /// <remarks>���[�J�[����</remarks>
    //    private string _makerName = "";

    //    /// <summary>����</summary>
    //    /// <remarks>���㖾�׃f�[�^</remarks>
    //    private Int64 _cost;

    //    /// <summary>���Ӑ�`�[�ԍ�</summary>
    //    /// <remarks>���Ӑ�`�[�ԍ�</remarks>
    //    private Int32 _custSlipNo;

    //    /// <summary>�v����t</summary>
    //    /// <remarks>�v����t(YYYYMMDD)/�v����t(YYYYMMDD)</remarks>
    //    private DateTime _addUpADate;

    //    /// <summary>���|�敪</summary>
    //    /// <remarks>���|�敪(0:���|�Ȃ�,1:���|)</remarks>
    //    private Int32 _accRecDivCd;

    //    /// <summary>�ԓ`�敪</summary>
    //    /// <remarks>�ԓ`�敪(0:���`,1:�ԓ`,2:����)/�����ԍ��敪(0:��,1:��,2:���E�ςݍ�)</remarks>
    //    private Int32 _debitNoteDiv;

    //    /// <summary>���_�R�[�h</summary>
    //    /// <remarks>���_�R�[�h</remarks>
    //    private string _sectionCode = "";

    //    /// <summary>�q�ɃR�[�h</summary>
    //    /// <remarks>�q�ɃR�[�h</remarks>
    //    private string _warehouseCode = "";

    //    /// <summary>���z�\�����@�敪</summary>
    //    /// <remarks>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</remarks>
    //    private Int32 _totalAmountDispWayCd;

    //    /// <summary>�ېŋ敪[����]</summary>
    //    /// <remarks>0:�ې�,1:��ې�,2:�ېŁi���Łj</remarks>
    //    private Int32 _taxationDivCd;

    //    /// <summary>�����`�[�ԍ�</summary>
    //    /// <remarks>�d����`�[�ԍ��Ɏg�p����</remarks>
    //    private string _stockPartySaleSlipNum = "";

    //    /// <summary>�[�i��R�[�h</summary>
    //    private Int32 _addresseeCode;

    //    /// <summary>�[�i�於��</summary>
    //    private string _addresseeName = "";

    //    /// <summary>�[�i�於��2</summary>
    //    /// <remarks>�ǉ�(�o�^�R��) ����</remarks>
    //    private string _addresseeName2 = "";

    //    /// <summary>�ԑ�ԍ�</summary>
    //    private string _frameNo = "";

    //    /// <summary>�󒍎c��</summary>
    //    /// <remarks>�󒍐��ʁ{�󒍒������|�o�א�</remarks>
    //    private Double _acptAnOdrRemainCnt;

    //    /// <summary>���Е��ރR�[�h</summary>
    //    private Int32 _enterpriseGanreCode;

    //    /// <summary>�萔�������z</summary>
    //    private Int64 _feeDeposit;

    //    /// <summary>�l�������z</summary>
    //    private Int64 _discountDeposit;

    //    /// <summary>���͓�</summary>
    //    /// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
    //    private DateTime _inputDay;

    //    /// <summary>���i����</summary>
    //    /// <remarks>0:���� 1:�D��</remarks>
    //    private Int32 _goodsKindCode;

    //    /// <summary>���i�啪�ރR�[�h</summary>
    //    /// <remarks>���啪�ށi���[�U�[�K�C�h�j</remarks>
    //    private Int32 _goodsLGroup;

    //    /// <summary>���i�����ރR�[�h</summary>
    //    /// <remarks>�������ރR�[�h</remarks>
    //    private Int32 _goodsMGroup;

    //    /// <summary>�q�ɒI��</summary>
    //    private string _warehouseShelfNo = "";

    //    /// <summary>����`�[�敪�i���ׁj</summary>
    //    /// <remarks>0:����,1:�ԕi,2:�l��,3:����,4:���v,5:���</remarks>
    //    private Int32 _salesSlipCdDtl;

    //    /// <summary>���i�啪�ޖ���</summary>
    //    private string _goodsLGroupName = "";

    //    /// <summary>���i�����ޖ���</summary>
    //    private string _goodsMGroupName = "";

    //    /// <summary>�ԗ��Ǘ��ԍ�</summary>
    //    /// <remarks>�����̔ԁi���d���̃V�[�P���X�jPM7�ł̎ԗ�SEQ</remarks>
    //    private Int32 _carMngNo;

    //    /// <summary>���[�J�[�R�[�h</summary>
    //    private Int32 _makerCode;

    //    /// <summary>�Ԏ�R�[�h</summary>
    //    private Int32 _modelCode;

    //    /// <summary>�Ԏ�T�u�R�[�h</summary>
    //    private Int32 _modelSubCode;

    //    /// <summary>�G���W���^������</summary>
    //    /// <remarks>�^���ɂ��ϓ�</remarks>
    //    private string _engineModelNm = "";

    //    /// <summary>�J���[�R�[�h</summary>
    //    /// <remarks>�J�^���O�̐F�R�[�h</remarks>
    //    private string _colorCode = "";

    //    /// <summary>�g�����R�[�h</summary>
    //    private string _trimCode = "";

    //    /// <summary>�[�i�敪</summary>
    //    private Int32 _deliveredGoodsDiv;

    //    /// <summary>�t���^���Œ�ԍ��z��</summary>
    //    private Int32[] _fullModelFixedNoAry = new Int32[0];

    //    /// <summary>�����I�u�W�F�N�g�z��</summary>
    //    private Byte[] _categoryObjAry = new Byte[0];

    //    /// <summary>������͎҃R�[�h</summary>
    //    /// <remarks>���͒S���ҁi���s�ҁj</remarks>
    //    private string _salesInputCode = "";

    //    /// <summary>��t�]�ƈ��R�[�h</summary>
    //    /// <remarks>��t�S���ҁi�󒍎ҁj</remarks>
    //    private string _frontEmployeeCd = "";


    //    /// public propaty name  :  DataDiv
    //    /// <summary>�f�[�^�敪�v���p�e�B</summary>
    //    /// <value>0:����f�[�^ 1:�����f�[�^</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �f�[�^�敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 DataDiv
    //    {
    //        get { return _dataDiv; }
    //        set { _dataDiv = value; }
    //    }

    //    /// public propaty name  :  SalesDate
    //    /// <summary>������t�v���p�e�B</summary>
    //    /// <value>������t(YYYYMMDD)/�������t</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ������t�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public DateTime SalesDate
    //    {
    //        get { return _salesDate; }
    //        set { _salesDate = value; }
    //    }

    //    /// public propaty name  :  SalesSlipNum
    //    /// <summary>����`�[�ԍ��v���p�e�B</summary>
    //    /// <value>����`�[�ԍ�/�����`�[�ԍ�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����`�[�ԍ��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SalesSlipNum
    //    {
    //        get { return _salesSlipNum; }
    //        set { _salesSlipNum = value; }
    //    }

    //    /// public propaty name  :  SalesRowNo
    //    /// <summary>����s�ԍ��v���p�e�B</summary>
    //    /// <value>����s�ԍ�/�����s�ԍ�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����s�ԍ��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 SalesRowNo
    //    {
    //        get { return _salesRowNo; }
    //        set { _salesRowNo = value; }
    //    }

    //    /// public propaty name  :  AcptAnOdrStatus
    //    /// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
    //    /// <value>10:����,20:��,30:����,40:�o��</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 AcptAnOdrStatus
    //    {
    //        get { return _acptAnOdrStatus; }
    //        set { _acptAnOdrStatus = value; }
    //    }

    //    /// public propaty name  :  SalesSlipCd
    //    /// <summary>����`�[�敪�v���p�e�B</summary>
    //    /// <value>0:����,1:�ԕi</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����`�[�敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 SalesSlipCd
    //    {
    //        get { return _salesSlipCd; }
    //        set { _salesSlipCd = value; }
    //    }

    //    /// public propaty name  :  SalesEmployeeNm
    //    /// <summary>�̔��]�ƈ����̃v���p�e�B</summary>
    //    /// <value>�̔��]�ƈ�����/�����S���Җ���</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �̔��]�ƈ����̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SalesEmployeeNm
    //    {
    //        get { return _salesEmployeeNm; }
    //        set { _salesEmployeeNm = value; }
    //    }

    //    /// public propaty name  :  SalesTotalTaxExc
    //    /// <summary>����`�[���v�i�Ŕ����j�v���p�e�B</summary>
    //    /// <value>����`�[���v�i�Ŕ����j/�����̏ꍇ(�������z+�l��+�萔��)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����`�[���v�i�Ŕ����j�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 SalesTotalTaxExc
    //    {
    //        get { return _salesTotalTaxExc; }
    //        set { _salesTotalTaxExc = value; }
    //    }

    //    /// public propaty name  :  GoodsName
    //    /// <summary>���i���̃v���p�e�B</summary>
    //    /// <value>���i����/���햼��</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���i���̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string GoodsName
    //    {
    //        get { return _goodsName; }
    //        set { _goodsName = value; }
    //    }

    //    /// public propaty name  :  GoodsNo
    //    /// <summary>���i�ԍ��v���p�e�B</summary>
    //    /// <value>���i�ԍ�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���i�ԍ��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string GoodsNo
    //    {
    //        get { return _goodsNo; }
    //        set { _goodsNo = value; }
    //    }

    //    /// public propaty name  :  BLGoodsCode
    //    /// <summary>BL���i�R�[�h�v���p�e�B</summary>
    //    /// <value>BL���i�R�[�h</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   BL���i�R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 BLGoodsCode
    //    {
    //        get { return _bLGoodsCode; }
    //        set { _bLGoodsCode = value; }
    //    }

    //    /// public propaty name  :  BLGroupCode
    //    /// <summary>BL�O���[�v�R�[�h�v���p�e�B</summary>
    //    /// <value>BL�O���[�v�R�[�h</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   BL�O���[�v�R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 BLGroupCode
    //    {
    //        get { return _bLGroupCode; }
    //        set { _bLGroupCode = value; }
    //    }

    //    /// public propaty name  :  ShipmentCnt
    //    /// <summary>�o�א��v���p�e�B</summary>
    //    /// <value>�o�א�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �o�א��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Double ShipmentCnt
    //    {
    //        get { return _shipmentCnt; }
    //        set { _shipmentCnt = value; }
    //    }

    //    /// public propaty name  :  ListPriceTaxExcFl
    //    /// <summary>�艿�i�Ŕ��C�����j�v���p�e�B</summary>
    //    /// <value>�艿�i�Ŕ����A�����j�܂���"�I�[�v�����i"</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �艿�i�Ŕ��C�����j�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Double ListPriceTaxExcFl
    //    {
    //        get { return _listPriceTaxExcFl; }
    //        set { _listPriceTaxExcFl = value; }
    //    }

    //    /// public propaty name  :  OpenPriceDiv
    //    /// <summary>�I�[�v�����i�敪�v���p�e�B</summary>
    //    /// <value>0:�ʏ�^1:�I�[�v�����i</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �I�[�v�����i�敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 OpenPriceDiv
    //    {
    //        get { return _openPriceDiv; }
    //        set { _openPriceDiv = value; }
    //    }

    //    /// public propaty name  :  SalesUnPrcTaxExcFl
    //    /// <summary>����P���i�Ŕ��C�����j�v���p�e�B</summary>
    //    /// <value>����P���i�Ŕ��C�����j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����P���i�Ŕ��C�����j�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Double SalesUnPrcTaxExcFl
    //    {
    //        get { return _salesUnPrcTaxExcFl; }
    //        set { _salesUnPrcTaxExcFl = value; }
    //    }

    //    /// public propaty name  :  SalesUnitCost
    //    /// <summary>�����P���v���p�e�B</summary>
    //    /// <value>�����P��</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �����P���v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Double SalesUnitCost
    //    {
    //        get { return _salesUnitCost; }
    //        set { _salesUnitCost = value; }
    //    }

    //    /// public propaty name  :  SalesMoneyTaxExc
    //    /// <summary>������z�i�Ŕ����j�v���p�e�B</summary>
    //    /// <value>������z�i�Ŕ����j/�������z</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ������z�i�Ŕ����j�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 SalesMoneyTaxExc
    //    {
    //        get { return _salesMoneyTaxExc; }
    //        set { _salesMoneyTaxExc = value; }
    //    }

    //    /// public propaty name  :  ConsTaxLayMethod
    //    /// <summary>����œ]�ŕ����v���p�e�B</summary>
    //    /// <value>0:�`�[�P��1:���גP��2:�����e 3:�����q 9:��ې�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����œ]�ŕ����v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 ConsTaxLayMethod
    //    {
    //        get { return _consTaxLayMethod; }
    //        set { _consTaxLayMethod = value; }
    //    }

    //    /// public propaty name  :  SalesTotalTaxInc
    //    /// <summary>����`�[���v�i�ō��݁j�v���p�e�B</summary>
    //    /// <value>����f�[�^</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����`�[���v�i�ō��݁j�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 SalesTotalTaxInc
    //    {
    //        get { return _salesTotalTaxInc; }
    //        set { _salesTotalTaxInc = value; }
    //    }

    //    /// public propaty name  :  SalesPriceConsTax
    //    /// <summary>������z����Ŋz�v���p�e�B</summary>
    //    /// <value>���㖾�׃f�[�^</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ������z����Ŋz�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 SalesPriceConsTax
    //    {
    //        get { return _salesPriceConsTax; }
    //        set { _salesPriceConsTax = value; }
    //    }

    //    /// public propaty name  :  TotalCost
    //    /// <summary>�������z�v�v���p�e�B</summary>
    //    /// <value>����f�[�^</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �������z�v�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 TotalCost
    //    {
    //        get { return _totalCost; }
    //        set { _totalCost = value; }
    //    }

    //    /// public propaty name  :  ModelDesignationNo
    //    /// <summary>�^���w��ԍ��v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �^���w��ԍ��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 ModelDesignationNo
    //    {
    //        get { return _modelDesignationNo; }
    //        set { _modelDesignationNo = value; }
    //    }

    //    /// public propaty name  :  CategoryNo
    //    /// <summary>�ޕʔԍ��v���p�e�B</summary>
    //    /// <value>�ޕʔԍ�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �ޕʔԍ��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 CategoryNo
    //    {
    //        get { return _categoryNo; }
    //        set { _categoryNo = value; }
    //    }

    //    /// public propaty name  :  ModelFullName
    //    /// <summary>�Ԏ�S�p���̃v���p�e�B</summary>
    //    /// <value>�Ԏ�S�p����</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �Ԏ�S�p���̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string ModelFullName
    //    {
    //        get { return _modelFullName; }
    //        set { _modelFullName = value; }
    //    }

    //    /// public propaty name  :  FirstEntryDate
    //    /// <summary>���N�x�v���p�e�B</summary>
    //    /// <value>���N�x(YYYYMM)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���N�x�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public DateTime FirstEntryDate
    //    {
    //        get { return _firstEntryDate; }
    //        set { _firstEntryDate = value; }
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
    //        get { return _searchFrameNo; }
    //        set { _searchFrameNo = value; }
    //    }

    //    /// public propaty name  :  FullModel
    //    /// <summary>�^���i�t���^�j�v���p�e�B</summary>
    //    /// <value>�^���i�t���^�j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �^���i�t���^�j�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string FullModel
    //    {
    //        get { return _fullModel; }
    //        set { _fullModel = value; }
    //    }

    //    /// public propaty name  :  SlipNote
    //    /// <summary>�`�[���l�v���p�e�B</summary>
    //    /// <value>�`�[���l/�`�[�E�v</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �`�[���l�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SlipNote
    //    {
    //        get { return _slipNote; }
    //        set { _slipNote = value; }
    //    }

    //    /// public propaty name  :  SlipNote2
    //    /// <summary>�`�[���l�Q�v���p�e�B</summary>
    //    /// <value>�`�[���l�Q</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �`�[���l�Q�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SlipNote2
    //    {
    //        get { return _slipNote2; }
    //        set { _slipNote2 = value; }
    //    }

    //    /// public propaty name  :  SlipNote3
    //    /// <summary>�`�[���l�R�v���p�e�B</summary>
    //    /// <value>�`�[���l�R</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �`�[���l�R�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SlipNote3
    //    {
    //        get { return _slipNote3; }
    //        set { _slipNote3 = value; }
    //    }

    //    /// public propaty name  :  FrontEmployeeNm
    //    /// <summary>��t�]�ƈ����̃v���p�e�B</summary>
    //    /// <value>��t�]�ƈ�����</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ��t�]�ƈ����̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string FrontEmployeeNm
    //    {
    //        get { return _frontEmployeeNm; }
    //        set { _frontEmployeeNm = value; }
    //    }

    //    /// public propaty name  :  SalesInputName
    //    /// <summary>������͎Җ��̃v���p�e�B</summary>
    //    /// <value>������͎Җ���/�������͎Җ���</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ������͎Җ��̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SalesInputName
    //    {
    //        get { return _salesInputName; }
    //        set { _salesInputName = value; }
    //    }

    //    /// public propaty name  :  CustomerCode
    //    /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
    //    /// <value>���Ӑ�R�[�h/���Ӑ�R�[�h</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 CustomerCode
    //    {
    //        get { return _customerCode; }
    //        set { _customerCode = value; }
    //    }

    //    /// public propaty name  :  CustomerSnm
    //    /// <summary>���Ӑ旪�̃v���p�e�B</summary>
    //    /// <value>���Ӑ旪��</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���Ӑ旪�̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string CustomerSnm
    //    {
    //        get { return _customerSnm; }
    //        set { _customerSnm = value; }
    //    }

    //    /// public propaty name  :  SupplierCd
    //    /// <summary>�d����R�[�h�v���p�e�B</summary>
    //    /// <value>�d����R�[�h</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �d����R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 SupplierCd
    //    {
    //        get { return _supplierCd; }
    //        set { _supplierCd = value; }
    //    }

    //    /// public propaty name  :  SupplierSnm
    //    /// <summary>�d���旪�̃v���p�e�B</summary>
    //    /// <value>�d���旪��</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �d���旪�̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SupplierSnm
    //    {
    //        get { return _supplierSnm; }
    //        set { _supplierSnm = value; }
    //    }

    //    /// public propaty name  :  PartySaleSlipNum
    //    /// <summary>�����`�[�ԍ��v���p�e�B</summary>
    //    /// <value>�����`�[�ԍ�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �����`�[�ԍ��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string PartySaleSlipNum
    //    {
    //        get { return _partySaleSlipNum; }
    //        set { _partySaleSlipNum = value; }
    //    }

    //    /// public propaty name  :  CarMngCode
    //    /// <summary>�ԗ��Ǘ��R�[�h�v���p�e�B</summary>
    //    /// <value>���q�Ǘ��R�[�h</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �ԗ��Ǘ��R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string CarMngCode
    //    {
    //        get { return _carMngCode; }
    //        set { _carMngCode = value; }
    //    }

    //    /// public propaty name  :  AcceptAnOrderNo
    //    /// <summary>�󒍔ԍ��v���p�e�B</summary>
    //    /// <value>�v�㌳�󒍔ԍ�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �󒍔ԍ��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 AcceptAnOrderNo
    //    {
    //        get { return _acceptAnOrderNo; }
    //        set { _acceptAnOrderNo = value; }
    //    }

    //    /// public propaty name  :  ShipmSalesSlipNum
    //    /// <summary>�v�㌳�o�ׇ��v���p�e�B</summary>
    //    /// <value>�v�㌳�o�הԍ�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �v�㌳�o�ׇ��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string ShipmSalesSlipNum
    //    {
    //        get { return _shipmSalesSlipNum; }
    //        set { _shipmSalesSlipNum = value; }
    //    }

    //    /// public propaty name  :  SrcSalesSlipNum
    //    /// <summary>������(���ו\��)�v���p�e�B</summary>
    //    /// <value>�����`�ԍ�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ������(���ו\��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SrcSalesSlipNum
    //    {
    //        get { return _srcSalesSlipNum; }
    //        set { _srcSalesSlipNum = value; }
    //    }

    //    /// public propaty name  :  SalesOrderDivCd
    //    /// <summary>����݌Ɏ�񂹋敪�v���p�e�B</summary>
    //    /// <value>����݌Ɏ�񂹋敪(0:��񂹁C1:�݌�)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����݌Ɏ�񂹋敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 SalesOrderDivCd
    //    {
    //        get { return _salesOrderDivCd; }
    //        set { _salesOrderDivCd = value; }
    //    }

    //    /// public propaty name  :  WarehouseName
    //    /// <summary>�q�ɖ��̃v���p�e�B</summary>
    //    /// <value>�q�ɖ���</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �q�ɖ��̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string WarehouseName
    //    {
    //        get { return _warehouseName; }
    //        set { _warehouseName = value; }
    //    }

    //    /// public propaty name  :  SupplierSlipNo
    //    /// <summary>�d���`�[�ԍ��v���p�e�B</summary>
    //    /// <value>�����d���`�[�ԍ�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �d���`�[�ԍ��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 SupplierSlipNo
    //    {
    //        get { return _supplierSlipNo; }
    //        set { _supplierSlipNo = value; }
    //    }

    //    /// public propaty name  :  UOESupplierCd
    //    /// <summary>UOE������R�[�h�v���p�e�B</summary>
    //    /// <value>�t�n�d�����f�[�^</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   UOE������R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 UOESupplierCd
    //    {
    //        get { return _uOESupplierCd; }
    //        set { _uOESupplierCd = value; }
    //    }

    //    /// public propaty name  :  UOESupplierSnm
    //    /// <summary>�����於(���ו\��)�v���p�e�B</summary>
    //    /// <value>�t�n�d�����f�[�^</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �����於(���ו\��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string UOESupplierSnm
    //    {
    //        get { return _uOESupplierSnm; }
    //        set { _uOESupplierSnm = value; }
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
    //        get { return _uoeRemark1; }
    //        set { _uoeRemark1 = value; }
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
    //        get { return _uoeRemark2; }
    //        set { _uoeRemark2 = value; }
    //    }

    //    /// public propaty name  :  GuideName
    //    /// <summary>�K�C�h���̃v���p�e�B</summary>
    //    /// <value>�K�C�h����</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �K�C�h���̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string GuideName
    //    {
    //        get { return _guideName; }
    //        set { _guideName = value; }
    //    }

    //    /// public propaty name  :  SectionGuideNm
    //    /// <summary>���_�K�C�h���̃v���p�e�B</summary>
    //    /// <value>���_�K�C�h����/�v�㋒�_�R�[�h</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SectionGuideNm
    //    {
    //        get { return _sectionGuideNm; }
    //        set { _sectionGuideNm = value; }
    //    }

    //    /// public propaty name  :  DtlNote
    //    /// <summary>���ה��l�v���p�e�B</summary>
    //    /// <value>���ה��l/</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���ה��l�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string DtlNote
    //    {
    //        get { return _dtlNote; }
    //        set { _dtlNote = value; }
    //    }

    //    /// public propaty name  :  ColorName1
    //    /// <summary>�J���[����1�v���p�e�B</summary>
    //    /// <value>�J���[����1</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �J���[����1�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string ColorName1
    //    {
    //        get { return _colorName1; }
    //        set { _colorName1 = value; }
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
    //        get { return _trimName; }
    //        set { _trimName = value; }
    //    }

    //    /// public propaty name  :  StdUnPrcLPrice
    //    /// <summary>��P���i�艿�j�v���p�e�B</summary>
    //    /// <value>��P���i�艿�j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ��P���i�艿�j�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Double StdUnPrcLPrice
    //    {
    //        get { return _stdUnPrcLPrice; }
    //        set { _stdUnPrcLPrice = value; }
    //    }

    //    /// public propaty name  :  StdUnPrcSalUnPrc
    //    /// <summary>��P���i����P���j�v���p�e�B</summary>
    //    /// <value>��P���i����P���j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ��P���i����P���j�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Double StdUnPrcSalUnPrc
    //    {
    //        get { return _stdUnPrcSalUnPrc; }
    //        set { _stdUnPrcSalUnPrc = value; }
    //    }

    //    /// public propaty name  :  StdUnPrcUnCst
    //    /// <summary>��P���i�����P���j�v���p�e�B</summary>
    //    /// <value>��P���i�����P���j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ��P���i�����P���j�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Double StdUnPrcUnCst
    //    {
    //        get { return _stdUnPrcUnCst; }
    //        set { _stdUnPrcUnCst = value; }
    //    }

    //    /// public propaty name  :  GoodsMakerCd
    //    /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
    //    /// <value>���i���[�J�[�R�[�h</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 GoodsMakerCd
    //    {
    //        get { return _goodsMakerCd; }
    //        set { _goodsMakerCd = value; }
    //    }

    //    /// public propaty name  :  MakerName
    //    /// <summary>���[�J�[���̃v���p�e�B</summary>
    //    /// <value>���[�J�[����</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���[�J�[���̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string MakerName
    //    {
    //        get { return _makerName; }
    //        set { _makerName = value; }
    //    }

    //    /// public propaty name  :  Cost
    //    /// <summary>�����v���p�e�B</summary>
    //    /// <value>���㖾�׃f�[�^</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �����v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 Cost
    //    {
    //        get { return _cost; }
    //        set { _cost = value; }
    //    }

    //    /// public propaty name  :  CustSlipNo
    //    /// <summary>���Ӑ�`�[�ԍ��v���p�e�B</summary>
    //    /// <value>���Ӑ�`�[�ԍ�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���Ӑ�`�[�ԍ��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 CustSlipNo
    //    {
    //        get { return _custSlipNo; }
    //        set { _custSlipNo = value; }
    //    }

    //    /// public propaty name  :  AddUpADate
    //    /// <summary>�v����t�v���p�e�B</summary>
    //    /// <value>�v����t(YYYYMMDD)/�v����t(YYYYMMDD)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �v����t�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public DateTime AddUpADate
    //    {
    //        get { return _addUpADate; }
    //        set { _addUpADate = value; }
    //    }

    //    /// public propaty name  :  AccRecDivCd
    //    /// <summary>���|�敪�v���p�e�B</summary>
    //    /// <value>���|�敪(0:���|�Ȃ�,1:���|)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���|�敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 AccRecDivCd
    //    {
    //        get { return _accRecDivCd; }
    //        set { _accRecDivCd = value; }
    //    }

    //    /// public propaty name  :  DebitNoteDiv
    //    /// <summary>�ԓ`�敪�v���p�e�B</summary>
    //    /// <value>�ԓ`�敪(0:���`,1:�ԓ`,2:����)/�����ԍ��敪(0:��,1:��,2:���E�ςݍ�)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �ԓ`�敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 DebitNoteDiv
    //    {
    //        get { return _debitNoteDiv; }
    //        set { _debitNoteDiv = value; }
    //    }

    //    /// public propaty name  :  SectionCode
    //    /// <summary>���_�R�[�h�v���p�e�B</summary>
    //    /// <value>���_�R�[�h</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SectionCode
    //    {
    //        get { return _sectionCode; }
    //        set { _sectionCode = value; }
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
    //        get { return _warehouseCode; }
    //        set { _warehouseCode = value; }
    //    }

    //    /// public propaty name  :  TotalAmountDispWayCd
    //    /// <summary>���z�\�����@�敪�v���p�e�B</summary>
    //    /// <value>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���z�\�����@�敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 TotalAmountDispWayCd
    //    {
    //        get { return _totalAmountDispWayCd; }
    //        set { _totalAmountDispWayCd = value; }
    //    }

    //    /// public propaty name  :  TaxationDivCd
    //    /// <summary>�ېŋ敪[����]�v���p�e�B</summary>
    //    /// <value>0:�ې�,1:��ې�,2:�ېŁi���Łj</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �ېŋ敪[����]�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 TaxationDivCd
    //    {
    //        get { return _taxationDivCd; }
    //        set { _taxationDivCd = value; }
    //    }

    //    /// public propaty name  :  StockPartySaleSlipNum
    //    /// <summary>�����`�[�ԍ��v���p�e�B</summary>
    //    /// <value>�d����`�[�ԍ��Ɏg�p����</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �����`�[�ԍ��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string StockPartySaleSlipNum
    //    {
    //        get { return _stockPartySaleSlipNum; }
    //        set { _stockPartySaleSlipNum = value; }
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
    //        get { return _addresseeCode; }
    //        set { _addresseeCode = value; }
    //    }

    //    /// public propaty name  :  AddresseeName
    //    /// <summary>�[�i�於�̃v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �[�i�於�̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string AddresseeName
    //    {
    //        get { return _addresseeName; }
    //        set { _addresseeName = value; }
    //    }

    //    /// public propaty name  :  AddresseeName2
    //    /// <summary>�[�i�於��2�v���p�e�B</summary>
    //    /// <value>�ǉ�(�o�^�R��) ����</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �[�i�於��2�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string AddresseeName2
    //    {
    //        get { return _addresseeName2; }
    //        set { _addresseeName2 = value; }
    //    }

    //    /// public propaty name  :  FrameNo
    //    /// <summary>�ԑ�ԍ��v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �ԑ�ԍ��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string FrameNo
    //    {
    //        get { return _frameNo; }
    //        set { _frameNo = value; }
    //    }

    //    /// public propaty name  :  AcptAnOdrRemainCnt
    //    /// <summary>�󒍎c���v���p�e�B</summary>
    //    /// <value>�󒍐��ʁ{�󒍒������|�o�א�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �󒍎c���v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Double AcptAnOdrRemainCnt
    //    {
    //        get { return _acptAnOdrRemainCnt; }
    //        set { _acptAnOdrRemainCnt = value; }
    //    }

    //    /// public propaty name  :  EnterpriseGanreCode
    //    /// <summary>���Е��ރR�[�h�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���Е��ރR�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 EnterpriseGanreCode
    //    {
    //        get { return _enterpriseGanreCode; }
    //        set { _enterpriseGanreCode = value; }
    //    }

    //    /// public propaty name  :  FeeDeposit
    //    /// <summary>�萔�������z�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �萔�������z�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 FeeDeposit
    //    {
    //        get { return _feeDeposit; }
    //        set { _feeDeposit = value; }
    //    }

    //    /// public propaty name  :  DiscountDeposit
    //    /// <summary>�l�������z�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �l�������z�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 DiscountDeposit
    //    {
    //        get { return _discountDeposit; }
    //        set { _discountDeposit = value; }
    //    }

    //    /// public propaty name  :  InputDay
    //    /// <summary>���͓��v���p�e�B</summary>
    //    /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���͓��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public DateTime InputDay
    //    {
    //        get { return _inputDay; }
    //        set { _inputDay = value; }
    //    }

    //    /// public propaty name  :  GoodsKindCode
    //    /// <summary>���i�����v���p�e�B</summary>
    //    /// <value>0:���� 1:�D��</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���i�����v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 GoodsKindCode
    //    {
    //        get { return _goodsKindCode; }
    //        set { _goodsKindCode = value; }
    //    }

    //    /// public propaty name  :  GoodsLGroup
    //    /// <summary>���i�啪�ރR�[�h�v���p�e�B</summary>
    //    /// <value>���啪�ށi���[�U�[�K�C�h�j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���i�啪�ރR�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 GoodsLGroup
    //    {
    //        get { return _goodsLGroup; }
    //        set { _goodsLGroup = value; }
    //    }

    //    /// public propaty name  :  GoodsMGroup
    //    /// <summary>���i�����ރR�[�h�v���p�e�B</summary>
    //    /// <value>�������ރR�[�h</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���i�����ރR�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 GoodsMGroup
    //    {
    //        get { return _goodsMGroup; }
    //        set { _goodsMGroup = value; }
    //    }

    //    /// public propaty name  :  WarehouseShelfNo
    //    /// <summary>�q�ɒI�ԃv���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �q�ɒI�ԃv���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string WarehouseShelfNo
    //    {
    //        get { return _warehouseShelfNo; }
    //        set { _warehouseShelfNo = value; }
    //    }

    //    /// public propaty name  :  SalesSlipCdDtl
    //    /// <summary>����`�[�敪�i���ׁj�v���p�e�B</summary>
    //    /// <value>0:����,1:�ԕi,2:�l��,3:����,4:���v,5:���</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����`�[�敪�i���ׁj�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 SalesSlipCdDtl
    //    {
    //        get { return _salesSlipCdDtl; }
    //        set { _salesSlipCdDtl = value; }
    //    }

    //    /// public propaty name  :  GoodsLGroupName
    //    /// <summary>���i�啪�ޖ��̃v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���i�啪�ޖ��̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string GoodsLGroupName
    //    {
    //        get { return _goodsLGroupName; }
    //        set { _goodsLGroupName = value; }
    //    }

    //    /// public propaty name  :  GoodsMGroupName
    //    /// <summary>���i�����ޖ��̃v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���i�����ޖ��̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string GoodsMGroupName
    //    {
    //        get { return _goodsMGroupName; }
    //        set { _goodsMGroupName = value; }
    //    }

    //    /// public propaty name  :  CarMngNo
    //    /// <summary>�ԗ��Ǘ��ԍ��v���p�e�B</summary>
    //    /// <value>�����̔ԁi���d���̃V�[�P���X�jPM7�ł̎ԗ�SEQ</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �ԗ��Ǘ��ԍ��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 CarMngNo
    //    {
    //        get { return _carMngNo; }
    //        set { _carMngNo = value; }
    //    }

    //    /// public propaty name  :  MakerCode
    //    /// <summary>���[�J�[�R�[�h�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���[�J�[�R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 MakerCode
    //    {
    //        get { return _makerCode; }
    //        set { _makerCode = value; }
    //    }

    //    /// public propaty name  :  ModelCode
    //    /// <summary>�Ԏ�R�[�h�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �Ԏ�R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 ModelCode
    //    {
    //        get { return _modelCode; }
    //        set { _modelCode = value; }
    //    }

    //    /// public propaty name  :  ModelSubCode
    //    /// <summary>�Ԏ�T�u�R�[�h�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �Ԏ�T�u�R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 ModelSubCode
    //    {
    //        get { return _modelSubCode; }
    //        set { _modelSubCode = value; }
    //    }

    //    /// public propaty name  :  EngineModelNm
    //    /// <summary>�G���W���^�����̃v���p�e�B</summary>
    //    /// <value>�^���ɂ��ϓ�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �G���W���^�����̃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string EngineModelNm
    //    {
    //        get { return _engineModelNm; }
    //        set { _engineModelNm = value; }
    //    }

    //    /// public propaty name  :  ColorCode
    //    /// <summary>�J���[�R�[�h�v���p�e�B</summary>
    //    /// <value>�J�^���O�̐F�R�[�h</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �J���[�R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string ColorCode
    //    {
    //        get { return _colorCode; }
    //        set { _colorCode = value; }
    //    }

    //    /// public propaty name  :  TrimCode
    //    /// <summary>�g�����R�[�h�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �g�����R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string TrimCode
    //    {
    //        get { return _trimCode; }
    //        set { _trimCode = value; }
    //    }

    //    /// public propaty name  :  DeliveredGoodsDiv
    //    /// <summary>�[�i�敪�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �[�i�敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 DeliveredGoodsDiv
    //    {
    //        get { return _deliveredGoodsDiv; }
    //        set { _deliveredGoodsDiv = value; }
    //    }

    //    /// public propaty name  :  FullModelFixedNoAry
    //    /// <summary>�t���^���Œ�ԍ��z��v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �t���^���Œ�ԍ��z��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32[] FullModelFixedNoAry
    //    {
    //        get { return _fullModelFixedNoAry; }
    //        set { _fullModelFixedNoAry = value; }
    //    }

    //    /// public propaty name  :  CategoryObjAry
    //    /// <summary>�����I�u�W�F�N�g�z��v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �����I�u�W�F�N�g�z��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Byte[] CategoryObjAry
    //    {
    //        get { return _categoryObjAry; }
    //        set { _categoryObjAry = value; }
    //    }

    //    /// public propaty name  :  SalesInputCode
    //    /// <summary>������͎҃R�[�h�v���p�e�B</summary>
    //    /// <value>���͒S���ҁi���s�ҁj</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ������͎҃R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SalesInputCode
    //    {
    //        get { return _salesInputCode; }
    //        set { _salesInputCode = value; }
    //    }

    //    /// public propaty name  :  FrontEmployeeCd
    //    /// <summary>��t�]�ƈ��R�[�h�v���p�e�B</summary>
    //    /// <value>��t�S���ҁi�󒍎ҁj</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ��t�]�ƈ��R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string FrontEmployeeCd
    //    {
    //        get { return _frontEmployeeCd; }
    //        set { _frontEmployeeCd = value; }
    //    }


    //    /// <summary>
    //    /// ���Ӑ�d�q�������o����(�`�[�E����)�N���X���[�N�R���X�g���N�^
    //    /// </summary>
    //    /// <returns>CustPrtPprSalTblRsltWork�N���X�̃C���X�^���X</returns>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   CustPrtPprSalTblRsltWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public CustPrtPprSalTblRsltWork()
    //    {
    //    }

    //}

    ///// <summary>
    /////  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    ///// </summary>
    ///// <returns>CustPrtPprSalTblRsltWork�N���X�̃C���X�^���X(object)</returns>
    ///// <remarks>
    ///// <br>Note�@�@�@�@�@�@ :   CustPrtPprSalTblRsltWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    ///// <br>Programer        :   ��������</br>
    ///// </remarks>
    //public class CustPrtPprSalTblRsltWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    //{
    //    #region ICustomSerializationSurrogate �����o

    //    /// <summary>
    //    ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   CustPrtPprSalTblRsltWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public void Serialize( System.IO.BinaryWriter writer, object graph )
    //    {
    //        // TODO:  CustPrtPprSalTblRsltWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
    //        if ( writer == null )
    //            throw new ArgumentNullException();

    //        if ( graph != null && !(graph is CustPrtPprSalTblRsltWork || graph is ArrayList || graph is CustPrtPprSalTblRsltWork[]) )
    //            throw new ArgumentException( string.Format( "graph��{0}�̃C���X�^���X�ł���܂���", typeof( CustPrtPprSalTblRsltWork ).FullName ) );

    //        if ( graph != null && graph is CustPrtPprSalTblRsltWork )
    //        {
    //            Type t = graph.GetType();
    //            if ( !CustomFormatterServices.NeedCustomSerialization( t ) )
    //                throw new ArgumentException( string.Format( "graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName ) );
    //        }

    //        //SerializationTypeInfo
    //        Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CustPrtPprSalTblRsltWork" );

    //        //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
    //        int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
    //        if ( graph is ArrayList )
    //        {
    //            serInfo.RetTypeInfo = 0;
    //            occurrence = ((ArrayList)graph).Count;
    //        }
    //        else if ( graph is CustPrtPprSalTblRsltWork[] )
    //        {
    //            serInfo.RetTypeInfo = 2;
    //            occurrence = ((CustPrtPprSalTblRsltWork[])graph).Length;
    //        }
    //        else if ( graph is CustPrtPprSalTblRsltWork )
    //        {
    //            serInfo.RetTypeInfo = 1;
    //            occurrence = 1;
    //        }

    //        serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

    //        //�f�[�^�敪
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //DataDiv
    //        //������t
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //SalesDate
    //        //����`�[�ԍ�
    //        serInfo.MemberInfo.Add( typeof( string ) ); //SalesSlipNum
    //        //����s�ԍ�
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //SalesRowNo
    //        //�󒍃X�e�[�^�X
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //AcptAnOdrStatus
    //        //����`�[�敪
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //SalesSlipCd
    //        //�̔��]�ƈ�����
    //        serInfo.MemberInfo.Add( typeof( string ) ); //SalesEmployeeNm
    //        //����`�[���v�i�Ŕ����j
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //SalesTotalTaxExc
    //        //���i����
    //        serInfo.MemberInfo.Add( typeof( string ) ); //GoodsName
    //        //���i�ԍ�
    //        serInfo.MemberInfo.Add( typeof( string ) ); //GoodsNo
    //        //BL���i�R�[�h
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //BLGoodsCode
    //        //BL�O���[�v�R�[�h
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //BLGroupCode
    //        //�o�א�
    //        serInfo.MemberInfo.Add( typeof( Double ) ); //ShipmentCnt
    //        //�艿�i�Ŕ��C�����j
    //        serInfo.MemberInfo.Add( typeof( Double ) ); //ListPriceTaxExcFl
    //        //�I�[�v�����i�敪
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //OpenPriceDiv
    //        //����P���i�Ŕ��C�����j
    //        serInfo.MemberInfo.Add( typeof( Double ) ); //SalesUnPrcTaxExcFl
    //        //�����P��
    //        serInfo.MemberInfo.Add( typeof( Double ) ); //SalesUnitCost
    //        //������z�i�Ŕ����j
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //SalesMoneyTaxExc
    //        //����œ]�ŕ���
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //ConsTaxLayMethod
    //        //����`�[���v�i�ō��݁j
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //SalesTotalTaxInc
    //        //������z����Ŋz
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //SalesPriceConsTax
    //        //�������z�v
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //TotalCost
    //        //�^���w��ԍ�
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //ModelDesignationNo
    //        //�ޕʔԍ�
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //CategoryNo
    //        //�Ԏ�S�p����
    //        serInfo.MemberInfo.Add( typeof( string ) ); //ModelFullName
    //        //���N�x
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //FirstEntryDate
    //        //�ԑ䇂
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //SearchFrameNo
    //        //�^���i�t���^�j
    //        serInfo.MemberInfo.Add( typeof( string ) ); //FullModel
    //        //�`�[���l
    //        serInfo.MemberInfo.Add( typeof( string ) ); //SlipNote
    //        //�`�[���l�Q
    //        serInfo.MemberInfo.Add( typeof( string ) ); //SlipNote2
    //        //�`�[���l�R
    //        serInfo.MemberInfo.Add( typeof( string ) ); //SlipNote3
    //        //��t�]�ƈ�����
    //        serInfo.MemberInfo.Add( typeof( string ) ); //FrontEmployeeNm
    //        //������͎Җ���
    //        serInfo.MemberInfo.Add( typeof( string ) ); //SalesInputName
    //        //���Ӑ�R�[�h
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //CustomerCode
    //        //���Ӑ旪��
    //        serInfo.MemberInfo.Add( typeof( string ) ); //CustomerSnm
    //        //�d����R�[�h
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //SupplierCd
    //        //�d���旪��
    //        serInfo.MemberInfo.Add( typeof( string ) ); //SupplierSnm
    //        //�����`�[�ԍ�
    //        serInfo.MemberInfo.Add( typeof( string ) ); //PartySaleSlipNum
    //        //�ԗ��Ǘ��R�[�h
    //        serInfo.MemberInfo.Add( typeof( string ) ); //CarMngCode
    //        //�󒍔ԍ�
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //AcceptAnOrderNo
    //        //�v�㌳�o�ׇ�
    //        serInfo.MemberInfo.Add( typeof( string ) ); //ShipmSalesSlipNum
    //        //������(���ו\��)
    //        serInfo.MemberInfo.Add( typeof( string ) ); //SrcSalesSlipNum
    //        //����݌Ɏ�񂹋敪
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //SalesOrderDivCd
    //        //�q�ɖ���
    //        serInfo.MemberInfo.Add( typeof( string ) ); //WarehouseName
    //        //�d���`�[�ԍ�
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //SupplierSlipNo
    //        //UOE������R�[�h
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //UOESupplierCd
    //        //�����於(���ו\��)
    //        serInfo.MemberInfo.Add( typeof( string ) ); //UOESupplierSnm
    //        //�t�n�d���}�[�N�P
    //        serInfo.MemberInfo.Add( typeof( string ) ); //UoeRemark1
    //        //�t�n�d���}�[�N�Q
    //        serInfo.MemberInfo.Add( typeof( string ) ); //UoeRemark2
    //        //�K�C�h����
    //        serInfo.MemberInfo.Add( typeof( string ) ); //GuideName
    //        //���_�K�C�h����
    //        serInfo.MemberInfo.Add( typeof( string ) ); //SectionGuideNm
    //        //���ה��l
    //        serInfo.MemberInfo.Add( typeof( string ) ); //DtlNote
    //        //�J���[����1
    //        serInfo.MemberInfo.Add( typeof( string ) ); //ColorName1
    //        //�g��������
    //        serInfo.MemberInfo.Add( typeof( string ) ); //TrimName
    //        //��P���i�艿�j
    //        serInfo.MemberInfo.Add( typeof( Double ) ); //StdUnPrcLPrice
    //        //��P���i����P���j
    //        serInfo.MemberInfo.Add( typeof( Double ) ); //StdUnPrcSalUnPrc
    //        //��P���i�����P���j
    //        serInfo.MemberInfo.Add( typeof( Double ) ); //StdUnPrcUnCst
    //        //���i���[�J�[�R�[�h
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //GoodsMakerCd
    //        //���[�J�[����
    //        serInfo.MemberInfo.Add( typeof( string ) ); //MakerName
    //        //����
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //Cost
    //        //���Ӑ�`�[�ԍ�
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //CustSlipNo
    //        //�v����t
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //AddUpADate
    //        //���|�敪
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //AccRecDivCd
    //        //�ԓ`�敪
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //DebitNoteDiv
    //        //���_�R�[�h
    //        serInfo.MemberInfo.Add( typeof( string ) ); //SectionCode
    //        //�q�ɃR�[�h
    //        serInfo.MemberInfo.Add( typeof( string ) ); //WarehouseCode
    //        //���z�\�����@�敪
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //TotalAmountDispWayCd
    //        //�ېŋ敪[����]
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //TaxationDivCd
    //        //�����`�[�ԍ�
    //        serInfo.MemberInfo.Add( typeof( string ) ); //StockPartySaleSlipNum
    //        //�[�i��R�[�h
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //AddresseeCode
    //        //�[�i�於��
    //        serInfo.MemberInfo.Add( typeof( string ) ); //AddresseeName
    //        //�[�i�於��2
    //        serInfo.MemberInfo.Add( typeof( string ) ); //AddresseeName2
    //        //�ԑ�ԍ�
    //        serInfo.MemberInfo.Add( typeof( string ) ); //FrameNo
    //        //�󒍎c��
    //        serInfo.MemberInfo.Add( typeof( Double ) ); //AcptAnOdrRemainCnt
    //        //���Е��ރR�[�h
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //EnterpriseGanreCode
    //        //�萔�������z
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //FeeDeposit
    //        //�l�������z
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //DiscountDeposit
    //        //���͓�
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //InputDay
    //        //���i����
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //GoodsKindCode
    //        //���i�啪�ރR�[�h
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //GoodsLGroup
    //        //���i�����ރR�[�h
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //GoodsMGroup
    //        //�q�ɒI��
    //        serInfo.MemberInfo.Add( typeof( string ) ); //WarehouseShelfNo
    //        //����`�[�敪�i���ׁj
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //SalesSlipCdDtl
    //        //���i�啪�ޖ���
    //        serInfo.MemberInfo.Add( typeof( string ) ); //GoodsLGroupName
    //        //���i�����ޖ���
    //        serInfo.MemberInfo.Add( typeof( string ) ); //GoodsMGroupName
    //        //�ԗ��Ǘ��ԍ�
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //CarMngNo
    //        //���[�J�[�R�[�h
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //MakerCode
    //        //�Ԏ�R�[�h
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //ModelCode
    //        //�Ԏ�T�u�R�[�h
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //ModelSubCode
    //        //�G���W���^������
    //        serInfo.MemberInfo.Add( typeof( string ) ); //EngineModelNm
    //        //�J���[�R�[�h
    //        serInfo.MemberInfo.Add( typeof( string ) ); //ColorCode
    //        //�g�����R�[�h
    //        serInfo.MemberInfo.Add( typeof( string ) ); //TrimCode
    //        //�[�i�敪
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //DeliveredGoodsDiv
    //        //�t���^���Œ�ԍ��z��
    //        serInfo.MemberInfo.Add( typeof( Int32[] ) ); //FullModelFixedNoAry
    //        //�����I�u�W�F�N�g�z��
    //        serInfo.MemberInfo.Add( typeof( Byte[] ) ); //CategoryObjAry
    //        //������͎҃R�[�h
    //        serInfo.MemberInfo.Add( typeof( string ) ); //SalesInputCode
    //        //��t�]�ƈ��R�[�h
    //        serInfo.MemberInfo.Add( typeof( string ) ); //FrontEmployeeCd


    //        serInfo.Serialize( writer, serInfo );
    //        if ( graph is CustPrtPprSalTblRsltWork )
    //        {
    //            CustPrtPprSalTblRsltWork temp = (CustPrtPprSalTblRsltWork)graph;

    //            SetCustPrtPprSalTblRsltWork( writer, temp );
    //        }
    //        else
    //        {
    //            ArrayList lst = null;
    //            if ( graph is CustPrtPprSalTblRsltWork[] )
    //            {
    //                lst = new ArrayList();
    //                lst.AddRange( (CustPrtPprSalTblRsltWork[])graph );
    //            }
    //            else
    //            {
    //                lst = (ArrayList)graph;
    //            }

    //            foreach ( CustPrtPprSalTblRsltWork temp in lst )
    //            {
    //                SetCustPrtPprSalTblRsltWork( writer, temp );
    //            }

    //        }


    //    }


    //    /// <summary>
    //    /// CustPrtPprSalTblRsltWork�����o��(public�v���p�e�B��)
    //    /// </summary>
    //    private const int currentMemberCount = 97;

    //    /// <summary>
    //    ///  CustPrtPprSalTblRsltWork�C���X�^���X��������
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   CustPrtPprSalTblRsltWork�̃C���X�^���X����������</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    private void SetCustPrtPprSalTblRsltWork( System.IO.BinaryWriter writer, CustPrtPprSalTblRsltWork temp )
    //    {
    //        //�f�[�^�敪
    //        writer.Write( temp.DataDiv );
    //        //������t
    //        writer.Write( (Int64)temp.SalesDate.Ticks );
    //        //����`�[�ԍ�
    //        writer.Write( temp.SalesSlipNum );
    //        //����s�ԍ�
    //        writer.Write( temp.SalesRowNo );
    //        //�󒍃X�e�[�^�X
    //        writer.Write( temp.AcptAnOdrStatus );
    //        //����`�[�敪
    //        writer.Write( temp.SalesSlipCd );
    //        //�̔��]�ƈ�����
    //        writer.Write( temp.SalesEmployeeNm );
    //        //����`�[���v�i�Ŕ����j
    //        writer.Write( temp.SalesTotalTaxExc );
    //        //���i����
    //        writer.Write( temp.GoodsName );
    //        //���i�ԍ�
    //        writer.Write( temp.GoodsNo );
    //        //BL���i�R�[�h
    //        writer.Write( temp.BLGoodsCode );
    //        //BL�O���[�v�R�[�h
    //        writer.Write( temp.BLGroupCode );
    //        //�o�א�
    //        writer.Write( temp.ShipmentCnt );
    //        //�艿�i�Ŕ��C�����j
    //        writer.Write( temp.ListPriceTaxExcFl );
    //        //�I�[�v�����i�敪
    //        writer.Write( temp.OpenPriceDiv );
    //        //����P���i�Ŕ��C�����j
    //        writer.Write( temp.SalesUnPrcTaxExcFl );
    //        //�����P��
    //        writer.Write( temp.SalesUnitCost );
    //        //������z�i�Ŕ����j
    //        writer.Write( temp.SalesMoneyTaxExc );
    //        //����œ]�ŕ���
    //        writer.Write( temp.ConsTaxLayMethod );
    //        //����`�[���v�i�ō��݁j
    //        writer.Write( temp.SalesTotalTaxInc );
    //        //������z����Ŋz
    //        writer.Write( temp.SalesPriceConsTax );
    //        //�������z�v
    //        writer.Write( temp.TotalCost );
    //        //�^���w��ԍ�
    //        writer.Write( temp.ModelDesignationNo );
    //        //�ޕʔԍ�
    //        writer.Write( temp.CategoryNo );
    //        //�Ԏ�S�p����
    //        writer.Write( temp.ModelFullName );
    //        //���N�x
    //        writer.Write( (Int64)temp.FirstEntryDate.Ticks );
    //        //�ԑ䇂
    //        writer.Write( temp.SearchFrameNo );
    //        //�^���i�t���^�j
    //        writer.Write( temp.FullModel );
    //        //�`�[���l
    //        writer.Write( temp.SlipNote );
    //        //�`�[���l�Q
    //        writer.Write( temp.SlipNote2 );
    //        //�`�[���l�R
    //        writer.Write( temp.SlipNote3 );
    //        //��t�]�ƈ�����
    //        writer.Write( temp.FrontEmployeeNm );
    //        //������͎Җ���
    //        writer.Write( temp.SalesInputName );
    //        //���Ӑ�R�[�h
    //        writer.Write( temp.CustomerCode );
    //        //���Ӑ旪��
    //        writer.Write( temp.CustomerSnm );
    //        //�d����R�[�h
    //        writer.Write( temp.SupplierCd );
    //        //�d���旪��
    //        writer.Write( temp.SupplierSnm );
    //        //�����`�[�ԍ�
    //        writer.Write( temp.PartySaleSlipNum );
    //        //�ԗ��Ǘ��R�[�h
    //        writer.Write( temp.CarMngCode );
    //        //�󒍔ԍ�
    //        writer.Write( temp.AcceptAnOrderNo );
    //        //�v�㌳�o�ׇ�
    //        writer.Write( temp.ShipmSalesSlipNum );
    //        //������(���ו\��)
    //        writer.Write( temp.SrcSalesSlipNum );
    //        //����݌Ɏ�񂹋敪
    //        writer.Write( temp.SalesOrderDivCd );
    //        //�q�ɖ���
    //        writer.Write( temp.WarehouseName );
    //        //�d���`�[�ԍ�
    //        writer.Write( temp.SupplierSlipNo );
    //        //UOE������R�[�h
    //        writer.Write( temp.UOESupplierCd );
    //        //�����於(���ו\��)
    //        writer.Write( temp.UOESupplierSnm );
    //        //�t�n�d���}�[�N�P
    //        writer.Write( temp.UoeRemark1 );
    //        //�t�n�d���}�[�N�Q
    //        writer.Write( temp.UoeRemark2 );
    //        //�K�C�h����
    //        writer.Write( temp.GuideName );
    //        //���_�K�C�h����
    //        writer.Write( temp.SectionGuideNm );
    //        //���ה��l
    //        writer.Write( temp.DtlNote );
    //        //�J���[����1
    //        writer.Write( temp.ColorName1 );
    //        //�g��������
    //        writer.Write( temp.TrimName );
    //        //��P���i�艿�j
    //        writer.Write( temp.StdUnPrcLPrice );
    //        //��P���i����P���j
    //        writer.Write( temp.StdUnPrcSalUnPrc );
    //        //��P���i�����P���j
    //        writer.Write( temp.StdUnPrcUnCst );
    //        //���i���[�J�[�R�[�h
    //        writer.Write( temp.GoodsMakerCd );
    //        //���[�J�[����
    //        writer.Write( temp.MakerName );
    //        //����
    //        writer.Write( temp.Cost );
    //        //���Ӑ�`�[�ԍ�
    //        writer.Write( temp.CustSlipNo );
    //        //�v����t
    //        writer.Write( (Int64)temp.AddUpADate.Ticks );
    //        //���|�敪
    //        writer.Write( temp.AccRecDivCd );
    //        //�ԓ`�敪
    //        writer.Write( temp.DebitNoteDiv );
    //        //���_�R�[�h
    //        writer.Write( temp.SectionCode );
    //        //�q�ɃR�[�h
    //        writer.Write( temp.WarehouseCode );
    //        //���z�\�����@�敪
    //        writer.Write( temp.TotalAmountDispWayCd );
    //        //�ېŋ敪[����]
    //        writer.Write( temp.TaxationDivCd );
    //        //�����`�[�ԍ�
    //        writer.Write( temp.StockPartySaleSlipNum );
    //        //�[�i��R�[�h
    //        writer.Write( temp.AddresseeCode );
    //        //�[�i�於��
    //        writer.Write( temp.AddresseeName );
    //        //�[�i�於��2
    //        writer.Write( temp.AddresseeName2 );
    //        //�ԑ�ԍ�
    //        writer.Write( temp.FrameNo );
    //        //�󒍎c��
    //        writer.Write( temp.AcptAnOdrRemainCnt );
    //        //���Е��ރR�[�h
    //        writer.Write( temp.EnterpriseGanreCode );
    //        //�萔�������z
    //        writer.Write( temp.FeeDeposit );
    //        //�l�������z
    //        writer.Write( temp.DiscountDeposit );
    //        //���͓�
    //        writer.Write( (Int64)temp.InputDay.Ticks );
    //        //���i����
    //        writer.Write( temp.GoodsKindCode );
    //        //���i�啪�ރR�[�h
    //        writer.Write( temp.GoodsLGroup );
    //        //���i�����ރR�[�h
    //        writer.Write( temp.GoodsMGroup );
    //        //�q�ɒI��
    //        writer.Write( temp.WarehouseShelfNo );
    //        //����`�[�敪�i���ׁj
    //        writer.Write( temp.SalesSlipCdDtl );
    //        //���i�啪�ޖ���
    //        writer.Write( temp.GoodsLGroupName );
    //        //���i�����ޖ���
    //        writer.Write( temp.GoodsMGroupName );
    //        //�ԗ��Ǘ��ԍ�
    //        writer.Write( temp.CarMngNo );
    //        //���[�J�[�R�[�h
    //        writer.Write( temp.MakerCode );
    //        //�Ԏ�R�[�h
    //        writer.Write( temp.ModelCode );
    //        //�Ԏ�T�u�R�[�h
    //        writer.Write( temp.ModelSubCode );
    //        //�G���W���^������
    //        writer.Write( temp.EngineModelNm );
    //        //�J���[�R�[�h
    //        writer.Write( temp.ColorCode );
    //        //�g�����R�[�h
    //        writer.Write( temp.TrimCode );
    //        //�[�i�敪
    //        writer.Write( temp.DeliveredGoodsDiv );
    //        //�t���^���Œ�ԍ��z��
    //        if ( temp.FullModelFixedNoAry == null ) temp.FullModelFixedNoAry = new int[0];
    //        int length = temp.FullModelFixedNoAry.Length;
    //        writer.Write( length );
    //        for ( int cnt = 0; cnt < length; cnt++ )
    //            writer.Write( temp.FullModelFixedNoAry[cnt] );
    //        //�����I�u�W�F�N�g�z��
    //        if ( temp.CategoryObjAry == null ) temp.CategoryObjAry = new byte[0];
    //        writer.Write( temp.CategoryObjAry.Length );
    //        writer.Write( temp.CategoryObjAry );
    //        //������͎҃R�[�h
    //        writer.Write( temp.SalesInputCode );
    //        //��t�]�ƈ��R�[�h
    //        writer.Write( temp.FrontEmployeeCd );

    //    }

    //    /// <summary>
    //    ///  CustPrtPprSalTblRsltWork�C���X�^���X�擾
    //    /// </summary>
    //    /// <returns>CustPrtPprSalTblRsltWork�N���X�̃C���X�^���X</returns>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   CustPrtPprSalTblRsltWork�̃C���X�^���X���擾���܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    private CustPrtPprSalTblRsltWork GetCustPrtPprSalTblRsltWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
    //    {
    //        // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
    //        // serInfo.MemberInfo.Count < currentMemberCount
    //        // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

    //        CustPrtPprSalTblRsltWork temp = new CustPrtPprSalTblRsltWork();

    //        //�f�[�^�敪
    //        temp.DataDiv = reader.ReadInt32();
    //        //������t
    //        temp.SalesDate = new DateTime( reader.ReadInt64() );
    //        //����`�[�ԍ�
    //        temp.SalesSlipNum = reader.ReadString();
    //        //����s�ԍ�
    //        temp.SalesRowNo = reader.ReadInt32();
    //        //�󒍃X�e�[�^�X
    //        temp.AcptAnOdrStatus = reader.ReadInt32();
    //        //����`�[�敪
    //        temp.SalesSlipCd = reader.ReadInt32();
    //        //�̔��]�ƈ�����
    //        temp.SalesEmployeeNm = reader.ReadString();
    //        //����`�[���v�i�Ŕ����j
    //        temp.SalesTotalTaxExc = reader.ReadInt64();
    //        //���i����
    //        temp.GoodsName = reader.ReadString();
    //        //���i�ԍ�
    //        temp.GoodsNo = reader.ReadString();
    //        //BL���i�R�[�h
    //        temp.BLGoodsCode = reader.ReadInt32();
    //        //BL�O���[�v�R�[�h
    //        temp.BLGroupCode = reader.ReadInt32();
    //        //�o�א�
    //        temp.ShipmentCnt = reader.ReadDouble();
    //        //�艿�i�Ŕ��C�����j
    //        temp.ListPriceTaxExcFl = reader.ReadDouble();
    //        //�I�[�v�����i�敪
    //        temp.OpenPriceDiv = reader.ReadInt32();
    //        //����P���i�Ŕ��C�����j
    //        temp.SalesUnPrcTaxExcFl = reader.ReadDouble();
    //        //�����P��
    //        temp.SalesUnitCost = reader.ReadDouble();
    //        //������z�i�Ŕ����j
    //        temp.SalesMoneyTaxExc = reader.ReadInt64();
    //        //����œ]�ŕ���
    //        temp.ConsTaxLayMethod = reader.ReadInt32();
    //        //����`�[���v�i�ō��݁j
    //        temp.SalesTotalTaxInc = reader.ReadInt64();
    //        //������z����Ŋz
    //        temp.SalesPriceConsTax = reader.ReadInt64();
    //        //�������z�v
    //        temp.TotalCost = reader.ReadInt64();
    //        //�^���w��ԍ�
    //        temp.ModelDesignationNo = reader.ReadInt32();
    //        //�ޕʔԍ�
    //        temp.CategoryNo = reader.ReadInt32();
    //        //�Ԏ�S�p����
    //        temp.ModelFullName = reader.ReadString();
    //        //���N�x
    //        temp.FirstEntryDate = new DateTime( reader.ReadInt64() );
    //        //�ԑ䇂
    //        temp.SearchFrameNo = reader.ReadInt32();
    //        //�^���i�t���^�j
    //        temp.FullModel = reader.ReadString();
    //        //�`�[���l
    //        temp.SlipNote = reader.ReadString();
    //        //�`�[���l�Q
    //        temp.SlipNote2 = reader.ReadString();
    //        //�`�[���l�R
    //        temp.SlipNote3 = reader.ReadString();
    //        //��t�]�ƈ�����
    //        temp.FrontEmployeeNm = reader.ReadString();
    //        //������͎Җ���
    //        temp.SalesInputName = reader.ReadString();
    //        //���Ӑ�R�[�h
    //        temp.CustomerCode = reader.ReadInt32();
    //        //���Ӑ旪��
    //        temp.CustomerSnm = reader.ReadString();
    //        //�d����R�[�h
    //        temp.SupplierCd = reader.ReadInt32();
    //        //�d���旪��
    //        temp.SupplierSnm = reader.ReadString();
    //        //�����`�[�ԍ�
    //        temp.PartySaleSlipNum = reader.ReadString();
    //        //�ԗ��Ǘ��R�[�h
    //        temp.CarMngCode = reader.ReadString();
    //        //�󒍔ԍ�
    //        temp.AcceptAnOrderNo = reader.ReadInt32();
    //        //�v�㌳�o�ׇ�
    //        temp.ShipmSalesSlipNum = reader.ReadString();
    //        //������(���ו\��)
    //        temp.SrcSalesSlipNum = reader.ReadString();
    //        //����݌Ɏ�񂹋敪
    //        temp.SalesOrderDivCd = reader.ReadInt32();
    //        //�q�ɖ���
    //        temp.WarehouseName = reader.ReadString();
    //        //�d���`�[�ԍ�
    //        temp.SupplierSlipNo = reader.ReadInt32();
    //        //UOE������R�[�h
    //        temp.UOESupplierCd = reader.ReadInt32();
    //        //�����於(���ו\��)
    //        temp.UOESupplierSnm = reader.ReadString();
    //        //�t�n�d���}�[�N�P
    //        temp.UoeRemark1 = reader.ReadString();
    //        //�t�n�d���}�[�N�Q
    //        temp.UoeRemark2 = reader.ReadString();
    //        //�K�C�h����
    //        temp.GuideName = reader.ReadString();
    //        //���_�K�C�h����
    //        temp.SectionGuideNm = reader.ReadString();
    //        //���ה��l
    //        temp.DtlNote = reader.ReadString();
    //        //�J���[����1
    //        temp.ColorName1 = reader.ReadString();
    //        //�g��������
    //        temp.TrimName = reader.ReadString();
    //        //��P���i�艿�j
    //        temp.StdUnPrcLPrice = reader.ReadDouble();
    //        //��P���i����P���j
    //        temp.StdUnPrcSalUnPrc = reader.ReadDouble();
    //        //��P���i�����P���j
    //        temp.StdUnPrcUnCst = reader.ReadDouble();
    //        //���i���[�J�[�R�[�h
    //        temp.GoodsMakerCd = reader.ReadInt32();
    //        //���[�J�[����
    //        temp.MakerName = reader.ReadString();
    //        //����
    //        temp.Cost = reader.ReadInt64();
    //        //���Ӑ�`�[�ԍ�
    //        temp.CustSlipNo = reader.ReadInt32();
    //        //�v����t
    //        temp.AddUpADate = new DateTime( reader.ReadInt64() );
    //        //���|�敪
    //        temp.AccRecDivCd = reader.ReadInt32();
    //        //�ԓ`�敪
    //        temp.DebitNoteDiv = reader.ReadInt32();
    //        //���_�R�[�h
    //        temp.SectionCode = reader.ReadString();
    //        //�q�ɃR�[�h
    //        temp.WarehouseCode = reader.ReadString();
    //        //���z�\�����@�敪
    //        temp.TotalAmountDispWayCd = reader.ReadInt32();
    //        //�ېŋ敪[����]
    //        temp.TaxationDivCd = reader.ReadInt32();
    //        //�����`�[�ԍ�
    //        temp.StockPartySaleSlipNum = reader.ReadString();
    //        //�[�i��R�[�h
    //        temp.AddresseeCode = reader.ReadInt32();
    //        //�[�i�於��
    //        temp.AddresseeName = reader.ReadString();
    //        //�[�i�於��2
    //        temp.AddresseeName2 = reader.ReadString();
    //        //�ԑ�ԍ�
    //        temp.FrameNo = reader.ReadString();
    //        //�󒍎c��
    //        temp.AcptAnOdrRemainCnt = reader.ReadDouble();
    //        //���Е��ރR�[�h
    //        temp.EnterpriseGanreCode = reader.ReadInt32();
    //        //�萔�������z
    //        temp.FeeDeposit = reader.ReadInt64();
    //        //�l�������z
    //        temp.DiscountDeposit = reader.ReadInt64();
    //        //���͓�
    //        temp.InputDay = new DateTime( reader.ReadInt64() );
    //        //���i����
    //        temp.GoodsKindCode = reader.ReadInt32();
    //        //���i�啪�ރR�[�h
    //        temp.GoodsLGroup = reader.ReadInt32();
    //        //���i�����ރR�[�h
    //        temp.GoodsMGroup = reader.ReadInt32();
    //        //�q�ɒI��
    //        temp.WarehouseShelfNo = reader.ReadString();
    //        //����`�[�敪�i���ׁj
    //        temp.SalesSlipCdDtl = reader.ReadInt32();
    //        //���i�啪�ޖ���
    //        temp.GoodsLGroupName = reader.ReadString();
    //        //���i�����ޖ���
    //        temp.GoodsMGroupName = reader.ReadString();
    //        //�ԗ��Ǘ��ԍ�
    //        temp.CarMngNo = reader.ReadInt32();
    //        //���[�J�[�R�[�h
    //        temp.MakerCode = reader.ReadInt32();
    //        //�Ԏ�R�[�h
    //        temp.ModelCode = reader.ReadInt32();
    //        //�Ԏ�T�u�R�[�h
    //        temp.ModelSubCode = reader.ReadInt32();
    //        //�G���W���^������
    //        temp.EngineModelNm = reader.ReadString();
    //        //�J���[�R�[�h
    //        temp.ColorCode = reader.ReadString();
    //        //�g�����R�[�h
    //        temp.TrimCode = reader.ReadString();
    //        //�[�i�敪
    //        temp.DeliveredGoodsDiv = reader.ReadInt32();
    //        //�t���^���Œ�ԍ��z��
    //        int length = reader.ReadInt32();
    //        temp.FullModelFixedNoAry = new int[length];
    //        for ( int cnt = 0; cnt < length; cnt++ )
    //            temp.FullModelFixedNoAry[cnt] = reader.ReadInt32();
    //        //�����I�u�W�F�N�g�z��
    //        length = reader.ReadInt32();
    //        temp.CategoryObjAry = reader.ReadBytes( length );
    //        //������͎҃R�[�h
    //        temp.SalesInputCode = reader.ReadString();
    //        //��t�]�ƈ��R�[�h
    //        temp.FrontEmployeeCd = reader.ReadString();


    //        //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
    //        //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
    //        //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
    //        //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
    //        for ( int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k )
    //        {
    //            //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
    //            //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
    //            //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
    //            //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
    //            int optCount = 0;
    //            object oMemberType = serInfo.MemberInfo[k];
    //            if ( oMemberType is Type )
    //            {
    //                Type t = (Type)oMemberType;
    //                object oData = TypeDeserializer.DeserializePrimitiveType( reader, t, optCount );
    //                if ( t.Equals( typeof( int ) ) )
    //                {
    //                    optCount = Convert.ToInt32( oData );
    //                }
    //                else
    //                {
    //                    optCount = 0;
    //                }
    //            }
    //            else if ( oMemberType is string )
    //            {
    //                Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate( (string)oMemberType );
    //                object userData = formatter.Deserialize( reader );  //�ǂݔ�΂�
    //            }
    //        }
    //        return temp;
    //    }

    //    /// <summary>
    //    ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
    //    /// </summary>
    //    /// <returns>CustPrtPprSalTblRsltWork�N���X�̃C���X�^���X(object)</returns>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   CustPrtPprSalTblRsltWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public object Deserialize( System.IO.BinaryReader reader )
    //    {
    //        object retValue = null;
    //        Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
    //        ArrayList lst = new ArrayList();
    //        for ( int cnt = 0; cnt < serInfo.Occurrence; ++cnt )
    //        {
    //            CustPrtPprSalTblRsltWork temp = GetCustPrtPprSalTblRsltWork( reader, serInfo );
    //            lst.Add( temp );
    //        }
    //        switch ( serInfo.RetTypeInfo )
    //        {
    //            case 0:
    //                retValue = lst;
    //                break;
    //            case 1:
    //                retValue = lst[0];
    //                break;
    //            case 2:
    //                retValue = (CustPrtPprSalTblRsltWork[])lst.ToArray( typeof( CustPrtPprSalTblRsltWork ) );
    //                break;
    //        }
    //        return retValue;
    //    }

    //    #endregion
    //}
    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.10 ADD
    # endregion

# if false
    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
    /// public class name:   CustPrtPprSalTblRsltWork
    /// <summary>
    ///                      ���Ӑ�d�q�������o����(�`�[�E����)�N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���Ӑ�d�q�������o����(�`�[�E����)�N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/08/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CustPrtPprSalTblRsltWork
    {
        /// <summary>�f�[�^�敪</summary>
        /// <remarks>0:����f�[�^ 1:�����f�[�^</remarks>
        private Int32 _dataDiv;

        /// <summary>������t</summary>
        /// <remarks>������t(YYYYMMDD)/�������t</remarks>
        private DateTime _salesDate;

        /// <summary>����`�[�ԍ�</summary>
        /// <remarks>����`�[�ԍ�/�����`�[�ԍ�</remarks>
        private string _salesSlipNum = "";

        /// <summary>����s�ԍ�</summary>
        /// <remarks>����s�ԍ�/�����s�ԍ�</remarks>
        private Int32 _salesRowNo;

        /// <summary>�󒍃X�e�[�^�X</summary>
        /// <remarks>10:����,20:��,30:����,40:�o��</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>����`�[�敪</summary>
        /// <remarks>0:����,1:�ԕi</remarks>
        private Int32 _salesSlipCd;

        /// <summary>�̔��]�ƈ�����</summary>
        /// <remarks>�̔��]�ƈ�����/�����S���Җ���</remarks>
        private string _salesEmployeeNm = "";

        /// <summary>����`�[���v�i�Ŕ����j</summary>
        /// <remarks>����`�[���v�i�Ŕ����j/�����̏ꍇ(�������z+�l��+�萔��)</remarks>
        private Int64 _salesTotalTaxExc;

        /// <summary>���i����</summary>
        /// <remarks>���i����/���햼��</remarks>
        private string _goodsName = "";

        /// <summary>���i�ԍ�</summary>
        /// <remarks>���i�ԍ�</remarks>
        private string _goodsNo = "";

        /// <summary>BL���i�R�[�h</summary>
        /// <remarks>BL���i�R�[�h</remarks>
        private Int32 _bLGoodsCode;

        /// <summary>BL�O���[�v�R�[�h</summary>
        /// <remarks>BL�O���[�v�R�[�h</remarks>
        private Int32 _bLGroupCode;

        /// <summary>�o�א�</summary>
        /// <remarks>�o�א�</remarks>
        private Double _shipmentCnt;

        /// <summary>�艿�i�Ŕ��C�����j</summary>
        /// <remarks>�艿�i�Ŕ����A�����j�܂���"�I�[�v�����i"</remarks>
        private Double _listPriceTaxExcFl;

        /// <summary>�I�[�v�����i�敪</summary>
        /// <remarks>0:�ʏ�^1:�I�[�v�����i</remarks>
        private Int32 _openPriceDiv;

        /// <summary>����P���i�Ŕ��C�����j</summary>
        /// <remarks>����P���i�Ŕ��C�����j</remarks>
        private Double _salesUnPrcTaxExcFl;

        /// <summary>�����P��</summary>
        /// <remarks>�����P��</remarks>
        private Double _salesUnitCost;

        /// <summary>������z�i�Ŕ����j</summary>
        /// <remarks>������z�i�Ŕ����j/�������z</remarks>
        private Int64 _salesMoneyTaxExc;

        /// <summary>����œ]�ŕ���</summary>
        /// <remarks>0:�`�[�P��1:���גP��2:�����e 3:�����q 9:��ې�</remarks>
        private Int32 _consTaxLayMethod;

        /// <summary>����`�[���v�i�ō��݁j</summary>
        /// <remarks>����f�[�^</remarks>
        private Int64 _salesTotalTaxInc;

        /// <summary>������z����Ŋz</summary>
        /// <remarks>���㖾�׃f�[�^</remarks>
        private Int64 _salesPriceConsTax;

        /// <summary>�������z�v</summary>
        /// <remarks>����f�[�^</remarks>
        private Int64 _totalCost;

        /// <summary>�^���w��ԍ�</summary>
        private Int32 _modelDesignationNo;

        /// <summary>�ޕʔԍ�</summary>
        /// <remarks>�ޕʔԍ�</remarks>
        private Int32 _categoryNo;

        /// <summary>�Ԏ�S�p����</summary>
        /// <remarks>�Ԏ�S�p����</remarks>
        private string _modelFullName = "";

        /// <summary>���N�x</summary>
        /// <remarks>���N�x(YYYYMM)</remarks>
        private DateTime _firstEntryDate;

        /// <summary>�ԑ䇂</summary>
        /// <remarks>�ԑ�ԍ��i�����p�j</remarks>
        private Int32 _searchFrameNo;

        /// <summary>�^���i�t���^�j</summary>
        /// <remarks>�^���i�t���^�j</remarks>
        private string _fullModel = "";

        /// <summary>�`�[���l</summary>
        /// <remarks>�`�[���l/�`�[�E�v</remarks>
        private string _slipNote = "";

        /// <summary>�`�[���l�Q</summary>
        /// <remarks>�`�[���l�Q</remarks>
        private string _slipNote2 = "";

        /// <summary>�`�[���l�R</summary>
        /// <remarks>�`�[���l�R</remarks>
        private string _slipNote3 = "";

        /// <summary>��t�]�ƈ�����</summary>
        /// <remarks>��t�]�ƈ�����</remarks>
        private string _frontEmployeeNm = "";

        /// <summary>������͎Җ���</summary>
        /// <remarks>������͎Җ���/�������͎Җ���</remarks>
        private string _salesInputName = "";

        /// <summary>���Ӑ�R�[�h</summary>
        /// <remarks>���Ӑ�R�[�h/���Ӑ�R�[�h</remarks>
        private Int32 _customerCode;

        /// <summary>���Ӑ旪��</summary>
        /// <remarks>���Ӑ旪��</remarks>
        private string _customerSnm = "";

        /// <summary>�d����R�[�h</summary>
        /// <remarks>�d����R�[�h</remarks>
        private Int32 _supplierCd;

        /// <summary>�d���旪��</summary>
        /// <remarks>�d���旪��</remarks>
        private string _supplierSnm = "";

        /// <summary>�����`�[�ԍ�</summary>
        /// <remarks>�����`�[�ԍ�</remarks>
        private string _partySaleSlipNum = "";

        /// <summary>�ԗ��Ǘ��R�[�h</summary>
        /// <remarks>���q�Ǘ��R�[�h</remarks>
        private string _carMngCode = "";

        /// <summary>�󒍔ԍ�</summary>
        /// <remarks>�v�㌳�󒍔ԍ�</remarks>
        private Int32 _acceptAnOrderNo;

        /// <summary>�v�㌳�o�ׇ�</summary>
        /// <remarks>�v�㌳�o�הԍ�</remarks>
        private string _shipmSalesSlipNum = "";

        /// <summary>������(���ו\��)</summary>
        /// <remarks>�����`�ԍ�</remarks>
        private string _srcSalesSlipNum = "";

        /// <summary>����݌Ɏ�񂹋敪</summary>
        /// <remarks>����݌Ɏ�񂹋敪(0:��񂹁C1:�݌�)</remarks>
        private Int32 _salesOrderDivCd;

        /// <summary>�q�ɖ���</summary>
        /// <remarks>�q�ɖ���</remarks>
        private string _warehouseName = "";

        /// <summary>�d���`�[�ԍ�</summary>
        /// <remarks>�����d���`�[�ԍ�</remarks>
        private Int32 _supplierSlipNo;

        /// <summary>UOE������R�[�h</summary>
        /// <remarks>�t�n�d�����f�[�^</remarks>
        private Int32 _uOESupplierCd;

        /// <summary>�����於(���ו\��)</summary>
        /// <remarks>�t�n�d�����f�[�^</remarks>
        private string _uOESupplierSnm = "";

        /// <summary>�t�n�d���}�[�N�P</summary>
        /// <remarks>�t�n�d���}�[�N�P</remarks>
        private string _uoeRemark1 = "";

        /// <summary>�t�n�d���}�[�N�Q</summary>
        /// <remarks>�t�n�d���}�[�N�Q</remarks>
        private string _uoeRemark2 = "";

        /// <summary>�K�C�h����</summary>
        /// <remarks>�K�C�h����</remarks>
        private string _guideName = "";

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>���_�K�C�h����/�v�㋒�_�R�[�h</remarks>
        private string _sectionGuideNm = "";

        /// <summary>���ה��l</summary>
        /// <remarks>���ה��l/</remarks>
        private string _dtlNote = "";

        /// <summary>�J���[����1</summary>
        /// <remarks>�J���[����1</remarks>
        private string _colorName1 = "";

        /// <summary>�g��������</summary>
        /// <remarks>�g��������</remarks>
        private string _trimName = "";

        /// <summary>��P���i�艿�j</summary>
        /// <remarks>��P���i�艿�j</remarks>
        private Double _stdUnPrcLPrice;

        /// <summary>��P���i����P���j</summary>
        /// <remarks>��P���i����P���j</remarks>
        private Double _stdUnPrcSalUnPrc;

        /// <summary>��P���i�����P���j</summary>
        /// <remarks>��P���i�����P���j</remarks>
        private Double _stdUnPrcUnCst;

        /// <summary>���i���[�J�[�R�[�h</summary>
        /// <remarks>���i���[�J�[�R�[�h</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>���[�J�[����</summary>
        /// <remarks>���[�J�[����</remarks>
        private string _makerName = "";

        /// <summary>����</summary>
        /// <remarks>���㖾�׃f�[�^</remarks>
        private Int64 _cost;

        /// <summary>���Ӑ�`�[�ԍ�</summary>
        /// <remarks>���Ӑ�`�[�ԍ�</remarks>
        private Int32 _custSlipNo;

        /// <summary>�v����t</summary>
        /// <remarks>�v����t(YYYYMMDD)/�v����t(YYYYMMDD)</remarks>
        private DateTime _addUpADate;

        /// <summary>���|�敪</summary>
        /// <remarks>���|�敪(0:���|�Ȃ�,1:���|)</remarks>
        private Int32 _accRecDivCd;

        /// <summary>�ԓ`�敪</summary>
        /// <remarks>�ԓ`�敪(0:���`,1:�ԓ`,2:����)/�����ԍ��敪(0:��,1:��,2:���E�ςݍ�)</remarks>
        private Int32 _debitNoteDiv;

        /// <summary>���_�R�[�h</summary>
        /// <remarks>���_�R�[�h</remarks>
        private string _sectionCode = "";

        /// <summary>�q�ɃR�[�h</summary>
        /// <remarks>�q�ɃR�[�h</remarks>
        private string _warehouseCode = "";

        /// <summary>���z�\�����@�敪</summary>
        /// <remarks>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</remarks>
        private Int32 _totalAmountDispWayCd;

        /// <summary>�ېŋ敪[����]</summary>
        /// <remarks>0:�ې�,1:��ې�,2:�ېŁi���Łj</remarks>
        private Int32 _taxationDivCd;

        /// <summary>�����`�[�ԍ�</summary>
        /// <remarks>�d����`�[�ԍ��Ɏg�p����</remarks>
        private string _stockPartySaleSlipNum = "";

        /// <summary>�[�i��R�[�h</summary>
        private Int32 _addresseeCode;

        /// <summary>�[�i�於��</summary>
        private string _addresseeName = "";

        /// <summary>�[�i�於��2</summary>
        /// <remarks>�ǉ�(�o�^�R��) ����</remarks>
        private string _addresseeName2 = "";

        /// <summary>�ԑ�ԍ�</summary>
        private string _frameNo = "";

        /// <summary>�󒍎c��</summary>
        /// <remarks>�󒍐��ʁ{�󒍒������|�o�א�</remarks>
        private Double _acptAnOdrRemainCnt;

        /// <summary>���Е��ރR�[�h</summary>
        private Int32 _enterpriseGanreCode;

        /// <summary>�萔�������z</summary>
        private Int64 _feeDeposit;

        /// <summary>�l�������z</summary>
        private Int64 _discountDeposit;

        /// <summary>���͓�</summary>
        /// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
        private DateTime _inputDay;

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

        /// <summary>���i�啪�ޖ���</summary>
        private string _goodsLGroupName = "";

        /// <summary>���i�����ޖ���</summary>
        private string _goodsMGroupName = "";

        /// <summary>�ԗ��Ǘ��ԍ�</summary>
        /// <remarks>�����̔ԁi���d���̃V�[�P���X�jPM7�ł̎ԗ�SEQ</remarks>
        private Int32 _carMngNo;

        /// <summary>���[�J�[�R�[�h</summary>
        private Int32 _makerCode;

        /// <summary>�Ԏ�R�[�h</summary>
        private Int32 _modelCode;

        /// <summary>�Ԏ�T�u�R�[�h</summary>
        private Int32 _modelSubCode;

        /// <summary>�G���W���^������</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private string _engineModelNm = "";

        /// <summary>�J���[�R�[�h</summary>
        /// <remarks>�J�^���O�̐F�R�[�h</remarks>
        private string _colorCode = "";

        /// <summary>�g�����R�[�h</summary>
        private string _trimCode = "";

        /// <summary>�[�i�敪</summary>
        private Int32 _deliveredGoodsDiv;

        /// <summary>�t���^���Œ�ԍ��z��</summary>
        private Int32[] _fullModelFixedNoAry = new Int32[0];

        /// <summary>�����I�u�W�F�N�g�z��</summary>
        private Byte[] _categoryObjAry = new Byte[0];

        /// <summary>������͎҃R�[�h</summary>
        /// <remarks>���͒S���ҁi���s�ҁj</remarks>
        private string _salesInputCode = "";

        /// <summary>��t�]�ƈ��R�[�h</summary>
        /// <remarks>��t�S���ҁi�󒍎ҁj</remarks>
        private string _frontEmployeeCd = "";

        /// <summary>�����敪</summary>
        private Int32 _historyDiv;

        /// <summary>�ԗ����s����</summary>
        private Int32 _mileage;   // ADD 2009/09/07

        /// <summary>���q���l</summary>
        private string _carNote = "";   // ADD 2009/09/07

        // ---ADD 2009/09/07 ------>>>>>
        /// public propaty name  :  Mileage
        /// <summary>�ԗ����s�����v���p�e�B</summary>
        /// <value>�ԗ����s����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Mileage
        {
            get { return _mileage; }
            set { _mileage = value; }
        }

        /// public propaty name  :  CarNote
        /// <summary>���q���l�v���p�e�B</summary>
        /// <value>���q���l</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CarNote
        {
            get { return _carNote; }
            set { _carNote = value; }
        }
        // ---ADD 2009/09/07 -----<<<<<

        /// public propaty name  :  DataDiv
        /// <summary>�f�[�^�敪�v���p�e�B</summary>
        /// <value>0:����f�[�^ 1:�����f�[�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DataDiv
        {
            get { return _dataDiv; }
            set { _dataDiv = value; }
        }

        /// public propaty name  :  SalesDate
        /// <summary>������t�v���p�e�B</summary>
        /// <value>������t(YYYYMMDD)/�������t</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>����`�[�ԍ��v���p�e�B</summary>
        /// <value>����`�[�ԍ�/�����`�[�ԍ�</value>
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

        /// public propaty name  :  SalesRowNo
        /// <summary>����s�ԍ��v���p�e�B</summary>
        /// <value>����s�ԍ�/�����s�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����s�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesRowNo
        {
            get { return _salesRowNo; }
            set { _salesRowNo = value; }
        }

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
        /// <value>10:����,20:��,30:����,40:�o��</value>
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

        /// public propaty name  :  SalesSlipCd
        /// <summary>����`�[�敪�v���p�e�B</summary>
        /// <value>0:����,1:�ԕi</value>
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

        /// public propaty name  :  SalesEmployeeNm
        /// <summary>�̔��]�ƈ����̃v���p�e�B</summary>
        /// <value>�̔��]�ƈ�����/�����S���Җ���</value>
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

        /// public propaty name  :  SalesTotalTaxExc
        /// <summary>����`�[���v�i�Ŕ����j�v���p�e�B</summary>
        /// <value>����`�[���v�i�Ŕ����j/�����̏ꍇ(�������z+�l��+�萔��)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���v�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTotalTaxExc
        {
            get { return _salesTotalTaxExc; }
            set { _salesTotalTaxExc = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>���i���̃v���p�e�B</summary>
        /// <value>���i����/���햼��</value>
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

        /// public propaty name  :  ShipmentCnt
        /// <summary>�o�א��v���p�e�B</summary>
        /// <value>�o�א�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�א��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentCnt
        {
            get { return _shipmentCnt; }
            set { _shipmentCnt = value; }
        }

        /// public propaty name  :  ListPriceTaxExcFl
        /// <summary>�艿�i�Ŕ��C�����j�v���p�e�B</summary>
        /// <value>�艿�i�Ŕ����A�����j�܂���"�I�[�v�����i"</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�i�Ŕ��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ListPriceTaxExcFl
        {
            get { return _listPriceTaxExcFl; }
            set { _listPriceTaxExcFl = value; }
        }

        /// public propaty name  :  OpenPriceDiv
        /// <summary>�I�[�v�����i�敪�v���p�e�B</summary>
        /// <value>0:�ʏ�^1:�I�[�v�����i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�[�v�����i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OpenPriceDiv
        {
            get { return _openPriceDiv; }
            set { _openPriceDiv = value; }
        }

        /// public propaty name  :  SalesUnPrcTaxExcFl
        /// <summary>����P���i�Ŕ��C�����j�v���p�e�B</summary>
        /// <value>����P���i�Ŕ��C�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����P���i�Ŕ��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesUnPrcTaxExcFl
        {
            get { return _salesUnPrcTaxExcFl; }
            set { _salesUnPrcTaxExcFl = value; }
        }

        /// public propaty name  :  SalesUnitCost
        /// <summary>�����P���v���p�e�B</summary>
        /// <value>�����P��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����P���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesUnitCost
        {
            get { return _salesUnitCost; }
            set { _salesUnitCost = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc
        /// <summary>������z�i�Ŕ����j�v���p�e�B</summary>
        /// <value>������z�i�Ŕ����j/�������z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc
        {
            get { return _salesMoneyTaxExc; }
            set { _salesMoneyTaxExc = value; }
        }

        /// public propaty name  :  ConsTaxLayMethod
        /// <summary>����œ]�ŕ����v���p�e�B</summary>
        /// <value>0:�`�[�P��1:���גP��2:�����e 3:�����q 9:��ې�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����œ]�ŕ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ConsTaxLayMethod
        {
            get { return _consTaxLayMethod; }
            set { _consTaxLayMethod = value; }
        }

        /// public propaty name  :  SalesTotalTaxInc
        /// <summary>����`�[���v�i�ō��݁j�v���p�e�B</summary>
        /// <value>����f�[�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���v�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTotalTaxInc
        {
            get { return _salesTotalTaxInc; }
            set { _salesTotalTaxInc = value; }
        }

        /// public propaty name  :  SalesPriceConsTax
        /// <summary>������z����Ŋz�v���p�e�B</summary>
        /// <value>���㖾�׃f�[�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z����Ŋz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesPriceConsTax
        {
            get { return _salesPriceConsTax; }
            set { _salesPriceConsTax = value; }
        }

        /// public propaty name  :  TotalCost
        /// <summary>�������z�v�v���p�e�B</summary>
        /// <value>����f�[�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalCost
        {
            get { return _totalCost; }
            set { _totalCost = value; }
        }

        /// public propaty name  :  ModelDesignationNo
        /// <summary>�^���w��ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���w��ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ModelDesignationNo
        {
            get { return _modelDesignationNo; }
            set { _modelDesignationNo = value; }
        }

        /// public propaty name  :  CategoryNo
        /// <summary>�ޕʔԍ��v���p�e�B</summary>
        /// <value>�ޕʔԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ޕʔԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CategoryNo
        {
            get { return _categoryNo; }
            set { _categoryNo = value; }
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

        /// public propaty name  :  FirstEntryDate
        /// <summary>���N�x�v���p�e�B</summary>
        /// <value>���N�x(YYYYMM)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���N�x�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime FirstEntryDate
        {
            get { return _firstEntryDate; }
            set { _firstEntryDate = value; }
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

        /// public propaty name  :  SlipNote
        /// <summary>�`�[���l�v���p�e�B</summary>
        /// <value>�`�[���l/�`�[�E�v</value>
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

        /// public propaty name  :  FrontEmployeeNm
        /// <summary>��t�]�ƈ����̃v���p�e�B</summary>
        /// <value>��t�]�ƈ�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��t�]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FrontEmployeeNm
        {
            get { return _frontEmployeeNm; }
            set { _frontEmployeeNm = value; }
        }

        /// public propaty name  :  SalesInputName
        /// <summary>������͎Җ��̃v���p�e�B</summary>
        /// <value>������͎Җ���/�������͎Җ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������͎Җ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesInputName
        {
            get { return _salesInputName; }
            set { _salesInputName = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// <value>���Ӑ�R�[�h/���Ӑ�R�[�h</value>
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

        /// public propaty name  :  CustomerSnm
        /// <summary>���Ӑ旪�̃v���p�e�B</summary>
        /// <value>���Ӑ旪��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
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

        /// public propaty name  :  SupplierSnm
        /// <summary>�d���旪�̃v���p�e�B</summary>
        /// <value>�d���旪��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }

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

        /// public propaty name  :  AcceptAnOrderNo
        /// <summary>�󒍔ԍ��v���p�e�B</summary>
        /// <value>�v�㌳�󒍔ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcceptAnOrderNo
        {
            get { return _acceptAnOrderNo; }
            set { _acceptAnOrderNo = value; }
        }

        /// public propaty name  :  ShipmSalesSlipNum
        /// <summary>�v�㌳�o�ׇ��v���p�e�B</summary>
        /// <value>�v�㌳�o�הԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�㌳�o�ׇ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ShipmSalesSlipNum
        {
            get { return _shipmSalesSlipNum; }
            set { _shipmSalesSlipNum = value; }
        }

        /// public propaty name  :  SrcSalesSlipNum
        /// <summary>������(���ו\��)�v���p�e�B</summary>
        /// <value>�����`�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������(���ו\��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SrcSalesSlipNum
        {
            get { return _srcSalesSlipNum; }
            set { _srcSalesSlipNum = value; }
        }

        /// public propaty name  :  SalesOrderDivCd
        /// <summary>����݌Ɏ�񂹋敪�v���p�e�B</summary>
        /// <value>����݌Ɏ�񂹋敪(0:��񂹁C1:�݌�)</value>
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

        /// public propaty name  :  WarehouseName
        /// <summary>�q�ɖ��̃v���p�e�B</summary>
        /// <value>�q�ɖ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
        }

        /// public propaty name  :  SupplierSlipNo
        /// <summary>�d���`�[�ԍ��v���p�e�B</summary>
        /// <value>�����d���`�[�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierSlipNo
        {
            get { return _supplierSlipNo; }
            set { _supplierSlipNo = value; }
        }

        /// public propaty name  :  UOESupplierCd
        /// <summary>UOE������R�[�h�v���p�e�B</summary>
        /// <value>�t�n�d�����f�[�^</value>
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

        /// public propaty name  :  UOESupplierSnm
        /// <summary>�����於(���ו\��)�v���p�e�B</summary>
        /// <value>�t�n�d�����f�[�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����於(���ו\��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOESupplierSnm
        {
            get { return _uOESupplierSnm; }
            set { _uOESupplierSnm = value; }
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

        /// public propaty name  :  GuideName
        /// <summary>�K�C�h���̃v���p�e�B</summary>
        /// <value>�K�C�h����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GuideName
        {
            get { return _guideName; }
            set { _guideName = value; }
        }

        /// public propaty name  :  SectionGuideNm
        /// <summary>���_�K�C�h���̃v���p�e�B</summary>
        /// <value>���_�K�C�h����/�v�㋒�_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }

        /// public propaty name  :  DtlNote
        /// <summary>���ה��l�v���p�e�B</summary>
        /// <value>���ה��l/</value>
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

        /// public propaty name  :  StdUnPrcLPrice
        /// <summary>��P���i�艿�j�v���p�e�B</summary>
        /// <value>��P���i�艿�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��P���i�艿�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StdUnPrcLPrice
        {
            get { return _stdUnPrcLPrice; }
            set { _stdUnPrcLPrice = value; }
        }

        /// public propaty name  :  StdUnPrcSalUnPrc
        /// <summary>��P���i����P���j�v���p�e�B</summary>
        /// <value>��P���i����P���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��P���i����P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StdUnPrcSalUnPrc
        {
            get { return _stdUnPrcSalUnPrc; }
            set { _stdUnPrcSalUnPrc = value; }
        }

        /// public propaty name  :  StdUnPrcUnCst
        /// <summary>��P���i�����P���j�v���p�e�B</summary>
        /// <value>��P���i�����P���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��P���i�����P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StdUnPrcUnCst
        {
            get { return _stdUnPrcUnCst; }
            set { _stdUnPrcUnCst = value; }
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

        /// public propaty name  :  MakerName
        /// <summary>���[�J�[���̃v���p�e�B</summary>
        /// <value>���[�J�[����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MakerName
        {
            get { return _makerName; }
            set { _makerName = value; }
        }

        /// public propaty name  :  Cost
        /// <summary>�����v���p�e�B</summary>
        /// <value>���㖾�׃f�[�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        /// public propaty name  :  CustSlipNo
        /// <summary>���Ӑ�`�[�ԍ��v���p�e�B</summary>
        /// <value>���Ӑ�`�[�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustSlipNo
        {
            get { return _custSlipNo; }
            set { _custSlipNo = value; }
        }

        /// public propaty name  :  AddUpADate
        /// <summary>�v����t�v���p�e�B</summary>
        /// <value>�v����t(YYYYMMDD)/�v����t(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AddUpADate
        {
            get { return _addUpADate; }
            set { _addUpADate = value; }
        }

        /// public propaty name  :  AccRecDivCd
        /// <summary>���|�敪�v���p�e�B</summary>
        /// <value>���|�敪(0:���|�Ȃ�,1:���|)</value>
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

        /// public propaty name  :  DebitNoteDiv
        /// <summary>�ԓ`�敪�v���p�e�B</summary>
        /// <value>�ԓ`�敪(0:���`,1:�ԓ`,2:����)/�����ԍ��敪(0:��,1:��,2:���E�ςݍ�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԓ`�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DebitNoteDiv
        {
            get { return _debitNoteDiv; }
            set { _debitNoteDiv = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>���_�R�[�h</value>
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

        /// public propaty name  :  TotalAmountDispWayCd
        /// <summary>���z�\�����@�敪�v���p�e�B</summary>
        /// <value>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���z�\�����@�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalAmountDispWayCd
        {
            get { return _totalAmountDispWayCd; }
            set { _totalAmountDispWayCd = value; }
        }

        /// public propaty name  :  TaxationDivCd
        /// <summary>�ېŋ敪[����]�v���p�e�B</summary>
        /// <value>0:�ې�,1:��ې�,2:�ېŁi���Łj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ېŋ敪[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TaxationDivCd
        {
            get { return _taxationDivCd; }
            set { _taxationDivCd = value; }
        }

        /// public propaty name  :  StockPartySaleSlipNum
        /// <summary>�����`�[�ԍ��v���p�e�B</summary>
        /// <value>�d����`�[�ԍ��Ɏg�p����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockPartySaleSlipNum
        {
            get { return _stockPartySaleSlipNum; }
            set { _stockPartySaleSlipNum = value; }
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

        /// public propaty name  :  AddresseeName
        /// <summary>�[�i�於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseeName
        {
            get { return _addresseeName; }
            set { _addresseeName = value; }
        }

        /// public propaty name  :  AddresseeName2
        /// <summary>�[�i�於��2�v���p�e�B</summary>
        /// <value>�ǉ�(�o�^�R��) ����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�於��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseeName2
        {
            get { return _addresseeName2; }
            set { _addresseeName2 = value; }
        }

        /// public propaty name  :  FrameNo
        /// <summary>�ԑ�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԑ�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FrameNo
        {
            get { return _frameNo; }
            set { _frameNo = value; }
        }

        /// public propaty name  :  AcptAnOdrRemainCnt
        /// <summary>�󒍎c���v���p�e�B</summary>
        /// <value>�󒍐��ʁ{�󒍒������|�o�א�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍎c���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AcptAnOdrRemainCnt
        {
            get { return _acptAnOdrRemainCnt; }
            set { _acptAnOdrRemainCnt = value; }
        }

        /// public propaty name  :  EnterpriseGanreCode
        /// <summary>���Е��ރR�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  FeeDeposit
        /// <summary>�萔�������z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �萔�������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 FeeDeposit
        {
            get { return _feeDeposit; }
            set { _feeDeposit = value; }
        }

        /// public propaty name  :  DiscountDeposit
        /// <summary>�l�������z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l�������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DiscountDeposit
        {
            get { return _discountDeposit; }
            set { _discountDeposit = value; }
        }

        /// public propaty name  :  InputDay
        /// <summary>���͓��v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime InputDay
        {
            get { return _inputDay; }
            set { _inputDay = value; }
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

        /// public propaty name  :  GoodsLGroupName
        /// <summary>���i�啪�ޖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�啪�ޖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsLGroupName
        {
            get { return _goodsLGroupName; }
            set { _goodsLGroupName = value; }
        }

        /// public propaty name  :  GoodsMGroupName
        /// <summary>���i�����ޖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ޖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsMGroupName
        {
            get { return _goodsMGroupName; }
            set { _goodsMGroupName = value; }
        }

        /// public propaty name  :  CarMngNo
        /// <summary>�ԗ��Ǘ��ԍ��v���p�e�B</summary>
        /// <value>�����̔ԁi���d���̃V�[�P���X�jPM7�ł̎ԗ�SEQ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԗ��Ǘ��ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CarMngNo
        {
            get { return _carMngNo; }
            set { _carMngNo = value; }
        }

        /// public propaty name  :  MakerCode
        /// <summary>���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MakerCode
        {
            get { return _makerCode; }
            set { _makerCode = value; }
        }

        /// public propaty name  :  ModelCode
        /// <summary>�Ԏ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ModelCode
        {
            get { return _modelCode; }
            set { _modelCode = value; }
        }

        /// public propaty name  :  ModelSubCode
        /// <summary>�Ԏ�T�u�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ�T�u�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ModelSubCode
        {
            get { return _modelSubCode; }
            set { _modelSubCode = value; }
        }

        /// public propaty name  :  EngineModelNm
        /// <summary>�G���W���^�����̃v���p�e�B</summary>
        /// <value>�^���ɂ��ϓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �G���W���^�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EngineModelNm
        {
            get { return _engineModelNm; }
            set { _engineModelNm = value; }
        }

        /// public propaty name  :  ColorCode
        /// <summary>�J���[�R�[�h�v���p�e�B</summary>
        /// <value>�J�^���O�̐F�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J���[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ColorCode
        {
            get { return _colorCode; }
            set { _colorCode = value; }
        }

        /// public propaty name  :  TrimCode
        /// <summary>�g�����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �g�����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TrimCode
        {
            get { return _trimCode; }
            set { _trimCode = value; }
        }

        /// public propaty name  :  DeliveredGoodsDiv
        /// <summary>�[�i�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DeliveredGoodsDiv
        {
            get { return _deliveredGoodsDiv; }
            set { _deliveredGoodsDiv = value; }
        }

        /// public propaty name  :  FullModelFixedNoAry
        /// <summary>�t���^���Œ�ԍ��z��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t���^���Œ�ԍ��z��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32[] FullModelFixedNoAry
        {
            get { return _fullModelFixedNoAry; }
            set { _fullModelFixedNoAry = value; }
        }

        /// public propaty name  :  CategoryObjAry
        /// <summary>�����I�u�W�F�N�g�z��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����I�u�W�F�N�g�z��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Byte[] CategoryObjAry
        {
            get { return _categoryObjAry; }
            set { _categoryObjAry = value; }
        }

        /// public propaty name  :  SalesInputCode
        /// <summary>������͎҃R�[�h�v���p�e�B</summary>
        /// <value>���͒S���ҁi���s�ҁj</value>
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
        /// <value>��t�S���ҁi�󒍎ҁj</value>
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

        /// public propaty name  :  HistoryDiv
        /// <summary>�����敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HistoryDiv
        {
            get { return _historyDiv; }
            set { _historyDiv = value; }
        }


        /// <summary>
        /// ���Ӑ�d�q�������o����(�`�[�E����)�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>CustPrtPprSalTblRsltWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustPrtPprSalTblRsltWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustPrtPprSalTblRsltWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>CustPrtPprSalTblRsltWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   CustPrtPprSalTblRsltWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class CustPrtPprSalTblRsltWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
    #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustPrtPprSalTblRsltWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize( System.IO.BinaryWriter writer, object graph )
        {
            // TODO:  CustPrtPprSalTblRsltWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if ( writer == null )
                throw new ArgumentNullException();

            if ( graph != null && !(graph is CustPrtPprSalTblRsltWork || graph is ArrayList || graph is CustPrtPprSalTblRsltWork[]) )
                throw new ArgumentException( string.Format( "graph��{0}�̃C���X�^���X�ł���܂���", typeof( CustPrtPprSalTblRsltWork ).FullName ) );

            if ( graph != null && graph is CustPrtPprSalTblRsltWork )
            {
                Type t = graph.GetType();
                if ( !CustomFormatterServices.NeedCustomSerialization( t ) )
                    throw new ArgumentException( string.Format( "graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName ) );
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CustPrtPprSalTblRsltWork" );

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if ( graph is ArrayList )
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if ( graph is CustPrtPprSalTblRsltWork[] )
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CustPrtPprSalTblRsltWork[])graph).Length;
            }
            else if ( graph is CustPrtPprSalTblRsltWork )
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�f�[�^�敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DataDiv
            //������t
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SalesDate
            //����`�[�ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //SalesSlipNum
            //����s�ԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SalesRowNo
            //�󒍃X�e�[�^�X
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //AcptAnOdrStatus
            //����`�[�敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SalesSlipCd
            //�̔��]�ƈ�����
            serInfo.MemberInfo.Add( typeof( string ) ); //SalesEmployeeNm
            //����`�[���v�i�Ŕ����j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SalesTotalTaxExc
            //���i����
            serInfo.MemberInfo.Add( typeof( string ) ); //GoodsName
            //���i�ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //GoodsNo
            //BL���i�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //BLGoodsCode
            //BL�O���[�v�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //BLGroupCode
            //�o�א�
            serInfo.MemberInfo.Add( typeof( Double ) ); //ShipmentCnt
            //�艿�i�Ŕ��C�����j
            serInfo.MemberInfo.Add( typeof( Double ) ); //ListPriceTaxExcFl
            //�I�[�v�����i�敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //OpenPriceDiv
            //����P���i�Ŕ��C�����j
            serInfo.MemberInfo.Add( typeof( Double ) ); //SalesUnPrcTaxExcFl
            //�����P��
            serInfo.MemberInfo.Add( typeof( Double ) ); //SalesUnitCost
            //������z�i�Ŕ����j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SalesMoneyTaxExc
            //����œ]�ŕ���
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ConsTaxLayMethod
            //����`�[���v�i�ō��݁j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SalesTotalTaxInc
            //������z����Ŋz
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SalesPriceConsTax
            //�������z�v
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //TotalCost
            //�^���w��ԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ModelDesignationNo
            //�ޕʔԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CategoryNo
            //�Ԏ�S�p����
            serInfo.MemberInfo.Add( typeof( string ) ); //ModelFullName
            //���N�x
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //FirstEntryDate
            //�ԑ䇂
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SearchFrameNo
            //�^���i�t���^�j
            serInfo.MemberInfo.Add( typeof( string ) ); //FullModel
            //�`�[���l
            serInfo.MemberInfo.Add( typeof( string ) ); //SlipNote
            //�`�[���l�Q
            serInfo.MemberInfo.Add( typeof( string ) ); //SlipNote2
            //�`�[���l�R
            serInfo.MemberInfo.Add( typeof( string ) ); //SlipNote3
            //��t�]�ƈ�����
            serInfo.MemberInfo.Add( typeof( string ) ); //FrontEmployeeNm
            //������͎Җ���
            serInfo.MemberInfo.Add( typeof( string ) ); //SalesInputName
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CustomerCode
            //���Ӑ旪��
            serInfo.MemberInfo.Add( typeof( string ) ); //CustomerSnm
            //�d����R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SupplierCd
            //�d���旪��
            serInfo.MemberInfo.Add( typeof( string ) ); //SupplierSnm
            //�����`�[�ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //PartySaleSlipNum
            //�ԗ��Ǘ��R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //CarMngCode
            //�󒍔ԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //AcceptAnOrderNo
            //�v�㌳�o�ׇ�
            serInfo.MemberInfo.Add( typeof( string ) ); //ShipmSalesSlipNum
            //������(���ו\��)
            serInfo.MemberInfo.Add( typeof( string ) ); //SrcSalesSlipNum
            //����݌Ɏ�񂹋敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SalesOrderDivCd
            //�q�ɖ���
            serInfo.MemberInfo.Add( typeof( string ) ); //WarehouseName
            //�d���`�[�ԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SupplierSlipNo
            //UOE������R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //UOESupplierCd
            //�����於(���ו\��)
            serInfo.MemberInfo.Add( typeof( string ) ); //UOESupplierSnm
            //�t�n�d���}�[�N�P
            serInfo.MemberInfo.Add( typeof( string ) ); //UoeRemark1
            //�t�n�d���}�[�N�Q
            serInfo.MemberInfo.Add( typeof( string ) ); //UoeRemark2
            //�K�C�h����
            serInfo.MemberInfo.Add( typeof( string ) ); //GuideName
            //���_�K�C�h����
            serInfo.MemberInfo.Add( typeof( string ) ); //SectionGuideNm
            //���ה��l
            serInfo.MemberInfo.Add( typeof( string ) ); //DtlNote
            //�J���[����1
            serInfo.MemberInfo.Add( typeof( string ) ); //ColorName1
            //�g��������
            serInfo.MemberInfo.Add( typeof( string ) ); //TrimName
            //��P���i�艿�j
            serInfo.MemberInfo.Add( typeof( Double ) ); //StdUnPrcLPrice
            //��P���i����P���j
            serInfo.MemberInfo.Add( typeof( Double ) ); //StdUnPrcSalUnPrc
            //��P���i�����P���j
            serInfo.MemberInfo.Add( typeof( Double ) ); //StdUnPrcUnCst
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //GoodsMakerCd
            //���[�J�[����
            serInfo.MemberInfo.Add( typeof( string ) ); //MakerName
            //����
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //Cost
            //���Ӑ�`�[�ԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CustSlipNo
            //�v����t
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //AddUpADate
            //���|�敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //AccRecDivCd
            //�ԓ`�敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DebitNoteDiv
            //���_�R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //SectionCode
            //�q�ɃR�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //WarehouseCode
            //���z�\�����@�敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //TotalAmountDispWayCd
            //�ېŋ敪[����]
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //TaxationDivCd
            //�����`�[�ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //StockPartySaleSlipNum
            //�[�i��R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //AddresseeCode
            //�[�i�於��
            serInfo.MemberInfo.Add( typeof( string ) ); //AddresseeName
            //�[�i�於��2
            serInfo.MemberInfo.Add( typeof( string ) ); //AddresseeName2
            //�ԑ�ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //FrameNo
            //�󒍎c��
            serInfo.MemberInfo.Add( typeof( Double ) ); //AcptAnOdrRemainCnt
            //���Е��ރR�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //EnterpriseGanreCode
            //�萔�������z
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //FeeDeposit
            //�l�������z
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DiscountDeposit
            //���͓�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //InputDay
            //���i����
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //GoodsKindCode
            //���i�啪�ރR�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //GoodsLGroup
            //���i�����ރR�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //GoodsMGroup
            //�q�ɒI��
            serInfo.MemberInfo.Add( typeof( string ) ); //WarehouseShelfNo
            //����`�[�敪�i���ׁj
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SalesSlipCdDtl
            //���i�啪�ޖ���
            serInfo.MemberInfo.Add( typeof( string ) ); //GoodsLGroupName
            //���i�����ޖ���
            serInfo.MemberInfo.Add( typeof( string ) ); //GoodsMGroupName
            //�ԗ��Ǘ��ԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CarMngNo
            //���[�J�[�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MakerCode
            //�Ԏ�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ModelCode
            //�Ԏ�T�u�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ModelSubCode
            //�G���W���^������
            serInfo.MemberInfo.Add( typeof( string ) ); //EngineModelNm
            //�J���[�R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //ColorCode
            //�g�����R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //TrimCode
            //�[�i�敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DeliveredGoodsDiv
            //�t���^���Œ�ԍ��z��
            serInfo.MemberInfo.Add( typeof( Byte[] ) ); //FullModelFixedNoAry
            //�����I�u�W�F�N�g�z��
            serInfo.MemberInfo.Add( typeof( Byte[] ) ); //CategoryObjAry
            //������͎҃R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //SalesInputCode
            //��t�]�ƈ��R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //FrontEmployeeCd
            //�����敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HistoryDiv
            //�ԗ����s����   // ADD 2009/09/07
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //Mileage
            //���q���l   // ADD 2009/09/07
            serInfo.MemberInfo.Add( typeof( string ) ); //CarNote

            serInfo.Serialize( writer, serInfo );
            if ( graph is CustPrtPprSalTblRsltWork )
            {
                CustPrtPprSalTblRsltWork temp = (CustPrtPprSalTblRsltWork)graph;

                SetCustPrtPprSalTblRsltWork( writer, temp );
            }
            else
            {
                ArrayList lst = null;
                if ( graph is CustPrtPprSalTblRsltWork[] )
                {
                    lst = new ArrayList();
                    lst.AddRange( (CustPrtPprSalTblRsltWork[])graph );
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach ( CustPrtPprSalTblRsltWork temp in lst )
                {
                    SetCustPrtPprSalTblRsltWork( writer, temp );
                }

            }


        }


        /// <summary>
        /// CustPrtPprSalTblRsltWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 100;

        /// <summary>
        ///  CustPrtPprSalTblRsltWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustPrtPprSalTblRsltWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetCustPrtPprSalTblRsltWork( System.IO.BinaryWriter writer, CustPrtPprSalTblRsltWork temp )
        {
            //�f�[�^�敪
            writer.Write( temp.DataDiv );
            //������t
            writer.Write( (Int64)temp.SalesDate.Ticks );
            //����`�[�ԍ�
            writer.Write( temp.SalesSlipNum );
            //����s�ԍ�
            writer.Write( temp.SalesRowNo );
            //�󒍃X�e�[�^�X
            writer.Write( temp.AcptAnOdrStatus );
            //����`�[�敪
            writer.Write( temp.SalesSlipCd );
            //�̔��]�ƈ�����
            writer.Write( temp.SalesEmployeeNm );
            //����`�[���v�i�Ŕ����j
            writer.Write( temp.SalesTotalTaxExc );
            //���i����
            writer.Write( temp.GoodsName );
            //���i�ԍ�
            writer.Write( temp.GoodsNo );
            //BL���i�R�[�h
            writer.Write( temp.BLGoodsCode );
            //BL�O���[�v�R�[�h
            writer.Write( temp.BLGroupCode );
            //�o�א�
            writer.Write( temp.ShipmentCnt );
            //�艿�i�Ŕ��C�����j
            writer.Write( temp.ListPriceTaxExcFl );
            //�I�[�v�����i�敪
            writer.Write( temp.OpenPriceDiv );
            //����P���i�Ŕ��C�����j
            writer.Write( temp.SalesUnPrcTaxExcFl );
            //�����P��
            writer.Write( temp.SalesUnitCost );
            //������z�i�Ŕ����j
            writer.Write( temp.SalesMoneyTaxExc );
            //����œ]�ŕ���
            writer.Write( temp.ConsTaxLayMethod );
            //����`�[���v�i�ō��݁j
            writer.Write( temp.SalesTotalTaxInc );
            //������z����Ŋz
            writer.Write( temp.SalesPriceConsTax );
            //�������z�v
            writer.Write( temp.TotalCost );
            //�^���w��ԍ�
            writer.Write( temp.ModelDesignationNo );
            //�ޕʔԍ�
            writer.Write( temp.CategoryNo );
            //�Ԏ�S�p����
            writer.Write( temp.ModelFullName );
            //���N�x
            writer.Write( (Int64)temp.FirstEntryDate.Ticks );
            //�ԑ䇂
            writer.Write( temp.SearchFrameNo );
            //�^���i�t���^�j
            writer.Write( temp.FullModel );
            //�`�[���l
            writer.Write( temp.SlipNote );
            //�`�[���l�Q
            writer.Write( temp.SlipNote2 );
            //�`�[���l�R
            writer.Write( temp.SlipNote3 );
            //��t�]�ƈ�����
            writer.Write( temp.FrontEmployeeNm );
            //������͎Җ���
            writer.Write( temp.SalesInputName );
            //���Ӑ�R�[�h
            writer.Write( temp.CustomerCode );
            //���Ӑ旪��
            writer.Write( temp.CustomerSnm );
            //�d����R�[�h
            writer.Write( temp.SupplierCd );
            //�d���旪��
            writer.Write( temp.SupplierSnm );
            //�����`�[�ԍ�
            writer.Write( temp.PartySaleSlipNum );
            //�ԗ��Ǘ��R�[�h
            writer.Write( temp.CarMngCode );
            //�󒍔ԍ�
            writer.Write( temp.AcceptAnOrderNo );
            //�v�㌳�o�ׇ�
            writer.Write( temp.ShipmSalesSlipNum );
            //������(���ו\��)
            writer.Write( temp.SrcSalesSlipNum );
            //����݌Ɏ�񂹋敪
            writer.Write( temp.SalesOrderDivCd );
            //�q�ɖ���
            writer.Write( temp.WarehouseName );
            //�d���`�[�ԍ�
            writer.Write( temp.SupplierSlipNo );
            //UOE������R�[�h
            writer.Write( temp.UOESupplierCd );
            //�����於(���ו\��)
            writer.Write( temp.UOESupplierSnm );
            //�t�n�d���}�[�N�P
            writer.Write( temp.UoeRemark1 );
            //�t�n�d���}�[�N�Q
            writer.Write( temp.UoeRemark2 );
            //�K�C�h����
            writer.Write( temp.GuideName );
            //���_�K�C�h����
            writer.Write( temp.SectionGuideNm );
            //���ה��l
            writer.Write( temp.DtlNote );
            //�J���[����1
            writer.Write( temp.ColorName1 );
            //�g��������
            writer.Write( temp.TrimName );
            //��P���i�艿�j
            writer.Write( temp.StdUnPrcLPrice );
            //��P���i����P���j
            writer.Write( temp.StdUnPrcSalUnPrc );
            //��P���i�����P���j
            writer.Write( temp.StdUnPrcUnCst );
            //���i���[�J�[�R�[�h
            writer.Write( temp.GoodsMakerCd );
            //���[�J�[����
            writer.Write( temp.MakerName );
            //����
            writer.Write( temp.Cost );
            //���Ӑ�`�[�ԍ�
            writer.Write( temp.CustSlipNo );
            //�v����t
            writer.Write( (Int64)temp.AddUpADate.Ticks );
            //���|�敪
            writer.Write( temp.AccRecDivCd );
            //�ԓ`�敪
            writer.Write( temp.DebitNoteDiv );
            //���_�R�[�h
            writer.Write( temp.SectionCode );
            //�q�ɃR�[�h
            writer.Write( temp.WarehouseCode );
            //���z�\�����@�敪
            writer.Write( temp.TotalAmountDispWayCd );
            //�ېŋ敪[����]
            writer.Write( temp.TaxationDivCd );
            //�����`�[�ԍ�
            writer.Write( temp.StockPartySaleSlipNum );
            //�[�i��R�[�h
            writer.Write( temp.AddresseeCode );
            //�[�i�於��
            writer.Write( temp.AddresseeName );
            //�[�i�於��2
            writer.Write( temp.AddresseeName2 );
            //�ԑ�ԍ�
            writer.Write( temp.FrameNo );
            //�󒍎c��
            writer.Write( temp.AcptAnOdrRemainCnt );
            //���Е��ރR�[�h
            writer.Write( temp.EnterpriseGanreCode );
            //�萔�������z
            writer.Write( temp.FeeDeposit );
            //�l�������z
            writer.Write( temp.DiscountDeposit );
            //���͓�
            writer.Write( (Int64)temp.InputDay.Ticks );
            //���i����
            writer.Write( temp.GoodsKindCode );
            //���i�啪�ރR�[�h
            writer.Write( temp.GoodsLGroup );
            //���i�����ރR�[�h
            writer.Write( temp.GoodsMGroup );
            //�q�ɒI��
            writer.Write( temp.WarehouseShelfNo );
            //����`�[�敪�i���ׁj
            writer.Write( temp.SalesSlipCdDtl );
            //���i�啪�ޖ���
            writer.Write( temp.GoodsLGroupName );
            //���i�����ޖ���
            writer.Write( temp.GoodsMGroupName );
            //�ԗ��Ǘ��ԍ�
            writer.Write( temp.CarMngNo );
            //���[�J�[�R�[�h
            writer.Write( temp.MakerCode );
            //�Ԏ�R�[�h
            writer.Write( temp.ModelCode );
            //�Ԏ�T�u�R�[�h
            writer.Write( temp.ModelSubCode );
            //�G���W���^������
            writer.Write( temp.EngineModelNm );
            //�J���[�R�[�h
            writer.Write( temp.ColorCode );
            //�g�����R�[�h
            writer.Write( temp.TrimCode );
            //�[�i�敪
            writer.Write( temp.DeliveredGoodsDiv );
            //�t���^���Œ�ԍ��z��
            if ( temp.FullModelFixedNoAry == null ) temp.FullModelFixedNoAry = new int[0];
            int length = temp.FullModelFixedNoAry.Length;
            writer.Write( length );
            for ( int cnt = 0; cnt < length; cnt++ )
                writer.Write( temp.FullModelFixedNoAry[cnt] );
            //�����I�u�W�F�N�g�z��
            if ( temp.CategoryObjAry == null ) temp.CategoryObjAry = new byte[0];
            writer.Write( temp.CategoryObjAry.Length );
            writer.Write( temp.CategoryObjAry );
            //������͎҃R�[�h
            writer.Write( temp.SalesInputCode );
            //��t�]�ƈ��R�[�h
            writer.Write( temp.FrontEmployeeCd );
            //�����敪
            writer.Write( temp.HistoryDiv );
            //�ԗ����s�����@// ADD 2009/09/07
            writer.Write( temp.Mileage );
            //���q���l   // ADD 2009/09/07
            writer.Write( temp.CarNote );


        }

        /// <summary>
        ///  CustPrtPprSalTblRsltWork�C���X�^���X�擾
        /// </summary>
        /// <returns>CustPrtPprSalTblRsltWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustPrtPprSalTblRsltWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private CustPrtPprSalTblRsltWork GetCustPrtPprSalTblRsltWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
	{
		// V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
		// serInfo.MemberInfo.Count < currentMemberCount
		// �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

		CustPrtPprSalTblRsltWork temp = new CustPrtPprSalTblRsltWork();

		//�f�[�^�敪
		temp.DataDiv = reader.ReadInt32();
		//������t
		temp.SalesDate = new DateTime(reader.ReadInt64());
		//����`�[�ԍ�
		temp.SalesSlipNum = reader.ReadString();
		//����s�ԍ�
		temp.SalesRowNo = reader.ReadInt32();
		//�󒍃X�e�[�^�X
		temp.AcptAnOdrStatus = reader.ReadInt32();
		//����`�[�敪
		temp.SalesSlipCd = reader.ReadInt32();
		//�̔��]�ƈ�����
		temp.SalesEmployeeNm = reader.ReadString();
		//����`�[���v�i�Ŕ����j
		temp.SalesTotalTaxExc = reader.ReadInt64();
		//���i����
		temp.GoodsName = reader.ReadString();
		//���i�ԍ�
		temp.GoodsNo = reader.ReadString();
		//BL���i�R�[�h
		temp.BLGoodsCode = reader.ReadInt32();
		//BL�O���[�v�R�[�h
		temp.BLGroupCode = reader.ReadInt32();
		//�o�א�
		temp.ShipmentCnt = reader.ReadDouble();
		//�艿�i�Ŕ��C�����j
		temp.ListPriceTaxExcFl = reader.ReadDouble();
		//�I�[�v�����i�敪
		temp.OpenPriceDiv = reader.ReadInt32();
		//����P���i�Ŕ��C�����j
		temp.SalesUnPrcTaxExcFl = reader.ReadDouble();
		//�����P��
		temp.SalesUnitCost = reader.ReadDouble();
		//������z�i�Ŕ����j
		temp.SalesMoneyTaxExc = reader.ReadInt64();
		//����œ]�ŕ���
		temp.ConsTaxLayMethod = reader.ReadInt32();
		//����`�[���v�i�ō��݁j
		temp.SalesTotalTaxInc = reader.ReadInt64();
		//������z����Ŋz
		temp.SalesPriceConsTax = reader.ReadInt64();
		//�������z�v
		temp.TotalCost = reader.ReadInt64();
		//�^���w��ԍ�
		temp.ModelDesignationNo = reader.ReadInt32();
		//�ޕʔԍ�
		temp.CategoryNo = reader.ReadInt32();
		//�Ԏ�S�p����
		temp.ModelFullName = reader.ReadString();
		//���N�x
		temp.FirstEntryDate = new DateTime(reader.ReadInt64());
		//�ԑ䇂
		temp.SearchFrameNo = reader.ReadInt32();
		//�^���i�t���^�j
		temp.FullModel = reader.ReadString();
		//�`�[���l
		temp.SlipNote = reader.ReadString();
		//�`�[���l�Q
		temp.SlipNote2 = reader.ReadString();
		//�`�[���l�R
		temp.SlipNote3 = reader.ReadString();
		//��t�]�ƈ�����
		temp.FrontEmployeeNm = reader.ReadString();
		//������͎Җ���
		temp.SalesInputName = reader.ReadString();
		//���Ӑ�R�[�h
		temp.CustomerCode = reader.ReadInt32();
		//���Ӑ旪��
		temp.CustomerSnm = reader.ReadString();
		//�d����R�[�h
		temp.SupplierCd = reader.ReadInt32();
		//�d���旪��
		temp.SupplierSnm = reader.ReadString();
		//�����`�[�ԍ�
		temp.PartySaleSlipNum = reader.ReadString();
		//�ԗ��Ǘ��R�[�h
		temp.CarMngCode = reader.ReadString();
		//�󒍔ԍ�
		temp.AcceptAnOrderNo = reader.ReadInt32();
		//�v�㌳�o�ׇ�
		temp.ShipmSalesSlipNum = reader.ReadString();
		//������(���ו\��)
		temp.SrcSalesSlipNum = reader.ReadString();
		//����݌Ɏ�񂹋敪
		temp.SalesOrderDivCd = reader.ReadInt32();
		//�q�ɖ���
		temp.WarehouseName = reader.ReadString();
		//�d���`�[�ԍ�
		temp.SupplierSlipNo = reader.ReadInt32();
		//UOE������R�[�h
		temp.UOESupplierCd = reader.ReadInt32();
		//�����於(���ו\��)
		temp.UOESupplierSnm = reader.ReadString();
		//�t�n�d���}�[�N�P
		temp.UoeRemark1 = reader.ReadString();
		//�t�n�d���}�[�N�Q
		temp.UoeRemark2 = reader.ReadString();
		//�K�C�h����
		temp.GuideName = reader.ReadString();
		//���_�K�C�h����
		temp.SectionGuideNm = reader.ReadString();
		//���ה��l
		temp.DtlNote = reader.ReadString();
		//�J���[����1
		temp.ColorName1 = reader.ReadString();
		//�g��������
		temp.TrimName = reader.ReadString();
		//��P���i�艿�j
		temp.StdUnPrcLPrice = reader.ReadDouble();
		//��P���i����P���j
		temp.StdUnPrcSalUnPrc = reader.ReadDouble();
		//��P���i�����P���j
		temp.StdUnPrcUnCst = reader.ReadDouble();
		//���i���[�J�[�R�[�h
		temp.GoodsMakerCd = reader.ReadInt32();
		//���[�J�[����
		temp.MakerName = reader.ReadString();
		//����
		temp.Cost = reader.ReadInt64();
		//���Ӑ�`�[�ԍ�
		temp.CustSlipNo = reader.ReadInt32();
		//�v����t
		temp.AddUpADate = new DateTime(reader.ReadInt64());
		//���|�敪
		temp.AccRecDivCd = reader.ReadInt32();
		//�ԓ`�敪
		temp.DebitNoteDiv = reader.ReadInt32();
		//���_�R�[�h
		temp.SectionCode = reader.ReadString();
		//�q�ɃR�[�h
		temp.WarehouseCode = reader.ReadString();
		//���z�\�����@�敪
		temp.TotalAmountDispWayCd = reader.ReadInt32();
		//�ېŋ敪[����]
		temp.TaxationDivCd = reader.ReadInt32();
		//�����`�[�ԍ�
		temp.StockPartySaleSlipNum = reader.ReadString();
		//�[�i��R�[�h
		temp.AddresseeCode = reader.ReadInt32();
		//�[�i�於��
		temp.AddresseeName = reader.ReadString();
		//�[�i�於��2
		temp.AddresseeName2 = reader.ReadString();
		//�ԑ�ԍ�
		temp.FrameNo = reader.ReadString();
		//�󒍎c��
		temp.AcptAnOdrRemainCnt = reader.ReadDouble();
		//���Е��ރR�[�h
		temp.EnterpriseGanreCode = reader.ReadInt32();
		//�萔�������z
		temp.FeeDeposit = reader.ReadInt64();
		//�l�������z
		temp.DiscountDeposit = reader.ReadInt64();
		//���͓�
		temp.InputDay = new DateTime(reader.ReadInt64());
		//���i����
		temp.GoodsKindCode = reader.ReadInt32();
		//���i�啪�ރR�[�h
		temp.GoodsLGroup = reader.ReadInt32();
		//���i�����ރR�[�h
		temp.GoodsMGroup = reader.ReadInt32();
		//�q�ɒI��
		temp.WarehouseShelfNo = reader.ReadString();
		//����`�[�敪�i���ׁj
		temp.SalesSlipCdDtl = reader.ReadInt32();
		//���i�啪�ޖ���
		temp.GoodsLGroupName = reader.ReadString();
		//���i�����ޖ���
		temp.GoodsMGroupName = reader.ReadString();
		//�ԗ��Ǘ��ԍ�
		temp.CarMngNo = reader.ReadInt32();
		//���[�J�[�R�[�h
		temp.MakerCode = reader.ReadInt32();
		//�Ԏ�R�[�h
		temp.ModelCode = reader.ReadInt32();
		//�Ԏ�T�u�R�[�h
		temp.ModelSubCode = reader.ReadInt32();
		//�G���W���^������
		temp.EngineModelNm = reader.ReadString();
		//�J���[�R�[�h
		temp.ColorCode = reader.ReadString();
		//�g�����R�[�h
		temp.TrimCode = reader.ReadString();
		//�[�i�敪
		temp.DeliveredGoodsDiv = reader.ReadInt32();
        //�t���^���Œ�ԍ��z��
        int length = reader.ReadInt32();
        temp.FullModelFixedNoAry = new int[length];
        for ( int cnt = 0; cnt < length; cnt++ )
            temp.FullModelFixedNoAry[cnt] = reader.ReadInt32();
        //�����I�u�W�F�N�g�z��
        length = reader.ReadInt32();
        temp.CategoryObjAry = reader.ReadBytes( length );
        //������͎҃R�[�h
		temp.SalesInputCode = reader.ReadString();
		//��t�]�ƈ��R�[�h
		temp.FrontEmployeeCd = reader.ReadString();
		//�����敪
		temp.HistoryDiv = reader.ReadInt32();
        //�ԗ����s����   // ADD 2009/09/07
        temp.Mileage = reader.ReadInt32();
        //���q���l   // ADD 2009/09/07
        temp.CarNote = reader.ReadString();

			
		//�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
		//�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
		//�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
		//�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
		for( int k = currentMemberCount ; k < serInfo.MemberInfo.Count ; ++k )
		{
			//byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
			//�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
			//�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
			//�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
			int optCount = 0;   
			object oMemberType = serInfo.MemberInfo[k];
			if( oMemberType is Type )
			{
				Type t = (Type)oMemberType;
				object oData = TypeDeserializer.DeserializePrimitiveType( reader, t, optCount );
				if( t.Equals( typeof(int) ) )
				{
					optCount = Convert.ToInt32(oData);
				}
				else
				{
					optCount = 0;
				}
			}
			else if( oMemberType is string )
			{
				Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate( (string)oMemberType );
				object userData = formatter.Deserialize( reader );  //�ǂݔ�΂�
			}
		}
		return temp;
	}

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
        /// </summary>
        /// <returns>CustPrtPprSalTblRsltWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustPrtPprSalTblRsltWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize( System.IO.BinaryReader reader )
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
            ArrayList lst = new ArrayList();
            for ( int cnt = 0; cnt < serInfo.Occurrence; ++cnt )
            {
                CustPrtPprSalTblRsltWork temp = GetCustPrtPprSalTblRsltWork( reader, serInfo );
                lst.Add( temp );
            }
            switch ( serInfo.RetTypeInfo )
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (CustPrtPprSalTblRsltWork[])lst.ToArray( typeof( CustPrtPprSalTblRsltWork ) );
                    break;
            }
            return retValue;
        }

        #endregion
    }

    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
# endif

    /// public class name:   CustPrtPprSalTblRsltWork
    /// <summary>
    ///                      ���Ӑ�d�q�������o����(�`�[�E����)�N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���Ӑ�d�q�������o����(�`�[�E����)�N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/10/23  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2010/01/12 ������</br>
    /// <br>                     �N�̂ݓ��͂����N���̓`�[�𔄏�`�[���͂Ő���Ɍ��o�\�t�ł���悤�ɕύX����B</br>
    /// <br>Update Note      :   2010/01/29 �k���r 4������</br>
    /// <br>                     �ԓ`���s���ɁA�ԕi���̏���𐧌����\�ƂȂ�悤�ɁA�ԕi�s�ݒ�@�\�̒ǉ����s���B</br>
    /// <br></br>
    /// <br>Update Note      :   2010/04/02 22018 ��� ���b �yMANTIS:0015241�z���o�\�t�̏C��</br>
    /// <br></br>
    /// <br>Update Note      :   2010/04/15 30517 �Ė� �x�� �yMANTIS:0015323�z�`�[�敪�ɓ������܂܂��ƃG���[�ƂȂ錏�̏C��</br>
    /// <br>Update Note      :   2010/04/27 gaoyh �󒍃}�X�^�i�ԗ��j�Ɏ��R�����^���Œ�ԍ��z��̒ǉ�</br>
    /// <br>Update Note      :   2010/08/05 ������ �ύX�O�艿�̒ǉ�</br>
    /// <br>Update Note      :   2010/12/20 �k���r �v�㌳�󒍇��E�v�㌳�ݏo���̕\�����e�C��</br>
    /// <br>Update Note      :   2011/07/18 zhubj �񓚋敪�ǉ��Ή�</br>
    /// <br>Update Note      :   2011/11/28 �k�m redmine#8172�̒ǉ��Ή�</br>
    /// <br>Update Note      :   2014/12/28 �i�N �ϊ���i�Ԃ̒ǉ��Ή�</br>
    /// <br>Update Note      :   K2015/06/16 鸏�</br>
    /// <br>�Ǘ��ԍ�         :   11101427-00</br>
    /// <br>                 :   ���C�S�����Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����B</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CustPrtPprSalTblRsltWork
    {
        /// <summary>�f�[�^�敪</summary>
        /// <remarks>0:����f�[�^ 1:�����f�[�^</remarks>
        private Int32 _dataDiv;

        /// <summary>������t</summary>
        /// <remarks>������t(YYYYMMDD)/�������t</remarks>
        private DateTime _salesDate;

        /// <summary>����`�[�ԍ�</summary>
        /// <remarks>����`�[�ԍ�/�����`�[�ԍ�</remarks>
        private string _salesSlipNum = "";

        /// <summary>����s�ԍ�</summary>
        /// <remarks>����s�ԍ�/�����s�ԍ�</remarks>
        private Int32 _salesRowNo;

        /// <summary>�󒍃X�e�[�^�X</summary>
        /// <remarks>10:����,20:��,30:����,40:�o��</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>����`�[�敪</summary>
        /// <remarks>0:����,1:�ԕi</remarks>
        private Int32 _salesSlipCd;

        /// <summary>�̔��]�ƈ�����</summary>
        /// <remarks>�̔��]�ƈ�����/�����S���Җ���</remarks>
        private string _salesEmployeeNm = "";

        /// <summary>����`�[���v�i�Ŕ����j</summary>
        /// <remarks>����`�[���v�i�Ŕ����j/�����̏ꍇ(�������z+�l��+�萔��)</remarks>
        private Int64 _salesTotalTaxExc;

        /// <summary>���i����</summary>
        /// <remarks>���i����/���햼��</remarks>
        private string _goodsName = "";

        /// <summary>���i�ԍ�</summary>
        /// <remarks>���i�ԍ�</remarks>
        private string _goodsNo = "";

        // --- ADD �i�N 2014/12/28 �ϊ���i�Ԃ̒ǉ��Ή�----->>>>>
        /// <summary>�ϊ���i��</summary>
        /// <remarks>�ϊ���i��</remarks>
        private string _changeGoodsNo = "";
        // --- ADD �i�N 2014/12/28 �ϊ���i�Ԃ̒ǉ��Ή�-----<<<<<

        /// <summary>BL���i�R�[�h</summary>
        /// <remarks>BL���i�R�[�h</remarks>
        private Int32 _bLGoodsCode;

        /// <summary>BL�O���[�v�R�[�h</summary>
        /// <remarks>BL�O���[�v�R�[�h</remarks>
        private Int32 _bLGroupCode;

        /// <summary>�o�א�</summary>
        /// <remarks>�o�א�</remarks>
        private Double _shipmentCnt;

        /// <summary>�艿�i�Ŕ��C�����j</summary>
        /// <remarks>�艿�i�Ŕ����A�����j�܂���"�I�[�v�����i"</remarks>
        private Double _listPriceTaxExcFl;

        // ----------- ADD �A��729 2011/08/18 -------------------->>>>>
        /// <summary>������</summary>
        /// <remarks>������</remarks>
        private Double _costRate;

        /// <summary>������</summary>
        /// <remarks>������</remarks>
        private Double _salesRate;
        // ----------- ADD �A��729 2011/08/18 --------------------<<<<<

        // ADD ���V�� 2020/03/11 PMKOBETSU-2912 -------->>>>>
        /// <summary>����Őŗ�</summary>
        /// <remarks>����Őŗ�</remarks>
        private Double _consTaxRate;
        // ADD ���V�� 2020/03/11 PMKOBETSU-2912 --------<<<<<

        /// <summary>�I�[�v�����i�敪</summary>
        /// <remarks>0:�ʏ�^1:�I�[�v�����i</remarks>
        private Int32 _openPriceDiv;

        /// <summary>����P���i�Ŕ��C�����j</summary>
        /// <remarks>����P���i�Ŕ��C�����j</remarks>
        private Double _salesUnPrcTaxExcFl;

        /// <summary>�����P��</summary>
        /// <remarks>�����P��</remarks>
        private Double _salesUnitCost;

        /// <summary>������z�i�Ŕ����j</summary>
        /// <remarks>������z�i�Ŕ����j/�������z</remarks>
        private Int64 _salesMoneyTaxExc;

        /// <summary>����œ]�ŕ���</summary>
        /// <remarks>0:�`�[�P��1:���גP��2:�����e 3:�����q 9:��ې�</remarks>
        private Int32 _consTaxLayMethod;

        /// <summary>����`�[���v�i�ō��݁j</summary>
        /// <remarks>����f�[�^</remarks>
        private Int64 _salesTotalTaxInc;

        /// <summary>������z����Ŋz</summary>
        /// <remarks>���㖾�׃f�[�^</remarks>
        private Int64 _salesPriceConsTax;

        /// <summary>�������z�v</summary>
        /// <remarks>����f�[�^</remarks>
        private Int64 _totalCost;

        /// <summary>�^���w��ԍ�</summary>
        private Int32 _modelDesignationNo;

        /// <summary>�ޕʔԍ�</summary>
        /// <remarks>�ޕʔԍ�</remarks>
        private Int32 _categoryNo;

        /// <summary>�Ԏ�S�p����</summary>
        /// <remarks>�Ԏ�S�p����</remarks>
        private string _modelFullName = "";

        /// <summary>���N�x</summary>
        /// <remarks>���N�x(YYYYMM)</remarks>
        //private DateTime _firstEntryDate;// DEL 20010/01/12
        private Int32 _firstEntryDate;// ADD 20010/01/12

        /// <summary>�ԑ䇂</summary>
        /// <remarks>�ԑ�ԍ��i�����p�j</remarks>
        private Int32 _searchFrameNo;

        /// <summary>�^���i�t���^�j</summary>
        /// <remarks>�^���i�t���^�j</remarks>
        private string _fullModel = "";

        /// <summary>�`�[���l</summary>
        /// <remarks>�`�[���l/�`�[�E�v</remarks>
        private string _slipNote = "";

        /// <summary>�`�[���l�Q</summary>
        /// <remarks>�`�[���l�Q</remarks>
        private string _slipNote2 = "";

        /// <summary>�`�[���l�R</summary>
        /// <remarks>�`�[���l�R</remarks>
        private string _slipNote3 = "";

        /// <summary>��t�]�ƈ�����</summary>
        /// <remarks>��t�]�ƈ�����</remarks>
        private string _frontEmployeeNm = "";

        /// <summary>������͎Җ���</summary>
        /// <remarks>������͎Җ���/�������͎Җ���</remarks>
        private string _salesInputName = "";

        /// <summary>���Ӑ�R�[�h</summary>
        /// <remarks>���Ӑ�R�[�h/���Ӑ�R�[�h</remarks>
        private Int32 _customerCode;

        /// <summary>���Ӑ旪��</summary>
        /// <remarks>���Ӑ旪��</remarks>
        private string _customerSnm = "";

        /// <summary>�d����R�[�h</summary>
        /// <remarks>�d����R�[�h</remarks>
        private Int32 _supplierCd;

        /// <summary>�d���旪��</summary>
        /// <remarks>�d���旪��</remarks>
        private string _supplierSnm = "";

        /// <summary>�����`�[�ԍ�</summary>
        /// <remarks>�����`�[�ԍ�</remarks>
        private string _partySaleSlipNum = "";

        /// <summary>�ԗ��Ǘ��R�[�h</summary>
        /// <remarks>���q�Ǘ��R�[�h</remarks>
        private string _carMngCode = "";

        /// <summary>�󒍔ԍ�</summary>
        /// <remarks>�v�㌳�󒍔ԍ�</remarks>
        private Int32 _acceptAnOrderNo;

        /// <summary>�v�㌳�o�ׇ�</summary>
        /// <remarks>�v�㌳�o�הԍ�</remarks>
        private string _shipmSalesSlipNum = "";

        /// <summary>������(���ו\��)</summary>
        /// <remarks>�����`�ԍ�</remarks>
        private string _srcSalesSlipNum = "";

        /// <summary>����݌Ɏ�񂹋敪</summary>
        /// <remarks>����݌Ɏ�񂹋敪(0:��񂹁C1:�݌�)</remarks>
        private Int32 _salesOrderDivCd;

        /// <summary>�q�ɖ���</summary>
        /// <remarks>�q�ɖ���</remarks>
        private string _warehouseName = "";

        /// <summary>�d���`�[�ԍ�</summary>
        /// <remarks>�����d���`�[�ԍ�</remarks>
        private Int32 _supplierSlipNo;

        /// <summary>UOE������R�[�h</summary>
        /// <remarks>�t�n�d�����f�[�^</remarks>
        private Int32 _uOESupplierCd;

        /// <summary>�����於(���ו\��)</summary>
        /// <remarks>�t�n�d�����f�[�^</remarks>
        private string _uOESupplierSnm = "";

        /// <summary>�t�n�d���}�[�N�P</summary>
        /// <remarks>�t�n�d���}�[�N�P</remarks>
        private string _uoeRemark1 = "";

        /// <summary>�t�n�d���}�[�N�Q</summary>
        /// <remarks>�t�n�d���}�[�N�Q</remarks>
        private string _uoeRemark2 = "";

        /// <summary>�K�C�h����</summary>
        /// <remarks>�K�C�h����</remarks>
        private string _guideName = "";

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>���_�K�C�h����/�v�㋒�_�R�[�h</remarks>
        private string _sectionGuideNm = "";

        /// <summary>���ה��l</summary>
        /// <remarks>���ה��l/</remarks>
        private string _dtlNote = "";

        /// <summary>�J���[����1</summary>
        /// <remarks>�J���[����1</remarks>
        private string _colorName1 = "";

        /// <summary>�g��������</summary>
        /// <remarks>�g��������</remarks>
        private string _trimName = "";

        /// <summary>��P���i�艿�j</summary>
        /// <remarks>��P���i�艿�j</remarks>
        private Double _stdUnPrcLPrice;

        /// <summary>��P���i����P���j</summary>
        /// <remarks>��P���i����P���j</remarks>
        private Double _stdUnPrcSalUnPrc;

        /// <summary>��P���i�����P���j</summary>
        /// <remarks>��P���i�����P���j</remarks>
        private Double _stdUnPrcUnCst;

        // -------------ADD 2009/12/28-------------->>>>>
        /// <summary>�ύX�O�P��</summary>
        /// <remarks>�ύX�O�P��</remarks>
        private Double _bfSalesUnitPrice;

        /// <summary>�ύX�O����</summary>
        /// <remarks>�ύX�O����</remarks>
        private Double _bfUnitCost;
        // -------------ADD 2009/12/28--------------<<<<<

        // -------------ADD 2010/08/05-------------->>>>>
        /// <summary>�ύX�O�艿</summary>
        /// <remarks>�ύX�O�艿</remarks>
        private Double _bfListPrice;
        // -------------ADD 2010/08/05--------------<<<<<

        // ---------------------- ADD START 2011/07/18 zhubj ----------------->>>>>
        /// <summary>�����񓚋敪(SCM)</summary>
        /// <remarks>0:�ʏ�(PCC�A�g�Ȃ�)�A1:�蓮�񓚁A2:������</remarks>
        private Int32 _autoAnswerDivSCM;
        // ---------------------- ADD END   2011.02.09 zhubj -----------------<<<<<

        //---ADD START 2011/11/28 �k�m ----------------------------------->>>>>
        /// <summary>�⍇���ԍ�</summary>
        private Int64 _inquiryNumber;
        //---ADD END 2011/11/28 �k�m -----------------------------------<<<<<
        
        /// <summary>���i���[�J�[�R�[�h</summary>
        /// <remarks>���i���[�J�[�R�[�h</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>���[�J�[����</summary>
        /// <remarks>���[�J�[����</remarks>
        private string _makerName = "";

        /// <summary>����</summary>
        /// <remarks>���㖾�׃f�[�^</remarks>
        private Int64 _cost;

        /// <summary>���Ӑ�`�[�ԍ�</summary>
        /// <remarks>���Ӑ�`�[�ԍ�</remarks>
        private Int32 _custSlipNo;

        /// <summary>�v����t</summary>
        /// <remarks>�v����t(YYYYMMDD)/�v����t(YYYYMMDD)</remarks>
        private DateTime _addUpADate;

        /// <summary>���|�敪</summary>
        /// <remarks>���|�敪(0:���|�Ȃ�,1:���|)</remarks>
        private Int32 _accRecDivCd;

        /// <summary>�ԓ`�敪</summary>
        /// <remarks>�ԓ`�敪(0:���`,1:�ԓ`,2:����)/�����ԍ��敪(0:��,1:��,2:���E�ςݍ�)</remarks>
        private Int32 _debitNoteDiv;

        /// <summary>���_�R�[�h</summary>
        /// <remarks>���_�R�[�h</remarks>
        private string _sectionCode = "";

        /// <summary>�q�ɃR�[�h</summary>
        /// <remarks>�q�ɃR�[�h</remarks>
        private string _warehouseCode = "";

        /// <summary>���z�\�����@�敪</summary>
        /// <remarks>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</remarks>
        private Int32 _totalAmountDispWayCd;

        /// <summary>�ېŋ敪[����]</summary>
        /// <remarks>0:�ې�,1:��ې�,2:�ېŁi���Łj</remarks>
        private Int32 _taxationDivCd;

        /// <summary>�����`�[�ԍ�</summary>
        /// <remarks>�d����`�[�ԍ��Ɏg�p����</remarks>
        private string _stockPartySaleSlipNum = "";

        /// <summary>�[�i��R�[�h</summary>
        private Int32 _addresseeCode;

        /// <summary>�[�i�於��</summary>
        private string _addresseeName = "";

        /// <summary>�[�i�於��2</summary>
        /// <remarks>�ǉ�(�o�^�R��) ����</remarks>
        private string _addresseeName2 = "";

        /// <summary>�ԑ�ԍ�</summary>
        private string _frameNo = "";

        /// <summary>�󒍎c��</summary>
        /// <remarks>�󒍐��ʁ{�󒍒������|�o�א�</remarks>
        private Double _acptAnOdrRemainCnt;

        /// <summary>���Е��ރR�[�h</summary>
        private Int32 _enterpriseGanreCode;

        /// <summary>�萔�������z</summary>
        private Int64 _feeDeposit;

        /// <summary>�l�������z</summary>
        private Int64 _discountDeposit;

        /// <summary>���͓�</summary>
        /// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
        private DateTime _inputDay;

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

        /// <summary>���i�啪�ޖ���</summary>
        private string _goodsLGroupName = "";

        /// <summary>���i�����ޖ���</summary>
        private string _goodsMGroupName = "";

        /// <summary>�ԗ��Ǘ��ԍ�</summary>
        /// <remarks>�����̔ԁi���d���̃V�[�P���X�jPM7�ł̎ԗ�SEQ</remarks>
        private Int32 _carMngNo;

        /// <summary>���[�J�[�R�[�h</summary>
        private Int32 _makerCode;

        /// <summary>�Ԏ�R�[�h</summary>
        private Int32 _modelCode;

        /// <summary>�Ԏ�T�u�R�[�h</summary>
        private Int32 _modelSubCode;

        /// <summary>�G���W���^������</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private string _engineModelNm = "";

        /// <summary>�J���[�R�[�h</summary>
        /// <remarks>�J�^���O�̐F�R�[�h</remarks>
        private string _colorCode = "";

        /// <summary>�g�����R�[�h</summary>
        private string _trimCode = "";

        /// <summary>�[�i�敪</summary>
        private Int32 _deliveredGoodsDiv;

        /// <summary>�t���^���Œ�ԍ��z��</summary>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 UPD
        private Int32[] _fullModelFixedNoAry;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 UPD

        /// <summary>�����I�u�W�F�N�g�z��</summary>
        private Byte[] _categoryObjAry;

        /// <summary>������͎҃R�[�h</summary>
        /// <remarks>���͒S���ҁi���s�ҁj</remarks>
        private string _salesInputCode = "";

        /// <summary>��t�]�ƈ��R�[�h</summary>
        /// <remarks>��t�S���ҁi�󒍎ҁj</remarks>
        private string _frontEmployeeCd = "";

        /// <summary>�����敪</summary>
        private Int32 _historyDiv;

        /// <summary>�ԗ����s����</summary>
        private Int32 _mileage;

        /// <summary>���q���l</summary>
        private string _carNote = "";
        // -------------ADD 2010/01/29 ---------->>>>>
        /// <summary>�ԕi�����</summary>
        private Double _retuppercnt;

        /// <summary>�ԕi��������݃t���O</summary>
        private Int32 _retuppercntDiv;
        // -------------ADD 2010/01/29 ----------<<<<<
        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 UPD
        private Int64 _updateDateTime;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 UPD
        // ADD 2012/04/01 gezh Redmine#29250 --------->>>>>
        /// <summary>�X�V����(����)</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private Int64 _updateDateTimeDetail;
        // ADD 2012/04/01 gezh Redmine#29250 ---------<<<<<
        // --- ADD m.suzuki 2010/04/02 ---------->>>>>
        /// <summary>�Ԏ피�p����</summary>
        // 2010/04/15 >>>
        //private string _modelHalfName;
        private string _modelHalfName = "";
        // 2010/04/15 <<<
        // --- ADD m.suzuki 2010/04/02 ----------<<<<<

        // --- ADD 2010/04/27 ---------->>>>>
        /// <summary>���R�����^���Œ�ԍ��z��</summary>
        /// <remarks>���R�����V���A�����̔z��N���X���i�[�i�Č����s�v�ɂȂ�j</remarks>
        private Byte[] _freeSrchMdlFxdNoAry;
        // --- ADD 2010/04/27 ----------<<<<<

        // --- ADD 2010/12/20 ---------->>>>>
        /// <summary>����`�[�ԍ�</summary>
        private string _hisDtlSlipNum = "";

        /// <summary>�󒍃X�e�[�^�X�i���j</summary>
        private Int32 _acptAnOdrStatusSrc;
        // --- ADD 2010/12/20 ----------<<<<<

        //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����----->>>>>
        /// <summary>�̔��G���A�R�[�h</summary>
        private string _salesAreaName = "";

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
        public string SalesAreaName
        {
            get { return _salesAreaName; }
            set { _salesAreaName = value; }
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
             
        // ---------------------- ADD START 2011/07/18 zhubj ----------------->>>>>
        /// public propaty name  :  AutoAnswerDivSCM
        /// <summary>�����񓚋敪(SCM)�v���p�e�B</summary>
        /// <value>0:�ʏ�(PCC�A�g�Ȃ�)�A1:�蓮�񓚁A2:������</value>
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

        //---ADD START 2011/11/28 �k�m ----------------------------------->>>>>
        /// public propaty name  :  St_InquiryNumber
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

        /// public propaty name  :  DataDiv
        /// <summary>�f�[�^�敪�v���p�e�B</summary>
        /// <value>0:����f�[�^ 1:�����f�[�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DataDiv
        {
            get { return _dataDiv; }
            set { _dataDiv = value; }
        }

        /// public propaty name  :  SalesDate
        /// <summary>������t�v���p�e�B</summary>
        /// <value>������t(YYYYMMDD)/�������t</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>����`�[�ԍ��v���p�e�B</summary>
        /// <value>����`�[�ԍ�/�����`�[�ԍ�</value>
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

        /// public propaty name  :  SalesRowNo
        /// <summary>����s�ԍ��v���p�e�B</summary>
        /// <value>����s�ԍ�/�����s�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����s�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesRowNo
        {
            get { return _salesRowNo; }
            set { _salesRowNo = value; }
        }

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
        /// <value>10:����,20:��,30:����,40:�o��</value>
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

        /// public propaty name  :  SalesSlipCd
        /// <summary>����`�[�敪�v���p�e�B</summary>
        /// <value>0:����,1:�ԕi</value>
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

        /// public propaty name  :  SalesEmployeeNm
        /// <summary>�̔��]�ƈ����̃v���p�e�B</summary>
        /// <value>�̔��]�ƈ�����/�����S���Җ���</value>
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

        /// public propaty name  :  SalesTotalTaxExc
        /// <summary>����`�[���v�i�Ŕ����j�v���p�e�B</summary>
        /// <value>����`�[���v�i�Ŕ����j/�����̏ꍇ(�������z+�l��+�萔��)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���v�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTotalTaxExc
        {
            get { return _salesTotalTaxExc; }
            set { _salesTotalTaxExc = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>���i���̃v���p�e�B</summary>
        /// <value>���i����/���햼��</value>
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

        // --- ADD �i�N 2014/12/28 �ϊ���i�Ԃ̒ǉ��Ή�----->>>>>
        /// public propaty name  :  ChangeGoodsNo
        /// <summary>�ϊ���i�ԃv���p�e�B</summary>
        /// <value>�ϊ���i��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϊ���i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ChangeGoodsNo
        {
            get { return _changeGoodsNo; }
            set { _changeGoodsNo = value; }
        }
        // --- ADD �i�N 2014/12/28 �ϊ���i�Ԃ̒ǉ��Ή�-----<<<<<

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

        /// public propaty name  :  ShipmentCnt
        /// <summary>�o�א��v���p�e�B</summary>
        /// <value>�o�א�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�א��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentCnt
        {
            get { return _shipmentCnt; }
            set { _shipmentCnt = value; }
        }

        /// public propaty name  :  ListPriceTaxExcFl
        /// <summary>�艿�i�Ŕ��C�����j�v���p�e�B</summary>
        /// <value>�艿�i�Ŕ����A�����j�܂���"�I�[�v�����i"</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�i�Ŕ��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ListPriceTaxExcFl
        {
            get { return _listPriceTaxExcFl; }
            set { _listPriceTaxExcFl = value; }
        }

        // ----------- ADD �A��729 2011/08/18 -------------------->>>>>
        /// public propaty name  :  CostRate
        /// <summary>�������v���p�e�B</summary>
        /// <value>������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double CostRate
        {
            get { return _costRate; }
            set { _costRate = value; }
        }

        /// public propaty name  :  SalesRate
        /// <summary>�������v���p�e�B</summary>
        /// <value>������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesRate
        {
            get { return _salesRate; }
            set { _salesRate = value; }
        }
        // ----------- ADD �A��729 2011/08/18 --------------------<<<<<


        // ADD ���V�� 2020/03/11 PMKOBETSU-2912 -------->>>>>
        /// public propaty name  :  ConsTaxRate
        /// <summary>����Őŗ��v���p�e�B</summary>
        /// <value>����Őŗ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����Őŗ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ConsTaxRate
        {
            get { return _consTaxRate; }
            set { _consTaxRate = value; }
        }
        // ADD ���V�� 2020/03/11 PMKOBETSU-2912 --------<<<<<

        /// public propaty name  :  OpenPriceDiv
        /// <summary>�I�[�v�����i�敪�v���p�e�B</summary>
        /// <value>0:�ʏ�^1:�I�[�v�����i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�[�v�����i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OpenPriceDiv
        {
            get { return _openPriceDiv; }
            set { _openPriceDiv = value; }
        }

        /// public propaty name  :  SalesUnPrcTaxExcFl
        /// <summary>����P���i�Ŕ��C�����j�v���p�e�B</summary>
        /// <value>����P���i�Ŕ��C�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����P���i�Ŕ��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesUnPrcTaxExcFl
        {
            get { return _salesUnPrcTaxExcFl; }
            set { _salesUnPrcTaxExcFl = value; }
        }

        /// public propaty name  :  SalesUnitCost
        /// <summary>�����P���v���p�e�B</summary>
        /// <value>�����P��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����P���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesUnitCost
        {
            get { return _salesUnitCost; }
            set { _salesUnitCost = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc
        /// <summary>������z�i�Ŕ����j�v���p�e�B</summary>
        /// <value>������z�i�Ŕ����j/�������z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc
        {
            get { return _salesMoneyTaxExc; }
            set { _salesMoneyTaxExc = value; }
        }

        /// public propaty name  :  ConsTaxLayMethod
        /// <summary>����œ]�ŕ����v���p�e�B</summary>
        /// <value>0:�`�[�P��1:���גP��2:�����e 3:�����q 9:��ې�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����œ]�ŕ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ConsTaxLayMethod
        {
            get { return _consTaxLayMethod; }
            set { _consTaxLayMethod = value; }
        }

        /// public propaty name  :  SalesTotalTaxInc
        /// <summary>����`�[���v�i�ō��݁j�v���p�e�B</summary>
        /// <value>����f�[�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���v�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTotalTaxInc
        {
            get { return _salesTotalTaxInc; }
            set { _salesTotalTaxInc = value; }
        }

        /// public propaty name  :  SalesPriceConsTax
        /// <summary>������z����Ŋz�v���p�e�B</summary>
        /// <value>���㖾�׃f�[�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z����Ŋz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesPriceConsTax
        {
            get { return _salesPriceConsTax; }
            set { _salesPriceConsTax = value; }
        }

        /// public propaty name  :  TotalCost
        /// <summary>�������z�v�v���p�e�B</summary>
        /// <value>����f�[�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalCost
        {
            get { return _totalCost; }
            set { _totalCost = value; }
        }

        /// public propaty name  :  ModelDesignationNo
        /// <summary>�^���w��ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���w��ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ModelDesignationNo
        {
            get { return _modelDesignationNo; }
            set { _modelDesignationNo = value; }
        }

        /// public propaty name  :  CategoryNo
        /// <summary>�ޕʔԍ��v���p�e�B</summary>
        /// <value>�ޕʔԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ޕʔԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CategoryNo
        {
            get { return _categoryNo; }
            set { _categoryNo = value; }
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

        /// public propaty name  :  FirstEntryDate
        /// <summary>���N�x�v���p�e�B</summary>
        /// <value>���N�x(YYYYMM)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���N�x�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        //public DateTime FirstEntryDate // DEL 2010/01/12
        public Int32 FirstEntryDate // ADD 2010/01/12
        {
            get { return _firstEntryDate; }
            set { _firstEntryDate = value; }
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

        /// public propaty name  :  SlipNote
        /// <summary>�`�[���l�v���p�e�B</summary>
        /// <value>�`�[���l/�`�[�E�v</value>
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

        /// public propaty name  :  FrontEmployeeNm
        /// <summary>��t�]�ƈ����̃v���p�e�B</summary>
        /// <value>��t�]�ƈ�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��t�]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FrontEmployeeNm
        {
            get { return _frontEmployeeNm; }
            set { _frontEmployeeNm = value; }
        }

        /// public propaty name  :  SalesInputName
        /// <summary>������͎Җ��̃v���p�e�B</summary>
        /// <value>������͎Җ���/�������͎Җ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������͎Җ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesInputName
        {
            get { return _salesInputName; }
            set { _salesInputName = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// <value>���Ӑ�R�[�h/���Ӑ�R�[�h</value>
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

        /// public propaty name  :  CustomerSnm
        /// <summary>���Ӑ旪�̃v���p�e�B</summary>
        /// <value>���Ӑ旪��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
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

        /// public propaty name  :  SupplierSnm
        /// <summary>�d���旪�̃v���p�e�B</summary>
        /// <value>�d���旪��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }

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

        /// public propaty name  :  AcceptAnOrderNo
        /// <summary>�󒍔ԍ��v���p�e�B</summary>
        /// <value>�v�㌳�󒍔ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcceptAnOrderNo
        {
            get { return _acceptAnOrderNo; }
            set { _acceptAnOrderNo = value; }
        }

        /// public propaty name  :  ShipmSalesSlipNum
        /// <summary>�v�㌳�o�ׇ��v���p�e�B</summary>
        /// <value>�v�㌳�o�הԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�㌳�o�ׇ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ShipmSalesSlipNum
        {
            get { return _shipmSalesSlipNum; }
            set { _shipmSalesSlipNum = value; }
        }

        /// public propaty name  :  SrcSalesSlipNum
        /// <summary>������(���ו\��)�v���p�e�B</summary>
        /// <value>�����`�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������(���ו\��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SrcSalesSlipNum
        {
            get { return _srcSalesSlipNum; }
            set { _srcSalesSlipNum = value; }
        }

        /// public propaty name  :  SalesOrderDivCd
        /// <summary>����݌Ɏ�񂹋敪�v���p�e�B</summary>
        /// <value>����݌Ɏ�񂹋敪(0:��񂹁C1:�݌�)</value>
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

        /// public propaty name  :  WarehouseName
        /// <summary>�q�ɖ��̃v���p�e�B</summary>
        /// <value>�q�ɖ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
        }

        /// public propaty name  :  SupplierSlipNo
        /// <summary>�d���`�[�ԍ��v���p�e�B</summary>
        /// <value>�����d���`�[�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierSlipNo
        {
            get { return _supplierSlipNo; }
            set { _supplierSlipNo = value; }
        }

        /// public propaty name  :  UOESupplierCd
        /// <summary>UOE������R�[�h�v���p�e�B</summary>
        /// <value>�t�n�d�����f�[�^</value>
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

        /// public propaty name  :  UOESupplierSnm
        /// <summary>�����於(���ו\��)�v���p�e�B</summary>
        /// <value>�t�n�d�����f�[�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����於(���ו\��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOESupplierSnm
        {
            get { return _uOESupplierSnm; }
            set { _uOESupplierSnm = value; }
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

        /// public propaty name  :  GuideName
        /// <summary>�K�C�h���̃v���p�e�B</summary>
        /// <value>�K�C�h����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GuideName
        {
            get { return _guideName; }
            set { _guideName = value; }
        }

        /// public propaty name  :  SectionGuideNm
        /// <summary>���_�K�C�h���̃v���p�e�B</summary>
        /// <value>���_�K�C�h����/�v�㋒�_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }

        /// public propaty name  :  DtlNote
        /// <summary>���ה��l�v���p�e�B</summary>
        /// <value>���ה��l/</value>
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

        /// public propaty name  :  StdUnPrcLPrice
        /// <summary>��P���i�艿�j�v���p�e�B</summary>
        /// <value>��P���i�艿�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��P���i�艿�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StdUnPrcLPrice
        {
            get { return _stdUnPrcLPrice; }
            set { _stdUnPrcLPrice = value; }
        }

        /// public propaty name  :  StdUnPrcSalUnPrc
        /// <summary>��P���i����P���j�v���p�e�B</summary>
        /// <value>��P���i����P���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��P���i����P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StdUnPrcSalUnPrc
        {
            get { return _stdUnPrcSalUnPrc; }
            set { _stdUnPrcSalUnPrc = value; }
        }

        /// public propaty name  :  StdUnPrcUnCst
        /// <summary>��P���i�����P���j�v���p�e�B</summary>
        /// <value>��P���i�����P���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��P���i�����P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StdUnPrcUnCst
        {
            get { return _stdUnPrcUnCst; }
            set { _stdUnPrcUnCst = value; }
        }

        // -------------ADD 2009/12/28-------------->>>>>
        /// public propaty name  :  BfSalesUnitPrice
        /// <summary>�ύX�O�P���v���p�e�B</summary>
        /// <value>�ύX�O�P��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ύX�O�P���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double BfSalesUnitPrice
        {
            get { return _bfSalesUnitPrice; }
            set { _bfSalesUnitPrice = value; }
        }

        /// public propaty name  :  BfUnitCost
        /// <summary>�ύX�O�����v���p�e�B</summary>
        /// <value>�ύX�O����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ύX�O�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double BfUnitCost
        {
            get { return _bfUnitCost; }
            set { _bfUnitCost = value; }
        }
        // -------------ADD 2009/12/28--------------<<<<<

        // -------------ADD 2010/08/05-------------->>>>>
        /// public propaty name  :  BfListPrice
        /// <summary>�ύX�O�艿�v���p�e�B</summary>
        /// <value>�ύX�O�艿</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ύX�O�艿�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double BfListPrice
        {
            get { return _bfListPrice; }
            set { _bfListPrice = value; }
        }
        // -------------ADD 2010/08/05--------------<<<<<

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

        /// public propaty name  :  MakerName
        /// <summary>���[�J�[���̃v���p�e�B</summary>
        /// <value>���[�J�[����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MakerName
        {
            get { return _makerName; }
            set { _makerName = value; }
        }

        /// public propaty name  :  Cost
        /// <summary>�����v���p�e�B</summary>
        /// <value>���㖾�׃f�[�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        /// public propaty name  :  CustSlipNo
        /// <summary>���Ӑ�`�[�ԍ��v���p�e�B</summary>
        /// <value>���Ӑ�`�[�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustSlipNo
        {
            get { return _custSlipNo; }
            set { _custSlipNo = value; }
        }

        /// public propaty name  :  AddUpADate
        /// <summary>�v����t�v���p�e�B</summary>
        /// <value>�v����t(YYYYMMDD)/�v����t(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AddUpADate
        {
            get { return _addUpADate; }
            set { _addUpADate = value; }
        }

        /// public propaty name  :  AccRecDivCd
        /// <summary>���|�敪�v���p�e�B</summary>
        /// <value>���|�敪(0:���|�Ȃ�,1:���|)</value>
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

        /// public propaty name  :  DebitNoteDiv
        /// <summary>�ԓ`�敪�v���p�e�B</summary>
        /// <value>�ԓ`�敪(0:���`,1:�ԓ`,2:����)/�����ԍ��敪(0:��,1:��,2:���E�ςݍ�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԓ`�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DebitNoteDiv
        {
            get { return _debitNoteDiv; }
            set { _debitNoteDiv = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>���_�R�[�h</value>
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

        /// public propaty name  :  TotalAmountDispWayCd
        /// <summary>���z�\�����@�敪�v���p�e�B</summary>
        /// <value>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���z�\�����@�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalAmountDispWayCd
        {
            get { return _totalAmountDispWayCd; }
            set { _totalAmountDispWayCd = value; }
        }

        /// public propaty name  :  TaxationDivCd
        /// <summary>�ېŋ敪[����]�v���p�e�B</summary>
        /// <value>0:�ې�,1:��ې�,2:�ېŁi���Łj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ېŋ敪[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TaxationDivCd
        {
            get { return _taxationDivCd; }
            set { _taxationDivCd = value; }
        }

        /// public propaty name  :  StockPartySaleSlipNum
        /// <summary>�����`�[�ԍ��v���p�e�B</summary>
        /// <value>�d����`�[�ԍ��Ɏg�p����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockPartySaleSlipNum
        {
            get { return _stockPartySaleSlipNum; }
            set { _stockPartySaleSlipNum = value; }
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

        /// public propaty name  :  AddresseeName
        /// <summary>�[�i�於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseeName
        {
            get { return _addresseeName; }
            set { _addresseeName = value; }
        }

        /// public propaty name  :  AddresseeName2
        /// <summary>�[�i�於��2�v���p�e�B</summary>
        /// <value>�ǉ�(�o�^�R��) ����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�於��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseeName2
        {
            get { return _addresseeName2; }
            set { _addresseeName2 = value; }
        }

        /// public propaty name  :  FrameNo
        /// <summary>�ԑ�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԑ�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FrameNo
        {
            get { return _frameNo; }
            set { _frameNo = value; }
        }

        /// public propaty name  :  AcptAnOdrRemainCnt
        /// <summary>�󒍎c���v���p�e�B</summary>
        /// <value>�󒍐��ʁ{�󒍒������|�o�א�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍎c���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AcptAnOdrRemainCnt
        {
            get { return _acptAnOdrRemainCnt; }
            set { _acptAnOdrRemainCnt = value; }
        }

        /// public propaty name  :  EnterpriseGanreCode
        /// <summary>���Е��ރR�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  FeeDeposit
        /// <summary>�萔�������z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �萔�������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 FeeDeposit
        {
            get { return _feeDeposit; }
            set { _feeDeposit = value; }
        }

        /// public propaty name  :  DiscountDeposit
        /// <summary>�l�������z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l�������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DiscountDeposit
        {
            get { return _discountDeposit; }
            set { _discountDeposit = value; }
        }

        /// public propaty name  :  InputDay
        /// <summary>���͓��v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime InputDay
        {
            get { return _inputDay; }
            set { _inputDay = value; }
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

        /// public propaty name  :  GoodsLGroupName
        /// <summary>���i�啪�ޖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�啪�ޖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsLGroupName
        {
            get { return _goodsLGroupName; }
            set { _goodsLGroupName = value; }
        }

        /// public propaty name  :  GoodsMGroupName
        /// <summary>���i�����ޖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ޖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsMGroupName
        {
            get { return _goodsMGroupName; }
            set { _goodsMGroupName = value; }
        }

        /// public propaty name  :  CarMngNo
        /// <summary>�ԗ��Ǘ��ԍ��v���p�e�B</summary>
        /// <value>�����̔ԁi���d���̃V�[�P���X�jPM7�ł̎ԗ�SEQ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԗ��Ǘ��ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CarMngNo
        {
            get { return _carMngNo; }
            set { _carMngNo = value; }
        }

        /// public propaty name  :  MakerCode
        /// <summary>���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MakerCode
        {
            get { return _makerCode; }
            set { _makerCode = value; }
        }

        /// public propaty name  :  ModelCode
        /// <summary>�Ԏ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ModelCode
        {
            get { return _modelCode; }
            set { _modelCode = value; }
        }

        /// public propaty name  :  ModelSubCode
        /// <summary>�Ԏ�T�u�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ�T�u�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ModelSubCode
        {
            get { return _modelSubCode; }
            set { _modelSubCode = value; }
        }

        /// public propaty name  :  EngineModelNm
        /// <summary>�G���W���^�����̃v���p�e�B</summary>
        /// <value>�^���ɂ��ϓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �G���W���^�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EngineModelNm
        {
            get { return _engineModelNm; }
            set { _engineModelNm = value; }
        }

        /// public propaty name  :  ColorCode
        /// <summary>�J���[�R�[�h�v���p�e�B</summary>
        /// <value>�J�^���O�̐F�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J���[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ColorCode
        {
            get { return _colorCode; }
            set { _colorCode = value; }
        }

        /// public propaty name  :  TrimCode
        /// <summary>�g�����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �g�����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TrimCode
        {
            get { return _trimCode; }
            set { _trimCode = value; }
        }

        /// public propaty name  :  DeliveredGoodsDiv
        /// <summary>�[�i�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DeliveredGoodsDiv
        {
            get { return _deliveredGoodsDiv; }
            set { _deliveredGoodsDiv = value; }
        }

        /// public propaty name  :  FullModelFixedNoAry
        /// <summary>�t���^���Œ�ԍ��z��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t���^���Œ�ԍ��z��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 UPD
        public Int32[] FullModelFixedNoAry
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 UPD
        {
            get { return _fullModelFixedNoAry; }
            set { _fullModelFixedNoAry = value; }
        }

        /// public propaty name  :  CategoryObjAry
        /// <summary>�����I�u�W�F�N�g�z��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����I�u�W�F�N�g�z��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Byte[] CategoryObjAry
        {
            get { return _categoryObjAry; }
            set { _categoryObjAry = value; }
        }

        /// public propaty name  :  SalesInputCode
        /// <summary>������͎҃R�[�h�v���p�e�B</summary>
        /// <value>���͒S���ҁi���s�ҁj</value>
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
        /// <value>��t�S���ҁi�󒍎ҁj</value>
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

        /// public propaty name  :  HistoryDiv
        /// <summary>�����敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HistoryDiv
        {
            get { return _historyDiv; }
            set { _historyDiv = value; }
        }

        /// public propaty name  :  Mileage
        /// <summary>�ԗ����s�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԗ����s�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Mileage
        {
            get { return _mileage; }
            set { _mileage = value; }
        }

        /// public propaty name  :  CarNote
        /// <summary>���q���l�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���q���l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CarNote
        {
            get { return _carNote; }
            set { _carNote = value; }
        }
        // -------------ADD 2010/01/29 ---------->>>>>
        /// public propaty name  :  Retuppercnt
        /// <summary>�ԕi�����</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi�����</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double Retuppercnt
        {
            get { return _retuppercnt; }
            set { _retuppercnt = value; }
        }

        /// public propaty name  :  RetuppercntDiv
        /// <summary>�ԕi��������݃t���O</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi��������݃t���O</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RetuppercntDiv
        {
            get { return _retuppercntDiv; }
            set { _retuppercntDiv = value; }
        }
        // -------------ADD 2010/01/29 ----------<<<<<
        /// public propaty name  :  UpdateDateTime
        /// <summary>�X�V�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 UPD
        public Int64 UpdateDateTime
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 UPD
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }
        // ADD 2012/04/01 gezh Redmine#29250 --------->>>>>
        public Int64 UpdateDateTimeDetail
        {
            get { return _updateDateTimeDetail; }
            set { _updateDateTimeDetail = value; }
        }
        // ADD 2012/04/01 gezh Redmine#29250 ---------<<<<<
        // --- ADD m.suzuki 2010/04/02 ---------->>>>>
        /// public propaty name  :  ModelHalfName
        /// <summary>�Ԏ피�p���̃v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ피�p���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ModelHalfName
        {
            get { return _modelHalfName; }
            set { _modelHalfName = value; }
        }
        // --- ADD m.suzuki 2010/04/02 ----------<<<<<

        // --- ADD 2010/04/27 ---------->>>>>
        /// public propaty name  :  FreeSrchMdlFxdNoAry
        /// <summary>���R�����^���Œ�ԍ��z��v���p�e�B</summary>
        /// <value>���R�����V���A�����̔z��N���X���i�[�i�Č����s�v�ɂȂ�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���R�����^���Œ�ԍ��z��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Byte[] FreeSrchMdlFxdNoAry
        {
            get { return _freeSrchMdlFxdNoAry; }
            set { _freeSrchMdlFxdNoAry = value; }
        }
        // --- ADD 2010/04/27 ----------<<<<

        // --- ADD 2010/12/20 ---------->>>>>
        /// public propaty name  :  HisDtlSlipNum
        /// <summary>����`�[�ԍ�</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HisDtlSlipNum
        {
            get { return _hisDtlSlipNum; }
            set { _hisDtlSlipNum = value; }
        }

        /// public propaty name  :  AcptAnOdrStatusSrc
        /// <summary>>�󒍃X�e�[�^�X�i���j</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   >�󒍃X�e�[�^�X�i���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcptAnOdrStatusSrc
        {
            get { return _acptAnOdrStatusSrc; }
            set { _acptAnOdrStatusSrc = value; }
        }
        // --- ADD 2010/12/20 ----------<<<<<

        /// <summary>
        /// ���Ӑ�d�q�������o����(�`�[�E����)�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>CustPrtPprSalTblRsltWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustPrtPprSalTblRsltWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustPrtPprSalTblRsltWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>CustPrtPprSalTblRsltWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   CustPrtPprSalTblRsltWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// <br>Update Note      :   K2015/06/16 鸏�</br>
    /// <br>�Ǘ��ԍ�         :   11101427-00</br>
    /// <br>                 :   ���C�S�����Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����B</br>
    /// </remarks>
    public class CustPrtPprSalTblRsltWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustPrtPprSalTblRsltWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2011/11/28 �k�m redmine#8172�̒ǉ��Ή�</br>
        /// <br>Update Note      :   K2015/06/16 鸏�</br>
        /// <br>�Ǘ��ԍ�         :   11101427-00</br>
        /// <br>                 :   ���C�S�����Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����B</br>
        /// </remarks>
        public void Serialize( System.IO.BinaryWriter writer, object graph )
        {
            // TODO:  CustPrtPprSalTblRsltWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if ( writer == null )
                throw new ArgumentNullException();

            if ( graph != null && !(graph is CustPrtPprSalTblRsltWork || graph is ArrayList || graph is CustPrtPprSalTblRsltWork[]) )
                throw new ArgumentException( string.Format( "graph��{0}�̃C���X�^���X�ł���܂���", typeof( CustPrtPprSalTblRsltWork ).FullName ) );

            if ( graph != null && graph is CustPrtPprSalTblRsltWork )
            {
                Type t = graph.GetType();
                if ( !CustomFormatterServices.NeedCustomSerialization( t ) )
                    throw new ArgumentException( string.Format( "graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName ) );
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CustPrtPprSalTblRsltWork" );

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if ( graph is ArrayList )
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if ( graph is CustPrtPprSalTblRsltWork[] )
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CustPrtPprSalTblRsltWork[])graph).Length;
            }
            else if ( graph is CustPrtPprSalTblRsltWork )
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�f�[�^�敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DataDiv
            //������t
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SalesDate
            //����`�[�ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //SalesSlipNum
            //����s�ԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SalesRowNo
            //�󒍃X�e�[�^�X
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //AcptAnOdrStatus
            //����`�[�敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SalesSlipCd
            //�̔��]�ƈ�����
            serInfo.MemberInfo.Add( typeof( string ) ); //SalesEmployeeNm
            //����`�[���v�i�Ŕ����j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SalesTotalTaxExc
            //���i����
            serInfo.MemberInfo.Add( typeof( string ) ); //GoodsName
            //���i�ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //GoodsNo
            // --- ADD �i�N 2014/12/28 �ϊ���i�Ԃ̒ǉ��Ή�----->>>>>
            //�ϊ���i��
            serInfo.MemberInfo.Add(typeof(string)); //ChangeGoodsNo
            // --- ADD �i�N 2014/12/28 �ϊ���i�Ԃ̒ǉ��Ή�-----<<<<<
            //BL���i�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //BLGoodsCode
            //BL�O���[�v�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //BLGroupCode
            //�o�א�
            serInfo.MemberInfo.Add( typeof( Double ) ); //ShipmentCnt
            //�艿�i�Ŕ��C�����j
            serInfo.MemberInfo.Add( typeof( Double ) ); //ListPriceTaxExcFl
            // ----------- ADD �A��729 2011/08/18 -------------------->>>>>
            //������
            serInfo.MemberInfo.Add( typeof( Double ) ); //CostRate
            //������
            serInfo.MemberInfo.Add( typeof( Double ) ); //SalesRate
            // ----------- ADD �A��729 2011/08/18 --------------------<<<<<
            //����Őŗ�
            serInfo.MemberInfo.Add(typeof(Double)); //ConsTaxRate // ADD ���V�� 2020/03/11 PMKOBETSU-2912
            //�I�[�v�����i�敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //OpenPriceDiv
            //����P���i�Ŕ��C�����j
            serInfo.MemberInfo.Add( typeof( Double ) ); //SalesUnPrcTaxExcFl
            //�����P��
            serInfo.MemberInfo.Add( typeof( Double ) ); //SalesUnitCost
            //������z�i�Ŕ����j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SalesMoneyTaxExc
            //����œ]�ŕ���
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ConsTaxLayMethod
            //����`�[���v�i�ō��݁j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SalesTotalTaxInc
            //������z����Ŋz
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SalesPriceConsTax
            //�������z�v
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //TotalCost
            //�^���w��ԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ModelDesignationNo
            //�ޕʔԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CategoryNo
            //�Ԏ�S�p����
            serInfo.MemberInfo.Add( typeof( string ) ); //ModelFullName
            //���N�x
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //FirstEntryDate
            //�ԑ䇂
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SearchFrameNo
            //�^���i�t���^�j
            serInfo.MemberInfo.Add( typeof( string ) ); //FullModel
            //�`�[���l
            serInfo.MemberInfo.Add( typeof( string ) ); //SlipNote
            //�`�[���l�Q
            serInfo.MemberInfo.Add( typeof( string ) ); //SlipNote2
            //�`�[���l�R
            serInfo.MemberInfo.Add( typeof( string ) ); //SlipNote3
            //��t�]�ƈ�����
            serInfo.MemberInfo.Add( typeof( string ) ); //FrontEmployeeNm
            //������͎Җ���
            serInfo.MemberInfo.Add( typeof( string ) ); //SalesInputName
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CustomerCode
            //���Ӑ旪��
            serInfo.MemberInfo.Add( typeof( string ) ); //CustomerSnm
            //�d����R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SupplierCd
            //�d���旪��
            serInfo.MemberInfo.Add( typeof( string ) ); //SupplierSnm
            //�����`�[�ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //PartySaleSlipNum
            //�ԗ��Ǘ��R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //CarMngCode
            //�󒍔ԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //AcceptAnOrderNo
            //�v�㌳�o�ׇ�
            serInfo.MemberInfo.Add( typeof( string ) ); //ShipmSalesSlipNum
            //������(���ו\��)
            serInfo.MemberInfo.Add( typeof( string ) ); //SrcSalesSlipNum
            //����݌Ɏ�񂹋敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SalesOrderDivCd
            //�q�ɖ���
            serInfo.MemberInfo.Add( typeof( string ) ); //WarehouseName
            //�d���`�[�ԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SupplierSlipNo
            //UOE������R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //UOESupplierCd
            //�����於(���ו\��)
            serInfo.MemberInfo.Add( typeof( string ) ); //UOESupplierSnm
            //�t�n�d���}�[�N�P
            serInfo.MemberInfo.Add( typeof( string ) ); //UoeRemark1
            //�t�n�d���}�[�N�Q
            serInfo.MemberInfo.Add( typeof( string ) ); //UoeRemark2
            //�K�C�h����
            serInfo.MemberInfo.Add( typeof( string ) ); //GuideName
            //���_�K�C�h����
            serInfo.MemberInfo.Add( typeof( string ) ); //SectionGuideNm
            //���ה��l
            serInfo.MemberInfo.Add( typeof( string ) ); //DtlNote
            //�J���[����1
            serInfo.MemberInfo.Add( typeof( string ) ); //ColorName1
            //�g��������
            serInfo.MemberInfo.Add( typeof( string ) ); //TrimName
            //��P���i�艿�j
            serInfo.MemberInfo.Add( typeof( Double ) ); //StdUnPrcLPrice
            //��P���i����P���j
            serInfo.MemberInfo.Add( typeof( Double ) ); //StdUnPrcSalUnPrc
            //��P���i�����P���j
            serInfo.MemberInfo.Add( typeof( Double ) ); //StdUnPrcUnCst
            // -------------ADD 2009/12/28-------------->>>>>
            //�ύX�O�P��
            serInfo.MemberInfo.Add( typeof( Double ) ); //BfSalesUnitPrice
            //�ύX�O����
            serInfo.MemberInfo.Add( typeof( Double ) ); //BfUnitCost
            // -------------ADD 2009/12/28--------------<<<<<
            // -------------ADD 2010/08/05-------------->>>>>
            //�ύX�O�艿
            serInfo.MemberInfo.Add(typeof(Double)); //BfListPrice
            // -------------ADD 2010/08/05--------------<<<<<
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //GoodsMakerCd
            //���[�J�[����
            serInfo.MemberInfo.Add( typeof( string ) ); //MakerName
            //����
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //Cost
            //���Ӑ�`�[�ԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CustSlipNo
            //�v����t
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //AddUpADate
            //���|�敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //AccRecDivCd
            //�ԓ`�敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DebitNoteDiv
            //���_�R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //SectionCode
            //�q�ɃR�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //WarehouseCode
            //���z�\�����@�敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //TotalAmountDispWayCd
            //�ېŋ敪[����]
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //TaxationDivCd
            //�����`�[�ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //StockPartySaleSlipNum
            //�[�i��R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //AddresseeCode
            //�[�i�於��
            serInfo.MemberInfo.Add( typeof( string ) ); //AddresseeName
            //�[�i�於��2
            serInfo.MemberInfo.Add( typeof( string ) ); //AddresseeName2
            //�ԑ�ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //FrameNo
            //�󒍎c��
            serInfo.MemberInfo.Add( typeof( Double ) ); //AcptAnOdrRemainCnt
            //���Е��ރR�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //EnterpriseGanreCode
            //�萔�������z
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //FeeDeposit
            //�l�������z
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DiscountDeposit
            //���͓�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //InputDay
            //���i����
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //GoodsKindCode
            //���i�啪�ރR�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //GoodsLGroup
            //���i�����ރR�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //GoodsMGroup
            //�q�ɒI��
            serInfo.MemberInfo.Add( typeof( string ) ); //WarehouseShelfNo
            //����`�[�敪�i���ׁj
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SalesSlipCdDtl
            //���i�啪�ޖ���
            serInfo.MemberInfo.Add( typeof( string ) ); //GoodsLGroupName
            //���i�����ޖ���
            serInfo.MemberInfo.Add( typeof( string ) ); //GoodsMGroupName
            //�ԗ��Ǘ��ԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CarMngNo
            //���[�J�[�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MakerCode
            //�Ԏ�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ModelCode
            //�Ԏ�T�u�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ModelSubCode
            //�G���W���^������
            serInfo.MemberInfo.Add( typeof( string ) ); //EngineModelNm
            //�J���[�R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //ColorCode
            //�g�����R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //TrimCode
            //�[�i�敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DeliveredGoodsDiv
            //�t���^���Œ�ԍ��z��
            serInfo.MemberInfo.Add( typeof( Byte[] ) ); //FullModelFixedNoAry
            //�����I�u�W�F�N�g�z��
            serInfo.MemberInfo.Add( typeof( Byte[] ) ); //CategoryObjAry
            //������͎҃R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //SalesInputCode
            //��t�]�ƈ��R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //FrontEmployeeCd
            //�����敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HistoryDiv
            //�ԗ����s����
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //Mileage
            //���q���l
            serInfo.MemberInfo.Add( typeof( string ) ); //CarNote
            // -------------ADD 2010/01/29 ---------->>>>>
            //�ԕi�����
            serInfo.MemberInfo.Add( typeof( Double ) ); //retuppercnt
            //�ԕi��������݃t���O
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //retuppercntDiv
            // -------------ADD 2010/01/29 ----------<<<<<

            // --- ADD 2010/04/27 ---------->>>>>
            serInfo.MemberInfo.Add(typeof(Byte[])); // FreeSrchMdlFxdNoAryRF
            // --- ADD 2010/04/27 ----------<<<<<

            // --- ADD 2010/12/20 ---------->>>>>
            //����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //HisDtlSlipNum

            //�󒍃X�e�[�^�X�i���j
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatusSrc
            // --- ADD 2010/12/20 ----------<<<<<
            // ---------------------- ADD START 2011/07/18 zhubj ----------------->>>>>
            //�����񓚋敪(SCM)
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoAnswerDivSCM
            // ---------------------- ADD END   2011/07/18 zhubj -----------------<<<<<

            //---ADD START 2011/11/28 �k�m ----------------------------------->>>>>
            //�⍇���ԍ�
            serInfo.MemberInfo.Add(typeof(Int64));
            //---ADD END 2011/11/28 �k�m -----------------------------------<<<<<

            //�X�V����
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //UpdateDateTime
            serInfo.MemberInfo.Add(typeof(Int64));  //UpdateDateTimeDetail // ADD 2012/04/01 gezh Redmine#29250

            //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����----->>>>>
            //�̔��G���A �n��
            serInfo.MemberInfo.Add(typeof(string));//salesAreaName
            //���Ӑ敪�̓R�[�h1
            serInfo.MemberInfo.Add(typeof(Int32));//CustAnalysCode1
            //���Ӑ敪�̓R�[�h2
            serInfo.MemberInfo.Add(typeof(Int32));//CustAnalysCode2
            //���Ӑ敪�̓R�[�h3
            serInfo.MemberInfo.Add(typeof(Int32));//CustAnalysCode3
            //���Ӑ敪�̓R�[�h4
            serInfo.MemberInfo.Add(typeof(Int32));//CustAnalysCode4
            //���Ӑ敪�̓R�[�h5
            serInfo.MemberInfo.Add(typeof(Int32));//CustAnalysCode5
            //���Ӑ敪�̓R�[�h6
            serInfo.MemberInfo.Add(typeof(Int32));//CustAnalysCode6
            //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����-----<<<<<

            serInfo.Serialize( writer, serInfo );
            if ( graph is CustPrtPprSalTblRsltWork )
            {
                CustPrtPprSalTblRsltWork temp = (CustPrtPprSalTblRsltWork)graph;

                SetCustPrtPprSalTblRsltWork( writer, temp );
            }
            else
            {
                ArrayList lst = null;
                if ( graph is CustPrtPprSalTblRsltWork[] )
                {
                    lst = new ArrayList();
                    lst.AddRange( (CustPrtPprSalTblRsltWork[])graph );
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach ( CustPrtPprSalTblRsltWork temp in lst )
                {
                    SetCustPrtPprSalTblRsltWork( writer, temp );
                }

            }
        }


        /// <summary>
        /// CustPrtPprSalTblRsltWork�����o��(public�v���p�e�B��)
        /// </summary>
        // --- UPD m.suzuki 2010/04/02 ---------->>>>>
        ////private const int currentMemberCount = 101;// DEL 2009/12/28
        //// -------------UPD 2010/01/29 ---------->>>>>
        ////private const int currentMemberCount = 103;// ADD 2009/12/28
        //private const int currentMemberCount = 105;
        //// -------------UPD 2010/01/29 ----------<<<<<
        //private const int currentMemberCount = 106;// DEL 2010/04/27
        //private const int currentMemberCount = 107;// ADD 2010/04/27// DEL 2010/08/05
        // --- UPD m.suzuki 2010/04/02 ----------<<<<<
        //private const int currentMemberCount = 108;// ADD 2010/08/05 // DEL 2010/12/20
        //private const int currentMemberCount = 110;// ADD 2010/12/20 // del 2011/07/18 zhubj
        //private const int currentMemberCount = 111;// add 2011/07/18 zhubj // DEL �A��729 2011/08/18
        //private const int currentMemberCount = 113;// ADD �A��729 2011/08/18 //DEL �k�m 2011/11/28
        //private const int currentMemberCount = 114;  //ADD 2011/11/28�@�k�m  // DEL 2012/04/01 gezh Redmine#29250
        //private const int currentMemberCount = 115;  // ADD 2012/04/01 gezh Redmine#29250 // DEL �i�N 2014/12/28 �ϊ���i�Ԃ̒ǉ��Ή�
        //private const int currentMemberCount = 116;// ADD �i�N 2014/12/28 �ϊ���i�Ԃ̒ǉ��Ή� //DEL K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����
        private const int currentMemberCount = 123;//ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����
        /// <summary>
        ///  CustPrtPprSalTblRsltWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustPrtPprSalTblRsltWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2011/11/28 �k�m redmine#8172�̒ǉ��Ή�</br>
        /// <br>Update Note      :   K2015/06/16 鸏�</br>
        /// <br>�Ǘ��ԍ�         :   11101427-00</br>
        /// <br>                 :   ���C�S�����Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����B</br>
        /// </remarks>
        private void SetCustPrtPprSalTblRsltWork( System.IO.BinaryWriter writer, CustPrtPprSalTblRsltWork temp )
        {
            //�f�[�^�敪
            writer.Write( temp.DataDiv );
            //������t
            writer.Write( (Int64)temp.SalesDate.Ticks );
            //����`�[�ԍ�
            writer.Write( temp.SalesSlipNum );
            //����s�ԍ�
            writer.Write( temp.SalesRowNo );
            //�󒍃X�e�[�^�X
            writer.Write( temp.AcptAnOdrStatus );
            //����`�[�敪
            writer.Write( temp.SalesSlipCd );
            //�̔��]�ƈ�����
            writer.Write( temp.SalesEmployeeNm );
            //����`�[���v�i�Ŕ����j
            writer.Write( temp.SalesTotalTaxExc );
            //���i����
            writer.Write( temp.GoodsName );
            //���i�ԍ�
            writer.Write( temp.GoodsNo );
            // --- ADD �i�N 2014/12/28 �ϊ���i�Ԃ̒ǉ��Ή�----->>>>>
            //�ϊ���i��
            writer.Write(temp.ChangeGoodsNo);
            // --- ADD �i�N 2014/12/28 �ϊ���i�Ԃ̒ǉ��Ή�-----<<<<<
            //BL���i�R�[�h
            writer.Write( temp.BLGoodsCode );
            //BL�O���[�v�R�[�h
            writer.Write( temp.BLGroupCode );
            //�o�א�
            writer.Write( temp.ShipmentCnt );
            //�艿�i�Ŕ��C�����j
            writer.Write( temp.ListPriceTaxExcFl );
            // ----------- ADD �A��729 2011/08/18 -------------------->>>>>
            //������
            writer.Write(temp.CostRate);
            //������
            writer.Write(temp.SalesRate);
            // ----------- ADD �A��729 2011/08/18 --------------------<<<<<
            //����ŗ�
            writer.Write(temp.ConsTaxRate); // ADD ���V�� 2020/03/11 PMKOBETSU-2912
            //�I�[�v�����i�敪
            writer.Write( temp.OpenPriceDiv );
            //����P���i�Ŕ��C�����j
            writer.Write( temp.SalesUnPrcTaxExcFl );
            //�����P��
            writer.Write( temp.SalesUnitCost );
            //������z�i�Ŕ����j
            writer.Write( temp.SalesMoneyTaxExc );
            //����œ]�ŕ���
            writer.Write( temp.ConsTaxLayMethod );
            //����`�[���v�i�ō��݁j
            writer.Write( temp.SalesTotalTaxInc );
            //������z����Ŋz
            writer.Write( temp.SalesPriceConsTax );
            //�������z�v
            writer.Write( temp.TotalCost );
            //�^���w��ԍ�
            writer.Write( temp.ModelDesignationNo );
            //�ޕʔԍ�
            writer.Write( temp.CategoryNo );
            //�Ԏ�S�p����
            writer.Write( temp.ModelFullName );
            //���N�x
            //writer.Write( (Int64)temp.FirstEntryDate.Ticks );// DEL 2010/01/12
            writer.Write( temp.FirstEntryDate );// ADD 2010/01/12
            //�ԑ䇂
            writer.Write( temp.SearchFrameNo );
            //�^���i�t���^�j
            writer.Write( temp.FullModel );
            //�`�[���l
            writer.Write( temp.SlipNote );
            //�`�[���l�Q
            writer.Write( temp.SlipNote2 );
            //�`�[���l�R
            writer.Write( temp.SlipNote3 );
            //��t�]�ƈ�����
            writer.Write( temp.FrontEmployeeNm );
            //������͎Җ���
            writer.Write( temp.SalesInputName );
            //���Ӑ�R�[�h
            writer.Write( temp.CustomerCode );
            //���Ӑ旪��
            writer.Write( temp.CustomerSnm );
            //�d����R�[�h
            writer.Write( temp.SupplierCd );
            //�d���旪��
            writer.Write( temp.SupplierSnm );
            //�����`�[�ԍ�
            writer.Write( temp.PartySaleSlipNum );
            //�ԗ��Ǘ��R�[�h
            writer.Write( temp.CarMngCode );
            //�󒍔ԍ�
            writer.Write( temp.AcceptAnOrderNo );
            //�v�㌳�o�ׇ�
            writer.Write( temp.ShipmSalesSlipNum );
            //������(���ו\��)
            writer.Write( temp.SrcSalesSlipNum );
            //����݌Ɏ�񂹋敪
            writer.Write( temp.SalesOrderDivCd );
            //�q�ɖ���
            writer.Write( temp.WarehouseName );
            //�d���`�[�ԍ�
            writer.Write( temp.SupplierSlipNo );
            //UOE������R�[�h
            writer.Write( temp.UOESupplierCd );
            //�����於(���ו\��)
            writer.Write( temp.UOESupplierSnm );
            //�t�n�d���}�[�N�P
            writer.Write( temp.UoeRemark1 );
            //�t�n�d���}�[�N�Q
            writer.Write( temp.UoeRemark2 );
            //�K�C�h����
            writer.Write( temp.GuideName );
            //���_�K�C�h����
            writer.Write( temp.SectionGuideNm );
            //���ה��l
            writer.Write( temp.DtlNote );
            //�J���[����1
            writer.Write( temp.ColorName1 );
            //�g��������
            writer.Write( temp.TrimName );
            //��P���i�艿�j
            writer.Write( temp.StdUnPrcLPrice );
            //��P���i����P���j
            writer.Write( temp.StdUnPrcSalUnPrc );
            //��P���i�����P���j
            writer.Write( temp.StdUnPrcUnCst );
            // -------------ADD 2009/12/28-------------->>>>>
            //�ύX�O�P��
            writer.Write( temp.BfSalesUnitPrice );
            //�ύX�O����
            writer.Write( temp.BfUnitCost );
            // -------------ADD 2009/12/28--------------<<<<<
            // -------------ADD 2010/08/05-------------->>>>>
            //�ύX�O�艿
            writer.Write(temp.BfListPrice);
            // -------------ADD 2010/08/05--------------<<<<<
            //���i���[�J�[�R�[�h
            writer.Write( temp.GoodsMakerCd );
            //���[�J�[����
            writer.Write( temp.MakerName );
            //����
            writer.Write( temp.Cost );
            //���Ӑ�`�[�ԍ�
            writer.Write( temp.CustSlipNo );
            //�v����t
            writer.Write( (Int64)temp.AddUpADate.Ticks );
            //���|�敪
            writer.Write( temp.AccRecDivCd );
            //�ԓ`�敪
            writer.Write( temp.DebitNoteDiv );
            //���_�R�[�h
            writer.Write( temp.SectionCode );
            //�q�ɃR�[�h
            writer.Write( temp.WarehouseCode );
            //���z�\�����@�敪
            writer.Write( temp.TotalAmountDispWayCd );
            //�ېŋ敪[����]
            writer.Write( temp.TaxationDivCd );
            //�����`�[�ԍ�
            writer.Write( temp.StockPartySaleSlipNum );
            //�[�i��R�[�h
            writer.Write( temp.AddresseeCode );
            //�[�i�於��
            writer.Write( temp.AddresseeName );
            //�[�i�於��2
            writer.Write( temp.AddresseeName2 );
            //�ԑ�ԍ�
            writer.Write( temp.FrameNo );
            //�󒍎c��
            writer.Write( temp.AcptAnOdrRemainCnt );
            //���Е��ރR�[�h
            writer.Write( temp.EnterpriseGanreCode );
            //�萔�������z
            writer.Write( temp.FeeDeposit );
            //�l�������z
            writer.Write( temp.DiscountDeposit );
            //���͓�
            writer.Write( (Int64)temp.InputDay.Ticks );
            //���i����
            writer.Write( temp.GoodsKindCode );
            //���i�啪�ރR�[�h
            writer.Write( temp.GoodsLGroup );
            //���i�����ރR�[�h
            writer.Write( temp.GoodsMGroup );
            //�q�ɒI��
            writer.Write( temp.WarehouseShelfNo );
            //����`�[�敪�i���ׁj
            writer.Write( temp.SalesSlipCdDtl );
            //���i�啪�ޖ���
            writer.Write( temp.GoodsLGroupName );
            //���i�����ޖ���
            writer.Write( temp.GoodsMGroupName );
            //�ԗ��Ǘ��ԍ�
            writer.Write( temp.CarMngNo );
            //���[�J�[�R�[�h
            writer.Write( temp.MakerCode );
            //�Ԏ�R�[�h
            writer.Write( temp.ModelCode );
            //�Ԏ�T�u�R�[�h
            writer.Write( temp.ModelSubCode );
            //�G���W���^������
            writer.Write( temp.EngineModelNm );
            //�J���[�R�[�h
            writer.Write( temp.ColorCode );
            //�g�����R�[�h
            writer.Write( temp.TrimCode );
            //�[�i�敪
            writer.Write( temp.DeliveredGoodsDiv );
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
            //�t���^���Œ�ԍ��z��
            if ( temp.FullModelFixedNoAry == null ) temp.FullModelFixedNoAry = new int[0];
            int length = temp.FullModelFixedNoAry.Length;
            writer.Write( length );
            for ( int cnt = 0; cnt < length; cnt++ )
                writer.Write( temp.FullModelFixedNoAry[cnt] );
            //�����I�u�W�F�N�g�z��
            if ( temp.CategoryObjAry == null ) temp.CategoryObjAry = new byte[0];
            writer.Write( temp.CategoryObjAry.Length );
            writer.Write( temp.CategoryObjAry );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD
            //������͎҃R�[�h
            writer.Write( temp.SalesInputCode );
            //��t�]�ƈ��R�[�h
            writer.Write( temp.FrontEmployeeCd );
            //�����敪
            writer.Write( temp.HistoryDiv );
            //�ԗ����s����
            writer.Write( temp.Mileage );
            //���q���l
            writer.Write( temp.CarNote );
            // -------------ADD 2010/01/29 ---------->>>>>
            //�ԕi�����
            writer.Write( temp.Retuppercnt );
            //�ԕi��������݃t���O   
            writer.Write( temp.RetuppercntDiv );
            // -------------ADD 2010/01/29 ----------<<<<<
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 UPD
            //�X�V����
            writer.Write( temp.UpdateDateTime );
            writer.Write(temp.UpdateDateTimeDetail);  // ADD 2012/04/01 gezh Redmine#29250
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 UPD
            // --- ADD m.suzuki 2010/04/02 ---------->>>>>
            //�Ԏ피�p����
            writer.Write( temp.ModelHalfName );
            // --- ADD m.suzuki 2010/04/02 ----------<<<<<

            // --- ADD 2010/04/27 ---------->>>>>
            //���R�����^���Œ�ԍ��z��
            if (temp.FreeSrchMdlFxdNoAry == null) temp.FreeSrchMdlFxdNoAry = new byte[0];
            writer.Write(temp.FreeSrchMdlFxdNoAry.Length);
            writer.Write(temp.FreeSrchMdlFxdNoAry);
            // --- ADD 2010/04/27 ----------<<<<<

            // --- ADD 2010/12/20 ---------->>>>>
            //����`�[�ԍ�
            writer.Write(temp.HisDtlSlipNum);
            //�󒍃X�e�[�^�X�i���j
            writer.Write(temp.AcptAnOdrStatusSrc);
            // --- ADD 2010/12/20 ----------<<<<<
            // ---------------------- ADD START 2011/07/18 zhubj ----------------->>>>>
            //�����񓚋敪(SCM)
            writer.Write(temp.AutoAnswerDivSCM);
            // ---------------------- ADD END   2011/07/18 zhubj -----------------<<<<<

            //---ADD START 2011/11/28 �k�m ----------------------------------->>>>>
            //�⍇���ԍ�
            writer.Write(temp.InquiryNumber);
            //---ADD END 2011/11/28 �k�m -----------------------------------<<<<<

            //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����----->>>>>
            //�̔��G���A
            writer.Write(temp.SalesAreaName);
            //���Ӑ敪�̓R�[�h1
            writer.Write(temp.CustAnalysCode1);
            //���Ӑ敪�̓R�[�h2
            writer.Write(temp.CustAnalysCode2);
            //���Ӑ敪�̓R�[�h3
            writer.Write(temp.CustAnalysCode3);
            //���Ӑ敪�̓R�[�h4
            writer.Write(temp.CustAnalysCode4);
            //���Ӑ敪�̓R�[�h5
            writer.Write(temp.CustAnalysCode5);
            //���Ӑ敪�̓R�[�h6
            writer.Write(temp.CustAnalysCode6);
            //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����-----<<<<<
        }

        /// <summary>
        ///  CustPrtPprSalTblRsltWork�C���X�^���X�擾
        /// </summary>
        /// <returns>CustPrtPprSalTblRsltWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustPrtPprSalTblRsltWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2011/11/28 �k�m redmine#8172�̒ǉ��Ή�</br>
        /// <br>Update Note      :   K2015/06/16 鸏�</br>
        /// <br>�Ǘ��ԍ�         :   11101427-00</br>
        /// <br>                 :   ���C�S�����Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����B</br>
        /// </remarks>
        private CustPrtPprSalTblRsltWork GetCustPrtPprSalTblRsltWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            CustPrtPprSalTblRsltWork temp = new CustPrtPprSalTblRsltWork();

            //�f�[�^�敪
            temp.DataDiv = reader.ReadInt32();
            //������t
            temp.SalesDate = new DateTime( reader.ReadInt64() );
            //����`�[�ԍ�
            temp.SalesSlipNum = reader.ReadString();
            //����s�ԍ�
            temp.SalesRowNo = reader.ReadInt32();
            //�󒍃X�e�[�^�X
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //����`�[�敪
            temp.SalesSlipCd = reader.ReadInt32();
            //�̔��]�ƈ�����
            temp.SalesEmployeeNm = reader.ReadString();
            //����`�[���v�i�Ŕ����j
            temp.SalesTotalTaxExc = reader.ReadInt64();
            //���i����
            temp.GoodsName = reader.ReadString();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            // --- ADD �i�N 2014/12/28 �ϊ���i�Ԃ̒ǉ��Ή�----->>>>>
            //�ϊ���i��
            temp.ChangeGoodsNo = reader.ReadString();
            // --- ADD �i�N 2014/12/28 �ϊ���i�Ԃ̒ǉ��Ή�-----<<<<<
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //BL�O���[�v�R�[�h
            temp.BLGroupCode = reader.ReadInt32();
            //�o�א�
            temp.ShipmentCnt = reader.ReadDouble();
            //�艿�i�Ŕ��C�����j
            temp.ListPriceTaxExcFl = reader.ReadDouble();
            // ----------- ADD �A��729 2011/08/18 -------------------->>>>>
            //������
            temp.CostRate = reader.ReadDouble();
            //������
            temp.SalesRate = reader.ReadDouble();
            // ----------- ADD �A��729 2011/08/18 --------------------<<<<<
            //����ŗ�
            temp.ConsTaxRate = reader.ReadDouble(); // ADD ���V�� 2020/03/11 PMKOBETSU-2912
            //�I�[�v�����i�敪
            temp.OpenPriceDiv = reader.ReadInt32();
            //����P���i�Ŕ��C�����j
            temp.SalesUnPrcTaxExcFl = reader.ReadDouble();
            //�����P��
            temp.SalesUnitCost = reader.ReadDouble();
            //������z�i�Ŕ����j
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            //����œ]�ŕ���
            temp.ConsTaxLayMethod = reader.ReadInt32();
            //����`�[���v�i�ō��݁j
            temp.SalesTotalTaxInc = reader.ReadInt64();
            //������z����Ŋz
            temp.SalesPriceConsTax = reader.ReadInt64();
            //�������z�v
            temp.TotalCost = reader.ReadInt64();
            //�^���w��ԍ�
            temp.ModelDesignationNo = reader.ReadInt32();
            //�ޕʔԍ�
            temp.CategoryNo = reader.ReadInt32();
            //�Ԏ�S�p����
            temp.ModelFullName = reader.ReadString();
            //���N�x
            //temp.FirstEntryDate = new DateTime(reader.ReadInt64());// DEL 2010/01/12
            temp.FirstEntryDate = reader.ReadInt32();// ADD 2010/01/12
            //�ԑ䇂
            temp.SearchFrameNo = reader.ReadInt32();
            //�^���i�t���^�j
            temp.FullModel = reader.ReadString();
            //�`�[���l
            temp.SlipNote = reader.ReadString();
            //�`�[���l�Q
            temp.SlipNote2 = reader.ReadString();
            //�`�[���l�R
            temp.SlipNote3 = reader.ReadString();
            //��t�]�ƈ�����
            temp.FrontEmployeeNm = reader.ReadString();
            //������͎Җ���
            temp.SalesInputName = reader.ReadString();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //���Ӑ旪��
            temp.CustomerSnm = reader.ReadString();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�d���旪��
            temp.SupplierSnm = reader.ReadString();
            //�����`�[�ԍ�
            temp.PartySaleSlipNum = reader.ReadString();
            //�ԗ��Ǘ��R�[�h
            temp.CarMngCode = reader.ReadString();
            //�󒍔ԍ�
            temp.AcceptAnOrderNo = reader.ReadInt32();
            //�v�㌳�o�ׇ�
            temp.ShipmSalesSlipNum = reader.ReadString();
            //������(���ו\��)
            temp.SrcSalesSlipNum = reader.ReadString();
            //����݌Ɏ�񂹋敪
            temp.SalesOrderDivCd = reader.ReadInt32();
            //�q�ɖ���
            temp.WarehouseName = reader.ReadString();
            //�d���`�[�ԍ�
            temp.SupplierSlipNo = reader.ReadInt32();
            //UOE������R�[�h
            temp.UOESupplierCd = reader.ReadInt32();
            //�����於(���ו\��)
            temp.UOESupplierSnm = reader.ReadString();
            //�t�n�d���}�[�N�P
            temp.UoeRemark1 = reader.ReadString();
            //�t�n�d���}�[�N�Q
            temp.UoeRemark2 = reader.ReadString();
            //�K�C�h����
            temp.GuideName = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideNm = reader.ReadString();
            //���ה��l
            temp.DtlNote = reader.ReadString();
            //�J���[����1
            temp.ColorName1 = reader.ReadString();
            //�g��������
            temp.TrimName = reader.ReadString();
            //��P���i�艿�j
            temp.StdUnPrcLPrice = reader.ReadDouble();
            //��P���i����P���j
            temp.StdUnPrcSalUnPrc = reader.ReadDouble();
            //��P���i�����P���j
            temp.StdUnPrcUnCst = reader.ReadDouble();
            // -------------ADD 2009/12/28-------------->>>>>
            //�ύX�O�P��
            temp.BfSalesUnitPrice = reader.ReadDouble();
            //�ύX�O����
            temp.BfUnitCost = reader.ReadDouble();
            // -------------ADD 2009/12/28--------------<<<<<
            // -------------ADD 2010/08/05-------------->>>>>
            //�ύX�O�艿
            temp.BfListPrice = reader.ReadDouble();
            // -------------ADD 2010/08/05--------------<<<<<
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���[�J�[����
            temp.MakerName = reader.ReadString();
            //����
            temp.Cost = reader.ReadInt64();
            //���Ӑ�`�[�ԍ�
            temp.CustSlipNo = reader.ReadInt32();
            //�v����t
            temp.AddUpADate = new DateTime( reader.ReadInt64() );
            //���|�敪
            temp.AccRecDivCd = reader.ReadInt32();
            //�ԓ`�敪
            temp.DebitNoteDiv = reader.ReadInt32();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //�q�ɃR�[�h
            temp.WarehouseCode = reader.ReadString();
            //���z�\�����@�敪
            temp.TotalAmountDispWayCd = reader.ReadInt32();
            //�ېŋ敪[����]
            temp.TaxationDivCd = reader.ReadInt32();
            //�����`�[�ԍ�
            temp.StockPartySaleSlipNum = reader.ReadString();
            //�[�i��R�[�h
            temp.AddresseeCode = reader.ReadInt32();
            //�[�i�於��
            temp.AddresseeName = reader.ReadString();
            //�[�i�於��2
            temp.AddresseeName2 = reader.ReadString();
            //�ԑ�ԍ�
            temp.FrameNo = reader.ReadString();
            //�󒍎c��
            temp.AcptAnOdrRemainCnt = reader.ReadDouble();
            //���Е��ރR�[�h
            temp.EnterpriseGanreCode = reader.ReadInt32();
            //�萔�������z
            temp.FeeDeposit = reader.ReadInt64();
            //�l�������z
            temp.DiscountDeposit = reader.ReadInt64();
            //���͓�
            temp.InputDay = new DateTime( reader.ReadInt64() );
            //���i����
            temp.GoodsKindCode = reader.ReadInt32();
            //���i�啪�ރR�[�h
            temp.GoodsLGroup = reader.ReadInt32();
            //���i�����ރR�[�h
            temp.GoodsMGroup = reader.ReadInt32();
            //�q�ɒI��
            temp.WarehouseShelfNo = reader.ReadString();
            //����`�[�敪�i���ׁj
            temp.SalesSlipCdDtl = reader.ReadInt32();
            //���i�啪�ޖ���
            temp.GoodsLGroupName = reader.ReadString();
            //���i�����ޖ���
            temp.GoodsMGroupName = reader.ReadString();
            //�ԗ��Ǘ��ԍ�
            temp.CarMngNo = reader.ReadInt32();
            //���[�J�[�R�[�h
            temp.MakerCode = reader.ReadInt32();
            //�Ԏ�R�[�h
            temp.ModelCode = reader.ReadInt32();
            //�Ԏ�T�u�R�[�h
            temp.ModelSubCode = reader.ReadInt32();
            //�G���W���^������
            temp.EngineModelNm = reader.ReadString();
            //�J���[�R�[�h
            temp.ColorCode = reader.ReadString();
            //�g�����R�[�h
            temp.TrimCode = reader.ReadString();
            //�[�i�敪
            temp.DeliveredGoodsDiv = reader.ReadInt32();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
            //�t���^���Œ�ԍ��z��
            int length = reader.ReadInt32();
            temp.FullModelFixedNoAry = new int[length];
            for ( int cnt = 0; cnt < length; cnt++ )
                temp.FullModelFixedNoAry[cnt] = reader.ReadInt32();
            //�����I�u�W�F�N�g�z��
            length = reader.ReadInt32();
            temp.CategoryObjAry = reader.ReadBytes( length );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD
            //������͎҃R�[�h
            temp.SalesInputCode = reader.ReadString();
            //��t�]�ƈ��R�[�h
            temp.FrontEmployeeCd = reader.ReadString();
            //�����敪
            temp.HistoryDiv = reader.ReadInt32();
            //�ԗ����s����
            temp.Mileage = reader.ReadInt32();
            //���q���l
            temp.CarNote = reader.ReadString();
            // -------------ADD 2010/01/29 ---------->>>>>
            //�ԕi�����
            temp.Retuppercnt = reader.ReadDouble();
            //�ԕi��������݃t���O
            temp.RetuppercntDiv = reader.ReadInt32();
            // -------------ADD 2010/01/29 ----------<<<<<
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 UPD
            //�X�V����
            temp.UpdateDateTime = reader.ReadInt64();
            temp.UpdateDateTimeDetail = reader.ReadInt64();  // ADD 2012/04/01 gezh Redmine#29250
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 UPD
            // --- UPD m.suzuki 2010/04/02 ---------->>>>>
            // �Ԏ피�p����
            temp.ModelHalfName = reader.ReadString();
            // --- UPD m.suzuki 2010/04/02 ----------<<<<<

            // --- ADD 2010/04/27 ---------->>>>>
            //���R�����^���Œ�ԍ��z��
            length = reader.ReadInt32();
            temp.FreeSrchMdlFxdNoAry = reader.ReadBytes(length);
            // --- ADD 2010/04/27 ----------<<<<<

            // --- ADD 2010/12/20 ---------->>>>>
            //����`�[�ԍ�
            temp.HisDtlSlipNum = reader.ReadString();
            //�󒍃X�e�[�^�X�i���j
            temp.AcptAnOdrStatusSrc = reader.ReadInt32();
            // --- ADD 2010/12/20 ----------<<<<<
            // ---------------------- ADD START 2011/07/18 zhubj ----------------->>>>>
            //�����񓚋敪(SCM)
            temp.AutoAnswerDivSCM = reader.ReadInt32();
            // ---------------------- ADD END   2011/07/18 zhubj -----------------<<<<<

            //---ADD START 2011/11/28 �k�m ----------------------------------->>>>>
            //�⍇���ԍ�
            temp.InquiryNumber = reader.ReadInt64();
            //---ADD END 2011/11/28 �k�m -----------------------------------<<<<<

            //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����----->>>>>
            //�̔��G���A
            temp.SalesAreaName = reader.ReadString();
            //���Ӑ敪�̓R�[�h1
            temp.CustAnalysCode1 = reader.ReadInt32();
            //���Ӑ敪�̓R�[�h2
            temp.CustAnalysCode2 = reader.ReadInt32();
            //���Ӑ敪�̓R�[�h3
            temp.CustAnalysCode3 = reader.ReadInt32();
            //���Ӑ敪�̓R�[�h4
            temp.CustAnalysCode4 = reader.ReadInt32();
            //���Ӑ敪�̓R�[�h5
            temp.CustAnalysCode5 = reader.ReadInt32();
            //���Ӑ敪�̓R�[�h6
            temp.CustAnalysCode6 = reader.ReadInt32();
            //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����-----<<<<<
 
            //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
            //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
            //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
            //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
            for ( int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k )
            {
                //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
                //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
                //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
                //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if ( oMemberType is Type )
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType( reader, t, optCount );
                    if ( t.Equals( typeof( int ) ) )
                    {
                        optCount = Convert.ToInt32( oData );
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if ( oMemberType is string )
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate( (string)oMemberType );
                    object userData = formatter.Deserialize( reader );  //�ǂݔ�΂�
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
        /// </summary>
        /// <returns>CustPrtPprSalTblRsltWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustPrtPprSalTblRsltWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize( System.IO.BinaryReader reader )
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
            ArrayList lst = new ArrayList();
            for ( int cnt = 0; cnt < serInfo.Occurrence; ++cnt )
            {
                CustPrtPprSalTblRsltWork temp = GetCustPrtPprSalTblRsltWork( reader, serInfo );
                lst.Add( temp );
            }
            switch ( serInfo.RetTypeInfo )
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (CustPrtPprSalTblRsltWork[])lst.ToArray( typeof( CustPrtPprSalTblRsltWork ) );
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

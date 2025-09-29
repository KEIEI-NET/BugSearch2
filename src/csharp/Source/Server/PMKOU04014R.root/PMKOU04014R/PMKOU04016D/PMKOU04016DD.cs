using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/19 DEL
    # region // DEL
    ///// public class name:   SuppPrtPprStcTblRsltWork
    ///// <summary>
    /////                      �d����d�q�������o����(�`�[�E����)�N���X���[�N
    ///// </summary>
    ///// <remarks>
    ///// <br>note             :   �d����d�q�������o����(�`�[�E����)�N���X���[�N�w�b�_�t�@�C��</br>
    ///// <br>Programmer       :   ��������</br>
    ///// <br>Date             :   </br>
    ///// <br>Genarated Date   :   2008/08/20  (CSharp File Generated Date)</br>
    ///// <br>Update Note      :   </br>
    ///// </remarks>
    //[Serializable]
    //[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    //public class SuppPrtPprStcTblRsltWork
    //{
    //    /// <summary>�f�[�^�敪</summary>
    //    /// <remarks>0:�d���f�[�^ 1:�x���f�[�^</remarks>
    //    private Int32 _dataDiv;

    //    /// <summary>�`�[���t</summary>
    //    /// <remarks>�d����(YYYYMMDD)/�x�����t</remarks>
    //    private DateTime _stockDate;

    //    /// <summary>�`�[�ԍ�</summary>
    //    /// <remarks>�����`�[�ԍ�</remarks>
    //    private string _partySaleSlipNum = "";

    //    /// <summary>�s��(���ו\��)</summary>
    //    /// <remarks>�d���s�ԍ�/�����s�ԍ�</remarks>
    //    private Int32 _stockRowNo;

    //    /// <summary>�d���`��</summary>
    //    /// <remarks>0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j</remarks>
    //    private Int32 _supplierFormal;

    //    /// <summary>�d���`�[�敪</summary>
    //    /// <remarks>10:�d��,20:�ԕi</remarks>
    //    private Int32 _supplierSlipCd;

    //    /// <summary>�S���Җ�</summary>
    //    /// <remarks>�d���S���Җ���/�x���S���Җ�</remarks>
    //    private string _stockAgentName = "";

    //    /// <summary>���z</summary>
    //    /// <remarks>�d�����z�v�i�Ŕ����j/�x�����z</remarks>
    //    private Int64 _stockTtlPricTaxExc;

    //    /// <summary>�i��(���ו\��)</summary>
    //    /// <remarks>���i����/���햼��</remarks>
    //    private string _goodsName = "";

    //    /// <summary>�i��(���ו\��)</summary>
    //    /// <remarks>���i�ԍ�</remarks>
    //    private string _goodsNo = "";

    //    /// <summary>���[�J�[�R�[�h(���ו\��)</summary>
    //    /// <remarks>���i���[�J�[�R�[�h</remarks>
    //    private Int32 _goodsMakerCd;

    //    /// <summary>���[�J�[����</summary>
    //    /// <remarks>���[�J�[����</remarks>
    //    private string _makerName = "";

    //    /// <summary>BL�R�[�h(���ו\��)</summary>
    //    /// <remarks>BL���i�R�[�h</remarks>
    //    private Int32 _bLGoodsCode;

    //    /// <summary>BL�O���[�v(���ו\��)</summary>
    //    /// <remarks>BL�O���[�v�R�[�h</remarks>
    //    private Int32 _bLGroupCode;

    //    /// <summary>����(���ו\��)</summary>
    //    /// <remarks>�d����</remarks>
    //    private Double _stockCount;

    //    /// <summary>�W�����i(���ו\��)</summary>
    //    /// <remarks>�艿�i�Ŕ��C�����j</remarks>
    //    private Double _listPriceTaxExcFl;

    //    /// <summary>�I�[�v�����i�敪(���ו\��)</summary>
    //    /// <remarks>0:�ʏ�^1:�I�[�v�����i</remarks>
    //    private Int32 _openPriceDiv;

    //    /// <summary>�d�������œ]�ŕ����R�[�h</summary>
    //    /// <remarks>0:�`�[�P��1:���גP��2:�x���e 3:�x���q 9:��ې�</remarks>
    //    private Int32 _suppCTaxLayCd;

    //    /// <summary>�d�����z�v�i�ō��݁j</summary>
    //    /// <remarks>���x�����z�̂���</remarks>
    //    private Int64 _stockTtlPricTaxInc;

    //    /// <summary>�d�����z����Ŋz</summary>
    //    private Int64 _stockPriceConsTax;

    //    /// <summary>���l�P</summary>
    //    /// <remarks>�d���`�[���l1/�`�[�E�v</remarks>
    //    private string _supplierSlipNote1 = "";

    //    /// <summary>���l�Q</summary>
    //    /// <remarks>�d���`�[���l2/�L������</remarks>
    //    private string _supplierSlipNote2 = "";

    //    /// <summary>���_</summary>
    //    /// <remarks>���_�K�C�h����/�v�㋒�_�R�[�h</remarks>
    //    private string _sectionGuideNm = "";

    //    /// <summary>���s��</summary>
    //    /// <remarks>�d�����͎Җ���/�x�����͎Җ���</remarks>
    //    private string _stockInputName = "";

    //    /// <summary>�d����R�[�h</summary>
    //    /// <remarks>�d����R�[�h/�d����R�[�h</remarks>
    //    private Int32 _supplierCd;

    //    /// <summary>�d���於</summary>
    //    /// <remarks>�d���旪��/�d���旪��</remarks>
    //    private string _supplierSnm = "";

    //    /// <summary>�ݎ�(���ו\��)</summary>
    //    /// <remarks>�d���݌Ɏ�񂹋敪(0:��񂹁C1:�݌�)</remarks>
    //    private Int32 _stockOrderDivCd;

    //    /// <summary>�q��(���ו\��)</summary>
    //    /// <remarks>�q�ɖ���</remarks>
    //    private string _warehouseName = "";

    //    /// <summary>�I��(���ו\��)</summary>
    //    /// <remarks>�q�ɒI��</remarks>
    //    private string _warehouseShelfNo = "";

    //    /// <summary>�t�n�d���}�[�N�P</summary>
    //    /// <remarks>�t�n�d���}�[�N�P</remarks>
    //    private string _uoeRemark1 = "";

    //    /// <summary>�t�n�d���}�[�N�Q</summary>
    //    /// <remarks>�t�n�d���}�[�N�Q</remarks>
    //    private string _uoeRemark2 = "";

    //    /// <summary>�d��SEQ/�x����</summary>
    //    /// <remarks>�d���`�[�ԍ�/�x���`�[�ԍ�</remarks>
    //    private Int32 _supplierSlipNo;

    //    /// <summary>�v���</summary>
    //    /// <remarks>�d���v����t(YYYYMMDD)/�v����t(YYYYMMDD)</remarks>
    //    private DateTime _stockAddUpADate;

    //    /// <summary>���|�敪</summary>
    //    /// <remarks>���|�敪(0:���|�Ȃ�,1:���|)</remarks>
    //    private Int32 _accPayDivCd;

    //    /// <summary>�ԓ`�敪</summary>
    //    /// <remarks>0:���`,1:�ԓ`,2:����</remarks>
    //    private Int32 _debitNoteDiv;

    //    /// <summary>��������`�[�ԍ�(���ו\��)</summary>
    //    /// <remarks>����`�[�ԍ�</remarks>
    //    private string _salesSlipNum = "";

    //    /// <summary>����������t(���ו\��)</summary>
    //    /// <remarks>������t</remarks>
    //    private DateTime _salesDate;

    //    /// <summary>���Ӑ�R�[�h(���ו\��)</summary>
    //    /// <remarks>���Ӑ�R�[�h</remarks>
    //    private Int32 _customerCode;

    //    /// <summary>���Ӑ於(���ו\��)</summary>
    //    /// <remarks>���Ӑ旪��</remarks>
    //    private string _customerSnm = "";

    //    /// <summary>���_�R�[�h</summary>
    //    /// <remarks>���_�R�[�h</remarks>
    //    private string _sectionCode = "";

    //    /// <summary>�q�ɃR�[�h</summary>
    //    /// <remarks>�q�ɃR�[�h</remarks>
    //    private string _warehouseCode = "";

    //    /// <summary>�d���摍�z�\�����@�敪</summary>
    //    /// <remarks>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</remarks>
    //    private Int32 _suppTtlAmntDspWayCd;

    //    /// <summary>�ېŋ敪</summary>
    //    /// <remarks>0:�ې�,1:��ې�,2:�ېŁi���Łj</remarks>
    //    private Int32 _taxationCode;

    //    /// <summary>�d�����z����Ŋz�i���Łj[�`�[]</summary>
    //    /// <remarks>�l���O�̓��ŏ��i�̏����</remarks>
    //    private Int64 _stckPrcConsTaxInclu;

    //    /// <summary>�d���l������Ŋz�i���Łj[�`�[]</summary>
    //    /// <remarks>���ŏ��i�l���̏���Ŋz</remarks>
    //    private Int64 _stckDisTtlTaxInclu;


    //    /// public propaty name  :  DataDiv
    //    /// <summary>�f�[�^�敪�v���p�e�B</summary>
    //    /// <value>0:�d���f�[�^ 1:�x���f�[�^</value>
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

    //    /// public propaty name  :  StockDate
    //    /// <summary>�`�[���t�v���p�e�B</summary>
    //    /// <value>�d����(YYYYMMDD)/�x�����t</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �`�[���t�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public DateTime StockDate
    //    {
    //        get { return _stockDate; }
    //        set { _stockDate = value; }
    //    }

    //    /// public propaty name  :  PartySaleSlipNum
    //    /// <summary>�`�[�ԍ��v���p�e�B</summary>
    //    /// <value>�����`�[�ԍ�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �`�[�ԍ��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string PartySaleSlipNum
    //    {
    //        get { return _partySaleSlipNum; }
    //        set { _partySaleSlipNum = value; }
    //    }

    //    /// public propaty name  :  StockRowNo
    //    /// <summary>�s��(���ו\��)�v���p�e�B</summary>
    //    /// <value>�d���s�ԍ�/�����s�ԍ�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �s��(���ו\��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 StockRowNo
    //    {
    //        get { return _stockRowNo; }
    //        set { _stockRowNo = value; }
    //    }

    //    /// public propaty name  :  SupplierFormal
    //    /// <summary>�d���`���v���p�e�B</summary>
    //    /// <value>0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �d���`���v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 SupplierFormal
    //    {
    //        get { return _supplierFormal; }
    //        set { _supplierFormal = value; }
    //    }

    //    /// public propaty name  :  SupplierSlipCd
    //    /// <summary>�d���`�[�敪�v���p�e�B</summary>
    //    /// <value>10:�d��,20:�ԕi</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �d���`�[�敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 SupplierSlipCd
    //    {
    //        get { return _supplierSlipCd; }
    //        set { _supplierSlipCd = value; }
    //    }

    //    /// public propaty name  :  StockAgentName
    //    /// <summary>�S���Җ��v���p�e�B</summary>
    //    /// <value>�d���S���Җ���/�x���S���Җ�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �S���Җ��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string StockAgentName
    //    {
    //        get { return _stockAgentName; }
    //        set { _stockAgentName = value; }
    //    }

    //    /// public propaty name  :  StockTtlPricTaxExc
    //    /// <summary>���z�v���p�e�B</summary>
    //    /// <value>�d�����z�v�i�Ŕ����j/�x�����z</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���z�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 StockTtlPricTaxExc
    //    {
    //        get { return _stockTtlPricTaxExc; }
    //        set { _stockTtlPricTaxExc = value; }
    //    }

    //    /// public propaty name  :  GoodsName
    //    /// <summary>�i��(���ו\��)�v���p�e�B</summary>
    //    /// <value>���i����/���햼��</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �i��(���ו\��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string GoodsName
    //    {
    //        get { return _goodsName; }
    //        set { _goodsName = value; }
    //    }

    //    /// public propaty name  :  GoodsNo
    //    /// <summary>�i��(���ו\��)�v���p�e�B</summary>
    //    /// <value>���i�ԍ�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �i��(���ו\��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string GoodsNo
    //    {
    //        get { return _goodsNo; }
    //        set { _goodsNo = value; }
    //    }

    //    /// public propaty name  :  GoodsMakerCd
    //    /// <summary>���[�J�[�R�[�h(���ו\��)�v���p�e�B</summary>
    //    /// <value>���i���[�J�[�R�[�h</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���[�J�[�R�[�h(���ו\��)�v���p�e�B</br>
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

    //    /// public propaty name  :  BLGoodsCode
    //    /// <summary>BL�R�[�h(���ו\��)�v���p�e�B</summary>
    //    /// <value>BL���i�R�[�h</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   BL�R�[�h(���ו\��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 BLGoodsCode
    //    {
    //        get { return _bLGoodsCode; }
    //        set { _bLGoodsCode = value; }
    //    }

    //    /// public propaty name  :  BLGroupCode
    //    /// <summary>BL�O���[�v(���ו\��)�v���p�e�B</summary>
    //    /// <value>BL�O���[�v�R�[�h</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   BL�O���[�v(���ו\��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 BLGroupCode
    //    {
    //        get { return _bLGroupCode; }
    //        set { _bLGroupCode = value; }
    //    }

    //    /// public propaty name  :  StockCount
    //    /// <summary>����(���ו\��)�v���p�e�B</summary>
    //    /// <value>�d����</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����(���ו\��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Double StockCount
    //    {
    //        get { return _stockCount; }
    //        set { _stockCount = value; }
    //    }

    //    /// public propaty name  :  ListPriceTaxExcFl
    //    /// <summary>�W�����i(���ו\��)�v���p�e�B</summary>
    //    /// <value>�艿�i�Ŕ��C�����j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �W�����i(���ו\��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Double ListPriceTaxExcFl
    //    {
    //        get { return _listPriceTaxExcFl; }
    //        set { _listPriceTaxExcFl = value; }
    //    }

    //    /// public propaty name  :  OpenPriceDiv
    //    /// <summary>�I�[�v�����i�敪(���ו\��)�v���p�e�B</summary>
    //    /// <value>0:�ʏ�^1:�I�[�v�����i</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �I�[�v�����i�敪(���ו\��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 OpenPriceDiv
    //    {
    //        get { return _openPriceDiv; }
    //        set { _openPriceDiv = value; }
    //    }

    //    /// public propaty name  :  SuppCTaxLayCd
    //    /// <summary>�d�������œ]�ŕ����R�[�h�v���p�e�B</summary>
    //    /// <value>0:�`�[�P��1:���גP��2:�x���e 3:�x���q 9:��ې�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �d�������œ]�ŕ����R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 SuppCTaxLayCd
    //    {
    //        get { return _suppCTaxLayCd; }
    //        set { _suppCTaxLayCd = value; }
    //    }

    //    /// public propaty name  :  StockTtlPricTaxInc
    //    /// <summary>�d�����z�v�i�ō��݁j�v���p�e�B</summary>
    //    /// <value>���x�����z�̂���</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �d�����z�v�i�ō��݁j�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 StockTtlPricTaxInc
    //    {
    //        get { return _stockTtlPricTaxInc; }
    //        set { _stockTtlPricTaxInc = value; }
    //    }

    //    /// public propaty name  :  StockPriceConsTax
    //    /// <summary>�d�����z����Ŋz�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �d�����z����Ŋz�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 StockPriceConsTax
    //    {
    //        get { return _stockPriceConsTax; }
    //        set { _stockPriceConsTax = value; }
    //    }

    //    /// public propaty name  :  SupplierSlipNote1
    //    /// <summary>���l�P�v���p�e�B</summary>
    //    /// <value>�d���`�[���l1/�`�[�E�v</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���l�P�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SupplierSlipNote1
    //    {
    //        get { return _supplierSlipNote1; }
    //        set { _supplierSlipNote1 = value; }
    //    }

    //    /// public propaty name  :  SupplierSlipNote2
    //    /// <summary>���l�Q�v���p�e�B</summary>
    //    /// <value>�d���`�[���l2/�L������</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���l�Q�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SupplierSlipNote2
    //    {
    //        get { return _supplierSlipNote2; }
    //        set { _supplierSlipNote2 = value; }
    //    }

    //    /// public propaty name  :  SectionGuideNm
    //    /// <summary>���_�v���p�e�B</summary>
    //    /// <value>���_�K�C�h����/�v�㋒�_�R�[�h</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���_�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SectionGuideNm
    //    {
    //        get { return _sectionGuideNm; }
    //        set { _sectionGuideNm = value; }
    //    }

    //    /// public propaty name  :  StockInputName
    //    /// <summary>���s�҃v���p�e�B</summary>
    //    /// <value>�d�����͎Җ���/�x�����͎Җ���</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���s�҃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string StockInputName
    //    {
    //        get { return _stockInputName; }
    //        set { _stockInputName = value; }
    //    }

    //    /// public propaty name  :  SupplierCd
    //    /// <summary>�d����R�[�h�v���p�e�B</summary>
    //    /// <value>�d����R�[�h/�d����R�[�h</value>
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
    //    /// <summary>�d���於�v���p�e�B</summary>
    //    /// <value>�d���旪��/�d���旪��</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �d���於�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SupplierSnm
    //    {
    //        get { return _supplierSnm; }
    //        set { _supplierSnm = value; }
    //    }

    //    /// public propaty name  :  StockOrderDivCd
    //    /// <summary>�ݎ�(���ו\��)�v���p�e�B</summary>
    //    /// <value>�d���݌Ɏ�񂹋敪(0:��񂹁C1:�݌�)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �ݎ�(���ו\��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 StockOrderDivCd
    //    {
    //        get { return _stockOrderDivCd; }
    //        set { _stockOrderDivCd = value; }
    //    }

    //    /// public propaty name  :  WarehouseName
    //    /// <summary>�q��(���ו\��)�v���p�e�B</summary>
    //    /// <value>�q�ɖ���</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �q��(���ו\��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string WarehouseName
    //    {
    //        get { return _warehouseName; }
    //        set { _warehouseName = value; }
    //    }

    //    /// public propaty name  :  WarehouseShelfNo
    //    /// <summary>�I��(���ו\��)�v���p�e�B</summary>
    //    /// <value>�q�ɒI��</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �I��(���ו\��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string WarehouseShelfNo
    //    {
    //        get { return _warehouseShelfNo; }
    //        set { _warehouseShelfNo = value; }
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

    //    /// public propaty name  :  SupplierSlipNo
    //    /// <summary>�d��SEQ/�x�����v���p�e�B</summary>
    //    /// <value>�d���`�[�ԍ�/�x���`�[�ԍ�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �d��SEQ/�x�����v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 SupplierSlipNo
    //    {
    //        get { return _supplierSlipNo; }
    //        set { _supplierSlipNo = value; }
    //    }

    //    /// public propaty name  :  StockAddUpADate
    //    /// <summary>�v����v���p�e�B</summary>
    //    /// <value>�d���v����t(YYYYMMDD)/�v����t(YYYYMMDD)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �v����v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public DateTime StockAddUpADate
    //    {
    //        get { return _stockAddUpADate; }
    //        set { _stockAddUpADate = value; }
    //    }

    //    /// public propaty name  :  AccPayDivCd
    //    /// <summary>���|�敪�v���p�e�B</summary>
    //    /// <value>���|�敪(0:���|�Ȃ�,1:���|)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���|�敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 AccPayDivCd
    //    {
    //        get { return _accPayDivCd; }
    //        set { _accPayDivCd = value; }
    //    }

    //    /// public propaty name  :  DebitNoteDiv
    //    /// <summary>�ԓ`�敪�v���p�e�B</summary>
    //    /// <value>0:���`,1:�ԓ`,2:����</value>
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

    //    /// public propaty name  :  SalesSlipNum
    //    /// <summary>��������`�[�ԍ�(���ו\��)�v���p�e�B</summary>
    //    /// <value>����`�[�ԍ�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ��������`�[�ԍ�(���ו\��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SalesSlipNum
    //    {
    //        get { return _salesSlipNum; }
    //        set { _salesSlipNum = value; }
    //    }

    //    /// public propaty name  :  SalesDate
    //    /// <summary>����������t(���ו\��)�v���p�e�B</summary>
    //    /// <value>������t</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����������t(���ו\��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public DateTime SalesDate
    //    {
    //        get { return _salesDate; }
    //        set { _salesDate = value; }
    //    }

    //    /// public propaty name  :  CustomerCode
    //    /// <summary>���Ӑ�R�[�h(���ו\��)�v���p�e�B</summary>
    //    /// <value>���Ӑ�R�[�h</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���Ӑ�R�[�h(���ו\��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 CustomerCode
    //    {
    //        get { return _customerCode; }
    //        set { _customerCode = value; }
    //    }

    //    /// public propaty name  :  CustomerSnm
    //    /// <summary>���Ӑ於(���ו\��)�v���p�e�B</summary>
    //    /// <value>���Ӑ旪��</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���Ӑ於(���ו\��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string CustomerSnm
    //    {
    //        get { return _customerSnm; }
    //        set { _customerSnm = value; }
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

    //    /// public propaty name  :  SuppTtlAmntDspWayCd
    //    /// <summary>�d���摍�z�\�����@�敪�v���p�e�B</summary>
    //    /// <value>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �d���摍�z�\�����@�敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 SuppTtlAmntDspWayCd
    //    {
    //        get { return _suppTtlAmntDspWayCd; }
    //        set { _suppTtlAmntDspWayCd = value; }
    //    }

    //    /// public propaty name  :  TaxationCode
    //    /// <summary>�ېŋ敪�v���p�e�B</summary>
    //    /// <value>0:�ې�,1:��ې�,2:�ېŁi���Łj</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �ېŋ敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 TaxationCode
    //    {
    //        get { return _taxationCode; }
    //        set { _taxationCode = value; }
    //    }

    //    /// public propaty name  :  StckPrcConsTaxInclu
    //    /// <summary>�d�����z����Ŋz�i���Łj[�`�[]�v���p�e�B</summary>
    //    /// <value>�l���O�̓��ŏ��i�̏����</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �d�����z����Ŋz�i���Łj[�`�[]�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 StckPrcConsTaxInclu
    //    {
    //        get { return _stckPrcConsTaxInclu; }
    //        set { _stckPrcConsTaxInclu = value; }
    //    }

    //    /// public propaty name  :  StckDisTtlTaxInclu
    //    /// <summary>�d���l������Ŋz�i���Łj[�`�[]�v���p�e�B</summary>
    //    /// <value>���ŏ��i�l���̏���Ŋz</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �d���l������Ŋz�i���Łj[�`�[]�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 StckDisTtlTaxInclu
    //    {
    //        get { return _stckDisTtlTaxInclu; }
    //        set { _stckDisTtlTaxInclu = value; }
    //    }


    //    /// <summary>
    //    /// �d����d�q�������o����(�`�[�E����)�N���X���[�N�R���X�g���N�^
    //    /// </summary>
    //    /// <returns>SuppPrtPprStcTblRsltWork�N���X�̃C���X�^���X</returns>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprStcTblRsltWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public SuppPrtPprStcTblRsltWork()
    //    {
    //    }
    //}

    ///// <summary>
    /////  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    ///// </summary>
    ///// <returns>SuppPrtPprStcTblRsltWork�N���X�̃C���X�^���X(object)</returns>
    ///// <remarks>
    ///// <br>Note�@�@�@�@�@�@ :   SuppPrtPprStcTblRsltWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    ///// <br>Programer        :   ��������</br>
    ///// </remarks>
    //public class SuppPrtPprStcTblRsltWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    //{
    //    #region ICustomSerializationSurrogate �����o

    //    /// <summary>
    //    ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprStcTblRsltWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public void Serialize(System.IO.BinaryWriter writer, object graph)
    //    {
    //        // TODO:  SuppPrtPprStcTblRsltWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
    //        if (writer == null)
    //            throw new ArgumentNullException();

    //        if (graph != null && !(graph is SuppPrtPprStcTblRsltWork || graph is ArrayList || graph is SuppPrtPprStcTblRsltWork[]))
    //            throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SuppPrtPprStcTblRsltWork).FullName));

    //        if (graph != null && graph is SuppPrtPprStcTblRsltWork)
    //        {
    //            Type t = graph.GetType();
    //            if (!CustomFormatterServices.NeedCustomSerialization(t))
    //                throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
    //        }

    //        //SerializationTypeInfo
    //        Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SuppPrtPprStcTblRsltWork");

    //        //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
    //        int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
    //        if (graph is ArrayList)
    //        {
    //            serInfo.RetTypeInfo = 0;
    //            occurrence = ((ArrayList)graph).Count;
    //        }
    //        else if (graph is SuppPrtPprStcTblRsltWork[])
    //        {
    //            serInfo.RetTypeInfo = 2;
    //            occurrence = ((SuppPrtPprStcTblRsltWork[])graph).Length;
    //        }
    //        else if (graph is SuppPrtPprStcTblRsltWork)
    //        {
    //            serInfo.RetTypeInfo = 1;
    //            occurrence = 1;
    //        }

    //        serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

    //        //�f�[�^�敪
    //        serInfo.MemberInfo.Add(typeof(Int32)); //DataDiv
    //        //�`�[���t
    //        serInfo.MemberInfo.Add(typeof(Int32)); //StockDate
    //        //�`�[�ԍ�
    //        serInfo.MemberInfo.Add(typeof(string)); //PartySaleSlipNum
    //        //�s��(���ו\��)
    //        serInfo.MemberInfo.Add(typeof(Int32)); //StockRowNo
    //        //�d���`��
    //        serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormal
    //        //�d���`�[�敪
    //        serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipCd
    //        //�S���Җ�
    //        serInfo.MemberInfo.Add(typeof(string)); //StockAgentName
    //        //���z
    //        serInfo.MemberInfo.Add(typeof(Int64)); //StockTtlPricTaxExc
    //        //�i��(���ו\��)
    //        serInfo.MemberInfo.Add(typeof(string)); //GoodsName
    //        //�i��(���ו\��)
    //        serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
    //        //���[�J�[�R�[�h(���ו\��)
    //        serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
    //        //���[�J�[����
    //        serInfo.MemberInfo.Add(typeof(string)); //MakerName
    //        //BL�R�[�h(���ו\��)
    //        serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
    //        //BL�O���[�v(���ו\��)
    //        serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
    //        //����(���ו\��)
    //        serInfo.MemberInfo.Add(typeof(Double)); //StockCount
    //        //�W�����i(���ו\��)
    //        serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxExcFl
    //        //�I�[�v�����i�敪(���ו\��)
    //        serInfo.MemberInfo.Add(typeof(Int32)); //OpenPriceDiv
    //        //�d�������œ]�ŕ����R�[�h
    //        serInfo.MemberInfo.Add(typeof(Int32)); //SuppCTaxLayCd
    //        //�d�����z�v�i�ō��݁j
    //        serInfo.MemberInfo.Add(typeof(Int64)); //StockTtlPricTaxInc
    //        //�d�����z����Ŋz
    //        serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceConsTax
    //        //���l�P
    //        serInfo.MemberInfo.Add(typeof(string)); //SupplierSlipNote1
    //        //���l�Q
    //        serInfo.MemberInfo.Add(typeof(string)); //SupplierSlipNote2
    //        //���_
    //        serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
    //        //���s��
    //        serInfo.MemberInfo.Add(typeof(string)); //StockInputName
    //        //�d����R�[�h
    //        serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
    //        //�d���於
    //        serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
    //        //�ݎ�(���ו\��)
    //        serInfo.MemberInfo.Add(typeof(Int32)); //StockOrderDivCd
    //        //�q��(���ו\��)
    //        serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
    //        //�I��(���ו\��)
    //        serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
    //        //�t�n�d���}�[�N�P
    //        serInfo.MemberInfo.Add(typeof(string)); //UoeRemark1
    //        //�t�n�d���}�[�N�Q
    //        serInfo.MemberInfo.Add(typeof(string)); //UoeRemark2
    //        //�d��SEQ/�x����
    //        serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
    //        //�v���
    //        serInfo.MemberInfo.Add(typeof(Int32)); //StockAddUpADate
    //        //���|�敪
    //        serInfo.MemberInfo.Add(typeof(Int32)); //AccPayDivCd
    //        //�ԓ`�敪
    //        serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteDiv
    //        //��������`�[�ԍ�(���ו\��)
    //        serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
    //        //����������t(���ו\��)
    //        serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
    //        //���Ӑ�R�[�h(���ו\��)
    //        serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
    //        //���Ӑ於(���ו\��)
    //        serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
    //        //���_�R�[�h
    //        serInfo.MemberInfo.Add(typeof(string)); //SectionCode
    //        //�q�ɃR�[�h
    //        serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
    //        //�d���摍�z�\�����@�敪
    //        serInfo.MemberInfo.Add(typeof(Int32)); //SuppTtlAmntDspWayCd
    //        //�ېŋ敪
    //        serInfo.MemberInfo.Add(typeof(Int32)); //TaxationCode
    //        //�d�����z����Ŋz�i���Łj[�`�[]
    //        serInfo.MemberInfo.Add(typeof(Int64)); //StckPrcConsTaxInclu
    //        //�d���l������Ŋz�i���Łj[�`�[]
    //        serInfo.MemberInfo.Add(typeof(Int64)); //StckDisTtlTaxInclu


    //        serInfo.Serialize(writer, serInfo);
    //        if (graph is SuppPrtPprStcTblRsltWork)
    //        {
    //            SuppPrtPprStcTblRsltWork temp = (SuppPrtPprStcTblRsltWork)graph;

    //            SetSuppPrtPprStcTblRsltWork(writer, temp);
    //        }
    //        else
    //        {
    //            ArrayList lst = null;
    //            if (graph is SuppPrtPprStcTblRsltWork[])
    //            {
    //                lst = new ArrayList();
    //                lst.AddRange((SuppPrtPprStcTblRsltWork[])graph);
    //            }
    //            else
    //            {
    //                lst = (ArrayList)graph;
    //            }

    //            foreach (SuppPrtPprStcTblRsltWork temp in lst)
    //            {
    //                SetSuppPrtPprStcTblRsltWork(writer, temp);
    //            }

    //        }


    //    }


    //    /// <summary>
    //    /// SuppPrtPprStcTblRsltWork�����o��(public�v���p�e�B��)
    //    /// </summary>
    //    private const int currentMemberCount = 45;

    //    /// <summary>
    //    ///  SuppPrtPprStcTblRsltWork�C���X�^���X��������
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprStcTblRsltWork�̃C���X�^���X����������</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    private void SetSuppPrtPprStcTblRsltWork(System.IO.BinaryWriter writer, SuppPrtPprStcTblRsltWork temp)
    //    {
    //        //�f�[�^�敪
    //        writer.Write(temp.DataDiv);
    //        //�`�[���t
    //        writer.Write((Int64)temp.StockDate.Ticks);
    //        //�`�[�ԍ�
    //        writer.Write(temp.PartySaleSlipNum);
    //        //�s��(���ו\��)
    //        writer.Write(temp.StockRowNo);
    //        //�d���`��
    //        writer.Write(temp.SupplierFormal);
    //        //�d���`�[�敪
    //        writer.Write(temp.SupplierSlipCd);
    //        //�S���Җ�
    //        writer.Write(temp.StockAgentName);
    //        //���z
    //        writer.Write(temp.StockTtlPricTaxExc);
    //        //�i��(���ו\��)
    //        writer.Write(temp.GoodsName);
    //        //�i��(���ו\��)
    //        writer.Write(temp.GoodsNo);
    //        //���[�J�[�R�[�h(���ו\��)
    //        writer.Write(temp.GoodsMakerCd);
    //        //���[�J�[����
    //        writer.Write(temp.MakerName);
    //        //BL�R�[�h(���ו\��)
    //        writer.Write(temp.BLGoodsCode);
    //        //BL�O���[�v(���ו\��)
    //        writer.Write(temp.BLGroupCode);
    //        //����(���ו\��)
    //        writer.Write(temp.StockCount);
    //        //�W�����i(���ו\��)
    //        writer.Write(temp.ListPriceTaxExcFl);
    //        //�I�[�v�����i�敪(���ו\��)
    //        writer.Write(temp.OpenPriceDiv);
    //        //�d�������œ]�ŕ����R�[�h
    //        writer.Write(temp.SuppCTaxLayCd);
    //        //�d�����z�v�i�ō��݁j
    //        writer.Write(temp.StockTtlPricTaxInc);
    //        //�d�����z����Ŋz
    //        writer.Write(temp.StockPriceConsTax);
    //        //���l�P
    //        writer.Write(temp.SupplierSlipNote1);
    //        //���l�Q
    //        writer.Write(temp.SupplierSlipNote2);
    //        //���_
    //        writer.Write(temp.SectionGuideNm);
    //        //���s��
    //        writer.Write(temp.StockInputName);
    //        //�d����R�[�h
    //        writer.Write(temp.SupplierCd);
    //        //�d���於
    //        writer.Write(temp.SupplierSnm);
    //        //�ݎ�(���ו\��)
    //        writer.Write(temp.StockOrderDivCd);
    //        //�q��(���ו\��)
    //        writer.Write(temp.WarehouseName);
    //        //�I��(���ו\��)
    //        writer.Write(temp.WarehouseShelfNo);
    //        //�t�n�d���}�[�N�P
    //        writer.Write(temp.UoeRemark1);
    //        //�t�n�d���}�[�N�Q
    //        writer.Write(temp.UoeRemark2);
    //        //�d��SEQ/�x����
    //        writer.Write(temp.SupplierSlipNo);
    //        //�v���
    //        writer.Write((Int64)temp.StockAddUpADate.Ticks);
    //        //���|�敪
    //        writer.Write(temp.AccPayDivCd);
    //        //�ԓ`�敪
    //        writer.Write(temp.DebitNoteDiv);
    //        //��������`�[�ԍ�(���ו\��)
    //        writer.Write(temp.SalesSlipNum);
    //        //����������t(���ו\��)
    //        writer.Write((Int64)temp.SalesDate.Ticks);
    //        //���Ӑ�R�[�h(���ו\��)
    //        writer.Write(temp.CustomerCode);
    //        //���Ӑ於(���ו\��)
    //        writer.Write(temp.CustomerSnm);
    //        //���_�R�[�h
    //        writer.Write(temp.SectionCode);
    //        //�q�ɃR�[�h
    //        writer.Write(temp.WarehouseCode);
    //        //�d���摍�z�\�����@�敪
    //        writer.Write(temp.SuppTtlAmntDspWayCd);
    //        //�ېŋ敪
    //        writer.Write(temp.TaxationCode);
    //        //�d�����z����Ŋz�i���Łj[�`�[]
    //        writer.Write(temp.StckPrcConsTaxInclu);
    //        //�d���l������Ŋz�i���Łj[�`�[]
    //        writer.Write(temp.StckDisTtlTaxInclu);

    //    }

    //    /// <summary>
    //    ///  SuppPrtPprStcTblRsltWork�C���X�^���X�擾
    //    /// </summary>
    //    /// <returns>SuppPrtPprStcTblRsltWork�N���X�̃C���X�^���X</returns>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprStcTblRsltWork�̃C���X�^���X���擾���܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    private SuppPrtPprStcTblRsltWork GetSuppPrtPprStcTblRsltWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
    //    {
    //        // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
    //        // serInfo.MemberInfo.Count < currentMemberCount
    //        // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

    //        SuppPrtPprStcTblRsltWork temp = new SuppPrtPprStcTblRsltWork();

    //        //�f�[�^�敪
    //        temp.DataDiv = reader.ReadInt32();
    //        //�`�[���t
    //        temp.StockDate = new DateTime(reader.ReadInt64());
    //        //�`�[�ԍ�
    //        temp.PartySaleSlipNum = reader.ReadString();
    //        //�s��(���ו\��)
    //        temp.StockRowNo = reader.ReadInt32();
    //        //�d���`��
    //        temp.SupplierFormal = reader.ReadInt32();
    //        //�d���`�[�敪
    //        temp.SupplierSlipCd = reader.ReadInt32();
    //        //�S���Җ�
    //        temp.StockAgentName = reader.ReadString();
    //        //���z
    //        temp.StockTtlPricTaxExc = reader.ReadInt64();
    //        //�i��(���ו\��)
    //        temp.GoodsName = reader.ReadString();
    //        //�i��(���ו\��)
    //        temp.GoodsNo = reader.ReadString();
    //        //���[�J�[�R�[�h(���ו\��)
    //        temp.GoodsMakerCd = reader.ReadInt32();
    //        //���[�J�[����
    //        temp.MakerName = reader.ReadString();
    //        //BL�R�[�h(���ו\��)
    //        temp.BLGoodsCode = reader.ReadInt32();
    //        //BL�O���[�v(���ו\��)
    //        temp.BLGroupCode = reader.ReadInt32();
    //        //����(���ו\��)
    //        temp.StockCount = reader.ReadDouble();
    //        //�W�����i(���ו\��)
    //        temp.ListPriceTaxExcFl = reader.ReadDouble();
    //        //�I�[�v�����i�敪(���ו\��)
    //        temp.OpenPriceDiv = reader.ReadInt32();
    //        //�d�������œ]�ŕ����R�[�h
    //        temp.SuppCTaxLayCd = reader.ReadInt32();
    //        //�d�����z�v�i�ō��݁j
    //        temp.StockTtlPricTaxInc = reader.ReadInt64();
    //        //�d�����z����Ŋz
    //        temp.StockPriceConsTax = reader.ReadInt64();
    //        //���l�P
    //        temp.SupplierSlipNote1 = reader.ReadString();
    //        //���l�Q
    //        temp.SupplierSlipNote2 = reader.ReadString();
    //        //���_
    //        temp.SectionGuideNm = reader.ReadString();
    //        //���s��
    //        temp.StockInputName = reader.ReadString();
    //        //�d����R�[�h
    //        temp.SupplierCd = reader.ReadInt32();
    //        //�d���於
    //        temp.SupplierSnm = reader.ReadString();
    //        //�ݎ�(���ו\��)
    //        temp.StockOrderDivCd = reader.ReadInt32();
    //        //�q��(���ו\��)
    //        temp.WarehouseName = reader.ReadString();
    //        //�I��(���ו\��)
    //        temp.WarehouseShelfNo = reader.ReadString();
    //        //�t�n�d���}�[�N�P
    //        temp.UoeRemark1 = reader.ReadString();
    //        //�t�n�d���}�[�N�Q
    //        temp.UoeRemark2 = reader.ReadString();
    //        //�d��SEQ/�x����
    //        temp.SupplierSlipNo = reader.ReadInt32();
    //        //�v���
    //        temp.StockAddUpADate = new DateTime(reader.ReadInt64());
    //        //���|�敪
    //        temp.AccPayDivCd = reader.ReadInt32();
    //        //�ԓ`�敪
    //        temp.DebitNoteDiv = reader.ReadInt32();
    //        //��������`�[�ԍ�(���ו\��)
    //        temp.SalesSlipNum = reader.ReadString();
    //        //����������t(���ו\��)
    //        temp.SalesDate = new DateTime(reader.ReadInt64());
    //        //���Ӑ�R�[�h(���ו\��)
    //        temp.CustomerCode = reader.ReadInt32();
    //        //���Ӑ於(���ו\��)
    //        temp.CustomerSnm = reader.ReadString();
    //        //���_�R�[�h
    //        temp.SectionCode = reader.ReadString();
    //        //�q�ɃR�[�h
    //        temp.WarehouseCode = reader.ReadString();
    //        //�d���摍�z�\�����@�敪
    //        temp.SuppTtlAmntDspWayCd = reader.ReadInt32();
    //        //�ېŋ敪
    //        temp.TaxationCode = reader.ReadInt32();
    //        //�d�����z����Ŋz�i���Łj[�`�[]
    //        temp.StckPrcConsTaxInclu = reader.ReadInt64();
    //        //�d���l������Ŋz�i���Łj[�`�[]
    //        temp.StckDisTtlTaxInclu = reader.ReadInt64();


    //        //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
    //        //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
    //        //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
    //        //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
    //        for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
    //        {
    //            //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
    //            //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
    //            //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
    //            //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
    //            int optCount = 0;
    //            object oMemberType = serInfo.MemberInfo[k];
    //            if (oMemberType is Type)
    //            {
    //                Type t = (Type)oMemberType;
    //                object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
    //                if (t.Equals(typeof(int)))
    //                {
    //                    optCount = Convert.ToInt32(oData);
    //                }
    //                else
    //                {
    //                    optCount = 0;
    //                }
    //            }
    //            else if (oMemberType is string)
    //            {
    //                Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
    //                object userData = formatter.Deserialize(reader);  //�ǂݔ�΂�
    //            }
    //        }
    //        return temp;
    //    }

    //    /// <summary>
    //    ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
    //    /// </summary>
    //    /// <returns>SuppPrtPprStcTblRsltWork�N���X�̃C���X�^���X(object)</returns>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprStcTblRsltWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public object Deserialize(System.IO.BinaryReader reader)
    //    {
    //        object retValue = null;
    //        Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
    //        ArrayList lst = new ArrayList();
    //        for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
    //        {
    //            SuppPrtPprStcTblRsltWork temp = GetSuppPrtPprStcTblRsltWork(reader, serInfo);
    //            lst.Add(temp);
    //        }
    //        switch (serInfo.RetTypeInfo)
    //        {
    //            case 0:
    //                retValue = lst;
    //                break;
    //            case 1:
    //                retValue = lst[0];
    //                break;
    //            case 2:
    //                retValue = (SuppPrtPprStcTblRsltWork[])lst.ToArray(typeof(SuppPrtPprStcTblRsltWork));
    //                break;
    //        }
    //        return retValue;
    //    }

    //    #endregion
    //}
    # endregion
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/19 DEL
    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/25 DEL
    # region // DEL
    ///// public class name:   SuppPrtPprStcTblRsltWork
    ///// <summary>
    /////                      �d����d�q�������o����(�`�[�E����)�N���X���[�N
    ///// </summary>
    ///// <remarks>
    ///// <br>note             :   �d����d�q�������o����(�`�[�E����)�N���X���[�N�w�b�_�t�@�C��</br>
    ///// <br>Programmer       :   ��������</br>
    ///// <br>Date             :   </br>
    ///// <br>Genarated Date   :   2009/02/19  (CSharp File Generated Date)</br>
    ///// <br>Update Note      :   </br>
    ///// </remarks>
    //[Serializable]
    //[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    //public class SuppPrtPprStcTblRsltWork
    //{
    //    /// <summary>�f�[�^�敪</summary>
    //    /// <remarks>0:�d���f�[�^ 1:�x���f�[�^</remarks>
    //    private Int32 _dataDiv;

    //    /// <summary>�`�[���t</summary>
    //    /// <remarks>�d����(YYYYMMDD)/�x�����t</remarks>
    //    private DateTime _stockDate;

    //    /// <summary>�`�[�ԍ�</summary>
    //    /// <remarks>�����`�[�ԍ�</remarks>
    //    private string _partySaleSlipNum = "";

    //    /// <summary>�s��(���ו\��)</summary>
    //    /// <remarks>�d���s�ԍ�/�����s�ԍ�</remarks>
    //    private Int32 _stockRowNo;

    //    /// <summary>�d���`��</summary>
    //    /// <remarks>0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j</remarks>
    //    private Int32 _supplierFormal;

    //    /// <summary>�d���`�[�敪</summary>
    //    /// <remarks>10:�d��,20:�ԕi</remarks>
    //    private Int32 _supplierSlipCd;

    //    /// <summary>�S���Җ�</summary>
    //    /// <remarks>�d���S���Җ���/�x���S���Җ�</remarks>
    //    private string _stockAgentName = "";

    //    /// <summary>���z</summary>
    //    /// <remarks>�d�����z�v�i�Ŕ����j/�x�����z</remarks>
    //    private Int64 _stockTtlPricTaxExc;

    //    /// <summary>�i��(���ו\��)</summary>
    //    /// <remarks>���i����/���햼��</remarks>
    //    private string _goodsName = "";

    //    /// <summary>�i��(���ו\��)</summary>
    //    /// <remarks>���i�ԍ�</remarks>
    //    private string _goodsNo = "";

    //    /// <summary>���[�J�[�R�[�h(���ו\��)</summary>
    //    /// <remarks>���i���[�J�[�R�[�h</remarks>
    //    private Int32 _goodsMakerCd;

    //    /// <summary>���[�J�[����</summary>
    //    /// <remarks>���[�J�[����</remarks>
    //    private string _makerName = "";

    //    /// <summary>BL�R�[�h(���ו\��)</summary>
    //    /// <remarks>BL���i�R�[�h</remarks>
    //    private Int32 _bLGoodsCode;

    //    /// <summary>BL�O���[�v(���ו\��)</summary>
    //    /// <remarks>BL�O���[�v�R�[�h</remarks>
    //    private Int32 _bLGroupCode;

    //    /// <summary>����(���ו\��)</summary>
    //    /// <remarks>�d����</remarks>
    //    private Double _stockCount;

    //    /// <summary>�W�����i(���ו\��)</summary>
    //    /// <remarks>�艿�i�Ŕ��C�����j</remarks>
    //    private Double _listPriceTaxExcFl;

    //    /// <summary>�I�[�v�����i�敪(���ו\��)</summary>
    //    /// <remarks>0:�ʏ�^1:�I�[�v�����i</remarks>
    //    private Int32 _openPriceDiv;

    //    /// <summary>�d�������œ]�ŕ����R�[�h</summary>
    //    /// <remarks>0:�`�[�P��1:���גP��2:�x���e 3:�x���q 9:��ې�</remarks>
    //    private Int32 _suppCTaxLayCd;

    //    /// <summary>�d�����z�v�i�ō��݁j</summary>
    //    /// <remarks>���x�����z�̂���</remarks>
    //    private Int64 _stockTtlPricTaxInc;

    //    /// <summary>�d�����z����Ŋz</summary>
    //    private Int64 _stockPriceConsTax;

    //    /// <summary>���l�P</summary>
    //    /// <remarks>�d���`�[���l1/�`�[�E�v</remarks>
    //    private string _supplierSlipNote1 = "";

    //    /// <summary>���l�Q</summary>
    //    /// <remarks>�d���`�[���l2/�L������</remarks>
    //    private string _supplierSlipNote2 = "";

    //    /// <summary>���_</summary>
    //    /// <remarks>���_�K�C�h����/�v�㋒�_�R�[�h</remarks>
    //    private string _sectionGuideNm = "";

    //    /// <summary>���s��</summary>
    //    /// <remarks>�d�����͎Җ���/�x�����͎Җ���</remarks>
    //    private string _stockInputName = "";

    //    /// <summary>�d����R�[�h</summary>
    //    /// <remarks>�d����R�[�h/�d����R�[�h</remarks>
    //    private Int32 _supplierCd;

    //    /// <summary>�d���於</summary>
    //    /// <remarks>�d���旪��/�d���旪��</remarks>
    //    private string _supplierSnm = "";

    //    /// <summary>�ݎ�(���ו\��)</summary>
    //    /// <remarks>�d���݌Ɏ�񂹋敪(0:��񂹁C1:�݌�)</remarks>
    //    private Int32 _stockOrderDivCd;

    //    /// <summary>�q��(���ו\��)</summary>
    //    /// <remarks>�q�ɖ���</remarks>
    //    private string _warehouseName = "";

    //    /// <summary>�I��(���ו\��)</summary>
    //    /// <remarks>�q�ɒI��</remarks>
    //    private string _warehouseShelfNo = "";

    //    /// <summary>�t�n�d���}�[�N�P</summary>
    //    /// <remarks>�t�n�d���}�[�N�P</remarks>
    //    private string _uoeRemark1 = "";

    //    /// <summary>�t�n�d���}�[�N�Q</summary>
    //    /// <remarks>�t�n�d���}�[�N�Q</remarks>
    //    private string _uoeRemark2 = "";

    //    /// <summary>�d��SEQ/�x����</summary>
    //    /// <remarks>�d���`�[�ԍ�/�x���`�[�ԍ�</remarks>
    //    private Int32 _supplierSlipNo;

    //    /// <summary>�v���</summary>
    //    /// <remarks>�d���v����t(YYYYMMDD)/�v����t(YYYYMMDD)</remarks>
    //    private DateTime _stockAddUpADate;

    //    /// <summary>���|�敪</summary>
    //    /// <remarks>���|�敪(0:���|�Ȃ�,1:���|)</remarks>
    //    private Int32 _accPayDivCd;

    //    /// <summary>�ԓ`�敪</summary>
    //    /// <remarks>0:���`,1:�ԓ`,2:����</remarks>
    //    private Int32 _debitNoteDiv;

    //    /// <summary>��������`�[�ԍ�(���ו\��)</summary>
    //    /// <remarks>����`�[�ԍ�</remarks>
    //    private string _salesSlipNum = "";

    //    /// <summary>����������t(���ו\��)</summary>
    //    /// <remarks>������t</remarks>
    //    private DateTime _salesDate;

    //    /// <summary>���Ӑ�R�[�h(���ו\��)</summary>
    //    /// <remarks>���Ӑ�R�[�h</remarks>
    //    private Int32 _customerCode;

    //    /// <summary>���Ӑ於(���ו\��)</summary>
    //    /// <remarks>���Ӑ旪��</remarks>
    //    private string _customerSnm = "";

    //    /// <summary>���_�R�[�h</summary>
    //    /// <remarks>���_�R�[�h</remarks>
    //    private string _sectionCode = "";

    //    /// <summary>�q�ɃR�[�h</summary>
    //    /// <remarks>�q�ɃR�[�h</remarks>
    //    private string _warehouseCode = "";

    //    /// <summary>�d���摍�z�\�����@�敪</summary>
    //    /// <remarks>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</remarks>
    //    private Int32 _suppTtlAmntDspWayCd;

    //    /// <summary>�ېŋ敪</summary>
    //    /// <remarks>0:�ې�,1:��ې�,2:�ېŁi���Łj</remarks>
    //    private Int32 _taxationCode;

    //    /// <summary>�d�����z����Ŋz�i���Łj[�`�[]</summary>
    //    /// <remarks>�l���O�̓��ŏ��i�̏����</remarks>
    //    private Int64 _stckPrcConsTaxInclu;

    //    /// <summary>�d���l������Ŋz�i���Łj[�`�[]</summary>
    //    /// <remarks>���ŏ��i�l���̏���Ŋz</remarks>
    //    private Int64 _stckDisTtlTaxInclu;

    //    /// <summary>�d���P���i�Ŕ��C�����j[���ו\��]</summary>
    //    /// <remarks>�Ŕ���</remarks>
    //    private Double _stockUnitPriceFl;


    //    /// public propaty name  :  DataDiv
    //    /// <summary>�f�[�^�敪�v���p�e�B</summary>
    //    /// <value>0:�d���f�[�^ 1:�x���f�[�^</value>
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

    //    /// public propaty name  :  StockDate
    //    /// <summary>�`�[���t�v���p�e�B</summary>
    //    /// <value>�d����(YYYYMMDD)/�x�����t</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �`�[���t�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public DateTime StockDate
    //    {
    //        get { return _stockDate; }
    //        set { _stockDate = value; }
    //    }

    //    /// public propaty name  :  PartySaleSlipNum
    //    /// <summary>�`�[�ԍ��v���p�e�B</summary>
    //    /// <value>�����`�[�ԍ�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �`�[�ԍ��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string PartySaleSlipNum
    //    {
    //        get { return _partySaleSlipNum; }
    //        set { _partySaleSlipNum = value; }
    //    }

    //    /// public propaty name  :  StockRowNo
    //    /// <summary>�s��(���ו\��)�v���p�e�B</summary>
    //    /// <value>�d���s�ԍ�/�����s�ԍ�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �s��(���ו\��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 StockRowNo
    //    {
    //        get { return _stockRowNo; }
    //        set { _stockRowNo = value; }
    //    }

    //    /// public propaty name  :  SupplierFormal
    //    /// <summary>�d���`���v���p�e�B</summary>
    //    /// <value>0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �d���`���v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 SupplierFormal
    //    {
    //        get { return _supplierFormal; }
    //        set { _supplierFormal = value; }
    //    }

    //    /// public propaty name  :  SupplierSlipCd
    //    /// <summary>�d���`�[�敪�v���p�e�B</summary>
    //    /// <value>10:�d��,20:�ԕi</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �d���`�[�敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 SupplierSlipCd
    //    {
    //        get { return _supplierSlipCd; }
    //        set { _supplierSlipCd = value; }
    //    }

    //    /// public propaty name  :  StockAgentName
    //    /// <summary>�S���Җ��v���p�e�B</summary>
    //    /// <value>�d���S���Җ���/�x���S���Җ�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �S���Җ��v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string StockAgentName
    //    {
    //        get { return _stockAgentName; }
    //        set { _stockAgentName = value; }
    //    }

    //    /// public propaty name  :  StockTtlPricTaxExc
    //    /// <summary>���z�v���p�e�B</summary>
    //    /// <value>�d�����z�v�i�Ŕ����j/�x�����z</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���z�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 StockTtlPricTaxExc
    //    {
    //        get { return _stockTtlPricTaxExc; }
    //        set { _stockTtlPricTaxExc = value; }
    //    }

    //    /// public propaty name  :  GoodsName
    //    /// <summary>�i��(���ו\��)�v���p�e�B</summary>
    //    /// <value>���i����/���햼��</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �i��(���ו\��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string GoodsName
    //    {
    //        get { return _goodsName; }
    //        set { _goodsName = value; }
    //    }

    //    /// public propaty name  :  GoodsNo
    //    /// <summary>�i��(���ו\��)�v���p�e�B</summary>
    //    /// <value>���i�ԍ�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �i��(���ו\��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string GoodsNo
    //    {
    //        get { return _goodsNo; }
    //        set { _goodsNo = value; }
    //    }

    //    /// public propaty name  :  GoodsMakerCd
    //    /// <summary>���[�J�[�R�[�h(���ו\��)�v���p�e�B</summary>
    //    /// <value>���i���[�J�[�R�[�h</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���[�J�[�R�[�h(���ו\��)�v���p�e�B</br>
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

    //    /// public propaty name  :  BLGoodsCode
    //    /// <summary>BL�R�[�h(���ו\��)�v���p�e�B</summary>
    //    /// <value>BL���i�R�[�h</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   BL�R�[�h(���ו\��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 BLGoodsCode
    //    {
    //        get { return _bLGoodsCode; }
    //        set { _bLGoodsCode = value; }
    //    }

    //    /// public propaty name  :  BLGroupCode
    //    /// <summary>BL�O���[�v(���ו\��)�v���p�e�B</summary>
    //    /// <value>BL�O���[�v�R�[�h</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   BL�O���[�v(���ו\��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 BLGroupCode
    //    {
    //        get { return _bLGroupCode; }
    //        set { _bLGroupCode = value; }
    //    }

    //    /// public propaty name  :  StockCount
    //    /// <summary>����(���ו\��)�v���p�e�B</summary>
    //    /// <value>�d����</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����(���ו\��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Double StockCount
    //    {
    //        get { return _stockCount; }
    //        set { _stockCount = value; }
    //    }

    //    /// public propaty name  :  ListPriceTaxExcFl
    //    /// <summary>�W�����i(���ו\��)�v���p�e�B</summary>
    //    /// <value>�艿�i�Ŕ��C�����j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �W�����i(���ו\��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Double ListPriceTaxExcFl
    //    {
    //        get { return _listPriceTaxExcFl; }
    //        set { _listPriceTaxExcFl = value; }
    //    }

    //    /// public propaty name  :  OpenPriceDiv
    //    /// <summary>�I�[�v�����i�敪(���ו\��)�v���p�e�B</summary>
    //    /// <value>0:�ʏ�^1:�I�[�v�����i</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �I�[�v�����i�敪(���ו\��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 OpenPriceDiv
    //    {
    //        get { return _openPriceDiv; }
    //        set { _openPriceDiv = value; }
    //    }

    //    /// public propaty name  :  SuppCTaxLayCd
    //    /// <summary>�d�������œ]�ŕ����R�[�h�v���p�e�B</summary>
    //    /// <value>0:�`�[�P��1:���גP��2:�x���e 3:�x���q 9:��ې�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �d�������œ]�ŕ����R�[�h�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 SuppCTaxLayCd
    //    {
    //        get { return _suppCTaxLayCd; }
    //        set { _suppCTaxLayCd = value; }
    //    }

    //    /// public propaty name  :  StockTtlPricTaxInc
    //    /// <summary>�d�����z�v�i�ō��݁j�v���p�e�B</summary>
    //    /// <value>���x�����z�̂���</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �d�����z�v�i�ō��݁j�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 StockTtlPricTaxInc
    //    {
    //        get { return _stockTtlPricTaxInc; }
    //        set { _stockTtlPricTaxInc = value; }
    //    }

    //    /// public propaty name  :  StockPriceConsTax
    //    /// <summary>�d�����z����Ŋz�v���p�e�B</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �d�����z����Ŋz�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 StockPriceConsTax
    //    {
    //        get { return _stockPriceConsTax; }
    //        set { _stockPriceConsTax = value; }
    //    }

    //    /// public propaty name  :  SupplierSlipNote1
    //    /// <summary>���l�P�v���p�e�B</summary>
    //    /// <value>�d���`�[���l1/�`�[�E�v</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���l�P�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SupplierSlipNote1
    //    {
    //        get { return _supplierSlipNote1; }
    //        set { _supplierSlipNote1 = value; }
    //    }

    //    /// public propaty name  :  SupplierSlipNote2
    //    /// <summary>���l�Q�v���p�e�B</summary>
    //    /// <value>�d���`�[���l2/�L������</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���l�Q�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SupplierSlipNote2
    //    {
    //        get { return _supplierSlipNote2; }
    //        set { _supplierSlipNote2 = value; }
    //    }

    //    /// public propaty name  :  SectionGuideNm
    //    /// <summary>���_�v���p�e�B</summary>
    //    /// <value>���_�K�C�h����/�v�㋒�_�R�[�h</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���_�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SectionGuideNm
    //    {
    //        get { return _sectionGuideNm; }
    //        set { _sectionGuideNm = value; }
    //    }

    //    /// public propaty name  :  StockInputName
    //    /// <summary>���s�҃v���p�e�B</summary>
    //    /// <value>�d�����͎Җ���/�x�����͎Җ���</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���s�҃v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string StockInputName
    //    {
    //        get { return _stockInputName; }
    //        set { _stockInputName = value; }
    //    }

    //    /// public propaty name  :  SupplierCd
    //    /// <summary>�d����R�[�h�v���p�e�B</summary>
    //    /// <value>�d����R�[�h/�d����R�[�h</value>
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
    //    /// <summary>�d���於�v���p�e�B</summary>
    //    /// <value>�d���旪��/�d���旪��</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �d���於�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SupplierSnm
    //    {
    //        get { return _supplierSnm; }
    //        set { _supplierSnm = value; }
    //    }

    //    /// public propaty name  :  StockOrderDivCd
    //    /// <summary>�ݎ�(���ו\��)�v���p�e�B</summary>
    //    /// <value>�d���݌Ɏ�񂹋敪(0:��񂹁C1:�݌�)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �ݎ�(���ו\��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 StockOrderDivCd
    //    {
    //        get { return _stockOrderDivCd; }
    //        set { _stockOrderDivCd = value; }
    //    }

    //    /// public propaty name  :  WarehouseName
    //    /// <summary>�q��(���ו\��)�v���p�e�B</summary>
    //    /// <value>�q�ɖ���</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �q��(���ו\��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string WarehouseName
    //    {
    //        get { return _warehouseName; }
    //        set { _warehouseName = value; }
    //    }

    //    /// public propaty name  :  WarehouseShelfNo
    //    /// <summary>�I��(���ו\��)�v���p�e�B</summary>
    //    /// <value>�q�ɒI��</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �I��(���ו\��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string WarehouseShelfNo
    //    {
    //        get { return _warehouseShelfNo; }
    //        set { _warehouseShelfNo = value; }
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

    //    /// public propaty name  :  SupplierSlipNo
    //    /// <summary>�d��SEQ/�x�����v���p�e�B</summary>
    //    /// <value>�d���`�[�ԍ�/�x���`�[�ԍ�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �d��SEQ/�x�����v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 SupplierSlipNo
    //    {
    //        get { return _supplierSlipNo; }
    //        set { _supplierSlipNo = value; }
    //    }

    //    /// public propaty name  :  StockAddUpADate
    //    /// <summary>�v����v���p�e�B</summary>
    //    /// <value>�d���v����t(YYYYMMDD)/�v����t(YYYYMMDD)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �v����v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public DateTime StockAddUpADate
    //    {
    //        get { return _stockAddUpADate; }
    //        set { _stockAddUpADate = value; }
    //    }

    //    /// public propaty name  :  AccPayDivCd
    //    /// <summary>���|�敪�v���p�e�B</summary>
    //    /// <value>���|�敪(0:���|�Ȃ�,1:���|)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���|�敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 AccPayDivCd
    //    {
    //        get { return _accPayDivCd; }
    //        set { _accPayDivCd = value; }
    //    }

    //    /// public propaty name  :  DebitNoteDiv
    //    /// <summary>�ԓ`�敪�v���p�e�B</summary>
    //    /// <value>0:���`,1:�ԓ`,2:����</value>
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

    //    /// public propaty name  :  SalesSlipNum
    //    /// <summary>��������`�[�ԍ�(���ו\��)�v���p�e�B</summary>
    //    /// <value>����`�[�ԍ�</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ��������`�[�ԍ�(���ו\��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string SalesSlipNum
    //    {
    //        get { return _salesSlipNum; }
    //        set { _salesSlipNum = value; }
    //    }

    //    /// public propaty name  :  SalesDate
    //    /// <summary>����������t(���ו\��)�v���p�e�B</summary>
    //    /// <value>������t</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����������t(���ו\��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public DateTime SalesDate
    //    {
    //        get { return _salesDate; }
    //        set { _salesDate = value; }
    //    }

    //    /// public propaty name  :  CustomerCode
    //    /// <summary>���Ӑ�R�[�h(���ו\��)�v���p�e�B</summary>
    //    /// <value>���Ӑ�R�[�h</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���Ӑ�R�[�h(���ו\��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 CustomerCode
    //    {
    //        get { return _customerCode; }
    //        set { _customerCode = value; }
    //    }

    //    /// public propaty name  :  CustomerSnm
    //    /// <summary>���Ӑ於(���ו\��)�v���p�e�B</summary>
    //    /// <value>���Ӑ旪��</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���Ӑ於(���ו\��)�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public string CustomerSnm
    //    {
    //        get { return _customerSnm; }
    //        set { _customerSnm = value; }
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

    //    /// public propaty name  :  SuppTtlAmntDspWayCd
    //    /// <summary>�d���摍�z�\�����@�敪�v���p�e�B</summary>
    //    /// <value>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �d���摍�z�\�����@�敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 SuppTtlAmntDspWayCd
    //    {
    //        get { return _suppTtlAmntDspWayCd; }
    //        set { _suppTtlAmntDspWayCd = value; }
    //    }

    //    /// public propaty name  :  TaxationCode
    //    /// <summary>�ېŋ敪�v���p�e�B</summary>
    //    /// <value>0:�ې�,1:��ې�,2:�ېŁi���Łj</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �ېŋ敪�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 TaxationCode
    //    {
    //        get { return _taxationCode; }
    //        set { _taxationCode = value; }
    //    }

    //    /// public propaty name  :  StckPrcConsTaxInclu
    //    /// <summary>�d�����z����Ŋz�i���Łj[�`�[]�v���p�e�B</summary>
    //    /// <value>�l���O�̓��ŏ��i�̏����</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �d�����z����Ŋz�i���Łj[�`�[]�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 StckPrcConsTaxInclu
    //    {
    //        get { return _stckPrcConsTaxInclu; }
    //        set { _stckPrcConsTaxInclu = value; }
    //    }

    //    /// public propaty name  :  StckDisTtlTaxInclu
    //    /// <summary>�d���l������Ŋz�i���Łj[�`�[]�v���p�e�B</summary>
    //    /// <value>���ŏ��i�l���̏���Ŋz</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �d���l������Ŋz�i���Łj[�`�[]�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 StckDisTtlTaxInclu
    //    {
    //        get { return _stckDisTtlTaxInclu; }
    //        set { _stckDisTtlTaxInclu = value; }
    //    }

    //    /// public propaty name  :  StockUnitPriceFl
    //    /// <summary>�d���P���i�Ŕ��C�����j[���ו\��]�v���p�e�B</summary>
    //    /// <value>�Ŕ���</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �d���P���i�Ŕ��C�����j[���ו\��]�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Double StockUnitPriceFl
    //    {
    //        get { return _stockUnitPriceFl; }
    //        set { _stockUnitPriceFl = value; }
    //    }


    //    /// <summary>
    //    /// �d����d�q�������o����(�`�[�E����)�N���X���[�N�R���X�g���N�^
    //    /// </summary>
    //    /// <returns>SuppPrtPprStcTblRsltWork�N���X�̃C���X�^���X</returns>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprStcTblRsltWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public SuppPrtPprStcTblRsltWork()
    //    {
    //    }
    //}

    ///// <summary>
    /////  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    ///// </summary>
    ///// <returns>SuppPrtPprStcTblRsltWork�N���X�̃C���X�^���X(object)</returns>
    ///// <remarks>
    ///// <br>Note�@�@�@�@�@�@ :   SuppPrtPprStcTblRsltWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    ///// <br>Programer        :   ��������</br>
    ///// </remarks>
    //public class SuppPrtPprStcTblRsltWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    //{
    //    #region ICustomSerializationSurrogate �����o

    //    /// <summary>
    //    ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprStcTblRsltWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public void Serialize( System.IO.BinaryWriter writer, object graph )
    //    {
    //        // TODO:  SuppPrtPprStcTblRsltWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
    //        if ( writer == null )
    //            throw new ArgumentNullException();

    //        if ( graph != null && !(graph is SuppPrtPprStcTblRsltWork || graph is ArrayList || graph is SuppPrtPprStcTblRsltWork[]) )
    //            throw new ArgumentException( string.Format( "graph��{0}�̃C���X�^���X�ł���܂���", typeof( SuppPrtPprStcTblRsltWork ).FullName ) );

    //        if ( graph != null && graph is SuppPrtPprStcTblRsltWork )
    //        {
    //            Type t = graph.GetType();
    //            if ( !CustomFormatterServices.NeedCustomSerialization( t ) )
    //                throw new ArgumentException( string.Format( "graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName ) );
    //        }

    //        //SerializationTypeInfo
    //        Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SuppPrtPprStcTblRsltWork" );

    //        //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
    //        int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
    //        if ( graph is ArrayList )
    //        {
    //            serInfo.RetTypeInfo = 0;
    //            occurrence = ((ArrayList)graph).Count;
    //        }
    //        else if ( graph is SuppPrtPprStcTblRsltWork[] )
    //        {
    //            serInfo.RetTypeInfo = 2;
    //            occurrence = ((SuppPrtPprStcTblRsltWork[])graph).Length;
    //        }
    //        else if ( graph is SuppPrtPprStcTblRsltWork )
    //        {
    //            serInfo.RetTypeInfo = 1;
    //            occurrence = 1;
    //        }

    //        serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

    //        //�f�[�^�敪
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //DataDiv
    //        //�`�[���t
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //StockDate
    //        //�`�[�ԍ�
    //        serInfo.MemberInfo.Add( typeof( string ) ); //PartySaleSlipNum
    //        //�s��(���ו\��)
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //StockRowNo
    //        //�d���`��
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //SupplierFormal
    //        //�d���`�[�敪
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //SupplierSlipCd
    //        //�S���Җ�
    //        serInfo.MemberInfo.Add( typeof( string ) ); //StockAgentName
    //        //���z
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //StockTtlPricTaxExc
    //        //�i��(���ו\��)
    //        serInfo.MemberInfo.Add( typeof( string ) ); //GoodsName
    //        //�i��(���ו\��)
    //        serInfo.MemberInfo.Add( typeof( string ) ); //GoodsNo
    //        //���[�J�[�R�[�h(���ו\��)
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //GoodsMakerCd
    //        //���[�J�[����
    //        serInfo.MemberInfo.Add( typeof( string ) ); //MakerName
    //        //BL�R�[�h(���ו\��)
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //BLGoodsCode
    //        //BL�O���[�v(���ו\��)
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //BLGroupCode
    //        //����(���ו\��)
    //        serInfo.MemberInfo.Add( typeof( Double ) ); //StockCount
    //        //�W�����i(���ו\��)
    //        serInfo.MemberInfo.Add( typeof( Double ) ); //ListPriceTaxExcFl
    //        //�I�[�v�����i�敪(���ו\��)
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //OpenPriceDiv
    //        //�d�������œ]�ŕ����R�[�h
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //SuppCTaxLayCd
    //        //�d�����z�v�i�ō��݁j
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //StockTtlPricTaxInc
    //        //�d�����z����Ŋz
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //StockPriceConsTax
    //        //���l�P
    //        serInfo.MemberInfo.Add( typeof( string ) ); //SupplierSlipNote1
    //        //���l�Q
    //        serInfo.MemberInfo.Add( typeof( string ) ); //SupplierSlipNote2
    //        //���_
    //        serInfo.MemberInfo.Add( typeof( string ) ); //SectionGuideNm
    //        //���s��
    //        serInfo.MemberInfo.Add( typeof( string ) ); //StockInputName
    //        //�d����R�[�h
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //SupplierCd
    //        //�d���於
    //        serInfo.MemberInfo.Add( typeof( string ) ); //SupplierSnm
    //        //�ݎ�(���ו\��)
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //StockOrderDivCd
    //        //�q��(���ו\��)
    //        serInfo.MemberInfo.Add( typeof( string ) ); //WarehouseName
    //        //�I��(���ו\��)
    //        serInfo.MemberInfo.Add( typeof( string ) ); //WarehouseShelfNo
    //        //�t�n�d���}�[�N�P
    //        serInfo.MemberInfo.Add( typeof( string ) ); //UoeRemark1
    //        //�t�n�d���}�[�N�Q
    //        serInfo.MemberInfo.Add( typeof( string ) ); //UoeRemark2
    //        //�d��SEQ/�x����
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //SupplierSlipNo
    //        //�v���
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //StockAddUpADate
    //        //���|�敪
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //AccPayDivCd
    //        //�ԓ`�敪
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //DebitNoteDiv
    //        //��������`�[�ԍ�(���ו\��)
    //        serInfo.MemberInfo.Add( typeof( string ) ); //SalesSlipNum
    //        //����������t(���ו\��)
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //SalesDate
    //        //���Ӑ�R�[�h(���ו\��)
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //CustomerCode
    //        //���Ӑ於(���ו\��)
    //        serInfo.MemberInfo.Add( typeof( string ) ); //CustomerSnm
    //        //���_�R�[�h
    //        serInfo.MemberInfo.Add( typeof( string ) ); //SectionCode
    //        //�q�ɃR�[�h
    //        serInfo.MemberInfo.Add( typeof( string ) ); //WarehouseCode
    //        //�d���摍�z�\�����@�敪
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //SuppTtlAmntDspWayCd
    //        //�ېŋ敪
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //TaxationCode
    //        //�d�����z����Ŋz�i���Łj[�`�[]
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //StckPrcConsTaxInclu
    //        //�d���l������Ŋz�i���Łj[�`�[]
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //StckDisTtlTaxInclu
    //        //�d���P���i�Ŕ��C�����j[���ו\��]
    //        serInfo.MemberInfo.Add( typeof( Double ) ); //StockUnitPriceFl


    //        serInfo.Serialize( writer, serInfo );
    //        if ( graph is SuppPrtPprStcTblRsltWork )
    //        {
    //            SuppPrtPprStcTblRsltWork temp = (SuppPrtPprStcTblRsltWork)graph;

    //            SetSuppPrtPprStcTblRsltWork( writer, temp );
    //        }
    //        else
    //        {
    //            ArrayList lst = null;
    //            if ( graph is SuppPrtPprStcTblRsltWork[] )
    //            {
    //                lst = new ArrayList();
    //                lst.AddRange( (SuppPrtPprStcTblRsltWork[])graph );
    //            }
    //            else
    //            {
    //                lst = (ArrayList)graph;
    //            }

    //            foreach ( SuppPrtPprStcTblRsltWork temp in lst )
    //            {
    //                SetSuppPrtPprStcTblRsltWork( writer, temp );
    //            }

    //        }


    //    }


    //    /// <summary>
    //    /// SuppPrtPprStcTblRsltWork�����o��(public�v���p�e�B��)
    //    /// </summary>
    //    private const int currentMemberCount = 46;

    //    /// <summary>
    //    ///  SuppPrtPprStcTblRsltWork�C���X�^���X��������
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprStcTblRsltWork�̃C���X�^���X����������</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    private void SetSuppPrtPprStcTblRsltWork( System.IO.BinaryWriter writer, SuppPrtPprStcTblRsltWork temp )
    //    {
    //        //�f�[�^�敪
    //        writer.Write( temp.DataDiv );
    //        //�`�[���t
    //        writer.Write( (Int64)temp.StockDate.Ticks );
    //        //�`�[�ԍ�
    //        writer.Write( temp.PartySaleSlipNum );
    //        //�s��(���ו\��)
    //        writer.Write( temp.StockRowNo );
    //        //�d���`��
    //        writer.Write( temp.SupplierFormal );
    //        //�d���`�[�敪
    //        writer.Write( temp.SupplierSlipCd );
    //        //�S���Җ�
    //        writer.Write( temp.StockAgentName );
    //        //���z
    //        writer.Write( temp.StockTtlPricTaxExc );
    //        //�i��(���ו\��)
    //        writer.Write( temp.GoodsName );
    //        //�i��(���ו\��)
    //        writer.Write( temp.GoodsNo );
    //        //���[�J�[�R�[�h(���ו\��)
    //        writer.Write( temp.GoodsMakerCd );
    //        //���[�J�[����
    //        writer.Write( temp.MakerName );
    //        //BL�R�[�h(���ו\��)
    //        writer.Write( temp.BLGoodsCode );
    //        //BL�O���[�v(���ו\��)
    //        writer.Write( temp.BLGroupCode );
    //        //����(���ו\��)
    //        writer.Write( temp.StockCount );
    //        //�W�����i(���ו\��)
    //        writer.Write( temp.ListPriceTaxExcFl );
    //        //�I�[�v�����i�敪(���ו\��)
    //        writer.Write( temp.OpenPriceDiv );
    //        //�d�������œ]�ŕ����R�[�h
    //        writer.Write( temp.SuppCTaxLayCd );
    //        //�d�����z�v�i�ō��݁j
    //        writer.Write( temp.StockTtlPricTaxInc );
    //        //�d�����z����Ŋz
    //        writer.Write( temp.StockPriceConsTax );
    //        //���l�P
    //        writer.Write( temp.SupplierSlipNote1 );
    //        //���l�Q
    //        writer.Write( temp.SupplierSlipNote2 );
    //        //���_
    //        writer.Write( temp.SectionGuideNm );
    //        //���s��
    //        writer.Write( temp.StockInputName );
    //        //�d����R�[�h
    //        writer.Write( temp.SupplierCd );
    //        //�d���於
    //        writer.Write( temp.SupplierSnm );
    //        //�ݎ�(���ו\��)
    //        writer.Write( temp.StockOrderDivCd );
    //        //�q��(���ו\��)
    //        writer.Write( temp.WarehouseName );
    //        //�I��(���ו\��)
    //        writer.Write( temp.WarehouseShelfNo );
    //        //�t�n�d���}�[�N�P
    //        writer.Write( temp.UoeRemark1 );
    //        //�t�n�d���}�[�N�Q
    //        writer.Write( temp.UoeRemark2 );
    //        //�d��SEQ/�x����
    //        writer.Write( temp.SupplierSlipNo );
    //        //�v���
    //        writer.Write( (Int64)temp.StockAddUpADate.Ticks );
    //        //���|�敪
    //        writer.Write( temp.AccPayDivCd );
    //        //�ԓ`�敪
    //        writer.Write( temp.DebitNoteDiv );
    //        //��������`�[�ԍ�(���ו\��)
    //        writer.Write( temp.SalesSlipNum );
    //        //����������t(���ו\��)
    //        writer.Write( (Int64)temp.SalesDate.Ticks );
    //        //���Ӑ�R�[�h(���ו\��)
    //        writer.Write( temp.CustomerCode );
    //        //���Ӑ於(���ו\��)
    //        writer.Write( temp.CustomerSnm );
    //        //���_�R�[�h
    //        writer.Write( temp.SectionCode );
    //        //�q�ɃR�[�h
    //        writer.Write( temp.WarehouseCode );
    //        //�d���摍�z�\�����@�敪
    //        writer.Write( temp.SuppTtlAmntDspWayCd );
    //        //�ېŋ敪
    //        writer.Write( temp.TaxationCode );
    //        //�d�����z����Ŋz�i���Łj[�`�[]
    //        writer.Write( temp.StckPrcConsTaxInclu );
    //        //�d���l������Ŋz�i���Łj[�`�[]
    //        writer.Write( temp.StckDisTtlTaxInclu );
    //        //�d���P���i�Ŕ��C�����j[���ו\��]
    //        writer.Write( temp.StockUnitPriceFl );

    //    }

    //    /// <summary>
    //    ///  SuppPrtPprStcTblRsltWork�C���X�^���X�擾
    //    /// </summary>
    //    /// <returns>SuppPrtPprStcTblRsltWork�N���X�̃C���X�^���X</returns>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprStcTblRsltWork�̃C���X�^���X���擾���܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    private SuppPrtPprStcTblRsltWork GetSuppPrtPprStcTblRsltWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
    //    {
    //        // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
    //        // serInfo.MemberInfo.Count < currentMemberCount
    //        // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

    //        SuppPrtPprStcTblRsltWork temp = new SuppPrtPprStcTblRsltWork();

    //        //�f�[�^�敪
    //        temp.DataDiv = reader.ReadInt32();
    //        //�`�[���t
    //        temp.StockDate = new DateTime( reader.ReadInt64() );
    //        //�`�[�ԍ�
    //        temp.PartySaleSlipNum = reader.ReadString();
    //        //�s��(���ו\��)
    //        temp.StockRowNo = reader.ReadInt32();
    //        //�d���`��
    //        temp.SupplierFormal = reader.ReadInt32();
    //        //�d���`�[�敪
    //        temp.SupplierSlipCd = reader.ReadInt32();
    //        //�S���Җ�
    //        temp.StockAgentName = reader.ReadString();
    //        //���z
    //        temp.StockTtlPricTaxExc = reader.ReadInt64();
    //        //�i��(���ו\��)
    //        temp.GoodsName = reader.ReadString();
    //        //�i��(���ו\��)
    //        temp.GoodsNo = reader.ReadString();
    //        //���[�J�[�R�[�h(���ו\��)
    //        temp.GoodsMakerCd = reader.ReadInt32();
    //        //���[�J�[����
    //        temp.MakerName = reader.ReadString();
    //        //BL�R�[�h(���ו\��)
    //        temp.BLGoodsCode = reader.ReadInt32();
    //        //BL�O���[�v(���ו\��)
    //        temp.BLGroupCode = reader.ReadInt32();
    //        //����(���ו\��)
    //        temp.StockCount = reader.ReadDouble();
    //        //�W�����i(���ו\��)
    //        temp.ListPriceTaxExcFl = reader.ReadDouble();
    //        //�I�[�v�����i�敪(���ו\��)
    //        temp.OpenPriceDiv = reader.ReadInt32();
    //        //�d�������œ]�ŕ����R�[�h
    //        temp.SuppCTaxLayCd = reader.ReadInt32();
    //        //�d�����z�v�i�ō��݁j
    //        temp.StockTtlPricTaxInc = reader.ReadInt64();
    //        //�d�����z����Ŋz
    //        temp.StockPriceConsTax = reader.ReadInt64();
    //        //���l�P
    //        temp.SupplierSlipNote1 = reader.ReadString();
    //        //���l�Q
    //        temp.SupplierSlipNote2 = reader.ReadString();
    //        //���_
    //        temp.SectionGuideNm = reader.ReadString();
    //        //���s��
    //        temp.StockInputName = reader.ReadString();
    //        //�d����R�[�h
    //        temp.SupplierCd = reader.ReadInt32();
    //        //�d���於
    //        temp.SupplierSnm = reader.ReadString();
    //        //�ݎ�(���ו\��)
    //        temp.StockOrderDivCd = reader.ReadInt32();
    //        //�q��(���ו\��)
    //        temp.WarehouseName = reader.ReadString();
    //        //�I��(���ו\��)
    //        temp.WarehouseShelfNo = reader.ReadString();
    //        //�t�n�d���}�[�N�P
    //        temp.UoeRemark1 = reader.ReadString();
    //        //�t�n�d���}�[�N�Q
    //        temp.UoeRemark2 = reader.ReadString();
    //        //�d��SEQ/�x����
    //        temp.SupplierSlipNo = reader.ReadInt32();
    //        //�v���
    //        temp.StockAddUpADate = new DateTime( reader.ReadInt64() );
    //        //���|�敪
    //        temp.AccPayDivCd = reader.ReadInt32();
    //        //�ԓ`�敪
    //        temp.DebitNoteDiv = reader.ReadInt32();
    //        //��������`�[�ԍ�(���ו\��)
    //        temp.SalesSlipNum = reader.ReadString();
    //        //����������t(���ו\��)
    //        temp.SalesDate = new DateTime( reader.ReadInt64() );
    //        //���Ӑ�R�[�h(���ו\��)
    //        temp.CustomerCode = reader.ReadInt32();
    //        //���Ӑ於(���ו\��)
    //        temp.CustomerSnm = reader.ReadString();
    //        //���_�R�[�h
    //        temp.SectionCode = reader.ReadString();
    //        //�q�ɃR�[�h
    //        temp.WarehouseCode = reader.ReadString();
    //        //�d���摍�z�\�����@�敪
    //        temp.SuppTtlAmntDspWayCd = reader.ReadInt32();
    //        //�ېŋ敪
    //        temp.TaxationCode = reader.ReadInt32();
    //        //�d�����z����Ŋz�i���Łj[�`�[]
    //        temp.StckPrcConsTaxInclu = reader.ReadInt64();
    //        //�d���l������Ŋz�i���Łj[�`�[]
    //        temp.StckDisTtlTaxInclu = reader.ReadInt64();
    //        //�d���P���i�Ŕ��C�����j[���ו\��]
    //        temp.StockUnitPriceFl = reader.ReadDouble();


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
    //    /// <returns>SuppPrtPprStcTblRsltWork�N���X�̃C���X�^���X(object)</returns>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprStcTblRsltWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public object Deserialize( System.IO.BinaryReader reader )
    //    {
    //        object retValue = null;
    //        Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
    //        ArrayList lst = new ArrayList();
    //        for ( int cnt = 0; cnt < serInfo.Occurrence; ++cnt )
    //        {
    //            SuppPrtPprStcTblRsltWork temp = GetSuppPrtPprStcTblRsltWork( reader, serInfo );
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
    //                retValue = (SuppPrtPprStcTblRsltWork[])lst.ToArray( typeof( SuppPrtPprStcTblRsltWork ) );
    //                break;
    //        }
    //        return retValue;
    //    }

    //    #endregion
    //}

    # endregion
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/25 DEL

    /// public class name:   SuppPrtPprStcTblRsltWork
    /// <summary>
    ///                      �d����d�q�������o����(�`�[�E����)�N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d����d�q�������o����(�`�[�E����)�N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/02/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2009/09/08 ���̕�</br>
    /// <br>                 :   PM.NS-2-B�E�o�l�D�m�r�ێ�˗��@</br>
    /// <br>                 :   �ߋ����\���Ή�</br>
    /// <br>Update Note      :   2012/10/15 �c����</br>
    /// <br>�Ǘ��ԍ�         :   10801804-00�A2012/11/14�z�M��</br>
    /// <br>                     Redmine#32862 ���i�ύX�������ׁA�F��ς���悤�ɏC��</br>
    //----------------------------------------------------------------------------//
    // �Ǘ��ԍ�              �쐬�S�� : FSI��c �W�v
    // �C �� ��  2013/01/21  �C�����e : �d���ԕi�\��@�\�Ή�
    //----------------------------------------------------------------------------//
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SuppPrtPprStcTblRsltWork
    {
        /// <summary>�f�[�^�敪</summary>
        /// <remarks>0:�d���f�[�^ 1:�x���f�[�^</remarks>
        private Int32 _dataDiv;

        /// <summary>�`�[���t</summary>
        /// <remarks>�d����(YYYYMMDD)/�x�����t</remarks>
        private DateTime _stockDate;

        /// <summary>�`�[�ԍ�</summary>
        /// <remarks>�����`�[�ԍ�</remarks>
        private string _partySaleSlipNum = "";

        /// <summary>�s��(���ו\��)</summary>
        /// <remarks>�d���s�ԍ�/�����s�ԍ�</remarks>
        private Int32 _stockRowNo;

        /// <summary>�d���`��</summary>
        /// <remarks>0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j</remarks>
        private Int32 _supplierFormal;

        /// <summary>�d���`�[�敪</summary>
        /// <remarks>10:�d��,20:�ԕi</remarks>
        private Int32 _supplierSlipCd;

        /// <summary>�S���Җ�</summary>
        /// <remarks>�d���S���Җ���/�x���S���Җ�</remarks>
        private string _stockAgentName = "";

        /// <summary>���z</summary>
        /// <remarks>�d�����z�v�i�Ŕ����j/�x�����z</remarks>
        private Int64 _stockTtlPricTaxExc;

        /// <summary>�i��(���ו\��)</summary>
        /// <remarks>���i����/���햼��</remarks>
        private string _goodsName = "";

        /// <summary>�i��(���ו\��)</summary>
        /// <remarks>���i�ԍ�</remarks>
        private string _goodsNo = "";

        /// <summary>���[�J�[�R�[�h(���ו\��)</summary>
        /// <remarks>���i���[�J�[�R�[�h</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>���[�J�[����</summary>
        /// <remarks>���[�J�[����</remarks>
        private string _makerName = "";

        /// <summary>BL�R�[�h(���ו\��)</summary>
        /// <remarks>BL���i�R�[�h</remarks>
        private Int32 _bLGoodsCode;

        /// <summary>BL�O���[�v(���ו\��)</summary>
        /// <remarks>BL�O���[�v�R�[�h</remarks>
        private Int32 _bLGroupCode;

        /// <summary>����(���ו\��)</summary>
        /// <remarks>�d����</remarks>
        private Double _stockCount;

        /// <summary>�W�����i(���ו\��)</summary>
        /// <remarks>�艿�i�Ŕ��C�����j</remarks>
        private Double _listPriceTaxExcFl;

        /// <summary>�I�[�v�����i�敪(���ו\��)</summary>
        /// <remarks>0:�ʏ�^1:�I�[�v�����i</remarks>
        private Int32 _openPriceDiv;

        /// <summary>�d�������œ]�ŕ����R�[�h</summary>
        /// <remarks>0:�`�[�P��1:���גP��2:�x���e 3:�x���q 9:��ې�</remarks>
        private Int32 _suppCTaxLayCd;

        /// <summary>�d�����z�v�i�ō��݁j</summary>
        /// <remarks>���x�����z�̂���</remarks>
        private Int64 _stockTtlPricTaxInc;

        /// <summary>�d�����z����Ŋz</summary>
        private Int64 _stockPriceConsTax;

        /// <summary>���l�P</summary>
        /// <remarks>�d���`�[���l1/�`�[�E�v</remarks>
        private string _supplierSlipNote1 = "";

        /// <summary>���l�Q</summary>
        /// <remarks>�d���`�[���l2/�L������</remarks>
        private string _supplierSlipNote2 = "";

        /// <summary>���_</summary>
        /// <remarks>���_�K�C�h����/�v�㋒�_�R�[�h</remarks>
        private string _sectionGuideNm = "";

        // --- DEL 2009/09/08 -------------->>>>>
        // /// <summary>���s��</summary>
        // /// <remarks>�d�����͎Җ���/�x�����͎Җ���</remarks>
        // private string _stockInputName = "";
        // --- DEL 2009/09/08 --------------<<<<<

        /// <summary>�d����R�[�h</summary>
        /// <remarks>�d����R�[�h/�d����R�[�h</remarks>
        private Int32 _supplierCd;

        /// <summary>�d���於</summary>
        /// <remarks>�d���旪��/�d���旪��</remarks>
        private string _supplierSnm = "";

        /// <summary>�ݎ�(���ו\��)</summary>
        /// <remarks>�d���݌Ɏ�񂹋敪(0:��񂹁C1:�݌�)</remarks>
        private Int32 _stockOrderDivCd;

        /// <summary>�q��(���ו\��)</summary>
        /// <remarks>�q�ɖ���</remarks>
        private string _warehouseName = "";

        /// <summary>�I��(���ו\��)</summary>
        /// <remarks>�q�ɒI��</remarks>
        private string _warehouseShelfNo = "";

        /// <summary>�t�n�d���}�[�N�P</summary>
        /// <remarks>�t�n�d���}�[�N�P</remarks>
        private string _uoeRemark1 = "";

        /// <summary>�t�n�d���}�[�N�Q</summary>
        /// <remarks>�t�n�d���}�[�N�Q</remarks>
        private string _uoeRemark2 = "";

        /// <summary>�d��SEQ/�x����</summary>
        /// <remarks>�d���`�[�ԍ�/�x���`�[�ԍ�</remarks>
        private Int32 _supplierSlipNo;

        /// <summary>�v���</summary>
        /// <remarks>�d���v����t(YYYYMMDD)/�v����t(YYYYMMDD)</remarks>
        private DateTime _stockAddUpADate;

        /// <summary>���|�敪</summary>
        /// <remarks>���|�敪(0:���|�Ȃ�,1:���|)</remarks>
        private Int32 _accPayDivCd;

        /// <summary>�ԓ`�敪</summary>
        /// <remarks>0:���`,1:�ԓ`,2:����</remarks>
        private Int32 _debitNoteDiv;

        /// <summary>��������`�[�ԍ�(���ו\��)</summary>
        /// <remarks>����`�[�ԍ�</remarks>
        private string _salesSlipNum = "";

        /// <summary>����������t(���ו\��)</summary>
        /// <remarks>������t</remarks>
        private DateTime _salesDate;

        /// <summary>���Ӑ�R�[�h(���ו\��)</summary>
        /// <remarks>���Ӑ�R�[�h</remarks>
        private Int32 _customerCode;

        /// <summary>���Ӑ於(���ו\��)</summary>
        /// <remarks>���Ӑ旪��</remarks>
        private string _customerSnm = "";

        /// <summary>���_�R�[�h</summary>
        /// <remarks>���_�R�[�h</remarks>
        private string _sectionCode = "";

        /// <summary>�q�ɃR�[�h</summary>
        /// <remarks>�q�ɃR�[�h</remarks>
        private string _warehouseCode = "";

        /// <summary>�d���摍�z�\�����@�敪</summary>
        /// <remarks>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</remarks>
        private Int32 _suppTtlAmntDspWayCd;

        /// <summary>�ېŋ敪</summary>
        /// <remarks>0:�ې�,1:��ې�,2:�ېŁi���Łj</remarks>
        private Int32 _taxationCode;

        /// <summary>�d�����z����Ŋz�i���Łj[�`�[]</summary>
        /// <remarks>�l���O�̓��ŏ��i�̏����</remarks>
        private Int64 _stckPrcConsTaxInclu;

        /// <summary>�d���l������Ŋz�i���Łj[�`�[]</summary>
        /// <remarks>���ŏ��i�l���̏���Ŋz</remarks>
        private Int64 _stckDisTtlTaxInclu;

        /// <summary>�d���P���i�Ŕ��C�����j[����]</summary>
        /// <remarks>�Ŕ���</remarks>
        private Double _stockUnitPriceFl;

        /// <summary>�d�����z�i�Ŕ����j[����]</summary>
        private Int64 _stockPriceTaxExc;

        /// <summary>�d�����z�i�ō��݁j[����]</summary>
        private Int64 _stockPriceTaxInc;

        /// <summary>�d�����i�敪[�`�[]</summary>
        /// <remarks>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,6:���v����,10:���p����Œ���(����),11:���E,12:���E(����)</remarks>
        private Int32 _stockGoodsCd;

        /// <summary>�d�����z����Ŋz[����]</summary>
        /// <remarks>�d�����z�i�ō��݁j- �d�����z�i�Ŕ����j������Œ����z�����˂�</remarks>
        private Int64 _stockPriceConsTaxDtl;

        /// <summary>�d���`�[�敪�i���ׁj[����]</summary>
        /// <remarks>0:�d��,1:�ԕi,2:�l��</remarks>
        private Int32 _stockSlipCdDtl;

        /// <summary>�萔���x���z[�x��]</summary>
        private Int64 _feePayment;

        /// <summary>�l���x���z[�x��]</summary>
        private Int64 _discountPayment;

        // ----------- ADD 2012/10/15 �c���� Redmine#32862 ------------>>>>>
        /// <summary>�ύX�O�d���P���i�����j[����]</summary>
        private Double _bfStockUnitPriceFl;

        /// <summary>�ύX�O�艿[����]</summary>
        private Double _bfListPrice;
        // ----------- ADD 2012/10/15 �c���� Redmine#32862 ------------<<<<<

        // ----------ADD 2013/01/21----------->>>>>
        /// <summary>�_���폜�敪[�d��]</summary>
        private Int32 _slpLogicalDeleteCode;

        /// <summary>�_���폜�敪[�d���ڍ�]</summary>
        private Int32 _dtlLogicalDeleteCode;

        /// <summary>����R�[�h[�d��]</summary>
        private Int32 _slpSubSectionCode;

        /// <summary>�d�����_�R�[�h[�d��]</summary>
        private string _stockSectionCd;

        /// <summary>�d�������Őŗ�[�d��]</summary>
        private Double _supplierConsTaxRate;

        /// <summary>���͓�[�d��]</summary>
        private DateTime _inputDay;

        /// <summary>����R�[�h[�d������]</summary>
        private Int32 _dtlSubSectionCode;

        /// <summary>�󒍔ԍ�[�d������]</summary>
        private Int32 _acceptAnOrderNo;

        /// <summary>���ʒʔ�[�d������]</summary>
        private Int64 _commonSeqNo;

        /// <summary>�d�����גʔ�[�d������]</summary>
        private Int64 _stockSlipDtlNum;

        /// <summary>�d���`���i���j[�d������]</summary>
        private Int32 _supplierFormalSrc;

        /// <summary>�d�����גʔԁi���j[�d������]</summary>
        private Int64 _stockSlipDtlNumSrc;

        /// <summary>�󒍃X�e�[�^�X�i�����j[�d������]</summary>
        private Int32 _acptAnOdrStatusSync;

        /// <summary>���㖾�גʔԁi�����j[�d������]</summary>
        private Int64 _salesSlipDtlNumSync;

        /// <summary>�d�����͎҃R�[�h[�d������]</summary>
        private string _stockInputCode;

        /// <summary>�d���S���҃R�[�h[�d������]</summary>
        private string _stockAgentCode;

        /// <summary>���i����[�d������]</summary>
        private Int32 _goodsKindCode;

        /// <summary>���[�J�[�J�i����[�d������]</summary>
        private string _makerKanaName;

        /// <summary>���[�J�[�J�i���́i�ꎮ�j[�d������]</summary>
        private string _cmpltMakerKanaName;

        /// <summary>���i���̃J�i[�d������]</summary>
        private string _goodsNameKana;

        /// <summary>���i�啪�ރR�[�h[�d������]</summary>
        private Int32 _goodsLGroup;

        /// <summary>���i�啪�ޖ���[�d������]</summary>
        private string _goodsLGroupName;

        /// <summary>���i�����ރR�[�h[�d������]</summary>
        private Int32 _goodsMGroup;

        /// <summary>���i�����ޖ���[�d������]</summary>
        private string _goodsMGroupName;

        /// <summary>BL�O���[�v�R�[�h����[�d������]</summary>
        private string _bLGroupName;

        /// <summary>BL���i�R�[�h���́i�S�p�j[�d������]</summary>
        private string _bLGoodsFullName;

        /// <summary>���Е��ރR�[�h[�d������]</summary>
        private Int32 _enterpriseGanreCode;

        /// <summary>�|���ݒ苒�_�i�d���P���j[�d������]</summary>
        private string _rateSectStckUnPrc;

        /// <summary>�|���ݒ�敪�i�d���P���j[�d������]</summary>
        private string _rateDivStckUnPrc;

        /// <summary>�P���Z�o�敪�i�d���P���j[�d������]</summary>
        private Int32 _unPrcCalcCdStckUnPrc;

        /// <summary>���i�敪�i�d���P���j[�d������]</summary>
        private Int32 _priceCdStckUnPrc;

        /// <summary>��P���i�d���P���j[�d������]</summary>
        private Double _stdUnPrcStckUnPrc;

        /// <summary>�[�������P�ʁi�d���P���j[�d������]</summary>
        private Double _fracProcUnitStcUnPrc;

        /// <summary>�[�������i�d���P���j[�d������]</summary>
        private Int32 _fracProcStckUnPrc;

        /// <summary>�d���P���i�ō��C�����j[�d������]</summary>
        private Double _stockUnitTaxPriceFl;

        /// <summary>�d���P���ύX�敪[�d������]</summary>
        private Int32 _stockUnitChngDiv;

        /// <summary>BL���i�R�[�h�i�|���j[�d������]</summary>
        private Int32 _rateBLGoodsCode;

        /// <summary>BL���i�R�[�h���́i�|���j[�d������]</summary>
        private string _rateBLGoodsName;

        /// <summary>���i�|���O���[�v�R�[�h�i�|���j[�d������]</summary>
        private Int32 _rateGoodsRateGrpCd;

        /// <summary>���i�|���O���[�v���́i�|���j[�d������]</summary>
        private string _rateGoodsRateGrpNm;

        /// <summary>BL�O���[�v�R�[�h�i�|���j[�d������]</summary>
        private Int32 _rateBLGroupCode;

        /// <summary>BL�O���[�v���́i�|���j[�d������]</summary>
        private string _rateBLGroupName;

        /// <summary>��������[�d������]</summary>
        private Double _orderCnt;

        /// <summary>����������[�d������]</summary>
        private Double _orderAdjustCnt;

        /// <summary>�����c��[�d������]</summary>
        private Double _orderRemainCnt;

        /// <summary>�c���X�V��[�d������]</summary>
        private DateTime _remainCntUpdDate;

        /// <summary>�d���`�[���ה��l1[�d������]</summary>
        private string _stockDtiSlipNote1;

        /// <summary>�̔���R�[�h[�d������]</summary>
        private Int32 _salesCustomerCode;

        /// <summary>�̔��旪��[�d������]</summary>
        private string _salesCustomerSnm;

        /// <summary>�`�[�����P[�d������]</summary>
        private string _slipMemo1;

        /// <summary>�`�[�����Q[�d������]</summary>
        private string _slipMemo2;

        /// <summary>�`�[�����R[�d������]</summary>
        private string _slipMemo3;

        /// <summary>�Г������P[�d������]</summary>
        private string _insideMemo1;

        /// <summary>�Г������Q[�d������]</summary>
        private string _insideMemo2;

        /// <summary>�Г������R[�d������]</summary>
        private string _insideMemo3;

        /// <summary>�[�i��R�[�h[�d������]</summary>
        private Int32 _addresseeCode;

        /// <summary>�[�i�於��[�d������]</summary>
        private string _addresseeName;

        /// <summary>�����敪[�d������]</summary>
        private Int32 _directSendingCd;

        /// <summary>�����ԍ�[�d������]</summary>
        private string _orderNumber;

        /// <summary>�������@[�d������]</summary>
        private Int32 _wayToOrder;

        /// <summary>�[�i�����\���[�d������]</summary>
        private DateTime _deliGdsCmpltDueDate;

        /// <summary>��]�[��[�d������]</summary>
        private DateTime _expectDeliveryDate;

        /// <summary>�����f�[�^�쐬�敪[�d������]</summary>
        private Int32 _orderDataCreateDiv;

        /// <summary>�����f�[�^�쐬��[�d������]</summary>
        private DateTime _orderDataCreateDate;

        /// <summary>���������s�ϋ敪[�d������]</summary>
        private Int32 _orderFormIssuedDiv;

        /// <summary>���Е��ޖ���[�d������]</summary>
        private string _enterpriseGanreName; 

        /// <summary>���i�|�������N[�d������]</summary>
        private string _goodsRateRank;

        /// <summary>���Ӑ�|���O���[�v�R�[�h[�d������]</summary>
        private Int32 _custRateGrpCode;

        /// <summary>�d����|���O���[�v�R�[�h[�d������]</summary>
        private Int32 _suppRateGrpCode;

        /// <summary>�艿�i�ō��C�����j[�d������]</summary>
        private Double _listPriceTaxIncFl;

        /// <summary>�d����[�d������]</summary>
        private Double _stockRate;

        /// <summary>�d���v�㋒�_�R�[�h[�d��]</summary>
        private string _stockAddUpSectionCd;

        /// <summary>�Ǝ�R�[�h[�d��]</summary>
        private Int32 _businessTypeCode;

        /// <summary>�Ǝ햼��[�d��]</summary>
        private string _businessTypeName;

        /// <summary>�̔��G���A�R�[�h[�d��]</summary>
        private Int32 _salesAreaCode;

        /// <summary>�̔��G���A����[�d��]</summary>
        private string _salesAreaName;

        /// <summary>���z�\���|���K�p�敪[�d��]</summary>
        private Int32 _ttlAmntDispRateApy;

        /// <summary>�d���[�������敪[�d��]</summary>
        private Int32 _stockFractionProcCd;
       
        /// <summary>�`�[�Z���敪[�d��]</summary>
        private Int32 _slipAddressDiv;

        /// <summary>�[�i��R�[�h[�d��]</summary>
        private Int32 _slpAddresseeCode;

        /// <summary>�[�i�於��[�d��]</summary>
        private string _slpAddresseeName;

        /// <summary>�[�i�於��2[�d��]</summary>
        private string _addresseeName2;

        /// <summary>�[�i��X�֔ԍ�[�d��]</summary>
        private string _addresseePostNo;

        /// <summary>�[�i��Z��1_�s���{���s��S�E�����E��[�d��]</summary>
        private string _addresseeAddr1;

        /// <summary>�[�i��Z��3_�Ԓn[�d��]</summary>
        private string _addresseeAddr3;

        /// <summary>�[�i��Z��4_�A�p�[�g����[�d��]</summary>
        private string _addresseeAddr4;

        /// <summary>�[�i��d�b�ԍ�[�d��]</summary>
        private string _addresseeTelNo;

        /// <summary>�[�i��FAX�ԍ�[�d��]</summary>
        private string _addresseeFaxNo;

        /// <summary>�����敪[�d��]</summary>
        private Int32 _slpDirectSendingCd;
        // ----------ADD 2013/01/21-----------<<<<<

        /// public propaty name  :  DataDiv
        /// <summary>�f�[�^�敪�v���p�e�B</summary>
        /// <value>0:�d���f�[�^ 1:�x���f�[�^</value>
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

        /// public propaty name  :  StockDate
        /// <summary>�`�[���t�v���p�e�B</summary>
        /// <value>�d����(YYYYMMDD)/�x�����t</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime StockDate
        {
            get { return _stockDate; }
            set { _stockDate = value; }
        }

        /// public propaty name  :  PartySaleSlipNum
        /// <summary>�`�[�ԍ��v���p�e�B</summary>
        /// <value>�����`�[�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartySaleSlipNum
        {
            get { return _partySaleSlipNum; }
            set { _partySaleSlipNum = value; }
        }

        /// public propaty name  :  StockRowNo
        /// <summary>�s��(���ו\��)�v���p�e�B</summary>
        /// <value>�d���s�ԍ�/�����s�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �s��(���ו\��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockRowNo
        {
            get { return _stockRowNo; }
            set { _stockRowNo = value; }
        }

        /// public propaty name  :  SupplierFormal
        /// <summary>�d���`���v���p�e�B</summary>
        /// <value>0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierFormal
        {
            get { return _supplierFormal; }
            set { _supplierFormal = value; }
        }

        /// public propaty name  :  SupplierSlipCd
        /// <summary>�d���`�[�敪�v���p�e�B</summary>
        /// <value>10:�d��,20:�ԕi</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierSlipCd
        {
            get { return _supplierSlipCd; }
            set { _supplierSlipCd = value; }
        }

        /// public propaty name  :  StockAgentName
        /// <summary>�S���Җ��v���p�e�B</summary>
        /// <value>�d���S���Җ���/�x���S���Җ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �S���Җ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockAgentName
        {
            get { return _stockAgentName; }
            set { _stockAgentName = value; }
        }

        /// public propaty name  :  StockTtlPricTaxExc
        /// <summary>���z�v���p�e�B</summary>
        /// <value>�d�����z�v�i�Ŕ����j/�x�����z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockTtlPricTaxExc
        {
            get { return _stockTtlPricTaxExc; }
            set { _stockTtlPricTaxExc = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>�i��(���ו\��)�v���p�e�B</summary>
        /// <value>���i����/���햼��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i��(���ו\��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>�i��(���ו\��)�v���p�e�B</summary>
        /// <value>���i�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i��(���ו\��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���[�J�[�R�[�h(���ו\��)�v���p�e�B</summary>
        /// <value>���i���[�J�[�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�R�[�h(���ו\��)�v���p�e�B</br>
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

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL�R�[�h(���ו\��)�v���p�e�B</summary>
        /// <value>BL���i�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h(���ו\��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>BL�O���[�v(���ו\��)�v���p�e�B</summary>
        /// <value>BL�O���[�v�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v(���ו\��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  StockCount
        /// <summary>����(���ו\��)�v���p�e�B</summary>
        /// <value>�d����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����(���ו\��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockCount
        {
            get { return _stockCount; }
            set { _stockCount = value; }
        }

        /// public propaty name  :  ListPriceTaxExcFl
        /// <summary>�W�����i(���ו\��)�v���p�e�B</summary>
        /// <value>�艿�i�Ŕ��C�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����i(���ו\��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ListPriceTaxExcFl
        {
            get { return _listPriceTaxExcFl; }
            set { _listPriceTaxExcFl = value; }
        }

        /// public propaty name  :  OpenPriceDiv
        /// <summary>�I�[�v�����i�敪(���ו\��)�v���p�e�B</summary>
        /// <value>0:�ʏ�^1:�I�[�v�����i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�[�v�����i�敪(���ו\��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OpenPriceDiv
        {
            get { return _openPriceDiv; }
            set { _openPriceDiv = value; }
        }

        /// public propaty name  :  SuppCTaxLayCd
        /// <summary>�d�������œ]�ŕ����R�[�h�v���p�e�B</summary>
        /// <value>0:�`�[�P��1:���גP��2:�x���e 3:�x���q 9:��ې�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�������œ]�ŕ����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SuppCTaxLayCd
        {
            get { return _suppCTaxLayCd; }
            set { _suppCTaxLayCd = value; }
        }

        /// public propaty name  :  StockTtlPricTaxInc
        /// <summary>�d�����z�v�i�ō��݁j�v���p�e�B</summary>
        /// <value>���x�����z�̂���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z�v�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockTtlPricTaxInc
        {
            get { return _stockTtlPricTaxInc; }
            set { _stockTtlPricTaxInc = value; }
        }

        /// public propaty name  :  StockPriceConsTax
        /// <summary>�d�����z����Ŋz�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z����Ŋz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockPriceConsTax
        {
            get { return _stockPriceConsTax; }
            set { _stockPriceConsTax = value; }
        }

        /// public propaty name  :  SupplierSlipNote1
        /// <summary>���l�P�v���p�e�B</summary>
        /// <value>�d���`�[���l1/�`�[�E�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierSlipNote1
        {
            get { return _supplierSlipNote1; }
            set { _supplierSlipNote1 = value; }
        }

        /// public propaty name  :  SupplierSlipNote2
        /// <summary>���l�Q�v���p�e�B</summary>
        /// <value>�d���`�[���l2/�L������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierSlipNote2
        {
            get { return _supplierSlipNote2; }
            set { _supplierSlipNote2 = value; }
        }

        /// public propaty name  :  SectionGuideNm
        /// <summary>���_�v���p�e�B</summary>
        /// <value>���_�K�C�h����/�v�㋒�_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }

        // --- DEL 2009/09/08 ---------->>>>>
        /// public propaty name  :  StockInputName
        /// <summary>���s�҃v���p�e�B</summary>
        /// <value>�d�����͎Җ���/�x�����͎Җ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���s�҃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        //public string StockInputName
        //{
        //    get { return _stockInputName; }
        //    set { _stockInputName = value; }
        //}
        //--- DEL 2009/09/08 ----------<<<<<

        /// public propaty name  :  SupplierCd
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// <value>�d����R�[�h/�d����R�[�h</value>
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
        /// <summary>�d���於�v���p�e�B</summary>
        /// <value>�d���旪��/�d���旪��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���於�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }

        /// public propaty name  :  StockOrderDivCd
        /// <summary>�ݎ�(���ו\��)�v���p�e�B</summary>
        /// <value>�d���݌Ɏ�񂹋敪(0:��񂹁C1:�݌�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ݎ�(���ו\��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockOrderDivCd
        {
            get { return _stockOrderDivCd; }
            set { _stockOrderDivCd = value; }
        }

        /// public propaty name  :  WarehouseName
        /// <summary>�q��(���ו\��)�v���p�e�B</summary>
        /// <value>�q�ɖ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q��(���ו\��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
        }

        /// public propaty name  :  WarehouseShelfNo
        /// <summary>�I��(���ו\��)�v���p�e�B</summary>
        /// <value>�q�ɒI��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I��(���ו\��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseShelfNo
        {
            get { return _warehouseShelfNo; }
            set { _warehouseShelfNo = value; }
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

        /// public propaty name  :  SupplierSlipNo
        /// <summary>�d��SEQ/�x�����v���p�e�B</summary>
        /// <value>�d���`�[�ԍ�/�x���`�[�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d��SEQ/�x�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierSlipNo
        {
            get { return _supplierSlipNo; }
            set { _supplierSlipNo = value; }
        }

        /// public propaty name  :  StockAddUpADate
        /// <summary>�v����v���p�e�B</summary>
        /// <value>�d���v����t(YYYYMMDD)/�v����t(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime StockAddUpADate
        {
            get { return _stockAddUpADate; }
            set { _stockAddUpADate = value; }
        }

        /// public propaty name  :  AccPayDivCd
        /// <summary>���|�敪�v���p�e�B</summary>
        /// <value>���|�敪(0:���|�Ȃ�,1:���|)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���|�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AccPayDivCd
        {
            get { return _accPayDivCd; }
            set { _accPayDivCd = value; }
        }

        /// public propaty name  :  DebitNoteDiv
        /// <summary>�ԓ`�敪�v���p�e�B</summary>
        /// <value>0:���`,1:�ԓ`,2:����</value>
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

        /// public propaty name  :  SalesSlipNum
        /// <summary>��������`�[�ԍ�(���ו\��)�v���p�e�B</summary>
        /// <value>����`�[�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������`�[�ԍ�(���ו\��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }

        /// public propaty name  :  SalesDate
        /// <summary>����������t(���ו\��)�v���p�e�B</summary>
        /// <value>������t</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����������t(���ו\��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h(���ו\��)�v���p�e�B</summary>
        /// <value>���Ӑ�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h(���ו\��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  CustomerSnm
        /// <summary>���Ӑ於(���ו\��)�v���p�e�B</summary>
        /// <value>���Ӑ旪��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於(���ו\��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
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

        /// public propaty name  :  SuppTtlAmntDspWayCd
        /// <summary>�d���摍�z�\�����@�敪�v���p�e�B</summary>
        /// <value>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���摍�z�\�����@�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SuppTtlAmntDspWayCd
        {
            get { return _suppTtlAmntDspWayCd; }
            set { _suppTtlAmntDspWayCd = value; }
        }

        /// public propaty name  :  TaxationCode
        /// <summary>�ېŋ敪�v���p�e�B</summary>
        /// <value>0:�ې�,1:��ې�,2:�ېŁi���Łj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ېŋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TaxationCode
        {
            get { return _taxationCode; }
            set { _taxationCode = value; }
        }

        /// public propaty name  :  StckPrcConsTaxInclu
        /// <summary>�d�����z����Ŋz�i���Łj[�`�[]�v���p�e�B</summary>
        /// <value>�l���O�̓��ŏ��i�̏����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z����Ŋz�i���Łj[�`�[]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StckPrcConsTaxInclu
        {
            get { return _stckPrcConsTaxInclu; }
            set { _stckPrcConsTaxInclu = value; }
        }

        /// public propaty name  :  StckDisTtlTaxInclu
        /// <summary>�d���l������Ŋz�i���Łj[�`�[]�v���p�e�B</summary>
        /// <value>���ŏ��i�l���̏���Ŋz</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���l������Ŋz�i���Łj[�`�[]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StckDisTtlTaxInclu
        {
            get { return _stckDisTtlTaxInclu; }
            set { _stckDisTtlTaxInclu = value; }
        }

        /// public propaty name  :  StockUnitPriceFl
        /// <summary>�d���P���i�Ŕ��C�����j[����]�v���p�e�B</summary>
        /// <value>�Ŕ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���P���i�Ŕ��C�����j[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockUnitPriceFl
        {
            get { return _stockUnitPriceFl; }
            set { _stockUnitPriceFl = value; }
        }

        /// public propaty name  :  StockPriceTaxExc
        /// <summary>�d�����z�i�Ŕ����j[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z�i�Ŕ����j[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockPriceTaxExc
        {
            get { return _stockPriceTaxExc; }
            set { _stockPriceTaxExc = value; }
        }

        /// public propaty name  :  StockPriceTaxInc
        /// <summary>�d�����z�i�ō��݁j[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z�i�ō��݁j[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockPriceTaxInc
        {
            get { return _stockPriceTaxInc; }
            set { _stockPriceTaxInc = value; }
        }

        /// public propaty name  :  StockGoodsCd
        /// <summary>�d�����i�敪[�`�[]�v���p�e�B</summary>
        /// <value>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,6:���v����,10:���p����Œ���(����),11:���E,12:���E(����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����i�敪[�`�[]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockGoodsCd
        {
            get { return _stockGoodsCd; }
            set { _stockGoodsCd = value; }
        }

        /// public propaty name  :  StockPriceConsTaxDtl
        /// <summary>�d�����z����Ŋz[����]�v���p�e�B</summary>
        /// <value>�d�����z�i�ō��݁j- �d�����z�i�Ŕ����j������Œ����z�����˂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z����Ŋz[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockPriceConsTaxDtl
        {
            get { return _stockPriceConsTaxDtl; }
            set { _stockPriceConsTaxDtl = value; }
        }

        /// public propaty name  :  StockSlipCdDtl
        /// <summary>�d���`�[�敪�i���ׁj[����]�v���p�e�B</summary>
        /// <value>0:�d��,1:�ԕi,2:�l��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�敪�i���ׁj[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockSlipCdDtl
        {
            get { return _stockSlipCdDtl; }
            set { _stockSlipCdDtl = value; }
        }

        /// public propaty name  :  FeePayment
        /// <summary>�萔���x���z[�x��]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �萔���x���z[�x��]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 FeePayment
        {
            get { return _feePayment; }
            set { _feePayment = value; }
        }

        /// public propaty name  :  DiscountPayment
        /// <summary>�l���x���z[�x��]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l���x���z[�x��]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DiscountPayment
        {
            get { return _discountPayment; }
            set { _discountPayment = value; }
        }

        // ----------- ADD 2012/10/15 �c���� Redmine#32862 ------------>>>>>
        /// public propaty name  :  BfStockUnitPriceFl
        /// <summary>�ύX�O�d���P���i�����j[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ύX�O�d���P���i�����j[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double BfStockUnitPriceFl
        {
            get { return _bfStockUnitPriceFl; }
            set { _bfStockUnitPriceFl = value; }
        }

        /// public propaty name  :  BfListPrice
        /// <summary>�ύX�O�艿[����]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ύX�O�艿[����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double BfListPrice
        {
            get { return _bfListPrice; }
            set { _bfListPrice = value; }
        }
        // ----------- ADD 2012/10/15 �c���� Redmine#32862 ------------<<<<<

        // ----------ADD 2013/01/21----------->>>>>
        /// public propaty name  :  SlpLogicalDeleteCode
        /// <summary>�_���폜�敪(�d��)�v���p�e�B</summary>
        /// <value>�_���폜�敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_���폜�敪(�d��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlpLogicalDeleteCode
        {
            get { return _slpLogicalDeleteCode; }
            set { _slpLogicalDeleteCode = value; }
        }

        /// public propaty name  :  DtlLogicalDeleteCode
        /// <summary>�_���폜�敪(�d���ڍ�)�v���p�e�B</summary>
        /// <value>�_���폜�敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_���폜�敪(�d���ڍ�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DtlLogicalDeleteCode
        {
            get { return _dtlLogicalDeleteCode; }
            set { _dtlLogicalDeleteCode = value; }
        }

        /// public propaty name  :  SlpSubSectionCode
        /// <summary>����R�[�h[�d��]�v���p�e�B</summary>
        /// <value>����R�[�h[�d��]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����R�[�h[�d��]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlpSubSectionCode
        {
            get { return _slpSubSectionCode; }
            set { _slpSubSectionCode = value; }
        }

        /// public propaty name  :  StockSectionCd
        /// <summary>�d�����_�R�[�h[�d��]�v���p�e�B</summary>
        /// <value>�d�����_�R�[�h[�d��]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����_�R�[�h[�d��]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockSectionCd
        {
            get { return _stockSectionCd; }
            set { _stockSectionCd = value; }
        }

        /// public propaty name  :  SupplierConsTaxRate
        /// <summary>�d�������Őŗ�[�d��]�v���p�e�B</summary>
        /// <value>�d�������Őŗ�[�d��]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�������Őŗ�[�d��]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SupplierConsTaxRate
        {
            get { return _supplierConsTaxRate; }
            set { _supplierConsTaxRate = value; }
        }

        /// public propaty name  :  InputDay
        /// <summary>���͓�[�d��]�v���p�e�B</summary>
        /// <value>���͓�[�d��]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓�[�d��]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime InputDay
        {
            get { return _inputDay; }
            set { _inputDay = value; }
        }

        /// public propaty name  :  DtlSubSectionCode
        /// <summary>����R�[�h[�d������]�v���p�e�B</summary>
        /// <value>����R�[�h[�d������]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����R�[�h[�d������]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DtlSubSectionCode
        {
            get { return _dtlSubSectionCode; }
            set { _dtlSubSectionCode = value; }
        }

        /// public propaty name  :  AcceptAnOrderNo
        /// <summary>�󒍔ԍ�[�d������]�v���p�e�B</summary>
        /// <value>�󒍔ԍ�[�d������]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍔ԍ�[�d������]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcceptAnOrderNo
        {
            get { return _acceptAnOrderNo; }
            set { _acceptAnOrderNo = value; }
        }

        /// public propaty name  :  CommonSeqNo
        /// <summary>���ʒʔ�[�d������]�v���p�e�B</summary>
        /// <value>���ʒʔ�[�d������]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ʒʔ�[�d������]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CommonSeqNo
        {
            get { return _commonSeqNo; }
            set { _commonSeqNo = value; }
        }

        /// public propaty name  :  StockSlipDtlNum
        /// <summary>�d�����גʔ�[�d������]�v���p�e�B</summary>
        /// <value>�d�����גʔ�[�d������]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����גʔ�[�d������]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockSlipDtlNum
        {
            get { return _stockSlipDtlNum; }
            set { _stockSlipDtlNum = value; }
        }

        /// public propaty name  :  SupplierFormalSrc
        /// <summary>�d���`���i���j[�d������]�v���p�e�B</summary>
        /// <value>�d���`���i���j[�d������]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`���i���j[�d������]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierFormalSrc
        {
            get { return _supplierFormalSrc; }
            set { _supplierFormalSrc = value; }
        }

        /// public propaty name  :  StockSlipDtlNumSrc
        /// <summary>�d�����גʔԁi���j[�d������]�v���p�e�B</summary>
        /// <value>�d�����גʔԁi���j[�d������]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����גʔԁi���j[�d������]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockSlipDtlNumSrc
        {
            get { return _stockSlipDtlNumSrc; }
            set { _stockSlipDtlNumSrc = value; }
        }

        /// public propaty name  :  AcptAnOdrStatusSync
        /// <summary>�󒍃X�e�[�^�X�i�����j[�d������]�v���p�e�B</summary>
        /// <value>�󒍃X�e�[�^�X�i�����j[�d������]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃X�e�[�^�X�i�����j[�d������]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcptAnOdrStatusSync
        {
            get { return _acptAnOdrStatusSync; }
            set { _acptAnOdrStatusSync = value; }
        }

        /// public propaty name  :  SalesSlipDtlNumSync
        /// <summary>���㖾�גʔԁi�����j[�d������]�v���p�e�B</summary>
        /// <value>���㖾�גʔԁi�����j[�d������]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㖾�גʔԁi�����j[�d������]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesSlipDtlNumSync
        {
            get { return _salesSlipDtlNumSync; }
            set { _salesSlipDtlNumSync = value; }
        }

        /// public propaty name  :  StockInputCode
        /// <summary>�d�����͎҃R�[�h�v���p�e�B</summary>
        /// <value>�d�����͎҃R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����͎҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockInputCode
        {
            get { return _stockInputCode; }
            set {  _stockInputCode = value; }
        }

        /// public propaty name  :  StockAgentCode
        /// <summary>�d���S���҃R�[�h�v���p�e�B</summary>
        /// <value>�d���S���҃R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���S���҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockAgentCode
        {
            get { return _stockAgentCode; }
            set {  _stockAgentCode = value; }
        }

        /// public propaty name  :  GoodsKindCode
        /// <summary>���i�����v���p�e�B</summary>
        /// <value>���i����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsKindCode
        {
            get { return _goodsKindCode; }
            set {  _goodsKindCode = value; }
        }

        /// public propaty name  :  MakerKanaName
        /// <summary>���[�J�[�J�i���̃v���p�e�B</summary>
        /// <value>���[�J�[�J�i����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�J�i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MakerKanaName
        {
            get { return _makerKanaName; }
            set {  _makerKanaName = value; }
        }

        /// public propaty name  :  CmpltMakerKanaName
        /// <summary>���[�J�[�J�i���́i�ꎮ�j�v���p�e�B</summary>
        /// <value>���[�J�[�J�i���́i�ꎮ�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�J�i���́i�ꎮ�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CmpltMakerKanaName
        {
            get { return _cmpltMakerKanaName; }
            set {  _cmpltMakerKanaName = value; }
        }

        /// public propaty name  :  GoodsNameKana
        /// <summary>���i���̃J�i�v���p�e�B</summary>
        /// <value>���i���̃J�i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̃J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNameKana
        {
            get { return _goodsNameKana; }
            set {  _goodsNameKana = value; }
        }

        /// public propaty name  :  GoodsLGroup
        /// <summary>���i�啪�ރR�[�h�v���p�e�B</summary>
        /// <value>���i�啪�ރR�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�啪�ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsLGroup
        {
            get { return _goodsLGroup; }
            set {  _goodsLGroup = value; }
        }

        /// public propaty name  :  GoodsLGroupName
        /// <summary>���i�啪�ޖ��̃v���p�e�B</summary>
        /// <value>���i�啪�ޖ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�啪�ޖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsLGroupName
        {
            get { return _goodsLGroupName; }
            set {  _goodsLGroupName = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>���i�����ރR�[�h�v���p�e�B</summary>
        /// <value>���i�����ރR�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set {  _goodsMGroup = value; }
        }

        /// public propaty name  :  GoodsMGroupName
        /// <summary>���i�����ޖ��̃v���p�e�B</summary>
        /// <value>���i�����ޖ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ޖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsMGroupName
        {
            get { return _goodsMGroupName; }
            set {  _goodsMGroupName = value; }
        }

        /// public propaty name  :  BLGroupName
        /// <summary>BL�O���[�v�R�[�h���̃v���p�e�B</summary>
        /// <value>BL�O���[�v�R�[�h����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�R�[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGroupName
        {
            get { return _bLGroupName; }
            set {  _bLGroupName = value; }
        }

        /// public propaty name  :  BLGoodsFullName
        /// <summary>BL���i�R�[�h���́i�S�p�j�v���p�e�B</summary>
        /// <value>BL���i�R�[�h���́i�S�p�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���́i�S�p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGoodsFullName
        {
            get { return _bLGoodsFullName; }
            set {  _bLGoodsFullName = value; }
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
            set {  _enterpriseGanreCode = value; }
        }

        /// public propaty name  :  RateSectStckUnPrc
        /// <summary>�|���ݒ苒�_�i�d���P���j�v���p�e�B</summary>
        /// <value>�|���ݒ苒�_�i�d���P���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���ݒ苒�_�i�d���P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateSectStckUnPrc
        {
            get { return _rateSectStckUnPrc; }
            set {  _rateSectStckUnPrc = value; }
        }

        /// public propaty name  :  RateDivStckUnPrc
        /// <summary>�|���ݒ�敪�i�d���P���j�v���p�e�B</summary>
        /// <value>�|���ݒ�敪�i�d���P���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���ݒ�敪�i�d���P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateDivStckUnPrc
        {
            get { return _rateDivStckUnPrc; }
            set {  _rateDivStckUnPrc = value; }
        }

        /// public propaty name  :  UnPrcCalcCdStckUnPrc
        /// <summary>�P���Z�o�敪�i�d���P���j�v���p�e�B</summary>
        /// <value>�P���Z�o�敪�i�d���P���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P���Z�o�敪�i�d���P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UnPrcCalcCdStckUnPrc
        {
            get { return _unPrcCalcCdStckUnPrc; }
            set {  _unPrcCalcCdStckUnPrc = value; }
        }

        /// public propaty name  :  PriceCdStckUnPrc
        /// <summary>���i�敪�i�d���P���j�v���p�e�B</summary>
        /// <value>���i�敪�i�d���P���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�敪�i�d���P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceCdStckUnPrc
        {
            get { return _priceCdStckUnPrc; }
            set {  _priceCdStckUnPrc = value; }
        }

        /// public propaty name  :  StdUnPrcStckUnPrc
        /// <summary>��P���i�d���P���j�v���p�e�B</summary>
        /// <value>��P���i�d���P���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��P���i�d���P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StdUnPrcStckUnPrc
        {
            get { return _stdUnPrcStckUnPrc; }
            set {  _stdUnPrcStckUnPrc = value; }
        }

        /// public propaty name  :  FracProcUnitStcUnPrc
        /// <summary>�[�������P�ʁi�d���P���j�v���p�e�B</summary>
        /// <value>�[�������P�ʁi�d���P���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�������P�ʁi�d���P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double FracProcUnitStcUnPrc
        {
            get { return _fracProcUnitStcUnPrc; }
            set {  _fracProcUnitStcUnPrc = value; }
        }

        /// public propaty name  :  FracProcStckUnPrc
        /// <summary>�[�������i�d���P���j�v���p�e�B</summary>
        /// <value>�[�������i�d���P���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�������i�d���P���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FracProcStckUnPrc
        {
            get { return _fracProcStckUnPrc; }
            set {  _fracProcStckUnPrc = value; }
        }

        /// public propaty name  :  StockUnitTaxPriceFl
        /// <summary>�d���P���i�ō��C�����j�v���p�e�B</summary>
        /// <value>�d���P���i�ō��C�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���P���i�ō��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockUnitTaxPriceFl
        {
            get { return _stockUnitTaxPriceFl; }
            set {  _stockUnitTaxPriceFl = value; }
        }

        /// public propaty name  :  StockUnitChngDiv
        /// <summary>�d���P���ύX�敪�v���p�e�B</summary>
        /// <value>�d���P���ύX�敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���P���ύX�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockUnitChngDiv
        {
            get { return _stockUnitChngDiv; }
            set {  _stockUnitChngDiv = value; }
        }

        /// public propaty name  :  RateBLGoodsCode
        /// <summary>BL���i�R�[�h�i�|���j�v���p�e�B</summary>
        /// <value>BL���i�R�[�h�i�|���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h�i�|���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RateBLGoodsCode
        {
            get { return _rateBLGoodsCode; }
            set {  _rateBLGoodsCode = value; }
        }

        /// public propaty name  :  RateBLGoodsName
        /// <summary>BL���i�R�[�h���́i�|���j�v���p�e�B</summary>
        /// <value>BL���i�R�[�h���́i�|���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���́i�|���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateBLGoodsName
        {
            get { return _rateBLGoodsName; }
            set {  _rateBLGoodsName = value; }
        }

        /// public propaty name  :  RateGoodsRateGrpCd
        /// <summary>���i�|���O���[�v�R�[�h�i�|���j�v���p�e�B</summary>
        /// <value>���i�|���O���[�v�R�[�h�i�|���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�|���O���[�v�R�[�h�i�|���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RateGoodsRateGrpCd
        {
            get { return _rateGoodsRateGrpCd; }
            set {  _rateGoodsRateGrpCd = value; }
        }

        /// public propaty name  :  RateGoodsRateGrpNm
        /// <summary>���i�|���O���[�v���́i�|���j�v���p�e�B</summary>
        /// <value>���i�|���O���[�v���́i�|���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�|���O���[�v���́i�|���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateGoodsRateGrpNm
        {
            get { return _rateGoodsRateGrpNm; }
            set {  _rateGoodsRateGrpNm = value; }
        }

        /// public propaty name  :  RateBLGroupCode
        /// <summary>BL�O���[�v�R�[�h�i�|���j�v���p�e�B</summary>
        /// <value>BL�O���[�v�R�[�h�i�|���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�R�[�h�i�|���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RateBLGroupCode
        {
            get { return _rateBLGroupCode; }
            set {  _rateBLGroupCode = value; }
        }

        /// public propaty name  :  RateBLGroupName
        /// <summary>BL�O���[�v���́i�|���j�v���p�e�B</summary>
        /// <value>BL�O���[�v���́i�|���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v���́i�|���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateBLGroupName
        {
            get { return _rateBLGroupName; }
            set {  _rateBLGroupName = value; }
        }

        /// public propaty name  :  OrderCnt
        /// <summary>�������ʃv���p�e�B</summary>
        /// <value>��������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double OrderCnt
        {
            get { return _orderCnt; }
            set {  _orderCnt = value; }
        }

        /// public propaty name  :  OrderAdjustCnt
        /// <summary>�����������v���p�e�B</summary>
        /// <value>����������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double OrderAdjustCnt
        {
            get { return _orderAdjustCnt; }
            set {  _orderAdjustCnt = value; }
        }

        /// public propaty name  :  OrderRemainCnt
        /// <summary>�����c���v���p�e�B</summary>
        /// <value>�����c��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����c���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double OrderRemainCnt
        {
            get { return _orderRemainCnt; }
            set {  _orderRemainCnt = value; }
        }

        /// public propaty name  :  RemainCntUpdDate
        /// <summary>�c���X�V���v���p�e�B</summary>
        /// <value>�c���X�V��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �c���X�V���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime RemainCntUpdDate
        {
            get { return _remainCntUpdDate; }
            set {  _remainCntUpdDate = value; }
        }

        /// public propaty name  :  StockDtiSlipNote1
        /// <summary>�d���`�[���ה��l1�v���p�e�B</summary>
        /// <value>�d���`�[���ה��l1</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[���ה��l1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockDtiSlipNote1
        {
            get { return _stockDtiSlipNote1; }
            set {  _stockDtiSlipNote1 = value; }
        }

        /// public propaty name  :  SalesCustomerCode
        /// <summary>�̔���R�[�h�v���p�e�B</summary>
        /// <value>�̔���R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesCustomerCode
        {
            get { return _salesCustomerCode; }
            set {  _salesCustomerCode = value; }
        }

        /// public propaty name  :  SalesCustomerSnm
        /// <summary>�̔��旪�̃v���p�e�B</summary>
        /// <value>�̔��旪��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesCustomerSnm
        {
            get { return _salesCustomerSnm; }
            set {  _salesCustomerSnm = value; }
        }

        /// public propaty name  :  SlipMemo1
        /// <summary>�`�[�����P�v���p�e�B</summary>
        /// <value>�`�[�����P</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�����P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipMemo1
        {
            get { return _slipMemo1; }
            set {  _slipMemo1 = value; }
        }

        /// public propaty name  :  SlipMemo2
        /// <summary>�`�[�����Q�v���p�e�B</summary>
        /// <value>�`�[�����Q</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�����Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipMemo2
        {
            get { return _slipMemo2; }
            set {  _slipMemo2 = value; }
        }

        /// public propaty name  :  SlipMemo3
        /// <summary>�`�[�����R�v���p�e�B</summary>
        /// <value>�`�[�����R</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�����R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipMemo3
        {
            get { return _slipMemo3; }
            set {  _slipMemo3 = value; }
        }

        /// public propaty name  :  InsideMemo1
        /// <summary>�Г������P�v���p�e�B</summary>
        /// <value>�Г������P</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Г������P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InsideMemo1
        {
            get { return _insideMemo1; }
            set {  _insideMemo1 = value; }
        }

        /// public propaty name  :  InsideMemo2
        /// <summary>�Г������Q�v���p�e�B</summary>
        /// <value>�Г������Q</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Г������Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InsideMemo2
        {
            get { return _insideMemo2; }
            set {  _insideMemo2 = value; }
        }

        /// public propaty name  :  InsideMemo3
        /// <summary>�Г������R�v���p�e�B</summary>
        /// <value>�Г������R</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Г������R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InsideMemo3
        {
            get { return _insideMemo3; }
            set {  _insideMemo3 = value; }
        }

        /// public propaty name  :  AddresseeCode
        /// <summary>�[�i��R�[�h�v���p�e�B</summary>
        /// <value>�[�i��R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddresseeCode
        {
            get { return _addresseeCode; }
            set {  _addresseeCode = value; }
        }

        /// public propaty name  :  AddresseeName
        /// <summary>�[�i�於�̃v���p�e�B</summary>
        /// <value>�[�i�於��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseeName
        {
            get { return _addresseeName; }
            set {  _addresseeName = value; }
        }

        /// public propaty name  :  DirectSendingCd
        /// <summary>�����敪�v���p�e�B</summary>
        /// <value>�����敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DirectSendingCd
        {
            get { return _directSendingCd; }
            set {  _directSendingCd = value; }
        }

        /// public propaty name  :  OrderNumber
        /// <summary>�����ԍ��v���p�e�B</summary>
        /// <value>�����ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OrderNumber
        {
            get { return _orderNumber; }
            set {  _orderNumber = value; }
        }

        /// public propaty name  :  WayToOrder
        /// <summary>�������@�v���p�e�B</summary>
        /// <value>�������@</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������@�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 WayToOrder
        {
            get { return _wayToOrder; }
            set {  _wayToOrder = value; }
        }

        /// public propaty name  :  DeliGdsCmpltDueDate
        /// <summary>�[�i�����\����v���p�e�B</summary>
        /// <value>�[�i�����\���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�����\����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime DeliGdsCmpltDueDate
        {
            get { return _deliGdsCmpltDueDate; }
            set {  _deliGdsCmpltDueDate = value; }
        }

        /// public propaty name  :  ExpectDeliveryDate
        /// <summary>��]�[���v���p�e�B</summary>
        /// <value>��]�[��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��]�[���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ExpectDeliveryDate
        {
            get { return _expectDeliveryDate; }
            set {  _expectDeliveryDate = value; }
        }

        /// public propaty name  :  OrderDataCreateDiv
        /// <summary>�����f�[�^�쐬�敪�v���p�e�B</summary>
        /// <value>�����f�[�^�쐬�敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����f�[�^�쐬�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OrderDataCreateDiv
        {
            get { return _orderDataCreateDiv; }
            set {  _orderDataCreateDiv = value; }
        }

        /// public propaty name  :  OrderDataCreateDate
        /// <summary>�����f�[�^�쐬���v���p�e�B</summary>
        /// <value>�����f�[�^�쐬��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����f�[�^�쐬���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime OrderDataCreateDate
        {
            get { return _orderDataCreateDate; }
            set {  _orderDataCreateDate = value; }
        }

        /// public propaty name  :  OrderFormIssuedDiv
        /// <summary>���������s�ϋ敪�v���p�e�B</summary>
        /// <value>���������s�ϋ敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������s�ϋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OrderFormIssuedDiv
        {
            get { return _orderFormIssuedDiv; }
            set {  _orderFormIssuedDiv = value; }
        }

        /// public propaty name  :  EnterpriseGanreName
        /// <summary>���Е��ޖ��̃v���p�e�B</summary>
        /// <value>���Е��ޖ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Е��ޖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseGanreName
        {
            get { return _enterpriseGanreName; }
            set { _enterpriseGanreName = value; }
        }

        /// public propaty name  :  GoodsRateRank
        /// <summary>���i�|�������N�v���p�e�B</summary>
        /// <value>���i�|�������N</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�|�������N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsRateRank
        {
            get { return _goodsRateRank; }
            set { _goodsRateRank = value; }
        }

                /// public propaty name  :  CustRateGrpCode
        /// <summary>���Ӑ�|���O���[�v�R�[�h�v���p�e�B</summary>
        /// <value>���Ӑ�|���O���[�v�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�|���O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustRateGrpCode
        {
            get { return _custRateGrpCode; }
            set { _custRateGrpCode = value; }
        }

        /// public propaty name  :  SuppRateGrpCode
        /// <summary>�d����|���O���[�v�R�[�h�v���p�e�B</summary>
        /// <value>�d����|���O���[�v�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����|���O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SuppRateGrpCode
        {
            get { return _suppRateGrpCode; }
            set { _suppRateGrpCode = value; }
        }

        /// public propaty name  :  ListPriceTaxIncFl
        /// <summary>�艿�i�ō��C�����j�v���p�e�B</summary>
        /// <value>�艿�i�ō��C�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�i�ō��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ListPriceTaxIncFl
        {
            get { return _listPriceTaxIncFl; }
            set { _listPriceTaxIncFl = value; }
        }

        /// public propaty name  :  StockRate
        /// <summary>�d�����v���p�e�B</summary>
        /// <value>�d����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockRate
        {
            get { return _stockRate; }
            set { _stockRate = value; }
        }

        /// public propaty name  :  StockAddUpSectionCd
        /// <summary>�d���v�㋒�_�R�[�h�v���p�e�B</summary>
        /// <value>�d���v�㋒�_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���v�㋒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockAddUpSectionCd
        {
            get { return _stockAddUpSectionCd; }
            set { _stockAddUpSectionCd = value; }
        }

        /// public propaty name  :  BusinessTypeCode
        /// <summary>�Ǝ�R�[�h[�d��]�v���p�e�B</summary>
        /// <value>�Ǝ�R�[�h[�d��]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǝ�R�[�h[�d��]</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BusinessTypeCode
        {
            get { return _businessTypeCode; }
            set { _businessTypeCode = value; }
        }

        /// public propaty name  :  BusinessTypeName
        /// <summary>�Ǝ햼��[�d��]�v���p�e�B</summary>
        /// <value>�Ǝ햼��[�d��]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǝ햼��[�d��]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BusinessTypeName
        {
            get { return _businessTypeName; }
            set { _businessTypeName = value; }
        }

        /// public propaty name  :  SalesAreaCode
        /// <summary>�̔��G���A�R�[�h[�d��]�v���p�e�B</summary>
        /// <value>>�̔��G���A�R�[�h[�d��]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   >�̔��G���A�R�[�h[�d��]</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesAreaCode
        {
            get { return _salesAreaCode; }
            set { _salesAreaCode = value; }
        }

        /// public propaty name  :  SalesAreaName
        /// <summary>�̔��G���A����[�d��]�v���p�e�B</summary>
        /// <value>�̔��G���A����[�d��]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��G���A����[�d��]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesAreaName
        {
            get { return _salesAreaName; }
            set { _salesAreaName = value; }
        }

        /// public propaty name  :  TtlAmntDispRateApy
        /// <summary>���z�\���|���K�p�敪[�d��]�v���p�e�B</summary>
        /// <value>���z�\���|���K�p�敪[�d��]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���z�\���|���K�p�敪[�d��]</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TtlAmntDispRateApy
        {
            get { return _ttlAmntDispRateApy; }
            set { _ttlAmntDispRateApy = value; }
        }

        /// public propaty name  :  StockFractionProcCd
        /// <summary>�d���[�������敪[�d��]�v���p�e�B</summary>
        /// <value>�d���[�������敪[�d��]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���[�������敪[�d��]</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockFractionProcCd
        {
            get { return _stockFractionProcCd; }
            set { _stockFractionProcCd = value; }
        }

        /// public propaty name  :  SlipAddressDiv
        /// <summary>�`�[�Z���敪[�d��]�v���p�e�B</summary>
        /// <value>�`�[�Z���敪[�d��]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�Z���敪[�d��]</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipAddressDiv
        {
            get { return _slipAddressDiv; }
            set { _slipAddressDiv = value; }
        }

        /// public propaty name  :  SlpAddresseeCode
        /// <summary>�[�i��R�[�h[�d��]�v���p�e�B</summary>
        /// <value>�[�i��R�[�h[�d��]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��R�[�h[�d��]</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlpAddresseeCode
        {
            get { return _slpAddresseeCode; }
            set { _slpAddresseeCode = value; }
        }

        /// public propaty name  :  SlpAddresseeName
        /// <summary>�[�i�於��[�d��]�v���p�e�B</summary>
        /// <value>�[�i�於��[�d��]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�於��[�d��]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlpAddresseeName
        {
            get { return _slpAddresseeName; }
            set { _slpAddresseeName = value; }
        }

        /// public propaty name  :  AddresseeName2
        /// <summary>�[�i�於��2[�d��]�v���p�e�B</summary>
        /// <value>�[�i�於��2[�d��]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�於��2[�d��]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseeName2
        {
            get { return _addresseeName2; }
            set { _addresseeName2 = value; }
        }

        /// public propaty name  :  AddresseePostNo
        /// <summary>�[�i��X�֔ԍ�[�d��]�v���p�e�B</summary>
        /// <value>�[�i��X�֔ԍ�[�d��]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��X�֔ԍ�[�d��]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseePostNo
        {
            get { return _addresseePostNo; }
            set { _addresseePostNo = value; }
        }

        /// public propaty name  :  AddresseeAddr1
        /// <summary>�[�i��Z��1_�s���{���s��S�E�����E��[�d��]�v���p�e�B</summary>
        /// <value>>�[�i��Z��1_�s���{���s��S�E�����E��[�d��]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  >�[�i��Z��1_�s���{���s��S�E�����E��[�d��]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseeAddr1
        {
            get { return _addresseeAddr1; }
            set { _addresseeAddr1 = value; }
        }

        /// public propaty name  :  AddresseeAddr3
        /// <summary>�[�i��Z��3_�Ԓn[�d��]�v���p�e�B</summary>
        /// <value>>�[�i��Z��3_�Ԓn[�d��]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��Z��3_�Ԓn[�d��]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseeAddr3
        {
            get { return _addresseeAddr3; }
            set { _addresseeAddr3 = value; }
        }

        /// public propaty name  :  AddresseeAddr4
        /// <summary>�[�i��Z��4_�A�p�[�g����[�d��]�v���p�e�B</summary>
        /// <value>�[�i��Z��4_�A�p�[�g����[�d��]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��Z��4_�A�p�[�g����[�d��]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseeAddr4
        {
            get { return _addresseeAddr4; }
            set { _addresseeAddr4 = value; }
        }

        /// public propaty name  :  AddresseeTelNo
        /// <summary>�[�i��d�b�ԍ�[�d��]�v���p�e�B</summary>
        /// <value>�[�i��d�b�ԍ�[�d��]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��d�b�ԍ�[�d��]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseeTelNo
        {
            get { return _addresseeTelNo; }
            set { _addresseeTelNo = value; }
        }

        /// public propaty name  :  AddresseeFaxNo
        /// <summary>�[�i��FAX�ԍ�[�d��]�v���p�e�B</summary>
        /// <value>�[�i��FAX�ԍ�[�d��]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��FAX�ԍ�[�d��]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseeFaxNo
        {
            get { return _addresseeFaxNo; }
            set { _addresseeFaxNo = value; }
        }

        /// public propaty name  :  SlpDirectSendingCd
        /// <summary>�����敪[�d��]�v���p�e�B</summary>
        /// <value>�����敪[�d��]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪[�d��]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlpDirectSendingCd
        {
            get { return _slpDirectSendingCd; }
            set { _slpDirectSendingCd = value; }
        }
        // ----------ADD 2013/01/21-----------<<<<<

        /// <summary>
        /// �d����d�q�������o����(�`�[�E����)�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SuppPrtPprStcTblRsltWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprStcTblRsltWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SuppPrtPprStcTblRsltWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SuppPrtPprStcTblRsltWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprStcTblRsltWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SuppPrtPprStcTblRsltWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprStcTblRsltWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note: 2009/09/08 ���̕� �ߋ����\���Ή�</br>
        /// </remarks>
        public void Serialize( System.IO.BinaryWriter writer, object graph )
        {
            // TODO:  SuppPrtPprStcTblRsltWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if ( writer == null )
                throw new ArgumentNullException();

            if ( graph != null && !(graph is SuppPrtPprStcTblRsltWork || graph is ArrayList || graph is SuppPrtPprStcTblRsltWork[]) )
                throw new ArgumentException( string.Format( "graph��{0}�̃C���X�^���X�ł���܂���", typeof( SuppPrtPprStcTblRsltWork ).FullName ) );

            if ( graph != null && graph is SuppPrtPprStcTblRsltWork )
            {
                Type t = graph.GetType();
                if ( !CustomFormatterServices.NeedCustomSerialization( t ) )
                    throw new ArgumentException( string.Format( "graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName ) );
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SuppPrtPprStcTblRsltWork" );

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if ( graph is ArrayList )
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if ( graph is SuppPrtPprStcTblRsltWork[] )
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SuppPrtPprStcTblRsltWork[])graph).Length;
            }
            else if ( graph is SuppPrtPprStcTblRsltWork )
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�f�[�^�敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DataDiv
            //�`�[���t
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //StockDate
            //�`�[�ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //PartySaleSlipNum
            //�s��(���ו\��)
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //StockRowNo
            //�d���`��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SupplierFormal
            //�d���`�[�敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SupplierSlipCd
            //�S���Җ�
            serInfo.MemberInfo.Add( typeof( string ) ); //StockAgentName
            //���z
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //StockTtlPricTaxExc
            //�i��(���ו\��)
            serInfo.MemberInfo.Add( typeof( string ) ); //GoodsName
            //�i��(���ו\��)
            serInfo.MemberInfo.Add( typeof( string ) ); //GoodsNo
            //���[�J�[�R�[�h(���ו\��)
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //GoodsMakerCd
            //���[�J�[����
            serInfo.MemberInfo.Add( typeof( string ) ); //MakerName
            //BL�R�[�h(���ו\��)
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //BLGoodsCode
            //BL�O���[�v(���ו\��)
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //BLGroupCode
            //����(���ו\��)
            serInfo.MemberInfo.Add( typeof( Double ) ); //StockCount
            //�W�����i(���ו\��)
            serInfo.MemberInfo.Add( typeof( Double ) ); //ListPriceTaxExcFl
            //�I�[�v�����i�敪(���ו\��)
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //OpenPriceDiv
            //�d�������œ]�ŕ����R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SuppCTaxLayCd
            //�d�����z�v�i�ō��݁j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //StockTtlPricTaxInc
            //�d�����z����Ŋz
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //StockPriceConsTax
            //���l�P
            serInfo.MemberInfo.Add( typeof( string ) ); //SupplierSlipNote1
            //���l�Q
            serInfo.MemberInfo.Add( typeof( string ) ); //SupplierSlipNote2
            //���_
            serInfo.MemberInfo.Add( typeof( string ) ); //SectionGuideNm
            //���s��
            // serInfo.MemberInfo.Add( typeof( string ) ); //StockInputName // DEL 2009/09/08
            //�d����R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SupplierCd
            //�d���於
            serInfo.MemberInfo.Add( typeof( string ) ); //SupplierSnm
            //�ݎ�(���ו\��)
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //StockOrderDivCd
            //�q��(���ו\��)
            serInfo.MemberInfo.Add( typeof( string ) ); //WarehouseName
            //�I��(���ו\��)
            serInfo.MemberInfo.Add( typeof( string ) ); //WarehouseShelfNo
            //�t�n�d���}�[�N�P
            serInfo.MemberInfo.Add( typeof( string ) ); //UoeRemark1
            //�t�n�d���}�[�N�Q
            serInfo.MemberInfo.Add( typeof( string ) ); //UoeRemark2
            //�d��SEQ/�x����
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SupplierSlipNo
            //�v���
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //StockAddUpADate
            //���|�敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //AccPayDivCd
            //�ԓ`�敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DebitNoteDiv
            //��������`�[�ԍ�(���ו\��)
            serInfo.MemberInfo.Add( typeof( string ) ); //SalesSlipNum
            //����������t(���ו\��)
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SalesDate
            //���Ӑ�R�[�h(���ו\��)
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CustomerCode
            //���Ӑ於(���ו\��)
            serInfo.MemberInfo.Add( typeof( string ) ); //CustomerSnm
            //���_�R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //SectionCode
            //�q�ɃR�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //WarehouseCode
            //�d���摍�z�\�����@�敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SuppTtlAmntDspWayCd
            //�ېŋ敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //TaxationCode
            //�d�����z����Ŋz�i���Łj[�`�[]
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //StckPrcConsTaxInclu
            //�d���l������Ŋz�i���Łj[�`�[]
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //StckDisTtlTaxInclu
            //�d���P���i�Ŕ��C�����j[����]
            serInfo.MemberInfo.Add( typeof( Double ) ); //StockUnitPriceFl
            //�d�����z�i�Ŕ����j[����]
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //StockPriceTaxExc
            //�d�����z�i�ō��݁j[����]
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //StockPriceTaxInc
            //�d�����i�敪[�`�[]
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //StockGoodsCd
            //�d�����z����Ŋz[����]
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //StockPriceConsTaxDtl
            //�d���`�[�敪�i���ׁj[����]
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //StockSlipCdDtl
            //�萔���x���z[�x��]
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //FeePayment
            //�l���x���z[�x��]
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DiscountPayment
            // ----------- ADD 2012/10/15 �c���� Redmine#32862 ------------>>>>>
            //�ύX�O�d���P���i�����j[����]
            serInfo.MemberInfo.Add(typeof(Double)); //BfStockUnitPriceFl
            //�ύX�O�艿[����]
            serInfo.MemberInfo.Add(typeof(Double)); //BfListPrice
            // ----------- ADD 2012/10/15 �c���� Redmine#32862 ------------<<<<<

            // ----------ADD 2013/01/21----------->>>>>
            //�_���폜�敪[�d��]
            serInfo.MemberInfo.Add(typeof(Int32)); //SlpLogicalDeleteCode
            //�_���폜�敪[�d���ڍ�]
            serInfo.MemberInfo.Add(typeof(Int32)); //DtlLogicalDeleteCode
            //����R�[�h[�d��]
            serInfo.MemberInfo.Add(typeof(Int32)); //SlpSubSectionCode
            //�d�����_�R�[�h[�d��]
            serInfo.MemberInfo.Add(typeof(string)); //StockSectionCd
            //�d�������Őŗ�[�d��]
            serInfo.MemberInfo.Add(typeof(Double)); //SupplierConsTaxRate
            //���͓�[�d��]
            serInfo.MemberInfo.Add(typeof(Int32)); //InputDay
            //����R�[�h[�d������]
            serInfo.MemberInfo.Add(typeof(Int32)); //DtlSubSectionCode
            //�󒍔ԍ�[�d������]
            serInfo.MemberInfo.Add(typeof(Int32)); //AcceptAnOrderNo
            //���ʒʔ�[�d������]
            serInfo.MemberInfo.Add(typeof(Int64)); //CommonSeqNo
            //�d�����גʔ�[�d������]
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSlipDtlNum
            //�d���`���i���j[�d������]
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormalSrc
            //�d�����גʔԁi���j[�d������]
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSlipDtlNumSrc
            //�󒍃X�e�[�^�X�i�����j[�d������]
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatusSync
            //���㖾�גʔԁi�����j[�d������]
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesSlipDtlNumSync

            //�d�����͎҃R�[�h[�d������]
            serInfo.MemberInfo.Add(typeof(string)); //StockInputCode
            //�d���S���҃R�[�h[�d������]
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentCode
            //���i����[�d������]
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsKindCode
            //���[�J�[�J�i����[�d������]
            serInfo.MemberInfo.Add(typeof(string)); //MakerKanaName
            //���[�J�[�J�i���́i�ꎮ�j[�d������]
            serInfo.MemberInfo.Add(typeof(string)); //CmpltMakerKanaName
            //���i���̃J�i[�d������]
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNameKana
            //���i�啪�ރR�[�h[�d������]
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsLGroup
            //���i�啪�ޖ���[�d������]
            serInfo.MemberInfo.Add(typeof(string)); //GoodsLGroupName
            //���i�����ރR�[�h[�d������]
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //���i�����ޖ���[�d������]
            serInfo.MemberInfo.Add(typeof(string)); //GoodsMGroupName
            //BL�O���[�v�R�[�h����[�d������]
            serInfo.MemberInfo.Add(typeof(string)); //BLGroupName
            //BL���i�R�[�h���́i�S�p�j[�d������]
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsFullName
            //���Е��ރR�[�h[�d������]
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterpriseGanreCode
            //�|���ݒ苒�_�i�d���P���j[�d������]
            serInfo.MemberInfo.Add(typeof(string)); //RateSectStckUnPrc
            //�|���ݒ�敪�i�d���P���j[�d������]
            serInfo.MemberInfo.Add(typeof(string)); //RateDivStckUnPrc
            //�P���Z�o�敪�i�d���P���j[�d������]
            serInfo.MemberInfo.Add(typeof(Int32)); //UnPrcCalcCdStckUnPrc
            //���i�敪�i�d���P���j[�d������]
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceCdStckUnPrc
            //��P���i�d���P���j[�d������]
            serInfo.MemberInfo.Add(typeof(Double)); //StdUnPrcStckUnPrc
            //�[�������P�ʁi�d���P���j[�d������]
            serInfo.MemberInfo.Add(typeof(Double)); //FracProcUnitStcUnPrc
            //�[�������i�d���P���j[�d������]
            serInfo.MemberInfo.Add(typeof(Int32)); //FracProcStckUnPrc
            //�d���P���i�ō��C�����j[�d������]
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitTaxPriceFl
            //�d���P���ύX�敪[�d������]
            serInfo.MemberInfo.Add(typeof(Int32)); //StockUnitChngDiv
            //BL���i�R�[�h�i�|���j[�d������]
            serInfo.MemberInfo.Add(typeof(Int32)); //RateBLGoodsCode
            //BL���i�R�[�h���́i�|���j[�d������]
            serInfo.MemberInfo.Add(typeof(string)); //RateBLGoodsName
            //���i�|���O���[�v�R�[�h�i�|���j[�d������]
            serInfo.MemberInfo.Add(typeof(Int32)); //RateGoodsRateGrpCd
            //���i�|���O���[�v���́i�|���j[�d������]
            serInfo.MemberInfo.Add(typeof(string)); //RateGoodsRateGrpNm
            //BL�O���[�v�R�[�h�i�|���j[�d������]
            serInfo.MemberInfo.Add(typeof(Int32)); //RateBLGroupCode
            //BL�O���[�v���́i�|���j[�d������]
            serInfo.MemberInfo.Add(typeof(string)); //RateBLGroupName
            //��������[�d������]
            serInfo.MemberInfo.Add(typeof(Double)); //OrderCnt
            //����������[�d������]
            serInfo.MemberInfo.Add(typeof(Double)); //OrderAdjustCnt
            //�����c��[�d������]
            serInfo.MemberInfo.Add(typeof(Double)); //OrderRemainCnt
            //�c���X�V��[�d������]
            serInfo.MemberInfo.Add(typeof(Int32)); //RemainCntUpdDate
            //�d���`�[���ה��l1[�d������]
            serInfo.MemberInfo.Add(typeof(string)); //StockDtiSlipNote1
            //�̔���R�[�h[�d������]
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCustomerCode
            //�̔��旪��[�d������]
            serInfo.MemberInfo.Add(typeof(string)); //SalesCustomerSnm
            //�`�[�����P[�d������]
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo1
            //�`�[�����Q[�d������]
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo2
            //�`�[�����R[�d������]
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo3
            //�Г������P[�d������]
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo1
            //�Г������Q[�d������]
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo2
            //�Г������R[�d������]
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo3
            //�[�i��R�[�h[�d������]
            serInfo.MemberInfo.Add(typeof(Int32)); //AddresseeCode
            //�[�i�於��[�d������]
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeName
            //�����敪[�d������]
            serInfo.MemberInfo.Add(typeof(Int32)); //DirectSendingCd
            //�����ԍ�[�d������]
            serInfo.MemberInfo.Add(typeof(string)); //OrderNumber
            //�������@[�d������]
            serInfo.MemberInfo.Add(typeof(Int32)); //WayToOrder
            //�[�i�����\���[�d������]
            serInfo.MemberInfo.Add(typeof(Int32)); //DeliGdsCmpltDueDate
            //��]�[��[�d������]
            serInfo.MemberInfo.Add(typeof(Int32)); //ExpectDeliveryDate
            //�����f�[�^�쐬�敪[�d������]
            serInfo.MemberInfo.Add(typeof(Int32)); //OrderDataCreateDiv
            //�����f�[�^�쐬��[�d������]
            serInfo.MemberInfo.Add(typeof(Int32)); //OrderDataCreateDate
            //���������s�ϋ敪[�d������]
            serInfo.MemberInfo.Add(typeof(Int32)); //OrderFormIssuedDiv

            //���Е��ޖ���[�d������]
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseGanreName
            //���i�|�������N[�d������]
            serInfo.MemberInfo.Add(typeof(string)); //GoodsRateRank
            //���Ӑ�|���O���[�v�R�[�h[�d������]
            serInfo.MemberInfo.Add(typeof(Int32)); //CustRateGrpCode
            //�d����|���O���[�v�R�[�h[�d������]
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppRateGrpCode
            //�艿�i�ō��C�����j[�d������]
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxIncFl
            //�d����[�d������]
            serInfo.MemberInfo.Add(typeof(Double)); //StockRate
            //�d���v�㋒�_�R�[�h[�d��]
            serInfo.MemberInfo.Add(typeof(string)); //StockAddUpSectionCd
            //�Ǝ�R�[�h[�d��]
            serInfo.MemberInfo.Add(typeof(Int32)); //BusinessTypeCode
            //�Ǝ햼��[�d��]
            serInfo.MemberInfo.Add(typeof(string)); //BusinessTypeName
            //�̔��G���A�R�[�h[�d��]
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesAreaCode
            //�̔��G���A����[�d��]
            serInfo.MemberInfo.Add(typeof(string)); //SalesAreaName
            //���z�\���|���K�p�敪[�d��]
            serInfo.MemberInfo.Add(typeof(Int32)); //TtlAmntDispRateApy
            //�d���[�������敪[�d��]
            serInfo.MemberInfo.Add(typeof(Int32)); //StockFractionProcCd

            //�`�[�Z���敪[�d��]
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipAddressDiv
            //�[�i��R�[�h[�d��]
            serInfo.MemberInfo.Add(typeof(Int32)); //SlpAddresseeCode
            //�[�i�於��[�d��]
            serInfo.MemberInfo.Add(typeof(string)); //SlpAddresseeName
            //�[�i�於��2[�d��]
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeName2
            //�[�i��X�֔ԍ�[�d��]
            serInfo.MemberInfo.Add(typeof(string)); //AddresseePostNo
            //�[�i��Z��1_�s���{���s��S�E�����E��[�d��]
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeAddr1
            //�[�i��Z��3_�Ԓn[�d��]
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeAddr3
            //�[�i��Z��4_�A�p�[�g����[�d��]
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeAddr4
            //�[�i��d�b�ԍ�[�d��]
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeTelNo
            //�[�i��FAX�ԍ�[�d��]
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeFaxNo
            //�����敪[�d��]
            serInfo.MemberInfo.Add(typeof(Int32)); //SlpDirectSendingCd

            // ----------ADD 2013/01/21-----------<<<<<

            serInfo.Serialize( writer, serInfo );
            if ( graph is SuppPrtPprStcTblRsltWork )
            {
                SuppPrtPprStcTblRsltWork temp = (SuppPrtPprStcTblRsltWork)graph;

                SetSuppPrtPprStcTblRsltWork( writer, temp );
            }
            else
            {
                ArrayList lst = null;
                if ( graph is SuppPrtPprStcTblRsltWork[] )
                {
                    lst = new ArrayList();
                    lst.AddRange( (SuppPrtPprStcTblRsltWork[])graph );
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach ( SuppPrtPprStcTblRsltWork temp in lst )
                {
                    SetSuppPrtPprStcTblRsltWork( writer, temp );
                }

            }


        }


        /// <summary>
        /// SuppPrtPprStcTblRsltWork�����o��(public�v���p�e�B��)
        /// </summary>
        // private const int currentMemberCount = 53; // DEL 2009/09/08
        //private const int currentMemberCount = 52; // ADD 2009/09/08 // DEL 2012/10/15 �c���� Redmine#32862
        //private const int currentMemberCount = 54; // ADD 2012/10/15 �c���� Redmine#32862 //DEL 2013/01/21
        private const int currentMemberCount = 143; // ADD 2013/01/21

        /// <summary>
        ///  SuppPrtPprStcTblRsltWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprStcTblRsltWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note: 2009/09/08 ���̕� �ߋ����\���Ή�</br>
        /// </remarks>
        private void SetSuppPrtPprStcTblRsltWork( System.IO.BinaryWriter writer, SuppPrtPprStcTblRsltWork temp )
        {
            //�f�[�^�敪
            writer.Write( temp.DataDiv );
            //�`�[���t
            writer.Write( (Int64)temp.StockDate.Ticks );
            //�`�[�ԍ�
            writer.Write( temp.PartySaleSlipNum );
            //�s��(���ו\��)
            writer.Write( temp.StockRowNo );
            //�d���`��
            writer.Write( temp.SupplierFormal );
            //�d���`�[�敪
            writer.Write( temp.SupplierSlipCd );
            //�S���Җ�
            writer.Write( temp.StockAgentName );
            //���z
            writer.Write( temp.StockTtlPricTaxExc );
            //�i��(���ו\��)
            writer.Write( temp.GoodsName );
            //�i��(���ו\��)
            writer.Write( temp.GoodsNo );
            //���[�J�[�R�[�h(���ו\��)
            writer.Write( temp.GoodsMakerCd );
            //���[�J�[����
            writer.Write( temp.MakerName );
            //BL�R�[�h(���ו\��)
            writer.Write( temp.BLGoodsCode );
            //BL�O���[�v(���ו\��)
            writer.Write( temp.BLGroupCode );
            //����(���ו\��)
            writer.Write( temp.StockCount );
            //�W�����i(���ו\��)
            writer.Write( temp.ListPriceTaxExcFl );
            //�I�[�v�����i�敪(���ו\��)
            writer.Write( temp.OpenPriceDiv );
            //�d�������œ]�ŕ����R�[�h
            writer.Write( temp.SuppCTaxLayCd );
            //�d�����z�v�i�ō��݁j
            writer.Write( temp.StockTtlPricTaxInc );
            //�d�����z����Ŋz
            writer.Write( temp.StockPriceConsTax );
            //���l�P
            writer.Write( temp.SupplierSlipNote1 );
            //���l�Q
            writer.Write( temp.SupplierSlipNote2 );
            //���_
            writer.Write( temp.SectionGuideNm );
            //���s��
            // writer.Write( temp.StockInputName ); // DEL 2009/09/08
            //�d����R�[�h
            writer.Write( temp.SupplierCd );
            //�d���於
            writer.Write( temp.SupplierSnm );
            //�ݎ�(���ו\��)
            writer.Write( temp.StockOrderDivCd );
            //�q��(���ו\��)
            writer.Write( temp.WarehouseName );
            //�I��(���ו\��)
            writer.Write( temp.WarehouseShelfNo );
            //�t�n�d���}�[�N�P
            writer.Write( temp.UoeRemark1 );
            //�t�n�d���}�[�N�Q
            writer.Write( temp.UoeRemark2 );
            //�d��SEQ/�x����
            writer.Write( temp.SupplierSlipNo );
            //�v���
            writer.Write( (Int64)temp.StockAddUpADate.Ticks );
            //���|�敪
            writer.Write( temp.AccPayDivCd );
            //�ԓ`�敪
            writer.Write( temp.DebitNoteDiv );
            //��������`�[�ԍ�(���ו\��)
            writer.Write( temp.SalesSlipNum );
            //����������t(���ו\��)
            writer.Write( (Int64)temp.SalesDate.Ticks );
            //���Ӑ�R�[�h(���ו\��)
            writer.Write( temp.CustomerCode );
            //���Ӑ於(���ו\��)
            writer.Write( temp.CustomerSnm );
            //���_�R�[�h
            writer.Write( temp.SectionCode );
            //�q�ɃR�[�h
            writer.Write( temp.WarehouseCode );
            //�d���摍�z�\�����@�敪
            writer.Write( temp.SuppTtlAmntDspWayCd );
            //�ېŋ敪
            writer.Write( temp.TaxationCode );
            //�d�����z����Ŋz�i���Łj[�`�[]
            writer.Write( temp.StckPrcConsTaxInclu );
            //�d���l������Ŋz�i���Łj[�`�[]
            writer.Write( temp.StckDisTtlTaxInclu );
            //�d���P���i�Ŕ��C�����j[����]
            writer.Write( temp.StockUnitPriceFl );
            //�d�����z�i�Ŕ����j[����]
            writer.Write( temp.StockPriceTaxExc );
            //�d�����z�i�ō��݁j[����]
            writer.Write( temp.StockPriceTaxInc );
            //�d�����i�敪[�`�[]
            writer.Write( temp.StockGoodsCd );
            //�d�����z����Ŋz[����]
            writer.Write( temp.StockPriceConsTaxDtl );
            //�d���`�[�敪�i���ׁj[����]
            writer.Write( temp.StockSlipCdDtl );
            //�萔���x���z[�x��]
            writer.Write( temp.FeePayment );
            //�l���x���z[�x��]
            writer.Write( temp.DiscountPayment );
            // ----------- ADD 2012/10/15 �c���� Redmine#32862 ------------>>>>>
            //�ύX�O�d���P���i�����j[����]
            writer.Write(temp.BfStockUnitPriceFl);
            //�ύX�O�艿[����]
            writer.Write(temp.BfListPrice);
            // ----------- ADD 2012/10/15 �c���� Redmine#32862 ------------<<<<<

            // ----------ADD 2013/01/21----------->>>>>
            //�_���폜�敪[�d��]
            writer.Write(temp.SlpLogicalDeleteCode);
            //�_���폜�敪[�d���ڍ�
            writer.Write(temp.DtlLogicalDeleteCode);
            //����R�[�h[�d��]
            writer.Write(temp.SlpSubSectionCode);
            //�d�����_�R�[�h[�d��]
            writer.Write(temp.StockSectionCd);
            //�d�������Őŗ�[�d��]
            writer.Write(temp.SupplierConsTaxRate);
            //���͓�[�d��]
            writer.Write((Int64)temp.InputDay.Ticks);
            //����R�[�h[�d������]
            writer.Write(temp.DtlSubSectionCode);
            //�󒍔ԍ�[�d������]
            writer.Write(temp.AcceptAnOrderNo);
            //���ʒʔ�[�d������]
            writer.Write(temp.CommonSeqNo);
            //�d�����גʔ�[�d������]
            writer.Write(temp.StockSlipDtlNum);
            //�d���`���i���j[�d������]
            writer.Write(temp.SupplierFormalSrc);
            //�d�����גʔԁi���j[�d������]
            writer.Write(temp.StockSlipDtlNumSrc);
            //�󒍃X�e�[�^�X�i�����j[�d������]
            writer.Write(temp.AcptAnOdrStatusSync);
            //���㖾�גʔԁi�����j[�d������]
            writer.Write(temp.SalesSlipDtlNumSync);

            //�d�����͎҃R�[�h[�d������]
            writer.Write(temp.StockInputCode);
            //�d���S���҃R�[�h[�d������]
            writer.Write(temp.StockAgentCode);
            //���i����[�d������]
            writer.Write(temp.GoodsKindCode);
            //���[�J�[�J�i����[�d������]
            writer.Write(temp.MakerKanaName);
            //���[�J�[�J�i���́i�ꎮ�j[�d������]
            writer.Write(temp.CmpltMakerKanaName);
            //���i���̃J�i[�d������]
            writer.Write(temp.GoodsNameKana);
            //���i�啪�ރR�[�h[�d������]
            writer.Write(temp.GoodsLGroup);
            //���i�啪�ޖ���[�d������]
            writer.Write(temp.GoodsLGroupName);
            //���i�����ރR�[�h[�d������]
            writer.Write(temp.GoodsMGroup);
            //���i�����ޖ���[�d������]
            writer.Write(temp.GoodsMGroupName);
            //BL�O���[�v�R�[�h����[�d������]
            writer.Write(temp.BLGroupName);
            //BL���i�R�[�h���́i�S�p�j[�d������]
            writer.Write(temp.BLGoodsFullName);
            //���Е��ރR�[�h[�d������]
            writer.Write(temp.EnterpriseGanreCode);
            //�|���ݒ苒�_�i�d���P���j[�d������]
            writer.Write(temp.RateSectStckUnPrc);
            //�|���ݒ�敪�i�d���P���j[�d������]
            writer.Write(temp.RateDivStckUnPrc);
            //�P���Z�o�敪�i�d���P���j[�d������]
            writer.Write(temp.UnPrcCalcCdStckUnPrc);
            //���i�敪�i�d���P���j[�d������]
            writer.Write(temp.PriceCdStckUnPrc);
            //��P���i�d���P���j[�d������]
            writer.Write(temp.StdUnPrcStckUnPrc);
            //�[�������P�ʁi�d���P���j[�d������]
            writer.Write(temp.FracProcUnitStcUnPrc);
            //�[�������i�d���P���j[�d������]
            writer.Write(temp.FracProcStckUnPrc);
            //�d���P���i�ō��C�����j[�d������]
            writer.Write(temp.StockUnitTaxPriceFl);
            //�d���P���ύX�敪[�d������]
            writer.Write(temp.StockUnitChngDiv);
            //BL���i�R�[�h�i�|���j[�d������]
            writer.Write(temp.RateBLGoodsCode);
            //BL���i�R�[�h���́i�|���j[�d������]
            writer.Write(temp.RateBLGoodsName);
            //���i�|���O���[�v�R�[�h�i�|���j[�d������]
            writer.Write(temp.RateGoodsRateGrpCd);
            //���i�|���O���[�v���́i�|���j[�d������]
            writer.Write(temp.RateGoodsRateGrpNm);
            //BL�O���[�v�R�[�h�i�|���j[�d������]
            writer.Write(temp.RateBLGroupCode);
            //BL�O���[�v���́i�|���j[�d������]
            writer.Write(temp.RateBLGroupName);
            //��������[�d������]
            writer.Write(temp.OrderCnt);
            //����������[�d������]
            writer.Write(temp.OrderAdjustCnt);
            //�����c��[�d������]
            writer.Write(temp.OrderRemainCnt);
            //�c���X�V��[�d������]
            writer.Write((Int64)temp.RemainCntUpdDate.Ticks);
            //�d���`�[���ה��l1[�d������]
            writer.Write(temp.StockDtiSlipNote1);
            //�̔���R�[�h[�d������]
            writer.Write(temp.SalesCustomerCode);
            //�̔��旪��[�d������]
            writer.Write(temp.SalesCustomerSnm);
            //�`�[�����P[�d������]
            writer.Write(temp.SlipMemo1);
            //�`�[�����Q[�d������]
            writer.Write(temp.SlipMemo2);
            //�`�[�����R[�d������]
            writer.Write(temp.SlipMemo3);
            //�Г������P[�d������]
            writer.Write(temp.InsideMemo1);
            //�Г������Q[�d������]
            writer.Write(temp.InsideMemo2);
            //�Г������R[�d������]
            writer.Write(temp.InsideMemo3);
            //�[�i��R�[�h[�d������]
            writer.Write(temp.AddresseeCode);
            //�[�i�於��[�d������]
            writer.Write(temp.AddresseeName);
            //�����敪[�d������]
            writer.Write(temp.DirectSendingCd);
            //�����ԍ�[�d������]
            writer.Write(temp.OrderNumber);
            //�������@[�d������]
            writer.Write(temp.WayToOrder);
            //�[�i�����\���[�d������]
            writer.Write((Int64)temp.DeliGdsCmpltDueDate.Ticks);
            //��]�[��[�d������]
            writer.Write((Int64)temp.ExpectDeliveryDate.Ticks);
            //�����f�[�^�쐬�敪[�d������]
            writer.Write(temp.OrderDataCreateDiv);
            //�����f�[�^�쐬��[�d������]
            writer.Write((Int64)temp.OrderDataCreateDate.Ticks);
            //���������s�ϋ敪[�d������]
            writer.Write(temp.OrderFormIssuedDiv);

            //���Е��ޖ���[�d������]
            writer.Write(temp.EnterpriseGanreName);
            //���i�|�������N[�d������]
            writer.Write(temp.GoodsRateRank);
            //���Ӑ�|���O���[�v�R�[�h[�d������]
            writer.Write(temp.CustRateGrpCode);
            //�d����|���O���[�v�R�[�h[�d������]
            writer.Write(temp.SuppRateGrpCode);
            //�艿�i�ō��C�����j[�d������]
            writer.Write(temp.ListPriceTaxIncFl);
            //�d����[�d������]
            writer.Write(temp.StockRate);
            //�d���v�㋒�_�R�[�h[�d��]
            writer.Write(temp.StockAddUpSectionCd);
            //�Ǝ�R�[�h[�d��]
            writer.Write(temp.BusinessTypeCode);
            //�Ǝ햼��[�d��]
            writer.Write(temp.BusinessTypeName);
            //�̔��G���A�R�[�h[�d��]
            writer.Write(temp.SalesAreaCode);
            //�̔��G���A����[�d��]
            writer.Write(temp.SalesAreaName);
            //���z�\���|���K�p�敪[�d��]
            writer.Write(temp.TtlAmntDispRateApy);
            //�d���[�������敪[�d��]
            writer.Write(temp.StockFractionProcCd);

            //�`�[�Z���敪[�d��]
            writer.Write(temp.SlipAddressDiv);
            //�[�i��R�[�h[�d��]
            writer.Write(temp.SlpAddresseeCode);
            //�[�i�於��[�d��]
            writer.Write(temp.SlpAddresseeName);
            //�[�i�於��2[�d��]
            writer.Write(temp.AddresseeName2);
            //�[�i��X�֔ԍ�[�d��]
            writer.Write(temp.AddresseePostNo);
            //�[�i��Z��1_�s���{���s��S�E�����E��[�d��]
            writer.Write(temp.AddresseeAddr1);
            //�[�i��Z��3_�Ԓn[�d��]
            writer.Write(temp.AddresseeAddr3);
            //�[�i��Z��4_�A�p�[�g����[�d��]
            writer.Write(temp.AddresseeAddr4);
            //�[�i��d�b�ԍ�[�d��]
            writer.Write(temp.AddresseeTelNo);
            //�[�i��FAX�ԍ�[�d��]
            writer.Write(temp.AddresseeFaxNo);
            //�����敪[�d��]
            writer.Write(temp.SlpDirectSendingCd);

            // ----------ADD 2013/01/21-----------<<<<<

        }

        /// <summary>
        ///  SuppPrtPprStcTblRsltWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SuppPrtPprStcTblRsltWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprStcTblRsltWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note: 2009/09/08 ���̕� �ߋ����\���Ή�</br>
        /// </remarks>
        private SuppPrtPprStcTblRsltWork GetSuppPrtPprStcTblRsltWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SuppPrtPprStcTblRsltWork temp = new SuppPrtPprStcTblRsltWork();

            //�f�[�^�敪
            temp.DataDiv = reader.ReadInt32();
            //�`�[���t
            temp.StockDate = new DateTime( reader.ReadInt64() );
            //�`�[�ԍ�
            temp.PartySaleSlipNum = reader.ReadString();
            //�s��(���ו\��)
            temp.StockRowNo = reader.ReadInt32();
            //�d���`��
            temp.SupplierFormal = reader.ReadInt32();
            //�d���`�[�敪
            temp.SupplierSlipCd = reader.ReadInt32();
            //�S���Җ�
            temp.StockAgentName = reader.ReadString();
            //���z
            temp.StockTtlPricTaxExc = reader.ReadInt64();
            //�i��(���ו\��)
            temp.GoodsName = reader.ReadString();
            //�i��(���ו\��)
            temp.GoodsNo = reader.ReadString();
            //���[�J�[�R�[�h(���ו\��)
            temp.GoodsMakerCd = reader.ReadInt32();
            //���[�J�[����
            temp.MakerName = reader.ReadString();
            //BL�R�[�h(���ו\��)
            temp.BLGoodsCode = reader.ReadInt32();
            //BL�O���[�v(���ו\��)
            temp.BLGroupCode = reader.ReadInt32();
            //����(���ו\��)
            temp.StockCount = reader.ReadDouble();
            //�W�����i(���ו\��)
            temp.ListPriceTaxExcFl = reader.ReadDouble();
            //�I�[�v�����i�敪(���ו\��)
            temp.OpenPriceDiv = reader.ReadInt32();
            //�d�������œ]�ŕ����R�[�h
            temp.SuppCTaxLayCd = reader.ReadInt32();
            //�d�����z�v�i�ō��݁j
            temp.StockTtlPricTaxInc = reader.ReadInt64();
            //�d�����z����Ŋz
            temp.StockPriceConsTax = reader.ReadInt64();
            //���l�P
            temp.SupplierSlipNote1 = reader.ReadString();
            //���l�Q
            temp.SupplierSlipNote2 = reader.ReadString();
            //���_
            temp.SectionGuideNm = reader.ReadString();
            //���s��
            // temp.StockInputName = reader.ReadString(); // DEL 2009/09/08
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�d���於
            temp.SupplierSnm = reader.ReadString();
            //�ݎ�(���ו\��)
            temp.StockOrderDivCd = reader.ReadInt32();
            //�q��(���ו\��)
            temp.WarehouseName = reader.ReadString();
            //�I��(���ו\��)
            temp.WarehouseShelfNo = reader.ReadString();
            //�t�n�d���}�[�N�P
            temp.UoeRemark1 = reader.ReadString();
            //�t�n�d���}�[�N�Q
            temp.UoeRemark2 = reader.ReadString();
            //�d��SEQ/�x����
            temp.SupplierSlipNo = reader.ReadInt32();
            //�v���
            temp.StockAddUpADate = new DateTime( reader.ReadInt64() );
            //���|�敪
            temp.AccPayDivCd = reader.ReadInt32();
            //�ԓ`�敪
            temp.DebitNoteDiv = reader.ReadInt32();
            //��������`�[�ԍ�(���ו\��)
            temp.SalesSlipNum = reader.ReadString();
            //����������t(���ו\��)
            temp.SalesDate = new DateTime( reader.ReadInt64() );
            //���Ӑ�R�[�h(���ו\��)
            temp.CustomerCode = reader.ReadInt32();
            //���Ӑ於(���ו\��)
            temp.CustomerSnm = reader.ReadString();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //�q�ɃR�[�h
            temp.WarehouseCode = reader.ReadString();
            //�d���摍�z�\�����@�敪
            temp.SuppTtlAmntDspWayCd = reader.ReadInt32();
            //�ېŋ敪
            temp.TaxationCode = reader.ReadInt32();
            //�d�����z����Ŋz�i���Łj[�`�[]
            temp.StckPrcConsTaxInclu = reader.ReadInt64();
            //�d���l������Ŋz�i���Łj[�`�[]
            temp.StckDisTtlTaxInclu = reader.ReadInt64();
            //�d���P���i�Ŕ��C�����j[����]
            temp.StockUnitPriceFl = reader.ReadDouble();
            //�d�����z�i�Ŕ����j[����]
            temp.StockPriceTaxExc = reader.ReadInt64();
            //�d�����z�i�ō��݁j[����]
            temp.StockPriceTaxInc = reader.ReadInt64();
            //�d�����i�敪[�`�[]
            temp.StockGoodsCd = reader.ReadInt32();
            //�d�����z����Ŋz[����]
            temp.StockPriceConsTaxDtl = reader.ReadInt64();
            //�d���`�[�敪�i���ׁj[����]
            temp.StockSlipCdDtl = reader.ReadInt32();
            //�萔���x���z[�x��]
            temp.FeePayment = reader.ReadInt64();
            //�l���x���z[�x��]
            temp.DiscountPayment = reader.ReadInt64();
            // ----------- ADD 2012/10/15 �c���� Redmine#32862 ------------>>>>>
            //�ύX�O�d���P���i�����j[����]
            temp.BfStockUnitPriceFl = reader.ReadDouble();
            //�ύX�O�艿[����]
            temp.BfListPrice = reader.ReadDouble();
            // ----------- ADD 2012/10/15 �c���� Redmine#32862 ------------<<<<<

            // ----------ADD 2013/01/21----------->>>>>
            //�_���폜�敪[�d��]
            temp.SlpLogicalDeleteCode = reader.ReadInt32();
            //�_���폜�敪[�d���ڍ�]
            temp.DtlLogicalDeleteCode = reader.ReadInt32();
            //����R�[�h[�d��]
            temp.SlpSubSectionCode = reader.ReadInt32();
            //�d�����_�R�[�h[�d��]
            temp.StockSectionCd = reader.ReadString();
            //�d�������Őŗ�[�d��]
            temp.SupplierConsTaxRate = reader.ReadDouble();
            //���͓�[�d��]
            temp.InputDay = new DateTime(reader.ReadInt64());
            //����R�[�h[�d������]
            temp.DtlSubSectionCode = reader.ReadInt32();
            //�󒍔ԍ�[�d������]
            temp.AcceptAnOrderNo = reader.ReadInt32();
            //���ʒʔ�[�d������]
            temp.CommonSeqNo = reader.ReadInt64();
            //�d�����גʔ�[�d������]
            temp.StockSlipDtlNum = reader.ReadInt64();
            //�d���`���i���j[�d������]
            temp.SupplierFormalSrc = reader.ReadInt32();
            //�d�����גʔԁi���j[�d������]
            temp.StockSlipDtlNumSrc = reader.ReadInt64();
            //�󒍃X�e�[�^�X�i�����j[�d������]
            temp.AcptAnOdrStatusSync = reader.ReadInt32();
            //���㖾�גʔԁi�����j[�d������]
            temp.SalesSlipDtlNumSync = reader.ReadInt64();

            //�d�����͎҃R�[�h[�d������]
            temp.StockInputCode = reader.ReadString();
            //�d���S���҃R�[�h[�d������]
            temp.StockAgentCode = reader.ReadString();
            //���i����[�d������]
            temp.GoodsKindCode = reader.ReadInt32();
            //���[�J�[�J�i����[�d������]
            temp.MakerKanaName = reader.ReadString();
            //���[�J�[�J�i���́i�ꎮ�j[�d������]
            temp.CmpltMakerKanaName = reader.ReadString();
            //���i���̃J�i[�d������]
            temp.GoodsNameKana = reader.ReadString();
            //���i�啪�ރR�[�h[�d������]
            temp.GoodsLGroup = reader.ReadInt32();
            //���i�啪�ޖ���[�d������]
            temp.GoodsLGroupName = reader.ReadString();
            //���i�����ރR�[�h[�d������]
            temp.GoodsMGroup = reader.ReadInt32();
            //���i�����ޖ���[�d������]
            temp.GoodsMGroupName = reader.ReadString();
            //BL�O���[�v�R�[�h����[�d������]
            temp.BLGroupName = reader.ReadString();
            //BL���i�R�[�h���́i�S�p�j[�d������]
            temp.BLGoodsFullName = reader.ReadString();
            //���Е��ރR�[�h[�d������]
            temp.EnterpriseGanreCode = reader.ReadInt32();
            //�|���ݒ苒�_�i�d���P���j[�d������]
            temp.RateSectStckUnPrc = reader.ReadString();
            //�|���ݒ�敪�i�d���P���j[�d������]
            temp.RateDivStckUnPrc = reader.ReadString();
            //�P���Z�o�敪�i�d���P���j[�d������]
            temp.UnPrcCalcCdStckUnPrc = reader.ReadInt32();
            //���i�敪�i�d���P���j[�d������]
            temp.PriceCdStckUnPrc = reader.ReadInt32();
            //��P���i�d���P���j[�d������]
            temp.StdUnPrcStckUnPrc = reader.ReadDouble();
            //�[�������P�ʁi�d���P���j[�d������]
            temp.FracProcUnitStcUnPrc = reader.ReadDouble();
            //�[�������i�d���P���j[�d������]
            temp.FracProcStckUnPrc = reader.ReadInt32();
            //�d���P���i�ō��C�����j[�d������]
            temp.StockUnitTaxPriceFl = reader.ReadDouble();
            //�d���P���ύX�敪[�d������]
            temp.StockUnitChngDiv = reader.ReadInt32();
            //BL���i�R�[�h�i�|���j[�d������]
            temp.RateBLGoodsCode = reader.ReadInt32();
            //BL���i�R�[�h���́i�|���j[�d������]
            temp.RateBLGoodsName = reader.ReadString();
            //���i�|���O���[�v�R�[�h�i�|���j[�d������]
            temp.RateGoodsRateGrpCd = reader.ReadInt32();
            //���i�|���O���[�v���́i�|���j[�d������]
            temp.RateGoodsRateGrpNm = reader.ReadString();
            //BL�O���[�v�R�[�h�i�|���j[�d������]
            temp.RateBLGroupCode = reader.ReadInt32();
            //BL�O���[�v���́i�|���j[�d������]
            temp.RateBLGroupName = reader.ReadString();
            //��������[�d������]
            temp.OrderCnt = reader.ReadDouble();
            //����������[�d������]
            temp.OrderAdjustCnt = reader.ReadDouble();
            //�����c��[�d������]
            temp.OrderRemainCnt = reader.ReadDouble();
            //�c���X�V��[�d������]
            temp.RemainCntUpdDate = new DateTime(reader.ReadInt64());
            //�d���`�[���ה��l1[�d������]
            temp.StockDtiSlipNote1 = reader.ReadString();
            //�̔���R�[�h[�d������]
            temp.SalesCustomerCode = reader.ReadInt32();
            //�̔��旪��[�d������]
            temp.SalesCustomerSnm = reader.ReadString();
            //�`�[�����P[�d������]
            temp.SlipMemo1 = reader.ReadString();
            //�`�[�����Q[�d������]
            temp.SlipMemo2 = reader.ReadString();
            //�`�[�����R[�d������]
            temp.SlipMemo3 = reader.ReadString();
            //�Г������P[�d������]
            temp.InsideMemo1 = reader.ReadString();
            //�Г������Q[�d������]
            temp.InsideMemo2 = reader.ReadString();
            //�Г������R[�d������]
            temp.InsideMemo3 = reader.ReadString();
            //�[�i��R�[�h[�d������]
            temp.AddresseeCode = reader.ReadInt32();
            //�[�i�於��[�d������]
            temp.AddresseeName = reader.ReadString();
            //�����敪[�d������]
            temp.DirectSendingCd = reader.ReadInt32();
            //�����ԍ�[�d������]
            temp.OrderNumber = reader.ReadString();
            //�������@[�d������]
            temp.WayToOrder = reader.ReadInt32();
            //�[�i�����\���[�d������]
            temp.DeliGdsCmpltDueDate = new DateTime(reader.ReadInt64());
            //��]�[��[�d������]
            temp.ExpectDeliveryDate = new DateTime(reader.ReadInt64());
            //�����f�[�^�쐬�敪[�d������]
            temp.OrderDataCreateDiv = reader.ReadInt32();
            //�����f�[�^�쐬��[�d������]
            temp.OrderDataCreateDate = new DateTime(reader.ReadInt64());
            //���������s�ϋ敪[�d������]
            temp.OrderFormIssuedDiv = reader.ReadInt32();

            //���Е��ޖ���[�d������]
            temp.EnterpriseGanreName = reader.ReadString();
            //���i�|�������N[�d������]
            temp.GoodsRateRank = reader.ReadString();
            //���Ӑ�|���O���[�v�R�[�h[�d������]
            temp.CustRateGrpCode = reader.ReadInt32();
            //�d����|���O���[�v�R�[�h[�d������]
            temp.SuppRateGrpCode = reader.ReadInt32();
            //�艿�i�ō��C�����j[�d������]
            temp.ListPriceTaxIncFl = reader.ReadDouble();
            //�d����[�d������]
            temp.StockRate = reader.ReadDouble();
            //�d���v�㋒�_�R�[�h[�d��]
            temp.StockAddUpSectionCd = reader.ReadString();
            //�Ǝ�R�[�h[�d��]
            temp.BusinessTypeCode = reader.ReadInt32();
            //�Ǝ햼��[�d��]
            temp.BusinessTypeName = reader.ReadString();
            //�̔��G���A�R�[�h[�d��]
            temp.SalesAreaCode = reader.ReadInt32();
            //�̔��G���A����[�d��]
            temp.SalesAreaName = reader.ReadString();
            //���z�\���|���K�p�敪[�d��]
            temp.TtlAmntDispRateApy = reader.ReadInt32();
            //�d���[�������敪[�d��]
            temp.StockFractionProcCd = reader.ReadInt32();

            //�`�[�Z���敪[�d��]
            temp.SlipAddressDiv = reader.ReadInt32();
            //�[�i��R�[�h[�d��]
            temp.SlpAddresseeCode = reader.ReadInt32();
            //�[�i�於��[�d��]
            temp.SlpAddresseeName = reader.ReadString();
            //�[�i�於��2[�d��]
            temp.AddresseeName2 = reader.ReadString();
            //�[�i��X�֔ԍ�[�d��]
            temp.AddresseePostNo = reader.ReadString();
            //�[�i��Z��1_�s���{���s��S�E�����E��[�d��]
            temp.AddresseeAddr1 = reader.ReadString();
            //�[�i��Z��3_�Ԓn[�d��]
            temp.AddresseeAddr3 = reader.ReadString();
            //�[�i��Z��4_�A�p�[�g����[�d��]
            temp.AddresseeAddr4 = reader.ReadString();
            //�[�i��d�b�ԍ�[�d��]
            temp.AddresseeTelNo = reader.ReadString();
            //�[�i��FAX�ԍ�[�d��]
            temp.AddresseeFaxNo = reader.ReadString();
            //�����敪[�d��]
            temp.SlpDirectSendingCd = reader.ReadInt32();

            // ----------ADD 2013/01/21-----------<<<<<

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
        /// <returns>SuppPrtPprStcTblRsltWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprStcTblRsltWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize( System.IO.BinaryReader reader )
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
            ArrayList lst = new ArrayList();
            for ( int cnt = 0; cnt < serInfo.Occurrence; ++cnt )
            {
                SuppPrtPprStcTblRsltWork temp = GetSuppPrtPprStcTblRsltWork( reader, serInfo );
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
                    retValue = (SuppPrtPprStcTblRsltWork[])lst.ToArray( typeof( SuppPrtPprStcTblRsltWork ) );
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

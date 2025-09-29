//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i���擾�i�񋟁j
// �v���O�����T�v   : ���i���擾�i�񋟁j�f�[�^�p�����[�^
//----------------------------------------------------------------------------//
//                (c)Copyright  2018 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� :              �쐬�S�� : 30290
// �� �� �� : 2005/04/14   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11470007-00  �쐬�S�� : 30757 ���X�؁@�M�p
// �� �� �� : 2018/03/26   �C�����e : NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    #region [ ���i��񌋉ʊi�[�N���X ]
    /// <summary>
    ///                      ���i��񌋉ʊi�[�N���X
    /// </summary>
    /// <remarks>
    /// <br>Date             :   2005/04/14</br>
    /// <br>Genarated Date   :   2005/04/14</br>
    /// <br>Update Note      :   20060710 iwa �s�r�o�Ή��@�i�Ԃ��p�����[�^�ɒǉ�</br>
    /// <br>Update Note      :   2009/10/23�@21024 ���X�� �����i���擾�J�[���[�J�[�R�[�h��ǉ�</br>
    /// <br>Update Note      :   2013/02/12�@20056 ���n ��� �D�ǌ����A�g�t���O�ǉ�(�_�~�[�i�Ԕ��ʗp)</br>
    /// <br>Update Note      :   2013/03/25  FSI�֓� �a�G VIN���YNo.(�n��)�EVIN���YNo.(�I��)��ǉ�(SPK�ԑ�ԍ�������Ή�)</br>
    /// <br>Update Note      :   2018/03/26  30757 ���X�؁@�M�p</br>
    /// <br>�Ǘ��ԍ�         :   11470007-00</br>
    /// <br>                 :   NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j</br>
    /// <br>                     BL���ꕔ�i�R�[�h�֘A�����o�[�̒ǉ�</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RetPartsInf
    {
        /// <summary>�񋟓��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _offerDate;
        /// <summary>
        /// ���i�����敪
        /// </summary>
        private int _PartsSearchCode;
        ///<summary>���i�i���݋敪 0:���Y�N�� 1:�V���V�[NO</summary>
        private int _PartsNarrowingCode;
        /// <summary>���i����</summary>
        private string _partsName = "";
        /// <summary>���i���̃J�i</summary>
        private string _partsNameKana = "";
        /// <summary>��ƕ��i�敪����</summary>
        private Int32 _partsCode;
        /// <summary>��ƕ��i�敪����</summary>
        private string _workOrPartsDivNm = "";
        /// <summary>�t���^���Œ�ԍ�</summary>
        private Int32 _fullModelFixedNo;
        /// <summary>�����i�R�[�h</summary>
        /// <remarks>1�`99999:�񋟕�,100000�`���[�U�[�o�^�p</remarks>
        private Int32 _tbsPartsCode;
        /// <summary>�����i�R�[�h�}��</summary>
        private Int32 _tbsPartsCdDerivedNo;
        /// <summary>Fig�}��</summary>
        /// <remarks>�C���X�g�̐}�ԂƘA�g</remarks>
        private string _figshapeNo = "";
        /// <summary>�^���ʕ��i�̗p�N��</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _modelPrtsAdptYm;
        /// <summary>�^���ʕ��i�p�~�N��</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _modelPrtsAblsYm;
        /// <summary>�^���ʕ��i�̗p�ԑ�ԍ�</summary>
        private Int32 _modelPrtsAdptFrameNo;
        /// <summary>�^���ʕ��i�p�~�ԑ�ԍ�</summary>
        private Int32 _modelPrtsAblsFrameNo;
        /// <summary>���iQTY</summary>
        private Double _partsQty;
        /// <summary>���i�I�v�V��������</summary>
        private string _partsOpNm = "";
        /// <summary>�K�i����</summary>
        private string _standardName = "";
        /// <summary>�J�^���O���i���[�J�[�R�[�h</summary>
        private Int32 _catalogPartsMakerCd;
        /// <summary>�n�C�t���t�J�^���O���i�i��</summary>
        private string _clgPrtsNoWithHyphen = "";
        /// <summary>����n�t���O</summary>
        /// <remarks>0:�ʏ핔�i,1:����n�d�l,9:���ʕ��i</remarks>
        private Int32 _coldDistrictsFlag;
        /// <summary>�J���[�i���t���O</summary>
        /// <remarks>0:�J���[���Ȃ�,1:�J���[��񂠂�</remarks>
        private Int32 _colorNarrowingFlag;
        /// <summary>�g�����i���t���O</summary>
        /// <remarks>0:�g�������Ȃ�,1:�g������񂠂�</remarks>
        private Int32 _trimNarrowingFlag;
        /// <summary>�����i���t���O</summary>
        /// <remarks>0:�������Ȃ�,1:������񂠂�</remarks>
        private Int32 _equipNarrowingFlag;
        /// <summary>�n�C�t���t�ŐV���i�i��</summary>
        private string _newPrtsNoWithHyphen = "";
        /// <summary>�n�C�t�����ŐV���i�i��</summary>
        private string _newPrtsNoNoneHyphen = "";
        /// <summary>���[�J�[�ʕ��i����</summary>
        private string _makerOfferPartsName = "";
        /// <summary>���i�񋟓��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _priceOfferDate;
        /// <summary>���i���i</summary>
        private Int64 _partsPrice;
        /// <summary>���i�J�n��</summary>
        private DateTime _partsPriceStDate;
        /// <summary>�w�ʃR�[�h</summary>
        private string _partsLayerCd = "";
        /// <summary>���i�ŗL�ԍ�</summary>
        private Int64 _PartsUniqueNo;
        /// <summary>���[�J�[�񋟕��i�J�i����</summary>
        private string _makerOfferPartsKana = "";
        /// <summary>�I�[�v�����i�敪</summary>
        private Int32 _openPriceDiv;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 ADD
        /// <summary>�V���[�Y�^���i�^���P�j</summary>
        private string _seriesModel = "";
        /// <summary>�^���i�ޕʋL���j�i�^���Q�j</summary>
        private string _categorySignModel = "";
        /// <summary>�r�K�X�L���i�^���O�j</summary>
        private string _exhaustGasSign = "";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 ADD
        // 2009/10/23 Add >>>
        /// <summary>�����i���擾�J�[���[�J�[�R�[�h</summary>
        private Int32 _srchPNmAcqrCarMkrCd;
        // 2009/10/23 Add <<<
        // --- ADD m.suzuki 2011/05/18 ---------->>>>>
        /// <summary>�������ϕ��i�R�[�h</summary>
        private string _autoEstimatePartsCd = "";
        /// <summary>BL���i�R�[�h�}�ԗp���i����</summary>
        private string _tbsPartsCdDerivedNm = "";
        // --- ADD m.suzuki 2011/05/18 ----------<<<<<
        //>>>2013/02/12
        /// <summary>�D�ǌ����A�g�t���O</summary>
        private Int32 _primeJoinLnkFlg;
        //<<<2013/02/12

        // --- ADD 2013/03/25 ---------->>>>>
        /// <summary>VIN���YNo.(�n��)</summary>
        private Int32 _vinProduceStartNo;
        /// <summary>VIN���YNo.(�I��)</summary>
        private Int32 _vinProduceEndNo;
        // --- ADD 2013/03/25 ----------<<<<<

        // ----ADD 2018/03/26 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j ------->>>>>
        /// <summary>BL���ꕔ�i�R�[�h(�X���[�R�[�h��)</summary>
        private string _blUtyPtThCd = string.Empty;
        /// <summary>BL���ꕔ�i�R�[�h</summary>
        private string _blUtyPtCd = string.Empty;
        /// <summary>BL���ꕔ�i�T�u�R�[�h</summary>
        private Int32  _blUtyPtSbCd = 0;
        // ----ADD 2018/03/26 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j -------<<<<<

        /// public propaty name  :  OfferDate
        /// <summary>�񋟓��t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񋟓��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime OfferDate
        {
            get { return _offerDate; }
            set { _offerDate = value; }
        }
        /// public propaty name  :  PartsSearchCode
        /// <summary>���i�����敪</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����敪</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int PartsSearchCode
        {
            get { return _PartsSearchCode; }
            set { _PartsSearchCode = value; }
        }
        /// public propaty name  :  PartsNarrowingCode
        /// <summary>�f�t�H���g�`�F�b�N�敪(��ƃ��R�[�h�敪��1,2�̏ꍇ�Ɏg�p�B�f�t�H���g�`�F�b�N�̌�����1�̏ꍇ�͍ō��_�����Z)</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�t�H���g�`�F�b�N�敪</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int PartsNarrowingCode
        {
            get { return _PartsNarrowingCode; }
            set { _PartsNarrowingCode = value; }
        }
        /// public propaty name  :  PartsName
        /// <summary>���i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartsName
        {
            get { return _partsName; }
            set { _partsName = value; }
        }
        /// public propaty name  :  PartsNameKana
        /// <summary>���i���̃J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̃J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartsNameKana
        {
            get { return _partsNameKana; }
            set { _partsNameKana = value; }
        }
        /// public propaty name  :  _partsCode
        /// <summary>��ƕ��i�敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t���^���Œ�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WorkOrPartsDivNm
        {
            get { return _workOrPartsDivNm; }
            set { _workOrPartsDivNm = value; }
        }
        /// public propaty name  :  _partsCode
        /// <summary>��ƕ��i�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t���^���Œ�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PartsCode
        {
            get { return _partsCode; }
            set { _partsCode = value; }
        }
        /// public propaty name  :  FullModelFixedNo
        /// <summary>�t���^���Œ�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t���^���Œ�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FullModelFixedNo
        {
            get { return _fullModelFixedNo; }
            set { _fullModelFixedNo = value; }
        }
        /// public propaty name  :  TbsPartsCode
        /// <summary>�����i�R�[�h�v���p�e�B</summary>
        /// <value>1�`99999:�񋟕�,100000�`���[�U�[�o�^�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TbsPartsCode
        {
            get { return _tbsPartsCode; }
            set { _tbsPartsCode = value; }
        }
        /// public propaty name  :  TbsPartsCdDerivedNo
        /// <summary>�����i�R�[�h�}�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����i�R�[�h�}�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TbsPartsCdDerivedNo
        {
            get { return _tbsPartsCdDerivedNo; }
            set { _tbsPartsCdDerivedNo = value; }
        }
        /// public propaty name  :  FigShapeNo
        /// <summary>Fig�}�ԃv���p�e�B</summary>
        /// <value>�C���X�g�̐}�ԂƘA�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   Fig�}�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FigShapeNo
        {
            get { return _figshapeNo; }
            set { _figshapeNo = value; }
        }
        /// public propaty name  :  ModelPrtsAdptYm
        /// <summary>�^���ʕ��i�̗p�N���v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���ʕ��i�̗p�N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ModelPrtsAdptYm
        {
            get { return _modelPrtsAdptYm; }
            set { _modelPrtsAdptYm = value; }
        }
        /// public propaty name  :  ModelPrtsAblsYm
        /// <summary>�^���ʕ��i�p�~�N���v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���ʕ��i�p�~�N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ModelPrtsAblsYm
        {
            get { return _modelPrtsAblsYm; }
            set { _modelPrtsAblsYm = value; }
        }
        /// public propaty name  :  ModelPrtsAdptFrameNo
        /// <summary>�^���ʕ��i�̗p�ԑ�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���ʕ��i�̗p�ԑ�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ModelPrtsAdptFrameNo
        {
            get { return _modelPrtsAdptFrameNo; }
            set { _modelPrtsAdptFrameNo = value; }
        }
        /// public propaty name  :  ModelPrtsAblsFrameNo
        /// <summary>�^���ʕ��i�p�~�ԑ�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���ʕ��i�p�~�ԑ�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ModelPrtsAblsFrameNo
        {
            get { return _modelPrtsAblsFrameNo; }
            set { _modelPrtsAblsFrameNo = value; }
        }
        /// public propaty name  :  PartsQty
        /// <summary>���iQTY�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���iQTY�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double PartsQty
        {
            get { return _partsQty; }
            set { _partsQty = value; }
        }
        /// public propaty name  :  PartsOpNm
        /// <summary>���i�I�v�V�������̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�I�v�V�������̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartsOpNm
        {
            get { return _partsOpNm; }
            set { _partsOpNm = value; }
        }
        /// public propaty name  :  StandardName
        /// <summary>�K�i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StandardName
        {
            get { return _standardName; }
            set { _standardName = value; }
        }
        /// public propaty name  :  CatalogPartsMakerCd
        /// <summary>�J�^���O���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�^���O���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CatalogPartsMakerCd
        {
            get { return _catalogPartsMakerCd; }
            set { _catalogPartsMakerCd = value; }
        }
        /// public propaty name  :  ClgPrtsNoWithHyphen
        /// <summary>�n�C�t���t�J�^���O���i�i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n�C�t���t�J�^���O���i�i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ClgPrtsNoWithHyphen
        {
            get { return _clgPrtsNoWithHyphen; }
            set { _clgPrtsNoWithHyphen = value; }
        }
        /// public propaty name  :  ColdDistrictsFlag
        /// <summary>����n�t���O�v���p�e�B</summary>
        /// <value>0:�ʏ핔�i,1:����n�d�l,9:���ʕ��i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����n�t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ColdDistrictsFlag
        {
            get { return _coldDistrictsFlag; }
            set { _coldDistrictsFlag = value; }
        }
        /// public propaty name  :  ColorNarrowingFlag
        /// <summary>�J���[�i���t���O�v���p�e�B</summary>
        /// <value>0:�J���[���Ȃ�,1:�J���[��񂠂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J���[�i���t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ColorNarrowingFlag
        {
            get { return _colorNarrowingFlag; }
            set { _colorNarrowingFlag = value; }
        }
        /// public propaty name  :  TrimNarrowingFlag
        /// <summary>�g�����i���t���O�v���p�e�B</summary>
        /// <value>0:�g�������Ȃ�,1:�g������񂠂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �g�����i���t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TrimNarrowingFlag
        {
            get { return _trimNarrowingFlag; }
            set { _trimNarrowingFlag = value; }
        }
        /// public propaty name  :  EquipNarrowingFlag
        /// <summary>�����i���t���O�v���p�e�B</summary>
        /// <value>0:�������Ȃ�,1:������񂠂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����i���t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EquipNarrowingFlag
        {
            get { return _equipNarrowingFlag; }
            set { _equipNarrowingFlag = value; }
        }
        /// public propaty name  :  NewPrtsNoWithHyphen
        /// <summary>�n�C�t���t�ŐV���i�i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n�C�t���t�ŐV���i�i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string NewPrtsNoWithHyphen
        {
            get { return _newPrtsNoWithHyphen; }
            set { _newPrtsNoWithHyphen = value; }
        }
        /// public propaty name  :  NewPrtsNoNoneHyphen
        /// <summary>�n�C�t�����ŐV���i�i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n�C�t�����ŐV���i�i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string NewPrtsNoNoneHyphen
        {
            get { return _newPrtsNoNoneHyphen; }
            set { _newPrtsNoNoneHyphen = value; }
        }
        /// public propaty name  :  MakerOfferPartsName
        /// <summary>���[�J�[�ʕ��i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�ʕ��i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MakerOfferPartsName
        {
            get { return _makerOfferPartsName; }
            set { _makerOfferPartsName = value; }
        }
        /// public propaty name  :  PriceOfferDate
        /// <summary>���i�񋟓��t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�񋟓��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime PriceOfferDate
        {
            get { return _priceOfferDate; }
            set { _priceOfferDate = value; }
        }
        /// public propaty name  :  PartsPrice
        /// <summary>���i���i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 PartsPrice
        {
            get { return _partsPrice; }
            set { _partsPrice = value; }
        }
        /// public propaty name  :  PartsPriceStDate
        /// <summary>���i���i�J�n���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���i�J�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime PartsPriceStDate
        {
            get { return _partsPriceStDate; }
            set { _partsPriceStDate = value; }
        }
        /// public propaty name  :  PartsLayerCd
        /// <summary>�w�ʃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �w�ʃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartsLayerCd
        {
            get { return _partsLayerCd; }
            set { _partsLayerCd = value; }
        }

        /// public propaty name  :  PartsUniqueNo
        /// <summary>���i����(����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   </br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 PartsUniqueNo
        {
            get { return _PartsUniqueNo; }
            set { _PartsUniqueNo = value; }
        }

        /// public propaty name  :  MakerOfferPartsKana
        /// <summary>���[�J�[�񋟕��i�J�i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   </br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MakerOfferPartsKana
        {
            get { return _makerOfferPartsKana; }
            set { _makerOfferPartsKana = value; }
        }

        /// public propaty name  :  OpenPriceDiv
        /// <summary>�I�[�v�����i�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   </br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OpenPriceDiv
        {
            get { return _openPriceDiv; }
            set { _openPriceDiv = value; }
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 ADD
        /// <summary>
        /// �V���[�Y�^���i�^���P�j
        /// </summary>
        public string SeriesModel
        {
            get { return _seriesModel; }
            set { _seriesModel = value; }
        }
        /// <summary>
        /// �^���i�ޕʋL���j�i�^���Q�j
        /// </summary>
        public string CategorySignModel
        {
            get { return _categorySignModel; }
            set { _categorySignModel = value; }
        }
        /// <summary>
        /// �r�K�X�L���i�^���O�j
        /// </summary>
        public string ExhaustGasSign
        {
            get { return _exhaustGasSign; }
            set { _exhaustGasSign = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 ADD

        // 2009/10/23 Add >>>
        /// <summary>
        /// �����i���擾�J�[���[�J�[�R�[�h
        /// </summary>
        public Int32 SrchPNmAcqrCarMkrCd
        {
            get { return _srchPNmAcqrCarMkrCd; }
            set { _srchPNmAcqrCarMkrCd = value; }
        }
        // 2009/10/23 Add <<<

        // --- ADD m.suzuki 2011/05/18 ---------->>>>>
        /// <summary>
        /// �������ϕ��i�R�[�h
        /// </summary>
        public string AutoEstimatePartsCd
        {
            get { return _autoEstimatePartsCd; }
            set { _autoEstimatePartsCd = value; }
        }
        /// <summary>
        /// BL���i�R�[�h�}�ԗp���i����
        /// </summary>
        public string TbsPartsCdDerivedNm
        {
            get { return _tbsPartsCdDerivedNm; }
            set { _tbsPartsCdDerivedNm = value; }
        }
        // --- ADD m.suzuki 2011/05/18 ----------<<<<<

        //>>>2013/02/12
        /// <summary>
        /// �D�ǌ����A�g�t���O
        /// </summary>
        public Int32 PrimeJoinLnkFlg
        {
            get { return _primeJoinLnkFlg; }
            set { _primeJoinLnkFlg = value; }
        }
        //<<<2013/02/12

        // --- ADD 2013/03/25 ---------->>>>>
        /// <summary>VIN���YNo.(�n��)</summary>
        public Int32 VinProduceStartNo
        {
            get { return _vinProduceStartNo; }
            set { _vinProduceStartNo = value; }
        }
        /// <summary>VIN���YNo.(�I��)</summary>
        public Int32 VinProduceEndNo
        {
            get { return _vinProduceEndNo; }
            set { _vinProduceEndNo = value; }
        }
        // --- ADD 2013/03/25 ----------<<<<<

        // ----ADD 2018/03/26 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j ------->>>>>
        /// <summary>BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�p�����[�^</summary>
        /// <value>BL���ꕔ�i�R�[�h(�X���[�R�[�h��)</value>
        /// <remarks>
        /// <br>Note       : BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�̎擾�Ɛݒ�</br>
        /// <br>Programmer : 30757 ���X�؁@�M�p</br>
        /// <br>Date       : 2018/03/26</br>
        /// <br>�Ǘ��ԍ�   :   11470007-00</br>
        /// <br>           :   NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j</br>
        /// </remarks>
        public string BlUtyPtThCd
        {
            get { return this._blUtyPtThCd; }
            set { this._blUtyPtThCd = value; }
        }
        /// <summary>BL���ꕔ�i�R�[�h�p�����[�^</summary>
        /// <value>BL���ꕔ�i�R�[�h</value>
        /// <remarks>
        /// <br>Note       : BL���ꕔ�i�R�[�h�̎擾�Ɛݒ�</br>
        /// <br>Programmer : 30757 ���X�؁@�M�p</br>
        /// <br>Date       : 2018/03/26</br>
        /// <br>�Ǘ��ԍ�   :   11470007-00</br>
        /// <br>           :   NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j</br>
        /// </remarks>
        public string BlUtyPtCd
        {
            get { return this._blUtyPtCd; }
            set { this._blUtyPtCd = value; }
        }
        /// <summary>BL���ꕔ�i�T�u�R�[�h�p�����[�^</summary>
        /// <value>BL���ꕔ�i�T�u�R�[�h</value>
        /// <remarks>
        /// <br>Note       : BL���ꕔ�i�T�u�R�[�h�̎擾�Ɛݒ�</br>
        /// <br>Programmer : 30757 ���X�؁@�M�p</br>
        /// <br>Date       : 2018/03/26</br>
        /// <br>�Ǘ��ԍ�   :   11470007-00</br>
        /// <br>           :   NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j</br>
        /// </remarks>
        public Int32 BlUtyPtSbCd
        {
            get { return this._blUtyPtSbCd; }
            set { this._blUtyPtSbCd = value; }
        }
        // ----ADD 2018/03/26 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j -------<<<<<

        /// <summary>
        /// UI�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>RetPartsInf�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RetPartsInf�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RetPartsInf()
        {
        }

        /// <summary>
        /// UI�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <param name="OfferDate"></param>
        /// <param name="PartsSearchCode"></param>
        /// <param name="PartsNarrowingCode"></param>
        /// <param name="partsName"></param>
        /// <param name="partsNameKana"></param>
        /// <param name="partsCode"></param>
        /// <param name="workOrPartsDivNm"></param>
        /// <param name="fullModelFixedNo">�t���^���Œ�ԍ�</param>
        /// <param name="tbsPartsCode">�����i�R�[�h(1�`99999:�񋟕�,100000�`���[�U�[�o�^�p)</param>
        /// <param name="tbsPartsCdDerivedNo">�����i�R�[�h�}��</param>
        /// <param name="figshapeNo">Fig�}��(�C���X�g�̐}�ԂƘA�g)</param>
        /// <param name="modelPrtsAdptYm">�^���ʕ��i�̗p�N��(YYYYMM)</param>
        /// <param name="modelPrtsAblsYm">�^���ʕ��i�p�~�N��(YYYYMM)</param>
        /// <param name="modelPrtsAdptFrameNo">�^���ʕ��i�̗p�ԑ�ԍ�</param>
        /// <param name="modelPrtsAblsFrameNo">�^���ʕ��i�p�~�ԑ�ԍ�</param>
        /// <param name="partsQty">���iQTY</param>
        /// <param name="partsOpNm">���i�I�v�V��������</param>
        /// <param name="standardName">�K�i����</param>
        /// <param name="catalogPartsMakerCd">�J�^���O���i���[�J�[�R�[�h</param>
        /// <param name="clgPrtsNoWithHyphen">�n�C�t���t�J�^���O���i�i��</param>
        /// <param name="coldDistrictsFlag">����n�t���O(0:�ʏ핔�i,1:����n�d�l,9:���ʕ��i)</param>
        /// <param name="colorNarrowingFlag">�J���[�i���t���O(0:�J���[���Ȃ�,1:�J���[��񂠂�)</param>
        /// <param name="trimNarrowingFlag">�g�����i���t���O(0:�g�������Ȃ�,1:�g������񂠂�)</param>
        /// <param name="equipNarrowingFlag">�����i���t���O(0:�������Ȃ�,1:������񂠂�)</param>
        /// <param name="newPrtsNoWithHyphen">�n�C�t���t�ŐV���i�i��</param>
        /// <param name="newPrtsNoNoneHyphen">�n�C�t�����ŐV���i�i��</param>
        /// <param name="makerOfferPartsName">���[�J�[�ʕ��i����</param>
        /// <param name="PriceOfferDate">���i�񋟓��t</param>
        /// <param name="partsPrice">���i���i</param>
        /// <param name="partsPriceStDate"></param>
        /// <param name="partsLayerCd">�w�ʃR�[�h</param>
        /// <param name="partsUniqueNo"></param>
        /// <param name="makerOfferPartsKana">���[�J�[�񋟕��i�J�i����</param>
        /// <param name="openPriceDiv">�I�[�v�����i�敪</param>
        /// <param name="vinProduceStartNo">VIN���YNo.(�n��)</param>
        /// <param name="vinProduceEndNo">VIN���YNo.(�I��)</param>
        /// <param name="autoEstimatePartsCd"></param>
        /// <param name="categorySignModel"></param>
        /// <param name="exhaustGasSign"></param>
        /// <param name="primeJoinLnkFlg"></param>
        /// <param name="seriesModel"></param>
        /// <param name="srchPNmAcqrCarMkrCd"></param>
        /// <param name="tbsPartsCdDerivedNm"></param>
        /// <param name="blUtyPtThCd">BL���ꕔ�i�R�[�h(�X���[�R�[�h��)</param>
        /// <param name="blUtyPtCd">BL���ꕔ�i�R�[�h</param>
        /// <param name="blUtyPtSbCd">BL���ꕔ�i�T�u�R�[�h</param>
        /// <returns>RetPartsInf�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RetPartsInf�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br />
        /// <br>Update Note      :   2018/03/26  30757 ���X�؁@�M�p</br>
        /// <br>�Ǘ��ԍ�         :   11470007-00</br>
        /// <br>                 :   NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j</br>
        /// <br>                     BL���ꕔ�i�R�[�h�֘A�����o�[�̒ǉ�</br>
        /// </remarks>
        //>>>2013/02/12
        //// --- UPD m.suzuki 2011/05/18 ---------->>>>>
        ////// 2009/10/23 >>>
        //////// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 DEL
        ////////public RetPartsInf(DateTime OfferDate, Int32 PartsSearchCode, Int32 PartsNarrowingCode, string partsName, string partsNameKana,
        ////////    Int32 partsCode, string workOrPartsDivNm, Int32 fullModelFixedNo, Int32 tbsPartsCode, Int32 tbsPartsCdDerivedNo,
        ////////    string figshapeNo, Int32 modelPrtsAdptYm, Int32 modelPrtsAblsYm, Int32 modelPrtsAdptFrameNo,
        ////////    Int32 modelPrtsAblsFrameNo, Double partsQty, string partsOpNm, string standardName, Int32 catalogPartsMakerCd,
        ////////    string clgPrtsNoWithHyphen, Int32 coldDistrictsFlag, Int32 colorNarrowingFlag, Int32 trimNarrowingFlag,
        ////////    Int32 equipNarrowingFlag, string newPrtsNoWithHyphen, string newPrtsNoNoneHyphen, string makerOfferPartsName, DateTime PriceOfferDate,
        ////////    Int64 partsPrice, DateTime partsPriceStDate, string partsLayerCd, Int64 partsUniqueNo, string makerOfferPartsKana, Int32 openPriceDiv)
        //////// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 DEL
        //////// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 ADD
        //////public RetPartsInf( DateTime OfferDate, Int32 PartsSearchCode, Int32 PartsNarrowingCode, string partsName, string partsNameKana,
        //////    Int32 partsCode, string workOrPartsDivNm, Int32 fullModelFixedNo, Int32 tbsPartsCode, Int32 tbsPartsCdDerivedNo,
        //////    string figshapeNo, Int32 modelPrtsAdptYm, Int32 modelPrtsAblsYm, Int32 modelPrtsAdptFrameNo,
        //////    Int32 modelPrtsAblsFrameNo, Double partsQty, string partsOpNm, string standardName, Int32 catalogPartsMakerCd,
        //////    string clgPrtsNoWithHyphen, Int32 coldDistrictsFlag, Int32 colorNarrowingFlag, Int32 trimNarrowingFlag,
        //////    Int32 equipNarrowingFlag, string newPrtsNoWithHyphen, string newPrtsNoNoneHyphen, string makerOfferPartsName, DateTime PriceOfferDate,
        //////    Int64 partsPrice, DateTime partsPriceStDate, string partsLayerCd, Int64 partsUniqueNo, string makerOfferPartsKana, Int32 openPriceDiv,
        //////    string seriesModel, string categorySignModel, string exhaustGasSign )
        //////// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 ADD
        ////public RetPartsInf(DateTime OfferDate, Int32 PartsSearchCode, Int32 PartsNarrowingCode, string partsName, string partsNameKana,
        ////    Int32 partsCode, string workOrPartsDivNm, Int32 fullModelFixedNo, Int32 tbsPartsCode, Int32 tbsPartsCdDerivedNo,
        ////    string figshapeNo, Int32 modelPrtsAdptYm, Int32 modelPrtsAblsYm, Int32 modelPrtsAdptFrameNo,
        ////    Int32 modelPrtsAblsFrameNo, Double partsQty, string partsOpNm, string standardName, Int32 catalogPartsMakerCd,
        ////    string clgPrtsNoWithHyphen, Int32 coldDistrictsFlag, Int32 colorNarrowingFlag, Int32 trimNarrowingFlag,
        ////    Int32 equipNarrowingFlag, string newPrtsNoWithHyphen, string newPrtsNoNoneHyphen, string makerOfferPartsName, DateTime PriceOfferDate,
        ////    Int64 partsPrice, DateTime partsPriceStDate, string partsLayerCd, Int64 partsUniqueNo, string makerOfferPartsKana, Int32 openPriceDiv,
        ////    string seriesModel, string categorySignModel, string exhaustGasSign, Int32 srchPNmAcqrCarMkrCd)
        ////// 2009/10/23 <<<

        //public RetPartsInf(DateTime OfferDate, Int32 PartsSearchCode, Int32 PartsNarrowingCode, string partsName, string partsNameKana,
        //    Int32 partsCode, string workOrPartsDivNm, Int32 fullModelFixedNo, Int32 tbsPartsCode, Int32 tbsPartsCdDerivedNo,
        //    string figshapeNo, Int32 modelPrtsAdptYm, Int32 modelPrtsAblsYm, Int32 modelPrtsAdptFrameNo,
        //    Int32 modelPrtsAblsFrameNo, Double partsQty, string partsOpNm, string standardName, Int32 catalogPartsMakerCd,
        //    string clgPrtsNoWithHyphen, Int32 coldDistrictsFlag, Int32 colorNarrowingFlag, Int32 trimNarrowingFlag,
        //    Int32 equipNarrowingFlag, string newPrtsNoWithHyphen, string newPrtsNoNoneHyphen, string makerOfferPartsName, DateTime PriceOfferDate,
        //    Int64 partsPrice, DateTime partsPriceStDate, string partsLayerCd, Int64 partsUniqueNo, string makerOfferPartsKana, Int32 openPriceDiv,
        //    string seriesModel, string categorySignModel, string exhaustGasSign, Int32 srchPNmAcqrCarMkrCd, string autoEstimatePartsCd, string tbsPartsCdDerivedNm )
        //// --- UPD m.suzuki 2011/05/18 ----------<<<<<

        // --- DEL 2013/03/25 ---------->>>>>
        //public RetPartsInf(DateTime OfferDate, Int32 PartsSearchCode, Int32 PartsNarrowingCode, string partsName, string partsNameKana,
        //    Int32 partsCode, string workOrPartsDivNm, Int32 fullModelFixedNo, Int32 tbsPartsCode, Int32 tbsPartsCdDerivedNo,
        //    string figshapeNo, Int32 modelPrtsAdptYm, Int32 modelPrtsAblsYm, Int32 modelPrtsAdptFrameNo,
        //    Int32 modelPrtsAblsFrameNo, Double partsQty, string partsOpNm, string standardName, Int32 catalogPartsMakerCd,
        //    string clgPrtsNoWithHyphen, Int32 coldDistrictsFlag, Int32 colorNarrowingFlag, Int32 trimNarrowingFlag,
        //    Int32 equipNarrowingFlag, string newPrtsNoWithHyphen, string newPrtsNoNoneHyphen, string makerOfferPartsName, DateTime PriceOfferDate,
        //    Int64 partsPrice, DateTime partsPriceStDate, string partsLayerCd, Int64 partsUniqueNo, string makerOfferPartsKana, Int32 openPriceDiv,
        //    string seriesModel, string categorySignModel, string exhaustGasSign, Int32 srchPNmAcqrCarMkrCd, string autoEstimatePartsCd, string tbsPartsCdDerivedNm, Int32 primeJoinLnkFlg)
        //<<<2013/02/12
        // --- DEL 2013/03/25 ----------<<<<<
        // ----DEL 2018/03/26 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j ------->>>>>
        //// --- ADD 2013/03/25 ---------->>>>>
        //public RetPartsInf(DateTime OfferDate, Int32 PartsSearchCode, Int32 PartsNarrowingCode, string partsName, string partsNameKana,
        //    Int32 partsCode, string workOrPartsDivNm, Int32 fullModelFixedNo, Int32 tbsPartsCode, Int32 tbsPartsCdDerivedNo,
        //    string figshapeNo, Int32 modelPrtsAdptYm, Int32 modelPrtsAblsYm, Int32 modelPrtsAdptFrameNo,
        //    Int32 modelPrtsAblsFrameNo, Double partsQty, string partsOpNm, string standardName, Int32 catalogPartsMakerCd,
        //    string clgPrtsNoWithHyphen, Int32 coldDistrictsFlag, Int32 colorNarrowingFlag, Int32 trimNarrowingFlag,
        //    Int32 equipNarrowingFlag, string newPrtsNoWithHyphen, string newPrtsNoNoneHyphen, string makerOfferPartsName, DateTime PriceOfferDate,
        //    Int64 partsPrice, DateTime partsPriceStDate, string partsLayerCd, Int64 partsUniqueNo, string makerOfferPartsKana, Int32 openPriceDiv,
        //    string seriesModel, string categorySignModel, string exhaustGasSign, Int32 srchPNmAcqrCarMkrCd, string autoEstimatePartsCd, string tbsPartsCdDerivedNm, Int32 primeJoinLnkFlg, Int32 vinProduceStartNo, Int32 vinProduceEndNo)
        //// --- ADD 2013/03/25 ----------<<<<<
        // ----DEL 2018/03/26 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j -------<<<<<
        // ----ADD 2018/03/26 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j ------->>>>>
        public RetPartsInf(DateTime OfferDate, Int32 PartsSearchCode, Int32 PartsNarrowingCode, string partsName, string partsNameKana,
            Int32 partsCode, string workOrPartsDivNm, Int32 fullModelFixedNo, Int32 tbsPartsCode, Int32 tbsPartsCdDerivedNo,
            string figshapeNo, Int32 modelPrtsAdptYm, Int32 modelPrtsAblsYm, Int32 modelPrtsAdptFrameNo,
            Int32 modelPrtsAblsFrameNo, Double partsQty, string partsOpNm, string standardName, Int32 catalogPartsMakerCd,
            string clgPrtsNoWithHyphen, Int32 coldDistrictsFlag, Int32 colorNarrowingFlag, Int32 trimNarrowingFlag,
            Int32 equipNarrowingFlag, string newPrtsNoWithHyphen, string newPrtsNoNoneHyphen, string makerOfferPartsName, DateTime PriceOfferDate,
            Int64 partsPrice, DateTime partsPriceStDate, string partsLayerCd, Int64 partsUniqueNo, string makerOfferPartsKana, Int32 openPriceDiv,
            string seriesModel, string categorySignModel, string exhaustGasSign, Int32 srchPNmAcqrCarMkrCd, string autoEstimatePartsCd, string tbsPartsCdDerivedNm, Int32 primeJoinLnkFlg, Int32 vinProduceStartNo, Int32 vinProduceEndNo,
            string blUtyPtThCd, string blUtyPtCd, Int32 blUtyPtSbCd)
        // ----ADD 2018/03/26 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j -------<<<<<
        {
            this._offerDate = OfferDate;
            this._PartsSearchCode = PartsSearchCode;
            this._PartsNarrowingCode = PartsNarrowingCode;
            this._partsName = partsName;
            this._partsNameKana = partsNameKana;
            this._partsCode = partsCode;
            this._workOrPartsDivNm = workOrPartsDivNm;
            this._fullModelFixedNo = fullModelFixedNo;
            this._tbsPartsCode = tbsPartsCode;
            this._tbsPartsCdDerivedNo = tbsPartsCdDerivedNo;
            this._figshapeNo = figshapeNo;
            this._modelPrtsAdptYm = modelPrtsAdptYm;
            this._modelPrtsAblsYm = modelPrtsAblsYm;
            this._modelPrtsAdptFrameNo = modelPrtsAdptFrameNo;
            this._modelPrtsAblsFrameNo = modelPrtsAblsFrameNo;
            this._partsQty = partsQty;
            this._partsOpNm = partsOpNm;
            this._standardName = standardName;
            this._catalogPartsMakerCd = catalogPartsMakerCd;
            this._clgPrtsNoWithHyphen = clgPrtsNoWithHyphen;
            this._coldDistrictsFlag = coldDistrictsFlag;
            this._colorNarrowingFlag = colorNarrowingFlag;
            this._trimNarrowingFlag = trimNarrowingFlag;
            this._equipNarrowingFlag = equipNarrowingFlag;
            this._newPrtsNoWithHyphen = newPrtsNoWithHyphen;
            this._newPrtsNoNoneHyphen = newPrtsNoNoneHyphen;
            this._makerOfferPartsName = makerOfferPartsName;
            this._priceOfferDate = PriceOfferDate;
            this._partsPrice = partsPrice;
            this._partsPriceStDate = partsPriceStDate;
            this._partsLayerCd = partsLayerCd;
            this._PartsUniqueNo = partsUniqueNo;
            this._makerOfferPartsKana = makerOfferPartsKana;
            this._openPriceDiv = openPriceDiv;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 ADD
            this.SeriesModel = seriesModel;
            this.CategorySignModel = categorySignModel;
            this.ExhaustGasSign = exhaustGasSign;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 ADD
            // 2009/10/23 Add >>>
            this.SrchPNmAcqrCarMkrCd = srchPNmAcqrCarMkrCd;
            // 2009/10/23 Add <<<
            // --- ADD m.suzuki 2011/05/18 ---------->>>>>
            this.AutoEstimatePartsCd = autoEstimatePartsCd;
            this.TbsPartsCdDerivedNm = tbsPartsCdDerivedNm;
            // --- ADD m.suzuki 2011/05/18 ----------<<<<<
            //>>>2013/02/12
            this.PrimeJoinLnkFlg = primeJoinLnkFlg;
            //<<<2013/02/12
            // --- ADD 2013/03/25 ---------->>>>>
            this._vinProduceStartNo = vinProduceStartNo;
            this._vinProduceEndNo = vinProduceEndNo;
            // --- ADD 2013/03/25 ----------<<<<<
            // ----ADD 2018/03/26 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j ------->>>>>
            this._blUtyPtThCd = blUtyPtThCd;
            this._blUtyPtCd = blUtyPtCd;
            this._blUtyPtSbCd = blUtyPtSbCd;
            // ----ADD 2018/03/26 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j -------<<<<<
        }
       
        /// <summary>
        /// UI�N���X���[�N��������
        /// </summary>
        /// <returns>RetPartsInf�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����RetPartsInf�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br />
        /// <br>Update Note      :   2018/03/26  30757 ���X�؁@�M�p</br>
        /// <br>�Ǘ��ԍ�         :   11470007-00</br>
        /// <br>                 :   NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j</br>
        /// <br>                     BL���ꕔ�i�R�[�h�֘A�����o�[�̒ǉ�</br>
        /// </remarks>
        public RetPartsInf Clone()
        {
            //>>>2013/02/12
            //// --- UPD m.suzuki 2011/05/18 ---------->>>>>
            ////// 2009/10/23 >>>
            //////// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 DEL
            ////////return new RetPartsInf(this._offerDate, this._PartsSearchCode, this._PartsNarrowingCode, this._partsName, this._partsNameKana, this._partsCode, this._workOrPartsDivNm, this._fullModelFixedNo, this._tbsPartsCode, this._tbsPartsCdDerivedNo, this._figshapeNo, this._modelPrtsAdptYm, this._modelPrtsAblsYm, this._modelPrtsAdptFrameNo, this._modelPrtsAblsFrameNo, this._partsQty, this._partsOpNm, this._standardName, this._catalogPartsMakerCd, this._clgPrtsNoWithHyphen, this._coldDistrictsFlag, this._colorNarrowingFlag, this._trimNarrowingFlag, this._equipNarrowingFlag, this._newPrtsNoWithHyphen, this._newPrtsNoNoneHyphen, this._makerOfferPartsName, this._priceOfferDate,this._partsPrice, this._partsPriceStDate, this._partsLayerCd, this._PartsUniqueNo, this._makerOfferPartsKana, this._openPriceDiv);
            //////// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 DEL
            //////// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 ADD
            //////return new RetPartsInf( this._offerDate, this._PartsSearchCode, this._PartsNarrowingCode, this._partsName, this._partsNameKana, this._partsCode, this._workOrPartsDivNm, this._fullModelFixedNo, this._tbsPartsCode, this._tbsPartsCdDerivedNo, this._figshapeNo, this._modelPrtsAdptYm, this._modelPrtsAblsYm, this._modelPrtsAdptFrameNo, this._modelPrtsAblsFrameNo, this._partsQty, this._partsOpNm, this._standardName, this._catalogPartsMakerCd, this._clgPrtsNoWithHyphen, this._coldDistrictsFlag, this._colorNarrowingFlag, this._trimNarrowingFlag, this._equipNarrowingFlag, this._newPrtsNoWithHyphen, this._newPrtsNoNoneHyphen, this._makerOfferPartsName, this._priceOfferDate, this._partsPrice, this._partsPriceStDate, this._partsLayerCd, this._PartsUniqueNo, this._makerOfferPartsKana, this._openPriceDiv, this._seriesModel, this._categorySignModel, this._exhaustGasSign );
            //////// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 ADD
            ////
            ////return new RetPartsInf(this._offerDate, this._PartsSearchCode, this._PartsNarrowingCode, this._partsName, this._partsNameKana, this._partsCode, this._workOrPartsDivNm, this._fullModelFixedNo, this._tbsPartsCode, this._tbsPartsCdDerivedNo, this._figshapeNo, this._modelPrtsAdptYm, this._modelPrtsAblsYm, this._modelPrtsAdptFrameNo, this._modelPrtsAblsFrameNo, this._partsQty, this._partsOpNm, this._standardName, this._catalogPartsMakerCd, this._clgPrtsNoWithHyphen, this._coldDistrictsFlag, this._colorNarrowingFlag, this._trimNarrowingFlag, this._equipNarrowingFlag, this._newPrtsNoWithHyphen, this._newPrtsNoNoneHyphen, this._makerOfferPartsName, this._priceOfferDate, this._partsPrice, this._partsPriceStDate, this._partsLayerCd, this._PartsUniqueNo, this._makerOfferPartsKana, this._openPriceDiv, this._seriesModel, this._categorySignModel, this._exhaustGasSign, this._srchPNmAcqrCarMkrCd);
            ////// 2009/10/23 <<<
            //return new RetPartsInf( this._offerDate, this._PartsSearchCode, this._PartsNarrowingCode, this._partsName, this._partsNameKana, this._partsCode, this._workOrPartsDivNm, this._fullModelFixedNo, this._tbsPartsCode, this._tbsPartsCdDerivedNo, this._figshapeNo, this._modelPrtsAdptYm, this._modelPrtsAblsYm, this._modelPrtsAdptFrameNo, this._modelPrtsAblsFrameNo, this._partsQty, this._partsOpNm, this._standardName, this._catalogPartsMakerCd, this._clgPrtsNoWithHyphen, this._coldDistrictsFlag, this._colorNarrowingFlag, this._trimNarrowingFlag, this._equipNarrowingFlag, this._newPrtsNoWithHyphen, this._newPrtsNoNoneHyphen, this._makerOfferPartsName, this._priceOfferDate, this._partsPrice, this._partsPriceStDate, this._partsLayerCd, this._PartsUniqueNo, this._makerOfferPartsKana, this._openPriceDiv, this._seriesModel, this._categorySignModel, this._exhaustGasSign, this._srchPNmAcqrCarMkrCd, this._autoEstimatePartsCd, this._tbsPartsCdDerivedNm );
            //// --- UPD m.suzuki 2011/05/18 ----------<<<<<

            // --- DEL 2013/03/25 ---------->>>>>
            //return new RetPartsInf(this._offerDate, this._PartsSearchCode, this._PartsNarrowingCode, this._partsName, this._partsNameKana, this._partsCode, this._workOrPartsDivNm, this._fullModelFixedNo, this._tbsPartsCode, this._tbsPartsCdDerivedNo, this._figshapeNo, this._modelPrtsAdptYm, this._modelPrtsAblsYm, this._modelPrtsAdptFrameNo, this._modelPrtsAblsFrameNo, this._partsQty, this._partsOpNm, this._standardName, this._catalogPartsMakerCd, this._clgPrtsNoWithHyphen, this._coldDistrictsFlag, this._colorNarrowingFlag, this._trimNarrowingFlag, this._equipNarrowingFlag, this._newPrtsNoWithHyphen, this._newPrtsNoNoneHyphen, this._makerOfferPartsName, this._priceOfferDate, this._partsPrice, this._partsPriceStDate, this._partsLayerCd, this._PartsUniqueNo, this._makerOfferPartsKana, this._openPriceDiv, this._seriesModel, this._categorySignModel, this._exhaustGasSign, this._srchPNmAcqrCarMkrCd, this._autoEstimatePartsCd, this._tbsPartsCdDerivedNm, this._primeJoinLnkFlg);
            //<<<2013/02/12
            // --- DEL 2013/03/25 ----------<<<<<
            // ----DEL 2018/03/26 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j ------->>>>>
            //// --- ADD 2013/03/25 ---------->>>>>
            //return new RetPartsInf(this._offerDate, this._PartsSearchCode, this._PartsNarrowingCode, this._partsName, this._partsNameKana, this._partsCode, this._workOrPartsDivNm, this._fullModelFixedNo, this._tbsPartsCode, this._tbsPartsCdDerivedNo, this._figshapeNo, this._modelPrtsAdptYm, this._modelPrtsAblsYm, this._modelPrtsAdptFrameNo, this._modelPrtsAblsFrameNo, this._partsQty, this._partsOpNm, this._standardName, this._catalogPartsMakerCd, this._clgPrtsNoWithHyphen, this._coldDistrictsFlag, this._colorNarrowingFlag, this._trimNarrowingFlag, this._equipNarrowingFlag, this._newPrtsNoWithHyphen, this._newPrtsNoNoneHyphen, this._makerOfferPartsName, this._priceOfferDate, this._partsPrice, this._partsPriceStDate, this._partsLayerCd, this._PartsUniqueNo, this._makerOfferPartsKana, this._openPriceDiv, this._seriesModel, this._categorySignModel, this._exhaustGasSign, this._srchPNmAcqrCarMkrCd, this._autoEstimatePartsCd, this._tbsPartsCdDerivedNm, this._primeJoinLnkFlg, this._vinProduceStartNo, this._vinProduceEndNo);
            //// --- ADD 2013/03/25 ----------<<<<<
            // ----DEL 2018/03/26 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j -------<<<<<
            // ----ADD 2018/03/26 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j ------->>>>>
            return new RetPartsInf(
                this._offerDate
                , this._PartsSearchCode
                , this._PartsNarrowingCode
                , this._partsName
                , this._partsNameKana
                , this._partsCode
                , this._workOrPartsDivNm
                , this._fullModelFixedNo
                , this._tbsPartsCode
                , this._tbsPartsCdDerivedNo
                , this._figshapeNo
                , this._modelPrtsAdptYm
                , this._modelPrtsAblsYm
                , this._modelPrtsAdptFrameNo
                , this._modelPrtsAblsFrameNo
                , this._partsQty
                , this._partsOpNm
                , this._standardName
                , this._catalogPartsMakerCd
                , this._clgPrtsNoWithHyphen
                , this._coldDistrictsFlag
                , this._colorNarrowingFlag
                , this._trimNarrowingFlag
                , this._equipNarrowingFlag
                , this._newPrtsNoWithHyphen
                , this._newPrtsNoNoneHyphen
                , this._makerOfferPartsName
                , this._priceOfferDate
                , this._partsPrice
                , this._partsPriceStDate
                , this._partsLayerCd
                , this._PartsUniqueNo
                , this._makerOfferPartsKana
                , this._openPriceDiv
                , this._seriesModel
                , this._categorySignModel
                , this._exhaustGasSign
                , this._srchPNmAcqrCarMkrCd
                , this._autoEstimatePartsCd
                , this._tbsPartsCdDerivedNm
                , this._primeJoinLnkFlg
                , this._vinProduceStartNo
                , this._vinProduceEndNo
                , this._blUtyPtThCd
                , this._blUtyPtCd
                , this._blUtyPtSbCd
                );
            // ----ADD 2018/03/26 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j -------<<<<<
        }
    }

    /// <summary>
    ///  Ver5.1.0.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>RetPartsInf�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   RetPartsInf�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// <br>Update Note      :   2009/10/23�@21024 ���X�� �����i���擾�J�[���[�J�[�R�[�h��ǉ�</br>
    /// <br>Update Note      :   2018/03/26  30757 ���X�؁@�M�p</br>
    /// <br>�Ǘ��ԍ�         :   11470007-00</br>
    /// <br>                 :   NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j</br>
    /// <br>                     BL���ꕔ�i�R�[�h�֘A�����o�[�̒ǉ�</br>
    /// </remarks>
    public class RetPartsInf_SerializationSurrogate_For_V5100 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o
        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RetPartsInf�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2018/03/26  30757 ���X�؁@�M�p</br>
        /// <br>�Ǘ��ԍ�         :   11470007-00</br>
        /// <br>                 :   NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j</br>
        /// <br>                     BL���ꕔ�i�R�[�h�֘A�����o�[�̒ǉ�</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  EmployeeWork_SerializationSurrogate_For_V5100.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RetPartsInf || graph is ArrayList))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(RetPartsInf).FullName));

            if (graph != null && graph is RetPartsInf)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RetPartsInf)
            {
                occurrence = 1;
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.1.0.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RetPartsInf");
            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            serInfo.MemberInfo.Add(typeof(Int64));
            serInfo.MemberInfo.Add(typeof(Int32));
            serInfo.MemberInfo.Add(typeof(Int32));
            serInfo.MemberInfo.Add(typeof(string));
            serInfo.MemberInfo.Add(typeof(string));
            serInfo.MemberInfo.Add(typeof(Int32));
            serInfo.MemberInfo.Add(typeof(string));
            serInfo.MemberInfo.Add(typeof(Int32));
            serInfo.MemberInfo.Add(typeof(Int32));
            serInfo.MemberInfo.Add(typeof(Int32));
            serInfo.MemberInfo.Add(typeof(string));//10th
            serInfo.MemberInfo.Add(typeof(Int32));
            serInfo.MemberInfo.Add(typeof(Int32));
            serInfo.MemberInfo.Add(typeof(Int32));
            serInfo.MemberInfo.Add(typeof(Int32));
            serInfo.MemberInfo.Add(typeof(Double));
            serInfo.MemberInfo.Add(typeof(string));
            serInfo.MemberInfo.Add(typeof(string));
            serInfo.MemberInfo.Add(typeof(Int32));
            serInfo.MemberInfo.Add(typeof(string));
            serInfo.MemberInfo.Add(typeof(Int32));
            serInfo.MemberInfo.Add(typeof(Int32));
            serInfo.MemberInfo.Add(typeof(Int32));
            serInfo.MemberInfo.Add(typeof(Int32));
            serInfo.MemberInfo.Add(typeof(string));
            serInfo.MemberInfo.Add(typeof(string));
            serInfo.MemberInfo.Add(typeof(string));
            serInfo.MemberInfo.Add(typeof(Int64));
            serInfo.MemberInfo.Add(typeof(Int64));
            serInfo.MemberInfo.Add(typeof(Int64));
            serInfo.MemberInfo.Add(typeof(string));//30th
            serInfo.MemberInfo.Add(typeof(Int64));
            serInfo.MemberInfo.Add(typeof(string));
            serInfo.MemberInfo.Add(typeof(Int32));
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 ADD
            serInfo.MemberInfo.Add( typeof( string ) );
            serInfo.MemberInfo.Add( typeof( string ) );
            serInfo.MemberInfo.Add( typeof( string ) );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 ADD
            serInfo.MemberInfo.Add(typeof(Int32));      // 2009/10/23 Add
            // --- ADD m.suzuki 2011/05/18 ---------->>>>>
            serInfo.MemberInfo.Add( typeof( string ) );
            serInfo.MemberInfo.Add( typeof( string ) );
            // --- ADD m.suzuki 2011/05/18 ----------<<<<<
            //>>>2013/02/12
            serInfo.MemberInfo.Add(typeof(Int32));
            //<<<2013/02/12

            // --- ADD 2013/03/25 ---------->>>>>
            serInfo.MemberInfo.Add(typeof(Int32));     // VinProduceStartNo
            serInfo.MemberInfo.Add(typeof(Int32));     // VinProduceEndNo
            // --- ADD 2013/03/25 ----------<<<<<

            // ----ADD 2018/03/26 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j ------->>>>>
            serInfo.MemberInfo.Add( typeof( string ) ); // BlUtyPtThCdRF
            serInfo.MemberInfo.Add( typeof( string ) ); // BlUtyPtCdRF
            serInfo.MemberInfo.Add( typeof( Int32 ) );  // BlUtyPtSbCdRF
            // ----ADD 2018/03/26 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j -------<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is RetPartsInf)
            {
                RetPartsInf temp = (RetPartsInf)graph;

                writer.Write(temp.OfferDate.Ticks);
                writer.Write(temp.PartsSearchCode);
                writer.Write(temp.PartsNarrowingCode);
                writer.Write(temp.PartsName);
                writer.Write(temp.PartsNameKana);
                writer.Write(temp.PartsCode);
                writer.Write(temp.WorkOrPartsDivNm);
                writer.Write(temp.FullModelFixedNo);
                writer.Write(temp.TbsPartsCode);
                writer.Write(temp.TbsPartsCdDerivedNo);
                writer.Write(temp.FigShapeNo);
                writer.Write(temp.ModelPrtsAdptYm);
                writer.Write(temp.ModelPrtsAblsYm);
                writer.Write(temp.ModelPrtsAdptFrameNo);
                writer.Write(temp.ModelPrtsAblsFrameNo);
                writer.Write(temp.PartsQty);
                writer.Write(temp.PartsOpNm);
                writer.Write(temp.StandardName);
                writer.Write(temp.CatalogPartsMakerCd);
                writer.Write(temp.ClgPrtsNoWithHyphen);
                writer.Write(temp.ColdDistrictsFlag);
                writer.Write(temp.ColorNarrowingFlag);
                writer.Write(temp.TrimNarrowingFlag);
                writer.Write(temp.EquipNarrowingFlag);
                writer.Write(temp.NewPrtsNoWithHyphen);
                writer.Write(temp.NewPrtsNoNoneHyphen);
                writer.Write(temp.MakerOfferPartsName);
                writer.Write(temp.PriceOfferDate.Ticks);
                writer.Write(temp.PartsPrice);
                writer.Write((Int64)temp.PartsPriceStDate.Ticks);
                writer.Write(temp.PartsLayerCd);
                writer.Write(temp.PartsUniqueNo);
                writer.Write(temp.MakerOfferPartsKana);
                writer.Write(temp.OpenPriceDiv);
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 ADD
                writer.Write( temp.SeriesModel );
                writer.Write( temp.CategorySignModel );
                writer.Write( temp.ExhaustGasSign );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 ADD
                writer.Write(temp.SrchPNmAcqrCarMkrCd);     // 2009/10/23 Add
                // --- ADD m.suzuki 2011/05/18 ---------->>>>>
                writer.Write( temp.AutoEstimatePartsCd );
                writer.Write( temp.TbsPartsCdDerivedNm );
                // --- ADD m.suzuki 2011/05/18 ----------<<<<<
                //>>>2013/02/12
                writer.Write(temp.PrimeJoinLnkFlg);
                //<<<2013/02/12

                // --- ADD 2013/03/25 ---------->>>>>
                writer.Write(temp.VinProduceStartNo);        // VinProduceStartNo
                writer.Write(temp.VinProduceEndNo);          // VinProduceEndNo
                // --- ADD 2013/03/25 ----------<<<<<
                // ----ADD 2018/03/26 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j ------->>>>>
                writer.Write( temp.BlUtyPtThCd );         // BlUtyPtThCd
                writer.Write( temp.BlUtyPtCd );           // BlUtyPtCd
                writer.Write( temp.BlUtyPtSbCd );         // BlUtyPtSbCd
                // ----ADD 2018/03/26 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j -------<<<<<

            }
            else if (graph is ArrayList)
            {
                ArrayList lst = (ArrayList)graph;
                for (int i = 0; i < occurrence; ++i)
                {

                    RetPartsInf temp = (RetPartsInf)lst[i];

                    writer.Write(temp.OfferDate.Ticks);
                    writer.Write(temp.PartsSearchCode);
                    writer.Write(temp.PartsNarrowingCode);
                    writer.Write(temp.PartsName);
                    writer.Write(temp.PartsNameKana);
                    writer.Write(temp.PartsCode);
                    writer.Write(temp.WorkOrPartsDivNm);
                    writer.Write(temp.FullModelFixedNo);
                    writer.Write(temp.TbsPartsCode);
                    writer.Write(temp.TbsPartsCdDerivedNo);
                    writer.Write(temp.FigShapeNo);
                    writer.Write(temp.ModelPrtsAdptYm);
                    writer.Write(temp.ModelPrtsAblsYm);
                    writer.Write(temp.ModelPrtsAdptFrameNo);
                    writer.Write(temp.ModelPrtsAblsFrameNo);
                    writer.Write(temp.PartsQty);
                    writer.Write(temp.PartsOpNm);
                    writer.Write(temp.StandardName);
                    writer.Write(temp.CatalogPartsMakerCd);
                    writer.Write(temp.ClgPrtsNoWithHyphen);
                    writer.Write(temp.ColdDistrictsFlag);
                    writer.Write(temp.ColorNarrowingFlag);
                    writer.Write(temp.TrimNarrowingFlag);
                    writer.Write(temp.EquipNarrowingFlag);
                    writer.Write(temp.NewPrtsNoWithHyphen);
                    writer.Write(temp.NewPrtsNoNoneHyphen);
                    writer.Write(temp.MakerOfferPartsName);
                    writer.Write(temp.PriceOfferDate.Ticks);
                    writer.Write(temp.PartsPrice);
                    writer.Write((Int64)temp.PartsPriceStDate.Ticks);
                    writer.Write(temp.PartsLayerCd);
                    writer.Write(temp.PartsUniqueNo);
                    writer.Write(temp.MakerOfferPartsKana);
                    writer.Write(temp.OpenPriceDiv);
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 ADD
                    writer.Write( temp.SeriesModel );
                    writer.Write( temp.CategorySignModel );
                    writer.Write( temp.ExhaustGasSign );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 ADD
                    writer.Write(temp.SrchPNmAcqrCarMkrCd);     // 2009/10/23 Add
                    // --- ADD m.suzuki 2011/05/18 ---------->>>>>
                    writer.Write( temp.AutoEstimatePartsCd );
                    writer.Write( temp.TbsPartsCdDerivedNm );
                    // --- ADD m.suzuki 2011/05/18 ----------<<<<<
                    //>>>2013/02/12
                    writer.Write(temp.PrimeJoinLnkFlg);
                    //<<<2013/02/12
                    // --- ADD 2013/03/25 ---------->>>>>
                    writer.Write(temp.VinProduceStartNo);        // VinProduceStartNo
                    writer.Write(temp.VinProduceEndNo);          // VinProduceEndNo
                    // --- ADD 2013/03/25 ----------<<<<<

                    // ----ADD 2018/03/26 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j ------->>>>>
                    writer.Write( temp.BlUtyPtThCd );         // BlUtyPtThCd
                    writer.Write( temp.BlUtyPtCd );           // BlUtyPtCd
                    writer.Write( temp.BlUtyPtSbCd );         // BlUtyPtSbCd
                    // ----ADD 2018/03/26 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j -------<<<<<
                }

            }
        }

        /// <summary>
        /// RetPartsInf�����o��(public�v���p�e�B��)
        /// </summary>
        //>>>2013/02/12
        //// --- UPD m.suzuki 2011/05/18 ---------->>>>>
        ////// 2009/10/23 >>>
        //////// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 DEL
        ////////private const int currentMemberCount = 34;
        //////// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 DEL
        //////// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 ADD
        //////private const int currentMemberCount = 37;
        //////// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 ADD
        ////
        ////private const int currentMemberCount = 38;
        ////// 2009/10/23 <<<
        //private const int currentMemberCount = 40;
        //// --- UPD m.suzuki 2011/05/18 ----------<<<<<
        // --- DEL 2013/03/25 ---------->>>>>
        //private const int currentMemberCount = 41;
        //<<<2013/02/12
        // --- DEL 2013/03/25 ----------<<<<<
        // ----DEL 2018/03/26 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j ------->>>>>
        //// --- ADD 2013/03/25 ---------->>>>>
        //private const int currentMemberCount = 43;
        //// --- ADD 2013/03/25 ----------<<<<<
        // ----DEL 2018/03/26 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j -------<<<<<
        // ----ADD 2018/03/26 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j ------->>>>>
        private const int currentMemberCount = 46;
        // ----ADD 2018/03/26 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j -------<<<<<


        /// <summary>
        ///  RetPartsInf�C���X�^���X�擾
        /// </summary>
        /// <returns>RetPartsInf�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RetPartsInf�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br />
        /// <br>Update Note      :   2018/03/26  30757 ���X�؁@�M�p</br>
        /// <br>�Ǘ��ԍ�         :   11470007-00</br>
        /// <br>                 :   NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j</br>
        /// <br>                     BL���ꕔ�i�R�[�h�֘A�����o�[�̒ǉ�</br>
        /// </remarks>
        private RetPartsInf GetRetPartsInf(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            RetPartsInf temp = new RetPartsInf();

            temp.OfferDate = new DateTime(reader.ReadInt64());
            temp.PartsSearchCode = reader.ReadInt32();
            temp.PartsNarrowingCode = reader.ReadInt32();
            temp.PartsName = reader.ReadString();
            temp.PartsNameKana = reader.ReadString();
            temp.PartsCode = reader.ReadInt32();
            temp.WorkOrPartsDivNm = reader.ReadString();
            temp.FullModelFixedNo = reader.ReadInt32();
            temp.TbsPartsCode = reader.ReadInt32();
            temp.TbsPartsCdDerivedNo = reader.ReadInt32();
            temp.FigShapeNo = reader.ReadString();
            temp.ModelPrtsAdptYm = reader.ReadInt32();
            temp.ModelPrtsAblsYm = reader.ReadInt32();
            temp.ModelPrtsAdptFrameNo = reader.ReadInt32();
            temp.ModelPrtsAblsFrameNo = reader.ReadInt32();
            temp.PartsQty = reader.ReadDouble();
            temp.PartsOpNm = reader.ReadString();
            temp.StandardName = reader.ReadString();
            temp.CatalogPartsMakerCd = reader.ReadInt32();
            temp.ClgPrtsNoWithHyphen = reader.ReadString();
            temp.ColdDistrictsFlag = reader.ReadInt32();
            temp.ColorNarrowingFlag = reader.ReadInt32();
            temp.TrimNarrowingFlag = reader.ReadInt32();
            temp.EquipNarrowingFlag = reader.ReadInt32();
            temp.NewPrtsNoWithHyphen = reader.ReadString();
            temp.NewPrtsNoNoneHyphen = reader.ReadString();
            temp.MakerOfferPartsName = reader.ReadString();
            temp.PriceOfferDate = new DateTime(reader.ReadInt64());
            temp.PartsPrice = reader.ReadInt64();
            temp.PartsPriceStDate = new DateTime(reader.ReadInt64());
            temp.PartsLayerCd = reader.ReadString();
            temp.PartsUniqueNo = reader.ReadInt64();
            temp.MakerOfferPartsKana = reader.ReadString();
            temp.OpenPriceDiv = reader.ReadInt32();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 ADD
            temp.SeriesModel = reader.ReadString();
            temp.CategorySignModel = reader.ReadString();
            temp.ExhaustGasSign = reader.ReadString();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 ADD
            temp.SrchPNmAcqrCarMkrCd = reader.ReadInt32();  // 2009/10/22 Add
            // --- ADD m.suzuki 2011/05/18 ---------->>>>>
            temp.AutoEstimatePartsCd = reader.ReadString();
            temp.TbsPartsCdDerivedNm = reader.ReadString();
            // --- ADD m.suzuki 2011/05/18 ----------<<<<<
            //>>>2013/02/12
            temp.PrimeJoinLnkFlg = reader.ReadInt32();
            //<<<2013/02/12

            // --- ADD 2013/03/25 ---------->>>>>
            temp.VinProduceStartNo = reader.ReadInt32();       // VinProduceStartNo
            temp.VinProduceEndNo = reader.ReadInt32();         // VinProduceEndNo
            // --- ADD 2013/03/25 ----------<<<<<

            // ----ADD 2018/03/26 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j ------->>>>>
            temp.BlUtyPtThCd = reader.ReadString();           // BlUtyPtThCd
            temp.BlUtyPtCd = reader.ReadString();             // BlUtyPtCd
            temp.BlUtyPtSbCd = reader.ReadInt32();            // BlUtyPtSbCd
            // ----ADD 2018/03/26 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j -------<<<<<

            //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
            //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
            //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
            //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
                //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
                //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
                //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //�ǂݔ�΂�
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.1.0.0�p�̃J�X�^���f�V���A���C�U�ł�
        /// </summary>
        /// <returns>RetPartsInf�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RetPartsInf�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RetPartsInf temp = GetRetPartsInf(reader, serInfo);
                lst.Add(temp);
            }
            retValue = lst;
            return retValue;
        }

        #endregion
    }
    #endregion

    /// <summary>
    ///                      ���i���i�擾�p�����[�^
    /// </summary>
    /// <remarks>
    /// <br>Date             :   2005/04/14</br>
    /// <br>Genarated Date   :   2005/04/14</br>
    /// <br></br>
    /// <br>Update Note: 2010/06/04  22018 ��� ���b</br>
    /// <br>           : ���ʕ�����</br>
    /// <br>           : �@���R���� 2010/04/28 �̑g��</br>
    /// <br></br>
    /// <br>Update Note: 2010/06/12  22018 ��� ���b</br>
    /// <br>           : ���ʕ�����</br>
    /// <br>           : �@�Q�փI�v�V�����Ή��i2�ֵ�߼��=OFF�Ȃ�2��Ұ�������O����j</br>
    /// <br></br>
    /// <br>Update Note: 2013/03/25�@FSI�֓� �a�G</br>
    /// <br>           : 10900269-00 SPK�ԑ�ԍ�������Ή�</br>
    /// <br>           :   ����������VIN�R�[�h�E�n���h���ʒu���E���Y�H��R�[�h��ǉ�</br>
    /// <br />
    /// <br>Update Note: 2018/03/26  30757 ���X�؁@�M�p</br>
    /// <br>�Ǘ��ԍ�   : 11470007-00</br>
    /// <br>           : NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j</br>
    /// <br>             BL���ꕔ�i�R�[�h�֘A�����o�[�̒ǉ�</br>
    /// </remarks>
    [Serializable]
    public class GetPartsInfPara
    {
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public GetPartsInfPara()
        {
            _NoSubst = 0;
        }

        //>>>>20060710 iwa add start
        /// <summary>�n�C�t���t�ŐV���i�i��</summary>
        private string _PrtsNoWithHyphen = "";
        /// <summary>�n�C�t�����ŐV���i�i��</summary>
        private string _PrtsNoNoneHyphen = "";
        //<<<<20060710 iwa add end

        ///����n���i���o�敪 0:�S���o�i�����j 1:�W���n�敔�i�̂ݒ��o 2:����n���i�̂ݒ��o
        private int _ColdDistrictsExtrDivCd;
        /// Ұ��
        private int _MakerCode;
        /// �Ԏ�
        private int _ModelCode;
        /// �Ԏ�T�u
        private int _ModelSubCode;
        /// ���Y�N��
        private int _ProduceTypeOfYear;
        /// �V���V�[No
        private string _ChassisNo;
        /// ��ƃR�[�h
        private string _EnterpriseCode;
        /// �v���^���Œ�ԍ�
        private int[] _FullModelFixedNo;
        /// �ޕʔԍ�
        private int _CategoryNo;
        /// �^���w��ԍ�
        private int _ModelDesignationNo;
        /// �t���^��
        private string _Model12FullModel;
        /// �����i�R�[�h
        private int _TbsPartsCode;
        /// Fig�}��
        private string _FigShapeNo;
        /// �J���[�R�[�h
        private string _ColorCdInfoNo;
        /// �g�����R�[�h
        private string _TrimCode;
        /// �������
        private Equipment[] _alEquipment;
        /// ��֌����Ȃ��t���O
        private int _NoSubst;
        ///// �ō����i�������[�h
        //private int _MaxPriceMode;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/16 ADD
        /// <summary>���i�K�p���t</summary>
        private DateTime _PriceDate;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/16 ADD

        /// <summary>���i�ԍ������敪</summary>
        /// <remarks>0:���S��v,1:�O����v����,2:�����v����,3:�B������</remarks>
        private int _SrchTyp;

        // --- ADD m.suzuki 2010/04/28 ---------->>>>>
        /// �ʏ팟�����O�t���O
        private bool _normalSearchExclude;
        /// �����L�[���X�g�i���R�����p�j
        private ArrayList _searchKeyList;
        // --- ADD m.suzuki 2010/04/28 ----------<<<<<
        // --- ADD m.suzuki 2010/06/12 ---------->>>>>
        /// <summary>�Q�փ��[�J�[���O�t���O</summary>
        private bool _twoWheelerMakerExclude;
        /// <summary>�Q�փ��[�J�[�J�n</summary>
        private int _twoWheelerMakerCdSt;
        /// <summary>�Q�փ��[�J�[�I��</summary>
        private int _twoWheelerMakerCdEd;
        // --- ADD m.suzuki 2010/06/12 ----------<<<<<
        // --- ADD m.suzuki 2011/05/18 ---------->>>>>
        /// <summary>BL�R�[�h�}��</summary>
        private int _tbsPartsCdDerivedNo;
        // --- ADD m.suzuki 2011/05/18 ----------<<<<<

        // --- ADD 2013/03/25 ---------->>>>>
        /// <summary>VIN�R�[�h</summary>
        private int _vinCode;

        /// <summary>�n���h���ʒu���</summary>
        private int _handleInfoCd;

        /// <summary>���Y�H��R�[�h</summary>
        private string _productionFactoryCd = "";
        // --- ADD 2013/03/25 ----------<<<<<

        // ----ADD 2018/03/26 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j ------->>>>>
        /// <summary>BL���ꕔ�i�R�[�h(�X���[�R�[�h��)</summary>
        private string _blUtyPtThCd = string.Empty;
        /// <summary>BL���ꕔ�i�T�u�R�[�h</summary>
        private Int32 _blUtyPtSbCd = 0;
        // ----ADD 2018/03/26 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j -------<<<<<

        /// <summary>���i�ԍ������敪</summary>
        /// <remarks>0:���S��v,1:�O����v����,2:�����v����,3:�B������</remarks>
        public int SearchType
        {
            get { return _SrchTyp; }
            set { _SrchTyp = value; }
        }

        //>>>>20060710 iwa add start
        /// �n�C�t���t�ŐV���i�i��
        public string PrtsNoWithHyphen
        {
            get { return this._PrtsNoWithHyphen; }
            set { this._PrtsNoWithHyphen = value; }
        }
        /// �n�C�t�����ŐV���i�i��
        public string PrtsNoNoneHyphen
        {
            get { return this._PrtsNoNoneHyphen; }
            set { this._PrtsNoNoneHyphen = value; }
        }
        //<<<<20060710 iwa add end

        /// public propaty name  :  PartsRateDivCe
        /// <summary>����n���i���o�敪�v���p�e�B0:�S���o�i�����j 1:�W���n�敔�i�̂ݒ��o 2:����n���i�̂ݒ��o</summary>
        /// <value>����n���i���o�敪</value>
        /// ----------------------------------------------------------------------
        public Int32 ColdDistrictsExtrDivCd
        {
            get { return _ColdDistrictsExtrDivCd; }
            set { _ColdDistrictsExtrDivCd = value; }
        }
        /// Fig�}��
        public string FigShapeNo
        {
            get { return this._FigShapeNo; }
            set { this._FigShapeNo = value; }
        }
        /// Ұ��
        public int MakerCode
        {
            get { return this._MakerCode; }
            set { this._MakerCode = value; }
        }
        /// �Ԏ�
        public int ModelCode
        {
            get { return this._ModelCode; }
            set { this._ModelCode = value; }
        }
        /// �Ԏ�T�u
        public int ModelSubCode
        {
            get { return this._ModelSubCode; }
            set { this._ModelSubCode = value; }
        }
        /// ���Y�N��
        public int ProduceTypeOfYear
        {
            get { return this._ProduceTypeOfYear; }
            set { this._ProduceTypeOfYear = value; }
        }
        /// �V���V�[No
        public string ChassisNo
        {
            get { return this._ChassisNo; }
            set { this._ChassisNo = value; }
        }
        /// <summary>
        /// ��ƃR�[�h
        /// </summary>
        public string EnterpriseCode
        {
            get { return this._EnterpriseCode; }
            set { this._EnterpriseCode = value; }
        }
        /// <summary>
        /// �t���^���Œ�ԍ�
        /// </summary>
        public int[] FullModelFixedNo
        {
            get { return this._FullModelFixedNo; }
            set { this._FullModelFixedNo = value; }
        }
        /// <summary>
        /// �ޕʔԍ�
        /// </summary>
        public int CategoryNo
        {
            get { return this._CategoryNo; }
            set { this._CategoryNo = value; }
        }
        /// <summary>
        /// �^���w��ԍ�
        /// </summary>
        public int ModelDesignationNo
        {
            get { return this._ModelDesignationNo; }
            set { this._ModelDesignationNo = value; }
        }
        /// <summary>
        /// �t���^��
        /// </summary>
        public string Model12FullModel
        {
            get { return this._Model12FullModel; }
            set { this._Model12FullModel = value; }
        }
        /// <summary>
        /// �����i�R�[�h
        /// </summary>
        public int TbsPartsCode
        {
            get { return this._TbsPartsCode; }
            set { this._TbsPartsCode = value; }
        }
        /// <summary>
        /// �J���[�R�[�h
        /// </summary>
        public string ColorCdInfoNo
        {
            get { return this._ColorCdInfoNo; }
            set { this._ColorCdInfoNo = value; }
        }
        /// <summary>
        /// �g�����R�[�h
        /// </summary>
        public string TrimCode
        {
            get { return this._TrimCode; }
            set { this._TrimCode = value; }
        }
        /// <summary>
        /// �������
        /// </summary>
        public Equipment[] alEquipment
        {
            get { return this._alEquipment; }
            set { this._alEquipment = value; }
        }
        /// <summary>
        /// ��֌����Ȃ��t���O  0:��֌�������@ 1:��֌����Ȃ�
        /// </summary>
        public int NoSubst
        {
            get { return this._NoSubst; }
            set { this._NoSubst = value; }
        }
        ///// <summary>
        ///// �ō����i�擾���[�h 0:�S�����[�h 1:�ō��_�����R�[�h�擾
        ///// </summary>
        //public int MaxPriceMode
        //{
        //    get { return this._MaxPriceMode; }
        //    set { this._MaxPriceMode = value; }
        //}
        
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/16 ADD
        /// <summary>
        /// ���i�K�p���t
        /// </summary>
        public DateTime PriceDate
        {
            get { return _PriceDate; }
            set { _PriceDate = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/16 ADD
        // --- ADD m.suzuki 2010/04/28 ---------->>>>>
        /// <summary>
        /// �ʏ팟�����O�t���O
        /// </summary>
        public bool NormalSearchExclude
        {
            get { return _normalSearchExclude; }
            set { _normalSearchExclude = value; }
        }
        /// <summary>
        /// �����L�[���X�g�i���R�����p�j
        /// </summary>
        public ArrayList SearchKeyList
        {
            get { return _searchKeyList; }
            set { _searchKeyList = value; }
        }
        // --- ADD m.suzuki 2010/04/28 ----------<<<<<
        // --- ADD m.suzuki 2010/06/12 ---------->>>>>
        /// <summary>
        /// �Q�փ��[�J�[���O�t���O
        /// </summary>
        public bool TwoWheelerMakerExclude
        {
            get { return _twoWheelerMakerExclude; }
            set { _twoWheelerMakerExclude = value; }
        }
        /// <summary>
        /// �Q�փ��[�J�[�R�[�h�J�n
        /// </summary>
        public int TwoWheelerMakerCdSt
        {
            get { return _twoWheelerMakerCdSt; }
            set { _twoWheelerMakerCdSt = value; }
        }
        /// <summary>
        /// �Q�փ��[�J�[�R�[�h�I��
        /// </summary>
        public int TwoWheelerMakerCdEd
        {
            get { return _twoWheelerMakerCdEd; }
            set { _twoWheelerMakerCdEd = value; }
        }
        // --- ADD m.suzuki 2010/06/12 ----------<<<<<
        // --- ADD m.suzuki 2011/05/18 ---------->>>>>
        /// <summary>
        /// BL�R�[�h�}��
        /// </summary>
        public int TbsPartsCdDerivedNo
        {
            get { return _tbsPartsCdDerivedNo; }
            set { _tbsPartsCdDerivedNo = value; }
        }
        // --- ADD m.suzuki 2011/05/18 ----------<<<<<

        // --- ADD 2013/03/25 ---------->>>>>
        /// <summary>VIN�R�[�h</summary>
        public int VinCode
        {
            get { return _vinCode; }
            set { _vinCode = value; }
        }

        /// <summary>�n���h���ʒu���</summary>
        public int HandleInfoCd
        {
            get { return _handleInfoCd; }
            set { _handleInfoCd = value; }
        }

        /// <summary>���Y�H��R�[�h</summary>
        public string ProductionFactoryCd
        {
            get { return _productionFactoryCd; }
            set { _productionFactoryCd = value; }
        }
        // --- ADD 2013/03/25 ----------<<<<<

        // ----ADD 2018/03/26 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j ------->>>>>
        /// <summary>BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�p�����[�^</summary>
        /// <value>BL���ꕔ�i�R�[�h(�X���[�R�[�h��)</value>
        /// <remarks>
        /// <br>Note       : BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�̎擾�Ɛݒ�</br>
        /// <br>Programmer : 30757 ���X�؁@�M�p</br>
        /// <br>Date       : 2018/03/26</br>
        /// <br>�Ǘ��ԍ�   :   11470007-00</br>
        /// <br>           :   NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j</br>
        /// </remarks>
        public string BlUtyPtThCd
        {
            get { return this._blUtyPtThCd; }
            set { this._blUtyPtThCd = value; }
        }
        /// <summary>BL���ꕔ�i�T�u�R�[�h�p�����[�^</summary>
        /// <value>BL���ꕔ�i�T�u�R�[�h</value>
        /// <remarks>
        /// <br>Note       : BL���ꕔ�i�T�u�R�[�h�̎擾�Ɛݒ�</br>
        /// <br>Programmer : 30757 ���X�؁@�M�p</br>
        /// <br>Date       : 2018/03/26</br>
        /// <br>�Ǘ��ԍ�   :   11470007-00</br>
        /// <br>           :   NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j</br>
        /// </remarks>
        public Int32 BlUtyPtSbCd
        {
            get { return this._blUtyPtSbCd; }
            set { this._blUtyPtSbCd = value; }
        }
        // ----ADD 2018/03/26 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j -------<<<<<
    }

    /// <summary>
    /// �������p�����[�^
    /// </summary>
    [Serializable]
    public struct Equipment
    {
        /// <summary>
        /// �������ރR�[�h
        /// </summary>
        public int EquipmentGenreCd;
        /// <summary>
        /// �������ޖ���
        /// </summary>
        public string EquipmentGenreNm;
        /// <summary>
        /// �����R�[�h
        /// </summary>
        public int EquipmentCode;
        /// <summary>
        /// ��������
        /// </summary>
        public string EquipmentName;
    }

    /// <summary>
    ///                      ���i�ꊇ���i�擾�p�����[�^
    /// </summary>
    /// <remarks>
    /// <br>Date             :   2005/04/14</br>
    /// <br>Genarated Date   :   2005/04/14</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    public class SerchPartsInfPara
    {
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public SerchPartsInfPara()
        {
        }
        /// Ұ��
        private int _MakerCode;
        /// �Ԏ�
        private int _ModelCode;
        /// �Ԏ�T�u
        private int _ModelSubCode;
        /// ��ƃR�[�h
        private string _EnterpriseCode;
        /// �v���^���Œ�ԍ�
        private int[] _FullModelFixedNo;
        /// �ޕʔԍ�
        private int _CategoryNo;
        /// �^���w��ԍ�
        private int _ModelDesignationNo;
        /// �t���^��
        private string _Model12FullModel;
        /// Ұ��
        public int MakerCode
        {
            get { return this._MakerCode; }
            set { this._MakerCode = value; }
        }
        /// �Ԏ�
        public int ModelCode
        {
            get { return this._ModelCode; }
            set { this._ModelCode = value; }
        }
        /// �Ԏ�T�u
        public int ModelSubCode
        {
            get { return this._ModelSubCode; }
            set { this._ModelSubCode = value; }
        }
        /// <summary>
        /// ��ƃR�[�h
        /// </summary>
        public string EnterpriseCode
        {
            get { return this._EnterpriseCode; }
            set { this._EnterpriseCode = value; }
        }
        /// <summary>
        /// �t���^���Œ�ԍ�
        /// </summary>
        public int[] FullModelFixedNo
        {
            get { return this._FullModelFixedNo; }
            set { this._FullModelFixedNo = value; }
        }
        /// <summary>
        /// �ޕʔԍ�
        /// </summary>
        public int CategoryNo
        {
            get { return this._CategoryNo; }
            set { this._CategoryNo = value; }
        }
        /// <summary>
        /// �^���w��ԍ�
        /// </summary>
        public int ModelDesignationNo
        {
            get { return this._ModelDesignationNo; }
            set { this._ModelDesignationNo = value; }
        }
        /// <summary>
        /// �t���^��
        /// </summary>
        public string Model12FullModel
        {
            get { return this._Model12FullModel; }
            set { this._Model12FullModel = value; }
        }
    }

    /// <summary>
    ///                      PartsModelLnkWork
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���i�[�^���A�g�N���X</br>
    /// <br>Programmer       :   �n���h���C�h</br>
    /// <br>Date             :   2007/03/27</br>
    /// <br>Genarated Date   :   </br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    public class PartsModelLnkWork
    {
        /// <summary>���i�ŗL�ԍ�</summary>
        private Int64 _partsproperno;

        /// <summary>�t���^���Œ�ԍ��z��</summary>
        private List<Int32> _fullModelFixedNos;

        /// public propaty name  :  PartsProperNo
        /// <summary>���i�ŗL�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ŗL�ԍ��v���p�e�B�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 PartsProperNo
        {
            get { return _partsproperno; }
            set { _partsproperno = value; }
        }

        /// public propaty name  :  FullModelFixedNos
        /// <summary>�t���^���Œ�ԍ��z��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t���^���Œ�ԍ��z��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public List<Int32> FullModelFixedNos
        {
            get { return _fullModelFixedNos; }
            set { _fullModelFixedNos = value; }
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PartsModelLnkWork()
        {
        }
    }

    /// <summary>
    ///                      �񋟕��i�������o�����N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �񋟕��i�������o�����N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :    </br>
    /// <br>Genarated Date   :   2008/05/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class OfrPrtsSrchCndWork
    {
        /// <summary>���[�J�[�R�[�h</summary>
        private Int32 _makerCode;

        /// <summary>���i�i��</summary>
        private string _prtsNo = "";

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

        /// <summary>���i�i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrtsNo
        {
            get { return _prtsNo; }
            set { _prtsNo = value; }
        }

        /// <summary>
        /// �񋟕��i�������o�����N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>OfrPrtsSrchCndWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OfrPrtsSrchCndWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public OfrPrtsSrchCndWork()
        {
        }

        /// <summary>
        /// �񋟕��i�������o�����N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>OfrPrtsSrchCndWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OfrPrtsSrchCndWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public OfrPrtsSrchCndWork(OfrPrtsSrchCndWork srcObject)
        {
            _makerCode = srcObject.MakerCode;
            _prtsNo = srcObject.PrtsNo;
        }

    }

    /// <summary>
    ///                      ���i�ꊇ�o�^�������o�����N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���i�ꊇ�o�^�������o�����N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :    </br>
    /// <br>Genarated Date   :   2008/05/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PrtsSrchCndWork
    {
        /// <summary>���[�J�[�R�[�h</summary>
        private Int32 _makerCode;

        /// <summary>BL�R�[�h</summary>
        private Int32 _BLCode;

        /// <summary>���i�i��[�O����v�����̂݁FPM7�p��]</summary>
        private string _prtsNo = "";

        /// <summary>�擾�f�[�^MAX����</summary>
        private Int32 _MaxCnt;

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

        /// <summary>BL�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLCode
        {
            get { return _BLCode; }
            set { _BLCode = value; }
        }

        /// <summary>���i�i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrtsNo
        {
            get { return _prtsNo; }
            set { _prtsNo = value; }
        }

        /// <summary>�擾�f�[�^MAX�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �擾�f�[�^MAX�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MaxCnt
        {
            get { return _MaxCnt; }
            set { _MaxCnt = value; }
        }

        /// <summary>
        /// ���i�ꊇ�o�^�������o�����N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PrtsSrchCndWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrtsSrchCndWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PrtsSrchCndWork()
        {
        }

        /// <summary>
        /// ���i�ꊇ�o�^�������o�����N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PrtsSrchCndWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrtsSrchCndWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PrtsSrchCndWork(OfrPrtsSrchCndWork srcObject)
        {
            _makerCode = srcObject.MakerCode;
            _prtsNo = srcObject.PrtsNo;
        }

    }

}

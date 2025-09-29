using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   FreeSearchPartsSRetWork
    /// <summary>
    ///                      ���R�������i���o���ʃ��[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���R�������i���o���ʃ��[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2010/04/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class FreeSearchPartsSRetWork
    {
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>�X�V�]�ƈ��R�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private string _updEmployeeCode = "";

        /// <summary>�X�V�A�Z���u��ID1</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>�X�V�A�Z���u��ID2</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>���R�������i�ŗL�ԍ�</summary>
        private string _freSrchPrtPropNo = "";

        /// <summary>���[�J�[�R�[�h</summary>
        /// <remarks>1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
        private Int32 _makerCode;

        /// <summary>�Ԏ�R�[�h</summary>
        /// <remarks>�Ԗ��R�[�h(BL��) 1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
        private Int32 _modelCode;

        /// <summary>�Ԏ�T�u�R�[�h</summary>
        /// <remarks>0�`899:�񋟕�,900�`հ�ް�o�^</remarks>
        private Int32 _modelSubCode;

        /// <summary>�^���i�t���^�j</summary>
        /// <remarks>�t���^��(44���p)</remarks>
        private string _fullModel = "";

        /// <summary>�a�k���i�R�[�h</summary>
        private Int32 _tbsPartsCode;

        /// <summary>�a�k���i�R�[�h�}��</summary>
        /// <remarks>�����g�p���ځi���C�A�E�g�ɂ͓���Ă����j</remarks>
        private Int32 _tbsPartsCdDerivedNo;

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>�n�C�t�������i�ԍ�</summary>
        private string _goodsNoNoneHyphen = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���iQTY</summary>
        private Double _partsQty;

        /// <summary>���i�I�v�V��������</summary>
        private string _partsOpNm = "";

        /// <summary>�^���ʕ��i�̗p�N��</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _modelPrtsAdptYm;

        /// <summary>�^���ʕ��i�p�~�N��</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _modelPrtsAblsYm;

        /// <summary>�^���ʕ��i�̗p�ԑ�ԍ�</summary>
        private Int32 _modelPrtsAdptFrameNo;

        /// <summary>�^���ʕ��i�p�~�ԑ�ԍ�</summary>
        private Int32 _modelPrtsAblsFrameNo;

        /// <summary>�^���O���[�h����</summary>
        private string _modelGradeNm = "";

        /// <summary>�{�f�B�[����</summary>
        private string _bodyName = "";

        /// <summary>�h�A��</summary>
        private Int32 _doorCount;

        /// <summary>�G���W���^������</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private string _engineModelNm = "";

        /// <summary>�r�C�ʖ���</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private string _engineDisplaceNm = "";

        /// <summary>E�敪����</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private string _eDivNm = "";

        /// <summary>�~�b�V��������</summary>
        private string _transmissionNm = "";

        /// <summary>�쓮��������</summary>
        /// <remarks>�V�K�ǉ�</remarks>
        private string _wheelDriveMethodNm = "";

        /// <summary>�V�t�g����</summary>
        private string _shiftNm = "";

        /// <summary>�쐬���t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _createDate;

        /// <summary>�X�V�N����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _updateDate;

        /// <summary>���i�ԍ�[���i�}�X�^]</summary>
        /// <remarks>�����i�}�X�^�擾�m�F�p</remarks>
        private string _goodsNoFromGoods = "";

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>���i���̃J�i</summary>
        private string _goodsNameKana = "";

        /// <summary>���i�|�������N</summary>
        /// <remarks>�w��</remarks>
        private string _goodsRateRank = "";

        /// <summary>���i�ԍ�[���i�}�X�^]</summary>
        /// <remarks>�����i�}�X�^�擾�m�F�p</remarks>
        private string _goodsNoFromPrice = "";

        /// <summary>���i�J�n��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _priceStartDate;

        /// <summary>�艿</summary>
        /// <remarks>0:�I�[�v�����i</remarks>
        private Double _listPrice;

        /// <summary>�I�[�v�����i�敪</summary>
        /// <remarks>0:�ʏ�^1:�I�[�v�����i</remarks>
        private Int32 _openPriceDiv;

        /// <summary>BL���i�R�[�h���́i�S�p�j</summary>
        private string _bLGoodsFullName = "";

        /// <summary>BL���i�R�[�h���́i���p�j</summary>
        private string _bLGoodsHalfName = "";

        /// <summary>�r�K�X�L��</summary>
        /// <remarks>���^��0</remarks>
        private string _exhaustGasSign = "";

        /// <summary>�V���[�Y�^��</summary>
        /// <remarks>���^��1</remarks>
        private string _seriesModel = "";

        /// <summary>�^���i�ޕʋL���j</summary>
        /// <remarks>���^��2</remarks>
        private string _categorySignModel = "";

        /// <summary>���i�}�X�^�a�k�R�[�h</summary>
        /// <remarks>���i�}�X�^����擾�����a�k�R�[�h</remarks>
        private Int32 _bLGoodsCodeFromGoods;


        /// public propaty name  :  CreateDateTime
        /// <summary>�쐬�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>�X�V�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
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

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUID�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>�X�V�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>�X�V�A�Z���u��ID1�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>�X�V�A�Z���u��ID2�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>�_���폜�敪�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_���폜�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  FreSrchPrtPropNo
        /// <summary>���R�������i�ŗL�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���R�������i�ŗL�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FreSrchPrtPropNo
        {
            get { return _freSrchPrtPropNo; }
            set { _freSrchPrtPropNo = value; }
        }

        /// public propaty name  :  MakerCode
        /// <summary>���[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>1�`899:�񋟕�, 900�`���[�U�[�o�^</value>
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
        /// <value>�Ԗ��R�[�h(BL��) 1�`899:�񋟕�, 900�`���[�U�[�o�^</value>
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
        /// <value>0�`899:�񋟕�,900�`հ�ް�o�^</value>
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

        /// public propaty name  :  FullModel
        /// <summary>�^���i�t���^�j�v���p�e�B</summary>
        /// <value>�t���^��(44���p)</value>
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

        /// public propaty name  :  TbsPartsCode
        /// <summary>�a�k���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �a�k���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TbsPartsCode
        {
            get { return _tbsPartsCode; }
            set { _tbsPartsCode = value; }
        }

        /// public propaty name  :  TbsPartsCdDerivedNo
        /// <summary>�a�k���i�R�[�h�}�ԃv���p�e�B</summary>
        /// <value>�����g�p���ځi���C�A�E�g�ɂ͓���Ă����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �a�k���i�R�[�h�}�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TbsPartsCdDerivedNo
        {
            get { return _tbsPartsCdDerivedNo; }
            set { _tbsPartsCdDerivedNo = value; }
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

        /// public propaty name  :  GoodsNoNoneHyphen
        /// <summary>�n�C�t�������i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n�C�t�������i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNoNoneHyphen
        {
            get { return _goodsNoNoneHyphen; }
            set { _goodsNoNoneHyphen = value; }
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

        /// public propaty name  :  ModelPrtsAdptYm
        /// <summary>�^���ʕ��i�̗p�N���v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���ʕ��i�̗p�N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ModelPrtsAdptYm
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
        public DateTime ModelPrtsAblsYm
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

        /// public propaty name  :  ModelGradeNm
        /// <summary>�^���O���[�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���O���[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ModelGradeNm
        {
            get { return _modelGradeNm; }
            set { _modelGradeNm = value; }
        }

        /// public propaty name  :  BodyName
        /// <summary>�{�f�B�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �{�f�B�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BodyName
        {
            get { return _bodyName; }
            set { _bodyName = value; }
        }

        /// public propaty name  :  DoorCount
        /// <summary>�h�A���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �h�A���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DoorCount
        {
            get { return _doorCount; }
            set { _doorCount = value; }
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

        /// public propaty name  :  EngineDisplaceNm
        /// <summary>�r�C�ʖ��̃v���p�e�B</summary>
        /// <value>�^���ɂ��ϓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �r�C�ʖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EngineDisplaceNm
        {
            get { return _engineDisplaceNm; }
            set { _engineDisplaceNm = value; }
        }

        /// public propaty name  :  EDivNm
        /// <summary>E�敪���̃v���p�e�B</summary>
        /// <value>�^���ɂ��ϓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   E�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EDivNm
        {
            get { return _eDivNm; }
            set { _eDivNm = value; }
        }

        /// public propaty name  :  TransmissionNm
        /// <summary>�~�b�V�������̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �~�b�V�������̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TransmissionNm
        {
            get { return _transmissionNm; }
            set { _transmissionNm = value; }
        }

        /// public propaty name  :  WheelDriveMethodNm
        /// <summary>�쓮�������̃v���p�e�B</summary>
        /// <value>�V�K�ǉ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쓮�������̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WheelDriveMethodNm
        {
            get { return _wheelDriveMethodNm; }
            set { _wheelDriveMethodNm = value; }
        }

        /// public propaty name  :  ShiftNm
        /// <summary>�V�t�g���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V�t�g���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ShiftNm
        {
            get { return _shiftNm; }
            set { _shiftNm = value; }
        }

        /// public propaty name  :  CreateDate
        /// <summary>�쐬���t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }

        /// public propaty name  :  UpdateDate
        /// <summary>�X�V�N�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }

        /// public propaty name  :  GoodsNoFromGoods
        /// <summary>���i�ԍ�[���i�}�X�^]�v���p�e�B</summary>
        /// <value>�����i�}�X�^�擾�m�F�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ԍ�[���i�}�X�^]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNoFromGoods
        {
            get { return _goodsNoFromGoods; }
            set { _goodsNoFromGoods = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>���i���̃v���p�e�B</summary>
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

        /// public propaty name  :  GoodsNameKana
        /// <summary>���i���̃J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̃J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNameKana
        {
            get { return _goodsNameKana; }
            set { _goodsNameKana = value; }
        }

        /// public propaty name  :  GoodsRateRank
        /// <summary>���i�|�������N�v���p�e�B</summary>
        /// <value>�w��</value>
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

        /// public propaty name  :  GoodsNoFromPrice
        /// <summary>���i�ԍ�[���i�}�X�^]�v���p�e�B</summary>
        /// <value>�����i�}�X�^�擾�m�F�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ԍ�[���i�}�X�^]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNoFromPrice
        {
            get { return _goodsNoFromPrice; }
            set { _goodsNoFromPrice = value; }
        }

        /// public propaty name  :  PriceStartDate
        /// <summary>���i�J�n���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�J�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime PriceStartDate
        {
            get { return _priceStartDate; }
            set { _priceStartDate = value; }
        }

        /// public propaty name  :  ListPrice
        /// <summary>�艿�v���p�e�B</summary>
        /// <value>0:�I�[�v�����i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ListPrice
        {
            get { return _listPrice; }
            set { _listPrice = value; }
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

        /// public propaty name  :  BLGoodsFullName
        /// <summary>BL���i�R�[�h���́i�S�p�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���́i�S�p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGoodsFullName
        {
            get { return _bLGoodsFullName; }
            set { _bLGoodsFullName = value; }
        }

        /// public propaty name  :  BLGoodsHalfName
        /// <summary>BL���i�R�[�h���́i���p�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���́i���p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGoodsHalfName
        {
            get { return _bLGoodsHalfName; }
            set { _bLGoodsHalfName = value; }
        }

        /// public propaty name  :  ExhaustGasSign
        /// <summary>�r�K�X�L���v���p�e�B</summary>
        /// <value>���^��0</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �r�K�X�L���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ExhaustGasSign
        {
            get { return _exhaustGasSign; }
            set { _exhaustGasSign = value; }
        }

        /// public propaty name  :  SeriesModel
        /// <summary>�V���[�Y�^���v���p�e�B</summary>
        /// <value>���^��1</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V���[�Y�^���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SeriesModel
        {
            get { return _seriesModel; }
            set { _seriesModel = value; }
        }

        /// public propaty name  :  CategorySignModel
        /// <summary>�^���i�ޕʋL���j�v���p�e�B</summary>
        /// <value>���^��2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���i�ޕʋL���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CategorySignModel
        {
            get { return _categorySignModel; }
            set { _categorySignModel = value; }
        }

        /// public propaty name  :  BLGoodsCodeFromGoods
        /// <summary>���i�}�X�^�a�k�R�[�h�v���p�e�B</summary>
        /// <value>�����i�}�X�^����擾�����a�k�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�}�X�^�a�k�R�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCodeFromGoods
        {
            get { return _bLGoodsCodeFromGoods; }
            set { _bLGoodsCodeFromGoods = value; }
        }

        /// <summary>
        /// ���R�������i���o���ʃ��[�N�R���X�g���N�^
        /// </summary>
        /// <returns>FreeSearchPartsSRetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FreeSearchPartsSRetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public FreeSearchPartsSRetWork()
        {
        }

    }


    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>FreeSearchPartsSRetWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   FreeSearchPartsSRetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class FreeSearchPartsSRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FreeSearchPartsSRetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize( System.IO.BinaryWriter writer, object graph )
        {
            // TODO:  FreeSearchPartsSRetWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if ( writer == null )
                throw new ArgumentNullException();

            if ( graph != null && !(graph is FreeSearchPartsSRetWork || graph is ArrayList || graph is FreeSearchPartsSRetWork[]) )
                throw new ArgumentException( string.Format( "graph��{0}�̃C���X�^���X�ł���܂���", typeof( FreeSearchPartsSRetWork ).FullName ) );

            if ( graph != null && graph is FreeSearchPartsSRetWork )
            {
                Type t = graph.GetType();
                if ( !CustomFormatterServices.NeedCustomSerialization( t ) )
                    throw new ArgumentException( string.Format( "graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName ) );
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.FreeSearchPartsSRetWork" );

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if ( graph is ArrayList )
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if ( graph is FreeSearchPartsSRetWork[] )
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((FreeSearchPartsSRetWork[])graph).Length;
            }
            else if ( graph is FreeSearchPartsSRetWork )
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�쐬����
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CreateDateTime
            //�X�V����
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //UpdateDateTime
            //��ƃR�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add( typeof( byte[] ) );  //FileHeaderGuid
            //�X�V�]�ƈ��R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //UpdEmployeeCode
            //�X�V�A�Z���u��ID1
            serInfo.MemberInfo.Add( typeof( string ) ); //UpdAssemblyId1
            //�X�V�A�Z���u��ID2
            serInfo.MemberInfo.Add( typeof( string ) ); //UpdAssemblyId2
            //�_���폜�敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //LogicalDeleteCode
            //���R�������i�ŗL�ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //FreSrchPrtPropNo
            //���[�J�[�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MakerCode
            //�Ԏ�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ModelCode
            //�Ԏ�T�u�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ModelSubCode
            //�^���i�t���^�j
            serInfo.MemberInfo.Add( typeof( string ) ); //FullModel
            //�a�k���i�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //TbsPartsCode
            //�a�k���i�R�[�h�}��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //TbsPartsCdDerivedNo
            //���i�ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //GoodsNo
            //�n�C�t�������i�ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //GoodsNoNoneHyphen
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //GoodsMakerCd
            //���iQTY
            serInfo.MemberInfo.Add( typeof( Double ) ); //PartsQty
            //���i�I�v�V��������
            serInfo.MemberInfo.Add( typeof( string ) ); //PartsOpNm
            //�^���ʕ��i�̗p�N��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ModelPrtsAdptYm
            //�^���ʕ��i�p�~�N��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ModelPrtsAblsYm
            //�^���ʕ��i�̗p�ԑ�ԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ModelPrtsAdptFrameNo
            //�^���ʕ��i�p�~�ԑ�ԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ModelPrtsAblsFrameNo
            //�^���O���[�h����
            serInfo.MemberInfo.Add( typeof( string ) ); //ModelGradeNm
            //�{�f�B�[����
            serInfo.MemberInfo.Add( typeof( string ) ); //BodyName
            //�h�A��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DoorCount
            //�G���W���^������
            serInfo.MemberInfo.Add( typeof( string ) ); //EngineModelNm
            //�r�C�ʖ���
            serInfo.MemberInfo.Add( typeof( string ) ); //EngineDisplaceNm
            //E�敪����
            serInfo.MemberInfo.Add( typeof( string ) ); //EDivNm
            //�~�b�V��������
            serInfo.MemberInfo.Add( typeof( string ) ); //TransmissionNm
            //�쓮��������
            serInfo.MemberInfo.Add( typeof( string ) ); //WheelDriveMethodNm
            //�V�t�g����
            serInfo.MemberInfo.Add( typeof( string ) ); //ShiftNm
            //�쐬���t
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CreateDate
            //�X�V�N����
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //UpdateDate
            //���i�ԍ�[���i�}�X�^]
            serInfo.MemberInfo.Add( typeof( string ) ); //GoodsNoFromGoods
            //���i����
            serInfo.MemberInfo.Add( typeof( string ) ); //GoodsName
            //���i���̃J�i
            serInfo.MemberInfo.Add( typeof( string ) ); //GoodsNameKana
            //���i�|�������N
            serInfo.MemberInfo.Add( typeof( string ) ); //GoodsRateRank
            //���i�ԍ�[���i�}�X�^]
            serInfo.MemberInfo.Add( typeof( string ) ); //GoodsNoFromPrice
            //���i�J�n��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //PriceStartDate
            //�艿
            serInfo.MemberInfo.Add( typeof( double ) ); //ListPrice
            //�I�[�v�����i�敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //OpenPriceDiv
            //BL���i�R�[�h���́i�S�p�j
            serInfo.MemberInfo.Add( typeof( string ) ); //BLGoodsFullName
            //BL���i�R�[�h���́i���p�j
            serInfo.MemberInfo.Add( typeof( string ) ); //BLGoodsHalfName
            //�r�K�X�L��
            serInfo.MemberInfo.Add( typeof( string ) ); //ExhaustGasSign
            //�V���[�Y�^��
            serInfo.MemberInfo.Add( typeof( string ) ); //SeriesModel
            //�^���i�ޕʋL���j
            serInfo.MemberInfo.Add( typeof( string ) ); //CategorySignModel
            //���i�}�X�^�a�k�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //BLGoodsCodeFromGoods

            serInfo.Serialize( writer, serInfo );
            if ( graph is FreeSearchPartsSRetWork )
            {
                FreeSearchPartsSRetWork temp = (FreeSearchPartsSRetWork)graph;

                SetFreeSearchPartsSRetWork( writer, temp );
            }
            else
            {
                ArrayList lst = null;
                if ( graph is FreeSearchPartsSRetWork[] )
                {
                    lst = new ArrayList();
                    lst.AddRange( (FreeSearchPartsSRetWork[])graph );
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach ( FreeSearchPartsSRetWork temp in lst )
                {
                    SetFreeSearchPartsSRetWork( writer, temp );
                }

            }


        }


        /// <summary>
        /// FreeSearchPartsSRetWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 49;

        /// <summary>
        ///  FreeSearchPartsSRetWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FreeSearchPartsSRetWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetFreeSearchPartsSRetWork( System.IO.BinaryWriter writer, FreeSearchPartsSRetWork temp )
        {
            //�쐬����
            writer.Write( (Int64)temp.CreateDateTime.Ticks );
            //�X�V����
            writer.Write( (Int64)temp.UpdateDateTime.Ticks );
            //��ƃR�[�h
            writer.Write( temp.EnterpriseCode );
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write( fileHeaderGuidArray.Length );
            writer.Write( temp.FileHeaderGuid.ToByteArray() );
            //�X�V�]�ƈ��R�[�h
            writer.Write( temp.UpdEmployeeCode );
            //�X�V�A�Z���u��ID1
            writer.Write( temp.UpdAssemblyId1 );
            //�X�V�A�Z���u��ID2
            writer.Write( temp.UpdAssemblyId2 );
            //�_���폜�敪
            writer.Write( temp.LogicalDeleteCode );
            //���R�������i�ŗL�ԍ�
            writer.Write( temp.FreSrchPrtPropNo );
            //���[�J�[�R�[�h
            writer.Write( temp.MakerCode );
            //�Ԏ�R�[�h
            writer.Write( temp.ModelCode );
            //�Ԏ�T�u�R�[�h
            writer.Write( temp.ModelSubCode );
            //�^���i�t���^�j
            writer.Write( temp.FullModel );
            //�a�k���i�R�[�h
            writer.Write( temp.TbsPartsCode );
            //�a�k���i�R�[�h�}��
            writer.Write( temp.TbsPartsCdDerivedNo );
            //���i�ԍ�
            writer.Write( temp.GoodsNo );
            //�n�C�t�������i�ԍ�
            writer.Write( temp.GoodsNoNoneHyphen );
            //���i���[�J�[�R�[�h
            writer.Write( temp.GoodsMakerCd );
            //���iQTY
            writer.Write( temp.PartsQty );
            //���i�I�v�V��������
            writer.Write( temp.PartsOpNm );
            //�^���ʕ��i�̗p�N��
            writer.Write( (Int64)temp.ModelPrtsAdptYm.Ticks );
            //�^���ʕ��i�p�~�N��
            writer.Write( (Int64)temp.ModelPrtsAblsYm.Ticks );
            //�^���ʕ��i�̗p�ԑ�ԍ�
            writer.Write( temp.ModelPrtsAdptFrameNo );
            //�^���ʕ��i�p�~�ԑ�ԍ�
            writer.Write( temp.ModelPrtsAblsFrameNo );
            //�^���O���[�h����
            writer.Write( temp.ModelGradeNm );
            //�{�f�B�[����
            writer.Write( temp.BodyName );
            //�h�A��
            writer.Write( temp.DoorCount );
            //�G���W���^������
            writer.Write( temp.EngineModelNm );
            //�r�C�ʖ���
            writer.Write( temp.EngineDisplaceNm );
            //E�敪����
            writer.Write( temp.EDivNm );
            //�~�b�V��������
            writer.Write( temp.TransmissionNm );
            //�쓮��������
            writer.Write( temp.WheelDriveMethodNm );
            //�V�t�g����
            writer.Write( temp.ShiftNm );
            //�쐬���t
            writer.Write( (Int64)temp.CreateDate.Ticks );
            //�X�V�N����
            writer.Write( (Int64)temp.UpdateDate.Ticks );
            //���i�ԍ�[���i�}�X�^]
            writer.Write( temp.GoodsNoFromGoods );
            //���i����
            writer.Write( temp.GoodsName );
            //���i���̃J�i
            writer.Write( temp.GoodsNameKana );
            //���i�|�������N
            writer.Write( temp.GoodsRateRank );
            //���i�ԍ�[���i�}�X�^]
            writer.Write( temp.GoodsNoFromPrice );
            //���i�J�n��
            writer.Write( (Int64)temp.PriceStartDate.Ticks );
            //�艿
            writer.Write( temp.ListPrice );
            //�I�[�v�����i�敪
            writer.Write( temp.OpenPriceDiv );
            //BL���i�R�[�h���́i�S�p�j
            writer.Write( temp.BLGoodsFullName );
            //BL���i�R�[�h���́i���p�j
            writer.Write( temp.BLGoodsHalfName );
            //�r�K�X�L��
            writer.Write( temp.ExhaustGasSign );
            //�V���[�Y�^��
            writer.Write( temp.SeriesModel );
            //�^���i�ޕʋL���j
            writer.Write( temp.CategorySignModel );
            //���i�}�X�^�a�k�R�[�h
            writer.Write( temp.BLGoodsCodeFromGoods );
        }

        /// <summary>
        ///  FreeSearchPartsSRetWork�C���X�^���X�擾
        /// </summary>
        /// <returns>FreeSearchPartsSRetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FreeSearchPartsSRetWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private FreeSearchPartsSRetWork GetFreeSearchPartsSRetWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            FreeSearchPartsSRetWork temp = new FreeSearchPartsSRetWork();

            //�쐬����
            temp.CreateDateTime = new DateTime( reader.ReadInt64() );
            //�X�V����
            temp.UpdateDateTime = new DateTime( reader.ReadInt64() );
            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes( lenOfFileHeaderGuidArray );
            temp.FileHeaderGuid = new Guid( fileHeaderGuidArray );
            //�X�V�]�ƈ��R�[�h
            temp.UpdEmployeeCode = reader.ReadString();
            //�X�V�A�Z���u��ID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //�X�V�A�Z���u��ID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //�_���폜�敪
            temp.LogicalDeleteCode = reader.ReadInt32();
            //���R�������i�ŗL�ԍ�
            temp.FreSrchPrtPropNo = reader.ReadString();
            //���[�J�[�R�[�h
            temp.MakerCode = reader.ReadInt32();
            //�Ԏ�R�[�h
            temp.ModelCode = reader.ReadInt32();
            //�Ԏ�T�u�R�[�h
            temp.ModelSubCode = reader.ReadInt32();
            //�^���i�t���^�j
            temp.FullModel = reader.ReadString();
            //�a�k���i�R�[�h
            temp.TbsPartsCode = reader.ReadInt32();
            //�a�k���i�R�[�h�}��
            temp.TbsPartsCdDerivedNo = reader.ReadInt32();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //�n�C�t�������i�ԍ�
            temp.GoodsNoNoneHyphen = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���iQTY
            temp.PartsQty = reader.ReadDouble();
            //���i�I�v�V��������
            temp.PartsOpNm = reader.ReadString();
            //�^���ʕ��i�̗p�N��
            temp.ModelPrtsAdptYm = new DateTime( reader.ReadInt64() );
            //�^���ʕ��i�p�~�N��
            temp.ModelPrtsAblsYm = new DateTime( reader.ReadInt64() );
            //�^���ʕ��i�̗p�ԑ�ԍ�
            temp.ModelPrtsAdptFrameNo = reader.ReadInt32();
            //�^���ʕ��i�p�~�ԑ�ԍ�
            temp.ModelPrtsAblsFrameNo = reader.ReadInt32();
            //�^���O���[�h����
            temp.ModelGradeNm = reader.ReadString();
            //�{�f�B�[����
            temp.BodyName = reader.ReadString();
            //�h�A��
            temp.DoorCount = reader.ReadInt32();
            //�G���W���^������
            temp.EngineModelNm = reader.ReadString();
            //�r�C�ʖ���
            temp.EngineDisplaceNm = reader.ReadString();
            //E�敪����
            temp.EDivNm = reader.ReadString();
            //�~�b�V��������
            temp.TransmissionNm = reader.ReadString();
            //�쓮��������
            temp.WheelDriveMethodNm = reader.ReadString();
            //�V�t�g����
            temp.ShiftNm = reader.ReadString();
            //�쐬���t
            temp.CreateDate = new DateTime( reader.ReadInt64() );
            //�X�V�N����
            temp.UpdateDate = new DateTime( reader.ReadInt64() );
            //���i�ԍ�[���i�}�X�^]
            temp.GoodsNoFromGoods = reader.ReadString();
            //���i����
            temp.GoodsName = reader.ReadString();
            //���i���̃J�i
            temp.GoodsNameKana = reader.ReadString();
            //���i�|�������N
            temp.GoodsRateRank = reader.ReadString();
            //���i�ԍ�[���i�}�X�^]
            temp.GoodsNoFromPrice = reader.ReadString();
            //���i�J�n��
            temp.PriceStartDate = new DateTime( reader.ReadInt64() );
            //�艿
            temp.ListPrice = reader.ReadDouble();
            //�I�[�v�����i�敪
            temp.OpenPriceDiv = reader.ReadInt32();
            //BL���i�R�[�h���́i�S�p�j
            temp.BLGoodsFullName = reader.ReadString();
            //BL���i�R�[�h���́i���p�j
            temp.BLGoodsHalfName = reader.ReadString();
            //�r�K�X�L��
            temp.ExhaustGasSign = reader.ReadString();
            //�V���[�Y�^��
            temp.SeriesModel = reader.ReadString();
            //�^���i�ޕʋL���j
            temp.CategorySignModel = reader.ReadString();
            //���i�}�X�^�a�k�R�[�h
            temp.BLGoodsCodeFromGoods = reader.ReadInt32();

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
        /// <returns>FreeSearchPartsSRetWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FreeSearchPartsSRetWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize( System.IO.BinaryReader reader )
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
            ArrayList lst = new ArrayList();
            for ( int cnt = 0; cnt < serInfo.Occurrence; ++cnt )
            {
                FreeSearchPartsSRetWork temp = GetFreeSearchPartsSRetWork( reader, serInfo );
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
                    retValue = (FreeSearchPartsSRetWork[])lst.ToArray( typeof( FreeSearchPartsSRetWork ) );
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   APStockAcPayHistWork
    /// <summary>
    ///                      �݌Ɏ󕥗����f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �݌Ɏ󕥗����f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2009/04/28  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/6/30  ����</br>
    /// <br>                 :   �c�c���C��</br>
    /// <br>                 :   BL���i�R�[�h���́i�S�p�j</br>
    /// <br>                 :   BLGoodsFullName �� BLGoodsFullNameRF</br>
    /// <br>Update Note      :   2008/6/30  ����</br>
    /// <br>                 :   �󕥌�����敪�̕⑫��</br>
    /// <br>                 :   �u42:�}�X�^�����e�v�ǉ�</br>
    /// <br>Update Note      :   2008/8/22  ����</br>
    /// <br>                 :   �󕥌��`�[�敪�̕⑫��</br>
    /// <br>                 :   �u13:�݌Ɏd���v�ǉ�</br>
    /// <br>Update Note      :   2008/10/09  ����</br>
    /// <br>                 :   �󕥌��`�[�敪�̕⑫��</br>
    /// <br>                 :   �u60:�g��,61:����,70:��[�v�ǉ�</br>
    /// <br>Update Note      :   2008/10/14  ����</br>
    /// <br>                 :   �󕥌��`�[�敪�̕⑫�ύX</br>
    /// <br>                 :   �u70:��[�v�ˁu70:��[����,70:��[�o�Ɂv</br>
    /// <br>Update Note      :   2008/10/30  ����</br>
    /// <br>                 :   ���L�[�ύX</br>
    /// <br>                 :   3,11,12,13,14 �� 3,11,12,13,14,24,26,32</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class APStockAcPayHistWork : IFileHeader
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

        /// <summary>���o�ד�</summary>
        private Int32 _ioGoodsDay;

        /// <summary>�v����t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _addUpADate;

        /// <summary>�󕥌��`�[�敪</summary>
        /// <remarks>10:�d��,11:���,12:��v��,13:�݌Ɏd��20:����,21:���v��,22:�ϑ�,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,42:�}�X�^�����e,50:�I��,60:�g��,61:����,70:��[����,71:��[�o��</remarks>
        private Int32 _acPaySlipCd;

        /// <summary>�󕥌��`�[�ԍ�</summary>
        /// <remarks>�u�󕥌��`�[�v�̓`�[�ԍ����i�[</remarks>
        private string _acPaySlipNum = "";

        /// <summary>�󕥌��s�ԍ�</summary>
        /// <remarks>�u�󕥌��`�[�v�̓`�[�s�ԍ����i�[</remarks>
        private Int32 _acPaySlipRowNo;

        /// <summary>�󕥗����쐬����</summary>
        private Int64 _acPayHistDateTime;

        /// <summary>�󕥌�����敪</summary>
        /// <remarks>10:�ʏ�`�[,11:�ԕi,12:�l��,20:�ԓ`,21:�폜,22:����
        /// 30:�݌ɐ�����,31:��������,32:���Ԓ���,33:�s�Ǖi,
        /// 34:���o,35:����,36:�ꊇ�o�^,40:�ߕs���X�V,90:���</remarks>
        private Int32 _acPayTransCd;

        /// <summary>���͋��_�R�[�h</summary>
        /// <remarks>���͂��s�������_����</remarks>
        private string _inputSectionCd = "";

        /// <summary>���͋��_�K�C�h����</summary>
        private string _inputSectionGuidNm = "";

        /// <summary>���͒S���҃R�[�h</summary>
        private string _inputAgenCd = "";

        /// <summary>���͒S���Җ���</summary>
        private string _inputAgenNm = "";

        /// <summary>�ړ����</summary>
        /// <remarks>0:�ړ��ΏۊO�A1:���o�׏�ԁA2:�ړ����A9:���׍�</remarks>
        private Int32 _moveStatus;

        /// <summary>�����`�[�ԍ�</summary>
        /// <remarks>���Ӑ�`�[�ԍ��A�d����`�[�ԍ�</remarks>
        private string _custSlipNo = "";

        /// <summary>���גʔ�</summary>
        private Int64 _slipDtlNum;

        /// <summary>�󕥔��l</summary>
        /// <remarks>�󕥂��������i�[</remarks>
        private string _acPayNote = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        /// <remarks>�񋟔͈͂̓v���_�N�g���Œ�`</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>���[�J�[����</summary>
        private string _makerName = "";

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL���i�R�[�h���́i�S�p�j</summary>
        private string _bLGoodsFullName = "";

        /// <summary>���_�R�[�h</summary>
        /// <remarks>�o�ׁA���ׂ��������鋒�_</remarks>
        private string _sectionCode = "";

        /// <summary>���_�K�C�h����</summary>
        private string _sectionGuideNm = "";

        /// <summary>�q�ɃR�[�h</summary>
        /// <remarks>�o�ׁA���ׂ���������q��</remarks>
        private string _warehouseCode = "";

        /// <summary>�q�ɖ���</summary>
        private string _warehouseName = "";

        /// <summary>�I��</summary>
        /// <remarks>�o�ׁA���ׂ���������I��</remarks>
        private string _shelfNo = "";

        /// <summary>�ړ������_�R�[�h</summary>
        /// <remarks>�ړ��i�o�ׁj�̏ꍇ�� �����@�@�ړ��i���ׁj�̏ꍇ�͑�����</remarks>
        private string _bfSectionCode = "";

        /// <summary>�ړ������_�K�C�h����</summary>
        /// <remarks>����</remarks>
        private string _bfSectionGuideNm = "";

        /// <summary>�ړ����q�ɃR�[�h</summary>
        /// <remarks>����</remarks>
        private string _bfEnterWarehCode = "";

        /// <summary>�ړ����q�ɖ���</summary>
        /// <remarks>����</remarks>
        private string _bfEnterWarehName = "";

        /// <summary>�ړ����I��</summary>
        /// <remarks>����</remarks>
        private string _bfShelfNo = "";

        /// <summary>�ړ��拒�_�R�[�h</summary>
        /// <remarks>�ړ��i�o�ׁj�̏ꍇ�� ������@�@�ړ��i���ׁj�̏ꍇ�͎����</remarks>
        private string _afSectionCode = "";

        /// <summary>�ړ��拒�_�K�C�h����</summary>
        /// <remarks>����</remarks>
        private string _afSectionGuideNm = "";

        /// <summary>�ړ���q�ɃR�[�h</summary>
        /// <remarks>����</remarks>
        private string _afEnterWarehCode = "";

        /// <summary>�ړ���q�ɖ���</summary>
        /// <remarks>����</remarks>
        private string _afEnterWarehName = "";

        /// <summary>�ړ���I��</summary>
        /// <remarks>����</remarks>
        private string _afShelfNo = "";

        /// <summary>���Ӑ�R�[�h</summary>
        /// <remarks>���㎞�̓��Ӑ�R�[�h���Z�b�g</remarks>
        private Int32 _customerCode;

        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = "";

        /// <summary>�d����R�[�h</summary>
        /// <remarks>�d�����̎d����R�[�h���Z�b�g</remarks>
        private Int32 _supplierCd;

        /// <summary>�d���旪��</summary>
        private string _supplierSnm = "";

        /// <summary>���א�</summary>
        /// <remarks>�d�����́A�݌Ɉړ��i���ׁj�A�݌ɒ����A�I�������ɃZ�b�g</remarks>
        private Double _arrivalCnt;

        /// <summary>�o�א�</summary>
        /// <remarks>������́A�݌Ɉړ��i�o�ׁj���ɃZ�b�g</remarks>
        private Double _shipmentCnt;

        /// <summary>�I�[�v�����i�敪</summary>
        /// <remarks>0:�ʏ�^1:�I�[�v�����i</remarks>
        private Int32 _openPriceDiv;

        /// <summary>�艿�i�Ŕ��C�����j</summary>
        /// <remarks>�Ŕ���</remarks>
        private Double _listPriceTaxExcFl;

        /// <summary>�d���P���i�Ŕ��C�����j</summary>
        /// <remarks>����̏ꍇ�����P��</remarks>
        private Double _stockUnitPriceFl;

        /// <summary>�d�����z</summary>
        /// <remarks>����̏ꍇ�������z</remarks>
        private Int64 _stockPrice;

        /// <summary>����P���i�Ŕ��C�����j</summary>
        private Double _salesUnPrcTaxExcFl;

        /// <summary>������z</summary>
        private Int64 _salesMoney;

        /// <summary>�d���݌ɐ�</summary>
        /// <remarks>���א�(���v��j�A�o�א�(���v��j���܂܂Ȃ��݌ɐ��i���Ѝ݌Ɂj</remarks>
        private Double _supplierStock;

        /// <summary>�󒍐�</summary>
        private Double _acpOdrCount;

        /// <summary>������</summary>
        private Double _salesOrderCount;

        /// <summary>�ړ����d���݌ɐ�</summary>
        /// <remarks>�݌Ɉړ���A���ړ��悪���ׂ���O�܂ł̊ԂɗL���l������B</remarks>
        private Double _movingSupliStock;

        /// <summary>�o�א��i���v��j</summary>
        /// <remarks>�ݏo�A�o�ׂƓ���</remarks>
        private Double _nonAddUpShipmCnt;

        /// <summary>���א��i���v��j</summary>
        /// <remarks>����</remarks>
        private Double _nonAddUpArrGdsCnt;

        /// <summary>�o�׉\��</summary>
        /// <remarks>�o�׉\�����d���݌ɐ��{���א�(���v��j�|�o�א��i���v��j�|�󒍐� �| �ړ����d���݌ɐ�</remarks>
        private Double _shipmentPosCnt;

        /// <summary>���݌ɐ���</summary>
        /// <remarks>���݌ɐ��ʁ��d���݌ɐ��{���א��i���v��j�|�o�א��i���v��j�|�ړ����d���݌ɐ�</remarks>
        private Double _presentStockCnt;


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

        /// public propaty name  :  IoGoodsDay
        /// <summary>���o�ד��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���o�ד��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 IoGoodsDay
        {
            get { return _ioGoodsDay; }
            set { _ioGoodsDay = value; }
        }

        /// public propaty name  :  AddUpADate
        /// <summary>�v����t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
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

        /// public propaty name  :  AcPaySlipCd
        /// <summary>�󕥌��`�[�敪�v���p�e�B</summary>
        /// <value>10:�d��,11:���,12:��v��,13:�݌Ɏd��20:����,21:���v��,22:�ϑ�,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,42:�}�X�^�����e,50:�I��,60:�g��,61:����,70:��[����,71:��[�o��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󕥌��`�[�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcPaySlipCd
        {
            get { return _acPaySlipCd; }
            set { _acPaySlipCd = value; }
        }

        /// public propaty name  :  AcPaySlipNum
        /// <summary>�󕥌��`�[�ԍ��v���p�e�B</summary>
        /// <value>�u�󕥌��`�[�v�̓`�[�ԍ����i�[</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󕥌��`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AcPaySlipNum
        {
            get { return _acPaySlipNum; }
            set { _acPaySlipNum = value; }
        }

        /// public propaty name  :  AcPaySlipRowNo
        /// <summary>�󕥌��s�ԍ��v���p�e�B</summary>
        /// <value>�u�󕥌��`�[�v�̓`�[�s�ԍ����i�[</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󕥌��s�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcPaySlipRowNo
        {
            get { return _acPaySlipRowNo; }
            set { _acPaySlipRowNo = value; }
        }

        /// public propaty name  :  AcPayHistDateTime
        /// <summary>�󕥗����쐬�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󕥗����쐬�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AcPayHistDateTime
        {
            get { return _acPayHistDateTime; }
            set { _acPayHistDateTime = value; }
        }

        /// public propaty name  :  AcPayTransCd
        /// <summary>�󕥌�����敪�v���p�e�B</summary>
        /// <value>10:�ʏ�`�[,11:�ԕi,12:�l��,20:�ԓ`,21:�폜,22:����
        /// 30:�݌ɐ�����,31:��������,32:���Ԓ���,33:�s�Ǖi,
        /// 34:���o,35:����,36:�ꊇ�o�^,40:�ߕs���X�V,90:���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󕥌�����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcPayTransCd
        {
            get { return _acPayTransCd; }
            set { _acPayTransCd = value; }
        }

        /// public propaty name  :  InputSectionCd
        /// <summary>���͋��_�R�[�h�v���p�e�B</summary>
        /// <value>���͂��s�������_����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͋��_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InputSectionCd
        {
            get { return _inputSectionCd; }
            set { _inputSectionCd = value; }
        }

        /// public propaty name  :  InputSectionGuidNm
        /// <summary>���͋��_�K�C�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͋��_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InputSectionGuidNm
        {
            get { return _inputSectionGuidNm; }
            set { _inputSectionGuidNm = value; }
        }

        /// public propaty name  :  InputAgenCd
        /// <summary>���͒S���҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͒S���҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InputAgenCd
        {
            get { return _inputAgenCd; }
            set { _inputAgenCd = value; }
        }

        /// public propaty name  :  InputAgenNm
        /// <summary>���͒S���Җ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͒S���Җ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InputAgenNm
        {
            get { return _inputAgenNm; }
            set { _inputAgenNm = value; }
        }

        /// public propaty name  :  MoveStatus
        /// <summary>�ړ���ԃv���p�e�B</summary>
        /// <value>0:�ړ��ΏۊO�A1:���o�׏�ԁA2:�ړ����A9:���׍�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ���ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MoveStatus
        {
            get { return _moveStatus; }
            set { _moveStatus = value; }
        }

        /// public propaty name  :  CustSlipNo
        /// <summary>�����`�[�ԍ��v���p�e�B</summary>
        /// <value>���Ӑ�`�[�ԍ��A�d����`�[�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustSlipNo
        {
            get { return _custSlipNo; }
            set { _custSlipNo = value; }
        }

        /// public propaty name  :  SlipDtlNum
        /// <summary>���גʔԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���גʔԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SlipDtlNum
        {
            get { return _slipDtlNum; }
            set { _slipDtlNum = value; }
        }

        /// public propaty name  :  AcPayNote
        /// <summary>�󕥔��l�v���p�e�B</summary>
        /// <value>�󕥂��������i�[</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󕥔��l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AcPayNote
        {
            get { return _acPayNote; }
            set { _acPayNote = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>�񋟔͈͂̓v���_�N�g���Œ�`</value>
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

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL���i�R�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>�o�ׁA���ׂ��������鋒�_</value>
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

        /// public propaty name  :  SectionGuideNm
        /// <summary>���_�K�C�h���̃v���p�e�B</summary>
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

        /// public propaty name  :  WarehouseCode
        /// <summary>�q�ɃR�[�h�v���p�e�B</summary>
        /// <value>�o�ׁA���ׂ���������q��</value>
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

        /// public propaty name  :  WarehouseName
        /// <summary>�q�ɖ��̃v���p�e�B</summary>
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

        /// public propaty name  :  ShelfNo
        /// <summary>�I�ԃv���p�e�B</summary>
        /// <value>�o�ׁA���ׂ���������I��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ShelfNo
        {
            get { return _shelfNo; }
            set { _shelfNo = value; }
        }

        /// public propaty name  :  BfSectionCode
        /// <summary>�ړ������_�R�[�h�v���p�e�B</summary>
        /// <value>�ړ��i�o�ׁj�̏ꍇ�� �����@�@�ړ��i���ׁj�̏ꍇ�͑�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ������_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BfSectionCode
        {
            get { return _bfSectionCode; }
            set { _bfSectionCode = value; }
        }

        /// public propaty name  :  BfSectionGuideNm
        /// <summary>�ړ������_�K�C�h���̃v���p�e�B</summary>
        /// <value>����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ������_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BfSectionGuideNm
        {
            get { return _bfSectionGuideNm; }
            set { _bfSectionGuideNm = value; }
        }

        /// public propaty name  :  BfEnterWarehCode
        /// <summary>�ړ����q�ɃR�[�h�v���p�e�B</summary>
        /// <value>����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BfEnterWarehCode
        {
            get { return _bfEnterWarehCode; }
            set { _bfEnterWarehCode = value; }
        }

        /// public propaty name  :  BfEnterWarehName
        /// <summary>�ړ����q�ɖ��̃v���p�e�B</summary>
        /// <value>����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����q�ɖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BfEnterWarehName
        {
            get { return _bfEnterWarehName; }
            set { _bfEnterWarehName = value; }
        }

        /// public propaty name  :  BfShelfNo
        /// <summary>�ړ����I�ԃv���p�e�B</summary>
        /// <value>����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����I�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BfShelfNo
        {
            get { return _bfShelfNo; }
            set { _bfShelfNo = value; }
        }

        /// public propaty name  :  AfSectionCode
        /// <summary>�ړ��拒�_�R�[�h�v���p�e�B</summary>
        /// <value>�ړ��i�o�ׁj�̏ꍇ�� ������@�@�ړ��i���ׁj�̏ꍇ�͎����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ��拒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AfSectionCode
        {
            get { return _afSectionCode; }
            set { _afSectionCode = value; }
        }

        /// public propaty name  :  AfSectionGuideNm
        /// <summary>�ړ��拒�_�K�C�h���̃v���p�e�B</summary>
        /// <value>����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ��拒�_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AfSectionGuideNm
        {
            get { return _afSectionGuideNm; }
            set { _afSectionGuideNm = value; }
        }

        /// public propaty name  :  AfEnterWarehCode
        /// <summary>�ړ���q�ɃR�[�h�v���p�e�B</summary>
        /// <value>����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ���q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AfEnterWarehCode
        {
            get { return _afEnterWarehCode; }
            set { _afEnterWarehCode = value; }
        }

        /// public propaty name  :  AfEnterWarehName
        /// <summary>�ړ���q�ɖ��̃v���p�e�B</summary>
        /// <value>����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ���q�ɖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AfEnterWarehName
        {
            get { return _afEnterWarehName; }
            set { _afEnterWarehName = value; }
        }

        /// public propaty name  :  AfShelfNo
        /// <summary>�ړ���I�ԃv���p�e�B</summary>
        /// <value>����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ���I�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AfShelfNo
        {
            get { return _afShelfNo; }
            set { _afShelfNo = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// <value>���㎞�̓��Ӑ�R�[�h���Z�b�g</value>
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
        /// <value>�d�����̎d����R�[�h���Z�b�g</value>
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

        /// public propaty name  :  ArrivalCnt
        /// <summary>���א��v���p�e�B</summary>
        /// <value>�d�����́A�݌Ɉړ��i���ׁj�A�݌ɒ����A�I�������ɃZ�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���א��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ArrivalCnt
        {
            get { return _arrivalCnt; }
            set { _arrivalCnt = value; }
        }

        /// public propaty name  :  ShipmentCnt
        /// <summary>�o�א��v���p�e�B</summary>
        /// <value>������́A�݌Ɉړ��i�o�ׁj���ɃZ�b�g</value>
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

        /// public propaty name  :  ListPriceTaxExcFl
        /// <summary>�艿�i�Ŕ��C�����j�v���p�e�B</summary>
        /// <value>�Ŕ���</value>
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

        /// public propaty name  :  StockUnitPriceFl
        /// <summary>�d���P���i�Ŕ��C�����j�v���p�e�B</summary>
        /// <value>����̏ꍇ�����P��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���P���i�Ŕ��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockUnitPriceFl
        {
            get { return _stockUnitPriceFl; }
            set { _stockUnitPriceFl = value; }
        }

        /// public propaty name  :  StockPrice
        /// <summary>�d�����z�v���p�e�B</summary>
        /// <value>����̏ꍇ�������z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockPrice
        {
            get { return _stockPrice; }
            set { _stockPrice = value; }
        }

        /// public propaty name  :  SalesUnPrcTaxExcFl
        /// <summary>����P���i�Ŕ��C�����j�v���p�e�B</summary>
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

        /// public propaty name  :  SalesMoney
        /// <summary>������z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoney
        {
            get { return _salesMoney; }
            set { _salesMoney = value; }
        }

        /// public propaty name  :  SupplierStock
        /// <summary>�d���݌ɐ��v���p�e�B</summary>
        /// <value>���א�(���v��j�A�o�א�(���v��j���܂܂Ȃ��݌ɐ��i���Ѝ݌Ɂj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���݌ɐ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SupplierStock
        {
            get { return _supplierStock; }
            set { _supplierStock = value; }
        }

        /// public propaty name  :  AcpOdrCount
        /// <summary>�󒍐��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍐��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AcpOdrCount
        {
            get { return _acpOdrCount; }
            set { _acpOdrCount = value; }
        }

        /// public propaty name  :  SalesOrderCount
        /// <summary>�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesOrderCount
        {
            get { return _salesOrderCount; }
            set { _salesOrderCount = value; }
        }

        /// public propaty name  :  MovingSupliStock
        /// <summary>�ړ����d���݌ɐ��v���p�e�B</summary>
        /// <value>�݌Ɉړ���A���ړ��悪���ׂ���O�܂ł̊ԂɗL���l������B</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����d���݌ɐ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MovingSupliStock
        {
            get { return _movingSupliStock; }
            set { _movingSupliStock = value; }
        }

        /// public propaty name  :  NonAddUpShipmCnt
        /// <summary>�o�א��i���v��j�v���p�e�B</summary>
        /// <value>�ݏo�A�o�ׂƓ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�א��i���v��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double NonAddUpShipmCnt
        {
            get { return _nonAddUpShipmCnt; }
            set { _nonAddUpShipmCnt = value; }
        }

        /// public propaty name  :  NonAddUpArrGdsCnt
        /// <summary>���א��i���v��j�v���p�e�B</summary>
        /// <value>����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���א��i���v��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double NonAddUpArrGdsCnt
        {
            get { return _nonAddUpArrGdsCnt; }
            set { _nonAddUpArrGdsCnt = value; }
        }

        /// public propaty name  :  ShipmentPosCnt
        /// <summary>�o�׉\���v���p�e�B</summary>
        /// <value>�o�׉\�����d���݌ɐ��{���א�(���v��j�|�o�א��i���v��j�|�󒍐� �| �ړ����d���݌ɐ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�׉\���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentPosCnt
        {
            get { return _shipmentPosCnt; }
            set { _shipmentPosCnt = value; }
        }

        /// public propaty name  :  PresentStockCnt
        /// <summary>���݌ɐ��ʃv���p�e�B</summary>
        /// <value>���݌ɐ��ʁ��d���݌ɐ��{���א��i���v��j�|�o�א��i���v��j�|�ړ����d���݌ɐ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���݌ɐ��ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double PresentStockCnt
        {
            get { return _presentStockCnt; }
            set { _presentStockCnt = value; }
        }


        /// <summary>
        /// �݌Ɏ󕥗����f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>APStockAcPayHistWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   APStockAcPayHistWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public APStockAcPayHistWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>APStockAcPayHistWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   APStockAcPayHistWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class APStockAcPayHistWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   APStockAcPayHistWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  APStockAcPayHistWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is APStockAcPayHistWork || graph is ArrayList || graph is APStockAcPayHistWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(APStockAcPayHistWork).FullName));

            if (graph != null && graph is APStockAcPayHistWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.APStockAcPayHistWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is APStockAcPayHistWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((APStockAcPayHistWork[])graph).Length;
            }
            else if (graph is APStockAcPayHistWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //�X�V�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //�X�V�A�Z���u��ID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //�X�V�A�Z���u��ID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //�_���폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //���o�ד�
            serInfo.MemberInfo.Add(typeof(Int32)); //IoGoodsDay
            //�v����t
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpADate
            //�󕥌��`�[�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AcPaySlipCd
            //�󕥌��`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //AcPaySlipNum
            //�󕥌��s�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //AcPaySlipRowNo
            //�󕥗����쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //AcPayHistDateTime
            //�󕥌�����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AcPayTransCd
            //���͋��_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InputSectionCd
            //���͋��_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //InputSectionGuidNm
            //���͒S���҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InputAgenCd
            //���͒S���Җ���
            serInfo.MemberInfo.Add(typeof(string)); //InputAgenNm
            //�ړ����
            serInfo.MemberInfo.Add(typeof(Int32)); //MoveStatus
            //�����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //CustSlipNo
            //���גʔ�
            serInfo.MemberInfo.Add(typeof(Int64)); //SlipDtlNum
            //�󕥔��l
            serInfo.MemberInfo.Add(typeof(string)); //AcPayNote
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL���i�R�[�h���́i�S�p�j
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsFullName
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //�q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //�q�ɖ���
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //�I��
            serInfo.MemberInfo.Add(typeof(string)); //ShelfNo
            //�ړ������_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //BfSectionCode
            //�ړ������_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //BfSectionGuideNm
            //�ړ����q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //BfEnterWarehCode
            //�ړ����q�ɖ���
            serInfo.MemberInfo.Add(typeof(string)); //BfEnterWarehName
            //�ړ����I��
            serInfo.MemberInfo.Add(typeof(string)); //BfShelfNo
            //�ړ��拒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AfSectionCode
            //�ړ��拒�_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //AfSectionGuideNm
            //�ړ���q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AfEnterWarehCode
            //�ړ���q�ɖ���
            serInfo.MemberInfo.Add(typeof(string)); //AfEnterWarehName
            //�ړ���I��
            serInfo.MemberInfo.Add(typeof(string)); //AfShelfNo
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //���Ӑ旪��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�d���旪��
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //���א�
            serInfo.MemberInfo.Add(typeof(Double)); //ArrivalCnt
            //�o�א�
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt
            //�I�[�v�����i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //OpenPriceDiv
            //�艿�i�Ŕ��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxExcFl
            //�d���P���i�Ŕ��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitPriceFl
            //�d�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPrice
            //����P���i�Ŕ��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnPrcTaxExcFl
            //������z
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney
            //�d���݌ɐ�
            serInfo.MemberInfo.Add(typeof(Double)); //SupplierStock
            //�󒍐�
            serInfo.MemberInfo.Add(typeof(Double)); //AcpOdrCount
            //������
            serInfo.MemberInfo.Add(typeof(Double)); //SalesOrderCount
            //�ړ����d���݌ɐ�
            serInfo.MemberInfo.Add(typeof(Double)); //MovingSupliStock
            //�o�א��i���v��j
            serInfo.MemberInfo.Add(typeof(Double)); //NonAddUpShipmCnt
            //���א��i���v��j
            serInfo.MemberInfo.Add(typeof(Double)); //NonAddUpArrGdsCnt
            //�o�׉\��
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentPosCnt
            //���݌ɐ���
            serInfo.MemberInfo.Add(typeof(Double)); //PresentStockCnt


            serInfo.Serialize(writer, serInfo);
            if (graph is APStockAcPayHistWork)
            {
                APStockAcPayHistWork temp = (APStockAcPayHistWork)graph;

                SetAPStockAcPayHistWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is APStockAcPayHistWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((APStockAcPayHistWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (APStockAcPayHistWork temp in lst)
                {
                    SetAPStockAcPayHistWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// APStockAcPayHistWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 64;

        /// <summary>
        ///  APStockAcPayHistWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   APStockAcPayHistWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetAPStockAcPayHistWork(System.IO.BinaryWriter writer, APStockAcPayHistWork temp)
        {
            //�쐬����
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //�X�V�]�ƈ��R�[�h
            writer.Write(temp.UpdEmployeeCode);
            //�X�V�A�Z���u��ID1
            writer.Write(temp.UpdAssemblyId1);
            //�X�V�A�Z���u��ID2
            writer.Write(temp.UpdAssemblyId2);
            //�_���폜�敪
            writer.Write(temp.LogicalDeleteCode);
            //���o�ד�
            writer.Write(temp.IoGoodsDay);
            //�v����t
            writer.Write((Int64)temp.AddUpADate.Ticks);
            //�󕥌��`�[�敪
            writer.Write(temp.AcPaySlipCd);
            //�󕥌��`�[�ԍ�
            writer.Write(temp.AcPaySlipNum);
            //�󕥌��s�ԍ�
            writer.Write(temp.AcPaySlipRowNo);
            //�󕥗����쐬����
            writer.Write(temp.AcPayHistDateTime);
            //�󕥌�����敪
            writer.Write(temp.AcPayTransCd);
            //���͋��_�R�[�h
            writer.Write(temp.InputSectionCd);
            //���͋��_�K�C�h����
            writer.Write(temp.InputSectionGuidNm);
            //���͒S���҃R�[�h
            writer.Write(temp.InputAgenCd);
            //���͒S���Җ���
            writer.Write(temp.InputAgenNm);
            //�ړ����
            writer.Write(temp.MoveStatus);
            //�����`�[�ԍ�
            writer.Write(temp.CustSlipNo);
            //���גʔ�
            writer.Write(temp.SlipDtlNum);
            //�󕥔��l
            writer.Write(temp.AcPayNote);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���[�J�[����
            writer.Write(temp.MakerName);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //���i����
            writer.Write(temp.GoodsName);
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //BL���i�R�[�h���́i�S�p�j
            writer.Write(temp.BLGoodsFullName);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideNm);
            //�q�ɃR�[�h
            writer.Write(temp.WarehouseCode);
            //�q�ɖ���
            writer.Write(temp.WarehouseName);
            //�I��
            writer.Write(temp.ShelfNo);
            //�ړ������_�R�[�h
            writer.Write(temp.BfSectionCode);
            //�ړ������_�K�C�h����
            writer.Write(temp.BfSectionGuideNm);
            //�ړ����q�ɃR�[�h
            writer.Write(temp.BfEnterWarehCode);
            //�ړ����q�ɖ���
            writer.Write(temp.BfEnterWarehName);
            //�ړ����I��
            writer.Write(temp.BfShelfNo);
            //�ړ��拒�_�R�[�h
            writer.Write(temp.AfSectionCode);
            //�ړ��拒�_�K�C�h����
            writer.Write(temp.AfSectionGuideNm);
            //�ړ���q�ɃR�[�h
            writer.Write(temp.AfEnterWarehCode);
            //�ړ���q�ɖ���
            writer.Write(temp.AfEnterWarehName);
            //�ړ���I��
            writer.Write(temp.AfShelfNo);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //���Ӑ旪��
            writer.Write(temp.CustomerSnm);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�d���旪��
            writer.Write(temp.SupplierSnm);
            //���א�
            writer.Write(temp.ArrivalCnt);
            //�o�א�
            writer.Write(temp.ShipmentCnt);
            //�I�[�v�����i�敪
            writer.Write(temp.OpenPriceDiv);
            //�艿�i�Ŕ��C�����j
            writer.Write(temp.ListPriceTaxExcFl);
            //�d���P���i�Ŕ��C�����j
            writer.Write(temp.StockUnitPriceFl);
            //�d�����z
            writer.Write(temp.StockPrice);
            //����P���i�Ŕ��C�����j
            writer.Write(temp.SalesUnPrcTaxExcFl);
            //������z
            writer.Write(temp.SalesMoney);
            //�d���݌ɐ�
            writer.Write(temp.SupplierStock);
            //�󒍐�
            writer.Write(temp.AcpOdrCount);
            //������
            writer.Write(temp.SalesOrderCount);
            //�ړ����d���݌ɐ�
            writer.Write(temp.MovingSupliStock);
            //�o�א��i���v��j
            writer.Write(temp.NonAddUpShipmCnt);
            //���א��i���v��j
            writer.Write(temp.NonAddUpArrGdsCnt);
            //�o�׉\��
            writer.Write(temp.ShipmentPosCnt);
            //���݌ɐ���
            writer.Write(temp.PresentStockCnt);

        }

        /// <summary>
        ///  APStockAcPayHistWork�C���X�^���X�擾
        /// </summary>
        /// <returns>APStockAcPayHistWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   APStockAcPayHistWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private APStockAcPayHistWork GetAPStockAcPayHistWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            APStockAcPayHistWork temp = new APStockAcPayHistWork();

            //�쐬����
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //�X�V�]�ƈ��R�[�h
            temp.UpdEmployeeCode = reader.ReadString();
            //�X�V�A�Z���u��ID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //�X�V�A�Z���u��ID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //�_���폜�敪
            temp.LogicalDeleteCode = reader.ReadInt32();
            //���o�ד�
            temp.IoGoodsDay = reader.ReadInt32();
            //�v����t
            temp.AddUpADate = new DateTime(reader.ReadInt64());
            //�󕥌��`�[�敪
            temp.AcPaySlipCd = reader.ReadInt32();
            //�󕥌��`�[�ԍ�
            temp.AcPaySlipNum = reader.ReadString();
            //�󕥌��s�ԍ�
            temp.AcPaySlipRowNo = reader.ReadInt32();
            //�󕥗����쐬����
            temp.AcPayHistDateTime = reader.ReadInt64();
            //�󕥌�����敪
            temp.AcPayTransCd = reader.ReadInt32();
            //���͋��_�R�[�h
            temp.InputSectionCd = reader.ReadString();
            //���͋��_�K�C�h����
            temp.InputSectionGuidNm = reader.ReadString();
            //���͒S���҃R�[�h
            temp.InputAgenCd = reader.ReadString();
            //���͒S���Җ���
            temp.InputAgenNm = reader.ReadString();
            //�ړ����
            temp.MoveStatus = reader.ReadInt32();
            //�����`�[�ԍ�
            temp.CustSlipNo = reader.ReadString();
            //���גʔ�
            temp.SlipDtlNum = reader.ReadInt64();
            //�󕥔��l
            temp.AcPayNote = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���[�J�[����
            temp.MakerName = reader.ReadString();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //���i����
            temp.GoodsName = reader.ReadString();
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //BL���i�R�[�h���́i�S�p�j
            temp.BLGoodsFullName = reader.ReadString();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideNm = reader.ReadString();
            //�q�ɃR�[�h
            temp.WarehouseCode = reader.ReadString();
            //�q�ɖ���
            temp.WarehouseName = reader.ReadString();
            //�I��
            temp.ShelfNo = reader.ReadString();
            //�ړ������_�R�[�h
            temp.BfSectionCode = reader.ReadString();
            //�ړ������_�K�C�h����
            temp.BfSectionGuideNm = reader.ReadString();
            //�ړ����q�ɃR�[�h
            temp.BfEnterWarehCode = reader.ReadString();
            //�ړ����q�ɖ���
            temp.BfEnterWarehName = reader.ReadString();
            //�ړ����I��
            temp.BfShelfNo = reader.ReadString();
            //�ړ��拒�_�R�[�h
            temp.AfSectionCode = reader.ReadString();
            //�ړ��拒�_�K�C�h����
            temp.AfSectionGuideNm = reader.ReadString();
            //�ړ���q�ɃR�[�h
            temp.AfEnterWarehCode = reader.ReadString();
            //�ړ���q�ɖ���
            temp.AfEnterWarehName = reader.ReadString();
            //�ړ���I��
            temp.AfShelfNo = reader.ReadString();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //���Ӑ旪��
            temp.CustomerSnm = reader.ReadString();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�d���旪��
            temp.SupplierSnm = reader.ReadString();
            //���א�
            temp.ArrivalCnt = reader.ReadDouble();
            //�o�א�
            temp.ShipmentCnt = reader.ReadDouble();
            //�I�[�v�����i�敪
            temp.OpenPriceDiv = reader.ReadInt32();
            //�艿�i�Ŕ��C�����j
            temp.ListPriceTaxExcFl = reader.ReadDouble();
            //�d���P���i�Ŕ��C�����j
            temp.StockUnitPriceFl = reader.ReadDouble();
            //�d�����z
            temp.StockPrice = reader.ReadInt64();
            //����P���i�Ŕ��C�����j
            temp.SalesUnPrcTaxExcFl = reader.ReadDouble();
            //������z
            temp.SalesMoney = reader.ReadInt64();
            //�d���݌ɐ�
            temp.SupplierStock = reader.ReadDouble();
            //�󒍐�
            temp.AcpOdrCount = reader.ReadDouble();
            //������
            temp.SalesOrderCount = reader.ReadDouble();
            //�ړ����d���݌ɐ�
            temp.MovingSupliStock = reader.ReadDouble();
            //�o�א��i���v��j
            temp.NonAddUpShipmCnt = reader.ReadDouble();
            //���א��i���v��j
            temp.NonAddUpArrGdsCnt = reader.ReadDouble();
            //�o�׉\��
            temp.ShipmentPosCnt = reader.ReadDouble();
            //���݌ɐ���
            temp.PresentStockCnt = reader.ReadDouble();


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
        ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
        /// </summary>
        /// <returns>APStockAcPayHistWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   APStockAcPayHistWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                APStockAcPayHistWork temp = GetAPStockAcPayHistWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (APStockAcPayHistWork[])lst.ToArray(typeof(APStockAcPayHistWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}

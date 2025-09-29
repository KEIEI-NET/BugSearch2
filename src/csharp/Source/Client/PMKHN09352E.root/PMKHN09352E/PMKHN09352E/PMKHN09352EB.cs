//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y
// �v���O��������   �F���Ӑ�ꊇ�C��
// �v���O�����T�v   �F���Ӑ�̕ύX���ꊇ�ōs��
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30414 �E �K�j
// �C����    2008/11/27     �C�����e�F�V�K�쐬
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/04/07     �C�����e�FMantis�y13030�z�̎����o�͋敪�̒ǉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30434 �H��
// �C����    2010/01/29     �C�����e�FMantis�y14950�z�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30434 �H��
// �C����    2010/02/24     �C�����e�FMantis�y15033�z�`�[����敪�~5��ǉ�
// ---------------------------------------------------------------------//

using System;
using System.Collections;

using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CustomerCustomerChangeResult
    /// <summary>
    ///                      ���Ӑ�ꊇ�C���N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���Ӑ�ꊇ�C���N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class CustomerCustomerChangeResult
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

        /// <summary>���Ӑ�R�[�h</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private Int32 _customerCode;

        /// <summary>���Ӑ�T�u�R�[�h</summary>
        private string _customerSubCode = "";

        /// <summary>����</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _name = "";

        /// <summary>����2</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _name2 = "";

        /// <summary>�h��</summary>
        private string _honorificTitle = "";

        /// <summary>�J�i</summary>
        private string _kana = "";

        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = "";

        /// <summary>�����R�[�h</summary>
        /// <remarks>0:�ڋq����1��2,1:�ڋq����1,2:�ڋq����2,3:��������</remarks>
        private Int32 _outputNameCode;

        /// <summary>��������</summary>
        private string _outputName = "";

        /// <summary>�l�E�@�l�敪</summary>
        /// <remarks>0:�l,1:�@�l,2:����@�l,3:�Ǝ�,4:�Ј�</remarks>
        private Int32 _corporateDivCode;

        /// <summary>���Ӑ摮���敪</summary>
        /// <remarks>0:���������,8:�Г������,9:��������</remarks>
        private Int32 _customerAttributeDiv;

        /// <summary>�E��R�[�h</summary>
        private Int32 _jobTypeCode;

        /// <summary>�E�햼��</summary>
        private string _jobTypeName = "";

        /// <summary>�Ǝ�R�[�h</summary>
        private Int32 _businessTypeCode;

        /// <summary>�Ǝ햼��</summary>
        private string _businessTypeName = "";

        /// <summary>�̔��G���A�R�[�h</summary>
        private Int32 _salesAreaCode;

        /// <summary>�̔��G���A����</summary>
        private string _salesAreaName = "";

        /// <summary>�X�֔ԍ�</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _postNo = "";

        /// <summary>�Z��1�i�s���{���s��S�E�����E���j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _address1 = "";

        /// <summary>�Z��3�i�Ԓn�j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _address3 = "";

        /// <summary>�Z��4�i�A�p�[�g���́j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _address4 = "";

        /// <summary>�d�b�ԍ��i����j</summary>
        /// <remarks>�n�C�t�����܂߂�16���̔ԍ�</remarks>
        private string _homeTelNo = "";

        /// <summary>�d�b�ԍ��i�Ζ���j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _officeTelNo = "";

        /// <summary>�d�b�ԍ��i�g�сj</summary>
        private string _portableTelNo = "";

        /// <summary>FAX�ԍ��i����j</summary>
        private string _homeFaxNo = "";

        /// <summary>FAX�ԍ��i�Ζ���j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _officeFaxNo = "";

        /// <summary>�d�b�ԍ��i���̑��j</summary>
        private string _othersTelNo = "";

        /// <summary>��A����敪</summary>
        /// <remarks>0:����,1:�Ζ���,2:�g��,3:����FAX,4:�Ζ���FAX���</remarks>
        private Int32 _mainContactCode;

        /// <summary>�d�b�ԍ��i�����p��4���j</summary>
        private string _searchTelNo = "";

        /// <summary>�Ǘ����_�R�[�h</summary>
        private string _mngSectionCode = "";

        /// <summary>�Ǘ����_����</summary>
        private string _mngSectionName = "";

        /// <summary>���͋��_�R�[�h</summary>
        private string _inpSectionCode = "";

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

        /// <summary>�������o�͋敪�R�[�h</summary>
        /// <remarks>0:���������s����,1:���Ȃ�</remarks>
        private Int32 _billOutputCode;

        /// <summary>�������o�͋敪����</summary>
        private string _billOutputName = "";

        /// <summary>����</summary>
        /// <remarks>DD</remarks>
        private Int32 _totalDay;

        /// <summary>�W�����敪�R�[�h</summary>
        /// <remarks>0:����,1:����,2:���X��</remarks>
        private Int32 _collectMoneyCode;

        /// <summary>�W�����敪����</summary>
        /// <remarks>����,����,���X��</remarks>
        private string _collectMoneyName = "";

        /// <summary>�W����</summary>
        /// <remarks>DD</remarks>
        private Int32 _collectMoneyDay;

        /// <summary>�������</summary>
        /// <remarks>10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�</remarks>
        private Int32 _collectCond;

        /// <summary>����T�C�g</summary>
        /// <remarks>��`�T�C�g�@180��</remarks>
        private Int32 _collectSight;

        /// <summary>������R�[�h</summary>
        /// <remarks>�����擾�Ӑ�B�[����̏ꍇ�̎g�p�\����</remarks>
        private Int32 _claimCode;

        /// <summary>�����於��</summary>
        private string _claimName = "";

        /// <summary>�����於��2</summary>
        private string _claimName2 = "";

        /// <summary>�����旪��</summary>
        private string _claimSnm = "";

        /// <summary>������~��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _transStopDate;

        /// <summary>DM�o�͋敪</summary>
        /// <remarks>0:�o�͂���,1:�o�͂��Ȃ�</remarks>
        private Int32 _dmOutCode;

        /// <summary>DM�o�͋敪����</summary>
        /// <remarks>�S�p�ŊǗ�</remarks>
        private string _dmOutName = "";

        /// <summary>�呗�M�惁�[���A�h���X�敪</summary>
        /// <remarks>0:���[���A�h���X1,1:���[���A�h���X2</remarks>
        private Int32 _mainSendMailAddrCd;

        /// <summary>���[���A�h���X��ʃR�[�h1</summary>
        /// <remarks>0:����,1:���,2:�g�ђ[��,3:�{�l�ȊO,99:���̑�</remarks>
        private Int32 _mailAddrKindCode1;

        /// <summary>���[���A�h���X��ʖ���1</summary>
        private string _mailAddrKindName1 = "";

        /// <summary>���[���A�h���X1</summary>
        private string _mailAddress1 = "";

        /// <summary>���[�����M�敪�R�[�h1</summary>
        /// <remarks>0:�񑗐M,1:���M</remarks>
        private Int32 _mailSendCode1;

        /// <summary>���[�����M�敪����1</summary>
        private string _mailSendName1 = "";

        /// <summary>���[���A�h���X��ʃR�[�h2</summary>
        /// <remarks>0:����,1:���,2:�g�ђ[��,3:�{�l�ȊO,99:���̑�</remarks>
        private Int32 _mailAddrKindCode2;

        /// <summary>���[���A�h���X��ʖ���2</summary>
        private string _mailAddrKindName2 = "";

        /// <summary>���[���A�h���X2</summary>
        private string _mailAddress2 = "";

        /// <summary>���[�����M�敪�R�[�h2</summary>
        /// <remarks>0:�񑗐M,1:���M</remarks>
        private Int32 _mailSendCode2;

        /// <summary>���[�����M�敪����2</summary>
        private string _mailSendName2 = "";

        /// <summary>�ڋq�S���]�ƈ��R�[�h</summary>
        /// <remarks>�����^</remarks>
        private string _customerAgentCd = "";

        /// <summary>�ڋq�S���]�ƈ�����</summary>
        private string _customerAgentNm = "";

        /// <summary>�W���S���]�ƈ��R�[�h</summary>
        private string _billCollecterCd = "";

        /// <summary>���ڋq�S���]�ƈ��R�[�h</summary>
        private string _oldCustomerAgentCd = "";

        /// <summary>���ڋq�S���]�ƈ�����</summary>
        private string _oldCustomerAgentNm = "";

        /// <summary>�ڋq�S���ύX��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _custAgentChgDate;

        /// <summary>�Ɣ̐�敪</summary>
        /// <remarks>0:�Ɣ̐�ȊO,1:�Ɣ̐�,2:�[����</remarks>
        private Int32 _acceptWholeSale;

        /// <summary>�^�M�Ǘ��敪</summary>
        private Int32 _creditMngCode;

        /// <summary>���������敪</summary>
        /// <remarks>PM(0:���Ȃ�,1:����) G/D( 0:���Ȃ�,1:����(������),2:����(�[�i��)�j</remarks>
        private Int32 _depoDelCode;

        /// <summary>���|�敪</summary>
        /// <remarks>0:���|�Ȃ�,1:���|</remarks>
        private Int32 _accRecDivCd;

        /// <summary>����`�[�ԍ��Ǘ��敪</summary>
        /// <remarks>0:���Ȃ��@1:����</remarks>
        private Int32 _custSlipNoMngCd;

        /// <summary>�����敪</summary>
        /// <remarks>0:�����A1:���̑��iPM�͗D�ǁj�@</remarks>
        private Int32 _pureCode;

        /// <summary>���Ӑ����œ]�ŕ����Q�Ƌ敪</summary>
        /// <remarks>0:�ŗ��ݒ�}�X�^���Q�Ɓ@1:���Ӑ�}�X�^���Q��</remarks>
        private Int32 _custCTaXLayRefCd;

        /// <summary>����œ]�ŕ���</summary>
        /// <remarks>0:�`�[�P��1:���גP��2:�����e3:�����q�@9:��ې�</remarks>
        private Int32 _consTaxLayMethod;

        /// <summary>���z�\�����@�敪</summary>
        /// <remarks>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</remarks>
        private Int32 _totalAmountDispWayCd;

        /// <summary>���z�\�����@�Q�Ƌ敪</summary>
        /// <remarks>0:�S�̐ݒ�Q�� 1:���Ӑ�Q��</remarks>
        private Int32 _totalAmntDspWayRef;

        /// <summary>��s����1</summary>
        private string _accountNoInfo1 = "";

        /// <summary>��s����2</summary>
        private string _accountNoInfo2 = "";

        /// <summary>��s����3</summary>
        private string _accountNoInfo3 = "";

        /// <summary>����P���[�������R�[�h</summary>
        /// <remarks>0�̏ꍇ�� �W���ݒ�Ƃ���B</remarks>
        private Int32 _salesUnPrcFrcProcCd;

        /// <summary>������z�[�������R�[�h</summary>
        /// <remarks>0�̏ꍇ�� �W���ݒ�Ƃ���B</remarks>
        private Int32 _salesMoneyFrcProcCd;

        /// <summary>�������Œ[�������R�[�h</summary>
        /// <remarks>0�̏ꍇ�� �W���ݒ�Ƃ���B</remarks>
        private Int32 _salesCnsTaxFrcProcCd;

        /// <summary>���Ӑ�`�[�ԍ��敪</summary>
        /// <remarks>0:�g�p���Ȃ�,1:�A��,2:����,3:����</remarks>
        private Int32 _customerSlipNoDiv;

        /// <summary>���񊨒�J�n��</summary>
        /// <remarks>01�`31�܂Łi�ȗ��\�j</remarks>
        private Int32 _nTimeCalcStDate;

        /// <summary>���Ӑ�S����</summary>
        /// <remarks>���Ӑ�i�d����j�̖₢���킹��Ј���</remarks>
        private string _customerAgent = "";

        /// <summary>�������_�R�[�h</summary>
        /// <remarks>�������s�����_</remarks>
        private string _claimSectionCode = "";

        /// <summary>�������_����</summary>
        /// <remarks>���_�K�C�h����</remarks>
        private string _claimSectionName = "";

        /// <summary>���q�Ǘ��敪</summary>
        /// <remarks>0:���Ȃ��A1:�o�^(�m�F)�A2:�o�^(����) 3:�o�^��</remarks>
        private Int32 _carMngDivCd;

        /// <summary>�i�Ԉ󎚋敪(������)</summary>
        /// <remarks>0:���i�}�X�^�A1:�L�A2:��</remarks>
        private Int32 _billPartsNoPrtCd;

        /// <summary>�i�Ԉ󎚋敪(�[�i���j</summary>
        /// <remarks>0:���i�}�X�^�A1:�L�A2:��</remarks>
        private Int32 _deliPartsNoPrtCd;

        /// <summary>�`�[�敪�����l</summary>
        private Int32 _defSalesSlipCd;

        /// <summary>�H�����o���[�g�����N</summary>
        private Int32 _lavorRateRank;

        /// <summary>�`�[�^�C�g���p�^�[��</summary>
        /// <remarks>0000:���ݒ�A0100:��{�^�C�g���A0200�E�E</remarks>
        private Int32 _slipTtlPrn;

        /// <summary>������s�R�[�h</summary>
        private Int32 _depoBankCode;

        /// <summary>������s����</summary>
        private string _depoBankName = "";

        /// <summary>���Ӑ�D��q�ɃR�[�h</summary>
        private string _custWarehouseCd;

        /// <summary>���Ӑ�D��q�ɖ���</summary>
        private string _custWarehouseName = "";

        /// <summary>QR�R�[�h���</summary>
        private Int32 _qrcodePrtCd;

        /// <summary>�[�i���h��</summary>
        /// <remarks>�[�i���p�̌h��</remarks>
        private string _deliHonorificTtl = "";

        /// <summary>�������h��</summary>
        /// <remarks>�������p�̌h��</remarks>
        private string _billHonorificTtl = "";

        /// <summary>���Ϗ��h��</summary>
        /// <remarks>���Ϗ��p�̌h��</remarks>
        private string _estmHonorificTtl = "";

        /// <summary>�̎����h��</summary>
        /// <remarks>�̎����p�̌h��</remarks>
        private string _rectHonorificTtl = "";

        /// <summary>�[�i���h�̈󎚋敪</summary>
        /// <remarks>0:���Ӑ�}�X�^ 1:�S�̍��ڐݒ�Q�� 2:���</remarks>
        private Int32 _deliHonorTtlPrtDiv;

        /// <summary>�������h�̈󎚋敪</summary>
        /// <remarks>0:���Ӑ�}�X�^ 1:�S�̍��ڐݒ�Q�� 2:���</remarks>
        private Int32 _billHonorTtlPrtDiv;

        /// <summary>���Ϗ��h�̈󎚋敪</summary>
        /// <remarks>0:���Ӑ�}�X�^ 1:�S�̍��ڐݒ�Q�� 2:���</remarks>
        private Int32 _estmHonorTtlPrtDiv;

        /// <summary>�̎����h�̈󎚋敪</summary>
        /// <remarks>0:���Ӑ�}�X�^ 1:�S�̍��ڐݒ�Q�� 2:���</remarks>
        private Int32 _rectHonorTtlPrtDiv;

        /// <summary>���l1</summary>
        private string _note1 = "";

        /// <summary>���l2</summary>
        private string _note2 = "";

        /// <summary>���l3</summary>
        private string _note3 = "";

        /// <summary>���l4</summary>
        private string _note4 = "";

        /// <summary>���l5</summary>
        private string _note5 = "";

        /// <summary>���l6</summary>
        private string _note6 = "";

        /// <summary>���l7</summary>
        private string _note7 = "";

        /// <summary>���l8</summary>
        private string _note8 = "";

        /// <summary>���l9</summary>
        private string _note9 = "";

        /// <summary>���l10</summary>
        private string _note10 = "";

        /// <summary>�^�M�z[�ϓ����]</summary>
        /// <remarks>�f�b�h���C��</remarks>
        private Int64 _creditMoney;

        /// <summary>�x���^�M�z[�ϓ����]</summary>
        /// <remarks>�x���\���p</remarks>
        private Int64 _warningCreditMoney;

        /// <summary>���ݔ��|�c��[�ϓ����]</summary>
        /// <remarks>�����f�[�^�A����f�[�^�i���|�j��o�^����ꍇ�Ƀ��A���ɍX�V</remarks>
        private Int64 _prsntAccRecBalance;

        /// <summary>�����敪[�|��]</summary>
        /// <remarks>0:�����A1:�D��</remarks>
        private Int32 _rateGPureCode;

        /// <summary>���i���[�J�[�R�[�h[�|��]</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���Ӑ�|���O���[�v�R�[�h[�|��]</summary>
        private Int32 _custRateGrpCode;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /// <summary>���͋��_����</summary>
        private string _inpSectionName = "";

        /// <summary>�������o�͋敪����</summary>
        /// <remarks>���������s����,���Ȃ�</remarks>
        private string _billOutPutCodeNm = "";

        /// <summary>�W���S���]�ƈ�����</summary>
        private string _billCollecterNm = "";

        // ADD 2009/04/07 ------>>>
        /// <summary>�̎����o�͋敪�R�[�h</summary>
        /// <remarks>0:����,1:���Ȃ�</remarks>
        private Int32 _receiptOutputCode;
        // ADD 2009/04/07 ------<<<

        // ADD 2010/02/24 MANTIS�Ή�[15033]�F�`�[����敪�~5��ǉ� ---------->>>>>
        /// <summary>�[�i���o�́i����`�[���s�敪�j</summary>
        /// <remarks>0:�W�� 1:���g�p 2:�g�p</remarks>
        private int _salesSlipPrtDiv;

        /// <summary>�󒍓`�[�o�́i�󒍓`�[���s�敪�j</summary>
        /// <remarks>0:�W�� 1:���g�p 2:�g�p</remarks>
        private int _acpOdrrSlipPrtDiv;

        /// <summary>�ݏo�`�[�o�́i�o�ד`�[���s�敪�j</summary>
        /// <remarks>0:�W�� 1:���g�p 2:�g�p</remarks>
        private int _shipmSlipPrtDiv;

        /// <summary>���ϓ`�[�o�́i���ϓ`�[���s�敪�j</summary>
        /// <remarks>0:�W�� 1:���g�p 2:�g�p</remarks>
        private int _estimatePrtDiv;

        /// <summary>UOE�`�[�o�́iUOE�`�[���s�敪�j</summary>
        /// <remarks>0:�W�� 1:���g�p 2:�g�p</remarks>
        private int _uoeSlipPrtDiv;
        // ADD 2010/02/24 MANTIS�Ή�[15033]�F�`�[����敪�~5��ǉ� ----------<<<<<

        // ADD 2010/01/29 MANTIS�Ή�[14950]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ---------->>>>>
        /// <summary>���v�������o�͋敪</summary>
        /// <remarks>0:�W�� 1:�g�p 2:���g�p</remarks>
        private int _totalBillOutputDiv;

        /// <summary>���א������o�͋敪</summary>
        /// <remarks>0:�W�� 1:�g�p 2:���g�p</remarks>
        private int _detailBillOutputCode;

        /// <summary>�`�[���v�������o�͋敪</summary>
        /// <remarks>0:�W�� 1:�g�p 2:���g�p</remarks>
        private int _slipTtlBillOutputDiv;
        // ADD 2010/01/29 MANTIS�Ή�[14950]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ----------<<<<<

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

        /// public propaty name  :  CreateDateTimeJpFormal
        /// <summary>�쐬���� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeJpInFormal
        /// <summary>�쐬���� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdFormal
        /// <summary>�쐬���� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdInFormal
        /// <summary>�쐬���� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
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

        /// public propaty name  :  UpdateDateTimeJpFormal
        /// <summary>�X�V���� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeJpInFormal
        /// <summary>�X�V���� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdFormal
        /// <summary>�X�V���� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdInFormal
        /// <summary>�X�V���� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
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

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
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

        /// public propaty name  :  CustomerSubCode
        /// <summary>���Ӑ�T�u�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�T�u�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerSubCode
        {
            get { return _customerSubCode; }
            set { _customerSubCode = value; }
        }

        /// public propaty name  :  Name
        /// <summary>���̃v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// public propaty name  :  Name2
        /// <summary>����2�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Name2
        {
            get { return _name2; }
            set { _name2 = value; }
        }

        /// public propaty name  :  HonorificTitle
        /// <summary>�h�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �h�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HonorificTitle
        {
            get { return _honorificTitle; }
            set { _honorificTitle = value; }
        }

        /// public propaty name  :  Kana
        /// <summary>�J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Kana
        {
            get { return _kana; }
            set { _kana = value; }
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

        /// public propaty name  :  OutputNameCode
        /// <summary>�����R�[�h�v���p�e�B</summary>
        /// <value>0:�ڋq����1��2,1:�ڋq����1,2:�ڋq����2,3:��������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OutputNameCode
        {
            get { return _outputNameCode; }
            set { _outputNameCode = value; }
        }

        /// public propaty name  :  OutputName
        /// <summary>�������̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OutputName
        {
            get { return _outputName; }
            set { _outputName = value; }
        }

        /// public propaty name  :  CorporateDivCode
        /// <summary>�l�E�@�l�敪�v���p�e�B</summary>
        /// <value>0:�l,1:�@�l,2:����@�l,3:�Ǝ�,4:�Ј�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l�E�@�l�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CorporateDivCode
        {
            get { return _corporateDivCode; }
            set { _corporateDivCode = value; }
        }

        /// public propaty name  :  CustomerAttributeDiv
        /// <summary>���Ӑ摮���敪�v���p�e�B</summary>
        /// <value>0:���������,8:�Г������,9:��������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ摮���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerAttributeDiv
        {
            get { return _customerAttributeDiv; }
            set { _customerAttributeDiv = value; }
        }

        /// public propaty name  :  JobTypeCode
        /// <summary>�E��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �E��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 JobTypeCode
        {
            get { return _jobTypeCode; }
            set { _jobTypeCode = value; }
        }

        /// public propaty name  :  JobTypeName
        /// <summary>�E�햼�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �E�햼�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string JobTypeName
        {
            get { return _jobTypeName; }
            set { _jobTypeName = value; }
        }

        /// public propaty name  :  BusinessTypeCode
        /// <summary>�Ǝ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǝ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BusinessTypeCode
        {
            get { return _businessTypeCode; }
            set { _businessTypeCode = value; }
        }

        /// public propaty name  :  BusinessTypeName
        /// <summary>�Ǝ햼�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǝ햼�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BusinessTypeName
        {
            get { return _businessTypeName; }
            set { _businessTypeName = value; }
        }

        /// public propaty name  :  SalesAreaCode
        /// <summary>�̔��G���A�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��G���A�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesAreaCode
        {
            get { return _salesAreaCode; }
            set { _salesAreaCode = value; }
        }

        /// public propaty name  :  SalesAreaName
        /// <summary>�̔��G���A���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��G���A���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesAreaName
        {
            get { return _salesAreaName; }
            set { _salesAreaName = value; }
        }

        /// public propaty name  :  PostNo
        /// <summary>�X�֔ԍ��v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�֔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PostNo
        {
            get { return _postNo; }
            set { _postNo = value; }
        }

        /// public propaty name  :  Address1
        /// <summary>�Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Address1
        {
            get { return _address1; }
            set { _address1 = value; }
        }

        /// public propaty name  :  Address3
        /// <summary>�Z��3�i�Ԓn�j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��3�i�Ԓn�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Address3
        {
            get { return _address3; }
            set { _address3 = value; }
        }

        /// public propaty name  :  Address4
        /// <summary>�Z��4�i�A�p�[�g���́j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��4�i�A�p�[�g���́j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Address4
        {
            get { return _address4; }
            set { _address4 = value; }
        }

        /// public propaty name  :  HomeTelNo
        /// <summary>�d�b�ԍ��i����j�v���p�e�B</summary>
        /// <value>�n�C�t�����܂߂�16���̔ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�b�ԍ��i����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HomeTelNo
        {
            get { return _homeTelNo; }
            set { _homeTelNo = value; }
        }

        /// public propaty name  :  OfficeTelNo
        /// <summary>�d�b�ԍ��i�Ζ���j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�b�ԍ��i�Ζ���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OfficeTelNo
        {
            get { return _officeTelNo; }
            set { _officeTelNo = value; }
        }

        /// public propaty name  :  PortableTelNo
        /// <summary>�d�b�ԍ��i�g�сj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�b�ԍ��i�g�сj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PortableTelNo
        {
            get { return _portableTelNo; }
            set { _portableTelNo = value; }
        }

        /// public propaty name  :  HomeFaxNo
        /// <summary>FAX�ԍ��i����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   FAX�ԍ��i����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HomeFaxNo
        {
            get { return _homeFaxNo; }
            set { _homeFaxNo = value; }
        }

        /// public propaty name  :  OfficeFaxNo
        /// <summary>FAX�ԍ��i�Ζ���j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   FAX�ԍ��i�Ζ���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OfficeFaxNo
        {
            get { return _officeFaxNo; }
            set { _officeFaxNo = value; }
        }

        /// public propaty name  :  OthersTelNo
        /// <summary>�d�b�ԍ��i���̑��j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�b�ԍ��i���̑��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OthersTelNo
        {
            get { return _othersTelNo; }
            set { _othersTelNo = value; }
        }

        /// public propaty name  :  MainContactCode
        /// <summary>��A����敪�v���p�e�B</summary>
        /// <value>0:����,1:�Ζ���,2:�g��,3:����FAX,4:�Ζ���FAX���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��A����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MainContactCode
        {
            get { return _mainContactCode; }
            set { _mainContactCode = value; }
        }

        /// public propaty name  :  SearchTelNo
        /// <summary>�d�b�ԍ��i�����p��4���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�b�ԍ��i�����p��4���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchTelNo
        {
            get { return _searchTelNo; }
            set { _searchTelNo = value; }
        }

        /// public propaty name  :  MngSectionCode
        /// <summary>�Ǘ����_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǘ����_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MngSectionCode
        {
            get { return _mngSectionCode; }
            set { _mngSectionCode = value; }
        }

        /// public propaty name  :  MngSectionName
        /// <summary>�Ǘ����_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǘ����_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MngSectionName
        {
            get { return _mngSectionName; }
            set { _mngSectionName = value; }
        }

        /// public propaty name  :  InpSectionCode
        /// <summary>���͋��_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͋��_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InpSectionCode
        {
            get { return _inpSectionCode; }
            set { _inpSectionCode = value; }
        }

        /// public propaty name  :  CustAnalysCode1
        /// <summary>���Ӑ敪�̓R�[�h1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ敪�̓R�[�h1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustAnalysCode1
        {
            get { return _custAnalysCode1; }
            set { _custAnalysCode1 = value; }
        }

        /// public propaty name  :  CustAnalysCode2
        /// <summary>���Ӑ敪�̓R�[�h2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ敪�̓R�[�h2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustAnalysCode2
        {
            get { return _custAnalysCode2; }
            set { _custAnalysCode2 = value; }
        }

        /// public propaty name  :  CustAnalysCode3
        /// <summary>���Ӑ敪�̓R�[�h3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ敪�̓R�[�h3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustAnalysCode3
        {
            get { return _custAnalysCode3; }
            set { _custAnalysCode3 = value; }
        }

        /// public propaty name  :  CustAnalysCode4
        /// <summary>���Ӑ敪�̓R�[�h4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ敪�̓R�[�h4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustAnalysCode4
        {
            get { return _custAnalysCode4; }
            set { _custAnalysCode4 = value; }
        }

        /// public propaty name  :  CustAnalysCode5
        /// <summary>���Ӑ敪�̓R�[�h5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ敪�̓R�[�h5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustAnalysCode5
        {
            get { return _custAnalysCode5; }
            set { _custAnalysCode5 = value; }
        }

        /// public propaty name  :  CustAnalysCode6
        /// <summary>���Ӑ敪�̓R�[�h6�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ敪�̓R�[�h6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustAnalysCode6
        {
            get { return _custAnalysCode6; }
            set { _custAnalysCode6 = value; }
        }

        /// public propaty name  :  BillOutputCode
        /// <summary>�������o�͋敪�R�[�h�v���p�e�B</summary>
        /// <value>0:���������s����,1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������o�͋敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BillOutputCode
        {
            get { return _billOutputCode; }
            set { _billOutputCode = value; }
        }

        /// public propaty name  :  BillOutputName
        /// <summary>�������o�͋敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������o�͋敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BillOutputName
        {
            get { return _billOutputName; }
            set { _billOutputName = value; }
        }

        /// public propaty name  :  TotalDay
        /// <summary>�����v���p�e�B</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalDay
        {
            get { return _totalDay; }
            set { _totalDay = value; }
        }

        /// public propaty name  :  CollectMoneyCode
        /// <summary>�W�����敪�R�[�h�v���p�e�B</summary>
        /// <value>0:����,1:����,2:���X��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CollectMoneyCode
        {
            get { return _collectMoneyCode; }
            set { _collectMoneyCode = value; }
        }

        /// public propaty name  :  CollectMoneyName
        /// <summary>�W�����敪���̃v���p�e�B</summary>
        /// <value>����,����,���X��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CollectMoneyName
        {
            get { return _collectMoneyName; }
            set { _collectMoneyName = value; }
        }

        /// public propaty name  :  CollectMoneyDay
        /// <summary>�W�����v���p�e�B</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CollectMoneyDay
        {
            get { return _collectMoneyDay; }
            set { _collectMoneyDay = value; }
        }

        /// public propaty name  :  CollectCond
        /// <summary>��������v���p�e�B</summary>
        /// <value>10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CollectCond
        {
            get { return _collectCond; }
            set { _collectCond = value; }
        }

        /// public propaty name  :  CollectSight
        /// <summary>����T�C�g�v���p�e�B</summary>
        /// <value>��`�T�C�g�@180��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����T�C�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CollectSight
        {
            get { return _collectSight; }
            set { _collectSight = value; }
        }

        /// public propaty name  :  ClaimCode
        /// <summary>������R�[�h�v���p�e�B</summary>
        /// <value>�����擾�Ӑ�B�[����̏ꍇ�̎g�p�\����</value>
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

        /// public propaty name  :  ClaimName
        /// <summary>�����於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ClaimName
        {
            get { return _claimName; }
            set { _claimName = value; }
        }

        /// public propaty name  :  ClaimName2
        /// <summary>�����於��2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����於��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ClaimName2
        {
            get { return _claimName2; }
            set { _claimName2 = value; }
        }

        /// public propaty name  :  ClaimSnm
        /// <summary>�����旪���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����旪���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ClaimSnm
        {
            get { return _claimSnm; }
            set { _claimSnm = value; }
        }

        /// public propaty name  :  TransStopDate
        /// <summary>������~���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������~���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime TransStopDate
        {
            get { return _transStopDate; }
            set { _transStopDate = value; }
        }

        /// public propaty name  :  TransStopDateJpFormal
        /// <summary>������~�� �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������~�� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TransStopDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _transStopDate); }
            set { }
        }

        /// public propaty name  :  TransStopDateJpInFormal
        /// <summary>������~�� �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������~�� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TransStopDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _transStopDate); }
            set { }
        }

        /// public propaty name  :  TransStopDateAdFormal
        /// <summary>������~�� ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������~�� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TransStopDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _transStopDate); }
            set { }
        }

        /// public propaty name  :  TransStopDateAdInFormal
        /// <summary>������~�� ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������~�� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TransStopDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _transStopDate); }
            set { }
        }

        /// public propaty name  :  DmOutCode
        /// <summary>DM�o�͋敪�v���p�e�B</summary>
        /// <value>0:�o�͂���,1:�o�͂��Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   DM�o�͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DmOutCode
        {
            get { return _dmOutCode; }
            set { _dmOutCode = value; }
        }

        /// public propaty name  :  DmOutName
        /// <summary>DM�o�͋敪���̃v���p�e�B</summary>
        /// <value>�S�p�ŊǗ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   DM�o�͋敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DmOutName
        {
            get { return _dmOutName; }
            set { _dmOutName = value; }
        }

        /// public propaty name  :  MainSendMailAddrCd
        /// <summary>�呗�M�惁�[���A�h���X�敪�v���p�e�B</summary>
        /// <value>0:���[���A�h���X1,1:���[���A�h���X2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �呗�M�惁�[���A�h���X�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MainSendMailAddrCd
        {
            get { return _mainSendMailAddrCd; }
            set { _mainSendMailAddrCd = value; }
        }

        /// public propaty name  :  MailAddrKindCode1
        /// <summary>���[���A�h���X��ʃR�[�h1�v���p�e�B</summary>
        /// <value>0:����,1:���,2:�g�ђ[��,3:�{�l�ȊO,99:���̑�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[���A�h���X��ʃR�[�h1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MailAddrKindCode1
        {
            get { return _mailAddrKindCode1; }
            set { _mailAddrKindCode1 = value; }
        }

        /// public propaty name  :  MailAddrKindName1
        /// <summary>���[���A�h���X��ʖ���1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[���A�h���X��ʖ���1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MailAddrKindName1
        {
            get { return _mailAddrKindName1; }
            set { _mailAddrKindName1 = value; }
        }

        /// public propaty name  :  MailAddress1
        /// <summary>���[���A�h���X1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[���A�h���X1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MailAddress1
        {
            get { return _mailAddress1; }
            set { _mailAddress1 = value; }
        }

        /// public propaty name  :  MailSendCode1
        /// <summary>���[�����M�敪�R�[�h1�v���p�e�B</summary>
        /// <value>0:�񑗐M,1:���M</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�����M�敪�R�[�h1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MailSendCode1
        {
            get { return _mailSendCode1; }
            set { _mailSendCode1 = value; }
        }

        /// public propaty name  :  MailSendName1
        /// <summary>���[�����M�敪����1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�����M�敪����1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MailSendName1
        {
            get { return _mailSendName1; }
            set { _mailSendName1 = value; }
        }

        /// public propaty name  :  MailAddrKindCode2
        /// <summary>���[���A�h���X��ʃR�[�h2�v���p�e�B</summary>
        /// <value>0:����,1:���,2:�g�ђ[��,3:�{�l�ȊO,99:���̑�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[���A�h���X��ʃR�[�h2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MailAddrKindCode2
        {
            get { return _mailAddrKindCode2; }
            set { _mailAddrKindCode2 = value; }
        }

        /// public propaty name  :  MailAddrKindName2
        /// <summary>���[���A�h���X��ʖ���2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[���A�h���X��ʖ���2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MailAddrKindName2
        {
            get { return _mailAddrKindName2; }
            set { _mailAddrKindName2 = value; }
        }

        /// public propaty name  :  MailAddress2
        /// <summary>���[���A�h���X2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[���A�h���X2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MailAddress2
        {
            get { return _mailAddress2; }
            set { _mailAddress2 = value; }
        }

        /// public propaty name  :  MailSendCode2
        /// <summary>���[�����M�敪�R�[�h2�v���p�e�B</summary>
        /// <value>0:�񑗐M,1:���M</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�����M�敪�R�[�h2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MailSendCode2
        {
            get { return _mailSendCode2; }
            set { _mailSendCode2 = value; }
        }

        /// public propaty name  :  MailSendName2
        /// <summary>���[�����M�敪����2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�����M�敪����2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MailSendName2
        {
            get { return _mailSendName2; }
            set { _mailSendName2 = value; }
        }

        /// public propaty name  :  CustomerAgentCd
        /// <summary>�ڋq�S���]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�����^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڋq�S���]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerAgentCd
        {
            get { return _customerAgentCd; }
            set { _customerAgentCd = value; }
        }

        /// public propaty name  :  CustomerAgentNm
        /// <summary>�ڋq�S���]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڋq�S���]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerAgentNm
        {
            get { return _customerAgentNm; }
            set { _customerAgentNm = value; }
        }

        /// public propaty name  :  BillCollecterCd
        /// <summary>�W���S���]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W���S���]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BillCollecterCd
        {
            get { return _billCollecterCd; }
            set { _billCollecterCd = value; }
        }

        /// public propaty name  :  OldCustomerAgentCd
        /// <summary>���ڋq�S���]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ڋq�S���]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OldCustomerAgentCd
        {
            get { return _oldCustomerAgentCd; }
            set { _oldCustomerAgentCd = value; }
        }

        /// public propaty name  :  OldCustomerAgentNm
        /// <summary>���ڋq�S���]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ڋq�S���]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OldCustomerAgentNm
        {
            get { return _oldCustomerAgentNm; }
            set { _oldCustomerAgentNm = value; }
        }

        /// public propaty name  :  CustAgentChgDate
        /// <summary>�ڋq�S���ύX���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڋq�S���ύX���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CustAgentChgDate
        {
            get { return _custAgentChgDate; }
            set { _custAgentChgDate = value; }
        }

        /// public propaty name  :  CustAgentChgDateJpFormal
        /// <summary>�ڋq�S���ύX�� �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڋq�S���ύX�� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustAgentChgDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _custAgentChgDate); }
            set { }
        }

        /// public propaty name  :  CustAgentChgDateJpInFormal
        /// <summary>�ڋq�S���ύX�� �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڋq�S���ύX�� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustAgentChgDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _custAgentChgDate); }
            set { }
        }

        /// public propaty name  :  CustAgentChgDateAdFormal
        /// <summary>�ڋq�S���ύX�� ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڋq�S���ύX�� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustAgentChgDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _custAgentChgDate); }
            set { }
        }

        /// public propaty name  :  CustAgentChgDateAdInFormal
        /// <summary>�ڋq�S���ύX�� ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڋq�S���ύX�� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustAgentChgDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _custAgentChgDate); }
            set { }
        }

        /// public propaty name  :  AcceptWholeSale
        /// <summary>�Ɣ̐�敪�v���p�e�B</summary>
        /// <value>0:�Ɣ̐�ȊO,1:�Ɣ̐�,2:�[����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ɣ̐�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcceptWholeSale
        {
            get { return _acceptWholeSale; }
            set { _acceptWholeSale = value; }
        }

        /// public propaty name  :  CreditMngCode
        /// <summary>�^�M�Ǘ��敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�M�Ǘ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CreditMngCode
        {
            get { return _creditMngCode; }
            set { _creditMngCode = value; }
        }

        /// public propaty name  :  DepoDelCode
        /// <summary>���������敪�v���p�e�B</summary>
        /// <value>PM(0:���Ȃ�,1:����) G/D( 0:���Ȃ�,1:����(������),2:����(�[�i��)�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepoDelCode
        {
            get { return _depoDelCode; }
            set { _depoDelCode = value; }
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

        /// public propaty name  :  CustSlipNoMngCd
        /// <summary>����`�[�ԍ��Ǘ��敪�v���p�e�B</summary>
        /// <value>0:���Ȃ��@1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�ԍ��Ǘ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustSlipNoMngCd
        {
            get { return _custSlipNoMngCd; }
            set { _custSlipNoMngCd = value; }
        }

        /// public propaty name  :  PureCode
        /// <summary>�����敪�v���p�e�B</summary>
        /// <value>0:�����A1:���̑��iPM�͗D�ǁj�@</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PureCode
        {
            get { return _pureCode; }
            set { _pureCode = value; }
        }

        /// public propaty name  :  CustCTaXLayRefCd
        /// <summary>���Ӑ����œ]�ŕ����Q�Ƌ敪�v���p�e�B</summary>
        /// <value>0:�ŗ��ݒ�}�X�^���Q�Ɓ@1:���Ӑ�}�X�^���Q��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ����œ]�ŕ����Q�Ƌ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustCTaXLayRefCd
        {
            get { return _custCTaXLayRefCd; }
            set { _custCTaXLayRefCd = value; }
        }

        /// public propaty name  :  ConsTaxLayMethod
        /// <summary>����œ]�ŕ����v���p�e�B</summary>
        /// <value>0:�`�[�P��1:���גP��2:�����e3:�����q�@9:��ې�</value>
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

        /// public propaty name  :  TotalAmntDspWayRef
        /// <summary>���z�\�����@�Q�Ƌ敪�v���p�e�B</summary>
        /// <value>0:�S�̐ݒ�Q�� 1:���Ӑ�Q��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���z�\�����@�Q�Ƌ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalAmntDspWayRef
        {
            get { return _totalAmntDspWayRef; }
            set { _totalAmntDspWayRef = value; }
        }

        /// public propaty name  :  AccountNoInfo1
        /// <summary>��s����1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��s����1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AccountNoInfo1
        {
            get { return _accountNoInfo1; }
            set { _accountNoInfo1 = value; }
        }

        /// public propaty name  :  AccountNoInfo2
        /// <summary>��s����2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��s����2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AccountNoInfo2
        {
            get { return _accountNoInfo2; }
            set { _accountNoInfo2 = value; }
        }

        /// public propaty name  :  AccountNoInfo3
        /// <summary>��s����3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��s����3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AccountNoInfo3
        {
            get { return _accountNoInfo3; }
            set { _accountNoInfo3 = value; }
        }

        /// public propaty name  :  SalesUnPrcFrcProcCd
        /// <summary>����P���[�������R�[�h�v���p�e�B</summary>
        /// <value>0�̏ꍇ�� �W���ݒ�Ƃ���B</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����P���[�������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesUnPrcFrcProcCd
        {
            get { return _salesUnPrcFrcProcCd; }
            set { _salesUnPrcFrcProcCd = value; }
        }

        /// public propaty name  :  SalesMoneyFrcProcCd
        /// <summary>������z�[�������R�[�h�v���p�e�B</summary>
        /// <value>0�̏ꍇ�� �W���ݒ�Ƃ���B</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z�[�������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesMoneyFrcProcCd
        {
            get { return _salesMoneyFrcProcCd; }
            set { _salesMoneyFrcProcCd = value; }
        }

        /// public propaty name  :  SalesCnsTaxFrcProcCd
        /// <summary>�������Œ[�������R�[�h�v���p�e�B</summary>
        /// <value>0�̏ꍇ�� �W���ݒ�Ƃ���B</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������Œ[�������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesCnsTaxFrcProcCd
        {
            get { return _salesCnsTaxFrcProcCd; }
            set { _salesCnsTaxFrcProcCd = value; }
        }

        /// public propaty name  :  CustomerSlipNoDiv
        /// <summary>���Ӑ�`�[�ԍ��敪�v���p�e�B</summary>
        /// <value>0:�g�p���Ȃ�,1:�A��,2:����,3:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�`�[�ԍ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerSlipNoDiv
        {
            get { return _customerSlipNoDiv; }
            set { _customerSlipNoDiv = value; }
        }

        /// public propaty name  :  NTimeCalcStDate
        /// <summary>���񊨒�J�n���v���p�e�B</summary>
        /// <value>01�`31�܂Łi�ȗ��\�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񊨒�J�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NTimeCalcStDate
        {
            get { return _nTimeCalcStDate; }
            set { _nTimeCalcStDate = value; }
        }

        /// public propaty name  :  CustomerAgent
        /// <summary>���Ӑ�S���҃v���p�e�B</summary>
        /// <value>���Ӑ�i�d����j�̖₢���킹��Ј���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�S���҃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerAgent
        {
            get { return _customerAgent; }
            set { _customerAgent = value; }
        }

        /// public propaty name  :  ClaimSectionCode
        /// <summary>�������_�R�[�h�v���p�e�B</summary>
        /// <value>�������s�����_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ClaimSectionCode
        {
            get { return _claimSectionCode; }
            set { _claimSectionCode = value; }
        }

        /// public propaty name  :  ClaimSectionName
        /// <summary>�������_���̃v���p�e�B</summary>
        /// <value>���_�K�C�h����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ClaimSectionName
        {
            get { return _claimSectionName; }
            set { _claimSectionName = value; }
        }

        /// public propaty name  :  CarMngDivCd
        /// <summary>���q�Ǘ��敪�v���p�e�B</summary>
        /// <value>0:���Ȃ��A1:�o�^(�m�F)�A2:�o�^(����) 3:�o�^��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���q�Ǘ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CarMngDivCd
        {
            get { return _carMngDivCd; }
            set { _carMngDivCd = value; }
        }

        /// public propaty name  :  BillPartsNoPrtCd
        /// <summary>�i�Ԉ󎚋敪(������)�v���p�e�B</summary>
        /// <value>0:���i�}�X�^�A1:�L�A2:��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�Ԉ󎚋敪(������)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BillPartsNoPrtCd
        {
            get { return _billPartsNoPrtCd; }
            set { _billPartsNoPrtCd = value; }
        }

        /// public propaty name  :  DeliPartsNoPrtCd
        /// <summary>�i�Ԉ󎚋敪(�[�i���j�v���p�e�B</summary>
        /// <value>0:���i�}�X�^�A1:�L�A2:��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�Ԉ󎚋敪(�[�i���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DeliPartsNoPrtCd
        {
            get { return _deliPartsNoPrtCd; }
            set { _deliPartsNoPrtCd = value; }
        }

        /// public propaty name  :  DefSalesSlipCd
        /// <summary>�`�[�敪�����l�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�敪�����l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DefSalesSlipCd
        {
            get { return _defSalesSlipCd; }
            set { _defSalesSlipCd = value; }
        }

        /// public propaty name  :  LavorRateRank
        /// <summary>�H�����o���[�g�����N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �H�����o���[�g�����N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LavorRateRank
        {
            get { return _lavorRateRank; }
            set { _lavorRateRank = value; }
        }

        /// public propaty name  :  SlipTtlPrn
        /// <summary>�`�[�^�C�g���p�^�[���v���p�e�B</summary>
        /// <value>0000:���ݒ�A0100:��{�^�C�g���A0200�E�E</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�^�C�g���p�^�[���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipTtlPrn
        {
            get { return _slipTtlPrn; }
            set { _slipTtlPrn = value; }
        }

        /// public propaty name  :  DepoBankCode
        /// <summary>������s�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������s�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepoBankCode
        {
            get { return _depoBankCode; }
            set { _depoBankCode = value; }
        }

        /// public propaty name  :  DepoBankName
        /// <summary>������s���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������s���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DepoBankName
        {
            get { return _depoBankName; }
            set { _depoBankName = value; }
        }

        /// public propaty name  :  CustWarehouseCd
        /// <summary>���Ӑ�D��q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�D��q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustWarehouseCd
        {
            get { return _custWarehouseCd; }
            set { _custWarehouseCd = value; }
        }

        /// public propaty name  :  CustWarehouseName
        /// <summary>���Ӑ�D��q�ɖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�D��q�ɖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustWarehouseName
        {
            get { return _custWarehouseName; }
            set { _custWarehouseName = value; }
        }

        /// public propaty name  :  QrcodePrtCd
        /// <summary>QR�R�[�h����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   QR�R�[�h����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 QrcodePrtCd
        {
            get { return _qrcodePrtCd; }
            set { _qrcodePrtCd = value; }
        }

        /// public propaty name  :  DeliHonorificTtl
        /// <summary>�[�i���h�̃v���p�e�B</summary>
        /// <value>�[�i���p�̌h��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i���h�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DeliHonorificTtl
        {
            get { return _deliHonorificTtl; }
            set { _deliHonorificTtl = value; }
        }

        /// public propaty name  :  BillHonorificTtl
        /// <summary>�������h�̃v���p�e�B</summary>
        /// <value>�������p�̌h��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������h�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BillHonorificTtl
        {
            get { return _billHonorificTtl; }
            set { _billHonorificTtl = value; }
        }

        /// public propaty name  :  EstmHonorificTtl
        /// <summary>���Ϗ��h�̃v���p�e�B</summary>
        /// <value>���Ϗ��p�̌h��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ϗ��h�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EstmHonorificTtl
        {
            get { return _estmHonorificTtl; }
            set { _estmHonorificTtl = value; }
        }

        /// public propaty name  :  RectHonorificTtl
        /// <summary>�̎����h�̃v���p�e�B</summary>
        /// <value>�̎����p�̌h��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̎����h�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RectHonorificTtl
        {
            get { return _rectHonorificTtl; }
            set { _rectHonorificTtl = value; }
        }

        /// public propaty name  :  DeliHonorTtlPrtDiv
        /// <summary>�[�i���h�̈󎚋敪�v���p�e�B</summary>
        /// <value>0:���Ӑ�}�X�^ 1:�S�̍��ڐݒ�Q�� 2:���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i���h�̈󎚋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DeliHonorTtlPrtDiv
        {
            get { return _deliHonorTtlPrtDiv; }
            set { _deliHonorTtlPrtDiv = value; }
        }

        /// public propaty name  :  BillHonorTtlPrtDiv
        /// <summary>�������h�̈󎚋敪�v���p�e�B</summary>
        /// <value>0:���Ӑ�}�X�^ 1:�S�̍��ڐݒ�Q�� 2:���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������h�̈󎚋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BillHonorTtlPrtDiv
        {
            get { return _billHonorTtlPrtDiv; }
            set { _billHonorTtlPrtDiv = value; }
        }

        /// public propaty name  :  EstmHonorTtlPrtDiv
        /// <summary>���Ϗ��h�̈󎚋敪�v���p�e�B</summary>
        /// <value>0:���Ӑ�}�X�^ 1:�S�̍��ڐݒ�Q�� 2:���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ϗ��h�̈󎚋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EstmHonorTtlPrtDiv
        {
            get { return _estmHonorTtlPrtDiv; }
            set { _estmHonorTtlPrtDiv = value; }
        }

        /// public propaty name  :  RectHonorTtlPrtDiv
        /// <summary>�̎����h�̈󎚋敪�v���p�e�B</summary>
        /// <value>0:���Ӑ�}�X�^ 1:�S�̍��ڐݒ�Q�� 2:���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̎����h�̈󎚋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RectHonorTtlPrtDiv
        {
            get { return _rectHonorTtlPrtDiv; }
            set { _rectHonorTtlPrtDiv = value; }
        }

        /// public propaty name  :  Note1
        /// <summary>���l1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Note1
        {
            get { return _note1; }
            set { _note1 = value; }
        }

        /// public propaty name  :  Note2
        /// <summary>���l2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Note2
        {
            get { return _note2; }
            set { _note2 = value; }
        }

        /// public propaty name  :  Note3
        /// <summary>���l3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Note3
        {
            get { return _note3; }
            set { _note3 = value; }
        }

        /// public propaty name  :  Note4
        /// <summary>���l4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Note4
        {
            get { return _note4; }
            set { _note4 = value; }
        }

        /// public propaty name  :  Note5
        /// <summary>���l5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Note5
        {
            get { return _note5; }
            set { _note5 = value; }
        }

        /// public propaty name  :  Note6
        /// <summary>���l6�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Note6
        {
            get { return _note6; }
            set { _note6 = value; }
        }

        /// public propaty name  :  Note7
        /// <summary>���l7�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l7�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Note7
        {
            get { return _note7; }
            set { _note7 = value; }
        }

        /// public propaty name  :  Note8
        /// <summary>���l8�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l8�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Note8
        {
            get { return _note8; }
            set { _note8 = value; }
        }

        /// public propaty name  :  Note9
        /// <summary>���l9�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l9�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Note9
        {
            get { return _note9; }
            set { _note9 = value; }
        }

        /// public propaty name  :  Note10
        /// <summary>���l10�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Note10
        {
            get { return _note10; }
            set { _note10 = value; }
        }

        /// public propaty name  :  CreditMoney
        /// <summary>�^�M�z[�ϓ����]�v���p�e�B</summary>
        /// <value>�f�b�h���C��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�M�z[�ϓ����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CreditMoney
        {
            get { return _creditMoney; }
            set { _creditMoney = value; }
        }

        /// public propaty name  :  WarningCreditMoney
        /// <summary>�x���^�M�z[�ϓ����]�v���p�e�B</summary>
        /// <value>�x���\���p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���^�M�z[�ϓ����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 WarningCreditMoney
        {
            get { return _warningCreditMoney; }
            set { _warningCreditMoney = value; }
        }

        /// public propaty name  :  PrsntAccRecBalance
        /// <summary>���ݔ��|�c��[�ϓ����]�v���p�e�B</summary>
        /// <value>�����f�[�^�A����f�[�^�i���|�j��o�^����ꍇ�Ƀ��A���ɍX�V</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ݔ��|�c��[�ϓ����]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 PrsntAccRecBalance
        {
            get { return _prsntAccRecBalance; }
            set { _prsntAccRecBalance = value; }
        }

        /// public propaty name  :  RateGPureCode
        /// <summary>�����敪[�|��]�v���p�e�B</summary>
        /// <value>0:�����A1:�D��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪[�|��]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RateGPureCode
        {
            get { return _rateGPureCode; }
            set { _rateGPureCode = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h[�|��]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h[�|��]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  CustRateGrpCode
        /// <summary>���Ӑ�|���O���[�v�R�[�h[�|��]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�|���O���[�v�R�[�h[�|��]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustRateGrpCode
        {
            get { return _custRateGrpCode; }
            set { _custRateGrpCode = value; }
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

        /// public propaty name  :  UpdEmployeeName
        /// <summary>�X�V�]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeName
        {
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
        }

        /// public propaty name  :  InpSectionName
        /// <summary>���͋��_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͋��_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InpSectionName
        {
            get { return _inpSectionName; }
            set { _inpSectionName = value; }
        }

        /// public propaty name  :  BillOutPutCodeNm
        /// <summary>�������o�͋敪���̃v���p�e�B</summary>
        /// <value>���������s����,���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������o�͋敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BillOutPutCodeNm
        {
            get { return _billOutPutCodeNm; }
            set { _billOutPutCodeNm = value; }
        }

        /// public propaty name  :  BillCollecterNm
        /// <summary>�W���S���]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W���S���]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BillCollecterNm
        {
            get { return _billCollecterNm; }
            set { _billCollecterNm = value; }
        }

        /// public propaty name  :  ReceiptOutputCode
        /// <summary>�̎����o�͋敪�R�[�h�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̎����o�͋敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ReceiptOutputCode
        {
            get { return _receiptOutputCode; }
            set { _receiptOutputCode = value; }
        }

        /// public propaty name  :  TotalBillOutputDiv
        /// <summary>���v�������o�͋敪�v���p�e�B</summary>
        /// <value>0:�W�� 1:�g�p 2:���g�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�������o�͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int TotalBillOutputDiv
        {
            get { return _totalBillOutputDiv; }
            set { _totalBillOutputDiv = value; }
        }

        /// public propaty name  :  DetailBillOutputCode
        /// <summary>���א������o�͋敪�v���p�e�B</summary>
        /// <value>0:�W�� 1:�g�p 2:���g�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���א������o�͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int DetailBillOutputCode
        {
            get { return _detailBillOutputCode; }
            set { _detailBillOutputCode = value; }
        }

        /// public propaty name  :  SlipTtlBillOutputDiv
        /// <summary>�`�[���v�������o�͋敪�v���p�e�B</summary>
        /// <value>0:�W�� 1:�g�p 2:���g�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���v�������o�͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int SlipTtlBillOutputDiv
        {
            get { return _slipTtlBillOutputDiv; }
            set { _slipTtlBillOutputDiv = value; }
        }

        /// public propaty name  :  SalesSlipPrtDiv
        /// <summary>�[�i���o�́i����`�[���s�敪�j�v���p�e�B</summary>
        /// <value>0:�W�� 1:���g�p 2:�g�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i���o�́i����`�[���s�敪�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int SalesSlipPrtDiv
        {
            get { return _salesSlipPrtDiv; }
            set { _salesSlipPrtDiv = value; }
        }

        /// public propaty name  :  AcpOdrrSlipPrtDiv
        /// <summary>�󒍓`�[�o�́i�󒍓`�[���s�敪�j�v���p�e�B</summary>
        /// <value>0:�W�� 1:���g�p 2:�g�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍓`�[�o�́i�󒍓`�[���s�敪�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int AcpOdrrSlipPrtDiv
        {
            get { return _acpOdrrSlipPrtDiv; }
            set { _acpOdrrSlipPrtDiv = value; }
        }

        /// public propaty name  :  ShipmSlipPrtDiv
        /// <summary>�ݏo�`�[�o�́i�o�ד`�[���s�敪�j�v���p�e�B</summary>
        /// <value>0:�W�� 1:���g�p 2:�g�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ݏo�`�[�o�́i�o�ד`�[���s�敪�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int ShipmSlipPrtDiv
        {
            get { return _shipmSlipPrtDiv; }
            set { _shipmSlipPrtDiv = value; }
        }

        /// public propaty name  :  EstimatePrtDiv
        /// <summary>���ϓ`�[�o�́i���ϓ`�[���s�敪�j�v���p�e�B</summary>
        /// <value>0:�W�� 1:���g�p 2:�g�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ϓ`�[�o�́i���ϓ`�[���s�敪�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int EstimatePrtDiv
        {
            get { return _estimatePrtDiv; }
            set { _estimatePrtDiv = value; }
        }

        /// public propaty name  :  UOESlipPrtDiv
        /// <summary>UOE�`�[�o�́iUOE�`�[���s�敪�j�v���p�e�B</summary>
        /// <value>0:�W�� 1:���g�p 2:�g�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�`�[�o�́iUOE�`�[���s�敪�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int UOESlipPrtDiv
        {
            get { return _uoeSlipPrtDiv; }
            set { _uoeSlipPrtDiv = value; }
        }

        /// <summary>
        /// ���Ӑ�ꊇ�C���N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>CustomerCustomerChangeResult�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerCustomerChangeResult�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustomerCustomerChangeResult()
        {
        }

        /// <summary>
        /// ���Ӑ�ꊇ�C���N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="customerCode">���Ӑ�R�[�h(�[����̏ꍇ�̎g�p�\����)</param>
        /// <param name="customerSubCode">���Ӑ�T�u�R�[�h</param>
        /// <param name="name">����(�[����̏ꍇ�̎g�p�\����)</param>
        /// <param name="name2">����2(�[����̏ꍇ�̎g�p�\����)</param>
        /// <param name="honorificTitle">�h��</param>
        /// <param name="kana">�J�i</param>
        /// <param name="customerSnm">���Ӑ旪��</param>
        /// <param name="outputNameCode">�����R�[�h(0:�ڋq����1��2,1:�ڋq����1,2:�ڋq����2,3:��������)</param>
        /// <param name="outputName">��������</param>
        /// <param name="corporateDivCode">�l�E�@�l�敪(0:�l,1:�@�l,2:����@�l,3:�Ǝ�,4:�Ј�)</param>
        /// <param name="customerAttributeDiv">���Ӑ摮���敪(0:���������,8:�Г������,9:��������)</param>
        /// <param name="jobTypeCode">�E��R�[�h</param>
        /// <param name="jobTypeName">�E�햼��</param>
        /// <param name="businessTypeCode">�Ǝ�R�[�h</param>
        /// <param name="businessTypeName">�Ǝ햼��</param>
        /// <param name="salesAreaCode">�̔��G���A�R�[�h</param>
        /// <param name="salesAreaName">�̔��G���A����</param>
        /// <param name="postNo">�X�֔ԍ�(�[����̏ꍇ�̎g�p�\����)</param>
        /// <param name="address1">�Z��1�i�s���{���s��S�E�����E���j(�[����̏ꍇ�̎g�p�\����)</param>
        /// <param name="address3">�Z��3�i�Ԓn�j(�[����̏ꍇ�̎g�p�\����)</param>
        /// <param name="address4">�Z��4�i�A�p�[�g���́j(�[����̏ꍇ�̎g�p�\����)</param>
        /// <param name="homeTelNo">�d�b�ԍ��i����j(�n�C�t�����܂߂�16���̔ԍ�)</param>
        /// <param name="officeTelNo">�d�b�ԍ��i�Ζ���j(�[����̏ꍇ�̎g�p�\����)</param>
        /// <param name="portableTelNo">�d�b�ԍ��i�g�сj</param>
        /// <param name="homeFaxNo">FAX�ԍ��i����j</param>
        /// <param name="officeFaxNo">FAX�ԍ��i�Ζ���j(�[����̏ꍇ�̎g�p�\����)</param>
        /// <param name="othersTelNo">�d�b�ԍ��i���̑��j</param>
        /// <param name="mainContactCode">��A����敪(0:����,1:�Ζ���,2:�g��,3:����FAX,4:�Ζ���FAX���)</param>
        /// <param name="searchTelNo">�d�b�ԍ��i�����p��4���j</param>
        /// <param name="mngSectionCode">�Ǘ����_�R�[�h</param>
        /// <param name="mngSectionName">�Ǘ����_����</param>
        /// <param name="inpSectionCode">���͋��_�R�[�h</param>
        /// <param name="custAnalysCode1">���Ӑ敪�̓R�[�h1</param>
        /// <param name="custAnalysCode2">���Ӑ敪�̓R�[�h2</param>
        /// <param name="custAnalysCode3">���Ӑ敪�̓R�[�h3</param>
        /// <param name="custAnalysCode4">���Ӑ敪�̓R�[�h4</param>
        /// <param name="custAnalysCode5">���Ӑ敪�̓R�[�h5</param>
        /// <param name="custAnalysCode6">���Ӑ敪�̓R�[�h6</param>
        /// <param name="billOutputCode">�������o�͋敪�R�[�h(0:���������s����,1:���Ȃ�)</param>
        /// <param name="billOutputName">�������o�͋敪����</param>
        /// <param name="totalDay">����(DD)</param>
        /// <param name="collectMoneyCode">�W�����敪�R�[�h(0:����,1:����,2:���X��)</param>
        /// <param name="collectMoneyName">�W�����敪����(����,����,���X��)</param>
        /// <param name="collectMoneyDay">�W����(DD)</param>
        /// <param name="collectCond">�������(10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�)</param>
        /// <param name="collectSight">����T�C�g(��`�T�C�g�@180��)</param>
        /// <param name="claimCode">������R�[�h(�����擾�Ӑ�B�[����̏ꍇ�̎g�p�\����)</param>
        /// <param name="claimName">�����於��</param>
        /// <param name="claimName2">�����於��2</param>
        /// <param name="claimSnm">�����旪��</param>
        /// <param name="transStopDate">������~��(YYYYMMDD)</param>
        /// <param name="dmOutCode">DM�o�͋敪(0:�o�͂���,1:�o�͂��Ȃ�)</param>
        /// <param name="dmOutName">DM�o�͋敪����(�S�p�ŊǗ�)</param>
        /// <param name="mainSendMailAddrCd">�呗�M�惁�[���A�h���X�敪(0:���[���A�h���X1,1:���[���A�h���X2)</param>
        /// <param name="mailAddrKindCode1">���[���A�h���X��ʃR�[�h1(0:����,1:���,2:�g�ђ[��,3:�{�l�ȊO,99:���̑�)</param>
        /// <param name="mailAddrKindName1">���[���A�h���X��ʖ���1</param>
        /// <param name="mailAddress1">���[���A�h���X1</param>
        /// <param name="mailSendCode1">���[�����M�敪�R�[�h1(0:�񑗐M,1:���M)</param>
        /// <param name="mailSendName1">���[�����M�敪����1</param>
        /// <param name="mailAddrKindCode2">���[���A�h���X��ʃR�[�h2(0:����,1:���,2:�g�ђ[��,3:�{�l�ȊO,99:���̑�)</param>
        /// <param name="mailAddrKindName2">���[���A�h���X��ʖ���2</param>
        /// <param name="mailAddress2">���[���A�h���X2</param>
        /// <param name="mailSendCode2">���[�����M�敪�R�[�h2(0:�񑗐M,1:���M)</param>
        /// <param name="mailSendName2">���[�����M�敪����2</param>
        /// <param name="customerAgentCd">�ڋq�S���]�ƈ��R�[�h(�����^)</param>
        /// <param name="customerAgentNm">�ڋq�S���]�ƈ�����</param>
        /// <param name="billCollecterCd">�W���S���]�ƈ��R�[�h</param>
        /// <param name="oldCustomerAgentCd">���ڋq�S���]�ƈ��R�[�h</param>
        /// <param name="oldCustomerAgentNm">���ڋq�S���]�ƈ�����</param>
        /// <param name="custAgentChgDate">�ڋq�S���ύX��(YYYYMMDD)</param>
        /// <param name="acceptWholeSale">�Ɣ̐�敪(0:�Ɣ̐�ȊO,1:�Ɣ̐�,2:�[����)</param>
        /// <param name="creditMngCode">�^�M�Ǘ��敪</param>
        /// <param name="depoDelCode">���������敪(PM(0:���Ȃ�,1:����) G/D( 0:���Ȃ�,1:����(������),2:����(�[�i��)�j)</param>
        /// <param name="accRecDivCd">���|�敪(0:���|�Ȃ�,1:���|)</param>
        /// <param name="custSlipNoMngCd">����`�[�ԍ��Ǘ��敪(0:���Ȃ��@1:����)</param>
        /// <param name="pureCode">�����敪(0:�����A1:���̑��iPM�͗D�ǁj�@)</param>
        /// <param name="custCTaXLayRefCd">���Ӑ����œ]�ŕ����Q�Ƌ敪(0:�ŗ��ݒ�}�X�^���Q�Ɓ@1:���Ӑ�}�X�^���Q��)</param>
        /// <param name="consTaxLayMethod">����œ]�ŕ���(0:�`�[�P��1:���גP��2:�����e3:�����q�@9:��ې�)</param>
        /// <param name="totalAmountDispWayCd">���z�\�����@�敪(0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j)</param>
        /// <param name="totalAmntDspWayRef">���z�\�����@�Q�Ƌ敪(0:�S�̐ݒ�Q�� 1:���Ӑ�Q��)</param>
        /// <param name="accountNoInfo1">��s����1</param>
        /// <param name="accountNoInfo2">��s����2</param>
        /// <param name="accountNoInfo3">��s����3</param>
        /// <param name="salesUnPrcFrcProcCd">����P���[�������R�[�h(0�̏ꍇ�� �W���ݒ�Ƃ���B)</param>
        /// <param name="salesMoneyFrcProcCd">������z�[�������R�[�h(0�̏ꍇ�� �W���ݒ�Ƃ���B)</param>
        /// <param name="salesCnsTaxFrcProcCd">�������Œ[�������R�[�h(0�̏ꍇ�� �W���ݒ�Ƃ���B)</param>
        /// <param name="customerSlipNoDiv">���Ӑ�`�[�ԍ��敪(0:�g�p���Ȃ�,1:�A��,2:����,3:����)</param>
        /// <param name="nTimeCalcStDate">���񊨒�J�n��(01�`31�܂Łi�ȗ��\�j)</param>
        /// <param name="customerAgent">���Ӑ�S����(���Ӑ�i�d����j�̖₢���킹��Ј���)</param>
        /// <param name="claimSectionCode">�������_�R�[�h(�������s�����_)</param>
        /// <param name="claimSectionName">�������_����(���_�K�C�h����)</param>
        /// <param name="carMngDivCd">���q�Ǘ��敪(0:���Ȃ��A1:�o�^(�m�F)�A2:�o�^(����) 3:�o�^��)</param>
        /// <param name="billPartsNoPrtCd">�i�Ԉ󎚋敪(������)(0:���i�}�X�^�A1:�L�A2:��)</param>
        /// <param name="deliPartsNoPrtCd">�i�Ԉ󎚋敪(�[�i���j(0:���i�}�X�^�A1:�L�A2:��)</param>
        /// <param name="defSalesSlipCd">�`�[�敪�����l</param>
        /// <param name="lavorRateRank">�H�����o���[�g�����N</param>
        /// <param name="slipTtlPrn">�`�[�^�C�g���p�^�[��(0000:���ݒ�A0100:��{�^�C�g���A0200�E�E)</param>
        /// <param name="depoBankCode">������s�R�[�h</param>
        /// <param name="depoBankName">������s����</param>
        /// <param name="custWarehouseCd">���Ӑ�D��q�ɃR�[�h</param>
        /// <param name="custWarehouseName">���Ӑ�D��q�ɖ���</param>
        /// <param name="qrcodePrtCd">QR�R�[�h���</param>
        /// <param name="deliHonorificTtl">�[�i���h��(�[�i���p�̌h��)</param>
        /// <param name="billHonorificTtl">�������h��(�������p�̌h��)</param>
        /// <param name="estmHonorificTtl">���Ϗ��h��(���Ϗ��p�̌h��)</param>
        /// <param name="rectHonorificTtl">�̎����h��(�̎����p�̌h��)</param>
        /// <param name="deliHonorTtlPrtDiv">�[�i���h�̈󎚋敪(0:���Ӑ�}�X�^ 1:�S�̍��ڐݒ�Q�� 2:���)</param>
        /// <param name="billHonorTtlPrtDiv">�������h�̈󎚋敪(0:���Ӑ�}�X�^ 1:�S�̍��ڐݒ�Q�� 2:���)</param>
        /// <param name="estmHonorTtlPrtDiv">���Ϗ��h�̈󎚋敪(0:���Ӑ�}�X�^ 1:�S�̍��ڐݒ�Q�� 2:���)</param>
        /// <param name="rectHonorTtlPrtDiv">�̎����h�̈󎚋敪(0:���Ӑ�}�X�^ 1:�S�̍��ڐݒ�Q�� 2:���)</param>
        /// <param name="note1">���l1</param>
        /// <param name="note2">���l2</param>
        /// <param name="note3">���l3</param>
        /// <param name="note4">���l4</param>
        /// <param name="note5">���l5</param>
        /// <param name="note6">���l6</param>
        /// <param name="note7">���l7</param>
        /// <param name="note8">���l8</param>
        /// <param name="note9">���l9</param>
        /// <param name="note10">���l10</param>
        /// <param name="creditMoney">�^�M�z[�ϓ����](�f�b�h���C��)</param>
        /// <param name="warningCreditMoney">�x���^�M�z[�ϓ����](�x���\���p)</param>
        /// <param name="prsntAccRecBalance">���ݔ��|�c��[�ϓ����](�����f�[�^�A����f�[�^�i���|�j��o�^����ꍇ�Ƀ��A���ɍX�V)</param>
        /// <param name="rateGPureCode">�����敪[�|��](0:�����A1:�D��)</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h[�|��]</param>
        /// <param name="custRateGrpCode">���Ӑ�|���O���[�v�R�[�h[�|��]</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="inpSectionName">���͋��_����</param>
        /// <param name="billOutPutCodeNm">�������o�͋敪����(���������s����,���Ȃ�)</param>
        /// <param name="billCollecterNm">�W���S���]�ƈ�����</param>
        /// <param name="receiptOutputCode">�̎����o�͋敪�R�[�h</param>
        /// <param name="salesSlipPrtDiv">�[�i���o�́i����`�[���s�敪�j</param>
        /// <param name="acpOdrrSlipPrtDiv">�󒍓`�[�o�́i�󒍓`�[���s�敪�j</param>
        /// <param name="shipmSlipPrtDiv">�ݏo�`�[�o�́i�o�ד`�[���s�敪�j</param>
        /// <param name="estimatePrtDiv">���ϓ`�[�o�́i���ϓ`�[���s�敪�j</param>
        /// <param name="uoeSlipPrtDiv">UOE�`�[�o�́iUOE�`�[���s�敪�j</param>
        /// <param name="totalBillOutputDiv">���v�������o�͋敪</param>
        /// <param name="detailBillOutputCode">���א������o�͋敪</param>
        /// <param name="slipTtlBillOutputDiv">�`�[���v�������o�͏o�͋敪</param>
        /// <returns>CustomerCustomerChangeResult�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerCustomerChangeResult�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustomerCustomerChangeResult(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 customerCode, string customerSubCode, string name, string name2, string honorificTitle, string kana, string customerSnm, Int32 outputNameCode, string outputName, Int32 corporateDivCode, Int32 customerAttributeDiv, Int32 jobTypeCode, string jobTypeName, Int32 businessTypeCode, string businessTypeName, Int32 salesAreaCode, string salesAreaName, string postNo, string address1, string address3, string address4, string homeTelNo, string officeTelNo, string portableTelNo, string homeFaxNo, string officeFaxNo, string othersTelNo, Int32 mainContactCode, string searchTelNo, string mngSectionCode, string mngSectionName, string inpSectionCode, Int32 custAnalysCode1, Int32 custAnalysCode2, Int32 custAnalysCode3, Int32 custAnalysCode4, Int32 custAnalysCode5, Int32 custAnalysCode6, Int32 billOutputCode, string billOutputName, Int32 totalDay, Int32 collectMoneyCode, string collectMoneyName, Int32 collectMoneyDay, Int32 collectCond, Int32 collectSight, Int32 claimCode, string claimName, string claimName2, string claimSnm, DateTime transStopDate, Int32 dmOutCode, string dmOutName, Int32 mainSendMailAddrCd, Int32 mailAddrKindCode1, string mailAddrKindName1, string mailAddress1, Int32 mailSendCode1, string mailSendName1, Int32 mailAddrKindCode2, string mailAddrKindName2, string mailAddress2, Int32 mailSendCode2, string mailSendName2, string customerAgentCd, string customerAgentNm, string billCollecterCd, string oldCustomerAgentCd, string oldCustomerAgentNm, DateTime custAgentChgDate, Int32 acceptWholeSale, Int32 creditMngCode, Int32 depoDelCode, Int32 accRecDivCd, Int32 custSlipNoMngCd, Int32 pureCode, Int32 custCTaXLayRefCd, Int32 consTaxLayMethod, Int32 totalAmountDispWayCd, Int32 totalAmntDspWayRef, string accountNoInfo1, string accountNoInfo2, string accountNoInfo3, Int32 salesUnPrcFrcProcCd, Int32 salesMoneyFrcProcCd, Int32 salesCnsTaxFrcProcCd, Int32 customerSlipNoDiv, Int32 nTimeCalcStDate, string customerAgent, string claimSectionCode, string claimSectionName, Int32 carMngDivCd, Int32 billPartsNoPrtCd, Int32 deliPartsNoPrtCd, Int32 defSalesSlipCd, Int32 lavorRateRank, Int32 slipTtlPrn, Int32 depoBankCode, string depoBankName, string custWarehouseCd, string custWarehouseName, Int32 qrcodePrtCd, string deliHonorificTtl, string billHonorificTtl, string estmHonorificTtl, string rectHonorificTtl, Int32 deliHonorTtlPrtDiv, Int32 billHonorTtlPrtDiv, Int32 estmHonorTtlPrtDiv, Int32 rectHonorTtlPrtDiv, string note1, string note2, string note3, string note4, string note5, string note6, string note7, string note8, string note9, string note10, Int64 creditMoney, Int64 warningCreditMoney, Int64 prsntAccRecBalance, Int32 rateGPureCode, Int32 goodsMakerCd, Int32 custRateGrpCode, string enterpriseName, string updEmployeeName, string inpSectionName, string billOutPutCodeNm, string billCollecterNm, Int32 receiptOutputCode
            , int salesSlipPrtDiv, int acpOdrrSlipPrtDiv, int shipmSlipPrtDiv, int estimatePrtDiv, int uoeSlipPrtDiv
            , int totalBillOutputDiv, int detailBillOutputCode, int slipTtlBillOutputDiv)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._customerCode = customerCode;
            this._customerSubCode = customerSubCode;
            this._name = name;
            this._name2 = name2;
            this._honorificTitle = honorificTitle;
            this._kana = kana;
            this._customerSnm = customerSnm;
            this._outputNameCode = outputNameCode;
            this._outputName = outputName;
            this._corporateDivCode = corporateDivCode;
            this._customerAttributeDiv = customerAttributeDiv;
            this._jobTypeCode = jobTypeCode;
            this._jobTypeName = jobTypeName;
            this._businessTypeCode = businessTypeCode;
            this._businessTypeName = businessTypeName;
            this._salesAreaCode = salesAreaCode;
            this._salesAreaName = salesAreaName;
            this._postNo = postNo;
            this._address1 = address1;
            this._address3 = address3;
            this._address4 = address4;
            this._homeTelNo = homeTelNo;
            this._officeTelNo = officeTelNo;
            this._portableTelNo = portableTelNo;
            this._homeFaxNo = homeFaxNo;
            this._officeFaxNo = officeFaxNo;
            this._othersTelNo = othersTelNo;
            this._mainContactCode = mainContactCode;
            this._searchTelNo = searchTelNo;
            this._mngSectionCode = mngSectionCode;
            this._mngSectionName = mngSectionName;
            this._inpSectionCode = inpSectionCode;
            this._custAnalysCode1 = custAnalysCode1;
            this._custAnalysCode2 = custAnalysCode2;
            this._custAnalysCode3 = custAnalysCode3;
            this._custAnalysCode4 = custAnalysCode4;
            this._custAnalysCode5 = custAnalysCode5;
            this._custAnalysCode6 = custAnalysCode6;
            this._billOutputCode = billOutputCode;
            this._billOutputName = billOutputName;
            this._totalDay = totalDay;
            this._collectMoneyCode = collectMoneyCode;
            this._collectMoneyName = collectMoneyName;
            this._collectMoneyDay = collectMoneyDay;
            this._collectCond = collectCond;
            this._collectSight = collectSight;
            this._claimCode = claimCode;
            this._claimName = claimName;
            this._claimName2 = claimName2;
            this._claimSnm = claimSnm;
            this.TransStopDate = transStopDate;
            this._dmOutCode = dmOutCode;
            this._dmOutName = dmOutName;
            this._mainSendMailAddrCd = mainSendMailAddrCd;
            this._mailAddrKindCode1 = mailAddrKindCode1;
            this._mailAddrKindName1 = mailAddrKindName1;
            this._mailAddress1 = mailAddress1;
            this._mailSendCode1 = mailSendCode1;
            this._mailSendName1 = mailSendName1;
            this._mailAddrKindCode2 = mailAddrKindCode2;
            this._mailAddrKindName2 = mailAddrKindName2;
            this._mailAddress2 = mailAddress2;
            this._mailSendCode2 = mailSendCode2;
            this._mailSendName2 = mailSendName2;
            this._customerAgentCd = customerAgentCd;
            this._customerAgentNm = customerAgentNm;
            this._billCollecterCd = billCollecterCd;
            this._oldCustomerAgentCd = oldCustomerAgentCd;
            this._oldCustomerAgentNm = oldCustomerAgentNm;
            this.CustAgentChgDate = custAgentChgDate;
            this._acceptWholeSale = acceptWholeSale;
            this._creditMngCode = creditMngCode;
            this._depoDelCode = depoDelCode;
            this._accRecDivCd = accRecDivCd;
            this._custSlipNoMngCd = custSlipNoMngCd;
            this._pureCode = pureCode;
            this._custCTaXLayRefCd = custCTaXLayRefCd;
            this._consTaxLayMethod = consTaxLayMethod;
            this._totalAmountDispWayCd = totalAmountDispWayCd;
            this._totalAmntDspWayRef = totalAmntDspWayRef;
            this._accountNoInfo1 = accountNoInfo1;
            this._accountNoInfo2 = accountNoInfo2;
            this._accountNoInfo3 = accountNoInfo3;
            this._salesUnPrcFrcProcCd = salesUnPrcFrcProcCd;
            this._salesMoneyFrcProcCd = salesMoneyFrcProcCd;
            this._salesCnsTaxFrcProcCd = salesCnsTaxFrcProcCd;
            this._customerSlipNoDiv = customerSlipNoDiv;
            this._nTimeCalcStDate = nTimeCalcStDate;
            this._customerAgent = customerAgent;
            this._claimSectionCode = claimSectionCode;
            this._claimSectionName = claimSectionName;
            this._carMngDivCd = carMngDivCd;
            this._billPartsNoPrtCd = billPartsNoPrtCd;
            this._deliPartsNoPrtCd = deliPartsNoPrtCd;
            this._defSalesSlipCd = defSalesSlipCd;
            this._lavorRateRank = lavorRateRank;
            this._slipTtlPrn = slipTtlPrn;
            this._depoBankCode = depoBankCode;
            this._depoBankName = depoBankName;
            this._custWarehouseCd = custWarehouseCd;
            this._custWarehouseName = custWarehouseName;
            this._qrcodePrtCd = qrcodePrtCd;
            this._deliHonorificTtl = deliHonorificTtl;
            this._billHonorificTtl = billHonorificTtl;
            this._estmHonorificTtl = estmHonorificTtl;
            this._rectHonorificTtl = rectHonorificTtl;
            this._deliHonorTtlPrtDiv = deliHonorTtlPrtDiv;
            this._billHonorTtlPrtDiv = billHonorTtlPrtDiv;
            this._estmHonorTtlPrtDiv = estmHonorTtlPrtDiv;
            this._rectHonorTtlPrtDiv = rectHonorTtlPrtDiv;
            this._note1 = note1;
            this._note2 = note2;
            this._note3 = note3;
            this._note4 = note4;
            this._note5 = note5;
            this._note6 = note6;
            this._note7 = note7;
            this._note8 = note8;
            this._note9 = note9;
            this._note10 = note10;
            this._creditMoney = creditMoney;
            this._warningCreditMoney = warningCreditMoney;
            this._prsntAccRecBalance = prsntAccRecBalance;
            this._rateGPureCode = rateGPureCode;
            this._goodsMakerCd = goodsMakerCd;
            this._custRateGrpCode = custRateGrpCode;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._inpSectionName = inpSectionName;
            this._billOutPutCodeNm = billOutPutCodeNm;
            this._billCollecterNm = billCollecterNm;
            this._receiptOutputCode = receiptOutputCode;
            this._salesSlipPrtDiv = salesSlipPrtDiv;
            this._acpOdrrSlipPrtDiv = acpOdrrSlipPrtDiv;
            this._shipmSlipPrtDiv = shipmSlipPrtDiv;
            this._estimatePrtDiv = estimatePrtDiv;
            this._uoeSlipPrtDiv = uoeSlipPrtDiv;
            this._totalBillOutputDiv = totalBillOutputDiv;
            this._detailBillOutputCode = detailBillOutputCode;
            this._slipTtlBillOutputDiv = slipTtlBillOutputDiv;
        }

        /// <summary>
        /// ���Ӑ�ꊇ�C���N���X���[�N��������
        /// </summary>
        /// <returns>CustomerCustomerChangeResult�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����CustomerCustomerChangeResult�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustomerCustomerChangeResult Clone()
        {
            return new CustomerCustomerChangeResult(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._customerCode, this._customerSubCode, this._name, this._name2, this._honorificTitle, this._kana, this._customerSnm, this._outputNameCode, this._outputName, this._corporateDivCode, this._customerAttributeDiv, this._jobTypeCode, this._jobTypeName, this._businessTypeCode, this._businessTypeName, this._salesAreaCode, this._salesAreaName, this._postNo, this._address1, this._address3, this._address4, this._homeTelNo, this._officeTelNo, this._portableTelNo, this._homeFaxNo, this._officeFaxNo, this._othersTelNo, this._mainContactCode, this._searchTelNo, this._mngSectionCode, this._mngSectionName, this._inpSectionCode, this._custAnalysCode1, this._custAnalysCode2, this._custAnalysCode3, this._custAnalysCode4, this._custAnalysCode5, this._custAnalysCode6, this._billOutputCode, this._billOutputName, this._totalDay, this._collectMoneyCode, this._collectMoneyName, this._collectMoneyDay, this._collectCond, this._collectSight, this._claimCode, this._claimName, this._claimName2, this._claimSnm, this._transStopDate, this._dmOutCode, this._dmOutName, this._mainSendMailAddrCd, this._mailAddrKindCode1, this._mailAddrKindName1, this._mailAddress1, this._mailSendCode1, this._mailSendName1, this._mailAddrKindCode2, this._mailAddrKindName2, this._mailAddress2, this._mailSendCode2, this._mailSendName2, this._customerAgentCd, this._customerAgentNm, this._billCollecterCd, this._oldCustomerAgentCd, this._oldCustomerAgentNm, this._custAgentChgDate, this._acceptWholeSale, this._creditMngCode, this._depoDelCode, this._accRecDivCd, this._custSlipNoMngCd, this._pureCode, this._custCTaXLayRefCd, this._consTaxLayMethod, this._totalAmountDispWayCd, this._totalAmntDspWayRef, this._accountNoInfo1, this._accountNoInfo2, this._accountNoInfo3, this._salesUnPrcFrcProcCd, this._salesMoneyFrcProcCd, this._salesCnsTaxFrcProcCd, this._customerSlipNoDiv, this._nTimeCalcStDate, this._customerAgent, this._claimSectionCode, this._claimSectionName, this._carMngDivCd, this._billPartsNoPrtCd, this._deliPartsNoPrtCd, this._defSalesSlipCd, this._lavorRateRank, this._slipTtlPrn, this._depoBankCode, this._depoBankName, this._custWarehouseCd, this._custWarehouseName, this._qrcodePrtCd, this._deliHonorificTtl, this._billHonorificTtl, this._estmHonorificTtl, this._rectHonorificTtl, this._deliHonorTtlPrtDiv, this._billHonorTtlPrtDiv, this._estmHonorTtlPrtDiv, this._rectHonorTtlPrtDiv, this._note1, this._note2, this._note3, this._note4, this._note5, this._note6, this._note7, this._note8, this._note9, this._note10, this._creditMoney, this._warningCreditMoney, this._prsntAccRecBalance, this._rateGPureCode, this._goodsMakerCd, this._custRateGrpCode, this._enterpriseName, this._updEmployeeName, this._inpSectionName, this._billOutPutCodeNm, this._billCollecterNm, this._receiptOutputCode
                , this._salesSlipPrtDiv, this._acpOdrrSlipPrtDiv, this._shipmSlipPrtDiv, this._estimatePrtDiv, this._uoeSlipPrtDiv 
                , this._totalBillOutputDiv, this._detailBillOutputCode, this._slipTtlBillOutputDiv);
        }

        /// <summary>
        /// ���Ӑ�ꊇ�C���N���X���[�N��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CustomerCustomerChangeResult�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerCustomerChangeResult�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(CustomerCustomerChangeResult target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.CustomerSubCode == target.CustomerSubCode)
                 && (this.Name == target.Name)
                 && (this.Name2 == target.Name2)
                 && (this.HonorificTitle == target.HonorificTitle)
                 && (this.Kana == target.Kana)
                 && (this.CustomerSnm == target.CustomerSnm)
                 && (this.OutputNameCode == target.OutputNameCode)
                 //&& (this.OutputName == target.OutputName)
                 && (this.CorporateDivCode == target.CorporateDivCode)
                 && (this.CustomerAttributeDiv == target.CustomerAttributeDiv)
                 && (this.JobTypeCode == target.JobTypeCode)
                 && (this.JobTypeName == target.JobTypeName)
                 && (this.BusinessTypeCode == target.BusinessTypeCode)
                 && (this.BusinessTypeName == target.BusinessTypeName)
                 && (this.SalesAreaCode == target.SalesAreaCode)
                 && (this.SalesAreaName == target.SalesAreaName)
                 && (this.PostNo == target.PostNo)
                 && (this.Address1 == target.Address1)
                 && (this.Address3 == target.Address3)
                 && (this.Address4 == target.Address4)
                 && (this.HomeTelNo == target.HomeTelNo)
                 && (this.OfficeTelNo == target.OfficeTelNo)
                 && (this.PortableTelNo == target.PortableTelNo)
                 && (this.HomeFaxNo == target.HomeFaxNo)
                 && (this.OfficeFaxNo == target.OfficeFaxNo)
                 && (this.OthersTelNo == target.OthersTelNo)
                 && (this.MainContactCode == target.MainContactCode)
                 && (this.SearchTelNo == target.SearchTelNo)
                 && (this.MngSectionCode == target.MngSectionCode)
                 && (this.MngSectionName == target.MngSectionName)
                 && (this.InpSectionCode == target.InpSectionCode)
                 && (this.CustAnalysCode1 == target.CustAnalysCode1)
                 && (this.CustAnalysCode2 == target.CustAnalysCode2)
                 && (this.CustAnalysCode3 == target.CustAnalysCode3)
                 && (this.CustAnalysCode4 == target.CustAnalysCode4)
                 && (this.CustAnalysCode5 == target.CustAnalysCode5)
                 && (this.CustAnalysCode6 == target.CustAnalysCode6)
                 && (this.BillOutputCode == target.BillOutputCode)
                 && (this.BillOutputName == target.BillOutputName)
                 && (this.TotalDay == target.TotalDay)
                 && (this.CollectMoneyCode == target.CollectMoneyCode)
                 && (this.CollectMoneyName == target.CollectMoneyName)
                 && (this.CollectMoneyDay == target.CollectMoneyDay)
                 && (this.CollectCond == target.CollectCond)
                 && (this.CollectSight == target.CollectSight)
                 && (this.ClaimCode == target.ClaimCode)
                 && (this.ClaimName == target.ClaimName)
                 && (this.ClaimName2 == target.ClaimName2)
                 && (this.ClaimSnm == target.ClaimSnm)
                 && (this.TransStopDate == target.TransStopDate)
                 && (this.DmOutCode == target.DmOutCode)
                 && (this.DmOutName == target.DmOutName)
                 && (this.MainSendMailAddrCd == target.MainSendMailAddrCd)
                 && (this.MailAddrKindCode1 == target.MailAddrKindCode1)
                 && (this.MailAddrKindName1 == target.MailAddrKindName1)
                 && (this.MailAddress1 == target.MailAddress1)
                 && (this.MailSendCode1 == target.MailSendCode1)
                 && (this.MailSendName1 == target.MailSendName1)
                 && (this.MailAddrKindCode2 == target.MailAddrKindCode2)
                 && (this.MailAddrKindName2 == target.MailAddrKindName2)
                 && (this.MailAddress2 == target.MailAddress2)
                 && (this.MailSendCode2 == target.MailSendCode2)
                 && (this.MailSendName2 == target.MailSendName2)
                 && (this.CustomerAgentCd == target.CustomerAgentCd)
                 && (this.CustomerAgentNm == target.CustomerAgentNm)
                 && (this.BillCollecterCd == target.BillCollecterCd)
                 && (this.OldCustomerAgentCd == target.OldCustomerAgentCd)
                 && (this.OldCustomerAgentNm == target.OldCustomerAgentNm)
                 && (this.CustAgentChgDate == target.CustAgentChgDate)
                 && (this.AcceptWholeSale == target.AcceptWholeSale)
                 && (this.CreditMngCode == target.CreditMngCode)
                 && (this.DepoDelCode == target.DepoDelCode)
                 && (this.AccRecDivCd == target.AccRecDivCd)
                 && (this.CustSlipNoMngCd == target.CustSlipNoMngCd)
                 && (this.PureCode == target.PureCode)
                 && (this.CustCTaXLayRefCd == target.CustCTaXLayRefCd)
                 && (this.ConsTaxLayMethod == target.ConsTaxLayMethod)
                 && (this.TotalAmountDispWayCd == target.TotalAmountDispWayCd)
                 && (this.TotalAmntDspWayRef == target.TotalAmntDspWayRef)
                 && (this.AccountNoInfo1 == target.AccountNoInfo1)
                 && (this.AccountNoInfo2 == target.AccountNoInfo2)
                 && (this.AccountNoInfo3 == target.AccountNoInfo3)
                 && (this.SalesUnPrcFrcProcCd == target.SalesUnPrcFrcProcCd)
                 && (this.SalesMoneyFrcProcCd == target.SalesMoneyFrcProcCd)
                 && (this.SalesCnsTaxFrcProcCd == target.SalesCnsTaxFrcProcCd)
                 && (this.CustomerSlipNoDiv == target.CustomerSlipNoDiv)
                 && (this.NTimeCalcStDate == target.NTimeCalcStDate)
                 && (this.CustomerAgent == target.CustomerAgent)
                 && (this.ClaimSectionCode == target.ClaimSectionCode)
                 && (this.ClaimSectionName == target.ClaimSectionName)
                 && (this.CarMngDivCd == target.CarMngDivCd)
                 && (this.BillPartsNoPrtCd == target.BillPartsNoPrtCd)
                 && (this.DeliPartsNoPrtCd == target.DeliPartsNoPrtCd)
                 && (this.DefSalesSlipCd == target.DefSalesSlipCd)
                 && (this.LavorRateRank == target.LavorRateRank)
                 && (this.SlipTtlPrn == target.SlipTtlPrn)
                 && (this.DepoBankCode == target.DepoBankCode)
                 && (this.DepoBankName == target.DepoBankName)
                 && (this.CustWarehouseCd == target.CustWarehouseCd)
                 && (this.CustWarehouseName == target.CustWarehouseName)
                 && (this.QrcodePrtCd == target.QrcodePrtCd)
                 && (this.DeliHonorificTtl == target.DeliHonorificTtl)
                 && (this.BillHonorificTtl == target.BillHonorificTtl)
                 && (this.EstmHonorificTtl == target.EstmHonorificTtl)
                 && (this.RectHonorificTtl == target.RectHonorificTtl)
                 && (this.DeliHonorTtlPrtDiv == target.DeliHonorTtlPrtDiv)
                 && (this.BillHonorTtlPrtDiv == target.BillHonorTtlPrtDiv)
                 && (this.EstmHonorTtlPrtDiv == target.EstmHonorTtlPrtDiv)
                 && (this.RectHonorTtlPrtDiv == target.RectHonorTtlPrtDiv)
                 && (this.Note1 == target.Note1)
                 && (this.Note2 == target.Note2)
                 && (this.Note3 == target.Note3)
                 && (this.Note4 == target.Note4)
                 && (this.Note5 == target.Note5)
                 && (this.Note6 == target.Note6)
                 && (this.Note7 == target.Note7)
                 && (this.Note8 == target.Note8)
                 && (this.Note9 == target.Note9)
                 && (this.Note10 == target.Note10)
                 && (this.CreditMoney == target.CreditMoney)
                 && (this.WarningCreditMoney == target.WarningCreditMoney)
                 && (this.PrsntAccRecBalance == target.PrsntAccRecBalance)
                 && (this.RateGPureCode == target.RateGPureCode)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.CustRateGrpCode == target.CustRateGrpCode)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.InpSectionName == target.InpSectionName)
                 && (this.BillOutPutCodeNm == target.BillOutPutCodeNm)
                 //&& (this.BillCollecterNm == target.BillCollecterNm)
                 && (this.ReceiptOutputCode == target.ReceiptOutputCode)

                 && (this.SalesSlipPrtDiv == target.SalesSlipPrtDiv)
                 && (this.AcpOdrrSlipPrtDiv == target.AcpOdrrSlipPrtDiv)
                 && (this.ShipmSlipPrtDiv == target.ShipmSlipPrtDiv)
                 && (this.EstimatePrtDiv == target.EstimatePrtDiv)
                 && (this.UOESlipPrtDiv == target.UOESlipPrtDiv)

                 && (this.TotalBillOutputDiv == target.TotalBillOutputDiv)
                 && (this.DetailBillOutputCode == target.DetailBillOutputCode)
                 && (this.SlipTtlBillOutputDiv == target.SlipTtlBillOutputDiv)
                 );
        }

        /// <summary>
        /// ���Ӑ�ꊇ�C���N���X���[�N��r����
        /// </summary>
        /// <param name="customerCustomerChangeResult1">
        ///                    ��r����CustomerCustomerChangeResult�N���X�̃C���X�^���X
        /// </param>
        /// <param name="customerCustomerChangeResult2">��r����CustomerCustomerChangeResult�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerCustomerChangeResult�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(CustomerCustomerChangeResult customerCustomerChangeResult1, CustomerCustomerChangeResult customerCustomerChangeResult2)
        {
            return ((customerCustomerChangeResult1.CreateDateTime == customerCustomerChangeResult2.CreateDateTime)
                 && (customerCustomerChangeResult1.UpdateDateTime == customerCustomerChangeResult2.UpdateDateTime)
                 && (customerCustomerChangeResult1.EnterpriseCode == customerCustomerChangeResult2.EnterpriseCode)
                 && (customerCustomerChangeResult1.FileHeaderGuid == customerCustomerChangeResult2.FileHeaderGuid)
                 && (customerCustomerChangeResult1.UpdEmployeeCode == customerCustomerChangeResult2.UpdEmployeeCode)
                 && (customerCustomerChangeResult1.UpdAssemblyId1 == customerCustomerChangeResult2.UpdAssemblyId1)
                 && (customerCustomerChangeResult1.UpdAssemblyId2 == customerCustomerChangeResult2.UpdAssemblyId2)
                 && (customerCustomerChangeResult1.LogicalDeleteCode == customerCustomerChangeResult2.LogicalDeleteCode)
                 && (customerCustomerChangeResult1.CustomerCode == customerCustomerChangeResult2.CustomerCode)
                 && (customerCustomerChangeResult1.CustomerSubCode == customerCustomerChangeResult2.CustomerSubCode)
                 && (customerCustomerChangeResult1.Name == customerCustomerChangeResult2.Name)
                 && (customerCustomerChangeResult1.Name2 == customerCustomerChangeResult2.Name2)
                 && (customerCustomerChangeResult1.HonorificTitle == customerCustomerChangeResult2.HonorificTitle)
                 && (customerCustomerChangeResult1.Kana == customerCustomerChangeResult2.Kana)
                 && (customerCustomerChangeResult1.CustomerSnm == customerCustomerChangeResult2.CustomerSnm)
                 && (customerCustomerChangeResult1.OutputNameCode == customerCustomerChangeResult2.OutputNameCode)
                 //&& (customerCustomerChangeResult1.OutputName == customerCustomerChangeResult2.OutputName)
                 && (customerCustomerChangeResult1.CorporateDivCode == customerCustomerChangeResult2.CorporateDivCode)
                 && (customerCustomerChangeResult1.CustomerAttributeDiv == customerCustomerChangeResult2.CustomerAttributeDiv)
                 && (customerCustomerChangeResult1.JobTypeCode == customerCustomerChangeResult2.JobTypeCode)
                 && (customerCustomerChangeResult1.JobTypeName == customerCustomerChangeResult2.JobTypeName)
                 && (customerCustomerChangeResult1.BusinessTypeCode == customerCustomerChangeResult2.BusinessTypeCode)
                 && (customerCustomerChangeResult1.BusinessTypeName == customerCustomerChangeResult2.BusinessTypeName)
                 && (customerCustomerChangeResult1.SalesAreaCode == customerCustomerChangeResult2.SalesAreaCode)
                 && (customerCustomerChangeResult1.SalesAreaName == customerCustomerChangeResult2.SalesAreaName)
                 && (customerCustomerChangeResult1.PostNo == customerCustomerChangeResult2.PostNo)
                 && (customerCustomerChangeResult1.Address1 == customerCustomerChangeResult2.Address1)
                 && (customerCustomerChangeResult1.Address3 == customerCustomerChangeResult2.Address3)
                 && (customerCustomerChangeResult1.Address4 == customerCustomerChangeResult2.Address4)
                 && (customerCustomerChangeResult1.HomeTelNo == customerCustomerChangeResult2.HomeTelNo)
                 && (customerCustomerChangeResult1.OfficeTelNo == customerCustomerChangeResult2.OfficeTelNo)
                 && (customerCustomerChangeResult1.PortableTelNo == customerCustomerChangeResult2.PortableTelNo)
                 && (customerCustomerChangeResult1.HomeFaxNo == customerCustomerChangeResult2.HomeFaxNo)
                 && (customerCustomerChangeResult1.OfficeFaxNo == customerCustomerChangeResult2.OfficeFaxNo)
                 && (customerCustomerChangeResult1.OthersTelNo == customerCustomerChangeResult2.OthersTelNo)
                 && (customerCustomerChangeResult1.MainContactCode == customerCustomerChangeResult2.MainContactCode)
                 && (customerCustomerChangeResult1.SearchTelNo == customerCustomerChangeResult2.SearchTelNo)
                 && (customerCustomerChangeResult1.MngSectionCode == customerCustomerChangeResult2.MngSectionCode)
                 && (customerCustomerChangeResult1.MngSectionName == customerCustomerChangeResult2.MngSectionName)
                 && (customerCustomerChangeResult1.InpSectionCode == customerCustomerChangeResult2.InpSectionCode)
                 && (customerCustomerChangeResult1.CustAnalysCode1 == customerCustomerChangeResult2.CustAnalysCode1)
                 && (customerCustomerChangeResult1.CustAnalysCode2 == customerCustomerChangeResult2.CustAnalysCode2)
                 && (customerCustomerChangeResult1.CustAnalysCode3 == customerCustomerChangeResult2.CustAnalysCode3)
                 && (customerCustomerChangeResult1.CustAnalysCode4 == customerCustomerChangeResult2.CustAnalysCode4)
                 && (customerCustomerChangeResult1.CustAnalysCode5 == customerCustomerChangeResult2.CustAnalysCode5)
                 && (customerCustomerChangeResult1.CustAnalysCode6 == customerCustomerChangeResult2.CustAnalysCode6)
                 && (customerCustomerChangeResult1.BillOutputCode == customerCustomerChangeResult2.BillOutputCode)
                 && (customerCustomerChangeResult1.BillOutputName == customerCustomerChangeResult2.BillOutputName)
                 && (customerCustomerChangeResult1.TotalDay == customerCustomerChangeResult2.TotalDay)
                 && (customerCustomerChangeResult1.CollectMoneyCode == customerCustomerChangeResult2.CollectMoneyCode)
                 && (customerCustomerChangeResult1.CollectMoneyName == customerCustomerChangeResult2.CollectMoneyName)
                 && (customerCustomerChangeResult1.CollectMoneyDay == customerCustomerChangeResult2.CollectMoneyDay)
                 && (customerCustomerChangeResult1.CollectCond == customerCustomerChangeResult2.CollectCond)
                 && (customerCustomerChangeResult1.CollectSight == customerCustomerChangeResult2.CollectSight)
                 && (customerCustomerChangeResult1.ClaimCode == customerCustomerChangeResult2.ClaimCode)
                 && (customerCustomerChangeResult1.ClaimName == customerCustomerChangeResult2.ClaimName)
                 && (customerCustomerChangeResult1.ClaimName2 == customerCustomerChangeResult2.ClaimName2)
                 && (customerCustomerChangeResult1.ClaimSnm == customerCustomerChangeResult2.ClaimSnm)
                 && (customerCustomerChangeResult1.TransStopDate == customerCustomerChangeResult2.TransStopDate)
                 && (customerCustomerChangeResult1.DmOutCode == customerCustomerChangeResult2.DmOutCode)
                 && (customerCustomerChangeResult1.DmOutName == customerCustomerChangeResult2.DmOutName)
                 && (customerCustomerChangeResult1.MainSendMailAddrCd == customerCustomerChangeResult2.MainSendMailAddrCd)
                 && (customerCustomerChangeResult1.MailAddrKindCode1 == customerCustomerChangeResult2.MailAddrKindCode1)
                 && (customerCustomerChangeResult1.MailAddrKindName1 == customerCustomerChangeResult2.MailAddrKindName1)
                 && (customerCustomerChangeResult1.MailAddress1 == customerCustomerChangeResult2.MailAddress1)
                 && (customerCustomerChangeResult1.MailSendCode1 == customerCustomerChangeResult2.MailSendCode1)
                 && (customerCustomerChangeResult1.MailSendName1 == customerCustomerChangeResult2.MailSendName1)
                 && (customerCustomerChangeResult1.MailAddrKindCode2 == customerCustomerChangeResult2.MailAddrKindCode2)
                 && (customerCustomerChangeResult1.MailAddrKindName2 == customerCustomerChangeResult2.MailAddrKindName2)
                 && (customerCustomerChangeResult1.MailAddress2 == customerCustomerChangeResult2.MailAddress2)
                 && (customerCustomerChangeResult1.MailSendCode2 == customerCustomerChangeResult2.MailSendCode2)
                 && (customerCustomerChangeResult1.MailSendName2 == customerCustomerChangeResult2.MailSendName2)
                 && (customerCustomerChangeResult1.CustomerAgentCd == customerCustomerChangeResult2.CustomerAgentCd)
                 && (customerCustomerChangeResult1.CustomerAgentNm == customerCustomerChangeResult2.CustomerAgentNm)
                 && (customerCustomerChangeResult1.BillCollecterCd == customerCustomerChangeResult2.BillCollecterCd)
                 && (customerCustomerChangeResult1.OldCustomerAgentCd == customerCustomerChangeResult2.OldCustomerAgentCd)
                 && (customerCustomerChangeResult1.OldCustomerAgentNm == customerCustomerChangeResult2.OldCustomerAgentNm)
                 && (customerCustomerChangeResult1.CustAgentChgDate == customerCustomerChangeResult2.CustAgentChgDate)
                 && (customerCustomerChangeResult1.AcceptWholeSale == customerCustomerChangeResult2.AcceptWholeSale)
                 && (customerCustomerChangeResult1.CreditMngCode == customerCustomerChangeResult2.CreditMngCode)
                 && (customerCustomerChangeResult1.DepoDelCode == customerCustomerChangeResult2.DepoDelCode)
                 && (customerCustomerChangeResult1.AccRecDivCd == customerCustomerChangeResult2.AccRecDivCd)
                 && (customerCustomerChangeResult1.CustSlipNoMngCd == customerCustomerChangeResult2.CustSlipNoMngCd)
                 && (customerCustomerChangeResult1.PureCode == customerCustomerChangeResult2.PureCode)
                 && (customerCustomerChangeResult1.CustCTaXLayRefCd == customerCustomerChangeResult2.CustCTaXLayRefCd)
                 && (customerCustomerChangeResult1.ConsTaxLayMethod == customerCustomerChangeResult2.ConsTaxLayMethod)
                 && (customerCustomerChangeResult1.TotalAmountDispWayCd == customerCustomerChangeResult2.TotalAmountDispWayCd)
                 && (customerCustomerChangeResult1.TotalAmntDspWayRef == customerCustomerChangeResult2.TotalAmntDspWayRef)
                 && (customerCustomerChangeResult1.AccountNoInfo1 == customerCustomerChangeResult2.AccountNoInfo1)
                 && (customerCustomerChangeResult1.AccountNoInfo2 == customerCustomerChangeResult2.AccountNoInfo2)
                 && (customerCustomerChangeResult1.AccountNoInfo3 == customerCustomerChangeResult2.AccountNoInfo3)
                 && (customerCustomerChangeResult1.SalesUnPrcFrcProcCd == customerCustomerChangeResult2.SalesUnPrcFrcProcCd)
                 && (customerCustomerChangeResult1.SalesMoneyFrcProcCd == customerCustomerChangeResult2.SalesMoneyFrcProcCd)
                 && (customerCustomerChangeResult1.SalesCnsTaxFrcProcCd == customerCustomerChangeResult2.SalesCnsTaxFrcProcCd)
                 && (customerCustomerChangeResult1.CustomerSlipNoDiv == customerCustomerChangeResult2.CustomerSlipNoDiv)
                 && (customerCustomerChangeResult1.NTimeCalcStDate == customerCustomerChangeResult2.NTimeCalcStDate)
                 && (customerCustomerChangeResult1.CustomerAgent == customerCustomerChangeResult2.CustomerAgent)
                 && (customerCustomerChangeResult1.ClaimSectionCode == customerCustomerChangeResult2.ClaimSectionCode)
                 && (customerCustomerChangeResult1.ClaimSectionName == customerCustomerChangeResult2.ClaimSectionName)
                 && (customerCustomerChangeResult1.CarMngDivCd == customerCustomerChangeResult2.CarMngDivCd)
                 && (customerCustomerChangeResult1.BillPartsNoPrtCd == customerCustomerChangeResult2.BillPartsNoPrtCd)
                 && (customerCustomerChangeResult1.DeliPartsNoPrtCd == customerCustomerChangeResult2.DeliPartsNoPrtCd)
                 && (customerCustomerChangeResult1.DefSalesSlipCd == customerCustomerChangeResult2.DefSalesSlipCd)
                 && (customerCustomerChangeResult1.LavorRateRank == customerCustomerChangeResult2.LavorRateRank)
                 && (customerCustomerChangeResult1.SlipTtlPrn == customerCustomerChangeResult2.SlipTtlPrn)
                 && (customerCustomerChangeResult1.DepoBankCode == customerCustomerChangeResult2.DepoBankCode)
                 && (customerCustomerChangeResult1.DepoBankName == customerCustomerChangeResult2.DepoBankName)
                 && (customerCustomerChangeResult1.CustWarehouseCd == customerCustomerChangeResult2.CustWarehouseCd)
                 && (customerCustomerChangeResult1.CustWarehouseName == customerCustomerChangeResult2.CustWarehouseName)
                 && (customerCustomerChangeResult1.QrcodePrtCd == customerCustomerChangeResult2.QrcodePrtCd)
                 && (customerCustomerChangeResult1.DeliHonorificTtl == customerCustomerChangeResult2.DeliHonorificTtl)
                 && (customerCustomerChangeResult1.BillHonorificTtl == customerCustomerChangeResult2.BillHonorificTtl)
                 && (customerCustomerChangeResult1.EstmHonorificTtl == customerCustomerChangeResult2.EstmHonorificTtl)
                 && (customerCustomerChangeResult1.RectHonorificTtl == customerCustomerChangeResult2.RectHonorificTtl)
                 && (customerCustomerChangeResult1.DeliHonorTtlPrtDiv == customerCustomerChangeResult2.DeliHonorTtlPrtDiv)
                 && (customerCustomerChangeResult1.BillHonorTtlPrtDiv == customerCustomerChangeResult2.BillHonorTtlPrtDiv)
                 && (customerCustomerChangeResult1.EstmHonorTtlPrtDiv == customerCustomerChangeResult2.EstmHonorTtlPrtDiv)
                 && (customerCustomerChangeResult1.RectHonorTtlPrtDiv == customerCustomerChangeResult2.RectHonorTtlPrtDiv)
                 && (customerCustomerChangeResult1.Note1 == customerCustomerChangeResult2.Note1)
                 && (customerCustomerChangeResult1.Note2 == customerCustomerChangeResult2.Note2)
                 && (customerCustomerChangeResult1.Note3 == customerCustomerChangeResult2.Note3)
                 && (customerCustomerChangeResult1.Note4 == customerCustomerChangeResult2.Note4)
                 && (customerCustomerChangeResult1.Note5 == customerCustomerChangeResult2.Note5)
                 && (customerCustomerChangeResult1.Note6 == customerCustomerChangeResult2.Note6)
                 && (customerCustomerChangeResult1.Note7 == customerCustomerChangeResult2.Note7)
                 && (customerCustomerChangeResult1.Note8 == customerCustomerChangeResult2.Note8)
                 && (customerCustomerChangeResult1.Note9 == customerCustomerChangeResult2.Note9)
                 && (customerCustomerChangeResult1.Note10 == customerCustomerChangeResult2.Note10)
                 && (customerCustomerChangeResult1.CreditMoney == customerCustomerChangeResult2.CreditMoney)
                 && (customerCustomerChangeResult1.WarningCreditMoney == customerCustomerChangeResult2.WarningCreditMoney)
                 && (customerCustomerChangeResult1.PrsntAccRecBalance == customerCustomerChangeResult2.PrsntAccRecBalance)
                 && (customerCustomerChangeResult1.RateGPureCode == customerCustomerChangeResult2.RateGPureCode)
                 && (customerCustomerChangeResult1.GoodsMakerCd == customerCustomerChangeResult2.GoodsMakerCd)
                 && (customerCustomerChangeResult1.CustRateGrpCode == customerCustomerChangeResult2.CustRateGrpCode)
                 && (customerCustomerChangeResult1.EnterpriseName == customerCustomerChangeResult2.EnterpriseName)
                 && (customerCustomerChangeResult1.UpdEmployeeName == customerCustomerChangeResult2.UpdEmployeeName)
                 && (customerCustomerChangeResult1.InpSectionName == customerCustomerChangeResult2.InpSectionName)
                 && (customerCustomerChangeResult1.BillOutPutCodeNm == customerCustomerChangeResult2.BillOutPutCodeNm)
                 //&& (customerCustomerChangeResult1.BillCollecterNm == customerCustomerChangeResult2.BillCollecterNm)
                 && (customerCustomerChangeResult1.ReceiptOutputCode == customerCustomerChangeResult2.ReceiptOutputCode)

                 && (customerCustomerChangeResult1.SalesSlipPrtDiv == customerCustomerChangeResult2.SalesSlipPrtDiv)
                 && (customerCustomerChangeResult1.AcpOdrrSlipPrtDiv == customerCustomerChangeResult2.AcpOdrrSlipPrtDiv)
                 && (customerCustomerChangeResult1.ShipmSlipPrtDiv == customerCustomerChangeResult2.ShipmSlipPrtDiv)
                 && (customerCustomerChangeResult1.EstimatePrtDiv == customerCustomerChangeResult2.EstimatePrtDiv)
                 && (customerCustomerChangeResult1.UOESlipPrtDiv == customerCustomerChangeResult2.UOESlipPrtDiv)

                 && (customerCustomerChangeResult1.TotalBillOutputDiv == customerCustomerChangeResult2.TotalBillOutputDiv)
                 && (customerCustomerChangeResult1.DetailBillOutputCode == customerCustomerChangeResult2.DetailBillOutputCode)
                 && (customerCustomerChangeResult1.SlipTtlBillOutputDiv == customerCustomerChangeResult2.SlipTtlBillOutputDiv)
                 );
        }
        /// <summary>
        /// ���Ӑ�ꊇ�C���N���X���[�N��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CustomerCustomerChangeResult�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerCustomerChangeResult�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(CustomerCustomerChangeResult target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustomerSubCode != target.CustomerSubCode) resList.Add("CustomerSubCode");
            if (this.Name != target.Name) resList.Add("Name");
            if (this.Name2 != target.Name2) resList.Add("Name2");
            if (this.HonorificTitle != target.HonorificTitle) resList.Add("HonorificTitle");
            if (this.Kana != target.Kana) resList.Add("Kana");
            if (this.CustomerSnm != target.CustomerSnm) resList.Add("CustomerSnm");
            if (this.OutputNameCode != target.OutputNameCode) resList.Add("OutputNameCode");
            if (this.OutputName != target.OutputName) resList.Add("OutputName");
            if (this.CorporateDivCode != target.CorporateDivCode) resList.Add("CorporateDivCode");
            if (this.CustomerAttributeDiv != target.CustomerAttributeDiv) resList.Add("CustomerAttributeDiv");
            if (this.JobTypeCode != target.JobTypeCode) resList.Add("JobTypeCode");
            if (this.JobTypeName != target.JobTypeName) resList.Add("JobTypeName");
            if (this.BusinessTypeCode != target.BusinessTypeCode) resList.Add("BusinessTypeCode");
            if (this.BusinessTypeName != target.BusinessTypeName) resList.Add("BusinessTypeName");
            if (this.SalesAreaCode != target.SalesAreaCode) resList.Add("SalesAreaCode");
            if (this.SalesAreaName != target.SalesAreaName) resList.Add("SalesAreaName");
            if (this.PostNo != target.PostNo) resList.Add("PostNo");
            if (this.Address1 != target.Address1) resList.Add("Address1");
            if (this.Address3 != target.Address3) resList.Add("Address3");
            if (this.Address4 != target.Address4) resList.Add("Address4");
            if (this.HomeTelNo != target.HomeTelNo) resList.Add("HomeTelNo");
            if (this.OfficeTelNo != target.OfficeTelNo) resList.Add("OfficeTelNo");
            if (this.PortableTelNo != target.PortableTelNo) resList.Add("PortableTelNo");
            if (this.HomeFaxNo != target.HomeFaxNo) resList.Add("HomeFaxNo");
            if (this.OfficeFaxNo != target.OfficeFaxNo) resList.Add("OfficeFaxNo");
            if (this.OthersTelNo != target.OthersTelNo) resList.Add("OthersTelNo");
            if (this.MainContactCode != target.MainContactCode) resList.Add("MainContactCode");
            if (this.SearchTelNo != target.SearchTelNo) resList.Add("SearchTelNo");
            if (this.MngSectionCode != target.MngSectionCode) resList.Add("MngSectionCode");
            if (this.MngSectionName != target.MngSectionName) resList.Add("MngSectionName");
            if (this.InpSectionCode != target.InpSectionCode) resList.Add("InpSectionCode");
            if (this.CustAnalysCode1 != target.CustAnalysCode1) resList.Add("CustAnalysCode1");
            if (this.CustAnalysCode2 != target.CustAnalysCode2) resList.Add("CustAnalysCode2");
            if (this.CustAnalysCode3 != target.CustAnalysCode3) resList.Add("CustAnalysCode3");
            if (this.CustAnalysCode4 != target.CustAnalysCode4) resList.Add("CustAnalysCode4");
            if (this.CustAnalysCode5 != target.CustAnalysCode5) resList.Add("CustAnalysCode5");
            if (this.CustAnalysCode6 != target.CustAnalysCode6) resList.Add("CustAnalysCode6");
            if (this.BillOutputCode != target.BillOutputCode) resList.Add("BillOutputCode");
            if (this.BillOutputName != target.BillOutputName) resList.Add("BillOutputName");
            if (this.TotalDay != target.TotalDay) resList.Add("TotalDay");
            if (this.CollectMoneyCode != target.CollectMoneyCode) resList.Add("CollectMoneyCode");
            if (this.CollectMoneyName != target.CollectMoneyName) resList.Add("CollectMoneyName");
            if (this.CollectMoneyDay != target.CollectMoneyDay) resList.Add("CollectMoneyDay");
            if (this.CollectCond != target.CollectCond) resList.Add("CollectCond");
            if (this.CollectSight != target.CollectSight) resList.Add("CollectSight");
            if (this.ClaimCode != target.ClaimCode) resList.Add("ClaimCode");
            if (this.ClaimName != target.ClaimName) resList.Add("ClaimName");
            if (this.ClaimName2 != target.ClaimName2) resList.Add("ClaimName2");
            if (this.ClaimSnm != target.ClaimSnm) resList.Add("ClaimSnm");
            if (this.TransStopDate != target.TransStopDate) resList.Add("TransStopDate");
            if (this.DmOutCode != target.DmOutCode) resList.Add("DmOutCode");
            if (this.DmOutName != target.DmOutName) resList.Add("DmOutName");
            if (this.MainSendMailAddrCd != target.MainSendMailAddrCd) resList.Add("MainSendMailAddrCd");
            if (this.MailAddrKindCode1 != target.MailAddrKindCode1) resList.Add("MailAddrKindCode1");
            if (this.MailAddrKindName1 != target.MailAddrKindName1) resList.Add("MailAddrKindName1");
            if (this.MailAddress1 != target.MailAddress1) resList.Add("MailAddress1");
            if (this.MailSendCode1 != target.MailSendCode1) resList.Add("MailSendCode1");
            if (this.MailSendName1 != target.MailSendName1) resList.Add("MailSendName1");
            if (this.MailAddrKindCode2 != target.MailAddrKindCode2) resList.Add("MailAddrKindCode2");
            if (this.MailAddrKindName2 != target.MailAddrKindName2) resList.Add("MailAddrKindName2");
            if (this.MailAddress2 != target.MailAddress2) resList.Add("MailAddress2");
            if (this.MailSendCode2 != target.MailSendCode2) resList.Add("MailSendCode2");
            if (this.MailSendName2 != target.MailSendName2) resList.Add("MailSendName2");
            if (this.CustomerAgentCd != target.CustomerAgentCd) resList.Add("CustomerAgentCd");
            if (this.CustomerAgentNm != target.CustomerAgentNm) resList.Add("CustomerAgentNm");
            if (this.BillCollecterCd != target.BillCollecterCd) resList.Add("BillCollecterCd");
            if (this.OldCustomerAgentCd != target.OldCustomerAgentCd) resList.Add("OldCustomerAgentCd");
            if (this.OldCustomerAgentNm != target.OldCustomerAgentNm) resList.Add("OldCustomerAgentNm");
            if (this.CustAgentChgDate != target.CustAgentChgDate) resList.Add("CustAgentChgDate");
            if (this.AcceptWholeSale != target.AcceptWholeSale) resList.Add("AcceptWholeSale");
            if (this.CreditMngCode != target.CreditMngCode) resList.Add("CreditMngCode");
            if (this.DepoDelCode != target.DepoDelCode) resList.Add("DepoDelCode");
            if (this.AccRecDivCd != target.AccRecDivCd) resList.Add("AccRecDivCd");
            if (this.CustSlipNoMngCd != target.CustSlipNoMngCd) resList.Add("CustSlipNoMngCd");
            if (this.PureCode != target.PureCode) resList.Add("PureCode");
            if (this.CustCTaXLayRefCd != target.CustCTaXLayRefCd) resList.Add("CustCTaXLayRefCd");
            if (this.ConsTaxLayMethod != target.ConsTaxLayMethod) resList.Add("ConsTaxLayMethod");
            if (this.TotalAmountDispWayCd != target.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
            if (this.TotalAmntDspWayRef != target.TotalAmntDspWayRef) resList.Add("TotalAmntDspWayRef");
            if (this.AccountNoInfo1 != target.AccountNoInfo1) resList.Add("AccountNoInfo1");
            if (this.AccountNoInfo2 != target.AccountNoInfo2) resList.Add("AccountNoInfo2");
            if (this.AccountNoInfo3 != target.AccountNoInfo3) resList.Add("AccountNoInfo3");
            if (this.SalesUnPrcFrcProcCd != target.SalesUnPrcFrcProcCd) resList.Add("SalesUnPrcFrcProcCd");
            if (this.SalesMoneyFrcProcCd != target.SalesMoneyFrcProcCd) resList.Add("SalesMoneyFrcProcCd");
            if (this.SalesCnsTaxFrcProcCd != target.SalesCnsTaxFrcProcCd) resList.Add("SalesCnsTaxFrcProcCd");
            if (this.CustomerSlipNoDiv != target.CustomerSlipNoDiv) resList.Add("CustomerSlipNoDiv");
            if (this.NTimeCalcStDate != target.NTimeCalcStDate) resList.Add("NTimeCalcStDate");
            if (this.CustomerAgent != target.CustomerAgent) resList.Add("CustomerAgent");
            if (this.ClaimSectionCode != target.ClaimSectionCode) resList.Add("ClaimSectionCode");
            if (this.ClaimSectionName != target.ClaimSectionName) resList.Add("ClaimSectionName");
            if (this.CarMngDivCd != target.CarMngDivCd) resList.Add("CarMngDivCd");
            if (this.BillPartsNoPrtCd != target.BillPartsNoPrtCd) resList.Add("BillPartsNoPrtCd");
            if (this.DeliPartsNoPrtCd != target.DeliPartsNoPrtCd) resList.Add("DeliPartsNoPrtCd");
            if (this.DefSalesSlipCd != target.DefSalesSlipCd) resList.Add("DefSalesSlipCd");
            if (this.LavorRateRank != target.LavorRateRank) resList.Add("LavorRateRank");
            if (this.SlipTtlPrn != target.SlipTtlPrn) resList.Add("SlipTtlPrn");
            if (this.DepoBankCode != target.DepoBankCode) resList.Add("DepoBankCode");
            if (this.DepoBankName != target.DepoBankName) resList.Add("DepoBankName");
            if (this.CustWarehouseCd != target.CustWarehouseCd) resList.Add("CustWarehouseCd");
            if (this.CustWarehouseName != target.CustWarehouseName) resList.Add("CustWarehouseName");
            if (this.QrcodePrtCd != target.QrcodePrtCd) resList.Add("QrcodePrtCd");
            if (this.DeliHonorificTtl != target.DeliHonorificTtl) resList.Add("DeliHonorificTtl");
            if (this.BillHonorificTtl != target.BillHonorificTtl) resList.Add("BillHonorificTtl");
            if (this.EstmHonorificTtl != target.EstmHonorificTtl) resList.Add("EstmHonorificTtl");
            if (this.RectHonorificTtl != target.RectHonorificTtl) resList.Add("RectHonorificTtl");
            if (this.DeliHonorTtlPrtDiv != target.DeliHonorTtlPrtDiv) resList.Add("DeliHonorTtlPrtDiv");
            if (this.BillHonorTtlPrtDiv != target.BillHonorTtlPrtDiv) resList.Add("BillHonorTtlPrtDiv");
            if (this.EstmHonorTtlPrtDiv != target.EstmHonorTtlPrtDiv) resList.Add("EstmHonorTtlPrtDiv");
            if (this.RectHonorTtlPrtDiv != target.RectHonorTtlPrtDiv) resList.Add("RectHonorTtlPrtDiv");
            if (this.Note1 != target.Note1) resList.Add("Note1");
            if (this.Note2 != target.Note2) resList.Add("Note2");
            if (this.Note3 != target.Note3) resList.Add("Note3");
            if (this.Note4 != target.Note4) resList.Add("Note4");
            if (this.Note5 != target.Note5) resList.Add("Note5");
            if (this.Note6 != target.Note6) resList.Add("Note6");
            if (this.Note7 != target.Note7) resList.Add("Note7");
            if (this.Note8 != target.Note8) resList.Add("Note8");
            if (this.Note9 != target.Note9) resList.Add("Note9");
            if (this.Note10 != target.Note10) resList.Add("Note10");
            if (this.CreditMoney != target.CreditMoney) resList.Add("CreditMoney");
            if (this.WarningCreditMoney != target.WarningCreditMoney) resList.Add("WarningCreditMoney");
            if (this.PrsntAccRecBalance != target.PrsntAccRecBalance) resList.Add("PrsntAccRecBalance");
            if (this.RateGPureCode != target.RateGPureCode) resList.Add("RateGPureCode");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.CustRateGrpCode != target.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.InpSectionName != target.InpSectionName) resList.Add("InpSectionName");
            if (this.BillOutPutCodeNm != target.BillOutPutCodeNm) resList.Add("BillOutPutCodeNm");
            if (this.BillCollecterNm != target.BillCollecterNm) resList.Add("BillCollecterNm");
            if (this.ReceiptOutputCode != target.ReceiptOutputCode) resList.Add("ReceiptOutputCode");

            if (this.SalesSlipPrtDiv != target.SalesSlipPrtDiv) resList.Add("SalesSlipPrtDiv");
            if (this.AcpOdrrSlipPrtDiv != target.AcpOdrrSlipPrtDiv) resList.Add("AcpOdrrSlipPrtDiv");
            if (this.ShipmSlipPrtDiv != target.ShipmSlipPrtDiv) resList.Add("ShipmSlipPrtDiv");
            if (this.EstimatePrtDiv != target.EstimatePrtDiv) resList.Add("EstimatePrtDiv");
            if (this.UOESlipPrtDiv != target.UOESlipPrtDiv) resList.Add("UOESlipPrtDiv");

            if (this.TotalBillOutputDiv != target.TotalBillOutputDiv) resList.Add("TotalBillOutputDiv");
            if (this.DetailBillOutputCode != target.DetailBillOutputCode) resList.Add("DetailBillOutputCode");
            if (this.SlipTtlBillOutputDiv != target.SlipTtlBillOutputDiv) resList.Add("SlipTtlBillOutputDiv");

            return resList;
        }

        /// <summary>
        /// ���Ӑ�ꊇ�C���N���X���[�N��r����
        /// </summary>
        /// <param name="customerCustomerChangeResult1">��r����CustomerCustomerChangeResult�N���X�̃C���X�^���X</param>
        /// <param name="customerCustomerChangeResult2">��r����CustomerCustomerChangeResult�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerCustomerChangeResult�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(CustomerCustomerChangeResult customerCustomerChangeResult1, CustomerCustomerChangeResult customerCustomerChangeResult2)
        {
            ArrayList resList = new ArrayList();
            if (customerCustomerChangeResult1.CreateDateTime != customerCustomerChangeResult2.CreateDateTime) resList.Add("CreateDateTime");
            if (customerCustomerChangeResult1.UpdateDateTime != customerCustomerChangeResult2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (customerCustomerChangeResult1.EnterpriseCode != customerCustomerChangeResult2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (customerCustomerChangeResult1.FileHeaderGuid != customerCustomerChangeResult2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (customerCustomerChangeResult1.UpdEmployeeCode != customerCustomerChangeResult2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (customerCustomerChangeResult1.UpdAssemblyId1 != customerCustomerChangeResult2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (customerCustomerChangeResult1.UpdAssemblyId2 != customerCustomerChangeResult2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (customerCustomerChangeResult1.LogicalDeleteCode != customerCustomerChangeResult2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (customerCustomerChangeResult1.CustomerCode != customerCustomerChangeResult2.CustomerCode) resList.Add("CustomerCode");
            if (customerCustomerChangeResult1.CustomerSubCode != customerCustomerChangeResult2.CustomerSubCode) resList.Add("CustomerSubCode");
            if (customerCustomerChangeResult1.Name != customerCustomerChangeResult2.Name) resList.Add("Name");
            if (customerCustomerChangeResult1.Name2 != customerCustomerChangeResult2.Name2) resList.Add("Name2");
            if (customerCustomerChangeResult1.HonorificTitle != customerCustomerChangeResult2.HonorificTitle) resList.Add("HonorificTitle");
            if (customerCustomerChangeResult1.Kana != customerCustomerChangeResult2.Kana) resList.Add("Kana");
            if (customerCustomerChangeResult1.CustomerSnm != customerCustomerChangeResult2.CustomerSnm) resList.Add("CustomerSnm");
            if (customerCustomerChangeResult1.OutputNameCode != customerCustomerChangeResult2.OutputNameCode) resList.Add("OutputNameCode");
            if (customerCustomerChangeResult1.OutputName != customerCustomerChangeResult2.OutputName) resList.Add("OutputName");
            if (customerCustomerChangeResult1.CorporateDivCode != customerCustomerChangeResult2.CorporateDivCode) resList.Add("CorporateDivCode");
            if (customerCustomerChangeResult1.CustomerAttributeDiv != customerCustomerChangeResult2.CustomerAttributeDiv) resList.Add("CustomerAttributeDiv");
            if (customerCustomerChangeResult1.JobTypeCode != customerCustomerChangeResult2.JobTypeCode) resList.Add("JobTypeCode");
            if (customerCustomerChangeResult1.JobTypeName != customerCustomerChangeResult2.JobTypeName) resList.Add("JobTypeName");
            if (customerCustomerChangeResult1.BusinessTypeCode != customerCustomerChangeResult2.BusinessTypeCode) resList.Add("BusinessTypeCode");
            if (customerCustomerChangeResult1.BusinessTypeName != customerCustomerChangeResult2.BusinessTypeName) resList.Add("BusinessTypeName");
            if (customerCustomerChangeResult1.SalesAreaCode != customerCustomerChangeResult2.SalesAreaCode) resList.Add("SalesAreaCode");
            if (customerCustomerChangeResult1.SalesAreaName != customerCustomerChangeResult2.SalesAreaName) resList.Add("SalesAreaName");
            if (customerCustomerChangeResult1.PostNo != customerCustomerChangeResult2.PostNo) resList.Add("PostNo");
            if (customerCustomerChangeResult1.Address1 != customerCustomerChangeResult2.Address1) resList.Add("Address1");
            if (customerCustomerChangeResult1.Address3 != customerCustomerChangeResult2.Address3) resList.Add("Address3");
            if (customerCustomerChangeResult1.Address4 != customerCustomerChangeResult2.Address4) resList.Add("Address4");
            if (customerCustomerChangeResult1.HomeTelNo != customerCustomerChangeResult2.HomeTelNo) resList.Add("HomeTelNo");
            if (customerCustomerChangeResult1.OfficeTelNo != customerCustomerChangeResult2.OfficeTelNo) resList.Add("OfficeTelNo");
            if (customerCustomerChangeResult1.PortableTelNo != customerCustomerChangeResult2.PortableTelNo) resList.Add("PortableTelNo");
            if (customerCustomerChangeResult1.HomeFaxNo != customerCustomerChangeResult2.HomeFaxNo) resList.Add("HomeFaxNo");
            if (customerCustomerChangeResult1.OfficeFaxNo != customerCustomerChangeResult2.OfficeFaxNo) resList.Add("OfficeFaxNo");
            if (customerCustomerChangeResult1.OthersTelNo != customerCustomerChangeResult2.OthersTelNo) resList.Add("OthersTelNo");
            if (customerCustomerChangeResult1.MainContactCode != customerCustomerChangeResult2.MainContactCode) resList.Add("MainContactCode");
            if (customerCustomerChangeResult1.SearchTelNo != customerCustomerChangeResult2.SearchTelNo) resList.Add("SearchTelNo");
            if (customerCustomerChangeResult1.MngSectionCode != customerCustomerChangeResult2.MngSectionCode) resList.Add("MngSectionCode");
            if (customerCustomerChangeResult1.MngSectionName != customerCustomerChangeResult2.MngSectionName) resList.Add("MngSectionName");
            if (customerCustomerChangeResult1.InpSectionCode != customerCustomerChangeResult2.InpSectionCode) resList.Add("InpSectionCode");
            if (customerCustomerChangeResult1.CustAnalysCode1 != customerCustomerChangeResult2.CustAnalysCode1) resList.Add("CustAnalysCode1");
            if (customerCustomerChangeResult1.CustAnalysCode2 != customerCustomerChangeResult2.CustAnalysCode2) resList.Add("CustAnalysCode2");
            if (customerCustomerChangeResult1.CustAnalysCode3 != customerCustomerChangeResult2.CustAnalysCode3) resList.Add("CustAnalysCode3");
            if (customerCustomerChangeResult1.CustAnalysCode4 != customerCustomerChangeResult2.CustAnalysCode4) resList.Add("CustAnalysCode4");
            if (customerCustomerChangeResult1.CustAnalysCode5 != customerCustomerChangeResult2.CustAnalysCode5) resList.Add("CustAnalysCode5");
            if (customerCustomerChangeResult1.CustAnalysCode6 != customerCustomerChangeResult2.CustAnalysCode6) resList.Add("CustAnalysCode6");
            if (customerCustomerChangeResult1.BillOutputCode != customerCustomerChangeResult2.BillOutputCode) resList.Add("BillOutputCode");
            if (customerCustomerChangeResult1.BillOutputName != customerCustomerChangeResult2.BillOutputName) resList.Add("BillOutputName");
            if (customerCustomerChangeResult1.TotalDay != customerCustomerChangeResult2.TotalDay) resList.Add("TotalDay");
            if (customerCustomerChangeResult1.CollectMoneyCode != customerCustomerChangeResult2.CollectMoneyCode) resList.Add("CollectMoneyCode");
            if (customerCustomerChangeResult1.CollectMoneyName != customerCustomerChangeResult2.CollectMoneyName) resList.Add("CollectMoneyName");
            if (customerCustomerChangeResult1.CollectMoneyDay != customerCustomerChangeResult2.CollectMoneyDay) resList.Add("CollectMoneyDay");
            if (customerCustomerChangeResult1.CollectCond != customerCustomerChangeResult2.CollectCond) resList.Add("CollectCond");
            if (customerCustomerChangeResult1.CollectSight != customerCustomerChangeResult2.CollectSight) resList.Add("CollectSight");
            if (customerCustomerChangeResult1.ClaimCode != customerCustomerChangeResult2.ClaimCode) resList.Add("ClaimCode");
            if (customerCustomerChangeResult1.ClaimName != customerCustomerChangeResult2.ClaimName) resList.Add("ClaimName");
            if (customerCustomerChangeResult1.ClaimName2 != customerCustomerChangeResult2.ClaimName2) resList.Add("ClaimName2");
            if (customerCustomerChangeResult1.ClaimSnm != customerCustomerChangeResult2.ClaimSnm) resList.Add("ClaimSnm");
            if (customerCustomerChangeResult1.TransStopDate != customerCustomerChangeResult2.TransStopDate) resList.Add("TransStopDate");
            if (customerCustomerChangeResult1.DmOutCode != customerCustomerChangeResult2.DmOutCode) resList.Add("DmOutCode");
            if (customerCustomerChangeResult1.DmOutName != customerCustomerChangeResult2.DmOutName) resList.Add("DmOutName");
            if (customerCustomerChangeResult1.MainSendMailAddrCd != customerCustomerChangeResult2.MainSendMailAddrCd) resList.Add("MainSendMailAddrCd");
            if (customerCustomerChangeResult1.MailAddrKindCode1 != customerCustomerChangeResult2.MailAddrKindCode1) resList.Add("MailAddrKindCode1");
            if (customerCustomerChangeResult1.MailAddrKindName1 != customerCustomerChangeResult2.MailAddrKindName1) resList.Add("MailAddrKindName1");
            if (customerCustomerChangeResult1.MailAddress1 != customerCustomerChangeResult2.MailAddress1) resList.Add("MailAddress1");
            if (customerCustomerChangeResult1.MailSendCode1 != customerCustomerChangeResult2.MailSendCode1) resList.Add("MailSendCode1");
            if (customerCustomerChangeResult1.MailSendName1 != customerCustomerChangeResult2.MailSendName1) resList.Add("MailSendName1");
            if (customerCustomerChangeResult1.MailAddrKindCode2 != customerCustomerChangeResult2.MailAddrKindCode2) resList.Add("MailAddrKindCode2");
            if (customerCustomerChangeResult1.MailAddrKindName2 != customerCustomerChangeResult2.MailAddrKindName2) resList.Add("MailAddrKindName2");
            if (customerCustomerChangeResult1.MailAddress2 != customerCustomerChangeResult2.MailAddress2) resList.Add("MailAddress2");
            if (customerCustomerChangeResult1.MailSendCode2 != customerCustomerChangeResult2.MailSendCode2) resList.Add("MailSendCode2");
            if (customerCustomerChangeResult1.MailSendName2 != customerCustomerChangeResult2.MailSendName2) resList.Add("MailSendName2");
            if (customerCustomerChangeResult1.CustomerAgentCd != customerCustomerChangeResult2.CustomerAgentCd) resList.Add("CustomerAgentCd");
            if (customerCustomerChangeResult1.CustomerAgentNm != customerCustomerChangeResult2.CustomerAgentNm) resList.Add("CustomerAgentNm");
            if (customerCustomerChangeResult1.BillCollecterCd != customerCustomerChangeResult2.BillCollecterCd) resList.Add("BillCollecterCd");
            if (customerCustomerChangeResult1.OldCustomerAgentCd != customerCustomerChangeResult2.OldCustomerAgentCd) resList.Add("OldCustomerAgentCd");
            if (customerCustomerChangeResult1.OldCustomerAgentNm != customerCustomerChangeResult2.OldCustomerAgentNm) resList.Add("OldCustomerAgentNm");
            if (customerCustomerChangeResult1.CustAgentChgDate != customerCustomerChangeResult2.CustAgentChgDate) resList.Add("CustAgentChgDate");
            if (customerCustomerChangeResult1.AcceptWholeSale != customerCustomerChangeResult2.AcceptWholeSale) resList.Add("AcceptWholeSale");
            if (customerCustomerChangeResult1.CreditMngCode != customerCustomerChangeResult2.CreditMngCode) resList.Add("CreditMngCode");
            if (customerCustomerChangeResult1.DepoDelCode != customerCustomerChangeResult2.DepoDelCode) resList.Add("DepoDelCode");
            if (customerCustomerChangeResult1.AccRecDivCd != customerCustomerChangeResult2.AccRecDivCd) resList.Add("AccRecDivCd");
            if (customerCustomerChangeResult1.CustSlipNoMngCd != customerCustomerChangeResult2.CustSlipNoMngCd) resList.Add("CustSlipNoMngCd");
            if (customerCustomerChangeResult1.PureCode != customerCustomerChangeResult2.PureCode) resList.Add("PureCode");
            if (customerCustomerChangeResult1.CustCTaXLayRefCd != customerCustomerChangeResult2.CustCTaXLayRefCd) resList.Add("CustCTaXLayRefCd");
            if (customerCustomerChangeResult1.ConsTaxLayMethod != customerCustomerChangeResult2.ConsTaxLayMethod) resList.Add("ConsTaxLayMethod");
            if (customerCustomerChangeResult1.TotalAmountDispWayCd != customerCustomerChangeResult2.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
            if (customerCustomerChangeResult1.TotalAmntDspWayRef != customerCustomerChangeResult2.TotalAmntDspWayRef) resList.Add("TotalAmntDspWayRef");
            if (customerCustomerChangeResult1.AccountNoInfo1 != customerCustomerChangeResult2.AccountNoInfo1) resList.Add("AccountNoInfo1");
            if (customerCustomerChangeResult1.AccountNoInfo2 != customerCustomerChangeResult2.AccountNoInfo2) resList.Add("AccountNoInfo2");
            if (customerCustomerChangeResult1.AccountNoInfo3 != customerCustomerChangeResult2.AccountNoInfo3) resList.Add("AccountNoInfo3");
            if (customerCustomerChangeResult1.SalesUnPrcFrcProcCd != customerCustomerChangeResult2.SalesUnPrcFrcProcCd) resList.Add("SalesUnPrcFrcProcCd");
            if (customerCustomerChangeResult1.SalesMoneyFrcProcCd != customerCustomerChangeResult2.SalesMoneyFrcProcCd) resList.Add("SalesMoneyFrcProcCd");
            if (customerCustomerChangeResult1.SalesCnsTaxFrcProcCd != customerCustomerChangeResult2.SalesCnsTaxFrcProcCd) resList.Add("SalesCnsTaxFrcProcCd");
            if (customerCustomerChangeResult1.CustomerSlipNoDiv != customerCustomerChangeResult2.CustomerSlipNoDiv) resList.Add("CustomerSlipNoDiv");
            if (customerCustomerChangeResult1.NTimeCalcStDate != customerCustomerChangeResult2.NTimeCalcStDate) resList.Add("NTimeCalcStDate");
            if (customerCustomerChangeResult1.CustomerAgent != customerCustomerChangeResult2.CustomerAgent) resList.Add("CustomerAgent");
            if (customerCustomerChangeResult1.ClaimSectionCode != customerCustomerChangeResult2.ClaimSectionCode) resList.Add("ClaimSectionCode");
            if (customerCustomerChangeResult1.ClaimSectionName != customerCustomerChangeResult2.ClaimSectionName) resList.Add("ClaimSectionName");
            if (customerCustomerChangeResult1.CarMngDivCd != customerCustomerChangeResult2.CarMngDivCd) resList.Add("CarMngDivCd");
            if (customerCustomerChangeResult1.BillPartsNoPrtCd != customerCustomerChangeResult2.BillPartsNoPrtCd) resList.Add("BillPartsNoPrtCd");
            if (customerCustomerChangeResult1.DeliPartsNoPrtCd != customerCustomerChangeResult2.DeliPartsNoPrtCd) resList.Add("DeliPartsNoPrtCd");
            if (customerCustomerChangeResult1.DefSalesSlipCd != customerCustomerChangeResult2.DefSalesSlipCd) resList.Add("DefSalesSlipCd");
            if (customerCustomerChangeResult1.LavorRateRank != customerCustomerChangeResult2.LavorRateRank) resList.Add("LavorRateRank");
            if (customerCustomerChangeResult1.SlipTtlPrn != customerCustomerChangeResult2.SlipTtlPrn) resList.Add("SlipTtlPrn");
            if (customerCustomerChangeResult1.DepoBankCode != customerCustomerChangeResult2.DepoBankCode) resList.Add("DepoBankCode");
            if (customerCustomerChangeResult1.DepoBankName != customerCustomerChangeResult2.DepoBankName) resList.Add("DepoBankName");
            if (customerCustomerChangeResult1.CustWarehouseCd != customerCustomerChangeResult2.CustWarehouseCd) resList.Add("CustWarehouseCd");
            if (customerCustomerChangeResult1.CustWarehouseName != customerCustomerChangeResult2.CustWarehouseName) resList.Add("CustWarehouseName");
            if (customerCustomerChangeResult1.QrcodePrtCd != customerCustomerChangeResult2.QrcodePrtCd) resList.Add("QrcodePrtCd");
            if (customerCustomerChangeResult1.DeliHonorificTtl != customerCustomerChangeResult2.DeliHonorificTtl) resList.Add("DeliHonorificTtl");
            if (customerCustomerChangeResult1.BillHonorificTtl != customerCustomerChangeResult2.BillHonorificTtl) resList.Add("BillHonorificTtl");
            if (customerCustomerChangeResult1.EstmHonorificTtl != customerCustomerChangeResult2.EstmHonorificTtl) resList.Add("EstmHonorificTtl");
            if (customerCustomerChangeResult1.RectHonorificTtl != customerCustomerChangeResult2.RectHonorificTtl) resList.Add("RectHonorificTtl");
            if (customerCustomerChangeResult1.DeliHonorTtlPrtDiv != customerCustomerChangeResult2.DeliHonorTtlPrtDiv) resList.Add("DeliHonorTtlPrtDiv");
            if (customerCustomerChangeResult1.BillHonorTtlPrtDiv != customerCustomerChangeResult2.BillHonorTtlPrtDiv) resList.Add("BillHonorTtlPrtDiv");
            if (customerCustomerChangeResult1.EstmHonorTtlPrtDiv != customerCustomerChangeResult2.EstmHonorTtlPrtDiv) resList.Add("EstmHonorTtlPrtDiv");
            if (customerCustomerChangeResult1.RectHonorTtlPrtDiv != customerCustomerChangeResult2.RectHonorTtlPrtDiv) resList.Add("RectHonorTtlPrtDiv");
            if (customerCustomerChangeResult1.Note1 != customerCustomerChangeResult2.Note1) resList.Add("Note1");
            if (customerCustomerChangeResult1.Note2 != customerCustomerChangeResult2.Note2) resList.Add("Note2");
            if (customerCustomerChangeResult1.Note3 != customerCustomerChangeResult2.Note3) resList.Add("Note3");
            if (customerCustomerChangeResult1.Note4 != customerCustomerChangeResult2.Note4) resList.Add("Note4");
            if (customerCustomerChangeResult1.Note5 != customerCustomerChangeResult2.Note5) resList.Add("Note5");
            if (customerCustomerChangeResult1.Note6 != customerCustomerChangeResult2.Note6) resList.Add("Note6");
            if (customerCustomerChangeResult1.Note7 != customerCustomerChangeResult2.Note7) resList.Add("Note7");
            if (customerCustomerChangeResult1.Note8 != customerCustomerChangeResult2.Note8) resList.Add("Note8");
            if (customerCustomerChangeResult1.Note9 != customerCustomerChangeResult2.Note9) resList.Add("Note9");
            if (customerCustomerChangeResult1.Note10 != customerCustomerChangeResult2.Note10) resList.Add("Note10");
            if (customerCustomerChangeResult1.CreditMoney != customerCustomerChangeResult2.CreditMoney) resList.Add("CreditMoney");
            if (customerCustomerChangeResult1.WarningCreditMoney != customerCustomerChangeResult2.WarningCreditMoney) resList.Add("WarningCreditMoney");
            if (customerCustomerChangeResult1.PrsntAccRecBalance != customerCustomerChangeResult2.PrsntAccRecBalance) resList.Add("PrsntAccRecBalance");
            if (customerCustomerChangeResult1.RateGPureCode != customerCustomerChangeResult2.RateGPureCode) resList.Add("RateGPureCode");
            if (customerCustomerChangeResult1.GoodsMakerCd != customerCustomerChangeResult2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (customerCustomerChangeResult1.CustRateGrpCode != customerCustomerChangeResult2.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (customerCustomerChangeResult1.EnterpriseName != customerCustomerChangeResult2.EnterpriseName) resList.Add("EnterpriseName");
            if (customerCustomerChangeResult1.UpdEmployeeName != customerCustomerChangeResult2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (customerCustomerChangeResult1.InpSectionName != customerCustomerChangeResult2.InpSectionName) resList.Add("InpSectionName");
            if (customerCustomerChangeResult1.BillOutPutCodeNm != customerCustomerChangeResult2.BillOutPutCodeNm) resList.Add("BillOutPutCodeNm");
            if (customerCustomerChangeResult1.BillCollecterNm != customerCustomerChangeResult2.BillCollecterNm) resList.Add("BillCollecterNm");
            if (customerCustomerChangeResult1.ReceiptOutputCode != customerCustomerChangeResult2.ReceiptOutputCode) resList.Add("ReceiptOutputCode");

            if (customerCustomerChangeResult1.SalesSlipPrtDiv != customerCustomerChangeResult2.SalesSlipPrtDiv) resList.Add("SalesSlipPrtDiv");
            if (customerCustomerChangeResult1.AcpOdrrSlipPrtDiv != customerCustomerChangeResult2.AcpOdrrSlipPrtDiv) resList.Add("AcpOdrrSlipPrtDiv");
            if (customerCustomerChangeResult1.ShipmSlipPrtDiv != customerCustomerChangeResult2.ShipmSlipPrtDiv) resList.Add("ShipmSlipPrtDiv");
            if (customerCustomerChangeResult1.EstimatePrtDiv != customerCustomerChangeResult2.EstimatePrtDiv) resList.Add("EstimatePrtDiv");
            if (customerCustomerChangeResult1.UOESlipPrtDiv != customerCustomerChangeResult2.UOESlipPrtDiv) resList.Add("UOESlipPrtDiv");

            if (customerCustomerChangeResult1.TotalBillOutputDiv != customerCustomerChangeResult2.TotalBillOutputDiv) resList.Add("TotalBillOutputDiv");
            if (customerCustomerChangeResult1.DetailBillOutputCode != customerCustomerChangeResult2.DetailBillOutputCode) resList.Add("DetailBillOutputCode");
            if (customerCustomerChangeResult1.SlipTtlBillOutputDiv != customerCustomerChangeResult2.SlipTtlBillOutputDiv) resList.Add("SlipTtlBillOutputDiv");

            return resList;
        }
    }
}

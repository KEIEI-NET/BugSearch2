//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   �}�X�^����M���o�E�X�VDB����N���X              //
//                  :   PMKYO06141D.DLL                                 //
// Name Space       :   Broadleaf.Application.Remoting.ParamData        //
// Programmer       :   ������                                          //
// Date             :   2009.04.28                                      //
//----------------------------------------------------------------------//
// Update Note      :                                                   //
//----------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   APCustomerWork
    /// <summary>
    ///                      ���Ӑ惏�[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���Ӑ惏�[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/18</br>
    /// <br>Genarated Date   :   2009/05/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/5/1  ����</br>
    /// <br>                 :   ���Ӑ�|���O���[�v�R�[�h���폜</br>
    /// <br>Update Note      :   2008/6/16  ����</br>
    /// <br>                 :   ���Ӑ�`�[�ԍ��̕⑫�����ύX</br>
    /// <br>                 :   0:�g�p���Ȃ�,1:�g�p����</br>
    /// <br>                 :   �@�@�@��</br>
    /// <br>                 :   0:�g�p���Ȃ�,1:�A��,2:����,3:����</br>
    /// <br>Update Note      :   2008/11/10  ����</br>
    /// <br>                 :   ���⑫�ύX</br>
    /// <br>                 :   QR�R�[�h�󎚋敪</br>
    /// <br>                 :   0:�W�� 1:�󎚂��Ȃ� 2:�󎚂��� 3:�ԕi�܂�</br>
    /// <br>Update Note      :   2008/11/11  ����</br>
    /// <br>                 :   ���⑫�ύX</br>
    /// <br>                 :   0:���Ȃ��@1:����</br>
    /// <br>                 :   ��</br>
    /// <br>                 :   0:�S�̐ݒ�Q�� 1:���Ȃ��@2:����</br>
    /// <br>Update Note      :   2008/12/1  ����</br>
    /// <br>                 :   �� �f�[�^�^�ύX</br>
    /// <br>                 :   ���Ӑ�D��q�ɃR�[�h</br>
    /// <br>                 :   Int32�@�ˁ@nchar 6 12byte</br>
    /// <br>                 :   �W�����敪����</br>
    /// <br>                 :   nvarchar 3 6byte�@�ˁ@nvarchar 4 8byte</br>
    /// <br>Update Note      :   2008/12/19  ����</br>
    /// <br>                 :   �� ���ڒǉ�</br>
    /// <br>                 :   ����`�[���s�敪 </br>
    /// <br>                 :   �o�ד`�[���s�敪 </br>
    /// <br>                 :   �󒍓`�[���s�敪 </br>
    /// <br>                 :   ���Ϗ����s�敪  </br>
    /// <br>                 :   UOE�`�[���s�敪  </br>
    /// <br>Update Note      :   2009/2/6  ����</br>
    /// <br>                 :   ���⑫�C��</br>
    /// <br>                 :   �������</br>
    /// <br>                 :   10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�</br>
    /// <br>                 :   ��</br>
    /// <br>                 :   51:����,52:�U��,53:���؎�,54:��`56:���E,58:���̑�</br>
    /// <br>Update Note      :   2009/3/19  ����</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   �̎����o�͋敪�R�[�h</br>
    /// <br>Update Note      :   2009/5/11  ����</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   ���Ӑ��ƃR�[�h</br>
    /// <br>                 :   ���Ӑ拒�_�R�[�h</br>
    /// <br>                 :   ���Ӑ拒�_����</br>
    /// <br>                 :   �I�����C����ʋ敪</br>
    /// <br>Update Note      :   2009/5/19  ����</br>
    /// <br>                 :   �����ڍ폜</br>
    /// <br>                 :   ���Ӑ拒�_����</br>
    /// <br>                 :   ���⑫�C��</br>
    /// <br>                 :   �I�����C����ʋ敪</br>
    /// <br>                 :   10:SCM�A20:TSP.NS�A30:TSP.NS�C�����C���A40:TSP���[��</br>
    /// <br>                 :   ��</br>
    /// <br>                 :   0:�Ȃ� 10:SCM�A20:TSP.NS�A30:TSP.NS�C�����C���A40:TSP���[��</br>
    /// <br>Update Note      :   2009/5/22  ����</br>
    /// <br>                 :   ��DD�o�C�g�~�X�C��</br>
    /// <br>                 :   �@���Ӑ拒�_�R�[�h</br>
    /// <br>                 :   �@32��12</br>
    /// <br>Update Note      :   2009/6/4  ����</br>
    /// <br>                 :   ���⑫�C��</br>
    /// <br>                 :   �@�l�E�@�l�敪</br>
    /// <br>                 :   �@5:AA��ǉ��i�S�̏����l�ݒ�ɍ��킹��j</br>
    /// <br>Update Note      :   2010/1/7  ����</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   ���v�������o�͋敪</br>
    /// <br>                 :   ���א������o�͋敪</br>
    /// <br>                 :   �`�[���v�������o�͋敪</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class APCustomerWork : IFileHeader
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

        /// <summary>�Ǝ�R�[�h</summary>
        private Int32 _businessTypeCode;

        /// <summary>�̔��G���A�R�[�h</summary>
        private Int32 _salesAreaCode;

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
        /// <remarks>����,����,���X��,���X�X��</remarks>
        private string _collectMoneyName = "";

        /// <summary>�W����</summary>
        /// <remarks>DD</remarks>
        private Int32 _collectMoneyDay;

        /// <summary>�������</summary>
        /// <remarks>51:����,52:�U��,53:���؎�,54:��`56:���E,58:���̑�</remarks>
        private Int32 _collectCond;

        /// <summary>����T�C�g</summary>
        /// <remarks>��`�T�C�g�@180��</remarks>
        private Int32 _collectSight;

        /// <summary>������R�[�h</summary>
        /// <remarks>�����擾�Ӑ�B�[����̏ꍇ�̎g�p�\����</remarks>
        private Int32 _claimCode;

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

        /// <summary>�W���S���]�ƈ��R�[�h</summary>
        private string _billCollecterCd = "";

        /// <summary>���ڋq�S���]�ƈ��R�[�h</summary>
        private string _oldCustomerAgentCd = "";

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
        /// <remarks>0:�S�̐ݒ�Q�� 1:���Ȃ��@2:����</remarks>
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

        /// <summary>���Ӑ�D��q�ɃR�[�h</summary>
        private string _custWarehouseCd = "";

        /// <summary>QR�R�[�h���</summary>
        /// <remarks>0:�W�� 1:�󎚂��Ȃ� 2:�󎚂��� 3:�ԕi�܂�</remarks>
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

        /// <summary>����`�[���s�敪</summary>
        /// <remarks>0:����@1:���Ȃ�</remarks>
        private Int32 _salesSlipPrtDiv;

        /// <summary>�o�ד`�[���s�敪</summary>
        /// <remarks>0:����@1:���Ȃ��@�i�ݏo�j</remarks>
        private Int32 _shipmSlipPrtDiv;

        /// <summary>�󒍓`�[���s�敪</summary>
        /// <remarks>0:���Ȃ� 1:����</remarks>
        private Int32 _acpOdrrSlipPrtDiv;

        /// <summary>���Ϗ����s�敪</summary>
        /// <remarks>0:����@1:���Ȃ�</remarks>
        private Int32 _estimatePrtDiv;

        /// <summary>UOE�`�[���s�敪</summary>
        /// <remarks>0:����@1:���Ȃ�</remarks>
        private Int32 _uOESlipPrtDiv;

        /// <summary>�̎����o�͋敪�R�[�h</summary>
        /// <remarks>0:����@1:���Ȃ�</remarks>
        private Int32 _receiptOutputCode;

        /// <summary>���Ӑ��ƃR�[�h</summary>
        /// <remarks>�V�X�e���A���\�ȏꍇ�̂ݓo�^�����</remarks>
        private string _customerEpCode = "";

        /// <summary>���Ӑ拒�_�R�[�h</summary>
        /// <remarks>�V�X�e���A���\�ȏꍇ�̂ݓo�^�����</remarks>
        private string _customerSecCode = "";

        /// <summary>�I�����C����ʋ敪</summary>
        /// <remarks>0:�Ȃ� 10:SCM�A20:TSP.NS�A30:TSP.NS�C�����C���A40:TSP���[��</remarks>
        private Int32 _onlineKindDiv;

        /// <summary>���v�������o�͋敪</summary>
        /// <remarks>0:�W���@1:�g�p����@2:�g�p���Ȃ�</remarks>
        private Int32 _totalBillOutputDiv;

        /// <summary>���א������o�͋敪</summary>
        /// <remarks>0:�W���@1:�g�p����@2:�g�p���Ȃ�</remarks>
        private Int32 _detailBillOutputCode;

        /// <summary>�`�[���v�������o�͋敪</summary>
        /// <remarks>0:�W���@1:�g�p����@2:�g�p���Ȃ�</remarks>
        private Int32 _slipTtlBillOutputDiv;


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
        /// <value>����,����,���X��,���X�X��</value>
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
        /// <value>51:����,52:�U��,53:���؎�,54:��`56:���E,58:���̑�</value>
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
        /// <value>0:�S�̐ݒ�Q�� 1:���Ȃ��@2:����</value>
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

        /// public propaty name  :  QrcodePrtCd
        /// <summary>QR�R�[�h����v���p�e�B</summary>
        /// <value>0:�W�� 1:�󎚂��Ȃ� 2:�󎚂��� 3:�ԕi�܂�</value>
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

        /// public propaty name  :  SalesSlipPrtDiv
        /// <summary>����`�[���s�敪�v���p�e�B</summary>
        /// <value>0:����@1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���s�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesSlipPrtDiv
        {
            get { return _salesSlipPrtDiv; }
            set { _salesSlipPrtDiv = value; }
        }

        /// public propaty name  :  ShipmSlipPrtDiv
        /// <summary>�o�ד`�[���s�敪�v���p�e�B</summary>
        /// <value>0:����@1:���Ȃ��@�i�ݏo�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ד`�[���s�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ShipmSlipPrtDiv
        {
            get { return _shipmSlipPrtDiv; }
            set { _shipmSlipPrtDiv = value; }
        }

        /// public propaty name  :  AcpOdrrSlipPrtDiv
        /// <summary>�󒍓`�[���s�敪�v���p�e�B</summary>
        /// <value>0:���Ȃ� 1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍓`�[���s�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcpOdrrSlipPrtDiv
        {
            get { return _acpOdrrSlipPrtDiv; }
            set { _acpOdrrSlipPrtDiv = value; }
        }

        /// public propaty name  :  EstimatePrtDiv
        /// <summary>���Ϗ����s�敪�v���p�e�B</summary>
        /// <value>0:����@1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ϗ����s�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EstimatePrtDiv
        {
            get { return _estimatePrtDiv; }
            set { _estimatePrtDiv = value; }
        }

        /// public propaty name  :  UOESlipPrtDiv
        /// <summary>UOE�`�[���s�敪�v���p�e�B</summary>
        /// <value>0:����@1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�`�[���s�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESlipPrtDiv
        {
            get { return _uOESlipPrtDiv; }
            set { _uOESlipPrtDiv = value; }
        }

        /// public propaty name  :  ReceiptOutputCode
        /// <summary>�̎����o�͋敪�R�[�h�v���p�e�B</summary>
        /// <value>0:����@1:���Ȃ�</value>
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

        /// public propaty name  :  CustomerEpCode
        /// <summary>���Ӑ��ƃR�[�h�v���p�e�B</summary>
        /// <value>�V�X�e���A���\�ȏꍇ�̂ݓo�^�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerEpCode
        {
            get { return _customerEpCode; }
            set { _customerEpCode = value; }
        }

        /// public propaty name  :  CustomerSecCode
        /// <summary>���Ӑ拒�_�R�[�h�v���p�e�B</summary>
        /// <value>�V�X�e���A���\�ȏꍇ�̂ݓo�^�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ拒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerSecCode
        {
            get { return _customerSecCode; }
            set { _customerSecCode = value; }
        }

        /// public propaty name  :  OnlineKindDiv
        /// <summary>�I�����C����ʋ敪�v���p�e�B</summary>
        /// <value>0:�Ȃ� 10:SCM�A20:TSP.NS�A30:TSP.NS�C�����C���A40:TSP���[��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����C����ʋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OnlineKindDiv
        {
            get { return _onlineKindDiv; }
            set { _onlineKindDiv = value; }
        }
 
        /// public propaty name  :  TotalBillOutputDiv
        /// <summary>���v�������o�͋敪�v���p�e�B</summary>
        /// <value>0:�W���@1:�g�p����@2:�g�p���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�������o�͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalBillOutputDiv
        {
            get { return _totalBillOutputDiv; }
            set { _totalBillOutputDiv = value; }
        }

        /// public propaty name  :  DetailBillOutputCode
        /// <summary>���א������o�͋敪�v���p�e�B</summary>
        /// <value>0:�W���@1:�g�p����@2:�g�p���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���א������o�͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DetailBillOutputCode
        {
            get { return _detailBillOutputCode; }
            set { _detailBillOutputCode = value; }
        }

        /// public propaty name  :  SlipTtlBillOutputDiv
        /// <summary>�`�[���v�������o�͋敪�v���p�e�B</summary>
        /// <value>0:�W���@1:�g�p����@2:�g�p���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���v�������o�͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipTtlBillOutputDiv
        {
            get { return _slipTtlBillOutputDiv; }
            set { _slipTtlBillOutputDiv = value; }
        }


        /// <summary>
        /// ���Ӑ惏�[�N�R���X�g���N�^
        /// </summary>
        /// <returns>CustomerWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public APCustomerWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>CustomerWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   CustomerWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class CustomerWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CustomerWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is APCustomerWork || graph is ArrayList || graph is APCustomerWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(APCustomerWork).FullName));

            if (graph != null && graph is APCustomerWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CustomerWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is APCustomerWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((APCustomerWork[])graph).Length;
            }
            else if (graph is APCustomerWork)
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
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //���Ӑ�T�u�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSubCode
            //����
            serInfo.MemberInfo.Add(typeof(string)); //Name
            //����2
            serInfo.MemberInfo.Add(typeof(string)); //Name2
            //�h��
            serInfo.MemberInfo.Add(typeof(string)); //HonorificTitle
            //�J�i
            serInfo.MemberInfo.Add(typeof(string)); //Kana
            //���Ӑ旪��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //�����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //OutputNameCode
            //��������
            serInfo.MemberInfo.Add(typeof(string)); //OutputName
            //�l�E�@�l�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //CorporateDivCode
            //���Ӑ摮���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerAttributeDiv
            //�E��R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //JobTypeCode
            //�Ǝ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BusinessTypeCode
            //�̔��G���A�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesAreaCode
            //�X�֔ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //PostNo
            //�Z��1�i�s���{���s��S�E�����E���j
            serInfo.MemberInfo.Add(typeof(string)); //Address1
            //�Z��3�i�Ԓn�j
            serInfo.MemberInfo.Add(typeof(string)); //Address3
            //�Z��4�i�A�p�[�g���́j
            serInfo.MemberInfo.Add(typeof(string)); //Address4
            //�d�b�ԍ��i����j
            serInfo.MemberInfo.Add(typeof(string)); //HomeTelNo
            //�d�b�ԍ��i�Ζ���j
            serInfo.MemberInfo.Add(typeof(string)); //OfficeTelNo
            //�d�b�ԍ��i�g�сj
            serInfo.MemberInfo.Add(typeof(string)); //PortableTelNo
            //FAX�ԍ��i����j
            serInfo.MemberInfo.Add(typeof(string)); //HomeFaxNo
            //FAX�ԍ��i�Ζ���j
            serInfo.MemberInfo.Add(typeof(string)); //OfficeFaxNo
            //�d�b�ԍ��i���̑��j
            serInfo.MemberInfo.Add(typeof(string)); //OthersTelNo
            //��A����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //MainContactCode
            //�d�b�ԍ��i�����p��4���j
            serInfo.MemberInfo.Add(typeof(string)); //SearchTelNo
            //�Ǘ����_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //MngSectionCode
            //���͋��_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InpSectionCode
            //���Ӑ敪�̓R�[�h1
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAnalysCode1
            //���Ӑ敪�̓R�[�h2
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAnalysCode2
            //���Ӑ敪�̓R�[�h3
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAnalysCode3
            //���Ӑ敪�̓R�[�h4
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAnalysCode4
            //���Ӑ敪�̓R�[�h5
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAnalysCode5
            //���Ӑ敪�̓R�[�h6
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAnalysCode6
            //�������o�͋敪�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BillOutputCode
            //�������o�͋敪����
            serInfo.MemberInfo.Add(typeof(string)); //BillOutputName
            //����
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalDay
            //�W�����敪�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CollectMoneyCode
            //�W�����敪����
            serInfo.MemberInfo.Add(typeof(string)); //CollectMoneyName
            //�W����
            serInfo.MemberInfo.Add(typeof(Int32)); //CollectMoneyDay
            //�������
            serInfo.MemberInfo.Add(typeof(Int32)); //CollectCond
            //����T�C�g
            serInfo.MemberInfo.Add(typeof(Int32)); //CollectSight
            //������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //ClaimCode
            //������~��
            serInfo.MemberInfo.Add(typeof(Int32)); //TransStopDate
            //DM�o�͋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DmOutCode
            //DM�o�͋敪����
            serInfo.MemberInfo.Add(typeof(string)); //DmOutName
            //�呗�M�惁�[���A�h���X�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //MainSendMailAddrCd
            //���[���A�h���X��ʃR�[�h1
            serInfo.MemberInfo.Add(typeof(Int32)); //MailAddrKindCode1
            //���[���A�h���X��ʖ���1
            serInfo.MemberInfo.Add(typeof(string)); //MailAddrKindName1
            //���[���A�h���X1
            serInfo.MemberInfo.Add(typeof(string)); //MailAddress1
            //���[�����M�敪�R�[�h1
            serInfo.MemberInfo.Add(typeof(Int32)); //MailSendCode1
            //���[�����M�敪����1
            serInfo.MemberInfo.Add(typeof(string)); //MailSendName1
            //���[���A�h���X��ʃR�[�h2
            serInfo.MemberInfo.Add(typeof(Int32)); //MailAddrKindCode2
            //���[���A�h���X��ʖ���2
            serInfo.MemberInfo.Add(typeof(string)); //MailAddrKindName2
            //���[���A�h���X2
            serInfo.MemberInfo.Add(typeof(string)); //MailAddress2
            //���[�����M�敪�R�[�h2
            serInfo.MemberInfo.Add(typeof(Int32)); //MailSendCode2
            //���[�����M�敪����2
            serInfo.MemberInfo.Add(typeof(string)); //MailSendName2
            //�ڋq�S���]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //CustomerAgentCd
            //�W���S���]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //BillCollecterCd
            //���ڋq�S���]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //OldCustomerAgentCd
            //�ڋq�S���ύX��
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAgentChgDate
            //�Ɣ̐�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AcceptWholeSale
            //�^�M�Ǘ��敪
            serInfo.MemberInfo.Add(typeof(Int32)); //CreditMngCode
            //���������敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DepoDelCode
            //���|�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AccRecDivCd
            //����`�[�ԍ��Ǘ��敪
            serInfo.MemberInfo.Add(typeof(Int32)); //CustSlipNoMngCd
            //�����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //PureCode
            //���Ӑ����œ]�ŕ����Q�Ƌ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //CustCTaXLayRefCd
            //����œ]�ŕ���
            serInfo.MemberInfo.Add(typeof(Int32)); //ConsTaxLayMethod
            //���z�\�����@�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalAmountDispWayCd
            //���z�\�����@�Q�Ƌ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalAmntDspWayRef
            //��s����1
            serInfo.MemberInfo.Add(typeof(string)); //AccountNoInfo1
            //��s����2
            serInfo.MemberInfo.Add(typeof(string)); //AccountNoInfo2
            //��s����3
            serInfo.MemberInfo.Add(typeof(string)); //AccountNoInfo3
            //����P���[�������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesUnPrcFrcProcCd
            //������z�[�������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesMoneyFrcProcCd
            //�������Œ[�������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCnsTaxFrcProcCd
            //���Ӑ�`�[�ԍ��敪
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerSlipNoDiv
            //���񊨒�J�n��
            serInfo.MemberInfo.Add(typeof(Int32)); //NTimeCalcStDate
            //���Ӑ�S����
            serInfo.MemberInfo.Add(typeof(string)); //CustomerAgent
            //�������_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //ClaimSectionCode
            //���q�Ǘ��敪
            serInfo.MemberInfo.Add(typeof(Int32)); //CarMngDivCd
            //�i�Ԉ󎚋敪(������)
            serInfo.MemberInfo.Add(typeof(Int32)); //BillPartsNoPrtCd
            //�i�Ԉ󎚋敪(�[�i���j
            serInfo.MemberInfo.Add(typeof(Int32)); //DeliPartsNoPrtCd
            //�`�[�敪�����l
            serInfo.MemberInfo.Add(typeof(Int32)); //DefSalesSlipCd
            //�H�����o���[�g�����N
            serInfo.MemberInfo.Add(typeof(Int32)); //LavorRateRank
            //�`�[�^�C�g���p�^�[��
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipTtlPrn
            //������s�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //DepoBankCode
            //���Ӑ�D��q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //CustWarehouseCd
            //QR�R�[�h���
            serInfo.MemberInfo.Add(typeof(Int32)); //QrcodePrtCd
            //�[�i���h��
            serInfo.MemberInfo.Add(typeof(string)); //DeliHonorificTtl
            //�������h��
            serInfo.MemberInfo.Add(typeof(string)); //BillHonorificTtl
            //���Ϗ��h��
            serInfo.MemberInfo.Add(typeof(string)); //EstmHonorificTtl
            //�̎����h��
            serInfo.MemberInfo.Add(typeof(string)); //RectHonorificTtl
            //�[�i���h�̈󎚋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DeliHonorTtlPrtDiv
            //�������h�̈󎚋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //BillHonorTtlPrtDiv
            //���Ϗ��h�̈󎚋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //EstmHonorTtlPrtDiv
            //�̎����h�̈󎚋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //RectHonorTtlPrtDiv
            //���l1
            serInfo.MemberInfo.Add(typeof(string)); //Note1
            //���l2
            serInfo.MemberInfo.Add(typeof(string)); //Note2
            //���l3
            serInfo.MemberInfo.Add(typeof(string)); //Note3
            //���l4
            serInfo.MemberInfo.Add(typeof(string)); //Note4
            //���l5
            serInfo.MemberInfo.Add(typeof(string)); //Note5
            //���l6
            serInfo.MemberInfo.Add(typeof(string)); //Note6
            //���l7
            serInfo.MemberInfo.Add(typeof(string)); //Note7
            //���l8
            serInfo.MemberInfo.Add(typeof(string)); //Note8
            //���l9
            serInfo.MemberInfo.Add(typeof(string)); //Note9
            //���l10
            serInfo.MemberInfo.Add(typeof(string)); //Note10
            //����`�[���s�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipPrtDiv
            //�o�ד`�[���s�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipmSlipPrtDiv
            //�󒍓`�[���s�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AcpOdrrSlipPrtDiv
            //���Ϗ����s�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //EstimatePrtDiv
            //UOE�`�[���s�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //UOESlipPrtDiv
            //�̎����o�͋敪�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //ReceiptOutputCode
            //���Ӑ��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //CustomerEpCode
            //���Ӑ拒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSecCode
            //�I�����C����ʋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //OnlineKindDiv
            //���v�������o�͋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalBillOutputDiv
            //���א������o�͋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DetailBillOutputCode
            //�`�[���v�������o�͋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipTtlBillOutputDiv


            serInfo.Serialize(writer, serInfo);
            if (graph is APCustomerWork)
            {
                APCustomerWork temp = (APCustomerWork)graph;

                SetCustomerWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is APCustomerWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((APCustomerWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (APCustomerWork temp in lst)
                {
                    SetCustomerWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CustomerWork�����o��(public�v���p�e�B��)
        /// </summary>
        // --- ADD  ���r��  2010/01/21 ---------->>>>>
        //private const int currentMemberCount = 125;
        private const int currentMemberCount = 128;
        // --- ADD  ���r��  2010/01/21 ----------<<<<<

        /// <summary>
        ///  CustomerWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetCustomerWork(System.IO.BinaryWriter writer, APCustomerWork temp)
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
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //���Ӑ�T�u�R�[�h
            writer.Write(temp.CustomerSubCode);
            //����
            writer.Write(temp.Name);
            //����2
            writer.Write(temp.Name2);
            //�h��
            writer.Write(temp.HonorificTitle);
            //�J�i
            writer.Write(temp.Kana);
            //���Ӑ旪��
            writer.Write(temp.CustomerSnm);
            //�����R�[�h
            writer.Write(temp.OutputNameCode);
            //��������
            writer.Write(temp.OutputName);
            //�l�E�@�l�敪
            writer.Write(temp.CorporateDivCode);
            //���Ӑ摮���敪
            writer.Write(temp.CustomerAttributeDiv);
            //�E��R�[�h
            writer.Write(temp.JobTypeCode);
            //�Ǝ�R�[�h
            writer.Write(temp.BusinessTypeCode);
            //�̔��G���A�R�[�h
            writer.Write(temp.SalesAreaCode);
            //�X�֔ԍ�
            writer.Write(temp.PostNo);
            //�Z��1�i�s���{���s��S�E�����E���j
            writer.Write(temp.Address1);
            //�Z��3�i�Ԓn�j
            writer.Write(temp.Address3);
            //�Z��4�i�A�p�[�g���́j
            writer.Write(temp.Address4);
            //�d�b�ԍ��i����j
            writer.Write(temp.HomeTelNo);
            //�d�b�ԍ��i�Ζ���j
            writer.Write(temp.OfficeTelNo);
            //�d�b�ԍ��i�g�сj
            writer.Write(temp.PortableTelNo);
            //FAX�ԍ��i����j
            writer.Write(temp.HomeFaxNo);
            //FAX�ԍ��i�Ζ���j
            writer.Write(temp.OfficeFaxNo);
            //�d�b�ԍ��i���̑��j
            writer.Write(temp.OthersTelNo);
            //��A����敪
            writer.Write(temp.MainContactCode);
            //�d�b�ԍ��i�����p��4���j
            writer.Write(temp.SearchTelNo);
            //�Ǘ����_�R�[�h
            writer.Write(temp.MngSectionCode);
            //���͋��_�R�[�h
            writer.Write(temp.InpSectionCode);
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
            //�������o�͋敪�R�[�h
            writer.Write(temp.BillOutputCode);
            //�������o�͋敪����
            writer.Write(temp.BillOutputName);
            //����
            writer.Write(temp.TotalDay);
            //�W�����敪�R�[�h
            writer.Write(temp.CollectMoneyCode);
            //�W�����敪����
            writer.Write(temp.CollectMoneyName);
            //�W����
            writer.Write(temp.CollectMoneyDay);
            //�������
            writer.Write(temp.CollectCond);
            //����T�C�g
            writer.Write(temp.CollectSight);
            //������R�[�h
            writer.Write(temp.ClaimCode);
            //������~��
            writer.Write((Int64)temp.TransStopDate.Ticks);
            //DM�o�͋敪
            writer.Write(temp.DmOutCode);
            //DM�o�͋敪����
            writer.Write(temp.DmOutName);
            //�呗�M�惁�[���A�h���X�敪
            writer.Write(temp.MainSendMailAddrCd);
            //���[���A�h���X��ʃR�[�h1
            writer.Write(temp.MailAddrKindCode1);
            //���[���A�h���X��ʖ���1
            writer.Write(temp.MailAddrKindName1);
            //���[���A�h���X1
            writer.Write(temp.MailAddress1);
            //���[�����M�敪�R�[�h1
            writer.Write(temp.MailSendCode1);
            //���[�����M�敪����1
            writer.Write(temp.MailSendName1);
            //���[���A�h���X��ʃR�[�h2
            writer.Write(temp.MailAddrKindCode2);
            //���[���A�h���X��ʖ���2
            writer.Write(temp.MailAddrKindName2);
            //���[���A�h���X2
            writer.Write(temp.MailAddress2);
            //���[�����M�敪�R�[�h2
            writer.Write(temp.MailSendCode2);
            //���[�����M�敪����2
            writer.Write(temp.MailSendName2);
            //�ڋq�S���]�ƈ��R�[�h
            writer.Write(temp.CustomerAgentCd);
            //�W���S���]�ƈ��R�[�h
            writer.Write(temp.BillCollecterCd);
            //���ڋq�S���]�ƈ��R�[�h
            writer.Write(temp.OldCustomerAgentCd);
            //�ڋq�S���ύX��
            writer.Write((Int64)temp.CustAgentChgDate.Ticks);
            //�Ɣ̐�敪
            writer.Write(temp.AcceptWholeSale);
            //�^�M�Ǘ��敪
            writer.Write(temp.CreditMngCode);
            //���������敪
            writer.Write(temp.DepoDelCode);
            //���|�敪
            writer.Write(temp.AccRecDivCd);
            //����`�[�ԍ��Ǘ��敪
            writer.Write(temp.CustSlipNoMngCd);
            //�����敪
            writer.Write(temp.PureCode);
            //���Ӑ����œ]�ŕ����Q�Ƌ敪
            writer.Write(temp.CustCTaXLayRefCd);
            //����œ]�ŕ���
            writer.Write(temp.ConsTaxLayMethod);
            //���z�\�����@�敪
            writer.Write(temp.TotalAmountDispWayCd);
            //���z�\�����@�Q�Ƌ敪
            writer.Write(temp.TotalAmntDspWayRef);
            //��s����1
            writer.Write(temp.AccountNoInfo1);
            //��s����2
            writer.Write(temp.AccountNoInfo2);
            //��s����3
            writer.Write(temp.AccountNoInfo3);
            //����P���[�������R�[�h
            writer.Write(temp.SalesUnPrcFrcProcCd);
            //������z�[�������R�[�h
            writer.Write(temp.SalesMoneyFrcProcCd);
            //�������Œ[�������R�[�h
            writer.Write(temp.SalesCnsTaxFrcProcCd);
            //���Ӑ�`�[�ԍ��敪
            writer.Write(temp.CustomerSlipNoDiv);
            //���񊨒�J�n��
            writer.Write(temp.NTimeCalcStDate);
            //���Ӑ�S����
            writer.Write(temp.CustomerAgent);
            //�������_�R�[�h
            writer.Write(temp.ClaimSectionCode);
            //���q�Ǘ��敪
            writer.Write(temp.CarMngDivCd);
            //�i�Ԉ󎚋敪(������)
            writer.Write(temp.BillPartsNoPrtCd);
            //�i�Ԉ󎚋敪(�[�i���j
            writer.Write(temp.DeliPartsNoPrtCd);
            //�`�[�敪�����l
            writer.Write(temp.DefSalesSlipCd);
            //�H�����o���[�g�����N
            writer.Write(temp.LavorRateRank);
            //�`�[�^�C�g���p�^�[��
            writer.Write(temp.SlipTtlPrn);
            //������s�R�[�h
            writer.Write(temp.DepoBankCode);
            //���Ӑ�D��q�ɃR�[�h
            writer.Write(temp.CustWarehouseCd);
            //QR�R�[�h���
            writer.Write(temp.QrcodePrtCd);
            //�[�i���h��
            writer.Write(temp.DeliHonorificTtl);
            //�������h��
            writer.Write(temp.BillHonorificTtl);
            //���Ϗ��h��
            writer.Write(temp.EstmHonorificTtl);
            //�̎����h��
            writer.Write(temp.RectHonorificTtl);
            //�[�i���h�̈󎚋敪
            writer.Write(temp.DeliHonorTtlPrtDiv);
            //�������h�̈󎚋敪
            writer.Write(temp.BillHonorTtlPrtDiv);
            //���Ϗ��h�̈󎚋敪
            writer.Write(temp.EstmHonorTtlPrtDiv);
            //�̎����h�̈󎚋敪
            writer.Write(temp.RectHonorTtlPrtDiv);
            //���l1
            writer.Write(temp.Note1);
            //���l2
            writer.Write(temp.Note2);
            //���l3
            writer.Write(temp.Note3);
            //���l4
            writer.Write(temp.Note4);
            //���l5
            writer.Write(temp.Note5);
            //���l6
            writer.Write(temp.Note6);
            //���l7
            writer.Write(temp.Note7);
            //���l8
            writer.Write(temp.Note8);
            //���l9
            writer.Write(temp.Note9);
            //���l10
            writer.Write(temp.Note10);
            //����`�[���s�敪
            writer.Write(temp.SalesSlipPrtDiv);
            //�o�ד`�[���s�敪
            writer.Write(temp.ShipmSlipPrtDiv);
            //�󒍓`�[���s�敪
            writer.Write(temp.AcpOdrrSlipPrtDiv);
            //���Ϗ����s�敪
            writer.Write(temp.EstimatePrtDiv);
            //UOE�`�[���s�敪
            writer.Write(temp.UOESlipPrtDiv);
            //�̎����o�͋敪�R�[�h
            writer.Write(temp.ReceiptOutputCode);
            //���Ӑ��ƃR�[�h
            writer.Write(temp.CustomerEpCode);
            //���Ӑ拒�_�R�[�h
            writer.Write(temp.CustomerSecCode);
            //�I�����C����ʋ敪
            writer.Write(temp.OnlineKindDiv);
            //���v�������o�͋敪
            writer.Write(temp.TotalBillOutputDiv);
            //���א������o�͋敪
            writer.Write(temp.DetailBillOutputCode);
            //�`�[���v�������o�͋敪
            writer.Write(temp.SlipTtlBillOutputDiv);


        }

        /// <summary>
        ///  CustomerWork�C���X�^���X�擾
        /// </summary>
        /// <returns>CustomerWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private APCustomerWork GetCustomerWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            APCustomerWork temp = new APCustomerWork();

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
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //���Ӑ�T�u�R�[�h
            temp.CustomerSubCode = reader.ReadString();
            //����
            temp.Name = reader.ReadString();
            //����2
            temp.Name2 = reader.ReadString();
            //�h��
            temp.HonorificTitle = reader.ReadString();
            //�J�i
            temp.Kana = reader.ReadString();
            //���Ӑ旪��
            temp.CustomerSnm = reader.ReadString();
            //�����R�[�h
            temp.OutputNameCode = reader.ReadInt32();
            //��������
            temp.OutputName = reader.ReadString();
            //�l�E�@�l�敪
            temp.CorporateDivCode = reader.ReadInt32();
            //���Ӑ摮���敪
            temp.CustomerAttributeDiv = reader.ReadInt32();
            //�E��R�[�h
            temp.JobTypeCode = reader.ReadInt32();
            //�Ǝ�R�[�h
            temp.BusinessTypeCode = reader.ReadInt32();
            //�̔��G���A�R�[�h
            temp.SalesAreaCode = reader.ReadInt32();
            //�X�֔ԍ�
            temp.PostNo = reader.ReadString();
            //�Z��1�i�s���{���s��S�E�����E���j
            temp.Address1 = reader.ReadString();
            //�Z��3�i�Ԓn�j
            temp.Address3 = reader.ReadString();
            //�Z��4�i�A�p�[�g���́j
            temp.Address4 = reader.ReadString();
            //�d�b�ԍ��i����j
            temp.HomeTelNo = reader.ReadString();
            //�d�b�ԍ��i�Ζ���j
            temp.OfficeTelNo = reader.ReadString();
            //�d�b�ԍ��i�g�сj
            temp.PortableTelNo = reader.ReadString();
            //FAX�ԍ��i����j
            temp.HomeFaxNo = reader.ReadString();
            //FAX�ԍ��i�Ζ���j
            temp.OfficeFaxNo = reader.ReadString();
            //�d�b�ԍ��i���̑��j
            temp.OthersTelNo = reader.ReadString();
            //��A����敪
            temp.MainContactCode = reader.ReadInt32();
            //�d�b�ԍ��i�����p��4���j
            temp.SearchTelNo = reader.ReadString();
            //�Ǘ����_�R�[�h
            temp.MngSectionCode = reader.ReadString();
            //���͋��_�R�[�h
            temp.InpSectionCode = reader.ReadString();
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
            //�������o�͋敪�R�[�h
            temp.BillOutputCode = reader.ReadInt32();
            //�������o�͋敪����
            temp.BillOutputName = reader.ReadString();
            //����
            temp.TotalDay = reader.ReadInt32();
            //�W�����敪�R�[�h
            temp.CollectMoneyCode = reader.ReadInt32();
            //�W�����敪����
            temp.CollectMoneyName = reader.ReadString();
            //�W����
            temp.CollectMoneyDay = reader.ReadInt32();
            //�������
            temp.CollectCond = reader.ReadInt32();
            //����T�C�g
            temp.CollectSight = reader.ReadInt32();
            //������R�[�h
            temp.ClaimCode = reader.ReadInt32();
            //������~��
            temp.TransStopDate = new DateTime(reader.ReadInt64());
            //DM�o�͋敪
            temp.DmOutCode = reader.ReadInt32();
            //DM�o�͋敪����
            temp.DmOutName = reader.ReadString();
            //�呗�M�惁�[���A�h���X�敪
            temp.MainSendMailAddrCd = reader.ReadInt32();
            //���[���A�h���X��ʃR�[�h1
            temp.MailAddrKindCode1 = reader.ReadInt32();
            //���[���A�h���X��ʖ���1
            temp.MailAddrKindName1 = reader.ReadString();
            //���[���A�h���X1
            temp.MailAddress1 = reader.ReadString();
            //���[�����M�敪�R�[�h1
            temp.MailSendCode1 = reader.ReadInt32();
            //���[�����M�敪����1
            temp.MailSendName1 = reader.ReadString();
            //���[���A�h���X��ʃR�[�h2
            temp.MailAddrKindCode2 = reader.ReadInt32();
            //���[���A�h���X��ʖ���2
            temp.MailAddrKindName2 = reader.ReadString();
            //���[���A�h���X2
            temp.MailAddress2 = reader.ReadString();
            //���[�����M�敪�R�[�h2
            temp.MailSendCode2 = reader.ReadInt32();
            //���[�����M�敪����2
            temp.MailSendName2 = reader.ReadString();
            //�ڋq�S���]�ƈ��R�[�h
            temp.CustomerAgentCd = reader.ReadString();
            //�W���S���]�ƈ��R�[�h
            temp.BillCollecterCd = reader.ReadString();
            //���ڋq�S���]�ƈ��R�[�h
            temp.OldCustomerAgentCd = reader.ReadString();
            //�ڋq�S���ύX��
            temp.CustAgentChgDate = new DateTime(reader.ReadInt64());
            //�Ɣ̐�敪
            temp.AcceptWholeSale = reader.ReadInt32();
            //�^�M�Ǘ��敪
            temp.CreditMngCode = reader.ReadInt32();
            //���������敪
            temp.DepoDelCode = reader.ReadInt32();
            //���|�敪
            temp.AccRecDivCd = reader.ReadInt32();
            //����`�[�ԍ��Ǘ��敪
            temp.CustSlipNoMngCd = reader.ReadInt32();
            //�����敪
            temp.PureCode = reader.ReadInt32();
            //���Ӑ����œ]�ŕ����Q�Ƌ敪
            temp.CustCTaXLayRefCd = reader.ReadInt32();
            //����œ]�ŕ���
            temp.ConsTaxLayMethod = reader.ReadInt32();
            //���z�\�����@�敪
            temp.TotalAmountDispWayCd = reader.ReadInt32();
            //���z�\�����@�Q�Ƌ敪
            temp.TotalAmntDspWayRef = reader.ReadInt32();
            //��s����1
            temp.AccountNoInfo1 = reader.ReadString();
            //��s����2
            temp.AccountNoInfo2 = reader.ReadString();
            //��s����3
            temp.AccountNoInfo3 = reader.ReadString();
            //����P���[�������R�[�h
            temp.SalesUnPrcFrcProcCd = reader.ReadInt32();
            //������z�[�������R�[�h
            temp.SalesMoneyFrcProcCd = reader.ReadInt32();
            //�������Œ[�������R�[�h
            temp.SalesCnsTaxFrcProcCd = reader.ReadInt32();
            //���Ӑ�`�[�ԍ��敪
            temp.CustomerSlipNoDiv = reader.ReadInt32();
            //���񊨒�J�n��
            temp.NTimeCalcStDate = reader.ReadInt32();
            //���Ӑ�S����
            temp.CustomerAgent = reader.ReadString();
            //�������_�R�[�h
            temp.ClaimSectionCode = reader.ReadString();
            //���q�Ǘ��敪
            temp.CarMngDivCd = reader.ReadInt32();
            //�i�Ԉ󎚋敪(������)
            temp.BillPartsNoPrtCd = reader.ReadInt32();
            //�i�Ԉ󎚋敪(�[�i���j
            temp.DeliPartsNoPrtCd = reader.ReadInt32();
            //�`�[�敪�����l
            temp.DefSalesSlipCd = reader.ReadInt32();
            //�H�����o���[�g�����N
            temp.LavorRateRank = reader.ReadInt32();
            //�`�[�^�C�g���p�^�[��
            temp.SlipTtlPrn = reader.ReadInt32();
            //������s�R�[�h
            temp.DepoBankCode = reader.ReadInt32();
            //���Ӑ�D��q�ɃR�[�h
            temp.CustWarehouseCd = reader.ReadString();
            //QR�R�[�h���
            temp.QrcodePrtCd = reader.ReadInt32();
            //�[�i���h��
            temp.DeliHonorificTtl = reader.ReadString();
            //�������h��
            temp.BillHonorificTtl = reader.ReadString();
            //���Ϗ��h��
            temp.EstmHonorificTtl = reader.ReadString();
            //�̎����h��
            temp.RectHonorificTtl = reader.ReadString();
            //�[�i���h�̈󎚋敪
            temp.DeliHonorTtlPrtDiv = reader.ReadInt32();
            //�������h�̈󎚋敪
            temp.BillHonorTtlPrtDiv = reader.ReadInt32();
            //���Ϗ��h�̈󎚋敪
            temp.EstmHonorTtlPrtDiv = reader.ReadInt32();
            //�̎����h�̈󎚋敪
            temp.RectHonorTtlPrtDiv = reader.ReadInt32();
            //���l1
            temp.Note1 = reader.ReadString();
            //���l2
            temp.Note2 = reader.ReadString();
            //���l3
            temp.Note3 = reader.ReadString();
            //���l4
            temp.Note4 = reader.ReadString();
            //���l5
            temp.Note5 = reader.ReadString();
            //���l6
            temp.Note6 = reader.ReadString();
            //���l7
            temp.Note7 = reader.ReadString();
            //���l8
            temp.Note8 = reader.ReadString();
            //���l9
            temp.Note9 = reader.ReadString();
            //���l10
            temp.Note10 = reader.ReadString();
            //����`�[���s�敪
            temp.SalesSlipPrtDiv = reader.ReadInt32();
            //�o�ד`�[���s�敪
            temp.ShipmSlipPrtDiv = reader.ReadInt32();
            //�󒍓`�[���s�敪
            temp.AcpOdrrSlipPrtDiv = reader.ReadInt32();
            //���Ϗ����s�敪
            temp.EstimatePrtDiv = reader.ReadInt32();
            //UOE�`�[���s�敪
            temp.UOESlipPrtDiv = reader.ReadInt32();
            //�̎����o�͋敪�R�[�h
            temp.ReceiptOutputCode = reader.ReadInt32();
            //���Ӑ��ƃR�[�h
            temp.CustomerEpCode = reader.ReadString();
            //���Ӑ拒�_�R�[�h
            temp.CustomerSecCode = reader.ReadString();
            //�I�����C����ʋ敪
            temp.OnlineKindDiv = reader.ReadInt32();
            //���v�������o�͋敪
            temp.TotalBillOutputDiv = reader.ReadInt32();
            //���א������o�͋敪
            temp.DetailBillOutputCode = reader.ReadInt32();
            //�`�[���v�������o�͋敪
            temp.SlipTtlBillOutputDiv = reader.ReadInt32();



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
        /// <returns>CustomerWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                APCustomerWork temp = GetCustomerWork(reader, serInfo);
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
                    retValue = (APCustomerWork[])lst.ToArray(typeof(APCustomerWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}

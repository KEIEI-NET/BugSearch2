//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����M�Ώېݒ�}�X�^�����e�i���X
// �v���O�����T�v   : ����M�Ώېݒ�̕ύX���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2009/04/22  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11600006-00 �쐬�S�� : ���O
// �C �� ��  2020/09/25  �C�����e : PMKOBETSU-3877�̑Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SecMngSndRcv
    /// <summary>
    ///                      ���_�Ǘ�����M�Ώۃ}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���_�Ǘ�����M�Ώۃ}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/04/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   PMKOBETSU-3877�̑Ή�</br>
    /// <br>                 :   2020/09/25</br>
    /// </remarks>
    public class SecMngSndRcv
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

        /// <summary>�\������</summary>
        private Int32 _displayOrder;

        /// <summary>�}�X�^����</summary>
        private string _masterName = "";

        /// <summary>�t�@�C���h�c</summary>
        private string _fileId = "";

        /// <summary>�t�@�C������</summary>
        private string _fileNm = "";

        /// <summary>���[�U�[�K�C�h�敪</summary>
        private Int32 _userGuideDivCd;

        /// <summary>���_�Ǘ����M�敪</summary>
        /// <remarks>0:���M�Ȃ� 1:���M����</remarks>
        private Int32 _secMngSendDiv;

        /// <summary>���_�Ǘ���M�敪</summary>
        /// <remarks>0:��M�� 1:��M�L�i�ǉ��̂݁j 2:��M�L�i�ǉ��E�X�V�j</remarks>
        private Int32 _secMngRecvDiv;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------>>>>>
        /// <summary>�󒍃f�[�^���M�敪</summary>
        /// <remarks>0:���M�Ȃ� 1:���M����</remarks>
        private Int32 _acptAnOdrSendDiv;

        /// <summary>�󒍃f�[�^��M�敪</summary>
        /// <remarks>0:���M�Ȃ� 1:���M����</remarks>
        private Int32 _acptAnOdrRecvDiv;

        /// <summary>�ݏo�f�[�^���M�敪</summary>
        /// <remarks>0:���M�Ȃ� 1:���M����</remarks>
        private Int32 _shipmentSendDiv;

        /// <summary>�ݏo�f�[�^��M�敪</summary>
        /// <remarks>0:���M�Ȃ� 1:���M����</remarks>
        private Int32 _shipmentRecvDiv;

        /// <summary>���σf�[�^���M�敪</summary>
        /// <remarks>0:���M�Ȃ� 1:���M����</remarks>
        private Int32 _estimateSendDiv;

        /// <summary>���σf�[�^��M�敪</summary>
        /// <remarks>0:���M�Ȃ� 1:���M����</remarks>
        private Int32 _estimateRecvDiv;
        // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------<<<<<

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

        /// public propaty name  :  DisplayOrder
        /// <summary>�\�����ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �\�����ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DisplayOrder
        {
            get { return _displayOrder; }
            set { _displayOrder = value; }
        }

        /// public propaty name  :  MasterName
        /// <summary>�}�X�^���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �}�X�^���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MasterName
        {
            get { return _masterName; }
            set { _masterName = value; }
        }

        /// public propaty name  :  FileId
        /// <summary>�t�@�C���h�c�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�@�C���h�c�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FileId
        {
            get { return _fileId; }
            set { _fileId = value; }
        }

        /// public propaty name  :  FileNm
        /// <summary>�t�@�C�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�@�C�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FileNm
        {
            get { return _fileNm; }
            set { _fileNm = value; }
        }

        /// public propaty name  :  UserGuideDivCd
        /// <summary>���[�U�[�K�C�h�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�U�[�K�C�h�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UserGuideDivCd
        {
            get { return _userGuideDivCd; }
            set { _userGuideDivCd = value; }
        }

        /// public propaty name  :  SecMngSendDiv
        /// <summary>���_�Ǘ����M�敪�v���p�e�B</summary>
        /// <value>0:���M�Ȃ� 1:���M����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�Ǘ����M�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SecMngSendDiv
        {
            get { return _secMngSendDiv; }
            set { _secMngSendDiv = value; }
        }

        /// public propaty name  :  SecMngRecvDiv
        /// <summary>���_�Ǘ���M�敪�v���p�e�B</summary>
        /// <value>0:��M�� 1:��M�L�i�ǉ��̂݁j 2:��M�L�i�ǉ��E�X�V�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�Ǘ���M�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SecMngRecvDiv
        {
            get { return _secMngRecvDiv; }
            set { _secMngRecvDiv = value; }
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

        // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------>>>>>
        /// public propaty name  :  AcptAnOdrSendDiv
        /// <summary>�󒍃f�[�^���M�敪�v���p�e�B</summary>
        /// <value>0:���M�Ȃ� 1:���M����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃f�[�^���M�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcptAnOdrSendDiv
        {
            get { return _acptAnOdrSendDiv; }
            set { _acptAnOdrSendDiv = value; }
        }

        /// public propaty name  :  AcptAnOdrRecvDiv
        /// <summary>�󒍃f�[�^��M�敪�v���p�e�B</summary>
        /// <value>0:���M�Ȃ� 1:���M����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃f�[�^��M�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcptAnOdrRecvDiv
        {
            get { return _acptAnOdrRecvDiv; }
            set { _acptAnOdrRecvDiv = value; }
        }

        /// public propaty name  :  ShipmentSendDiv
        /// <summary>�ݏo�f�[�^���M�敪�v���p�e�B</summary>
        /// <value>0:���M�Ȃ� 1:���M����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ݏo�f�[�^���M�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ShipmentSendDiv
        {
            get { return _shipmentSendDiv; }
            set { _shipmentSendDiv = value; }
        }

        /// public propaty name  :  ShipmentRecvDiv
        /// <summary>�ݏo�f�[�^��M�敪�v���p�e�B</summary>
        /// <value>0:���M�Ȃ� 1:���M����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ݏo�f�[�^��M�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ShipmentRecvDiv
        {
            get { return _shipmentRecvDiv; }
            set { _shipmentRecvDiv = value; }
        }

        /// public propaty name  :  EstimateSendDiv
        /// <summary>���σf�[�^���M�敪�v���p�e�B</summary>
        /// <value>0:���M�Ȃ� 1:���M����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���σf�[�^���M�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EstimateSendDiv
        {
            get { return _estimateSendDiv; }
            set { _estimateSendDiv = value; }
        }

        /// public propaty name  :  EstimateRecvDiv
        /// <summary>���σf�[�^��M�敪�v���p�e�B</summary>
        /// <value>0:���M�Ȃ� 1:���M����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���σf�[�^��M�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EstimateRecvDiv
        {
            get { return _estimateRecvDiv; }
            set { _estimateRecvDiv = value; }
        }
        // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------<<<<<

        /// <summary>
        /// ���_�Ǘ�����M�Ώۃ}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>SecMngSndRcv�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SecMngSndRcv�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SecMngSndRcv()
        {
        }

        /// <summary>
        /// ���_�Ǘ�����M�Ώۃ}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="displayOrder">�\������</param>
        /// <param name="masterName">�}�X�^����</param>
        /// <param name="fileId">�t�@�C���h�c</param>
        /// <param name="fileNm">�t�@�C������</param>
        /// <param name="userGuideDivCd">���[�U�[�K�C�h�敪</param>
        /// <param name="secMngSendDiv">���_�Ǘ����M�敪(0:���M�Ȃ� 1:���M����)</param>
        /// <param name="secMngRecvDiv">���_�Ǘ���M�敪(0:��M�� 1:��M�L�i�ǉ��̂݁j 2:��M�L�i�ǉ��E�X�V�j)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="acptAnOdrSendDiv">�󒍃f�[�^���M�敪(0:���M�Ȃ� 1:���M����)</param>
        /// <param name="acptAnOdrRecvDiv">�󒍃f�[�^��M�敪(0:���M�Ȃ� 1:���M����)</param>
        /// <param name="shipmentSendDiv">�ݏo�f�[�^���M�敪(0:���M�Ȃ� 1:���M����)</param>
        /// <param name="shipmentRecvDiv">�ݏo�f�[�^��M�敪(0:���M�Ȃ� 1:���M����)</param>
        /// <param name="estimateSendDiv">���σf�[�^���M�敪(0:���M�Ȃ� 1:���M����)</param>
        /// <param name="estimateRecvDiv">���σf�[�^��M�敪(0:���M�Ȃ� 1:���M����)</param>
        /// <returns>SecMngSndRcv�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SecMngSndRcv�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        // UPD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------>>>>>
        //public SecMngSndRcv(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 displayOrder, string masterName, string fileId, string fileNm, Int32 userGuideDivCd, Int32 secMngSendDiv, Int32 secMngRecvDiv, string enterpriseName, string updEmployeeName)
        public SecMngSndRcv(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 displayOrder, string masterName, string fileId, string fileNm, Int32 userGuideDivCd, Int32 secMngSendDiv, Int32 secMngRecvDiv, string enterpriseName, string updEmployeeName, Int32 acptAnOdrSendDiv, Int32 acptAnOdrRecvDiv,Int32 shipmentSendDiv, Int32 shipmentRecvDiv, Int32 estimateSendDiv, Int32 estimateRecvDiv)
        // UPD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------<<<<<
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._displayOrder = displayOrder;
            this._masterName = masterName;
            this._fileId = fileId;
            this._fileNm = fileNm;
            this._userGuideDivCd = userGuideDivCd;
            this._secMngSendDiv = secMngSendDiv;
            this._secMngRecvDiv = secMngRecvDiv;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------>>>>>
            this._acptAnOdrSendDiv = acptAnOdrSendDiv;
            this._acptAnOdrRecvDiv = acptAnOdrRecvDiv;
            this._shipmentSendDiv = shipmentSendDiv;
            this._shipmentRecvDiv = shipmentRecvDiv;
            this._estimateSendDiv = estimateSendDiv;
            this._estimateRecvDiv = estimateRecvDiv;
            // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------<<<<<
        }

        /// <summary>
        /// ���_�Ǘ�����M�Ώۃ}�X�^��������
        /// </summary>
        /// <returns>SecMngSndRcv�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SecMngSndRcv�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SecMngSndRcv Clone()
        {
            // UPD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------>>>>>
            //return new SecMngSndRcv(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._displayOrder, this._masterName, this._fileId, this._fileNm, this._userGuideDivCd, this._secMngSendDiv, this._secMngRecvDiv, this._enterpriseName, this._updEmployeeNamethis);
            return new SecMngSndRcv(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._displayOrder, this._masterName, this._fileId, this._fileNm, this._userGuideDivCd, this._secMngSendDiv, this._secMngRecvDiv, this._enterpriseName, this._updEmployeeName, this._acptAnOdrSendDiv, this._acptAnOdrRecvDiv, this._shipmentSendDiv, this._shipmentRecvDiv, this._estimateSendDiv, this._estimateRecvDiv);
            // UPD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------<<<<<
        }

        /// <summary>
        /// ���_�Ǘ�����M�Ώۃ}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SecMngSndRcv�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SecMngSndRcv�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(SecMngSndRcv target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.DisplayOrder == target.DisplayOrder)
                 && (this.MasterName == target.MasterName)
                 && (this.FileId == target.FileId)
                 && (this.FileNm == target.FileNm)
                 && (this.UserGuideDivCd == target.UserGuideDivCd)
                 && (this.SecMngSendDiv == target.SecMngSendDiv)
                 && (this.SecMngRecvDiv == target.SecMngRecvDiv)
                 && (this.EnterpriseName == target.EnterpriseName)
                 // UPD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------>>>>>
                 //&& (this.UpdEmployeeName == target.UpdEmployeeName));
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.AcptAnOdrSendDiv == target.AcptAnOdrSendDiv)
                 && (this.AcptAnOdrRecvDiv == target.AcptAnOdrRecvDiv)
                 && (this.ShipmentSendDiv == target.ShipmentSendDiv)
                 && (this.ShipmentRecvDiv == target.ShipmentRecvDiv)
                 && (this.EstimateSendDiv == target.EstimateSendDiv)
                 && (this.EstimateRecvDiv == target.EstimateRecvDiv));
                 // UPD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------<<<<<
        }

        /// <summary>
        /// ���_�Ǘ�����M�Ώۃ}�X�^��r����
        /// </summary>
        /// <param name="secMngSndRcv1">
        ///                    ��r����SecMngSndRcv�N���X�̃C���X�^���X
        /// </param>
        /// <param name="secMngSndRcv2">��r����SecMngSndRcv�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SecMngSndRcv�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(SecMngSndRcv secMngSndRcv1, SecMngSndRcv secMngSndRcv2)
        {
            return ((secMngSndRcv1.CreateDateTime == secMngSndRcv2.CreateDateTime)
                 && (secMngSndRcv1.UpdateDateTime == secMngSndRcv2.UpdateDateTime)
                 && (secMngSndRcv1.EnterpriseCode == secMngSndRcv2.EnterpriseCode)
                 && (secMngSndRcv1.FileHeaderGuid == secMngSndRcv2.FileHeaderGuid)
                 && (secMngSndRcv1.UpdEmployeeCode == secMngSndRcv2.UpdEmployeeCode)
                 && (secMngSndRcv1.UpdAssemblyId1 == secMngSndRcv2.UpdAssemblyId1)
                 && (secMngSndRcv1.UpdAssemblyId2 == secMngSndRcv2.UpdAssemblyId2)
                 && (secMngSndRcv1.LogicalDeleteCode == secMngSndRcv2.LogicalDeleteCode)
                 && (secMngSndRcv1.DisplayOrder == secMngSndRcv2.DisplayOrder)
                 && (secMngSndRcv1.MasterName == secMngSndRcv2.MasterName)
                 && (secMngSndRcv1.FileId == secMngSndRcv2.FileId)
                 && (secMngSndRcv1.FileNm == secMngSndRcv2.FileNm)
                 && (secMngSndRcv1.UserGuideDivCd == secMngSndRcv2.UserGuideDivCd)
                 && (secMngSndRcv1.SecMngSendDiv == secMngSndRcv2.SecMngSendDiv)
                 && (secMngSndRcv1.SecMngRecvDiv == secMngSndRcv2.SecMngRecvDiv)
                 && (secMngSndRcv1.EnterpriseName == secMngSndRcv2.EnterpriseName)
                 // UPD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------>>>>>
                 //&& (secMngSndRcv1.UpdEmployeeName == secMngSndRcv2.UpdEmployeeName));
                 && (secMngSndRcv1.UpdEmployeeName == secMngSndRcv2.UpdEmployeeName)
                 && (secMngSndRcv1.AcptAnOdrSendDiv == secMngSndRcv2.AcptAnOdrSendDiv)
                 && (secMngSndRcv1.AcptAnOdrRecvDiv == secMngSndRcv2.AcptAnOdrRecvDiv)
                 && (secMngSndRcv1.ShipmentSendDiv == secMngSndRcv2.ShipmentSendDiv)
                 && (secMngSndRcv1.ShipmentRecvDiv == secMngSndRcv2.ShipmentRecvDiv)
                 && (secMngSndRcv1.EstimateSendDiv == secMngSndRcv2.EstimateSendDiv)
                 && (secMngSndRcv1.EstimateRecvDiv == secMngSndRcv2.EstimateRecvDiv));
                 // UPD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------<<<<<
        }
        /// <summary>
        /// ���_�Ǘ�����M�Ώۃ}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SecMngSndRcv�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SecMngSndRcv�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(SecMngSndRcv target)
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
            if (this.DisplayOrder != target.DisplayOrder) resList.Add("DisplayOrder");
            if (this.MasterName != target.MasterName) resList.Add("MasterName");
            if (this.FileId != target.FileId) resList.Add("FileId");
            if (this.FileNm != target.FileNm) resList.Add("FileNm");
            if (this.UserGuideDivCd != target.UserGuideDivCd) resList.Add("UserGuideDivCd");
            if (this.SecMngSendDiv != target.SecMngSendDiv) resList.Add("SecMngSendDiv");
            if (this.SecMngRecvDiv != target.SecMngRecvDiv) resList.Add("SecMngRecvDiv");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------>>>>>
            if (this.AcptAnOdrSendDiv != target.AcptAnOdrSendDiv) resList.Add("AcptAnOdrSendDiv");
            if (this.AcptAnOdrRecvDiv != target.AcptAnOdrRecvDiv) resList.Add("AcptAnOdrRecvDiv");
            if (this.ShipmentSendDiv != target.ShipmentSendDiv) resList.Add("ShipmentSendDiv");
            if (this.ShipmentRecvDiv != target.ShipmentRecvDiv) resList.Add("ShipmentRecvDiv");
            if (this.EstimateSendDiv != target.EstimateSendDiv) resList.Add("EstimateSendDiv");
            if (this.EstimateRecvDiv != target.EstimateRecvDiv) resList.Add("EstimateRecvDiv");
            // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------<<<<<
            return resList;
        }

        /// <summary>
        /// ���_�Ǘ�����M�Ώۃ}�X�^��r����
        /// </summary>
        /// <param name="secMngSndRcv1">��r����SecMngSndRcv�N���X�̃C���X�^���X</param>
        /// <param name="secMngSndRcv2">��r����SecMngSndRcv�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SecMngSndRcv�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(SecMngSndRcv secMngSndRcv1, SecMngSndRcv secMngSndRcv2)
        {
            ArrayList resList = new ArrayList();
            if (secMngSndRcv1.CreateDateTime != secMngSndRcv2.CreateDateTime) resList.Add("CreateDateTime");
            if (secMngSndRcv1.UpdateDateTime != secMngSndRcv2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (secMngSndRcv1.EnterpriseCode != secMngSndRcv2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (secMngSndRcv1.FileHeaderGuid != secMngSndRcv2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (secMngSndRcv1.UpdEmployeeCode != secMngSndRcv2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (secMngSndRcv1.UpdAssemblyId1 != secMngSndRcv2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (secMngSndRcv1.UpdAssemblyId2 != secMngSndRcv2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (secMngSndRcv1.LogicalDeleteCode != secMngSndRcv2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (secMngSndRcv1.DisplayOrder != secMngSndRcv2.DisplayOrder) resList.Add("DisplayOrder");
            if (secMngSndRcv1.MasterName != secMngSndRcv2.MasterName) resList.Add("MasterName");
            if (secMngSndRcv1.FileId != secMngSndRcv2.FileId) resList.Add("FileId");
            if (secMngSndRcv1.FileNm != secMngSndRcv2.FileNm) resList.Add("FileNm");
            if (secMngSndRcv1.UserGuideDivCd != secMngSndRcv2.UserGuideDivCd) resList.Add("UserGuideDivCd");
            if (secMngSndRcv1.SecMngSendDiv != secMngSndRcv2.SecMngSendDiv) resList.Add("SecMngSendDiv");
            if (secMngSndRcv1.SecMngRecvDiv != secMngSndRcv2.SecMngRecvDiv) resList.Add("SecMngRecvDiv");
            if (secMngSndRcv1.EnterpriseName != secMngSndRcv2.EnterpriseName) resList.Add("EnterpriseName");
            if (secMngSndRcv1.UpdEmployeeName != secMngSndRcv2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------>>>>>
            if (secMngSndRcv1.AcptAnOdrSendDiv != secMngSndRcv2.AcptAnOdrSendDiv) resList.Add("AcptAnOdrSendDiv");
            if (secMngSndRcv1.AcptAnOdrRecvDiv != secMngSndRcv2.AcptAnOdrRecvDiv) resList.Add("AcptAnOdrRecvDiv");
            if (secMngSndRcv1.ShipmentSendDiv != secMngSndRcv2.ShipmentSendDiv) resList.Add("ShipmentSendDiv");
            if (secMngSndRcv1.ShipmentRecvDiv != secMngSndRcv2.ShipmentRecvDiv) resList.Add("ShipmentRecvDiv");
            if (secMngSndRcv1.EstimateSendDiv != secMngSndRcv2.EstimateSendDiv) resList.Add("EstimateSendDiv");
            if (secMngSndRcv1.EstimateRecvDiv != secMngSndRcv2.EstimateRecvDiv) resList.Add("EstimateRecvDiv");
            // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------<<<<<

            return resList;
        }
    }
}

//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����[�g�`���ݒ�}�X�^ �f�[�^�N���X
// �v���O�����T�v   : �����[�g�`���ݒ�}�X�^ �f�[�^�N���X�f�[�^�p�����[�^
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��������
// �� �� ��  2011.08.03  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : zhouzy
// �C �� ��              �C�����e : �����[�g�`���@�]���ݒ�̎d�l�ύX
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   RmSlpPrtSt
    /// <summary>
    ///                      �����[�g�`���ݒ�}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   �����[�g�`���ݒ�}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2011.07.21</br>
    /// <br>Genarated Date   :   2011.08.03  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class RmSlpPrtSt
    {
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

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

        /// <summary>�⍇������ƃR�[�h</summary>
        private string _inqOriginalEpCd = "";

        /// <summary>�⍇�������_�R�[�h</summary>
        private string _inqOriginalSecCd = "";

        /// <summary>�⍇�����ƃR�[�h</summary>
        private string _inqOtherEpCd = "";

        /// <summary>�⍇���拒�_�R�[�h</summary>
        private string _inqOtherSecCd = "";

        /// <summary>PCC���ЃR�[�h</summary>
        /// <remarks>PM�̓��Ӑ�R�[�h</remarks>
        private Int32 _pccCompanyCode;

        /// <summary>�`�[������</summary>
        /// <remarks>30:�[�i��160:UOE�`�[</remarks>
        private Int32 _slipPrtKind;

        /// <summary>�`�[����ݒ�p���[ID</summary>
        /// <remarks>�`�[����ݒ�p</remarks>
        private string _slipPrtSetPaperId = "";

        /// <summary>�����[�g�`���敪</summary>
        /// <remarks>0:���s���Ȃ�, 1:���s����</remarks>
        private Int32 _rmtSlpPrtDiv;

        // 2011.09.16 zhouzy UPDATE STA >>>>>>
        /// <summary>��]��</summary>
        /// <remarks>��]��</remarks>
        private double _topMargin;

        /// <summary>���]��</summary>
        /// <remarks>���]��</remarks>
        private double _leftMargin;
        // 2011.09.16 zhouzy UPDATE END <<<<<<

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

        /// public propaty name  :  InqOriginalEpCd
        /// <summary>�⍇������ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇������ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOriginalEpCd
        {
            get { return _inqOriginalEpCd; }
            set { _inqOriginalEpCd = value; }
        }

        /// public propaty name  :  InqOriginalSecCd
        /// <summary>�⍇�������_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇�������_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOriginalSecCd
        {
            get { return _inqOriginalSecCd; }
            set { _inqOriginalSecCd = value; }
        }

        /// public propaty name  :  InqOtherEpCd
        /// <summary>�⍇�����ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇�����ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOtherEpCd
        {
            get { return _inqOtherEpCd; }
            set { _inqOtherEpCd = value; }
        }

        /// public propaty name  :  InqOtherSecCd
        /// <summary>�⍇���拒�_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���拒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOtherSecCd
        {
            get { return _inqOtherSecCd; }
            set { _inqOtherSecCd = value; }
        }

        /// public propaty name  :  PccCompanyCode
        /// <summary>PCC���ЃR�[�h�v���p�e�B</summary>
        /// <value>PM�̓��Ӑ�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC���ЃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PccCompanyCode
        {
            get { return _pccCompanyCode; }
            set { _pccCompanyCode = value; }
        }

        /// public propaty name  :  SlipPrtKind
        /// <summary>�`�[�����ʃv���p�e�B</summary>
        /// <value>30:�[�i��160:UOE�`�[</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�����ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipPrtKind
        {
            get { return _slipPrtKind; }
            set { _slipPrtKind = value; }
        }

        /// public propaty name  :  SlipPrtSetPaperId
        /// <summary>�`�[����ݒ�p���[ID�v���p�e�B</summary>
        /// <value>�`�[����ݒ�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[����ݒ�p���[ID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipPrtSetPaperId
        {
            get { return _slipPrtSetPaperId; }
            set { _slipPrtSetPaperId = value; }
        }

        /// public propaty name  :  RmtSlpPrtDiv
        /// <summary>�����[�g�`���敪�v���p�e�B</summary>
        /// <value>0:���s���Ȃ�, 1:���s����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����[�g�`���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RmtSlpPrtDiv
        {
            get { return _rmtSlpPrtDiv; }
            set { _rmtSlpPrtDiv = value; }
        }
        // 2011.09.16 zhouzy UPDATE STA >>>>>>
        /// public propaty name  :  TopMargin
        /// <summary>��]���v���p�e�B</summary>
        /// <value>��]��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��]���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public double TopMargin
        {
            get { return _topMargin; }
            set { _topMargin = value; }
        }

        /// public propaty name  :  TopMargin
        /// <summary>���]���v���p�e�B</summary>
        /// <value>���]��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���]���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public double LeftMargin
        {
            get { return _leftMargin; }
            set { _leftMargin = value; }
        }
        // 2011.09.16 zhouzy UPDATE END <<<<<<

        /// <summary>
        /// �����[�g�`���ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>RmSlpPrtSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RmSlpPrtSt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RmSlpPrtSt()
        {
        }

        /// <summary>
        /// �����[�g�`���ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="fileHeaderGuid">GUID</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2</param>
        /// <param name="inqOriginalEpCd">�⍇������ƃR�[�h</param>
        /// <param name="inqOriginalSecCd">�⍇�������_�R�[�h</param>
        /// <param name="inqOtherEpCd">�⍇�����ƃR�[�h</param>
        /// <param name="inqOtherSecCd">�⍇���拒�_�R�[�h</param>
        /// <param name="pccCompanyCode">PCC���ЃR�[�h(PM�̓��Ӑ�R�[�h)</param>
        /// <param name="slipPrtKind">�`�[������(30:�[�i��160:UOE�`�[)</param>
        /// <param name="slipPrtSetPaperId">�`�[����ݒ�p���[ID(�`�[����ݒ�p)</param>
        /// <param name="rmtSlpPrtDiv">�����[�g�`���敪(0:���s���Ȃ�, 1:���s����)</param>
        /// <param name="topMargin">���]��</param>
        /// <param name="leftMargin">���]��</param>
        /// <returns>RmSlpPrtSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RmSlpPrtSt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RmSlpPrtSt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int32 pccCompanyCode, Int32 slipPrtKind, string slipPrtSetPaperId, Int32 rmtSlpPrtDiv, double topMargin, double leftMargin)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._logicalDeleteCode = logicalDeleteCode;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._inqOriginalEpCd = inqOriginalEpCd.Trim();//@@@@20230303
            this._inqOriginalSecCd = inqOriginalSecCd;
            this._inqOtherEpCd = inqOtherEpCd;
            this._inqOtherSecCd = inqOtherSecCd;
            this._pccCompanyCode = pccCompanyCode;
            this._slipPrtKind = slipPrtKind;
            this._slipPrtSetPaperId = slipPrtSetPaperId;
            this._rmtSlpPrtDiv = rmtSlpPrtDiv;
            this._topMargin = topMargin;
            this._leftMargin = leftMargin;
        }

        /// <summary>
        /// �����[�g�`���ݒ�}�X�^��������
        /// </summary>
        /// <returns>RmSlpPrtSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����RmSlpPrtSt�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RmSlpPrtSt Clone()
        {
            return new RmSlpPrtSt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._inqOriginalEpCd.Trim(), this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._pccCompanyCode, this._slipPrtKind, this._slipPrtSetPaperId, this._rmtSlpPrtDiv,this._topMargin,this._leftMargin);//@@@@20230303
        }

        /// <summary>
        /// �����[�g�`���ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�RmSlpPrtSt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RmSlpPrtSt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(RmSlpPrtSt target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.InqOriginalEpCd.Trim() == target.InqOriginalEpCd.Trim())//@@@@20230303
                 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
                 && (this.InqOtherEpCd == target.InqOtherEpCd)
                 && (this.InqOtherSecCd == target.InqOtherSecCd)
                 && (this.PccCompanyCode == target.PccCompanyCode)
                 && (this.SlipPrtKind == target.SlipPrtKind)
                 && (this.SlipPrtSetPaperId == target.SlipPrtSetPaperId)
                 && (this.RmtSlpPrtDiv == target.RmtSlpPrtDiv)
                 && (this.TopMargin == target.TopMargin)
                 && (this.LeftMargin == target.LeftMargin));
        }

        /// <summary>
        /// �����[�g�`���ݒ�}�X�^��r����
        /// </summary>
        /// <param name="rmSlpPrtSt1">
        ///                    ��r����RmSlpPrtSt�N���X�̃C���X�^���X
        /// </param>
        /// <param name="rmSlpPrtSt2">��r����RmSlpPrtSt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RmSlpPrtSt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(RmSlpPrtSt rmSlpPrtSt1, RmSlpPrtSt rmSlpPrtSt2)
        {
            return ((rmSlpPrtSt1.CreateDateTime == rmSlpPrtSt2.CreateDateTime)
                 && (rmSlpPrtSt1.UpdateDateTime == rmSlpPrtSt2.UpdateDateTime)
                 && (rmSlpPrtSt1.LogicalDeleteCode == rmSlpPrtSt2.LogicalDeleteCode)
                 && (rmSlpPrtSt1.InqOriginalEpCd.Trim() == rmSlpPrtSt2.InqOriginalEpCd.Trim())//@@@@20230303
                 && (rmSlpPrtSt1.InqOriginalSecCd == rmSlpPrtSt2.InqOriginalSecCd)
                 && (rmSlpPrtSt1.InqOtherEpCd == rmSlpPrtSt2.InqOtherEpCd)
                 && (rmSlpPrtSt1.InqOtherSecCd == rmSlpPrtSt2.InqOtherSecCd)
                 && (rmSlpPrtSt1.PccCompanyCode == rmSlpPrtSt2.PccCompanyCode)
                 && (rmSlpPrtSt1.SlipPrtKind == rmSlpPrtSt2.SlipPrtKind)
                 && (rmSlpPrtSt1.SlipPrtSetPaperId == rmSlpPrtSt2.SlipPrtSetPaperId)
                 && (rmSlpPrtSt1.RmtSlpPrtDiv == rmSlpPrtSt2.RmtSlpPrtDiv)
                 && (rmSlpPrtSt1.TopMargin == rmSlpPrtSt2.TopMargin)
                 && (rmSlpPrtSt1.LeftMargin == rmSlpPrtSt2.LeftMargin));
        }
        /// <summary>
        /// �����[�g�`���ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�RmSlpPrtSt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RmSlpPrtSt�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(RmSlpPrtSt target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.InqOriginalEpCd.Trim() != target.InqOriginalEpCd.Trim()) resList.Add("InqOriginalEpCd");//@@@@20230303
            if (this.InqOriginalSecCd != target.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (this.InqOtherEpCd != target.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (this.InqOtherSecCd != target.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (this.PccCompanyCode != target.PccCompanyCode) resList.Add("PccCompanyCode");
            if (this.SlipPrtKind != target.SlipPrtKind) resList.Add("SlipPrtKind");
            if (this.SlipPrtSetPaperId != target.SlipPrtSetPaperId) resList.Add("SlipPrtSetPaperId");
            if (this.RmtSlpPrtDiv != target.RmtSlpPrtDiv) resList.Add("RmtSlpPrtDiv");
            if (this.TopMargin != target.TopMargin) resList.Add("TopMargin");
            if (this.LeftMargin != target.LeftMargin) resList.Add("LeftMargin");

            return resList;
        }

        /// <summary>
        /// �����[�g�`���ݒ�}�X�^��r����
        /// </summary>
        /// <param name="rmSlpPrtSt1">��r����RmSlpPrtSt�N���X�̃C���X�^���X</param>
        /// <param name="rmSlpPrtSt2">��r����RmSlpPrtSt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RmSlpPrtSt�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(RmSlpPrtSt rmSlpPrtSt1, RmSlpPrtSt rmSlpPrtSt2)
        {
            ArrayList resList = new ArrayList();
            if (rmSlpPrtSt1.CreateDateTime != rmSlpPrtSt2.CreateDateTime) resList.Add("CreateDateTime");
            if (rmSlpPrtSt1.UpdateDateTime != rmSlpPrtSt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (rmSlpPrtSt1.LogicalDeleteCode != rmSlpPrtSt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (rmSlpPrtSt1.InqOriginalEpCd.Trim() != rmSlpPrtSt2.InqOriginalEpCd.Trim()) resList.Add("InqOriginalEpCd");//@@@@20230303
            if (rmSlpPrtSt1.InqOriginalSecCd != rmSlpPrtSt2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (rmSlpPrtSt1.InqOtherEpCd != rmSlpPrtSt2.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (rmSlpPrtSt1.InqOtherSecCd != rmSlpPrtSt2.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (rmSlpPrtSt1.PccCompanyCode != rmSlpPrtSt2.PccCompanyCode) resList.Add("PccCompanyCode");
            if (rmSlpPrtSt1.SlipPrtKind != rmSlpPrtSt2.SlipPrtKind) resList.Add("SlipPrtKind");
            if (rmSlpPrtSt1.SlipPrtSetPaperId != rmSlpPrtSt2.SlipPrtSetPaperId) resList.Add("SlipPrtSetPaperId");
            if (rmSlpPrtSt1.RmtSlpPrtDiv != rmSlpPrtSt2.RmtSlpPrtDiv) resList.Add("RmtSlpPrtDiv");
            if (rmSlpPrtSt1.TopMargin != rmSlpPrtSt2.TopMargin) resList.Add("TopMargin");
            if (rmSlpPrtSt1.LeftMargin != rmSlpPrtSt2.LeftMargin) resList.Add("LeftMargin");

            return resList;
        }
    }
}

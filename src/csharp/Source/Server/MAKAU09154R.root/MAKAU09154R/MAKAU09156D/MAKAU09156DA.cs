using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   DmdPrtPtnWork
    /// <summary>
    ///                      ����������p�^�[�����[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ����������p�^�[�����[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/26</br>
    /// <br>Genarated Date   :   2008/06/09  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2010/02/18  30531 ���r��</br>
    /// <br>                 :   ���߈󎚋敪�ǉ�</br> 
    /// <br>Update Note      :   2011/02/16  �{�w�C��</br> 																								
    /// <br>                 :   ���Ж��󎚋敪��ǉ�</br> 																								
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class DmdPrtPtnWork : IFileHeader
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

        /// <summary>�X�V�A�Z���u��ID1</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>�f�[�^���̓V�X�e��</summary>
        /// <remarks>0:����,1:����,2:���,3:�Ԕ�</remarks>
        private Int32 _dataInputSystem;

        /// <summary>�`�[������</summary>
        /// <remarks>50:���v������,60:���א�����,70:�`�[���v������,80:�̎���</remarks>
        private Int32 _slipPrtKind;

        /// <summary>�`�[����ݒ�p���[ID</summary>
        /// <remarks>�`�[����ݒ�p</remarks>
        private string _slipPrtSetPaperId = "";

        /// <summary>�`�[�R�����g</summary>
        private string _slipComment = "";

        /// <summary>�o�̓t�@�C����</summary>
        /// <remarks>�t�H�[���t�@�C��ID or �t�H�[�}�b�g�t�@�C��ID</remarks>
        private string _outputFormFileName = "";

        /// <summary>��]��</summary>
        /// <remarks>cm�Ŏw��B�}�C�i�X���͕s�B�L�������͏����_��P�ʂ܂Łi��0.8)</remarks>
        private Double _topMargin;

        /// <summary>���]��</summary>
        /// <remarks>cm�Ŏw��B�}�C�i�X���͕s�B�L�������͏����_��P�ʂ܂Łi��0.8)</remarks>
        private Double _leftMargin;

        /// <summary>�E�]��</summary>
        private Double _rightMargin;

        /// <summary>���]��</summary>
        private Double _bottomMargin;

        /// <summary>���ʖ���</summary>
        private Int32 _copyCount;

        /// <summary>���� �Ӄ^�C�g���P</summary>
        private string _dmdTtlFormTitle1 = "";

        /// <summary>���� �Ӄ^�C�g���Q</summary>
        private string _dmdTtlFormTitle2 = "";

        /// <summary>���� �Ӄ^�C�g���R</summary>
        private string _dmdTtlFormTitle3 = "";

        /// <summary>���� �Ӄ^�C�g���S</summary>
        private string _dmdTtlFormTitle4 = "";

        /// <summary>���� �Ӄ^�C�g���T</summary>
        private string _dmdTtlFormTitle5 = "";

        /// <summary>���� �Ӄ^�C�g���U</summary>
        private string _dmdTtlFormTitle6 = "";

        /// <summary>���� �Ӄ^�C�g���V</summary>
        private string _dmdTtlFormTitle7 = "";

        /// <summary>���� �Ӄ^�C�g���W</summary>
        private string _dmdTtlFormTitle8 = "";

        /// <summary>���� �Ӑݒ荀�ڋ敪�P</summary>
        private Int32 _dmdTtlSetItemDiv1;

        /// <summary>���� �Ӑݒ荀�ڋ敪�Q</summary>
        private Int32 _dmdTtlSetItemDiv2;

        /// <summary>���� �Ӑݒ荀�ڋ敪�R</summary>
        private Int32 _dmdTtlSetItemDiv3;

        /// <summary>���� �Ӑݒ荀�ڋ敪�S</summary>
        private Int32 _dmdTtlSetItemDiv4;

        /// <summary>���� �Ӑݒ荀�ڋ敪�T</summary>
        private Int32 _dmdTtlSetItemDiv5;

        /// <summary>���� �Ӑݒ荀�ڋ敪�U</summary>
        private Int32 _dmdTtlSetItemDiv6;

        /// <summary>���� �Ӑݒ荀�ڋ敪�V</summary>
        private Int32 _dmdTtlSetItemDiv7;

        /// <summary>���� �Ӑݒ荀�ڋ敪�W</summary>
        private Int32 _dmdTtlSetItemDiv8;

        /// <summary>�������^�C�g��</summary>
        private string _dmdFormTitle = "";

        /// <summary>�������^�C�g���Q</summary>
        /// <remarks>�T��</remarks>
        private string _dmdFormTitle2 = "";

        /// <summary>�������R�����g�P</summary>
        private string _dmdFormComent1 = "";

        /// <summary>�������R�����g�Q</summary>
        private string _dmdFormComent2 = "";

        /// <summary>�������R�����g�R</summary>
        private string _dmdFormComent3 = "";

        /// <summary>�������דE�v�敪</summary>
        /// <remarks>0:�󎚂��Ȃ� 1:�i�� 2:�艿</remarks>
        private Int32 _dmdDtlOutlineCode;

        /// <summary>�������׏��󎚏��ʋ敪</summary>
        /// <remarks>0:�v���+�`�[�ԍ� 1:���Ӑ�+�v���+�`�[�ԍ�</remarks>
        private Int32 _dmdDtlPtnOdrDiv;

        /// <summary>�`�[�v�󎚗L��</summary>
        /// <remarks>0:�󎚂��� 1:�󎚂��Ȃ�</remarks>
        private Int32 _slipTtlPrtDiv;

        /// <summary>�v����v�󎚗L��</summary>
        /// <remarks>0:�󎚂��� 1:�󎚂��Ȃ�</remarks>
        private Int32 _addDayTtlPrtDiv;

        /// <summary>���Ӑ�v�󎚗L��</summary>
        /// <remarks>0:�󎚂��� 1:�󎚂��Ȃ�</remarks>
        private Int32 _customerTtlPrtDiv;

        /// <summary>���׋��z�[�����󎚗L��</summary>
        /// <remarks>0:�󎚂��� 1:�󎚂��Ȃ�</remarks>
        private Int32 _dtlPrcZeroPrtDiv;

        /// <summary>�������׈󎚗L���敪</summary>
        /// <remarks>0:�󎚂��Ȃ� 1:�󎚂���(���v)  1:�󎚂��� (����)</remarks>
        private Int32 _depoDtlPrcPrtDiv;

        /// <summary>�������h��</summary>
        /// <remarks>�������p�̌h��</remarks>
        private string _billHonorificTtl = "";

        /// <summary>�W�����i�󎚋敪</summary>
        /// <remarks>0:�󎚂��Ȃ� 1:�󎚂��� 2:�|�����P</remarks>
        private Int32 _listPricePrtCd;

        /// <summary>�i�Ԉ󎚋敪</summary>
        /// <remarks>0:�󎚂��Ȃ�,1:�󎚂���</remarks>
        private Int32 _partsNoPrtCd;

        // --- ADD  ���r��  2010/02/18 ---------->>>>>
        /// <summary>���߈󎚋敪</summary>
        /// <remarks>0:�󎚂���,1:�󎚂��Ȃ�</remarks>
        private Int32 _annotationPrtCd;
        // --- ADD  ���r��  2010/02/18 ----------<<<<<

        // --- ADD  2011/02/16 ---------->>>>>
        /// <summary>���Ж��󎚋敪</summary>
        /// <remarks>0:�W��1:���Ж�2:���_��3:�r�b�g�}�b�v4:�󎚂��Ȃ�</remarks>
        private Int32 _coNmPrintOutCd;
        // --- ADD  2011/02/16 ----------<<<<<

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
        /// <summary>�X�V�A�Z���u��ID1�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID1�v���p�e�B</br>
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

        /// public propaty name  :  DataInputSystem
        /// <summary>�f�[�^���̓V�X�e���v���p�e�B</summary>
        /// <value>0:����,1:����,2:���,3:�Ԕ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^���̓V�X�e���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DataInputSystem
        {
            get { return _dataInputSystem; }
            set { _dataInputSystem = value; }
        }

        /// public propaty name  :  SlipPrtKind
        /// <summary>�`�[�����ʃv���p�e�B</summary>
        /// <value>50:���v������,60:���א�����,70:�`�[���v������,80:�̎���</value>
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

        /// public propaty name  :  SlipComment
        /// <summary>�`�[�R�����g�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�R�����g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipComment
        {
            get { return _slipComment; }
            set { _slipComment = value; }
        }

        /// public propaty name  :  OutputFormFileName
        /// <summary>�o�̓t�@�C�����v���p�e�B</summary>
        /// <value>�t�H�[���t�@�C��ID or �t�H�[�}�b�g�t�@�C��ID</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�̓t�@�C�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OutputFormFileName
        {
            get { return _outputFormFileName; }
            set { _outputFormFileName = value; }
        }

        /// public propaty name  :  TopMargin
        /// <summary>��]���v���p�e�B</summary>
        /// <value>cm�Ŏw��B�}�C�i�X���͕s�B�L�������͏����_��P�ʂ܂Łi��0.8)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��]���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TopMargin
        {
            get { return _topMargin; }
            set { _topMargin = value; }
        }

        /// public propaty name  :  LeftMargin
        /// <summary>���]���v���p�e�B</summary>
        /// <value>cm�Ŏw��B�}�C�i�X���͕s�B�L�������͏����_��P�ʂ܂Łi��0.8)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���]���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double LeftMargin
        {
            get { return _leftMargin; }
            set { _leftMargin = value; }
        }

        /// public propaty name  :  RightMargin
        /// <summary>�E�]���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �E�]���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double RightMargin
        {
            get { return _rightMargin; }
            set { _rightMargin = value; }
        }

        /// public propaty name  :  BottomMargin
        /// <summary>���]���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���]���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double BottomMargin
        {
            get { return _bottomMargin; }
            set { _bottomMargin = value; }
        }

        /// public propaty name  :  CopyCount
        /// <summary>���ʖ����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ʖ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CopyCount
        {
            get { return _copyCount; }
            set { _copyCount = value; }
        }

        /// public propaty name  :  DmdTtlFormTitle1
        /// <summary>���� �Ӄ^�C�g���P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���� �Ӄ^�C�g���P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DmdTtlFormTitle1
        {
            get { return _dmdTtlFormTitle1; }
            set { _dmdTtlFormTitle1 = value; }
        }

        /// public propaty name  :  DmdTtlFormTitle2
        /// <summary>���� �Ӄ^�C�g���Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���� �Ӄ^�C�g���Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DmdTtlFormTitle2
        {
            get { return _dmdTtlFormTitle2; }
            set { _dmdTtlFormTitle2 = value; }
        }

        /// public propaty name  :  DmdTtlFormTitle3
        /// <summary>���� �Ӄ^�C�g���R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���� �Ӄ^�C�g���R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DmdTtlFormTitle3
        {
            get { return _dmdTtlFormTitle3; }
            set { _dmdTtlFormTitle3 = value; }
        }

        /// public propaty name  :  DmdTtlFormTitle4
        /// <summary>���� �Ӄ^�C�g���S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���� �Ӄ^�C�g���S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DmdTtlFormTitle4
        {
            get { return _dmdTtlFormTitle4; }
            set { _dmdTtlFormTitle4 = value; }
        }

        /// public propaty name  :  DmdTtlFormTitle5
        /// <summary>���� �Ӄ^�C�g���T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���� �Ӄ^�C�g���T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DmdTtlFormTitle5
        {
            get { return _dmdTtlFormTitle5; }
            set { _dmdTtlFormTitle5 = value; }
        }

        /// public propaty name  :  DmdTtlFormTitle6
        /// <summary>���� �Ӄ^�C�g���U�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���� �Ӄ^�C�g���U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DmdTtlFormTitle6
        {
            get { return _dmdTtlFormTitle6; }
            set { _dmdTtlFormTitle6 = value; }
        }

        /// public propaty name  :  DmdTtlFormTitle7
        /// <summary>���� �Ӄ^�C�g���V�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���� �Ӄ^�C�g���V�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DmdTtlFormTitle7
        {
            get { return _dmdTtlFormTitle7; }
            set { _dmdTtlFormTitle7 = value; }
        }

        /// public propaty name  :  DmdTtlFormTitle8
        /// <summary>���� �Ӄ^�C�g���W�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���� �Ӄ^�C�g���W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DmdTtlFormTitle8
        {
            get { return _dmdTtlFormTitle8; }
            set { _dmdTtlFormTitle8 = value; }
        }

        /// public propaty name  :  DmdTtlSetItemDiv1
        /// <summary>���� �Ӑݒ荀�ڋ敪�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���� �Ӑݒ荀�ڋ敪�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DmdTtlSetItemDiv1
        {
            get { return _dmdTtlSetItemDiv1; }
            set { _dmdTtlSetItemDiv1 = value; }
        }

        /// public propaty name  :  DmdTtlSetItemDiv2
        /// <summary>���� �Ӑݒ荀�ڋ敪�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���� �Ӑݒ荀�ڋ敪�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DmdTtlSetItemDiv2
        {
            get { return _dmdTtlSetItemDiv2; }
            set { _dmdTtlSetItemDiv2 = value; }
        }

        /// public propaty name  :  DmdTtlSetItemDiv3
        /// <summary>���� �Ӑݒ荀�ڋ敪�R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���� �Ӑݒ荀�ڋ敪�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DmdTtlSetItemDiv3
        {
            get { return _dmdTtlSetItemDiv3; }
            set { _dmdTtlSetItemDiv3 = value; }
        }

        /// public propaty name  :  DmdTtlSetItemDiv4
        /// <summary>���� �Ӑݒ荀�ڋ敪�S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���� �Ӑݒ荀�ڋ敪�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DmdTtlSetItemDiv4
        {
            get { return _dmdTtlSetItemDiv4; }
            set { _dmdTtlSetItemDiv4 = value; }
        }

        /// public propaty name  :  DmdTtlSetItemDiv5
        /// <summary>���� �Ӑݒ荀�ڋ敪�T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���� �Ӑݒ荀�ڋ敪�T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DmdTtlSetItemDiv5
        {
            get { return _dmdTtlSetItemDiv5; }
            set { _dmdTtlSetItemDiv5 = value; }
        }

        /// public propaty name  :  DmdTtlSetItemDiv6
        /// <summary>���� �Ӑݒ荀�ڋ敪�U�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���� �Ӑݒ荀�ڋ敪�U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DmdTtlSetItemDiv6
        {
            get { return _dmdTtlSetItemDiv6; }
            set { _dmdTtlSetItemDiv6 = value; }
        }

        /// public propaty name  :  DmdTtlSetItemDiv7
        /// <summary>���� �Ӑݒ荀�ڋ敪�V�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���� �Ӑݒ荀�ڋ敪�V�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DmdTtlSetItemDiv7
        {
            get { return _dmdTtlSetItemDiv7; }
            set { _dmdTtlSetItemDiv7 = value; }
        }

        /// public propaty name  :  DmdTtlSetItemDiv8
        /// <summary>���� �Ӑݒ荀�ڋ敪�W�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���� �Ӑݒ荀�ڋ敪�W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DmdTtlSetItemDiv8
        {
            get { return _dmdTtlSetItemDiv8; }
            set { _dmdTtlSetItemDiv8 = value; }
        }

        /// public propaty name  :  DmdFormTitle
        /// <summary>�������^�C�g���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������^�C�g���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DmdFormTitle
        {
            get { return _dmdFormTitle; }
            set { _dmdFormTitle = value; }
        }

        /// public propaty name  :  DmdFormTitle2
        /// <summary>�������^�C�g���Q�v���p�e�B</summary>
        /// <value>�T��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������^�C�g���Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DmdFormTitle2
        {
            get { return _dmdFormTitle2; }
            set { _dmdFormTitle2 = value; }
        }

        /// public propaty name  :  DmdFormComent1
        /// <summary>�������R�����g�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������R�����g�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DmdFormComent1
        {
            get { return _dmdFormComent1; }
            set { _dmdFormComent1 = value; }
        }

        /// public propaty name  :  DmdFormComent2
        /// <summary>�������R�����g�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������R�����g�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DmdFormComent2
        {
            get { return _dmdFormComent2; }
            set { _dmdFormComent2 = value; }
        }

        /// public propaty name  :  DmdFormComent3
        /// <summary>�������R�����g�R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������R�����g�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DmdFormComent3
        {
            get { return _dmdFormComent3; }
            set { _dmdFormComent3 = value; }
        }

        /// public propaty name  :  DmdDtlOutlineCode
        /// <summary>�������דE�v�敪�v���p�e�B</summary>
        /// <value>0:�󎚂��Ȃ� 1:�i�� 2:�艿</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������דE�v�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DmdDtlOutlineCode
        {
            get { return _dmdDtlOutlineCode; }
            set { _dmdDtlOutlineCode = value; }
        }

        /// public propaty name  :  DmdDtlPtnOdrDiv
        /// <summary>�������׏��󎚏��ʋ敪�v���p�e�B</summary>
        /// <value>0:�v���+�`�[�ԍ� 1:���Ӑ�+�v���+�`�[�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������׏��󎚏��ʋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DmdDtlPtnOdrDiv
        {
            get { return _dmdDtlPtnOdrDiv; }
            set { _dmdDtlPtnOdrDiv = value; }
        }

        /// public propaty name  :  SlipTtlPrtDiv
        /// <summary>�`�[�v�󎚗L���v���p�e�B</summary>
        /// <value>0:�󎚂��� 1:�󎚂��Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�v�󎚗L���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipTtlPrtDiv
        {
            get { return _slipTtlPrtDiv; }
            set { _slipTtlPrtDiv = value; }
        }

        /// public propaty name  :  AddDayTtlPrtDiv
        /// <summary>�v����v�󎚗L���v���p�e�B</summary>
        /// <value>0:�󎚂��� 1:�󎚂��Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����v�󎚗L���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddDayTtlPrtDiv
        {
            get { return _addDayTtlPrtDiv; }
            set { _addDayTtlPrtDiv = value; }
        }

        /// public propaty name  :  CustomerTtlPrtDiv
        /// <summary>���Ӑ�v�󎚗L���v���p�e�B</summary>
        /// <value>0:�󎚂��� 1:�󎚂��Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�v�󎚗L���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerTtlPrtDiv
        {
            get { return _customerTtlPrtDiv; }
            set { _customerTtlPrtDiv = value; }
        }

        /// public propaty name  :  DtlPrcZeroPrtDiv
        /// <summary>���׋��z�[�����󎚗L���v���p�e�B</summary>
        /// <value>0:�󎚂��� 1:�󎚂��Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���׋��z�[�����󎚗L���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DtlPrcZeroPrtDiv
        {
            get { return _dtlPrcZeroPrtDiv; }
            set { _dtlPrcZeroPrtDiv = value; }
        }

        /// public propaty name  :  DepoDtlPrcPrtDiv
        /// <summary>�������׈󎚗L���敪�v���p�e�B</summary>
        /// <value>0:�󎚂��Ȃ� 1:�󎚂���(���v)  1:�󎚂��� (����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������׈󎚗L���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepoDtlPrcPrtDiv
        {
            get { return _depoDtlPrcPrtDiv; }
            set { _depoDtlPrcPrtDiv = value; }
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

        /// public propaty name  :  ListPricePrtCd
        /// <summary>�W�����i�󎚋敪�v���p�e�B</summary>
        /// <value>0:�󎚂��Ȃ� 1:�󎚂��� 2:�|�����P</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����i�󎚋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ListPricePrtCd
        {
            get { return _listPricePrtCd; }
            set { _listPricePrtCd = value; }
        }

        /// public propaty name  :  PartsNoPrtCd
        /// <summary>�i�Ԉ󎚋敪�v���p�e�B</summary>
        /// <value>0:�󎚂��Ȃ�,1:�󎚂���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�Ԉ󎚋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PartsNoPrtCd
        {
            get { return _partsNoPrtCd; }
            set { _partsNoPrtCd = value; }
        }

        // --- ADD  ���r��  2010/02/18 ---------->>>>>
        /// public propaty name  :  AnnotationPrtCd
        /// <summary>���߈󎚋敪�v���p�e�B</summary>
        /// <value>0:�󎚂���,1:�󎚂��Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���߈󎚋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AnnotationPrtCd
        {
            get { return _annotationPrtCd; }
            set { _annotationPrtCd = value; }
        }
        // --- ADD  ���r��  2010/02/18 ----------<<<<<

        // --- ADD  2011/02/16 ---------->>>>>
        /// public propaty name  :  CoNmPrintOutCd
        /// <summary>���Ж��󎚋敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж��󎚋敪��ǉ�</br>
        /// <br>Programer        :   2011/02/16  �{�w�C��</br>
        /// </remarks>
        public Int32 CoNmPrintOutCd
        {
            get { return _coNmPrintOutCd; }
            set { _coNmPrintOutCd = value; }
        }
        // --- ADD  2011/02/16 ----------<<<<<

        /// <summary>
        /// ����������p�^�[�����[�N�R���X�g���N�^
        /// </summary>
        /// <returns>DmdPrtPtnWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DmdPrtPtnWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DmdPrtPtnWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>DmdPrtPtnWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   DmdPrtPtnWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// <br>Update Note      :   2011/02/16  �{�w�C��</br> 																								
    /// <br>                 :   ���Ж��󎚋敪��ǉ�</br> 
    /// </remarks>
    public class DmdPrtPtnWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DmdPrtPtnWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  DmdPrtPtnWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is DmdPrtPtnWork || graph is ArrayList || graph is DmdPrtPtnWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(DmdPrtPtnWork).FullName));

            if (graph != null && graph is DmdPrtPtnWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.DmdPrtPtnWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is DmdPrtPtnWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((DmdPrtPtnWork[])graph).Length;
            }
            else if (graph is DmdPrtPtnWork)
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
            //�X�V�A�Z���u��ID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //�_���폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //�f�[�^���̓V�X�e��
            serInfo.MemberInfo.Add(typeof(Int32)); //DataInputSystem
            //�`�[������
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipPrtKind
            //�`�[����ݒ�p���[ID
            serInfo.MemberInfo.Add(typeof(string)); //SlipPrtSetPaperId
            //�`�[�R�����g
            serInfo.MemberInfo.Add(typeof(string)); //SlipComment
            //�o�̓t�@�C����
            serInfo.MemberInfo.Add(typeof(string)); //OutputFormFileName
            //��]��
            serInfo.MemberInfo.Add(typeof(Double)); //TopMargin
            //���]��
            serInfo.MemberInfo.Add(typeof(Double)); //LeftMargin
            //�E�]��
            serInfo.MemberInfo.Add(typeof(Double)); //RightMargin
            //���]��
            serInfo.MemberInfo.Add(typeof(Double)); //BottomMargin
            //���ʖ���
            serInfo.MemberInfo.Add(typeof(Int32)); //CopyCount
            //���� �Ӄ^�C�g���P
            serInfo.MemberInfo.Add(typeof(string)); //DmdTtlFormTitle1
            //���� �Ӄ^�C�g���Q
            serInfo.MemberInfo.Add(typeof(string)); //DmdTtlFormTitle2
            //���� �Ӄ^�C�g���R
            serInfo.MemberInfo.Add(typeof(string)); //DmdTtlFormTitle3
            //���� �Ӄ^�C�g���S
            serInfo.MemberInfo.Add(typeof(string)); //DmdTtlFormTitle4
            //���� �Ӄ^�C�g���T
            serInfo.MemberInfo.Add(typeof(string)); //DmdTtlFormTitle5
            //���� �Ӄ^�C�g���U
            serInfo.MemberInfo.Add(typeof(string)); //DmdTtlFormTitle6
            //���� �Ӄ^�C�g���V
            serInfo.MemberInfo.Add(typeof(string)); //DmdTtlFormTitle7
            //���� �Ӄ^�C�g���W
            serInfo.MemberInfo.Add(typeof(string)); //DmdTtlFormTitle8
            //���� �Ӑݒ荀�ڋ敪�P
            serInfo.MemberInfo.Add(typeof(Int32)); //DmdTtlSetItemDiv1
            //���� �Ӑݒ荀�ڋ敪�Q
            serInfo.MemberInfo.Add(typeof(Int32)); //DmdTtlSetItemDiv2
            //���� �Ӑݒ荀�ڋ敪�R
            serInfo.MemberInfo.Add(typeof(Int32)); //DmdTtlSetItemDiv3
            //���� �Ӑݒ荀�ڋ敪�S
            serInfo.MemberInfo.Add(typeof(Int32)); //DmdTtlSetItemDiv4
            //���� �Ӑݒ荀�ڋ敪�T
            serInfo.MemberInfo.Add(typeof(Int32)); //DmdTtlSetItemDiv5
            //���� �Ӑݒ荀�ڋ敪�U
            serInfo.MemberInfo.Add(typeof(Int32)); //DmdTtlSetItemDiv6
            //���� �Ӑݒ荀�ڋ敪�V
            serInfo.MemberInfo.Add(typeof(Int32)); //DmdTtlSetItemDiv7
            //���� �Ӑݒ荀�ڋ敪�W
            serInfo.MemberInfo.Add(typeof(Int32)); //DmdTtlSetItemDiv8
            //�������^�C�g��
            serInfo.MemberInfo.Add(typeof(string)); //DmdFormTitle
            //�������^�C�g���Q
            serInfo.MemberInfo.Add(typeof(string)); //DmdFormTitle2
            //�������R�����g�P
            serInfo.MemberInfo.Add(typeof(string)); //DmdFormComent1
            //�������R�����g�Q
            serInfo.MemberInfo.Add(typeof(string)); //DmdFormComent2
            //�������R�����g�R
            serInfo.MemberInfo.Add(typeof(string)); //DmdFormComent3
            //�������דE�v�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DmdDtlOutlineCode
            //�������׏��󎚏��ʋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DmdDtlPtnOdrDiv
            //�`�[�v�󎚗L��
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipTtlPrtDiv
            //�v����v�󎚗L��
            serInfo.MemberInfo.Add(typeof(Int32)); //AddDayTtlPrtDiv
            //���Ӑ�v�󎚗L��
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerTtlPrtDiv
            //���׋��z�[�����󎚗L��
            serInfo.MemberInfo.Add(typeof(Int32)); //DtlPrcZeroPrtDiv
            //�������׈󎚗L���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DepoDtlPrcPrtDiv
            //�������h��
            serInfo.MemberInfo.Add(typeof(string)); //BillHonorificTtl
            //�W�����i�󎚋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //ListPricePrtCd
            //�i�Ԉ󎚋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsNoPrtCd
            // --- ADD  ���r��  2010/02/18 ---------->>>>>
            //���߈󎚋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AnnotationPrtCd
            // --- ADD  ���r��  2010/02/18 ----------<<<<<

            // --- ADD  2011/02/16 ---------->>>>>
            //���Ж��󎚋敪
            serInfo.MemberInfo.Add(typeof(Int32));
            // --- ADD  2011/02/16 ----------<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is DmdPrtPtnWork)
            {
                DmdPrtPtnWork temp = (DmdPrtPtnWork)graph;

                SetDmdPrtPtnWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is DmdPrtPtnWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((DmdPrtPtnWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (DmdPrtPtnWork temp in lst)
                {
                    SetDmdPrtPtnWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// DmdPrtPtnWork�����o��(public�v���p�e�B��)
        /// </summary>
        // --- UPD  ���r��  2010/02/18 ---------->>>>>
        //private const int currentMemberCount = 49;
        // --- UPD  2011/02/16 ---------->>>>>
        //private const int currentMemberCount = 50;
        private const int currentMemberCount = 51;
        // --- UPD  2011/02/16 ----------<<<<
        // --- UPD  ���r��  2010/02/18 ----------<<<<<

        /// <summary>
        ///  DmdPrtPtnWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DmdPrtPtnWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2011/02/16  �{�w�C��</br> 																								
        /// <br>                 :   ���Ж��󎚋敪��ǉ�</br> 
        /// </remarks>
        private void SetDmdPrtPtnWork(System.IO.BinaryWriter writer, DmdPrtPtnWork temp)
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
            //�X�V�A�Z���u��ID1
            writer.Write(temp.UpdAssemblyId2);
            //�_���폜�敪
            writer.Write(temp.LogicalDeleteCode);
            //�f�[�^���̓V�X�e��
            writer.Write(temp.DataInputSystem);
            //�`�[������
            writer.Write(temp.SlipPrtKind);
            //�`�[����ݒ�p���[ID
            writer.Write(temp.SlipPrtSetPaperId);
            //�`�[�R�����g
            writer.Write(temp.SlipComment);
            //�o�̓t�@�C����
            writer.Write(temp.OutputFormFileName);
            //��]��
            writer.Write(temp.TopMargin);
            //���]��
            writer.Write(temp.LeftMargin);
            //�E�]��
            writer.Write(temp.RightMargin);
            //���]��
            writer.Write(temp.BottomMargin);
            //���ʖ���
            writer.Write(temp.CopyCount);
            //���� �Ӄ^�C�g���P
            writer.Write(temp.DmdTtlFormTitle1);
            //���� �Ӄ^�C�g���Q
            writer.Write(temp.DmdTtlFormTitle2);
            //���� �Ӄ^�C�g���R
            writer.Write(temp.DmdTtlFormTitle3);
            //���� �Ӄ^�C�g���S
            writer.Write(temp.DmdTtlFormTitle4);
            //���� �Ӄ^�C�g���T
            writer.Write(temp.DmdTtlFormTitle5);
            //���� �Ӄ^�C�g���U
            writer.Write(temp.DmdTtlFormTitle6);
            //���� �Ӄ^�C�g���V
            writer.Write(temp.DmdTtlFormTitle7);
            //���� �Ӄ^�C�g���W
            writer.Write(temp.DmdTtlFormTitle8);
            //���� �Ӑݒ荀�ڋ敪�P
            writer.Write(temp.DmdTtlSetItemDiv1);
            //���� �Ӑݒ荀�ڋ敪�Q
            writer.Write(temp.DmdTtlSetItemDiv2);
            //���� �Ӑݒ荀�ڋ敪�R
            writer.Write(temp.DmdTtlSetItemDiv3);
            //���� �Ӑݒ荀�ڋ敪�S
            writer.Write(temp.DmdTtlSetItemDiv4);
            //���� �Ӑݒ荀�ڋ敪�T
            writer.Write(temp.DmdTtlSetItemDiv5);
            //���� �Ӑݒ荀�ڋ敪�U
            writer.Write(temp.DmdTtlSetItemDiv6);
            //���� �Ӑݒ荀�ڋ敪�V
            writer.Write(temp.DmdTtlSetItemDiv7);
            //���� �Ӑݒ荀�ڋ敪�W
            writer.Write(temp.DmdTtlSetItemDiv8);
            //�������^�C�g��
            writer.Write(temp.DmdFormTitle);
            //�������^�C�g���Q
            writer.Write(temp.DmdFormTitle2);
            //�������R�����g�P
            writer.Write(temp.DmdFormComent1);
            //�������R�����g�Q
            writer.Write(temp.DmdFormComent2);
            //�������R�����g�R
            writer.Write(temp.DmdFormComent3);
            //�������דE�v�敪
            writer.Write(temp.DmdDtlOutlineCode);
            //�������׏��󎚏��ʋ敪
            writer.Write(temp.DmdDtlPtnOdrDiv);
            //�`�[�v�󎚗L��
            writer.Write(temp.SlipTtlPrtDiv);
            //�v����v�󎚗L��
            writer.Write(temp.AddDayTtlPrtDiv);
            //���Ӑ�v�󎚗L��
            writer.Write(temp.CustomerTtlPrtDiv);
            //���׋��z�[�����󎚗L��
            writer.Write(temp.DtlPrcZeroPrtDiv);
            //�������׈󎚗L���敪
            writer.Write(temp.DepoDtlPrcPrtDiv);
            //�������h��
            writer.Write(temp.BillHonorificTtl);
            //�W�����i�󎚋敪
            writer.Write(temp.ListPricePrtCd);
            //�i�Ԉ󎚋敪
            writer.Write(temp.PartsNoPrtCd);
            // --- ADD  ���r��  2010/02/18 ---------->>>>>
            //���߈󎚋敪
            writer.Write(temp.AnnotationPrtCd);
            // --- ADD  ���r��  2010/02/18 ----------<<<<<
            // --- ADD  2011/02/16 ---------->>>>>
            writer.Write(temp.CoNmPrintOutCd);
            // --- ADD  2011/02/16 ----------<<<<<

        }

        /// <summary>
        ///  DmdPrtPtnWork�C���X�^���X�擾
        /// </summary>
        /// <returns>DmdPrtPtnWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DmdPrtPtnWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2011/02/16  �{�w�C��</br> 																								
        /// <br>                 :   ���Ж��󎚋敪��ǉ�</br> 
        /// </remarks>
        private DmdPrtPtnWork GetDmdPrtPtnWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            DmdPrtPtnWork temp = new DmdPrtPtnWork();

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
            //�X�V�A�Z���u��ID1
            temp.UpdAssemblyId2 = reader.ReadString();
            //�_���폜�敪
            temp.LogicalDeleteCode = reader.ReadInt32();
            //�f�[�^���̓V�X�e��
            temp.DataInputSystem = reader.ReadInt32();
            //�`�[������
            temp.SlipPrtKind = reader.ReadInt32();
            //�`�[����ݒ�p���[ID
            temp.SlipPrtSetPaperId = reader.ReadString();
            //�`�[�R�����g
            temp.SlipComment = reader.ReadString();
            //�o�̓t�@�C����
            temp.OutputFormFileName = reader.ReadString();
            //��]��
            temp.TopMargin = reader.ReadDouble();
            //���]��
            temp.LeftMargin = reader.ReadDouble();
            //�E�]��
            temp.RightMargin = reader.ReadDouble();
            //���]��
            temp.BottomMargin = reader.ReadDouble();
            //���ʖ���
            temp.CopyCount = reader.ReadInt32();
            //���� �Ӄ^�C�g���P
            temp.DmdTtlFormTitle1 = reader.ReadString();
            //���� �Ӄ^�C�g���Q
            temp.DmdTtlFormTitle2 = reader.ReadString();
            //���� �Ӄ^�C�g���R
            temp.DmdTtlFormTitle3 = reader.ReadString();
            //���� �Ӄ^�C�g���S
            temp.DmdTtlFormTitle4 = reader.ReadString();
            //���� �Ӄ^�C�g���T
            temp.DmdTtlFormTitle5 = reader.ReadString();
            //���� �Ӄ^�C�g���U
            temp.DmdTtlFormTitle6 = reader.ReadString();
            //���� �Ӄ^�C�g���V
            temp.DmdTtlFormTitle7 = reader.ReadString();
            //���� �Ӄ^�C�g���W
            temp.DmdTtlFormTitle8 = reader.ReadString();
            //���� �Ӑݒ荀�ڋ敪�P
            temp.DmdTtlSetItemDiv1 = reader.ReadInt32();
            //���� �Ӑݒ荀�ڋ敪�Q
            temp.DmdTtlSetItemDiv2 = reader.ReadInt32();
            //���� �Ӑݒ荀�ڋ敪�R
            temp.DmdTtlSetItemDiv3 = reader.ReadInt32();
            //���� �Ӑݒ荀�ڋ敪�S
            temp.DmdTtlSetItemDiv4 = reader.ReadInt32();
            //���� �Ӑݒ荀�ڋ敪�T
            temp.DmdTtlSetItemDiv5 = reader.ReadInt32();
            //���� �Ӑݒ荀�ڋ敪�U
            temp.DmdTtlSetItemDiv6 = reader.ReadInt32();
            //���� �Ӑݒ荀�ڋ敪�V
            temp.DmdTtlSetItemDiv7 = reader.ReadInt32();
            //���� �Ӑݒ荀�ڋ敪�W
            temp.DmdTtlSetItemDiv8 = reader.ReadInt32();
            //�������^�C�g��
            temp.DmdFormTitle = reader.ReadString();
            //�������^�C�g���Q
            temp.DmdFormTitle2 = reader.ReadString();
            //�������R�����g�P
            temp.DmdFormComent1 = reader.ReadString();
            //�������R�����g�Q
            temp.DmdFormComent2 = reader.ReadString();
            //�������R�����g�R
            temp.DmdFormComent3 = reader.ReadString();
            //�������דE�v�敪
            temp.DmdDtlOutlineCode = reader.ReadInt32();
            //�������׏��󎚏��ʋ敪
            temp.DmdDtlPtnOdrDiv = reader.ReadInt32();
            //�`�[�v�󎚗L��
            temp.SlipTtlPrtDiv = reader.ReadInt32();
            //�v����v�󎚗L��
            temp.AddDayTtlPrtDiv = reader.ReadInt32();
            //���Ӑ�v�󎚗L��
            temp.CustomerTtlPrtDiv = reader.ReadInt32();
            //���׋��z�[�����󎚗L��
            temp.DtlPrcZeroPrtDiv = reader.ReadInt32();
            //�������׈󎚗L���敪
            temp.DepoDtlPrcPrtDiv = reader.ReadInt32();
            //�������h��
            temp.BillHonorificTtl = reader.ReadString();
            //�W�����i�󎚋敪
            temp.ListPricePrtCd = reader.ReadInt32();
            //�i�Ԉ󎚋敪
            temp.PartsNoPrtCd = reader.ReadInt32();
            // --- ADD  ���r��  2010/02/18 ---------->>>>>
            //���߈󎚋敪
            temp.AnnotationPrtCd = reader.ReadInt32();
            // --- ADD  ���r��  2010/02/18 ----------<<<<<

            // --- ADD  2011/02/16 ---------->>>>>
            //���Ж��󎚋敪
            temp.CoNmPrintOutCd = reader.ReadInt32();
            // --- ADD  2011/02/16 ----------<<<<<

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
        /// <returns>DmdPrtPtnWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DmdPrtPtnWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for ( int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                DmdPrtPtnWork temp = GetDmdPrtPtnWork(reader, serInfo);
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
                    retValue = (DmdPrtPtnWork[])lst.ToArray(typeof(DmdPrtPtnWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}


using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SlipPrtSetWork
	/// <summary>
	///                      �`�[����ݒ胏�[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �`�[����ݒ胏�[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2008/3/26</br>
	/// <br>Genarated Date   :   2008/06/03  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
    /// <br>Update Note      :   2011/02/16  ���N�n��</br>
    /// <br>                     ���Ж��̂P�C�Q���c�{�p�ɂȂ��Ă��Ȃ��s��̑Ή�</br>
    /// <br>Update Note      :   2011/7/19  chenyd</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   SCM�񓚃}�[�N�󎚋敪</br>
    /// <br>                 :   �ʏ픭�s�}�[�N</br>
    /// <br>                 :   SCM�蓮�񓚃}�[�N</br>
    /// <br>                 :   SCM�����񓚃}�[�N</br>
    /// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SlipPrtSetWork : IFileHeader
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

        /// <summary>�f�[�^���̓V�X�e��</summary>
        /// <remarks>0:����,1:����,2:���,3:�Ԕ�</remarks>
        private Int32 _dataInputSystem;

        /// <summary>�`�[������</summary>
        /// <remarks>10:���Ϗ�,20:�w�����i�������j,21:���菑,30:�[�i��40:�ԕi�`�[,100:���[�N�V�[�g,110:�{�f�B���@�}</remarks>
        private Int32 _slipPrtKind;

        /// <summary>�`�[����ݒ�p���[ID</summary>
        /// <remarks>�`�[����ݒ�p</remarks>
        private string _slipPrtSetPaperId = "";

        /// <summary>�`�[�R�����g</summary>
        private string _slipComment = "";

        /// <summary>�o�̓v���O����ID</summary>
        private string _outputPgId = "";

        /// <summary>�o�̓v���O�����N���XID</summary>
        private string _outputPgClassId = "";

        /// <summary>�o�̓t�@�C����</summary>
        /// <remarks>�t�H�[���t�@�C��ID or �t�H�[�}�b�g�t�@�C��ID</remarks>
        private string _outputFormFileName = "";

        /// <summary>���Ж�����敪</summary>
        /// <remarks>0:���Ж��󎚁@1:���_���󎚁@2:�r�b�g�}�b�v���󎚁@3:�󎚂��Ȃ�</remarks>
        private Int32 _enterpriseNamePrtCd;

        /// <summary>�������</summary>
        /// <remarks>1�`99</remarks>
        private Int32 _prtCirculation;

        /// <summary>�`�[�p���敪</summary>
        /// <remarks>0:����,1:��p�`�[,2:�A��</remarks>
        private Int32 _slipFormCd;

        /// <summary>�o�͊m�F���b�Z�[�W</summary>
        private string _outConfimationMsg = "";

        /// <summary>�I�v�V�����R�[�h</summary>
        /// <remarks>���я�̵�߼�ݺ���</remarks>
        private string _optionCode = "";

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

        /// <summary>����v���r���L���敪</summary>
        /// <remarks>0:����,1:�L��</remarks>
        private Int32 _prtPreviewExistCode;

        /// <summary>�o�͗p�r</summary>
        /// <remarks>���R�ɐݒ�\</remarks>
        private Int32 _outputPurpose;

        /// <summary>�`�[�^�C�v�ʗ�ID1</summary>
        private string _eachSlipTypeColId1 = "";

        /// <summary>�`�[�^�C�v�ʗ񖼏�1</summary>
        private string _eachSlipTypeColNm1 = "";

        /// <summary>�`�[�^�C�v�ʗ�󎚋敪1</summary>
        /// <remarks>0:�󎚂��Ȃ�,1:�󎚂���</remarks>
        private Int32 _eachSlipTypeColPrt1;

        /// <summary>�`�[�^�C�v�ʗ�ID2</summary>
        private string _eachSlipTypeColId2 = "";

        /// <summary>�`�[�^�C�v�ʗ񖼏�2</summary>
        private string _eachSlipTypeColNm2 = "";

        /// <summary>�`�[�^�C�v�ʗ�󎚋敪2</summary>
        /// <remarks>0:�󎚂��Ȃ�,1:�󎚂���</remarks>
        private Int32 _eachSlipTypeColPrt2;

        /// <summary>�`�[�^�C�v�ʗ�ID3</summary>
        private string _eachSlipTypeColId3 = "";

        /// <summary>�`�[�^�C�v�ʗ񖼏�3</summary>
        private string _eachSlipTypeColNm3 = "";

        /// <summary>�`�[�^�C�v�ʗ�󎚋敪3</summary>
        /// <remarks>0:�󎚂��Ȃ�,1:�󎚂���</remarks>
        private Int32 _eachSlipTypeColPrt3;

        /// <summary>�`�[�^�C�v�ʗ�ID4</summary>
        private string _eachSlipTypeColId4 = "";

        /// <summary>�`�[�^�C�v�ʗ񖼏�4</summary>
        private string _eachSlipTypeColNm4 = "";

        /// <summary>�`�[�^�C�v�ʗ�󎚋敪4</summary>
        /// <remarks>0:�󎚂��Ȃ�,1:�󎚂���</remarks>
        private Int32 _eachSlipTypeColPrt4;

        /// <summary>�`�[�^�C�v�ʗ�ID5</summary>
        private string _eachSlipTypeColId5 = "";

        /// <summary>�`�[�^�C�v�ʗ񖼏�5</summary>
        private string _eachSlipTypeColNm5 = "";

        /// <summary>�`�[�^�C�v�ʗ�󎚋敪5</summary>
        /// <remarks>0:�󎚂��Ȃ�,1:�󎚂���</remarks>
        private Int32 _eachSlipTypeColPrt5;

        /// <summary>�`�[�^�C�v�ʗ�ID6</summary>
        private string _eachSlipTypeColId6 = "";

        /// <summary>�`�[�^�C�v�ʗ񖼏�6</summary>
        private string _eachSlipTypeColNm6 = "";

        /// <summary>�`�[�^�C�v�ʗ�󎚋敪6</summary>
        /// <remarks>0:�󎚂��Ȃ�,1:�󎚂���</remarks>
        private Int32 _eachSlipTypeColPrt6;

        /// <summary>�`�[�^�C�v�ʗ�ID7</summary>
        private string _eachSlipTypeColId7 = "";

        /// <summary>�`�[�^�C�v�ʗ񖼏�7</summary>
        private string _eachSlipTypeColNm7 = "";

        /// <summary>�`�[�^�C�v�ʗ�󎚋敪7</summary>
        /// <remarks>0:�󎚂��Ȃ�,1:�󎚂���</remarks>
        private Int32 _eachSlipTypeColPrt7;

        /// <summary>�`�[�^�C�v�ʗ�ID8</summary>
        private string _eachSlipTypeColId8 = "";

        /// <summary>�`�[�^�C�v�ʗ񖼏�8</summary>
        private string _eachSlipTypeColNm8 = "";

        /// <summary>�`�[�^�C�v�ʗ�󎚋敪8</summary>
        /// <remarks>0:�󎚂��Ȃ�,1:�󎚂���</remarks>
        private Int32 _eachSlipTypeColPrt8;

        /// <summary>�`�[�^�C�v�ʗ�ID9</summary>
        private string _eachSlipTypeColId9 = "";

        /// <summary>�`�[�^�C�v�ʗ񖼏�9</summary>
        private string _eachSlipTypeColNm9 = "";

        /// <summary>�`�[�^�C�v�ʗ�󎚋敪9</summary>
        /// <remarks>0:�󎚂��Ȃ�,1:�󎚂���</remarks>
        private Int32 _eachSlipTypeColPrt9;

        /// <summary>�`�[�^�C�v�ʗ�ID10</summary>
        private string _eachSlipTypeColId10 = "";

        /// <summary>�`�[�^�C�v�ʗ񖼏�10</summary>
        private string _eachSlipTypeColNm10 = "";

        /// <summary>�`�[�^�C�v�ʗ�󎚋敪10</summary>
        /// <remarks>0:�󎚂��Ȃ�,1:�󎚂���</remarks>
        private Int32 _eachSlipTypeColPrt10;

        /// <summary>�`�[�t�H���g����</summary>
        private string _slipFontName = "";

        /// <summary>�`�[�t�H���g�T�C�Y</summary>
        /// <remarks>0:�W��,1:��</remarks>
        private Int32 _slipFontSize;

        /// <summary>�`�[�t�H���g�X�^�C��</summary>
        /// <remarks>0:�W��,1:����</remarks>
        private Int32 _slipFontStyle;

        /// <summary>�`�[��F��1</summary>
        private Int32 _slipBaseColorRed1;

        /// <summary>�`�[��F��1</summary>
        private Int32 _slipBaseColorGrn1;

        /// <summary>�`�[��F��1</summary>
        private Int32 _slipBaseColorBlu1;

        /// <summary>�`�[��F��2</summary>
        private Int32 _slipBaseColorRed2;

        /// <summary>�`�[��F��2</summary>
        private Int32 _slipBaseColorGrn2;

        /// <summary>�`�[��F��2</summary>
        private Int32 _slipBaseColorBlu2;

        /// <summary>�`�[��F��3</summary>
        private Int32 _slipBaseColorRed3;

        /// <summary>�`�[��F��3</summary>
        private Int32 _slipBaseColorGrn3;

        /// <summary>�`�[��F��3</summary>
        private Int32 _slipBaseColorBlu3;

        /// <summary>�`�[��F��4</summary>
        private Int32 _slipBaseColorRed4;

        /// <summary>�`�[��F��4</summary>
        private Int32 _slipBaseColorGrn4;

        /// <summary>�`�[��F��4</summary>
        private Int32 _slipBaseColorBlu4;

        /// <summary>�`�[��F��5</summary>
        private Int32 _slipBaseColorRed5;

        /// <summary>�`�[��F��5</summary>
        private Int32 _slipBaseColorGrn5;

        /// <summary>�`�[��F��5</summary>
        private Int32 _slipBaseColorBlu5;

        /// <summary>���ʖ���</summary>
        private Int32 _copyCount;

        /// <summary>�^�C�g��1</summary>
        private string _titleName1 = "";

        /// <summary>�^�C�g��2</summary>
        private string _titleName2 = "";

        /// <summary>�^�C�g��3</summary>
        private string _titleName3 = "";

        /// <summary>�^�C�g��4</summary>
        private string _titleName4 = "";

        /// <summary>����p�r1</summary>
        /// <remarks>�`�[��ʒu������(�� 10,20,30����ݒ�j�@�����Ϗ���[�i���ň󎚂���ꍇ���Ɏg�p</remarks>
        private string _specialPurpose1 = "";

        /// <summary>����p�r2</summary>
        /// <remarks>���R�ɐݒ�\�i����ȓ`�[�̏ꍇ�Ɏg�p�j���}�X�����s��</remarks>
        private string _specialPurpose2 = "";

        /// <summary>����p�r3</summary>
        /// <remarks>���R�ɐݒ�\�i����ȓ`�[�̏ꍇ�Ɏg�p�j���}�X�����s��</remarks>
        private string _specialPurpose3 = "";

        /// <summary>����p�r4</summary>
        /// <remarks>���R�ɐݒ�\�i����ȓ`�[�̏ꍇ�Ɏg�p�j���}�X�����s��</remarks>
        private string _specialPurpose4 = "";

        /// <summary>�^�C�g��1-2</summary>
        private string _titleName102 = "";

        /// <summary>�^�C�g��1-3</summary>
        private string _titleName103 = "";

        /// <summary>�^�C�g��1-4</summary>
        private string _titleName104 = "";

        /// <summary>�^�C�g��1-5</summary>
        private string _titleName105 = "";

        /// <summary>�^�C�g��2-2</summary>
        private string _titleName202 = "";

        /// <summary>�^�C�g��2-3</summary>
        private string _titleName203 = "";

        /// <summary>�^�C�g��2-4</summary>
        private string _titleName204 = "";

        /// <summary>�^�C�g��2-5</summary>
        private string _titleName205 = "";

        /// <summary>�^�C�g��3-2</summary>
        private string _titleName302 = "";

        /// <summary>�^�C�g��3-3</summary>
        private string _titleName303 = "";

        /// <summary>�^�C�g��3-4</summary>
        private string _titleName304 = "";

        /// <summary>�^�C�g��3-5</summary>
        private string _titleName305 = "";

        /// <summary>�^�C�g��4-2</summary>
        private string _titleName402 = "";

        /// <summary>�^�C�g��4-3</summary>
        private string _titleName403 = "";

        /// <summary>�^�C�g��4-4</summary>
        private string _titleName404 = "";

        /// <summary>�^�C�g��4-5</summary>
        private string _titleName405 = "";

        /// <summary>���l�P</summary>
        private string _note1 = "";

        /// <summary>���l�Q</summary>
        private string _note2 = "";

        /// <summary>���l�R</summary>
        private string _note3 = "";

        /// <summary>QR�R�[�h�󎚋敪</summary>
        /// <remarks>0:�W�� 1:�󎚂��Ȃ� 2:�󎚂��� 3:�ԕi�܂�</remarks>
        private Int32 _qRCodePrintDivCd;

        /// <summary>�����󎚋敪</summary>
        /// <remarks>0:���,1:��</remarks>
        private Int32 _timePrintDivCd;

        /// <summary>�Ĕ��s�}�[�N</summary>
        /// <remarks>�S�p�R�����܂�</remarks>
        private string _reissueMark = "";

        /// <summary>����ň󎚋敪</summary>
        /// <remarks>0:���,1:��</remarks>
        private Int32 _consTaxPrtCd;

        /// <summary>�Q�l����ŋ敪</summary>
        /// <remarks>0:���,1:��</remarks>
        private Int32 _refConsTaxDivCd;

        /// <summary>�Q�l����ň󎚖���</summary>
        /// <remarks>�S�p�T�����܂�</remarks>
        private string _refConsTaxPrtNm = "";

        /// <summary>���׍s��</summary>
        /// <remarks>MAX999</remarks>
        private Int32 _detailRowCount;

        /// <summary>�h��</summary>
        private string _honorificTitle = "";

        /// <summary>����ň󎚋敪</summary>
        /// <remarks>0:��� 1:��</remarks>
        private Int32 _consTaxPrtCdRF;

        // --- ADD 2009/12/31 ---------->>>>>
        /// <summary>�`�[���l����</summary>
        private Int32 _slipNoteCharCnt;

        /// <summary>�`�[���l�Q����</summary>
        private Int32 _slipNote2CharCnt;

        /// <summary>�`�[���l�R����</summary>
        private Int32 _slipNote3CharCnt;
        // --- ADD 2009/12/31 ----------<<<<<

        // ---ADD 2010/08/06 ------------------------------------------------------------>>>>>
        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>�X�V�t���O</summary>
        private Int32 _updateFlag;
        // ---ADD 2010/08/06 ------------------------------------------------------------<<<<<

        // ---ADD 2011/02/16 ------------------------------------------------------------>>>>>
        /// <summary>���Ж��󎚊g��敪</summary>
        private Int32 _entNmPrtExpDiv;
        // ---ADD 2011/02/16 ------------------------------------------------------------<<<<<

        // ---ADD 2011/07/19 ------------------------------------------------------------>>>>>
        /// <summary>SCM�񓚃}�[�N�󎚋敪</summary>
        /// <remarks>0:���Ȃ�,1:����</remarks>
        private Int32 _sCMAnsMarkPrtDiv;

        /// <summary>�ʏ픭�s�}�[�N</summary>
        private string _normalPrtMark = "";

        /// <summary>SCM�蓮�񓚃}�[�N</summary>
        private string _sCMManualAnsMark = "";

        /// <summary>SCM�����񓚃}�[�N</summary>
        private string _sCMAutoAnsMark = "";
        // ---ADD 2011/07/19 ------------------------------------------------------------<<<<<

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
        /// <value>10:���Ϗ�,20:�w�����i�������j,21:���菑,30:�[�i��,40:�ԕi�`�[,100:���[�N�V�[�g,110:�{�f�B���@�}</value>
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

        /// public propaty name  :  OutputPgId
        /// <summary>�o�̓v���O����ID�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�̓v���O����ID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OutputPgId
        {
            get { return _outputPgId; }
            set { _outputPgId = value; }
        }

        /// public propaty name  :  OutputPgClassId
        /// <summary>�o�̓v���O�����N���XID�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�̓v���O�����N���XID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OutputPgClassId
        {
            get { return _outputPgClassId; }
            set { _outputPgClassId = value; }
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

        /// public propaty name  :  EnterpriseNamePrtCd
        /// <summary>���Ж�����敪�v���p�e�B</summary>
        /// <value>0:���Ж��󎚁@1:���_���󎚁@2:�r�b�g�}�b�v���󎚁@3:�󎚂��Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж�����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EnterpriseNamePrtCd
        {
            get { return _enterpriseNamePrtCd; }
            set { _enterpriseNamePrtCd = value; }
        }

        /// public propaty name  :  PrtCirculation
        /// <summary>��������v���p�e�B</summary>
        /// <value>1�`99</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrtCirculation
        {
            get { return _prtCirculation; }
            set { _prtCirculation = value; }
        }

        /// public propaty name  :  SlipFormCd
        /// <summary>�`�[�p���敪�v���p�e�B</summary>
        /// <value>0:����,1:��p�`�[,2:�A��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�p���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipFormCd
        {
            get { return _slipFormCd; }
            set { _slipFormCd = value; }
        }

        /// public propaty name  :  OutConfimationMsg
        /// <summary>�o�͊m�F���b�Z�[�W�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�͊m�F���b�Z�[�W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OutConfimationMsg
        {
            get { return _outConfimationMsg; }
            set { _outConfimationMsg = value; }
        }

        /// public propaty name  :  OptionCode
        /// <summary>�I�v�V�����R�[�h�v���p�e�B</summary>
        /// <value>���я�̵�߼�ݺ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�v�V�����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OptionCode
        {
            get { return _optionCode; }
            set { _optionCode = value; }
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

        /// public propaty name  :  PrtPreviewExistCode
        /// <summary>����v���r���L���敪�v���p�e�B</summary>
        /// <value>0:����,1:�L��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����v���r���L���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrtPreviewExistCode
        {
            get { return _prtPreviewExistCode; }
            set { _prtPreviewExistCode = value; }
        }

        /// public propaty name  :  OutputPurpose
        /// <summary>�o�͗p�r�v���p�e�B</summary>
        /// <value>���R�ɐݒ�\</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�͗p�r�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OutputPurpose
        {
            get { return _outputPurpose; }
            set { _outputPurpose = value; }
        }

        /// public propaty name  :  EachSlipTypeColId1
        /// <summary>�`�[�^�C�v�ʗ�ID1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�^�C�v�ʗ�ID1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EachSlipTypeColId1
        {
            get { return _eachSlipTypeColId1; }
            set { _eachSlipTypeColId1 = value; }
        }

        /// public propaty name  :  EachSlipTypeColNm1
        /// <summary>�`�[�^�C�v�ʗ񖼏�1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�^�C�v�ʗ񖼏�1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EachSlipTypeColNm1
        {
            get { return _eachSlipTypeColNm1; }
            set { _eachSlipTypeColNm1 = value; }
        }

        /// public propaty name  :  EachSlipTypeColPrt1
        /// <summary>�`�[�^�C�v�ʗ�󎚋敪1�v���p�e�B</summary>
        /// <value>0:�󎚂��Ȃ�,1:�󎚂���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�^�C�v�ʗ�󎚋敪1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EachSlipTypeColPrt1
        {
            get { return _eachSlipTypeColPrt1; }
            set { _eachSlipTypeColPrt1 = value; }
        }

        /// public propaty name  :  EachSlipTypeColId2
        /// <summary>�`�[�^�C�v�ʗ�ID2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�^�C�v�ʗ�ID2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EachSlipTypeColId2
        {
            get { return _eachSlipTypeColId2; }
            set { _eachSlipTypeColId2 = value; }
        }

        /// public propaty name  :  EachSlipTypeColNm2
        /// <summary>�`�[�^�C�v�ʗ񖼏�2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�^�C�v�ʗ񖼏�2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EachSlipTypeColNm2
        {
            get { return _eachSlipTypeColNm2; }
            set { _eachSlipTypeColNm2 = value; }
        }

        /// public propaty name  :  EachSlipTypeColPrt2
        /// <summary>�`�[�^�C�v�ʗ�󎚋敪2�v���p�e�B</summary>
        /// <value>0:�󎚂��Ȃ�,1:�󎚂���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�^�C�v�ʗ�󎚋敪2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EachSlipTypeColPrt2
        {
            get { return _eachSlipTypeColPrt2; }
            set { _eachSlipTypeColPrt2 = value; }
        }

        /// public propaty name  :  EachSlipTypeColId3
        /// <summary>�`�[�^�C�v�ʗ�ID3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�^�C�v�ʗ�ID3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EachSlipTypeColId3
        {
            get { return _eachSlipTypeColId3; }
            set { _eachSlipTypeColId3 = value; }
        }

        /// public propaty name  :  EachSlipTypeColNm3
        /// <summary>�`�[�^�C�v�ʗ񖼏�3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�^�C�v�ʗ񖼏�3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EachSlipTypeColNm3
        {
            get { return _eachSlipTypeColNm3; }
            set { _eachSlipTypeColNm3 = value; }
        }

        /// public propaty name  :  EachSlipTypeColPrt3
        /// <summary>�`�[�^�C�v�ʗ�󎚋敪3�v���p�e�B</summary>
        /// <value>0:�󎚂��Ȃ�,1:�󎚂���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�^�C�v�ʗ�󎚋敪3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EachSlipTypeColPrt3
        {
            get { return _eachSlipTypeColPrt3; }
            set { _eachSlipTypeColPrt3 = value; }
        }

        /// public propaty name  :  EachSlipTypeColId4
        /// <summary>�`�[�^�C�v�ʗ�ID4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�^�C�v�ʗ�ID4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EachSlipTypeColId4
        {
            get { return _eachSlipTypeColId4; }
            set { _eachSlipTypeColId4 = value; }
        }

        /// public propaty name  :  EachSlipTypeColNm4
        /// <summary>�`�[�^�C�v�ʗ񖼏�4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�^�C�v�ʗ񖼏�4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EachSlipTypeColNm4
        {
            get { return _eachSlipTypeColNm4; }
            set { _eachSlipTypeColNm4 = value; }
        }

        /// public propaty name  :  EachSlipTypeColPrt4
        /// <summary>�`�[�^�C�v�ʗ�󎚋敪4�v���p�e�B</summary>
        /// <value>0:�󎚂��Ȃ�,1:�󎚂���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�^�C�v�ʗ�󎚋敪4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EachSlipTypeColPrt4
        {
            get { return _eachSlipTypeColPrt4; }
            set { _eachSlipTypeColPrt4 = value; }
        }

        /// public propaty name  :  EachSlipTypeColId5
        /// <summary>�`�[�^�C�v�ʗ�ID5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�^�C�v�ʗ�ID5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EachSlipTypeColId5
        {
            get { return _eachSlipTypeColId5; }
            set { _eachSlipTypeColId5 = value; }
        }

        /// public propaty name  :  EachSlipTypeColNm5
        /// <summary>�`�[�^�C�v�ʗ񖼏�5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�^�C�v�ʗ񖼏�5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EachSlipTypeColNm5
        {
            get { return _eachSlipTypeColNm5; }
            set { _eachSlipTypeColNm5 = value; }
        }

        /// public propaty name  :  EachSlipTypeColPrt5
        /// <summary>�`�[�^�C�v�ʗ�󎚋敪5�v���p�e�B</summary>
        /// <value>0:�󎚂��Ȃ�,1:�󎚂���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�^�C�v�ʗ�󎚋敪5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EachSlipTypeColPrt5
        {
            get { return _eachSlipTypeColPrt5; }
            set { _eachSlipTypeColPrt5 = value; }
        }

        /// public propaty name  :  EachSlipTypeColId6
        /// <summary>�`�[�^�C�v�ʗ�ID6�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�^�C�v�ʗ�ID6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EachSlipTypeColId6
        {
            get { return _eachSlipTypeColId6; }
            set { _eachSlipTypeColId6 = value; }
        }

        /// public propaty name  :  EachSlipTypeColNm6
        /// <summary>�`�[�^�C�v�ʗ񖼏�6�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�^�C�v�ʗ񖼏�6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EachSlipTypeColNm6
        {
            get { return _eachSlipTypeColNm6; }
            set { _eachSlipTypeColNm6 = value; }
        }

        /// public propaty name  :  EachSlipTypeColPrt6
        /// <summary>�`�[�^�C�v�ʗ�󎚋敪6�v���p�e�B</summary>
        /// <value>0:�󎚂��Ȃ�,1:�󎚂���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�^�C�v�ʗ�󎚋敪6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EachSlipTypeColPrt6
        {
            get { return _eachSlipTypeColPrt6; }
            set { _eachSlipTypeColPrt6 = value; }
        }

        /// public propaty name  :  EachSlipTypeColId7
        /// <summary>�`�[�^�C�v�ʗ�ID7�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�^�C�v�ʗ�ID7�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EachSlipTypeColId7
        {
            get { return _eachSlipTypeColId7; }
            set { _eachSlipTypeColId7 = value; }
        }

        /// public propaty name  :  EachSlipTypeColNm7
        /// <summary>�`�[�^�C�v�ʗ񖼏�7�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�^�C�v�ʗ񖼏�7�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EachSlipTypeColNm7
        {
            get { return _eachSlipTypeColNm7; }
            set { _eachSlipTypeColNm7 = value; }
        }

        /// public propaty name  :  EachSlipTypeColPrt7
        /// <summary>�`�[�^�C�v�ʗ�󎚋敪7�v���p�e�B</summary>
        /// <value>0:�󎚂��Ȃ�,1:�󎚂���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�^�C�v�ʗ�󎚋敪7�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EachSlipTypeColPrt7
        {
            get { return _eachSlipTypeColPrt7; }
            set { _eachSlipTypeColPrt7 = value; }
        }

        /// public propaty name  :  EachSlipTypeColId8
        /// <summary>�`�[�^�C�v�ʗ�ID8�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�^�C�v�ʗ�ID8�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EachSlipTypeColId8
        {
            get { return _eachSlipTypeColId8; }
            set { _eachSlipTypeColId8 = value; }
        }

        /// public propaty name  :  EachSlipTypeColNm8
        /// <summary>�`�[�^�C�v�ʗ񖼏�8�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�^�C�v�ʗ񖼏�8�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EachSlipTypeColNm8
        {
            get { return _eachSlipTypeColNm8; }
            set { _eachSlipTypeColNm8 = value; }
        }

        /// public propaty name  :  EachSlipTypeColPrt8
        /// <summary>�`�[�^�C�v�ʗ�󎚋敪8�v���p�e�B</summary>
        /// <value>0:�󎚂��Ȃ�,1:�󎚂���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�^�C�v�ʗ�󎚋敪8�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EachSlipTypeColPrt8
        {
            get { return _eachSlipTypeColPrt8; }
            set { _eachSlipTypeColPrt8 = value; }
        }

        /// public propaty name  :  EachSlipTypeColId9
        /// <summary>�`�[�^�C�v�ʗ�ID9�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�^�C�v�ʗ�ID9�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EachSlipTypeColId9
        {
            get { return _eachSlipTypeColId9; }
            set { _eachSlipTypeColId9 = value; }
        }

        /// public propaty name  :  EachSlipTypeColNm9
        /// <summary>�`�[�^�C�v�ʗ񖼏�9�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�^�C�v�ʗ񖼏�9�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EachSlipTypeColNm9
        {
            get { return _eachSlipTypeColNm9; }
            set { _eachSlipTypeColNm9 = value; }
        }

        /// public propaty name  :  EachSlipTypeColPrt9
        /// <summary>�`�[�^�C�v�ʗ�󎚋敪9�v���p�e�B</summary>
        /// <value>0:�󎚂��Ȃ�,1:�󎚂���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�^�C�v�ʗ�󎚋敪9�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EachSlipTypeColPrt9
        {
            get { return _eachSlipTypeColPrt9; }
            set { _eachSlipTypeColPrt9 = value; }
        }

        /// public propaty name  :  EachSlipTypeColId10
        /// <summary>�`�[�^�C�v�ʗ�ID10�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�^�C�v�ʗ�ID10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EachSlipTypeColId10
        {
            get { return _eachSlipTypeColId10; }
            set { _eachSlipTypeColId10 = value; }
        }

        /// public propaty name  :  EachSlipTypeColNm10
        /// <summary>�`�[�^�C�v�ʗ񖼏�10�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�^�C�v�ʗ񖼏�10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EachSlipTypeColNm10
        {
            get { return _eachSlipTypeColNm10; }
            set { _eachSlipTypeColNm10 = value; }
        }

        /// public propaty name  :  EachSlipTypeColPrt10
        /// <summary>�`�[�^�C�v�ʗ�󎚋敪10�v���p�e�B</summary>
        /// <value>0:�󎚂��Ȃ�,1:�󎚂���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�^�C�v�ʗ�󎚋敪10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EachSlipTypeColPrt10
        {
            get { return _eachSlipTypeColPrt10; }
            set { _eachSlipTypeColPrt10 = value; }
        }

        /// public propaty name  :  SlipFontName
        /// <summary>�`�[�t�H���g���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�t�H���g���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipFontName
        {
            get { return _slipFontName; }
            set { _slipFontName = value; }
        }

        /// public propaty name  :  SlipFontSize
        /// <summary>�`�[�t�H���g�T�C�Y�v���p�e�B</summary>
        /// <value>0:�W��,1:��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�t�H���g�T�C�Y�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipFontSize
        {
            get { return _slipFontSize; }
            set { _slipFontSize = value; }
        }

        /// public propaty name  :  SlipFontStyle
        /// <summary>�`�[�t�H���g�X�^�C���v���p�e�B</summary>
        /// <value>0:�W��,1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�t�H���g�X�^�C���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipFontStyle
        {
            get { return _slipFontStyle; }
            set { _slipFontStyle = value; }
        }

        /// public propaty name  :  SlipBaseColorRed1
        /// <summary>�`�[��F��1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[��F��1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipBaseColorRed1
        {
            get { return _slipBaseColorRed1; }
            set { _slipBaseColorRed1 = value; }
        }

        /// public propaty name  :  SlipBaseColorGrn1
        /// <summary>�`�[��F��1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[��F��1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipBaseColorGrn1
        {
            get { return _slipBaseColorGrn1; }
            set { _slipBaseColorGrn1 = value; }
        }

        /// public propaty name  :  SlipBaseColorBlu1
        /// <summary>�`�[��F��1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[��F��1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipBaseColorBlu1
        {
            get { return _slipBaseColorBlu1; }
            set { _slipBaseColorBlu1 = value; }
        }

        /// public propaty name  :  SlipBaseColorRed2
        /// <summary>�`�[��F��2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[��F��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipBaseColorRed2
        {
            get { return _slipBaseColorRed2; }
            set { _slipBaseColorRed2 = value; }
        }

        /// public propaty name  :  SlipBaseColorGrn2
        /// <summary>�`�[��F��2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[��F��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipBaseColorGrn2
        {
            get { return _slipBaseColorGrn2; }
            set { _slipBaseColorGrn2 = value; }
        }

        /// public propaty name  :  SlipBaseColorBlu2
        /// <summary>�`�[��F��2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[��F��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipBaseColorBlu2
        {
            get { return _slipBaseColorBlu2; }
            set { _slipBaseColorBlu2 = value; }
        }

        /// public propaty name  :  SlipBaseColorRed3
        /// <summary>�`�[��F��3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[��F��3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipBaseColorRed3
        {
            get { return _slipBaseColorRed3; }
            set { _slipBaseColorRed3 = value; }
        }

        /// public propaty name  :  SlipBaseColorGrn3
        /// <summary>�`�[��F��3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[��F��3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipBaseColorGrn3
        {
            get { return _slipBaseColorGrn3; }
            set { _slipBaseColorGrn3 = value; }
        }

        /// public propaty name  :  SlipBaseColorBlu3
        /// <summary>�`�[��F��3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[��F��3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipBaseColorBlu3
        {
            get { return _slipBaseColorBlu3; }
            set { _slipBaseColorBlu3 = value; }
        }

        /// public propaty name  :  SlipBaseColorRed4
        /// <summary>�`�[��F��4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[��F��4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipBaseColorRed4
        {
            get { return _slipBaseColorRed4; }
            set { _slipBaseColorRed4 = value; }
        }

        /// public propaty name  :  SlipBaseColorGrn4
        /// <summary>�`�[��F��4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[��F��4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipBaseColorGrn4
        {
            get { return _slipBaseColorGrn4; }
            set { _slipBaseColorGrn4 = value; }
        }

        /// public propaty name  :  SlipBaseColorBlu4
        /// <summary>�`�[��F��4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[��F��4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipBaseColorBlu4
        {
            get { return _slipBaseColorBlu4; }
            set { _slipBaseColorBlu4 = value; }
        }

        /// public propaty name  :  SlipBaseColorRed5
        /// <summary>�`�[��F��5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[��F��5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipBaseColorRed5
        {
            get { return _slipBaseColorRed5; }
            set { _slipBaseColorRed5 = value; }
        }

        /// public propaty name  :  SlipBaseColorGrn5
        /// <summary>�`�[��F��5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[��F��5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipBaseColorGrn5
        {
            get { return _slipBaseColorGrn5; }
            set { _slipBaseColorGrn5 = value; }
        }

        /// public propaty name  :  SlipBaseColorBlu5
        /// <summary>�`�[��F��5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[��F��5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipBaseColorBlu5
        {
            get { return _slipBaseColorBlu5; }
            set { _slipBaseColorBlu5 = value; }
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

        /// public propaty name  :  TitleName1
        /// <summary>�^�C�g��1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�C�g��1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TitleName1
        {
            get { return _titleName1; }
            set { _titleName1 = value; }
        }

        /// public propaty name  :  TitleName2
        /// <summary>�^�C�g��2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�C�g��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TitleName2
        {
            get { return _titleName2; }
            set { _titleName2 = value; }
        }

        /// public propaty name  :  TitleName3
        /// <summary>�^�C�g��3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�C�g��3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TitleName3
        {
            get { return _titleName3; }
            set { _titleName3 = value; }
        }

        /// public propaty name  :  TitleName4
        /// <summary>�^�C�g��4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�C�g��4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TitleName4
        {
            get { return _titleName4; }
            set { _titleName4 = value; }
        }

        /// public propaty name  :  SpecialPurpose1
        /// <summary>����p�r1�v���p�e�B</summary>
        /// <value>�`�[��ʒu������(�� 10,20,30����ݒ�j�@�����Ϗ���[�i���ň󎚂���ꍇ���Ɏg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����p�r1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SpecialPurpose1
        {
            get { return _specialPurpose1; }
            set { _specialPurpose1 = value; }
        }

        /// public propaty name  :  SpecialPurpose2
        /// <summary>����p�r2�v���p�e�B</summary>
        /// <value>���R�ɐݒ�\�i����ȓ`�[�̏ꍇ�Ɏg�p�j���}�X�����s��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����p�r2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SpecialPurpose2
        {
            get { return _specialPurpose2; }
            set { _specialPurpose2 = value; }
        }

        /// public propaty name  :  SpecialPurpose3
        /// <summary>����p�r3�v���p�e�B</summary>
        /// <value>���R�ɐݒ�\�i����ȓ`�[�̏ꍇ�Ɏg�p�j���}�X�����s��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����p�r3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SpecialPurpose3
        {
            get { return _specialPurpose3; }
            set { _specialPurpose3 = value; }
        }

        /// public propaty name  :  SpecialPurpose4
        /// <summary>����p�r4�v���p�e�B</summary>
        /// <value>���R�ɐݒ�\�i����ȓ`�[�̏ꍇ�Ɏg�p�j���}�X�����s��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����p�r4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SpecialPurpose4
        {
            get { return _specialPurpose4; }
            set { _specialPurpose4 = value; }
        }

        /// public propaty name  :  TitleName102
        /// <summary>�^�C�g��1-2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�C�g��1-2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TitleName102
        {
            get { return _titleName102; }
            set { _titleName102 = value; }
        }

        /// public propaty name  :  TitleName103
        /// <summary>�^�C�g��1-3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�C�g��1-3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TitleName103
        {
            get { return _titleName103; }
            set { _titleName103 = value; }
        }

        /// public propaty name  :  TitleName104
        /// <summary>�^�C�g��1-4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�C�g��1-4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TitleName104
        {
            get { return _titleName104; }
            set { _titleName104 = value; }
        }

        /// public propaty name  :  TitleName105
        /// <summary>�^�C�g��1-5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�C�g��1-5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TitleName105
        {
            get { return _titleName105; }
            set { _titleName105 = value; }
        }

        /// public propaty name  :  TitleName202
        /// <summary>�^�C�g��2-2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�C�g��2-2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TitleName202
        {
            get { return _titleName202; }
            set { _titleName202 = value; }
        }

        /// public propaty name  :  TitleName203
        /// <summary>�^�C�g��2-3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�C�g��2-3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TitleName203
        {
            get { return _titleName203; }
            set { _titleName203 = value; }
        }

        /// public propaty name  :  TitleName204
        /// <summary>�^�C�g��2-4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�C�g��2-4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TitleName204
        {
            get { return _titleName204; }
            set { _titleName204 = value; }
        }

        /// public propaty name  :  TitleName205
        /// <summary>�^�C�g��2-5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�C�g��2-5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TitleName205
        {
            get { return _titleName205; }
            set { _titleName205 = value; }
        }

        /// public propaty name  :  TitleName302
        /// <summary>�^�C�g��3-2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�C�g��3-2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TitleName302
        {
            get { return _titleName302; }
            set { _titleName302 = value; }
        }

        /// public propaty name  :  TitleName303
        /// <summary>�^�C�g��3-3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�C�g��3-3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TitleName303
        {
            get { return _titleName303; }
            set { _titleName303 = value; }
        }

        /// public propaty name  :  TitleName304
        /// <summary>�^�C�g��3-4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�C�g��3-4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TitleName304
        {
            get { return _titleName304; }
            set { _titleName304 = value; }
        }

        /// public propaty name  :  TitleName305
        /// <summary>�^�C�g��3-5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�C�g��3-5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TitleName305
        {
            get { return _titleName305; }
            set { _titleName305 = value; }
        }

        /// public propaty name  :  TitleName402
        /// <summary>�^�C�g��4-2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�C�g��4-2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TitleName402
        {
            get { return _titleName402; }
            set { _titleName402 = value; }
        }

        /// public propaty name  :  TitleName403
        /// <summary>�^�C�g��4-3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�C�g��4-3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TitleName403
        {
            get { return _titleName403; }
            set { _titleName403 = value; }
        }

        /// public propaty name  :  TitleName404
        /// <summary>�^�C�g��4-4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�C�g��4-4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TitleName404
        {
            get { return _titleName404; }
            set { _titleName404 = value; }
        }

        /// public propaty name  :  TitleName405
        /// <summary>�^�C�g��4-5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�C�g��4-5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TitleName405
        {
            get { return _titleName405; }
            set { _titleName405 = value; }
        }

        /// public propaty name  :  Note1
        /// <summary>���l�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Note1
        {
            get { return _note1; }
            set { _note1 = value; }
        }

        /// public propaty name  :  Note2
        /// <summary>���l�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Note2
        {
            get { return _note2; }
            set { _note2 = value; }
        }

        /// public propaty name  :  Note3
        /// <summary>���l�R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Note3
        {
            get { return _note3; }
            set { _note3 = value; }
        }

        /// public propaty name  :  QRCodePrintDivCd
        /// <summary>QR�R�[�h�󎚋敪�v���p�e�B</summary>
        /// <value>0:�W�� 1:�󎚂��Ȃ� 2:�󎚂��� 3:�ԕi�܂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   QR�R�[�h�󎚋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 QRCodePrintDivCd
        {
            get { return _qRCodePrintDivCd; }
            set { _qRCodePrintDivCd = value; }
        }

        /// public propaty name  :  TimePrintDivCd
        /// <summary>�����󎚋敪�v���p�e�B</summary>
        /// <value>0:���,1:��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����󎚋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TimePrintDivCd
        {
            get { return _timePrintDivCd; }
            set { _timePrintDivCd = value; }
        }

        /// public propaty name  :  ReissueMark
        /// <summary>�Ĕ��s�}�[�N�v���p�e�B</summary>
        /// <value>�S�p�R�����܂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ĕ��s�}�[�N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ReissueMark
        {
            get { return _reissueMark; }
            set { _reissueMark = value; }
        }

        /// public propaty name  :  ConsTaxPrtCd
        /// <summary>����ň󎚋敪�v���p�e�B</summary>
        /// <value>0:���,1:��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ň󎚋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ConsTaxPrtCd
        {
            get { return _consTaxPrtCd; }
            set { _consTaxPrtCd = value; }
        }

        /// public propaty name  :  RefConsTaxDivCd
        /// <summary>�Q�l����ŋ敪�v���p�e�B</summary>
        /// <value>0:���,1:��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Q�l����ŋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RefConsTaxDivCd
        {
            get { return _refConsTaxDivCd; }
            set { _refConsTaxDivCd = value; }
        }

        /// public propaty name  :  RefConsTaxPrtNm
        /// <summary>�Q�l����ň󎚖��̃v���p�e�B</summary>
        /// <value>�S�p�T�����܂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Q�l����ň󎚖��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RefConsTaxPrtNm
        {
            get { return _refConsTaxPrtNm; }
            set { _refConsTaxPrtNm = value; }
        }

        /// public propaty name  :  DetailRowCount
        /// <summary>���׍s���v���p�e�B</summary>
        /// <value>MAX999</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���׍s���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DetailRowCount
        {
            get { return _detailRowCount; }
            set { _detailRowCount = value; }
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

        /// public propaty name  :  ConsTaxPrtCdRF 
        /// <summary>����ň󎚋敪�v���p�e�B</summary>
        /// <value>0:��� 1:��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ň󎚋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ConsTaxPrtCdRF
        {
            get { return _consTaxPrtCdRF; }
            set { _consTaxPrtCdRF = value; }
        }

        // --- ADD 2009/12/31 ---------->>>>>
        /// public propaty name  :  SlipNoteCharCnt 
        /// <summary>�`�[���l�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���l�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipNoteCharCnt
        {
            get { return _slipNoteCharCnt; }
            set { _slipNoteCharCnt = value; }
        }

        /// public propaty name  :  SlipNote2CharCnt 
        /// <summary>�`�[���l�Q�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  �`�[���l�Q�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipNote2CharCnt
        {
            get { return _slipNote2CharCnt; }
            set { _slipNote2CharCnt = value; }
        }

        /// public propaty name  :  SlipNote3CharCnt 
        /// <summary>�`�[���l�R�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���l�R�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipNote3CharCnt
        {
            get { return _slipNote3CharCnt; }
            set { _slipNote3CharCnt = value; }
        }
        // --- ADD 2009/12/31 ----------<<<<<

        // ---ADD 2010/08/06 ------------------------------------------------------------>>>>>
        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  UpdateFlag
        /// <summary>�X�V�t���O</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�t���O</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UpdateFlag
        {
            get { return _updateFlag; }
            set { _updateFlag = value; }
        }
        // ---ADD 2010/08/06 ------------------------------------------------------------<<<<<

        // ---ADD 2011/02/16 ------------------------------------------------------------>>>>>
        /// public propaty name  :  EntNmPrtExpDiv
        /// <summary>EntNmPrtExpDiv</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж��󎚊g��敪</br>
        /// <br>Programer        :   2011/02/16  ���N�n�� ���Ж��̂P�C�Q���c�{�p�ɂȂ��Ă��Ȃ��s��̑Ή�</br>
        /// </remarks>
        public Int32 EntNmPrtExpDiv
        {
            get { return _entNmPrtExpDiv; }
            set { _entNmPrtExpDiv = value; }
        }
        // ---ADD 2011/02/16 ------------------------------------------------------------<<<<<

        // ---ADD 2011/07/19 ------------------------------------------------------------>>>>>
        /// public propaty name  :  SCMAnsMarkPrtDiv
        /// <summary>SCM�񓚃}�[�N�󎚋敪�v���p�e�B</summary>
        /// <value>0:���Ȃ�,1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SCM�񓚃}�[�N�󎚋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SCMAnsMarkPrtDiv
        {
            get { return _sCMAnsMarkPrtDiv; }
            set { _sCMAnsMarkPrtDiv = value; }
        }

        /// public propaty name  :  NormalPrtMark
        /// <summary>�ʏ픭�s�}�[�N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ʏ픭�s�}�[�N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string NormalPrtMark
        {
            get { return _normalPrtMark; }
            set { _normalPrtMark = value; }
        }

        /// public propaty name  :  SCMManualAnsMark
        /// <summary>SCM�蓮�񓚃}�[�N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SCM�蓮�񓚃}�[�N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SCMManualAnsMark
        {
            get { return _sCMManualAnsMark; }
            set { _sCMManualAnsMark = value; }
        }

        /// public propaty name  :  SCMAutoAnsMark
        /// <summary>SCM�����񓚃}�[�N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SCM�����񓚃}�[�N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SCMAutoAnsMark
        {
            get { return _sCMAutoAnsMark; }
            set { _sCMAutoAnsMark = value; }
        }
        // ---ADD 2011/07/19 ------------------------------------------------------------<<<<<

        /// <summary>
        /// �`�[����ݒ胏�[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SlipPrtSetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SlipPrtSetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SlipPrtSetWork()
        {
        }

	}
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SlipPrtSetWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SlipPrtSetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SlipPrtSetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SlipPrtSetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      : 2011/02/16  ���N�n��</br>
        /// <br>                        ���Ж��̂P�C�Q���c�{�p�ɂȂ��Ă��Ȃ��s��̑Ή�</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SlipPrtSetWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SlipPrtSetWork || graph is ArrayList || graph is SlipPrtSetWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SlipPrtSetWork).FullName));

            if (graph != null && graph is SlipPrtSetWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SlipPrtSetWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SlipPrtSetWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SlipPrtSetWork[])graph).Length;
            }
            else if (graph is SlipPrtSetWork)
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
            //�f�[�^���̓V�X�e��
            serInfo.MemberInfo.Add(typeof(Int32)); //DataInputSystem
            //�`�[������
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipPrtKind
            //�`�[����ݒ�p���[ID
            serInfo.MemberInfo.Add(typeof(string)); //SlipPrtSetPaperId
            //�`�[�R�����g
            serInfo.MemberInfo.Add(typeof(string)); //SlipComment
            //�o�̓v���O����ID
            serInfo.MemberInfo.Add(typeof(string)); //OutputPgId
            //�o�̓v���O�����N���XID
            serInfo.MemberInfo.Add(typeof(string)); //OutputPgClassId
            //�o�̓t�@�C����
            serInfo.MemberInfo.Add(typeof(string)); //OutputFormFileName
            //���Ж�����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterpriseNamePrtCd
            //�������
            serInfo.MemberInfo.Add(typeof(Int32)); //PrtCirculation
            //�`�[�p���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipFormCd
            //�o�͊m�F���b�Z�[�W
            serInfo.MemberInfo.Add(typeof(string)); //OutConfimationMsg
            //�I�v�V�����R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //OptionCode
            //��]��
            serInfo.MemberInfo.Add(typeof(Double)); //TopMargin
            //���]��
            serInfo.MemberInfo.Add(typeof(Double)); //LeftMargin
            //�E�]��
            serInfo.MemberInfo.Add(typeof(Double)); //RightMargin
            //���]��
            serInfo.MemberInfo.Add(typeof(Double)); //BottomMargin
            //����v���r���L���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //PrtPreviewExistCode
            //�o�͗p�r
            serInfo.MemberInfo.Add(typeof(Int32)); //OutputPurpose
            //�`�[�^�C�v�ʗ�ID1
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColId1
            //�`�[�^�C�v�ʗ񖼏�1
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColNm1
            //�`�[�^�C�v�ʗ�󎚋敪1
            serInfo.MemberInfo.Add(typeof(Int32)); //EachSlipTypeColPrt1
            //�`�[�^�C�v�ʗ�ID2
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColId2
            //�`�[�^�C�v�ʗ񖼏�2
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColNm2
            //�`�[�^�C�v�ʗ�󎚋敪2
            serInfo.MemberInfo.Add(typeof(Int32)); //EachSlipTypeColPrt2
            //�`�[�^�C�v�ʗ�ID3
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColId3
            //�`�[�^�C�v�ʗ񖼏�3
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColNm3
            //�`�[�^�C�v�ʗ�󎚋敪3
            serInfo.MemberInfo.Add(typeof(Int32)); //EachSlipTypeColPrt3
            //�`�[�^�C�v�ʗ�ID4
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColId4
            //�`�[�^�C�v�ʗ񖼏�4
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColNm4
            //�`�[�^�C�v�ʗ�󎚋敪4
            serInfo.MemberInfo.Add(typeof(Int32)); //EachSlipTypeColPrt4
            //�`�[�^�C�v�ʗ�ID5
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColId5
            //�`�[�^�C�v�ʗ񖼏�5
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColNm5
            //�`�[�^�C�v�ʗ�󎚋敪5
            serInfo.MemberInfo.Add(typeof(Int32)); //EachSlipTypeColPrt5
            //�`�[�^�C�v�ʗ�ID6
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColId6
            //�`�[�^�C�v�ʗ񖼏�6
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColNm6
            //�`�[�^�C�v�ʗ�󎚋敪6
            serInfo.MemberInfo.Add(typeof(Int32)); //EachSlipTypeColPrt6
            //�`�[�^�C�v�ʗ�ID7
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColId7
            //�`�[�^�C�v�ʗ񖼏�7
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColNm7
            //�`�[�^�C�v�ʗ�󎚋敪7
            serInfo.MemberInfo.Add(typeof(Int32)); //EachSlipTypeColPrt7
            //�`�[�^�C�v�ʗ�ID8
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColId8
            //�`�[�^�C�v�ʗ񖼏�8
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColNm8
            //�`�[�^�C�v�ʗ�󎚋敪8
            serInfo.MemberInfo.Add(typeof(Int32)); //EachSlipTypeColPrt8
            //�`�[�^�C�v�ʗ�ID9
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColId9
            //�`�[�^�C�v�ʗ񖼏�9
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColNm9
            //�`�[�^�C�v�ʗ�󎚋敪9
            serInfo.MemberInfo.Add(typeof(Int32)); //EachSlipTypeColPrt9
            //�`�[�^�C�v�ʗ�ID10
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColId10
            //�`�[�^�C�v�ʗ񖼏�10
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColNm10
            //�`�[�^�C�v�ʗ�󎚋敪10
            serInfo.MemberInfo.Add(typeof(Int32)); //EachSlipTypeColPrt10
            //�`�[�t�H���g����
            serInfo.MemberInfo.Add(typeof(string)); //SlipFontName
            //�`�[�t�H���g�T�C�Y
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipFontSize
            //�`�[�t�H���g�X�^�C��
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipFontStyle
            //�`�[��F��1
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipBaseColorRed1
            //�`�[��F��1
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipBaseColorGrn1
            //�`�[��F��1
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipBaseColorBlu1
            //�`�[��F��2
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipBaseColorRed2
            //�`�[��F��2
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipBaseColorGrn2
            //�`�[��F��2
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipBaseColorBlu2
            //�`�[��F��3
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipBaseColorRed3
            //�`�[��F��3
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipBaseColorGrn3
            //�`�[��F��3
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipBaseColorBlu3
            //�`�[��F��4
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipBaseColorRed4
            //�`�[��F��4
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipBaseColorGrn4
            //�`�[��F��4
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipBaseColorBlu4
            //�`�[��F��5
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipBaseColorRed5
            //�`�[��F��5
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipBaseColorGrn5
            //�`�[��F��5
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipBaseColorBlu5
            //���ʖ���
            serInfo.MemberInfo.Add(typeof(Int32)); //CopyCount
            //�^�C�g��1
            serInfo.MemberInfo.Add(typeof(string)); //TitleName1
            //�^�C�g��2
            serInfo.MemberInfo.Add(typeof(string)); //TitleName2
            //�^�C�g��3
            serInfo.MemberInfo.Add(typeof(string)); //TitleName3
            //�^�C�g��4
            serInfo.MemberInfo.Add(typeof(string)); //TitleName4
            //����p�r1
            serInfo.MemberInfo.Add(typeof(string)); //SpecialPurpose1
            //����p�r2
            serInfo.MemberInfo.Add(typeof(string)); //SpecialPurpose2
            //����p�r3
            serInfo.MemberInfo.Add(typeof(string)); //SpecialPurpose3
            //����p�r4
            serInfo.MemberInfo.Add(typeof(string)); //SpecialPurpose4
            //�^�C�g��1-2
            serInfo.MemberInfo.Add(typeof(string)); //TitleName102
            //�^�C�g��1-3
            serInfo.MemberInfo.Add(typeof(string)); //TitleName103
            //�^�C�g��1-4
            serInfo.MemberInfo.Add(typeof(string)); //TitleName104
            //�^�C�g��1-5
            serInfo.MemberInfo.Add(typeof(string)); //TitleName105
            //�^�C�g��2-2
            serInfo.MemberInfo.Add(typeof(string)); //TitleName202
            //�^�C�g��2-3
            serInfo.MemberInfo.Add(typeof(string)); //TitleName203
            //�^�C�g��2-4
            serInfo.MemberInfo.Add(typeof(string)); //TitleName204
            //�^�C�g��2-5
            serInfo.MemberInfo.Add(typeof(string)); //TitleName205
            //�^�C�g��3-2
            serInfo.MemberInfo.Add(typeof(string)); //TitleName302
            //�^�C�g��3-3
            serInfo.MemberInfo.Add(typeof(string)); //TitleName303
            //�^�C�g��3-4
            serInfo.MemberInfo.Add(typeof(string)); //TitleName304
            //�^�C�g��3-5
            serInfo.MemberInfo.Add(typeof(string)); //TitleName305
            //�^�C�g��4-2
            serInfo.MemberInfo.Add(typeof(string)); //TitleName402
            //�^�C�g��4-3
            serInfo.MemberInfo.Add(typeof(string)); //TitleName403
            //�^�C�g��4-4
            serInfo.MemberInfo.Add(typeof(string)); //TitleName404
            //�^�C�g��4-5
            serInfo.MemberInfo.Add(typeof(string)); //TitleName405
            //���l�P
            serInfo.MemberInfo.Add(typeof(string)); //Note1
            //���l�Q
            serInfo.MemberInfo.Add(typeof(string)); //Note2
            //���l�R
            serInfo.MemberInfo.Add(typeof(string)); //Note3
            //QR�R�[�h�󎚋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //QRCodePrintDivCd
            //�����󎚋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //TimePrintDivCd
            //�Ĕ��s�}�[�N
            serInfo.MemberInfo.Add(typeof(string)); //ReissueMark
            //����ň󎚋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //ConsTaxPrtCd
            //�Q�l����ŋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //RefConsTaxDivCd
            //�Q�l����ň󎚖���
            serInfo.MemberInfo.Add(typeof(string)); //RefConsTaxPrtNm
            //���׍s��
            serInfo.MemberInfo.Add(typeof(Int32)); //DetailRowCount
            //�h��
            serInfo.MemberInfo.Add(typeof(string)); //HonorificTitle
            //����ň󎚋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //ConsTaxPrtCdRF 

            // --- ADD 2009/12/31 ---------->>>>>
            //�`�[���l����
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipNoteCharCnt 
            //�`�[���l�Q����
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipNote2CharCnt 
            //�`�[���l�R����
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipNote3CharCnt 
            // --- ADD 2009/12/31 ----------<<<<<

            // ---ADD 2010/08/06 ------------------------------------------------------------>>>>>
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateFlag
            // ---ADD 2010/08/06 ------------------------------------------------------------<<<<<

            // ---ADD 2011/02/16 ------------------------------------------------------------>>>>>
            //���Ж��󎚊g��敪
            serInfo.MemberInfo.Add(typeof(Int32)); //EntNmPrtExpDiv 
            // ---ADD 2011/02/16 ------------------------------------------------------------<<<<<

            // ---ADD 2011/07/19 ------------------------------------------------------------>>>>>
            //SCM�񓚃}�[�N�󎚋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SCMAnsMarkPrtDiv
            //�ʏ픭�s�}�[�N
            serInfo.MemberInfo.Add(typeof(string)); //NormalPrtMark
            //SCM�蓮�񓚃}�[�N
            serInfo.MemberInfo.Add(typeof(string)); //SCMManualAnsMark
            //SCM�����񓚃}�[�N
            serInfo.MemberInfo.Add(typeof(string)); //SCMAutoAnsMark
            // ---ADD 2011/07/19 ------------------------------------------------------------<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is SlipPrtSetWork)
            {
                SlipPrtSetWork temp = (SlipPrtSetWork)graph;

                SetSlipPrtSetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SlipPrtSetWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SlipPrtSetWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SlipPrtSetWork temp in lst)
                {
                    SetSlipPrtSetWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SlipPrtSetWork�����o��(public�v���p�e�B��)
        /// </summary>
        //private const int currentMemberCount = 114;
        //private const int currentMemberCount = 116; // DEL 2011/02/16
        //private const int currentMemberCount = 117; // ADD 2011/02/16  // DEL 2011/07/19
        private const int currentMemberCount = 121; // ADD 2011/07/19

        /// <summary>
        ///  SlipPrtSetWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SlipPrtSetWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      : 2011/02/16  ���N�n��</br>
        /// <br>                        ���Ж��̂P�C�Q���c�{�p�ɂȂ��Ă��Ȃ��s��̑Ή�</br>
        /// </remarks>
        private void SetSlipPrtSetWork(System.IO.BinaryWriter writer, SlipPrtSetWork temp)
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
            //�f�[�^���̓V�X�e��
            writer.Write(temp.DataInputSystem);
            //�`�[������
            writer.Write(temp.SlipPrtKind);
            //�`�[����ݒ�p���[ID
            writer.Write(temp.SlipPrtSetPaperId);
            //�`�[�R�����g
            writer.Write(temp.SlipComment);
            //�o�̓v���O����ID
            writer.Write(temp.OutputPgId);
            //�o�̓v���O�����N���XID
            writer.Write(temp.OutputPgClassId);
            //�o�̓t�@�C����
            writer.Write(temp.OutputFormFileName);
            //���Ж�����敪
            writer.Write(temp.EnterpriseNamePrtCd);
            //�������
            writer.Write(temp.PrtCirculation);
            //�`�[�p���敪
            writer.Write(temp.SlipFormCd);
            //�o�͊m�F���b�Z�[�W
            writer.Write(temp.OutConfimationMsg);
            //�I�v�V�����R�[�h
            writer.Write(temp.OptionCode);
            //��]��
            writer.Write(temp.TopMargin);
            //���]��
            writer.Write(temp.LeftMargin);
            //�E�]��
            writer.Write(temp.RightMargin);
            //���]��
            writer.Write(temp.BottomMargin);
            //����v���r���L���敪
            writer.Write(temp.PrtPreviewExistCode);
            //�o�͗p�r
            writer.Write(temp.OutputPurpose);
            //�`�[�^�C�v�ʗ�ID1
            writer.Write(temp.EachSlipTypeColId1);
            //�`�[�^�C�v�ʗ񖼏�1
            writer.Write(temp.EachSlipTypeColNm1);
            //�`�[�^�C�v�ʗ�󎚋敪1
            writer.Write(temp.EachSlipTypeColPrt1);
            //�`�[�^�C�v�ʗ�ID2
            writer.Write(temp.EachSlipTypeColId2);
            //�`�[�^�C�v�ʗ񖼏�2
            writer.Write(temp.EachSlipTypeColNm2);
            //�`�[�^�C�v�ʗ�󎚋敪2
            writer.Write(temp.EachSlipTypeColPrt2);
            //�`�[�^�C�v�ʗ�ID3
            writer.Write(temp.EachSlipTypeColId3);
            //�`�[�^�C�v�ʗ񖼏�3
            writer.Write(temp.EachSlipTypeColNm3);
            //�`�[�^�C�v�ʗ�󎚋敪3
            writer.Write(temp.EachSlipTypeColPrt3);
            //�`�[�^�C�v�ʗ�ID4
            writer.Write(temp.EachSlipTypeColId4);
            //�`�[�^�C�v�ʗ񖼏�4
            writer.Write(temp.EachSlipTypeColNm4);
            //�`�[�^�C�v�ʗ�󎚋敪4
            writer.Write(temp.EachSlipTypeColPrt4);
            //�`�[�^�C�v�ʗ�ID5
            writer.Write(temp.EachSlipTypeColId5);
            //�`�[�^�C�v�ʗ񖼏�5
            writer.Write(temp.EachSlipTypeColNm5);
            //�`�[�^�C�v�ʗ�󎚋敪5
            writer.Write(temp.EachSlipTypeColPrt5);
            //�`�[�^�C�v�ʗ�ID6
            writer.Write(temp.EachSlipTypeColId6);
            //�`�[�^�C�v�ʗ񖼏�6
            writer.Write(temp.EachSlipTypeColNm6);
            //�`�[�^�C�v�ʗ�󎚋敪6
            writer.Write(temp.EachSlipTypeColPrt6);
            //�`�[�^�C�v�ʗ�ID7
            writer.Write(temp.EachSlipTypeColId7);
            //�`�[�^�C�v�ʗ񖼏�7
            writer.Write(temp.EachSlipTypeColNm7);
            //�`�[�^�C�v�ʗ�󎚋敪7
            writer.Write(temp.EachSlipTypeColPrt7);
            //�`�[�^�C�v�ʗ�ID8
            writer.Write(temp.EachSlipTypeColId8);
            //�`�[�^�C�v�ʗ񖼏�8
            writer.Write(temp.EachSlipTypeColNm8);
            //�`�[�^�C�v�ʗ�󎚋敪8
            writer.Write(temp.EachSlipTypeColPrt8);
            //�`�[�^�C�v�ʗ�ID9
            writer.Write(temp.EachSlipTypeColId9);
            //�`�[�^�C�v�ʗ񖼏�9
            writer.Write(temp.EachSlipTypeColNm9);
            //�`�[�^�C�v�ʗ�󎚋敪9
            writer.Write(temp.EachSlipTypeColPrt9);
            //�`�[�^�C�v�ʗ�ID10
            writer.Write(temp.EachSlipTypeColId10);
            //�`�[�^�C�v�ʗ񖼏�10
            writer.Write(temp.EachSlipTypeColNm10);
            //�`�[�^�C�v�ʗ�󎚋敪10
            writer.Write(temp.EachSlipTypeColPrt10);
            //�`�[�t�H���g����
            writer.Write(temp.SlipFontName);
            //�`�[�t�H���g�T�C�Y
            writer.Write(temp.SlipFontSize);
            //�`�[�t�H���g�X�^�C��
            writer.Write(temp.SlipFontStyle);
            //�`�[��F��1
            writer.Write(temp.SlipBaseColorRed1);
            //�`�[��F��1
            writer.Write(temp.SlipBaseColorGrn1);
            //�`�[��F��1
            writer.Write(temp.SlipBaseColorBlu1);
            //�`�[��F��2
            writer.Write(temp.SlipBaseColorRed2);
            //�`�[��F��2
            writer.Write(temp.SlipBaseColorGrn2);
            //�`�[��F��2
            writer.Write(temp.SlipBaseColorBlu2);
            //�`�[��F��3
            writer.Write(temp.SlipBaseColorRed3);
            //�`�[��F��3
            writer.Write(temp.SlipBaseColorGrn3);
            //�`�[��F��3
            writer.Write(temp.SlipBaseColorBlu3);
            //�`�[��F��4
            writer.Write(temp.SlipBaseColorRed4);
            //�`�[��F��4
            writer.Write(temp.SlipBaseColorGrn4);
            //�`�[��F��4
            writer.Write(temp.SlipBaseColorBlu4);
            //�`�[��F��5
            writer.Write(temp.SlipBaseColorRed5);
            //�`�[��F��5
            writer.Write(temp.SlipBaseColorGrn5);
            //�`�[��F��5
            writer.Write(temp.SlipBaseColorBlu5);
            //���ʖ���
            writer.Write(temp.CopyCount);
            //�^�C�g��1
            writer.Write(temp.TitleName1);
            //�^�C�g��2
            writer.Write(temp.TitleName2);
            //�^�C�g��3
            writer.Write(temp.TitleName3);
            //�^�C�g��4
            writer.Write(temp.TitleName4);
            //����p�r1
            writer.Write(temp.SpecialPurpose1);
            //����p�r2
            writer.Write(temp.SpecialPurpose2);
            //����p�r3
            writer.Write(temp.SpecialPurpose3);
            //����p�r4
            writer.Write(temp.SpecialPurpose4);
            //�^�C�g��1-2
            writer.Write(temp.TitleName102);
            //�^�C�g��1-3
            writer.Write(temp.TitleName103);
            //�^�C�g��1-4
            writer.Write(temp.TitleName104);
            //�^�C�g��1-5
            writer.Write(temp.TitleName105);
            //�^�C�g��2-2
            writer.Write(temp.TitleName202);
            //�^�C�g��2-3
            writer.Write(temp.TitleName203);
            //�^�C�g��2-4
            writer.Write(temp.TitleName204);
            //�^�C�g��2-5
            writer.Write(temp.TitleName205);
            //�^�C�g��3-2
            writer.Write(temp.TitleName302);
            //�^�C�g��3-3
            writer.Write(temp.TitleName303);
            //�^�C�g��3-4
            writer.Write(temp.TitleName304);
            //�^�C�g��3-5
            writer.Write(temp.TitleName305);
            //�^�C�g��4-2
            writer.Write(temp.TitleName402);
            //�^�C�g��4-3
            writer.Write(temp.TitleName403);
            //�^�C�g��4-4
            writer.Write(temp.TitleName404);
            //�^�C�g��4-5
            writer.Write(temp.TitleName405);
            //���l�P
            writer.Write(temp.Note1);
            //���l�Q
            writer.Write(temp.Note2);
            //���l�R
            writer.Write(temp.Note3);
            //QR�R�[�h�󎚋敪
            writer.Write(temp.QRCodePrintDivCd);
            //�����󎚋敪
            writer.Write(temp.TimePrintDivCd);
            //�Ĕ��s�}�[�N
            writer.Write(temp.ReissueMark);
            //����ň󎚋敪
            writer.Write(temp.ConsTaxPrtCd);
            //�Q�l����ŋ敪
            writer.Write(temp.RefConsTaxDivCd);
            //�Q�l����ň󎚖���
            writer.Write(temp.RefConsTaxPrtNm);
            //���׍s��
            writer.Write(temp.DetailRowCount);
            //�h��
            writer.Write(temp.HonorificTitle);
            //����ň󎚋敪
            writer.Write(temp.ConsTaxPrtCdRF);
            // --- ADD 2009/12/31 ---------->>>>>
            //�`�[���l����
            writer.Write(temp.SlipNoteCharCnt);
            //�`�[���l�Q����
            writer.Write(temp.SlipNote2CharCnt);
            //�`�[���l�R����
            writer.Write(temp.SlipNote3CharCnt);
            // --- ADD 2009/12/31 ----------<<<<<

            // ---ADD 2010/08/06 ------------------------------------------------------------>>>>>
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //�X�V�t���O
            writer.Write(temp.UpdateFlag);
            // ---ADD 2010/08/06 ------------------------------------------------------------<<<<<
            
            // ---ADD 2011/02/16 ------------------------------------------------------------>>>>>
            //���Ж��󎚊g��敪
            writer.Write(temp.EntNmPrtExpDiv); 
            // ---ADD 2011/02/16 ------------------------------------------------------------>>>>>

            // ---ADD 2011/07/19 ------------------------------------------------------------>>>>>
            //SCM�񓚃}�[�N�󎚋敪
            writer.Write(temp.SCMAnsMarkPrtDiv);
            //�ʏ픭�s�}�[�N
            writer.Write(temp.NormalPrtMark);
            //SCM�蓮�񓚃}�[�N
            writer.Write(temp.SCMManualAnsMark);
            //SCM�����񓚃}�[�N
            writer.Write(temp.SCMAutoAnsMark);
            // ---ADD 2011/07/19 ------------------------------------------------------------>>>>>
        }

        /// <summary>
        ///  SlipPrtSetWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SlipPrtSetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SlipPrtSetWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      : 2011/02/16  ���N�n��</br>
        /// <br>                        ���Ж��̂P�C�Q���c�{�p�ɂȂ��Ă��Ȃ��s��̑Ή�</br>
        /// </remarks>
        private SlipPrtSetWork GetSlipPrtSetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SlipPrtSetWork temp = new SlipPrtSetWork();

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
            //�f�[�^���̓V�X�e��
            temp.DataInputSystem = reader.ReadInt32();
            //�`�[������
            temp.SlipPrtKind = reader.ReadInt32();
            //�`�[����ݒ�p���[ID
            temp.SlipPrtSetPaperId = reader.ReadString();
            //�`�[�R�����g
            temp.SlipComment = reader.ReadString();
            //�o�̓v���O����ID
            temp.OutputPgId = reader.ReadString();
            //�o�̓v���O�����N���XID
            temp.OutputPgClassId = reader.ReadString();
            //�o�̓t�@�C����
            temp.OutputFormFileName = reader.ReadString();
            //���Ж�����敪
            temp.EnterpriseNamePrtCd = reader.ReadInt32();
            //�������
            temp.PrtCirculation = reader.ReadInt32();
            //�`�[�p���敪
            temp.SlipFormCd = reader.ReadInt32();
            //�o�͊m�F���b�Z�[�W
            temp.OutConfimationMsg = reader.ReadString();
            //�I�v�V�����R�[�h
            temp.OptionCode = reader.ReadString();
            //��]��
            temp.TopMargin = reader.ReadDouble();
            //���]��
            temp.LeftMargin = reader.ReadDouble();
            //�E�]��
            temp.RightMargin = reader.ReadDouble();
            //���]��
            temp.BottomMargin = reader.ReadDouble();
            //����v���r���L���敪
            temp.PrtPreviewExistCode = reader.ReadInt32();
            //�o�͗p�r
            temp.OutputPurpose = reader.ReadInt32();
            //�`�[�^�C�v�ʗ�ID1
            temp.EachSlipTypeColId1 = reader.ReadString();
            //�`�[�^�C�v�ʗ񖼏�1
            temp.EachSlipTypeColNm1 = reader.ReadString();
            //�`�[�^�C�v�ʗ�󎚋敪1
            temp.EachSlipTypeColPrt1 = reader.ReadInt32();
            //�`�[�^�C�v�ʗ�ID2
            temp.EachSlipTypeColId2 = reader.ReadString();
            //�`�[�^�C�v�ʗ񖼏�2
            temp.EachSlipTypeColNm2 = reader.ReadString();
            //�`�[�^�C�v�ʗ�󎚋敪2
            temp.EachSlipTypeColPrt2 = reader.ReadInt32();
            //�`�[�^�C�v�ʗ�ID3
            temp.EachSlipTypeColId3 = reader.ReadString();
            //�`�[�^�C�v�ʗ񖼏�3
            temp.EachSlipTypeColNm3 = reader.ReadString();
            //�`�[�^�C�v�ʗ�󎚋敪3
            temp.EachSlipTypeColPrt3 = reader.ReadInt32();
            //�`�[�^�C�v�ʗ�ID4
            temp.EachSlipTypeColId4 = reader.ReadString();
            //�`�[�^�C�v�ʗ񖼏�4
            temp.EachSlipTypeColNm4 = reader.ReadString();
            //�`�[�^�C�v�ʗ�󎚋敪4
            temp.EachSlipTypeColPrt4 = reader.ReadInt32();
            //�`�[�^�C�v�ʗ�ID5
            temp.EachSlipTypeColId5 = reader.ReadString();
            //�`�[�^�C�v�ʗ񖼏�5
            temp.EachSlipTypeColNm5 = reader.ReadString();
            //�`�[�^�C�v�ʗ�󎚋敪5
            temp.EachSlipTypeColPrt5 = reader.ReadInt32();
            //�`�[�^�C�v�ʗ�ID6
            temp.EachSlipTypeColId6 = reader.ReadString();
            //�`�[�^�C�v�ʗ񖼏�6
            temp.EachSlipTypeColNm6 = reader.ReadString();
            //�`�[�^�C�v�ʗ�󎚋敪6
            temp.EachSlipTypeColPrt6 = reader.ReadInt32();
            //�`�[�^�C�v�ʗ�ID7
            temp.EachSlipTypeColId7 = reader.ReadString();
            //�`�[�^�C�v�ʗ񖼏�7
            temp.EachSlipTypeColNm7 = reader.ReadString();
            //�`�[�^�C�v�ʗ�󎚋敪7
            temp.EachSlipTypeColPrt7 = reader.ReadInt32();
            //�`�[�^�C�v�ʗ�ID8
            temp.EachSlipTypeColId8 = reader.ReadString();
            //�`�[�^�C�v�ʗ񖼏�8
            temp.EachSlipTypeColNm8 = reader.ReadString();
            //�`�[�^�C�v�ʗ�󎚋敪8
            temp.EachSlipTypeColPrt8 = reader.ReadInt32();
            //�`�[�^�C�v�ʗ�ID9
            temp.EachSlipTypeColId9 = reader.ReadString();
            //�`�[�^�C�v�ʗ񖼏�9
            temp.EachSlipTypeColNm9 = reader.ReadString();
            //�`�[�^�C�v�ʗ�󎚋敪9
            temp.EachSlipTypeColPrt9 = reader.ReadInt32();
            //�`�[�^�C�v�ʗ�ID10
            temp.EachSlipTypeColId10 = reader.ReadString();
            //�`�[�^�C�v�ʗ񖼏�10
            temp.EachSlipTypeColNm10 = reader.ReadString();
            //�`�[�^�C�v�ʗ�󎚋敪10
            temp.EachSlipTypeColPrt10 = reader.ReadInt32();
            //�`�[�t�H���g����
            temp.SlipFontName = reader.ReadString();
            //�`�[�t�H���g�T�C�Y
            temp.SlipFontSize = reader.ReadInt32();
            //�`�[�t�H���g�X�^�C��
            temp.SlipFontStyle = reader.ReadInt32();
            //�`�[��F��1
            temp.SlipBaseColorRed1 = reader.ReadInt32();
            //�`�[��F��1
            temp.SlipBaseColorGrn1 = reader.ReadInt32();
            //�`�[��F��1
            temp.SlipBaseColorBlu1 = reader.ReadInt32();
            //�`�[��F��2
            temp.SlipBaseColorRed2 = reader.ReadInt32();
            //�`�[��F��2
            temp.SlipBaseColorGrn2 = reader.ReadInt32();
            //�`�[��F��2
            temp.SlipBaseColorBlu2 = reader.ReadInt32();
            //�`�[��F��3
            temp.SlipBaseColorRed3 = reader.ReadInt32();
            //�`�[��F��3
            temp.SlipBaseColorGrn3 = reader.ReadInt32();
            //�`�[��F��3
            temp.SlipBaseColorBlu3 = reader.ReadInt32();
            //�`�[��F��4
            temp.SlipBaseColorRed4 = reader.ReadInt32();
            //�`�[��F��4
            temp.SlipBaseColorGrn4 = reader.ReadInt32();
            //�`�[��F��4
            temp.SlipBaseColorBlu4 = reader.ReadInt32();
            //�`�[��F��5
            temp.SlipBaseColorRed5 = reader.ReadInt32();
            //�`�[��F��5
            temp.SlipBaseColorGrn5 = reader.ReadInt32();
            //�`�[��F��5
            temp.SlipBaseColorBlu5 = reader.ReadInt32();
            //���ʖ���
            temp.CopyCount = reader.ReadInt32();
            //�^�C�g��1
            temp.TitleName1 = reader.ReadString();
            //�^�C�g��2
            temp.TitleName2 = reader.ReadString();
            //�^�C�g��3
            temp.TitleName3 = reader.ReadString();
            //�^�C�g��4
            temp.TitleName4 = reader.ReadString();
            //����p�r1
            temp.SpecialPurpose1 = reader.ReadString();
            //����p�r2
            temp.SpecialPurpose2 = reader.ReadString();
            //����p�r3
            temp.SpecialPurpose3 = reader.ReadString();
            //����p�r4
            temp.SpecialPurpose4 = reader.ReadString();
            //�^�C�g��1-2
            temp.TitleName102 = reader.ReadString();
            //�^�C�g��1-3
            temp.TitleName103 = reader.ReadString();
            //�^�C�g��1-4
            temp.TitleName104 = reader.ReadString();
            //�^�C�g��1-5
            temp.TitleName105 = reader.ReadString();
            //�^�C�g��2-2
            temp.TitleName202 = reader.ReadString();
            //�^�C�g��2-3
            temp.TitleName203 = reader.ReadString();
            //�^�C�g��2-4
            temp.TitleName204 = reader.ReadString();
            //�^�C�g��2-5
            temp.TitleName205 = reader.ReadString();
            //�^�C�g��3-2
            temp.TitleName302 = reader.ReadString();
            //�^�C�g��3-3
            temp.TitleName303 = reader.ReadString();
            //�^�C�g��3-4
            temp.TitleName304 = reader.ReadString();
            //�^�C�g��3-5
            temp.TitleName305 = reader.ReadString();
            //�^�C�g��4-2
            temp.TitleName402 = reader.ReadString();
            //�^�C�g��4-3
            temp.TitleName403 = reader.ReadString();
            //�^�C�g��4-4
            temp.TitleName404 = reader.ReadString();
            //�^�C�g��4-5
            temp.TitleName405 = reader.ReadString();
            //���l�P
            temp.Note1 = reader.ReadString();
            //���l�Q
            temp.Note2 = reader.ReadString();
            //���l�R
            temp.Note3 = reader.ReadString();
            //QR�R�[�h�󎚋敪
            temp.QRCodePrintDivCd = reader.ReadInt32();
            //�����󎚋敪
            temp.TimePrintDivCd = reader.ReadInt32();
            //�Ĕ��s�}�[�N
            temp.ReissueMark = reader.ReadString();
            //����ň󎚋敪
            temp.ConsTaxPrtCd = reader.ReadInt32();
            //�Q�l����ŋ敪
            temp.RefConsTaxDivCd = reader.ReadInt32();
            //�Q�l����ň󎚖���
            temp.RefConsTaxPrtNm = reader.ReadString();
            //���׍s��
            temp.DetailRowCount = reader.ReadInt32();
            //�h��
            temp.HonorificTitle = reader.ReadString();
            //����ň󎚋敪
            temp.ConsTaxPrtCdRF = reader.ReadInt32();
            // --- ADD 2009/12/31 ---------->>>>>
            //�`�[���l����
            temp.SlipNoteCharCnt = reader.ReadInt32();
            //�`�[���l�Q����
            temp.SlipNote2CharCnt = reader.ReadInt32();
            //�`�[���l�R����
            temp.SlipNote3CharCnt = reader.ReadInt32();
            // --- ADD 2009/12/31 ----------<<<<<

            // ---ADD 2010/08/06 ------------------------------------------------------------>>>>>
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //�X�V�t���O
            temp.UpdateFlag = reader.ReadInt32();
            // ---ADD 2010/08/06 ------------------------------------------------------------<<<<<

            // ---ADD 2011/02/16 ------------------------------------------------------------>>>>>
            //���Ж��󎚊g��敪
            temp.EntNmPrtExpDiv = reader.ReadInt32();
            // ---ADD 2011/02/16 ------------------------------------------------------------<<<<<

            // ---ADD 2011/07/19 ------------------------------------------------------------>>>>>
            //SCM�񓚃}�[�N�󎚋敪
            temp.SCMAnsMarkPrtDiv = reader.ReadInt32();
            //�ʏ픭�s�}�[�N
            temp.NormalPrtMark = reader.ReadString();
            //SCM�蓮�񓚃}�[�N
            temp.SCMManualAnsMark = reader.ReadString();
            //SCM�����񓚃}�[�N
            temp.SCMAutoAnsMark = reader.ReadString();
            // ---ADD 2011/07/19 ------------------------------------------------------------<<<<<
            
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
        /// <returns>SlipPrtSetWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SlipPrtSetWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SlipPrtSetWork temp = GetSlipPrtSetWork(reader, serInfo);
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
                    retValue = (SlipPrtSetWork[])lst.ToArray(typeof(SlipPrtSetWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}



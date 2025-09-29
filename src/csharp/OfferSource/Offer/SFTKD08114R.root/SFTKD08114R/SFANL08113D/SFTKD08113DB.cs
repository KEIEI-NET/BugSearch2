using System;
using System.Collections;

using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   PrtItemSetWork
	/// <summary>
	///                      �󎚍��ڐݒ胏�[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �󎚍��ڐݒ胏�[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2007/03/15</br>
	/// <br>Genarated Date   :   2007/10/12  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class PrtItemSetWork : IFileHeaderOffer
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

		/// <summary>���R���[���ڃO���[�v�R�[�h</summary>
		private Int32 _freePrtPprItemGrpCd;

		/// <summary>���R���[���ڃR�[�h</summary>
		/// <remarks>1�`100:ActiveReport�p,101�`:.NS�p</remarks>
		private Int32 _freePrtPaperItemCd;

		/// <summary>���R���[���ږ���</summary>
		private string _freePrtPaperItemNm = "";

		/// <summary>�t�@�C������</summary>
		/// <remarks>DB�̃e�[�u��ID</remarks>
		private string _fileNm = "";

		/// <summary>DD����</summary>
		private Int32 _dDCharCnt;

		/// <summary>DD����</summary>
		/// <remarks>�������œo�^</remarks>
		private string _dDName = "";

		/// <summary>���|�[�g�R���g���[���敪</summary>
		/// <remarks>1:TextBox,2:Label,3:Picture,4:Shape,5:Line,6:BarCode</remarks>
		private Int32 _reportControlCode;

		/// <summary>�w�b�_�[�g�p�敪</summary>
		/// <remarks>0:�g�p�s��,1:�g�p��</remarks>
		private Int32 _headerUseDivCd;

		/// <summary>���׎g�p�敪</summary>
		/// <remarks>0:�g�p�s��,1:�g�p��</remarks>
		private Int32 _detailUseDivCd;

		/// <summary>�t�b�^�[�g�p�敪</summary>
		/// <remarks>0:�g�p�s��,1:�g�p��</remarks>
		private Int32 _footerUseDivCd;

		/// <summary>���o�����敪</summary>
		/// <remarks>0:�g�p�s��,1:���l�^,2:�����^�i���p�j,3:�����^�i�S�p�j,4:���t�^,5:�R���{�^,6:�`�F�b�N�^</remarks>
		private Int32 _extraConditionDivCd;

		/// <summary>���o�����^�C�v</summary>
		/// <remarks>0:��v,1:�͈�,2:�����܂�,3:����</remarks>
		private Int32 _extraConditionTypeCd;

		/// <summary>�J���}�ҏW�L��</summary>
		/// <remarks>0:�Ȃ�,1:"#,###",2:"#,##0",3:"0.0",4:"0.00"</remarks>
		private Int32 _commaEditExistCd;

		/// <summary>�󎚃y�[�W����敪</summary>
		/// <remarks>0:�S�y�[�W,1:1�y�[�W�ڂ̂�,2:�ŏI�y�[�W�̂�</remarks>
		private Int32 _printPageCtrlDivCd;

		/// <summary>�V�X�e���敪</summary>
		/// <remarks>0:����,1:SF,2:BK,3:SH</remarks>
		private Int32 _systemDivCd;

		/// <summary>�I�v�V�����R�[�h</summary>
		/// <remarks>���я�̵�߼�ݺ���</remarks>
		private string _optionCode = "";

		/// <summary>���o�������׃O���[�v�R�[�h</summary>
		/// <remarks>���o�����敪���R���{�{�b�N�X�^�̎��Ɏg�p</remarks>
		private Int32 _extraCondDetailGrpCd;

		/// <summary>�W�v���ڋ敪</summary>
		/// <remarks>0:�g�p�s��,1:�g�p��</remarks>
		private Int32 _totalItemDivCd;

		/// <summary>���ō��ڋ敪</summary>
		/// <remarks>0:�g�p�s��,1:�g�p��</remarks>
		private Int32 _formFeedItemDivCd;

		/// <summary>���R���[�\���O���[�v�R�[�h</summary>
		/// <remarks>1:���Ӑ���,2:�ԗ��n���,3:���z�n���,4:���Џ��</remarks>
		private Int32 _freePrtPprDispGrpCd;

		/// <summary>�K�{���o�����敪</summary>
		/// <remarks>0:�C��,1:�K�{</remarks>
		private Int32 _necessaryExtraCondCd;

		/// <summary>�Í����t���O</summary>
		/// <remarks>0:�Í�����,1:�Í����L</remarks>
		private Int32 _cipherFlg;

		/// <summary>���o�Ώۃt���O</summary>
		/// <remarks>0:��Ώ�,1:�Ώ�</remarks>
		private Int32 _extractionItdedFlg;

		/// <summary>�O���[�v�T�v���X�敪</summary>
		/// <remarks>0:�Ȃ�,1:����</remarks>
		private Int32 _groupSuppressCd;

		/// <summary>���אF�ύX�敪</summary>
		/// <remarks>0:��Ώ�,1:�Ώ�</remarks>
		private Int32 _dtlColorChangeCd;

		/// <summary>���������敪</summary>
		/// <remarks>0:��Ώ�,1:�Ώ�</remarks>
		private Int32 _heightAdjustDivCd;

		/// <summary>�ǉ����ڎg�p�敪</summary>
		/// <remarks>0:�g�p�s��,1:�g�p��</remarks>
		private Int32 _addItemUseDivCd;

		/// <summary>���͌���</summary>
		/// <remarks>�����̓��͐����Ŏg�p</remarks>
		private Int32 _inputCharCnt;

		/// <summary>�o�[�R�[�h�X�^�C��</summary>
		/// <remarks>1:Code_128_A,2:JapanesePostal,3:QRCode</remarks>
		private Int32 _barCodeStyle;


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

		/// public propaty name  :  FreePrtPprItemGrpCd
		/// <summary>���R���[���ڃO���[�v�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���R���[���ڃO���[�v�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 FreePrtPprItemGrpCd
		{
			get { return _freePrtPprItemGrpCd; }
			set { _freePrtPprItemGrpCd = value; }
		}

		/// public propaty name  :  FreePrtPaperItemCd
		/// <summary>���R���[���ڃR�[�h�v���p�e�B</summary>
		/// <value>1�`100:ActiveReport�p,101�`:.NS�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���R���[���ڃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 FreePrtPaperItemCd
		{
			get { return _freePrtPaperItemCd; }
			set { _freePrtPaperItemCd = value; }
		}

		/// public propaty name  :  FreePrtPaperItemNm
		/// <summary>���R���[���ږ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���R���[���ږ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string FreePrtPaperItemNm
		{
			get { return _freePrtPaperItemNm; }
			set { _freePrtPaperItemNm = value; }
		}

		/// public propaty name  :  FileNm
		/// <summary>�t�@�C�����̃v���p�e�B</summary>
		/// <value>DB�̃e�[�u��ID</value>
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

		/// public propaty name  :  DDCharCnt
		/// <summary>DD�����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   DD�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DDCharCnt
		{
			get { return _dDCharCnt; }
			set { _dDCharCnt = value; }
		}

		/// public propaty name  :  DDName
		/// <summary>DD���̃v���p�e�B</summary>
		/// <value>�������œo�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   DD���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DDName
		{
			get { return _dDName; }
			set { _dDName = value; }
		}

		/// public propaty name  :  ReportControlCode
		/// <summary>���|�[�g�R���g���[���敪�v���p�e�B</summary>
		/// <value>1:TextBox,2:Label,3:Picture,4:Shape,5:Line,6:BarCode</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���|�[�g�R���g���[���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ReportControlCode
		{
			get { return _reportControlCode; }
			set { _reportControlCode = value; }
		}

		/// public propaty name  :  HeaderUseDivCd
		/// <summary>�w�b�_�[�g�p�敪�v���p�e�B</summary>
		/// <value>0:�g�p�s��,1:�g�p��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �w�b�_�[�g�p�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 HeaderUseDivCd
		{
			get { return _headerUseDivCd; }
			set { _headerUseDivCd = value; }
		}

		/// public propaty name  :  DetailUseDivCd
		/// <summary>���׎g�p�敪�v���p�e�B</summary>
		/// <value>0:�g�p�s��,1:�g�p��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���׎g�p�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DetailUseDivCd
		{
			get { return _detailUseDivCd; }
			set { _detailUseDivCd = value; }
		}

		/// public propaty name  :  FooterUseDivCd
		/// <summary>�t�b�^�[�g�p�敪�v���p�e�B</summary>
		/// <value>0:�g�p�s��,1:�g�p��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �t�b�^�[�g�p�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 FooterUseDivCd
		{
			get { return _footerUseDivCd; }
			set { _footerUseDivCd = value; }
		}

		/// public propaty name  :  ExtraConditionDivCd
		/// <summary>���o�����敪�v���p�e�B</summary>
		/// <value>0:�g�p�s��,1:���l�^,2:�����^�i���p�j,3:�����^�i�S�p�j,4:���t�^,5:�R���{�^,6:�`�F�b�N�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ExtraConditionDivCd
		{
			get { return _extraConditionDivCd; }
			set { _extraConditionDivCd = value; }
		}

		/// public propaty name  :  ExtraConditionTypeCd
		/// <summary>���o�����^�C�v�v���p�e�B</summary>
		/// <value>0:��v,1:�͈�,2:�����܂�,3:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�����^�C�v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ExtraConditionTypeCd
		{
			get { return _extraConditionTypeCd; }
			set { _extraConditionTypeCd = value; }
		}

		/// public propaty name  :  CommaEditExistCd
		/// <summary>�J���}�ҏW�L���v���p�e�B</summary>
		/// <value>0:�Ȃ�,1:"#,###",2:"#,##0",3:"0.0",4:"0.00"</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J���}�ҏW�L���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CommaEditExistCd
		{
			get { return _commaEditExistCd; }
			set { _commaEditExistCd = value; }
		}

		/// public propaty name  :  PrintPageCtrlDivCd
		/// <summary>�󎚃y�[�W����敪�v���p�e�B</summary>
		/// <value>0:�S�y�[�W,1:1�y�[�W�ڂ̂�,2:�ŏI�y�[�W�̂�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󎚃y�[�W����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PrintPageCtrlDivCd
		{
			get { return _printPageCtrlDivCd; }
			set { _printPageCtrlDivCd = value; }
		}

		/// public propaty name  :  SystemDivCd
		/// <summary>�V�X�e���敪�v���p�e�B</summary>
		/// <value>0:����,1:SF,2:BK,3:SH</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �V�X�e���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SystemDivCd
		{
			get { return _systemDivCd; }
			set { _systemDivCd = value; }
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

		/// public propaty name  :  ExtraCondDetailGrpCd
		/// <summary>���o�������׃O���[�v�R�[�h�v���p�e�B</summary>
		/// <value>���o�����敪���R���{�{�b�N�X�^�̎��Ɏg�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�������׃O���[�v�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ExtraCondDetailGrpCd
		{
			get { return _extraCondDetailGrpCd; }
			set { _extraCondDetailGrpCd = value; }
		}

		/// public propaty name  :  TotalItemDivCd
		/// <summary>�W�v���ڋ敪�v���p�e�B</summary>
		/// <value>0:�g�p�s��,1:�g�p��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �W�v���ڋ敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TotalItemDivCd
		{
			get { return _totalItemDivCd; }
			set { _totalItemDivCd = value; }
		}

		/// public propaty name  :  FormFeedItemDivCd
		/// <summary>���ō��ڋ敪�v���p�e�B</summary>
		/// <value>0:�g�p�s��,1:�g�p��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ō��ڋ敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 FormFeedItemDivCd
		{
			get { return _formFeedItemDivCd; }
			set { _formFeedItemDivCd = value; }
		}

		/// public propaty name  :  FreePrtPprDispGrpCd
		/// <summary>���R���[�\���O���[�v�R�[�h�v���p�e�B</summary>
		/// <value>1:���Ӑ���,2:�ԗ��n���,3:���z�n���,4:���Џ��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���R���[�\���O���[�v�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 FreePrtPprDispGrpCd
		{
			get { return _freePrtPprDispGrpCd; }
			set { _freePrtPprDispGrpCd = value; }
		}

		/// public propaty name  :  NecessaryExtraCondCd
		/// <summary>�K�{���o�����敪�v���p�e�B</summary>
		/// <value>0:�C��,1:�K�{</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �K�{���o�����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 NecessaryExtraCondCd
		{
			get { return _necessaryExtraCondCd; }
			set { _necessaryExtraCondCd = value; }
		}

		/// public propaty name  :  CipherFlg
		/// <summary>�Í����t���O�v���p�e�B</summary>
		/// <value>0:�Í�����,1:�Í����L</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Í����t���O�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CipherFlg
		{
			get { return _cipherFlg; }
			set { _cipherFlg = value; }
		}

		/// public propaty name  :  ExtractionItdedFlg
		/// <summary>���o�Ώۃt���O�v���p�e�B</summary>
		/// <value>0:��Ώ�,1:�Ώ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�Ώۃt���O�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ExtractionItdedFlg
		{
			get { return _extractionItdedFlg; }
			set { _extractionItdedFlg = value; }
		}

		/// public propaty name  :  GroupSuppressCd
		/// <summary>�O���[�v�T�v���X�敪�v���p�e�B</summary>
		/// <value>0:�Ȃ�,1:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �O���[�v�T�v���X�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GroupSuppressCd
		{
			get { return _groupSuppressCd; }
			set { _groupSuppressCd = value; }
		}

		/// public propaty name  :  DtlColorChangeCd
		/// <summary>���אF�ύX�敪�v���p�e�B</summary>
		/// <value>0:��Ώ�,1:�Ώ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���אF�ύX�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DtlColorChangeCd
		{
			get { return _dtlColorChangeCd; }
			set { _dtlColorChangeCd = value; }
		}

		/// public propaty name  :  HeightAdjustDivCd
		/// <summary>���������敪�v���p�e�B</summary>
		/// <value>0:��Ώ�,1:�Ώ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���������敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 HeightAdjustDivCd
		{
			get { return _heightAdjustDivCd; }
			set { _heightAdjustDivCd = value; }
		}

		/// public propaty name  :  AddItemUseDivCd
		/// <summary>�ǉ����ڎg�p�敪�v���p�e�B</summary>
		/// <value>0:�g�p�s��,1:�g�p��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ǉ����ڎg�p�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AddItemUseDivCd
		{
			get { return _addItemUseDivCd; }
			set { _addItemUseDivCd = value; }
		}

		/// public propaty name  :  InputCharCnt
		/// <summary>���͌����v���p�e�B</summary>
		/// <value>�����̓��͐����Ŏg�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���͌����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InputCharCnt
		{
			get { return _inputCharCnt; }
			set { _inputCharCnt = value; }
		}

		/// public propaty name  :  BarCodeStyle
		/// <summary>�o�[�R�[�h�X�^�C���v���p�e�B</summary>
		/// <value>1:Code_128_A,2:JapanesePostal,3:QRCode</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�[�R�[�h�X�^�C���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 BarCodeStyle
		{
			get { return _barCodeStyle; }
			set { _barCodeStyle = value; }
		}


		/// <summary>
		/// �󎚍��ڐݒ胏�[�N�R���X�g���N�^
		/// </summary>
		/// <returns>PrtItemSetWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   PrtItemSetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public PrtItemSetWork()
		{
		}

	}

	/// <summary>
	///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
	/// </summary>
	/// <returns>PrtItemSetWork�N���X�̃C���X�^���X(object)</returns>
	/// <remarks>
	/// <br>Note�@�@�@�@�@�@ :   PrtItemSetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
	/// <br>Programer        :   ��������</br>
	/// </remarks>
	public class PrtItemSetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate �����o

		/// <summary>
		///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   PrtItemSetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  PrtItemSetWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
			if (writer == null)
				throw new ArgumentNullException();

			if (graph != null && !(graph is PrtItemSetWork || graph is ArrayList || graph is PrtItemSetWork[]))
				throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(PrtItemSetWork).FullName));

			if (graph != null && graph is PrtItemSetWork)
			{
				Type t = graph.GetType();
				if (!CustomFormatterServices.NeedCustomSerialization(t))
					throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PrtItemSetWork");

			//�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
			int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
			if (graph is ArrayList)
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if (graph is PrtItemSetWork[])
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((PrtItemSetWork[])graph).Length;
			}
			else if (graph is PrtItemSetWork)
			{
				serInfo.RetTypeInfo = 1;
				occurrence = 1;
			}

			serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

			//�쐬����
			serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
			//�X�V����
			serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
			//�_���폜�敪
			serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
			//���R���[���ڃO���[�v�R�[�h
			serInfo.MemberInfo.Add(typeof(Int32)); //FreePrtPprItemGrpCd
			//���R���[���ڃR�[�h
			serInfo.MemberInfo.Add(typeof(Int32)); //FreePrtPaperItemCd
			//���R���[���ږ���
			serInfo.MemberInfo.Add(typeof(string)); //FreePrtPaperItemNm
			//�t�@�C������
			serInfo.MemberInfo.Add(typeof(string)); //FileNm
			//DD����
			serInfo.MemberInfo.Add(typeof(Int32)); //DDCharCnt
			//DD����
			serInfo.MemberInfo.Add(typeof(string)); //DDName
			//���|�[�g�R���g���[���敪
			serInfo.MemberInfo.Add(typeof(Int32)); //ReportControlCode
			//�w�b�_�[�g�p�敪
			serInfo.MemberInfo.Add(typeof(Int32)); //HeaderUseDivCd
			//���׎g�p�敪
			serInfo.MemberInfo.Add(typeof(Int32)); //DetailUseDivCd
			//�t�b�^�[�g�p�敪
			serInfo.MemberInfo.Add(typeof(Int32)); //FooterUseDivCd
			//���o�����敪
			serInfo.MemberInfo.Add(typeof(Int32)); //ExtraConditionDivCd
			//���o�����^�C�v
			serInfo.MemberInfo.Add(typeof(Int32)); //ExtraConditionTypeCd
			//�J���}�ҏW�L��
			serInfo.MemberInfo.Add(typeof(Int32)); //CommaEditExistCd
			//�󎚃y�[�W����敪
			serInfo.MemberInfo.Add(typeof(Int32)); //PrintPageCtrlDivCd
			//�V�X�e���敪
			serInfo.MemberInfo.Add(typeof(Int32)); //SystemDivCd
			//�I�v�V�����R�[�h
			serInfo.MemberInfo.Add(typeof(string)); //OptionCode
			//���o�������׃O���[�v�R�[�h
			serInfo.MemberInfo.Add(typeof(Int32)); //ExtraCondDetailGrpCd
			//�W�v���ڋ敪
			serInfo.MemberInfo.Add(typeof(Int32)); //TotalItemDivCd
			//���ō��ڋ敪
			serInfo.MemberInfo.Add(typeof(Int32)); //FormFeedItemDivCd
			//���R���[�\���O���[�v�R�[�h
			serInfo.MemberInfo.Add(typeof(Int32)); //FreePrtPprDispGrpCd
			//�K�{���o�����敪
			serInfo.MemberInfo.Add(typeof(Int32)); //NecessaryExtraCondCd
			//�Í����t���O
			serInfo.MemberInfo.Add(typeof(Int32)); //CipherFlg
			//���o�Ώۃt���O
			serInfo.MemberInfo.Add(typeof(Int32)); //ExtractionItdedFlg
			//�O���[�v�T�v���X�敪
			serInfo.MemberInfo.Add(typeof(Int32)); //GroupSuppressCd
			//���אF�ύX�敪
			serInfo.MemberInfo.Add(typeof(Int32)); //DtlColorChangeCd
			//���������敪
			serInfo.MemberInfo.Add(typeof(Int32)); //HeightAdjustDivCd
			//�ǉ����ڎg�p�敪
			serInfo.MemberInfo.Add(typeof(Int32)); //AddItemUseDivCd
			//���͌���
			serInfo.MemberInfo.Add(typeof(Int32)); //InputCharCnt
			//�o�[�R�[�h�X�^�C��
			serInfo.MemberInfo.Add(typeof(Int32)); //BarCodeStyle


			serInfo.Serialize(writer, serInfo);
			if (graph is PrtItemSetWork)
			{
				PrtItemSetWork temp = (PrtItemSetWork)graph;

				SetPrtItemSetWork(writer, temp);
			}
			else
			{
				ArrayList lst = null;
				if (graph is PrtItemSetWork[])
				{
					lst = new ArrayList();
					lst.AddRange((PrtItemSetWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;
				}

				foreach (PrtItemSetWork temp in lst)
				{
					SetPrtItemSetWork(writer, temp);
				}

			}


		}


		/// <summary>
		/// PrtItemSetWork�����o��(public�v���p�e�B��)
		/// </summary>
		private const int currentMemberCount = 32;

		/// <summary>
		///  PrtItemSetWork�C���X�^���X��������
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   PrtItemSetWork�̃C���X�^���X����������</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		private void SetPrtItemSetWork(System.IO.BinaryWriter writer, PrtItemSetWork temp)
		{
			//�쐬����
			writer.Write((Int64)temp.CreateDateTime.Ticks);
			//�X�V����
			writer.Write((Int64)temp.UpdateDateTime.Ticks);
			//�_���폜�敪
			writer.Write(temp.LogicalDeleteCode);
			//���R���[���ڃO���[�v�R�[�h
			writer.Write(temp.FreePrtPprItemGrpCd);
			//���R���[���ڃR�[�h
			writer.Write(temp.FreePrtPaperItemCd);
			//���R���[���ږ���
			writer.Write(temp.FreePrtPaperItemNm);
			//�t�@�C������
			writer.Write(temp.FileNm);
			//DD����
			writer.Write(temp.DDCharCnt);
			//DD����
			writer.Write(temp.DDName);
			//���|�[�g�R���g���[���敪
			writer.Write(temp.ReportControlCode);
			//�w�b�_�[�g�p�敪
			writer.Write(temp.HeaderUseDivCd);
			//���׎g�p�敪
			writer.Write(temp.DetailUseDivCd);
			//�t�b�^�[�g�p�敪
			writer.Write(temp.FooterUseDivCd);
			//���o�����敪
			writer.Write(temp.ExtraConditionDivCd);
			//���o�����^�C�v
			writer.Write(temp.ExtraConditionTypeCd);
			//�J���}�ҏW�L��
			writer.Write(temp.CommaEditExistCd);
			//�󎚃y�[�W����敪
			writer.Write(temp.PrintPageCtrlDivCd);
			//�V�X�e���敪
			writer.Write(temp.SystemDivCd);
			//�I�v�V�����R�[�h
			writer.Write(temp.OptionCode);
			//���o�������׃O���[�v�R�[�h
			writer.Write(temp.ExtraCondDetailGrpCd);
			//�W�v���ڋ敪
			writer.Write(temp.TotalItemDivCd);
			//���ō��ڋ敪
			writer.Write(temp.FormFeedItemDivCd);
			//���R���[�\���O���[�v�R�[�h
			writer.Write(temp.FreePrtPprDispGrpCd);
			//�K�{���o�����敪
			writer.Write(temp.NecessaryExtraCondCd);
			//�Í����t���O
			writer.Write(temp.CipherFlg);
			//���o�Ώۃt���O
			writer.Write(temp.ExtractionItdedFlg);
			//�O���[�v�T�v���X�敪
			writer.Write(temp.GroupSuppressCd);
			//���אF�ύX�敪
			writer.Write(temp.DtlColorChangeCd);
			//���������敪
			writer.Write(temp.HeightAdjustDivCd);
			//�ǉ����ڎg�p�敪
			writer.Write(temp.AddItemUseDivCd);
			//���͌���
			writer.Write(temp.InputCharCnt);
			//�o�[�R�[�h�X�^�C��
			writer.Write(temp.BarCodeStyle);

		}

		/// <summary>
		///  PrtItemSetWork�C���X�^���X�擾
		/// </summary>
		/// <returns>PrtItemSetWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   PrtItemSetWork�̃C���X�^���X���擾���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		private PrtItemSetWork GetPrtItemSetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
		{
			// V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
			// serInfo.MemberInfo.Count < currentMemberCount
			// �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

			PrtItemSetWork temp = new PrtItemSetWork();

			//�쐬����
			temp.CreateDateTime = new DateTime(reader.ReadInt64());
			//�X�V����
			temp.UpdateDateTime = new DateTime(reader.ReadInt64());
			//�_���폜�敪
			temp.LogicalDeleteCode = reader.ReadInt32();
			//���R���[���ڃO���[�v�R�[�h
			temp.FreePrtPprItemGrpCd = reader.ReadInt32();
			//���R���[���ڃR�[�h
			temp.FreePrtPaperItemCd = reader.ReadInt32();
			//���R���[���ږ���
			temp.FreePrtPaperItemNm = reader.ReadString();
			//�t�@�C������
			temp.FileNm = reader.ReadString();
			//DD����
			temp.DDCharCnt = reader.ReadInt32();
			//DD����
			temp.DDName = reader.ReadString();
			//���|�[�g�R���g���[���敪
			temp.ReportControlCode = reader.ReadInt32();
			//�w�b�_�[�g�p�敪
			temp.HeaderUseDivCd = reader.ReadInt32();
			//���׎g�p�敪
			temp.DetailUseDivCd = reader.ReadInt32();
			//�t�b�^�[�g�p�敪
			temp.FooterUseDivCd = reader.ReadInt32();
			//���o�����敪
			temp.ExtraConditionDivCd = reader.ReadInt32();
			//���o�����^�C�v
			temp.ExtraConditionTypeCd = reader.ReadInt32();
			//�J���}�ҏW�L��
			temp.CommaEditExistCd = reader.ReadInt32();
			//�󎚃y�[�W����敪
			temp.PrintPageCtrlDivCd = reader.ReadInt32();
			//�V�X�e���敪
			temp.SystemDivCd = reader.ReadInt32();
			//�I�v�V�����R�[�h
			temp.OptionCode = reader.ReadString();
			//���o�������׃O���[�v�R�[�h
			temp.ExtraCondDetailGrpCd = reader.ReadInt32();
			//�W�v���ڋ敪
			temp.TotalItemDivCd = reader.ReadInt32();
			//���ō��ڋ敪
			temp.FormFeedItemDivCd = reader.ReadInt32();
			//���R���[�\���O���[�v�R�[�h
			temp.FreePrtPprDispGrpCd = reader.ReadInt32();
			//�K�{���o�����敪
			temp.NecessaryExtraCondCd = reader.ReadInt32();
			//�Í����t���O
			temp.CipherFlg = reader.ReadInt32();
			//���o�Ώۃt���O
			temp.ExtractionItdedFlg = reader.ReadInt32();
			//�O���[�v�T�v���X�敪
			temp.GroupSuppressCd = reader.ReadInt32();
			//���אF�ύX�敪
			temp.DtlColorChangeCd = reader.ReadInt32();
			//���������敪
			temp.HeightAdjustDivCd = reader.ReadInt32();
			//�ǉ����ڎg�p�敪
			temp.AddItemUseDivCd = reader.ReadInt32();
			//���͌���
			temp.InputCharCnt = reader.ReadInt32();
			//�o�[�R�[�h�X�^�C��
			temp.BarCodeStyle = reader.ReadInt32();


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
		/// <returns>PrtItemSetWork�N���X�̃C���X�^���X(object)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   PrtItemSetWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
			ArrayList lst = new ArrayList();
			for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
			{
				PrtItemSetWork temp = GetPrtItemSetWork(reader, serInfo);
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
					retValue = (PrtItemSetWork[])lst.ToArray(typeof(PrtItemSetWork));
					break;
			}
			return retValue;
		}

		#endregion
	}

}

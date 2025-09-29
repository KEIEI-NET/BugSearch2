using System;
using System.IO;
using System.Drawing;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:	FrePrtExport
	/// <summary>
	///                      ���R���[Export�N���X
	/// </summary>
	/// <remarks>
	/// <br>note			:	���R���[Export�N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer		:	��������</br>
	/// <br>Date			:	2007/11/06</br>
	/// <br>Genarated Date	:	2007/11/06  (CSharp File Generated Date)</br>
	/// <br></br>
	/// <br>Update Note		:	</br>
	/// </remarks>
	public class FrePrtExport
	{
		#region Const
		/// <summary>�G�N�X�|�[�g�t�@�C����</summary>
		public const string ctExportFileName = "FREPRTPSETEXPORT.xml";
		#endregion

		#region PrivateMember
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>�o�̓t�@�C����</summary>
		/// <remarks>�t�H�[���t�@�C��ID or �t�H�[�}�b�g�t�@�C��ID</remarks>
		private string _outputFormFileName = "";

		/// <summary>���[�U�[���[ID�}�ԍ�</summary>
		private Int32 _userPrtPprIdDerivNo;

		/// <summary>�o�͖���</summary>
		/// <remarks>�K�C�h���ɕ\�����閼��</remarks>
		private string _displayName = "";

		/// <summary>���[���[�U�[�}�ԃR�����g</summary>
		private string _prtPprUserDerivNoCmt = "";

		/// <summary>�G�N�X�|�[�g�f�[�^�t�@�C���p�X</summary>
		private string _exportDataFilePath = "";

		/// <summary>�f�[�^���̓V�X�e��</summary>
		/// <remarks>0:����,1:����,2:���,3:�Ԕ�</remarks>
		private Int32 _dataInputSystem;

		/// <summary>���[�g�p�敪</summary>
		/// <remarks>1:���[,2:�`�[,3:DM�ꗗ�\,4:DM�͂���</remarks>
		private Int32 _printPaperUseDivcd;

		/// <summary>���l</summary>
		private string _note = "";

		/// <summary>�`�[��ʓo�^�敪1</summary>
		/// <remarks>�`�[�o�^���Ɏg�p�i�`�[���:10�j</remarks>
		private Int32 _slipKindEntryDiv1;

		/// <summary>�`�[��ʓo�^�敪2</summary>
		/// <remarks>�`�[�o�^���Ɏg�p�i�`�[���:20�j</remarks>
		private Int32 _slipKindEntryDiv2;

		/// <summary>�`�[��ʓo�^�敪3</summary>
		/// <remarks>�`�[�o�^���Ɏg�p�i�`�[���:21�j</remarks>
		private Int32 _slipKindEntryDiv3;

		/// <summary>�`�[��ʓo�^�敪4</summary>
		/// <remarks>�`�[�o�^���Ɏg�p�i�`�[���:30�j</remarks>
		private Int32 _slipKindEntryDiv4;

		/// <summary>���o�Ώۃt���O</summary>
		/// <remarks>0:��Ώ�,1:�Ώ�</remarks>
		private Int32 _extractionItdedFlg;

		/// <summary>�`�[������</summary>
		/// <remarks>10:���Ϗ�,20:�w�����i�������j,21:���菑,30:�[�i��,100:���[�N�V�[�g,110:�{�f�B���@�}</remarks>
		private Int32 _slipPrtKind;

		/// <summary>���[�w�i�摜�f�[�^</summary>
		private Byte[] _printPprBgImageData;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 ADD
        /// <summary>���R���[������ڃO���[�v�R�[�h</summary>
        private Int32 _freePrtPprItemGrpCd;
        /// <summary>���R���[����p�r�R�[�h</summary>
        private Int32 _freePrtPprSpPrpseCd;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 ADD
		#endregion

		#region Property
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

		/// public propaty name  :  UserPrtPprIdDerivNo
		/// <summary>���[�U�[���[ID�}�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�U�[���[ID�}�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 UserPrtPprIdDerivNo
		{
			get { return _userPrtPprIdDerivNo; }
			set { _userPrtPprIdDerivNo = value; }
		}

		/// public propaty name  :  DisplayName
		/// <summary>�o�͖��̃v���p�e�B</summary>
		/// <value>�K�C�h���ɕ\�����閼��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�͖��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DisplayName
		{
			get { return _displayName; }
			set { _displayName = value; }
		}

		/// public propaty name  :  PrtPprUserDerivNoCmt
		/// <summary>���[���[�U�[�}�ԃR�����g�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[���[�U�[�}�ԃR�����g�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PrtPprUserDerivNoCmt
		{
			get { return _prtPprUserDerivNoCmt; }
			set { _prtPprUserDerivNoCmt = value; }
		}

		/// public propaty name  :  ExportDataFilePath
		/// <summary>�G�N�X�|�[�g�f�[�^�t�@�C���p�X�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �G�N�X�|�[�g�f�[�^�t�@�C���p�X�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ExportDataFilePath
		{
			get { return _exportDataFilePath; }
			set { _exportDataFilePath = value; }
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

		/// public propaty name  :  PrintPaperUseDivcd
		/// <summary>���[�g�p�敪�v���p�e�B</summary>
		/// <value>1:���[,2:�`�[,3:DM�ꗗ�\,4:DM�͂���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�g�p�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PrintPaperUseDivcd
		{
			get { return _printPaperUseDivcd; }
			set { _printPaperUseDivcd = value; }
		}

		/// public propaty name  :  Note
		/// <summary>���l�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���l�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Note
		{
			get { return _note; }
			set { _note = value; }
		}

		/// public propaty name  :  SlipKindEntryDiv1
		/// <summary>�`�[��ʓo�^�敪1�v���p�e�B</summary>
		/// <value>�`�[�o�^���Ɏg�p�i�`�[���:10�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[��ʓo�^�敪1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SlipKindEntryDiv1
		{
			get { return _slipKindEntryDiv1; }
			set { _slipKindEntryDiv1 = value; }
		}

		/// public propaty name  :  SlipKindEntryDiv2
		/// <summary>�`�[��ʓo�^�敪2�v���p�e�B</summary>
		/// <value>�`�[�o�^���Ɏg�p�i�`�[���:20�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[��ʓo�^�敪2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SlipKindEntryDiv2
		{
			get { return _slipKindEntryDiv2; }
			set { _slipKindEntryDiv2 = value; }
		}

		/// public propaty name  :  SlipKindEntryDiv3
		/// <summary>�`�[��ʓo�^�敪3�v���p�e�B</summary>
		/// <value>�`�[�o�^���Ɏg�p�i�`�[���:21�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[��ʓo�^�敪3�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SlipKindEntryDiv3
		{
			get { return _slipKindEntryDiv3; }
			set { _slipKindEntryDiv3 = value; }
		}

		/// public propaty name  :  SlipKindEntryDiv4
		/// <summary>�`�[��ʓo�^�敪4�v���p�e�B</summary>
		/// <value>�`�[�o�^���Ɏg�p�i�`�[���:30�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[��ʓo�^�敪4�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SlipKindEntryDiv4
		{
			get { return _slipKindEntryDiv4; }
			set { _slipKindEntryDiv4 = value; }
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

		/// public propaty name  :  SlipPrtKind
		/// <summary>�`�[�����ʃv���p�e�B</summary>
		/// <value>10:���Ϗ�,20:�w�����i�������j,21:���菑,30:�[�i��,100:���[�N�V�[�g,110:�{�f�B���@�}</value>
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

		/// public propaty name  :  PrintPprBgImageData
		/// <summary>���[�w�i�摜�f�[�^�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�w�i�摜�f�[�^�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Byte[] PrintPprBgImageData
		{
			get { return _printPprBgImageData; }
			set { _printPprBgImageData = value; }
		}

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 ADD
        /// public propaty name  :  FreePrtPprItemGrpCd
        /// <summary>���R���[������ڃO���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���R���[������ڃO���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   </br>
        /// </remarks>
        public Int32 FreePrtPprItemGrpCd
        {
            get { return _freePrtPprItemGrpCd; }
            set { _freePrtPprItemGrpCd = value; }
        }
        /// public propaty name  :  FreePrtPprSpPrpseCd
        /// <summary>���R���[����p�r�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���R���[����p�r�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   </br>
        /// </remarks>
        public Int32 FreePrtPprSpPrpseCd
        {
            get { return _freePrtPprSpPrpseCd; }
            set { _freePrtPprSpPrpseCd = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 ADD
		#endregion

		#region PublicMethod
		/// <summary>
		/// ���[�w�i�摜�擾����
		/// </summary>
		/// <returns>���[�w�i�摜</returns>
		public Image GetPrintPprBgImageDataImage()
		{
			MemoryStream stream = new MemoryStream(_printPprBgImageData);
			stream.Position = 0;
			return Image.FromStream(stream);
		}

		/// <summary>
		/// ���[�w�i�摜�ݒ菈��
		/// </summary>
		/// <param name="image">���[�w�i�摜</param>
		public void SetPrintPprBgImageDataImage(Image image)
		{
			_printPprBgImageData = null;
			MemoryStream stream = new MemoryStream();
			image.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
			_printPprBgImageData = stream.ToArray();
		}
		#endregion

		#region Constructor
		/// <summary>
		/// ���R���[Export�N���X�R���X�g���N�^
		/// </summary>
		/// <returns>FrePrtExport�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note			:	FrePrtExport�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer		:	��������</br>
		/// </remarks>
		public FrePrtExport()
		{
		}
		#endregion
	}
}

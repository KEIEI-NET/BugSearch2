using System;
using System.Collections.Specialized;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���ʉ�ʏ����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���ʉ�ʂɕK�v�ȏ������`�����N���X�ł��B</br>
	/// <br>Programer  : 18012  Y.Sasaki</br>
	/// <br>Date       : 2005.11.24</br>
	/// <br>Update Note:</br>
	/// </remarks>
	[Serializable]
	public class SFCMN00293UC
	{
		/// <summary>����͈�</summary>
		/// <remarks>0:�S�Ẵy�[�W,1:�y�[�W�w��</remarks>
		private int _printRange;

		/// <summary>����J�n�y�[�W</summary>
		/// <remarks>������J�n����y�[�W���w��</remarks>
		private int _printTopPage;
		
		/// <summary>����I���y�[�W</summary>
		/// <remarks>������I������y�[�W���w��</remarks>
		private int _printEndPage;
		
		/// <summary>��]��</summary>
		/// <remarks>��]�����w��</remarks>
		private int _marginsTop;

		/// <summary>���]��</summary>
		/// <remarks>���]�����w��</remarks>
		private int _marginsBottom;

		/// <summary>���]��</summary>
		/// <remarks>���]�����w��</remarks>
		private int _marginsLeft;
		
		/// <summary>�E�]��</summary>
		/// <remarks>�E�]�����w��</remarks>
		private int _marginsRight;
		
		/// <summary>�g�嗦</summary>
		/// <remarks>0�`800%</remarks>
		private int _expansionRate;

		/// <summary>�v�����^�[����</summary>
		/// <remarks>�v�����^�̖���</remarks>
		private string _printerName = "";

		/// <summary>������[�h</summary>
		/// <remarks>1:�v�����^,2:�o�c�e,3:����</remarks>
		private int _printMode;

		/// <summary>�������</summary>
		/// <remarks>�������f�[�^�̌���</remarks>
		private int _printMax;

		/// <summary>���[�t�H�[��ID</summary>
		/// <remarks>������钠�[�t�H�[��ID</remarks>
		private string _outputFormID;
		
		/// <summary>������ޖ�</summary>
		/// <remarks>������鏑�ޖ���</remarks>
		private string _printName;
		
		/// <summary>�o�c�e�o�̓p�X</summary>
		/// <remarks>�o�c�e�̏o�͐�(�t���p�X)</remarks>
		private string _pdfFullPath;
		
		/// <summary>�󎚈ʒu����</summary>
		/// <remarks>[0:���Ȃ�,1:����]</remarks>
		private int _printPositionAdjust;
		
		/// <summary>������R���g���[����\�����X�g</summary>
		/// <remarks>������ɔ�\���ɂ���R���g���[���̖��O���X�g</remarks>
		private StringCollection _hideControlList = null;
		
		/// <summary>�X�e�[�^�X</summary>
		/// <remarks>����X�e�[�^�X</remarks>
		private int _status;
		
		/// public propaty name  :  PrintRange
		/// <summary>����͈̓v���p�e�B</summary>
		/// <value>0:�S�Ẵy�[�W 1:�w��y�[�W</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����͈̓v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public int PrintRange
		{
			get{return _printRange;}
			set{_printRange = value;}
		}

		/// public propaty name  :  PrintTopPage
		/// <summary>����J�n�y�[�W�v���p�e�B</summary>
		/// <value>����J�n�y�[�W</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����J�n�y�[�W�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public int PrintTopPage
		{
			get{return _printTopPage;}
			set{_printTopPage = value;}
		}

		/// public propaty name  :  PrintEndPage
		/// <summary>����I���y�[�W�v���p�e�B</summary>
		/// <value>����I���y�[�W</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����I���y�[�W�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public int PrintEndPage
		{
			get{return _printEndPage;}
			set{_printEndPage = value;}
		}

		/// public propaty name  :  MarginsTop
		/// <summary>��]���v���p�e�B</summary>
		/// <value>��]��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��]���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public int MarginsTop
		{
			get{return _marginsTop;}
			set{_marginsTop = value;}
		}

		/// public propaty name  :  MarginsBottom
		/// <summary>���]���v���p�e�B</summary>
		/// <value>���]��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���]���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public int MarginsBottom
		{
			get{return _marginsBottom;}
			set{_marginsBottom = value;}
		}

		/// public propaty name  :  MarginsLeft
		/// <summary>���]���v���p�e�B</summary>
		/// <value>���]��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���]���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public int MarginsLeft
		{
			get{return _marginsLeft;}
			set{_marginsLeft = value;}
		}

		/// public propaty name  :  MarginsRight
		/// <summary>�E�]���v���p�e�B</summary>
		/// <value>�E�]��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �E�]���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public int MarginsRight
		{
			get{return _marginsRight;}
			set{_marginsRight = value;}
		}
		
		
		/// public propaty name  :  ExpansionRate
		/// <summary>�g�嗦�v���p�e�B</summary>
		/// <value>�g�嗦</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �g�嗦�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public int ExpansionRate
		{
			get{return _expansionRate;}
			set{_expansionRate = value;}
		}
		
		/// public propaty name  :  PrinterName
		/// <summary>�v�����^���̃v���p�e�B</summary>
		/// <value></value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v�����^���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PrinterName
		{
			get{return _printerName;}
			set{_printerName = value;}
		}
		
		/// public propaty name  :  PrinterMode
		/// <summary>������[�h�v���p�e�B</summary>
		/// <value></value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public int PrintMode
		{
			get{return _printMode;}
			set{_printMode = value;}
		}

		/// public propaty name  :  PrintMax
		/// <summary>��������v���p�e�B</summary>
		/// <value></value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public int PrintMax
		{
			get{return _printMax;}
			set{_printMax = value;}
		}

		/// public propaty name  :  PrintName
		/// <summary>���[�t�H�[��ID�v���p�e�B</summary>
		/// <value></value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�t�H�[��ID�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string OutputFormID
		{
			get{return _outputFormID;}
			set{_outputFormID = value;}
		}
		
		/// public propaty name  :  PrintName
		/// <summary>������ޖ��̃v���p�e�B</summary>
		/// <value></value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������ޖ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PrintName
		{
			get{return _printName;}
			set{_printName = value;}
		}

		/// public propaty name  :  PdfFullPath
		/// <summary>�o�c�e�o�͐�v���p�e�B</summary>
		/// <value></value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�c�e�o�͐�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PdfFullPath
		{
			get{return _pdfFullPath;}
			set{_pdfFullPath = value;}
		}

		/// public propaty name  :  PrintPositionAdjust
		/// <summary>�󎚈ʒu�����v���p�e�B</summary>
		/// <value>[0:���Ȃ�,1:����]</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󎚈ʒu�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public int PrintPositionAdjust
		{
			get{return _printPositionAdjust;}
			set{_printPositionAdjust = value;}
		}

		/// public propaty name  :  HideControlList
		/// <summary>������R���g���[����\�����X�g�v���p�e�B</summary>
		/// <value>������ɔ�\���ɂ���R���g���[���̖��O���X�g</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������R���g���[����\�����X�g�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StringCollection HideControlList
		{
			get{return _hideControlList;}
			set{_hideControlList = value;}
		}
		
		/// public propaty name  :  Status
		/// <summary>����X�e�[�^�X�v���p�e�B</summary>
		/// <value>����X�e�[�^�X</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����X�e�[�^�X</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public int Status
		{
			get{return _status;}
			set{_status = value;}
		}

		/// <summary>
		/// ���ʉ�ʏ����N���X�R���X�g���N�^
		/// </summary>
		/// <returns>SFCMN00293UC�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :  SFCMN00293UC�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer       :   ��������</br>
		/// </remarks>
		public SFCMN00293UC()
		{
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �ύX�ē��Ď��A�v���P�[�V�����\�����N���X
	/// </summary>
	public class ChangeInfoCheckAppConfig
	{
		/// <summary>
		/// �f�t�H���g�R���X�g���N�^
		/// </summary>
		public ChangeInfoCheckAppConfig() { }

		/// <summary>Web�T�[�r�XURL</summary>
		private string _webServiceURL;
		/// <summary>�`�F�b�N�Ԋu(min)</summary>
		private int _checkTimeSpan;
		/// <summary>�ύX�ē�TOP�y�[�WURL</summary>
		private string _webTopPageURL;

		/// <summary>Web�T�[�r�XURL</summary>
		public string WebServiceURL
		{
			get { return _webServiceURL; }
			set { _webServiceURL = value; }
		}

		/// <summary>�`�F�b�N�Ԋu(min)</summary>
		public int CheckTimeSpan
		{
			get { return _checkTimeSpan; }
			set { _checkTimeSpan = value; }
		}

		/// <summary>�ύX�ē�TOP�y�[�WURL</summary>
		public string WebTopPageURL
		{
			get { return _webTopPageURL; }
			set { _webTopPageURL = value; }
		}
	}


	/// <summary>
	/// �ύX�ē��ʒm �ŐV�ύX�f�[�^���V���A���C�Y�p�N���X
	/// </summary>
	public class LatestChangeInfoData
	{
		/// <summary>
		/// �f�t�H���g�R���X�g���N�^
		/// </summary>
		public LatestChangeInfoData() { }

		/// <summary>�p�b�P�[�W�敪</summary>
		private string _productCode;

		/// <summary>��������e�i���X �T�[�o�[�����e�i���X�A��</summary>
		private int _nmlServerMainteConsNo;

		/// <summary>�ً}�����e�i���X �T�[�o�[�����e�i���X�A��</summary>
		private int _emgServerMainteConsNo;

		/// <summary>�f�[�^�����e�i���X �T�[�o�[�����e�i���X�A��</summary>
		private int _datServerMainteConsNo;
        
        /// <summary>�z�M�o�[�W����</summary>
		private string _multicastVersion;

		/// <summary>�󎚈ʒu�����[�X �A��</summary>
		private int _printPositionConsNo;

		/// <summary>�p�b�P�[�W�敪</summary>
		public string ProductCode
		{
			get { return _productCode; }
			set { _productCode = value; }
		}

		/// <summary>��������e�i���X �T�[�o�[�����e�i���X�A��</summary>
		public int NmlServerMainteConsNo
		{
			get { return _nmlServerMainteConsNo; }
			set { _nmlServerMainteConsNo = value; }
		}

		/// <summary>�ً}�����e�i���X �T�[�o�[�����e�i���X�A��</summary>
		public int EmgServerMainteConsNo
		{
			get { return _emgServerMainteConsNo; }
			set { _emgServerMainteConsNo = value; }
		}

		/// <summary>�f�[�^�����e�i���X �T�[�o�[�����e�i���X�A��</summary>
		public int DatServerMainteConsNo
		{
			get { return _datServerMainteConsNo; }
			set { _datServerMainteConsNo = value; }
		}

		/// <summary>�z�M�o�[�W����</summary>
		public string MulticastVersion
		{
			get { return _multicastVersion; }
			set { _multicastVersion = value; }
		}

		/// <summary>�󎚈ʒu�����[�X �A��</summary>
		public int PrintPositionConsNo
		{
			get { return _printPositionConsNo; }
			set { _printPositionConsNo = value; }
		}
    
    
    }
}

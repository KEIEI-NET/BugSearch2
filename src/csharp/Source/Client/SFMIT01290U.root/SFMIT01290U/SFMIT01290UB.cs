using System;

using DataDynamics.ActiveReports.Document;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ����v���r���[�p�����[�^�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: �v���r���[�\���p�̃p�����[�^�N���X�ł��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2006.01.12</br>
	/// </remarks>
	public class SFMIT01290UB
	{
		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public SFMIT01290UB()
		{
		}
		#endregion

		#region PrivateMember
		// ����h�L�������g�i����p�j
		private Document _printDocument;
		// ����h�L�������g�i�v���r���[�p�j
		private Document _previewDocument;
		// PDF�p�X
		private string _pdfPath;
		// �g�嗦
		private int _expansionRate;
		#endregion

		#region Property
		/// <summary>
		/// ����h�L�������g�i����p�j
		/// </summary>
		public Document PrintDocument
		{
			get{ return this._printDocument; }
			set{ this._printDocument = value; }
		}

		/// <summary>
		/// ����h�L�������g�i�v���r���[�p�j
		/// </summary>
		public Document PreviewDocument
		{
			get{ return this._previewDocument; }
			set{ this._previewDocument = value; }
		}

		/// <summary>
		/// PDF�p�X
		/// </summary>
		public string PdfPath
		{
			get{ return this._pdfPath; }
			set{ this._pdfPath = value; }
		}

		/// <summary>
		/// �g�嗦
		/// </summary>
		public int ExpansionRate
		{
			get{ return this._expansionRate; }
			set{ this._expansionRate = value; }
		}
		#endregion
	}
}

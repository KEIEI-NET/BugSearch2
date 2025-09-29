using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   PrdTypYearCondWork
	/// <summary>
	///                      ���Y�N�����o�����N���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���Y�N�����o�����N���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2006/10/16</br>
	/// <br>Genarated Date   :   2007/03/09  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class PrdTypYearCondWork
	{
		/// <summary>���[�J�[�R�[�h</summary>
		/// <remarks>1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
		private Int32 _makerCode;

		/// <summary>�ԑ�^��</summary>
		private string _frameModel = "";

        /// <summary>�J�n���Y�N��</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _stProduceTypeOfYear;

        /// <summary>�I�����Y�N��</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _edProduceTypeOfYear;

		/// public propaty name  :  MakerCode
		/// <summary>���[�J�[�R�[�h�v���p�e�B</summary>
		/// <value>1�`899:�񋟕�, 900�`���[�U�[�o�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 MakerCode
		{
			get { return _makerCode; }
			set { _makerCode = value; }
		}

		/// public propaty name  :  FrameModel
		/// <summary>�ԑ�^���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԑ�^���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string FrameModel
		{
			get { return _frameModel; }
			set { _frameModel = value; }
		}

        /// public property name  :  StProduceTypeOfYear
        /// <summary>�J�n���Y�N���v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���Y�N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StProduceTypeOfYear
        {
            get { return _stProduceTypeOfYear; }
            set { _stProduceTypeOfYear = value; }
        }

        /// public property name  :  EdProduceTypeOfYear
        /// <summary>�I�����Y�N���v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����Y�N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EdProduceTypeOfYear
        {
            get { return _edProduceTypeOfYear; }
            set { _edProduceTypeOfYear = value; }
        }

		/// <summary>
		/// ���Y�N�����o�����N���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>PrdTypYearCondWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   PrdTypYearCondWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public PrdTypYearCondWork()
		{
		}

	}
}

using System;
using System.Collections;

using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SuplAccInfGetParameter
	/// <summary>
	///                      ���|���擾���o�����p�����[�^�N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���|���擾���o�����p�����[�^�N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/11/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
	[Serializable]
	public class SuplAccInfGetParameter
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>�v�㋒�_�R�[�h���X�g</summary>
		/// <remarks>���o�ΏۂƂȂ��Ă���v�㋒�_�R�[�h</remarks>
		private ArrayList _addUpSecCodeList = new ArrayList();

		/// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�d����R�[�h(�J�n)</summary>
        /// <remarks>SupplierCd���ݒ肳��Ă���ꍇ�͖���</remarks>
        private Int32 _startSupplierCd;

        /// <summary>�d����R�[�h(�I��)</summary>
        /// <remarks>SupplierCd���ݒ肳��Ă���ꍇ�͖���</remarks>
        private Int32 _endSupplierCd;
        
        /// <summary>�v��N���i�J�n�j</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _startAddUpYearMonth;

		/// <summary>�v��N���i�I���j</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _endAddUpYearMonth;

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
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
		}

		/// public propaty name  :  AddUpSecCodet
		/// <summary>�v�㋒�_�R�[�h�v���p�e�B</summary>
		/// <value>���o�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v�㋒�_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList AddUpSecCodeList
		{
			get{return _addUpSecCodeList;}
			set{_addUpSecCodeList = value;}
		}

        /// public propaty name  :  SupplierCd
		/// <summary>�d����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public Int32 SupplierCd
		{
            get { return _supplierCd; }
            set { _supplierCd = value; }
		}

        /// public propaty name  :  StartSupplierCd
        /// <summary>�d����R�[�h(�J�n)�v���p�e�B</summary>
        /// <value>SupplierCd���ݒ肳��Ă���ꍇ�͖���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StartSupplierCd
        {
            get { return _startSupplierCd; }
            set { _startSupplierCd = value; }
        }

        /// public propaty name  :  EndSupplierCd
        /// <summary>�d����R�[�h(�I��)�v���p�e�B</summary>
        /// <value>SupplierCd���ݒ肳��Ă���ꍇ�͖���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EndSupplierCd
        {
            get { return _endSupplierCd; }
            set { _endSupplierCd = value; }
        }

        /// public propaty name  :  StartAddUpYearMonth
		/// <summary>�v��N���i�J�n�j�v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v��N���i�J�n�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime StartAddUpYearMonth
		{
			get{return _startAddUpYearMonth;}
			set{_startAddUpYearMonth = value;}
		}

		/// public propaty name  :  EndAddUpYearMonth
		/// <summary>�v��N���i�I���j�v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v��N���i�I���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime EndAddUpYearMonth
		{
			get{return _endAddUpYearMonth;}
			set{_endAddUpYearMonth = value;}
		}

        /// <summary>
		/// ���|���p���o�����p�����[�^�N���X�R���X�g���N�^
		/// </summary>
		/// <returns>SuplAccInfGetParameter�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SuplAccInfGetParameter�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SuplAccInfGetParameter()
		{
		}

	}
}

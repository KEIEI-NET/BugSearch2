using System;
using System.Collections;

using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SuplierPayInfGetParameter
	/// <summary>
	///                      �x�����擾���o�����p�����[�^�N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   �x�����擾���o�����p�����[�^�N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/11/20  (CSharp File Generated Date)</br>
    /// <br></br>
    /// <br>UpdateNote	     : �d���摍���Ή�</br>
    /// <br>Programer        : FSI�֓� �a�G</br>
    /// <br>Date             : 2012/10/02</br>
    /// </remarks>
	[Serializable]
	public class SuplierPayInfGetParameter
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

        // --- ADD 2012/10/02 ---------->>>>>
        /// <summary>�d���摍���I�v�V����</summary>
        /// <remarks>0:���� 1:�L��</remarks>
        private Int32 _sumSuppEnable;
        // --- ADD 2012/10/02 ----------<<<<<

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
        /// <value>CustomerCode���ݒ肳��Ă���ꍇ�͖���</value>
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

        // --- ADD 2012/10/02 ---------->>>>>
        /// public propaty name  :  SumSuppEnable
        /// <summary>�d���摍���I�v�V�����v���p�e�B</summary>
        /// <value>0:���� 1:�L��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���摍���I�v�V�����v���p�e�B</br>
        /// <br>Programer        :   2012/10/02 FSI�֓� �a�G</br>
        /// </remarks>
        public Int32 SumSuppEnable
        {
            get { return _sumSuppEnable; }
            set { _sumSuppEnable = value; }
        }
        // --- ADD 2012/10/02 ----------<<<<<

        /// <summary>
		/// �x�����p���o�����p�����[�^�N���X�R���X�g���N�^
		/// </summary>
		/// <returns>SuplierPayInfGetParameter�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SuplierPayInfGetParameter�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SuplierPayInfGetParameter()
		{
		}

	}
}

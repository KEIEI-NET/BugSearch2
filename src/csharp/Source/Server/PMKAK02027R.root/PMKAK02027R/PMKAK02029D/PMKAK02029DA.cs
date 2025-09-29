//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���|�c���ꗗ�\�i�����j ���o�����N���X���[�N
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : FSI�y�~ �їR��
// �� �� ��  2012/09/14  �C�����e : �V�K�쐬 �d�������@�\�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570208-00 �쐬�S�� : 3H ������
// �C �� ��  2020/04/10  �C�����e : �y���ŗ��Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SumAccPaymentListCndtnWork
	/// <summary>
	///                      ���|�c���ꗗ�\�i�����j���o�����N���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���|�c���ꗗ�\�i�����j���o�����N���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2012/09/14  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
    /// <br>UpdateNote       :   11570208-00 �y���ŗ��Ή�</br>
    /// <br>Programmer       :   3H ������</br>
    /// <br>Date	         :   2020/04/10</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SumAccPaymentListCndtnWork
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���_�R�[�h</summary>
		/// <remarks>(�z��)�@�S�Ўw���{""}</remarks>
		private string[] _sectionCodes;

		/// <summary>�v��N����</summary>
		/// <remarks>YYYYMMDD ������������߂���t�B</remarks>
		private DateTime _addUpDate;

		/// <summary>�Ώ۔N��</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _addUpYearMonth;

		/// <summary>�J�n�x����R�[�h</summary>
		private Int32 _st_PayeeCode;

		/// <summary>�I���x����R�[�h</summary>
		private Int32 _ed_PayeeCode;

		/// <summary>�o�͋��z�敪</summary>
		/// <remarks>0:�S�� 1:0����׽ 2:��׽�̂� 3:0�̂� 4:0�ȊO 5:0��ϲŽ 6:ϲŽ�̂�</remarks>
		private Int32 _outMoneyDiv;

		/// <summary>�x������敪</summary>
		/// <remarks>0:�󎚂��� 1:�󎚂��Ȃ�</remarks>
		private Int32 _payDtlDiv;

        // --- ADD START 3H ������ 2020/04/10 ---------->>>>>
        /// <summary>�ŕʓ���󎚋敪</summary>
        /// <remarks>0:�󎚂��� 1:�󎚂��Ȃ�</remarks>
        private Int32 _taxPrintDiv;

        /// <summary>�ŗ�1</summary>
        /// <remarks>�ŗ�1</remarks>
        private Double _taxRate1;

        /// <summary>�ŗ�2</summary>
        /// <remarks>�ŗ�2</remarks>
        private Double _taxRate2;
        // --- ADD END 3H ������ 2020/04/10 ----------<<<<<

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

		/// public propaty name  :  SectionCodes
		/// <summary>���_�R�[�h�v���p�e�B</summary>
		/// <value>(�z��)�@�S�Ўw���{""}</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string[] SectionCodes
		{
			get{return _sectionCodes;}
			set{_sectionCodes = value;}
		}

		/// public propaty name  :  AddUpDate
		/// <summary>�v��N�����v���p�e�B</summary>
		/// <value>YYYYMMDD ������������߂���t�B</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v��N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime AddUpDate
		{
			get{return _addUpDate;}
			set{_addUpDate = value;}
		}

		/// public propaty name  :  AddUpYearMonth
		/// <summary>�Ώ۔N���v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Ώ۔N���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime AddUpYearMonth
		{
			get{return _addUpYearMonth;}
			set{_addUpYearMonth = value;}
		}

		/// public propaty name  :  St_PayeeCode
		/// <summary>�J�n�x����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�x����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_PayeeCode
		{
			get{return _st_PayeeCode;}
			set{_st_PayeeCode = value;}
		}

		/// public propaty name  :  Ed_PayeeCode
		/// <summary>�I���x����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���x����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_PayeeCode
		{
			get{return _ed_PayeeCode;}
			set{_ed_PayeeCode = value;}
		}

		/// public propaty name  :  OutMoneyDiv
		/// <summary>�o�͋��z�敪�v���p�e�B</summary>
		/// <value>0:�S�� 1:0����׽ 2:��׽�̂� 3:0�̂� 4:0�ȊO 5:0��ϲŽ 6:ϲŽ�̂�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�͋��z�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 OutMoneyDiv
		{
			get{return _outMoneyDiv;}
			set{_outMoneyDiv = value;}
		}

		/// public propaty name  :  PayDtlDiv
		/// <summary>�x������敪�v���p�e�B</summary>
		/// <value>0:�󎚂��� 1:�󎚂��Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x������敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PayDtlDiv
		{
			get{return _payDtlDiv;}
			set{_payDtlDiv = value;}
		}

        // --- ADD START 3H ������ 2020/04/10 ---------->>>>>
        /// <summary>�ŕʓ���󎚋敪</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŕʓ���󎚋敪</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TaxPrintDiv
        {
            get { return _taxPrintDiv; }
            set { _taxPrintDiv = value; }
        }

        /// public propaty name  :  TaxRate1
        /// <summary>�ŗ�1</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ�1</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TaxRate1
        {
            get { return _taxRate1; }
            set { _taxRate1 = value; }
        }

        /// public propaty name  :  TaxRate2
        /// <summary>�ŗ�2</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ�2</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TaxRate2
        {
            get { return _taxRate2; }
            set { _taxRate2 = value; }
        }
        // --- ADD END 3H ������ 2020/04/10 ----------<<<<<

		/// <summary>
		/// ���|�c���ꗗ�\�i�����j���o�����N���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>SumAccPaymentListCndtnWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SumAccPaymentListCndtnWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SumAccPaymentListCndtnWork()
		{
		}

	}
}

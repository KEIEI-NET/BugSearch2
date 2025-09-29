//***************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �d���ԕi�\��ꗗ�\
// �v���O�����T�v   : �d���ԕi�\��ꗗ�\ ���o�����N���X���[�N
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10806793-00 �쐬�S�� : FSI���� ����
// �� �� ��   2013/01/28 �C�����e : �V�K�쐬 �d���ԕi�\��@�\�Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   StockRetPlnParamWork
	/// <summary>
	///                      �d���ԕi�\��ꗗ�\���o�����N���X���[�N���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �d���ԕi�\��ꗗ�\���o�����N���X���[�N���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2009/04/07  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class StockRetPlnParamWork
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";
		/// <summary>���_�R�[�h</summary>
		/// <remarks>(�z��)�@�S�Ўw���{""}</remarks>
		private string[] _sectionCodes;
		/// <summary>�J�n�d����R�[�h</summary>
		private Int32 _supplierCdSt;
		/// <summary>�I���d����R�[�h</summary>
		private Int32 _supplierCdEd;
		/// <summary>�J�n�d�����t</summary>
		private Int32 _stockDateSt;
		/// <summary>�I���d�����t</summary>
		private Int32 _stockDateEd;
		/// <summary>�J�n���͓��t</summary>
		private Int32 _inputDaySt;
		/// <summary>�I�����͓��t</summary>
		private Int32 _inputDayEd;
		/// <summary>���s�^�C�v</summary>
		private Int32 _makeShowDiv;
		/// <summary>�o�͎w��</summary>
		private Int32 _slipDiv;
        /// <summary>���t�w��</summary>
        private Int32 _printDailyFooter;
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

		/// public propaty name  :  SupplierCdSt
		/// <summary>�J�n�d����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�d����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierCdSt
		{
			get{return _supplierCdSt;}
			set{_supplierCdSt = value;}
		}

		/// public propaty name  :  SupplierCdEd
		/// <summary>�I���d����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���d����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierCdEd
		{
			get{return _supplierCdEd;}
			set{_supplierCdEd = value;}
		}

		/// public propaty name  :  StockDateSt
		/// <summary>�J�n�d�����t�v���p�e�B</summary>
		/// <value>YYYYMMDD (�����͂�0)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�d�����t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockDateSt
		{
			get{return _stockDateSt;}
			set{_stockDateSt = value;}
		}

		/// public propaty name  :  StockDateEd
		/// <summary>�I���d�����t�v���p�e�B</summary>
		/// <value>YYYYMMDD (�����͂�0)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���d�����t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockDateEd
		{
			get{return _stockDateEd;}
			set{_stockDateEd = value;}
		}

		/// public propaty name  :  InputDaySt
		/// <summary>�J�n���͓��t�v���p�e�B</summary>
		/// <value>YYYYMMDD (�����͂�0)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���͓��t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InputDaySt
		{
			get{return _inputDaySt;}
			set{_inputDaySt = value;}
		}

		/// public propaty name  :  InputDayEd
		/// <summary>�I�����͓��t�v���p�e�B</summary>
		/// <value>YYYYMMDD (�����͂�0)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����͓��t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InputDayEd
		{
			get{return _inputDayEd;}
			set{_inputDayEd = value;}
		}

		/// public propaty name  :  MakeShowDiv
		/// <summary>���s�^�C�v�v���p�e�B</summary>
		/// <value>0:�S�Ĉ��,1:�c�̂�   �����g�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���s�^�C�v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 MakeShowDiv
		{
			get{return _makeShowDiv;}
			set{_makeShowDiv = value;}
		}

		/// public propaty name  :  SlipDiv
		/// <summary>�o�͎w��v���p�e�B</summary>
		/// <value>0:�ԕi�\��̂�,1:�ԕi�ς̂�,2:���ׂ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�͎w��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SlipDiv
		{
			get{return _slipDiv;}
			set{_slipDiv = value;}
		}

        /// public propaty name  :  DebitNoteDiv
        /// <summary>���t�w��v���p�e�B</summary>
        /// <value>0:�ʏ�,1:�폜</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���t�w��v���p�e�B�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrintDailyFooter
        {
            get { return _printDailyFooter; }
            set { _printDailyFooter = value; }
        }

		/// <summary>
		/// �d���ԕi�\��ꗗ�\���o�����N���X���[�N���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>StockRetPlnParamWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockRetPlnParamWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockRetPlnParamWork()
		{
		}

	}

}

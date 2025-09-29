using System;
using System.Collections;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SearchParaChartAccept2
	/// <summary>
	///                      �x���`�[�����p�����[�^�N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   �x���`�[�����p�����[�^�N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   99033 ��{�@�E</br>
    /// <br>Date             :   2005/8/16</br>
    /// <br></br>
    /// <br>Update Note      :   980081  �R�c ���F</br>
    /// <br>                 :   2008.01.30 �����x���敪�E�d���`�[�ԍ���ǉ�</br>
    /// </remarks>
	[Serializable]
	public class SearchParaPaymentRead
	{
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�v�㋒�_�R�[�h</summary>
        private string _addUpSecCode;

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�x���`�[�ԍ�</summary>
        private Int32 _paymentSlipNo;

		/// <summary>������(�J�n)</summary>
		private DateTime _paymentCallMonthsStart;

		/// <summary>������(�I��)</summary>
		private DateTime _paymentCallMonthsEnd;
        // �� 2008.01.30 980081 a
        /// <summary>�����x���敪</summary>
        /// <remarks>0:�ʏ�x��,�@1:�����x��</remarks>
        private Int32 _autoPayment;

        /// <summary>�d���`�[�ԍ�</summary>
        private Int32 _supplierSlipNo;
        // �� 2008.01.30 980081 a

        /// public propaty name  :  enterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get{return _enterpriseCode;}
            set{_enterpriseCode = value;}
        }

        /// public propaty name  :  addUpSecCode
        /// <summary>�v�㋒�_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�㋒�_�R�[�h�v���p�e�B</br>
        /// </remarks>
        public string AddUpSecCode
        {
            get{return _addUpSecCode;}
            set{_addUpSecCode = value;}
        }

        /// public propaty name  :  supplierCd
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h�v���p�e�B</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get{return _supplierCd;}
            set{_supplierCd = value;}
        }

        /// public propaty name  :  PaymentSlipNo
        /// <summary>�x���`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���`�[�ԍ��v���p�e�B</br>
        /// </remarks>
        public Int32 PaymentSlipNo
        {
            get{return _paymentSlipNo;}
            set{_paymentSlipNo = value;}
        }

		/// public propaty name  :  depositCallMonthsStart
		/// <summary>�x����(�J�n)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x����(�J�n)�v���p�e�B</br>
		/// </remarks>
		public DateTime PaymentCallMonthsStart
		{
			get{return _paymentCallMonthsStart;}
			set{_paymentCallMonthsStart = value;}
		}

		/// public propaty name  :  depositCallMonthsEnd
		/// <summary>�x����(�I��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x����(�I��)�v���p�e�B</br>
		/// </remarks>
		public DateTime PaymentCallMonthsEnd
		{
			get{return _paymentCallMonthsEnd;}
			set{_paymentCallMonthsEnd = value;}
		}
        // �� 2008.01.30 980081 a
        /// public propaty name  :  AutoPayment
        /// <summary>�����x���敪�v���p�e�B</summary>
        /// <value>0:�ʏ�x��,�@1:�����x��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����x���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AutoPayment
        {
            get { return _autoPayment; }
            set { _autoPayment = value; }
        }

        /// public propaty name  :  SupplierSlipNo
        /// <summary>�d���`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierSlipNo
        {
            get { return _supplierSlipNo; }
            set { _supplierSlipNo = value; }
        }
        // �� 2008.01.30 980081 a

		/// <summary>
		/// �d�������p�����[�^�N���X�R���X�g���N�^
		/// </summary>
		/// <returns>SearchParaPaymentRead�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SearchParaPaymentRead�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// </remarks>
		public SearchParaPaymentRead()
		{

		}

		/// <summary>
		/// �x�������p�����[�^�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ƃR�[�h�A�v�㋒�_�R�[�h�A�d����R�[�h�A�x���`�[�ԍ��A�x����(�J�n)�A�x����(�I��) ���Z�b�g���܂��B</br>
		/// <br>Programmer : 90027 ����  ��</br>
		/// <br>Date       : 2005.08.16</br>
        /// <br></br>
        /// <br>Update Note: 980081  �R�c ���F</br>
        /// <br>           : 2008.01.30 �����x���敪�E�d���`�[�ԍ���ǉ�</br>
        /// </remarks>
        // �� 2008.01.30 980081 c
        //public SearchParaPaymentRead(string enterpriseCode, string addUpSecCode, Int32 supplierCd,  Int32 paymentSlipNo, DateTime paymentCallMonthsStart, DateTime paymentCallMonthsEnd)
		//{
		//	this._enterpriseCode          = enterpriseCode;
		//	this._addUpSecCode		      = addUpSecCode;
		//	this._supplierCd            = supplierCd;
        //    this._paymentSlipNo = paymentSlipNo;
		//	this._paymentCallMonthsStart  = paymentCallMonthsStart;
        //    this._paymentCallMonthsEnd    = paymentCallMonthsEnd;
        //}
        public SearchParaPaymentRead(string enterpriseCode, string addUpSecCode, Int32 supplierCd, Int32 paymentSlipNo, DateTime paymentCallMonthsStart, DateTime paymentCallMonthsEnd, Int32 autoPayment, Int32 supplierSlipNo)
        {
            this._enterpriseCode = enterpriseCode;
            this._addUpSecCode = addUpSecCode;
            this._supplierCd = supplierCd;
            this._paymentSlipNo = paymentSlipNo;
            this._paymentCallMonthsStart = paymentCallMonthsStart;
            this._paymentCallMonthsEnd = paymentCallMonthsEnd;
            this._autoPayment = autoPayment;
            this._supplierSlipNo = supplierSlipNo;
        }
        // �� 2008.01.30 980081 c


	}
}

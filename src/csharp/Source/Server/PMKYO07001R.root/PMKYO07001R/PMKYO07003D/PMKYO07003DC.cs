using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SearchCountWork
    /// <summary>
    ///                      ���M�������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���M�������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/9/29</br>
    /// <br>Genarated Date   :   2009/04/08  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SearchCountWork
    {
        /// <summary>����f�[�^COUNT</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private Int32 _salesSlipCount;

        /// <summary>���㖾�׃f�[�^COUNT</summary>
        private Int32 _salesDetailCount;

        /// <summary>���㗚���f�[�^COUNT</summary>
        private Int32 _salesHistoryCount;

        /// <summary>���㗚�𖾍׃f�[�^COUNT</summary>
        private Int32 _salesHistDtlCount;

        /// <summary>�����f�[�^COUNT</summary>
        private Int32 _depsitMainCount;

        /// <summary>�������׃f�[�^COUNT</summary>
        private Int32 _depsitDtlCount;

        /// <summary>�d���f�[�^COUNT</summary>
        private Int32 _stockSlipCount;

        /// <summary>�d�����׃f�[�^COUNT</summary>
        private Int32 _stockDetailCount;

        /// <summary>�d�������f�[�^COUNT</summary>
        private Int32 _stockSlipHistCount;

        /// <summary>�d�����𖾍׃f�[�^COUNT</summary>
        private Int32 _stockSlHistDtlCount;

        /// <summary>�x���`�[�}�X�^COUNT</summary>
        private Int32 _paymentSlpCount;

        /// <summary>�x�����׃f�[�^COUNT</summary>
        private Int32 _paymentDtlCount;

        /// <summary>�󒍃}�X�^COUNT</summary>
        private Int32 _acceptOdrCount;

        /// <summary>�󒍃}�X�^�i�ԗ��jCOUNT</summary>
        private Int32 _acceptOdrCarCount;

        /// <summary>���㌎���W�v�f�[�^COUNT</summary>
        private Int32 _mTtlSalesSlipCount;

        /// <summary>���i�ʔ��㌎���W�v�f�[�^COUNT</summary>
        private Int32 _goodsMTtlSaSlipCount;

        /// <summary>�d�������W�v�f�[�^COUNT</summary>
        private Int32 _mTtlStockSlipCount;

        /// <summary>�݌ɒ����f�[�^COUNT</summary>
        private Int32 _stockAdjustCount;

        /// <summary>�݌ɒ������׃f�[�^COUNT</summary>
        private Int32 _stockAdjustDtlCount;

        /// <summary>�݌Ɉړ��f�[�^COUNT</summary>
        private Int32 _stockMoveCount;

        /// <summary>�݌Ɏ󕥗����f�[�^COUNT</summary>
        private Int32 _stockAcPayHistCount;

		/// <summary>���������}�X�^COUNT</summary>
		private Int32 _depositAlwCount;

		/// <summary>����`�}�X�^COUNT</summary>
		private Int32 _rcvDraftDataCount;

		/// <summary>�x����`�}�X�^COUNT</summary>
		private Int32 _payDraftDataCount;
        /// <summary>�X�e�[�^�X</summary>
        private Int32 _status;

        /// public propaty name  :  SalesSlipCount
        /// <summary>����f�[�^COUNT�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����f�[�^COUNT�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesSlipCount
        {
            get { return _salesSlipCount; }
            set { _salesSlipCount = value; }
        }

        /// public propaty name  :  SalesDetailCount
        /// <summary>���㖾�׃f�[�^COUNT�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㖾�׃f�[�^COUNT�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesDetailCount
        {
            get { return _salesDetailCount; }
            set { _salesDetailCount = value; }
        }

        /// public propaty name  :  SalesHistoryCount
        /// <summary>���㗚���f�[�^COUNT�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㗚���f�[�^COUNT�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesHistoryCount
        {
            get { return _salesHistoryCount; }
            set { _salesHistoryCount = value; }
        }

        /// public propaty name  :  SalesHistDtlCount
        /// <summary>���㗚�𖾍׃f�[�^COUNT�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㗚�𖾍׃f�[�^COUNT�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesHistDtlCount
        {
            get { return _salesHistDtlCount; }
            set { _salesHistDtlCount = value; }
        }

        /// public propaty name  :  DepsitMainCount
        /// <summary>�����f�[�^COUNT�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����f�[�^COUNT�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepsitMainCount
        {
            get { return _depsitMainCount; }
            set { _depsitMainCount = value; }
        }

        /// public propaty name  :  DepsitDtlCount
        /// <summary>�������׃f�[�^COUNT�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������׃f�[�^COUNT�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepsitDtlCount
        {
            get { return _depsitDtlCount; }
            set { _depsitDtlCount = value; }
        }

        /// public propaty name  :  StockSlipCount
        /// <summary>�d���f�[�^COUNT�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���f�[�^COUNT�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockSlipCount
        {
            get { return _stockSlipCount; }
            set { _stockSlipCount = value; }
        }

        /// public propaty name  :  StockDetailCount
        /// <summary>�d�����׃f�[�^COUNT�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����׃f�[�^COUNT�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockDetailCount
        {
            get { return _stockDetailCount; }
            set { _stockDetailCount = value; }
        }

        /// public propaty name  :  StockSlipHistCount
        /// <summary>�d�������f�[�^COUNT�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�������f�[�^COUNT�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockSlipHistCount
        {
            get { return _stockSlipHistCount; }
            set { _stockSlipHistCount = value; }
        }

        /// public propaty name  :  StockSlHistDtlCount
        /// <summary>�d�����𖾍׃f�[�^COUNT�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����𖾍׃f�[�^COUNT�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockSlHistDtlCount
        {
            get { return _stockSlHistDtlCount; }
            set { _stockSlHistDtlCount = value; }
        }

        /// public propaty name  :  PaymentSlpCount
        /// <summary>�x���`�[�}�X�^COUNT�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���`�[�}�X�^COUNT�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentSlpCount
        {
            get { return _paymentSlpCount; }
            set { _paymentSlpCount = value; }
        }

        /// public propaty name  :  PaymentDtlCount
        /// <summary>�x�����׃f�[�^COUNT�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����׃f�[�^COUNT�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentDtlCount
        {
            get { return _paymentDtlCount; }
            set { _paymentDtlCount = value; }
        }

        /// public propaty name  :  AcceptOdrCount
        /// <summary>�󒍃}�X�^COUNT�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃}�X�^COUNT�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcceptOdrCount
        {
            get { return _acceptOdrCount; }
            set { _acceptOdrCount = value; }
        }

        /// public propaty name  :  AcceptOdrCarCount
        /// <summary>�󒍃}�X�^�i�ԗ��jCOUNT�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃}�X�^�i�ԗ��jCOUNT�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcceptOdrCarCount
        {
            get { return _acceptOdrCarCount; }
            set { _acceptOdrCarCount = value; }
        }

        /// public propaty name  :  MTtlSalesSlipCount
        /// <summary>���㌎���W�v�f�[�^COUNT�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㌎���W�v�f�[�^COUNT�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MTtlSalesSlipCount
        {
            get { return _mTtlSalesSlipCount; }
            set { _mTtlSalesSlipCount = value; }
        }

        /// public propaty name  :  GoodsMTtlSaSlipCount
        /// <summary>���i�ʔ��㌎���W�v�f�[�^COUNT�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ʔ��㌎���W�v�f�[�^COUNT�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMTtlSaSlipCount
        {
            get { return _goodsMTtlSaSlipCount; }
            set { _goodsMTtlSaSlipCount = value; }
        }

        /// public propaty name  :  MTtlStockSlipCount
        /// <summary>�d�������W�v�f�[�^COUNT�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�������W�v�f�[�^COUNT�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MTtlStockSlipCount
        {
            get { return _mTtlStockSlipCount; }
            set { _mTtlStockSlipCount = value; }
        }

        /// public propaty name  :  StockAdjustCount
        /// <summary>�݌ɒ����f�[�^COUNT�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɒ����f�[�^COUNT�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockAdjustCount
        {
            get { return _stockAdjustCount; }
            set { _stockAdjustCount = value; }
        }

        /// public propaty name  :  StockAdjustDtlCount
        /// <summary>�݌ɒ������׃f�[�^COUNT�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɒ������׃f�[�^COUNT�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockAdjustDtlCount
        {
            get { return _stockAdjustDtlCount; }
            set { _stockAdjustDtlCount = value; }
        }

        /// public propaty name  :  StockMoveCount
        /// <summary>�݌Ɉړ��f�[�^COUNT�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɉړ��f�[�^COUNT�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockMoveCount
        {
            get { return _stockMoveCount; }
            set { _stockMoveCount = value; }
        }

        /// public propaty name  :  StockAcPayHistCount
        /// <summary>�݌Ɏ󕥗����f�[�^COUNT�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɏ󕥗����f�[�^COUNT�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockAcPayHistCount
        {
            get { return _stockAcPayHistCount; }
            set { _stockAcPayHistCount = value; }
        }

		/// public propaty name  :  DepositAlwCount
		/// <summary>���������}�X�^COUNT�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���������}�X�^COUNT�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DepositAlwCount
		{
			get { return _depositAlwCount; }
			set { _depositAlwCount = value; }
		}

		/// public propaty name  :  RcvDraftDataCount
		/// <summary>����`�}�X�^COUNT�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����`�}�X�^COUNT�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 RcvDraftDataCount
		{
			get { return _rcvDraftDataCount; }
			set { _rcvDraftDataCount = value; }
		}

		/// public propaty name  :  PayDraftDataCount
		/// <summary>�x����`�}�X�^COUNT�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x����`�}�X�^COUNT�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PayDraftDataCount
		{
			get { return _payDraftDataCount; }
			set { _payDraftDataCount = value; }
		}
        /// public propaty name  :  Status
        /// <summary>�X�e�[�^�X�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�e�[�^�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Status
        {
            get { return _status; }
            set { _status = value; }
        }

        /// <summary>
        /// �o�׃f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>ShipmentWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ShipmentWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SearchCountWork()
        {
        }

    }
}

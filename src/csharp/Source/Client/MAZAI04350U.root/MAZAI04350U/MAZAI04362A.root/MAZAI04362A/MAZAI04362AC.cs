using System;
using System.Collections.Generic;

namespace Broadleaf.Application.Controller
{
	//********************************************************************************
	//  �C�x���g�p�����[�^��`
	//********************************************************************************
	//==================================================================
	//  �p�u���b�N�N���X
	//==================================================================
	/// <summary>
	/// �`�[���׍s�����C�x���g�����N���X
	/// </summary>
	public class SlipDtlRowChangedEventArgs : EventArgs
	{
		//--------------------------------------------------------
		//  �v���C�x�[�g�ϐ�
		//--------------------------------------------------------
		#region �v���C�x�[�g�ϐ�
		/// <summary>�Ώۂ̍s�C���f�b�N�X(0�`)</summary>
		private int _rowIndex;
		/// <summary>����ΏۃI�u�W�F�N�g</summary>
		private object _object;
		#endregion

		//--------------------------------------------------------
		//  �R���X�g���N�^
		//--------------------------------------------------------
		#region �R���X�g���N�^
		/// <summary>
		/// �`�[���׍s�����C�x���g�����N���X�̃R���X�g���N�^�[
		/// </summary>
		/// <param name="rowIndex">�Ώۍs�C���f�b�N�X(0�`)</param>
		/// <param name="dest">�Ώۍs�̒l</param>
		public SlipDtlRowChangedEventArgs(int rowIndex, object dest)
			: base()
		{
			this._rowIndex = rowIndex;
			this._object = dest;
		}
		#endregion

		//--------------------------------------------------------
		//  �v���p�e�B
		//--------------------------------------------------------
		#region �v���p�e�B
		/// <summary>�Ώۍs�C���f�b�N�X</summary>
		public int RowIndex
		{
			get { return this._rowIndex; }
		}

		/// <summary>����Ώۍs�̓��e</summary>
		public object Destination
		{
			get { return this._object; }
		}
		#endregion
	}

	/// <summary>
	/// �`�[���׍s����O�C�x���g�����N���X
	/// </summary>
	public class SlipDtlRowChangingEventArgs : SlipDtlRowChangedEventArgs
	{
		//--------------------------------------------------------
		//  �v���C�x�[�g�ϐ�
		//--------------------------------------------------------
		#region �v���C�x�[�g�ϐ�
		/// <summary>����L�����Z���t���O</summary>
		private bool _cancel;
		#endregion

		//--------------------------------------------------------
		//  �R���X�g���N�^
		//--------------------------------------------------------
		#region �R���X�g���N�^
		/// <summary>
		/// �`�[���׍s����O�C�x���g�����N���X�R���X�g���N�^�[
		/// </summary>
		/// <param name="rowIndex">�Ώۍs�C���f�b�N�X(0�`)</param>
		/// <param name="dest">�Ώۍs�̒l</param>
		public SlipDtlRowChangingEventArgs(int rowIndex, object dest)
			: base(rowIndex, dest)
		{
			this._cancel = false;
		}
		#endregion

		//--------------------------------------------------------
		//  �v���p�e�B
		//--------------------------------------------------------
		#region �v���p�e�B
		/// <summary>�L�����Z���t���O</summary>
		public bool Cancel
		{
			get { return this._cancel; }
			set { this._cancel = value; }
		}
		#endregion
	}


	/// <summary>
	/// �`�[���ח񑀍�O�C�x���g�����N���X
	/// </summary>
	public class SlipDtlColChangingEventArgs : SlipDtlColChangedEventArgs
	{
		//--------------------------------------------------------
		//  �v���C�x�[�g�ϐ�
		//--------------------------------------------------------
		#region �v���C�x�[�g�ϐ�
		/// <summary>�L�����Z���t���O</summary>
		private bool _cancel;
		#endregion

		//--------------------------------------------------------
		//  �R���X�g���N�^
		//--------------------------------------------------------
		#region �R���X�g���N�^
		/// <summary>
		/// �`�[���ח񑀍�O�C�x���g�����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="row">�Ώۍs�C���f�b�N�X(0~)</param>
		/// <param name="column">�Ώۗ�̃f�[�^�J����</param>
		/// <param name="dest">�Ώۗ�̒l</param>
		public SlipDtlColChangingEventArgs(int row, System.Data.DataColumn column, object dest)
			: base(row, column, dest)
		{
			this._cancel = false;
		}
		#endregion

		//--------------------------------------------------------
		//  �v���p�e�B
		//--------------------------------------------------------
		#region �v���p�e�B
		/// <summary>
		/// �L�����Z���t���O
		/// </summary>
		public bool Cancel
		{
			get { return this._cancel; }
			set { this._cancel = value; }
		}
		#endregion
	}

	/// <summary>
	/// �`�[���ח񑀍��C�x���g�����N���X�̃R���X�g���N�^�[
	/// </summary>
	public class SlipDtlColChangedEventArgs : SlipDtlRowChangedEventArgs
	{
		//--------------------------------------------------------
		//  �v���C�x�[�g�ϐ�
		//--------------------------------------------------------
		#region �v���C�x�[�g�ϐ�
		/// <summary>�C�x���g�����������J�����ʒu</summary>
		private System.Data.DataColumn _dataColumn;
		#endregion

		//--------------------------------------------------------
		//  �R���X�g���N�^
		//--------------------------------------------------------
		#region �R���X�g���N�^
		/// <summary>
		/// �`�[���ח񑀍��C�x���g�����N���X�̃R���X�g���N�^
		/// </summary>
		/// <param name="row">�Ώۍs�C���f�b�N�X</param>
		/// <param name="column">�Ώۗ�̃f�[�^�J����</param>
		/// <param name="dest">�Ώۗ�̒l</param>
		public SlipDtlColChangedEventArgs(int row, System.Data.DataColumn column, object dest)
			: base(row, dest)
		{
			this._dataColumn = column;
		}
		#endregion

		//--------------------------------------------------------
		//  �v���p�e�B
		//--------------------------------------------------------
		#region �v���p�e�B
		/// <summary>�C�x���g������������̗񖼏�</summary>
		public string ColumnName
		{
			get { return this._dataColumn.ColumnName; }
		}

		/// <summary>�C�x���g������������̃f�[�^�J����</summary>
		public System.Data.DataColumn Column
		{
			get { return this._dataColumn; }
		}
		#endregion
	}

    /// <summary>
    /// �݌Ƀ}�X�^�d�����f�p�N���X
    /// </summary>
    public class ChkStock
    {
        private string enterPriseCode;
        private string sectionCode;
        // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        //private int makerCode;
        //private string goodsCode;
        private int goodsMakerCd;
        private string goodsNo;
        // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
        private string productNumber;
        // 2008.03.28 �ǉ� >>>>>>>>>>>>>>>>>>>>
        private string warehouseCode;
        // 2008.03.28 �ǉ� <<<<<<<<<<<<<<<<<<<<

        public ChkStock()
        {
        }

        // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        //public ChkStock(string EnterPriseCode, string SectionCode, int MakerCode, string GoodsCode, string ProductNumber)
        // 2008.03.28 �C�� >>>>>>>>>>>>>>>>>>>>
        //public ChkStock(string EnterPriseCode, string SectionCode, int GoodsMakerCd, string GoodsNo, string ProductNumber)
        public ChkStock(string EnterPriseCode, string SectionCode, int GoodsMakerCd, string GoodsNo, string ProductNumber, string WarehouseCode)
        // 2008.03.28 �C�� <<<<<<<<<<<<<<<<<<<<
        // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
        {
            enterPriseCode = EnterPriseCode;
            sectionCode = SectionCode;
            // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
            //makerCode = MakerCode;
            //goodsCode = GoodsCode;
            goodsMakerCd = GoodsMakerCd;
            goodsNo = GoodsNo;
            // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
            productNumber = ProductNumber;
            // 2008.03.28 �ǉ� >>>>>>>>>>>>>>>>>>>>
            warehouseCode = WarehouseCode;
            // 2008.03.28 �ǉ� <<<<<<<<<<<<<<<<<<<<
        }

        public string EnterPriseCode
        {
            get { return this.enterPriseCode; }
            set { this.enterPriseCode = value; }
        }
        public string SectionCode
        {
            get { return this.sectionCode;}
            set { this.sectionCode = value; }
        }
        // 2007.10.11 �C�� >>>>>>>>>>>>>>>>>>>>
        //public int MakerCode
        //{
        //    get { return this.makerCode; }
        //    set { this.makerCode = value; }
        //}
        //public string GoodsCode
        //{
        //    get { return this.goodsCode; }
        //    set { this.goodsCode = value; }
        //}
        public int GoodsMakerCd
        {
            get { return this.goodsMakerCd; }
            set { this.goodsMakerCd = value; }
        }
        public string GoodsNo
        {
            get { return this.goodsNo; }
            set { this.goodsNo = value; }
        }
        // 2007.10.11 �C�� <<<<<<<<<<<<<<<<<<<<
        public string ProductNumber
        {
            get { return this.productNumber; }
            set { this.productNumber = value; }
        }
        // 2008.03.28 �ǉ� >>>>>>>>>>>>>>>>>>>>
        public string WarehouseCode
        {
            get { return this.warehouseCode; }
            set { this.warehouseCode = value; }
        }
        // 2008.03.28 �ǉ� <<<<<<<<<<<<<<<<<<<<
    }

}

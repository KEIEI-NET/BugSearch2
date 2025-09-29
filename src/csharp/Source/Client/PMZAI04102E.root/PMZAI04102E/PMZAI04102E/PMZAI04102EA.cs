using System;
using System.Collections;
using Broadleaf.Library.Globarization;
using System.Collections.Generic;

namespace Broadleaf.Application.UIData
{
	/// public class name:   StockHistoryDspSearchParamWork
	/// <summary>
	///                      �݌Ɏ��яƉ�o�������[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �݌Ɏ��яƉ�o�������[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/11/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2010/07/20 ������ �e�L�X�g�o�͑Ή�</br>
	/// </remarks>
	[Serializable]
	public class StockHistoryDspSearchParam
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>�q�ɃR�[�h</summary>
		private string _warehouseCode = "";

		/// <summary>���i���[�J�[�R�[�h</summary>
		private Int32 _goodsMakerCd;

		/// <summary>���i�ԍ�</summary>
		private string _goodsNo = "";

		/// <summary>�J�n�N��</summary>
		/// <remarks>YYYYMM</remarks>
		private Int32 _stAddUpYearMonth;

		/// <summary>�I���N��</summary>
		/// <remarks>YYYYMM</remarks>
		private Int32 _edAddUpYearMonth;

        /// <summary>�J�n�N����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _stAddUpDate;

        /// <summary>�I���N����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _edAddUpDate;

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode;

        // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� -------------------->>>>>
        /// <summary>�q�ɃR�[�h���X�g</summary>
        private List<string> _warehouseCodeList = new List<string>();

        /// <summary>�I�ԃ��X�g</summary>
        private List<string> _warehouseShelfNoList = new List<string>();

        /// <summary>���[�J�[�R�[�h���X�g</summary>
        private List<Int32> _makerCodeList = new List<Int32>();

        /// <summary>BL�R�[�h���X�g</summary>
        private List<Int32> _blGoodsCodeList = new List<Int32>();

        /// <summary>�i�ԃ��X�g</summary>
        private List<string> _goodsNoList = new List<string>();
        // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� --------------------<<<<<

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

		/// public propaty name  :  WarehouseCode
		/// <summary>�q�ɃR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �q�ɃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string WarehouseCode
		{
			get{return _warehouseCode;}
			set{_warehouseCode = value;}
		}

		/// public propaty name  :  GoodsMakerCd
		/// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsMakerCd
		{
			get{return _goodsMakerCd;}
			set{_goodsMakerCd = value;}
		}

		/// public propaty name  :  GoodsNo
		/// <summary>���i�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsNo
		{
			get{return _goodsNo;}
			set{_goodsNo = value;}
		}

		/// public propaty name  :  StAddUpYearMonth
		/// <summary>�J�n�N���v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�N���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public Int32 StAddUpYearMonth
		{
			get{return _stAddUpYearMonth;}
			set{_stAddUpYearMonth = value;}
		}

		/// public propaty name  :  EdAddUpYearMonth
		/// <summary>�I���N���v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���N���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public Int32 EdAddUpYearMonth
		{
			get{return _edAddUpYearMonth;}
			set{_edAddUpYearMonth = value;}
		}

        /// public propaty name  :  StAddUpDate
        /// <summary>�J�n�N���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StAddUpDate
        {
            get { return _stAddUpDate; }
            set { _stAddUpDate = value; }
        }

        /// public propaty name  :  EdAddUpDate
        /// <summary>�I���N���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EdAddUpDate
        {
            get { return _edAddUpDate; }
            set { _edAddUpDate = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>���i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� -------------------->>>>>
        /// public propaty name  :  WarehouseCodeList
        /// <summary>�q�ɃR�[�h���X�g�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h���X�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public List<string> WarehouseCodeList
        {
            get { return _warehouseCodeList; }
            set { _warehouseCodeList = value; }
        }

        /// public propaty name  :  WarehouseShelfNoList
        /// <summary>�I�ԃ��X�g�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�ԃ��X�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public List<string> WarehouseShelfNoList
        {
            get { return _warehouseShelfNoList; }
            set { _warehouseShelfNoList = value; }
        }

        /// public propaty name  :  MakerCodeList
        /// <summary>���[�J�[�R�[�h���X�g�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�R�[�h���X�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public List<Int32> MakerCodeList
        {
            get { return _makerCodeList; }
            set { _makerCodeList = value; }
        }

        /// public propaty name  :  BlGoodsCodeList
        /// <summary>BL�R�[�h���X�g�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h���X�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public List<Int32> BlGoodsCodeList
        {
            get { return _blGoodsCodeList; }
            set { _blGoodsCodeList = value; }
        }

        /// public propaty name  :  GoodsNoList
        /// <summary>�i�ԃR�[�h���X�g�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ԃR�[�h���X�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public List<string> GoodsNoList
        {
            get { return _goodsNoList; }
            set { _goodsNoList = value; }
        }
        // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� --------------------<<<<<

		/// <summary>
		/// �݌Ɏ��яƉ�o�������[�N�R���X�g���N�^
		/// </summary>
		/// <returns>StockHistoryDspSearchParamWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockHistoryDspSearchParamWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockHistoryDspSearchParam()
		{
		}

        
        /// <summary>
        /// �݌Ɏ��яƉ�N���X�R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="sectionCode">���_�R�[�h(�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h)</param>
        /// <param name="stAddUpYearMonth">�v��N��(�J�n)(YYYYMM)</param>
        /// <param name="edAddUpYearMonth">�v��N��(�I��)(YYYYMM)</param>
        /// <param name="warehouseCodeList">�q�ɃR�[�h���X�g</param>
        /// <param name="warehouseShelfNoList">�I�ԃ��X�g</param>
        /// <param name="makerCodeList">���[�J�[�R�[�h���X�g</param>
        /// <param name="blGoodsCodeList">BL�R�[�h���X�g</param>
        /// <param name="goodsNoList">�i�ԃR�[�h���X�g</param>
        /// <returns>ShipmentPartsDspParam�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ShipmentPartsDspParam�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockHistoryDspSearchParam(string enterpriseCode, string GoodsNo, Int32 GoodsMakerCd, string WarehouseCode, Int32 StAddUpYearMonth, Int32 EdAddUpYearMonth, Int32 StAddUpDate, Int32 EdAddUpDate, string SectionCode, List<string> warehouseCodeList, List<string> warehouseShelfNoList, List<Int32> makerCodeList, List<Int32> blGoodsCodeList, List<string> goodsNoList)
        {
            this._enterpriseCode = enterpriseCode;
            this._goodsNo = GoodsNo;
            this._goodsMakerCd = GoodsMakerCd;
            this._warehouseCode = WarehouseCode;
            this._stAddUpYearMonth = StAddUpYearMonth;
            this._edAddUpYearMonth = EdAddUpYearMonth;
            this._stAddUpDate = StAddUpDate;
            this._edAddUpDate = EdAddUpDate;
            this._sectionCode = SectionCode;
            // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� -------------------->>>>>
            this._warehouseCodeList = warehouseCodeList;
            this._warehouseShelfNoList = warehouseShelfNoList;
            this._makerCodeList = makerCodeList;
            this._blGoodsCodeList = blGoodsCodeList;
            this._goodsNoList = goodsNoList;
            // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� --------------------<<<<<
        }

	
        /// <summary>
        /// �o�ו��i�\�������N���X��������
        /// </summary>
        /// <returns>ShipmentPartsDspParam�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// 
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����ShipmentPartsDspParam�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockHistoryDspSearchParam Clone()
        {
            return new StockHistoryDspSearchParam(this._enterpriseCode, this._goodsNo,this._goodsMakerCd, this._warehouseCode, this._stAddUpYearMonth, this._edAddUpYearMonth, this._stAddUpDate, this._edAddUpDate, this._sectionCode, this._warehouseCodeList, this._warehouseShelfNoList, this._makerCodeList, this._blGoodsCodeList, this._goodsNoList);
        }
    }
}

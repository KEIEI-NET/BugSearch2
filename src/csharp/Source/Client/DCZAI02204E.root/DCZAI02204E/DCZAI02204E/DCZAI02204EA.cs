using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// �݌Ɏ󕥊m�F�\�e�[�u���X�L�[�}��`�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �݌Ɏ󕥊m�F�\�e�[�u���X�L�[�}�N���X�̒�`�E�������y�уC���X�^���X�������s���B</br>
	/// <br>Programmer : 22018 ��� ���b</br>
	/// <br>Date       : 2007.09.19</br>
	/// <br></br>
    /// <br>Update Note: 2008/12/15 �Ɠc �M�u�@���ɋ��z�A�o�ɋ��z�ǉ�</br>
    /// <br>             2009/01/08 �Ɠc �M�u�@�P������ɒP���A�o�ɒP���ɕ���</br>
    /// <br>             2009/01/28 �Ɠc �M�u�@�s��Ή�[10622]</br>
    /// <br>           : </br>
    /// <br>Update Note: 2010/11/15 liyp</br>
    /// <br>           : PM.NS �@�\���ǂp�S</br>
	/// </remarks>
	public class DCZAI02204EA
	{
		#region �� Public Const

        /// <summary> �e�[�u������ </summary>
        public const string ct_Tbl_StockAcPayList = "Tbl_StockAcPayList";

        /// <summary> ���_�R�[�h </summary>
        public const string ct_Col_SectionCode = "SectionCode";
        /// <summary> ���_�K�C�h���� </summary>
        public const string ct_Col_SectionGuideNm = "SectionGuideNm";
        /// <summary> �q�ɃR�[�h </summary>
        public const string ct_Col_WarehouseCode = "WarehouseCode";
        /// <summary> �q�ɖ��� </summary>
        public const string ct_Col_WarehouseName = "WarehouseName";
        /// <summary> ���i���[�J�[�R�[�h </summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary> ���[�J�[���� </summary>
        public const string ct_Col_MakerName = "MakerName";
        /// <summary> ���i�ԍ� </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> ���i���� </summary>
        public const string ct_Col_GoodsName = "GoodsName";
        /// <summary> ���o�ד� </summary>
        public const string ct_Col_IoGoodsDay = "IoGoodsDay";
        /// <summary> �󕥌��`�[�ԍ� </summary>
        public const string ct_Col_AcPaySlipNum = "AcPaySlipNum";
        /// <summary> �󕥌��s�ԍ� </summary>
        public const string ct_Col_AcPaySlipRowNo = "AcPaySlipRowNo";
        /// <summary> �󕥌��`�[�敪 </summary>
        public const string ct_Col_AcPaySlipCd = "AcPaySlipCd";
        /// <summary> �󕥌�����敪 </summary>
        public const string ct_Col_AcPayTransCd = "AcPayTransCd";
        /// <summary> �󕥐�R�[�h�i����p�j </summary>
        public const string ct_Col_AcPayOtherPartyCd = "AcPayOtherPartyCd";
        /// <summary> �󕥐於�́i����p�j </summary>
        public const string ct_Col_AcPayOtherPartyNm = "AcPayOtherPartyNm";
        /// <summary> ���א� </summary>
        public const string ct_Col_ArrivalCnt = "ArrivalCnt";
        /// <summary> �o�א� </summary>
        public const string ct_Col_ShipmentCnt = "ShipmentCnt";
        /// <summary> �艿�i�Ŕ��C�����j </summary>
        public const string ct_Col_ListPriceTaxExcFl = "ListPriceTaxExcFl";
        /// <summary> �d���P���i�Ŕ��C�����j </summary>
        public const string ct_Col_StockUnitPriceFl = "StockUnitPriceFl";
        /// <summary> �󕥌��`�[�敪 </summary>
        public const string ct_Col_AcPaySlipNm = "AcPaySlipNm";
        /// <summary> �󕥌�����敪 </summary>
        public const string ct_Col_AcPayTransNm = "AcPayTransNm";

        //--- ADD 2008/12/15 ------------------------------------------>>>>>
        /// <summary> ���ɋ��z </summary>
        public const string ct_Col_StockPrice = "StockPrice";
        /// <summary> �o�ɋ��z </summary>
        public const string ct_Col_SalesMoney = "SalesMoney";
        //--- ADD 2008/12/15 ------------------------------------------<<<<<
        //--- ADD 2009/01/08 ------------------------------------------>>>>>
        /// <summary> ����P���i�Ŕ��C�����j </summary>
        public const string ct_Col_SalesUnPrcTaxExcFl = "SalesUnPrcTaxExcFl";
        //--- ADD 2009/01/08 ------------------------------------------<<<<<
        //--- ADD 2009/01/28 �s��Ή�[10622] ------------------------>>>>>
        /// <summary> �󕥗����쐬���� </summary>
        public const string ct_Col_AcPayHistDateTime = "AcPayHistDateTime";
        //--- ADD 2009/01/08 �s��Ή�[10622] ------------------------<<<<<

        //--- ADD 2010/11/15 ------------------------------------------>>>>>
        /// <summary> �O�����c </summary>
        public const string ct_Col_StockTotal = "StockTotal";

        /// <summary> ���[�J�[�Ə��i�ԍ� </summary>
        public const string ct_Col_GoodsNoMaker = "GoodsNoMaker";

        /// <summary> �I�� </summary>
        public const string ct_Col_ShelfNo = "ShelfNo";

        /// <summary> �󕥗����쐬���� </summary>
        public const string ct_Col_AcPayHistDateTimeView = "AcPayHistDateTimeView";

        /// <summary> ) </summary>
        public const string ct_Col_Bracker = "Bracker";
        /// <summary> ) </summary>
        public const string ct_Col_BrackerPrice = "BrackerPrice";
        //--- ADD 2010/11/15 ------------------------------------------<<<<<
        #endregion �� Public Const

		#region �� Constructor
		/// <summary>
		/// �݌Ɏ󕥊m�F�\�e�[�u���X�L�[�}��`�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �݌Ɏ󕥊m�F�\�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���B</br>
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		public DCZAI02204EA()
		{
		}
		#endregion

		#region �� Static Public Method
		#region �� �݌ɁE�q�Ɉړ�DataSet�e�[�u���X�L�[�}�ݒ�
		/// <summary>
		/// �݌ɁE�q�Ɉړ�DataSet�e�[�u���X�L�[�}�ݒ�
		/// </summary>
		/// <param name="dt">�ݒ�Ώۃf�[�^�e�[�u��</param>
		/// <remarks>
		/// <br>Note       : �݌ɁE�q�Ɉړ��f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.09.19</br>
		/// <br>Update Note: 2010/11/15 liyp</br>
        /// <br>           : PM.NS �@�\���ǂp�S</br>
		/// </remarks>
		static public void CreateDataTable(ref DataTable dt)
		{
			// �e�[�u�������݂��邩�ǂ����̃`�F�b�N
			if ( dt != null )
			{
				// �e�[�u�������݂���Ƃ��̓N���A�[����̂݁B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
				dt.Clear();
			}
			else
			{
                // �X�L�[�}�ݒ�
                dt = new DataTable( ct_Tbl_StockAcPayList );

                // �f�t�H���g�l
                string defaultValueOfstring = string.Empty;
                Int32 defaultValueOfInt32 = 0;
                Int64 defaultValueOfInt64 = 0;
                double defaultValueOfDouble = 0;
                DateTime defaultValueOfDateTime = DateTime.MinValue;

                # region <Column�ǉ�>

                // ���_�R�[�h
                dt.Columns.Add( ct_Col_SectionCode, typeof( string ) );
                dt.Columns[ct_Col_SectionCode].DefaultValue = defaultValueOfstring;

                // ���_�K�C�h����
                dt.Columns.Add( ct_Col_SectionGuideNm, typeof( string ) );
                dt.Columns[ct_Col_SectionGuideNm].DefaultValue = defaultValueOfstring;

                // �q�ɃR�[�h
                dt.Columns.Add( ct_Col_WarehouseCode, typeof( string ) );
                dt.Columns[ct_Col_WarehouseCode].DefaultValue = defaultValueOfstring;

                // �q�ɖ���
                dt.Columns.Add( ct_Col_WarehouseName, typeof( string ) );
                dt.Columns[ct_Col_WarehouseName].DefaultValue = defaultValueOfstring;

                // ���i���[�J�[�R�[�h
                dt.Columns.Add( ct_Col_GoodsMakerCd, typeof( Int32 ) );
                dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = defaultValueOfInt32;

                // ���[�J�[����
                dt.Columns.Add( ct_Col_MakerName, typeof( string ) );
                dt.Columns[ct_Col_MakerName].DefaultValue = defaultValueOfstring;

                // ���i�ԍ�
                dt.Columns.Add( ct_Col_GoodsNo, typeof( string ) );
                dt.Columns[ct_Col_GoodsNo].DefaultValue = defaultValueOfstring;

                // ���i����
                dt.Columns.Add( ct_Col_GoodsName, typeof( string ) );
                dt.Columns[ct_Col_GoodsName].DefaultValue = defaultValueOfstring;

                // ���o�ד�
                dt.Columns.Add( ct_Col_IoGoodsDay, typeof( string ) );
                dt.Columns[ct_Col_IoGoodsDay].DefaultValue = defaultValueOfstring;

                // �󕥌��`�[�ԍ�
                dt.Columns.Add( ct_Col_AcPaySlipNum, typeof( string ) );
                dt.Columns[ct_Col_AcPaySlipNum].DefaultValue = defaultValueOfstring;

                // �󕥌��s�ԍ�
                dt.Columns.Add( ct_Col_AcPaySlipRowNo, typeof( Int32 ) );
                dt.Columns[ct_Col_AcPaySlipRowNo].DefaultValue = defaultValueOfInt32;

                // �󕥌��`�[�敪
                dt.Columns.Add( ct_Col_AcPaySlipCd, typeof( Int32 ) );
                dt.Columns[ct_Col_AcPaySlipCd].DefaultValue = defaultValueOfInt32;

                // �󕥌�����敪
                dt.Columns.Add( ct_Col_AcPayTransCd, typeof( Int32 ) );
                dt.Columns[ct_Col_AcPayTransCd].DefaultValue = defaultValueOfInt32;

                // �󕥐�R�[�h�i����p�j
                dt.Columns.Add( ct_Col_AcPayOtherPartyCd, typeof( string ) );
                dt.Columns[ct_Col_AcPayOtherPartyCd].DefaultValue = defaultValueOfstring;

                // �󕥐於�́i����p�j
                dt.Columns.Add( ct_Col_AcPayOtherPartyNm, typeof( string ) );
                dt.Columns[ct_Col_AcPayOtherPartyNm].DefaultValue = defaultValueOfstring;

                // ���א�
                //dt.Columns.Add( ct_Col_ArrivalCnt, typeof( Double ) );//DEL 2010/11/15
                dt.Columns.Add( ct_Col_ArrivalCnt, typeof( string ) );//ADD 2010/11/15
                //dt.Columns[ct_Col_ArrivalCnt].DefaultValue = defaultValueOfDouble;//DEL 2010/11/15
				dt.Columns[ct_Col_ArrivalCnt].DefaultValue = defaultValueOfstring;//ADD 2010/11/15
                // �o�א�
                //dt.Columns.Add( ct_Col_ShipmentCnt, typeof( Double ) );//DEL 2010/11/15
                dt.Columns.Add( ct_Col_ShipmentCnt, typeof( string ) );//ADD 2010/11/15
                //dt.Columns[ct_Col_ShipmentCnt].DefaultValue = defaultValueOfDouble;//DEL 2010/11/15
                dt.Columns[ct_Col_ShipmentCnt].DefaultValue = defaultValueOfstring;//ADD 2010/11/15

                // �艿�i�Ŕ��C�����j
                dt.Columns.Add( ct_Col_ListPriceTaxExcFl, typeof( Double ) );
                dt.Columns[ct_Col_ListPriceTaxExcFl].DefaultValue = defaultValueOfDouble;

                // �d���P���i�Ŕ��C�����j
                dt.Columns.Add( ct_Col_StockUnitPriceFl, typeof( Double ) );
                dt.Columns[ct_Col_StockUnitPriceFl].DefaultValue = defaultValueOfDouble;

                // �󕥌��`�[�敪
                dt.Columns.Add( ct_Col_AcPaySlipNm, typeof( string ) );
                dt.Columns[ct_Col_AcPaySlipNm].DefaultValue = defaultValueOfstring;

                // �󕥌�����敪
                dt.Columns.Add( ct_Col_AcPayTransNm, typeof( string ) );
                dt.Columns[ct_Col_AcPayTransNm].DefaultValue = defaultValueOfstring;

                //--- ADD 2008/12/15 ------------------------------------------>>>>>
                //--- ADD 2010/11/15 ------------------------------------------>>>>>
                // ���ɋ��z
                //dt.Columns.Add( ct_Col_StockPrice, typeof( Int64 ) );
                //dt.Columns[ct_Col_StockPrice].DefaultValue = defaultValueOfInt64;
                dt.Columns.Add(ct_Col_StockPrice, typeof(string));
                dt.Columns[ct_Col_StockPrice].DefaultValue = defaultValueOfstring;
                // �o�ɋ��z
                //dt.Columns.Add( ct_Col_SalesMoney, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesMoney].DefaultValue = defaultValueOfInt64;
                dt.Columns.Add(ct_Col_SalesMoney, typeof(string));
                dt.Columns[ct_Col_SalesMoney].DefaultValue = defaultValueOfstring;
                //--- ADD 2010/11/15 ------------------------------------------<<<<<
                //--- ADD 2008/12/15 ------------------------------------------<<<<<

                //--- ADD 2009/01/08 ------------------------------------------>>>>>
                // ����P���i�Ŕ��C�����j
                dt.Columns.Add(ct_Col_SalesUnPrcTaxExcFl, typeof( Double ));
                dt.Columns[ct_Col_SalesUnPrcTaxExcFl].DefaultValue = defaultValueOfDouble;
                //--- ADD 2009/01/08 ------------------------------------------<<<<<

                //--- ADD 2009/01/28 �s��Ή�[10622] ------------------------>>>>>
                // ����P���i�Ŕ��C�����j
                dt.Columns.Add(ct_Col_AcPayHistDateTime, typeof(DateTime));
                dt.Columns[ct_Col_AcPayHistDateTime].DefaultValue = defaultValueOfDateTime;
                //--- ADD 2009/01/28 �s��Ή�[10622] ------------------------<<<<<

                //--- ADD 2010/11/15 ------------------------------------------>>>>>
                /// <summary> �O�����c </summary>
                dt.Columns.Add(ct_Col_StockTotal, typeof(Int64));
                dt.Columns[ct_Col_StockTotal].DefaultValue = defaultValueOfInt64;

                /// <summary> ���[�J�[�Ə��i�ԍ� </summary>
                dt.Columns.Add(ct_Col_GoodsNoMaker, typeof(string));
                dt.Columns[ct_Col_GoodsNoMaker].DefaultValue = defaultValueOfstring;

                /// <summary> �I�� </summary>
                dt.Columns.Add(ct_Col_ShelfNo, typeof(string));
                dt.Columns[ct_Col_ShelfNo].DefaultValue = defaultValueOfstring;

                /// <summary> �󕥗����쐬���� </summary>
                dt.Columns.Add(ct_Col_AcPayHistDateTimeView, typeof(string));
                dt.Columns[ct_Col_AcPayHistDateTimeView].DefaultValue = defaultValueOfstring;
                
                /// <summary> ) </summary>
                dt.Columns.Add(ct_Col_Bracker, typeof(string));
                dt.Columns[ct_Col_Bracker].DefaultValue = defaultValueOfstring;

                /// <summary> ) </summary>
                dt.Columns.Add(ct_Col_BrackerPrice, typeof(string));
                dt.Columns[ct_Col_BrackerPrice].DefaultValue = defaultValueOfstring;
                //--- ADD 2010/11/15 ------------------------------------------<<<<<
                # endregion
            }
		}
		#endregion
		#endregion
	}
}

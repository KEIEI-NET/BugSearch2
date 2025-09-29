using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �݌Ɏ󕥏Ɖ�e�[�u���X�L�[�}��`�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌Ɏ󕥏Ɖ�e�[�u���X�L�[�}�N���X�̒�`�E�������y�уC���X�^���X�������s���B</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2007.12.03</br>
    /// <br></br>
    /// <br>Update Note: 2008/07/17 �Ɠc �M�u</br>
    /// <br>             PM.NS�p�ɕύX�B</br>
    /// <br>Update Note: 2008/09/29 �Ɠc �M�u</br>
    /// <br>             �d�l�ύX�Ή��B</br>
    /// <br>           : 2008/12/09 �Ɠc �M�u</br>
    /// <br>             �o�O�C���A�d�l�ύX�Ή�</br>
    /// <br>           : 2010/11/15 �����</br>
    /// <br>             ���ׂ̕\�������󕥍쐬�����̏����ɂȂ��Ă��Ȃ���Q�̏C��</br>
    /// <br>           : </br>
    /// </remarks>
    public class MAZAI04311EC
    {
        #region �� Public Const

        /// <summary> �e�[�u������ </summary>
        public const string ct_Tbl_StockAcPayRef = "Tbl_StockAcPayRef";

        /// <summary> �s�ԍ� </summary>
        public const string ct_Col_RowNo = "RowNo";
        /// <summary> ���o�ד� </summary>
        public const string ct_Col_IoGoodsDay = "IoGoodsDay";
        /// <summary> �󕥌��`�[�敪 </summary>
        public const string ct_Col_AcPaySlipCd = "AcPaySlipCd";
        /// <summary> �󕥌��`�[�ԍ� </summary>
        public const string ct_Col_AcPaySlipNum = "AcPaySlipNum";
        /// <summary> �󕥌��s�ԍ� </summary>
        public const string ct_Col_AcPaySlipRowNo = "AcPaySlipRowNo";
        /// <summary> �󕥗����쐬���� </summary>
        public const string ct_Col_AcPayHistDateTime = "AcPayHistDateTime";
        /// <summary> �󕥌�����敪 </summary>
        public const string ct_Col_AcPayTransCd = "AcPayTransCd";
        /// <summary> ���͒S���҃R�[�h </summary>
        public const string ct_Col_InputAgenCd = "InputAgenCd";
        /// <summary> ���͒S���Җ��� </summary>
        public const string ct_Col_InputAgenNm = "InputAgenNm";
        /// <summary> �����`�[�ԍ� </summary>
        public const string ct_Col_CustSlipNo = "CustSlipNo";
        /// <summary> ���גʔ� </summary>
        public const string ct_Col_SlipDtlNum = "SlipDtlNum";
        /// <summary> �󕥔��l </summary>
        public const string ct_Col_AcPayNote = "AcPayNote";
        /// <summary> ���_�R�[�h </summary>
        public const string ct_Col_SectionCode = "SectionCode";
        /// <summary> ���_�K�C�h���� </summary>
        public const string ct_Col_SectionGuideNm = "SectionGuideNm";
        /// <summary> �q�ɃR�[�h </summary>
        public const string ct_Col_WarehouseCode = "WarehouseCode";
        /// <summary> �q�ɖ��� </summary>
        public const string ct_Col_WarehouseName = "WarehouseName";
        /// <summary> �I�� </summary>
        public const string ct_Col_ShelfNo = "ShelfNo";
        /// <summary> ���א� </summary>
        public const string ct_Col_ArrivalCnt = "ArrivalCnt";
        /// <summary> �o�א� </summary>
        public const string ct_Col_ShipmentCnt = "ShipmentCnt";
        /// <summary> �艿�i�Ŕ��C�����j </summary>
        public const string ct_Col_ListPriceTaxExcFl = "ListPriceTaxExcFl";
        /// <summary> �d���P���i�Ŕ��C�����j </summary>
        public const string ct_Col_StockUnitPriceFl = "StockUnitPriceFl";
        /// <summary> �d�����z </summary>
        public const string ct_Col_StockPrice = "StockPrice";
        /// <summary> �d���݌ɐ� </summary>
        public const string ct_Col_SupplierStock = "SupplierStock";
        /// <summary> �󒍐� </summary>
        public const string ct_Col_AcpOdrCount = "AcpOdrCount";
        /// <summary> ������ </summary>
        public const string ct_Col_SalesOrderCount = "SalesOrderCount";
        /// <summary> �ړ����d���݌ɐ� </summary>
        public const string ct_Col_MovingSupliStock = "MovingSupliStock";
        /// <summary> �o�א��i���v��j </summary>
        public const string ct_Col_NonAddUpShipmCnt = "NonAddUpShipmCnt";
        /// <summary> ���א��i���v��j </summary>
        public const string ct_Col_NonAddUpArrGdsCnt = "NonAddUpArrGdsCnt";
        /// <summary> �o�׉\�� </summary>
        public const string ct_Col_ShipmentPosCnt = "ShipmentPosCnt";
        /// <summary> �󕥐於�� </summary>
        public const string ct_Col_AcPayOtherPartyNm = "AcPayOtherPartyNm";
        /// <summary> �󕥌��`�[�敪���� </summary>
        public const string ct_Col_AcPaySlipNm = "AcPaySlipNm";
        /// <summary> �󕥌�����敪���� </summary>
        public const string ct_Col_AcPayTransNm = "AcPayTransNm";
        /// <summary> ���ɋ��z </summary>
        public const string ct_Col_ArrivalPrice = "ArrivalPrice";
        /// <summary> �o�ɋ��z </summary>
        public const string ct_Col_ShipmentPrice = "ShipmentPrice";
        /// <summary> �J�z�� </summary>
        public const string ct_Col_CarryForwardCnt = "CarryForwardCnt";         // ADD 2008/07/17 T.Shouda
        /// <summary> ����P���i�Ŕ��C�����j </summary>
        public const string ct_Col_SalesUnPrcTaxExcFl = "SalesUnPrcTaxExcFl";   // ADD 2008/09/29 T.Shouda
        /// <summary> �i�� </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";                         // ADD 2008/12/09 �s��Ή�[8895]
        #endregion �� Public Const

        #region �� Constructor
        /// <summary>
        /// �݌Ɏ󕥏Ɖ�e�[�u���X�L�[�}��`�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �݌Ɏ󕥏Ɖ�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.12.03</br>
        /// </remarks>
        public MAZAI04311EC ()
        {
        }
        #endregion

        #region �� Static Public Method
        #region �� �e�[�u���X�L�[�}�ݒ�
        /// <summary>
        /// DataSet�e�[�u���X�L�[�}�ݒ�
        /// </summary>
        /// <param name="dt">�ݒ�Ώۃf�[�^�e�[�u��</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.12.03</br>
        /// </remarks>
        static public void CreateDataTable ( ref DataTable dt )
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
                dt = new DataTable( ct_Tbl_StockAcPayRef );

                // �f�t�H���g�l
                string defaultValueOfstring = string.Empty;
                Int32 defaultValueOfInt32 = 0;
                Int64 defaultValueOfInt64 = 0;
                double defaultValueOfDouble = 0;
                DateTime defaultValueOfDateTime = DateTime.MinValue;

                # region <Column�ǉ�>

                // �s�ԍ�
                dt.Columns.Add( ct_Col_RowNo, typeof( Int32 ) );
                dt.Columns[ct_Col_RowNo].DefaultValue = defaultValueOfInt32;

                // ���o�ד�
                dt.Columns.Add( ct_Col_IoGoodsDay, typeof( DateTime ) );
                dt.Columns[ct_Col_IoGoodsDay].DefaultValue = defaultValueOfDateTime;

                // �󕥌��`�[�敪
                dt.Columns.Add( ct_Col_AcPaySlipCd, typeof( Int32 ) );
                dt.Columns[ct_Col_AcPaySlipCd].DefaultValue = defaultValueOfInt32;

                // �󕥌��`�[�ԍ�
                dt.Columns.Add( ct_Col_AcPaySlipNum, typeof( string ) );
                dt.Columns[ct_Col_AcPaySlipNum].DefaultValue = defaultValueOfstring;

                // �󕥌��s�ԍ�
                dt.Columns.Add( ct_Col_AcPaySlipRowNo, typeof( Int32 ) );
                dt.Columns[ct_Col_AcPaySlipRowNo].DefaultValue = defaultValueOfInt32;

                // �󕥗����쐬����
                // --- UPD 2010/11/15 ---------->>>>>
                //dt.Columns.Add( ct_Col_AcPayHistDateTime, typeof( string ) );
                //dt.Columns[ct_Col_AcPayHistDateTime].DefaultValue = defaultValueOfstring;
                dt.Columns.Add(ct_Col_AcPayHistDateTime, typeof(DateTime));
                dt.Columns[ct_Col_AcPayHistDateTime].DefaultValue = defaultValueOfDateTime;
                // --- UPD 2010/11/15  ----------<<<<<

                // �󕥌�����敪
                dt.Columns.Add( ct_Col_AcPayTransCd, typeof( Int32 ) );
                dt.Columns[ct_Col_AcPayTransCd].DefaultValue = defaultValueOfInt32;

                // ���͒S���҃R�[�h
                dt.Columns.Add( ct_Col_InputAgenCd, typeof( string ) );
                dt.Columns[ct_Col_InputAgenCd].DefaultValue = defaultValueOfstring;

                // ���͒S���Җ���
                dt.Columns.Add( ct_Col_InputAgenNm, typeof( string ) );
                dt.Columns[ct_Col_InputAgenNm].DefaultValue = defaultValueOfstring;

                // �����`�[�ԍ�
                dt.Columns.Add( ct_Col_CustSlipNo, typeof( string ) );
                dt.Columns[ct_Col_CustSlipNo].DefaultValue = defaultValueOfstring;

                // ���גʔ�
                dt.Columns.Add( ct_Col_SlipDtlNum, typeof( Int64 ) );
                dt.Columns[ct_Col_SlipDtlNum].DefaultValue = defaultValueOfInt64;

                // �󕥔��l
                dt.Columns.Add( ct_Col_AcPayNote, typeof( string ) );
                dt.Columns[ct_Col_AcPayNote].DefaultValue = defaultValueOfstring;

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

                // �I��
                dt.Columns.Add( ct_Col_ShelfNo, typeof( string ) );
                dt.Columns[ct_Col_ShelfNo].DefaultValue = defaultValueOfstring;

                /* ---DEL 2008/09/29 �d�l�ύX --------------------------------------->>>>>
                // ���א�
                dt.Columns.Add( ct_Col_ArrivalCnt, typeof( Double ) );
                dt.Columns[ct_Col_ArrivalCnt].DefaultValue = defaultValueOfDouble;

                // �o�א�
                dt.Columns.Add( ct_Col_ShipmentCnt, typeof( Double ) );
                dt.Columns[ct_Col_ShipmentCnt].DefaultValue = defaultValueOfDouble;
                   ---DEL 2008/09/29 ------------------------------------------------<<<<< */
                // ---ADD 2008/09/29 ------------------------------------------------>>>>>
                // ���א�
                dt.Columns.Add(ct_Col_ArrivalCnt, typeof(string));
                dt.Columns[ct_Col_ArrivalCnt].DefaultValue = defaultValueOfstring;

                // �o�א�
                dt.Columns.Add(ct_Col_ShipmentCnt, typeof(string));
                dt.Columns[ct_Col_ShipmentCnt].DefaultValue = defaultValueOfstring;
                // ---ADD 2008/09/29 ------------------------------------------------<<<<<

                // �艿�i�Ŕ��C�����j
                dt.Columns.Add( ct_Col_ListPriceTaxExcFl, typeof( Double ) );
                dt.Columns[ct_Col_ListPriceTaxExcFl].DefaultValue = defaultValueOfDouble;

                // �d���P���i�Ŕ��C�����j
                dt.Columns.Add( ct_Col_StockUnitPriceFl, typeof( Double ) );
                dt.Columns[ct_Col_StockUnitPriceFl].DefaultValue = defaultValueOfDouble;

                // �d�����z
                dt.Columns.Add( ct_Col_StockPrice, typeof( Int64 ) );
                dt.Columns[ct_Col_StockPrice].DefaultValue = defaultValueOfInt64;

                // �d���݌ɐ�
                dt.Columns.Add( ct_Col_SupplierStock, typeof( Double ) );
                dt.Columns[ct_Col_SupplierStock].DefaultValue = defaultValueOfDouble;

                // �󒍐�
                dt.Columns.Add( ct_Col_AcpOdrCount, typeof( Double ) );
                dt.Columns[ct_Col_AcpOdrCount].DefaultValue = defaultValueOfDouble;

                // ������
                dt.Columns.Add( ct_Col_SalesOrderCount, typeof( Double ) );
                dt.Columns[ct_Col_SalesOrderCount].DefaultValue = defaultValueOfDouble;

                // �ړ����d���݌ɐ�
                dt.Columns.Add( ct_Col_MovingSupliStock, typeof( Double ) );
                dt.Columns[ct_Col_MovingSupliStock].DefaultValue = defaultValueOfDouble;

                // �o�א��i���v��j
                dt.Columns.Add( ct_Col_NonAddUpShipmCnt, typeof( Double ) );
                dt.Columns[ct_Col_NonAddUpShipmCnt].DefaultValue = defaultValueOfDouble;

                // ���א��i���v��j
                dt.Columns.Add( ct_Col_NonAddUpArrGdsCnt, typeof( Double ) );
                dt.Columns[ct_Col_NonAddUpArrGdsCnt].DefaultValue = defaultValueOfDouble;

                // �o�׉\��
                dt.Columns.Add( ct_Col_ShipmentPosCnt, typeof( Double ) );
                dt.Columns[ct_Col_ShipmentPosCnt].DefaultValue = defaultValueOfDouble;

                // �󕥐於��
                dt.Columns.Add( ct_Col_AcPayOtherPartyNm, typeof( string ) );
                dt.Columns[ct_Col_AcPayOtherPartyNm].DefaultValue = defaultValueOfstring;

                // �󕥌��`�[�敪����
                dt.Columns.Add( ct_Col_AcPaySlipNm, typeof( string ) );
                dt.Columns[ct_Col_AcPaySlipNm].DefaultValue = defaultValueOfstring;

                // �󕥌�����敪����
                dt.Columns.Add( ct_Col_AcPayTransNm, typeof( string ) );
                dt.Columns[ct_Col_AcPayTransNm].DefaultValue = defaultValueOfstring;

                // ���ɋ��z
                dt.Columns.Add( ct_Col_ArrivalPrice, typeof( string ) );
                dt.Columns[ct_Col_ArrivalPrice].DefaultValue = defaultValueOfstring;

                // �o�ɋ��z
                dt.Columns.Add( ct_Col_ShipmentPrice, typeof( string ) );
                dt.Columns[ct_Col_ShipmentPrice].DefaultValue = defaultValueOfstring;

                // �J�z��
                dt.Columns.Add(ct_Col_CarryForwardCnt, typeof(Double));                         // ADD 2008/07/17 T.Shouda
                dt.Columns[ct_Col_CarryForwardCnt].DefaultValue = defaultValueOfDouble;         // ADD 2008/07/17 T.Shouda

                // ����P���i�Ŕ��C�����j
                dt.Columns.Add(ct_Col_SalesUnPrcTaxExcFl, typeof(Double));                      // ADD 2008/09/29 T.Shouda
                dt.Columns[ct_Col_SalesUnPrcTaxExcFl].DefaultValue = defaultValueOfDouble;      // ADD 2008/09/29 T.Shouda

                // �i��
                dt.Columns.Add(ct_Col_GoodsNo, typeof(string));                                 // ADD 2008/12/09 �s��Ή�[8895]
                dt.Columns[ct_Col_GoodsNo].DefaultValue = defaultValueOfstring;                 // ADD 2008/12/09 �s��Ή�[8895]

                # endregion
            }
        }
        #endregion
        #endregion
    }
}

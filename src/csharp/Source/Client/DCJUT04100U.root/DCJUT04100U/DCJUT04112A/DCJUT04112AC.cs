using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �󒍎c�Ɖ�e�[�u���X�L�[�}��`�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �󒍎c�Ɖ�e�[�u���X�L�[�}�N���X�̒�`�E�������y�уC���X�^���X�������s���B</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2007.09.19</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// <br>           : </br>
    /// </remarks>
    public class DCJUT04102AC
    {
        #region �� Public Const

        /// <summary> �e�[�u������ </summary>
        public const string ct_Tbl_AcptAnOdrRemainRef = "Tbl_AcptAnOdrRemainRef";

        /// <summary> ��ƃR�[�h </summary>
        public const string ct_Col_EnterpriseCode = "EnterpriseCode";
        /// <summary> �󒍓� </summary>
        public const string ct_Col_SalesDate = "SalesDate";
        /// <summary> �`�[�ԍ� </summary>
        public const string ct_Col_SalesSlipNum = "SalesSlipNum";
        /// <summary> �ʎZ�s�ԍ� </summary>
        public const string ct_Col_CommonSeqNo = "CommonSeqNo";
        /// <summary> ���㖾�גʔ� </summary>
        public const string ct_Col_SalesSlipDtlNum = "SalesSlipDtlNum";
        /// <summary> ���Ӑ�R�[�h </summary>
        public const string ct_Col_CustomerCode = "CustomerCode";
        /// <summary> ���Ӑ旪�� </summary>
        public const string ct_Col_CustomerSnm = "CustomerSnm";
        /// <summary> �i�� </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> �i�� </summary>
        public const string ct_Col_GoodsName = "GoodsName";
        /// <summary> ���[�J�[���� </summary>
        public const string ct_Col_MakerName = "MakerName";
        /// <summary> �d���旪�� </summary>
        public const string ct_Col_SupplierSnm = "SupplierSnm";
        /// <summary> �S���� </summary>
        public const string ct_Col_SalesEmployeeNm = "SalesEmployeeNm";
        /// <summary> ���s�� </summary>
        public const string ct_Col_SalesInputNm = "SalesInputNm";
        /// <summary> �󒍎� </summary>
        public const string ct_Col_FrontEmployeeNm = "FrontEmployeeNm";
        /// <summary> �[�i�於�� </summary>
        public const string ct_Col_AddresseeName = "AddresseeName";
        /// <summary> �[�i�於��2 </summary>
        public const string ct_Col_AddresseeName2 = "AddresseeName2";
        /// <summary> �󒍐��� </summary>
        public const string ct_Col_AcceptAnOrderCnt = "AcceptAnOrderCnt";
        /// <summary> �󒍎c�� </summary>
        public const string ct_Col_AcptAnOdrRemainCnt = "AcptAnOdrRemainCnt";
        /// <summary> ����P���i�Ŕ��C�����j </summary>
        public const string ct_Col_SalesUnPrcTaxExcFl = "SalesUnPrcTaxExcFl";
        /// <summary> �����P�� </summary>
        public const string ct_Col_SalesUnitCost = "SalesUnitCost";
        /// <summary> ���ה��l </summary>
        public const string ct_Col_DtlNote = "DtlNote";
        


        /// <summary> �󒍃X�e�[�^�X </summary>
        public const string ct_Col_AcptAnOdrStatus = "AcptAnOdrStatus";
        /// <summary> �󒍔ԍ� </summary>
        public const string ct_Col_AcceptAnOrderNo = "AcceptAnOrderNo";
        ///// <summary> �P�ʖ��� </summary>
        //public const string ct_Col_UnitName = "UnitName";
        ///// <summary> �����敪���� </summary>
        //public const string ct_Col_BargainNm = "BargainNm";
        /// <summary> �����`�[�ԍ��i���ׁj </summary>
        public const string ct_Col_PartySlipNumDtl = "PartySlipNumDtl";
        /// <summary> ��P���i����P���j </summary>
        public const string ct_Col_StdUnPrcSalUnPrc = "StdUnPrcSalUnPrc";
        ///// <summary> �q��[�� </summary>
        //public const string ct_Col_CustomerDeliveryDate = "CustomerDeliveryDate";
        /// <summary> �`�[�����P </summary>
        public const string ct_Col_SlipMemo1 = "SlipMemo1";
        /// <summary> �`�[�����Q </summary>
        public const string ct_Col_SlipMemo2 = "SlipMemo2";
        /// <summary> �`�[�����R </summary>
        public const string ct_Col_SlipMemo3 = "SlipMemo3";
        ///// <summary> �`�[�����S </summary>
        //public const string ct_Col_SlipMemo4 = "SlipMemo4";
        ///// <summary> �`�[�����T </summary>
        //public const string ct_Col_SlipMemo5 = "SlipMemo5";
        ///// <summary> �`�[�����U </summary>
        //public const string ct_Col_SlipMemo6 = "SlipMemo6";
        /// <summary> �Г������P </summary>
        public const string ct_Col_InsideMemo1 = "InsideMemo1";
        /// <summary> �Г������Q </summary>
        public const string ct_Col_InsideMemo2 = "InsideMemo2";
        /// <summary> �Г������R </summary>
        public const string ct_Col_InsideMemo3 = "InsideMemo3";
        ///// <summary> �Г������S </summary>
        //public const string ct_Col_InsideMemo4 = "InsideMemo4";
        ///// <summary> �Г������T </summary>
        //public const string ct_Col_InsideMemo5 = "InsideMemo5";
        ///// <summary> �Г������U </summary>
        //public const string ct_Col_InsideMemo6 = "InsideMemo6";
        ///// <summary> �d���`�� </summary>
        //public const string ct_Col_SupplierFormal = "SupplierFormal";
        ///// <summary> �d�����גʔ� </summary>
        //public const string ct_Col_StockSlipDtlNum = "StockSlipDtlNum";
        ///// <summary> �����ԍ� </summary>
        //public const string ct_Col_OrderNumber = "OrderNumber";
        ///// <summary> ��]�[�� </summary>
        //public const string ct_Col_ExpectDeliveryDate = "ExpectDeliveryDate";
        ///// <summary> �[�i�����\��� </summary>
        //public const string ct_Col_DeliGdsCmpltDueDate = "DeliGdsCmpltDueDate";
        ///// <summary> ���ד� </summary>
        //public const string ct_Col_ArrivalGoodsDay = "ArrivalGoodsDay";
        ///// <summary> �d���� </summary>
        //public const string ct_Col_StockCount = "StockCount";
        ///// <summary> �d���P���i�Ŕ��C�����j </summary>
        //public const string ct_Col_StockUnitPriceFl = "StockUnitPriceFl";
        /// <summary> �s�� </summary>
        public const string ct_Col_RowNoView = "RowNoView";
        // [9095]
        /// <summary> �s�� �\���p </summary>
        public const string ct_Col_RowNoDisplay = "RowNoDisplay";
        // [9095]
        /// <summary> �s�I���t���O </summary>
        public const string ct_Col_SelectRowFlag = "SelectRowFlag";
        ///// <summary> �󒍎c���z </summary>
        //public const string ct_Col_AcptAnOdrRemainPrice = "AcptAnOdrRemainPrice";
        /// <summary> �����}�[�N </summary>
        public const string ct_Col_MemoExistsMark = "MemoExistsMark";
        /// <summary> �����L�t���O </summary>
        public const string ct_Col_MemoExistsFlag = "MemoExistsFlag";
        /// <summary> ������t�i�\���p�j </summary>
        public const string ct_Col_SalesDateView = "SalesDateView";
        ///// <summary> �q��[���i�\���p�j </summary>
        //public const string ct_Col_CustomerDeliveryDateView = "CustomerDeliveryDateView";
        ///// <summary> ��]�[���i�\���p�j </summary>
        //public const string ct_Col_ExpectDeliveryDateView = "ExpectDeliveryDateView";
        ///// <summary> �[�i�����\����i�\���p�j </summary>
        //public const string ct_Col_DeliGdsCmpltDueDateView = "DeliGdsCmpltDueDateView";
        ///// <summary> ���ד��i�\���p�j </summary>
        //public const string ct_Col_ArrivalGoodsDayView = "ArrivalGoodsDayView";

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.12 TOKUNAGA ADD START
        /// <summary> ����`�[�敪�i���ׁj </summary>
        public const string ct_Col_SalesSlipCdDtl = "SalesSlipCdDtl";
        /// <summary> �d����R�[�h </summary>
        public const string ct_Col_SupplierCd = "SupplierCd";
        /// <summary> BL���i�R�[�h </summary>
        public const string ct_Col_BLGoodsCode = "BLGoodsCode";
        /// <summary> �艿�i�Ŕ��A�����j </summary>
        public const string ct_Col_ListPriceTaxExc = "ListPriceTaxExc";
        /// <summary> �󒍋��z�i�v�Z�j </summary>
        public const string ct_Col_SalesPriceTotal = "SalesPriceTotal";
        /// <summary> ����� </summary>
        public const string ct_Col_SalesPriceConsTax = "SalesPriceConsTax";
        /// <summary> �������z </summary>
        public const string ct_Col_SalesTotalCost = "SalesTotalCost";
        /// <summary> �ԗ��Ǘ��R�[�h </summary>
        public const string ct_Col_CarMngCode = "CarMngCode";
        /// <summary> �^���w��ԍ� </summary>
        public const string ct_Col_ModelDesignationNo = "ModelDesignationNo";
        /// <summary> �ޕʔԍ� </summary>
        public const string ct_Col_CategoryNo = "CategoryNo";
        /// <summary> �ޕʌ^�� </summary>
        public const string ct_Col_ModelCategory = "ModelCategory";
        /// <summary> �Ԏ�S�p���� </summary>
        public const string ct_Col_ModelFullName = "ModelFullName";
        /// <summary> �^���i�t���^�j </summary>
        public const string ct_Col_FullModel = "FullModel";
        /// <summary> �q�ɖ� </summary>
        public const string ct_Col_WarehouseName = "WarehouseName";
        /// <summary> ���͓� </summary>
        public const string ct_Col_SearchSlipDate = "SearchSlipDate";
        /// <summary> ���͓�(�\��) </summary>
        public const string ct_Col_SearchSlipDateString = "SearchSlipDateString";
        /// <summary> �o�ד� </summary>
        public const string ct_Col_ShipmentDay = "ShipmentDay";
        /// <summary> �o�ד�(�\��) </summary>
        public const string ct_Col_ShipmentDayString = "ShipmentDayString";
        /// <summary> �v��� </summary>
        public const string ct_Col_AddUpADate = "AddUpADate";
        /// <summary> �v���(�\��) </summary>
        public const string ct_Col_AddUpADateString = "AddUpADateString";
        /// <summary> ���_�� </summary>
        public const string ct_Col_SectionName = "SectionName";
        /// <summary> ������R�[�h </summary>
        public const string ct_Col_ClaimCode = "ClaimCode";
        /// <summary> �����旪�� </summary>
        public const string ct_Col_ClaimSnm = "ClaimSnm";

        /// <summary> �q�ɃR�[�h </summary>
        public const string ct_Col_WarehouseCode = "WarehouseCode";
        /// <summary> �o�א� </summary>
        public const string ct_Col_ShipmentCnt = "ShipmentCnt";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.12 TOKUNAGA ADD END        

        // 2008.12.12 add start [9095]
        /// <summary> ����s�ԍ� </summary>
        public const string ct_Col_SalesRowNo = "SalesRowNo";
        // 2008.12.12 add end [9095]

        // ���s�ҕ\���敪(DCKHN09211E�̋敪�ƍ��킹��K�v����)
        private const int INP_AGT_DISP = 0;         // 0:����
        private const int INP_AGT_NODISP = 1;       // 1:���Ȃ�
        private const int INP_AGT_NESSESALY = 2;    // 2:�K�{

        #endregion �� Public Const

        #region �� Constructor
        /// <summary>
        /// �󒍎c�Ɖ�e�[�u���X�L�[�}��`�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �󒍎c�Ɖ�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        public DCJUT04102AC ()
        {
        }
        #endregion

        #region �� Static Public Method
        #region �� �e�[�u���X�L�[�}�ݒ�
        /// <summary>
        /// �݌ɁE�q�Ɉړ�DataSet�e�[�u���X�L�[�}�ݒ�
        /// </summary>
        /// <param name="dt">�ݒ�Ώۃf�[�^�e�[�u��</param>
        /// <remarks>
        /// <br>Note       : �݌ɁE�q�Ɉړ��f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        /// <param name="inpAgentDispDiv"></param>
        static public void CreateDataTable(ref DataTable dt, int inpAgentDispDiv)
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
                dt = new DataTable( ct_Tbl_AcptAnOdrRemainRef );

                // �f�t�H���g�l
                string defaultValueOfstring = string.Empty;
                Int32 defaultValueOfInt32 = 0;
                Int64 defaultValueOfInt64 = 0;
                double defaultValueOfDouble = 0;
                DateTime defaultValueOfDateTime = DateTime.MinValue;
                bool defaultValueOfBool = false;

                # region <Column�ǉ�>

                // ��ƃR�[�h
                dt.Columns.Add( ct_Col_EnterpriseCode, typeof( string ) );
                dt.Columns[ct_Col_EnterpriseCode].DefaultValue = defaultValueOfstring;

                // �󒍃X�e�[�^�X
                dt.Columns.Add( ct_Col_AcptAnOdrStatus, typeof( Int32 ) );
                dt.Columns[ct_Col_AcptAnOdrStatus].DefaultValue = defaultValueOfInt32;

                // ����`�[�ԍ�
                dt.Columns.Add( ct_Col_SalesSlipNum, typeof( string ) );
                dt.Columns[ct_Col_SalesSlipNum].DefaultValue = defaultValueOfstring;

                // �󒍔ԍ�
                dt.Columns.Add( ct_Col_AcceptAnOrderNo, typeof( Int32 ) );
                dt.Columns[ct_Col_AcceptAnOrderNo].DefaultValue = defaultValueOfInt32;

                // ���ʒʔ�
                dt.Columns.Add( ct_Col_CommonSeqNo, typeof( Int64 ) );
                dt.Columns[ct_Col_CommonSeqNo].DefaultValue = defaultValueOfInt64;

                // ���㖾�גʔ�
                dt.Columns.Add( ct_Col_SalesSlipDtlNum, typeof( Int64 ) );
                dt.Columns[ct_Col_SalesSlipDtlNum].DefaultValue = defaultValueOfInt64;

                // ���Ӑ�R�[�h
                //dt.Columns.Add(ct_Col_CustomerCode, typeof(Int32));
                //dt.Columns[ct_Col_CustomerCode].DefaultValue = defaultValueOfInt32;
                // 0�̎��͋�
                dt.Columns.Add(ct_Col_CustomerCode, typeof(string));
                dt.Columns[ct_Col_CustomerCode].DefaultValue = defaultValueOfstring;

                // ���Ӑ旪��
                dt.Columns.Add( ct_Col_CustomerSnm, typeof( string ) );
                dt.Columns[ct_Col_CustomerSnm].DefaultValue = defaultValueOfstring;

                // �̔��]�ƈ�����
                dt.Columns.Add( ct_Col_SalesEmployeeNm, typeof( string ) );
                dt.Columns[ct_Col_SalesEmployeeNm].DefaultValue = defaultValueOfstring;

                // �[�i�於��
                dt.Columns.Add( ct_Col_AddresseeName, typeof( string ) );
                dt.Columns[ct_Col_AddresseeName].DefaultValue = defaultValueOfstring;

                // �[�i�於��2
                dt.Columns.Add( ct_Col_AddresseeName2, typeof( string ) );
                dt.Columns[ct_Col_AddresseeName2].DefaultValue = defaultValueOfstring;

                // ��t�]�ƈ�����
                dt.Columns.Add( ct_Col_FrontEmployeeNm, typeof( string ) );
                dt.Columns[ct_Col_FrontEmployeeNm].DefaultValue = defaultValueOfstring;

                // ���s�Җ���
                if (inpAgentDispDiv == INP_AGT_DISP)
                {
                    dt.Columns.Add(ct_Col_SalesInputNm, typeof(string));
                    dt.Columns[ct_Col_SalesInputNm].DefaultValue = defaultValueOfstring;
                }

                // ������t
                dt.Columns.Add( ct_Col_SalesDate, typeof( DateTime ) );
                dt.Columns[ct_Col_SalesDate].DefaultValue = defaultValueOfDateTime;

                // ���i�ԍ�
                dt.Columns.Add( ct_Col_GoodsNo, typeof( string ) );
                dt.Columns[ct_Col_GoodsNo].DefaultValue = defaultValueOfstring;

                // ���i����
                dt.Columns.Add( ct_Col_GoodsName, typeof( string ) );
                dt.Columns[ct_Col_GoodsName].DefaultValue = defaultValueOfstring;

                // ���[�J�[����
                dt.Columns.Add( ct_Col_MakerName, typeof( string ) );
                dt.Columns[ct_Col_MakerName].DefaultValue = defaultValueOfstring;

                // �󒍐���
                dt.Columns.Add( ct_Col_AcceptAnOrderCnt, typeof( Double ) );
                dt.Columns[ct_Col_AcceptAnOrderCnt].DefaultValue = defaultValueOfDouble;

                // �󒍎c��
                dt.Columns.Add( ct_Col_AcptAnOdrRemainCnt, typeof( Double ) );
                dt.Columns[ct_Col_AcptAnOdrRemainCnt].DefaultValue = defaultValueOfDouble;

                //// �P�ʖ���
                //dt.Columns.Add( ct_Col_UnitName, typeof( string ) );
                //dt.Columns[ct_Col_UnitName].DefaultValue = defaultValueOfstring;

                // ����P���i�Ŕ��C�����j
                dt.Columns.Add( ct_Col_SalesUnPrcTaxExcFl, typeof( Double ) );
                dt.Columns[ct_Col_SalesUnPrcTaxExcFl].DefaultValue = defaultValueOfDouble;

                //// �����敪����
                //dt.Columns.Add( ct_Col_BargainNm, typeof( string ) );
                //dt.Columns[ct_Col_BargainNm].DefaultValue = defaultValueOfstring;

                // �����`�[�ԍ��i���ׁj
                dt.Columns.Add( ct_Col_PartySlipNumDtl, typeof( string ) );
                dt.Columns[ct_Col_PartySlipNumDtl].DefaultValue = defaultValueOfstring;

                // ��P���i����P���j
                dt.Columns.Add( ct_Col_StdUnPrcSalUnPrc, typeof( Double ) );
                dt.Columns[ct_Col_StdUnPrcSalUnPrc].DefaultValue = defaultValueOfDouble;

                // �����P��
                dt.Columns.Add( ct_Col_SalesUnitCost, typeof( Double ) );
                dt.Columns[ct_Col_SalesUnitCost].DefaultValue = defaultValueOfDouble;

                // �d���旪��
                dt.Columns.Add( ct_Col_SupplierSnm, typeof( string ) );
                dt.Columns[ct_Col_SupplierSnm].DefaultValue = defaultValueOfstring;

                // ���ה��l
                dt.Columns.Add( ct_Col_DtlNote, typeof( string ) );
                dt.Columns[ct_Col_DtlNote].DefaultValue = defaultValueOfstring;

                //// �q��[��
                //dt.Columns.Add( ct_Col_CustomerDeliveryDate, typeof( DateTime ) );
                //dt.Columns[ct_Col_CustomerDeliveryDate].DefaultValue = defaultValueOfDateTime;

                // �`�[�����P
                dt.Columns.Add( ct_Col_SlipMemo1, typeof( string ) );
                dt.Columns[ct_Col_SlipMemo1].DefaultValue = defaultValueOfstring;

                // �`�[�����Q
                dt.Columns.Add( ct_Col_SlipMemo2, typeof( string ) );
                dt.Columns[ct_Col_SlipMemo2].DefaultValue = defaultValueOfstring;

                // �`�[�����R
                dt.Columns.Add( ct_Col_SlipMemo3, typeof( string ) );
                dt.Columns[ct_Col_SlipMemo3].DefaultValue = defaultValueOfstring;

                //// �`�[�����S
                //dt.Columns.Add( ct_Col_SlipMemo4, typeof( string ) );
                //dt.Columns[ct_Col_SlipMemo4].DefaultValue = defaultValueOfstring;

                //// �`�[�����T
                //dt.Columns.Add( ct_Col_SlipMemo5, typeof( string ) );
                //dt.Columns[ct_Col_SlipMemo5].DefaultValue = defaultValueOfstring;

                //// �`�[�����U
                //dt.Columns.Add( ct_Col_SlipMemo6, typeof( string ) );
                //dt.Columns[ct_Col_SlipMemo6].DefaultValue = defaultValueOfstring;

                // �Г������P
                dt.Columns.Add( ct_Col_InsideMemo1, typeof( string ) );
                dt.Columns[ct_Col_InsideMemo1].DefaultValue = defaultValueOfstring;

                // �Г������Q
                dt.Columns.Add( ct_Col_InsideMemo2, typeof( string ) );
                dt.Columns[ct_Col_InsideMemo2].DefaultValue = defaultValueOfstring;

                // �Г������R
                dt.Columns.Add( ct_Col_InsideMemo3, typeof( string ) );
                dt.Columns[ct_Col_InsideMemo3].DefaultValue = defaultValueOfstring;

                //// �Г������S
                //dt.Columns.Add( ct_Col_InsideMemo4, typeof( string ) );
                //dt.Columns[ct_Col_InsideMemo4].DefaultValue = defaultValueOfstring;

                //// �Г������T
                //dt.Columns.Add( ct_Col_InsideMemo5, typeof( string ) );
                //dt.Columns[ct_Col_InsideMemo5].DefaultValue = defaultValueOfstring;

                //// �Г������U
                //dt.Columns.Add( ct_Col_InsideMemo6, typeof( string ) );
                //dt.Columns[ct_Col_InsideMemo6].DefaultValue = defaultValueOfstring;

                //// �d���`��
                //dt.Columns.Add( ct_Col_SupplierFormal, typeof( Int32 ) );
                //dt.Columns[ct_Col_SupplierFormal].DefaultValue = defaultValueOfInt32;

                //// �d�����גʔ�
                //dt.Columns.Add( ct_Col_StockSlipDtlNum, typeof( Int64 ) );
                //dt.Columns[ct_Col_StockSlipDtlNum].DefaultValue = defaultValueOfInt64;

                //// �����ԍ�
                //dt.Columns.Add( ct_Col_OrderNumber, typeof( string ) );
                //dt.Columns[ct_Col_OrderNumber].DefaultValue = defaultValueOfstring;

                //// ��]�[��
                //dt.Columns.Add( ct_Col_ExpectDeliveryDate, typeof( DateTime ) );
                //dt.Columns[ct_Col_ExpectDeliveryDate].DefaultValue = defaultValueOfDateTime;

                //// �[�i�����\���
                //dt.Columns.Add( ct_Col_DeliGdsCmpltDueDate, typeof( DateTime ) );
                //dt.Columns[ct_Col_DeliGdsCmpltDueDate].DefaultValue = defaultValueOfDateTime;

                //// ���ד�
                //dt.Columns.Add( ct_Col_ArrivalGoodsDay, typeof( DateTime ) );
                //dt.Columns[ct_Col_ArrivalGoodsDay].DefaultValue = defaultValueOfDateTime;

                //// �d����
                //dt.Columns.Add( ct_Col_StockCount, typeof( Double ) );
                //dt.Columns[ct_Col_StockCount].DefaultValue = defaultValueOfDouble;

                //// �d���P���i�Ŕ��C�����j
                //dt.Columns.Add( ct_Col_StockUnitPriceFl, typeof( Double ) );
                //dt.Columns[ct_Col_StockUnitPriceFl].DefaultValue = defaultValueOfDouble;

                // �s��
                dt.Columns.Add( ct_Col_RowNoView, typeof( Int32 ) );
                dt.Columns[ct_Col_RowNoView].DefaultValue = defaultValueOfInt32;

                // �s�I���t���O
                dt.Columns.Add( ct_Col_SelectRowFlag, typeof( bool ) );
                dt.Columns[ct_Col_SelectRowFlag].DefaultValue = defaultValueOfBool;

                //// �󒍎c���z
                //dt.Columns.Add( ct_Col_AcptAnOdrRemainPrice, typeof( Int64 ) );
                //dt.Columns[ct_Col_AcptAnOdrRemainPrice].DefaultValue = defaultValueOfInt64;

                // �����}�[�N
                dt.Columns.Add( ct_Col_MemoExistsMark, typeof( string ) );
                dt.Columns[ct_Col_MemoExistsMark].DefaultValue = defaultValueOfstring;

                // �����L�t���O
                dt.Columns.Add( ct_Col_MemoExistsFlag, typeof( bool ) );
                dt.Columns[ct_Col_MemoExistsFlag].DefaultValue = defaultValueOfBool;

                // ������t�i�\���p�j
                dt.Columns.Add( ct_Col_SalesDateView, typeof( string ) );
                dt.Columns[ct_Col_SalesDateView].DefaultValue = defaultValueOfstring;

                //// �q��[���i�\���p�j
                //dt.Columns.Add( ct_Col_CustomerDeliveryDateView, typeof( string ) );
                //dt.Columns[ct_Col_CustomerDeliveryDateView].DefaultValue = defaultValueOfstring;

                //// ��]�[���i�\���p�j
                //dt.Columns.Add( ct_Col_ExpectDeliveryDateView, typeof( string ) );
                //dt.Columns[ct_Col_ExpectDeliveryDateView].DefaultValue = defaultValueOfstring;

                //// �[�i�����\����i�\���p�j
                //dt.Columns.Add( ct_Col_DeliGdsCmpltDueDateView, typeof( string ) );
                //dt.Columns[ct_Col_DeliGdsCmpltDueDateView].DefaultValue = defaultValueOfstring;

                //// ���ד��i�\���p�j
                //dt.Columns.Add( ct_Col_ArrivalGoodsDayView, typeof( string ) );
                //dt.Columns[ct_Col_ArrivalGoodsDayView].DefaultValue = defaultValueOfstring;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.12 TOKUNAGA ADD START
                // �d����R�[�h
                //dt.Columns.Add(ct_Col_SupplierCd, typeof(Int32));
                //dt.Columns[ct_Col_SupplierCd].DefaultValue = defaultValueOfInt32;
                // 0�̎��͋�
                dt.Columns.Add(ct_Col_SupplierCd, typeof(string));
                dt.Columns[ct_Col_SupplierCd].DefaultValue = defaultValueOfstring;

                // �q�ɃR�[�h
                dt.Columns.Add(ct_Col_WarehouseCode, typeof(string));
                dt.Columns[ct_Col_WarehouseCode].DefaultValue = defaultValueOfstring;

                // �q�ɖ�
                dt.Columns.Add(ct_Col_WarehouseName, typeof(string));
                dt.Columns[ct_Col_WarehouseName].DefaultValue = defaultValueOfstring;

                // ����`�[�敪�i���ׁj
                dt.Columns.Add(ct_Col_SalesSlipCdDtl, typeof(string));
                dt.Columns[ct_Col_SalesSlipCdDtl].DefaultValue = defaultValueOfstring;

                // BL���i�R�[�h
                //dt.Columns.Add(ct_Col_BLGoodsCode, typeof(Int32));
                //dt.Columns[ct_Col_BLGoodsCode].DefaultValue = defaultValueOfInt32;
                // 0�̎��͋�
                dt.Columns.Add(ct_Col_BLGoodsCode, typeof(string));
                dt.Columns[ct_Col_BLGoodsCode].DefaultValue = defaultValueOfstring;

                // �艿�i�Ŕ��A�����j
                dt.Columns.Add(ct_Col_ListPriceTaxExc, typeof(Double));
                dt.Columns[ct_Col_ListPriceTaxExc].DefaultValue = defaultValueOfDouble;

                // ���z
                dt.Columns.Add(ct_Col_SalesPriceTotal, typeof(Double));
                dt.Columns[ct_Col_SalesPriceTotal].DefaultValue = defaultValueOfDouble;

                // �����
                dt.Columns.Add(ct_Col_SalesPriceConsTax, typeof(Double));
                dt.Columns[ct_Col_SalesPriceConsTax].DefaultValue = defaultValueOfDouble;

                // �������v
                dt.Columns.Add(ct_Col_SalesTotalCost, typeof(Double));
                dt.Columns[ct_Col_SalesTotalCost].DefaultValue = defaultValueOfDouble;

                // �o�א�
                dt.Columns.Add(ct_Col_ShipmentCnt, typeof(Double));
                dt.Columns[ct_Col_ShipmentCnt].DefaultValue = defaultValueOfDouble;

                // �ԗ��Ǘ��R�[�h
                dt.Columns.Add(ct_Col_CarMngCode, typeof(string));
                dt.Columns[ct_Col_CarMngCode].DefaultValue = defaultValueOfstring;

                // �^���w��ԍ�
                dt.Columns.Add(ct_Col_ModelDesignationNo, typeof(Int32));
                dt.Columns[ct_Col_ModelDesignationNo].DefaultValue = defaultValueOfInt32;

                // �ޕʔԍ� 
                dt.Columns.Add(ct_Col_CategoryNo, typeof(Int32));
                dt.Columns[ct_Col_CategoryNo].DefaultValue = defaultValueOfInt32;

                // �ޕʌ^��
                dt.Columns.Add(ct_Col_ModelCategory, typeof(string));
                dt.Columns[ct_Col_ModelCategory].DefaultValue = defaultValueOfstring;
                
                // �Ԏ�S�p����
                dt.Columns.Add(ct_Col_ModelFullName, typeof(string));
                dt.Columns[ct_Col_ModelFullName].DefaultValue = defaultValueOfstring;

                // �^���i�t���^�j
                dt.Columns.Add(ct_Col_FullModel, typeof(string));
                dt.Columns[ct_Col_FullModel].DefaultValue = defaultValueOfstring;

                // �`�[�������t
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.10.27 TOKUNAGA MODIFY START
                //dt.Columns.Add(ct_Col_SearchSlipDate, typeof(Int32));
                //dt.Columns[ct_Col_SearchSlipDate].DefaultValue = defaultValueOfInt32;
                dt.Columns.Add(ct_Col_SearchSlipDate, typeof(DateTime));
                dt.Columns[ct_Col_SearchSlipDate].DefaultValue = defaultValueOfDateTime;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.10.27 TOKUNAGA MODIFY END
                // �`�[�������t�i������j
                dt.Columns.Add(ct_Col_SearchSlipDateString, typeof(string));
                dt.Columns[ct_Col_SearchSlipDateString].DefaultValue = defaultValueOfstring;

                // �v����t
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.10.27 TOKUNAGA MODIFY START
                //dt.Columns.Add(ct_Col_AddUpADate, typeof(Int32));
                //dt.Columns[ct_Col_AddUpADate].DefaultValue = defaultValueOfInt32;
                dt.Columns.Add(ct_Col_AddUpADate, typeof(DateTime));
                dt.Columns[ct_Col_AddUpADate].DefaultValue = defaultValueOfDateTime;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.10.27 TOKUNAGA MODIFY END

                // �v����t�i������j
                dt.Columns.Add(ct_Col_AddUpADateString, typeof(string));
                dt.Columns[ct_Col_AddUpADateString].DefaultValue = defaultValueOfstring;

                // �o�ד�
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.10.27 TOKUNAGA MODIFY START
                //dt.Columns.Add(ct_Col_ShipmentDay, typeof(Int32));
                //dt.Columns[ct_Col_ShipmentDay].DefaultValue = defaultValueOfInt32;
                dt.Columns.Add(ct_Col_ShipmentDay, typeof(DateTime));
                dt.Columns[ct_Col_ShipmentDay].DefaultValue = defaultValueOfDateTime;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.10.27 TOKUNAGA MODIFY END

                // �o�ד��i������j
                dt.Columns.Add(ct_Col_ShipmentDayString, typeof(string));
                dt.Columns[ct_Col_ShipmentDayString].DefaultValue = defaultValueOfstring;

                // ���_��
                dt.Columns.Add(ct_Col_SectionName, typeof(string));
                dt.Columns[ct_Col_SectionName].DefaultValue = defaultValueOfstring;

                // ������R�[�h
                //dt.Columns.Add(ct_Col_ClaimCode, typeof(Int32));
                //dt.Columns[ct_Col_ClaimCode].DefaultValue = defaultValueOfInt32;
                // 0�̎��͋�
                dt.Columns.Add(ct_Col_ClaimCode, typeof(string));
                dt.Columns[ct_Col_ClaimCode].DefaultValue = defaultValueOfstring;

                // �����旪��
                dt.Columns.Add(ct_Col_ClaimSnm, typeof(string));
                dt.Columns[ct_Col_ClaimSnm].DefaultValue = defaultValueOfstring;

                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.12 TOKUNAGA ADD END

                // 2008.12.12 add start [9095]
                // ����s�ԍ�
                dt.Columns.Add(ct_Col_SalesRowNo, typeof(Int32));
                dt.Columns[ct_Col_SalesRowNo].DefaultValue = defaultValueOfInt32;
                // 2008.12.12 add end [9095]

                // [9095]
                // �s��(�\���p)
                dt.Columns.Add(ct_Col_RowNoDisplay, typeof(Int32));
                dt.Columns[ct_Col_RowNoDisplay].DefaultValue = defaultValueOfInt32;
                // [9095]

                # endregion
            }
        }
        #endregion
        #endregion
    }
}

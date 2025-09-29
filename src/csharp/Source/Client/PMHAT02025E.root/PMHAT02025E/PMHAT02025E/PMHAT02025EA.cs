//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����_�ݒ�}�X�^���X�g�e�[�u���X�L�[�}��`�N���X
// �v���O�����T�v   : ��`�E�������y�уC���X�^���X�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/04/14  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �����_�ݒ�}�X�^���X�g�e�[�u���X�L�[�}��`�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����_�ݒ�}�X�^���X�g�e�[�u���X�L�[�}��`�N���X�̒�`�E�������y�уC���X�^���X�������s���B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.03.26</br>
    /// </remarks>
    public class PMHAT02025EA
    {
        #region �� Public Const

        /// <summary> �e�[�u������ </summary>
        public const string Tbl_OrderSetMasListReportData = "Tbl_OrderSetMasListReportData";

        /// <summary> ���_�R�[�h </summary>
        public const string Col_SectionCodeRF = "SectionCodeRF";
        /// <summary> ���_���� </summary>
        public const string Col_CompanyName1 = "CompanyName1";
        /// <summary> �폜�敪 </summary>
        public const string Col_DeleteCodeRF = "DeleteCodeRF";
        /// <summary> �ݒ�R�[�h </summary>
        public const string Col_SetCode = "PatterNoRF";
        /// <summary> �p�^�[���ԍ��}�� </summary>
        public const string Col_PatternNoDerivedNoRF = "PatternNoDerivedNoRF";
        /// <summary> �q�ɃR�[�h </summary>
        public const string Col_WarehouseCodeRF = "WarehouseCodeRF";
        /// <summary> �q�ɖ��� </summary>
        public const string Col_WarehouseNameRF = "WarehouseNameRF";
        /// <summary> �d����R�[�h </summary>
        public const string Col_SupplierCdRF = "SupplierCdRF";
        /// <summary> �d���於�� </summary>
        public const string Col_SupplierNameRF = "SupplierSnmRF";
        /// <summary> ���[�J�[�R�[�h </summary>
        public const string Col_GoodsMakerCdRF = "GoodsMakerCdRF";
        /// <summary> ���[�J�[���� </summary>
        public const string Col_GoodsMakerNameRF = "MakerNameRF";
        /// <summary> �����ރR�[�h </summary>
        public const string Col_GoodsMGroupCdRF = "GoodsMGroupRF";
        /// <summary> �����ޖ��� </summary>
        public const string Col_GoodsMGroupNameRF = "GoodsMGroupNameRF";
        /// <summary> BL�O���[�v�R�[�h </summary>
        public const string Col_BLGroupCodeRF = "BLGroupCodeRF";
        /// <summary> BL�O���[�v���� </summary>
        public const string Col_BLGroupNameRF = "BLGroupNameRF";
        /// <summary> BL���i�R�[�h </summary>
        public const string Col_BLGoodsCodeRF = "BLGoodsCodeRF";
        /// <summary> BL���i���� </summary>
        public const string Col_BLGoodsNameRF = "BLGoodsNameRF";
        /// <summary> �݌ɏo�בΏۊJ�n�� </summary>
        public const string Col_StckShipMonthStRF = "StckShipMonthStRF";
        /// <summary> �݌ɏo�בΏۏI���� </summary>
        public const string Col_StckShipMonthEdRF = "StckShipMonthEdRF";
        /// <summary> �݌ɓo�^�� </summary>
        public const string Col_StockCreateDateRF = "StockCreateDateRF";
        /// <summary> �o�א��͈�(�ȏ�) </summary>
        public const string Col_ShipScopeMoreRF = "ShipScopeMoreRF";
        /// <summary> �o�א��͈�(�ȉ�) </summary>
        public const string Col_ShipScopeLessRF = "ShipScopeLessRF";
        /// <summary> �Œ�݌ɐ� </summary>
        public const string Col_MinimumStockCntRF = "MinimumStockCntRF";
        /// <summary> �ō��݌ɐ�</summary>
        public const string Col_MaximumStockCntRF = "MaximumStockCntRF";
        /// <summary> ���b�g��</summary>
        public const string Col_SalesOrderUnitRF = "SalesOrderUnitRF";
        /// <summary> �����_�����X�V�t���O</summary>
        public const string Col_OrderPProcUpdFlgRF = "OrderPProcUpdFlgRF";
        /// <summary> �����K�p�敪</summary>
        public const string Col_OrderApplyDivRF = "OrderApplyDivRF";


        #endregion �� Public Const

        #region �� Constructor
        /// <summary>
        /// �����_�ݒ�}�X�^���X�g ���[�f�[�^�p�e�[�u���X�L�[�}�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����_�ݒ�}�X�^���X�g ���[�f�[�^�p�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        public PMHAT02025EA()
        {
        }
        #endregion

        #region �� Static Public Method
        #region ��  �����_�ݒ�}�X�^���X�gDataSet�e�[�u���X�L�[�}�ݒ�
        /// <summary>
        ///  �����_�ݒ�}�X�^���X�gDataSet�e�[�u���X�L�[�}�ݒ�
        /// </summary>
        /// <param name="ds">�ݒ�Ώۃf�[�^�e�[�u��</param>
        /// <remarks>
        /// <br>Note       : �����_�ݒ�}�X�^���X�g�f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        static public void CreateDataTable(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // �e�[�u�������݂��邩�ǂ����̃`�F�b�N
            if (ds.Tables.Contains(Tbl_OrderSetMasListReportData))
            {
                // �e�[�u�������݂���Ƃ��̓N���A�[����̂݁B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                ds.Tables[Tbl_OrderSetMasListReportData].Clear();
            }
            else
            {
                // �X�L�[�}�ݒ�
                ds.Tables.Add(Tbl_OrderSetMasListReportData);

                DataTable dt = ds.Tables[Tbl_OrderSetMasListReportData];

                dt.Columns.Add(Col_SectionCodeRF, typeof(string));//���_�R�[�h
                dt.Columns[Col_SectionCodeRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_CompanyName1, typeof(string));//���_����
                dt.Columns[Col_CompanyName1].DefaultValue = string.Empty;

                dt.Columns.Add(Col_DeleteCodeRF, typeof(string));//�폜�敪
                dt.Columns[Col_DeleteCodeRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SetCode, typeof(string));//�ݒ�R�[�h
                dt.Columns[Col_SetCode].DefaultValue = string.Empty;

                dt.Columns.Add(Col_PatternNoDerivedNoRF, typeof(string));//�p�^�[���ԍ��}��
                dt.Columns[Col_PatternNoDerivedNoRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_WarehouseCodeRF, typeof(string));//�q�ɃR�[�h
                dt.Columns[Col_WarehouseCodeRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_WarehouseNameRF, typeof(string));//�q�ɖ���
                dt.Columns[Col_WarehouseNameRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SupplierCdRF, typeof(string));//�d����R�[�h
                dt.Columns[Col_SupplierCdRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SupplierNameRF, typeof(string));//�d������
                dt.Columns[Col_SupplierNameRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_GoodsMakerCdRF, typeof(string));//���[�J�[�R�[�h
                dt.Columns[Col_GoodsMakerCdRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_GoodsMakerNameRF, typeof(string));//���[�J�[����
                dt.Columns[Col_GoodsMakerNameRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_GoodsMGroupCdRF, typeof(string));//�����ރR�[�h
                dt.Columns[Col_GoodsMGroupCdRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_GoodsMGroupNameRF, typeof(string));//�����ޖ���
                dt.Columns[Col_GoodsMGroupNameRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_BLGroupCodeRF, typeof(string));// BL�O���[�v�R�[�h
                dt.Columns[Col_BLGroupCodeRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_BLGroupNameRF, typeof(string));// BL�O���[�v����
                dt.Columns[Col_BLGroupNameRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_BLGoodsCodeRF, typeof(string));// BL���i�R�[�h
                dt.Columns[Col_BLGoodsCodeRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_BLGoodsNameRF, typeof(string));// BL���i����
                dt.Columns[Col_BLGoodsNameRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_StckShipMonthStRF, typeof(string));// �݌ɏo�בΏۊJ�n��
                dt.Columns[Col_StckShipMonthStRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_StckShipMonthEdRF, typeof(string));// �݌ɏo�בΏۏI����
                dt.Columns[Col_StckShipMonthEdRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_StockCreateDateRF, typeof(string));// �݌ɓo�^��
                dt.Columns[Col_StockCreateDateRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_ShipScopeMoreRF, typeof(string));// �o�א��͈�(�ȏ�)
                dt.Columns[Col_ShipScopeMoreRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_ShipScopeLessRF, typeof(string));// �o�א��͈�(�ȉ�)
                dt.Columns[Col_ShipScopeLessRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_MinimumStockCntRF, typeof(string));// �Œ�݌ɐ�
                dt.Columns[Col_MinimumStockCntRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_MaximumStockCntRF, typeof(string));// �ō��݌ɐ�
                dt.Columns[Col_MaximumStockCntRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SalesOrderUnitRF, typeof(string));// ���b�g��
                dt.Columns[Col_SalesOrderUnitRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_OrderPProcUpdFlgRF, typeof(string));// �����_�����X�V�t���O
                dt.Columns[Col_OrderPProcUpdFlgRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_OrderApplyDivRF, typeof(string));// �����K�p�敪
                dt.Columns[Col_OrderApplyDivRF].DefaultValue = string.Empty;
                
            }
        }
        #endregion
        #endregion
    }
}


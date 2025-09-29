//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �^���ʏo�בΉ��\
// �v���O�����T�v   : �^���ʏo�בΉ��\���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2010/04/22  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �^���ʏo�בΉ��\ �e�[�u���X�L�[�}���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �^���ʏo�בΉ��\ �e�[�u���X�L�[�}���N���X�̒�`�E�������y�уC���X�^���X�������s���B</br>
    /// <br>Programmer : ���C��</br>
    /// <br>Date       : 2010/04/22</br>
    /// </remarks>
    public class PMSYA02205EA
    {
        #region �� Public Const

        /// <summary> �e�[�u������ </summary>
        public const string Tbl_ModelShipListData = "Tbl_ModelShipListData";
        /// <summary>���ьv�㋒�_�R�[�h</summary>
        public const string ct_Col_ResultsAddUpSecCdRF = "ResultsAddUpSecCdRF";
        /// <summary>���_�K�C�h����</summary>
        public const string ct_Col_SectionGuideSnmRF = "SectionGuideSnmRF";
        /// <summary>���[�J�[�R�[�h</summary>
        public const string ct_Col_MakerCodeRF = "MakerCodeRF";
        /// <summary>�Ԏ�R�[�h</summary>
        public const string ct_Col_ModelCodeRF = "ModelCodeRF";
        /// <summary>�Ԏ�T�u�R�[�h</summary>
        public const string ct_Col_ModelSubCodeRF = "ModelSubCodeRF";
        /// <summary>�Ԏ피�p����</summary>
        public const string ct_Col_ModelHalfNameRF = "ModelHalfNameRF";
        /// <summary>�^���i�t���^�j</summary>
        public const string ct_Col_FullModelRF = "FullModelRF";
        /// <summary>BL���i�R�[�h</summary>
        public const string ct_Col_BLGoodsCodeRF = "BLGoodsCodeRF";
        /// <summary>BL���i�R�[�h���́i���p�j</summary>
        public const string ct_Col_BLGoodsHalfNameRF = "BLGoodsHalfNameRF";
        /// <summary>���i���[�J�[�R�[�h�i�����j</summary>
        public const string ct_Col_GoodsMakerCd1RF = "GoodsMakerCd1RF";
        /// <summary>���i���[�J�[���́i�����j</summary>
        public const string ct_Col_GoodsMakerName1RF = "GoodsMakerName1RF";
        /// <summary>�����i��</summary>
        public const string ct_Col_GoodsNo1RF = "GoodsNo1RF";
        /// <summary>�o�א�</summary>
        public const string ct_Col_ShipmentCntRF = "ShipmentCntRF";
        /// <summary>����P���i�Ŕ��C�����j</summary>
        public const string ct_Col_SalesUnPrcTaxExcFlRF = "SalesUnPrcTaxExcFlRF";
        /// <summary>������z�i�Ŕ����j</summary>
        public const string ct_Col_SalesMoneyTaxExcRF = "SalesMoneyTaxExcRF";
        /// <summary>�q�ɒI��</summary>
        public const string ct_Col_WarehouseShelfNoRF = "WarehouseShelfNoRF";
        /// <summary>�d���݌ɐ�</summary>
        public const string ct_Col_SupplierStockRF = "SupplierStockRF";
        /// <summary>���i���[�J�[�R�[�h�i�D�ǁj</summary>
        public const string ct_Col_GoodsMakerCd2RF = "GoodsMakerCd2RF";
        /// <summary>���i���[�J�[���́i�D�ǁj</summary>
        public const string ct_Col_GoodsMakerName2RF = "GoodsMakerName2RF";
        /// <summary>�Ή��i��</summary>
        public const string ct_Col_GoodsNo2RF = "GoodsNo2RF";
        #endregion �� Public Const

		#region �� Constructor
		/// <summary>
        /// �^���ʏo�בΉ��\ �e�[�u���X�L�[�}���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �^���ʏo�בΉ��\ �e�[�u���X�L�[�}���N���X�̏������y�уC���X�^���X�������s���B</br>
		/// <br>Programmer : ���C��</br>
		/// <br>Date       : 2010/04/22</br>
		/// </remarks>
        public PMSYA02205EA()
		{
		}
		#endregion

        #region �� Static Public Method
        #region �� �f�[�^DataSet�e�[�u���X�L�[�}�ݒ�
        /// <summary>
        /// �f�[�^DataSet�e�[�u���X�L�[�}�ݒ�
		/// </summary>
        /// <param name="ds">�ݒ�Ώۃf�[�^�e�[�u��</param>
		/// <remarks>
		/// <br>Note       : �f�[�^�f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
		/// <br>Programmer : ���C��</br>
        /// <br>Date       : 2010/04/22</br>
		/// </remarks>
        static public void CreateDataTable(ref DataSet ds)
        {
            if (ds == null)
            {
                ds = new DataSet();
            }
            // �e�[�u�������݂��邩�ǂ����̃`�F�b�N
            if (ds.Tables.Contains(Tbl_ModelShipListData))
            {
                // �e�[�u�������݂���Ƃ��̓N���A�[����̂݁B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                ds.Tables[Tbl_ModelShipListData].Clear();
            }
            else
            {
                // �X�L�[�}�ݒ�

                ds.Tables.Add(Tbl_ModelShipListData);

                DataTable dt = ds.Tables[Tbl_ModelShipListData];

                // ���ьv�㋒�_�R�[�h
                dt.Columns.Add(ct_Col_ResultsAddUpSecCdRF, typeof(string));
                dt.Columns[ct_Col_ResultsAddUpSecCdRF].DefaultValue = "";
                // ���_�K�C�h����
                dt.Columns.Add(ct_Col_SectionGuideSnmRF, typeof(string));
                dt.Columns[ct_Col_SectionGuideSnmRF].DefaultValue = "";
                // ���[�J�[�R�[�h
                dt.Columns.Add(ct_Col_MakerCodeRF, typeof(string));
                dt.Columns[ct_Col_MakerCodeRF].DefaultValue = "";
                // �Ԏ�R�[�h
                dt.Columns.Add(ct_Col_ModelCodeRF, typeof(string));
                dt.Columns[ct_Col_ModelCodeRF].DefaultValue = "";
                // �Ԏ�T�u�R�[�h
                dt.Columns.Add(ct_Col_ModelSubCodeRF, typeof(string));
                dt.Columns[ct_Col_ModelSubCodeRF].DefaultValue = "";
                // �Ԏ피�p����
                dt.Columns.Add(ct_Col_ModelHalfNameRF, typeof(string));
                dt.Columns[ct_Col_ModelHalfNameRF].DefaultValue = "";
                // �^���i�t���^�j
                dt.Columns.Add(ct_Col_FullModelRF, typeof(string));
                dt.Columns[ct_Col_FullModelRF].DefaultValue = "";
                // BL���i�R�[�h
                dt.Columns.Add(ct_Col_BLGoodsCodeRF, typeof(string));
                dt.Columns[ct_Col_BLGoodsCodeRF].DefaultValue = "";
                // BL���i�R�[�h���́i���p�j
                dt.Columns.Add(ct_Col_BLGoodsHalfNameRF, typeof(string));
                dt.Columns[ct_Col_BLGoodsHalfNameRF].DefaultValue = "";
                // ���i���[�J�[�R�[�h�i�����j
                dt.Columns.Add(ct_Col_GoodsMakerCd1RF, typeof(string));
                dt.Columns[ct_Col_GoodsMakerCd1RF].DefaultValue = "";
                // ���i���[�J�[���́i�����j
                dt.Columns.Add(ct_Col_GoodsMakerName1RF, typeof(string));
                dt.Columns[ct_Col_GoodsMakerName1RF].DefaultValue = "";
                // �����ԍ�
                dt.Columns.Add(ct_Col_GoodsNo1RF, typeof(string));
                dt.Columns[ct_Col_GoodsNo1RF].DefaultValue = "";
                // �o�א�
                dt.Columns.Add(ct_Col_ShipmentCntRF, typeof(string));
                dt.Columns[ct_Col_ShipmentCntRF].DefaultValue = "";
                // ����P���i�Ŕ��C�����j
                dt.Columns.Add(ct_Col_SalesUnPrcTaxExcFlRF, typeof(string));
                dt.Columns[ct_Col_SalesUnPrcTaxExcFlRF].DefaultValue = "";
                // ������z�i�Ŕ����j
                dt.Columns.Add(ct_Col_SalesMoneyTaxExcRF, typeof(string));
                dt.Columns[ct_Col_SalesMoneyTaxExcRF].DefaultValue = "";
                // �q�ɒI��
                dt.Columns.Add(ct_Col_WarehouseShelfNoRF, typeof(string));
                dt.Columns[ct_Col_WarehouseShelfNoRF].DefaultValue = "";
                // �d���݌ɐ�
                dt.Columns.Add(ct_Col_SupplierStockRF, typeof(string));
                dt.Columns[ct_Col_SupplierStockRF].DefaultValue = "";
                // ���i���[�J�[�R�[�h�i�D�ǁj
                dt.Columns.Add(ct_Col_GoodsMakerCd2RF, typeof(string));
                dt.Columns[ct_Col_GoodsMakerCd2RF].DefaultValue = "";
                // ���i���[�J�[���́i�D�ǁj
                dt.Columns.Add(ct_Col_GoodsMakerName2RF, typeof(string));
                dt.Columns[ct_Col_GoodsMakerName2RF].DefaultValue = "";
                // �Ή��ԍ�
                dt.Columns.Add(ct_Col_GoodsNo2RF, typeof(string));
                dt.Columns[ct_Col_GoodsNo2RF].DefaultValue = "";
            }
        }

        #endregion �� �f�[�^DataSet�e�[�u���X�L�[�}�ݒ�

        #endregion �� Static Public Method

    }
}

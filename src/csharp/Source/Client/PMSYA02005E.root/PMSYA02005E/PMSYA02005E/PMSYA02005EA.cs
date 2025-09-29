//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���q�ʏo�׎��ѕ\
// �v���O�����T�v   : ���q�ʏo�׎��ѕ\���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2009/09/15  �C�����e : �V�K�쐬
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
    /// ���q�ʏo�׎��ѕ\ �e�[�u���X�L�[�}���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���q�ʏo�׎��ѕ\ �e�[�u���X�L�[�}���N���X�̒�`�E�������y�уC���X�^���X�������s���B</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2009.09.15</br>
    /// </remarks>
    public class PMSYA02005EA
    {
        #region �� Public Const

        /// <summary> �e�[�u������ </summary>
        public const string Tbl_CarShipListData = "Tbl_CarShipListData";
        /// <summary>����`�[�ԍ�</summary>
        public const string ct_Col_SalesSlipNumRF = "SalesSlipNumRF";
        /// <summary>���ьv�㋒�_�R�[�h</summary>
        public const string ct_Col_ResultsAddUpSecCdRF = "ResultsAddUpSecCdRF";
        /// <summary>������t</summary>
        public const string ct_Col_SalesDateRF = "SalesDateRF";
        /// <summary>���Ӑ�R�[�h</summary>
        public const string ct_Col_CustomerCodeRF = "CustomerCodeRF";
        /// <summary>���Ӑ旪��</summary>
        public const string ct_Col_CustomerSnmRF = "CustomerSnmRF";
        /// <summary>����s�ԍ�</summary>
        public const string ct_Col_SalesRowNoRF = "SalesRowNoRF";
        /// <summary>���i���[�J�[�R�[�h</summary>
        public const string ct_Col_GoodsMakerCdRF = "GoodsMakerCdRF";
        /// <summary>���i�ԍ�</summary>
        public const string ct_Col_GoodsNoRF = "GoodsNoRF";
        /// <summary>���i���̃J�i</summary>
        public const string ct_Col_GoodsNameKanaRF = "GoodsNameKanaRF";
        /// <summary>BL���i�R�[�h</summary>
        public const string ct_Col_BLGoodsCodeRF = "BLGoodsCodeRF";
        /// <summary>BL���i�R�[�hCopy</summary>
        public const string ct_Col_BLGoodsCodeRFCopy = "BLGoodsCodeRFCopy";
        /// <summary>BL���i�R�[�h���́i���p�j</summary>
        public const string ct_Col_BLGoodsHalfNameRF = "BLGoodsHalfNameRF";
        /// <summary>BL�O���[�v�R�[�h</summary>
        public const string ct_Col_BLGroupCodeRF = "BLGroupCodeRF";
        /// <summary>BL�O���[�v�R�[�hCopy</summary>
        public const string ct_Col_BLGroupCodeRFCopy = "BLGroupCodeRFCopy";
        /// <summary>BL�O���[�v�R�[�h�J�i����</summary>
        public const string ct_Col_BLGroupKanaNameRF = "BLGroupKanaNameRF";
        /// <summary>�艿�i�Ŕ��C�����j</summary>
        public const string ct_Col_ListPriceTaxExcFlRF = "ListPriceTaxExcFlRF";
        /// <summary>����P���i�Ŕ��C�����j</summary>
        public const string ct_Col_SalesUnPrcTaxExcFlRF = "SalesUnPrcTaxExcFlRF";
        /// <summary>�����P��</summary>
        public const string ct_Col_SalesUnitCostRF = "SalesUnitCostRF";
        /// <summary>�o�א�</summary>
        public const string ct_Col_ShipmentCntRF = "ShipmentCntRF";
        /// <summary>�o�א�(�݌�)</summary>
        public const string ct_Col_ShipmentCntInRF = "ShipmentCntInRF";
        /// <summary>�o�א�(���)</summary>
        public const string ct_Col_ShipmentCntNotInRF = "ShipmentCntNotInRF";
        /// <summary>����݌Ɏ�񂹋敪</summary>
        public const string ct_Col_SalesOrderDivCdRF = "SalesOrderDivCdRF";
        /// <summary>������z�i�Ŕ����j</summary>
        public const string ct_Col_SalesMoneyTaxExcRF = "SalesMoneyTaxExcRF";
        /// <summary>���_�K�C�h����</summary>
        public const string ct_Col_SectionGuideSnmRF = "SectionGuideSnmRF";
        /// <summary>�e�����z</summary>
        public const string ct_Col_GrossProfitRF = "GrossProfitRF";
        /// <summary>�e����</summary>
        public const string ct_Col_GrossPivRF = "GrossPivRF";

        /// <summary>�ԗ��Ǘ��ԍ�</summary>
        public const string ct_Col_CarMngNoRF = "CarMngNoRF";
        /// <summary>���q�Ǘ��R�[�h</summary>
        public const string ct_Col_CarMngCodeRF = "CarMngCodeRF";
        /// <summary>���^�����ǖ���</summary>
        public const string ct_Col_NumberPlate1NameRF = "NumberPlate1NameRF";
        /// <summary>�ԗ��o�^�ԍ��i��ʁj</summary>
        public const string ct_Col_NumberPlate2RF = "NumberPlate2RF";
        /// <summary>�ԗ��o�^�ԍ��i�J�i�j</summary>
        public const string ct_Col_NumberPlate3RF = "NumberPlate3RF";
        /// <summary>�ԗ��o�^�ԍ��i�v���[�g�ԍ��j</summary>
        public const string ct_Col_NumberPlate4RF = "NumberPlate4RF";
        /// <summary>���N�x</summary>
        public const string ct_Col_FirstEntryDateRF = "FirstEntryDateRF";
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
        /// <summary>�ԗ����s����</summary>
        public const string ct_Col_MileageRF = "MileageRF";
        /// <summary> LineShow</summary> 
        public const string ct_Col_LineShow = "LineShow";
        #endregion �� Public Const

		#region �� Constructor
		/// <summary>
        /// ���q�ʏo�׎��ѕ\ �e�[�u���X�L�[�}���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���q�ʏo�׎��ѕ\ �e�[�u���X�L�[�}���N���X�̏������y�уC���X�^���X�������s���B</br>
		/// <br>Programmer : ����</br>
		/// <br>Date       : 2009.09.15</br>
		/// </remarks>
        public PMSYA02005EA()
		{
		}
		#endregion

        #region �� Static Public Method
        #region �� �d���f�[�^DataSet�e�[�u���X�L�[�}�ݒ�
        /// <summary>
        /// �d���f�[�^DataSet�e�[�u���X�L�[�}�ݒ�
		/// </summary>
        /// <param name="ds">�ݒ�Ώۃf�[�^�e�[�u��</param>
		/// <remarks>
		/// <br>Note       : �d���f�[�^�f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
		/// <br>Programmer : ����</br>
        /// <br>Date       : 2009.09.15</br>
		/// </remarks>
        static public void CreateDataTable(ref DataSet ds)
        {
            if (ds == null)
            {
                ds = new DataSet();
            }
            // �e�[�u�������݂��邩�ǂ����̃`�F�b�N
            if (ds.Tables.Contains(Tbl_CarShipListData))
            {
                // �e�[�u�������݂���Ƃ��̓N���A�[����̂݁B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                ds.Tables[Tbl_CarShipListData].Clear();
            }
            else
            {
                // �X�L�[�}�ݒ�
                
                ds.Tables.Add(Tbl_CarShipListData);

                DataTable dt = ds.Tables[Tbl_CarShipListData];

                // ����`�[�ԍ�
                dt.Columns.Add(ct_Col_SalesSlipNumRF, typeof(string));
                dt.Columns[ct_Col_SalesSlipNumRF].DefaultValue = "";
                // ���ьv�㋒�_�R�[�h
                dt.Columns.Add(ct_Col_ResultsAddUpSecCdRF, typeof(string));
                dt.Columns[ct_Col_ResultsAddUpSecCdRF].DefaultValue = "";
                // ������t
                dt.Columns.Add(ct_Col_SalesDateRF, typeof(string));
                dt.Columns[ct_Col_SalesDateRF].DefaultValue = "";
                // ���Ӑ�R�[�h
                dt.Columns.Add(ct_Col_CustomerCodeRF, typeof(string));
                dt.Columns[ct_Col_CustomerCodeRF].DefaultValue = "";
                // ���Ӑ旪��
                dt.Columns.Add(ct_Col_CustomerSnmRF, typeof(string));
                dt.Columns[ct_Col_CustomerSnmRF].DefaultValue = "";
                // ����s�ԍ�
                dt.Columns.Add(ct_Col_SalesRowNoRF, typeof(string));
                dt.Columns[ct_Col_SalesRowNoRF].DefaultValue = "";
                // ���i���[�J�[�R�[�h
                dt.Columns.Add(ct_Col_GoodsMakerCdRF, typeof(string));
                dt.Columns[ct_Col_GoodsMakerCdRF].DefaultValue = "";
                // ���i�ԍ�
                dt.Columns.Add(ct_Col_GoodsNoRF, typeof(string));
                dt.Columns[ct_Col_GoodsNoRF].DefaultValue = "";
                // ���i���̃J�i
                dt.Columns.Add(ct_Col_GoodsNameKanaRF, typeof(string));
                dt.Columns[ct_Col_GoodsNameKanaRF].DefaultValue = "";
                // BL���i�R�[�h
                dt.Columns.Add(ct_Col_BLGoodsCodeRF, typeof(string));
                dt.Columns[ct_Col_BLGoodsCodeRF].DefaultValue = "";
                // BL���i�R�[�hCopy
                dt.Columns.Add(ct_Col_BLGoodsCodeRFCopy, typeof(string));
                dt.Columns[ct_Col_BLGoodsCodeRFCopy].DefaultValue = "";
                // BL���i�R�[�h���́i���p�j
                dt.Columns.Add(ct_Col_BLGoodsHalfNameRF, typeof(string));
                dt.Columns[ct_Col_BLGoodsHalfNameRF].DefaultValue = "";
                // BL�O���[�v�R�[�h
                dt.Columns.Add(ct_Col_BLGroupCodeRF, typeof(string));
                dt.Columns[ct_Col_BLGroupCodeRF].DefaultValue = "";
                // BL�O���[�v�R�[�hCopy
                dt.Columns.Add(ct_Col_BLGroupCodeRFCopy, typeof(string));
                dt.Columns[ct_Col_BLGroupCodeRFCopy].DefaultValue = "";
                // BL�O���[�v�R�[�h�J�i����
                dt.Columns.Add(ct_Col_BLGroupKanaNameRF, typeof(string));
                dt.Columns[ct_Col_BLGroupKanaNameRF].DefaultValue = "";
                // �艿�i�Ŕ��C�����j
                dt.Columns.Add(ct_Col_ListPriceTaxExcFlRF, typeof(string));
                dt.Columns[ct_Col_ListPriceTaxExcFlRF].DefaultValue = "";
                // ����P���i�Ŕ��C�����j
                dt.Columns.Add(ct_Col_SalesUnPrcTaxExcFlRF, typeof(string));
                dt.Columns[ct_Col_SalesUnPrcTaxExcFlRF].DefaultValue = "";
                // �����P��
                dt.Columns.Add(ct_Col_SalesUnitCostRF, typeof(string));
                dt.Columns[ct_Col_SalesUnitCostRF].DefaultValue = "";
                // �o�א�
                dt.Columns.Add(ct_Col_ShipmentCntRF, typeof(string));
                dt.Columns[ct_Col_ShipmentCntRF].DefaultValue = "";
                // �o�א�(�݌�)
                dt.Columns.Add(ct_Col_ShipmentCntInRF, typeof(string));
                dt.Columns[ct_Col_ShipmentCntInRF].DefaultValue = "";
                // �o�א�(���)
                dt.Columns.Add(ct_Col_ShipmentCntNotInRF, typeof(string));
                dt.Columns[ct_Col_ShipmentCntNotInRF].DefaultValue = "";
                // ����݌Ɏ�񂹋敪
                dt.Columns.Add(ct_Col_SalesOrderDivCdRF, typeof(string));
                dt.Columns[ct_Col_SalesOrderDivCdRF].DefaultValue = "";
                // ������z�i�Ŕ����j
                dt.Columns.Add(ct_Col_SalesMoneyTaxExcRF, typeof(string));
                dt.Columns[ct_Col_SalesMoneyTaxExcRF].DefaultValue = "";
                // ���_�K�C�h����
                dt.Columns.Add(ct_Col_SectionGuideSnmRF, typeof(string));
                dt.Columns[ct_Col_SectionGuideSnmRF].DefaultValue = "";
                // �e�����z
                dt.Columns.Add(ct_Col_GrossProfitRF, typeof(string));
                dt.Columns[ct_Col_GrossProfitRF].DefaultValue = "";
                // �e����
                dt.Columns.Add(ct_Col_GrossPivRF, typeof(string));
                dt.Columns[ct_Col_GrossPivRF].DefaultValue = "";
                // �ԗ��Ǘ��ԍ�
                dt.Columns.Add(ct_Col_CarMngNoRF, typeof(string));
                dt.Columns[ct_Col_CarMngNoRF].DefaultValue = "";
                // ���q�Ǘ��R�[�h
                dt.Columns.Add(ct_Col_CarMngCodeRF, typeof(string));
                dt.Columns[ct_Col_CarMngCodeRF].DefaultValue = "";
                // ���^�����ǖ���
                dt.Columns.Add(ct_Col_NumberPlate1NameRF, typeof(string));
                dt.Columns[ct_Col_NumberPlate1NameRF].DefaultValue = "";
                // �ԗ��o�^�ԍ��i��ʁj
                dt.Columns.Add(ct_Col_NumberPlate2RF, typeof(string));
                dt.Columns[ct_Col_NumberPlate2RF].DefaultValue = "";
                // �ԗ��o�^�ԍ��i�J�i�j
                dt.Columns.Add(ct_Col_NumberPlate3RF, typeof(string));
                dt.Columns[ct_Col_NumberPlate3RF].DefaultValue = "";
                // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                dt.Columns.Add(ct_Col_NumberPlate4RF, typeof(string));
                dt.Columns[ct_Col_NumberPlate4RF].DefaultValue = "";
                // ���N�x
                dt.Columns.Add(ct_Col_FirstEntryDateRF, typeof(string));
                dt.Columns[ct_Col_FirstEntryDateRF].DefaultValue = "";
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
                // �ԗ����s����
                dt.Columns.Add(ct_Col_MileageRF, typeof(string));
                dt.Columns[ct_Col_MileageRF].DefaultValue = "";
                 // LineShow
                dt.Columns.Add(ct_Col_LineShow, typeof(bool));
                dt.Columns[ct_Col_LineShow].DefaultValue = true;

            }
        }

        #endregion �� �d���f�[�^DataSet�e�[�u���X�L�[�}�ݒ�

        #endregion �� Static Public Method

    }
}

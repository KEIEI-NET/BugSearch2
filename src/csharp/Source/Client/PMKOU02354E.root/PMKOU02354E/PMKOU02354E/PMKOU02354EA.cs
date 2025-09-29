//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���׍��ٕ\�@�e�[�u���X�L�[�}��`�N���X
// �v���O�����T�v   : ��`�E�������y�уC���X�^���X�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570136-00  �쐬�S�� : 杍^
// �� �� ��  K2019/08/14  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//


using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ���׍��ٕ\�@�e�[�u���X�L�[�}��`�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���׍��ٕ\�e�[�u���X�L�[�}�N���X�̒�`�E�������y�уC���X�^���X�������s���B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : K2019/08/14</br>
    /// </remarks>
    public class PMKOU02354EA
    {
        #region �� Public Const

        /// <summary> �e�[�u������ </summary>
        public const string ct_Tbl_ArrGoodsDiffReportData = "Tbl_ArrGoodsDiffReportData";

        /// <summary> ������R�[�h </summary>
        public const string ct_Col_UOESupplierCd = "UOESupplierCd";
        /// <summary> �����於 </summary>
        public const string ct_Col_UOESupplierNm = "UOESupplierNm";
        /// <summary> �`�[�ԍ� </summary>
        public const string ct_Col_SupplierSlipNo = "SupplierSlipNo";
        /// <summary> �i�� </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> �i�� </summary>
        public const string ct_Col_GoodsName = "GoodsName";
        /// <summary> ���[�J�[ </summary>
        public const string ct_Col_MakerName = "MakerName";
        /// <summary> ������ </summary>
        public const string ct_Col_OrderCnt = "OrderCnt";
        /// <summary> �����c </summary>
        public const string ct_Col_OrderRemainCnt = "OrderRemainCnt";
        /// <summary> ���i�� </summary>
        public const string ct_Col_InspectCnt = "InspectCnt";
        /// <summary> ���� </summary>
        public const string ct_Col_DiffCnt = "DiffCnt";
        /// <summary> �q�� </summary>
        public const string ct_Col_WarehouseName = "WarehouseName";
        /// <summary> ������ </summary>
        public const string ct_Col_StockAgentName = "StockAgentName";

        #endregion �� Public Const

        #region �� Constructor
        /// <summary>
        /// ���׍��ٕ\�e�[�u���X�L�[�}��`�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���׍��ٕ\�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        public PMKOU02354EA()
        {
        }
        #endregion

        #region �� Static Public Method
        #region �� ���׍��ٕ\DataSet�e�[�u���X�L�[�}�ݒ�
        /// <summary>
        /// ���׍��ٕ\DataSet�e�[�u���X�L�[�}�ݒ�
        /// </summary>
        /// <param name="ds">�ݒ�Ώۃf�[�^�e�[�u��</param>
        /// <remarks>
        /// <br>Note       : ���׍��ٕ\�f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        static public void CreateDataTable(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // �e�[�u�������݂��邩�ǂ����̃`�F�b�N
            if (ds.Tables.Contains(ct_Tbl_ArrGoodsDiffReportData))
            {
                // �e�[�u�������݂���Ƃ��̓N���A�[����̂݁B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                ds.Tables[ct_Tbl_ArrGoodsDiffReportData].Clear();
            }
            else
            {
                // �X�L�[�}�ݒ�
                ds.Tables.Add(ct_Tbl_ArrGoodsDiffReportData);

                DataTable dt = ds.Tables[ct_Tbl_ArrGoodsDiffReportData];


                // ������R�[�h
                dt.Columns.Add(ct_Col_UOESupplierCd, typeof(string));
                dt.Columns[ct_Col_UOESupplierCd].DefaultValue = string.Empty;

                // �����於
                dt.Columns.Add(ct_Col_UOESupplierNm, typeof(string));
                dt.Columns[ct_Col_UOESupplierNm].DefaultValue = string.Empty;

                // �`�[�ԍ�
                dt.Columns.Add(ct_Col_SupplierSlipNo, typeof(string));
                dt.Columns[ct_Col_SupplierSlipNo].DefaultValue = string.Empty;

                // �i��
                dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
                dt.Columns[ct_Col_GoodsNo].DefaultValue = string.Empty;

                // �i��
                dt.Columns.Add(ct_Col_GoodsName, typeof(string));
                dt.Columns[ct_Col_GoodsName].DefaultValue = string.Empty;

                // ���[�J�[
                dt.Columns.Add(ct_Col_MakerName, typeof(string));
                dt.Columns[ct_Col_MakerName].DefaultValue = string.Empty;

                // ������
                dt.Columns.Add(ct_Col_OrderCnt, typeof(Double));
                dt.Columns[ct_Col_OrderCnt].DefaultValue = 0.0;

                // �����c
                dt.Columns.Add(ct_Col_OrderRemainCnt, typeof(Double));
                dt.Columns[ct_Col_OrderRemainCnt].DefaultValue = 0.0;

                // ���i��
                dt.Columns.Add(ct_Col_InspectCnt, typeof(Double));
                dt.Columns[ct_Col_InspectCnt].DefaultValue = 0.0;

                // ����
                dt.Columns.Add(ct_Col_DiffCnt, typeof(Double));
                dt.Columns[ct_Col_DiffCnt].DefaultValue = 0.0;

                // �q��
                dt.Columns.Add(ct_Col_WarehouseName, typeof(string));
                dt.Columns[ct_Col_WarehouseName].DefaultValue = string.Empty;

                // ������
                dt.Columns.Add(ct_Col_StockAgentName, typeof(string));
                dt.Columns[ct_Col_StockAgentName].DefaultValue = string.Empty;

            }
        }
        #endregion �� ���׍��ٕ\DataSet�e�[�u���X�L�[�}�ݒ�
        #endregion �� Static Public Method
    }
}
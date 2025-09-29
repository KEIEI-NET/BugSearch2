using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �o�׏��i�D�ǑΉ��\2 ���[�󎚗p�f�[�^�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �o�׏��i�D�ǑΉ��\2�̒��[�󎚗p�̂P�s�f�[�^��ێ�����B</br>
    /// <br>Programmer : 30452 ��� �r��</br>
    /// <br>Date       : 2008.11.25</br>
    /// <br>           : </br>
    /// </remarks>
    public class PMHNB02155EB
    {
        #region �� Public�萔
        // �e�[�u������
        public const string ct_Tbl_ShipGdsPrimeListResultForPrint = "ShipGdsPrimeListResultForPrint";
        // ���_�R�[�h
        public const string ct_Col_AddUpSecCode = "AddUpSecCode";
        // ���_����
        public const string ct_Col_SectionGuideSnm = "SectionGuideSnm";

        // --�\�[�g�p--
        // ���[�J�[�R�[�h
        public const string ct_Col_Sort_GoodsMakerCd = "Sort_GoodsMakerCd";
        // ���i�啪�ރR�[�h
        public const string ct_Col_Sort_GoodsLGroup = "Sort_GoodsLGroup";
        // ���i�����ރR�[�h
        public const string ct_Col_Sort_GoodsMGroup = "Sort_GoodsMGroup";
        // �O���[�v�R�[�h
        public const string ct_Col_Sort_BLGroupCode = "Sort_BLGroupCode";

        // --���[�󎚐���p--
        // ��������L��(0:�Ȃ��A1:����)
        public const string ct_Col_SubInfoCount = "SubInfoCount";
        // �����׃L�[
        public const string ct_Col_DetailUnitKey = "DetailUnitKey";

        // --������(����)�֘A--
        // �O���[�v�R�[�h
        public const string ct_Col_Main_BLGroupCode = "Main_BLGroupCode";
        // �����i��
        public const string ct_Col_Main_GoodsNo = "Main_GoodsNo";
        // �i��
        public const string ct_Col_Main_GoodsName = "Main_GoodsName";
        // �I��
        public const string ct_Col_Main_WarehouseShelfNo = "Main_WarehouseShelfNo";
        // ����񐔁i�݌Ɂj
        public const string ct_Col_Main_St_SalesTimes = "Main_St_SalesTimes";
        // ����񐔁i���j
        public const string ct_Col_Main_Or_SalesTimes = "Main_Or_SalesTimes";
        // ����񐔁i���v�j
        public const string ct_Col_Main_Sum_SalesTimes = "Main_Sum_SalesTimes";


        // --������(�E��)�֘A--
        // ����
        public const string ct_Col_Sub_DisplayOrder = "Sub_DisplayOrder";
        // �d����1
        public const string ct_Col_Sub_SuplierCode = "Sub_SuplierCode";
        // ���[�J�[1
        public const string ct_Col_Sub_MakerCode = "Sub_MakerCode";
        // �Q�l�i��1
        public const string ct_Col_Sub_GoodsNo = "Sub_GoodsNo";
        // �I��1
        public const string ct_Col_Sub_WarehouseShelfNo = "Sub_WarehouseShelfNo";

        // ����񐔁i�݌Ɂj
        public const string ct_Col_Sub_St_SalesTimes = "Sub_St_SalesTimes";
        // ����񐔁i���j
        public const string ct_Col_Sub_Or_SalesTimes = "Sub_Or_SalesTimes";
        // ����񐔁i���v�j
        public const string ct_Col_Sub_Sum_SalesTimes = "Sub_Sum_SalesTimes";

        // --������v(�E��)�֘A--
        // ����񐔁i�݌Ɂj���v
        public const string ct_Col_SubTotal_St_SalesTimes = "SubTotal_St_SalesTimes";
        // ����񐔁i���j���v
        public const string ct_Col_SubTotal_Or_SalesTimes = "SubTotal_Or_SalesTimes";
        // ����񐔁i���v�j���v
        public const string ct_Col_SubTotal_Sum_SalesTimes = "SubTotal_Sum_SalesTimes";

        #endregion

        #region �� �R���X�g���N�^
        /// <summary>
        ///  �R���X�g���N�^
        /// </summary>
        public PMHNB02155EB()
        {
        }

        #endregion

        #region �� public���\�b�h
        static public void CreateDataTable(ref DataTable dt)
        {
            // �e�[�u�������݂��邩�ǂ����̃`�F�b�N
            if (dt != null)
            {
                // �e�[�u�������݂���Ƃ��̓N���A�[����̂݁B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                dt.Clear();
            }
            else
            {
                // �X�L�[�}�ݒ�
                dt = new DataTable(ct_Tbl_ShipGdsPrimeListResultForPrint);

                // --����--
                // ���_�R�[�h
                dt.Columns.Add(ct_Col_AddUpSecCode, typeof(string));
                dt.Columns[ct_Col_AddUpSecCode].DefaultValue = string.Empty;

                // ���_����
                dt.Columns.Add(ct_Col_SectionGuideSnm, typeof(string));
                dt.Columns[ct_Col_SectionGuideSnm].DefaultValue = string.Empty;

                // --�\�[�g--
                // ���i���[�J�[�R�[�h
                dt.Columns.Add(ct_Col_Sort_GoodsMakerCd, typeof(Int32));
                dt.Columns[ct_Col_Sort_GoodsMakerCd].DefaultValue = 0;

                // ���i�啪��
                dt.Columns.Add(ct_Col_Sort_GoodsLGroup, typeof(Int32));
                dt.Columns[ct_Col_Sort_GoodsLGroup].DefaultValue = 0;

                // ���i������
                dt.Columns.Add(ct_Col_Sort_GoodsMGroup, typeof(Int32));
                dt.Columns[ct_Col_Sort_GoodsMGroup].DefaultValue = 0;

                // BL�O���[�v�R�[�h
                dt.Columns.Add(ct_Col_Sort_BLGroupCode, typeof(Int32));
                dt.Columns[ct_Col_Sort_BLGroupCode].DefaultValue = 0;

                // --����p--
                // ������(�E��)�̏��(0��1)
                dt.Columns.Add(ct_Col_SubInfoCount, typeof(Int32));
                dt.Columns[ct_Col_SubInfoCount].DefaultValue = 0;

                // �����׃L�[
                dt.Columns.Add(ct_Col_DetailUnitKey, typeof(Int32));
                dt.Columns[ct_Col_DetailUnitKey].DefaultValue = 0;

                // --������(����)�֘A--
                // �O���[�v�R�[�h
                dt.Columns.Add(ct_Col_Main_BLGroupCode, typeof(Int32));
                dt.Columns[ct_Col_Main_BLGroupCode].DefaultValue = 0;
                
                // �����i��
                dt.Columns.Add(ct_Col_Main_GoodsNo, typeof(string));
                dt.Columns[ct_Col_Main_GoodsNo].DefaultValue = string.Empty;

                // �i��
                dt.Columns.Add(ct_Col_Main_GoodsName, typeof(string));
                dt.Columns[ct_Col_Main_GoodsName].DefaultValue = string.Empty;

                // �I��
                dt.Columns.Add(ct_Col_Main_WarehouseShelfNo, typeof(string));
                dt.Columns[ct_Col_Main_WarehouseShelfNo].DefaultValue = string.Empty;

                // �����(�݌�)
                dt.Columns.Add(ct_Col_Main_St_SalesTimes, typeof(Int32));
                dt.Columns[ct_Col_Main_St_SalesTimes].DefaultValue = 0;

                // �����(���)
                dt.Columns.Add(ct_Col_Main_Or_SalesTimes, typeof(Int32));
                dt.Columns[ct_Col_Main_Or_SalesTimes].DefaultValue = 0;

                // �����(���v)
                dt.Columns.Add(ct_Col_Main_Sum_SalesTimes, typeof(Int32));
                dt.Columns[ct_Col_Main_Sum_SalesTimes].DefaultValue = 0;

                // --������(�E��)�֘A--
                // ����
                dt.Columns.Add(ct_Col_Sub_DisplayOrder, typeof(Int32));
                dt.Columns[ct_Col_Sub_DisplayOrder].DefaultValue = 0;

                // �d����
                dt.Columns.Add(ct_Col_Sub_SuplierCode, typeof(Int32));
                dt.Columns[ct_Col_Sub_SuplierCode].DefaultValue = 0;

                // ���[�J�[
                dt.Columns.Add(ct_Col_Sub_MakerCode, typeof(Int32));
                dt.Columns[ct_Col_Sub_MakerCode].DefaultValue = 0;

                // �Q�l�i��
                dt.Columns.Add(ct_Col_Sub_GoodsNo, typeof(string));
                dt.Columns[ct_Col_Sub_GoodsNo].DefaultValue = string.Empty;

                // �I��
                dt.Columns.Add(ct_Col_Sub_WarehouseShelfNo, typeof(string));
                dt.Columns[ct_Col_Sub_WarehouseShelfNo].DefaultValue = string.Empty;

                // ����񐔁i�݌Ɂj
                dt.Columns.Add(ct_Col_Sub_St_SalesTimes, typeof(Int32));
                dt.Columns[ct_Col_Sub_St_SalesTimes].DefaultValue = 0;

                // ����񐔁i���j
                dt.Columns.Add(ct_Col_Sub_Or_SalesTimes, typeof(Int32));
                dt.Columns[ct_Col_Sub_Or_SalesTimes].DefaultValue = 0;

                // ����񐔁i���v�j
                dt.Columns.Add(ct_Col_Sub_Sum_SalesTimes, typeof(Int32));
                dt.Columns[ct_Col_Sub_Sum_SalesTimes].DefaultValue = 0;

                // --������v(�E��)�֘A--
                // ����񐔁i�݌Ɂj���v
                dt.Columns.Add(ct_Col_SubTotal_St_SalesTimes, typeof(double));
                dt.Columns[ct_Col_SubTotal_St_SalesTimes].DefaultValue = 0;

                // ����񐔁i���j���v
                dt.Columns.Add(ct_Col_SubTotal_Or_SalesTimes, typeof(double));
                dt.Columns[ct_Col_SubTotal_Or_SalesTimes].DefaultValue = 0;

                // ����񐔁i���v�j���v
                dt.Columns.Add(ct_Col_SubTotal_Sum_SalesTimes, typeof(double));
                dt.Columns[ct_Col_SubTotal_Sum_SalesTimes].DefaultValue = 0;
            }
        }
        #endregion
    }
}

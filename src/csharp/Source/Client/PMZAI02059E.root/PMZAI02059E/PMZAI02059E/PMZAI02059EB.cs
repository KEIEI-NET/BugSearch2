using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �݌ɊŔ�� ���[1�s�f�[�^�ێ��N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌ɊŔ���̒��[�P�s�`���Ńf�[�^��ێ�����B</br>
    /// <br>Programmer : 30452 ��� �r��</br>
    /// <br>Date       : 2008.12.12</br>
    /// <br>       
    public class PMZAI02059EB
    {
        #region �� Public�萔
        // �e�[�u������
        public const string ct_Tbl_StockSignResultForPrint = "ct_Tbl_StockSignResultForPrint";
        
        // �J�n��s
        // 0:��s 1:�󎚍s
        public const string ct_Col_InvisibleRow = "InvisibleRow";
        // 1�s�̐ݒ萔
        public const string ct_Col_DataNum = "DataNum";

        // ���_�R�[�h
        public const string ct_Col_SectionCode1 = "SectionCode1";
        // �q�ɃR�[�h
        public const string ct_Col_WarehouseCode1 = "WarehouseCode1";
        // ���i���[�J�[�R�[�h
        public const string ct_Col_GoodsMakerCd1 = "GoodsMakerCd1";
        // �q�ɒI��
        public const string ct_Col_WarehouseShelfNo1 = "WarehouseShelfNo1";
        // ���i�ԍ�
        public const string ct_Col_GoodsNo1 = "GoodsNo1";
        // ���i���̃J�i
        public const string ct_Col_GoodsNameKana1 = "GoodsNameKana1";
        // �Œ�݌ɐ�
        public const string ct_Col_MinimumStockCnt1 = "MinimumStockCnt1";
        // �ō��݌ɐ�
        public const string ct_Col_MaximumStockCnt1 = "MaximumStockCnt1";
        // �݌ɓo�^��
        public const string ct_Col_StockCreateDate1 = "StockCreateDate1";
        // �艿�i�����j
        public const string ct_Col_ListPrice1 = "ListPrice1";

        // ���_�R�[�h
        public const string ct_Col_SectionCode2 = "SectionCode2";
        // �q�ɃR�[�h
        public const string ct_Col_WarehouseCode2 = "WarehouseCode2";
        // ���i���[�J�[�R�[�h
        public const string ct_Col_GoodsMakerCd2 = "GoodsMakerCd2";
        // �q�ɒI��
        public const string ct_Col_WarehouseShelfNo2 = "WarehouseShelfNo2";
        // ���i�ԍ�
        public const string ct_Col_GoodsNo2 = "GoodsNo2";
        // ���i���̃J�i
        public const string ct_Col_GoodsNameKana2 = "GoodsNameKana2";
        // �Œ�݌ɐ�
        public const string ct_Col_MinimumStockCnt2 = "MinimumStockCnt2";
        // �ō��݌ɐ�
        public const string ct_Col_MaximumStockCnt2 = "MaximumStockCnt2";
        // �݌ɓo�^��
        public const string ct_Col_StockCreateDate2 = "StockCreateDate2";
        // �艿�i�����j
        public const string ct_Col_ListPrice2 = "ListPrice2";

        // ���_�R�[�h
        public const string ct_Col_SectionCode3 = "SectionCode3";
        // �q�ɃR�[�h
        public const string ct_Col_WarehouseCode3 = "WarehouseCode3";
        // ���i���[�J�[�R�[�h
        public const string ct_Col_GoodsMakerCd3 = "GoodsMakerCd3";
        // �q�ɒI��
        public const string ct_Col_WarehouseShelfNo3 = "WarehouseShelfNo3";
        // ���i�ԍ�
        public const string ct_Col_GoodsNo3 = "GoodsNo3";
        // ���i���̃J�i
        public const string ct_Col_GoodsNameKana3 = "GoodsNameKana3";
        // �Œ�݌ɐ�
        public const string ct_Col_MinimumStockCnt3 = "MinimumStockCnt3";
        // �ō��݌ɐ�
        public const string ct_Col_MaximumStockCnt3 = "MaximumStockCnt3";
        // �݌ɓo�^��
        public const string ct_Col_StockCreateDate3 = "StockCreateDate3";
        // �艿�i�����j
        public const string ct_Col_ListPrice3 = "ListPrice3";

        // ���_�R�[�h
        public const string ct_Col_SectionCode4 = "SectionCode4";
        // �q�ɃR�[�h
        public const string ct_Col_WarehouseCode4 = "WarehouseCode4";
        // ���i���[�J�[�R�[�h
        public const string ct_Col_GoodsMakerCd4 = "GoodsMakerCd4";
        // �q�ɒI��
        public const string ct_Col_WarehouseShelfNo4 = "WarehouseShelfNo4";
        // ���i�ԍ�
        public const string ct_Col_GoodsNo4 = "GoodsNo4";
        // ���i���̃J�i
        public const string ct_Col_GoodsNameKana4 = "GoodsNameKana4";
        // �Œ�݌ɐ�
        public const string ct_Col_MinimumStockCnt4 = "MinimumStockCnt4";
        // �ō��݌ɐ�
        public const string ct_Col_MaximumStockCnt4 = "MaximumStockCnt4";
        // �݌ɓo�^��
        public const string ct_Col_StockCreateDate4 = "StockCreateDate4";
        // �艿�i�����j
        public const string ct_Col_ListPrice4 = "ListPrice4";

        // ���_�R�[�h
        public const string ct_Col_SectionCode5 = "SectionCode5";
        // �q�ɃR�[�h
        public const string ct_Col_WarehouseCode5 = "WarehouseCode5";
        // ���i���[�J�[�R�[�h
        public const string ct_Col_GoodsMakerCd5 = "GoodsMakerCd5";
        // �q�ɒI��
        public const string ct_Col_WarehouseShelfNo5 = "WarehouseShelfNo5";
        // ���i�ԍ�
        public const string ct_Col_GoodsNo5 = "GoodsNo5";
        // ���i���̃J�i
        public const string ct_Col_GoodsNameKana5 = "GoodsNameKana5";
        // �Œ�݌ɐ�
        public const string ct_Col_MinimumStockCnt5 = "MinimumStockCnt5";
        // �ō��݌ɐ�
        public const string ct_Col_MaximumStockCnt5 = "MaximumStockCnt5";
        // �݌ɓo�^��
        public const string ct_Col_StockCreateDate5 = "StockCreateDate5";
        // �艿�i�����j
        public const string ct_Col_ListPrice5 = "ListPrice5";
        #endregion

        #region �� �R���X�g���N�^
        /// <summary>
        ///  �R���X�g���N�^
        /// </summary>
        public PMZAI02059EB()
        {
        }

        #endregion

        #region �� public���\�b�h
        /// <summary>
        /// �݌ɊŔ��DataSet�e�[�u���X�L�[�}�ݒ�
        /// </summary>
        /// <param name="dt">�ݒ�Ώۃf�[�^�e�[�u��</param>
        /// <remarks>
        /// <br>Note       : �݌ɊŔ���f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.12.12</br>
        /// </remarks>
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
                dt = new DataTable(ct_Tbl_StockSignResultForPrint);

                // �J�n��s
                dt.Columns.Add(ct_Col_InvisibleRow, typeof(Int32));
                dt.Columns[ct_Col_InvisibleRow].DefaultValue = 0;
                // 1�s�̐ݒ萔
                dt.Columns.Add(ct_Col_DataNum, typeof(Int32));
                dt.Columns[ct_Col_DataNum].DefaultValue = 0;

                // 1���
                // ���_�R�[�h
                dt.Columns.Add(ct_Col_SectionCode1, typeof(string));
                dt.Columns[ct_Col_SectionCode1].DefaultValue = string.Empty;
                // �q�ɃR�[�h
                dt.Columns.Add(ct_Col_WarehouseCode1, typeof(string));
                dt.Columns[ct_Col_WarehouseCode1].DefaultValue = string.Empty;
                // ���i���[�J�[�R�[�h
                dt.Columns.Add(ct_Col_GoodsMakerCd1, typeof(Int32));
                dt.Columns[ct_Col_GoodsMakerCd1].DefaultValue = 0;
                // �q�ɒI��
                dt.Columns.Add(ct_Col_WarehouseShelfNo1, typeof(string));
                dt.Columns[ct_Col_WarehouseShelfNo1].DefaultValue = string.Empty;
                // ���i�ԍ�
                dt.Columns.Add(ct_Col_GoodsNo1, typeof(string));
                dt.Columns[ct_Col_GoodsNo1].DefaultValue = string.Empty;
                // ���i���̃J�i
                dt.Columns.Add(ct_Col_GoodsNameKana1, typeof(string));
                dt.Columns[ct_Col_GoodsNameKana1].DefaultValue = string.Empty;
                // �Œ�݌ɐ�
                dt.Columns.Add(ct_Col_MinimumStockCnt1, typeof(double));
                dt.Columns[ct_Col_MinimumStockCnt1].DefaultValue = 0;
                // �ō��݌ɐ�
                dt.Columns.Add(ct_Col_MaximumStockCnt1, typeof(double));
                dt.Columns[ct_Col_MaximumStockCnt1].DefaultValue = 0;
                // �݌ɓo�^��
                dt.Columns.Add(ct_Col_StockCreateDate1, typeof(DateTime));
                dt.Columns[ct_Col_StockCreateDate1].DefaultValue = DateTime.MinValue;
                // �艿�i�����j
                dt.Columns.Add(ct_Col_ListPrice1, typeof(double));
                dt.Columns[ct_Col_ListPrice1].DefaultValue = 0;

                // 2���
                // ���_�R�[�h
                dt.Columns.Add(ct_Col_SectionCode2, typeof(string));
                dt.Columns[ct_Col_SectionCode2].DefaultValue = string.Empty;
                // �q�ɃR�[�h
                dt.Columns.Add(ct_Col_WarehouseCode2, typeof(string));
                dt.Columns[ct_Col_WarehouseCode2].DefaultValue = string.Empty;
                // ���i���[�J�[�R�[�h
                dt.Columns.Add(ct_Col_GoodsMakerCd2, typeof(Int32));
                dt.Columns[ct_Col_GoodsMakerCd2].DefaultValue = 0;
                // �q�ɒI��
                dt.Columns.Add(ct_Col_WarehouseShelfNo2, typeof(string));
                dt.Columns[ct_Col_WarehouseShelfNo2].DefaultValue = string.Empty;
                // ���i�ԍ�
                dt.Columns.Add(ct_Col_GoodsNo2, typeof(string));
                dt.Columns[ct_Col_GoodsNo2].DefaultValue = string.Empty;
                // ���i���̃J�i
                dt.Columns.Add(ct_Col_GoodsNameKana2, typeof(string));
                dt.Columns[ct_Col_GoodsNameKana2].DefaultValue = string.Empty;
                // �Œ�݌ɐ�
                dt.Columns.Add(ct_Col_MinimumStockCnt2, typeof(double));
                dt.Columns[ct_Col_MinimumStockCnt2].DefaultValue = 0;
                // �ō��݌ɐ�
                dt.Columns.Add(ct_Col_MaximumStockCnt2, typeof(double));
                dt.Columns[ct_Col_MaximumStockCnt2].DefaultValue = 0;
                // �݌ɓo�^��
                dt.Columns.Add(ct_Col_StockCreateDate2, typeof(DateTime));
                dt.Columns[ct_Col_StockCreateDate2].DefaultValue = DateTime.MinValue;
                // �艿�i�����j
                dt.Columns.Add(ct_Col_ListPrice2, typeof(double));
                dt.Columns[ct_Col_ListPrice2].DefaultValue = 0;

                // 3���
                // ���_�R�[�h
                dt.Columns.Add(ct_Col_SectionCode3, typeof(string));
                dt.Columns[ct_Col_SectionCode3].DefaultValue = string.Empty;
                // �q�ɃR�[�h
                dt.Columns.Add(ct_Col_WarehouseCode3, typeof(string));
                dt.Columns[ct_Col_WarehouseCode3].DefaultValue = string.Empty;
                // ���i���[�J�[�R�[�h
                dt.Columns.Add(ct_Col_GoodsMakerCd3, typeof(Int32));
                dt.Columns[ct_Col_GoodsMakerCd3].DefaultValue = 0;
                // �q�ɒI��
                dt.Columns.Add(ct_Col_WarehouseShelfNo3, typeof(string));
                dt.Columns[ct_Col_WarehouseShelfNo3].DefaultValue = string.Empty;
                // ���i�ԍ�
                dt.Columns.Add(ct_Col_GoodsNo3, typeof(string));
                dt.Columns[ct_Col_GoodsNo3].DefaultValue = string.Empty;
                // ���i���̃J�i
                dt.Columns.Add(ct_Col_GoodsNameKana3, typeof(string));
                dt.Columns[ct_Col_GoodsNameKana3].DefaultValue = string.Empty;
                // �Œ�݌ɐ�
                dt.Columns.Add(ct_Col_MinimumStockCnt3, typeof(double));
                dt.Columns[ct_Col_MinimumStockCnt3].DefaultValue = 0;
                // �ō��݌ɐ�
                dt.Columns.Add(ct_Col_MaximumStockCnt3, typeof(double));
                dt.Columns[ct_Col_MaximumStockCnt3].DefaultValue = 0;
                // �݌ɓo�^��
                dt.Columns.Add(ct_Col_StockCreateDate3, typeof(DateTime));
                dt.Columns[ct_Col_StockCreateDate3].DefaultValue = DateTime.MinValue;
                // �艿�i�����j
                dt.Columns.Add(ct_Col_ListPrice3, typeof(double));
                dt.Columns[ct_Col_ListPrice3].DefaultValue = 0;

                // 4���
                // ���_�R�[�h
                dt.Columns.Add(ct_Col_SectionCode4, typeof(string));
                dt.Columns[ct_Col_SectionCode4].DefaultValue = string.Empty;
                // �q�ɃR�[�h
                dt.Columns.Add(ct_Col_WarehouseCode4, typeof(string));
                dt.Columns[ct_Col_WarehouseCode4].DefaultValue = string.Empty;
                // ���i���[�J�[�R�[�h
                dt.Columns.Add(ct_Col_GoodsMakerCd4, typeof(Int32));
                dt.Columns[ct_Col_GoodsMakerCd4].DefaultValue = 0;
                // �q�ɒI��
                dt.Columns.Add(ct_Col_WarehouseShelfNo4, typeof(string));
                dt.Columns[ct_Col_WarehouseShelfNo4].DefaultValue = string.Empty;
                // ���i�ԍ�
                dt.Columns.Add(ct_Col_GoodsNo4, typeof(string));
                dt.Columns[ct_Col_GoodsNo4].DefaultValue = string.Empty;
                // ���i���̃J�i
                dt.Columns.Add(ct_Col_GoodsNameKana4, typeof(string));
                dt.Columns[ct_Col_GoodsNameKana4].DefaultValue = string.Empty;
                // �Œ�݌ɐ�
                dt.Columns.Add(ct_Col_MinimumStockCnt4, typeof(double));
                dt.Columns[ct_Col_MinimumStockCnt4].DefaultValue = 0;
                // �ō��݌ɐ�
                dt.Columns.Add(ct_Col_MaximumStockCnt4, typeof(double));
                dt.Columns[ct_Col_MaximumStockCnt4].DefaultValue = 0;
                // �݌ɓo�^��
                dt.Columns.Add(ct_Col_StockCreateDate4, typeof(DateTime));
                dt.Columns[ct_Col_StockCreateDate4].DefaultValue = DateTime.MinValue;
                // �艿�i�����j
                dt.Columns.Add(ct_Col_ListPrice4, typeof(double));
                dt.Columns[ct_Col_ListPrice4].DefaultValue = 0;

                // 5���
                // ���_�R�[�h
                dt.Columns.Add(ct_Col_SectionCode5, typeof(string));
                dt.Columns[ct_Col_SectionCode5].DefaultValue = string.Empty;
                // �q�ɃR�[�h
                dt.Columns.Add(ct_Col_WarehouseCode5, typeof(string));
                dt.Columns[ct_Col_WarehouseCode5].DefaultValue = string.Empty;
                // ���i���[�J�[�R�[�h
                dt.Columns.Add(ct_Col_GoodsMakerCd5, typeof(Int32));
                dt.Columns[ct_Col_GoodsMakerCd5].DefaultValue = 0;
                // �q�ɒI��
                dt.Columns.Add(ct_Col_WarehouseShelfNo5, typeof(string));
                dt.Columns[ct_Col_WarehouseShelfNo5].DefaultValue = string.Empty;
                // ���i�ԍ�
                dt.Columns.Add(ct_Col_GoodsNo5, typeof(string));
                dt.Columns[ct_Col_GoodsNo5].DefaultValue = string.Empty;
                // ���i���̃J�i
                dt.Columns.Add(ct_Col_GoodsNameKana5, typeof(string));
                dt.Columns[ct_Col_GoodsNameKana5].DefaultValue = string.Empty;
                // �Œ�݌ɐ�
                dt.Columns.Add(ct_Col_MinimumStockCnt5, typeof(double));
                dt.Columns[ct_Col_MinimumStockCnt5].DefaultValue = 0;
                // �ō��݌ɐ�
                dt.Columns.Add(ct_Col_MaximumStockCnt5, typeof(double));
                dt.Columns[ct_Col_MaximumStockCnt5].DefaultValue = 0;
                // �݌ɓo�^��
                dt.Columns.Add(ct_Col_StockCreateDate5, typeof(DateTime));
                dt.Columns[ct_Col_StockCreateDate5].DefaultValue = DateTime.MinValue;
                // �艿�i�����j
                dt.Columns.Add(ct_Col_ListPrice5, typeof(double));
                dt.Columns[ct_Col_ListPrice5].DefaultValue = 0;
            }
        }
        #endregion
    }
}

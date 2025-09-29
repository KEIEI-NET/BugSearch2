//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �d���`�F�b�N���X�g
// �v���O�����T�v   : �d���`�F�b�N���X�g���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2009/05/10  �C�����e : �V�K�쐬
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
    /// �d���`�F�b�N���X�g �e�[�u���X�L�[�}���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d���`�F�b�N���X�g �e�[�u���X�L�[�}���N���X�̒�`�E�������y�уC���X�^���X�������s���B</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2009.05.10</br>
    /// </remarks>
    public class PMKOU02055EA
    {
        #region �� Public Const

        /// <summary> �e�[�u������ </summary>
        public const string ct_Tbl_StockSlipData = "Tbl_StockSlipData";
        
        /// <summary> ���t(�d���f�[�^�̓��ד�) </summary>
        public const string ct_Col_ArrivalGoodsDay = "ArrivalGoodsDay";

        /// <summary> �`�[�ԍ�(�d���f�[�^�̑����`�[�ԍ�) </summary>
        public const string ct_Col_PartySaleSlipNum = "PartySaleSlipNum";

        /// <summary> ���_�R�[�h(�d���f�[�^�̋��_�R�[�h) </summary>
        public const string ct_Col_SectionCode = "SectionCode";
        
        /// <summary> �d��SEQ�ԍ�(�d���f�[�^�̎d���`�[�ԍ�) </summary>
        public const string ct_Col_SupplierSlipNo = "SupplierSlipNo";

        /// <summary> �d����(�d���f�[�^�̎d����) </summary>
        public const string ct_Col_StockDate = "StockDate";
        
        /// <summary> �d���z(�d���f�[�^�̎d���z���v) </summary>
        public const string ct_Col_StockTotalPrice = "StockTotalPrice";

        /// <summary> ���l(�d���f�[�^�̎d���`�[���l1) </summary>
        public const string ct_Col_SupplierSlipNote1 = "SupplierSlipNote1";

        /// <summary> UOE(�d���f�[�^��UOE���}�[�N1,2�H) </summary>
        public const string ct_Col_UoeRemark1 = "UoeRemark1";

        /// <summary> ���t(�e�L�X�g�f�[�^�̓��ד�) </summary>
        public const string ct_Col_Csv_ArrivalGoodsDay = "Csv_ArrivalGoodsDay";

        /// <summary> �`�[�ԍ�(�e�L�X�g�f�[�^�̓`�[�ԍ�) </summary>
        public const string ct_Col_Csv_PartySaleSlipNum = "Csv_PartySaleSlipNum";

        /// <summary> ���_�R�[�h(�e�L�X�g�f�[�^�̋��_�R�[�h) </summary>
        public const string ct_Col_Csv_SectionCode = "Csv_SectionCode";

        /// <summary> �d����(�e�L�X�g�f�[�^�̎d����) </summary>
        public const string ct_Col_Csv_StockDate = "Csv_StockDate";

        /// <summary> �d���z(�e�L�X�g�f�[�^�̎d���z) </summary>
        public const string ct_Col_Csv_StockTotalPrice = "Csv_StockTotalPrice";

        /// <summary> ���l(�e�L�X�g�f�[�^�̔��l) </summary>
        public const string ct_Col_Csv_SupplierSlipNote = "Csv_SupplierSlipNote";

        /// <summary> �`�F�b�N���e(�����Ώۂɂ���(�d����`�[����/�o�l�`�[����/�`�[���z�s��v/���t�s��v/���z�E���t�s��v/�o�l�`�[���d��)) </summary>
        public const string ct_Col_CheckContent = "CheckContent";

        /// <summary> ����敪�i�s��v��/��v���j </summary>
        public const string ct_Col_printDiv = "PrintDiv";

        /// <summary> �G���[�敪</summary>
        public const string ct_Col_errDiv = "errDiv";

        /// <summary> �\���p���t�t�H�[�}�b�g</summary>
        public const string ct_DateFomat = "YYYY/MM/DD";

        /// <summary> �f�[�^�\�����f</summary>
        public const string ct_Col_isNotShow = "IsNotShow";

        #endregion �� Public Const

		#region �� Constructor
		/// <summary>
        /// �d���`�F�b�N���X�g �e�[�u���X�L�[�}���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �d���`�F�b�N���X�g �e�[�u���X�L�[�}���N���X�̏������y�уC���X�^���X�������s���B</br>
		/// <br>Programmer : ����</br>
		/// <br>Date       : 2009.05.10</br>
		/// </remarks>
        public PMKOU02055EA()
		{
		}
		#endregion

        #region �� Static Public Method
        #region �� �d���f�[�^DataSet�e�[�u���X�L�[�}�ݒ�
        /// <summary>
        /// �d���f�[�^DataSet�e�[�u���X�L�[�}�ݒ�
		/// </summary>
		/// <param name="dt">�ݒ�Ώۃf�[�^�e�[�u��</param>
		/// <remarks>
		/// <br>Note       : �d���f�[�^�f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
		/// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
		/// </remarks>
        static public void CreateDataTable(ref DataTable dt)
        {
            // �e�[�u�������݂��邩�ǂ����̃`�F�b�N
            if (dt != null)
            {
                // �e�[�u�������݂��鎞�̓N���A����̂݁B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                dt.Clear();
            }
            else
            {
                // �X�L�[�}�ݒ�
                dt = new DataTable(ct_Tbl_StockSlipData);

                // �f�[�^�\�����f
                dt.Columns.Add(ct_Col_isNotShow, typeof(string));
                dt.Columns[ct_Col_isNotShow].DefaultValue = "";

                // �G���[�敪
                dt.Columns.Add(ct_Col_errDiv, typeof(Int32));
                dt.Columns[ct_Col_errDiv].DefaultValue = 0;

                // ����敪�i�s��v��/��v���j
                dt.Columns.Add(ct_Col_printDiv, typeof(string));
                dt.Columns[ct_Col_printDiv].DefaultValue = "";

                // ���t(�d���f�[�^�̓��ד�) 
                dt.Columns.Add(ct_Col_ArrivalGoodsDay, typeof(string));
                dt.Columns[ct_Col_ArrivalGoodsDay].DefaultValue = "";

                // �`�[�ԍ�(�d���f�[�^�̑����`�[�ԍ�) 
                dt.Columns.Add(ct_Col_PartySaleSlipNum, typeof(string));    
                dt.Columns[ct_Col_PartySaleSlipNum].DefaultValue = "";

                // ���_�R�[�h(�d���f�[�^�̋��_�R�[�h)
                dt.Columns.Add(ct_Col_SectionCode, typeof(string));
                dt.Columns[ct_Col_SectionCode].DefaultValue = "";

                // �d��SEQ�ԍ�(�d���f�[�^�̎d���`�[�ԍ�)
                dt.Columns.Add(ct_Col_SupplierSlipNo, typeof(int));
                dt.Columns[ct_Col_SupplierSlipNo].DefaultValue = 0;

                // �d����(�d���f�[�^�̎d����)
                dt.Columns.Add(ct_Col_StockDate, typeof(string));
                dt.Columns[ct_Col_StockDate].DefaultValue = "";

                // �d���z(�d���f�[�^�̎d���z���v) 
                dt.Columns.Add(ct_Col_StockTotalPrice, typeof(Int64));
                dt.Columns[ct_Col_StockTotalPrice].DefaultValue = 0;

                // ���l(�d���f�[�^�̎d���`�[���l1)
                dt.Columns.Add(ct_Col_SupplierSlipNote1, typeof(string));
                dt.Columns[ct_Col_SupplierSlipNote1].DefaultValue = "";

                // UOE(�d���f�[�^��UOE���}�[�N1,2�H)
                dt.Columns.Add(ct_Col_UoeRemark1, typeof(string));
                dt.Columns[ct_Col_UoeRemark1].DefaultValue = "";

                // ���t(�e�L�X�g�f�[�^�̓��ד�)
                dt.Columns.Add(ct_Col_Csv_ArrivalGoodsDay, typeof(string));
                dt.Columns[ct_Col_Csv_ArrivalGoodsDay].DefaultValue = "";

                // �`�[�ԍ�(�e�L�X�g�f�[�^�̓`�[�ԍ�)
                dt.Columns.Add(ct_Col_Csv_PartySaleSlipNum, typeof(int));
                dt.Columns[ct_Col_Csv_PartySaleSlipNum].DefaultValue = 0;

                // ���_�R�[�h(�e�L�X�g�f�[�^�̋��_�R�[�h) 
                dt.Columns.Add(ct_Col_Csv_SectionCode, typeof(string));
                dt.Columns[ct_Col_Csv_SectionCode].DefaultValue = "";

                // �d����(�e�L�X�g�f�[�^�̎d����)
                dt.Columns.Add(ct_Col_Csv_StockDate, typeof(string));
                dt.Columns[ct_Col_Csv_StockDate].DefaultValue = "";

                // �d���z(�e�L�X�g�f�[�^�̎d���z) 
                dt.Columns.Add(ct_Col_Csv_StockTotalPrice, typeof(Int64));
                dt.Columns[ct_Col_Csv_StockTotalPrice].DefaultValue = 0;

                // ���l(�e�L�X�g�f�[�^�̔��l)
                dt.Columns.Add(ct_Col_Csv_SupplierSlipNote, typeof(string));
                dt.Columns[ct_Col_Csv_SupplierSlipNote].DefaultValue = "";

                // �`�F�b�N���e
                dt.Columns.Add(ct_Col_CheckContent, typeof(string));
                dt.Columns[ct_Col_CheckContent].DefaultValue = "";
            }
        }

        #endregion �� �d���f�[�^DataSet�e�[�u���X�L�[�}�ݒ�

        #endregion �� Static Public Method

    }
}

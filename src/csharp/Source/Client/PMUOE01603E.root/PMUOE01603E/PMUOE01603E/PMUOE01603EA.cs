//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �z���_UOE WEB�`�F�b�N���X�g
// �v���O�����T�v   : �z���_UOE WEB�`�F�b�N���X�g�e�[�u���X�L�[�}��`�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���m
// �� �� ��  2009/04/07  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �z���_UOE WEB�`�F�b�N���X�g�e�[�u���X�L�[�}��`�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �z���_UOE WEB�`�F�b�N���X�g�e�[�u���X�L�[�}�N���X�̒�`�E�������y�уC���X�^���X�������s���B</br>
    /// <br>Programmer : ���m</br>
    /// <br>Date       : 2009.06.03</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class SlipNoAlwcResult
    {
        /// <summary> �e�[�u������ </summary>
        public const string Tbl_Result_SlipNoAlwc = "Tbl_Result_SlipNoAlwc";

        /// <summary> �d���� </summary>
        public const string Col_SupplierDate = "SupplierDate";

        /// <summary> ������ </summary>
        public const string Col_OrderDate = "OrderDate";

        /// <summary> ���d���`�[�ԍ� </summary>
        public const string Col_OldSupplierSlipNo = "OldSupplierSlipNo";

        /// <summary> �d���`�[�ԍ� </summary>
        public const string Col_SupplierSlipNo = "SupplierSlipNo";

        /// <summary> �i�� </summary>
        public const string Col_GoodsNo = "GoodsNo";

        /// <summary> �i�� </summary>
        public const string Col_GoodsName = "GoodsName";

        /// <summary> �X�V�O�P�� </summary>
        public const string Col_UpdatePrice = "UpdatePrice";

        /// <summary> �P�� </summary>
        public const string Col_Price = "Price";

        /// <summary> ������ꗗ�t�@�C������ </summary>
        public const string Col_FilesName = "FilesName";

        /// <summary> �X�V���� </summary>
        public const string Col_UpdateResult = "UpdateResult";

        /// <summary>
        /// �z���_UOE WEB�`�F�b�N���X�g�e�[�u���X�L�[�}��`�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �z���_UOE WEB�`�F�b�N���X�g�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.06.03</br>
		/// </remarks>
        public SlipNoAlwcResult()
		{
		}

        /// <summary>
		/// DataSet�e�[�u���X�L�[�}�ݒ�
		/// </summary>
		/// <param name="ds">�ݒ�Ώۃf�[�^�Z�b�g</param>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.06.03</br>
        /// </remarks>
        static public void CreateDataTableResultSlipNoAlwc(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // �e�[�u�������݂��邩�ǂ����̃`�F�b�N
            if (ds.Tables.Contains(Tbl_Result_SlipNoAlwc))
            {
                // �e�[�u�������݂���Ƃ��̓N���A�[����̂݁B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                ds.Tables[Tbl_Result_SlipNoAlwc].Clear();
            }
            else
            {
                // �X�L�[�}�ݒ�
                ds.Tables.Add(Tbl_Result_SlipNoAlwc);

                DataTable dt = ds.Tables[Tbl_Result_SlipNoAlwc];

                string defValuestring = "";
                // Int32 defValueInt32 = 0;
                // DateTime defValueDateTime = new DateTime();
                // double defValueDouble = 0.0;

                dt.Columns.Add(Col_SupplierDate, typeof(string));
                dt.Columns[Col_SupplierDate].DefaultValue = defValuestring;

                dt.Columns.Add(Col_OrderDate, typeof(string));
                dt.Columns[Col_OrderDate].DefaultValue = defValuestring;

                dt.Columns.Add(Col_OldSupplierSlipNo, typeof(string));
                dt.Columns[Col_OldSupplierSlipNo].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SupplierSlipNo, typeof(string));
                dt.Columns[Col_SupplierSlipNo].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsNo, typeof(string));
                dt.Columns[Col_GoodsNo].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsName, typeof(string));
                dt.Columns[Col_GoodsName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UpdatePrice, typeof(string));
                dt.Columns[Col_UpdatePrice].DefaultValue = defValuestring;

                dt.Columns.Add(Col_Price, typeof(string));
                dt.Columns[Col_Price].DefaultValue = defValuestring;

                dt.Columns.Add(Col_FilesName, typeof(string));
                dt.Columns[Col_FilesName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UpdateResult, typeof(string));
                dt.Columns[Col_UpdateResult].DefaultValue = defValuestring;
            }
        }
    }
}

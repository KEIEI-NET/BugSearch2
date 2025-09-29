using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
    ///  �D�ǃf�[�^�폜���� �e�[�u���X�L�[�}���N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �D�ǃf�[�^�폜�e�[�u���X�L�[�}�N���X�̒�`�E�������y�уC���X�^���X�������s���B</br>
	/// <br>Programmer : caohh</br>
	/// <br>Date       : 2011/07/21</br>
	/// <br></br>
    /// <br>Update Note: </br>
    /// <br>           : </br>
	/// </remarks>
	public class PMKHN01505EA
	{
		#region �� Public Const

        /// <summary> �e�[�u������ </summary>
        public const string ct_Tbl_DeleteList = "Tbl_DeleteList";

        /// <summary> ���i���[�J�[�R�[�h </summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";

        /// <summary> ���[�J�[���� </summary>
        public const string ct_Col_MakerName = "MakerName";

        /// <summary> ���i�ԍ� </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";

        /// <summary> BL���i�R�[�h</summary>
        public const string ct_Col_BLGoodsCode = "BLGoodsCode";

        /// <summary> ���i���� </summary>
        public const string ct_Col_GoodsName = "GoodsName";

        /// <summary> �q�ɃR�[�h </summary>
        public const string ct_Col_WarehouseCode = "WarehouseCode";

        /// <summary> �q�ɖ��� </summary>
        public const string ct_Col_WarehouseName = "WarehouseName";

        /// <summary> �q�ɒI�� </summary>
        public const string ct_Col_WarehouseShelfNo = "WarehouseShelfNo";

        /// <summary> �o�׉\�� </summary>
        public const string ct_Col_ShipmentPosCnt = "ShipmentPosCnt";

        /// <summary> ������(�����c) </summary>
        public const string ct_Col_SalesOrderCount = "SalesOrderCount";

        #endregion �� Public Const

		#region �� Constructor
		/// <summary>
        /// �D�ǃf�[�^�폜�����e�[�u���X�L�[�}��`�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �D�ǃf�[�^�폜�����e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���B</br>
		/// <br>Programmer : caohh</br>
		/// <br>Date       : 2011/07/21</br>
		/// </remarks>
		public PMKHN01505EA()
		{
		}
		#endregion

		#region �� Static Public Method
		#region �� DataSet�e�[�u���X�L�[�}�ݒ�
		/// <summary>
		/// DataSet�e�[�u���X�L�[�}�ݒ�
		/// </summary>
		/// <param name="dt">�ݒ�Ώۃf�[�^�e�[�u��</param>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
		/// <br>Programmer : caohh</br>
		/// <br>Date       : 2011/07/21</br>
		/// </remarks>
		static public void CreateDataTable(ref DataTable dt)
		{
            string defValuestring = "";
            Int32 defValueInt32 = 0;
            double defValueDouble = 0.0;

			// �e�[�u�������݂��邩�ǂ����̃`�F�b�N
			if ( dt != null )
			{
				// �e�[�u�������݂���Ƃ��̓N���A�[����̂݁B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
				dt.Clear();
			}
			else
			{
                // �X�L�[�}�ݒ�
                dt = new DataTable(ct_Tbl_DeleteList);

                #region << Column �ǉ� >>
                // ���i���[�J�[�R�[�h
                dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(Int32));
                dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = defValueInt32;

                // ���[�J�[����
                dt.Columns.Add(ct_Col_MakerName, typeof(string));
                dt.Columns[ct_Col_MakerName].DefaultValue = defValuestring;

                // ���i�ԍ�
                dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
                dt.Columns[ct_Col_GoodsNo].DefaultValue = defValuestring;

                // BL���i�R�[�h
                dt.Columns.Add(ct_Col_BLGoodsCode, typeof(Int32));
                dt.Columns[ct_Col_BLGoodsCode].DefaultValue = defValueInt32;

                // ���i����
                dt.Columns.Add(ct_Col_GoodsName, typeof(string));
                dt.Columns[ct_Col_GoodsName].DefaultValue = defValuestring;

                // �q�ɃR�[�h
                dt.Columns.Add(ct_Col_WarehouseCode, typeof(string));
                dt.Columns[ct_Col_WarehouseCode].DefaultValue = defValuestring;

                // �q�ɖ���
                dt.Columns.Add(ct_Col_WarehouseName, typeof(string));
                dt.Columns[ct_Col_WarehouseName].DefaultValue = defValuestring;

                // �q�ɒI��
                dt.Columns.Add(ct_Col_WarehouseShelfNo, typeof(string));
                dt.Columns[ct_Col_WarehouseShelfNo].DefaultValue = defValuestring;

                // �o�׉\��
                dt.Columns.Add(ct_Col_ShipmentPosCnt, typeof(Double));
                dt.Columns[ct_Col_ShipmentPosCnt].DefaultValue = defValueDouble;

                // ������(�����c)
                dt.Columns.Add(ct_Col_SalesOrderCount, typeof(Double));
                dt.Columns[ct_Col_SalesOrderCount].DefaultValue = defValueDouble;
                #endregion << Column �ǉ� >>
            }
		}
		#endregion
		#endregion
	}
}

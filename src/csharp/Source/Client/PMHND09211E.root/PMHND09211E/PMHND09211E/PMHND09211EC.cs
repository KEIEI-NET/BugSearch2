//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�o�[�R�[�h�֘A�t���e�[�u���X�L�[�}��`�N���X
// �v���O�����T�v   : ���i�o�[�R�[�h�֘A�t���e�[�u���ɑ΂��Ċe���쏈�����s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370006-00 �쐬�S�� : 3H ������
// �� �� ��  2017/06/12  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ���i�o�[�R�[�h�֘A�t���e�[�u���X�L�[�}��`�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�o�[�R�[�h�֘A�t���e�[�u���X�L�[�}�N���X�̒�`�E�������y�уC���X�^���X�������s���B</br>
    /// <br>Programmer : 3H ������</br>
    /// <br>Date       : 2017/06/12</br>
    /// </remarks>
    public class GoodsBarCodeRevnTbl
    {
        #region �� Public Const

        /// <summary> �e�[�u������ </summary>
        public const string ct_Tbl_GoodsBarCodeRevn = "Tbl_GoodsBarCodeRevn";

        /// <summary> �s�ԍ� </summary>
        public const string ct_Col_RowNo = "RowNo";
        /// <summary> �i�� </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";

        /// <summary> ���[�J�[�R�[�h </summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary> ���[�J�[���� </summary>
        public const string ct_Col_MakerName = "MakerName";

        /// <summary> �i�� </summary>
        public const string ct_Col_GoodsName = "GoodsName";

        /// <summary> ���i�o�[�R�[�h��� </summary>
        public const string ct_Col_GoodsBarCodeKind = "GoodsBarCodeKind";

        /// <summary> �o�[�R�[�h </summary>
        public const string ct_Col_GoodsBarCode = "GoodsBarCode";

        /// <summary> �폜�敪 </summary>
        public const string ct_Col_DeleteDiv = "DeleteDiv";

        #endregion �� Public Const

        #region �� Constructor
        /// <summary>
        /// ���i�o�[�R�[�h�֘A�t���e�[�u���X�L�[�}��`�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�o�[�R�[�h�֘A�t���e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        public GoodsBarCodeRevnTbl()
        {
        }
        #endregion

        #region �� Static Public Method
        #region �� �e�[�u���X�L�[�}�ݒ�
        /// <summary>
        /// DataSet�e�[�u���X�L�[�}�ݒ�
        /// </summary>
        /// <param name="dt">�ݒ�Ώۃf�[�^�e�[�u��</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
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
                dt = new DataTable(ct_Tbl_GoodsBarCodeRevn);

                // �f�t�H���g�l
                string defaultValueOfstring = string.Empty;
                Int32 defaultValueOfInt32 = 0;

                # region <Column�ǉ�>

                // �s�ԍ�
                dt.Columns.Add(ct_Col_RowNo, typeof(Int32));
                dt.Columns[ct_Col_RowNo].DefaultValue = defaultValueOfInt32;
                dt.Columns[ct_Col_RowNo].Caption = "No.";

                // �i��
                dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
                dt.Columns[ct_Col_GoodsNo].DefaultValue = defaultValueOfstring;
                dt.Columns[ct_Col_GoodsNo].Caption = "�i��";

                // ���[�J�[�R�[�h
                dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(string));
                dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = defaultValueOfstring;
                dt.Columns[ct_Col_GoodsMakerCd].Caption = "���[�J�[�R�[�h";

                // ���[�J�[����
                dt.Columns.Add(ct_Col_MakerName, typeof(string));
                dt.Columns[ct_Col_MakerName].DefaultValue = defaultValueOfstring;
                dt.Columns[ct_Col_MakerName].Caption = "���[�J�[����";

                // �i��
                dt.Columns.Add(ct_Col_GoodsName, typeof(string));
                dt.Columns[ct_Col_GoodsName].DefaultValue = defaultValueOfstring;
                dt.Columns[ct_Col_GoodsName].Caption = "�i��";

                // �o�[�R�[�h���
                dt.Columns.Add(ct_Col_GoodsBarCodeKind, typeof(Int32));
                dt.Columns[ct_Col_GoodsBarCodeKind].DefaultValue = defaultValueOfInt32;
                dt.Columns[ct_Col_GoodsBarCodeKind].Caption = "�o�[�R�[�h���";

                // �o�[�R�[�h
                dt.Columns.Add(ct_Col_GoodsBarCode, typeof(string));
                dt.Columns[ct_Col_GoodsBarCode].DefaultValue = defaultValueOfstring;
                dt.Columns[ct_Col_GoodsBarCode].Caption = "�o�[�R�[�h";

                // �폜�敪
                dt.Columns.Add(ct_Col_DeleteDiv, typeof(string));
                dt.Columns[ct_Col_DeleteDiv].DefaultValue = defaultValueOfstring;
                dt.Columns[ct_Col_DeleteDiv].Caption = "�폜�敪";
                # endregion
            }
        }
        #endregion
        #endregion
    }
}

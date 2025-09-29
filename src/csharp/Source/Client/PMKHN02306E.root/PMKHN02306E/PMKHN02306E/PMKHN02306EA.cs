//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �������i���i����
// �v���O�����T�v   : �������i���i�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���痈
// �� �� ��  2009/04/27  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �������i���i�����p�e�[�u���X�L�[�}��`�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �������i���i�����p�e�[�u���X�L�[�}�N���X�̒�`�E�������y�уC���X�^���X�������s���B</br>
    /// <br>Programmer : ���痈</br>
    /// <br>Date       : 2009/04/28</br>
    /// </remarks>
    public class PMKHN02306EA
    {
        # region �� Public Const

        /// <summary> �e�[�u������ </summary>
        public const string ct_Tbl_GoodsWarnErrorCheck = "Tbl_GoodsWarnErrorCheck";
        /// <summary>�d���溰��</summary>
        public const string ct_Col_SupplierCd = "SupplierCd";
        /// <summary>���[�J�[</summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary>�a�k�R�[�h</summary>
        public const string ct_Col_BLGoodsCode = "BLGoodsCode";
        /// <summary>�i��</summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary>�i��</summary>
        public const string ct_Col_GoodsName = "GoodsName";
        /// <summary>�艿</summary>
        public const string ct_Col_Price = "Price";
        /// <summary>�d����</summary>
        public const string ct_Col_SaleRate = "SaleRate";
        /// <summary>����</summary>
        public const string ct_Col_SalesUnitCost = "SalesUnitCost";
        /// <summary>���</summary>
        public const string ct_Col_PdfStatus = "PdfStatus";
        /// <summary>�`�F�b�N</summary>
        public const string ct_Col_CheckMessage = "CheckMessage";
        /// <summary>�󎚏�</summary>
        public const string ct_Col_Orderby = "Orderby";
        # endregion Public Const


        # region �� Constructor
        /// <summary>
        /// �������i���i�����p�e�[�u���X�L�[�}��`�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �������i���i�����p�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        public PMKHN02306EA()
        {
        }
        # endregion Constructor


        # region �� Public Method
        /// <summary>
        /// �������i���i����DataSet�e�[�u���X�L�[�}�ݒ�
        /// </summary>
        /// <param name="ds">�ݒ�Ώۃf�[�^�Z�b�g</param>
        /// <remarks>
        /// <br>Note       : �������i���i�����f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        static public void CreateDataTableGoodsWarnErrorCheck(ref DataTable dt)
        {
            if (dt == null)
                dt = new DataTable();

            if (dt.TableName == ct_Tbl_GoodsWarnErrorCheck)
            {
                // �e�[�u�������݂���Ƃ��̓N���A�[����̂݁B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                dt.Clear();
            }
            else
            {
                // �X�L�[�}�ݒ�

                //�d���溰��
                dt.Columns.Add(ct_Col_SupplierCd, typeof(string));
                dt.Columns[ct_Col_SupplierCd].DefaultValue = "";

                //���[�J�[
                dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(string));
                dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = "";

                //�a�k�R�[�h
                dt.Columns.Add(ct_Col_BLGoodsCode, typeof(string));
                dt.Columns[ct_Col_BLGoodsCode].DefaultValue = "";

                //�i��
                dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
                dt.Columns[ct_Col_GoodsNo].DefaultValue = "";

                //�i��
                dt.Columns.Add(ct_Col_GoodsName, typeof(string));
                dt.Columns[ct_Col_GoodsName].DefaultValue = "";

                //�艿
                dt.Columns.Add(ct_Col_Price, typeof(string));
                dt.Columns[ct_Col_Price].DefaultValue = "";

                //�d����
                dt.Columns.Add(ct_Col_SaleRate, typeof(string));
                dt.Columns[ct_Col_SaleRate].DefaultValue = "";

                //����
                dt.Columns.Add(ct_Col_SalesUnitCost, typeof(string));
                dt.Columns[ct_Col_SalesUnitCost].DefaultValue = "";

                //���
                dt.Columns.Add(ct_Col_PdfStatus, typeof(string));
                dt.Columns[ct_Col_PdfStatus].DefaultValue = "";

                //�`�F�b�N
                dt.Columns.Add(ct_Col_CheckMessage, typeof(string));
                dt.Columns[ct_Col_CheckMessage].DefaultValue = "";

                //�󎚏�
                dt.Columns.Add(ct_Col_Orderby, typeof(int));
                dt.Columns[ct_Col_Orderby].DefaultValue = 0;
            }
        }
        # endregion Public Method
    }
}

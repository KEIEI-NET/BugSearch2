//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �����ꗗ����(�����)�e�[�u���X�L�[�}�N���X
// �v���O�����T�v   : �����ꗗ����(�����)�e�[�u����`���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-00 �쐬�S�� : ���� �T��
// �� �� ��  2009/05/25  �C�����e : 96186 ���� �T�� �z���_ UOE WEB�Ή�
//----------------------------------------------------------------------------//
using System;
using System.Data;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �����ꗗ����(�����)�e�[�u���X�L�[�}�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����ꗗ����(�����)�e�[�u���X�L�[�}</br>
    /// <br>Programmer : 96186�@���ԗT��</br>
    /// <br>Date       : 2009/05/25</br>
    /// </remarks>
    public class OrderLstInputDtlSchema
    {
        #region Public Members
        /// <summary>�����ꗗ����(�����)�e�[�u����</summary>
        public const string CT_OrderLstInputDtlDataTable = "OrderLstInputDtlDataTable";


        #region �J�����������
        public const double defValueDouble = 0;
        public const Int64 defValueInt64 = 0;
        public const Int32 defValueInt32 = 0;
        public const string defValueString = "";
        #endregion

        #region �J�������
        /// <summary> ���q�l�� </summary>
        public const string ct_Col_UserName = "UserName";
        /// <summary> ���q�lCD </summary>
        public const string ct_Col_UserCode = "UserCode";
        /// <summary> �A�C�e�� </summary>
        public const string ct_Col_ItemCode = "ItemCode";
        /// <summary> ������ </summary>
        public const string ct_Col_OrderDate = "OrderDate";
        /// <summary> �������� </summary>
        public const string ct_Col_OrderTime = "OrderTime";
        /// <summary> �`�[�ԍ�(�w�b�_�[��) </summary>
        public const string ct_Col_SlipNoHead = "SlipNoHead";
        /// <summary> ������ </summary>
        public const string ct_Col_Memo = "Memo";
        /// <summary> �������i�ԍ� </summary>
        public const string ct_Col_OrderGoodsNo = "OrderGoodsNo";
        /// <summary> �o�ו��i�ԍ� </summary>
        public const string ct_Col_ShipmGoodsNo = "ShipmGoodsNo";
        /// <summary> �o�ו��i�� </summary>
        public const string ct_Col_GoodsName = "GoodsName";
        /// <summary> �������� </summary>
        public const string ct_Col_ShipmentCnt = "ShipmentCnt";
        /// <summary> �����c���� </summary>
        public const string ct_Col_OrderRemCnt = "OrderRemCnt";
        /// <summary> ��]�������i </summary>
        public const string ct_Col_AnswerListPrice = "AnswerListPrice";
        /// <summary> �o�׌��� </summary>
        public const string ct_Col_SourceShipment = "SourceShipment";
        /// <summary> ���͗\��� </summary>
        public const string ct_Col_PlanDate = "PlanDate";
        /// <summary> �`�[�ԍ�(���ו�) </summary>
        public const string ct_Col_SlipNoDtl = "SlipNoDtl";
        /// <summary> �d���ꉿ�i </summary>
        public const string ct_Col_AnswerSalesUnitCost = "AnswerSalesUnitCost";
        #endregion

        #endregion

        #region Constructor
        /// <summary>
        /// �����ꗗ����(�����)�e�[�u���X�L�[�}�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����ꗗ����(�����)�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���܂��B</br>
        /// <br>Programmer : 96186�@���ԗT��</br>
        /// <br>Date       : 2009/05/25</br>
        /// </remarks>
        public OrderLstInputDtlSchema()
        {
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// �f�[�^�Z�b�g�A�f�[�^�e�[�u���ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2009/05/25</br>
        /// </remarks>
        public static void SettingDataSet(ref DataSet ds, string dataTableName)
        {
            // �e�[�u�������݂��邩�ǂ������`�F�b�N
            if ((ds.Tables.Contains(dataTableName)))
            {
                // TODO:�e�[�u�������݂���Ƃ��̓N���A�[����̂�
                // �X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                ds.Tables[dataTableName].Clear();
            }
            else
            {
                CreateTable(ref ds, dataTableName);

            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// �����ꗗ����(�����)�쐬����
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2009/05/25</br>
        /// </remarks>
        private static void CreateTable(ref DataSet ds, string dataTableName)
        {
            DataTable dt = null;
            // �X�L�[�}�ݒ�
            ds.Tables.Add(dataTableName);
            dt = ds.Tables[dataTableName];

            // ���q�l��
            dt.Columns.Add(ct_Col_UserName, typeof(String));
            dt.Columns[ct_Col_UserName].DefaultValue = defValueString;
            // ���q�lCD
            dt.Columns.Add(ct_Col_UserCode, typeof(String));
            dt.Columns[ct_Col_UserCode].DefaultValue = defValueString;
            // �A�C�e��
            dt.Columns.Add(ct_Col_ItemCode, typeof(String));
            dt.Columns[ct_Col_ItemCode].DefaultValue = defValueString;
            // ������
            dt.Columns.Add(ct_Col_OrderDate, typeof(DateTime));
            dt.Columns[ct_Col_OrderDate].DefaultValue = DateTime.MinValue;
            // ��������
            dt.Columns.Add(ct_Col_OrderTime, typeof(Int32));
            dt.Columns[ct_Col_OrderTime].DefaultValue = defValueInt32;
            // �`�[�ԍ�(�w�b�_�[��)
            dt.Columns.Add(ct_Col_SlipNoHead, typeof(String));
            dt.Columns[ct_Col_SlipNoHead].DefaultValue = defValueString;
            // ������
            dt.Columns.Add(ct_Col_Memo, typeof(String));
            dt.Columns[ct_Col_Memo].DefaultValue = defValueString;
            // �������i�ԍ�
            dt.Columns.Add(ct_Col_OrderGoodsNo, typeof(String));
            dt.Columns[ct_Col_OrderGoodsNo].DefaultValue = defValueString;
            // �o�ו��i�ԍ�
            dt.Columns.Add(ct_Col_ShipmGoodsNo, typeof(String));
            dt.Columns[ct_Col_ShipmGoodsNo].DefaultValue = defValueString;
            // �o�ו��i��
            dt.Columns.Add(ct_Col_GoodsName, typeof(String));
            dt.Columns[ct_Col_GoodsName].DefaultValue = defValueString;
            // ��������
            dt.Columns.Add(ct_Col_ShipmentCnt, typeof(Double));
            dt.Columns[ct_Col_ShipmentCnt].DefaultValue = defValueDouble;
            // �����c����
            dt.Columns.Add(ct_Col_OrderRemCnt, typeof(Double));
            dt.Columns[ct_Col_OrderRemCnt].DefaultValue = defValueDouble;
            // ��]�������i
            dt.Columns.Add(ct_Col_AnswerListPrice, typeof(Double));
            dt.Columns[ct_Col_AnswerListPrice].DefaultValue = defValueDouble;
            // �o�׌���
            dt.Columns.Add(ct_Col_SourceShipment, typeof(String));
            dt.Columns[ct_Col_SourceShipment].DefaultValue = defValueString;
            // ���͗\���
            dt.Columns.Add(ct_Col_PlanDate, typeof(DateTime));
            dt.Columns[ct_Col_PlanDate].DefaultValue = DateTime.MinValue;
            // �`�[�ԍ�(���ו�)
            dt.Columns.Add(ct_Col_SlipNoDtl, typeof(String));
            dt.Columns[ct_Col_SlipNoDtl].DefaultValue = defValueString;
            // �d���ꉿ�i
            dt.Columns.Add(ct_Col_AnswerSalesUnitCost, typeof(Double));
            dt.Columns[ct_Col_AnswerSalesUnitCost].DefaultValue = defValueDouble;
        }
        #endregion
    }
}
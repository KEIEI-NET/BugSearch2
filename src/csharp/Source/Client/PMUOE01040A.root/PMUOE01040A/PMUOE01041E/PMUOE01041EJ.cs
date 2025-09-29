//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : ����ꗗ���׃e�[�u���X�L�[�}�N���X
// �v���O�����T�v   : ����ꗗ���׃e�[�u����`���s��
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
    /// ����ꗗ���׃e�[�u���X�L�[�}�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����ꗗ���׃e�[�u���X�L�[�}</br>
    /// <br>Programmer : 96186�@���ԗT��</br>
    /// <br>Date       : 2008.05.26</br>
    /// </remarks>
    public class BuyOutLstDtlSchema
    {
        #region Public Members
        /// <summary>����ꗗ���׃e�[�u����</summary>
        public const string CT_BuyOutLstDtlDataTable = "BuyOutLstDtlDataTable";


        #region �J�����������
        public const double defValueDouble = 0;
        public const Int64 defValueInt64 = 0;
        public const Int32 defValueInt32 = 0;
        public const string defValueString = "";
        #endregion

        #region �J�������
        /// <summary> �ʔ� </summary>
        public const string ct_Col_No = "No";
        /// <summary> �������� </summary>
        public const string ct_Col_OrderDate = "OrderDate";
        /// <summary> ������� </summary>
        public const string ct_Col_BuyOutDate = "BuyOutDate";
        /// <summary> ���� </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> �i�� </summary>
        public const string ct_Col_GoodsName = "GoodsName";
        /// <summary> ���� </summary>
        public const string ct_Col_ShipmentCnt = "ShipmentCnt";
        /// <summary> ��]�������i </summary>
        public const string ct_Col_AnswerListPrice = "AnswerListPrice";
        /// <summary> ������P�� </summary>
        public const string ct_Col_BuyOutCost = "BuyOutCost";
        /// <summary> ������z���v </summary>
        public const string ct_Col_BuyOutTotalCost = "BuyOutTotalCost";
        /// <summary> �`�[�ԍ� </summary>
        public const string ct_Col_BuyOutSlipNo = "BuyOutSlipNo";
        /// <summary> �������`�[�ԍ� </summary>
        public const string ct_Col_OrderSlipNo = "OrderSlipNo";
        /// <summary> �R�����g(���L����) </summary>
        public const string ct_Col_Comment = "Comment";
        /// <summary> �������P�� </summary>
        public const string ct_Col_OrderCost = "OrderCost";
        /// <summary> �X�V���� </summary>
        public const string ct_Col_UpdRsl = "UpdRsl";
        #endregion

        #endregion

        #region Constructor
        /// <summary>
        /// ����ꗗ���׃e�[�u���X�L�[�}�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����ꗗ���׃e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���܂��B</br>
        /// <br>Programmer : 96186�@���ԗT��</br>
        /// <br>Date       : 2009/05/25</br>
        /// </remarks>
        public BuyOutLstDtlSchema()
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
        /// ����ꗗ���׍쐬����
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

            // �ʔ�
            dt.Columns.Add(ct_Col_No, typeof(Int32));
            dt.Columns[ct_Col_No].DefaultValue = defValueInt32;
            // ��������
            dt.Columns.Add(ct_Col_OrderDate, typeof(DateTime));
            dt.Columns[ct_Col_OrderDate].DefaultValue = DateTime.MinValue;
            // �������
            dt.Columns.Add(ct_Col_BuyOutDate, typeof(DateTime));
            dt.Columns[ct_Col_BuyOutDate].DefaultValue = DateTime.MinValue;
            // ����
            dt.Columns.Add(ct_Col_GoodsNo, typeof(String));
            dt.Columns[ct_Col_GoodsNo].DefaultValue = defValueString;
            // �i��
            dt.Columns.Add(ct_Col_GoodsName, typeof(String));
            dt.Columns[ct_Col_GoodsName].DefaultValue = defValueString;
            // ����
            dt.Columns.Add(ct_Col_ShipmentCnt, typeof(Double));
            dt.Columns[ct_Col_ShipmentCnt].DefaultValue = defValueDouble;
            // ��]�������i
            dt.Columns.Add(ct_Col_AnswerListPrice, typeof(Double));
            dt.Columns[ct_Col_AnswerListPrice].DefaultValue = defValueDouble;
            // ������P��
            dt.Columns.Add(ct_Col_BuyOutCost, typeof(Double));
            dt.Columns[ct_Col_BuyOutCost].DefaultValue = defValueDouble;
            // ������z���v
            dt.Columns.Add(ct_Col_BuyOutTotalCost, typeof(Double));
            dt.Columns[ct_Col_BuyOutTotalCost].DefaultValue = defValueDouble;
            // �`�[�ԍ�
            dt.Columns.Add(ct_Col_BuyOutSlipNo, typeof(String));
            dt.Columns[ct_Col_BuyOutSlipNo].DefaultValue = defValueString;
            // �������`�[�ԍ�
            dt.Columns.Add(ct_Col_OrderSlipNo, typeof(String));
            dt.Columns[ct_Col_OrderSlipNo].DefaultValue = defValueString;
            // �R�����g(���L����)
            dt.Columns.Add(ct_Col_Comment, typeof(String));
            dt.Columns[ct_Col_Comment].DefaultValue = defValueString;
            // �������P��
            dt.Columns.Add(ct_Col_OrderCost, typeof(Double));
            dt.Columns[ct_Col_OrderCost].DefaultValue = defValueDouble;
            // �X�V����
            dt.Columns.Add(ct_Col_UpdRsl, typeof(Int32));
            dt.Columns[ct_Col_UpdRsl].DefaultValue = defValueInt32;

            //PrimaryKey�̐ݒ�
            dt.PrimaryKey = new DataColumn[] { dt.Columns[ct_Col_No] };

        }
        #endregion
    }
}
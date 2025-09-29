//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �d���s�����m�F�\
// �v���O�����T�v   : �d���s�����m�F�\���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���痈
// �� �� ��  2009.04.13  �C�����e : �V�K�쐬
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
    /// �d���s�����m�F�\�e�[�u���X�L�[�}���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d���s�����m�F�\�e�[�u���X�L�[�}���N���X�̒�`�E�������y�уC���X�^���X�������s���B</br>
    /// <br>Programmer : ���痈</br>
    /// <br>Date       : 2009.04.10</br>
    /// </remarks>
    public class PMKOU02045EA
    {
        #region �� Public Const

        /// <summary> �e�[�u������ </summary>
        public const string Tbl_StockSalesInfoAccRecMain = "Tbl_StockSalesInfoAccRecMain";

        /// <summary> ���_�R�[�h </summary>
        /// <remarks>�d���f�[�^�@���_�R�[�h</remarks>
        public const string Col_SectionCode = "SectionCode";

        /// <summary> ���_�R�[�h header </summary>
        /// <remarks>�d���f�[�^�@���_�R�[�h</remarks>
        public const string Col_SectionCodeHeader = "SectionCodeHeader";

        /// <summary> ���_���� </summary>
        /// <remarks>���_���ݒ�}�X�^�@���_����</remarks>
        public const string Col_SectionName = "SectionName";

        /// <summary> �d����R�[�h </summary>
        /// <remarks>�d���f�[�^ �d����R�[�h</remarks>
        public const string Col_SupplierCd = "SupplierCd";

        /// <summary> �d����R�[�h Header </summary>
        /// <remarks>�d���f�[�^ �d����R�[�h</remarks>
        public const string Col_SupplierCdHeader = "SupplierCdHeader";

        /// <summary> �d���旪�� </summary>
        /// <remarks>�d���f�[�^ �d���旪��</remarks>
        public const string Col_SupplierSnm = "SupplierSnm";

        /// <summary> ���t�@�d���� </summary>
        /// <remarks>�d���f�[�^ �d����</remarks>
        public const string Col_StockDate = "StockDate";

        /// <summary> ���͓��t </summary>
        /// <remarks>�d���f�[�^ ���͓�</remarks>
        public const string Col_InputDay = "InputDay";

        /// <summary>�@�`�[�ԍ� </summary>
        /// <remarks>���㖾�׃f�[�^ �����`�[�ԍ��i���ׁj</remarks>
        public const string Col_PartySlipNumDtl = "PartySlipNumDtl";

        /// <summary>�@�ʔ� </summary>
        /// <remarks>�d�����׃f�[�^ �d���`�[�ԍ��|�d���s�ԍ�</remarks>
        public const string Col_SeqNo = "SeqNo";

        /// <summary> �S���� </summary>
        /// <remarks>�d���f�[�^�@�d���S���҃R�[�h</remarks>
        public const string Col_StockAgentCode = "StockAgentCode";

        /// <summary> BL�R�[�h </summary>
        /// <remarks>�d�����׃f�[�^�@BL���i�R�[�h</remarks>
        public const string Col_BLGoodsCode = "BLGoodsCode";


        /// <summary> �O���[�v </summary>
        /// <remarks>�d�����׃f�[�^�@BL�O���[�v�R�[�h</remarks>
        public const string Col_BLGroupCode = "BLGroupCode";


        /// <summary> �q�� </summary>
        /// <remarks>�d�����׃f�[�^�@�q�ɃR�[�h</remarks>
        public const string Col_WarehouseCode = "WarehouseCode";

        /// <summary> ���Ӑ� </summary>
        /// <remarks>����f�[�^�@���Ӑ�R�[�h</remarks>
        public const string Col_CustomerCode = "CustomerCode";


        /// <summary> ����`�[�ԍ� </summary>
        /// <remarks>����f�[�^�@����`�[�ԍ�</remarks>
        public const string Col_SalesSlipNum = "SalesSlipNum";

        /// <summary> �s�������e </summary>
        /// <remarks>�s�������e</remarks>
        public const string Col_NayiYou = "NayiYou";

        /// <summary> LineFlag</summary>
        public const string Col_LineFlag = "LineFlag";

        #endregion �� Public Const

        #region �� Constructor
        /// <summary>
        /// �d���s�����m�F�\ ���[�f�[�^�p�e�[�u���X�L�[�}��`�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d���s�����m�F�\ ���[�f�[�^�p�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.10</br>
        /// </remarks>
        public PMKOU02045EA()
        {

        }
        #endregion

        #region �� Static Public Method
        #region �� CreateDataTable(ref DataSet ds)
        /// <summary>
        /// ���[DataSet�e�[�u���X�L�[�}�ݒ�
        /// </summary>
        /// <param name="ds">�ݒ�Ώۃf�[�^�Z�b�g</param>
        /// <remarks>
        /// <br>Note       : ���[�f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.10</br>
        /// </remarks>
        static public void CreateDataTableStockSalesInfoAccRecMain(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // �e�[�u�������݂��邩�ǂ����̃`�F�b�N
            if (ds.Tables.Contains(Tbl_StockSalesInfoAccRecMain))
            {
                // �e�[�u�������݂���Ƃ��̓N���A�[����̂݁B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                ds.Tables[Tbl_StockSalesInfoAccRecMain].Clear();
            }
            else
            {
                // �X�L�[�}�ݒ�
                ds.Tables.Add(Tbl_StockSalesInfoAccRecMain);

                DataTable dt = ds.Tables[Tbl_StockSalesInfoAccRecMain];

                dt.Columns.Add(Col_SectionCode, typeof(string));//���_�R�[�h
                dt.Columns[Col_SectionCode].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SectionCodeHeader, typeof(string));//���_�R�[�h Header
                dt.Columns[Col_SectionCodeHeader].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SectionName, typeof(string));//���_����
                dt.Columns[Col_SectionName].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SupplierCd, typeof(string));//�d����R�[�h
                dt.Columns[Col_SupplierCd].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SupplierCdHeader, typeof(string));//�d����R�[�h Header
                dt.Columns[Col_SupplierCdHeader].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SupplierSnm, typeof(string));//�d���旪��
                dt.Columns[Col_SupplierSnm].DefaultValue = string.Empty;

                dt.Columns.Add(Col_StockDate, typeof(string));//���t�@�d����
                dt.Columns[Col_StockDate].DefaultValue = string.Empty;

                dt.Columns.Add(Col_InputDay, typeof(string));//���͓�
                dt.Columns[Col_InputDay].DefaultValue = string.Empty;

                dt.Columns.Add(Col_PartySlipNumDtl, typeof(string));//�`�[�ԍ�
                dt.Columns[Col_PartySlipNumDtl].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SeqNo, typeof(string));//�ʔ�
                dt.Columns[Col_SeqNo].DefaultValue = string.Empty;

                dt.Columns.Add(Col_StockAgentCode, typeof(string));//�S����
                dt.Columns[Col_StockAgentCode].DefaultValue = string.Empty;

                dt.Columns.Add(Col_BLGoodsCode, typeof(string));//BL�R�[�h
                dt.Columns[Col_BLGoodsCode].DefaultValue = string.Empty;

                dt.Columns.Add(Col_BLGroupCode, typeof(string));//�O���[�v
                dt.Columns[Col_BLGroupCode].DefaultValue = string.Empty;

                dt.Columns.Add(Col_WarehouseCode, typeof(string));//�q��
                dt.Columns[Col_WarehouseCode].DefaultValue = string.Empty;

                dt.Columns.Add(Col_CustomerCode, typeof(string));//���Ӑ�
                dt.Columns[Col_CustomerCode].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SalesSlipNum, typeof(string));//����`�[�ԍ�
                dt.Columns[Col_SalesSlipNum].DefaultValue = string.Empty;

                dt.Columns.Add(Col_NayiYou, typeof(string));//�s�������e
                dt.Columns[Col_NayiYou].DefaultValue = string.Empty;

                dt.Columns.Add(Col_LineFlag, typeof(bool));//lineflag
                dt.Columns[Col_LineFlag].DefaultValue = false;
            }
        }
        #endregion
        #endregion
    }
}

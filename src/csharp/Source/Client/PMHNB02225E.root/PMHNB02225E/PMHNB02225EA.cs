//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����s�����m�F�\
// �v���O�����T�v   : ����s�����m�F�\���[���s��
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
    /// ����s�����m�F�\�e�[�u���X�L�[�}���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����s�����m�F�\�e�[�u���X�L�[�}���N���X�̒�`�E�������y�уC���X�^���X�������s���B</br>
    /// <br>Programmer : ���痈</br>
    /// <br>Date       : 2009.04.10</br>
    /// </remarks>
    public class PMHNB02225EA
    {
        #region �� Public Const

        /// <summary> �e�[�u������ </summary>
        public const string Tbl_SalesStockInfoAccRecMain = "Tbl_SalesStockInfoAccRecMain";

        /// <summary> ���_�R�[�h header </summary>
        /// <remarks>�d���f�[�^�@���_�R�[�h</remarks>
        public const string Col_SectionCodeHeader = "SectionCodeHeader";

        /// <summary> ���_���� </summary>
        /// <remarks>���_���ݒ�}�X�^�@���_����</remarks>
        public const string Col_SectionName = "SectionName";

        /// <summary> ���Ӑ� header </summary>
        /// <remarks>����f�[�^�@���Ӑ�R�[�h</remarks>
        public const string Col_CustomerCodeHeader = "CustomerCodeHeader";

        /// <summary> ���Ӑ旪�� </summary>
        /// <remarks>����f�[�^�@���Ӑ旪��</remarks>
        public const string Col_CustomerSnm = "CustomerSnm";


        /// <summary> ���t�@������t </summary>
        /// <remarks>����f�[�^ ������t</remarks>
        public const string Col_SalesDate = "SalesDate";


        /// <summary> ���͓��t </summary>
        /// <remarks>����f�[�^ �`�[�������t</remarks>
        public const string Col_SearchSlipDate = "SearchSlipDate";


        /// <summary> ����`�[�ԍ� </summary>
        /// <remarks>����f�[�^�@����`�[�ԍ�</remarks>
        public const string Col_SalesSlipNum = "SalesSlipNum";

        /// <summary> ���_�R�[�h </summary>
        /// <remarks>�d���f�[�^�@���_�R�[�h</remarks>
        public const string Col_SectionCode = "SectionCode";


        /// <summary> ���� </summary>
        /// <remarks>����f�[�^ ���͒S���҃R�[�h</remarks>
        public const string Col_InputAgenCd = "InputAgenCd";

        /// <summary> ���� </summary>
        /// <remarks>����f�[�^ ������͎҃R�[�h</remarks>
        public const string Col_SalesInputCode = "SalesInputCode";

        /// <summary> ��t </summary>
        /// <remarks>����f�[�^ ��t�]�ƈ��R�[�h</remarks>
        public const string Col_FrontEmployeeCd = "FrontEmployeeCd";

        /// <summary> �̔� </summary>
        /// <remarks>����f�[�^ �̔��]�ƈ��R�[�h</remarks>
        public const string Col_SalesEmployeeCd = "SalesEmployeeCd";


        /// <summary> ���Ӑ� </summary>
        /// <remarks>����f�[�^�@���Ӑ�R�[�h</remarks>
        public const string Col_CustomerCode = "CustomerCode";

        /// <summary> BL�R�[�h </summary>
        /// <remarks>���㖾�׃f�[�^�@BL���i�R�[�h</remarks>
        public const string Col_BLGoodsCode = "BLGoodsCode";


        /// <summary> �O���[�v </summary>
        /// <remarks>���㖾�׃f�[�^�@BL�O���[�v�R�[�h</remarks>
        public const string Col_BLGroupCode = "BLGroupCode";


        /// <summary> �q�� </summary>
        /// <remarks>���㖾�׃f�[�^�@�q�ɃR�[�h</remarks>
        public const string Col_WarehouseCode = "WarehouseCode";

        /// <summary> �G���A </summary>
        /// <remarks>����f�[�^�@�̔��G���A�R�[�h</remarks>
        public const string Col_SalesAreaCode = "SalesAreaCode";

        /// <summary> �Ǝ� </summary>
        /// <remarks>����f�[�^�@�Ǝ�R�[�h</remarks>
        public const string Col_BusinessTypeCode = "BusinessTypeCode";

        /// <summary> �d����R�[�h </summary>
        /// <remarks>�d���f�[�^ �d����R�[�h</remarks>
        public const string Col_SupplierCd = "SupplierCd";


        /// <summary>�@�`�[�ԍ� </summary>
        /// <remarks>���㖾�׃f�[�^ �����`�[�ԍ��i���ׁj</remarks>
        public const string Col_PartySlipNumDtl = "PartySlipNumDtl";

        /// <summary>�@�d��SEQ�ԍ� </summary>
        /// <remarks>�d�����׃f�[�^ �d���`�[�ԍ� SupplierSlipNo</remarks>
        public const string Col_SupplierSlipNo = "SupplierSlipNo";


        /// <summary>�@�ʔ� </summary>
        /// <remarks>�d�����׃f�[�^ �d���`�[�ԍ��|�d���s�ԍ�</remarks>
        public const string Col_SeqNo = "SeqNo";

        /// <summary> �s�������e </summary>
        /// <remarks>�s�������e</remarks>
        public const string Col_NayiYou = "NayiYou";

        /// <summary> LineFlag</summary>
        public const string Col_LineFlag = "LineFlag";

        #endregion �� Public Const

        #region �� Constructor
        /// <summary>
        /// ����s�����m�F�\ ���[�f�[�^�p�e�[�u���X�L�[�}��`�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����s�����m�F�\ ���[�f�[�^�p�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.10</br>
        /// </remarks>
        public PMHNB02225EA()
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
        static public void CreateDataTableSalesStockInfoAccRecMain(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // �e�[�u�������݂��邩�ǂ����̃`�F�b�N
            if (ds.Tables.Contains(Tbl_SalesStockInfoAccRecMain))
            {
                // �e�[�u�������݂���Ƃ��̓N���A�[����̂݁B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                ds.Tables[Tbl_SalesStockInfoAccRecMain].Clear();
            }
            else
            {
                // �X�L�[�}�ݒ�
                ds.Tables.Add(Tbl_SalesStockInfoAccRecMain);

                DataTable dt = ds.Tables[Tbl_SalesStockInfoAccRecMain];



                dt.Columns.Add(Col_SectionCodeHeader, typeof(string));//���_�R�[�h Header
                dt.Columns[Col_SectionCodeHeader].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SectionName, typeof(string));//���_����
                dt.Columns[Col_SectionName].DefaultValue = string.Empty;

                dt.Columns.Add(Col_CustomerCodeHeader, typeof(string));//���Ӑ�Header
                dt.Columns[Col_CustomerCodeHeader].DefaultValue = string.Empty;

                dt.Columns.Add(Col_CustomerSnm, typeof(string));//���Ӑ旪��
                dt.Columns[Col_CustomerSnm].DefaultValue = string.Empty;


                dt.Columns.Add(Col_SalesDate, typeof(string));//���t�@������t
                dt.Columns[Col_SalesDate].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SearchSlipDate, typeof(string));//���͓��@�`�[�������t
                dt.Columns[Col_SearchSlipDate].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SalesSlipNum, typeof(string));//����`�[�ԍ�
                dt.Columns[Col_SalesSlipNum].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SectionCode, typeof(string));//���_�R�[�h
                dt.Columns[Col_SectionCode].DefaultValue = string.Empty;

                dt.Columns.Add(Col_InputAgenCd, typeof(string));//����
                dt.Columns[Col_InputAgenCd].DefaultValue = string.Empty;


                dt.Columns.Add(Col_SalesInputCode, typeof(string));//����
                dt.Columns[Col_SalesInputCode].DefaultValue = string.Empty;


                dt.Columns.Add(Col_FrontEmployeeCd, typeof(string));//��t
                dt.Columns[Col_FrontEmployeeCd].DefaultValue = string.Empty;


                dt.Columns.Add(Col_SalesEmployeeCd, typeof(string));//�̔�
                dt.Columns[Col_SalesEmployeeCd].DefaultValue = string.Empty;

                dt.Columns.Add(Col_CustomerCode, typeof(string));//���Ӑ�
                dt.Columns[Col_CustomerCode].DefaultValue = string.Empty;

                dt.Columns.Add(Col_BLGoodsCode, typeof(string));//BL�R�[�h
                dt.Columns[Col_BLGoodsCode].DefaultValue = string.Empty;

                dt.Columns.Add(Col_BLGroupCode, typeof(string));//�O���[�v
                dt.Columns[Col_BLGroupCode].DefaultValue = string.Empty;

                dt.Columns.Add(Col_WarehouseCode, typeof(string));//�q��
                dt.Columns[Col_WarehouseCode].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SalesAreaCode, typeof(string));//�G���A
                dt.Columns[Col_SalesAreaCode].DefaultValue = string.Empty;

                dt.Columns.Add(Col_BusinessTypeCode, typeof(string));//�Ǝ�
                dt.Columns[Col_BusinessTypeCode].DefaultValue = string.Empty;


                dt.Columns.Add(Col_SupplierCd, typeof(string));//�d����R�[�h
                dt.Columns[Col_SupplierCd].DefaultValue = string.Empty;


                dt.Columns.Add(Col_PartySlipNumDtl, typeof(string));//�`�[�ԍ�
                dt.Columns[Col_PartySlipNumDtl].DefaultValue = string.Empty;


                dt.Columns.Add(Col_SupplierSlipNo, typeof(string));//�d��SEQ�ԍ�
                dt.Columns[Col_SupplierSlipNo].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SeqNo, typeof(string));//�ʔ�
                dt.Columns[Col_SeqNo].DefaultValue = string.Empty;


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

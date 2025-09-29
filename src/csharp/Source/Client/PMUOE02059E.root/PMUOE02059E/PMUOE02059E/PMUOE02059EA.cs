using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �����f�[�^�ꗗ�\ �����[�g���o���ʃN���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����f�[�^�ꗗ�\�̃����[�g���o���ʂ�ێ�����B</br>
    /// <br>Programmer : 30452 ��� �r��</br>
    /// <br>Date       : 2008.12.02</br>
    /// <br>           : </br>
    /// </remarks>
    public class PMUOE02059EA
    {
        #region �� Public�萔
        // �e�[�u������
        public const string ct_Tbl_RecoveryDataOrder = "ct_Tbl_RecoveryDataOrder";

        // ���_�R�[�h
        public const string ct_Col_SectionCode = "SectionCode";
        // ���_�K�C�h����
        public const string ct_Col_SectionGuideSnm = "SectionGuideSnm";

        // UOE������R�[�h
        public const string ct_Col_UOESupplierCd = "UOESupplierCd";
        // UOE�����於��
        public const string ct_Col_UOESupplierName = "UOESupplierName";
        // �I�����C���ԍ�
        public const string ct_Col_OnlineNo = "OnlineNo";
        // ���i�ԍ�
        public const string ct_Col_GoodsNo = "GoodsNo";
        // ���i����
        public const string ct_Col_GoodsName = "GoodsName";
        // ���i���[�J�[�R�[�h
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        // �󒍐���
        public const string ct_Col_AcceptAnOrderCnt = "AcceptAnOrderCnt";
        // BO�敪
        public const string ct_Col_BoCode = "BoCode";
        // �t�n�d���}�[�N�P
        public const string ct_Col_UoeRemark1 = "UoeRemark1";
        // �f�[�^���M�敪
        public const string ct_Col_DataSendCode = "DataSendCode";
        // �I�����C���s�ԍ�
        public const string ct_Col_OnlineRowNo = "OnlineRowNo";
        // �V�X�e���敪
        public const string ct_Col_SystemDivCd = "SystemDivCd";

        // �����[�g���o���ʈȊO�̍���
        // ���o����
        public const string ct_Col_ExtractCondition = "ExtractCondition";
        // �V�X�e���敪����
        public const string ct_Col_SystemDivName = "SystemDivName";
        // �G���[���e(�f�[�^���M�敪����)
        public const string ct_Col_DataSendName = "DataSendName";

        #endregion

        #region �� �R���X�g���N�^
        /// <summary>
        ///  �R���X�g���N�^
        /// </summary>
        public PMUOE02059EA()
        {
        }

        #endregion

        #region �� public���\�b�h
        /// <summary>
        /// �����f�[�^�ꗗ�\DataSet�e�[�u���X�L�[�}�ݒ�
        /// </summary>
        /// <param name="dt">�ݒ�Ώۃf�[�^�e�[�u��</param>
        /// <remarks>
        /// <br>Note       : �����f�[�^�ꗗ�\�f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.12.02</br>
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
                dt = new DataTable(ct_Tbl_RecoveryDataOrder);

                // ���_�R�[�h
                dt.Columns.Add(ct_Col_SectionCode, typeof(string));
                dt.Columns[ct_Col_SectionCode].DefaultValue = string.Empty;

                // ���_�K�C�h����
                dt.Columns.Add(ct_Col_SectionGuideSnm, typeof(string));
                dt.Columns[ct_Col_SectionGuideSnm].DefaultValue = string.Empty;

                // UOE������R�[�h
                dt.Columns.Add(ct_Col_UOESupplierCd, typeof(Int32));
                dt.Columns[ct_Col_UOESupplierCd].DefaultValue = 0;

                // UOE�����於��
                dt.Columns.Add(ct_Col_UOESupplierName, typeof(string));
                dt.Columns[ct_Col_UOESupplierName].DefaultValue = string.Empty;

                // �I�����C���ԍ�
                dt.Columns.Add(ct_Col_OnlineNo, typeof(Int32));
                dt.Columns[ct_Col_OnlineNo].DefaultValue = 0;

                // ���i�ԍ�
                dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
                dt.Columns[ct_Col_GoodsNo].DefaultValue = string.Empty;

                // ���i����
                dt.Columns.Add(ct_Col_GoodsName, typeof(string));
                dt.Columns[ct_Col_GoodsName].DefaultValue = string.Empty;

                // ���i���[�J�[�R�[�h
                dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(Int32));
                dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = 0;

                // �󒍐���
                dt.Columns.Add(ct_Col_AcceptAnOrderCnt, typeof(double));
                dt.Columns[ct_Col_AcceptAnOrderCnt].DefaultValue = 0;

                // BO�敪
                dt.Columns.Add(ct_Col_BoCode, typeof(string));
                dt.Columns[ct_Col_BoCode].DefaultValue = string.Empty;

                // �t�n�d���}�[�N�P
                dt.Columns.Add(ct_Col_UoeRemark1, typeof(string));
                dt.Columns[ct_Col_UoeRemark1].DefaultValue = string.Empty;

                // �f�[�^���M�敪
                dt.Columns.Add(ct_Col_DataSendCode, typeof(Int32));
                dt.Columns[ct_Col_DataSendCode].DefaultValue = 0;

                // �I�����C���s�ԍ�
                dt.Columns.Add(ct_Col_OnlineRowNo, typeof(Int32));
                dt.Columns[ct_Col_OnlineRowNo].DefaultValue = 0;

                // �V�X�e���敪
                dt.Columns.Add(ct_Col_SystemDivCd, typeof(Int32));
                dt.Columns[ct_Col_SystemDivCd].DefaultValue = 0;

                // ���o����
                dt.Columns.Add(ct_Col_ExtractCondition, typeof(string));
                dt.Columns[ct_Col_ExtractCondition].DefaultValue = string.Empty;
                
                // �V�X�e���敪����
                dt.Columns.Add(ct_Col_SystemDivName, typeof(string));
                dt.Columns[ct_Col_SystemDivName].DefaultValue = string.Empty;
                
                // �G���[���e(�f�[�^���M�敪����)
                dt.Columns.Add(ct_Col_DataSendName, typeof(string));
                dt.Columns[ct_Col_DataSendName].DefaultValue = string.Empty;
            }
        }
        #endregion
    }
}

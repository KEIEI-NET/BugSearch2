using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// ���s�m�F�ꗗ�\�p�e�[�u���X�L�[�}��`�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���s�m�F�ꗗ�\�p�e�[�u���X�L�[�}�N���X�̒�`�E�������y�уC���X�^���X�������s���B</br>
    /// <br>Programmer : 30009 �a�J ���</br>
    /// <br>Date       : 2008.12.02</br>
    /// <br>Programmer : 30009 �a�J ���</br>
    /// <br>Date       : 2009.01.13</br>
    /// <br></br>
    /// </remarks>
	public class PMUOE02049EA
	{
		# region Public Const

        /// <summary> �e�[�u������ </summary>
        public const string ct_Tbl_PublicationConfDtl  = "Tbl_PublicationConfDtl";

        /// <summary> ���_�R�[�h </summary>
        public const string ct_Col_SectionCode         = "SectionCode";

        /// <summary> ���_�K�C�h���� </summary>
        public const string ct_Col_SectionGuideNm      = "SectionGuideNm";

        /// <summary> �I�����C���ԍ� </summary>
        public const string ct_Col_OnlineNo            = "OnlineNo";

        /// <summary> �I�����C���s�ԍ� </summary>
        public const string ct_Col_OnlineRowNo         = "OnlineRowNo";

        /// <summary> �V�X�e���敪 </summary>
        public const string ct_Col_SystemDivCd         = "SystemDivCd";

        /// <summary> �V�X�e���敪���� </summary>
        public const string ct_Col_SystemDivName       = "SystemDivName";

        /// <summary> ���i�ԍ� </summary>
        public const string ct_Col_GoodsNo             = "GoodsNo";

        /// <summary> �q�ɃR�[�h </summary>
        public const string ct_Col_WarehouseCode       = "WarehouseCode";

        /// <summary> �q�ɒI�� </summary>
        public const string ct_Col_WarehouseShelfNo    = "WarehouseShelfNo";

        /// <summary> �艿�i�����j </summary>
        public const string ct_Col_ListPrice           = "ListPrice";

        /// <summary> �󒍐��� </summary>
        public const string ct_Col_AcceptAnOrderCnt    = "AcceptAnOrderCnt";

        /// <summary> UOE���_�o�ɐ� </summary>
        public const string ct_Col_UOESectOutGoodsCnt  = "UOESectOutGoodsCnt";

        /// <summary> BO�o�ɐ�1 </summary>
        public const string ct_Col_BOShipmentCnt1      = "BOShipmentCnt1";

        /// <summary> BO�o�ɐ�2 </summary>
        public const string ct_Col_BOShipmentCnt2      = "BOShipmentCnt2";

        /// <summary> BO�o�ɐ�3 </summary>
        public const string ct_Col_BOShipmentCnt3      = "BOShipmentCnt3";

        /// <summary> ���[�J�[�t�H���[�� </summary>
        public const string ct_Col_MakerFollowCnt      = "MakerFollowCnt";

        /// <summary> EO������ </summary>
        public const string ct_Col_EOAlwcCount         = "EOAlwcCount";

        /// <summary> UOE�����於�� </summary>
        public const string ct_Col_UOESupplierName     = "UOESupplierName";

        /// <summary> ��M���t </summary>
        public const string ct_Col_ReceiveDate         = "ReceiveDate";

        /// <summary> �t�n�d���}�[�N1 </summary>
        public const string ct_Col_UoeRemark1          = "UoeRemark1";

        /// <summary> �t�n�d���}�[�N2 </summary>
        public const string ct_Col_UoeRemark2          = "UoeRemark2";

        /// <summary> �񓚕i�� </summary>
        public const string ct_Col_AnswerPartsNo       = "AnswerPartsNo";

        /// <summary> �񓚕i�� </summary>
        public const string ct_Col_AnswerPartsName     = "AnswerPartsName";

        /// <summary> �񓚒艿 </summary>
        public const string ct_Col_AnswerListPrice     = "AnswerListPrice";

        /// <summary> �񓚌����P�� </summary>
        public const string ct_Col_AnswerSalesUnitCost = "AnswerSalesUnitCost";

        /// <summary> UOE���_�`�[�ԍ� </summary>
        public const string ct_Col_UOESectionSlipNo    = "UOESectionSlipNo";

        /// <summary> BO�`�[�ԍ�1 </summary>
        public const string ct_Col_BOSlipNo1           = "BOSlipNo1";

        /// <summary> BO�`�[�ԍ�2 </summary>
        public const string ct_Col_BOSlipNo2           = "BOSlipNo2";

        /// <summary> BO�`�[�ԍ�3 </summary>
        public const string ct_Col_BOSlipNo3           = "BOSlipNo3";

        /// <summary> BO�Ǘ��ԍ� </summary>
        public const string ct_Col_BOManagementNo      = "BOManagementNo";

        /// <summary> �`�F�b�N���e���� </summary>
        public const string ct_Col_CheckCntsNm         = "CheckCntsNm";

        /// <summary> �t���[�J�����P </summary>
        public const string ct_Col_FreeColumn1         = "FreeColumn1";

        /// <summary> �t���[�J�����P���� </summary>
        public const string ct_Col_FreeColumn1Nm       = "FreeColumn1Nm";

        /// <summary> �t���[�J�����Q </summary>
        public const string ct_Col_FreeColumn2         = "FreeColumn2";

        /// <summary> �t���[�J�����Q���� </summary>
        public const string ct_Col_FreeColumn2Nm       = "FreeColumn2Nm";

        
        
        // --- DataTable���ڃt�H�[�}�b�g�`�� --- //
        /// <summary>���� �\���p���t�t�H�[�}�b�g</summary>
        public const string ct_DateFomat = "YYYY/MM/DD";
        # endregion Public Const

        # region Constructor
        /// <summary>
		/// ���s�m�F�ꗗ�\�p�e�[�u���X�L�[�}��`�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���s�m�F�ꗗ�\�p�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���B</br>
        /// <br>Programmer : 30009 �a�J ���</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
		public PMUOE02049EA()
		{
		}
		# endregion

		# region Static Public Method
		/// <summary>
		/// ���s�m�F�ꗗ�\DataSet�e�[�u���X�L�[�}�ݒ�
		/// </summary>
		/// <param name="ds">�ݒ�Ώۃf�[�^�Z�b�g</param>
		/// <remarks>
		/// <br>Note       : ���s�m�F�ꗗ�\�f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
        /// <br>Programmer : 30009 �a�J ���</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
        static public void CreateDataTablePublicationConfDtl(ref DataSet ds)
		{
			if ( ds == null )
				ds = new DataSet();

			// �e�[�u�������݂��邩�ǂ����̃`�F�b�N
            if (ds.Tables.Contains(ct_Tbl_PublicationConfDtl))
			{
				// �e�[�u�������݂���Ƃ��̓N���A�[����̂݁B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                ds.Tables[ct_Tbl_PublicationConfDtl].Clear();
			}
			else
			{
				// �X�L�[�}�ݒ�
                ds.Tables.Add(ct_Tbl_PublicationConfDtl);
                DataTable dt = ds.Tables[ct_Tbl_PublicationConfDtl];

                dt.Columns.Add(ct_Col_SectionCode, typeof(string));         // ���_�R�[�h
                dt.Columns[ct_Col_SectionCode].DefaultValue = "";

                dt.Columns.Add(ct_Col_SectionGuideNm, typeof(string));      // ���_����
                dt.Columns[ct_Col_SectionGuideNm].DefaultValue = "";

                dt.Columns.Add(ct_Col_OnlineNo, typeof(int));               // �I�����C���ԍ�
                dt.Columns[ct_Col_OnlineNo].DefaultValue = 0;

                dt.Columns.Add(ct_Col_OnlineRowNo, typeof(int));	    	// �I�����C���s�ԍ�
                dt.Columns[ct_Col_OnlineRowNo].DefaultValue = 0;

                dt.Columns.Add(ct_Col_SystemDivName, typeof(string));		// �V�X�e���敪
                dt.Columns[ct_Col_SystemDivName].DefaultValue = "";

                dt.Columns.Add(ct_Col_SystemDivCd, typeof(int));			// �V�X�e���敪
                dt.Columns[ct_Col_SystemDivCd].DefaultValue = 0;

                dt.Columns.Add(ct_Col_GoodsNo, typeof(string));             // ���i�ԍ�
                dt.Columns[ct_Col_GoodsNo].DefaultValue = "";

                dt.Columns.Add(ct_Col_WarehouseCode, typeof(string));       // �q�ɃR�[�h
                dt.Columns[ct_Col_WarehouseCode].DefaultValue = "";

                dt.Columns.Add(ct_Col_WarehouseShelfNo, typeof(string));    // �q�ɒI��
                dt.Columns[ct_Col_WarehouseShelfNo].DefaultValue = "";

                dt.Columns.Add(ct_Col_ListPrice, typeof(double));           // �艿�i�����j
                dt.Columns[ct_Col_ListPrice].DefaultValue = 0;

                dt.Columns.Add(ct_Col_AcceptAnOrderCnt, typeof(double));    // �󒍐���
                dt.Columns[ct_Col_AcceptAnOrderCnt].DefaultValue = 0;

                dt.Columns.Add(ct_Col_UOESectOutGoodsCnt, typeof(int));     // UOE���_�o�ɐ�
                dt.Columns[ct_Col_UOESectOutGoodsCnt].DefaultValue = 0;

                dt.Columns.Add(ct_Col_BOShipmentCnt1, typeof(int));         // BO�o�ɐ�1
                dt.Columns[ct_Col_BOShipmentCnt1].DefaultValue = 0;

                dt.Columns.Add(ct_Col_BOShipmentCnt2, typeof(int));         // BO�o�ɐ�2
                dt.Columns[ct_Col_BOShipmentCnt2].DefaultValue = 0;

                dt.Columns.Add(ct_Col_BOShipmentCnt3, typeof(int));         // BO�o�ɐ�3
                dt.Columns[ct_Col_BOShipmentCnt3].DefaultValue = 0;

                dt.Columns.Add(ct_Col_MakerFollowCnt, typeof(int));         // ���[�J�[�t�H���[��
                dt.Columns[ct_Col_MakerFollowCnt].DefaultValue = 0;

                dt.Columns.Add(ct_Col_EOAlwcCount, typeof(int));            // EO������
                dt.Columns[ct_Col_EOAlwcCount].DefaultValue = 0;

                dt.Columns.Add(ct_Col_UOESupplierName, typeof(string));     // UOE�����於��
                dt.Columns[ct_Col_UOESupplierName].DefaultValue = "";

                dt.Columns.Add(ct_Col_ReceiveDate, typeof(DateTime));            // ��M���t
                dt.Columns[ct_Col_ReceiveDate].DefaultValue = DateTime.MinValue;

                dt.Columns.Add(ct_Col_UoeRemark1, typeof(string));          // �t�n�d���}�[�N1
                dt.Columns[ct_Col_UoeRemark1].DefaultValue = "";

                dt.Columns.Add(ct_Col_UoeRemark2, typeof(string));          // �t�n�d���}�[�N2
                dt.Columns[ct_Col_UoeRemark2].DefaultValue = "";

                dt.Columns.Add(ct_Col_AnswerPartsNo, typeof(string));       // �񓚕i��
                dt.Columns[ct_Col_AnswerPartsNo].DefaultValue = "";

                dt.Columns.Add(ct_Col_AnswerPartsName, typeof(string));     // �񓚕i��
                dt.Columns[ct_Col_AnswerPartsName].DefaultValue = "";

                dt.Columns.Add(ct_Col_AnswerListPrice, typeof(double));     // �񓚒艿
                dt.Columns[ct_Col_AnswerListPrice].DefaultValue = 0;

                dt.Columns.Add(ct_Col_AnswerSalesUnitCost, typeof(double)); // �񓚌����P��
                dt.Columns[ct_Col_AnswerSalesUnitCost].DefaultValue = 0;

                dt.Columns.Add(ct_Col_UOESectionSlipNo, typeof(string));    // UOE���_�`�[�ԍ�
                dt.Columns[ct_Col_UOESectionSlipNo].DefaultValue = "";

                dt.Columns.Add(ct_Col_BOSlipNo1, typeof(string));           // BO�`�[�ԍ�1
                dt.Columns[ct_Col_BOSlipNo1].DefaultValue = "";

                dt.Columns.Add(ct_Col_BOSlipNo2, typeof(string));           // BO�`�[�ԍ�2
                dt.Columns[ct_Col_BOSlipNo2].DefaultValue = "";

                dt.Columns.Add(ct_Col_BOSlipNo3, typeof(string));           // BO�`�[�ԍ�3
                dt.Columns[ct_Col_BOSlipNo3].DefaultValue = "";

                dt.Columns.Add(ct_Col_BOManagementNo, typeof(string));      // BO�Ǘ��ԍ�
                dt.Columns[ct_Col_BOManagementNo].DefaultValue = "";

                dt.Columns.Add(ct_Col_CheckCntsNm, typeof(string));  �@     // �`�F�b�N���e����
                dt.Columns[ct_Col_CheckCntsNm].DefaultValue = "";

                dt.Columns.Add(ct_Col_FreeColumn1, typeof(string));         // �t���[�J�����P
                dt.Columns[ct_Col_FreeColumn1].DefaultValue = "";

                dt.Columns.Add(ct_Col_FreeColumn1Nm, typeof(string));       // �t���[�J�����P����
                dt.Columns[ct_Col_FreeColumn1Nm].DefaultValue = "";

                dt.Columns.Add(ct_Col_FreeColumn2, typeof(string));         // �t���[�J�����Q
                dt.Columns[ct_Col_FreeColumn2].DefaultValue = "";

                dt.Columns.Add(ct_Col_FreeColumn2Nm, typeof(string));       // �t���[�J�����Q����
                dt.Columns[ct_Col_FreeColumn2Nm].DefaultValue = "";

			}
		}

		/// <summary>
        /// �V�X�e���敪���̎擾����
		/// </summary>
        /// <param name="systemDivCd">�V�X�e���敪</param>
        /// <returns>�V�X�e���敪����</returns>
		/// <remarks>
        /// <br>Note       : �V�X�e���敪���̂̎擾���s���܂��B</br>
        /// <br>Programmer : 30009 �a�J ���</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
        static public string GetSystemDivNm(int systemDivCd)
        {
            string systemDivNm = "";
            switch (systemDivCd)
            {
                // 2009.01.13 UPD �s�v�ȋ敪�̍폜>>>>>>>>>>>>>>>>>>>>>>>>>>>
                case 0: systemDivNm = "�����"; break;
                case 1: systemDivNm = "�`��"; break;
                case 2: systemDivNm = "����"; break;
                case 3: systemDivNm = "�ꊇ"; break;
                case 4: systemDivNm = "��["; break;
                //case 9: systemDivNm = "�S��"; break;
                case 9: systemDivNm = "�`���ȊO"; break;
                // 2009.01.13 UPD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            }
            return systemDivNm;
        }

        # endregion
	}
}

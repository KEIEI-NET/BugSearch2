using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ���ɗ\��\�e�[�u���X�L�[�}��`�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���ɗ\��\�e�[�u���X�L�[�}�N���X�̒�`�E�������y�уC���X�^���X�������s���B</br>
    /// <br>Programmer : 30413 ����</br>
    /// <br>Date       : 2008.12.03</br>
    /// <br>Note       : �n���f�B�^�[�~�i���񎟊J���̑Ή�</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2017/09/14</br>
    /// </remarks>
    public class EnterSchResult
    {

        /// <summary> �e�[�u������ </summary>
        public const string Col_Tbl_Result_EnterSch = "Tbl_Result_EnterSch";

        /// <summary> ���_�R�[�h </summary>
        public const string Col_SectionCode = "SectionCode";

        /// <summary> ���_�K�C�h���� </summary>
        public const string Col_SectionGuideSnm = "SectionGuideSnm";

        /// <summary> �q�ɃR�[�h </summary>
        public const string Col_WarehouseCode = "WarehouseCode";

        /// <summary> �q�ɖ��� </summary>
        public const string Col_WarehouseName = "WarehouseName";

        /// <summary> �q�ɒI�� </summary>
        public const string Col_WarehouseShelfNo = "WarehouseShelfNo";

        /// <summary> ���i�ԍ� </summary>
        public const string Col_GoodsNo = "GoodsNo";

        /// <summary> ���i���[�J�[�R�[�h </summary>
        public const string Col_GoodsMakerCd = "GoodsMakerCd";

        /// <summary> ���i���� </summary>
        public const string Col_GoodsName = "GoodsName";

        /// <summary> �󒍐��� </summary>
        public const string Col_AcceptAnOrderCnt = "AcceptAnOrderCnt";

        /// <summary> UOE���_�o�ɐ� </summary>
        public const string Col_UOESectOutGoodsCnt = "UOESectOutGoodsCnt";

        /// <summary> BO�o�ɐ�1 </summary>
        public const string Col_BOShipmentCnt1 = "BOShipmentCnt1";

        /// <summary> BO�o�ɐ�2 </summary>
        public const string Col_BOShipmentCnt2 = "BOShipmentCnt2";

        /// <summary> BO�o�ɐ�3 </summary>
        public const string Col_BOShipmentCnt3 = "BOShipmentCnt3";

        /// <summary> ���[�J�[�t�H���[�� </summary>
        public const string Col_MakerFollowCnt = "MakerFollowCnt";

        /// <summary> EO������ </summary>
        public const string Col_EOAlwcCount = "EOAlwcCount";

        /// <summary> �񓚒艿 </summary>
        public const string Col_AnswerListPrice = "AnswerListPrice";

        /// <summary> �񓚌����P�� </summary>
        public const string Col_AnswerSalesUnitCost = "AnswerSalesUnitCost";

        /// <summary> �d����R�[�h </summary>
        public const string Col_SupplierCd = "SupplierCd";

        /// <summary> BO�`�[�ԍ��P </summary>
        public const string Col_BOSlipNo1 = "BOSlipNo1";

        /// <summary> BO�`�[�ԍ��Q </summary>
        public const string Col_BOSlipNo2 = "BOSlipNo2";

        /// <summary> BO�`�[�ԍ��R </summary>
        public const string Col_BOSlipNo3 = "BOSlipNo3";

        /// <summary> UOE���_�`�[�ԍ� </summary>
        public const string Col_UOESectionSlipNo = "UOESectionSlipNo";

        /// <summary> �t�n�d���}�[�N�P </summary>
        public const string Col_UoeRemark1 = "UoeRemark1";

        /// <summary> �t�n�d���}�[�N�Q </summary>
        public const string Col_UoeRemark2 = "UoeRemark2";

        /// <summary> ��M���t </summary>
        public const string Col_ReceiveDate = "ReceiveDate";

        // ------ ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- >>>>
        /// <summary> �d��SEQ�ԍ�(�o�[�R�[�h���p) </summary>
        public const string ct_Col_SupplierSeqNoForBarCode = "SupplierSeqNoForBarCode";
        // ------ ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- <<<<

        // ��������p
        /// <summary> ���ɐ�(����p) </summary>
        public const string Col_OutGoodsCnt_Print = "OutGoodsCnt_Print";
        /// <summary> BO��(����p) </summary>
        public const string Col_BOCnt_Print = "BOCnt_Print";
        /// <summary> �d���`�[�ԍ�(����p) </summary>
        public const string Col_SlipNo_Print = "SlipNo_Print";

        /// <summary>
		/// ���ɗ\��\�e�[�u���X�L�[�}��`�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ����\��\�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���B</br>
		/// <br>Programmer : 30413 ����</br>
		/// <br>Date       : 2008.12.03</br>
		/// </remarks>
        public EnterSchResult()
		{
		}

        /// <summary>
		/// DataSet�e�[�u���X�L�[�}�ݒ�
		/// </summary>
		/// <param name="ds">�ݒ�Ώۃf�[�^�Z�b�g</param>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.12.03</br>
        /// </remarks>
        static public void CreateDataTableResultEnterSch(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // �e�[�u�������݂��邩�ǂ����̃`�F�b�N
            if (ds.Tables.Contains(Col_Tbl_Result_EnterSch))
            {
                // �e�[�u�������݂���Ƃ��̓N���A�[����̂݁B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                ds.Tables[Col_Tbl_Result_EnterSch].Clear();
            }
            else
            {
                // �X�L�[�}�ݒ�
                ds.Tables.Add(Col_Tbl_Result_EnterSch);

                DataTable dt = ds.Tables[Col_Tbl_Result_EnterSch];

                string defValuestring = "";
                Int32 defValueInt32 = 0;
                double defValueDouble = 0.0;

                dt.Columns.Add(Col_SectionCode, typeof(string));                    // ���_�R�[�h
                dt.Columns[Col_SectionCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SectionGuideSnm, typeof(string));                // ���_�K�C�h����
                dt.Columns[Col_SectionGuideSnm].DefaultValue = defValuestring;

                dt.Columns.Add(Col_WarehouseCode, typeof(string));                  // �q�ɃR�[�h
                dt.Columns[Col_WarehouseCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_WarehouseName, typeof(string));                  // �q�ɖ���
                dt.Columns[Col_WarehouseName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_WarehouseShelfNo, typeof(string));               // �q�ɒI��
                dt.Columns[Col_WarehouseShelfNo].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsNo, typeof(string));                        // ���i�ԍ�
                dt.Columns[Col_GoodsNo].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsMakerCd, typeof(Int32));                    // ���i���[�J�[�R�[�h
                dt.Columns[Col_GoodsMakerCd].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_GoodsName, typeof(string));                      // ���i����
                dt.Columns[Col_GoodsName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_AcceptAnOrderCnt, typeof(Double));               // �󒍐���
                dt.Columns[Col_AcceptAnOrderCnt].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_UOESectOutGoodsCnt, typeof(Int32));              // UOE���_�o�ɐ�
                dt.Columns[Col_UOESectOutGoodsCnt].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_BOShipmentCnt1, typeof(Int32));                  // BO�o�ɐ�1
                dt.Columns[Col_BOShipmentCnt1].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_BOShipmentCnt2, typeof(Int32));                  // BO�o�ɐ�2
                dt.Columns[Col_BOShipmentCnt2].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_BOShipmentCnt3, typeof(Int32));                  // BO�o�ɐ�3
                dt.Columns[Col_BOShipmentCnt3].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_MakerFollowCnt, typeof(Int32));                  // ���[�J�[�t�H���[��
                dt.Columns[Col_MakerFollowCnt].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_EOAlwcCount, typeof(Int32));                     // EO������
                dt.Columns[Col_EOAlwcCount].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_AnswerListPrice, typeof(Double));                // �񓚒艿
                dt.Columns[Col_AnswerListPrice].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_AnswerSalesUnitCost, typeof(Double));            // �񓚌����P��
                dt.Columns[Col_AnswerSalesUnitCost].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_SupplierCd, typeof(Int32));                      // �d����R�[�h
                dt.Columns[Col_SupplierCd].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_BOSlipNo1, typeof(string));                      // BO�`�[�ԍ��P
                dt.Columns[Col_BOSlipNo1].DefaultValue = defValuestring;

                dt.Columns.Add(Col_BOSlipNo2, typeof(string));                      // BO�`�[�ԍ��Q
                dt.Columns[Col_BOSlipNo2].DefaultValue = defValuestring;

                dt.Columns.Add(Col_BOSlipNo3, typeof(string));                      // BO�`�[�ԍ��R
                dt.Columns[Col_BOSlipNo3].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UOESectionSlipNo, typeof(string));               // UOE���_�`�[�ԍ�
                dt.Columns[Col_UOESectionSlipNo].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UoeRemark1, typeof(string));                     // �t�n�d���}�[�N�P
                dt.Columns[Col_UoeRemark1].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UoeRemark2, typeof(string));                     // �t�n�d���}�[�N�Q
                dt.Columns[Col_UoeRemark2].DefaultValue = defValuestring;

                dt.Columns.Add(Col_ReceiveDate, typeof(string));                    // ��M���t
                dt.Columns[Col_ReceiveDate].DefaultValue = defValuestring;

                // ------ ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- >>>>
                dt.Columns.Add(ct_Col_SupplierSeqNoForBarCode, typeof(string)); // �d���`�[�ԍ�
                dt.Columns[ct_Col_SupplierSeqNoForBarCode].DefaultValue = defValuestring;
                // ------ ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- <<<<

                // ��������p
                dt.Columns.Add(Col_OutGoodsCnt_Print, typeof(Int32));               // ���ɐ�(����p)
                dt.Columns[Col_OutGoodsCnt_Print].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_BOCnt_Print, typeof(Int32));                     // BO��(����p)
                dt.Columns[Col_BOCnt_Print].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_SlipNo_Print, typeof(string));                   // �d���`�[�ԍ�(����p)
                dt.Columns[Col_SlipNo_Print].DefaultValue = defValuestring;
            }
        }
    }
}

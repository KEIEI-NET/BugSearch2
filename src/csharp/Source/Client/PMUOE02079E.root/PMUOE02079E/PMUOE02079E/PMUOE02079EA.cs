using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �d����ϯ�ؽăe�[�u���X�L�[�}��`�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d����ϯ�ؽăe�[�u���X�L�[�}�N���X�̒�`�E�������y�уC���X�^���X�������s���B</br>
    /// <br>Programmer : 30413 ����</br>
    /// <br>Date       : 2008.12.17</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class SupplierUnmResult
    {

        /// <summary> �e�[�u������ </summary>
        public const string Col_Tbl_Result_SupplierUnm = "Tbl_Result_SupplierUnm";

         /// <summary> ���_�R�[�h </summary>
        public const string Col_SectionCode = "SectionCode";

        /// <summary> ���_�K�C�h���� </summary>
        public const string Col_SectionGuideSnm = "SectionGuideSnm";

        /// <summary> �d����R�[�h </summary>
        public const string Col_SupplierCd = "SupplierCd";

        /// <summary> �d���旪�� </summary>
        public const string Col_SupplierSnm = "SupplierSnm";

        /// <summary> ������t </summary>
        public const string Col_SalesDate = "SalesDate";

        /// <summary> ���i�ԍ� </summary>
        public const string Col_GoodsNo = "GoodsNo";

        /// <summary> ���i���� </summary>
        public const string Col_GoodsName = "GoodsName";

        /// <summary> �󒍐��� </summary>
        public const string Col_AcceptAnOrderCnt = "AcceptAnOrderCnt";

        /// <summary> BO�敪 </summary>
        public const string Col_BoCode = "BoCode";

        /// <summary> �񓚒艿 </summary>
        public const string Col_AnswerListPrice = "AnswerListPrice";

        /// <summary> �񓚌����P�� </summary>
        public const string Col_AnswerSalesUnitCost = "AnswerSalesUnitCost";

        /// <summary> UOE�����ԍ� </summary>
        public const string Col_UOESalesOrderNo = "UOESalesOrderNo";

        /// <summary> �V�X�e���敪 </summary>
        public const string Col_SystemDivCd = "SystemDivCd";

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

        /// <summary> UOE���_�`�[�ԍ� </summary>
        public const string Col_UOESectionSlipNo = "UOESectionSlipNo";
        
        /// <summary> BO�`�[�ԍ��P </summary>
        public const string Col_BOSlipNo1 = "BOSlipNo1";

        /// <summary> BO�`�[�ԍ��Q </summary>
        public const string Col_BOSlipNo2 = "BOSlipNo2";

        /// <summary> BO�`�[�ԍ��R </summary>
        public const string Col_BOSlipNo3 = "BOSlipNo3";

        /// <summary> EO������ </summary>
        public const string Col_EOAlwcCount = "EOAlwcCount";

        // ����p
        /// <summary> ��M���t(����p) </summary>
        public const string Col_SalesDate_Print = "SalesDate_Print";

        /// <summary> �V�X�e���敪(����p) </summary>
        public const string Col_SystemDivCd_Print = "SystemDivCd_Print";

        /// <summary> ���� </summary>
        public const string Col_QTY = "QTY";

        /// <summary> ���e </summary>
        public const string Col_Contents = "Contents";

        /// <summary>
        /// �d����ϯ�ؽăe�[�u���X�L�[�}��`�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �d����ϯ�ؽăe�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���B</br>
		/// <br>Programmer : 30413 ����</br>
		/// <br>Date       : 2008.12.17</br>
		/// </remarks>
        public SupplierUnmResult()
		{
		}

        /// <summary>
		/// DataSet�e�[�u���X�L�[�}�ݒ�
		/// </summary>
		/// <param name="ds">�ݒ�Ώۃf�[�^�Z�b�g</param>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.12.17</br>
        /// </remarks>
        static public void CreateDataTableResultSupplierUnm(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // �e�[�u�������݂��邩�ǂ����̃`�F�b�N
            if (ds.Tables.Contains(Col_Tbl_Result_SupplierUnm))
            {
                // �e�[�u�������݂���Ƃ��̓N���A�[����̂݁B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                ds.Tables[Col_Tbl_Result_SupplierUnm].Clear();
            }
            else
            {
                // �X�L�[�}�ݒ�
                ds.Tables.Add(Col_Tbl_Result_SupplierUnm);

                DataTable dt = ds.Tables[Col_Tbl_Result_SupplierUnm];

                string defValuestring = "";
                Int32 defValueInt32 = 0;
                Int64 defValueInt64 = 0;
                double defValueDouble = 0.0;

                dt.Columns.Add(Col_SectionCode, typeof(string));                    // ���_�R�[�h
                dt.Columns[Col_SectionCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SectionGuideSnm, typeof(string));                // ���_�K�C�h����
                dt.Columns[Col_SectionGuideSnm].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SupplierCd, typeof(Int32));                      // �d����R�[�h
                dt.Columns[Col_SupplierCd].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_SupplierSnm, typeof(string));                    // �d���旪��
                dt.Columns[Col_SupplierSnm].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SalesDate, typeof(DateTime));                    // ������t
                dt.Columns[Col_SalesDate].DefaultValue = DateTime.MinValue;

                dt.Columns.Add(Col_GoodsNo, typeof(string));                        // ���i�ԍ�
                dt.Columns[Col_GoodsNo].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsName, typeof(string));                      // ���i����
                dt.Columns[Col_GoodsName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_AcceptAnOrderCnt, typeof(Double));               // �󒍐���
                dt.Columns[Col_AcceptAnOrderCnt].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_BoCode, typeof(string));                         // BO�敪
                dt.Columns[Col_BoCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_AnswerListPrice, typeof(Double));                // �񓚒艿
                dt.Columns[Col_AnswerListPrice].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_AnswerSalesUnitCost, typeof(Double));            // �񓚌����P��
                dt.Columns[Col_AnswerSalesUnitCost].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_UOESalesOrderNo, typeof(Int32));                 // UOE�����ԍ�
                dt.Columns[Col_UOESalesOrderNo].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_SystemDivCd, typeof(Int32));                     // �V�X�e���敪
                dt.Columns[Col_SystemDivCd].DefaultValue = defValueInt32;

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

                dt.Columns.Add(Col_UOESectionSlipNo, typeof(string));               // UOE���_�`�[�ԍ�
                dt.Columns[Col_UOESectionSlipNo].DefaultValue = defValuestring;
                
                dt.Columns.Add(Col_BOSlipNo1, typeof(string));                      // BO�`�[�ԍ��P
                dt.Columns[Col_BOSlipNo1].DefaultValue = defValuestring;

                dt.Columns.Add(Col_BOSlipNo2, typeof(string));                      // BO�`�[�ԍ��Q
                dt.Columns[Col_BOSlipNo2].DefaultValue = defValuestring;

                dt.Columns.Add(Col_BOSlipNo3, typeof(string));                      // BO�`�[�ԍ��R
                dt.Columns[Col_BOSlipNo3].DefaultValue = defValuestring;

                dt.Columns.Add(Col_EOAlwcCount, typeof(Int32));                     // EO������
                dt.Columns[Col_EOAlwcCount].DefaultValue = defValueInt32;
                
                // ����p
                dt.Columns.Add(Col_SalesDate_Print, typeof(string));                // ������t(����p)
                dt.Columns[Col_SalesDate_Print].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SystemDivCd_Print, typeof(string));              // �V�X�e���敪(����p)
                dt.Columns[Col_SystemDivCd_Print].DefaultValue = defValuestring;

                dt.Columns.Add(Col_QTY, typeof(Int32));                             // ����
                dt.Columns[Col_QTY].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_Contents, typeof(string));                       // ���e
                dt.Columns[Col_Contents].DefaultValue = defValuestring;

            }
        }
    }
}

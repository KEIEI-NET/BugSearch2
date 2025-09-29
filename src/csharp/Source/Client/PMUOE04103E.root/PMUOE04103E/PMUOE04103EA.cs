using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �����񓚏��e�[�u���X�L�[�}��`�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����񓚏��e�[�u���X�L�[�}�N���X�̒�`�E�������y�уC���X�^���X�������s���B</br>
    /// <br>Programmer : �Ɠc �M�u</br>
    /// <br>Date       : 2008/11/06</br>
    /// <br>UpdateNote : 2008/12/18 �Ɠc �M�u�@�o�O�C���A�d�l�ύX�Ή�</br>
    /// <br>             �@�z���_�̕\�����@�ύX</br>
    /// <br></br>
    /// <br>UpdateNote : 2012/07/13 30517 �Ė� �x��</br>
    /// <br>             �d�������������_�ȉ��\���\�ɏC��</br>
    /// </remarks>
    public class PMUOE04103EA
    {
        #region ��Public�萔
        /// <summary> �e�[�u������(������P��) </summary>
        public const string ct_Tbl_OrderAnsSupplier = "Tbl_OrderAnsSupplier";
        /// <summary> �e�[�u������(���גP��) </summary>
        public const string ct_Tbl_OrderAnsDetail = "Tbl_OrderAnsDetail";
        /// <summary> ���ׂ̃O���[�v���� </summary>
        public const string ct_Grp_OrderAnsDeltail = "Grp_OrderAnsDetail";

        // ������(���׈ȊO)���
        /// <summary> ������ </summary>
        public const string ct_Col_SalesDate = "SalesDate";
        /// <summary> �����ԍ� </summary>
        public const string ct_Col_UOESalesOrderNo = "UOESalesOrderNo";
        /// <summary> UOE�����於�� </summary>
        public const string ct_Col_UOESupplierName = "UOESupplierName";
        /// <summary> UOE���}�[�N1 </summary>
        public const string ct_Col_UoeRemark1 = "UoeRemark1";
        /// <summary> UOE���}�[�N2 </summary>
        public const string ct_Col_UoeRemark2 = "UoeRemark2";
        /// <summary> �[�i�敪���� </summary>
        public const string ct_Col_DeliveredGoodsDivNm = "DeliveredGoodsDivNm";
        /// <summary> �t�H���[�[�i�敪���� </summary>
        public const string ct_Col_FollowDeliGoodsDivNm = "FollowDeliGoodsDivNm";
        /// <summary> ���_ </summary>
        public const string ct_Col_UOEResvdSectionNm = "UOEResvdSectionNm";
        /// <summary> �˗��� </summary>
        public const string ct_Col_EmployeeName = "EmployeeName";
        /// <summary> �O���b�h�w�b�_�[�ϖ���1 </summary>
        public const string ct_Col_GridHeadVariableName1 = "GridHeadVariableName1";
        /// <summary> �O���b�h�w�b�_�[�ϖ���2 </summary>
        public const string ct_Col_GridHeadVariableName2 = "GridHeadVariableName2";
        /// <summary> �O���b�h�w�b�_�[�ϖ���3 </summary>
        public const string ct_Col_GridHeadVariableName3 = "GridHeadVariableName3";
        /// <summary> �O���b�h�w�b�_�[�ϖ���4 </summary>
        public const string ct_Col_GridHeadVariableName4 = "GridHeadVariableName4";
        /// <summary> �O���b�h�w�b�_�[�ϖ���5 </summary>
        public const string ct_Col_GridHeadVariableName5 = "GridHeadVariableName5";
        /// <summary> �O���b�h�w�b�_�[�ϖ���6 </summary>
        public const string ct_Col_GridHeadVariableName6 = "GridHeadVariableName6";
        /// <summary> �O���b�h�w�b�_�[�o�א�����1(�ϖ���1�ɑΉ�) </summary>
        public const string ct_Col_GridHeadShipmentCntName1 = "GridHeadShipmentCntName1";
        /// <summary> �O���b�h�w�b�_�[�o�א�����2(�ϖ���2�ɑΉ�) </summary>
        public const string ct_Col_GridHeadShipmentCntName2 = "GridHeadShipmentCntName2";
        /// <summary> �O���b�h�w�b�_�[�o�א�����3(�ϖ���3�ɑΉ�) </summary>
        public const string ct_Col_GridHeadShipmentCntName3 = "GridHeadShipmentCntName3";
        /// <summary> �O���b�h�w�b�_�[�o�א�����4(�ϖ���4�ɑΉ�) </summary>
        public const string ct_Col_GridHeadShipmentCntName4 = "GridHeadShipmentCntName4";
        /// <summary> �O���b�h�w�b�_�[�o�א�����5(�ϖ���5�ɑΉ�) </summary>
        public const string ct_Col_GridHeadShipmentCntName5 = "GridHeadShipmentCntName5";
        /// <summary> �V�X�e���敪���� </summary>
        public const string ct_Col_SystemDivName = "SystemDivName";

        // ���׏��(�O���b�h�p)
        /// <summary> UOE�����s�ԍ� </summary>
        public const string ct_Col_UOESalesOrderRowNo = "UOESalesOrderRowNo";
        /// <summary> ��֕i�� </summary>
        public const string ct_Col_SubstPartsNo = "SubstPartsNo";
        /// <summary> �i�� </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> ���[�J�[ </summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary> ��1 </summary>
        public const string ct_Col_Blank1 = "Blank1";
        /// <summary> �艿 </summary>
        public const string ct_Col_ListPrice = "ListPrice";
        /// <summary> ���_�`�[ </summary>
        public const string ct_Col_UOESectionSlipNo = "UOESectionSlipNo";
        /// <summary> BO�`�[1 </summary>
        public const string ct_Col_BOSlipNo1 = "BOSlipNo1";
        /// <summary> BO�`�[2 </summary>
        public const string ct_Col_BOSlipNo2 = "BOSlipNo2";
        /// <summary> BO�`�[3 </summary>
        public const string ct_Col_BOSlipNo3 = "BOSlipNo3";
        /// <summary> BO�Ǘ��ԍ� </summary>
        public const string ct_Col_BOManagementNo = "BOBOManagementNoNo";
        /// <summary> ��2 </summary>
        public const string ct_Col_Blank2 = "Blank2";
        /// <summary> ��� </summary>
        public const string ct_Col_UOESubstMark = "UOESubstMark";
        /// <summary> �R�����g���� </summary>
        public const string ct_Col_Comment = "Comment";
        /// <summary> �i�� </summary>
        public const string ct_Col_GoodsName = "GoodsName";
        /// <summary> �󒍐��� </summary>
        public const string ct_Col_AcceptAnOrderCnt = "AcceptAnOrderCnt";
        /// <summary> BO�敪 </summary>
        public const string ct_Col_BOCode = "BOCode";
        /// <summary> �����P�� </summary>
        public const string ct_Col_SalesUnitCost = "SalesUnitCost";
        /// <summary> UOE���_�o�ɐ� </summary>
        public const string ct_Col_UOESectOutGoodsCnt = "UOESectOutGoodsCnt";
        /// <summary> BO�o�ɐ�1 </summary>
        public const string ct_Col_BOShipmentCnt1 = "BOShipmentCnt1";
        /// <summary> BO�o�ɐ�2 </summary>
        public const string ct_Col_BOShipmentCnt2 = "BOShipmentCnt2";
        /// <summary> BO�o�ɐ�3 </summary>
        public const string ct_Col_BOShipmentCnt3 = "BOShipmentCnt3";
        /// <summary> EO������ </summary>
        public const string ct_Col_EOAlwcCount = "EOAlwcCount";
        /// <summary> ���[�J�[�t�H���[�� </summary>
        public const string ct_Col_MakerFollowCnt = "MakerFollowCnt";
        /// <summary> �c </summary>
        public const string ct_Col_RemainderCount = "RemainderCount";
        /// <summary> �q�ɁE�I�� </summary>
        public const string ct_Col_WarehouseShelfNo = "WarehouseShelfNo";
        /// <summary> �O�i�F </summary>
        public const string ct_Col_ForeColor = "ForeColor";
        #endregion

        #region �� Constructor
        /// <summary>
        /// �����񓚃O���b�h�p�e�[�u���X�L�[�}��`�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����񓚏��e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        public PMUOE04103EA()
        {
        }
        #endregion

        #region �� Public���\�b�h
        /// <summary>
        /// DataSet�e�[�u���X�L�[�}�ݒ�(������P��)
        /// </summary>
        /// <param name="dt">�ݒ�Ώۃf�[�^�e�[�u��</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        static public void CreateDataTableSupplier(ref DataTable dt)
        {
            // �e�[�u�������݂��邩�ǂ����̃`�F�b�N
            if (dt != null)
            {
                // �e�[�u�������݂���Ƃ��̓N���A�[�̂ݍs���B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                dt.Clear();
                return;
            }

            dt = new DataTable(ct_Tbl_OrderAnsSupplier);

            string defaultValueOfstring = string.Empty;

            // ������
            dt.Columns.Add(ct_Col_SalesDate, typeof(string));
            dt.Columns[ct_Col_SalesDate].DefaultValue = defaultValueOfstring;
            // �����ԍ�
            dt.Columns.Add(ct_Col_UOESalesOrderNo, typeof(string));
            dt.Columns[ct_Col_UOESalesOrderNo].DefaultValue = defaultValueOfstring;
            // UOE�����於��
            dt.Columns.Add(ct_Col_UOESupplierName, typeof(string));
            dt.Columns[ct_Col_UOESupplierName].DefaultValue = defaultValueOfstring;
            // UOE���}�[�N1
            dt.Columns.Add(ct_Col_UoeRemark1, typeof(string));
            dt.Columns[ct_Col_UoeRemark1].DefaultValue = defaultValueOfstring;
            // UOE���}�[�N2
            dt.Columns.Add(ct_Col_UoeRemark2, typeof(string));
            dt.Columns[ct_Col_UoeRemark2].DefaultValue = defaultValueOfstring;
            // �[�i�敪����
            dt.Columns.Add(ct_Col_DeliveredGoodsDivNm, typeof(string));
            dt.Columns[ct_Col_DeliveredGoodsDivNm].DefaultValue = defaultValueOfstring;
            // �t�H���[�[�i�敪����
            dt.Columns.Add(ct_Col_FollowDeliGoodsDivNm, typeof(string));
            dt.Columns[ct_Col_FollowDeliGoodsDivNm].DefaultValue = defaultValueOfstring;
            // ���_
            dt.Columns.Add(ct_Col_UOEResvdSectionNm, typeof(string));
            dt.Columns[ct_Col_UOEResvdSectionNm].DefaultValue = defaultValueOfstring;
            // �˗���
            dt.Columns.Add(ct_Col_EmployeeName, typeof(string));
            dt.Columns[ct_Col_EmployeeName].DefaultValue = defaultValueOfstring;
            // �O���b�h�w�b�_�[�ϖ���1
            dt.Columns.Add(ct_Col_GridHeadVariableName1, typeof(string));
            dt.Columns[ct_Col_GridHeadVariableName1].DefaultValue = defaultValueOfstring;
            // �O���b�h�w�b�_�[�ϖ���2
            dt.Columns.Add(ct_Col_GridHeadVariableName2, typeof(string));
            dt.Columns[ct_Col_GridHeadVariableName2].DefaultValue = defaultValueOfstring;
            // �O���b�h�w�b�_�[�ϖ���3
            dt.Columns.Add(ct_Col_GridHeadVariableName3, typeof(string));
            dt.Columns[ct_Col_GridHeadVariableName3].DefaultValue = defaultValueOfstring;
            // �O���b�h�w�b�_�[�ϖ���4
            dt.Columns.Add(ct_Col_GridHeadVariableName4, typeof(string));
            dt.Columns[ct_Col_GridHeadVariableName4].DefaultValue = defaultValueOfstring;
            // �O���b�h�w�b�_�[�ϖ���5
            dt.Columns.Add(ct_Col_GridHeadVariableName5, typeof(string));
            dt.Columns[ct_Col_GridHeadVariableName5].DefaultValue = defaultValueOfstring;
            // �O���b�h�w�b�_�[�ϖ���6
            dt.Columns.Add(ct_Col_GridHeadVariableName6, typeof(string));
            dt.Columns[ct_Col_GridHeadVariableName6].DefaultValue = defaultValueOfstring;
            // �O���b�h�w�b�_�[�o�א�����1
            dt.Columns.Add(ct_Col_GridHeadShipmentCntName1, typeof(string));
            dt.Columns[ct_Col_GridHeadShipmentCntName1].DefaultValue = defaultValueOfstring;
            // �O���b�h�w�b�_�[�o�א�����2
            dt.Columns.Add(ct_Col_GridHeadShipmentCntName2, typeof(string));
            dt.Columns[ct_Col_GridHeadShipmentCntName2].DefaultValue = defaultValueOfstring;
            // �O���b�h�w�b�_�[�o�א�����3
            dt.Columns.Add(ct_Col_GridHeadShipmentCntName3, typeof(string));
            dt.Columns[ct_Col_GridHeadShipmentCntName3].DefaultValue = defaultValueOfstring;
            // �O���b�h�w�b�_�[�o�א�����4
            dt.Columns.Add(ct_Col_GridHeadShipmentCntName4, typeof(string));
            dt.Columns[ct_Col_GridHeadShipmentCntName4].DefaultValue = defaultValueOfstring;
            // �O���b�h�w�b�_�[�o�א�����5
            dt.Columns.Add(ct_Col_GridHeadShipmentCntName5, typeof(string));
            dt.Columns[ct_Col_GridHeadShipmentCntName5].DefaultValue = defaultValueOfstring;
            // �V�X�e���敪����
            dt.Columns.Add(ct_Col_SystemDivName, typeof(string));
            dt.Columns[ct_Col_SystemDivName].DefaultValue = defaultValueOfstring;
        }

        /// <summary>
        /// DataSet�e�[�u���X�L�[�}�ݒ�(���גP��)
        /// </summary>
        /// <param name="dt">�ݒ�Ώۃf�[�^�e�[�u��</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        static public void CreateDataTableDetail(ref DataTable dt)
        {
            // �e�[�u�������݂��邩�ǂ����̃`�F�b�N
            if (dt != null)
            {
                // �e�[�u�������݂���Ƃ��̓N���A�[�̂ݍs���B�X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                dt.Clear();
                return;
            }

            dt = new DataTable(ct_Tbl_OrderAnsDetail);

            string defaultValueOfstring = string.Empty;
            Int32 defaultValueOfInt32 = 0;
            Int64 defaultValueOfInt64 = 0;

            // �����s�ԍ�
            dt.Columns.Add(ct_Col_UOESalesOrderRowNo, typeof(Int32));
            dt.Columns[ct_Col_UOESalesOrderRowNo].DefaultValue = defaultValueOfInt32;
            // ��֕i��
            dt.Columns.Add(ct_Col_SubstPartsNo, typeof(string));
            dt.Columns[ct_Col_SubstPartsNo].DefaultValue = defaultValueOfstring;
            // �i��
            dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
            dt.Columns[ct_Col_GoodsNo].DefaultValue = defaultValueOfstring;
            // ���[�J�[
            dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(string));
            dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = defaultValueOfstring;
            // ��1
            dt.Columns.Add(ct_Col_Blank1, typeof(string));
            dt.Columns[ct_Col_Blank1].DefaultValue = defaultValueOfstring;
            // �艿
            dt.Columns.Add(ct_Col_ListPrice, typeof(Int64));
            dt.Columns[ct_Col_ListPrice].DefaultValue = defaultValueOfInt64;
            // ���_�`�[
            dt.Columns.Add(ct_Col_UOESectionSlipNo, typeof(string));
            dt.Columns[ct_Col_UOESectionSlipNo].DefaultValue = defaultValueOfstring;
            // BO�`�[1
            dt.Columns.Add(ct_Col_BOSlipNo1, typeof(string));
            dt.Columns[ct_Col_BOSlipNo1].DefaultValue = defaultValueOfstring;
            // BO�`�[2
            dt.Columns.Add(ct_Col_BOSlipNo2, typeof(string));
            dt.Columns[ct_Col_BOSlipNo2].DefaultValue = defaultValueOfstring;
            // BO�`�[3
            dt.Columns.Add(ct_Col_BOSlipNo3, typeof(string));
            dt.Columns[ct_Col_BOSlipNo3].DefaultValue = defaultValueOfstring;
            // BO�Ǘ��ԍ�
            dt.Columns.Add(ct_Col_BOManagementNo, typeof(string));
            dt.Columns[ct_Col_BOManagementNo].DefaultValue = defaultValueOfstring;
            // ��2
            dt.Columns.Add(ct_Col_Blank2, typeof(string));
            dt.Columns[ct_Col_Blank2].DefaultValue = defaultValueOfstring;
            // ���
            dt.Columns.Add(ct_Col_UOESubstMark, typeof(string));
            dt.Columns[ct_Col_UOESubstMark].DefaultValue = defaultValueOfstring;
            // �R�����g
            dt.Columns.Add(ct_Col_Comment, typeof(string));
            dt.Columns[ct_Col_Comment].DefaultValue = defaultValueOfstring;
            // �i��
            dt.Columns.Add(ct_Col_GoodsName, typeof(string));
            dt.Columns[ct_Col_GoodsName].DefaultValue = defaultValueOfstring;
            // ����
            dt.Columns.Add(ct_Col_AcceptAnOrderCnt, typeof(Int64));
            dt.Columns[ct_Col_AcceptAnOrderCnt].DefaultValue = defaultValueOfInt64;
            // BO�敪
            dt.Columns.Add(ct_Col_BOCode, typeof(string));
            dt.Columns[ct_Col_BOCode].DefaultValue = defaultValueOfstring;
            // �����P��
            // upd 2012/07/13 >>>
            //dt.Columns.Add(ct_Col_SalesUnitCost, typeof(Int64));
            //dt.Columns[ct_Col_SalesUnitCost].DefaultValue = defaultValueOfInt64;
            dt.Columns.Add(ct_Col_SalesUnitCost, typeof(Double));
            dt.Columns[ct_Col_SalesUnitCost].DefaultValue = 0.0;
            // upd 2012/07/13 <<<
            /* --- DEL 2008/12/18 �@ --------------------------------------------------->>>>>
            // UOE���_�o�ɐ�
            dt.Columns.Add(ct_Col_UOESectOutGoodsCnt, typeof(Int64));
            dt.Columns[ct_Col_UOESectOutGoodsCnt].DefaultValue = defaultValueOfInt64;
            // BO�o�ɐ�1
            dt.Columns.Add(ct_Col_BOShipmentCnt1, typeof(Int64));
            dt.Columns[ct_Col_BOShipmentCnt1].DefaultValue = defaultValueOfInt64;
            // BO�o�ɐ�2
            dt.Columns.Add(ct_Col_BOShipmentCnt2, typeof(Int64));
            dt.Columns[ct_Col_BOShipmentCnt2].DefaultValue = defaultValueOfInt64;
            // BO�o�ɐ�3
            dt.Columns.Add(ct_Col_BOShipmentCnt3, typeof(Int64));
            dt.Columns[ct_Col_BOShipmentCnt3].DefaultValue = defaultValueOfInt64;
            // EO������
            dt.Columns.Add(ct_Col_EOAlwcCount, typeof(Int64));
            dt.Columns[ct_Col_EOAlwcCount].DefaultValue = defaultValueOfInt64;
            // ���[�J�[�t�H���[��
            dt.Columns.Add(ct_Col_MakerFollowCnt, typeof(Int64));
            dt.Columns[ct_Col_MakerFollowCnt].DefaultValue = defaultValueOfInt64;
            // �c
            dt.Columns.Add(ct_Col_RemainderCount, typeof(Int64));
            dt.Columns[ct_Col_RemainderCount].DefaultValue = defaultValueOfInt64;
               --- DEL 2008/12/18 �@ ---------------------------------------------------<<<<< */
            // --- DEL 2008/12/18 �@ --------------------------------------------------->>>>> 
            // UOE���_�o�ɐ�
            dt.Columns.Add(ct_Col_UOESectOutGoodsCnt, typeof(string));
            dt.Columns[ct_Col_UOESectOutGoodsCnt].DefaultValue = defaultValueOfstring;
            // BO�o�ɐ�1
            dt.Columns.Add(ct_Col_BOShipmentCnt1, typeof(string));
            dt.Columns[ct_Col_BOShipmentCnt1].DefaultValue = defaultValueOfstring;
            // BO�o�ɐ�2
            dt.Columns.Add(ct_Col_BOShipmentCnt2, typeof(string));
            dt.Columns[ct_Col_BOShipmentCnt2].DefaultValue = defaultValueOfstring;
            // BO�o�ɐ�3
            dt.Columns.Add(ct_Col_BOShipmentCnt3, typeof(string));
            dt.Columns[ct_Col_BOShipmentCnt3].DefaultValue = defaultValueOfstring;
            // EO������
            dt.Columns.Add(ct_Col_EOAlwcCount, typeof(string));
            dt.Columns[ct_Col_EOAlwcCount].DefaultValue = defaultValueOfstring;
            // ���[�J�[�t�H���[��
            dt.Columns.Add(ct_Col_MakerFollowCnt, typeof(string));
            dt.Columns[ct_Col_MakerFollowCnt].DefaultValue = defaultValueOfstring;
            // �c
            dt.Columns.Add(ct_Col_RemainderCount, typeof(string));
            dt.Columns[ct_Col_RemainderCount].DefaultValue = defaultValueOfstring;
            // --- DEL 2008/12/18 �@ ---------------------------------------------------<<<<<
            // �q�ɁE�I��
            dt.Columns.Add(ct_Col_WarehouseShelfNo, typeof(string));
            dt.Columns[ct_Col_WarehouseShelfNo].DefaultValue = defaultValueOfstring;
            // �O�i�F
            dt.Columns.Add(ct_Col_ForeColor, typeof(string));
            dt.Columns[ct_Col_ForeColor].DefaultValue = defaultValueOfstring;
        }
        #endregion
    }
}

using System;
using System.Data;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// UOE�񓚁@�f�[�^�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : UOE�񓚕\���Ɋւ���e�[�u���X�L�[�}/�O���b�h�f�[�^�̒�`�E�������y�уC���X�^���X�������s���B</br>
    /// <br>Programmer : �Ɠc �M�u</br>
    /// <br>Date       : 2008/11/10</br>
    /// <br>             2008/12/10 �Ɠc �M�u�@BO�敪�̌^Int32��String�ύX</br>
    /// </remarks>
    public class PMUOE04202EA
    {
        #region ��Public�萔
        /// <summary> �e�[�u������(���׏��) </summary>
        public const string ct_Tbl_UOEReply = "Tbl_UOEReply";

        // ���׏��(�O���b�h�p)
        /// <summary> No </summary>
        public const string ct_Col_No = "No";
        /// <summary> �I�� </summary>
        public const string ct_Col_SelectFlg = "SelectFlg";
        /// <summary> ��M���� </summary>
        public const string ct_Col_ReceiveDate = "ReceiveDate";
        /// <summary> ��M���� </summary>
        public const string ct_Col_ReceiveTime = "ReceiveTime";
        /// <summary> �����񓚔ԍ� </summary>
        public const string ct_Col_UOESalesOrderNo = "UOESalesOrderNo";
        /// <summary> �����񓚍s�ԍ� </summary>
        public const string ct_Col_UOESalesOrderRowNo = "UOESalesOrderRowNo";
        /// <summary> ������R�[�h </summary>
        public const string ct_Col_UOESupplierCd = "UOESupplierCd";
        /// <summary> �����於�� </summary>
        public const string ct_Col_UOESupplierName = "UOESupplierName";
        /// <summary> UOE�[�i�敪 </summary>
        public const string ct_Col_UOEDeliGoodsDiv = "UOEDeliGoodsDiv";
        /// <summary> �t�H���[�[�i�敪 </summary>
        public const string ct_Col_FollowDeliGoodsDiv = "FollowDeliGoodsDiv";
        /// <summary> BO�敪 </summary>
        public const string ct_Col_BOCode = "BOCode";
        /// <summary> �˗��҃R�[�h </summary>
        public const string ct_Col_EmployeeCode = "EmployeeCode";
        /// <summary> �˗��Җ��� </summary>
        public const string ct_Col_EmployeeName = "EmployeeName";
        /// <summary> ���Ӑ�R�[�h </summary>
        public const string ct_Col_CustomerCode = "CustomerCode";
        /// <summary> ���Ӑ於�� </summary>
        public const string ct_Col_CustomerSnm = "CustomerSnm";
        /// <summary> �i�� </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> ���[�J�[ </summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary> �i�� </summary>
        public const string ct_Col_GoodsName = "GoodsName";
        /// <summary> ���}�[�N1 </summary>
        public const string ct_Col_UOERemark1 = "UOERemark1";
        /// <summary> ���}�[�N2 </summary>
        public const string ct_Col_UOERemark2 = "UOERemark2";
        /// <summary> �������� </summary>
        public const string ct_Col_AcceptAnOrderCnt = "AcceptAnOrderCnt";
        /// <summary> ���_�o�ɐ� </summary>
        public const string ct_Col_UOESectOutGoodsCnt = "UOESectOutGoodsCnt";
        /// <summary> ���_�`�[�ԍ� </summary>
        public const string ct_Col_UOESectionSlipNo = "UOESectionSlipNo";
        /// <summary> �t�H���[1 </summary>
        public const string ct_Col_BOShipmentCnt1 = "BOShipmentCnt1";
        /// <summary> �t�H���[�`�[�ԍ�1 </summary>
        public const string ct_Col_BOSlipNo1 = "BOSlipNo1";
        /// <summary> �t�H���[2 </summary>
        public const string ct_Col_BOShipmentCnt2 = "BOShipmentCnt2";
        /// <summary> �t�H���[�`�[�ԍ�2 </summary>
        public const string ct_Col_BOSlipNo2 = "BOSlipNo2";
        /// <summary> �t�H���[3 </summary>
        public const string ct_Col_BOShipmentCnt3 = "BOShipmentCnt3";
        /// <summary> �t�H���[�`�[�ԍ�3 </summary>
        public const string ct_Col_BOSlipNo3 = "BOSlipNo3";
        /// <summary> ���[�J�[�t�H���[�� </summary>
        public const string ct_Col_MakerFollowCnt = "MakerFollowCnt";
        /// <summary> �艿 </summary>
        public const string ct_Col_ListPrice = "ListPrice";
        /// <summary> �d�ؒP�� </summary>
        public const string ct_Col_SalesUnitCost = "SalesUnitCost";
        /// <summary> ��֋敪 </summary>
        public const string ct_Col_UOESubstMark = "UOESubstMark";
        /// <summary> �w��(���Y) </summary>
        public const string ct_Col_PartsLayerCd = "PartsLayerCd";
        /// <summary> EO�Ǘ��ԍ�(���Y) </summary>
        public const string ct_Col_BOManagementNo = "BOManagementNo";
        /// <summary> EO������(���Y) </summary>
        public const string ct_Col_EOAlwcCount = "EOAlwcCount";
        /// <summary> ���_�R�[�h(����) </summary>
        public const string ct_Col_MazdaUOEShipSectCd1 = "MazdaUOEShipSectCd1";
        /// <summary> �t�H���[�R�[�h1(����) </summary>
        public const string ct_Col_MazdaUOEShipSectCd2 = "MazdaUOEShipSectCd2";
        /// <summary> �t�H���[�R�[�h2(����) </summary>
        public const string ct_Col_MazdaUOEShipSectCd3 = "MazdaUOEShipSectCd3";
        /// <summary> �G���[���b�Z�[�W </summary>
        public const string ct_Col_LineErrorMessage = "LineErrorMessage";
        /// <summary> �o�׌��R�[�h(����) </summary>
        public const string ct_Col_SourceShipment = "SourceShipment";
        /// <summary> ���_�R�[�h(�����[�p����) </summary>
        public const string ct_Col_SectionCode = "SectionCode";
        /// <summary> ���_����(�����[�p����) </summary>
        public const string ct_Col_SectionName = "SectionName";
        /// <summary> �\�������F </summary>
        public const string ct_Col_ForeColor = "ForeColor";
        #endregion

        #region �� Constructor
        /// <summary>
        /// �񓚃O���b�h�p�e�[�u���X�L�[�}��`�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �񓚏��e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public PMUOE04202EA()
        {
        }
        #endregion

        #region �� Public���\�b�h
        /// <summary>
        /// DataSet�e�[�u���X�L�[�}�ݒ�(���גP��)
        /// </summary>
        /// <param name="dt">�ݒ�Ώۃf�[�^�e�[�u��</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̃X�L�[�}��ݒ肷��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
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

            dt = new DataTable(ct_Tbl_UOEReply);

            string defaultValueOfstring = string.Empty;
            double defaultValueOfDouble = 0;
            Int32 defaultValueOfInt32 = 0;
            bool defaultValueOfBool = false;

            #region �J�����ݒ�
            // No
            dt.Columns.Add(ct_Col_No, typeof(Int32));
            dt.Columns[ct_Col_No].DefaultValue = defaultValueOfInt32;
            // �I��
            dt.Columns.Add(ct_Col_SelectFlg, typeof(bool));
            dt.Columns[ct_Col_SelectFlg].DefaultValue = defaultValueOfBool;
            // ��M����
            dt.Columns.Add(ct_Col_ReceiveDate, typeof(string));
            dt.Columns[ct_Col_ReceiveDate].DefaultValue = defaultValueOfstring;
            // ��M����
            dt.Columns.Add(ct_Col_ReceiveTime, typeof(string));
            dt.Columns[ct_Col_ReceiveTime].DefaultValue = defaultValueOfstring;
            // �����񓚔ԍ�
            dt.Columns.Add(ct_Col_UOESalesOrderNo, typeof(string));
            dt.Columns[ct_Col_UOESalesOrderNo].DefaultValue = defaultValueOfstring;
            // �����񓚍s�ԍ�
            dt.Columns.Add(ct_Col_UOESalesOrderRowNo, typeof(Int32));
            dt.Columns[ct_Col_UOESalesOrderRowNo].DefaultValue = defaultValueOfInt32;
            // ������R�[�h
            dt.Columns.Add(ct_Col_UOESupplierCd, typeof(string));
            dt.Columns[ct_Col_UOESupplierCd].DefaultValue = defaultValueOfstring;
            // �����於��
            dt.Columns.Add(ct_Col_UOESupplierName, typeof(string));
            dt.Columns[ct_Col_UOESupplierName].DefaultValue = defaultValueOfstring;
            // UOE�[�i�敪
            dt.Columns.Add(ct_Col_UOEDeliGoodsDiv, typeof(string));
            dt.Columns[ct_Col_UOEDeliGoodsDiv].DefaultValue = defaultValueOfstring;
            // �t�H���[�[�i�敪
            dt.Columns.Add(ct_Col_FollowDeliGoodsDiv, typeof(string));
            dt.Columns[ct_Col_FollowDeliGoodsDiv].DefaultValue = defaultValueOfstring;
            // BO�敪
            /* ---DEL 2008/12/10 �^�ύX--------------------------------->>>>>
            //dt.Columns.Add(ct_Col_BOCode, typeof(Int32));
            //dt.Columns[ct_Col_BOCode].DefaultValue = defaultValueOfInt32;
               ---DEL 2008/12/10 �^�ύX---------------------------------<<<<< */
            // ---ADD 2008/12/10 --------------------------------------->>>>>
            dt.Columns.Add(ct_Col_BOCode, typeof(string));
            dt.Columns[ct_Col_BOCode].DefaultValue = defaultValueOfstring;
            // ---ADD 2008/12/10 ---------------------------------------<<<<<
            // �˗��҃R�[�h
            dt.Columns.Add(ct_Col_EmployeeCode, typeof(string));
            dt.Columns[ct_Col_EmployeeCode].DefaultValue = defaultValueOfstring;
            // �˗��Җ���
            dt.Columns.Add(ct_Col_EmployeeName, typeof(string));
            dt.Columns[ct_Col_EmployeeName].DefaultValue = defaultValueOfstring;
            // ���Ӑ�R�[�h
            dt.Columns.Add(ct_Col_CustomerCode, typeof(string));
            dt.Columns[ct_Col_CustomerCode].DefaultValue = defaultValueOfstring;
            // ���Ӑ於��
            dt.Columns.Add(ct_Col_CustomerSnm, typeof(string));
            dt.Columns[ct_Col_CustomerSnm].DefaultValue = defaultValueOfstring;
            // �i��
            dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
            dt.Columns[ct_Col_GoodsNo].DefaultValue = defaultValueOfstring;
            // ���[�J�[
            dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(string));
            dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = defaultValueOfstring;
            // �i��
            dt.Columns.Add(ct_Col_GoodsName, typeof(string));
            dt.Columns[ct_Col_GoodsName].DefaultValue = defaultValueOfstring;
            // ���}�[�N1
            dt.Columns.Add(ct_Col_UOERemark1, typeof(string));
            dt.Columns[ct_Col_UOERemark1].DefaultValue = defaultValueOfstring;
            // ���}�[�N2
            dt.Columns.Add(ct_Col_UOERemark2, typeof(string));
            dt.Columns[ct_Col_UOERemark2].DefaultValue = defaultValueOfstring;
            // ��������
            dt.Columns.Add(ct_Col_AcceptAnOrderCnt, typeof(Double));
            dt.Columns[ct_Col_AcceptAnOrderCnt].DefaultValue = defaultValueOfDouble;
            // ���_�o�ɐ�
            dt.Columns.Add(ct_Col_UOESectOutGoodsCnt, typeof(Int32));
            dt.Columns[ct_Col_UOESectOutGoodsCnt].DefaultValue = defaultValueOfInt32;
            // ���_�`�[�ԍ�
            dt.Columns.Add(ct_Col_UOESectionSlipNo, typeof(string));
            dt.Columns[ct_Col_UOESectionSlipNo].DefaultValue = defaultValueOfstring;
            // �t�H���[1
            dt.Columns.Add(ct_Col_BOShipmentCnt1, typeof(Int32));
            dt.Columns[ct_Col_BOShipmentCnt1].DefaultValue = defaultValueOfInt32;
            // �t�H���[�`�[�ԍ�1
            dt.Columns.Add(ct_Col_BOSlipNo1, typeof(string));
            dt.Columns[ct_Col_BOSlipNo1].DefaultValue = defaultValueOfstring;
            // �t�H���[2
            dt.Columns.Add(ct_Col_BOShipmentCnt2, typeof(Int32));
            dt.Columns[ct_Col_BOShipmentCnt2].DefaultValue = defaultValueOfInt32;
            // �t�H���[�`�[�ԍ�2
            dt.Columns.Add(ct_Col_BOSlipNo2, typeof(string));
            dt.Columns[ct_Col_BOSlipNo2].DefaultValue = defaultValueOfstring;
            // �t�H���[3
            dt.Columns.Add(ct_Col_BOShipmentCnt3, typeof(Int32));
            dt.Columns[ct_Col_BOShipmentCnt3].DefaultValue = defaultValueOfInt32;
            // �t�H���[�`�[�ԍ�3
            dt.Columns.Add(ct_Col_BOSlipNo3, typeof(string));
            dt.Columns[ct_Col_BOSlipNo3].DefaultValue = defaultValueOfstring;
            // ���[�J�[�t�H���[��
            dt.Columns.Add(ct_Col_MakerFollowCnt, typeof(Int32));
            dt.Columns[ct_Col_MakerFollowCnt].DefaultValue = defaultValueOfInt32;
            // �艿
            dt.Columns.Add(ct_Col_ListPrice, typeof(Double));
            dt.Columns[ct_Col_ListPrice].DefaultValue = defaultValueOfDouble;
            // �d�ؒP��
            dt.Columns.Add(ct_Col_SalesUnitCost, typeof(Double));
            dt.Columns[ct_Col_SalesUnitCost].DefaultValue = defaultValueOfDouble;
            // ��֋敪
            dt.Columns.Add(ct_Col_UOESubstMark, typeof(string));
            dt.Columns[ct_Col_UOESubstMark].DefaultValue = defaultValueOfstring;
            // �w��(���Y)
            dt.Columns.Add(ct_Col_PartsLayerCd, typeof(string));
            dt.Columns[ct_Col_PartsLayerCd].DefaultValue = defaultValueOfstring;
            // EO�Ǘ��ԍ�(���Y)
            dt.Columns.Add(ct_Col_BOManagementNo, typeof(string));
            dt.Columns[ct_Col_BOManagementNo].DefaultValue = defaultValueOfstring;
            // EO������(���Y)
            dt.Columns.Add(ct_Col_EOAlwcCount, typeof(Int32));
            dt.Columns[ct_Col_EOAlwcCount].DefaultValue = defaultValueOfInt32;
            // ���_�R�[�h(�}�c�_)
            dt.Columns.Add(ct_Col_MazdaUOEShipSectCd1, typeof(string));
            dt.Columns[ct_Col_MazdaUOEShipSectCd1].DefaultValue = defaultValueOfstring;
            // �t�H���[�R�[�h1(�}�c�_)
            dt.Columns.Add(ct_Col_MazdaUOEShipSectCd2, typeof(string));
            dt.Columns[ct_Col_MazdaUOEShipSectCd2].DefaultValue = defaultValueOfstring;
            // �t�H���[�R�[�h2(�}�c�_)
            dt.Columns.Add(ct_Col_MazdaUOEShipSectCd3, typeof(string));
            dt.Columns[ct_Col_MazdaUOEShipSectCd3].DefaultValue = defaultValueOfstring;
            // �G���[���b�Z�[�W
            dt.Columns.Add(ct_Col_LineErrorMessage, typeof(string));
            dt.Columns[ct_Col_LineErrorMessage].DefaultValue = defaultValueOfstring;
            // �o�׌��R�[�h(�z���_)
            dt.Columns.Add(ct_Col_SourceShipment, typeof(string));
            dt.Columns[ct_Col_SourceShipment].DefaultValue = defaultValueOfstring;
            // ���_�R�[�h(�����[�p����)
            dt.Columns.Add(ct_Col_SectionCode, typeof(string));
            dt.Columns[ct_Col_SectionCode].DefaultValue = defaultValueOfstring;
            // ���_����(�����[�p����)
            dt.Columns.Add(ct_Col_SectionName, typeof(string));
            dt.Columns[ct_Col_SectionName].DefaultValue = defaultValueOfstring;
            // �\�������F
            dt.Columns.Add(ct_Col_ForeColor, typeof(string));
            dt.Columns[ct_Col_ForeColor].DefaultValue = defaultValueOfstring;
            #endregion

            // ��L�[�ݒ�
            dt.PrimaryKey = new DataColumn[] { dt.Columns[ct_Col_No]};
        }
        #endregion
    }
}

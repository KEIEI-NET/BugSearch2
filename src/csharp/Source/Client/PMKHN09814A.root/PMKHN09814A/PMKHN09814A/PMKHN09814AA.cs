//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �|���}�X�^�i�G�N�X�|�[�g�j
// �v���O�����T�v   : �|���}�X�^�i�G�N�X�|�[�g�j���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  ********-** �쐬�S�� : FSI���� �f��
// �� �� ��  2013/06/12  �C�����e : �T�|�[�g�c�[���Ή��A�V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�               �쐬�S�� : K.Miura
// �C �� ��  2015/10/14   �C�����e : �N���X���d���̂��ߕύX 
//                                   StockMasWork �� RateTextWork
//                                   IStockMasDB �� IRateTextDB
//                                   MediationStockMasDB �� MediationRateTextDB
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�               �쐬�S�� : ���V�@���M
// �C �� ��  2015/10/14   �C�����e : �N���X���d���̂��ߕύX 
//                                   StockMasExportAcs �� RateTextExportAcs
//                                   StockMasShWork �� RateTextShWork
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �|���}�X�^�i�G�N�X�|�[�g�j�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �|���}�X�^�i�G�N�X�|�[�g�j�C���X�^���X�̍쐬���s���B</br>
    /// <br>Programmer : FSI���� �f��</br>
    /// <br>Date       : 2013/06/12</br>
    /// </remarks>
// --- CHG  2015/10/14 ���V�@���M --- >>>>
//  public class StockMasExportAcs
    public class RateTextExportAcs
// --- CHG  2015/10/14 ���V�@���M --- <<<<
    {
        #region �� Private Member
        private const string PRINTSET_TABLE = "StockMasExp";

        /// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
// --- CHG  2015/10/14 K.Miura --- >>>>
        //Remoting.IStockMasDB _stockMasDB = null;
        IRateTextDB _rateTextDB = null;
// --- CHG  2015/10/14 K.Miura --- <<<<

        /// <summary>�d����}�X�^�A�N�Z�X�N���X</summary>
        private SupplierAcs _supplierAcs;

        /// <summary>�d����}�X�^�L���b�V��</summary>
        private Dictionary<int,Supplier> _supplierDic;

        #endregion

        # region ��Constracter
        /// <summary>
        /// �|���}�X�^�i�G�N�X�|�[�g�j�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �݌Ƀ}�X�^�i�e�L�X�g�ϊ��j�A�N�Z�X�N���X�B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        public RateTextExportAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
// --- CHG  2015/10/14 K.Miura --- >>>>
//              this._stockMasDB = (IStockMasDB)MediationStockMasDB.GetStockMasDB();
                this._rateTextDB = (IRateTextDB)MediationRateTextDB.GetRateTextDB();
// --- CHG  2015/10/14 K.Miura --- <<<<
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._rateTextDB = null;
            }

            // �d����A�N�Z�X�N���X
            _supplierAcs = new SupplierAcs();

        }
        # endregion

        #region �� �d����}�X�^��񌟍�
        /// <summary>
        /// �|���}�X�^�i�G�N�X�|�[�g�j�}�X�^�f�[�^�擾����
        /// </summary>
        /// <param name="condition">��������</param>
        /// <param name="dataTable">�����f�[�^</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �|���}�X�^�i�G�N�X�|�[�g�j�}�X�^�f�[�^�擾�������s���B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
// --- CHG  2015/10/14 ���V�@���M --- >>>>
//      public int Search(UIData.StockMasShWork condition, out DataTable dataTable)
        public int Search(UIData.RateTextShWork condition, out DataTable dataTable)
// --- CHG  2015/10/14 ���V�@���M --- <<<<
        {
            int status = 0;
            ArrayList retList = null;
            dataTable = new DataTable(PRINTSET_TABLE);

            // DataTable��Columns��ǉ�����
            CreateDataTable(ref dataTable);
            // ����
            status = SearchProc(out retList, condition);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �������ʂ�ConvertToDataTable
                ConverToDataSetStockMasInf(retList, condition, ref dataTable);
            }
            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            return status;
        }
        # endregion

        #region �� Private Methods

        /// <summary>
        /// �|���}�X�^�i�G�N�X�|�[�g�j�e�L�X�g�f�[�^��������
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevSupplier��null�̏ꍇ�̂ݖ߂�)</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="prevSupplier">�O��ŏI�S���҃f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �|���}�X�^�̌����������s���܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
// --- CHG  2015/10/14 ���V�@���M --- >>>
//      private int SearchProc(out ArrayList retList, UIData.StockMasShWork condition)
        private int SearchProc(out ArrayList retList, UIData.RateTextShWork condition)
// --- CHG  2015/10/14 ���V�@���M --- <<<<
        {

            // ������
            retList = new ArrayList();
            //retTotalCnt = 0;

            // Search�p�����[�^
            ArrayList paraList = new ArrayList();

            // ���������Z�b�g
// --- CHG  2015/10/14 K.Miura --- >>>>
//          StockMasWork stockMasWorkSt = new StockMasWork();
//          StockMasWork stockMasWorkEd = new StockMasWork();
            RateTextWork rateTextWorkSt = new RateTextWork();
            RateTextWork rateTextWorkEd = new RateTextWork();
// --- CHG  2015/10/14 K.Miura --- <<<<


            // �J�n
            rateTextWorkSt.EnterpriseCode = condition.EnterpriseCode;     //��ƃR�[�h
            rateTextWorkSt.SectionCode = condition.SectionCodeSt;         //���_�R�[�h�i�J�n�j
            rateTextWorkSt.WarehouseCd = condition.WarehouseCdSt;       //�P�����

            // �I��
            rateTextWorkEd.SectionCode = condition.SectionCodeEd;         //���_�R�[�h�i�I���j

            // Search�p�����[�^
            paraList.Add(rateTextWorkSt);
            paraList.Add(rateTextWorkEd);

            object paraobj = paraList;

            // ����
            object retobj = null;

            int status_o = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // �����[�g
            status_o = this._rateTextDB.Search(out retobj, paraobj, 0, 0);

            // �������ʔ���
            switch (status_o)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                    if (retobj != null)
                    {

                        retList = (ArrayList)retobj;

                    }
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    status_o = (int)ConstantManagement.DB_Status.ctDB_EOF;
                    break;
                default:
                    return status_o;
            }

            return status_o;
        }

 
        /// <summary>
        /// DataTable��Columns��ǉ�����
        /// </summary>
        /// <param name="dataTable">����DataTable</param>
        /// <remarks>
        /// <br>Note       : DataTable��Columns��ǉ�����B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void CreateDataTable(ref DataTable dataTable)
        {
            dataTable.Columns.Add("enterpriseCode", typeof(string));           // ��ƃR�[�h
            dataTable.Columns.Add("���_�R�[�h", typeof(string));               // ���_�R�[�h
            dataTable.Columns.Add("�P���|���ݒ�敪", typeof(string));         // �P���|���ݒ�敪
            dataTable.Columns.Add("�P�����", typeof(string));                 // �P�����
            dataTable.Columns.Add("�|���ݒ�敪", typeof(string));             // �|���ݒ�敪
            dataTable.Columns.Add("�|���ݒ�敪(���i)", typeof(string));       // �|���ݒ�敪(���i)
            dataTable.Columns.Add("�|���ݒ薼��(���i)", typeof(string));       // �|���ݒ薼��(���i)
            dataTable.Columns.Add("�|���ݒ�敪(���Ӑ�)", typeof(string));     // �|���ݒ�敪(���Ӑ�)
            dataTable.Columns.Add("�|���ݒ薼��(���Ӑ�)", typeof(string));     // �|���ݒ薼��(���Ӑ�)
            dataTable.Columns.Add("���i���[�J�[�R�[�h", typeof(string));       // ���i���[�J�[�R�[�h
            dataTable.Columns.Add("���i�ԍ�", typeof(string));                 // ���i�ԍ�
            dataTable.Columns.Add("���i�|�������N", typeof(string));           // ���i�|�������N
            dataTable.Columns.Add("���i�|���O���[�v�R�[�h", typeof(string));   // ���i�|���O���[�v�R�[�h
            dataTable.Columns.Add("BL�O���[�v�R�[�h", typeof(string));         // BL�O���[�v�R�[�h
            dataTable.Columns.Add("BL���i�R�[�h", typeof(string));             // BL���i�R�[�h
            dataTable.Columns.Add("���Ӑ�R�[�h", typeof(string));             // ���Ӑ�R�[�h
            dataTable.Columns.Add("���Ӑ�|���O���[�v�R�[�h", typeof(string)); // ���Ӑ�|���O���[�v�R�[�h
            dataTable.Columns.Add("�d����R�[�h", typeof(string));             // �d����R�[�h
            dataTable.Columns.Add("���b�g��", typeof(string));                 // ���b�g��
            dataTable.Columns.Add("���i(����)", typeof(string));               // ���i(����)
            dataTable.Columns.Add("�|��", typeof(string));                     // �|��
            dataTable.Columns.Add("UP��", typeof(string));                     // UP��
            dataTable.Columns.Add("�e���m�ۗ�", typeof(string));               // �e���m�ۗ�
            dataTable.Columns.Add("�P���[�������P��", typeof(string));         // �P���[�������P��
            dataTable.Columns.Add("�P���[�������敪", typeof(string));         // �P���[�������敪
        }

        /// <summary>
        /// �������ʂ�ConvertToDataTable
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="postcardEnvelopeDMWork">��������</param>
        /// <param name="dataTable">����</param>
        /// <remarks>
        /// <br>Note       : �������ʂ�ConvertToDataTable�ɍs���B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
// --- CHG  2015/10/14 ���V�@���M --- >>>>
//      private void ConverToDataSetStockMasInf(ArrayList retList, UIData.StockMasShWork StockMasShWork, ref DataTable dataTable)
        private void ConverToDataSetStockMasInf(ArrayList retList, UIData.RateTextShWork rateTextShWork, ref DataTable dataTable)
// --- CHG  2015/10/14 ���V�@���M --- <<<<
        {
            _supplierDic = new Dictionary<int, Supplier>();

// --- CHG  2015/10/14 K.Miura --- >>>>
//          foreach (StockMasWork work in retList)
            foreach (RateTextWork work in retList)
// --- CHG  2015/10/14 K.Miura --- <<<<
            {
                DataRow dataRow = dataTable.NewRow();

                SetValue(ref dataRow, "enterpriseCode", work.EnterpriseCode, 0, 0);            // ��ƃR�[�h              (string)
                SetValue(ref dataRow, "���_�R�[�h", work.SectionCode, 0, 0);                   // ���_�R�[�h              (string)
                SetValue(ref dataRow, "�P���|���ݒ�敪", work.UnitRateSetDivCd, 0, 0);        // �P���|���ݒ�敪        (string)
                SetValue(ref dataRow, "�P�����", work.UnitPriceKind, 0, 0);                   // �P�����                (string)
                SetValue(ref dataRow, "�|���ݒ�敪", work.RateSettingDivide, 0, 0);           // �|���ݒ�敪            (string)
                SetValue(ref dataRow, "�|���ݒ�敪(���i)", work.RateMngGoodsCd, 0, 0);        // �|���ݒ�敪(���i)      (string)
                SetValue(ref dataRow, "�|���ݒ薼��(���i)", work.RateMngGoodsNm, 0, 0);        // �|���ݒ薼��(���i)      (string)
                SetValue(ref dataRow, "�|���ݒ�敪(���Ӑ�)", work.RateMngCustCd, 0, 0);       // �|���ݒ�敪(���Ӑ�)    (string)
                SetValue(ref dataRow, "�|���ݒ薼��(���Ӑ�)", work.RateMngCustNm, 0, 0);       // �|���ݒ薼��(���Ӑ�)    (string)
                SetValue(ref dataRow, "���i���[�J�[�R�[�h", work.GoodsMakerCd, 6, 0);          // ���i���[�J�[�R�[�h      (Int32)
                SetValue(ref dataRow, "���i�ԍ�", work.GoodsNo, 0, 0);                         // ���i�ԍ�                (string)
                SetValue(ref dataRow, "���i�|�������N", work.GoodsRateRank, 0, 0);             // ���i�|�������N          (string)
                SetValue(ref dataRow, "���i�|���O���[�v�R�[�h", work.GoodsRateGrpCode, 4, 0);  // ���i�|���O���[�v�R�[�h  (Int32)
                SetValue(ref dataRow, "BL�O���[�v�R�[�h", work.BLGroupCode, 5, 0);             // BL�O���[�v�R�[�h        (Int32)
                SetValue(ref dataRow, "BL���i�R�[�h", work.BLGoodsCode, 8, 0);                 // BL���i�R�[�h            (Int32)
                SetValue(ref dataRow, "���Ӑ�R�[�h", work.CustomerCode, 9, 0);                // ���Ӑ�R�[�h            (Int32)
                SetValue(ref dataRow, "���Ӑ�|���O���[�v�R�[�h", work.CustRateGrpCode, 4, 0); // ���Ӑ�|���O���[�v�R�[�h(Int32)
                SetValue(ref dataRow, "�d����R�[�h", work.SupplierCd, 9, 0);                  // �d����R�[�h            (Int32)
                SetValue(ref dataRow, "���b�g��", work.LotCount, 7, 2);                        // ���b�g��                (Double)
                SetValue(ref dataRow, "���i(����)", work.PriceFl, 9, 2);                       // ���i(����)              (Double)
                SetValue(ref dataRow, "�|��", work.RateVal, 6, 2);                             // �|��                    (Double)
                SetValue(ref dataRow, "UP��", work.UpRate, 3, 2);                              // UP��                    (Double)
                SetValue(ref dataRow, "�e���m�ۗ�", work.GrsProfitSecureRate, 2, 2);           // �e���m�ۗ�              (Double)
                SetValue(ref dataRow, "�P���[�������P��", work.UnPrcFracProcUnit, 6, 2);       // �P���[�������P��        (Double)
                SetValue(ref dataRow, "�P���[�������敪", work.UnPrcFracProcDiv, 2, 0);        // �P���[�������敪        (Int32)

                dataTable.Rows.Add(dataRow);
            }
        }

        /// <summary>
        /// ���ʊi�[�pDataRow�ɒl��ݒ�
        /// </summary>
        /// <param name="dataRow">�l��ݒ肷��DataRow</param>
        /// <param name="key">�ݒ肷��l�̃L�[</param>
        /// <param name="value">�ݒ肷��l</param>
        /// <param name="length">�ݒ肷��l�����l�������ꍇ�̏o�͌���</param>
        /// <param name="length">�ݒ肷��l��Double�^�������ꍇ�̏����_�ȉ��o�͌���</param>
        /// <remarks>
        /// <br>Note       : AppendZero�s���B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void SetValue(ref DataRow dataRow, string key, object value, int length, int pointLength)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }
            if (null == value)
            {
                dataRow[key] = string.Empty;
            }
            else if (value is string)
            {
                string stringVal = value as string;
                if (!string.IsNullOrEmpty(stringVal))
                {
                    // �J���}�̕����ϊ�
                    stringVal = stringVal.Replace(
                        Properties.Resources.OldStringComma, Properties.Resources.NewStringComma);
                    // �_�u���N�H�[�e�[�V�����̕����ϊ�
                    stringVal = stringVal.Replace(
                        Properties.Resources.OldStringDQuotation, Properties.Resources.NewStringDQuotation);
                    // �G���}�[�N�̕����ϊ�
                    if (!string.IsNullOrEmpty(Properties.Resources.OldStringYen))
                    {
                        stringVal = stringVal.Replace(
                            Properties.Resources.OldStringYen, Properties.Resources.NewStringYen);
                    }
                }
                dataRow[key] = stringVal;
            }
            else if ((value is double) || (value is Double))
            {
                double dVal = Convert.ToDouble(value);
                bool neg = dVal < 0;
                int len = neg ? length - 1 : length;
                dVal = Math.Abs(dVal); // ��Βl���擾
                string outFormat = new string('0', len); // �������̌������w�肷��
                if (pointLength > 0)
                {
                    // �������̃t�H�[�}�b�g���������ǋL����
                    outFormat += "." + new string('0', pointLength);
                }
                string valueString = dVal.ToString(outFormat);

                // �����ӂ�`�F�b�N
                int pos = valueString.IndexOf('.');
                if (pos > len)
                {
                    valueString = valueString.Substring(pos - len, len + (pointLength > 0 ? pointLength + 1 : 0));
                }
                dataRow[key] = (neg ? "-" : "") + valueString;
            }
            else if ((value is int) || (value is Int32) || (value is Int64))
            {
                long longVal = Convert.ToInt64(value);
                bool neg = longVal < 0;
                int len = neg ? length - 1 : length;
                string outFormat = new string('0', len); // �������̌������w�肷��
                string valueString = longVal.ToString(outFormat);

                // �����ӂ�`�F�b�N
                valueString = valueString.Substring(valueString.Length - len, len);
                dataRow[key] = (neg ? "-" : "") + valueString;
            }
            else
            {
                dataRow[key] = value.ToString();
            }
        }

        # endregion

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting;
using System.Data;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{

    /// <summary>
    /// �|���W�v���ʕԋp�p�����[�^
    /// </summary>
    public class RateAddingUpResultsPara
    {
        /// <summary>�J�E���g�t���O[true:�W�v�����e�P���̊|���ݒ�敪��20���ȉ�,false:21���ȏ�]</summary>
        public bool countFlg;
        /// <summary>���ʃf�[�^�e�[�u��</summary>
        public DataTable resultsTbl;
    }

    /// <summary>
    /// �|���D��ݒ莩���o�^�@ �A�N�Z�X�N���X 
    /// </summary>
    /// <remarks>
    /// <br>Note        :  �|���}�X�^��P���|���ݒ�敪�ŏW�v����A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer	:  23003 enokida</br>
    /// <br>Date        :  2013.11.21</br>
    /// </remarks>
    public class PMKHN09932AA
    {
        #region --- Private Member ---
        /// <summary>�|���}�X�^�����[�g�I�u�W�F�N�g</summary>
        private IRateDB _iRateDB = null;

        /// <summary>���_</summary>
        private SecInfoSetAcs _secInfoSetAcs = new SecInfoSetAcs();

        /// <summary>�|���}�X�^�f�[�^�e�[�u��</summary>
        private static DataTable _rateTable;

        /// <summary>���_��񃊃X�g</summary>
        private static ArrayList _secInfoList;

        /// <summary>�W�v���ʃ��X�g</summary>
        private static Dictionary<string, RateAddingUpResultsPara> _addingUpTblList;

        #endregion

        #region --- Public Member ---
        /// <summary>�|���e�[�u����</summary>
        public const string RATE_TABLE = "RateTable";

        /// <summary> ���_�R�[�h </summary>
        public const string SECTIONCODE_TITLE = "SectionCode";
        /// <summary> �P���|���ݒ�敪 </summary>
        public const string UNITRATESETDIVCD_TITLE = "UnitRateSetDivCd";
        /// <summary> �P����� </summary>
        public const string UNITPRICEKIND_TITLE = "UnitPriceKind";
        /// <summary> �|���ݒ�敪 </summary>
        public const string RATESETTINGDIVIDE_TITLE = "RateSettingDivide";

        /// <summary> ���i���[�J�[�R�[�h </summary>
        public const string GOODSMAKERCD_TITLE = "GoodsMakerCd";
        /// <summary> ���i�ԍ� </summary>
        public const string GOODSNO_TITLE = "GoodsNo";
        /// <summary> ���i�|�������N </summary>
        public const string GOODSRATERANK_TITLE = "GoodsRateRank";
        /// <summary> ���i�|���O���[�v�R�[�h </summary>
        public const string GOODSRATEGRPCODE_TITLE = "GoodsRateGrpCode";
        /// <summary> BL�O���[�v�R�[�h </summary>
        public const string BLGROUPCODE_TITLE = "BLGroupCode";
        /// <summary> BL���i�R�[�h </summary>
        public const string BLGOODSCODE_TITLE = "BLGoodsCode";
        /// <summary> ���Ӑ�R�[�h </summary>
        public const string CUSTOMERCODE_TITLE = "CustomerCode";
        /// <summary> ���Ӑ�|���O���[�v�R�[�h </summary>
        public const string CUSTRATEGRPCODE_TITLE = "CustRateGrpCode";
        /// <summary> �d����R�[�h </summary>
        public const string SUPPLIERCD_TITLE = "SupplierCd";
        /// <summary> ���b�g�� </summary>
        public const string LOTCOUNT_TITLE = "LotCount";

        /// <summary>�W�v���ʃe�[�u����</summary>
        public const string ADDUP_TABLE = "AddingUpTable";
        /// <summary> �� </summary>
        public const string COUNT_TITLE = "Count";
        #endregion

        #region --- �R���X�g���N�^ ---
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMKHN09932AA()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iRateDB = (IRateDB)MediationRateDB.GetRateDB();

                // �W�v��Ɨp�e�[�u���̍쐬 �f�[�^�e�[�u������\�z����
                this.DataTableColumnConstruction();

                if (_addingUpTblList == null)
                    _addingUpTblList = new Dictionary<string, RateAddingUpResultsPara>();
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iRateDB = null;
            }
        }
        #endregion

        #region --- Public Methods ---
        /// <summary>
        /// �|���ݒ�敪�W�v����
        /// </summary>
        /// <param name="resultsTblList">�W�v���ʃ��X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h�i�S�Ўw��̏ꍇ�͋�""�j</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X[ConstantManagement.MethodResult]</returns>
        /// <remarks>
        /// <br>Note        :  �w�肳�ꂽ�������Ɋ|���}�X�^�̏W�v���s�����ʂ�Ԃ��܂��B</br>
        /// </remarks>
        public int RateSetDivCdAddingUp(out Dictionary<string, RateAddingUpResultsPara> resultsTblList, string enterpriseCode, string sectionCode, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            resultsTblList = new Dictionary<string, RateAddingUpResultsPara>();
            errMsg = string.Empty;

            DataTable resultsTbl = new DataTable(ADDUP_TABLE);
            List<string> sectionCodeList = new List<string>();
            try
            {
                if (sectionCode.Trim() == string.Empty)
                    status = this.RateSetDivCdAddingUpPro(out resultsTblList, enterpriseCode, out errMsg);
                else
                    status = this.RateSetDivCdAddingUpPro(out resultsTblList, enterpriseCode, sectionCode, out errMsg);
            }
            catch (Exception ex)
            {
                resultsTbl = null;
                this._iRateDB = null;
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }

        /// <summary>
        /// �ڍ׏��擾����
        /// </summary>
        /// <param name="resultsTbl">�ڍ׏��</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="unitPriceKind">�P�����</param>
        /// <param name="rateSettingDivide">�|���ݒ�敪</param>
        /// <remarks>
        /// <br>Note        :  �w�肳�ꂽ�������Ɋ|���}�X�^�̏���Ԃ��܂��B</br>
        /// </remarks>
        public void GetDetailInfo(out DataTable resultsTbl, string sectionCode, string unitPriceKind, string rateSettingDivide)
        {
            resultsTbl = new DataTable(RATE_TABLE);

            if (_rateTable == null)
                return;

            DataView dtView = new DataView(_rateTable);
            dtView.RowFilter = SECTIONCODE_TITLE + " = '" + sectionCode + "' and " +
                UNITPRICEKIND_TITLE + " = '" + unitPriceKind + "' and " + RATESETTINGDIVIDE_TITLE + " = '" + rateSettingDivide + "'";

            resultsTbl = dtView.ToTable();
        }



        // TODO: ����Ȃ�����
        /// <summary>
        /// �W�v���ʃf�[�^�Z�b�g����\�z����
        /// </summary>
        /// <param name="resultsTbl"></param>
        /// <remarks>
        /// <br>Note        : �W�v���ʗp�̃f�[�^�Z�b�g�̗�����\�z���܂��B</br>
        /// </remarks>
        public void DataTableColumnConstruction(out DataTable resultsTbl)
        {
            resultsTbl = new DataTable(ADDUP_TABLE);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            resultsTbl.Columns.Add(SECTIONCODE_TITLE, typeof(string)); // ���_�R�[�h
            resultsTbl.Columns.Add(UNITRATESETDIVCD_TITLE, typeof(string)); // �P���|���ݒ�敪
            resultsTbl.Columns.Add(UNITPRICEKIND_TITLE, typeof(string)); // �P�����
            resultsTbl.Columns.Add(RATESETTINGDIVIDE_TITLE, typeof(string)); // �|���ݒ�敪
            resultsTbl.Columns.Add(COUNT_TITLE, typeof(Int64)); // �o�^��
        }

        // TODO: ����Ȃ�����
        /// <summary>
        /// �ڍ׃f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <param name="resultsTbl"></param>
        /// <remarks>
        /// <br>Note        : �ڍו\���p�̃f�[�^�Z�b�g�̗�����\�z���܂��B</br>
        /// </remarks>
        public void DataTableDtlColumnConstruction(out DataTable resultsTbl)
        {
            resultsTbl = new DataTable(RATE_TABLE);
            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            resultsTbl.Columns.Add(SECTIONCODE_TITLE, typeof(string)); // ���_�R�[�h
            resultsTbl.Columns.Add(UNITRATESETDIVCD_TITLE, typeof(string)); // �P���|���ݒ�敪
            resultsTbl.Columns.Add(UNITPRICEKIND_TITLE, typeof(string)); // �P�����
            resultsTbl.Columns.Add(RATESETTINGDIVIDE_TITLE, typeof(string)); // �|���ݒ�敪

            resultsTbl.Columns.Add(GOODSMAKERCD_TITLE, typeof(Int32)); // ���i���[�J�[�R�[�h
            resultsTbl.Columns.Add(GOODSNO_TITLE, typeof(string)); // ���i�ԍ�
            resultsTbl.Columns.Add(GOODSRATERANK_TITLE, typeof(string)); // ���i�|�������N
            resultsTbl.Columns.Add(GOODSRATEGRPCODE_TITLE, typeof(Int32)); // ���i�|���O���[�v�R�[�h
            resultsTbl.Columns.Add(BLGROUPCODE_TITLE, typeof(Int32)); // BL�O���[�v�R�[�h
            resultsTbl.Columns.Add(BLGOODSCODE_TITLE, typeof(Int32)); // BL���i�R�[�h
            resultsTbl.Columns.Add(CUSTOMERCODE_TITLE, typeof(Int32)); // ���Ӑ�R�[�h
            resultsTbl.Columns.Add(CUSTRATEGRPCODE_TITLE, typeof(Int32)); // ���Ӑ�|���O���[�v�R�[�h
            resultsTbl.Columns.Add(SUPPLIERCD_TITLE, typeof(Int32)); // �d����R�[�h
        }
        #endregion

        #region --- Private Methods ---

        /// <summary>
        /// �|���ݒ�敪�W�v�����i�S�Ёj
        /// </summary>
        /// <param name="resultsTblList">�W�v���ʃ��X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X[ConstantManagement.MethodResult]</returns>
        /// <remarks>
        /// <br>Note        :  �w�肳�ꂽ��Ƃ̊|���}�X�^�̏W�v���e���_�R�[�h���ɍs�����ʂ�Ԃ��܂��B</br>
        /// </remarks>
        private int RateSetDivCdAddingUpPro(out Dictionary<string, RateAddingUpResultsPara> resultsTblList, string enterpriseCode, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            resultsTblList = new Dictionary<string, RateAddingUpResultsPara>();
            errMsg = string.Empty;

            // �W�v�Ώۋ��_�R�[�h���X�g
            List<string> sectionCodeList = new List<string>();
            bool addingupFlg = false;

            // ���Ɋ|���}�X�^����f�[�^�擾�ς݂�
            if (_secInfoList == null)
            {
                if (_secInfoSetAcs == null)
                    _secInfoSetAcs = new SecInfoSetAcs();
                // ���_���擾
                status = _secInfoSetAcs.SearchAll(out _secInfoList, enterpriseCode);

                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    errMsg = "���_���̎擾�Ɏ��s���܂����B";
                    return status;
                }

                // ���_�R�[�h���X�g�̍쐬
                sectionCodeList.Add("00");
                foreach (SecInfoSet wk in _secInfoList)
                    sectionCodeList.Add(wk.SectionCode.Trim());

                _rateTable.Clear();

                // �|���}�X�^�Ǎ��ݏ���
                status = this.OrgRateDataTableCreate(enterpriseCode, "");

                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    errMsg = "�|���}�X�^�̎擾�Ɏ��s���܂����B";
                    return status;
                }
            }
            else
            {
                // ���_�R�[�h���X�g�̍쐬
                sectionCodeList.Add("00");
                foreach (SecInfoSet wk in _secInfoList)
                    sectionCodeList.Add(wk.SectionCode.Trim());

                // ���ɏW�v�ς݂�
                if (_addingUpTblList != null)
                {
                    addingupFlg = true;
                    foreach (string key in sectionCodeList)
                    {
                        if (!_addingUpTblList.ContainsKey(key))
                        {
                            addingupFlg = false;
                            break;
                        }
                        resultsTblList.Add(key, _addingUpTblList[key]);
                    }
                }
            }

            // �W�v�������ԋp�f�[�^�쐬
            if (!addingupFlg)
                this.RateSetDivCdAddingUpDataCreate(out resultsTblList, sectionCodeList, 1);

            _addingUpTblList = resultsTblList;
            return status;
        }


        /// <summary>
        /// �|���ݒ�敪�W�v�����i���_�j
        /// </summary>
        /// <param name="resultsTblList">�W�v���ʃ��X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X[ConstantManagement.MethodResult]</returns>
        /// <remarks>
        /// <br>Note        :  �w�肳�ꂽ���_�̊|���}�X�^�̏W�v���s�����ʂ�Ԃ��܂��B</br>
        /// </remarks>
        private int RateSetDivCdAddingUpPro(out Dictionary<string, RateAddingUpResultsPara> resultsTblList, string enterpriseCode, string sectionCode, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            resultsTblList = new Dictionary<string, RateAddingUpResultsPara>();
            errMsg = string.Empty;

            bool retrievedFlg = true;

            // �|���}�X�^�ɓo�^���Ă��Ȃ����_�̏ꍇ�A1�x�W�v���Ă���Ǝ擾�ς݃f�[�^�i_rateTable�j�ɂ͖������A
            // �W�v���ʁi_addingUpTblList�j�ɂ͓���敪�̂ݏW�v����Ă���\��������ׁA�u�W�v�ς݃`�F�b�N�v����s��

            // ���ɏW�v�ς݂�
            if (_addingUpTblList != null && _addingUpTblList.ContainsKey(sectionCode))
            {
                resultsTblList.Add(sectionCode, _addingUpTblList[sectionCode]);
                return status;
            }

            // ���Ɋ|���}�X�^����f�[�^�擾�ς݂�
            DataRow[] findRows = null;
            if (_rateTable != null)
                findRows = _rateTable.Select(SECTIONCODE_TITLE + " = '" + sectionCode + "'");

            if (findRows == null || findRows.Length <= 0)
                retrievedFlg = false;

            // �|���}�X�^�Ǎ��ݏ���
            if (!retrievedFlg)
                status = this.OrgRateDataTableCreate(enterpriseCode, sectionCode);

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                errMsg = "�|���}�X�^�̎擾�Ɏ��s���܂����B";
                return status;
            }

            List<string> sectionCodeList = new List<string>();
            sectionCodeList.Add(sectionCode);

            // �W�v�������ԋp�f�[�^�쐬
            this.RateSetDivCdAddingUpDataCreate(out resultsTblList, sectionCodeList, 2);
            _addingUpTblList.Add(sectionCode.Trim(), resultsTblList[sectionCode]);

            return status;

        }


        /// <summary>
        /// �|���ݒ�敪�W�v����&�ԋp�f�[�^�쐬 
        /// </summary>
        /// <param name="resultsTblList">���ʃ��X�g</param>
        /// <param name="sectionCodeList">���_�R�[�h���X�g</param>
        /// <param name="mode">���[�h[1:�S��,2:���_�w��]</param>
        /// <remarks>
        /// <br>Note        :  �|���}�X�^�̏W�v���s���A�W�v���ʌ����ƍ��킹�Č��ʂ�Ԃ��܂��B</br>
        /// </remarks>
        private void RateSetDivCdAddingUpDataCreate(out Dictionary<string, RateAddingUpResultsPara> resultsTblList, List<string> sectionCodeList, int mode)
        {
            resultsTblList = new Dictionary<string, RateAddingUpResultsPara>();

            DataTable resultsTbl;
            string sectionCode = string.Empty;
            if (mode == 2)
                sectionCode = sectionCodeList[0];

            // ---------------- �|���ݒ�敪�W�v���� ---------------- //
            // �|���ݒ�敪�W�v���� 
            this.RateSetDivCdAddingUp(out resultsTbl, sectionCode, mode);

            // ����|���ݒ�敪�i"2A","4A","6A"�j�Z�b�g����
            this.RateSettingDivideSet(ref resultsTbl, sectionCodeList);

            // ----- �ԋp�f�[�^�쐬 ----- //
            DataView dtView = new DataView(resultsTbl);
            DataTable wkDt = new DataTable();
            RateAddingUpResultsPara para = new RateAddingUpResultsPara();

            // �W�v�����e�P���̊|���ݒ�敪��1�ł�21���ȏ゠���true���Z�b�g
            foreach (string wkSecCd in sectionCodeList)
            {
                para = new RateAddingUpResultsPara();
                dtView.RowFilter = SECTIONCODE_TITLE + " = '" + wkSecCd + "'";
                wkDt = dtView.ToTable();
                para.resultsTbl = wkDt;

                // �Ώۋ��_�̃f�[�^�������ꍇ��false��Ԃ�
                if (para.resultsTbl.Rows.Count == 0)
                    para.countFlg = false;
                else
                {
                    para.countFlg = true;

                    // �ΏےP����ށi�����܂��͌����j�̃f�[�^��21���ȏ㖔��0���̏ꍇ��false��Ԃ�
                    dtView.RowFilter = SECTIONCODE_TITLE + " = '" + wkSecCd + "' and " + UNITPRICEKIND_TITLE + " = '1'";
                    if (dtView.ToTable().Rows.Count > 20 || dtView.ToTable().Rows.Count == 0)
                        para.countFlg = false;
                    else
                    {
                        dtView.RowFilter = SECTIONCODE_TITLE + " = '" + wkSecCd + "' and " + UNITPRICEKIND_TITLE + " = '2'";
                        if (dtView.ToTable().Rows.Count > 20 || dtView.ToTable().Rows.Count == 0)
                            para.countFlg = false;
                    }
                }
                resultsTblList.Add(wkSecCd.Trim(), para);
            }
        }

        /// <summary>
        /// �W�v���e�[�u���쐬����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>�X�e�[�^�X[ConstantManagement.MethodResult]</returns>
        /// <remarks>
        /// <br>Note        :  �|���}�X�^��Ǎ���ŏW�v���ƂȂ�f�[�^�e�[�u�����쐬���܂��B</br>
        /// </remarks>
        private int OrgRateDataTableCreate(string enterpriseCode, string sectionCode)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            RateWork paraWork = new RateWork(); // ���o�����p�����[�^
            object retList = null; // �����[�g�߂胊�X�g

            paraWork.EnterpriseCode = enterpriseCode;   // ��ƃR�[�h
            paraWork.SectionCode = sectionCode;         // ���_�R�[�h
            paraWork.LotCount = 9999999.99;             // ���b�g���i-1:�i���ݖ���, -1�ȊO:�Y�����b�g���ōi�荞�݁j���ʔ͈͕͂����o�^���Ă����Ă�1�J�E���g�Ƃ���ׁu9999999.99�v�ōi�荞��

            // �|���}�X�^�Ǎ��ݏ���
        status = _iRateDB.Search(out retList, paraWork, 0, ConstantManagement.LogicalMode.GetData0);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �f�[�^�e�[�u���ɃZ�b�g
                foreach (RateWork rateWork in (ArrayList)retList)
                {
                    this.AddDataTableFromRateWork(rateWork);
                }
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            
            return status;
        }

        /// <summary>
        /// �|���ݒ�敪�W�v����
        /// </summary>
        /// <param name="resultsTbl">�W�v���ʃe�[�u��</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="mode">���[�h[1:�S��,2:���_�w��]</param>
        /// <remarks>
        /// <br>Note        : �|���}�X�^��P���|���ݒ�敪�ŏW�v���܂��B</br>
        /// </remarks>
        private void RateSetDivCdAddingUp(out DataTable resultsTbl, string sectionCode, int mode)
        {
            // ����쐬
            DataTableColumnConstruction(out resultsTbl);

            if (_rateTable.Rows.Count == 0)
                return;

            // �v���C�}���L�[�̐ݒ�i���_�R�[�h�A�P���|���ݒ�敪�j
            resultsTbl.PrimaryKey =
                new DataColumn[] { resultsTbl.Columns[SECTIONCODE_TITLE], resultsTbl.Columns[UNITRATESETDIVCD_TITLE] };

            foreach (DataRow row in _rateTable.Rows)
            {
                if (mode == 2 && (string)row[SECTIONCODE_TITLE] != sectionCode)
                    continue;

                // �P����ނ������A�����ȊO�̏ꍇ�͏W�v�s�v
                if ((string)row[UNITPRICEKIND_TITLE] != "1" && (string)row[UNITPRICEKIND_TITLE] != "2")
                    continue;

                object[] keys = new object[] { row[SECTIONCODE_TITLE], row[UNITRATESETDIVCD_TITLE] };
                DataRow trgDataRow = resultsTbl.Rows.Find(keys);

                if (trgDataRow == null)
                {
                    trgDataRow = resultsTbl.NewRow();
                    trgDataRow[SECTIONCODE_TITLE] = row[SECTIONCODE_TITLE]; // ���_�R�[�h
                    trgDataRow[UNITRATESETDIVCD_TITLE] = row[UNITRATESETDIVCD_TITLE]; // �P���|���ݒ�敪
                    trgDataRow[UNITPRICEKIND_TITLE] = row[UNITPRICEKIND_TITLE]; // �P�����
                    trgDataRow[RATESETTINGDIVIDE_TITLE] = row[RATESETTINGDIVIDE_TITLE]; // �|���ݒ�敪
                    resultsTbl.Rows.Add(trgDataRow);
                }
            }

            // �J�E���g
            foreach (DataRow row in resultsTbl.Rows)
            {
                int count = (int)_rateTable.Compute("Count(" + UNITRATESETDIVCD_TITLE + ")", UNITRATESETDIVCD_TITLE + " = '" + row[UNITRATESETDIVCD_TITLE] + "' and " + SECTIONCODE_TITLE + " = '" + row[SECTIONCODE_TITLE] + "'");
                row[COUNT_TITLE] = count;
            }

        }


        /// <summary>
        /// �|���ݒ�敪�ǉ�����
        /// </summary>
        /// <param name="resultsTbl">���ʃe�[�u��</param>
        /// <param name="sectionCodeList">���_�R�[�h���X�g</param>
        /// <remarks>
        /// <br>Note        : �W�v���ʂɑ΂��A����̊|���ݒ�敪��ǉ����܂��B</br>
        /// </remarks>
        private void RateSettingDivideSet(ref DataTable resultsTbl, List<string> sectionCodeList)
        {
            // ----------- �Œ�f�[�^�ǉ� ----------- //
            // ����̊|���ݒ�敪�i"2A","4A","6A"�j���Ȃ��ꍇ��count0�ŗp�ӂ��Ă���
            Dictionary<string, string[]> wkDivList = new Dictionary<string, string[]>();
            wkDivList.Add("1", new string[] { "2A", "4A", "6A" });�@// 1:�����ݒ�
            wkDivList.Add("2", new string[] { "6A" }); // 2:�����ݒ�

            DataRow dr;
            int count = 0;

            foreach (string sectionCode in sectionCodeList) // ���_
            {
                foreach (string wkUnitPriceKind in wkDivList.Keys) // �P�����
                {
                    // �w��̋��_�A�P����ނ̊|���f�[�^�������ꍇ�͒ǉ����Ȃ�
                    count = (int)resultsTbl.Compute("Count(" + RATESETTINGDIVIDE_TITLE + ")",
                        UNITPRICEKIND_TITLE + " = '" + wkUnitPriceKind + "' and " + SECTIONCODE_TITLE + " = '" + sectionCode + "'");
                    if (count == 0)
                        continue;

                    foreach (string wkRateSettingDivide in wkDivList[wkUnitPriceKind]) // �|���ݒ�敪
                    {
                        count = (int)resultsTbl.Compute("Count(" + RATESETTINGDIVIDE_TITLE + ")",
                            RATESETTINGDIVIDE_TITLE + " = '" + wkRateSettingDivide + "' and " + UNITPRICEKIND_TITLE + " = '" + wkUnitPriceKind + "' and " + SECTIONCODE_TITLE + " = '" + sectionCode + "'");

                        if (count == 0)
                        {
                            // �ǉ�
                            dr = resultsTbl.NewRow();

                            dr[SECTIONCODE_TITLE] = sectionCode; // ���_�R�[�h
                            dr[UNITRATESETDIVCD_TITLE] = wkUnitPriceKind + wkRateSettingDivide; // �P���|���ݒ�敪
                            dr[UNITPRICEKIND_TITLE] = wkUnitPriceKind; // �P�����
                            dr[RATESETTINGDIVIDE_TITLE] = wkRateSettingDivide; // �|���ݒ�敪
                            dr[COUNT_TITLE] = 0;
                            resultsTbl.Rows.Add(dr);
                        }
                    }
                }
            }
        }


        #region �f�[�^�e�[�u���֘A����
        /// <summary>
        /// �f�[�^�e�[�u������\�z�����i�|���}�X�^�j
        /// </summary>
        /// <remarks>
        /// <br>Note        : �W�v���ʗp�̃f�[�^�Z�b�g�̗�����\�z���܂��B</br>
        /// </remarks>
        private void DataTableColumnConstruction()
        {
            if (_rateTable == null)
            {
                _rateTable = new DataTable(RATE_TABLE);
                // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
                _rateTable.Columns.Add(SECTIONCODE_TITLE, typeof(string)); // ���_�R�[�h
                _rateTable.Columns.Add(UNITRATESETDIVCD_TITLE, typeof(string)); // �P���|���ݒ�敪
                _rateTable.Columns.Add(UNITPRICEKIND_TITLE, typeof(string)); // �P�����
                _rateTable.Columns.Add(RATESETTINGDIVIDE_TITLE, typeof(string)); // �|���ݒ�敪

                _rateTable.Columns.Add(GOODSMAKERCD_TITLE, typeof(Int32)); // ���i���[�J�[�R�[�h
                _rateTable.Columns.Add(GOODSNO_TITLE, typeof(string)); // ���i�ԍ�
                _rateTable.Columns.Add(GOODSRATERANK_TITLE, typeof(string)); // ���i�|�������N
                _rateTable.Columns.Add(GOODSRATEGRPCODE_TITLE, typeof(Int32)); // ���i�|���O���[�v�R�[�h
                _rateTable.Columns.Add(BLGROUPCODE_TITLE, typeof(Int32)); // BL�O���[�v�R�[�h
                _rateTable.Columns.Add(BLGOODSCODE_TITLE, typeof(Int32)); // BL���i�R�[�h
                _rateTable.Columns.Add(CUSTOMERCODE_TITLE, typeof(Int32)); // ���Ӑ�R�[�h
                _rateTable.Columns.Add(CUSTRATEGRPCODE_TITLE, typeof(Int32)); // ���Ӑ�|���O���[�v�R�[�h
                _rateTable.Columns.Add(SUPPLIERCD_TITLE, typeof(Int32)); // �d����R�[�h
            }
        }

        /// <summary>
        /// �f�[�^�e�[�u���ɃZ�b�g�i�|���}�X�^�j
        /// </summary>
        /// <param name="rateWork"></param>
        private void AddDataTableFromRateWork(RateWork rateWork)
        {
            DataRow dr = _rateTable.NewRow();

            dr[SECTIONCODE_TITLE] = rateWork.SectionCode.Trim(); // ���_�R�[�h
            dr[UNITRATESETDIVCD_TITLE] = rateWork.UnitRateSetDivCd; // �P���|���ݒ�敪
            dr[UNITPRICEKIND_TITLE] = rateWork.UnitPriceKind; // �P�����
            dr[RATESETTINGDIVIDE_TITLE] = rateWork.RateSettingDivide; // �|���ݒ�敪

            dr[GOODSMAKERCD_TITLE] = rateWork.GoodsMakerCd; // ���i���[�J�[�R�[�h
            dr[GOODSNO_TITLE] = rateWork.GoodsNo; // ���i�ԍ�
            dr[GOODSRATERANK_TITLE] = rateWork.GoodsRateRank; // ���i�|�������N
            dr[GOODSRATEGRPCODE_TITLE] = rateWork.GoodsRateGrpCode; // ���i�|���O���[�v�R�[�h
            dr[BLGROUPCODE_TITLE] = rateWork.BLGroupCode; // BL�O���[�v�R�[�h
            dr[BLGOODSCODE_TITLE] = rateWork.BLGoodsCode; // BL���i�R�[�h
            dr[CUSTOMERCODE_TITLE] = rateWork.CustomerCode; // ���Ӑ�R�[�h
            dr[CUSTRATEGRPCODE_TITLE] = rateWork.CustRateGrpCode; // ���Ӑ�|���O���[�v�R�[�h
            dr[SUPPLIERCD_TITLE] = rateWork.SupplierCd; // �d����R�[�h


            _rateTable.Rows.Add(dr);
        }


        #endregion

        #endregion

    }
}

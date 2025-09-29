//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �S���ҕʎ��яƉ�
// �v���O�����T�v   : �S���ҕʎ��яƉ�ꗗ���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���痈
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���J��
// �C �� ��  2010/07/20  �C�����e : �e�L�X�g�o��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : chenyd
// �C �� ��  2010/08/17  �C�����e : ��QID:13038 �e�L�X�g�o�͑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : liyp
// �C �� ��  2011/02/16  �C�����e : �e�L�X�g�o�͑Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using System.Windows.Forms;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization; // ADD 2010/07/20


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �S���ҕʎ��яƉ�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �S���ҕʎ��яƉ��S�ʂ��s���܂��B</br>
    /// <br>Programmer : ���痈</br>
    /// <br>Date       : 2009.04.01</br>
    /// <br>Update Note: 2010/08/17�A 2010/08/20�@chenyd</br>
    /// <br>            �E��QID:13038 �e�L�X�g�o�͑Ή�</br>
    /// </remarks>
    public class EmployeeResultsAcs
    {
        # region ��Private Member
        /// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        /// <remarks></remarks> 
        private IEmployeeResultsListDB _iEmployeeResultsListWorkDB = null;

        /// <summary>�S���ҕʎ��яƉ�ꗗ�f�[�^�Z�b�g</summary>
        /// <remarks></remarks> 
        private EmployeeResultsDataSet _dataSet;

        /// <summary>���������N���X�L���b�V��</summary>
        /// <remarks></remarks> 
        private static EmployeeResultsCtdtn _employeeResultsCtdtnSlipCache;

        /// <summary>�S���ҕʎ��яƉ�A�N�Z�X�N���X</summary>
        /// <remarks></remarks> 
        private static EmployeeResultsAcs _employeeResultsAcs;

        private bool _excOrtxtDiv = false;                      // �e�L�X�g�o��orExcel�o�͋敪  // ADD 2011/02/16

        ///// <summary>�X�e�^�X�o�A�Z�b�g�C�x���g����</summary>
        ///// <remarks></remarks> 
        //public event SettingStatusBarMessageEventHandler StatusBarMessageSetting;

        /// <summary>�Z�b�g�X�e�^�X�C�x���g����</summary>
        /// <remarks></remarks> 
        public delegate void SettingStatusBarMessageEventHandler(object sender, string message);

        #endregion

        # region ��Private Member
        private const string MESSAGE_NoResult = "�S���ҕʎ��яƉ�Ɉ�v����f�[�^�͑��݂��܂���B";
        private const string MESSAGE_ErrResult = "�S���ҕʎ��яƉ�̎擾�Ɏ��s���܂����B";
        private const string MESSAGE_NONOWNSECTION = "�����_��񂪎擾�ł��܂���ł����B���_�ݒ���s���Ă���N�����Ă��������B";
        private const string NOINPUT = "���o�^";
        private const string ALLTOTAL = "�����v";
        private const int TANNSI = 4;

        #endregion

        # region ��Constracter
        // ---------------ADD 2011/02/16 ------------------->>>>>
        // �e�L�X�g�o��orExcel�o�͋敪
        public bool ExcOrtxtDiv
        {
            get { return this._excOrtxtDiv; }
            set { _excOrtxtDiv = value; }
        }
        // ---------------ADD 2011/02/16 -------------------<<<<<

        /// <summary>
        /// �S���ҕʎ��яƉ�� �e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �S���ҕʎ��яƉ�� �e�[�u���A�N�Z�X�N���X�R���X�g���N�^�����������܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public EmployeeResultsAcs()
        {
            this._dataSet = new EmployeeResultsDataSet();
            // ���O�C�����i�ŒʐM��Ԃ��m�F
            if (LoginInfoAcquisition.OnlineFlag)
            {
                try
                {
                    // �����[�g�I�u�W�F�N�g�擾
                    this._iEmployeeResultsListWorkDB = (IEmployeeResultsListDB)MediationEmployeeResultsListDB.GetEmployeeResultsListDB();
                }
                catch (Exception)
                {
                    //�I�t���C������null���Z�b�g
                    this._iEmployeeResultsListWorkDB = null;
                }
            }
            else
            {
                // �I�t���C�����̃f�[�^�ǂݍ���
                //this.SearchOfflineData();
                MessageBox.Show("�I�t���C����Ԃ̂��ߌ��������s�ł��܂���B");
            }
        }

        /// <summary>
        /// ���������N���X�L���b�V���擾����
        /// </summary>
        /// <returns>���������N���X�L���b�V��</returns>
        /// <remarks>
        /// <br>Note       : ���������N���X�L���b�V���擾�������s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public EmployeeResultsCtdtn GetParaEmployeeResultsSlipCache()
        {
            return _employeeResultsCtdtnSlipCache;
        }

        #endregion

        # region ���C���X�^���X�擾����
        /// <summary>
        /// �S���ҕʎ��яƉ���A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns>�S���ҕʎ��яƉ���A�N�Z�X�N���X �C���X�^���X</returns>
        /// <remarks>
        /// <br>Note       : �S���ҕʎ��яƉ���A�N�Z�X�N���X �C���X�^���X�擾�������s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public static EmployeeResultsAcs GetInstance()
        {
            if (_employeeResultsAcs == null)
            {
                _employeeResultsAcs = new EmployeeResultsAcs();
            }

            return _employeeResultsAcs;
        }
        #endregion

        #region �� �f�[�^�Z�b�g�擾����
        /// <summary>
        /// �S���ҕʎ��яƉ�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <returns>�S���ҕʎ��яƉ�f�[�^�Z�b�g</returns>
        /// <remarks>
        /// <br>Note       : �S���ҕʎ��яƉ�f�[�^�Z�b�g�擾�������s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// <br>Note       : �S���ҕʎ��яƉ����ǂݍ��݂܂��B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        public EmployeeResultsDataSet DataSet
        {
            get { return this._dataSet; }
            set { _dataSet = value; } // ADD 2010/07/20
        }

        #endregion

        #region ��Public Method

        /// <summary>
        /// �S���ҕʎ��яƉ��� �Ǎ��E�f�[�^�Z�b�g�i�[���s����
        /// </summary>
        /// <param name="employeeResultsCtdtn">�S���ҕʎ��яƉ���p�����[�^�N���X</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �S���ҕʎ��яƉ����ǂݍ��݂܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public int SetSearchData(EmployeeResultsCtdtn employeeResultsCtdtn)
        {
            SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // �\��������ݒ�
            form.Title = "���o��";
            form.Message = "���݁A�f�[�^�𒊏o���ł��B";
            try
            {
                // �_�C�A���O�\��
                form.Show();

                List<EmployeeResultsListResultWork> retData;

                // �����[�g�Ăяo��
                int status = this.Search(out retData, employeeResultsCtdtn);
                this.ClearEmployeeResultsDataTable();

                this._dataSet.EmployeeResults.Rows.Clear();

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (retData.Count != 0)
                    {
                        long retGoodSales;
                        long PureSales;
                        ToSumSet(retData, out retGoodSales, out PureSales);

                        for (int i = 0; i < retData.Count; i++)
                        {
                            // 1���׎擾
                            EmployeeResultsListResultWork employeeResultsListResultWork = retData[i];

                            // �f�[�^�e�[�u���Ɋi�[
                            CopyToTable(employeeResultsListResultWork, employeeResultsCtdtn, retGoodSales, PureSales);
                        }

                        CopyAllToTable(employeeResultsCtdtn, retGoodSales, PureSales);

                    }

                }
                return status;
            }
            finally
            {
                // �_�C�A���O�����
                form.Close();
            }
        }

        // --- ADD 2010/07/20-------------------------------->>>>>
        /// <summary>
        /// �S���ҕʎ��яƉ��� �Ǎ��E�f�[�^�Z�b�g�i�[���s����(�o�͗p)
        /// </summary>
        /// <param name="employeeResultsCtdtn">�S���ҕʎ��яƉ���p�����[�^�N���X</param>
        /// <param name="SectionCodeSt">���_</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �S���ҕʎ��яƉ����ǂݍ��݂܂��B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        //public int SearchForOutput(EmployeeResultsCtdtn employeeResultsCtdtn)  // DEL 2010/08/20
        //public int SearchForOutput(EmployeeResultsCtdtn employeeResultsCtdtn, string SectionCodeSt) // ADD 2010/08/20 // DEL 2010/09/21
        public int SearchForOutput(EmployeeResultsCtdtn employeeResultsCtdtn, string SectionCodeSt, string SectionCodeEd) // ADD 2010/09/21
        {
            SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // �\��������ݒ�
            form.Title = "���o��";
            form.Message = "���݁A�f�[�^�𒊏o���ł��B";
            try
            {
                // �_�C�A���O�\��
                form.Show();

                List<EmployeeResultsListResultWork> retData;
                int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                long retGoodSales = 0;
                long PureSales = 0;
                this.ClearEmployeeResultsDataTable();

                this._dataSet.EmployeeResults.Rows.Clear();
                // --- UPD 2010/09/21 ---------->>>>>
                //if (SectionCodeSt != string.Empty)
                //{
                //    employeeResultsCtdtn.SectionCode = SectionCodeSt;
                //}

                if (SectionCodeSt != string.Empty)
                {
                    if ("00".Equals(SectionCodeSt) && !"00".Equals(SectionCodeEd))
                    {
                        employeeResultsCtdtn.SectionCode = SectionCodeEd;
                    }
                    else
                    {
                        employeeResultsCtdtn.SectionCode = SectionCodeSt;
                    }
                }

                // --- UPD 2010/09/21 ----------<<<<<
                status = this.Search(out retData, employeeResultsCtdtn);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (retData.Count != 0)
                    {
                        ToSumSet(retData, out retGoodSales, out PureSales);

                        for (int i = 0; i < retData.Count; i++)
                        {
                            // 1���׎擾
                            EmployeeResultsListResultWork employeeResultsListResultWork = retData[i];

                            // �f�[�^�e�[�u���Ɋi�[
                            CopyToTable(employeeResultsListResultWork, employeeResultsCtdtn, retGoodSales, PureSales);
                        }
                        //CopyAllToTable(employeeResultsCtdtn, retGoodSales, PureSales); // DEL 2010/09/09
                        _excOrtxtDiv = false;// ADD 2011/02/16
                    }

                }

                return status;
            }
            finally
            {
                // �_�C�A���O�����
                form.Close();
            }
        }
        // --- ADD 2010/07/20 --------------------------------<<<<<

        /// <summary>
        /// �S���ҕʎ��яƉ�Z�b�g�N���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �S���ҕʎ��яƉ�Z�b�g�N���A�������s���B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public void ClearEmployeeResultsDataTable()
        {
            this._dataSet.EmployeeResults.Rows.Clear();

            // �L���b�V���f�[�^�̎�蒼��(�N���A��Ԃɂ���)
            this.CacheParaEmployeeResultsSlip(null);
        }

        /// <summary>
        /// ���������N���X(�ĕ\���p) �L���b�V������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���������N���X(�ĕ\���p) �L���b�V���������s���B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void CacheParaEmployeeResultsSlip(EmployeeResultsCtdtn employeeResultsCtdtn)
        {
            // ���������l
            if (_employeeResultsCtdtnSlipCache == null)
            {
                _employeeResultsCtdtnSlipCache = new EmployeeResultsCtdtn();
            }
            _employeeResultsCtdtnSlipCache = employeeResultsCtdtn;

        }

        /// <summary>
        /// �S���ҕʎ��яƉ�Z�b�g�����v����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �S���ҕʎ��яƉ�Z�b�g�����v�������s���B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public void ToSumSet(List<EmployeeResultsListResultWork> retData, out long retGoodSales, out long pureSales)
        {
            long retGood = 0;
            long pureSa = 0;
            foreach (EmployeeResultsListResultWork detailWork in retData)
            {
                retGood += detailWork.RetGoodSalesTotalTaxExc;

                pureSa += (Convert.ToInt64(Convert.ToDecimal(detailWork.BackSalesTotalTaxExc) + Convert.ToDecimal(detailWork.BackSalesDisTtlTaxExc) + Convert.ToDecimal(detailWork.RetGoodSalesTotalTaxExc)));
            }

            retGoodSales = retGood * (-1);
            pureSales = pureSa;
        }


        /// <summary>
        /// �f�[�^�e�[�u���i�[����
        /// </summary>
        /// <param name="retWork">�S���ҕʎ��яƉ�f�[�^���[�N</param>
        /// <param name="employeeResultsCtdtn">�S���ҕʎ��яƉ� �f�[�^�N���X</param>
        /// <param name="retGoodSales">�ԕi�z</param>
        /// <param name="PureSales">������</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�e�[�u���i�[�������s���B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// <br>Update Note: 2011/02/16 liyp</br>
        /// <br>            �e�L�X�g�o�͑Ή�</br>
        /// </remarks>
        private void CopyToTable(EmployeeResultsListResultWork retWork, EmployeeResultsCtdtn employeeResultsCtdtn, long retGoodSales, long PureSales)
        {
            // �V�K�s�擾
            EmployeeResultsDataSet.EmployeeResultsRow row = _dataSet.EmployeeResults.NewEmployeeResultsRow();

            # region [copy]
            row.Header = _dataSet.EmployeeResults.Rows.Count + 1;    // �s��

            //����
            //if (!string.IsNullOrEmpty(retWork.EmployeeCode)) // DEL 2010/09/14
            if (retWork.EmployeeCode != null && !string.IsNullOrEmpty(retWork.EmployeeCode.Trim())) // ADD 2010/09/14
            {
                row.EmployeeCode = retWork.EmployeeCode.Trim();
            }
            // --- ADD 2010/07/20-------------------------------->>>>>
            else
            {
                //row.EmployeeCode = ""; // DEL 2010/09/14
                row.EmployeeCode = "0000"; // ADD 2010/09/14
            }
            // --- ADD 2010/07/20--------------------------------<<<<<
            //������z
            row.BackSalesTotalTaxExc = retWork.BackSalesTotalTaxExc;

            //�ԕi�z
            row.RetGoodSalesTotalTaxExc = (-1) * retWork.RetGoodSalesTotalTaxExc;

            //�l���z
            row.BackSalesDisTtlTaxExc = (-1) * retWork.BackSalesDisTtlTaxExc;

            //������
            row.PureSales = Convert.ToInt64(Convert.ToDecimal(row.BackSalesTotalTaxExc) - Convert.ToDecimal(row.BackSalesDisTtlTaxExc) - Convert.ToDecimal(row.RetGoodSalesTotalTaxExc));

            //�`�[����
            if (employeeResultsCtdtn.DuringType == 1)
            {
                row.SlipNumCount = retWork.SlipNumCount;
            }

            //����ڕW�z
            row.SalesTargetMoney = retWork.SalesTargetMoney;

            if (employeeResultsCtdtn.DuringType == 2 || employeeResultsCtdtn.DuringType == 3)
            {
                //�ԕi�\��
                if (retGoodSales != 0)
                {
                    row.RetGoodsStructure = decimal.Round((Convert.ToDecimal(row.RetGoodSalesTotalTaxExc) / Convert.ToDecimal(retGoodSales)), TANNSI, MidpointRounding.AwayFromZero);
                    // --------------------ADD 2011/02/16 ------------->>>>>
                    if (_excOrtxtDiv)
                    {
                        row.RetGoodsStructure = row.RetGoodsStructure * 100;
                    }
                    // --------------------ADD 2011/02/16 -------------<<<<<
                }

                //����\��
                if (PureSales != 0)
                {
                    row.SalesStructure = decimal.Round((Convert.ToDecimal(row.PureSales) / Convert.ToDecimal(PureSales)), TANNSI, MidpointRounding.AwayFromZero);
                    // --------------------ADD 2011/02/16 ------------->>>>>
                    if (_excOrtxtDiv)
                    {
                        row.SalesStructure = row.SalesStructure * 100;
                    }
                    // --------------------ADD 2011/02/16 -------------<<<<<
                }
            }

            //����
            if (!string.IsNullOrEmpty(retWork.EmployeeName))
            {
                row.EmployeeName = retWork.EmployeeName;
            }
            else
            {
                row.EmployeeName = NOINPUT;
            }

            //����
            row.TotalCost = retWork.TotalCost;

            //�ԕi��
            if (row.BackSalesTotalTaxExc != 0)
            {
                row.RetGoodsPct = decimal.Round((Convert.ToDecimal(row.RetGoodSalesTotalTaxExc) / Convert.ToDecimal(row.BackSalesTotalTaxExc)), TANNSI, MidpointRounding.AwayFromZero);
                // --------------------ADD 2011/02/16 ------------->>>>>
                if (_excOrtxtDiv)
                {
                    row.RetGoodsPct = row.RetGoodsPct * 100;
                }
                // --------------------ADD 2011/02/16 -------------<<<<<
            }

            //�l����
            if (row.BackSalesTotalTaxExc != 0)
            {
                row.DisTtlPct = decimal.Round((Convert.ToDecimal(row.BackSalesDisTtlTaxExc) / Convert.ToDecimal(row.BackSalesTotalTaxExc)), TANNSI, MidpointRounding.AwayFromZero);
                // --------------------ADD 2011/02/16 ------------->>>>>
                if (_excOrtxtDiv)
                {
                    row.DisTtlPct = row.DisTtlPct * 100;
                }
                // --------------------ADD 2011/02/16 -------------<<<<<
            }

            //�e���z
            if (employeeResultsCtdtn.DuringType == 1)
            {
                row.GrossProfit = row.BackSalesTotalTaxExc - row.RetGoodSalesTotalTaxExc - row.BackSalesDisTtlTaxExc - row.TotalCost;
            }
            else
            {
                row.GrossProfit = retWork.GrossProfit;
            }

            //�e����
            if (row.PureSales != 0)
            {
                row.GrossProfitPct = decimal.Round((Convert.ToDecimal(row.GrossProfit) / Convert.ToDecimal(row.PureSales)), TANNSI, MidpointRounding.AwayFromZero);
                // --------------------ADD 2011/02/16 ------------->>>>>
                if (_excOrtxtDiv)
                {
                    row.GrossProfitPct = row.GrossProfitPct * 100;
                }
                // --------------------ADD 2011/02/16 -------------<<<<<
            }

            //�ڕW�B����
            if (row.SalesTargetMoney != 0)
            {
                row.TargetPct = decimal.Round(((Convert.ToDecimal(row.PureSales) / Convert.ToDecimal(row.SalesTargetMoney))), TANNSI, MidpointRounding.AwayFromZero);
                // --------------------ADD 2011/02/16 ------------->>>>>
                if (_excOrtxtDiv)
                {
                    row.TargetPct = row.TargetPct * 100;
                }
                // --------------------ADD 2011/02/16 -------------<<<<<
            }
            // --- ADD 2010/08/17-------------------------------->>>>>
            if (string.IsNullOrEmpty(retWork.SectionCode))
            {
                row.SectionCode = "00";
                row.SectionName = "";
            }
            else
            {
                // --- ADD 2010/08/17--------------------------------<<<<<
                // --- ADD 2010/07/20-------------------------------->>>>>
                // ���_
                //row.SectionCode = retWork.SectionCode; // DEL 2010/09/09
                row.SectionCode = retWork.SectionCode.Trim(); // ADD 2010/09/09
                row.SectionName = GetSectionName(retWork.SectionCode, employeeResultsCtdtn.SectionCodeList);
            }
            
            // ����
            if (employeeResultsCtdtn.DuringType == 1)
            {
                row.DuringSt = TDateTime.DateTimeToString("YYYY/MM/DD", employeeResultsCtdtn.St_DuringTime);
                row.DuringEd = TDateTime.DateTimeToString("YYYY/MM/DD", employeeResultsCtdtn.Ed_DuringTime);

            }
            else
            {
                row.DuringSt = TDateTime.DateTimeToString("YYYY/MM", employeeResultsCtdtn.St_YearMonth);
                row.DuringEd = TDateTime.DateTimeToString("YYYY/MM", employeeResultsCtdtn.Ed_YearMonth);
            }
            // --- ADD 2010/07/20--------------------------------<<<<<

            // ---------------ADD 2011/02/16 ------------------->>>>>
            if (_excOrtxtDiv)
            {
                if (employeeResultsCtdtn.DuringType == 1)
                {
                    row.DuringSt = TDateTime.DateTimeToString("YYYY/MM/DD", employeeResultsCtdtn.St_DuringTime);
                    row.DuringEd = TDateTime.DateTimeToString("YYYY/MM/DD", employeeResultsCtdtn.Ed_DuringTime);
                    if (!string.IsNullOrEmpty(row.DuringSt))
                    {
                        row.DuringSt = row.DuringSt.Replace("/", "");
                    }
                    if (!string.IsNullOrEmpty(row.DuringEd))
                    {
                        row.DuringEd = row.DuringEd.Replace("/", "");
                    }
                }
                else
                {
                    row.DuringSt = TDateTime.DateTimeToString("YYYY/MM", employeeResultsCtdtn.St_YearMonth);
                    row.DuringEd = TDateTime.DateTimeToString("YYYY/MM", employeeResultsCtdtn.Ed_YearMonth);
                    if (!string.IsNullOrEmpty(row.DuringSt))
                    {
                        row.DuringSt = row.DuringSt.Replace("/", "");
                    }
                    if (!string.IsNullOrEmpty(row.DuringEd))
                    {
                        row.DuringEd = row.DuringEd.Replace("/", "");
                    }
                }
            }
            // ---------------ADD 2011/02/16 -------------------<<<<<

            # endregion

            // �ǉ�
            _dataSet.EmployeeResults.AddEmployeeResultsRow(row);
        }

        // --- ADD 2010/07/20-------------------------------->>>>>
        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="employeeRsectionListesultsCtdtn">���_���X�g</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note       : ���_���̎擾�������s���B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private string GetSectionName(string sectionCode, List<string[]> sectionList)
        {
            foreach (string[] sectionArray in sectionList)
            {
                if (!string.IsNullOrEmpty(sectionCode))
                {
                    if (sectionArray[0].Trim().Equals(sectionCode.Trim()))
                    {
                        return sectionArray[1];
                    }
                }
            }
            return string.Empty;
        }
        // --- ADD 2010/07/20--------------------------------<<<<<

        /// <summary>
        /// �f�[�^�e�[�u���i�[����
        /// </summary>
        /// <param name="retGoodSales">�l���z</param>
        /// <param name="employeeResultsCtdtn">�S���ҕʎ��яƉ� �f�[�^�N���X</param>
        /// <param name="pureSales">������</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�e�[�u���i�[�������s���B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void CopyAllToTable(EmployeeResultsCtdtn employeeResultsCtdtn, long retGoodSales, long pureSales)
        {
            //������z�i�����v�j
            long allBackSalesTotalTaxExc = 0;

            //�l���z�i�����v�j
            long allBackSalesDisTtlTaxExc = 0;

            //�`�[�����i�����v�j
            int allSlipNumCount = 0;

            //����ڕW�z�i�����v�j
            long allSalesTargetMoney = 0;

            //�����i�����v�j
            long allTotalCost = 0;

            //�e���z�i�����v�j
            long allGrossProfit = 0;

            foreach (EmployeeResultsDataSet.EmployeeResultsRow dataRow in _dataSet.EmployeeResults.Rows)
            {
                allBackSalesTotalTaxExc += dataRow.BackSalesTotalTaxExc;

                allBackSalesDisTtlTaxExc += dataRow.BackSalesDisTtlTaxExc;

                allSlipNumCount += dataRow.SlipNumCount;

                allSalesTargetMoney += dataRow.SalesTargetMoney;

                allTotalCost += dataRow.TotalCost;

                allGrossProfit += dataRow.GrossProfit;
            }

            // �V�K�s�擾
            EmployeeResultsDataSet.EmployeeResultsRow row = _dataSet.EmployeeResults.NewEmployeeResultsRow();

            row.Header = _dataSet.EmployeeResults.Rows.Count + 1;    // �s��

            //����
            //row.EmployeeCode = ALLTOTAL; // DEL 2010/07/20
            // --- ADD 2010/07/20-------------------------------->>>>>
            if (!"OUTPUT".Equals(employeeResultsCtdtn.ViewFlg))
                row.EmployeeCode = ALLTOTAL;
            else
                row.EmployeeCode = "";
            // --- ADD 2010/07/20--------------------------------<<<<<

            //������z
            row.BackSalesTotalTaxExc = allBackSalesTotalTaxExc;

            //�ԕi�z
            row.RetGoodSalesTotalTaxExc = retGoodSales;

            //�l���z
            row.BackSalesDisTtlTaxExc = allBackSalesDisTtlTaxExc;

            //������
            row.PureSales = pureSales;

            //�`�[����
            if (employeeResultsCtdtn.DuringType == 1)
            {
                row.SlipNumCount = allSlipNumCount;
            }

            //����ڕW�z
            row.SalesTargetMoney = allSalesTargetMoney;

            if (employeeResultsCtdtn.DuringType == 2 || employeeResultsCtdtn.DuringType == 3)
            {
                //�ԕi�\��
                row.RetGoodsStructure = decimal.Round((Convert.ToDecimal(1)), TANNSI, MidpointRounding.AwayFromZero);

                //����\��
                row.SalesStructure = decimal.Round((Convert.ToDecimal(1)), TANNSI, MidpointRounding.AwayFromZero);
            }

            //����
            row.TotalCost = allTotalCost;

            //�ԕi��
            if (allBackSalesTotalTaxExc != 0)
            {
                row.RetGoodsPct = decimal.Round((Convert.ToDecimal(retGoodSales) / Convert.ToDecimal(allBackSalesTotalTaxExc)), TANNSI, MidpointRounding.AwayFromZero);
            }

            //�l����
            if (allBackSalesTotalTaxExc != 0)
            {
                row.DisTtlPct = decimal.Round((Convert.ToDecimal(allBackSalesDisTtlTaxExc) / Convert.ToDecimal(allBackSalesTotalTaxExc)), TANNSI, MidpointRounding.AwayFromZero);
            }

            //�e���z
            row.GrossProfit = allGrossProfit;

            //�e����
            if (row.PureSales != 0)
            {
                row.GrossProfitPct = decimal.Round((Convert.ToDecimal(allGrossProfit) / Convert.ToDecimal(pureSales)), TANNSI, MidpointRounding.AwayFromZero);
            }

            //�ڕW�B����
            if (allSalesTargetMoney != 0)
            {
                row.TargetPct = decimal.Round(((Convert.ToDecimal(pureSales) / Convert.ToDecimal(allSalesTargetMoney))), TANNSI, MidpointRounding.AwayFromZero);
            }
            // --- ADD 2010/07/20-------------------------------->>>>>
            // ���_
            row.SectionCode = "00";
            if ("OUTPUT".Equals(employeeResultsCtdtn.ViewFlg))
                // ���_����
                row.SectionName = ALLTOTAL;
            // ����
            if (employeeResultsCtdtn.DuringType == 1)
            {
                row.DuringSt = TDateTime.DateTimeToString("YYYY/MM/DD", employeeResultsCtdtn.St_DuringTime);
                row.DuringEd = TDateTime.DateTimeToString("YYYY/MM/DD", employeeResultsCtdtn.Ed_DuringTime);

            }
            else
            {
                row.DuringSt = TDateTime.DateTimeToString("YYYY/MM", employeeResultsCtdtn.St_YearMonth);
                row.DuringEd = TDateTime.DateTimeToString("YYYY/MM", employeeResultsCtdtn.Ed_YearMonth);
            }
            // --- ADD 2010/07/20--------------------------------<<<<<

            // �ǉ�
            _dataSet.EmployeeResults.AddEmployeeResultsRow(row);
        }

        /// <summary>
        /// �S���ҕʎ��яƉ��� �ǂݍ��ݏ���
        /// </summary>
        /// <param name="employeeResultsListResultWorks">�S���ҕʎ��яƉ� �I�u�W�F�N�g�z��</param>
        /// <param name="employeeResultsCtdtn">�S���ҕʎ��яƉ���p�����[�^�N���X</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �S���ҕʎ��яƉ����ǂݍ��݂܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public int Search(out List<EmployeeResultsListResultWork> employeeResultsListResultWorks, EmployeeResultsCtdtn employeeResultsCtdtn)
        {
            string errMsg = "";

            int status;
            employeeResultsListResultWorks = new List<EmployeeResultsListResultWork>();

            EmployeeResultsListCndtnWork employeeResultsListCndtnWork = new EmployeeResultsListCndtnWork();
            // ���o�����W�J  --------------------------------------------------------------
            status = this.DevEmployeeResultsMainCndtn(employeeResultsCtdtn, out employeeResultsListCndtnWork, out errMsg);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return status;
            }

            object retObj = null;

            try
            {
                // �I�����C���̏ꍇ�����[�g�擾
                if (LoginInfoAcquisition.OnlineFlag)
                {
                    // �����[�g�I�u�W�F�N�g�擾
                    if (this._iEmployeeResultsListWorkDB == null)
                    {
                        this._iEmployeeResultsListWorkDB = (IEmployeeResultsListDB)MediationEmployeeResultsListDB.GetEmployeeResultsListDB();
                    }

                    status = this._iEmployeeResultsListWorkDB.Search(out retObj, employeeResultsListCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        ArrayList retList = retObj as ArrayList;
                        int len = retList.Count;
                        for (int i = 0; i < len; i++)
                        {
                            employeeResultsListResultWorks.Add((EmployeeResultsListResultWork)retList[i]);
                        }
                    }
                }
                else	// �I�t���C���̏ꍇ
                {
                    status = -1;
                }

                return status;
            }
            catch (Exception)
            {
                employeeResultsListResultWorks = null;
                //�I�t���C������null���Z�b�g
                this._iEmployeeResultsListWorkDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }


        #region �� ���o�����W�J����
        /// <summary>
        /// ���o�����W�J����
        /// </summary>
        /// <param name="employeeResultsCtdtn">UI���o�����N���X</param>
        /// <param name="employeeResultsListCndtnWork">�����[�g���o�����N���X</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ���o�����W�J�������s���܂��B</br>		
        /// <br>Programmer : ���痈</br>		
        /// <br>Date       : 2009.04.01</br>		
        /// </remarks>		
        private int DevEmployeeResultsMainCndtn(EmployeeResultsCtdtn employeeResultsCtdtn, out EmployeeResultsListCndtnWork employeeResultsListCndtnWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            employeeResultsListCndtnWork = new EmployeeResultsListCndtnWork();

            try
            {
                // ��ƃR�[�h
                employeeResultsListCndtnWork.EnterpriseCode = employeeResultsCtdtn.EnterpriseCode;

                // ���_�R�[�h
                employeeResultsListCndtnWork.SectionCode = employeeResultsCtdtn.SectionCode;
                // --- ADD 2010/07/20-------------------------------->>>>>
                // ���_�R�[�h���X�g
                employeeResultsListCndtnWork.SectionCodeList = employeeResultsCtdtn.SectionCodeList;
                // ��ʃr���[�E�o�̓r���[�t���O
                employeeResultsListCndtnWork.ViewFlg = employeeResultsCtdtn.ViewFlg;
                // --- ADD 2010/07/20 --------------------------------<<<<<

                //�Q�Ƌ敪
                employeeResultsListCndtnWork.ReferType = employeeResultsCtdtn.ReferType;

                //�S����(�J�n)
                employeeResultsListCndtnWork.St_EmployeeCode = employeeResultsCtdtn.St_EmployeeCode;

                //�S����(�I��)
                employeeResultsListCndtnWork.Ed_EmployeeCode = employeeResultsCtdtn.Ed_EmployeeCode;

                //���ԋ敪
                employeeResultsListCndtnWork.DuringType = employeeResultsCtdtn.DuringType;

                if (employeeResultsListCndtnWork.DuringType == 1)
                {
                    //����(�J�n)YYYYMMDD
                    employeeResultsListCndtnWork.St_DuringTime = employeeResultsCtdtn.St_DuringTime;

                    //����(�I��)YYYYMMDD
                    employeeResultsListCndtnWork.Ed_DuringTime = employeeResultsCtdtn.Ed_DuringTime;
                }
                else if (employeeResultsListCndtnWork.DuringType == 2 || employeeResultsListCndtnWork.DuringType == 3)
                {

                    //����(�J�n)YYYYMM
                    employeeResultsListCndtnWork.St_YearMonth = employeeResultsCtdtn.St_YearMonth;

                    //����(�I��)YYYYMM
                    employeeResultsListCndtnWork.Ed_YearMonth = employeeResultsCtdtn.Ed_YearMonth;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion

        #endregion
    }
}
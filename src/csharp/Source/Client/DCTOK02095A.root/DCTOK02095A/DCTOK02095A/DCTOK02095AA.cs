//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y
// �v���O��������   �F�O�N�Δ�\
// �v���O�����T�v   �F�O�N�Δ�\������EPDF�o�͂��s��
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30462 �s�V �m��
// �C����    2008/11/25     �C�����e�FPartsman�p�ɕύX
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F�Ɠc �M�u
// �C����    2009/01/29     �C�����e�F�s��Ή�[9849][9835]
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F�E �K�j
// �C����    2009/02/02     �C�����e�F�s��Ή�[10881]
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/04/16     �C�����e�FMantis�y13129�z�c�Č�No.19 �[������
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F����
// �C����    2012/05/18     �C�����e�F�O�N�Δ�\(�O���[�v��)�ƑO�N�Δ�\(BL�R�[�h��)�̋��z�����킹�Ȃ��̑Ή�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�  11170129-00    �쐬�S���Fcheq
// �C����    2015/08/17     �C�����e�FRedmine#47029 �O�N�Δ�\�䗦�Z�o�s���ƃG���[���o��̑Ή�
// ---------------------------------------------------------------------//

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �O�N�Δ�\�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Programer  : 30462 �s�V �m��</br>
    /// <br>Date       : 2008.11.25</br>
    /// <br>UpdateNote : 2009/01/29 �Ɠc �M�u�@�s��Ή�[9849][9835]</br>
    /// <br>UpdateNote : 2009/02/02 �E �K�j�@�s��Ή�[10881]</br>
    /// </remarks>
    public class PrevYearComparison
    {
        // ===================================================================================== //
        //  �O���񋟒萔
        // ===================================================================================== //
        #region public constant
        /// <summary>�S���_���R�[�h�p���_�R�[�h</summary>
        public const string CT_AllSectionCode = "000000";
        #endregion

        // ===================================================================================== //
        //  �X�^�e�B�b�N�ϐ�
        // ===================================================================================== //
        #region static variable

        /// <summary>�����_�R�[�h</summary>
        private static string mySectionCode = "";
        /// <summary>���[�o�͐ݒ�f�[�^�N���X</summary>
        private static PrtOutSet prtOutSetData = null;

        #endregion

        // ===================================================================================== //
        //  �����g�p�ϐ�
        // ===================================================================================== //
        #region private member

        private static SecInfoAcs _secInfoAcs;

        /// <summary>���[�o�͐ݒ�A�N�Z�X�N���X</summary>
        private static PrtOutSetAcs prtOutSetAcs = null;
        /// <summary>����pDataSet</summary>
        public DataSet _printDataSet;
        /// <summary>�o�b�t�@DataSet</summary>
        public static DataSet _printBuffDataSet;

        /// <summary>�O�N�Δ�\�f�[�^�e�[�u����</summary>
        private string _PrevYearCpDataTable;

        //�@�O��l�ۑ��p
        private string _beforAddUpSecCode = "";
        private string _beforSectionGuideSnmRF = "";
        private int    _beforCustomerCode = 0;
        private string _beforCustomerSnmRF = "";
        private string _beforEmployeeCode = "";
        private string _beforNameRF = "";
        private int    _beforBLGoodsCode = 0;
        private string _beforBLGoodsHalfNameRF = "";
        private int    _beforGoodsLGroup = 0;
        private string _beforGoodsLGroupName = "";
        private int    _beforGoodsMGroup = 0;
        private string _beforGoodsMGroupNameRF = "";
        private int    _beforBLGroupCode = 0;
        private string _beforBLGroupKanaNameRF = "";
        private int    _beforSalesAreaCode = 0;
        private string _beforSalesAreaName = "";
        private int    _beforBusinessTypeCode = 0;
        private string _beforBusinessTypeName = "";

        // �N���ʒu����p
        private int[] _monthArray = null;

        // ���z�P�ʁ@ADD 2009/01/30 �s��Ή�[9844]
        private int _moneyUnit = 0;

        #endregion

        // ===================================================================================== //
        //  �����g�p�萔
        // ===================================================================================== //
        #region private constant

        ///// <summary>�O�N�Δ�\�o�b�t�@�f�[�^�e�[�u����</summary>
        private const string MESSAGE_NONOWNSECTION = "�����_��񂪎擾�ł��܂���ł����B���_�ݒ���s���Ă���N�����Ă��������B";

        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        #region �R���X�g���N�^�[

        /// <summary>
        /// �O�N�Δ�\�A�N�Z�X�N���X�R���X�g���N�^�[
        /// </summary>
        public PrevYearComparison()
        {
            this.SettingDataTable();

            // ����pDataSet
            this._printDataSet = new DataSet();
            DataSetColumnConstruction(ref this._printDataSet);
            // �o�b�t�@�e�[�u���f�[�^�Z�b�g
            if (_printBuffDataSet == null)
            {
                _printBuffDataSet = new DataSet();
                DataSetColumnConstruction(ref _printBuffDataSet);
            }

            // ���_���擾
            this.CreateSecInfoAcs();
        }

        #endregion

        // ===================================================================================== //
        // �ÓI�R���X�g���N�^
        // ===================================================================================== //
        #region �ÓI�R���X�g���N�^�[

        /// <summary>
        /// �O�N�Δ�\�A�N�Z�X�N���X�ÓI�R���X�g���N�^�[
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programer  : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.11.25</br>
        /// </remarks>
        static PrevYearComparison()
        {
            // ���[�o�͐ݒ�A�N�Z�X�N���X�C���X�^���X��
            prtOutSetAcs = new PrtOutSetAcs();

            // ���O�C�����_�擾
            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            if (loginEmployee != null)
            {
                mySectionCode = loginEmployee.BelongSectionCode;
            }

        }

        #endregion

        // ===================================================================================== //
        // �O���񋟊֐�
        // ===================================================================================== //
        #region public method

        /// <summary>
        /// ���[�o�͐ݒ�Ǎ�
        /// </summary>
        /// <param name="prtOutSet">���[�o�͐ݒ�f�[�^�N���X</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note       : �����_�̒��[�o�͐ݒ�̓Ǎ����s���܂��B</br>
        /// <br>Programer  : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.11.25</br>
        /// </remarks>
        // public int ReadPrtOutSet(out PrtOutSet prtOutSet, out string message)
        static public int ReadPrtOutSet(out PrtOutSet prtOutSet, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            prtOutSet = null;
            message = "";
            try
            {
                // �f�[�^�͓Ǎ��ς݂��H
                if (prtOutSetData != null)
                {
                    prtOutSet = prtOutSetData.Clone();
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = prtOutSetAcs.Read(out prtOutSetData, LoginInfoAcquisition.EnterpriseCode, mySectionCode);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            prtOutSet = prtOutSetData.Clone();
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            prtOutSet = new PrtOutSet();
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            break;
                        default:
                            prtOutSet = new PrtOutSet();
                            message = "���[�o�͐ݒ�̓Ǎ��Ɏ��s���܂����B";
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return status;
        }

        /// <summary>
        /// �O�N�Δ�\�f�[�^����������
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : Static�������������܂��B</br>
        /// <br>Programer  : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.11.25</br>
        /// </remarks>
        public void InitializeCustomerLedger()
        {
            // --�e�[�u���s������-----------------------
            // ���o���ʃf�[�^�e�[�u�����N���A
            if (this._printDataSet.Tables[_PrevYearCpDataTable] != null)
            {
                this._printDataSet.Tables[_PrevYearCpDataTable].Rows.Clear();
            }
            // ���o���ʃo�b�t�@�f�[�^�e�[�u�����N���A
            if (_printBuffDataSet.Tables[_PrevYearCpDataTable] != null)
            {
                _printBuffDataSet.Tables[_PrevYearCpDataTable].Rows.Clear();
            }
        }

        /// <summary>
        /// �O�N�Δ�\�f�[�^�擾����
        /// </summary>
        /// <param name="PrYearCpListCndtn"></param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <param name="mode">�T�[�`���[�h(0:remote only,1:static��remote,2:static only)</param>
        /// <returns></returns>
        public int Search(ExtrInfo_DCTOK02093E PrYearCpListCndtn, out string message, int mode)
        {
            int status = 0;
            message = "";

            switch (mode)
            {
                case 0:
                    {
                        status = this.Search(PrYearCpListCndtn, out message);
                        break;
                    }
                case 1:
                    {
                        status = this.SearchStatic(out message);
                        if (status == (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            status = this.Search(PrYearCpListCndtn, out message);
                        }
                        break;
                    }
                case 2:
                    {
                        // static only �̏ꍇ�̓����[�e�B���O�ɍs���Ȃ�
                        status = this.SearchStatic(out message);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            return status;
        }

        /// <summary>
        /// �O�N�Δ�\�X�^�e�B�b�N�f�[�^�擾����
        /// </summary>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns></returns>
        public int SearchStatic(out string message)
        {
            int status = 0;
            message = "";

            DataRow dr;
            DataRow buffDr;

            this._printDataSet.Tables[_PrevYearCpDataTable].Rows.Clear();

            if (_printBuffDataSet.Tables[_PrevYearCpDataTable].Rows.Count > 0)
            {
                try
                {
                    for (int i = 0; i < _printBuffDataSet.Tables[_PrevYearCpDataTable].Rows.Count; i++)
                    {
                        dr = this._printDataSet.Tables[_PrevYearCpDataTable].NewRow();
                        buffDr = _printBuffDataSet.Tables[_PrevYearCpDataTable].Rows[i];

                        this.SetTebleRowFromDataRow(ref dr, buffDr);

                        this._printDataSet.Tables[_PrevYearCpDataTable].Rows.Add(dr);
                    }
                    status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    message = ex.Message;
                }
            }
            else
            {
                status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            return status;
        }

        /// <summary>
        /// �O�N�Δ�\�f�[�^�擾����
        /// </summary>
        /// <param name="PrYearCpListCndtn"></param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �Ώ۔͈͂̑O�N�Δ�\�f�[�^���擾���܂��B</br>
        /// <br>Programer  : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.11.25</br>
        /// <br>UpdateNote : �O�N�Δ�\(�O���[�v��)�ƑO�N�Δ�\(BL�R�[�h��)�̋��z�����킹�Ȃ��̑Ή�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/05/18</br>
        /// </remarks>
        private int Search(ExtrInfo_DCTOK02093E PrYearCpListCndtn, out string message)
        {
            object retObj;
            bool addflg = false;
            int rowIndex = -1;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            message = "";
            try
            {
                // StaticMemory�@������
                InitializeCustomerLedger();

                // �����[�g����f�[�^�̎擾
                ExtrInfo_PrevYearComparisonWork PrYearCpShWork = new ExtrInfo_PrevYearComparisonWork();
                // ���o�����p�����[�^�Z�b�g
                this.SearchParaSet(PrYearCpListCndtn, ref PrYearCpShWork);

                #region ���z��
                // ���̔z��쐬
                if (PrYearCpListCndtn.St_AddUpYearMonth == PrYearCpListCndtn.Ed_AddUpYearMonth)
                {
                    this._monthArray = new int[] { PrYearCpListCndtn.St_AddUpYearMonth };
                }
                else
                {
                    int st_nextyear = (Int32.Parse(PrYearCpListCndtn.St_AddUpYearMonth.ToString().Substring(0, 4)) + 1) * 100;
                    int st_yearmonth = PrYearCpListCndtn.St_AddUpYearMonth;
                    int ed_yearmonth = PrYearCpListCndtn.Ed_AddUpYearMonth;
                    this._monthArray = new int[12];

                    this._monthArray[0] = st_yearmonth;
                    for (int i = 1; i < 12; i++)
                    {
                        st_yearmonth++;
                        if (st_yearmonth.ToString().Substring(4, 2).Equals("13"))
                        {
                            st_yearmonth = st_nextyear + 1;
                        }

                        if (st_yearmonth <= ed_yearmonth)
                        {
                            this._monthArray[i] = st_yearmonth;
                        }
                    }
                }
                #endregion

                status = this.SearchByMode(out retObj, PrYearCpShWork);

                ArrayList retList = new ArrayList();
                retList = (ArrayList)retObj;

                if ((status == 0) && (retList.Count != 0))
                {
                    // --- ADD 2009/02/02 ��QID:10881�Ή�------------------------------------------------------>>>>>
                    // �\�[�g�p�Ƀ��X�g�쐬
                    List<RsltInfo_PrevYearComparisonWork> retWorkList = new List<RsltInfo_PrevYearComparisonWork>();
                    for (int i = 0; i < retList.Count; i++)
                    {
                        RsltInfo_PrevYearComparisonWork retWork = (RsltInfo_PrevYearComparisonWork)retList[i];
                        retWorkList.Add(retWork);
                    }

                    // �\�[�g
                    retWorkList.Sort(delegate(RsltInfo_PrevYearComparisonWork x, RsltInfo_PrevYearComparisonWork y)
                    {
                        switch (PrYearCpShWork.ListType)
                        {
                            case 0:
                                {
                                    //�O�N�Δ�\�i���Ӑ�ʁj
                                    if (String.Compare(x.AddUpSecCode, y.AddUpSecCode) == 0)
                                    {
                                        return (x.CustomerCode - y.CustomerCode);
                                    }
                                    else
                                    {
                                        return (String.Compare(x.AddUpSecCode, y.AddUpSecCode));
                                    }
                                }
                            case 1:
                            case 2:
                                {
                                    //�O�N�Δ�\�i�S���ҕʁj
                                    //�O�N�Δ�\�i�󒍎ҕʁj
                                    if (String.Compare(x.AddUpSecCode, y.AddUpSecCode) == 0)
                                    {
                                        // -- UPD 2011/01/28 --------------------------->>>
                                        //return (String.Compare(x.EmployeeCode, y.EmployeeCode));
                                        //���Ӑ��
                                        if (PrYearCpShWork.printType == 1)
                                        {
                                            if (String.Compare(x.EmployeeCode, y.EmployeeCode) == 0)
                                            {
                                                return (x.CustomerCode - y.CustomerCode);
                                            }
                                            else
                                            {
                                                return (String.Compare(x.EmployeeCode, y.EmployeeCode));
                                            }

                                        }
                                        else
                                        {
                                          return (String.Compare(x.EmployeeCode, y.EmployeeCode));
                                        }
                                        // -- UPD 2011/01/28 ---------------------------<<<

                                    }
                                    else
                                    {
                                        return (String.Compare(x.AddUpSecCode, y.AddUpSecCode));
                                    }
                                }
                            case 3:
                                {
                                    //�O�N�Δ�\�i�n��ʁj
                                    if (String.Compare(x.AddUpSecCode, y.AddUpSecCode) == 0)
                                    {
                                        // -- UPD 2011/01/28 --------------------------->>>
                                        //return (x.SalesAreaCode - y.SalesAreaCode);
                                        //���Ӑ��
                                        if (PrYearCpShWork.printType == 1)
                                        {
                                            if ((x.SalesAreaCode - y.SalesAreaCode) == 0)
                                            {
                                                return (x.CustomerCode - y.CustomerCode);
                                            }
                                            else
                                            {
                                                return (x.SalesAreaCode - y.SalesAreaCode);
                                            }

                                        }
                                        else
                                        {
                                            return (x.SalesAreaCode - y.SalesAreaCode);
                                        }
                                        // -- UPD 2011/01/28 ---------------------------<<<

                                    }
                                    else
                                    {
                                        return (String.Compare(x.AddUpSecCode, y.AddUpSecCode));
                                    }
                                }
                            case 4:
                                {
                                    //�O�N�Δ�\�i�Ǝ�ʁj
                                    if (String.Compare(x.AddUpSecCode, y.AddUpSecCode) == 0)
                                    {
                                        // -- UPD 2011/01/28 --------------------------->>>
                                        //return (x.BusinessTypeCode - y.BusinessTypeCode);
                                        //���Ӑ��
                                        if (PrYearCpShWork.printType == 1)
                                        {
                                            if ((x.BusinessTypeCode - y.BusinessTypeCode) == 0)
                                            {
                                                return (x.CustomerCode - y.CustomerCode);
                                            }
                                            else
                                            {
                                                return (x.BusinessTypeCode - y.BusinessTypeCode);
                                            }

                                        }
                                        else
                                        {
                                            return (x.BusinessTypeCode - y.BusinessTypeCode);
                                        }
                                        // -- UPD 2011/01/28 ---------------------------<<<
                                    }
                                    else
                                    {
                                        return (String.Compare(x.AddUpSecCode, y.AddUpSecCode));
                                    }
                                }
                            case 5:
                                {
                                    //�O�N�Δ�\�i�O���[�v�R�[�h�ʁj
                                    if (String.Compare(x.AddUpSecCode, y.AddUpSecCode) == 0)
                                    {
                                        // -- UPD 2011/01/28 --------------------------->>>
                                        //return (x.BLGroupCode - y.BLGroupCode);

                                        if (PrYearCpShWork.printType == 1)
                                        {
                                            //���i�����ޕ�
                                            if ((x.BLGroupCode - y.BLGroupCode) == 0)
                                            {
                                                return (x.GoodsMGroup - y.GoodsMGroup);
                                            }
                                            else
                                            {
                                                return (x.BLGroupCode - y.BLGroupCode);
                                            }
                                        }
                                        else if (PrYearCpShWork.printType == 2)
                                        {
                                            //���i�啪�ޕ�
                                            if ((x.BLGroupCode - y.BLGroupCode) == 0)
                                            {
                                                return (x.GoodsLGroup - y.GoodsLGroup);
                                            }
                                            else
                                            {
                                                return (x.BLGroupCode - y.BLGroupCode);
                                            }
                                        }
                                        else
                                        {
                                            return (x.BLGroupCode - y.BLGroupCode);
                                        }
                                        // -- UPD 2011/01/28 ---------------------------<<<
                                    }
                                    else
                                    {
                                        return (String.Compare(x.AddUpSecCode, y.AddUpSecCode));
                                    }
                                }
                            case 6:
                                {
                                    //�O�N�Δ�\�i�a�k�R�[�h�ʁj
                                    if (String.Compare(x.AddUpSecCode, y.AddUpSecCode) == 0)
                                    {
                                        // -- UPD 2011/01/28 --------------------------->>>
                                        //return (x.BLGoodsCode - y.BLGoodsCode);

                                        if (PrYearCpShWork.printType == 1)
                                        {
                                            //�a�k�R�[�h�ʓ��Ӑ��
                                            if ((x.BLGoodsCode - y.BLGoodsCode) == 0)
                                            {
                                                return (x.CustomerCode - y.CustomerCode);
                                            }
                                            else
                                            {
                                                return (x.BLGoodsCode - y.BLGoodsCode);
                                            }
                                        }
                                        else if (PrYearCpShWork.printType == 2)
                                        {
                                            //�a�k�R�[�h�ʒS���ҕ�
                                            if ((x.BLGoodsCode - y.BLGoodsCode) == 0)
                                            {
                                                return (String.Compare(x.EmployeeCode, y.EmployeeCode));
                                            }
                                            else
                                            {
                                                return (x.BLGoodsCode - y.BLGoodsCode);
                                            }
                                        }
                                        else
                                        {
                                            return (x.BLGoodsCode - y.BLGoodsCode);
                                        }
                                        // -- UPD 2011/01/28 ---------------------------<<<
                                    }
                                    else
                                    {
                                        return (String.Compare(x.AddUpSecCode, y.AddUpSecCode));
                                    }
                                }
                            default:
                                {
                                    if (String.Compare(x.AddUpSecCode, y.AddUpSecCode) == 0)
                                    {
                                        return (x.CustomerCode - y.CustomerCode);
                                    }
                                    else
                                    {
                                        return (String.Compare(x.AddUpSecCode, y.AddUpSecCode));
                                    }
                                }
                        }
                    });
                    // --- ADD 2009/02/02 ��QID:10881�Ή�------------------------------------------------------<<<<<

                    // ���擾
                    // --- CHG 2009/02/02 ��QID:10881�Ή�------------------------------------------------------>>>>>
                    //for (int i = 0; i < retList.Count; i++)
                    for (int i = 0; i < retWorkList.Count; i++)
                    // --- CHG 2009/02/02 ��QID:10881�Ή�------------------------------------------------------<<<<<
                    {
                        DataRow dr;
                        addflg = false;

                        #region �V�K�s���𔻒�
                        // --- CHG 2009/02/02 ��QID:10881�Ή�------------------------------------------------------>>>>>
                        //RsltInfo_PrevYearComparisonWork prevYearCpWork = (RsltInfo_PrevYearComparisonWork)retList[i];
                        RsltInfo_PrevYearComparisonWork prevYearCpWork = (RsltInfo_PrevYearComparisonWork)retWorkList[i];
                        // --- CHG 2009/02/02 ��QID:10881�Ή�------------------------------------------------------<<<<<

                        if (this._beforAddUpSecCode != prevYearCpWork.AddUpSecCode ||
                            this._beforSectionGuideSnmRF != prevYearCpWork.SectionGuideSnm ||
                            this._beforCustomerCode != prevYearCpWork.CustomerCode ||
                            this._beforCustomerSnmRF != prevYearCpWork.CustomerSnm ||
                            this._beforEmployeeCode != prevYearCpWork.EmployeeCode ||
                            this._beforNameRF != prevYearCpWork.Name ||
                            this._beforBLGoodsCode != prevYearCpWork.BLGoodsCode ||
                            this._beforBLGoodsHalfNameRF != prevYearCpWork.BLGoodsHalfName ||
                            this._beforGoodsLGroup != prevYearCpWork.GoodsLGroup ||
                            this._beforGoodsLGroupName != prevYearCpWork.GoodsLGroupName ||
                            this._beforGoodsMGroup != prevYearCpWork.GoodsMGroup ||
                            this._beforGoodsMGroupNameRF != prevYearCpWork.GoodsMGroupName ||
                            this._beforBLGroupCode != prevYearCpWork.BLGroupCode ||
                            this._beforBLGroupKanaNameRF != prevYearCpWork.BLGroupKanaName ||
                            this._beforSalesAreaCode != prevYearCpWork.SalesAreaCode ||
                            this._beforSalesAreaName != prevYearCpWork.SalesAreaName ||
                            this._beforBusinessTypeCode != prevYearCpWork.BusinessTypeCode ||
                            this._beforBusinessTypeName != prevYearCpWork.BusinessTypeName)
                        {
                            addflg = true;
                            dr = this._printDataSet.Tables[_PrevYearCpDataTable].NewRow();
                            rowIndex++;

                            this._beforAddUpSecCode = prevYearCpWork.AddUpSecCode;
                            this._beforSectionGuideSnmRF = prevYearCpWork.SectionGuideSnm;
                            this._beforCustomerCode = prevYearCpWork.CustomerCode;
                            this._beforCustomerSnmRF = prevYearCpWork.CustomerSnm;
                            this._beforEmployeeCode = prevYearCpWork.EmployeeCode;
                            this._beforNameRF = prevYearCpWork.Name;
                            this._beforBLGoodsCode = prevYearCpWork.BLGoodsCode;
                            this._beforBLGoodsHalfNameRF = prevYearCpWork.BLGoodsHalfName;
                            this._beforGoodsLGroup = prevYearCpWork.GoodsLGroup;
                            this._beforGoodsLGroupName = prevYearCpWork.GoodsLGroupName;
                            this._beforGoodsMGroup = prevYearCpWork.GoodsMGroup;
                            this._beforGoodsMGroupNameRF = prevYearCpWork.GoodsMGroupName;
                            this._beforBLGroupCode = prevYearCpWork.BLGroupCode;
                            this._beforBLGroupKanaNameRF = prevYearCpWork.BLGroupKanaName;
                            this._beforSalesAreaCode = prevYearCpWork.SalesAreaCode;
                            this._beforSalesAreaName = prevYearCpWork.SalesAreaName;
                            this._beforBusinessTypeCode = prevYearCpWork.BusinessTypeCode;
                            this._beforBusinessTypeName = prevYearCpWork.BusinessTypeName;

                        }
                        else
                        {
                            //// ----- ADD ���� 2012/05/18 �O�N�Δ�\(�O���[�v��)�ƑO�N�Δ�\(BL�R�[�h��)�̋��z�����킹�Ȃ��̑Ή� ----->>>>>
                            // ��Q�F�����ނ��ݒ肵�Ă��Ȃ��ABL�R�[�h=�O�̓`�[�������ɑ��݂���ꍇ�A�ꕔ�̓`�[�̋��z���W�v����Ȃ��B
                            if (prevYearCpWork.GoodsMGroup == 0)
                            {
                                for (int j = i - 1; j >= 0; j--)
                                {
                                    RsltInfo_PrevYearComparisonWork prevWork = (RsltInfo_PrevYearComparisonWork)retWorkList[j];

                                    if (prevWork.AddUpSecCode == prevYearCpWork.AddUpSecCode &&
                                        prevWork.SectionGuideSnm == prevYearCpWork.SectionGuideSnm &&
                                        prevWork.CustomerCode == prevYearCpWork.CustomerCode &&
                                        prevWork.CustomerSnm == prevYearCpWork.CustomerSnm &&
                                        prevWork.EmployeeCode == prevYearCpWork.EmployeeCode &&
                                        prevWork.Name == prevYearCpWork.Name &&
                                        prevWork.BLGoodsCode == prevYearCpWork.BLGoodsCode &&
                                        prevWork.BLGoodsHalfName == prevYearCpWork.BLGoodsHalfName &&
                                        prevWork.GoodsLGroup == prevYearCpWork.GoodsLGroup &&
                                        prevWork.GoodsLGroupName == prevYearCpWork.GoodsLGroupName &&
                                        prevWork.GoodsMGroup == prevYearCpWork.GoodsMGroup &&
                                        prevWork.GoodsMGroupName == prevYearCpWork.GoodsMGroupName &&
                                        prevWork.BLGroupCode == prevYearCpWork.BLGroupCode &&
                                        prevWork.BLGroupKanaName == prevYearCpWork.BLGroupKanaName &&
                                        prevWork.SalesAreaCode == prevYearCpWork.SalesAreaCode &&
                                        prevWork.SalesAreaName == prevYearCpWork.SalesAreaName &&
                                        prevWork.BusinessTypeCode == prevYearCpWork.BusinessTypeCode &&
                                        prevWork.BusinessTypeName == prevYearCpWork.BusinessTypeName &&
                                        prevWork.AddUpMonth == prevYearCpWork.AddUpMonth)  // ���Ԃ��P�P���ȏ�̏ꍇ�A���̔�r���K�v
                                    {
                                        prevYearCpWork.ThisTermSales += prevWork.ThisTermSales;     // ����z(Int64)
                                        prevYearCpWork.FirstTermSales += prevWork.FirstTermSales;     // ����z(Int64)
                                        prevYearCpWork.ThisTermGross += prevWork.ThisTermGross; // �e���z(Int64)
                                        prevYearCpWork.FirstTermGross += prevWork.FirstTermGross;  // �e���z(Int64)

                                        break;
                                    }
                                }
                            }
                            //// ----- ADD ���� 2012/05/18 �O�N�Δ�\(�O���[�v��)�ƑO�N�Δ�\(BL�R�[�h��)�̋��z�����킹�Ȃ��̑Ή� -----<<<<< 

                            dr = this._printDataSet.Tables[_PrevYearCpDataTable].Rows[rowIndex];
                        }
                        #endregion

                        // --- CHG 2009/02/02 ��QID:10881�Ή�------------------------------------------------------>>>>>
                        //SetTebleRowFromRetList(ref dr, retList, i);
                        SetTebleRowFromRetList(ref dr, retWorkList, i);
                        // --- CHG 2009/02/02 ��QID:10881�Ή�------------------------------------------------------<<<<<

                        if (addflg == true)
                        {
                            this._printDataSet.Tables[_PrevYearCpDataTable].Rows.Add(dr);
                        }

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }

                // ���v�l���䗦���Z�o
                for (int i = 0; i < this._printDataSet.Tables[_PrevYearCpDataTable].Rows.Count; i++)
                {
                    DataRow dr;

                    dr = this._printDataSet.Tables[_PrevYearCpDataTable].Rows[i];

                    SetTebleRowFromRetListSum(ref dr);
                }

                // ��ʒ��o�����ƈ�v���邩�𔻒�
                if (PrYearCpListCndtn.St_MonthSalesRatio_ck == true ||
                    PrYearCpListCndtn.Ed_MonthSalesRatio_ck == true ||
                    PrYearCpListCndtn.St_YearSalesRatio_ck == true ||
                    PrYearCpListCndtn.Ed_YearSalesRatio_ck == true ||
                    PrYearCpListCndtn.St_MonthGrossRatio_ck == true ||
                    PrYearCpListCndtn.Ed_MonthGrossRatio_ck == true ||
                    PrYearCpListCndtn.St_YearGrossRatio_ck == true ||
                    PrYearCpListCndtn.Ed_YearGrossRatio_ck == true)
                {
                    // �ǂꂩ��ł�����͂��Ă�������`�F�b�N������
                    this.CheckVal(PrYearCpListCndtn);
                }

                // ---ADD 2009/01/29 �s��Ή�[9835] ----------------------------------------->>>>>
                if (this._printDataSet.Tables[_PrevYearCpDataTable].Rows.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    return status;
                }
                // ---ADD 2009/01/29 �s��Ή�[9835] -----------------------------------------<<<<<

                // �o�b�t�@�e�[�u���ւ̊i�[
                _printBuffDataSet = this._printDataSet.Copy();

            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.Message;
            }
            return status;
        }

        #endregion

        // ===================================================================================== //
        // �����g�p�֐�
        // ===================================================================================== //
        #region private method

        /// <summary>
        /// �����p�����[�^�ݒ菈��
        /// </summary>
        private void SearchParaSet(ExtrInfo_DCTOK02093E prYearCpListCndtn, ref ExtrInfo_PrevYearComparisonWork prYearCpShWork)
        {
            prYearCpShWork.EnterpriseCode = prYearCpListCndtn.EnterpriseCode;			// ��ƃR�[�h

            prYearCpShWork.secCodeList = prYearCpListCndtn.SecCodeList;					//�o�͑Ώۋ��_�inull:�S�Ёj

            prYearCpShWork.TotalWay = prYearCpListCndtn.TotalWay;                       // �W�v���@

            prYearCpShWork.ListType = prYearCpListCndtn.ListType;                       // �o�͕��@�i���[�^�C�v�j

            prYearCpShWork.MoneyUnit = prYearCpListCndtn.MoneyUnit;						// ���z�P��
            this._moneyUnit = prYearCpListCndtn.MoneyUnit;                  //ADD 2009/01/30 �s��Ή�[9844]

            prYearCpShWork.printType = prYearCpListCndtn.IssueType;						// ���s�^�C�v

            prYearCpShWork.St_AddUpYearMonth = prYearCpListCndtn.St_AddUpYearMonth;     // �J�n �Ώ۔N��
            prYearCpShWork.Ed_AddUpYearMonth = prYearCpListCndtn.Ed_AddUpYearMonth;     // �I�� �Ώ۔N��

            prYearCpShWork.St_MonthSalesRatio = prYearCpListCndtn.St_MonthSalesRatio;   // �J�n ����������
            prYearCpShWork.Ed_MonthSalesRatio = prYearCpListCndtn.Ed_MonthSalesRatio;   // �I�� ����������

            prYearCpShWork.St_YearSalesRatio = prYearCpListCndtn.St_YearSalesRatio;     // �J�n ���N������
            prYearCpShWork.Ed_YearSalesRatio = prYearCpListCndtn.Ed_YearSalesRatio;	    // �I�� ���N������

            prYearCpShWork.St_MonthGrossRatio = prYearCpListCndtn.St_MonthGrossRatio;   // �J�n �����e��
            prYearCpShWork.Ed_MonthGrossRatio = prYearCpListCndtn.Ed_MonthGrossRatio;   // �I�� �����e��

            prYearCpShWork.St_YearGrossRatio = prYearCpListCndtn.St_YearGrossRatio;     // �J�n ���N�e��
            prYearCpShWork.Ed_YearGrossRatio = prYearCpListCndtn.Ed_YearGrossRatio;	    // �I�� ���N�e��

            prYearCpShWork.St_EmployeeCode = prYearCpListCndtn.St_EmployeeCode;         // �J�n �S����
            if (prYearCpListCndtn.Ed_EmployeeCode.Trim().PadLeft(4, '0').Equals("0000"))
            {
                prYearCpShWork.Ed_EmployeeCode = "9999";                                // �I�� �S����
            }
            else
            {
                prYearCpShWork.Ed_EmployeeCode = prYearCpListCndtn.Ed_EmployeeCode;     // �I�� �S����
            }
            prYearCpShWork.St_CustomerCode = prYearCpListCndtn.St_CustomerCode;         // �J�n ���Ӑ�
            if (prYearCpListCndtn.Ed_CustomerCode == 0)
            {
                prYearCpShWork.Ed_CustomerCode = 99999999;                              // �I�� ���Ӑ�
            }
            else
            {
                prYearCpShWork.Ed_CustomerCode = prYearCpListCndtn.Ed_CustomerCode;     // �I�� ���Ӑ�
            }

            prYearCpShWork.St_SalesAreaCode = prYearCpListCndtn.St_SalesAreaCode;       // �J�n �n��
            if (prYearCpListCndtn.Ed_SalesAreaCode == 0)
            {
                prYearCpShWork.Ed_SalesAreaCode = 9999;                                 // �I�� �n��
            }
            else
            {
                prYearCpShWork.Ed_SalesAreaCode = prYearCpListCndtn.Ed_SalesAreaCode;   // �I�� �n��
            }

            prYearCpShWork.St_BusinessTypeCode = prYearCpListCndtn.St_BusinessTypeCode; // �J�n �Ǝ�
            if (prYearCpListCndtn.Ed_BusinessTypeCode == 0)
            {
                prYearCpShWork.Ed_BusinessTypeCode = 9999;                              // �I�� �Ǝ�
            }
            else
            {
                prYearCpShWork.Ed_BusinessTypeCode = prYearCpListCndtn.Ed_BusinessTypeCode; // �I�� �Ǝ�
            }

            prYearCpShWork.St_BLGoodsCode = prYearCpListCndtn.St_BLGoodsCode;           // �J�n BL�R�[�h
            if (prYearCpListCndtn.Ed_BLGoodsCode == 0)
            {
                prYearCpShWork.Ed_BLGoodsCode = 99999;                                  // �I�� BL�R�[�h
            }
            else
            {
                prYearCpShWork.Ed_BLGoodsCode = prYearCpListCndtn.Ed_BLGoodsCode;       // �I�� BL�R�[�h
            }

            prYearCpShWork.St_GoodsLGroup = prYearCpListCndtn.St_GoodsLGroup;           // �J�n ���i�啪��
            if (prYearCpListCndtn.Ed_GoodsLGroup == 0)
            {
                prYearCpShWork.Ed_GoodsLGroup = 9999;                                   // �I�� ���i�啪��
            }
            else
            {
                prYearCpShWork.Ed_GoodsLGroup = prYearCpListCndtn.Ed_GoodsLGroup;       // �I�� ���i�啪��
            }

            prYearCpShWork.St_GoodsMGroup = prYearCpListCndtn.St_GoodsMGroup;           // �J�n ���i������
            if (prYearCpListCndtn.Ed_GoodsMGroup == 0)
            {
                prYearCpShWork.Ed_GoodsMGroup = 9999;                                   // �I�� ���i������
            }
            else
            {
                prYearCpShWork.Ed_GoodsMGroup = prYearCpListCndtn.Ed_GoodsMGroup;       // �I�� ���i������
            }

            prYearCpShWork.St_BLGroupCode = prYearCpListCndtn.St_BLGroupCode;           // �J�n �O���[�v�R�[�h
            if (prYearCpListCndtn.Ed_BLGroupCode == 0)
            {
                prYearCpShWork.Ed_BLGroupCode = 99999;                                  // �I�� �O���[�v�R�[�h
            }
            else
            {
                prYearCpShWork.Ed_BLGroupCode = prYearCpListCndtn.Ed_BLGroupCode;       // �I�� �O���[�v�R�[�h
            }
        }

        /// <summary>
        /// �f�[�^�X�L�[�}�\������
        /// </summary>
        private void DataSetColumnConstruction(ref DataSet ds)
        {
            // ���o��{�f�[�^�Z�b�g�X�L�[�}�ݒ�
            Broadleaf.Application.UIData.DCTOK02094EA.SettingDataSet(ref ds);
        }

        /// <summary>
        /// ���[�h����Search�ďo����
        /// </summary>
        /// <param name="retObj">�擾�f�[�^�I�u�W�F�N�g</param>
        /// <param name="prYearCpShWork">�����[�g���������N���X</param>
        /// <returns>�X�e�[�^�X</returns>
        private int SearchByMode(out object retObj, ExtrInfo_PrevYearComparisonWork prYearCpShWork)
        {
            int status = 0;

            retObj = null;

            IPrevYearComparisonDB _iSalesConfDB = (IPrevYearComparisonDB)MediationPrevYearComparisonDB.GetPrevYearComparisonDB();

            status = _iSalesConfDB.SearchPrevYearComparison(out retObj, prYearCpShWork);

            return status;
        }
        
        /// <summary>
        /// �N�����[�h���f�[�^�e�[�u���ݒ�
        /// </summary>
        private void SettingDataTable()
        {
            this._PrevYearCpDataTable = Broadleaf.Application.UIData.DCTOK02094EA.CT_PrevYearCpDataTable;
        }

        /// <summary>
        /// �f�[�^Row�쐬
        /// </summary>
        /// <param name="dr">�Z�b�g�Ώ�DataRow</param>
        /// <param name="retList">�f�[�^�擾�����X�g</param>
        /// <param name="setCnt">���X�g�̃f�[�^�擾Index</param>
        // --- CHG 2009/02/02 ��QID:10881�Ή�------------------------------------------------------>>>>>
        //private void SetTebleRowFromRetList(ref DataRow dr, ArrayList retList, int setCnt)
        private void SetTebleRowFromRetList(ref DataRow dr, List<RsltInfo_PrevYearComparisonWork> retList, int setCnt)
        // --- CHG 2009/02/02 ��QID:10881�Ή�------------------------------------------------------<<<<<
        {
            int index = 0;

            RsltInfo_PrevYearComparisonWork prevYearCpWork = (RsltInfo_PrevYearComparisonWork)retList[setCnt];

            dr[DCTOK02094EA.CT_PrevYear_AddUpSecCode] = prevYearCpWork.AddUpSecCode;		 // �v�㋒�_�R�[�h(string)
            dr[DCTOK02094EA.CT_PrevYear_SectionGuidNm] = prevYearCpWork.SectionGuideSnm;	 // ���_�K�C�h���� (string)
            dr[DCTOK02094EA.CT_PrevYear_EmployeeCode] = prevYearCpWork.EmployeeCode;         // �]�ƈ��R�[�h  (string)
            dr[DCTOK02094EA.CT_PrevYear_EmployeeName] = prevYearCpWork.Name;                 // �]�ƈ�����    (string)
            dr[DCTOK02094EA.CT_PrevYear_CustomerCode] = prevYearCpWork.CustomerCode;         // ���Ӑ�R�[�h  (Int32)
            dr[DCTOK02094EA.CT_PrevYear_CustomerSnm] = prevYearCpWork.CustomerSnm;           // ���Ӑ旪��    (string)
            dr[DCTOK02094EA.CT_PrevYear_BusinessTypeCode] = prevYearCpWork.BusinessTypeCode; // �Ǝ�R�[�h    (Int32)
            dr[DCTOK02094EA.CT_PrevYear_BusinessTypeName] = prevYearCpWork.BusinessTypeName; // �Ǝ햼��		(string)
            dr[DCTOK02094EA.CT_PrevYear_SalesAreaCode] = prevYearCpWork.SalesAreaCode;       // �̔��G���A�R�[�h(Int32)
            dr[DCTOK02094EA.CT_PrevYear_SalesAreaName] = prevYearCpWork.SalesAreaName;		 // �̔��G���A����  (string)
            dr[DCTOK02094EA.CT_PrevYear_BLGoodsCode] = prevYearCpWork.BLGoodsCode;           // BL�R�[�h(Int32)
            dr[DCTOK02094EA.CT_PrevYear_BLGoodsHalfName] = prevYearCpWork.BLGoodsHalfName;	 // BL����  (string)
            dr[DCTOK02094EA.CT_PrevYear_GoodsLGroup] = prevYearCpWork.GoodsLGroup;           // ���i�啪�ރR�[�h(Int32)
            dr[DCTOK02094EA.CT_PrevYear_GoodsLGroupName] = prevYearCpWork.GoodsLGroupName;	 // ���i�啪�ޖ���  (string)
            dr[DCTOK02094EA.CT_PrevYear_GoodsMGroup] = prevYearCpWork.GoodsMGroup;           // ���i�����ރR�[�h(Int32)
            dr[DCTOK02094EA.CT_PrevYear_GoodsMGroupName] = prevYearCpWork.GoodsMGroupName;	 // ���i�����ޖ���  (string)
            dr[DCTOK02094EA.CT_PrevYear_BLGroupCode] = prevYearCpWork.BLGroupCode;           // �O���[�v�R�[�h(Int32)
            dr[DCTOK02094EA.CT_PrevYear_BLGroupKanaName] = prevYearCpWork.BLGroupKanaName;	 // �O���[�v����  (string)

            // ���ڐݒ�ꏊ�𔻒�
            for (int i = 0; i < 12; i++)
            {
                if (Int32.Parse(this._monthArray[i].ToString().Substring(4, 2)) == prevYearCpWork.AddUpMonth)
                {
                    index = i + 1;
                    break;
                }
            }

            switch (index)
            {
                case 1:
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermSales1] = prevYearCpWork.ThisTermSales;     // ����z(����1������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermSales1] = prevYearCpWork.FirstTermSales;   // ����z(�O��1������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_SalesRatio1] = GetRatio(prevYearCpWork.ThisTermSales, prevYearCpWork.FirstTermSales);   // �����(1������)    (Double)
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermGross1] = prevYearCpWork.ThisTermGross;     // �e���z(����1������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermGross1] = prevYearCpWork.FirstTermGross;   // �e���z(�O��1������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_GrossRatio1] = GetRatio(prevYearCpWork.ThisTermGross, prevYearCpWork.FirstTermGross);   // �e����(1������)    (Double)
                    break;
                case 2:
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermSales2] = prevYearCpWork.ThisTermSales;     // ����z(����2������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermSales2] = prevYearCpWork.FirstTermSales;   // ����z(�O��2������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_SalesRatio2] = GetRatio(prevYearCpWork.ThisTermSales, prevYearCpWork.FirstTermSales);   // �����(2������)    (Double)
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermGross2] = prevYearCpWork.ThisTermGross;     // �e���z(����2������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermGross2] = prevYearCpWork.FirstTermGross;   // �e���z(�O��2������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_GrossRatio2] = GetRatio(prevYearCpWork.ThisTermGross, prevYearCpWork.FirstTermGross);   // �e����(2������)    (Double)
                    break;
                case 3:
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermSales3] = prevYearCpWork.ThisTermSales;     // ����z(����3������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermSales3] = prevYearCpWork.FirstTermSales;   // ����z(�O��3������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_SalesRatio3] = GetRatio(prevYearCpWork.ThisTermSales, prevYearCpWork.FirstTermSales);   // �����(3������)    (Double)
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermGross3] = prevYearCpWork.ThisTermGross;     // �e���z(����3������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermGross3] = prevYearCpWork.FirstTermGross;   // �e���z(�O��3������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_GrossRatio3] = GetRatio(prevYearCpWork.ThisTermGross, prevYearCpWork.FirstTermGross);   // �e����(3������)    (Double)
                    break;
                case 4:
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermSales4] = prevYearCpWork.ThisTermSales;     // ����z(����4������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermSales4] = prevYearCpWork.FirstTermSales;   // ����z(�O��4������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_SalesRatio4] = GetRatio(prevYearCpWork.ThisTermSales, prevYearCpWork.FirstTermSales);   // �����(4������)    (Double)
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermGross4] = prevYearCpWork.ThisTermGross;     // �e���z(����4������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermGross4] = prevYearCpWork.FirstTermGross;   // �e���z(�O��4������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_GrossRatio4] = GetRatio(prevYearCpWork.ThisTermGross, prevYearCpWork.FirstTermGross);   // �e����(4������)    (Double)
                    break;
                case 5:
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermSales5] = prevYearCpWork.ThisTermSales;     // ����z(����5������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermSales5] = prevYearCpWork.FirstTermSales;   // ����z(�O��5������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_SalesRatio5] = GetRatio(prevYearCpWork.ThisTermSales, prevYearCpWork.FirstTermSales);   // �����(5������)    (Double)
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermGross5] = prevYearCpWork.ThisTermGross;     // �e���z(����5������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermGross5] = prevYearCpWork.FirstTermGross;   // �e���z(�O��5������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_GrossRatio5] = GetRatio(prevYearCpWork.ThisTermGross, prevYearCpWork.FirstTermGross);   // �e����(5������)    (Double)
                    break;
                case 6:
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermSales6] = prevYearCpWork.ThisTermSales;     // ����z(����6������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermSales6] = prevYearCpWork.FirstTermSales;   // ����z(�O��6������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_SalesRatio6] = GetRatio(prevYearCpWork.ThisTermSales, prevYearCpWork.FirstTermSales);   // �����(6������)    (Double)
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermGross6] = prevYearCpWork.ThisTermGross;     // �e���z(����6������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermGross6] = prevYearCpWork.FirstTermGross;   // �e���z(�O��6������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_GrossRatio6] = GetRatio(prevYearCpWork.ThisTermGross, prevYearCpWork.FirstTermGross);   // �e����(6������)    (Double)
                    break;
                case 7:
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermSales7] = prevYearCpWork.ThisTermSales;     // ����z(����7������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermSales7] = prevYearCpWork.FirstTermSales;   // ����z(�O��7������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_SalesRatio7] = GetRatio(prevYearCpWork.ThisTermSales, prevYearCpWork.FirstTermSales);   // �����(7������)    (Double)
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermGross7] = prevYearCpWork.ThisTermGross;     // �e���z(����7������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermGross7] = prevYearCpWork.FirstTermGross;   // �e���z(�O��7������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_GrossRatio7] = GetRatio(prevYearCpWork.ThisTermGross, prevYearCpWork.FirstTermGross);   // �e����(7������)    (Double)
                    break;
                case 8:
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermSales8] = prevYearCpWork.ThisTermSales;     // ����z(����8������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermSales8] = prevYearCpWork.FirstTermSales;   // ����z(�O��8������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_SalesRatio8] = GetRatio(prevYearCpWork.ThisTermSales, prevYearCpWork.FirstTermSales);   // �����(8������)    (Double)
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermGross8] = prevYearCpWork.ThisTermGross;     // �e���z(����8������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermGross8] = prevYearCpWork.FirstTermGross;   // �e���z(�O��8������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_GrossRatio8] = GetRatio(prevYearCpWork.ThisTermGross, prevYearCpWork.FirstTermGross);   // �e����(8������)    (Double)
                    break;
                case 9:
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermSales9] = prevYearCpWork.ThisTermSales;     // ����z(����9������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermSales9] = prevYearCpWork.FirstTermSales;   // ����z(�O��9������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_SalesRatio9] = GetRatio(prevYearCpWork.ThisTermSales, prevYearCpWork.FirstTermSales);   // �����(9������)    (Double)
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermGross9] = prevYearCpWork.ThisTermGross;     // �e���z(����9������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermGross9] = prevYearCpWork.FirstTermGross;   // �e���z(�O��9������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_GrossRatio9] = GetRatio(prevYearCpWork.ThisTermGross, prevYearCpWork.FirstTermGross);   // �e����(9������)    (Double)
                    break;
                case 10:
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermSales10] = prevYearCpWork.ThisTermSales;     // ����z(����10������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermSales10] = prevYearCpWork.FirstTermSales;   // ����z(�O��10������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_SalesRatio10] = GetRatio(prevYearCpWork.ThisTermSales, prevYearCpWork.FirstTermSales);   // �����(10������)    (Double)
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermGross10] = prevYearCpWork.ThisTermGross;     // �e���z(����10������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermGross10] = prevYearCpWork.FirstTermGross;   // �e���z(�O��10������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_GrossRatio10] = GetRatio(prevYearCpWork.ThisTermGross, prevYearCpWork.FirstTermGross);   // �e����(10������)    (Double)
                    break;
                case 11:
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermSales11] = prevYearCpWork.ThisTermSales;     // ����z(����11������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermSales11] = prevYearCpWork.FirstTermSales;   // ����z(�O��11������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_SalesRatio11] = GetRatio(prevYearCpWork.ThisTermSales, prevYearCpWork.FirstTermSales);   // �����(11������)    (Double)
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermGross11] = prevYearCpWork.ThisTermGross;     // �e���z(����11������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermGross11] = prevYearCpWork.FirstTermGross;   // �e���z(�O��11������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_GrossRatio11] = GetRatio(prevYearCpWork.ThisTermGross, prevYearCpWork.FirstTermGross);   // �e����(11������)    (Double)
                    break;
                case 12:
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermSales12] = prevYearCpWork.ThisTermSales;     // ����z(����12������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermSales12] = prevYearCpWork.FirstTermSales;   // ����z(�O��12������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_SalesRatio12] = GetRatio(prevYearCpWork.ThisTermSales, prevYearCpWork.FirstTermSales);   // �����(12������)    (Double)
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermGross12] = prevYearCpWork.ThisTermGross;     // �e���z(����12������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermGross12] = prevYearCpWork.FirstTermGross;   // �e���z(�O��12������)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_GrossRatio12] = GetRatio(prevYearCpWork.ThisTermGross, prevYearCpWork.FirstTermGross);   // �e����(12������)    (Double)
                    break;
            }
            /*
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales1] = prevYearCpWork.ThisTermSales1;     // ����z(����1������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales1] = prevYearCpWork.FirstTermSales1;   // ����z(�O��1������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio1] = prevYearCpWork.SalesRatio1;           // �����(1������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross1] = prevYearCpWork.ThisTermGross1;     // �e���z(����1������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross1] = prevYearCpWork.FirstTermGross1;   // �e���z(�O��1������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio1] = prevYearCpWork.GrossRatio1;           // �e����(1������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales2] = prevYearCpWork.ThisTermSales2;     // ����z(����2������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales2] = prevYearCpWork.FirstTermSales2;   // ����z(�O��2������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio2] = prevYearCpWork.SalesRatio2;           // �����(2������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross2] = prevYearCpWork.ThisTermGross2;     // �e���z(����2������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross2] = prevYearCpWork.FirstTermGross2;   // �e���z(�O��2������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio2] = prevYearCpWork.GrossRatio2;           // �e����(2������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales3] = prevYearCpWork.ThisTermSales3;     // ����z(����3������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales3] = prevYearCpWork.FirstTermSales3;   // ����z(�O��3������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio3] = prevYearCpWork.SalesRatio3;           // �����(3������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross3] = prevYearCpWork.ThisTermGross3;     // �e���z(����3������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross3] = prevYearCpWork.FirstTermGross3;   // �e���z(�O��3������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio3] = prevYearCpWork.GrossRatio3;           // �e����(3������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales4] = prevYearCpWork.ThisTermSales4;     // ����z(����4������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales4] = prevYearCpWork.FirstTermSales4;   // ����z(�O��4������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio4] = prevYearCpWork.SalesRatio4;           // �����(4������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross4] = prevYearCpWork.ThisTermGross4;     // �e���z(����4������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross4] = prevYearCpWork.FirstTermGross4;   // �e���z(�O��4������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio4] = prevYearCpWork.GrossRatio4;           // �e����(4������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales5] = prevYearCpWork.ThisTermSales5;     // ����z(����5������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales5] = prevYearCpWork.FirstTermSales5;   // ����z(�O��5������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio5] = prevYearCpWork.SalesRatio5;           // �����(5������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross5] = prevYearCpWork.ThisTermGross5;     // �e���z(����5������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross5] = prevYearCpWork.FirstTermGross5;   // �e���z(�O��5������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio5] = prevYearCpWork.GrossRatio5;           // �e����(5������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales6] = prevYearCpWork.ThisTermSales6;     // ����z(����6������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales6] = prevYearCpWork.FirstTermSales6;   // ����z(�O��6������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio6] = prevYearCpWork.SalesRatio6;           // �����(6������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross6] = prevYearCpWork.ThisTermGross6;     // �e���z(����6������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross6] = prevYearCpWork.FirstTermGross6;   // �e���z(�O��6������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio6] = prevYearCpWork.GrossRatio6;           // �e����(6������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales7] = prevYearCpWork.ThisTermSales7;     // ����z(����7������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales7] = prevYearCpWork.FirstTermSales7;   // ����z(�O��7������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio7] = prevYearCpWork.SalesRatio7;           // �����(7������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross7] = prevYearCpWork.ThisTermGross7;     // �e���z(����7������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross7] = prevYearCpWork.FirstTermGross7;   // �e���z(�O��7������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio7] = prevYearCpWork.GrossRatio7;           // �e����(7������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales8] = prevYearCpWork.ThisTermSales8;     // ����z(����8������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales8] = prevYearCpWork.FirstTermSales8;   // ����z(�O��8������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio8] = prevYearCpWork.SalesRatio8;           // �����(8������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross8] = prevYearCpWork.ThisTermGross8;     // �e���z(����8������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross8] = prevYearCpWork.FirstTermGross8;   // �e���z(�O��8������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio8] = prevYearCpWork.GrossRatio8;           // �e����(8������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales9] = prevYearCpWork.ThisTermSales9;     // ����z(����9������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales9] = prevYearCpWork.FirstTermSales9;   // ����z(�O��9������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio9] = prevYearCpWork.SalesRatio9;           // �����(9������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross9] = prevYearCpWork.ThisTermGross9;     // �e���z(����9������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross9] = prevYearCpWork.FirstTermGross9;   // �e���z(�O��9������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio9] = prevYearCpWork.GrossRatio9;           // �e����(9������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales10] = prevYearCpWork.ThisTermSales10;     // ����z(����10������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales10] = prevYearCpWork.FirstTermSales10;   // ����z(�O��10������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio10] = prevYearCpWork.SalesRatio10;           // �����(10������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross10] = prevYearCpWork.ThisTermGross10;     // �e���z(����10������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross10] = prevYearCpWork.FirstTermGross10;   // �e���z(�O��10������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio10] = prevYearCpWork.GrossRatio10;           // �e����(10������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales11] = prevYearCpWork.ThisTermSales11;     // ����z(����11������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales11] = prevYearCpWork.FirstTermSales11;   // ����z(�O��11������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio11] = prevYearCpWork.SalesRatio11;           // �����(11������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross11] = prevYearCpWork.ThisTermGross11;     // �e���z(����11������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross11] = prevYearCpWork.FirstTermGross11;   // �e���z(�O��11������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio11] = prevYearCpWork.GrossRatio11;           // �e����(11������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales12] = prevYearCpWork.ThisTermSales12;     // ����z(����12������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales12] = prevYearCpWork.FirstTermSales12;   // ����z(�O��12������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio12] = prevYearCpWork.SalesRatio12;           // �����(12������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross12] = prevYearCpWork.ThisTermGross12;     // �e���z(����12������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross12] = prevYearCpWork.FirstTermGross12;   // �e���z(�O��12������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio12] = prevYearCpWork.GrossRatio12;           // �e����(12������)    (Double)
            //TODO �ȉ������Őݒ肷�鍀��
            // �������v����z    (Int64)
            long _thisTermTotalSales = prevYearCpWork.ThisTermSales1 + prevYearCpWork.ThisTermSales2 + prevYearCpWork.ThisTermSales3 + prevYearCpWork.ThisTermSales4
                                        + prevYearCpWork.ThisTermSales5 + prevYearCpWork.ThisTermSales6 + prevYearCpWork.ThisTermSales7 + prevYearCpWork.ThisTermSales8
                                        + prevYearCpWork.ThisTermSales9 + prevYearCpWork.ThisTermSales10 + prevYearCpWork.ThisTermSales11 + prevYearCpWork.ThisTermSales12;
            dr[DCTOK02094EA.CT_PrevYear_thisTermTotalSales] = _thisTermTotalSales;

            // �O�����v����z    (Int64)
            long _firstTermTotalSales = prevYearCpWork.FirstTermSales1 + prevYearCpWork.FirstTermSales2 + prevYearCpWork.FirstTermSales3 + prevYearCpWork.FirstTermSales4
                                                            + prevYearCpWork.FirstTermSales5 + prevYearCpWork.FirstTermSales6 + prevYearCpWork.FirstTermSales7 + prevYearCpWork.FirstTermSales8
                                                            + prevYearCpWork.FirstTermSales9 + prevYearCpWork.FirstTermSales10 + prevYearCpWork.FirstTermSales11 + prevYearCpWork.FirstTermSales12;
            dr[DCTOK02094EA.CT_PrevYear_firstTermTotalSales] = _firstTermTotalSales;

            // �N�v�����    (Double)
            if (_firstTermTotalSales != 0)
            {
                Double d_thisTermTotalSales = Convert.ToDouble(_thisTermTotalSales) * 100;
                Double d_firstTermTotalSales = Convert.ToDouble(_firstTermTotalSales);

                Double _totalSalesRatio = Math.Round((d_thisTermTotalSales / d_firstTermTotalSales), 4);	//�����_��܈ʂ��ۂ�
                dr[DCTOK02094EA.CT_PrevYear_totalSalesRatio] = Math.Round(_totalSalesRatio, 2, MidpointRounding.AwayFromZero);//�����_��O�ʂ��l�̌ܓ�
            }
            else
            {
                dr[DCTOK02094EA.CT_PrevYear_totalSalesRatio] = 0;
            }
            // �������v�e���z    (Int64)
            long _thisTermTotalGross = prevYearCpWork.ThisTermGross1 + prevYearCpWork.ThisTermGross2 + prevYearCpWork.ThisTermGross3 + prevYearCpWork.ThisTermGross4
                                        + prevYearCpWork.ThisTermGross5 + prevYearCpWork.ThisTermGross6 + prevYearCpWork.ThisTermGross7 + prevYearCpWork.ThisTermGross8
                                        + prevYearCpWork.ThisTermGross9 + prevYearCpWork.ThisTermGross10 + prevYearCpWork.ThisTermGross11 + prevYearCpWork.ThisTermGross12;
            dr[DCTOK02094EA.CT_PrevYear_thisTermTotalGross] = _thisTermTotalGross;

            // �O�����v�e���z    (Int64)
            long _firstTermTotalGross = prevYearCpWork.FirstTermGross1 + prevYearCpWork.FirstTermGross2 + prevYearCpWork.FirstTermGross3 + prevYearCpWork.FirstTermGross4
                                        + prevYearCpWork.FirstTermGross5 + prevYearCpWork.FirstTermGross6 + prevYearCpWork.FirstTermGross7 + prevYearCpWork.FirstTermGross8
                                        + prevYearCpWork.FirstTermGross9 + prevYearCpWork.FirstTermGross10 + prevYearCpWork.FirstTermGross11 + prevYearCpWork.FirstTermGross12;
            dr[DCTOK02094EA.CT_PrevYear_firstTermTotalGross] = _firstTermTotalGross;

            // �N�v�e����    (Double)
            if (_firstTermTotalGross != 0)
            {
                Double d_thisTermTotalGross = Convert.ToDouble(_thisTermTotalGross * 100);
                Double d_firstTermTotalGross = Convert.ToDouble(_firstTermTotalGross);

                Double _totalGrossRatio = Math.Round((d_thisTermTotalGross / _firstTermTotalGross), 4);		//�����_��܈ʂ��ۂ�
                dr[DCTOK02094EA.CT_PrevYear_totalGrossRatio] = Math.Round(_totalGrossRatio, 2, MidpointRounding.AwayFromZero); //�����_��O�ʂ��l�̌ܓ�
            }
            else
            {
                dr[DCTOK02094EA.CT_PrevYear_totalGrossRatio] = 0;
            }
          */
        }

        /// <summary>
        /// �f�[�^Row�쐬�i���v�l�Z�o)
        /// </summary>
        /// <param name="dr"></param>
        /// <remarks>
        /// <br>Update Note : 2015/08/17 cheq </br>
        /// <br>�Ǘ��ԍ�    : 11170129-00</br>
        /// <br>            : redmine#47029 �䗦�Z�o�s���̏�Q�Ή�</br>
        /// </remarks> 
        private void SetTebleRowFromRetListSum(ref DataRow dr)
        {
            //TODO �ȉ������Őݒ肷�鍀��
            // �������v����z    (Int64)
            long _thisTermTotalSales = Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales1].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales2].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales3].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales4].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales5].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales6].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales7].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales8].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales9].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales10].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales11].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales12].ToString());
            //dr[DCTOK02094EA.CT_PrevYear_thisTermTotalSales] = _thisTermTotalSales;                        //DEL 2009/01/30 �s��Ή�[9844]
            //dr[DCTOK02094EA.CT_PrevYear_thisTermTotalSales] = this.SetMoneyUnit(_thisTermTotalSales);       //ADD 2009/01/30 �s��Ή�[9844]     // DEL 2009/04/16
            dr[DCTOK02094EA.CT_PrevYear_thisTermTotalSales] = _thisTermTotalSales;          // ADD 2009/04/16         
            
            // �O�����v����z    (Int64)
            long _firstTermTotalSales = Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales1].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales2].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales3].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales4].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales5].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales6].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales7].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales8].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales9].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales10].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales11].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales12].ToString());
            //dr[DCTOK02094EA.CT_PrevYear_firstTermTotalSales] = _firstTermTotalSales;                      //DEL 2009/01/30 �s��Ή�[9844]
            //dr[DCTOK02094EA.CT_PrevYear_firstTermTotalSales] = this.SetMoneyUnit(_firstTermTotalSales);     //ADD 2009/01/30 �s��Ή�[9844]     // DEL 2009/04/16
            dr[DCTOK02094EA.CT_PrevYear_firstTermTotalSales] = _firstTermTotalSales;        // ADD 2009/04/16

            // �N�v�����    (Double)
            //-----DEL cheq 2015/08/17 for Redmine#47029 �䗦�Z�o�s���̏�Q�Ή�---------->>>>>
            //if (_firstTermTotalSales != 0)
            //{
            //    Double d_thisTermTotalSales = Convert.ToDouble(_thisTermTotalSales) * 100;
            //    Double d_firstTermTotalSales = Convert.ToDouble(_firstTermTotalSales);

            //    Double _totalSalesRatio = Math.Round((d_thisTermTotalSales / d_firstTermTotalSales), 4);	//�����_��܈ʂ��ۂ� 
            //    dr[DCTOK02094EA.CT_PrevYear_totalSalesRatio] = Math.Round(_totalSalesRatio, 2, MidpointRounding.AwayFromZero);//�����_��O�ʂ��l�̌ܓ�

            //}
            //else
            //{
            //    dr[DCTOK02094EA.CT_PrevYear_totalSalesRatio] = 0;
            //}
            //-----DEL cheq 2015/08/17 for Redmine#47029 �䗦�Z�o�s���̏�Q�Ή�----------<<<<<
            dr[DCTOK02094EA.CT_PrevYear_totalSalesRatio] = GetRatio(_thisTermTotalSales, _firstTermTotalSales); // ADD cheq 2015/08/17 RedMine#47029 �䗦�Z�o�s���̏�Q�Ή�

            // �������v�e���z    (Int64)
            long _thisTermTotalGross = Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross1].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross2].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross3].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross4].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross5].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross6].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross7].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross8].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross9].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross10].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross11].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross12].ToString());
            //dr[DCTOK02094EA.CT_PrevYear_thisTermTotalGross] = _thisTermTotalGross;                        //DEL 2009/01/30 �s��Ή�[9844]
            //dr[DCTOK02094EA.CT_PrevYear_thisTermTotalGross] = this.SetMoneyUnit(_thisTermTotalGross);       //ADD 2009/01/30 �s��Ή�[9844]     // DEL 2009/04/16
            dr[DCTOK02094EA.CT_PrevYear_thisTermTotalGross] = _thisTermTotalGross;          // ADD 2009/04/16

            // �O�����v�e���z    (Int64)
            long _firstTermTotalGross = Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross1].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross2].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross3].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross4].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross5].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross6].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross7].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross8].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross9].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross10].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross11].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross12].ToString());
            //dr[DCTOK02094EA.CT_PrevYear_firstTermTotalGross] = _firstTermTotalGross;                      //DEL 2009/01/30 �s��Ή�[9844]
            //dr[DCTOK02094EA.CT_PrevYear_firstTermTotalGross] = this.SetMoneyUnit(_firstTermTotalGross);     //ADD 2009/01/30 �s��Ή�[9844]     // DEL 2009/04/16
            dr[DCTOK02094EA.CT_PrevYear_firstTermTotalGross] = _firstTermTotalGross;        // ADD 2009/04/16

            // �N�v�e����    (Double)
            //-----DEL cheq 2015/08/17 for Redmine#47029 �䗦�Z�o�s���̏�Q�Ή�---------->>>>>
            //if (_firstTermTotalGross != 0)
            //{
            //    Double d_thisTermTotalGross = Convert.ToDouble(_thisTermTotalGross * 100);
            //    Double d_firstTermTotalGross = Convert.ToDouble(_firstTermTotalGross);

            //    Double _totalGrossRatio = Math.Round((d_thisTermTotalGross / _firstTermTotalGross), 4);		//�����_��܈ʂ��ۂ�
            //    dr[DCTOK02094EA.CT_PrevYear_totalGrossRatio] = Math.Round(_totalGrossRatio, 2, MidpointRounding.AwayFromZero); //�����_��O�ʂ��l�̌ܓ�
            //}
            //else
            //{
            //    dr[DCTOK02094EA.CT_PrevYear_totalGrossRatio] = 0;
            //}
            //-----DEL cheq 2015/08/17 for Redmine#47029 �䗦�Z�o�s���̏�Q�Ή�----------<<<<<
            dr[DCTOK02094EA.CT_PrevYear_totalGrossRatio] = GetRatio(_thisTermTotalGross, _firstTermTotalGross); // ADD cheq 2015/08/17 RedMine#47029 �䗦�Z�o�s���̏�Q�Ή�

            // DEL 2009/04/16 ------>>>
            //// ---ADD 2009/01/30 �s��Ή�[9844] ---------------------------------------------------------------------------------------->>>>>
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermSales1] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales1]);     // ����z(����1������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermSales1] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales1]);   // ����z(�O��1������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermGross1] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross1]);     // �e���z(����1������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermGross1] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross1]);   // �e���z(�O��1������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermSales2] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales2]);     // ����z(����2������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermSales2] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales2]);   // ����z(�O��2������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermGross2] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross2]);     // �e���z(����2������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermGross2] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross2]);   // �e���z(�O��2������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermSales3] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales3]);     // ����z(����3������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermSales3] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales3]);   // ����z(�O��3������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermGross3] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross3]);     // �e���z(����3������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermGross3] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross3]);   // �e���z(�O��3������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermSales4] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales4]);     // ����z(����4������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermSales4] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales4]);   // ����z(�O��4������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermGross4] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross4]);     // �e���z(����4������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermGross4] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross4]);   // �e���z(�O��4������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermSales5] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales5]);     // ����z(����5������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermSales5] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales5]);   // ����z(�O��5������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermGross5] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross5]);     // �e���z(����5������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermGross5] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross5]);   // �e���z(�O��5������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermSales6] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales6]);     // ����z(����6������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermSales6] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales6]);   // ����z(�O��6������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermGross6] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross6]);     // �e���z(����6������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermGross6] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross6]);   // �e���z(�O��6������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermSales7] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales7]);     // ����z(����7������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermSales7] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales7]);   // ����z(�O��7������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermGross7] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross7]);     // �e���z(����7������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermGross7] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross7]);   // �e���z(�O��7������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermSales8] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales8]);     // ����z(����8������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermSales8] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales8]);   // ����z(�O��8������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermGross8] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross8]);     // �e���z(����8������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermGross8] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross8]);   // �e���z(�O��8������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermSales9] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales9]);     // ����z(����9������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermSales9] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales9]);   // ����z(�O��9������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermGross9] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross9]);     // �e���z(����9������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermGross9] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross9]);   // �e���z(�O��9������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermSales10] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales10]);     // ����z(����10������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermSales10] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales10]);   // ����z(�O��10������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermGross10] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross10]);     // �e���z(����10������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermGross10] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross10]);   // �e���z(�O��10������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermSales11] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales11]);     // ����z(����11������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermSales11] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales11]);   // ����z(�O��11������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermGross11] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross11]);     // �e���z(����11������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermGross11] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross11]);   // �e���z(�O��11������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermSales12] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales12]);     // ����z(����12������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermSales12] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales12]);   // ����z(�O��12������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermGross12] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross12]);     // �e���z(����12������)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermGross12] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross12]);   // �e���z(�O��12������)(Int64)
            //// ---ADD 2009/01/30 �s��Ή�[9844] ----------------------------------------------------------------------------------------<<<<<
            // DEL 2009/04/16 ------<<<
        }
        // ---ADD 2009/01/30 �s��Ή�[9844] --------------------------------->>>>>
        private Int64 SetMoneyUnit(object value)
        {
            Int64 result = 0;
            try
            {
                result = Int64.Parse(value.ToString());
            }
            catch
            {
                return 0;
            }

            return SetMoneyUnit(result);
        }
        private Int64 SetMoneyUnit(Int64 value)
        {
            Int64 result = 0;
            int moneyUnitValue = 0;
            if (this._moneyUnit == 0)
            {
                moneyUnitValue = 1;
            }
            else
            {
                moneyUnitValue = 1000;
            }

            try
            {
                result = (Int64)Math.Floor((Double)(value / moneyUnitValue));
            }
            catch
            {
                return 0;
            }

            return result;
        }
        // ---ADD 2009/01/30 �s��Ή�[9844] ---------------------------------<<<<<

        /// <summary>
        /// �f�[�^Row�쐬
        /// </summary>
        /// <param name="dr">�Z�b�g�Ώ�DataRow</param>
        /// <param name="sourceDataRow">�Z�b�g��DataRow</param>
        private void SetTebleRowFromDataRow(ref DataRow dr, DataRow sourceDataRow)
        {
            dr[DCTOK02094EA.CT_PrevYear_AddUpSecCode] = sourceDataRow[DCTOK02094EA.CT_PrevYear_AddUpSecCode];		  // �v�㋒�_�R�[�h(string)
            dr[DCTOK02094EA.CT_PrevYear_SectionGuidNm] = sourceDataRow[DCTOK02094EA.CT_PrevYear_SectionGuidNm];		  // ���_�K�C�h����     (string)
            dr[DCTOK02094EA.CT_PrevYear_EmployeeCode] = sourceDataRow[DCTOK02094EA.CT_PrevYear_EmployeeCode];         // �]�ƈ��R�[�h  (string)
            dr[DCTOK02094EA.CT_PrevYear_EmployeeName] = sourceDataRow[DCTOK02094EA.CT_PrevYear_EmployeeName];         // �]�ƈ�����    (string)
            dr[DCTOK02094EA.CT_PrevYear_CustomerCode] = sourceDataRow[DCTOK02094EA.CT_PrevYear_CustomerCode];         // ���Ӑ�R�[�h  (Int32)
            dr[DCTOK02094EA.CT_PrevYear_CustomerSnm] = sourceDataRow[DCTOK02094EA.CT_PrevYear_CustomerSnm];           // ���Ӑ旪��    (string)
            dr[DCTOK02094EA.CT_PrevYear_BusinessTypeCode] = sourceDataRow[DCTOK02094EA.CT_PrevYear_BusinessTypeCode]; // �Ǝ�R�[�h    (Int32)
            dr[DCTOK02094EA.CT_PrevYear_BusinessTypeName] = sourceDataRow[DCTOK02094EA.CT_PrevYear_BusinessTypeName]; // �Ǝ햼��		(string)
            dr[DCTOK02094EA.CT_PrevYear_SalesAreaCode] = sourceDataRow[DCTOK02094EA.CT_PrevYear_SalesAreaCode];       // �̔��G���A�R�[�h(Int32)
            dr[DCTOK02094EA.CT_PrevYear_SalesAreaName] = sourceDataRow[DCTOK02094EA.CT_PrevYear_SalesAreaName];		  // �̔��G���A����  (string)
            dr[DCTOK02094EA.CT_PrevYear_BLGoodsCode] = sourceDataRow[DCTOK02094EA.CT_PrevYear_BLGoodsCode];           // BL�R�[�h(Int32)
            dr[DCTOK02094EA.CT_PrevYear_BLGoodsHalfName] = sourceDataRow[DCTOK02094EA.CT_PrevYear_BLGoodsHalfName];	�@// BL����  (string)
            dr[DCTOK02094EA.CT_PrevYear_GoodsLGroup] = sourceDataRow[DCTOK02094EA.CT_PrevYear_GoodsLGroup];           // ���i�啪�ރR�[�h(Int32)
            dr[DCTOK02094EA.CT_PrevYear_GoodsLGroupName] = sourceDataRow[DCTOK02094EA.CT_PrevYear_GoodsLGroupName];	�@// ���i�啪�ޖ���  (string)
            dr[DCTOK02094EA.CT_PrevYear_GoodsMGroup] = sourceDataRow[DCTOK02094EA.CT_PrevYear_GoodsMGroup];           // ���i�����ރR�[�h(Int32)
            dr[DCTOK02094EA.CT_PrevYear_GoodsMGroupName] = sourceDataRow[DCTOK02094EA.CT_PrevYear_GoodsMGroupName];	�@// ���i�����ޖ���  (string)
            dr[DCTOK02094EA.CT_PrevYear_BLGroupCode] = sourceDataRow[DCTOK02094EA.CT_PrevYear_BLGroupCode];           // �O���[�v�R�[�h(Int32)
            dr[DCTOK02094EA.CT_PrevYear_BLGroupKanaName] = sourceDataRow[DCTOK02094EA.CT_PrevYear_BLGroupKanaName];	�@// �O���[�v����  (string)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales1] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermSales1];     // ����z(����1������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales1] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermSales1];   // ����z(�O��1������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio1] = sourceDataRow[DCTOK02094EA.CT_PrevYear_SalesRatio1];           // �����(1������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross1] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermGross1];     // �e���z(����1������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross1] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermGross1];   // �e���z(�O��1������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio1] = sourceDataRow[DCTOK02094EA.CT_PrevYear_GrossRatio1];           // �e����(1������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales2] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermSales2];     // ����z(����2������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales2] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermSales2];   // ����z(�O��2������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio2] = sourceDataRow[DCTOK02094EA.CT_PrevYear_SalesRatio2];           // �����(2������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross2] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermGross2];     // �e���z(����2������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross2] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermGross2];   // �e���z(�O��2������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio2] = sourceDataRow[DCTOK02094EA.CT_PrevYear_GrossRatio2];           // �e����(2������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales3] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermSales3];     // ����z(����3������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales3] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermSales3];   // ����z(�O��3������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio3] = sourceDataRow[DCTOK02094EA.CT_PrevYear_SalesRatio3];           // �����(3������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross3] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermGross3];     // �e���z(����3������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross3] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermGross3];   // �e���z(�O��3������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio3] = sourceDataRow[DCTOK02094EA.CT_PrevYear_GrossRatio3];           // �e����(3������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales4] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermSales4];     // ����z(����4������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales4] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermSales4];   // ����z(�O��4������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio4] = sourceDataRow[DCTOK02094EA.CT_PrevYear_SalesRatio4];           // �����(4������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross4] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermGross4];     // �e���z(����4������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross4] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermGross4];   // �e���z(�O��4������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio4] = sourceDataRow[DCTOK02094EA.CT_PrevYear_GrossRatio4];           // �e����(4������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales5] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermSales5];     // ����z(����5������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales5] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermSales5];   // ����z(�O��5������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio5] = sourceDataRow[DCTOK02094EA.CT_PrevYear_SalesRatio5];           // �����(5������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross5] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermGross5];     // �e���z(����5������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross5] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermGross5];   // �e���z(�O��5������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio5] = sourceDataRow[DCTOK02094EA.CT_PrevYear_GrossRatio5];           // �e����(5������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales6] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermSales6];     // ����z(����6������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales6] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermSales6];   // ����z(�O��6������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio6] = sourceDataRow[DCTOK02094EA.CT_PrevYear_SalesRatio6];           // �����(6������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross6] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermGross6];     // �e���z(����6������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross6] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermGross6];   // �e���z(�O��6������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio6] = sourceDataRow[DCTOK02094EA.CT_PrevYear_GrossRatio6];           // �e����(6������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales7] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermSales7];     // ����z(����7������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales7] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermSales7];   // ����z(�O��7������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio7] = sourceDataRow[DCTOK02094EA.CT_PrevYear_SalesRatio7];           // �����(7������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross7] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermGross7];     // �e���z(����7������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross7] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermGross7];   // �e���z(�O��7������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio7] = sourceDataRow[DCTOK02094EA.CT_PrevYear_GrossRatio7];           // �e����(7������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales8] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermSales8];     // ����z(����8������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales8] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermSales8];   // ����z(�O��8������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio8] = sourceDataRow[DCTOK02094EA.CT_PrevYear_SalesRatio8];           // �����(8������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross8] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermGross8];     // �e���z(����8������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross8] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermGross8];   // �e���z(�O��8������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio8] = sourceDataRow[DCTOK02094EA.CT_PrevYear_GrossRatio8];           // �e����(8������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales9] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermSales9];     // ����z(����9������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales9] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermSales9];   // ����z(�O��9������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio9] = sourceDataRow[DCTOK02094EA.CT_PrevYear_SalesRatio9];           // �����(9������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross9] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermGross9];     // �e���z(����9������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross9] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermGross9];   // �e���z(�O��9������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio9] = sourceDataRow[DCTOK02094EA.CT_PrevYear_GrossRatio9];           // �e����(9������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales10] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermSales10];     // ����z(����10������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales10] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermSales10];   // ����z(�O��10������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio10] = sourceDataRow[DCTOK02094EA.CT_PrevYear_SalesRatio10];           // �����(10������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross10] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermGross10];     // �e���z(����10������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross10] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermGross10];   // �e���z(�O��10������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio10] = sourceDataRow[DCTOK02094EA.CT_PrevYear_GrossRatio10];           // �e����(10������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales11] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermSales11];     // ����z(����11������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales11] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermSales11];   // ����z(�O��11������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio11] = sourceDataRow[DCTOK02094EA.CT_PrevYear_SalesRatio11];           // �����(11������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross11] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermGross11];     // �e���z(����11������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross11] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermGross11];   // �e���z(�O��11������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio11] = sourceDataRow[DCTOK02094EA.CT_PrevYear_GrossRatio11];           // �e����(11������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales12] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermSales12];     // ����z(����12������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales12] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermSales12];   // ����z(�O��12������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio12] = sourceDataRow[DCTOK02094EA.CT_PrevYear_SalesRatio12];           // �����(12������)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross12] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermGross12];     // �e���z(����12������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross12] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermGross12];   // �e���z(�O��12������)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio12] = sourceDataRow[DCTOK02094EA.CT_PrevYear_GrossRatio12];           // �e����(12������)    (Double)
            //TODO �ȉ������Ōv�Z���鍀��
            dr[DCTOK02094EA.CT_PrevYear_thisTermTotalSales] = sourceDataRow[DCTOK02094EA.CT_PrevYear_thisTermTotalSales];	// �������v����z    (Int64)
            dr[DCTOK02094EA.CT_PrevYear_firstTermTotalSales] = sourceDataRow[DCTOK02094EA.CT_PrevYear_firstTermTotalSales];	// �O�����v����z    (Int64)
            dr[DCTOK02094EA.CT_PrevYear_totalSalesRatio] = sourceDataRow[DCTOK02094EA.CT_PrevYear_totalSalesRatio];			// �N�v�����    (Double)
            dr[DCTOK02094EA.CT_PrevYear_totalSalesRatio] = sourceDataRow[DCTOK02094EA.CT_PrevYear_totalSalesRatio];			// �������v�e���z    (Int64)
            dr[DCTOK02094EA.CT_PrevYear_firstTermTotalGross] = sourceDataRow[DCTOK02094EA.CT_PrevYear_firstTermTotalGross];	// �O�����v�e���z    (Int64)
            dr[DCTOK02094EA.CT_PrevYear_totalGrossRatio] = sourceDataRow[DCTOK02094EA.CT_PrevYear_totalGrossRatio];			// �N�v�e����    (Double)
        }

        /// <summary>
        /// ���_����A�N�Z�X�N���X�C���X�^���X������
        /// </summary>
        internal void CreateSecInfoAcs()
        {
            if (_secInfoAcs == null)
            {
                _secInfoAcs = new SecInfoAcs();
            }

            // ���O�C���S�����_���̎擾
            if (_secInfoAcs.SecInfoSet == null)
            {
                throw new ApplicationException(MESSAGE_NONOWNSECTION);
            }
        }

        /// <summary>
        /// ���Z�o
        /// </summary>
        /// <param name="ThisVal"></param>
        /// <param name="FirstVal"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note : 2015/08/17 cheq </br>
        /// <br>�Ǘ��ԍ�    : 11170129-00</br>
        /// <br>            : redmine#47029 �䗦�Z�o�s���̏�Q�Ή�</br>
        /// </remarks>
        private Double GetRatio(long ThisVal, long FirstVal)
        {
            Double rtnval = 0;

            if (FirstVal == 0)
            {
                return rtnval;
            }

            //-----DEL cheq 2015/08/17 for Redmine#47029 �䗦�Z�o�s���̏�Q�Ή�---------->>>>>
            //Double d_thisTermTotalSales = Convert.ToDouble(ThisVal) * 100;
            //Double d_firstTermTotalSales = Convert.ToDouble(FirstVal);

            //Double _totalSalesRatio = Math.Round((d_thisTermTotalSales / d_firstTermTotalSales), 4);	//�����_��܈ʂ��ۂ�
            //rtnval = Math.Round(_totalSalesRatio, 2, MidpointRounding.AwayFromZero);//�����_��O�ʂ��l�̌ܓ�
            //-----DEL cheq 2015/08/17 for Redmine#47029 �䗦�Z�o�s���̏�Q�Ή�----------<<<<<

            //---ADD cheq 2015/08/17 RedMine#47029 �䗦�Z�o�s���̏�Q�Ή�---------->>>>>
            decimal d_thisTermTotalSales = ThisVal * 100;
            decimal d_firstTermTotalSales = FirstVal;

            decimal _totalSalesRatio = d_thisTermTotalSales / d_firstTermTotalSales;
            decimal d_rtnval = Math.Round(_totalSalesRatio, 2, MidpointRounding.AwayFromZero);//�����_��O�ʂ��l�̌ܓ�
            rtnval = Convert.ToDouble(d_rtnval);
            //---ADD cheq 2015/08/17 RedMine#47029 �䗦�Z�o�s���̏�Q�Ή�----------<<<<<

            return rtnval;
        }

        /// <summary>
        /// �䗦�����`�F�b�N����
        /// </summary>
        /// <remarks>
        /// <br>Update Note : 2015/08/17 cheq </br>
        /// <br>�Ǘ��ԍ�    : 11170129-00</br>
        /// <br>            : redmine#47029 �O�N�ΑΕ\�G���[�����������Q�Ή�</br>
        /// </remarks>
        private void CheckVal(ExtrInfo_DCTOK02093E PrYearCpListCndtn)
        {            
            int index = 0;
            bool ckflg = false;
            string SalesFild = "";
            string GrossFild = "";

            #region �Ώۃt�B�[���h�ݒ�
            // -----DEL cheq 2015/08/17 for Redmine#47029 �O�N�ΑΕ\�G���[����������̑Ή�---------->>>>>
            //for (int i = 0; i < 12; i++)
            //{
            //    if (Int32.Parse(this._monthArray[i].ToString()) == 0)
            //    {
            //        index = i;
            //        break;
            //    }
            //}
            // -----DEL cheq 2015/08/17 for Redmine#47029 �O�N�ΑΕ\�G���[����������̑Ή�----------<<<<<
            // -----ADD cheq 2015/08/17 for Redmine#47029 �O�N�ΑΕ\�G���[����������̑Ή�---------->>>>>
            for (int i = 0; i < this._monthArray.Length; i++)
            {
                if (Int32.Parse(this._monthArray[i].ToString()) != 0)
                {
                    index++;
                }
            }
            // -----ADD cheq 2015/08/17 for Redmine#47029 �O�N�ΑΕ\�G���[����������̑Ή�----------<<<<<
            switch (index)
            {
                case 1:
                    SalesFild = DCTOK02094EA.CT_PrevYear_SalesRatio1;
                    GrossFild = DCTOK02094EA.CT_PrevYear_GrossRatio1;
                    break;
                case 2:
                    SalesFild = DCTOK02094EA.CT_PrevYear_SalesRatio2;
                    GrossFild = DCTOK02094EA.CT_PrevYear_GrossRatio2;
                    break;
                case 3:
                    SalesFild = DCTOK02094EA.CT_PrevYear_SalesRatio3;
                    GrossFild = DCTOK02094EA.CT_PrevYear_GrossRatio3;
                    break;
                case 4:
                    SalesFild = DCTOK02094EA.CT_PrevYear_SalesRatio4;
                    GrossFild = DCTOK02094EA.CT_PrevYear_GrossRatio4;
                    break;
                case 5:
                    SalesFild = DCTOK02094EA.CT_PrevYear_SalesRatio5;
                    GrossFild = DCTOK02094EA.CT_PrevYear_GrossRatio5;
                    break;
                case 6:
                    SalesFild = DCTOK02094EA.CT_PrevYear_SalesRatio6;
                    GrossFild = DCTOK02094EA.CT_PrevYear_GrossRatio6;
                    break;
                case 7:
                    SalesFild = DCTOK02094EA.CT_PrevYear_SalesRatio7;
                    GrossFild = DCTOK02094EA.CT_PrevYear_GrossRatio7;
                    break;
                case 8:
                    SalesFild = DCTOK02094EA.CT_PrevYear_SalesRatio8;
                    GrossFild = DCTOK02094EA.CT_PrevYear_GrossRatio8;
                    break;
                case 9:
                    SalesFild = DCTOK02094EA.CT_PrevYear_SalesRatio9;
                    GrossFild = DCTOK02094EA.CT_PrevYear_GrossRatio9;
                    break;
                case 10:
                    SalesFild = DCTOK02094EA.CT_PrevYear_SalesRatio10;
                    GrossFild = DCTOK02094EA.CT_PrevYear_GrossRatio10;
                    break;
                case 11:
                    SalesFild = DCTOK02094EA.CT_PrevYear_SalesRatio11;
                    GrossFild = DCTOK02094EA.CT_PrevYear_GrossRatio11;
                    break;
                case 12:
                    SalesFild = DCTOK02094EA.CT_PrevYear_SalesRatio12;
                    GrossFild = DCTOK02094EA.CT_PrevYear_GrossRatio12;
                    break;
            }
            #endregion

            for (int i = 0; i < this._printDataSet.Tables[_PrevYearCpDataTable].Rows.Count; i++)
            {
                DataRow dr;

                dr = this._printDataSet.Tables[_PrevYearCpDataTable].Rows[i];
                ckflg = false;
                //����������(�J�n)
                if (PrYearCpListCndtn.St_MonthSalesRatio_ck == true)
                {
                    //if (Int64.Parse(dr[SalesFild].ToString()) < PrYearCpListCndtn.St_MonthSalesRatio)         //DEL 2009/01/29 �s��Ή�[9849]
                    if (Double.Parse(dr[SalesFild].ToString()) < PrYearCpListCndtn.St_MonthSalesRatio)          //ADD 2009/01/29 �s��Ή�[9849]
                    {
                        ckflg = true;
                    }
                }
                //����������(�I��)
                if (PrYearCpListCndtn.Ed_MonthSalesRatio_ck == true)
                {
                    //if (Int64.Parse(dr[SalesFild].ToString()) > PrYearCpListCndtn.Ed_MonthSalesRatio)         //DEL 2009/01/29 �s��Ή�[9849]
                    if (Double.Parse(dr[SalesFild].ToString()) > PrYearCpListCndtn.Ed_MonthSalesRatio)          //ADD 2009/01/29 �s��Ή�[9849]
                    {
                        ckflg = true;
                    }
                }
                //���N������(�J�n)
                if (PrYearCpListCndtn.St_YearSalesRatio_ck == true)
                {
                    //if (Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_totalSalesRatio].ToString()) < PrYearCpListCndtn.St_YearSalesRatio)   //DEL 2009/01/29 �s��Ή�[9849]
                    if (Double.Parse(dr[DCTOK02094EA.CT_PrevYear_totalSalesRatio].ToString()) < PrYearCpListCndtn.St_YearSalesRatio)    //ADD 2009/01/29 �s��Ή�[9849]
                    {
                        ckflg = true;
                    }
                }
                //���N������(�I��)
                if (PrYearCpListCndtn.Ed_YearSalesRatio_ck == true)
                {
                    //if (Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_totalSalesRatio].ToString()) > PrYearCpListCndtn.Ed_YearSalesRatio)   //DEL 2009/01/29 �s��Ή�[9849]
                    if (Double.Parse(dr[DCTOK02094EA.CT_PrevYear_totalSalesRatio].ToString()) > PrYearCpListCndtn.Ed_YearSalesRatio)    //ADD 2009/01/29 �s��Ή�[9849]
                    {
                        ckflg = true;
                    }
                }
                //�����e��(�J�n)
                if (PrYearCpListCndtn.St_MonthGrossRatio_ck == true)
                {
                    //if (Int64.Parse(dr[GrossFild].ToString()) < PrYearCpListCndtn.St_MonthGrossRatio)         //DEL 2009/01/29 �s��Ή�[9849]
                    if (Double.Parse(dr[GrossFild].ToString()) < PrYearCpListCndtn.St_MonthGrossRatio)          //ADD 2009/01/29 �s��Ή�[9849]
                    {
                        ckflg = true;
                    }
                }
                //�����e��(�I��)
                if (PrYearCpListCndtn.Ed_MonthGrossRatio_ck == true)
                {
                    //if (Int64.Parse(dr[GrossFild].ToString()) > PrYearCpListCndtn.Ed_MonthGrossRatio)         //DEL 2009/01/29 �s��Ή�[9849]
                    if (Double.Parse(dr[GrossFild].ToString()) > PrYearCpListCndtn.Ed_MonthGrossRatio)          //ADD 2009/01/29 �s��Ή�[9849]
                    {
                        ckflg = true;
                    }
                }
                //���N�e��(�J�n)
                if (PrYearCpListCndtn.St_YearGrossRatio_ck == true)
                {
                    //if (Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_totalGrossRatio].ToString()) < PrYearCpListCndtn.St_YearGrossRatio)   //DEL 2009/01/29 �s��Ή�[9849]
                    if (Double.Parse(dr[DCTOK02094EA.CT_PrevYear_totalGrossRatio].ToString()) < PrYearCpListCndtn.St_YearGrossRatio)    //ADD 2009/01/29 �s��Ή�[9849]
                    {
                        ckflg = true;
                    }
                }
                //���N�e��(�I��)
                if (PrYearCpListCndtn.Ed_YearGrossRatio_ck == true)
                {
                    //if (Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_totalGrossRatio].ToString()) > PrYearCpListCndtn.St_YearGrossRatio)   //DEL 2009/01/29 �s��Ή�[9849]
                    if (Double.Parse(dr[DCTOK02094EA.CT_PrevYear_totalGrossRatio].ToString()) > PrYearCpListCndtn.Ed_YearGrossRatio)    //ADD 2009/01/29 �s��Ή�[9849]
                    {
                        ckflg = true;
                    }
                }

                // �ΏۊO�f�[�^�̏ꍇ�A�폜
                if (ckflg == true)
                {
                    dr.Delete();
                    i = i - 1;
                }

            }
        }
        #endregion
    }
}

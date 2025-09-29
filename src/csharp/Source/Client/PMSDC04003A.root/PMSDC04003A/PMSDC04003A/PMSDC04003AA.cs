//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���M���O�\��
// �v���O�����T�v   : ����f�[�^���M���O�e�[�u���ɑ΂��Č����������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �c����
// �� �� ��  2019/12/02  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using Microsoft.Win32;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Controller.Agent;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���M���O�\���̃A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer : �c����</br>
    /// <br>Date       : 2019/12/02</br>
    /// </remarks>
    public class SalCprtSndLogListResultAcs
    {
        #region �� Private Members ��
        // ����f�[�^���M���O�f�[�^�Z�b�g
        private SalCprtSndLogListResultDataSet _salCprtSndLogListResultDataSet;
        // ����f�[�^���M���O�f�[�^�e�[�u��
        private SalCprtSndLogListResultDataSet.SalCprtSndLogListResultDataTable _salCprtSndLogListResultDataTable;
        private ISalCprtSndLogDB _iSalCprtSndLogDB;
        private static SalCprtSndLogListResultAcs _salCprtSndLogListResultAcs;
        /// <summary>���_�}�X�^DB</summary>
        private SecInfoSetAcsAgent _sectionInfoDB;
        #endregion �� Private Members ��

        #region �� Properties ��

        /// <summary>
        /// ����f�[�^���M���O�f�[�^�e�[�u���v���p�e�B
        /// </summary>
        public SalCprtSndLogListResultDataSet.SalCprtSndLogListResultDataTable SalCprtSndLogListResultDataTable
        {
            get { return _salCprtSndLogListResultDataTable; }
        }
        #endregion �� Properties ��

        # region �� Constructor ��
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        private SalCprtSndLogListResultAcs()
        {
            // �ϐ�������
            this._salCprtSndLogListResultDataSet = new SalCprtSndLogListResultDataSet();
            this._salCprtSndLogListResultDataTable = this._salCprtSndLogListResultDataSet.SalCprtSndLogListResult;
            this._iSalCprtSndLogDB = MediationSalCprtSndLogDB.GetSalCprtSndLogDB();
            this._sectionInfoDB = new SecInfoSetAcsAgent();
        }
        # endregion �� Constructor ��

        /// <summary>
        /// ����f�[�^���M���O�e�[�u���̃��O��񏈗����s��
        /// </summary>
        /// <param name="salCprtSndLogListResultSearchPara">����f�[�^���M���O���o����</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>�Ǎ����ʃX�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ����f�[�^���M���O�擾�������s���B</br>      
        /// <br>Programmer : �c����</br>                                  
        /// <br>Date       : 2019/12/02</br> 
        /// <br>UpdateNote : 2013/08/12 �c����</br>
        /// <br>           : Redmine#39695 ���o���ʖ����̃��O���e�̕ύX�Ή�</br>
        /// </remarks>
        public int SearchSalCprtSndLog(ref object salCprtSndLogListResultSearchPara, ConstantManagement.LogicalMode logicalMode)
        {
            ArrayList outSalCprtSndLogListResultList = new ArrayList();
            object outObj = outSalCprtSndLogListResultList as object;

            string errMessage = string.Empty;
            int status = this._iSalCprtSndLogDB.SearchSalCprtSndLog(out outObj, out errMessage, ref salCprtSndLogListResultSearchPara, logicalMode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                outSalCprtSndLogListResultList = (ArrayList)outObj;
                Dictionary<string, string> sectionNameMap = new Dictionary<string, string>();

                this._salCprtSndLogListResultDataTable.Clear();
                this._salCprtSndLogListResultDataTable.BeginLoadData();
                try
                {
                    foreach (SalCprtSndLogListResultWork salCprtSndLogListResult in outSalCprtSndLogListResultList)
                    {
                        SalCprtSndLogListResultDataSet.SalCprtSndLogListResultRow salCprtSndLogListResultRow = this._salCprtSndLogListResultDataTable.NewSalCprtSndLogListResultRow();
                        salCprtSndLogListResultRow.SectionCode = salCprtSndLogListResult.SectionCode; // ���_�R�[�h
                        // ���_����
                        if (!sectionNameMap.ContainsKey(salCprtSndLogListResult.SectionCode))
                        {
                            sectionNameMap.Add(salCprtSndLogListResult.SectionCode, _sectionInfoDB.GetSectionName(salCprtSndLogListResult.SectionCode));
                        }
                        salCprtSndLogListResultRow.SectionName = sectionNameMap[salCprtSndLogListResult.SectionCode];
                        salCprtSndLogListResultRow.SAndEAutoSendDiv = salCprtSndLogListResult.SAndEAutoSendDiv;
                        // 0:�蓮,1:����
                        switch (salCprtSndLogListResult.SAndEAutoSendDiv)
                        {
                            case 0:
                                salCprtSndLogListResultRow.SAndEAutoSendDivName = "�蓮";
                                break;
                            case 1:
                                salCprtSndLogListResultRow.SAndEAutoSendDivName = "����";
                                break;
                            default:
                                salCprtSndLogListResultRow.SAndEAutoSendDivName = string.Empty;
                                break;
                        }

                        DateTime sendDateTimeStart = DateTime.MinValue;
                        DateTime sendDateTimeEnd = DateTime.MinValue;
                        DateTime sendObjDateStart = DateTime.MinValue;
                        DateTime sendObjDateEnd = DateTime.MinValue;
                        if (DateTime.TryParseExact(salCprtSndLogListResult.SendDateTimeStart.ToString(), "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out sendDateTimeStart))
                        {
                            salCprtSndLogListResultRow.SendDateTimeStart = sendDateTimeStart.ToString("yyyy/MM/dd HH:mm:ss");
                        }
                        else
                        {
                            salCprtSndLogListResultRow.SendDateTimeStart = string.Empty;
                        }
                        if (DateTime.TryParseExact(salCprtSndLogListResult.SendDateTimeEnd.ToString(), "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out sendDateTimeEnd))
                        {
                            salCprtSndLogListResultRow.SendDateTimeEnd = sendDateTimeEnd.ToString("yyyy/MM/dd HH:mm:ss");
                        }
                        else
                        {
                            salCprtSndLogListResultRow.SendDateTimeEnd = string.Empty;
                        }
                        if (DateTime.TryParseExact(salCprtSndLogListResult.SendObjDateStart.ToString(), "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out sendObjDateStart))
                        {
                            salCprtSndLogListResultRow.SendObjDateStart = sendObjDateStart.ToString("yyyy/MM/dd HH:mm:ss");
                        }
                        else
                        {
                            salCprtSndLogListResultRow.SendObjDateStart = string.Empty;
                        }
                        if (DateTime.TryParseExact(salCprtSndLogListResult.SendObjDateEnd.ToString(), "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out sendObjDateEnd))
                        {
                            salCprtSndLogListResultRow.SendObjDateEnd = sendObjDateEnd.ToString("yyyy/MM/dd HH:mm:ss");
                        }
                        else
                        {
                            salCprtSndLogListResultRow.SendObjDateEnd = string.Empty;
                        }
                        salCprtSndLogListResultRow.SendObjCustStart = salCprtSndLogListResult.SendObjCustStart;
                        salCprtSndLogListResultRow.SendObjCustEnd = salCprtSndLogListResult.SendObjCustEnd;
                        salCprtSndLogListResultRow.SendObjDiv = salCprtSndLogListResult.SendObjDiv;
                        // 0:�����M,1:���M��,2�F�S��
                        switch (salCprtSndLogListResult.SendObjDiv)
                        {
                            case 0:
                                salCprtSndLogListResultRow.SendObjDivName = "�����M";
                                break;
                            case 1:
                                salCprtSndLogListResultRow.SendObjDivName = "���M��";
                                break;
                            case 2:
                                salCprtSndLogListResultRow.SendObjDivName = "�S��";
                                break;
                            default:
                                salCprtSndLogListResultRow.SendObjDivName = string.Empty;
                                break;
                        }
                        salCprtSndLogListResultRow.SendResults = salCprtSndLogListResult.SendResults;
                        // 0:���튮��,1�F���s
                        switch (salCprtSndLogListResult.SendResults)
                        {
                            case 0:
                                salCprtSndLogListResultRow.SendResultsName = "���튮��";
                                break;
                            case 1:
                                salCprtSndLogListResultRow.SendResultsName = "���s";
                                break;
                            //----- ADD �c���� 2013/08/12 Redmine#39695 ----->>>>>
                            case 2:
                                salCprtSndLogListResultRow.SendResultsName = "���M�ΏۂȂ�";
                                break;
                            //----- ADD �c���� 2013/08/12 Redmine#39695 -----<<<<<
                            default:
                                salCprtSndLogListResultRow.SendResultsName = string.Empty;
                                break;
                        }
                        salCprtSndLogListResultRow.SendSlipCount = salCprtSndLogListResult.SendSlipCount; // ���M�`�[����
                        salCprtSndLogListResultRow.SendSlipDtlCnt = salCprtSndLogListResult.SendSlipDtlCnt; // ���M�`�[���א�
                        salCprtSndLogListResultRow.SendSlipTotalMny = salCprtSndLogListResult.SendSlipTotalMny; // ���M�`�[���v���z
                        salCprtSndLogListResultRow.SendErrorContents = salCprtSndLogListResult.SendErrorContents; // ���M�G���[���e

                        this._salCprtSndLogListResultDataTable.Rows.Add(salCprtSndLogListResultRow);
                    }
                }
                finally
                {
                    this._salCprtSndLogListResultDataTable.EndLoadData();
                }
                return status;
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                this._salCprtSndLogListResultDataTable.Clear();
                return status;
            }
            else
            {
                return status;
            }
        }

        /// <summary>
        /// ����f�[�^���M���O�e�[�u���̃��O�����폜����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>���ʃX�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ����f�[�^���M���O�e�[�u���̃��O�����폜�������s���B</br>      
        /// <br>Programmer : �c����</br>                                  
        /// <br>Date       : 2019/12/02</br> 
        /// </remarks>
        public int ResetSalCprtSndLog(out string errMessage, string enterpriseCode)
        {
            errMessage = string.Empty;

            int status = this._iSalCprtSndLogDB.ResetSalCprtSndLog(out errMessage, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._salCprtSndLogListResultDataTable.Clear();
            }

            return status;
        }

        # region �� ����f�[�^���M���O�A�N�Z�X�N���X �C���X�^���X�擾���� ��
        /// <summary>
        /// ����f�[�^���M���O�A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����f�[�^���M���O�擾�������s���B</br>      
        /// <br>Programmer : �c����</br>                                  
        /// <br>Date       : 2019/12/02</br> 
        /// </remarks>
        public static SalCprtSndLogListResultAcs GetInstance()
        {
            if (_salCprtSndLogListResultAcs == null)
            {
                _salCprtSndLogListResultAcs = new SalCprtSndLogListResultAcs();
            }

            return _salCprtSndLogListResultAcs;
        }
        # endregion �� ����f�[�^���M���O�A�N�Z�X�N���X �C���X�^���X�擾���� ��
    }
}

//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���M���O�\��
// �v���O�����T�v   : ����f�[�^���M���O�e�[�u���ɑ΂��Č����������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : zhaimm
// �� �� ��  2013/06/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10901034-00  �쐬�S�� : �c����  
// �C �� ��  2013/08/12  �C�����e : Redmine#39695 ���o���ʖ����̃��O���e�̕ύX�Ή�
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
    /// <br>Programmer : zhaimm</br>
    /// <br>Date       : 2013/06/26</br>
    /// <br>UpdateNote : 2013/08/12 �c����</br>
    /// <br>           : Redmine#39695 ���o���ʖ����̃��O���e�̕ύX�Ή�</br>
    /// </remarks>
    public class SAndESalSndLogListResultAcs
    {
        #region �� Private Members ��
        // ����f�[�^���M���O�f�[�^�Z�b�g
        private SAndESalSndLogListResultDataSet _sAndESalSndLogListResultDataSet;
        // ����f�[�^���M���O�f�[�^�e�[�u��
        private SAndESalSndLogListResultDataSet.SAndESalSndLogListResultDataTable _sAndESalSndLogListResultDataTable;
        private ISAndESalSndLogDB _iSAndESalSndLogDB;
        private static SAndESalSndLogListResultAcs _sAndESalSndLogListResultAcs;
        /// <summary>���_�}�X�^DB</summary>
        private SecInfoSetAcsAgent _sectionInfoDB;
        #endregion �� Private Members ��

        #region �� Properties ��

        /// <summary>
        /// ����f�[�^���M���O�f�[�^�e�[�u���v���p�e�B
        /// </summary>
        public SAndESalSndLogListResultDataSet.SAndESalSndLogListResultDataTable SAndESalSndLogListResultDataTable
        {
            get { return _sAndESalSndLogListResultDataTable; }
        }
        #endregion �� Properties ��

        # region �� Constructor ��
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        private SAndESalSndLogListResultAcs()
        {
            // �ϐ�������
            this._sAndESalSndLogListResultDataSet = new SAndESalSndLogListResultDataSet();
            this._sAndESalSndLogListResultDataTable = this._sAndESalSndLogListResultDataSet.SAndESalSndLogListResult;
            this._iSAndESalSndLogDB = MediationSAndESalSndLogDB.GetSAndESalSndLogDB();
            this._sectionInfoDB = new SecInfoSetAcsAgent();
        }
        # endregion �� Constructor ��

        /// <summary>
        /// ����f�[�^���M���O�e�[�u���̃��O��񏈗����s��
        /// </summary>
        /// <param name="sAndESalSndLogListResultSearchPara">����f�[�^���M���O���o����</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>�Ǎ����ʃX�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ����f�[�^���M���O�擾�������s���B</br>      
        /// <br>Programmer : zhaimm</br>                                  
        /// <br>Date       : 2013/06/26</br> 
        /// <br>UpdateNote : 2013/08/12 �c����</br>
        /// <br>           : Redmine#39695 ���o���ʖ����̃��O���e�̕ύX�Ή�</br>
        /// </remarks>
        public int SearchSAndESalSndLog(ref object sAndESalSndLogListResultSearchPara, ConstantManagement.LogicalMode logicalMode)
        {
            ArrayList outSAndESalSndLogListResultList = new ArrayList();
            object outObj = outSAndESalSndLogListResultList as object;

            string errMessage = string.Empty;
            int status = this._iSAndESalSndLogDB.SearchSAndESalSndLog(out outObj, out errMessage, ref sAndESalSndLogListResultSearchPara, logicalMode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                outSAndESalSndLogListResultList = (ArrayList)outObj;
                Dictionary<string, string> sectionNameMap = new Dictionary<string, string>();

                this._sAndESalSndLogListResultDataTable.Clear();
                this._sAndESalSndLogListResultDataTable.BeginLoadData();
                try
                {
                    foreach (SAndESalSndLogListResultWork sAndESalSndLogListResult in outSAndESalSndLogListResultList)
                    {
                        SAndESalSndLogListResultDataSet.SAndESalSndLogListResultRow sAndESalSndLogListResultRow = this._sAndESalSndLogListResultDataTable.NewSAndESalSndLogListResultRow();
                        sAndESalSndLogListResultRow.SectionCode = sAndESalSndLogListResult.SectionCode; // ���_�R�[�h
                        // ���_����
                        if (!sectionNameMap.ContainsKey(sAndESalSndLogListResult.SectionCode))
                        {
                            sectionNameMap.Add(sAndESalSndLogListResult.SectionCode, _sectionInfoDB.GetSectionName(sAndESalSndLogListResult.SectionCode));
                        }
                        sAndESalSndLogListResultRow.SectionName = sectionNameMap[sAndESalSndLogListResult.SectionCode];
                        sAndESalSndLogListResultRow.SAndEAutoSendDiv = sAndESalSndLogListResult.SAndEAutoSendDiv;
                        // 0:�蓮,1:����
                        switch (sAndESalSndLogListResult.SAndEAutoSendDiv)
                        {
                            case 0:
                                sAndESalSndLogListResultRow.SAndEAutoSendDivName = "�蓮";
                                break;
                            case 1:
                                sAndESalSndLogListResultRow.SAndEAutoSendDivName = "����";
                                break;
                            default:
                                sAndESalSndLogListResultRow.SAndEAutoSendDivName = string.Empty;
                                break;
                        }

                        DateTime sendDateTimeStart = DateTime.MinValue;
                        DateTime sendDateTimeEnd = DateTime.MinValue;
                        DateTime sendObjDateStart = DateTime.MinValue;
                        DateTime sendObjDateEnd = DateTime.MinValue;
                        if (DateTime.TryParseExact(sAndESalSndLogListResult.SendDateTimeStart.ToString(), "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out sendDateTimeStart))
                        {
                            sAndESalSndLogListResultRow.SendDateTimeStart = sendDateTimeStart.ToString("yyyy/MM/dd HH:mm:ss");
                        }
                        else
                        {
                            sAndESalSndLogListResultRow.SendDateTimeStart = string.Empty;
                        }
                        if (DateTime.TryParseExact(sAndESalSndLogListResult.SendDateTimeEnd.ToString(), "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out sendDateTimeEnd))
                        {
                            sAndESalSndLogListResultRow.SendDateTimeEnd = sendDateTimeEnd.ToString("yyyy/MM/dd HH:mm:ss");
                        }
                        else
                        {
                            sAndESalSndLogListResultRow.SendDateTimeEnd = string.Empty;
                        }
                        if (DateTime.TryParseExact(sAndESalSndLogListResult.SendObjDateStart.ToString(), "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out sendObjDateStart))
                        {
                            sAndESalSndLogListResultRow.SendObjDateStart = sendObjDateStart.ToString("yyyy/MM/dd");
                        }
                        else
                        {
                            sAndESalSndLogListResultRow.SendObjDateStart = string.Empty;
                        }
                        if (DateTime.TryParseExact(sAndESalSndLogListResult.SendObjDateEnd.ToString(), "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out sendObjDateEnd))
                        {
                            sAndESalSndLogListResultRow.SendObjDateEnd = sendObjDateEnd.ToString("yyyy/MM/dd");
                        }
                        else
                        {
                            sAndESalSndLogListResultRow.SendObjDateEnd = string.Empty;
                        }
                        sAndESalSndLogListResultRow.SendObjCustStart = sAndESalSndLogListResult.SendObjCustStart;
                        sAndESalSndLogListResultRow.SendObjCustEnd = sAndESalSndLogListResult.SendObjCustEnd;
                        sAndESalSndLogListResultRow.SendObjDiv = sAndESalSndLogListResult.SendObjDiv;
                        // 0:�S��,1:�����M,2�F���M��
                        switch (sAndESalSndLogListResult.SendObjDiv)
                        {
                            case 0:
                                sAndESalSndLogListResultRow.SendObjDivName = "�S��";
                                break;
                            case 1:
                                sAndESalSndLogListResultRow.SendObjDivName = "�����M";
                                break;
                            case 2:
                                sAndESalSndLogListResultRow.SendObjDivName = "���M��";
                                break;
                            default:
                                sAndESalSndLogListResultRow.SendObjDivName = string.Empty;
                                break;
                        }
                        sAndESalSndLogListResultRow.SendResults = sAndESalSndLogListResult.SendResults;
                        // 0:���튮��,1�F���s
                        switch (sAndESalSndLogListResult.SendResults)
                        {
                            case 0:
                                sAndESalSndLogListResultRow.SendResultsName = "���튮��";
                                break;
                            case 1:
                                sAndESalSndLogListResultRow.SendResultsName = "���s";
                                break;
                            //----- ADD �c���� 2013/08/12 Redmine#39695 ----->>>>>
                            case 2:
                                sAndESalSndLogListResultRow.SendResultsName = "���M�ΏۂȂ�";
                                break;
                            //----- ADD �c���� 2013/08/12 Redmine#39695 -----<<<<<
                            default:
                                sAndESalSndLogListResultRow.SendResultsName = string.Empty;
                                break;
                        }
                        sAndESalSndLogListResultRow.SendSlipCount = sAndESalSndLogListResult.SendSlipCount; // ���M�`�[����
                        sAndESalSndLogListResultRow.SendSlipDtlCnt = sAndESalSndLogListResult.SendSlipDtlCnt; // ���M�`�[���א�
                        sAndESalSndLogListResultRow.SendSlipTotalMny = sAndESalSndLogListResult.SendSlipTotalMny; // ���M�`�[���v���z
                        sAndESalSndLogListResultRow.SendErrorContents = sAndESalSndLogListResult.SendErrorContents; // ���M�G���[���e

                        this._sAndESalSndLogListResultDataTable.Rows.Add(sAndESalSndLogListResultRow);
                    }
                }
                finally
                {
                    this._sAndESalSndLogListResultDataTable.EndLoadData();
                }
                return status;
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                this._sAndESalSndLogListResultDataTable.Clear();
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
        /// <br>Programmer : zhaimm</br>                                  
        /// <br>Date       : 2013/06/26</br> 
        /// </remarks>
        public int ResetSAndESalSndLog(out string errMessage, string enterpriseCode)
        {
            errMessage = string.Empty;

            int status = this._iSAndESalSndLogDB.ResetSAndESalSndLog(out errMessage, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._sAndESalSndLogListResultDataTable.Clear();
            }

            return status;
        }

        # region �� ����f�[�^���M���O�A�N�Z�X�N���X �C���X�^���X�擾���� ��
        /// <summary>
        /// ����f�[�^���M���O�A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����f�[�^���M���O�擾�������s���B</br>      
        /// <br>Programmer : zhaimm</br>                                  
        /// <br>Date       : 2013/06/26</br> 
        /// </remarks>
        public static SAndESalSndLogListResultAcs GetInstance()
        {
            if (_sAndESalSndLogListResultAcs == null)
            {
                _sAndESalSndLogListResultAcs = new SAndESalSndLogListResultAcs();
            }

            return _sAndESalSndLogListResultAcs;
        }
        # endregion �� ����f�[�^���M���O�A�N�Z�X�N���X �C���X�^���X�擾���� ��
    }
}

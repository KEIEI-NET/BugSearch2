//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �d�q����A�g�X�V����
// �v���O�����T�v   : �d�q����A�g�X�V����
//----------------------------------------------------------------------------//
//                (c)Copyright  2022 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570183-00 �쐬�S�� : 3H ����
// �� �� ��  2022/03/18  �V�K�쐬
//----------------------------------------------------------------------------//
//****************************************************************************//

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Text.RegularExpressions;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Microsoft.Win32;
using ar = DataDynamics.ActiveReports;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    ///  �d�q����A�g�X�V�����A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        :  �d�q����A�g�X�V�������s��</br>
    /// <br>Programmer	: 3H ����</br>
    /// <br>Date		: 2022/03/18</br>
    /// </remarks>
    public class EBooksCooprtUpdateAcs
    {
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region ��Constructor
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        /// <remarks>
        /// <br>Programmer	: 3H ����</br>
        /// <br>Date		: 2022/03/18</br>
        /// </remarks>
        public EBooksCooprtUpdateAcs()
        {
            // ����惊�X�g�o�� �A�N�Z�X�N���X
            if (_denchoDXCustomerExportAcs == null)
            {
                // ����惊�X�g�o�� �A�N�Z�X�N���X�@�Í���
                _denchoDXCustomerExportAcs = new DenchoDXCustomerExportAcs(true);
            }
        }
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region ��Private Members
        private static EBooksCooprtUpdateAcs _eBooksCooprtUpdateAcs = null;            // �d�q����A�g�X�V�����A�N�Z�X�N���X
        private static DenchoDXCustomerExportAcs _denchoDXCustomerExportAcs = null;    // ����惊�X�g�o�� �A�N�Z�X�N���X
        private static FrePrtGuideAcs _frePrtGuideAcs = null;                          // ���R���[�I���K�C�h�A�N�Z�X�N���X
        private static FrePrtPSetAcs _frePrtPSetAcs = null;
        private EBooksLinkSetInfo _eBooksLinkSetInfo;
        private static Employee stc_Employee;
        private static Dictionary<string, Int32> _customerItemDic = null;
        /// <summary>�o�͉\�������p�^�[�����XML�t�@�C����</summary>
        private const string ctXML_DMDPRTPTN_FILE_NAME = "PMKAU02010U_DmdPrtPtnSetting.XML";
        /// <summary>�d�q����A�g�T�|�[�g�ݒ�XML�t�@�C����</summary>
        private const string ctXML_EBOOKLINK_FILE_NAME = "MAKAU03000U_EbooksLinkSetting.XML";
        /// <summary>�C���X�g�[���f�B���N�g��</summary>
        private const string ctInstallDirectory = "InstallDirectory";
        /// <summary>�C���X�g�[�� ���W�X�g���L�[</summary>
        private const string ctRegistryKey = @"SOFTWARE\Broadleaf\Product\Partsman";
        /// <summary>�C���X�g�[�� ���W�X�g���L�[</summary>
        private const string ctIniCustomFolderPath = @"eBooks\Customer";
        /// <summary>���Ӑ�}�X�^�e�L�X�g�t�@�C����</summary>
        private const string ctCustomCsvName = "nN7_CustomerRF";
        #endregion

        #region[�d�q����A�g�X�V���� �A�N�Z�X�N���X �C���X�^���X�擾����]
        /// <summary>
        /// �d�q����A�g�X�V���� �A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns>�A�N�Z�X�N���X �C���X�^���X</returns>
        /// <remarks>
        /// <br>Programmer	: 3H ����</br>
        /// <br>Date		: 2022/03/18</br>
        /// </remarks>
        public static EBooksCooprtUpdateAcs GetInstance()
        {
            stc_Employee = null;

            // ���O�C�����_�擾
            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            if (loginEmployee != null)
            {
                stc_Employee = loginEmployee.Clone();
            }

            // �d�q����A�g�X�V���� �A�N�Z�X�N���X
            if (_eBooksCooprtUpdateAcs == null)
            {
                _eBooksCooprtUpdateAcs = new EBooksCooprtUpdateAcs();
            }

            return _eBooksCooprtUpdateAcs;
        }
        #endregion

        #region �o�͉\�������p�^�[�����o
        /// <summary>
        /// �o�͉\�������p�^�[�����o
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : �o�͉\�������p�^�[�����o�������s���B</br>
        /// <br>Programmer	: 3H ����</br>
        /// <br>Date		: 2022/03/18</br>
        /// </remarks>
        public int ExtraDmdPrtPtnData(ref string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            try
            {
                List<DmdPrtPtnSetInfo> listDmdPrtPtnSetInfo;
                getDmdPrtPtnInfo(out listDmdPrtPtnSetInfo, ref errMsg);
                // ���א������`�[��XML�ɏo�͂���
                if (string.IsNullOrEmpty(errMsg))
                {
                    DoXmlOutPrc(listDmdPrtPtnSetInfo, ref errMsg);
                }

            }
            catch (Exception ex)
            {
                errMsg = ex.Message.TrimEnd();
                return status;
            }
            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        #endregion

        #region [�o�͉\�������p�^�[���擾]
        /// <summary>
        /// �o�͉\�������p�^�[���擾
        /// </summary>
        /// <param name="errMsg"></param>
        /// <param name="ListDmdPrtPtnSetInfo"></param>       
        private void getDmdPrtPtnInfo(out List<DmdPrtPtnSetInfo> listDmdPrtPtnSetInfo, ref string errMsg)
        {
            const string sCustomNameMk = "ITEM";                    // �ʍ��ڃ}�b�N
            const int iMeisaiGrpCd = 1220;                          // ���א������R�[�h�敪
            ArrayList retList = new ArrayList();
            List<FrePrtPSet> listFrePrtPSet = new List<FrePrtPSet>();
            listDmdPrtPtnSetInfo = new List<DmdPrtPtnSetInfo>();

            int[] dataInputSystemArray = new int[] { 0 };           // �f�[�^���̓V�X�e��            
            bool msgDiv = false;                                    // ���b�Z�[�W�敪
            string sControlNm = string.Empty;                       // ���ږ�
            bool bCustomFlg;                                        // �ʍ��ڑ��݃t���O

            List<FrePprECnd> frePprECndLs = null;
            List<FrePprSrtO> frePprSrtOLs = null;
            _frePrtPSetAcs = new FrePrtPSetAcs();
            _frePrtGuideAcs = new FrePrtGuideAcs();

            if (_customerItemDic == null) 
            {
                _customerItemDic = new Dictionary<string, int>();
                //  �ʍ��ږ��FITEM01�`ITEM99
                for (int i = 1; i < 100; i++)
                {
                    _customerItemDic.Add(sCustomNameMk + i.ToString("00"), 0);                    
                }
            }

            try
            {
                // ���������[�ꗗ���擾
                // �@��ƃR�[�h�@�A���[�g�p�敪 �B���[�敪�R�[�h(�@�C�f�[�^���̓V�X�e���z��@�D�Ǎ����ʃR���N�V�����@�E���b�Z�[�W�敪�@�F�G���[���b�Z�[�W
                int st = _frePrtGuideAcs.SearchFrePrtPSetDLDB(stc_Employee.EnterpriseCode, 5, 0, dataInputSystemArray, out retList, out msgDiv, out errMsg);
                if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���א������`�[���X�g���擾
                    foreach (FrePrtPSet retPSet in retList)
                    {
                        if (retPSet.FreePrtPprItemGrpCd == iMeisaiGrpCd)
                        {
                            listFrePrtPSet.Add(retPSet);
                        }
                    }

                    // �ʍ��ڑ��݂��Ȃ��̖��א��������擾
                    for (int i = 0; i < listFrePrtPSet.Count; i++)
                    {
                        frePprECndLs = null;
                        frePprSrtOLs = null;
                        FrePrtPSet frtpSet = listFrePrtPSet[i];
                        // �󎚈ʒu�N���X�f�[�^���擾
                        st = _frePrtPSetAcs.ReadDBFrePrtPSet(ref frtpSet, out frePprECndLs, out frePprSrtOLs);

                        if ((st == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                            (st == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                        {
                        }
                        else
                        {
                            errMsg = _frePrtPSetAcs.ErrorMessage;
                            return;
                        }

                        using (MemoryStream stream = new MemoryStream(frtpSet.PrintPosClassData))
                        {
                            // �ʍ��ڑ��ݔ��f�t���O
                            bCustomFlg = false;
                            // �ʍ��ڑ��݃`�F�b�N
                            // ActiveReport��őS�Ĉ�����ڂ��擾
                            ar.ActiveReport3 prtRpt = new ar.ActiveReport3();
                            prtRpt.LoadLayout(stream);
                            foreach (DataDynamics.ActiveReports.Section section in prtRpt.Sections)
                            {
                                foreach (ar.ARControl aRControl in section.Controls)
                                {

                                    if (aRControl is ar.TextBox && aRControl.Tag is string)
                                    {
                                        if (aRControl.DataField == null)
                                        {
                                            continue;
                                        }
                                        string dataFieldName = aRControl.DataField.ToUpper();
                                        if (dataFieldName.Contains("CUSTOMIZE"))
                                        {
                                            bCustomFlg = true;
                                            break;
                                        }
                                    }
                                }
                                // �ʍ��ڑ��݁A�Y�����[�`�F�b�N���~
                                if (bCustomFlg) 
                                {
                                    break;
                                }
                            }
                            // �ʍ��ڑ��݂��Ȃ��̒��[
                            if (!bCustomFlg)
                            {   // �o�͉\�������p�^�[�����
                                DmdPrtPtnSetInfo dmdPrtPtnSetInfo = new DmdPrtPtnSetInfo();
                                dmdPrtPtnSetInfo.OutputFormFileName = frtpSet.OutputFormFileName;
                                dmdPrtPtnSetInfo.DisplayName = frtpSet.DisplayName;
                                listDmdPrtPtnSetInfo.Add(dmdPrtPtnSetInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message.TrimEnd();
            }
        }
        #endregion

        #region ���Ӑ�}�X�^(�Í���)�G�N�X�|�[�g
        /// <summary>
        /// ���Ӑ�}�X�^(�Í���)�G�N�X�|�[�g
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : ���Ӑ�}�X�^�g(�Í���)�G�N�X�|�[�������s���B</br>
        /// <br>Programmer	: 3H ����</br>
        /// <br>Date		: 2022/03/18</br>
        /// </remarks>
        public int ExtraCustomerData(ref string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            string sOutFileName = ctCustomCsvName + "_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";
            try
            {
                // ���Ӑ�}�X�^�e�L�X�g�t�@�C���o�̓p�X���擾
                string sCustomerListOutPath = Path.Combine(GetEBooksFolderPath(), sOutFileName);

                status = _denchoDXCustomerExportAcs.MakeCustomerCSVAll(stc_Employee.EnterpriseCode, sCustomerListOutPath);

            }
            catch (Exception ex)
            {
                errMsg = ex.Message.TrimEnd();
            }
            return status;
        }
        #endregion

        # region[�d�q����󂯓n���t�H���_�p�X���擾]
        /// <summary>
        /// �d�q����󂯓n���t�H���_�p�X���擾
        /// </summary>
        /// <returns>�d�q����󂯓n���t�H���_�p�X</returns>
        /// <remarks> 
        /// </remarks>
        private string GetEBooksFolderPath()
        {
            string sCustomFoldertPath = string.Empty;
            _eBooksLinkSetInfo = new EBooksLinkSetInfo();

            // ����惊�X�g�󂯓n���t�H���_�@�f�t�H���g�l
            sCustomFoldertPath = Path.Combine(GetInstallDirectory(), ctIniCustomFolderPath);
            //  �d�q����A�g�T�|�[�g�ݒ���XML�t�@�C�����݂̔��f           
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctXML_EBOOKLINK_FILE_NAME)))
            {
                try
                {
                    _eBooksLinkSetInfo = UserSettingController.DeserializeUserSetting<EBooksLinkSetInfo>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctXML_EBOOKLINK_FILE_NAME));
                    // ����惊�X�g�󂯓n���t�H���_ �ݒ�̏ꍇ�A
                    if (!string.IsNullOrEmpty(_eBooksLinkSetInfo.CustomFolder))
                    {
                        sCustomFoldertPath = _eBooksLinkSetInfo.CustomFolder;
                    }

                }
                catch (System.InvalidOperationException)
                {
                    return sCustomFoldertPath;
                }
            }

            return sCustomFoldertPath;
        }
        # endregion

        #region[�o�͉\�������p�^�[�����o��]
        /// <summary>
        ///  �o�͉\�������p�^�[�����o��
        /// </summary>
        /// <param name="listDmdPrtPtnSetInfo">�o�͉\�������p�^�[�����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        private void DoXmlOutPrc(List<DmdPrtPtnSetInfo> listDmdPrtPtnSetInfo, ref string errMsg)
        {
            string sXmlOutPath = Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctXML_DMDPRTPTN_FILE_NAME);

            try
            {
                if (listDmdPrtPtnSetInfo.Count == 0) 
                {
                    DmdPrtPtnSetInfo dmdPrtPtnSetInfo = new DmdPrtPtnSetInfo();
                    listDmdPrtPtnSetInfo.Add(dmdPrtPtnSetInfo);
                }
                UserSettingController.SerializeUserSetting(listDmdPrtPtnSetInfo, sXmlOutPath);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }

        }
        #endregion

        #region [PMNS�̃C���X�g�[���p�X�擾]
        /// <summary>
        /// PMNS�̃C���X�g�[���p�X
        /// </summary>
        private string GetInstallDirectory()
        {
            // �N���C�A���g
            string sKeyPath = @String.Format(@ctRegistryKey);
            RegistryKey key = Registry.LocalMachine.OpenSubKey(sKeyPath);
            string directoryPath = "";
            if (key.GetValue(ctInstallDirectory) != null)
            {
                directoryPath = (string)key.GetValue(ctInstallDirectory);
            }
            return directoryPath;
        }
        # endregion

        # region [�d�q����A�g�T�|�[�g�ݒ���XML]
        /// <summary>
        /// �d�q����A�g�T�|�[�g�ݒ���
        /// </summary>
        /// <remarks> 
        /// </remarks>
        public class EBooksLinkSetInfo
        {
            /// <summary>
            /// �d�q����A�g�T�|�[�g�ݒ���
            /// </summary>
            public EBooksLinkSetInfo() 
            {

            }

            /// <summary>�d�q����󂯓n���t�H���_</summary>
            private string _eBooksFolder;
            /// <summary>����惊�X�g�󂯓n���t�H���_</summary>
            private string _customFolder;

            /// <summary>�d�q����󂯓n���t�H���_</summary>
            public string EBooksFolder
            {
                get { return _eBooksFolder; }
                set { _eBooksFolder = value; }
            }

            /// <summary>����惊�X�g�󂯓n���t�H���_</summary>
            public string CustomFolder
            {
                get { return _customFolder; }
                set { _customFolder = value; }
            }
        }
        #endregion

        # region [�o�͉\�������p�^�[�����XML]
        /// <summary>
        /// �o�͉\�������p�^�[�����
        /// </summary>
        /// <remarks> 
        /// </remarks>
        public class DmdPrtPtnSetInfo
        {
            /// <summary>
            /// �o�͉\�������p�^�[�����
            /// </summary>
            public DmdPrtPtnSetInfo()
            {

            }

            /// <summary>�o�̓t�@�C����</summary>
            private string _outputFormFileName;
            /// <summary>�o�͖���</summary>
            private string _displayName;

            /// <summary>�o�̓t�@�C����</summary>
            public string OutputFormFileName
            {
                get { return _outputFormFileName; }
                set { _outputFormFileName = value; }
            }

            /// <summary>�o�͖���</summary>
            public string DisplayName
            {
                get { return _displayName; }
                set { _displayName = value; }
            }
        }
        #endregion
    }
}

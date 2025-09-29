//****************************************************************************//
// �V�X�e��         : �����񓚏���
// �v���O��������   : �����񓚏����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517 �Ė� �x��
// �� �� ��  2021/01/17  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���X�� ��
// �� �� ��  2011/03/07  �C�����e : �t�r�a�̃I�v�V���������ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���N�n��
// �� �� ��  2011/09/16  �C�����e : Redmine 25219 PCCUOE PM���^����`�[���� UOE�������̓���s��̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2012/08/17  �C�����e : SCM��Q��154�Ή� �A���ݒ�̃`�F�b�N���Ȃ������M���Ȃ��悤�ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �{�{ ����
// �� �� ��  2013/08/09  �C�����e : SCM�d�|�ꗗ ��10557�Ή�
//                                  PMTAB�S�̐ݒ�}�X�^(���Ӑ��)�EBLP���M�敪���Q�Ƃ��đ��M�`�F�b�N�{�b�N�X�̏����ݒ���s��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 31065 �L�� ���O
// �� �� ��  2014/11/26  �C�����e : SCM�d�|�ꗗ��10707�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �{�{ ����
// �� �� ��  2015/06/18  �C�����e : SCM�d�|�ꗗ��10707
//                                  �񓚑��M�����s���̊m�F���b�Z�[�W�\���L����config�ݒ�ɕύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �{�{ ����
// �� �� ��  2015/06/25  �C�����e : SCM�d�|�ꗗ��10707
//                                  config�Q�Ə�����Null�����ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570208-00 �쐬�S�� : 杍^
// �� �� ��  2020/02/24  �C�����e : PMKOBETSU-2912����Őŗ��@�\�ǉ��Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Configuration; // ADD 2015/06/18 T.Miyamoto SCM�d�|�ꗗ��10707

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
// 2011/03/07 Add >>>
using Broadleaf.Application.Common;   
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
// 2011/03/07 Add <<<
// --- ADD 2013/08/09 T.Miyamoto ------------------------------>>>>>
using System.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
// --- ADD 2013/08/09 T.Miyamoto ------------------------------<<<<<
using System.IO; // ADD 2014/11/26 k.toyosawa SCM�d�|�ꗗ��10707�Ή�

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���M��ʑI���K�C�hUI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���M��ʑI���K�C�h�̉�ʕ\��������s���܂�</br>
    /// <br>Programmer : 30517 �Ė� �x��</br>
    /// <br>Date       : 2011/01/17</br>
    /// </remarks>
    public class PMKHN05010UA
    {
        #region �v���C�x�[�g�����o
        /// <summary>���M�Ώ۔���f�[�^</summary>
        private SalesSlip _salesSlip = null;
        /// <summary>���M�Ώ۔��㖾�׃f�[�^</summary>
        private List<SalesDetail> _salesDetailList = null;
        /// <summary>���Ӑ�}�X�^</summary>
        private CustomerInfo _customerInfo = null;
        //>>>2011/05/17
        /// <summary>�w�����ԍ�</summary>
        private string _partySalesSlipNum = string.Empty;
        //<<<2011/05/17
        // --- ADD 2013/08/09 T.Miyamoto ------------------------------>>>>>
        /// <summary>BLP���M�敪</summary>
        private int _blpSendDiv = 1;
        /// <summary>PMTAB�S�̐ݒ�}�X�^�����[�g</summary>
        private IPmTabTtlStCustDB _iPmTabTtlStCustDB;
        // --- ADD 2013/08/09 T.Miyamoto ------------------------------<<<<<
        // ADD 2014/11/26 k.toyosawa SCM�d�|�ꗗ��10707�Ή� --->>>>>>
        /// <summary>�󒍃X�e�[�^�X����</summary>
        private const int ACPTANORDSTATUSSTATE_SALSE = 30;
        // --- DEL 2015/06/18 T.Miyamoto SCM�d�|�ꗗ��10707 -------------------->>>>>
        ///// <summary>���c���i��ƃR�[�h</summary>
        //private const string ENTERPRISE_CODE_FUKUDA = "0101130064003200";
        // --- DEL 2015/06/18 T.Miyamoto SCM�d�|�ꗗ��10707 --------------------<<<<<
        /// <summary>���엚�����O�o�̓t�@�C����</summary>
        private const string LOG_FILE_NAME = ".\\Log\\PMKHN05010U_Operation.log";
        // ADD 2014/11/26 k.toyosawa SCM�d�|�ꗗ��10707�Ή� ---<<<<<<
        // --- ADD 2015/06/18 T.Miyamoto SCM�d�|�ꗗ��10707 -------------------->>>>>
        /// <summary>�uconfig�v�t�@�C��</summary>
        private const string Exe_Conf_Filename = "PMKHN05010U.dll.config";
        /// <summary>appSettings</summary>
        private const string App_Set_Section = "appSettings";
        /// <summary>�񓚑��M���s�m�F�ݒ�</summary>
        private const string CT_Conf_SendCheck = "SendCheck";
        // --- ADD 2015/06/18 T.Miyamoto SCM�d�|�ꗗ��10707 --------------------<<<<<

        // ADD 杍^ 2020/02/24 PMKOBETSU-2912�̑Ή� ------>>>>>
        /// <summary>�y���ŗ��敪</summary>
        private double _scmTaxRateInput = 0;
        // ADD 杍^ 2020/02/24 PMKOBETSU-2912�̑Ή� ------<<<<<

        #endregion

        #region �O�����J�v���p�e�B
        /// <summary>���M�Ώ۔���f�[�^</summary>
        public SalesSlip SalesSlip
        {
            get { return _salesSlip; }
            set { _salesSlip = value; }
        }

        /// <summary>���M�Ώ۔��㖾�׃f�[�^</summary>
        public List<SalesDetail> SalesDetailList
        {
            get { return _salesDetailList; }
            set { _salesDetailList = value; }
        }

        /// <summary>���Ӑ�}�X�^</summary>
        public CustomerInfo CustomerInfo
        {
            get { return _customerInfo; }
            set { _customerInfo = value; }
        }

        //>>>2011/05/17
        /// <summary>�w�����ԍ�</summary>
        public string PartySalesSlipNum
        {
            get { return _partySalesSlipNum; }
            set { _partySalesSlipNum = value; }
        }
        //<<<2011/05/17
        // ADD 杍^ 2020/02/24 PMKOBETSU-2912�̑Ή� ------>>>>>
        /// <summary>�y���ŗ��l</summary>
        public double ScmTaxRateInput
        {
            get { return _scmTaxRateInput; }
            set { _scmTaxRateInput = value; }
        }
        // ADD 杍^ 2020/02/24 PMKOBETSU-2912�̑Ή� ------<<<<<

        #endregion

        #region enum
        /// <summary>���M�ΏۃI�v�V����</summary>
        public enum OptSendTargetDiv : int
        {
            /// <summary>����</summary>
            None = 0,
            /// <summary>SCM</summary>
            Scm = 10,
            /// <summary>TSP.NS</summary>
            TspNs = 20,
            /// <summary>TSP�C�����C��</summary>
            TspInline = 30,
            /// <summary>TSP���[��</summary>
            TspMail = 40,
            //---ADD 2011/09/16 --------->>>>>
            /// <summary>ScmUOE</summary>
            ScmUOE = 50,
            //---ADD 2011/09/16 ---------<<<<<
            // ADD 2012/08/17 SCM��Q��154 --------------->>>>>
            /// <summary>ScmUOE</summary>
            ScmNoSend = 60,
            // ADD 2012/08/17 SCM��Q��154 --------------->>>>>
        }
        #endregion

        #region �O�����J���\�b�h
        /// <summary>
        /// ���M��ʑI���K�C�h��\�����܂��B
        /// </summary>
        /// <param name="status"></param>
        /// <param name="msg"></param>
        /// <param name="optSendTarget"></param>
        /// <returns></returns>
        public DialogResult ShowDialog(out int status, out string msg, out OptSendTargetDiv optSendTarget)
        {
            return this.ShowDialog(null, out status, out msg, out optSendTarget); ;
        }

        /// <summary>
        /// ���M��ʑI���K�C�h��\�����܂��B
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="status"></param>
        /// <param name="msg"></param>
        /// <param name="optSendTarget"></param>
        /// <returns></returns>
        public DialogResult ShowDialog(IWin32Window owner, out int status, out string msg, out OptSendTargetDiv optSendTarget)
        {
            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            msg = string.Empty;
            optSendTarget = OptSendTargetDiv.None;
            DialogResult result = DialogResult.Cancel;
            switch (CheckData(out msg))
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    // ��ʂ�\������
                    // --- UPD 2013/08/09 T.Miyamoto ------------------------------>>>>>
                    //PMKHN05010UB form = new PMKHN05010UB(_salesSlip.CustomerSnm, _customerInfo.OnlineKindDiv, CheckMustSend());
                    PMKHN05010UB form = new PMKHN05010UB(_salesSlip.CustomerSnm, _customerInfo.OnlineKindDiv, CheckMustSend(), _blpSendDiv);
                    // --- UPD 2013/08/09 T.Miyamoto ------------------------------<<<<<
                    //>>>2011/05/17
                    form.PartySalesSlipNum = this._partySalesSlipNum;
                    //<<<2011/05/17
                    // ADD 杍^ 2020/02/24 PMKOBETSU-2912�̑Ή� ------>>>>>
                    form.ScmTaxRateInput = this._scmTaxRateInput;
                    // ADD 杍^ 2020/02/24 PMKOBETSU-2912�̑Ή� ------<<<<<
                    if (owner == null)
                    {
                        form.ShowDialog();
                    }
                    else
                    {
                        form.ShowDialog(owner);
                    }
                    result = form.Result;
                    // �͂���I��
                    if (result == DialogResult.Yes)
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        // ADD 2014/11/26 k.toyosawa SCM�d�|�ꗗ��10707�Ή� --->>>>>>
                        // --- UPD 2015/06/18 T.Miyamoto SCM�d�|�ꗗ��10707 -------------------->>>>>
                        //// ��ƃR�[�h�����c���i�̏ꍇ
                        //if (LoginInfoAcquisition.EnterpriseCode.Trim().Equals(ENTERPRISE_CODE_FUKUDA))
                        // config�ݒ�ŉ񓚑��M�m�F���b�Z�[�W���I���̏ꍇ
                        AppSettingsSection appSettingSection = GetAppSettingsSection();
                        // --- UPD 2015/06/25 T.Miyamoto SCM�d�|�ꗗ��10707 -------------------->>>>>
                        //if (appSettingSection.Settings[CT_Conf_SendCheck].Value.Equals("1"))
                        if ((appSettingSection.Settings[CT_Conf_SendCheck] != null) &&
                            (appSettingSection.Settings[CT_Conf_SendCheck].Value.Equals("1")))
                        // --- ADD 2015/06/25 T.Miyamoto SCM�d�|�ꗗ��10707 --------------------<<<<<
                        // --- UPD 2015/06/18 T.Miyamoto SCM�d�|�ꗗ��10707 --------------------<<<<<
                        {
                            if (!form.OptSendTargetChk &&
                                (_customerInfo.OnlineKindDiv == (int)PMKHN05010UA.OptSendTargetDiv.Scm ||
                                _customerInfo.OnlineKindDiv == (int)PMKHN05010UA.OptSendTargetDiv.ScmUOE) &&
                                _salesSlip.AcptAnOdrStatus == ACPTANORDSTATUSSTATE_SALSE)
                            {
                                // �ȉ��̏������ׂĂ𖞂����ꍇ�A�����̌p���m�F���b�Z�[�W��\��
                                // �E�`�F�b�N���O��Ă���
                                // �E�`�[��ʂ�����
                                // �E��ʂ�SCM�܂���UOE

                                DialogResult dResult = MessageBox.Show(
                                    "���Ӑ�ɉ񓚂𑗐M���Ȃ��ݒ�ƂȂ��Ă��܂���\n��낵���ł����H",
                                    "�m�F",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question,
                                    MessageBoxDefaultButton.Button2);

                                // ���엚���̃��O�o��
                                this.WriteLog(dResult);

                                // NO��I�������ꍇ
                                if (dResult == DialogResult.No)
                                {
                                    status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                                    result = DialogResult.No;
                                    break;
                                }
                            }
                        }
                        // ADD 2014/11/26 k.toyosawa SCM�d�|�ꗗ��10707�Ή� ---<<<<<

                        // ���M��ʂ̃`�F�b�N�̏�Ԃ��m�F
                        if (form.OptSendTargetChk)
                        {
                            optSendTarget = (OptSendTargetDiv)_customerInfo.OnlineKindDiv;
                        }
                        else
                        {
                            optSendTarget = OptSendTargetDiv.None;
                        }

                        //>>>2011/05/17
                        // ��ʎw�����ԍ��𔽉f
                        this._partySalesSlipNum = form.PartySalesSlipNum;
                        //<<<2011/05/17
                    }
                    // ��������I��
                    else
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    }
                    break;
                case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                    // ���M�ΏۊO�̏ꍇ��DialogResult��YES�Ƃ���
                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                    // 2011/03/04 >>>
                    //result = DialogResult.Yes;
                    result = DialogResult.None;
                    // 2011/03/04 <<<
                    break;
                default:
                    // �G���[�̈׏������I��
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                    result = DialogResult.Cancel;
                    break;
            }
            return result;
        }
        #endregion

        #region �v���C�x�[�g���\�b�h
        /// <summary>
        /// ���M�Ώۂ����f����
        /// </summary>
        /// <returns></returns>
        private int CheckData(out string msg)
        {
            msg = string.Empty;
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            // ����f�[�^�E���㖾�׃f�[�^���X�g�@�����ꂩ��NULL�Ȃ珈�����s��Ȃ�
            if (_salesSlip == null || _salesDetailList == null)
            {
                msg = "����f�[�^���Z�b�g����Ă��܂���B";
                return status;
            }
            // ���Ӑ�}�X�^��NULL�Ȃ�擾����
            if (_customerInfo == null)
            {
                // ���Ӑ�}�X�^�擾
                CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                int readStatus = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, _salesSlip.EnterpriseCode, _salesSlip.CustomerCode, true, false, out _customerInfo);
                if (readStatus != 0 || _customerInfo == null || _customerInfo.LogicalDeleteCode != 0)
                {
                    // �G���[
                    msg = "���Ӑ�}�X�^�̎擾�Ɏ��s���܂����B";
                    return status;
                }
            }
            // --- ADD 2013/08/09 T.Miyamoto ------------------------------>>>>>
            this._iPmTabTtlStCustDB = MediationPmTabTtlStCustDB.GetPmTabTtlStCustDB();
            PmTabTtlStCustWork pmTabTtlStCustWork = new PmTabTtlStCustWork();
            pmTabTtlStCustWork.EnterpriseCode = _customerInfo.EnterpriseCode;
            pmTabTtlStCustWork.CustomerCode = _customerInfo.CustomerCode;

            object objSearchCond = pmTabTtlStCustWork;
            object objRetList;
            int pMTabStatus = this._iPmTabTtlStCustDB.Search(out objRetList, objSearchCond, 0, ConstantManagement.LogicalMode.GetData0);
            if (pMTabStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList resultList = objRetList as ArrayList;
                if (resultList != null && resultList.Count > 0)
                {
                    _blpSendDiv = ((PmTabTtlStCustWork)resultList[0]).BlpSendDiv;
                }
            }
            // --- ADD 2013/08/09 T.Miyamoto ------------------------------<<<<<

            // �I�����C����ʋ敪���`�F�b�N
            switch (_customerInfo.OnlineKindDiv)
            {
                case (int)OptSendTargetDiv.Scm:
                case (int)OptSendTargetDiv.ScmUOE: // ADD 2011/09/16
                // ADD 2012/08/17 SCM��Q��154 --------------->>>>>
                case (int)OptSendTargetDiv.ScmNoSend: 
                // ADD 2012/08/17 SCM��Q��154 ---------------<<<<<
                    // 2011/03/07 Add >>>
                    PurchaseStatus purchaseStatus = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM);
                    if (!( purchaseStatus == PurchaseStatus.Contract || purchaseStatus == PurchaseStatus.Trial_Contract ))
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    }
                    // 2011/03/07 Add <<<

                    // SCM�Ŕ���f�[�^�Ȃ瑗�M�Ώ�
                    if (_salesSlip.AcptAnOdrStatus == 30)
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    }
                    // SCM�Œʏ팩�ςȂ瑗�M�Ώ�
                    else if (_salesSlip.AcptAnOdrStatus == 10 && _salesSlip.EstimateDivide == 1)
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    }
                    else
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                    }
                    break;
                default:
                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                    break;
            }
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                msg = "���M�ΏۊO�ł��B";
            }
            return status;
        }

        /// <summary>
        /// ���M�Œ肩���f����
        /// </summary>
        /// <returns></returns>
        private bool CheckMustSend()
        {
            // �I�����C����ʂ�SCM�Ŕ���f�[�^�ɖ₢���킹�ԍ����Z�b�g����Ă���ꍇ�͑��M�Œ�
            //if (_customerInfo.OnlineKindDiv == 10  && _salesSlip.InquiryNumber != 0) // DEL 2011/09/16
            if ((_customerInfo.OnlineKindDiv == 10 || _customerInfo.OnlineKindDiv == 50) && _salesSlip.InquiryNumber != 0)// ADD 2011/09/16
            {
                return true;
            }
            return false;
        }

        // ADD 2014/11/26 k.toyosawa SCM�d�|�ꗗ��10707�Ή� --->>>>>
        /// <summary>
        /// �����p���I�����ʂ̃��O���o�͂��܂��B
        /// </summary>
        /// <remarks>MAHNB01012AD.cs::SalesSlipInputInitDataAcs.LogWrite()���Q�l</remarks>
        /// <param name="result">���쌋��</param>
        private void WriteLog(DialogResult dResult)
        {
            string operation = string.Empty;
            if (dResult == DialogResult.Yes)
            {
                operation = "�͂�";
            }
            else if (dResult == DialogResult.No)
            {
                operation = "������";
            }

            FileStream fileStream = new FileStream(LOG_FILE_NAME, FileMode.Append, FileAccess.Write, FileShare.Write);
            if (fileStream != null)
            {
                StreamWriter writer = new StreamWriter(fileStream, Encoding.GetEncoding("shift_jis"));
                DateTime writingDateTime = DateTime.Now;

                if (writer != null)
                {
                    writer.WriteLine(string.Format(
                        "{0,-19} {1,-5} {2} {3}",   // yyyy/MM/dd hh:mm:ss
                        writingDateTime,
                        writingDateTime.Millisecond,
                        _salesSlip.SalesSlipNum,
                        operation
                    ));
                    writer.Close();
                }
                fileStream.Close();
            }
        }
        // ADD 2014/11/26 k.toyosawa SCM�d�|�ꗗ��10707�Ή� ---<<<<<

        // --- ADD 2015/06/18 T.Miyamoto SCM�d�|�ꗗ��10707 -------------------->>>>>
        /// <summary>
        /// ConfigurationSection�擾����
        /// </summary>
        private AppSettingsSection GetAppSettingsSection()
        {
            ExeConfigurationFileMap file = new ExeConfigurationFileMap();

            file.ExeConfigFilename = Exe_Conf_Filename;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(file, ConfigurationUserLevel.None);

            return (AppSettingsSection)config.GetSection(App_Set_Section);
        }
        // --- ADD 2015/06/18 T.Miyamoto SCM�d�|�ꗗ��10707 --------------------<<<<<
        #endregion
    }
}

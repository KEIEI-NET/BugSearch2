//****************************************************************************//
// �V�X�e��         : �����d����M����
// �v���O��������   : �����d����M����View
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/11/17  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2009/10/09  �C�����e : ��M�̊Y���f�[�^�����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21024  ���X�� �� 
// �� �� ��  2010/10/19  �C�����e : �݌Ɏd���f�[�^�쐬�����̕������؂�Ȃ��悤�ɏC��(MANTIS[0016443])
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 32470  �����@��� 
// �� �� ��  2021/07/09  �C�����e : ��M������O�������̃��O�o�͒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11601223-00  �쐬�S�� : ���O
// �� �� ��  K2021/09/22  �C�����e : PMKOBETSU-4189 ���O�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11770181-00  �쐬�S�� : 杍^
// �� �� ��  2021/12/08   �C�����e : PMKOBETSU-4202 �����d����M���� �f�[�^�Ǎ����P�Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Exception;
using System.IO;//ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή�

namespace Broadleaf.Windows.Forms
{
    using LoginWorkerAcs        = SingletonPolicy<LoginWorker>;
    using UOESupplierUIItemType = CodeNamePair<int>;

    /// <summary>
    /// �����d����M����View�N���X
    /// </summary>
    /// <remarks>
    /// <br>Update Note: PMKOBETSU-4189�@���O�ǉ�</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : K2021/09/22</br>
    /// </remarks>
    public partial class OroshishoStockReceptionView : UserControl
    {
        // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------>>>>>
        /// <summary>���O���e</summary>
        private const string CtLogDataMassage = "�d���⍇���ԍ�={0};��M����={1}��;�񓚃f�[�^�쐬={2}��;�d���f�[�^�쐬={3}��";
        /// <summary>�ُ탍�O���e</summary>
        private const string CtErrLogDataMassage = "�d���⍇���ԍ�={0};��M����={1}��;�񓚃f�[�^�쐬={2}��;�d���f�[�^�쐬={3}��;�G���[���e={4}";
        /// <summary>�d���⍇���ԍ�</summary>
        private string UOESalesOrderNo = string.Empty;
        /// <summary>���엚�����O�o�^�A�N�Z�X</summary>
        private UoeOprtnHisLogAcs _uoeOprtnHisLogAcs = null;
        /// <summary>���O�o��PGID</summary>
        private const string CtLogOutputPgid = "PMUOE01301U";
        /// <summary>���O�o�͋��ʕ��i</summary>
        OutLogCommon LogCommon;
        // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------<<<<<
        // ------ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή� ------>>>>>
        // ����XML�t�@�C��
        private const string HISLOGOUTSETTINGFILE = "PMUOE01300U_HisLogOutSetting.xml";
        // �o�͐���XML
        private HisLogOutSetting HisLogOutSettingInfo;
        // ------ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή� ------<<<<<

        #region <UOE������/>

        /// <summary>
        /// UOE�����悪���݂��邩���肵�܂��B
        /// </summary>
        /// <value>
        /// <c>true </c>:���݂���B
        /// <c>false</c>:���݂��Ȃ��B
        /// </value>
        public bool ExistsUOESupplier
        {
            get { return this.uoeSupplierComboBox.Items.Count > 0; }
        }

        /// <summary>UOE������̃}�b�v</summary>
        /// <remarks>Key:UOE������R�[�h</remarks>
        private readonly IDictionary<int, UOESupplierHelper> _uoeSupplierCodedMap = new Dictionary<int, UOESupplierHelper>();
        /// <summary>
        /// UOE������̃}�b�v���擾���܂��B
        /// </summary>
        /// <value>UOE������̃}�b�v</value>
        private IDictionary<int, UOESupplierHelper> UOESupplierCodedMap { get { return _uoeSupplierCodedMap; } }

        /// <summary>
        /// �d����M�������s���邩���肵�܂��B
        /// </summary>
        /// <remarks>
        /// �d����M�������s����ꍇ�A������}�b�v�ɓo�^����܂��B
        /// </remarks>
        /// <param name="uoeSupplier">UOE������</param>
        /// <returns>
        /// <c>true</c> :�d����M�������s����<br/>
        /// <c>false</c>:�d����M�������s���Ȃ�
        /// </returns>
        private bool CanReceivingStocking(UOESupplier uoeSupplier)
        {
            if (UOESupplierUtil.HasStockSlipData(uoeSupplier.StockSlipDtRecvDiv))   // �d����M�敪(=1�F����j
            {
                UOESupplierHelper uoeSupplierItem = UOESupplierUtil.CreateHelper(uoeSupplier, EnterpriseProfile);
                // UOE�d���悪SPK(���̑�)�A�����Y�Ƃŏ����͕ω�
                if (!uoeSupplierItem.CanReceiveStoking()) return false;

                if (!UOESupplierCodedMap.ContainsKey(uoeSupplier.UOESupplierCd))
                {
                    UOESupplierCodedMap.Add(uoeSupplier.UOESupplierCd, uoeSupplierItem);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// UOE����������������܂��B
        /// </summary>
        /// <exception cref="OroshishoStockReceptionException">UOE������}�X�^�̌����Ɏ��s���܂����B</exception>
        private void InitializeUOESupplier()
        {
            // UOE������}�X�^������
            UOESupplierAcs uoeSupplierAcs = new UOESupplierAcs();
            ArrayList uoeSupplierList = new ArrayList();

            int status = uoeSupplierAcs.Search(out uoeSupplierList, EnterpriseProfile.Code, SectionProfile.Code);
            if (!status.Equals((int)Result.RemoteStatus.Normal))
            {
                const string ERR_MSG = "UOE������}�X�^�̌����Ɏ��s���܂����B"; // LITERAL:
                Debug.Assert(status.Equals((int)Result.RemoteStatus.Normal), ERR_MSG);
                throw new OroshishoStockReceptionException(ERR_MSG, status);
            }

            // UOE������UI��������
            UOESupplierCodedMap.Clear();
            this.uoeSupplierComboBox.Items.Clear();
            foreach (UOESupplier uoeSupplier in uoeSupplierList)
            {
                if (CanReceivingStocking(uoeSupplier))
                {
                    this.uoeSupplierComboBox.Items.Add(
                        new UOESupplierUIItemType(uoeSupplier.UOESupplierCd, uoeSupplier.UOESupplierName)
                    );
                }
            }
            if (this.uoeSupplierComboBox.Items.Count > 0)
            {
                this.uoeSupplierComboBox.SelectedIndex = 0;
            }
            else
            {
                this.uoeSupplierComboBox.Enabled = false;
            }
        }

        /// <summary>
        /// �I������Ă���UOE��������擾���܂��B
        /// </summary>
        /// <value>�I������Ă���UOE������</value>
        private UOESupplierHelper SelectedUOESupplier
        {
            get
            {
                UOESupplierUIItemType selectedUOESupplierItem = (UOESupplierUIItemType)this.uoeSupplierComboBox.SelectedItem;
                return UOESupplierCodedMap[selectedUOESupplierItem.Code];
            }
        }

        #endregion  // <UOE������/>

        #region <�d���f�[�^/>

        #region <UOE���Аݒ�/>

        /// <summary>
        /// UOE���Аݒ���擾���܂��B
        /// </summary>
        public UOESetting UOESetting { get { return LoginWorkerAcs.Instance.Policy.UOESetting; } }

        #endregion  // <UOE���Аݒ�/>

        /// <summary>
        /// �d���f�[�^�����������܂��B
        /// </summary>
        /// <remarks>
        /// UOE���Аݒ��ݒ肵�܂��B
        /// </remarks>
        /// <exception cref="OroshishoStockReceptionException">UOE���Аݒ�}�X�^�̌����Ɏ��s���܂����B</exception>
        private void InitializeStockData()
        {
            // UOE���Аݒ�}�X�^������
            if (UOESetting == null)
            {
                const string ERR_MSG = "UOE���Аݒ�}�X�^�̌����Ɏ��s���܂����B";   // LITERAL:
                throw new OroshishoStockReceptionException(ERR_MSG, (int)Result.Code.Error);
            }

            // UOE���Аݒ�}�X�^�̉����X�V�敪���蓮�̏ꍇ�A�d���f�[�^UI�͔�\��
            if (IsManualThatIsDistEnterDivOfUOESetting())
            {
                this.stockingTitleLabel.Visible= false;
                this.stockingCountLabel.Visible= false;
                this.stockingUnitLabel.Visible = false;

                return;
            }

            // ���|�Ǘ�����̏ꍇ�A�d���f�[�^�쐬
            if (LoginWorkerAcs.Instance.Policy.HasStockingPaymentOption)
            {
                this.stockingTitleLabel.Text = "�d���f�[�^�쐬";    // Literal:
            }
            // ���|�Ǘ��Ȃ��̏ꍇ�A�݌Ɏd���f�[�^�쐬
            else
            {
                this.stockingTitleLabel.Text = "�݌Ɏd���f�[�^�쐬";// Literal:
            }
        }

        /// <summary>
        /// UOE���Аݒ�}�X�^�̉����X�V�敪���蓮�����肵�܂��B
        /// </summary>
        /// <returns>
        /// <c>true</c> :�蓮<br/>
        /// <c>false</c>:����ȊO
        /// </returns>
        private bool IsManualThatIsDistEnterDivOfUOESetting()
        {
            return UOESetting.DistEnterDiv.Equals((int)LoginWorker.OroshishoDistEnterDiv.Manual);
        }

        #endregion  // <�d���f�[�^/>

        #region <Constructor/>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public OroshishoStockReceptionView()
        {
            #region <Designer Code/>

            InitializeComponent();

            #endregion  // <Designer Code/>

            UpdateProgress += DebugWriteLine;

            GetControlXmlInfo();//ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή�
        }

        /// <summary>
        /// ���������܂��B
        /// </summary>
        /// <exception cref="OroshishoStockReceptionException">
        /// <list type="bullet">
        /// <item>
        /// <description>UOE������}�X�^�̌����Ɏ��s���܂����B</description>
        /// </item>
        /// <item>
        /// <description>UOE���Аݒ�}�X�^�̌����Ɏ��s���܂����B</description>
        /// </item>
        /// </list>
        /// </exception>
        public void Initialize()
        {
            // UOE������UI��������
            InitializeUOESupplier();

            // �d���f�[�^UI��������
            InitializeStockData();

            // ���s���ʂ̕\����������
            InitializeResult();
        }

        /// <summary>
        /// ���s���ʂ̕\�������������܂��B
        /// </summary>
        private void InitializeResult()
        {
            const string EMPTY_RESULT = "0";

            // ��M����UI��������
            this.receptionCountLabel.Text = EMPTY_RESULT;

            // �񓚃f�[�^UI��������
            this.answerCountLabel.Text = EMPTY_RESULT;

            // �d���f�[�^�^�݌Ɏd���f�[�^UI��������
            this.stockingCountLabel.Text = EMPTY_RESULT;
        }

        #endregion  // <Constructor/>

        /// <summary>�i�����X�V����C�x���g</summary>
        public event UpdateProgressEventHandler UpdateProgress;

        #region <��ƃv���t�B�[��/>

        /// <summary>
        /// ��ƃv���t�B�[�����擾���܂��B
        /// </summary>
        /// <value>��ƃv���t�B�[��</value>
        private CodeNamePair<string> EnterpriseProfile
        {
            get { return LoginWorkerAcs.Instance.Policy.EnterpriseProfile; }
        }

        #endregion  // <��ƃv���t�B�[��/>

        #region <���_�v���t�B�[��/>

        /// <summary>
        /// ���_�v���t�B�[�����擾���܂��B
        /// </summary>
        /// <value>���_�v���t�B�[��</value>
        private CodeNamePair<string> SectionProfile
        {
            get { return LoginWorkerAcs.Instance.Policy.SectionProfile; }
        }

        #endregion  // <���_�v���t�B�[��/>

        /// <summary>
        /// ���������s���܂��B
        /// </summary>
        /// <param name="processID">����ID</param>
        /// <returns>���ʃR�[�h</returns>
        // 2009/10/09 >>>
        //public int Execute()
        /// <remarks>
        /// <br>Update Note: PMKOBETSU-4189�@���O�ǉ�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : K2021/09/22</br>
        /// </remarks>
        public int Execute(out Result.ProcessID processID)
        // 2009/10/09 <<<
        {
            // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------>>>>>
            //���엚�����O�A�N�Z�X
            _uoeOprtnHisLogAcs = UoeOprtnHisLogAcs.GetInstance();
            string logMsg = string.Empty;
            int uOESupplierCd = SelectedUOESupplier.RealUOESupplier.UOESupplierCd;
            // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------<<<<<
            processID = Result.ProcessID.None; // 2009/10/09 Add

            InitializeResult();

            IList<OroshishoStockReceptionController> controllerList = new List<OroshishoStockReceptionController>();

            // 1.�d����M����
            controllerList.Add(CreateReceiveStockAcs());

            // 2.�d���񓚃f�[�^�쐬����
            controllerList.Add(CreateMakeStockAnswerDataAcs((ReceiveStockAcs)controllerList[0]));

            // 3.�v��f�[�^�쐬����
            controllerList.Add(CreateMakeSumUpDataAcs());

            // 3.5.�݌ɒ����f�[�^�쐬����
            MakeSumUpDataController makeStockAdjustAcs = CreateMakeStockAdjustAcs();
            if (makeStockAdjustAcs != null)
            {
                controllerList.Add(makeStockAdjustAcs);
            }

            // 4.�񓚕\��
            controllerList.Add(CreateShowAnswerAcs());

            int resultCode = (int)Result.Code.Normal;
            try
            {
                foreach (OroshishoStockReceptionController controller in controllerList)
                {
                    resultCode = controller.Execute();
                    processID = controller.ProcessID;   // 2009/10/09 Add
                    if (processID == Result.ProcessID.MakeStockAnswerData) UOESalesOrderNo = ((MakeStockAnswerDataAcs)controller).UOESalesOrderNo;// ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή�
                    if (!resultCode.Equals((int)Result.Code.Normal)) break;
                }
                // ------ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή� ------>>>>>
                if (HisLogOutSettingInfo.OutFlg)
                {
                    // ------ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή� ------<<<<<
                    // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------>>>>>
                    //���엚�����O�o�^
                    logMsg = string.Format(CtLogDataMassage, UOESalesOrderNo, this.receptionCountLabel.Text, this.answerCountLabel.Text, this.stockingCountLabel.Text);
                    _uoeOprtnHisLogAcs.logd_update(this, string.Empty, string.Empty, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_END, resultCode, logMsg, uOESupplierCd);
                    // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------<<<<<
                }//ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή�
                if (resultCode.Equals((int)Result.Code.Normal)) InitializeResult();
            }
            catch (ArgumentException e)
            {
                // --ADD 2021/07/09 ��O�������̃��O�o�͒ǉ� ------>>>>>>
                OutLogCommon outlogCommonObj = new OutLogCommon();
                outlogCommonObj.OutputClientLog("PMUOE01301U", "PMUOE01301U.Execute ��O���� processID=" + processID.ToString(), EnterpriseProfile.Code, LoginWorkerAcs.Instance.Policy.Detail.EmployeeCode, e);
                // --ADD 2021/07/09 ��O�������̃��O�o�͒ǉ� ------<<<<<<
                Debug.WriteLine(e.ToString());
                resultCode = (int)Result.Code.ExistSlip;
                // ------ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή� ------>>>>>
                if (HisLogOutSettingInfo.OutFlg)
                {
                    // ------ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή� ------<<<<<
                    // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------>>>>>
                    //���엚�����O�o�^
                    logMsg = string.Format(CtErrLogDataMassage, UOESalesOrderNo, this.receptionCountLabel.Text, this.answerCountLabel.Text, this.stockingCountLabel.Text, e.Message);
                    _uoeOprtnHisLogAcs.logd_update(this, string.Empty, string.Empty, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_END, resultCode, logMsg, uOESupplierCd);
                    WriteClcLogProc(CtLogOutputPgid, logMsg);
                    // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------<<<<<
                }//ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή�
            }
            // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------>>>>>
            catch (Exception e)
            {
                // ------ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή� ------>>>>>
                if (HisLogOutSettingInfo.OutFlg)
                {
                    // ------ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή� ------<<<<<
                    resultCode = (int)Result.Code.Error;
                    //���엚�����O�o�^
                    logMsg = string.Format(CtErrLogDataMassage, UOESalesOrderNo, this.receptionCountLabel.Text, this.answerCountLabel.Text, this.stockingCountLabel.Text, e.Message);
                    _uoeOprtnHisLogAcs.logd_update(this, string.Empty, string.Empty, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_END, resultCode, logMsg, uOESupplierCd);
                    WriteClcLogProc(CtLogOutputPgid, logMsg);
                }//ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή�
                throw;
            }
            // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------<<<<<
            return resultCode;
        }

        // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------>>>>>
        /// <summary>
        /// CLC���O�o�͏������\�b�h
        /// </summary>
        /// <param name="pgid">�ďo�����\�b�h��</param>
        /// <param name="message">�o�̓��b�Z�[�W�{��</param>
        /// <remarks>
        /// <br>Note       : CLC���O�o�͋��ʃ��\�b�h���ďo</br>
        /// <br>Programmer : �c������</br>
        /// <br>Date       : K2021/09/22</br>
        /// </remarks>
        public void WriteClcLogProc(string pgid, string message)
        {
            try
            {
                if (LogCommon == null)
                {
                    LogCommon = new OutLogCommon();
                }
                LogCommon.OutputClientLog(pgid, message, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode);
            }
            catch
            {
                // ���O�o�͏����̂��߁A��O�͖�������
            }
        }
        // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------<<<<<

        // ------ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή� ------>>>>>
        /// <summary>
        /// �o�͐���XML�t�@�C���擾
        /// </summary>
        /// <remarks>
        /// <br>Note         : �o�͐���XML�t�@�C���擾�������s��</br>
        /// <br>Programmer   : 杍^</br>
        /// <br>Date         : 2021/12/08</br>
        /// </remarks>
        public void GetControlXmlInfo()
        {
            try
            {
                HisLogOutSettingInfo = new HisLogOutSetting();
                if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, HISLOGOUTSETTINGFILE)))
                {
                    // XML�����擾����
                    HisLogOutSettingInfo = UserSettingController.DeserializeUserSetting<HisLogOutSetting>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, HISLOGOUTSETTINGFILE));
                }
                else
                {
                    HisLogOutSettingInfo.OutFlg = false;
                }
            }
            catch
            {
                if (HisLogOutSettingInfo == null) HisLogOutSettingInfo = new HisLogOutSetting();
                HisLogOutSettingInfo.OutFlg = false;
            }
        }
        // ------ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή� ------<<<<<


        /// <summary>
        /// �t�H�[�}�b�g�����ꂽ�������擾���܂��B
        /// </summary>
        /// <param name="count">����</param>
        /// <returns>ZZZ,ZZ9</returns>
        private static string FormatCount(int count)
        {
            return string.Format("{0:N0}", count);
        }

        #region <�d����M����/>

        /// <summary>
        /// �d����M����Controller�𐶐����܂��B
        /// </summary>
        /// <returns>�d����M����Controller</returns>
        private ReceiveStockAcs CreateReceiveStockAcs()
        {
            ReceiveStockAcs receiveStockAcs = new ReceiveStockAcs(SelectedUOESupplier);
            receiveStockAcs.UpdateProgress += this.UpdateProgressOfStockReceive;
            return receiveStockAcs;
        }

        /// <summary>
        /// �d����M�����̐i�����X�V����C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void UpdateProgressOfStockReceive(
            object sender,
            UpdateProgressEventArgs e
        )
        {
            this.receptionCountLabel.Text = FormatCount(e.Count);
            this.Update();

            UpdateProgress(sender, e);
        }

        #endregion  // <�d����M����/>

        #region <�d���񓚃f�[�^�쐬����/>

        /// <summary>
        /// �d���񓚃f�[�^�쐬����Controller�𐶐����܂��B
        /// </summary>
        /// <param name="inputMaker">���̓f�[�^�̍쐬��</param>
        /// <returns>�d���񓚃f�[�^�쐬����Controller</returns>
        private MakeStockAnswerDataAcs CreateMakeStockAnswerDataAcs(ReceiveStockAcs inputMaker)
        {
            MakeStockAnswerDataAcs makeStockAnswerDataAcs = new MakeStockAnswerDataAcs(SelectedUOESupplier, inputMaker);
            makeStockAnswerDataAcs.UpdateProgress += this.UpdateProgressOfAnswerData;
            return makeStockAnswerDataAcs;
        }

        /// <summary>
        /// �d���񓚃f�[�^�쐬�����̐i�����X�V����C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void UpdateProgressOfAnswerData(
            object sender,
            UpdateProgressEventArgs e
        )
        {
            if (!e.IsRunning)
            {
                this.answerCountLabel.Text = FormatCount(e.Count);
                this.Update();
            }

            UpdateProgress(sender, e);
        }

        #endregion  // <�d���񓚃f�[�^�쐬����/>

        #region <�v��f�[�^�쐬����/>

        /// <summary>
        /// �v��f�[�^�쐬����Controller�𐶐����܂��B
        /// </summary>
        /// <returns>�v��f�[�^�쐬����Controller</returns>
        private MakeSumUpDataController CreateMakeSumUpDataAcs()
        {
            MakeSumUpDataController makeSumUpDataAcs = new MakeStockDataAcs(SelectedUOESupplier);
            {
                // ���|�Ǘ�����̏ꍇ�A�d���f�[�^�쐬�̂�
                if (LoginWorkerAcs.Instance.Policy.HasStockingPaymentOption)
                {
                    makeSumUpDataAcs.CanNotWriting = false;
                }
                // ���|�Ǘ��Ȃ��̏ꍇ�A�d���f�[�^�쐬�ƍ݌Ɏd���f�[�^�쐬
                else
                {
                    makeSumUpDataAcs.CanNotWriting = true;
                }
                makeSumUpDataAcs.UpdateProgress += this.UpdateProgressOfSumUpData;
            }
            return makeSumUpDataAcs;
        }

        /// <summary>
        /// �݌ɒ����f�[�^�쐬����Controller�𐶐����܂��B
        /// </summary>
        /// <returns>�݌ɒ����f�[�^�쐬����Controller</returns>
        private MakeSumUpDataController CreateMakeStockAdjustAcs()
        {
            MakeSumUpDataController makeSumUpDataAcs = null;
            {
                // ���|�Ǘ�����̏ꍇ�A�d���f�[�^�쐬
                if (LoginWorkerAcs.Instance.Policy.HasStockingPaymentOption)
                {
                    return makeSumUpDataAcs;
                }
                // ���|�Ǘ��Ȃ��̏ꍇ�A�݌Ɏd���f�[�^�쐬
                else
                {
                    makeSumUpDataAcs = new MakeStockAdjustAcs(SelectedUOESupplier);
                }
                makeSumUpDataAcs.UpdateProgress += this.UpdateProgressOfSumUpData;
            }
            return makeSumUpDataAcs;
        }

        /// <summary>
        /// �v��f�[�^�쐬�����̐i�����X�V����C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void UpdateProgressOfSumUpData(
            object sender,
            UpdateProgressEventArgs e
        )
        {
            this.stockingCountLabel.Text = FormatCount(e.Count);
            this.Update();

            UpdateProgress(sender, e);
        }

        #endregion  // <�v��f�[�^�쐬����/>

        #region <�񓚕\��/>

        /// <summary>
        /// �񓚕\��Controller�𐶐����܂��B
        /// </summary>
        /// <returns>�񓚕\��Controller</returns>
        private ShowAnswerAcs CreateShowAnswerAcs()
        {
            ShowAnswerAcs showAnswerAcs = new ShowAnswerAcs(SelectedUOESupplier);
            showAnswerAcs.UpdateProgress += this.UpdateProgressOfShowingAnswer;
            return showAnswerAcs;
        }

        /// <summary>
        /// �񓚕\���̐i�����X�V����C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void UpdateProgressOfShowingAnswer(
            object sender,
            UpdateProgressEventArgs e
        )
        {
            UpdateProgress(sender, e);
        }

        #endregion  // <�񓚕\��/>

        #region <�f�o�b�O�p/>

        /// <summary>
        /// �i����Debug.WriteLine()���܂��B
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private static void DebugWriteLine(
            object sender,
            UpdateProgressEventArgs e
        )
        {
            Debug.WriteLine(e.ToString());
        }

        #endregion  // <�f�o�b�O�p/>
    }

    // ------ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή� ------>>>>>
    /// <summary>
    /// ���엚���̓o�^�A���O�o�͐ݒ�
    /// </summary>
    public class HisLogOutSetting
    {
        // ���엚���̓o�^�A���O�o�͋敪
        private bool _outFlg;

        /// <summary>
        /// ���엚���̓o�^�A���O�o�͐ݒ�N���X
        /// </summary>
        public HisLogOutSetting()
        {

        }

        /// <summary>���엚���̓o�^�A���O�o�͋敪</summary>
        public bool OutFlg
        {
            get { return this._outFlg; }
            set { this._outFlg = value; }
        }
    }
    // ------ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή� ------<<<<<
}

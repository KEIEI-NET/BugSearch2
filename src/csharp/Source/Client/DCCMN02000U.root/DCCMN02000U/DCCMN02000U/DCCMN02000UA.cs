using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �`�[����t�h�ďo����
    /// </summary>
    /// <remarks>
    /// <br>Note         : �`�[����m�F��ʂ̌Ăяo��������s���N���X�ł��B</br>
    /// <br>               �i��UI�ł̑g�ݍ��ݎ��A�قȂ�`�[�^�C�v�ł��P��̃R�[���Ŏ��s�ł���悤�ɂ���ׁA�����j</br>
    /// <br>Programmer   : 22018 ��؁@���b</br>
    /// <br>Date         : 2008.02.25</br>
    /// <br>-----------------------------------------------------------------</br>
    /// <br>Update Note  : 2008.05.29  22018 ��� ���b</br>
    /// <br>             : �@PM.NS�����ύX�B�S�̓I�ɑ啝�ɕύX�B</br>
    /// <br>Update Note  : 2009.07.16  20056 ���n ���</br>
    /// <br>             : �T�[�o�[�֔z�u����N���C�A���g�A�Z���u���Ή�</br>
    /// <br>             : �@���O�C�����擾���@�ύX</br>
    /// <br>             : �A�T�[�r�X�N���v���p�e�B�ǉ�</br>
    /// <br>             : �B�E�C���h�E�\�������ǉ�</br>
    /// <br>Update Note  : 2010/07/30  20056 ���n ���</br>
    /// <br>             : SCM�N���C�A���g��M�Ή� </br>
    /// <br>             : �T�[�r�X�N��(�T�[�o�[)�������Ȃ����ׁA_isService �����0�Ƃ��� </br>
    /// <br>Update Note  : 2010/08/09  �����J</br>
    /// <br>             : PCCUOE </br>
    /// <br>             : �����[�g�`�[���s</br>
    /// <br>Update Note  : 2010/09/15  �����J</br>
    /// <br>             : Redmine#24942 </br>
    /// <br>             : PM������̓`�[���s���鎞�A </br>
    /// <br>             : �u����S�̐ݒ�.����`�[���s�敪=���Ȃ��v�̎���SF�������[�g�`�[�𔭍s����</br>
    /// <br>Update Note  : 2010/09/17  �����J</br>
    /// <br>             : Redmine#25225 </br>
    /// <br>             : �ԓ`���s���̓����`�̔��s�͂��Ȃ�</br>
    /// <br>Update Note  : 2010/10/17  wangqx</br>
    /// <br>             : Redmine#25529 </br>
    /// <br>             : PCC�⍇���ꍇ���Ϗ�����`�B�b�N��ǉ�����</br>
    /// <br>Update Note  : 2011/10/21  22018  ��� ���b</br>
    /// <br>             : SCM���Ӑ�Ŕ���`�[�o�^���ɓ`�[���������Ȃ��s��̏C��</br>
    /// <br>Update Note  : 2011/11/22  ������</br>
    /// <br>             : Redmine#7883 �[���`�݂̂̎��̕s��ɂ���</br>
    /// <br>Update Note  : 2012/01/18  duzg</br>
    /// <br>             : Redmine#28011 �ԓ`���s���Ɉ������Ȃ�</br>
    /// <br>Update Note  : 2012/12/13  30744 ���� ����q</br>
    /// <br>             : SCM��Q��10352 PCCforNS�̎��������[�g�`�[�𔭍s�ł���悤�ɂ���</br>
    /// <br>Update Note  : 2013/06/17  zhubj</br>
    /// <br>             : Redmine #36594</br>
    /// <br>             : ��10542 SCM</br>
    /// <br>Update Note  : 2013/06/21 �e�c ���V
    /// <br>             : SCM��Q�Ή� BLP�����[�g�`�[�����s����Ȃ���Q�̏C��
    /// <br>Update Note  : 2013/07/28  zhubj</br>
    /// <br>             : Redmine #36594</br>
    /// <br>             : ��10542 SCM NO.10�̑Ή�</br>
    /// <br>Update Note  : 2013/09/13  �g��</br>
    /// <br>             : PM.NS�d�|�ꗗ��2137</br>
    /// <br>Update Note  : 2013/09/19  30744 ����</br>
    /// <br>             : Redmine #40342</br>
    /// <br>             : �����[�g�`�[���s���G���[�Ή�</br>
    /// <br>Update Note  : 2013/09/20  �g��</br>
    /// <br>             : �����e��UOE���M���� ���x�x���Ή�</br>
    /// <br>Update Note  : 2014/12/05  �{�{ ����</br>
    /// <br>             : �d�|�ꗗ��2295(��1725)�Ή�</br>
    /// <br>             : ����������ɓo�^�����C�x���g�n���h�����A�����I����ɑS�č폜����悤�ɏC��</br>
    /// <br>             : </br>
    /// <br>Update Note  : 2013/10/30  30744 ����</br>
    /// <br>             : SCM�d�|�ꗗ��10614�Ή�</br>
    /// </remarks>
    public class DCCMN02000UA
    {
        # region [private �t�B�[���h]
        /// <summary>�`�[����A�N�Z�X�N���X</summary>
        private SlipPrintAcs _slipPrintAcs;
        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;
        /// <summary>�`�[����X�e�[�^�X</summary>
        private SlipPrintStatus _slipPrintState;
        // 2009.07.16 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>�T�[�r�X�N���t���O(0:�ʏ� 1:�T�[�r�X�N��)</summary> 
        private int _isService = 0;
        // 2009.07.16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811 begin
        /// <summary>
        /// �����[�g�`�[���s���邩
        /// </summary>
        private bool _IsRmSlpPrt;
        /// <summary>PCCUOE�����񓚋N���t���O(0:�ʏ� 1:PCCUOE�����񓚋N��)</summary> 
        private int _isAutoAns = 0;
        //�r�b�l�S�̐ݒ�̔���`�[����敪
        int _SCMTotalSettingSalesSlipPrtDiv;
        // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811  end
        // ADD 2013/09/19 Redmine#40342�Ή� --------------------------------------------------->>>>>
        // �^�u���b�g�N���敪
        private bool _isTablet = false;
        // ADD 2013/09/19 Redmine#40342�Ή� ---------------------------------------------------<<<<<
        // ADD 2013/09/20 �g�� 2013/09/99�z�M�\�� �����e��UOE���M���� ���x�x���Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �����`�[���̃f�[�^���X�g
        /// </summary>
        private List<List<object>> _printDataList;
        // ADD 2013/09/20 �g�� 2013/09/99�z�M�\�� �����e��UOE���M���� ���x�x���Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        # endregion

        # region [�R���X�g���N�^]
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public DCCMN02000UA()
        {
            _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            _slipPrintAcs = new SlipPrintAcs(_enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);
            _slipPrintState = SlipPrintStatus.BeforeExecute;
        }
        // 2009.07.16 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �R���X�g���N�^(���O�C�����_���g�p���Ȃ�)
        /// </summary>
        /// <param name="sectionCode"></param>
        public DCCMN02000UA(string sectionCode)
        {
            _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            _slipPrintAcs = new SlipPrintAcs(_enterpriseCode, sectionCode);
            _slipPrintState = SlipPrintStatus.BeforeExecute;
        }
        // 2009.07.16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        # endregion

        # region [public �v���p�e�B]
        /// <summary>
        /// �`�[����X�e�[�^�X
        /// </summary>
        public SlipPrintStatus SlipPrintState
        {
            get { return _slipPrintState; }
        }
        // 2009.07.16 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// PCCUOE�����񓚋N���t���O�v���p�e�B(0:�ʏ� 1:PCCUOE�����񓚋N��)
        /// </summary>
        public int IsAutoAns
        {
            get { return this._isAutoAns; }
            set { this._isAutoAns = value; }
        }
        // 2009.07.16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811 begin
        /// <summary>
        /// �T�[�r�X�N���v���p�e�B
        /// </summary>
        public int IsService
        {
            get { return this._isService; }
            //>>>2010/07/30
            //set { this._isService = value; }
            set { this._isService = 0; }
            //<<<2010/07/30
        }
        // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811  end
        // ADD 2013/09/19 Redmine#40342�Ή� --------------------------------------------------->>>>>
        /// <summary>
        /// �^�u���b�g�N���敪(True:�^�u���b�g���N�� False:�^�u���b�g�ȊO���N��)
        /// </summary>
        public bool IsTablet
        {
            get { return this._isTablet; }
            set { this._isTablet = value; }
        }
        // ADD 2013/09/19 Redmine#40342�Ή� ---------------------------------------------------<<<<<
        # endregion

        # region [public ���\�b�h]
        /// <summary>
        /// ��������i��ʕ\���Ȃ��j
        /// </summary>
        /// <param name="iSlipPrintCndtn">�`�[�������</param>
        /// <remarks>
        /// <br>��ʕ\�������ɒ��ڈ���������s���܂��B</br>
        /// </remarks>
        public void Print(ISlipPrintCndtn iSlipPrintCndtn)
        {
            // ��ʕ\���Ȃ�
            this.ShowDialogProc(iSlipPrintCndtn, true);
        }
        /// <summary>
        /// ����m�F��ʕ\��
        /// </summary>
        /// <param name="iSlipPrintCndtn">�`�[�������</param>
        /// <param name="printWithoutDialog">�_�C�A���O�\���Ȃ��t���O</param>
        public void ShowDialog(ISlipPrintCndtn iSlipPrintCndtn, bool printWithoutDialog)
        {
            // ��ʕ\���C��
            this.ShowDialogProc(iSlipPrintCndtn, printWithoutDialog);
        }
        # endregion

        # region [private ���\�b�h]
        /// <summary>
        /// ����m�F��ʕ\������
        /// </summary>
        /// <param name="iSlipPrintCndtn">�`�[�������</param>
        /// <param name="printWithoutDialog">�m�F�_�C�A���O�\�������t���O</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>�`�[����m�F��ʂ�\�����܂��B</br>
        /// <br>printWithoutDialog = true �̏ꍇ�͉�ʕ\�������ɒ��ڈ���������s���܂��B</br>
        /// <br>Update Note  : 2011/11/22  ������</br>
        /// <br>             : �[���`�݂̂̎��̕s��ɂ���</br>
        /// <br></br>
        /// </remarks>
        private void ShowDialogProc(ISlipPrintCndtn iSlipPrintCndtn, bool printWithoutDialog)
        {
            if (iSlipPrintCndtn == null)
            {
                _slipPrintState = SlipPrintStatus.Error_Cndtn;
                return;
            }
            else if (String.IsNullOrEmpty(iSlipPrintCndtn.EnterpriseCode))
            {
                _slipPrintState = SlipPrintStatus.Error_Cndtn_EnterpriseCode;
                return;
            }
            else
            {
                if (iSlipPrintCndtn is SalesSlipPrintCndtn)
                {
                    // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811 begin
                    _slipPrintAcs.IsRmSlpPrt = false;
                    this._IsRmSlpPrt = false;

                    // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811  end
                    // ����f�[�^�̏ꍇ
                    // update by zhouzy for PCCUOE�����[�g�`�[���s 20110915  begin
                    //CallSalesSlipPrint((SalesSlipPrintCndtn)iSlipPrintCndtn, printWithoutDialog);
                    if (((SalesSlipPrintCndtn)iSlipPrintCndtn).NomalSalesSlipPrintFlag == 0)
                    {
                        //SCM�S�̐ݒ�.����`�[����t���O
                        _SCMTotalSettingSalesSlipPrtDiv = ((SalesSlipPrintCndtn)iSlipPrintCndtn).SCMTotalSettingSalesSlipPrtDiv;
                        //���Ӑ�}�X�^�Ɣ���S�̐ݒ�}�X�^�̐ݒ���A������鎞�B
                        CallSalesSlipPrint((SalesSlipPrintCndtn)iSlipPrintCndtn, printWithoutDialog);
                    }
                    // update by zhouzy for PCCUOE�����[�g�`�[���s 20110915  end
                    // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811 begin
                    Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;
                    ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(Broadleaf.Application.Resources.ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_RemoteSlipPrt);
                   // if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract) //delete by lingxiaoqing on 20110930 for #Redmine25699
                   if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract || ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Trial_Contract ) //add by lingxiaoqing on 20110930 for #Redmine25699
                    {
                        // update by zhouzy 20110917  begin
                        if (((SalesSlipPrintCndtn)iSlipPrintCndtn).RemoteSalesSlipPrintFlag != 1 && ((SalesSlipPrintCndtn)iSlipPrintCndtn).ScmFlg)
                        {
                            _slipPrintAcs.IsRmSlpPrt = true;
                            this._IsRmSlpPrt = true;
                            CallSalesSlipPrint((SalesSlipPrintCndtn)iSlipPrintCndtn, printWithoutDialog);
                        }
                        // update by zhouzy 20110917 end
                    }
                    else
                    {
                        _slipPrintAcs.IsRmSlpPrt = false;
                        this._IsRmSlpPrt = false;
                    }

                    // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811  end
                }
                else if (iSlipPrintCndtn is StockSlipPrintCndtn)
                {
                    // �d���f�[�^�̏ꍇ
                    CallStockSlipPrint((StockSlipPrintCndtn)iSlipPrintCndtn, printWithoutDialog);
                }
                else if (iSlipPrintCndtn is StockMoveSlipPrintCndtn)
                {
                    // �݌Ɉړ��f�[�^�̏ꍇ
                    CallStockMoveSlipPrint((StockMoveSlipPrintCndtn)iSlipPrintCndtn, printWithoutDialog);
                }
                else if (iSlipPrintCndtn is EstFmPrintCndtn)
                {
                    // ���Ϗ��f�[�^�̏ꍇ
                    CallEstFmPrint((EstFmPrintCndtn)iSlipPrintCndtn, printWithoutDialog);
                }
                else if (iSlipPrintCndtn is UOESlipPrintCndtn)
                {
                    // �t�n�d�`�[�f�[�^�̏ꍇ
                    // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811 begin
                    _slipPrintAcs.IsRmSlpPrt = false;
                    this._IsRmSlpPrt = false;
                    CallUOESlipPrint((UOESlipPrintCndtn)iSlipPrintCndtn, printWithoutDialog);
                    // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811  end
                    // --- DEL 2013/06/21 Y.Wakita ---------->>>>>
                    //// ADD by gezh for rednine#7883 2011/11/22 begin --------->>>>>
                    //if (iSlipPrintCndtn.ExtrData == null || iSlipPrintCndtn.ExtrData.Count == 0)
                    //{
                    //    return;
                    //}
                    //// ADD by gezh for rednine#7883 2011/11/22 end -----------<<<<<
                    // --- DEL 2013/06/21 Y.Wakita ----------<<<<<
                    // ADD 2013/09/13 PM.NS�d�|�ꗗ��2137 �g��------------->>>>>>>>>>>>>>>
                    bool rtnFlg = true;
                    foreach(UoeSales uoeSales in ((UOESlipPrintCndtn)iSlipPrintCndtn).UOESalesList)
                    {
                        if (!string.IsNullOrEmpty(uoeSales.salesSlipWork.SalesSlipNum))
                        {
                            rtnFlg = false;
                            break;
                        }
                    }
                    if (rtnFlg) return;
                    // ADD 2013/09/13 PM.NS�d�|�ꗗ��2137 �g�� -------------<<<<<<<<<<<<<<<
                    // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811 begin
                    Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;
                    ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(Broadleaf.Application.Resources.ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_RemoteSlipPrt);
                   // if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract) //delete by lingxiaoqing on 20110930 for #Redmine25699
                   if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract || ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Trial_Contract) //add by lingxiaoqing on 20110930 for #Redmine25699
                    {
                        _slipPrintAcs.IsRmSlpPrt = true;
                        this._IsRmSlpPrt = true;
                        // �t�n�d�����[�g�`������
                        CallSalesSlipPrint(CopyToSalesSlipPrintCndtnFromUoe((UOESlipPrintCndtn)iSlipPrintCndtn), printWithoutDialog);
                    }
                    else
                    {
                        _slipPrintAcs.IsRmSlpPrt = false;
                        this._IsRmSlpPrt = false;
                    }

                    // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811  end
                }
            }

            // �G���[���b�Z�[�W�\��
            ShowErrorMessage(_slipPrintState);
        }

        /// <summary>
        /// ����`�[�@����m�F�t�h�Ăяo��
        /// </summary>
        /// <param name="iSlipPrintCndtn"></param>
        /// <param name="printWithoutDialog"></param>
        private void CallSalesSlipPrint(SalesSlipPrintCndtn iSlipPrintCndtn, bool printWithoutDialog)
        {
            if (iSlipPrintCndtn.SalesSlipKeyList == null || iSlipPrintCndtn.SalesSlipKeyList.Count == 0)
            {
                _slipPrintState = SlipPrintStatus.Error_Cndtn_SlipList;
                return;
            }

            // 2009.07.16 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //SFCMN00299CA progressDialog = null;
            //if (!printWithoutDialog)
            //{
            //    // �������_�C�A���O�\���@����
            //    progressDialog = new SFCMN00299CA();
            //    progressDialog.Title = "�`�[�������";
            //    progressDialog.Message = "���݁A�`�[����������ł��B";
            //    progressDialog.Show();
            //}

            SFCMN00299CA progressDialog = null;
            if (this._isService == 0)
            {
                if (!printWithoutDialog)
                {
                    // �������_�C�A���O�\���@����
                    progressDialog = new SFCMN00299CA();
                    progressDialog.Title = "�`�[�������";
                    progressDialog.Message = "���݁A�`�[����������ł��B";
                    progressDialog.Show();
                }
            }
            // 2009.07.16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            List<List<ArrayList>> printDataList = null;

            try
            {
                // ���o�������ڍs
                FrePSalesSlipParaWork paraWork = new FrePSalesSlipParaWork();
                paraWork.EnterpriseCode = iSlipPrintCndtn.EnterpriseCode;
                paraWork.FrePSalesSlipParaKeyList = new List<FrePSalesSlipParaWork.FrePSalesSlipParaKey>();
                for (int index = 0; index < iSlipPrintCndtn.SalesSlipKeyList.Count; index++)
                {
                    SalesSlipPrintCndtn.SalesSlipKey key = iSlipPrintCndtn.SalesSlipKeyList[index];
                    paraWork.FrePSalesSlipParaKeyList.Add(new FrePSalesSlipParaWork.FrePSalesSlipParaKey(key.AcptAnOdrStatus, key.SalesSlipNum));
                }

                // 2009.07.16 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //// �A�N�Z�X�N���XSearch�Ăяo��
                //status = _slipPrintAcs.InitialSearchFrePSalesSlip(paraWork, ref printDataList);
                // �A�N�Z�X�N���XSearch�Ăяo��
                status = _slipPrintAcs.InitialSearchFrePSalesSlip(paraWork, ref printDataList, this._isService);
                // 2009.07.16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                // ADD 2013/10/30 SCM�d�|�ꗗ��10614�Ή� ------------------------------------->>>>>
                paraWork = null;
                // ADD 2013/10/30 SCM�d�|�ꗗ��10614�Ή� -------------------------------------<<<<<
            }
            finally
            {
                // 2009.07.16 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //if (!printWithoutDialog)
                //{
                //    // �������_�C�A���O�I�� ����
                //    if (progressDialog != null)
                //    {
                //        progressDialog.Close();
                //    }
                //}

                if (this._isService == 0)
                {
                    if (!printWithoutDialog)
                    {
                        // �������_�C�A���O�I�� ����
                        if (progressDialog != null)
                        {
                            progressDialog.Close();
                        }
                    }
                }
                // 2009.07.16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            }
            if (status == 0)
            {
                // --------------- ADD START 2013/06/17 zhubj FOR Redmine #36594-------->>>>
                int slipNums = 0;
                //if (_IsRmSlpPrt)//DEL 2013/07/28 zhubj FOR Redmine #36594
                if (_IsRmSlpPrt && !_slipPrintAcs.IsPrintSplit)//ADD 2013/07/28 zhubj FOR Redmine #36594
                {
                    for (int index = 0; index < iSlipPrintCndtn.SalesSlipKeyList.Count; index++)
                    {
                        if (iSlipPrintCndtn.SalesSlipKeyList[index].AcptAnOdrStatus == 30)
                        {
                            slipNums++;
                        }
                    }
                }
                bool isOnlyOneSlip = true;
                if (slipNums > 1)
                {
                    isOnlyOneSlip = false;
                }
                int printCount = 0;
                bool isLastSlip = false;
                // --------------- ADD START 2013/07/28 zhubj FOR Redmine #36594-------->>>>
                // KEY�F�⍇���ԍ��A����`�[�ԍ�
                List<string> latestDiscKeyList = new List<string>();
                // --------------- ADD END 2013/07/28 zhubj FOR Redmine #36594--------<<<<
                // --------------- ADD END 2013/06/17 zhubj FOR Redmine #36594--------<<<<
                // ADD 2013/09/19 yugami Redmine#40342�Ή� --------------------------------------------------->>>>>
                // �v���p�e�B�p����`�[�ԍ����X�g�A�⍇���ԍ����X�g
                List<string> slipNumlist = new List<string>();
                List<string> inquiryNumList = new List<string>();
                // ADD 2013/09/19 yugami Redmine#40342�Ή� ---------------------------------------------------<<<<<
                foreach (List<ArrayList> printData in printDataList)
                {
                    // �`�[����_�C�A���O�Ăяo��
                    DCCMN02000UB slipPrintDialog = new DCCMN02000UB(_slipPrintAcs);
                    slipPrintDialog.IsService = this._isService; // 2009.07.16
                    // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811  begin
                    slipPrintDialog.IsAutoAns = this._isAutoAns;
                    // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811  end
                    // --------------- ADD START 2013/06/17 zhubj FOR Redmine #36594-------->>>>
                    printCount++;
                    if (slipNums > 1 && printCount == printDataList.Count)
                    {
                        isLastSlip = true;
                    }
                    slipPrintDialog.IsOnlyOneSlip = isOnlyOneSlip;
                    slipPrintDialog.IsLastSlip = isLastSlip;
                    // --------------- ADD END 2013/06/17 zhubj FOR Redmine #36594--------<<<<
                    // --------------- ADD END 2013/07/28 zhubj FOR Redmine #36594--------<<<<
                    // ADD 2013/09/19 Redmine#40342�Ή� --------------------------------------------------->>>>>
                    // �^�u���b�g�N���敪
                    slipPrintDialog.IsTablet = this._isTablet;
                    // ADD 2013/09/19 Redmine#40342�Ή� ---------------------------------------------------<<<<<

                    // KEY�F�⍇���ԍ��A����`�[�ԍ�
                    // ����`�[�̏ꍇ
                    FrePSalesSlipWork slipWork = (printData[0][0] as FrePSalesSlipWork);
                    List<Broadleaf.Application.Remoting.ParamData.FrePSalesDetailWork> frePSalesDetailWorkList = printData[0][1] as List<Broadleaf.Application.Remoting.ParamData.FrePSalesDetailWork>;
                    string latestDiscKey = frePSalesDetailWorkList[0].SALESDETAILRF_INQUIRYNUMBERRF + "_" + slipWork.SALESSLIPRF_SALESSLIPNUMRF;
                    if (!latestDiscKeyList.Contains(latestDiscKey))
                    {
                        slipPrintDialog.IsKeyChangeFlag = true;
                        latestDiscKeyList.Add(latestDiscKey);
                        // ADD 2013/09/19 yugami Redmine#40342�Ή� --------------------------------------------------->>>>>
                        slipNumlist.Add(slipWork.SALESSLIPRF_SALESSLIPNUMRF);
                        inquiryNumList.Add(frePSalesDetailWorkList[0].SALESDETAILRF_INQUIRYNUMBERRF.ToString());
                        // ADD 2013/09/19 yugami Redmine#40342�Ή� ---------------------------------------------------<<<<<
                    }
                    else
                    {
                        slipPrintDialog.IsKeyChangeFlag = false;
                    }
                    // --------------- ADD END 2013/07/28 zhubj FOR Redmine #36594--------<<<<
                    if (_IsRmSlpPrt)
                    {
                        //�����[�g�`�[���s�̏ꍇ
                        slipPrintDialog.IsRmSlpPrt = true;

                        // ADD 2013/09/19 yugami Redmine#40342�Ή� --------------------------------------------------->>>>>
                        slipPrintDialog.SlipNumlist = slipNumlist;
                        slipPrintDialog.InquiryNumList = inquiryNumList;
                        // ADD 2013/09/19 yugami Redmine#40342�Ή� ---------------------------------------------------<<<<<

                        // UPD 2012/12/13 2013/01/16�z�M�\�� SCM��Q��10352�Ή� ---------------------------------------->>>>>
                        //if (null != _slipPrintAcs.RmSlpPrtStWork && _slipPrintAcs.RmSlpPrtStWork.RmtSlpPrtDiv == 1 && CheckRmSlpPrt(printData))
                        if (null != _slipPrintAcs.RmSlpPrtStWork && _slipPrintAcs.RmSlpPrtStWork.RmtSlpPrtDiv == 1)
                        // UPD 2012/12/13 2013/01/16�z�M�\�� SCM��Q��10352�Ή� ----------------------------------------<<<<<
                        {
                            // ADD 2013/09/20 �g�� 2013/09/99�z�M�\�� �����e��UOE���M���� ���x�x���Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                            slipPrintDialog.PrintDataList = _printDataList;
                            // ADD 2013/09/20 �g�� 2013/09/99�z�M�\�� �����e��UOE���M���� ���x�x���Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                            slipPrintDialog.ShowDialog(iSlipPrintCndtn, printData, printWithoutDialog, _slipPrintAcs.RmSlpPrtStWork);
                            // ADD 2013/09/20 �g�� 2013/09/99�z�M�\�� �����e��UOE���M���� ���x�x���Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                            _printDataList = slipPrintDialog.PrintDataList;
                            // ADD 2013/09/20 �g�� 2013/09/99�z�M�\�� �����e��UOE���M���� ���x�x���Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        }
                    }
                    else
                    {
                        //�ʏ�̏ꍇ
                        slipPrintDialog.IsRmSlpPrt = false;
                        // zhouzy update 20110927 begin
                        //slipPrintDialog.ShowDialog(iSlipPrintCndtn, printData, printWithoutDialog);
                        if (CheckSCMSlpPrt(printData))
                        {
                            slipPrintDialog.ShowDialog(iSlipPrintCndtn, printData, printWithoutDialog);
                        }
                        // zhouzy update 20110927 end
                    }

                    SetErrorStateFromDialog(ref _slipPrintState, slipPrintDialog);
                    // --- ADD 2014/12/05 T.Miyamoto ------------------------------>>>>>
                    slipPrintDialog.EventDelete();
                    // --- ADD 2014/12/05 T.Miyamoto ------------------------------<<<<<
                    // ADD 2013/10/30 SCM�d�|�ꗗ��10614�Ή� ------------------------------------->>>>>
                    slipPrintDialog.Clear();
                    slipPrintDialog.Dispose();
                    slipPrintDialog = null;
                    GC.Collect();
                    // ADD 2013/10/30 SCM�d�|�ꗗ��10614�Ή� -------------------------------------<<<<<
                }
            }
            else
            {
                //ShowErrorMessageOfSlipAcs( _slipPrintAcs.SlipAcsState, status );
                SetErrorState(ref _slipPrintState, _slipPrintAcs.SlipAcsState);
            }
        }

        // zhouzy add 20110920 begin
        /// <summary>
        /// �����[�g�`�[�𔭍s���邩�𔻒f����
        /// �󔭒���ʂ�1:PCC-UOE�̏ꍇ�͈��
        /// ����ȊO�̏ꍇ�͈�����Ȃ�
        /// </summary>
        /// <param name="printData">����f�[�^</param>
        /// <returns>�`�F�b�N����</returns>
        private bool CheckRmSlpPrt(List<ArrayList> printData)
        {
            bool result = false;
            List<Broadleaf.Application.Remoting.ParamData.FrePSalesDetailWork> frePSalesDetailWorkList = printData[0][1] as List<Broadleaf.Application.Remoting.ParamData.FrePSalesDetailWork>;
            // ���㖾�׃f�[�^���[�N
            FrePSalesDetailWork salesDetailWork = salesDetailWork = frePSalesDetailWorkList[0];
            //PCCUOE�̏ꍇ�A�����[�g�`�[�𔭍s
            if (salesDetailWork.SALESDETAILRF_ACCEPTORORDERKINDRF == 1)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// SCM�`�[�𔭍s���邩�𔻒f����
        /// �󔭒���ʂ�0:SCM�̏ꍇ�A�`�F�b�N���s��
        /// ����ȊO�̏ꍇ�͈�����Ȃ�
        /// </summary>
        /// <param name="printData">����f�[�^</param>
        /// <returns>�`�F�b�N����</returns>
        private bool CheckSCMSlpPrt(List<ArrayList> printData)
        {
            bool result = false;
            List<Broadleaf.Application.Remoting.ParamData.FrePSalesDetailWork> frePSalesDetailWorkList = printData[0][1] as List<Broadleaf.Application.Remoting.ParamData.FrePSalesDetailWork>;
            // ���㖾�׃f�[�^���[�N
            FrePSalesDetailWork salesDetailWork = salesDetailWork = frePSalesDetailWorkList[0];
            //���Ϗ��̏ꍇ
            if (salesDetailWork.SALESDETAILRF_ACPTANODRSTATUSRF == 10)
            {
                //add by wangqx 2011/10/17
                //SCM�̏ꍇ
                if (salesDetailWork.SALESDETAILRF_ACCEPTORORDERKINDRF == 0)
                {
                    // ���Ӑ�}�X�^����擾
                    int SlipPrintDivCd = 0;
                    CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                    CustomerInfo customerInfo;
                    FrePSalesSlipWork slipWork = (printData[0][0] as FrePSalesSlipWork);
                    int flg = customerInfoAcs.ReadDBData(LoginInfoAcquisition.EnterpriseCode, slipWork.SALESSLIPRF_CUSTOMERCODERF, out customerInfo);
                    EstimateDefSetAcs estimateDefSetAcs = new EstimateDefSetAcs();
                    EstimateDefSet estimateDefSet = new EstimateDefSet();
                    // ���ϑS�̐ݒ�擾
                    estimateDefSetAcs.Read(out estimateDefSet, LoginInfoAcquisition.EnterpriseCode, slipWork.SALESSLIPRF_SECTIONCODERF);
                    if (estimateDefSet == null)
                    {
                        estimateDefSetAcs.Read(out estimateDefSet, LoginInfoAcquisition.EnterpriseCode, "00");

                    }
                    if (estimateDefSet == null)
                    {
                        estimateDefSet = new EstimateDefSet();
                    }
                    // ���Ӑ�}�X�^�擾
                    if (flg != (int)ConstantManagement.DB_Status.ctDB_NORMAL || customerInfo == null)
                    {
                        customerInfo = new CustomerInfo();
                    }
                    switch (customerInfo.EstimatePrtDiv)
                    {
                        // 0:�W�� �� ���ϑS�̐ݒ�
                        default:
                        case 0:
                            SlipPrintDivCd = (estimateDefSet.EstimatePrtDiv + 1) % 2;
                            break;
                        // 1:���g�p �� 0:���Ȃ�
                        case 1:
                            SlipPrintDivCd = 0;
                            break;
                        // 2:�g�p �� 1:����
                        case 2:
                            SlipPrintDivCd = 1;
                            break;
                    }
                    if (SlipPrintDivCd != 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }

                }
                // --- Add 2012/01/18 duzg for Redmine#28011 --->>>
                else
                {
                    result = true;
                }
                // --- Add 2012/01/18 duzg for Redmine#28011 ---<<<
                //add by wangqx 2011/10/17
                //result = true;//delete by wangqx 2011/10/17
            }
            //����`�[�̏ꍇ
            else
            {
                //�ʏ�̏ꍇ
                if (salesDetailWork.SALESDETAILRF_ACCEPTORORDERKINDRF == 0)
                {
                    //���M������ꍇ
                    if (salesDetailWork.SALESDETAILRF_INQUIRYNUMBERRF != 0)
                    {
                        // --- ADD m.suzuki 2011/10/21 ---------->>>>>
                        if ( IsAutoAns == 1 )
                        {
                        // --- ADD m.suzuki 2011/10/21 ----------<<<<<
                            if ( _SCMTotalSettingSalesSlipPrtDiv == 1 )
                            {
                                //SCM�S�̐ݒ�.����`�[����t���O�F1 �������
                                result = true;
                            }
                            else
                            {
                                //SCM�S�̐ݒ�.����`�[����t���O�F0 ������Ȃ�
                                result = false;
                            }
                        // --- ADD m.suzuki 2011/10/21 ---------->>>>>
                        }
                        else
                        {
                            //�����񓚈ȊO��SCM�S�̐ݒ�.����`�[����t���O�ɂ�炸�A�������B
                            result = true;
                        }
                        // --- ADD m.suzuki 2011/10/21 ----------<<<<<
                    }
                    else
                    {
                        //���M�Ȃ��ꍇ�A�������
                        result = true;
                    }
                }
                else
                {
                    //PCCUOE�̏ꍇ
                    result = true;
                }
            }
            return result;
        }
        // zhouzy add 20110920 end

        // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811 begin
        /// <summary>
        /// ����������R�s�[����B
        /// �t�n�d�`�[��������˔���`�[�������
        /// </summary>
        /// <param name="uoeSlipPrintCndtn">�t�n�d�`�[�������</param>
        /// <returns>����`�[�������</returns>
        private SalesSlipPrintCndtn CopyToSalesSlipPrintCndtnFromUoe(UOESlipPrintCndtn uoeSlipPrintCndtn)
        {
            SalesSlipPrintCndtn salesCndtn = new SalesSlipPrintCndtn();
            salesCndtn.EnterpriseCode = uoeSlipPrintCndtn.EnterpriseCode;
            salesCndtn.ExtrData = uoeSlipPrintCndtn.ExtrData;
            // �`�[����pKeyList�C���X�^���X����
            List<SalesSlipPrintCndtn.SalesSlipKey> keyList = new List<SalesSlipPrintCndtn.SalesSlipKey>();
            Dictionary<string, bool> dic = new Dictionary<string, bool>();
            foreach (UoeSales uoeSales in uoeSlipPrintCndtn.UOESalesList)
            {
                // �`�[�ԍ����ݒ�͏��O����
                if (string.IsNullOrEmpty(uoeSales.salesSlipWork.SalesSlipNum)) continue;
                // �f�B�N�V���i���ŏd���`�F�b�N���ď��O����
                if (dic.ContainsKey(uoeSales.salesSlipWork.SalesSlipNum)) continue;

                // �`�[�L�[�ǉ�
                keyList.Add(new SalesSlipPrintCndtn.SalesSlipKey(uoeSales.salesSlipWork.AcptAnOdrStatus, uoeSales.salesSlipWork.SalesSlipNum));
                dic.Add(uoeSales.salesSlipWork.SalesSlipNum, true);
            }
            salesCndtn.SalesSlipKeyList = keyList;
            return salesCndtn;
        }
        // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811  end


        ///// <summary>
        ///// �A�N�Z�X�N���X�G���[�̕\��
        ///// </summary>
        ///// <param name="slipAcsStatus"></param>
        //private void ShowErrorMessageOfSlipAcs( SlipPrintAcs.SlipAcsStatus slipAcsStatus, int status )
        //{
        //    if ( _slipPrintAcs.SlipAcsState != SlipPrintAcs.SlipAcsStatus.Normal )
        //    {
        //        string message = string.Empty;

        //        switch ( _slipPrintAcs.SlipAcsState )
        //        {
        //            case SlipPrintAcs.SlipAcsStatus.Error_NoTerminalMg:
        //                message = "�[���ݒ肪���ݒ�ׁ̈A����ł��܂���ł����B";
        //                break;
        //            case SlipPrintAcs.SlipAcsStatus.Error_SearchSlip:
        //                message = "�`�[��񒊏o���ɃG���[�����������ׁA����ł��܂���ł����B";
        //                break;
        //        }

        //        TMsgDisp.Show(
        //            emErrorLevel.ERR_LEVEL_STOPDISP
        //            , this.ToString()
        //            , "�`�[���s"
        //            , ""
        //            , TMsgDisp.OPE_PRINT
        //            , message
        //            , status
        //            , null
        //            , MessageBoxButtons.OK
        //            , MessageBoxDefaultButton.Button1 );
        //    }
        //}

        /// <summary>
        /// �G���[�X�e�[�^�X�ݒ�i�A�N�Z�X�N���X�̃G���[ �� ����t�h�̃G���[�j
        /// </summary>
        /// <param name="slipPrintStatus"></param>
        /// <param name="slipAcsStatus"></param>
        private void SetErrorState(ref SlipPrintStatus slipPrintStatus, SlipPrintAcs.SlipAcsStatus slipAcsStatus)
        {
            switch (slipAcsStatus)
            {
                case SlipPrintAcs.SlipAcsStatus.Error_NoTerminalMg:
                    slipPrintStatus = SlipPrintStatus.Error_NoTerminalMg;
                    break;
                case SlipPrintAcs.SlipAcsStatus.Error_SearchSlip:
                    slipPrintStatus = SlipPrintStatus.Error_PrintSlip;
                    break;
            }
        }
        /// <summary>
        /// �G���[�X�e�[�^�X�ݒ�i�_�C�A���O�̃G���[ �� ����t�h�̃G���[�j
        /// </summary>
        /// <param name="slipPrintStatus"></param>
        /// <param name="slipPrintDialog"></param>
        private void SetErrorStateFromDialog(ref SlipPrintStatus slipPrintStatus, DCCMN02000UB slipPrintDialog)
        {
            switch (slipPrintDialog.SlipPrintDialogState)
            {
                case DCCMN02000UB.SlipPrintDialogStatus.Cancel:
                    slipPrintStatus = SlipPrintStatus.Cancel;
                    break;
                case DCCMN02000UB.SlipPrintDialogStatus.Error_CallPrint:
                    slipPrintStatus = SlipPrintStatus.Error_PrintSlip;
                    break;
                case DCCMN02000UB.SlipPrintDialogStatus.Error_InvalidPrinter:
                    slipPrintStatus = SlipPrintStatus.Error_InvalidPrinter;
                    break;
                case DCCMN02000UB.SlipPrintDialogStatus.Error_Initialize:
                    slipPrintStatus = SlipPrintStatus.Error_PrintSlipInit;
                    break;
            }
        }

        /// <summary>
        /// �G���[�\��
        /// </summary>
        /// <param name="slipPrintStatus"></param>
        private void ShowErrorMessage(SlipPrintStatus slipPrintStatus)
        {
            string message = string.Empty;

            switch (slipPrintStatus)
            {
                case SlipPrintStatus.Error_NoTerminalMg:
                    message = "�[���ݒ肪���ݒ�ׁ̈A����ł��܂���ł����B";
                    break;
                case SlipPrintStatus.Error_SearchSlip:
                    message = "�`�[��񒊏o���ɃG���[�����������ׁA����ł��܂���ł����B";
                    break;
                case SlipPrintStatus.Error_PrintSlip:
                    message = "�`�[����������ɃG���[�����������ׁA����ł��܂���ł����B";
                    break;
                case SlipPrintStatus.Error_PrintSlipInit:
                    message = "�`�[����������������ɃG���[�����������ׁA����ł��܂���ł����B";
                    break;
                case SlipPrintStatus.Error_InvalidPrinter:
                    message = "�v�����^�ݒ肪�s���ȈׁA����ł��܂���ł����B";
                    break;
                case SlipPrintStatus.Error_Cndtn_EnterpriseCode:
                    message = "�`�[����������s���ȈׁA����ł��܂���ł����B�i��ƃR�[�h�j";
                    break;
                case SlipPrintStatus.Error_Cndtn_SlipList:
                    message = "�`�[����������s���ȈׁA����ł��܂���ł����B�i�`�[���X�g�j";
                    break;
                case SlipPrintStatus.Error_Cndtn:
                    message = "�`�[����������s���ȈׁA����ł��܂���ł����B";
                    break;
                case SlipPrintStatus.BeforeExecute:
                case SlipPrintStatus.Cancel:
                case SlipPrintStatus.OK:
                default:
                    break;
            }

            if (message != string.Empty)
            {
                // 2009.07.16 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //TMsgDisp.Show(
                //    emErrorLevel.ERR_LEVEL_STOPDISP
                //    , this.ToString()
                //    , "�`�[���s"
                //    , ""
                //    , TMsgDisp.OPE_PRINT
                //    , message
                //    , 0
                //    , null
                //    , MessageBoxButtons.OK
                //    , MessageBoxDefaultButton.Button1);

                if (this._isService == 0)
                {
                    TMsgDisp.Show(
                        emErrorLevel.ERR_LEVEL_STOPDISP
                        , this.ToString()
                        , "�`�[���s"
                        , ""
                        , TMsgDisp.OPE_PRINT
                        , message
                        , 0
                        , null
                        , MessageBoxButtons.OK
                        , MessageBoxDefaultButton.Button1);
                }
                // 2009.07.16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<                
            }
        }

        /// <summary>
        /// �d���`�[�@����m�F�t�h�Ăяo��
        /// </summary>
        /// <param name="iSlipPrintCndtn"></param>
        /// <param name="printWithoutDialog"></param>
        private void CallStockSlipPrint(StockSlipPrintCndtn iSlipPrintCndtn, bool printWithoutDialog)
        {
            //----------------------------------------------------------------
            // ��2008.06.02���_�Ŏd���ԕi�`�[����͖������B
            // �@��������ꍇ�͐�p�̃����[�g�ƁA���DLL�̒ǉ����K�v�B
            //----------------------------------------------------------------
        }
        /// <summary>
        /// �݌Ɉړ��`�[�@����m�F�t�h�Ăяo��
        /// </summary>
        /// <param name="iSlipPrintCndtn"></param>
        /// <param name="printWithoutDialog"></param>
        private void CallStockMoveSlipPrint(StockMoveSlipPrintCndtn iSlipPrintCndtn, bool printWithoutDialog)
        {
            if (iSlipPrintCndtn.StockMoveSlipKeyList == null || iSlipPrintCndtn.StockMoveSlipKeyList.Count == 0)
            {
                _slipPrintState = SlipPrintStatus.Error_Cndtn_SlipList;
                return;
            }

            SFCMN00299CA progressDialog = null;
            if (!printWithoutDialog)
            {
                // �������_�C�A���O�\���@����
                progressDialog = new SFCMN00299CA();
                progressDialog.Title = "�`�[�������";
                progressDialog.Message = "���݁A�`�[����������ł��B";
                progressDialog.Show();
            }

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            List<List<ArrayList>> printDataList = null;

            try
            {
                // ���o�������ڍs
                FrePStockMoveSlipParaWork paraWork = new FrePStockMoveSlipParaWork();
                paraWork.EnterpriseCode = iSlipPrintCndtn.EnterpriseCode;
                paraWork.FrePStockMoveSlipParaKeyList = new List<FrePStockMoveSlipParaWork.FrePStockMoveSlipParaKey>();
                for (int index = 0; index < iSlipPrintCndtn.StockMoveSlipKeyList.Count; index++)
                {
                    StockMoveSlipPrintCndtn.StockMoveSlipKey key = iSlipPrintCndtn.StockMoveSlipKeyList[index];
                    paraWork.FrePStockMoveSlipParaKeyList.Add(new FrePStockMoveSlipParaWork.FrePStockMoveSlipParaKey(key.StockMoveFormal, key.StockMoveSlipNo));
                }

                // �A�N�Z�X�N���XSearch�Ăяo��
                status = _slipPrintAcs.InitialSearchFrePStockMoveSlip(paraWork, ref printDataList);
            }
            finally
            {
                if (!printWithoutDialog)
                {
                    // �������_�C�A���O�I�� ����
                    if (progressDialog != null)
                    {
                        progressDialog.Close();
                    }
                }
            }
            if (status == 0)
            {
                foreach (List<ArrayList> printData in printDataList)
                {
                    // �`�[����_�C�A���O�Ăяo��
                    DCCMN02000UB slipPrintDialog = new DCCMN02000UB(_slipPrintAcs);
                    slipPrintDialog.ShowDialog(iSlipPrintCndtn, printData, printWithoutDialog);

                    SetErrorStateFromDialog(ref _slipPrintState, slipPrintDialog);
                }
            }
            else
            {
                //ShowErrorMessageOfSlipAcs( _slipPrintAcs.SlipAcsState, status );
                SetErrorState(ref _slipPrintState, _slipPrintAcs.SlipAcsState);
            }
        }
        /// <summary>
        /// ���Ϗ��@����m�F�t�h�Ăяo��
        /// </summary>
        /// <param name="iSlipPrintCndtn"></param>
        /// <param name="printWithoutDialog"></param>
        private void CallEstFmPrint(EstFmPrintCndtn iSlipPrintCndtn, bool printWithoutDialog)
        {
            if (iSlipPrintCndtn.EstFmUnitDataList == null || iSlipPrintCndtn.EstFmUnitDataList.Count == 0)
            {
                _slipPrintState = SlipPrintStatus.Error_Cndtn_SlipList;
                return;
            }

            SFCMN00299CA progressDialog = null;
            if (!printWithoutDialog)
            {
                // �������_�C�A���O�\���@����
                progressDialog = new SFCMN00299CA();
                progressDialog.Title = "���Ϗ��������";
                progressDialog.Message = "���݁A���Ϗ�����������ł��B";
                progressDialog.Show();
            }

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            List<ArrayList> extData = null;
            List<ArrayList> printData = null;

            try
            {
                // ���o�������ڍs
                FrePEstFmParaWork paraWork = new FrePEstFmParaWork();
                paraWork.EnterpriseCode = iSlipPrintCndtn.EnterpriseCode;
                if (iSlipPrintCndtn.EstFmUnitDataList != null && iSlipPrintCndtn.EstFmUnitDataList.Count > 0 && iSlipPrintCndtn.EstFmUnitDataList[0].FrePEstFmHead != null)
                {
                    // ���_�R�[�h�Z�b�g
                    paraWork.SectionCode = iSlipPrintCndtn.EstFmUnitDataList[0].FrePEstFmHead.SALESSLIPRF_SECTIONCODERF;
                    // �A�N�Z�X�N���XSearch�Ăяo��
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 DEL
                    //status = _slipPrintAcs.InitialSearchFrePEstFm( paraWork, ref extData );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 ADD
                    status = _slipPrintAcs.InitialSearchFrePEstFm(paraWork, iSlipPrintCndtn.EstFmUnitDataList[0].FrePEstFmHead.SALESSLIPRF_CUSTOMERCODERF, ref extData);
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 ADD

                    if (status == 0)
                    {
                        // �����[�g�擾����������(�ꕔ)���擾
                        FrePSalesSlipWork frePSalesSlipWork = null;
                        if (extData != null && extData.Count > 0)
                        {
                            foreach (ArrayList list in extData)
                            {
                                foreach (object extObj in list)
                                {
                                    if (extObj is FrePSalesSlipWork)
                                    {
                                        frePSalesSlipWork = (FrePSalesSlipWork)extObj;
                                        break;
                                    }
                                }
                                if (frePSalesSlipWork != null) break;
                            }
                        }

                        if (frePSalesSlipWork != null)
                        {
                            // �e���Ϗ��f�[�^�ɔ��f
                            foreach (EstFmPrintCndtn.EstFmUnitData unitData in iSlipPrintCndtn.EstFmUnitDataList)
                            {
                                // �`�[����p���[�h�c�Z�b�g
                                unitData.FrePEstFmHead.HADD_SLIPPRTSETPAPERIDRF = frePSalesSlipWork.HADD_SLIPPRTSETPAPERIDRF;
                                // �v�����^�Ǘ����Z�b�g
                                unitData.FrePEstFmHead.HADD_PRINTERMNGNORF = frePSalesSlipWork.HADD_PRINTERMNGNORF;

                                // ���_�E���Ж��́E�摜�E���Џ����R�s�[
                                # region [�R�s�[]
                                unitData.FrePEstFmHead.COMPANYNMRF_COMPANYPRRF = frePSalesSlipWork.COMPANYNMRF_COMPANYPRRF;
                                unitData.FrePEstFmHead.COMPANYNMRF_COMPANYNAME1RF = frePSalesSlipWork.COMPANYNMRF_COMPANYNAME1RF;
                                unitData.FrePEstFmHead.COMPANYNMRF_COMPANYNAME2RF = frePSalesSlipWork.COMPANYNMRF_COMPANYNAME2RF;
                                unitData.FrePEstFmHead.COMPANYNMRF_POSTNORF = frePSalesSlipWork.COMPANYNMRF_POSTNORF;
                                unitData.FrePEstFmHead.COMPANYNMRF_ADDRESS1RF = frePSalesSlipWork.COMPANYNMRF_ADDRESS1RF;
                                unitData.FrePEstFmHead.COMPANYNMRF_ADDRESS3RF = frePSalesSlipWork.COMPANYNMRF_ADDRESS3RF;
                                unitData.FrePEstFmHead.COMPANYNMRF_ADDRESS4RF = frePSalesSlipWork.COMPANYNMRF_ADDRESS4RF;
                                unitData.FrePEstFmHead.COMPANYNMRF_COMPANYTELNO1RF = frePSalesSlipWork.COMPANYNMRF_COMPANYTELNO1RF;
                                unitData.FrePEstFmHead.COMPANYNMRF_COMPANYTELNO2RF = frePSalesSlipWork.COMPANYNMRF_COMPANYTELNO2RF;
                                unitData.FrePEstFmHead.COMPANYNMRF_COMPANYTELNO3RF = frePSalesSlipWork.COMPANYNMRF_COMPANYTELNO3RF;
                                unitData.FrePEstFmHead.COMPANYNMRF_COMPANYTELTITLE1RF = frePSalesSlipWork.COMPANYNMRF_COMPANYTELTITLE1RF;
                                unitData.FrePEstFmHead.COMPANYNMRF_COMPANYTELTITLE2RF = frePSalesSlipWork.COMPANYNMRF_COMPANYTELTITLE2RF;
                                unitData.FrePEstFmHead.COMPANYNMRF_COMPANYTELTITLE3RF = frePSalesSlipWork.COMPANYNMRF_COMPANYTELTITLE3RF;
                                unitData.FrePEstFmHead.COMPANYNMRF_TRANSFERGUIDANCERF = frePSalesSlipWork.COMPANYNMRF_TRANSFERGUIDANCERF;
                                unitData.FrePEstFmHead.COMPANYNMRF_ACCOUNTNOINFO1RF = frePSalesSlipWork.COMPANYNMRF_ACCOUNTNOINFO1RF;
                                unitData.FrePEstFmHead.COMPANYNMRF_ACCOUNTNOINFO2RF = frePSalesSlipWork.COMPANYNMRF_ACCOUNTNOINFO2RF;
                                unitData.FrePEstFmHead.COMPANYNMRF_ACCOUNTNOINFO3RF = frePSalesSlipWork.COMPANYNMRF_ACCOUNTNOINFO3RF;
                                unitData.FrePEstFmHead.COMPANYNMRF_COMPANYSETNOTE1RF = frePSalesSlipWork.COMPANYNMRF_COMPANYSETNOTE1RF;
                                unitData.FrePEstFmHead.COMPANYNMRF_COMPANYSETNOTE2RF = frePSalesSlipWork.COMPANYNMRF_COMPANYSETNOTE2RF;
                                unitData.FrePEstFmHead.COMPANYNMRF_COMPANYURLRF = frePSalesSlipWork.COMPANYNMRF_COMPANYURLRF;
                                unitData.FrePEstFmHead.COMPANYNMRF_COMPANYPRSENTENCE2RF = frePSalesSlipWork.COMPANYNMRF_COMPANYPRSENTENCE2RF;
                                unitData.FrePEstFmHead.COMPANYNMRF_IMAGECOMMENTFORPRT1RF = frePSalesSlipWork.COMPANYNMRF_IMAGECOMMENTFORPRT1RF;
                                unitData.FrePEstFmHead.COMPANYNMRF_IMAGECOMMENTFORPRT2RF = frePSalesSlipWork.COMPANYNMRF_IMAGECOMMENTFORPRT2RF;
                                unitData.FrePEstFmHead.IMAGEINFORF_IMAGEINFODATARF = frePSalesSlipWork.IMAGEINFORF_IMAGEINFODATARF;
                                unitData.FrePEstFmHead.COMPANYINFRF_COMPANYNAME1RF = frePSalesSlipWork.COMPANYINFRF_COMPANYNAME1RF;
                                unitData.FrePEstFmHead.COMPANYINFRF_COMPANYNAME2RF = frePSalesSlipWork.COMPANYINFRF_COMPANYNAME2RF;
                                unitData.FrePEstFmHead.COMPANYINFRF_POSTNORF = frePSalesSlipWork.COMPANYINFRF_POSTNORF;
                                unitData.FrePEstFmHead.COMPANYINFRF_ADDRESS1RF = frePSalesSlipWork.COMPANYINFRF_ADDRESS1RF;
                                unitData.FrePEstFmHead.COMPANYINFRF_ADDRESS3RF = frePSalesSlipWork.COMPANYINFRF_ADDRESS3RF;
                                unitData.FrePEstFmHead.COMPANYINFRF_ADDRESS4RF = frePSalesSlipWork.COMPANYINFRF_ADDRESS4RF;
                                unitData.FrePEstFmHead.COMPANYINFRF_COMPANYTELNO1RF = frePSalesSlipWork.COMPANYINFRF_COMPANYTELNO1RF;
                                unitData.FrePEstFmHead.COMPANYINFRF_COMPANYTELNO2RF = frePSalesSlipWork.COMPANYINFRF_COMPANYTELNO2RF;
                                unitData.FrePEstFmHead.COMPANYINFRF_COMPANYTELNO3RF = frePSalesSlipWork.COMPANYINFRF_COMPANYTELNO3RF;
                                unitData.FrePEstFmHead.COMPANYINFRF_COMPANYTELTITLE1RF = frePSalesSlipWork.COMPANYINFRF_COMPANYTELTITLE1RF;
                                unitData.FrePEstFmHead.COMPANYINFRF_COMPANYTELTITLE2RF = frePSalesSlipWork.COMPANYINFRF_COMPANYTELTITLE2RF;
                                unitData.FrePEstFmHead.COMPANYINFRF_COMPANYTELTITLE3RF = frePSalesSlipWork.COMPANYINFRF_COMPANYTELTITLE3RF;
                                # endregion

                                //------------------------------------------------
                                // ������̐���
                                //------------------------------------------------
                                if (printData == null)
                                {
                                    printData = new List<ArrayList>();
                                }
                                ArrayList list = new ArrayList();
                                list.Add(unitData.FrePEstFmHead);         // ���̈�������ɍ��킹���[0]�̓w�b�_�ɂ��Ă���
                                list.Add(unitData.FrePEstFmDetailList);   // ���̈�������ɍ��킹���[1]�͖��׃��X�g�ɂ��Ă���
                                list.Add(CreateExtraData(unitData));    // [2]�ɕs����������
                                printData.Add(list);
                            }
                        }
                    }
                }
            }
            finally
            {
                if (!printWithoutDialog)
                {
                    // �������_�C�A���O�I�� ����
                    if (progressDialog != null)
                    {
                        progressDialog.Close();
                    }
                }
            }
            if (status == 0)
            {
                // �`�[����_�C�A���O�Ăяo��
                DCCMN02000UB slipPrintDialog = new DCCMN02000UB(_slipPrintAcs);
                slipPrintDialog.ShowDialog(iSlipPrintCndtn, printData, printWithoutDialog);

                SetErrorStateFromDialog(ref _slipPrintState, slipPrintDialog);
            }
            else
            {
                //ShowErrorMessageOfSlipAcs( _slipPrintAcs.SlipAcsState, status );
                SetErrorState(ref _slipPrintState, _slipPrintAcs.SlipAcsState);
            }
        }
        /// <summary>
        /// ���Ϗ��@�⑫���ݒ�
        /// </summary>
        /// <param name="unitData"></param>
        /// <returns></returns>
        private EstFmUnitExtraData CreateExtraData(EstFmPrintCndtn.EstFmUnitData unitData)
        {
            EstFmUnitExtraData extraData = new EstFmUnitExtraData();
            extraData.PrintCount = unitData.PrintCount;

            return extraData;
        }
        /// <summary>
        /// UOE�`�[�@����m�F�t�h�Ăяo��
        /// </summary>
        /// <param name="iSlipPrintCndtn"></param>
        /// <param name="printWithoutDialog"></param>
        private void CallUOESlipPrint(UOESlipPrintCndtn iSlipPrintCndtn, bool printWithoutDialog)
        {
            if (iSlipPrintCndtn.UOESalesList == null || iSlipPrintCndtn.UOESalesList.Count == 0)
            {
                _slipPrintState = SlipPrintStatus.Error_Cndtn_SlipList;
                return;
            }

            SFCMN00299CA progressDialog = null;
            if (!printWithoutDialog)
            {
                // �������_�C�A���O�\���@����
                progressDialog = new SFCMN00299CA();
                progressDialog.Title = "�`�[�������";
                progressDialog.Message = "���݁A�`�[����������ł��B";
                progressDialog.Show();
            }

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            List<List<ArrayList>> printDataList = null;

            try
            {
                // ���o�������ڍs
                FrePUOESlipParaWork paraWork = new FrePUOESlipParaWork();
                paraWork.EnterpriseCode = iSlipPrintCndtn.EnterpriseCode;
                paraWork.UOESlipParaUnitList = new List<FrePUOESlipParaWork.FrePUOESlipParaUnitWork>();

                for (int index = 0; index < iSlipPrintCndtn.UOESalesList.Count; index++)
                {
                    // �P�`�[���������[�g�p�����[�^�ɕϊ�
                    paraWork.UOESlipParaUnitList.Add(CopyToFrePUOESlipParaUnitWorkFromUOESales(iSlipPrintCndtn.UOESalesList[index]));
                }

                // �A�N�Z�X�N���XSearch�Ăяo��
                status = _slipPrintAcs.InitialSearchFrePUOESlip(paraWork, ref printDataList, iSlipPrintCndtn.UOESalesList);
            }
            finally
            {
                if (!printWithoutDialog)
                {
                    // �������_�C�A���O�I�� ����
                    if (progressDialog != null)
                    {
                        progressDialog.Close();
                    }
                }
            }
            if (status == 0)
            {
                foreach (List<ArrayList> printData in printDataList)
                {
                    // �`�[����_�C�A���O�Ăяo��
                    DCCMN02000UB slipPrintDialog = new DCCMN02000UB(_slipPrintAcs);
                    slipPrintDialog.ShowDialog(iSlipPrintCndtn, printData, printWithoutDialog);

                    SetErrorStateFromDialog(ref _slipPrintState, slipPrintDialog);
                }
            }
            else
            {
                //ShowErrorMessageOfSlipAcs( _slipPrintAcs.SlipAcsState, status );
                SetErrorState(ref _slipPrintState, _slipPrintAcs.SlipAcsState);
            }
        }
        /// <summary>
        /// UOE�`�[�p ���o�����ڍs����
        /// </summary>
        /// <param name="uoeSales"></param>
        /// <returns></returns>
        private FrePUOESlipParaWork.FrePUOESlipParaUnitWork CopyToFrePUOESlipParaUnitWorkFromUOESales(UoeSales uoeSales)
        {
            FrePUOESlipParaWork.FrePUOESlipParaUnitWork unitWork = new FrePUOESlipParaWork.FrePUOESlipParaUnitWork();

            // �`�[�w�b�_
            unitWork.SlipWork = SlipPrintAcs.CopyToFrePSalesSlipWorkFromSalesSlip(uoeSales.salesSlipWork);

            // ���׃��X�g
            unitWork.DetailWorkList = new List<FrePSalesDetailWork>();
            for (int index = 0; index < uoeSales.uoeSalesDetailList.Count; index++)
            {
                unitWork.DetailWorkList.Add(SlipPrintAcs.CopyToFrePSalesDetailWorkFromSalesDetail(uoeSales.uoeSalesDetailList[index].salesDetailWork));
            }

            return unitWork;
        }
        # endregion

        # region [�`�[����X�e�[�^�X]
        /// <summary>
        /// �`�[����X�e�[�^�X
        /// </summary>
        public enum SlipPrintStatus
        {
            /// <summary>�����s</summary>
            BeforeExecute = 0,
            /// <summary>�L�����Z����</summary>
            Cancel = 1,
            /// <summary>����I����</summary>
            OK = 2,
            /// <summary>�i�G���[�j�[���Ǘ��ݒ�Ȃ�</summary>
            Error_NoTerminalMg = 11,
            /// <summary>�i�G���[�j�`�[��񒊏o</summary>
            Error_SearchSlip = 12,
            /// <summary>�i�G���[�j�`�[���</summary>
            Error_PrintSlip = 13,
            /// <summary>�i�G���[�j�`�[���������������</summary>
            Error_PrintSlipInit = 14,
            /// <summary>�i�G���[�j�v�����^�s��</summary>
            Error_InvalidPrinter = 15,
            /// <summary>�i�����G���[�j��ƃR�[�h</summary>
            Error_Cndtn_EnterpriseCode = 21,
            /// <summary>�i�����G���[�j�`�[���X�g</summary>
            Error_Cndtn_SlipList = 22,
            /// <summary>�i�����G���[�j�S��</summary>
            Error_Cndtn = 23,
        }
        # endregion

        // 2009.07.16 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// ���O�o��(DEBUG)����
        /// </summary>
        /// <param name="pMsg"></param>
        public static void LogWrite(string pMsg)
        {
#if DEBUG
            //System.IO.FileStream _fs;										// �t�@�C���X�g���[��
            //System.IO.StreamWriter _sw;										// �X�g���[��writer
            //_fs = new FileStream("DCCMN02000U.Log", FileMode.Append, FileAccess.Write, FileShare.Write);
            //_sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));
            //DateTime edt = DateTime.Now;
            ////yyyy/MM/dd hh:mm:ss
            //_sw.WriteLine(string.Format("{0,-19} {1,-5} ==> {2}", edt, edt.Millisecond, pMsg));
            //if (_sw != null)
            //    _sw.Close();
            //if (_fs != null)
            //    _fs.Close();
#endif
        }
        // 2009.07.16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<                

    }
}

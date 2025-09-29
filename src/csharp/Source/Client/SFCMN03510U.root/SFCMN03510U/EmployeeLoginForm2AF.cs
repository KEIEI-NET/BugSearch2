using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Library.Runtime.InteropServices;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// public class name:   EmployeeLoginForm2AF
    /// <summary>
    ///                      �]�ƈ����O�C�����(felica�Ή���)
    ///                      SFCMN00655U���x�[�X�Ƃ��č쐬
    /// </summary>
    /// <remarks>
    /// <br>note             :   �]�ƈ����O�C�����</br>
    /// <br>Programmer       :   23002�@���@�k��</br>
    /// <br>Date             :   2008.11.13</br>
    /// <br>Update Note      :    
    ///                      :   2009.01.26 ���@�k��
    ///                      :   �E����̓��O�C����A�|�[�����O���~�܂�Ȃ����ۂ̏C��</br>
    /// <br></br>
    /// <br>Update Note: 2010.02.18  22018 ��� ���b</br>
    /// <br>           : PM.NS�Ή�</br>
    /// <br>           : �@�ENetAdvantage�o�[�W�����A�b�v�Ή�</br>
    /// <br>           : �@�E�A�C�R���ύX(SF��NS)</br>
    /// </remarks>
    public partial class EmployeeLogin2FormAF :Form
    {
        #region �v���C�x�[�g�����o
        //��ƃ��O�C�����i�[�p
        private CompanyAuthInfoWork _companyAuthInfoWork = null;
        //�]�ƈ����O�C���p�����[�^���i�[�p
        private EmployeeAuthInfoWork _paraEmployeeAuthInfoWork = null;
        //�]�ƈ����O�C�����ʏ��i�[�p
        private EmployeeAuthInfoWork _employeeAuthInfoWork = null;
        //�]�ƈ����O�C�������[�g�I�u�W�F�N�g�C���^�[�t�F�[�X
        private IEmployeeLogin2DB _iEmployeeLogin2DB = null;

        //�A�N�Z�X�`�P�b�g�p�����[�^�i�[�p
        private string _accessTicket = null;
        //�]�ƈ����O�C���h���C��������
        private string _domainStr = null;
        //�I�����C���t���O
        private bool _onlineFlag = false;

        //�v���O����ID
        private const string pgId = "SFCMN03510U";
        
        //Felica�Ή��\���p�^�C�}�[
        private Timer timer_FelicaInfo;
        //�t�F���J�A�N�Z�X�N���X
        static private FelicaAcs _felicaAcs = null;
        //�t�F���J�`�F�b�N�Ԋu
        private int felicaInterval = 400;
        //�t�F���J�`�F�b�N�� 0������
        private int felicaRetry = 0;

        
        //���O�C�������r���I�u�W�F�N�g
        private object _loginObject = new object();
        #endregion

        #region �R���X�g���N�^
        /// <summary>
        /// �]�ƈ����O�C����ʃN���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���������FOwner�ݒ�</br>
        /// <br>Programmer : 23002 ���@�k��</br>
        /// <br>Date       : 2008.11.13</br>
        /// </remarks>		
        public EmployeeLogin2FormAF()
        {
            InitializeComponent();
        }
        #endregion

        #region �p�u���b�N���\�b�h
        /// <summary>
        /// �]�ƈ����O�C���J�n
        /// </summary>
        /// <param name="owner">���O�C�����Owner</param>
        /// <param name="accessTicket">�A�N�Z�X�`�P�b�g</param>
        /// <param name="domainStr">�]�ƈ����O�C���h���C��������</param>
        /// <param name="companyAuthInfoWork">��ƃ��O�C�����</param>
        /// <param name="employeeAuthInfoWork">�]�ƈ����O�C�����</param>
        /// <returns>STATUS</returns>
        public int ShowDialog(IWin32Window owner, string accessTicket, string domainStr, CompanyAuthInfoWork companyAuthInfoWork, ref EmployeeAuthInfoWork employeeAuthInfoWork)
        {
            //�߂�l���Y�������ŏ�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            //�]�ƈ����O�C�����p�����[�^����I�����C���t���O����
            if( employeeAuthInfoWork == null )
                _onlineFlag = true;
            else
                _onlineFlag = false;

            //��ƃ��O�C�����擾
            _companyAuthInfoWork = companyAuthInfoWork;
            //�p�����[�^�]�ƈ����O�C���N���X������
            _paraEmployeeAuthInfoWork = employeeAuthInfoWork;

            if( accessTicket == null || accessTicket == "" || companyAuthInfoWork == null || companyAuthInfoWork.EnterpriseInfoWork == null )
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, pgId, "��ƔF�؂���Ă��Ȃ����A��ƔF�؂������ɂȂ��Ă��܂��B�ēx��ƔF�؂��s���Ă��������B", 0, MessageBoxButtons.OK);
                return status;
            }

            //���[�N�N���X������
            _employeeAuthInfoWork = null;

            //�]�ƈ����O�C���C���^�[�t�F�[�X������
            _iEmployeeLogin2DB = null;

            //�A�N�Z�X�`�P�b�g�ۑ�
            _accessTicket = accessTicket;
            //�h���C��������ۑ�
            _domainStr = domainStr;

            //�X�e�[�^�X�o�[�̃��b�Z�[�W���Z�b�g���܂��B
            ultraStatusBar_EmployeeLogin.Panels["Info"].Text = "�J�[�h�����[�_�[�ɂ��������A���O�C��������͂��ĉ�����";
            ultraStatusBar_EmployeeLogin.Panels["Info"].Enabled = true;

            //�t�F���J�|�[�����O�X�g�b�v�i�O�̂��߁j
            FelicaStopPolling();

            //Felica�A�N�Z�X�N���X������
            //if(_onlineFlag && _felicaAcs == null )
            if( _onlineFlag )
            {
                _felicaAcs = new FelicaAcs();

                // �t�F���J����������
                if( _felicaAcs.InitializeLibrary() )
                {
                    // �R�[���o�b�N�f���Q�[�g�ɓo�^
                    _felicaAcs.CallBackDelegate = new FelicaAcs.PollingCallBackDelegate(PollingSuccessCallBack);

                    // �t�F���J���[�_�[�I�[�v������
                    if( !_felicaAcs.OpenReaderWriterAuto() )
                    {
                        FelicaDispose();
                        ultraStatusBar_EmployeeLogin.Panels["Info"].Text = "�]�ƈ����O�C��������͂��ĉ�����";
                    }
                }
                else
                {
                    FelicaDispose();
                    ultraStatusBar_EmployeeLogin.Panels["Info"].Text = "�]�ƈ����O�C��������͂��ĉ�����";
                }
            }


            //��ʕ\��
            this.ShowDialog(owner);

            //��ƁE�]�ƈ����O�C����񂪂���Ύ擾�߂�l��߂�
            if( _employeeAuthInfoWork != null )
            {
                //���O�C�����ݒ�
                employeeAuthInfoWork = _employeeAuthInfoWork;
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            return status;
        }
        #endregion

        #region �v���C�x�[�g���\�b�h
        /// <summary>
        /// �]�ƈ����O�C�������i���s���j
        /// </summary>
        /// <param name="felicaLogin"></param>
        /// <returns></returns>
        private bool LoginProc(string loginID, string loginPassword, bool felicaMode)
        {
            bool result = false;
            //�����O�C�����擾
            //timer_FelicaInfo.Stop();
            FelicaStopPolling();
            ultraStatusBar_EmployeeLogin.Panels["Info"].Enabled = true;
            ultraStatusBar_EmployeeLogin.Panels["Info"].Text = "���O�C��������...";
            ultraStatusBar_EmployeeLogin.Refresh();
            ultraStatusBar_EmployeeLogin.Update();

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            object retEmpObj = null;
            string retMsg = "";

            //�I�����C����
            if( _onlineFlag )
            {
                if ( _iEmployeeLogin2DB == null )
                    _iEmployeeLogin2DB = MediationEmployeeLogin2DB.GetEmployeeLogin2DB(_domainStr);
                //���͓��e�ݒ�
                object paraCmpObj = (object)_companyAuthInfoWork;
                status = _iEmployeeLogin2DB.Login(_accessTicket, loginID.Trim(), loginPassword.Trim(), felicaMode, ref paraCmpObj, out retEmpObj, out retMsg);
            }
            //�I�t���C����
            else
            {
                if( _paraEmployeeAuthInfoWork.EmployeeWork.LoginPassword == loginPassword.Trim() )
                {
                    retEmpObj = _paraEmployeeAuthInfoWork;
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    retMsg = "";
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                    retMsg = "�p�X���[�h���قȂ�܂��B�ēx���͂��Ă��������BCaps��On/Off���m�F���Ă��������B";
                }
            }

            if( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                //���߂�l�ݒ�
                _employeeAuthInfoWork = retEmpObj as EmployeeAuthInfoWork;
                if( _employeeAuthInfoWork == null )
                {
                    TMsgDisp.Show(this.Owner, emErrorLevel.ERR_LEVEL_INFO, pgId, "�]�ƈ����O�C���F�،��ʂ��擾�ł��܂���B�ēx���O�C�����Ă�������", 0, MessageBoxButtons.OK);
                }
                else
                {
                    ////����ʏI��
                    //this.Close();
                    //return;
                    result = true;
                    return result;
                }
            }
            else if( status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND )
            {
                TMsgDisp.Show(this.Owner, emErrorLevel.ERR_LEVEL_INFO, pgId, retMsg, 0, MessageBoxButtons.OK);
                tEdit_LoginId.Text = "";
                tEdit_LoginPassword.Text = "";
                tEdit_LoginId.Focus();
            }
            else if( status == (int)ConstantManagement.DB_Status.ctDB_EOF )
            {
                TMsgDisp.Show(this.Owner, emErrorLevel.ERR_LEVEL_INFO, pgId, retMsg, 0, MessageBoxButtons.OK);
                tEdit_LoginPassword.Text = "";
                tEdit_LoginPassword.Focus();
            }
            else if( status == (int)ConstantManagement.DB_Status.ctDB_ERROR )
            {
                if( retMsg == null || retMsg == "" )
                {
                    TMsgDisp.Show(this.Owner, emErrorLevel.ERR_LEVEL_STOPDISP, pgId, "�]�ƈ��F�؃T�[�o�[�ŃG���[���������܂����B�F�؏o���܂���B", 0, MessageBoxButtons.OK);
                }
                else
                {
                    TMsgDisp.Show(this.Owner, emErrorLevel.ERR_LEVEL_STOPDISP, pgId, string.Format("{0}[{1}]", "�]�ƈ��F�؃T�[�o�[�ŃG���[���������܂����B", retMsg), 0, MessageBoxButtons.OK);
                }
            }

            if( _felicaAcs != null)
            {
                FelicaStartPolling();
                ultraStatusBar_EmployeeLogin.Panels["Info"].Text = "�J�[�h�����[�_�[�ɂ��������A���O�C��������͂��ĉ�����";
            }
            else
            {
                ultraStatusBar_EmployeeLogin.Panels["Info"].Text = "�]�ƈ����O�C��������͂��ĉ�����";
            }
            
           
            return result;
        }
        #endregion

        #region �R���g���[���C�x���g
        /// <summary>
        /// �t�H�[�J�X�R���g���[������
        /// </summary>
        /// <param name="sender">�C�x���g�����I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���e</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            //�C�x���g���e/�ړ����R���g���[����������ΏI��
            if( e == null || e.PrevCtrl == null )
                return;

            int prevTag = System.Convert.ToInt32(e.PrevCtrl.Tag);
            switch( prevTag )
            {
                case 1:
                    if( e.Key == System.Windows.Forms.Keys.Return || e.Key == System.Windows.Forms.Keys.Tab )
                        e.NextCtrl = tEdit_LoginPassword;
                    break;
                case 2:
                    if( e.Key == System.Windows.Forms.Keys.Return || e.Key == System.Windows.Forms.Keys.Tab )
                        e.NextCtrl = ultraButton_OK;
                    break;
                case 100:
                    if( e.Key == System.Windows.Forms.Keys.Tab )
                        e.NextCtrl = ultraButton_CANCEL;
                    else if( e.Key == System.Windows.Forms.Keys.Return )
                    {
                        e.NextCtrl = e.PrevCtrl;
                        ultraButton_OK_Click(null, null);//OK�{�^������
                    }
                    break;
                case 200:
                    if( e.Key == System.Windows.Forms.Keys.Tab )
                        e.NextCtrl = tEdit_LoginId;
                    else if( e.Key == System.Windows.Forms.Keys.Return )
                    {
                        e.NextCtrl = e.PrevCtrl;
                        ultraButton_CANCEL_Click(null, null);//OK�{�^������
                    }
                    break;
            }


        }

        /// <summary>
        /// CANCEL�{�^��Click�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�����I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���e</param>
        private void ultraButton_CANCEL_Click(object sender, System.EventArgs e)
        {
            //��ʏI��
            this.Close();
        }

        /// <summary>
        /// OK�{�^��Click�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�����I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���e</param>
        private void ultraButton_OK_Click(object sender, System.EventArgs e)
        {
            FelicaStopPolling();

            //�����O�C��ID�����̓`�F�b�N
            if( tEdit_LoginId.Text.Trim() == "" )
            {
                TMsgDisp.Show(this.Owner, emErrorLevel.ERR_LEVEL_INFO, pgId, "���O�C��ID����͂��Ă�������", 0, MessageBoxButtons.OK);
                tEdit_LoginId.Focus();

                // >>>> 2009.01.26 ��� Add �|�[�����O���~�܂�Ȃ����ۑΉ� >>>>>>>>>>>>>>>>>>>>>>>>> 
                FelicaStartPolling();
                // <<<< 2009.01.26 ��� Add �|�[�����O���~�܂�Ȃ����ۑΉ� <<<<<<<<<<<<<<<<<<<<<<<<<
            }
            else
            {
                //���O�C��������Felica�Əd�Ȃ�Ȃ��悤�ɔr��
                lock( _loginObject )
                {
                    //�]�ƈ����O�C������
                    if( LoginProc(tEdit_LoginId.Text, tEdit_LoginPassword.Text, false) )
                    {
                        this.Close();
                    }
                    else
                    {
                        // >>>> 2009.01.26 ��� Add �|�[�����O���~�܂�Ȃ����ۑΉ� >>>>>>>>>>>>>>>>>>>>>>>>>
                        FelicaStartPolling();
                        // <<<< 2009.01.26 ��� Add �|�[�����O���~�܂�Ȃ����ۑΉ� <<<<<<<<<<<<<<<<<<<<<<<<<
                    }
                }
            }
            // >>>> 2009.01.26 ��� Del �|�[�����O���~�܂�Ȃ����ۑΉ� >>>>>>>>>>>>>>>>>>>>>>>>>
            //FelicaStartPolling();
            // <<<< 2009.01.26 ��� Del �|�[�����O���~�܂�Ȃ����ۑΉ� <<<<<<<<<<<<<<<<<<<<<<<<<
        }
        

        /// <summary>
        /// �^�C�}�[�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_FelicaInfo_Tick(object sender, EventArgs e)
        {
            ultraStatusBar_EmployeeLogin.Panels["Info"].Enabled = !ultraStatusBar_EmployeeLogin.Panels["Info"].Enabled;

            // --- ADD m.suzuki 2010/02/18 ---------->>>>>
            // �܂�Ɂu���[�_�[����������Ă��Ȃ��v��ԂɂȂ�̂ŁA
            // �ēx�A�������ƃI�[�v�����s���ĕ�������B
            if ( _felicaAcs != null )
            {
                if ( _felicaAcs.FelicaLastErrType == FeliCaErrorType.FELICA_LIBRARY_NOT_INITIALIZED ||
                    _felicaAcs.FelicaLastErrType == FeliCaErrorType.FELICA_READER_WRITER_NOT_OPENED )
                {
                    // �t�F���J����������
                    if ( _felicaAcs.InitializeLibrary() )
                    {
                        // �t�F���J���[�_�[�I�[�v������
                        if ( !_felicaAcs.OpenReaderWriterAuto() )
                        {
                        }
                    }
                    else
                    {
                    }
                }
            }
            // --- ADD m.suzuki 2010/02/18 ----------<<<<<
        }

        /// <summary>
        /// ��ʐ����C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�����I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���e</param>
        private void EmployeeLoginFormAF_Load(object sender, System.EventArgs e)
        {
            //�I�����C����
            if( _onlineFlag )
            {
                Text = "�]�ƈ����O�C��[Online]";
                //Edit���e������
                tEdit_LoginId.Text = "";
                tEdit_LoginId.ReadOnly = false;
                tEdit_LoginId.Appearance.BackColor = System.Drawing.Color.White;
                tEdit_LoginPassword.Text = "";
                //���b�Z�[�W���e������
                //ultraStatusBar_EmployeeLogin.Panels["Info"].Text = "�J�[�h�����[�_�[�ɂ��������A���O�C��������͂��ĉ�����";
                //���O�C��ID�������t�H�[�J�X�ʒu�ɐݒ�
                tEdit_LoginId.Focus();
            }
            else
            {
                Text = "�]�ƈ����O�C��[Offline]";
                //Edit���e������
                tEdit_LoginId.Text = _paraEmployeeAuthInfoWork.EmployeeWork.LoginId;
                tEdit_LoginId.ReadOnly = true;
                tEdit_LoginId.Appearance.BackColor = System.Drawing.Color.AliceBlue;
                tEdit_LoginPassword.Text = "";
                //���b�Z�[�W���e������
                ultraStatusBar_EmployeeLogin.Panels["Info"].Text = "�O�񃍃O�C�������]�ƈ��p�X���[�h����͂��ĉ�����";
                //���O�C��ID�������t�H�[�J�X�ʒu�ɐݒ�
                tEdit_LoginPassword.Focus();
            }

            if( _felicaAcs != null )
            {
                //Felica�|�[�����O�X�^�[�g
                FelicaStartPolling();
            }
        }

        /// <summary>
        /// ��ʏI���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmployeeLoginFormAF_FormClosing(object sender, FormClosingEventArgs e)
        {
            //FelicaStopPolling();
            FelicaDispose();
        }

        #endregion

        #region Felica�n����
        /// <summary>
        /// �A���|�[�����O�R�[���o�b�N
        /// </summary>
        /// <param name="idm"></param>
        /// <param name="pmm"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private bool PollingSuccessCallBack(UInt64 idm, UInt64 pmm, bool result)
        {
            // --- ADD m.suzuki 2010/02/18 ---------->>>>>
            if ( idm == 0 )
            {
                // ��x�|�[�����O�����ƔF�����Ă��Aidm=0�Ȃ�΃L�����Z������
                // �i�����[�_�[���ڑ�����Ă��Ȃ��ꍇ�Ɍ�F������ׁA�Ή��j
                FelicaStartPolling();
                return false;
            }
            // --- ADD m.suzuki 2010/02/18 ----------<<<<<

            bool loginStatus = false;
            if( result )
            {
                //���O�C���������ʏ탍�O�C���Əd�Ȃ�Ȃ��悤�ɔr��
                lock( _loginObject )
                {
                    //�]�ƈ����O�C������
                    loginStatus = LoginProc(idm.ToString(), "", true);

                    if( loginStatus )
                    {
                        this.Close();
                    }
                    else
                    {
                        FelicaStartPolling();
                    }
                }
            }
            else
            {
                if( _felicaAcs.FelicaLastErrType == FeliCaErrorType.FELICA_READER_WRITER_OPEN_AUTO_ERROR
                    || _felicaAcs.FelicaLastErrType == FeliCaErrorType.FELICA_POLLING_ERROR
                    || _felicaAcs.RwLastErrType == RwErrorType.RW_DEVICE_PLUGIN_NOT_FOUND
                    || _felicaAcs.RwLastErrType == RwErrorType.RW_READER_WRITER_DISCONNECTED )
                {
                    FelicaDispose();
                    ultraStatusBar_EmployeeLogin.Panels["Info"].Text = "�]�ƈ����O�C��������͂��ĉ�����";
                }
            }

            return result;
        }



        /// <summary>
        /// �t�F���J�J�[�h�Ď��X�^�[�g
        /// </summary>
        private void FelicaStartPolling()
        {
            if( _felicaAcs != null )
            {
                timer_FelicaInfo.Enabled = true;
                timer_FelicaInfo.Start();

                _felicaAcs.StartPolling(felicaInterval, felicaRetry);
            }
        }

        /// <summary>
        /// �t�F���J�J�[�h�Ď��X�g�b�v
        /// </summary>
        private void FelicaStopPolling()
        {
            if( _felicaAcs != null )
            {
                _felicaAcs.StopPolling();
            }

            timer_FelicaInfo.Stop();
            timer_FelicaInfo.Enabled = false;
        }


        /// <summary>
        /// �t�F���J�j������
        /// </summary>
        private void FelicaDispose()
        {
            FelicaStopPolling();

            if( _felicaAcs != null )
            {
                try
                {
                    ultraStatusBar_EmployeeLogin.Panels["Info"].Enabled = true;

                    _felicaAcs.Dispose();
                    _felicaAcs = null;
                }
                catch( Exception )
                {
                    _felicaAcs = null;
                }
            }
        }
        #endregion
    }
}
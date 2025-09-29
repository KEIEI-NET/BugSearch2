//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �i�ԕϊ�����
// �v���O�����T�v   : �i�ԕϊ������t�H�[���N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/12/24  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00  �쐬�S�� : �c����
// �� �� ��  2015/04/06   �C�����e : Redmine#44209 ���j���[�N������Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �N������
    /// </summary>
    /// <remarks>
    /// Note       : �N�������ł��B<br />
    /// Programmer : 杍^<br />
    /// Date       : 2009/12/24<br />
    /// <br>UpdateNote : 2015/04/06 �c���� </br>
    /// <br>           : Redmine#44209 ���j���[�N������Ή�</br>
    /// </remarks>
    static class Program
    {
        private static string[] _parameter;						// �N���p�����[�^
        private static Form _form = null;

        //----- ADD 2015/04/06 �c���� Redmine#44209 ���j���[�N������Ή� ----->>>>>
        /// <summary> ���j���[�N������ݒ�t�@�C�� </summary>
        private const string XML_FILE_START = "GoodsNoChange_Config.xml";
        //----- ADD 2015/04/06 �c���� Redmine#44209 ���j���[�N������Ή� -----<<<<<

        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        /// <param name="args">�N���p�����[�^</param>
        /// <remarks>
        /// Note       : �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B<br />
        /// Programmer : 杍^<br />
        /// Date       : 2009/12/24<br />
        /// <br>UpdateNote : 2015/04/06 �c���� </br>
        /// <br>           : Redmine#44209 ���j���[�N������Ή�</br>
        /// </remarks>
        [STAThread]
        static void Main(String[] args)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                string msg = "";
                _parameter = args;

                // �A�v���P�[�V�����J�n��������
                // ���p�����[�^�̓A�v���P�[�V�����̃\�t�g�E�F�A�R�[�h���w��ł���ꍇ�͖���B�o���Ȃ��ꍇ�̓v���_�N�g�R�[�h
                int status = ApplicationStartControl.StartApplication(
                    out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));

                if (status == 0)
                {
                    // �I�����C����Ԕ��f
                    if (!LoginInfoAcquisition.OnlineFlag)
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMKHN01700U",
                            "�I�t���C����ԂŖ{�@�\�͂��g�p�ł��܂���B", 0, MessageBoxButtons.OK);
                    }
                    else
                    {
                        //----- DEL 2015/04/06 �c���� Redmine#44209 ���j���[�N������Ή� ----->>>>>
                        //_form = new PMKHN01700UA();

                        //System.Windows.Forms.Application.Run(_form);
                        //----- DEL 2015/04/06 �c���� Redmine#44209 ���j���[�N������Ή� -----<<<<<
                        //----- ADD 2015/04/06 �c���� Redmine#44209 ���j���[�N������Ή� ----->>>>>
                        /*
                        * ���j���[�̋N���ې���
                        *    �O���t�@�C���̗��p�\�� �� �V�X�e�����t                               => ���j���[�̋N����������
                        *    �O���t�@�C�������݂��Ȃ� �n�q �O���t�@�C���̗��p�\�� �� �V�X�e�����t => ���j���[�̋N���������Ȃ�
                        */
                        if (BeforeRunDateCheck())
                        {
                        _form = new PMKHN01700UA();
                        System.Windows.Forms.Application.Run(_form);
                    }
                        else
                        {
                            _form = new PMKHN01700UA(0);
                            MessageBox.Show(_form, "���݂����p�����܂���B", "��� - ��" + _form.Text + "��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _form = null;
                        }
                        //----- ADD 2015/04/06 �c���� Redmine#44209 ���j���[�N������Ή� -----<<<<<
                    }
                }
                else
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMKHN01700U", msg, 0, MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "PMKHN01700U", ex.Message, 0, MessageBoxButtons.OK);
            }
            finally
            {
                ApplicationStartControl.EndApplication();
            }
        }

        //----- ADD 2015/04/06 �c���� Redmine#44209 ���j���[�N������Ή� ----->>>>>
        /// <summary>
        /// �v���O���}�����s����O�ɁA���t���`�F�b�N����
        /// </summary>
        /// <returns></returns>
        public static bool BeforeRunDateCheck()
        {
            Config xmlSetting = null;
            bool checkFlag = false;
            int checkResult = 0;

            try
            {
                if (UserSettingController.ExistUserSetting(System.IO.Path.Combine(Environment.CurrentDirectory, XML_FILE_START)))
                {
                    try
                    {
                        xmlSetting = UserSettingController.DeserializeUserSetting<Config>(System.IO.Path.Combine(Environment.CurrentDirectory, XML_FILE_START));
                    }
                    catch
                    {
                        xmlSetting = new Config();
                    }
                }

                /*
                 * ���j���[�̋N���ې���
                 *    �O���t�@�C���̗��p�\�� �� �V�X�e�����t                               => ���j���[�̋N����������
                 *    �O���t�@�C�������݂��Ȃ� �n�q �O���t�@�C���̗��p�\�� �� �V�X�e�����t => ���j���[�̋N���������Ȃ�
                 */
                if (xmlSetting != null && xmlSetting.Common != null && !string.IsNullOrEmpty(xmlSetting.Common.AvailableDate))
                {
                    string checkDate = xmlSetting.Common.AvailableDate;
                    DateTime checkDateTime = Convert.ToDateTime(checkDate);
                    checkResult = DateTime.Compare(checkDateTime, DateTime.Now);

                    if (checkResult <= 0)
                    {
                        checkFlag = true;
                    }
                }
                else
                {
                    checkFlag = false;
                }
            }
            catch
            {
                checkFlag = false;
            }

            return checkFlag;
        }
        //----- ADD 2015/04/06 �c���� Redmine#44209 ���j���[�N������Ή� -----<<<<<

        /// <summary>
        /// �A�v���P�[�V�����I���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// Note       : �A�v���P�[�V�����I�������ł��B<br />
        /// Programmer : 杍^<br />
        /// Date       : 2009/12/24<br />
        /// </remarks>
        private static void ApplicationReleased(object sender, EventArgs e)
        {
            // ���b�Z�[�W���o���O�ɑS�ĊJ��
            ApplicationStartControl.EndApplication();

            // �]�ƈ����O�I�t�̃��b�Z�[�W��\��
            if (_form != null)
            {
                TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "PMKHN01700U", e.ToString(), 0, MessageBoxButtons.OK);
            }
            else
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMKHN01700U", e.ToString(), 0, MessageBoxButtons.OK);
            }

            // �A�v���P�[�V�����I��
            System.Windows.Forms.Application.Exit();
        }
    }

    //----- ADD 2015/04/06 �c���� Redmine#44209 ���j���[�N������Ή� ----->>>>>
    /// <summary>
    /// ���t�̏��
    /// </summary>
    public class CheckDate
    {
        /// <summary> �`�F�b�N�p���t </summary>
        private string _availableDate;

        /// <summary>
        /// �`�F�b�N�p���t
        /// </summary>
        public string AvailableDate
        {
            get { return _availableDate; }
            set { _availableDate = value; }
        }
    }

    /// <summary>
    /// �e�[�u���f�[�^�̐ݒ�
    /// </summary>
    public class Config
    {
        /// <summary> �e�[�u�����ݒ� </summary>
        private CheckDate _common;

        /// <summary>
        /// �e�[�u�����ݒ�
        /// </summary>
        public CheckDate Common
        {
            get { return _common; }
            set
            {
                if (_common == null)
                {
                    _common = new CheckDate();
                }
                _common = value;
            }
        }
    }
    //----- ADD 2015/04/06 �c���� Redmine#44209 ���j���[�N������Ή� -----<<<<<
}
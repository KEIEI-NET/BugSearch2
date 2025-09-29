//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : PMNS-HTT�ʐM�T�[�r�X
// �v���O�����T�v   : PMNS-HTT�Ԃ̒ʐM���s���T�[�r�X�v���O�����ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370006-00 �쐬�S�� : �����@�q�V
// �� �� ��  2017/07/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace PMHND00100S
{
    /// public class name:   HT_Service_Installer
    /// <summary>
    ///                      �T�[�r�X�̊e�v���p�e�B�̏����ݒ�
    /// </summary>
    /// <remarks>
    /// <br>note             :   �T�[�r�X�̏����ݒ�p�N���X</br>
    /// <br>Programmer       :   �����@�q�V</br>
    /// <br>Date             :   2017/07/01</br>
    /// <br></br>
    /// <br></br>
    /// <br>Update Note      :   </br>
    /// <br></br>
    /// </remarks>
    [RunInstaller(true)]
    public partial class HT_Service_Installer : Installer
    {
        private ServiceInstaller _si;
        private ServiceProcessInstaller _pi;

        /// <summary>
        /// �T�[�r�X�̊e�v���p�e�B�̏����ݒ�
        /// </summary>
        public HT_Service_Installer()
        {
            _pi = new ServiceProcessInstaller();

            //�T�[�r�X�̎��s���[�U�[
            _pi.Account = ServiceAccount.LocalSystem;
            //_pi.Account = ServiceAccount.User;

            this.Installers.Add(_pi);

            _si = new ServiceInstaller();

            //�J�n���@�̎w��
            _si.StartType = ServiceStartMode.Automatic;
            
            //�T�[�r�X��
            _si.ServiceName = "Partsman.NS HT_RELAY_SERVICE";

            //�T�[�r�X�̐���
            _si.Description = "Partsman.NS-HT�Ԃ̒ʐM���s���܂��B" + "\r\n" +
                              "Partsman.NS�Ɠ��T�[�r�X�Ԃ́AIPC�ʐM�B" + "\r\n" +
                              "���T�[�r�X��HT�Ԃ́ASocket�ʐM�B";

            //�T�[�r�X�̕\����
            _si.DisplayName = "Partsman.NS HT_RELAY_SERVICE";

            this.Installers.Add(_si);

            InitializeComponent();
        }
    }
}
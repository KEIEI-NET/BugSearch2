using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;

namespace Broadleaf.NSNetworkChk.Data
{
    /// <summary>
    /// AWS�����e�X�g���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : AWS�����e�X�g���̃N���X�ł��B</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2019.01.02</br>
    /// </remarks>
    public class NSNetWorkAutoTestInfo
    {
        /// <summary>
        /// AWS�����e�X�g���R���X�g���N�^
        /// </summary>
        /// <returns>NSNetWorkAutoTestInfo�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   NSNetWorkAutoTestInfo�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public NSNetWorkAutoTestInfo()
        {
        }

        /// <summary>�����e�X�g���i</summary>
        private string _autoProductName;

        /// <summary>�����e�X�g�敪</summary>
        private bool _autoStartupDiv;

        /// public propaty name  :  AutoProductName
        /// <summary>�����e�X�g���i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����e�X�g���i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AutoProductName
        {
            get { return _autoProductName; }
            set { _autoProductName = value; }
        }

        /// public propaty name  :  AutoStartupDiv
        /// <summary>�����e�X�g�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����e�X�g�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool AutoStartupDiv
        {
            get { return _autoStartupDiv; }
            set { _autoStartupDiv = value; }
        }

        /// <summary>
        /// �f�V���A���C�Y��
        /// </summary>
        /// <returns>AWS�����e�X�g���N���X</returns>
        /// <remarks>
        /// <br>Note       : XML����NSNetWorkAutoTestInfo�f�[�^��ǂݍ��݂܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2019.01.02</br>
        /// </remarks>
        public static int Deserialize(out NSNetWorkAutoTestInfo nSNetWorkAutoTestInfo, string filename)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            try
            {
                // AWS�����e�X�g���̃C���X�^���X���擾
                // AWS�����e�X�g���t�@�C���̑��݂��m�F
                if (UserSettingController.ExistUserSetting(Path.Combine(System.Windows.Forms.Application.StartupPath, filename)))
                {
                    nSNetWorkAutoTestInfo = UserSettingController.DeserializeUserSetting<NSNetWorkAutoTestInfo>(Path.Combine(System.Windows.Forms.Application.StartupPath, filename));
                }
                else
                {
                    // AWS�����e�X�g����t�@�C�������݂��Ȃ��ꍇ
                    nSNetWorkAutoTestInfo = Default();
                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                }
            }
            //XML���ǂݍ��ݎ��s�̏ꍇ
            catch (Exception)
            {
                nSNetWorkAutoTestInfo = Default();
                status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
            }
            
            return status;
        }

        /// <summary>
        /// AWS�����e�X�g���擾����
        /// </summary>
        /// <returns>AWS�����e�X�g���̏����l</returns>
        /// <remarks>
        /// <br>Note       : AWS�����e�X�g���̏����l��ݒ肵�܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2019.01.02</br>
        /// </remarks>
        private static NSNetWorkAutoTestInfo Default()
        {
            NSNetWorkAutoTestInfo nSNetWorkAutoTestInfoDefault = new NSNetWorkAutoTestInfo();

            nSNetWorkAutoTestInfoDefault._autoProductName = "���i��I�����ĉ�����";
            nSNetWorkAutoTestInfoDefault._autoStartupDiv = false;

            return nSNetWorkAutoTestInfoDefault;
        }

    }
}

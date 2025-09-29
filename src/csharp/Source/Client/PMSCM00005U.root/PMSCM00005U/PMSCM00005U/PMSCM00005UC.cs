using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Controller.Util;// ADD 2020/10/30 ���O PMKOBETSU-4088

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// SCM���[�J���ݒ�A�N�Z�X�N���X
    /// <summary>
    /// </summary>
    /// <remarks>
    /// <br>note             :   SCM���[�J���ݒ�A�N�Z�X�N���X</br>
    /// <br>Programmer       :   ���X�؁@��</br>
    /// <br>Date             :   2010/03/03</br>
    /// </remarks>
    public class ScmLocalSetAcs
    {
        // SCM���[�J���ݒ�A�N�Z�X�N���X�ƃf�[�^�N���X���L�q���܂��B
        // SCM���[�J���ݒ�p�t�@�C���p�X
        private const string CTFILE_UISETTING = "PMSCM00005U_UserSetting.xml";

        private ScmLocalSet _scmLocal;

        internal ScmLocalSet ScmLocal
        {
            get { return _scmLocal; }
            set { _scmLocal = value; }
        }


        /// <summary>
        /// SCM���[�J���ݒ�Ǎ�����
        /// </summary>
        /// <returns>SCM���[�J���ݒ�</returns>
        /// <remarks>
        /// <br>Note		: SCM���[�J���ݒ����ǂݍ��݂܂��B</br>
        /// <br>Programmer	: 21024�@���X�� ��</br>
        /// <br>Date		: 2010.03.03</br>
        /// </remarks>
        public ScmLocalSet ReadScmLocalSet()
        {
            ScmLocalSet info = null;

            if (UserSettingController.ExistUserSetting(System.IO.Path.Combine(ConstantManagement_ClientDirectory.UISettings, CTFILE_UISETTING)))
            {
                try
                {
                    // XML���璊�o�����A�C�e���N���X�z��Ƀf�V���A���C�Y����
                    info = UserSettingController.DeserializeUserSetting<ScmLocalSet>(System.IO.Path.Combine(ConstantManagement_ClientDirectory.UISettings, CTFILE_UISETTING));
                }
                catch (InvalidOperationException)
                {
                    LogWriter.LogWrite("SCM���[�J���ݒ�p�t�@�C������ŏI�擾���t�ƍŏI�擾���Ԃ��擾���s���܂����B");// ADD 2020/10/30 ���O PMKOBETSU-4088
                }
            }

            if (info == null)
            {
                info = new ScmLocalSet();
            }

            return info;
        }

        /// <summary>
        /// SCM���[�J���ݒ�ۑ�����
        /// </summary>
        /// <param name="info">SCM���[�J���ݒ�</param>
        /// <remarks>
        /// <br>Note		: SCM���[�J���ݒ��ۑ����܂��B</br>
        /// <br>Programmer	: 30015 ���{�@�T�B</br>
        /// <br>Date		: 2009.05.22</br>
        /// </remarks>
        public void WriteScmLocalSet()
        {
            try
            {
                // ���o�����A�C�e���N���X�z���XML�ɃV���A���C�Y����
                UserSettingController.SerializeUserSetting(_scmLocal, System.IO.Path.Combine(ConstantManagement_ClientDirectory.UISettings, CTFILE_UISETTING));
            }
            catch (Exception)
            {
            }
        }

    }


    /// public class name:   ScmLocalSet
    /// <summary>
    ///                      SCM���[�J���ݒ�
    /// </summary>
    /// <remarks>
    /// <br>note             :   SCM���[�J���ݒ�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ���X�؁@��</br>
    /// <br>Date             :   2010/03/03</br>
    /// </remarks>
    public class ScmLocalSet
    {
        /// <summary>�|�b�v�A�b�v�\���敪</summary>
        /// <remarks>0:�\������,1:�\�����Ȃ�</remarks>
        private Int32 _popupDspDiv;

        /// <summary>�|�b�v�A�b�v�\������</summary>
        /// <remarks>�b�P��(0:�����ƕ\��)</remarks>
        private Int32 _popUpDspTime;

        /// <summary>�ŏI�擾���t</summary>
        /// <remarks>YYYYMMDD(DATETIME)</remarks>
        private DateTime _lastGetDate;

        /// <summary>�ŏI�擾����</summary>
        /// <remarks>HHMMSSXXX</remarks>
        private Int32 _lastGetTime;

        /// public propaty name  :  PopupDspDiv
        /// <summary>�|�b�v�A�b�v�\���敪�v���p�e�B</summary>
        /// <value>0:�\������,1:�\�����Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|�b�v�A�b�v�\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PopupDspDiv
        {
            get { return _popupDspDiv; }
            set { _popupDspDiv = value; }
        }

        /// public propaty name  :  PopUpDspTime
        /// <summary>�|�b�v�A�b�v�\�����ԃv���p�e�B</summary>
        /// <value>�b�P��(0:�����ƕ\��)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|�b�v�A�b�v�\�����ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PopUpDspTime
        {
            get { return _popUpDspTime; }
            set { _popUpDspTime = value; }
        }

        /// public propaty name  :  LastGetDate
        /// <summary>�ŏI�擾���t�v���p�e�B</summary>
        /// <value>YYYYMMDD(DATETIME)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŏI�擾���t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime LastGetDate
        {
            get { return _lastGetDate; }
            set { _lastGetDate = value; }
        }

        /// public propaty name  :  LastGetTime
        /// <summary>�ŏI�擾���ԃv���p�e�B</summary>
        /// <value>HHMMSSXXX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŏI�擾���ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LastGetTime
        {
            get { return _lastGetTime; }
            set { _lastGetTime = value; }
        }

        /// <summary>
        /// SCM���[�J���ݒ�R���X�g���N�^
        /// </summary>
        /// <returns>ScmLocalSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ScmLocalSet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ScmLocalSet()
        {
        }


        /// <summary>
        /// SCM���[�J���ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="popupDspDiv">�|�b�v�A�b�v�\���敪(0:�\������,1:�\�����Ȃ�)</param>
        /// <param name="popUpDspTime">�|�b�v�A�b�v�\������(�b�P��(0:�����ƕ\��))</param>
        /// <param name="lastGetDate">�ŏI�擾���t(YYYYMMDD(DATETIME))</param>
        /// <param name="lastGetTime">�ŏI�擾����(HHMMSSXXX)</param>
        /// <returns>ScmLocalSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ScmLocalSet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ScmLocalSet(Int32 popupDspDiv, Int32 popUpDspTime, DateTime lastGetDate, Int32 lastGetTime)
        {
            this._popupDspDiv = popupDspDiv;
            this._popUpDspTime = popUpDspTime;
            this._lastGetDate = lastGetDate;
            this._lastGetTime = lastGetTime;

        }

        /// <summary>
        /// SCM���[�J���ݒ�}�X�^��������
        /// </summary>
        /// <returns>ScmLocalSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����ScmLocalSet�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ScmLocalSet Clone()
        {
            return new ScmLocalSet(this._popupDspDiv, this._popUpDspTime, this._lastGetDate, this._lastGetTime);
        }

        /// <summary>
        /// SCM���[�J���ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�ScmLocalSet�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ScmLocalSet�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(ScmLocalSet target)
        {
            return ( ( this.PopupDspDiv == target.PopupDspDiv )
                && ( this.PopUpDspTime == target.PopUpDspTime )
                && ( this.LastGetDate == target.LastGetDate )
                && ( this.LastGetTime == target.LastGetTime ) );
        }
    }

}

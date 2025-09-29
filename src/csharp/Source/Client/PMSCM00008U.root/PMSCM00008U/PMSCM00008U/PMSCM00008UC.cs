using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

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
    public class CmtLocalSetAcs
    {
        // ���[�J���ݒ�A�N�Z�X�N���X�ƃf�[�^�N���X���L�q���܂��B
        // ���[�J���ݒ�p�t�@�C���p�X
        private const string CTFILE_UISETTING = "PMSCM00008U_UserSetting.xml";

        private CmtLocalSet _cmtLocal;

        internal CmtLocalSet CmtLocal
        {
            get { return _cmtLocal; }
            set { _cmtLocal = value; }
        }

        /// <summary>
        /// ���[�J���ݒ�ǂݍ��ݏ���
        /// </summary>
        /// <returns>���[�J���ݒ�</returns>
        public CmtLocalSet ReadScmLocalSet()
        {
            CmtLocalSet info = null;

            if (UserSettingController.ExistUserSetting(System.IO.Path.Combine(ConstantManagement_ClientDirectory.UISettings, CTFILE_UISETTING)))
            {
                try
                {
                    // XML���璊�o�����A�C�e���N���X�z��Ƀf�V���A���C�Y����
                    info = UserSettingController.DeserializeUserSetting<CmtLocalSet>(System.IO.Path.Combine(ConstantManagement_ClientDirectory.UISettings, CTFILE_UISETTING));
                }
                catch (InvalidOperationException)
                {
                }
            }

            if (info == null)
            {
                info = new CmtLocalSet();
            }

            return info;
        }

        /// <summary>
        /// ���[�J���ݒ�ۑ�����
        /// </summary>
        /// <param name="info">���[�J���ݒ�</param>
        public void WriteLocalSet()
        {
            try
            {
                // ���o�����A�C�e���N���X�z���XML�ɃV���A���C�Y����
                UserSettingController.SerializeUserSetting(_cmtLocal, System.IO.Path.Combine(ConstantManagement_ClientDirectory.UISettings, CTFILE_UISETTING));
            }
            catch (Exception)
            {
            }
        }

    }


    /// public class name:   CmtLocalSet
    /// <summary>
    ///                      CMT���[�J���ݒ�
    /// </summary>
    /// <remarks>
    /// <br>note             :   CMt���[�J���ݒ�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ���X�؁@��</br>
    /// <br>Date             :   2010/03/10</br>
    /// </remarks>
    public class CmtLocalSet
    {
        /// <summary>��M����</summary>
        /// <remarks>�b</remarks>
        private Int32 _recvTime;

        /// <summary>�Ď��s</summary>
        /// <remarks>0:���Ȃ��A1:����</remarks>
        private Int32 _retry;

        /// public propaty name  :  RecvTime
        /// <summary>��M���ԃv���p�e�B</summary>
        /// <value>�b��ݒ�</value>
        public Int32 RecvTime
        {
            get { return _recvTime; }
            set { _recvTime = value; }
        }

        /// public propaty name  :  Retry
        /// <summary>���g���C</summary>
        /// <value>0:���Ȃ��A1:����</value>
        public Int32 Retry
        {
            get { return _retry; }
            set { _retry = value; }
        }

        // 2011/03/04 Add >>>
        /// <summary>CTI���[�h</summary>
        private int _ctiMode = -1;

        /// <summary>
        /// CTI�N�����[�h
        /// <value>0:���Ȃ��A1:�ʏ탂�[�h�A2:����`�[����</value>
        /// </summary>
        public int CTIMode
        {
            get { return _ctiMode; }
            set { _ctiMode = value; }
        }
        // 2011/03/04 Add <<<


        /// <summary>
        /// ���[�J���ݒ�R���X�g���N�^
        /// </summary>
        /// <returns>�C���X�^���X</returns>
        /// </remarks>
        public CmtLocalSet()
        {
        }

        /// <summary>
        /// ���[�J���ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="recvTime">��M����</param>
        /// <param name="retry">�Ď��s</param>
        // 2011/03/04 >>>
        //public CmtLocalSet(Int32 recvTime, Int32 retry)
        public CmtLocalSet(Int32 recvTime, Int32 retry, Int32 ctiMode)
        // 2011/03/04 <<<
        {
            this._recvTime = recvTime;
            this._retry = retry;
            this._ctiMode = ctiMode;  // 2011/03/04 Add
        }

        /// <summary>
        /// ���[�J���ݒ�}�X�^��������
        /// </summary>
        /// <returns>ScmLocalSet�N���X�̃C���X�^���X</returns>
        public CmtLocalSet Clone()
        {
            // 2011/03/04 >>>
            //return new CmtLocalSet(this._recvTime, this._retry);
            return new CmtLocalSet(this._recvTime, this._retry, this._ctiMode);
            // 2011/03/04 <<<
        }

        /// <summary>
        /// ���[�J���ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�ScmLocalSet�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        public bool Equals(CmtLocalSet target)
        {
            // 2011/03/04 >>>
            //return ( ( this.RecvTime == target.RecvTime )
            //    && ( this.Retry == target.Retry ));

            return ( ( this.RecvTime == target.RecvTime )
                   && ( this.Retry == target.Retry )
                   && ( this.CTIMode == target.CTIMode )
                   );

            // 2011/03/04 <<<
        }
    }

}

using System;
using System.Collections.Generic;
using System.IO;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���[�����M�����f�[�^�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �V�K�쐬</br>
    /// <br>Programmer : 980035�@����@��`</br>
    /// <br>Date       : 2010/05/25</br>
    /// </remarks>
    public class MailSendHistAcs
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region �� Private Member

        #endregion

        // ===================================================================================== //
        // �񋓑�
        // ===================================================================================== //
        #region �� Public Enum

        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        #region �� Costructor

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public MailSendHistAcs()
        {
                   
        }

        #endregion

        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        #region �� Public Method

        /// <summary>
        /// ���[�����M�����f�[�^���������݂܂��B
        /// </summary>
        /// <param name="mailHistList">���[�����M�����f�[�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        public int Write(List<MailHist> mailHistList)
        {
            return WriteProc(mailHistList);
        }

        /// <summary>
        /// ���[�����M�����f�[�^��ǂݍ��݂܂��B
        /// </summary>
        /// <param name="mailHistList">���[�����M�����f�[�^�I�u�W�F�N�g���X�g</param>
        /// <returns>STATUS</returns>
        public int Read(out List<MailHist> mailHistList)
        {
            return ReadProc(out mailHistList);
        }

        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        #region �� Private Method

        /// <summary>
        /// ���[���p�����f�[�^���������݂܂��B
        /// </summary>
        /// <param name="mailHistList">���[�����M�����f�[�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        private int WriteProc(List<MailHist> mailHistList)
        {
            string fileName = "QRMAILHIST.XML";
            string fullpath = Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName);
            PMNSMailCommon pmmc = new PMNSMailCommon();
            pmmc.PMNSQRMailHist = mailHistList;

            try
            {
                UserSettingController.SerializeUserSetting(pmmc, fullpath);
            }
            catch
            {
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// ���[���p�����f�[�^��ǂݍ��݂܂��B
        /// </summary>
        /// <param name="mailHistList">���[���������׃f�[�^�I�u�W�F�N�g���X�g</param>
        /// <returns>STATUS</returns>
        private int ReadProc(out List<MailHist> mailHistList)
        {
            mailHistList = new List<MailHist>();

            string fileName = "QRMAILHIST.XML";
            string filePath = Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName);

            if (!System.IO.File.Exists(filePath)) return -1;

            try
            {
                object obj = UserSettingController.DeserializeUserSetting(filePath, typeof(PMNSMailCommon));
                if (obj != null && obj is PMNSMailCommon)
                {
                    PMNSMailCommon data = (PMNSMailCommon)obj;
                    mailHistList = data.PMNSQRMailHist;
                }
                else
                {
                    return -2;
                }
            }
            catch
            {
                return -3;
            }

            return 0;
        }

        #endregion
    }

    /// <summary>
    /// ���[���������
    /// </summary>
    [Serializable]
    public class PMNSMailCommon
    {
        #region �� Private Member

        private List<MailHist> _mailHistList;

        #endregion

        #region �� Constructor

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public PMNSMailCommon()
        {

        }
        #endregion

        #region �� Property

        /// <summary>���[�����M�������X�g</summary>
        public List<MailHist> PMNSQRMailHist
        {
            get { return _mailHistList; }
            set { _mailHistList = value; }
        }
        #endregion
    }
}

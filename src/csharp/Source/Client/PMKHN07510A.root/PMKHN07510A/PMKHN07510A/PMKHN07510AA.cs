using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���[�������l�f�[�^�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �V�K�쐬</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2010/04/06</br>
    /// </remarks>
    public class MailDefaultDataAcs
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
        /// <summary>
        /// �ȒP�⍇���̃V�X�e���R�[�h
        /// </summary>
        public enum SimpleInqIdCngSysCd : int
        {
            Partsman = 300
        }
        
        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        #region �� Costructor

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public MailDefaultDataAcs()
        {
                   
        }

        #endregion

        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        #region �� Public Method

        /// <summary>
        /// ���[���p�����f�[�^���������݂܂��B
        /// </summary>
        /// <param name="mailDefaultHeader">���[�������w�b�_�f�[�^�I�u�W�F�N�g</param>
        /// <param name="mailDefaultCar">���[�������ԗ��f�[�^�I�u�W�F�N�g</param>
        /// <param name="mailDefaultDetailList">���[���������׃f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="fileName">�쐬�����t�@�C����</param>
        /// <returns>STATUS</returns>
        public int Write(MailDefaultHeader mailDefaultHeader, MailDefaultCar mailDefaultCar, List<MailDefaultDetail> mailDefaultDetailList, out string fileName)
        {
            return WriteProc(mailDefaultHeader, mailDefaultCar, mailDefaultDetailList, out fileName);
        }

        /// <summary>
        /// ���[���p�����f�[�^��ǂݍ��݂܂��B
        /// </summary>
        /// <param name="fileName">�t�@�C����</param>
        /// <param name="mailDefaultHeader">���[�������w�b�_�f�[�^�I�u�W�F�N�g</param>
        /// <param name="mailDefaultCar">���[�������ԗ��f�[�^�I�u�W�F�N�g</param>
        /// <param name="mailDefaultDetailList">���[���������׃f�[�^�I�u�W�F�N�g���X�g</param>
        /// <returns>STATUS</returns>
        public int Read(string fileName, out MailDefaultHeader mailDefaultHeader, out MailDefaultCar mailDefaultCar, out List<MailDefaultDetail> mailDefaultDetailList)
        {
            return ReadProc(fileName, out mailDefaultHeader, out mailDefaultCar, out mailDefaultDetailList);
        }

        /// <summary>
        /// ���[���p�����f�[�^���폜���܂��B
        /// </summary>
        /// <param name="fileName">�t�@�C����</param>
        /// <returns>STATUS</returns>
        public int Delete(string fileName)
        {
            return DeleteProc(fileName);
        }

        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        #region �� Private Method

        /// <summary>
        /// ���[���p�����f�[�^���������݂܂��B
        /// </summary>
        /// <param name="mailDefaultHeader">���[�������w�b�_�f�[�^�I�u�W�F�N�g</param>
        /// <param name="mailDefaultCar">���[�������ԗ��f�[�^�I�u�W�F�N�g</param>
        /// <param name="mailDefaultDetailList">���[���������׃f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="fileName">�t�@�C����</param>
        /// <returns>STATUS</returns>
        private int WriteProc(MailDefaultHeader mailDefaultHeader, MailDefaultCar mailDefaultCar, List<MailDefaultDetail> mailDefaultDetailList, out string fileName)
        {
            fileName = Guid.NewGuid().ToString() + ".xml";
            string fullpath = Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName);
            MailDefaultData msd = new MailDefaultData();
            msd.HeaderInfo = mailDefaultHeader;
            msd.DetailInfoList = mailDefaultDetailList;
            msd.CarInfo = mailDefaultCar;

            try
            {
                UserSettingController.SerializeUserSetting(msd, fullpath);
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
        /// <param name="fileName">�t�@�C����</param>
        /// <param name="mailDefaultHeader">���[�������w�b�_�f�[�^�I�u�W�F�N�g</param>
        /// <param name="mailDefaultCar">���[�������ԗ��f�[�^�I�u�W�F�N�g</param>
        /// <param name="mailDefaultDetailList">���[���������׃f�[�^�I�u�W�F�N�g���X�g</param>
        /// <returns>STATUS</returns>
        private int ReadProc(string fileName, out MailDefaultHeader mailDefaultHeader, out MailDefaultCar mailDefaultCar, out List<MailDefaultDetail> mailDefaultDetailList)
        {
            mailDefaultHeader = new MailDefaultHeader();
            mailDefaultDetailList = new List<MailDefaultDetail>();
            mailDefaultCar = new MailDefaultCar();

            string filePath = Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName);

            if (!System.IO.File.Exists(filePath)) return -1;

            try
            {
                object obj = UserSettingController.DeserializeUserSetting(filePath, typeof(MailDefaultData));
                if (obj != null && obj is MailDefaultData)
                {
                    MailDefaultData data = (MailDefaultData)obj;
                    mailDefaultHeader = data.HeaderInfo;
                    mailDefaultDetailList = data.DetailInfoList;
                    mailDefaultCar = data.CarInfo;
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

        /// <summary>
        /// ���[���p�����f�[�^���폜���܂��B
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private int DeleteProc(string fileName)
        {
            string filePath = Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName);
            if (System.IO.File.Exists(filePath))
            {
                UserSettingController.DeleteUserSetting(filePath);
            }
            return 0;
        }
        

        #endregion
    }

    /// <summary>
    /// ���[�������f�[�^
    /// </summary>
    [Serializable]
    public class MailDefaultData
    {
        #region �� Private Member

        private MailDefaultHeader _header;
        private List<MailDefaultDetail> _detailList;
        private MailDefaultCar _car;

        #endregion

        #region �� Constructor

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public MailDefaultData()
        {

        }
        #endregion

        #region �� Property

        /// <summary>�w�b�_�f�[�^</summary>
        public MailDefaultHeader HeaderInfo
        {
            get { return _header; }
            set { _header = value; }
        }

        /// <summary>�ԗ����</summary>
        public MailDefaultCar CarInfo
        {
            get { return _car; }
            set { _car = value; }
        }


        /// <summary>���׃��X�g</summary>
        public List<MailDefaultDetail> DetailInfoList
        {
            get { return _detailList; }
            set { _detailList = value; }
        }
        #endregion
    }
}

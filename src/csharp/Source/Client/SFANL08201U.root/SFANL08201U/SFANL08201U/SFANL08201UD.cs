using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �ŏI���������I/O�N���X�ł�
    /// </summary>
	class LastPrtTimeAcs
	{
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region private member
        private string _xmlLastPrtFileName;                           // �ŏI��������ۑ��pXML�̃t���p�X
        
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g�萔
        // ===================================================================================== //
        #region private constant
        private const string XML_FNAME_LASTPRT = "FrePLastPrt.xml";  // �ŏI��������̂w�l�k�t�@�C������ݒ�
        
        #endregion

        // ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		#region constructor
        public LastPrtTimeAcs()
        {
            //�ŏI��������ۑ��p��XML�p�X
            this._xmlLastPrtFileName = ConstantManagement_ClientDirectory.Temp_UserTemp + "\\" + XML_FNAME_LASTPRT;
        }
        //public LastPrtTimeAcs(SerializationInfo info, StreamingContext context)
        //{
        //}
        #endregion

        #region ���R���[�ŏI��������o�^�E�X�V����(Write)
        /// <summary>
        /// ���R���[�ŏI��������o�^�E�X�V����
        /// </summary>
        /// <param name="lastTimes">���R���[�ŏI��������f�B�N�V���i��</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���R���[�ŏI����������̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : 22011 ���� ���l</br>
        /// <br>Date       : 2007.11.05</br>
        /// </remarks>
        public int Write(List<LastPrtTime> lastTimes)
        {
            // �X�e�[�^�X
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            try
            {
                // �w�l�k�̏������݁i���R���[�ŏI�������List�V���A���C�Y�����j
                this.Serialize(lastTimes, this._xmlLastPrtFileName);

            }
            catch (Exception)
            {
                status = -1;
            }
            return status;
        }
        #endregion

        #region ���R���[�ŏI���������������(SearchAll)
        /// <summary>
        /// ���R���[�ŏI����������������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���R���[�ŏI��������̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : 22011 ���� ���l</br>
        /// <br>Date       : 2007.11.05</br>
        /// </remarks>
        public int SearchAll(out List<LastPrtTime> retList)
        {
            retList = null;

            int status = 0;
            try
            {
                // �w�l�k�̓ǂݍ���
                retList = XmlDeserialize();

                // �Ǎ����ʂȂ��̏ꍇ��EOF��Ԃ�
                if ((retList == null)||(retList.Count <= 0))
                    status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            }
            catch (System.IO.FileNotFoundException)
            {
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }
            catch (Exception)
            {
                return -1;
            }
            return status;
        }
        #endregion

        #region �L�[�쐬
        //public string KeyGenerate(FrePprGrTr frePprGrTr)
        //{
        //    string keystring = string.Empty;
        //    if (frePprGrTr != null)
        //    {
        //        keystring = frePprGrTr.FreePrtPprGroupCd.ToString() + "," + frePprGrTr.TransferCode.ToString();
        //    }
        //    return keystring;
        //}
        #endregion

        #region �ŏI����������X�g�T�[�`
        /// <summary>
        /// �ŏI����������X�g����w��̃f�[�^���T�[�`���܂�
        /// </summary>
        /// <param name="lastTimes">�ŏI����������X�g</param>
        /// <param name="frePprGrTr">���R���[�O���[�v�U��</param>
        /// <returns>�ŏI�������(������Ȃ������Ƃ���Null��Ԃ�)</returns>
        public LastPrtTime FindLastPrtTime(List<LastPrtTime> lastTimes, FrePprGrTr frePprGrTr)
        {
            return lastTimes.Find(delegate(LastPrtTime ptm) { return ((ptm.freePrtPprGroupCd == frePprGrTr.FreePrtPprGroupCd) && (ptm.transferCode == frePprGrTr.TransferCode)); });
        }              
        #endregion

        #region �ŏI��������Z�b�g
        /// <summary>
        /// �ŏI��������Z�b�g
        /// </summary>
        /// <param name="lastTime">�ŏI�������</param>
        /// <param name="frePprGrTr">���R���[�O���[�v�U��</param>
        public void SetLastPrtTime(out LastPrtTime lastTime, FrePprGrTr frePprGrTr)
        {
            //if (lastTime == null) 
            lastTime = new LastPrtTime();
            lastTime.freePrtPprGroupCd = frePprGrTr.FreePrtPprGroupCd;
            lastTime.transferCode = frePprGrTr.TransferCode;
        }
        #endregion

        #region private methods

        #region ���R���\�ŏI��������f�V���A���C�Y����
        /// <summary>
        /// XML���玩�R���\�ŏI��������N���X�փf�V���A���C�Y���܂�
        /// </summary>
        /// <returns>Dictionary(string,DateTime)</returns>
        private List<LastPrtTime> XmlDeserialize()
        {
            return (List<LastPrtTime>)UserSettingController.DeserializeUserSetting(this._xmlLastPrtFileName, typeof(List<LastPrtTime>));
        }
        #endregion

        #region ���R���[���o��������List�V���A���C�Y����
        /// <summary>
        /// ���R���[���o����List�V���A���C�Y����
        /// </summary>
        /// <param name="lastTimes">�V���A���C�Y�Ώێ��R���[�ŏI��������f�B�N�V���i��</param>
        /// <param name="fileName">�V���A���C�Y�t�@�C����</param>
        private void Serialize(List<LastPrtTime> lastTimes, string fileName)
        {
            try
            {
                //�i�[�f�B���N�g�����Ȃ���΍쐬
                if (System.IO.Directory.Exists(ConstantManagement_ClientDirectory.Temp_UserTemp) == false)
                {
                    System.IO.Directory.CreateDirectory(ConstantManagement_ClientDirectory.Temp_UserTemp);
                }
                UserSettingController.SerializeUserSetting(lastTimes, _xmlLastPrtFileName);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        #endregion


        #endregion

    }

    /// <summary>
    /// �ŏI��������ێ��p�̃f�[�^�N���X
    /// </summary>
    public class LastPrtTime
    {
        /// <summary>
        /// 
        /// </summary>
        public LastPrtTime()
        {
        }
        /// <summary></summary>
        public int freePrtPprGroupCd;
        /// <summary></summary>
        public int transferCode;
        /// <summary></summary>
        public DateTime lastPrtTime = DateTime.Now;
    }
}
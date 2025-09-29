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
    /// �ŏI����v�����^��I/O�N���X�ł�
    /// </summary>
    class LastPrtPrinterAcs
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region private member
        private string _xmlLastPrterFileName;                           // �ŏI����v�����^�ۑ��pXML�̃t���p�X
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g�萔
        // ===================================================================================== //
        #region private constant
        private const string XML_FNAME_LASTPRTER = "FrePLastPrter.xml";  // �ŏI����v�����^�̂w�l�k�t�@�C������ݒ�

        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        #region constructor
        public LastPrtPrinterAcs()
        {
            //�ŏI����v�����^�ۑ��p��XML�p�X
            this._xmlLastPrterFileName = ConstantManagement_ClientDirectory.Temp_UserTemp + "\\" + XML_FNAME_LASTPRTER;
        }
        #endregion

        #region ���R���[�ŏI����v�����^�o�^�E�X�V����(Write)
        /// <summary>
        /// ���R���[�ŏI����v�����^�o�^�E�X�V����
        /// </summary>
        /// <param name="lastTimes">���R���[�ŏI����v�����^�f�B�N�V���i��</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���R���[�ŏI����v�����^���̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : 22011 ���� ���l</br>
        /// <br>Date       : 2008.01.25</br>
        /// </remarks>
        public int Write(List<LastPrtPrinter> lastTimes)
        {
            // �X�e�[�^�X
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            try
            {
                // �w�l�k�̏������݁i���R���[�ŏI����v�����^List�V���A���C�Y�����j
                this.Serialize(lastTimes, this._xmlLastPrterFileName);

            }
            catch (Exception)
            {
                status = -1;
            }
            return status;
        }
        #endregion

        #region ���R���[�ŏI����v�����^��������(SearchAll)
        /// <summary>
        /// ���R���[�ŏI����v�����^��������
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���R���[�ŏI����v�����^�̑S�����������s���܂��B</br>
        /// <br>Programmer : 22011 ���� ���l</br>
        /// <br>Date       : 2008.01.25</br>
        /// </remarks>
        public int Search(out List<LastPrtPrinter> retList)
        {
            retList = null;

            int status = 0;
            try
            {
                // �w�l�k�̓ǂݍ���
                retList = XmlDeserialize();

                // �Ǎ����ʂȂ��̏ꍇ��EOF��Ԃ�
                if ((retList == null) || (retList.Count <= 0))
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

        #region �ŏI����v�����^���X�g�T�[�`
        /// <summary>
        /// �ŏI����v�����^���X�g����w��̃f�[�^���T�[�`���܂�
        /// </summary>
        /// <param name="lastTimes">�ŏI����v�����^���X�g</param>
        /// <param name="dialogMode">�_�C�A���O���[�h</param>
        /// <param name="selectFlag">�I���t���O</param>
        /// <param name="lastPrinters">���[�g�p�敪</param>
        /// <returns>�ŏI����v�����^(������Ȃ������Ƃ���Null��Ԃ�)</returns>
        public LastPrtPrinter FindLastPrtPrinter(List<LastPrtPrinter> lastPrinters, Int32 dialogMode, Int32 selectFlag, Int32 printPaperUseDivcd)
        {
            if (lastPrinters == null) return null;
            return lastPrinters.Find(delegate(LastPrtPrinter ptm) { return ((ptm.DialogMode == dialogMode) && (ptm.SelectFlag == selectFlag) && (ptm.PrintPaperUseDivcd == printPaperUseDivcd)); });
        }
        #endregion

        #region private methods

        #region ���R���\�ŏI����v�����^�f�V���A���C�Y����
        /// <summary>
        /// XML���玩�R���\�ŏI����v�����^�N���X�փf�V���A���C�Y���܂�
        /// </summary>
        /// <returns>Dictionary<string,DateTime></returns>
        private List<LastPrtPrinter> XmlDeserialize()
        {
            return (List<LastPrtPrinter>)UserSettingController.DeserializeUserSetting(this._xmlLastPrterFileName, typeof(List<LastPrtPrinter>));
        }
        #endregion

        #region ���R���[���o��������List�V���A���C�Y����
        /// <summary>
        /// ���R���[���o����List�V���A���C�Y����
        /// </summary>
        /// <param name="lastTimes">�V���A���C�Y�Ώێ��R���[�ŏI����v�����^�f�B�N�V���i��</param>
        /// <param name="fileName">�V���A���C�Y�t�@�C����</param>
        private void Serialize(List<LastPrtPrinter> lastTimes, string fileName)
        {
            try
            {
                //�i�[�f�B���N�g�����Ȃ���΍쐬
                if (System.IO.Directory.Exists(ConstantManagement_ClientDirectory.Temp_UserTemp) == false)
                {
                    System.IO.Directory.CreateDirectory(ConstantManagement_ClientDirectory.Temp_UserTemp);
                }
                UserSettingController.SerializeUserSetting(lastTimes, _xmlLastPrterFileName);
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
    /// �ŏI����v�����^�ێ��p�̃f�[�^�N���X
    /// </summary>
    public class LastPrtPrinter
    {
        public LastPrtPrinter()
        {
        }
        public Int32 DialogMode;           // �_�C�A���O�\�����[�h0:�v�����^�A���[�I���@1:�v�����^�ݒ�̂݁i�ꊇ����p�j
        public Int32 SelectFlag;           // �I���t���O�i10:���[,20:DM�j
        public Int32 PrinterMngNo;         // �v�����^�Ǘ��ԍ�
        public Int32 PrintPaperUseDivcd;   // ���[�g�p�敪 (1:���[,2:�`�[,3:DM�ꗗ�\,4:DM�͂���)
        public string PrinterName;
    }
}
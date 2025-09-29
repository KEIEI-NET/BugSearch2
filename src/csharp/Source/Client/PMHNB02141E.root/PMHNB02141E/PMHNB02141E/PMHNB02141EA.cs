using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �o�׏��i�D�ǑΉ��\���o�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �o�׏��i�D�ǑΉ��\���o�N���X</br>
    /// <br>Programmer : 30452 ��� �r��</br>
    /// <br>Date       : 2008.11.14</br>
    /// <br>           : </br>
    /// </remarks>
    public class PMHNB02141EA
    {
        #region �� �R���X�g���N�^
        /// <summary>
        /// �o�׏��i�D�ǑΉ��\���o�N���X�R���X�g���N�^
        /// </summary>
        public PMHNB02141EA(object printInfo)
        {
            // ������
            this._printInfo = printInfo as SFCMN06002C;

            this._shipGdsPrimeListAsc = new ShipGdsPrimeListAsc();
            this._shipGdsPrimeListCndtn = this._printInfo.jyoken as ShipGdsPrimeListCndtn;
        }
        #endregion

        #region �� private�萔
        private const string ct_PGID = "PMHNB02141E";
        #endregion

        #region �� private�ϐ�
        private SFCMN06002C _printInfo = null;			               // ������N���X

        private ShipGdsPrimeListAsc _shipGdsPrimeListAsc = null; // �o�׏��i�D�ǑΉ��\�A�N�Z�X�N���X
        private ShipGdsPrimeListCndtn _shipGdsPrimeListCndtn = null; // �o�׏��i�D�ǑΉ��\���o�����N���X
        #endregion

        #region �� IExtrProc �����o
        #region �� Public Property
        /// <summary>
        /// ������N���X�v���p�e�B
        /// </summary>
        public SFCMN06002C Printinfo
        {
            get { return this._printInfo; }
            set { this._printInfo = value; }
        }
        #endregion

        #region �� Public Method
        #region �� ���o����
        /// <summary>
        /// ���o����
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ����̃��C���������s���܂��B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.11.14</br>
        /// </remarks>
        public int ExtrPrintData()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            // ���o����ʕ��i�̃C���X�^���X���쐬
            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // �\��������ݒ�
            form.Title = "���o��";
            form.Message = "���݁A�f�[�^�𒊏o���ł��B";

            try
            {
                form.Show();			// �_�C�A���O�\��
                status = this.ExtraProc();	// ���o�������s
            }
            finally
            {
                // �_�C�A���O�����
                form.Close();
                this._printInfo.status = status;
            }

            return status;
        }
        #endregion
        #endregion
        #endregion

        #region �� Private���\�b�h
        #region �� ���o���C������
        /// <summary>
        /// ���o���C������
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���o�̃��C���������s���܂��B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.11.14</br>
        /// </remarks>
        private int ExtraProc()
        {
            string errMsg = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                status = this._shipGdsPrimeListAsc.SearchMain(this._shipGdsPrimeListCndtn, out errMsg);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // ����f�[�^�擾
                    this._printInfo.rdData = this._shipGdsPrimeListAsc.ShipGdsPrimeListDataView;
                }
            }
            catch (Exception ex)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                // �߂�l��ݒ�B�ُ�̏ꍇ�̓��b�Z�[�W��\��
                switch (status)
                {
                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                        {
                            break;
                        }
                    default:
                        {
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, ct_PGID, errMsg, status,
                                        MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            break;
                        }
                }
            }
            return status;
        }
        #endregion

        #region �� �G���[���b�Z�[�W�\��
        /// <summary>
        /// �G���[���b�Z�[�W�\��
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="iMsg">�G���[���b�Z�[�W</param>
        /// <param name="iSt">�G���[�X�e�[�^�X</param>
        /// <param name="iButton">�\���{�^��</param>
        /// <param name="iDefButton">�����t�H�[�J�X�{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W��\�����܂��B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.11.14</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, ct_PGID, iMsg, iSt, iButton, iDefButton);
        }
        #endregion
        #endregion
    }
}

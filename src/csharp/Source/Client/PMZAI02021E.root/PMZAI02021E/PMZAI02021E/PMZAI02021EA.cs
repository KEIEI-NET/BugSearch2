using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using System.Data;

namespace Broadleaf.Application.UIData
{

    /// <summary>
    /// ���R���[�i�݌Ƀ}�X�^�ꗗ�j���o�N���X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���R���[�i�݌Ƀ}�X�^�ꗗ�jUI�t�H�[���N���X</br>
    /// <br>Programmer : 30413 ����</br>
    /// <br>Date       : 2009.01.13</br>
    /// <br></br>
    /// <br>UpdateNote : </br>
    /// <br>           : </br>
    /// </remarks>
    public class PMZAI02021EA : IExtrProc
    {
        #region [private �t�B�[���h]
        private SFCMN06002C _printInfo = null;                  // ������N���X
        private StockMasterTblAcs _stockMasterTblAcs = null;    // ���R���[�i�݌Ƀ}�X�^�ꗗ�j�A�N�Z�X�N���X
        #endregion

        #region [private const �t�B�[���h]
        /// <summary>�v���O����ID (�A�Z���u����)</summary>
        private const string ct_PGID = "PMZAI02021E";
        #endregion

        #region [�R���X�g���N�^]
		/// <summary>
		/// ���R���[�i�݌Ƀ}�X�^�ꗗ�j���o�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���R���[�i�݌Ƀ}�X�^�ꗗ�jUI�N���X</br>
		/// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009.01.13</br>
		/// <br></br>
		/// </remarks>
        public PMZAI02021EA( object printInfo )
        {
            // ������
            this._printInfo = printInfo as SFCMN06002C;
            this._stockMasterTblAcs = new StockMasterTblAcs();
        }
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
		#endregion �� Public Property

		#region �� Public Method
		#region �� ���o����
		/// <summary>
        /// ���o����
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ����̃��C���������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009.01.13</br>
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
		#endregion �� Public Method
		#endregion �� IExtrProc �����o

		#region �� Private Method
		#region �� ���o���C������
		/// <summary>
        /// ���o���C������
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���o�̃��C���������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009.01.13</br>
        /// </remarks>
        private int ExtraProc()
        {
            string errMsg = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
				// �݌Ƀ}�X�^�ꗗ�f�[�^�擾
                status = this._stockMasterTblAcs.SearchStockMasterTbl(this._printInfo.jyoken, out errMsg );
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
                {
					// ����f�[�^�擾
                    this._printInfo.rdData = this._stockMasterTblAcs.PrintDataSet;
                }
            }
            catch (Exception ex)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                // �߂�l��ݒ�B�ُ�̏ꍇ�̓��b�Z�[�W��\��
                switch ( status )
                {
                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                        {
                            break;
                        }
                    default:
                        {
							// �X�e�[�^�X���ȏ�̂Ƃ��̓��b�Z�[�W��\��
                            TMsgDisp.Show( emErrorLevel.ERR_LEVEL_STOPDISP, ct_PGID, errMsg, status,
                                        MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                            break;
                        }
                }
            }
            return status;
		}
		#endregion �� ���o���C������

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
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009.01.13</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, ct_PGID, iMsg, iSt, iButton, iDefButton);
        }
		#endregion �� �G���[���b�Z�[�W�\��
        #endregion
	}
}

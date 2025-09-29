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
    /// ���R���[�i�������j���o�N���X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���R���[�i�������jUI�t�H�[���N���X</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2008.06.17</br>
    /// <br></br>
    /// <br>UpdateNote : 2010/07/22  22018 ��� ���b</br>
    /// <br>           : �A�E�g�I�u�������Ή��ׁ̈A�L�����Z���������ύX�B</br>
    /// </remarks>
    public class PMKAU08000EA : IExtrProc
    {
        #region [private �t�B�[���h]
        private SFCMN06002C _printInfo = null;      // ������N���X
        private FrePBillAcs _frePBillAcs = null;    // ���R���[�i�������j�A�N�Z�X�N���X
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
        Broadleaf.Windows.Forms.SFCMN00299CA _progressForm;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
        #endregion

        #region [private const �t�B�[���h]
        /// <summary>�v���O����ID (�A�Z���u����)</summary>
        private const string ct_PGID = "PMKAU08000E";
        #endregion

        #region [�R���X�g���N�^]
		/// <summary>
		/// ���R���[�i�������j���o�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���R���[�i�������jUI�N���X</br>
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2008.06.17</br>
		/// <br></br>
		/// </remarks>
        public PMKAU08000EA( object printInfo )
        {
            // ������
            this._printInfo = printInfo as SFCMN06002C;
            this._frePBillAcs = new FrePBillAcs();
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
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public int ExtrPrintData()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            
            // --- DEL m.suzuki 2010/07/22 ---------->>>>>
            //// ���o����ʕ��i�̃C���X�^���X���쐬
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 DEL
            ////Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 DEL
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
            //_progressForm = new Broadleaf.Windows.Forms.SFCMN00299CA();
            //Broadleaf.Windows.Forms.SFCMN00299CA form = _progressForm;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
            //// �\��������ݒ�
            //form.Title = "���o��";
            //form.Message = "���݁A�f�[�^�𒊏o���ł��B";
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
            //form.DispCancelButton = true;
            //form.CancelButtonClick += new EventHandler( form_CancelButtonClick );
            //form.CancelButtonClick += new EventHandler( this._frePBillAcs.CancelButtonClick );
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
            // --- UPD m.suzuki 2010/07/22 ----------<<<<<

            try
            {
                // --- DEL m.suzuki 2010/07/22 ---------->>>>>
                //form.Show();			// �_�C�A���O�\��
                // --- DEL m.suzuki 2010/07/22 ----------<<<<<
                status = this.ExtraProc();	// ���o�������s
            }
            finally
            {
                // --- DEL m.suzuki 2010/07/22 ---------->>>>>
                //// �_�C�A���O�����
                //form.Close();
                // --- DEL m.suzuki 2010/07/22 ----------<<<<<
                this._printInfo.status = status;
            }

            return status;
		}
        // --- DEL m.suzuki 2010/07/22 ---------->>>>>
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //void form_CancelButtonClick( object sender, EventArgs e )
        //{
        //    if ( _progressForm != null )
        //    {
        //        _progressForm.Message = "�����𒆒f���܂��B";
        //    }
        //}
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
        /// <summary>
        /// ���o�L�����Z������
        /// </summary>
        public void Cancel()
        {
            // �A�N�Z�X�N���X�̒��o�L�����Z���������Ăяo��
            this._frePBillAcs.CancelButtonClick( this, new EventArgs() );
        }
        // --- DEL m.suzuki 2010/07/22 ----------<<<<<
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
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private int ExtraProc()
        {
            string errMsg = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
				// Todo:Search Method Call
                status = this._frePBillAcs.SearchMain( this._printInfo.jyoken, (DataView)this._printInfo.rdData, out errMsg );
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
                {
					// ����f�[�^�擾
                    this._printInfo.rdData = this._frePBillAcs.PrintDataSet;
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
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, ct_PGID, iMsg, iSt, iButton, iDefButton);
        }
		#endregion �� �G���[���b�Z�[�W�\��
        #endregion
	}
}

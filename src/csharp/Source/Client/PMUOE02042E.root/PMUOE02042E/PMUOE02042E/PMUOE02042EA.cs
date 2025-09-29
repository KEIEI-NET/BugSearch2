using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Application.UIData
{

    /// <summary>
    /// ���s�m�F�ꗗ�\���o�N���X
    /// </summary>
    /// <remarks>
	/// <br>Note       : ���s�m�F�ꗗ�\UI�t�H�[���N���X</br>
    /// <br>Programmer : 30009 �a�J ���</br>
    /// <br>Date       : 2008.12.2</br>
    /// <br></br>
    /// </remarks>
    public class PMUOE02042EA : IExtrProc
    {
		# region Constractor
		/// <summary>
		/// ���s�m�F�ꗗ�\���o�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���s�m�F�ꗗ�\UI�N���X</br>
        /// <br>Programmer : 30009 �a�J ���</br>
        /// <br>Date       : 2008.12.2</br>
        /// <br></br>
		/// </remarks>
        public PMUOE02042EA( object printInfo )
        {
			// ������N���X
			this._printInfo = printInfo as SFCMN06002C;

			// ���o�����N���X
			this._extraInfo = this._printInfo.jyoken as PublicationConfOrderCndtn;

			// ���s�m�F�ꗗ�\�A�N�Z�X�N���X
			this._publicationConfListAcs = new PublicationConfListAcs();
        }
        # endregion

		# region Private Menbers
		/// <summary> ������N���X </summary>
		private SFCMN06002C _printInfo = null;
		/// <summary> ���o�����N���X </summary>
        private PublicationConfOrderCndtn _extraInfo = null;
		/// <summary> ���s�m�F�ꗗ�\�A�N�Z�X�N���X </summary>
        private PublicationConfListAcs _publicationConfListAcs = null;
		# endregion

		# region Private const Menbers
		/// <summary> �v���O����ID </summary>
		private const string ct_PGID = "PMUOE02042E";
		# endregion


		# region �� IExtrProc �C���^�[�t�F�[�X
		# region Public Property
		/// <summary> ������N���X�v���p�e�B </summary>
		public SFCMN06002C Printinfo
        {
            get { return this._printInfo; }
            set { this._printInfo = value; }
		}
		# endregion

		#region Public Method
		/// <summary>
		/// ���o����
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note		: ����̃��C���������s���܂��B</br>
        /// <br>Programmer : 30009 �a�J ���</br>
        /// <br>Date       : 2008.12.2</br>
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
				// �_�C�A���O�\��
                form.Show();
				// ���o�������s
                status = this.ExtraProc();
            }
            finally
            {
                form.Close();
                this._printInfo.status = status;
            }

            return status;
		}
		# endregion
		# endregion

		# region Private Method
		/// <summary>
		/// ���o�������C������
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note		: ����̃��C���������s���܂��B</br>
        /// <br>Programmer : 30009 �a�J ���</br>
        /// <br>Date       : 2008.12.2</br>
        /// </remarks>
        private int ExtraProc()
        {
            string errMsg = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                // ���s�m�F�m�F�f�[�^�擾
                status = this._publicationConfListAcs.SearchConfirmPublicationConf(this._extraInfo, out errMsg);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
					// �t�B���^�[������
					string strFilter = "";
					// �\�[�g��������擾
					string strSort = this.MakeSortingOrderString();
					// ���o���ʃe�[�u������w�肳�ꂽ�t�B���^�E�\�[�g�����Ńf�[�^�r���[���쐬
                    DataView dv = new DataView(this._publicationConfListAcs.PublicationConfDs.Tables[PMUOE02049EA.ct_Tbl_PublicationConfDtl], strFilter, strSort, DataViewRowState.CurrentRows);
                    if (dv.Count > 0)
					{
						// �f�[�^���Z�b�g
						this._printInfo.rdData = dv;
					}
					// �Y���f�[�^����
					else
					{
						status = (int)ConstantManagement.DB_Status.ctDB_EOF;
					}
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
                            TMsgDisp.Show( emErrorLevel.ERR_LEVEL_STOPDISP, ct_PGID, errMsg, status,
                                        MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                            break;
                        }
                }
            }
            return status;
		}

		/// <summary>
		/// �\�[�g������쐬����
		/// </summary>
		/// <returns>�\�[�g������</returns>
		/// <remarks>
		/// <br>Note       : �\�[�g��������쐬���܂��B</br>
        /// <br>Programmer : 30009 �a�J ���</br>
        /// <br>Date       : 2008.12.2</br>
        /// </remarks>
		private string MakeSortingOrderString()
		{
			string sortStr = "";

            // ���_
            this.MakeSortQuery(ref sortStr, PMUOE02049EA.ct_Col_SectionCode, 0);

            // �I�����C���ԍ�
            this.MakeSortQuery(ref sortStr, PMUOE02049EA.ct_Col_OnlineNo, 0);

            // �I�����C���s�ԍ�
            this.MakeSortQuery(ref sortStr, PMUOE02049EA.ct_Col_OnlineRowNo, 0);

			return sortStr;
		}

		/// <summary>
		/// �\�[�g�p������쐬����
		/// </summary>
		/// <param name="colName">�񖼏�</param>
		/// <param name="ascDescDiv">�����E�~���敪[0:����, 1:�~��]</param>
		/// <param name="strQuery">�\�[�g�p������</param>
		/// <remarks>
		/// <br>Note       : �\�[�g�p�̕�����̍쐬���s���܂��B</br>
        /// <br>Programmer : 30009 �a�J ���</br>
        /// <br>Date       : 2008.12.2</br>
        /// </remarks>
		private void MakeSortQuery(ref string strQuery, string colName, int ascDescDiv)
		{
			if (strQuery == null)
			{
				strQuery = "";
			}

			if (strQuery == "")
			{
				strQuery += String.Format("{0} {1}", colName, (ascDescDiv == 0 ? "ASC" : "DESC"));
			}
			else
			{
				strQuery += String.Format(", {0} {1}", colName, (ascDescDiv == 0 ? "ASC" : "DESC"));
			}
		}

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
        /// <br>Programmer : 30009 �a�J ���</br>
        /// <br>Date       : 2008.12.2</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, ct_PGID, iMsg, iSt, iButton, iDefButton);
        }
        # endregion
	}
}

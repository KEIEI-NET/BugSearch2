//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����A�g�e�L�X�g�o��
// �v���O�����T�v   : ����A�g�e�L�X�g�o�͒��[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570219-00     �쐬�S�� : �c����
// �� �� ��  2019/12/02      �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11675168-00     �쐬�S�� : �i�N
// �� �� ��  2021/08/03      �C�����e : PMKOBETSU-4115 PDF�o�͊�����Q�̑Ή�
//----------------------------------------------------------------------------//

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
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.UIData
{

    /// <summary>
    /// ����f�[�^�e�L�X�g���o�N���X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����f�[�^�e�L�X�gUI�t�H�[���N���X</br>
    /// <br>Programmer : �c����</br>
    /// <br>Date       : 2019/12/02</br>
    /// <br>UpdateNote : PMKOBETSU-4115 PDF�o�͊�����Q�̑Ή�</br>
    /// <br>Programmer : �i�N</br>
    /// <br>Date       : 2021/08/03</br>
    /// </remarks>
    public class PMSDC02011EA : IExtrProc
    {
        #region �� Constructor
        /// <summary>
        /// ����f�[�^�e�L�X�g���o�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����f�[�^�e�L�X�gUI�N���X</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// <br></br>
        /// </remarks>
        public PMSDC02011EA(object printInfo)
        {
            // ������
            this._printInfo = printInfo as SFCMN06002C;
            this._salesCprtAcs = new SalesCprtAcs();
            this._salesHistoryCndtn = this._printInfo.jyoken as SalesCprtCndtnWork;
        }
        #endregion �� Constructor

        #region �� private member
        private SFCMN06002C _printInfo = null;			        // ������N���X
        private SalesCprtAcs _salesCprtAcs = null;		// ����A�g�f�[�^�e�L�X�g�A�N�Z�X�N���X
        private SalesCprtCndtnWork _salesHistoryCndtn = null;	// ����A�g�f�[�^�e�L�X�g���o�����N���X
        #endregion �� private member

        #region �� private const
        private const string ct_PGID = "PMSDC02011E";
        #endregion �� private const


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
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
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
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// <br>UpdateNote : PMKOBETSU-4115 PDF�o�͊�����Q�̑Ή�</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2021/08/03</br>
        /// </remarks>
        private int ExtraProc()
        {
            string errMsg = "";
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            DataTable printdataTable = new DataTable();
            try
            {
                if (_salesHistoryCndtn.Mode == 0)
                {
                    // --- ADD �i�N 2021/08/03 PMKOBETSU-4115 PDF�o�͊�����Q�̑Ή� ----->>>>>
                    SalCprtConnectInfoWork connectInfoWork = null;
                    SalCprtConnectInfoWorkAcs connectInfoWorkAcs = new SalCprtConnectInfoWorkAcs();

                    // �ڑ�����ݒ�}�X�^���擾
                    status = connectInfoWorkAcs.Read(out connectInfoWork, _salesHistoryCndtn.EnterpriseCode, 0, _salesHistoryCndtn.SectionCode, _salesHistoryCndtn.CustomerCode);
                    // --- ADD �i�N 2021/08/03 PMKOBETSU-4115 PDF�o�͊�����Q�̑Ή� -----<<<<<

                    // ����f�[�^�擾
                    // --- UPD �i�N 2021/08/03 PMKOBETSU-4115 PDF�o�͊�����Q�̑Ή� ----->>>>>
                    //status = this._salesCprtAcs.SearchSalesHistoryProcMain(this._salesHistoryCndtn, out errMsg);
                    if (connectInfoWork != null && status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        status = this._salesCprtAcs.SearchSalesHistoryProcMain(this._salesHistoryCndtn, out errMsg, connectInfoWork);
                    }
                    // --- ADD �i�N 2021/08/03 PMKOBETSU-4115 PDF�o�͊�����Q�̑Ή� -----<<<<<

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // ����f�[�^�擾
                        this._printInfo.rdData = this._salesCprtAcs.GetprintdataTable();
                    }
                }
                else
                {
                    if (this._printInfo.rdData != null)
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
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
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        }
                    case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                        {
                            break;
                        }
                    default:
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, ct_PGID, iMsg, iSt, iButton, iDefButton);
        }

        #endregion �� �G���[���b�Z�[�W�\��
        #endregion
    }
}

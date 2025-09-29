//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �e�L�X�g�o�͑��샍�O�o�^�y�яo�͎��A���[�g���b�Z�[�W�\������
// �v���O�����T�v   : �e�L�X�g�o�͑��샍�O�o�^�y�яo�͎��A���[�g���b�Z�[�W�\���������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570163-00  �쐬�S�� : �c����
// �� �� ��  K2019/08/12  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570217-00  �쐬�S�� : ���c�`�[
// �� �� ��  2019/11/15   �C�����e : �i�C�����e�ꗗNo.1�j�e�L�X�g�o�̓��b�Z�[�W����
//----------------------------------------------------------------------------//
using System;
using System.IO;
using System.Data;
using System.Text;
using Microsoft.Win32;
using System.Reflection;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Net.NetworkInformation;

using Broadleaf.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �e�L�X�g�o�͑��샍�O�o�^�y�яo�͎��A���[�g���b�Z�[�W�\�������X�N���X
    /// </summary>
    /// <remarks>
    /// Note       : �e�L�X�g�o�͑��샍�O�o�^�y�яo�͎��A���[�g���b�Z�[�W�\�������ł��B<br/>
    /// Programmer : �c����<br/>
    /// Date       : K2019/08/12<br/>
    /// </remarks>
    public class TextOutPutOprtnHisLogAcs
    {
        # region �� Constructor ��
        /// <summary>
        /// �f�t�H���g���N�^
        /// </summary>
        /// <remarks>
        /// Note       : �f�t�H���g���N�^<br/>
        /// Programmer : �c����<br/>
        /// Date       : K2019/08/12<br/>
        /// </remarks>
        public TextOutPutOprtnHisLogAcs()
        {
            // �ϐ�������
            this.ITextOutPutOprtnHisLogDBObj = (ITextOutPutOprtnHisLogDB)MediationTextOutPutOprtnHisLogDB.GetDataCopyDB();
        }
        # endregion �� Constructor ��

        # region �� Private Members ��
        private ITextOutPutOprtnHisLogDB ITextOutPutOprtnHisLogDBObj;

        /// <summary>
        /// �Ăяo�����I�u�W�F�N�g�̃A�Z���u�����C���f�b�N�X�񋓑�
        /// </summary>
        private enum SenderInfoIdx : int
        {
            /// <summary>���O�f�[�^�ΏۃA�Z���u��ID</summary>
            LogDataObjAssemblyID,
            /// <summary>���O�f�[�^�ΏۃN���XID</summary>
            LogDataObjClassID,
            /// <summary>���O�f�[�^�V�X�e���o�[�W����</summary>
            LogDataSystemVersion
        }
        # endregion �� Private Members ��

        # region �� Const Members ��
        /// <summary>�ő又�����x��</summary>
        private const int MAX_LEVEL = 99;

        # endregion �� Const Members ��

        #region �� �e�L�X�g�o�͑��샍�O�o�^�y�яo�͎��A���[�g���b�Z�[�W�\������ ��

        /// <summary>
        /// �A���[�g���b�Z�[�W�\������
        /// </summary>
        /// <param name="sender">�Ăяo�����I�u�W�F�N�g</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>���s���ʏ��</returns>
        /// <remarks>
        /// <br>Note       : �A���[�g���b�Z�[�W�\���������s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : K2019/08/12</br>
        /// </remarks>
        public int ShowTextOutPut(object sender,out string errMsg)
        {
            // �����X�e�[�^�X
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // �G���[���b�Z�[�W
            errMsg = string.Empty;

            try
            {
                // �A���[�g�\��
                DialogResult dialogResult = BeforeTextOutput.ShowDialog((IWin32Window)sender);

                // OK�{�^�����������ꍇ
                if (dialogResult == DialogResult.Yes)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                errMsg = ex.Message;
                this.WriteErrorLog(ex, "TextOutPutOprtnHisLogAcs.ShowTextOutput", status);
            }
            return status;
        }

        /// <summary>
        /// �e�L�X�g�o�͑��샍�O�o�^�y�яo�͎��A���[�g���b�Z�[�W�\������
        /// </summary>
        /// <param name="sender">�Ăяo�����I�u�W�F�N�g</param>
        /// <param name="textOutPutOprtnHisLogWorkObj">�o�^�p���[�N�N���X</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>���s���ʏ��</returns>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�͑��샍�O�o�^�y�яo�͎��A���[�g���b�Z�[�W�\���������s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : K2019/08/12</br>
        /// </remarks>
        public int Write(object sender, ref TextOutPutOprtnHisLogWork textOutPutOprtnHisLogWorkObj, out string errMsg)
        {
            // �����X�e�[�^�X
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                // �e�L�X�g�o�͑��샍�O�o�^�p���[�N�쐬
                this.SetTextOutPutOprtnHisLogWork(sender, ref textOutPutOprtnHisLogWorkObj);

                object textOutPutObj = (object)textOutPutOprtnHisLogWorkObj;
                // �e�L�X�g�o�͑��샍�O�o�^
                status = this.ITextOutPutOprtnHisLogDBObj.Write(ref textOutPutObj, out errMsg);

                // �A���[�g���b�Z�[�W�\��
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    textOutPutOprtnHisLogWorkObj = textOutPutObj as TextOutPutOprtnHisLogWork;
                }
                else
                {
                    // �Ȃ�
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                this.WriteErrorLog(ex, "TextOutPutOprtnHisLogAcs.Write", status);
                errMsg = ex.Message;
            }
            return status;
        }

        /// <summary>
        /// �e�L�X�g�o�͑��샍�O�o�^�p���[�N�Z�b�g
        /// </summary>
        /// <param name="sender">�Ăяo�����I�u�W�F�N�g</param>
        /// <param name="textOutPutOprtnHisLogWork">�o�^�p���[�N�N���X</param>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�͑��샍�O�o�^�p���[�N�Z�b�g�������s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : K2019/08/12</br>
        /// </remarks>
        private void SetTextOutPutOprtnHisLogWork(object sender, ref TextOutPutOprtnHisLogWork textOutPutOprtnHisLogWork)
        {
            try
            {
                // ��ƃR�[�h
                textOutPutOprtnHisLogWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                // ���O�f�[�^�쐬����
                if (textOutPutOprtnHisLogWork.LogDataCreateDateTime == DateTime.MinValue)
                {
                    textOutPutOprtnHisLogWork.LogDataCreateDateTime = DateTime.Now;
                }
                // ���O�C�����_�R�[�h
                textOutPutOprtnHisLogWork.LoginSectionCd = LoginInfoAcquisition.Employee.BelongSectionCode;
                // ���O�f�[�^��ʋ敪�R�[�h
                textOutPutOprtnHisLogWork.LogDataKindCd = 0;
                // ���O�f�[�^�[����
                textOutPutOprtnHisLogWork.LogDataMachineName = Environment.MachineName;
                // ���O�f�[�^�S���҃R�[�h
                textOutPutOprtnHisLogWork.LogDataAgentCd = LoginInfoAcquisition.Employee.EmployeeCode.Trim();
                // ���O�f�[�^�S���Җ�
                textOutPutOprtnHisLogWork.LogDataAgentNm = LoginInfoAcquisition.Employee.Name;
                // ���O�f�[�^�I�y���[�V�����R�[�h
                textOutPutOprtnHisLogWork.LogDataOperationCd = 8;

                string[] senderInfos = GetSenderInfo(sender);
                {
                    // ���O�f�[�^�ΏۃN���XID
                    textOutPutOprtnHisLogWork.LogDataObjClassID = senderInfos[(int)SenderInfoIdx.LogDataObjClassID];

                    // ���O�f�[�^�I�y���[�^�[�f�[�^�������x��
                    if (LoginInfoAcquisition.Employee.AuthorityLevel1 <= MAX_LEVEL)
                    {
                        textOutPutOprtnHisLogWork.LogOperaterDtProcLvl = LoginInfoAcquisition.Employee.AuthorityLevel1.ToString();
                    }
                    else
                    {
                        textOutPutOprtnHisLogWork.LogOperaterDtProcLvl = MAX_LEVEL.ToString();
                    }
                    // ���O�f�[�^�I�y���[�^�[�@�\�������x��
                    if (LoginInfoAcquisition.Employee.AuthorityLevel2 <= MAX_LEVEL)
                    {
                        textOutPutOprtnHisLogWork.LogOperaterFuncLvl = LoginInfoAcquisition.Employee.AuthorityLevel2.ToString();
                    }
                    else
                    {
                        textOutPutOprtnHisLogWork.LogOperaterFuncLvl = MAX_LEVEL.ToString();
                    }
                    // ���O�f�[�^�V�X�e���o�[�W����
                    textOutPutOprtnHisLogWork.LogDataSystemVersion = senderInfos[(int)SenderInfoIdx.LogDataSystemVersion];
                }

                // ���O�I�y���[�V�����X�e�[�^�X
                textOutPutOprtnHisLogWork.LogOperationStatus = 0;
            }
            catch (Exception ex)
            {
                this.WriteErrorLog(ex, "TextOutPutOprtnHisLogAcs.SetTextOutPutOprtnHisLogWork", 1000);
            }
        }

        /// <summary>
        /// �Ăяo�����I�u�W�F�N�g���擾
        /// </summary>
        /// <param name="sender">�Ăяo�����I�u�W�F�N�g</param>
        /// <returns>
        /// �Ăяo�����I�u�W�F�N�g���<br/>
        /// [0]:���O�f�[�^�ΏۃA�Z���u��ID<br/>
        /// [1]:���O�f�[�^�ΏۃN���XID<br/>
        /// [2]:���O�f�[�^�V�X�e���o�[�W����
        /// </returns>
        /// <remarks>
        /// <br>Note       : �Ăяo�����I�u�W�F�N�g���擾�������s��</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : K2019/08/12</br>
        /// </remarks>
        private static string[] GetSenderInfo(object sender)
        {
            string[] senderInfoArray = new string[3] { string.Empty, string.Empty, string.Empty };

            if (sender != null)
            {
                Type senderType = sender.GetType();
                AssemblyName assemblyName = senderType.Assembly.GetName();

                if (assemblyName != null)
                {
                    senderInfoArray[(int)SenderInfoIdx.LogDataObjAssemblyID] = assemblyName.Name;
                    senderInfoArray[(int)SenderInfoIdx.LogDataSystemVersion] = assemblyName.Version.ToString();
                }

                if (senderType != null) senderInfoArray[(int)SenderInfoIdx.LogDataObjClassID] = senderType.Name;
            }

            return senderInfoArray;
        }
        #endregion

        #region �� �G���[���O�o�͏��� ��
        /// <summary>
        /// �G���[���O�o�͏���
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <param name="errorText">�G���[���e</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �G���[���O�o�͂��s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : K2019/08/12</br>
        /// </remarks>
        private void WriteErrorLog(Exception ex, string errorText, int status)
        {
            string message = string.Empty;

            if (ex != null)
            {
                message = string.Concat(new object[] { "Index #", 0, "\nMessage: ", ex.Message, "\n", errorText, "\nSource: ", ex.Source, "\nStatus = ", status.ToString(), "\n" });
                new ClientLogTextOut().Output(ex.Source, message, status, ex);
            }
            else
            {
                new ClientLogTextOut().Output(base.GetType().Assembly.GetName().Name, errorText, status);
            }
        }
        #endregion

    }

    /// <summary>
    /// �e�L�X�g�o�͂̊m�F�_�C�A���O�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// Note       : �e�L�X�g�o�͂̊m�F�_�C�A���O�t�H�[���\������<br/>
    /// Programmer : �c����<br/>
    /// Date       : K2019/08/12<br/>
    /// </remarks>
    public class BeforeTextOutput
    {
        /// <summary>
        /// �e�L�X�g�o�͂̊m�F�_�C�A���O�t�H�[���N���X��\������
        /// </summary>
        /// <param name="owner">�e��ʑΏ�</param>
        /// <returns>�I������</returns>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�͂̊m�F�_�C�A���O�t�H�[���N���X��\�����鏈�����s��</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : K2019/08/12</br>
        /// </remarks>
        public static DialogResult ShowDialog(IWin32Window owner)
        {
            DialogResult dlgResult = DialogResult.Cancel;

            try
            {
                // �f�[�^�����������݂���ꍇ�͑I����ʂ�\������
                BeforeTextOutputDialog form = new BeforeTextOutputDialog();
                try
                {
                    dlgResult = form.ShowDialog(owner);
                }
                finally
                {
                    form.Dispose();
                    form = null;
                }

            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }

            return dlgResult;
        }
    }
}

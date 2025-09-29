//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ��M�G���[�`�F�b�N����
// �v���O�����T�v   : ���[�U�f�[�^�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2011/07/28  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  2011/09/05  �쐬�S�� : ������
// �C �� ��              �C�����e : #24361 ���_�Ǘ�������M�풓PG
//                                  �A�N�Z�X�N���X�̘_���폜�ɂ���
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ��M�G���[�`�F�b�N�A�N�Z�X�N���X
    /// </summary>
    public class OprtnHisLogAcs
    {
        #region private
        IOprtnHisLogDB iOprtnHisLogDB;
        string _dataMsg = "��������M�G���[";
        ArrayList workList = new ArrayList();
        #endregion

        #region �R���X�g���N�^
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public OprtnHisLogAcs()
        {

        }
        #endregion

        #region ���W�b�N����
        /// <summary>
        /// �w�肳�ꂽ�����̑��엚�����O�f�[�^���LIST��߂��܂�
        /// </summary>
        /// <param name="list">��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̑��엚�����O�f�[�^�����������܂�</br>
        /// <br>Programmer : sundx</br>
        /// <br>Date       : 2011.08.04</br>
        public void SearchLog(out ArrayList list)
        {
            list = new ArrayList();
            object obj = new object();
            if(iOprtnHisLogDB == null)
            {
                iOprtnHisLogDB = MediationOprtnHisLogDB.GetOprtnHisLogDB();
            }
            //���������N���X�\�z
            OprtnHisLogSrchWork oprtnHisLogSrchWork = new OprtnHisLogSrchWork();
            oprtnHisLogSrchWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            oprtnHisLogSrchWork.LogDataObjAssemblyID = "PMKYO01100U";
            oprtnHisLogSrchWork.St_LogDataCreateDateTime = new DateTime(1800,1,1);
            oprtnHisLogSrchWork.Ed_LogDataCreateDateTime = DateTime.Now;
            oprtnHisLogSrchWork.LogDataKindCd = (int)LogDataKind.ErrorLog;
            oprtnHisLogSrchWork.LogDataOperationCd = 12;

            //�������s��
            int status = iOprtnHisLogDB.Search(ref obj, oprtnHisLogSrchWork, 0, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0);

            workList = (ArrayList)obj;

            //�������ʏ���
            for (int i = 0; i < workList.Count; i++)
            {
                try
                {
                    OprtnHisLogWork oprtnHisLogWork = (OprtnHisLogWork)workList[i];
                    PMKYO01901EA errInfo = new PMKYO01901EA();
                    if (oprtnHisLogWork.LogDataMassage.Contains(_dataMsg))
                    {
                        string[] data = oprtnHisLogWork.LogDataMassage.Split('�@');
                        errInfo.NoFlg = data[1];
                        errInfo.No = data[2];
                        errInfo.Date = data[3];
                        errInfo.SectionCode = data[4];
                        errInfo.SectionNm = data[5];
                        errInfo.CustomerCode = data[6];
                        errInfo.CustomerNm = data[7];
                        errInfo.Error = data[8];
                        list.Add(errInfo);
                    }
                }
                catch { }
            }
        }

        /// <summary>
        /// ���엚�����O�f�[�^����_���폜���܂�
        /// </summary>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���엚�����O�f�[�^����_���폜���܂�</br>
        /// <br>Programmer : sundx</br>
        /// <br>Date       : 2011.08.04</br>
        public void LogicalDelete()
        {
            if (iOprtnHisLogDB == null)
            {
                iOprtnHisLogDB = MediationOprtnHisLogDB.GetOprtnHisLogDB();
            }
            //DEL #24361 ���_�Ǘ�������M�풓PG�A�N�Z�X�N���X�̘_���폜�ɂ���----->>>>>
            //for (int i = 0; i < workList.Count; i++)
            //{
            //    object oprtnHisLogWork = (object)workList[i];
            //    iOprtnHisLogDB.LogicalDelete(ref oprtnHisLogWork);
            //}
            //DEL #24361 ���_�Ǘ�������M�풓PG�A�N�Z�X�N���X�̘_���폜�ɂ���-----<<<<<
            //ADD #24361 ���_�Ǘ�������M�풓PG�A�N�Z�X�N���X�̘_���폜�ɂ���----->>>>>            
            object oprtnHisLogWork = (object)workList;
            iOprtnHisLogDB.LogicalDelete(ref oprtnHisLogWork); 
            //ADD #24361 ���_�Ǘ�������M�풓PG�A�N�Z�X�N���X�̘_���폜�ɂ���-----<<<<<
        }
        #endregion
    }
}

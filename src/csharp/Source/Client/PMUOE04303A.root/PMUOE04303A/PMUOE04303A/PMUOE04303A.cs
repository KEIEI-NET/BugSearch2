using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{

    /// <summary>
    /// DSP���O�f�[�^�Ɖ�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : DSP���O�f�[�^�Ɖ�A�N�Z�X�N���X</br>
    /// <br>Programmer  : 30350 �N��@����</br>
    /// <br>Date        : 2008/12/03</br>
    /// </remarks>
    public class OprationLogOrderAcs
    {
        #region Private Members

        private string _enterpriseCode;

        private IOprtnHisLogDB _oprtnHisLogDB;

        #endregion Private Members


        #region Constructor

        /// <summary>
        /// DSP���O�f�[�^�Ɖ�A�N�Z�X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : DSP���O�f�[�^�Ɖ�A�N�Z�X�N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer  : 30350 �N�� ����</br>
        /// <br>Date        : 2008/11/17</br>
        /// </remarks>
        public OprationLogOrderAcs()
		{
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._oprtnHisLogDB = (IOprtnHisLogDB)MediationOprtnHisLogDB.GetOprtnHisLogDB();

            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._oprtnHisLogDB = null;
            }

            // ��ƃR�[�h���擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="extrInfo">��������</param>
        /// <param name="updHisDspWorkList">�������ʃ��X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        public int Search(OprationLogOrderParam extrInfo, out List<DspRogDataResult> dspRogDataResultList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            dspRogDataResultList = new List<DspRogDataResult>();

            // �N���X�����o�R�s�[����(E��D)
            OprationLogOrderWork paraWork = CopyToInventoryDataDspParamWorkFromOprationLogOrderParam(extrInfo);
            
            ArrayList retList;
            object paraObj = paraWork;
            object retObj = new object();

            try
            {
                status = this._oprtnHisLogDB.SearchUOE(ref retObj, paraObj,0,0);
                if (status == 0)
                {
                    retList = retObj as ArrayList;
                    foreach (OprtnHisLogWork retWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        dspRogDataResultList.Add(CopyToInventoryDataDspResultFromOprationLogOrderWork(retWork));
                    }
                }
            }
            catch
            {
                status = -1;
                dspRogDataResultList = new List<DspRogDataResult>();
            }

            return (status);
        }

        /// <summary>
        /// ���O�f�[�^�폜
        /// </summary>
        /// <param name="extrInfo">��������</param>
        /// <returns>�X�e�[�^�X</returns>
        public int Delete(OprationLogOrderParam opParam)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            OprationLogOrderWork paraWork = CopyToInventoryDataDspParamWorkFromOprationLogOrderParam(opParam);

            try
            {
                status = this._oprtnHisLogDB.DeleteUOE(paraWork);
            }
            catch
            {
                status = -1;
            }
            return status;
        }

        #endregion Public Methods


        #region Private Methods

        /// <summary>
        /// �N���X�����o�R�s�[����(E��D)
        /// </summary>
        /// <param name="para">DSP���O�f�[�^�Ɖ�\�������N���X</param>
        /// <returns>>���엚�����O�������[�N�N���X</returns>
        private OprationLogOrderWork CopyToInventoryDataDspParamWorkFromOprationLogOrderParam(OprationLogOrderParam para)
        {
            OprationLogOrderWork paraWork = new OprationLogOrderWork();

            paraWork.EnterpriseCode = para.EnterpriseCode;
            paraWork.St_LogDataCreateDateTime = para.St_LogDataCreateDateTime;
            paraWork.Ed_LogDataCreateDateTime = para.Ed_LogDataCreateDateTime.AddDays(1);
            paraWork.SectionCodes = para.SectionCodes;
            paraWork.LogDataMachineName = para.LogDataMachineName;
            paraWork.LogDataObjClassID = para.LogDataObjClassID;
            paraWork.LogDataKindCd = para.LogDataKindCd;

            return paraWork;
        }

        /// <summary>
        /// �N���X�����o�R�s�[����(D��E)
        /// </summary>
        /// <param name="retWork">>���엚�����O���ʃ��[�N�N���X</param>
        /// <returns>>DSP���O�f�[�^�Ɖ�ʃN���X</returns>
        private DspRogDataResult CopyToInventoryDataDspResultFromOprationLogOrderWork(OprtnHisLogWork retWork)
        {
            DspRogDataResult ret = new DspRogDataResult();

            ret.EnterpriseCode = retWork.EnterpriseCode;
            ret.Date = retWork.LogDataCreateDateTime;
            ret.TerminalNo = retWork.LogDataMachineName;
            if (retWork.LogDataObjClassID == string.Empty || retWork.LogDataObjClassID == null)
            {
                ret.UOESupplierCd = 0;
            }
            else 
            {
                ret.UOESupplierCd = Int32.Parse(retWork.LogDataObjClassID);
            }
            ret.DspDiv = retWork.LogDataOperationCd;
            ret.DspPGID = retWork.LogDataObjBootProgramNm;
            ret.DspStatus = retWork.LogOperationStatus;
            ret.DspMessage = retWork.LogDataMassage;

            return ret;
        }

        #endregion Private Methods
    }
}

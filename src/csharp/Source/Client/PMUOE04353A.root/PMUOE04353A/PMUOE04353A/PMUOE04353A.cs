
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
    /// �ʐM���O�f�[�^�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : �ʐM���O�f�[�^�Ɖ�A�N�Z�X�N���X</br>
    /// <br>Programmer  : 30350 �N��@����</br>
    /// <br>Date        : 2008/12/03</br>
    /// </remarks>
    public class ComLogOrderAcs
    {
        #region Private Members

        private string _enterpriseCode;

        private IOprtnHisLogDB _oprtnHisLogDB;

        #endregion Private Members


        #region Constructor

        /// <summary>
        /// �ʐM���O�f�[�^�Ɖ�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : �ʐM���O�f�[�^�A�N�Z�X�N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer  : 30350 �N�� ����</br>
        /// <br>Date        : 2008/12/03</br>
        /// </remarks>
        public ComLogOrderAcs()
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
        public int Search(ComLogOrderParam extrInfo, out List<ComRogDataResult> comRogDataResultList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            comRogDataResultList = new List<ComRogDataResult>();

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
                        comRogDataResultList.Add(CopyToInventoryDataDspResultFromOprationLogOrderWork(retWork));
                    }
                }
            }
            catch
            {
                status = -1;
                comRogDataResultList = new List<ComRogDataResult>();
            }

            return (status);
        }

        /// <summary>
        /// ���O�f�[�^�폜
        /// </summary>
        /// <param name="extrInfo">��������</param>
        /// <returns>�X�e�[�^�X</returns>
        public int Delete(ComLogOrderParam opParam)
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
        /// <param name="para">�ʐM���O�f�[�^�����N���X</param>
        /// <returns>���엚�����O���[�N�N���X</returns>
        private OprationLogOrderWork CopyToInventoryDataDspParamWorkFromOprationLogOrderParam(ComLogOrderParam para)
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
        /// <param name="retWork">�ʐM���O�f�[�^�Ɖ�ʃ��[�N�N���X</param>
        /// <returns>���엚�����O���ʃN���X</returns>
        private ComRogDataResult CopyToInventoryDataDspResultFromOprationLogOrderWork(OprtnHisLogWork retWork)
        {
            ComRogDataResult ret = new ComRogDataResult();

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

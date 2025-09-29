//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���R�����^���}�X�^�A�N�Z�X�N���X
// �v���O�����T�v   : ���R�����^���}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2010/04/27  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���R�����^���}�X�^�e�[�u���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���R�����^���}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : ���C��</br>
    /// <br>Date       : 2010/04/27</br>
    /// <br></br>
    /// </remarks>
    public class FreeSearchModelAcs
    {
        /// <summary>
        /// ���R�����^��ރe�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       :���R�����^���}�X�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2010/04/27</br>
        /// </remarks>
        public FreeSearchModelAcs()
        {
            this._iFreeSearchModelPrintDB = (IFreeSearchModelPrintDB)MediationFreeSearchModelPrintDB.GetFreeSearchModelPrintDB();
        }

        #region �� Private Member

        // ���R�����^���}�X�^����pDB Access RemoteObject�C���^�[�t�F�[�X
        private IFreeSearchModelPrintDB _iFreeSearchModelPrintDB;

        #endregion �� Private Member

        #region �� ���R�����^����������
        /// <summary>
        /// ���R�����^����������
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>	
        /// <param name="freeSearchModelPrint">���R�����^���}�X�^�i����j�����N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���R�����^���̑S�����������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2010/04/27</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, FreeSearchModelPrint freeSearchModelPrint)
        {
            retList = new ArrayList();
            object retObject = null;

            FreeSearchModelParaWork paraWork = null;
            // ���o�����W�J����
            int status = CopyFromPrintToWork(freeSearchModelPrint, out paraWork);
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                // ��ƃR�[�h 
                paraWork.EnterpriseCode = enterpriseCode;

                status = this._iFreeSearchModelPrintDB.SearchAll(paraWork, out retObject);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        retList = retObject as ArrayList;

                        // �f�[�^�W�J����
                        status = CopyFromWorkToSet(ref retList);
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                        break;
                }
            }
            
            return status;
        }
        #endregion �� ���R�����^����������

        #region �� ���o�����W�J����
        /// <summary>
        /// ���o�����W�J����
        /// </summary>
        /// <param name="freeSearchModelPrint">UI���o�����N���X</param>
        /// <param name="freeSearchModelParaWork">�����[�g���o�����N���X</param>
        /// <returns>Status</returns>
        private int CopyFromPrintToWork(FreeSearchModelPrint freeSearchModelPrint, out FreeSearchModelParaWork freeSearchModelParaWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            freeSearchModelParaWork = new FreeSearchModelParaWork();
            try
            {
                // ����
                freeSearchModelParaWork.NewPageDiv = (int)freeSearchModelPrint.NewPageDiv;

                //�Ԏ탁�[�J�[�R�[�h
                freeSearchModelParaWork.CarMakerCodeSt = freeSearchModelPrint.CarMakerCodeSt;
                freeSearchModelParaWork.CarMakerCodeEd = freeSearchModelPrint.CarMakerCodeEd;

                //�Ԏ�R�[�h
                freeSearchModelParaWork.CarModelCodeSt = freeSearchModelPrint.CarModelCodeSt;
                freeSearchModelParaWork.CarModelCodeEd = freeSearchModelPrint.CarModelCodeEd;

                //�Ԏ�T�u�R�[�h
                freeSearchModelParaWork.CarModelSubCodeSt = freeSearchModelPrint.CarModelSubCodeSt;
                freeSearchModelParaWork.CarModelSubCodeEd = freeSearchModelPrint.CarModelSubCodeEd;

                //��\�^��
                freeSearchModelParaWork.ModelName = freeSearchModelPrint.ModelName;

                //�o�^��
                freeSearchModelParaWork.CreateDateTime = freeSearchModelPrint.CreateDateTime;

                //�o�^���i�����j
                freeSearchModelParaWork.CreateDateTimeCode = freeSearchModelPrint.CreateDateTimeCode;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion �� ���o�����W�J����

        #region �� �f�[�^�W�J����
        /// <summary>
        /// �f�[�^�W�J����
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <returns>Status</returns>
        private int CopyFromWorkToSet(ref ArrayList retList)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            ArrayList newList = new ArrayList();
            FreeSearchModelSet set = null;

            try
            {
                foreach (FreeSearchModelPrintWork work in retList)
                {
                    set = new FreeSearchModelSet();
                    set.CreateDateTime = work.CreateDateTime;
                    set.UpdateDateTime = work.UpdateDateTime;
                    set.EnterpriseCode = work.EnterpriseCode;
                    set.FileHeaderGuid = work.FileHeaderGuid;
                    set.UpdEmployeeCode = work.UpdEmployeeCode;
                    set.UpdAssemblyId1 = work.UpdAssemblyId1;
                    set.UpdAssemblyId2 = work.UpdAssemblyId2;
                    set.LogicalDeleteCode = work.LogicalDeleteCode;
                    set.FreeSrchMdlFxdNo = work.FreeSrchMdlFxdNo;
                    set.MakerCode = work.MakerCode;
                    set.ModelCode = work.ModelCode;
                    set.ModelSubCode = work.ModelSubCode;
                    set.ExhaustGasSign = work.ExhaustGasSign;
                    set.SeriesModel = work.SeriesModel;
                    set.CategorySignModel = work.CategorySignModel;
                    set.FullModel = work.FullModel;
                    set.ModelDesignationNo = work.ModelDesignationNo;
                    set.CategoryNo = work.CategoryNo;
                    set.StProduceTypeOfYear = work.StProduceTypeOfYear;
                    set.EdProduceTypeOfYear = work.EdProduceTypeOfYear;
                    set.StProduceFrameNo = work.StProduceFrameNo;
                    set.EdProduceFrameNo = work.EdProduceFrameNo;
                    set.ModelGradeNm = work.ModelGradeNm;
                    set.BodyName = work.BodyName;
                    set.DoorCount = work.DoorCount;
                    set.EngineModelNm = work.EngineModelNm;
                    set.EngineDisplaceNm = work.EngineDisplaceNm;
                    set.EDivNm = work.EDivNm;
                    set.TransmissionNm = work.TransmissionNm;
                    set.WheelDriveMethodNm = work.WheelDriveMethodNm;
                    set.ShiftNm = work.ShiftNm;
                    set.CreateDate = work.CreateDate;
                    set.UpdateDate = work.UpdateDate;
                    set.ModelFullName = work.ModelFullName;

                    newList.Add(set);
                }

                retList = newList;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion �� �f�[�^�W�J����
    }
}
//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���R�����^���}�X�^�A�N�Z�X�N���X
// �v���O�����T�v   : ���R�����^���}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10602352-00 �쐬�S�� : �я���
// �� �� ��  2010/04/30  �C�����e : �V�K�쐬
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
    /// <br>Programmer : �я���</br>
    /// <br>Date       : 2010/04/30</br>
    /// <br></br>
    /// </remarks>
    public class FreeSearchModelAcs
    {

        #region �� Constructor ��

        /// <summary>
        /// ���R�����^���e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���R�����^���}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        public FreeSearchModelAcs()
        {
            this._iFreeSearchModelDB = (IFreeSearchModelDB)MediationFreeSearchModelDB.GetFreeSearchModelDB();
        }

        #endregion


        #region �� Private Member ��

        // ���R�����^���}�X�^DB Access RemoteObject�C���^�[�t�F�[�X
        private IFreeSearchModelDB _iFreeSearchModelDB;

        #endregion


        #region �� Private Methods ��

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���R�����^�����[�N�N���X�ˎ��R�����^���N���X�j
        /// </summary>
        /// <param name="uoeSupplierWork">���R�����^�����[�N�N���X</param>
        /// <returns>���R�����^���N���X</returns>
        /// <remarks>
        /// <br>Note       : ���R�����^�����[�N�N���X���玩�R�����^���N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        private FreeSearchModel CopyToFreeSearchModelFromFreeSearchModelWork(FreeSearchModelWork freeSearchModelWork)
        {
            FreeSearchModel freeSearchModel = new FreeSearchModel();

            freeSearchModel.CreateDateTime = freeSearchModelWork.CreateDateTime;
            freeSearchModel.UpdateDateTime = freeSearchModelWork.UpdateDateTime;
            freeSearchModel.EnterpriseCode = freeSearchModelWork.EnterpriseCode;
            freeSearchModel.FileHeaderGuid = freeSearchModelWork.FileHeaderGuid;
            freeSearchModel.UpdEmployeeCode = freeSearchModelWork.UpdEmployeeCode;
            freeSearchModel.UpdAssemblyId1 = freeSearchModelWork.UpdAssemblyId1;
            freeSearchModel.UpdAssemblyId2 = freeSearchModelWork.UpdAssemblyId2;
            freeSearchModel.LogicalDeleteCode = freeSearchModelWork.LogicalDeleteCode;

            freeSearchModel.FreeSrchMdlFxdNo = freeSearchModelWork.FreeSrchMdlFxdNo;
            freeSearchModel.MakerCode = freeSearchModelWork.MakerCode;
            freeSearchModel.ModelCode = freeSearchModelWork.ModelCode;
            freeSearchModel.ModelSubCode = freeSearchModelWork.ModelSubCode;
            freeSearchModel.ExhaustGasSign = freeSearchModelWork.ExhaustGasSign;
            freeSearchModel.SeriesModel = freeSearchModelWork.SeriesModel;
            freeSearchModel.CategorySignModel = freeSearchModelWork.CategorySignModel;
            freeSearchModel.FullModel = freeSearchModelWork.FullModel;
            freeSearchModel.ModelDesignationNo = freeSearchModelWork.ModelDesignationNo;
            freeSearchModel.CategoryNo = freeSearchModelWork.CategoryNo;
            freeSearchModel.StProduceTypeOfYear = freeSearchModelWork.StProduceTypeOfYear;
            freeSearchModel.EdProduceTypeOfYear = freeSearchModelWork.EdProduceTypeOfYear;
            freeSearchModel.StProduceFrameNo = freeSearchModelWork.StProduceFrameNo;
            freeSearchModel.EdProduceFrameNo = freeSearchModelWork.EdProduceFrameNo;
            freeSearchModel.ModelGradeNm = freeSearchModelWork.ModelGradeNm;
            freeSearchModel.BodyName = freeSearchModelWork.BodyName;
            freeSearchModel.DoorCount = freeSearchModelWork.DoorCount;
            freeSearchModel.EngineModelNm = freeSearchModelWork.EngineModelNm;
            freeSearchModel.EngineDisplaceNm = freeSearchModelWork.EngineDisplaceNm;
            freeSearchModel.EDivNm = freeSearchModelWork.EDivNm;
            freeSearchModel.TransmissionNm = freeSearchModelWork.TransmissionNm;
            freeSearchModel.WheelDriveMethodNm = freeSearchModelWork.WheelDriveMethodNm;
            freeSearchModel.ShiftNm = freeSearchModelWork.ShiftNm;
            freeSearchModel.CreateDate = freeSearchModelWork.CreateDate;
            freeSearchModel.UpdateDate = freeSearchModelWork.UpdateDate;

            return freeSearchModel;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���R�����^���N���X�ˎ��R�����^�����[�N�N���X�j
        /// </summary>
        /// <param name="uoeSupplier">���R�����^�����[�N�N���X</param>
        /// <returns>���R�����^���N���X</returns>
        /// <remarks>
        /// <br>Note       : ���R�����^���N���X���玩�R�����^�����[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        private FreeSearchModelWork CopyToFreeSearchModelWorkFromFreeSearchModel(FreeSearchModel freeSearchModel)
        {
            FreeSearchModelWork freeSearchModelWork = new FreeSearchModelWork();


            freeSearchModelWork.CreateDateTime = freeSearchModel.CreateDateTime;
            freeSearchModelWork.UpdateDateTime = freeSearchModel.UpdateDateTime;
            freeSearchModelWork.EnterpriseCode = freeSearchModel.EnterpriseCode;
            freeSearchModelWork.FileHeaderGuid = freeSearchModel.FileHeaderGuid;
            freeSearchModelWork.UpdEmployeeCode = freeSearchModel.UpdEmployeeCode;
            freeSearchModelWork.UpdAssemblyId1 = freeSearchModel.UpdAssemblyId1;
            freeSearchModelWork.UpdAssemblyId2 = freeSearchModel.UpdAssemblyId2;
            freeSearchModelWork.LogicalDeleteCode = freeSearchModel.LogicalDeleteCode;

            freeSearchModelWork.FreeSrchMdlFxdNo = freeSearchModel.FreeSrchMdlFxdNo;
            freeSearchModelWork.MakerCode = freeSearchModel.MakerCode;
            freeSearchModelWork.ModelCode = freeSearchModel.ModelCode;
            freeSearchModelWork.ModelSubCode = freeSearchModel.ModelSubCode;
            freeSearchModelWork.ExhaustGasSign = freeSearchModel.ExhaustGasSign;
            freeSearchModelWork.SeriesModel = freeSearchModel.SeriesModel;
            freeSearchModelWork.CategorySignModel = freeSearchModel.CategorySignModel;
            freeSearchModelWork.FullModel = freeSearchModel.FullModel;
            freeSearchModelWork.ModelDesignationNo = freeSearchModel.ModelDesignationNo;
            freeSearchModelWork.CategoryNo = freeSearchModel.CategoryNo;
            freeSearchModelWork.StProduceTypeOfYear = freeSearchModel.StProduceTypeOfYear;
            freeSearchModelWork.EdProduceTypeOfYear = freeSearchModel.EdProduceTypeOfYear;
            freeSearchModelWork.StProduceFrameNo = freeSearchModel.StProduceFrameNo;
            freeSearchModelWork.EdProduceFrameNo = freeSearchModel.EdProduceFrameNo;
            freeSearchModelWork.ModelGradeNm = freeSearchModel.ModelGradeNm;
            freeSearchModelWork.BodyName = freeSearchModel.BodyName;
            freeSearchModelWork.DoorCount = freeSearchModel.DoorCount;
            freeSearchModelWork.EngineModelNm = freeSearchModel.EngineModelNm;
            freeSearchModelWork.EngineDisplaceNm = freeSearchModel.EngineDisplaceNm;
            freeSearchModelWork.EDivNm = freeSearchModel.EDivNm;
            freeSearchModelWork.TransmissionNm = freeSearchModel.TransmissionNm;
            freeSearchModelWork.WheelDriveMethodNm = freeSearchModel.WheelDriveMethodNm;
            freeSearchModelWork.ShiftNm = freeSearchModel.ShiftNm;
            freeSearchModelWork.CreateDate = freeSearchModel.CreateDate;
            freeSearchModelWork.UpdateDate = freeSearchModel.UpdateDate;

            return freeSearchModelWork;
        }
        #endregion


        #region �� ���R�����^���}�X�^�������� ��
        /// <summary>
        /// ���R�����^����������
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>	
        /// <param name="freeSearchModel">���R�����^���}�X�^�����N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���R�����^���̑S�����������s���܂��B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        public int Search(out ArrayList retList, FreeSearchModel freeSearchModel)
        {
            retList = new ArrayList();
            object retObject = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            FreeSearchModelWork paraWork = null;

            this.CopyFromFreeSearchModelToWork(freeSearchModel, ref paraWork);

            status = this._iFreeSearchModelDB.Search(paraWork, out retObject);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        retList = retObject as ArrayList;

                        // �f�[�^�W�J����
                        status = CopyFromWorkToSet(ref retList);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    }
                default:
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                        break;
                    }
            }

            return status;
        }
        #endregion �� ���R�����^���������� ��


        #region �� ���R�����^���}�X�^�o�^�E�X�V���� ��

        /// <summary>
        /// ���R�����^���}�X�^�o�^�E�X�V����
        /// </summary>
        /// <param name="freeSearchModel">���R�����^���}�X�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���R�����^���}�X�^�̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        public int Write(ref FreeSearchModel freeSearchModel)
        {
            FreeSearchModelWork freeSearchModelWork = new FreeSearchModelWork();
            ArrayList paraList = new ArrayList();

            // ���R�����^���}�X�^���玩�R�����^���}�X�^���[�N�N���X�Ƀ����o�R�s�[
            freeSearchModelWork = CopyToFreeSearchModelWorkFromFreeSearchModel(freeSearchModel);

            // ���R�����^���}�X�^�̓o�^�E�X�V����ݒ�
            paraList.Add(freeSearchModelWork);

            object paraObj = paraList;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            try
            {
                // ���R�����^���}�X�^��������
                status = this._iFreeSearchModelDB.Write(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    paraList = (ArrayList)paraObj;

                    freeSearchModel = new FreeSearchModel();

                    // ���R�����^���}�X�^���[�N�N���X���玩�R�����^���}�X�^�N���X�Ƀ����o�R�s�[
                    freeSearchModel = this.CopyToFreeSearchModelFromFreeSearchModelWork((FreeSearchModelWork)paraList[0]);
                }
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iFreeSearchModelDB = null;
                // �ʐM�G���[��-1��߂�
                status = -1;
            }

            return status;
        }

        #endregion


        #region �� ���R�����^���}�X�^�����폜���� ��

        /// <summary>
        /// ���R�����^���}�X�^�����폜����
        /// </summary>
        /// <param name="freeSearchModel">���R�����^���}�X�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���R�����^���}�X�^���̕����폜���s���܂��B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        public int Delete(FreeSearchModel freeSearchModel)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            try
            {
                FreeSearchModelWork freeSearchModelWork = new FreeSearchModelWork();
                ArrayList paraList = new ArrayList();

                // ���R�����^���}�X�^�N���X���玩�R�����^���}�X�^���[�N�N���X�Ƀ����o�R�s�[
                freeSearchModelWork = CopyToFreeSearchModelWorkFromFreeSearchModel(freeSearchModel);
                // ���R�����^���}�X�^�̕����폜����ݒ�
                paraList.Add(freeSearchModelWork);

                object paraObj = paraList;

                // ���R�����^���}�X�^�����폜
                status = this._iFreeSearchModelDB.Delete(paraObj);

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iFreeSearchModelDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        #endregion


        #region �� ���o�����W�J���� ��
        /// <summary>
        /// ���o�����W�J����
        /// </summary>
        /// <param name="freeSearchModelPrint">UI���o�����N���X</param>
        /// <param name="freeSearchModelParaWork">�����[�g���o�����N���X</param>
        /// <returns>Status</returns>
        private int CopyFromFreeSearchModelToWork(FreeSearchModel freeSearchModel, ref FreeSearchModelWork freeSearchModelParaWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            freeSearchModelParaWork = new FreeSearchModelWork();
            try
            {
                //��ƃR�[�h
                freeSearchModelParaWork.EnterpriseCode = freeSearchModel.EnterpriseCode;

                //���R�����^���Œ�ԍ�
                freeSearchModelParaWork.FreeSrchMdlFxdNo = freeSearchModel.FreeSrchMdlFxdNo;

                //���[�J�[�R�[�h
                freeSearchModelParaWork.MakerCode = freeSearchModel.MakerCode;

                //�Ԏ�R�[�h
                freeSearchModelParaWork.ModelCode = freeSearchModel.ModelCode;

                //�Ԏ�T�u�R�[�h
                freeSearchModelParaWork.ModelSubCode = freeSearchModel.ModelSubCode;

                //�r�K�X�L��
                freeSearchModelParaWork.ExhaustGasSign = freeSearchModel.ExhaustGasSign;

                //�V���[�Y�^��
                freeSearchModelParaWork.SeriesModel = freeSearchModel.SeriesModel;

                //�^���i�ޕʋL���j
                freeSearchModelParaWork.CategorySignModel = freeSearchModel.CategorySignModel;

            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion �� ���o�����W�J����


        #region �� �f�[�^�W�J���� ��
        /// <summary>
        /// �f�[�^�W�J����
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <returns>Status</returns>
        private int CopyFromWorkToSet(ref ArrayList retList)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            ArrayList newList = new ArrayList();
            FreeSearchModel set = null;

            try
            {
                foreach (FreeSearchModelWork work in retList)
                {
                    set = new FreeSearchModel();
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
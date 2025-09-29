//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : ���R�������i
// �v���O�����T�v   : ���R�������i�}�X�^�e�[�u���̃A�N�Z�X������s���܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���`
// �� �� ��  2010/04/30  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using System.Windows.Forms;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���R�������i�}�X�^ �A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���R�������i�}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : ���`</br>
    /// <br>Date       : 2010/04/30</br>
    /// <br>UpDate</br>
    /// <br>2010.05.22 ���R RedMine#8049</br>
    /// </remarks>
    public class FreeSearchPartsAcs
    {
        #region Private Member

        /// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        // ���R�������i�}�X�^
        private IFreeSearchPartsDB _iFreeSearchPartsDB = null;

        private GoodsAcs _goodsAcs;

        private IWin32Window _owner;

        private List<MakerUMnt> _makerUMntList = null;         // ���[�J�[�}�X�^���X�g
        private List<BLGoodsCdUMnt> _blGoodsCdUMntList = null; // �a�k�R�[�h�}�X�^���X�g

        private ArrayList _freeSearchPartsList = new ArrayList();         // ���R�������i�}�X�^

        #endregion

        #region ���v���p�e�B
        /// <summary>�I�[�i�[�t�H�[��</summary>
        public IWin32Window Owner
        {
            set { this._owner = value; }
            get { return this._owner; }
        }

        /// <summary>���R�������i�}�X�^</summary>
        public ArrayList FreeSearchPartsList
        {
            set { this._freeSearchPartsList = value; }
            get { return this._freeSearchPartsList; }
        }
        #endregion

        #region ReadInitData
        // ���[�J�[�}�X�^
        public void GetMakerUMntList(out List<MakerUMnt> makerUMntList)
        {
            makerUMntList = this._makerUMntList;
        }
        public void SetMakerUMntList(List<MakerUMnt> makerUMntList)
        {
            this._makerUMntList = makerUMntList;
        }
        // �a�k�R�[�h���X
        public void GetBlGoodsCdUMntList(out List<BLGoodsCdUMnt> blGoodsCdUMntList)
        {
            blGoodsCdUMntList = this._blGoodsCdUMntList;
        }
        public void SetBlGoodsCdUMntList(List<BLGoodsCdUMnt> blGoodsCdUMntList)
        {
            this._blGoodsCdUMntList = blGoodsCdUMntList;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// ���R�������i�}�X�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���R�������i�}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        public FreeSearchPartsAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iFreeSearchPartsDB = (IFreeSearchPartsDB)MediationFreeSearchPartsDB.GetFreeSearchPartsDB();
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iFreeSearchPartsDB = null;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iFreeSearchPartsDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        /// <summary>
        /// ���R�������i�o�^�E�X�V����
        /// </summary>
        /// <param name="freeSearchPartsList">���R�������i�I�u�W�F�N�g���X�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���R�������i�̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        public int Write(ref ArrayList freeSearchPartsList)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            try
            {
                if (freeSearchPartsList != null && freeSearchPartsList.Count != 0)
                {
                    ArrayList paraList = new ArrayList();

                    foreach (FreeSearchParts freeSearchParts in freeSearchPartsList)
                    {
                        // ���R�������i�N���X���玩�R�������i���[�N�N���X�Ƀ����o�R�s�[
                        FreeSearchPartsWork freeSearchPartsWork = CopyToFreeSearchPartsWorkFromFreeSearchParts(freeSearchParts);
                        // �f�[�^�N���X��Ǎ����ʂփR�s�[
                        paraList.Add(freeSearchPartsWork);
                    }

                    object paraObj = paraList;
                    // ���R�������i��������
                    status = this._iFreeSearchPartsDB.Write(ref paraObj);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        paraList = (ArrayList)paraObj;

                        if (paraList != null && paraList.Count > 0)
                        {
                            freeSearchPartsList.Clear();
                            foreach (FreeSearchPartsWork wkfreeSearchPartsWork in paraList)
                            {
                                // �����[�g�p�����[�^�f�[�^ �� �f�[�^�N���X
                                FreeSearchParts freeSearchPartsPara = CopyToFreeSearchPartsFromFreeSearchPartsWork(wkfreeSearchPartsWork);
                                // �f�[�^�N���X��Ǎ����ʂփR�s�[
                                freeSearchPartsList.Add(freeSearchPartsPara);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iFreeSearchPartsDB = null;
                // �ʐM�G���[��-1��߂�
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// ���R�������i�o�^�E�X�V�E�����폜����
        /// </summary>
        /// <param name="writeParaList">���R�������i�I�u�W�F�N�g���X�g</param>
        /// <param name="deleteParaList">���R�������i�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���R�������i�̓o�^�E�X�V�E�����폜���s���܂��B</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        public int WriteAndDelete(ref ArrayList writeParaList, ArrayList deleteParaList)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            try
            {
                if ((writeParaList != null && writeParaList.Count != 0) || (deleteParaList != null && deleteParaList.Count != 0))
                {
                    ArrayList wparaList = new ArrayList();
                    ArrayList dparaList = new ArrayList();

                    if (writeParaList != null && writeParaList.Count != 0)
                    {
                        foreach (FreeSearchParts freeSearchParts in writeParaList)
                        {
                            // ���R�������i�N���X���玩�R�������i���[�N�N���X�Ƀ����o�R�s�[
                            FreeSearchPartsWork freeSearchPartsWork = CopyToFreeSearchPartsWorkFromFreeSearchParts(freeSearchParts);
                            // �f�[�^�N���X��Ǎ����ʂփR�s�[
                            wparaList.Add(freeSearchPartsWork);
                        }
                    }

                    if (deleteParaList != null && deleteParaList.Count != 0)
                    {
                        foreach (FreeSearchParts freeSearchParts in deleteParaList)
                        {
                            // ���R�������i�N���X���玩�R�������i���[�N�N���X�Ƀ����o�R�s�[
                            FreeSearchPartsWork freeSearchPartsWork = CopyToFreeSearchPartsWorkFromFreeSearchParts(freeSearchParts);
                            // �f�[�^�N���X��Ǎ����ʂփR�s�[
                            dparaList.Add(freeSearchPartsWork);
                        }
                    }

                    object wparaObj = wparaList;
                    object dparaObj = dparaList;
                    // ���R�������i��������
                    status = this._iFreeSearchPartsDB.WriteAndDelete(ref wparaObj, dparaObj);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        wparaList = (ArrayList)wparaObj;

                        if (wparaList != null && wparaList.Count > 0)
                        {
                            writeParaList.Clear();
                            foreach (FreeSearchPartsWork wkfreeSearchPartsWork in wparaList)
                            {
                                // �����[�g�p�����[�^�f�[�^ �� �f�[�^�N���X
                                FreeSearchParts freeSearchPartsPara = CopyToFreeSearchPartsFromFreeSearchPartsWork(wkfreeSearchPartsWork);
                                // �f�[�^�N���X��Ǎ����ʂփR�s�[
                                writeParaList.Add(freeSearchPartsPara);
                            }
                        }
                    }
                }
                //ADD START 2009/05/22 GEJUN FOR REDMINE#8049
                else
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                //ADD END 2009/05/22 GEJUN FOR REDMINE#8049
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iFreeSearchPartsDB = null;
                // �ʐM�G���[��-1��߂�
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }


        /// <summary>
        /// ���R�������i�����폜����
        /// </summary>
        /// <param name="freeSearchPartsList">���R�������i�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���R�������i���̕����폜���s���܂��B</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        public int Delete(ArrayList freeSearchPartsList)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            try
            {
                if (freeSearchPartsList != null && freeSearchPartsList.Count != 0)
                {
                    ArrayList paraList = new ArrayList();

                    foreach (FreeSearchParts freeSearchParts in freeSearchPartsList)
                    {
                        // ���R�������i�N���X���玩�R�������i���[�N�N���X�Ƀ����o�R�s�[
                        FreeSearchPartsWork freeSearchPartsWork = CopyToFreeSearchPartsWorkFromFreeSearchParts(freeSearchParts);
                        // �f�[�^�N���X��Ǎ����ʂփR�s�[
                        paraList.Add(freeSearchPartsWork);
                    }

                    object paraObj = paraList;

                    // ���R�������i�����폜
                    status = this._iFreeSearchPartsDB.Delete(paraObj);
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iFreeSearchPartsDB = null;
                //�ʐM�G���[��-1��߂�
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }

        /// <summary>
        /// ���R�������i���������i�_���폜�܂܂Ȃ��j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="freeSearchParts">��������</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���R�������i�̑S�����������s���܂��B</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        public int Search(out ArrayList retList, FreeSearchParts freeSearchParts)
        {
            retList = new ArrayList();
            try
            {
                int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

                // ���R�������i�}�X�^
                status = this.Search(ref retList, freeSearchParts, ConstantManagement.LogicalMode.GetData0);
                // ���R�������i�}�X�^�f�[�^
                this._freeSearchPartsList = retList;
                
                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iFreeSearchPartsDB = null;
                //�ʐM�G���[��-1��߂�
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }
        #endregion

        //#region Private Methods
        /// <summary>
        /// ���R�������i��������
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="freeSearchParts">��������</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���R�������i�̌����������s���܂��B</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        private int Search(ref ArrayList retList, FreeSearchParts freeSearchParts, ConstantManagement.LogicalMode logicalMode)
        {
            try
            {
                FreeSearchPartsWork freeSearchPartsWork = new FreeSearchPartsWork();

                //���R�������i�N���X�ˎ��R�������i���[�N�N���X
                freeSearchPartsWork = CopyToFreeSearchPartsWorkFromFreeSearchParts(freeSearchParts);

                int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

                ArrayList workList = new ArrayList();
                object retObj = workList;


                // ���R�������i���[�J�[�N���X���I�u�W�F�N�g�ɐݒ�
                object paraObj = (object)freeSearchPartsWork;

                // �S���Ǎ�
                status = this._iFreeSearchPartsDB.Search(paraObj, out retObj, 0, logicalMode);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        workList = retObj as ArrayList;
                        if (workList != null)
                        {
                            foreach (FreeSearchPartsWork wkfreeSearchPartsWork in workList)
                            {
                                // �����[�g�p�����[�^�f�[�^ �� �f�[�^�N���X
                                FreeSearchParts freeSearchPartsPara = CopyToFreeSearchPartsFromFreeSearchPartsWork(wkfreeSearchPartsWork);
                                // �f�[�^�N���X��Ǎ����ʂփR�s�[
                                retList.Add(freeSearchPartsPara);
                            }
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        return status;
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iFreeSearchPartsDB = null;
                //�ʐM�G���[��-1��߂�
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���R�������i���[�N�N���X�ˎ��R�������i�N���X�j
        /// </summary>
        /// <param name="freeSearchPartsWork">���R�������i���[�N�N���X</param>
        /// <returns>���R�������i�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���R�������i���[�N�N���X���玩�R�������i�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        public FreeSearchParts CopyToFreeSearchPartsFromFreeSearchPartsWork(FreeSearchPartsWork freeSearchPartsWork)
        {
            FreeSearchParts freeSearchParts = new FreeSearchParts();

            freeSearchParts.CreateDateTime = freeSearchPartsWork.CreateDateTime;
            freeSearchParts.UpdateDateTime = freeSearchPartsWork.UpdateDateTime;
            freeSearchParts.EnterpriseCode = freeSearchPartsWork.EnterpriseCode;
            freeSearchParts.FileHeaderGuid = freeSearchPartsWork.FileHeaderGuid;
            freeSearchParts.UpdEmployeeCode = freeSearchPartsWork.UpdEmployeeCode;
            freeSearchParts.UpdAssemblyId1 = freeSearchPartsWork.UpdAssemblyId1;
            freeSearchParts.UpdAssemblyId2 = freeSearchPartsWork.UpdAssemblyId2;
            freeSearchParts.LogicalDeleteCode = freeSearchPartsWork.LogicalDeleteCode;
            freeSearchParts.FreSrchPrtPropNo = freeSearchPartsWork.FreSrchPrtPropNo;
            freeSearchParts.MakerCode = freeSearchPartsWork.MakerCode;
            freeSearchParts.ModelCode = freeSearchPartsWork.ModelCode;
            freeSearchParts.ModelSubCode = freeSearchPartsWork.ModelSubCode;
            freeSearchParts.FullModel = freeSearchPartsWork.FullModel;
            freeSearchParts.TbsPartsCode = freeSearchPartsWork.TbsPartsCode;
            freeSearchParts.TbsPartsCdDerivedNo = freeSearchPartsWork.TbsPartsCdDerivedNo;
            freeSearchParts.GoodsNo = freeSearchPartsWork.GoodsNo;
            freeSearchParts.GoodsNoNoneHyphen = freeSearchPartsWork.GoodsNoNoneHyphen;
            freeSearchParts.GoodsMakerCd = freeSearchPartsWork.GoodsMakerCd;
            freeSearchParts.PartsQty = freeSearchPartsWork.PartsQty;
            freeSearchParts.PartsOpNm = freeSearchPartsWork.PartsOpNm;
            freeSearchParts.ModelPrtsAdptYm = freeSearchPartsWork.ModelPrtsAdptYm;
            freeSearchParts.ModelPrtsAblsYm = freeSearchPartsWork.ModelPrtsAblsYm;
            freeSearchParts.ModelPrtsAdptFrameNo = freeSearchPartsWork.ModelPrtsAdptFrameNo;
            freeSearchParts.ModelPrtsAblsFrameNo = freeSearchPartsWork.ModelPrtsAblsFrameNo;
            freeSearchParts.ModelGradeNm = freeSearchPartsWork.ModelGradeNm;
            freeSearchParts.BodyName = freeSearchPartsWork.BodyName;
            freeSearchParts.DoorCount = freeSearchPartsWork.DoorCount;
            freeSearchParts.EngineModelNm = freeSearchPartsWork.EngineModelNm;
            freeSearchParts.EngineDisplaceNm = freeSearchPartsWork.EngineDisplaceNm;
            freeSearchParts.EDivNm = freeSearchPartsWork.EDivNm;
            freeSearchParts.TransmissionNm = freeSearchPartsWork.TransmissionNm;
            freeSearchParts.WheelDriveMethodNm = freeSearchPartsWork.WheelDriveMethodNm;
            freeSearchParts.ShiftNm = freeSearchPartsWork.ShiftNm;
            freeSearchParts.CreateDate = freeSearchPartsWork.CreateDate;
            freeSearchParts.UpdateDate = freeSearchPartsWork.UpdateDate;
            return freeSearchParts;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���R�������i�N���X�ˎ��R�������i���[�N�N���X�j
        /// </summary>
        /// <param name="freeSearchParts">���R�������i���[�N�N���X</param>
        /// <returns>���R�������i�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���R�������i�N���X���玩�R�������i���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        public FreeSearchPartsWork CopyToFreeSearchPartsWorkFromFreeSearchParts(FreeSearchParts freeSearchParts)
        {
            FreeSearchPartsWork freeSearchPartsWork = new FreeSearchPartsWork();

            freeSearchPartsWork.CreateDateTime = freeSearchParts.CreateDateTime;
            freeSearchPartsWork.UpdateDateTime = freeSearchParts.UpdateDateTime;
            freeSearchPartsWork.EnterpriseCode = freeSearchParts.EnterpriseCode;
            freeSearchPartsWork.FileHeaderGuid = freeSearchParts.FileHeaderGuid;
            freeSearchPartsWork.UpdEmployeeCode = freeSearchParts.UpdEmployeeCode;
            freeSearchPartsWork.UpdAssemblyId1 = freeSearchParts.UpdAssemblyId1;
            freeSearchPartsWork.UpdAssemblyId2 = freeSearchParts.UpdAssemblyId2;
            freeSearchPartsWork.LogicalDeleteCode = freeSearchParts.LogicalDeleteCode;
            freeSearchPartsWork.FreSrchPrtPropNo = freeSearchParts.FreSrchPrtPropNo;
            freeSearchPartsWork.MakerCode = freeSearchParts.MakerCode;
            freeSearchPartsWork.ModelCode = freeSearchParts.ModelCode;
            freeSearchPartsWork.ModelSubCode = freeSearchParts.ModelSubCode;
            freeSearchPartsWork.FullModel = freeSearchParts.FullModel;
            freeSearchPartsWork.TbsPartsCode = freeSearchParts.TbsPartsCode;
            freeSearchPartsWork.TbsPartsCdDerivedNo = freeSearchParts.TbsPartsCdDerivedNo;
            freeSearchPartsWork.GoodsNo = freeSearchParts.GoodsNo;
            freeSearchPartsWork.GoodsNoNoneHyphen = freeSearchParts.GoodsNoNoneHyphen;
            freeSearchPartsWork.GoodsMakerCd = freeSearchParts.GoodsMakerCd;
            freeSearchPartsWork.PartsQty = freeSearchParts.PartsQty;
            freeSearchPartsWork.PartsOpNm = freeSearchParts.PartsOpNm;
            freeSearchPartsWork.ModelPrtsAdptYm = freeSearchParts.ModelPrtsAdptYm;
            freeSearchPartsWork.ModelPrtsAblsYm = freeSearchParts.ModelPrtsAblsYm;
            freeSearchPartsWork.ModelPrtsAdptFrameNo = freeSearchParts.ModelPrtsAdptFrameNo;
            freeSearchPartsWork.ModelPrtsAblsFrameNo = freeSearchParts.ModelPrtsAblsFrameNo;
            freeSearchPartsWork.ModelGradeNm = freeSearchParts.ModelGradeNm;
            freeSearchPartsWork.BodyName = freeSearchParts.BodyName;
            freeSearchPartsWork.DoorCount = freeSearchParts.DoorCount;
            freeSearchPartsWork.EngineModelNm = freeSearchParts.EngineModelNm;
            freeSearchPartsWork.EngineDisplaceNm = freeSearchParts.EngineDisplaceNm;
            freeSearchPartsWork.EDivNm = freeSearchParts.EDivNm;
            freeSearchPartsWork.TransmissionNm = freeSearchParts.TransmissionNm;
            freeSearchPartsWork.WheelDriveMethodNm = freeSearchParts.WheelDriveMethodNm;
            freeSearchPartsWork.ShiftNm = freeSearchParts.ShiftNm;
            freeSearchPartsWork.CreateDate = freeSearchParts.CreateDate;
            freeSearchPartsWork.UpdateDate = freeSearchParts.UpdateDate;
            freeSearchPartsWork.GoodsNoFuzzy = freeSearchParts.GoodsNoFuzzy;


            return freeSearchPartsWork;
        }

        /// <summary>
        /// �w�肵�����i�R�[�h�����ɏ��i�����擾���܂��B
        /// </summary>
        /// <param name="goodsCndtn">���i��������</param>
        /// <param name="goodsUnitData">���i���I�u�W�F�N�g�iout�j</param>
        /// <param name="message">���b�Z�[�W(out)</param>
        /// <returns>STATUS</returns>
        public int GetGoodsUnitData(GoodsCndtn goodsCndtn, out GoodsUnitData goodsUnitData, out string message)
        {

            List<GoodsUnitData> goodsUnitDataList;

            if (this._goodsAcs == null)
            {
                this._goodsAcs = new GoodsAcs();
            }
            int status = _goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out message);

            if ((goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
            {
                goodsUnitData = goodsUnitDataList[0];
            }
            else
            {
                goodsUnitData = null;
            }
            return status;
        }

        /// <summary>
        /// BL�R�[�h����
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="bLGoodsCode">BL�R�[�h</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="carInfo">�ԗ����</param>
        /// <returns>ConstantManagement.MethodResult(-3:�ԗ���񖳂�)</returns>
        public int SearchPartsFromBLCode(int salesRowNo, string enterpriseCode, string sectionCode, int bLGoodsCode, out List<GoodsUnitData> goodsUnitDataList, PMKEN01010E carInfo)
        {
            #region ��������
            //-----------------------------------------------------------------------------
            // ������
            //-----------------------------------------------------------------------------
            string msg;
            PartsInfoDataSet partsInfoDataSet;
            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            goodsUnitDataList = new List<GoodsUnitData>();
            #endregion

            #region �����o�����ݒ�
            //-----------------------------------------------------------------------------
            // ���o�����ݒ�
            //-----------------------------------------------------------------------------
            GoodsCndtn cndtn = new GoodsCndtn();
            cndtn.EnterpriseCode = enterpriseCode;
            cndtn.SectionCode = sectionCode;
            cndtn.BLGoodsCode = bLGoodsCode;
            cndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.NoSearch;
            cndtn.IsSettingSupplier = 1;


            cndtn.SearchCarInfo = carInfo;
            #endregion

            #region ���ԗ���񑶍݃`�F�b�N
            //-----------------------------------------------------------------------------
            // �ԗ���񑶍݃`�F�b�N
            //-----------------------------------------------------------------------------
            if (cndtn.SearchCarInfo == null) return -3;
            #endregion

            #region ��BL�R�[�h����
            //-----------------------------------------------------------------------------
            // BL�R�[�h����
            //-----------------------------------------------------------------------------
            if (_goodsAcs == null)
            {
                string retMessage;
                this._goodsAcs = new GoodsAcs();
                this._goodsAcs.SearchInitial(cndtn.EnterpriseCode, cndtn.SectionCode, out retMessage);
            }
            int status = this._goodsAcs.SearchPartsFromBLCode(cndtn, out partsInfoDataSet, out goodsUnitDataList, out msg);
            #endregion

            switch ((ConstantManagement.MethodResult)status)
            {
                case ConstantManagement.MethodResult.ctFNC_CANCEL: // �I�𖳂�
                    break;
                case ConstantManagement.MethodResult.ctFNC_NORMAL: // �ʏ폈��
                    #region �����i�I�𐧌�N��
                    //-----------------------------------------------------------------------------
                    // ���i�I�𐧌�N��
                    //-----------------------------------------------------------------------------
                    partsInfoDataSet.TBOInitializeFlg = 0;
                    DialogResult retDialog = UIDisplayControl.ProcessPartsSearch(this._owner, cndtn.SearchCarInfo, partsInfoDataSet);
                    #endregion

                    switch (retDialog)
                    {
                        case DialogResult.Abort:
                        case DialogResult.Cancel:
                            partsInfoDataSet.Clear();
                            goodsUnitDataList.Clear();
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                        case DialogResult.Ignore:
                            break;
                        case DialogResult.No:
                            break;
                        case DialogResult.None:
                            break;
                        case DialogResult.OK:
                        case DialogResult.Yes:
                            #region �����i�����f�[�^�Z�b�g����I�����̏��i�A���f�[�^�I�u�W�F�N�g���擾
                            //-----------------------------------------------------------------------------
                            // ���i�����f�[�^�Z�b�g����I�����̏��i�A���f�[�^�I�u�W�F�N�g���擾
                            //-----------------------------------------------------------------------------
                            goodsUnitDataList = new List<GoodsUnitData>((GoodsUnitData[])partsInfoDataSet.GetGoodsList(true).ToArray(typeof(GoodsUnitData)));
                            #endregion
                            break;
                        case DialogResult.Retry:
                            break;
                    }
                    break;
                case ConstantManagement.MethodResult.ctFNC_NO_RETURN: // �Y���f�[�^����
                    break;
            }
            return status;
        }
    }
}

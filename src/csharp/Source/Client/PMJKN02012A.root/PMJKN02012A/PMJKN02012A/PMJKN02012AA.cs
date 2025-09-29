//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���R�������i�}�X�^�A�N�Z�X�N���X
// �v���O�����T�v   : ���R�������i�}�X�^�̓o�^�E�ύX�E�폜���s��
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
using System.Windows.Forms;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���R�������i�}�X�^�e�[�u���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���R�������i�}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : ���C��</br>
    /// <br>Date       : 2010/04/27</br>
    /// <br></br>
    /// </remarks>
    public class FreeSearchPartsAcs
    {
        /// <summary>
        /// ���R�����^��ރe�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       :���R�����^���}�X�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2010/04/27</br>
        /// </remarks>
        public FreeSearchPartsAcs()
        {
            this._goodsAcs = new GoodsAcs();
            this._iFreeSearchPartsPrintDB = (IFreeSearchPartsPrintDB)MediationFreeSearchPartsPrintDB.GetFreeSearchPartsPrintDB();
        }

        /// <summary>�I�[�i�[�t�H�[��</summary>
        public IWin32Window Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        #region �� Private Member

        // ���R�������i�}�X�^����pDB Access RemoteObject�C���^�[�t�F�[�X
        private IFreeSearchPartsPrintDB _iFreeSearchPartsPrintDB;

        private GoodsAcs _goodsAcs;

        private IWin32Window _owner = null;

        #endregion �� Private Member

        #region �� ���R�����^����������
        /// <summary>
        /// ���R�����^����������
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="freeSearchPartsPrint">���R�������i�}�X�^�i����j�����N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���R�����^���̑S�����������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2010/04/27</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, FreeSearchPartsPrint freeSearchPartsPrint)
        {
            retList = new ArrayList();
            object retObject = null;

            FreeSearchPartsParaWork paraWork = null;
            // ���o�����W�J����
            int status = CopyFromPrintToWork(freeSearchPartsPrint, out paraWork);
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                status = this._iFreeSearchPartsPrintDB.SearchAll(paraWork, out retObject);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        retList = retObject as ArrayList;
                        // �f�[�^�W�J����
                        status = CopyFromWorkToSet(ref retList, freeSearchPartsPrint);

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
        /// <param name="freeSearchPartsPrint">UI���o�����N���X</param>
        /// <param name="freeSearchPartsParaWork">�����[�g���o�����N���X</param>
        /// <returns>Status</returns>
        private int CopyFromPrintToWork(FreeSearchPartsPrint freeSearchPartsPrint, out FreeSearchPartsParaWork freeSearchPartsParaWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            freeSearchPartsParaWork = new FreeSearchPartsParaWork();
            try
            {
                //��ƃR�[�h
                freeSearchPartsParaWork.EnterpriseCode = freeSearchPartsPrint.EnterpriseCode;

                // ����
                freeSearchPartsParaWork.NewPageDiv = (int)freeSearchPartsPrint.NewPageDiv;

                //�Ԏ탁�[�J�[�R�[�h
                freeSearchPartsParaWork.CarMakerCodeSt = freeSearchPartsPrint.CarMakerCodeSt;
                freeSearchPartsParaWork.CarMakerCodeEd = freeSearchPartsPrint.CarMakerCodeEd;

                //�Ԏ�R�[�h
                freeSearchPartsParaWork.CarModelCodeSt = freeSearchPartsPrint.CarModelCodeSt;
                freeSearchPartsParaWork.CarModelCodeEd = freeSearchPartsPrint.CarModelCodeEd;

                //�Ԏ�T�u�R�[�h
                freeSearchPartsParaWork.CarModelSubCodeSt = freeSearchPartsPrint.CarModelSubCodeSt;
                freeSearchPartsParaWork.CarModelSubCodeEd = freeSearchPartsPrint.CarModelSubCodeEd;

                //��\�^��
                freeSearchPartsParaWork.ModelName = freeSearchPartsPrint.ModelName;

                //���i���[�J�[
                freeSearchPartsParaWork.MakerCodeSt = freeSearchPartsPrint.MakerCodeSt;
                freeSearchPartsParaWork.MakerCodeEd = freeSearchPartsPrint.MakerCodeEd;

                //�a�k�R�[�h
                freeSearchPartsParaWork.BLGoodsCodeSt = freeSearchPartsPrint.BLGoodsCodeSt;
                freeSearchPartsParaWork.BLGoodsCodeEd = freeSearchPartsPrint.BLGoodsCodeEd;

                //�o�^��
                freeSearchPartsParaWork.CreateDateTime = freeSearchPartsPrint.CreateDateTime;

                //�o�^���i�����j
                freeSearchPartsParaWork.CreateDateTimeCode = freeSearchPartsPrint.CreateDateTimeCode;
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
        /// <param name="freeSearchPartsPrint">���R�������i�}�X�^�i����j�����N���X</param>
        /// <returns>Status</returns>
        private int CopyFromWorkToSet(ref ArrayList retList, FreeSearchPartsPrint freeSearchPartsPrint)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            ArrayList newList = new ArrayList();
            FreeSearchPartsSet set = null;

            GoodsUnitData goodsUnitData = null;

            try
            {
                foreach (FreeSearchPartsPrintWork work in retList)
                {
                    set = new FreeSearchPartsSet();
                    set.CreateDateTime = work.CreateDateTime;
                    set.UpdateDateTime = work.UpdateDateTime;
                    set.EnterpriseCode = work.EnterpriseCode;
                    set.FileHeaderGuid = work.FileHeaderGuid;
                    set.UpdEmployeeCode = work.UpdEmployeeCode;
                    set.UpdAssemblyId1 = work.UpdAssemblyId1;
                    set.UpdAssemblyId2 = work.UpdAssemblyId2;
                    set.LogicalDeleteCode = work.LogicalDeleteCode;
                    set.FreSrchPrtPropNo = work.FreSrchPrtPropNo;
                    set.MakerCode = work.MakerCode;
                    set.ModelCode = work.ModelCode;
                    set.ModelSubCode = work.ModelSubCode;
                    set.FullModel = work.FullModel;
                    set.TbsPartsCode = work.TbsPartsCode;
                    set.TbsPartsCdDerivedNo = work.TbsPartsCdDerivedNo;
                    set.GoodsNo = work.GoodsNo;
                    set.GoodsNoNoneHyphen = work.GoodsNoNoneHyphen;
                    set.GoodsMakerCd = work.GoodsMakerCd;
                    set.PartsQty = work.PartsQty;
                    set.PartsOpNm = work.PartsOpNm;
                    set.ModelPrtsAdptYm = work.ModelPrtsAdptYm;
                    set.ModelPrtsAblsYm = work.ModelPrtsAblsYm;
                    set.ModelPrtsAdptFrameNo = work.ModelPrtsAdptFrameNo;
                    set.ModelPrtsAblsFrameNo = work.ModelPrtsAblsFrameNo;
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
                    set.MakerName = work.MakerName;

                    // �w�肵�����i�R�[�h�����ɏ��i�����擾
                    status = GetGoodsUnitData(work, freeSearchPartsPrint, out goodsUnitData);
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        //�i�����񋟃f�[�^�ɂȂ��̏ꍇ
                        if (string.IsNullOrEmpty(goodsUnitData.GoodsNameKana))
                        {
                            set.BLGoodsHalfName = work.BLGoodsHalfName;
                        }
                        else
                        {
                            set.BLGoodsHalfName = goodsUnitData.GoodsNameKana;
                        }

                        //�W�����i���񋟃f�[�^�ɂ���̏ꍇ
                        if (goodsUnitData.GoodsPriceList != null && goodsUnitData.GoodsPriceList.Count > 0)
                        {
                            foreach (GoodsPrice goodsPrice in goodsUnitData.GoodsPriceList)
                            {
                                if (goodsPrice.PriceStartDate == DateTime.Today)
                                {
                                    set.ListPrice = goodsPrice.ListPrice;
                                }
                            }
                        }
                        else
                        {
                            set.ListPrice = 0;
                        }
                    }
                    else
                    {
                        set.BLGoodsHalfName = work.BLGoodsHalfName;
                        set.ListPrice = 0;
                    }

                    newList.Add(set);
                }

                retList = newList;
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion �� �f�[�^�W�J����

        #region �� ���i��������
        /// <summary>
        /// �w�肵�����i�R�[�h�����ɏ��i�����擾���܂��B
        /// </summary>
        /// <param name="work">���R�������i�}�X�^�i����j���N���X</param>
        /// <param name="print">���R�������i�}�X�^�i����j�����N���X</param>
        /// <param name="goodsUnitData">���i���I�u�W�F�N�g�iout�j</param>
        /// <param name="message">���b�Z�[�W(out)</param>
        /// <returns>STATUS</returns>
        private int GetGoodsUnitData(FreeSearchPartsPrintWork work, FreeSearchPartsPrint print, out GoodsUnitData goodsUnitData)
        {
            string message;

            List<GoodsUnitData> goodsUnitDataList;

            this._goodsAcs.Owner = this._owner;

            GoodsCndtn goodsCndtn = new GoodsCndtn();
            goodsCndtn.EnterpriseCode = print.EnterpriseCode; // ��ƃR�[�h
            goodsCndtn.SectionCode = print.SectionCode; // ���_�R�[�h
            goodsCndtn.GoodsNo = work.GoodsNo; // ���i�R�[�h
            goodsCndtn.GoodsMakerCd = work.GoodsMakerCd; // ���i���[�J�[�R�[�h
            goodsCndtn.PriceApplyDate = DateTime.Today; // ���i�K�p��

            int status = _goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, false, out goodsUnitDataList, out message);

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
        #endregion �� ���i��������
    }
}
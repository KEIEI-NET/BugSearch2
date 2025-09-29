//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �\���敪�}�X�^�i����j
// �v���O�����T�v   : �\���敪�}�X�^�i����j�A�N�Z�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �L�w��
// �� �� ��  2012/06/11  �C�����e : �V�K�쐬
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
    /// �\���敪�}�X�^����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �\���敪�}�X�^����C���X�^���X�̍쐬���s���B</br>
    /// <br>Programmer : �L�w��</br>
    /// <br>Date       : 2012/06/11</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00</br>
    /// </remarks>
    public class PriceSelectSetAcs
    {
        #region �� Private Member

        //private PriceSelectSetAcs _priceSelectSetAcs;

        IPriceSelectSetWorkDB _iPriceSelectSetWorkDB;

        #endregion

        # region ��Constracter
        /// <summary>
        /// �\���敪�}�X�^����A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �\���敪�}�X�^����A�N�Z�X�N���X�B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// </remarks>
        public PriceSelectSetAcs()
        {
            try
            {
                this._iPriceSelectSetWorkDB = (IPriceSelectSetWorkDB)MediationPriceSelectSetWorkDB.GetPriceSelectSetWorkDB();
            }
            catch (Exception)
            {

                _iPriceSelectSetWorkDB = null;
            }

        }
        #endregion

        #region �� �\���敪�}�X�^��񌟍�

        /// <summary>
        /// �\���敪�}�X�^�f�[�^�擾����
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="enterpriseCode">�����f�[�^</param>
        /// <param name="priceSelectSetPrint">�擾�f�[�^</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �\���敪�}�X�^�f�[�^�擾�������s���B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, PriceSelectSetPrint priceSelectSetPrint)
        {
            return SearchProc(out retList, enterpriseCode, 0, 0, priceSelectSetPrint);
        }
        #endregion

        #region �� Private Methods

        /// <summary>
        /// �\���敪�}�X�^���������i�_���폜�j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>	
        /// <param name="priceSelectSetPrint">�擾�f�[�^</param>	
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �\���敪�}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// </remarks>
        public int SearchDelete(out ArrayList retList, string enterpriseCode, PriceSelectSetPrint priceSelectSetPrint)
        {
            return SearchProc(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, priceSelectSetPrint);
        }

        /// <summary>
        /// �\���敪�}�X�^��������
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� )</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="priceSelectSetPrint">�擾�f�[�^</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �\���敪�}�X�^�̌����������s���܂��B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, PriceSelectSetPrint priceSelectSetPrint)
        {

            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            retList = new ArrayList();
            retList.Clear();

            try
            {
                PriceSelectSetCndtnWork priceSelectSetCndtnWork = new PriceSelectSetCndtnWork();
                // ���o�����W�J 
                status = this.DevReatCndtn(priceSelectSetPrint, enterpriseCode, out priceSelectSetCndtnWork);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // �f�[�^�擾  
                object retReatList = null;

                status = this._iPriceSelectSetWorkDB.Search(out retReatList, priceSelectSetCndtnWork, logicalMode);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // �f�[�^�W�J����
                        DevReatData(priceSelectSetPrint, (ArrayList)retReatList, out retList);

                        if (retList.Count == 0)
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }

        /// <summary>
        /// �擾�f�[�^�W�J����
        /// </summary>
        /// <param name="priceSelectSetPrint">UI���o�����N���X</param>
        /// <param name="arrayList">�擾�f�[�^</param>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �擾�f�[�^��W�J����B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// </remarks>
        private void DevReatData(PriceSelectSetPrint priceSelectSetPrint, ArrayList arrayList, out ArrayList retList)
        {
            retList = new ArrayList();

            foreach (PriceSelectSetResultWork priceSelectSetResultWork in arrayList)
            {
                PriceSelectSet priceSelectSet = new PriceSelectSet();

                priceSelectSet.UpdateDateTime = priceSelectSetResultWork.UpdateDateTime;
                priceSelectSet.CustomerCode = priceSelectSetResultWork.CustomerCode;
                priceSelectSet.CustomerSnm = priceSelectSetResultWork.CustomerSnm;
                priceSelectSet.BLGroupCode = priceSelectSetResultWork.BLGroupCode;
                priceSelectSet.GoodsMakerCd = priceSelectSetResultWork.GoodsMakerCd;
                priceSelectSet.GoodsMakerSnm = priceSelectSetResultWork.GoodsMakerSnm;
                priceSelectSet.BLGoodsCode = priceSelectSetResultWork.BLGoodsCode;
                priceSelectSet.BLGoodsHalfName = priceSelectSetResultWork.BLGoodsHalfName;
                priceSelectSet.PriceSelectDiv = priceSelectSetResultWork.PriceSelectDiv;
                priceSelectSet.PriceSelectPtn = priceSelectSetResultWork.PriceSelectPtn;
                retList.Add(priceSelectSet);
            }
        }

        /// <summary>
        /// ���o�����W�J����
        /// </summary>
        /// <param name="priceSelectSetPrint">UI���o�����N���X</param>
        /// <param name="enterpriseCode">errMsg</param>
        /// <param name="priceSelectSetCndtnWork">�����[�g���o�����N���X</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �擾�f�[�^��W�J����B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// </remarks>
        private int DevReatCndtn(PriceSelectSetPrint priceSelectSetPrint, string enterpriseCode, out PriceSelectSetCndtnWork priceSelectSetCndtnWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            priceSelectSetCndtnWork = new PriceSelectSetCndtnWork();
            try
            {
                // ��ƃR�[�h
                priceSelectSetCndtnWork.EnterpriseCode = enterpriseCode;
                // �W�����i�I��ݒ�
                priceSelectSetCndtnWork.PriceSelectPtn = priceSelectSetPrint.PrintType;
                // ���[�J�[�J�n
                priceSelectSetCndtnWork.St_GoodsMakerCd = priceSelectSetPrint.GoodsMakerCdSt;
                // ���[�J�[�I��
                priceSelectSetCndtnWork.Ed_GoodsMakerCd = priceSelectSetPrint.GoodsMakerCdEd;
                // �a�k�R�[�h�J�n
                priceSelectSetCndtnWork.St_BLGoodsCode = priceSelectSetPrint.BLGoodsCodeSt;
                // �a�k�R�[�h�I��
                priceSelectSetCndtnWork.Ed_BLGoodsCode = priceSelectSetPrint.BLGoodsCodeEd;
                // ���Ӑ�J�n
                priceSelectSetCndtnWork.St_CustomerCode = priceSelectSetPrint.CustomerCodeSt;
                // ���Ӑ�I��
                priceSelectSetCndtnWork.Ed_CustomerCode = priceSelectSetPrint.CustomerCodeEd;
                // ���Ӑ�|���O���[�v�R�[�h�J�n
                priceSelectSetCndtnWork.St_BLGroupCode = priceSelectSetPrint.BLGroupCodeSt;
                // ���Ӑ�|���O���[�v�R�[�h�I��
                priceSelectSetCndtnWork.Ed_BLGroupCode = priceSelectSetPrint.BLGroupCodeEd;
                // �_���폜�敪
                priceSelectSetCndtnWork.LogicalDeleteCode = priceSelectSetPrint.LogicalDeleteCode;
                // �폜���J�n
                priceSelectSetCndtnWork.DeleteDateTimeSt = priceSelectSetPrint.DeleteDateTimeSt;
                // �폜���I��
                priceSelectSetCndtnWork.DeleteDateTimeEd = priceSelectSetPrint.DeleteDateTimeEd;
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion
    }
}

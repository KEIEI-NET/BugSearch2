//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �\���敪�}�X�^�����e�i���X
// �v���O�����T�v   : �\���敪�}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/10/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �\���敪�}�X�^�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �\���敪�}�X�^�̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.10.15</br>
    /// <br></br>
    /// </remarks>
    public class PriceSelectSetAcs
    {
        #region -- �����[�g�I�u�W�F�N�g�i�[�o�b�t�@ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �����[�g�I�u�W�F�N�g�i�[�o�b�t�@
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        private IPriceSelectSetDB _iPriceSelectSetDB = null;

        // ���[�J���c�a���[�h
        private static bool _isLocalDBRead = false;	// �f�t�H���g�̓����[�g

        #endregion

        #region -- �R���X�g���N�^ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.15</br>
        /// <br></br>
        /// </remarks>
        public PriceSelectSetAcs()
        {
            // �����[�g�I�u�W�F�N�g�擾
            this._iPriceSelectSetDB = (IPriceSelectSetDB)MediationPriceSelectSetDB.GetPriceSelectSetDB();
        }

        #endregion

        #region [���[�J���A�N�Z�X�p]
        /// <summary> �������[�h </summary>
        public enum SearchMode
        {
            /// <summary> ���[�J���A�N�Z�X </summary>
            Local = 0,
            /// <summary> �����[�g�A�N�Z�X </summary>
            Remote = 1
        }
        #endregion

        #region -- �o�^��X�V���� --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �o�^�E�X�V����
        /// </summary>
        /// <param name="priceSelectSet">UI�f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �o�^�E�X�V�������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        public int Write(ref PriceSelectSet priceSelectSet)
        {
            // UI�f�[�^�N���X�����[�N
            PriceSelectSetWork priceSelectSetWork = CopyToPriceSelectSetWorkFromPriceSelectSet(priceSelectSet);

            object objPriceSelectSetWork = priceSelectSetWork;

            int status = 0;
            int writeMode = 0;

            // �������ݏ���
            status = this._iPriceSelectSetDB.Write(ref objPriceSelectSetWork, writeMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {

                priceSelectSetWork = objPriceSelectSetWork as PriceSelectSetWork;

                // �N���X�������o�R�s�[
                priceSelectSet = CopyToPriceSelectSetFromPriceSelectSetWork(priceSelectSetWork);
            }

            return status;
        }

        #endregion

        #region -- �폜���� --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �_���폜����
        /// </summary>
        /// <param name="priceSelectSet">�\���敪�}�X�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �\���敪�}�X�^�̘_���폜���s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        public int LogicalDelete(ref PriceSelectSet priceSelectSet)
        {
            PriceSelectSetWork priceSelectSetWork = CopyToPriceSelectSetWorkFromPriceSelectSet(priceSelectSet);
            object objPriceSelectSetWork = priceSelectSetWork;

            // ���_���_���폜
            int status = this._iPriceSelectSetDB.LogicalDelete(ref objPriceSelectSetWork);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �t�@�C������n���ċ��_��񃏁[�N�N���X���f�V���A���C�Y����
                priceSelectSetWork = objPriceSelectSetWork as PriceSelectSetWork;

                // �N���X�������o�R�s�[
                priceSelectSet = CopyToPriceSelectSetFromPriceSelectSetWork(priceSelectSetWork);

            }

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �����폜����
        /// </summary>
        /// <param name="priceSelectSet">�\���敪�}�X�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �\���敪�}�X�^�̕����폜���s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        public int Delete(PriceSelectSet priceSelectSet)
        {
            PriceSelectSetWork priceSelectSetWork = CopyToPriceSelectSetWorkFromPriceSelectSet(priceSelectSet);

            // XML�֕ϊ����A������̃o�C�i����
            object objPriceSelectSetWork = priceSelectSetWork;

            // ���_��񕨗��폜
            int status = this._iPriceSelectSetDB.Delete(ref objPriceSelectSetWork);

            return status;
        }

        #endregion

        #region -- ������������� --

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �\���敪�}�X�^���������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �\���敪�}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode, SearchMode.Remote, ConstantManagement.LogicalMode.GetData01);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �\���敪�}�X�^���������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �\���敪�}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode, SearchMode.Remote, ConstantManagement.LogicalMode.GetData0);
        }

/*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �\���敪�}�X�^��������
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>  
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="searchMode">�������[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �\���敪�}�X�^�̌����������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.15</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, string enterpriseCode, SearchMode searchMode, ConstantManagement.LogicalMode logicalMode)
        {
            LogWrite("���[�J�����[�h����");
            _isLocalDBRead = searchMode == SearchMode.Local ? true : false;

            LogWrite("D�N���X�C���X�^���X����");
            PriceSelectSetWork priceSelectSetWork = new PriceSelectSetWork();

            priceSelectSetWork.EnterpriseCode = enterpriseCode;

            int status = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList priceSelectSetWorkList = new ArrayList();
            priceSelectSetWorkList.Clear();

            object paraobj = priceSelectSetWork;
            object retobj = null;

            LogWrite("�����[�g�@��������");
            status = this._iPriceSelectSetDB.Search(out retobj, paraobj, 0, logicalMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                LogWrite("���폈��");

                priceSelectSetWorkList = retobj as ArrayList;

                foreach (PriceSelectSetWork wkPriceSelectSetWork in priceSelectSetWorkList)
                {
                    retList.Add(CopyToPriceSelectSetFromPriceSelectSetWork(wkPriceSelectSetWork));
                }
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            }

            // STATUS ��ݒ�
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                (retList.Count == 0))
            {
                LogWrite("�Y���Ȃ�");

                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �\���敪�}�X�^�_���폜��������
        /// </summary>
        /// <param name="priceSelectSet">�\���敪�}�X�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �\���敪�}�X�^�̕������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        public int Revival(ref PriceSelectSet priceSelectSet)
        {
            PriceSelectSetWork priceSelectSetWork = CopyToPriceSelectSetWorkFromPriceSelectSet(priceSelectSet);

            // XML�֕ϊ����A������̃o�C�i����
            object objPriceSelectSetWork = priceSelectSetWork;

            // ��������
            int status = this._iPriceSelectSetDB.RevivalLogicalDelete(ref objPriceSelectSetWork);


            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �t�@�C������n���ċ��_��񃏁[�N�N���X���f�V���A���C�Y����
                priceSelectSetWork = objPriceSelectSetWork as PriceSelectSetWork;

                // �N���X�������o�R�s�[
                priceSelectSet = CopyToPriceSelectSetFromPriceSelectSetWork(priceSelectSetWork);

            }

            return status;
        }

        # endregion

        #region -- �W�����i�I���敪�擾 --
        /// <summary>
        /// �W�����i�I���敪�擾
        /// </summary>
        /// <param name="displayDivList">�\���敪���X�g</param>
        /// <param name="goodsMakerCode">���[�J�[�R�[�h</param>
        /// <param name="blGoodsCode">/ BL�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="custRateGrpCode">���Ӑ�|���O���[�v�R�[�h</param>
        /// <param name="priceSelectDiv">�W�����i�I���敪</param>
        /// <remarks>
        /// <br>Note       : �W�����i�I���敪�擾�������s���܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        public void GetDisplayDiv(List<PriceSelectSet> displayDivList, Int32 goodsMakerCode, Int32 blGoodsCode, Int32 customerCode, Int32 custRateGrpCode, out Int32  priceSelectDiv)
        {
            GetDisplayDivProc(displayDivList, goodsMakerCode, blGoodsCode, customerCode, custRateGrpCode, out  priceSelectDiv);
        }

        /// <summary>
        /// �W�����i�I���敪�擾
        /// </summary>
        /// <param name="displayDivList">�\���敪���X�g</param>
        /// <param name="goodsMakerCode">���[�J�[�R�[�h</param>
        /// <param name="blGoodsCode">/ BL�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="custRateGrpCode">���Ӑ�|���O���[�v�R�[�h</param>
        /// <param name="priceSelectDiv">�W�����i�I���敪</param>
        /// <remarks>
        /// <br>Note       : �W�����i�I���敪�擾�������s���܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        private void GetDisplayDivProc(List<PriceSelectSet> displayDivList, Int32 goodsMakerCode, Int32 blGoodsCode, Int32 customerCode, Int32 custRateGrpCode, out Int32 priceSelectDiv)
        {
            priceSelectDiv = 0;
            int location = -1;
            for (int i = 0; i < displayDivList.Count; i++)
            {
                // 0:Ұ�����ށEBL���ށE���Ӑ溰��
                if (goodsMakerCode == displayDivList[i].GoodsMakerCd &&
                    blGoodsCode == displayDivList[i].BLGoodsCode &&
                    customerCode == displayDivList[i].CustomerCode &&
                    0 == displayDivList[i].PriceSelectPtn)
                {
                    location = i;
                    break;

                }
                // 1:Ұ�����ށE���Ӑ溰�� 
                else if (goodsMakerCode == displayDivList[i].GoodsMakerCd &&
                    customerCode == displayDivList[i].CustomerCode &&
                    1 == displayDivList[i].PriceSelectPtn)
                {
                    location = i;
                    break;

                }
                // 2:BL���ށE���Ӑ溰�� 
                else if (blGoodsCode == displayDivList[i].BLGoodsCode &&
                    customerCode == displayDivList[i].CustomerCode &&
                    2 == displayDivList[i].PriceSelectPtn)
                {
                    location = i;
                    break;

                }
                // 3:Ұ�����ށEBL���ށE���Ӑ�|����ٰ�� 
                else if (goodsMakerCode == displayDivList[i].GoodsMakerCd &&
                    blGoodsCode == displayDivList[i].BLGoodsCode &&
                    custRateGrpCode == displayDivList[i].CustRateGrpCode &&
                    3 == displayDivList[i].PriceSelectPtn)
                {
                    location = i;
                    break;

                }
                // 4:Ұ�����ށE���Ӑ�|����ٰ�� 
                else if (goodsMakerCode == displayDivList[i].GoodsMakerCd &&
                    custRateGrpCode == displayDivList[i].CustRateGrpCode &&
                    4 == displayDivList[i].PriceSelectPtn)
                {
                    location = i;
                    break;

                }
                // 5:BL���ށE���Ӑ�|����ٰ�� 
                else if (blGoodsCode == displayDivList[i].BLGoodsCode &&
                   custRateGrpCode == displayDivList[i].CustRateGrpCode &&
                   5 == displayDivList[i].PriceSelectPtn)
                {
                    location = i;
                    break;

                }
                // 6:Ұ�����ށEBL���� 
                else if (blGoodsCode == displayDivList[i].BLGoodsCode &&
                    goodsMakerCode == displayDivList[i].GoodsMakerCd &&
                    6 == displayDivList[i].PriceSelectPtn)
                {
                    location = i;
                    break;

                }
                // 7:Ұ������ 
                else if (goodsMakerCode == displayDivList[i].GoodsMakerCd &&
                         7 == displayDivList[i].PriceSelectPtn)
                {
                    location = i;
                    break;

                }
                // 8:BL����
                else if (blGoodsCode == displayDivList[i].BLGoodsCode &&
                         8 == displayDivList[i].PriceSelectPtn)
                {
                    location = i;
                    break;

                }
            }
            if (location < 0)
            {
                priceSelectDiv = -1;
            }
            else
            {
                priceSelectDiv = displayDivList[location].PriceSelectDiv;
            }
        }
        #endregion

        #region -- �N���X�����o�[�R�s�[���� --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�\���敪�}�X�^���[�N�N���X�˕\���敪�}�X�^�N���X�j
        /// </summary>
        /// <param name="priceSelectSetWork">�\���敪�}�X�^���[�N�N���X</param>
        /// <returns>�\���敪�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �\���敪�}�X�^���[�N�N���X����\���敪�}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        private PriceSelectSet CopyToPriceSelectSetFromPriceSelectSetWork(PriceSelectSetWork priceSelectSetWork)
        {
            PriceSelectSet priceSelectSet = new PriceSelectSet();
            priceSelectSet.CreateDateTime = priceSelectSetWork.CreateDateTime;
            priceSelectSet.UpdateDateTime = priceSelectSetWork.UpdateDateTime;
            priceSelectSet.EnterpriseCode = priceSelectSetWork.EnterpriseCode;
            priceSelectSet.FileHeaderGuid = priceSelectSetWork.FileHeaderGuid;
            priceSelectSet.UpdEmployeeCode = priceSelectSetWork.UpdEmployeeCode;
            priceSelectSet.UpdAssemblyId1 = priceSelectSetWork.UpdAssemblyId1;
            priceSelectSet.UpdAssemblyId2 = priceSelectSetWork.UpdAssemblyId2;
            priceSelectSet.LogicalDeleteCode = priceSelectSetWork.LogicalDeleteCode;
            priceSelectSet.PriceSelectPtn = priceSelectSetWork.PriceSelectPtn;
            priceSelectSet.GoodsMakerCd = priceSelectSetWork.GoodsMakerCd;
            priceSelectSet.BLGoodsCode = priceSelectSetWork.BLGoodsCode;
            priceSelectSet.CustRateGrpCode = priceSelectSetWork.CustRateGrpCode;
            priceSelectSet.CustomerCode = priceSelectSetWork.CustomerCode;
            priceSelectSet.PriceSelectDiv = priceSelectSetWork.PriceSelectDiv;
            priceSelectSet.CustomerSnm = priceSelectSetWork.CustomerSnm;
            priceSelectSet.BLGoodsFullName = priceSelectSetWork.BLGoodsFullName;
            priceSelectSet.MakerName = priceSelectSetWork.MakerName;

            return priceSelectSet;

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�\���敪�}�X�^�N���X�˕\���敪�}�X�^���[�N�N���X�j
        /// </summary>
        /// <param name="priceSelectSet">�\���敪�}�X�^�N���X</param>
        /// <returns>�\���敪�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �\���敪�}�X�^�N���X����\���敪�}�X�^���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        private PriceSelectSetWork CopyToPriceSelectSetWorkFromPriceSelectSet(PriceSelectSet priceSelectSet)
        {
            PriceSelectSetWork priceSelectSetWork = new PriceSelectSetWork();
            priceSelectSetWork.CreateDateTime = priceSelectSet.CreateDateTime;
            priceSelectSetWork.UpdateDateTime = priceSelectSet.UpdateDateTime;
            priceSelectSetWork.EnterpriseCode = priceSelectSet.EnterpriseCode;
            priceSelectSetWork.FileHeaderGuid = priceSelectSet.FileHeaderGuid;
            priceSelectSetWork.UpdEmployeeCode = priceSelectSet.UpdEmployeeCode;
            priceSelectSetWork.UpdAssemblyId1 = priceSelectSet.UpdAssemblyId1;
            priceSelectSetWork.UpdAssemblyId2 = priceSelectSet.UpdAssemblyId2;
            priceSelectSetWork.LogicalDeleteCode = priceSelectSet.LogicalDeleteCode;
            priceSelectSetWork.PriceSelectPtn = priceSelectSet.PriceSelectPtn;
            priceSelectSetWork.GoodsMakerCd = priceSelectSet.GoodsMakerCd;
            priceSelectSetWork.BLGoodsCode = priceSelectSet.BLGoodsCode;
            priceSelectSetWork.CustRateGrpCode = priceSelectSet.CustRateGrpCode;
            priceSelectSetWork.CustomerCode = priceSelectSet.CustomerCode;
            priceSelectSetWork.PriceSelectDiv = priceSelectSet.PriceSelectDiv;
            priceSelectSetWork.CustomerSnm = priceSelectSet.CustomerSnm;
            priceSelectSetWork.BLGoodsFullName = priceSelectSet.BLGoodsFullName;
            priceSelectSetWork.MakerName = priceSelectSet.MakerName;

            return priceSelectSetWork;
        }

        # endregion

        /// <summary>
        /// ���O�o��(DEBUG)����
        /// </summary>
        /// <param name="pMsg"></param>
        public static void LogWrite(string pMsg)
        {
#if DEBUG
            System.IO.FileStream _fs;										// �t�@�C���X�g���[��
            System.IO.StreamWriter _sw;										// �X�g���[��writer
            _fs = new System.IO.FileStream("PMHNB09003A.Log", System.IO.FileMode.Append, System.IO.FileAccess.Write, System.IO.FileShare.Write);
            _sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));
            DateTime edt = DateTime.Now;
            //yyyy/MM/dd hh:mm:ss
            _sw.WriteLine(string.Format("{0,-19} {1,-5} ==> {2}", edt, edt.Millisecond, pMsg));
            if (_sw != null)
                _sw.Close();
            if (_fs != null)
                _fs.Close();
#endif
        }
    }
}

//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���[�J�[�i�ԃp�^�[���}�X�^
// �v���O�����T�v   : ���[�J�[�i�ԃp�^�[���}�X�^ �A�N�Z�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright 2020 Broadleaf Co.,Ltd.
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570249-00   �쐬�S�� : ���O
// �� �� ��  2020/03/09    �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���[�J�[�i�ԃp�^�[���}�X�^�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���[�J�[�i�ԃp�^�[���}�X�^�A�N�Z�X�N���X</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2020/03/09</br>
    /// </remarks>
    public class HandyMakerGoodsPtrnAcs
    {
        #region �� Private Members
        private IHandyMakerGoodsPtrnDB IMakerGoodsPtrnDB;       // ���[�J�[�i�ԃp�^�[���}�X�^
        private DateGetAcs DateGetAcs;                          // �f�[�^�擾�A�N�Z�X
        #endregion �� Private Members

        #region �� Constructor
        /// <summary>
        /// ���[�J�[�i�ԃp�^�[���}�X�^�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�J�[�i�ԃp�^�[���}�X�^�A�N�Z�X�N���X</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public HandyMakerGoodsPtrnAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this.IMakerGoodsPtrnDB = (IHandyMakerGoodsPtrnDB)MediationHandyMakerGoodsPtrnDB.GetHandyMakerGoodsPtrnDB();
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this.IMakerGoodsPtrnDB = null;
            }

            this.DateGetAcs = DateGetAcs.GetInstance();
        }
        #endregion �� Constructor

        #region �� Public Methods
        #region �I�����C�����[�h�擾
        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this.IMakerGoodsPtrnDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }
        #endregion �I�����C�����[�h�擾

        #region ��������
        /// <summary>
        /// �w�肳�ꂽ�����̃��[�J�[�i�ԃp�^�[���}�X�^��񌟍�(���[�J�[�i�ԃp�^�[��No.�̏��)
        /// </summary>
        /// <param name="makerGoodsPtrnList">���ʃ��X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="goodsMakerCd">���[�J�[�R�[�h</param>
        /// <param name="barCodeLength">�o�[�R�[�h����</param>
        /// <param name="controlStr">���䕶����</param>
        /// <param name="mode">0�F�}�X�^�p�G1�F���i����p</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̃��[�J�[�i�ԃp�^�[���}�X�^����߂��܂�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int ReadByMakerAndBarCodeLength(out ArrayList makerGoodsPtrnList, string enterpriseCode, int goodsMakerCd, int barCodeLength, string controlStr, int mode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            makerGoodsPtrnList = new ArrayList();

            try
            {
                HandyMakerGoodsPtrnWork paraMakerGoodsPtrn = new HandyMakerGoodsPtrnWork();
                paraMakerGoodsPtrn.EnterpriseCode = enterpriseCode;
                paraMakerGoodsPtrn.GoodsMakerCd = goodsMakerCd;
                paraMakerGoodsPtrn.BarCodeLength = barCodeLength;
                paraMakerGoodsPtrn.ControlStr = controlStr;

                object retObj = null;
                //�}�X�^�ǂݍ���
                status = this.IMakerGoodsPtrnDB.ReadByMakerAndBarCodeLength(out retObj, paraMakerGoodsPtrn, 0, mode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �p�����[�^���n���ė��Ă��邩�m�F
                    ArrayList al = retObj as ArrayList;
                    if (al == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // �f�[�^�ϊ�
                    foreach (HandyMakerGoodsPtrnWork makerGoodsPtrnWork in al)
                    {
                        makerGoodsPtrnList.Add(makerGoodsPtrnWork);
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̃��[�J�[�i�ԃp�^�[���}�X�^��񌟍�(���[�J�[�i�ԃp�^�[��No.�̏��)
        /// </summary>
        /// <param name="makerGoodsPtrnWork">Primary Key��񃊃X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="makerGoodsPtrnNo">���[�J�[�i�ԃp�^�[��No.</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̃��[�J�[�i�ԃp�^�[���}�X�^����߂��܂�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int Read(out HandyMakerGoodsPtrnWork makerGoodsPtrnWork, string enterpriseCode, int makerGoodsPtrnNo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            makerGoodsPtrnWork = null;

            try
            {
                HandyMakerGoodsPtrnWork paraMakerGoodsPtrn = new HandyMakerGoodsPtrnWork();
                paraMakerGoodsPtrn.EnterpriseCode = enterpriseCode;
                paraMakerGoodsPtrn.MakerGoodsPtrnNo = makerGoodsPtrnNo;

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(paraMakerGoodsPtrn);

                //�]�ƈ��ǂݍ���
                status = this.IMakerGoodsPtrnDB.Read(ref parabyte, 0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // XML�̓ǂݍ���
                    makerGoodsPtrnWork = (HandyMakerGoodsPtrnWork)XmlByteSerializer.Deserialize(parabyte, typeof(HandyMakerGoodsPtrnWork));
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// ��������(���[�J�[�i�ԃp�^�[���}�X�^)
        /// </summary>
        /// <param name="retList">���[�J�[�i�ԃp�^�[���}�X�^���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[�i�ԃp�^�[���}�X�^���������܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            retList = new ArrayList();

            try
            {
                HandyMakerGoodsPtrnWork paraWork = new HandyMakerGoodsPtrnWork();
                paraWork.EnterpriseCode = enterpriseCode;
                object retObj = null;

                // ��������
                status = this.IMakerGoodsPtrnDB.Search(out retObj, paraWork, 0, ConstantManagement.LogicalMode.GetData01);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �p�����[�^���n���ė��Ă��邩�m�F
                    ArrayList al = retObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // �f�[�^�ϊ�
                    foreach (HandyMakerGoodsPtrnWork makerGoodsPtrnWork in al)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        retList.Add(makerGoodsPtrnWork);
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }
        #endregion ��������

        #region �X�V����
        /// <summary>
        /// �X�V����(���[�J�[�i�ԃp�^�[���}�X�^)
        /// </summary>
        /// <param name="makerGoodsPtrnWork">���[�J�[�i�ԃp�^�[���}�X�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[�i�ԃp�^�[���}�X�^���X�V���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       :2020/03/09</br>
        /// </remarks>
        public int Write(ref HandyMakerGoodsPtrnWork makerGoodsPtrnWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(makerGoodsPtrnWork);

                // �X�V����
                status = this.IMakerGoodsPtrnDB.Write(ref parabyte);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �t�@�C������n���ċ��_��񃏁[�N�N���X���f�V���A���C�Y����
                    makerGoodsPtrnWork = (HandyMakerGoodsPtrnWork)XmlByteSerializer.Deserialize(parabyte, typeof(HandyMakerGoodsPtrnWork));
                    if (makerGoodsPtrnWork == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }
        #endregion �X�V����

        #region �_���폜����
        /// <summary>
        /// �_���폜����(���[�J�[�i�ԃp�^�[���}�X�^)
        /// </summary>
        /// <param name="paraWork">��������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[�i�ԃp�^�[���}�X�^��_���폜���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int LogicalDelete(ref HandyMakerGoodsPtrnWork paraWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                object paraObj = (object)paraWork;
                // �_���폜����
                status = this.IMakerGoodsPtrnDB.LogicalDelete(ref paraObj);
                paraWork = paraObj as HandyMakerGoodsPtrnWork;
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }
        #endregion �_���폜����

        #region �����폜����
        /// <summary>
        /// �����폜����(���[�J�[�i�ԃp�^�[���}�X�^)
        /// </summary>
        /// <param name="paraWork">��������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[�i�ԃp�^�[���}�X�^�𕨗��폜���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int Delete(HandyMakerGoodsPtrnWork paraWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                // �����폜����
                status = this.IMakerGoodsPtrnDB.Delete(paraWork);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }
        #endregion �����폜����

        #region ��������
        /// <summary>
        /// ��������(���[�J�[�i�ԃp�^�[���}�X�^)
        /// </summary>
        /// <param name="paraWork">��������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[�i�ԃp�^�[���}�X�^�𕜊����܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int Revival(ref HandyMakerGoodsPtrnWork paraWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                object paraObj = (object)paraWork;
                // �_���폜����
                status = this.IMakerGoodsPtrnDB.RevivalLogicalDelete(ref paraObj);
                paraWork = paraObj as HandyMakerGoodsPtrnWork; 
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }
        #endregion ��������

        #region [�Ɖ�]
        /// <summary>
        /// ���[�J�[�i�ԃp�^�[���}�X�^�������𒊏o����
        /// </summary>
        /// <param name="condObj">��������</param>
        /// <param name="retObj">���[�J�[�i�ԃp�^�[���}�X�^���������f�[�^���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[�i�ԃp�^�[���}�X�^�������𒊏o�������s���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int SearchHis(object condObj, out object retObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retObj = null;
            try
            {
                // ���[�J�[�i�ԃp�^�[���}�X�^�������𒊏o
                status = IMakerGoodsPtrnDB.SearchHis(condObj, out retObj);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        #endregion

        #region �݌Ɉꊇ�폜
        /// <summary>
        /// ��ʏ����ɂ���āA�݌Ɉꊇ�폜����
        /// </summary>
        /// <param name="deleteStockCondWork">��������</param>
        /// <remarks>
        /// <br>Note		: ��ʏ����ɂ���āA�������ʎ擾�B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2020/03/09</br>
        /// </remarks>
        public int DeleteStockWithMng(HandyDeleteStockCondWork deleteStockCondWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            ArrayList handyDeleteStockList = null;
            object handyDeleteStockRsltList = null;

            // �݌Ɉꊇ�폜�Ώے��o
            status = this.IMakerGoodsPtrnDB.SearchDeleteStockWithMng((object)deleteStockCondWork, out handyDeleteStockRsltList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                handyDeleteStockList = handyDeleteStockRsltList as ArrayList;
                foreach (HandyDeleteStockRsltWork handyDeleteStock in handyDeleteStockList)
                {
                    // �݌Ɉꊇ�폜
                    status = this.IMakerGoodsPtrnDB.DeleteStockWithMng((object)handyDeleteStock, deleteStockCondWork.EnterpriseCode);

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        break;
                    }
                }
            }

            // ���엚�����O�o�^
            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
            string operationMsg;

            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                operationMsg = "�폜�Ώۃf�[�^������܂���B";
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                operationMsg = "����ɏI�����܂����B";
            }
            else
            {
                operationMsg = "�G���[���������܂����B";
            }

            operationHistoryLog.WriteOperationLog(this, LogDataKind.OperationLog, "PMKHN09770U", "�݌Ɉꊇ�폜", "", 6, status, operationMsg, "");

            return status;
        }

        #endregion �݌Ɉꊇ�폜

        #region ���i�o�[�R�[�h�֘A�t���}�X�^����
        /// <summary>
        /// ���i�o�[�R�[�h�֘A�t���}�X�^��������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="goodsBarCode">�p�[�R�[�h</param>
        /// <param name="goodsMakerCd">���[�J�[�R�[�h</param>
        /// <param name="retObj">���i�o�[�R�[�h�֘A�t���}�X�^���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���i�o�[�R�[�h�֘A�t���}�X�^�����������s���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int SearchGoodsBarCodeRevn(string enterpriseCode, string goodsBarCode, int goodsMakerCd, out object retObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retObj = null;
            try
            {
                // ���i�o�[�R�[�h�֘A�t���}�X�^����
                status = IMakerGoodsPtrnDB.SearchGoodsBarCodeRevn(enterpriseCode, goodsBarCode, goodsMakerCd, out retObj);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion

        #region UOE�����f�[�^����
        /// <summary>
        /// UOE�����f�[�^��������
        /// </summary>
        /// <param name="condObj">��������</param>
        /// <param name="count">�߂茏��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : UOE�����f�[�^�����������s���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int SearchHandyUOEOrder(ref object condObj, out int count)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            count = 0;
            try
            {
                // UOE�����f�[�^���݃`�F�b�N
                status = IMakerGoodsPtrnDB.SearchHandyUOEOrder(ref condObj, out count);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        #endregion

        #region ���[�J�[�i�ԃp�^�[�����������f�[�^�o�^
        /// <summary>
        /// ���[�J�[�i�ԃp�^�[�����������f�[�^�o�^
        /// </summary>
        /// <param name="searcHisWork">���[�J�[�i�ԃp�^�[�����������f�[�^</param>
        /// <param name="mode">0:�V�K�o�^�G1�F�X�V</param>
        /// <param name="callMode">0�F�p�^�[�����������G1�F�p�^�[�����������ȊO</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[�i�ԃp�^�[�����������f�[�^��o�^�E�X�V���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int WriteHis(ref HandyMakerGoodsPtrnHisResultWork searcHisWork, int mode, int callMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(searcHisWork);

                // �X�V����
                status = this.IMakerGoodsPtrnDB.WriteHis(ref parabyte, mode, callMode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �t�@�C������n���ă��[�J�[�i�ԃp�^�[�����������f�[�^���[�N�N���X���f�V���A���C�Y����
                    searcHisWork = (HandyMakerGoodsPtrnHisResultWork)XmlByteSerializer.Deserialize(parabyte, typeof(HandyMakerGoodsPtrnHisResultWork));
                    if (searcHisWork == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }
        #endregion �X�V����

        #region �n���f�B�݌ɓo�^�Ǘ��f�[�^�o�^
        /// <summary>
        /// �n���f�B�݌ɓo�^�Ǘ��f�[�^�o�^
        /// </summary>
        /// <param name="mngWork">��������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �n���f�B�݌ɓo�^�Ǘ��f�[�^��o�^�E�X�V���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int WriteMng(HandyZaikoRegistMngWork mngWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {

                // �X�V����
                object condObj = (object)mngWork;
                status = this.IMakerGoodsPtrnDB.WriteMng(condObj);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }
        #endregion �X�V����
        #endregion �� Public Methods

    }
}

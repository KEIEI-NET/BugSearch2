//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �݌Ɉړ��f�[�^�W�v�����[�g
// �v���O�����T�v   : �݌Ɉړ��f�[�^��M���ɍ݌Ƀ}�X�^�̍X�V���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2011/08/10  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2011/08/24  �C�����e : #23964 �\�[�X���r���[���ʇ@��NO.4�@��M���X�V�����ł́u���׊m��Ȃ��v�Œ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� �B
// �C �� ��  2012/03/16  �C�����e : �^�C���A�E�g�Ή�(30�b��600�b)
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ��M�݌Ɉړ��f�[�^�W�v�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��M�݌Ɉړ��f�[�^�W�v������s���N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2011.8.10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class APTotalizeStockMoveDB : RemoteDB
    {
        #region [�ϐ���`]
        //��M�����׊m��敪
        //private int _stockMoveFixCode = 0;//DEL 2011/08/24 #23964 �\�[�X���r���[���ʇ@��NO.4�@��M���X�V�����ł́u���׊m��Ȃ��v�Œ�
        #endregion

        #region[�p�u���b�N���@]
        /// <summary>
        /// �݌Ɉړ��f�[�^��M�X�V����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="paramStockMoveList">��M�����݌Ɉړ��f�[�^���X�g</param>
        /// <param name="sqlConnection">DB�ڑ�</param>
        /// <param name="sqlTransaction">DB�g�����U�N�V����</param>
        /// <param name="retMsg">�G���[���</param>
        /// <returns>�X�e�[�^�X</returns>
        public int TotalizeStokMove(string enterpriseCode, ArrayList paramStockMoveList, SqlConnection sqlConnection, SqlTransaction sqlTransaction, out string retMsg)
        {
            //�G���[���
            retMsg = string.Empty;

            //�X�e�[�^�X
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // �p�����[�^�`�F�b�N
            if (paramStockMoveList == null || paramStockMoveList.Count == 0)
                return status;

            // ��ƃR�[�h���o�b�N�A�b�v
            string enterpriseCodeBak = ((APStockMoveWork)paramStockMoveList[0]).EnterpriseCode;
            try
            {
                // ��M���_���̊�ƃR�[�h���Z�b�g
                SetEnterpriseCodeToWorkList(enterpriseCode, paramStockMoveList);

                //��M�����׊m��敪�擾
                //_stockMoveFixCode = GetStockMoveFixCode(enterpriseCode);//DEL 2011/08/24 #23964 �\�[�X���r���[���ʇ@��NO.4�@��M���X�V�����ł́u���׊m��Ȃ��v�Œ�

                // �݌Ɉړ��f�[�^��M�X�V����
                status = TotalizeStokMove(paramStockMoveList, sqlConnection, sqlTransaction, out retMsg);
            }
            finally
            {
                // ��ƃR�[�h�����X�g�A
                SetEnterpriseCodeToWorkList(enterpriseCodeBak, paramStockMoveList);
            }
            return status;
        }
        #endregion

        #region [�v���C�x�[�g���@]
        /// <summary>
        /// �݌Ɉړ��f�[�^��M�X�V����
        /// </summary>
        /// <param name="paramStockMoveList">��M�����݌Ɉړ��f�[�^���X�g</param>
        /// <param name="sqlConnection">DB�ڑ�</param>
        /// <param name="sqlTransaction">DB�g�����U�N�V����</param>
        /// <param name="retMsg">�G���[���</param>
        /// <returns>�X�e�[�^�X</returns>
        private int TotalizeStokMove(ArrayList paramStockMoveList, SqlConnection sqlConnection, SqlTransaction sqlTransaction, out string retMsg)
        {
            //�G���[���
            retMsg = string.Empty;
            //�X�e�[�^�X
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            //�݌ɍX�V
            StockMoveDB _stockMoveDB = new StockMoveDB();
            APStockMoveInfoConverter converter = new APStockMoveInfoConverter();
            ArrayList stockList = new ArrayList();
            Hashtable slipNo = new Hashtable();

            //�`�[�P�ʂŌJ��Ԃ�
            for (int i = 0; i < paramStockMoveList.Count; i++)
            {
                //�݌ɍX�V�f�[�^�p�����[�^�ƍ݌Ɏ󕥗����X�V�p�����[�^���X�V
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                
                    // ��M�����݌Ɉړ��f�[�^����M���_���݌Ɉړ��f�[�^�ɕϊ�
                    APStockMoveWork apStockMoveWork = paramStockMoveList[i] as APStockMoveWork;
                    if (slipNo.Contains(apStockMoveWork.StockMoveSlipNo))
                    {
                        continue;
                    }
                    else
                    {
                        slipNo.Add(apStockMoveWork.StockMoveSlipNo, i);
                        StockMoveWork stockMoveWork = converter.GetSecStockMoveWork(apStockMoveWork);
                        //stockMoveWork.StockMoveFixCode = _stockMoveFixCode;//DEL 2011/08/24 #23964 �\�[�X���r���[���ʇ@��NO.4�@��M���X�V�����ł́u���׊m��Ȃ��v�Œ�
                        stockMoveWork.StockMoveFixCode = 2;//ADD 2011/08/24 #23964 �\�[�X���r���[���ʇ@��NO.4�@��M���X�V�����ł́u���׊m��Ȃ��v�Œ�
                        stockList.Add(stockMoveWork);
                    }
                    for (int j = i + 1; j < paramStockMoveList.Count; j++)
                    {
                        APStockMoveWork apStockMoveWorkChild = paramStockMoveList[j] as APStockMoveWork;
                        if (apStockMoveWork.StockMoveSlipNo == apStockMoveWorkChild.StockMoveSlipNo)
                        {
                            StockMoveWork stockMoveWork = converter.GetSecStockMoveWork(apStockMoveWorkChild);
                            //stockMoveWork.StockMoveFixCode = _stockMoveFixCode;//DEL 2011/08/24 #23964 �\�[�X���r���[���ʇ@��NO.4�@��M���X�V�����ł́u���׊m��Ȃ��v�Œ�
                            stockMoveWork.StockMoveFixCode = 2;//ADD 2011/08/24 #23964 �\�[�X���r���[���ʇ@��NO.4�@��M���X�V�����ł́u���׊m��Ȃ��v�Œ�
                            stockList.Add(stockMoveWork);
                        }
                    }

                    if (apStockMoveWork.LogicalDeleteCode == 0)
                    {
                        status = _stockMoveDB.WriteForReceiveData(stockList, sqlConnection, sqlTransaction, out retMsg);
                    }
                    if (apStockMoveWork.LogicalDeleteCode == 1)
                    {
                        status = _stockMoveDB.DeleteForReceiveData(stockList, sqlConnection, sqlTransaction);
                    }

                    stockList.Clear();                    
                }
                else
                {
                    //�G���[����
                    break;
                }
                
            }
            //�߂�l
            return status;
        }

        /// <summary>
        /// ��M�����׊m��敪�擾
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns></returns>
        private int GetStockMoveFixCode(string enterpriseCode)
        {
            int stockMoveFixCode = 0;
            object obj = new object();
            ArrayList retList;
            StockMngTtlStDB stockMngTtlStDB = new StockMngTtlStDB();

            StockMngTtlStWork  stockMngTtlStWork = new StockMngTtlStWork();
            stockMngTtlStWork.EnterpriseCode = enterpriseCode;
            ArrayList stockMngTtlStWorkList = new ArrayList();
            stockMngTtlStWorkList.Add(stockMngTtlStWork);

            stockMoveFixCode = stockMngTtlStWork.StockMoveFixCode;

            int statusMngTtlSt = stockMngTtlStDB.Search(out obj, stockMngTtlStWorkList as object, 0, ConstantManagement.LogicalMode.GetData0);
            if (statusMngTtlSt == 0)
            {
                retList = obj as ArrayList;
                foreach (StockMngTtlStWork stockMngTtlSt in retList)
                {
                    if (stockMngTtlSt.SectionCode.Trim() == "00")
                    {
                        stockMoveFixCode = stockMngTtlSt.StockMoveFixCode;
                        break;
                    }
                }
            }

            return stockMoveFixCode;
        }
        /// <summary>
        /// ��ƃR�[�h�����[�N���X�g�ɃZ�b�g
        /// </summary>
        /// <param name="code">��ƃR�[�h</param>
        /// <param name="paramWkList">���[�N���X�g</param>
        private void SetEnterpriseCodeToWorkList(string code, ArrayList paramWkList)
        {
            if (null == paramWkList || paramWkList.Count == 0)
                return;
            foreach (Broadleaf.Library.Data.IFileHeader header in paramWkList)
                header.EnterpriseCode = code;
        }
        #endregion
    }
}

//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ԕi�s�ݒ�
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.NetworkInformation;
using System.Collections;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �ԕi�s�ݒ�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ԕi�s�ݒ�̃t�H�[���N���X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2009.04.20</br>
    /// </remarks>
    public class GoodsNotReturnAcs
    {
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region ��Constructor

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        private GoodsNotReturnAcs()
        {
            // �ϐ�������
            this._dataSet = new GoodsNotReturnDataSet();
            this._goodsNotReturnDetailDataTable = this._dataSet.GoodsNotReturnDetail;
            this.goodsNotReturnProcDB = GoodsNotReturnSetDB.GetGoodsNotReturnProcDB();
        }
        # endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        # region ��Properties

        /// <summary>
        /// �ԕi�s�ݒ薾�׃f�[�^�e�[�u���v���p�e�B
        /// </summary>
        public GoodsNotReturnDataSet.GoodsNotReturnDetailDataTable GoodsNotReturnDetailDataTable
        {
            get { return _goodsNotReturnDetailDataTable; }
        }

        /// <summary>
        /// �ԕi�s�ݒ�A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns>�ԕi�s�ݒ�A�N�Z�X�N���X �C���X�^���X</returns>
        public static GoodsNotReturnAcs GetInstance()
        {
            if (_goodsNotReturnAcs == null)
            {
                _goodsNotReturnAcs = new GoodsNotReturnAcs();
            }

            return _goodsNotReturnAcs;
        }
        # endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region ��Private Members
        private static GoodsNotReturnAcs _goodsNotReturnAcs;
        private GoodsNotReturnDataSet.GoodsNotReturnDetailDataTable _goodsNotReturnDetailDataTable;
        private GoodsNotReturnDataSet _dataSet;
        IGoodsNotReturnProcDB goodsNotReturnProcDB;
        # endregion

        // ===================================================================================== //
        // �p�u���b�N�C�x�[�g���\�b�h
        // ===================================================================================== //
        #region ��public Methods

        /// <summary>
        /// �ԕi�s�ݒ�f�[�^��������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="salesSlipNum">����`�[�ԍ�</param>
        /// <param name="goodsNotReturnList">����`�[�f�[�^���X�g</param>
        /// <param name="retMessage">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���b�Z�[�W�ɂ��A�ԕi�s�ݒ�f�[�^�����������s���܂��B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.20</br> 
        /// </remarks>
        public int ReadDBData(string enterpriseCode, string salesSlipNum, out ArrayList goodsNotReturnList, out string retMessage)
        {
            int status = this.goodsNotReturnProcDB.ReadDBData(enterpriseCode, salesSlipNum, out goodsNotReturnList, out retMessage);

            return status;
        }

        /// <summary>
        /// �ԕi�s�ݒ�f�[�^�X�V����
        /// </summary>
        /// <param name="goodsNotReturnList">����`�[�f�[�^���X�g</param>
        /// <param name="retMessage">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���b�Z�[�W�ɂ��A�ԕi�s�ݒ�f�[�^�X�V�������s���܂��B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.20</br> 
        /// </remarks>
        public int UpdateReturnUpper(ArrayList goodsNotReturnList, out string retMessage)
        {
            int status = this.goodsNotReturnProcDB.UpdateReturnUpper(ref goodsNotReturnList, out retMessage);

            return status;
        }

        /// <summary>
        /// �ԕi�s�ݒ�f�[�^��ʏo��
        /// </summary>
        /// <param name="goodsNotReturnList">����`�[�f�[�^���X�g</param>
        /// <remarks>
        /// <br>Note       : ���b�Z�[�W�ɂ��A�ԕi�s�ݒ�f�[�^�o�͏������s���܂��B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.20</br> 
        /// </remarks>
        public ArrayList goodsNotReturnCache(ArrayList goodsNotReturnList)
        {
            int rowNo = 0;
            ArrayList goodsNotReturnListTmp = new ArrayList();
            foreach (GoodsNotReturnWork work in goodsNotReturnList)
            {

                GoodsNotReturnDataSet.GoodsNotReturnDetailRow row = _goodsNotReturnDetailDataTable.NewGoodsNotReturnDetailRow();

                // NO.
                rowNo = rowNo + 1;
                row.RowNo = rowNo;
                // ���i�ԍ�
                row.ProductNo = work.GoodsNo;
                // ���i����
                row.GoodsName = work.GoodsName;
                // ���[�J�[����
                row.Manufacturer = work.MakerName;
                // �o�א�
                double shipmentCnt = work.ShipmentCnt;
                row.ShipmentNo = shipmentCnt;
                // �ԕi�ϐ�
                double acptAnOdrRemainCnt = work.AcptAnOdrRemainCnt;
                double returnNo = shipmentCnt - acptAnOdrRemainCnt;
                row.ReturnNo = returnNo;
                // �ԕi�����
                row.LimitReturnNo = work.RetUpperCnt;
                // �󒍃X�e�[�^�X
                row.AcptAnOdrStatus = work.AcptAnOdrStatus;
                // ���㖾�גʔ�
                row.SalesSlipDtlNum = work.SalesSlipDtlNum;
                // �X�V����
                row.UpdateTime = work.UpdateDateTime;
                // �擾�������㖾�׏��D����`�[�敪�i���ׁj���u2�F�l���v�̏ꍇ�A���ו����ɕ\�����Ȃ��G
                if (work.SalesSlipCdDtl != 2 && work.ShipmentCnt >= 0 && work.DtlLogicalDeleteCode == 0)
                {
                    _goodsNotReturnDetailDataTable.Rows.Add(row);
                    goodsNotReturnListTmp.Add(work);
                }
                else
                {
                    rowNo = rowNo - 1;
                }

                if (rowNo == 99)
                {
                    break;
                }
            }
            return goodsNotReturnListTmp;
        }

        /// <summary>
        /// ���O�I�����I�����C����ԃ`�F�b�N����
        /// </summary>
        /// <returns>�`�F�b�N��������</returns>
        /// <remarks>
        /// <br>Note       : ���O�I�����I�����C����ԃ`�F�b�N�������s���܂��B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.01</br> 
        /// </remarks>
        public bool CheckOnline()
        {
            if (Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag == false)
            {
                return false;
            }
            else
            {
                // ���[�J���G���A�ڑ���Ԃɂ��I�����C������
                if (CheckRemoteOn() == false)
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        #region ��Private Methods
        /// <summary>
        /// �����[�g�ڑ��\����
        /// </summary>
        /// <returns>���茋��</returns>
        /// <remarks>
        /// <br>Note       : ���O�I�����I�����C����ԃ`�F�b�N�������s���܂��B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.01</br> 
        /// </remarks>
        private bool CheckRemoteOn()
        {
            bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();

            if (isLocalAreaConnected == false)
            {
                // �C���^�[�l�b�g�ڑ��s�\���
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}

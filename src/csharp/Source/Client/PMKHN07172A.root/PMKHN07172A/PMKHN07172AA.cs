//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����}�X�^�i�G�N�X�|�[�g�j
// �v���O�����T�v   : �����}�X�^�̴���߰ď������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/05/14  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �����}�X�^�e�[�u���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2009.05.14</br>
    /// <br></br>
    /// </remarks>
    public class JoinPartsSetExpAcs
    {
        private static bool _isLocalDBRead = false;

        /// <summary>���i�Z�b�g�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        private IJoinPartsUDB _joinPartsUDB;

        private Dictionary<int, MakerUMnt> _MakerDic;
        private MakerAcs _makerAcs;

        /// <summary> ���[�J���c�a�Q�ƃ��[�h�v���p�e�B</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
        /// �����}�X�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public JoinPartsSetExpAcs()
        {
            this._joinPartsUDB = (IJoinPartsUDB)MediationJoinPartsUDB.GetJoinPartsUDB();
            this._makerAcs = new MakerAcs();
        }

        /// <summary>�I�����C�����[�h�̗񋓌^�ł��B</summary>
        public enum OnlineMode
        {
            /// <summary>�I�t���C��</summary>
            Offline,
            /// <summary>�I�����C��</summary>
            Online
        }

        /// <summary>
        /// �����}�X�^�S���������i�_���폜�����j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="joinPartsExpWork">���o����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, JoinPartsExpWork joinPartsExpWork)
        {
            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, joinPartsExpWork);
        }

        /// <summary>
        /// �����}�X�^���������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="joinPartsExpWork">���o����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, JoinPartsExpWork joinPartsExpWork)
        {
            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, joinPartsExpWork);
        }

        /// <summary>
        /// �����}�X�^��������
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="joinPartsExpWork">���o����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����}�X�^�����������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, JoinPartsExpWork joinPartsExpWork)
        {
            JoinPartsUWork goodsSetWork = new JoinPartsUWork();

            goodsSetWork.EnterpriseCode = enterpriseCode;

            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int checkstatus = 0;
            nextData = false;
            retTotalCnt = 0;

            // ��������
            retList = new ArrayList();
            retList.Clear();

            ArrayList paraList = new ArrayList();
            paraList.Clear();

            object paraobj = goodsSetWork;
            object retobj = new ArrayList();

            status = this._joinPartsUDB.Search(ref retobj, paraobj, 0, logicalMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND|| status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                paraList = retobj as ArrayList;
                foreach (JoinPartsUWork joinPartsUWork in paraList)
                {
                    // ���o����
                    checkstatus = DataCheck(joinPartsUWork, joinPartsExpWork);
                    if (checkstatus == 0)
                    {
                        //�a�k�O���[�v���N���X�փ����o�R�s�[
                        retList.Add(CopyToJoinPartsSetFromSecInfoSetWork(joinPartsUWork, enterpriseCode));
                    }
                }
            }
            else
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            //�S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
            if (readCnt == 0) retTotalCnt = retList.Count;

            return status;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�����}�X�^���[�N�N���X�ˌ����}�X�^�N���X�j
        /// </summary>
        /// <param name="joinPartsUWork">�����}�X�^���[�N�N���X</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�����}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �����}�X�^���[�N�N���X���猋���}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private JoinPartsSetExp CopyToJoinPartsSetFromSecInfoSetWork(JoinPartsUWork joinPartsUWork, string enterpriseCode)
        {
            JoinPartsSetExp joinPartsSetExp = new JoinPartsSetExp();

            joinPartsSetExp.JoinSourceMakerCode = joinPartsUWork.JoinSourceMakerCode;
            joinPartsSetExp.JoinSourceMakerName = GetMakerName(joinPartsUWork.JoinSourceMakerCode, enterpriseCode);
            joinPartsSetExp.JoinSourPartsNoWithH = joinPartsUWork.JoinSourPartsNoWithH;
            joinPartsSetExp.JoinSourPartsNoNoneH = joinPartsUWork.JoinSourPartsNoNoneH;
            //joinPartsSetExp.GoodsNameKana = goodName;
            joinPartsSetExp.JoinDispOrder = joinPartsUWork.JoinDispOrder;
            joinPartsSetExp.JoinDestPartsNo = joinPartsUWork.JoinDestPartsNo;
            joinPartsSetExp.JoinDestMakerCd = joinPartsUWork.JoinDestMakerCd;
            joinPartsSetExp.JoinDestMakerName = GetMakerName(joinPartsUWork.JoinDestMakerCd, enterpriseCode);
            joinPartsSetExp.JoinQty = joinPartsUWork.JoinQty;
            joinPartsSetExp.JoinSpecialNote = joinPartsUWork.JoinSpecialNote;

            return joinPartsSetExp;
        }

        /// <summary>
        /// ���[�J�[���̎擾����
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>���[�J�[����</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[���̂��擾���܂��B</br>
        /// </remarks>
        private string GetMakerName(int makerCode, string enterpriseCode)
        {
            string makerName = "";
            ReadMaker(enterpriseCode);
            if (this._MakerDic.ContainsKey(makerCode))
            {
                makerName = this._MakerDic[makerCode].MakerName.Trim();
            }

            return makerName;
        }

        /// <summary>
        /// ���[�J�[�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�J�[�ꗗ��ǂݍ��݂܂��B</br>
        /// </remarks>
        private void ReadMaker(string enterpriseCode)
        {
            try
            {
                if (this._MakerDic.Count == 0)
                {
                    this._MakerDic = new Dictionary<int, MakerUMnt>();

                    ArrayList retList;

                    int status = this._makerAcs.SearchAll(out retList, enterpriseCode);
                    if (status == 0)
                    {
                        foreach (MakerUMnt mkerUMnt in retList)
                        {
                            if (mkerUMnt.LogicalDeleteCode == 0)
                            {
                                this._MakerDic.Add(mkerUMnt.GoodsMakerCd, mkerUMnt);
                            }
                        }
                    }
                }
            }
            catch
            {
                this._MakerDic = new Dictionary<int, MakerUMnt>();

                ArrayList retList;

                int status = this._makerAcs.SearchAll(out retList, enterpriseCode);
                if (status == 0)
                {
                    foreach (MakerUMnt mkerUMnt in retList)
                    {
                        if (mkerUMnt.LogicalDeleteCode == 0)
                        {
                            this._MakerDic.Add(mkerUMnt.GoodsMakerCd, mkerUMnt);
                        }
                    }
                }
            }
            return;
        }

        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="joinPartsUWork">��������</param>
        /// <param name="joinPartsPrintWork">���o����</param>
        /// <returns></returns>
        private int DataCheck(JoinPartsUWork joinPartsUWork, JoinPartsExpWork joinPartsPrintWork)
        {
            int status = 0;

            // �_���폜�敪
            if (joinPartsUWork.LogicalDeleteCode != 0)
            {
                status = -1;
                return status;
            }

            // ���������[�J�[�R�[�h
            if (joinPartsPrintWork.JoinSourceMakerCodeSt != 0 &&
                joinPartsPrintWork.JoinSourceMakerCodeEd != 0)
            {
                if (joinPartsUWork.JoinSourceMakerCode < joinPartsPrintWork.JoinSourceMakerCodeSt ||
                   joinPartsUWork.JoinSourceMakerCode > joinPartsPrintWork.JoinSourceMakerCodeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (joinPartsPrintWork.JoinSourceMakerCodeSt != 0)
            {
                if (joinPartsUWork.JoinSourceMakerCode < joinPartsPrintWork.JoinSourceMakerCodeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (joinPartsPrintWork.JoinSourceMakerCodeEd != 0)
            {
                if (joinPartsUWork.JoinSourceMakerCode > joinPartsPrintWork.JoinSourceMakerCodeEd)
                {
                    status = -1;
                    return status;
                }
            }

            // �������i��
            if (!joinPartsPrintWork.JoinSourPartsNoWithHSt.Trim().Equals(string.Empty) &&
                !joinPartsPrintWork.JoinSourPartsNoWithHEd.Trim().Equals(string.Empty))
            {
                if (joinPartsPrintWork.JoinSourPartsNoWithHSt.CompareTo(joinPartsUWork.JoinSourPartsNoWithH) > 0 ||
                    joinPartsPrintWork.JoinSourPartsNoWithHEd.CompareTo(joinPartsUWork.JoinSourPartsNoWithH) < 0)
                {
                    status = -1;
                    return status;
                }
            }
            else if (!joinPartsPrintWork.JoinSourPartsNoWithHSt.Trim().Equals(string.Empty))
            {
                if (joinPartsPrintWork.JoinSourPartsNoWithHSt.CompareTo(joinPartsUWork.JoinSourPartsNoWithH) > 0)
                {
                    status = -1;
                    return status;
                }
            }
            else if (!joinPartsPrintWork.JoinSourPartsNoWithHEd.Trim().Equals(string.Empty))
            {
                if (joinPartsPrintWork.JoinSourPartsNoWithHEd.CompareTo(joinPartsUWork.JoinSourPartsNoWithH) < 0)
                {
                    status = -1;
                    return status;
                }
            }
            return status;
        }
    }
}

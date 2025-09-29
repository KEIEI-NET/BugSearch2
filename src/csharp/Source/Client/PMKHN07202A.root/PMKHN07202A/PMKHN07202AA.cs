//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �s�a�n�����}�X�^�i�G�N�X�|�[�g�j
// �v���O�����T�v   : �s�a�n�����}�X�^�̴���߰ď������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/05/14  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �� �� ��  2009/06/24  �C�����e : PVCS268 �o�̓f�[�^���Ⴂ
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
// ADD 2009/06/24 --->>>
// �o�̓f�[�^���Ⴂ
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
// ADD 2009/06/24 ---<<<

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �s�a�n�����}�X�^�e�[�u���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �s�a�n�����}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2009.05.14</br>
    /// <br></br>
    /// </remarks>
    public class TBOSearchSetExpAcs
    {
        private ITBOSearchUDB _iTBOSearchUDB;


        private static bool _isLocalDBRead = false;

        /// <summary>TBO�����}�X�^�A�N�Z�X�N���X</summary>
        private TBOSearchUAcs _tBOSearchUAcs;

        /// <summary> ���[�J���c�a�Q�ƃ��[�h�v���p�e�B</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
        /// �s�a�n�����}�X�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �s�a�n�����}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public TBOSearchSetExpAcs()
        {
            _tBOSearchUAcs = new TBOSearchUAcs();
            this._iTBOSearchUDB = (ITBOSearchUDB)MediationTBOSearchUDB.GetTBOSearchUDB();
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
        /// �s�a�n�����}�X�^�S���������i�_���폜�����j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="tBOSearchExportWork">���o����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �s�a�n�����}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, TBOSearchExportWork tBOSearchExportWork)
        {
            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, tBOSearchExportWork);
        }

        /// <summary>
        /// �s�a�n�����}�X�^���������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="tBOSearchExportWork">���o����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �s�a�n�����}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, TBOSearchExportWork tBOSearchExportWork)
        {
            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, tBOSearchExportWork);
        }

        /// <summary>
        /// �s�a�n�����}�X�^��������
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="tBOSearchExportWork">���o����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �s�a�n�����}�X�^�����������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, TBOSearchExportWork tBOSearchExportWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int checkstatus = 0;
            nextData = false;
            retTotalCnt = 0;

            // ��������
            retList = new ArrayList();
            retList.Clear();
            // MODIFY 2009/06/24 --->>>
            // �o�̓f�[�^���Ⴂ
            //ArrayList paraList = new ArrayList();
            //paraList.Clear();

            //object retobj = new ArrayList();

            TBOSearchUWork paraWork = new TBOSearchUWork();
            paraWork.EnterpriseCode = enterpriseCode;

            ArrayList tboSearchUWorkList = new ArrayList();
            object paraList = tboSearchUWorkList;
            object paraObj = paraWork;
            status = _iTBOSearchUDB.Search(ref paraList, paraObj, 0, ConstantManagement.LogicalMode.GetData0);

            // ����
            //status = this._tBOSearchUAcs.SearchAll(out paraList, enterpriseCode);
            // MODIFY 2009/06/24 ---<<<

            // ����ꍇ
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                // MODIFY 2009/06/24 --->>>
                // �o�̓f�[�^���Ⴂ
                //foreach (TBOSearchU tBOSearchU in paraList)
                foreach (TBOSearchUWork tBOSearchU in (ArrayList)paraList)
                // MODIFY 2009/06/24 ---<<<
                {
                    // ���o����
                    checkstatus = DataCheck(tBOSearchU, tBOSearchExportWork);
                    if (checkstatus == 0)
                    {
                    //�s�a�n�����}�X�^���N���X�փ����o�R�s�[
                    retList.Add(CopyToTBOSearchSetExpFromtBOSearchU(tBOSearchU, enterpriseCode));
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
        /// �N���X�����o�[�R�s�[�����i�s�a�n�����}�X�^���[�N�N���X�˂s�a�n�����}�X�^�N���X�j
        /// </summary>
        /// <param name="tBOSearchU">�s�a�n�����}�X�^���[�N�N���X</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�s�a�n�����}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �s�a�n�����}�X�^���[�N�N���X����s�a�n�����}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        // MODIFY 2009/06/24 --->>>
        // �o�̓f�[�^���Ⴂ
        //private TBOSearchSetExp CopyToTBOSearchSetExpFromtBOSearchU(TBOSearchU tBOSearchU, string enterpriseCode)
        private TBOSearchSetExp CopyToTBOSearchSetExpFromtBOSearchU(TBOSearchUWork tBOSearchU, string enterpriseCode)
        // MODIFY 2009/06/24 ---<<<
        {
            TBOSearchSetExp tBOSearchSetExp = new TBOSearchSetExp();

            tBOSearchSetExp.EquipGenreCode = tBOSearchU.EquipGenreCode;
            // DELETE 2009/06/24 --->>>
            // �o�̓f�[�^���Ⴂ
            //tBOSearchSetExp.EnterpriseName = tBOSearchU.EnterpriseName;
            // DELETE 2009/06/24 ---<<<
            tBOSearchSetExp.EquipName = tBOSearchU.EquipName;
            tBOSearchSetExp.CarInfoJoinDispOrder = tBOSearchU.CarInfoJoinDispOrder;
            tBOSearchSetExp.JoinDestPartsNo = tBOSearchU.JoinDestPartsNo;
            tBOSearchSetExp.JoinDestMakerCd = tBOSearchU.JoinDestMakerCd;
            tBOSearchSetExp.BLGoodsCode = tBOSearchU.BLGoodsCode;
            tBOSearchSetExp.JoinQty = tBOSearchU.JoinQty;
            tBOSearchSetExp.EquipSpecialNote = tBOSearchU.EquipSpecialNote;

            return tBOSearchSetExp;
        }

        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="tBOSearchU">��������</param>
        /// <param name="tBOSearchExportWork">���o����</param>
        /// <returns></returns>
        // MODIFY 2009/06/24 --->>>
        // �o�̓f�[�^���Ⴂ
        //private int DataCheck(TBOSearchU tBOSearchU, TBOSearchExportWork tBOSearchExportWork)
        private int DataCheck(TBOSearchUWork tBOSearchU, TBOSearchExportWork tBOSearchExportWork)
        // MODIFY 2009/06/24 ---<<<
        {
            int status = 0;

            // �_���폜�敪
            if (tBOSearchU.LogicalDeleteCode != 0)
            {
                status = -1;
                return status;
            }

            // �����惁�[�J�[�R�[�h
            if (tBOSearchExportWork.JoinDestMakerCdSt != 0 &&
                tBOSearchExportWork.JoinDestMakerCdEd != 0)
            {
                if (tBOSearchU.JoinDestMakerCd < tBOSearchExportWork.JoinDestMakerCdSt ||
                   tBOSearchU.JoinDestMakerCd > tBOSearchExportWork.JoinDestMakerCdEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (tBOSearchExportWork.JoinDestMakerCdSt != 0)
            {
                if (tBOSearchU.JoinDestMakerCd < tBOSearchExportWork.JoinDestMakerCdSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (tBOSearchExportWork.JoinDestMakerCdEd != 0)
            {
                if (tBOSearchU.JoinDestMakerCd > tBOSearchExportWork.JoinDestMakerCdEd)
                {
                    status = -1;
                    return status;
                }
            }

            // ��������
            if (tBOSearchExportWork.EquipGenreCodeCd != 0)
            {
                if (tBOSearchU.EquipGenreCode != tBOSearchExportWork.EquipGenreCodeCd)
                {
                    status = -1;
                    return status;
                }
            }

            return status;
        }
    }
}

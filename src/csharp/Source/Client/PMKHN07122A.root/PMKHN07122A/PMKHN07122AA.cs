//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �a�k�R�[�h�}�X�^�i�G�N�X�|�[�g�j
// �v���O�����T�v   : �a�k�R�[�h�}�X�^�̴���߰ď������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/05/12  �C�����e : �V�K�쐬
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

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// BL�R�[�h�}�X�^�e�[�u���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : BL�R�[�h�}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2009.05.12</br>
    /// <br></br>
    /// </remarks>
    public class BLGoodsCdSetExpAcs
    {

        private static bool _isLocalDBRead = false;

        private BLGoodsCdAcs _bLGoodsCdAcs;

        private Dictionary<int, BLGroupU> _blGroupUDic;
        private BLGroupUAcs _bLGroupUAcs;

        private Dictionary<int, GoodsGroupU> _goodsGroupUDic;
        private GoodsGroupUAcs _goodsGroupUAcs;

        // ��������
        private const int EQUIPGANRE_CODE_0 = 0;
        private const int EQUIPGANRE_CODE_1001 = 1001;
        private const int EQUIPGANRE_CODE_1005 = 1005;
        private const int EQUIPGANRE_CODE_1010 = 1010;
        private const string EQUIPGANRE_NAME_0 = "����";
        private const string EQUIPGANRE_NAME_1001 = "�o�b�e���[";
        private const string EQUIPGANRE_NAME_1005 = "�^�C��";
        private const string EQUIPGANRE_NAME_1010 = "�I�C��";

        /// <summary> ���[�J���c�a�Q�ƃ��[�h�v���p�e�B</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
        /// BL�R�[�h�}�X�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public BLGoodsCdSetExpAcs()
        {
            this._bLGroupUAcs = new BLGroupUAcs();
            this._goodsGroupUAcs = new GoodsGroupUAcs();
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
        /// BL�R�[�h�}�X�^�S���������i�_���폜�����j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <param name="bLGoodsCdExportWork">���o����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, BLGoodsCdExportWork bLGoodsCdExportWork)
        {
            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, bLGoodsCdExportWork);
        }

        /// <summary>
        /// BL�R�[�h�}�X�^���������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>	
        /// <param name="bLGoodsCdExportWork">���o����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, BLGoodsCdExportWork bLGoodsCdExportWork)
        {

            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, bLGoodsCdExportWork);
        }

        /// <summary>
        /// BL�R�[�h�}�X�^��������
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="bLGoodsCdExportWork">���o����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�}�X�^�̌����������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, BLGoodsCdExportWork bLGoodsCdExportWork)
        {

            this._bLGoodsCdAcs = new BLGoodsCdAcs();

            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int checkstatus = 0;

            //���f�[�^�L��������
            nextData = false;
            //0�ŏ�����
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList bLGoodsCdUMnts = null;

            status = this._bLGoodsCdAcs.SearchAll(
                                out bLGoodsCdUMnts,
                                enterpriseCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                foreach (BLGoodsCdUMnt bLGoodsCdUMnt in bLGoodsCdUMnts)
                {
                    // ���o����
                    checkstatus = DataFiler(bLGoodsCdUMnt, bLGoodsCdExportWork);
                    if (checkstatus == 0)
                    {

                        //BL�R�[�h���N���X�փ����o�R�s�[
                        retList.Add(CopyToBLGoodsCdSetFromSecInfoSetWork(bLGoodsCdUMnt, enterpriseCode));

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
        /// �N���X�����o�[�R�s�[�����iBL�R�[�h�}�X�^���[�N�N���X��BL�R�[�h�}�X�^�N���X�j
        /// </summary>
        /// <param name="bLGoodsCdUMnt">BL�R�[�h�}�X�^���[�N�N���X</param>
        /// <param name="enterpriseCode"></param>
        /// <returns>BL�R�[�h�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�}�X�^���[�N�N���X����BL�R�[�h�}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private BLGoodsCdSetExp CopyToBLGoodsCdSetFromSecInfoSetWork(BLGoodsCdUMnt bLGoodsCdUMnt, string enterpriseCode)
        {

            BLGoodsCdSetExp bLGoodsCdSet = new BLGoodsCdSetExp();

            bLGoodsCdSet.BLGoodsCode = bLGoodsCdUMnt.BLGoodsCode;
            bLGoodsCdSet.BLGoodsFullName = bLGoodsCdUMnt.BLGoodsFullName;
            bLGoodsCdSet.BLGoodsHalfName = bLGoodsCdUMnt.BLGoodsHalfName;
            bLGoodsCdSet.BLGroupCode = bLGoodsCdUMnt.BLGloupCode;
            bLGoodsCdSet.BLGroupKanaName = GetBLGroupName(bLGoodsCdUMnt.BLGloupCode, enterpriseCode);
            bLGoodsCdSet.GoodsRateGrpCode = bLGoodsCdUMnt.GoodsRateGrpCode;
            bLGoodsCdSet.GoodsRateGrpCodeName = GetGoodsRateGrpName(bLGoodsCdUMnt.GoodsRateGrpCode, enterpriseCode);
            bLGoodsCdSet.BLGoodsGenreCode = bLGoodsCdUMnt.BLGoodsGenreCode;
            bLGoodsCdSet.BLGoodsGenreCodeName = GetEquipGenreName(bLGoodsCdUMnt.BLGoodsGenreCode);

            return bLGoodsCdSet;
        }

        /// <summary>
        /// BL�O���[�v���̎擾����
        /// </summary>
        /// <param name="blGroupCode">BL�O���[�v�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <remarks>
        /// <br>Note       : BL�O���[�v���̂��擾���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string GetBLGroupName(int blGroupCode, string enterpriseCode)
        {
            string blGroupName = "";

            ReadBLGroup(enterpriseCode);
            if (this._blGroupUDic.ContainsKey(blGroupCode))
            {
                blGroupName = this._blGroupUDic[blGroupCode].BLGroupName.Trim();
            }

            return blGroupName;
        }

        /// <summary>
        /// BL�O���[�v�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : BL�O���[�v�ꗗ��ǂݍ��݂܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private void ReadBLGroup(string enterpriseCode)
        {
            try
            {
                if (this._blGroupUDic.Count == 0)
                {
                    this._blGroupUDic = new Dictionary<int, BLGroupU>();

                    ArrayList retList;

                    int status = this._bLGroupUAcs.SearchAll(out retList, enterpriseCode);
                    if (status == 0)
                    {
                        foreach (BLGroupU bLGroupU in retList)
                        {
                            if (bLGroupU.LogicalDeleteCode == 0)
                            {
                                this._blGroupUDic.Add(bLGroupU.BLGroupCode, bLGroupU);
                            }
                        }
                    }
                }
            }
            catch
            {
                this._blGroupUDic = new Dictionary<int, BLGroupU>();

                ArrayList retList;

                int status = this._bLGroupUAcs.SearchAll(out retList, enterpriseCode);
                if (status == 0)
                {
                    foreach (BLGroupU bLGroupU in retList)
                    {
                        if (bLGroupU.LogicalDeleteCode == 0)
                        {
                            this._blGroupUDic.Add(bLGroupU.BLGroupCode, bLGroupU);
                        }
                    }
                }
            }
            return;
        }

        /// <summary>
        /// ���i�|���O���[�v���̎擾����
        /// </summary>
        /// <param name="goodsGroupUCode">���i�|���O���[�v�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <remarks>
        /// <returns>���i�|���O���[�v����</returns>
        /// <br>Note       : ���i�|���O���[�v���̂��擾���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string GetGoodsRateGrpName(int goodsGroupUCode, string enterpriseCode)
        {
            string goodsGroupUName = "";

            ReadGoodsRateGrp(enterpriseCode);
            if (this._goodsGroupUDic.ContainsKey(goodsGroupUCode))
            {
                goodsGroupUName = this._goodsGroupUDic[goodsGroupUCode].GoodsMGroupName.Trim();
            }

            return goodsGroupUName;
        }

        /// <summary>
        /// ���i�|���O���[�v�Ǎ�����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <remarks>
        /// <br>Note       : ���i�|���O���[�v�ꗗ��ǂݍ��݂܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private void ReadGoodsRateGrp(string enterpriseCode)
        {
            try
            {
                if (this._goodsGroupUDic.Count == 0)
                {
                    this._goodsGroupUDic = new Dictionary<int, GoodsGroupU>();

                    ArrayList retList;

                    int status = this._goodsGroupUAcs.SearchAll(out retList, enterpriseCode);
                    if (status == 0)
                    {
                        foreach (GoodsGroupU goodsGroupU in retList)
                        {
                            if (goodsGroupU.LogicalDeleteCode == 0)
                            {
                                this._goodsGroupUDic.Add(goodsGroupU.GoodsMGroup, goodsGroupU);
                            }
                        }
                    }
                }
            }
            catch
            {
                this._goodsGroupUDic = new Dictionary<int, GoodsGroupU>();

                ArrayList retList;

                int status = this._goodsGroupUAcs.SearchAll(out retList, enterpriseCode);
                if (status == 0)
                {
                    foreach (GoodsGroupU goodsGroupU in retList)
                    {
                        if (goodsGroupU.LogicalDeleteCode == 0)
                        {
                            this._goodsGroupUDic.Add(goodsGroupU.GoodsMGroup, goodsGroupU);
                        }
                    }
                }
            }
            return;
        }

        /// <summary>
        /// �������ޖ��̎擾����
        /// </summary>
        /// <param name="equipGenreCode">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �������ޖ��̂��擾���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string GetEquipGenreName(int equipGenreCode)
        {
            string EquipGenreName = "";

            switch (equipGenreCode)
            {
                case EQUIPGANRE_CODE_0:
                    EquipGenreName = EQUIPGANRE_NAME_0;
                    break;
                case EQUIPGANRE_CODE_1001:
                    EquipGenreName = EQUIPGANRE_NAME_1001;
                    break;
                case EQUIPGANRE_CODE_1005:
                    EquipGenreName = EQUIPGANRE_NAME_1005;
                    break;
                case EQUIPGANRE_CODE_1010:
                    EquipGenreName = EQUIPGANRE_NAME_1010;
                    break;
                default:
                    break;
            }

            return EquipGenreName;
        }

        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="bLGoodsCdUMnt"></param>
        /// <param name="bLGoodsCdExportWork"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���o�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private int DataFiler(BLGoodsCdUMnt bLGoodsCdUMnt, BLGoodsCdExportWork bLGoodsCdExportWork)
        {
            int status = 0;

            // �_���폜�敪
            if (bLGoodsCdUMnt.LogicalDeleteCode != 0)
            {
                status = -1;
                return status;
            }

            // �a�k�R�[�h�R�[�h
            if (bLGoodsCdExportWork.BLGoodsCodeSt != 0 &&
                bLGoodsCdExportWork.BLGoodsCodeEd != 0)
            {
                if (bLGoodsCdUMnt.BLGoodsCode < bLGoodsCdExportWork.BLGoodsCodeSt ||
                   bLGoodsCdUMnt.BLGoodsCode > bLGoodsCdExportWork.BLGoodsCodeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (bLGoodsCdExportWork.BLGoodsCodeSt != 0)
            {
                if (bLGoodsCdUMnt.BLGoodsCode < bLGoodsCdExportWork.BLGoodsCodeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (bLGoodsCdExportWork.BLGoodsCodeEd != 0)
            {
                if (bLGoodsCdUMnt.BLGoodsCode > bLGoodsCdExportWork.BLGoodsCodeEd)
                {
                    status = -1;
                    return status;
                }
            }

            // �񋟃f�[�^�敪

            return status;
        }
    }
}

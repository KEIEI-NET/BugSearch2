//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : AB���i�R�[�hޕϊ��}�X�^�A�N�Z�X�N���X
// �v���O�����T�v   : AB���i�R�[�hޕϊ��}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/08/05  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// AB���i�R�[�hޕϊ��}�X�^�e�[�u���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : AB���i�R�[�hޕϊ��}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2009.08.04</br>
    /// <br></br>
    /// </remarks>
    public class ABGoodsCdChgAcs
    {
        private BLGoodsCodeSetAcs _bLGoodsCodeSetAcs;
        /// <summary>
        /// AB���i�R�[�hރe�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : AB���i�R�[�hރ}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.08.04</br>
        /// </remarks>
        public ABGoodsCdChgAcs()
        {

        }

        /// <summary>
        /// AB���i�R�[�h���������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>	
        /// <param name="aBGoodsCdChgPrint">AB���i�R�[�hޕϊ��}�X�^�i����j�����N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : AB���i�R�[�h�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.08.04</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, ABGoodsCdChgPrint aBGoodsCdChgPrint)
        {
            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, aBGoodsCdChgPrint);
        }

        /// <summary>
        /// AB���i�R�[�h��������
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="aBGoodsCdChgPrint">���o����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : AB���i�R�[�h�̌����������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.08.04</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, ABGoodsCdChgPrint aBGoodsCdChgPrint)
        {
            this._bLGoodsCodeSetAcs = new BLGoodsCodeSetAcs();

            int status = 0;
            int checkstatus = 0;

            //���f�[�^�L��������
            nextData = false;
            //0�ŏ�����
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList resultList = null;

            status = this._bLGoodsCodeSetAcs.SearchAll(
                                out resultList,
                                enterpriseCode);

            foreach (SAndEGoodsCdChg sAndEGoodsCdChg in resultList)
            {
                // ���o����
                checkstatus = DataCheck(sAndEGoodsCdChg, aBGoodsCdChgPrint);
                if (checkstatus == 0)
                {
                    //AB���i�R�[�hޕϊ��}�X�^���N���X�փ����o�R�s�[
                    retList.Add(CopyToABGoodsCdChgSetFromSAndEGoodsCdChg(sAndEGoodsCdChg, enterpriseCode));
                }
            }

            //�S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
            if (readCnt == 0) retTotalCnt = retList.Count;

            return status;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[����
        /// </summary>
        /// <param name="sAndEGoodsCdChg">���i�R�[�h�ϊ��N���X</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>AB���i�R�[�hޕϊ��}�X�^�i����j�����N���X</returns>
        /// <remarks>
        /// <br>Note       : �R�s�[���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.08.04</br>
        /// </remarks>
        private ABGoodsCdChgSet CopyToABGoodsCdChgSetFromSAndEGoodsCdChg(SAndEGoodsCdChg sAndEGoodsCdChg, string enterpriseCode)
        {
            ABGoodsCdChgSet aBGoodsCdChgSet = new ABGoodsCdChgSet();
            aBGoodsCdChgSet.BLGoodsCode = sAndEGoodsCdChg.BLGoodsCode;
            aBGoodsCdChgSet.BLGoodsHalfName = sAndEGoodsCdChg.BLGoodsHalfName;
            aBGoodsCdChgSet.ABGoodsCode = sAndEGoodsCdChg.ABGoodsCode;

            return aBGoodsCdChgSet;
        }

        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="sAndEGoodsCdChg"></param>
        /// <param name="aBGoodsCdChgPrint"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���o�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.08.06</br>
        /// </remarks>
        private int DataCheck(SAndEGoodsCdChg sAndEGoodsCdChg, ABGoodsCdChgPrint aBGoodsCdChgPrint)
        {
            int status = 0;

            // �폜�w��
            if (sAndEGoodsCdChg.LogicalDeleteCode != aBGoodsCdChgPrint.LogicalDeleteCode)
            {
                status = -1;
                return status;
            }

            // �X�V����
            string upDateTime = sAndEGoodsCdChg.UpdateDateTime.Year.ToString("0000") +
                    sAndEGoodsCdChg.UpdateDateTime.Month.ToString("00") +
                    sAndEGoodsCdChg.UpdateDateTime.Day.ToString("00");

            if (aBGoodsCdChgPrint.LogicalDeleteCode == 1 &&
                aBGoodsCdChgPrint.DeleteDateTimeSt != 0 &&
                aBGoodsCdChgPrint.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < aBGoodsCdChgPrint.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > aBGoodsCdChgPrint.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (aBGoodsCdChgPrint.LogicalDeleteCode == 1 &&
                        aBGoodsCdChgPrint.DeleteDateTimeSt != 0 &&
                        aBGoodsCdChgPrint.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < aBGoodsCdChgPrint.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (aBGoodsCdChgPrint.LogicalDeleteCode == 1 &&
                    aBGoodsCdChgPrint.DeleteDateTimeSt == 0 &&
                    aBGoodsCdChgPrint.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > aBGoodsCdChgPrint.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }

            // BL�R�[�h
            if (aBGoodsCdChgPrint.BLGoodsCodeSt != 0 &&
                aBGoodsCdChgPrint.BLGoodsCodeEd != 0)
            {
                if (sAndEGoodsCdChg.BLGoodsCode < aBGoodsCdChgPrint.BLGoodsCodeSt ||
                   sAndEGoodsCdChg.BLGoodsCode > aBGoodsCdChgPrint.BLGoodsCodeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (aBGoodsCdChgPrint.BLGoodsCodeSt != 0)
            {
                if (sAndEGoodsCdChg.BLGoodsCode < aBGoodsCdChgPrint.BLGoodsCodeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (aBGoodsCdChgPrint.BLGoodsCodeEd != 0)
            {
                if (sAndEGoodsCdChg.BLGoodsCode > aBGoodsCdChgPrint.BLGoodsCodeEd)
                {
                    status = -1;
                    return status;
                }
            }

            return status;
        }
    }
}
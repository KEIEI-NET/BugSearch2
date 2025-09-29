//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����}�X�^�i�C���|�[�g�j
// �v���O�����T�v   : �����}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2009/05/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using System.Text.RegularExpressions;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �����}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����}�X�^�i�C���|�[�g�j�Ŏg�p����f�[�^���擾����B</br>
    /// <br>Programmer : ���M</br>
    /// <br>Date       : 2009.05.13</br>
    /// <br></br>
    /// </remarks>
    public class JoinImportAcs
    {
        #region �� Constructor
        /// <summary>
        /// �����}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        public JoinImportAcs()
        {
            this._iJoinImportDB = (IJoinImportDB)MediationJoinImportDB.GetJoinImportDB();
        }

        /// <summary>
        /// �����}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        static JoinImportAcs()
        {

        }
        #endregion �� Constructor

        #region �� Static Member

        #endregion �� Static Member

        #region �� Private Member
        // �����}�X�^�i�C���|�[�g�j�̃����[�g�C���^�t�F�[�X
        private IJoinImportDB _iJoinImportDB;
        #endregion �� Private Member

        #region �� Const Member

        #endregion �� Const Member

        #region �� Public Method
        #region �� �C���|�[�g����
        /// <summary>
        /// �C���|�[�g����
        /// </summary>
        /// <param name="importWorkTbl">�C���|�[�g���[�N</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="addCnt">�ǉ�����</param>
        /// <param name="updCnt">��������</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �����}�X�^�i�C���|�[�g�j�������s���B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        public int Import(ExtrInfo_JoinImportWorkTbl importWorkTbl, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg)
        {
            return this.ImportProc(importWorkTbl, out readCnt, out addCnt, out updCnt, out errMsg);
        }
        #endregion
        #endregion �� Public Method

        #region �� Private Method
        #region �� �����}�X�^�i�C���|�[�g�j�̃C���|�[�g����
        /// <summary>
        /// �C���|�[�g����
        /// </summary>
        /// <param name="importWorkTbl">�C���|�[�g���[�N</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="addCnt">�ǉ�����</param>
        /// <param name="updCnt">��������</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �����}�X�^�i�C���|�[�g�j�������s���B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private int ImportProc(ExtrInfo_JoinImportWorkTbl importWorkTbl, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            readCnt = 0;
            addCnt = 0;
            updCnt = 0;
            errMsg = string.Empty;

            try
            {
                ArrayList importWorkList = null;
                // �C���|�[�g���[�N�̕ϊ�����
                status = ConvertToImportWorkList(importWorkTbl, out importWorkList, out errMsg);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL && importWorkList != null && importWorkList.Count != 0)
                {
                    Object objImportWorkList = (object)importWorkList;
                    // �����[�g�N���X���Ăяo���B
                    status = this._iJoinImportDB.Import(importWorkTbl.ProcessKbn, ref objImportWorkList, out readCnt, out addCnt, out updCnt, out errMsg);
                }
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ERROR:
                        status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion

        #region �� �f�[�^�ϊ�����
        #region �� �C���|�[�g���[�N�̕ϊ�����
        /// <summary>
        /// �C���|�[�g���[�N�̕ϊ�����
        /// </summary>
        /// <param name="importWorkTbl">UI���o�����N���X</param>
        /// <param name="importWorkList">�����[�g�p�̃C���|�[�g���[�N���X�g</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �C���|�[�g���[�N�̕ϊ��������s���B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private int ConvertToImportWorkList(ExtrInfo_JoinImportWorkTbl importWorkTbl, out ArrayList importWorkList, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            errMsg = string.Empty;
            importWorkList = new ArrayList();
            JoinPartsUWork work = null;

            try
            {
                List<string[]> csvDataInfoList = importWorkTbl.CsvDataInfoList;
                foreach (string[] csvDataArr in csvDataInfoList)
                {
                    work = new JoinPartsUWork();
                    int index = 0;
                    //�������i��(�|�t���i��)
                    work.EnterpriseCode = importWorkTbl.EnterpriseCode;

                    //�������i��(�|�t���i��)
                    work.JoinSourPartsNoWithH = ConvertToEmpty(csvDataArr, index++);

                    //���������[�J�[�R�[�h
                    work.JoinSourceMakerCode = ConvertToInt32(csvDataArr, index++);

                    //�������i��(�|�����i��)
                    work.JoinSourPartsNoNoneH = ConvertToEmpty(csvDataArr, index++);

                    //�����\������
                    work.JoinDispOrder = ConvertToInt32(csvDataArr, index++);

                    //������i��(�|�t���i��)
                    work.JoinDestPartsNo = ConvertToEmpty(csvDataArr, index++);

                    //�����惁�[�J�[�R�[�h
                    work.JoinDestMakerCd = ConvertToInt32(csvDataArr, index++);

                    //����QTY
                    work.JoinQty = ConvertToDouble(csvDataArr, index++);

                    //�����K�i�E���L����
                    work.JoinSpecialNote = ConvertToEmpty(csvDataArr, index++);

                    importWorkList.Add(work);
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }
        #endregion

        #region �� ���l���ڂ֕ϊ�����
        /// <summary>
        /// ���l���ڂ֕ϊ�����
        /// </summary>
        /// <param name="csvDataArr">CSV���ڔz��</param>
        /// <param name="index">�C���f�b�N�X</param>
        /// <returns>�ύX�������l</returns>
        /// <remarks>
        /// <br>Note       : ���ڐ�������Ȃ��ꍇ�̓[���֕ϊ������������s���B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.05.22</br>
        /// </remarks>
        private Int32 ConvertToInt32(string[] csvDataArr, Int32 index)
        {
            Int32 retNum = 0;

            if (index < csvDataArr.Length)
            {
                try
                {
                    retNum = Convert.ToInt32(csvDataArr[index]);
                }
                catch
                {
                    retNum = 0;
                }
            }
            return retNum;
        }

        /// <summary>
        /// ���l���ڂ֕ϊ�����
        /// </summary>
        /// <param name="csvDataArr">CSV���ڔz��</param>
        /// <param name="index">�C���f�b�N�X</param>
        /// <returns>�ύX�������l</returns>
        /// <remarks>
        /// <br>Note       : ���ڐ�������Ȃ��ꍇ�̓[���֕ϊ������������s���B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.22</br>
        /// </remarks>
        private double ConvertToDouble(string[] csvDataArr, Int32 index)
        {
            double reDouble = 0;

            if (index < csvDataArr.Length)
            {
                try
                {
                    reDouble = Convert.ToDouble(csvDataArr[index]);
                }
                catch
                {
                    reDouble = 0;
                }
            }

            return reDouble;
        }

        /// <summary>
        /// �󔒍��ڂ֕ϊ�����
        /// </summary>
        /// <param name="csvDataArr">CSV���ڔz��</param>
        /// <param name="index">�C���f�b�N�X</param>
        /// <returns>�ύX��������</returns>
        /// <remarks>
        /// <br>Note       : ���ڐ�������Ȃ��ꍇ�͋󔒍��ڂ֕ϊ������������s���B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.05.22</br>
        /// </remarks>
        private string ConvertToEmpty(string[] csvDataArr, Int32 index)
        {
            string retContent = string.Empty;

            if (index < csvDataArr.Length)
            {
                retContent = csvDataArr[index];
            }

            return retContent;
        }
        #endregion
        #endregion

        #endregion �� Private Method
    }
}

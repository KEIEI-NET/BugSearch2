//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : TBO�����}�X�^�i�C���|�[�g�j
// �v���O�����T�v   : TBO�����}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
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
using System.Text.RegularExpressions;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// TBO�����}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : TBO�����}�X�^�i�C���|�[�g�j�Ŏg�p����f�[�^���擾����B</br>
    /// <br>Programmer : ���w�q</br>
    /// <br>Date       : 2009.05.13</br>
    /// <br></br>
    /// </remarks>
    public class TBOSearchUImportAcs
    {
        #region �� Constructor
		/// <summary>
        /// TBO�����}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : TBO�����}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X�̏��������s���B</br>
	    /// <br>Programmer : ���w�q</br>
	    /// <br>Date       : 2009.05.13</br>
		/// </remarks>
		public TBOSearchUImportAcs()
		{
            this._iTBOSearchUImportDB = (ITBOSearchUImportDB)MediationTBOSearchUImportDB.GetTBOSearchUImportDB();
        }

		/// <summary>
        /// TBO�����}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : TBO�����}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        static TBOSearchUImportAcs()
		{
		}
		#endregion �� Constructor

        #region �� Private Member
        // TBO�����}�X�^�i�C���|�[�g�j�̃����[�g�C���^�t�F�[�X
        private ITBOSearchUImportDB _iTBOSearchUImportDB;
        #endregion �� Private Member

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
        /// <br>Note       : TBO�����}�X�^�i�C���|�[�g�j�������s���B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        public int Import(ExtrInfo_TBOSearchUImportWorkTbl importWorkTbl, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg)
        {
            return this.ImportProc(importWorkTbl, out readCnt, out addCnt, out updCnt, out errMsg);
        }
        #endregion
        #endregion �� Public Method

        #region �� Private Method
        #region �� TBO�����}�X�^�i�C���|�[�g�j�̃C���|�[�g����
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
        /// <br>Note       : TBO�����}�X�^�i�C���|�[�g�j�������s���B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private int ImportProc(ExtrInfo_TBOSearchUImportWorkTbl importWorkTbl, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg)
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
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    Object objImportWorkList = (object)importWorkList;
                    // �����[�g�N���X���Ăяo���B
                    status = this._iTBOSearchUImportDB.Import(importWorkTbl.ProcessKbn, ref objImportWorkList, out readCnt, out addCnt, out updCnt, out errMsg);
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
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private int ConvertToImportWorkList(ExtrInfo_TBOSearchUImportWorkTbl importWorkTbl, out ArrayList importWorkList, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            errMsg = string.Empty;
            importWorkList = new ArrayList();
            TBOSearchUWork work = null;

            try
            {
                List<string[]> csvDataInfoList = importWorkTbl.CsvDataInfoList;
                foreach (string[] csvDataArr in csvDataInfoList)
                {
                    work = new TBOSearchUWork();
                    int index = 0;
                    work.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;          // ��ƃR�[�h
                    work.EquipGenreCode = ConvertToInt32(csvDataArr, index++);          // ��������
                    work.EquipName = ConvertToEmpty(csvDataArr, index++);               // ������
                    work.CarInfoJoinDispOrder = ConvertToInt32(csvDataArr, index++);    // �\����
                    work.JoinDestPartsNo = ConvertToEmpty(csvDataArr, index++);         // �i��
                    work.JoinDestMakerCd = ConvertToInt32(csvDataArr, index++);         // ���[�J�[
                    work.BLGoodsCode = ConvertToInt32(csvDataArr, index++);             // �a�k�R�[�h
                    work.JoinQty = ConvertToDouble(csvDataArr, index++);                // �p�s�x
                    work.EquipSpecialNote = ConvertToEmpty(csvDataArr, index++);        // �����K�i�E���L����

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
        /// <br>Programmer : ���w�q</br>
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
        #endregion

        #region �� �󔒍��ڂ֕ϊ�����
        /// <summary>
        /// �󔒍��ڂ֕ϊ�����
        /// </summary>
        /// <param name="csvDataArr">CSV���ڔz��</param>
        /// <param name="index">�C���f�b�N�X</param>
        /// <returns>�ύX��������</returns>
        /// <remarks>
        /// <br>Note       : ���ڐ�������Ȃ��ꍇ�͋󔒍��ڂ֕ϊ������������s���B</br>
        /// <br>Programmer : ���w�q</br>
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

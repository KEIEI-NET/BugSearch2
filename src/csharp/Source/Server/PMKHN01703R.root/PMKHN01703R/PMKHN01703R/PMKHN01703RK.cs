//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����Y�ƗD�ǐݒ�}�X�^�ϊ�����
// �v���O�����T�v   : �����𖞂������f�[�^��ϊ�����
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00  �쐬�S�� : �i�N
// �� �� ��  2015/02/27   �C�����e : Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00  �쐬�S�� : ���V��
// �� �� ��  2015/03/16   �C�����e : Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00  �쐬�S�� : ���V��
// �� �� ��  2015/04/17   �C�����e : Redmine#45436 ���i�Ԏ�ʂƐV�i�Ԏ�ʂ�����̏ꍇ�̃G���[���e�����Ғl�ƂȂ��Ă��Ȃ��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : ���V��
// �� �� ��  2015/04/17  �C�����e : Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : ���V��
// �� �� ��  2015/04/27  �C�����e : ���r���[���ʑΉ�(status�ɂ�蔻�f�����̒ǉ�) 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : ���V��
// �� �� ��  2015/04/29  �C�����e : ���X�g��NULL�A��count�͔��f����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : ���V��
// �� �� ��  2015/05/14  �C�����e : ���[�J�[�R�[�h�A���i�����ރR�[�h�A�a�k�R�[�h���݃`�F�b�N�̍폜
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Collections.Generic;

using Broadleaf.Library.Data;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using System.Text.RegularExpressions;
using Broadleaf.Library.Data.SqlTypes;
using Microsoft.Win32;
using System.IO;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �����Y�ƗD�ǐݒ�}�X�^�ϊ�����DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note        : �D�ǐݒ�}�X�^�ϊ������̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer  : �i�N</br>
    /// <br>Date        : 2015/02/27</br>
    /// </remarks>
    [Serializable]
    public class MeijiPrmSettingDB : RemoteDB
    {
        private GoodsNoChgCommonDB _iGoodsNoChgCommonDB;
        private PrmSettingUDB _iprmSettingUDB;// ADD 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�

        #region MeijiPrmSettingDB()
        /// <summary>
        /// �D�ǐݒ�}�X�^�ϊ������R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���ɂȂ�</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/02/27</br>
        /// </remarks>
        public MeijiPrmSettingDB()
        {
            // �i�ԕϊ���������
            if (this._iGoodsNoChgCommonDB == null)
            {
                this._iGoodsNoChgCommonDB = new GoodsNoChgCommonDB();
            }
            //----- ADD 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�------>>>>>
            // �D�ǐݒ�}�X�^���������[�g
            if (this._iprmSettingUDB == null)
            {
                this._iprmSettingUDB = new PrmSettingUDB();
            }
            //----- ADD 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�------<<<<<
        }
        #endregion

        #region �D�ǐݒ�}�X�^�̕ϊ�����
        /// <summary>
        /// �D�ǐݒ�}�X�^�̕ϊ�����
        /// </summary>
        /// <param name="goodsChangeAllCndWorkWork">��������</param>
        /// <param name="offerPrmDic">�񋟕��f�[�^</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="loginCnt">�X�V����</param>
        /// <param name="sucObjectList">�o�^�����f�[�^</param>
        /// <param name="errObjectList">�G���[�f�[�^</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <param name="csvErr">CSV�G���[�t���O</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �D�ǐݒ�}�X�^�̕ϊ��������s��</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/02/27</br>
        /// <br>Note       : Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�</br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : 2015/03/16</br>
        /// </remarks>
        //public int PrmSettingChange(object goodsChangeAllCndWorkWork, out object sucObjectList, out object errObjectList, out int readCnt, out int loginCnt, out string errMsg, out bool csvErr)// DEL 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�
        public int PrmSettingChange(object goodsChangeAllCndWorkWork, Dictionary<string, PrmSettingWork> offerPrmDic, out object sucObjectList, out object errObjectList, // ADD 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�
            out int readCnt, out int loginCnt, out string errMsg, out bool csvErr)// ADD 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�    
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string err = string.Empty;
            string workDir = string.Empty;
            sucObjectList = null;
            errObjectList = null;
            readCnt = 0;
            loginCnt = 0;
            errMsg = string.Empty;
            csvErr = false;

            // �t�@�C�����X�g
            List<string[]> csvDataList = new List<string[]>();
            GoodsChangeAllCndWorkWork cndWork = null;

            cndWork = goodsChangeAllCndWorkWork as GoodsChangeAllCndWorkWork;

            // �t�@�C�����擾
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");
            if (key == null) // �����Ă͂����Ȃ��P�[�X
            {
                workDir = @"C:\Program Files\Partsman\USER_AP"; // ���W�X�g���ɏ�񂪂Ȃ����߁A���Ƀf�t�H���g�̃t�H���_��ݒ�
            }
            else
            {
                workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
            }
            string fileName = Path.Combine(@workDir, "Log\\Trance_csv\\Cross_Index_PrmSet.csv");

            // �t�@�C���`�F�b�N����
            if (!_iGoodsNoChgCommonDB.CheckInputFile(fileName, out err, 1))
            {
                errMsg = err;
                return status;
            }
            bool isReadErr = false;
            // ���R�[�h���݃`�F�b�N����
            if (!_iGoodsNoChgCommonDB.CheckInputFileDataExists(fileName, out err, out csvDataList, out isReadErr))
            {
                if (isReadErr)
                {
                    // �Ǎ��G���[
                    errMsg = err;
                }
                else
                {
                    if (csvDataList.Count == 0)
                    {
                        // ���R�[�h���Ȃ�
                        errMsg = "�Y������f�[�^������܂���B";
                    }
                }
                return status;
            }

            List<string[]> csvDataInfoList = (List<string[]>)csvDataList;

            ArrayList prmChangeWorkList = null;

            // CSV���R�[�h���X�g�̍쐬
            status = ConvertToprmChangeWorkList(cndWork, csvDataInfoList, out prmChangeWorkList, out errMsg);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                // ���[�J�[�ŊY�����R�[�h���Ȃ��ꍇ
                if (prmChangeWorkList != null && prmChangeWorkList.Count == 0)
                {
                    return status;
                }

                // �D�ǐݒ�}�X�^�̕ϊ�����
                //status = this.PrmChange(cndWork, ref prmChangeWorkList, out readCnt, out loginCnt, out sucObjectList, out errObjectList, out errMsg, out csvErr);// DEL 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�
                status = this.PrmChange(cndWork, offerPrmDic, ref prmChangeWorkList, out readCnt, out loginCnt, out sucObjectList, out errObjectList, out errMsg, out csvErr);// ADD 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�
            }

            return status;
        }


        /// <summary>
        /// �D�ǐݒ�}�X�^�̕ϊ�����
        /// </summary>
        /// <param name="cndWork">�������[�N</param>
        /// <param name="offerPrmDic">�񋟕��f�[�^</param>
        /// <param name="prmChangeWorkList">�D�ǐݒ�}�X�^�̕ϊ��f�[�^���X�g</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="loginCnt">�X�V����</param>
        /// <param name="errObjectList">�G���[�e�[�u���p</param>
        /// <param name="sucObjectList">�o�^�����f�[�^</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <param name="csvErr"></param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �D�ǐݒ�}�X�^�̕ϊ��������s��</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/02/27</br>
        /// <br>Note       : Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�</br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : 2015/03/16</br>
        /// <br>Note       : ���[�J�[�R�[�h�A���i�����ރR�[�h�A�a�k�R�[�h�`�F�b�N�̍폜</br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : 2015/05/14</br>
        /// </remarks>
        //private int PrmChange(GoodsChangeAllCndWorkWork cndWork, ref ArrayList prmChangeWorkList, out int readCnt, out int loginCnt, out object sucObjectList, out object errObjectList, out string errMsg, out bool csvErr)// DEL 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�
        private int PrmChange(GoodsChangeAllCndWorkWork cndWork, Dictionary<string, PrmSettingWork> offerPrmDic, ref ArrayList prmChangeWorkList, // ADD 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�
            out int readCnt, out int loginCnt, out object sucObjectList, out object errObjectList, out string errMsg, out bool csvErr)// ADD 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            readCnt = 0;
            loginCnt = 0;
            sucObjectList = null;
            errObjectList = null;
            errMsg = string.Empty;
            csvErr = false;

            // �ϊ��Ώۃ��X�g
            ArrayList dataTagList = new ArrayList();
            // �o�^���X�g
            ArrayList dataSucList = new ArrayList();
            // �G���[���X�g
            ArrayList dataErrList = new ArrayList();
            // �b�r�u���R�[�h�`�F�b�N
            //status = PrmChangeListCheck(cndWork, prmChangeWorkList, out dataTagList, ref dataErrList);// DEL 2015/05/14 ���V�� ���[�J�[�R�[�h�A���i�����ރR�[�h�A�a�k�R�[�h�`�F�b�N�̍폜
            PrmChangeListCheck(cndWork, prmChangeWorkList, out dataTagList, ref dataErrList);// ADD 2015/05/14 ���V�� ���[�J�[�R�[�h�A���i�����ރR�[�h�A�a�k�R�[�h�`�F�b�N�̍폜

            //----- DEL 2015/05/14 ���V�� ���[�J�[�R�[�h�A���i�����ރR�[�h�A�a�k�R�[�h�`�F�b�N�̍폜------>>>>>
            //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    return status;
            //}
            //----- DEL 2015/05/14 ���V�� ���[�J�[�R�[�h�A���i�����ރR�[�h�A�a�k�R�[�h�`�F�b�N�̍폜------<<<<<
            // �G���[�f�[�^������ꍇ
            //else if (dataErrList.Count > 0)// DEL 2015/05/14 ���V�� ���[�J�[�R�[�h�A���i�����ރR�[�h�A�a�k�R�[�h�`�F�b�N�̍폜
            if (dataErrList.Count > 0)// ADD 2015/05/14 ���V�� ���[�J�[�R�[�h�A���i�����ރR�[�h�A�a�k�R�[�h�`�F�b�N�̍폜
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;// ADD 2015/05/14 ���V�� ���[�J�[�R�[�h�A���i�����ރR�[�h�A�a�k�R�[�h�`�F�b�N�̍폜
                errObjectList = dataErrList;
                csvErr = true;
                readCnt = prmChangeWorkList.Count;
                return status;
            }

            // �R�l�N�V����
            SqlConnection sqlConnection = null;
            // �g�����U�N�V����
            SqlTransaction sqlTransaction = null;

            try
            {
                // �R�l�N�V��������
                sqlConnection = this._iGoodsNoChgCommonDB.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this._iGoodsNoChgCommonDB.CreateTransaction(ref sqlConnection);

                //status = this.ChangePrmSettingProc(dataTagList, out dataSucList, out dataErrList, out readCnt, out loginCnt, ref sqlConnection, ref sqlTransaction);// DEL 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�
                status = this.ChangePrmSettingProc(dataTagList, offerPrmDic, out dataSucList, out dataErrList, out readCnt, out loginCnt, ref sqlConnection, ref sqlTransaction);// ADD 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �R�~�b�g
                    sqlTransaction.Commit();
                }
                else
                {
                    // ���[���o�b�N
                    sqlTransaction.Rollback();
                    if (dataErrList.Count > 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    loginCnt = 0;
                    dataSucList.Clear();
                }

                sucObjectList = dataSucList;
                errObjectList = dataErrList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MeijiPrmSettingDB.PrmChange");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        #region CSV���R�[�h���X�g�̍쐬
        /// <summary>
        /// CSV���R�[�h���X�g�̍쐬
        /// </summary>
        /// <param name="cndWork">�����N���X</param>
        /// <param name="csvDataInfoList"></param>
        /// <param name="prmChangeWorkList">�����[�g�p�̃C���|�[�g���[�N���X�g</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : CSV���R�[�h���X�g�̍쐬���s���B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private int ConvertToprmChangeWorkList(GoodsChangeAllCndWorkWork cndWork, List<string[]> csvDataInfoList, out ArrayList prmChangeWorkList, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            prmChangeWorkList = new ArrayList();
            NewPrmSettingUWork work = null;

            try
            {
                foreach (string[] csvDataArr in csvDataInfoList)
                {
                    work = new NewPrmSettingUWork();

                    if (csvDataArr.Length < 6)
                    {
                        work.CountErrLog = true;
                    }

                    int index = 0;
                    work.EnterpriseCode = cndWork.EnterpriseCode;             // ��ƃR�[�h
                    work.PartsMakerCd = _iGoodsNoChgCommonDB.ConvertToEmpty(csvDataArr, index++);  // ���[�J�[�R�[�h
                    work.GoodsMGroup = _iGoodsNoChgCommonDB.ConvertToEmpty(csvDataArr, index++);   // ���i�����ރR�[�h
                    work.TbsPartsCode = _iGoodsNoChgCommonDB.ConvertToEmpty(csvDataArr, index++);   // BL�R�[�h
                    work.PrmSetDtlNo1 = _iGoodsNoChgCommonDB.ConvertToEmpty(csvDataArr, index++);   // �Z���N�g�R�[�h
                    work.PrmSetDtlNoAfterOld = _iGoodsNoChgCommonDB.ConvertToEmpty(csvDataArr, index++);   // ����ʃR�[�h
                    work.PrmSetDtlNoAfterNew = _iGoodsNoChgCommonDB.ConvertToEmpty(csvDataArr, index++);   // �V��ʃR�[�h

                    prmChangeWorkList.Add(work);
                    continue;
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

        #region CSV�f�[�^�`�F�b�N
        /// <summary>
        /// �b�r�u�f�[�^�`�F�b�N���s���B
        /// </summary>
        /// <param name="cndWork">�������[�N</param>
        /// <param name="prmChangeWorkList">�`�F�b�N���X�g</param>
        /// <param name="dataTagList">�ǉ����X�g</param>
        /// <param name="dataErrList">�G���[�e�[�u���p</param>
        /// <remarks>
        /// <br>Note       : �b�r�u���R�[�h�`�F�b�N���s��</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/02/27</br>
        /// <br>Note       : ���r���[���ʑΉ�(status�ɂ�蔻�f�����̒ǉ�) </br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : 2015/04/27</br>
        /// <br>Note       : ���[�J�[�R�[�h�A���i�����ރR�[�h�A�a�k�R�[�h���݃`�F�b�N�̍폜</br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : 2015/05/14</br>
        /// </remarks>
        //private int PrmChangeListCheck(GoodsChangeAllCndWorkWork cndWork, ArrayList prmChangeWorkList, out ArrayList dataTagList, ref ArrayList dataErrList)// DEL 2015/05/14 ���V�� ���[�J�[�R�[�h�A���i�����ރR�[�h�A�a�k�R�[�h�`�F�b�N�̍폜
        private void PrmChangeListCheck(GoodsChangeAllCndWorkWork cndWork, ArrayList prmChangeWorkList, out ArrayList dataTagList, ref ArrayList dataErrList)// ADD 2015/05/14 ���V�� ���[�J�[�R�[�h�A���i�����ރR�[�h�A�a�k�R�[�h�`�F�b�N�̍폜    
        {
            //int status = (int)ConstantManagement.DB_Status.ctDB_EOF;// DEL 2015/05/14 ���V�� ���[�J�[�R�[�h�A���i�����ރR�[�h�A�a�k�R�[�h�`�F�b�N�̍폜

            string message = string.Empty;
            dataTagList = new ArrayList();

            //----- DEL 2015/05/14 ���V�� ���[�J�[�R�[�h�A���i�����ރR�[�h�A�a�k�R�[�h���݃`�F�b�N�̍폜------>>>>>
            //// ���[�J�[Dictionary
            //Dictionary<int, string> makerDic = new Dictionary<int, string>();
            //// BL�R�[�hDictionary
            //Dictionary<int, string> blCodeDic = new Dictionary<int, string>();
            //// ���i������Dictionary
            //Dictionary<int, string> goodsMGroupDic = new Dictionary<int, string>();
            //// ���[�J�[�ABL�R�[�h�A���i�����ނ̌���
            //status = this.SearchWorkData(out makerDic, out blCodeDic, out goodsMGroupDic, cndWork.EnterpriseCode);

            ////----- ADD 2015/04/27 ���V�� ���r���[���ʑΉ�(status�ɂ�蔻�f�����̒ǉ�) ------>>>>>
            //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //    return status;
            //}
            ////----- ADD 2015/04/27 ���V�� ���r���[���ʑΉ�(status�ɂ�蔻�f�����̒ǉ�) ------<<<<<
            //----- DEL 2015/05/14 ���V�� ���[�J�[�R�[�h�A���i�����ރR�[�h�A�a�k�R�[�h���݃`�F�b�N�̍폜------<<<<<

            // ���R�[�h�d���`�F�b�N�pDictionary
            Dictionary<string, string> repeatOldDic = new Dictionary<string, string>();
            Dictionary<string, string> repeatNewDic = new Dictionary<string, string>();

            foreach (NewPrmSettingUWork newPrmSettingUWork in prmChangeWorkList)
            {
                //bool checkRes = ImportCheck(newPrmSettingUWork, out message, ref repeatOldDic, ref repeatNewDic, makerDic, blCodeDic, goodsMGroupDic);// DEL 2015/05/14 ���V�� ���[�J�[�R�[�h�A���i�����ރR�[�h�A�a�k�R�[�h���݃`�F�b�N�̍폜
                bool checkRes = ImportCheck(newPrmSettingUWork, out message, ref repeatOldDic, ref repeatNewDic);// ADD 2015/05/14 ���V�� ���[�J�[�R�[�h�A���i�����ރR�[�h�A�a�k�R�[�h���݃`�F�b�N�̍폜

                if (!checkRes)
                {
                    ConverToNewPrmSettingUWork(newPrmSettingUWork, message, ref dataErrList);
                }
                else
                {
                    dataTagList.Add(newPrmSettingUWork);
                }
            }

            //return status; // DEL 2015/05/14 ���V�� ���[�J�[�R�[�h�A���i�����ރR�[�h�A�a�k�R�[�h�`�F�b�N�̍폜
        }

        /// <summary>
        /// �f�[�^�捞���`�F�b�N����(�G���[�Əd���`�F�b�N)
        /// </summary>
        /// <param name="prmSettingWork">�f�[�^</param>
        /// <param name="errMsg">���b�Z�[�W</param>
        /// <param name="repeatOldDic">���i�Ԃ̗D�ǐݒ�d���`�F�b�N�pdictionary</param>
        /// <param name="repeatNewDic">�V�i�Ԃ̗D�ǐݒ�d���`�F�b�N�pdictionary</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/02/27</br>
        /// <br>Note       : Redmine#45436 ���i�Ԏ�ʂƐV�i�Ԏ�ʂ�����̏ꍇ�̃G���[���e�����Ғl�ƂȂ��Ă��Ȃ��Ή�</br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : 2015/04/17</br>
        /// <br>Note       : ���[�J�[�R�[�h�A���i�����ރR�[�h�A�a�k�R�[�h���݃`�F�b�N�̍폜</br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : 2015/05/14</br>
        /// </remarks>
        //----- DEL 2015/05/14 ���V�� ���[�J�[�R�[�h�A���i�����ރR�[�h�A�a�k�R�[�h���݃`�F�b�N�̍폜------>>>>>
        //private bool ImportCheck(NewPrmSettingUWork prmSettingWork, out string errMsg, ref Dictionary<string, string> repeatOldDic, ref Dictionary<string, string> repeatNewDic,
        //    Dictionary<int, string> makerDic, Dictionary<int, string> blCodeDic, Dictionary<int, string> goodsMGroupDic)
        //----- DEL 2015/05/14 ���V�� ���[�J�[�R�[�h�A���i�����ރR�[�h�A�a�k�R�[�h���݃`�F�b�N�̍폜------<<<<<
        //----- DEL 2015/05/14 ���V�� ���[�J�[�R�[�h�A���i�����ރR�[�h�A�a�k�R�[�h���݃`�F�b�N�̍폜------>>>>>
        private bool ImportCheck(NewPrmSettingUWork prmSettingWork, out string errMsg, ref Dictionary<string, string> repeatOldDic, ref Dictionary<string, string> repeatNewDic)
        //----- DEL 2015/05/14 ���V�� ���[�J�[�R�[�h�A���i�����ރR�[�h�A�a�k�R�[�h���݃`�F�b�N�̍폜------<<<<<
        {
            errMsg = string.Empty;
            bool errFlg = false;
            string repeatOldMsg = "";
            string repeatNewMsg = "";
            string repeatDataKey1 = prmSettingWork.PartsMakerCd.Trim().PadLeft(4, '0') + prmSettingWork.GoodsMGroup.Trim().PadLeft(4, '0') +
                prmSettingWork.TbsPartsCode + prmSettingWork.PrmSetDtlNo1 + prmSettingWork.PrmSetDtlNoAfterOld;
            string repeatDataKey2 = prmSettingWork.PartsMakerCd.Trim().PadLeft(4, '0') + prmSettingWork.GoodsMGroup.Trim().PadLeft(4, '0') +
                prmSettingWork.TbsPartsCode + prmSettingWork.PrmSetDtlNo1 + prmSettingWork.PrmSetDtlNoAfterNew;

            // �d���`�F�b�N��Dictionary�̍쐬
            if (!repeatOldDic.ContainsKey(repeatDataKey1) && !repeatNewDic.ContainsKey(repeatDataKey1))
            {
                //repeatOldDic.Add(repeatDataKey1, repeatDataKey1); // DEL 2015/04/17 ���V�� Redmine#45436 ���i�Ԏ�ʂƐV�i�Ԏ�ʂ�����̏ꍇ�̃G���[���e�����Ғl�ƂȂ��Ă��Ȃ��Ή�
            }
            else
            {
                repeatOldMsg = ERRMSG_REPEATOLD;
            }
            if (!repeatNewDic.ContainsKey(repeatDataKey2) && !repeatOldDic.ContainsKey(repeatDataKey2))
            {
                //repeatNewDic.Add(repeatDataKey2, repeatDataKey2); // DEL 2015/04/17 ���V�� Redmine#45436 ���i�Ԏ�ʂƐV�i�Ԏ�ʂ�����̏ꍇ�̃G���[���e�����Ғl�ƂȂ��Ă��Ȃ��Ή�
            }
            else
            {
                repeatNewMsg = ERRMSG_REPEATNEW;
            }
            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i�Ԏ�ʂƐV�i�Ԏ�ʂ�����̏ꍇ�̃G���[���e�����Ғl�ƂȂ��Ă��Ȃ��Ή�------>>>>>
            if (!repeatOldDic.ContainsKey(repeatDataKey1))
            {
                repeatOldDic.Add(repeatDataKey1, repeatDataKey1);
            }
            else
            { 
                // �Ȃ�
            }
            if (!repeatNewDic.ContainsKey(repeatDataKey2))
            {
                repeatNewDic.Add(repeatDataKey2, repeatDataKey2);
            }
            else
            {
                // �Ȃ�
            }
            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i�Ԏ�ʂƐV�i�Ԏ�ʂ�����̏ꍇ�̃G���[���e�����Ғl�ƂȂ��Ă��Ȃ��Ή�------<<<<<

            //���ڐ��`�F�b�N
            if (prmSettingWork.CountErrLog)
            {
                errFlg = true;
                errMsg = GoodsNoChgCommonDB.ERRMSG_COUNTERR;
            }
            if (!string.IsNullOrEmpty(errMsg))
            {
                return false;
            }

            //���[�J�[�R�[�h�`�F�b�N
            string makerMsg = string.Empty;
            if (!_iGoodsNoChgCommonDB.Check_IsNull("���[�J�[", prmSettingWork.PartsMakerCd.Trim(), out makerMsg))
                errFlg = true;
            else if (!_iGoodsNoChgCommonDB.Check_StrUnFixedLen("���[�J�[", prmSettingWork.PartsMakerCd.Trim(), 4, out makerMsg))
                errFlg = true;
            else if (!_iGoodsNoChgCommonDB.IsDigitAdd("���[�J�[", prmSettingWork.PartsMakerCd.Trim(), out makerMsg))
                errFlg = true;
            //----- DEL 2015/05/14 ���V�� ���[�J�[�R�[�h�A���i�����ރR�[�h�A�a�k�R�[�h���݃`�F�b�N�̍폜------>>>>>
            //else if (!makerDic.ContainsKey(Convert.ToInt32(prmSettingWork.PartsMakerCd.Trim())))
            //{
            //    errFlg = true;
            //    makerMsg = GoodsNoChgCommonDB.ERRMSG_MAKERNOTFOUND;
            //}
            //----- DEL 2015/05/14 ���V�� ���[�J�[�R�[�h�A���i�����ރR�[�h�A�a�k�R�[�h���݃`�F�b�N�̍폜------<<<<<

            if (errFlg && !string.IsNullOrEmpty(makerMsg))
            {
                errMsg = makerMsg;
            }
            //���i�����ރR�[�h�`�F�b�N
            string goodsMGroupMsg = string.Empty;
            if (!_iGoodsNoChgCommonDB.Check_IsNull("���i������", prmSettingWork.GoodsMGroup.Trim(), out goodsMGroupMsg))
                errFlg = true;
            else if (!_iGoodsNoChgCommonDB.Check_StrUnFixedLen("���i������", prmSettingWork.GoodsMGroup.Trim(), 4, out goodsMGroupMsg))
                errFlg = true;
            else if (!_iGoodsNoChgCommonDB.IsDigitAdd("���i������", prmSettingWork.GoodsMGroup.Trim(), out goodsMGroupMsg))
                errFlg = true;
            //----- DEL 2015/05/14 ���V�� ���[�J�[�R�[�h�A���i�����ރR�[�h�A�a�k�R�[�h���݃`�F�b�N�̍폜------>>>>>
            //else if (!goodsMGroupDic.ContainsKey(Convert.ToInt32(prmSettingWork.GoodsMGroup.Trim())))
            //{
            //    errFlg = true;
            //    goodsMGroupMsg = ERRMSG_MGROUPNOTFOUND;
            //}
            //----- DEL 2015/05/14 ���V�� ���[�J�[�R�[�h�A���i�����ރR�[�h�A�a�k�R�[�h���݃`�F�b�N�̍폜------<<<<<
            if (errFlg && !string.IsNullOrEmpty(goodsMGroupMsg))
            {
                if (string.IsNullOrEmpty(errMsg))
                {
                    errMsg = goodsMGroupMsg;
                }
                else
                {
                    errMsg = errMsg + "�A" + goodsMGroupMsg;
                }
            }
            //�a�k�R�[�h�`�F�b�N
            string tbsPartsCodeMsg = string.Empty;
            if (!_iGoodsNoChgCommonDB.Check_IsNull("�a�k�R�[�h", prmSettingWork.TbsPartsCode.Trim(), out tbsPartsCodeMsg))
                errFlg = true;
            else if (!_iGoodsNoChgCommonDB.Check_StrUnFixedLen("�a�k�R�[�h", prmSettingWork.TbsPartsCode.Trim(), 5, out tbsPartsCodeMsg))
                errFlg = true;
            else if (!_iGoodsNoChgCommonDB.IsDigitAdd("�a�k�R�[�h", prmSettingWork.TbsPartsCode.Trim(), out tbsPartsCodeMsg))
                errFlg = true;
            //----- DEL 2015/05/14 ���V�� ���[�J�[�R�[�h�A���i�����ރR�[�h�A�a�k�R�[�h���݃`�F�b�N�̍폜------>>>>>
            //else if (!blCodeDic.ContainsKey(Convert.ToInt32(prmSettingWork.TbsPartsCode.Trim())))
            //{
            //    errFlg = true;
            //    tbsPartsCodeMsg = ERRMSG_BLCODENOTFOUND;
            //}
            //----- DEL 2015/05/14 ���V�� ���[�J�[�R�[�h�A���i�����ރR�[�h�A�a�k�R�[�h���݃`�F�b�N�̍폜------<<<<<
            if (errFlg && !string.IsNullOrEmpty(tbsPartsCodeMsg))
            {
                if (string.IsNullOrEmpty(errMsg))
                {
                    errMsg = tbsPartsCodeMsg;
                }
                else
                {
                    errMsg = errMsg + "�A" + tbsPartsCodeMsg;
                }
            }
            //�Z���N�g�R�[�h�`�F�b�N
            string prmSetDtlNoMsg = string.Empty;
            if (!_iGoodsNoChgCommonDB.Check_IsNull("�Z���N�g�R�[�h", prmSettingWork.PrmSetDtlNo1.Trim(), out prmSetDtlNoMsg))
                errFlg = true;
            else if (!_iGoodsNoChgCommonDB.Check_StrUnFixedLen("�Z���N�g�R�[�h", prmSettingWork.PrmSetDtlNo1.Trim(), 4, out prmSetDtlNoMsg))
                errFlg = true;
            else if (!_iGoodsNoChgCommonDB.IsDigitAddZero("�Z���N�g�R�[�h", prmSettingWork.PrmSetDtlNo1.Trim(), out prmSetDtlNoMsg))
                errFlg = true;

            if (errFlg && !string.IsNullOrEmpty(prmSetDtlNoMsg))
            {
                if (string.IsNullOrEmpty(errMsg))
                {
                    errMsg = prmSetDtlNoMsg;
                }
                else
                {
                    errMsg = errMsg + "�A" + prmSetDtlNoMsg;
                }
            }
            //���i��_��ʃR�[�h�`�F�b�N
            string prmSetDtlNoOldMsg = string.Empty;
            if (!_iGoodsNoChgCommonDB.Check_IsNull("���i�Ԃ̎�ʃR�[�h", prmSettingWork.PrmSetDtlNoAfterOld.Trim(), out prmSetDtlNoOldMsg))
                errFlg = true;
            else if (!_iGoodsNoChgCommonDB.Check_StrUnFixedLen("���i�Ԃ̎�ʃR�[�h", prmSettingWork.PrmSetDtlNoAfterOld.Trim(), 4, out prmSetDtlNoOldMsg))
                errFlg = true;
            else if (!_iGoodsNoChgCommonDB.IsDigitAdd("���i�Ԃ̎�ʃR�[�h", prmSettingWork.PrmSetDtlNoAfterOld.Trim(), out prmSetDtlNoOldMsg))
                errFlg = true;

            if (errFlg && !string.IsNullOrEmpty(prmSetDtlNoOldMsg))
            {
                if (string.IsNullOrEmpty(errMsg))
                {
                    errMsg = prmSetDtlNoOldMsg;
                }
                else
                {
                    errMsg = errMsg + "�A" + prmSetDtlNoOldMsg;
                }
            }
            //�V�i��_��ʃR�[�h�`�F�b�N
            string prmSetDtlNoNewMsg = string.Empty;
            if (!_iGoodsNoChgCommonDB.Check_IsNull("�V�i�Ԃ̎�ʃR�[�h", prmSettingWork.PrmSetDtlNoAfterNew.Trim(), out prmSetDtlNoNewMsg))
                errFlg = true;
            else if (!_iGoodsNoChgCommonDB.Check_StrUnFixedLen("�V�i�Ԃ̎�ʃR�[�h", prmSettingWork.PrmSetDtlNoAfterNew.Trim(), 4, out prmSetDtlNoNewMsg))
                errFlg = true;
            else if (!_iGoodsNoChgCommonDB.IsDigitAdd("�V�i�Ԃ̎�ʃR�[�h", prmSettingWork.PrmSetDtlNoAfterNew.Trim(), out prmSetDtlNoNewMsg))
                errFlg = true;

            if (errFlg && !string.IsNullOrEmpty(prmSetDtlNoNewMsg))
            {
                if (string.IsNullOrEmpty(errMsg))
                {
                    errMsg = prmSetDtlNoNewMsg;
                }
                else
                {
                    errMsg = errMsg + "�A" + prmSetDtlNoNewMsg;
                }
            }

            if (!string.IsNullOrEmpty(errMsg))
            {
                return false;
            }

            // ���R�[�h���d�����`�F�b�N
            //----- DEL 2015/04/17 ���V�� Redmine#45436 ���i�Ԏ�ʂƐV�i�Ԏ�ʂ�����̏ꍇ�̃G���[���e�����Ғl�ƂȂ��Ă��Ȃ��Ή�------>>>>>
            //if (!string.IsNullOrEmpty(repeatOldMsg))
            //{
            //    errMsg = repeatOldMsg;
            //    return false;
            //}
            //else if (!string.IsNullOrEmpty(repeatNewMsg))
            //{
            //    errMsg = repeatNewMsg;
            //    return false;
            //}
            //else if (prmSettingWork.PrmSetDtlNoAfterOld.Trim().Equals(prmSettingWork.PrmSetDtlNoAfterNew.Trim()))
            //{
            //    errMsg = ERRMSG_REPEATCODE;
            //    return false;
            //}
            //----- DEL 2015/04/17 ���V�� Redmine#45436 ���i�Ԏ�ʂƐV�i�Ԏ�ʂ�����̏ꍇ�̃G���[���e�����Ғl�ƂȂ��Ă��Ȃ��Ή�------<<<<<
            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i�Ԏ�ʂƐV�i�Ԏ�ʂ�����̏ꍇ�̃G���[���e�����Ғl�ƂȂ��Ă��Ȃ��Ή�------>>>>>
            if (prmSettingWork.PrmSetDtlNoAfterOld.Trim().Equals(prmSettingWork.PrmSetDtlNoAfterNew.Trim()))
            {
                errMsg = ERRMSG_REPEATCODE;
                return false;
            }
            else if (!string.IsNullOrEmpty(repeatOldMsg))
            {
                errMsg = repeatOldMsg;
                return false;
            }
            else if (!string.IsNullOrEmpty(repeatNewMsg))
            {
                errMsg = repeatNewMsg;
                return false;
            }
            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i�Ԏ�ʂƐV�i�Ԏ�ʂ�����̏ꍇ�̃G���[���e�����Ғl�ƂȂ��Ă��Ȃ��Ή�------<<<<<

            return true;
        }

        #region �G���[�f�[�^�ւ���
        //private const string ERRMSG_BLCODENOTFOUND = "�a�k�R�[�h���}�X�^�ɓo�^����Ă��܂���";// DEL 2015/05/14 ���V�� ���[�J�[�R�[�h�A���i�����ރR�[�h�A�a�k�R�[�h���݃`�F�b�N�̍폜
        //private const string ERRMSG_MGROUPNOTFOUND = "���i�����ނ��}�X�^�ɓo�^����Ă��܂���";// DEL 2015/05/14 ���V�� ���[�J�[�R�[�h�A���i�����ރR�[�h�A�a�k�R�[�h���݃`�F�b�N�̍폜
        private const string ERRMSG_REPEATOLD = "���i�Ԃ̗D�ǐݒ肪�d�����Ă���s�����݂��܂�";
        private const string ERRMSG_REPEATNEW = "�V�i�Ԃ̗D�ǐݒ肪�d�����Ă���s�����݂��܂�";
        private const string ERRMSG_REPEATCODE = "���i�ԂƐV�i�Ԃ̗D�ǐݒ肪�d�����Ă��܂�";

        /// <summary>
        /// �G���[�f�[�^�̏���
        /// </summary>
        /// <param name="prmSettingWork">���i�Ǘ��f�[�^</param>
        /// <param name="dataList">�e�[�v������</param>
        ///<param name="message">����[���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note       : �G���[�f�[�^�̏������s���B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private void ConverToNewPrmSettingUWork(NewPrmSettingUWork prmSettingWork, string message, ref ArrayList dataList)
        {
            NewPrmSettingUWork tempWork = new NewPrmSettingUWork();

            //���i���[�J�[�R�[�h
            tempWork.PartsMakerCd = prmSettingWork.PartsMakerCd;
            //���i�����ރR�[�h
            tempWork.GoodsMGroup = prmSettingWork.GoodsMGroup;
            //�a�k�R�[�h
            tempWork.TbsPartsCode = prmSettingWork.TbsPartsCode;
            //�Z���N�g�R�[�h
            tempWork.PrmSetDtlNo1 = prmSettingWork.PrmSetDtlNo1;
            //���i��_��ʃR�[�h
            tempWork.PrmSetDtlNoAfterOld = prmSettingWork.PrmSetDtlNoAfterOld;
            //�V�i��_��ʃR�[�h
            tempWork.PrmSetDtlNoAfterNew = prmSettingWork.PrmSetDtlNoAfterNew;
            //�G���[���b�Z�W�[
            tempWork.OutNote = message;

            dataList.Add(tempWork);
        }
        #endregion

        #region ����Dictionary�̎擾
        //----- DEL 2015/05/14 ���V�� ���[�J�[�R�[�h�A���i�����ރR�[�h�A�a�k�R�[�h���݃`�F�b�N�̍폜------>>>>>
        ///// <summary>
        ///// ��ƃR�[�h�ɂ���āA���[�J�[�ABL�R�[�h�A���i�����ނ�Dictionary�쐬
        ///// </summary>
        ///// <param name="makerDic">���[�J�[��Dictionary</param>
        ///// <param name="blCodeDic">�a�k�R�[�h��Dictionary</param>
        ///// <param name="goodsMGroupDic">���i�����ނ�Dictionary</param>
        ///// <param name="enterPriseCode">��ƃR�[�h</param>
        ///// <returns></returns>
        ///// <remarks>
        ///// <br>Programmer  : �i�N</br>
        ///// <br>Date        : 2015/01/26</br>
        ///// <br>Note      �@: ���r���[���ʑΉ�(status�ɂ�蔻�f�����̒ǉ�)</br>
        ///// <br>Programmer�@: ���V��</br>
        ///// <br>Date        : 2015/04/27</br>
        ///// </remarks>
        //private int SearchWorkData(out Dictionary<int, string> makerDic, out Dictionary<int, string> blCodeDic,
        //    out Dictionary<int, string> goodsMGroupDic, string enterPriseCode)
        //{
        //    // �e�}�X�^��Dictionary
        //    makerDic = new Dictionary<int, string>();
        //    blCodeDic = new Dictionary<int, string>();
        //    goodsMGroupDic = new Dictionary<int, string>();

        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    // �R�l�N�V��������
        //    SqlConnection sqlConnection = null;

        //    try
        //    {
        //        sqlConnection = this._iGoodsNoChgCommonDB.CreateSqlConnection(true);

        //        // BL�R�[�h�}�X�^
        //        BLGoodsCdUDB bLGoodsCdUDB = new BLGoodsCdUDB();
        //        ArrayList retal = null;
        //        BLGoodsCdUWork bLGoodsCdUWork = new BLGoodsCdUWork();
        //        bLGoodsCdUWork.EnterpriseCode = enterPriseCode;
        //        status = bLGoodsCdUDB.SearchBLGoodsCdProc(out retal, bLGoodsCdUWork, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection);
        //        //----- ADD 2015/04/27 ���V�� ���r���[���ʑΉ�(status�ɂ�蔻�f�����̒ǉ�) ------>>>>>
        //        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //        {
        //            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //            return status;
        //        }
        //        //----- ADD 2015/04/27 ���V�� ���r���[���ʑΉ�(status�ɂ�蔻�f�����̒ǉ�) ------<<<<<
        //        foreach (BLGoodsCdUWork bLGoodsWork in retal)
        //        {
        //            if (!blCodeDic.ContainsKey(bLGoodsWork.BLGoodsCode))
        //            {
        //                blCodeDic.Add(bLGoodsWork.BLGoodsCode, bLGoodsWork.BLGoodsHalfName);
        //            }
        //        }

        //        // ���[�J�[�}�X�^�i���[�U�[�o�^�j
        //        MakerUDB makerUDB = new MakerUDB();
        //        retal = null;
        //        MakerUWork makerUWork = new MakerUWork();
        //        makerUWork.EnterpriseCode = enterPriseCode;
        //        status = makerUDB.SearchMakerProc(out retal, makerUWork, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection);
        //        //----- ADD 2015/04/27 ���V�� ���r���[���ʑΉ�(status�ɂ�蔻�f�����̒ǉ�) ------>>>>>
        //        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //        {
        //            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //            return status;
        //        }
        //        //----- ADD 2015/04/27 ���V�� ���r���[���ʑΉ�(status�ɂ�蔻�f�����̒ǉ�) ------<<<<<
        //        foreach (MakerUWork makerWork in retal)
        //        {
        //            if (!makerDic.ContainsKey(makerWork.GoodsMakerCd))
        //            {
        //                makerDic.Add(makerWork.GoodsMakerCd, makerWork.MakerName);
        //            }
        //        }

        //        // ���i�����ރ}�X�^
        //        ArrayList retalRlt = new ArrayList();
        //        GoodsGroupUDB goodsGroupUDB = new GoodsGroupUDB();
        //        retal.Clear();
        //        object retalObj = retal;
        //        GoodsGroupUWork goodsGroupUWork = new GoodsGroupUWork();
        //        goodsGroupUWork.EnterpriseCode = enterPriseCode;
        //        object goodsGroupUObj = goodsGroupUWork;
        //        status = goodsGroupUDB.Search(ref retalObj, goodsGroupUObj, 0, ConstantManagement.LogicalMode.GetData0);
        //        //----- ADD 2015/04/27 ���V�� ���r���[���ʑΉ�(status�ɂ�蔻�f�����̒ǉ�) ------>>>>>
        //        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //        {
        //            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //            return status;
        //        }
        //        //----- ADD 2015/04/27 ���V�� ���r���[���ʑΉ�(status�ɂ�蔻�f�����̒ǉ�) ------<<<<<
        //        retalRlt = (ArrayList)retalObj;
        //        foreach (GoodsGroupUWork goodsGroupWork in retalRlt)
        //        {
        //            if (!goodsMGroupDic.ContainsKey(goodsGroupWork.GoodsMGroup))
        //            {
        //                goodsMGroupDic.Add(goodsGroupWork.GoodsMGroup, goodsGroupWork.GoodsMGroupName);
        //            }
        //        }

        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }
        //    catch (SqlException ex)
        //    {
        //        //���N���X�ɗ�O��n���ď������Ă��炤
        //        status = base.WriteSQLErrorLog(ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        base.WriteErrorLog(ex, "MeijiGoodsStockDB.SearchWorkDate Exception=" + ex.Message);
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    }
        //    finally
        //    {
        //        if (sqlConnection != null)
        //        {
        //            sqlConnection.Close();
        //            sqlConnection.Dispose();
        //        }
        //    }

        //    return status;
        //}
        //----- DEL 2015/05/14 ���V�� ���[�J�[�R�[�h�A���i�����ރR�[�h�A�a�k�R�[�h���݃`�F�b�N�̍폜------<<<<<
        #endregion

        #endregion

        #region �D�ǐݒ�}�X�^�ϊ�����
        /// <summary>
        /// �D�ǐݒ�}�X�^�ϊ�����(�O�������SqlConnection and SqlTranaction���g�p)
        /// </summary>
        /// <param name="prmSettingWorkList">�D�ǐݒ胊�X�g</param>
        /// <param name="offerPrmDic">�񋟕��f�[�^</param>
        /// <param name="prmSucList">�������X�g</param>
        /// <param name="prmErrList">���s���X�g</param>
        /// <param name="readCntCount">�Ǎ�����</param>
        /// <param name="changeCount">�X�V����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note        : �D�ǐݒ�}�X�^�ϊ�����(�O�������SqlConnection and SqlTranaction���g�p)</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/02/27</br>
        /// <br>Note        : Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�</br>
        /// <br>Programmer  : ���V��</br>
        /// <br>Date        : 2015/03/16</br>
        /// <br>Note        : Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�</br>
        /// <br>Programmer  : ���V��</br>
        /// <br>Date        : 2015/04/17</br>
        //private int ChangePrmSettingProc(ArrayList prmSettingWorkList, out ArrayList prmSucList, out ArrayList prmErrList, out int readCntCount, out int changeCount, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)// DEL 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�
        private int ChangePrmSettingProc(ArrayList prmSettingWorkList, Dictionary<string, PrmSettingWork> offerPrmDic, out ArrayList prmSucList, // ADD 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�
            out ArrayList prmErrList, out int readCntCount, out int changeCount, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)// ADD 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection prmConnection = this._iGoodsNoChgCommonDB.CreateSqlConnection(true);
            // �X�V�p���X�g
            ArrayList prmUWorkSearchList = new ArrayList();
            ArrayList changePrmList = new ArrayList();
            ArrayList deleteWorkList = new ArrayList();
            ArrayList insertWorkList = new ArrayList();
            // �X�V���ʃ��X�g
            prmSucList = new ArrayList();
            prmErrList = new ArrayList();
            // �Ǎ������ƍX�V����
            readCntCount = 0;
            changeCount = 0;

            Dictionary<string, string> csvDic = new Dictionary<string, string>();
            string csvKey = "";
            try
            {
                #region CSV���R�[�h���A�X�V�f�[�^�̌�������
                foreach (NewPrmSettingUWork newPrmSettingUWork in prmSettingWorkList)
                {
                    csvKey = newPrmSettingUWork.PartsMakerCd.ToString() + newPrmSettingUWork.GoodsMGroup.ToString() +
                        newPrmSettingUWork.TbsPartsCode.ToString() + newPrmSettingUWork.PrmSetDtlNo1.ToString() + newPrmSettingUWork.PrmSetDtlNoAfterOld.Trim();

                    // �V����ʃR�[�h��Dictionary
                    if (!csvDic.ContainsKey(csvKey))
                    {
                        csvDic.Add(csvKey, newPrmSettingUWork.PrmSetDtlNoAfterNew.Trim());
                    }

                    status = SearchProc(newPrmSettingUWork, ref prmUWorkSearchList, prmConnection);

                    // �����ȏꍇ
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (prmUWorkSearchList != null && prmUWorkSearchList.Count > 0)
                        {
                            //�Ǎ�����
                            readCntCount = readCntCount + prmUWorkSearchList.Count;
                            changePrmList.AddRange(prmUWorkSearchList);
                        }
                    }
                    // �ُ�ȏꍇ
                    else
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                    prmUWorkSearchList.Clear();
                }
                #endregion

                #region �����������݂̂̏ꍇ�A�X�V���������s����
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���������f�[�^���A�D�ǐݒ�}�X�^�ɍX�V����
                    foreach (NewPrmSettingUWork prmSetwork in changePrmList)
                    {
                        string message = "";
                        // �D�ǐݒ胏�[�N�̕ϊ�
                        PrmSettingUWork prmSettingUWork;
                        ConvertToPrmSettingUWork(prmSetwork, out prmSettingUWork);

                        // ����ʂ̍폜
                        deleteWorkList.Add(prmSettingUWork);
                        //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                        try
                        {
                        //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                            status = this._iprmSettingUDB.Delete(deleteWorkList, ref sqlConnection, ref sqlTransaction);
                        //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                        }
                        catch (Exception ex)
                        {
                            base.WriteErrorLog(ex, "Delete");
                            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        }
                        //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                        deleteWorkList.Clear();

                        // �폜�̏ꍇ�ُ킪��������
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �r���ُ킪��������ꍇ
                            if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE
                                || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                            {
                                message = GoodsNoChgCommonDB.PRMDELETEERR;
                            }
                            // ����ȊO�ُ�̏ꍇ
                            else
                            {
                                message = GoodsNoChgCommonDB.PRMDELETEEX;
                            }
                        }
                        // �폜������̏ꍇ
                        else
                        {
                            prmSettingUWork.UpdateDateTime = DateTime.MinValue;
                            // ��ʃR�[�h�̕ϊ�
                            csvKey = prmSettingUWork.PartsMakerCd.ToString() + prmSettingUWork.GoodsMGroup.ToString() +
                                prmSettingUWork.TbsPartsCode.ToString() + prmSettingUWork.PrmSetDtlNo1.ToString() + prmSetwork.PrmSetDtlNoAfterOld.Trim();

                            if (csvDic.ContainsKey(csvKey))
                            {
                                prmSettingUWork.PrmSetDtlNo2 = Convert.ToInt32(csvDic[csvKey]);
                            }

                            // ��ʖ��̂ƒ񋟓��t�̕ϊ�
                            csvKey = prmSettingUWork.PartsMakerCd.ToString() + prmSettingUWork.GoodsMGroup.ToString() +
                                prmSettingUWork.TbsPartsCode.ToString() + prmSettingUWork.PrmSetDtlNo1.ToString() + prmSetwork.PrmSetDtlNoAfterNew.Trim();


                            if (offerPrmDic.ContainsKey(csvKey))
                            {
                                prmSettingUWork.PrmSetDtlName2 = offerPrmDic[csvKey].PrmSetDtlName2;
                                prmSettingUWork.OfferDate = offerPrmDic[csvKey].OfferDate;
                            }
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                message = GoodsNoChgCommonDB.PRMOFFERNOT;
                            }

                            // �񋟃f�[�^���擾����ꍇ�A�X�V�����s����
                            if (string.IsNullOrEmpty(message))
                            {
                                // �D�ǐݒ�}�X�^�ɐV�i�Ԃ�ǉ�����
                                insertWorkList.Add(prmSettingUWork);
                                status = WriteProc(ref insertWorkList, ref sqlConnection, ref sqlTransaction);
                                insertWorkList.Clear();

                                // �o�^���ُ킪��������ꍇ
                                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // �r���ُ킪��������ꍇ
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE
                                        || status == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE)
                                    {
                                        message = GoodsNoChgCommonDB.PRMINSERTERR;
                                    }
                                    // ����ȊO�ُ�̏ꍇ
                                    else
                                    {
                                        message = GoodsNoChgCommonDB.PRMINSERTEX;
                                    }
                                }
                            }
                        }

                        // ���O���X�g�̃Z�b�g
                        if (string.IsNullOrEmpty(message))
                        {
                            prmSucList.Add(prmSetwork);
                        }
                        else
                        {
                            prmSetwork.OutNote = message;
                            prmErrList.Add(prmSetwork);
                            break;
                        }
                    }

                    // �X�V����
                    if (prmSucList != null && prmSucList.Count > 0)
                    {
                        changeCount = prmSucList.Count;
                    }
                }
                #endregion
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (prmConnection != null)
                {
                    prmConnection.Close();
                    prmConnection.Dispose();
                }
            }

            return status;
        }

        //----- ADD 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�------>>>>>
        /// <summary>
        /// �D�ǐݒ�}�X�^�i���[�U�[�o�^���j����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="prmSettingUList">�ǉ��E�X�V����D�ǐݒ�}�X�^�i���[�U�[�o�^���j�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PrmSettingUList �Ɋi�[����Ă���D�ǐݒ�}�X�^�i���[�U�[�o�^���j����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : 2015/03/16</br>
        /// <br>Note       : ���X�g��NULL�A��count�͔��f����Ή��B</br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : 2015/04/29</br>
        private int WriteProc(ref ArrayList prmSettingUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (prmSettingUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < prmSettingUList.Count; i++)
                    {
                        //PrmSettingUWork prmSettingUWork = prmSettingUList[i] as PrmSettingUWork;// DEL 2015/04/29 ���V�� ���X�g��NULL�A��count�͔��f����Ή�
                        //----- ADD 2015/04/29 ���V�� ���X�g��NULL�A��count�͔��f����Ή�------>>>>>
                        PrmSettingUWork prmSettingUWork = null;
                        if (prmSettingUList != null && prmSettingUList.Count > 0)
                        {
                            prmSettingUWork = prmSettingUList[i] as PrmSettingUWork;
                        }
                        //----- ADD 2015/04/29 ���V�� ���X�g��NULL�A��count�͔��f����Ή�------<<<<<
                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " FROM PRMSETTINGURF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlText += "    AND GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                        sqlText += "    AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                        sqlText += "    AND PARTSMAKERCDRF=@FINDPARTSMAKERCD" + Environment.NewLine;
                        sqlText += "    AND PRMSETDTLNO1RF=@FINDPRMSETDTLNO1" + Environment.NewLine;
                        sqlText += "    AND PRMSETDTLNO2RF=@FINDPRMSETDTLNO2" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                        SqlParameter findParaTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int);
                        SqlParameter findParaPartsMakerCd = sqlCommand.Parameters.Add("@FINDPARTSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaPrmSetDtlNo1 = sqlCommand.Parameters.Add("@FINDPRMSETDTLNO1", SqlDbType.Int);
                        SqlParameter findParaPrmSetDtlNo2 = sqlCommand.Parameters.Add("@FINDPRMSETDTLNO2", SqlDbType.Int);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.SectionCode);
                        findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.GoodsMGroup);
                        findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.TbsPartsCode);
                        findParaPartsMakerCd.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PartsMakerCd);
                        findParaPrmSetDtlNo1.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo1);
                        findParaPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo2);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != prmSettingUWork.UpdateDateTime)
                            {
                                if (prmSettingUWork.UpdateDateTime == DateTime.MinValue)
                                {
                                    // �V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                    status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                }
                                else
                                {
                                    // �����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                }

                                return status;
                            }

                            # region [UPDATE��]
                            sqlText = string.Empty;
                            sqlText += "UPDATE PRMSETTINGURF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            sqlText += " , GOODSMGROUPRF=@GOODSMGROUP" + Environment.NewLine;
                            sqlText += " , TBSPARTSCODERF=@TBSPARTSCODE" + Environment.NewLine;
                            sqlText += " , TBSPARTSCDDERIVEDNORF=@TBSPARTSCDDERIVEDNO" + Environment.NewLine;
                            sqlText += " , MAKERDISPORDERRF=@MAKERDISPORDER" + Environment.NewLine;
                            sqlText += " , PARTSMAKERCDRF=@PARTSMAKERCD" + Environment.NewLine;
                            sqlText += " , PRIMEDISPORDERRF=@PRIMEDISPORDER" + Environment.NewLine;
                            sqlText += " , PRMSETDTLNO1RF=@PRMSETDTLNO1" + Environment.NewLine;
                            sqlText += " , PRMSETDTLNAME1RF=@PRMSETDTLNAME1" + Environment.NewLine;
                            sqlText += " , PRMSETDTLNO2RF=@PRMSETDTLNO2" + Environment.NewLine;
                            sqlText += " , PRMSETDTLNAME2RF=@PRMSETDTLNAME2" + Environment.NewLine;
                            sqlText += " , PRIMEDISPLAYCODERF=@PRIMEDISPLAYCODE" + Environment.NewLine;
                            sqlText += " , OFFERDATERF=@OFFERDATE" + Environment.NewLine;
                            sqlText += " , PRMSETDTLNAME2FORFACRF=@PRMSETDTLNAME2FORFACRF" + Environment.NewLine;
                            sqlText += " , PRMSETDTLNAME2FORCOWRF=@PRMSETDTLNAME2FORCOWRF" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlText += "    AND GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                            sqlText += "    AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                            sqlText += "    AND PARTSMAKERCDRF=@FINDPARTSMAKERCD" + Environment.NewLine;
                            sqlText += "    AND PRMSETDTLNO1RF=@FINDPRMSETDTLNO1" + Environment.NewLine;
                            sqlText += "    AND PRMSETDTLNO2RF=@FINDPRMSETDTLNO2" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.SectionCode);
                            findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.GoodsMGroup);
                            findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.TbsPartsCode);
                            findParaPartsMakerCd.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PartsMakerCd);
                            findParaPrmSetDtlNo1.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo1);
                            findParaPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo2);

                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)prmSettingUWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (prmSettingUWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT��]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO PRMSETTINGURF" + Environment.NewLine;
                            sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                            sqlText += "    ,GOODSMGROUPRF" + Environment.NewLine;
                            sqlText += "    ,TBSPARTSCODERF" + Environment.NewLine;
                            sqlText += "    ,TBSPARTSCDDERIVEDNORF" + Environment.NewLine;
                            sqlText += "    ,MAKERDISPORDERRF" + Environment.NewLine;
                            sqlText += "    ,PARTSMAKERCDRF" + Environment.NewLine;
                            sqlText += "    ,PRIMEDISPORDERRF" + Environment.NewLine;
                            sqlText += "    ,PRMSETDTLNO1RF" + Environment.NewLine;
                            sqlText += "    ,PRMSETDTLNAME1RF" + Environment.NewLine;
                            sqlText += "    ,PRMSETDTLNO2RF" + Environment.NewLine;
                            sqlText += "    ,PRMSETDTLNAME2RF" + Environment.NewLine;
                            sqlText += "    ,PRIMEDISPLAYCODERF" + Environment.NewLine;
                            sqlText += "    ,OFFERDATERF" + Environment.NewLine;
                            sqlText += "    ,PRMSETDTLNAME2FORFACRF" + Environment.NewLine;
                            sqlText += "    ,PRMSETDTLNAME2FORCOWRF" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlText += " VALUES" + Environment.NewLine;
                            sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "    ,@SECTIONCODE" + Environment.NewLine;
                            sqlText += "    ,@GOODSMGROUP" + Environment.NewLine;
                            sqlText += "    ,@TBSPARTSCODE" + Environment.NewLine;
                            sqlText += "    ,@TBSPARTSCDDERIVEDNO" + Environment.NewLine;
                            sqlText += "    ,@MAKERDISPORDER" + Environment.NewLine;
                            sqlText += "    ,@PARTSMAKERCD" + Environment.NewLine;
                            sqlText += "    ,@PRIMEDISPORDER" + Environment.NewLine;
                            sqlText += "    ,@PRMSETDTLNO1" + Environment.NewLine;
                            sqlText += "    ,@PRMSETDTLNAME1" + Environment.NewLine;
                            sqlText += "    ,@PRMSETDTLNO2" + Environment.NewLine;
                            sqlText += "    ,@PRMSETDTLNAME2" + Environment.NewLine;
                            sqlText += "    ,@PRIMEDISPLAYCODE" + Environment.NewLine;
                            sqlText += "    ,@OFFERDATE" + Environment.NewLine;
                            sqlText += "    ,@PRMSETDTLNAME2FORFACRF" + Environment.NewLine;
                            sqlText += "    ,@PRMSETDTLNAME2FORCOWRF" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // �o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)prmSettingUWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        # region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);
                        SqlParameter paraTbsPartsCode = sqlCommand.Parameters.Add("@TBSPARTSCODE", SqlDbType.Int);
                        SqlParameter paraTbsPartsCdDerivedNo = sqlCommand.Parameters.Add("@TBSPARTSCDDERIVEDNO", SqlDbType.Int);
                        SqlParameter paraMakerDispOrder = sqlCommand.Parameters.Add("@MAKERDISPORDER", SqlDbType.Int);
                        SqlParameter paraPartsMakerCd = sqlCommand.Parameters.Add("@PARTSMAKERCD", SqlDbType.Int);
                        SqlParameter paraPrimeDispOrder = sqlCommand.Parameters.Add("@PRIMEDISPORDER", SqlDbType.Int);
                        SqlParameter paraPrmSetDtlNo1 = sqlCommand.Parameters.Add("@PRMSETDTLNO1", SqlDbType.Int);
                        SqlParameter paraPrmSetDtlName1 = sqlCommand.Parameters.Add("@PRMSETDTLNAME1", SqlDbType.NVarChar);
                        SqlParameter paraPrmSetDtlNo2 = sqlCommand.Parameters.Add("@PRMSETDTLNO2", SqlDbType.Int);
                        SqlParameter paraPrmSetDtlName2 = sqlCommand.Parameters.Add("@PRMSETDTLNAME2", SqlDbType.NVarChar);
                        SqlParameter paraPrimeDisplayCode = sqlCommand.Parameters.Add("@PRIMEDISPLAYCODE", SqlDbType.Int);
                        SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
                        SqlParameter paraPrmSetDtlName2ForFac = sqlCommand.Parameters.Add("@PRMSETDTLNAME2FORFACRF", SqlDbType.NVarChar);
                        SqlParameter paraPrmSetDtlName2ForCOw = sqlCommand.Parameters.Add("@PRMSETDTLNAME2FORCOWRF", SqlDbType.NVarChar);
                        # endregion

                        # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(prmSettingUWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(prmSettingUWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(prmSettingUWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(prmSettingUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(prmSettingUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.SectionCode);
                        paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.GoodsMGroup);
                        paraTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.TbsPartsCode);
                        paraTbsPartsCdDerivedNo.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.TbsPartsCdDerivedNo);
                        paraMakerDispOrder.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.MakerDispOrder);
                        paraPartsMakerCd.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PartsMakerCd);
                        paraPrimeDispOrder.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrimeDispOrder);
                        paraPrmSetDtlNo1.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo1);
                        paraPrmSetDtlName1.Value = SqlDataMediator.SqlSetString(prmSettingUWork.PrmSetDtlName1);
                        paraPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo2);
                        paraPrmSetDtlName2.Value = SqlDataMediator.SqlSetString(prmSettingUWork.PrmSetDtlName2);
                        if (prmSettingUWork.OfferDate == 0)
                        {
                            paraOfferDate.Value = DBNull.Value;
                        }
                        else
                        {
                            paraOfferDate.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.OfferDate);
                        }
                        paraPrmSetDtlName2ForFac.Value = SqlDataMediator.SqlSetString(prmSettingUWork.PrmSetDtlName2ForFac);
                        paraPrmSetDtlName2ForCOw.Value = SqlDataMediator.SqlSetString(prmSettingUWork.PrmSetDtlName2ForCOw);
                        if (prmSettingUWork.TbsPartsCode == 0)
                        {
                            paraPrimeDisplayCode.Value = 0;
                        }
                        else
                        {
                            paraPrimeDisplayCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrimeDisplayCode);
                        }

                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(prmSettingUWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            prmSettingUList = al;

            return status;
        }
        //----- ADD 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�------<<<<<

        /// <summary>
        /// �D�ǐݒ�}�X�^��������(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="newPrmSettingUWork">�����N���X</param>
        /// <param name="prmUWorkSearchList">�������X�g</param>
        /// <param name="prmConnection">sqlConnection</param>
        /// <returns></returns>
        /// <br>Note        : �D�ǐݒ�}�X�^��������</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/02/27</br>
        private int SearchProc(NewPrmSettingUWork newPrmSettingUWork,ref ArrayList prmUWorkSearchList, SqlConnection prmConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string command = "";

            try
            {
                command += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                command += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                command += "    ,ENTERPRISECODERF" + Environment.NewLine;
                command += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                command += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                command += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                command += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                command += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                command += "    ,SECTIONCODERF" + Environment.NewLine;
                command += "    ,GOODSMGROUPRF" + Environment.NewLine;
                command += "    ,TBSPARTSCODERF" + Environment.NewLine;
                command += "    ,TBSPARTSCDDERIVEDNORF" + Environment.NewLine;
                command += "    ,MAKERDISPORDERRF" + Environment.NewLine;
                command += "    ,PARTSMAKERCDRF" + Environment.NewLine;
                command += "    ,PRIMEDISPORDERRF" + Environment.NewLine;
                command += "    ,PRMSETDTLNO1RF" + Environment.NewLine;
                command += "    ,PRMSETDTLNAME1RF" + Environment.NewLine;
                command += "    ,PRMSETDTLNO2RF" + Environment.NewLine;
                command += "    ,PRMSETDTLNAME2RF" + Environment.NewLine;
                command += "    ,PRIMEDISPLAYCODERF" + Environment.NewLine;
                command += "    ,PRMSETDTLNAME2FORFACRF" + Environment.NewLine;
                command += "    ,PRMSETDTLNAME2FORCOWRF" + Environment.NewLine;
                command += " FROM PRMSETTINGURF WITH (READUNCOMMITTED) " + Environment.NewLine;
                command += " WHERE" + Environment.NewLine;
                command += " ENTERPRISECODERF   = @FINDENTERPRISECODE" + Environment.NewLine;
                command += " AND LOGICALDELETECODERF  = @FINDLOGICALDELETECODERF" + Environment.NewLine;
                command += " AND GOODSMGROUPRF  = @FINDGOODSMGROUPRF" + Environment.NewLine;
                command += " AND TBSPARTSCODERF = @FINDTBSPARTSCODERF" + Environment.NewLine;
                command += " AND PARTSMAKERCDRF = @FINDPARTSMAKERCDRF" + Environment.NewLine;
                command += " AND PRMSETDTLNO1RF = @FINDPRMSETDTLNO1RF" + Environment.NewLine;
                command += " AND PRMSETDTLNO2RF = @FINDOLDPRMSETDTLNO2RF" + Environment.NewLine;
                command += " ORDER BY SECTIONCODERF" + Environment.NewLine;

                sqlCommand = new SqlCommand(command, prmConnection);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODERF", SqlDbType.Int);
                SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUPRF", SqlDbType.Int);
                SqlParameter findParaTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODERF", SqlDbType.Int);
                SqlParameter findParaPartsMakerCd = sqlCommand.Parameters.Add("@FINDPARTSMAKERCDRF", SqlDbType.Int);
                SqlParameter findParaPrmSetDtlNo1 = sqlCommand.Parameters.Add("@FINDPRMSETDTLNO1RF", SqlDbType.Int);
                SqlParameter findParaOldPrmSetDtlNo2 = sqlCommand.Parameters.Add("@FINDOLDPRMSETDTLNO2RF", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(newPrmSettingUWork.EnterpriseCode);
                findParaLogicalDeleteCode.Value = 0;
                findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(newPrmSettingUWork.GoodsMGroup.Trim()));
                findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(newPrmSettingUWork.TbsPartsCode.Trim()));
                findParaPartsMakerCd.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(newPrmSettingUWork.PartsMakerCd.Trim()));
                findParaPrmSetDtlNo1.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(newPrmSettingUWork.PrmSetDtlNo1.Trim()));
                findParaOldPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(newPrmSettingUWork.PrmSetDtlNoAfterOld.Trim()));

                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInquiry);
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    prmUWorkSearchList.Add(CopyToNewPrmSettingUWork(ref myReader, newPrmSettingUWork));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (myReader.IsClosed == false) myReader.Close();
            }
            catch (SqlException)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� NewPrmSettingUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="newPrmSettingUWork">NewPrmSettingUWork</param>
        /// <returns>NewPrmSettingUWork</returns>
        /// <remarks>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/02/27</br>
        /// </remarks>
        private NewPrmSettingUWork CopyToNewPrmSettingUWork(ref SqlDataReader myReader, NewPrmSettingUWork newPrmSettingUWork)
        {
            NewPrmSettingUWork _newPrmSettingUWork = new NewPrmSettingUWork();

            #region �N���X�֊i�[
            _newPrmSettingUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            _newPrmSettingUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            _newPrmSettingUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            _newPrmSettingUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            _newPrmSettingUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            _newPrmSettingUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            _newPrmSettingUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            _newPrmSettingUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            _newPrmSettingUWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            _newPrmSettingUWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF")).ToString();
            _newPrmSettingUWork.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF")).ToString();
            _newPrmSettingUWork.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
            _newPrmSettingUWork.MakerDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERDISPORDERRF"));
            _newPrmSettingUWork.PartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF")).ToString();
            _newPrmSettingUWork.PrimeDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIMEDISPORDERRF"));
            _newPrmSettingUWork.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO1RF")).ToString();
            _newPrmSettingUWork.PrmSetDtlName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME1RF"));
            _newPrmSettingUWork.PrmSetDtlNo2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO2RF"));
            _newPrmSettingUWork.PrmSetDtlName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME2RF"));
            _newPrmSettingUWork.PrimeDisplayCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIMEDISPLAYCODERF"));
            _newPrmSettingUWork.PrmSetDtlName2ForFac = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME2FORFACRF"));
            _newPrmSettingUWork.PrmSetDtlName2ForCOw = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME2FORCOWRF"));
            _newPrmSettingUWork.PrmSetDtlNoAfterOld = newPrmSettingUWork.PrmSetDtlNoAfterOld;
            _newPrmSettingUWork.PrmSetDtlNoAfterNew = newPrmSettingUWork.PrmSetDtlNoAfterNew;
            #endregion

            return _newPrmSettingUWork;
        }
        #endregion

        #region ���[�N�̕ϊ�
        /// <summary>
        /// �N���X�i�[���� PrmSettingUWork
        /// </summary>
        /// <param name="newPrmSettingUWork1">�D�ǐݒ胏�[�N</param>
        /// <param name="prmSettingUWork">PrmSettingUWork���[�N</param>
        /// <br>Note        : �N���X�i�[���� PrmSettingUWork</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/02/27</br>
        private void ConvertToPrmSettingUWork(NewPrmSettingUWork newPrmSettingUWork1, out PrmSettingUWork prmSettingUWork)
        {
            prmSettingUWork = new PrmSettingUWork();

            prmSettingUWork.CreateDateTime = newPrmSettingUWork1.CreateDateTime;
            prmSettingUWork.UpdateDateTime = newPrmSettingUWork1.UpdateDateTime;
            prmSettingUWork.EnterpriseCode = newPrmSettingUWork1.EnterpriseCode;
            prmSettingUWork.FileHeaderGuid = newPrmSettingUWork1.FileHeaderGuid;
            prmSettingUWork.UpdEmployeeCode = newPrmSettingUWork1.UpdEmployeeCode;
            prmSettingUWork.UpdAssemblyId1 = newPrmSettingUWork1.UpdAssemblyId1;
            prmSettingUWork.UpdAssemblyId2 = newPrmSettingUWork1.UpdAssemblyId2;
            prmSettingUWork.LogicalDeleteCode = newPrmSettingUWork1.LogicalDeleteCode;
            prmSettingUWork.SectionCode = newPrmSettingUWork1.SectionCode;
            prmSettingUWork.GoodsMGroup = Convert.ToInt32(newPrmSettingUWork1.GoodsMGroup);
            prmSettingUWork.TbsPartsCode = Convert.ToInt32(newPrmSettingUWork1.TbsPartsCode);
            prmSettingUWork.TbsPartsCdDerivedNo = newPrmSettingUWork1.TbsPartsCdDerivedNo;
            prmSettingUWork.MakerDispOrder = newPrmSettingUWork1.MakerDispOrder;
            prmSettingUWork.PartsMakerCd = Convert.ToInt32(newPrmSettingUWork1.PartsMakerCd);
            prmSettingUWork.PrimeDispOrder = newPrmSettingUWork1.PrimeDispOrder;
            prmSettingUWork.PrmSetDtlNo1 = Convert.ToInt32(newPrmSettingUWork1.PrmSetDtlNo1);
            prmSettingUWork.PrmSetDtlName1 = newPrmSettingUWork1.PrmSetDtlName1;
            prmSettingUWork.PrmSetDtlNo2 = newPrmSettingUWork1.PrmSetDtlNo2;
            prmSettingUWork.PrmSetDtlName2 = newPrmSettingUWork1.PrmSetDtlName2;
            prmSettingUWork.PrimeDisplayCode = newPrmSettingUWork1.PrimeDisplayCode;
            prmSettingUWork.PrmSetDtlName2ForFac = newPrmSettingUWork1.PrmSetDtlName2ForFac;
            prmSettingUWork.PrmSetDtlName2ForCOw = newPrmSettingUWork1.PrmSetDtlName2ForCOw;
        }
        #endregion

        #endregion
    }
}
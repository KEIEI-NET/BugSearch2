//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �a�k�R�[�h�w�ʕϊ�����
// �v���O�����T�v   : �a�k�R�[�h�w�ʕϊ��������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2010/01/11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� :
// �C �� ��              �C�����e :
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Text;
using System.IO;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �a�k�R�[�h�w�ʕϊ������N���X
    /// </summary>
    /// <remarks>
    /// Note       : �a�k�R�[�h�w�ʕϊ������ł��B<br />
    /// Programmer : ������<br />
    /// Date       : 2010/01/11<br />
    /// </remarks>
    public class BlCodeLevelChangeAcs
    {
        # region �� Constructor ��
        /// <summary>
        /// �a�k�R�[�h�w�ʕϊ������A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �a�k�R�[�h�w�ʕϊ������A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        public BlCodeLevelChangeAcs()
        {
        }
        # endregion �� Constructor ��

        #region �� Const Memebers ��
        // ��ʋ@�\ID
        private const string PROGRAM_ID = "PMKHN09280UA";
        // ��ʋ@�\����
        private const string PROGRAM_NAME = "�a�k�R�[�h�w�ʕϊ�����";

        //�|���p�����[�^�t�@�C��
        private const string INI_FILE_RATE = "PMCV1200.INI";
        //�|���p�����[�^�`�Z�N�V������
        private const string INI_FILE_RATE_SECTION_A = "D3018";
        //�|���p�����[�^�a�Z�N�V������
        private const string INI_FILE_RATE_SECTION_B = "D3150";
        //�|���p�����[�^�b�Z�N�V������
        private const string INI_FILE_RATE_SECTION_C = "D3020";

        //���i�p�����[�^�t�@�C��
        private const string INI_FILE_GOODS = "PMCV1100.INI";
        //���i�p�����[�^�`�Z�N�V������
        private const string INI_FILE_GOODS_SECTION_A = "D3150";
        //���i�p�����[�^�a�Z�N�V������
        private const string INI_FILE_GOODS_SECTION_B = "D3010";
        //���i�p�����[�^�b�Z�N�V������
        private const string INI_FILE_GOODS_SECTION_C = "D3020";

        //���ʃp�����[�^�t�@�C��
        private const string INI_FILE_PARTS = "PMCV1160.INI";
        //���ʃp�����[�^�Z�N�V������
        private const string INI_FILE_PARTS_SECTION_A = "D3020";

        //�D�ǐݒ�p�����[�^�t�@�C��
        private const string INI_FILE_EXCELLENTSET = "PMCV1180.INI";
        //�D�ǐݒ�p�����[�^�`�Z�N�V������
        private const string INI_FILE_EXCELLENTSET_SECTION_A = "D3020";
        //�D�ǐݒ�p�����[�^�a�Z�N�V������
        private const string INI_FILE_EXCELLENTSET_SECTION_B = "PM8660";
        //�D�ǐݒ�p�����[�^�b�Z�N�V������
        private const string INI_FILE_EXCELLENTSET_SECTION_C = "PM0076";

        #endregion �� Const Memebers ��

        # region �� Private Members ��

        // �a�k�R�[�h�w�ʕϊ������C���^�t�F�[�X
        private IDataBLGoodsRateRankConvertDB _iDataBLGoodsRateRankConvertDB;

        # endregion �� Private Members ��

        #region �� Private Method
        #region �� �a�k�R�[�h�w�ʕϊ�����
        #region �� �a�k�R�[�h�w�ʕϊ�����
        /// <summary>
        /// �a�k�R�[�h�w�ʕϊ�����
        /// </summary>
        /// <param name="iniFilePass">INI�t�@�C���p�X</param>
        /// <param name="logFilePass">LOG�t�@�C���p�X</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        public int Update(string iniFilePass, string logFilePass, out string errMsg)
        {
            errMsg = string.Empty;
            return this.UpdateProc(iniFilePass, logFilePass, ref errMsg);
        }

        /// <summary>
        ///�a�k�R�[�h�w�ʕϊ�����
        /// </summary>
        /// <param name="iniFilePass">INI�t�@�C���p�X</param>
        /// <param name="logFilePass">LOG�t�@�C���p�X</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        private int UpdateProc(string iniFilePass, string logFilePass,  ref string errMsg)
        {
            // �S�ăe�[�u��������̏��
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            ArrayList rateFile_A = null;
            ArrayList rateFile_B = null;
            ArrayList rateFile_C = null;
            ArrayList goodsFile_A = null;
            ArrayList goodsFile_B = null;
            ArrayList goodsFile_C = null;
            ArrayList partsFile = null;
            ArrayList excellentSetFile_A = null;
            ArrayList excellentSetFile_B = null;
            ArrayList excellentSetFile_C = null;
            // INI�t�@�C���ǂݍ���
            if (!ReadIniFile(iniFilePass, out rateFile_A, out rateFile_B, out rateFile_C, out goodsFile_A, 
                out goodsFile_B, out goodsFile_C, out partsFile, out excellentSetFile_A, out excellentSetFile_B, out excellentSetFile_C))
            {
                return status;
            }
            // ���엚�����O��`
            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
            string logFileName = string.Empty;

            // �a�k�R�[�h�w�ʕϊ������C���^�t�F�[�X
            _iDataBLGoodsRateRankConvertDB = (IDataBLGoodsRateRankConvertDB)MediationDataBLGoodsRateRankConvertDB.GetDataBLGoodsRateRankConvertDB();
            object retList = null;

            // Remote:�a�k�R�[�h�w�ʕϊ�����
            try
            {
                logFileName = logFilePass + "\\LOG" + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
 + ".CSV";
                object _rateFile_AObj = rateFile_A as object;
                object _rateFile_BObj = rateFile_B as object;
                object _rateFile_CObj = rateFile_C as object;
                object _goodsFile_AObj = goodsFile_A as object;
                object _goodsFile_BObj = goodsFile_B as object;
                object _goodsFile_CObj = goodsFile_C as object;
                object _partsFileObj = partsFile as object;
                object _excellentSetFile_AObj = excellentSetFile_A as object;
                object _excellentSetFile_BObj = excellentSetFile_B as object;
                object _excellentSetFile_CObj = excellentSetFile_C as object;
                status = _iDataBLGoodsRateRankConvertDB.Update(LoginInfoAcquisition.EnterpriseCode, _rateFile_AObj, _rateFile_BObj, _rateFile_CObj, _goodsFile_AObj, _goodsFile_BObj, _goodsFile_CObj, _partsFileObj, _excellentSetFile_AObj, _excellentSetFile_BObj, _excellentSetFile_CObj, out retList, out errMsg);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // ���엚�����O�̏�������
                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "����I�����܂����B", string.Empty);
                    // �������O�t�@�C���̏�������
                    ArrayList al = retList as ArrayList;
                    if (al == null)
                    {
                        al = new ArrayList();
                    }
                    if (al.Count > 0)
                    {
                        WriteCSV(al, false, logFileName);
                    }
                }
                else
                {
                    // ���엚�����O�̏�������
                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "�G���[���������܂����B(" + status.ToString() + ")", string.Empty);
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message.ToString();
            }
            return status;
        }
        #endregion

        #region �� INI�t�@�C���ǂݍ��ݏ���
        /// <summary>
        ///INI�t�@�C���ǂݍ���
        /// </summary>
        /// <param name="iniFilePass">INI�t�@�C���p�X</param>
        /// <param name="excellentSetFile_A">�D�ǐݒ�p�����[�^���X�g�`</param>
        /// <param name="excellentSetFile_B">�D�ǐݒ�p�����[�^���X�g�a</param>
        /// <param name="excellentSetFile_C">�D�ǐݒ�p�����[�^���X�g�b</param>
        /// <param name="goodsFile_A">���i�p�����[�^���X�g�`</param>
        /// <param name="goodsFile_B">���i�p�����[�^���X�g�a</param>
        /// <param name="goodsFile_C">���i�p�����[�^���X�g�b</param>
        /// <param name="partsFile">���ʃp�����[�^�̃��X�g</param>
        /// <param name="rateFile_A">�|���p�����[�^���X�g�`</param>
        /// <param name="rateFile_B">�|���p�����[�^���X�g�a</param>
        /// <param name="rateFile_C">�|���p�����[�^���X�g�b</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : INI�t�@�C���ǂݍ��݂��s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        private bool ReadIniFile(string  iniFilePass, out ArrayList rateFile_A, out ArrayList rateFile_B, out ArrayList rateFile_C, out ArrayList goodsFile_A,
            out ArrayList goodsFile_B, out ArrayList goodsFile_C, out ArrayList partsFile, out ArrayList excellentSetFile_A, out ArrayList excellentSetFile_B, out ArrayList excellentSetFile_C)
        {
            //�|���p�����[�^�`�A�a�A�b�̊e���X�g
            rateFile_A = new ArrayList();
            rateFile_B = new ArrayList();
            rateFile_C = new ArrayList();
            //���i�p�����[�^�`�A�a�A�b�̊e���X�g
            goodsFile_A = new ArrayList();
            goodsFile_B = new ArrayList();
            goodsFile_C = new ArrayList();
            //���ʃp�����[�^�̃��X�g
            partsFile = new ArrayList();
            //�D�ǐݒ�p�����[�^�`�A�a�A�b�̊e���X�g
            excellentSetFile_A = new ArrayList();
            excellentSetFile_B = new ArrayList();
            excellentSetFile_C = new ArrayList();
            string iniRateFile = iniFilePass + "\\" + INI_FILE_RATE;
            string iniGoodsFilee = iniFilePass + "\\" + INI_FILE_GOODS;
            string iniPartsFile = iniFilePass + "\\" + INI_FILE_PARTS;
            string iniExcellentSetFile = iniFilePass + "\\" + INI_FILE_EXCELLENTSET;

            bool status = true;
            // �|���p�����[�^�ǂ�
            if (!ReadRateParamFile(iniRateFile, ref rateFile_A, ref rateFile_B, ref rateFile_C))
            {
                status = false;
                return false;
            }
            //���i�p�����[�^�ǂ�
            else if (!ReadGoodsParamFile(iniGoodsFilee, ref goodsFile_A, ref goodsFile_B, ref goodsFile_C))
            {
                status = false;
                return false;
            }
            //���ʃp�����[�^�ǂ�
            else if (!ReadPartsParamFile(iniPartsFile, ref partsFile))
            {
                status = false;
                return false;
            }
            //�D�ǐݒ�p�����[�^�ǂ�
            else if (!ReadExcellentSetParamFile(iniExcellentSetFile, ref excellentSetFile_A, ref excellentSetFile_B, ref excellentSetFile_C))
            {
                status = false;
                return false;
            }
            return status;
        }

        /// <summary>
        ///INI�t�@�C���ǂݍ���
        /// </summary>
        /// <param name="file">INI�t�@�C���p�X</param>
        /// <param name="file_A">�|���p�����[�^���X�g�`</param>
        /// <param name="file_B">�|���p�����[�^���X�g�a</param>
        /// <param name="file_C">�|���p�����[�^���X�g�b</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : INI�t�@�C���ǂݍ��݂��s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        private bool ReadRateParamFile(string file, ref ArrayList file_A, ref ArrayList file_B, ref ArrayList file_C)
        {
            bool status = true;
            StreamReader sr = null;
            string line = string.Empty;
            string tempSection = string.Empty;
            string errMess = string.Empty;
            // VALUE���X�g
            ArrayList valueList = new ArrayList();
            try
            {
                sr = new StreamReader(file, Encoding.Default);
                line = sr.ReadLine();
                //INI�t�@�C���ǂݍ���
                while (null != line)
                {
                    //���p�Z�~�R����(;)�ȍ~�͖�������
                    if (line.Equals("") || line.Contains(";"))
                    {
                        line = sr.ReadLine();
                        continue;
                    }
                    else if (line.Trim().Contains("[") && line.Trim().Contains("]") && line.Contains(INI_FILE_RATE_SECTION_A))
                    {
                        //�|���p�����[�^�`
                        tempSection = INI_FILE_RATE_SECTION_A;
                        file_A.Clear();
                        line = sr.ReadLine();
                        continue;
                    }
                    else if (line.Trim().Contains("[") && line.Trim().Contains("]") && line.Contains(INI_FILE_RATE_SECTION_B))
                    {
                        //�|���p�����[�^�a
                        tempSection = INI_FILE_RATE_SECTION_B;
                        file_B.Clear();
                        line = sr.ReadLine();
                        continue;
                    }
                    else if (line.Trim().Contains("[") && line.Trim().Contains("]") && line.Contains(INI_FILE_RATE_SECTION_C))
                    {
                        //�|���p�����[�^�b
                        tempSection = INI_FILE_RATE_SECTION_C;
                        file_C.Clear();
                        line = sr.ReadLine();
                        continue;
                    }
                    // �|���p�����[�^�`�A�a�A�b�ȊO�̏���
                    else if (line.Trim().Contains("[") && line.Trim().Contains("]"))
                    {
                        tempSection = "other";
                        line = sr.ReadLine();
                        continue;
                    }
                    //�|���p�����[�^�`�̓ǂ�
                    if (tempSection == INI_FILE_RATE_SECTION_A)
                    {
                        ReadRateParamAFile(line, ref file_A, tempSection);
                    }
                    //�|���p�����[�^�a�̓ǂ�
                    if (tempSection == INI_FILE_RATE_SECTION_B)
                    {
                        ReadRateParamBFile(line, ref file_B, tempSection);
                    }
                    //�|���p�����[�^�b�̓ǂ�
                    if (tempSection == INI_FILE_RATE_SECTION_C)
                    {
                        ReadRateParamCFile(line, ref file_C, tempSection);
                    }
                    line = sr.ReadLine();
                }
            }
            catch (Exception e)
            {
                errMess = e.Message.ToString();
                status = false;
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();

                }
            }
            return status;
        }

        /// <summary>
        ///INI�t�@�C���ǂݍ���
        /// </summary>
        /// <param name="file">INI�t�@�C���p�X</param>
        /// <param name="file_A">���i�p�����[�^���X�g�`</param>
        /// <param name="file_B">���i�p�����[�^���X�g�a</param>
        /// <param name="file_C">���i�p�����[�^���X�g�b</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : INI�t�@�C���ǂݍ��݂��s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        private bool ReadGoodsParamFile(string file, ref ArrayList file_A, ref ArrayList file_B, ref ArrayList file_C)
        {
            bool status = true;
            StreamReader sr = null;
            string line = string.Empty;
            string tempSection = string.Empty;
            string errMess = string.Empty;
            // VALUE���X�g
            ArrayList valueList = new ArrayList();
            try
            {
                sr = new StreamReader(file, Encoding.Default);
                line = sr.ReadLine();
                //INI�t�@�C���ǂݍ���
                while (null != line)
                {
                    //���p�Z�~�R����(;)�ȍ~�͖�������
                    if (line.Equals("") || line.Contains(";"))
                    {
                        line = sr.ReadLine();
                        continue;
                    }
                    else if (line.Trim().Contains("[") && line.Trim().Contains("]") && line.Contains(INI_FILE_GOODS_SECTION_A))
                    {
                        //���i�p�����[�^�`
                        tempSection = INI_FILE_GOODS_SECTION_A;
                        file_A.Clear();
                        line = sr.ReadLine();
                        continue;
                    }
                    else if (line.Trim().Contains("[") && line.Trim().Contains("]") && line.Contains(INI_FILE_GOODS_SECTION_B))
                    {
                        //���i�p�����[�^�a
                        tempSection = INI_FILE_GOODS_SECTION_B;
                        file_B.Clear();
                        line = sr.ReadLine();
                        continue;
                    }
                    else if (line.Trim().Contains("[") && line.Trim().Contains("]") && line.Contains(INI_FILE_GOODS_SECTION_C))
                    {
                        //���i�p�����[�^�b
                        tempSection = INI_FILE_GOODS_SECTION_C;
                        file_C.Clear();
                        line = sr.ReadLine();
                        continue;
                    }
                    // ���i�p�����[�^�`�A�a�A�b�ȊO�̏���
                    else if (line.Trim().Contains("[") && line.Trim().Contains("]"))
                    {
                        tempSection = "other";
                        line = sr.ReadLine();
                        continue;
                    }
                    //���i�p�����[�^�`�̓ǂ�
                    if (tempSection == INI_FILE_GOODS_SECTION_A)
                    {
                        ReadGoodsParamAFile(line, ref file_A, tempSection);
                    }
                    //���i�p�����[�^�a�̓ǂ�
                    if (tempSection == INI_FILE_GOODS_SECTION_B)
                    {
                        ReadGoodsParamBFile(line, ref file_B, tempSection);
                    }
                    //���i�p�����[�^�b�̓ǂ�
                    if (tempSection == INI_FILE_GOODS_SECTION_C)
                    {
                        ReadGoodsParamCFile(line, ref file_C, tempSection);
                    }
                    line = sr.ReadLine();
                }
            }
            catch (Exception e)
            {
                errMess = e.Message.ToString();
                status = false;
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();

                }
            }
            return status;
        }

        /// <summary>
        ///INI�t�@�C���ǂݍ���
        /// </summary>
        /// <param name="file">INI�t�@�C���p�X</param>
        /// <param name="al">���ʃp�����[�^���X�g</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : INI�t�@�C���ǂݍ��݂��s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        private bool ReadPartsParamFile(string file, ref ArrayList al)
        {
            bool status = true;
            StreamReader sr = null;
            string line = string.Empty;
            string tempSection = string.Empty;
            string errMess = string.Empty;
            // VALUE���X�g
            ArrayList valueList = new ArrayList();
            try
            {
                sr = new StreamReader(file, Encoding.Default);
                line = sr.ReadLine();
                //INI�t�@�C���ǂݍ���
                while (null != line)
                {
                    //���p�Z�~�R����(;)�ȍ~�͖�������
                    if (line.Equals("") || line.Contains(";"))
                    {
                        line = sr.ReadLine();
                        continue;
                    }
                    else if (line.Trim().Contains("[") && line.Trim().Contains("]") && line.Contains(INI_FILE_PARTS_SECTION_A))
                    {
                        //���ʃp�����[�^
                        tempSection = INI_FILE_PARTS_SECTION_A;
                        al.Clear();
                        line = sr.ReadLine();
                        continue;
                    }
                    // ���ʃp�����[�^�ȊO�̏���
                    else if (line.Trim().Contains("[") && line.Trim().Contains("]"))
                    {
                        tempSection = "other";
                        line = sr.ReadLine();
                        continue;
                    }
                    //���ʃp�����[�^�̓ǂ�
                    if (tempSection == INI_FILE_PARTS_SECTION_A)
                    {
                        ReadPartsParamFile(line, ref al, tempSection);
                    }
                    line = sr.ReadLine();
                }
            }
            catch (Exception e)
            {
                errMess = e.Message.ToString();
                status = false;
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();

                }
            }
            return status;
        }

        /// <summary>
        ///INI�t�@�C���ǂݍ���
        /// </summary>
        /// <param name="file">INI�t�@�C���p�X</param>
        /// <param name="file_A">�D�ǐݒ�p�����[�^���X�g�`</param>
        /// <param name="file_B">�D�ǐݒ�p�����[�^���X�g�a</param>
        /// <param name="file_C">�D�ǐݒ�p�����[�^���X�g�b</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : INI�t�@�C���ǂݍ��݂��s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        private bool ReadExcellentSetParamFile(string file, ref ArrayList file_A, ref ArrayList file_B, ref ArrayList file_C)
        {
            bool status = true;
            StreamReader sr = null;
            string line = string.Empty;
            string tempSection = string.Empty;
            string errMess = string.Empty;
            // VALUE���X�g
            ArrayList valueList = new ArrayList();
            try
            {
                sr = new StreamReader(file, Encoding.Default);
                line = sr.ReadLine();
                //INI�t�@�C���ǂݍ���
                while (null != line)
                {
                    //���p�Z�~�R����(;)�ȍ~�͖�������
                    if (line.Equals("") || line.Contains(";"))
                    {
                        line = sr.ReadLine();
                        continue;
                    }
                    else if (line.Trim().Contains("[") && line.Trim().Contains("]") && line.Contains(INI_FILE_EXCELLENTSET_SECTION_A))
                    {
                        //�D�ǐݒ�p�����[�^�`
                        tempSection = INI_FILE_EXCELLENTSET_SECTION_A;
                        file_A.Clear();
                        line = sr.ReadLine();
                        continue;
                    }
                    else if (line.Trim().Contains("[") && line.Trim().Contains("]") && line.Contains(INI_FILE_EXCELLENTSET_SECTION_B))
                    {
                        //�D�ǐݒ�p�����[�^�a
                        tempSection = INI_FILE_EXCELLENTSET_SECTION_B;
                        file_B.Clear();
                        line = sr.ReadLine();
                        continue;
                    }
                    else if (line.Trim().Contains("[") && line.Trim().Contains("]") && line.Contains(INI_FILE_EXCELLENTSET_SECTION_C))
                    {
                        //�D�ǐݒ�p�����[�^�b
                        tempSection = INI_FILE_EXCELLENTSET_SECTION_C;
                        file_C.Clear();
                        line = sr.ReadLine();
                        continue;
                    }
                    // �D�ǐݒ�p�����[�^�ȊO�̏���
                    else if (line.Trim().Contains("[") && line.Trim().Contains("]"))
                    {
                        tempSection = "other";
                        line = sr.ReadLine();
                        continue;
                    }
                    //�D�ǐݒ�p�����[�^�`�̓ǂ�
                    if (tempSection == INI_FILE_EXCELLENTSET_SECTION_A)
                    {
                        ReadExcellentSetParamAFile(line, ref file_A, tempSection);
                    }
                    //�D�ǐݒ�p�����[�^�a�̓ǂ�
                    if (tempSection == INI_FILE_EXCELLENTSET_SECTION_B)
                    {
                        ReadExcellentSetParamBFile(line, ref file_B, tempSection);
                    }
                    //�D�ǐݒ�p�����[�^�b�̓ǂ�
                    if (tempSection == INI_FILE_EXCELLENTSET_SECTION_C)
                    {
                        ReadExcellentSetParamCFile(line, ref file_C, tempSection);
                    }
                    line = sr.ReadLine();
                }
            }
            catch (Exception e)
            {
                errMess = e.Message.ToString();
                status = false;
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();

                }
            }
            return status;
        }

        /// <summary>
        ///�|���p�����[�^�`�ǂݍ���
        /// </summary>
        /// <param name="line">��s</param>
        /// <param name="file_A">�|���p�����[�^�`���X�g</param>
        /// <param name="tempSection">�Z�N�V������</param>
        /// <remarks>
        /// <br>Note       : �|���p�����[�^�`�ǂݍ��݂��s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        private void ReadRateParamAFile(string line, ref ArrayList file_A, string tempSection)
        {
            //�e�s�ŁA���p�C�R�[��(=)�̍���(KEY)�ƉE��(VALUE)�ɕ�����
            string[] tempLine = line.Split('=');
            if (tempLine != null && tempLine.Length > 0 && tempLine.Length == 2)
            {
                RateParaAWork work = new RateParaAWork();
                work.FileName = INI_FILE_RATE;
                work.SectionName = tempSection;
                //�ϊ��OBL����
                work.BeforeBlCd = tempLine[0].PadLeft(5, '0').Trim();
                string[] tempList = tempLine[1].Split(',');
                if (tempList != null && tempList.Length > 0)
                {
                    ArrayList al = new ArrayList();
                    foreach (string str in tempList)
                    {
                        al.Add(str.PadLeft(4, '0').Trim());
                    }
                    //Ұ������ؽ�
                    work.MakerList = al;
                }
                file_A.Add(work);
            }
        }

        /// <summary>
        ///�|���p�����[�^�a�ǂݍ���
        /// </summary>
        /// <param name="line">��s</param>
        /// <param name="file_B">�|���p�����[�^�a���X�g</param>
        /// <param name="tempSection">�Z�N�V������</param>
        /// <remarks>
        /// <br>Note       : �|���p�����[�^�a�ǂݍ��݂��s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        private void ReadRateParamBFile(string line, ref ArrayList file_B, string tempSection)
        {
            //�e�s�ŁA���p�C�R�[��(=)�̍���(KEY)�ƉE��(VALUE)�ɕ�����
            string[] tempLine = line.Split('=');
            if (tempLine != null && tempLine.Length > 0 && tempLine.Length == 2)
            {
                RateParaBWork work = new RateParaBWork();
                work.FileName = INI_FILE_RATE;
                work.SectionName = tempSection;
                string[] tempList1 = tempLine[0].Split(',');
                if (tempList1 != null && tempList1.Length > 0 && tempList1.Length == 2)
                {
                    work.MakerCd = tempList1[0].PadLeft(4, '0').Trim();
                    work.BeforeBlCd = tempList1[1].PadLeft(5, '0').Trim();
                }
                string[] tempList2 = tempLine[1].Split(',');
                if (tempList2 != null && tempList2.Length >= 1)
                {
                    work.AfterBlCd = tempList2[0].PadLeft(5, '0').Trim();
                    if (tempList2.Length > 1)
                    {
                        ArrayList al = new ArrayList();
                        for (int i = 1; i < tempList2.Length; i++)
                        {
                            al.Add(tempList2[i].Trim());
                        }
                        work.LevelList = al;
                    }
                }
                file_B.Add(work);
            }
        }

        /// <summary>
        ///�|���p�����[�^�b�ǂݍ���
        /// </summary>
        /// <param name="line">��s</param>
        /// <param name="file_C">�|���p�����[�^�b���X�g</param>
        /// <param name="tempSection">�Z�N�V������</param>
        /// <remarks>
        /// <br>Note       : �|���p�����[�^�b�ǂݍ��݂��s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        private void ReadRateParamCFile(string line, ref ArrayList file_C, string tempSection)
        {
            //�e�s�ŁA���p�C�R�[��(=)�̍���(KEY)�ƉE��(VALUE)�ɕ�����
            string[] tempLine = line.Split('=');
            if (tempLine != null && tempLine.Length > 0 && tempLine.Length == 2)
            {
                RateParaCWork work = new RateParaCWork();
                work.FileName = INI_FILE_RATE;
                work.SectionName = tempSection;
                string[] tempList1 = tempLine[0].Split(',');
                if (tempList1 != null && tempList1.Length > 0 && tempList1.Length == 2)
                {
                    work.MakerCd = tempList1[0].PadLeft(4, '0').Trim();
                    work.BeforeBlCd = tempList1[1].PadLeft(5, '0').Trim();
                }
                string[] tempList2 = tempLine[1].Split(',');
                if (tempList2 != null && tempList2.Length > 0)
                {
                    ArrayList al = new ArrayList();
                    foreach (string str in tempList2)
                    {
                        al.Add(str.PadLeft(5, '0').Trim());
                    }
                    work.AfterBlList = al;
                }
                file_C.Add(work);
            }
        }

        /// <summary>
        ///���i�p�����[�^�`�ǂݍ���
        /// </summary>
        /// <param name="line">��s</param>
        /// <param name="file_A">���i�p�����[�^�`���X�g</param>
        /// <param name="tempSection">�Z�N�V������</param>
        /// <remarks>
        /// <br>Note       : ���i�p�����[�^�`�ǂݍ��݂��s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        private void ReadGoodsParamAFile(string line, ref ArrayList file_A, string tempSection)
        {
            //�e�s�ŁA���p�C�R�[��(=)�̍���(KEY)�ƉE��(VALUE)�ɕ�����
            string[] tempLine = line.Split('=');
            if (tempLine != null && tempLine.Length > 0 && tempLine.Length == 2)
            {
                GoodsParaAWork work = new GoodsParaAWork();
                work.FileName = INI_FILE_GOODS;
                work.SectionName = tempSection;
                string[] tempList1 = tempLine[0].Split(',');
                if (tempList1 != null && tempList1.Length > 0 && tempList1.Length == 3)
                {
                    work.MakerCd = tempList1[0].PadLeft(4, '0').Trim();
                    work.BeforeBlCd = tempList1[1].PadLeft(5, '0').Trim();
                    work.TopGoodsNo = tempList1[2].Trim();
                }
                string[] tempList2 = tempLine[1].Split(',');
                if (tempList2 != null && tempList2.Length > 0 && tempList2.Length == 1)
                {
                    work.AfterLevel = tempList2[0].Trim();
                }
                file_A.Add(work);
            }
        }

        /// <summary>
        ///���i�p�����[�^�a�ǂݍ���
        /// </summary>
        /// <param name="line">��s</param>
        /// <param name="file_B">���i�p�����[�^�a���X�g</param>
        /// <param name="tempSection">�Z�N�V������</param>
        /// <remarks>
        /// <br>Note       : ���i�p�����[�^�a�ǂݍ��݂��s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        private void ReadGoodsParamBFile(string line, ref ArrayList file_B, string tempSection)
        {
            //�e�s�ŁA���p�C�R�[��(=)�̍���(KEY)�ƉE��(VALUE)�ɕ�����
            string[] tempLine = line.Split('=');
            if (tempLine != null && tempLine.Length > 0 && tempLine.Length == 2)
            {
                GoodsParaBWork work = new GoodsParaBWork();
                work.FileName = INI_FILE_GOODS;
                work.SectionName = tempSection;
                string[] tempList1 = tempLine[0].Split(',');
                if (tempList1 != null && tempList1.Length > 0 && tempList1.Length == 2)
                {
                    work.MakerCd = tempList1[0].PadLeft(4, '0').Trim();
                    work.halfGoodsNp = tempList1[1].Trim();
                }
                string[] tempList2 = tempLine[1].Split(',');
                if (tempList2 != null && tempList2.Length > 0 && tempList2.Length == 1)
                {
                    work.AfterBlCd = tempList2[0].PadLeft(5, '0').Trim();
                }
                file_B.Add(work);
            }
        }

        /// <summary>
        ///���i�p�����[�^�b�ǂݍ���
        /// </summary>
        /// <param name="line">��s</param>
        /// <param name="file_C">���i�p�����[�^�b���X�g</param>
        /// <param name="tempSection">�Z�N�V������</param>
        /// <remarks>
        /// <br>Note       : ���i�p�����[�^�b�ǂݍ��݂��s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        private void ReadGoodsParamCFile(string line, ref ArrayList file_C, string tempSection)
        {
            //�e�s�ŁA���p�C�R�[��(=)�̍���(KEY)�ƉE��(VALUE)�ɕ�����
            string[] tempLine = line.Split('=');
            if (tempLine != null && tempLine.Length > 0 && tempLine.Length == 2)
            {
                GoodsParaCWork work = new GoodsParaCWork();
                work.FileName = INI_FILE_GOODS;
                work.SectionName = tempSection;
                string[] tempList1 = tempLine[0].Split(',');
                if (tempList1 != null && tempList1.Length > 0 && tempList1.Length == 2)
                {
                    work.MakerCd = tempList1[0].PadLeft(4, '0').Trim();
                    work.BeforeBlCd = tempList1[1].PadLeft(5, '0').Trim();
                }
                string[] tempList2 = tempLine[1].Split(',');
                if (tempList2 != null && tempList2.Length > 0 && tempList2.Length == 1)
                {
                    work.AfterBlCd = tempList2[0].PadLeft(5, '0').Trim();
                }
                file_C.Add(work);
            }
        }

        /// <summary>
        ///���ʃp�����[�^�ǂݍ���
        /// </summary>
        /// <param name="line">��s</param>
        /// <param name="file">���ʃp�����[�^���X�g</param>
        /// <param name="tempSection">�Z�N�V������</param>
        /// <remarks>
        /// <br>Note       : ���ʃp�����[�^�ǂݍ��݂��s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        private void ReadPartsParamFile(string line, ref ArrayList file, string tempSection)
        {
            //�e�s�ŁA���p�C�R�[��(=)�̍���(KEY)�ƉE��(VALUE)�ɕ�����
            string[] tempLine = line.Split('=');
            if (tempLine != null && tempLine.Length > 0 && tempLine.Length == 2)
            {
                PartsParaWork work = new PartsParaWork();
                work.FileName = INI_FILE_PARTS;
                work.SectionName = tempSection;
                string[] tempList1 = tempLine[0].Split(',');
                if (tempList1 != null && tempList1.Length > 0 && tempList1.Length == 1)
                {
                    work.BeforeBlCd = tempList1[0].PadLeft(5, '0').Trim();
                }
                string[] tempList2 = tempLine[1].Split(',');
                if (tempList2 != null && tempList2.Length > 0 && tempList1.Length == 1)
                {
                    work.AfterBlCd = tempList2[0].PadLeft(5, '0').Trim();
                }
                file.Add(work);
            }
        }

        /// <summary>
        ///�D�ǐݒ�p�����[�^�`�ǂݍ���
        /// </summary>
        /// <param name="line">��s</param>
        /// <param name="file_A">�D�ǐݒ�p�����[�^�`���X�g</param>
        /// <param name="tempSection">�Z�N�V������</param>
        /// <remarks>
        /// <br>Note       : �D�ǐݒ�p�����[�^�`�ǂݍ��݂��s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        private void ReadExcellentSetParamAFile(string line, ref ArrayList file_A, string tempSection)
        {
            //�e�s�ŁA���p�C�R�[��(=)�̍���(KEY)�ƉE��(VALUE)�ɕ�����
            string[] tempLine = line.Split('=');
            if (tempLine != null && tempLine.Length > 0 && tempLine.Length == 2)
            {
                ExcellentSetParaAWork work = new ExcellentSetParaAWork();
                work.FileName = INI_FILE_EXCELLENTSET;
                work.SectionName = tempSection;
                string[] tempList1 = tempLine[0].Split(',');
                if (tempList1 != null && tempList1.Length > 0 && tempList1.Length == 3)
                {
                    work.MakerCd = tempList1[0].PadLeft(4, '0').Trim();
                    work.BeforeBlCd = tempList1[1].PadLeft(5, '0').Trim();
                    work.BeforeSelectCd = tempList1[2].PadLeft(4, '0').Trim();
                }
                string[] tempList2 = tempLine[1].Split(',');
                if (tempList2 != null && tempList2.Length > 0 && tempList2.Length == 1)
                {
                    work.AfterBlCd = tempList2[0].PadLeft(5, '0').Trim();
                }
                file_A.Add(work);
            }
        }

        /// <summary>
        ///�D�ǐݒ�p�����[�^�a�ǂݍ���
        /// </summary>
        /// <param name="line">��s</param>
        /// <param name="file_B">�D�ǐݒ�p�����[�^�a���X�g</param>
        /// <param name="tempSection">�Z�N�V������</param>
        /// <remarks>
        /// <br>Note       : �D�ǐݒ�p�����[�^�a�ǂݍ��݂��s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        private void ReadExcellentSetParamBFile(string line, ref ArrayList file_B, string tempSection)
        {
            //�e�s�ŁA���p�C�R�[��(=)�̍���(KEY)�ƉE��(VALUE)�ɕ�����
            string[] tempLine = line.Split('=');
            if (tempLine != null && tempLine.Length > 0 && tempLine.Length == 2)
            {
                ExcellentSetParaBWork work = new ExcellentSetParaBWork();
                work.FileName = INI_FILE_EXCELLENTSET;
                work.SectionName = tempSection;
                string[] tempList1 = tempLine[0].Split(',');
                if (tempList1 != null && tempList1.Length > 0 && tempList1.Length == 3)
                {
                    work.MakerCd = tempList1[0].PadLeft(4, '0').Trim();
                    work.BeforeBlCd = tempList1[1].PadLeft(5, '0').Trim();
                    work.BeforeSelectCd = tempList1[2].PadLeft(4, '0').Trim();
                }
                string[] tempList2 = tempLine[1].Split(',');
                if (tempList2 != null && tempList2.Length > 0 && tempList2.Length == 1)
                {
                    work.AfterSelectCd = tempList2[0].PadLeft(4, '0').Trim();
                }
                file_B.Add(work);
            }
         }

        /// <summary>
        ///�D�ǐݒ�p�����[�^�b�ǂݍ���
        /// </summary>
        /// <param name="line">��s</param>
        /// <param name="file_C">�D�ǐݒ�p�����[�^�b���X�g</param>
        /// <param name="tempSection">�Z�N�V������</param>
        /// <remarks>
        /// <br>Note       : �D�ǐݒ�p�����[�^�b�ǂݍ��݂��s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        private void ReadExcellentSetParamCFile(string line, ref ArrayList file_C, string tempSection)
        {
            //�e�s�ŁA���p�C�R�[��(=)�̍���(KEY)�ƉE��(VALUE)�ɕ�����
            string[] tempLine = line.Split('=');
            if (tempLine != null && tempLine.Length > 0 && tempLine.Length == 2)
            {
                ExcellentSetParaCWork work = new ExcellentSetParaCWork();
                work.FileName = INI_FILE_EXCELLENTSET;
                work.SectionName = tempSection;
                string[] tempList1 = tempLine[0].Split(',');
                if (tempList1 != null && tempList1.Length > 0 && tempList1.Length == 4)
                {
                    work.MakerCd = tempList1[0].PadLeft(4, '0').Trim();
                    work.BeforeBlCd = tempList1[1].PadLeft(5, '0').Trim();
                    work.BeforeSelectCd = tempList1[2].PadLeft(4, '0').Trim();
                    work.BeforeKindCd = tempList1[3].PadLeft(4, '0').Trim();
                }
                string[] tempList2 = tempLine[1].Split(',');
                if (tempList2 != null && tempList2.Length > 0 && tempList2.Length == 1)
                {
                    work.AfterKindCd = tempList2[0].PadLeft(4, '0').Trim();
                }
                file_C.Add(work);
            }
        }
        #endregion

        #region �� �������O�t�@�C���̏�������
        /// <summary>
        /// �������O�t�@�C���̏�������
        /// </summary>
        /// <param name="list">���ʃ��X�g</param>
        /// <param name="append">append</param>
        /// <param name="file">file</param>
        /// <remarks>
        /// <br>Note       : �������ʃ��X�g�f�[�^�̕ϊ����s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        private void WriteCSV(ArrayList list, bool append, string file)
        {
            StreamWriter fileWriter = null;
            try
            {
                fileWriter = new StreamWriter(file, append, Encoding.Default);
                // �������O�t�@�C���̏�������
                foreach( ResultListWork work in list)
                {
                    fileWriter.WriteLine(work.TableName + "," + work.Key + "," + work.Content + "," + work.Status);
                }
                fileWriter.Flush();
            }
            finally
            {
                if (fileWriter != null)
                {
                    fileWriter.Close();
                }
            }
        }
        #endregion
        #endregion �� �a�k�R�[�h�w�ʕϊ�����
        #endregion �� Private Method
    }
}

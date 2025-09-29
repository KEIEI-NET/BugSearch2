using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using Broadleaf.Application.UIData;
//using Broadleaf.Application.UIData.UserDB;

#if DEBUG
//using SCMAcOdrData = Broadleaf.Application.UIData.StubDB.SCMAcOdrData;
//using SCMAcOdrDtlIq = Broadleaf.Application.UIData.StubDB.SCMAcOdrDtlIq;
//using SCMAcOdrDtlAs = Broadleaf.Application.UIData.StubDB.SCMAcOdrDtlAs;
//using SCMAcOdrDtCar = Broadleaf.Application.UIData.StubDB.SCMAcOdrDtCar;
using SCMAcOdrData = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDataWork;
using SCMAcOdrDtlIq = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtlIqWork;
using SCMAcOdrDtlAs = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtlAsWork;
using SCMAcOdrDtCar = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtCarWork;

#else
using SCMAcOdrData = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDataWork;
using SCMAcOdrDtlIq = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtlIqWork;
using SCMAcOdrDtlAs = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtlAsWork;
using SCMAcOdrDtCar = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtCarWork;
#endif

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// ���V�X�e���A�g�pCSV�t�@�C���o�̓N���X
    /// </summary>
    public static class CSVWriter
    {
        #region private�萔
        private const string CT_HeaderFileName  = "ScmOdrDataCSV";  // "SCM�󒍃f�[�^.csv";
        private const string CT_CarFileName = "ScmOdDtCarCSV";      // "SCM�󒍃f�[�^�i�ԗ����j.csv";
        private const string CT_DetailFileName  = "ScmOdDtInqCSV";  // "SCM�󒍖��׃f�[�^�i�⍇���E�����j.csv";
        #endregion

        /// <summary>
        /// CSV�o�͏���
        /// </summary>
        /// <param name="pMsg"></param>
        public static int CSVWrite(string enterPriseCd, string oldSysCoopFolder,
            List<List<string>> headerList, List<List<string>> detailList, List<List<string>> carList)
        {
            if (headerList == null
                || headerList.Count == 0)
            {
                return (int)Result.Code.Normal;
            }

            if (oldSysCoopFolder == string.Empty)
            {
                LogWriter.LogWrite("���V�X�e���A�g�t�H���_���ݒ肳��Ă��܂���B");
                return (int)Result.Code.Error;
            }
            else
            {
                // ��M�p�t�H���_�p�X��ݒ�
                oldSysCoopFolder = SCMConfig.GetSCMReceivedDataPath(oldSysCoopFolder);
            }

            // CSV�o�͐��␳
            if (!oldSysCoopFolder.EndsWith("\\")
                && !oldSysCoopFolder.EndsWith("/"))
            {
                oldSysCoopFolder += "\\";
            }
            LogWriter.WriteDebugLog("CSVWriter.CSVWrite()", "CSV�o�͏�����..." + oldSysCoopFolder);

            // �t�@�C�����쐬 (��ƃR�[�h + ����)
            string fileNameWithExtension = enterPriseCd
                            + "_"
                            + DateTime.Now.ToString("yyyyMMddHHmmss")
                            //+ "_";
                            +".csv";

            try
            {
                // CSV�o��
                LogWriter.WriteDebugLog("CSVWriter.CSVWrite()", "�w�b�_�o�͏�����..." + headerList.Count.ToString() + " ��");
                OutputCSVFile(oldSysCoopFolder, CT_HeaderFileName + "_" + fileNameWithExtension, headerList);

                LogWriter.WriteDebugLog("CSVWriter.CSVWrite()", "���׏o�͏�����..." + detailList.Count.ToString() + " ��");
                OutputCSVFile(oldSysCoopFolder, CT_DetailFileName + "_" + fileNameWithExtension, detailList);

                LogWriter.WriteDebugLog("CSVWriter.CSVWrite()", "�ԗ��o�͏�����..." + carList.Count.ToString() + " ��");
                OutputCSVFile(oldSysCoopFolder, CT_CarFileName + "_" + fileNameWithExtension, carList);
            }
            catch(Exception e)
            {
                LogWriter.LogWrite("CSV�o�͏����ŃG���[���������܂����B");
                LogWriter.LogWrite(e.Message);

                return (int)Result.Code.Error;
            }

            return (int)Result.Code.Normal;
        }

        /// <summary>
        /// SCM�󔭒��f�[�^(�⍇���E��)��CSV�o�͏���
        /// </summary>
        /// <param name="oldSysCoopFolder"></param>
        /// <param name="baseFileName"></param>
        /// <param name="scmAcOdrDataList"></param>
        private static void OutputCSVFile(string oldSysCoopFolder, string baseFileName, List<List<string>> outputList)
        {
            FileStream _fs; // �t�@�C���X�g���[��
            StreamWriter _sw; // �X�g���[��writer

            string filePath = oldSysCoopFolder + baseFileName;

            Directory.CreateDirectory(oldSysCoopFolder);
            _fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
            _sw = new StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));

            try
            {
                // 1�s�f�[�^
                StringBuilder outputStrSB = new StringBuilder();

                // �󒍃f�[�^��1�s�f�[�^�쐬
                foreach (List<string> oneLineStr in outputList)
                {
                    //MakeSCMAcOdrDataStr(outputSCMAcOdrData, ref outputStrSB);
                    foreach (string oneColumn in oneLineStr)
                    {
                        AppendString(oneColumn, ref outputStrSB);
                    }

                    // �Ō�̃_�u���N�H�[�e�[�V������ݒ�
                    outputStrSB.Append(@"""");

                    _sw.WriteLine(outputStrSB.ToString());
                    outputStrSB.Length = 0;
                }
            }
            finally
            {
                if (_sw != null)
                    _sw.Close();
                if (_fs != null)
                    _fs.Close();
            }
        }

        /// <summary>
        /// �e�f�[�^���_�u���N�H�[�e�[�V�����ň͂�
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strSB"></param>
        private static void AppendString(string str, ref StringBuilder strSB)
        {
            if (strSB.Length != 0)
            {
                strSB.Append(@"""");
                strSB.Append(",");
            }

            strSB.Append(@"""");
            strSB.Append(str);

        }
    }
}

//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�o�[�R�[�h�֘A�t���@�捞�A�N�Z�X�N���X
// �v���O�����T�v   : ���i�o�[�R�[�h�֘A�t���f�[�^�ɑ΂��Ď捞�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370006-00 �쐬�S�� : 3H ������
// �� �� ��  2017/06/12  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Resources;
using System.IO;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;
using System.Data;
using Broadleaf.Library.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���i�o�[�R�[�h�֘A�t�����捞�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�o�[�R�[�h�֘A�t�����捞�A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : 3H ������</br>
    /// <br>Date       : 2017/06/12</br>
    /// </remarks>
    public class GoodsBarCodeRevnImportAcs
    {
        // �G���[���b�Z�[�W
        private const string ct_ERR_NOINPUT = "�����ͥ";
        private const string ct_ERR_INVALID_VALUE = "�l�s���";
        private const string ct_ERR_INVALID_LENGTH = "�����";
        private const string ct_ERR_INVALID_HYPHEN = "ʲ�݌��";
        private const string ct_ERR_MINUS = "ϲŽ�";
        private const string ct_ERR_DUPLICATE = "�d���f�[�^�����邽�ߓo�^�ł��܂���B";
        private const string ct_ERROR_LOG_FILENAME = "PMHND09210U_ERRORLOG.xml";

        /// <summary>�����[�g�I�u�W�F�N�g</summary>
        private IGoodsBarCodeRevnDB _iGoodsBarCodeRevnDB = null;

        /// <summary>�G���[�f�[�^�e�[�u��</summary>
        private DataTable _errOutputDataTable = null;

        /// <summary>
        /// ���i�o�[�R�[�h�֘A�t�����捞�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�o�[�R�[�h�֘A�t�����捞�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        public GoodsBarCodeRevnImportAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iGoodsBarCodeRevnDB = MediationGoodsBarCodeRevnDB.GetGoodsBarCodeRevnDB();
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iGoodsBarCodeRevnDB = null;
            }
        }

        #region �� �C���|�[�g����
        /// <summary>
        /// �C���|�[�g����
        /// </summary>
        /// <param name="fileWorkList">�t�@�C���f�[�^List</param>
        /// <param name="errLogFilePath">�G���[���O�t�@�C���p�X</param>
        /// <param name="processKbn">�����敪</param>
        /// <param name="dataCheckKbn">�`�F�b�N�敪</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="addCnt">�ǉ�����</param>
        /// <param name="updCnt">�X�V����</param>
        /// <param name="errCnt">�G���[����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�C���|�[�g��������</returns>
        /// <remarks>
        /// <br>Note       : ���i�o�[�R�[�h�֘A�t�����̓Ǎ����s���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// <br></br>
        /// </remarks>
        public int Import(List<GoodsBarCodeRevnFileWork> fileWorkList, string errLogFilePath, int processKbn, int dataCheckKbn, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 errCnt, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            readCnt = 0; // �Ǎ�����
            addCnt = 0; // �ǉ�����
            updCnt = 0; // �X�V����
            errCnt = 0; // �G���[����
            errMsg = string.Empty; //�G���[���b�Z�[�W
            try
            {
                // �����̏��i�o�[�R�[�h�֘A�t�����
                List<GoodsBarCodeRevnWork> existWorkList = null;
                // �t�@�C���f�[�^�̃G���[�f�[�^
                List<GoodsBarCodeRevnFileWork> errFileWorkList = null;
                // ���i�o�[�R�[�h�֘A�t�����
                ArrayList importWorkList = null;

                if (fileWorkList != null && fileWorkList.Count > 0)
                {
                    // �Ǎ�����
                    readCnt = fileWorkList.Count;
                    // �����̏��i�o�[�R�[�h�f�[�^��������
                    status = SearchGoodsBarCodeRevnWorkList(out existWorkList);
                    // �����̏��i�o�[�R�[�h�f�[�^�����������s
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                        && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) return status;
                    // �t�@�C���f�[�^��o�^�f�[�^�ɕϊ�����
                    status = ConvertFileWorkToImportWorkList(fileWorkList, existWorkList, processKbn, dataCheckKbn, out addCnt, out updCnt, out importWorkList, out errFileWorkList);
                    // �t�@�C���f�[�^��o�^�f�[�^�ɕϊ����s
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                    if (importWorkList != null && importWorkList.Count > 0)
                    {
                        // ���i�o�[�R�[�h�֘A�t�����(obj) 
                        object objGoodsBarCodeRevnWorkList = (object)importWorkList;
                        // ���i�o�[�R�[�h�֘A�t�����o�^���� 
                        status = this._iGoodsBarCodeRevnDB.WriteByInput(ref objGoodsBarCodeRevnWorkList);
                    }
                    if (errFileWorkList != null && errFileWorkList.Count > 0)
                    {
                        // �G���[����
                        errCnt = errFileWorkList.Count;
                        // �G���[���O�f�[�^���Z�b�g
                        SetDataToErrDataTable(errFileWorkList);
                        // �G���[���O�t�@�C�����o��
                        DoOutPut(errLogFilePath);
                    }
                }
            }
            catch (IOException)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// ���i�o�[�R�[�h�֘A�t����������
        /// </summary>
        /// <param name="goodsBarCodeRevnWorkList">��������List</param>
        /// <returns>������������</returns>
        /// <remarks>
        /// <br>Note       : ���i�o�[�R�[�h�֘A�t���̌����������s���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private int SearchGoodsBarCodeRevnWorkList(out List<GoodsBarCodeRevnWork> goodsBarCodeRevnWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            goodsBarCodeRevnWorkList = new List<GoodsBarCodeRevnWork>();
            try
            {
                GoodsBarCodeRevnSearchParaWork goodsBarCodeRevnSearchParaWork = new GoodsBarCodeRevnSearchParaWork();
                goodsBarCodeRevnSearchParaWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                // ���i�o�[�R�[�h�֘A�t�������������[�N�N���X �� obj
                object paraobj = goodsBarCodeRevnSearchParaWork;
                object retobj = null;

                // ���i�o�[�R�[�h�֘A�t���f�[�^����
                status = this._iGoodsBarCodeRevnDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData01);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���i�o�[�R�[�h�֘A�t�����[�NList
                    ArrayList wkList = retobj as ArrayList;
                    if (wkList != null && wkList.Count > 0)
                    {
                        for (int i = 0; i < wkList.Count; i++)
                        {
                            goodsBarCodeRevnWorkList.Add((GoodsBarCodeRevnWork)wkList[i]);
                        }
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �t�@�C���f�[�^��o�^�f�[�^�ɕϊ�����
        /// </summary>
        /// <param name="fileWorkList">�t�@�C���f�[�^</param>
        /// <param name="existWorkList">�����̏��i�o�[�R�[�h�֘A�t�����[�NList</param>
        /// <param name="processKbn">�����敪</param>
        /// <param name="dataCheckKbn">�`�F�b�N�敪</param>
        /// <param name="addCnt">�ǉ�����</param>
        /// <param name="updCnt">�X�V����</param>
        /// <param name="importWorkList">���i�o�[�R�[�h�֘A�t�����[�NList</param>
        /// <param name="errFileWorkList">�G���[�f�[�^List</param>
        /// <returns>�ϊ���������</returns>
        /// <remarks>
        /// <br>Note       : �t�@�C���f�[�^��o�^�f�[�^�ɕϊ������B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// <br></br>
        /// </remarks>
        private int ConvertFileWorkToImportWorkList(List<GoodsBarCodeRevnFileWork> fileWorkList, List<GoodsBarCodeRevnWork> existWorkList, int processKbn, int dataCheckKbn, out int addCnt, out int updCnt, out ArrayList importWorkList, out List<GoodsBarCodeRevnFileWork> errFileWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // �ǉ�����
            addCnt = 0;
            // �X�V����
            updCnt = 0;
            // ���i�o�[�R�[�h�֘A�t�����[�NList
            importWorkList = new ArrayList();
            // �t�@�C���f�[�^�̃G���[�f�[�^List
            errFileWorkList = new List<GoodsBarCodeRevnFileWork>();
            try
            {
                if (fileWorkList != null && fileWorkList.Count > 0)
                {
                    // ���i�o�[�R�[�h�֘A�t���f�B�N�V���i��
                    Dictionary<string, GoodsBarCodeRevnWork> _goodsBarCodeRevnWorkDic = new Dictionary<string, GoodsBarCodeRevnWork>();

                    if (existWorkList != null && existWorkList.Count > 0)
                    {
                        for (int i = 0; i < existWorkList.Count; i++)
                        {
                            // �L�[: ���i���[�J�[�R�[�h(4��) + "_" + ���i�ԍ�
                            string dicKey = existWorkList[i].GoodsMakerCd.ToString("0000") + "_" + existWorkList[i].GoodsNo;
                            if (!_goodsBarCodeRevnWorkDic.ContainsKey(dicKey))
                            {
                                // �����̃f�[�^���f�B�N�V���i���ɃZ�b�g
                                _goodsBarCodeRevnWorkDic.Add(dicKey, existWorkList[i]);
                            }
                        }
                    }

                    for (int i = 0; i < fileWorkList.Count; i++)
                    {
                        string errMsg = String.Empty;
                        // �L�[: ���i���[�J�[�R�[�h + "_" + ���i�ԍ�
                        string dicKey = fileWorkList[i].GoodsMakerCd.PadLeft(4, '0') + "_" + fileWorkList[i].GoodsNo;
                        // �f�[�^�͓o�^���Ȃ�
                        if (!_goodsBarCodeRevnWorkDic.ContainsKey(dicKey))
                        {
                            // ���.�����敪�F�ǉ��A�ǉ��X�V����ƁA�`�F�b�N�s��
                            if (processKbn == 0 || processKbn == 1)
                            {
                                // �f�[�^�̗L�����`�F�b�N
                                if (!FileWorKDataCheck(fileWorkList[i], fileWorkList, dataCheckKbn, out errMsg))
                                {
                                    fileWorkList[i].ErrMessage = errMsg;
                                    errFileWorkList.Add(fileWorkList[i]);
                                }
                                else
                                {
                                    GoodsBarCodeRevnWork temp = new GoodsBarCodeRevnWork();
                                    // ��ƃR�[�h
                                    temp.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                                    // ���i���[�J�[�R�[�h
                                    temp.GoodsMakerCd = int.Parse((fileWorkList[i].GoodsMakerCd.Trim()));
                                    // ���i�ԍ�
                                    temp.GoodsNo = fileWorkList[i].GoodsNo.Trim();
                                    // ���i�o�[�R�[�h
                                    temp.GoodsBarCode = fileWorkList[i].GoodsBarCode.Trim();
                                    // ���i�o�[�R�[�h���
                                    temp.GoodsBarCodeKind = int.Parse((fileWorkList[i].GoodsBarCodeKind.Trim()));
                                    // �`�F�b�N�f�W�b�g�敪
                                    temp.CheckdigitCode = 0;
                                    // �񋟃f�[�^�敪  0:���[�U�f�[�^
                                    temp.OfferDataDiv = 0;
                                    importWorkList.Add(temp);
                                    addCnt++;
                                }
                            }
                        }
                        // �f�[�^�͓o�^�ς�
                        else
                        {
                            // ���.�����敪�F�X�V�A�ǉ��X�V����ƁA�`�F�b�N�s��
                            if (processKbn == 0 || processKbn == 2)
                            {
                                // �f�[�^�̗L�����`�F�b�N
                                if (!FileWorKDataCheck(fileWorkList[i], fileWorkList, dataCheckKbn, out errMsg))
                                {
                                    fileWorkList[i].ErrMessage = errMsg;
                                    errFileWorkList.Add(fileWorkList[i]);
                                }
                                else
                                {
                                    GoodsBarCodeRevnWork temp = new GoodsBarCodeRevnWork();
                                    temp = _goodsBarCodeRevnWorkDic[dicKey];
                                    // ���i�o�[�R�[�h
                                    temp.GoodsBarCode = fileWorkList[i].GoodsBarCode;
                                    // ���i�o�[�R�[�h���
                                    temp.GoodsBarCodeKind = int.Parse(fileWorkList[i].GoodsBarCodeKind);
                                    importWorkList.Add(temp);
                                    updCnt++;
                                }
                            }
                        }
                    }
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        #endregion �� �C���|�[�g����

        #region �� �f�[�^�`�F�b�N����
        /// <summary>
        /// �f�[�^�`�F�b�N
        /// </summary>
        /// <param name="fileWork">���i�o�[�R�[�h�̃t�@�C���N���X���[�N</param>
        /// <param name="fileWorkList">�t�@�C���f�[�^</param>
        /// <param name="dataCheckKbn">�`�F�b�N�敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>true:�`�F�b�NOK false:�`�F�b�NNG</returns>
        /// <remarks>
        /// <br>Note       : �f�[�^�`�F�b�N�����s���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private bool FileWorKDataCheck(GoodsBarCodeRevnFileWork fileWork, List<GoodsBarCodeRevnFileWork> fileWorkList, int dataCheckKbn, out string errMsg)
        {
            errMsg = string.Empty;

            // �`�F�b�N�敪:����
            if (dataCheckKbn == 0)
            {
                string sWkMsg = string.Empty;

                // ���[�J�[�R�[�h
                sWkMsg = CheckGoodsMakerCd(fileWork.GoodsMakerCd.Trim());
                if (!string.IsNullOrEmpty(sWkMsg))
                {
                    errMsg = String.Format("Ұ��({0})", sWkMsg);
                    return false;
                }

                // �i��
                sWkMsg = CheckGoodsNo(fileWork.GoodsNo.Trim());
                if (!string.IsNullOrEmpty(sWkMsg))
                {
                    errMsg = String.Format("�i��({0})", sWkMsg);
                    return false;
                }

                // �o�[�R�[�h
                sWkMsg = CheckGoodsBarCode(fileWork.GoodsBarCode.Trim());
                if (!string.IsNullOrEmpty(sWkMsg))
                {
                    errMsg = String.Format("�o�[�R�[�h({0})", sWkMsg);
                    return false;
                }

                // �o�[�R�[�h���
                sWkMsg = CheckGoodsBarCodeKind(fileWork.GoodsBarCodeKind.Trim());
                if (!string.IsNullOrEmpty(sWkMsg))
                {
                    errMsg = String.Format("�o�[�R�[�h���({0})", sWkMsg);
                    return false;
                }
            }

            // ���i�o�[�R�[�h�L�[�d���`�F�b�N
            int countGoodU = fileWorkList.FindAll(
                delegate(GoodsBarCodeRevnFileWork p)
                {
                    return (p.GoodsNo == fileWork.GoodsNo
                           && p.GoodsMakerCd.PadLeft(4, '0') == fileWork.GoodsMakerCd.PadLeft(4, '0')
                          );
                }).Count;
            if (countGoodU > 1)
            {
                errMsg = ct_ERR_DUPLICATE;
                return false;
            }

            return true;
        }

        #region �� ���[�J�[�R�[�h
        /// <summary>
        /// ���[�J�[�R�[�h�`�F�b�N
        /// </summary>
        /// <param name="goodsMakerCd">���[�J�[�R�[�h</param>
        /// <returns>�`�F�b�N����</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[�R�[�h�`�F�b�N�����s���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private string CheckGoodsMakerCd(string goodsMakerCd)
        {
            string sResult = string.Empty;

            // ����������
            if (string.IsNullOrEmpty(goodsMakerCd))
            {
                sResult += ct_ERR_NOINPUT;
            }
            else
            {
                //���l���� 
                int num = 0;
                if (!Int32.TryParse(goodsMakerCd, out num))
                {
                    sResult += ct_ERR_INVALID_VALUE;
                }

                // �l�s��(���l)����
                if (num < 0)
                {
                    sResult += ct_ERR_MINUS;
                }

                // ��������
                if (goodsMakerCd.Length > 4)
                {
                    sResult += ct_ERR_INVALID_LENGTH;
                }

            }

            // ү���ޕҏW
            if (!string.IsNullOrEmpty(sResult))
            {
                sResult = sResult.Substring(0, sResult.Length - 1);
            }

            return sResult;
        }
        #endregion �� ���[�J�[�R�[�h

        #region �� �i��
        /// <summary>
        /// �i�ԃ`�F�b�N
        /// </summary>
        /// <param name="goodsNo">�i��</param>
        /// <returns>�`�F�b�N����</returns>
        /// <remarks>
        /// <br>Note       : �i�ԃ`�F�b�N�����s���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private string CheckGoodsNo(string goodsNo)
        {
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
            string sResult = string.Empty;

            // ����������
            if (string.IsNullOrEmpty(goodsNo))
            {
                sResult += ct_ERR_NOINPUT;
            }
            else
            {
                // ��������
                int byteCount = sjisEnc.GetByteCount(goodsNo);
                if (byteCount > 24)
                {
                    sResult += ct_ERR_INVALID_LENGTH;
                }

                // ʲ�݂�6�ȏ㑶��
                if (goodsNo.Split('-').Length > 6)
                {
                    sResult += ct_ERR_INVALID_HYPHEN;
                }

                // �i�ԕs��
                if ((byteCount != goodsNo.Length) ||
                    goodsNo.Contains("*") ||
                    goodsNo.StartsWith("-") ||
                    goodsNo.EndsWith("+") ||
                    goodsNo.EndsWith("."))
                {
                    sResult += ct_ERR_INVALID_VALUE;
                }
            }

            // ү���ޕҏW
            if (!string.IsNullOrEmpty(sResult))
            {
                sResult = sResult.Substring(0, sResult.Length - 1);
            }

            return sResult;
        }

        #endregion �� �i��

        #region �� �o�[�R�[�h
        /// <summary>
        /// �o�[�R�[�h�`�F�b�N
        /// </summary>
        /// <param name="goodsBarCode">�o�[�R�[�h</param>
        /// <returns>�`�F�b�N����</returns>
        /// <remarks>
        /// <br>Note       : �o�[�R�[�h�`�F�b�N�����s���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private string CheckGoodsBarCode(string goodsBarCode)
        {
            string sResult = string.Empty;

            // ����������
            if (string.IsNullOrEmpty(goodsBarCode))
            {
                sResult += ct_ERR_NOINPUT;
            }
            else
            {
                // ��������
                if (goodsBarCode.Length > 128)
                {
                    sResult += ct_ERR_INVALID_LENGTH;
                }
            }

            // ү���ޕҏW
            if (!string.IsNullOrEmpty(sResult))
            {
                sResult = sResult.Substring(0, sResult.Length - 1);
            }

            return sResult;
        }
        #endregion �� �o�[�R�[�h

        #region �� �o�[�R�[�h���
        /// <summary>
        /// �o�[�R�[�h��ʃ`�F�b�N
        /// </summary>
        /// <param name="goodsBarCodeKind">�o�[�R�[�h���</param>
        /// <returns>�`�F�b�N����</returns>
        /// <remarks>
        /// <br>Note       : �o�[�R�[�h��ʃ`�F�b�N�����s���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private string CheckGoodsBarCodeKind(string goodsBarCodeKind)
        {
            string sResult = string.Empty;
            // ����������
            if (string.IsNullOrEmpty(goodsBarCodeKind))
            {
                sResult += ct_ERR_NOINPUT;
            }
            else
            {
                // �o�[�R�[�h���(0��1)
                if (!goodsBarCodeKind.Equals("0") && !goodsBarCodeKind.Equals("1"))
                {
                    sResult = ct_ERR_INVALID_VALUE;
                }
            }
            // ү���ޕҏW
            if (!string.IsNullOrEmpty(sResult))
            {
                sResult = sResult.Substring(0, sResult.Length - 1);
            }

            return sResult;
        }
        #endregion �� �o�[�R�[�h���

        #endregion �� �f�[�^�`�F�b�N����

        #region �G���[���O�t�@�C���o�͏���

        /// <summary>
        /// �G���[�f�[�^�e�[�u�������ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : �G���[�f�[�^�e�[�u�������ݒ�B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void InitErrDataTable()
        {
            this._errOutputDataTable = new DataTable();
            // ���i���[�J�[�R�[�h
            this._errOutputDataTable.Columns.Add("GoodsMakerCd_Err", typeof(string));
            // ���i�ԍ�
            this._errOutputDataTable.Columns.Add("GoodsNo_Err", typeof(string));
            // ���i�o�[�R�[�h
            this._errOutputDataTable.Columns.Add("GoodsBarCode_Err", typeof(string));
            // ���i�o�[�R�[�h���
            this._errOutputDataTable.Columns.Add("GoodsBarCodeKind_Err", typeof(string));
            // �G���[���b�Z�[�W
            this._errOutputDataTable.Columns.Add("Message_Err", typeof(string));
        }

        /// <summary>
        /// �G���[�f�[�^�e�[�u���ɒl���Z�b�g
        /// </summary>
        /// <param name="errFileWorkList">�G���[�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �G���[�f�[�^�e�[�u���ɒl���Z�b�g�B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void SetDataToErrDataTable(List<GoodsBarCodeRevnFileWork> errFileWorkList)
        {
            if (this._errOutputDataTable == null)
            {
                // �G���[�f�[�^�e�[�u�������ݒ�
                InitErrDataTable();
            }
            // �G���[�f�[�^�e�[�u���N���A
            this._errOutputDataTable.Clear();
            if (errFileWorkList != null && errFileWorkList.Count > 0)
            {
                for (int i = 0; i < errFileWorkList.Count; i++)
                {
                    DataRow dataRow = this._errOutputDataTable.NewRow();
                    // ���i���[�J�[�R�[�h
                    dataRow["GoodsMakerCd_Err"] = errFileWorkList[i].GoodsMakerCd;
                    // ���i�ԍ�
                    dataRow["GoodsNo_Err"] = errFileWorkList[i].GoodsNo;
                    // ���i�o�[�R�[�h
                    dataRow["GoodsBarCode_Err"] = errFileWorkList[i].GoodsBarCode;
                    // ���i�o�[�R�[�h���
                    dataRow["GoodsBarCodeKind_Err"] = errFileWorkList[i].GoodsBarCodeKind;
                    // �G���[���b�Z�[�W
                    dataRow["Message_Err"] = errFileWorkList[i].ErrMessage;
                    this._errOutputDataTable.Rows.Add(dataRow);
                }
            }
        }

        /// <summary>
        /// �G���[���O�t�@�C���o�͏���
        /// </summary>
        /// <param name="errorLogFileName">�G���[���O�o�̓t�@�C���o�X</param>
        /// <returns>�o�͏�����</returns>
        /// <remarks>
        /// <br>Note	   : �G���[���O�t�@�C���o�͏������s���B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private int DoOutPut(string errorLogFileName)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // �e�L�X�g�o�̓T�[�r�X�p�����[�^
            CustomTextProviderInfo customTextProviderInfo = CustomTextProviderInfo.GetDefaultInfo();
            // �e�L�X�g���o�̓N���X
            CustomTextWriter customTextWriter = new CustomTextWriter();

            // �o�̓p�X�Ɩ��O
            customTextProviderInfo.OutPutFileName = errorLogFileName;
            // �㏑���^�ǉ��t���O���Z�b�g(true:�ǉ�����Afalse:�㏑������)
            customTextProviderInfo.AppendMode = false;
            // �X�L�[�}�擾
            customTextProviderInfo.SchemaFileName = System.IO.Path.Combine(ConstantManagement_ClientDirectory.TextOutSchema, ct_ERROR_LOG_FILENAME);

            try
            {
                // �G���[���O�t�@�C���o�͏���
                status = customTextWriter.WriteText(this._errOutputDataTable, customTextProviderInfo.SchemaFileName, customTextProviderInfo.OutPutFileName, customTextProviderInfo);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion
    }
    
}

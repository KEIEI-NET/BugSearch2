using System;
using Broadleaf.Application.Remoting;
using System.Collections.Generic;
using System.Collections;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;
using Microsoft.Win32;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// �R���o�[�g�Ώۃo�[�W�����Ǘ����i
    /// </summary>
    /// <remarks>
    /// <br>Note       : �R���o�[�g�Ώۃo�[�W��������ĕϊ���������N���X�ł��B</br>
    /// <br>Programmer : </br>
    /// <br>Date       : 2020/06/15</br>
    /// </remarks>
    public class ConvertVersionSetting : RemoteDB
    { 
        #region �v���C�x�[�g�ϐ�

        #region �v���p�e�B�Ŏg�p

        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;

        /// <summary>���i�R�[�h</summary>
        private string _goodsNo;

        /// <summary>���i���[�J�[�R�[�h</summary>
        private int _goodsMakerCd;

        /// <summary>�ϊ��O�p�����[�^</summary>
        private double _convertSetParam;

        /// <summary>�ϊ���p�����[�^</summary>
        private double _convertGetParam;

        /// <summary>�ϊ��o�[�W����</summary>
        private int _convertSetVersion;

        #endregion // �v���p�e�B�Ŏg�p

        /// <summary>�ϊ��������s�N���X</summary>
        private ExeConvert _exeConvert;

        #endregion

        #region �񋓑�

        /// <summary>
        /// ���\�b�h�̖߂�X�e�[�^�X
        /// </summary>
        public enum ReturnStatus
        {
            CT_RETURN_STATUS_OK = 0,
            CT_RETURN_STATUS_ERROR = 9,
            CT_RETURN_STATUS_ERROR_EXP = 1000
        }

        /// <summary>
        /// �ϊ��o�[�W����
        /// </summary>
        public enum ConvertVersion
        {
            CT_CONVERT_VERSION_NONE = 0,
            CT_CONVERT_VERSION_1 = 1,
            CT_CONVERT_VERSION_2 = 2,
            CT_CONVERT_VERSION_3 = 3
        }

        /// <summary>
        /// �������
        /// 0:�����A1:�ϊ�
        /// </summary>
        public enum ProcCls
        {
            CT_PROC_RELEASE = 0,
            CT_PROC_CONVERT = 1
        }

        #endregion // �萔

        #region �R���X�g���N�^

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public ConvertVersionSetting()
        {
            //// �����l�Z�b�g
            _enterpriseCode = string.Empty;
            _goodsNo = string.Empty;
            _goodsMakerCd = int.MinValue;
            _convertSetParam = int.MinValue;
            _convertGetParam = int.MinValue;
            _convertSetVersion = (int)ConvertVersion.CT_CONVERT_VERSION_NONE;
        }

        #endregion // �R���X�g���N�^

        #region �v���p�e�B

        /// <summary>
        /// ��ƃR�[�h
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// <summary>
        /// ���i���[�J�[�R�[�h
        /// </summary>
        public int GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// <summary>
        /// ���i�ԍ�
        /// </summary>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// <summary>
        /// �ϊ��O�p�����[�^
        /// </summary>
        public double ConvertSetParam
        {
            get { return this._convertSetParam; }
            set { this._convertSetParam = value; }
        }

        /// <summary>
        /// �ϊ���p�����[�^
        /// </summary>
        public double ConvertGetParam
        {
            get { return this._convertGetParam; }
            set { this._convertGetParam = value; }
        }

        /// <summary>
        /// �ϊ��o�[�W����
        /// </summary>
        public int ConvertSetVersion
        {
            get { return this._convertSetVersion; }
            set { this._convertSetVersion = value; }
        }

        #endregion

        #region public���\�b�h
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns>���s�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����������s���܂��B</br>
        /// <br>Programmer : </br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        public int VersionInitLib()
        {
            int status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR;

            try
            {
                // �ϊ����i�̏�����
                switch (_convertSetVersion)
                {
                    case (int)ConvertVersion.CT_CONVERT_VERSION_1:
                        _exeConvert = new ExeConvert();
                        break;

                    case (int)ConvertVersion.CT_CONVERT_VERSION_2:
                        // ������
                        break;

                    case (int)ConvertVersion.CT_CONVERT_VERSION_3:
                        // ������
                        break;

                    default:
                        break;
                }

                status = (int)ReturnStatus.CT_RETURN_STATUS_OK;
            }
            catch (Exception ex)
            {
                //���O�o��
                WriteErrorLogProc(ex, "ConvertVersionSetting.VersionInitLib");
                status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR_EXP;
            }

            return status;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <returns>���s�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���l�ϊ������������s���܂��B</br>
        /// <br>Programmer : </br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        public int ReleaseProc()
        {
            int status = (int)ConvertVersionSettingOne.ReturnStatus.CT_RETURN_STATUS_OK;

            // ���ϊ���l�̏�����
            _convertGetParam = int.MinValue;

            try
            {
                // �o�[�W�����ŉ��������𕪊򂷂�
                switch (_convertSetVersion)
                {
                    case (int)ConvertVersion.CT_CONVERT_VERSION_NONE:
                        // �ϊ����s���Ă��Ȃ����߁A�󂯎�����l��ԋp
                        _convertGetParam = _convertSetParam;
                        break;

                    case (int)ConvertVersion.CT_CONVERT_VERSION_1:
                        // �o�[�W�����P�̉�������
                        // �p�����[�^�ݒ�
                        _exeConvert.EnterpriseCode = _enterpriseCode;
                        _exeConvert.GoodsMakerCd = _goodsMakerCd;
                        _exeConvert.GoodsNo = _goodsNo;
                        _exeConvert.ConvertSetParam = _convertSetParam;

                        _exeConvert.ConvertGetParam = int.MinValue;

                        // ��������
                        status = _exeConvert.ExecuteConvert((int)ProcCls.CT_PROC_RELEASE);

                        if (status == (int)ConvertVersionSettingOne.ReturnStatus.CT_RETURN_STATUS_ERROR_EXP)
                        {
                            // �p�����[�^�Đݒ�
                            _exeConvert.EnterpriseCode = _enterpriseCode;
                            _exeConvert.GoodsMakerCd = _goodsMakerCd;
                            _exeConvert.GoodsNo = _goodsNo;
                            _exeConvert.ConvertSetParam = _convertSetParam;

                            _exeConvert.ConvertGetParam = int.MinValue;

                            // ���i�ϊ�����ĂȂ��ꍇ���ڌďo��
                            status = _exeConvert.ExecuteConvertDirect((int)ProcCls.CT_PROC_RELEASE);
                        }

                        if (status == (int)ConvertVersionSettingOne.ReturnStatus.CT_RETURN_STATUS_OK)
                        {
                            // �����l�ݒ�
                            _convertGetParam = _exeConvert.ConvertGetParam;
                        }

                        break;

                    case (int)ConvertVersion.CT_CONVERT_VERSION_2:
                        // �o�[�W�����Q�̉�������

                        // �������̂��߁A�󂯎�����l��ԋp
                        _convertGetParam = _convertSetParam;

                        break;

                    case (int)ConvertVersion.CT_CONVERT_VERSION_3:
                        // �o�[�W�����R�̉�������

                        // �������̂��߁A�󂯎�����l��ԋp
                        _convertGetParam = _convertSetParam;

                        break;

                    default:
                        status = (int)ConvertVersionSettingOne.ReturnStatus.CT_RETURN_STATUS_ERROR;
                        _exeConvert.WriteErrorLogProc("ERR ConvertVersionSetting.ReleaseProc _convertSetVersion:" + _convertSetVersion.ToString());
                        _convertGetParam = _convertSetParam;
                        break;
                }
            }
            catch (Exception ex)
            {
                //���O�o��
                _exeConvert.WriteErrorLogProc(ex, "EXP ConvertVersionSetting.ReleaseProc _convertSetVersion:" + _convertSetVersion.ToString());

                status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR_EXP;
            }

            // �Ԃ�l�͕K�v
            return status;
        }

        /// <summary>
        /// �ϊ�����
        /// </summary>
        /// <returns>���s�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���l�ϊ������������s���܂��B</br>
        /// <br>Programmer : </br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        public int ConvertProc()
        {
            int status = (int)ConvertVersionSettingOne.ReturnStatus.CT_RETURN_STATUS_OK;

            // ���ϊ���l�̏�����
            _convertGetParam = int.MinValue;

            try
            {
                // �o�[�W�����ŕϊ������𕪊򂷂�
                switch (_convertSetVersion)
                {
                    case (int)ConvertVersion.CT_CONVERT_VERSION_NONE:
                        // �ϊ����s���Ă��Ȃ����߁A�󂯎�����l��ԋp
                        _convertGetParam = _convertSetParam;
                        break;

                    case (int)ConvertVersion.CT_CONVERT_VERSION_1:
                        // �o�[�W�����P�̕ϊ�����
                        // �p�����[�^�ݒ�
                        _exeConvert.EnterpriseCode = _enterpriseCode;
                        _exeConvert.GoodsMakerCd = _goodsMakerCd;
                        _exeConvert.GoodsNo = _goodsNo;
                        _exeConvert.ConvertSetParam = _convertSetParam;

                        _exeConvert.ConvertGetParam = int.MinValue;

                        // �ϊ�����
                        status = _exeConvert.ExecuteConvert((int)ProcCls.CT_PROC_CONVERT);

                        if (status == (int)ConvertVersionSettingOne.ReturnStatus.CT_RETURN_STATUS_ERROR_EXP)
                        {
                            // �p�����[�^�Đݒ�
                            _exeConvert.EnterpriseCode = _enterpriseCode;
                            _exeConvert.GoodsMakerCd = _goodsMakerCd;
                            _exeConvert.GoodsNo = _goodsNo;
                            _exeConvert.ConvertSetParam = _convertSetParam;

                            _exeConvert.ConvertGetParam = int.MinValue;

                            // ���i�ϊ�����ĂȂ��ꍇ���ڌďo��
                            _exeConvert.ExecuteConvertDirect((int)ProcCls.CT_PROC_CONVERT);
                        }

                        if (status == (int)ConvertVersionSettingOne.ReturnStatus.CT_RETURN_STATUS_OK)
                        {
                            // �ϊ��l�ݒ�
                            _convertGetParam = _exeConvert.ConvertGetParam;
                        }

                        break;

                    case (int)ConvertVersion.CT_CONVERT_VERSION_2:
                        // �o�[�W�����Q�̕ϊ�����

                        // �������̂��߁A�󂯎�����l��ԋp
                        _convertGetParam = _convertSetParam;

                        break;

                    case (int)ConvertVersion.CT_CONVERT_VERSION_3:
                        // �o�[�W�����R�̕ϊ�����

                        // �������̂��߁A�󂯎�����l��ԋp
                        _convertGetParam = _convertSetParam;

                        break;

                    default:
                        status = (int)ConvertVersionSettingOne.ReturnStatus.CT_RETURN_STATUS_ERROR;
                        _exeConvert.WriteErrorLogProc("ERR ConvertVersionSetting.ConvertProc _convertSetVersion:" + _convertSetVersion.ToString());
                        _convertGetParam = _convertSetParam;
                        break;
                }
            }
            catch (Exception ex)
            {
                //���O�o��
                _exeConvert.WriteErrorLogProc(ex, "EXP ConvertVersionSetting.ConvertProc _convertSetVersion:" + _convertSetVersion.ToString());

                status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR_EXP;
            }

            return status;
        }
        
        #endregion // public���\�b�h

        #region private���\�b�h
        /// <summary>
        /// ���O�o��
        /// </summary>
        /// <param name="errorText"></param>
        /// <remarks>
        /// <br>Note       : ���O�o�͂��s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private void WriteErrorLogProc(string errorText)
        {
            try
            {
                base.WriteErrorLog(errorText);
            }
            catch
            {
            }
            finally
            {
            }
        }

        /// <summary>
        /// ���O�o��
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="errorText"></param>
        /// <remarks>
        /// <br>Note       : ���O�o�͂��s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private void WriteErrorLogProc(Exception ex, string errorText)
        {
            try
            {
                base.WriteErrorLog(ex, errorText);
            }
            catch
            {
            }
            finally
            {
            }
        }
        #endregion // private���\�b�h
    }
}

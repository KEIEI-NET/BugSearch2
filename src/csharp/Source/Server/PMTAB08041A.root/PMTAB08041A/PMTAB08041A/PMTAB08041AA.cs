//****************************************************************************//
// �V�X�e��         : PM-Tablet
// �v���O��������   : ���i�ڍ׏�񌟍�HTTP�n���h��
// �v���O�����T�v   : ���i�ڍ׏�񌟍��̏����𐧌䂵�܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370090-00  �쐬�S�� : chenyk
// �� �� ��  2017.11.02   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Runtime.Serialization.Json;
using Broadleaf.Application.Controller;

namespace Broadleaf.Web
{
    /// <summary>
    /// ���i�ڍ׏�񌟍�HTTP�n���h��
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�ڍ׏�񌟍��̏����𐧌䂵�܂��B</br>
    /// <br>Programmer : chenyk</br>
    /// <br>Date       : 2017.11.02</br>
    /// </remarks>
    public class PartsDetailInfoSearchHTTPHandler : NSJsonHandler
    {
        #region << Private Const >>
        /// <summary>PGID</summary>
        private const string Pgid = "PMTAB08041A";
        /// <summary>HTTP���N�G�X�g�������\�b�h����</summary>
        private const string RequestProcName = "HTTP���N�G�X�g����";
        /// <summary>HTTP���N�G�X�g�����G���[���b�Z�[�W</summary>
        private const string RequestProcErrorMsg = "HTTP���N�G�X�g�����̓Z�b�g����Ă��܂���B";
        /// <summary>���i�ڍ׏��L���`�F�b�N�������\�b�hID</summary>
        private const string CheckProcID = "CheckPartsDetailInfoList";
        /// <summary>���i�ڍ׏��L���`�F�b�N�������\�b�h����</summary>
        private const string CheckProcName = "���i�ڍ׏��L���`�F�b�N����";
        /// <summary>���i�ڍ׏��擾�������\�b�hID</summary>
        private const string GetProcID = "GetPartsDetailInfoList";
        /// <summary>���i�ڍ׏��擾�������\�b�h����</summary>
        private const string GetProcName = "���i�ڍ׏��擾����";
        /// <summary>��O�G���[���b�Z�[�W</summary>
        private const string ExceptionMsg = "{0}�ɂė�O���������܂����B";
        /// <summary>�p�����[�^�s�����b�Z�[�W</summary>
        private const string ParamErrorMsg = "�p�����[�^��񂪕s���Ȃ��߁A�����𒆒f���܂�";
        #endregion

        #region << NSJsonHnadler ���� >>
        /// <summary>
        /// HTTP���N�G�X�g����
        /// </summary>
        /// <param name="data">�p�����[�^</param>
        /// <returns>��������(true�F���N�G�X�g����������, false�F���N�G�X�g���������Ȃ�����)</returns>
        /// <remarks>
        /// <br>Note       : �v�����ꂽHTTP���N�G�X�g�ɑ΂��鏈�����s���܂�</br>
        /// <br>Programmer : chenyk</br>
        /// <br>Date       : 2017.11.02</br>
        ///</remarks>
        protected override bool ProcessRequest(NSJsonProcessRequestData data)
        {
            // ���N�G�X�g�����t���O
            // �������ʂɊւ�炸�AMethodPath���������ꍇ��True��Ԃ�
            bool isProcessed = true;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string errMsg = string.Empty;
            JsonValue resultValue = null;  // �������ʊi�[�pJsonValue

            string methodPath = string.Empty;

            if (data == null)
            {
                throw new MobileWebException(
                    Pgid
                    ,RequestProcName
                    ,RequestProcErrorMsg
                    ,-1
                    ,null);
            }

            if (!string.IsNullOrEmpty(data.MethodPath))
            {
                methodPath = data.MethodPath;
            }

            try
            {
                JsonObject jsonObject = data.JsonParameter as JsonObject;

                // �p�����[�^�`�F�b�N����
                if (!CheckJsonParameterObject(jsonObject, ref data))
                {
                    if (methodPath == CheckProcID || methodPath == GetProcID)
                    {
                        // �������ʂɊւ�炸�AMethodPath���������ꍇ��True��Ԃ�
                        isProcessed = true;
                        return isProcessed;
                    }
                    else
                    {
                        isProcessed = false;
                        return isProcessed;
                    }
                }

                // ���\�b�h���̒�`
                #region  MethodPath�ɂ�鏈������
                switch (methodPath)
                {
                    case CheckProcID:�@// ���i�ڍ׏��L���`�F�b�N����
                        {
                            #region
                            // ���i�ڍ׏��L���`�F�b�N����
                            isProcessed = true;
                            status = this.CheckPartsDetailInfoListProc(jsonObject, out resultValue, out errMsg);
                            #endregion
                            break;
                        }
                    case GetProcID:�@// ���i�ڍ׏��擾����
                        {
                            #region
                            // ���i�ڍ׏��擾����
                            isProcessed = true;
                            status = this.GetPartsDetailInfoListProc(jsonObject, out resultValue, out errMsg);
                            #endregion
                            break;
                        }
                    default:
                        isProcessed = false;
                        break;
                }
                #endregion

                if (isProcessed)
                {
                    data.ResponseStatus = status;
                    data.ResponseMessage = errMsg;
                    data.JsonResponse = resultValue;
                }
            }
            catch (MobileWebException)
            {
                throw;
            }
            catch (Exception ex)
            {
                // �v���O����ID�A���b�Z�[�W�A�X�e�[�^�X�AException ���Z�b�g
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                throw new MobileWebException(Pgid, RequestProcName + "(" + methodPath + ")", 
                    string.Format(ExceptionMsg, RequestProcName + "(" + methodPath + ")") + Environment.NewLine + ex.ToString(), -1, ex);
            }

            return isProcessed;
        }

        #endregion

        #region ��JsonObject�`�F�b�N����
        /// <summary>
        /// JsonObject�`�F�b�N����
        /// </summary>
        /// <param name="jsonObject">�����p�p�����[�^</param>
        /// <param name="data">�p�����[�^</param>
        /// <returns>�`�F�b�N����(True:�p�����[�^��񂠂�, False:�p�����[�^���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note       : JsonObject�`�F�b�N�������s���܂�</br>
        /// <br>Programmer : chenyk</br>
        /// <br>Date       : 2017.11.02</br>
        ///</remarks>
        private bool CheckJsonParameterObject(JsonObject jsonObject, ref NSJsonProcessRequestData data)
        {
            bool isProcess = true;

            if(jsonObject == null)
            {
                data.ResponseStatus = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                data.ResponseMessage = ParamErrorMsg;
                isProcess = false;
            }
            return isProcess;
        }
        #endregion

        #region �����i�ڍ׏��L���`�F�b�N����(CheckPartsDetailInfoListProc)
        /// <summary>
        /// ���i�ڍ׏��L���`�F�b�N����
        /// </summary>
        /// <param name="jsonObject">�����p�p�����[�^</param>
        /// <param name="retObj">���X�|���X</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note        : ���i�ڍ׏��L���`�F�b�N�������s���܂�</br>
        /// <br>Programmer  : chenyk</br>
        /// <br>Date        : 2017.11.02</br>
        ///</remarks>
        private int CheckPartsDetailInfoListProc(JsonObject jsonObject, out JsonValue retObj, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retObj = null;
            errMsg = string.Empty;

            try
            {
                status = new PartsDetailInfoSearchWebAcs().CheckPartsDetailInfoList(jsonObject, out retObj, out errMsg);
            }
            catch (MobileWebException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                // �v���O����ID�A���b�Z�[�W�A�X�e�[�^�X�AException ���Z�b�g
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                throw new MobileWebException(Pgid, CheckProcName, string.Format(ExceptionMsg, CheckProcName), -1, ex);
            }
            return status;
        }
        #endregion

        #region �����i�ڍ׏��擾����(GetPartsDetailInfoList)
        /// <summary>
        /// ���i�ڍ׏��擾����
        /// </summary>
        /// <param name="jsonObject">�����p�p�����[�^</param>
        /// <param name="retObj">���X�|���X</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note        : ���i�ڍ׏��擾�������s���܂�</br>
        /// <br>Programmer  : chenyk</br>
        /// <br>Date        : 2017.11.02</br>
        ///</remarks>
        private int GetPartsDetailInfoListProc(JsonObject jsonObject, out JsonValue retObj, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retObj = null;
            errMsg = string.Empty;

            try
            {
                status = new PartsDetailInfoSearchWebAcs().GetPartsDetailInfoList(jsonObject, out retObj, out errMsg);
            }
            catch (MobileWebException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                // �v���O����ID�A���b�Z�[�W�A�X�e�[�^�X�AException ���Z�b�g
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                throw new MobileWebException(Pgid, GetProcName, string.Format(ExceptionMsg, GetProcName), -1, ex);
            }
            return status;
        }
        #endregion
    }
}

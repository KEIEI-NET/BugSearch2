using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// where���������i�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: ���R���[�̒��[�p�����[�g���g�p���܂��Bwhere���𐶐����܂��B</br>
    /// <br>Programmer	: 22011 ���� ���l</br>
    /// <br>Date		: 2007.10.18</br>
    /// <br>UpdateNote	: </br>
    /// </remarks>
    public class SFANL08309CA
    {
        #region public methods
        
        #region ���o�����N�G���쐬
        /// <summary>
        /// ���o�����N�G���쐬(���o�����p�����[�^���ƍ����ĕ��𐶐����܂�)
        /// </summary>
        /// <param name="whereString">where����ǉ�����StringBuilder</param>
        /// <param name="frePprECnd">���R���[���o����</param>
        /// <param name="sqlCommand">���o�Ɏg�p����SqlCommand�̃C���X�^���X</param>
        public void SettingPara(ref StringBuilder whereString, FrePprECndWork frePprECnd, ref SqlCommand sqlCommand)
        {
            switch (frePprECnd.ExtraConditionDivCd)
            {
                case 1:
                case 5:
                    {//���l/�R���{�{�b�N�X
                        if (frePprECnd.ExtraConditionTypeCd == 0)
                        {//��v
                            if(frePprECnd.StExtraNumCode != 0)
                            {
                                whereString.Append(" AND ");
                                whereString.Append(GetFieldName(frePprECnd) + " = " + GetFindPrNmStr(frePprECnd));
                                SqlParameter findPara = sqlCommand.Parameters.Add(GetFindPrNmStr(frePprECnd), SqlDbType.Int);
                                findPara.Value = frePprECnd.StExtraNumCode;
                            }
                        }
                        else
                        {//�͈�
                            //�J�n
                            if (frePprECnd.StExtraNumCode != 0)
                            {
                                whereString.Append(" AND ");
                                whereString.Append(GetFieldName(frePprECnd) + " >= " + GetFindPrNmStr(frePprECnd));
                                SqlParameter findSrtPara = sqlCommand.Parameters.Add(GetFindPrNmStr(frePprECnd), SqlDbType.Int);
                                findSrtPara.Value = frePprECnd.StExtraNumCode;
                            }
                            //�I��
                            if (frePprECnd.EdExtraNumCode != 0)
                            {
                                whereString.Append(" AND ");
                                whereString.Append(GetFieldName(frePprECnd) + " <= " + GetFindPrNmEndStr(frePprECnd));
                                SqlParameter findEndPara = sqlCommand.Parameters.Add(GetFindPrNmEndStr(frePprECnd), SqlDbType.Int);
                                findEndPara.Value = frePprECnd.EdExtraNumCode;
                            }
                        }
                        break;
                    }
                case 2:
                case 3:
                    {//����
                        if (frePprECnd.ExtraConditionTypeCd == 0)
                        {//��v
                            if (!string.IsNullOrEmpty(frePprECnd.StExtraCharCode))
                            {
                                whereString.Append(" AND ");
                                whereString.Append(GetFieldName(frePprECnd) + " = " + GetFindPrNmStr(frePprECnd));
                                SqlParameter findPara = sqlCommand.Parameters.Add(GetFindPrNmStr(frePprECnd), SqlDbType.NChar);
                                findPara.Value = frePprECnd.StExtraCharCode;
                            }
                        }
                        else if (frePprECnd.ExtraConditionTypeCd == 1)
                        {//�͈�
                            if (!string.IsNullOrEmpty(frePprECnd.StExtraCharCode))
                            {
                                //�J�n
                                whereString.Append(" AND ");
                                whereString.Append(GetFieldName(frePprECnd) + " >= " + GetFindPrNmStr(frePprECnd));
                                SqlParameter findSrtPara = sqlCommand.Parameters.Add(GetFindPrNmStr(frePprECnd), SqlDbType.NChar);
                                findSrtPara.Value = frePprECnd.StExtraCharCode;
                            }
                            //�I��
                            if ((!string.IsNullOrEmpty(frePprECnd.EdExtraCharCode)))
                            {
                                whereString.Append(" AND ");
                                whereString.Append(GetFieldName(frePprECnd) + " <= " + GetFindPrNmEndStr(frePprECnd));
                                SqlParameter findEndPara = sqlCommand.Parameters.Add(GetFindPrNmEndStr(frePprECnd), SqlDbType.NChar);
                                findEndPara.Value = frePprECnd.EdExtraCharCode;
                            }
                        }
                        else if (frePprECnd.ExtraConditionTypeCd == 2)
                        {//�B��
                            if ((!string.IsNullOrEmpty(frePprECnd.StExtraCharCode)))
                            {
                                whereString.Append(" AND ");
                                whereString.Append(GetFieldName(frePprECnd) + " like " + GetFindPrNmStr(frePprECnd));
                                SqlParameter findPara = sqlCommand.Parameters.Add(GetFindPrNmStr(frePprECnd), SqlDbType.NChar);
                                findPara.Value = "%"+frePprECnd.StExtraCharCode+"%";
                            }
                        }
                        break;
                    }
                case 4:
                    {//���t
                        if (frePprECnd.ExtraConditionTypeCd == 0)
                        {//��v
                            if (frePprECnd.StartExtraDate != 0)
                            {
                                whereString.Append(" AND ");
                                whereString.Append(GetFieldName(frePprECnd) + " = " + GetFindPrNmStr(frePprECnd));
                                SqlParameter findPara = sqlCommand.Parameters.Add(GetFindPrNmStr(frePprECnd), SqlDbType.Int);
                                findPara.Value = frePprECnd.StartExtraDate;
                            }
                        }
                        else
                        {//�͈�/����
                            if (frePprECnd.StartExtraDate != 0)
                            {
                                //�J�n
                                whereString.Append(" AND ");
                                whereString.Append(GetFieldName(frePprECnd) + " >= " + GetFindPrNmStr(frePprECnd));
                                SqlParameter findSrtPara = sqlCommand.Parameters.Add(GetFindPrNmStr(frePprECnd), SqlDbType.Int);
                                findSrtPara.Value = frePprECnd.StartExtraDate;
                            }
                            if (frePprECnd.EndExtraDate != 0)
                            {
                                //�I��
                                whereString.Append(" AND ");
                                whereString.Append(GetFieldName(frePprECnd) + " <= " + GetFindPrNmEndStr(frePprECnd));
                                SqlParameter findEndPara = sqlCommand.Parameters.Add(GetFindPrNmEndStr(frePprECnd), SqlDbType.Int);
                                findEndPara.Value = frePprECnd.EndExtraDate;
                            }
                        }
                        break;
                    }
                case 6:
                    {//�`�F�b�N�{�b�N�X
                        StringBuilder values = new StringBuilder();
                        if (frePprECnd.CheckItemCode1 != -1) values.Append(frePprECnd.CheckItemCode1.ToString());
                        if (frePprECnd.CheckItemCode2 != -1)
                        {
                            if (values.Length != 0) values.Append(",");
                            values.Append(frePprECnd.CheckItemCode2.ToString());
                        }
                        if (frePprECnd.CheckItemCode3 != -1)
                        {
                            if (values.Length != 0) values.Append(",");
                            values.Append(frePprECnd.CheckItemCode3.ToString());
                        }
                        if (frePprECnd.CheckItemCode4 != -1)
                        {
                            if (values.Length != 0) values.Append(",");
                            values.Append(frePprECnd.CheckItemCode4.ToString());
                        }
                        if (frePprECnd.CheckItemCode5 != -1)
                        {
                            if (values.Length != 0) values.Append(",");
                            values.Append(frePprECnd.CheckItemCode5.ToString());
                        }
                        if (frePprECnd.CheckItemCode6 != -1)
                        {
                            if (values.Length != 0) values.Append(",");
                            values.Append(frePprECnd.CheckItemCode6.ToString());
                        }
                        if (frePprECnd.CheckItemCode7 != -1)
                        {
                            if (values.Length != 0) values.Append(",");
                            values.Append(frePprECnd.CheckItemCode7.ToString());
                        }
                        if (frePprECnd.CheckItemCode8 != -1)
                        {
                            if (values.Length != 0) values.Append(",");
                            values.Append(frePprECnd.CheckItemCode8.ToString());
                        }
                        if (frePprECnd.CheckItemCode9 != -1)
                        {
                            if (values.Length != 0) values.Append(",");
                            values.Append(frePprECnd.CheckItemCode9.ToString());
                        }
                        if (frePprECnd.CheckItemCode10 != -1)
                        {
                            if (values.Length != 0) values.Append(",");
                            values.Append(frePprECnd.CheckItemCode10.ToString());
                        }
                        if (values.Length != 0)
                        {
                            whereString.Append(" AND ");
                            whereString.Append(GetFieldName(frePprECnd) + " IN (" + values.ToString() + ")");
                        }
                        break;
                    }
            }
        }
        #endregion

        #endregion

        #region private methods

        #region Sql�N�G���p�ϐ����̎擾
        /// <summary>
        /// Sql�N�G���p�ϐ����̂�Ԃ��܂�(�ėp)
        /// </summary>
        /// <param name="frePprECnd">���R���[���o����</param>
        /// <returns></returns>
        private string GetFindPrNmStr(FrePprECndWork frePprECnd)
        {
            return ("@FIND" + CreateFindPara(frePprECnd));
        }
        /// <summary>
        /// Sql�N�G���p�ϐ����̂�Ԃ��܂�(�I�������p)
        /// </summary>
        /// <param name="frePprECnd">���R���[���o����</param>
        /// <returns></returns>
        private string GetFindPrNmEndStr(FrePprECndWork frePprECnd)
        {
            return ("@FINDEND" + CreateFindPara(frePprECnd));
        }
        #endregion

        #region �t�B�[���h���̎擾
        /// <summary>
        /// �t�B�[���h���̂�Ԃ��܂�
        /// </summary>
        /// <param name="frePprECnd">���R���[���o����</param>
        /// <returns>���o�Ώۂ̃t�B�[���h����</returns>
        private string GetFieldName(FrePprECndWork frePprECnd)
        {
            return CreateDataField(frePprECnd);
        }

        /// <summary>
        /// ���R���[���o�����N���X����DD���̂𐶐����܂�
        /// </summary>
        /// <param name="frePprECnd">���R���[���o����</param>
        /// <returns></returns>
        private string CreateDataField(FrePprECndWork frePprECnd)
        {
            if (frePprECnd == null) return string.Empty;
            
            if (!string.IsNullOrEmpty(frePprECnd.FileNm) && !string.IsNullOrEmpty(frePprECnd.DDName))
                return frePprECnd.FileNm + "." + frePprECnd.DDName;
            else if (!string.IsNullOrEmpty(frePprECnd.FileNm))
                return frePprECnd.FileNm;
            else if (!string.IsNullOrEmpty(frePprECnd.DDName))
                return frePprECnd.DDName;
            else return string.Empty;
        }
        /// <summary>
        /// ���R���[���o�����N���X����X�J���ϐ��p��������쐬���܂�
        /// </summary>
        /// <param name="frePprECnd">���R���[���o����</param>
        /// <returns></returns>
        private string CreateFindPara(FrePprECndWork frePprECnd)
        {
            if (frePprECnd == null) return string.Empty;

            if (!string.IsNullOrEmpty(frePprECnd.FileNm) && !string.IsNullOrEmpty(frePprECnd.DDName))
                return frePprECnd.FileNm + "_" + frePprECnd.DDName;
            else if (!string.IsNullOrEmpty(frePprECnd.FileNm))
                return frePprECnd.FileNm;
            else if (!string.IsNullOrEmpty(frePprECnd.DDName))
                return frePprECnd.DDName;
            else return string.Empty;
        } 
        #endregion

        #endregion
    }
}

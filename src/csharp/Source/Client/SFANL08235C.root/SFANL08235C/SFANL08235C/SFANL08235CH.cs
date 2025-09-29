using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// ���R���[�ʒ��o�����`�F�b�N�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �󎚍��ڃO���[�v���Ɍʂ̏������̓`�F�b�N��p�ӂ��܂�</br>
    /// <br>Programmer	: 22011 ���� ���l</br>
    /// <br>Date		: 2008.03.17</br>
    /// <br>UpdateNote	: </br>
    /// </remarks>
    static public class SFANL08235CH
    {
        #region Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ecnds"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        static public int Check_ECnd_DaillyReport(List<FrePprECnd> ecnds, out string msg)
        {
            msg = "";
            if (Check_DateTimeType_NoInput(ecnds) != 0)
            {
                msg = "���t�n�̏������Œ��͓��͂��Ă��������B";
                if (Check_DateTimeType_NoInput(ecnds) == -2)
                {
                    msg += "\n�͈͎w��^�C�v�ł͊J�n�����ƏI�������̓��͂��K�v�ł��B";
                }
                return -1;
            }

            return 0;
        }
        #endregion
        
        #region Pribate Methods
        /// <summary>
        /// ���t�^�C�v�����̓`�F�b�N(�Œ���Top,End�o�����͂���Ă���K�v�L��)
        /// </summary>
        /// <param name="ecnds">���R���[���o�����N���X�̃��X�g</param>
        /// <returns>status(0:����-���͗L��, -1:�s��-������, -2:�s��-�͈͖��� )</returns>
        static private int Check_DateTimeType_NoInput(List<FrePprECnd> ecnds)
        {
            bool inputFlg = false; //���t�̐�����͔��f�t���O (true :���͗L��,false:������) 
            bool harfInputFlg = false; //�͈̓^�C�v�ɂ�����TOP�܂͂�END�̂ݎw�肵�Ă��鎞True

            foreach (FrePprECnd ecnd in ecnds)
            {
                if (ecnd.ExtraConditionDivCd != 4) continue; // ���t���ڂłȂ����continue
                switch (ecnd.ExtraConditionTypeCd)
                {
                    case 0: // ��v
                    case 5: // ����v
                        {
                            if (ecnd.StartExtraDate != 0)
                            {
                                inputFlg = true;
                            }
                            break;
                        }
                    case 1: // �͈�
                    case 3: // ����(�J�n���)
                    case 4: // ����(�I�����)
                    case 6: // ���͈�
                        {
                            if ((ecnd.StartExtraDate != 0) && (ecnd.EndExtraDate != 0))
                            {
                                inputFlg = true;
                            }
                            if ((ecnd.StartExtraDate != 0) || (ecnd.EndExtraDate != 0))
                            {
                                harfInputFlg = true;
                            }                    
                            break;
                        }
                }
                if (inputFlg) return 0;
            }
            if (inputFlg)
            {
                return 0;
            }
            else
            {
                if (harfInputFlg)
                {
                    return -2;
                }
                return -1;
            }
        }
        #endregion
    }
}

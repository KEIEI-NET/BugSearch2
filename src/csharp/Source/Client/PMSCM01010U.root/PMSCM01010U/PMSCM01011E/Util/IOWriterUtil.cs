//****************************************************************************//
// �V�X�e��         : �����񓚏���
// �v���O��������   : �����񓚏����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���
// �� �� ��  2009/06/12  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : LDNS�̗���
// �� �� ��  2011/08/12  �C�����e : �����񓚑Ή��ASCM�Z�b�g�}�X�^���M�ł��邽��
//�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�J�X�^���R���X�g���N�^��ǉ�����
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// IOWriter�֘A����N���X
    /// </summary>
    public static class IOWriterUtil
    {
        /// <summary>
        /// IOWriter.SCMRead�̖߂�l�̓W�J����
        /// </summary>
        /// <param name="header"></param>
        /// <param name="detail"></param>
        /// <param name="answer"></param>
        /// <param name="car"></param>
        /// <param name="retObject">IOWriter.SCMRead�̖߂�l</param>
        public static void ExpandSCMReadRet(object retObject, out SCMAcOdrDataWork header, out List<SCMAcOdrDtlIqWork> detail, out List<SCMAcOdrDtlAsWork> answer, out SCMAcOdrDtCarWork car)
        {
            header = new SCMAcOdrDataWork();
            detail = new List<SCMAcOdrDtlIqWork>();
            answer = new List<SCMAcOdrDtlAsWork>();
            car = new SCMAcOdrDtCarWork();

            CustomSerializeArrayList retList = (CustomSerializeArrayList)retObject;

            foreach (object ret in retList)
            {
                if (ret is SCMAcOdrDataWork)
                {
                    header = (SCMAcOdrDataWork)ret;
                }
                else if (ret is SCMAcOdrDtCarWork)
                {
                    car = (SCMAcOdrDtCarWork)ret;
                }
                else
                {
                    foreach (object dtl in (ArrayList)ret)
                    {
                        if (dtl is SCMAcOdrDtlIqWork)
                        {
                            detail.Add((SCMAcOdrDtlIqWork)dtl);
                        }
                        // else                             // DEL 2011/08/12
                        else if (dtl is SCMAcOdrDtlAsWork)  // ADD 2011/08/12
                        {
                            answer.Add((SCMAcOdrDtlAsWork)dtl);
                        }
                    }
                }
            }
        }

        //--- ADD 2011/08/12 -------------------------------------------->>>
        /// <summary>
        /// IOWriter.SCMRead�̖߂�l�̓W�J����
        /// </summary>
        /// <param name="header"></param>
        /// <param name="detail"></param>
        /// <param name="answer"></param>
        /// <param name="setDt"></param>
        /// <param name="car"></param>
        /// <param name="retObject">IOWriter.SCMRead�̖߂�l</param>
        public static void ExpandSCMReadRet(object retObject, 
                                            out SCMAcOdrDataWork header, 
                                            out List<SCMAcOdrDtlIqWork> detail, 
                                            out List<SCMAcOdrDtlAsWork> answer,
                                            out List<SCMAcOdSetDtWork> setDt, 
                                            out SCMAcOdrDtCarWork car)
        {
            header = new SCMAcOdrDataWork();
            detail = new List<SCMAcOdrDtlIqWork>();
            answer = new List<SCMAcOdrDtlAsWork>();
            setDt = new List<SCMAcOdSetDtWork>();
            car = new SCMAcOdrDtCarWork();
            
            CustomSerializeArrayList retList = (CustomSerializeArrayList)retObject;

            foreach (object ret in retList)
            {
                if (ret is SCMAcOdrDataWork)
                {
                    header = (SCMAcOdrDataWork)ret;
                }
                else if (ret is SCMAcOdrDtCarWork)
                {
                    car = (SCMAcOdrDtCarWork)ret;
                }
                else
                {
                    foreach (object dtl in (ArrayList)ret)
                    {
                        if (dtl is SCMAcOdrDtlIqWork)
                        {
                            detail.Add((SCMAcOdrDtlIqWork)dtl);
                        }
                        else if (dtl is SCMAcOdSetDtWork)
                        {
                            setDt.Add((SCMAcOdSetDtWork)dtl);
                        }
                        else
                        {
                            answer.Add((SCMAcOdrDtlAsWork)dtl);
                        }
                    }
                }
            }
        }
        //--- ADD 2011/08/12 --------------------------------------------<<<
    }
}

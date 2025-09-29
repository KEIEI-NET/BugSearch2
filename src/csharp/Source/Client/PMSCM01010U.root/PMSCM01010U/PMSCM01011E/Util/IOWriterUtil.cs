//****************************************************************************//
// システム         : 自働回答処理
// プログラム名称   : 自働回答処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野
// 作 成 日  2009/06/12  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : LDNSの劉立
// 作 成 日  2011/08/12  修正内容 : 自動回答対応、SCMセットマスタ送信できるため
//　　　　　　　　　　　　　　　　　カスタムコンストラクタを追加する
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
    /// IOWriter関連操作クラス
    /// </summary>
    public static class IOWriterUtil
    {
        /// <summary>
        /// IOWriter.SCMReadの戻り値の展開処理
        /// </summary>
        /// <param name="header"></param>
        /// <param name="detail"></param>
        /// <param name="answer"></param>
        /// <param name="car"></param>
        /// <param name="retObject">IOWriter.SCMReadの戻り値</param>
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
        /// IOWriter.SCMReadの戻り値の展開処理
        /// </summary>
        /// <param name="header"></param>
        /// <param name="detail"></param>
        /// <param name="answer"></param>
        /// <param name="setDt"></param>
        /// <param name="car"></param>
        /// <param name="retObject">IOWriter.SCMReadの戻り値</param>
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

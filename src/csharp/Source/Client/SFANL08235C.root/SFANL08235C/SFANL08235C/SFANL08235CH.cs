using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// 自由帳票個別抽出条件チェッククラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 印字項目グループ毎に個別の条件入力チェックを用意します</br>
    /// <br>Programmer	: 22011 柏原 頼人</br>
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
                msg = "日付系の条件を最低一つは入力してください。";
                if (Check_DateTimeType_NoInput(ecnds) == -2)
                {
                    msg += "\n範囲指定タイプでは開始条件と終了条件の入力が必要です。";
                }
                return -1;
            }

            return 0;
        }
        #endregion
        
        #region Pribate Methods
        /// <summary>
        /// 日付タイプ未入力チェック(最低一つはTop,End双方入力されている必要有り)
        /// </summary>
        /// <param name="ecnds">自由帳票抽出条件クラスのリスト</param>
        /// <returns>status(0:正常-入力有り, -1:不正-未入力, -2:不正-範囲未完 )</returns>
        static private int Check_DateTimeType_NoInput(List<FrePprECnd> ecnds)
        {
            bool inputFlg = false; //日付の正常入力判断フラグ (true :入力有り,false:未入力) 
            bool harfInputFlg = false; //範囲タイプにおいてTOPまはたENDのみ指定している時True

            foreach (FrePprECnd ecnd in ecnds)
            {
                if (ecnd.ExtraConditionDivCd != 4) continue; // 日付項目でなければcontinue
                switch (ecnd.ExtraConditionTypeCd)
                {
                    case 0: // 一致
                    case 5: // 月一致
                        {
                            if (ecnd.StartExtraDate != 0)
                            {
                                inputFlg = true;
                            }
                            break;
                        }
                    case 1: // 範囲
                    case 3: // 期間(開始日基準)
                    case 4: // 期間(終了日基準)
                    case 6: // 月範囲
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

using System;
using Broadleaf.Library.Text;

namespace Broadleaf.Application.Common
{

    /// <summary>
    /// 端数処理モジュールクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 端数処理算定を行います。</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2007.09.19</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2007.09.19 對馬 大輔 新規作成</br>
    /// </remarks>
    public static class FractionCalculate
    {

        /// <summary>
        /// 金額端数処理
        /// </summary>
        /// <param name="inputCount">入力数量</param>
        /// <param name="inputMoney">入力金額</param>
        /// <param name="fractionUnit">端数処理単位</param>
        /// <param name="fractionProcess">端数処理（1:切捨 2:四捨五入 3:切上）</param>
        /// <param name="resultMoney">算出金額</param>
        public static void FracCalcMoney(double inputCount, double inputMoney, double fractionUnit, Int32 fractionProcess, out double resultMoney)
        {
            FracCalc(inputCount * inputMoney, fractionUnit, fractionProcess, out resultMoney);
        }

        /// <summary>
        /// 金額端数処理（オーバーロード）
        /// </summary>
        /// <param name="inputMoney">入力金額</param>
        /// <param name="fractionUnit">端数処理単位</param>
        /// <param name="fractionProcess">端数処理（1:切捨 2:四捨五入 3:切上）</param>
        /// <param name="resultMoney">算出金額</param>
        public static void FracCalcMoney(double inputMoney, double fractionUnit, Int32 fractionProcess, out double resultMoney)
        {
            FracCalc(inputMoney, fractionUnit, fractionProcess, out resultMoney);
        }

        /// <summary>
        /// 金額端数処理（オーバーロード）
        /// </summary>
        /// <param name="inputMoney">入力金額</param>
        /// <param name="fractionUnit">端数処理単位</param>
        /// <param name="fractionProcess">端数処理（1:切捨 2:四捨五入 3:切上）</param>
        /// <param name="resultMoney">算出金額</param>
        public static void FracCalcMoney(double inputMoney, double fractionUnit, Int32 fractionProcess, out long resultMoney)
        {
            double resultMoneyWork;
            FracCalc(inputMoney, fractionUnit, fractionProcess, out resultMoneyWork);
            resultMoney = (long)resultMoneyWork;
        }

        /// <summary>
        /// 率端数処理
        /// </summary>
        /// <param name="numerator">数値(分子)</param>
        /// <param name="denominator">数値(分母)</param>
        /// <param name="fractionUnit">端数処理単位</param>
        /// <param name="fractionProcess">端数処理（1:切捨 2:四捨五入 3:切上）</param>
        /// <param name="resultRate">算出率</param>
        public static void FracCalcRate(double numerator, double denominator, double fractionUnit, Int32 fractionProcess, out double resultRate)
        {
            resultRate = 0;
            if (denominator != 0)
            {
                double rate = (double)((decimal)numerator / (decimal)denominator);
                FracCalc(rate, fractionUnit, fractionProcess, out resultRate); // 端数処理
                resultRate = (double)((decimal)resultRate * 100);
            }
        }

        /// <summary>
        /// 端数処理
        /// </summary>
        /// <param name="inputNumerical">数値</param>
        /// <param name="fractionUnit">端数処理単位</param>
        /// <param name="fractionProcess">端数処理（1:切捨 2:四捨五入 3:切上）</param>
        /// <param name="resultNumerical">算出金額</param>
        private static void FracCalc(double inputNumerical, double fractionUnit, Int32 fractionProcess, out double resultNumerical)
        {
            // 初期値セット
            resultNumerical = inputNumerical;

			//inputNumerical -= (decimal)inputNumerical % (decimal)0.000001; // 小数点6桁以下切捨
			//fractionUnit -= (decimal)fractionUnit % (decimal)0.000001; // 小数点6桁以下切捨
			inputNumerical = (double)( (decimal)inputNumerical - ( (decimal)inputNumerical % (decimal)0.000001 ) );	// 小数点6桁以下切捨
			fractionUnit = (double)( (decimal)fractionUnit - ( (decimal)fractionUnit % (decimal)0.000001 ) );		// 小数点6桁以下切捨

            // 端数単位で除算
            decimal tmpKin = (decimal)inputNumerical / (decimal)fractionUnit;

            // マイナス補正
            bool sign = false;
            if (tmpKin < 0)
            {
                sign = true;
                tmpKin = tmpKin * (-1);
            }

            // 小数部1桁取得
            decimal tmpDecimal;
            GetFraction(tmpKin, out tmpDecimal);
            tmpDecimal = tmpDecimal * 10;

            // tmpKin 端数指定
            bool wRoundFlg = true; // 切捨
            switch (fractionProcess)
            {
                //--------------------------------------
                // 1:切捨
                //--------------------------------------
                case 1:
                    {
                        wRoundFlg = true; // 切捨
                        break;
                    }
                //--------------------------------------
                // 2:四捨五入
                //--------------------------------------
                case 2: // 四捨五入
                    {
                        if (tmpDecimal >= 5)
                        {
                            wRoundFlg = false; // 切上
                        }
                        break;
                    }
                //--------------------------------------
                // 3:切上
                //--------------------------------------
                case 3: // 切上
                    {
                        if (tmpDecimal > 0)
                        {
                            wRoundFlg = false; // 切上
                        }
                        break;
                    }
            }

            // 端数処理
            if (wRoundFlg == false)
            {
                tmpKin = tmpKin + 1;
            }

            // 小数部切捨
            GetInteger(tmpKin, out tmpKin);

            // マイナス補正
            if (sign == true)
            {
                tmpKin = tmpKin * (-1);
            }

            decimal a = (decimal)tmpKin * (decimal)fractionUnit;

            // 算出値セット
            //resultNumerical = tmpKin * fractionUnit;
            resultNumerical = (double)((decimal)tmpKin * (decimal)fractionUnit);

        }

        /// <summary>
        /// 整数部取得
        /// </summary>
        /// <param name="cEx">対象数値</param>
        /// <param name="outcEx">算出数値</param>
        private static void GetInteger(decimal cEx, out decimal outcEx)
        {
            outcEx = 0;

            string wkStr = cEx.ToString();

            int index = wkStr.IndexOf("."); // ドット位置
            if (index > 0)
            {
                wkStr = wkStr.Substring(0, index);
            }

            if (wkStr.Trim() != "")
            {
                outcEx = (decimal)TStrConv.StrToDoubleDef(wkStr, 0);
            }

        }

        /// <summary>
        /// 小数部算出
        /// </summary>
        /// <param name="cEx">対象数値</param>
        /// <param name="outcEx">算出数値</param>
        private static void GetFraction(decimal cEx, out decimal outcEx)
        {
            outcEx = 0;

            string wkStr = cEx.ToString();

            int index = wkStr.IndexOf("."); // ドット位置
            if (index > 0)
            {
                if (cEx < 0)
                {
                    // マイナス
                    wkStr = "-0." + wkStr.Substring(index + 1, wkStr.Length - index - 1);
                }
                else
                {
                    // プラス
                    wkStr = "0." + wkStr.Substring(index + 1, wkStr.Length - index - 1);
                }
            }
            else
            {
                wkStr = "0";
            }

            if (wkStr.Trim() != "")
            {
                outcEx = (decimal)TStrConv.StrToDoubleDef(wkStr, 0);
            }

        }

    }

}

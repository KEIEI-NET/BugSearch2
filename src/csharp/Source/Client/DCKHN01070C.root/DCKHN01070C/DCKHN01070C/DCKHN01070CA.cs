using System;
using Broadleaf.Library.Text;

namespace Broadleaf.Application.Common
{

    /// <summary>
    /// �[���������W���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �[�������Z����s���܂��B</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2007.09.19</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2007.09.19 ���n ��� �V�K�쐬</br>
    /// </remarks>
    public static class FractionCalculate
    {

        /// <summary>
        /// ���z�[������
        /// </summary>
        /// <param name="inputCount">���͐���</param>
        /// <param name="inputMoney">���͋��z</param>
        /// <param name="fractionUnit">�[�������P��</param>
        /// <param name="fractionProcess">�[�������i1:�؎� 2:�l�̌ܓ� 3:�؏�j</param>
        /// <param name="resultMoney">�Z�o���z</param>
        public static void FracCalcMoney(double inputCount, double inputMoney, double fractionUnit, Int32 fractionProcess, out double resultMoney)
        {
            FracCalc(inputCount * inputMoney, fractionUnit, fractionProcess, out resultMoney);
        }

        /// <summary>
        /// ���z�[�������i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="inputMoney">���͋��z</param>
        /// <param name="fractionUnit">�[�������P��</param>
        /// <param name="fractionProcess">�[�������i1:�؎� 2:�l�̌ܓ� 3:�؏�j</param>
        /// <param name="resultMoney">�Z�o���z</param>
        public static void FracCalcMoney(double inputMoney, double fractionUnit, Int32 fractionProcess, out double resultMoney)
        {
            FracCalc(inputMoney, fractionUnit, fractionProcess, out resultMoney);
        }

        /// <summary>
        /// ���z�[�������i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="inputMoney">���͋��z</param>
        /// <param name="fractionUnit">�[�������P��</param>
        /// <param name="fractionProcess">�[�������i1:�؎� 2:�l�̌ܓ� 3:�؏�j</param>
        /// <param name="resultMoney">�Z�o���z</param>
        public static void FracCalcMoney(double inputMoney, double fractionUnit, Int32 fractionProcess, out long resultMoney)
        {
            double resultMoneyWork;
            FracCalc(inputMoney, fractionUnit, fractionProcess, out resultMoneyWork);
            resultMoney = (long)resultMoneyWork;
        }

        /// <summary>
        /// ���[������
        /// </summary>
        /// <param name="numerator">���l(���q)</param>
        /// <param name="denominator">���l(����)</param>
        /// <param name="fractionUnit">�[�������P��</param>
        /// <param name="fractionProcess">�[�������i1:�؎� 2:�l�̌ܓ� 3:�؏�j</param>
        /// <param name="resultRate">�Z�o��</param>
        public static void FracCalcRate(double numerator, double denominator, double fractionUnit, Int32 fractionProcess, out double resultRate)
        {
            resultRate = 0;
            if (denominator != 0)
            {
                double rate = (double)((decimal)numerator / (decimal)denominator);
                FracCalc(rate, fractionUnit, fractionProcess, out resultRate); // �[������
                resultRate = (double)((decimal)resultRate * 100);
            }
        }

        /// <summary>
        /// �[������
        /// </summary>
        /// <param name="inputNumerical">���l</param>
        /// <param name="fractionUnit">�[�������P��</param>
        /// <param name="fractionProcess">�[�������i1:�؎� 2:�l�̌ܓ� 3:�؏�j</param>
        /// <param name="resultNumerical">�Z�o���z</param>
        private static void FracCalc(double inputNumerical, double fractionUnit, Int32 fractionProcess, out double resultNumerical)
        {
            // �����l�Z�b�g
            resultNumerical = inputNumerical;

			//inputNumerical -= (decimal)inputNumerical % (decimal)0.000001; // �����_6���ȉ��؎�
			//fractionUnit -= (decimal)fractionUnit % (decimal)0.000001; // �����_6���ȉ��؎�
			inputNumerical = (double)( (decimal)inputNumerical - ( (decimal)inputNumerical % (decimal)0.000001 ) );	// �����_6���ȉ��؎�
			fractionUnit = (double)( (decimal)fractionUnit - ( (decimal)fractionUnit % (decimal)0.000001 ) );		// �����_6���ȉ��؎�

            // �[���P�ʂŏ��Z
            decimal tmpKin = (decimal)inputNumerical / (decimal)fractionUnit;

            // �}�C�i�X�␳
            bool sign = false;
            if (tmpKin < 0)
            {
                sign = true;
                tmpKin = tmpKin * (-1);
            }

            // ������1���擾
            decimal tmpDecimal;
            GetFraction(tmpKin, out tmpDecimal);
            tmpDecimal = tmpDecimal * 10;

            // tmpKin �[���w��
            bool wRoundFlg = true; // �؎�
            switch (fractionProcess)
            {
                //--------------------------------------
                // 1:�؎�
                //--------------------------------------
                case 1:
                    {
                        wRoundFlg = true; // �؎�
                        break;
                    }
                //--------------------------------------
                // 2:�l�̌ܓ�
                //--------------------------------------
                case 2: // �l�̌ܓ�
                    {
                        if (tmpDecimal >= 5)
                        {
                            wRoundFlg = false; // �؏�
                        }
                        break;
                    }
                //--------------------------------------
                // 3:�؏�
                //--------------------------------------
                case 3: // �؏�
                    {
                        if (tmpDecimal > 0)
                        {
                            wRoundFlg = false; // �؏�
                        }
                        break;
                    }
            }

            // �[������
            if (wRoundFlg == false)
            {
                tmpKin = tmpKin + 1;
            }

            // �������؎�
            GetInteger(tmpKin, out tmpKin);

            // �}�C�i�X�␳
            if (sign == true)
            {
                tmpKin = tmpKin * (-1);
            }

            decimal a = (decimal)tmpKin * (decimal)fractionUnit;

            // �Z�o�l�Z�b�g
            //resultNumerical = tmpKin * fractionUnit;
            resultNumerical = (double)((decimal)tmpKin * (decimal)fractionUnit);

        }

        /// <summary>
        /// �������擾
        /// </summary>
        /// <param name="cEx">�Ώې��l</param>
        /// <param name="outcEx">�Z�o���l</param>
        private static void GetInteger(decimal cEx, out decimal outcEx)
        {
            outcEx = 0;

            string wkStr = cEx.ToString();

            int index = wkStr.IndexOf("."); // �h�b�g�ʒu
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
        /// �������Z�o
        /// </summary>
        /// <param name="cEx">�Ώې��l</param>
        /// <param name="outcEx">�Z�o���l</param>
        private static void GetFraction(decimal cEx, out decimal outcEx)
        {
            outcEx = 0;

            string wkStr = cEx.ToString();

            int index = wkStr.IndexOf("."); // �h�b�g�ʒu
            if (index > 0)
            {
                if (cEx < 0)
                {
                    // �}�C�i�X
                    wkStr = "-0." + wkStr.Substring(index + 1, wkStr.Length - index - 1);
                }
                else
                {
                    // �v���X
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

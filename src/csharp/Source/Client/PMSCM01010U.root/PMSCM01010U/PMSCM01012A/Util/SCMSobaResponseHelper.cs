//****************************************************************************//
// �V�X�e��         : �����񓚏���
// �v���O��������   : �����񓚏����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/05/22  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Diagnostics;

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.UIData;
using Broadleaf.RCDS.Web.Services;

namespace Broadleaf.Application.Controller.Util
{
    using SCMMarketPriceServer = SingletonInstance<SCMMarketPriceAgent>;    // SCM���ꉿ�i�ݒ�}�X�^

    /// <summary>
    /// SCM�����񃌃X�|���X�̃w���p�N���X
    /// </summary>
    public class SCMSobaResponseHelper
    {
        private const string MY_NAME = "SCMSobaResponseHelper"; // ���O�p

        #region <SCM���ꉿ�i�ݒ�>

        /// <summary>SCM���ꉿ�i�ݒ�</summary>
        private readonly SCMMrktPriSt _marketPriceSetting;
        /// <summary>SCM���ꉿ�i�ݒ���擾���܂��B</summary>
        private SCMMrktPriSt MarketPriceSetting {  get { return _marketPriceSetting; } }

        /// <summary>���ꉿ�i��ʔԍ�</summary>
        private readonly int _marketPriceKindNo;
        /// <summary>���ꉿ�i��ʔԍ����擾���܂��B</summary>
        private int MarketPriceKindNo { get { return _marketPriceKindNo; } }

        /// <summary>
        /// ���ꉿ�i�ݒ�}�X�^���擾���܂��B
        /// </summary>
        private static SCMMarketPriceAgent MarketPriceDB
        {
            get { return SCMMarketPriceServer.Singleton.Instance; }
        }

        #endregion // </SCM���ꉿ�i�ݒ�>

        #region <�{���̃��X�|���X>

        /// <summary>�{���̃��X�|���X</summary>
        private readonly GetSobaResType _realResponse;
        /// <summary>�{���̃��X�|���X���擾���܂��B</summary>
        public GetSobaResType RealResponse { get { return _realResponse; } }

        /// <summary>
        /// �����񂪑��݂��邩���f���܂��B
        /// </summary>
        public bool Exists
        {
            get { return RealResponse != null && Count > 0; }
        }

        #endregion // </�{���̃��X�|���X>

        #region <Constructor>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="marketPriceSetting">���ꉿ�i�ݒ�</param>
        /// <param name="marketPriceKindNo">���ꉿ�i��ʔԍ�</param>
        /// <param name="realResponse">�{���̃��X�|���X</param>
        public SCMSobaResponseHelper(
            SCMMrktPriSt marketPriceSetting,
            int marketPriceKindNo,
            GetSobaResType realResponse
        )
        {
            _marketPriceSetting = marketPriceSetting;
            _marketPriceKindNo  = marketPriceKindNo;
            _realResponse       = realResponse;
        }

        #endregion // </Constructor>

        /// <summary>
        /// �������擾���܂��B
        /// </summary>
        private int Count
        {
            get
            {
                if (RealResponse == null || RealResponse.SobaList == null)
                {
                    return 0;
                }
                return RealResponse.SobaList[0].Cnt;
            }
        }

        /// <summary>
        /// ���ꉿ�i��ʃR�[�h���擾���܂��B
        /// </summary>
        public int MarketPriceKindCd
        {
            get
            {
                return SCMMarketPriceAgent.GetMarketPriceKindCd(MarketPriceSetting, MarketPriceKindNo);
            }
        }

        /// <summary>
        /// ���ꉿ�i��ʖ��̂��擾���܂��B
        /// </summary>
        public string MarketPriceKindNm
        {
            get
            {
                return MarketPriceDB.GetMarketPriceKindNm(MarketPriceSetting, MarketPriceKindNo);
            }
        }

        /// <summary>
        /// ���ꉿ�i���擾���܂��B
        /// </summary>
        /// <returns>���ꉿ�i</returns>
        public long GetMarketPrice()
        {
            const string METHOD_NAME = "GetMarketPrice()";  // ���O�p

            #region <Guard Phrase>

            if (!Exists) return 0;
            if (MarketPriceSetting == null) return 0;

            #endregion // </Guard Phrase>

            double marketPriceResponse = (double)RealResponse.SobaList[0].StdDev;   // �W���΍�����

            // ���ꉿ�i�񓚋敪���u1:����(������)�v�̏ꍇ
            if (MarketPriceSetting.MarketPriceAnswerDiv.Equals((int)MarketPriceAnswerDiv.Rate))
            {
                #region <Log>

                string msg = "���������瑊�ꉿ�i���Z�o";
                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                #endregion // </Log>

                double marketPriceSalesRate = MarketPriceSetting.MarketPriceSalesRate / 100.0;  // ��100.0% �� 100.0

                long marketPrice = RoundingOff(
                    marketPriceResponse * marketPriceSalesRate,
                    MarketPriceSetting.FractionProcCd
                );
                return marketPrice;
            }

            // ���ꉿ�i�񓚋敪���u2:����(���Z�e�[�u��)�v�̏ꍇ
            if (MarketPriceSetting.MarketPriceAnswerDiv.Equals((int)MarketPriceAnswerDiv.Table))
            {
                #region <Log>

                string msg = "���Z�e�[�u�����瑊�ꉿ�i���Z�o";
                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                #endregion // </Log>

                long marketPrice = GetMarketPriceFromAddTable(marketPriceResponse, MarketPriceSetting);
                return marketPrice;
            }

            return 0;
        }

        #region <���ꉿ�i�̎Z�o>

        /// <summary>
        /// ���ꉿ�i�����Z�e�[�u�����擾���܂��B
        /// </summary>
        /// <param name="marketPrice">���ꉿ�i</param>
        /// <param name="marketPriceSetting">SCM���ꉿ�i�ݒ�</param>
        /// <returns></returns>
        private static long GetMarketPriceFromAddTable(
            double marketPrice,
            SCMMrktPriSt marketPriceSetting
        )
        {
            long nMarketPrice = (long)marketPrice;
            {
                // 1�ȏ�`�����~����(���Z�͈�1)
                if (1.0 <= marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit1)
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt1;
                }
                // ���Z�z�͈�1�𒴂��`�����~�ȉ�(���Z�͈�2)
                else if ((double)marketPriceSetting.AddPaymntAmbit1 < marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit2)
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt2;
                }
                // ���Z�z�͈�2�𒴂��`�����~�ȉ�(���Z�͈�3)
                else if ((double)marketPriceSetting.AddPaymntAmbit2 < marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit3)
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt3;
                }
                // ���Z�z�͈�3�𒴂��`�����~�ȉ�(���Z�͈�4)
                else if ((double)marketPriceSetting.AddPaymntAmbit3 < marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit4)
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt4;
                }
                // ���Z�z�͈�4�𒴂��`�����~�ȉ�(���Z�͈�5)
                else if ((double)marketPriceSetting.AddPaymntAmbit4 < marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit5)
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt5;
                }
                // ���Z�z�͈�5�𒴂��`�����~�ȉ�(���Z�͈�6)
                else if ((double)marketPriceSetting.AddPaymntAmbit5 < marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit6)
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt6;
                }
                // ���Z�z�͈�6�𒴂��`�����~�ȉ�(���Z�͈�7)
                else if ((double)marketPriceSetting.AddPaymntAmbit6 < marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit7)
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt7;
                }
                // ���Z�z�͈�7�𒴂��`�����~�ȉ�(���Z�͈�8)
                else if ((double)marketPriceSetting.AddPaymntAmbit7 < marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit8)
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt8;
                }
                // ���Z�z�͈�8�𒴂��`�����~�ȉ�(���Z�͈�9)
                else if ((double)marketPriceSetting.AddPaymntAmbit8 < marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit9)
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt9;
                }
                // ���Z�z�͈�9�𒴂��`�����~�ȉ�(���Z�͈�10)
                else if ((double)marketPriceSetting.AddPaymntAmbit9 < marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit10)
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt10;
                }
            }
            nMarketPrice = RoundingOff((double)nMarketPrice, marketPriceSetting.FractionProcCd);
            return nMarketPrice;
        }

        /// <summary>
        /// ���ꉿ�i���l�̌ܓ����܂��B
        /// </summary>
        /// <param name="marketPrice">���ꉿ�i</param>
        /// <param name="fractionProcCd">�[�������敪</param>
        /// <returns>�l�̌ܓ��������ꉿ�i</returns>
        private static long RoundingOff(
            double marketPrice,
            int fractionProcCd
        )
        {
            long nMarketPrice = (long)marketPrice;
            int targetIndex = -1;
            int addValue = 0;
            switch (fractionProcCd)
            {
                case (int)FractionProcCd.RoundingOff10Yen:
                    {
                        if (marketPrice <= 10.0) return nMarketPrice;
                        targetIndex = nMarketPrice.ToString().Length - 1;
                        addValue = 10;
                        break;
                    }
                case (int)FractionProcCd.RoundingOff100Yen:
                    {
                        if (marketPrice <= 100.0) return nMarketPrice;
                        targetIndex = nMarketPrice.ToString().Length - 2;
                        addValue = 100;
                        break;
                    }
                default:
                    return nMarketPrice;
            }
            string strMarketPrice = nMarketPrice.ToString();

            // �Ώی��ȍ~��0�ɐݒ�
            char[] chrMarketPrices = strMarketPrice.ToCharArray();
            for (int i = strMarketPrice.Length - 1; i > targetIndex; i--)
            {
                chrMarketPrices[i] = '0';
            }
            
            if (int.Parse(chrMarketPrices[targetIndex].ToString()) <= 4)
            {
                // �l��
                chrMarketPrices[targetIndex] = '0';
                strMarketPrice = new string(chrMarketPrices);
                addValue = 0;
            }
            else
            {   
                // �ܓ�
                chrMarketPrices[targetIndex] = '0';
                strMarketPrice = new string(chrMarketPrices);
            }
            nMarketPrice = long.Parse(strMarketPrice) + addValue;

            return nMarketPrice;
        }

        #endregion // </���ꉿ�i�̎Z�o>
    }
}

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.RCDS.Web.Services;
using System.Web.Services.Protocols;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ����Web�T�[�r�X�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �V�K�쐬 (���Q�l:PMSCM01010U)</br>
    /// <br>Programmer : 22018�@��� ���b</br>
    /// <br>Date       : 2010/06/17</br>
    /// </remarks>
    public class SobaServiceAcs
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region �� Private Member
        /// <summary>����T�[�r�X</summary>
        private SobaService _sobaService;

        /// <summary>���ꉿ�i��ʂ̃}�b�v</summary>
        private IDictionary<string, GetKindListResType> _marketPriceKindMap;
        /// <summary>���ꉿ�i�i���̃}�b�v</summary>
        private IDictionary<string, GetQualityListResType> _marketPriceQualityMap;
        /// <summary>���ꉿ�i�n��̃}�b�v</summary>
        private IDictionary<string, GetAreaListResType> _marketPriceAreaMap;
        #endregion

        // ===================================================================================== //
        // �񋓑�
        // ===================================================================================== //
        #region �� private Enum
        /// <summary>
        /// ���ꉿ�i��ʃR�[�h�񋓌^
        /// </summary>
        private enum MarketPriceKindCd : int
        {
            /// <summary>�Ȃ�</summary>
            None = -1,
            /// <summary>�V�i</summary>
            New = 0,
            /// <summary>���r���g</summary>
            Rebuild = 1,
            /// <summary>����</summary>
            Used = 2
        }

        /// <summary>
        /// ���ꉿ�i�񓚋敪�񋓌^
        /// </summary>
        private enum MarketPriceAnswerDiv : int
        {
            /// <summary>0:���Ȃ�</summary>
            None = 0,
            /// <summary>1:����(������)</summary>
            Rate = 1,
            /// <summary>2:����(���Z�e�[�u��)</summary>
            Table = 2
        }

        /// <summary>
        /// �[�������敪�񋓌^
        /// </summary>
        private enum FractionProcCd : int
        {
            /// <summary>10�~�P��(�l�̌ܓ�)</summary>
            RoundingOff10Yen = 0,
            /// <summary>100�~�P��(�l�̌ܓ�)</summary>
            RoundingOff100Yen = 1
        }
        #endregion

        // ===================================================================================== //
        // �N���X
        // ===================================================================================== //
        #region �� class
        /// <summary>
        /// ����擾���i�����N�G�X�g�ƃ��X�|���X���܂Ƃ߂�j
        /// </summary>
        public class GetSobaResTypeUnitData
        {
            private int _index;
            private GetSobaReqType _getSobaReqType;
            private GetSobaResType _getSobaResType;

            /// <summary>
            /// ���ꉿ�i�}�X�^��̉��Ԗڂ̐ݒ肩��\��index
            /// </summary>
            public int Index
            {
                get { return _index; }
                set { _index = value; }
            }
            /// <summary>
            /// ���N�G�X�g(����)
            /// </summary>
            public GetSobaReqType GetSobaReqType
            {
                get { return _getSobaReqType; }
                set { _getSobaReqType = value; }
            }
            /// <summary>
            /// ���X�|���X(����)
            /// </summary>
            public GetSobaResType GetSobaResType
            {
                get { return _getSobaResType; }
                set { _getSobaResType = value; }
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="getSobaResType"></param>
            public GetSobaResTypeUnitData( GetSobaReqType getSobaReqType, GetSobaResType getSobaResType, int index )
            {
                _index = index;
                _getSobaReqType = getSobaReqType;
                _getSobaResType = getSobaResType;
            }
        }
        #endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        #region �� Property
        /// <summary>���ꉿ�i��ʂ̃}�b�v���擾���܂��B</summary>
        /// <remarks>�L�[�F��ƃR�[�h</remarks>
        private IDictionary<string, GetKindListResType> MarketPriceKindMap
        {
            get
            {
                if ( _marketPriceKindMap == null )
                {
                    _marketPriceKindMap = new Dictionary<string, GetKindListResType>();
                }
                return _marketPriceKindMap;
            }
        }
        /// <summary>���ꉿ�i�i���̃}�b�v���擾���܂��B</summary>
        /// <remarks>�L�[�F��ƃR�[�h</remarks>
        private IDictionary<string, GetQualityListResType> MarketPriceQualityMap
        {
            get
            {
                if ( _marketPriceQualityMap == null )
                {
                    _marketPriceQualityMap = new Dictionary<string, GetQualityListResType>();
                }
                return _marketPriceQualityMap;
            }
        }
        /// <summary>���ꉿ�i�n��̃}�b�v���擾���܂��B</summary>
        /// <remarks>�L�[�F��ƃR�[�h</remarks>
        private IDictionary<string, GetAreaListResType> MarketPriceAreaMap
        {
            get
            {
                if ( _marketPriceAreaMap == null )
                {
                    _marketPriceAreaMap = new Dictionary<string, GetAreaListResType>();
                }
                return _marketPriceAreaMap;
            }
        }
        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        #region �� Costructor
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public SobaServiceAcs()
        {
        }
        #endregion

        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        #region �� Public Method
        # region [���ꉿ�i���擾]
        /// <summary>
        /// ���ꉿ�i���擾
        /// </summary>
        /// <param name="marketPriceAcqCond"></param>
        /// <param name="scmMrktPriSt"></param>
        /// <returns></returns>
        public List<GetSobaResTypeUnitData> GetSobaResponce( MarketPriceAcqCond marketPriceAcqCond, SCMMrktPriSt scmMrktPriSt )
        {
            // �ԋp���X�g������
            List<GetSobaResTypeUnitData> getSobaResTypeList = new List<GetSobaResTypeUnitData>();

            // ����T�[�r�X����
            if ( _sobaService == null )
            {
                _sobaService = new SobaService();
            }

            // ���i��ʃ��X�g
            List<int> kindCdList = new List<int>();
            kindCdList.Add( scmMrktPriSt.MarketPriceKindCd1 );
            kindCdList.Add( scmMrktPriSt.MarketPriceKindCd2 );
            kindCdList.Add( scmMrktPriSt.MarketPriceKindCd3 );

            for ( int index = 0; index < kindCdList.Count; index++ )
            {
                // �����l�Ȃ�I��i-1:�Ȃ�, 0:�V�i, 1:���r���g, 2:���Áj
                if ( kindCdList[index] < 0 ) continue;

                // ������擾
                GetSobaResTypeUnitData sobaRes = GetSobaResponceProc( marketPriceAcqCond, scmMrktPriSt, index );
                if ( sobaRes != null )
                {
                    getSobaResTypeList.Add( sobaRes );
                }
            }

            return getSobaResTypeList;
        }
        # endregion

        # region [���ꉿ�i�Z�o]
        /// <summary>
        /// ���ꉿ�i�Z�o����
        /// </summary>
        /// <param name="sobaRes"></param>
        /// <param name="scmMrktPriSt"></param>
        /// <returns></returns>
        public static long GetMarketPrice( GetSobaResType sobaRes, SCMMrktPriSt scmMrktPriSt )
        {
            if ( sobaRes.SobaList != null && sobaRes.SobaList.Length > 0 )
            {
                double marketPriceResponse = (double)sobaRes.SobaList[0].StdDev;   // �W���΍�����

                if ( scmMrktPriSt.MarketPriceAnswerDiv.Equals( (int)MarketPriceAnswerDiv.Rate ) )
                {
                    // ���ꉿ�i�񓚋敪���u1:����(������)�v�̏ꍇ
                    double marketPriceSalesRate = scmMrktPriSt.MarketPriceSalesRate / 100.0;  // ��100.0% �� 100.0
                    long marketPrice = RoundingOff( marketPriceResponse * marketPriceSalesRate, scmMrktPriSt.FractionProcCd );
                    return marketPrice;
                }
                else if ( scmMrktPriSt.MarketPriceAnswerDiv.Equals( (int)MarketPriceAnswerDiv.Table ) )
                {
                    // ���ꉿ�i�񓚋敪���u2:����(���Z�e�[�u��)�v�̏ꍇ
                    long marketPrice = GetMarketPriceFromAddTable( marketPriceResponse, scmMrktPriSt );
                    return marketPrice;
                }
            }

            return 0;
        }
        # endregion

        # region [���̎擾]
        /// <summary>
        /// ���ꉿ�i��ʖ��̂��擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="marketPriceKindCd">��ʃR�[�h</param>
        /// <returns>���ꉿ�i��ʖ���</returns>
        public string GetMarketPriceKindNm( string enterpriseCode, int marketPriceKindCd )
        {
            GetKindListResType foundKindListResponse = null;
            if ( MarketPriceKindMap.ContainsKey( enterpriseCode ) )
            {
                foundKindListResponse = MarketPriceKindMap[enterpriseCode];
            }
            else
            {
                try
                {
                    // ���ꉿ�i��ʂ̏��擾
                    GetKindListReqType request = new GetKindListReqType();
                    {
                        request.UC = enterpriseCode; // ��ƃR�[�h
                    }
                    KindService kindService = new KindService();
                    {
                        foundKindListResponse = kindService.GetKindList( request );
                    }
                    MarketPriceKindMap.Add( enterpriseCode, foundKindListResponse );
                }
                catch ( SoapException ex )
                {
                    foundKindListResponse = null;
                }
            }
            if ( foundKindListResponse == null ) return string.Empty;

            foreach ( KindType kindType in foundKindListResponse.KindList )
            {
                if ( marketPriceKindCd.Equals( kindType.KindCode ) ) return kindType.KindName;
            }
            return string.Empty;
        }
        /// <summary>
        /// ���ꉿ�i�i�����̂��擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="marketPriceKindCd">�i���R�[�h</param>
        /// <returns>���ꉿ�i�i������</returns>
        public string GetMarketPriceQualityNm( string enterpriseCode, int marketPriceQualityCd )
        {
            GetQualityListResType foundQualityListResponse = null;
            if ( MarketPriceQualityMap.ContainsKey( enterpriseCode ) )
            {
                foundQualityListResponse = MarketPriceQualityMap[enterpriseCode];
            }
            else
            {
                try
                {
                    // ���ꉿ�i��ʂ̕i���擾
                    GetQualityListReqType request = new GetQualityListReqType();
                    {
                        request.UC = enterpriseCode; // ��ƃR�[�h
                    }
                    QualityService QualityService = new QualityService();
                    {
                        foundQualityListResponse = QualityService.GetQualityList( request );
                    }
                    MarketPriceQualityMap.Add( enterpriseCode, foundQualityListResponse );
                }
                catch ( SoapException ex )
                {
                    foundQualityListResponse = null;
                }
            }
            if ( foundQualityListResponse == null ) return string.Empty;

            foreach ( QualityType QualityType in foundQualityListResponse.QualityList )
            {
                if ( marketPriceQualityCd.Equals( QualityType.QualityCode ) ) return QualityType.QualityName;
            }
            return string.Empty;
        }
        /// <summary>
        /// ���ꉿ�i�n�於�̂��擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="marketPriceKindCd">�n��R�[�h</param>
        /// <returns>���ꉿ�i�n�於��</returns>
        public string GetMarketPriceAreaNm( string enterpriseCode, int marketPriceAreaCd )
        {
            GetAreaListResType foundAreaListResponse = null;
            if ( MarketPriceAreaMap.ContainsKey( enterpriseCode ) )
            {
                foundAreaListResponse = MarketPriceAreaMap[enterpriseCode];
            }
            else
            {
                try
                {
                    // ���ꉿ�i�n��̏��擾
                    GetAreaListReqType request = new GetAreaListReqType();
                    {
                        request.UC = enterpriseCode; // ��ƃR�[�h
                    }
                    AreaService AreaService = new AreaService();
                    {
                        foundAreaListResponse = AreaService.GetAreaList( request );
                    }
                    MarketPriceAreaMap.Add( enterpriseCode, foundAreaListResponse );
                }
                catch ( SoapException ex )
                {
                    foundAreaListResponse = null;
                }
            }
            if ( foundAreaListResponse == null ) return string.Empty;

            foreach ( AreaType AreaType in foundAreaListResponse.AreaList )
            {
                if ( marketPriceAreaCd.Equals( AreaType.AreaCode ) ) return AreaType.AreaName;
            }
            return string.Empty;
        }
        # endregion
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        #region �� Private Method

        # region [���ꉿ�i���擾]
        /// <summary>
        /// ���ꉿ�i���擾����
        /// </summary>
        /// <param name="marketPriceAcqCond"></param>
        /// <param name="scmMrktPriSt"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private GetSobaResTypeUnitData GetSobaResponceProc( MarketPriceAcqCond marketPriceAcqCond, SCMMrktPriSt scmMrktPriSt, int index )
        {
            try
            {
                // ���ꃊ�N�G�X�g����
                GetSobaReqType request = CreateSobaRequest( marketPriceAcqCond, scmMrktPriSt, index );

                // ������擾
                GetSobaResType response = _sobaService.GetSoba( request );

                // ���ʂ��擾�ł��Ȃ��������A�܂���
                // �擾�������ʂ̋��z���[���̏ꍇ�̓f�[�^�Ȃ��Ɣ��f����
                if ( response == null ||
                     response.SobaList == null || 
                     response.SobaList.Length == 0 || 
                     response.SobaList[0].StdDev == 0 )
                {
                    return null;
                }

                return new GetSobaResTypeUnitData( request, response, index );
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        # endregion

        # region [���ꃊ�N�G�X�g��������]
        /// <summary>
        /// ���ꃊ�N�G�X�g��������
        /// </summary>
        /// <param name="marketPriceAcqCond"></param>
        /// <param name="scmMrktPriSt"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private GetSobaReqType CreateSobaRequest( MarketPriceAcqCond marketPriceAcqCond, SCMMrktPriSt scmMrktPriSt, int index )
        {
            GetSobaReqType request = new GetSobaReqType();

            request.UC = marketPriceAcqCond.EnterpriseCode; // ��ƃR�[�h�F���O�C�����
            request.AT = marketPriceAcqCond.AaccessTicket; // �A�N�Z�X�`�P�b�g
            request.GC = marketPriceAcqCond.GenerationCode; // �W�F�l���[�V�����R�[�h

            request.BLCodeList = GetBLCodeList( marketPriceAcqCond ); // BL�R�[�h
            request.Model = marketPriceAcqCond.RelevanceModel; // �֘A�^��
            request.AreaCode = scmMrktPriSt.MarketPriceAreaCd;  // �n��R�[�h
            request.KindCode = GetMarketPriceKindCd( scmMrktPriSt, index ); // ��ʃR�[�h(cd1 or cd2 or cd3)
            request.QualityCode = GetMarketPriceQualityCd( scmMrktPriSt, index ); // �i���R�[�h(cd1 or cd2 or cd3)
            request.MtDateTime = new MtDateTimeType();

            return request;
        }
        /// <summary>
        /// BL�R�[�h���X�g�擾
        /// </summary>
        /// <param name="marketPriceAcqCond"></param>
        /// <returns></returns>
        private BLCodeType[] GetBLCodeList( MarketPriceAcqCond marketPriceAcqCond )
        {
            BLCodeType[] blCodeList = new BLCodeType[1];
            blCodeList[0] = new BLCodeType();
            blCodeList[0].BLCode = marketPriceAcqCond.BLGoodsCode.ToString();
            return blCodeList;
        }
        /// <summary>
        /// ���ꉿ�i��ʃR�[�h�擾
        /// </summary>
        /// <param name="marketPriceSetting"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private int GetMarketPriceKindCd( SCMMrktPriSt marketPriceSetting, int index )
        {
            switch ( index )
            {
                case 0: // ���ꉿ�i��ʃR�[�h1
                    return marketPriceSetting.MarketPriceKindCd1;
                case 1: // ���ꉿ�i��ʃR�[�h2
                    return marketPriceSetting.MarketPriceKindCd2;
                case 2: // ���ꉿ�i��ʃR�[�h3
                    return marketPriceSetting.MarketPriceKindCd3;
                default:
                    return marketPriceSetting.MarketPriceKindCd1;
            }
        }
        /// <summary>
        /// ���ꉿ�i�i���R�[�h�擾
        /// </summary>
        /// <param name="marketPriceSetting"></param>
        /// <param name="marketPriceQualityCd"></param>
        /// <returns></returns>
        private int GetMarketPriceQualityCd( SCMMrktPriSt marketPriceSetting, int index )
        {
            switch ( index )
            {
                case 0: // ���ꉿ�i�i���R�[�h1
                    return marketPriceSetting.MarketPriceQualityCd;
                case 1: // ���ꉿ�i�i���R�[�h2
                    return marketPriceSetting.MarketPriceQualityCd2;
                case 2: // ���ꉿ�i�i���R�[�h3
                    return marketPriceSetting.MarketPriceQualityCd3;
                default:
                    return marketPriceSetting.MarketPriceQualityCd;
            }
        }
        # endregion

        # region [���ꉿ�i�Z�o�p]
        /// <summary>
        /// ���ꉿ�i�����Z�e�[�u�����擾���܂��B
        /// </summary>
        /// <param name="marketPrice">���ꉿ�i</param>
        /// <param name="marketPriceSetting">SCM���ꉿ�i�ݒ�</param>
        /// <returns></returns>
        private static long GetMarketPriceFromAddTable( double marketPrice, SCMMrktPriSt marketPriceSetting )
        {
            long nMarketPrice = (long)marketPrice;
            {
                // 1�ȏ�`�����~����(���Z�͈�1)
                if ( 1.0 <= marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit1 )
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt1;
                }
                // ���Z�z�͈�1�𒴂��`�����~�ȉ�(���Z�͈�2)
                else if ( (double)marketPriceSetting.AddPaymntAmbit1 < marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit2 )
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt2;
                }
                // ���Z�z�͈�2�𒴂��`�����~�ȉ�(���Z�͈�3)
                else if ( (double)marketPriceSetting.AddPaymntAmbit2 < marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit3 )
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt3;
                }
                // ���Z�z�͈�3�𒴂��`�����~�ȉ�(���Z�͈�4)
                else if ( (double)marketPriceSetting.AddPaymntAmbit3 < marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit4 )
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt4;
                }
                // ���Z�z�͈�4�𒴂��`�����~�ȉ�(���Z�͈�5)
                else if ( (double)marketPriceSetting.AddPaymntAmbit4 < marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit5 )
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt5;
                }
                // ���Z�z�͈�5�𒴂��`�����~�ȉ�(���Z�͈�6)
                else if ( (double)marketPriceSetting.AddPaymntAmbit5 < marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit6 )
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt6;
                }
                // ���Z�z�͈�6�𒴂��`�����~�ȉ�(���Z�͈�7)
                else if ( (double)marketPriceSetting.AddPaymntAmbit6 < marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit7 )
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt7;
                }
                // ���Z�z�͈�7�𒴂��`�����~�ȉ�(���Z�͈�8)
                else if ( (double)marketPriceSetting.AddPaymntAmbit7 < marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit8 )
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt8;
                }
                // ���Z�z�͈�8�𒴂��`�����~�ȉ�(���Z�͈�9)
                else if ( (double)marketPriceSetting.AddPaymntAmbit8 < marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit9 )
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt9;
                }
                // ���Z�z�͈�9�𒴂��`�����~�ȉ�(���Z�͈�10)
                else if ( (double)marketPriceSetting.AddPaymntAmbit9 < marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit10 )
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt10;
                }
            }
            nMarketPrice = RoundingOff( (double)nMarketPrice, marketPriceSetting.FractionProcCd );
            return nMarketPrice;
        }
        /// <summary>
        /// ���ꉿ�i���l�̌ܓ����܂��B
        /// </summary>
        /// <param name="marketPrice">���ꉿ�i</param>
        /// <param name="fractionProcCd">�[�������敪</param>
        /// <returns>�l�̌ܓ��������ꉿ�i</returns>
        private static long RoundingOff( double marketPrice, int fractionProcCd )
        {
            long nMarketPrice = (long)marketPrice;
            int targetIndex = -1;
            int addValue = 0;
            switch ( fractionProcCd )
            {
                case (int)FractionProcCd.RoundingOff10Yen:
                    {
                        if ( marketPrice <= 10.0 ) return nMarketPrice;
                        targetIndex = nMarketPrice.ToString().Length - 1;
                        addValue = 10;
                        break;
                    }
                case (int)FractionProcCd.RoundingOff100Yen:
                    {
                        if ( marketPrice <= 100.0 ) return nMarketPrice;
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
            for ( int i = strMarketPrice.Length - 1; i > targetIndex; i-- )
            {
                chrMarketPrices[i] = '0';
            }

            if ( int.Parse( chrMarketPrices[targetIndex].ToString() ) <= 4 )
            {
                // �l��
                chrMarketPrices[targetIndex] = '0';
                strMarketPrice = new string( chrMarketPrices );
                addValue = 0;
            }
            else
            {
                // �ܓ�
                chrMarketPrices[targetIndex] = '0';
                strMarketPrice = new string( chrMarketPrices );
            }
            nMarketPrice = long.Parse( strMarketPrice ) + addValue;

            return nMarketPrice;
        }
        # endregion

        #endregion

    }
}

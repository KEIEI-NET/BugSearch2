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
// �Ǘ��ԍ�              �쐬�S�� : ���X�� ��
// �� �� ��  2010/03/12  �C�����e : ������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2010/04/22  �C�����e : ������͑��ꉿ�i ��ʃR�[�h# - �i���R�[�h# �Ŏ擾(SCM���ꉿ�i�ݒ�}�X�^�̕ύX)
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Web.Services.Protocols;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;
using Broadleaf.RCDS.Web.Services;

using System.Collections;       // 2010/03/12 Add


namespace Broadleaf.Application.Controller.Agent
{
    using RealAccesserType  = SCMMrktPriStAcs;
    using RecordType        = SCMMrktPriSt;

    /// <summary>
    /// ���ꉿ�i��ʃR�[�h�񋓌^
    /// </summary>
    public enum MarketPriceKindCd : int
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
    public enum MarketPriceAnswerDiv : int
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
    public enum FractionProcCd : int
    {
        /// <summary>10�~�P��(�l�̌ܓ�)</summary>
        RoundingOff10Yen = 0,
        /// <summary>100�~�P��(�l�̌ܓ�)</summary>
        RoundingOff100Yen = 1
    }

    /// <summary>
    /// SCM���ꉿ�i�ݒ�A�N�Z�X�̑㗝�l�N���X
    /// </summary>
    public class SCMMarketPriceAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "SCM���ꉿ�i�ݒ�}�X�^";

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public SCMMarketPriceAgent() : base() { }

        #endregion // </Constructor>

        // 2010/03/12 >>>
        Dictionary<string, List<RecordType>> _recordlist;

        /// <summary>
        /// ���ϑS�̐ݒ���A���_�R�[�h�t���Ƀ\�[�g����
        /// </summary>
        /// <remarks></remarks>
        private class SCMMrktPriStComparer : Comparer<RecordType>
        {
            public override int Compare(RecordType x, RecordType y)
            {
                int result = y.SectionCode.Trim().CompareTo(x.SectionCode.Trim());
                if (result != 0) return result;

                return result;
            }
        }
        // 2010/03/12 <<<

        #region <SCM���ꉿ�i�ݒ�}�X�^�̌���>

        /// <summary>
        /// �������܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>�Y������SCM���ꉿ�i�ݒ� ���w�苒�_�Ō���0�̏ꍇ�A�S�Аݒ�ōČ������܂��B</returns>
        public RecordType Find(
            string enterpriseCode,
            string sectionCode
        )
        {
            #region <Guard Phrase>

            if (string.IsNullOrEmpty(enterpriseCode.Trim()) || string.IsNullOrEmpty(sectionCode.Trim()))
            {
                return new RecordType();
            }

            #endregion // </Guard Phrase>

            const string ALL_SECTION_CODE = SecInfoSetAgent.ALL_SECTION_CODE;   // �S�Аݒ�

            string key = SCMEntityUtil.FormatEnterpriseCode(enterpriseCode) + SCMEntityUtil.FormatSectionCode(sectionCode);
            if (FoundRecordMap.ContainsKey(key))
            {
                return FoundRecordMap[key];
            }

            RecordType foundRecord = null;

            // 2010/03/12 Add >>>
            //int status = RealAccesser.Read(out foundRecord, enterpriseCode, sectionCode);
            //if (!status.Equals((int)ResultUtil.ResultCode.Normal) && !status.Equals((int)ResultUtil.ResultCode.NotFound))
            //{
            //    Debug.Assert(false, MY_NAME + "�̌��������s���܂����B");
            //    int sectionCodeNo = SCMEntityUtil.ConvertNumber(sectionCode.Trim());
            //    if (sectionCodeNo > 0)
            //    {
            //        return Find(enterpriseCode, ALL_SECTION_CODE);  // �S�Аݒ�ōČ���
            //    }
            //}

            //if (SCMDataHelper.IsAvailableRecord(foundRecord))
            //{
            //    FoundRecordMap.Add(key, foundRecord);
            //}
            //else
            //{
            //    int sectionCodeNo = SCMEntityUtil.ConvertNumber(sectionCode.Trim());
            //    if (sectionCodeNo > 0)
            //    {
            //        return Find(enterpriseCode, ALL_SECTION_CODE);  // �S�Аݒ�ōČ���
            //    }
            //}

            if (_recordlist == null) _recordlist = new Dictionary<string, List<RecordType>>();

            if (!_recordlist.ContainsKey(enterpriseCode))
            {
                _recordlist.Add(enterpriseCode, GetRecordList(enterpriseCode));
            }

            if (_recordlist[enterpriseCode] != null && _recordlist[enterpriseCode].Count > 0)
            {
                foundRecord = ( (List<RecordType>)_recordlist[enterpriseCode] ).Find(
                     delegate(RecordType rec)
                     {
                         if (rec.SectionCode.Trim() == sectionCode.Trim() || rec.SectionCode.Trim() == ALL_SECTION_CODE.Trim())
                         {
                             return true;
                         }
                         return false;
                     });
            }

            if (foundRecord != null && foundRecord.LogicalDeleteCode.Equals(0))
            {
                FoundRecordMap.Add(key, foundRecord);
            }
            // 2010/03/12 Add <<<

            return foundRecord ?? new RecordType();
        }

        // 2010/03/12 Add >>>
        /// <summary>
        /// ���R�[�h���X�g�̎擾
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <returns></returns>
        private List<RecordType> GetRecordList(string enterpriseCode)
        {
            List<RecordType> retList = new List<RecordType>();
            ArrayList al;
            int status = RealAccesser.SearchAll(out al, enterpriseCode);

            if (status.Equals((int)ResultUtil.ResultCode.Normal))
            {
                if (al != null && al.Count > 0)
                {
                    foreach (SCMMrktPriSt rec in al)
                    {
                        if (rec.LogicalDeleteCode == 0)
                        {
                            retList.Add(rec);
                        }
                    }

                    retList.Sort(new SCMMrktPriStComparer());
                }
            }

            return retList;
        }
        // 2010/03/12 Add <<<

        #endregion // </SCM���ꉿ�i�ݒ�}�X�^�̌���>

        /// <summary>
        /// ��������擾���܂��B
        /// </summary>
        /// <param name="detailRecord">SCM�󒍖��׃f�[�^(�⍇���E����)�̃��R�[�h</param>
        /// <param name="model">�֘A�^��</param>
        /// <param name="scmGoodsUnitData">SCM���t���i�A���f�[�^</param>
        /// <returns>�Y�����鑊����</returns>
        public IList<SCMSobaResponseHelper> GetSobaResponse(
            ISCMOrderDetailRecord detailRecord,
            string model,
            SCMGoodsUnitData scmGoodsUnitData
        )
        {
            const string METHOD_NAME = "GetSobaResponse()"; // ���O�p

            #region <Log>

            string msg = "������擾��...";
            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

            #endregion // </Log>

            IList<SCMSobaResponseHelper> scmSobaResponseList = new List<SCMSobaResponseHelper>();
            {
                // SCM���ꉿ�i�ݒ���擾
                SCMMrktPriSt foundMarketPriceSetting = Find(
                    detailRecord.InqOtherEpCd,
                    detailRecord.InqOtherSecCd
                );
                if (!SCMDataHelper.IsAvailableRecord(foundMarketPriceSetting)) foundMarketPriceSetting = null;
                if (foundMarketPriceSetting != null)
                {
                    #region <���ꉿ�i ��ʃR�[�h1 - �i���R�[�h1>
                    
                    if (EnabledMarketPrice(foundMarketPriceSetting.MarketPriceKindCd1))
                    {
                        scmSobaResponseList.Add(new SCMSobaResponseHelper(
                            foundMarketPriceSetting,
                            1,
                            GetSobaResTypeFromWebService(foundMarketPriceSetting, 1, detailRecord, model, scmGoodsUnitData)
                        ));
                    }

                    #endregion // </���ꉿ�i ��ʃR�[�h1 - �i���R�[�h1>

                    #region <���ꉿ�i ��ʃR�[�h2 - �i���R�[�h2>

                    if (EnabledMarketPrice(foundMarketPriceSetting.MarketPriceKindCd2))
                    {
                        scmSobaResponseList.Add(new SCMSobaResponseHelper(
                            foundMarketPriceSetting,
                            2,
                            GetSobaResTypeFromWebService(foundMarketPriceSetting, 2, detailRecord, model, scmGoodsUnitData)
                        ));
                    }

                    #endregion // </���ꉿ�i ��ʃR�[�h2 - �i���R�[�h2>

                    #region <���ꉿ�i ��ʃR�[�h3 - �i���R�[�h3>

                    if (EnabledMarketPrice(foundMarketPriceSetting.MarketPriceKindCd3))
                    {
                        scmSobaResponseList.Add(new SCMSobaResponseHelper(
                            foundMarketPriceSetting,
                            3,
                            GetSobaResTypeFromWebService(foundMarketPriceSetting, 3, detailRecord, model, scmGoodsUnitData)
                        ));
                    }

                    #endregion // </���ꉿ�i ��ʃR�[�h3 - �i���R�[�h3>
                }
            }
            return scmSobaResponseList;
        }

        /// <summary>
        /// ���ꉿ�i���L���ł��邩���f���܂��B
        /// </summary>
        /// <param name="marketPriceKindCd">���ꉿ�i��ʃR�[�h</param>
        /// <returns>
        /// <c>true</c> :�L���ł��B<br/>
        /// <c>false</c>:�����ł��B
        /// </returns>
        private static bool EnabledMarketPrice(int marketPriceKindCd)
        {
            // -1:�Ȃ�, 0:�V�i, 1:���r���g, 2:����
            return !marketPriceKindCd.Equals((int)MarketPriceKindCd.None);
        }

        /// <summary>
        /// ������̃��N�G�X�g���𐶐����܂��B
        /// </summary>
        /// <param name="marketPriceSetting">SCM���ꉿ�i�ݒ�</param>
        /// <param name="marketPriceKindNo">���ꉿ�i��ʔԍ�</param>
        /// <param name="detailRecord">SCM�󒍖��׃f�[�^(�⍇���E����)�̃��R�[�h</param>
        /// <param name="model">�֘A�^��</param>
        /// <param name="scmGoodsUnitData">SCM���t���i�A���f�[�^</param>
        /// <returns>������̃��N�G�X�g���</returns>
        private static GetSobaReqType CreateSobaRequest(
            SCMMrktPriSt marketPriceSetting,
            int marketPriceKindNo,
            ISCMOrderDetailRecord detailRecord,
            string model,
            SCMGoodsUnitData scmGoodsUnitData
        )
        {
            GetSobaReqType request = new GetSobaReqType();
            {
                request.UC = detailRecord.EnterpriseCode;   // ��ƃR�[�h�F���O�C�����
                request.AT = string.Empty;                  // �A�N�Z�X�`�P�b�g�F�H
                request.GC = string.Empty;                  // �W�F�l���[�V�����R�[�h�F���O�C�����

                // BL�R�[�h
                request.BLCodeList = new BLCodeType[1];
                request.BLCodeList[0] = new BLCodeType();
                request.BLCodeList[0].BLCode = scmGoodsUnitData.RealGoodsUnitData.BLGoodsCode.ToString();

                request.Model = model;                                                              // �֘A�^��
                request.AreaCode = marketPriceSetting.MarketPriceAreaCd;                            // �n��R�[�h
                request.KindCode = GetMarketPriceKindCd(marketPriceSetting, marketPriceKindNo);     // ��ʃR�[�h
                // DEL 2010/04/22 ������͑��ꉿ�i ��ʃR�[�h# - �i���R�[�h# �Ŏ擾(SCM���ꉿ�i�ݒ�}�X�^�̕ύX) ---------->>>>>
                //request.QualityCode = marketPriceSetting.MarketPriceQualityCd;                      // �i���R�[�h
                // DEL 2010/04/22 ������͑��ꉿ�i ��ʃR�[�h# - �i���R�[�h# �Ŏ擾(SCM���ꉿ�i�ݒ�}�X�^�̕ύX) ----------<<<<<
                // ADD 2010/04/22 ������͑��ꉿ�i ��ʃR�[�h# - �i���R�[�h# �Ŏ擾(SCM���ꉿ�i�ݒ�}�X�^�̕ύX) ---------->>>>>
                request.QualityCode = GetMarketPriceQualityCd(marketPriceSetting, marketPriceKindNo);   // �i���R�[�h
                // ADD 2010/04/22 ������͑��ꉿ�i ��ʃR�[�h# - �i���R�[�h# �Ŏ擾(SCM���ꉿ�i�ݒ�}�X�^�̕ύX) ----------<<<<<
                request.MtDateTime = new MtDateTimeType();  // FIXME:new���邾���ł悢�H
                //{
                //    const string DATE_TIME_FORMAT = "yyyyMMddHHmmss";
                //    DateTime now = DateTime.Now;
                //    request.MtDateTime.AreaDateTime = now.ToString(DATE_TIME_FORMAT);
                //    request.MtDateTime.KindDateTime = now.ToString(DATE_TIME_FORMAT);
                //    request.MtDateTime.QualityDateTime = now.ToString(DATE_TIME_FORMAT);
                //}
            }
            return request;
        }

        /// <summary>
        /// Web�T�[�r�X��葊������擾���܂��B
        /// </summary>
        /// <param name="marketPriceSetting">SCM���ꉿ�i�ݒ�</param>
        /// <param name="marketPriceKindNo">���ꉿ�i��ʔԍ�</param>
        /// <param name="detailRecord">SCM�󒍖��׃f�[�^(�⍇���E����)�̃��R�[�h</param>
        /// <param name="model">�֘A�^��</param>
        /// <param name="scmGoodsUnitData">SCM���t���i�A���f�[�^</param>
        /// <returns>�Y�����鑊����</returns>
        private static GetSobaResType GetSobaResTypeFromWebService(
            SCMMrktPriSt marketPriceSetting,
            int marketPriceKindNo,
            ISCMOrderDetailRecord detailRecord,
            string model,
            SCMGoodsUnitData scmGoodsUnitData
        )
        {
            const string METHOD_NAME = "GetSobaResTypeFromWebService()";    // ���O�p

            // ���N�G�X�g���𐶐�
            GetSobaReqType request = CreateSobaRequest(
                marketPriceSetting,
                marketPriceKindNo,
                detailRecord,
                model,
                scmGoodsUnitData
            );
            try
            {
                #region <Log>

                const string TAB = "\t";

                StringBuilder msg = new StringBuilder();
                {
                    msg.Append("������擾[���N�G�X�g]").Append(Environment.NewLine);
                    msg.Append(TAB).Append("��ƃR�[�h�F").Append(request.UC).Append(Environment.NewLine);
                    msg.Append(TAB).Append("�A�N�Z�X�`�P�b�g�F").Append(request.AT).Append(Environment.NewLine);
                    msg.Append(TAB).Append("�W�F�l���[�V�����R�[�h�F").Append(request.GC).Append(Environment.NewLine);

                    msg.Append(TAB).Append("BL�R�[�h�F").Append(request.BLCodeList[0].BLCode).Append(Environment.NewLine);
                    msg.Append(TAB).Append("�֘A�^���F").Append(request.Model).Append(Environment.NewLine);
                    msg.Append(TAB).Append("�n��R�[�h�F").Append(request.AreaCode).Append(Environment.NewLine);
                    msg.Append(TAB).Append("��ʃR�[�h�F").Append(request.KindCode).Append(Environment.NewLine);
                    msg.Append(TAB).Append("�i���R�[�h�F").Append(request.QualityCode).Append(Environment.NewLine);

                    msg.Append(TAB).Append("MtDateTime.AreaDateTime = ").Append(request.MtDateTime.AreaDateTime).Append(Environment.NewLine);
                    msg.Append(TAB).Append("MtDateTime.KindDateTime = ").Append(request.MtDateTime.KindDateTime).Append(Environment.NewLine);
                    msg.Append(TAB).Append("MtDateTime.QualityDateTime = ").Append(request.MtDateTime.QualityDateTime);
                }
                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg.ToString()));

                #endregion // </Log>

                SobaService sobaService = new SobaService();
                {
                    // Web�T�[�r�X�A�N�Z�X
                    GetSobaResType response = sobaService.GetSoba(request);

                    #region <Log>

                    if (response == null)
                    {
                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("���X�|���X��null�ł��B"));
                    }
                    else
                    {
                        string message = "������擾[���X�|���X]" + Environment.NewLine;
                        message += string.Format(
                            "\t�����Fresponse.SobaList[0].Cnt = {0}, response.SobaList[0].StdDev = {1}",
                            response.SobaList[0].Cnt,
                            response.SobaList[0].StdDev
                        );
                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(message));
                    }

                    #endregion // </Log>

                    return response;
                }
            }
            catch (SoapException ex)
            {
                Debug.WriteLine(ex.ToString());
                //Debug.Assert(false, ex.ToString());
                LogHelper.WriteExceptionLog(
                    MY_NAME,
                    METHOD_NAME,
                    "GetSobaResType response = sobaService.GetSoba(request);",
                    ex
                );
                return null;
            }
        }

        #region <���ꉿ�i���>

        /// <summary>
        /// ���ꉿ�i��ʃR�[�h���擾���܂��B
        /// </summary>
        /// <param name="marketPriceSetting">SCM���ꉿ�i�ݒ�</param>
        /// <param name="marketPriceKindNo">���ꉿ�i��ʔԍ�</param>
        /// <returns>���ꉿ�i��ʃR�[�h</returns>
        public static int GetMarketPriceKindCd(
            SCMMrktPriSt marketPriceSetting,
            int marketPriceKindNo
        )
        {
            switch (marketPriceKindNo)
            {
                case 1: // ���ꉿ�i��ʃR�[�h1
                    return marketPriceSetting.MarketPriceKindCd1;
                case 2: // ���ꉿ�i��ʃR�[�h2
                    return marketPriceSetting.MarketPriceKindCd2;
                case 3: // ���ꉿ�i��ʃR�[�h3
                    return marketPriceSetting.MarketPriceKindCd3;
                default:
                    return marketPriceSetting.MarketPriceKindCd1;
            }
        }

        /// <summary>���ꉿ�i��ʂ̃}�b�v</summary>
        private IDictionary<string, GetKindListResType> _marketPriceKindMap;
        /// <summary>���ꉿ�i��ʂ̃}�b�v���擾���܂��B</summary>
        /// <remarks>�L�[�F��ƃR�[�h</remarks>
        private IDictionary<string, GetKindListResType> MarketPriceKindMap
        {
            get
            {
                if (_marketPriceKindMap == null)
                {
                    _marketPriceKindMap = new Dictionary<string, GetKindListResType>();
                }
                return _marketPriceKindMap;
            }
        }

        /// <summary>
        /// ���ꉿ�i��ʖ��̂��擾���܂��B
        /// </summary>
        /// <param name="marketPriceSetting">SCM���ꉿ�i�ݒ�</param>
        /// <param name="marketPriceKindNo">���ꉿ�i��ʔԍ�</param>
        /// <returns>���ꉿ�i��ʖ���</returns>
        public string GetMarketPriceKindNm(
            SCMMrktPriSt marketPriceSetting,
            int marketPriceKindNo
        )
        {
            const string METHOD_NAME = "GetMarketPriceKindNm()";    // ���O�p

            GetKindListResType foundKindListResponse = null;
            if (MarketPriceKindMap.ContainsKey(marketPriceSetting.EnterpriseCode))
            {
                foundKindListResponse = MarketPriceKindMap[marketPriceSetting.EnterpriseCode];
            }
            else
            {
                try
                {
                    // ���ꉿ�i��ʂ̏��擾
                    GetKindListReqType request = new GetKindListReqType();
                    {
                        request.UC = marketPriceSetting.EnterpriseCode; // ��ƃR�[�h
                    }
                    KindService kindService = new KindService();
                    {
                        foundKindListResponse = kindService.GetKindList(request);
                    }
                    MarketPriceKindMap.Add(marketPriceSetting.EnterpriseCode, foundKindListResponse);
                }
                catch (SoapException ex)
                {
                    Debug.WriteLine(ex.ToString());
                    LogHelper.WriteExceptionLog(
                        MY_NAME,
                        METHOD_NAME,
                        "GetKindListResType response = kindService.GetKindList(request);",
                        ex
                    );
                    foundKindListResponse = null;
                }
            }   // if (MarketPriceKindMap.ContainsKey(marketPriceSetting.EnterpriseCode))
            if (foundKindListResponse == null) return string.Empty;

            int marketPriceKindCd = GetMarketPriceKindCd(marketPriceSetting, marketPriceKindNo);
            foreach (KindType kindType in foundKindListResponse.KindList)
            {
                if (marketPriceKindCd.Equals(kindType.KindCode)) return kindType.KindName;
            }
            return string.Empty;
        }

        #endregion // </���ꉿ�i���>

        // ADD 2010/04/22 ������͑��ꉿ�i ��ʃR�[�h# - �i���R�[�h# �Ŏ擾(SCM���ꉿ�i�ݒ�}�X�^�̕ύX) ---------->>>>>
        #region <���ꉿ�i�i��>

        /// <summary>
        /// ���ꉿ�i�i���R�[�h���擾���܂��B
        /// </summary>
        /// <param name="marketPriceSetting">SCM���ꉿ�i�ݒ�</param>
        /// <param name="marketPriceQualityNo">���ꉿ�i�i���ԍ�</param>
        /// <returns>���ꉿ�i�i���R�[�h</returns>
        private static int GetMarketPriceQualityCd(
            SCMMrktPriSt marketPriceSetting,
            int marketPriceQualityNo
        )
        {
            switch (marketPriceQualityNo)
            {
                case 1: // ���ꉿ�i�i���R�[�h1
                    return marketPriceSetting.MarketPriceQualityCd;
                case 2: // ���ꉿ�i�i���R�[�h2
                    return marketPriceSetting.MarketPriceQualityCd2;
                case 3: // ���ꉿ�i�i���R�[�h3
                    return marketPriceSetting.MarketPriceQualityCd3;
                default:
                    return marketPriceSetting.MarketPriceQualityCd;
            }
        }

        #endregion // </���ꉿ�i�i��>
        // ADD 2010/04/22 ������͑��ꉿ�i ��ʃR�[�h# - �i���R�[�h# �Ŏ擾(SCM���ꉿ�i�ݒ�}�X�^�̕ύX) ----------<<<<<

        #region �����R�[�h

        /// <summary>
        /// ������̎擾�e�X�g
        /// </summary>
        private static void TestWebService()
        {
            GetSobaReqType request = new GetSobaReqType();
            {
                request.UC = "0101150842020000";    // ��ƃR�[�h�F���O�C�����
                //request.AT = "";    // �A�N�Z�X�`�P�b�g�F�H
                //request.GC = "";    // �W�F�l���[�V�����R�[�h�F���O�C�����

                request.BLCodeList = new BLCodeType[1];
                request.BLCodeList[0] = new BLCodeType();
                request.BLCodeList[0].BLCode = "1"; // BL�R�[�h
                request.Model = "E-HR32-GFE";       // �֘A�^��
                request.AreaCode = 0;               // �n��R�[�h
                request.KindCode = 0;               // ��ʃR�[�h
                request.QualityCode = 0;            // �i���R�[�h
            }
            SobaService sobaService = new SobaService();
            try
            {
                //// ���ꉿ�i�n��̏��擾(����)
                //AreaService areaService = new AreaService();
                //GetAreaListReqType getAreaListReqType = new GetAreaListReqType();
                //GetAreaListResType getAreaListResType = areaService.GetAreaList(getAreaListReqType);

                GetSobaResType response = sobaService.GetSoba(request);
            }
            catch (SoapException ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        #endregion // �����R�[�h
    }
}

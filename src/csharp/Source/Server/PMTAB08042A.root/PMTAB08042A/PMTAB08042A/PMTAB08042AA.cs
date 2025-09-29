//****************************************************************************//
// �V�X�e��         : PM-Tablet
// �v���O��������   : ���i�ڍ׏�񌟍�WEB�A�N�Z�X
// �v���O�����T�v   : ���i�ڍ׏�񌟍�WEB�A�N�Z�X������s���܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370090-00  �쐬�S�� : chenyk
// �� �� ��  2017.11.02   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using Broadleaf.Runtime.Serialization.Json;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using System.Collections;
using Broadleaf.Web.Common;
using Broadleaf.Web;
using Broadleaf.Library.Collections;
using System.Globalization;
using Broadleaf.Application.Resources;
using System.Text;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���i�ڍ׏�񌟍�WEB�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�ڍ׏�񌟍�WEB�A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : chenyk</br>
    /// <br>Date       : 2017.11.02</br>
    /// </remarks>
    public partial class PartsDetailInfoSearchWebAcs
    {
        #region << Constructor >>
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�ڍ׏�񌟍�WEB�A�N�Z�X�N���X�̃C���X�^���X�����s���܂��B</br>
        /// <br>Programmer : chenyk</br>
        /// <br>Date       : 2017.11.02</br>
        /// </remarks>
        public PartsDetailInfoSearchWebAcs()
        {
            // ���i�ڍ׏�񌟍������[�g�I�u�W�F�N�g�̎擾
            AspLoginInfoAcquisition loginInfoAcq = new AspLoginInfoAcquisition();
            string wkStrApSvr = loginInfoAcq.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
            this.IPrimePartsDtDBObj = GetPmtPartsSearchDB(wkStrApSvr);
        }
        #endregion

        #region << Private Const >>
        /// <summary>PGID</summary>
        private const string Pgid = "PMTAB08042A";
        /// <summary>���i�ڍ׏��L���`�F�b�N�������\�b�h����</summary>
        private const string CheckProcName = "���i�ڍ׏��L���`�F�b�N����";
        // <summary>���i�ڍ׏��擾�������\�b�h����</summary>
        private const string GetProcName = "���i�ڍ׏��擾����";
        /// <summary>�������G���[���b�Z�[�W</summary>
        private const string InitErrorMsg = "{0}�ɂď������G���[���������܂����B";
        /// <summary>��O�G���[���b�Z�[�W</summary>
        private const string ExceptionMsg = "{0}�ɂė�O���������܂����B";

        /// <summary>JSON�p�����[�^�@���i�ڍ׌����p�����[�^</summary>
        private const string JSParaPartsDetail = "PartsDetailPara";
        /// <summary>JSON�p�����[�^�@���i���[�J�[�R�[�h</summary>
        private const string JSParaPartsMakerCd = "GoodsMakerCd";
        /// <summary>JSON�p�����[�^�@���i�i��</summary>
        private const string JSParaPartsNo = "GoodsNo";
        /// <summary>JSON�߂錋�ʁ@���i�ڍ׏��L���f�[�^</summary>
        private const string JSParaPartsDetailExistInfo = "PartsDetailExistInfo";
        /// <summary>JSON�߂錋�ʁ@���i�ڍ׏��</summary>
        private const string JSParaPartsDetailInfo = "PartsDetailInfo";
        /// <summary>�n�C�t��</summary>
        private const string HyphenStr = "-";
        /// <summary>���p�X�y�[�X</summary>
        private const string SpaceStr = " ";
        #endregion

        #region << Private Member >>

        /// <summary>���i�ڍ׏�񌟍������[�g�I�u�W�F�N�g</summary>
        private IPrimePartsDtlDB IPrimePartsDtDBObj = null;

        #endregion

        # region << Public Method(WEB�n���h��) >>
        /// <summary>
        /// ���i�ڍ׏��L���`�F�b�N����
        /// </summary>
        /// <param name="parameterValue">�����p�����[�^</param>
        /// <param name="resultValue">��������</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : ���i�ڍ׏��L���`�F�b�N�������s���܂��B</br>
        /// <br>Programmer : chenyk</br>
        /// <br>Date       : 2017.11.02</br>
        /// </remarks>
        public int CheckPartsDetailInfoList(JsonValue parameterValue, out JsonValue resultValue, out string errMsg)
        {
            return this.CheckPartsDetailInfoListProc(parameterValue, out resultValue, out errMsg);
        }

        /// <summary>
        /// ���i�ڍ׏��擾����
        /// </summary>
        /// <param name="parameterValue">�����p�����[�^</param>
        /// <param name="resultValue">��������</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : ���i�ڍ׏��擾�������s���܂��B</br>
        /// <br>Programmer : chenyk</br>
        /// <br>Date       : 2017.11.02</br>
        /// </remarks>
        public int GetPartsDetailInfoList(JsonValue parameterValue, out JsonValue resultValue, out string errMsg)
        {
            return this.GetPartsDetailInfoListProc(parameterValue, out resultValue, out errMsg);
        }
        # endregion

        #region << Private Method >>
        /// <summary>
        /// ���i�ڍ׏�񌟍������[�g�I�u�W�F�N�g�̎擾
        /// </summary>
        /// <param name="wkStrApSvr">AP�T�[�o�[��</param>
        /// <returns>���i�ڍ׏�񌟍������[�g�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : ���i�ڍ׏�񌟍������[�g�I�u�W�F�N�g�̎擾���s���܂��B</br>
        /// <br>Programmer : chenyk</br>
        /// <br>Date       : 2017.11.02</br>
        /// </remarks>
        private IPrimePartsDtlDB GetPmtPartsSearchDB(string wkStrApSvr)
        {
            return (IPrimePartsDtlDB)Activator.GetObject(typeof(IPrimePartsDtlDB), string.Format("{0}/MyAppPrimePartsDtl", wkStrApSvr));
        }

        /// <summary>
        /// ���i�ڍ׏��L���`�F�b�N����
        /// </summary>
        /// <param name="parameterValue">�����p�����[�^</param>
        /// <param name="resultValue">��������</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : ���i�ڍ׏��L���`�F�b�N�������s���܂��B</br>
        /// <br>Programmer : chenyk</br>
        /// <br>Date       : 2017.11.02</br>
        /// </remarks>
        private int CheckPartsDetailInfoListProc(JsonValue parameterValue, out JsonValue resultValue, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            resultValue = null;
            errMsg = string.Empty;
            try
            {
                // �p�����[�^
                JsonObject paramObj = parameterValue as JsonObject;

                if (this.IPrimePartsDtDBObj == null)
                {
                    // �v���O����ID�A���b�Z�[�W�A�X�e�[�^�X�AException ���Z�b�g
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    throw new MobileWebException(Pgid, CheckProcName, string.Format(InitErrorMsg, CheckProcName), -1, null);
                }
                else
                {
                    CustomSerializeArrayList retCSList = null;
                    object primPartsCheckObj = retCSList;

                    //--------------------------------------------------
                    // ���i�ڍ׏��L���`�F�b�N�����̐���
                    //--------------------------------------------------
                    CustomSerializeArrayList paraCSList = new CustomSerializeArrayList();
                    JsonArray jsonArray = null;
                    int partsMakerCd = 0;
                    string partsNo = string.Empty;
                    PrmPrtDtParaWork paraWork = null;
                    if (paramObj.HasValueArray(JSParaPartsDetail))
                    {
                        jsonArray = paramObj.GetValueArray(JSParaPartsDetail);
                    }
                    if (jsonArray != null)
                    {
                        foreach (JsonObject jsonObj in jsonArray)
                        {
                            // ���i���[�J�[�R�[�h
                            partsMakerCd = jsonObj.GetValueInt32(JSParaPartsMakerCd, 0);
                            // ���i�i��
                            if (jsonObj.HasValueString(JSParaPartsNo))
                            {
                                partsNo = jsonObj.GetValueString(JSParaPartsNo);
                            }
                            paraWork = new PrmPrtDtParaWork();
                            paraWork.PartsMakerCode = partsMakerCd;
                            paraWork.PrimePartsNoWithH = partsNo;
                            paraCSList.Add(paraWork);
                        }
                    }

                    //--------------------------------------------------
                    // ���i�ڍ׏��L���`�F�b�N���������[�g�Ăяo��(CheckExist)
                    //--------------------------------------------------
                    status = this.IPrimePartsDtDBObj.CheckExist(out primPartsCheckObj, paraCSList);

                    // �������ʂ���\�����e�𐶐�
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                        primPartsCheckObj != null &&
                        primPartsCheckObj is CustomSerializeArrayList)
                    {
                        JsonObject resultObj = new JsonObject();

                        CustomSerializeArrayList retList = primPartsCheckObj as CustomSerializeArrayList;

                        //--------------------------------------------------
                        // ���ʂ̔��f�iList�̗v�f���`�F�b�N�j
                        //--------------------------------------------------
                        if (retList == null || retList.Count == 0)
                        {
                            // �Y���f�[�^������
                            return (int)ConstantManagement.DB_Status.ctDB_EOF;
                        }

                        //--------------------------------------------------
                        // �f�[�^�ڍs
                        //--------------------------------------------------
                        List<PrmPrtDtParaWork> partsDetailInfoList = new List<PrmPrtDtParaWork>();
                        // PartsDetailExistInfo
                        foreach (PrmPrtDtParaWork prmPrtDtParaWork in retList)
                        {
                            // PartsDetailExistInfo���X�g�ɒǉ�����
                            partsDetailInfoList.Add(prmPrtDtParaWork);
                        }

                        //--------------------------------------------------
                        // JsonObject�ւ̃Z�b�g
                        //--------------------------------------------------
                        resultObj.SetValue(JSParaPartsDetailExistInfo, (JsonArray)JsonSerializer.ConvertToJsonValue(partsDetailInfoList.ToArray()));

                        resultValue = resultObj;
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (MobileWebException)
            {
                throw;
            }
            catch (Exception ex)
            {
                // �v���O����ID�A���b�Z�[�W�A�X�e�[�^�X�AException ���Z�b�g
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                throw new MobileWebException(Pgid, CheckProcName, string.Format(ExceptionMsg, CheckProcName), -1, ex);
            }
            return status;
        }

        /// <summary>
        /// ���i�ڍ׏��擾����
        /// </summary>
        /// <param name="parameterValue">�����p�����[�^</param>
        /// <param name="resultValue">��������</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : ���i�ڍ׏��擾�������s���܂��B</br>
        /// <br>Programmer : chenyk</br>
        /// <br>Date       : 2017.11.02</br>
        /// </remarks>
        private int GetPartsDetailInfoListProc(JsonValue parameterValue, out JsonValue resultValue, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            resultValue = null;
            errMsg = string.Empty;
            try
            {
                // �p�����[�^
                JsonObject paramObj = parameterValue as JsonObject;

                if (this.IPrimePartsDtDBObj == null)
                {
                    // �v���O����ID�A���b�Z�[�W�A�X�e�[�^�X�AException ���Z�b�g
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    throw new MobileWebException(Pgid, GetProcName, string.Format(InitErrorMsg, GetProcName), -1, null);
                }
                else
                {
                    CustomSerializeArrayList retCSList = null;
                    object prmPrtDtInfobj = retCSList;

                    //--------------------------------------------------
                    // ���i�ڍ׏��擾���������̐���
                    //--------------------------------------------------
                    int partsMakerCd = 0;
                    string partsNo = string.Empty;
                    PrmPrtDtParaWork paraWork = new PrmPrtDtParaWork();
                    // ���i���[�J�[�R�[�h
                    partsMakerCd = paramObj.GetValueInt32(JSParaPartsMakerCd, 0);
                    // ���i�i��
                    if (paramObj.HasValueString(JSParaPartsNo))
                    {
                        partsNo = paramObj.GetValueString(JSParaPartsNo);
                    }
                    paraWork.PartsMakerCode = partsMakerCd;
                    paraWork.PrimePartsNoWithH = partsNo;

                    //--------------------------------------------------
                    // ���i�ڍ׏��擾���������[�g�Ăяo��(Read)
                    //--------------------------------------------------
                    status = this.IPrimePartsDtDBObj.Read(out prmPrtDtInfobj, paraWork);

                    // �������ʂ���\�����e�𐶐�
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                        prmPrtDtInfobj != null)
                    {
                        JsonObject resultObj = new JsonObject();

                        PrmPrtDtInfWork retWork = prmPrtDtInfobj as PrmPrtDtInfWork;

                        //--------------------------------------------------
                        // JSON-IF�p�̃N���X�փZ�b�g
                        //--------------------------------------------------
                        JSPartsDetailInfo jsonWork = new JSPartsDetailInfo();
                        // ���[�J�[�R�[�h
                        jsonWork.PartsMakerCode = retWork.PartsMakerCode;
                        // ���[�J�[��
                        jsonWork.PartsMakerFullName = retWork.PartsMakerFullName;
                        // �i��
                        jsonWork.PrimePartsName = retWork.PrimePartsName;
                        // �i��
                        jsonWork.PrimePartsNo = retWork.PrimePartsNoWithH;
                        // ���i�����i���i�����iB�����j�j
                        jsonWork.GoodsDetailDesc = retWork.GoodsDetailDescToB;
                        // ���L
                        jsonWork.PrimePartsSpecialNote = retWork.PrimePartsSpecialNote;
                        // ���[�J�[���z�[���y�[�WURL
                        jsonWork.PrmPartsMakerUrl = retWork.PrmPartsMakerUrl;
                        // �J�^���O���y�[�WURL
                        jsonWork.PrmPartsCatalogUri = retWork.PrmPartsCatalogUri;
                        // ���i���y�[�WURL
                        jsonWork.PrmPtDescMovieUri = retWork.PrmPtDescMovieUri;
                        // ���@�i�����j�i���i���@�P�ʕt���j
                        jsonWork.GoodsSizeLengthWithUnit = GetSizeWithUnit(retWork.GoodsSizeLength, retWork.GoodsSizeUnit);
                        // ���@�i���j�i���i���@�P�ʕt���j
                        jsonWork.GoodsSizeWidthWithUnit = GetSizeWithUnit(retWork.GoodsSizeWidth, retWork.GoodsSizeUnit);
                        // ���@�i�����j�i���i���@�P�ʕt���j
                        jsonWork.GoodsSizeHeightWithUnit = GetSizeWithUnit(retWork.GoodsSizeHeight, retWork.GoodsSizeUnit);
                        // �����@�i�����j�i���i�����@�P�ʕt���j
                        jsonWork.GoodsPkgBoxLengthWithUnit = GetSizeWithUnit(retWork.GoodsPkgBoxLength, retWork.GoodsPkgBoxUnit);
                        // �����@�i���j�i���i�����@�P�ʕt���j
                        jsonWork.GoodsPkgBoxWidthWithUnit = GetSizeWithUnit(retWork.GoodsPkgBoxWidth, retWork.GoodsPkgBoxUnit);
                        // �����@�i�����j�i���i�����@�P�ʕt���j
                        jsonWork.GoodsPkgBoxHeightWithUnit = GetSizeWithUnit(retWork.GoodsPkgBoxHeight, retWork.GoodsPkgBoxUnit);
                        // ���i�e�ʁi���i���e�ʒP�ʕt���j
                        jsonWork.GoodsVolumeWithUnit = GetSizeWithUnit(retWork.GoodsVolume, retWork.GoodsVolumeUnit);
                        // ���i�d�ʁi���i�d�ʒP�ʕt���j
                        jsonWork.GoodsWeightWithUnit = GetSizeWithUnit(retWork.GoodsWeight, retWork.GoodsWeightUnit);
                        // ���i�T���l�C���摜�L���敪
                        jsonWork.GoodsTmbImgExtDiv = retWork.GoodsTmbImgExtDiv;
                        // �摜1
                        jsonWork.GoodsTmbImgFlName1 = retWork.GoodsTmbImgFlName1;
                        // �摜2
                        jsonWork.GoodsTmbImgFlName2 = retWork.GoodsTmbImgFlName2;
                        // �摜3
                        jsonWork.GoodsTmbImgFlName3 = retWork.GoodsTmbImgFlName3;
                        // �摜4
                        jsonWork.GoodsTmbImgFlName4 = retWork.GoodsTmbImgFlName4;
                        // �摜5
                        jsonWork.GoodsTmbImgFlName5 = retWork.GoodsTmbImgFlName5;
                        // �摜6
                        jsonWork.GoodsTmbImgFlName6 = retWork.GoodsTmbImgFlName6;
                        // �摜7
                        jsonWork.GoodsTmbImgFlName7 = retWork.GoodsTmbImgFlName7;
                        // �摜8
                        jsonWork.GoodsTmbImgFlName8 = retWork.GoodsTmbImgFlName8;
                        // �摜9
                        jsonWork.GoodsTmbImgFlName9 = retWork.GoodsTmbImgFlName9;
                        // �̔��I�����i�p�ԓ��t�j
                        if (retWork.CarPrtsDiscontDate != 0)
                        {
                            DateTime dt = DateTime.ParseExact(retWork.CarPrtsDiscontDate.ToString(), "yyyyMMdd",
                                System.Globalization.CultureInfo.CurrentCulture);
                            jsonWork.CarPrtsDiscontDate = dt.ToString("yyyy/M/d"); // 2017/5/9�̌^
                        }
                        else
                        {
                            // �̔��I�����i�p�ԓ��t�j�Ȃ��ꍇ�A�n�C�t���u-�v�Œ�Ƃ���B
                            jsonWork.CarPrtsDiscontDate = HyphenStr;
                        }

                        //--------------------------------------------------
                        // JsonObject�ւ̃Z�b�g
                        //--------------------------------------------------
                        resultObj.SetValue(JSParaPartsDetailInfo, (JsonObject)JsonSerializer.ConvertToJsonValue(jsonWork));

                        resultValue = resultObj;
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (MobileWebException)
            {
                throw;
            }
            catch (Exception ex)
            {
                // �v���O����ID�A���b�Z�[�W�A�X�e�[�^�X�AException ���Z�b�g
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                throw new MobileWebException(Pgid, GetProcName, string.Format(ExceptionMsg, GetProcName), -1, ex);
            }
            return status;
        }

        /// <summary>
        /// ���@�i�P�ʕt���j�̎擾
        /// </summary>
        /// <param name="size">���@�i�����A���A�����j</param>
        /// <param name="unit">�P��</param>
        /// <returns>���@�i�P�ʕt���j</returns>
        /// <remarks>
        /// <br>Note       : ���@�i�P�ʕt���j�̎擾���s���܂��B</br>
        /// <br>Programmer : chenyk</br>
        /// <br>Date       : 2017.11.02</br>
        /// </remarks>
        private string GetSizeWithUnit(double size, string unit)
        {
            // ���@���ݒ�̏ꍇ�A�n�C�t���u-�v�Œ�Ƃ���B
            string sizeWithUnit = HyphenStr;

            if (size != 0)
            {
                sizeWithUnit = size.ToString("#,##0.00") + SpaceStr + unit;
            }

            return sizeWithUnit;
        }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using System.Net;
using System.IO;
using System.Drawing;

using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// TBO�A�N�Z�X�N���X
    /// </summary>
	public class TBOServiceACS
	{
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
        public TBOServiceACS()
		{ 
           
		}

		private static string tobServerURL = "";

		// GCP�p�i������API�p�X ���@�������񂪍�����炱���ɒǉ����Ă���
		/// <summary>�J�e�S������API</summary>
		private readonly string GET_GoodsCategory = "/CarGoodsExchange-web/api/general/goodscategory";

        /// <summary>�t�������ݒ�擾</summary>
        private readonly string GET_Attendrepairs = "/CarGoodsExchange-web/api/wholesale/attendrepairs";

        /// <summary>�t�������ݒ�擾(SF���[�h)</summary>
        private readonly string GET_Attendrepairs_ModeSF = "/CarGoodsExchange-web/api/store/attendrepairs";

        /// <summary>���i�摜�擾�E�o�^�E�폜</summary>
        private readonly string COMMON_GoodsImage = "/CarGoodsExchange-web/api/goodsimage";

        /// <summary>��ď��i�ꊇ�o�^</summary>
        private readonly string POST_Goods = "/CarGoodsExchange-web/api/wholesale/proposegoods/bulk";

        /// <summary>��ď��i���J�i���i�����[�h�j</summary>
        private readonly string POST_Release = "/CarGoodsExchange-web/api/wholesale/proposegoods/release";

        /// <summary>��ď��i���J�i�����H�ꃂ�[�h�j</summary>
        private readonly string POST_ReleaseAdopt = "/CarGoodsExchange-web/api/wholesale/proposegoods/releaseAdopt";

        /// <summary>�t�������ݒ�ꊇ�X�V</summary>
        private readonly string POST_Attendrepairs = "/CarGoodsExchange-web/api/wholesale/attendrepairs/bulk";

        /// <summary>��ď��i�擾(GET)</summary>
        private readonly string GET_Goods = "/CarGoodsExchange-web/api/wholesale/proposegoods";


        /// <summary>���i���J��� �擾�A�폜</summary>
        private readonly string COMMON_DestSettings = "/CarGoodsExchange-web/api/wholesale/destsettings";

        /// <summary>���i���J���ꊇ �폜</summary>
        private readonly string DELET_BULK_DestSettings = "/CarGoodsExchange-web/api/wholesale/destsettings/bulk";

        /// <summary>����ݒ� �o�^�E�X�V�E�폜 </summary>
        private readonly string COMMON_BULK_Settings = "/CarGoodsExchange-web/api/settings/bulk";

        /// <summary>����ݒ� �擾</summary>
        private readonly string GET_Settings = "/CarGoodsExchange-web/api/settings/list";

        private void DebugURL(ref string tobServerURL , string para)
        {
            if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "TBO.txt")))
            {
                using (StreamReader reader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "TBO.txt")))
                {
                    tobServerURL = reader.ReadLine() + para;
                }
            }
        }

        private readonly int _timeOut = 1800000; // 30���Ƃ���

        #region TBO�A�N�Z�X���\�b�h

        // �^�C���A�E�g�̓f�t�H���g��100�b�Ƃ���

        #region POST

        #region ��ď��i�ۑ�����
        /// <summary>
        /// ��ď��i�ۑ�����
        /// </summary>
        /// <returns></returns>
        public int SavePropose_Goods(ref ProposeGoods[] para, out string errMsg)
        {
            errMsg = string.Empty;
            string resultJsonString = "";

            int st = 0;

            // �������鐔 ��ԃp�t�H�[�}���X���ǂ�����300���Ƃ���
            //int div_count = 100; // 100������     3:54
            //int div_count = 300;�@ // 300������   3:37
            //int div_count = 500;�@ // 500������   4:03
            int div_count = 1000;�@ // 1000������   4:03

            // �ۑ��f�[�^������胋�[�v�񐔂��Z��
            int roopCount = (para.Length / div_count);

            // ���܂肪��������ꍇ�̓��[�v�񐔂�1��ǉ�
            if ((para.Length % div_count) != 0)
            {
                roopCount += 1;
            }

            // �ۑ����ɂw�w���ȍ~�̕ۑ��Ɏ��s�Ƃ������b�Z�[�W���o���ׂ̃C���f�b�N�X
            int saveIndex = 0;

            // �ۑ��f�[�^�i�S�Ă���j�������Ď��o���v�f��
            int copyLength = 0;

             List<ProposeGoods> retList = new List<ProposeGoods>(); 

            try
            {
                // URL�擾
                tobServerURL = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_IllustSelectWeb) + POST_Goods;
#if DEBUG
                DebugURL(ref tobServerURL, POST_Goods);
#endif

                #region ����
                for (int i = 0; i < roopCount; i++)
                {
                    saveIndex = i;
                    copyLength = div_count;
                    if (i == roopCount - 1)
                    {
                        copyLength = para.Length - (i * div_count);
                    }

                    long sourceIndex = i * div_count;
                    ProposeGoods[] wkProposeGoods = new ProposeGoods[copyLength];
                    Array.Copy(para, sourceIndex, wkProposeGoods, 0, copyLength);

                    // ���M���̐ݒ�
                    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(tobServerURL);
                    webRequest.Method = "POST";
                    webRequest.ContentType = "application/json";
                    // TOB�̃��N�G�X�gKEY(�v�Í���)
                    webRequest.Headers.Add("bl-app-key", "df8f7b8f-a44a-49e9-a50e-afa1f902cd4e");
                    // �v���L�V�o�R�̏ꍇ�K�v
                    webRequest.ServicePoint.Expect100Continue = false;
                    webRequest.Timeout = this._timeOut;

                    //POST�f�[�^�쐬
                    string jsonPara = FM.WebSync.Core.JSON.Serialize<ProposeGoods[]>(wkProposeGoods);
                    byte[] reqByte = Encoding.UTF8.GetBytes(jsonPara);

                    webRequest.ContentLength = reqByte.Length;

                    // �����N�G�X�g�J�n
                    using (Stream reqStream = webRequest.GetRequestStream())
                    {
                        reqStream.Write(reqByte, 0, reqByte.Length);
                    }

                    using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                    using (Stream resStream = webResponse.GetResponseStream())
                    using (StreamReader sr = new StreamReader(resStream, Encoding.UTF8))
                    {
                        // ���ʎ擾
                        resultJsonString = sr.ReadToEnd();

                        //���ʂ��f�V���A���C�Y
                        ProposeGoods_MAIN main = FM.WebSync.Core.JSON.Deserialize<ProposeGoods_MAIN>(resultJsonString);
                        retList.AddRange(main.goods);
                        st = 0;
                    }

                }
                #endregion

                #region DEL ��
                //// ���M���̐ݒ�
                //HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(tobServerURL);
                //webRequest.Method = "POST";
                //webRequest.ContentType = "application/json";
                //// TOB�̃��N�G�X�gKEY(�v�Í���)
                //webRequest.Headers.Add("bl-app-key", "df8f7b8f-a44a-49e9-a50e-afa1f902cd4e");
                //// �v���L�V�o�R�̏ꍇ�K�v
                //webRequest.ServicePoint.Expect100Continue = false;
                //webRequest.Timeout = this._timeOut;

                ////POST�f�[�^�쐬
                //string jsonPara = FM.WebSync.Core.JSON.Serialize<ProposeGoods[]>(para);
                //byte[] reqByte = Encoding.UTF8.GetBytes(jsonPara);

                //webRequest.ContentLength = reqByte.Length;

                //// �����N�G�X�g�J�n
                //using (Stream reqStream = webRequest.GetRequestStream())
                //{
                //    reqStream.Write(reqByte, 0, reqByte.Length);
                //}

                //using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                //using (Stream resStream = webResponse.GetResponseStream())
                //using (StreamReader sr = new StreamReader(resStream, Encoding.UTF8))
                //{
                //    // ���ʎ擾
                //    resultJsonString = sr.ReadToEnd();

                //    //���ʂ��f�V���A���C�Y
                //    ProposeGoods_MAIN main = FM.WebSync.Core.JSON.Deserialize<ProposeGoods_MAIN>(resultJsonString);
                //    para = main.goods;
                //    st = 0;
                //}
                #endregion

            }
            #region ��
            //// �^�C���A�E�g
            //catch (WebException ex)
            //{
            //    errMsg = "���i���̕ۑ��Ɏ��s���܂����B";
            //    // ��O����
            //    this.ErrProc(ex, ref errMsg, out st);
            //}
            //catch (Exception ex)
            //{
            //    errMsg = "���i���̕ۑ������ŗ�O���������܂����B" + Environment.NewLine + ex.StackTrace.ToString(); ;
            //    st = -1;
            //}
            #endregion
            #region ����
            catch (WebException ex)
            {
                errMsg = "���i���̕ۑ��Ɏ��s���܂����B";
                if (retList.Count != 0)
                {
                    errMsg = "���i���̕ۑ������ŗ�O���������܂����B" + Environment.NewLine + ((saveIndex * div_count) + 1).ToString() + "���ڈȍ~�̏��i�̍X�V�Ɏ��s���܂����B�B" + Environment.NewLine + ex.StackTrace.ToString();
                }
                // ��O����
                this.ErrProc(ex, ref errMsg, out st);
            }
            catch (Exception ex)
            {
                errMsg = "���i���̕ۑ������ŗ�O���������܂����B" + Environment.NewLine + ex.StackTrace.ToString();
                if (retList.Count != 0)
                {
                    errMsg = "���i���̕ۑ������ŗ�O���������܂����B" + Environment.NewLine + ((saveIndex * div_count) + 1).ToString() + "���ڈȍ~�̏��i�̍X�V�Ɏ��s���܂����B�B" + Environment.NewLine + ex.StackTrace.ToString();
                }
                st = -1;
            }
            #endregion
            finally
            {
                para = retList.ToArray();
            }

            return st;
        }
        #endregion

        #region �V�����ۑ�����

        #region ���i��
        /// <summary>
        /// �V�����ۑ�����
        /// </summary>
        /// <returns></returns>
        public int SaveNews(News news, out string errMsg)
        {
            errMsg = string.Empty;

            int st = 0;

            try
            {
                // URL�擾
                tobServerURL = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_IllustSelectWeb) + POST_Release;
#if DEBUG
                DebugURL(ref tobServerURL, POST_Release);
#endif

                // ���M���̐ݒ�
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(tobServerURL);
                webRequest.Method = "POST";
                webRequest.ContentType = "application/json";

                // TOB�̃��N�G�X�gKEY(�v�Í���)
                webRequest.Headers.Add("bl-app-key", "df8f7b8f-a44a-49e9-a50e-afa1f902cd4e");
                // �v���L�V�o�R�̏ꍇ�K�v
                webRequest.ServicePoint.Expect100Continue = false;
                webRequest.Timeout = this._timeOut;

                //POST�f�[�^�쐬
                string jsonPara = FM.WebSync.Core.JSON.Serialize<News>(news);
                byte[] reqByte = Encoding.UTF8.GetBytes(jsonPara);
                webRequest.ContentLength = reqByte.Length;

                // �����N�G�X�g�J�n
                using (Stream reqStream = webRequest.GetRequestStream())
                {
                    reqStream.Write(reqByte, 0, reqByte.Length);
                }

                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                using (Stream resStream = webResponse.GetResponseStream())
                using (StreamReader sr = new StreamReader(resStream, Encoding.UTF8))
                {
                    // ���ʂ͖�����
                    st = 0;
                }

            }
            // �^�C���A�E�g
            catch (WebException ex)
            {
                errMsg = "�ʒm���̕ۑ��Ɏ��s���܂����B";
                // ��O����
                this.ErrProc(ex, ref errMsg, out st);
            }
            catch (Exception ex)
            {
                errMsg = "�ʒm���̕ۑ������ŗ�O���������܂����B" + Environment.NewLine + ex.StackTrace.ToString(); ;
                st = -1;
            }
            return st;
        }
        #endregion

        #region �����H��
        /// <summary>
        /// �V�����ۑ�����
        /// </summary>
        /// <returns></returns>
        public int SaveNewsAdopt(News news, out string errMsg)
        {
            errMsg = string.Empty;

            int st = 0;

            try
            {
                // URL�擾
                tobServerURL = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_IllustSelectWeb) + POST_ReleaseAdopt;
#if DEBUG
                DebugURL(ref tobServerURL, POST_ReleaseAdopt);
#endif
                // ���M���̐ݒ�
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(tobServerURL);
                webRequest.Method = "POST";
                webRequest.ContentType = "application/json";
                webRequest.Timeout = this._timeOut;

                // TOB�̃��N�G�X�gKEY(�v�Í���)
                webRequest.Headers.Add("bl-app-key", "df8f7b8f-a44a-49e9-a50e-afa1f902cd4e");
                // �v���L�V�o�R�̏ꍇ�K�v
                webRequest.ServicePoint.Expect100Continue = false;

                //POST�f�[�^�쐬
                string jsonPara = FM.WebSync.Core.JSON.Serialize<News>(news);
                byte[] reqByte = Encoding.UTF8.GetBytes(jsonPara);
                webRequest.ContentLength = reqByte.Length;

                // �����N�G�X�g�J�n
                using (Stream reqStream = webRequest.GetRequestStream())
                {
                    reqStream.Write(reqByte, 0, reqByte.Length);
                }

                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                using (Stream resStream = webResponse.GetResponseStream())
                using (StreamReader sr = new StreamReader(resStream, Encoding.UTF8))
                {
                    // ���ʂ͖�����
                    st = 0;

                 
                }

            }
            // �^�C���A�E�g
            catch (WebException ex)
            {
                errMsg = "�ʒm���̕ۑ��Ɏ��s���܂����B";
                // ��O����
                this.ErrProc(ex, ref errMsg, out st);
            }
            catch (Exception ex)
            {
                errMsg = "�ʒm���̕ۑ������ŗ�O���������܂����B" + Environment.NewLine + ex.StackTrace.ToString(); ;
                st = -1;
            }
            return st;
        }
        #endregion


        #endregion

        #region �t�������ݒ�
        /// <summary>
        /// �t�������ݒ� �ۑ�����
        /// </summary>
        /// <returns></returns>
        public int SaveAttendRepairSet(ref AttendRepairSet[] para, out string errMsg)
        {
            errMsg = string.Empty;
            string resultJsonString = "";

            int st = 0;

            try
            {
                // URL�擾
                tobServerURL = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_IllustSelectWeb) + POST_Attendrepairs;
#if DEBUG
                DebugURL(ref tobServerURL, POST_Attendrepairs);
#endif


                // ���M���̐ݒ�
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(tobServerURL);
                webRequest.Method = "POST";
                webRequest.ContentType = "application/json";

                // TOB�̃��N�G�X�gKEY(�v�Í���)
                webRequest.Headers.Add("bl-app-key", "df8f7b8f-a44a-49e9-a50e-afa1f902cd4e");
                // �v���L�V�o�R�̏ꍇ�K�v
                webRequest.ServicePoint.Expect100Continue = false;

                //POST�f�[�^�쐬
                string jsonPara = FM.WebSync.Core.JSON.Serialize<AttendRepairSet[]>(para);

                byte[] reqByte = Encoding.UTF8.GetBytes(jsonPara);
                webRequest.ContentLength = reqByte.Length;

                // �����N�G�X�g�J�n
                using (Stream reqStream = webRequest.GetRequestStream())
                {
                    reqStream.Write(reqByte, 0, reqByte.Length);
                }

                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                using (Stream resStream = webResponse.GetResponseStream())
                using (StreamReader sr = new StreamReader(resStream, Encoding.UTF8))
                {
                    // ���ʎ擾
                    resultJsonString = sr.ReadToEnd();

                    if (resultJsonString != "")
                    {
                        //���ʂ��f�V���A���C�Y(�폜�����猋�ʂ��O���ɂȂ�)
                        AttendRepairSetMain main = FM.WebSync.Core.JSON.Deserialize<AttendRepairSetMain>(resultJsonString);
                        para = main.attendrepairs;
                    }
                    else
                    {
                        para = new AttendRepairSet[0];
                    }
                    st = 0;
                }

            }
            catch (WebException ex)
            {
                errMsg = "�t���������̕ۑ��Ɏ��s���܂����B";
                // ��O����
                this.ErrProc(ex, ref errMsg, out st);
            }
            catch (Exception ex)
            {
                errMsg = "�t���������̕ۑ������ŗ�O���������܂����B" + Environment.NewLine + ex.StackTrace.ToString();
                st = -1;
            }
            return st;
        }
        #endregion

        #region POST����O����
        /// <summary>
        /// ��O����
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="st"></param>
        /// <param name="errMsg"></param>
        private void ErrProc(WebException ex, ref string errMsg, out int st)
        {
            st = -1;
            try
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse errorRes = (HttpWebResponse)ex.Response;
                    st = (int)errorRes.StatusCode;

                    using (Stream resStream = ex.Response.GetResponseStream())
                    using (StreamReader sr = new StreamReader(resStream, Encoding.UTF8))
                    {
                        // ���ʎ擾
                        string errInfo = sr.ReadToEnd();
                        if (errInfo.Contains("E0003"))
                        {
                            // �r���G���[
                            errMsg += Environment.NewLine + "���ɑ��[���ɂčX�V����Ă��܂��B";
                            st = 800;
                        }
                        else
                        {
                            errMsg += Environment.NewLine + ex.StackTrace.ToString();
                        }
                    }
                }
            }
            catch
            {

            }
        }
        #endregion

        #endregion

        #region GET

        #region �t�������ݒ�

        #region ���i��
        /// <summary>
        /// �t�������ݒ�
        /// </summary>
        /// <returns></returns>
        public int GetAttendRepairSet(string enterpriseCode, out List<AttendRepairSet> attendRepairSetList, out string errMsg)
        {
            int st = 0;
            attendRepairSetList = new List<AttendRepairSet>();

            AttendRepairSetMain retJson;
            errMsg = string.Empty;

            // �ڑ�����API�ɂ���āA�����̒l��ύX
            tobServerURL = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_IllustSelectWeb) + GET_Attendrepairs;

#if DEBUG
            DebugURL(ref tobServerURL, GET_Attendrepairs);
#endif

            // ����������t�^
            string key = String.Format("?{0}={1}", "EnterpriseCode", enterpriseCode);
            tobServerURL += key;

            string resultJsonString = "";


            // ���M���̐ݒ�
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(tobServerURL);
            webRequest.Method = "GET";

            // TOB�̃��N�G�X�gKEY(�v�Í���)
            webRequest.Headers.Add("bl-app-key", "df8f7b8f-a44a-49e9-a50e-afa1f902cd4e");
            try
            {
                // ���X�|���X�̎擾
                using (WebResponse webResponse = webRequest.GetResponse())
                using (Stream responseStream = webResponse.GetResponseStream())
                using (StreamReader sr = new StreamReader(responseStream, Encoding.UTF8))
                {
                        // ���ʎ擾
                        resultJsonString = sr.ReadToEnd();
                        //���ʂ��f�V���A���C�Y
                        retJson = FM.WebSync.Core.JSON.Deserialize<AttendRepairSetMain>(resultJsonString);
                        attendRepairSetList.AddRange(retJson.attendrepairs);
                        // �\�����Ń\�[�g
                        attendRepairSetList.Sort(delegate(AttendRepairSet obj1, AttendRepairSet obj2)
                        {
                            return obj1.sortNo.CompareTo(obj2.sortNo);
                        });
                }
            }
            // �^�C���A�E�g
            catch (WebException ex)
            {
                errMsg = "�t���������̎擾�Ɏ��s���܂����B";
                st = -1;
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse errorRes = (HttpWebResponse)ex.Response;
                    st = (int)errorRes.StatusCode;
                }
            }
            catch (Exception ex)
            {
                errMsg = "�t���������擾�����ŗ�O���������܂����B" + Environment.NewLine + ex.StackTrace.ToString();
                st = -1;
            }
            return st;
        }
        #endregion

        #region �����H�ꃂ�[�h(���_�T�O����)
        /// <summary>
        /// �t�������ݒ�
        /// </summary>
        /// <returns></returns>
        public int GetAttendRepairSetSF(string enterpriseCode, string sectionCode, long goodsCategoryId, out List<AttendRepairSet> attendRepairSetList, out string errMsg)
        {
            int st = 0;
            attendRepairSetList = new List<AttendRepairSet>();

            AttendRepairSetMain retJson;
            errMsg = string.Empty;

            // �ڑ�����API�ɂ���āA�����̒l��ύX
            tobServerURL = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_IllustSelectWeb) + GET_Attendrepairs_ModeSF;

#if DEBUG
            DebugURL(ref tobServerURL, GET_Attendrepairs);
#endif

            // ����������t�^
            string key = String.Format("?{0}={1}&{2}={3}&{4}={5}", "EnterpriseCode", enterpriseCode, "SectionCode", sectionCode, "GoodsCategoryId", goodsCategoryId);
            tobServerURL += key;

            string resultJsonString = "";


            // ���M���̐ݒ�
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(tobServerURL);
            webRequest.Method = "GET";

            // TOB�̃��N�G�X�gKEY(�v�Í���)
            webRequest.Headers.Add("bl-app-key", "df8f7b8f-a44a-49e9-a50e-afa1f902cd4e");
            try
            {
                // ���X�|���X�̎擾
                using (WebResponse webResponse = webRequest.GetResponse())
                using (Stream responseStream = webResponse.GetResponseStream())
                using (StreamReader sr = new StreamReader(responseStream, Encoding.UTF8))
                {
                    // ���ʎ擾
                    resultJsonString = sr.ReadToEnd();
                    //���ʂ��f�V���A���C�Y
                    retJson = FM.WebSync.Core.JSON.Deserialize<AttendRepairSetMain>(resultJsonString);

                    // �����f�[�^�����O
                    for (int i = 0; i < retJson.attendrepairs.Length; i++)
                    {
                        if (retJson.attendrepairs[i].displayFlag)
                        {
                            attendRepairSetList.Add(retJson.attendrepairs[i]);
                        }
                    }

                    // �\�����Ń\�[�g
                    attendRepairSetList.Sort(delegate(AttendRepairSet obj1, AttendRepairSet obj2)
                    {
                        return obj1.sortNo.CompareTo(obj2.sortNo);
                    });
                }
            }
            // �^�C���A�E�g
            catch (WebException ex)
            {
                errMsg = "�t���������̎擾�Ɏ��s���܂����B";
                st = -1;
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse errorRes = (HttpWebResponse)ex.Response;
                    st = (int)errorRes.StatusCode;
                }
            }
            catch (Exception ex)
            {
                errMsg = "�t���������擾�����ŗ�O���������܂����B" + Environment.NewLine + ex.StackTrace.ToString();
                st = -1;
            }
            return st;
        }
        #endregion


        #endregion

        #region ���i�J�e�S��
        /// <summary>
        /// ���i�J�e�S���擾����
        /// </summary>
        /// <returns></returns>
        public int GetGoodsCategory(out List<GoodsCategory> categoryList, out string errMsg)
        {
            int st = 0;
            categoryList = new List<GoodsCategory>();
            errMsg = string.Empty;

            // �ڑ�����API�ɂ���āA�����̒l��ύX
            // API�ɂ���ẮA�N�G���������ݒ肷��iPOST�̏ꍇ�́A������JSON���ׂ��j

            tobServerURL = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_IllustSelectWeb) + GET_GoodsCategory;
#if DEBUG
            DebugURL(ref tobServerURL, GET_GoodsCategory);
#endif
            //System.Windows.Forms.MessageBox.Show("tobServerURL = " + tobServerURL);


            // ���M���̐ݒ�
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(tobServerURL);
            webRequest.Method = "GET";

            // TOB�̃��N�G�X�gKEY(�v�Í���)
            webRequest.Headers.Add("bl-app-key", "df8f7b8f-a44a-49e9-a50e-afa1f902cd4e");

            string resultJsonString = "";

            try
            {
                // ���X�|���X�̎擾
                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                using (Stream resStream = webResponse.GetResponseStream())
                using (StreamReader sr = new StreamReader(resStream, Encoding.UTF8))
                {
                    // ���ʎ擾
                    resultJsonString = sr.ReadToEnd();

                    //���ʂ��f�V���A���C�Y
                    GoodsCategory_MAIN main = FM.WebSync.Core.JSON.Deserialize<GoodsCategory_MAIN>(resultJsonString);
                    categoryList.AddRange(main.GoodsCategory);

                    categoryList.Sort(delegate(GoodsCategory obj1, GoodsCategory obj2)
                    {
                        // �J�e�S��ID��
                        return obj1.GoodsCategoryId.CompareTo(obj2.GoodsCategoryId);
                    });
                }
            }
            // �^�C���A�E�g
            catch (WebException ex)
            {
                errMsg = "���i�J�e�S���̎擾�Ɏ��s���܂����B";
                st = -1;
                 // HTTP�v���g�R���G���[���ǂ������ׂ�
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse errorRes = (HttpWebResponse)ex.Response;
                    st = (int)errorRes.StatusCode;
                }
            }
            catch (Exception ex)
            {
                st = -1;
                errMsg = "���i�J�e�S���擾�����ŗ�O���������܂����B" + Environment.NewLine + ex.StackTrace.ToString();
            }
            return st;
        }
        #endregion

        #region ��ď��i���

        /// <summary>
        /// ��ď��i���擾����
        /// </summary>
        /// <returns></returns>
        public int GetProposegoods(string enterpriseCode, string sectioncode, long categoryId, out List<ProposeGoods> proposeGoodsList, out string errMsg)
        {
            int st = 0;
            proposeGoodsList = new List<ProposeGoods>();
            errMsg = string.Empty;

            // �ڑ�����API�ɂ���āA�����̒l��ύX
            // API�ɂ���ẮA�N�G���������ݒ肷��iPOST�̏ꍇ�́A������JSON���ׂ��j
            tobServerURL = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_IllustSelectWeb) + GET_Goods;
#if DEBUG
            DebugURL(ref tobServerURL, GET_Goods);
#endif


            // ����������t�^
            string key = String.Format("?{0}={1}&{2}={3}&{4}={5}", "EnterpriseCode",enterpriseCode,"SectionCode",sectioncode, "GoodsCategoryId",categoryId);
            tobServerURL += key;

            // ��������
            // ��ƃR�[�h�A���_�R�[�h�A�J�e�S��
            // �߂��Ă���̂� ��ď��i���A�t����ƁA�ʐݒ�

            // ���M���̐ݒ�
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(tobServerURL);
            webRequest.Method = "GET";

            // TOB�̃��N�G�X�gKEY(�v�Í���)
            webRequest.Headers.Add("bl-app-key", "df8f7b8f-a44a-49e9-a50e-afa1f902cd4e");

            string resultJsonString = "";
            ProposeGoods_MAIN retJson = new ProposeGoods_MAIN();

            try
            {
                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                using (Stream resStream = webResponse.GetResponseStream())
                using (StreamReader sr = new StreamReader(resStream, Encoding.UTF8))
                {
                    // ���ʎ擾
                    resultJsonString = sr.ReadToEnd();

                    //���ʂ��f�V���A���C�Y
                    retJson = FM.WebSync.Core.JSON.Deserialize<ProposeGoods_MAIN>(resultJsonString);

                    proposeGoodsList.AddRange(retJson.goods);
                    proposeGoodsList.Sort(delegate(ProposeGoods obj1, ProposeGoods obj2)
                   {
                       // �\�[�g��
                       return obj1.sortNo.CompareTo(obj2.sortNo);
                   });

                    st = 0;
                } 

                // �摜�擾
                Dictionary<long, Image> imageCash = new Dictionary<long, Image>();
                foreach (ProposeGoods goods in proposeGoodsList)
	            {
            		 if(goods.imageId != 0)
                     {
                         if (imageCash.ContainsKey(goods.imageId))
                         {
                             goods.image_Data = imageCash[goods.imageId];
                         }
                         else
                         {
                             GoodsImage image = new GoodsImage();
                             st = this.GetGoodsImage(goods.enterpriseCode, goods.imageId, out image, out errMsg);
                             if (st == 0)
                             {
                                 goods.image_Data = image.imageData_Image;
                                 imageCash.Add(goods.imageId, image.imageData_Image);
                             }
                             else
                             {
                                 goods.image_Data = null;
                             }
                         }
                     }
	            }
            }
            // �^�C���A�E�g
            catch (WebException ex)
            {
                errMsg = "��ď��i�̎擾�Ɏ��s���܂����B";
                st = -1;
                // HTTP�v���g�R���G���[���ǂ������ׂ�
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse errorRes = (HttpWebResponse)ex.Response;
                    st = (int)errorRes.StatusCode;
                }
            }
            catch (Exception ex)
            {
                st = -1;
                errMsg = "��ď��i�擾�����ŗ�O���������܂����B" + Environment.NewLine + ex.StackTrace.ToString();
            }
            return st;
        }

        #endregion

        #endregion

        #region ���i���J���

        #region Get

        /// <summary>
        /// ���i���J���擾����
        /// </summary>
        /// <returns></returns>
        public int GetDestSetting(string enterpriseCode, string sectioncode, long categoryId, out List<DestSetting> destSettingList, out string errMsg)
        {
            int st = 0;
            destSettingList = new List<DestSetting>();
            errMsg = string.Empty;

            // �ڑ�URL
            tobServerURL = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_IllustSelectWeb) + COMMON_DestSettings;
#if DEBUG
            DebugURL(ref tobServerURL, COMMON_DestSettings);
#endif


            // ����������t�^
            string key = String.Format("?{0}={1}&{2}={3}&{4}={5}", "EnterpriseCode", enterpriseCode, "SectionCode", sectioncode, "GoodsCategoryId", categoryId);
            tobServerURL += key;

            // ���M���̐ݒ�
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(tobServerURL);
            webRequest.Method = "GET";

            // TOB�̃��N�G�X�gKEY(�v�Í���)
            webRequest.Headers.Add("bl-app-key", "df8f7b8f-a44a-49e9-a50e-afa1f902cd4e");

            string resultJsonString = "";

            try
            {
                // ���X�|���X�̎擾
                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                using (Stream resStream = webResponse.GetResponseStream())
                using (StreamReader sr = new StreamReader(resStream, Encoding.UTF8))
                {
                    // ���ʎ擾
                    resultJsonString = sr.ReadToEnd();
                    //���ʂ��f�V���A���C�Y
                    DestSetting_MAIN main = FM.WebSync.Core.JSON.Deserialize<DestSetting_MAIN>(resultJsonString);
                    destSettingList.AddRange(main.destSettings);
                }
            }
            // �^�C���A�E�g
            catch (WebException ex)
            {
                errMsg = "���i���J���̎擾�Ɏ��s���܂����B";
                st = -1;
                 // HTTP�v���g�R���G���[���ǂ������ׂ�
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse errorRes = (HttpWebResponse)ex.Response;
                    st = (int)errorRes.StatusCode;
                }
            }
            catch (Exception ex)
            {
                st = -1;
                errMsg = "���i�J���擾�����ŗ�O���������܂����B" + Environment.NewLine + ex.StackTrace.ToString();
            }
            return st;
        }

        #endregion

        #region Delete

        /// <summary>
        /// ���i���J��~����
        /// </summary>
        /// <returns></returns>
        public int DeleteDestSetting(DestSetting para, out string errMsg)
        {
            errMsg = string.Empty;
            string resultJsonString = "";

            int st = 0;

            try
            {
                // URL�擾
                tobServerURL = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_IllustSelectWeb) + COMMON_DestSettings;
#if DEBUG
                DebugURL(ref tobServerURL, COMMON_DestSettings);
#endif


                // ����������t�^
                string key = String.Format("?{0}={1}&{2}={3}&{4}={5}&{6}={7}", "EnterpriseCode", para.enterpriseCode, "SectionCode", para.sectionCode, "GoodsCategoryId", para.goodsCategoryId, "ProposeDestId", para.proposeDestId);
                tobServerURL += key;

                // ���M���̐ݒ�
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(tobServerURL);
                webRequest.Method = "DELETE";
                webRequest.ContentType = "application/json";

                // TOB�̃��N�G�X�gKEY(�v�Í���)
                webRequest.Headers.Add("bl-app-key", "df8f7b8f-a44a-49e9-a50e-afa1f902cd4e");
                // �v���L�V�o�R�̏ꍇ�K�v
                webRequest.ServicePoint.Expect100Continue = false;

                using (WebResponse webResponse = webRequest.GetResponse())
                using (Stream responseStream = webResponse.GetResponseStream())
                using (StreamReader sr = new StreamReader(responseStream, Encoding.UTF8))
                {
                    // ���ʎ擾 �ˁ@�폜�Ȃ�Ō��ʂȂ���
                    resultJsonString = sr.ReadToEnd();
                    st = 0;
                }
            }
            catch (WebException ex)
            {
                errMsg = "���i�̌��J��~�Ɏ��s���܂����B";
                // ��O����
                this.ErrProc(ex, ref errMsg, out st);
            }
            catch (Exception ex)
            {
                st = -1;
                errMsg = "���i���J��~�����ŗ�O���������܂����B" + Environment.NewLine + ex.StackTrace.ToString();
            }
            return st;
        }

        /// <summary>
        /// ���i���J��~����
        /// </summary>
        /// <returns></returns>
        public int DeleteDestSetting_bulk(List<DestSetting> delList, out string errMsg)
        {
            errMsg = string.Empty;
            string resultJsonString = "";

            int st = 0;

            try
            {
                // URL�擾
                tobServerURL = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_IllustSelectWeb) + DELET_BULK_DestSettings;
#if DEBUG
                DebugURL(ref tobServerURL, DELET_BULK_DestSettings);
#endif


                // ���M���̐ݒ�
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(tobServerURL);
                webRequest.Method = "POST";
                webRequest.ContentType = "application/json";

                // TOB�̃��N�G�X�gKEY(�v�Í���)
                webRequest.Headers.Add("bl-app-key", "df8f7b8f-a44a-49e9-a50e-afa1f902cd4e");
                // �v���L�V�o�R�̏ꍇ�K�v
                webRequest.ServicePoint.Expect100Continue = false;



                //POST�f�[�^�쐬
                string jsonPara = FM.WebSync.Core.JSON.Serialize<DestSetting[]>(delList.ToArray());
                byte[] reqByte = Encoding.UTF8.GetBytes(jsonPara);

                webRequest.ContentLength = reqByte.Length;

                // �����N�G�X�g�J�n
                using (Stream reqStream = webRequest.GetRequestStream())
                {
                    reqStream.Write(reqByte, 0, reqByte.Length);
                }

                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                using (Stream resStream = webResponse.GetResponseStream())
                using (StreamReader sr = new StreamReader(resStream, Encoding.UTF8))
                {
                    // ���ʎ擾
                    resultJsonString = sr.ReadToEnd();
                    // �폜�Ȃ�Ō��ʂ͂Ȃ���
                    st = 0;
                }
            }
            catch (WebException ex)
            {
                errMsg = "���i�̌��J��~�Ɏ��s���܂����B";
                // ��O����
                this.ErrProc(ex, ref errMsg, out st);
            }
            catch (Exception ex)
            {
                st = -1;
                errMsg = "���i���J��~�����ŗ�O���������܂����B" + Environment.NewLine + ex.StackTrace.ToString();
            }
            return st;
        }

        #endregion

        #endregion

        #region ���i�摜

        #region �摜�h�c���X�g�擾
        /// <summary>
        /// �摜�h�c���X�g�擾
        /// </summary>
        /// <returns></returns>
        public int GetGoodsImageIdList(string enterpriseCode, out List<GoodsImage> goodsImageList, out string errMsg)
        {
            // �摜��ID���ꗗ�Ŏ擾��A�P�����É摜���擾����
            // TODO ���[�J���L���b�V��
            // �摜ID����Temp�t�H���_�ɃL���b�V�����쐬���āA�L���b�V��������΂���������悤�Ȏd�g�݂��l����

            int st = 0;
            goodsImageList = new List<GoodsImage>();
            GoodsImage[] retJson = null;
            errMsg = string.Empty;

            // �ڑ�����API�ɂ���āA�����̒l��ύX
            // API�ɂ���ẮA�N�G���������ݒ肷��iPOST�̏ꍇ�́A������JSON���ׂ��j
            tobServerURL = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_IllustSelectWeb) + COMMON_GoodsImage;
#if DEBUG
            DebugURL(ref tobServerURL, COMMON_GoodsImage);
#endif


            // ����������t�^
            string key = String.Format("?{0}={1}", "EnterpriseCode", enterpriseCode);
            tobServerURL += key;

            string resultJsonString = "";

            // ���M���̐ݒ�
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(tobServerURL);
            webRequest.Method = "GET";

            // TOB�̃��N�G�X�gKEY(�v�Í���)
            webRequest.Headers.Add("bl-app-key", "df8f7b8f-a44a-49e9-a50e-afa1f902cd4e");
            try
            {
                // ���X�|���X�̎擾
                using (WebResponse webResponse = webRequest.GetResponse())
                using (Stream responseStream = webResponse.GetResponseStream())
                using (StreamReader sr = new StreamReader(responseStream, Encoding.UTF8))
                {
                    // ���׌y���ׂ̈ɏ��߂ɉ摜�h�c���X�g���擾
                    // ���ʎ擾
                    resultJsonString = sr.ReadToEnd();
                    //���ʂ��f�V���A���C�Y
                    retJson = FM.WebSync.Core.JSON.Deserialize<GoodsImage[]>(resultJsonString);
                    if (retJson != null)
                    {
                        goodsImageList.AddRange(retJson);
                    }
                }
            }
            // �^�C���A�E�g
            catch (WebException ex)
            {
                errMsg = "���i�摜�̎擾�Ɏ��s���܂����B";
                st = -1;
                // HTTP�v���g�R���G���[���ǂ������ׂ�
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse errorRes = (HttpWebResponse)ex.Response;
                    st = (int)errorRes.StatusCode;
                }
            }
            catch (Exception ex)
            {
                st = -1;
                errMsg = "���i�摜�擾�����ŗ�O���������܂����B" + Environment.NewLine + ex.StackTrace.ToString();
            }
            return st;
        }
        #endregion

        #region ���i�摜�擾
        /// <summary>
        /// ���i�摜�擾
        /// </summary>
        /// <returns></returns>
        public int GetGoodsImage(string enterpriseCode, long imageId,  out GoodsImage goodsImage, out string errMsg)
        {
            // �摜��ID���ꗗ�Ŏ擾��A�P�����É摜���擾����
            // TODO ���[�J���L���b�V��
            // �摜ID����Temp�t�H���_�ɃL���b�V�����쐬���āA�L���b�V��������΂���������悤�Ȏd�g�݂��l����

            int st = 0;
            goodsImage = new GoodsImage();
            errMsg = string.Empty;

            // �ڑ�����API�ɂ���āA�����̒l��ύX
            // API�ɂ���ẮA�N�G���������ݒ肷��iPOST�̏ꍇ�́A������JSON���ׂ��j
            tobServerURL = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_IllustSelectWeb) + COMMON_GoodsImage + "/json/";
#if DEBUG
            DebugURL(ref tobServerURL, COMMON_GoodsImage + "/json/");
#endif


            // ����������t�^
            string key = String.Format("{0}?{1}={2}", imageId.ToString(), "EnterpriseCode", enterpriseCode);
            tobServerURL += key;

            string resultJsonString = "";

            // ���M���̐ݒ�
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(tobServerURL);
            webRequest.Method = "GET";

            // TOB�̃��N�G�X�gKEY(�v�Í���)
            webRequest.Headers.Add("bl-app-key", "df8f7b8f-a44a-49e9-a50e-afa1f902cd4e");
            try
            {
                // ���X�|���X�̎擾
                using (WebResponse webResponse = webRequest.GetResponse())
                using (Stream responseStream = webResponse.GetResponseStream())
                using (StreamReader sr = new StreamReader(responseStream, Encoding.UTF8))
                {
                    // ���׌y���ׂ̈ɏ��߂ɉ摜�h�c���X�g���擾
                    // ���ʎ擾
                    resultJsonString = sr.ReadToEnd();
                    //���ʂ��f�V���A���C�Y
                    goodsImage = FM.WebSync.Core.JSON.Deserialize<GoodsImage>(resultJsonString);
                    if (goodsImage != null)
                    {
                        // �摜����
                        goodsImage.imageData_Image = Base64ToImage(goodsImage.imageData);
                        if (goodsImage.imageKeyword == null) goodsImage.imageKeyword = "";
                        if (goodsImage.imageData_Image == null)
                        {
                            st = -1;
                            errMsg = "�摜�̕����Ɏ��s���܂����B";
                        }
                    }
                }
            }
            // �^�C���A�E�g
            catch (WebException ex)
            {
                errMsg = "���i�摜�̎擾�Ɏ��s���܂����B";
                st = -1;
                // HTTP�v���g�R���G���[���ǂ������ׂ�
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse errorRes = (HttpWebResponse)ex.Response;
                    st = (int)errorRes.StatusCode;
                    if (st == 400)
                    {
                        // �摜�������Ă���ꍇ
                        goodsImage.imageData_Image = null;
                        st = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                st = -1;
                errMsg = "���i�摜�擾�����ŗ�O���������܂����B" + Environment.NewLine + ex.StackTrace.ToString();
            }
            return st;
        }
        #endregion

        #region �摜�o�^
        /// <summary>
        /// ��ď��i�ۑ�����
        /// </summary>
        /// <returns></returns>
        public int SaveGoodsImage(int mode, ref GoodsImage para, out string errMsg)
        {
            errMsg = string.Empty;
            string resultJsonString = "";

            int st = 0;

            try
            {
                // URL�擾
                tobServerURL = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_IllustSelectWeb) + COMMON_GoodsImage;
#if DEBUG
                DebugURL(ref tobServerURL, COMMON_GoodsImage);
#endif

                if (mode == 3)
                {
                    // ����������t�^
                    string key = "/" + String.Format("{0}?{1}={2}", para.imageId.ToString(), "EnterpriseCode", para.enterpriseCode);
                    tobServerURL += key;
                }

                // ���M���̐ݒ�
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(tobServerURL);

                switch (mode)
                {
                    case 1:   // �V�K�o�^
                        webRequest.Method = "POST";
                        break;
                    case 2:   // �X�V
                        webRequest.Method = "PUT";
                        break;
                    case 3:�@ // �폜
                        webRequest.Method = "DELETE";
                        break;
                    default:
                        webRequest.Method = "POST";
                        break;
                }
                
                webRequest.ContentType = "application/json";

                // TOB�̃��N�G�X�gKEY(�v�Í���)
                webRequest.Headers.Add("bl-app-key", "df8f7b8f-a44a-49e9-a50e-afa1f902cd4e");
                // �v���L�V�o�R�̏ꍇ�K�v
                webRequest.ServicePoint.Expect100Continue = false;


                GoodsImage damy = new GoodsImage();

                if (mode != 3)
                {
                    // Image��Base64
                    para.imageData = ImageToBase64(para.imageData_Image);
                    if (string.IsNullOrEmpty(para.imageData))
                    {
                        errMsg = "�摜�̈��k�Ɏ��s���܂����B";
                        st = -1;
                        return st;
                    }

                    // �摜��FM���i�ɑΉ����ĂȂ��̂�
                    damy = para.Clone();
                    damy.imageData_Image = null;

                    //POST�f�[�^�쐬
                    string jsonPara = FM.WebSync.Core.JSON.Serialize<GoodsImage>(damy);
                    byte[] reqByte = Encoding.UTF8.GetBytes(jsonPara);
                    webRequest.ContentLength = reqByte.Length;

                    // �����N�G�X�g�J�n
                    using (Stream reqStream = webRequest.GetRequestStream())
                    {
                        reqStream.Write(reqByte, 0, reqByte.Length);
                    }

                }
                using (WebResponse webResponse = webRequest.GetResponse())
                using (Stream responseStream = webResponse.GetResponseStream())
                using (StreamReader sr = new StreamReader(responseStream, Encoding.UTF8))
                {
                    // ���ʎ擾
                    resultJsonString = sr.ReadToEnd();
                    // �폜�ȊO
                    if (mode != 3)
                    {
                        //���ʂ��f�V���A���C�Y
                        GoodsImage_MAIN main = FM.WebSync.Core.JSON.Deserialize<GoodsImage_MAIN>(resultJsonString);
                        if (main != null && main.image != null)
                        {
                            damy = main.image;
                            damy.imageData_Image = para.imageData_Image;
                            para = damy;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    st = 0;
                }
            }
            // �^�C���A�E�g
            catch (WebException ex)
            {
                errMsg = "���i�摜�̓o�^�Ɏ��s���܂����B";
                // ��O����
                this.ErrProc(ex, ref errMsg, out st);
            }
            catch (Exception ex)
            {
                st = -1;
                errMsg = "���i�摜�o�^�����ŗ�O���������܂����B" + Environment.NewLine + ex.StackTrace.ToString();
            }
            return st;
        }

        #endregion

        #endregion

        #region ����ݒ�

        #region POST
        /// <summary>
        /// ����ݒ�(�o�^�E�X�V�E�폜)
        /// </summary>
        /// <returns></returns>
        public int SaveSettings(ref List<Settings> settingsList, out string errMsg)
        {
            errMsg = string.Empty;
            string resultJsonString = "";

            int st = 0;

            try
            {
                // URL�擾
                tobServerURL = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_IllustSelectWeb) + COMMON_BULK_Settings;
#if DEBUG
                DebugURL(ref tobServerURL, COMMON_BULK_Settings);
#endif
                 // ���M���̐ݒ�
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(tobServerURL);
                webRequest.Method = "POST";
                webRequest.ContentType = "application/json";

                // TOB�̃��N�G�X�gKEY(�v�Í���)
                webRequest.Headers.Add("bl-app-key", "df8f7b8f-a44a-49e9-a50e-afa1f902cd4e");
                // �v���L�V�o�R�̏ꍇ�K�v
                webRequest.ServicePoint.Expect100Continue = false;

                //POST�f�[�^�쐬
                string jsonPara = FM.WebSync.Core.JSON.Serialize<Settings[]>(settingsList.ToArray());
                byte[] reqByte = Encoding.UTF8.GetBytes(jsonPara);
                webRequest.ContentLength = reqByte.Length;

                // �����N�G�X�g�J�n
                using (Stream reqStream = webRequest.GetRequestStream())
                {
                    reqStream.Write(reqByte, 0, reqByte.Length);
                }

                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                using (Stream resStream = webResponse.GetResponseStream())
                using (StreamReader sr = new StreamReader(resStream, Encoding.UTF8))
                {
                    // ���ʎ擾
                    resultJsonString = sr.ReadToEnd();
                    st = 0;

                    //���ʂ��f�V���A���C�Y
                    Settings_MAIN main = FM.WebSync.Core.JSON.Deserialize<Settings_MAIN>(resultJsonString);
                    if (main != null && main.settings != null)
                    {
                        settingsList.Clear();
                        settingsList.AddRange(main.settings);
                    }
                    else
                    {
                        errMsg = "����ݒ�̓o�^�Ɏ��s���܂����B";
                        st = -1;
                    }
                }
            }
            catch (WebException ex)
            {
                errMsg = "����ݒ�̓o�^�Ɏ��s���܂����B";
                // ��O����
                this.ErrProc(ex, ref errMsg, out st);
            }
            catch (Exception ex)
            {
                st = -1;
                errMsg = "����ݒ�o�^�����ŗ�O���������܂����B" + Environment.NewLine + ex.StackTrace.ToString();
            }
            return st;
        }
        #endregion

        #region Get
        /// <summary>
        /// ����ݒ���擾����
        /// </summary>
        /// <returns></returns>
        public int GetSettings(string enterpriseCode, out List<Settings> settingsList, out string errMsg)
        {
            int st = 0;
            settingsList = new List<Settings>();
            errMsg = string.Empty;

            // �ڑ�����API�ɂ���āA�����̒l��ύX
            // API�ɂ���ẮA�N�G���������ݒ肷��iPOST�̏ꍇ�́A������JSON���ׂ��j
            tobServerURL = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_IllustSelectWeb) + GET_Settings;
#if DEBUG
            DebugURL(ref tobServerURL, GET_Settings);
#endif

            // ����������t�^
            string key = String.Format("?{0}={1}", "EnterpriseCode",enterpriseCode);
            tobServerURL += key;
       
            // ���M���̐ݒ�
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(tobServerURL);
            webRequest.Method = "GET";

            // TOB�̃��N�G�X�gKEY(�v�Í���)
            webRequest.Headers.Add("bl-app-key", "df8f7b8f-a44a-49e9-a50e-afa1f902cd4e");
            //webRequest.ServicePoint.Expect100Continue = false;

            string resultJsonString = "";
            Settings_MAIN retJson = new Settings_MAIN();

            try
            {
                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                using (Stream resStream = webResponse.GetResponseStream())
                using (StreamReader sr = new StreamReader(resStream, Encoding.UTF8))
                {
                    // ���ʎ擾
                    resultJsonString = sr.ReadToEnd();

                    //���ʂ��f�V���A���C�Y
                    retJson = FM.WebSync.Core.JSON.Deserialize<Settings_MAIN>(resultJsonString);
                    settingsList.AddRange(retJson.settings);
                    st = 0;
                } 
            }
            catch (WebException ex)
            {
                errMsg = "����ݒ�̎擾�Ɏ��s���܂����B";
                st = -1;
                // HTTP�v���g�R���G���[���ǂ������ׂ�
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse errorRes = (HttpWebResponse)ex.Response;
                    st = (int)errorRes.StatusCode;
                }
            }
            catch (Exception ex)
            {
                st = -1;
                errMsg = "����ݒ�擾�����ŗ�O���������܂����B" + Environment.NewLine + ex.StackTrace.ToString();
            }
            return st;
        }

        #endregion

        #endregion


        /// <summary>
        /// �摜�ϊ�����
        /// </summary>
        /// <returns></returns>
        private Image Base64ToImage(string imageBase64)
        {
            Image img = null;
            try
            {
                byte[] imageBytes = System.Convert.FromBase64String(imageBase64);
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBytes, 0, imageBytes.Length))
                {
                    img = Image.FromStream(ms, true);
                }
            }
            catch
            {
                img = null;
            }
            return img;
        }

        /// <summary>
        /// Base64�ϊ�����
        /// </summary>
        /// <returns></returns>
        private string ImageToBase64(Image image)
        {
            string base64String = string.Empty;
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, image.RawFormat);
                    byte[] imageBytes = ms.ToArray();
                    base64String = Convert.ToBase64String(imageBytes);
                }
            }
            catch
            {
                base64String = "";
            }
            return base64String;
        }

        #endregion
    }


 
}

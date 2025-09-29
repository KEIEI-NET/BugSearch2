using System;
using System.Net;
using System.Collections.Generic;
using System.Collections;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;

#if DEBUG
using ScmOdrData = Broadleaf.Application.UIData.StubDB.ScmOdrData;
#else
    using ScmOdrData = Broadleaf.Application.UIData.ScmOdrData;
#endif

namespace Broadleaf.Application.Controller.NetworkConfig
{
    /// <summary>
    /// DBネットワーク設定クラス
    /// </summary>
    public class DBNetworkConfig : AbstractNetworkConfig
    {
        #region <AbstractNetworkConfig メンバ>

        /// <summary>
        /// IPアドレスを取得します。
        /// </summary>
        /// <see cref="AbstractNetworkConfig"/>
        public override IPAddress IPAddress
        {
            get
            {
                return _ipAdress;
            }
        }

        /// <summary>
        /// ポート番号を取得します。
        /// </summary>
        /// <see cref="AbstractNetworkConfig"/>
        public override int PortNumber
        {
            get
            {
                return _portNumber;
            }
        }

        /// <summary>
        /// 初期化します。
        /// </summary>
        /// <see cref="AbstractNetworkConfig"/>
        protected override void Initialize()
        {
            Clear();
        }

        #endregion // </AbstractNetworkConfig メンバ>

        #region private変数
        private SCMNewArrNtfyStAcs _scmNewArrNtfyStAcs; // 新着通知マスタ
        private PosTerminalMgAcs _posTerminalMgAcs; // 端末管理マスタ

        private readonly IPAddress _ipAdress;
        private readonly int _portNumber;
        #endregion

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public DBNetworkConfig() : base()
        {
            this._scmNewArrNtfyStAcs = new SCMNewArrNtfyStAcs();
            this._posTerminalMgAcs = new PosTerminalMgAcs();
        }

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public DBNetworkConfig(IPAddress ipAddress, int portNumber)
            : base()
        {
            this._scmNewArrNtfyStAcs = new SCMNewArrNtfyStAcs();
            this._posTerminalMgAcs = new PosTerminalMgAcs();

            this._ipAdress = ipAddress;
            this._portNumber = portNumber;
        }

        #endregion // </Constructor>

        #region <publicメソッド>
        /// <summary>
        /// 端末管理マスタのIPアドレス文字列リストを取得します。
        /// </summary>
        /// <param name="scmOdrDataList">SCM受発注データリスト</param>
        /// <param name="portNumber">ポップアップ命令送信用ポート番号</param>
        /// <param name="enterpriseCd">自企業コード</param>
        /// <returns>端末管理マスタのIPアドレスの文字列リスト</returns>
        public void GetIPAddressInfo(List<ISCMOrderHeaderRecord> userHeaderList, int portNumber, string enterpriseCd)
        {
            // 送信先IPアドレスリスト
            List<string> ipAddressList = new List<string>();
            List<string> ipAddressGetList = new List<string>();

            // 処理済キーリスト(得意先コード、問合せ先拠点コード)
            Dictionary<int, List<string>> finishedKeyDic = new Dictionary<int, List<string>>();

            foreach (UserSCMOrderHeaderWrapper userHeader in userHeaderList)
            {
                if (finishedKeyDic.ContainsKey(userHeader.CustomerCode))
                {
                    if (finishedKeyDic[userHeader.CustomerCode].Contains(userHeader.InqOtherSecCd))
                    {
                        // 処理済み
                        continue;
                    }
                }

                // 検索処理からIPを取得
                ipAddressGetList = this.GetIPAddress(userHeader.CustomerCode, userHeader.InqOtherSecCd, enterpriseCd);

                if ((ipAddressGetList != null) && (ipAddressGetList.Count != 0))
                {
                    foreach (string addr in ipAddressGetList)
                    {
                        if (!ipAddressList.Contains(addr))
                        {
                            ipAddressList.Add(addr);
                        }
                    }
                }

                // 処理済みの企業、拠点情報を取得
                if (finishedKeyDic.ContainsKey(userHeader.CustomerCode))
                {
                    finishedKeyDic[userHeader.CustomerCode].Add(userHeader.InqOtherSecCd);
                }
                else
                {
                    List<string> secList = new List<string>();
                    secList.Add(userHeader.InqOtherSecCd);

                    finishedKeyDic.Add(userHeader.CustomerCode, secList);
                }
            }

            foreach (string ipAddress in ipAddressList)
            {
                Add(new NetworkConfigImpl(ipAddress, portNumber));
            }
        }
        #endregion

        #region <privateメソッド>

        /// <summary>
        /// IPアドレス取得処理
        /// </summary>
        /// <param name="customerCd"></param>
        /// <param name="sectionCd"></param>
        /// <param name="enterpriseCd"></param>
        /// <returns></returns>
        private List<string> GetIPAddress(int customerCd, string sectionCd, string enterpriseCd)
        {
            List<string> retIPAddressList = new List<string>();

            // 企業コードと得意先コード、拠点コードより新着通知設定マスタ情報取得
            List<SCMNewArrNtfySt> scmNewArrNtfyStList = this.GetSCMNewArrNtfyStInfo(customerCd, sectionCd, enterpriseCd);

            if ((scmNewArrNtfyStList == null) || (scmNewArrNtfyStList.Count == 0)) return null;

            // 企業コードとレジ番号より端末管理マスタ取得
            List<PosTerminalMg> posTerminalMgList = this.GetPosTerminalMgInfo(scmNewArrNtfyStList, enterpriseCd);

            if ((posTerminalMgList != null) || (posTerminalMgList.Count != 0))
            {
                foreach (PosTerminalMg rec in posTerminalMgList)
                {
                    retIPAddressList.Add(rec.MachineIpAddr);
                }
            }
            return retIPAddressList;
        }

        /// <summary>
        /// SCM新着通知マスタ情報取得
        /// </summary>
        /// <param name="customerCd"></param>
        /// <param name="sectionCd"></param>
        /// <param name="enterpriseCd"></param>
        /// <returns></returns>
        private List<SCMNewArrNtfySt> GetSCMNewArrNtfyStInfo(int customerCd, string sectionCd, string enterpriseCd)
        {
            // 初期処理
            ArrayList al;
            List<SCMNewArrNtfySt> retSCMNewArrNtfyStList = new List<SCMNewArrNtfySt>();
            List<SCMNewArrNtfySt> scmNewArrNtfyStList = new List<SCMNewArrNtfySt>();
            string allSectionCd = "00";

            // SCM新着通知マスタ全件取得
            // TODO:ゴミ掃除…論理削除分を含むので撤去→this._scmNewArrNtfyStAcs.SearchAll(out al, enterpriseCd);
            this._scmNewArrNtfyStAcs.SearchAvailable(out al, enterpriseCd);

            // 取得不可の場合、終了
            if ((al == null) || (al.Count == 0)) return null;

            // リスト変換
            scmNewArrNtfyStList = new List<SCMNewArrNtfySt>((SCMNewArrNtfySt[])al.ToArray(typeof(SCMNewArrNtfySt)));

            // 得意先設定／拠点設定／全社設定取得
            retSCMNewArrNtfyStList = scmNewArrNtfyStList.FindAll(
                delegate(SCMNewArrNtfySt scmNew)
                {
                    if (((string.IsNullOrEmpty(scmNew.SectionCode.Trim())) && (scmNew.CustomerCode == customerCd)) ||  // 得意先設定
                        ((scmNew.CustomerCode == 0) && (scmNew.SectionCode.Trim() == sectionCd.Trim())) ||      // 拠点設定
                        ((scmNew.CustomerCode == 0) && (scmNew.SectionCode.Trim() == allSectionCd)))            // 全社設定
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            return retSCMNewArrNtfyStList;
        }

        /// <summary>
        /// 端末管理マスタ情報取得
        /// </summary>
        /// <param name="scmNewArrNtfyStList"></param>
        /// <param name="enterpriseCd"></param>
        /// <returns></returns>
        private List<PosTerminalMg> GetPosTerminalMgInfo(List<SCMNewArrNtfySt> scmNewArrNtfyStList, string enterpriseCd)
        {
            List<PosTerminalMg> retPosTerminalMgList = new List<PosTerminalMg>();

            foreach (SCMNewArrNtfySt rec in scmNewArrNtfyStList)
            {
                PosTerminalMg posTerminalMg;
                int status = this._posTerminalMgAcs.Read(out posTerminalMg, enterpriseCd, rec.CashRegisterNo);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) retPosTerminalMgList.Add(posTerminalMg);
            }

            return retPosTerminalMgList;
        }
        #endregion
    }
}

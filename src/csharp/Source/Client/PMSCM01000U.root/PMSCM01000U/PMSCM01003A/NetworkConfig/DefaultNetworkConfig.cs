using System;
using System.Collections.Generic;
using System.Management;
using System.Net;

namespace Broadleaf.Application.Controller.NetworkConfig
{
    /// <summary>
    /// デフォルトネットワーク設定クラス
    /// </summary>
    public sealed class DefaultNetworkConfig : AbstractNetworkConfig
    {
        #region <AbstractNetworkConfig メンバ>

        /// <summary>IPアドレス</summary>
        private readonly IPAddress _ipAddress;
        /// <summary>IPアドレスを取得します。</summary>
        /// <see cref="AbstractNetworkConfig"/>
        public override IPAddress IPAddress { get { return _ipAddress; } }

        /// <summary>ポート番号</summary>
        private readonly int _portNumber;
        /// <summary>ポート番号を取得します。</summary>
        /// <see cref="AbstractNetworkConfig"/>
        public override int PortNumber { get { return _portNumber; } }

        /// <summary>
        /// 初期化します。
        /// </summary>
        /// <see cref="AbstractNetworkConfig"/>
        protected override void Initialize()
        {
            Clear();
        }

        #region <publicメソッド>
        /// <summary>
        /// IPアドレス文字列リストを取得します。
        /// </summary>
        /// <param name="portNumber">ポート番号</param>
        /// <returns>端末管理マスタのIPアドレスの文字列リスト</returns>
        public void GetLocalIPAddressInfo(int portNumber)
        {
            IList<string> localIPAddressList = GetLocalIPAddressList();

            foreach (string enmIPAddress in localIPAddressList)
            {
                Add(new NetworkConfigImpl(enmIPAddress, portNumber));
            }
        }
        #endregion

        #endregion // </AbstractNetworkConfig メンバ>

        #region <ローカル設定>

        /// <summary>デフォルトLAN接続番号</summary>
        private const int DEFAULT_LAN_NUMBER = 0;

        /// <summary>デフォルトポート番号</summary>
        private const int DEFAULT_PORT_NUMBER = 65000;

        /// <summary>
        /// ローカルIPアドレス文字列リストを取得します。
        /// </summary>
        /// <returns>ローカルIPアドレスの文字列リスト</returns>
        private static IList<string> GetLocalIPAddressList()
        {
            IList<string> localIPAddressList = new List<string>();
            {
                ManagementScope scope = new ManagementScope("root\\cimv2");
                scope.Connect();

                ManagementClass networkAdapterConfig = new ManagementClass(
                    scope,
                    new ManagementPath("Win32_NetworkAdapterConfiguration"),
                    null
                );

                ManagementObjectCollection configCollection = networkAdapterConfig.GetInstances();
                foreach (ManagementObject enmConfig in configCollection)
                {
                    if ((bool)enmConfig.Properties["IPEnabled"].Value)
                    {
                        foreach (string strIPAddress in (string[])enmConfig["IPAddress"])
                        {
                            localIPAddressList.Add(strIPAddress);
                        }
                    }
                }
            }
            return localIPAddressList;
        }

        #endregion // </ローカル設定>

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public DefaultNetworkConfig() : base()
        {
        }

        public DefaultNetworkConfig(IPAddress ipAddress, int portNumber)
        {
            _ipAddress = ipAddress;
            _portNumber = portNumber;
        }

        #endregion // </Constructor>
    }
}

using System;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// 起動インターフェース
    /// </summary>
    public interface IRunable : IDisposable
    {
        /// <summary>起動します。</summary>
        void Run();
    }
}

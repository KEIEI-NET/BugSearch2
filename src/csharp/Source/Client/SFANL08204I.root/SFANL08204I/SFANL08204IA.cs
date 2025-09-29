using System;
using System.Drawing;
using System.Collections.Generic;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// 自由帳票印刷処理のインターフェースです。
    /// </summary>
    /// <remarks>
    /// <br>Note		: 自由帳票の印刷クラス用インターフェースです。</br>
    /// <br>Programmer	: 22011 柏原 頼人</br>
    /// <br>Date		: 2007.03.27</br>
    /// <br></br>
    /// <br>UpdateNote	: </br>
    /// </remarks>
    public interface IFrePprPrintProc
    {
        // プロパティ
        /// <summary>
        /// 印刷に必要な情報です。
        /// </summary>
        SFANL08205C Printinfo { get;set;}
        // メソッド
        /// <summary>印刷を開始させるメソッドです。</summary>
        int StartPrint();

    }

    /// <summary>
    /// 自由帳票抽出処理のインターフェースです。
    /// </summary>
    /// <remarks>
    /// <br>Note		: 自由帳票の抽出クラス用インターフェースです。</br>
    /// <br>Programmer	: 22011 柏原 頼人</br>
    /// <br>Date		: 2007.07.13</br>
    /// <br></br>
    /// <br>UpdateNote	: </br>
    /// </remarks>
    public interface IFrePprExtraProc
    {
        // プロパティ
        /// <summary>印刷に必要な情報です。</summary>
        SFANL08205C Printinfo { get;set;}
        
        // メソッド
        /// <summary>抽出を開始させるメソッドです。</summary>
        int ExtrPrintData();
    }
}

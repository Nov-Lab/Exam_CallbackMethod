// @(h)MyTraceListener.cs ver 0.00 ( '24.01.18 Nov-Lab ) 作成開始
// @(h)MyTraceListener.cs ver 0.51 ( '24.01.18 Nov-Lab ) ベータ版完成。

// @(s)
// 　【トレースリスナー】トレース出力やデバッグ出力をテスト用フォームへ転送する機能を提供します。

using System;
using System.Diagnostics;
using System.Collections.Generic;


namespace Exam_CallbackMethod
{
    //====================================================================================================
    /// <summary>
    /// 【トレースリスナー】トレース出力やデバッグ出力をテスト用フォームへ転送する機能を提供します。
    /// </summary>
    //====================================================================================================
    public partial class MyTraceListener : TraceListener
    {
        protected readonly FrmAppCallbackTest m_target;

        public MyTraceListener(FrmAppCallbackTest target)
        {
            m_target = target;
        }

        public override void Write(string message) => m_target.AppendTrace(message);

        public override void WriteLine(string message) => m_target.AppendTrace(message);

    } // class

} // namespace

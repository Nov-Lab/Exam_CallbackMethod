﻿// @(h)TestCallback.cs ver 0.00 ( '24.01.18 Nov-Lab ) 作成開始
// @(h)TestCallback.cs ver 0.51 ( '24.01.18 Nov-Lab ) ベータ版完成。
// @(h)TestCallback.cs ver 0.52 ( '24.01.21 Nov-Lab ) 機能追加：インターフェイス呼び出しのテストを追加した。

// @(s)
// 　【コールバックテスト】各種コールバック方法をテストします。

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Reflection;


namespace Exam_CallbackMethod
{
    // ＜メモ＞
    // ・インターフェイスには目印用属性はない。インターフェイスにキャストできるかどうかで判別可能なので。
    //====================================================================================================
    // 目印用属性クラス
    //====================================================================================================
    /// <summary>
    /// 【デリゲート呼び出し用メソッド属性】デリゲート呼び出し用のテストメソッドであることを示す目印です。
    /// </summary>
    public class CallbackDelegateAttribute : Attribute { }

    /// <summary>
    /// 【MethodInfo.Invoke 呼び出し用メソッド属性】MethodInfo.Invoke 呼び出し用のテストメソッドであることを示す目印です。
    /// </summary>
    public class CallbackMethodAttribute : Attribute { }

    /// <summary>
    /// 【イベント呼び出し用メソッド属性】イベント呼び出し用のテストメソッドであることを示す目印です。
    /// </summary>
    public class CallbackEventAttribute : Attribute { }


    //====================================================================================================
    /// <summary>
    /// 【コールバックテスト】各種コールバック方法をテストします。
    /// </summary>
    //====================================================================================================
    public partial class TestCallback
    {
        //====================================================================================================
        // デリゲートを使う方法
        //====================================================================================================

        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【デリゲート呼び出し用メソッドのデリゲート定義】
        /// </summary>
        /// <param name="message">         [in ]：メッセージ文字列</param>
        /// <param name="requestException">[in ]：例外要求フラグ</param>
        /// <returns>
        /// 処理結果
        /// </returns>
        //--------------------------------------------------------------------------------
        public delegate string TestFunc(string message, bool requestException);


        //--------------------------------------------------------------------------------
        /// <summary>【デリゲート呼び出し用メソッド1】</summary>
        //--------------------------------------------------------------------------------
        [CallbackDelegate()]
        public static string ByDelegate1(string message, bool requestException)
        {
            if (requestException)
            {
                throw new Exception("例外を要求されました");  // デリゲート呼び出しの場合はここで中断される
            }

            return "OK1:" + message;
        }


        //--------------------------------------------------------------------------------
        /// <summary>【デリゲート呼び出し用メソッド2】</summary>
        //--------------------------------------------------------------------------------
        [CallbackDelegate()]
        public static string ByDelegate2(string message, bool requestException)
        {
            if (requestException)
            {
                throw new Exception("例外を要求されました");  // デリゲート呼び出しの場合はここで中断される
            }

            return "OK2:" + message;
        }


        //====================================================================================================
        // MethodInfo.Invoke を使う方法
        //====================================================================================================

        //--------------------------------------------------------------------------------
        /// <summary>【MethodInfo.Invoke 呼び出し用メソッド1】</summary>
        //--------------------------------------------------------------------------------
        [CallbackMethod()]
        public static string ByMethodInfo1(string message, bool requestException)
        {
            if (requestException)
            {
                throw new Exception("例外を要求されました");  // MethodInfo.Invoke 呼び出しの場合は呼び出し元まで戻って中断されるのでデバッグしにくい
            }

            return "OK1:" + message;
        }


        //--------------------------------------------------------------------------------
        /// <summary>【MethodInfo.Invoke 呼び出し用メソッド2】</summary>
        //--------------------------------------------------------------------------------
        [CallbackMethod()]
        public static string ByMethodInfo2(string message, bool requestException)
        {
            if (requestException)
            {
                throw new Exception("例外を要求されました");  // MethodInfo.Invoke 呼び出しの場合は呼び出し元まで戻って中断されるのでデバッグしにくい
            }

            return "OK2:" + message;
        }


        //====================================================================================================
        // イベント処理を使う方法
        //====================================================================================================

        /// <summary>
        /// 【TestEvent イベント】
        /// </summary>
        public event EventHandler<TestEventArgs> Event;


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【TestEvent イベント発生】TestEvent イベントを発生させます。
        /// </summary>
        /// <param name="eventArgs">[in ]：TestEvent イベント引数</param>
        //--------------------------------------------------------------------------------
        public void RaiseTestEvent(TestEventArgs eventArgs) => Event(this, eventArgs);


        //--------------------------------------------------------------------------------
        /// <summary>【イベント呼び出し用メソッド1】</summary>
        //--------------------------------------------------------------------------------
        [CallbackEvent()]
        public void ByEvent1(object sender, TestEventArgs e)
        {
            if (e.requestException)
            {
                throw new Exception("例外を要求されました");  // イベント呼び出しの場合はここで中断される
            }

            e.resultTable[MethodBase.GetCurrentMethod().Name] = "OK1:" + e.message;
        }


        //--------------------------------------------------------------------------------
        /// <summary>【イベント呼び出し用メソッド2】</summary>
        //--------------------------------------------------------------------------------
        [CallbackEvent()]
        public void ByEvent2(object sender, TestEventArgs e)
        {
            if (e.requestException)
            {
                throw new Exception("例外を要求されました");  // イベント呼び出しの場合はここで中断される
            }

            e.resultTable[MethodBase.GetCurrentMethod().Name] = "OK2:" + e.message;
        }


        //====================================================================================================
        // インターフェイスを使う方法
        //====================================================================================================
        public ByInterface byInterface1 = new ByInterface("byInterface1");

        public ByInterface byInterface2 = new ByInterface("byInterface2");

    } // class


    //====================================================================================================
    /// <summary>
    /// 【TestEvent イベント引数】TestEvent イベント用の引数を管理します。
    /// </summary>
    //====================================================================================================
    public class TestEventArgs : EventArgs
    {
        /// <summary>【メッセージ文字列】</summary>
        public string message;

        /// <summary>【例外要求フラグ】</summary>
        public bool requestException;

        /// <summary>【戻り値テーブル】key = イベントハンドラーのメソッド名, value = 戻り値</summary>
        public Dictionary<string, string> resultTable = new Dictionary<string, string>();

    } // class


    //====================================================================================================
    /// <summary>
    /// 【コールバックテスト用インターフェイス】
    /// </summary>
    //====================================================================================================
    public interface ICallbackTest
    {
        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【インスタンス名取得】
        /// </summary>
        /// <returns>インスタンス名</returns>
        //--------------------------------------------------------------------------------
        string GetInstanceName();

        //--------------------------------------------------------------------------------
        /// <summary>【前処理】</summary>
        //--------------------------------------------------------------------------------
        string Init(string message, bool requestException);

        //--------------------------------------------------------------------------------
        /// <summary>【処理本体】</summary>
        //--------------------------------------------------------------------------------
        string Body(string message, bool requestException);

        //--------------------------------------------------------------------------------
        /// <summary>【後処理】</summary>
        //--------------------------------------------------------------------------------
        string Term(string message, bool requestException);
    } // interface


    //====================================================================================================
    /// <summary>
    /// 【インターフェイス呼び出し用テストクラス】
    /// </summary>
    //====================================================================================================
    public class ByInterface : ICallbackTest
    {
        /// <summary>【インスタンス名】</summary>
        protected string m_instanceName;

        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【完全コンストラクター】
        /// </summary>
        /// <param name="instanceName">[in ]：インスタンス名</param>
        //--------------------------------------------------------------------------------
        public ByInterface(string instanceName)
        {
            m_instanceName = instanceName;
        }


        //====================================================================================================
        // ICallbackTest I/F の実装
        //====================================================================================================

        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【インスタンス名取得】
        /// </summary>
        /// <returns>インスタンス名</returns>
        //--------------------------------------------------------------------------------
        public string GetInstanceName() => m_instanceName;

        //--------------------------------------------------------------------------------
        /// <summary>【前処理】</summary>
        //--------------------------------------------------------------------------------
        public string Init(string message, bool requestException)
        {
            if (requestException)
            {
                throw new Exception("例外を要求されました");  // インターフェイス呼び出しの場合はここで中断される
            }

            return "OK:" + message;
        }

        //--------------------------------------------------------------------------------
        /// <summary>【処理本体】</summary>
        //--------------------------------------------------------------------------------
        public string Body(string message, bool requestException)
        {
            if (requestException)
            {
                throw new Exception("例外を要求されました");  // インターフェイス呼び出しの場合はここで中断される
            }

            return "OK:" + message;
        }

        //--------------------------------------------------------------------------------
        /// <summary>【後処理】</summary>
        //--------------------------------------------------------------------------------
        public string Term(string message, bool requestException)
        {
            if (requestException)
            {
                throw new Exception("例外を要求されました");  // インターフェイス呼び出しの場合はここで中断される
            }

            return "OK:" + message;
        }

    } // class

} // namespace

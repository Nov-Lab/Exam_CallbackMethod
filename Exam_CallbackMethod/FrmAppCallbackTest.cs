// @(h)FrmAppCallbackTest.cs ver 0.00 ( '24.01.18 Nov-Lab ) 作成開始
// @(h)FrmAppCallbackTest.cs ver 0.51 ( '24.01.18 Nov-Lab ) ベータ版完成。

// @(s)
// 　【コールバックテスト用フォーム】各種コールバック方法をテストします。

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;


namespace Exam_CallbackMethod
{
    //====================================================================================================
    /// <summary>
    /// 【コールバックテスト用フォーム】各種コールバック方法をテストします。
    /// </summary>
    //====================================================================================================
    public partial class FrmAppCallbackTest : Form
    {
        //====================================================================================================
        // 内部フィールド
        //====================================================================================================
        /// <summary>
        /// 【トレースリスナー】
        /// </summary>
        protected MyTraceListener m_traceListener;

        /// <summary>
        /// 【コールバックテストインスタンス】
        /// </summary>
        /// <remarks>
        /// 補足<br></br>
        /// ・イベント呼び出し用メソッドはこのインスタンスの <see cref="TestCallback.Event"/> に登録します。<br></br>
        /// </remarks>
        protected TestCallback m_callbackTest = new TestCallback();

        /// <summary>
        /// 【デリゲート呼び出し用メソッドリスト】
        /// </summary>
        protected List<TestCallback.TestFunc> m_testDelegates = new List<TestCallback.TestFunc>();

        /// <summary>
        /// 【MethodInfo.Invoke 呼び出し用メソッドリスト】
        /// </summary>
        protected List<MethodInfo> m_testMethods = new List<MethodInfo>();


        //====================================================================================================
        // フォームイベント
        //====================================================================================================

        // 自動生成された内容のまま
        public FrmAppCallbackTest()
        {
            InitializeComponent();
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【メインフォーム_Load】本フォームを初期化します。
        /// </summary>
        //--------------------------------------------------------------------------------
        private void FrmAppCallbackTest_Load(object sender, EventArgs e)
        {
            //------------------------------------------------------------
            /// トレースリスナーを登録する
            //------------------------------------------------------------
            m_traceListener = new MyTraceListener(this);                //// トレースリスナーを生成する
            Debug.Listeners.Add(m_traceListener);                       //// Debugトレースリスナーに登録する


            //------------------------------------------------------------
            /// デリゲート呼び出し用メソッドを検索・収集する
            //------------------------------------------------------------
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {                                                           //// 読み込み済みアセンブリを繰り返す
                foreach (var typeInfo in assembly.GetTypes())
                {                                                       /////  アセンブリ内の型情報を繰り返す
                    foreach (var methodInfo in typeInfo.GetMethods())
                    {                                                   //////   メソッド情報を繰り返す
                        var attributes =                                ///////    デリゲート呼び出し用メソッド属性の配列を取得する
                            methodInfo.GetCustomAttributes(typeof(CallbackDelegateAttribute), false);
                        if (attributes.Length >= 1)
                        {                                               ///////    １つ以上取得できた場合
                            m_testDelegates.Add(                        ////////     デリゲート呼び出し用メソッドリストにメソッド情報を追加する
                                (TestCallback.TestFunc)
                                    Delegate.CreateDelegate(
                                        typeof(TestCallback.TestFunc),
                                        methodInfo));
                        }
                    }
                }
            }

            //------------------------------------------------------------
            /// MethodInfo.Invoke 呼び出し用メソッドを検索・収集する
            //------------------------------------------------------------
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {                                                           //// 読み込み済みアセンブリを繰り返す
                foreach (var typeInfo in assembly.GetTypes())
                {                                                       /////  アセンブリ内の型情報を繰り返す
                    foreach (var methodInfo in typeInfo.GetMethods())
                    {                                                   //////   メソッド情報を繰り返す
                        var attributes =                                ///////    MethodInfo.Invoke 呼び出し用メソッド属性の配列を取得する
                            methodInfo.GetCustomAttributes(typeof(CallbackMethodAttribute), false);
                        if (attributes.Length >= 1)
                        {                                               ///////    １つ以上取得できた場合
                            m_testMethods.Add(methodInfo);              ////////     コールバックテスト用メソッドリストにメソッド情報を追加する
                        }
                    }
                }
            }

            //------------------------------------------------------------
            /// イベント呼び出し用メソッドを検索・収集する
            //------------------------------------------------------------
            foreach (var methodInfo in m_callbackTest.GetType().GetMethods())
            {                                                           //// コールバックテストインスタンスのメソッド情報を繰り返す
                var attributes =                                        /////  イベント呼び出し用メソッド属性の配列を取得する
                    methodInfo.GetCustomAttributes(typeof(CallbackEventAttribute), false);
                if (attributes.Length >= 1)
                {                                                       /////  １つ以上取得できた場合
                    m_callbackTest.Event +=                             //////   TestEventイベントにイベントハンドラーを追加する
                        (EventHandler<TestEventArgs>)
                            Delegate.CreateDelegate(
                                typeof(EventHandler<TestEventArgs>),
                                m_callbackTest,
                                methodInfo);
                }
            }
        }


        //====================================================================================================
        // 公開メソッド
        //====================================================================================================

        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【トレース追加】トレースメッセージをリストボックスに追加します。
        /// </summary>
        /// <param name="message">[in ]：トレースメッセージ</param>
        //--------------------------------------------------------------------------------
        public void AppendTrace(string message)
        {
            //------------------------------------------------------------
            /// トレースメッセージをリストボックスに追加する
            //------------------------------------------------------------
            bool moveSelection = false;                                 //// 選択インデックス移動フラグ = false に初期化する

            if (LstTrace.SelectedIndex == LstTrace.Items.Count - 1)
            {                                                           //// リストボックスで最後の項目が選択されている場合
                moveSelection = true;                                   /////  選択インデックス移動フラグ = true にセットする
            }

            LstTrace.Items.Add(message);                                //// リストボックスにトレースメッセージを追加する

            if (moveSelection)
            {                                                           //// 選択インデックス移動フラグ = true の場合
                LstTrace.SelectedIndex = LstTrace.Items.Count - 1;      /////  リストボックスの最後の項目を選択状態にする
            }
        }


        //====================================================================================================
        // コントロールイベント
        //====================================================================================================

        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【デリゲートでコールバックボタン_Click】
        /// デリゲートを用いたコールバック呼び出しをテストします。
        /// </summary>
        //--------------------------------------------------------------------------------
        private void BtnCallbackByDelegate_Click(object sender, EventArgs e)
        {
            //------------------------------------------------------------
            /// デリゲートを用いたコールバック呼び出しをテストする
            //------------------------------------------------------------
            foreach (var fncTest in m_testDelegates)
            {                                                           //// デリゲート呼び出し用メソッドリストを繰り返す
                var result = 
                    fncTest("ABCDE", ChkRequestException.Checked);      /////  デリゲートを呼び出す
                Trace.WriteLine(fncTest.Method.Name + ":" + result);    /////  トレース出力(処理結果)
            }
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【MethodInfo.Invoke でコールバックボタン_Click】
        /// MethodInfo.Invoke を用いたコールバック呼び出しをテストします。
        /// </summary>
        //--------------------------------------------------------------------------------
        private void BtnCallbackByMethodInfo_Click(object sender, EventArgs e)
        {
            //------------------------------------------------------------
            /// MethodInfo.Invoke を用いたコールバック呼び出しをテストする
            //------------------------------------------------------------
            foreach (var methodInfo in m_testMethods)
            {                                                               //// MethodInfo.Invoke 呼び出し用メソッドリストを繰り返す
                var result = methodInfo.Invoke(null,                        /////  メソッドを呼び出す
                    new object[] { "ABCDE", ChkRequestException.Checked });
                Trace.WriteLine(methodInfo.Name + ":" + result.ToString()); /////  トレース出力(処理結果)
            }
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【イベントでコールバックボタン_Click】
        /// イベントを用いたコールバック呼び出しをテストします。
        /// </summary>
        //--------------------------------------------------------------------------------
        private void BtnCallbackByEvent_Click(object sender, EventArgs e)
        {
            //------------------------------------------------------------
            /// イベントを用いたコールバック呼び出しをテストする
            //------------------------------------------------------------
            var eventArgs = new TestEventArgs()
            {                                                           //// TestEventイベントの引数を生成する
                message = "ABCDE",
                requestException = ChkRequestException.Checked,
            };

            m_callbackTest.RaiseTestEvent(eventArgs);                   //// TestEventイベントを発生させる

            foreach (var tmpResult in eventArgs.resultTable)
            {                                                           //// 戻り値テーブルを繰り返す
                Trace.WriteLine(tmpResult.Key + ":" + tmpResult.Value); /////  トレース出力(処理結果)
            }
        }

    } // class

} // namespace

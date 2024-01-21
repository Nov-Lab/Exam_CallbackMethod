
namespace Exam_CallbackMethod
{
    partial class FrmAppCallbackTest
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnCallbackByDelegate = new System.Windows.Forms.Button();
            this.BtnCallbackByMethodInfo = new System.Windows.Forms.Button();
            this.BtnCallbackByEvent = new System.Windows.Forms.Button();
            this.ChkRequestException = new System.Windows.Forms.CheckBox();
            this.LstTrace = new System.Windows.Forms.ListBox();
            this.BtnCallbackByInterface = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnCallbackByDelegate
            // 
            this.BtnCallbackByDelegate.Location = new System.Drawing.Point(16, 16);
            this.BtnCallbackByDelegate.Name = "BtnCallbackByDelegate";
            this.BtnCallbackByDelegate.Size = new System.Drawing.Size(192, 24);
            this.BtnCallbackByDelegate.TabIndex = 0;
            this.BtnCallbackByDelegate.Text = "Callback by Delegate";
            this.BtnCallbackByDelegate.UseVisualStyleBackColor = true;
            this.BtnCallbackByDelegate.Click += new System.EventHandler(this.BtnCallbackByDelegate_Click);
            // 
            // BtnCallbackByMethodInfo
            // 
            this.BtnCallbackByMethodInfo.Location = new System.Drawing.Point(16, 56);
            this.BtnCallbackByMethodInfo.Name = "BtnCallbackByMethodInfo";
            this.BtnCallbackByMethodInfo.Size = new System.Drawing.Size(192, 24);
            this.BtnCallbackByMethodInfo.TabIndex = 1;
            this.BtnCallbackByMethodInfo.Text = "Callback by MethodInfo.Invoke";
            this.BtnCallbackByMethodInfo.UseVisualStyleBackColor = true;
            this.BtnCallbackByMethodInfo.Click += new System.EventHandler(this.BtnCallbackByMethodInfo_Click);
            // 
            // BtnCallbackByEvent
            // 
            this.BtnCallbackByEvent.Location = new System.Drawing.Point(16, 96);
            this.BtnCallbackByEvent.Name = "BtnCallbackByEvent";
            this.BtnCallbackByEvent.Size = new System.Drawing.Size(192, 24);
            this.BtnCallbackByEvent.TabIndex = 2;
            this.BtnCallbackByEvent.Text = "Callback by Event";
            this.BtnCallbackByEvent.UseVisualStyleBackColor = true;
            this.BtnCallbackByEvent.Click += new System.EventHandler(this.BtnCallbackByEvent_Click);
            // 
            // ChkRequestException
            // 
            this.ChkRequestException.AutoSize = true;
            this.ChkRequestException.Location = new System.Drawing.Point(16, 176);
            this.ChkRequestException.Name = "ChkRequestException";
            this.ChkRequestException.Size = new System.Drawing.Size(120, 16);
            this.ChkRequestException.TabIndex = 4;
            this.ChkRequestException.Text = "Request Exception";
            this.ChkRequestException.UseVisualStyleBackColor = true;
            // 
            // LstTrace
            // 
            this.LstTrace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LstTrace.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LstTrace.FormattingEnabled = true;
            this.LstTrace.ItemHeight = 12;
            this.LstTrace.Location = new System.Drawing.Point(224, 16);
            this.LstTrace.Name = "LstTrace";
            this.LstTrace.Size = new System.Drawing.Size(408, 172);
            this.LstTrace.TabIndex = 5;
            // 
            // BtnCallbackByInterface
            // 
            this.BtnCallbackByInterface.Location = new System.Drawing.Point(16, 136);
            this.BtnCallbackByInterface.Name = "BtnCallbackByInterface";
            this.BtnCallbackByInterface.Size = new System.Drawing.Size(192, 24);
            this.BtnCallbackByInterface.TabIndex = 3;
            this.BtnCallbackByInterface.Text = "Callback by Interface";
            this.BtnCallbackByInterface.UseVisualStyleBackColor = true;
            this.BtnCallbackByInterface.Click += new System.EventHandler(this.BtnCallbackByInterface_Click);
            // 
            // FrmAppCallbackTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 210);
            this.Controls.Add(this.BtnCallbackByInterface);
            this.Controls.Add(this.LstTrace);
            this.Controls.Add(this.ChkRequestException);
            this.Controls.Add(this.BtnCallbackByEvent);
            this.Controls.Add(this.BtnCallbackByMethodInfo);
            this.Controls.Add(this.BtnCallbackByDelegate);
            this.Name = "FrmAppCallbackTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Callback Test";
            this.Load += new System.EventHandler(this.FrmAppCallbackTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCallbackByDelegate;
        private System.Windows.Forms.Button BtnCallbackByMethodInfo;
        private System.Windows.Forms.Button BtnCallbackByEvent;
        private System.Windows.Forms.CheckBox ChkRequestException;
        private System.Windows.Forms.ListBox LstTrace;
        private System.Windows.Forms.Button BtnCallbackByInterface;
    }
}


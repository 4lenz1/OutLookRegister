namespace WindowsFormsApplication1
{
    partial class OutlookRegister
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.browser = new System.Windows.Forms.WebBrowser();
            this.progresspbar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // browser
            // 
            this.browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browser.Location = new System.Drawing.Point(0, 0);
            this.browser.MinimumSize = new System.Drawing.Size(20, 22);
            this.browser.Name = "browser";
            this.browser.Size = new System.Drawing.Size(493, 672);
            this.browser.TabIndex = 0;
            this.browser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            this.browser.ProgressChanged += new System.Windows.Forms.WebBrowserProgressChangedEventHandler(this.browser_ProgressChanged);
            // 
            // progresspbar
            // 
            this.progresspbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progresspbar.Location = new System.Drawing.Point(0, 647);
            this.progresspbar.Name = "progresspbar";
            this.progresspbar.Size = new System.Drawing.Size(493, 25);
            this.progresspbar.TabIndex = 2;
            // 
            // OutlookRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 672);
            this.Controls.Add(this.progresspbar);
            this.Controls.Add(this.browser);
            this.Name = "OutlookRegister";
            this.Text = "OutlookRegister";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser browser;
        private System.Windows.Forms.ProgressBar progresspbar;
    }
}


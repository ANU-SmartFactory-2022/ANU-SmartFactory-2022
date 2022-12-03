namespace WindowsFormsApp4.ucPanel
{
    partial class ucScreen3
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.button1 = new System.Windows.Forms.Button();
			this.circularProgressBar1 = new CircularProgressBar.CircularProgressBar();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "규격(인치)",
            "패널(IPS)",
            "주사율(IPS)"});
			this.comboBox1.Location = new System.Drawing.Point(15, 65);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(170, 20);
			this.comboBox1.TabIndex = 0;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(15, 118);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(522, 430);
			this.dataGridView1.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(345, 50);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(192, 48);
			this.button1.TabIndex = 2;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// circularProgressBar1
			// 
			this.circularProgressBar1.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
			this.circularProgressBar1.AnimationSpeed = 500;
			this.circularProgressBar1.BackColor = System.Drawing.Color.Transparent;
			this.circularProgressBar1.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.circularProgressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.circularProgressBar1.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.circularProgressBar1.InnerMargin = 2;
			this.circularProgressBar1.InnerWidth = -1;
			this.circularProgressBar1.Location = new System.Drawing.Point(597, 239);
			this.circularProgressBar1.MarqueeAnimationSpeed = 2000;
			this.circularProgressBar1.Name = "circularProgressBar1";
			this.circularProgressBar1.OuterColor = System.Drawing.Color.Gray;
			this.circularProgressBar1.OuterMargin = -25;
			this.circularProgressBar1.OuterWidth = 26;
			this.circularProgressBar1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.circularProgressBar1.ProgressWidth = 25;
			this.circularProgressBar1.SecondaryFont = new System.Drawing.Font("굴림", 36F);
			this.circularProgressBar1.Size = new System.Drawing.Size(314, 309);
			this.circularProgressBar1.StartAngle = 270;
			this.circularProgressBar1.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
			this.circularProgressBar1.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
			this.circularProgressBar1.SubscriptText = "";
			this.circularProgressBar1.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
			this.circularProgressBar1.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
			this.circularProgressBar1.SuperscriptText = "";
			this.circularProgressBar1.TabIndex = 3;
			this.circularProgressBar1.Text = "불량률";
			this.circularProgressBar1.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
			this.circularProgressBar1.Value = 68;
			// 
			// ucScreen3
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
			this.Controls.Add(this.circularProgressBar1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.comboBox1);
			this.Name = "ucScreen3";
			this.Size = new System.Drawing.Size(971, 598);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button button1;
		private CircularProgressBar.CircularProgressBar circularProgressBar1;
	}
}

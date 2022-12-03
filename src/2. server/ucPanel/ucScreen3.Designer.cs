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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 0D);
			System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2D, 0D);
			System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(3D, 0D);
			System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(4D, 0D);
			System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(5D, 0D);
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint6 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 0D);
			System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint7 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2D, 0D);
			System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint8 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(3D, 0D);
			System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint9 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(4D, 0D);
			System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint10 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(5D, 0D);
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.button1 = new System.Windows.Forms.Button();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.oracleDataAdapter1 = new Oracle.ManagedDataAccess.Client.OracleDataAdapter();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
			this.SuspendLayout();
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "전체",
            "24",
            "27",
            "32"});
			this.comboBox1.Location = new System.Drawing.Point(15, 70);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(95, 20);
			this.comboBox1.TabIndex = 0;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// dataGridView1
			// 
			this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(15, 119);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(522, 444);
			this.dataGridView1.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.button1.Location = new System.Drawing.Point(394, 58);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(143, 35);
			this.button1.TabIndex = 2;
			this.button1.Text = "조회";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// comboBox2
			// 
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Items.AddRange(new object[] {
            "전체",
            "TN",
            "VA",
            "IPS"});
			this.comboBox2.Location = new System.Drawing.Point(136, 70);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(95, 20);
			this.comboBox2.TabIndex = 5;
			// 
			// comboBox3
			// 
			this.comboBox3.FormattingEnabled = true;
			this.comboBox3.Items.AddRange(new object[] {
            "전체",
            "60",
            "144",
            "240"});
			this.comboBox3.Location = new System.Drawing.Point(256, 70);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(95, 20);
			this.comboBox3.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
			this.label1.Location = new System.Drawing.Point(33, 35);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 30);
			this.label1.TabIndex = 7;
			this.label1.Text = "Size";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
			this.label2.Location = new System.Drawing.Point(149, 37);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(66, 30);
			this.label2.TabIndex = 8;
			this.label2.Text = "Panel";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
			this.label3.Location = new System.Drawing.Point(284, 35);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(39, 30);
			this.label3.TabIndex = 9;
			this.label3.Text = "Hz";
			// 
			// chart2
			// 
			chartArea1.Name = "ChartArea1";
			this.chart2.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chart2.Legends.Add(legend1);
			this.chart2.Location = new System.Drawing.Point(214, 115);
			this.chart2.Name = "chart2";
			series1.ChartArea = "ChartArea1";
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			this.chart2.Series.Add(series1);
			this.chart2.Size = new System.Drawing.Size(8, 8);
			this.chart2.TabIndex = 11;
			this.chart2.Text = "chart2";
			// 
			// chart1
			// 
			this.chart1.BackColor = System.Drawing.Color.Transparent;
			chartArea2.BackColor = System.Drawing.Color.Transparent;
			chartArea2.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea2);
			legend2.Enabled = false;
			legend2.Name = "Legend1";
			this.chart1.Legends.Add(legend2);
			this.chart1.Location = new System.Drawing.Point(552, 119);
			this.chart1.Name = "chart1";
			series2.ChartArea = "ChartArea1";
			series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
			series2.Legend = "Legend1";
			series2.Name = "Series1";
			series2.Points.Add(dataPoint1);
			series2.Points.Add(dataPoint2);
			series2.Points.Add(dataPoint3);
			series2.Points.Add(dataPoint4);
			series2.Points.Add(dataPoint5);
			this.chart1.Series.Add(series2);
			this.chart1.Size = new System.Drawing.Size(216, 202);
			this.chart1.TabIndex = 12;
			this.chart1.Text = "chart1";
			// 
			// chart3
			// 
			this.chart3.BackColor = System.Drawing.Color.Transparent;
			chartArea3.BackColor = System.Drawing.Color.Transparent;
			chartArea3.Name = "ChartArea1";
			this.chart3.ChartAreas.Add(chartArea3);
			legend3.Enabled = false;
			legend3.Name = "Legend1";
			this.chart3.Legends.Add(legend3);
			this.chart3.Location = new System.Drawing.Point(552, 361);
			this.chart3.Name = "chart3";
			series3.ChartArea = "ChartArea1";
			series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
			series3.Legend = "Legend1";
			series3.Name = "Series1";
			series3.Points.Add(dataPoint6);
			series3.Points.Add(dataPoint7);
			series3.Points.Add(dataPoint8);
			series3.Points.Add(dataPoint9);
			series3.Points.Add(dataPoint10);
			this.chart3.Series.Add(series3);
			this.chart3.Size = new System.Drawing.Size(216, 202);
			this.chart3.TabIndex = 13;
			this.chart3.Text = "chart3";
			// 
			// ucScreen3
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
			this.Controls.Add(this.chart3);
			this.Controls.Add(this.chart1);
			this.Controls.Add(this.chart2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBox3);
			this.Controls.Add(this.comboBox2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.comboBox1);
			this.Name = "ucScreen3";
			this.Size = new System.Drawing.Size(771, 577);
			this.Load += new System.EventHandler(this.ucScreen3_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
		private Oracle.ManagedDataAccess.Client.OracleDataAdapter oracleDataAdapter1;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
	}
}

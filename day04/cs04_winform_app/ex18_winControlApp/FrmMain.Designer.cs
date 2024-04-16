namespace ex18_winControlApp
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            Label1 = new Label();
            CboFonts = new ComboBox();
            ChkBold = new CheckBox();
            ChkItalic = new CheckBox();
            TxtSampleText = new TextBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            PrgDummy = new ProgressBar();
            TrbDummy = new TrackBar();
            groupBox3 = new GroupBox();
            BtnQuestion = new Button();
            BtnMsgBox = new Button();
            BtnModaless = new Button();
            BtnModel = new Button();
            groupBox4 = new GroupBox();
            BtnAddChild = new Button();
            BtnAddRoot = new Button();
            LsvDummy = new ListView();
            TrvDummy = new TreeView();
            groupBox5 = new GroupBox();
            BtnLoad = new Button();
            PicNomal = new PictureBox();
            DlgOpenImage = new OpenFileDialog();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TrbDummy).BeginInit();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PicNomal).BeginInit();
            SuspendLayout();
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Font = new Font("나눔고딕코딩", 9F);
            Label1.Location = new Point(9, 25);
            Label1.Name = "Label1";
            Label1.Size = new Size(41, 12);
            Label1.TabIndex = 0;
            Label1.Text = "폰트 :";
            // 
            // CboFonts
            // 
            CboFonts.Font = new Font("나눔고딕코딩", 9F);
            CboFonts.FormattingEnabled = true;
            CboFonts.Location = new Point(54, 22);
            CboFonts.Name = "CboFonts";
            CboFonts.Size = new Size(196, 20);
            CboFonts.TabIndex = 1;
            CboFonts.SelectedIndexChanged += CboFonts_SelectedIndexChanged;
            // 
            // ChkBold
            // 
            ChkBold.AutoSize = true;
            ChkBold.Font = new Font("나눔고딕코딩", 9F, FontStyle.Bold);
            ChkBold.Location = new Point(256, 24);
            ChkBold.Name = "ChkBold";
            ChkBold.Size = new Size(48, 16);
            ChkBold.TabIndex = 2;
            ChkBold.Text = "굵게";
            ChkBold.UseVisualStyleBackColor = true;
            ChkBold.CheckedChanged += ChkBold_CheckedChanged;
            // 
            // ChkItalic
            // 
            ChkItalic.AutoSize = true;
            ChkItalic.Font = new Font("나눔고딕코딩", 9F, FontStyle.Italic);
            ChkItalic.Location = new Point(312, 24);
            ChkItalic.Name = "ChkItalic";
            ChkItalic.Size = new Size(60, 16);
            ChkItalic.TabIndex = 2;
            ChkItalic.Text = "이탤릭";
            ChkItalic.UseVisualStyleBackColor = true;
            ChkItalic.CheckedChanged += ChkItalic_CheckedChanged;
            // 
            // TxtSampleText
            // 
            TxtSampleText.Font = new Font("나눔고딕코딩", 9F);
            TxtSampleText.Location = new Point(9, 62);
            TxtSampleText.Name = "TxtSampleText";
            TxtSampleText.Size = new Size(363, 19);
            TxtSampleText.TabIndex = 3;
            TxtSampleText.Text = "Hello, C#!";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(TxtSampleText);
            groupBox1.Controls.Add(ChkItalic);
            groupBox1.Controls.Add(ChkBold);
            groupBox1.Controls.Add(CboFonts);
            groupBox1.Controls.Add(Label1);
            groupBox1.Font = new Font("나눔고딕코딩", 9F);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(390, 104);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "콤보박스, 체크박스, 텍스트박스";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(PrgDummy);
            groupBox2.Controls.Add(TrbDummy);
            groupBox2.Location = new Point(12, 122);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(390, 100);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "트랙바, 프로그레스바";
            // 
            // PrgDummy
            // 
            PrgDummy.Location = new Point(9, 71);
            PrgDummy.Maximum = 20;
            PrgDummy.Name = "PrgDummy";
            PrgDummy.Size = new Size(363, 23);
            PrgDummy.TabIndex = 1;
            // 
            // TrbDummy
            // 
            TrbDummy.Location = new Point(9, 22);
            TrbDummy.Maximum = 20;
            TrbDummy.Name = "TrbDummy";
            TrbDummy.Size = new Size(363, 45);
            TrbDummy.TabIndex = 0;
            TrbDummy.Scroll += TrbDummy_Scroll;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(BtnQuestion);
            groupBox3.Controls.Add(BtnMsgBox);
            groupBox3.Controls.Add(BtnModaless);
            groupBox3.Controls.Add(BtnModel);
            groupBox3.Location = new Point(12, 228);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(390, 69);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "모달창, 모달리스창";
            // 
            // BtnQuestion
            // 
            BtnQuestion.Location = new Point(310, 22);
            BtnQuestion.Name = "BtnQuestion";
            BtnQuestion.Size = new Size(62, 30);
            BtnQuestion.TabIndex = 1;
            BtnQuestion.Text = "...";
            BtnQuestion.UseVisualStyleBackColor = true;
            BtnQuestion.Click += BtnQuestion_Click;
            // 
            // BtnMsgBox
            // 
            BtnMsgBox.Location = new Point(214, 22);
            BtnMsgBox.Name = "BtnMsgBox";
            BtnMsgBox.Size = new Size(90, 30);
            BtnMsgBox.TabIndex = 0;
            BtnMsgBox.Text = "MessageBox";
            BtnMsgBox.UseVisualStyleBackColor = true;
            BtnMsgBox.Click += BtnMsgBox_Click;
            // 
            // BtnModaless
            // 
            BtnModaless.Location = new Point(101, 22);
            BtnModaless.Name = "BtnModaless";
            BtnModaless.Size = new Size(107, 30);
            BtnModaless.TabIndex = 0;
            BtnModaless.Text = "Modaless";
            BtnModaless.UseVisualStyleBackColor = true;
            BtnModaless.Click += BtnModaless_Click;
            // 
            // BtnModel
            // 
            BtnModel.Location = new Point(9, 22);
            BtnModel.Name = "BtnModel";
            BtnModel.Size = new Size(86, 30);
            BtnModel.TabIndex = 0;
            BtnModel.Text = "Modal";
            BtnModel.UseVisualStyleBackColor = true;
            BtnModel.Click += BtnModal_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(BtnAddChild);
            groupBox4.Controls.Add(BtnAddRoot);
            groupBox4.Controls.Add(LsvDummy);
            groupBox4.Controls.Add(TrvDummy);
            groupBox4.Location = new Point(12, 303);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(390, 220);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "트리뷰, 리스트뷰";
            // 
            // BtnAddChild
            // 
            BtnAddChild.Location = new Point(105, 178);
            BtnAddChild.Name = "BtnAddChild";
            BtnAddChild.Size = new Size(87, 36);
            BtnAddChild.TabIndex = 2;
            BtnAddChild.Text = "자식추가";
            BtnAddChild.UseVisualStyleBackColor = true;
            BtnAddChild.Click += BtnAddChild_Click;
            // 
            // BtnAddRoot
            // 
            BtnAddRoot.Location = new Point(9, 178);
            BtnAddRoot.Name = "BtnAddRoot";
            BtnAddRoot.Size = new Size(90, 36);
            BtnAddRoot.TabIndex = 2;
            BtnAddRoot.Text = "루트추가";
            BtnAddRoot.UseVisualStyleBackColor = true;
            BtnAddRoot.Click += BtnAddRoot_Click;
            // 
            // LsvDummy
            // 
            LsvDummy.Location = new Point(195, 22);
            LsvDummy.Name = "LsvDummy";
            LsvDummy.Size = new Size(183, 150);
            LsvDummy.TabIndex = 1;
            LsvDummy.UseCompatibleStateImageBehavior = false;
            LsvDummy.View = View.Details;
            // 
            // TrvDummy
            // 
            TrvDummy.Location = new Point(9, 22);
            TrvDummy.Name = "TrvDummy";
            TrvDummy.Size = new Size(183, 150);
            TrvDummy.TabIndex = 0;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(BtnLoad);
            groupBox5.Controls.Add(PicNomal);
            groupBox5.Location = new Point(408, 12);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(409, 505);
            groupBox5.TabIndex = 4;
            groupBox5.TabStop = false;
            groupBox5.Text = "픽처박스";
            // 
            // BtnLoad
            // 
            BtnLoad.Location = new Point(327, 257);
            BtnLoad.Name = "BtnLoad";
            BtnLoad.Size = new Size(75, 23);
            BtnLoad.TabIndex = 1;
            BtnLoad.Text = "로드";
            BtnLoad.UseVisualStyleBackColor = true;
            BtnLoad.Click += BtnLoad_Click;
            // 
            // PicNomal
            // 
            PicNomal.BackColor = SystemColors.GrayText;
            PicNomal.Location = new Point(6, 22);
            PicNomal.Name = "PicNomal";
            PicNomal.Size = new Size(396, 229);
            PicNomal.TabIndex = 0;
            PicNomal.TabStop = false;
            PicNomal.Click += PicNomal_Click;
            // 
            // DlgOpenImage
            // 
            DlgOpenImage.FileName = "z";
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1323, 529);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmMain";
            Text = "컨트롤 예제";
            FormClosing += FrmMain_FormClosing;
            Load += FrmMain_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TrbDummy).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PicNomal).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label Label1;
        private ComboBox CboFonts;
        private CheckBox ChkBold;
        private CheckBox ChkItalic;
        private TextBox TxtSampleText;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ProgressBar PrgDummy;
        private TrackBar TrbDummy;
        private GroupBox groupBox3;
        private Button BtnMsgBox;
        private Button BtnModaless;
        private Button BtnModel;
        private Button BtnQuestion;
        private GroupBox groupBox4;
        private Button BtnAddChild;
        private Button BtnAddRoot;
        private ListView LsvDummy;
        private TreeView TrvDummy;
        private GroupBox groupBox5;
        private Button BtnLoad;
        private PictureBox PicNomal;
        private OpenFileDialog DlgOpenImage;
    }
}

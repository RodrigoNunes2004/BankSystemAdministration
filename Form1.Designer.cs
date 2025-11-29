namespace BankAccountApp
{
    partial class Form1
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
            label1 = new Label();
            label2 = new Label();
            OwnerTxt = new TextBox();
            AmountNum = new NumericUpDown();
            BankAccountsGrid = new DataGridView();
            DepositBtn = new Button();
            WithdrawBtn = new Button();
            CreateAccountBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)AmountNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BankAccountsGrid).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(84, 56);
            label1.Name = "label1";
            label1.Size = new Size(79, 30);
            label1.TabIndex = 0;
            label1.Text = "Owner:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(84, 357);
            label2.Name = "label2";
            label2.Size = new Size(93, 30);
            label2.TabIndex = 1;
            label2.Text = "Amount:";
            // 
            // OwnerTxt
            // 
            OwnerTxt.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            OwnerTxt.Location = new Point(179, 63);
            OwnerTxt.Name = "OwnerTxt";
            OwnerTxt.Size = new Size(284, 35);
            OwnerTxt.TabIndex = 2;
            // 
            // AmountNum
            // 
            AmountNum.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AmountNum.Location = new Point(188, 364);
            AmountNum.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            AmountNum.Minimum = new decimal(new int[] { 999999999, 0, 0, int.MinValue });
            AmountNum.Name = "AmountNum";
            AmountNum.Size = new Size(275, 35);
            AmountNum.TabIndex = 3;
            // 
            // BankAccountsGrid
            // 
            BankAccountsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            BankAccountsGrid.BackgroundColor = SystemColors.Info;
            BankAccountsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            BankAccountsGrid.Location = new Point(513, 63);
            BankAccountsGrid.Name = "BankAccountsGrid";
            BankAccountsGrid.Size = new Size(482, 297);
            BankAccountsGrid.TabIndex = 4;
            // 
            // DepositBtn
            // 
            DepositBtn.BackColor = SystemColors.ControlLight;
            DepositBtn.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DepositBtn.Location = new Point(513, 387);
            DepositBtn.Name = "DepositBtn";
            DepositBtn.Size = new Size(242, 63);
            DepositBtn.TabIndex = 5;
            DepositBtn.Text = "Deposit";
            DepositBtn.UseVisualStyleBackColor = false;
            DepositBtn.Click += DepositBtn_Click;
            // 
            // WithdrawBtn
            // 
            WithdrawBtn.BackColor = SystemColors.WindowFrame;
            WithdrawBtn.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            WithdrawBtn.ForeColor = SystemColors.ButtonHighlight;
            WithdrawBtn.Location = new Point(753, 387);
            WithdrawBtn.Name = "WithdrawBtn";
            WithdrawBtn.Size = new Size(242, 63);
            WithdrawBtn.TabIndex = 6;
            WithdrawBtn.Text = "Withdraw";
            WithdrawBtn.UseVisualStyleBackColor = false;
            WithdrawBtn.Click += WithdrawBtn_Click;
            // 
            // CreateAccountBtn
            // 
            CreateAccountBtn.BackColor = SystemColors.ScrollBar;
            CreateAccountBtn.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CreateAccountBtn.Location = new Point(179, 124);
            CreateAccountBtn.Name = "CreateAccountBtn";
            CreateAccountBtn.Size = new Size(284, 63);
            CreateAccountBtn.TabIndex = 7;
            CreateAccountBtn.Text = "Create Account";
            CreateAccountBtn.UseVisualStyleBackColor = true;
            CreateAccountBtn.Click += CreateAccountBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1059, 497);
            Controls.Add(CreateAccountBtn);
            Controls.Add(WithdrawBtn);
            Controls.Add(DepositBtn);
            Controls.Add(BankAccountsGrid);
            Controls.Add(AmountNum);
            Controls.Add(OwnerTxt);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "Form1";
            Text = "Bank Account System Management";
            ((System.ComponentModel.ISupportInitialize)AmountNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)BankAccountsGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox OwnerTxt;
        private NumericUpDown AmountNum;
        private DataGridView BankAccountsGrid;
        private Button DepositBtn;
        private Button WithdrawBtn;
        private Button CreateAccountBtn;
    }
}

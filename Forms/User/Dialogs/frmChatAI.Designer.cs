namespace doanbanve.Forms
{
    partial class frmChatAI
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTieuDe;
        private RichTextBox rtbHoiThoai;
        private TextBox txtCauHoi;
        private Button btnGui;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            rtbHoiThoai = new RichTextBox();
            txtCauHoi = new TextBox();
            btnGui = new Button();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTieuDe.Location = new Point(16, 16);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(247, 28);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "Chăm sóc khách hàng AI";
            // 
            // rtbHoiThoai
            // 
            rtbHoiThoai.Location = new Point(16, 56);
            rtbHoiThoai.Name = "rtbHoiThoai";
            rtbHoiThoai.ReadOnly = true;
            rtbHoiThoai.Size = new Size(640, 320);
            rtbHoiThoai.TabIndex = 1;
            rtbHoiThoai.Text = "";
            // 
            // txtCauHoi
            // 
            txtCauHoi.Location = new Point(16, 388);
            txtCauHoi.Name = "txtCauHoi";
            txtCauHoi.Size = new Size(520, 27);
            txtCauHoi.TabIndex = 2;
            // 
            // btnGui
            // 
            btnGui.Location = new Point(552, 386);
            btnGui.Name = "btnGui";
            btnGui.Size = new Size(104, 30);
            btnGui.TabIndex = 3;
            btnGui.Text = "Gửi";
            btnGui.UseVisualStyleBackColor = true;
            btnGui.Click += btnGui_Click;
            // 
            // frmChatAI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(680, 440);
            Controls.Add(btnGui);
            Controls.Add(txtCauHoi);
            Controls.Add(rtbHoiThoai);
            Controls.Add(lblTieuDe);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "frmChatAI";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Chăm sóc khách hàng";
            Load += frmChatAI_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

namespace doanbanve.Forms
{
    partial class frmChatAI
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTieuDe;
        private FlowLayoutPanel flpHoiThoai;
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
            flpHoiThoai = new FlowLayoutPanel();
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
            // flpHoiThoai
            // 
            flpHoiThoai.AutoScroll = true;
            flpHoiThoai.BackColor = Color.White;
            flpHoiThoai.BorderStyle = BorderStyle.FixedSingle;
            flpHoiThoai.FlowDirection = FlowDirection.TopDown;
            flpHoiThoai.Location = new Point(16, 56);
            flpHoiThoai.Name = "flpHoiThoai";
            flpHoiThoai.Padding = new Padding(12);
            flpHoiThoai.Size = new Size(680, 360);
            flpHoiThoai.TabIndex = 1;
            flpHoiThoai.WrapContents = false;
            // 
            // txtCauHoi
            // 
            txtCauHoi.Location = new Point(16, 430);
            txtCauHoi.Name = "txtCauHoi";
            txtCauHoi.Size = new Size(560, 27);
            txtCauHoi.TabIndex = 2;
            // 
            // btnGui
            // 
            btnGui.Location = new Point(592, 428);
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
            ClientSize = new Size(720, 482);
            Controls.Add(btnGui);
            Controls.Add(txtCauHoi);
            Controls.Add(flpHoiThoai);
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

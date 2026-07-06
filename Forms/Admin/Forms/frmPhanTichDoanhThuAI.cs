using doanbanve.Utils;

namespace doanbanve.Forms
{
    public partial class frmPhanTichDoanhThuAI : Form
    {
        private readonly RichTextBox rtbNhanXetAI = new();
        private readonly Button btnDong = new();

        public frmPhanTichDoanhThuAI(string noiDungNhanXet)
        {
            InitializeComponent();
            KhoiTaoGiaoDien(noiDungNhanXet);
        }

        private void InitializeComponent()
        {
        }

        private void KhoiTaoGiaoDien(string noiDungNhanXet)
        {
            Text = "Phân tích doanh thu AI";
            StartPosition = FormStartPosition.CenterParent;
            MinimumSize = new Size(720, 520);
            Size = new Size(820, 600);
            GiaoDienHelper.ApDungGiaoDien(this);

            var lblTieuDe = new Label
            {
                Text = "Nhận xét AI về báo cáo doanh thu",
                Dock = DockStyle.Top,
                Height = 48,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(16, 0, 16, 0),
                Font = new Font("Segoe UI", 13F, FontStyle.Bold)
            };

            rtbNhanXetAI.Name = "rtbNhanXetAI";
            rtbNhanXetAI.Dock = DockStyle.Fill;
            rtbNhanXetAI.ReadOnly = true;
            rtbNhanXetAI.BorderStyle = BorderStyle.FixedSingle;
            rtbNhanXetAI.BackColor = Color.White;
            rtbNhanXetAI.Font = new Font("Segoe UI", 10.5F);
            rtbNhanXetAI.Text = noiDungNhanXet;

            var pnlDuoi = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 58,
                Padding = new Padding(16),
                BackColor = Color.White
            };

            btnDong.Name = "btnDong";
            btnDong.Text = "Đóng";
            btnDong.Size = new Size(120, 32);
            btnDong.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDong.Location = new Point(pnlDuoi.Width - btnDong.Width - 16, 13);
            btnDong.Click += (_, _) => Close();
            pnlDuoi.Resize += (_, _) =>
            {
                btnDong.Location = new Point(pnlDuoi.ClientSize.Width - btnDong.Width - 16, 13);
            };
            GiaoDienHelper.ApDungNutPhu(btnDong);

            pnlDuoi.Controls.Add(btnDong);
            Controls.Add(rtbNhanXetAI);
            Controls.Add(pnlDuoi);
            Controls.Add(lblTieuDe);
        }
    }
}

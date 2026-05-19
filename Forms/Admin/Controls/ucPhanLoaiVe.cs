using doanbanve.Controllers;
using doanbanve.Models;

namespace doanbanve.Forms
{
    public partial class ucPhanLoaiVe : UserControl
    {
        private readonly LoaiVeController loaiVeController = new();
        private readonly Color mauNenMacDinh = Color.White;
        private readonly Color mauNenChon = Color.FromArgb(230, 243, 255);
        private Panel? theLoaiVeDangChon;

        public ucPhanLoaiVe()
        {
            InitializeComponent();
            flpDanhSachLoaiVe.SizeChanged += FlpDanhSachLoaiVe_SizeChanged;
        }

        public async Task TaiDuLieu()
        {
            flpDanhSachLoaiVe.SuspendLayout();
            flpDanhSachLoaiVe.Controls.Clear();
            theLoaiVeDangChon = null;
            var danhSach = await loaiVeController.LayDanhSachLoaiVeQuanLy();
            foreach (var loaiVe in danhSach)
            {
                flpDanhSachLoaiVe.Controls.Add(TaoTheLoaiVe(loaiVe));
            }
            flpDanhSachLoaiVe.ResumeLayout();
        }

        private Panel TaoTheLoaiVe(LoaiVe loaiVe)
        {
            var the = new Panel
            {
                Width = flpDanhSachLoaiVe.ClientSize.Width - flpDanhSachLoaiVe.Padding.Horizontal - 24,
                Height = 110,
                BackColor = mauNenMacDinh,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(8),
                Tag = loaiVe
            };

            var lblTen = new Label
            {
                Text = loaiVe.TenLoaiVe,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point),
                Location = new Point(12, 10),
                AutoSize = true
            };

            var lblMoTa = new Label
            {
                Text = string.IsNullOrWhiteSpace(loaiVe.MoTa) ? "Mô tả: Đang cập nhật" : "Mô tả: " + loaiVe.MoTa,
                Location = new Point(12, 40),
                AutoSize = false,
                Size = new Size(Math.Max(200, the.Width - 24), 50)
            };

            the.Controls.Add(lblTen);
            the.Controls.Add(lblMoTa);
            GanSuKienChonThe(the);
            return the;
        }

        private void GanSuKienChonThe(Control control)
        {
            control.Click += TheLoaiVe_Click;
            foreach (Control con in control.Controls)
            {
                con.Click += TheLoaiVe_Click;
            }
        }

        private void TheLoaiVe_Click(object? sender, EventArgs e)
        {
            var the = LayTheTuControl(sender as Control);
            if (the == null)
            {
                return;
            }

            if (theLoaiVeDangChon != null)
            {
                theLoaiVeDangChon.BackColor = mauNenMacDinh;
            }

            the.BackColor = mauNenChon;
            theLoaiVeDangChon = the;
        }

        private static Panel? LayTheTuControl(Control? control)
        {
            while (control != null && control is not Panel)
            {
                control = control.Parent;
            }

            return control as Panel;
        }

        private LoaiVe? LayLoaiVeDangChon()
        {
            return theLoaiVeDangChon?.Tag as LoaiVe;
        }

        private void FlpDanhSachLoaiVe_SizeChanged(object? sender, EventArgs e)
        {
            foreach (Control control in flpDanhSachLoaiVe.Controls)
            {
                if (control is Panel the)
                {
                    the.Width = flpDanhSachLoaiVe.ClientSize.Width - flpDanhSachLoaiVe.Padding.Horizontal - 24;
                    var lblMoTa = the.Controls.OfType<Label>().LastOrDefault();
                    if (lblMoTa != null)
                    {
                        lblMoTa.Size = new Size(Math.Max(200, the.Width - 24), lblMoTa.Height);
                    }
                }
            }
        }

        private async void btnThemLoaiVe_Click(object sender, EventArgs e)
        {
            var formNhap = new frmNhapLoaiVe(null);
            var ketQua = formNhap.ShowDialog();
            if (ketQua != DialogResult.OK || formNhap.LoaiVeHienTai == null)
            {
                return;
            }

            try
            {
                await loaiVeController.ThemLoaiVe(formNhap.LoaiVeHienTai);
                await TaiDuLieu();
                MessageBox.Show("Đã thêm loại vé.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSuaLoaiVe_Click(object sender, EventArgs e)
        {
            var loaiVe = LayLoaiVeDangChon();
            if (loaiVe == null)
            {
                MessageBox.Show("Vui lòng chọn loại vé.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var formNhap = new frmNhapLoaiVe(loaiVe);
            var ketQua = formNhap.ShowDialog();
            if (ketQua != DialogResult.OK || formNhap.LoaiVeHienTai == null)
            {
                return;
            }

            formNhap.LoaiVeHienTai.MaLoaiVe = loaiVe.MaLoaiVe;
            try
            {
                await loaiVeController.SuaLoaiVe(formNhap.LoaiVeHienTai);
                await TaiDuLieu();
                MessageBox.Show("Đã cập nhật loại vé.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXoaLoaiVe_Click(object sender, EventArgs e)
        {
            var loaiVe = LayLoaiVeDangChon();
            if (loaiVe == null)
            {
                MessageBox.Show("Vui lòng chọn loại vé.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var xacNhan = MessageBox.Show("Bạn có chắc muốn xóa loại vé này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (xacNhan != DialogResult.Yes)
            {
                return;
            }

            try
            {
                await loaiVeController.XoaLoaiVe(loaiVe.MaLoaiVe);
                await TaiDuLieu();
                MessageBox.Show("Đã xóa loại vé.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

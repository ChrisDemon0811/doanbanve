using doanbanve.Controllers;
using Microsoft.Reporting.WinForms;

namespace doanbanve.Forms
{
    public partial class frmReportVeBanChayTheoLoai : Form
    {
        private readonly BaoCaoController baoCaoController = new();
        private readonly DateTimePicker dtpTuNgay = new();
        private readonly DateTimePicker dtpDenNgay = new();
        private readonly Button btnXemBaoCao = new();
        private readonly ReportViewer reportViewer = new();

        public frmReportVeBanChayTheoLoai()
        {
            InitializeComponent();
            KhoiTaoGiaoDien();
        }

        private void InitializeComponent()
        {
        }

        private void KhoiTaoGiaoDien()
        {
            Text = "Báo cáo vé bán chạy theo loại";
            StartPosition = FormStartPosition.CenterParent;
            MinimumSize = new Size(900, 650);
            Size = new Size(1000, 720);

            var pnlBoLoc = new Panel
            {
                Dock = DockStyle.Top,
                Height = 58,
                Padding = new Padding(12),
                BackColor = Color.White
            };

            var lblTuNgay = new Label
            {
                Text = "Từ ngày:",
                AutoSize = true,
                Location = new Point(12, 20)
            };

            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            dtpTuNgay.Value = DateTime.Today.AddDays(-30);
            dtpTuNgay.Location = new Point(80, 16);
            dtpTuNgay.Size = new Size(140, 28);

            var lblDenNgay = new Label
            {
                Text = "Đến ngày:",
                AutoSize = true,
                Location = new Point(242, 20)
            };

            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            dtpDenNgay.Value = DateTime.Today;
            dtpDenNgay.Location = new Point(320, 16);
            dtpDenNgay.Size = new Size(140, 28);

            btnXemBaoCao.Name = "btnXemBaoCao";
            btnXemBaoCao.Text = "Xem báo cáo";
            btnXemBaoCao.Location = new Point(482, 14);
            btnXemBaoCao.Size = new Size(130, 32);
            btnXemBaoCao.Click += btnXemBaoCao_Click;

            reportViewer.Name = "reportViewer";
            reportViewer.Dock = DockStyle.Fill;
            reportViewer.ProcessingMode = ProcessingMode.Local;

            pnlBoLoc.Controls.Add(lblTuNgay);
            pnlBoLoc.Controls.Add(dtpTuNgay);
            pnlBoLoc.Controls.Add(lblDenNgay);
            pnlBoLoc.Controls.Add(dtpDenNgay);
            pnlBoLoc.Controls.Add(btnXemBaoCao);

            Controls.Add(reportViewer);
            Controls.Add(pnlBoLoc);
        }

        private async void btnXemBaoCao_Click(object? sender, EventArgs e)
        {
            if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
            {
                MessageBox.Show("Từ ngày không được lớn hơn đến ngày.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var duLieu = await baoCaoController.LayBaoCaoVeBanChayTheoLoai(dtpTuNgay.Value.Date, dtpDenNgay.Value.Date);
                var reportPath = LayDuongDanReport("rBaoCaoVeBanChayTheoLoai.rdlc");
                if (!File.Exists(reportPath))
                {
                    MessageBox.Show("Không tìm thấy file report: " + reportPath, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.ReportPath = reportPath;
                reportViewer.LocalReport.DataSources.Add(new ReportDataSource("ds_BaoCaoVeBanChayTheoLoai", duLieu));
                reportViewer.LocalReport.SetParameters(new[]
                {
                    new ReportParameter("TuNgay", dtpTuNgay.Value.ToString("dd/MM/yyyy")),
                    new ReportParameter("DenNgay", dtpDenNgay.Value.ToString("dd/MM/yyyy"))
                });
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(LayThongBaoLoi(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string LayDuongDanReport(string tenFile)
        {
            var duongDanSource = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Reports", tenFile));
            if (File.Exists(duongDanSource))
            {
                return duongDanSource;
            }

            var duongDanOutput = Path.Combine(AppContext.BaseDirectory, "Reports", tenFile);
            if (File.Exists(duongDanOutput))
            {
                return duongDanOutput;
            }

            return duongDanSource;
        }

        private static string LayThongBaoLoi(Exception ex)
        {
            var loi = ex;
            while (loi.InnerException != null)
            {
                loi = loi.InnerException;
            }

            return loi.Message;
        }
    }
}

# Copilot Instructions - Quản Lý Bán Vé Khu Du Lịch

## Tổng quan
Đồ án WinForms nhỏ dùng C#, .NET WinForms, phiên bản .NET 8.0, Entity Framework Core, SQL Server 2022 . Quản lý bán vé khu du lịch.

## Ngôn ngữ
- Trả lời, giải thích, comment bằng **Tiếng Việt**.
- MessageBox dùng tiếng Việt **có dấu**.

## Đặt tên
**Tên bảng, cột, method, biến, tham số đều BẮT BUỘC dùng Tiếng Việt không dấu. KHÔNG dùng tiếng Anh.**

- Tên bảng/cột: PascalCase. VD: `KhachHang`, `MaKhachHang`, `GiaVe`, `NgayBan`.
- Khóa chính: `Ma` + tên bảng. VD: `MaKhachHang`, `MaHoaDon`.
- Class DAO: theo pattern `[TenBang]DAO`. VD: `KhachHangDAO`, `VeDAO`, `HoaDonDAO`.
- Class khác: PascalCase tiếng Việt không dấu. VD: `Session` (giữ chuẩn .NET).
- Method: PascalCase tiếng Việt không dấu. VD: `LayDanhSachKhachHang()`, `ThemKhachHang()`, `SuaKhachHang()`, `XoaKhachHang()`, `KiemTraDangNhap()`, `TinhTongTien()`, `LayTheoMa()`.
- Biến, tham số: camelCase tiếng Việt không dấu. VD: `maKhachHang`, `tongTien`, `danhSachVe`.
- Form: tiền tố `frm` + tiếng Việt không dấu. VD: `frmDangNhap`, `frmQuanLyKhachHang`, `frmBanVe`.
- Controls bắt buộc tiền tố + tên tiếng Việt không dấu:
  - `btn` Button. VD: `btnLuu`, `btnXoa`, `btnThem`
  - `txt` TextBox. VD: `txtTaiKhoan`, `txtMatKhau`, `txtTenKhachHang`
  - `lbl` Label. VD: `lblTieuDe`, `lblThongBao`
  - `cbo` ComboBox. VD: `cboLoaiVe`, `cboQuyenHan`
  - `dgv` DataGridView. VD: `dgvDanhSachKhachHang`
  - `dtp` DateTimePicker. VD: `dtpNgayBan`
  - `rad` RadioButton. VD: `radNam`, `radNu`
  - `chk` CheckBox. VD: `chkConHang`

## Kiến trúc
Dự án theo DAO Pattern + Controller xử lý logic nghiệp vụ, chia thành các thư mục:

- `Models/` — class thực thể (entity), dùng Property `{ get; set; }`. VD: `KhachHang.cs`, `Ve.cs`, `HoaDon.cs`.
- `DAO/` — class thao tác DB (CRUD). VD: `KhachHangDAO.cs`, `VeDAO.cs`, `HoaDonDAO.cs`.
- `Controllers/` — class xử lý logic nghiệp vụ, đứng giữa Form và DAO. VD: `KhachHangController.cs`.
- `Forms/` — form giao diện WinForms. VD: `frmDangNhap.cs`, `frmQuanLyKhachHang.cs`.
- `Utils/` — class tiện ích dùng chung (static). VD: `DatabaseHelper.cs`, `SecurityUtil.cs`.
- `Exceptions/` — class lỗi tự định nghĩa, kế thừa `Exception`. VD: `UserNotFoundException.cs`.
- `Config/` — class đọc cấu hình hệ thống (kết hợp với `App.config` hoặc `appsettings.json`).
- `Resources/` — file tĩnh (hình ảnh, icon, file text) — có thể dùng song song với `Properties > Resources.resx`.
- `Program.cs` — điểm bắt đầu ứng dụng, chứa `static void Main()`.

### Luồng xử lý chuẩn
```
Form (Click nút) → Controller (kiểm tra logic, validate) → DAO (truy cập DB) → Model (trả dữ liệu về)
```

Phân quyền dùng class tĩnh `Session` lưu người dùng đăng nhập + vai trò (`QuanLy` / `NhanVien`). Form chính ẩn/hiện menu theo `Session.LaQuanLy()`.

## EF Core & LINQ
- **Luôn** bọc DbContext trong `using`.
- **Luôn** dùng Async/Await cho thao tác DB (`ToListAsync`, `FirstOrDefaultAsync`, `SaveChangesAsync`).
- Ưu tiên LINQ Method Syntax (`.Where()`, `.Select()`, `.Include()`).
- Khi cần dữ liệu liên quan, dùng `.Include()` để tránh N+1 query.

## Validate & Xử lý lỗi
- **Luôn** Validate dữ liệu trước khi gọi `SaveChangesAsync()` (kiểm tra rỗng, định dạng).
- **Luôn** bọc thao tác Thêm/Sửa/Xóa/Load DB trong `try-catch`.
- Khi lỗi, hiển thị: `MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);`
- Xác nhận xóa dùng `MessageBoxButtons.YesNo` + `MessageBoxIcon.Question`.

## Quy ước Form
- Form 1 bảng: TextBox + DataGridView + nút Thêm/Sửa/Xóa/Lưu.
- Form 2 bảng: dùng ComboBox load từ bảng phụ, DataSource + DisplayMember + ValueMember.
- Form Master-Detail: phần trên thông tin chính, phần dưới DataGridView chi tiết. Lưu dùng transaction để đảm bảo nhất quán.

## Format dữ liệu
- Số tiền: `tongTien.ToString("N0") + " VNĐ"`
- Ngày: `.ToString("dd/MM/yyyy")` hoặc `"dd/MM/yyyy HH:mm"`

## Báo cáo (Report)
- Hiển thị báo cáo trên màn hình bằng DataGridView hoặc Form riêng.
- Tạo DTO format chuẩn để bind vào lưới hiển thị.

## Không làm
- Không hardcode connection string trong code (dùng `appsettings.json`).
- Không dùng query đồng bộ cho DB (gây treo UI).
- Không gọi `SaveChanges` mà không có `try-catch`.
- Không đặt tên Tiếng Việt có dấu trong code.
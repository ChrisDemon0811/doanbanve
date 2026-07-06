# Huong dan mau rBaoCaoDoanhThu.rdlc

File mau: `Reports/rBaoCaoDoanhThu.rdlc`

## Cau hinh bat buoc

- Dataset name: `ds_BaoCaoDoanhThu`
- ReportDataSource trong WinForms phai dung dung ten: `ds_BaoCaoDoanhThu`
- File form goi report: `Forms/Admin/Reports/frmReportDoanhThu.cs`

## Cac cot trong dataset

- `NgayBaoCao`
- `SoHoaDon`
- `TongSoVe`
- `TongTien`
- `TongTienGiam`
- `TongThanhTien`

## Bo cuc theo giao trinh

- Page Header: co tieu de `BAO CAO DOANH THU`.
- Page Header: co dong thoi gian loc `Tu ngay - Den ngay` thong qua parameters `TuNgay`, `DenNgay`.
- Body: dung Table/Tablix hien thi 6 cot dataset.
- Page Footer: hien thi thoi gian in bao cao va so trang.
- Cac cot tien dung format `N0`.

## Doan code quan trong trong form

```csharp
reportViewer.LocalReport.DataSources.Clear();
reportViewer.LocalReport.DataSources.Add(new ReportDataSource("ds_BaoCaoDoanhThu", duLieu));
reportViewer.LocalReport.ReportPath = reportPath;
reportViewer.LocalReport.SetParameters(new[]
{
    new ReportParameter("TuNgay", dtpTuNgay.Value.ToString("dd/MM/yyyy")),
    new ReportParameter("DenNgay", dtpDenNgay.Value.ToString("dd/MM/yyyy"))
});
reportViewer.RefreshReport();
```

## Luu y

- Khong doi ten dataset neu khong doi lai ReportDataSource trong form.
- Neu them cot moi vao RDLC thi can them property tuong ung vao model `BaoCaoDoanhThu`.

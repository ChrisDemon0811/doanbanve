# Huong dan mau rBaoCaoVeBanChayTheoLoai.rdlc

File mau: `Reports/rBaoCaoVeBanChayTheoLoai.rdlc`

## Cau hinh bat buoc

- Dataset name: `ds_BaoCaoVeBanChayTheoLoai`
- ReportDataSource trong WinForms phai dung dung ten: `ds_BaoCaoVeBanChayTheoLoai`
- File form goi report: `Forms/Admin/Reports/frmReportVeBanChayTheoLoai.cs`

## Cac cot trong dataset

- `MaLoaiVe`
- `TenLoaiVe`
- `SoVeDaBan`
- `TongThanhTien`

## Bo cuc theo giao trinh

- Page Header: co tieu de `BAO CAO VE BAN CHAY THEO LOAI VE`.
- Page Header: co dong thoi gian loc `Tu ngay - Den ngay` thong qua parameters `TuNgay`, `DenNgay`.
- Body: dung Table/Tablix hien thi 4 cot dataset.
- Tablix sort theo `SoVeDaBan` giam dan, sau do `TongThanhTien` giam dan.
- Page Footer: hien thi thoi gian in bao cao va so trang.
- Cot `TongThanhTien` dung format `#,0 VNĐ`.

## Doan code quan trong trong form

```csharp
reportViewer.LocalReport.DataSources.Clear();
reportViewer.LocalReport.DataSources.Add(new ReportDataSource("ds_BaoCaoVeBanChayTheoLoai", duLieu));
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
- Neu them cot moi vao RDLC thi can them property tuong ung vao model `BaoCaoVeBanChayTheoLoai`.
- Khong can bieu do neu bang da hien thi on dinh.

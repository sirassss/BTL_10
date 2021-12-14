/*
Created		11/24/2021
Modified		12/13/2021
Project		
Model			
Company		
Author		
Version		
Database		MS SQL 2000 
*/


Create table [HUONGDANVIEN]
(
	[MAHDV] Char(10) NOT NULL,
	[TENHDV] Nvarchar(100) NULL,
	[PHAI] Bit NULL,
	[DIACHI] Nvarchar(100) NULL,
	[SDT] Numeric(13,0) NULL,
Primary Key ([MAHDV])
) 
go

Create table [KHACH]
(
	[MAKHACH] Char(10) NOT NULL,
	[TENKHACH] Nvarchar(100) NULL,
	[PHAI] Bit NULL,
	[DIACHI] Nvarchar(100) NULL,
	[CMND] Numeric(15,0) NULL,
	[SDT] Numeric(15,0) NULL,
Primary Key ([MAKHACH])
) 
go

Create table [KHACHSAN]
(
	[MAKS] Char(10) NOT NULL,
	[TENKS] Nvarchar(100) NULL,
	[DIACHI] Nvarchar(100) NULL,
Primary Key ([MAKS])
) 
go

Create table [TOUR]
(
	[MATOUR] Char(10) NOT NULL,
	[TENTOUR] Nchar(100) NULL,
	[NGAYBD] Datetime NULL,
	[NGAYKT] Datetime NULL,
	[GIA] Money NULL,
	[MAHDV] Char(10) NOT NULL,
	[CHITIETTOUR] Ntext NULL,
	[ANH] Nvarchar(1000) NULL,
	[MAKS] Char(10) NOT NULL,
	[MAPHUONGTIEN] Char(10) NOT NULL,
Primary Key ([MATOUR])
) 
go

Create table [PHUONGTIEN]
(
	[MAPHUONGTIEN] Char(10) NOT NULL,
	[TENPHUONGTIEN] Nvarchar(100) NULL,
Primary Key ([MAPHUONGTIEN])
) 
go

Create table [DIEMTHAMQUAN]
(
	[MADD] Char(10) NOT NULL,
	[TENDD] Nvarchar(100) NULL,
	[DIACHI] Nvarchar(100) NULL,
	[MOTADIEMDEN] Nvarchar(1000) NULL,
	[ANH] Nvarchar(1000) NULL,
Primary Key ([MADD])
) 
go

Create table [DANGKY]
(
	[MATOUR] Char(10) NOT NULL,
	[MAKHACH] Char(10) NOT NULL,
Primary Key ([MATOUR],[MAKHACH])
) 
go

Create table [ADMIN]
(
	[ID] Char(10) NOT NULL,
	[TENDN] Char(20) NULL,
	[MK] Char(8) NULL,
	[LOAITK] Char(20) NULL,
	[HOTEN] Nvarchar(100) NULL,
	[TRANGTHAI] Char(10) NULL,
Primary Key ([ID])
) 
go

Create table [DANHMUCBLOG]
(
	[MADANHMUCBLOG] Char(10) NOT NULL,
	[TENDANHMUCBLOG] Nvarchar(100) NULL,
Primary Key ([MADANHMUCBLOG])
) 
go

Create table [DEN]
(
	[MATOUR] Char(10) NOT NULL,
	[MADD] Char(10) NOT NULL,
Primary Key ([MATOUR],[MADD])
) 
go

Create table [BLOG]
(
	[MABAIVIET] Char(10) NOT NULL,
	[TIEUDE] Nvarchar(1000) NULL,
	[ANH] Nvarchar(1000) NULL,
	[TOMTAT] Nvarchar(1000) NULL,
	[NOIDUNG] Ntext NULL,
	[NGAYKHOITAO] Datetime NULL,
	[MADANHMUCBLOG] Char(10) NOT NULL,
	[ID] Char(10) NOT NULL,
Primary Key ([MABAIVIET])
) 
go


Alter table [TOUR] add  foreign key([MAHDV]) references [HUONGDANVIEN] ([MAHDV])  on update no action on delete no action 
go
Alter table [DANGKY] add  foreign key([MAKHACH]) references [KHACH] ([MAKHACH])  on update no action on delete no action 
go
Alter table [TOUR] add  foreign key([MAKS]) references [KHACHSAN] ([MAKS])  on update no action on delete no action 
go
Alter table [DANGKY] add  foreign key([MATOUR]) references [TOUR] ([MATOUR])  on update no action on delete no action 
go
Alter table [DEN] add  foreign key([MATOUR]) references [TOUR] ([MATOUR])  on update no action on delete no action 
go
Alter table [TOUR] add  foreign key([MAPHUONGTIEN]) references [PHUONGTIEN] ([MAPHUONGTIEN])  on update no action on delete no action 
go
Alter table [DEN] add  foreign key([MADD]) references [DIEMTHAMQUAN] ([MADD])  on update no action on delete no action 
go
Alter table [BLOG] add  foreign key([ID]) references [ADMIN] ([ID])  on update no action on delete no action 
go
Alter table [BLOG] add  foreign key([MADANHMUCBLOG]) references [DANHMUCBLOG] ([MADANHMUCBLOG])  on update no action on delete no action 
go


Set quoted_identifier on
go


Set quoted_identifier off
go

--Thêm dữ liệu bảng HUONGDANVIEN

INSERT INTO HUONGDANVIEN(MAHDV, TENHDV, PHAI, DIACHI, SDT) VALUES (N'HD1',N'Nguyễn Trung Trí','TRUE',N'Hải Dương','0393343276')
INSERT INTO HUONGDANVIEN(MAHDV, TENHDV, PHAI, DIACHI, SDT) VALUES (N'HD2',N'Thái Anh Lâm','TRUE',N'Hải Dương','058343567')
INSERT INTO HUONGDANVIEN(MAHDV, TENHDV, PHAI, DIACHI, SDT) VALUES (N'HD3',N'Vũ Đình Đoàn','TRUE',N'Hải Dương','0393343456')
go


--Thêm dữ liệu bảng TOUR

Insert Into [TOUR](MATOUR, TENTOUR, NGAYBD, NGAYKT, GIA, MAHDV, CHITIETTOUR, ANH, MAKS, MAPHUONGTIEN)
VALUES (N'T1',N'DU LỊCH DI SẢN - DI TÍCH','2021-12-6','2021-12-10',7000000,'HD1',N'Hà Nội là thành phố cổ với lịch sử gần 1000 năm văn hiến. Hiện nay, Hà Nội có trên 300 di tích được công nhận là di tích lịch sử văn hoá. Bên cạnh đó, còn có nhiều công trình mới được xây dựng như Lăng Chủ Tịch Hồ Chí Minh, Cung Văn hoá hữu nghị Việt Xô… cùng hệ thống các viện bảo tàng, nhà hát',N'003.jpg',N'KS1',N'PT1')
Insert Into [TOUR](MATOUR, TENTOUR, NGAYBD, NGAYKT, GIA, MAHDV, CHITIETTOUR, ANH, MAKS, MAPHUONGTIEN)
VALUES(N'T2',N'DU LỊCH LÀNG NGHỀ ','2021-12-6','2021-12-12',6000000,'HD2',N'Du lịch Hà Nội nổi tiếng với rất nhiều làng nghề truyền thống Hà Nội, mỗi làng nghề có một nét đặc trưng riêng. Nếu du khách đang có dự định tham quan và tìm hiểu về những giá trị văn hóa – nghệ thuật và mua những món quà lưu niệm đậm chất dân tộc thì những làng nghề truyền thống nằm trong bán kính 30km quanh Hà Nội chính là sự lựa chọn tuyệt vời dành cho du khách.',N'001.jpg',N'KS2',N'PT2')
Insert Into [TOUR](MATOUR, TENTOUR, NGAYBD, NGAYKT, GIA, MAHDV, CHITIETTOUR, ANH, MAKS, MAPHUONGTIEN)
VALUES(N'T3',N'DU LỊCH SINH THÁI - NGHỈ DƯỠNG','2021-12-6','2021-12-11',15000000,'HD3',N'Du lịch sinh thái tại Hà Nội là một trong những trải nghiệm được nhiều du khách yêu thích. Tại đây, du khách hoàn toàn có thể thư giãn thoải mái giữa khung cảnh thiên nhiên sau một tuần làm việc và học tập căng thẳng. Hãy cùng Vinpearl khám phá chi tiết 15 địa điểm du lịch gần Hà Nội nổi tiếng nhất hiện nay nhé!',N'004.jpg',N'KS3',N'PT3')
Insert Into [TOUR](MATOUR, TENTOUR, NGAYBD, NGAYKT, GIA, MAHDV, CHITIETTOUR, ANH, MAKS, MAPHUONGTIEN)
VALUES(N'T4',N'DU LỊCH NÔNG NGHIỆP','2021-12-6','2021-12-9',5000000,'HD2',N'Hiện nay, các sản phẩm du lịch nông nghiệp tại Hà Nội chú trọng khai thác yếu tố văn hóa, văn minh lúa nước của vùng đồng bằng Bắc Bộ; du lịch nông nghiệp kết hợp với tham quan di sản văn hóa, làng nghề; khai thác mô hình trang trại đồng quê phục vụ hoạt động du lịch học đường, du lịch nghỉ dưỡng cuối tuần tại khu vực ngoại thành Hà Nội và các vùng phụ cận','002.jpg',N'KS4',N'PT4')
Insert Into [TOUR](MATOUR, TENTOUR, NGAYBD, NGAYKT, GIA, MAHDV, CHITIETTOUR, ANH, MAKS, MAPHUONGTIEN)
VALUES(N'T5',N'DU LỊCH THỂ THAO - VUI CHƠI GIẢI TRÍ','2021-12-6','2021-12-20',3000000,'HD1',N'Lần đầu đến Hà Nội, bạn muốn tìm đến những địa điểm vui chơi cuối tuần mà người Hà thành hay lui tới nhưng lại không có người hướng dẫn. Vậy thì hãy xem qua ngay các địa điểm vui chơi cuối tuần Hà Nội do chúng tôi gợi ý cho bạn nhé.Các địa điểm vui chơi cuối tuần này đa phần đều rất quen thuộc với giới trẻ Hà Nội nhưng với khách du lịch thì không phải ai cũng biết. Còn chần chờ gì nữa mà không đi ngay để khám phá đời sống cuối tuần ở Thủ đô nào!',N'005.jpg',N'KS5',N'PT5')
go

--Thêm dữ liệu bảng KHACHSAN

INSERT INTO KHACHSAN(MAKS, TENKS, DIACHI) VALUES (N'KS1',N'Khách sạn Boutique Hà Nội (Hanoi Boutique Hotel)',N'30/6 Lo Su, Quận Hoàn Kiếm, Hà Nội, Việt Nam')
INSERT INTO KHACHSAN(MAKS, TENKS, DIACHI) VALUES (N'KS2',N'Lotte Hotel Hanoi',N'54 Liễu Giai, Quận Ba Đình, Hà Nội, Việt Nam')
INSERT INTO KHACHSAN(MAKS, TENKS, DIACHI) VALUES (N'KS3',N'Khách Sạn & Spa Acoustic (Acoustic Hotel & Spa)',N'39 Tho Nhuom,Hoan Kiem, Quận Hoàn Kiếm, Hà Nội, Việt Nam')
INSERT INTO KHACHSAN(MAKS, TENKS, DIACHI) VALUES (N'KS4',N'22housing Westlake Hotel & Residence',N'Quận Tây Hồ, Hà Nội, Việt Nam')
INSERT INTO KHACHSAN(MAKS, TENKS, DIACHI) VALUES (N'KS5',N'Khách sạn Sofitel Legend Metropole Hà Nội (Sofitel Legend Metropole Hanoi Hotel)',N'Số 15, Phố Ngô Quyền, Quận Hoàn Kiếm, Quận Hoàn Kiếm, Hà Nội, Việt Nam')
go

--Thêm dữ liệu bảng DIEMTHAMQUAN

INSERT INTO DIEMTHAMQUAN(MADD, TENDD, DIACHI, MOTADIEMDEN, ANH) VALUES (N'DTQ1',N'LỄ HỘI LÀNG TRƯỜNG LÂM',N'Việt Hưng, Long Biên',N'Lễ hội đình Trường Lâm được tổ chức hàng năm vào mỗi độ xuân về, đây cũng là lễ hội lớn nhất trong năm của làng. Tuy nhiên, tùy theo điều kiện kinh tế của làng trong từng năm mà lễ hội được tổ chức to hay nhỏ. Nếu năm nào được mùa làng sẽ vào đám to',N'd1.jpg')
INSERT INTO DIEMTHAMQUAN(MADD, TENDD, DIACHI, MOTADIEMDEN, ANH) VALUES (N'DTQ2',N'NHÀ THỜ HÀM LONG',N'Phan Chu Trinh, Hoàn Kiếm Phường Phan Chu Trinh , Quận Hoàn Kiếm',N'Nhà thờ Hàm Long là một nhà thờ của Giáo hội Công giáo Rôma, thuộc Tổng giáo phận Hà Nội, Việt Nam. Đây là một trong những nhà thờ lớn, có kiến trúc đẹp ở Hà Nội tọa lạc ở số 21 phố Hàm Long, quận Hoàn Kiếm.Giáo xứ Hàm Long là họ lẻ của xứ Nhà thờ Lớn (xứ Chính tòa). Có một văn bản niên giám năm 1939 đã ghi rõ về giáo xứ Thánh Anton – Hàm Long có 2 họ với 4710 giáo hữu cùng với 3 linh mục thừa sai M.E.P. Còn theo bản ghi nhớ do cha cố Giuse Nguyễn Văn Quế lập nhân kỷ niệm 50 năn thành lập giáo xứ, giáo xứ được thiết lập ngày 24/12/1934.',N'd2.jpg')
INSERT INTO DIEMTHAMQUAN(MADD, TENDD, DIACHI, MOTADIEMDEN, ANH) VALUES (N'DTQ3',N'BẢO TÀNG PHỤ NỮ VIỆT NAM',N'Hàng Bài, Hoàn Kiếm Phường Hàng Bài , Quận Hoàn Kiếm ',N'Bảo tàng Phụ nữ Việt Nam được thành lập năm 1987, trực thuộc Hội Liên hiệp Phụ nữ Việt Nam. Là một bảo tàng Giới với chức năng nghiên cứu, lưu giữ bảo quản, trưng bày những di sản vật thể, phi vật thể về lịch sử, văn hóa của phụ nữ Việt Nam, Hội LHPN Việt Nam; đồng thời là trung tâm giao lưu văn hóa của phụ nữ Việt Nam và phụ nữ quốc tế vì mục tiêu Bình đẳng, Phát triển và Hoà Bình.',N'd3.jpg')
INSERT INTO DIEMTHAMQUAN(MADD, TENDD, DIACHI, MOTADIEMDEN, ANH) VALUES (N'DTQ4',N'CHÙA THIỀN QUANG',N'Nguyễn Du, Hai Bà Trưng',N'Nằm bên cạnh ngôi chùa Quang Hoa là ngôi chùa Thiền Quang với quy mô khiêm tốn hơn, ngăn cách nhau bằng một mảng tường lửng. Chùa quay về hướng Tây, khuôn viên cũng như quy mô kiến trúc của chùa nhỏ và đơn giản. Phía sau chùa vẫn còn hai tháp mộ của các nhà sư trụ trì đã viên tịch.',N'd4.jpg')
INSERT INTO DIEMTHAMQUAN(MADD, TENDD, DIACHI, MOTADIEMDEN, ANH) VALUES (N'DTQ5',N'LỄ HỘI ĐÁNH CỜ CHÙA VUA',N'Phố Huế, Hai Bà Trưng Phường Phố Huế , Quận Hai Bà Trưng',N'Lễ hội chùa Vua được tổ chức hàng năm vào các ngày 6, 7, 8 và 9 tháng Giêng. Lễ hội khá hấp dẫn, ngoài phần nghi lễ như ở các đền, chùa khác, thì nội dung chính của ngày lễ là mở hội cờ.Đi qua cổng Tam quan với gác chuông là tới sân đánh cờ. Đây là nơi diễn ra những huyền vi, ảo diệu của các thế cờ trong cuộc thi mỗi năm. Bàn cờ được kẻ bằng vôi trên một sân lát bằng đá xanh. Trong những ngày thường, các vị trí đặt quân trên bàn cờ được đặt các chậu cảnh. Trên thân chậu cũng ghi tên quân với tướng, sĩ, tượng, xe, pháo, mã… ',N'd5.jpg')
INSERT INTO DIEMTHAMQUAN(MADD, TENDD, DIACHI, MOTADIEMDEN, ANH) VALUES (N'DTQ6',N'NGHỀ ĐẬU BẠC ĐỊNH CÔNG',N'Thanh Trì, Hoàng Mai Phường Thanh Trì , Quận Hoàng Mai',N'Theo truyền thuyết, vào thời Lý Nam Đế (thế kỷ thứ VI) ở làng Định Công có ba anh em họ Trần: Trần Hòa, Trần Điện, Trần Điền, nhờ có bàn tay khéo léo, lại thêm đức tính cần cù, chịu khó nên họ đã học được nghề làm vàng bạc và mở cửa hàng lấy tên là “kim hoàn” (tức là: vòng vàng). Những đồ vàng bạc do ba anh em làm ra rất tinh xảo, tiếng đồn khắp trong nước. Ba người lại dạy cho dân làng cùng làm nghề, từ đó làng Định Công có nghề làm vàng bạc, truyền từ đời này qua đời khác, được khắp nơi biết tiếng. Trải qua năm tháng, nghề đậu bạc càng phát triển và trở thành một trong 4 nghề tinh hoa nhất kinh thành Thăng Long.',N'd6.jpg')
INSERT INTO DIEMTHAMQUAN(MADD, TENDD, DIACHI, MOTADIEMDEN, ANH) VALUES (N'DTQ7',N'ĐÌNH VÀ NGHÈ MAI ĐỘNG',N'Mai Động, Hoàng Mai Phường Mai Động , Quận Hoàng Mai',N'Chùa làng Mai Động có tên là “Thiện Khánh tự”, từ xa xưa vẫn nằm ở xóm chùa, đây từng là một trong 5 xóm của làng cổ My Động (có xóm Đống Cơm, xóm Chợ, xóm Chùa, xóm Cửa Lĩnh và Mơ Táo).',N'd7.jpg')
INSERT INTO DIEMTHAMQUAN(MADD, TENDD, DIACHI, MOTADIEMDEN, ANH) VALUES (N'DTQ8',N'Điểm du lịch Làng nghề sinh vật cảnh Hồng Vân',N'Xã Hồng Vân, huyện Thường Tín, Hà Nội Xã Hồng Vân , Huyện Thường Tín ',N'Làng sinh vật cảnh Hồng Vân nằm ở phía Đông huyện Thường Tín, cách trung tâm Hà Nội khoảng 20km về phía Nam. Nằm trong vùng ngoại thành và vành đai xanh của Thủ đô Hà Nội, Hồng Vân hội tụ đầy đủ những nét đẹp thuần khiết, yên bình của một làng quê ven đô với đặc trưng của nền nông nghiệp đồng bằng châu thổ sông Hồng.',N'd8.jpg')
INSERT INTO DIEMTHAMQUAN(MADD, TENDD, DIACHI, MOTADIEMDEN, ANH) VALUES (N'DTQ9',N'Làng múa rối nước Đào Thục',N'Đào Thục, Thụy Lâm, Đông Anh Xã Thụy Lâm , Huyện Đông Anh',N'Trang Đào Xá xưa (làng Đào Thục nay) là quê hương của nghề múa rối nước, được cụ tổ Nguyễn Đăng Vinh truyền nghề dạy múa rối nước vào thời vua Lê Dụ Tông (1706 – 1729), nghệ thuật múa rối nước Đào Thục đã có hơn300 năm tồn tại và phát triển, là sự kết tinh từ quá trình sáng tạo, lao động của người nông dân gắn liền với nghề trồng lúa nước ở đồng bằng Bắc Bộ. Cho đến nay, Phường rối nước Đào Thục vẫn còn lưu giữ nhiều tích trò cổ mang ý nghĩa nhân văn sâu sắc, gửi gắm khát vọng về cuộc sống bình yên, hạnh phúc, ca ngợi sự cần cù, chịu khó của người nông dân, phản ánh bối cảnh lịch sử, đời sống văn hoá đương thời như: “Trâu đi cày”, “Trâu chui ống”, “Lên võng xuống ngựa”, “Tễu bắt ác”, “Đánh cáo bắt vịt”, “Đốt pháo bật cờ”, “Ba khí giáo trò” vv…',N'd9.jpg')
INSERT INTO DIEMTHAMQUAN(MADD, TENDD, DIACHI, MOTADIEMDEN, ANH) VALUES (N'DTQ10',N'Làng nghề sơn mài Hạ Thái',N'Hạ Thái, Duyên Thái, Thường Tín Xã Duyên Thái , Huyện Thường Tín',N'Làng nghề thủ công truyền thống sơn mài Hạ Thái nằm ngay trục quốc lộ 1A cũ, đến gần cầu Quán Gánh, rẽ trái vào đường liên xã Duyên Thái, qua cầu chui dân sinh là đến. Ngày xưa, làng có tên là Cự Tràng trang, năm 1870 đổi tên là làng Đông Thái và đến đầu thế kỷ XX thì chính thức mang tên là làng Hạ Thái.',N'd10.jpg')
INSERT INTO DIEMTHAMQUAN(MADD, TENDD, DIACHI, MOTADIEMDEN, ANH) VALUES (N'DTQ11',N'Hà Nội Paragon Hill Resort',N'Thôn Muồng Cháu, Xã Vân Hòa, Huyện Ba Vì Xã Vân Hòa , Huyện Ba Vì ',N'Cách Trung tâm Hà Nội hơn 50 km, mất khoảng 1 giờ 30 phút du khách đã đặt chân đến khu du lịch. Ba Vì nổi tiếng là vùng đất có những nét đẹp hoang sơ, mang đậm dấu ấn ngàn năm lịch sử. Dãy núi Ba Vì hay còn gọi là núi Tản Viên - ngọn núi thiêng thờ Đức Thánh Tản Viên. Khuôn viên và cảnh quan khu du lịch với diện tích rộng gần 200 heta... Khu du lịch nghỉ dưỡng có 72 phòng, trong đó có 8 phòng bungalow, 66 phòng nghỉ tiêu chuẩn, 15 nhà sàn cộng đồng. Với kiến trúc nhà sàn đặc trưng được trang bị thiết bị tiện nghi sang trọng, hiện đại, có Wifi miễn phí toàn khu.',N'd11.jpg')
INSERT INTO DIEMTHAMQUAN(MADD, TENDD, DIACHI, MOTADIEMDEN, ANH) VALUES (N'DTQ12',N'Khu du lịch sinh thái Thiên Sơn Suối Ngà',N'Khu du lịch sinh thái Thiên Sơn Suối Ngà, Xã Vân Hòa , Huyện Ba Vì ',N'Bạn đang quen với cuộc sống thành phố đô thị đông đúc hay môi trường làm việc, sinh sống không trong lành, hãy dành thời gian nghỉ ngơi, tận hưởng bầu không khí thiên nhiên, núi rừng đầy sức sống Thiên Sơn – Suối Ngà.Nằm dưới chân núi Ba Vì, khu du lịch Thiên - Suối Ngà , với cảnh thiên nhiên hùng vĩ, tươi đẹp và thơ mộng của núi rừng, suối, hồ và thác nước đã tạo nên một quần thể du lịch hấp dẫn du khách, đặc biệt trong những ngày hè.',N'd12.jpg')
INSERT INTO DIEMTHAMQUAN(MADD, TENDD, DIACHI, MOTADIEMDEN, ANH) VALUES (N'DTQ13',N'Vườn Quốc gia Ba Vì',N'Tản Lĩnh, Ba Vì Xã Tản Lĩnh , Huyện Ba Vì ',N'Nằm cách trung tâm thủ đô khoảng hơn 60km về phía Tây, với khí hậu núi cao trong lành và mát mẻ, từ lâu Vườn Quốc Gia Ba Vì trở thành điểm đến lý tưởng cho du khách trong và ngoài nước. Đến Vườn Quốc Gia Ba Vì, du khách sẽ được đắm mình giữa khung cảnh thiên nhiên hùng vĩ của núi rừng, được trở về với truyền thuyết Sơn Tinh- Thủy Tinh linh thiêng mà đậm chất thơ.',N'd13.jpg')
INSERT INTO DIEMTHAMQUAN(MADD, TENDD, DIACHI, MOTADIEMDEN, ANH) VALUES (N'DTQ14',N'Khu nghỉ dưỡng Asean',N'Quốc lộ 21A Hòa Lạc, Hòa Lạc, Thạch Thất Xã Tản Lĩnh , Huyện Thạch Thất ',N'Đến ASEAN Resort & Spa, du khách chắc hẳn sẽ rất ngạc nhiên bởi ngay gần trung tâm Hà Nội lại có một thiên đường đẹp như trong mơ, phù hợp cho cả bốn mùa, nơi đáp ứng tốt nhất nhu cầu về nghỉ dưỡng, ẩm thực, hội nghị hội thảo và vui chơi giải trí… Chắc chắn sẽ tiết kiệm được cho bạn nhiều thời gian, tiền bạc trong khi vẫn có thể sử dụng những dịch vụ đạt tiêu chuẩn quốc tế.',N'd14.jpg')
INSERT INTO DIEMTHAMQUAN(MADD, TENDD, DIACHI, MOTADIEMDEN, ANH) VALUES (N'DTQ15',N'Khu nghỉ dưỡng Family resort',N'Xóm Mái, Yên Bài, Ba Vì Xã Yên Bài , Huyện Ba Vì ',N'Bạn thích được gần gũi thiên nhiên, chạy trốn mệt mỏi tất bật, không gian tươi mát của style Family Resort sẽ là điểm lí tưởng để bạn tìm đến với bình yên và thanh thản. Hãy thư giãn và hít thở bầu không khí trong lành và thả lỏng cơ thể bạn nhé, mọi chuyện còn lại chúng tôi sẽ giúp bạn.',N'd15.jpg')
INSERT INTO DIEMTHAMQUAN(MADD, TENDD, DIACHI, MOTADIEMDEN, ANH) VALUES (N'DTQ16',N'Điểm tham quan du lịch Detrang Farm',N'Thôn Ké Mới, Tản Lĩnh, Ba Vì Xã Tản Lĩnh , Huyện Ba Vì ',N'Cách Hà Nội 50km Detrang Farm là nông trại giáo dục theo mô hình Working Farm đầu tiên tại Việt Nam.Nông trại có diện tích hơn 12ha tọa lạc ngay dưới chân dãy núi Ba Vì giữa mầu xanh ngút ngàn của khu rừng nguyên sinh và những nương đồng xanh mướt. Giữa màu xanh trùng điệp đó là nền văn hóa xứ Đoài xưa mang đậm dấu ấn văn hóa đồng quê Việt Nam. Địa hình khí hậu tự nhiên ưu đãi đã tạo nên một vùng chăn nuôi, nông nghiệp, lâm nghiệp phát triển mạnh mẽ.',N'd16.jpg')
INSERT INTO DIEMTHAMQUAN(MADD, TENDD, DIACHI, MOTADIEMDEN, ANH) VALUES (N'DTQ17',N'Trang trại Đồng quê Ba Vì',N'Thôn Nghe, Vân Hòa, Ba Vì Xã Vân Hòa , Huyện Ba Vì ',N'Trang trại Đồng Quê Ba Vì chỉ cách trung tâm thành phố Hà Nội 49 km, toạ lạc trên một khu đồi nhỏ xinh xắn, tựa lưng vào dãy núi Ba Vì. Trang trại nằm trong vùng ngoại thành phía tây thuộc thủ đô Hà Nội có địa hình thiên nhiên nông nghiệp rất đẹp và đa dạng (rừng, hồ, ao, suối, sông ngòi) tiêu biểu cho một nền văn minh lúa nước vào hàng cổ đại của thế giới thuộc châu thổ sông Hồng.Từ trang trại nhìn xuống, quý khách có thể chiêm ngưỡng những cánh đồng lúa có hình dạng bậc thang thấp, phía sau là màu xanh ngút ngàn của khu rừng nguyên sinh thuộc dãy núi Ba Vì với ba đỉnh cao 1100, 1200 và 1300 mét',N'd17.jpg')
INSERT INTO DIEMTHAMQUAN(MADD, TENDD, DIACHI, MOTADIEMDEN, ANH) VALUES (N'DTQ18',N'Trang trại giáo dục Erahouse',N'KM1 Đường Đê Vàng, Giang Biên, Long Biên Phường Giang Biên , Quận Long Biên',N'gười sáng lập: Đặng Lưu Hoa - Thạc sĩ Khoa học Nông nghiệp, Đại học Tổng Hợp Sydney niên khóa 2005-2007Erahouse được xây dựng từ tâm huyết của một giảng viên trường Đại học Nông nghiệp yêu nghề muốn tạo ra các giá trị lớn hơn cho các hoạt động nông nghiệp và tình yêu của một bà mẹ với con trẻ muốn mang đến cho con và các bạn nhỏ một môi trường phát triển gần gũi với thiên nhiên, cân bằng và thú vị, cho các con có thể thoải mái vừa vui chơi vừa học tập, phát triển toàn diện và khám phá bản thân.',N'd18.jpg')
INSERT INTO DIEMTHAMQUAN(MADD, TENDD, DIACHI, MOTADIEMDEN, ANH) VALUES (N'DTQ19',N'Điểm du lịch sinh thái Bản Rõm',N'Khu Suối Tiên, Quang Tiến, Sóc Sơn Xã Quang Tiến , Huyện Sóc Sơn',N'Từ trung tâm thành phố, hướng về phía bắc 30km, quý khách đi trên trục đường cầu Nhật Tân đến cảng hàng không quốc tế Nội Bài là đến với Bản Rõm. Bản Rõm nằm trong quần thể du lịch sinh thái đền Sóc nơi đây đã được ủy ban nhân dân thành phố Hà Nội quy hoạch là khu nghỉ dưỡng sinh thái của thành phố. Bản Rõm có diện tích lên tới 6ha, bao quanh là khu rừng Thông rộng lớn, chúng tôi tự hào là 1 trong những khu du lịch đào tạo kỹ năng sống đầu tiên và lớn nhất Sóc Sơn. Đến với bản Rõm quý khách được trải nghiệm vô cùng thú vị với các dịch vụ phong phú như :Tìm hiểu cuộc sống của người nông dân.Tham quan khu rừng cổ tích.Tham gia khóa học kỹ năng sống (cắm trại - cách sống sót trong rừng - tập làm chú bộ đội ...).Tham gia các hoạt động ngoài trời.Tổ chức picnic cùng bạn bè và Công ty.Teambuilding bổ ích.Gala, tiệc nướng BBQ.',N'd19.jpg')
INSERT INTO DIEMTHAMQUAN(MADD, TENDD, DIACHI, MOTADIEMDEN, ANH) VALUES (N'DTQ20',N'Nhà hát Lớn',N' Số 01 Tràng Tiền, Tràng Tiền, Hoàn Kiếm Phường Tràng Tiền , Quận Hoàn Kiếm ',N'Khu đất xây dựng Nhà Hát Lớn trước kia là một vùng đầm lầy thuộc đất của hai làng Thạch Tần và Tây Luông thuộc Tổng Phúc Lân Huyện Thọ Xương. Vào năm 1899 hội đồng thành phố nhóm họp dưới quyền chủ tọa của Richard – là Công sứ Hà Nội đề nghị lên tòan quyền Fourer cho xây Nhà Hát. Tác giả đồ án thiết kế là hai kiến trúc sư Harlay và Broyer. Bản thiết kế này phải sửa đổi nhiều bởi sự góp ý của nhiều kiến trúc sư.',N'd20.jpg')
INSERT INTO DIEMTHAMQUAN(MADD, TENDD, DIACHI, MOTADIEMDEN, ANH) VALUES (N'DTQ21',N'Nhà hát Star Galaxy (Ionah show)',N'Số 87 Láng Hạ, Thành Công, Ba Đình Phường Thành Công , Quận Ba Đình',N'CHƯƠNG TRÌNH NGHỆ THUẬT GIẢI TRÍ ĐẲNG CẤPVới sự kết hợp chưa từng có của các loại hình nghệ thuật như xiếc, uốn dẻo, múa, diễn xuất, hip-hop,... cùng âm thanh, hiệu ứng sân khấu 3D hiện đại, sống động, Ionah sẽ đưa bạn lạc vào thế giới hoàn toàn khác so với những gì bạn có thể tưởng tượng.',N'd21.jpg')
INSERT INTO DIEMTHAMQUAN(MADD, TENDD, DIACHI, MOTADIEMDEN, ANH) VALUES (N'DTQ22',N'Nhà hát chèo Việt Nam',N'Số 71 Kim Mã, Ba Đình Phường Khương Trung , Quận Ba Đình ',N'Nhà hát Chèo Việt Nam là trung tâm biểu diễn, nghiên cứu và đào tạo nghệ thuật Chèo (thuộc Bộ Văn hóa – Thể thao & Du lịch), tiền thân là Tổ Chèo trong Đoàn Văn công Nhân dân Trung ương, thành lập năm 1951 tại Việt Bắc.Từ ngày đầu thành lập, Nhà hát đã tập hợp các nghệ nhân ưu tú trong một chương trình khai thác và học tập vốn cổ trong nghệ thuật Chèo. Trên cơ sở đó, Nhà hát đã phục hồi, chỉnh lí, cải biên thành công những vở Chèo truyền thống tiêu biểu như: “Quan Âm Thị Kính”, “Lưu Bình – Dương Lễ”, “Xuý Vân”, “Từ Thức”, “Trương Viên”…',N'd22.jpg')
INSERT INTO DIEMTHAMQUAN(MADD, TENDD, DIACHI, MOTADIEMDEN, ANH) VALUES (N'DTQ23',N'Nhà hát chèo Hà Nội',N'Số 15 Nguyễn Đình Chiểu, Nguyễn Du, Hai Bà Trưng Phường Nguyễn Du , Quận Hai Bà Trưng ',N'Nhà hát Chèo Hà Nội là đơn vị hoạt động nghệ thuật, được nâng cấp từ Đoàn Chèo Hà Nội theo quyết định Số: 62/2002/QĐ-UB Ngày 25 tháng 04 năm 2002 của thành phố Hà Nội. Nhà hát Chèo Hà Nội có trụ sở đặt tại: số 15 phố Nguyễn Đình Chiểu, quận Hai Bà Trưng, thành phố Hà Nội.',N'd23.jpg')
INSERT INTO DIEMTHAMQUAN(MADD, TENDD, DIACHI, MOTADIEMDEN, ANH) VALUES (N'DTQ24',N'Nhà hát tuồng Việt Nam - Rạp Hồng Hà',N'Số 51A Đường Thành, Cửa Đông, Hoàn Kiếm Phường Cửa Đông , Quận Hoàn Kiếm',N'Nhà hát Tuồng Việt Nam, tiền thân là Đoàn Tuồng Bắc vốn đã có từ lâu đời và biểu diễn phổ biến khá rộng rãi chẳng những ở các vùng nông thôn  mà ở các đô thị lớn ở phái bắc như:  Hà Nội, Bắc Ninh, Hải Phòng, Nam Định,Vinh ...Và những rạp Tuồng có tên tuổi như: Quảng Lạc, Sán Nhiên Đài quanh năm diễn Tuồng.',N'd24.jpg')
INSERT INTO DIEMTHAMQUAN(MADD, TENDD, DIACHI, MOTADIEMDEN, ANH) VALUES (N'DTQ25',N'Ca Trù Thăng Long - Đền Quan Đế',N'Số 28 Hàng Buồm, Hoàn Kiếm Phường Hàng Trống , Quận Hoàn Kiếm',N'Ca trù là một bộ môn nghệ thuật truyền thống lâu đời, hết sức độc đáo và có ý nghĩa đặc biệt trong kho tàng âm nhạc Việt Nam, gắn liền với lễ hội, phong tục, tín ngưỡng, văn chương, âm nhạc, mang tư tưởng và triết lý sống của người Việt sâu sắc.',N'd25.jpg')
go

--Thêm dữ liệu bảng PHUONGTIEN

INSERT INTO PHUONGTIEN(MAPHUONGTIEN, TENPHUONGTIEN) VALUES (N'PT1',N'Máy bay')
INSERT INTO PHUONGTIEN(MAPHUONGTIEN, TENPHUONGTIEN) VALUES (N'PT2',N'Ôtô')
INSERT INTO PHUONGTIEN(MAPHUONGTIEN, TENPHUONGTIEN) VALUES (N'PT3',N'Ôtô')
INSERT INTO PHUONGTIEN(MAPHUONGTIEN, TENPHUONGTIEN) VALUES (N'PT4',N'Thuyền')
INSERT INTO PHUONGTIEN(MAPHUONGTIEN, TENPHUONGTIEN) VALUES (N'PT5',N'Ôtô')

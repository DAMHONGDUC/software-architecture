-- USE MASTER

USE QLBH
GO

--NOTE
--0 = admin
--1 = staff
INSERT INTO M_USER
VALUES
	('admin','12345',N'Đàm Hồng Đức','06/11/2001', 0),
	('staff1','12345',N'Nguyễn Văn A','02/11/2002', 1),
	('staff2','12345',N'Nguyễn Văn B','03/11/2003', 1),
	('staff3','12345',N'Nguyễn Văn C','04/11/2004', 1)
GO

INSERT INTO M_CUSTOMER
VALUES
	(N'Đinh Văn A', '0355211736'),
	(N'Đinh Văn B', '0355211737'),
	(N'Đinh Văn C', '0355211738')
	
GO

INSERT INTO M_PRODUCT
VALUES
	(N'Hoa hồng', N'hoa hồng', 'https://www.pinterest.com/pin/756956649877065867/',10,60000),
	(N'Hoa hướng dương', N'hoa hướng dương', 'https://www.pinterest.com/pin/68742994984/',10,70000),
	(N'Hoa tuylip', N'hoa tulip', 'https://www.pinterest.com/pin/443393525823105628/', 10,80000),
	(N'Hoa ly', N'hoa ly', 'https://www.pinterest.com/pin/422281206039061/', 10, 50000),
	(N'Hoa cẩm tú cầu', N'hoa cẩm tú cầu', 'https://www.pinterest.com/pin/351912445419073/', 10, 90000)
GO

--NOTE
--0 = ORDER_STATUS unpaid
--1 = ORDER_STATUS paid
--0 = PAYMENT_TYPE cash
--1 = PAYMENT_TYPE banking
INSERT INTO M_ORDER
VALUES
	(1, 1, N'21/2 Trần Phú, Phường 3, Quận 3, TP.HCM', '10/01/2023', 'Nguyễn Thị A', '0355211736', '01/01/2023', 1, 1, 20000, 220000),
	(2, 2, N'2 Nguyễn Văn Cừ, Phường 9, Quận 12, TP.HCM', '11/01/2023', 'Nguyễn Thị B', '0355211737', '02/01/2023', 1, 0, 20000, 240000),
	(3, 3, N'1 Trương Công Định, Phường Linh Trung, TP. Thủ Đức, TP.HCM', '12/01/2023', 'Nguyễn Thị C', '0355211738', '03/01/2023', 1, 0, 20000, 250000)
GO

INSERT INTO M_ORDER_DETAIL
VALUES
	(1, 1, 1, 60000),
	(1, 2, 2, 140000),
	(2, 1, 1, 60000),
	(2, 3, 2, 160000),
	(3, 4, 1, 50000),
	(3, 5, 2, 180000)
GO


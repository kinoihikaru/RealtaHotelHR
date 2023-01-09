USE Hotel_Realta;
GO
--SERVICE_TASK
SET IDENTITY_INSERT Master.service_task ON;
insert into master.service_task (seta_id, seta_name, seta_seq)
values
(1, 'Receptionist', 1),
(2, 'Housekeeping', 2),
(3, 'Chef', 3),
(4, 'Security', 4),
(5, 'Manager', 5);
SET IDENTITY_INSERT Master.service_task OFF;
SELECT*FROM Master.service_task
ORDER BY seta_id ASC

SET IDENTITY_INSERT Master.category_group ON;
INSERT INTO master.category_group (cagro_id, cagro_name, cagro_description, cagro_type, cagro_icon, cagro_icon_url)
VALUES
  (1, 'ROOM', 'Rooms for guests to stay in', 'category', 'room.png', 'https://example.com/room.png'),
  (2, 'RESTAURANT', 'On-site restaurant for guests to dine in', 'service', 'restaurant.png', 'https://example.com/restaurant.png'),
  (3, 'MEETING ROOM', 'Rooms for meetings and events', 'facility', 'meeting_room.png', 'https://example.com/meeting_room.png'),
  (4, 'GYM', 'Fitness center for guests to use', 'facility', 'gym.png', 'https://example.com/gym.png'),
  (5, 'AULA', 'Multipurpose room for events', 'facility', 'aula.png', 'https://example.com/aula.png'),
  (6, 'SWIMMING POOL', 'Outdoor swimming pool for guests to use', 'facility', 'swimming_pool.png', 'https://example.com/swimming_pool.png'),
  (7, 'BALROOM', 'Ballroom for events and parties', 'facility', 'balroom.png', 'https://example.com/balroom.png');
SET IDENTITY_INSERT Master.category_group OFF;
SELECT*FROM Master.category_group
ORDER BY cagro_id ASC

SET IDENTITY_INSERT Master.Regions ON;
INSERT INTO Master.Regions (region_code, region_name)
VALUES ('1', 'Region 1'), ('2', 'Region 2'), ('3', 'Region 3'),
       ('4', 'Region 4'), ('5', 'Region 5'), ('6', 'Region 6'),
       ('7', 'Region 7'), ('8', 'Region 8'), ('9', 'Region 9'),
       ('10', 'Region 10'), ('11', 'Region 11'), ('12', 'Region 12'),
       ('13', 'Region 13'), ('14', 'Region 14'), ('15', 'Region 15'),
       ('16', 'Region 16'), ('17', 'Region 17'), ('18', 'Region 18'),
       ('19', 'Region 19'), ('20', 'Region 20');
SET IDENTITY_INSERT Master.Regions OFF;
SELECT*FROM Master.Regions
ORDER by region_code ASC

SET IDENTITY_INSERT Master.Country ON;
INSERT INTO .Master.Country (country_id, country_name, country_region_id)
VALUES (1, 'France', 1), (2, 'Germany', 2), (3, 'Spain', 3),
       (4, 'Italy', 4), (5, 'United Kingdom', 5), (6, 'Netherlands', 6),
       (7, 'Belgium', 7), (8, 'Denmark', 8), (9, 'Sweden', 9),
       (10, 'Norway', 10), (11, 'China', 11), (12, 'Japan', 12),
       (13, 'South Korea', 13), (14, 'North Korea', 14), (15, 'India', 15),
       (16, 'Pakistan', 16), (17, 'Bangladesh', 17), (18, 'Nepal', 18),
       (19, 'Bhutan', 19), (20, 'Sri Lanka', 20);
SET IDENTITY_INSERT Master.Country OFF;
SELECT*FROM Master.Country
ORDER by country_id ASC

SET IDENTITY_INSERT Master.Provinces ON;
INSERT INTO Master.Provinces (prov_id, prov_name, prov_country_id)
VALUES (1, 'Ontario', 1), (2, 'Quebec', 1), (3, 'British Columbia', 1),
       (4, 'Alberta', 1), (5, 'Manitoba', 1), (6, 'Saskatchewan', 1),
       (7, 'New Brunswick', 1), (8, 'Nova Scotia', 1), (9, 'Prince Edward Island', 1),
       (10, 'Newfoundland and Labrador', 1), (11, 'Hesse', 2), (12, 'Bavaria', 2),
       (13, 'Baden-Württemberg', 2), (14, 'North Rhine-Westphalia', 2), (15, 'Lower Saxony', 2),
       (16, 'Andalusia', 3), (17, 'Catalonia', 3), (18, 'Valencia', 3),
       (19, 'Galicia', 3), (20, 'Castilla y León', 3);
SET IDENTITY_INSERT Master.provinces OFF;
SELECT*FROM Master.provinces
ORDER BY prov_id

SET IDENTITY_INSERT Master.Address ON;
INSERT INTO Master.Address (addr_id, addr_line1, addr_line2, addr_postal_code, addr_spatial_location, addr_prov_id)
VALUES (1, '123 Main Street', '', 'A1AA1', geography::Point(43.65, -79.38, 4326), 1),
    (2, '456 Maple Avenue', '', 'B2BB2', geography::Point(43.65, -79.38, 4326), 1),
    (3, '789 Oak Boulevard', '', 'C3CC3', geography::Point(43.65, -79.38, 4326), 1),
    (4, '321 Pine Street', '', 'D4DD4', geography::Point(43.65, -79.38, 4326), 1),
    (5, '654 Cedar Road', '', 'E5EE5', geography::Point(43.65, -79.38, 4326), 1),
    (6, '987 Spruce Lane', '', 'F6FF6', geography::Point(43.65, -79.38, 4326), 1),
    (7, '246 Fir Avenue', '', 'G77G7', geography::Point(43.65, -79.38, 4326), 1),
    (8, '369 Hemlock Drive', '', 'H8HH8', geography::Point(43.65, -79.38, 4326), 1),
    (9, '159 Willow Way', '', 'I9II9', geography::Point(43.65, -79.38, 4326), 1),
    (10, '753 Maple Street', '', 'J0JJ0', geography::Point(43.65, -79.38, 4326), 1),
    (11, '1 Parliament Hill', '', 'K1KA6', geography::Point(45.42, -75.70, 4326), 2),
    (12, '2 Sussex Drive', '', 'K1NK1', geography::Point(45.42, -75.70, 4326), 2),
    (13, '3 Rideau Street', '', 'K1NJ9', geography::Point(45.42, -75.70, 4326), 2),
    (14, '4 Wellington Street', '', 'K1PJ9', geography::Point(45.42, -75.70, 4326), 2),
    (15, '5 Elgin Street', '', 'K1PK7', geography::Point(45.42, -75.70, 4326), 2),
    (16, 'Avenida de la Constitución, 3', '', '41001', geography::Point(37.38, -6.00, 4326), 16),
    (17, 'Plaza de Santo Domingo, 3', '', '41001', geography::Point(37.38, -6.00, 4326), 16),
    (18, 'Calle de la Ribera, 15', '', '41001', geography::Point(37.38, -6.00, 4326), 16),
    (19, 'Calle del Arenal, 12', '', '41001', geography::Point(37.38, -6.00, 4326), 16),
    (20, 'Calle de la Ribera, 25', '', '41001', geography::Point(37.38, -6.00, 4326), 16);
SET IDENTITY_INSERT Master.Address OFF;
SELECT*FROM Master.Address
ORDER BY addr_id ASC

SET IDENTITY_INSERT Hotel.Hotels ON;
INSERT INTO Hotel.Hotels (hotel_id, hotel_name, hotel_description, hotel_rating_star, hotel_phonenumber, hotel_modified_date, hotel_addr_id)
VALUES
(1,'Hotel Amaris Palembang', 'Hotel bintang 3 dengan fasilitas yang lengkap dan modern di Palembang', 3, '+62 823 3456 7891', '2022-01-01', 1),
(2,'Grand Clarion Hotel Palembang', 'Hotel bintang 4 dengan kamar yang luas dan nyaman di Palembang', 4, '+62 823 1234 5678', '2022-02-01', 2),
(3,'Aston Hotel Palembang', 'Hotel bintang 5 dengan fasilitas spa dan kolam renang di Palembang', 5, '+62 823 9012 3456', '2022-03-01', 3),
(4,'Hotel Santika Palembang', 'Hotel bintang 3 dengan fasilitas kelas atas di Palembang', 3, '+62 823 7890 1234', '2022-04-01', 3),
(5,'Ibis Hotel Palembang', 'Hotel bintang 3 dengan tarif terjangkau di Palembang', 3, '+62 823 4567 8901', '2022-05-01', 2),
(6,'Grand Mercure Hotel Palembang', 'Hotel bintang 4 dengan fasilitas mewah di Palembang', 4, '+62 823 1234 5679', '2022-06-01', 5),
(7,'Marriott Hotel Palembang', 'Hotel bintang 5 dengan fasilitas spa dan fitness center di Palembang', 5, '+62 823 9012 3457', '2022-07-01', 1),
(8,'Zest Hotel Palembang', 'Hotel bintang 3 dengan desain modern dan nyaman di Palembang', 3, '+62 823 7890 1235', '2022-08-01', 4),
(9,'The Westin Hotel Palembang', 'Hotel bintang 4 dengan fasilitas kelas atas di Palembang', 4, '+62 823 4567 8902', '2022-09-01', 5),
(10,'Swiss-Belhotel Palembang', 'Hotel bintang 5 dengan fasilitas mewah di Palembang', 5, '+62 823 1234 5680', '2022-10-01', 4)
SET IDENTITY_INSERT Hotel.Hotels OFF;
SELECT*FROM Hotel.hotels
ORDER BY hotel_id asc

SET IDENTITY_INSERT Hotel.Facilities ON;
INSERT INTO Hotel.Facilities (faci_id, faci_name, faci_description, faci_max_number, faci_measure_unit, 
faci_room_number, faci_startdate, faci_endate, faci_low_price, faci_high_price, faci_rate_price, 
faci_discount, faci_tax_rate, faci_cagro_id, faci_hotel_id)
VALUES
(1,'Pool', 'Outdoor pool with sun loungers and parasols', 100, 'people', 'POOL01', '2022-01-01', '2022-12-31', 50000, 100000, 75000, 25000, 10000, 6, 1) -- POOL
,(2,'Restaurant', 'Fine dining restaurant serving international cuisine', 100, 'people', 'REST01', '2022-01-01', '2022-12-31', 40000, 80000, 60000, 25000, 10000, 2, 1) -- RESTAURANT
,(3,'Gym', 'Fully equipped gym with treadmills stationary bikes, and weights', 50, 'people', 'GYM01', '2022-01-01', '2022-12-31', 30000, 50000, 40000, 25000, 10000, 4, 1) -- GYM
,(4,'Metting Room', 'Meeting room Luxury, and body treatments', 20, 'people', 'MTG01', '2022-01-01', '2022-12-31', 80000, 120000, 100000, 25000, 10000, 3, 1) -- MEETING
,(5,'Deluxe Room', 'Kamar luas dengan fasilitas mewah, termasuk kamar mandi pribadi dengan shower dan bathtub', 2,'beds', 'DLR01', '2022-01-01', '2022-01-30', 200000, 250000, 230000, 25000, 10000, 1, 1)
,(6,'Superior Room', 'Kamar standar dengan fasilitas lengkap, termasuk kamar mandi pribadi dengan shower', 2,'beds', 'SPR01', '2022-01-01', '2022-01-30', 150000, 180000, 160000, 25000, 10000, 1, 1)
,(7,'Family Room', 'Kamar untuk keluarga, dengan 2 tempat tidur single dan 1 tempat tidur double, serta fasilitas lengkap', 4,'beds', 'FMR01', '2022-01-01', '2022-01-30', 250000, 300000, 270000, 25000, 10000, 1, 1)
,(8,'Standard Room', 'Kamar standar dengan fasilitas sederhana, termasuk kamar mandi pribadi dengan shower', 2,'beds', 'STR01','2022-01-01', '2022-01-30', 100000, 125000, 115000, 25000, 10000, 1, 1)
,(9,'Double Room', 'Kamar dengan 2 tempat tidur single, serta fasilitas lengkap', 2,'beds', 'DBR01', '2022-01-01', '2022-01-30', 150000, 175000, 160000, 25000, 10000, 1, 1)
SET IDENTITY_INSERT Hotel.Facilities OFF;
SELECT*From Hotel.facilities
ORDER BY faci_id asc

--- INSERT MODULE USERS
SET IDENTITY_INSERT users.users ON;
INSERT INTO users.users (user_id, user_full_name, user_type, user_company_name, user_email, user_phone_number, user_modified_date)
VALUES (1,'John Smith', 'T', 'Acme Inc.', 'john.smith@acme.com', '123-456-7890', GETDATE()),
       (2,'Jane Doe', 'C', 'XYZ Corp.', 'jane.doe@xyz.com', '123-456-7891', GETDATE()),
       (3,'Bob Johnson', 'I', 'ABC Inc.', 'bob.johnson@abc.com', '123-456-7892', GETDATE()),
       (4,'Samantha Williams', 'T', 'Def Corp.', 'samantha.williams@def.com', '123-456-7893', GETDATE()),
       (5,'Michael Brown', 'C', 'Ghi Inc.', 'michael.brown@ghi.com', '123-456-7894', GETDATE()),
       (6,'Emily Davis', 'I', 'Jkl Ltd.', 'emily.davis@jkl.com', '123-456-7895', GETDATE()),
       (7,'William Thompson', 'T', 'Mno Inc.', 'william.thompson@mno.com', '123-456-7896', GETDATE()),
       (8,'Ashley Johnson', 'C', 'Pqr Corp.', 'ashley.johnson@pqr.com', '123-456-7897', GETDATE()),
       (9,'David Anderson', 'I', 'Stu Inc.', 'david.anderson@stu.com', '123-456-7898', GETDATE()),
       (10,'Jessica Smith', 'T', 'Vwx Corp.', 'jessica.smith@vwx.com', '123-456-7899', GETDATE()),
	   (11,'David Brown', 'T', 'Example Co', 'david.brown@example.com', '555-555-1222', GETDATE()),
	   (12,'Jessica Smith', 'C', 'Test Inc', 'jessica.smith@test.com', '555-555-1223', GETDATE()),
	   (13,'James Johnson', 'I', 'Acme Inc', 'james.johnson@acme.com', '555-555-1224', GETDATE()),
	   (14,'Samantha Williams', 'C', 'XYZ Corp', 'samantha.williams@xyz.com', '555-555-1225', GETDATE()),
	   (15,'Robert Davis', 'T', 'Example Co', 'robert.davis@example.com', '555-555-1226', GETDATE());
SET IDENTITY_INSERT users.users OFF;
SELECT*FROM Users.users


-- INSERT MODULE HR
SET IDENTITY_INSERT hr.job_role ON
insert into hr.job_role (joro_id, joro_name, joro_modified_date) values
	(1,'Resepsionis', GETDATE()),
	(2,'Porter', GETDATE()),
	(3,'Concierge', GETDATE()),
	(4,'Room Service', GETDATE()),
	(5,'Waiter', GETDATE()),
	(6,'Staff Dapur', GETDATE()),
	(7,'Housekeeper', GETDATE()),
	(8,'Room Division Manager', GETDATE()),
	(9,'Maintenance Staff', GETDATE()),
	(10,'Hotel Manager', GETDATE()),
	(11,'Purchasing', GETDATE()),
	(12,'Sales & Marketing', GETDATE()),
	(13,'Event Planner', GETDATE()),
	(14,'Akuntan', GETDATE())
;
SET IDENTITY_INSERT hr.job_role OFF
select * from hr.job_role;

SET IDENTITY_INSERT hr.employee ON
insert into hr.employee (emp_id, emp_national_id, emp_birth_date, emp_marital_status, emp_gender, emp_hire_date,
	emp_salaried_flag, emp_joro_id) values
	(1, 'a123123123456456456789789', '2001-01-01', 'S', 'M', GETDATE(), '1', 1),
	(2, 'b456456456123123123789789', '2002-02-01', 'M', 'F', GETDATE(), '0', 2),
	(3, 'c231231231339339339013013', '2003-03-01', 'M', 'M', GETDATE(), '1', 3),
	(4, 'd524524524621621621832832', '1999-04-01', 'S', 'F', GETDATE(), '0', 4),
	(5, 'e122122122322322322494944', '1997-05-01', 'S', 'M', GETDATE(), '1', 5),
	(6, 'f090285082940243284423853', '1999-06-01', 'M', 'F', GETDATE(), '0', 6),
	(7, 'g122932483892095343534255', '1998-07-01', 'M', 'M', GETDATE(), '1', 7),
	(8, 'h214392573294812743928523', '2002-08-01', 'S', 'F', GETDATE(), '0', 8),
	(9, 'i217473298498378988932754', '1999-09-01', 'S', 'M', GETDATE(), '1', 9),
	(10, 'j219483945782893873249573', '2001-10-01', 'M', 'F', GETDATE(), '0', 10)
;
SET IDENTITY_INSERT hr.employee OFF
select * from hr.employee;

SET IDENTITY_INSERT hr.shift ON
insert into hr.shift(shift_id, shift_name, shift_start_time, shift_end_time) values
	(1,'Shift 1', '08:00:00', '16:00:00'),
	(2,'Shift 2', '16:00:00', '00:00:00'),
	(3,'Shift 3', '00:00:00', '08:00:00')
;
SET IDENTITY_INSERT hr.shift OFF
select * from hr.shift;

SET IDENTITY_INSERT hr.department ON
insert into hr.department(dept_id, dept_name, dept_modified_date)values 
	(1, 'Front Office', GETDATE()), 
	(2, 'Security', GETDATE()), 
	(3, 'Marketing', GETDATE()), 
	(4, 'Accounting', GETDATE()), 
	(5, 'Food and Beverage', GETDATE()), 
	(6, 'Housekeeping', GETDATE()), 
	(7, 'Purchasing', GETDATE()), 
	(8, 'Engineering', GETDATE()), 
	(9, 'Personalia (HRD)', GETDATE())
;
SET IDENTITY_INSERT hr.department OFF
select * from hr.department;

SET IDENTITY_INSERT hr.employee_department_history ON
insert into hr.employee_department_history(edhi_id, edhi_emp_id, edhi_dept_id, edhi_shift_id) values 
	(1,1, 1, 1),
	(2,2, 2, 2),
	(3,3, 3, 3),
	(4,4, 4, 1),
	(5,5, 5, 2),
	(6,6, 6, 3),
	(7,7, 7, 1),
	(8,8, 8, 2),
	(9,9, 9, 3),
	(10,10, 2, 1)
;
SET IDENTITY_INSERT hr.employee_department_history OFF
select * from hr.employee_department_history;

insert into hr.employee_pay_history (ephi_emp_id, ephi_rate_change_date) values
	(1, GETDATE()),
	(2, GETDATE()),
	(3, GETDATE()),
	(4, GETDATE()),
	(5, GETDATE()),
	(6, GETDATE()),
	(7, GETDATE()),
	(8, GETDATE()),
	(9, GETDATE()),
	(10, GETDATE())
;
select * from hr.employee_pay_history;

SET IDENTITY_INSERT HR.work_orders ON;
Insert into HR.work_orders (woro_id,woro_date, woro_status, woro_user_id) values ('1','1995-01-14', 'OPEN' ,'2');
Insert into HR.work_orders (woro_id,woro_date, woro_status, woro_user_id) values ('2','1995-02-09', 'CLOSED' ,'2');
Insert into HR.work_orders (woro_id,woro_date, woro_status, woro_user_id) values ('3','1995-03-17', 'CANCELLED' ,'2');
Insert into HR.work_orders (woro_id,woro_date, woro_status, woro_user_id) values ('4','1995-04-03', 'CLOSED' ,'3');
Insert into HR.work_orders (woro_id,woro_date, woro_status, woro_user_id) values ('5','1995-07-12', 'OPEN' ,'2');
Insert into HR.work_orders (woro_id,woro_date, woro_status, woro_user_id) values ('6','1995-08-19', 'CANCELLED' ,'5');
Insert into HR.work_orders (woro_id,woro_date, woro_status, woro_user_id) values ('7','1995-09-17', 'CLOSED' ,'4');
Insert into HR.work_orders (woro_id,woro_date, woro_status, woro_user_id) values ('8','1995-11-20', 'OPEN' ,'5');
Insert into HR.work_orders (woro_id,woro_date, woro_status, woro_user_id) values ('9','1995-12-23', 'CANCELLED' ,'5');
Insert into HR.work_orders (woro_id,woro_date, woro_status, woro_user_id) values ('10','1995-12-27','CLOSED' , '4');
SET IDENTITY_INSERT HR.work_orders OFF;
SELECT*FROM hr.work_orders

SET IDENTITY_INSERT HR.work_order_detail ON;
Insert into HR.work_order_detail (wode_id, wode_task_name, wode_status, wode_start_date, wode_end_date, wode_notes, wode_emp_id, wode_seta_id, wode_faci_id, wode_woro_id) values ('1', 'work detail 1', 'INPROGRESS', '1995-01-14', '1995-03-14', 'Masih Bekerja', '2', '2', '1', '2');
Insert into HR.work_order_detail (wode_id, wode_task_name, wode_status, wode_start_date, wode_end_date, wode_notes, wode_emp_id, wode_seta_id, wode_faci_id, wode_woro_id) values ('2', 'work detail 2', 'COMPLETED', '1995-01-14', '1995-03-14', 'Selesai', '3', '1', '2', '1');
Insert into HR.work_order_detail (wode_id, wode_task_name, wode_status, wode_start_date, wode_end_date, wode_notes, wode_emp_id, wode_seta_id, wode_faci_id, wode_woro_id) values ('3', 'work detail 3', 'CANCELLED', '1995-01-14', '1995-03-14', 'Ada Kenadala', '4', '1', '5', '3');
Insert into HR.work_order_detail (wode_id, wode_task_name, wode_status, wode_start_date, wode_end_date, wode_notes, wode_emp_id, wode_seta_id, wode_faci_id, wode_woro_id) values ('4', 'work detail 4', 'INPROGRESS', '1995-01-14', '1995-03-14', 'Masih Bekerja', '6', '3', '9', '5');
Insert into HR.work_order_detail (wode_id, wode_task_name, wode_status, wode_start_date, wode_end_date, wode_notes, wode_emp_id, wode_seta_id, wode_faci_id, wode_woro_id) values ('5', 'work detail 5', 'COMPLETED', '1995-01-14', '1995-03-14', 'Selesai', '5', '4', '8', '6');
Insert into HR.work_order_detail (wode_id, wode_task_name, wode_status, wode_start_date, wode_end_date, wode_notes, wode_emp_id, wode_seta_id, wode_faci_id, wode_woro_id) values ('6', 'work detail 6', 'CANCELLED', '1995-01-14', '1995-03-14', 'Ada Kenadala', '5', '5', '7', '7');
Insert into HR.work_order_detail (wode_id, wode_task_name, wode_status, wode_start_date, wode_end_date, wode_notes, wode_emp_id, wode_seta_id, wode_faci_id, wode_woro_id) values ('7', 'work detail 7', 'COMPLETED', '1995-01-14', '1995-03-14', 'Selesai', '10', '4', '1', '10');
Insert into HR.work_order_detail (wode_id, wode_task_name, wode_status, wode_start_date, wode_end_date, wode_notes, wode_emp_id, wode_seta_id, wode_faci_id, wode_woro_id) values ('8', 'work detail 8', 'CANCELLED', '1995-01-14', '1995-03-14', 'Ada Kenadala', '10', '1', '2', '1');
Insert into HR.work_order_detail (wode_id, wode_task_name, wode_status, wode_start_date, wode_end_date, wode_notes, wode_emp_id, wode_seta_id, wode_faci_id, wode_woro_id) values ('9', 'work detail 9', 'COMPLETED', '1995-01-14', '1995-03-14', 'Selesai', '4', '3', '2', '5');
Insert into HR.work_order_detail (wode_id, wode_task_name, wode_status, wode_start_date, wode_end_date, wode_notes, wode_emp_id, wode_seta_id, wode_faci_id, wode_woro_id) values ('10', 'work detail 10', 'INPROGRESS', '1995-01-14', '1995-03-14', 'Masih Bekerja', '4', '5', '6', '4');
SET IDENTITY_INSERT HR.work_order_detail OFF;
SELECT*FROM hr.work_order_detail

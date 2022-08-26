/*
SQLyog Professional v13.1.1 (64 bit)
MySQL - 10.4.14-MariaDB : Database - hotel
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`hotel` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;

USE `hotel`;

/*Table structure for table `tb_checkin` */

DROP TABLE IF EXISTS `tb_checkin`;

CREATE TABLE `tb_checkin` (
  `kd_checkin` varchar(10) NOT NULL,
  `kd_kamar` varchar(10) DEFAULT NULL,
  `id_tamu` varchar(10) DEFAULT NULL,
  `id_karyawan` varchar(10) DEFAULT NULL,
  `tgl_checkin` date DEFAULT NULL,
  `lama_tinggal` int(11) DEFAULT NULL,
  `keterangan` text DEFAULT NULL,
  `status_checkin` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`kd_checkin`),
  KEY `fk_kd_kamar` (`kd_kamar`),
  KEY `fk_id_tamu` (`id_tamu`),
  KEY `fk_id_karyawan` (`id_karyawan`),
  CONSTRAINT `fk_id_karyawan` FOREIGN KEY (`id_karyawan`) REFERENCES `tb_karyawan` (`id_karyawan`),
  CONSTRAINT `fk_id_tamu` FOREIGN KEY (`id_tamu`) REFERENCES `tb_tamu` (`id_tamu`),
  CONSTRAINT `fk_kd_kamar` FOREIGN KEY (`kd_kamar`) REFERENCES `tb_kamar` (`kd_kamar`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tb_checkin` */

insert  into `tb_checkin`(`kd_checkin`,`kd_kamar`,`id_tamu`,`id_karyawan`,`tgl_checkin`,`lama_tinggal`,`keterangan`,`status_checkin`) values 
('CIN000','KAM208','TM001','KAR007','2021-09-07',2,'Ngamer Yuk','Selesai'),
('CIN003','KAM102','TM002','KAR002','2021-09-07',3,'menginap','selesai'),
('CIN111','KAM101','TM001','KAR001','2021-09-07',1,'aa','selesai');

/*Table structure for table `tb_checkout` */

DROP TABLE IF EXISTS `tb_checkout`;

CREATE TABLE `tb_checkout` (
  `kd_checkout` varchar(10) NOT NULL,
  `kd_checkin` varchar(10) DEFAULT NULL,
  `tanggal_checkout` date DEFAULT NULL,
  PRIMARY KEY (`kd_checkout`),
  KEY `fk_kd_checkin` (`kd_checkin`),
  CONSTRAINT `fk_kd_checkin` FOREIGN KEY (`kd_checkin`) REFERENCES `tb_checkin` (`kd_checkin`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tb_checkout` */

insert  into `tb_checkout`(`kd_checkout`,`kd_checkin`,`tanggal_checkout`) values 
('COT000','CIN111','2021-09-08'),
('COT001','CIN000','2021-09-07'),
('COT111','CIN111','2021-09-07'),
('COT123','CIN003','2021-09-07'),
('COT456','CIN111','2021-09-09'),
('COT777','CIN003','2021-09-08'),
('COT999','CIN003','2021-09-07');

/*Table structure for table `tb_fasilitas` */

DROP TABLE IF EXISTS `tb_fasilitas`;

CREATE TABLE `tb_fasilitas` (
  `kd_fasilitas` varchar(10) NOT NULL,
  `nama_fasilitas` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`kd_fasilitas`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tb_fasilitas` */

insert  into `tb_fasilitas`(`kd_fasilitas`,`nama_fasilitas`) values 
('FAS001','Standard'),
('FAS002','Superior'),
('FAS003','Deluxe'),
('FAS004','Junior Suite'),
('FAS005','Suite'),
('FAS006','Presidental Suite');

/*Table structure for table `tb_history` */

DROP TABLE IF EXISTS `tb_history`;

CREATE TABLE `tb_history` (
  `id_checkout` char(10) NOT NULL,
  `nama_tamu` varchar(50) DEFAULT NULL,
  `kd_checkin` char(10) NOT NULL,
  `id_tamu` char(10) NOT NULL,
  `kd_kamar` char(10) NOT NULL,
  `no_telepon` varchar(15) DEFAULT NULL,
  `tgl_checkin` varchar(20) DEFAULT NULL,
  `tgl_checkout` varchar(20) DEFAULT NULL,
  `lama_inap` int(11) DEFAULT NULL,
  `harga_kamar` int(11) DEFAULT NULL,
  `tagihan` int(11) DEFAULT NULL,
  `pembayaran` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tb_history` */

/*Table structure for table `tb_kamar` */

DROP TABLE IF EXISTS `tb_kamar`;

CREATE TABLE `tb_kamar` (
  `kd_kamar` varchar(10) NOT NULL,
  `kd_tipekamar` varchar(10) DEFAULT NULL,
  `kd_fasilitas` varchar(10) DEFAULT NULL,
  `harga` int(11) DEFAULT NULL,
  `kapasitas` varchar(30) DEFAULT NULL,
  `status` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`kd_kamar`),
  KEY `fk_kd_tipekamar` (`kd_tipekamar`),
  KEY `fk_kd_fasilitas` (`kd_fasilitas`),
  CONSTRAINT `fk_kd_fasilitas` FOREIGN KEY (`kd_fasilitas`) REFERENCES `tb_fasilitas` (`kd_fasilitas`),
  CONSTRAINT `fk_kd_tipekamar` FOREIGN KEY (`kd_tipekamar`) REFERENCES `tb_tipekamar` (`kd_tipekamar`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tb_kamar` */

insert  into `tb_kamar`(`kd_kamar`,`kd_tipekamar`,`kd_fasilitas`,`harga`,`kapasitas`,`status`) values 
('KAM101','TIK001','FAS001',85000,'1','Tersedia'),
('KAM102','TIK002','FAS001',150000,'1','Tersedia'),
('KAM103','TIK001','FAS001',75000,'1','Terisi'),
('KAM104','TIK001','FAS001',75000,'1','Tersedia'),
('KAM105','TIK001','FAS002',100000,'1','Tersedia'),
('KAM106','TIK001','FAS002',100000,'1','Tersedia'),
('KAM107','TIK002','FAS001',125000,'2','Tersedia'),
('KAM108','TIK002','FAS001',125000,'2','Tersedia'),
('KAM109','TIK002','FAS002',150000,'2','Tersedia'),
('KAM110','TIK002','FAS002',150000,'2','Tersedia'),
('KAM201','TIK003','FAS001',175000,'2','Tersedia'),
('KAM202','TIK003','FAS001',175000,'2','Terisi'),
('KAM203','TIK003','FAS002',200000,'2','Tersedia'),
('KAM204','TIK003','FAS002',200000,'2','Tersedia'),
('KAM205','TIK003','FAS003',225000,'2','Tersedia'),
('KAM206','TIK003','FAS003',225000,'2','Tersedia'),
('KAM207','TIK003','FAS004',250000,'2','Tersedia'),
('KAM208','TIK003','FAS004',250000,'2','Tersedia'),
('KAM301','TIK003','FAS005',300000,'4','Tersedia'),
('KAM302','TIK003','FAS005',300000,'4','Tersedia'),
('KAM303','TIK004','FAS003',350000,'4','Tersedia'),
('KAM304','TIK004','FAS003',350000,'4','Tersedia'),
('KAM305','TIK004','FAS005',400000,'4','Tersedia'),
('KAM306','TIK004','FAS005',400000,'4','Tersedia'),
('KAM401','TIK004','FAS005',500000,'6','Tersedia'),
('KAM402','TIK004','FAS005',500000,'6','Tersedia'),
('KAM403','TIK004','FAS005',500000,'6','Tersedia'),
('KAM404','TIK004','FAS005',500000,'6','Tersedia'),
('KAM501','TIK004','FAS006',750000,'4','Tersedia');

/*Table structure for table `tb_karyawan` */

DROP TABLE IF EXISTS `tb_karyawan`;

CREATE TABLE `tb_karyawan` (
  `id_karyawan` varchar(10) NOT NULL,
  `no_ktp` varchar(30) DEFAULT NULL,
  `nama_karyawan` varchar(30) DEFAULT NULL,
  `jenis_kelamin` varchar(15) DEFAULT NULL,
  `alamat` varchar(50) DEFAULT NULL,
  `email` varchar(30) DEFAULT NULL,
  `no_telepon` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id_karyawan`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tb_karyawan` */

insert  into `tb_karyawan`(`id_karyawan`,`no_ktp`,`nama_karyawan`,`jenis_kelamin`,`alamat`,`email`,`no_telepon`) values 
('KAR001','4326817368721648','Af\'idatul Maghfiroh','Perempuan','Salatiga','afida@gmail.com','081246532764'),
('KAR002','7215487125478218','Yoga Hendrapratama','Laki-laki','Kawali - Ciamis','yhepra@gmail.com','082211466516'),
('KAR003','3242385326847216','Hani Oktaviani','Perempuan','Pangandaran','hanimun@gmail.com','087352635261'),
('KAR004','2362736273618261','Jaja Nurjana','Laki-laki','Banjarsari','janur@gmail.com','085678367263'),
('KAR005','2367176254726335','Raisa Kamel','Perempuan','Cianjur','camel@gmail.com','083726376237'),
('KAR006','7476324728374326','Dede Rifaldi','Laki-laki','Indramayu','dedeku@gmail.com','0890238923786'),
('KAR007','8326492184698164','Rahma Fauziah','Perempuan','Boyolali','rhmfa@gmail.com','0832371263127'),
('KAR008','3625482147514817','Moh Afkarul Haq','Laki-laki','Ciamis Jawa Barat','afkrl@gmail.com','085236242166'),
('KAR009',' 08337467733008','Bayu Wijiana','Laki-laki','bandung jl jendral no 11','merly@gmail.com','099868711'),
('KAR010',' 0987654323456789','Otong','Laki-laki','banjarsari','bt@gmail.com','0987654345678');

/*Table structure for table `tb_tamu` */

DROP TABLE IF EXISTS `tb_tamu`;

CREATE TABLE `tb_tamu` (
  `id_tamu` varchar(10) NOT NULL,
  `no_ktp` varchar(30) DEFAULT NULL,
  `nama_tamu` varchar(30) DEFAULT NULL,
  `jenis_kelamin` varchar(15) DEFAULT NULL,
  `alamat` varchar(50) DEFAULT NULL,
  `email` varchar(30) DEFAULT NULL,
  `no_telepon` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id_tamu`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tb_tamu` */

insert  into `tb_tamu`(`id_tamu`,`no_ktp`,`nama_tamu`,`jenis_kelamin`,`alamat`,`email`,`no_telepon`) values 
('TM001','2345677534567876','Aris Purnama','Laki-laki','Banjarsari','Aris@gmail.com','081323068201'),
('TM002','0823453432243564','Bayu Wijianan','Laki-laki','Banyumas, Jawa Tengah Indonesia','Bayu@gmail.com','0823284263456');

/*Table structure for table `tb_tipekamar` */

DROP TABLE IF EXISTS `tb_tipekamar`;

CREATE TABLE `tb_tipekamar` (
  `kd_tipekamar` varchar(10) NOT NULL,
  `nama_tipe` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`kd_tipekamar`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tb_tipekamar` */

insert  into `tb_tipekamar`(`kd_tipekamar`,`nama_tipe`) values 
('TIK001','Single Room'),
('TIK002','Twin Room'),
('TIK003','Double Room'),
('TIK004','Family Room');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

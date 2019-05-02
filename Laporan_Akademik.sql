DROP TABLE DOSEN CASCADE CONSTRAINT PURGE;
DROP TABLE JADWAL_MATAKULIAH CASCADE CONSTRAINT PURGE;
DROP TABLE MAHASISWA CASCADE CONSTRAINT PURGE;
DROP TABLE MATAKULIAH_MAHASISWA CASCADE CONSTRAINT PURGE;
DROP TABLE MASTER_JURUSAN CASCADE CONSTRAINT PURGE;

/*==============================================================*/
/* Table: DOSEN */
/*==============================================================*/
CREATE TABLE DOSEN 
(
   KODE_DOSEN VARCHAR(10) NOT NULL,
   NAMA_DOSEN VARCHAR(50) NULL,
   JK_DOSEN VARCHAR(1) NULL,
   EMAIL_DOSEN VARCHAR(20) NULL,
   ALAMAT_DOSEN VARCHAR(30) NULL,
   TELP_DOSEN INTEGER NULL,
   STATUS_DOSEN VARCHAR(15) NULL,
   CONSTRAINT PK_DOSEN PRIMARY KEY (KODE_DOSEN)
);

/*==============================================================*/
/* Table: JADWAL_MATAKULIAH */
/*==============================================================*/
CREATE TABLE JADWAL_MATAKULIAH 
(
   KODE_MK VARCHAR(10) NOT NULL,
   NAMA_MK VARCHAR(30) NULL,
   SMST_MK INTEGER NULL,
   SKS_MATKUL INTEGER NULL,
   JURUSAN_MK VARCHAR(30) NULL,
   KELAS_MK VARCHAR(10) NULL,
   HARI_MK VARCHAR(10) NULL,
   JAM_MK VARCHAR(10) NULL,
   RUANG_MK VARCHAR(10) NULL,
   KODE_PENGAJAR VARCHAR(10) REFERENCES KATEGORI(IDKAT),
   CONSTRAINT PK_JADWAL_MATAKULIAH PRIMARY KEY (KODE_MK)
);

/*==============================================================*/
/* Table: MAHASISWA */
/*==============================================================*/
CREATE TABLE MAHASISWA 
(
   NRP_MHS INTEGER NOT NULL,
   NAMA_MHS VARCHAR(50) NULL,
   JURUSAN_MHS VARCHAR(20) NULL,
   KELAS_MHS VARCHAR(1) NULL,
   TGL_LAHIR_MHS DATE NULL,
   JK_MHS VARCHAR(1) NULL,
   EMAIL_MHS VARCHAR(20) NULL,
   ALAMAT_MHS VARCHAR(30) NULL,
   TELP_MHS INTEGER NULL,
   STATUS_MHS VARCHAR(15) NULL,
   KODE_DOSEN_WALI VARCHAR(10) NULL,
   CONSTRAINT PK_MAHASISWA PRIMARY KEY (NRP_MHS)
);

/*==============================================================*/
/* Table: MATAKULIAH_MAHASISWA */
/*==============================================================*/
CREATE TABLE MATAKULIAH_MAHASISWA 
(
   KODE_MATKUL VARCHAR(10) NOT NULL,
   NRP_MHS INTEGER NULL,
   NAMA_MATKUL VARCHAR(30) NULL,
   SMST_MATKUL INTEGER NULL,
   SKS_MATKUL INTEGER NULL,
   SIFAT_MATKUL VARCHAR(20) NULL,
   NILAI_UTS INTEGER NULL,
   NILAI_UAS INTEGER NULL,
   NILAI_AKHIR INTEGER NULL,
   GRADE VARCHAR(1) NULL,
   STATUS_MATKUL VARCHAR(15) NULL,
   KE INTEGER NULL,
   CONSTRAINT PK_MATAKULIAH_MAHASISWA PRIMARY KEY (KODE_MATKUL)
);

/*==============================================================*/
/* Table: MASTER_JURUSAN */
/*==============================================================*/
CREATE TABLE MASTER_JURUSAN 
(
   KODE_MJ INTEGER NOT NULL,
   NAMA_MJ VARCHAR(30) NULL,
   CONSTRAINT PK_MASTER_JURUSAN PRIMARY KEY (KODE_MJ)
);

INSERT INTO DOSEN VALUES('TM001','Tamariska Marcelline','P','tamariskacelline@gmail.com','jalan Ahmad No. 12',081384552458,'Single');
INSERT INTO DOSEN VALUES('AG001','Agatha','P','agatha@gmail.com','jalan Kendari blok AA No. 57',085911274387,'Married');
INSERT INTO DOSEN VALUES('TM002','Tony Mario','L','tonym@gmail.com','jalan Kupang Jaya gang XV No. 66',085143358003,'Married');
INSERT INTO DOSEN VALUES('DT001','Devina Tammy','P','devi@gmail.com','jalan Bukittinggi No. 129',085427380075,'Single');
INSERT INTO DOSEN VALUES('GG001','Goofy Gunardi Setiawan','L','goofygs@gmail.com','jalan Kertajaya blok I No. 4',082416987873,'Single');

INSERT INTO JADWAL_MATAKULIAH VALUES('INF001','Bahasa Indonesia',1,3,'Teknik Informatika','B','Selasa','15.30','U-401','DT001');
INSERT INTO JADWAL_MATAKULIAH VALUES('DKV001','Kaligrafi',2,3,'Desain Komunikasi Visual','A','Senin','08.00','E-305','DT001');
INSERT INTO JADWAL_MATAKULIAH VALUES('INF002','Pemrograman Client Server',4,3,'Teknik Informatika','A','Jumat','10.30','L-204','TM002');
INSERT INTO JADWAL_MATAKULIAH VALUES('SIB001','Pemrograman Client Server',4,3,'Sistem Informasi Bisnis','C','Jumat','10.30','L-304','TM001');
INSERT INTO JADWAL_MATAKULIAH VALUES('SIB002','Akutansi',4,2,'Sistem Informasi Bisnis','A','Jumat','10.30','U-303','TM001');
INSERT INTO JADWAL_MATAKULIAH VALUES('SIB003','Akutansi',4,2,'Sistem Informasi Bisnis','B','Jumat','10.30','U-102','GG001');

INSERT INTO MAHASISWA VALUES(216116536,'Edwin Lo','Teknik Informatika','B',TO_DATE('24-06-2018', 'DD-MM-YYYY'),'L','edwin@gmail.com','SDPS Gang 15 No. 150',082337123047,'Single','TM002');
INSERT INTO MAHASISWA VALUES(215116467,'Matalangit','Teknik Informatika','B',TO_DATE('24-06-2018', 'DD-MM-YYYY'),'L','edwin@gmail.com','SDPS Gang 15 No. 150',082337123047,'Single','TM002');
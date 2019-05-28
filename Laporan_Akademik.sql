DROP TABLE DOSEN CASCADE CONSTRAINT PURGE;
DROP TABLE JADWAL_MATAKULIAH CASCADE CONSTRAINT PURGE;
DROP TABLE MAHASISWA CASCADE CONSTRAINT PURGE;
DROP TABLE MATAKULIAH_MAHASISWA CASCADE CONSTRAINT PURGE;
DROP TABLE MASTER_JURUSAN CASCADE CONSTRAINT PURGE;
DROP TABLE MASTER_MATAKULIAH CASCADE CONSTRAINT PURGE;
DROP TABLE PENGAMBILAN_MATAKULIAH CASCADE CONSTRAINT PURGE;

/*==============================================================*/
/* Table: MASTER_JURUSAN */
/*==============================================================*/
CREATE TABLE MASTER_JURUSAN 
(
   KODE_MJ INTEGER CONSTRAINT KODE_MASTER_JURUSAN NOT NULL,
   NAMA_MJ VARCHAR(30) CONSTRAINT NAMA_MASTER_JURUSAN NOT NULL,
   CONSTRAINT PK_MASTER_JURUSAN PRIMARY KEY (KODE_MJ)
);

/*==============================================================*/
/* Table: DOSEN */
/*==============================================================*/
CREATE TABLE DOSEN 
(
   KODE_DOSEN VARCHAR(10) CONSTRAINT KODE_DOSEN NOT NULL,
   NAMA_DOSEN VARCHAR(50) CONSTRAINT NAMA_DOSEN NOT NULL,
   JK_DOSEN VARCHAR(1) CONSTRAINT JK_DOSEN NOT NULL CHECK(JK_DOSEN='L' OR JK_DOSEN='P'),
   EMAIL_DOSEN VARCHAR(50) CONSTRAINT EMAIL_DOSEN NOT NULL,
   ALAMAT_DOSEN VARCHAR(50) CONSTRAINT ALAMAT_DOSEN NOT NULL,
   TELP_DOSEN VARCHAR(20) CONSTRAINT TELP_DOSEN NOT NULL,
   STATUS_DOSEN VARCHAR(15) CONSTRAINT STATUS_DOSEN NOT NULL CHECK(STATUS_DOSEN='Tetap' OR STATUS_DOSEN='Tidak Tetap'),
   CONSTRAINT PK_DOSEN PRIMARY KEY (KODE_DOSEN)
);

/*==============================================================*/
/* Table: MASTER_MATAKULIAH */
/*==============================================================*/
CREATE TABLE MASTER_MATAKULIAH 
(
   KODE_MK VARCHAR(10) CONSTRAINT KODE_MASTER_MATAKULIAH NOT NULL,
   NAMA_MK VARCHAR(30) CONSTRAINT NAMA_MASTER_MATAKULIAH NOT NULL,
   JURUSAN_MK VARCHAR(30) CONSTRAINT JURUSAN_MASTER_MATAKULIAH NOT NULL,
   SMST_MK INTEGER CONSTRAINT SMST_MASTER_MATAKULIAH NOT NULL CHECK(SMST_MK>0 AND SMST_MK<=8),
   SKS_MATKUL INTEGER CONSTRAINT SKS_MASTER_MATAKULIAH NOT NULL CHECK(SKS_MATKUL>=2 AND SKS_MATKUL<=4),
   CONSTRAINT PK_MASTER_MATAKULIAH PRIMARY KEY (KODE_MK)
);

/*==============================================================*/
/* Table: JADWAL_MATAKULIAH */
/*==============================================================*/
CREATE TABLE JADWAL_MATAKULIAH
(
   KODE_MK VARCHAR(10) CONSTRAINT KODE_JADWAL_MATAKULIAH NOT NULL REFERENCES MASTER_MATAKULIAH(KODE_MK),
   HARI_MK VARCHAR(10) CONSTRAINT HARI_JADWAL_MATAKULIAH NOT NULL CHECK(HARI_MK='Senin' OR HARI_MK='Selasa' OR HARI_MK='Rabu' 
      OR HARI_MK='Kamis' OR HARI_MK='Jumat' OR HARI_MK='Sabtu'),
   KELAS_MK VARCHAR(1) CONSTRAINT KELAS_JADWAL_MATAKULIAH NOT NULL,
   JAM_MK VARCHAR(10) CONSTRAINT JAM_JADWAL_MATAKULIAH NOT NULL,
   RUANG_MK VARCHAR(10) CONSTRAINT RUANG_JADWAL_MATAKULIAH NOT NULL,
   KODE_PENGAJAR VARCHAR(10) CONSTRAINT KODE_DOSEN_JADWAL_MATAKULIAH NOT NULL REFERENCES DOSEN(KODE_DOSEN)
);

/*==============================================================*/
/* Table: MAHASISWA */
/*==============================================================*/
CREATE TABLE MAHASISWA 
(
   NRP_MHS INTEGER CONSTRAINT NRP_MAHASISWA NOT NULL,
   THN_REG INTEGER CONSTRAINT THN_REG_MAHASISWA NOT NULL,
   NAMA_MHS VARCHAR(50) CONSTRAINT NAMA_MAHASISWA NOT NULL,
   JURUSAN_MHS VARCHAR(40) CONSTRAINT JURUSAN_MAHASISWA NOT NULL,
   KELAS_MHS VARCHAR(1) CONSTRAINT KELAS_MAHASISWA NOT NULL,
   SMST_MHS INTEGER CONSTRAINT SEMESTER_MAHASISWA NOT NULL,
   TGL_LAHIR_MHS DATE CONSTRAINT TGL_LAHIR_MAHASISWA NOT NULL,
   JK_MHS VARCHAR(1) CONSTRAINT JK_MAHASISWA NOT NULL CHECK(JK_MHS='L' OR JK_MHS='P'),
   EMAIL_MHS VARCHAR(50) CONSTRAINT EMAIL_MAHASISWA NOT NULL,
   ALAMAT_MHS VARCHAR(50) CONSTRAINT ALAMAT_MAHASISWA NOT NULL,
   TELP_MHS VARCHAR(20) CONSTRAINT TELP_MAHASISWA NOT NULL,
   STATUS_MHS VARCHAR(15) CONSTRAINT STATUS_MAHASISWA NOT NULL CHECK(STATUS_MHS='Aktif' OR STATUS_MHS='Cuti' OR STATUS_MHS='Tidak Aktif'),
   KODE_DOSEN_WALI VARCHAR(10) CONSTRAINT KODE_DOSEN_WALI_MAHASISWA NOT NULL REFERENCES DOSEN(KODE_DOSEN),
   CONSTRAINT PK_MAHASISWA PRIMARY KEY (NRP_MHS)
);

/*==============================================================*/
/* Table: PENGAMBILAN_MATAKULIAH */
/*==============================================================*/
CREATE TABLE PENGAMBILAN_MATAKULIAH
(
   NRP_MHS INTEGER CONSTRAINT PM_NRP_MHS NOT NULL REFERENCES MAHASISWA(NRP_MHS),
   KODE_MK VARCHAR(10) CONSTRAINT PM_KODE_MK NOT NULL,
   NILAI_UTS INTEGER CONSTRAINT PM_NILAI_UTS NOT NULL CHECK(NILAI_UTS>=0 AND NILAI_UTS<=100),
   NILAI_UAS INTEGER CONSTRAINT PM_NILAI_UAS NOT NULL CHECK(NILAI_UAS>=0 AND NILAI_UAS<=100),
   NILAI_AKHIR INTEGER CONSTRAINT PM_NILAI_AKHIR NOT NULL CHECK(NILAI_AKHIR>=0 AND NILAI_AKHIR<=100),
   GRADE VARCHAR(1) CONSTRAINT PM_GRADE NOT NULL CHECK(GRADE='A' OR GRADE='B' OR GRADE='C' OR GRADE='D' OR GRADE='E'),
   STATUS_MATKUL VARCHAR(15) CONSTRAINT PM_STATUS_MATKUL NOT NULL CHECK(STATUS_MATKUL='Lulus' OR STATUS_MATKUL='Tidak Lulus'),
   KE INTEGER CONSTRAINT PM_KE NOT NULL CHECK(KE>0 AND KE<=10)
);

/*==============================================================*/
/* Table: MATAKULIAH_MAHASISWA */
/*==============================================================*/
CREATE TABLE MATAKULIAH_MAHASISWA
(
   NRP_MHS INTEGER CONSTRAINT MM_NRP_MHS NOT NULL REFERENCES MAHASISWA(NRP_MHS),
   KODE_MK VARCHAR(10) CONSTRAINT MM_KODE_MK NOT NULL,
   NILAI_UTS INTEGER CONSTRAINT MM_NILAI_UTS NOT NULL CHECK(NILAI_UTS>=0 AND NILAI_UTS<=100),
   NILAI_UAS INTEGER CONSTRAINT MM_NILAI_UAS NOT NULL CHECK(NILAI_UAS>=0 AND NILAI_UAS<=100),
   NILAI_AKHIR INTEGER CONSTRAINT MM_NILAI_AKHIR NOT NULL CHECK(NILAI_AKHIR>=0 AND NILAI_AKHIR<=100),
   GRADE VARCHAR(1) CONSTRAINT MM_GRADE NOT NULL CHECK(GRADE='A' OR GRADE='B' OR GRADE='C' OR GRADE='D' OR GRADE='E'),
   STATUS_MATKUL VARCHAR(15) CONSTRAINT MM_STATUS_MATKUL NOT NULL CHECK(STATUS_MATKUL='Lulus' OR STATUS_MATKUL='Tidak Lulus'),
   KE INTEGER CONSTRAINT MM_KE NOT NULL CHECK(KE>0 AND KE<=10),
   SMST_MHS INTEGER CONSTRAINT MM_SMST_MHS NOT NULL,
   IPS_MHS FLOAT(5) CONSTRAINT MM_IPS_MHS NOT NULL,
   IPK_MHS FLOAT(5) CONSTRAINT MM_IPK_MHS NOT NULL
);

CREATE OR REPLACE TRIGGER INSERTJURUSAN
BEFORE INSERT ON MASTER_JURUSAN
FOR EACH ROW
DECLARE
   CTR INTEGER; RAN INTEGER; ERR EXCEPTION;
BEGIN
   SELECT COUNT(*) INTO CTR FROM MASTER_JURUSAN WHERE NAMA_MJ=:NEW.NAMA_MJ;
   IF CTR>0 THEN RAISE ERR;
   ELSE LOOP RAN:=DBMS_RANDOM.VALUE(100,999);
         SELECT COUNT(KODE_MJ) INTO CTR FROM MASTER_JURUSAN WHERE KODE_MJ=RAN;
         EXIT WHEN CTR<1;
      END LOOP; :NEW.KODE_MJ:=RAN;
   END IF;
EXCEPTION
   WHEN ERR THEN RAISE_APPLICATION_ERROR(-20000,'Nama Jurusan Sudah Tersedia');
END;
/  
SHOW ERR;

INSERT INTO MASTER_JURUSAN VALUES(0,'Teknik Informatika');
INSERT INTO MASTER_JURUSAN VALUES(0,'Sistem Informasi Bisnis');
INSERT INTO MASTER_JURUSAN VALUES(0,'Desain Komunikasi Visual');
INSERT INTO MASTER_JURUSAN VALUES(0,'Desain Produk');
INSERT INTO MASTER_JURUSAN VALUES(0,'Teknik Produk');
INSERT INTO MASTER_JURUSAN VALUES(0,'Teknik Elektro');
INSERT INTO MASTER_JURUSAN VALUES(0,'Teknik Industri');
INSERT INTO MASTER_JURUSAN VALUES(0,'Psikologi');
INSERT INTO MASTER_JURUSAN VALUES(0,'Farmasi');
INSERT INTO MASTER_JURUSAN VALUES(0,'Desain Interior');
INSERT INTO MASTER_JURUSAN VALUES(0,'Ahli Interior');
INSERT INTO MASTER_JURUSAN VALUES(0,'Teknik Sipil');
INSERT INTO MASTER_JURUSAN VALUES(0,'Ahli Sipil');
INSERT INTO MASTER_JURUSAN VALUES(0,'Teknik Nuklir');
INSERT INTO MASTER_JURUSAN VALUES(0,'Pariwisata');
INSERT INTO MASTER_JURUSAN VALUES(0,'Arsitek');

CREATE OR REPLACE TRIGGER INSERTDOSEN
BEFORE INSERT ON DOSEN
FOR EACH ROW
DECLARE 
   JUMKAT NUMBER; IDM NUMBER; NM VARCHAR2(10); CH CHAR; ERR EXCEPTION;
BEGIN
   LOOP
      CH:=SUBSTR(:NEW.NAMA_DOSEN,1,1);
      IF CH=' ' THEN
         CH:=REPLACE(:NEW.NAMA_DOSEN,' ','');
      END IF;
      EXIT WHEN CH!=' ';
   END LOOP;
   IF LENGTH(:NEW.NAMA_DOSEN)<2 THEN
      RAISE ERR;
   ELSE
      JUMKAT:=LENGTH(:NEW.NAMA_DOSEN)-LENGTH(REPLACE(:NEW.NAMA_DOSEN,' ',''))+1;
      IF JUMKAT<2 THEN
         NM:=UPPER(SUBSTR(:NEW.NAMA_DOSEN,1,2));
      ELSE
         NM:=SUBSTR(:NEW.NAMA_DOSEN,1,1)||SUBSTR(:NEW.NAMA_DOSEN,INSTR(:NEW.NAMA_DOSEN,' ')+1,1);
      END IF;
      SELECT MAX(SUBSTR(KODE_DOSEN,3,3))+1 INTO IDM FROM DOSEN WHERE SUBSTR(KODE_DOSEN,1,2)=NM;
      IF IDM IS NULL THEN IDM:=1; 
      END IF;
      :NEW.KODE_DOSEN:=UPPER(NM)||LPAD(IDM,3,0);
   END IF;
EXCEPTION
   WHEN ERR THEN RAISE_APPLICATION_ERROR(-20000,'Panjang Nama Dosen harus lebih dari satu huruf');
END;
/  
SHOW ERR;

INSERT INTO DOSEN VALUES('','Tamariska Marcelline','P','tamariskacelline@gmail.com','jalan Ahmad No. 12','081384552458','Tetap');
INSERT INTO DOSEN VALUES('','Agatha','P','agatha@gmail.com','jalan Kendari blok AA No. 57','085911274387','Tetap');
INSERT INTO DOSEN VALUES('','Tony Mario','L','tonym@gmail.com','jalan Kupang Jaya gang XV No. 66','085143358003','Tetap');
INSERT INTO DOSEN VALUES('','Devina Tammy','P','devi@gmail.com','jalan Bukittinggi No. 129','085427380075','Tetap');
INSERT INTO DOSEN VALUES('','Goofy Gunardi Setiawan','L','goofygs@rocketmail.com','jalan Kertajaya blok I No. 04','082416987873','Tetap');
INSERT INTO DOSEN VALUES('','Kushno Santoso','L','kushno@gmail.com','jalan Villa Regensi blok III No. 16','081680590957','Tetap');
INSERT INTO DOSEN VALUES('','Indah Rejeki','P','indahrejeki@yahoo.com','jalan Villa Bukit Merah blok AC No. 110','083255125830','Tetap');
INSERT INTO DOSEN VALUES('','Metta Karimun','P','metta@yahoo.com','jalan Anggur Merah No. 41','083255125830','Tetap');
INSERT INTO DOSEN VALUES('','Sekar Sari','P','sekarsari@yahoo.com','jalan Anggur Putih No. 16','083673927839','Tidak Tetap');
INSERT INTO DOSEN VALUES('','Robyn Gunawan','L','robyng@yahoo.com','jalan Tinjauan No. 306','085630165125','Tidak Tetap');
INSERT INTO DOSEN VALUES('','Randi Setiadi','L','randis@yahoo.com','jalan Kunjungan No. 68','085169535125','Tetap');

CREATE OR REPLACE TRIGGER INSERTMK
BEFORE INSERT ON MASTER_MATAKULIAH
FOR EACH ROW
DECLARE
   JUR NUMBER; JUM NUMBER; NOKODE NUMBER; KOD VARCHAR2(10); ERR3 EXCEPTION;
   ERR EXCEPTION; ERR1 EXCEPTION; ERR2 EXCEPTION; SPS NUMBER; NMJ VARCHAR2(30);
BEGIN
   SELECT COUNT(*) INTO JUM FROM MASTER_JURUSAN WHERE NAMA_MJ=:NEW.JURUSAN_MK;
   IF JUM>0 THEN 
      IF LENGTH(:NEW.JURUSAN_MK)<3 THEN RAISE ERR2;
      ELSE :NEW.JURUSAN_MK:=LTRIM(:NEW.JURUSAN_MK); :NEW.JURUSAN_MK:=RTRIM(:NEW.JURUSAN_MK); SPS:=REGEXP_COUNT (:NEW.JURUSAN_MK,' ');
         IF SPS<1 THEN KOD:=UPPER(SUBSTR(:NEW.JURUSAN_MK,1,3));
         ELSIF SPS>0 AND SPS<2 THEN KOD:=UPPER(SUBSTR(:NEW.JURUSAN_MK,INSTR(:NEW.JURUSAN_MK,' ')+1,3));
         ELSE KOD:=KOD||SUBSTR(:NEW.JURUSAN_MK,1,1); NMJ:=:NEW.JURUSAN_MK;
            LOOP KOD:=UPPER(KOD||SUBSTR(NMJ,INSTR(NMJ,' ')+1,1));
               NMJ:=SUBSTR(NMJ,1,INSTR(NMJ,' ')-1)||
               SUBSTR(NMJ,INSTR(NMJ,' ')+1,LENGTH(NMJ)-INSTR(NMJ,' '));
               EXIT WHEN LENGTH(KOD)=3;
            END LOOP;
         END IF;
      END IF;
      SELECT COUNT(*) INTO JUM FROM MASTER_MATAKULIAH WHERE SUBSTR(KODE_MK,1,3)=KOD;
      IF JUM>0 THEN SELECT COUNT(*) INTO JUR FROM MASTER_MATAKULIAH WHERE JURUSAN_MK=:NEW.JURUSAN_MK AND SUBSTR(KODE_MK,1,3)=KOD;
         IF JUR>0 THEN SELECT COUNT(NAMA_MK) INTO JUM FROM MASTER_MATAKULIAH WHERE NAMA_MK=:NEW.NAMA_MK AND JURUSAN_MK=:NEW.JURUSAN_MK;
            IF JUM>0 THEN RAISE ERR3;
            ELSE SELECT MAX(SUBSTR(KODE_MK,4,3))+1 INTO NOKODE FROM MASTER_MATAKULIAH WHERE JURUSAN_MK=:NEW.JURUSAN_MK;
            END IF;      
         ELSE KOD:=''; LOOP KOD:=KOD||SUBSTR('ABCDEFGHIJKLMNOPQRSTUVWXYZ',DBMS_RANDOM.VALUE(1,26),1); 
            EXIT WHEN LENGTH(KOD)=3; END LOOP; NOKODE:=1;
         END IF;
      ELSE NOKODE:=1;
      END IF; 
      SELECT COUNT(*) INTO JUM FROM MASTER_MATAKULIAH WHERE JURUSAN_MK=:NEW.JURUSAN_MK;
      IF JUM>0 THEN KOD:=''; SELECT MAX(SUBSTR(KODE_MK,1,3)) INTO KOD FROM MASTER_MATAKULIAH WHERE JURUSAN_MK=:NEW.JURUSAN_MK;
         SELECT COUNT(*) INTO JUR FROM MASTER_MATAKULIAH WHERE JURUSAN_MK=:NEW.JURUSAN_MK AND SUBSTR(KODE_MK,1,3)=KOD;
         IF JUR>0 THEN SELECT COUNT(NAMA_MK) INTO JUM FROM MASTER_MATAKULIAH WHERE NAMA_MK=:NEW.NAMA_MK AND JURUSAN_MK=:NEW.JURUSAN_MK AND SUBSTR(KODE_MK,1,3)=KOD;
            IF JUM>0 THEN RAISE ERR3;
            ELSE SELECT MAX(SUBSTR(KODE_MK,4,3))+1 INTO NOKODE FROM MASTER_MATAKULIAH WHERE JURUSAN_MK=:NEW.JURUSAN_MK AND SUBSTR(KODE_MK,1,3)=KOD;
            END IF;      
         ELSE KOD:=''; LOOP KOD:=KOD||SUBSTR('ABCDEFGHIJKLMNOPQRSTUVWXYZ',DBMS_RANDOM.VALUE(1,26),1); 
            EXIT WHEN LENGTH(KOD)=3; END LOOP; NOKODE:=1;
         END IF;
      END IF; :NEW.KODE_MK:=KOD||LPAD(NOKODE,3,0);
   ELSE RAISE ERR1;
   END IF;
EXCEPTION
   WHEN ERR THEN RAISE_APPLICATION_ERROR(-20000,'Kelas sudah tersedia');
   WHEN ERR1 THEN RAISE_APPLICATION_ERROR(-20001,'Nama Jurusan Tidak Tersedia');
   WHEN ERR2 THEN RAISE_APPLICATION_ERROR(-20002,'Panjang Nama Jurusan harus minimal tiga huruf');
   WHEN ERR3 THEN RAISE_APPLICATION_ERROR(-20003,'Nama Mata Kuliah sudah tersedia');
END;
/
SHOW ERR;

INSERT INTO MASTER_MATAKULIAH VALUES('','Bahasa Daerah','Sistem Informasi Bisnis',4,3);
INSERT INTO MASTER_MATAKULIAH VALUES('','Bahasa Daerah','Sistem Informasi Bisnis',4,3);
INSERT INTO MASTER_MATAKULIAH VALUES('','Bahasa Indonesia','Teknik Informatika',3,3);
INSERT INTO MASTER_MATAKULIAH VALUES('','Bahasa Indonesia','Manajemen Informatika',3,3);
INSERT INTO MASTER_MATAKULIAH VALUES('','Bahasa Inggris','Teknik Informatika',2,3);
INSERT INTO MASTER_MATAKULIAH VALUES('','Bahasa Romawi','Teknik Informatika',2,3);
INSERT INTO MASTER_MATAKULIAH VALUES('','Bahasa Perancis','Teknik Informatika',4,3);
INSERT INTO MASTER_MATAKULIAH VALUES('','Bahasa Rusia','Teknik Informatika',4,3);
INSERT INTO MASTER_MATAKULIAH VALUES('','Pendidikan Kewarganegaraan','Teknik Informatika',4,3);
INSERT INTO MASTER_MATAKULIAH VALUES('','Bahasa Rusia','Bahasa',4,3);
INSERT INTO MASTER_MATAKULIAH VALUES('','Bahasa Rusia','Ilmu Komunikasi',4,3);
INSERT INTO MASTER_MATAKULIAH VALUES('','Pendidikan Kewarganegaraan','Desain Komunikasi Visual',4,3);

INSERT INTO MASTER_MATAKULIAH VALUES('','Budi Pekerti','Desain Interior',4,3);
INSERT INTO MASTER_MATAKULIAH VALUES('','Geografi','Desain Interior',4,3);
INSERT INTO MASTER_MATAKULIAH VALUES('','Sejarah','Desain Interior',4,3);
INSERT INTO MASTER_MATAKULIAH VALUES('','Budi Pekerti','Ahli Interior',4,3);
INSERT INTO MASTER_MATAKULIAH VALUES('','Geografi','Ahli Interior',4,3);
INSERT INTO MASTER_MATAKULIAH VALUES('','Sejarah','Ahli Interior',4,3);
INSERT INTO MASTER_MATAKULIAH VALUES('','Matematika','Ahli Interior',4,3);
INSERT INTO MASTER_MATAKULIAH VALUES('','Kimia','Farmasi',4,3);
INSERT INTO MASTER_MATAKULIAH VALUES('','Kimia Praktek 1','Farmasi',4,4);
INSERT INTO MASTER_MATAKULIAH VALUES('','Kimia Praktek 2','Farmasi',4,4);
INSERT INTO MASTER_MATAKULIAH VALUES('','Teknik Desain','Teknik Produk',4,2);

INSERT INTO MASTER_MATAKULIAH VALUES('','Pemrograman Client Server','Teknik Informatika',4,3);
INSERT INTO MASTER_MATAKULIAH VALUES('','Pemrograman Client Server','Sistem Informasi Bisnis',4,3);
INSERT INTO MASTER_MATAKULIAH VALUES('','Akuntansi','Sistem Informasi Bisnis',7,3);
INSERT INTO MASTER_MATAKULIAH VALUES('','Akuntansi','Sistem Informasi Bisnis',7,3);
INSERT INTO MASTER_MATAKULIAH VALUES('','Sistem Digital','Teknik Elektro',4,3);
INSERT INTO MASTER_MATAKULIAH VALUES('','Kalkulus 3','Teknik Industri',4,3);
INSERT INTO MASTER_MATAKULIAH VALUES('','Teknik Desain','Desain Produk',1,2);
INSERT INTO MASTER_MATAKULIAH VALUES('','Software Design Pattern','Teknik Informatika',4,3);
INSERT INTO MASTER_MATAKULIAH VALUES('','Software Design Pattern','Teknik Informatika',4,3);
INSERT INTO MASTER_MATAKULIAH VALUES('','Membangun Empat Dimensi','Ahli Sipil',6,3);
INSERT INTO MASTER_MATAKULIAH VALUES('','Membangun Tiga Dimensi','Teknik Sipil',4,3);
INSERT INTO MASTER_MATAKULIAH VALUES('','Kalkulus 4','Teknik Sipil',5,3);

CREATE OR REPLACE TRIGGER INSERTJADWALMK
BEFORE INSERT ON JADWAL_MATAKULIAH
FOR EACH ROW
DECLARE
   JUM NUMBER; ERR EXCEPTION; ERR1 EXCEPTION; HR NUMBER;
BEGIN
   SELECT COUNT(*) INTO JUM FROM MASTER_MATAKULIAH WHERE KODE_MK=:NEW.KODE_MK;
   IF JUM>0 THEN SELECT COUNT(*) INTO JUM FROM JADWAL_MATAKULIAH WHERE KODE_MK=:NEW.KODE_MK AND KELAS_MK=:NEW.KELAS_MK;
      IF JUM>0 THEN RAISE ERR; END IF;
   END IF;
   HR:=TO_NUMBER(SUBSTR(:NEW.JAM_MK,1,2))*100+TO_NUMBER(SUBSTR(:NEW.JAM_MK,4,2));
   SELECT COUNT(*) INTO JUM FROM JADWAL_MATAKULIAH WHERE KODE_PENGAJAR=:NEW.KODE_PENGAJAR AND HARI_MK=:NEW.HARI_MK AND 
      TO_NUMBER(SUBSTR(JAM_MK,1,2))*100+TO_NUMBER(SUBSTR(JAM_MK,4,2))-HR<230 AND TO_NUMBER(SUBSTR(JAM_MK,1,2))*100+TO_NUMBER(SUBSTR(JAM_MK,4,2))-HR>-230;
   IF JUM>0 THEN RAISE ERR1;
   ELSE IF HR<1000 THEN :NEW.JAM_MK:='0'||TO_CHAR(SUBSTR(HR,1,1))||':'||TO_CHAR(SUBSTR(HR,2,2));
      ELSE :NEW.JAM_MK:=TO_CHAR(SUBSTR(HR,1,2))||':'||TO_CHAR(SUBSTR(HR,3,2));
      END IF;
   END IF;
EXCEPTION
   WHEN ERR THEN RAISE_APPLICATION_ERROR(-20000,'Kelas Mata Kuliah Sudah Tersedia di Jadwal');
   WHEN ERR1 THEN RAISE_APPLICATION_ERROR(-20001,'Dosen Sedang Mengajar di Waktu Tersebut');
END;
/
SHOW ERR;

CREATE OR REPLACE TRIGGER INSERTMHS
BEFORE INSERT ON MAHASISWA
FOR EACH ROW
DECLARE
   NOM VARCHAR2(5); NOM1 VARCHAR2(5); NOM2 NUMBER; NONRP NUMBER; ERR EXCEPTION;
BEGIN
   SELECT COUNT(*) INTO NOM FROM MASTER_JURUSAN WHERE NAMA_MJ=:NEW.JURUSAN_MHS;
   IF NOM>0 THEN NOM:=SUBSTR(:NEW.THN_REG,1,1)||SUBSTR(:NEW.THN_REG,3,2);
      SELECT KODE_MJ INTO NOM1 FROM MASTER_JURUSAN WHERE NAMA_MJ=:NEW.JURUSAN_MHS;
      SELECT COUNT(*) INTO NOM2 FROM MAHASISWA WHERE SUBSTR(NRP_MHS,1,6)=CONCAT(NOM,NOM1);
      IF NOM2>0 THEN SELECT MAX(SUBSTR(NRP_MHS,7,3))+1 INTO NONRP FROM MAHASISWA WHERE SUBSTR(NRP_MHS,1,6)=CONCAT(NOM,NOM1); 
      ELSE NONRP:=1;
      END IF;
   ELSE RAISE ERR;
   END IF; :NEW.NRP_MHS:=CONCAT(CONCAT(NOM,NOM1),LPAD(NONRP,3,0)); :NEW.SMST_MHS:=1;
EXCEPTION
   WHEN ERR THEN RAISE_APPLICATION_ERROR(-20000,'Nama Jurusan Tidak Tersedia');
END;
/
SHOW ERR;

INSERT INTO MAHASISWA VALUES(0,2016,'Edwin Lo','Teknik Informatika','B',1,TO_DATE('24-06-1998', 'DD-MM-YYYY'),'L','edwin@gmail.com','SDPS Gang 15 No. 150','082337123047','Aktif','TM002');
INSERT INTO MAHASISWA VALUES(0,2015,'Matalangit Zerafim','Teknik Informatika','A',1,TO_DATE('05-09-1997', 'DD-MM-YYYY'),'L','matalangit@yahoo.com','jalan Kertajaya No. 225','083521375645','Aktif','TM001');
INSERT INTO MAHASISWA VALUES(0,2018,'Ricardo','Teknik Elektro','C',1,TO_DATE('01-11-2000', 'DD-MM-YYYY'),'L','ricardo@yahoo.com','jalan Bukit Indah No. 02','083521375645','Cuti','KS001');
INSERT INTO MAHASISWA VALUES(0,2018,'Fransisca Maria','Teknik Industri','A',1,TO_DATE('06-06-2000', 'DD-MM-YYYY'),'P','maria@gmail.com','jalan Melati Putih No. 13','031177006868','Aktif','IR001');
INSERT INTO MAHASISWA VALUES(0,2017,'Fanny Kusuma','Desain Produk','A',1,TO_DATE('27-08-1998', 'DD-MM-YYYY'),'P','sunny@gmail.com','jalan Pelangi No. 149','085948133712','Tidak Aktif','MK001');
INSERT INTO MAHASISWA VALUES(0,2017,'Hansen Oetomo','Desain Komunikasi Visual','B',1,TO_DATE('12-10-1999', 'DD-MM-YYYY'),'L','hansen@gmail.com','jalan Surakarta No. 09','081029124149','Cuti','DT001');
INSERT INTO MAHASISWA VALUES(0,2016,'Philip Cahya','Sistem Informasi Bisnis','C',1,TO_DATE('28-02-1998', 'DD-MM-YYYY'),'L','philip@gmail.com','jalan Sekarjaya Blok C No. 34','085600402155','Tidak Aktif','GG001');
INSERT INTO MAHASISWA VALUES(0,2016,'Karent Finnartha','Teknik Informatika','B',1,TO_DATE('24-06-1998', 'DD-MM-YYYY'),'L','karent@gmail.com','SDPS Gang 15 No. 150','082337123047','Aktif','TM002');
INSERT INTO MAHASISWA VALUES(0,2015,'Steven Kwan','Teknik Sipil','A',1,TO_DATE('05-09-1997', 'DD-MM-YYYY'),'L','steve@yahoo.com','jalan Kertajaya No. 225','083521375645','Aktif','TM001');
INSERT INTO MAHASISWA VALUES(0,2018,'Henny Widayanti','Desain Interior','C',1,TO_DATE('01-11-2000', 'DD-MM-YYYY'),'P','henny@yahoo.com','jalan Bukit Indah No. 02','083521375645','Cuti','KS001');
INSERT INTO MAHASISWA VALUES(0,2018,'Olive Liman','Pariwisata','A',1,TO_DATE('06-06-2000', 'DD-MM-YYYY'),'P','olive@gmail.com','jalan Melati Putih No. 13','031177006868','Aktif','IR001');
INSERT INTO MAHASISWA VALUES(0,2016,'Hana Regina','Arsitek','A',1,TO_DATE('27-08-1998', 'DD-MM-YYYY'),'P','hana@gmail.com','jalan Pelangi No. 149','085948133712','Tidak Aktif','MK001');
INSERT INTO MAHASISWA VALUES(0,2017,'Rico Sumargo','Desain Komunikasi Visual','B',1,TO_DATE('12-10-1999', 'DD-MM-YYYY'),'L','rico@gmail.com','jalan Surakarta No. 09','081029124149','Cuti','DT001');
INSERT INTO MAHASISWA VALUES(0,2016,'Hendarto Wijaya','Sistem Informasi Bisnis','C',1,TO_DATE('28-02-1998', 'DD-MM-YYYY'),'L','hendartowijaya@gmail.com','jalan Sekarjaya Blok C No. 34','085600402155','Tidak Aktif','GG001');
INSERT INTO MAHASISWA VALUES(0,2012,'Danny Hendrawan','Teknik Nuklir','C',1,TO_DATE('28-02-1998', 'DD-MM-YYYY'),'L','danny@gmail.com','jalan Sekarjaya Blok C No. 34','085600402155','Tidak Aktif','GG001');

CREATE OR REPLACE TRIGGER INSERTMKMAHASISWA
BEFORE INSERT ON PENGAMBILAN_MATAKULIAH
FOR EACH ROW
DECLARE
   CEK NUMBER; ERR EXCEPTION; ERR1 EXCEPTION; ERR2 EXCEPTION; NAMJUR VARCHAR2(30);
BEGIN
   :NEW.NILAI_UTS:=DBMS_RANDOM.VALUE(40,100); :NEW.NILAI_UAS:=DBMS_RANDOM.VALUE(40,100);
   SELECT COUNT(NRP_MHS) INTO CEK FROM MAHASISWA WHERE NRP_MHS=:NEW.NRP_MHS; 
   IF CEK>=1 THEN SELECT JURUSAN_MHS INTO NAMJUR FROM MAHASISWA WHERE NRP_MHS=:NEW.NRP_MHS; 
      SELECT COUNT(*) INTO CEK FROM MASTER_MATAKULIAH WHERE JURUSAN_MK=NAMJUR AND KODE_MK=:NEW.KODE_MK;
      IF CEK>0 THEN :NEW.NILAI_AKHIR:=(:NEW.NILAI_UTS+:NEW.NILAI_UAS)/2;
         IF :NEW.NILAI_AKHIR>=80 THEN :NEW.GRADE:='A'; :NEW.STATUS_MATKUL:='Lulus';
         ELSIF :NEW.NILAI_AKHIR>=70 AND :NEW.NILAI_AKHIR<80 THEN :NEW.GRADE:='B'; :NEW.STATUS_MATKUL:='Lulus';
         ELSIF :NEW.NILAI_AKHIR>=56 AND :NEW.NILAI_AKHIR<=69 THEN :NEW.GRADE:='C'; :NEW.STATUS_MATKUL:='Lulus';
         ELSIF :NEW.NILAI_AKHIR>=46 AND :NEW.NILAI_AKHIR<56 THEN :NEW.GRADE:='D'; :NEW.STATUS_MATKUL:='Lulus';
         ELSIF :NEW.NILAI_AKHIR<46 THEN :NEW.GRADE:='E'; :NEW.STATUS_MATKUL:='Tidak Lulus'; END IF;
         SELECT MAX(KE) INTO :NEW.KE FROM PENGAMBILAN_MATAKULIAH WHERE KODE_MK=:NEW.KODE_MK AND NRP_MHS=:NEW.NRP_MHS;
         IF :NEW.KE IS NULL THEN :NEW.KE:=1; ELSE :NEW.KE:=:NEW.KE+1; END IF;
      ELSE SELECT COUNT(KODE_MK) INTO CEK FROM MASTER_MATAKULIAH WHERE KODE_MK=:NEW.KODE_MK;
         IF CEK>0 THEN RAISE ERR1;
         ELSE RAISE ERR2;
         END IF;
      END IF;
   ELSE RAISE ERR;
   END IF;
EXCEPTION
   WHEN ERR THEN RAISE_APPLICATION_ERROR(-20000,'NRP Mahasiswa Tidak Tersedia');
   WHEN ERR1 THEN RAISE_APPLICATION_ERROR(-20001,'Kode Mata Kuliah Tidak Sesuai Dengan Jurusan Mahasiswa');
   WHEN ERR2 THEN RAISE_APPLICATION_ERROR(-20002,'Kode Mata Kuliah Tidak Tersedia');
END;
/
SHOW ERR;

COMMIT;